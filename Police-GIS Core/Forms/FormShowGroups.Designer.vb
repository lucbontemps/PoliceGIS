<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormShowGroups
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormShowGroups))
        Me.DefinedGroupsDataGridView = New System.Windows.Forms.DataGridView
        Me.GroupDGColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ValueDGColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.DefinedGroupsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DefinedGroupsDataGridView
        '
        Me.DefinedGroupsDataGridView.AccessibleDescription = Nothing
        Me.DefinedGroupsDataGridView.AccessibleName = Nothing
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(204, Byte), Integer), CType(CType(215, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DefinedGroupsDataGridView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        resources.ApplyResources(Me.DefinedGroupsDataGridView, "DefinedGroupsDataGridView")
        Me.DefinedGroupsDataGridView.BackgroundImage = Nothing
        Me.DefinedGroupsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DefinedGroupsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GroupDGColumn, Me.ValueDGColumn})
        Me.DefinedGroupsDataGridView.Font = Nothing
        Me.DefinedGroupsDataGridView.MultiSelect = False
        Me.DefinedGroupsDataGridView.Name = "DefinedGroupsDataGridView"
        Me.DefinedGroupsDataGridView.RowTemplate.Height = 24
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
        'FormShowGroups
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.DefinedGroupsDataGridView)
        Me.Font = Nothing
        Me.Name = "FormShowGroups"
        CType(Me.DefinedGroupsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DefinedGroupsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents GroupDGColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ValueDGColumn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
