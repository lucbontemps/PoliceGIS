Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

''' <summary>
''' This class controls the workflow of an analysis per street.
''' </summary>
''' <remarks></remarks>
''' 
Public Class AnalysisPerStreetController

    ''' <summary>
    ''' Window handle for the mapper window of the workspace.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_mapWindowHandle As Integer

    ''' <summary>
    ''' Window handle for the legend window of the workspace.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_legendWindowHandle As Integer

    Public ReadOnly Property LegenWindowHandle() As Integer
        Get
            Return m_legendWindowHandle
        End Get
    End Property

    Public ReadOnly Property MapWindowHandle() As Integer
        Get
            Return m_mapWindowHandle
        End Get
    End Property

    Public Sub GenerateAnalysisPerStreet(ByVal areaSpecificSettings As PGISAreaSpecificSettings, ByVal isCrime As Boolean)
        Dim workspace = areaSpecificSettings.StartupWorkspace.Replace(String.Format("{0}{1}.wor", areaSpecificSettings.Area, PGISConfigurationManager.GetInstance.GeocodingSettings.Version), String.Format("{0}_GA{1}.wor", areaSpecificSettings.Area, PGISConfigurationManager.GetInstance.GeocodingSettings.Version))

        AnalysisCommon.OpenWorkspace(workspace, m_mapWindowHandle, m_legendWindowHandle, False)

        areaSpecificSettings.RoadAggrTempTable = AnalysisCommon.CreateNewNaam(areaSpecificSettings.WerkFolder, isCrime, areaSpecificSettings.Area, "S")
        areaSpecificSettings.RoadAggrTempFile = String.Format("{0}{1}.TAB", areaSpecificSettings.WerkFolder, areaSpecificSettings.RoadAggrTempTable)

        ' Only select accidents or criminal incidents that fall within the chosen area
        AnalysisCommon.LimitIslpToArea(areaSpecificSettings)

        LinkIncidentsToStreets(areaSpecificSettings)

        Dim rangeLimits = CreateThematicMap(areaSpecificSettings, areaSpecificSettings.NumberOfClasses)

        CreateLegend(areaSpecificSettings, My.Resources.StreetAnalysis, rangeLimits)

        MIWindowProxy.ReparentLegendWindow(m_mapWindowHandle, m_legendWindowHandle, True)

        MIWindowProxy.Rename(m_mapWindowHandle, String.Format("{0} - {1} {2}", areaSpecificSettings.TypeAnalyse, My.Resources.StreetAnalysis, areaSpecificSettings.AreaNaamSpatie))

        LabelStreetsWithIncidents(areaSpecificSettings)

        'wegen zonder incidenten uitgrijzen
        'MapBasicInterop.ExecuteCommand(String.Format("shade Window {0} {1} with {2} ranges 0:0 Line (1,2,12632256)", m_mapWindowHandle, areaSpecificSettings.roadAggrTempTable, areaSpecificSettings.NumberIncidentsField))

    End Sub


    ''' <summary>
    ''' Copies the counts from the street buffers to aggregated 
    ''' streets. (street axis / line geometry)
    ''' This layer has a better visual presentation the buffers.
    ''' </summary>
    ''' <param name="areaSpecificSettings"></param>
    ''' <remarks></remarks>

    Private Shared Sub LinkIncidentsToStreets(ByVal areaSpecificSettings As PGISAreaSpecificSettings)

        ' The bufferTable aggregate all the incidents around one road
        MITableProxy.OpenTableChecked(areaSpecificSettings.RoadBufferTable, areaSpecificSettings.RoadBufferFile)

        ' The aggregatedTable contains the "complete" roads <> several road segements.
        MITableProxy.OpenTableChecked(areaSpecificSettings.RoadAggrTable, areaSpecificSettings.RoadAggrFile)

        MITableProxy.IfTableOpenCloseTable(areaSpecificSettings.RoadBufferTempTable)

        ' Make copy of the buffered streets for editing.
        MITableProxy.SaveTableAs(areaSpecificSettings.RoadBufferTable, areaSpecificSettings.RoadBufferTempFile, False)
        MITableProxy.OpenTableChecked(areaSpecificSettings.RoadBufferTempTable, areaSpecificSettings.RoadBufferTempFile)

        ' Create a column for counting the accidents/crimes inside a buffer, and fill it.
        MITableProxy.AddColumn(areaSpecificSettings.RoadBufferTempTable, areaSpecificSettings.NumberIncidentsField, "Integer", True)
        Dim LinkIncidentsWithStreetsCommand = String.Format("Add Column {0}({1})From {2} Set To Count(*) Where within ", _
                                                     areaSpecificSettings.RoadBufferTempTable, _
                                                     areaSpecificSettings.NumberIncidentsField, _
                                                     areaSpecificSettings.islpTable)

        MapBasicInterop.ExecuteCommand(LinkIncidentsWithStreetsCommand)

        MITableProxy.SaveTable(areaSpecificSettings.RoadBufferTempTable)

        MITableProxy.IfTableOpenCloseTable(areaSpecificSettings.RoadAggrTempTable)

        ' Make copy of aggregated roads for editing.
        MITableProxy.SaveTableAs(areaSpecificSettings.RoadAggrTable, areaSpecificSettings.RoadAggrTempFile, False)
        MITableProxy.OpenTableChecked(areaSpecificSettings.RoadAggrTempTable, areaSpecificSettings.RoadAggrTempFile)

        ' Add column to aggregation_temp for the number of incidents that occured arround the street.
        MITableProxy.AddColumn(areaSpecificSettings.RoadAggrTempTable, areaSpecificSettings.NumberIncidentsField, "Integer", True)

        'Dim streetIdColumnAggr As String = areaSpecificSettings.RoadAggrTempTable & "." & areaSpecificSettings.StreetIDField
        'Dim streetIdColumnBuffer As String = areaSpecificSettings.RoadBufferTempTable & "." & areaSpecificSettings.StreetIDField
        Dim addColumnStatement As String = String.Format("Add Column {0} ({1}) From {2} " & _
                                                         "Set To {1} " & _
                                                         "Where {3} = {3}", _
                                             areaSpecificSettings.RoadAggrTempTable, _
                                             areaSpecificSettings.NumberIncidentsField, _
                                             areaSpecificSettings.RoadBufferTempTable, _
                                             areaSpecificSettings.StreetIDField)

        MapBasicInterop.ExecuteCommand(addColumnStatement)

        MITableProxy.SaveTable(areaSpecificSettings.RoadAggrTempTable)
        'Dim removeEmptyStreets = String.Format(" Delete from {0} where {1} = 0", areaSpecificSettings.RoadAggrTempTable, areaSpecificSettings.NumberIncidentsField)
        'MapBasicInterop.ExecuteCommand(removeEmptyStreets)
    End Sub


    Public Function CreateThematicMap(ByVal areaSpecificSettings As PGISAreaSpecificSettings, _
                                  ByVal numberOfClasses As Integer) As List(Of Double)

        MIMapProxy.AddLayer(areaSpecificSettings.RoadAggrTempTable, True)

        MapBasicInterop.ExecuteCommand(String.Format("Select Min({0}), Max({0}) From {1}", areaSpecificSettings.NumberIncidentsField, areaSpecificSettings.RoadAggrTempTable))

        Dim selectionTable = MITableProxy.GetTableName(0)

        Dim minimum As Integer = Integer.Parse(MapBasicInterop.Evaluate("Selection.COL1"))
        Dim maximum As Integer = Integer.Parse(MapBasicInterop.Evaluate("Selection.COL2"))

        'close temp tables

        MITableProxy.CloseTable(MITableProxy.GetTableName(0), False)
        MITableProxy.CloseTable(selectionTable, False)

        ' Create the class ranges

        Dim rangeLimits = AnalysisCommon.GetRangeLimits(minimum, maximum, numberOfClasses)

        Dim rangeOfColors = AnalysisCommon.GetRangeOfColors(numberOfClasses)

        Dim shadeCommand As New StringBuilder 'add thematic layers to the map
        shadeCommand.Append(String.Format("Shade Window {0} {1} " & _
                                       "with {2} ignore 0 " & _
                                       "Ranges Apply All Use All Line (1,2, 12632256) ", _
                                       m_mapWindowHandle, _
                                       areaSpecificSettings.RoadAggrTempTable, _
                                        areaSpecificSettings.NumberIncidentsField))


        ' Loop through the ranges and add the styles for each range.
        For stl As Integer = 0 To numberOfClasses - 1

            Dim lineWidth = ((stl + 1) * 2) - 1
            Dim linePattern = "2"
            Dim lineColor = rangeOfColors(stl)

            shadeCommand.Append(String.Format(MapBasicInterop.GetMapInfoNumFormat, _
                                                  "{0}:{1} line({2},{3},{4})", _
                                                  rangeLimits(stl), _
                                                  rangeLimits(stl + 1), _
                                                  lineWidth, _
                                                  linePattern, _
                                                  lineColor))


            If stl < numberOfClasses - 1 Then
                shadeCommand.Append(", ")
            End If

        Next

        ' last part of the command for the default style
        shadeCommand.Append(" default Line (1,2,12632256)")

        MapBasicInterop.ExecuteCommand(shadeCommand.ToString)

        Return rangeLimits
    End Function


    Private Sub CreateLegend(ByVal areaSpecificSettings As PGISAreaSpecificSettings, ByVal title As String, ByVal rangeLimits As List(Of Double))

        Dim legendCommand As New StringBuilder

        legendCommand.Append(String.Format(MapBasicInterop.GetMapInfoNumFormat, _
                                             "set legend window {0} " & _
                                             "layer prev display on shades off symbols off lines on " & _
                                             "count on title ""{1}"" " & _
                                             "Font (""Arial"",0,9,0) " & _
                                             "subtitle auto " & _
                                             "Font (""Arial"",0,8,0) " & _
                                             "ascending off " & _
                                             "ranges Font (""Arial"",0,8,0) auto display off ,", _
                                             m_mapWindowHandle, _
                                             title))

        ' add legend specs for all classes

        Dim uniqueValues = MIColumnProxy.GetUniqueValues(areaSpecificSettings.RoadAggrTempTable, areaSpecificSettings.NumberIncidentsField)

        For classCount As Integer = 1 To areaSpecificSettings.NumberOfClasses
            Dim range = "auto"
            Dim uniqueValue = GetUniqueValues(uniqueValues, rangeLimits(classCount - 1), rangeLimits(classCount))
            Dim display = "on"
            If uniqueValue.Count = 1 Then

                If uniqueValue.First = 0 Then
                    display = "off"
                End If

                range = String.Format("""{0}""", uniqueValue.First.ToString)

            End If

            If classCount <> areaSpecificSettings.NumberOfClasses Then
                legendCommand.Append(String.Format("{0} display {1} ,", range, display))
            Else
                legendCommand.Append(String.Format("{0} display {1} ", range, display))
            End If

        Next

        MapBasicInterop.ExecuteCommand(legendCommand.ToString)

    End Sub

    Private Shared Function GetUniqueValues(ByVal uniqueVal As List(Of String), ByVal beginValue As Double, ByVal endValue As Double) As List(Of Integer)

        Dim Values As New List(Of Integer)
        For Each value In uniqueVal
            Dim iValue = Integer.Parse(value)
            If iValue >= CInt(beginValue) And iValue <= CInt(endValue) Then
                Values.Add(iValue)
            End If
        Next
        If Values.Count = 0 Then
            Values.Add(0)
        End If
        Return Values
    End Function

    Private Sub LabelStreetsWithIncidents(ByVal areaSpecificSettings As PGISAreaSpecificSettings)

        Dim tempTable = "Selection"
        MapBasicInterop.ExecuteCommand(String.Format("select * from {0} where Aantal_Incidenten <> 0 into {1}", areaSpecificSettings.RoadAggrTempTable, tempTable))
        MapBasicInterop.ExecuteCommand(String.Format("Add Map Window {0} Auto Layer {1}", m_mapWindowHandle, tempTable))
        MapBasicInterop.ExecuteCommand(String.Format("Set Map Window {0}  Layer 1 Display Global Global Line (1,1,0)  Label Font (""Arial"",257,9,0,16777215) Follow Path  Auto Retry On", m_mapWindowHandle))
        MapBasicInterop.ExecuteCommand(String.Format("Set Map Window {0}  Layer 1 Label Auto On", m_mapWindowHandle))
        MapBasicInterop.ExecuteCommand("Select * from Selection where Aantal_Incidenten = 0")

    End Sub

End Class
