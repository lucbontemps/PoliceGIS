
Imports Gim.PoliceGis.Core
Imports Gim.ErrorHandling

Public Class ShowAboutBoxAction
    Inherits GenericOpenFormAction(Of PoliceGISAboutBox)

    ' ShowAboutBox() is just a another name for StartController
    ' But it needs to be a unique name so MapBasic can distinguish 
    ' different .NET methods
    Public Shared Sub ShowAboutBox()
        Try
            StartController()
            GetInstance.MForm.Enabled = True
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Public Shared Sub ShowStartAboutBox()
        Try
            StartController()
            GetInstance.MForm.Enabled = False
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Public Shared Sub CloseAboutBox()
        Try
            GetInstance.MForm.Close()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub
End Class
