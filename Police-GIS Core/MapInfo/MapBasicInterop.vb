Option Strict On

' System namespaces
Imports System.Globalization
Imports System.IO

' MapInfo namespaces
Imports MapInfo.MiPro.Interop

Public Class MapBasicInterop

    Private Shared sh_mapInfoNumFormat As NumberFormatInfo

    Public Sub New()
        ' empty default constructor
    End Sub


    ''' <summary>
    ''' Execute a command that does not return a result, and check if it gave any errors.
    ''' </summary>
    ''' <param name="commandText"></param>
    ''' <remarks></remarks>
    Public Shared Sub ExecuteCommand(ByVal commandText As String)

        If String.IsNullOrEmpty(commandText) Then
            Throw ExceptionProvider.NullOrEmptyArgException("commandText")
        End If

        If Not CommandLengthOk(commandText) Then
            Throw New PoliceGisException("Command text is too long: " & commandText)
        End If

        InteropServices.MapInfoApplication.Do(commandText)
        CheckMapInfoResult(commandText)

    End Sub

    ''' <summary>
    ''' Evaluate an expression or execute a command that returns a result, 
    ''' and check if it gave any errors.
    ''' </summary>
    ''' <param name="expression"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function Evaluate(ByVal expression As String) As String

        If String.IsNullOrEmpty(expression) Then
            Throw ExceptionProvider.NullOrEmptyArgException("Expression")
        End If

        If Not CommandLengthOk(expression) Then
            Throw New PoliceGisException("Expression is too long: " & expression)
        End If

        Dim result = InteropServices.MapInfoApplication.Eval(expression)
        CheckMapInfoResult(expression)
        Return result

    End Function

    Public Shared Function CommandLengthOk(ByVal commandText As String) As Boolean

        Return (commandText.Length <= MapBasicConstants.MAX_STRING_LENGTH)

    End Function

    Private Shared Sub CheckMapInfoResult(ByVal commandOrExpression As String)

        Dim mi = InteropServices.MapInfoApplication
        Dim lastErrMsg = mi.LastErrorMessage
        Dim lastErrCode = mi.LastErrorCode

        If Not String.IsNullOrEmpty(lastErrMsg) Then

            Dim excMsg = String.Format("MapInfo command or expression has failed: {0}Command / expression : ""{1}""{0}{2}{0}error code = {3} ", ControlChars.NewLine, commandOrExpression, lastErrMsg, lastErrCode)
            Throw New PoliceGisException(excMsg)

        End If

        ' No message available, just the error code:
        ' This is unlikely to happen though.
        If lastErrCode <> 0 Then

            Dim excMsg = String.Format("MapInfo command or expression has failed: {0}Command / expression : ""{1}""{0}error code = {2} ", ControlChars.NewLine, commandOrExpression, lastErrCode)
            Throw New PoliceGisException(excMsg)

        End If

    End Sub

    Public Shared Function GetMapInfoNumFormat() As NumberFormatInfo

        If sh_mapInfoNumFormat Is Nothing Then

            Dim temp As New NumberFormatInfo()
            temp.NumberDecimalSeparator = "."
            temp.NumberGroupSeparator = ""

            ' This object MUST be READ-ONLY. None of the clients of this class is allowed to change it.'
            ' Alternatively you could create a new instance on each request, if waisted memory is
            ' not a concern. 
            sh_mapInfoNumFormat = NumberFormatInfo.ReadOnly(temp)

        End If

        Return sh_mapInfoNumFormat

    End Function

    ''' <summary>
    ''' Escapes double quote characters so MapInfo can handle it in queries.
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Note that Mapinfo does not use the single quote to denote text, whihc is 
    ''' the way most SQL implementations do it. (In fact MapInfo does not 
    ''' implement an SQL standard, just something that looks similar.)
    ''' </remarks>
    Public Shared Function EscapeString(ByVal text As String) As String

        Return text.Replace("""", """""")

    End Function

    ''' <summary>
    ''' Escapes double quote characters so MapInfo can handle it in queries.
    ''' </summary>
    ''' <param name="text"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' Note that Mapinfo does not use the single quote to denote text, whihc is 
    ''' the way most SQL implementations do it. (In fact MapInfo does not 
    ''' implement an SQL standard, just something that looks similar.)
    ''' </remarks>
    Public Shared Function QuoteAndEscapeString(ByVal text As String) As String

        Return text.Replace("""", """""")

    End Function

    Public Shared Function ConvertMapInfoLogical(ByVal inputLogical As String) As Boolean

        If inputLogical Is Nothing Then
            Throw ExceptionProvider.NullArgException("inputLogical")
        End If

        Dim result As Boolean = False
        Dim normalized As String = inputLogical.Trim.ToUpper

        If normalized = "T" OrElse normalized = "1" Then
            result = True
        ElseIf normalized = "F" OrElse normalized = "0" Then
            result = False
        Else

            Dim msg = String.Format("Argument 'inputLogical' should be one of these string values: ""t"", ""T"", ""1"", ""f"", ""F"", ""0"".  Actual value was: ""{0}"" .", inputLogical)
            Throw New ArgumentOutOfRangeException(msg)

        End If

        Return result

    End Function

End Class
