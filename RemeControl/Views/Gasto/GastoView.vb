Public Class GastoView
    Inherits ViewBase

    Private WithEvents Label1 As Label
    Private WithEvents oGastoABM As GastoABM

    Public Sub New()
        MyBase.New


        InitializeComponent()


        'LoadGlobalCaptions()

    End Sub

    Public Sub LoadData()
        Dim oGastoData As GastoDataLayer = Nothing
        oGastoData = New GastoDataLayer


        dgvView.DataSource = Nothing

        If oGastoData.GetGastos Is Nothing Then
            Label1.Visible = True
            dgvView.DataSource = oGastoData.GetGastos()
        Else
            dgvView.DataSource = oGastoData.GetGastos
        End If


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
        dgvView.ColumnCount = 10

        dgvView.Columns(0).Name = "CLI_Id"
        dgvView.Columns(0).HeaderText = "Codigo"
        dgvView.Columns(0).DataPropertyName = "CLI_Id"
        dgvView.Columns(0).Width = 100
        dgvView.Columns(0).Visible = False

        dgvView.Columns(1).Name = "CLI_Nombre"
        dgvView.Columns(1).HeaderText = "Nombre"
        dgvView.Columns(1).DataPropertyName = "CLI_Nombre"
        dgvView.Columns(1).Width = 150
        'dgvView.Columns(1).DefaultCellStyle.Format = "d"
        'dgvView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter


        dgvView.Columns(2).Name = "BAN_Name"
        dgvView.Columns(2).HeaderText = "Banco"
        dgvView.Columns(2).DataPropertyName = "BAN_Name"
        dgvView.Columns(2).Width = 120
        'dgvView.Columns(2).DefaultCellStyle.Format = "{0:N2}"
        'dgvView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvView.Columns(3).Name = "CLI_Cuenta"
        dgvView.Columns(3).HeaderText = "Cuenta"
        dgvView.Columns(3).DataPropertyName = "CLI_Cuenta"
        dgvView.Columns(3).Width = 120

        dgvView.Columns(4).Name = "CLI_Titular"
        dgvView.Columns(4).HeaderText = "Titular"
        dgvView.Columns(4).DataPropertyName = "CLI_Titular"
        dgvView.Columns(4).Width = 120

        dgvView.Columns(5).Name = "CLI_Cedula"
        dgvView.Columns(5).HeaderText = "Cedula"
        dgvView.Columns(5).DataPropertyName = "CLI_Cedula"
        dgvView.Columns(5).Width = 120

        dgvView.Columns(6).Name = "CLI_CreatedDateTime"
        dgvView.Columns(6).HeaderText = "Fecha de alta"
        dgvView.Columns(6).DataPropertyName = "CLI_CreatedDateTime"
        dgvView.Columns(6).Width = 120
        dgvView.Columns(6).Visible = False


        dgvView.Columns(7).Name = "CLI_ModifiedDateTime"
        dgvView.Columns(7).HeaderText = "Fecha de modificacion"
        dgvView.Columns(7).DataPropertyName = "CLI_ModifiedDateTime"
        dgvView.Columns(7).Width = 100
        dgvView.Columns(7).Visible = False


        dgvView.Columns(8).Name = "CLI_ModifiedBy"
        dgvView.Columns(8).HeaderText = "Modificado por"
        dgvView.Columns(8).DataPropertyName = "CLI_ModifiedBy"
        dgvView.Columns(8).Width = 120
        dgvView.Columns(8).Visible = False

        dgvView.Columns(9).Name = "CLI_Banco"
        dgvView.Columns(9).HeaderText = "IDBAn"
        dgvView.Columns(9).DataPropertyName = "CLI_Banco"
        dgvView.Columns(9).Width = 120
        dgvView.Columns(9).Visible = False


        Dim Check As New DataGridViewCheckBoxColumn
        Check.Name = "CLI_Active"
        Check.HeaderText = "Activo"
        Check.DataPropertyName = "CLI_Active"
        dgvView.Columns.Insert(10, Check)

    End Sub

    Private Sub Close_ABM()
        oMainForm.ShowLeftPanel()

        oGastoABM.Dispose()
        oGastoABM = Nothing

        LoadData()
        Me.Visible = True
    End Sub

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(207, 182)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "No hay registros"
        Me.Label1.Visible = False
        '
        'ClientView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ClientView"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
