
Public Class GeocodingResult


    Private m_rowId As Integer

    ' basic result: found or not
    Private m_pointFound As Boolean

    ' more detailed result: 
    ' what kind of match we found 'exact/approximate/not found, 
    ' and the method: address point / hecto meter poles /mapinfo geocoding
    Private m_statusCode As GeocodingStatusCode

    ' valid when found: x and y coordinates
    Private m_xCoordinate As Double
    Private m_yCoordinate As Double

    ' the address that lead to the match
    Private m_address As String
    Private m_type As String
    Public Property Type() As String
        Get
            Return m_type
        End Get
        Set(ByVal value As String)
            m_type = value
        End Set
    End Property




    Public Sub New()

        ' Clear does the same thing as the initialization should:
        ' set every field to its default value
        Clear()

    End Sub

    Property RowId() As Integer
        Get
            Return m_rowId
        End Get
        Set(ByVal value As Integer)
            m_rowId = value
        End Set
    End Property

    Property XCoord() As Double
        Get
            Return m_xCoordinate
        End Get
        Set(ByVal value As Double)
            m_xCoordinate = value
        End Set
    End Property

    Property YCoord() As Double
        Get
            Return m_yCoordinate
        End Get
        Set(ByVal value As Double)
            m_yCoordinate = value
        End Set
    End Property

    Property Address() As String
        Get
            Return m_address
        End Get
        Set(ByVal value As String)
            m_address = value
        End Set
    End Property


    Property StatusCode() As GeocodingStatusCode
        Get
            Return m_statusCode
        End Get
        Set(ByVal value As GeocodingStatusCode)
            m_statusCode = value
        End Set
    End Property


    Public Function GetStatusText() As String
        
        Dim text As String = "UNKNOWN"

        Select Case m_statusCode

            Case GeocodingStatusCode.NotFound
                text = My.Resources.GeocodingStatusMessages.NotFound

            Case GeocodingStatusCode.ExactMatchWithMapInfo
                text = My.Resources.GeocodingStatusMessages.ExactWithMapinfo

            Case GeocodingStatusCode.ApproximateMatchWithMapInfo
                text = My.Resources.GeocodingStatusMessages.ApproximateWithMapInfo

            Case GeocodingStatusCode.ExactAddressPoint
                text = My.Resources.GeocodingStatusMessages.ExactAddressPoint

            Case GeocodingStatusCode.ExactHectometerPole
                text = My.Resources.GeocodingStatusMessages.ExactHectometerPole

            Case GeocodingStatusCode.LongStreet
                text = My.Resources.GeocodingStatusMessages.LongStreet

            Case Else

                Dim msg = String.Format("Internal error: value {0} was of type GeocodingStatusCode was not expected in StatusText.", m_statusCode)
                Throw New PoliceGisException(msg)

        End Select

        Return text

    End Function

    Property PointFound() As Boolean
        Get
            Return m_pointFound
        End Get
        Set(ByVal value As Boolean)
            m_pointFound = value
        End Set
    End Property

    Public Sub Clear()

        m_rowId = -1

        ' Start as False, becomes true when one of the search methods finds a result.
        m_pointFound = False

        ' Address used to geocode the record, or the address used by the last search method if it wasn't found.
        ' The address used by the last search method. 
        m_address = ""

        ' x and y coordinate of point if it was found
        m_xCoordinate = 0.0
        m_yCoordinate = 0.0
        m_statusCode = GeocodingStatusCode.NotFound
        m_type = ""
    End Sub

End Class
