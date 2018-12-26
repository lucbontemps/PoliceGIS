<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSaveTable
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSaveTable))
        Me.BufferLabel = New System.Windows.Forms.Label
        Me.AnnuleerButton = New System.Windows.Forms.Button
        Me.OKButton = New System.Windows.Forms.Button
        Me.TextBoxNaam = New System.Windows.Forms.TextBox
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog
        Me.OpenTabFileButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'BufferLabel
        '
        Me.BufferLabel.AccessibleDescription = Nothing
        Me.BufferLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.BufferLabel, "BufferLabel")
        Me.BufferLabel.Font = Nothing
        Me.BufferLabel.Name = "BufferLabel"
        '
        'AnnuleerButton
        '
        Me.AnnuleerButton.AccessibleDescription = Nothing
        Me.AnnuleerButton.AccessibleName = Nothing
        resources.ApplyResources(Me.AnnuleerButton, "AnnuleerButton")
        Me.AnnuleerButton.BackgroundImage = Nothing
        Me.AnnuleerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.AnnuleerButton.Font = Nothing
        Me.AnnuleerButton.Name = "AnnuleerButton"
        Me.AnnuleerButton.UseVisualStyleBackColor = True
        '
        'OKButton
        '
        Me.OKButton.AccessibleDescription = Nothing
        Me.OKButton.AccessibleName = Nothing
        resources.ApplyResources(Me.OKButton, "OKButton")
        Me.OKButton.BackgroundImage = Nothing
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OKButton.Font = Nothing
        Me.OKButton.Name = "OKButton"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'TextBoxNaam
        '
        Me.TextBoxNaam.AccessibleDescription = Nothing
        Me.TextBoxNaam.AccessibleName = Nothing
        resources.ApplyResources(Me.TextBoxNaam, "TextBoxNaam")
        Me.TextBoxNaam.BackgroundImage = Nothing
        Me.TextBoxNaam.Font = Nothing
        Me.TextBoxNaam.Name = "TextBoxNaam"
        Me.TextBoxNaam.ReadOnly = True
        '
        'SaveFileDialog1
        '
        resources.ApplyResources(Me.SaveFileDialog1, "SaveFileDialog1")
        '
        'OpenTabFileButton
        '
        Me.OpenTabFileButton.AccessibleDescription = Nothing
        Me.OpenTabFileButton.AccessibleName = Nothing
        resources.ApplyResources(Me.OpenTabFileButton, "OpenTabFileButton")
        Me.OpenTabFileButton.BackgroundImage = Nothing
        Me.OpenTabFileButton.Font = Nothing
        Me.OpenTabFileButton.Image = Global.Gim.PoliceGis.Core.My.Resources.Resources.openfolderHS
        Me.OpenTabFileButton.Name = "OpenTabFileButton"
        Me.OpenTabFileButton.UseVisualStyleBackColor = True
        '
        'FormSaveTable
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.OpenTabFileButton)
        Me.Controls.Add(Me.TextBoxNaam)
        Me.Controls.Add(Me.BufferLabel)
        Me.Controls.Add(Me.AnnuleerButton)
        Me.Controls.Add(Me.OKButton)
        Me.Font = Nothing
        Me.Name = "FormSaveTable"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BufferLabel As System.Windows.Forms.Label
    Friend WithEvents AnnuleerButton As System.Windows.Forms.Button
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents TextBoxNaam As System.Windows.Forms.TextBox
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents OpenTabFileButton As System.Windows.Forms.Button
End Class
