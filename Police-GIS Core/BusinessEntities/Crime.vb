Public Class Crime

    Private m_rowID As Integer
    Private m_endDate As DateTime
    Private m_startDate As DateTime
    Private m_geocodeStatus As String

    Public ReadOnly Property Interval() As Integer
        Get
            Return CInt(TimeSpan.FromTicks(EndDateTime.Ticks - StartDateTime.Ticks).TotalHours)
        End Get
    End Property

    Public Property RowID() As Integer
        Get
            Return m_rowID
        End Get
        Set(ByVal value As Integer)
            m_rowID = value
        End Set
    End Property

    Public Property StartDateTime() As DateTime
        Get
            Return m_startDate
        End Get
        Set(ByVal value As DateTime)
            m_startDate = value
        End Set
    End Property

    Public Property EndDateTime() As DateTime
        Get
            Return m_endDate
        End Get
        Set(ByVal value As DateTime)
            m_endDate = value
        End Set
    End Property

    Public Property GeocodeStatus() As String
        Get
            Return m_geocodeStatus
        End Get
        Set(ByVal value As String)
            m_geocodeStatus = value
        End Set
    End Property

End Class
