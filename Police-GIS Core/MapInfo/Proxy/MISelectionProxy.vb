Option Strict On

Public Class MISelectionProxy

    Public Shared Function GetSelectionInfo(ByVal attribute As SelectionInfoCodes) As String

        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "SelectionInfo( {0} )", DirectCast(attribute, Short))
        Return MapBasicInterop.Evaluate(expression)

    End Function

    Public Shared Function NumberOfRows() As Integer

        Dim result = GetSelectionInfo(SelectionInfoCodes.SEL_INFO_NROWS)
        Return Integer.Parse(result)

    End Function

    Public Shared Function SelectionName() As String
        Return GetSelectionInfo(SelectionInfoCodes.SEL_INFO_SELNAME)
    End Function


    Public Shared Function TableName() As String
        Return GetSelectionInfo(SelectionInfoCodes.SEL_INFO_TABLENAME)
    End Function


    Public Enum SelectionInfoCodes As Short
        SEL_INFO_NROWS = MapBasicConstants.SEL_INFO_NROWS
        SEL_INFO_SELNAME = MapBasicConstants.SEL_INFO_SELNAME
        SEL_INFO_TABLENAME = MapBasicConstants.SEL_INFO_TABLENAME
    End Enum

    Public Shared Sub SelectMax(ByVal column As String, ByVal tablename As String)

        MapBasicInterop.ExecuteCommand(String.Format(" Select Max({0}) From {1}", column, tablename))

    End Sub

End Class
