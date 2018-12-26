Option Strict On

Imports System.Drawing

Public Class GuiThemeProvider

    Public Const POLICE_BLUE_HUE As Integer = 228
    Public Const POLICE_BLUE_SATURATION As Integer = 99
    Public Const POLICE_BLUE_VALUE As Integer = 100

    Shared ReadOnly Property AlternatingRowColor() As System.Drawing.Color
        Get

            ' a pale blue that matches the police logo in hue but is much lighter
            ' The color is completely opaque (alpha = 100%, or a value of 255)
            Return Color.FromArgb(255, 217, 224, 255)
        End Get
    End Property

    Public Shared Function GetPoliceIcon() As Icon
        Return GetPoliceLogo(False)
    End Function

    Public Shared Function GetPoliceLogo(ByVal useLargeLogo As Boolean) As Icon

        If useLargeLogo Then
            Return My.Resources.PolitieGIS_favicon_16x16
        Else
            Return My.Resources.PolitieGIS_desktop_32x32
        End If

    End Function


    Private Structure RgbColor
        Public red As Byte
        Public green As Byte
        Public blue As Byte
    End Structure

    Private Structure HsvColor
        Public hue As Double
        Public saturation As Double
        Public value As Double
    End Structure

End Class
