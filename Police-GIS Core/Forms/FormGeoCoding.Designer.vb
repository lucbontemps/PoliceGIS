<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGeoCoding
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormGeoCoding))
        Me.InputLabel = New System.Windows.Forms.Label()
        Me.TextBoxFileToImport = New System.Windows.Forms.TextBox()
        Me.BrowseToFileButton = New System.Windows.Forms.Button()
        Me.ImportFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.GeocodingTabControl = New System.Windows.Forms.TabControl()
        Me.KolomNamenTabPage = New System.Windows.Forms.TabPage()
        Me.MyGeocodingFieldsControl = New Gim.PoliceGis.Core.PickGeocodingFieldsControl()
        Me.DatatypesTabPage = New System.Windows.Forms.TabPage()
        Me.MyColumnTypesEditor = New Gim.PoliceGis.Core.ChangeDataTypesControl()
        Me.OutputTabelTextBox = New System.Windows.Forms.TextBox()
        Me.OutputLabel = New System.Windows.Forms.Label()
        Me.StartButton = New System.Windows.Forms.Button()
        Me.AnnuleerButton = New System.Windows.Forms.Button()
        Me.MyErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PreviewButton = New System.Windows.Forms.Button()
        Me.GeocodingTabControl.SuspendLayout()
        Me.KolomNamenTabPage.SuspendLayout()
        Me.DatatypesTabPage.SuspendLayout()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'InputLabel
        '
        resources.ApplyResources(Me.InputLabel, "InputLabel")
        Me.MyErrorProvider.SetError(Me.InputLabel, resources.GetString("InputLabel.Error"))
        Me.MyErrorProvider.SetIconAlignment(Me.InputLabel, CType(resources.GetObject("InputLabel.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.InputLabel, CType(resources.GetObject("InputLabel.IconPadding"), Integer))
        Me.InputLabel.Name = "InputLabel"
        '
        'TextBoxFileToImport
        '
        resources.ApplyResources(Me.TextBoxFileToImport, "TextBoxFileToImport")
        Me.MyErrorProvider.SetError(Me.TextBoxFileToImport, resources.GetString("TextBoxFileToImport.Error"))
        Me.MyErrorProvider.SetIconAlignment(Me.TextBoxFileToImport, CType(resources.GetObject("TextBoxFileToImport.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.TextBoxFileToImport, CType(resources.GetObject("TextBoxFileToImport.IconPadding"), Integer))
        Me.TextBoxFileToImport.Name = "TextBoxFileToImport"
        '
        'BrowseToFileButton
        '
        resources.ApplyResources(Me.BrowseToFileButton, "BrowseToFileButton")
        Me.MyErrorProvider.SetError(Me.BrowseToFileButton, resources.GetString("BrowseToFileButton.Error"))
        Me.MyErrorProvider.SetIconAlignment(Me.BrowseToFileButton, CType(resources.GetObject("BrowseToFileButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.BrowseToFileButton, CType(resources.GetObject("BrowseToFileButton.IconPadding"), Integer))
        Me.BrowseToFileButton.Image = Global.Gim.PoliceGis.Core.My.Resources.Resources.openfolderHS
        Me.BrowseToFileButton.Name = "BrowseToFileButton"
        Me.BrowseToFileButton.UseVisualStyleBackColor = True
        '
        'ImportFileDialog
        '
        Me.ImportFileDialog.FileName = "OpenFileDialog1"
        resources.ApplyResources(Me.ImportFileDialog, "ImportFileDialog")
        '
        'GeocodingTabControl
        '
        resources.ApplyResources(Me.GeocodingTabControl, "GeocodingTabControl")
        Me.GeocodingTabControl.Controls.Add(Me.KolomNamenTabPage)
        Me.GeocodingTabControl.Controls.Add(Me.DatatypesTabPage)
        Me.MyErrorProvider.SetError(Me.GeocodingTabControl, resources.GetString("GeocodingTabControl.Error"))
        Me.MyErrorProvider.SetIconAlignment(Me.GeocodingTabControl, CType(resources.GetObject("GeocodingTabControl.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.GeocodingTabControl, CType(resources.GetObject("GeocodingTabControl.IconPadding"), Integer))
        Me.GeocodingTabControl.Name = "GeocodingTabControl"
        Me.GeocodingTabControl.SelectedIndex = 0
        '
        'KolomNamenTabPage
        '
        resources.ApplyResources(Me.KolomNamenTabPage, "KolomNamenTabPage")
        Me.KolomNamenTabPage.Controls.Add(Me.MyGeocodingFieldsControl)
        Me.MyErrorProvider.SetError(Me.KolomNamenTabPage, resources.GetString("KolomNamenTabPage.Error"))
        Me.MyErrorProvider.SetIconAlignment(Me.KolomNamenTabPage, CType(resources.GetObject("KolomNamenTabPage.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.KolomNamenTabPage, CType(resources.GetObject("KolomNamenTabPage.IconPadding"), Integer))
        Me.KolomNamenTabPage.Name = "KolomNamenTabPage"
        Me.KolomNamenTabPage.UseVisualStyleBackColor = True
        '
        'MyGeocodingFieldsControl
        '
        resources.ApplyResources(Me.MyGeocodingFieldsControl, "MyGeocodingFieldsControl")
        Me.MyGeocodingFieldsControl.AllFieldsReady = False
        Me.MyErrorProvider.SetError(Me.MyGeocodingFieldsControl, resources.GetString("MyGeocodingFieldsControl.Error"))
        Me.MyGeocodingFieldsControl.Fields = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.MyGeocodingFieldsControl, CType(resources.GetObject("MyGeocodingFieldsControl.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.MyGeocodingFieldsControl, CType(resources.GetObject("MyGeocodingFieldsControl.IconPadding"), Integer))
        Me.MyGeocodingFieldsControl.MaxStreetLength = 0
        Me.MyGeocodingFieldsControl.MiGeocodingFields = Nothing
        Me.MyGeocodingFieldsControl.Name = "MyGeocodingFieldsControl"
        '
        'DatatypesTabPage
        '
        resources.ApplyResources(Me.DatatypesTabPage, "DatatypesTabPage")
        Me.DatatypesTabPage.Controls.Add(Me.MyColumnTypesEditor)
        Me.MyErrorProvider.SetError(Me.DatatypesTabPage, resources.GetString("DatatypesTabPage.Error"))
        Me.MyErrorProvider.SetIconAlignment(Me.DatatypesTabPage, CType(resources.GetObject("DatatypesTabPage.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.DatatypesTabPage, CType(resources.GetObject("DatatypesTabPage.IconPadding"), Integer))
        Me.DatatypesTabPage.Name = "DatatypesTabPage"
        Me.DatatypesTabPage.UseVisualStyleBackColor = True
        '
        'MyColumnTypesEditor
        '
        resources.ApplyResources(Me.MyColumnTypesEditor, "MyColumnTypesEditor")
        Me.MyErrorProvider.SetError(Me.MyColumnTypesEditor, resources.GetString("MyColumnTypesEditor.Error"))
        Me.MyErrorProvider.SetIconAlignment(Me.MyColumnTypesEditor, CType(resources.GetObject("MyColumnTypesEditor.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.MyColumnTypesEditor, CType(resources.GetObject("MyColumnTypesEditor.IconPadding"), Integer))
        Me.MyColumnTypesEditor.Name = "MyColumnTypesEditor"
        '
        'OutputTabelTextBox
        '
        resources.ApplyResources(Me.OutputTabelTextBox, "OutputTabelTextBox")
        Me.MyErrorProvider.SetError(Me.OutputTabelTextBox, resources.GetString("OutputTabelTextBox.Error"))
        Me.MyErrorProvider.SetIconAlignment(Me.OutputTabelTextBox, CType(resources.GetObject("OutputTabelTextBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.OutputTabelTextBox, CType(resources.GetObject("OutputTabelTextBox.IconPadding"), Integer))
        Me.OutputTabelTextBox.Name = "OutputTabelTextBox"
        '
        'OutputLabel
        '
        resources.ApplyResources(Me.OutputLabel, "OutputLabel")
        Me.MyErrorProvider.SetError(Me.OutputLabel, resources.GetString("OutputLabel.Error"))
        Me.MyErrorProvider.SetIconAlignment(Me.OutputLabel, CType(resources.GetObject("OutputLabel.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.OutputLabel, CType(resources.GetObject("OutputLabel.IconPadding"), Integer))
        Me.OutputLabel.Name = "OutputLabel"
        '
        'StartButton
        '
        resources.ApplyResources(Me.StartButton, "StartButton")
        Me.MyErrorProvider.SetError(Me.StartButton, resources.GetString("StartButton.Error"))
        Me.MyErrorProvider.SetIconAlignment(Me.StartButton, CType(resources.GetObject("StartButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.StartButton, CType(resources.GetObject("StartButton.IconPadding"), Integer))
        Me.StartButton.Name = "StartButton"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'AnnuleerButton
        '
        resources.ApplyResources(Me.AnnuleerButton, "AnnuleerButton")
        Me.MyErrorProvider.SetError(Me.AnnuleerButton, resources.GetString("AnnuleerButton.Error"))
        Me.MyErrorProvider.SetIconAlignment(Me.AnnuleerButton, CType(resources.GetObject("AnnuleerButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.AnnuleerButton, CType(resources.GetObject("AnnuleerButton.IconPadding"), Integer))
        Me.AnnuleerButton.Name = "AnnuleerButton"
        Me.AnnuleerButton.UseVisualStyleBackColor = True
        '
        'MyErrorProvider
        '
        Me.MyErrorProvider.ContainerControl = Me
        resources.ApplyResources(Me.MyErrorProvider, "MyErrorProvider")
        '
        'PreviewButton
        '
        resources.ApplyResources(Me.PreviewButton, "PreviewButton")
        Me.MyErrorProvider.SetError(Me.PreviewButton, resources.GetString("PreviewButton.Error"))
        Me.MyErrorProvider.SetIconAlignment(Me.PreviewButton, CType(resources.GetObject("PreviewButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.PreviewButton, CType(resources.GetObject("PreviewButton.IconPadding"), Integer))
        Me.PreviewButton.Name = "PreviewButton"
        Me.PreviewButton.UseVisualStyleBackColor = True
        '
        'FormGeoCoding
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.PreviewButton)
        Me.Controls.Add(Me.AnnuleerButton)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.OutputLabel)
        Me.Controls.Add(Me.OutputTabelTextBox)
        Me.Controls.Add(Me.GeocodingTabControl)
        Me.Controls.Add(Me.BrowseToFileButton)
        Me.Controls.Add(Me.TextBoxFileToImport)
        Me.Controls.Add(Me.InputLabel)
        Me.Name = "FormGeoCoding"
        Me.GeocodingTabControl.ResumeLayout(False)
        Me.KolomNamenTabPage.ResumeLayout(False)
        Me.DatatypesTabPage.ResumeLayout(False)
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InputLabel As System.Windows.Forms.Label
    Friend WithEvents TextBoxFileToImport As System.Windows.Forms.TextBox
    Friend WithEvents BrowseToFileButton As System.Windows.Forms.Button
    Friend WithEvents ImportFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents GeocodingTabControl As System.Windows.Forms.TabControl
    Friend WithEvents KolomNamenTabPage As System.Windows.Forms.TabPage
    Friend WithEvents DatatypesTabPage As System.Windows.Forms.TabPage
    Friend WithEvents MyGeocodingFieldsControl As Gim.PoliceGis.Core.PickGeocodingFieldsControl
    Friend WithEvents OutputTabelTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OutputLabel As System.Windows.Forms.Label
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents AnnuleerButton As System.Windows.Forms.Button
    Friend WithEvents MyColumnTypesEditor As Gim.PoliceGis.Core.ChangeDataTypesControl
    Friend WithEvents MyErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents PreviewButton As System.Windows.Forms.Button
End Class
