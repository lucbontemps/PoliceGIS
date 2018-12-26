
' System namespaces
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms

' Microsoft namespaces
Imports Microsoft.Win32.Registry

''' <summary>
''' This class controls the flow of an analysis of black points.
''' </summary>
''' <remarks></remarks>
Public Class BlackPointAnalysisController


    ''' <summary>
    ''' Window handle for the mapper window of the workspace.
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared sh_mapWindowHandle As Integer

    ''' <summary>
    ''' Window handle for the legend window of the workspace.
    ''' </summary>
    ''' <remarks></remarks>
    Private Shared sh_legendWindowHandle As Integer

    ''' <summary>
    ''' Helper object for common task in GIS analysis.
    ''' </summary>
    ''' <remarks></remarks>

    Private Shared sh_columnForPie As String = ""
    Private Shared sh_uniqueColumnValuesTheme As List(Of String)
    Private Shared sh_areaSpecificSettings As New PGISAreaSpecificSettings

    Private Const ILLEGAL_DISTANCE As Integer = -1
    Private Const BUTTON_BLACKPOINT As Integer = 6
    Private Const BUTTON_DRAWPIES As Integer = 7
    Private Const BUTTON_CHANGEBUFFER As Integer = 8
    Private Const BUTTON_SAVEMAP As Integer = 9



    Public Shared Sub GenerateBlackPointAnalysis(ByVal areaSpecificSettings As PGISAreaSpecificSettings, _
                                          ByVal uniqueColumnValuesForTheme As List(Of String), _
                                          ByVal columnForPie As String, _
                                          ByVal isCrime As Boolean, _
                                          ByVal filename As String)

        sh_areaSpecificSettings = areaSpecificSettings
        sh_uniqueColumnValuesTheme = uniqueColumnValuesForTheme
        sh_columnForPie = columnForPie

        ' Open workspace for selected area
        AnalysisCommon.OpenWorkspace(sh_areaSpecificSettings.StartupWorkspace, sh_mapWindowHandle, sh_legendWindowHandle, False)

        ' Only select incidents that fall within chosen area
        AnalysisCommon.LimitIslpToArea(sh_areaSpecificSettings)

        areaSpecificSettings.BlackPointTable = AnalysisCommon.CreateNewNaam(areaSpecificSettings.WerkFolder, isCrime, areaSpecificSettings.Area, "Z")
        areaSpecificSettings.BlackPointFile = String.Format("{0}{1}.TAB", areaSpecificSettings.WerkFolder, areaSpecificSettings.BlackPointTable)

        If filename Is Nothing Then

            CreateBlackPointTAble()

            MITableProxy.MakeMappable(sh_areaSpecificSettings.BlackPointTable, CoreLibConstants.CS_LAMBERT_1972)

        Else
            MITableProxy.OpenTableAs(filename, False, areaSpecificSettings.BlackPointTable)
            MITableProxy.SaveTableAs(areaSpecificSettings.BlackPointTable, areaSpecificSettings.BlackPointFile, False)
            MITableProxy.CloseTable(areaSpecificSettings.BlackPointTable, False)
            MITableProxy.OpenTableAs(areaSpecificSettings.BlackPointFile, False, areaSpecificSettings.BlackPointTable)
        End If


   
        MIMapProxy.SetRedrawOff()
        MIMapProxy.AddLayer(sh_areaSpecificSettings.AreaIslpTable, True)
        MIMapProxy.SetRedrawOn()

        MIButtonProxy.Enable(BUTTON_BLACKPOINT)

        MIWindowProxy.ReparentLegendWindow(sh_mapWindowHandle, sh_legendWindowHandle, False)
        MIWindowProxy.Rename(sh_mapWindowHandle, String.Format("{0} - {1} {2}", sh_areaSpecificSettings.TypeAnalyse, My.Resources.BlackPointAnlysis, sh_areaSpecificSettings.AreaNaamSpatie))

        If filename IsNot Nothing Then
            ShowBuffersOnMap()
        End If


    End Sub


    Public Shared Sub BlackPointToolHandler(ByVal newPoint As Boolean)

        If Not newPoint AndAlso MISelectionProxy.NumberOfRows <> 1 Then
            'you can only change the buffer from one selected blackpoint.
            MessageBox.Show(My.Resources.ExceptionMessages.SelectOnlyOne)
        Else
            If MIWindowProxy.FrontWindow() <> sh_mapWindowHandle Then
                Throw New PoliceGisException(My.Resources.ExceptionMessages.BlackPointWindowNotSelected)
            End If

            Dim bufferdistance As Double = ILLEGAL_DISTANCE

            MapBasicInterop.ExecuteCommand(String.Format("Set CoordSys {0}", CoreLibConstants.CS_LAMBERT_1972))

            Dim bufferForm As New FormGetBuffer ' Retrieve buffer distance form user.

            If Not newPoint Then
                MITableProxy.FetchRecord(sh_areaSpecificSettings.BlackPointTable, CInt(MICommandInfo.ROWID))
                bufferForm.BufferSizeNumericUD.Value = CDec(MapBasicInterop.Evaluate(sh_areaSpecificSettings.BlackPointTable & "." & "bufdist"))
            End If

            If bufferForm.ShowDialog = DialogResult.OK Then

                bufferdistance = bufferForm.BufferSize

                If bufferdistance <> ILLEGAL_DISTANCE Then
                    If newPoint Then
                        InsertBuffer(bufferdistance)
                    Else

                        Dim rid = MICommandInfo.ROWID
                        UpdateBuffer(CInt(rid), bufferdistance)

                    End If

                    ShowBuffersOnMap()

                End If

            End If

        End If
       

    End Sub

    ''' <summary>
    ''' Generate Map using CrossroadAnalysis Method
    ''' </summary>
    ''' <remarks></remarks>
    ''' 

    Public Shared Sub DrawPieChartsOnCrossRoads()

        MIButtonProxy.Disable(BUTTON_BLACKPOINT)

        MapBasicInterop.ExecuteCommand(String.Format("Add Column {0}({1}) " & _
                                 "From {2} Set To Count(*) " & _
                                 "Where within", _
                                 sh_areaSpecificSettings.BlackPointTable, _
                                 sh_areaSpecificSettings.NumberIncidentsField, _
                                 sh_areaSpecificSettings.islpTable))

        MITableProxy.SaveTable(sh_areaSpecificSettings.BlackPointTable)


        If sh_columnForPie Is Nothing Then

            ShadeMapWithNumberOfIncidents()

        Else

            ShadeMapWithPies()

        End If

        MIButtonProxy.Disable(BUTTON_DRAWPIES)
        MIButtonProxy.Disable(BUTTON_CHANGEBUFFER)
        MIWindowProxy.ReparentLegendWindow(sh_mapWindowHandle, sh_legendWindowHandle, True)

    End Sub




    Private Shared Sub InsertBuffer(ByVal bufferdistance As Double)

        Dim rowID As Integer
        Dim x = MICommandInfo.CoordinateX.ToString(MapBasicInterop.GetMapInfoNumFormat)
        Dim y = MICommandInfo.CoordinateY.ToString(MapBasicInterop.GetMapInfoNumFormat)

        ' Add a new record with an id which is one higher then the last.
        rowID = 1 + MITableProxy.GetRowCount(sh_areaSpecificSettings.BlackPointTable)

        ' Store the point in table m_areaSpecificSettings.crossRoadTable
        MapBasicInterop.ExecuteCommand(String.Format(MapBasicInterop.GetMapInfoNumFormat, _
                                                    "INSERT INTO {0} (id, xcoord, ycoord, bufdist, Obj) " & _
                                                    "VALUES({1},{2},{3},{4},CreatePoint(xcoord,ycoord))", _
                                                    sh_areaSpecificSettings.BlackPointTable, _
                                                    rowID, x, y, bufferdistance))


        MapBasicInterop.ExecuteCommand(String.Format("Run Menu Command {0}", MapBasicConstants.M_TOOLS_SELECTOR))

        MITableProxy.SaveTable(sh_areaSpecificSettings.BlackPointTable)

        ' Create buffer polygons from the points which the user has chosen.
        UpdateBuffer(rowID, bufferdistance)


    End Sub

    Private Shared Sub UpdateBuffer(ByVal rowID As Integer, ByVal bufferdistance As Double)
        MapBasicInterop.ExecuteCommand(String.Format( _
            "Update {0} " & _
            "set  Obj = Buffer(CreatePoint(xcoord, ycoord), 30, {1}, ""m""), bufdist = {1}" & _
            "Where Rowid = {2}", _
            sh_areaSpecificSettings.BlackPointTable, _
            bufferdistance, _
            rowID))

        MITableProxy.SaveTable(sh_areaSpecificSettings.BlackPointTable)
        MITableProxy.CloseTable(sh_areaSpecificSettings.BlackPointTable, False)
        MITableProxy.OpenTable(sh_areaSpecificSettings.BlackPointFile, False)
    End Sub

    Private Shared Sub ShowBuffersOnMap()

        MIMapProxy.SetRedrawOff()  ' Hold off map redraws when we are changing then layers

        MIMapProxy.AddLayer(sh_areaSpecificSettings.BlackPointTable, False)

        ' Set the style of the buffer layer: no pattern and a blue border with a thickness of 2 pixels.
        MapBasicInterop.ExecuteCommand(String.Format( _
            "Set Map Layer {0} " & _
            "Display Global " & _
            "Global Pen (2,2,255)  " & _
            "Global Brush (1,16777215,16777215)", _
            sh_areaSpecificSettings.BlackPointTable))

        MIMapProxy.SetRedrawOn()
        MIButtonProxy.Enable(BUTTON_DRAWPIES)
        MIButtonProxy.Enable(BUTTON_CHANGEBUFFER)
        MITableProxy.SaveTable(sh_areaSpecificSettings.BlackPointTable)

    End Sub

    Private Shared Sub CreateBlackPointTAble()
        MapBasicInterop.ExecuteCommand(String.Format("Create Table {0} " & _
                                                       "(id Integer, xcoord Float, ycoord Float, bufdist Float) " & _
                                                       "File ""{1}""", _
                                                       sh_areaSpecificSettings.BlackPointTable, _
                                                       sh_areaSpecificSettings.BlackPointFile))
    End Sub

    Private Shared Sub ShadeMapWithNumberOfIncidents()

        If MITableProxy.GetRowCount(sh_areaSpecificSettings.BlackPointTable) = 0 Then

            Throw New PoliceGisException("Table """ & sh_areaSpecificSettings.BlackPointTable & " for thematic layer does not contain any records.")

        End If

        AnalysisCommon.ShadeMapWithGraduatedValues( _
                                    sh_mapWindowHandle, _
                                    sh_areaSpecificSettings.NumberIncidentsField, _
                                    sh_areaSpecificSettings.BlackPointTable, _
                                    MapBasicConstants.RED)

        AnalysisCommon.SetLegend(String.Format("{0} {1}", My.Resources.Legend, sh_areaSpecificSettings.NumberIncidentsField), _
                                                    "Prev", True, True, True, False, _
                                                    sh_uniqueColumnValuesTheme, _
                                                    sh_mapWindowHandle, _
                                                    "Ascending on")

    End Sub

    Private Shared Sub ShadeMapWithPies()

        sh_uniqueColumnValuesTheme = MIColumnProxy.GetUniqueValues(sh_areaSpecificSettings.islpTable, sh_columnForPie)

        If MITableProxy.IsTabFileOpen(sh_areaSpecificSettings.PieFile) Then
            MITableProxy.CloseTable(sh_areaSpecificSettings.PieTable, False)
        End If

        MITableProxy.SaveTableAs(sh_areaSpecificSettings.BlackPointTable, sh_areaSpecificSettings.PieFile, False)
        MITableProxy.OpenTableChecked(sh_areaSpecificSettings.PieTable, sh_areaSpecificSettings.PieFile)

        AnalysisCommon.CreatePieChartData(sh_areaSpecificSettings, _
                                            sh_columnForPie, _
                                            sh_uniqueColumnValuesTheme)

        For cl = 0 To sh_uniqueColumnValuesTheme.Count - 1

            Dim newCol = "CountOfColumnValues" & cl

            MITableProxy.AddColumn(sh_areaSpecificSettings.BlackPointTable, newCol, "Integer", False)

            MITableProxy.SaveTable(sh_areaSpecificSettings.BlackPointTable)

        Next

        Dim queryString As New StringBuilder

        With queryString
            .Append("Select Count(*) from ")
            .Append(sh_areaSpecificSettings.PieTable)
            .Append(" where Not ( ")

            For valIdx As Integer = 0 To sh_uniqueColumnValuesTheme.Count - 1
                If valIdx <> sh_uniqueColumnValuesTheme.Count - 1 Then
                    .Append(String.Format("( CountOfColumnValues{0} = 0 ) AND ", valIdx))
                Else
                    .Append(String.Format("( CountOfColumnValues{0} = 0 ) ) ", valIdx))
                End If

            Next
            .Append(" INTO AccidentsCount")
        End With

        MapBasicInterop.ExecuteCommand(queryString.ToString)

        If Integer.Parse(MapBasicInterop.Evaluate("AccidentsCount.COL1")) = 0 Then
            MessageBox.Show(My.Resources.NoIncidentsFound, "Incidents")
        End If

        ' Sanitycheck: In some cases the buffer may be empty. We can't continue creating 
        If MITableProxy.GetRowCount(sh_areaSpecificSettings.PieTable) = 0 Then

            MessageBox.Show("Table """ & sh_areaSpecificSettings.PieTable & " for thematic layer does not contain any records.")

        End If

        AnalysisCommon.ShadeMapWithPies(sh_mapWindowHandle, sh_areaSpecificSettings.PieTable, sh_uniqueColumnValuesTheme.Count)

        AnalysisCommon.SetLegend(String.Format("{0} {1}", My.Resources.Legend, sh_columnForPie), "Prev", True, True, True, False, sh_uniqueColumnValuesTheme, sh_mapWindowHandle, "Ascending on")

    End Sub


    Public Shared Sub SaveBlackPointTable()

        If MIWindowProxy.FrontWindow() <> sh_mapWindowHandle Then
            Throw New PoliceGisException(My.Resources.ExceptionMessages.BlackPointWindowNotSelected)
        End If

        MapBasicInterop.ExecuteCommand(String.Format("Set CoordSys {0}", CoreLibConstants.CS_LAMBERT_1972))

        Dim saveForm As New FormSaveTable ' Retrieve buffer distance form user.


        If saveForm.ShowDialog = DialogResult.OK Then

            MITableProxy.SaveTableTo(sh_areaSpecificSettings.BlackPointTable, New FileInfo(saveForm.TextBoxNaam.Text), False)

        End If


    End Sub

    Public Shared Function CheckBlackPointTable(ByVal table As String) As Boolean
        Dim validTable As Boolean = True
        Dim columnList As New List(Of String)
        columnList.Add("xcoord")
        columnList.Add("ycoord")
        columnList.Add("bufdist")
        columnList.Add("id")
        For Each cname In columnList
            If Not MITableProxy.ListColumnNames(table).Contains(cname) Then
                validTable = False
            End If
        Next

        Dim objecttype = MapBasicInterop.Evaluate(String.Format("ObjectInfo({0}.obj, 1)", table))
        If CShort(objecttype) <> MapBasicConstants.OBJ_TYPE_REGION Then
            validTable = False
        End If

        Return validTable
    End Function

End Class
