Imports System.IO
Imports System.Globalization
Imports System.Text



''' <summary>
''' This class controls the work flow for a point analysis.
''' </summary>
''' <remarks></remarks>
Public Class PointAnalysisController
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

    Public Sub GeneratePointAnalysis(ByVal areaSpecificSettings As PGISAreaSpecificSettings, _
                                     ByVal uniqueColumnValuesForTheme As List(Of String), _
                                     ByVal thematicFieldName As String, ByVal isCrime As Boolean)

        AnalysisCommon.OpenWorkspace(areaSpecificSettings.StartupWorkspace, m_mapWindowHandle, m_legendWindowHandle, False)

        areaSpecificSettings.AreaIslpTable = AnalysisCommon.CreateNewNaam(areaSpecificSettings.WerkFolder, isCrime, areaSpecificSettings.Area, "P")
        areaSpecificSettings.AreaIslpFile = String.Format("{0}{1}.TAB", areaSpecificSettings.WerkFolder, areaSpecificSettings.AreaIslpTable)

        AnalysisCommon.LimitIslpToArea(areaSpecificSettings)

        MIMapProxy.AddLayer(areaSpecificSettings.AreaIslpTable, True)

        'Color the points by individual values in a field.
        If uniqueColumnValuesForTheme.Count > 0 Then

            CreateThematicLayer(areaSpecificSettings, uniqueColumnValuesForTheme, thematicFieldName)
            CreateLegend(uniqueColumnValuesForTheme, String.Format("{0} {1}", My.Resources.Legend, thematicFieldName))

        End If

        MIWindowProxy.ReparentLegendWindow(m_mapWindowHandle, m_legendWindowHandle, True)

        areaSpecificSettings.AreaIslpTable = My.Settings.AreaISLPTable
        areaSpecificSettings.AreaIslpFile = String.Format("{0}{1}.TAB", areaSpecificSettings.WerkFolder, areaSpecificSettings.AreaIslpTable)

        MIWindowProxy.Rename(m_mapWindowHandle, String.Format("{0} - {1} {2}", areaSpecificSettings.TypeAnalyse, My.Resources.AnalyseByPoint, areaSpecificSettings.AreaNaamSpatie))

    End Sub

    Private Sub CreateThematicLayer(ByVal areaSpecificSettings As PGISAreaSpecificSettings, _
                                    ByVal uniqueColumnValuesForTheme As List(Of String), _
                                    ByVal thematicFieldName As String)

        Dim shadeCommand As New StringBuilder
        shadeCommand.Append(String.Format(MapBasicInterop.GetMapInfoNumFormat, _
                                        "Shade Window {0} {1} with {2} ignore """" values ", _
                                        m_mapWindowHandle, _
                                        areaSpecificSettings.AreaIslpTable, _
                                        thematicFieldName))

        For i As Integer = 0 To uniqueColumnValuesForTheme.Count - 1

            Dim escapedValue As String = MapBasicInterop.QuoteAndEscapeString(uniqueColumnValuesForTheme(i))

            Dim colorDescription As String = AnalysisCommon.GetShadeColor(i)
            shadeCommand.Append(String.Format("""{0}"" Symbol(34,{1},12)", escapedValue, colorDescription))

            If i <> uniqueColumnValuesForTheme.Count - 1 Then
                shadeCommand.Append(", ")
            Else
                shadeCommand.Append(" default Symbol (40,0,12)")
            End If

        Next

        MapBasicInterop.ExecuteCommand(shadeCommand.ToString)

    End Sub


    Private Sub CreateLegend(ByVal uniqueColumnValuesForTheme As List(Of String), ByVal title As String)

        Dim legendDefaultRangeName = "anderen"
        Dim setLegendCommand As New StringBuilder
        setLegendCommand.Append(String.Format("Set Legend Window {0} Layer prev " & _
                                              "Display on Shades off Symbols on Lines off Count on " & _
                                              "Title ""{1}"" " & _
                                              "Font (""Arial"",0,9,0) " & _
                                              "Subtitle auto Font (""Arial"",0,8,0) " & _
                                              "Order Custom " & _
                                              "Ranges Font (""Arial"",0,8,0) ", _
                                              m_mapWindowHandle, _
                                              title))

        For i As Integer = 0 To uniqueColumnValuesForTheme.Count - 1

            Dim legendValue As String = uniqueColumnValuesForTheme(i).Replace("""", "'")

            setLegendCommand.Append(String.Format("Range ""{0}"" auto display on , ", legendValue))

            If i = (uniqueColumnValuesForTheme.Count - 1) Then
                setLegendCommand.Append(String.Format(" range default ""{0}"" display off ", legendDefaultRangeName))
            End If

        Next

        MapBasicInterop.ExecuteCommand(setLegendCommand.ToString)

    End Sub

End Class
