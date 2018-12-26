Option Strict On

Imports System.Globalization

Public Class MICommandInfo

    Public Enum CmdInfoCode As Short

        X = 1
        Y = 2
        SHIFT = 3
        CTRL = 4
        X2 = 5
        Y2 = 6
        TOOLBTN = 7
        MENUITEM = 8
        WIN = 1
        SELTYPE = 1
        ROWID = 2
        INTERRUPT = 3
        STATUS = 1
        MSG = 1000
        DLG_OK = 1
        DLG_DBL = 1
        FIND_RC = 3
        FIND_ROWID = 4
        XCMD = 1
        CUSTOM_OBJ = 1
        TASK_SWITCH = 1
        EDIT_TABLE = 1
        EDIT_STATUS = 2
        EDIT_ASK = 1
        EDIT_SAVE = 2
        EDIT_DISCARD = 3
        HL_WINDOW_ID = 17
        HL_TABLE_NAME = 18
        HL_ROWID = 19
        HL_LAYER_ID = 20
        HL_FILE_NAME = 21

    End Enum


    Public Shared Function CommandInfo(ByVal infoCode As CmdInfoCode) As String
        Dim attribute = DirectCast(infoCode, Short)
        Dim expression = String.Format(MapBasicInterop.GetMapInfoNumFormat, "CommandInfo({0})", attribute)
        Return MapBasicInterop.Evaluate(expression)
    End Function


    Private Shared Function GetCommandInfoDouble(ByVal infoCode As CmdInfoCode, ByVal propertyName As String) As Double

        Dim valueD As Double
        Dim result As String = CommandInfo(infoCode)

        If Double.TryParse(result, NumberStyles.AllowDecimalPoint, MapBasicInterop.GetMapInfoNumFormat, valueD) Then
            Return valueD
        Else
            Dim msg = String.Format("Result of {0} is not a Double. value: {1} ", propertyName, result)
            Throw New PoliceGisException(msg)
        End If

    End Function

    Public Shared Function CoordinateX() As Double
        Return GetCommandInfoDouble(CmdInfoCode.X, "CoordinateX")
    End Function

    Public Shared Function CoordinateX2() As Double
        Return GetCommandInfoDouble(CmdInfoCode.X2, "CoordinateX2")
    End Function

    Public Shared Function CoordinateY() As Double
        Return GetCommandInfoDouble(CmdInfoCode.Y, "CoordinateY")
    End Function

    Public Shared Function CoordinateY2() As Double
        Return GetCommandInfoDouble(CmdInfoCode.Y2, "CoordinateY2")
    End Function

    Public Shared Function SHIFT() As String
        Return CommandInfo(CmdInfoCode.SHIFT)
    End Function

    Public Shared Function CTRL() As String
        Return CommandInfo(CmdInfoCode.CTRL)
    End Function


    Public Shared Function TOOLBTN() As String
        Return CommandInfo(CmdInfoCode.TOOLBTN)
    End Function

    Public Shared Function MENUITEM() As String
        Return CommandInfo(CmdInfoCode.MENUITEM)
    End Function

    Public Shared Function WIN() As String
        Return CommandInfo(CmdInfoCode.WIN)
    End Function

    Public Shared Function SELTYPE() As String
        Return CommandInfo(CmdInfoCode.SELTYPE)
    End Function

    Public Shared Function ROWID() As String
        Return CommandInfo(CmdInfoCode.ROWID)
    End Function

    Public Shared Function INTERRUPT() As String
        Return CommandInfo(CmdInfoCode.INTERRUPT)
    End Function

    Public Shared Function STATUS() As String
        Return CommandInfo(CmdInfoCode.STATUS)
    End Function

    Public Shared Function MSG() As String
        Return CommandInfo(CmdInfoCode.MSG)
    End Function

    Public Shared Function DLG_DBL() As String
        Return CommandInfo(CmdInfoCode.DLG_DBL)
    End Function

    Public Shared Function DLG_OK() As String
        Return CommandInfo(CmdInfoCode.DLG_OK)
    End Function

    Public Shared Function EDIT_ASK() As String
        Return CommandInfo(CmdInfoCode.EDIT_ASK)
    End Function

    Public Shared Function EDIT_DISCARD() As String
        Return CommandInfo(CmdInfoCode.EDIT_DISCARD)
    End Function

    Public Shared Function EDIT_SAVE() As String
        Return CommandInfo(CmdInfoCode.EDIT_SAVE)
    End Function

    Public Shared Function EDIT_STATUS() As String
        Return CommandInfo(CmdInfoCode.EDIT_STATUS)
    End Function

    Public Shared Function EDIT_TABLE() As String
        Return CommandInfo(CmdInfoCode.EDIT_TABLE)
    End Function

    Public Shared Function FIND_RC() As String
        Return CommandInfo(CmdInfoCode.FIND_RC)
    End Function

    Public Shared Function FIND_ROWID() As String
        Return CommandInfo(CmdInfoCode.FIND_ROWID)
    End Function

    Public Shared Function HL_FILE_NAME() As String
        Return CommandInfo(CmdInfoCode.HL_FILE_NAME)
    End Function

    Public Shared Function HL_LAYER_ID() As String
        Return CommandInfo(CmdInfoCode.HL_LAYER_ID)
    End Function

    Public Shared Function HL_ROWID() As String
        Return CommandInfo(CmdInfoCode.HL_ROWID)
    End Function

    Public Shared Function HL_TABLE_NAME() As String
        Return CommandInfo(CmdInfoCode.HL_TABLE_NAME)
    End Function

    Public Shared Function HL_WINDOW_ID() As String
        Return CommandInfo(CmdInfoCode.HL_WINDOW_ID)
    End Function


End Class

