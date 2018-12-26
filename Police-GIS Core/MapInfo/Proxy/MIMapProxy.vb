Option Strict On

Imports System.Text

Public Class MIMapProxy

    Public Shared Sub AddLayer(ByVal layerName As String, ByVal auto As Boolean)

        Dim command As New StringBuilder
        command.Append("Add Map ")

        If auto Then
            command.Append("Auto ")
        End If

        command.Append("Layer ")
        command.Append(layerName)

        MapBasicInterop.ExecuteCommand(command.ToString)

    End Sub

    Public Shared Sub RemoveLayer(ByVal layerName As String, ByVal interactive As Boolean)

        Dim command As New StringBuilder
        command.Append("Remove Map Layer ")
        command.Append(layerName)
        If interactive Then
            command.Append(" Interactive")
        End If
        MapBasicInterop.ExecuteCommand(command.ToString)

    End Sub

    Public Shared Sub SetRedrawOn()
        MapBasicInterop.ExecuteCommand("Set map redraw on")
    End Sub

    Public Shared Sub SetRedrawOff()
        MapBasicInterop.ExecuteCommand("Set map redraw off")
    End Sub

End Class
