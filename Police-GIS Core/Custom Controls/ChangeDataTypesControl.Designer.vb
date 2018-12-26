<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangeDataTypesControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ChangeDataTypesControl))
        Me.ColumnsComboBox = New System.Windows.Forms.ComboBox
        Me.TypeComboBox = New System.Windows.Forms.ComboBox
        Me.ColumnLabel = New System.Windows.Forms.Label
        Me.TypeLabel = New System.Windows.Forms.Label
        Me.WidthLabel = New System.Windows.Forms.Label
        Me.DecimalsLabel = New System.Windows.Forms.Label
        Me.ChangeButton = New System.Windows.Forms.Button
        Me.WidthNumericUD = New System.Windows.Forms.NumericUpDown
        Me.DecimalPlacesNumericUD = New System.Windows.Forms.NumericUpDown
        Me.ColumnTypesGroupBox = New System.Windows.Forms.GroupBox
        Me.LabelType = New System.Windows.Forms.Label
        CType(Me.WidthNumericUD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DecimalPlacesNumericUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ColumnTypesGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ColumnsComboBox
        '
        Me.ColumnsComboBox.AccessibleDescription = Nothing
        Me.ColumnsComboBox.AccessibleName = Nothing
        resources.ApplyResources(Me.ColumnsComboBox, "ColumnsComboBox")
        Me.ColumnsComboBox.BackgroundImage = Nothing
        Me.ColumnsComboBox.Font = Nothing
        Me.ColumnsComboBox.FormattingEnabled = True
        Me.ColumnsComboBox.Name = "ColumnsComboBox"
        '
        'TypeComboBox
        '
        Me.TypeComboBox.AccessibleDescription = Nothing
        Me.TypeComboBox.AccessibleName = Nothing
        resources.ApplyResources(Me.TypeComboBox, "TypeComboBox")
        Me.TypeComboBox.BackgroundImage = Nothing
        Me.TypeComboBox.Font = Nothing
        Me.TypeComboBox.FormattingEnabled = True
        Me.TypeComboBox.Name = "TypeComboBox"
        '
        'ColumnLabel
        '
        Me.ColumnLabel.AccessibleDescription = Nothing
        Me.ColumnLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.ColumnLabel, "ColumnLabel")
        Me.ColumnLabel.Font = Nothing
        Me.ColumnLabel.Name = "ColumnLabel"
        '
        'TypeLabel
        '
        Me.TypeLabel.AccessibleDescription = Nothing
        Me.TypeLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.TypeLabel, "TypeLabel")
        Me.TypeLabel.Font = Nothing
        Me.TypeLabel.Name = "TypeLabel"
        '
        'WidthLabel
        '
        Me.WidthLabel.AccessibleDescription = Nothing
        Me.WidthLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.WidthLabel, "WidthLabel")
        Me.WidthLabel.Font = Nothing
        Me.WidthLabel.Name = "WidthLabel"
        '
        'DecimalsLabel
        '
        Me.DecimalsLabel.AccessibleDescription = Nothing
        Me.DecimalsLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.DecimalsLabel, "DecimalsLabel")
        Me.DecimalsLabel.Font = Nothing
        Me.DecimalsLabel.Name = "DecimalsLabel"
        '
        'ChangeButton
        '
        Me.ChangeButton.AccessibleDescription = Nothing
        Me.ChangeButton.AccessibleName = Nothing
        resources.ApplyResources(Me.ChangeButton, "ChangeButton")
        Me.ChangeButton.BackgroundImage = Nothing
        Me.ChangeButton.Font = Nothing
        Me.ChangeButton.Name = "ChangeButton"
        Me.ChangeButton.UseVisualStyleBackColor = True
        '
        'WidthNumericUD
        '
        Me.WidthNumericUD.AccessibleDescription = Nothing
        Me.WidthNumericUD.AccessibleName = Nothing
        resources.ApplyResources(Me.WidthNumericUD, "WidthNumericUD")
        Me.WidthNumericUD.Font = Nothing
        Me.WidthNumericUD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.WidthNumericUD.Name = "WidthNumericUD"
        '
        'DecimalPlacesNumericUD
        '
        Me.DecimalPlacesNumericUD.AccessibleDescription = Nothing
        Me.DecimalPlacesNumericUD.AccessibleName = Nothing
        resources.ApplyResources(Me.DecimalPlacesNumericUD, "DecimalPlacesNumericUD")
        Me.DecimalPlacesNumericUD.Font = Nothing
        Me.DecimalPlacesNumericUD.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.DecimalPlacesNumericUD.Name = "DecimalPlacesNumericUD"
        '
        'ColumnTypesGroupBox
        '
        Me.ColumnTypesGroupBox.AccessibleDescription = Nothing
        Me.ColumnTypesGroupBox.AccessibleName = Nothing
        resources.ApplyResources(Me.ColumnTypesGroupBox, "ColumnTypesGroupBox")
        Me.ColumnTypesGroupBox.BackgroundImage = Nothing
        Me.ColumnTypesGroupBox.Controls.Add(Me.LabelType)
        Me.ColumnTypesGroupBox.Controls.Add(Me.DecimalPlacesNumericUD)
        Me.ColumnTypesGroupBox.Controls.Add(Me.ColumnsComboBox)
        Me.ColumnTypesGroupBox.Controls.Add(Me.WidthNumericUD)
        Me.ColumnTypesGroupBox.Controls.Add(Me.TypeComboBox)
        Me.ColumnTypesGroupBox.Controls.Add(Me.ChangeButton)
        Me.ColumnTypesGroupBox.Controls.Add(Me.ColumnLabel)
        Me.ColumnTypesGroupBox.Controls.Add(Me.DecimalsLabel)
        Me.ColumnTypesGroupBox.Controls.Add(Me.TypeLabel)
        Me.ColumnTypesGroupBox.Controls.Add(Me.WidthLabel)
        Me.ColumnTypesGroupBox.Font = Nothing
        Me.ColumnTypesGroupBox.Name = "ColumnTypesGroupBox"
        Me.ColumnTypesGroupBox.TabStop = False
        '
        'LabelType
        '
        Me.LabelType.AccessibleDescription = Nothing
        Me.LabelType.AccessibleName = Nothing
        resources.ApplyResources(Me.LabelType, "LabelType")
        Me.LabelType.Font = Nothing
        Me.LabelType.Name = "LabelType"
        '
        'ChangeDataTypesControl
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.ColumnTypesGroupBox)
        Me.Font = Nothing
        Me.Name = "ChangeDataTypesControl"
        CType(Me.WidthNumericUD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DecimalPlacesNumericUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ColumnTypesGroupBox.ResumeLayout(False)
        Me.ColumnTypesGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ColumnsComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents TypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnLabel As System.Windows.Forms.Label
    Friend WithEvents TypeLabel As System.Windows.Forms.Label
    Friend WithEvents WidthLabel As System.Windows.Forms.Label
    Friend WithEvents DecimalsLabel As System.Windows.Forms.Label
    Friend WithEvents ChangeButton As System.Windows.Forms.Button
    Friend WithEvents WidthNumericUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents DecimalPlacesNumericUD As System.Windows.Forms.NumericUpDown
    Friend WithEvents ColumnTypesGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents LabelType As System.Windows.Forms.Label

End Class
