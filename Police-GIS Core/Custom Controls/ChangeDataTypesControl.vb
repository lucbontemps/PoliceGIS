Option Strict On

' System namespaces
Imports System.Reflection
Imports System.Windows.Forms

' GIM namespaces
Imports Gim.ErrorHandling

Public Class ChangeDataTypesControl

    Private m_columns As New List(Of ColumnTypeDescriptor)


    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
 
    End Sub

    ''' <summary>
    ''' The Columns property is readonly.
    ''' You should set the columms via a separate method, SetColumns
    ''' The reason is that the Visual Studio designer has a lot of trouble
    ''' with this property. It tries to serialize its contents in the 
    ''' resources files, but it has trouble when you change thing about 
    ''' the type of the property.
    ''' 
    ''' This property is meant to be volatile and should not be serialized 
    ''' anyway, but this is how the designer treats properties on a 
    ''' custom control / user control.
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Columns() As List(Of ColumnTypeDescriptor)
        Get
            Return m_columns
        End Get
    End Property


    ' Not for the outside world! must remain private
    Private Sub SetColumnsInternal(ByVal value As List(Of ColumnTypeDescriptor))

        If value IsNot Nothing Then
            m_columns = value
            BindControl()

            ChangeButton.Enabled = m_columns.Count > 0

        End If

    End Sub

    Private Sub BindControl()

        ColumnsComboBox.DataSource = New BindingSource(m_columns, Nothing)
        ColumnsComboBox.DisplayMember = "ColumnName"

        TypeComboBox.DataSource = New BindingSource(ListDataTypes, Nothing)
        TypeComboBox.DisplayMember = "Value"
        TypeComboBox.ValueMember = "Key"

    End Sub


    Public Sub SetColumnInfo(ByVal tablePath As String, ByVal fieldNames As List(Of String))

        If String.IsNullOrEmpty(tablePath) Then
            Throw ExceptionProvider.NullOrEmptyArgException("tablePath")

        ElseIf Not System.IO.File.Exists(tablePath) Then
            Throw ExceptionProvider.PathArgNotFoundException("tablePath", tablePath)

        End If

        Dim tempTable = ""
        Try
            tempTable = MITableProxy.OpenTable(tablePath, False)

            Dim list As New List(Of ColumnTypeDescriptor)

            ' MapInfo columns start counting from 1, while .NET arrays start from 0.
            For columIndex As Short = 1 To MITableProxy.GetAttributeCount(tempTable)

                Dim info As New ColumnTypeDescriptor
                info.ColumnName = fieldNames(columIndex - 1)
                info.ColumnType = MIColumnProxy.GetColumnType(tempTable, columIndex) 'miColumnProxy.ColumnType
                info.Width = MIColumnProxy.GetColumnWidth(tempTable, columIndex)
                If info.ColumnType = MIColumnType.DecimalType Then
                    info.DecimalPlaces = MIColumnProxy.GetDecimalPlaces(tempTable, columIndex)
                End If
                list.Add(info)

            Next

            SetColumnsInternal(list)


        Finally

            If Not String.IsNullOrEmpty(tempTable) Then
                If MITableProxy.IsTableOpen(tempTable) Then
                    MITableProxy.CloseTable(tempTable, False)
                End If
            End If

        End Try

    End Sub



    Private Sub ColumnsComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ColumnsComboBox.SelectedIndexChanged

        Try

            Dim clInfo = DirectCast(ColumnsComboBox.SelectedItem, ColumnTypeDescriptor)
            TypeComboBox.SelectedValue = clInfo.ColumnType
            LabelType.Text = ListDataTypes.Where(Function(m) m.Key = clInfo.ColumnType).First.Value
            If clInfo.HasDecimalPlaces Then
                DecimalPlacesNumericUD.Value = clInfo.decimalPlaces
            Else
                DecimalPlacesNumericUD.Value = 0
            End If

            If clInfo.HasWidth Then
                WidthNumericUD.Value = clInfo.width
            Else
                WidthNumericUD.Value = 0
            End If

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Public Shared Function ListDataTypes() As Dictionary(Of MIColumnType, String)

        Dim dataTypesList As New Dictionary(Of MIColumnType, String)

        dataTypesList.Add(MIColumnType.CharType, "Char")
        dataTypesList.Add(MIColumnType.IntegerType, "Integer")
        dataTypesList.Add(MIColumnType.SmallintType, "Smallint")
        dataTypesList.Add(MIColumnType.FloatType, "Float")
        dataTypesList.Add(MIColumnType.DecimalType, "Decimal")
        dataTypesList.Add(MIColumnType.LogicalType, "Logical")
        dataTypesList.Add(MIColumnType.DateType, "Date")
        dataTypesList.Add(MIColumnType.TimeType, "Time")
        dataTypesList.Add(MIColumnType.DatetimeType, "DateTime")

        Return dataTypesList

    End Function



    ''' <summary>
    ''' Afhankelijk van het datatype gaan we velden al dan niet beschikbaar maken.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub TypeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TypeComboBox.SelectedIndexChanged

        Try

            If TypeComboBox.SelectedIndex >= 0 Then

                Dim kv = DirectCast(TypeComboBox.SelectedItem, KeyValuePair(Of MIColumnType, String))

                If ColumnTypeDescriptor.HasWidth(kv.Key) Then
                    WidthNumericUD.Enabled = True
                Else
                    WidthNumericUD.Enabled = False
                End If

                If ColumnTypeDescriptor.HasDecimalPlaces(kv.Key) Then
                    DecimalPlacesNumericUD.Enabled = True
                Else
                    DecimalPlacesNumericUD.Enabled = False
                End If


            End If

        Catch ex As Exception
            GenericExceptionHandlingForm.ShowException(ex)
        End Try

    End Sub

    Private Sub WijzigButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangeButton.Click

        If ColumnsComboBox.SelectedIndex >= 0 Then

            Dim colInfo = Columns(ColumnsComboBox.SelectedIndex)
            Dim kv = DirectCast(TypeComboBox.SelectedItem, KeyValuePair(Of MIColumnType, String))
            colInfo.ColumnType = kv.Key

            If colInfo.HasWidth Then
                colInfo.Width = Decimal.ToInt16(WidthNumericUD.Value)
            End If

            If colInfo.HasDecimalPlaces Then
                colInfo.DecimalPlaces = Decimal.ToInt16(DecimalPlacesNumericUD.Value)
            End If

            LabelType.Text = kv.Value

        End If

    End Sub

End Class
