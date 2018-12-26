Option Strict On


''' <summary>
''' Entity that represents settings, specific to geocoding.
''' </summary>
''' <remarks></remarks>
Public Class PGISGeocodingSettings

    Public Const ILLEGAL_COLUMN_INDEX As Integer = -1

    '---------------------------------------------------
    ' Fields which take values from configuration file
    '---------------------------------------------------

    ''' True when module is enabled AND all settings are valid.
    Private m_enableModule As Boolean
    Public Property EnableModule() As Boolean
        Get
            Return m_enableModule
        End Get
        Set(ByVal value As Boolean)
            m_enableModule = value
        End Set
    End Property


    ''' True if there is a GUI AND it is allowed to ask the user for a response.
    ''' False if ther is no GUI or the GUI not allowed to show any blocking dialogs
    ''' or any other interactive input/output.
    ''' This option is necessary for fully automated programs that eliminated
    ''' any interaction, such as overnight batch jobs, etc.
    ''' This setting doesn't come from a configuration file. It is the application 
    ''' that determines whether interaction is allowed or not.
    Private m_allowInteraction As Boolean
    Public Property AllowInteraction() As Boolean
        Get
            Return m_allowInteraction
        End Get
        Set(ByVal value As Boolean)
            m_allowInteraction = value
        End Set
    End Property


    ''' workspace to open for showing results
    Private m_workspace As String
    Public Property Workspace() As String
        Get
            Return m_workspace
        End Get
        Set(ByVal value As String)
            m_workspace = value
        End Set
    End Property


    ''' The desired coordinate system for the geocoded output
    Private m_outputCoordinateSystem As String
    Public Property OutputCoordinateSystem() As String
        Get
            Return m_outputCoordinateSystem
        End Get
        Set(ByVal value As String)
            m_outputCoordinateSystem = value
        End Set
    End Property


    ' path to geocoding layer's TAB file
    Private m_tabFileStreetGeocoding As String
    Public Property TabFileStreetGeocoding() As String
        Get
            Return m_tabFileStreetGeocoding
        End Get
        Set(ByVal value As String)
            m_tabFileStreetGeocoding = value
        End Set
    End Property

    ' path to TAB file of administrative borders
    Private m_tabFileAdminBorders As String
    Public Property TabFileAdminBorders() As String
        Get
            Return m_tabFileAdminBorders
        End Get
        Set(ByVal value As String)
            m_tabFileAdminBorders = value
        End Set
    End Property


    ' path to TAB file of street length layer
    Private m_tabFileStreetlength As String
    Public Property TabFileStreetlength() As String
        Get
            Return m_tabFileStreetlength
        End Get
        Set(ByVal value As String)
            m_tabFileStreetlength = value
        End Set
    End Property


    ''' path to TAB file of address points. 
    ''' in principle this can be any data. 
    ''' In practice this will be CRAB data
    Private m_tabFileAddressPoints As String
    Public Property TabFileAddressPoints() As String
        Get
            Return m_tabFileAddressPoints
        End Get
        Set(ByVal value As String)
            m_tabFileAddressPoints = value
        End Set
    End Property

    ' path to TAB file of hectometer poles
    Private m_tabFileHectoMeterPoles As String
    Public Property TabFileHectoMeterPoles() As String
        Get
            Return m_tabFileHectoMeterPoles
        End Get
        Set(ByVal value As String)
            m_tabFileHectoMeterPoles = value
        End Set
    End Property

    ''' True if the table for address points is present and all necessary settings are valid
    Private m_addressPointsEnabled As Boolean
    Public Property AddressPointsEnabled() As Boolean
        Get
            Return m_addressPointsEnabled
        End Get
        Set(ByVal value As Boolean)
            m_addressPointsEnabled = value
        End Set
    End Property


    ''' True if the table for hectometer poles is present  and all necessary settings are valid
    Private m_hectoMeterPolesEnabled As Boolean
    Public Property HectoMeterPolesEnabled() As Boolean
        Get
            Return m_hectoMeterPolesEnabled
        End Get
        Set(ByVal value As Boolean)
            m_hectoMeterPolesEnabled = value
        End Set
    End Property


    ' name of table with addresses that would not be geocoded.
    ' Table for the accidents/crimes were geocoding failed.
    Private m_addressNotFoundtable As String
    Public Property AddressNotFoundtable() As String
        Get
            Return m_addressNotFoundtable
        End Get
        Set(ByVal value As String)
            m_addressNotFoundtable = value
        End Set
    End Property


    ''' Field for name of street in both locStreetGeocoding and locStreetlength
    Private m_gcLayerStreetNameField As String = "FULLNAME"
    Public Property GCLayerStreetNameField() As String
        Get
            Return m_gcLayerStreetNameField
        End Get
        Set(ByVal value As String)
            m_gcLayerStreetNameField = value
        End Set
    End Property


    ''' Column name for street in address points table
    Private m_addressPtsStreetField As String
    Public Property AddressPtsStreetField() As String
        Get
            Return m_addressPtsStreetField
        End Get
        Set(ByVal value As String)
            m_addressPtsStreetField = value
        End Set
    End Property


    ''' Column name for house number in address points table
    Private m_addressPtsNumberField As String
    Public Property AddressPtsNumberField() As String
        Get
            Return m_addressPtsNumberField
        End Get
        Set(ByVal value As String)
            m_addressPtsNumberField = value
        End Set
    End Property


    ''' Column name for commune in address points table
    Private m_addressPtsMunicipalityField As String
    Public Property AddressPtsMunicipalityField() As String
        Get
            Return m_addressPtsMunicipalityField
        End Get
        Set(ByVal value As String)
            m_addressPtsMunicipalityField = value
        End Set
    End Property


    ''' Column name for route in hectometer pole table. This is the equivalent of street in 
    ''' the address points, read from street1 in the input table.
    Private m_hectoRouteField As String
    Public Property HectoRouteField() As String
        Get
            Return m_hectoRouteField
        End Get
        Set(ByVal value As String)
            m_hectoRouteField = value
        End Set
    End Property

    ''' Column name for alternative name in hectometer pole table. This is the equivalent of street in 
    ''' the address points, read from street1 in the input table.
    Private m_hectoAlternativeNameField As String
    Public Property HectoAlternativeNameField() As String
        Get
            Return m_hectoAlternativeNameField
        End Get
        Set(ByVal value As String)
            m_hectoAlternativeNameField = value
        End Set
    End Property

    Private m_hectoDistanceField As String
    Public Property HectoDistanceField() As String
        Get
            Return m_hectoDistanceField
        End Get
        Set(ByVal value As String)
            m_hectoDistanceField = value
        End Set
    End Property

    ' List of column names in geocoding street layer. 
    ' ( = _gc for TeleAtlas data, _sa for URBIS data)
    ' Each column contains a commune/municipality name in one of the available/supported 
    ' languages. This allows us to find a commune whatever the language of 
    ' the ISLP input was, as long as it is in one of the supported languages. 
    ' Otherwise the ISLP input has to be in one predefined language and we 
    ' don't want that restriction. 
    ' streetCommuneFields(0)	as String

    Private m_streetLengthMunicipalityFields As New List(Of String)
    Public Property StreetLengthMunicipalityFields() As List(Of String)
        Get
            Return m_streetLengthMunicipalityFields
        End Get
        Set(ByVal value As List(Of String))
            m_streetLengthMunicipalityFields = value
        End Set
    End Property


    ''' Column that contains name of area in the administrative borders table.
    Private m_adminBordersNameCol As String
    Public Property AdminBordersNameCol() As String
        Get
            Return m_adminBordersNameCol
        End Get
        Set(ByVal value As String)
            m_adminBordersNameCol = value
        End Set
    End Property


    '---------------------------------------------------
    ' Fields which take values from controls in GUI 
    '---------------------------------------------------


    ''' path to file containing data that must be geocoded
    Private m_inputFile As String
    Public Property InputFile() As String
        Get
            Return m_inputFile
        End Get
        Set(ByVal value As String)
            m_inputFile = value
        End Set
    End Property


    ''' name of table with geocoded results
    Private m_outputTable As String
    Public Property OutputTable() As String
        Get
            Return m_outputTable
        End Get
        Set(ByVal value As String)
            m_outputTable = value
        End Set
    End Property

    Private m_inputStreet1Field As String
    Public Property InputStreet1Field() As String
        Get
            Return m_inputStreet1Field
        End Get
        Set(ByVal value As String)
            m_inputStreet1Field = value
        End Set
    End Property

    ' Default column name for colIndexStreet1, read from configuration file.
    'colNameStreet1Default	as String 
    Private m_street1FieldCandidates As New List(Of String)
    Public Property Street1FieldCandidates() As List(Of String)
        Get
            Return m_street1FieldCandidates
        End Get
        Set(ByVal value As List(Of String))
            m_street1FieldCandidates = value
        End Set
    End Property


    Private m_inputNumberField As String
    Public Property InputNumberField() As String
        Get
            Return m_inputNumberField
        End Get
        Set(ByVal value As String)
            m_inputNumberField = value
        End Set
    End Property

    ''' Default column name  for colIndexHouseNumber, read from configuration file.
    Private m_numberFieldCandidates As New List(Of String)
    Public Property NumberFieldCandidates() As List(Of String)
        Get
            Return m_numberFieldCandidates
        End Get
        Set(ByVal value As List(Of String))
            m_numberFieldCandidates = value
        End Set
    End Property


    Private m_inputStreet2Field As String
    Public Property InputStreet2Field() As String
        Get
            Return m_inputStreet2Field
        End Get
        Set(ByVal value As String)
            m_inputStreet2Field = value
        End Set
    End Property


    ' Default column name for colIndexStreet2, read from configuration file.
    Private m_street2FieldCandidates As New List(Of String)
    Public Property Street2FieldCandidates() As List(Of String)
        Get
            Return m_street2FieldCandidates
        End Get
        Set(ByVal value As List(Of String))
            m_street2FieldCandidates = value
        End Set
    End Property

    ' True if we need to search for crossroads too.
    Public ReadOnly Property SearchIntersections() As Boolean
        Get
            Return Not String.IsNullOrEmpty(InputStreet2Field)
        End Get
    End Property


    Private m_inputMunicipalityField As String
    Public Property InputMunicipalityField() As String
        Get
            Return m_inputMunicipalityField
        End Get
        Set(ByVal value As String)
            m_inputMunicipalityField = value
        End Set
    End Property


    ''' Default value for colIndexCommune, read from configuration file.
    Private m_municipalityFieldCandidates As New List(Of String)
    Public Property MunicipalityFieldCandidates() As List(Of String)
        Get
            Return m_municipalityFieldCandidates
        End Get
        Set(ByVal value As List(Of String))
            m_municipalityFieldCandidates = value
        End Set
    End Property


    ''' Default column name for colIndexHectometer, read from configuration file.
    Private m_hectoMeterFieldCandidates As New List(Of String)
    Public Property HectoMeterFieldCandidates() As List(Of String)
        Get
            Return m_hectoMeterFieldCandidates
        End Get
        Set(ByVal value As List(Of String))
            m_hectoMeterFieldCandidates = value
        End Set
    End Property


    ' True if we need to search for hectometer poles too.
    Public ReadOnly Property SearchHectormeterPoles() As Boolean
        Get
            Return Not String.IsNullOrEmpty(InputHectoMeterField)
        End Get
    End Property


    Private m_inputHectoMeterField As String
    Public Property InputHectoMeterField() As String
        Get
            Return m_inputHectoMeterField
        End Get
        Set(ByVal value As String)
            m_inputHectoMeterField = value
        End Set
    End Property


    Private m_fieldNames As New List(Of String)
    Public Property FieldNames() As List(Of String)
        Get
            Return m_fieldNames
        End Get
        Set(ByVal value As List(Of String))
            m_fieldNames = value
        End Set
    End Property


    ''' <summary>
    ''' Columns type of the ISLP input file. The user can modify the types.
    ''' </summary>
    ''' <remarks></remarks>
    Private m_columnTypes As New List(Of ColumnTypeDescriptor)
    Public Property ColumnTypes() As List(Of ColumnTypeDescriptor)
        Get
            Return m_columnTypes
        End Get
        Set(ByVal value As List(Of ColumnTypeDescriptor))
            m_columnTypes = value
        End Set
    End Property



    'How far the marker symbol is set from the street axis

    Public Shared ReadOnly Property MarkerOffset() As Integer
        Get
            Return 1
        End Get
    End Property


    'Max allowed length of street when adresses have no house number.
    'If street is longer it won't be geocoded its geocode statis will 
    ' be LONG_STREET

    Private m_maxStreetLength As Integer
    Public Property MaxStreetLength() As Integer
        Get
            Return m_maxStreetLength
        End Get
        Set(ByVal value As Integer)
            m_maxStreetLength = value
        End Set
    End Property


    Private m_version As String
    Public Property Version() As String
        Get
            Return m_version
        End Get
        Set(ByVal value As String)
            m_version = value
        End Set
    End Property

End Class

