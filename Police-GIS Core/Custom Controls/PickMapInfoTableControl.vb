Option Strict On

Imports Gim.ErrorHandling
Imports Gim.PoliceGis.Core
Imports System.Windows.Forms

Public Class PickMapInfoTableControl


    Public Delegate Sub SelectedTableChangedDelegate(ByVal sender As PickMapInfoTableControl, ByVal tableName As String)
    Public Event SelectedTableChanged As SelectedTableChangedDelegate


    Private m_tables As New List(Of String)

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_tables = New List(Of String)
        TableComboBox.Items.AddRange(m_tables.ToArray)

    End Sub

    Property InitialDirectory() As String
        Get
            Return OpenTabFileDialog.InitialDirectory
        End Get
        Set(ByVal value As String)
            OpenTabFileDialog.InitialDirectory = value
        End Set
    End Property

    Public Sub ClearTables()
        m_tables.Clear()
        TableComboBox.Items.Clear()
        TableComboBox.SelectedIndex = -1
        TableComboBox.Text = ""
    End Sub

    Public Sub AddTable(ByVal tableName As String)
        m_tables.Add(tableName)
        TableComboBox.Items.Add(tableName)
    End Sub

    Public Sub AddTables(ByVal tableNames As IEnumerable(Of String))

        m_tables.AddRange(tableNames)

        For Each t In tableNames
            TableComboBox.Items.Add(t)
        Next

    End Sub

    Property SelectedIndex() As Integer
        Get
            Return TableComboBox.SelectedIndex
        End Get
        Set(ByVal value As Integer)
            TableComboBox.SelectedIndex = value
        End Set
    End Property

    Property SelectedTable() As String

        Get

            If TableComboBox.SelectedIndex >= 0 Then
                Return TableComboBox.Items(TableComboBox.SelectedIndex).ToString
            Else
                Return Nothing
            End If

        End Get

        Set(ByVal value As String)

            If value Is Nothing Then
                SelectedIndex = -1

            ElseIf m_tables.ToArray.Contains(value) Then
                TableComboBox.SelectedItem = value

            Else
                Throw New ArgumentOutOfRangeException(String.Format("Value must be present in property ""Tables"", Value = ""{0}""", value))
            End If

        End Set
    End Property

    ''' <summary>
    ''' Open a file chooser to select a MapInfo TAB file.
    ''' The table will be openened and selected in the combobox.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OpenTabFile()

        Dim answer = OpenTabFileDialog.ShowDialog
        Dim tableName = ""
        If answer = Windows.Forms.DialogResult.OK Then

            If Not String.IsNullOrEmpty(OpenTabFileDialog.FileName) Then

                Dim tableId As Short = MITableProxy.GetTableIDByFile(OpenTabFileDialog.FileName)
                If tableId <= 0 Then

                    tableName = MITableProxy.OpenTable(OpenTabFileDialog.FileName, False)
                    If MITableProxy.IsMappable(tableName) Then
                        m_tables.Add(tableName)
                        TableComboBox.Items.Add(tableName)
                        SelectedTable = tableName
                    Else
                        MessageBox.Show(string.Format(My.Resources.ErrorNoSpatialTable,tableName))
                    End If

                Else

                    tableName = MITableProxy.GetTableName(tableId)
                    If Not TableComboBox.Items.Contains(tableName) Then
                        If MITableProxy.IsMappable(tableName) Then
                            TableComboBox.Items.Add(tableName)
                        Else
                            MessageBox.Show(String.Format(My.Resources.ErrorNoSpatialTable, tableName))
                        End If

                    End If

                    ' Store result and notify all observers that the selected table has changed.
                    SelectedTable = tableName
                    RaiseEvent SelectedTableChanged(Me, SelectedTable)

                End If

            End If

        End If

    End Sub


    Private Sub TableComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableComboBox.SelectedIndexChanged

        RaiseEvent SelectedTableChanged(Me, SelectedTable)

    End Sub

    Private Sub OpenTabFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenTabFileButton.Click

        Try
            OpenTabFile()
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

End Class
