Option Strict On

Imports System.IO
Imports System.Text
Imports System.Windows.Forms

''' <summary>
''' This class controls the work flow for a crime series analysis.
''' </summary>
''' <remarks></remarks>
Public Class CrimeSeriesController

    Public Const PRECISION_DAYS As Integer = 1
    Public Const PRECISION_HOURS As Integer = 2
    Public Const PRECISION_MINUTES As Integer = 3
    Public Const PRECISION_SECS As Integer = 4


    Private m_legendWindowHandle As Integer
    Private m_mapWindowHandle As Integer

    Private m_areaSpecificSettings As PGISAreaSpecificSettings


    Public Sub GenerateCrimeAnalysis(ByVal areaSpecificSettings As PGISAreaSpecificSettings, _
                              ByVal crimeserieFields As CrimeSerieFields, ByVal isCrime As Boolean)


        Dim crimeSeriesTable As String = AnalysisCommon.CreateNewNaam(areaSpecificSettings.WerkFolder, isCrime, areaSpecificSettings.Area, "SI")
        Dim crimeSeriesFile = String.Format("{0}{1}.TAB", areaSpecificSettings.WerkFolder, crimeSeriesTable)
        Dim incidentIDField = "CrimeID"
        Dim distanceTable = "DistancesTable"
        Dim candidateCouples = AnalysisCommon.CreateNewNaam(areaSpecificSettings.WerkFolder, isCrime, areaSpecificSettings.Area, "SC")
        ' Dim candidateCouplesFile = String.Format("{0}{1}.TAB", areaSpecificSettings.WerkFolder, candidateCouples)
        Dim SeriesTable = "Series_Table"
        Dim SeriesFile = String.Format("{0}{1}.TAB", areaSpecificSettings.WerkFolder, SeriesTable)

        m_areaSpecificSettings = areaSpecificSettings

        AnalysisCommon.OpenWorkspace(m_areaSpecificSettings.StartupWorkspace, m_mapWindowHandle, m_legendWindowHandle, False)
        AnalysisCommon.LimitIslpToArea(areaSpecificSettings)

        'te testen ########################################################################################

        MITableProxy.SaveTableAs(m_areaSpecificSettings.AreaIslpTable, crimeSeriesFile, False)
        MITableProxy.OpenTableAs(crimeSeriesFile, False, crimeSeriesTable)


        Dim crimes = GetCrimes(crimeSeriesTable, crimeserieFields)

        MITableProxy.PackTable(crimeSeriesTable)

        MITableProxy.AddColumn(crimeSeriesTable, incidentIDField, "Integer", False)
        MITableProxy.AddColumn(crimeSeriesTable, My.Settings.StartDateField, "DateTime", False)
        MITableProxy.AddColumn(crimeSeriesTable, My.Settings.EndDateField, "DateTime", False)


        CreateNewCrimeTable(crimes, crimeSeriesTable)

        crimes = crimes.Where(Function(crime) crime.Interval <= crimeserieFields.MaxTimeSpanHours _
                               And crime.Interval >= 0).ToList


        DeleteCrimes(crimeSeriesTable, crimes)

        '#########################################################################################

        'Dim crimes = GetCrimes(m_areaSpecificSettings.AreaIslpTable, crimeserieFields)

        'crimes = crimes.Where(Function(crime) crime.Interval <= crimeserieFields.MaxTimeSpanHours _
        '                               And crime.Interval >= 0).ToList




        'CreateCrimeTable(crimes, crimeSeriesTable, crimeSeriesFile)

        ' Create table with distances between pairs of points.
        CreateDistanceTable(crimeSeriesTable, _
                                 distanceTable, _
                                 m_areaSpecificSettings.WerkFolder, _
                                 crimeserieFields.MaxDistance, _
                                 incidentIDField)

        ' Add the intervals, the overlap or gap, and the overlap length / gap length to the table
        CalculateTimeIntervals(distanceTable)

        SelectCandidatesForSeries(m_areaSpecificSettings.WerkFolder, _
                                     distanceTable, _
                                     candidateCouples, _
                                     crimeserieFields.MaxGapHours * 60)

        MergeCandidatesIntoSeries(candidateCouples, _
                                      SeriesTable, _
                                      SeriesFile, _
                                      incidentIDField)

        ' Add the SeriesID to table with results
        MITableProxy.AddColumn(crimeSeriesTable, "SeriesID", "Integer", False)

        MapBasicInterop.ExecuteCommand(String.Format("Add Column {0} (SeriesID)  From {1} Set To SerID Where {2} = {2}", _
                                                        crimeSeriesTable, _
                                                        SeriesTable, _
                                                        incidentIDField))
        MITableProxy.SaveTable(crimeSeriesTable)

        ShowResultsOnMap(crimeSeriesTable, SeriesTable, candidateCouples)

        MIWindowProxy.Rename(m_mapWindowHandle, String.Format("{0} - {1} {2}", areaSpecificSettings.TypeAnalyse, "Series", areaSpecificSettings.AreaNaamSpatie))

    End Sub

    'Private Sub CreateCrimeTable(ByVal crimes As List(Of Crime), _
    '                             ByVal tableName As String, ByVal tableFile As String)
    '    Dim crime As New Crime
    '    MITableProxy.IfTableOpenCloseTable(tableName)

    '    MapBasicInterop.ExecuteCommand(String.Format("Create Table {0} (CrimeID Integer,{1} DateTime,{2} DateTime) file ""{3}""", _
    '                                                   tableName, _
    '                                                   My.Settings.StartDateField, _
    '                                                   My.Settings.EndDateField, tableFile))

    '    MITableProxy.MakeMappable(tableName, CoreLibConstants.CS_LAMBERT_1972)

    '    For Each crime In crimes

    '        MITableProxy.FetchRecord(m_areaSpecificSettings.AreaIslpTable, crime.RowID)

    '        Dim expressionForX = String.Format("ObjectGeography({0}, {1})", m_areaSpecificSettings.AreaIslpTable & ".obj", MapBasicConstants.OBJ_GEO_POINTX)
    '        Dim expressionForY = String.Format("ObjectGeography({0}, {1})", m_areaSpecificSettings.AreaIslpTable & ".obj", MapBasicConstants.OBJ_GEO_POINTY)
    '        Dim xFoundAsText As String = MapBasicInterop.Evaluate(expressionForX)
    '        Dim yFoundAsText As String = MapBasicInterop.Evaluate(expressionForY)

    '        MapBasicInterop.ExecuteCommand(String.Format("insert into {0} (CrimeID,{1},{2},obj) values ({3},{4},{5},CreatePoint({6}, {7}))", _
    '                                                       tableName, _
    '                                                        My.Settings.StartDateField, _
    '                                                        My.Settings.EndDateField, _
    '                                                       crime.RowID, _
    '                                                       crime.StartDateTime.ToString("yyyyMMddHHmmss000"), _
    '                                                       crime.EndDateTime.ToString("yyyyMMddHHmmss000"), _
    '                                                       xFoundAsText, _
    '                                                       yFoundAsText))

    '    Next
    '    MITableProxy.SaveTable(tableName)
    'End Sub

    Private Shared Sub CreateDistanceTable(ByVal crimesTable As String, _
                                     ByVal distanceTable As String, _
                                      ByVal workFolder As String, _
                                      ByVal maxDistance As Double, _
                                      ByVal incidentIDField As String)

        ' Copy to make it easier to use the Mapbasic "Nearest" command.
        Dim copyCrimeTable = "CopyCrimeSeriesTable"
        Dim createTableCmd As New StringBuilder
        Dim NearestCommand As New StringBuilder
        Try
            MapBasicInterop.ExecuteCommand(String.Format(MapBasicInterop.GetMapInfoNumFormat, "Select * From {0} Into {1} NoSelect", _
                                                   crimesTable, _
                                                   copyCrimeTable))

            MITableProxy.SaveAndOpenAsBaseTable(workFolder, copyCrimeTable)

            MITableProxy.IfTableOpenCloseTable(distanceTable)

            createTableCmd.Append(String.Format(MapBasicInterop.GetMapInfoNumFormat, "Create table {0}  (origin {1},destination {2}, distance Float ", _
                                                distanceTable, _
                                                MIColumnProxy.GetColumnTypeDescriptor(crimesTable, incidentIDField).TypeString(), _
                                                MIColumnProxy.GetColumnTypeDescriptor(copyCrimeTable, incidentIDField).TypeString()))

            ' Add datacolumns for the first table.
            createTableCmd.Append(String.Format(", {0}_1 DateTime", My.Settings.StartDateField))
            createTableCmd.Append(String.Format(", {0}_1 DateTime", My.Settings.EndDateField))

            ' Add datacolumns for the second table.
            createTableCmd.Append(String.Format(", {0}_2 DateTime", My.Settings.StartDateField))
            createTableCmd.Append(String.Format(", {0}_2 DateTime", My.Settings.EndDateField))

            ' Add filelocation
            createTableCmd.Append(String.Format(") File ""{0}\{1}.TAB"" ", workFolder, distanceTable))

            MapBasicInterop.ExecuteCommand(createTableCmd.ToString)

            ' Make the distance table mappable, using the Belgian national coordinate system.
            MITableProxy.MakeMappable(distanceTable, CoreLibConstants.CS_LAMBERT_1972)

            ' Find all points for which 0 < distance <= f_maxDistance meters
            ' Copy some fields in the process.
            NearestCommand.Append(String.Format("Nearest ALL From Table {0}" & _
                                         " To {1} " & _
                                         "Into {2} " & _
                                         "Type Spherical Ignore Min 0 Max {3} Units ""m"" " & _
                                         "Data origin = {0}.{4}, " & _
                                         "destination = {1}.{4} " _
                                         , crimesTable, _
                                         copyCrimeTable, _
                                         distanceTable, _
                                         maxDistance, _
                                        incidentIDField))

            NearestCommand.Append(String.Format(",{0}_1= {1}.{0}, " & _
                                           "{0}_2= {2}.{0}", _
                                           My.Settings.StartDateField, _
                                           crimesTable, copyCrimeTable))

            NearestCommand.Append(String.Format(",{0}_1= {1}.{0}, " & _
                                           "{0}_2= {2}.{0}", _
                                           My.Settings.EndDateField, _
                                           crimesTable, copyCrimeTable))

            MapBasicInterop.ExecuteCommand(NearestCommand.ToString)

            'Set distances
            MapBasicInterop.ExecuteCommand(String.Format("Update {0} Set distance = ObjectLen(obj, ""m"")", distanceTable))

            MITableProxy.SaveTable(distanceTable)
        Finally
            MITableProxy.IfTableOpenCloseTable(copyCrimeTable)
        End Try
    




    End Sub

    Private Shared Sub CalculateTimeIntervals(ByVal distanceTable As String)

        MapBasicInterop.ExecuteCommand(String.Format("Alter Table {0} " & _
                      "(Add TimesOverlap Logical, OverlapGapLength Integer)", _
                      distanceTable))

        MITableProxy.SaveTable(distanceTable)

        ' Loop through all distances.
        ' Determine the correct roder from the dates and times.
        ' Then Check the criteria to detect which couples are part of a serie.

        For rw = 1 To MITableProxy.GetRowCount(distanceTable)
            MITableProxy.FetchRecord(distanceTable, rw)

            ' Add a message for the status bar.
            If rw Mod 100 = 0 Then
                'Call MapGenGUI_SetStatusBar(m_msgCalculatingOverlaps & " " & Str$(rw) & "/" & Str$(nRows))
            End If

            Dim endDate1 = MapBasicInterop.Evaluate(distanceTable & "." & My.Settings.EndDateField & "_1").Trim
            Dim startDate1 = MapBasicInterop.Evaluate(distanceTable & "." & My.Settings.StartDateField & "_1").Trim
            Dim endDate2 = MapBasicInterop.Evaluate(distanceTable & "." & My.Settings.EndDateField & "_2").Trim
            Dim startDate2 = MapBasicInterop.Evaluate(distanceTable & "." & My.Settings.StartDateField & "_2").Trim

            ' None of the time parts may be empty. 
            If Not ( _
               (endDate1 = "") Or _
               (startDate1 = "") Or _
               (endDate2 = "") Or _
               (startDate2 = "")) Then

                '---------------------------------------------------
                ' Check overlapping times.
                '--------------------------------------------------a
                Dim overlap As Boolean
                Dim length As Integer
                Dim endDateTime1 = convertToDate(endDate1)
                Dim startDateTime1 = convertToDate(startDate1)
                Dim endDateTime2 = convertToDate(endDate2)
                Dim startDateTime2 = convertToDate(startDate2)


                ' determine the overlap of gap length
                IntervalOverlapOrGap(endDateTime1, startDateTime1, endDateTime2, startDateTime2, overlap, length)

                ' fill in the time and overlap info in the distance table
                MapBasicInterop.ExecuteCommand(String.Format("Update {0} Set " & _
                                                "TimesOverlap = {1}," & _
                                                "OverlapGapLength = {2} " & _
                                                "Where Rowid = {3}", _
                                                distanceTable, _
                                                CInt(overlap), _
                                                length, _
                                                rw))

            End If

        Next
        MITableProxy.SaveTable(distanceTable)
    End Sub

    Private Shared Sub IntervalOverlapOrGap(ByVal endDateTime1 As DateTime, _
                                        ByVal startDateTime1 As DateTime, _
                                        ByVal endDateTime2 As DateTime, _
                                        ByVal startDateTime2 As DateTime, _
                                        ByRef isOverLap As Boolean, _
                                        ByRef length As Integer)


        If startDateTime1 = endDateTime1 Then

            'start1=end1 = crime1
            '     |
            If startDateTime2 = endDateTime2 Then

                isOverLap = False

                If endDateTime1 = endDateTime2 Then

                    ' crime1 =crime 2
                    '   ___|____

                    length = 0

                Else

                    If startDateTime2 > startDateTime1 Then

                        ' crime1   crime2
                        '   |        |

                        length = TimeDifference(endDateTime1, startDateTime2, PRECISION_MINUTES)
                    Else

                        ' crime2   crime1
                        '   |        |

                        length = TimeDifference(endDateTime2, startDateTime1, PRECISION_MINUTES)

                    End If


                End If

            Else

                If endDateTime2 > endDateTime1 And endDateTime1 > startDateTime2 Then

                    '  start2         crime1       end2
                    '   |______________|____________|

                    isOverLap = True
                    length = 0 ' overlap is 0 because it is a point

                Else

                    isOverLap = False

                    If startDateTime1 > startDateTime2 Then

                        '  start2        end2        crime1
                        '  |______________|          |

                        length = TimeDifference(endDateTime2, startDateTime1, PRECISION_MINUTES)

                    Else

                        '    crime1     start2       end2
                        '      |          |___________|

                        length = TimeDifference(endDateTime1, startDateTime2, PRECISION_MINUTES)

                    End If

                End If

            End If

        Else
            ' startDateTime1 < endDateTime1 
            ' start1   end1
            '   |________|

            If endDateTime2 = startDateTime2 Then
                ' crime2
                '   |


                If startDateTime1 <= startDateTime2 And startDateTime2 <= endDateTime1 Then
                    ' start1  crime2       end1
                    ' |________|____________|

                    isOverLap = True
                    length = 0 ' overlap is 0 because it is a point

                Else

                    isOverLap = False

                    If startDateTime2 > endDateTime1 Then

                        ' start1   end1  crime2
                        '   |________|    |

                        length = TimeDifference(endDateTime1, startDateTime2, PRECISION_MINUTES)

                    Else

                        ' crime2  start1   end1  
                        '    |       |________| 

                        length = TimeDifference(endDateTime2, startDateTime1, PRECISION_MINUTES)

                    End If
                End If

            Else

                If startDateTime1 = startDateTime2 Then

                    isOverLap = True

                    If endDateTime1 > endDateTime2 Then

                        ' start1&2   end2   end1
                        ' |_________|______| 
                        length = TimeDifference(startDateTime1, endDateTime2, PRECISION_MINUTES)

                    Else

                        ' start1&2   end1   end2
                        ' |_________|______| 
                        length = TimeDifference(startDateTime1, endDateTime1, PRECISION_MINUTES)

                    End If
                Else

                    If startDateTime1 < startDateTime2 Then

                        ' start1      start2
                        ' |____________|

                        OverlapRegularIntervals(endDateTime1, startDateTime1, endDateTime2, startDateTime2, isOverLap, length)

                    Else
                        ' start2      start1
                        ' |____________|

                        OverlapRegularIntervals(endDateTime2, startDateTime2, endDateTime1, startDateTime1, isOverLap, length)

                    End If
                End If
            End If
        End If


    End Sub

    Private Shared Function TimeDifference(ByVal fromTime As DateTime, _
                            ByVal toTime As DateTime, _
                            ByVal precision As Short) As Integer

        Dim result As Integer
        Dim daysDiff As Integer
        Dim hoursDiff As Integer
        Dim minutesDiff As Integer
        Dim secondsDiff As Integer

        result = 0

        '  from      to     => diff is positive
        '___|________|____
        '
        '   to      from   => diff is negative
        '___|________|____

        daysDiff = toTime.Subtract(fromTime).Days
        hoursDiff = toTime.Subtract(fromTime).Hours
        minutesDiff = toTime.Subtract(fromTime).Minutes
        secondsDiff = toTime.Subtract(fromTime).Seconds

        ' --- sums ---
        '24 hours in a day + the remaining hours withing the same day
        hoursDiff = hoursDiff + (24 * daysDiff)

        '60 minutes in one hour + remaining minutes
        minutesDiff = minutesDiff + (60 * hoursDiff)

        '60 seconds in one minute + remaining seconds
        secondsDiff = secondsDiff + (60 * minutesDiff)

        Select Case precision

            Case PRECISION_DAYS
                result = daysDiff

            Case PRECISION_HOURS
                result = hoursDiff

            Case PRECISION_MINUTES
                result = minutesDiff

            Case PRECISION_SECS
                result = secondsDiff

            Case Else
                Throw New PoliceGisException("TimeDifference: illegal value for argument 'precision'. Value is  '" & Str$(precision) & "'.")
        End Select

        Return result

    End Function

    ''' <summary>
    ''' determines the length overlap or the length of the gap between to intervals
    ''' </summary>
    ''' 

    Private Shared Sub OverlapRegularIntervals(ByVal endDateTime1 As DateTime, _
                                        ByVal startDateTime1 As DateTime, _
                                        ByVal endDateTime2 As DateTime, _
                                        ByVal startDateTime2 As DateTime, _
                                        ByRef isOverLap As Boolean, _
                                        ByRef length As Integer)

        ' enforce the preconditions of the function by throwing an error if they are  not met:

        If startDateTime1 > endDateTime1 Then

            Dim errorMessage As New StringBuilder
            With errorMessage
                .Append("Illegal arguments: start date na end date")
                .AppendLine()
                .Append(String.Format("{0}>{1}", startDateTime1.ToString, endDateTime1.ToString))
            End With

            Throw New PoliceGisException(errorMessage.ToString)
        End If

        If startDateTime2 > endDateTime2 Then
            Dim errorMessage As New StringBuilder
            With errorMessage
                .Append("Illegal arguments: start date na end date")
                .AppendLine()
                .Append(String.Format("{0}>{1}", startDateTime2.ToString, endDateTime2.ToString))
            End With

            Throw New PoliceGisException(errorMessage.ToString)
        End If

        If startDateTime1 > startDateTime2 Then

            Dim errorMessage As New StringBuilder
            With errorMessage
                .Append("Illegal arguments: First interval's starts is after second ineterval")
                .AppendLine()
                .Append(String.Format("{0}>{1}", startDateTime1.ToString, startDateTime2.ToString))
            End With

            Throw New PoliceGisException(errorMessage.ToString)

        End If

        If startDateTime2 = endDateTime1 Then

            ' start1       end1=start2   end2 
            ' |____________|______________|

            isOverLap = True
            length = 0

        Else

            If endDateTime1 > startDateTime2 Then
                ' end1                  start2
                ' |________________________|

                isOverLap = True


                If endDateTime1 > endDateTime2 Then
                    '  start1  start2   end2 end1   
                    ' |_______|_________|____|

                    length = TimeDifference(startDateTime2, endDateTime2, PRECISION_MINUTES)

                Else

                    '  start1 start2       end1   end2
                    ' |_______|___________|_______|

                    length = TimeDifference(startDateTime2, endDateTime1, PRECISION_MINUTES)

                End If

            Else

                '  start1          end1     start2  end2
                ' |_________________|       |________|   

                isOverLap = False
                length = TimeDifference(endDateTime1, startDateTime2, PRECISION_MINUTES)

            End If

        End If

    End Sub

    Private Shared Sub SelectCandidatesForSeries(ByVal workFolder As String, _
                                  ByVal distanceTable As String, _
                                  ByVal candidateCouples As String, _
                                  ByVal maxGapMinutes As Integer)


        MapBasicInterop.ExecuteCommand(String.Format("Alter Table {0} (Add IsShortGap logical, " & _
                                                       "PartOfSeries logical, TypeOfSeries Char(50))", _
                                                       distanceTable))

        ' Update column for gap < maximum allowed gap
        MapBasicInterop.ExecuteCommand(String.Format("Update {0} " & _
                                                       "Set IsShortGap = ( (NOT TimesOverlap) " & _
                                                       "AND (OverlapGapLength <= {1} ))", _
                                                       distanceTable, _
                                                       maxGapMinutes.ToString))

        'Set part of series
        MapBasicInterop.ExecuteCommand(String.Format("Update {0} set PartOfSeries = " & _
                                              "( TimesOverlap  OR " & _
                                              "( (NOT TimesOverlap) " & _
                                              "AND IsShortGap ))", _
                                              distanceTable))


        ' Save changes to the distance table
        MITableProxy.SaveTable(distanceTable)

        ' Initialize all records with series type = "None", meanign the point isn't part of any series.
        MapBasicInterop.ExecuteCommand(String.Format("Update {0} set TypeOfSeries = ""None""", distanceTable))

        For countRecDist = 1 To MITableProxy.GetRowCount(distanceTable)

            MITableProxy.FetchRecord(distanceTable, countRecDist)

            '     Dim partofSeries = MapBasicInterop.Evaluate(distanceTable & ".PartOfSeries")
            Dim timesOverlap = MapBasicInterop.Evaluate(distanceTable & ".TimesOverlap")
            Dim IsShortGap = MapBasicInterop.Evaluate(distanceTable & ".IsShortGap")

            ' timesOverlap = True => PartOfSeries should be True
            If timesOverlap = "T" Then
                MapBasicInterop.ExecuteCommand(String.Format("Update {0} " & _
                                                               "set TypeOfSeries = ""overlap"" " & _
                                                               "Where Rowid = {1}", _
                                                               distanceTable, _
                                                               countRecDist))
            Else
                If IsShortGap = "T" Then
                    MapBasicInterop.ExecuteCommand(String.Format("Update {0} " & _
                                                     "set TypeOfSeries = ""short gap"" " & _
                                                     "Where Rowid = {1}", _
                                                     distanceTable, _
                                                     countRecDist))
                End If
            End If
        Next

        MITableProxy.SaveTable(distanceTable)

        MITableProxy.IfTableOpenCloseTable(candidateCouples)

        ' Create a table with the couples that are potentially part of a crime series
        MapBasicInterop.ExecuteCommand(String.Format("Select * from {0} Where PartOfSeries Into {1}", _
                                                       distanceTable, _
                                                       candidateCouples))

        MITableProxy.SaveAndOpenAsBaseTable(workFolder, candidateCouples)

    End Sub

    ''' <summary>
    ''' Builds the table for linking ISLP points to crime series
    ''' </summary>
    ''' 

    Private Shared Sub MergeCandidatesIntoSeries(ByVal candidateCouplesTable As String, _
                                       ByVal seriesTable As String, _
                                       ByVal seriesFile As String, _
                                       ByVal incidentIDField As String)

        Dim seriesCount As Integer = 0
        Dim seriesRecordCount As Integer = 0

        MITableProxy.IfTableOpenCloseTable(seriesTable)

        MapBasicInterop.ExecuteCommand(String.Format("Create table {0} " & _
                      "( SerID integer,{1} {2}, recordnumber Integer) " & _
                      "File ""{3}""", _
                      seriesTable, _
                      incidentIDField, _
                      MIColumnProxy.GetColumnTypeDescriptor(candidateCouplesTable, "origin").TypeString, _
                      seriesFile))

        For cdRecord = 1 To MITableProxy.GetRowCount(candidateCouplesTable)

            MITableProxy.FetchRecord(candidateCouplesTable, cdRecord)

            Dim originID = MapBasicInterop.Evaluate(candidateCouplesTable & "." & "origin")
            Dim destinationID = MapBasicInterop.Evaluate(candidateCouplesTable & "." & "destination")
            Dim seriesIDOriginValue As Integer ' value of selected series ID

            ' Find the series to which the origin belongs.
            seriesIDOriginValue = FindSeriesOfIncident(seriesTable, _
                                 incidentIDField, _
                                 originID)

            If seriesIDOriginValue = -1 Then

                ' If origin is not part of any series yet, we add it to a new series:
                seriesCount = seriesCount + 1

                ' Update the seriesRecordCount, because we are going to add a record in s_SeriesTable.
                ' The rowID will also be equal to the value of seriesRecordCount.
                seriesRecordCount = seriesRecordCount + 1

                ' Store the seriesIDOriginValue. We need it to set the destination's SerID.
                seriesIDOriginValue = seriesCount

                AddCrimeSeriesRecord(seriesTable, incidentIDField, seriesIDOriginValue, originID, seriesRecordCount)

            End If

            Dim seriesIDDestValue As Integer ' value of selected series ID
            seriesIDDestValue = FindSeriesOfIncident(seriesTable, incidentIDField, destinationID)

            ' If destination is not part of any series yet, we add it to the origin's series.
            If seriesIDDestValue = -1 Then

                ' Insert a series record for the destination with the SerID 
                ' of the origin's series. The incident ID of destination is 
                ' incIDDestinationCouples.

                ' Update the seriesRecordCount, because we are going to add a record in s_SeriesTable.
                seriesRecordCount = seriesRecordCount + 1

                AddCrimeSeriesRecord(seriesTable, _
                                     incidentIDField, _
                                     seriesIDOriginValue, _
                                     destinationID, _
                                     seriesRecordCount)

            Else

                ' Destination was already part of another series. 
                If seriesIDDestValue <> seriesIDOriginValue Then

                    MergeCrimeSeries(seriesTable, _
                                     seriesIDOriginValue, _
                                     seriesIDDestValue)
                End If

            End If

        Next
        MITableProxy.SaveTable(seriesTable)
    End Sub

    ''' <summary>
    ''' Retrieves the SeriesID of the Series to which the incident belong
    ''' </summary>
    ''' 

    Private Shared Function FindSeriesOfIncident(ByVal SeriesTable As String, _
                               ByVal incidentIDField As String, _
                               ByVal incidentValue As String) As Integer

        Dim tempFindSeries = "TempFindSeries"
        Dim seriesID = -1 'set to illegal value for incident ID: -1

        MapBasicInterop.ExecuteCommand(String.Format("Select * from {0} " & _
                                                       "Where {1} = {2} " & _
                                                       "Into {3}", _
                                                       SeriesTable, _
                                                       incidentIDField, _
                                                       incidentValue, _
                                                       tempFindSeries))

        Dim numOrigsFound = MITableProxy.GetRowCount("TempFindSeries")

        If numOrigsFound > 1 Then
            ' A point can never belong to 2 series at the same time. 
            Throw New PoliceGisException(String.Format("Internal error: Incident ""{0}"" is stored in more than one series.", _
                                                       incidentValue))
        Else

            If numOrigsFound = 1 Then
                seriesID = Integer.Parse(MapBasicInterop.Evaluate(String.Format("{0}.SerID", tempFindSeries)))
            End If

        End If

        MITableProxy.CloseTable(tempFindSeries, False)

        Return seriesID

    End Function

    ''' <summary>
    ''' Adds one record to the table for linking ISLP points to crime series.
    ''' </summary>
    ''' 

    Private Shared Sub AddCrimeSeriesRecord(ByVal seriesTable As String, _
                             ByVal incidentIDField As String, _
                             ByVal seriesID As Integer, _
                             ByVal incidentID As String, _
                             ByVal seriesRecordCount As Integer)

        MapBasicInterop.ExecuteCommand(String.Format("Insert Into {0} " & _
                                                       "(SerID, {1}, recordnumber ) Values ({2},{3},{4})", _
                                                       seriesTable, _
                                                       incidentIDField, _
                                                       seriesID.ToString, _
                                                       incidentID, _
                                                       seriesRecordCount.ToString))

    End Sub

    ''' <summary>
    ''' ' Overwrite highest ID with the value of the lowest ID.
    ''' </summary>
    ''' <remarks> </remarks>
    ''' 

    Private Shared Sub MergeCrimeSeries(ByVal seriesTable As String, _
                         ByVal seriesID1 As Integer, _
                         ByVal seriesID2 As Integer)

        Dim temTable As String = "TempRecordNumber"
        Dim lowestID As Integer
        Dim highestID As Integer

        If seriesID1 <= seriesID2 Then

            lowestID = seriesID1
            highestID = seriesID2

        Else

            lowestID = seriesID2
            highestID = seriesID1

        End If

        'Dim seriesIDSeries = MapBasicInterop.Evaluate(seriesTable & "." & "SerID")

        ' Retrieve the record IDs of the series that must be updated 
        MapBasicInterop.ExecuteCommand(String.Format("Select * From {0} " & _
                                                      "Where SerID = {1} Into {2} ", _
                                                      seriesTable, _
                                                      highestID.ToString, _
                                                      temTable))

        Dim recToUpdate As Integer
        'Dim seriesToUpdate As String

        MITableProxy.FetchFirstRecord(temTable)

        ' Loop through selected records and update the Series ID with the lowest ID .
        For rcHighSeries = 1 To MITableProxy.GetRowCount(temTable)

            recToUpdate = Integer.Parse(MapBasicInterop.Evaluate(temTable & ".recordnumber"))
            ' seriesToUpdate = MapBasicInterop.Evaluate(temTable & ".SerID")

            ' Set the SerID to lowestID for all records in series number "highestID".
            MapBasicInterop.ExecuteCommand(String.Format("Update {0} " & _
                                                           "Set SerID = {1} Where Rowid = {2}", _
                                                            seriesTable, _
                                                            lowestID.ToString, _
                                                            recToUpdate.ToString))

            MITableProxy.FetchNextRecord(temTable)

        Next

        MITableProxy.SaveTable(seriesTable)

        MITableProxy.CloseTable(temTable, False)

    End Sub

    Private Shared Function GetCrimeSeriesIDList(ByVal seriesTable As String) As List(Of String)

        Dim list As New List(Of String)
        Dim SeriesListTable = "SeriesIDList"
        Dim a_SerIDTemp = seriesTable & ".SerID"

        Dim createTempTable = String.Format("Select {0} From {1} Group By {0} Into {2}", _
                                            a_SerIDTemp, seriesTable, SeriesListTable)

        MapBasicInterop.ExecuteCommand(createTempTable)

        For serIDCounter = 1 To MITableProxy.GetRowCount(SeriesListTable)

            MITableProxy.FetchRecord(SeriesListTable, serIDCounter)
            list.Add(MapBasicInterop.Evaluate("SeriesIDList.SerID"))

        Next

        MITableProxy.CloseTable(SeriesListTable, False)

        Return list

    End Function

    Private Shared Function GetCrimes(ByVal table As String, _
                               ByVal CrimeFields As CrimeSerieFields) As List(Of Crime)
        Dim list As New List(Of Crime)

        MITableProxy.FetchFirstRecord(table)

        For rw As Integer = 1 To MITableProxy.GetRowCount(table)

            Dim CrimeFact As New Crime
            Dim startDate = MapBasicInterop.Evaluate(String.Format("{0}.{1}", table, CrimeFields.StartDate))
            Dim endDate = MapBasicInterop.Evaluate(String.Format("{0}.{1}", table, CrimeFields.EndDate))
            Dim startTime = MapBasicInterop.Evaluate(String.Format("{0}.{1}", table, CrimeFields.StartTime))
            Dim endTIme = MapBasicInterop.Evaluate(String.Format("{0}.{1}", table, CrimeFields.EndTime))


            With CrimeFact
                .StartDateTime = convertToDate(startDate, startTime)
                .EndDateTime = convertToDate(endDate, endTIme)
                .RowID = rw
                .GeocodeStatus = MapBasicInterop.Evaluate(String.Format("{0}.{1}", table, My.Resources.GeocodingStatusMessages.GeocodingField))
            End With

            If CrimeFact.StartDateTime <> Nothing _
            AndAlso CrimeFact.EndDateTime <> Nothing _
            AndAlso CrimeFact.GeocodeStatus <> My.Resources.GeocodingStatusMessages.NotFound Then
                list.Add(CrimeFact)
                'Else
                '    MITableProxy.DeleteRecord(table, rw)
            End If

            MITableProxy.FetchNextRecord(table)
        Next
        Return list
    End Function

    Private Shared Function convertToDate(ByVal dateTimePart As String) As DateTime

        Dim newDate As DateTime
        If dateTimePart.Length = 17 Then
            newDate = New Date(CInt(dateTimePart.Substring(0, 4)), _
                               CInt(dateTimePart.Substring(4, 2)), _
                               CInt(dateTimePart.Substring(6, 2)), _
                               CInt(dateTimePart.Substring(8, 2)), _
                               CInt(dateTimePart.Substring(10, 2)), _
                               CInt(dateTimePart.Substring(12, 2)))

        End If
        Return newDate
    End Function

    Private Shared Function convertToDate(ByVal datePart As String, ByVal timePart As String) As DateTime
        Dim dateTime = String.Format("{0}{1}", datePart, timePart)
        Return convertToDate(dateTime)
    End Function

    Private Sub ShowResultsOnMap(ByVal crimeSeriesTable As String, ByVal SeriesTable As String, ByVal candidateCouples As String)
        MIMapProxy.SetRedrawOff()

        MIMapProxy.AddLayer(candidateCouples, False) 'shows lines between candidates
        MIMapProxy.AddLayer(crimeSeriesTable, False)

        MIMapProxy.SetRedrawOn()

        Dim seriesIDs = GetCrimeSeriesIDList(SeriesTable)

        If seriesIDs.Count = 0 Then

            MessageBox.Show(My.Resources.NoSerieFound)

        Else

            Dim thematicFieldName = "SeriesID"
            Dim shadeCommand As New StringBuilder

            shadeCommand.Append(String.Format("Shade Window {0} {1} with {2} Values ", _
                                           m_mapWindowHandle, _
                                           crimeSeriesTable, _
                                           thematicFieldName))

            For serieID = 0 To seriesIDs.Count - 1

                shadeCommand.Append(String.Format("{0} Symbol (34,{1},12) ", _
                                                  seriesIDs(serieID), _
                                                  AnalysisCommon.GetShadeColor(serieID)))

                If serieID <> seriesIDs.Count - 1 Then
                    shadeCommand.Append(",")
                Else
                    shadeCommand.Append(" default Symbol (40,0,12)")
                End If

            Next

            MapBasicInterop.ExecuteCommand(shadeCommand.ToString)
            AnalysisCommon.SetLegend(String.Format("{0} {1}", My.Resources.Legend, My.Resources.CrimeSeries), _
                                         String.Format("""{0}(1)""", crimeSeriesTable), _
                                          False, _
                                          True, _
                                          False, _
                                          True, _
                                          seriesIDs, _
                                          m_mapWindowHandle, _
                                          "Ascending on")

            MIWindowProxy.ReparentLegendWindow(m_mapWindowHandle, m_legendWindowHandle, True)

            ' Show table with result
            ' MapBasicInterop.ExecuteCommand(String.Format("Browse * from {0} ", crimeSeriesTable))

        End If
    End Sub



    Private Shared Sub CreateNewCrimeTable(ByVal crimes As List(Of Crime), ByVal tableName As String)

        For Each crime In crimes

            MITableProxy.FetchRecord(tableName, crime.RowID)

            MapBasicInterop.ExecuteCommand(String.Format("update {0} set CrimeID = {3}, {1} = {4}, {2} = {5} WHERE rowid = {3}", _
                                                           tableName, _
                                                            My.Settings.StartDateField, _
                                                            My.Settings.EndDateField, _
                                                           crime.RowID, _
                                                           crime.StartDateTime.ToString("yyyyMMddHHmmss000"), _
                                                           crime.EndDateTime.ToString("yyyyMMddHHmmss000")))

        Next
        MITableProxy.SaveTable(tableName)
    End Sub


    Private Shared Sub DeleteCrimes(ByVal table As String, _
                            ByVal crimes As List(Of Crime))

        MITableProxy.FetchFirstRecord(table)

        For rw As Integer = 1 To MITableProxy.GetRowCount(table)


            Dim rowids = From som In crimes Select som.RowID

            If Not rowids.Contains(rw) Then
                MITableProxy.DeleteRecord(table, rw)
            End If

            MITableProxy.FetchNextRecord(table)

        Next
        MITableProxy.SaveTable(table)
        MITableProxy.PackTable(table)
    End Sub
End Class
