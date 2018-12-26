
Imports Gim.ErrorHandling

<Serializable()> _
Public Class PoliceGisException
    Inherits GimBaseException


    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal technicalInfo As String)
        MyBase.New(message, technicalInfo)
    End Sub

    Public Sub New(ByVal message As String, ByVal innerException As Exception)
        MyBase.New(message, innerException)
    End Sub


    Public Sub New(ByVal message As String, ByVal technicalInfo As String, ByVal innerException As Exception)
        MyBase.New(message, technicalInfo, innerException)
    End Sub

End Class
