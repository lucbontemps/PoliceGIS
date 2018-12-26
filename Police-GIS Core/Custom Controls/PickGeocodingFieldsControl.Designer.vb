<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PickGeocodingFieldsControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PickGeocodingFieldsControl))
        Me.StreetLabel = New System.Windows.Forms.Label()
        Me.NumberLabel = New System.Windows.Forms.Label()
        Me.CityLabel = New System.Windows.Forms.Label()
        Me.IntersectionCheckBox = New System.Windows.Forms.CheckBox()
        Me.HectoMeterCheckBox = New System.Windows.Forms.CheckBox()
        Me.MaxStreetLengthCheckBox = New System.Windows.Forms.CheckBox()
        Me.StandardValuesButton = New System.Windows.Forms.Button()
        Me.StreetComboBox = New System.Windows.Forms.ComboBox()
        Me.NumberComboBox = New System.Windows.Forms.ComboBox()
        Me.CityComboBox = New System.Windows.Forms.ComboBox()
        Me.IntersectionComboBox = New System.Windows.Forms.ComboBox()
        Me.HectometerComboBox = New System.Windows.Forms.ComboBox()
        Me.StreetFoundLabel = New System.Windows.Forms.Label()
        Me.NumberFoundLabel = New System.Windows.Forms.Label()
        Me.CityFoundLabel = New System.Windows.Forms.Label()
        Me.IntersectionFoundLabel = New System.Windows.Forms.Label()
        Me.HectometerFoundLabel = New System.Windows.Forms.Label()
        Me.MaxStreetLengthNumericUD = New System.Windows.Forms.NumericUpDown()
        CType(Me.MaxStreetLengthNumericUD, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StreetLabel
        '
        resources.ApplyResources(Me.StreetLabel, "StreetLabel")
        Me.StreetLabel.Name = "StreetLabel"
        '
        'NumberLabel
        '
        resources.ApplyResources(Me.NumberLabel, "NumberLabel")
        Me.NumberLabel.Name = "NumberLabel"
        '
        'CityLabel
        '
        resources.ApplyResources(Me.CityLabel, "CityLabel")
        Me.CityLabel.Name = "CityLabel"
        '
        'IntersectionCheckBox
        '
        resources.ApplyResources(Me.IntersectionCheckBox, "IntersectionCheckBox")
        Me.IntersectionCheckBox.Name = "IntersectionCheckBox"
        Me.IntersectionCheckBox.UseVisualStyleBackColor = True
        '
        'HectoMeterCheckBox
        '
        resources.ApplyResources(Me.HectoMeterCheckBox, "HectoMeterCheckBox")
        Me.HectoMeterCheckBox.Name = "HectoMeterCheckBox"
        Me.HectoMeterCheckBox.UseVisualStyleBackColor = True
        '
        'MaxStreetLengthCheckBox
        '
        resources.ApplyResources(Me.MaxStreetLengthCheckBox, "MaxStreetLengthCheckBox")
        Me.MaxStreetLengthCheckBox.Name = "MaxStreetLengthCheckBox"
        Me.MaxStreetLengthCheckBox.UseVisualStyleBackColor = True
        '
        'StandardValuesButton
        '
        resources.ApplyResources(Me.StandardValuesButton, "StandardValuesButton")
        Me.StandardValuesButton.Name = "StandardValuesButton"
        Me.StandardValuesButton.UseVisualStyleBackColor = True
        '
        'StreetComboBox
        '
        Me.StreetComboBox.FormattingEnabled = True
        resources.ApplyResources(Me.StreetComboBox, "StreetComboBox")
        Me.StreetComboBox.Name = "StreetComboBox"
        '
        'NumberComboBox
        '
        Me.NumberComboBox.FormattingEnabled = True
        resources.ApplyResources(Me.NumberComboBox, "NumberComboBox")
        Me.NumberComboBox.Name = "NumberComboBox"
        '
        'CityComboBox
        '
        Me.CityComboBox.FormattingEnabled = True
        resources.ApplyResources(Me.CityComboBox, "CityComboBox")
        Me.CityComboBox.Name = "CityComboBox"
        '
        'IntersectionComboBox
        '
        resources.ApplyResources(Me.IntersectionComboBox, "IntersectionComboBox")
        Me.IntersectionComboBox.FormattingEnabled = True
        Me.IntersectionComboBox.Name = "IntersectionComboBox"
        '
        'HectometerComboBox
        '
        resources.ApplyResources(Me.HectometerComboBox, "HectometerComboBox")
        Me.HectometerComboBox.FormattingEnabled = True
        Me.HectometerComboBox.Name = "HectometerComboBox"
        '
        'StreetFoundLabel
        '
        resources.ApplyResources(Me.StreetFoundLabel, "StreetFoundLabel")
        Me.StreetFoundLabel.Name = "StreetFoundLabel"
        '
        'NumberFoundLabel
        '
        resources.ApplyResources(Me.NumberFoundLabel, "NumberFoundLabel")
        Me.NumberFoundLabel.Name = "NumberFoundLabel"
        '
        'CityFoundLabel
        '
        resources.ApplyResources(Me.CityFoundLabel, "CityFoundLabel")
        Me.CityFoundLabel.Name = "CityFoundLabel"
        '
        'IntersectionFoundLabel
        '
        resources.ApplyResources(Me.IntersectionFoundLabel, "IntersectionFoundLabel")
        Me.IntersectionFoundLabel.Name = "IntersectionFoundLabel"
        '
        'HectometerFoundLabel
        '
        resources.ApplyResources(Me.HectometerFoundLabel, "HectometerFoundLabel")
        Me.HectometerFoundLabel.Name = "HectometerFoundLabel"
        '
        'MaxStreetLengthNumericUD
        '
        Me.MaxStreetLengthNumericUD.Increment = New Decimal(New Integer() {10, 0, 0, 0})
        resources.ApplyResources(Me.MaxStreetLengthNumericUD, "MaxStreetLengthNumericUD")
        Me.MaxStreetLengthNumericUD.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.MaxStreetLengthNumericUD.Name = "MaxStreetLengthNumericUD"
        '
        'PickGeocodingFieldsControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.MaxStreetLengthNumericUD)
        Me.Controls.Add(Me.HectometerFoundLabel)
        Me.Controls.Add(Me.IntersectionFoundLabel)
        Me.Controls.Add(Me.CityFoundLabel)
        Me.Controls.Add(Me.NumberFoundLabel)
        Me.Controls.Add(Me.StreetFoundLabel)
        Me.Controls.Add(Me.HectometerComboBox)
        Me.Controls.Add(Me.IntersectionComboBox)
        Me.Controls.Add(Me.CityComboBox)
        Me.Controls.Add(Me.NumberComboBox)
        Me.Controls.Add(Me.StreetComboBox)
        Me.Controls.Add(Me.StandardValuesButton)
        Me.Controls.Add(Me.MaxStreetLengthCheckBox)
        Me.Controls.Add(Me.HectoMeterCheckBox)
        Me.Controls.Add(Me.IntersectionCheckBox)
        Me.Controls.Add(Me.CityLabel)
        Me.Controls.Add(Me.NumberLabel)
        Me.Controls.Add(Me.StreetLabel)
        Me.Name = "PickGeocodingFieldsControl"
        CType(Me.MaxStreetLengthNumericUD, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StreetLabel As System.Windows.Forms.Label
    Friend WithEvents NumberLabel As System.Windows.Forms.Label
    Friend WithEvents CityLabel As System.Windows.Forms.Label
    Friend WithEvents IntersectionCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents HectoMeterCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents MaxStreetLengthCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents StandardValuesButton As System.Windows.Forms.Button
    Friend WithEvents StreetComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents NumberComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CityComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents IntersectionComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents HectometerComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents StreetFoundLabel As System.Windows.Forms.Label
    Friend WithEvents NumberFoundLabel As System.Windows.Forms.Label
    Friend WithEvents CityFoundLabel As System.Windows.Forms.Label
    Friend WithEvents IntersectionFoundLabel As System.Windows.Forms.Label
    Friend WithEvents HectometerFoundLabel As System.Windows.Forms.Label
    Friend WithEvents MaxStreetLengthNumericUD As System.Windows.Forms.NumericUpDown

End Class
