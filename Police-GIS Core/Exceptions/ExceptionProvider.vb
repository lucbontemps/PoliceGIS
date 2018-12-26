
Imports System.IO


''' <summary>
''' Met deze klasse kan je exceptions met een standaard boodschap 
''' aanmaken voor vaak voorkomende situaties: 
''' <list>
''' <item>method argumenten die ongelig zijn.</item>
''' <item>null references</item>
''' <item>bestanden die niet gevonden werden.</item>
''' </list>
''' De standaard exception klassen worden gebruikt maar de met 
''' deze helper wordt in de hele applicatie consistent dezelfde 
''' boodschap gebruikt voor dezelfde soort fout. 
''' </summary>
''' <remarks></remarks>
Public Class ExceptionProvider

    ''' <summary>
    ''' Een argument van een method is een null reference wanneer dat niet 
    ''' toegelaten is.
    ''' </summary>
    ''' <param name="argumentName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NullArgException(ByVal argumentName As String) As ArgumentNullException

        Dim msg As String = String.Format(My.Resources.ExceptionMessages.ArgumentNull, argumentName)
        Return New ArgumentNullException(argumentName, msg)

    End Function

    ''' <summary>
    ''' Een string argument is niet ingevuld: het is ofwel een null reference
    ''' ofwel een lege string. 
    ''' </summary>
    ''' <param name="argumentName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function NullOrEmptyArgException(ByVal argumentName As String) As ArgumentOutOfRangeException

        Dim msg As String = String.Format(My.Resources.ExceptionMessages.StringArgumentNullOrEmpty, argumentName)
        Return New ArgumentOutOfRangeException(argumentName, msg)

    End Function


    ''' <summary>
    ''' Een argument van een method heeft een waarde die niet toegelaten is.
    ''' De toegelaten waarde is meestal een numerieke range maat dat hoeft niet
    ''' zo te zijn. Door via extraMessage een specifieke boodschap op te geven
    ''' kan je duidelijk maken wat er mis is of wat de toegelaten range is.
    ''' gebruik actual value om de werkelijke waarde van het foute argument
    ''' door te geven.
    ''' </summary>
    ''' <param name="argumentName">Name of argument that was invalid</param>
    ''' <param name="actualValue">Actual value of the invalid argument</param>
    ''' <param name="extraMessage">Extra message explaining how the value was out of range.</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ArgumentOutOfRange(ByVal argumentName As String, ByVal actualValue As Object, ByVal extraMessage As String) As ArgumentOutOfRangeException

        Dim msg As String = String.Format(My.Resources.ExceptionMessages.NoValidArgumentValue & " " & extraMessage, argumentName)
        Return New ArgumentOutOfRangeException(argumentName, actualValue, msg)

    End Function


    ''' <summary>
    ''' Het argument stelt een pad naar een bestand voor (type String of FileInfo)
    ''' Het bestand is echter niet gevonden.
    ''' </summary>
    ''' <param name="argumentName"></param>
    ''' <param name="path"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function PathArgNotFoundException(ByVal argumentName As String, ByVal path As String) As ArgumentOutOfRangeException

        Dim msg As String = String.Format(My.Resources.ExceptionMessages.PathNotFound, path)
        Return New ArgumentOutOfRangeException(argumentName, path, msg)

    End Function

    ''' <summary>
    ''' Een variable van type String wijst naar een bestand dat niet bestaat.
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FileNotFoundException(ByVal fileName As String) As FileNotFoundException

        Dim msg As String = String.Format(My.Resources.ExceptionMessages.FileNotFound, fileName)
        Return New FileNotFoundException(msg, fileName)

    End Function

    ''' <summary>
    ''' Een variable van type FileInfo wijst naar een bestand dat niet bestaat.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FileNotFoundException(ByVal file As FileInfo) As FileNotFoundException

        Dim msg As String = String.Format(My.Resources.ExceptionMessages.FileNotFound, file.FullName)
        Return New FileNotFoundException(msg, file.FullName)

    End Function


    ''' <summary>
    ''' Een variable van type String wijst naar een bestand dat niet bestaat.
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FileExistException(ByVal argumentName As String, ByVal fileName As String) As ArgumentOutOfRangeException

        Dim msg As String = String.Format(My.Resources.ExceptionMessages.FileExists, fileName)
        Return New ArgumentOutOfRangeException(argumentName, fileName, msg)

    End Function

    ''' <summary>
    ''' Een variable van type FileInfo wijst naar een bestand dat niet bestaat.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FileExistException(ByVal argumentName As String, ByVal file As FileInfo) As ArgumentOutOfRangeException

        Dim msg As String = String.Format(My.Resources.ExceptionMessages.FileExists, file.FullName)
        Return New ArgumentOutOfRangeException(argumentName, file.FullName, msg)

    End Function

    ''' <summary>
    ''' Een variable van type String wijst naar een directory die niet bestaat.
    ''' </summary>
    ''' <param name="dir"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DirectoryNotFoundException(ByVal dir As String) As FileNotFoundException

        Dim msg As String = String.Format(My.Resources.ExceptionMessages.DirectoryNotFound, dir)
        Return New FileNotFoundException(msg, dir)

    End Function

    ''' <summary>
    ''' Een variable van type DirectoryInfo wijst naar een directory die niet bestaat.
    ''' </summary>
    ''' <param name="file"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DirectoryNotFoundException(ByVal file As FileInfo) As FileNotFoundException

        Dim msg As String = String.Format(My.Resources.ExceptionMessages.DirectoryNotFound, file.FullName)
        Return New FileNotFoundException(msg, file.FullName)

    End Function

    Public Shared Function NoRecordsFound(ByVal argumentName As String, ByVal nameOfData As String) As ArgumentException

        Dim msg As String = String.Format(My.Resources.ExceptionMessages.NoRecordsFound, nameOfData)
        Return New ArgumentException(msg, argumentName)

    End Function

End Class
