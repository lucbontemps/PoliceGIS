' System namespaces
Imports System.Windows.Forms
Imports System.Xml.Schema
' Gim namespaces
Imports Gim.ErrorHandling
Imports Gim.PoliceGis.Core

Imports <xmlns="http://schemas.gim.be/PoliceGIS/PoliceGisConfiguration.xsd">



Public Class GenericOpenFormAction(Of T As {System.Windows.Forms.Form, New})


    Private Shared sh_theInstance As GenericOpenFormAction(Of T)

    Public WithEvents MForm As T

    Public Sub New()
        MForm = Nothing
    End Sub


    Private Sub ShowForm()

        Dim pGISConfig As XDocument = XDocument.Load(PGISConfigurationManager.GetInstance.ConfigFile.FullName)

        If pGISConfig...<language>.Value.ToLower = "fr" Then
            Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("fr-BE")
        End If

        If MForm Is Nothing Then
            MForm = New T()
        End If
        If Not MForm.IsDisposed Then
            If MForm.Visible = True Then
                MForm.Refresh()
            Else
                MForm.Show()
            End If

            MForm.BringToFront()

        Else
            sh_theInstance = Nothing
        End If



    End Sub

    Public Shared Function GetInstance() As GenericOpenFormAction(Of T)

        If sh_theInstance Is Nothing Then
            sh_theInstance = New GenericOpenFormAction(Of T)
        End If

        Return sh_theInstance

    End Function


    Public Shared Sub StartController()

        Dim instance As GenericOpenFormAction(Of T) = GetInstance()
        instance.ShowForm()

    End Sub


    Private Sub m_form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MForm.FormClosed
        Try
            MForm.Dispose()
            MForm = Nothing
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

End Class
