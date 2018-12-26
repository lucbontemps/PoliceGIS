' System namespaces
Imports System.ComponentModel
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms
Imports System.Xml

' GIM namespaces
Imports Gim.ErrorHandling
Imports <xmlns="http://schemas.gim.be/PoliceGIS/PoliceGisConfiguration.xsd">


''' <summary>
''' Form for the analysis module
''' There are two modes:  traffic analysis and crime analysis.
''' Some analysis functions are only available in one of the modes and not the other.
''' </summary>
''' <remarks></remarks>
Public Class FormAnalysis

    'Private MapBasicInterop As New MapBasicInterop
    Private m_tables As New List(Of String)
    Private m_xDdocument As XDocument
    Private m_interessegebieden As List(Of InteresseGebied)
    Private m_isCrimeAnalysis As Boolean
    Private m_configManager As PGISConfigurationManager


    Public Property Configuration() As PGISConfigurationManager
        Get
            Return m_configManager
        End Get
        Set(ByVal value As PGISConfigurationManager)
            m_configManager = value
        End Set
    End Property


    Public Property IsCrimeAnalysis() As Boolean
        Get
            Return m_isCrimeAnalysis
        End Get
        Set(ByVal value1 As Boolean)
            m_isCrimeAnalysis = value1
            If m_isCrimeAnalysis Then
                Dim anaLyseTypes = From at In m_xDdocument...<analyseTypes>.Elements Where at.Value <> m_xDdocument...<analyseTypes>.<Controles>.Value Select at.Value
                AnalysisTypeComboBox.DataSource = anaLyseTypes.ToList
                m_configManager.AreaSettings.TypeAnalyse = My.Resources.CriminalType
            Else
                Dim anaLyseTypes = From at In m_xDdocument...<analyseTypes>.Elements Where at.Value <> m_xDdocument...<analyseTypes>.<crime_series>.Value Select at.Value
                AnalysisTypeComboBox.DataSource = anaLyseTypes.ToList
                m_configManager.AreaSettings.TypeAnalyse = My.Resources.TrafficType
            End If

        End Set
    End Property



    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        SetMapInfoTables()

        ' Add any initialization after the InitializeComponent() call.
        InitializeApplication(True)


    End Sub

    Public Sub InitializeApplication(ByVal setGebieden As Boolean)


        Me.Icon = GuiThemeProvider.GetPoliceIcon
        If Not Me.Text.Contains(My.Resources.GIMPoliceGis) Then
            Me.Text = String.Format("{0}{1}", Me.Text, My.Resources.GIMPoliceGis)
        End If

        Me.Icon = GuiThemeProvider.GetPoliceIcon

        m_configManager = PGISConfigurationManager.GetInstance

        If Not m_configManager.ValidationReport.IsValid Then

            Dim errorForm As New FormConfigurationErrors()
            errorForm.Report = m_configManager.ValidationReport
            errorForm.ShowDialog()
            ' Can't continue close form
            Me.Close()
        Else

            m_xDdocument = XDocument.Load(m_configManager.ConfigFile.FullName)

            If setGebieden Then
                m_configManager.ReadBasicSettings()
                SetInteresseGebieden()
            End If



            UpdateFieldControls(MyPickMapInfoTableControl.SelectedTable)
            MyQueryBuilderControl.Enabled = MyPickMapInfoTableControl.SelectedIndex >= 0

        End If
        Me.BringToFront()

    End Sub

    Private Sub UpdateFieldControls(ByVal tableName As String)

        ParamColumnListBox.Items.Clear()

        If Not String.IsNullOrEmpty(tableName) Then

            ParamColumnListBox.Items.AddRange(MITableProxy.ListColumnNames(tableName).ToArray)

        End If

    End Sub

    Private Sub MyPickMapInfoTableControl_SelectedTableChanged(ByVal sender As PickMapInfoTableControl, ByVal tableName As String) Handles MyPickMapInfoTableControl.SelectedTableChanged

        Try
            If MITableProxy.ListTableNames.Contains(tableName) Then

                MyQueryBuilderControl.Enabled = True
                MyQueryBuilderControl.InputTable = tableName
                m_configManager.AreaSettings.islpTable = tableName

                m_configManager.AreaSettings.islpFile = MITableProxy.GetTableInfo(m_configManager.AreaSettings.islpTable, MapBasicConstants.TAB_INFO_TABFILE)

                InitializeApplication(False)

            Else

            m_configManager.AreaSettings.islpTable = Nothing

            SetMapInfoTables()

            MainTabControl.SelectTab(TabelTabPage)
                MyQueryBuilderControl.Clear()
                MyQueryBuilderControl.Enabled = False
            End If


        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub GenereerKaartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GenereerKaartButton.Click

        Try

            Dim uniqueColumnValues As New List(Of String)
            AnalyseErrorProvider.Tag = True 'No errors

            If KolomRadioButton.Checked Then
                If String.IsNullOrEmpty(TryCast(ParamColumnListBox.SelectedItem, String)) Then

                    AnalyseErrorProvider.SetError(ParamColumnListBox, My.Resources.ExceptionMessages.NoValidColumn)
                    AnalyseErrorProvider.Tag = False

                Else

                    uniqueColumnValues = MIColumnProxy.GetUniqueValuesInColumn(MyPickMapInfoTableControl.SelectedTable, TryCast(ParamColumnListBox.SelectedItem, String))

                End If

            End If

            If CType(AnalyseErrorProvider.Tag, Boolean) Then

                For Each item In AreasListBox.SelectedItems
                    Dim interessegebied = CType(item, InteresseGebied)
                    m_configManager.SetAreaSettings(interessegebied)

                    Select Case AnalysisTypeComboBox.SelectedItem.ToString

                        Case m_xDdocument...<analyseTypes>.<point>.Value

                            Dim pointController As New PointAnalysisController
                            pointController.GeneratePointAnalysis(m_configManager.AreaSettings, uniqueColumnValues, TryCast(ParamColumnListBox.SelectedItem, String), Me.IsCrimeAnalysis)

                        Case m_xDdocument...<analyseTypes>.<street>.Value

                            Dim streetController As New AnalysisPerStreetController
                            streetController.GenerateAnalysisPerStreet(m_configManager.AreaSettings, Me.IsCrimeAnalysis)

                        Case m_xDdocument...<analyseTypes>.<area>.Value

                            Dim areaController As New AnalysisPerAreasController
                            Dim columnForPie As String

                            If AantalFeitenRadioButton.Checked Or InkleurenRadioButton.Checked Then
                                columnForPie = Nothing
                            Else
                                columnForPie = ParamColumnListBox.SelectedItem.ToString()
                                If String.IsNullOrEmpty(columnForPie) Then
                                    AnalyseErrorProvider.SetError(ParamColumnListBox, My.Resources.ExceptionMessages.NoValidColumn)
                                End If
                            End If

                            If AggregationLevelListBox2.SelectedItem IsNot Nothing Then

                                Dim dataFolder = m_configManager.FileSettings.DataFolder

                                Select Case AggregationLevelListBox2.SelectedItem.ToString

                                    Case m_xDdocument...<aggregationLevels>.<commune>.Value
                                        With m_configManager.AreaSettings
                                            .PieAggregationTable = String.Format("{0}_L2", interessegebied.NaamStreep)
                                            .pieAggregationFile = String.Format("{0}\basiskaarten\{1}\{1}_L2.tab", dataFolder, .Area)
                                        End With

                                    Case m_xDdocument...<aggregationLevels>.<quarter>.Value
                                        With m_configManager.AreaSettings


                                            .PieAggregationTable = String.Format("{0}_L3", interessegebied.NaamStreep)
                                            .pieAggregationFile = String.Format("{0}\basiskaarten\{1}\{1}_L3.tab", dataFolder, .Area)
                                        End With
                                    Case Else
                                        With m_configManager.AreaSettings

                                            .PieAggregationTable = String.Format("{0}", interessegebied.NaamStreep)
                                            .pieAggregationFile = String.Format("{0}\basiskaarten\{1}\{1}.tab", dataFolder, .Area)
                                        End With
                                End Select

                            End If

                            areaController.GenerateAnalysisPerArea(m_configManager.AreaSettings, _
                                                                   uniqueColumnValues, _
                                                                   columnForPie, _
                                                                   InkleurenRadioButton.Checked, _
                                                                   Me.IsCrimeAnalysis)


                        Case m_xDdocument...<analyseTypes>.<Controles>.Value

                            Dim controlController As New ControlAnalysisController
                            controlController.GenerateAnalysis(m_configManager.AreaSettings, TryCast(ParamColumnListBox.SelectedItem, String), Me.IsCrimeAnalysis)

                        Case m_xDdocument...<analyseTypes>.<crime_series>.Value

                            Dim serieController As New CrimeSeriesController
                            serieController.GenerateCrimeAnalysis(m_configManager.AreaSettings, PickCrimeSerieFields1.CrimeSerieFields, Me.IsCrimeAnalysis)

                    End Select
                Next

            End If

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Private Function AbsolutePathForData(ByVal inputPath As String) As String

        If System.IO.Path.IsPathRooted(inputPath) Then
            Return inputPath
        Else
            Return System.IO.Path.Combine(m_configManager.FileSettings.DataFolder, inputPath)
        End If

    End Function


    Private Sub PuntenIntekenenButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PuntenIntekenenButton.Click

        AnalyseBlackPoints(Nothing)
 

    End Sub

    Private Sub AnalyseBlackPoints(ByVal fileName As String)
        Try

            Dim uniqueColumnValues As New List(Of String)
            AnalyseErrorProvider.Tag = True 'No errors

            If KolomRadioButton.Checked Then
                If String.IsNullOrEmpty(TryCast(ParamColumnListBox.SelectedItem, String)) Then

                    AnalyseErrorProvider.SetError(ParamColumnListBox, My.Resources.ExceptionMessages.NoValidColumn)
                    AnalyseErrorProvider.Tag = False

                Else

                    uniqueColumnValues = MIColumnProxy.GetUniqueValuesInColumn(m_configManager.AreaSettings.islpTable, TryCast(ParamColumnListBox.SelectedItem, String))

                End If

            End If

            If CType(AnalyseErrorProvider.Tag, Boolean) Then

                Me.Close()

                Dim thematicField = TryCast(ParamColumnListBox.SelectedItem, String)

                BlackPointAnalysisController.GenerateBlackPointAnalysis(m_configManager.AreaSettings, uniqueColumnValues, thematicField, Me.IsCrimeAnalysis, fileName)

            End If

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)

        End Try
    End Sub

    Private Sub AnalysisTypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalysisTypeComboBox.SelectedIndexChanged
        Try

            If MITableProxy.ListTableNames.Contains(m_configManager.AreaSettings.islpTable) Then

                UpdateFieldControls(m_configManager.AreaSettings.islpTable)

            Else

                m_configManager.AreaSettings.islpTable = Nothing

                SetMapInfoTables()

                MainTabControl.SelectTab(TabelTabPage)

            End If

            ParameterGroupBox.Enabled = False
            ParameterGroupBox.Visible = True
            InkleurenRadioButton.Enabled = False
            AantalFeitenRadioButton.Enabled = False
            AantalFeitenRadioButton.Checked = True
            AggregatieGroupBox.Visible = False
            PuntenIntekenenButton.Visible = False
            ButtonUseExisitingBP.Visible = False
            GenereerKaartButton.Enabled = True

            PickCrimeSerieFields1.Visible = False
            AnalyseErrorProvider.Clear()
            AnalyseErrorProvider.Tag = True 'No errors


            Select Case AnalysisTypeComboBox.SelectedItem.ToString

                Case m_xDdocument...<analyseTypes>.<point>.Value

                    ParameterGroupBox.Enabled = True
                    KolomRadioButton.Checked = True

                Case m_xDdocument...<analyseTypes>.<street>.Value

                Case m_xDdocument...<analyseTypes>.<area>.Value

                    ParameterGroupBox.Enabled = True
                    ParamColumnListBox.Enabled = False
                    InkleurenRadioButton.Enabled = True
                    AantalFeitenRadioButton.Enabled = True

                    If AggregationLevelListBox2.Items.Count > 0 Then
                        AggregatieGroupBox.Visible = True
                    End If

                Case m_xDdocument...<analyseTypes>.<black_points>.Value

                    ParameterGroupBox.Enabled = True
                    AantalFeitenRadioButton.Enabled = True
                    ButtonUseExisitingBP.Visible = True
                    PuntenIntekenenButton.Visible = True
                    GenereerKaartButton.Enabled = False

                Case m_xDdocument...<analyseTypes>.<Controles>.Value

                    ParameterGroupBox.Enabled = True
                    KolomRadioButton.Checked = True

                    If m_configManager.AreaSettings.islpTable IsNot Nothing Then
                        ShowOnlyNumericColumns(m_configManager.AreaSettings.islpTable)

                    End If

                Case m_xDdocument...<analyseTypes>.<crime_series>.Value
                    ParameterGroupBox.Visible = False
                    PickCrimeSerieFields1.Visible = True
                    If m_configManager.AreaSettings.islpTable IsNot Nothing Then
                        PickCrimeSerieFields1.TableName = m_configManager.AreaSettings.islpTable
                    End If

            End Select

        Catch ex As Exception

            GenericExceptionHandlingForm.ShowException(ex)

        End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Try
            Dim form As New FormConfiguration(Me)

            form.Show()
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Private Sub ShowOnlyNumericColumns(ByVal tableName As String)
        Try

            ParamColumnListBox.Items.Clear()

            For Each column In MITableProxy.ListColumnNames(tableName).ToArray
                If MIColumnProxy.GetColumnType(tableName, column) = MIColumnType.IntegerType _
                Or MIColumnProxy.GetColumnType(tableName, column) = MIColumnType.SmallintType _
                Or MIColumnProxy.GetColumnType(tableName, column) = MIColumnType.FloatType _
                Or MIColumnProxy.GetColumnType(tableName, column) = MIColumnType.DecimalType Then

                    ParamColumnListBox.Items.Add(column)

                End If
            Next
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Private Sub InkleurenRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InkleurenRadioButton.CheckedChanged
        Try
            If InkleurenRadioButton.Checked Then
                ParamColumnListBox.Enabled = False
            Else
                ParamColumnListBox.Enabled = True
            End If
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Private Sub AantalFeitenRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AantalFeitenRadioButton.CheckedChanged
        Try
            If AantalFeitenRadioButton.Checked Then
                ParamColumnListBox.Enabled = False
            Else
                ParamColumnListBox.Enabled = True
            End If
        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Private Sub KolomRadioButton_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KolomRadioButton.CheckedChanged
        Try
            If m_configManager.AreaSettings.islpTable IsNot Nothing AndAlso _
              AnalysisTypeComboBox.SelectedItem.ToString <> m_xDdocument...<analyseTypes>.<point>.Value _
              AndAlso AnalysisTypeComboBox.SelectedItem.ToString <> m_xDdocument...<analyseTypes>.<Controles>.Value Then

                ParamColumnListBox.Items.Clear()
                Dim items = MITableProxy.ListColumnNames(m_configManager.AreaSettings.islpTable).ToArray
                If KolomRadioButton.Checked Then

                    ParamColumnListBox.Enabled = True

                    For Each item In items

                        Dim number = MIColumnProxy.NumberOfUniqueValues(m_configManager.AreaSettings.islpTable, item)
                        If number > 0 And number < 11 Then
                            ParamColumnListBox.Items.Add(item)
                        End If

                    Next

                Else
                    ParamColumnListBox.Enabled = False
                    ParamColumnListBox.Items.AddRange(items)

                End If
            End If

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Private Sub ListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AreasListBox.SelectedIndexChanged
        Try
            Dim interessegebied = CType(AreasListBox.SelectedItem, InteresseGebied)

            m_configManager.SetAreaSettings(interessegebied)
            SetAggregationLevels(interessegebied.Level)

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub SetAggregationLevels(ByVal level As Short)

        AggregationLevelListBox2.Items.Clear()

        Select Case level
            Case 1
                AggregationLevelListBox2.Items.Add(m_xDdocument...<aggregationLevels>.<zone>.Value)
                AggregationLevelListBox2.Items.Add(m_xDdocument...<aggregationLevels>.<commune>.Value)
                If m_interessegebieden.Where(Function(ig) ig.Level = 3).Count > 0 Then
                    AggregationLevelListBox2.Items.Add(m_xDdocument...<aggregationLevels>.<quarter>.Value)
                End If
            Case 2
                AggregationLevelListBox2.Items.Add(m_xDdocument...<aggregationLevels>.<commune>.Value)
                If m_interessegebieden.Where(Function(ig) ig.Level = 3).Count > 0 Then
                    AggregationLevelListBox2.Items.Add(m_xDdocument...<aggregationLevels>.<quarter>.Value)
                End If
            Case Else

        End Select

        If AggregationLevelListBox2.Items.Count > 1 Then
            AggregationLevelListBox2.SelectedIndex = 0
        End If

        If AggregationLevelListBox2.Items.Count > 1 _
            AndAlso AnalysisTypeComboBox.SelectedItem IsNot Nothing _
        AndAlso AnalysisTypeComboBox.SelectedItem.ToString = m_xDdocument...<analyseTypes>.<area>.Value Then
            AggregatieGroupBox.Visible = True

        Else
            AggregatieGroupBox.Visible = False
        End If

    End Sub

    Private Sub MainTabControl_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MainTabControl.SelectedIndexChanged
        If MainTabControl.SelectedTab.Equals(ParametersTabPage) Then
            If String.IsNullOrEmpty(m_configManager.AreaSettings.islpTable) Then
                MessageBox.Show(My.Resources.ExceptionMessages.NoTableSelected)
                MainTabControl.SelectedTab = TabelTabPage
            End If
        End If

    End Sub

    Private Sub MyQueryBuilderControl_SelectedTableChanged() Handles MyQueryBuilderControl.SelectedTableChanged

        m_configManager.AreaSettings.islpTable = MyQueryBuilderControl.OutputTableName
        MITableProxy.SaveTable(m_configManager.AreaSettings.islpTable)
        MITableProxy.SaveAndOpenAsBaseTable(m_configManager.FileSettings.WorkFolder, m_configManager.AreaSettings.islpTable)
        m_configManager.AreaSettings.islpFile = MITableProxy.GetTableInfo(m_configManager.AreaSettings.islpTable, MapBasicConstants.TAB_INFO_TABFILE)
        MyPickMapInfoTableControl.AddTable(m_configManager.AreaSettings.islpTable)
        MyPickMapInfoTableControl.SelectedTable = m_configManager.AreaSettings.islpTable
        Me.BringToFront()

    End Sub


  
    ''' <summary>
    ''' Add name of tables in the current MapInfo session.
    ''' </summary>
    ''' <remarks>Filter tables that have geometry</remarks>
    Private Sub SetMapInfoTables()

        MyPickMapInfoTableControl.ClearTables()
        m_tables.Clear()

        For Each tableName In MITableProxy.ListTableNames()

            If MITableProxy.IsMappable(tableName) Then
                m_tables.Add(tableName)
            End If

        Next

        MyPickMapInfoTableControl.AddTables(m_tables)
    End Sub

    Private Sub SetInteresseGebieden()

        m_interessegebieden = AnalysisCommon.GetInteresseGebieden(m_configManager.AreaSettings.Area)
        AreasListBox.DataSource = m_interessegebieden
        AreasListBox.DisplayMember = My.Resources.DisplayMember
        If AreasListBox.Items.Count > 0 Then
            AreasListBox.SelectedIndex = 0
        End If

    End Sub

    Private Sub ButtonUseExisitingBP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonUseExisitingBP.Click

        Dim openFileDialog1 As New OpenFileDialog()
        Dim tempTablename As String = "tempBPTable"
        openFileDialog1.InitialDirectory = "c:\"
        openFileDialog1.Filter = "tab files (*.tab)|*.tab"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                If Not String.IsNullOrEmpty(openFileDialog1.FileName) Then
                    MITableProxy.OpenTableChecked(tempTablename, openFileDialog1.FileName)
                    If BlackPointAnalysisController.CheckBlackPointTable(tempTablename) Then
                        MITableProxy.CloseTable(tempTablename, False)
                        AnalyseBlackPoints(openFileDialog1.FileName)
                    Else
                        MITableProxy.CloseTable(tempTablename, False)
                        MessageBox.Show(My.Resources.ExceptionMessages.NoValidTable)
                    End If
                End If
            Catch Ex As Exception
                GenericExceptionHandlingForm.ShowException(Ex)
            Finally
                ' Check this again, since we need to make sure we didn't throw an exception on open.

            End Try
        End If
    End Sub
End Class