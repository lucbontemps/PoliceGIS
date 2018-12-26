Option Strict On

Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Public Class MIWindowProxy

    Public Shared Function FrontWindow() As Integer
        Return Integer.Parse(MapBasicInterop.Evaluate("FrontWindow()"))
    End Function

    Public Shared Function GetWindowID(ByVal windowName As String) As Integer

        Dim winID As Integer
        Dim wnd As Integer

        ' ATTENTION: The default return code used to be 0 in the MapBasic version instead of -1.
        winID = -1
        Dim numWin As Integer = GetNumWindows()

        For wnd = 1 To numWin

            Dim currentWindow = GetWindowInfo(wnd, MapBasicConstants.WIN_INFO_NAME)

            If (currentWindow.ToLower = windowName.ToLower) Then
                winID = wnd
                Exit For
            End If

        Next

        Return winID

    End Function

    Public Shared Function GetWindowID(ByVal mapperWindowNum As Integer) As Integer
        Return Integer.Parse(MapBasicInterop.Evaluate(String.Format("WindowID({0})", mapperWindowNum)))
    End Function


    Public Shared Function GetNumWindows() As Short

        Return Short.Parse(MapBasicInterop.Evaluate("NumWindows()"))

    End Function


    Public Shared Function GetWindowInfo(ByVal windowID As Integer, ByVal attributeCode As Short) As String

        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "WindowInfo( {0} , {1} )", windowID, attributeCode)
        Return MapBasicInterop.Evaluate(expression)

    End Function

    Public Shared Function GetSessionInfo(ByVal attributeCode As Short) As String

        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "SessionInfo( {0})", attributeCode)
        Return MapBasicInterop.Evaluate(expression)

    End Function


    Public Shared Function GetWindowName(ByVal windowID As Integer) As String

        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "WindowInfo( {0} , {1} )", windowID, MapBasicConstants.WIN_INFO_NAME)
        Return MapBasicInterop.Evaluate(expression)

    End Function

    Public Shared Function GetWindowWidth(ByVal windowID As Integer) As Double

        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "WindowInfo( {0} , {1} )", windowID, MapBasicConstants.WIN_INFO_WIDTH)
        'MessageBox.Show(String.Format("getWindowWidth: {0}", expression))
        Return Double.Parse(MapBasicInterop.Evaluate(expression), MapBasicInterop.GetMapInfoNumFormat)

    End Function

    Public Shared Function GetWindowHeight(ByVal windowID As Integer) As Double

        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "WindowInfo( {0} , {1} )", windowID, MapBasicConstants.WIN_INFO_HEIGHT)
        Return Double.Parse(MapBasicInterop.Evaluate(expression), MapBasicInterop.GetMapInfoNumFormat)

    End Function

    Public Shared Function GetMapperInfo(ByVal windowID As Integer, ByVal attribute As Short) As String

        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "MapperInfo( {0}, {1} )", windowID, attribute)
        Return MapBasicInterop.Evaluate(expression)

    End Function

    Public Shared Function NumberOfLayers(ByVal windowID As Integer) As Short

        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "MapperInfo( {0}, {1} )", windowID, MapBasicConstants.MAPPER_INFO_LAYERS)
        Return Short.Parse(MapBasicInterop.Evaluate(expression))


    End Function

    Public Shared Function GetWindowType(ByVal windowID As Integer) As Short

        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "WindowInfo( {0} , {1} )", windowID, MapBasicConstants.WIN_INFO_TYPE)
        Return Short.Parse(MapBasicInterop.Evaluate(expression))

    End Function

    Public Shared Function GetLegendsMap(ByVal windowID As Integer) As Integer
        Return Integer.Parse(GetWindowInfo(windowID, MapBasicConstants.WIN_INFO_LEGENDS_MAP))
    End Function


    '''-------------------------------------------------------------------------------------------------
    ''' Finds the window ID of the top-most mapper window.
    '''-------------------------------------------------------------------------------------------------

    Public Shared Sub FindTopMapWindows(ByVal workspaceFile As String, _
                                        ByRef mapWindowID As Integer, _
                                        ByRef legendWindowID As Integer)



        If String.IsNullOrEmpty(workspaceFile) Then
            Throw ExceptionProvider.NullOrEmptyArgException("workspaceFile")
        End If

        Dim Bestand As New FileInfo(workspaceFile)

        If Not Bestand.Exists Then
            Throw ExceptionProvider.FileExistException("workspaceFile", workspaceFile)
        End If

        '
        ' Find the topmost mapper and legend windows and store their 
        ' handles (WindowID) so we can easily access the window later. 
        Dim originalMapname As String
        Dim mapperWindowNum As Short
        Dim legendWindowNum As Short
        Dim winType As Short
        Dim currentWindowName As String

        mapperWindowNum = getMapperWindow()

        If mapperWindowNum > 0 Then
            ' found
            mapWindowID = GetWindowID(mapperWindowNum)
        Else
            ' not found => Error ?
            mapWindowID = 0

        End If

        ' Try to find a legend window starting from the top window to the last window in the background.
        ' the legend should correspond to the mapper so we check for this link if possible
        originalMapname = GetWindowInfo(mapWindowID, MapBasicConstants.WIN_INFO_NAME)
        For legendWindowNum = GetNumWindows() To 0 Step -1

            winType = GetWindowType(legendWindowNum)
            currentWindowName = GetWindowInfo(legendWindowNum, MapBasicConstants.WIN_INFO_NAME)

            If (winType = MapBasicConstants.WIN_CART_LEGEND) Then
                If GetLegendsMap(legendWindowNum) = mapWindowID Then
                    Exit For
                End If
            End If

            If LCase$(currentWindowName) = LCase$("Legend of " & originalMapname) Then
                ' Found it: exit loop
                Exit For
            End If

        Next

        If legendWindowNum > 0 Then
            ' found it
            legendWindowID = GetWindowID(legendWindowNum)
        Else
            ' not found => Error ?
            legendWindowID = 0

        End If

    End Sub


    Public Shared Function getMapperWindow() As Short
        ' Try to find a mapper starting from the top window to the last window in the background
        Dim mapperWindowNum As Short
        Dim winType As Short

        For mapperWindowNum = GetNumWindows() To 0 Step -1
            winType = GetWindowType(mapperWindowNum)
            If (winType = MapBasicConstants.WIN_MAPPER) Then
                Exit For
            End If
        Next
        Return mapperWindowNum
    End Function


    '''-------------------------------------------------------------------
    ''' Arranges the mapper and legend window nicely.
    '''-------------------------------------------------------------------
    Public Shared Sub LayoutWindows(ByVal mapWindow As Integer, _
                                    ByVal legendWindow As Integer)

        Dim CommandBuilder As New StringBuilder
        Dim oldPaperUnits As String

        oldPaperUnits = GetSessionInfo(MapBasicConstants.SESSION_INFO_PAPER_UNITS)

        Dim maxWidth, maxHeight As Double
        Dim ratioWidthOfLegend As Double
        Dim widthLegend As Double
        Dim widthMap As Double
        Dim xLegend As Double
        Dim xMap As Double
        ' legend may take up 25 percent (1 quarter) of the widht of the screen.
        ratioWidthOfLegend = 0.25

        CommandBuilder.Append("Set Paper Units ""mm""")
        CommandBuilder.Append(Environment.NewLine)
        CommandBuilder.Append(String.Format("Set window {0} Max", mapWindow))

        MapBasicInterop.ExecuteCommand(CommandBuilder.ToString)

        ' Width is the width of the MapInfo application window
        ' Height is 80 percent of the height of the MapInfo application window
        ' There are menu bars and toolbars at the top of the MapInfo window, so 
        ' we take an educated guess that one fifth of the screen would be enough 
        ' room for the menus and toolbars.
        maxWidth = GetWindowWidth(mapWindow)
        maxHeight = 0.8 * GetWindowHeight(mapWindow)
        widthLegend = ratioWidthOfLegend * maxWidth

        ' Reserve 10 mm margin for vertical scrollbar on the right 
        ' and to prevent overlap with the legend window.
        widthMap = maxWidth - widthLegend - 10
        xLegend = 0
        xMap = maxWidth - widthMap - 8

        ' Update the window sizes and positions
        CommandBuilder = New StringBuilder
        CommandBuilder.Append(String.Format("Set window {0}  Restore", legendWindow))
        CommandBuilder.AppendLine()
        CommandBuilder.Append(String.Format(MapBasicInterop.GetMapInfoNumFormat, "Set window {0} Position({1}, 0)" & _
                                            " Width({2})" & _
                                            " Height({3})", _
                                            legendWindow, _
                                            xLegend, _
                                            widthLegend, _
                                            maxHeight))
        CommandBuilder.AppendLine()
        CommandBuilder.Append(String.Format("Set window {0} Restore", mapWindow))
        CommandBuilder.AppendLine()
        CommandBuilder.Append(String.Format(MapBasicInterop.GetMapInfoNumFormat, "Set window {0} Position({1}, 0)" & _
                                            " Width({2})" & _
                                            " Height({3})", _
                                             mapWindow, _
                                            xMap, _
                                            widthMap, _
                                            maxHeight))
        CommandBuilder.AppendLine()
        ' restore old paper units
        CommandBuilder.Append(String.Format("Set Paper Units ""{0}""", oldPaperUnits))
        MapBasicInterop.ExecuteCommand(CommandBuilder.ToString)


    End Sub


    Public Shared Sub ReparentLegendWindow(ByVal parentWindowID As Integer, ByVal legendWindow As Integer, ByVal closeLegendWindow As Boolean)

        Dim commandBuilder As New StringBuilder

        commandBuilder.Append(String.Format("Set Next Document Parent WindowInfo({0},{1}) Style 1", parentWindowID, MapBasicConstants.WIN_INFO_WND))
        commandBuilder.Append(Environment.NewLine)
        commandBuilder.Append(String.Format("Create Legend From Window {0}", parentWindowID))

        MapBasicInterop.ExecuteCommand(commandBuilder.ToString)

        If closeLegendWindow Then

            Close(legendWindow)

        End If

        SetFront(parentWindowID)
        SetMax(parentWindowID)


    End Sub

    Public Shared Sub SetMax(ByVal windowID As Integer)
        MapBasicInterop.ExecuteCommand(String.Format("Set Window {0} Max", windowID))
    End Sub

    Public Shared Sub SetFront(ByVal windowID As Integer)
        MapBasicInterop.ExecuteCommand(String.Format("Set Window {0} Front", windowID))
    End Sub

    Public Shared Sub AddLegendToFrame(ByVal windowID As Integer, ByVal frame As String)

        MIMapProxy.AddLayer(frame, False)
        MapBasicInterop.ExecuteCommand(String.Format("Add Cartographic Frame Window {0} Frame From Layer {1}", _
                                               windowID, frame))
    End Sub

    Public Shared Sub Rename(ByVal windowID As Integer, ByVal title As String)
        MapBasicInterop.ExecuteCommand(String.Format("Set Window {0} Title ""{1}""", windowID, title))
    End Sub

    Public Shared Sub Close(ByVal windowID As Integer)
        MapBasicInterop.ExecuteCommand(String.Format("Close Window {0}", windowID))
    End Sub

    Public Shared Sub OrderLayers(ByVal windowID As Integer, ByVal startPosition As Integer, ByVal endPosition As Integer)
        MapBasicInterop.ExecuteCommand(String.Format("Set Map Window {0} Order Layers {1} DestGroupLayer 0 Position {2}", windowID, startPosition, endPosition))
    End Sub
End Class
