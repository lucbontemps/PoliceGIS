Option Strict On

' System namespaces
Imports System.Windows.Forms
Imports System.Drawing


' GIM namespaces
Imports Gim.ErrorHandling
Imports Gim.PoliceGis.Core
Imports System.Xml.Schema
Imports System.IO
Imports System.Text


''' <summary>
''' GUI for the grouping module. Allows to create and edit groups, then apply 
''' them to the selecter table.
''' </summary>
''' <remarks>
''' </remarks>
Public Class FormCreateGroups

    '
    ' Fields and constants
    '
    Private m_groupMapping As DataTable
    Private m_groupTableForm As FormShowGroups
    Public Const COLUMN_GROUP As String = "group"
    Public Const COLUMN_VALUE As String = "value"

    '
    ' Constructor(s)
    '

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Logo of the police is the icon for the window.

        Me.Icon = GuiThemeProvider.GetPoliceIcon
        Me.Text = String.Format("{0}{1}", Me.Text, My.Resources.GIMPoliceGis)
        DataGridViewDefinedGroups.AlternatingRowsDefaultCellStyle.BackColor = GuiThemeProvider.AlternatingRowColor

        MyToolTip.SetToolTip(ListBoxAvailableValues, My.Resources.TooltipSelectValues)
        MyToolTip.SetToolTip(ListBoxSelectedValues, My.Resources.TooltipSelectedValues)
        MyToolTip.SetToolTip(DataGridViewDefinedGroups, My.Resources.TooltipWichValues)

        Dim tables = MITableProxy.ListTableNames()
        PickMapInfoTableControl1.AddTables(tables.ToArray)

        m_groupMapping = New DataTable("groups")

        Dim colGroup As New DataColumn(COLUMN_GROUP, GetType(System.String))
        Dim colValue As New DataColumn(COLUMN_VALUE, GetType(System.String))
        m_groupMapping.Columns.Add(colGroup)
        m_groupMapping.Columns.Add(colValue)
        m_groupTableForm = New FormShowGroups(m_groupMapping)

        DataGridViewDefinedGroups.DataSource = m_groupMapping
        GroupDGColumn.DataPropertyName = COLUMN_GROUP
        ValueDGColumn.DataPropertyName = COLUMN_VALUE
        DataGridViewDefinedGroups.Columns.RemoveAt(3)
        DataGridViewDefinedGroups.Columns.RemoveAt(2)

        OnTableChanged()

    End Sub


    '
    ' Private methods
    '


    Private Sub TableComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            OnTableChanged()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub OnTableChanged()

        Dim tableSelected = PickMapInfoTableControl1.SelectedIndex >= 0
        ComboBoxInputField.Enabled = tableSelected
        GroupBoxEditGroups.Enabled = tableSelected
        ButtonShowGroups.Enabled = tableSelected
        ButtonExecuteGrouping.Enabled = tableSelected

        If tableSelected Then

            Dim table = PickMapInfoTableControl1.SelectedTable
            Dim fields = MITableProxy.ListColumnNames(table)
            ComboBoxInputField.Items.Clear()
            ComboBoxInputField.Items.AddRange(fields.ToArray)

            OnInputFieldChanged()

        End If

    End Sub


    Private Sub OnInputFieldChanged()

        UpdateAvailableValues()
        ListBoxSelectedValues.Items.Clear()
        m_groupMapping.Clear()

    End Sub


    Private Sub InputFieldComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBoxInputField.SelectedIndexChanged

        Try

            OnInputFieldChanged()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub AddToSelectionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddToSelection.Click

        Try

            Dim itemsToMove As Object() = New Object(ListBoxAvailableValues.SelectedItems.Count - 1) {}
            ListBoxAvailableValues.SelectedItems.CopyTo(itemsToMove, 0)

            For Each it In itemsToMove
                ListBoxSelectedValues.Items.Add(it)
                ListBoxAvailableValues.Items.Remove(it)
            Next

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub RemoveFromSelectionButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRemoveFromSelection.Click

        Try

            Dim itemsToMove As Object() = New Object(ListBoxSelectedValues.SelectedItems.Count - 1) {}
            ListBoxSelectedValues.SelectedItems.CopyTo(itemsToMove, 0)

            For Each it In itemsToMove
                ListBoxAvailableValues.Items.Add(it)
                ListBoxSelectedValues.Items.Remove(it)
            Next

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub AddGroupButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddGroup.Click

        Try

            Dim newGroupName As String = TextBoxGroupName.Text
            For Each value In Me.ListBoxSelectedValues.Items

                Dim valueStr = value.ToString
                Dim groupRow = m_groupMapping.NewRow
                groupRow.Item(COLUMN_GROUP) = newGroupName
                groupRow.Item(COLUMN_VALUE) = valueStr
                m_groupMapping.Rows.Add(groupRow)


            Next

            ListBoxSelectedValues.Items.Clear()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Function GetAvailableValues() As List(Of String)

        Dim result As New List(Of String)
        Dim table = PickMapInfoTableControl1.SelectedTable
        Dim field = ComboBoxInputField.SelectedItem.ToString()
        Dim uniqueValues = MIColumnProxy.GetUniqueValuesInColumn(table, field)

        For Each uv In uniqueValues

            ' quote string and escape single quotes for a query on a DataTable
            Dim rowWithValue = m_groupMapping.Select(COLUMN_VALUE & " = '" & uv.Replace("'", "''") & "'")
            If rowWithValue.Length = 0 Then
                result.Add(uv)
            End If

        Next

        Return result

    End Function

    Private Function UpdateRenameTable() As Boolean

        Dim outField = Me.TextBoxOutputField.Text
        If String.IsNullOrEmpty(outField) Then

            MessageBox.Show(My.Resources.ExceptionMessages.NameNotFilled)
            Return False
        Else
            Dim tableName = PickMapInfoTableControl1.SelectedTable
            Dim inputField = ComboBoxInputField.SelectedItem.ToString()
            Dim numFrmt = MapBasicInterop.GetMapInfoNumFormat

            Dim outFieldPresent = MITableProxy.ListColumnNames(tableName).Contains(outField)

            If outFieldPresent Then

                ' Field is already present
                ' Don't change anything if the user does not positively confirm 
                ' he or she wants to overwrite the current values.

                Dim overWritefieldMsg = String.Format(My.Resources.Messages.GroupingIncidents.OverWriteExistingField, outField)
                Dim answer = MessageBox.Show(overWritefieldMsg, My.Resources.GroupFieldExist, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button3)
                If answer <> Windows.Forms.DialogResult.Yes Then
                    Return False
                End If

            Else

                ' add the new field
                Dim longestValueWidth As Integer = 0
                Dim indexGroup As Integer = m_groupMapping.Columns(COLUMN_GROUP).Ordinal

                For Each dr As DataRow In m_groupMapping.Rows

                    Dim groupName = dr.Item(indexGroup).ToString
                    If groupName.Length > longestValueWidth Then
                        longestValueWidth = groupName.Length
                    End If

                Next

                Dim addColumnCommand As String = "Alter Table " & tableName & " (  Add " & outField & " CHAR( " & longestValueWidth.ToString(MapBasicInterop.GetMapInfoNumFormat()) & " ) )"
                MapBasicInterop.ExecuteCommand(addColumnCommand)

            End If

            For rw As Integer = 0 To MITableProxy.GetRowCount(tableName)

                MapBasicInterop.ExecuteCommand(String.Format(numFrmt, "Fetch rec {0} from {1} ", rw, tableName))
                Dim fieldValue = MapBasicInterop.Evaluate(tableName & "." & inputField)

                Dim drs = GetMatchingDataRows(fieldValue)
                If drs.Length > 1 Then
                    Throw New PoliceGisException("Internal error: More then one group matching following value: ""{0}"".")
                ElseIf drs.Length = 1 Then

                    Dim groupName = drs(0).Item(COLUMN_GROUP).ToString

                    'Update table Set column = expr [, column = expr, ...] [ Where RowID = idnum ]
                    'String values must be quoted and escaped
                    Dim escapedGroupName As String = """" & MapBasicInterop.EscapeString(groupName) & """"
                    Dim updateCommand = String.Format(numFrmt, "Update {0} Set {1} = {2}  Where RowID = {3} ", tableName, outField, escapedGroupName, rw)
                    MapBasicInterop.ExecuteCommand(updateCommand)

                    ' length = 0 means  no match
                End If

            Next
            MITableProxy.SaveTable(tableName)
            Return True
        End If


    End Function


    Private Function GetMatchingDataRows(ByVal value As String) As DataRow()

        Return m_groupMapping.Select(COLUMN_VALUE & " = '" & value.Replace("'", "''") & "'")

    End Function


    Private Sub ExecuteGroupingButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonExecuteGrouping.Click

        Try

            If UpdateRenameTable() Then

                Dim openBrowserWindowCmd = String.Format("Browse * From {0}", PickMapInfoTableControl1.SelectedTable)
                MapBasicInterop.ExecuteCommand(openBrowserWindowCmd)

                Me.Close()
            End If

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub DefinedGroupsDataGridView_RowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) Handles DataGridViewDefinedGroups.RowsRemoved

        Try

            UpdateAvailableValues()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub DefinedGroupsDataGridView_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridViewDefinedGroups.CellValueChanged

        Try

            ValidateGridCell(e.RowIndex, e.ColumnIndex)

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Function ValidateGridCell(ByVal rowIndex As Integer, ByVal columnIndex As Integer) As Boolean

        Dim wasCancelled As Boolean = False
        If rowIndex >= 0 And columnIndex >= 0 Then

            Dim theCell = DataGridViewDefinedGroups.Rows(rowIndex).Cells(columnIndex)
            If String.IsNullOrEmpty(Convert.ToString(theCell.Value)) Then
                theCell.ErrorText = "Waarde moet ingevuld zijn."
                wasCancelled = True
            Else
                theCell.ErrorText = ""
            End If

        End If

        Return wasCancelled

    End Function


    Private Sub UpdateAvailableValues()

        ListBoxAvailableValues.Items.Clear()

        If PickMapInfoTableControl1.SelectedIndex >= 0 And ComboBoxInputField.SelectedIndex >= 0 Then

            Dim tableName = PickMapInfoTableControl1.SelectedTable
            Dim inputField = ComboBoxInputField.SelectedItem.ToString()
            Dim vals = MIColumnProxy.GetUniqueValuesInColumn(tableName, inputField)
            ListBoxAvailableValues.Items.Clear()

            For Each v In vals

                If Not String.IsNullOrEmpty(v.Trim) Then

                    Dim selectedDataRows = GetMatchingDataRows(v)
                    If selectedDataRows.Length = 0 Then
                        Me.ListBoxAvailableValues.Items.Add(v)
                    End If

                End If

            Next

        End If

    End Sub


    Private Sub DeleteSelectedRows()

        Dim numSelected = DataGridViewDefinedGroups.SelectedRows().Count
        If numSelected = 0 Then
            ' nothing to do
            Return
        End If

        Dim selectedRows As DataGridViewRow() = New DataGridViewRow(numSelected - 1) {}
        DataGridViewDefinedGroups.SelectedRows().CopyTo(selectedRows, 0)

        For Each dgr In selectedRows
            DataGridViewDefinedGroups.Rows.Remove(dgr)
        Next

    End Sub


    Private Sub ShowGroupsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonShowGroups.Click
        Try

            If Not m_groupTableForm Is Nothing Then
                m_groupTableForm = New FormShowGroups()
                m_groupTableForm.Show()
            End If



            m_groupTableForm.GroupMapping = m_groupMapping
            m_groupTableForm.Refresh()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub PickMapInfoTableControl1_SelectedTableChanged(ByVal sender As PickMapInfoTableControl, ByVal tableName As String) Handles PickMapInfoTableControl1.SelectedTableChanged

        Try
            OnTableChanged()
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub ListBoxAvailableValues_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxAvailableValues.SelectedIndexChanged
        If ListBoxAvailableValues.Text.Length > 50 Then
            MyToolTip.SetToolTip(ListBoxAvailableValues, ListBoxAvailableValues.Text)
        End If

    End Sub

    Private Sub ListBoxSelectedValues_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBoxSelectedValues.SelectedIndexChanged
        If ListBoxSelectedValues.Text.Length > 50 Then
            MyToolTip.SetToolTip(ListBoxSelectedValues, ListBoxSelectedValues.Text)
        End If

    End Sub


    Private Sub ButtonSaveGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonSaveGroups.Click

        Dim saveFileDialog1 As New SaveFileDialog()

        saveFileDialog1.Filter = "xml files (*.xml)|*.xml"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True

        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            m_groupMapping.WriteXml(saveFileDialog1.FileName)
        End If



    End Sub

    Private Sub ButtonUseExistingGroups_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUseExistingGroups.Click

        Dim openFileDialog1 As New OpenFileDialog()

        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "xml files (*.xml)|*.xml"
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                Dim validator As New XsdSchemaValidator
                validator.Validate(New FileInfo(openFileDialog1.FileName), GetSchema)
                If validator.HasErrors Then
                    Dim sb As New StringBuilder
                    For Each Errs In validator.Errors
                        sb.AppendLine(Errs)
                    Next
                    MessageBox.Show(sb.ToString)
                Else
                    m_groupMapping.Clear()
                    m_groupMapping.ReadXml(openFileDialog1.FileName)
                    For Each item As DataRow In m_groupMapping.Rows
                        Dim value = item(COLUMN_VALUE)
                        If ListBoxAvailableValues.Items.Contains(value) Then
                            ListBoxAvailableValues.Items.Remove(value)
                        End If
                    Next
                End If

            Catch Ex As Exception
                MessageBox.Show(Ex.Message)
            Finally

            End Try
        End If
    End Sub

    Private Function GetSchema() As XmlSchema

        Dim schema = <?xml version="1.0" encoding="utf-8"?>
                     <xs:schema id="DocumentElement" xmlns="" xmlns:xs="http://www.w3.org/2001/XMLSchema" xmlns:msdata="urn:schemas-microsoft-com:xml-msdata">
                         <xs:element name="DocumentElement" msdata:IsDataSet="true" msdata:Locale="en-US">
                             <xs:complexType>
                                 <xs:choice minOccurs="0" maxOccurs="unbounded">
                                     <xs:element name="groups">
                                         <xs:complexType>
                                             <xs:sequence>
                                                 <xs:element name="group" type="xs:string"/>
                                                 <xs:element name="value" type="xs:string"/>
                                             </xs:sequence>
                                         </xs:complexType>
                                     </xs:element>
                                 </xs:choice>
                             </xs:complexType>
                         </xs:element>
                     </xs:schema>

        Return XmlSchema.Read(schema.CreateReader, Nothing)

    End Function
End Class