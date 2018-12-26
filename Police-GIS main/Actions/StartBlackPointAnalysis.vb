Imports Gim.PoliceGis.Core

Public Class StartBlackPointAnalysis

    Public Shared Sub BlackPointToolHandler()
        Try
            BlackPointAnalysisController.BlackPointToolHandler(True)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub



    Public Shared Sub DrawPieChartsOnCrossRoads()
        Try
            BlackPointAnalysisController.DrawPieChartsOnCrossRoads()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Shared Sub ChangeBuffer()
        Try
            BlackPointAnalysisController.BlackPointToolHandler(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Public Shared Sub SaveTable()
        Try
            BlackPointAnalysisController.SaveBlackPointTable()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
End Class
