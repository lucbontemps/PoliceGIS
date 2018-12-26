<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SimpleQueryBuilder
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SimpleQueryBuilder))
        Me.SelectionGroupBox = New System.Windows.Forms.GroupBox
        Me.ClearQueryButton = New System.Windows.Forms.Button
        Me.NameResulLabel = New System.Windows.Forms.Label
        Me.OutputTableTextBox = New System.Windows.Forms.TextBox
        Me.DoQueryButton = New System.Windows.Forms.Button
        Me.PreviewButton = New System.Windows.Forms.Button
        Me.QueryStartLabel = New System.Windows.Forms.Label
        Me.QueryStringTextBox = New System.Windows.Forms.TextBox
        Me.SelectionParametersGroupBox = New System.Windows.Forms.GroupBox
        Me.AddValueButton = New System.Windows.Forms.Button
        Me.QueryValuesLabel = New System.Windows.Forms.Label
        Me.QueryValueComboBox = New System.Windows.Forms.ComboBox
        Me.AddOperatorButton = New System.Windows.Forms.Button
        Me.QueryOperatorLabel = New System.Windows.Forms.Label
        Me.QueryOperatorComboBox = New System.Windows.Forms.ComboBox
        Me.AddFieldButton = New System.Windows.Forms.Button
        Me.QueryFieldLabel = New System.Windows.Forms.Label
        Me.QueryFieldComboBox = New System.Windows.Forms.ComboBox
        Me.MyErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.SelectionGroupBox.SuspendLayout()
        Me.SelectionParametersGroupBox.SuspendLayout()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SelectionGroupBox
        '
        Me.SelectionGroupBox.AccessibleDescription = Nothing
        Me.SelectionGroupBox.AccessibleName = Nothing
        resources.ApplyResources(Me.SelectionGroupBox, "SelectionGroupBox")
        Me.SelectionGroupBox.BackgroundImage = Nothing
        Me.SelectionGroupBox.Controls.Add(Me.ClearQueryButton)
        Me.SelectionGroupBox.Controls.Add(Me.NameResulLabel)
        Me.SelectionGroupBox.Controls.Add(Me.OutputTableTextBox)
        Me.SelectionGroupBox.Controls.Add(Me.DoQueryButton)
        Me.SelectionGroupBox.Controls.Add(Me.PreviewButton)
        Me.SelectionGroupBox.Controls.Add(Me.QueryStartLabel)
        Me.SelectionGroupBox.Controls.Add(Me.QueryStringTextBox)
        Me.SelectionGroupBox.Controls.Add(Me.SelectionParametersGroupBox)
        Me.MyErrorProvider.SetError(Me.SelectionGroupBox, resources.GetString("SelectionGroupBox.Error"))
        Me.SelectionGroupBox.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.SelectionGroupBox, CType(resources.GetObject("SelectionGroupBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.SelectionGroupBox, CType(resources.GetObject("SelectionGroupBox.IconPadding"), Integer))
        Me.SelectionGroupBox.Name = "SelectionGroupBox"
        Me.SelectionGroupBox.TabStop = False
        '
        'ClearQueryButton
        '
        Me.ClearQueryButton.AccessibleDescription = Nothing
        Me.ClearQueryButton.AccessibleName = Nothing
        resources.ApplyResources(Me.ClearQueryButton, "ClearQueryButton")
        Me.ClearQueryButton.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.ClearQueryButton, resources.GetString("ClearQueryButton.Error"))
        Me.ClearQueryButton.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.ClearQueryButton, CType(resources.GetObject("ClearQueryButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.ClearQueryButton, CType(resources.GetObject("ClearQueryButton.IconPadding"), Integer))
        Me.ClearQueryButton.Name = "ClearQueryButton"
        Me.ClearQueryButton.UseVisualStyleBackColor = True
        '
        'NameResulLabel
        '
        Me.NameResulLabel.AccessibleDescription = Nothing
        Me.NameResulLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.NameResulLabel, "NameResulLabel")
        Me.MyErrorProvider.SetError(Me.NameResulLabel, resources.GetString("NameResulLabel.Error"))
        Me.NameResulLabel.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.NameResulLabel, CType(resources.GetObject("NameResulLabel.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.NameResulLabel, CType(resources.GetObject("NameResulLabel.IconPadding"), Integer))
        Me.NameResulLabel.Name = "NameResulLabel"
        '
        'OutputTableTextBox
        '
        Me.OutputTableTextBox.AccessibleDescription = Nothing
        Me.OutputTableTextBox.AccessibleName = Nothing
        resources.ApplyResources(Me.OutputTableTextBox, "OutputTableTextBox")
        Me.OutputTableTextBox.BackColor = System.Drawing.SystemColors.Window
        Me.OutputTableTextBox.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.OutputTableTextBox, resources.GetString("OutputTableTextBox.Error"))
        Me.OutputTableTextBox.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.OutputTableTextBox, CType(resources.GetObject("OutputTableTextBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.OutputTableTextBox, CType(resources.GetObject("OutputTableTextBox.IconPadding"), Integer))
        Me.OutputTableTextBox.Name = "OutputTableTextBox"
        '
        'DoQueryButton
        '
        Me.DoQueryButton.AccessibleDescription = Nothing
        Me.DoQueryButton.AccessibleName = Nothing
        resources.ApplyResources(Me.DoQueryButton, "DoQueryButton")
        Me.DoQueryButton.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.DoQueryButton, resources.GetString("DoQueryButton.Error"))
        Me.DoQueryButton.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.DoQueryButton, CType(resources.GetObject("DoQueryButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.DoQueryButton, CType(resources.GetObject("DoQueryButton.IconPadding"), Integer))
        Me.DoQueryButton.Name = "DoQueryButton"
        Me.DoQueryButton.UseVisualStyleBackColor = True
        '
        'PreviewButton
        '
        Me.PreviewButton.AccessibleDescription = Nothing
        Me.PreviewButton.AccessibleName = Nothing
        resources.ApplyResources(Me.PreviewButton, "PreviewButton")
        Me.PreviewButton.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.PreviewButton, resources.GetString("PreviewButton.Error"))
        Me.PreviewButton.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.PreviewButton, CType(resources.GetObject("PreviewButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.PreviewButton, CType(resources.GetObject("PreviewButton.IconPadding"), Integer))
        Me.PreviewButton.Name = "PreviewButton"
        Me.PreviewButton.UseVisualStyleBackColor = True
        '
        'QueryStartLabel
        '
        Me.QueryStartLabel.AccessibleDescription = Nothing
        Me.QueryStartLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.QueryStartLabel, "QueryStartLabel")
        Me.MyErrorProvider.SetError(Me.QueryStartLabel, resources.GetString("QueryStartLabel.Error"))
        Me.QueryStartLabel.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.QueryStartLabel, CType(resources.GetObject("QueryStartLabel.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.QueryStartLabel, CType(resources.GetObject("QueryStartLabel.IconPadding"), Integer))
        Me.QueryStartLabel.Name = "QueryStartLabel"
        '
        'QueryStringTextBox
        '
        Me.QueryStringTextBox.AccessibleDescription = Nothing
        Me.QueryStringTextBox.AccessibleName = Nothing
        Me.QueryStringTextBox.AllowDrop = True
        resources.ApplyResources(Me.QueryStringTextBox, "QueryStringTextBox")
        Me.QueryStringTextBox.BackColor = System.Drawing.SystemColors.Window
        Me.QueryStringTextBox.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.QueryStringTextBox, resources.GetString("QueryStringTextBox.Error"))
        Me.QueryStringTextBox.Font = Nothing
        Me.QueryStringTextBox.HideSelection = False
        Me.MyErrorProvider.SetIconAlignment(Me.QueryStringTextBox, CType(resources.GetObject("QueryStringTextBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.QueryStringTextBox, CType(resources.GetObject("QueryStringTextBox.IconPadding"), Integer))
        Me.QueryStringTextBox.Name = "QueryStringTextBox"
        '
        'SelectionParametersGroupBox
        '
        Me.SelectionParametersGroupBox.AccessibleDescription = Nothing
        Me.SelectionParametersGroupBox.AccessibleName = Nothing
        resources.ApplyResources(Me.SelectionParametersGroupBox, "SelectionParametersGroupBox")
        Me.SelectionParametersGroupBox.BackgroundImage = Nothing
        Me.SelectionParametersGroupBox.Controls.Add(Me.AddValueButton)
        Me.SelectionParametersGroupBox.Controls.Add(Me.QueryValuesLabel)
        Me.SelectionParametersGroupBox.Controls.Add(Me.QueryValueComboBox)
        Me.SelectionParametersGroupBox.Controls.Add(Me.AddOperatorButton)
        Me.SelectionParametersGroupBox.Controls.Add(Me.QueryOperatorLabel)
        Me.SelectionParametersGroupBox.Controls.Add(Me.QueryOperatorComboBox)
        Me.SelectionParametersGroupBox.Controls.Add(Me.AddFieldButton)
        Me.SelectionParametersGroupBox.Controls.Add(Me.QueryFieldLabel)
        Me.SelectionParametersGroupBox.Controls.Add(Me.QueryFieldComboBox)
        Me.MyErrorProvider.SetError(Me.SelectionParametersGroupBox, resources.GetString("SelectionParametersGroupBox.Error"))
        Me.SelectionParametersGroupBox.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.SelectionParametersGroupBox, CType(resources.GetObject("SelectionParametersGroupBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.SelectionParametersGroupBox, CType(resources.GetObject("SelectionParametersGroupBox.IconPadding"), Integer))
        Me.SelectionParametersGroupBox.Name = "SelectionParametersGroupBox"
        Me.SelectionParametersGroupBox.TabStop = False
        '
        'AddValueButton
        '
        Me.AddValueButton.AccessibleDescription = Nothing
        Me.AddValueButton.AccessibleName = Nothing
        resources.ApplyResources(Me.AddValueButton, "AddValueButton")
        Me.AddValueButton.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.AddValueButton, resources.GetString("AddValueButton.Error"))
        Me.AddValueButton.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.AddValueButton, CType(resources.GetObject("AddValueButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.AddValueButton, CType(resources.GetObject("AddValueButton.IconPadding"), Integer))
        Me.AddValueButton.Image = Global.Gim.PoliceGis.Core.My.Resources.Resources.Add16x16GreenLarge
        Me.AddValueButton.Name = "AddValueButton"
        Me.AddValueButton.UseVisualStyleBackColor = True
        '
        'QueryValuesLabel
        '
        Me.QueryValuesLabel.AccessibleDescription = Nothing
        Me.QueryValuesLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.QueryValuesLabel, "QueryValuesLabel")
        Me.MyErrorProvider.SetError(Me.QueryValuesLabel, resources.GetString("QueryValuesLabel.Error"))
        Me.QueryValuesLabel.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.QueryValuesLabel, CType(resources.GetObject("QueryValuesLabel.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.QueryValuesLabel, CType(resources.GetObject("QueryValuesLabel.IconPadding"), Integer))
        Me.QueryValuesLabel.Name = "QueryValuesLabel"
        '
        'QueryValueComboBox
        '
        Me.QueryValueComboBox.AccessibleDescription = Nothing
        Me.QueryValueComboBox.AccessibleName = Nothing
        resources.ApplyResources(Me.QueryValueComboBox, "QueryValueComboBox")
        Me.QueryValueComboBox.BackColor = System.Drawing.SystemColors.Window
        Me.QueryValueComboBox.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.QueryValueComboBox, resources.GetString("QueryValueComboBox.Error"))
        Me.QueryValueComboBox.Font = Nothing
        Me.QueryValueComboBox.FormattingEnabled = True
        Me.MyErrorProvider.SetIconAlignment(Me.QueryValueComboBox, CType(resources.GetObject("QueryValueComboBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.QueryValueComboBox, CType(resources.GetObject("QueryValueComboBox.IconPadding"), Integer))
        Me.QueryValueComboBox.Name = "QueryValueComboBox"
        '
        'AddOperatorButton
        '
        Me.AddOperatorButton.AccessibleDescription = Nothing
        Me.AddOperatorButton.AccessibleName = Nothing
        resources.ApplyResources(Me.AddOperatorButton, "AddOperatorButton")
        Me.AddOperatorButton.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.AddOperatorButton, resources.GetString("AddOperatorButton.Error"))
        Me.AddOperatorButton.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.AddOperatorButton, CType(resources.GetObject("AddOperatorButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.AddOperatorButton, CType(resources.GetObject("AddOperatorButton.IconPadding"), Integer))
        Me.AddOperatorButton.Image = Global.Gim.PoliceGis.Core.My.Resources.Resources.Add16x16GreenLarge
        Me.AddOperatorButton.Name = "AddOperatorButton"
        Me.AddOperatorButton.UseVisualStyleBackColor = True
        '
        'QueryOperatorLabel
        '
        Me.QueryOperatorLabel.AccessibleDescription = Nothing
        Me.QueryOperatorLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.QueryOperatorLabel, "QueryOperatorLabel")
        Me.MyErrorProvider.SetError(Me.QueryOperatorLabel, resources.GetString("QueryOperatorLabel.Error"))
        Me.QueryOperatorLabel.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.QueryOperatorLabel, CType(resources.GetObject("QueryOperatorLabel.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.QueryOperatorLabel, CType(resources.GetObject("QueryOperatorLabel.IconPadding"), Integer))
        Me.QueryOperatorLabel.Name = "QueryOperatorLabel"
        '
        'QueryOperatorComboBox
        '
        Me.QueryOperatorComboBox.AccessibleDescription = Nothing
        Me.QueryOperatorComboBox.AccessibleName = Nothing
        resources.ApplyResources(Me.QueryOperatorComboBox, "QueryOperatorComboBox")
        Me.QueryOperatorComboBox.BackColor = System.Drawing.SystemColors.Window
        Me.QueryOperatorComboBox.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.QueryOperatorComboBox, resources.GetString("QueryOperatorComboBox.Error"))
        Me.QueryOperatorComboBox.Font = Nothing
        Me.QueryOperatorComboBox.FormattingEnabled = True
        Me.MyErrorProvider.SetIconAlignment(Me.QueryOperatorComboBox, CType(resources.GetObject("QueryOperatorComboBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.QueryOperatorComboBox, CType(resources.GetObject("QueryOperatorComboBox.IconPadding"), Integer))
        Me.QueryOperatorComboBox.Items.AddRange(New Object() {resources.GetString("QueryOperatorComboBox.Items"), resources.GetString("QueryOperatorComboBox.Items1"), resources.GetString("QueryOperatorComboBox.Items2"), resources.GetString("QueryOperatorComboBox.Items3"), resources.GetString("QueryOperatorComboBox.Items4"), resources.GetString("QueryOperatorComboBox.Items5"), resources.GetString("QueryOperatorComboBox.Items6"), resources.GetString("QueryOperatorComboBox.Items7"), resources.GetString("QueryOperatorComboBox.Items8"), resources.GetString("QueryOperatorComboBox.Items9"), resources.GetString("QueryOperatorComboBox.Items10"), resources.GetString("QueryOperatorComboBox.Items11"), resources.GetString("QueryOperatorComboBox.Items12"), resources.GetString("QueryOperatorComboBox.Items13")})
        Me.QueryOperatorComboBox.Name = "QueryOperatorComboBox"
        '
        'AddFieldButton
        '
        Me.AddFieldButton.AccessibleDescription = Nothing
        Me.AddFieldButton.AccessibleName = Nothing
        resources.ApplyResources(Me.AddFieldButton, "AddFieldButton")
        Me.AddFieldButton.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.AddFieldButton, resources.GetString("AddFieldButton.Error"))
        Me.AddFieldButton.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.AddFieldButton, CType(resources.GetObject("AddFieldButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.AddFieldButton, CType(resources.GetObject("AddFieldButton.IconPadding"), Integer))
        Me.AddFieldButton.Image = Global.Gim.PoliceGis.Core.My.Resources.Resources.Add16x16GreenLarge
        Me.AddFieldButton.Name = "AddFieldButton"
        Me.AddFieldButton.UseVisualStyleBackColor = True
        '
        'QueryFieldLabel
        '
        Me.QueryFieldLabel.AccessibleDescription = Nothing
        Me.QueryFieldLabel.AccessibleName = Nothing
        resources.ApplyResources(Me.QueryFieldLabel, "QueryFieldLabel")
        Me.MyErrorProvider.SetError(Me.QueryFieldLabel, resources.GetString("QueryFieldLabel.Error"))
        Me.QueryFieldLabel.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.QueryFieldLabel, CType(resources.GetObject("QueryFieldLabel.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.QueryFieldLabel, CType(resources.GetObject("QueryFieldLabel.IconPadding"), Integer))
        Me.QueryFieldLabel.Name = "QueryFieldLabel"
        '
        'QueryFieldComboBox
        '
        Me.QueryFieldComboBox.AccessibleDescription = Nothing
        Me.QueryFieldComboBox.AccessibleName = Nothing
        resources.ApplyResources(Me.QueryFieldComboBox, "QueryFieldComboBox")
        Me.QueryFieldComboBox.BackColor = System.Drawing.SystemColors.Window
        Me.QueryFieldComboBox.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.QueryFieldComboBox, resources.GetString("QueryFieldComboBox.Error"))
        Me.QueryFieldComboBox.Font = Nothing
        Me.QueryFieldComboBox.FormattingEnabled = True
        Me.MyErrorProvider.SetIconAlignment(Me.QueryFieldComboBox, CType(resources.GetObject("QueryFieldComboBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.QueryFieldComboBox, CType(resources.GetObject("QueryFieldComboBox.IconPadding"), Integer))
        Me.QueryFieldComboBox.Name = "QueryFieldComboBox"
        '
        'MyErrorProvider
        '
        Me.MyErrorProvider.ContainerControl = Me
        resources.ApplyResources(Me.MyErrorProvider, "MyErrorProvider")
        '
        'SimpleQueryBuilder
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.SelectionGroupBox)
        Me.MyErrorProvider.SetError(Me, resources.GetString("$this.Error"))
        Me.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me, CType(resources.GetObject("$this.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me, CType(resources.GetObject("$this.IconPadding"), Integer))
        Me.Name = "SimpleQueryBuilder"
        Me.SelectionGroupBox.ResumeLayout(False)
        Me.SelectionGroupBox.PerformLayout()
        Me.SelectionParametersGroupBox.ResumeLayout(False)
        Me.SelectionParametersGroupBox.PerformLayout()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SelectionGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ClearQueryButton As System.Windows.Forms.Button
    Friend WithEvents NameResulLabel As System.Windows.Forms.Label
    Friend WithEvents OutputTableTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DoQueryButton As System.Windows.Forms.Button
    Friend WithEvents PreviewButton As System.Windows.Forms.Button
    Friend WithEvents QueryStartLabel As System.Windows.Forms.Label
    Friend WithEvents QueryStringTextBox As System.Windows.Forms.TextBox
    Friend WithEvents SelectionParametersGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents AddValueButton As System.Windows.Forms.Button
    Friend WithEvents QueryValuesLabel As System.Windows.Forms.Label
    Friend WithEvents QueryValueComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents AddOperatorButton As System.Windows.Forms.Button
    Friend WithEvents QueryOperatorLabel As System.Windows.Forms.Label
    Friend WithEvents QueryOperatorComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents AddFieldButton As System.Windows.Forms.Button
    Friend WithEvents QueryFieldLabel As System.Windows.Forms.Label
    Friend WithEvents QueryFieldComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents MyErrorProvider As System.Windows.Forms.ErrorProvider

End Class
