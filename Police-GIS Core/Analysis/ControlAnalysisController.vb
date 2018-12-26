Public Class ControlAnalysisController

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

    Public Sub GenerateAnalysis(ByVal areaSpecificSettings As PGISAreaSpecificSettings, _
                                ByVal controlesField As String, ByVal isCrime As Boolean)

        AnalysisCommon.OpenWorkspace(areaSpecificSettings.StartupWorkspace, m_mapWindowHandle, m_legendWindowHandle, False)

        areaSpecificSettings.AreaIslpTable = AnalysisCommon.CreateNewNaam(areaSpecificSettings.WerkFolder, isCrime, areaSpecificSettings.Area, "C")

        areaSpecificSettings.AreaIslpFile = String.Format("{0}{1}.TAB", areaSpecificSettings.WerkFolder, areaSpecificSettings.AreaIslpTable)

        AnalysisCommon.LimitIslpToArea(areaSpecificSettings)

        AnalysisCommon.ShadeMapWithGraduatedValues(m_mapWindowHandle, controlesField, areaSpecificSettings.AreaIslpTable, MapBasicConstants.YELLOW)

        MIWindowProxy.ReparentLegendWindow(m_mapWindowHandle, m_legendWindowHandle, True)

        areaSpecificSettings.AreaIslpTable = My.Settings.AreaISLPTable

        areaSpecificSettings.AreaIslpFile = String.Format("{0}{1}.TAB", areaSpecificSettings.WerkFolder, areaSpecificSettings.AreaIslpTable)

        MIWindowProxy.Rename(m_mapWindowHandle, String.Format("{0} - {1} {2}", areaSpecificSettings.TypeAnalyse, "Controles", areaSpecificSettings.AreaNaamSpatie))

    End Sub

End Class
