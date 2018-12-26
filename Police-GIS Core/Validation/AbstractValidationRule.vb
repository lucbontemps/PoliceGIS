Option Strict On

Public MustInherit Class AbstractValidationRule
    Implements IValidatable

    Public Const NAME_SEPARATOR As String = "\"
    Private m_localName As String
    Private m_validationReport As ValidationReport
    Private m_isValidated As Boolean
    Private m_parentRule As AbstractValidationRule

    Protected Sub New(ByVal name As String)

        m_validationReport = New ValidationReport()
        m_localName = name

    End Sub

    Property ParentRule() As AbstractValidationRule
        Get
            Return m_parentRule
        End Get
        Set(ByVal value As AbstractValidationRule)
            m_parentRule = value
        End Set
    End Property
    ''' <summary>
    ''' Whether the contents are valid or not.
    ''' If the contents have not been validated, the result is also false.
    ''' </summary>
    ''' <value></value>
    ''' <returns>
    ''' True when contents were validated succesfully
    ''' False when they were not validated yet or when there are validation errors.
    ''' </returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsValid() As Boolean Implements IValidatable.IsValid
        Get
            If Not m_isValidated Then
                Return False
            Else
                Return m_validationReport.IsValid
            End If
        End Get
    End Property

    Public Property IsValidated() As Boolean Implements IValidatable.IsValidated
        Get
            Return m_isValidated
        End Get
        Set(ByVal value As Boolean)
            m_isValidated = value
        End Set
    End Property

    Public ReadOnly Property Report() As ValidationReport Implements IValidatable.Report
        Get
            Return m_validationReport
        End Get
    End Property


    Property LocalName() As String
        Get
            Return m_localName
        End Get
        Set(ByVal value As String)
            m_localName = value
        End Set
    End Property

    ReadOnly Property FullName() As String
        Get
            If m_parentRule Is Nothing Then
                Return m_localName
            Else
                Return m_parentRule.FullName & NAME_SEPARATOR & m_localName
            End If
        End Get
    End Property

    ' can't replace the reference, but you can edit the list.
    ReadOnly Property ValidationErrors() As List(Of String)
        Get
            Return m_validationReport.ValidationErrors
        End Get
    End Property

    ReadOnly Property ErrorSummary() As String
        Get
            Return m_validationReport.Summary
        End Get
    End Property

    Public Sub AddError(ByVal errorDescription As String)
        m_validationReport.AddError(FullName & ": " & errorDescription)
    End Sub

    Public Sub AddErrors(ByVal rule As AbstractValidationRule)
        m_validationReport.AddErrors(rule.ValidationErrors)
    End Sub

    Public Sub Clear()
        m_isValidated = False
        m_validationReport.Clear()
    End Sub

    Public MustOverride Sub Validate() Implements IValidatable.Validate

End Class
