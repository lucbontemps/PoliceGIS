<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PickMapInfoTableControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PickMapInfoTableControl))
        Me.OpenTabFileButton = New System.Windows.Forms.Button
        Me.TableComboBox = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.OpenTabFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.SuspendLayout()
        '
        'OpenTabFileButton
        '
        resources.ApplyResources(Me.OpenTabFileButton, "OpenTabFileButton")
        Me.OpenTabFileButton.Image = Global.Gim.PoliceGis.Core.My.Resources.Resources.openfolderHS
        Me.OpenTabFileButton.Name = "OpenTabFileButton"
        Me.OpenTabFileButton.UseVisualStyleBackColor = True
        '
        'TableComboBox
        '
        resources.ApplyResources(Me.TableComboBox, "TableComboBox")
        Me.TableComboBox.FormattingEnabled = True
        Me.TableComboBox.Name = "TableComboBox"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'OpenTabFileDialog
        '
        resources.ApplyResources(Me.OpenTabFileDialog, "OpenTabFileDialog")
        '
        'PickMapInfoTableControl
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.OpenTabFileButton)
        Me.Controls.Add(Me.TableComboBox)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PickMapInfoTableControl"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenTabFileButton As System.Windows.Forms.Button
    Friend WithEvents TableComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenTabFileDialog As System.Windows.Forms.OpenFileDialog

End Class
