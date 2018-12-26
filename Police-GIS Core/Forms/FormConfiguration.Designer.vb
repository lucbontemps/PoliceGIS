<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormConfiguration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormConfiguration))
        Me.Button1 = New System.Windows.Forms.Button
        Me.OpenTabFileButton = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.DataFolderTextBox = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.PolitieZoneTextBox = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.AccessibleDescription = Nothing
        Me.Button1.AccessibleName = Nothing
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.BackgroundImage = Nothing
        Me.Button1.Font = Nothing
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
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
        'Label1
        '
        Me.Label1.AccessibleDescription = Nothing
        Me.Label1.AccessibleName = Nothing
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Font = Nothing
        Me.Label1.Name = "Label1"
        '
        'DataFolderTextBox
        '
        Me.DataFolderTextBox.AccessibleDescription = Nothing
        Me.DataFolderTextBox.AccessibleName = Nothing
        resources.ApplyResources(Me.DataFolderTextBox, "DataFolderTextBox")
        Me.DataFolderTextBox.BackgroundImage = Nothing
        Me.DataFolderTextBox.Font = Nothing
        Me.DataFolderTextBox.Name = "DataFolderTextBox"
        '
        'Label2
        '
        Me.Label2.AccessibleDescription = Nothing
        Me.Label2.AccessibleName = Nothing
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Font = Nothing
        Me.Label2.Name = "Label2"
        '
        'PolitieZoneTextBox
        '
        Me.PolitieZoneTextBox.AccessibleDescription = Nothing
        Me.PolitieZoneTextBox.AccessibleName = Nothing
        resources.ApplyResources(Me.PolitieZoneTextBox, "PolitieZoneTextBox")
        Me.PolitieZoneTextBox.BackgroundImage = Nothing
        Me.PolitieZoneTextBox.Font = Nothing
        Me.PolitieZoneTextBox.Name = "PolitieZoneTextBox"
        '
        'FormConfiguration
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.PolitieZoneTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataFolderTextBox)
        Me.Controls.Add(Me.OpenTabFileButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Font = Nothing
        Me.Name = "FormConfiguration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents OpenTabFileButton As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DataFolderTextBox As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PolitieZoneTextBox As System.Windows.Forms.TextBox
End Class
