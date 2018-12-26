Public Class CrimeSerieFields

    Private m_startDate As String
    Private m_endDate As String
    Private m_startTime As String
    Private m_endTime As String
    Private m_timeDiffColumn As String
    Private m_maxDistance As Integer
    Private m_maxTimeSpanHours As Integer
    Private m_maxGapHours As Integer

    Public Property MaxGapHours() As Integer
        Get
            Return m_maxGapHours
        End Get
        Set(ByVal value As Integer)
            m_maxGapHours = value
        End Set
    End Property

    Public Property MaxTimeSpanHours() As Integer
        Get
            Return m_maxTimeSpanHours
        End Get
        Set(ByVal value As Integer)
            m_maxTimeSpanHours = value
        End Set
    End Property

    Public Property MaxDistance() As Integer
        Get
            Return m_maxDistance
        End Get
        Set(ByVal value As Integer)
            m_maxDistance = value
        End Set
    End Property

    Public Property TimeDiffColumn() As String
        Get
            Return m_timeDiffColumn
        End Get
        Set(ByVal value As String)
            m_timeDiffColumn = value
        End Set
    End Property

    Public Property StartTime() As String
        Get
            Return m_startTime
        End Get
        Set(ByVal value As String)
            m_startTime = value
        End Set
    End Property

    Public Property EndTime() As String
        Get
            Return m_endTime
        End Get
        Set(ByVal value As String)
            m_endTime = value
        End Set
    End Property

    Public Property StartDate() As String
        Get
            Return m_startDate
        End Get
        Set(ByVal value As String)
            m_startDate = value
        End Set
    End Property

    Public Property EndDate() As String
        Get
            Return m_endDate
        End Get
        Set(ByVal value As String)
            m_endDate = value
        End Set
    End Property

End Class
