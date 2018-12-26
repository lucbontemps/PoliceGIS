
Imports Gim.PoliceGis.Core
Imports Gim.ErrorHandling

Public Class StartAnalysisAction
    Inherits GenericOpenFormAction(Of FormAnalysis)

    ' StartTrafficAnalysis() is just a another name for StartController
    ' But it needs to be a unique name so MapBasic can distinguish 
    ' different .NET methods

    Public Shared Sub StartTrafficAnalysis()
        Try

            StartController()

            If GetInstance.MForm IsNot Nothing Then
                GetInstance.MForm.IsCrimeAnalysis = False
                GetInstance.MForm.Text = My.Resources.trafficAnalysysHeader
                GetInstance.MForm.Show()
            End If

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    ' StartCrimeAnalysis() is just a another name for StartController
    ' But it needs to be a unique name so MapBasic can distinguish 
    ' different .NET methods
    Public Shared Sub StartCrimeAnalysis()
        Try
            StartController()

            If GetInstance.MForm IsNot Nothing Then

                GetInstance.MForm.IsCrimeAnalysis = True
                GetInstance.MForm.Text = My.Resources.criminaAnalysiHeader
                GetInstance.MForm.Show()

            End If

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

End Class
