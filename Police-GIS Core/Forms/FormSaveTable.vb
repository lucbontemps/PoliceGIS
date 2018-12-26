Option Strict On

Imports System.Globalization
Imports Gim.ErrorHandling

Public Class FormSaveTable

    Private Sub AnnuleerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnuleerButton.Click
        Try

            DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try
    End Sub

    Private Sub OpenTabFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenTabFileButton.Click


        SaveFileDialog1.Filter = "tab files (*.tab)|*.tab"

        SaveFileDialog1.RestoreDirectory = True


        Dim answer = SaveFileDialog1.ShowDialog

        If answer = Windows.Forms.DialogResult.OK Then

            If Not String.IsNullOrEmpty(SaveFileDialog1.FileName) Then

                TextBoxNaam.Text = SaveFileDialog1.FileName

            End If

        End If


    End Sub
End Class