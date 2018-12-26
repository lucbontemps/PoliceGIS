
' System namespaces
Imports System.Windows.Forms

' GIM namespaces
Imports Gim.ErrorHandling
Imports Gim.PoliceGis.Core

Public Class SimpleQueryBuilder

    ''' <summary>
    ''' Name of input table
    ''' </summary>
    ''' <remarks></remarks>
    Private m_inputTable As String
    Private m_outputTable As String

    Public Event SelectedTableChanged()

    Private Const QUERY_START As String = "Select * from {0} where: "

#Region " constructors "

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        m_inputTable = ""
        m_outputTable = ""
        UpdateQueryButtons()

    End Sub


#End Region


#Region " properties"


    ''' <summary>
    ''' Name of input table from which you want to select records 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Property InputTable() As String
        Get
            Return m_inputTable
        End Get
        Set(ByVal value As String)

            m_inputTable = value
  
            Me.QueryStartLabel.Text = String.Format(QUERY_START, m_inputTable)

            ' Prevent lookup id at the moment no table is set.
            ' You must clear it in both cases.
            QueryFieldComboBox.Items.Clear()
            QueryFieldComboBox.Text = ""
            If Not String.IsNullOrEmpty(InputTable) Then

                Dim fields = MITableProxy.ListColumnNames(m_inputTable)
                QueryFieldComboBox.Items.AddRange(fields.ToArray)

            End If

        End Set
    End Property

    ''' <summary>
    ''' Name of output table. Is emtpy string when no select query was executed.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property OutputTableName() As String
        Get
            Return m_outputTable
        End Get
    End Property

    ''' <summary>
    ''' Selected field to insert in the query text.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SelectedQueryField() As String
        Get
            If QueryFieldComboBox.SelectedIndex >= 0 Then
                Return QueryFieldComboBox.SelectedItem.ToString
            Else
                Return Nothing
            End If
        End Get
    End Property


    ''' <summary>
    ''' Selected operator to insert in the query text.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SelectedQueryOperator() As String
        Get
            If QueryOperatorComboBox.SelectedIndex >= 0 Then
                Return QueryOperatorComboBox.SelectedItem.ToString
            Else
                Return Nothing
            End If
        End Get
    End Property


    ''' <summary>
    ''' Selected value from a field, to insert in the query text.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ReadOnly Property SelectedQueryValue() As String
        Get
            If QueryValueComboBox.SelectedIndex >= 0 Then
                Return QueryValueComboBox.SelectedItem.ToString
            Else
                Return Nothing
            End If
        End Get
    End Property


#End Region


