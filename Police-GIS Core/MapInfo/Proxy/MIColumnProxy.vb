
Option Strict On

Imports System.Globalization


Public Class MIColumnProxy


    Private Shared sh_columnIDNumberFormat As NumberFormatInfo


#Region "Public  Methods"


    Public Shared Function ColumnNeedsQuotes(ByVal table As String, ByVal column As String) As Boolean

        If String.IsNullOrEmpty(table) Then
            Throw New InvalidOperationException("TableName not set")
        End If

        If String.IsNullOrEmpty(column) Then
            Throw New InvalidOperationException("ColumnName not set")
        End If

        ' most columns don't need quotes
        Dim needsQutes As Boolean = False
        Dim colType As MIColumnType = MIColumnProxy.GetColumnType(table, column)
        If colType = MapBasicConstants.COL_TYPE_CHAR _
            OrElse colType = MapBasicConstants.COL_TYPE_DATE _
            OrElse colType = MapBasicConstants.COL_TYPE_TIME Then
            needsQutes = True
        End If

        Return needsQutes

    End Function


    Public Shared Function GetColumnProperties( _
        ByVal tableName As String, _
        ByVal propertyCode As Short _
    ) As List(Of String)

        Dim colIndex As Short
        Dim columnProperties As New List(Of String)

        For colIndex = 1 To MITableProxy.GetColumnCountIncludingOBJ(tableName)
            Dim propValue = GetColumnInfo(tableName, colIndex, propertyCode)
            columnProperties.Add(propValue)
        Next

        Return columnProperties

    End Function


    Public Shared Function GetUniqueValues(ByVal table As String, ByVal column As String) As List(Of String)

        If String.IsNullOrEmpty(table) Then
            Throw ExceptionProvider.NullOrEmptyArgException("table")
        End If

        If String.IsNullOrEmpty(column) Then
            Throw ExceptionProvider.NullOrEmptyArgException("column")
        End If

        Dim query = "Select " & column & " From  " & table & "  Group By " & column & " Order By " & column & " Into Selection "
        MapBasicInterop.ExecuteCommand(query)

        Dim numVals As Integer = MISelectionProxy.NumberOfRows
        Dim values As New List(Of String)

        For r As Integer = 1 To numVals

            Dim command = String.Format(MapBasicInterop.GetMapInfoNumFormat, "Fetch rec {0} from Selection ", r)
            MapBasicInterop.ExecuteCommand(command)

            values.Add(MapBasicInterop.Evaluate("Selection.COL1"))

        Next


        ' close the query table
        Dim lastQueryTable = MITableProxy.GetTableName(0)
        MapBasicInterop.ExecuteCommand("Close Table " & lastQueryTable)

        Return values

    End Function


    Public Shared Function GetColumnTypeDescriptor(ByVal table As String, _
                                                   ByVal column As String _
                                                   ) As ColumnTypeDescriptor

        Dim colInfo As New ColumnTypeDescriptor
        colInfo.ColumnName = column
        colInfo.ColumnType = GetColumnType(table, column)
        colInfo.Width = GetColumnWidth(table, column)

        If GetDecimalPlaces(table, column) > 0 Then

            colInfo.DecimalPlaces = GetDecimalPlaces(table, column)

        End If

        Return colInfo

    End Function

    Public Shared Function NumberOfUniqueValues(ByVal table As String, ByVal column As String) As Integer

        If String.IsNullOrEmpty(table) Then
            Throw ExceptionProvider.NullOrEmptyArgException("table")
        End If

        If String.IsNullOrEmpty(column) Then
            Throw ExceptionProvider.NullOrEmptyArgException("column")
        End If

        Dim query = "SELECT " & column & " FROM " & table & " GROUP BY " & column & " ORDER BY " & column & " INTO SELECTION "
        MapBasicInterop.ExecuteCommand(query)

        Return MISelectionProxy.NumberOfRows

    End Function


    Public Shared Function NumberOfUniqueValues(ByVal table As String, ByVal columnIndex As Short) As Integer
        Dim numFrmt As New NumberFormatInfo
        numFrmt.NumberGroupSeparator = ""
        numFrmt.NumberDecimalSeparator = "."
        Dim columnID = "COL" & columnIndex.ToString(numFrmt)
        Return NumberOfUniqueValues(table, columnID)

    End Function


    Public Shared Function GetColumnID( _
        ByVal table As String, _
        ByVal column As String _
    ) As Short

        If String.IsNullOrEmpty(table) Then
            ExceptionProvider.NullOrEmptyArgException("tableName")
        End If

        If String.IsNullOrEmpty(column) Then
            ExceptionProvider.NullOrEmptyArgException("column")
        End If

        Dim colID As Short = 0 'error code if no column was found
        Dim numCols As Short = MITableProxy.GetColumnCountIncludingOBJ(table)

        For cl As Short = 1 To numCols

            Dim currentColName As String = GetColumnName(table, cl)

            If currentColName Is Nothing Then
                Throw New PoliceGisException("internal error: GetColumnName return null reference")
            End If

            If (currentColName.ToLower = column.ToLower) Then
                colID = cl
                Exit For
            End If

        Next

        Return colID

    End Function


    Public Shared Function GetColumnInfo(ByVal tableName As String, ByVal columnIndex As Short, ByVal attribute As Short) As String

        If String.IsNullOrEmpty(tableName) Then
            Throw ExceptionProvider.NullOrEmptyArgException("tableName")
        End If

        If columnIndex < 1 Then
            Throw ExceptionProvider.ArgumentOutOfRange("columnIndex", columnIndex, "Argument 'columnIndex' must be 1 or greater.")
        End If

        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "ColumnInfo( {0}, COL{1} , {2} )", tableName, columnIndex, attribute)
        Return MapBasicInterop.Evaluate(expression)

    End Function


    Public Shared Function GetColumnInfo(ByVal tableName As String, ByVal columnName As String, ByVal attribute As Short) As String

        Dim colIndex = MIColumnProxy.GetColumnID(tableName, columnName)
        Dim expression = GetColumnInfo(tableName, colIndex, attribute)
        Return MapBasicInterop.Evaluate(expression)

    End Function


    Public Shared Function GetColumnType(ByVal tableName As String, ByVal columnName As String) As MIColumnType

        ' get the code
        Dim columnTypeCode As Short = Short.Parse(GetColumnInfo(tableName, columnName, MapBasicConstants.COL_INFO_TYPE))

        ' MIColumnType has to maintain the same values and order as the constants in MapBasic
        Return DirectCast(columnTypeCode, MIColumnType)

    End Function


    Public Shared Function GetColumnType(ByVal tableName As String, ByVal columnIndex As Short) As MIColumnType

        ' get the code
        Dim columnTypeCode As Short = Short.Parse(GetColumnInfo(tableName, columnIndex, MapBasicConstants.COL_INFO_TYPE))
        Return DirectCast(columnTypeCode, MIColumnType)

    End Function


    Public Shared Function GetColumnWidth(ByVal tableName As String, ByVal columnName As String) As Short

        Dim value = GetColumnInfo(tableName, columnName, MapBasicConstants.COL_INFO_WIDTH)
        Return Short.Parse(value)

    End Function

    Public Shared Function GetColumnWidth(ByVal tableName As String, ByVal columnIndex As Short) As Short

        Dim value = GetColumnInfo(tableName, columnIndex, MapBasicConstants.COL_INFO_WIDTH)
        Return Short.Parse(value)

    End Function

    Public Shared Function GetDecimalPlaces(ByVal tableName As String, ByVal columnName As String) As Short

        Dim value = GetColumnInfo(tableName, columnName, MapBasicConstants.COL_INFO_DECPLACES)

        Return Short.Parse(value)

    End Function

    Public Shared Function GetDecimalPlaces(ByVal tableName As String, ByVal columnIndex As Short) As Short

        Dim value = GetColumnInfo(tableName, columnIndex, MapBasicConstants.COL_INFO_DECPLACES)
        Return Short.Parse(value)

    End Function

    Public Shared Function GetColumnName(ByVal tableName As String, ByVal columnIndex As Short) As String
        Return GetColumnInfo(tableName, columnIndex, MapBasicConstants.COL_INFO_NAME)
    End Function


    Public Shared Function ToDataColumn(ByVal tableName As String, ByVal columnName As String) As System.Data.DataColumn

        Dim result As New DataColumn(columnName)
        Dim columnIndex = GetColumnID(tableName, columnName)
        Dim ColumnType = GetColumnType(tableName, columnName)
        Select Case ColumnType

            Case MIColumnType.CharType
                result.DataType = GetType(System.String)
                result.MaxLength = Short.Parse(GetColumnInfo(tableName, columnIndex, MapBasicConstants.COL_INFO_WIDTH))

            Case MIColumnType.DecimalType

                result.DataType = GetType(System.Decimal)

            Case MIColumnType.FloatType
                result.DataType = GetType(System.Double)

            Case MIColumnType.IntegerType
                result.DataType = GetType(System.Int32)

            Case MIColumnType.SmallintType
                result.DataType = GetType(System.Int16)

            Case MIColumnType.LogicalType
                result.DataType = GetType(System.Boolean)

            Case MIColumnType.DatetimeType, MIColumnType.DateType, MIColumnType.TimeType
                result.DataType = GetType(System.DateTime)

            Case MIColumnType.GraphicType
                'result.DataType = GetType(Byte())
                result = Nothing

            Case Else
                Dim msg = String.Format("Unsupported mapinfo column type: {0}.", ColumnType)
                Throw New PoliceGisException(msg)

        End Select
        Return result

    End Function


    ''' <summary>
    ''' A short alias for the column in the COLn format.
    ''' Watch out, there are lots of situations where you have to use the longer
    ''' format: tablename.COLn,  which FormatLongColumnID can make for you.
    ''' For example, to extract values from table cell you have to use an the long format.
    ''' </summary>
    ''' <param name="columnIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FormatColumnID(ByVal columnIndex As Integer) As String
        Return String.Format(GetColumnIDNumberFormat(), "COL{0}", columnIndex)
    End Function


    Public Shared Function FormatLongColumnID(ByVal tableName As String, ByVal columnIndex As Integer) As String
        If String.IsNullOrEmpty(tableName) Then
            Throw ExceptionProvider.NullArgException("tableName")
        End If
        Return String.Format(GetColumnIDNumberFormat(), "{0}.COL{1}", tableName, columnIndex)
    End Function

    Public Shared Function FormatLongColumnID(ByVal table As String, ByVal columnName As String) As String
        Dim columnIndex As Short = GetColumnID(table, columnName)
        Return FormatLongColumnID(table, columnIndex)
    End Function

    Public Shared Function GetColumnIDNumberFormat() As NumberFormatInfo

        If sh_columnIDNumberFormat Is Nothing Then
            Dim numFrmt As New NumberFormatInfo
            numFrmt.NumberGroupSeparator = ""
            numFrmt.NumberDecimalSeparator = "."
            sh_columnIDNumberFormat = NumberFormatInfo.ReadOnly(numFrmt)
        End If

        Return sh_columnIDNumberFormat

    End Function


    Public Shared Function GetUniqueValuesInColumn(ByVal table As String, ByVal column As String) As List(Of String)

        If String.IsNullOrEmpty(table) Then
            Throw ExceptionProvider.NullOrEmptyArgException("table")
        End If

        If String.IsNullOrEmpty(column) Then
            Throw ExceptionProvider.NullOrEmptyArgException("column")
        End If

        Dim query = "Select " & column & " From  " & table & "  Group By " & column & " Order By " & column & " Into Selection "
        MapBasicInterop.ExecuteCommand(query)

        Dim numVals As Integer = MISelectionProxy.NumberOfRows
        Dim values As New List(Of String)

        For r As Integer = 1 To numVals

            Dim command = String.Format(MapBasicInterop.GetMapInfoNumFormat, "Fetch rec {0} from Selection ", r)
            MapBasicInterop.ExecuteCommand(command)
            Dim value = MapBasicInterop.Evaluate("Selection.COL1")
            If Not String.IsNullOrEmpty(value.Trim) Then
                values.Add(value)
            End If
        Next


        ' close the query table
        Dim lastQueryTable = MITableProxy.GetTableName(0)
        MapBasicInterop.ExecuteCommand("Close Table " & lastQueryTable)

        Return values

    End Function


#End Region

End Class


