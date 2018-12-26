Imports System.IO
Imports System.Windows.Forms
Imports System.Xml
Imports <xmlns="http://schemas.gim.be/PoliceGIS/PoliceGisConfiguration.xsd">

Public Class FormConfiguration

    Private m_AnanLyseForm As FormAnalysis
    Private m_xDdocument As XDocument = XDocument.Load(PGISConfigurationManager.GetInstance.ConfigFile.FullName)

#Region "constructors"

    Public Sub New()
        Try

            ' This call is required by the Windows Form Designer.

            InitializeComponent()
            InitializeForm()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub New(ByVal analyseForm As FormAnalysis)

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        InitializeForm()

        m_AnanLyseForm = analyseForm

    End Sub


#End Region

    Private Sub OpenTabFileButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenTabFileButton.Click

        Dim dialog = New System.Windows.Forms.FolderBrowserDialog

        Dim answer = dialog.ShowDialog
        If answer = Windows.Forms.DialogResult.OK Then

            If Not String.IsNullOrEmpty(dialog.SelectedPath) Then

                DataFolderTextBox.Text = dialog.SelectedPath

            End If

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim s = XDocument.Load(String.Format("{0}\{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location), My.Settings.configFile))


            Dim politieZone = (From el In s.<policeGisConfig>.<analysis>.<areas>.<area>.<Name> Select el).First
            Dim StartUpFolder = (From el In s.<policeGisConfig>.<directories>.<dataFolder> Select el).First

            StartUpFolder.Value = DataFolderTextBox.Text
            politieZone.Value = PolitieZoneTextBox.Text

            s.Save(Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location), My.Settings.configFile))

            If m_AnanLyseForm IsNot Nothing Then
                m_AnanLyseForm.Configuration.initiaLizeComponents()
                m_AnanLyseForm.InitializeApplication(True)
            End If


        Catch ex As Exception
            Throw New PoliceGisException("configError", ex)
        Finally
            Me.Close()
        End Try



    End Sub

    'Private Sub GetTabFile(ByVal textbox As TextBox)
    '    Dim dialog = New System.Windows.Forms.OpenFileDialog
    '    With dialog
    '        .Multiselect = False
    '        '.InitialDirectory = Path.GetDirectoryName(configPath)
    '        .Filter = "tabel (*.TAB)|*.TAB"
    '        .AddExtension = False
    '        .CheckFileExists = True
    '        .Title = "Kies workspace"
    '    End With

    '    Dim answer = dialog.ShowDialog
    '    If answer = Windows.Forms.DialogResult.OK Then

    '        If Not String.IsNullOrEmpty(dialog.FileName) Then

    '            textbox.Text = dialog.FileName

    '        End If

    '    End If
    'End Sub


    Private Sub InitializeForm()

        Dim politieZone = (From el In m_xDdocument.<policeGisConfig>.<analysis>.<areas>.<area>.<Name> Select el).First
        Dim StarUpFolder = (From el In m_xDdocument.<policeGisConfig>.<directories>.<dataFolder> Select el).First

        DataFolderTextBox.Text = StarUpFolder.Value
        PolitieZoneTextBox.Text = politieZone.Value

        ' Logo of the police is the icon for the window.

        Me.Icon = GuiThemeProvider.GetPoliceIcon
        Me.Text = String.Format("{0}{1}", Me.Text, My.Resources.GIMPoliceGis)

    End Sub

End Class