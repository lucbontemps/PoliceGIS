' System namespaces
Imports System.IO
Imports System.Windows.Forms
Imports System.Xml.Schema
' GIM namespaces
Imports Gim.ErrorHandling
Imports <xmlns="http://schemas.gim.be/PoliceGIS/PoliceGisConfiguration.xsd">

''' <summary>
''' Configuration manager is responsible for:
'''  - getting configuration from disk, from its correct location.
'''  - storing configuration to disk
'''  - provide save defaults when it is not there.
''' </summary>
''' <remarks></remarks>
Public Class PGISConfigurationManager

    ' shared fields
    Private Shared sh_theInstance As PGISConfigurationManager 
    ' instance fields
    Private m_configFile As FileInfo
    Private m_validationReport As ValidationReport
    Private m_fileSettings As PGISFileSettings
    Private m_geocodingSettings As PGISGeocodingSettings
    Private m_areaSpecificSettings As PGISAreaSpecificSettings
    Private _configDoc As XDocument


    Public Property AreaSettings() As PGISAreaSpecificSettings
        Get
            Return m_areaSpecificSettings
        End Get
        Set(ByVal value As PGISAreaSpecificSettings)
            m_areaSpecificSettings = value
        End Set
    End Property

    ReadOnly Property ConfigFile() As FileInfo
        Get
            Return m_configFile
        End Get
    End Property

    ReadOnly Property FileSettings() As PGISFileSettings
        Get
            Return m_fileSettings
        End Get
    End Property

    ReadOnly Property GeocodingSettings() As PGISGeocodingSettings
        Get
            Return m_geocodingSettings
        End Get
    End Property

    ReadOnly Property ValidationReport() As ValidationReport
        Get
            Return m_validationReport
        End Get
    End Property

    Public Shared Function GetInstance() As PGISConfigurationManager

        If sh_theInstance Is Nothing Then
            sh_theInstance = New PGISConfigurationManager()
        End If

        Return sh_theInstance

    End Function

    Public Property ConfigDocument() As XDocument
        Get
            Return _configDoc
        End Get
        Set(ByVal value As XDocument)
            _configDoc = value
        End Set
    End Property

    Private Sub New()
        initiaLizeComponents()
    End Sub

    Private Shared Function GetConfigPath() As String

        Dim configPath As String = String.Format("{0}\{1}", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly.Location), My.Settings.configFile)

        If Not File.Exists(configPath) Then
            CreateDefaultConfig(configPath)
            MessageBox.Show(My.Resources.defaultConfgurationFIleCreated)
        End If

        Return configPath

    End Function

    Public Sub ReadBasicSettings()

        If m_configFile.Exists Then

            ConfigDocument = XDocument.Load(m_configFile.FullName)
            Dim xsdFile As New FileInfo(String.Format("{0}\{1}", m_configFile.Directory.FullName, m_configFile.Name.Replace(".xml", ".xsd")))
            Dim validator As New XsdSchemaValidator()

            validator.Validate(ConfigFile, xsdFile, "http://schemas.gim.be/PoliceGIS/PoliceGisConfiguration.xsd")

            m_validationReport.AddErrors(validator.Errors)
            m_validationReport.AddErrors(validator.Warnings)

            m_areaSpecificSettings.Area = ConfigDocument...<area>.<Name>.Value
            SetFileSettings()
            SetGeocodeSettings()

        Else
            Throw New InvalidConfigurationException("configFile is geen XML bestand")
        End If

    End Sub

    'Private Sub XSDErrors(ByVal o As Object, ByVal e As ValidationEventArgs)
    '    m_validationReport.AddError(e.Message)
    'End Sub

    Private Sub SetFileSettings()

        With ConfigDocument.<policeGisConfig>.<directories>
            m_fileSettings.DataFolder = .<dataFolder>.Value
        End With
        With m_fileSettings
            .IslpFolder = Path.Combine(.DataFolder, "ISLP bestanden")
            .WorkFolder = Path.Combine(.DataFolder, "werkfolder")
            .OutputFolder = Path.Combine(.DataFolder, "resultaten")
        End With
    End Sub


    Private Sub SetGeocodeSettings()

        With m_geocodingSettings
            .Version = GetVersion()
            .HectoMeterPolesEnabled = False
            .AddressPointsEnabled = True
            .Workspace = String.Format("{0}\workspaces\{1}{2}.wor", m_fileSettings.DataFolder, m_areaSpecificSettings.Area, .Version)
            .AddressNotFoundtable = ConfigDocument...<addressNotFoundSelection>.Value
            .AllowInteraction = True
            .EnableModule = True
            .OutputCoordinateSystem = CoreLibConstants.CS_LAMBERT_1972
            .TabFileStreetGeocoding = String.Format("{0}\basiskaarten\{1}\{1}_gc.tab", m_fileSettings.DataFolder, m_areaSpecificSettings.Area)
            .TabFileStreetlength = String.Format("{0}\basiskaarten\{1}\{1}_gc_aggr.tab", m_fileSettings.DataFolder, m_areaSpecificSettings.Area)
            .StreetLengthMunicipalityFields = ConfigDocument...<GeocodingColumns>.<StreetLengthMunicipalityFields>.Elements.Select(Function(el) el.Value).ToList
            .MaxStreetLength = -1
            .TabFileAdminBorders = String.Format("{0}\basiskaarten\{1}\{1}_a8.tab", m_fileSettings.DataFolder, m_areaSpecificSettings.Area)
            .AdminBordersNameCol = ConfigDocument...<GeocodingColumns>.<AdminBordersNameCol>.Value
            'Desactivated as ap_ file not found
            '.TabFileAddressPoints = String.Format("{0}\basiskaarten\{1}\{1}_ap.tab", m_fileSettings.DataFolder, m_areaSpecificSettings.Area)
            .AddressPtsMunicipalityField = ConfigDocument...<GeocodingColumns>.<AddressPtsMunicipalityField>.Value
            .AddressPtsNumberField = ConfigDocument...<GeocodingColumns>.<AddressPtsNumberField>.Value
            .AddressPtsStreetField = ConfigDocument...<GeocodingColumns>.<AddressPtsStreetField>.Value
            .TabFileHectoMeterPoles = String.Format("{0}\basiskaarten\{1}\{1}_hm.tab", m_fileSettings.DataFolder, m_areaSpecificSettings.Area)
            .HectoDistanceField = ConfigDocument...<GeocodingColumns>.<HectoDistanceField>.Value
            .HectoRouteField = ConfigDocument...<GeocodingColumns>.<HectoRouteField>.Value
            .HectoAlternativeNameField = ConfigDocument...<GeocodingColumns>.<HectoAlternativeNameField>.Value
            .Street1FieldCandidates = ConfigDocument...<GeocodingColumns>.<Street1FieldCandidates>.Elements.Select(Function(el) el.Value).ToList
            .Street2FieldCandidates = ConfigDocument...<GeocodingColumns>.<Street2FieldCandidates>.Elements.Select(Function(el) el.Value).ToList
            .NumberFieldCandidates = ConfigDocument...<GeocodingColumns>.<NumberFieldCandidates>.Elements.Select(Function(el) el.Value).ToList
            .HectoMeterFieldCandidates = ConfigDocument...<GeocodingColumns>.<HectoMeterFieldCandidates>.Elements.Select(Function(el) el.Value).ToList
            .MunicipalityFieldCandidates = ConfigDocument...<GeocodingColumns>.<MunicipalityFieldCandidates>.Elements.Select(Function(el) el.Value).ToList
        End With

    End Sub

    Public Sub SetAreaSettings(ByVal area As InteresseGebied)

        With m_areaSpecificSettings
            .Version = GetVersion()
            .Area = area.Naam
            .WerkFolder = String.Format("{0}\werkfolder\", m_fileSettings.DataFolder)
            .StartupWorkspace = String.Format("{0}\workspaces\{1}{2}.wor", m_fileSettings.DataFolder, .Area, m_geocodingSettings.Version)
            .AreaBordersTable = String.Format("_{0}_a8", area.Naam)
            .AreaBordersFile = String.Format("{0}\basiskaarten\{1}\{1}_a8.tab", m_fileSettings.DataFolder, .Area)
            .AreaIslpTable = My.Settings.AreaISLPTable
            .AreaIslpFile = String.Format("{0}{1}.TAB", .WerkFolder, .AreaIslpTable) ' File where s_areaIslpTable is stored
            .RoadAggrTable = String.Format("{0}_gc_aggr", area.NaamStreep)
            .RoadAggrFile = String.Format("{0}\basiskaarten\{1}\{1}_gc_aggr.tab", m_fileSettings.DataFolder, .Area)
            .RoadBufferTempTable = String.Format("BufferTable_temp", area.NaamStreep) 'Table, temp copy of roadBufferTableName in workfolder
            .RoadBufferTempFile = String.Format("{0}\werkfolder\{1}.TAB", m_fileSettings.DataFolder, .RoadBufferTempTable)
            .RoadBufferTable = String.Format("{0}_gc_buff", area.NaamStreep) 'Table, buffer of fixed distance around the roads
            .RoadBufferFile = String.Format("{0}\basiskaarten\{1}\{1}_gc_buff.tab", m_fileSettings.DataFolder, .Area)
            .RoadNetworkFile = String.Format("{0}\basiskaarten\{1}\{1}_gc_nw.tab", m_fileSettings.DataFolder, .Area)
            .pieAggregationFile = .AreaBordersFile
            .PieAggregationTable = .AreaBordersTable
            .PieTable = String.Format("PieTable_temp", area.NaamStreep)
            .PieFile = String.Format("{0}\werkfolder\{1}.TAB", m_fileSettings.DataFolder, .PieTable)
            .NumberIncidentsField = ConfigDocument...<NumberIncidentsField>.Value
            .NumberOfClasses = Short.Parse(ConfigDocument...<NumberOfClasses>.Value)
            .StreetIDField = ConfigDocument...<StreetIDField>.Value
            .AreaNaamSpatie = area.NaamSpatie
        End With

    End Sub

    Public Sub initiaLizeComponents()

        m_configFile = New FileInfo(GetConfigPath)
        m_validationReport = New ValidationReport
        m_geocodingSettings = New PGISGeocodingSettings
        m_fileSettings = New PGISFileSettings
        m_areaSpecificSettings = New PGISAreaSpecificSettings
        ReadBasicSettings()

    End Sub

    Private Shared Sub CreateDefaultConfig(ByVal configPath As String)
        Dim defaultConfig = <?xml version="1.0" encoding="utf-8"?>
                            <policeGisConfig xmlns="http://schemas.gim.be/PoliceGIS/PoliceGisConfiguration.xsd" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:schemaLocation="http://schemas.gim.be/PoliceGIS/PoliceGisConfiguration.xsd PoliceGisConfiguration.xsd">
                                <release>
                                    <majorVersion>2</majorVersion>
                                    <minorVersion>1</minorVersion>
                                    <implementationVersion>0</implementationVersion>
                                </release>
                                <language></language>
                                <releaseDate>2010-01-15</releaseDate>
                                <directories>
                                    <dataFolder>C:\Program Files\GIM\PolitieGIS\data</dataFolder>
                                </directories>
                                <geocoding>
                                    <GeocodingColumns>
                                        <AddressPtsMunicipalityField>Gemeente</AddressPtsMunicipalityField>
                                        <AddressPtsNumberField>HUISNR</AddressPtsNumberField>
                                        <AddressPtsStreetField>Name_CRAB</AddressPtsStreetField>
                                        <AdminBordersNameCol>NAME</AdminBordersNameCol>
                                        <HectoRouteField>wegnr_ISLP</HectoRouteField>
                                        <HectoDistanceField>HM</HectoDistanceField>
                                        <HectoAlternativeNameField></HectoAlternativeNameField>
                                        <StreetLengthMunicipalityFields>
                                            <name>L_AXON</name>
                                        </StreetLengthMunicipalityFields>
                                        <Street1FieldCandidates>
                                            <name>Straat</name>
                                            <name>Rue</name>
                                        </Street1FieldCandidates>
                                        <Street2FieldCandidates>
                                            <name>Kruispunt met</name>
                                            <name>Kruispunt_met</name>
                                        </Street2FieldCandidates>
                                        <NumberFieldCandidates>
                                            <name>Nr.</name>
                                            <name>num</name>
                                        </NumberFieldCandidates>
                                        <HectoMeterFieldCandidates>
                                            <name>Hecto</name>
                                        </HectoMeterFieldCandidates>
                                        <MunicipalityFieldCandidates>
                                            <name>Gemeente</name>
                                        </MunicipalityFieldCandidates>
                                    </GeocodingColumns>
                                    <MaximumStreetLength>200</MaximumStreetLength>
                                    <addressNotFoundSelection>Niet_gevonden_incidenten</addressNotFoundSelection>
                                    <outputCoordinateSystem>Earth Projection 3, 1019, ""m"", 4.3674866667, 90, 49.8333339, 51.1666672333, 150000.01300000001, 5400088.4380000001 Bounds (-128761666.217, -123511577.792) (129061666.243, 134311754.668)</outputCoordinateSystem>
                                </geocoding>
                                <analysis>
                                    <aggregationLevels>
                                        <zone>Politie zone</zone>
                                        <commune>Gemeente</commune>
                                        <quarter>Wijk</quarter>
                                    </aggregationLevels>
                                    <analyseTypes>
                                        <point>Punten</point>
                                        <street>Per straat </street>
                                        <area>Per gebied </area>
                                        <black_points>Zwarte punten</black_points>
                                        <Controles>Controles </Controles>
                                        <crime_series>Serie inbraken</crime_series>
                                    </analyseTypes>
                                    <NumberIncidentsField>Aantal_Incidenten</NumberIncidentsField>
                                    <NumberOfClasses>5</NumberOfClasses>
                                    <StreetIDField>streetID</StreetIDField>
                                    <areas>
                                        <area>
                                            <Name>01PZ_NOL</Name>
                                        </area>
                                    </areas>
                                </analysis>
                            </policeGisConfig>
        defaultConfig.Save(configPath)
    End Sub

    Private Function GetVersion() As String
        Return String.Format("_{0}_{1}", ConfigDocument...<majorVersion>.Value, ConfigDocument...<minorVersion>.Value)
    End Function

End Class
