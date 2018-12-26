
Imports Gim.ErrorHandling

Public Class PickGeocodingFieldsControl

    Public Enum FieldRoles As Integer
        Street1
        Street2
        Number
        Municipality
        HectoMeterPole
    End Enum

    Public Event GeocodingFieldsChanged(ByVal Sender As PickGeocodingFieldsControl, ByVal e As EventArgs)

    Private m_geocodingFields As GeoCodingFields
    Private m_fieldsBound As Boolean
    Private m_fields As List(Of String)
    Private m_allFieldsReady As Boolean
    Private m_candidateFields As Dictionary(Of FieldRoles, List(Of String))


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    Public Sub ReadSettings(ByVal geocSettings As PGISGeocodingSettings)


        If geocSettings.MaxStreetLength > 0 Then
            Me.MaxStreetLength = geocSettings.MaxStreetLength
            MaxStreetLengthCheckBox.Checked = True
        Else
            MaxStreetLengthCheckBox.Checked = False
        End If
        Me.MaxStreetLengthNumericUD.Enabled = MaxStreetLengthCheckBox.Checked


        ' Add any initialization after the InitializeComponent() call.
        m_candidateFields = New Dictionary(Of FieldRoles, List(Of String))
        m_candidateFields.Add(FieldRoles.Street1, New List(Of String))
        m_candidateFields.Add(FieldRoles.Street2, New List(Of String))
        m_candidateFields.Add(FieldRoles.Number, New List(Of String))
        m_candidateFields.Add(FieldRoles.Municipality, New List(Of String))
        m_candidateFields.Add(FieldRoles.HectoMeterPole, New List(Of String))

        For Each field As String In geocSettings.Street1FieldCandidates
            m_candidateFields(FieldRoles.Street1).Add(field.ToUpper)
        Next

        For Each field As String In geocSettings.Street2FieldCandidates
            m_candidateFields(FieldRoles.Street2).Add(field.ToUpper)
        Next

        For Each field As String In geocSettings.NumberFieldCandidates
            m_candidateFields(FieldRoles.Number).Add(field.ToUpper)
        Next

        For Each field As String In geocSettings.MunicipalityFieldCandidates
            m_candidateFields(FieldRoles.Municipality).Add(field.ToUpper)
        Next

        ' If there is not hectometer pole layer we don't allow to use it in the GUI.
        If geocSettings.HectoMeterPolesEnabled Then

            For Each field As String In geocSettings.HectoMeterFieldCandidates
                m_candidateFields(FieldRoles.HectoMeterPole).Add(field.ToUpper)
            Next

            Me.HectoMeterCheckBox.Enabled = True

        Else
            Me.HectoMeterCheckBox.Checked = False
            Me.HectoMeterCheckBox.Enabled = False
        End If

        HectometerComboBox.Enabled = HectoMeterCheckBox.Checked
        OnGeocodingFieldsChanged()

    End Sub


    Public Sub ClearCandidateFields()

        For Each k In m_candidateFields.Keys
            ClearCandidateFields(k)
        Next

    End Sub

    Public Sub ClearCandidateFields(ByVal role As FieldRoles)
        m_candidateFields(role).Clear()
    End Sub

    Private Function GetCandidateFields(ByVal role As FieldRoles) As List(Of String)
        Return m_candidateFields(role)
    End Function


    'Private Sub AddCandidateFields(ByVal role As FieldRoles, ByVal name As String)
    '    m_candidateFields(role).Add(name.ToUpper)
    'End Sub

    Public Property AllFieldsReady() As Boolean
        Get
            Return m_allFieldsReady
        End Get
        Set(ByVal value As Boolean)
            m_allFieldsReady = value
        End Set
    End Property

    Public Property Fields() As List(Of String)
        Get
            Return m_fields
        End Get
        Set(ByVal value As List(Of String))

            If value IsNot Nothing Then
                m_fields = value
                BindComboboxen()
            End If

        End Set
    End Property

    Public Property MiGeocodingFields() As GeoCodingFields
        Get
            Return m_geocodingFields
        End Get
        Set(ByVal value As GeoCodingFields)
            m_geocodingFields = value
        End Set
    End Property

    Public Property MaxStreetLength() As Integer
        Get
            Return Decimal.ToInt32(MaxStreetLengthNumericUD.Value)
        End Get
        Set(ByVal value As Integer)

            If value < 0 Then
                Throw ExceptionProvider.ArgumentOutOfRange("MaxStreetLength", MaxStreetLength, "MaxStreetLength should be > 0 or = 0 .")
            End If

            MaxStreetLengthNumericUD.Value = Convert.ToDecimal(value)

        End Set
    End Property

    Private Sub BindComboboxen()

        m_fieldsBound = False

        MiGeocodingFields = FindGeocodingFields()

        With StreetComboBox

            .BindingContext = New Windows.Forms.BindingContext
            .DataSource = Fields

            If MiGeocodingFields.Street IsNot Nothing Then
                .SelectedItem = MiGeocodingFields.Street
                StreetFoundLabel.Text = My.Resources.Found
            Else
                StreetFoundLabel.Text = My.Resources.NotFound
            End If

        End With

        With NumberComboBox

            .BindingContext = New Windows.Forms.BindingContext
            .DataSource = Fields

            If MiGeocodingFields.Number IsNot Nothing Then
                .SelectedItem = MiGeocodingFields.Number
                NumberFoundLabel.Text = My.Resources.Found
            Else
                NumberFoundLabel.Text = My.Resources.NotFound
            End If

        End With

        With CityComboBox

            .BindingContext = New Windows.Forms.BindingContext
            .DataSource = Fields

            If MiGeocodingFields.City IsNot Nothing Then
                .SelectedItem = MiGeocodingFields.City
                CityFoundLabel.Text = My.Resources.Found
            Else
                CityFoundLabel.Text = My.Resources.NotFound
            End If

        End With

        With HectometerComboBox

            .BindingContext = New Windows.Forms.BindingContext
            .DataSource = Fields

            If MiGeocodingFields.HectoMeterPole IsNot Nothing Then
                .SelectedItem = MiGeocodingFields.HectoMeterPole
                HectometerFoundLabel.Text = My.Resources.Found
            Else
                HectometerFoundLabel.Text = My.Resources.NotFound
            End If

        End With

        With IntersectionComboBox

            .BindingContext = New Windows.Forms.BindingContext
            .DataSource = Fields

            If MiGeocodingFields.Intersection IsNot Nothing Then
                .SelectedItem = MiGeocodingFields.Intersection
                IntersectionFoundLabel.Text = My.Resources.Found
            Else
                IntersectionFoundLabel.Text = My.Resources.NotFound
            End If

        End With
        m_fieldsBound = True
        OnGeocodingFieldsChanged()

    End Sub


    Private Function FindGeocodingFields() As GeoCodingFields

        Dim mgeocodingFields As New GeoCodingFields

        Dim street1Candidates = GetCandidateFields(FieldRoles.Street1)
        Dim streetFieldMatches = From veld In m_fields Select veld Where street1Candidates.Contains(veld.ToUpper)
        If streetFieldMatches.Count > 0 Then
            mgeocodingFields.Street = streetFieldMatches.First
        End If


        Dim municipalityCandidates = GetCandidateFields(FieldRoles.Municipality)
        Dim cityFieldMatches = From veld In m_fields Select veld Where municipalityCandidates.Contains(veld.ToUpper)
        If cityFieldMatches.Count > 0 Then
            mgeocodingFields.City = cityFieldMatches.First
        End If


        Dim numberCandidates = GetCandidateFields(FieldRoles.Number)
        Dim numberField = From veld In m_fields Select veld Where numberCandidates.Contains(veld.ToUpper)
        If numberField.Count > 0 Then
            mgeocodingFields.Number = numberField.First
        End If


        Dim hectometerCandidates = GetCandidateFields(FieldRoles.HectoMeterPole)
        Dim hectometerFieldMatches = From veld In m_fields Select veld Where hectometerCandidates.Contains(veld.ToUpper)
        If hectometerFieldMatches.Count > 0 Then
            mgeocodingFields.HectoMeterPole = hectometerFieldMatches.First
        End If


        Dim intersectionCandidates = GetCandidateFields(FieldRoles.Street2)
        Dim intersectionFieldmatches = From veld In m_fields Select veld Where intersectionCandidates.Contains(veld.ToUpper)
        If intersectionFieldmatches.Count > 0 Then
            mgeocodingFields.Intersection = intersectionFieldmatches.First
        End If

        Return mgeocodingFields

    End Function


    Private Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) _
                                            Handles HectometerComboBox.SelectedIndexChanged, _
                                                    StreetComboBox.SelectedIndexChanged, _
                                                    NumberComboBox.SelectedIndexChanged, _
                                                    CityComboBox.SelectedIndexChanged, _
                                                    IntersectionComboBox.SelectedIndexChanged

        Try

            If m_fieldsBound Then

                If sender.Equals(StreetComboBox) Then

                    If StreetComboBox.SelectedItem.ToString <> MiGeocodingFields.Street Then
                        StreetFoundLabel.Text = My.Resources.Changed
                        MiGeocodingFields.Street = StreetComboBox.SelectedItem.ToString
                    End If

                ElseIf sender.Equals(NumberComboBox) Then

                    If NumberComboBox.SelectedItem.ToString <> MiGeocodingFields.Number Then
                        NumberFoundLabel.Text = My.Resources.Changed
                        MiGeocodingFields.Number = NumberComboBox.SelectedItem.ToString
                    End If

                ElseIf sender.Equals(CityComboBox) Then

                    If CityComboBox.SelectedItem.ToString <> MiGeocodingFields.City Then
                        CityFoundLabel.Text = My.Resources.Changed
                        MiGeocodingFields.City = CityComboBox.SelectedItem.ToString
                    End If

                ElseIf sender.Equals(HectometerComboBox) Then

                    If HectometerComboBox.SelectedItem.ToString <> MiGeocodingFields.HectoMeterPole Then
                        HectometerFoundLabel.Text = My.Resources.Changed
                        MiGeocodingFields.HectoMeterPole = HectometerComboBox.SelectedItem.ToString
                    End If

                ElseIf sender.Equals(IntersectionComboBox) Then

                    If IntersectionComboBox.SelectedItem.ToString <> MiGeocodingFields.Intersection Then
                        IntersectionFoundLabel.Text = My.Resources.Changed
                        MiGeocodingFields.Intersection = IntersectionComboBox.SelectedItem.ToString
                    End If

                End If

            End If

            OnGeocodingFieldsChanged()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Private Sub IntersectionCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IntersectionCheckBox.CheckedChanged

        Try

            IntersectionComboBox.Enabled = IntersectionCheckBox.Checked
            OnGeocodingFieldsChanged()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Private Sub HectoMeterCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HectoMeterCheckBox.CheckedChanged

        Try

            HectometerComboBox.Enabled = HectoMeterCheckBox.Checked
            OnGeocodingFieldsChanged()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Private Sub StandardValuesButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StandardValuesButton.Click

        Try
            MaxStreetLengthNumericUD.Value = CInt(My.Resources.MaxStreetDefault)
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Private Sub SteetDistanceCheckBox_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaxStreetLengthCheckBox.CheckedChanged

        Try
            MaxStreetLengthNumericUD.Enabled = MaxStreetLengthCheckBox.Checked

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub OnGeocodingFieldsChanged()

        m_allFieldsReady = True

        If StreetFoundLabel.Text = My.Resources.NotFound Then
            m_allFieldsReady = False
        End If

        If NumberFoundLabel.Text = My.Resources.NotFound Then
            m_allFieldsReady = False
        End If

        If CityFoundLabel.Text = My.Resources.NotFound _
            Or StreetFoundLabel.Text = My.Resources.NotFound _
            Or NumberFoundLabel.Text = My.Resources.NotFound _
        Then
            m_allFieldsReady = False
        End If

        If HectoMeterCheckBox.Checked Then
            If HectometerFoundLabel.Text = My.Resources.NotFound Then
                m_allFieldsReady = False
            End If
        End If

        If IntersectionCheckBox.Checked Then
            If IntersectionFoundLabel.Text = My.Resources.NotFound Then
                m_allFieldsReady = False
            End If
        End If

        RaiseEvent GeocodingFieldsChanged(Me, Nothing)

    End Sub

    Private Sub NumberLabel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NumberLabel.Click

    End Sub
End Class