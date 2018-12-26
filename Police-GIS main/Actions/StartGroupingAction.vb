
Imports Gim.ErrorHandling
Imports Gim.PoliceGis.Core

Public Class StartGroupingAction
    Inherits GenericOpenFormAction(Of FormCreateGroups)


    ' StartGrouping() is just a another name for StartController
    ' But it needs to be a unique name so MapBasic can distinguish 
    ' different .NET methods
    Public Shared Sub StartGrouping()
        Try
            StartController()
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

End Class
