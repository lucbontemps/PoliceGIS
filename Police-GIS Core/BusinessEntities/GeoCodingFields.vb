
Option Strict On

''' <summary>
''' Entity which represents the fiels from an input file with addresses
''' whihc you want to geocode.
''' </summary>
''' <remarks></remarks>
Public Class GeoCodingFields

    Private m_street As String
    Private m_number As String
    Private m_city As String
    Private m_intersection As String
    Private m_hectoMeterPole As String


    Public Property HectoMeterPole() As String
        Get
            Return m_hectoMeterPole
        End Get
        Set(ByVal value As String)
            m_hectoMeterPole = value
        End Set
    End Property

    Public Property Intersection() As String
        Get
            Return m_intersection
        End Get
        Set(ByVal value As String)
            m_intersection = value
        End Set
    End Property

    Public Property City() As String
        Get
            Return m_city
        End Get
        Set(ByVal value As String)
            m_city = value
        End Set
    End Property

    Public Property Number() As String
        Get
            Return m_number
        End Get
        Set(ByVal value As String)
            m_number = value
        End Set
    End Property

    Public Property Street() As String
        Get
            Return m_street
        End Get
        Set(ByVal value As String)
            m_street = value
        End Set
    End Property

End Class
