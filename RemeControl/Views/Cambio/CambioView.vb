Public Class CambioView
    Inherits ViewBase

    Private WithEvents Label1 As Label
    Private WithEvents oCambioABM As CambioABM
    Private oBsource As BindingSource
    Public Sub New()
        MyBase.New

        InitializeComponent()

        LoadGlobalCaptions()

    End Sub

    Public Sub LoadData()
        Dim oCambioData As New CambioDataLayer

        oBsource = New BindingSource With {
            .DataSource = oCambioData.GetTasas
        }

        Dim OBsource1 = New BindingSource With {
            .DataSource = oCambioData.GetCambios
        }


        dgvView.DataSource = Nothing

        Try
            If oBsource.Item(0).Row.ItemArray(0) = -9999 Then
                MessageBox.Show("Debe crear una tasa para continuar!", "Unelsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
                oMainForm.FlagRed = True
            End If

            If OBsource1.DataSource Is Nothing Then
                Label1.Visible = True
            Else
                Label1.Visible = False
                With dgvView
                    .DataSource = Nothing
                    .DataSource = OBsource1.DataSource
                End With
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub CambioView_Addnew() Handles MyBase.AddNew

        Cursor = Cursors.WaitCursor
        If oApp.IsSaleDateOpened Then

            oCambioABM = New CambioABM With {
        .Caption = "Agregar un cambio",
        .Title = "Datos Generales"
        }
            'oClientABM.chkActive.Checked = True
            oCambioABM.Edit(Nothing)

            Me.Visible = False
            oCambioABM.Dock = DockStyle.Fill
            oMainForm.ShowView(oCambioABM)
            oMainForm.HideLeftPanel()


            oCambioABM.Select()
        End If

        Cursor = Cursors.Arrow
    End Sub

    Public Sub CambioView_Edit() Handles MyBase.Edit
        Cursor = Cursors.WaitCursor

        oCambioABM = New CambioABM With {
            .Caption = "Editar una cambio",
            .Title = "Datos Generales"
        }
        Dim row As DataGridViewRow = dgvView.CurrentRow
        oCambioABM.Edit(DirectCast(row.DataBoundItem, DataRowView))

        Me.Visible = False
        oCambioABM.Dock = DockStyle.Fill
        oMainForm.ShowView(oCambioABM)
        oMainForm.HideLeftPanel()

        oCambioABM.Select()

        Cursor = Cursors.Arrow
    End Sub

    Private Sub oCambioABM_Delete() Handles MyBase.Delete
        Dim oDataLayer As New CambioDataLayer
        Cursor = Cursors.WaitCursor
        If dgvView.RowCount > 0 Then
            If MessageBox.Show("Desea eliminar " & " '" & Trim(dgvView.CurrentRow.Cells(1).Value) & "'?", Me.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                Try

                    Dim Data As CambioDataLayer = New CambioDataLayer With
                    {
                        .OP_Id = dgvView.CurrentRow.Cells(0).Value,
                        .OP_ModifiedBy = oApp.CurrentUser.USR_Id
                    }

                    oDataLayer.DeleteCambio(Data)
                Catch ex As Exception

                End Try
            End If
        End If

        LoadData()
        Cursor = Cursors.Arrow
    End Sub

    Private Sub oCambioABM_Close() Handles oCambioABM.Close
        Close_ABM()
    End Sub
    Private Sub oCambioABM_Save() Handles oCambioABM.Save
        Close_ABM()
    End Sub
    Public Sub LoadGlobalCaptions()
        dgvView.AutoGenerateColumns = False
        dgvView.ColumnCount = 18

        dgvView.Columns(0).Name = "OP_Id"
        dgvView.Columns(0).HeaderText = "Codigo"
        dgvView.Columns(0).DataPropertyName = "OP_Id"
        dgvView.Columns(0).Width = 100
        dgvView.Columns(0).Visible = False

        dgvView.Columns(1).Name = "OP_Date"
        dgvView.Columns(1).HeaderText = "Fecha"
        dgvView.Columns(1).DataPropertyName = "OP_Date"
        dgvView.Columns(1).Width = 120



        dgvView.Columns(2).Name = "OP_Socio"
        dgvView.Columns(2).HeaderText = "Socio"
        dgvView.Columns(2).DataPropertyName = "OP_Socio"
        dgvView.Columns(2).Width = 150
        dgvView.Columns(2).Visible = False
        'dgvView.Columns(1).DefaultCellStyle.Format = "d"
        'dgvView.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        dgvView.Columns(3).Name = "SOC_Name"
        dgvView.Columns(3).HeaderText = "Cliente"
        dgvView.Columns(3).DataPropertyName = "SOC_Name"
        dgvView.Columns(3).Width = 150

        dgvView.Columns(4).Name = "OP_Cliente"
        dgvView.Columns(4).HeaderText = "Cliente"
        dgvView.Columns(4).DataPropertyName = "OP_Cliente"
        dgvView.Columns(4).Width = 150
        dgvView.Columns(4).Visible = False

        dgvView.Columns(5).Name = "CLI_Nombre"
        dgvView.Columns(5).HeaderText = "Cliente"
        dgvView.Columns(5).DataPropertyName = "CLI_Nombre"
        dgvView.Columns(5).Width = 150

        dgvView.Columns(6).Name = "OP_Pesos"
        dgvView.Columns(6).HeaderText = "Envian"
        dgvView.Columns(6).DataPropertyName = "OP_Pesos"
        dgvView.Columns(6).Width = 120
        dgvView.Columns(6).DefaultCellStyle.Format = "{0:N2}"
        dgvView.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvView.Columns(7).Name = "OP_Tasa_id"
        dgvView.Columns(7).HeaderText = "Tasa"
        dgvView.Columns(7).DataPropertyName = "OP_Tasa_id"
        dgvView.Columns(7).Width = 120
        dgvView.Columns(7).Visible = False

        dgvView.Columns(8).Name = "TAS_TasaCliente"
        dgvView.Columns(8).HeaderText = "Tasa"
        dgvView.Columns(8).DataPropertyName = "TAS_TasaCliente"
        dgvView.Columns(8).Width = 150
        dgvView.Columns(8).DefaultCellStyle.Format = "{0:N2}"
        dgvView.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvView.Columns(9).Name = "OP_USTDBUY"
        dgvView.Columns(9).HeaderText = "USTD comprado"
        dgvView.Columns(9).DataPropertyName = "OP_USTDBUY"
        dgvView.Columns(9).Width = 150
        dgvView.Columns(9).DefaultCellStyle.Format = "{0:N2}"
        dgvView.Columns(9).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvView.Columns(10).Name = "OP_USTDSELL"
        dgvView.Columns(10).HeaderText = "USTD vendido"
        dgvView.Columns(10).DataPropertyName = "OP_USTDSELL"
        dgvView.Columns(10).Width = 150
        dgvView.Columns(10).DefaultCellStyle.Format = "{0:N2}"
        dgvView.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvView.Columns(11).Name = "OP_Resta"
        dgvView.Columns(11).HeaderText = "Ganacia"
        dgvView.Columns(11).DataPropertyName = "OP_Resta"
        dgvView.Columns(11).Width = 150
        dgvView.Columns(11).DefaultCellStyle.Format = "{0:N2}"
        dgvView.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        dgvView.Columns(12).Name = "OP_Status_Id"
        dgvView.Columns(12).HeaderText = "Estado"
        dgvView.Columns(12).DataPropertyName = "OP_Status_Id"
        dgvView.Columns(12).Width = 150
        dgvView.Columns(12).Visible = False

        dgvView.Columns(13).Name = "STA_Name"
        dgvView.Columns(13).HeaderText = "Cliente"
        dgvView.Columns(13).DataPropertyName = "STA_Name"
        dgvView.Columns(13).Width = 150

        dgvView.Columns(14).Name = "OP_Operation"
        dgvView.Columns(14).HeaderText = "Mensaje"
        dgvView.Columns(14).DataPropertyName = "OP_Operation"
        dgvView.Columns(14).Width = 150

        dgvView.Columns(15).Name = "OP_CreatedDateTime"
        dgvView.Columns(15).HeaderText = "Fecha de alta"
        dgvView.Columns(15).DataPropertyName = "OP_CreatedDateTime"
        dgvView.Columns(15).Width = 120
        dgvView.Columns(15).Visible = False

        dgvView.Columns(16).Name = "OP_ModifiedDateTime"
        dgvView.Columns(16).HeaderText = "Fecha de modificacion"
        dgvView.Columns(16).DataPropertyName = "OP_ModifiedDateTime"
        dgvView.Columns(16).Width = 100
        dgvView.Columns(16).Visible = False

        dgvView.Columns(17).Name = "OP_ModifiedBy"
        dgvView.Columns(17).HeaderText = "Modificado por"
        dgvView.Columns(17).DataPropertyName = "OP_ModifiedBy"
        dgvView.Columns(17).Width = 120
        dgvView.Columns(17).Visible = False


        Dim Check As New DataGridViewCheckBoxColumn
        Check.Name = "OP_Active"
        Check.HeaderText = "Activo"
        Check.DataPropertyName = "OP_Active"
        dgvView.Columns.Insert(18, Check)

    End Sub

    Private Sub Close_ABM() 'Handles oCambioABM.Close
        oMainForm.ShowLeftPanel()

        oMainForm.ExitView(oCambioABM)
        oCambioABM.Dispose()
        oCambioABM = Nothing

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
        Me.Label1.Location = New System.Drawing.Point(307, 255)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 24)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "No hay registros"
        Me.Label1.Visible = False
        '
        'CambioView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Label1)
        Me.Name = "CambioView"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
End Class