#Region " Private methods "

    ''' <summary>
    ''' Deletes the query string in the textbox. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub ClearQueryButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClearQueryButton.Click

        Try

            QueryStringTextBox.Text = ""

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Shows a preview af the selection.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub PreviewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewButton.Click

        If Me.QueryStringTextBox.Text.Trim = "" Then
            MessageBox.Show(My.Resources.ErrorCriteriaMsg)
            Exit Sub
        End If

        Dim previewTable = "PREVIEWQUERY"
        Try

            ' This button is only enabled it the query textbox is not empty

            Dim selectionCommand As String = GetCurrentQuery() & " INTO " & previewTable

            If MITableProxy.IsTableOpen(previewTable) Then
                MITableProxy.CloseTable(previewTable, False)
            End If

            MapBasicInterop.ExecuteCommand(selectionCommand)

            ' Open result in a table browser window.
            ' Use FormTableBrowser, a regular browse window in MapInfo 
            ' is not enough, because we want to close the temp table as 
            ' soon as we are done. But this also close the browser in MapInfo.
            Dim frm As New FormTableBrowser()
            frm.DataSource = MITableProxy.FillDataTable(previewTable)
            frm.Show()

        Catch ex As Exception

            GenericExceptionHandlingForm.ShowException(ex)

        Finally

            ' Always close the temporary table

            If Not String.IsNullOrEmpty(previewTable) AndAlso MITableProxy.IsTableOpen(previewTable) Then
                MITableProxy.CloseTable(previewTable, False)
            End If

        End Try

    End Sub


    Private Sub QueryStringTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryStringTextBox.TextChanged

        Try

            ' Update some buttons that depend on the state of the query string.
            UpdateQueryButtons()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub QueryResultTableTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutputTableTextBox.TextChanged

        Try

            If MITableProxy.IsValidTableName(OutputTableTextBox.Text) Then
                MyErrorProvider.SetError(OutputTableTextBox, "")
            Else
                MyErrorProvider.SetError(OutputTableTextBox, My.Resources.ErrorNoValidTableName)
            End If

            UpdateQueryButtons()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub TableComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

        Try

            UpdateFields()
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub UpdateFields()

        Dim fields = MITableProxy.ListColumnNames(m_inputTable)
        QueryFieldComboBox.Items.Clear()
        QueryFieldComboBox.Items.AddRange(fields.ToArray)

    End Sub


    Private Sub QueryFieldComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QueryFieldComboBox.SelectedIndexChanged

        Try

            UpdateQueryAvailableValues()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try


    End Sub


    Private Sub UpdateQueryAvailableValues()

        If Not String.IsNullOrEmpty(m_inputTable) _
            And QueryFieldComboBox.SelectedIndex >= 0 Then

            Dim selectedField = QueryFieldComboBox.SelectedItem.ToString()
            Dim vals = MIColumnProxy.GetUniqueValuesInColumn(m_inputTable, selectedField)
            QueryValueComboBox.Items.Clear()
            QueryValueComboBox.Text = ""

            For Each v In vals

                If Not String.IsNullOrEmpty(v.Trim) Then
                    QueryValueComboBox.Items.Add(MapBasicInterop.EscapeString(v))
                End If

            Next

        End If

    End Sub

    ''' <summary>
    ''' Insert selected field into the query string.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AddFieldButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddFieldButton.Click

        Try

            Dim fld As String = SelectedQueryField
            If Not String.IsNullOrEmpty(fld) Then
                AddTextToQuery(fld)
            End If

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Insert selected operator into the query string.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AddOperatorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddOperatorButton.Click

        Try

            Dim op As String = SelectedQueryOperator
            If Not String.IsNullOrEmpty(op) Then
                AddTextToQuery(op)
            End If

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Insert selected value from a column into the query string.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub AddValueButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddValueButton.Click

        Try

            Dim val As String = SelectedQueryValue
            If Not String.IsNullOrEmpty(val) Then

                If MIColumnProxy.ColumnNeedsQuotes(m_inputTable, SelectedQueryField) Then
                    val = """" & MapBasicInterop.EscapeString(val) & """"
                End If

                AddTextToQuery(val)

            End If

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    ''' <summary>
    ''' Insert text into the query string, at the position of the cursor 
    ''' in the textbox.
    ''' </summary>
    ''' <param name="text"></param>
    ''' <remarks></remarks>
    Private Sub AddTextToQuery(ByVal text As String)

        Dim origStart = QueryStringTextBox.SelectionStart
        ' Add some white space around the value, so it does not "stick" to the other text.
        text = " " & text & " "

        If QueryStringTextBox.SelectionLength = 0 Then
            Dim newText = QueryStringTextBox.Text.Insert(QueryStringTextBox.SelectionStart, text)
            QueryStringTextBox.Text = newText
        Else

            Dim toLeft = QueryStringTextBox.Text.Substring(0, origStart)
            Dim toRight = QueryStringTextBox.Text.Substring(origStart + QueryStringTextBox.SelectionLength)
            Dim newText = toLeft & text & toRight
            QueryStringTextBox.Text = newText

        End If

        QueryStringTextBox.SelectionStart = origStart + text.Length

    End Sub

    ''' <summary>
    ''' Executes the select query.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub DoQueryButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles DoQueryButton.Click

        Try

            ' This button is only enabled it the query textbox is not empty

            Dim resultTable As String = Me.OutputTableTextBox.Text

            MITableProxy.IfTableOpenCloseTable(resultTable)

            Dim selectionCommand As String = GetCurrentQuery() & " INTO " & resultTable

            MapBasicInterop.ExecuteCommand(selectionCommand)

            ' Query is now executed, store the name out the output table, 
            ' so the client code can retrieve the table name.
            m_outputTable = resultTable
            MessageBox.Show(String.Format(My.Resources.SelectionSavedIn, m_outputTable))
            RaiseEvent SelectedTableChanged()
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    ''' <summary>
    ''' Get the full query text.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCurrentQuery() As String

        Return "Select * From " & m_inputTable & " WHERE " & QueryStringTextBox.Text

    End Function

    ''' <summary>
    ''' Refresh some buttons, according to the state of the query string.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UpdateQueryButtons()

        If String.IsNullOrEmpty(QueryStringTextBox.Text) Then

            PreviewButton.Enabled = False
            ClearQueryButton.Enabled = False
            DoQueryButton.Enabled = False

        Else

            PreviewButton.Enabled = True
            ClearQueryButton.Enabled = True

            If MITableProxy.IsValidTableName(OutputTableTextBox.Text) Then
                DoQueryButton.Enabled = True
            Else
                DoQueryButton.Enabled = False
            End If

        End If

    End Sub

#End Region
    Public Sub Clear()
        QueryStringTextBox.Text = ""
        InputTable = ""
        OutputTableTextBox.Text = ""
        QueryFieldComboBox.Text = ""
        QueryOperatorComboBox.Text = ""
        QueryValueComboBox.Text = ""
    End Sub



End Class
