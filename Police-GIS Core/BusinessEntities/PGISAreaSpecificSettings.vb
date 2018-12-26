Option Strict On

''' <summary>
''' Entity that represents settings, specific to an area in the police zone.
''' </summary>
''' <remarks></remarks>
Public Class PGISAreaSpecificSettings

    Private m_islpFile As String
    Private m_islpTable As String
    Private m_area As String
    Private m_startupWorkspace As String
    Private m_areaIslpFile As String
    Private m_areaIslpTable As String
    Private m_areaBordersFile As String
    Private m_areaBordersTable As String
    Private m_roadNetworkFile As String
    Private m_areaNaamSpatie As String
    Private m_typeAnalyse As String
    '------------------------------------------------
    ' Specific for street analysis
    '------------------------------------------------

    Private m_roadBufferFile As String
    Private m_roadBufferTable As String
    Private m_roadBufferTempFile As String
    Private m_roadBufferTempTable As String
    Private m_roadAggrFile As String
    Private m_roadAggrTable As String
    Private m_roadAggrTempTable As String

    '------------------------------------------------
    ' Specific for area and blackpoint analysis
    '------------------------------------------------

    Private m_pieAggregationFile As String
    Private m_pieAggregationTable As String
    Private m_pieTable As String
    Private m_pieFile As String

    '------------------------------------------------
    ' Specific for crossroads / black points 
    '------------------------------------------------

    Private m_blackPointFile As String
    Private m_blackPointTable As String


    Private m_numberIncidentsField As String
    Private m_streetIDField As String
    Private m_numberOfClasses As Short

    Private m_werFolder As String
    Private m_roadAggrTempFile As String
    Private _version As String

    Public Property TypeAnalyse() As String
        Get
            Return m_typeAnalyse
        End Get
        Set(ByVal value As String)
            m_typeAnalyse = value
        End Set
    End Property

    Public Property AreaNaamSpatie() As String
        Get
            Return m_areaNaamSpatie
        End Get
        Set(ByVal value As String)
            m_areaNaamSpatie = value
        End Set
    End Property

    Public Property WerkFolder() As String
        Get
            Return m_werFolder
        End Get
        Set(ByVal value As String)
            m_werFolder = value
        End Set
    End Property

    Public Property Version() As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property

    Public Property NumberOfClasses() As Short
        Get
            Return m_numberOfClasses
        End Get
        Set(ByVal value As Short)
            m_numberOfClasses = value
        End Set
    End Property

    Public Property NumberIncidentsField() As String
        Get
            Return m_numberIncidentsField
        End Get
        Set(ByVal value As String)
            m_numberIncidentsField = value
        End Set
    End Property

    Public Property BlackPointTable() As String
        Get
            Return m_blackPointTable
        End Get
        Set(ByVal value As String)
            m_blackPointTable = value
        End Set
    End Property

    Public Property BlackPointFile() As String
        Get
            Return m_blackPointFile
        End Get
        Set(ByVal value As String)
            m_blackPointFile = value
        End Set
    End Property

    Public Property PieFile() As String
        Get
            Return m_pieFile
        End Get
        Set(ByVal value As String)
            m_pieFile = value
        End Set
    End Property

    Public Property PieTable() As String
        Get
            Return m_pieTable
        End Get
        Set(ByVal value As String)
            m_pieTable = value
        End Set
    End Property

    Public Property PieAggregationTable() As String
        Get
            Return m_pieAggregationTable
        End Get
        Set(ByVal value As String)
            m_pieAggregationTable = value
        End Set
    End Property

    Public Property pieAggregationFile() As String
        Get
            Return m_pieAggregationFile
        End Get
        Set(ByVal value As String)
            m_pieAggregationFile = value
        End Set
    End Property

    Public Property RoadAggrTempFile() As String
        Get
            Return m_roadAggrTempFile
        End Get
        Set(ByVal value As String)
            m_roadAggrTempFile = value
        End Set
    End Property

    Public Property RoadAggrTempTable() As String
        Get
            Return m_roadAggrTempTable
        End Get
        Set(ByVal value As String)
            m_roadAggrTempTable = value
        End Set
    End Property

    Public Property RoadAggrTable() As String
        Get
            Return m_roadAggrTable
        End Get
        Set(ByVal value As String)
            m_roadAggrTable = value
        End Set
    End Property

    Public Property RoadAggrFile() As String
        Get
            Return m_roadAggrFile
        End Get
        Set(ByVal value As String)
            m_roadAggrFile = value
        End Set
    End Property

    Public Property RoadBufferTempTable() As String
        Get
            Return m_roadBufferTempTable
        End Get
        Set(ByVal value As String)
            m_roadBufferTempTable = value
        End Set
    End Property

    Public Property RoadBufferTempFile() As String
        Get
            Return m_roadBufferTempFile
        End Get
        Set(ByVal value As String)
            m_roadBufferTempFile = value
        End Set
    End Property

    Public Property RoadBufferTable() As String
        Get
            Return m_roadBufferTable
        End Get
        Set(ByVal value As String)
            m_roadBufferTable = value
        End Set
    End Property

    Public Property RoadBufferFile() As String
        Get
            Return m_roadBufferFile
        End Get
        Set(ByVal value As String)
            m_roadBufferFile = value
        End Set
    End Property

    Public Property RoadNetworkFile() As String
        Get
            Return m_roadNetworkFile
        End Get
        Set(ByVal value As String)
            m_roadNetworkFile = value
        End Set
    End Property

    Public Property AreaBordersTable() As String
        Get
            Return m_areaBordersTable
        End Get
        Set(ByVal value As String)
            m_areaBordersTable = value
        End Set
    End Property

    Public Property AreaBordersFile() As String
        Get
            Return m_areaBordersFile
        End Get
        Set(ByVal value As String)
            m_areaBordersFile = value
        End Set
    End Property

    Public Property AreaIslpTable() As String
        Get
            Return m_areaIslpTable
        End Get
        Set(ByVal value As String)
            m_areaIslpTable = value
        End Set
    End Property

    Public Property AreaIslpFile() As String
        Get
            Return m_areaIslpFile
        End Get
        Set(ByVal value As String)
            m_areaIslpFile = value
        End Set
    End Property

    Public Property StartupWorkspace() As String
        Get
            Return m_startupWorkspace
        End Get
        Set(ByVal value As String)
            m_startupWorkspace = value
        End Set
    End Property

    Public Property Area() As String
        Get
            Return m_area
        End Get
        Set(ByVal value As String)
            m_area = value
        End Set
    End Property

    Public Property islpTable() As String
        Get
            Return m_islpTable
        End Get
        Set(ByVal value As String)
            m_islpTable = value
        End Set
    End Property

    Public Property islpFile() As String
        Get
            Return m_islpFile
        End Get
        Set(ByVal value As String)
            m_islpFile = value
        End Set
    End Property

    Public Property StreetIDField() As String
        Get
            Return m_streetIDField
        End Get
        Set(ByVal value As String)
            m_streetIDField = value
        End Set
    End Property

End Class
