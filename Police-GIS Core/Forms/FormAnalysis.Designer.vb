<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAnalysis
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAnalysis))
        Dim CrimeSerieFields1 As Gim.PoliceGis.Core.CrimeSerieFields = New Gim.PoliceGis.Core.CrimeSerieFields
        Me.MainTabControl = New System.Windows.Forms.TabControl
        Me.TabelTabPage = New System.Windows.Forms.TabPage
        Me.MyPickMapInfoTableControl = New Gim.PoliceGis.Core.PickMapInfoTableControl
        Me.Button1 = New System.Windows.Forms.Button
        Me.MyQueryBuilderControl = New Gim.PoliceGis.Core.SimpleQueryBuilder
        Me.GebiedenTabPage = New System.Windows.Forms.TabPage
        Me.AnalysisAreaGroupBox = New System.Windows.Forms.GroupBox
        Me.AreasListBox = New System.Windows.Forms.ListBox
        Me.ParametersTabPage = New System.Windows.Forms.TabPage
        Me.ButtonUseExisitingBP = New System.Windows.Forms.Button
        Me.ParameterGroupBox = New System.Windows.Forms.GroupBox
        Me.InkleurenRadioButton = New System.Windows.Forms.RadioButton
        Me.ParamColumnListBox = New System.Windows.Forms.ListBox
        Me.KolomRadioButton = New System.Windows.Forms.RadioButton
        Me.AantalFeitenRadioButton = New System.Windows.Forms.RadioButton
        Me.PuntenIntekenenButton = New System.Windows.Forms.Button
        Me.GenereerKaartButton = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.AnalysisTypeComboBox = New System.Windows.Forms.ComboBox
        Me.AggregatieGroupBox = New System.Windows.Forms.GroupBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.AggregationLevelListBox2 = New System.Windows.Forms.ListBox
        Me.PickCrimeSerieFields1 = New Gim.PoliceGis.Core.PickCrimeSerieFields
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.ComboBox9 = New System.Windows.Forms.ComboBox
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.ComboBox10 = New System.Windows.Forms.ComboBox
        Me.RadioButton11 = New System.Windows.Forms.RadioButton
        Me.RadioButton12 = New System.Windows.Forms.RadioButton
        Me.Label9 = New System.Windows.Forms.Label
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.AnalyseErrorProvider = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.PolitieZoneBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.MainTabControl.SuspendLayout()
        Me.TabelTabPage.SuspendLayout()
        Me.GebiedenTabPage.SuspendLayout()
        Me.AnalysisAreaGroupBox.SuspendLayout()
        Me.ParametersTabPage.SuspendLayout()
        Me.ParameterGroupBox.SuspendLayout()
        Me.AggregatieGroupBox.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        CType(Me.AnalyseErrorProvider, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PolitieZoneBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MainTabControl
        '
        Me.MainTabControl.AccessibleDescription = Nothing
        Me.MainTabControl.AccessibleName = Nothing
        resources.ApplyResources(Me.MainTabControl, "MainTabControl")
        Me.MainTabControl.BackgroundImage = Nothing
        Me.MainTabControl.Controls.Add(Me.TabelTabPage)
        Me.MainTabControl.Controls.Add(Me.GebiedenTabPage)
        Me.MainTabControl.Controls.Add(Me.ParametersTabPage)
        Me.AnalyseErrorProvider.SetError(Me.MainTabControl, resources.GetString("MainTabControl.Error"))
        Me.MainTabControl.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.MainTabControl, CType(resources.GetObject("MainTabControl.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.MainTabControl, CType(resources.GetObject("MainTabControl.IconPadding"), Integer))
        Me.MainTabControl.Name = "MainTabControl"
        Me.MainTabControl.SelectedIndex = 0
        '
        'TabelTabPage
        '
        Me.TabelTabPage.AccessibleDescription = Nothing
        Me.TabelTabPage.AccessibleName = Nothing
        resources.ApplyResources(Me.TabelTabPage, "TabelTabPage")
        Me.TabelTabPage.BackgroundImage = Nothing
        Me.TabelTabPage.Controls.Add(Me.MyPickMapInfoTableControl)
        Me.TabelTabPage.Controls.Add(Me.Button1)
        Me.TabelTabPage.Controls.Add(Me.MyQueryBuilderControl)
        Me.AnalyseErrorProvider.SetError(Me.TabelTabPage, resources.GetString("TabelTabPage.Error"))
        Me.TabelTabPage.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.TabelTabPage, CType(resources.GetObject("TabelTabPage.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.TabelTabPage, CType(resources.GetObject("TabelTabPage.IconPadding"), Integer))
        Me.TabelTabPage.Name = "TabelTabPage"
        Me.TabelTabPage.UseVisualStyleBackColor = True
        '
        'MyPickMapInfoTableControl
        '
        Me.MyPickMapInfoTableControl.AccessibleDescription = Nothing
        Me.MyPickMapInfoTableControl.AccessibleName = Nothing
        resources.ApplyResources(Me.MyPickMapInfoTableControl, "MyPickMapInfoTableControl")
        Me.MyPickMapInfoTableControl.BackColor = System.Drawing.SystemColors.Window
        Me.MyPickMapInfoTableControl.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.MyPickMapInfoTableControl, resources.GetString("MyPickMapInfoTableControl.Error"))
        Me.MyPickMapInfoTableControl.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.MyPickMapInfoTableControl, CType(resources.GetObject("MyPickMapInfoTableControl.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.MyPickMapInfoTableControl, CType(resources.GetObject("MyPickMapInfoTableControl.IconPadding"), Integer))
        Me.MyPickMapInfoTableControl.InitialDirectory = Global.Gim.PoliceGis.Core.My.Resources.Resources.MapsFolder
        Me.MyPickMapInfoTableControl.Name = "MyPickMapInfoTableControl"
        Me.MyPickMapInfoTableControl.SelectedIndex = -1
        Me.MyPickMapInfoTableControl.SelectedTable = Nothing
        '
        'Button1
        '
        Me.Button1.AccessibleDescription = Nothing
        Me.Button1.AccessibleName = Nothing
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.Button1, resources.GetString("Button1.Error"))
        Me.Button1.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.Button1, CType(resources.GetObject("Button1.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.Button1, CType(resources.GetObject("Button1.IconPadding"), Integer))
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MyQueryBuilderControl
        '
        Me.MyQueryBuilderControl.AccessibleDescription = Nothing
        Me.MyQueryBuilderControl.AccessibleName = Nothing
        resources.ApplyResources(Me.MyQueryBuilderControl, "MyQueryBuilderControl")
        Me.MyQueryBuilderControl.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.MyQueryBuilderControl, resources.GetString("MyQueryBuilderControl.Error"))
        Me.MyQueryBuilderControl.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.MyQueryBuilderControl, CType(resources.GetObject("MyQueryBuilderControl.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.MyQueryBuilderControl, CType(resources.GetObject("MyQueryBuilderControl.IconPadding"), Integer))
        Me.MyQueryBuilderControl.InputTable = Global.Gim.PoliceGis.Core.My.Resources.Resources.MapsFolder
        Me.MyQueryBuilderControl.Name = "MyQueryBuilderControl"
        '
        'GebiedenTabPage
        '
        Me.GebiedenTabPage.AccessibleDescription = Nothing
        Me.GebiedenTabPage.AccessibleName = Nothing
        resources.ApplyResources(Me.GebiedenTabPage, "GebiedenTabPage")
        Me.GebiedenTabPage.BackgroundImage = Nothing
        Me.GebiedenTabPage.Controls.Add(Me.AnalysisAreaGroupBox)
        Me.AnalyseErrorProvider.SetError(Me.GebiedenTabPage, resources.GetString("GebiedenTabPage.Error"))
        Me.GebiedenTabPage.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.GebiedenTabPage, CType(resources.GetObject("GebiedenTabPage.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.GebiedenTabPage, CType(resources.GetObject("GebiedenTabPage.IconPadding"), Integer))
        Me.GebiedenTabPage.Name = "GebiedenTabPage"
        Me.GebiedenTabPage.UseVisualStyleBackColor = True
        '
        'AnalysisAreaGroupBox
        '
        Me.AnalysisAreaGroupBox.AccessibleDescription = Nothing
        Me.AnalysisAreaGroupBox.AccessibleName = Nothing
        resources.ApplyResources(Me.AnalysisAreaGroupBox, "AnalysisAreaGroupBox")
        Me.AnalysisAreaGroupBox.BackgroundImage = Nothing
        Me.AnalysisAreaGroupBox.Controls.Add(Me.AreasListBox)
        Me.AnalyseErrorProvider.SetError(Me.AnalysisAreaGroupBox, resources.GetString("AnalysisAreaGroupBox.Error"))
        Me.AnalysisAreaGroupBox.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.AnalysisAreaGroupBox, CType(resources.GetObject("AnalysisAreaGroupBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.AnalysisAreaGroupBox, CType(resources.GetObject("AnalysisAreaGroupBox.IconPadding"), Integer))
        Me.AnalysisAreaGroupBox.Name = "AnalysisAreaGroupBox"
        Me.AnalysisAreaGroupBox.TabStop = False
        '
        'AreasListBox
        '
        Me.AreasListBox.AccessibleDescription = Nothing
        Me.AreasListBox.AccessibleName = Nothing
        resources.ApplyResources(Me.AreasListBox, "AreasListBox")
        Me.AreasListBox.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.AreasListBox, resources.GetString("AreasListBox.Error"))
        Me.AreasListBox.Font = Nothing
        Me.AreasListBox.FormattingEnabled = True
        Me.AnalyseErrorProvider.SetIconAlignment(Me.AreasListBox, CType(resources.GetObject("AreasListBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.AreasListBox, CType(resources.GetObject("AreasListBox.IconPadding"), Integer))
        Me.AreasListBox.Name = "AreasListBox"
        Me.AreasListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple
        '
        'ParametersTabPage
        '
        Me.ParametersTabPage.AccessibleDescription = Nothing
        Me.ParametersTabPage.AccessibleName = Nothing
        resources.ApplyResources(Me.ParametersTabPage, "ParametersTabPage")
        Me.ParametersTabPage.BackgroundImage = Nothing
        Me.ParametersTabPage.Controls.Add(Me.ButtonUseExisitingBP)
        Me.ParametersTabPage.Controls.Add(Me.ParameterGroupBox)
        Me.ParametersTabPage.Controls.Add(Me.PuntenIntekenenButton)
        Me.ParametersTabPage.Controls.Add(Me.GenereerKaartButton)
        Me.ParametersTabPage.Controls.Add(Me.Label12)
        Me.ParametersTabPage.Controls.Add(Me.AnalysisTypeComboBox)
        Me.ParametersTabPage.Controls.Add(Me.AggregatieGroupBox)
        Me.ParametersTabPage.Controls.Add(Me.PickCrimeSerieFields1)
        Me.AnalyseErrorProvider.SetError(Me.ParametersTabPage, resources.GetString("ParametersTabPage.Error"))
        Me.ParametersTabPage.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.ParametersTabPage, CType(resources.GetObject("ParametersTabPage.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.ParametersTabPage, CType(resources.GetObject("ParametersTabPage.IconPadding"), Integer))
        Me.ParametersTabPage.Name = "ParametersTabPage"
        Me.ParametersTabPage.UseVisualStyleBackColor = True
        '
        'ButtonUseExisitingBP
        '
        Me.ButtonUseExisitingBP.AccessibleDescription = Nothing
        Me.ButtonUseExisitingBP.AccessibleName = Nothing
        resources.ApplyResources(Me.ButtonUseExisitingBP, "ButtonUseExisitingBP")
        Me.ButtonUseExisitingBP.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.ButtonUseExisitingBP, resources.GetString("ButtonUseExisitingBP.Error"))
        Me.ButtonUseExisitingBP.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.ButtonUseExisitingBP, CType(resources.GetObject("ButtonUseExisitingBP.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.ButtonUseExisitingBP, CType(resources.GetObject("ButtonUseExisitingBP.IconPadding"), Integer))
        Me.ButtonUseExisitingBP.Name = "ButtonUseExisitingBP"
        Me.ButtonUseExisitingBP.UseVisualStyleBackColor = True
        '
        'ParameterGroupBox
        '
        Me.ParameterGroupBox.AccessibleDescription = Nothing
        Me.ParameterGroupBox.AccessibleName = Nothing
        resources.ApplyResources(Me.ParameterGroupBox, "ParameterGroupBox")
        Me.ParameterGroupBox.BackgroundImage = Nothing
        Me.ParameterGroupBox.Controls.Add(Me.InkleurenRadioButton)
        Me.ParameterGroupBox.Controls.Add(Me.ParamColumnListBox)
        Me.ParameterGroupBox.Controls.Add(Me.KolomRadioButton)
        Me.ParameterGroupBox.Controls.Add(Me.AantalFeitenRadioButton)
        Me.AnalyseErrorProvider.SetError(Me.ParameterGroupBox, resources.GetString("ParameterGroupBox.Error"))
        Me.ParameterGroupBox.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.ParameterGroupBox, CType(resources.GetObject("ParameterGroupBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.ParameterGroupBox, CType(resources.GetObject("ParameterGroupBox.IconPadding"), Integer))
        Me.ParameterGroupBox.Name = "ParameterGroupBox"
        Me.ParameterGroupBox.TabStop = False
        '
        'InkleurenRadioButton
        '
        Me.InkleurenRadioButton.AccessibleDescription = Nothing
        Me.InkleurenRadioButton.AccessibleName = Nothing
        resources.ApplyResources(Me.InkleurenRadioButton, "InkleurenRadioButton")
        Me.InkleurenRadioButton.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.InkleurenRadioButton, resources.GetString("InkleurenRadioButton.Error"))
        Me.InkleurenRadioButton.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.InkleurenRadioButton, CType(resources.GetObject("InkleurenRadioButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.InkleurenRadioButton, CType(resources.GetObject("InkleurenRadioButton.IconPadding"), Integer))
        Me.InkleurenRadioButton.Name = "InkleurenRadioButton"
        Me.InkleurenRadioButton.TabStop = True
        Me.InkleurenRadioButton.UseVisualStyleBackColor = True
        '
        'ParamColumnListBox
        '
        Me.ParamColumnListBox.AccessibleDescription = Nothing
        Me.ParamColumnListBox.AccessibleName = Nothing
        resources.ApplyResources(Me.ParamColumnListBox, "ParamColumnListBox")
        Me.ParamColumnListBox.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.ParamColumnListBox, resources.GetString("ParamColumnListBox.Error"))
        Me.ParamColumnListBox.Font = Nothing
        Me.ParamColumnListBox.FormattingEnabled = True
        Me.AnalyseErrorProvider.SetIconAlignment(Me.ParamColumnListBox, CType(resources.GetObject("ParamColumnListBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.ParamColumnListBox, CType(resources.GetObject("ParamColumnListBox.IconPadding"), Integer))
        Me.ParamColumnListBox.Name = "ParamColumnListBox"
        '
        'KolomRadioButton
        '
        Me.KolomRadioButton.AccessibleDescription = Nothing
        Me.KolomRadioButton.AccessibleName = Nothing
        resources.ApplyResources(Me.KolomRadioButton, "KolomRadioButton")
        Me.KolomRadioButton.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.KolomRadioButton, resources.GetString("KolomRadioButton.Error"))
        Me.KolomRadioButton.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.KolomRadioButton, CType(resources.GetObject("KolomRadioButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.KolomRadioButton, CType(resources.GetObject("KolomRadioButton.IconPadding"), Integer))
        Me.KolomRadioButton.Name = "KolomRadioButton"
        Me.KolomRadioButton.TabStop = True
        Me.KolomRadioButton.UseVisualStyleBackColor = True
        '
        'AantalFeitenRadioButton
        '
        Me.AantalFeitenRadioButton.AccessibleDescription = Nothing
        Me.AantalFeitenRadioButton.AccessibleName = Nothing
        resources.ApplyResources(Me.AantalFeitenRadioButton, "AantalFeitenRadioButton")
        Me.AantalFeitenRadioButton.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.AantalFeitenRadioButton, resources.GetString("AantalFeitenRadioButton.Error"))
        Me.AantalFeitenRadioButton.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.AantalFeitenRadioButton, CType(resources.GetObject("AantalFeitenRadioButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.AantalFeitenRadioButton, CType(resources.GetObject("AantalFeitenRadioButton.IconPadding"), Integer))
        Me.AantalFeitenRadioButton.Name = "AantalFeitenRadioButton"
        Me.AantalFeitenRadioButton.TabStop = True
        Me.AantalFeitenRadioButton.UseVisualStyleBackColor = True
        '
        'PuntenIntekenenButton
        '
        Me.PuntenIntekenenButton.AccessibleDescription = Nothing
        Me.PuntenIntekenenButton.AccessibleName = Nothing
        resources.ApplyResources(Me.PuntenIntekenenButton, "PuntenIntekenenButton")
        Me.PuntenIntekenenButton.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.PuntenIntekenenButton, resources.GetString("PuntenIntekenenButton.Error"))
        Me.PuntenIntekenenButton.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.PuntenIntekenenButton, CType(resources.GetObject("PuntenIntekenenButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.PuntenIntekenenButton, CType(resources.GetObject("PuntenIntekenenButton.IconPadding"), Integer))
        Me.PuntenIntekenenButton.Name = "PuntenIntekenenButton"
        Me.PuntenIntekenenButton.UseVisualStyleBackColor = True
        '
        'GenereerKaartButton
        '
        Me.GenereerKaartButton.AccessibleDescription = Nothing
        Me.GenereerKaartButton.AccessibleName = Nothing
        resources.ApplyResources(Me.GenereerKaartButton, "GenereerKaartButton")
        Me.GenereerKaartButton.BackColor = System.Drawing.Color.Transparent
        Me.GenereerKaartButton.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.GenereerKaartButton, resources.GetString("GenereerKaartButton.Error"))
        Me.GenereerKaartButton.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.GenereerKaartButton, CType(resources.GetObject("GenereerKaartButton.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.GenereerKaartButton, CType(resources.GetObject("GenereerKaartButton.IconPadding"), Integer))
        Me.GenereerKaartButton.Name = "GenereerKaartButton"
        Me.GenereerKaartButton.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.AccessibleDescription = Nothing
        Me.Label12.AccessibleName = Nothing
        resources.ApplyResources(Me.Label12, "Label12")
        Me.AnalyseErrorProvider.SetError(Me.Label12, resources.GetString("Label12.Error"))
        Me.Label12.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.Label12, CType(resources.GetObject("Label12.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.Label12, CType(resources.GetObject("Label12.IconPadding"), Integer))
        Me.Label12.Name = "Label12"
        '
        'AnalysisTypeComboBox
        '
        Me.AnalysisTypeComboBox.AccessibleDescription = Nothing
        Me.AnalysisTypeComboBox.AccessibleName = Nothing
        resources.ApplyResources(Me.AnalysisTypeComboBox, "AnalysisTypeComboBox")
        Me.AnalysisTypeComboBox.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.AnalysisTypeComboBox, resources.GetString("AnalysisTypeComboBox.Error"))
        Me.AnalysisTypeComboBox.Font = Nothing
        Me.AnalysisTypeComboBox.FormattingEnabled = True
        Me.AnalyseErrorProvider.SetIconAlignment(Me.AnalysisTypeComboBox, CType(resources.GetObject("AnalysisTypeComboBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.AnalysisTypeComboBox, CType(resources.GetObject("AnalysisTypeComboBox.IconPadding"), Integer))
        Me.AnalysisTypeComboBox.Name = "AnalysisTypeComboBox"
        '
        'AggregatieGroupBox
        '
        Me.AggregatieGroupBox.AccessibleDescription = Nothing
        Me.AggregatieGroupBox.AccessibleName = Nothing
        resources.ApplyResources(Me.AggregatieGroupBox, "AggregatieGroupBox")
        Me.AggregatieGroupBox.BackgroundImage = Nothing
        Me.AggregatieGroupBox.Controls.Add(Me.Label11)
        Me.AggregatieGroupBox.Controls.Add(Me.AggregationLevelListBox2)
        Me.AnalyseErrorProvider.SetError(Me.AggregatieGroupBox, resources.GetString("AggregatieGroupBox.Error"))
        Me.AggregatieGroupBox.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.AggregatieGroupBox, CType(resources.GetObject("AggregatieGroupBox.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.AggregatieGroupBox, CType(resources.GetObject("AggregatieGroupBox.IconPadding"), Integer))
        Me.AggregatieGroupBox.Name = "AggregatieGroupBox"
        Me.AggregatieGroupBox.TabStop = False
        '
        'Label11
        '
        Me.Label11.AccessibleDescription = Nothing
        Me.Label11.AccessibleName = Nothing
        resources.ApplyResources(Me.Label11, "Label11")
        Me.AnalyseErrorProvider.SetError(Me.Label11, resources.GetString("Label11.Error"))
        Me.Label11.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.Label11, CType(resources.GetObject("Label11.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.Label11, CType(resources.GetObject("Label11.IconPadding"), Integer))
        Me.Label11.Name = "Label11"
        '
        'AggregationLevelListBox2
        '
        Me.AggregationLevelListBox2.AccessibleDescription = Nothing
        Me.AggregationLevelListBox2.AccessibleName = Nothing
        resources.ApplyResources(Me.AggregationLevelListBox2, "AggregationLevelListBox2")
        Me.AggregationLevelListBox2.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.AggregationLevelListBox2, resources.GetString("AggregationLevelListBox2.Error"))
        Me.AggregationLevelListBox2.Font = Nothing
        Me.AggregationLevelListBox2.FormattingEnabled = True
        Me.AnalyseErrorProvider.SetIconAlignment(Me.AggregationLevelListBox2, CType(resources.GetObject("AggregationLevelListBox2.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.AggregationLevelListBox2, CType(resources.GetObject("AggregationLevelListBox2.IconPadding"), Integer))
        Me.AggregationLevelListBox2.Name = "AggregationLevelListBox2"
        '
        'PickCrimeSerieFields1
        '
        Me.PickCrimeSerieFields1.AccessibleDescription = Nothing
        Me.PickCrimeSerieFields1.AccessibleName = Nothing
        resources.ApplyResources(Me.PickCrimeSerieFields1, "PickCrimeSerieFields1")
        Me.PickCrimeSerieFields1.BackgroundImage = Nothing
        CrimeSerieFields1.EndDate = Nothing
        CrimeSerieFields1.EndTime = Nothing
        CrimeSerieFields1.MaxDistance = 0
        CrimeSerieFields1.MaxGapHours = 0
        CrimeSerieFields1.MaxTimeSpanHours = 0
        CrimeSerieFields1.StartDate = Nothing
        CrimeSerieFields1.StartTime = Nothing
        CrimeSerieFields1.TimeDiffColumn = Nothing
        Me.PickCrimeSerieFields1.CrimeSerieFields = CrimeSerieFields1
        Me.AnalyseErrorProvider.SetError(Me.PickCrimeSerieFields1, resources.GetString("PickCrimeSerieFields1.Error"))
        Me.PickCrimeSerieFields1.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.PickCrimeSerieFields1, CType(resources.GetObject("PickCrimeSerieFields1.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.PickCrimeSerieFields1, CType(resources.GetObject("PickCrimeSerieFields1.IconPadding"), Integer))
        Me.PickCrimeSerieFields1.Name = "PickCrimeSerieFields1"
        Me.PickCrimeSerieFields1.TableName = Nothing
        '
        'GroupBox6
        '
        Me.GroupBox6.AccessibleDescription = Nothing
        Me.GroupBox6.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBox6, "GroupBox6")
        Me.GroupBox6.BackgroundImage = Nothing
        Me.GroupBox6.Controls.Add(Me.Label8)
        Me.GroupBox6.Controls.Add(Me.CheckBox2)
        Me.GroupBox6.Controls.Add(Me.ComboBox9)
        Me.AnalyseErrorProvider.SetError(Me.GroupBox6, resources.GetString("GroupBox6.Error"))
        Me.GroupBox6.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.GroupBox6, CType(resources.GetObject("GroupBox6.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.GroupBox6, CType(resources.GetObject("GroupBox6.IconPadding"), Integer))
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.TabStop = False
        '
        'Label8
        '
        Me.Label8.AccessibleDescription = Nothing
        Me.Label8.AccessibleName = Nothing
        resources.ApplyResources(Me.Label8, "Label8")
        Me.AnalyseErrorProvider.SetError(Me.Label8, resources.GetString("Label8.Error"))
        Me.Label8.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.Label8, CType(resources.GetObject("Label8.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.Label8, CType(resources.GetObject("Label8.IconPadding"), Integer))
        Me.Label8.Name = "Label8"
        '
        'CheckBox2
        '
        Me.CheckBox2.AccessibleDescription = Nothing
        Me.CheckBox2.AccessibleName = Nothing
        resources.ApplyResources(Me.CheckBox2, "CheckBox2")
        Me.CheckBox2.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.CheckBox2, resources.GetString("CheckBox2.Error"))
        Me.CheckBox2.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.CheckBox2, CType(resources.GetObject("CheckBox2.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.CheckBox2, CType(resources.GetObject("CheckBox2.IconPadding"), Integer))
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'ComboBox9
        '
        Me.ComboBox9.AccessibleDescription = Nothing
        Me.ComboBox9.AccessibleName = Nothing
        resources.ApplyResources(Me.ComboBox9, "ComboBox9")
        Me.ComboBox9.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.ComboBox9, resources.GetString("ComboBox9.Error"))
        Me.ComboBox9.Font = Nothing
        Me.ComboBox9.FormattingEnabled = True
        Me.AnalyseErrorProvider.SetIconAlignment(Me.ComboBox9, CType(resources.GetObject("ComboBox9.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.ComboBox9, CType(resources.GetObject("ComboBox9.IconPadding"), Integer))
        Me.ComboBox9.Name = "ComboBox9"
        '
        'GroupBox7
        '
        Me.GroupBox7.AccessibleDescription = Nothing
        Me.GroupBox7.AccessibleName = Nothing
        resources.ApplyResources(Me.GroupBox7, "GroupBox7")
        Me.GroupBox7.BackgroundImage = Nothing
        Me.GroupBox7.Controls.Add(Me.ComboBox10)
        Me.GroupBox7.Controls.Add(Me.RadioButton11)
        Me.GroupBox7.Controls.Add(Me.RadioButton12)
        Me.AnalyseErrorProvider.SetError(Me.GroupBox7, resources.GetString("GroupBox7.Error"))
        Me.GroupBox7.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.GroupBox7, CType(resources.GetObject("GroupBox7.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.GroupBox7, CType(resources.GetObject("GroupBox7.IconPadding"), Integer))
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.TabStop = False
        '
        'ComboBox10
        '
        Me.ComboBox10.AccessibleDescription = Nothing
        Me.ComboBox10.AccessibleName = Nothing
        resources.ApplyResources(Me.ComboBox10, "ComboBox10")
        Me.ComboBox10.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.ComboBox10, resources.GetString("ComboBox10.Error"))
        Me.ComboBox10.Font = Nothing
        Me.ComboBox10.FormattingEnabled = True
        Me.AnalyseErrorProvider.SetIconAlignment(Me.ComboBox10, CType(resources.GetObject("ComboBox10.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.ComboBox10, CType(resources.GetObject("ComboBox10.IconPadding"), Integer))
        Me.ComboBox10.Name = "ComboBox10"
        '
        'RadioButton11
        '
        Me.RadioButton11.AccessibleDescription = Nothing
        Me.RadioButton11.AccessibleName = Nothing
        resources.ApplyResources(Me.RadioButton11, "RadioButton11")
        Me.RadioButton11.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.RadioButton11, resources.GetString("RadioButton11.Error"))
        Me.RadioButton11.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.RadioButton11, CType(resources.GetObject("RadioButton11.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.RadioButton11, CType(resources.GetObject("RadioButton11.IconPadding"), Integer))
        Me.RadioButton11.Name = "RadioButton11"
        Me.RadioButton11.TabStop = True
        Me.RadioButton11.UseVisualStyleBackColor = True
        '
        'RadioButton12
        '
        Me.RadioButton12.AccessibleDescription = Nothing
        Me.RadioButton12.AccessibleName = Nothing
        resources.ApplyResources(Me.RadioButton12, "RadioButton12")
        Me.RadioButton12.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.RadioButton12, resources.GetString("RadioButton12.Error"))
        Me.RadioButton12.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.RadioButton12, CType(resources.GetObject("RadioButton12.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.RadioButton12, CType(resources.GetObject("RadioButton12.IconPadding"), Integer))
        Me.RadioButton12.Name = "RadioButton12"
        Me.RadioButton12.TabStop = True
        Me.RadioButton12.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AccessibleDescription = Nothing
        Me.Label9.AccessibleName = Nothing
        resources.ApplyResources(Me.Label9, "Label9")
        Me.AnalyseErrorProvider.SetError(Me.Label9, resources.GetString("Label9.Error"))
        Me.Label9.Font = Nothing
        Me.AnalyseErrorProvider.SetIconAlignment(Me.Label9, CType(resources.GetObject("Label9.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.Label9, CType(resources.GetObject("Label9.IconPadding"), Integer))
        Me.Label9.Name = "Label9"
        '
        'ListBox1
        '
        Me.ListBox1.AccessibleDescription = Nothing
        Me.ListBox1.AccessibleName = Nothing
        resources.ApplyResources(Me.ListBox1, "ListBox1")
        Me.ListBox1.BackgroundImage = Nothing
        Me.AnalyseErrorProvider.SetError(Me.ListBox1, resources.GetString("ListBox1.Error"))
        Me.ListBox1.Font = Nothing
        Me.ListBox1.FormattingEnabled = True
        Me.AnalyseErrorProvider.SetIconAlignment(Me.ListBox1, CType(resources.GetObject("ListBox1.IconAlignment"), System.Windows.Forms.ErrorIconAlignment))
        Me.AnalyseErrorProvider.SetIconPadding(Me.ListBox1, CType(resources.GetObject("ListBox1.IconPadding"), Integer))
        Me.ListBox1.Name = "ListBox1"
        '
        'AnalyseErrorProvider
        '
        Me.AnalyseErrorProvider.ContainerControl = Me
        resources.ApplyResources(Me.AnalyseErrorProvider, "AnalyseErrorProvider")
        '
        'PolitieZoneBindingSource
        '
        Me.PolitieZoneBindingSource.DataSource = GetType(Gim.PoliceGis.Core.InteresseGebied)
        '
        'FormAnalysis
        '
        Me.AccessibleDescription = Nothing
        Me.AccessibleName = Nothing
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Nothing
        Me.Controls.Add(Me.MainTabControl)
        Me.Font = Nothing
        Me.Name = "FormAnalysis"
        Me.MainTabControl.ResumeLayout(False)
        Me.TabelTabPage.ResumeLayout(False)
        Me.GebiedenTabPage.ResumeLayout(False)
        Me.AnalysisAreaGroupBox.ResumeLayout(False)
        Me.ParametersTabPage.ResumeLayout(False)
        Me.ParametersTabPage.PerformLayout()
        Me.ParameterGroupBox.ResumeLayout(False)
        Me.ParameterGroupBox.PerformLayout()
        Me.AggregatieGroupBox.ResumeLayout(False)
        Me.AggregatieGroupBox.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        CType(Me.AnalyseErrorProvider, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PolitieZoneBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MainTabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabelTabPage As System.Windows.Forms.TabPage
    Friend WithEvents GebiedenTabPage As System.Windows.Forms.TabPage
    Friend WithEvents AnalysisAreaGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ParametersTabPage As System.Windows.Forms.TabPage
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents AnalysisTypeComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents AggregatieGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents AggregationLevelListBox2 As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents ComboBox9 As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents ComboBox10 As System.Windows.Forms.ComboBox
    Friend WithEvents RadioButton11 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton12 As System.Windows.Forms.RadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents MyPickMapInfoTableControl As PickMapInfoTableControl
    Friend WithEvents MyQueryBuilderControl As SimpleQueryBuilder
    Friend WithEvents GenereerKaartButton As System.Windows.Forms.Button
    Friend WithEvents ParameterGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ParamColumnListBox As System.Windows.Forms.ListBox
    Friend WithEvents KolomRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AantalFeitenRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents InkleurenRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents PuntenIntekenenButton As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents PolitieZoneBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AreasListBox As System.Windows.Forms.ListBox
    Friend WithEvents PickCrimeSerieFields1 As Gim.PoliceGis.Core.PickCrimeSerieFields
    Friend WithEvents AnalyseErrorProvider As System.Windows.Forms.ErrorProvider
    Friend WithEvents ButtonUseExisitingBP As System.Windows.Forms.Button
End Class
