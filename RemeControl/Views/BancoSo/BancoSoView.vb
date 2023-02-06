Public Class BancoSoView
    Inherits ViewBase

    Private WithEvents Label1 As Label

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
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "No hay registros"
        Me.Label1.Visible = False
        '
        'BancoSoView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Label1)
        Me.Name = "BancoSoView"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Private WithEvents oBancoSoABM As BancoSoABM

    Public Sub New()
        MyBase.New


        InitializeComponent()


        LoadGlobalCaptions()

    End Sub

    Public Sub LoadData()
        Dim oBancoSoData As BancoSoDataLayer = Nothing

        oBancoSoData = New BancoSoDataLayer

        dgvView.DataSource = Nothing

        If oBancoSoData.GetBancoSo Is Nothing Then
            Label1.Visible = True

        Else
            'pnlVacio.Visible = False
            dgvView.DataSource = oBancoSoData.GetBancoSo
        End If


    End Sub

    Private Sub BancoSoView_Addnew() Handles MyBase.AddNew

        Cursor = Cursors.WaitCursor


        oBancoSoABM = New BancoSoABM

            oBancoSoABM.Caption = "Agregar un banco socio"
            oBancoSoABM.Title = "Datos Generales"
            'oClientABM.chkActive.Checked = True
            oBancoSoABM.Edit(Nothing)

            Me.Visible = False
            oBancoSoABM.Dock = DockStyle.Fill
            oMainForm.ShowView(oBancoSoABM)
            oMainForm.HideLeftPanel()


            oBancoSoABM.Select()


        Cursor = Cursors.Arrow
    End Sub

    Public Sub BancoSoView_Edit() Handles MyBase.Edit
        Cursor = Cursors.WaitCursor

        oBancoSoABM = New BancoSoABM

        oBancoSoABM.Caption = "Editar una banco socio"
        oBancoSoABM.Title = "Datos Generales"
        Dim row As DataGridViewRow = dgvView.CurrentRow
        oBancoSoABM.Edit(DirectCast(row.DataBoundItem, DataRowView))

        Me.Visible = False
        oBancoSoABM.Dock = DockStyle.Fill
        oMainForm.ShowView(oBancoSoABM)
        oMainForm.HideLeftPanel()

        oBancoSoABM.Select()




        Cursor = Cursors.Arrow
    End Sub

    Private Sub oBancoSoABM_Delete() Handles MyBase.Delete
        Dim oDataLayer As BancoSoDataLayer = New BancoSoDataLayer
        Cursor = Cursors.WaitCursor
        If dgvView.RowCount > 0 Then
            If MessageBox.Show("Desea eliminar " & " '" & Trim(dgvView.CurrentRow.Cells(1).Value) & "'?", Me.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try

                    Dim Data As BancoSoData = New BancoSoData With
                    {
                        .OSB_Id = dgvView.CurrentRow.Cells(0).Value,
                        .OSB_ModifiedBy = oApp.CurrentUser.USR_Id
                    }

                    oDataLayer.DeleteBancoSo(Data)
                Catch ex As Exception

                End Try
            End If
        End If

        LoadData()
        Cursor = Cursors.Arrow
    End Sub

    Private Sub oBancoSoABM_Close() Handles oBancoSoABM.Close
        Close_ABM()
    End Sub
    Private Sub oBancoSoABM_Save() Handles oBancoSoABM.Save
        Close_ABM()
    End Sub

    Public Sub LoadGlobalCaptions()
        dgvView.AutoGenerateColumns = False
        dgvView.ColumnCount = 11

        dgvView.Columns(0).Name = "OSB_Id"
        dgvView.Columns(0).HeaderText = "Codigo"
        dgvView.Columns(0).DataPropertyName = "OSB_Id"
        dgvView.Columns(0).Width = 100
        dgvView.Columns(0).Visible = False

        dgvView.Columns(1).Name = "OSB_Nombre"
        dgvView.Columns(1).HeaderText = "Nombre"
        dgvView.Columns(1).DataPropertyName = "OSB_Nombre"
        dgvView.Columns(1).Width = 150

        dgvView.Columns(2).Name = "OSB_Type"
        dgvView.Columns(2).HeaderText = "Tipo de cuenta"
        dgvView.Columns(2).DataPropertyName = "OSB_Type"
        dgvView.Columns(2).Width = 120
        dgvView.Columns(2).Visible = False


        dgvView.Columns(3).Name = "OSBT_Nombre"
        dgvView.Columns(3).HeaderText = "Tipo de cuenta"
        dgvView.Columns(3).DataPropertyName = "OSBT_Nombre"
        dgvView.Columns(3).Width = 120

        dgvView.Columns(4).Name = "OSB_Account"
        dgvView.Columns(4).HeaderText = "Numero de cuenta"
        dgvView.Columns(4).DataPropertyName = "OSB_Account"
        dgvView.Columns(4).Width = 120

        dgvView.Columns(5).Name = "OSB_InitialBalance"
        dgvView.Columns(5).HeaderText = "Saldo"
        dgvView.Columns(5).DataPropertyName = "OSB_InitialBalance"
        dgvView.Columns(5).Width = 120


        dgvView.Columns(6).Name = "OSB_BeginninBalanceDate"
        dgvView.Columns(6).HeaderText = "Fecha de inicio"
        dgvView.Columns(6).DataPropertyName = "OSB_BeginninBalanceDate"
        dgvView.Columns(6).Width = 120
        dgvView.Columns(6).Visible = False

        dgvView.Columns(7).Name = "OSB_Description"
        dgvView.Columns(7).HeaderText = "Descripción"
        dgvView.Columns(7).DataPropertyName = "OSB_Description"
        dgvView.Columns(7).Width = 120
        dgvView.Columns(7).Visible = False

        dgvView.Columns(8).Name = "OSB_CreatedDateTime"
        dgvView.Columns(8).HeaderText = "Fecha de alta"
        dgvView.Columns(8).DataPropertyName = "OSB_CreatedDateTime"
        dgvView.Columns(8).Width = 120
        dgvView.Columns(8).Visible = False

        dgvView.Columns(9).Name = "OSB_ModifiedDateTime"
        dgvView.Columns(9).HeaderText = "Fecha de modificacion"
        dgvView.Columns(9).DataPropertyName = "OSB_ModifiedDateTime"
        dgvView.Columns(9).Width = 100
        dgvView.Columns(9).Visible = False

        dgvView.Columns(10).Name = "OSB_ModifiedBy"
        dgvView.Columns(10).HeaderText = "Modificado por"
        dgvView.Columns(10).DataPropertyName = "OSB_ModifiedBy"
        dgvView.Columns(10).Width = 120
        dgvView.Columns(10).Visible = False


        Dim Check As New DataGridViewCheckBoxColumn
        Check.Name = "OSB_Active"
        Check.HeaderText = "Activo"
        Check.DataPropertyName = "OSB_Active"
        dgvView.Columns.Insert(11, Check)

    End Sub

    Private Sub Close_ABM()
        oMainForm.ShowLeftPanel()

        oBancoSoABM.Dispose()
        oBancoSoABM = Nothing

        LoadData()
        Me.Visible = True
    End Sub
End Class
