<Serializable()> Public Class ColumnTypeDescriptor

    Private m_columnName As String
    Private m_columnType As MIColumnType
    Private m_width As Short
    Private m_decimalPlaces As Short


    Public Property ColumnName() As String
        Get
            Return m_columnName
        End Get
        Set(ByVal value As String)
            m_columnName = value
        End Set
    End Property

    Public Property ColumnType() As MIColumnType
        Get
            Return m_columnType
        End Get
        Set(ByVal value As MIColumnType)
            m_columnType = value
        End Set
    End Property

    Public Property Width() As Short
        Get
            Return m_width
        End Get
        Set(ByVal value As Short)

            If value <= 0 Then
                Throw ExceptionProvider.ArgumentOutOfRange("Width", value, "Width must be 1 or greater")
            End If

            If value > 254 Then
                Throw ExceptionProvider.ArgumentOutOfRange("Width", value, "Width must be smaller then 254")
            End If

            m_width = value
        End Set
    End Property

    Public Property DecimalPlaces() As Short
        Get
            Return m_decimalPlaces
        End Get
        Set(ByVal value As Short)

            If value <= 0 Then
                Throw ExceptionProvider.ArgumentOutOfRange("DecimalPlaces", value, "DecimalPlaces must be 1 or greater")
            End If

            If value > 254 Then
                Throw ExceptionProvider.ArgumentOutOfRange("DecimalPlaces", value, "DecimalPlaces must be smaller then 254")
            End If

            m_decimalPlaces = value

        End Set
    End Property

    Public Overloads Function ToString() As String
        Return m_columnName & " " & TypeString()
    End Function

    Public Function HasWidth() As Boolean
        Return HasWidth(m_columnType)
    End Function

    Public Shared Function HasWidth(ByVal tp As MIColumnType) As Boolean
        Return (tp = MIColumnType.CharType) OrElse (tp = MIColumnType.DecimalType)
    End Function

    Public Function HasDecimalPlaces() As Boolean
        Return HasDecimalPlaces(m_columnType)
    End Function

    Public Shared Function HasDecimalPlaces(ByVal tp As MIColumnType) As Boolean
        Return (tp = MIColumnType.DecimalType)
    End Function

    Public Function TypeString() As String

        Dim numFormat As New System.Globalization.NumberFormatInfo()
        numFormat.NumberDecimalSeparator = "."
        numFormat.NumberGroupSeparator = ""

        Dim result As String = ""
        Select Case m_columnType

            Case MIColumnType.CharType
                result = String.Format(numFormat, "Char({0})", m_width)

            Case MIColumnType.DecimalType
                result = String.Format(numFormat, "Decimal({0}, {1})", m_width, m_decimalPlaces)

            Case MIColumnType.IntegerType
                result = "Integer"

            Case MIColumnType.SmallintType
                result = "SmallInt"

            Case MIColumnType.LogicalType
                result = "Logical"

            Case MIColumnType.GraphicType
                result = "Graphic"

            Case MIColumnType.FloatType
                result = "Float"

            Case MIColumnType.DateType
                result = "Date"

            Case MIColumnType.TimeType
                result = "Time"

            Case MIColumnType.DatetimeType
                result = "Datetime"

            Case Else

                Dim errMsg = String.Format("Onbekende waarde voor columnType: {0}. {1}", [Enum].GetName(m_columnType.GetType, m_columnType), m_columnType)
                Throw New PoliceGisException(errMsg)

        End Select

        Return result

    End Function

End Class