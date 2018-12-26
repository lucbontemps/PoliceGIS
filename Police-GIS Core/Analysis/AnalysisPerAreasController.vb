Imports System.Text
Imports System.IO
Imports System.Drawing

Public Class AnalysisPerAreasController


    Private m_legendWindowHandle As Integer
    Private m_mapWindowHandle As Integer
    Private m_areaSpecificSettings As PGISAreaSpecificSettings


    Sub GenerateAnalysisPerArea(ByVal areaSpecificSettings As PGISAreaSpecificSettings, _
                                ByVal uniqueColumnValuesForTheme As List(Of String), _
                                ByVal columnForPie As String, _
                                ByVal inKleuren As Boolean, ByVal isCrime As Boolean)


        m_areaSpecificSettings = areaSpecificSettings

        ' Open workspace for the selected area
        AnalysisCommon.OpenWorkspace(TransformToGAWorkspace(m_areaSpecificSettings), _
                                       m_mapWindowHandle, m_legendWindowHandle, False)


        areaSpecificSettings.PieTable = AnalysisCommon.CreateNewNaam(areaSpecificSettings.WerkFolder, isCrime, areaSpecificSettings.Area, "G")
        areaSpecificSettings.PieFile = String.Format("{0}{1}.TAB", areaSpecificSettings.WerkFolder, areaSpecificSettings.PieTable)


        ' Only select incidents that fall within the chosen area
        AnalysisCommon.LimitIslpToArea(m_areaSpecificSettings)

        CreatePieTable(columnForPie, uniqueColumnValuesForTheme, m_areaSpecificSettings.NumberIncidentsField)

        ' Sanity check: if the pie table contains no data, it makes no sence to keep going on. 
        If MITableProxy.GetRowCount(m_areaSpecificSettings.PieTable) = 0 Then
            Throw New PoliceGisException(String.Format(My.Resources.ExceptionMessages.NoRecordsFound, m_areaSpecificSettings.PieTable))
        End If

        'Add layers for creating the thematic map

        If columnForPie IsNot Nothing Then

            AnalysisCommon.ShadeMapWithPies(m_mapWindowHandle, m_areaSpecificSettings.PieTable, uniqueColumnValuesForTheme.Count)


        Else

            If inKleuren Then

                AnalysisCommon.ShadeMapRegionsByRange(m_mapWindowHandle, m_areaSpecificSettings.NumberIncidentsField, m_areaSpecificSettings.PieTable, m_areaSpecificSettings.NumberOfClasses)


            Else

                AnalysisCommon.ShadeMapWithGraduatedValues(m_mapWindowHandle, _
                                                          m_areaSpecificSettings.NumberIncidentsField, _
                                                          m_areaSpecificSettings.PieTable, _
                                                          MapBasicConstants.RED)
            End If



        End If

        AnalysisCommon.SetLegend(My.Resources.NumberOfincidenten, "Prev", True, False, False, False, _
                                    uniqueColumnValuesForTheme, m_mapWindowHandle, "Ascending on")

        showMap(inKleuren)

        MIWindowProxy.Rename(m_mapWindowHandle, String.Format("{0} - {1} {2}", areaSpecificSettings.TypeAnalyse, My.Resources.AnalyseByArea, areaSpecificSettings.AreaNaamSpatie))


    End Sub

    Private Sub showMap(ByVal inkleuren As Boolean)

        MIMapProxy.AddLayer(m_areaSpecificSettings.PieTable, False)

        MIMapProxy.SetRedrawOff()

        ' Give the pie table a purple border, thickness 3 pix and transparent fill.


        MapBasicInterop.ExecuteCommand(String.Format( _
                                        "Set Map Layer {0} Display Global " & _
                                        "Global Pen (3,2,6291648) " & _
                                        "Global Brush (1,16777215,16777215) ", _
                                        m_areaSpecificSettings.PieTable))
        If inkleuren Then

            MILayerProxy.LabelOn(m_mapWindowHandle, m_areaSpecificSettings.PieTable)
            Dim labelField = ""
            Dim s = m_areaSpecificSettings.pieAggregationFile.Split(CChar("\"))
            If s.Last.Replace(".tab", "") = m_areaSpecificSettings.Area Then
                labelField = "NamePZ"
            Else
                labelField = "NaamKORT"
            End If
            MILayerProxy.LabelWith(m_mapWindowHandle, m_areaSpecificSettings.PieTable, labelField)
        End If

        MIMapProxy.SetRedrawOn()

        MIWindowProxy.ReparentLegendWindow(m_mapWindowHandle, m_legendWindowHandle, True)

    End Sub

    ''' <summary>
    ''' Create a table with de data for showing pie charts on the map.
    ''' </summary>
    ''' <param name="columnForPie"></param>
    ''' <param name="uniqueColumnValuesForTheme"></param>
    ''' <param name="columnIncidents"></param>
    ''' <remarks></remarks>
    Private Sub CreatePieTable(ByVal columnForPie As String, _
                               ByVal uniqueColumnValuesForTheme As List(Of String), _
                               ByVal columnIncidents As String)

        MITableProxy.IfTableOpenCloseTable(m_areaSpecificSettings.PieTable)
        If Not MITableProxy.IsTableOpen(m_areaSpecificSettings.PieAggregationTable) Then
            MITableProxy.OpenTableAs(m_areaSpecificSettings.pieAggregationFile, False, m_areaSpecificSettings.PieAggregationTable)
        End If
        MITableProxy.SaveTableAs(m_areaSpecificSettings.PieAggregationTable, m_areaSpecificSettings.PieFile, False)

        MITableProxy.OpenTableChecked(m_areaSpecificSettings.PieTable, m_areaSpecificSettings.PieFile)

        If columnForPie IsNot Nothing Then

            AnalysisCommon.CreatePieChartData(m_areaSpecificSettings, _
                                                columnForPie, _
                                                uniqueColumnValuesForTheme)

        Else

            MITableProxy.AddColumn(m_areaSpecificSettings.PieTable, columnIncidents, "Integer", True)

            Dim linkIncidentsToPieTable = String.Format("Add Column {0}({1}) From {2} Set To Count(*) Where within", _
                                                 m_areaSpecificSettings.PieTable, _
                                                 columnIncidents, m_areaSpecificSettings.islpTable)

            MapBasicInterop.ExecuteCommand(linkIncidentsToPieTable)

            MITableProxy.SaveTable(m_areaSpecificSettings.PieTable)

        End If

    End Sub

    Private Shared Function TransformToGAWorkspace(ByVal wp As PGISAreaSpecificSettings) As String

        Return wp.StartupWorkspace.Replace(wp.Version, String.Format("_GA{0}", wp.Version))
    End Function

End Class

