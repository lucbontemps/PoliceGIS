Option Strict On

''' <summary>
''' Entity that represents file settings.
''' </summary>
''' <remarks></remarks>
Public Class PGISFileSettings

    'Private m_iniFile As String = "config.ini"
    Private m_dataFolder As String = "data"
    Private m_islpFolder As String = "ISLP bestanden"
    Private m_outputFolder As String = "result"
    Private m_workFolder As String = "temp"

    Public Property WorkFolder() As String
        Get
            Return m_workFolder
        End Get
        Set(ByVal value As String)
            m_workFolder = value
        End Set
    End Property

    Public Property OutputFolder() As String
        Get
            Return m_outputFolder
        End Get
        Set(ByVal value As String)
            m_outputFolder = value
        End Set
    End Property

    Public Property IslpFolder() As String
        Get
            Return m_islpFolder
        End Get
        Set(ByVal value As String)
            m_islpFolder = value
        End Set
    End Property

    Public Property DataFolder() As String
        Get
            ' If folder ends with "\", remove the slash at the end.
            If m_dataFolder.Chars(m_dataFolder.Length - 1) = "\" Then
                m_dataFolder = m_dataFolder.Remove(m_dataFolder.Length - 1)
            End If
            Return m_dataFolder
        End Get
        Set(ByVal value As String)
            m_dataFolder = value
        End Set
    End Property

End Class
