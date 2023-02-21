Public Class SocioView
    Inherits ViewBase

    Private WithEvents Label1 As Label
    Private WithEvents oSocioABM As SocioABM

#Region "Initial"

    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Red
        Me.Label1.Location = New System.Drawing.Point(188, 183)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "No hay registros"
        Me.Label1.Visible = False
        '
        'SocioView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SocioView"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
    Public Sub New()
        MyBase.New

        InitializeComponent()

        LoadGlobalCaptions()
    End Sub

    Public Sub LoadData()
        Dim oSocioData As SocioDataLayer = Nothing

        oSocioData = New SocioDataLayer

        dgvView.DataSource = Nothing

        If oSocioData.GetSocios Is Nothing Then
            Label1.Visible = True

        Else
            'pnlVacio.Visible = False
            dgvView.DataSource = oSocioData.GetSocios
        End If

    End Sub

    Private Sub SocioView_Addnew() Handles MyBase.AddNew

        Cursor = Cursors.WaitCursor

        oSocioABM = New SocioABM

        oSocioABM.Caption = "Agregar una socio"
        oSocioABM.Title = "Datos Generales"
        oSocioABM.chkActive.Checked = True
        oSocioABM.Edit(Nothing)

        Me.Visible = False
        oSocioABM.Dock = DockStyle.Fill
        oMainForm.ShowView(oSocioABM)
        oMainForm.HideLeftPanel()


        oSocioABM.Select()

        Cursor = Cursors.Arrow
    End Sub

    Public Sub SocioView_Edit() Handles MyBase.Edit
        Cursor = Cursors.WaitCursor

        oSocioABM = New SocioABM

        oSocioABM.Caption = "Editar una socio"
        oSocioABM.Title = "Datos Generales"
        Dim row As DataGridViewRow = dgvView.CurrentRow
        oSocioABM.Edit(DirectCast(row.DataBoundItem, DataRowView))

        Me.Visible = False
        oSocioABM.Dock = DockStyle.Fill
        oMainForm.ShowView(oSocioABM)
        oMainForm.HideLeftPanel()

        oSocioABM.Select()




        Cursor = Cursors.Arrow
    End Sub

    Private Sub oSocioABM_Delete() Handles MyBase.Delete
        Dim oDataLayer As SocioDataLayer = New SocioDataLayer
        Cursor = Cursors.WaitCursor
        If dgvView.RowCount > 0 Then
            If MessageBox.Show("Desea eliminar " & " '" & Trim(dgvView.CurrentRow.Cells(1).Value) & "'?", Me.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try

                    Dim Data As SocioData = New SocioData With
                    {
                        .SOC_Id = dgvView.CurrentRow.Cells(0).Value,
                        .SOC_ModifiedBy = oApp.CurrentUser.USR_Id
                    }

                    oDataLayer.DeleteSocios(Data)
                Catch ex As Exception

                End Try
            End If
        End If

        LoadData()
        Cursor = Cursors.Arrow
    End Sub

    Private Sub oSocioABM_Close() Handles oSocioABM.Close
        Close_ABM()
    End Sub
    Private Sub oSocioABM_Save() Handles oSocioABM.Save
        Close_ABM()
    End Sub

    Public Sub LoadGlobalCaptions()
        dgvView.AutoGenerateColumns = False
        dgvView.ColumnCount = 6

        dgvView.Columns(0).Name = "SOC_Id"
        dgvView.Columns(0).HeaderText = "Codigo"
        dgvView.Columns(0).DataPropertyName = "SOC_Id"
        dgvView.Columns(0).Width = 100
        dgvView.Columns(0).Visible = False

        dgvView.Columns(1).Name = "SOC_Name"
        dgvView.Columns(1).HeaderText = "Nombre"
        dgvView.Columns(1).DataPropertyName = "SOC_Name"
        dgvView.Columns(1).Width = 150
        'dgvView.Columns(1).DefaultCellStyle.Format = "d"
        'dgvView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvView.Columns(2).Name = "SOC_Telefono"
        dgvView.Columns(2).HeaderText = "Telefono"
        dgvView.Columns(2).DataPropertyName = "SOC_Telefono"
        dgvView.Columns(2).Width = 120
        'dgvView.Columns(2).DefaultCellStyle.Format = "{0:N2}"
        'dgvView.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvView.Columns(3).Name = "SOC_CreatedDateTime"
        dgvView.Columns(3).HeaderText = "Dolar"
        dgvView.Columns(3).DataPropertyName = "SOC_CreatedDateTime"
        dgvView.Columns(3).Width = 120
        dgvView.Columns(3).Visible = False


        dgvView.Columns(4).Name = "SOC_ModifiedDateTime"
        dgvView.Columns(4).HeaderText = "Comision"
        dgvView.Columns(4).DataPropertyName = "SOC_ModifiedDateTime"
        dgvView.Columns(4).Width = 100
        dgvView.Columns(4).Visible = False


        dgvView.Columns(5).Name = "SOC_ModifiedBy"
        dgvView.Columns(5).HeaderText = "Tasa full"
        dgvView.Columns(5).DataPropertyName = "SOC_ModifiedBy"
        dgvView.Columns(5).Width = 120
        dgvView.Columns(5).Visible = False


        Dim Check As New DataGridViewCheckBoxColumn
        Check.Name = "SOC_Active"
        Check.HeaderText = "Activo"
        Check.DataPropertyName = "SOC_Active"
        dgvView.Columns.Insert(6, Check)

    End Sub

    Private Sub Close_ABM()
        oMainForm.ShowLeftPanel()

        oSocioABM.Dispose()
        oSocioABM = Nothing

        LoadData()
        Me.Visible = True
    End Sub
End Class
