Imports System.Globalization

Public Class TasaView
    Inherits ViewBase

    Private WithEvents oTasaABM As TasaABM
    Private dtTasa As DataTable

    Public Sub New()
        MyBase.New



        LoadGlobalCaptions()
    End Sub
    Public Sub LoadData()
        Dim oTasaData As TasaDataLayer = Nothing

        oTasaData = New TasaDataLayer

        'oTasaData.GetTasas()



        dgvView.DataSource = Nothing

        dgvView.DataSource = oTasaData.GetTasas

    End Sub

    Private Sub TasaView_Addnew() Handles MyBase.AddNew

        Cursor = Cursors.WaitCursor

        oTasaABM = New TasaABM

        oTasaABM.Caption = "Agregar una tasa"
        oTasaABM.Title = "Datos Generales"
        oTasaABM.Edit(Nothing)

        Me.Visible = False
        oTasaABM.Dock = DockStyle.Fill
        oMainForm.ShowView(oTasaABM)
        oMainForm.HideLeftPanel()


        oTasaABM.Select()

        Cursor = Cursors.Arrow
    End Sub

    Public Sub TasaView_Edit() Handles MyBase.Edit
        Cursor = Cursors.WaitCursor

        oTasaABM = New TasaABM
        oTasaABM.Caption = "Editar una tasa"
        oTasaABM.Title = "Datos Generales"
        Dim row As DataGridViewRow = dgvView.CurrentRow
        oTasaABM.Edit(DirectCast(row.DataBoundItem, DataRowView))

        Me.Visible = False
        oTasaABM.Dock = DockStyle.Fill
        oMainForm.ShowView(oTasaABM)
        oMainForm.HideLeftPanel()

        oTasaABM.Select()




        Cursor = Cursors.Arrow
    End Sub

    Private Sub oTasaABM_Delete() Handles MyBase.Delete
        Dim oDataLayer As TasaDataLayer = New TasaDataLayer
        Cursor = Cursors.WaitCursor
        If dgvView.RowCount > 0 Then
            If MessageBox.Show("Desea eliminar " & " '" & Trim(dgvView.CurrentRow.Cells(1).Value) & "'?", Me.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try

                    Dim Data As TasaData = New TasaData With
                    {
                        .TAS_Id = dgvView.CurrentRow.Cells(0).Value,
                        .TAS_ModifiedBy = oApp.CurrentUser.USR_Id
                    }

                    oDataLayer.DeleteTasa(Data)
                Catch ex As Exception

                End Try
            End If
        End If

        LoadData()
        Cursor = Cursors.Arrow
    End Sub

    Private Sub oTasaABM_Close() Handles oTasaABM.Close
        Close_ABM()
    End Sub
    Private Sub oTasaABM_Save() Handles oTasaABM.Save
        Close_ABM()
    End Sub

    Public Sub LoadGlobalCaptions()
        dgvView.AutoGenerateColumns = False
        dgvView.ColumnCount = 8

        dgvView.Columns(0).Name = "TAS_Id"
        dgvView.Columns(0).HeaderText = "Codigo"
        dgvView.Columns(0).DataPropertyName = "TAS_Id"
        dgvView.Columns(0).Width = 100
        dgvView.Columns(0).Visible = False

        dgvView.Columns(1).Name = "TAS_Date"
        dgvView.Columns(1).HeaderText = "Fecha"
        dgvView.Columns(1).DataPropertyName = "TAS_Date"
        dgvView.Columns(1).Width = 100
        dgvView.Columns(1).DefaultCellStyle.Format = "d"
        dgvView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvView.Columns(2).Name = "TAS_Binance"
        dgvView.Columns(2).HeaderText = "Binance"
        dgvView.Columns(2).DataPropertyName = "TAS_Binance"
        dgvView.Columns(2).Width = 120
        dgvView.Columns(2).DefaultCellStyle.Format = "{0:N2}"
        dgvView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvView.Columns(3).Name = "TAS_DolarPais"
        dgvView.Columns(3).HeaderText = "Dolar"
        dgvView.Columns(3).DataPropertyName = "TAS_DolarPais"
        dgvView.Columns(3).Width = 120
        dgvView.Columns(3).DefaultCellStyle.Format = "N"
        dgvView.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvView.Columns(4).Name = "TAS_Comision"
        dgvView.Columns(4).HeaderText = "Comision"
        dgvView.Columns(4).DataPropertyName = "TAS_Comision"
        dgvView.Columns(4).Width = 100
        dgvView.Columns(4).Visible = False
        dgvView.Columns(4).DefaultCellStyle.Format = "N"

        dgvView.Columns(5).Name = "TAS_TasaFull"
        dgvView.Columns(5).HeaderText = "Tasa full"
        dgvView.Columns(5).DataPropertyName = "TAS_TasaFull"
        dgvView.Columns(5).Width = 120
        dgvView.Columns(5).DefaultCellStyle.Format = "N"
        dgvView.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvView.Columns(6).Name = "TAS_TasaMayorista"
        dgvView.Columns(6).HeaderText = "Tasa mayorista"
        dgvView.Columns(6).DataPropertyName = "TAS_TasaMayorista"
        dgvView.Columns(6).Width = 100
        dgvView.Columns(6).Visible = False
        dgvView.Columns(6).DefaultCellStyle.Format = "n4"

        dgvView.Columns(7).Name = "TAS_TasaCliente"
        dgvView.Columns(7).HeaderText = "Tasa cliente"
        dgvView.Columns(7).DataPropertyName = "TAS_TasaCliente"
        dgvView.Columns(7).Width = 120
        dgvView.Columns(7).DefaultCellStyle.Format = "N"
        dgvView.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

    End Sub

    Private Sub Close_ABM()
        oMainForm.ShowLeftPanel()

        oTasaABM.Dispose()
        oTasaABM = Nothing

        LoadData()
        Me.Visible = True
    End Sub

End Class
