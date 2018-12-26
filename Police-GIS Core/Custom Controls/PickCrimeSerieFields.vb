Public Class PickCrimeSerieFields

    Private _crimeSerieFields As CrimeSerieFields
    Private _tableName As String


    Public Property TableName() As String
        Get
            Return _tableName
        End Get
        Set(ByVal value As String)
            _tableName = value
            If Not String.IsNullOrEmpty(_tableName) Then
                BindComboBoxen()
            End If
        End Set
    End Property


    Public Property CrimeSerieFields() As CrimeSerieFields
        Get
            Return _crimeSerieFields
        End Get
        Set(ByVal value As CrimeSerieFields)
            _crimeSerieFields = value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        _crimeSerieFields = New CrimeSerieFields

    End Sub

    Private Sub BindComboBoxen()
        LaagsteDatumComboBox.DataSource = GetDateFields()
        HoogsteDatumComboBox.DataSource = GetDateFields()
        HoogsteUurComboBox.DataSource = GetTimeFields()
        LaagsteUurComboBox.DataSource = GetTimeFields()
        CrimeSerieFields.MaxDistance = CInt(MaxAfstandNumericUpDown.Value)
        CrimeSerieFields.MaxTimeSpanHours = CInt(MaxTijdNumericUpDown.Value)
        CrimeSerieFields.MaxGapHours = CInt(MaxTijdTussenNumericUpDown.Value)
    End Sub

    Private Function GetTimeFields() As List(Of String)
        Dim list As New List(Of String)
        For Each field In MITableProxy.ListColumnNames(TableName)
            If MIColumnProxy.GetColumnType(TableName, field) = MIColumnType.TimeType Then
                list.Add(field)
            End If
        Next
        Return list
    End Function


    Private Function GetDateFields() As List(Of String)
        Dim list As New List(Of String)
        For Each field In MITableProxy.ListColumnNames(TableName)
            If MIColumnProxy.GetColumnType(TableName, field) = MIColumnType.DateType Then
                list.Add(field)
            End If
        Next
        Return list
    End Function

    Private Sub CrimeSerieFieldsChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) _
                                        Handles LaagsteDatumComboBox.SelectedIndexChanged, _
                                        LaagsteUurComboBox.SelectedIndexChanged, _
                                        HoogsteDatumComboBox.SelectedIndexChanged, _
                                        HoogsteUurComboBox.SelectedIndexChanged, _
                                        MaxAfstandNumericUpDown.ValueChanged, _
                                        MaxTijdNumericUpDown.ValueChanged, _
                                        MaxTijdTussenNumericUpDown.ValueChanged

        If CrimeSerieFields IsNot Nothing Then
            If sender.Equals(LaagsteDatumComboBox) Then
                If LaagsteDatumComboBox.Items.Count > 0 Then
                    CrimeSerieFields.StartDate = LaagsteDatumComboBox.SelectedItem.ToString
                End If

            ElseIf sender.Equals(LaagsteUurComboBox) Then
                If LaagsteUurComboBox.Items.Count > 0 Then
                    CrimeSerieFields.StartTime = LaagsteUurComboBox.SelectedItem.ToString
                End If
            ElseIf sender.Equals(HoogsteDatumComboBox) Then

                If HoogsteDatumComboBox.Items.Count > 0 Then
                    CrimeSerieFields.EndDate = HoogsteDatumComboBox.SelectedItem.ToString
                End If

            ElseIf sender.Equals(HoogsteUurComboBox) Then

                If HoogsteUurComboBox.Items.Count > 0 Then
                    CrimeSerieFields.EndTime = HoogsteUurComboBox.SelectedItem.ToString
                End If

            ElseIf sender.Equals(MaxAfstandNumericUpDown) Then
                CrimeSerieFields.MaxDistance = CInt(MaxAfstandNumericUpDown.Value)
            ElseIf sender.Equals(MaxTijdNumericUpDown) Then
                CrimeSerieFields.MaxTimeSpanHours = CInt(MaxTijdNumericUpDown.Value)
            ElseIf sender.Equals(MaxTijdTussenNumericUpDown) Then
                CrimeSerieFields.MaxGapHours = CInt(MaxTijdTussenNumericUpDown.Value)
            End If
        End If



    End Sub



End Class
