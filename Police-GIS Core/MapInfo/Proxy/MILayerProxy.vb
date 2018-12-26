Option Strict On

Imports System.Text

Public Class MILayerProxy

    Public Shared Function GetLayerInfo(ByVal windowID As Integer, ByVal layerIndex As Short, ByVal attribute As Short) As String

        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "LayerInfo( {0}, {1}, {2} )", windowID, layerIndex, attribute)
        Return MapBasicInterop.Evaluate(expression)

    End Function

    Public Shared Sub LabelOn(ByVal windowID As Integer, ByVal layerName As String)
        Dim expression = String.Format("Set Map Window {0}  Layer ""{1}"" Label Auto On", windowID, layerName)
        MapBasicInterop.ExecuteCommand(expression)
    End Sub

    Public Shared Sub LabelOff(ByVal windowID As Integer, ByVal layerName As String)
        Dim expression = String.Format("Set Map Window {0}  Layer ""{1}"" Label Auto Off", windowID, layerName)
        MapBasicInterop.ExecuteCommand(expression)
    End Sub

    Public Shared Sub LabelWith(ByVal windowID As Integer, ByVal layerName As String, ByVal field As String)
        Dim expression = String.Format("Set Map Window {0}  Layer ""{1}"" Label Font (""Arial"",256,9,0,16777215) With {2}", windowID, layerName, field)
        MapBasicInterop.ExecuteCommand(expression)
    End Sub

    Public Shared Function GetLayerID(ByVal windowID As Integer, ByVal layerName As String) As Short

        If windowID < 0 Then
            Throw ExceptionProvider.ArgumentOutOfRange("windowID", windowID, "WindowID < 0 not allowed.")
        End If

        If String.IsNullOrEmpty(layerName) Then
            Throw ExceptionProvider.NullOrEmptyArgException("layerName")
        End If

        Dim result As Short = 0
        Dim noLayers As Short = Short.Parse(MIWindowProxy.GetMapperInfo(windowID, MapBasicConstants.MAPPER_INFO_LAYERS))

        For lyr As Short = 1 To noLayers
            Dim nameCurrentLayer As String = GetLayerInfo(windowID, lyr, MapBasicConstants.LAYER_INFO_NAME)
            If (nameCurrentLayer.ToLower = layerName.ToLower) Then
                result = lyr
                Exit For
            End If
        Next

        Return result

    End Function


End Class
