Option Strict On

Imports System.Globalization

Imports Gim.ErrorHandling


Public Class FormGetBuffer


    ReadOnly Property BufferSize() As Double
        Get
            Return Decimal.ToDouble(BufferSizeNumericUD.Value)
        End Get
    End Property

    Private Sub AnnuleerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnuleerButton.Click

        Try

            DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click

    End Sub
    Private Sub BufferSizeNumericUD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BufferSizeNumericUD.ValueChanged

    End Sub
    Private Sub BufferLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BufferLabel.Click

    End Sub
End Class