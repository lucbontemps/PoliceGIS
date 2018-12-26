Imports System.Text
Imports System.Windows.Forms
Imports System.IO

''' <summary>
''' Helper class. Helps to perform common tasks for doing a GIS analysis.
''' </summary>
''' <remarks></remarks>
Public Class AnalysisCommon

    Private Shared sh_defaultColors As List(Of Integer)

    Private Shared ReadOnly Property DefaultColors() As List(Of Integer)

        Get

            If sh_defaultColors Is Nothing Then
                sh_defaultColors = New List(Of Integer)
                sh_defaultColors.Add(RGB(0, 0, 255)) ' bright red
                sh_defaultColors.Add(RGB(0, 255, 0)) ' bright green
                sh_defaultColors.Add(RGB(255, 0, 0)) ' bright blue
                sh_defaultColors.Add(RGB(255, 0, 255)) ' bright magenta
                sh_defaultColors.Add(RGB(255, 255, 0)) ' bright yellow
                sh_defaultColors.Add(RGB(0, 255, 255)) ' bright cyan
                sh_defaultColors.Add(RGB(128, 0, 0)) ' dark red
                sh_defaultColors.Add(RGB(0, 128, 0)) ' dark green
                sh_defaultColors.Add(RGB(0, 0, 128)) ' dark blue
                sh_defaultColors.Add(RGB(128, 0, 128))
                sh_defaultColors.Add(RGB(128, 128, 0))
                sh_defaultColors.Add(RGB(0, 128, 128))
                sh_defaultColors.Add(RGB(255, 128, 128))
                sh_defaultColors.Add(RGB(128, 255, 128))
                sh_defaultColors.Add(RGB(128, 128, 255))
                sh_defaultColors.Add(RGB(255, 128, 255))
                sh_defaultColors.Add(RGB(255, 255, 128))
                sh_defaultColors.Add(RGB(128, 255, 255))
                sh_defaultColors.Add(RGB(128, 64, 64))
                sh_defaultColors.Add(RGB(64, 128, 64))
                sh_defaultColors.Add(RGB(64, 64, 128))
                sh_defaultColors.Add(RGB(128, 64, 128))
                sh_defaultColors.Add(RGB(128, 128, 64))
                sh_defaultColors.Add(RGB(64, 128, 128))
                sh_defaultColors.Add(RGB(255, 192, 192))
                sh_defaultColors.Add(RGB(192, 255, 192))
                sh_defaultColors.Add(RGB(192, 192, 255))
                sh_defaultColors.Add(RGB(255, 192, 255))
                sh_defaultColors.Add(RGB(255, 255, 192))
                sh_defaultColors.Add(RGB(192, 255, 255))
                sh_defaultColors.Add(RGB(128, 96, 96))
                sh_defaultColors.Add(RGB(96, 128, 96))
                sh_defaultColors.Add(RGB(96, 96, 128))
                sh_defaultColors.Add(RGB(128, 96, 128))
                sh_defaultColors.Add(RGB(128, 128, 96))
                sh_defaultColors.Add(RGB(96, 128, 128))
            End If

            Return sh_defaultColors
        End Get
    End Property

    Public Shared Function GetShadeColor(ByVal colorNumber As Integer) As String

        ' Wrap around when all colors have been used
        While colorNumber >= DefaultColors.Count
            colorNumber = colorNumber - DefaultColors.Count
        End While

        Return DefaultColors(colorNumber).ToString

    End Function

    Public Shared Sub LimitIslpToArea(ByVal areaSettings As PGISAreaSpecificSettings)

        Dim bordersObj = areaSettings.AreaBordersTable & ".obj"
        Dim islpObj = areaSettings.islpTable & ".obj"



        MITableProxy.OpenTableChecked(areaSettings.AreaBordersTable, areaSettings.AreaBordersFile)
        MITableProxy.OpenTableChecked(areaSettings.islpTable, areaSettings.islpFile)

        MapBasicInterop.ExecuteCommand(String.Format("Select * From {0},{1} " & _
                                                        "Where {2}  Within {3} " & _
                                                        "into Selection", _
                                                        areaSettings.islpTable, _
                                                        areaSettings.AreaBordersTable, _
                                                        islpObj, _
                                                        bordersObj))

        Dim selectedRows = MISelectionProxy.NumberOfRows()

        If selectedRows < 1 Then

            Throw New PoliceGisException(String.Format(My.Resources.ExceptionMessages.NoRecordsFound, My.Resources.SelectedZone))

        Else

            MITableProxy.IfTableOpenCloseTable(areaSettings.AreaIslpTable)

            ' Save to ISLP data for the selected area.
            MITableProxy.SaveTableAs("Selection", areaSettings.AreaIslpFile, False)
            MITableProxy.IfTableOpenCloseTable(MITableProxy.GetTableName(0)) ' close temp table
            MITableProxy.OpenTableChecked(areaSettings.AreaIslpTable, areaSettings.AreaIslpFile)


        End If

    End Sub

    Public Shared Sub OpenWorkspace(ByVal workspace As String, _
                             ByRef mapWindowHandle As Integer, _
                             ByRef legendWindowHandle As Integer, _
                             ByVal closeAll As Boolean)

        If closeAll Then
            MapBasicInterop.ExecuteCommand("Close all")
        End If

        MapBasicInterop.ExecuteCommand(String.Format("Run Application ""{0}""", workspace))

        ' Find window handle of mapper en legend widow in the workspace
        MIWindowProxy.FindTopMapWindows(workspace, mapWindowHandle, legendWindowHandle)

        ' Place the legend and map window next to each other in a nicer layout.
        MIWindowProxy.LayoutWindows(mapWindowHandle, legendWindowHandle)

    End Sub

    Public Shared Function GetRangeLimits(ByVal min As Double, ByVal max As Double, ByVal ranges As Integer) As List(Of Double)

        Dim list As New List(Of Double)
        Dim range = (max - min) / ranges

        If range > 0 Then
            While min <= max
                list.Add(min)
                min = min + range
            End While
        Else
            list.Add(min)
            list.Add(max)
        End If

        Return list

    End Function

    Public Shared Function GetRangeOfColors(ByVal ranges As Integer) As List(Of Integer)

        Dim list As New List(Of Integer)
        Dim Red = 255

        For index As Integer = 1 To ranges
            list.Add(RGB(0, 0, Red))
            Red = CInt(Red - (255 / (ranges + 2)))
        Next

        Return list

    End Function

    Public Shared Sub ShadeMapWithGraduatedValues(ByVal mapWindowHandle As Integer, _
                                                ByVal thematicFieldName As String, _
                                                ByVal tableName As String, _
                                                ByVal color As Integer)
        If MITableProxy.GetRowCount(tableName) > 0 Then

            ' MIMapProxy.AddLayer(tableName, False)

            Dim shadeCommand As New StringBuilder

            MapBasicInterop.ExecuteCommand(String.Format("Select Max({0}) From {1}", thematicFieldName, tableName))

            Dim maxVal = Double.Parse(MapBasicInterop.Evaluate("Selection.COL1"))
            MITableProxy.CloseTable(MITableProxy.GetTableName(0), False) 'remove temp table

            If MILayerProxy.GetLayerID(mapWindowHandle, tableName) = 0 Then
                MIMapProxy.AddLayer(tableName, True)
            End If


            shadeCommand.Append(String.Format("Shade Window {0} {1} with {2} ", _
                                              mapWindowHandle, tableName, thematicFieldName))
            shadeCommand.Append(String.Format("graduated 0.0:0 {0}:56 ", _
                                              maxVal.ToString))
            shadeCommand.Append(String.Format("Symbol (34,{0},56) vary size by ""SQRT"" ", _
                                              color))
            MapBasicInterop.ExecuteCommand(shadeCommand.ToString)
        Else

            Throw New PoliceGisException(String.Format(My.Resources.ExceptionMessages.NoRecordsFound, tableName))

        End If

    End Sub

    Public Shared Sub SetLegend(ByVal legendTitle As String, _
                             ByVal layer As String, _
                             ByVal showShades As Boolean, _
                             ByVal showSymbols As Boolean, _
                             ByVal showLines As Boolean, _
                             ByVal showCount As Boolean, _
                             ByVal values As List(Of String), _
                             ByVal mapWindowHandle As Integer, _
                             ByVal order As String)

        Dim setLegendCommand As New StringBuilder
        setLegendCommand.Append(String.Format("Set Legend Window {0} Layer {1} Display on ", _
                                           mapWindowHandle, _
                                           layer))
        If showShades Then
            setLegendCommand.Append(" Shades on ")
        Else
            setLegendCommand.Append(" Shades off ")
        End If

        If showSymbols Then
            setLegendCommand.Append(" Symbols on ")
        Else
            setLegendCommand.Append(" Symbols off ")
        End If

        If showLines Then
            setLegendCommand.Append(" Lines on ")
        Else
            setLegendCommand.Append(" Lines off ")
        End If

        If showCount Then
            setLegendCommand.Append(" Count on ")
        Else
            setLegendCommand.Append(" Count off ")
        End If

        setLegendCommand.Append(String.Format( _
                                " Title ""{0}"" Font (""Arial"",0,9,0) " & _
                                "Subtitle auto Font (""Arial"",0,8,0) {1} ", _
                                legendTitle.Trim, _
                                order))

        If values.Count > 0 Then

            setLegendCommand.Append("Ranges Font (""Arial"",0,8,0) auto display off, ")

            For v As Integer = 0 To values.Count - 1

                ' The range title must be set explicitly because the (generic) column name is 
                ' not informative: "ColumnValues<some number>"
                Dim escapedValue As String = values(v).Replace("""", "'")

                If v <> values.Count - 1 Then
                    ' with comma at the end
                    setLegendCommand.Append(String.Format("""{0}"" Display on, ", escapedValue))

                Else
                    ' without comma at the end
                    setLegendCommand.Append(String.Format("""{0}"" Display on ", escapedValue))

                End If
            Next
        End If

        MapBasicInterop.ExecuteCommand(setLegendCommand.ToString)

    End Sub


    Public Shared Sub CreatePieChartData(ByVal areaspecificSettings As PGISAreaSpecificSettings, _
                                  ByVal thematicFieldName As String, _
                                  ByVal uniqueColumnValuesForTheme As List(Of String))


        ' 	- For each thematic field value a table is saved to workFolder
        '	  which contains only rows where the column has that one value
        CreateThematicTables(areaspecificSettings.islpTable, _
                             thematicFieldName, _
                             uniqueColumnValuesForTheme)

        For i As Integer = 0 To uniqueColumnValuesForTheme.Count - 1

            Dim valuesTable As String = String.Format("tempTable{0}", i)
            Dim addedColName As String = ("CountOfColumnValues" & i)

            MITableProxy.AddColumn(areaspecificSettings.PieTable, addedColName, "Integer", True)

            MapBasicInterop.ExecuteCommand(String.Format("Add Column {0}({1}) " & _
                                             "From {2} Set To Count(*) Where within", _
                                             areaspecificSettings.PieTable, _
                                             addedColName, valuesTable))

            MITableProxy.SaveTable(areaspecificSettings.PieTable)
            MITableProxy.SaveTable(valuesTable)
            MITableProxy.CloseTable(valuesTable, True)

        Next

    End Sub

    '---------------------------------------------------------------------------------------------------
    '	Creates some tabels that contain all the rows 
    ' 	for which the column value of thematicFieldName 
    ' 	have one and the same value
    '---------------------------------------------------------------------------------------------------

    Public Shared Sub CreateThematicTables(ByVal islpTable As String, _
                                    ByVal thematicFieldName As String, _
                                    ByVal uniqueColumnValuesForTheme As List(Of String))

        ' Result is stored in new column which is saved in workspace as this select statement.
        Dim sqlStatement As String
        Dim quotesValues As Boolean = MIColumnProxy.ColumnNeedsQuotes(islpTable, thematicFieldName)

        For i As Integer = 0 To uniqueColumnValuesForTheme.Count - 1

            Dim tempTable = String.Format("tempTable{0}", i)
            Dim columnName = replaceQuotes(uniqueColumnValuesForTheme(i), quotesValues)

            sqlStatement = String.Format("Select * From {0}  " & _
                                         "Where {1} = {2}  " & _
                                         "Into ""{3}"" NOSELECT", _
                                         islpTable, _
                                         thematicFieldName, _
                                         columnName, _
                                         tempTable)

            MapBasicInterop.ExecuteCommand(sqlStatement)

        Next

    End Sub

    Private Shared Function replaceQuotes(ByVal value As String, _
                                      ByVal needsQuotes As Boolean) As String

        value = value.Replace("""", "'")

        If needsQuotes Then
            value = String.Format("""{0}""", value)
        End If

        Return value

    End Function

    Public Shared Sub ShadeMapWithPies(ByVal mapWindowHandle As Integer, _
                                ByVal tableName As String, _
                                ByVal numberOfValues As Integer)


        MIMapProxy.AddLayer(tableName, False)

        Dim shadeCommand As New StringBuilder

        ' counter for loop over unique values array
        Dim uVal As Integer

        'value to be used for the volume of the pies
        Dim maxValue As Integer

        If numberOfValues < 1 Or numberOfValues > 30 Then

            Throw ExceptionProvider.ArgumentOutOfRange("numberOfValues", _
                                                       numberOfValues, _
                                                       "Value of argument 'numberOfValues' must >=1 and <= 30. There must be at least one value and no for the Pie chart and no more then 30.")
        End If

        shadeCommand.Append(String.Format("Shade Window {0} {1} with ", _
                                          mapWindowHandle, tableName))

        For uVal = 0 To numberOfValues - 1

            Dim columnWithValues As String = String.Format("CountOfColumnValues{0}", uVal)

            MISelectionProxy.SelectMax(columnWithValues, tableName)

            If Double.Parse(MapBasicInterop.Evaluate("Selection.COL1")) > maxValue Then
                maxValue = Integer.Parse(MapBasicInterop.Evaluate("Selection.COL1"))
            End If

            MITableProxy.CloseTable(MITableProxy.GetTableName(0), False) 'close temp table

            If uVal <> numberOfValues - 1 Then

                shadeCommand.Append(columnWithValues & ", ")

            Else
                ' add the last columns + the settings for the pie chart
                shadeCommand.Append(String.Format(MapBasicInterop.GetMapInfoNumFormat, "{0}" & _
                     " Pie Angle 180 Max Size 0.5 Units ""cm""" & _
                     " At Value {1} Vary Size By ""SQRT"" Border Pen (1,2,0) Position Center Center" & _
                     " Style ", columnWithValues, Math.Round(maxValue / 7)))

            End If

        Next

        ' Add the brushes for the pie chart. One for each value.
        For uVal = 0 To numberOfValues - 1

            Dim colorDescription As String = GetShadeColor(uVal)
            shadeCommand.AppendFormat(MapBasicInterop.GetMapInfoNumFormat, " Brush (2, {0}, {1}) ", _
                                      colorDescription, MapBasicConstants.WHITE)
            If uVal = (numberOfValues - 1) Then
                shadeCommand.Append(",")
            End If

        Next

        MapBasicInterop.ExecuteCommand(shadeCommand.ToString)

    End Sub

    Public Shared Sub ShadeMapRegionsByRange(ByVal mapWindowHandle As Integer, _
                                      ByVal thematicFieldName As String, _
                                      ByVal tableName As String, _
                                      ByVal numberDesiredClasses As Integer)


        ' Extended routine name for logging and error handling"
        Dim commandBuilder = New StringBuilder()

        Dim rangeLimits As New List(Of Double)
        Dim rangeOfColors As New List(Of Integer)
        Dim numRecords = MITableProxy.GetRowCount(tableName)
        ' Dim a_themColumn As String = MIColumnProxy.FormatLongColumnID(tableName, thematicFieldName)

        If numRecords < 1 Then

            ' Table has 0 rows. Shade statement would have no effect.
            ' Use one fake interval: add one upper and one lower limit, both zero.

            rangeLimits.Add(0.0)
            rangeLimits.Add(0.0)

        Else

            ' When there are less records then the desired number of classes, 
            ' it has no use creating more classes then records. There would  
            ' be empty classes.
            If numRecords <= numberDesiredClasses Then
                numberDesiredClasses = numRecords
            End If

            commandBuilder.Append(String.Format("Select Min({0}), Max({0}) From {1}", thematicFieldName, tableName))
            MapBasicInterop.ExecuteCommand(commandBuilder.ToString)
            Dim queryTable = MITableProxy.GetTableName(0)

            Dim minimumRange = Double.Parse(MapBasicInterop.Evaluate("Selection.COL1"))
            Dim maximumRange = Double.Parse(MapBasicInterop.Evaluate("Selection.COL2"))

            ' close temp tables as soon as possible
            MITableProxy.CloseTable(MITableProxy.GetTableName(0), False)
            MITableProxy.CloseTable(queryTable, False)

            rangeLimits = GetRangeLimits(minimumRange, maximumRange, numberDesiredClasses)
            rangeOfColors = GetRangeOfColors(numberDesiredClasses)

        End If

        Dim shadeCommand As New StringBuilder ' Shade command to add a thematic layer to the map.

        MIMapProxy.AddLayer(tableName, False)

        ' not via a layer number. This has to work for any client's configuration. 
        shadeCommand.Append(String.Format("Shade Window {0} {1} " & _
                                          "with {2} ignore 0 " & _
                                          "Ranges Apply All Use All Brush (2,{3}, {3}) ", _
                                          mapWindowHandle, _
                                          tableName, _
                                          thematicFieldName, _
                                          Str$(MapBasicConstants.WHITE)))


        For stl As Integer = 1 To numberDesiredClasses

            ' Sets a line style with some parameters, with a Line clause. 

            Dim pattern = 2
            Dim foreColor = rangeOfColors(stl - 1).ToString
            Dim backColor = 0
            Dim rangeStart = rangeLimits(stl - 1)

            ' Dim rangeEnd = rangeLimits(stl)

            ' Get line width and color from a range that you build in .NET.
            shadeCommand.Append(String.Format(MapBasicInterop.GetMapInfoNumFormat, _
                                " {0}:{1} Brush({2},{3},{4})", _
                                rangeStart, _
                                rangeLimits(stl), _
                                pattern, _
                                foreColor, _
                                backColor))

            If stl < numberDesiredClasses Then
                shadeCommand.Append(", ")
            End If

        Next

        shadeCommand.Append(" default Style replace off")

        MapBasicInterop.ExecuteCommand(shadeCommand.ToString)

    End Sub

    Public Shared Function GetInteresseGebieden(ByVal PolitieZone As String) As List(Of InteresseGebied)

        Dim list As New List(Of InteresseGebied)

        Dim tableFile As New FileInfo(String.Format("{0}\{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location), "interessegebieden_CZ.TAB"))
        Dim table = MITableProxy.OpenTable(tableFile, False)
        MITableProxy.FetchFirstRecord(table)

        For rw As Integer = 0 To MITableProxy.GetRowCount(table) - 1

            Dim gebied As New InteresseGebied

            With gebied

                .PolitieZone = MapBasicInterop.Evaluate(String.Format("{0}.COL{1}", table, MIColumnProxy.GetColumnID(table, "NamePZ")))
                .Naam = MapBasicInterop.Evaluate(String.Format("{0}.COL{1}", table, MIColumnProxy.GetColumnID(table, "NaamKORT")))
                .NaamSpatie = MapBasicInterop.Evaluate(String.Format("{0}.COL{1}", table, MIColumnProxy.GetColumnID(table, "NaamSPATIE")))
                .NaamStreep = MapBasicInterop.Evaluate(String.Format("{0}.COL{1}", table, MIColumnProxy.GetColumnID(table, "NaamSTREEP")))
                .Level = Short.Parse(MapBasicInterop.Evaluate(String.Format("{0}.COL{1}", table, MIColumnProxy.GetColumnID(table, "LevelINT"))))
                .NaamParent = MapBasicInterop.Evaluate(String.Format("{0}.COL{1}", table, MIColumnProxy.GetColumnID(table, "ParentID")))

            End With

            list.Add(gebied)
            MITableProxy.FetchNextRecord(table)
        Next
        Dim tempList As New List(Of InteresseGebied)
        tempList = list.Where(Function(ig) ig.NaamParent = PolitieZone).ToList
        Dim FinalList As New List(Of InteresseGebied)
        FinalList.AddRange(tempList)
        For Each item In tempList
            If item.Level = 2 Then
                Dim pz = item
                FinalList.AddRange(list.Where(Function(ig) ig.NaamParent = pz.Naam).ToList)
            End If
        Next
        Return FinalList.OrderBy(Function(ig) ig.Level).ToList

    End Function

    Public Shared Function CreateNewNaam(ByVal werkfolder As String, ByVal isCrime As Boolean, ByVal gebied As String, ByVal analyse As String) As String

        Dim naam As String
        Dim soort As String
        If isCrime Then
            soort = "C"
        Else
            soort = "V"
        End If
        naam = String.Format("{0}_{1}_{2}", soort, gebied, analyse)
        Dim teller = 1

        While File.Exists(String.Format("{0}{1}_{2}.TAB", werkfolder, naam, teller))
            teller = teller + 1
        End While

        Return String.Format("{0}_{1}", naam, teller)

    End Function


End Class
