
' System namespaces
Imports System.IO
Imports System.Globalization
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Windows.Forms
Imports Microsoft.Office.Interop.Excel


''' <summary>
''' Controls the flow through the steps of a geocoding
''' </summary>
''' <remarks></remarks>
''' 
Public Class GeocodingController

#Region " public methods "

    Public Shared Sub RunGeocoding(ByVal geocSettings As PGISGeocodingSettings, _
                        ByVal tempDir As DirectoryInfo)


        If geocSettings Is Nothing Then
            Throw ExceptionProvider.NullArgException("geocSettings")
        End If

        If tempDir Is Nothing Then
            Throw ExceptionProvider.NullArgException("tempDirectory")
        Else
            If Not tempDir.Exists Then
                tempDir.Create()
            End If
        End If


            Dim street1 As String = ""
            Dim houseNumber As String = ""
            Dim street2 As String = ""
            Dim hectoValue As String = ""
            Dim city As String = ""
            Dim street2Alias As String = ""
            Dim hectoAlias As String = ""

            ' If the table is already open, close it first so we can overwrite it.
            MITableProxy.IfTableOpenCloseTable(geocSettings.OutputTable)

            Dim geoCodedTable = ConvertExcelToTab(geocSettings.InputFile, geocSettings.OutputTable, tempDir, geocSettings.ColumnTypes)

            ' Now that the table is open, we can determine the numbers of the columns.
            Dim colIndexStreet1 = MIColumnProxy.GetColumnID(geocSettings.OutputTable, geocSettings.InputStreet1Field)
            Dim colIndexHouseNumber = MIColumnProxy.GetColumnID(geocSettings.OutputTable, ConvertToValidName(geocSettings.InputNumberField))
            Dim colIndexMunicipality = MIColumnProxy.GetColumnID(geocSettings.OutputTable, geocSettings.InputMunicipalityField)

            ' Build column aliases for extracting the cell values from the table.
            Dim street1Alias As String = MIColumnProxy.FormatLongColumnID(geocSettings.OutputTable, colIndexStreet1)
            Dim numberAlias As String = MIColumnProxy.FormatLongColumnID(geocSettings.OutputTable, colIndexHouseNumber)
            Dim communeAlias As String = MIColumnProxy.FormatLongColumnID(geocSettings.OutputTable, colIndexMunicipality)

            ' Intersections are optional, so we can not always find that column.
            Dim colIndexStreet2 As Short = PGISGeocodingSettings.ILLEGAL_COLUMN_INDEX

            If geocSettings.SearchIntersections Then

                colIndexStreet2 = MIColumnProxy.GetColumnID(geocSettings.OutputTable, geocSettings.InputStreet2Field)
                street2Alias = MIColumnProxy.FormatLongColumnID(geocSettings.OutputTable, colIndexStreet2)

            End If

            ' Hectometer poles are optional, so we can not always find that column.
            If geocSettings.HectoMeterPolesEnabled _
               And geocSettings.SearchHectormeterPoles Then

                If Not MITableProxy.IsTabFileOpen(geocSettings.TabFileHectoMeterPoles) Then
                    MITableProxy.OpenTable(geocSettings.TabFileHectoMeterPoles, False)
                End If

                Dim colIndexHectometer As Short = _
                    MIColumnProxy.GetColumnID(geocSettings.OutputTable, geocSettings.InputHectoMeterField)
                hectoAlias = MIColumnProxy.FormatLongColumnID(geocSettings.OutputTable, colIndexHectometer)

            End If

        ' Optionally open the address points:
        'If geocSettings.AddressPointsEnabled Then
        '    If Not MITableProxy.IsTabFileOpen(geocSettings.TabFileAddressPoints) Then
        '        MITableProxy.OpenTable(geocSettings.TabFileAddressPoints, False)
        '    End If
        'End If

        MapBasicInterop.ExecuteCommand(String.Format("Set CoordSys {0} ", geocSettings.OutputCoordinateSystem))

        ' Open the workspace
        MapBasicInterop.ExecuteCommand(String.Format("Run Application ""{0}""", geocSettings.Workspace))

            'The marker object to show a point on the map
            Dim setStyleCommand = String.Format("Set Style Symbol MakeSymbol(34, {0}, 6)", MapBasicConstants.RED)

            MapBasicInterop.ExecuteCommand(setStyleCommand)

            ' Loop counter, also RowID of current record
            Dim currentRecord As Integer = -1
            ' result of a match for one record
            Dim gcResult As New GeocodingResult

            MITableProxy.FetchFirstRecord(geoCodedTable)

            While Not MITableProxy.EndOfTable(geoCodedTable)

                currentRecord = currentRecord + 1

                gcResult.Clear() ' Initialization of output arguments

                gcResult.RowId = currentRecord

                street1 = MapBasicInterop.Evaluate(street1Alias).Trim
                houseNumber = MapBasicInterop.Evaluate(numberAlias).Trim
                city = MapBasicInterop.Evaluate(communeAlias).Trim
                houseNumber = RemoveLetters(houseNumber)
                ' Intersections is the first thing we try.  We consider it the most specific match.
                If geocSettings.SearchIntersections Then ' Only try intersections if it is enabled.

                    street2 = MapBasicInterop.Evaluate(street2Alias).Trim

                    If street2 <> "" Then ' No second street => skip intersections

                        Dim addressToFind = String.Format("{0} && {1}", street1, street2)
                        GeocodeWithMapInfo(geocSettings, addressToFind, city, gcResult)

                    End If

                End If
            ' Suspended, waiting for an _ap file
            'If (Not gcResult.PointFound) And geocSettings.AddressPointsEnabled Then

            '    GeocodeWithAddressPoints(geocSettings, street1, houseNumber, city, gcResult)

            'End If

            If (Not gcResult.PointFound) _
                    And geocSettings.HectoMeterPolesEnabled _
                    And geocSettings.SearchHectormeterPoles Then

                    hectoValue = MapBasicInterop.Evaluate(hectoAlias)

                    GeocodeWithHectoMeter(geocSettings, street1, hectoValue, gcResult)

                End If

                If Not gcResult.PointFound Then

                    Dim addressToFind = ""

                    If houseNumber.Trim <> "" Then

                        addressToFind = String.Format("{0} {1}", street1, houseNumber)
                        GeocodeWithMapInfo(geocSettings, addressToFind, city, gcResult)


                    End If

                    If Not gcResult.PointFound Then

                        addressToFind = street1
                        GeocodeWithMapInfo(geocSettings, addressToFind, city, gcResult)

                        ' Check if the street is not too long
                        If geocSettings.MaxStreetLength > 0 Then
                            CheckStreetLength(geocSettings, _
                                              MITableProxy.TabFileToTableName(geocSettings.TabFileStreetlength), _
                                              street1, _
                                              city, _
                                              gcResult)
                        End If
                        gcResult.Address = String.Format("{0} {1}", street1, houseNumber).ToUpper
                    End If

                End If

                MapBasicInterop.ExecuteCommand(String.Format( _
                                                 MapBasicInterop.GetMapInfoNumFormat, _
                                                 "Update {0} " & _
                                                 "Set  GeocodeStatus = ""{1}"", " & _
                                                 "XCoord = {2}, YCoord = {3}, " & _
                                                 "GeocodeType = ""{4}"", " & _
                                                 "Address = ""{5}"" " & _
                                                 "Where RowId = {6}", _
                                                 geocSettings.OutputTable, _
                                                 gcResult.GetStatusText(), _
                                                 gcResult.XCoord, _
                                                 gcResult.YCoord, _
                                                 gcResult.Type, _
                                                 gcResult.Address, _
                                                 currentRecord))

                If gcResult.PointFound Then

                    Dim updateCmd = String.Format(MapBasicInterop.GetMapInfoNumFormat, _
                                                  "Update {0} " & _
                                                   "Set obj = CreatePoint ({1},{2}) " & _
                                                   "Where Rowid = {3}", _
                                                   geocSettings.OutputTable, _
                                                   gcResult.XCoord, _
                                                   gcResult.YCoord, _
                                                   currentRecord)
                    MapBasicInterop.ExecuteCommand(updateCmd)


                End If

                MITableProxy.FetchNextRecord(geoCodedTable)
            End While

            MITableProxy.SaveTable(geocSettings.OutputTable)

            MIMapProxy.AddLayer(geocSettings.OutputTable, False)

            ShowNotGeocodedRecords(geocSettings.OutputTable, "NietGevondenRecords")

    End Sub

    Public Shared Function ReadHeaderFromInputFile(ByVal inputFile As String, _
                                            ByVal tempRegisterPath As String _
                                            ) As List(Of String)

        If String.IsNullOrEmpty(inputFile) Then

            Throw ExceptionProvider.NullOrEmptyArgException("inputFile")

        ElseIf Not File.Exists(inputFile) Then

            Throw ExceptionProvider.PathArgNotFoundException("inputFile", inputFile)

        End If

        Dim tempTableName As String = Path.GetFileNameWithoutExtension(tempRegisterPath)

        RegisterTable(inputFile, tempRegisterPath)

        Try
            tempTableName = MITableProxy.OpenTable(tempRegisterPath, False)

            Return GetTableHeader(tempTableName)

        Finally

            MITableProxy.IfTableOpenCloseTable(tempTableName)

        End Try

    End Function

    Public Shared Function ConvertExcelToTab(ByVal inputFile As String, _
                                     ByVal outputTable As String, _
                                     ByVal tempDirectory As DirectoryInfo, _
                                     ByVal columnTypes As List(Of ColumnTypeDescriptor) _
                                     ) As String

        If String.IsNullOrEmpty(inputFile) Then

            Throw ExceptionProvider.NullOrEmptyArgException("inputFile")

        ElseIf Not File.Exists(inputFile) Then

            Throw ExceptionProvider.PathArgNotFoundException("inputFile", inputFile)

        End If

        If String.IsNullOrEmpty(outputTable) Then
            Throw ExceptionProvider.NullOrEmptyArgException("outputTable")
        End If

        If tempDirectory Is Nothing Then
            Throw ExceptionProvider.NullArgException("tempDirectory")
        Else
            If Not tempDirectory.Exists Then
                tempDirectory.Create()
            End If
        End If

        If columnTypes Is Nothing Then
            Throw ExceptionProvider.NullArgException("columnTypes")
        End If

        If columnTypes.Count = 0 Then
            Throw ExceptionProvider.ArgumentOutOfRange("columnTypes", columnTypes, "columnTypes must contain at least one element.")
        End If

        'Dim inputFileInfo As New FileInfo(inputFile)
        Dim tempRegisterPath = Path.Combine(tempDirectory.FullName, outputTable & ".tab")


        RegisterTable(inputFile, tempRegisterPath)

        Dim convertTablePath = Path.Combine(PGISConfigurationManager.GetInstance.FileSettings.IslpFolder, outputTable & ".tab")


        Try

            '
            ' Copy the table to a native MapInfo table'
            '
            outputTable = MITableProxy.OpenTable(New FileInfo(tempRegisterPath), False)
            ' 1. Save it to a new TAB file
            MITableProxy.SaveTableTo(outputTable, New FileInfo(convertTablePath), False)
            ' 2. close the original table
            MITableProxy.CloseTable(outputTable, False)
            ' 3. open the new tab file 
            outputTable = MITableProxy.OpenTable(New FileInfo(convertTablePath), False)

            Dim fastEditCommand As String = String.Format("Set Table {0} FastEdit ON", outputTable)
            MapBasicInterop.ExecuteCommand(fastEditCommand)

            ' cleanup: MS Excel may add some empty cell
            ' Also, the first record contains the column names

            UseFirstRowAsColumnNames(outputTable)

            ConvertColumnTypes(outputTable, columnTypes)

            MITableProxy.RemoveEmptyColumns(outputTable)
            'RemoveEmptyColumns(outputTableProxy)

            ' Add the columns we need for storing the geocoding results.
            RestructureTableForGeocoding(outputTable)

            MITableProxy.SaveTable(outputTable)
            Return outputTable

        Catch ex As Exception

            ' Clean up temp stuff and rethrow the original exception
            MITableProxy.IfTableOpenCloseTable(outputTable)

            Throw ex

        End Try

    End Function

#End Region

#Region " private methods "

    Private Shared Sub RegisterTable(ByVal inputFile As String, ByVal outputTabPath As String)

        CheckFileParameter(inputFile, "inputFile")

        Dim inputFileInfo As New FileInfo(inputFile)

        Dim inputType As String = ""
        Dim extension = inputFileInfo.Extension.ToLower
   
        ' Close ALL tables that are one and the same TAB file:
        For Each tbl In MITableProxy.ListTableNames()

            Dim tabFile As String = MITableProxy.GetTableInfo(tbl, DirectCast(MITableInfo.TABFILE, Short))
            If tabFile.ToUpper = outputTabPath.ToUpper Then
                MITableProxy.CloseTable(tbl, False)
            End If

        Next

        Select Case extension

            Case ".xls", ".xlsx"
                inputType = "XLS"

            Case ".csv", ".txt"
                inputType = "ASCII"

            Case Else

                MessageBox.Show(String.Format(My.Resources.NotSupportedFileExtension, extension))

        End Select
        Try

            Dim registerCmd = ""

            If extension = ".xlsx" Then


                Dim oldCI As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
                System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")
                Try
                    Dim exclelap = New Microsoft.Office.Interop.Excel.Application
                    Dim xlWorkSheet = CType(exclelap.Workbooks.Open(inputFile).Worksheets.Item(1), Worksheet)
                    Dim name = xlWorkSheet.Name
                    exclelap.Quit()
                    releaseObject(xlWorkSheet)
                    releaseObject(exclelap)
                    registerCmd = "Register Table """ & inputFile & """ TYPE """ & inputType & """ Range """ & name & """   Into """ & outputTabPath & """ "

                Finally

                    System.Threading.Thread.CurrentThread.CurrentCulture = oldCI
                End Try


            Else
                registerCmd = "Register Table """ & inputFile & """ TYPE """ & inputType & """  Into """ & outputTabPath & """ "

            End If


            MapBasicInterop.ExecuteCommand(registerCmd)

        Catch ex As Exception

            Throw New PoliceGisException(String.Format(My.Resources.ExceptionMessages.CouldNotRegister, inputFile, Environment.NewLine), ex)

        End Try

    End Sub

    Private Shared Sub releaseObject(ByVal obj As Object)

        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try

    End Sub

    Private Shared Sub UseFirstRowAsColumnNames(ByVal tableName As String)

        MITableProxy.FetchRecord(tableName, 1)

        Dim colNames As New List(Of String)

        For cl As Short = 1 To MITableProxy.GetColumnCountIncludingOBJ(tableName)

            ' Get the value in the first row, which is the new column name.
            ' You need to clean up some of the values because they are not
            ' valid identifiers for a column.
            Dim colAlias = MIColumnProxy.FormatLongColumnID(tableName, cl)
            Dim ColName = MapBasicInterop.Evaluate(colAlias)

            If String.IsNullOrEmpty(ColName) OrElse ColName = "0" Then
                ColName = "cl" & cl.ToString(MIColumnProxy.GetColumnIDNumberFormat())
            End If

            ColName = ConvertToValidName(ColName)

            colNames.Add(ColName)
            Dim oldColName = MIColumnProxy.GetColumnName(tableName, cl)
            Dim renameColCmd = "Alter Table " & tableName & " ( rename " & oldColName & " " & ColName & ") Interactive"
            MapBasicInterop.ExecuteCommand(renameColCmd)

        Next

        MITableProxy.DeleteRecord(tableName, 1)
        MITableProxy.SaveTable(tableName)
        MITableProxy.PackTable(tableName)
        MITableProxy.SaveTable(tableName)

    End Sub

    ''' <summary>
    ''' Retrieve the columns names from the first record.
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 

    Private Shared Function GetTableHeader(ByVal tableName As String) As List(Of String)

        MITableProxy.FetchRecord(tableName, 1)

        Dim colNames As New List(Of String)

        For cl As Short = 1 To MITableProxy.GetColumnCountIncludingOBJ(tableName)

            ' Clean up the table names
            Dim colAlias = MIColumnProxy.FormatLongColumnID(tableName, cl)
            Dim tempColName = MapBasicInterop.Evaluate(colAlias)

            If String.IsNullOrEmpty(tempColName) OrElse tempColName = "0" Then
                tempColName = "cl" & cl.ToString(MIColumnProxy.GetColumnIDNumberFormat())

            ElseIf Not Char.IsLetter(tempColName(0)) OrElse tempColName(0) = "_" Then
                tempColName = "_" & tempColName

            End If

            Dim newColNameBuilder As New StringBuilder
            For i As Integer = 0 To tempColName.Length - 1

                If Char.IsWhiteSpace(tempColName(i)) Then
                    newColNameBuilder.Append("_")
                Else
                    newColNameBuilder.Append(tempColName(i))
                End If

            Next

            colNames.Add(newColNameBuilder.ToString)

        Next

        Return colNames

    End Function

    Private Shared Sub RestructureTableForGeocoding(ByVal tableName As String)

        MITableProxy.MakeMappable(tableName, CoreLibConstants.CS_LAMBERT_1972)

        MITableProxy.AddColumn(tableName, "XCoord", "FLOAT", True)
        MITableProxy.AddColumn(tableName, "YCoord", "FLOAT", True)
        MITableProxy.AddColumn(tableName, "Address", "Char(254)", True)
        MITableProxy.AddColumn(tableName, "GeocodeStatus", "Char(20)", True)
        MITableProxy.AddColumn(tableName, "GeocodeType", "Char(3)", True)
        MITableProxy.SaveTable(tableName)

    End Sub

    Private Shared Sub ConvertColumnTypes(ByVal tableName As String, _
                                   ByVal columnTypes As ICollection(Of ColumnTypeDescriptor))

        If String.IsNullOrEmpty(tableName) Then
            Throw ExceptionProvider.NullArgException("tableName")

        ElseIf Not MITableProxy.IsTableOpen(tableName) Then
            Throw New PoliceGisException(String.Format("Table {0} must be open to convert the types of its columns.", tableName))

        End If

        If columnTypes Is Nothing Then
            Throw ExceptionProvider.NullArgException("columnTypes")
        End If

        ' If there are no time colums we don't need to do any text processing on the table.
        If ContainsTimeColumns(tableName, columnTypes) Then
            AddTimeValidationField(tableName, columnTypes)
        End If

        For c As Short = 1 To Convert.ToInt16(columnTypes.Count)

            'Dim colProxy As New MIColumnProxy(tableProxy, c)
            Dim colName = MIColumnProxy.GetColumnName(tableName, c)
            ' Array counts from 0 but MapInfo column counts from 1!
            Dim newType As String = columnTypes(c - 1).TypeString()
            Dim originalType = MIColumnProxy.GetColumnTypeDescriptor(tableName, colName).TypeString

            ' Do not change it if the type is the same
            If newType <> originalType Then

                Dim alterColumnCmd = String.Format("Alter table {0} ( Modify {1} {2} )", _
                            tableName, colName, _
                            newType)

                MapBasicInterop.ExecuteCommand(alterColumnCmd)

            End If

        Next
        MITableProxy.SaveTable(tableName)
    End Sub

    Private Shared Function GetValidationColumn(ByVal columnName As String) As String

        Return String.Format("valid_{0}", columnName)

    End Function

    Enum TimeParseErrorCode

        OK
        SeperatorInWrongPlace
        UnrecognizedFormat
        ValueTooLarge
        ValueNegative

    End Enum

    Private Structure TimeResult

        Public parsed As Integer
        Public errorCode As TimeParseErrorCode

        Public Function FormatMITime() As String

            Dim hours As Integer = parsed \ 100
            Dim minutes As Integer = parsed Mod 100

            Return String.Format("{0:00}:{1:00}:00.000", hours, minutes)

        End Function

    End Structure

    Private Shared Function UnifyTimeFormat(ByVal timeText As String) As TimeResult

        Dim result As TimeResult
        result.parsed = -1
        result.errorCode = TimeParseErrorCode.OK

        If timeText.Length <= 4 Then

            ' This is the most straight forward case, 
            ' If it is exactly 4 characters long, 
            ' all characters must be digits
            ' Also if its less then four characters, it must 
            ' represent a number in the range [0 .. 2359]
            If timeText.All(AddressOf Char.IsDigit) Then
                result.parsed = Integer.Parse(timeText)
                result.errorCode = TimeParseErrorCode.OK
            Else
                result = ParseTimeWithRegex(timeText)
            End If

        ElseIf timeText.Length <= 8 Then
            result = ParseTimeWithRegex(timeText)

        Else

            ' text might contain a double value
            Dim dblTime As Double = 0
            If Double.TryParse(timeText, dblTime) Then

                If dblTime >= 0 And dblTime < 1 Then
                    result.parsed = Convert.ToInt32(Math.Round(2359 * dblTime))
                Else
                    result.errorCode = TimeParseErrorCode.ValueTooLarge
                End If

            Else
                result.errorCode = TimeParseErrorCode.UnrecognizedFormat
            End If

        End If

        ' Finally, check if the range is correct
        If result.errorCode = TimeParseErrorCode.OK Then

            If result.parsed > 2359 Then
                result.errorCode = TimeParseErrorCode.ValueTooLarge

            ElseIf result.parsed < 0 Then

                result.errorCode = TimeParseErrorCode.ValueNegative

            End If

        End If

        Return result

    End Function

    Private Shared Function ParseTimeWithRegex(ByVal timeText As String) As TimeResult

        Dim result As TimeResult
        result.parsed = -1
        result.errorCode = TimeParseErrorCode.OK

        Dim timeRegex As New Regex("^(?<Hour>\d{1,2}):(?<Minute>\d{1,2})", _
                                   RegexOptions.IgnorePatternWhitespace _
                                   Or RegexOptions.CultureInvariant _
                                   Or RegexOptions.Compiled)

        Dim theMatch = timeRegex.Match(timeText)
        If theMatch.Success AndAlso theMatch.Groups.Count = 2 Then

            If theMatch.Groups("Hour").Captures.Count > 0 _
                AndAlso theMatch.Groups("Minute").Captures.Count > 0 Then

                ' Keep it simple, only try the first capture.
                Dim hourCapture = theMatch.Groups("Hour").Captures(0).Value
                Dim minuteCapture = theMatch.Groups("Minute").Captures(0).Value
                Dim hourInt As Integer = 0
                Dim minuteInt As Integer = 0

                If Not Integer.TryParse(hourCapture, hourInt) Then
                    result.errorCode = TimeParseErrorCode.UnrecognizedFormat

                ElseIf Not Integer.TryParse(minuteCapture, minuteInt) Then
                    result.errorCode = TimeParseErrorCode.UnrecognizedFormat

                Else

                    result.parsed = hourInt * 100 + minuteInt
                    result.errorCode = TimeParseErrorCode.OK

                End If

            End If

        Else
            result.errorCode = TimeParseErrorCode.UnrecognizedFormat
        End If

        Return result

    End Function

    Private Shared Sub GeocodeWithAddressPoints(ByVal geocSettings As PGISGeocodingSettings, _
                                         ByVal street As String, _
                                         ByVal number As String, _
                                         ByVal municipality As String, _
                                         ByRef gcResult As GeocodingResult)

        If geocSettings Is Nothing Then
            Throw ExceptionProvider.NullArgException("geocSettings")
        End If

        If gcResult Is Nothing Then
            Throw ExceptionProvider.NullArgException("gcResult")
        End If

        Dim tempAdressPointTable As String = "TempAddresPt"
        Dim addresPointsTable As String = MITableProxy.TabFileToTableName(geocSettings.TabFileAddressPoints)

        ' using statement makes sure we don't leave the temp table open.
        ' prevent any lookup if the address is empty anyway

        If (street Is Nothing _
            OrElse number Is Nothing _
            OrElse municipality Is Nothing) Then

            gcResult.PointFound = False

        ElseIf street.Trim = "" _
            OrElse number.Trim = "" _
            OrElse municipality.Trim = "" Then

            gcResult.PointFound = False

        Else

            Dim normalizedStreet = NormalizeAddressPart(street)
            Dim normalizedMunicipality = NormalizeAddressPart(municipality)
            Dim normalizedNumber = NormalizeAddressPart(number) ' vb 10a

            gcResult.Address = normalizedStreet & " " & normalizedNumber
            Dim query As String = String.Format("SELECT * FROM {0}" & _
                                  " WHERE" & _
                                  " LTrim$(RTrim$(UCase$({1}))) = ""{2}""" & _
                                  " AND LTrim$(RTrim$(UCase$({3})))  = ""{4}""" & _
                                  " AND LTrim$(RTrim$(UCase$({5}))) = ""{6}""" & _
                                  " INTO {7}", _
                                    addresPointsTable, _
                                    geocSettings.AddressPtsStreetField, _
                                    normalizedStreet, _
                                    geocSettings.AddressPtsNumberField, _
                                    normalizedNumber, _
                                    geocSettings.AddressPtsMunicipalityField, _
                                    normalizedMunicipality, _
                                    tempAdressPointTable)
            MapBasicInterop.ExecuteCommand(query)

            Dim numFound = MITableProxy.GetRowCount(tempAdressPointTable)
            If numFound = 1 Then

                ' The points were originally centroids but the have been moved 
                ' to 1 m from the street axis.

                gcResult.PointFound = True
                gcResult.Type = "AP"
                GetCoordinatesFromPoint(addresPointsTable & ".obj", gcResult)
                gcResult.StatusCode = GeocodingStatusCode.ExactAddressPoint

            End If

        End If


    End Sub

    Private Shared Function NormalizeAddressPart(ByVal value As String) As String

        If value Is Nothing Then
            Return ""
        Else
            Return value.Trim.ToUpper()
        End If
    End Function

    Private Shared Sub GeocodeWithMapInfo(ByVal geocSettings As PGISGeocodingSettings, _
                                   ByVal address As String, _
                                   ByVal municipality As String, _
                                   ByRef gcResult As GeocodingResult)


        If geocSettings Is Nothing Then
            Throw ExceptionProvider.NullArgException("geocSettings")
        End If

        If gcResult Is Nothing Then
            Throw ExceptionProvider.NullArgException("gcResult")
        End If

        ' We allow null references and the empty string for the address

        gcResult.Address = NormalizeAddressPart(address)
        gcResult.PointFound = False

        If Not address Is Nothing AndAlso address.Trim <> "" Then

            Dim geocodingStreetsTable As String = MITableProxy.OpenTable(geocSettings.TabFileStreetGeocoding, False)
            Dim adminBordersTable As String = MITableProxy.OpenTable(geocSettings.TabFileAdminBorders, False)

            ' Update settings for MapInfo geocoding
            Dim cmdSettingsGeocode As New StringBuilder
            cmdSettingsGeocode.Append("Find Using ")
            cmdSettingsGeocode.Append(geocodingStreetsTable)
            cmdSettingsGeocode.Append("(")
            cmdSettingsGeocode.Append(geocSettings.GCLayerStreetNameField)
            cmdSettingsGeocode.Append(")")
            cmdSettingsGeocode.Append(" Refine Using ")
            cmdSettingsGeocode.Append(adminBordersTable)
            cmdSettingsGeocode.Append("(")
            cmdSettingsGeocode.Append(geocSettings.AdminBordersNameCol)
            cmdSettingsGeocode.Append(")")
            cmdSettingsGeocode.Append(" Options")
            cmdSettingsGeocode.Append(" Abbrs Off")
            cmdSettingsGeocode.Append(" ClosestAddr On")
            cmdSettingsGeocode.Append(" Offset """)
            cmdSettingsGeocode.Append(PGISGeocodingSettings.MarkerOffset)
            cmdSettingsGeocode.Append(""" Distance Units ""m""")
            MapBasicInterop.ExecuteCommand(cmdSettingsGeocode.ToString)

            MapBasicInterop.ExecuteCommand(String.Format("Find""{0}"", ""{1}""", address, municipality))

            Dim geocResultText As String = MICommandInfo.FIND_RC()
            Dim geocResultCode As Integer = Integer.Parse(geocResultText)

            ' geocResultCode = 0 if result was not found for this address
            If Not geocResultCode <= 0 Then

                If geocResultCode Mod 1000 = 1 Then

                    gcResult.StatusCode = GeocodingStatusCode.ExactMatchWithMapInfo

                ElseIf geocResultCode Mod 1000 > 1 Then

                    gcResult.StatusCode = GeocodingStatusCode.ApproximateMatchWithMapInfo

                End If

                gcResult.XCoord = MICommandInfo.CoordinateX
                gcResult.YCoord = MICommandInfo.CoordinateY
                gcResult.Type = "MI"
                gcResult.PointFound = True

            End If

        End If

    End Sub

    Private Shared Sub GeocodeWithHectoMeter(ByVal geocSettings As PGISGeocodingSettings, _
                                      ByVal routeValue As String, _
                                      ByVal hectometerValue As String, _
                                      ByRef gcResult As GeocodingResult)


        If geocSettings Is Nothing Then
            Throw ExceptionProvider.NullArgException("geocSettings")
        End If

        If gcResult Is Nothing Then
            Throw ExceptionProvider.NullArgException("gcResult")
        End If

        gcResult.PointFound = False

        ' We allow null references and the empty string for the address
        If Not (routeValue Is Nothing OrElse hectometerValue Is Nothing OrElse routeValue.Trim = "" OrElse hectometerValue.Trim = "") Then

            ' First make sure the numeric format of the hecto meters is always the same
            ' It might eb emtpy too, or contain stuf that is not even a number. 
            ' If so, we skip the hectometer geocoding.
            Dim convertedhectoValue As String = ""

            Dim normalizedRoute = NormalizeAddressPart(routeValue)

            ' Only continue if the hectometers contain a valid number.
            If UnifyHectoMeterValue(hectometerValue, convertedhectoValue) Then

                ' address = route + hectometer number 
                gcResult.Address = normalizedRoute & " " & hectometerValue

                ' Temp selection table to store the mathing hectometer poles.
                Dim tempHectoPoleTable As String = "TempHectoPole"

                ' The table to seach for a hectometer pole.
                ' using statement makes sure we don't leave the temp table open.

                Dim hectoMeterTable As String = MITableProxy.TabFileToTableName(geocSettings.TabFileHectoMeterPoles)

                ' The HectoDistanceField must be a text field and 
                ' thus its value must be compared as a string.

                Dim queryBuilder As New StringBuilder
                queryBuilder.Append("SELECT * FROM {0}")
                queryBuilder.Append(" WHERE ")
                If geocSettings.HectoAlternativeNameField.Trim.Length > 0 Then
                    queryBuilder.Append("(")
                End If
                queryBuilder.Append("( LTrim$(RTrim$(UCase$( {1} ))) = ""{3}"" ) ")
                If geocSettings.HectoAlternativeNameField.Trim.Length > 0 Then
                    queryBuilder.Append(" OR ( LTrim$(RTrim$(UCase$( {2} ))) = ""{3}"" ) ")
                    queryBuilder.Append(")")
                End If
                queryBuilder.Append(" AND LTrim$(RTrim$(UCase$( Str$({4}) ))) = ""{5}""")
                queryBuilder.Append(" INTO {6}")

                Dim query As String = String.Format(queryBuilder.ToString, _
                                            hectoMeterTable, _
                                            geocSettings.HectoRouteField, _
                                            geocSettings.HectoAlternativeNameField, _
                                            normalizedRoute, _
                                            geocSettings.HectoDistanceField, _
                                            convertedhectoValue, _
                                            tempHectoPoleTable)
                MapBasicInterop.ExecuteCommand(query)

                ' If it did not find anything try again using the first character in the route name.
                ' Use the characters before the first space, but only the first 4.
                Dim numPoints As Integer = MITableProxy.GetRowCount(tempHectoPoleTable)
                If numPoints = 0 Then

                    Dim shortRouteName As String = ""
                    Dim routeParts = normalizedRoute.Split(" "c)
                    If routeParts.Count > 1 Then

                        If routeParts(0).Length > 3 Then
                            shortRouteName = routeParts(0).Substring(0, 4)
                        Else
                            shortRouteName = routeParts(0)
                        End If

                        query = String.Format(queryBuilder.ToString, _
                                      hectoMeterTable, _
                                      geocSettings.HectoRouteField, _
                                      geocSettings.HectoAlternativeNameField, _
                                      shortRouteName, _
                                      geocSettings.HectoDistanceField, _
                                      convertedhectoValue, _
                                      tempHectoPoleTable)

                        MapBasicInterop.ExecuteCommand(query)

                        ' Change address only if the second query found a result
                        numPoints = MITableProxy.GetRowCount(tempHectoPoleTable)
                        If numPoints > 0 Then
                            gcResult.Address = shortRouteName & " " & hectometerValue
                        End If

                    End If

                End If

                If numPoints > 0 Then

                    gcResult.PointFound = True
                    gcResult.Type = "HM"
                    MITableProxy.FetchFirstRecord(tempHectoPoleTable)
                    GetCoordinatesFromPoint(hectoMeterTable & ".obj", gcResult)
                    gcResult.StatusCode = GeocodingStatusCode.ExactHectometerPole

                End If

            End If

        End If

    End Sub

    Private Shared Function UnifyHectoMeterValue(ByVal valueHecto As String, _
                                          ByRef converted As String) As Boolean


        Dim decimalSeparator As String = "." ' For hectometer we ONLY use the point "."
        Dim isANumber As Boolean = True

        valueHecto = NormalizeAddressPart(valueHecto)
        converted = ""

        If valueHecto = "" Then

            isANumber = False

        Else

            ' temp: current character in value of hectometer column
            Dim ch As String = ""
            Dim numDecimalPoints As Integer = 0

            ' Loop through string and count the points and comma's
            ' either of them can represent a decimal point but 
            ' there should be only one in the string.
            For i As Integer = 1 To valueHecto.Length

                ch = Mid$(valueHecto, i, 1)
                Dim int As Integer

                If Not Integer.TryParse(ch, int) Then

                    If (ch = ".") Or (ch = ",") Then
                        numDecimalPoints = numDecimalPoints + 1
                        ch = decimalSeparator
                    Else
                        isANumber = False
                    End If

                End If

                converted = converted & ch

            Next

            If numDecimalPoints > 1 Then
                isANumber = False
            End If

        End If

        Return isANumber

    End Function

    Private Shared Sub GetCoordinatesFromPoint(ByVal pointAlias As String, ByRef gcResults As GeocodingResult)

        Dim expressionForX = String.Format("ObjectGeography({0}, {1})", pointAlias, MapBasicConstants.OBJ_GEO_POINTX)
        Dim expressionForY = String.Format("ObjectGeography({0}, {1})", pointAlias, MapBasicConstants.OBJ_GEO_POINTY)
        Dim xFoundAsText As String = MapBasicInterop.Evaluate(expressionForX)
        Dim yFoundAsText As String = MapBasicInterop.Evaluate(expressionForY)
        gcResults.XCoord = Double.Parse(xFoundAsText, MapBasicInterop.GetMapInfoNumFormat)
        gcResults.YCoord = Double.Parse(yFoundAsText, MapBasicInterop.GetMapInfoNumFormat)

    End Sub

    Private Shared Sub CheckStreetLength(ByVal geocSettings As PGISGeocodingSettings, _
                                  ByVal streetLengthTable As String, _
                                  ByVal street As String, _
                                  ByVal municipality As String, _
                                  ByRef gcResults As GeocodingResult)


        ' -1 is a sentinel, meaning max street length doesn't apply.
        If geocSettings.MaxStreetLength > 0 Then

            If gcResults.StatusCode = GeocodingStatusCode.ApproximateMatchWithMapInfo Then

                Dim streetLength As Double = -1
                Dim streetLengthFound As Boolean = False

                streetLength = GetStreetLength(street, _
                                municipality, _
                                streetLengthTable, _
                                geocSettings.GCLayerStreetNameField, _
                                geocSettings.StreetLengthMunicipalityFields, _
                                streetLengthFound)


                If Not (streetLengthFound) Then
                    'Call GimErrorHandler("No street length found for address """ & addressUsed & """.")
                End If

                If streetLength > geocSettings.MaxStreetLength Then

                    gcResults.PointFound = False
                    gcResults.StatusCode = GeocodingStatusCode.LongStreet
                    gcResults.XCoord = 0D
                    gcResults.YCoord = 0D

                End If

            End If

        End If

    End Sub

    '''-------------------------------------------------------------------------------------------------
    ''' Returns the length of the street or -1 if no street was found with the specified name
    ''' If more then one street are found with the specified name, then the program is terminated
    ''' by the error handler.
    '''-------------------------------------------------------------------------------------------------
    Private Shared Function GetStreetLength( _
        ByVal street As String, _
        ByVal municipality As String, _
        ByVal streetLengthTable As String, _
        ByVal streetField As String, _
        ByVal municipalityFields As List(Of String), _
        ByRef streetFound As Boolean _
        ) As Double

        Dim errorMessage As String = ""
        Dim streetlength As Double = (-1.0)

        streetFound = False

        Dim tempStreetLenghTable As String = "TempResultStreetLength"


        Dim streetLengthQuery As String = "SELECT * FROM " & streetLengthTable _
                                            & FormatStreetLengthWhereClause(street, _
                                                                          municipality, _
                                                                          streetField, _
                                                                          municipalityFields) _
                                            & " INTO " & tempStreetLenghTable
        MapBasicInterop.ExecuteCommand(streetLengthQuery)

        ' Check results: should be exactly one result or no results
        Dim numStreets As Integer = MITableProxy.GetRowCount(tempStreetLenghTable)

        If (numStreets > 1) Then

            ' More then one record is a fatal error, the match should be exactly one at this point.
            streetFound = False
            streetlength = (-1.0)
            errorMessage = "GetStreetLength: More then one street found."

            Throw New PoliceGisException(errorMessage)

        End If
        If numStreets = 1 Then

            MITableProxy.FetchFirstRecord(tempStreetLenghTable)

            Dim lengthExpression As String = String.Format("ObjectLen({0}.OBJ, ""m"")", streetLengthTable)

            streetlength = Val(MapBasicInterop.Evaluate(lengthExpression))
            streetFound = True

            MITableProxy.CloseTable(tempStreetLenghTable, False)
        End If

        Return streetlength

    End Function

    Private Shared Sub ShowNotGeocodedRecords(ByVal table As String, ByVal notFoundTable As String)

        Dim command As New StringBuilder
        command.Append(" SELECT * from ")
        command.Append(table)
        command.Append(" WHERE(geocodeStatus = """)
        command.Append(My.Resources.GeocodingStatusMessages.NotFound)
        command.Append(""" Or geocodeStatus = """)
        command.Append(My.Resources.GeocodingStatusMessages.LongStreet)
        command.Append(""") INTO ")
        command.Append(notFoundTable)
        command.Append(Environment.NewLine)
        command.Append("Browse * from ")
        command.Append(notFoundTable)

        MapBasicInterop.ExecuteCommand(command.ToString)

    End Sub

    Private Shared Function FormatStreetLengthWhereClause( _
                                                    ByVal street As String, _
                                                    ByVal municipality As String, _
                                                    ByVal aggrStreetField As String, _
                                                    ByVal streetMunicipalityFields As List(Of String) _
         ) As String


        Dim municipalityExpressionBuilder As New StringBuilder
        municipalityExpressionBuilder.Append(String.Format("""{0}""", MapBasicInterop.EscapeString((municipality))))
        municipalityExpressionBuilder.Append(" = Any( ")

        Dim maxMunicField = streetMunicipalityFields.Count
        For i As Integer = 0 To maxMunicField - 1
            municipalityExpressionBuilder.Append(streetMunicipalityFields(i))
            municipalityExpressionBuilder.Append(", ")
        Next

        municipalityExpressionBuilder.Append(streetMunicipalityFields(maxMunicField - 1))
        municipalityExpressionBuilder.Append(" ) ")


        Dim streetWhereClause = String.Format(" WHERE ( ( LCase$( {0} ) =  ""{1}"" ) " & _
                                " AND ( {2} ) ) ", aggrStreetField, MapBasicInterop.EscapeString(street).ToLower, _
                                municipalityExpressionBuilder.ToString)

        Return streetWhereClause

    End Function

    Private Shared Sub CheckFileParameter(ByVal fileParameter As String, ByVal parameterName As String)

        If String.IsNullOrEmpty(fileParameter) Then
            Throw ExceptionProvider.NullOrEmptyArgException(parameterName)
        End If

        If Not File.Exists(fileParameter) Then
            Throw ExceptionProvider.PathArgNotFoundException(parameterName, fileParameter)
        End If

    End Sub

    Private Shared Function ConvertToValidName(ByVal naam As String) As String

        naam = naam.Trim

        naam = naam.Replace(".", "") 'remove points

        If Not Char.IsLetter(naam(0)) AndAlso naam(0) <> "_" AndAlso naam(0) <> "~" Then
            naam = "_" & naam
        End If

        Dim newColNameBuilder As New StringBuilder

        For i As Integer = 0 To naam.Length - 1

            If Not Char.IsLetterOrDigit(naam(i)) AndAlso naam(i) <> "_" AndAlso naam(i) <> "~" Then
                newColNameBuilder.Append("_")
            Else
                newColNameBuilder.Append(naam(i))
            End If

        Next

        Return newColNameBuilder.ToString
    End Function

    Private Shared Function ContainsTimeColumns(ByVal tableName As String, ByVal columnTypes As ICollection(Of ColumnTypeDescriptor)) As Boolean
        Dim hasTimeColumns As Boolean = False

        For c As Short = 0 To Convert.ToInt16(columnTypes.Count - 1)

            Dim typeSpec = columnTypes(c)
            Dim colname = MIColumnProxy.GetColumnName(tableName, c + 1S)

            If typeSpec.ColumnType = MIColumnType.TimeType Then

                hasTimeColumns = True
                MITableProxy.AddColumn(tableName, GetValidationColumn(colname), "logical", False)

                ' Make sure there is enough room to store the time results
                If typeSpec.ColumnType = MIColumnType.CharType Then
                    If typeSpec.Width < 12 Then

                        Dim alterColumnCmd = String.Format("Alter table {0} ( Modify {1} CHAR(12))", _
                            tableName, colname)
                        MapBasicInterop.ExecuteCommand(alterColumnCmd)

                    End If
                End If

                '   Dim validationCol = New DataColumn(GetValidationColumn(colname), GetType(System.Boolean))
                '   Dim timeConversionCol = New DataColumn(GetTimeConversionColumn(colname), GetType(System.String))

            End If

        Next

        MITableProxy.SaveTable(tableName)
        MITableProxy.PackTable(tableName)

        Return hasTimeColumns

    End Function

    Private Shared Sub AddTimeValidationField(ByVal tableName As String, ByVal columnTypes As ICollection(Of ColumnTypeDescriptor))
        Dim rowIdAlias As String = tableName & ".RowID"

        ' loop through al records
        MITableProxy.FetchFirstRecord(tableName)
        Dim rowId As Integer = 0

        While Not MITableProxy.EndOfTable(tableName)

            rowId = Integer.Parse(MapBasicInterop.Evaluate(rowIdAlias))

            ' loop through all columns
            For c As Integer = 0 To columnTypes.Count - 1

                Dim typeSpec = columnTypes(c)
                Dim validationCol = GetValidationColumn(typeSpec.ColumnName)
                'Dim convertedTimeCol = GetTimeConversionColumn(typeSpec.ColumnName)

                Dim bothOutputFields As New List(Of String)
                bothOutputFields.Add(typeSpec.ColumnName)
                bothOutputFields.Add(validationCol)

                If typeSpec.ColumnType = MIColumnType.TimeType Then

                    ' attention! column indices in MapInfo start counting from 1, not 0.
                    Dim colAlias = MIColumnProxy.FormatLongColumnID(tableName, c + 1)
                    Dim celValue = MapBasicInterop.Evaluate(colAlias)
                    If IsDBNull(celValue) Then

                        MITableProxy.UpdateRecord(tableName, validationCol, False, rowId)

                    ElseIf String.IsNullOrEmpty(Convert.ToString(celValue)) Then

                        MITableProxy.UpdateRecord(tableName, validationCol, False, rowId)

                    Else

                        Dim timeRes As TimeResult
                        Try
                            timeRes = UnifyTimeFormat(celValue)

                        Catch ex As Exception

                            Dim msg = String.Format(My.Resources.ExceptionMessages.TimeConvertError, celValue, rowId, timeRes.errorCode.ToString)
                            Throw New PoliceGisException(msg)

                        End Try

                        If timeRes.errorCode = TimeParseErrorCode.OK Then

                            Dim vals As New List(Of Object)
                            vals.Add(timeRes.FormatMITime)
                            vals.Add(True)
                            MITableProxy.UpdateRecord(tableName, bothOutputFields, vals, rowId)

                        Else

                            MITableProxy.UpdateRecord(tableName, validationCol, False, rowId)

                        End If

                    End If

                End If

            Next ' loop through columns

            MITableProxy.FetchNextRecord(tableName)

        End While 'loop through rows

        ' Save edits before you modidy the table structure
        MITableProxy.SaveTable(tableName)
    End Sub

    Private Shared Function RemoveLetters(ByVal number As String) As String

        Dim newColNameBuilder As New StringBuilder

        For i As Integer = 0 To number.Length - 1

            If Not Char.IsDigit(number(i)) Then
                newColNameBuilder.Append("")
            Else
                newColNameBuilder.Append(number(i))
            End If

        Next

        Return newColNameBuilder.ToString

    End Function
#End Region

End Class
