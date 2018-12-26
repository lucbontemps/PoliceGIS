Option Strict On

' System namespaces
Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports System.Text
Imports System.Xml.Xsl


Public Class XsdSchemaValidationRule
    Inherits AbstractValidationRule

#Region " private fields "

    Private m_configFile As FileInfo
    Private m_xsdFile As FileInfo
    Private m_targetNamespace As String

#End Region

    ''' <summary>
    ''' Default constructor
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New(ByVal name As String, ByVal configFile As FileInfo, ByVal xsdFile As FileInfo, ByVal targetNamespace As String)
        MyBase.New(name)

        If configFile Is Nothing Then
            Throw ExceptionProvider.NullOrEmptyArgException("configFile")
        End If

        ' Safer way to check if file exists then FileInfo.Exists()
        If Not File.Exists(configFile.FullName) Then
            Throw ExceptionProvider.PathArgNotFoundException("configFile", configFile.FullName)
        End If

        ' if xsdFile is not specified assume it is next to has the same 
        ' directry and name as configFile, but the extension is .xsd instead
        If xsdFile Is Nothing Then
            Dim xsdPath As String = System.IO.Path.Combine(configFile.DirectoryName, System.IO.Path.GetFileNameWithoutExtension(configFile.Name) & ".xsd")
            xsdFile = New FileInfo(xsdPath)
        End If

        ' Safer way to check if file exists then FileInfo.Exists()
        If Not File.Exists(xsdFile.FullName) Then
            Throw ExceptionProvider.PathArgNotFoundException("xsdFile", xsdFile.FullName)
        End If

        If String.IsNullOrEmpty(targetNamespace) Then
            Throw ExceptionProvider.NullOrEmptyArgException("targetNamespace")
        End If


        m_configFile = configFile
        m_xsdFile = xsdFile
        m_targetNamespace = targetNamespace

    End Sub


    Public Overrides Sub Validate()

        Dim rdSettings As XmlReaderSettings = New XmlReaderSettings()
        rdSettings.Schemas.Add(m_targetNamespace, m_xsdFile.FullName)
        rdSettings.ValidationType = ValidationType.Schema

        Using reader As XmlReader = XmlReader.Create(m_configFile.FullName, rdSettings)

            'Dim configDocument As XmlDocument = New XmlDocument()
            'configDocument.Load(reader)

            ' Do validation, if validation is ok then _lastConfigValid will be true.
            ' First reset _lastConfigValid, it is set false when validation events 
            ' are raised and the event's severity is either error or warning.
            Report.Clear()

            Dim xsdVldtr As New XsdSchemaValidator()
            xsdVldtr.Validate(m_configFile, m_xsdFile, m_targetNamespace)
            If xsdVldtr.HasErrorsOrWarning() Then

                For Each e In xsdVldtr.Errors
                    AddError(e)
                Next

                For Each w In xsdVldtr.Warnings
                    AddError(w)
                Next

            End If


        End Using

        IsValidated = True

    End Sub

End Class




