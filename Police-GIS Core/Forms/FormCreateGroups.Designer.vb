<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCreateGroups
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCreateGroups))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.LabelInputField = New System.Windows.Forms.Label
        Me.ComboBoxInputField = New System.Windows.Forms.ComboBox
        Me.LabelOutputField = New System.Windows.Forms.Label
        Me.TextBoxOutputField = New System.Windows.Forms.TextBox
        Me.GroupBoxEditGroups = New System.Windows.Forms.GroupBox
        Me.ButtonUseExistingGroups = New System.Windows.Forms.Button
        Me.GroupBoxDefinedGroups = New System.Windows.Forms.GroupBox
        Me.DataGridViewDefinedGroups = New System.Windows.Forms.DataGridView
        Me.GroupDGColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValueDGColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBoxEditValues = New System.Windows.Forms.GroupBox
        Me.LabelAvailableValue = New System.Windows.Forms.Label
        Me.ListBoxAvailableValues = New System.Windows.Forms.ListBox
        Me.LabelGroupName = New System.Windows.Forms.Label
        Me.TextBoxGroupName = New System.Windows.Forms.TextBox
        Me.ButtonRemoveFromSelection = New System.Windows.Forms.Button
        Me.ButtonAddToSelection = New System.Windows.Forms.Button
        Me.ButtonAddGroup = New System.Windows.Forms.Button
        Me.ListBoxSelectedValues = New System.Windows.Forms.ListBox
        Me.LabelSelectedValues = New System.Windows.Forms.Label
        Me.ButtonShowGroups = New System.Windows.Forms.Button
        Me.ButtonExecuteGrouping = New System.Windows.Forms.Button
        Me.MyErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PickMapInfoTableControl1 = New Gim.PoliceGis.Core.PickMapInfoTableControl
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher
        Me.MyToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.ButtonSaveGroups = New System.Windows.Forms.Button
        Me.GroupBoxEditGroups.SuspendLayout()
        Me.GroupBoxDefinedGroups.SuspendLayout()
        CType(Me.DataGridViewDefinedGroups, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxEditValues.SuspendLayout()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelInputField
        '
        Me.LabelInputField.AccessibleDescription = Nothing
        Me.LabelInputField.AccessibleName = Nothing
        resources.ApplyResources(Me.LabelInputField, "LabelInputField")
        Me.MyErrorProvider.SetError(Me.LabelInputField, resources.GetString("LabelInputField.Error"))
        Me.LabelInputField.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.LabelInputField, CType(resources.GetObject("LabelInputField.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.LabelInputField, CType(resources.GetObject("LabelInputField.IconPadding"), Integer))
        Me.LabelInputField.Name = "LabelInputField"
        Me.MyToolTip.SetToolTip(Me.LabelInputField, resources.GetString("LabelInputField.ToolTip"))
        '
        'ComboBoxInputField
        '
        Me.ComboBoxInputField.AccessibleDescription = Nothing
        Me.ComboBoxInputField.AccessibleName = Nothing
        resources.ApplyResources(Me.ComboBoxInputField, "ComboBoxInputField")
        Me.ComboBoxInputField.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.ComboBoxInputField, resources.GetString("ComboBoxInputField.Error"))
        Me.ComboBoxInputField.Font = Nothing
        Me.ComboBoxInputField.FormattingEnabled = True
        Me.MyErrorProvider.SetIconAlignment(Me.ComboBoxInputField, CType(resources.GetObject("ComboBoxInputField.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.ComboBoxInputField, CType(resources.GetObject("ComboBoxInputField.IconPadding"), Integer))
        Me.ComboBoxInputField.Name = "ComboBoxInputField"
        Me.MyToolTip.SetToolTip(Me.ComboBoxInputField, resources.GetString("ComboBoxInputField.ToolTip"))
        '
        'LabelOutputField
        '
        Me.LabelOutputField.AccessibleDescription = Nothing
        Me.LabelOutputField.AccessibleName = Nothing
        resources.ApplyResources(Me.LabelOutputField, "LabelOutputField")
        Me.MyErrorProvider.SetError(Me.LabelOutputField, resources.GetString("LabelOutputField.Error"))
        Me.LabelOutputField.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.LabelOutputField, CType(resources.GetObject("LabelOutputField.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.LabelOutputField, CType(resources.GetObject("LabelOutputField.IconPadding"), Integer))
        Me.LabelOutputField.Name = "LabelOutputField"
        Me.MyToolTip.SetToolTip(Me.LabelOutputField, resources.GetString("LabelOutputField.ToolTip"))
        '
        'TextBoxOutputField
        '
        Me.TextBoxOutputField.AccessibleDescription = Nothing
        Me.TextBoxOutputField.AccessibleName = Nothing
        resources.ApplyResources(Me.TextBoxOutputField, "TextBoxOutputField")
        Me.TextBoxOutputField.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.TextBoxOutputField, resources.GetString("TextBoxOutputField.Error"))
        Me.TextBoxOutputField.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.TextBoxOutputField, CType(resources.GetObject("TextBoxOutputField.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.TextBoxOutputField, CType(resources.GetObject("TextBoxOutputField.IconPadding"), Integer))
        Me.TextBoxOutputField.Name = "TextBoxOutputField"
        Me.MyToolTip.SetToolTip(Me.TextBoxOutputField, resources.GetString("TextBoxOutputField.ToolTip"))
        '
        'GroupBoxEditGroups
        '
        Me.GroupBoxEditGroups.AccessibleDescription = Nothing
        Me.GroupBoxEditGroups.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBoxEditGroups, "GroupBoxEditGroups")
        Me.GroupBoxEditGroups.BackgroundImage = Nothing
        Me.GroupBoxEditGroups.Controls.Add(Me.ButtonUseExistingGroups)
        Me.GroupBoxEditGroups.Controls.Add(Me.GroupBoxDefinedGroups)
        Me.GroupBoxEditGroups.Controls.Add(Me.GroupBoxEditValues)
        Me.MyErrorProvider.SetError(Me.GroupBoxEditGroups, resources.GetString("GroupBoxEditGroups.Error"))
        Me.GroupBoxEditGroups.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.GroupBoxEditGroups, CType(resources.GetObject("GroupBoxEditGroups.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.GroupBoxEditGroups, CType(resources.GetObject("GroupBoxEditGroups.IconPadding"), Integer))
        Me.GroupBoxEditGroups.Name = "GroupBoxEditGroups"
        Me.GroupBoxEditGroups.TabStop = False
        Me.MyToolTip.SetToolTip(Me.GroupBoxEditGroups, resources.GetString("GroupBoxEditGroups.ToolTip"))
        '
        'ButtonUseExistingGroups
        '
        Me.ButtonUseExistingGroups.AccessibleDescription = Nothing
        Me.ButtonUseExistingGroups.AccessibleName = Nothing
        resources.ApplyResources(Me.ButtonUseExistingGroups, "ButtonUseExistingGroups")
        Me.ButtonUseExistingGroups.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.ButtonUseExistingGroups, resources.GetString("ButtonUseExistingGroups.Error"))
        Me.ButtonUseExistingGroups.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.ButtonUseExistingGroups, CType(resources.GetObject("ButtonUseExistingGroups.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.ButtonUseExistingGroups, CType(resources.GetObject("ButtonUseExistingGroups.IconPadding"), Integer))
        Me.ButtonUseExistingGroups.Name = "ButtonUseExistingGroups"
        Me.MyToolTip.SetToolTip(Me.ButtonUseExistingGroups, resources.GetString("ButtonUseExistingGroups.ToolTip"))
        Me.ButtonUseExistingGroups.UseVisualStyleBackColor = True
        '
        'GroupBoxDefinedGroups
        '
        Me.GroupBoxDefinedGroups.AccessibleDescription = Nothing
        Me.GroupBoxDefinedGroups.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBoxDefinedGroups, "GroupBoxDefinedGroups")
        Me.GroupBoxDefinedGroups.BackgroundImage = Nothing
        Me.GroupBoxDefinedGroups.Controls.Add(Me.DataGridViewDefinedGroups)
        Me.MyErrorProvider.SetError(Me.GroupBoxDefinedGroups, resources.GetString("GroupBoxDefinedGroups.Error"))
        Me.GroupBoxDefinedGroups.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.GroupBoxDefinedGroups, CType(resources.GetObject("GroupBoxDefinedGroups.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.GroupBoxDefinedGroups, CType(resources.GetObject("GroupBoxDefinedGroups.IconPadding"), Integer))
        Me.GroupBoxDefinedGroups.Name = "GroupBoxDefinedGroups"
        Me.GroupBoxDefinedGroups.TabStop = False
        Me.MyToolTip.SetToolTip(Me.GroupBoxDefinedGroups, resources.GetString("GroupBoxDefinedGroups.ToolTip"))
        '
        'DataGridViewDefinedGroups
        '
        Me.DataGridViewDefinedGroups.AccessibleDescription = Nothing
        Me.DataGridViewDefinedGroups.AccessibleName = Nothing
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridViewDefinedGroups.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.DataGridViewDefinedGroups, "DataGridViewDefinedGroups")
        Me.DataGridViewDefinedGroups.BackgroundImage = Nothing
        Me.DataGridViewDefinedGroups.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewDefinedGroups.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GroupDGColumn, Me.ValueDGColumn})
        Me.MyErrorProvider.SetError(Me.DataGridViewDefinedGroups, resources.GetString("DataGridViewDefinedGroups.Error"))
        Me.DataGridViewDefinedGroups.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.DataGridViewDefinedGroups, CType(resources.GetObject("DataGridViewDefinedGroups.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.DataGridViewDefinedGroups, CType(resources.GetObject("DataGridViewDefinedGroups.IconPadding"), Integer))
        Me.DataGridViewDefinedGroups.MultiSelect = False
        Me.DataGridViewDefinedGroups.Name = "DataGridViewDefinedGroups"
        Me.DataGridViewDefinedGroups.RowTemplate.Height = 24
        Me.MyToolTip.SetToolTip(Me.DataGridViewDefinedGroups, resources.GetString("DataGridViewDefinedGroups.ToolTip"))
        '
        'GroupDGColumn
        '
        resources.ApplyResources(Me.GroupDGColumn, "GroupDGColumn")
        Me.GroupDGColumn.Name = "GroupDGColumn"
        '
        'ValueDGColumn
        '
        resources.ApplyResources(Me.ValueDGColumn, "ValueDGColumn")
        Me.ValueDGColumn.Name = "ValueDGColumn"
        '
        'GroupBoxEditValues
        '
        Me.GroupBoxEditValues.AccessibleDescription = Nothing
        Me.GroupBoxEditValues.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBoxEditValues, "GroupBoxEditValues")
        Me.GroupBoxEditValues.BackgroundImage = Nothing
        Me.GroupBoxEditValues.Controls.Add(Me.LabelAvailableValue)
        Me.GroupBoxEditValues.Controls.Add(Me.ListBoxAvailableValues)
        Me.GroupBoxEditValues.Controls.Add(Me.LabelGroupName)
        Me.GroupBoxEditValues.Controls.Add(Me.TextBoxGroupName)
        Me.GroupBoxEditValues.Controls.Add(Me.ButtonRemoveFromSelection)
        Me.GroupBoxEditValues.Controls.Add(Me.ButtonAddToSelection)
        Me.GroupBoxEditValues.Controls.Add(Me.ButtonAddGroup)
        Me.GroupBoxEditValues.Controls.Add(Me.ListBoxSelectedValues)
        Me.GroupBoxEditValues.Controls.Add(Me.LabelSelectedValues)
        Me.MyErrorProvider.SetError(Me.GroupBoxEditValues, resources.GetString("GroupBoxEditValues.Error"))
        Me.GroupBoxEditValues.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.GroupBoxEditValues, CType(resources.GetObject("GroupBoxEditValues.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.GroupBoxEditValues, CType(resources.GetObject("GroupBoxEditValues.IconPadding"), Integer))
        Me.GroupBoxEditValues.MinimumSize = New System.Drawing.Size(375, 122)
        Me.GroupBoxEditValues.Name = "GroupBoxEditValues"
        Me.GroupBoxEditValues.TabStop = False
        Me.MyToolTip.SetToolTip(Me.GroupBoxEditValues, resources.GetString("GroupBoxEditValues.ToolTip"))
        '
        'LabelAvailableValue
        '
        Me.LabelAvailableValue.AccessibleDescription = Nothing
        Me.LabelAvailableValue.AccessibleName = Nothing
        resources.ApplyResources(Me.LabelAvailableValue, "LabelAvailableValue")
        Me.MyErrorProvider.SetError(Me.LabelAvailableValue, resources.GetString("LabelAvailableValue.Error"))
        Me.LabelAvailableValue.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.LabelAvailableValue, CType(resources.GetObject("LabelAvailableValue.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.LabelAvailableValue, CType(resources.GetObject("LabelAvailableValue.IconPadding"), Integer))
        Me.LabelAvailableValue.Name = "LabelAvailableValue"
        Me.MyToolTip.SetToolTip(Me.LabelAvailableValue, resources.GetString("LabelAvailableValue.ToolTip"))
        '
        'ListBoxAvailableValues
        '
        Me.ListBoxAvailableValues.AccessibleDescription = Nothing
        Me.ListBoxAvailableValues.AccessibleName = Nothing
        resources.ApplyResources(Me.ListBoxAvailableValues, "ListBoxAvailableValues")
        Me.ListBoxAvailableValues.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.ListBoxAvailableValues, resources.GetString("ListBoxAvailableValues.Error"))
        Me.ListBoxAvailableValues.Font = Nothing
        Me.ListBoxAvailableValues.FormattingEnabled = True
        Me.MyErrorProvider.SetIconAlignment(Me.ListBoxAvailableValues, CType(resources.GetObject("ListBoxAvailableValues.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.ListBoxAvailableValues, CType(resources.GetObject("ListBoxAvailableValues.IconPadding"), Integer))
        Me.ListBoxAvailableValues.Name = "ListBoxAvailableValues"
        Me.ListBoxAvailableValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.MyToolTip.SetToolTip(Me.ListBoxAvailableValues, resources.GetString("ListBoxAvailableValues.ToolTip"))
        '
        'LabelGroupName
        '
        Me.LabelGroupName.AccessibleDescription = Nothing
        Me.LabelGroupName.AccessibleName = Nothing
        resources.ApplyResources(Me.LabelGroupName, "LabelGroupName")
        Me.MyErrorProvider.SetError(Me.LabelGroupName, resources.GetString("LabelGroupName.Error"))
        Me.LabelGroupName.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.LabelGroupName, CType(resources.GetObject("LabelGroupName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.LabelGroupName, CType(resources.GetObject("LabelGroupName.IconPadding"), Integer))
        Me.LabelGroupName.Name = "LabelGroupName"
        Me.MyToolTip.SetToolTip(Me.LabelGroupName, resources.GetString("LabelGroupName.ToolTip"))
        '
        'TextBoxGroupName
        '
        Me.TextBoxGroupName.AccessibleDescription = Nothing
        Me.TextBoxGroupName.AccessibleName = Nothing
        resources.ApplyResources(Me.TextBoxGroupName, "TextBoxGroupName")
        Me.TextBoxGroupName.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.TextBoxGroupName, resources.GetString("TextBoxGroupName.Error"))
        Me.TextBoxGroupName.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.TextBoxGroupName, CType(resources.GetObject("TextBoxGroupName.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.TextBoxGroupName, CType(resources.GetObject("TextBoxGroupName.IconPadding"), Integer))
        Me.TextBoxGroupName.Name = "TextBoxGroupName"
        Me.MyToolTip.SetToolTip(Me.TextBoxGroupName, resources.GetString("TextBoxGroupName.ToolTip"))
        '
        'ButtonRemoveFromSelection
        '
        Me.ButtonRemoveFromSelection.AccessibleDescription = Nothing
        Me.ButtonRemoveFromSelection.AccessibleName = Nothing
        resources.ApplyResources(Me.ButtonRemoveFromSelection, "ButtonRemoveFromSelection")
        Me.ButtonRemoveFromSelection.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.ButtonRemoveFromSelection, resources.GetString("ButtonRemoveFromSelection.Error"))
        Me.ButtonRemoveFromSelection.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.ButtonRemoveFromSelection, CType(resources.GetObject("ButtonRemoveFromSelection.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.ButtonRemoveFromSelection, CType(resources.GetObject("ButtonRemoveFromSelection.IconPadding"), Integer))
        Me.ButtonRemoveFromSelection.Name = "ButtonRemoveFromSelection"
        Me.MyToolTip.SetToolTip(Me.ButtonRemoveFromSelection, resources.GetString("ButtonRemoveFromSelection.ToolTip"))
        Me.ButtonRemoveFromSelection.UseVisualStyleBackColor = True
        '
        'ButtonAddToSelection
        '
        Me.ButtonAddToSelection.AccessibleDescription = Nothing
        Me.ButtonAddToSelection.AccessibleName = Nothing
        resources.ApplyResources(Me.ButtonAddToSelection, "ButtonAddToSelection")
        Me.ButtonAddToSelection.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.ButtonAddToSelection, resources.GetString("ButtonAddToSelection.Error"))
        Me.ButtonAddToSelection.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.ButtonAddToSelection, CType(resources.GetObject("ButtonAddToSelection.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.ButtonAddToSelection, CType(resources.GetObject("ButtonAddToSelection.IconPadding"), Integer))
        Me.ButtonAddToSelection.Name = "ButtonAddToSelection"
        Me.MyToolTip.SetToolTip(Me.ButtonAddToSelection, resources.GetString("ButtonAddToSelection.ToolTip"))
        Me.ButtonAddToSelection.UseVisualStyleBackColor = True
        '
        'ButtonAddGroup
        '
        Me.ButtonAddGroup.AccessibleDescription = Nothing
        Me.ButtonAddGroup.AccessibleName = Nothing
        resources.ApplyResources(Me.ButtonAddGroup, "ButtonAddGroup")
        Me.ButtonAddGroup.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.ButtonAddGroup, resources.GetString("ButtonAddGroup.Error"))
        Me.ButtonAddGroup.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.ButtonAddGroup, CType(resources.GetObject("ButtonAddGroup.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.ButtonAddGroup, CType(resources.GetObject("ButtonAddGroup.IconPadding"), Integer))
        Me.ButtonAddGroup.Name = "ButtonAddGroup"
        Me.MyToolTip.SetToolTip(Me.ButtonAddGroup, resources.GetString("ButtonAddGroup.ToolTip"))
        Me.ButtonAddGroup.UseVisualStyleBackColor = True
        '
        'ListBoxSelectedValues
        '
        Me.ListBoxSelectedValues.AccessibleDescription = Nothing
        Me.ListBoxSelectedValues.AccessibleName = Nothing
        resources.ApplyResources(Me.ListBoxSelectedValues, "ListBoxSelectedValues")
        Me.ListBoxSelectedValues.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.ListBoxSelectedValues, resources.GetString("ListBoxSelectedValues.Error"))
        Me.ListBoxSelectedValues.Font = Nothing
        Me.ListBoxSelectedValues.FormattingEnabled = True
        Me.MyErrorProvider.SetIconAlignment(Me.ListBoxSelectedValues, CType(resources.GetObject("ListBoxSelectedValues.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.ListBoxSelectedValues, CType(resources.GetObject("ListBoxSelectedValues.IconPadding"), Integer))
        Me.ListBoxSelectedValues.Name = "ListBoxSelectedValues"
        Me.ListBoxSelectedValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.MyToolTip.SetToolTip(Me.ListBoxSelectedValues, resources.GetString("ListBoxSelectedValues.ToolTip"))
        '
        'LabelSelectedValues
        '
        Me.LabelSelectedValues.AccessibleDescription = Nothing
        Me.LabelSelectedValues.AccessibleName = Nothing
        resources.ApplyResources(Me.LabelSelectedValues, "LabelSelectedValues")
        Me.MyErrorProvider.SetError(Me.LabelSelectedValues, resources.GetString("LabelSelectedValues.Error"))
        Me.LabelSelectedValues.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.LabelSelectedValues, CType(resources.GetObject("LabelSelectedValues.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.LabelSelectedValues, CType(resources.GetObject("LabelSelectedValues.IconPadding"), Integer))
        Me.LabelSelectedValues.Name = "LabelSelectedValues"
        Me.MyToolTip.SetToolTip(Me.LabelSelectedValues, resources.GetString("LabelSelectedValues.ToolTip"))
        '
        'ButtonShowGroups
        '
        Me.ButtonShowGroups.AccessibleDescription = Nothing
        Me.ButtonShowGroups.AccessibleName = Nothing
        resources.ApplyResources(Me.ButtonShowGroups, "ButtonShowGroups")
        Me.ButtonShowGroups.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.ButtonShowGroups, resources.GetString("ButtonShowGroups.Error"))
        Me.ButtonShowGroups.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.ButtonShowGroups, CType(resources.GetObject("ButtonShowGroups.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.ButtonShowGroups, CType(resources.GetObject("ButtonShowGroups.IconPadding"), Integer))
        Me.ButtonShowGroups.Name = "ButtonShowGroups"
        Me.MyToolTip.SetToolTip(Me.ButtonShowGroups, resources.GetString("ButtonShowGroups.ToolTip"))
        Me.ButtonShowGroups.UseVisualStyleBackColor = True
        '
        'ButtonExecuteGrouping
        '
        Me.ButtonExecuteGrouping.AccessibleDescription = Nothing
        Me.ButtonExecuteGrouping.AccessibleName = Nothing
        resources.ApplyResources(Me.ButtonExecuteGrouping, "ButtonExecuteGrouping")
        Me.ButtonExecuteGrouping.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.ButtonExecuteGrouping, resources.GetString("ButtonExecuteGrouping.Error"))
        Me.ButtonExecuteGrouping.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.ButtonExecuteGrouping, CType(resources.GetObject("ButtonExecuteGrouping.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.ButtonExecuteGrouping, CType(resources.GetObject("ButtonExecuteGrouping.IconPadding"), Integer))
        Me.ButtonExecuteGrouping.Name = "ButtonExecuteGrouping"
        Me.MyToolTip.SetToolTip(Me.ButtonExecuteGrouping, resources.GetString("ButtonExecuteGrouping.ToolTip"))
        Me.ButtonExecuteGrouping.UseVisualStyleBackColor = True
        '
        'MyErrorProvider
        '
        Me.MyErrorProvider.ContainerControl = Me
        resources.ApplyResources(Me.MyErrorProvider, "MyErrorProvider")
        '
        'PickMapInfoTableControl1
        '
        Me.PickMapInfoTableControl1.AccessibleDescription = Nothing
        Me.PickMapInfoTableControl1.AccessibleName = Nothing
        resources.ApplyResources(Me.PickMapInfoTableControl1, "PickMapInfoTableControl1")
        Me.PickMapInfoTableControl1.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.PickMapInfoTableControl1, resources.GetString("PickMapInfoTableControl1.Error"))
        Me.PickMapInfoTableControl1.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.PickMapInfoTableControl1, CType(resources.GetObject("PickMapInfoTableControl1.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.PickMapInfoTableControl1, CType(resources.GetObject("PickMapInfoTableControl1.IconPadding"), Integer))
        Me.PickMapInfoTableControl1.InitialDirectory = Global.Gim.PoliceGis.Core.My.Resources.Resources.MapsFolder
        Me.PickMapInfoTableControl1.Name = "PickMapInfoTableControl1"
        Me.PickMapInfoTableControl1.SelectedIndex = -1
        Me.PickMapInfoTableControl1.SelectedTable = Nothing
        Me.MyToolTip.SetToolTip(Me.PickMapInfoTableControl1, resources.GetString("PickMapInfoTableControl1.ToolTip"))
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'ButtonSaveGroups
        '
        Me.ButtonSaveGroups.AccessibleDescription = Nothing
        Me.ButtonSaveGroups.AccessibleName = Nothing
        resources.ApplyResources(Me.ButtonSaveGroups, "ButtonSaveGroups")
        Me.ButtonSaveGroups.BackgroundImage = Nothing
        Me.MyErrorProvider.SetError(Me.ButtonSaveGroups, resources.GetString("ButtonSaveGroups.Error"))
        Me.ButtonSaveGroups.Font = Nothing
        Me.MyErrorProvider.SetIconAlignment(Me.ButtonSaveGroups, CType(resources.GetObject("ButtonSaveGroups.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.MyErrorProvider.SetIconPadding(Me.ButtonSaveGroups, CType(resources.GetObject("ButtonSaveGroups.IconPadding"), Integer))
        Me.ButtonSaveGroups.Name = "ButtonSaveGroups"
        Me.MyToolTip.SetToolTip(Me.ButtonSaveGroups, resources.GetString("ButtonSaveGroups.ToolTip"))
        Me.ButtonSaveGroups.UseVisualStyleBackColor = True
        '
        'FormCreateGroups
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.ButtonSaveGroups)
        Me.Controls.Add(Me.PickMapInfoTableControl1)
        Me.Controls.Add(Me.ButtonShowGroups)
        Me.Controls.Add(Me.ButtonExecuteGrouping)
        Me.Controls.Add(Me.GroupBoxEditGroups)
        Me.Controls.Add(Me.TextBoxOutputField)
        Me.Controls.Add(Me.LabelOutputField)
        Me.Controls.Add(Me.ComboBoxInputField)
        Me.Controls.Add(Me.LabelInputField)
        Me.Font = Nothing
        Me.Name = "FormCreateGroups"
        Me.MyToolTip.SetToolTip(Me, resources.GetString("$this.ToolTip"))
        Me.GroupBoxEditGroups.ResumeLayout(False)
        Me.GroupBoxDefinedGroups.ResumeLayout(False)
        CType(Me.DataGridViewDefinedGroups, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxEditValues.ResumeLayout(False)
        Me.GroupBoxEditValues.PerformLayout()
        CType(Me.MyErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelInputField As System.Windows.Forms.Label
    Friend WithEvents ComboBoxInputField As System.Windows.Forms.ComboBox
    Friend WithEvents LabelOutputField As System.Windows.Forms.Label
    Friend WithEvents TextBoxOutputField As System.Windows.Forms.TextBox
    Friend WithEvents GroupBoxEditGroups As System.Windows.Forms.GroupBox
    Friend WithEvents LabelSelectedValues As System.Windows.Forms.Label
    Friend WithEvents GroupBoxEditValues As System.Windows.Forms.GroupBox
    Friend WithEvents LabelAvailableValue As System.Windows.Forms.Label
    Friend WithEvents ListBoxAvailableValues As System.Windows.Forms.ListBox
    Friend WithEvents LabelGroupName As System.Windows.Forms.Label
    Friend WithEvents TextBoxGroupName As System.Windows.Forms.TextBox
    Friend WithEvents ButtonRemoveFromSelection As System.Windows.Forms.Button
    Friend WithEvents ButtonAddToSelection As System.Windows.Forms.Button
    Friend WithEvents ButtonAddGroup As System.Windows.Forms.Button
    Friend WithEvents ListBoxSelectedValues As System.Windows.Forms.ListBox
    Friend WithEvents GroupBoxDefinedGroups As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridViewDefinedGroups As System.Windows.Forms.DataGridView
    Friend WithEvents ButtonExecuteGrouping As System.Windows.Forms.Button
    Friend WithEvents MyErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents ButtonShowGroups As System.Windows.Forms.Button
    Friend WithEvents MyToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents PickMapInfoTableControl1 As PickMapInfoTableControl
    Friend WithEvents GroupDGColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValueDGColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ButtonSaveGroups As System.Windows.Forms.Button
    Private WithEvents ButtonUseExistingGroups As System.Windows.Forms.Button
End Class
