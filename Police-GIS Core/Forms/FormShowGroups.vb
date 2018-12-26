Option Strict On

''' <summary>
''' Part of the GUi for the grouping module.
''' Shows the groups in a separate window so you kan inspect 
''' and modify them more easily.
''' </summary>
''' <remarks></remarks>
Public Class FormShowGroups

    Private m_groupMapping As DataTable

    Public Sub New()
        Me.New(Nothing)
    End Sub

    Public Sub New(ByVal groupMapping As DataTable)


        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        ' Logo of the police is the icon for the window.

        Me.Icon = GuiThemeProvider.GetPoliceIcon


        ' set the mapping table that contains which group each value belongs too.
        m_groupMapping = groupMapping
        DefinedGroupsDataGridView.AlternatingRowsDefaultCellStyle.BackColor = GuiThemeProvider.AlternatingRowColor

    End Sub

    Property GroupMapping() As DataTable
        Get
            Return m_groupMapping
        End Get
        Set(ByVal value As DataTable)

            m_groupMapping = value

            If m_groupMapping IsNot Nothing Then

                DefinedGroupsDataGridView.DataSource = m_groupMapping
                GroupDGColumn.DataPropertyName = FormCreateGroups.COLUMN_GROUP
                ValueDGColumn.DataPropertyName = FormCreateGroups.COLUMN_VALUE

                'dim names  = select Name from m_groupMapping.Columns
                DefinedGroupsDataGridView.Columns.Remove(m_groupMapping.Columns(0).ColumnName)
                DefinedGroupsDataGridView.Columns.Remove(m_groupMapping.Columns(1).ColumnName)

            End If

        End Set
    End Property

End Class