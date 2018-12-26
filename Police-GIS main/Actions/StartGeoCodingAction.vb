Imports Gim.PoliceGis.Core
Imports Gim.ErrorHandling

Public Class StartGeoCodingAction
    Inherits GenericOpenFormAction(Of FormGeoCoding)

    Public Shared Sub StartGeoCoding()
        Try
            StartController()
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


End Class
