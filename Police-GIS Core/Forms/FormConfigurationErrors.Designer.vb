<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConfigurationErrors
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConfigurationErrors))
        Me.ErrorsGroupBox = New System.Windows.Forms.GroupBox
        Me.FoutenTextBox = New System.Windows.Forms.TextBox
        Me.LabelExplanation = New System.Windows.Forms.Label
        Me.OKButton = New System.Windows.Forms.Button
        Me.ErrorsGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ErrorsGroupBox
        '
        Me.ErrorsGroupBox.AccessibleDescription = Nothing
        Me.ErrorsGroupBox.AccessibleName = Nothing
        resources.ApplyResources(Me.ErrorsGroupBox, "ErrorsGroupBox")
        Me.ErrorsGroupBox.BackgroundImage = Nothing
        Me.ErrorsGroupBox.Controls.Add(Me.FoutenTextBox)
        Me.ErrorsGroupBox.Font = Nothing
        Me.ErrorsGroupBox.Name = "ErrorsGroupBox"
        Me.ErrorsGroupBox.TabStop = False
        '
        'FoutenTextBox
        '
        Me.FoutenTextBox.AccessibleDescription = Nothing
        Me.FoutenTextBox.AccessibleName = Nothing
        resources.ApplyResources(Me.FoutenTextBox, "FoutenTextBox")
        Me.FoutenTextBox.BackgroundImage = Nothing
        Me.FoutenTextBox.Font = Nothing
        Me.FoutenTextBox.Name = "FoutenTextBox"
        '
        'LabelExplanation
        '
        Me.LabelExplanation.AccessibleDescription = Nothing
        Me.LabelExplanation.AccessibleName = Nothing
        resources.ApplyResources(Me.LabelExplanation, "LabelExplanation")
        Me.LabelExplanation.Font = Nothing
        Me.LabelExplanation.Name = "LabelExplanation"
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
        'FormConfigurationErrors
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.ErrorsGroupBox)
        Me.Controls.Add(Me.LabelExplanation)
        Me.Controls.Add(Me.OKButton)
        Me.Font = Nothing
        Me.Name = "FormConfigurationErrors"
        Me.ErrorsGroupBox.ResumeLayout(False)
        Me.ErrorsGroupBox.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ErrorsGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents FoutenTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LabelExplanation As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
End Class
