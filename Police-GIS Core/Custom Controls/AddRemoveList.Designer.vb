<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddRemoveList(Of T)
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
        Me.ListBoxAvailableValues = New System.Windows.Forms.ListBox
        Me.ButtonRemoveFromSelection = New System.Windows.Forms.Button
        Me.ButtonAddToSelection = New System.Windows.Forms.Button
        Me.ListBoxSelectedValues = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'ListBoxAvailableValues
        '
        Me.ListBoxAvailableValues.FormattingEnabled = True
        Me.ListBoxAvailableValues.Location = New System.Drawing.Point(3, 3)
        Me.ListBoxAvailableValues.Name = "ListBoxAvailableValues"
        Me.ListBoxAvailableValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBoxAvailableValues.Size = New System.Drawing.Size(260, 147)
        Me.ListBoxAvailableValues.TabIndex = 20
        '
        'ButtonRemoveFromSelection
        '
        Me.ButtonRemoveFromSelection.Location = New System.Drawing.Point(268, 83)
        Me.ButtonRemoveFromSelection.Name = "ButtonRemoveFromSelection"
        Me.ButtonRemoveFromSelection.Size = New System.Drawing.Size(41, 23)
        Me.ButtonRemoveFromSelection.TabIndex = 23
        Me.ButtonRemoveFromSelection.Text = "<<"
        Me.ButtonRemoveFromSelection.UseVisualStyleBackColor = True
        '
        'ButtonAddToSelection
        '
        Me.ButtonAddToSelection.Location = New System.Drawing.Point(268, 54)
        Me.ButtonAddToSelection.Name = "ButtonAddToSelection"
        Me.ButtonAddToSelection.Size = New System.Drawing.Size(41, 23)
        Me.ButtonAddToSelection.TabIndex = 22
        Me.ButtonAddToSelection.Text = ">>"
        Me.ButtonAddToSelection.UseVisualStyleBackColor = True
        '
        'ListBoxSelectedValues
        '
        Me.ListBoxSelectedValues.FormattingEnabled = True
        Me.ListBoxSelectedValues.Location = New System.Drawing.Point(315, 3)
        Me.ListBoxSelectedValues.Name = "ListBoxSelectedValues"
        Me.ListBoxSelectedValues.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ListBoxSelectedValues.Size = New System.Drawing.Size(260, 147)
        Me.ListBoxSelectedValues.TabIndex = 21
        '
        'AddRemoveList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.ListBoxAvailableValues)
        Me.Controls.Add(Me.ButtonRemoveFromSelection)
        Me.Controls.Add(Me.ButtonAddToSelection)
        Me.Controls.Add(Me.ListBoxSelectedValues)
        Me.Name = "AddRemoveList"
        Me.Size = New System.Drawing.Size(580, 153)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListBoxAvailableValues As System.Windows.Forms.ListBox
    Friend WithEvents ButtonRemoveFromSelection As System.Windows.Forms.Button
    Friend WithEvents ButtonAddToSelection As System.Windows.Forms.Button
    Friend WithEvents ListBoxSelectedValues As System.Windows.Forms.ListBox


End Class
