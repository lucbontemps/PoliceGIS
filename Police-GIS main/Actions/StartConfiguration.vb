Imports Gim.PoliceGis.Core
Imports Gim.ErrorHandling

' System namespaces
Imports System.Windows.Forms
Imports System.Xml.Schema

Imports <xmlns="http://schemas.gim.be/PoliceGIS/PoliceGisConfiguration.xsd">
Imports System.Runtime.InteropServices

Public Class StartConfiguration
    Inherits GenericOpenFormAction(Of FormConfiguration)

    Public Shared Sub StartConfiguration()
        Try
            StartController()
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Public Shared Function GetLanguage() As String

        Try

            Dim pGISConfig As XDocument = XDocument.Load(PGISConfigurationManager.GetInstance.ConfigFile.FullName)

            Return pGISConfig...<language>.Value.ToLower


        Catch ex As Exception

            GenericExceptionHandlingForm.ShowException(ex)

            Return ""
        End Try

    End Function
End Class
