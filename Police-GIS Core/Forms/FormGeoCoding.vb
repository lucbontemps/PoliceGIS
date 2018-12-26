Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Windows.Forms

Imports Gim.ErrorHandling
Imports Gim.PoliceGis.Core


''' <summary>
''' Form for the geocoding module.
''' </summary>
''' <remarks></remarks>
Public Class FormGeoCoding

#Region "fields"

    Private m_tempHeadersTable As String = "temp_hdrs"
    '   Private m_miTableName As String = "ISLP_punten"

    Private m_configManager As PGISConfigurationManager
    Private m_geocodingSettings As PGISGeocodingSettings
    Private m_fileSettings As PGISFileSettings

#End Region
 
#Region "constructors"

   
    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Logo of the police is the icon for the window.

        Me.Icon = GuiThemeProvider.GetPoliceIcon
        Me.Text = String.Format("{0} {1}", Me.Text, My.Resources.GIMPoliceGis)

        m_configManager = PGISConfigurationManager.GetInstance
        If Not m_configManager.ValidationReport.IsValid Then

            Dim errorForm As New FormConfigurationErrors()
            errorForm.Report = m_configManager.ValidationReport
            errorForm.ShowDialog()
            ' Can't continue close form
            Me.Close()

        Else

            m_fileSettings = m_configManager.FileSettings
            m_geocodingSettings = m_configManager.GeocodingSettings
            MyGeocodingFieldsControl.ReadSettings(m_geocodingSettings)

        End If

    End Sub


#End Region

