Option Strict On

' system namespaces
Imports System.Text


Public Class ValidationReport

#Region " fields "

    Protected m_validationErrors As List(Of String)

#End Region

#Region " constructors "

    Public Sub New()
        m_validationErrors = New List(Of String)
    End Sub

    Public Sub New(ByVal other As ValidationReport)
        m_validationErrors = New List(Of String)
        m_validationErrors.AddRange(other.ValidationErrors)
    End Sub

#End Region

#Region " public "

    Public ReadOnly Property ValidationErrors() As List(Of String)
        Get
            Return m_validationErrors
        End Get
    End Property

    Public ReadOnly Property Item(ByVal index As Integer) As String
        Get
            Return m_validationErrors(index)
        End Get
    End Property

    Public ReadOnly Property Count() As Integer
        Get
            Return m_validationErrors.Count
        End Get
    End Property

    Public ReadOnly Property IsValid() As Boolean
        Get
            Return m_validationErrors.Count = 0
        End Get
    End Property

    Public ReadOnly Property Summary() As String
        Get

            Dim reportBuilder As New StringBuilder()
            For Each vr As String In m_validationErrors
                reportBuilder.AppendLine(vr)
            Next

            Return reportBuilder.ToString()

        End Get
    End Property

    Public Sub AddError(ByVal errorDescription As String)
        m_validationErrors.Add(errorDescription)
    End Sub

    Public Sub AddErrors(ByVal errorDescriptions As IList(Of String))
        m_validationErrors.AddRange(errorDescriptions)
    End Sub

    Public Sub Clear()
        m_validationErrors.Clear()
    End Sub

#End Region

#Region " protected "

#End Region

#Region " private "

#End Region

End Class