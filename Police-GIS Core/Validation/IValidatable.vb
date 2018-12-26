Option Strict On

Public Interface IValidatable

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
    ReadOnly Property IsValid() As Boolean

    Property IsValidated() As Boolean

    ' can't replace the reference, but you can edit the report.
    ReadOnly Property Report() As ValidationReport

    Sub Validate()


End Interface