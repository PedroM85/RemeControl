Public Class GastoView
    Inherits ViewBase

#Region "InitializeComponent"


    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(307, 255)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "No hay registros"
        Me.Label1.Visible = False
        '
        'GastoView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Label1)
        Me.Name = "GastoView"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private WithEvents Label1 As Label
    Private WithEvents oGastoABM As GastoABM
    Private oBsource As BindingSource

    Public Sub New()
        MyBase.New


        InitializeComponent()


        LoadGlobalCaptions()

    End Sub

    Public Sub LoadData()
        Dim oGastoData As New GastoDataLayer
        oBsource = New BindingSource


        Try
            dgvView.DataSource = Nothing
            oBsource.DataSource = oGastoData.GetGastos
            If oBsource.Item(0).Row.ItemArray(0) = -1 Then
                Label1.Visible = True

            Else
                Label1.Visible = False
                With dgvView
                    .DataSource = Nothing
                    .DataSource = oBsource.DataSource
                End With

            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub GastoView_Addnew() Handles MyBase.AddNew

        Cursor = Cursors.WaitCursor

        oGastoABM = New GastoABM

        oGastoABM.Caption = "Agregar un gasto"
        oGastoABM.Title = "Datos Generales"
        'oClientABM.chkActive.Checked = True
        oGastoABM.Edit(Nothing)

        Me.Visible = False
        oGastoABM.Dock = DockStyle.Fill
        oMainForm.ShowView(oGastoABM)
        oMainForm.HideLeftPanel()


        oGastoABM.Select()

        Cursor = Cursors.Arrow
    End Sub

    Public Sub GastoView_Edit() Handles MyBase.Edit
        Cursor = Cursors.WaitCursor

        oGastoABM = New GastoABM

        oGastoABM.Caption = "Editar un gasto"
        oGastoABM.Title = "Datos Generales"
        Dim row As DataGridViewRow = dgvView.CurrentRow
        oGastoABM.Edit(DirectCast(row.DataBoundItem, DataRowView))

        Me.Visible = False
        oGastoABM.Dock = DockStyle.Fill
        oMainForm.ShowView(oGastoABM)
        oMainForm.HideLeftPanel()

        oGastoABM.Select()




        Cursor = Cursors.Arrow
    End Sub

    Private Sub oGastoABM_Delete() Handles MyBase.Delete
        Dim oDataLayer As GastoDataLayer = New GastoDataLayer
        Cursor = Cursors.WaitCursor
        If dgvView.RowCount > 0 Then
            If MessageBox.Show("Desea eliminar " & " '" & Trim(dgvView.CurrentRow.Cells(1).Value) & "'?", Me.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try

                    Dim Data As GastoData = New GastoData With
                    {
                        .GAT_Id = dgvView.CurrentRow.Cells(0).Value,
                        .GAT_ModifiedBy = oApp.CurrentUser.USR_Id
                    }

                    oDataLayer.DeleteGasto(Data)
                Catch ex As Exception

                End Try
            End If
        End If

        LoadData()
        Cursor = Cursors.Arrow
    End Sub

    Private Sub oGastoABM_Close() Handles oGastoABM.Close
        Close_ABM()
    End Sub
    Private Sub oGastoABM_Save() Handles oGastoABM.Save
        Close_ABM()
    End Sub

    Public Sub LoadGlobalCaptions()
        dgvView.AutoGenerateColumns = False
        dgvView.ColumnCount = 13

        dgvView.Columns(0).Name = "GAT_Id"
        dgvView.Columns(0).HeaderText = "Codigo"
        dgvView.Columns(0).DataPropertyName = "GAT_Id"
        dgvView.Columns(0).Width = 100
        dgvView.Columns(0).Visible = False

        dgvView.Columns(1).Name = "GAT_Date"
        dgvView.Columns(1).HeaderText = "Fecha"
        dgvView.Columns(1).DataPropertyName = "GAT_Date"
        dgvView.Columns(1).Width = 150

        dgvView.Columns(2).Name = "GAT_SOC_Id"
        dgvView.Columns(2).HeaderText = "Banco"
        dgvView.Columns(2).DataPropertyName = "GAT_SOC_Id"
        dgvView.Columns(2).Width = 120
        dgvView.Columns(2).Visible = False

        dgvView.Columns(3).Name = "SOC_Name"
        dgvView.Columns(3).HeaderText = "Nombre"
        dgvView.Columns(3).DataPropertyName = "SOC_Name"
        dgvView.Columns(3).Width = 120

        dgvView.Columns(4).Name = "GAT_OSB_Id"
        dgvView.Columns(4).HeaderText = "Titular"
        dgvView.Columns(4).DataPropertyName = "GAT_OSB_Id"
        dgvView.Columns(4).Visible = False

        dgvView.Columns(5).Name = "OSB_Nombre"
        dgvView.Columns(5).HeaderText = "Banco"
        dgvView.Columns(5).DataPropertyName = "OSB_Nombre"
        dgvView.Columns(5).Width = 120

        dgvView.Columns(6).Name = "GAT_OSBT_Id"
        dgvView.Columns(6).HeaderText = "Banco"
        dgvView.Columns(6).DataPropertyName = "GAT_OSBT_Id"
        dgvView.Columns(6).Visible = False

        dgvView.Columns(7).Name = "OSBT_Nombre"
        dgvView.Columns(7).HeaderText = "Tipo de cuenta"
        dgvView.Columns(7).DataPropertyName = "OSBT_Nombre"

        dgvView.Columns(8).Name = "GAT_Reason"
        dgvView.Columns(8).HeaderText = "Uso"
        dgvView.Columns(8).DataPropertyName = "GAT_Reason"
        dgvView.Columns(8).Visible = False

        dgvView.Columns(9).Name = "GAT_Amount"
        dgvView.Columns(9).HeaderText = "Monto"
        dgvView.Columns(9).DataPropertyName = "GAT_Amount"

        dgvView.Columns(10).Name = "GAT_CreatedDateTime"
        dgvView.Columns(10).HeaderText = "Fecha de alta"
        dgvView.Columns(10).DataPropertyName = "GAT_CreatedDateTime"
        dgvView.Columns(10).Visible = False

        dgvView.Columns(11).Name = "GAT_ModifiedDateTime"
        dgvView.Columns(11).HeaderText = "Fecha de modificacion"
        dgvView.Columns(11).DataPropertyName = "GAT_ModifiedDateTime"
        dgvView.Columns(11).Visible = False

        dgvView.Columns(12).Name = "GAT_ModifiedBy"
        dgvView.Columns(12).HeaderText = "Modificado por"
        dgvView.Columns(12).DataPropertyName = "GAT_ModifiedBy"
        dgvView.Columns(12).Visible = False


        Dim Check As New DataGridViewCheckBoxColumn
        Check.Name = "GAT_Active"
        Check.HeaderText = "Activo"
        Check.DataPropertyName = "GAT_Active"
        dgvView.Columns.Insert(13, Check)

    End Sub

    Private Sub dgvView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs)
        If Me.dgvView.Columns(e.ColumnIndex).Name = "GAT_Date" And e.RowIndex <> dgvView.NewRowIndex Then
            Dim val1 As Date = Date.Parse(e.Value.ToString())
            e.Value = val1.ToString("d")
        End If
        If Me.dgvView.Columns(e.ColumnIndex).Name = "GAT_Amount" And e.RowIndex <> dgvView.NewRowIndex Then
            Dim val1 As Decimal = Decimal.Parse(e.Value.ToString())
            e.Value = val1.ToString("N2")
            Dim type = CInt(CType(sender, DataGridView).Rows(e.RowIndex).Cells("GAT_Amount").Value)
            If type = 1 And e.ColumnIndex = 9 Then
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        End If

    End Sub
    Private Sub Close_ABM()
        oMainForm.ShowLeftPanel()

        oGastoABM.Dispose()
        oGastoABM = Nothing

        LoadData()
        Me.Visible = True
    End Sub


End Class
