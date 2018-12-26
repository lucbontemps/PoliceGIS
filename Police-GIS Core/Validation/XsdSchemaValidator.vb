Option Strict On

' System namespaces
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports System.Text
Imports System.Xml.Xsl

''' <summary>
''' Validates an XML file according to an XSD schema file
''' </summary>
''' <remarks></remarks>
Public Class XsdSchemaValidator

#Region " private fields "

    Private m_errors As List(Of String)
    Private m_warnings As List(Of String)

#End Region

    ''' <summary>
    ''' Default constructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()

        m_errors = New List(Of String)
        m_warnings = New List(Of String)

    End Sub

    ReadOnly Property Errors() As List(Of String)
        Get
            Return m_errors
        End Get
    End Property

    ReadOnly Property Warnings() As List(Of String)
        Get
            Return m_warnings
        End Get
    End Property

    ReadOnly Property HasErrorsOrWarning() As Boolean
        Get
            Return HasErrors Or HasWarnings
        End Get
    End Property

    ReadOnly Property HasErrors() As Boolean
        Get
            Return m_errors.Count > 0
        End Get
    End Property

    ReadOnly Property HasWarnings() As Boolean
        Get
            Return m_warnings.Count > 0
        End Get
    End Property



#Region " private methods "

    ''' <summary>
    ''' Process validation events, checks if they are errors or warnings.
    ''' </summary>
    ''' <param name="sender"></param>


    Private Sub ValidationEventHandler(ByVal sender As Object, ByVal e As ValidationEventArgs)

        Select Case e.Severity

            Case XmlSeverityType.Error
                m_errors.Add(e.Message)

            Case XmlSeverityType.Warning
                m_warnings.Add(e.Message)

        End Select

    End Sub

#End Region

    Public Sub Validate(ByVal configFile As FileInfo, ByVal xsdFile As FileInfo, ByVal targetNamespace As String)

        ' delegate work to an overloaded version; 
        ' That version should check configFile (and readerSettings)
        ' We schould check xsdFile and targetNamespace, from which we build readerSettings

        ' if xsdFile is not specified assume it is next to has the same 
        ' directry and name as configFile, but the extension is .xsd instead
        If xsdFile Is Nothing Then
            Dim xsdPath As String = System.IO.Path.Combine(configFile.DirectoryName, System.IO.Path.GetFileNameWithoutExtension(configFile.Name) & ".xsd")
            xsdFile = New FileInfo(xsdPath)
        End If

        ' Must refresh FileInfo objects so .Exists() wil return up to date results
        xsdFile.Refresh()
        If Not xsdFile.Exists() Then
            Throw ExceptionProvider.PathArgNotFoundException("xsdFile", configFile.FullName)
        End If

        Dim readerSettings As XmlReaderSettings = New XmlReaderSettings()
        readerSettings.Schemas.Add(targetNamespace, xsdFile.FullName)
        readerSettings.ValidationType = ValidationType.Schema
        Validate(configFile, readerSettings)

    End Sub

    Public Sub Validate(ByVal configFile As FileInfo, ByVal targetSchema As XmlSchema)

        ' delegate work to an overloaded version; 
        ' That version should check configFile (and readerSettings)
        ' We schould check xsdFile and targetNamespace, from which we build readerSettings

        ' if xsdFile is not specified assume it is next to has the same 
        ' directry and name as configFile, but the extension is .xsd instead
        If targetSchema Is Nothing Then
            Throw ExceptionProvider.NullArgException("targetSchema")
        End If

        Dim readerSettings As XmlReaderSettings = New XmlReaderSettings()
        readerSettings.Schemas.Add(targetSchema)
        readerSettings.ValidationType = ValidationType.Schema
        Validate(configFile, readerSettings)

    End Sub

    Public Sub Validate(ByVal configFile As FileInfo, ByVal schemaSet As XmlSchemaSet)

        ' delegate work to an overloaded version; 
        ' That version should check configFile (and readerSettings)
        ' We schould check schemaSet, from which we build readerSettings
        If schemaSet Is Nothing Then
            Throw ExceptionProvider.NullArgException("schemaSet")
        End If

        Dim readerSettings As XmlReaderSettings = New XmlReaderSettings()
        readerSettings.Schemas.Add(schemaSet)
        readerSettings.ValidationType = ValidationType.Schema
        Validate(configFile, readerSettings)

    End Sub


    Public Sub Validate(ByVal configFile As FileInfo, ByVal readerSettings As XmlReaderSettings)

        If configFile Is Nothing Then
            Throw ExceptionProvider.NullOrEmptyArgException("configFile")
        End If

        ' Must refresh FileInfo objects so .Exists() wil return up to date results
        configFile.Refresh()
        If Not configFile.Exists() Then
            Throw ExceptionProvider.PathArgNotFoundException("configFile", configFile.FullName)
        End If

        If readerSettings Is Nothing Then
            Throw ExceptionProvider.NullArgException("readerSettings")
        End If

        Dim xdoc = System.Xml.Linq.XDocument.Load(configFile.FullName)
        Dim eventHandler As ValidationEventHandler = New ValidationEventHandler(AddressOf ValidationEventHandler)

        xdoc.Validate(readerSettings.Schemas, eventHandler)

    End Sub

End Class
