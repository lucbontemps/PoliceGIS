<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormGetBuffer
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormGetBuffer))
        Me.OKButton = New System.Windows.Forms.Button
        Me.AnnuleerButton = New System.Windows.Forms.Button
        Me.BufferLabel = New System.Windows.Forms.Label
        Me.MyErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BufferSizeNumericUD = New System.Windows.Forms.NumericUpDown
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BufferSizeNumericUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OKButton
        '
        Me.OKButton.AccessibleDescription = Nothing
        Me.OKButton.AccessibleName = Nothing
        resources.ApplyResources(Me.OKButton, "OKButton")
        Me.OKButton.BackgroundImage = Nothing
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.MyErrorProvider.SetError(Me.OKButton, resources.GetString("OKButton.Error"))
        Me.OKButton.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.OKButton, CType(resources.GetObject("OKButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.OKButton, CType(resources.GetObject("OKButton.IconPadding"), Integer))
        Me.OKButton.Name = "OKButton"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'AnnuleerButton
        '
        Me.AnnuleerButton.AccessibleDescription = Nothing
        Me.AnnuleerButton.AccessibleName = Nothing
        resources.ApplyResources(Me.AnnuleerButton, "AnnuleerButton")
        Me.AnnuleerButton.BackgroundImage = Nothing
        Me.AnnuleerButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.MyErrorProvider.SetError(Me.AnnuleerButton, resources.GetString("AnnuleerButton.Error"))
        Me.AnnuleerButton.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.AnnuleerButton, CType(resources.GetObject("AnnuleerButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.AnnuleerButton, CType(resources.GetObject("AnnuleerButton.IconPadding"), Integer))
        Me.AnnuleerButton.Name = "AnnuleerButton"
        Me.AnnuleerButton.UseVisualStyleBackColor = True
        '
        'BufferLabel
        '
        Me.BufferLabel.AccessibleDescription = Nothing
        Me.BufferLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.BufferLabel, "BufferLabel")
        Me.MyErrorProvider.SetError(Me.BufferLabel, resources.GetString("BufferLabel.Error"))
        Me.BufferLabel.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.BufferLabel, CType(resources.GetObject("BufferLabel.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.BufferLabel, CType(resources.GetObject("BufferLabel.IconPadding"), Integer))
        Me.BufferLabel.Name = "BufferLabel"
        '
        'MyErrorProvider
        '
        Me.MyErrorProvider.ContainerControl = Me
        resources.ApplyResources(Me.MyErrorProvider, "MyErrorProvider")
        '
        'BufferSizeNumericUD
        '
        Me.BufferSizeNumericUD.AccessibleDescription = Nothing
        Me.BufferSizeNumericUD.AccessibleName = Nothing
        resources.ApplyResources(Me.BufferSizeNumericUD, "BufferSizeNumericUD")
        Me.MyErrorProvider.SetError(Me.BufferSizeNumericUD, resources.GetString("BufferSizeNumericUD.Error"))
        Me.BufferSizeNumericUD.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.BufferSizeNumericUD, CType(resources.GetObject("BufferSizeNumericUD.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.BufferSizeNumericUD, CType(resources.GetObject("BufferSizeNumericUD.IconPadding"), Integer))
        Me.BufferSizeNumericUD.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.BufferSizeNumericUD.Name = "BufferSizeNumericUD"
        '
        'FormGetBuffer
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.BufferSizeNumericUD)
        Me.Controls.Add(Me.BufferLabel)
        Me.Controls.Add(Me.AnnuleerButton)
        Me.Controls.Add(Me.OKButton)
        Me.Font = Nothing
        Me.Name = "FormGetBuffer"
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BufferSizeNumericUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents AnnuleerButton As System.Windows.Forms.Button
    Friend WithEvents BufferLabel As System.Windows.Forms.Label
    Friend WithEvents MyErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents BufferSizeNumericUD As System.Windows.Forms.NumericUpDown
End Class
