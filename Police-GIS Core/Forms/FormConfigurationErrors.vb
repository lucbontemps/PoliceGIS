Option Strict On

Imports Gim.ErrorHandling
Imports Gim.PoliceGis.Core


''' <summary>
''' Form to summerize configuration errors.
''' </summary>
''' <remarks></remarks>
Public Class FormConfigurationErrors

    Private m_validationReport As ValidationReport

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Logo of the police is the icon for the window.

        Me.Icon = GuiThemeProvider.GetPoliceIcon
        Me.Text = String.Format("{0}{1}", Me.Text, My.Resources.GIMPoliceGis)

    End Sub

    Property Report() As ValidationReport
        Get
            Return m_validationReport
        End Get
        Set(ByVal value As ValidationReport)
            m_validationReport = value
            Me.FoutenTextBox.Text = m_validationReport.Summary
        End Set
    End Property


End Class