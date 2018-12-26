Option Strict On

'This is still experimental code, not used in any forms yet

Imports Gim.ErrorHandling

Public Class AddRemoveList(Of T)

    Private m_availableItems As New List(Of T)

    Private m_selectedItems As New List(Of T)

    ReadOnly Property AvailableItems() As List(Of T)
        Get
            Return m_availableItems
        End Get
    End Property

    ReadOnly Property SelectedItems() As List(Of T)
        Get
            Return m_selectedItems
        End Get
    End Property

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.ListBoxAvailableValues.DataSource = m_availableItems
        Me.ListBoxSelectedValues.DataSource = m_selectedItems

    End Sub


    Private Sub ButtonAddToSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonAddToSelection.Click

        Try

            Dim itemsToMove As T() = New T(m_availableItems.Count - 1) {}
            m_availableItems.CopyTo(itemsToMove, 0)

            For Each item In itemsToMove
                m_selectedItems.Add(item)
                m_availableItems.Remove(item)
            Next

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub


    Private Sub ButtonRemoveFromSelection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonRemoveFromSelection.Click

        Try

            Dim itemsToMove As T() = New T(m_selectedItems.Count - 1) {}
            m_selectedItems.CopyTo(itemsToMove, 0)

            For Each it In itemsToMove
                m_availableItems.Add(it)
                m_selectedItems.Remove(it)
            Next

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub
End Class
