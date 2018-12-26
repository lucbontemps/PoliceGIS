Option Strict On

Imports Gim.ErrorHandling
<Serializable()> _
Public Class InvalidConfigurationException
    Inherits GimBaseException

    Private m_validationReport As ValidationReport

    Public Sub New(ByVal message As String)
        Me.New(message, Nothing, Nothing)
    End Sub

    Public Sub New(ByVal message As String, ByVal valReport As ValidationReport)
        Me.New(message, valReport, Nothing)
    End Sub

    Public Sub New(ByVal message As String, ByVal valReport As ValidationReport, ByVal innerExc As Exception)
        MyBase.New(message, "", innerExc)
        m_validationReport = valReport
    End Sub

    Public Overrides ReadOnly Property Message() As String
        Get

            If m_validationReport IsNot Nothing Then
                Return MyBase.Message & ControlChars.NewLine & m_validationReport.Summary
            Else
                Return MyBase.Message
            End If

        End Get
    End Property

    ReadOnly Property ValidationReport() As ValidationReport
        Get
            Return m_validationReport
        End Get
    End Property

End Class

