Public Class BancoView
    Inherits ViewBase

#Region "Initializecomponet"


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
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "No hay registros"
        Me.Label1.Visible = False
        '
        'BancoView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Label1)
        Me.Name = "BancoView"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private WithEvents oBancoABM As BancoABM

    Public Sub New()
        MyBase.New


        InitializeComponent()


        LoadGlobalCaptions()

    End Sub

    Public Sub LoadData()
        Dim oBancoData As BancoDataLayer = Nothing

        oBancoData = New BancoDataLayer

        dgvView.DataSource = Nothing

        If oBancoData.GetBancos Is Nothing Then
            Label1.Visible = True

        Else
            'pnlVacio.Visible = False
            dgvView.DataSource = oBancoData.GetBancos
        End If


    End Sub

    Private Sub BancoView_Addnew() Handles MyBase.AddNew

        Cursor = Cursors.WaitCursor

        oBancoABM = New BancoABM

        oBancoABM.Caption = "Agregar un banco"
        oBancoABM.Title = "Datos Generales"
        'oClientABM.chkActive.Checked = True
        oBancoABM.Edit(Nothing)

        Me.Visible = False
        oBancoABM.Dock = DockStyle.Fill
        oMainForm.ShowView(oBancoABM)
        oMainForm.HideLeftPanel()


        oBancoABM.Select()

        Cursor = Cursors.Arrow
    End Sub

    Public Sub SocioView_Edit() Handles MyBase.Edit
        Cursor = Cursors.WaitCursor

        oBancoABM = New BancoABM

        oBancoABM.Caption = "Editar una banco"
        oBancoABM.Title = "Datos Generales"
        Dim row As DataGridViewRow = dgvView.CurrentRow
        oBancoABM.Edit(DirectCast(row.DataBoundItem, DataRowView))

        Me.Visible = False
        oBancoABM.Dock = DockStyle.Fill
        oMainForm.ShowView(oBancoABM)
        oMainForm.HideLeftPanel()

        oBancoABM.Select()




        Cursor = Cursors.Arrow
    End Sub

    Private Sub oSocioABM_Delete() Handles MyBase.Delete
        Dim oDataLayer As BancoDataLayer = New BancoDataLayer
        Cursor = Cursors.WaitCursor
        If dgvView.RowCount > 0 Then
            If MessageBox.Show("Desea eliminar " & " '" & Trim(dgvView.CurrentRow.Cells(1).Value) & "'?", Me.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try

                    Dim Data As BancoData = New BancoData With
                    {
                        .BAN_Id = dgvView.CurrentRow.Cells(0).Value,
                        .BAN_ModifiedBy = oApp.CurrentUser.USR_Id
                    }

                    oDataLayer.DeleteBanco(Data)
                Catch ex As Exception

                End Try
            End If
        End If

        LoadData()
        Cursor = Cursors.Arrow
    End Sub

    Private Sub oClientABM_Close() Handles oBancoABM.Close
        Close_ABM()
    End Sub
    Private Sub oClientABM_Save() Handles oBancoABM.Save
        Close_ABM()
    End Sub

    Public Sub LoadGlobalCaptions()
        dgvView.AutoGenerateColumns = False
        dgvView.ColumnCount = 7

        dgvView.Columns(0).Name = "BAN_Id"
        dgvView.Columns(0).HeaderText = "Codigo"
        dgvView.Columns(0).DataPropertyName = "BAN_Id"
        dgvView.Columns(0).Width = 100
        dgvView.Columns(0).Visible = False

        dgvView.Columns(1).Name = "BAN_Name"
        dgvView.Columns(1).HeaderText = "Nombre"
        dgvView.Columns(1).DataPropertyName = "BAN_Name"
        dgvView.Columns(1).Width = 150
        'dgvView.Columns(1).DefaultCellStyle.Format = "d"
        'dgvView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvView.Columns(2).Name = "BAN_ACC_Name"
        dgvView.Columns(2).HeaderText = "Tipo de cuenta"
        dgvView.Columns(2).DataPropertyName = "BAN_ACC_Name"
        dgvView.Columns(2).Width = 120
        'dgvView.Columns(2).DefaultCellStyle.Format = "{0:N2}"
        'dgvView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvView.Columns(3).Name = "BAN_Prefix"
        dgvView.Columns(3).HeaderText = "Prefijo"
        dgvView.Columns(3).DataPropertyName = "BAN_Prefix"
        dgvView.Columns(3).Width = 120


        dgvView.Columns(4).Name = "BAN_CreatedDateTime"
        dgvView.Columns(4).HeaderText = "Fecha de alta"
        dgvView.Columns(4).DataPropertyName = "BAN_CreatedDateTime"
        dgvView.Columns(4).Width = 120
        dgvView.Columns(4).Visible = False


        dgvView.Columns(5).Name = "BAN_ModifiedDateTime"
        dgvView.Columns(5).HeaderText = "Fecha de modificacion"
        dgvView.Columns(5).DataPropertyName = "BAN_ModifiedDateTime"
        dgvView.Columns(5).Width = 100
        dgvView.Columns(5).Visible = False


        dgvView.Columns(6).Name = "BAN_ModifiedBy"
        dgvView.Columns(6).HeaderText = "Modificado por"
        dgvView.Columns(6).DataPropertyName = "BAN_ModifiedBy"
        dgvView.Columns(6).Width = 120
        dgvView.Columns(6).Visible = False


        Dim Check As New DataGridViewCheckBoxColumn
        Check.Name = "BAN_Active"
        Check.HeaderText = "Activo"
        Check.DataPropertyName = "BAN_Active"
        dgvView.Columns.Insert(7, Check)

    End Sub

    Private Sub Close_ABM()
        oMainForm.ShowLeftPanel()

        oBancoABM.Dispose()
        oBancoABM = Nothing

        LoadData()
        Me.Visible = True
    End Sub
End Class