#Region "private methods"


    Private Sub BrowseToFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseToFileButton.Click

        '  Dim tempTableProxy As MITableProxy = Nothing

        Try

            ImportFileDialog.InitialDirectory = m_fileSettings.IslpFolder
            ImportFileDialog.Filter = "Excel (*.xls)|*.xls| Excel 2007 (*.xlsx)|*.xlsx| Komma gescheiden (*.csv)|*.csv| Tekst files (*.txt)|*.txt | alle bestanden (*.*)|*.*"
            ImportFileDialog.FileName = ""
            Dim answer = ImportFileDialog.ShowDialog

            If answer = Windows.Forms.DialogResult.OK Then

                Dim inputFile = ImportFileDialog.FileName
                TextBoxFileToImport.Text = inputFile

                ' Fill in the columns on the geocoding columns control
                ShowGeoControl()
                Dim tempDirectory As New DirectoryInfo(m_fileSettings.WorkFolder)
                If tempDirectory Is Nothing Then
                    Throw ExceptionProvider.NullArgException("tempTable")
                Else

                    ' Transparently create the temp directory if it does not yet exist.
                    If Not tempDirectory.Exists Then
                        tempDirectory.Create()
                    End If

                End If

                Dim tempRegisterPath = Path.Combine(tempDirectory.FullName, m_tempHeadersTable & ".tab")
                Dim fields = GeocodingController.ReadHeaderFromInputFile(inputFile, tempRegisterPath)
                MyGeocodingFieldsControl.Fields = New List(Of String)(fields)
                m_geocodingSettings.FieldNames = New List(Of String)(fields)
                MyColumnTypesEditor.SetColumnInfo(tempRegisterPath, fields)

            End If

        Catch ex As Exception

            GenericExceptionHandlingForm.ShowException(ex)

        End Try

    End Sub

    Private Sub AnnuleerButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnnuleerButton.Click
        Me.Close()
    End Sub

    Private Sub ShowGeoControl()
        GeocodingTabControl.Visible = True
        PreviewButton.Visible = True
        OutputLabel.Visible = True
        OutputTabelTextBox.Visible = True
    End Sub

    Private Sub PickGeocodingFieldsControl_GeocodingFieldsChanged(ByVal Sender As PickGeocodingFieldsControl, ByVal e As System.EventArgs) Handles MyGeocodingFieldsControl.GeocodingFieldsChanged

        Try
            StartButton.Enabled = Sender.AllFieldsReady
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click

        Try

            If ParametersReady() Then

                Dim workFolder As New DirectoryInfo(m_fileSettings.WorkFolder)

                GeocodingController.RunGeocoding(m_geocodingSettings, workFolder)

                Me.Close()
            End If

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Private Function ParametersReady() As Boolean

        Dim isValid As Boolean = True

        If String.IsNullOrEmpty(TextBoxFileToImport.Text.Trim) Then

            MyErrorProvider.SetError(TextBoxFileToImport, My.Resources.ExceptionMessages.NotFilled)
            isValid = False
   
        End If

        If String.IsNullOrEmpty(OutputTabelTextBox.Text.Trim) Then

            MyErrorProvider.SetError(OutputTabelTextBox, My.Resources.ExceptionMessages.NotFilled)
            isValid = False
        Else
            If Not MITableProxy.IsValidTableName(OutputTabelTextBox.Text.Trim) Then
                MyErrorProvider.SetError(OutputTabelTextBox, My.Resources.ExceptionMessages.NoValidTableName)
                isValid = False
            End If
        End If

        If Not MyGeocodingFieldsControl.AllFieldsReady Then

            MyErrorProvider.SetError(MyGeocodingFieldsControl, My.Resources.ExceptionMessages.NoColumnsSelected)
            isValid = False

        End If

        If isValid Then
            MyErrorProvider.SetError(TextBoxFileToImport, "")
            MyErrorProvider.SetError(OutputTabelTextBox, "")
            MyErrorProvider.SetError(MyGeocodingFieldsControl, "")

            UpdateGeocodingSettings()

        End If

        Return isValid

    End Function


    Private Sub UpdateGeocodingSettings()

        m_geocodingSettings.InputFile = TextBoxFileToImport.Text.Trim
        m_geocodingSettings.OutputTable = OutputTabelTextBox.Text.Trim

        Dim geocCols = MyGeocodingFieldsControl.MiGeocodingFields
        m_geocodingSettings.InputMunicipalityField = geocCols.City
        m_geocodingSettings.InputStreet1Field = geocCols.Street
        m_geocodingSettings.InputNumberField = geocCols.Number
        m_geocodingSettings.InputStreet2Field = geocCols.Intersection
        m_geocodingSettings.InputHectoMeterField = geocCols.HectoMeterPole

        ' copy the columns tot the geocoding settings
        m_geocodingSettings.ColumnTypes = New List(Of ColumnTypeDescriptor)(MyColumnTypesEditor.Columns)
        If MyGeocodingFieldsControl.MaxStreetLengthNumericUD.Enabled Then
            m_geocodingSettings.MaxStreetLength = MyGeocodingFieldsControl.MaxStreetLength
        Else
            m_geocodingSettings.MaxStreetLength = -1
        End If


    End Sub

#End Region



    Private Sub PreviewButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreviewButton.Click
        Dim tableName = ""
        Try

            Dim tempDirectory As New DirectoryInfo(m_fileSettings.WorkFolder)
            If tempDirectory Is Nothing Then
                Throw ExceptionProvider.NullArgException("tempTable")
            Else

                ' Transparently create the temp directory if it does not yet exist.
                If Not tempDirectory.Exists Then
                    tempDirectory.Create()
                End If

            End If

            Dim tempRegisterPath = Path.Combine(tempDirectory.FullName, m_tempHeadersTable & ".tab")
            tableName = MITableProxy.OpenTable(tempRegisterPath, True)
            'Dim brwsCmd As New BrowseTableCommand(tableProxy.TableName)
            'brwsCmd.Run()

            Dim frm As New FormTableBrowser()
            frm.DataSource = MITableProxy.FillDataTable(tableName)
            frm.Show()

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)

        Finally

            If Not String.IsNullOrEmpty(tableName) Then
                If MITableProxy.IsTableOpen(tableName) Then
                    MITableProxy.CloseTable(tableName, False)
                End If
            End If

        End Try
    End Sub

    Private Sub FormGeoCoding_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
