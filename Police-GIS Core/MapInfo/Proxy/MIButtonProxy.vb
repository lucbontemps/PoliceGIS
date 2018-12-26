Option Strict On


Public Class MIButtonProxy


    Public Shared Sub Disable(ByVal id As Integer)

        MapBasicInterop.ExecuteCommand(String.Format("Alter Button ID {0} Disable", id))

    End Sub


    Public Shared Sub Enable(ByVal id As Integer)

        MapBasicInterop.ExecuteCommand(String.Format("Alter Button ID {0} Enable", id))

    End Sub
End Class
