Public Class InteresseGebied

    Private m_naam As String
    Private m_naamParent As String
    Private m_level As Short
    Private m_naamSpatie As String
    Private m_naamStreep As String
    Private m_politieZone As String


    Public Property PolitieZone() As String
        Get
            Return m_politieZone
        End Get
        Set(ByVal value As String)
            m_politieZone = value
        End Set
    End Property

    Public Property NaamStreep() As String
        Get
            Return m_naamStreep
        End Get
        Set(ByVal value As String)
            m_naamStreep = value
        End Set
    End Property

    Public Property NaamSpatie() As String
        Get
            Return m_naamSpatie
        End Get
        Set(ByVal value As String)
            m_naamSpatie = value
        End Set
    End Property

    Public Property Level() As Short
        Get
            Return m_level
        End Get
        Set(ByVal value As Short)
            m_level = value
        End Set
    End Property

    Public Property NaamParent() As String
        Get
            Return m_naamParent
        End Get
        Set(ByVal value As String)
            m_naamParent = value
        End Set
    End Property

    Public Property Naam() As String
        Get
            Return m_naam
        End Get
        Set(ByVal value As String)
            m_naam = value
        End Set
    End Property

End Class
