Option Strict On

Imports System.IO
Imports System.Text

Public Class MITableProxy

    Public Shared Sub SaveTableTo(ByVal TableName As String, ByVal tabFile As FileInfo, ByVal interactive As Boolean)

        If tabFile Is Nothing Then
            Throw ExceptionProvider.NullArgException("tabFile")
        End If

        If String.IsNullOrEmpty(TableName) Then
            Throw New InvalidOperationException("Can not save table when property TableName is not set")
        End If

        SaveTableAs(TableName, tabFile.FullName, interactive)

    End Sub

    Public Shared Sub SaveTableAs(ByVal TableName As String, ByVal path As String, ByVal interactive As Boolean)

        If String.IsNullOrEmpty(path) Then
            Throw ExceptionProvider.NullArgException("tableName")
        End If

        If String.IsNullOrEmpty(path) Then
            Throw ExceptionProvider.NullArgException("tablePath")
        End If
        Dim expr As New StringBuilder
        expr.Append(String.Format("Commit table {0} as ""{1}"" ", TableName, path))
        If interactive Then
            expr.Append(" interactive")
        End If
        MapBasicInterop.ExecuteCommand(expr.ToString)
    End Sub

    Public Shared Sub SaveTable(ByVal mtableName As String)

        If String.IsNullOrEmpty(mtableName) Then
            Throw New InvalidOperationException("Can not save table when property TableName is not set")
        End If

        MapBasicInterop.ExecuteCommand(String.Format("Commit table {0}", mtableName))

    End Sub

    Public Shared Function EndOfTable(ByVal tableName As String) As Boolean

        VerifyTableOpen(tableName)

        Dim expr = "EOT( " & tableName & " )"
        Dim value = MapBasicInterop.Evaluate(expr)
        Return MapBasicInterop.ConvertMapInfoLogical(value)

    End Function

    ''' <summary>
    ''' True if the a table with the specified name is currently opn in MapInfo.
    ''' </summary>
    ''' <param name="table"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsTableOpen(ByVal table As String) As Boolean

        Dim tables As List(Of String) = ListTableNames()
        Dim found As Boolean = False

        For Each t In tables
            If t.ToLower = table.ToLower Then
                found = True
                Exit For
            End If
        Next

        Return found

    End Function

    Public Shared Function IsTabFileOpen(ByVal tabFile As String) As Boolean

        For Each tbl In MITableProxy.ListTableNames()

            Dim currentTabFile As String = MITableProxy.GetTableInfo(tbl, DirectCast(MITableInfo.TABFILE, Short))
            If currentTabFile.ToUpper = tabFile.ToUpper Then
                Return True
            End If

        Next

        Return False

    End Function

    Public Shared Function IsTabFileOpen(ByVal tabFile As FileInfo) As Boolean

        If Not tabFile.Exists Then
            Return False
        Else
            Dim tableID = GetTableIDByFile(tabFile.FullName)
            Return (tableID <> -1)
        End If

    End Function

    Public Shared Function IsMappable(ByVal table As String) As Boolean
        Dim value = GetTableInfo(table, MapBasicConstants.TAB_INFO_MAPPABLE)
        Return MapBasicInterop.ConvertMapInfoLogical(value)
    End Function

    ''' <summary>
    ''' Returns the index of the table if it is open, or -1 if no table with 
    ''' the specified name is currently open. Names are not case sensitive.
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTableIDByName(ByVal tableName As String) As Short

        VerifyTableOpen(tableName)
        Return GetTableIDInternal(tableName, False)

    End Function

    ''' <summary>
    ''' Returns the index of the table if it is open, or -1 if no table with 
    ''' the specified TAB file path is currently open. Names are not case sensitive.
    ''' </summary>
    ''' <param name="tabFilePath"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTableIDByFile(ByVal tabFilePath As String) As Short

        Return GetTableIDInternal(tabFilePath, True)

    End Function

    Public Shared Function GetTableIDByFile(ByVal tabFileInfo As FileInfo) As Short

        Return GetTableIDInternal(tabFileInfo.FullName, True)

    End Function

    Public Shared Function ListColumnNames(ByVal tableName As String) As List(Of String)

        Return MIColumnProxy.GetColumnProperties(tableName, MapBasicConstants.COL_INFO_NAME)

    End Function

    Public Shared Function GetTableInfo(ByVal table As String, ByVal attributeCode As Short) As String

        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "TableInfo( {0} , {1} )", table, attributeCode)
        Return MapBasicInterop.Evaluate(expression)

    End Function


    Public Shared Function GetTableInfo(ByVal index As Short, ByVal attributeCode As Short) As String

        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "TableInfo( {0} , {1} )", index, attributeCode)
        Return MapBasicInterop.Evaluate(expression)

    End Function

    Public Shared Function GetTableName(ByVal index As Short) As String

        Return GetTableInfo(index, MapBasicConstants.TAB_INFO_NAME)
    End Function

    Public Shared Sub IfTableOpenCloseTable(ByVal tableName As String)
        If IsTableOpen(tableName) Then
            CloseTable(tableName, False)
        End If
    End Sub

    Public Shared Function TabFileToTableName(ByVal tabFile As String) As String

        Dim tableId As Short = GetTableIDByFile(tabFile)
        If tableId < 1 Then
            ' not found
            Return Nothing
        Else
            Return GetTableName(tableId)
        End If

    End Function

    Public Shared Function ListTableNames(ByVal allowedTableTypes() As Short) As List(Of String)

        ' First make array empty.
        Dim tableList As New List(Of String)
        Dim numTbls As Short = GetNumTables()

        ' Loop through (regular) open tables.
        For tableIndex As Short = 1 To numTbls

            Dim tblType As Short = Short.Parse(GetTableInfo(tableIndex, MapBasicConstants.TAB_INFO_TYPE))

            ' Loop through all types we want to see in the list
            ' and check if the table's type is allowed.
            For typeIndex As Integer = 0 To allowedTableTypes.GetUpperBound(0)

                If allowedTableTypes(typeIndex) = tblType Then
                    ' Type is in the allowed list, add its name to the output.
                    tableList.Add(GetTableInfo(tableIndex, MapBasicConstants.TAB_INFO_NAME))

                    ' Type was found, There's no use continuing inner loop
                    Exit For

                End If

            Next

        Next

        Return tableList

    End Function

    Public Shared Function ListTableNames() As List(Of String)

        ' First make array empty.
        Dim tableList As New List(Of String)
        Dim numTbls As Short = GetNumTables()

        ' Loop through (regular) open tables.
        For tableIndex As Short = 1 To numTbls

            tableList.Add(MITableProxy.GetTableName(tableIndex))

        Next

        Return tableList

    End Function

    Public Shared Function GetNumTables() As Short

        Return Short.Parse(MapBasicInterop.Evaluate("NumTables()"))

    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' The NumCols( ) function returns the number of columns contained in the 
    ''' specified open table. The number of columns returned by NumCols( ) does 
    ''' not include the special column known as Object (or Obj for short), which 
    ''' refers to the graphical objects attached to mappable tables. Similarly,
    ''' the number of columns returned does not include the special column known 
    ''' as RowID.
    ''' Note If a table has temporary columns (for example, because of an Add 
    ''' Column statement), the number returned by NumCols( ) includes the 
    ''' temporary column(s).
    ''' </remarks>
    Public Shared Function GetAttributeCount(ByVal tableName As String) As Short

        Dim expression = ("NumCols(" & tableName & ")")
        Return Short.Parse(MapBasicInterop.Evaluate(expression))

    End Function

    ''' <summary>
    ''' The number of columns including the OBJ (geometry) column
    ''' </summary>
    ''' <param name="table"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetColumnCountIncludingOBJ(ByVal table As String) As Short
        Return Short.Parse(GetTableInfo(table, MapBasicConstants.TAB_INFO_NCOLS))
    End Function


    Public Shared Function GetRowCount(ByVal table As String) As Integer
        Return Integer.Parse(GetTableInfo(table, MapBasicConstants.TAB_INFO_NROWS))
    End Function

    Public Shared Function OpenTable(ByVal tabFile As FileInfo, ByVal interactive As Boolean) As String

        If tabFile Is Nothing Then
            Throw ExceptionProvider.NullArgException("tabFile")
        Else

            ' overload of OpenTable check the existence of the TAB file
            Return OpenTable(tabFile.FullName, interactive)

        End If

    End Function

    Public Shared Function OpenTable(ByVal tabFilePath As String, ByVal interactive As Boolean) As String

        If String.IsNullOrEmpty(tabFilePath) Then
            Throw ExceptionProvider.NullOrEmptyArgException("tabFilePath")

        ElseIf Not File.Exists(tabFilePath) Then
            Throw ExceptionProvider.PathArgNotFoundException("tabFilePath", tabFilePath)

        Else

            Dim cmd = "Open table """ & tabFilePath & """"
            If interactive Then
                cmd &= " interactive"
            End If

            MapBasicInterop.ExecuteCommand(cmd)
            Return MITableProxy.GetTableName(0)

        End If

    End Function

    Public Shared Function OpenTableAs(ByVal tabFilePath As String, _
                                       ByVal interactive As Boolean, _
                                       ByVal aliasName As String) As String

        Dim commandBuilder As New StringBuilder

        If String.IsNullOrEmpty(tabFilePath) Then
            Throw ExceptionProvider.NullOrEmptyArgException("tabFilePath")

        ElseIf Not File.Exists(tabFilePath) Then
            Throw ExceptionProvider.PathArgNotFoundException("tabFilePath", tabFilePath)

        Else

            commandBuilder.Append(String.Format("Open table ""{0}"" as ""{1}""", tabFilePath, aliasName))
            If interactive Then
                commandBuilder.Append(" interactive")
            End If

            MapBasicInterop.ExecuteCommand(commandBuilder.ToString)
            Return MITableProxy.GetTableName(0)

        End If

    End Function

    '''-------------------------------------------------------------------------------------------------
    ''' OpenTableChecked only opens the table if it is not open yet. 
    ''' It will also make sure the table is opened with the specified name.
    ''' A single TAB file may not be open under two different names.
    '''-------------------------------------------------------------------------------------------------
    ''' 
    Public Shared Sub OpenTableChecked(ByVal tableName As String, _
                                       ByVal tabFile As String)

        If String.IsNullOrEmpty(tableName) Then
            Throw ExceptionProvider.NullOrEmptyArgException("tableName")
        End If

        If String.IsNullOrEmpty(tabFile) Then
            Throw ExceptionProvider.NullOrEmptyArgException("tabFile")
        End If

        If Not New FileInfo(tabFile).Exists Then
            Throw ExceptionProvider.PathArgNotFoundException("tabFile", tabFile)
        End If

        If MITableProxy.IsTableOpen(tableName) Then

            Dim actualTabFile As String = GetTableInfo(tableName, MapBasicConstants.TAB_INFO_TABFILE)
            actualTabFile = actualTabFile.Trim.ToLower

            If actualTabFile <> tabFile.Trim.ToLower Then

                Dim msg = String.Format("Table name {0} is already used by a different TAB file: {1}. Can not open file {2} as the same table name.", tableName, actualTabFile, tabFile)

                Throw New PoliceGisException(msg)

            End If

        Else

            MITableProxy.OpenTableAs(tabFile, False, tableName)

        End If

    End Sub

    Public Shared Sub CloseTable(ByVal table As String, ByVal interactive As Boolean)

        If String.IsNullOrEmpty(table) Then
            Throw New InvalidOperationException("TableName must be set before you call CloseTable(Boolean interactive)")
        Else

            Dim cmd = "Close table """ & table & """"
            If interactive Then
                cmd &= " interactive"
            End If

            MapBasicInterop.ExecuteCommand(cmd)

        End If

    End Sub

    Public Shared Sub PackTable(ByVal table As String)

        If String.IsNullOrEmpty(table) Then
            Throw ExceptionProvider.NullOrEmptyArgException("table")

        Else
            Dim cmd As String
            If MITableProxy.IsMappable(table) Then
                cmd = "Pack table " & table & " Graphic Data"
            Else
                cmd = "Pack table " & table & " Data"
            End If
            MapBasicInterop.ExecuteCommand(cmd)

        End If

    End Sub

    ''' <summary>
    ''' Create an empty DataTable with a similar structure as the MapInfo Table
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ToDataTable(ByVal tableName As String) As System.Data.DataTable

        Dim resultTable As New DataTable(tableName)

        For Each cl In ListColumnNames(tableName)

            Dim dCol As DataColumn = MIColumnProxy.ToDataColumn(tableName, cl)

            ' skip unsupported column types.
            If dCol IsNot Nothing Then
                resultTable.Columns.Add(dCol)
            End If

        Next

        Return resultTable

    End Function

    ''' <summary>
    ''' Fills a System.Data.DataTable with the records from a MapInfo table
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function FillDataTable(ByVal tableName As String) As System.Data.DataTable

        Dim resultTable = ToDataTable(tableName)
        Dim numFrmt = MapBasicInterop.GetMapInfoNumFormat
        FetchFirstRecord(tableName)

        For rw As Integer = 0 To GetRowCount(tableName) - 1

            Dim newRow = resultTable.NewRow
            newRow.BeginEdit()

            ' copy the values
            For cl As Integer = 0 To GetColumnCountIncludingOBJ(tableName) - 1

                Dim expr = String.Format(numFrmt, "{0}.COL{1}", tableName, (cl + 1))
                Dim fieldValue = MapBasicInterop.Evaluate(expr)

                Select Case MIColumnProxy.GetColumnType(tableName, CShort(cl + 1))

                    Case MIColumnType.DatetimeType, MIColumnType.DateType

                        newRow(cl) = New Date(CInt(fieldValue.Substring(0, 4)), CInt(fieldValue.Substring(4, 2)), CInt(fieldValue.Substring(6, 2)))

                    Case MIColumnType.TimeType

                        newRow(cl) = New Date(Now.Year, Now.Month, Now.Day, CInt(fieldValue.Substring(0, 2)), CInt(fieldValue.Substring(2, 2)), 0)

                    Case MIColumnType.LogicalType
                        If fieldValue = "T" Then
                            newRow(cl) = True
                        Else
                            newRow(cl) = False
                        End If

                    Case Else

                        newRow(cl) = fieldValue

                End Select

            Next

            newRow.EndEdit()

            resultTable.Rows.Add(newRow)

            FetchNextRecord(tableName)

        Next

        Return resultTable

    End Function

    Public Shared Sub KillTable(ByVal tableFile As FileInfo)

        If tableFile Is Nothing Then
            Throw ExceptionProvider.NullArgException("tableFile")
        End If

        KillTable(tableFile.FullName)

    End Sub

    Public Shared Sub KillTable(ByVal tablePath As String)

        If String.IsNullOrEmpty(tablePath) Then
            Throw ExceptionProvider.NullOrEmptyArgException("tablePath")
        End If

        If Not File.Exists(tablePath) Then
            Throw ExceptionProvider.PathArgNotFoundException("tablePath", tablePath)
        End If

        MapBasicInterop.ExecuteCommand("Kill """ & tablePath & """")

    End Sub

    Public Shared Sub AddColumn(ByVal tableName As String, ByVal columnName As String, ByVal type As String, ByVal interactive As Boolean)

        Dim command As New StringBuilder

        command.Append("Alter Table ")
        command.Append(tableName)
        command.Append("(")
        command.Append("Add ")
        command.Append(columnName)
        command.Append(" ")
        command.Append(type)
        command.Append(")")

        If interactive Then
            command.Append(" Interactive")
        End If

        MapBasicInterop.ExecuteCommand(command.ToString)

    End Sub

    Public Shared Sub MakeMappable(ByVal table As String, ByVal coordinateSystemSpec As String)

        MapBasicInterop.ExecuteCommand(String.Format("Create Map For {0} CoordSys {1}", _
                                                        table, _
                                                        coordinateSystemSpec))

    End Sub

    Public Shared Function IsValidTableName(ByVal tableName As String) As Boolean

        Dim result As Boolean = True

        If String.IsNullOrEmpty(tableName) Then
            result = False

        ElseIf tableName.Length > 30 Then
            result = False

        ElseIf Not Char.IsLetter(tableName(0)) Then
            result = False
        Else

            For Each c As Char In tableName
                If Not (Char.IsLetterOrDigit(c) Or c = "_"c) Then
                    result = False
                    Exit For
                End If
            Next

        End If

        Return result

    End Function

    Public Shared Sub UpdateRecord(ByVal tableName As String, ByVal field As String, _
                            ByVal value As Object, _
                            ByVal rowId As Integer)

        Dim fieldList As New List(Of String)
        fieldList.Add(field)

        Dim valueList As New List(Of Object)
        valueList.Add(value)

        UpdateRecord(tableName, fieldList, valueList, rowId)

    End Sub

    Public Shared Sub UpdateRecord(ByVal tableName As String, ByVal fields As List(Of String), _
                            ByVal values As List(Of Object), _
                            ByVal rowId As Integer)

        If fields Is Nothing Then
            Throw ExceptionProvider.NullArgException("fields")

        ElseIf fields.Count = 0 Then
            Throw ExceptionProvider.ArgumentOutOfRange("fields", fields, "Argument 'fields' must contain at least 1 element.")

        End If

        If values Is Nothing Then
            Throw ExceptionProvider.NullArgException("values")

        ElseIf values.Count <> fields.Count Then
            Throw ExceptionProvider.ArgumentOutOfRange("values", values, "Argument 'values' must contain the same number of element as 'fields', one value for each field.")

        End If

        Dim cmdBuilder As New StringBuilder()
        cmdBuilder.Append("Update ")
        cmdBuilder.Append(TableName)
        cmdBuilder.Append(" set ")

        Dim numFormat As New System.Globalization.NumberFormatInfo
        numFormat.NumberDecimalSeparator = "."
        numFormat.NumberGroupSeparator = ""

        For i As Integer = 0 To fields.Count - 1

            cmdBuilder.Append(fields(i))
            cmdBuilder.Append(" = ")

            Dim needQuotes = MIColumnProxy.ColumnNeedsQuotes(TableName, fields(i))
            Dim valueText As String = ""

            If values(i).GetType.IsPrimitive Then

                If TypeOf values(i) Is Boolean Then

                    If DirectCast(values(i), Boolean) Then
                        valueText = "1"
                    Else
                        valueText = "0"
                    End If

                Else
                    valueText = Convert.ToString(values(i), numFormat)
                End If

            Else
                'should not happen normally the types should be primitive
                valueText = Convert.ToString(values(i), numFormat)
            End If

            If needQuotes Then

                Dim escaped = """" & MapBasicInterop.EscapeString(valueText) & """"
                cmdBuilder.Append(escaped)

            Else
                cmdBuilder.Append(valueText)
            End If

            If i < fields.Count - 1 Then
                cmdBuilder.Append(", ")
            End If

        Next

        cmdBuilder.Append(" where RowID = ")
        cmdBuilder.Append(rowId.ToString(numFormat))

        MapBasicInterop.ExecuteCommand(cmdBuilder.ToString)


    End Sub

    Public Shared Sub DeleteRecord(ByVal tableName As String, ByVal rowId As Integer)

        If String.IsNullOrEmpty(tableName) Then
            Throw ExceptionProvider.NullOrEmptyArgException("tableName")
        End If

        If rowId < 1 Then
            Throw ExceptionProvider.ArgumentOutOfRange("rowId", rowId, "Argument 'rowId' moet een waarde hebben die groter dan of gelijk aan 1 is.")
        End If

        Dim deleteFirstRowCmd = String.Format(MapBasicInterop.GetMapInfoNumFormat, _
                                           "delete from {0}  where RowID = {1} ", _
                                           tableName, rowId)
        MapBasicInterop.ExecuteCommand(deleteFirstRowCmd)

    End Sub

    Public Shared Sub FetchFirstRecord(ByVal tableName As String)

        Dim fetchCommand = String.Format("Fetch First From {0}", tableName)
        MapBasicInterop.ExecuteCommand(fetchCommand)

    End Sub

    Public Shared Sub FetchLastRecord(ByVal tableName As String)

        Dim fetchCommand = String.Format("Fetch Last From {0}", tableName)
        MapBasicInterop.ExecuteCommand(fetchCommand)

    End Sub

    Public Shared Sub FetchNextRecord(ByVal tableName As String)

        Dim fetchCommand = String.Format("Fetch Next From {0}", tableName)
        MapBasicInterop.ExecuteCommand(fetchCommand)

    End Sub

    Public Shared Sub FetchPreviousRecord(ByVal tableName As String)

        Dim fetchCommand = String.Format("Fetch Prev From {0}", tableName)
        MapBasicInterop.ExecuteCommand(fetchCommand)

    End Sub

    Public Shared Sub FetchRecord(ByVal tableName As String, ByVal rowID As Integer)

        Dim fetchCommand = String.Format(MapBasicInterop.GetMapInfoNumFormat, _
                                         "Fetch Rec {0} From {1}", rowID, tableName)
        MapBasicInterop.ExecuteCommand(fetchCommand)

    End Sub

#Region " private methods "

    ''' <summary>
    ''' Returns the index of the table if it is open, or -1 if no table with 
    ''' the specified name or TAB file path is currently open. Names are not case sensitive.
    ''' </summary>
    ''' <param name="tableNameOrPath">Either a table name or a path to its TAB file.</param>
    ''' <param name="byFile">Set this to true if you want to search wiht a file path, false for a table name</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Shared Function GetTableIDInternal(ByVal tableNameOrPath As String, ByVal byFile As Boolean) As Short

        Dim tableAttribute As Short = -1
        If byFile Then
            tableAttribute = MapBasicConstants.TAB_INFO_TABFILE
        Else
            tableAttribute = MapBasicConstants.TAB_INFO_NAME
        End If

        ' loop from 1 to numTables, table ID = 0 is a shortcut to the most recently opened table.

        Dim numTables As Short = Short.Parse(MapBasicInterop.Evaluate("NumTables()"))
        Dim tableId As Short = 0S
        Dim found As Boolean = False

        While (Not found) And tableId <= numTables - 1

            tableId += 1S
            Dim currentTable As String = MITableProxy.GetTableInfo(tableId, tableAttribute)

            If currentTable.ToLower = tableNameOrPath.ToLower Then
                found = True
            End If

        End While

        If found Then
            Return tableId
        Else
            ' if table does not exist: return a sentinel value
            Return -1
        End If

    End Function

    Private Shared Sub VerifyTableOpen(ByVal table As String)

        If Not IsTableOpen(table) Then

            Dim msg = String.Format("No table named ""{0}"" is currently open.", table)
            Throw New InvalidOperationException(msg)

        End If

    End Sub

#End Region

    '''-------------------------------------------------------------------------------------------------
    ''' Saves a table, closes and re-opens it under the same name, 
    ''' so it will become a base table.
    '''-------------------------------------------------------------------------------------------------
    ''' Purpose: 
    ''' 	to convert temporary tables to base table. Reopening the table 
    ''' 	actually makes it a NEW table. It just happens to be one which has 
    ''' 	the same name as the old one. Since the new table comes from a file 
    ''' 	it is a base table.
    '''
    ''' Arguments:
    '''	- sfolder: [in] path of folder where the table will be saved, as a string
    '''	- s_tableName [in] name of the table
    '''
    ''' Preconditions:
    '''	- Table must be open before routine is called.
    '''
    ''' PostConditions:
    '''	- Table is opened as a base table under same name.
    '''	- Table has been saved to location s_folder\s_tablename.TAB
    '''
    ''' Invariants:
    '''	- Table must be ready for further use by calling routine, just as it 
    '''	  was before.
    '''
    '''-------------------------------------------------------------------------------------------------
    Public Shared Sub SaveAndOpenAsBaseTable(ByVal folder As String, ByVal tableName As String)

        If String.IsNullOrEmpty(folder) Then
            Throw ExceptionProvider.NullOrEmptyArgException("Folder")
        End If

        If String.IsNullOrEmpty(tableName) Then
            Throw ExceptionProvider.NullOrEmptyArgException("Tabel naam")
        End If

        If Not Directory.Exists(folder) Then
            Throw ExceptionProvider.PathArgNotFoundException("Folder", folder)
        End If

        ' Save the temp table so they can be opened if the workspace is opened in a new MapInfo Session
        Dim destinationFile As String
        Dim sourceFile As String

        ' Remove trailing slash from path

        If folder.Trim.LastIndexOf("\") = folder.Trim.Length - 1 Then
            folder = folder.Remove(folder.Trim.Length - 1, 1)
        End If

        destinationFile = String.Format("{0}\{1}.TAB", folder, tableName)

        sourceFile = MITableProxy.GetTableInfo(tableName, MITableInfo.TABFILE)

        ' Use regular commit statement if the source and destination file are the same.
        If sourceFile <> destinationFile Then

            SaveTableAs(tableName, destinationFile, False)
        Else
            'Saving as existing file

            SaveTable(tableName)
        End If

        ' Close + open is necessary to make sure the table is a BASE table.
        ' Otherwise MapInfo keeps working with the derived table which is still IN MEMORY.
        CloseTable(tableName, False)

        ' Open it again under the same name.
        OpenTableAs(destinationFile, False, tableName)

    End Sub

    ''' <summary>
    ''' Excel sometimes has empty columns especially at the outer ends of the range.
    ''' These columns need to be removed. (And the rows too?)
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    Public Shared Sub RemoveEmptyColumns(ByVal tableName As String)

        Dim emptyColumnsBuilder As New StringBuilder()
        Dim emptyCount As Integer = 0

        For cl As Short = 1 To CShort(GetAttributeCount(tableName))
            Dim columnName = MIColumnProxy.GetColumnName(tableName, cl)
            Dim uniqueVlaues = MIColumnProxy.GetUniqueValues(tableName, columnName)

            If uniqueVlaues.Count = 0 Or (uniqueVlaues.Count = 1 AndAlso String.IsNullOrEmpty(uniqueVlaues(0).Trim)) Then

                If emptyCount > 0 Then
                    emptyColumnsBuilder.Append(", ")
                End If

                emptyColumnsBuilder.Append(MIColumnProxy.GetColumnName(tableName, CShort(cl)))
                emptyCount += 1

            End If

        Next

        If emptyCount > 0 Then
            Dim dropCommand = "Alter Table " & tableName & "(drop " & emptyColumnsBuilder.ToString() & " ) Interactive"
            MapBasicInterop.ExecuteCommand(dropCommand)
        End If

    End Sub

End Class
