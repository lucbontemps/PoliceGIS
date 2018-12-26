
Option Strict On

''' <summary>
''' A table browser on the .NET side, for when you want to show a table, 
''' but not in the MapInfo Window (or say an ADO.NET DataTable, which is 
''' impossible to show directly in MapInfo.
''' </summary>
''' <remarks></remarks>
Public Class FormTableBrowser

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Icon = GuiThemeProvider.GetPoliceIcon
        TableGridView.DataSource = New DataTable
        TableGridView.AlternatingRowsDefaultCellStyle.BackColor = GuiThemeProvider.AlternatingRowColor

    End Sub

    Property DataSource() As Object
        Get
            Return Me.TableGridView.DataSource
        End Get
        Set(ByVal value As Object)
            Me.TableGridView.DataSource = value
        End Set
    End Property

End Class