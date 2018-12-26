Imports Gim.PoliceGis.Core
Imports System.Xml
Imports <xmlns="http://schemas.gim.be/PoliceGIS/PoliceGisConfiguration.xsd">
Public NotInheritable Class PoliceGISAboutBox

    Private Sub PoliceGISAboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim pGISConfig As XDocument = XDocument.Load(PGISConfigurationManager.GetInstance.ConfigFile.FullName)
        If pGISConfig...<language>.Value.ToLower = "fr" Then
            Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo("fr-BE")
        End If

        Me.Text = String.Format("About {0}", My.Resources.policeGIS)
        Me.LabelProductName.Text = My.Resources.policeGIS
        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        Me.LabelCopyright.Text = My.Application.Info.Copyright
        Me.LabelCompanyName.Text = My.Application.Info.CompanyName
        Me.TextBoxDescription.Text = My.Application.Info.Description

    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub

    Property EnableButton() As Boolean
        Get
            Return OKButton.Enabled
        End Get
        Set(ByVal value As Boolean)
            OKButton.Enabled = value
        End Set
    End Property

End Class
