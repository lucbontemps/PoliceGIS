Option Strict On

' System namespaces
Imports System.Globalization
Imports System.IO
Imports System.Text
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization


Public MustInherit Class AbstractXsdConfigurationReader(Of T)

#Region " private fields "

    Private m_isValid As Boolean = False
    Private m_isValidated As Boolean = False
    Private m_report As New ValidationReport

#End Region

#Region " constructor "

    Public Sub New()

        ' empty constructor 

    End Sub

#End Region


    ''' <summary>
    ''' Whether the contents are valid or not.
    ''' If the contents have not been validated, the result is also false.
    ''' </summary>
    ''' <value></value>
    ''' <returns>
    ''' True when contents were validated succesfully
    ''' False when they were not validated yet or when there are validation errors.
    ''' </returns>
    ''' <remarks></remarks>
    ReadOnly Property IsValid() As Boolean
        Get
            Return m_isValid
        End Get
    End Property

    Property IsValidated() As Boolean
        Get
            Return m_isValidated
        End Get
        Set(ByVal value As Boolean)
            m_isValidated = value
        End Set
    End Property

    ' can't replace the reference, but you can edit the report.
    ReadOnly Property Report() As ValidationReport
        Get
            Return m_report
        End Get
    End Property


    MustOverride ReadOnly Property TargetNamespace() As String

    Public MustOverride Sub Validate()

    Public Sub ValidateXMLFile(ByVal configFile As System.IO.FileInfo, _
                               ByVal xsdFile As System.IO.FileInfo)

        Dim val As New XsdSchemaValidator()
        val.Validate(configFile, xsdFile, TargetNamespace())

        If val.HasErrorsOrWarning() Then
            m_report.AddErrors(val.Errors)
            m_report.AddErrors(val.Warnings)
        End If

        IsValidated = True

    End Sub

    ''' <summary>
    ''' Reads a configurationobject from an XML file, without any validation.
    ''' </summary>
    ''' <param name="configFile">XML file to read</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Overloads Function ReadConfigFile(ByVal configFile As System.IO.FileInfo) As T

        If configFile Is Nothing Then
            Throw ExceptionProvider.NullArgException("configFile")
        End If

        ' Refresh FileInfo state so Exists() returns an up-to-date result
        configFile.Refresh()
        If Not configFile.Exists Then
            Throw ExceptionProvider.PathArgNotFoundException("configFile", configFile.FullName)
        End If

        ' read the configuration for further validation
        Try

            Dim result As T = Nothing
            Dim configSerializer = New XmlSerializer(GetType(T))
            Using configStream As FileStream = configFile.OpenRead()

                Dim objConfig As Object = configSerializer.Deserialize(configStream)
                result = DirectCast(objConfig, T)
                configStream.Close()

            End Using

            Return result

        Catch ex As Exception

            Throw New InvalidConfigurationException(String.Format("Kon configuratie bestand {0} niet laden.", configFile.FullName))

        End Try

    End Function

End Class
