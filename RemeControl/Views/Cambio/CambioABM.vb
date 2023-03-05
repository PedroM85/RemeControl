Imports System.Text

Public Class CambioABM
    Inherits ABMBase


    Private oDataLayer As CambioDataLayer
    Private ReadOnly focusedForeColor As Color = Color.Black
    Friend WithEvents lblId As Label
    Private ReadOnly components As System.ComponentModel.IContainer
    Friend WithEvents Label8 As Label
    Friend WithEvents cboBanco As ComboBox
    Private ReadOnly focusedBackColor As Color = Color.Gainsboro


    Private tasa As String = "0"
    Private Ope As Double
    Private Banco As String
    Private Titular As String
    Private Cuenta As String
    Private Cedula As String


#Region "Initialize Component"



    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboStatus As ComboBox
    Friend WithEvents txtUSTDSell As TextBox
    Friend WithEvents txtUSTDBuy As TextBox
    Friend WithEvents cboTasa As ComboBox
    Friend WithEvents txtPesos As TextBox
    Friend WithEvents cboCliente As ComboBox
    Friend WithEvents cboSocio As ComboBox
    Friend WithEvents lblOperacion As Label


    Private Sub InitializeComponent()
        Me.cboSocio = New System.Windows.Forms.ComboBox()
        Me.cboCliente = New System.Windows.Forms.ComboBox()
        Me.txtPesos = New System.Windows.Forms.TextBox()
        Me.cboTasa = New System.Windows.Forms.ComboBox()
        Me.txtUSTDBuy = New System.Windows.Forms.TextBox()
        Me.txtUSTDSell = New System.Windows.Forms.TextBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.lblOperacion = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboBanco = New System.Windows.Forms.ComboBox()
        Me.pnlControls0.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlControls0
        '
        Me.pnlControls0.Controls.Add(Me.Label8)
        Me.pnlControls0.Controls.Add(Me.cboBanco)
        Me.pnlControls0.Controls.Add(Me.lblId)
        Me.pnlControls0.Controls.Add(Me.lblOperacion)
        Me.pnlControls0.Controls.Add(Me.Label7)
        Me.pnlControls0.Controls.Add(Me.Label6)
        Me.pnlControls0.Controls.Add(Me.Label5)
        Me.pnlControls0.Controls.Add(Me.Label4)
        Me.pnlControls0.Controls.Add(Me.Label3)
        Me.pnlControls0.Controls.Add(Me.Label2)
        Me.pnlControls0.Controls.Add(Me.Label1)
        Me.pnlControls0.Controls.Add(Me.txtPesos)
        Me.pnlControls0.Controls.Add(Me.cboStatus)
        Me.pnlControls0.Controls.Add(Me.txtUSTDSell)
        Me.pnlControls0.Controls.Add(Me.txtUSTDBuy)
        Me.pnlControls0.Controls.Add(Me.cboTasa)
        Me.pnlControls0.Controls.Add(Me.cboCliente)
        Me.pnlControls0.Controls.Add(Me.cboSocio)
        Me.pnlControls0.Size = New System.Drawing.Size(524, 251)
        '
        'cboSocio
        '
        Me.cboSocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSocio.FormattingEnabled = True
        Me.cboSocio.Location = New System.Drawing.Point(68, 31)
        Me.cboSocio.Name = "cboSocio"
        Me.cboSocio.Size = New System.Drawing.Size(152, 21)
        Me.cboSocio.TabIndex = 0
        '
        'cboCliente
        '
        Me.cboCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCliente.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cboCliente.FormattingEnabled = True
        Me.cboCliente.Location = New System.Drawing.Point(68, 58)
        Me.cboCliente.Name = "cboCliente"
        Me.cboCliente.Size = New System.Drawing.Size(152, 21)
        Me.cboCliente.TabIndex = 1
        '
        'txtPesos
        '
        Me.txtPesos.Location = New System.Drawing.Point(68, 112)
        Me.txtPesos.Name = "txtPesos"
        Me.txtPesos.Size = New System.Drawing.Size(152, 20)
        Me.txtPesos.TabIndex = 3
        Me.txtPesos.Text = "0"
        Me.txtPesos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboTasa
        '
        Me.cboTasa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTasa.FormattingEnabled = True
        Me.cboTasa.Location = New System.Drawing.Point(68, 85)
        Me.cboTasa.Name = "cboTasa"
        Me.cboTasa.Size = New System.Drawing.Size(152, 21)
        Me.cboTasa.TabIndex = 2
        '
        'txtUSTDBuy
        '
        Me.txtUSTDBuy.Location = New System.Drawing.Point(359, 59)
        Me.txtUSTDBuy.Name = "txtUSTDBuy"
        Me.txtUSTDBuy.Size = New System.Drawing.Size(152, 20)
        Me.txtUSTDBuy.TabIndex = 4
        Me.txtUSTDBuy.Text = "0"
        Me.txtUSTDBuy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtUSTDSell
        '
        Me.txtUSTDSell.Location = New System.Drawing.Point(359, 85)
        Me.txtUSTDSell.Name = "txtUSTDSell"
        Me.txtUSTDSell.Size = New System.Drawing.Size(152, 20)
        Me.txtUSTDSell.TabIndex = 5
        Me.txtUSTDSell.Text = "0"
        Me.txtUSTDSell.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(359, 111)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(152, 21)
        Me.cboStatus.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Socio:*"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Cliente:*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Pesos:*"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 93)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Tasa:*"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(259, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "USTD comprado:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(263, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(86, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "USTD vendidos:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(309, 119)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Status:*"
        '
        'lblOperacion
        '
        Me.lblOperacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblOperacion.Location = New System.Drawing.Point(224, 137)
        Me.lblOperacion.Name = "lblOperacion"
        Me.lblOperacion.Size = New System.Drawing.Size(287, 105)
        Me.lblOperacion.TabIndex = 14
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(207, 13)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(13, 13)
        Me.lblId.TabIndex = 15
        Me.lblId.Text = "0"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(304, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(45, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Banco:*"
        '
        'cboBanco
        '
        Me.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBanco.FormattingEnabled = True
        Me.cboBanco.Location = New System.Drawing.Point(359, 31)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(152, 21)
        Me.cboBanco.TabIndex = 16
        '
        'CambioABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "CambioABM"
        Me.pnlControls0.ResumeLayout(False)
        Me.pnlControls0.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Public Sub New()
        MyBase.New

        InitializeComponent()

        CargaCBO()

        Me.GetAllControls(Me).OfType(Of TextBox)().ToList() _
    .ForEach(Sub(b)
                 b.Tag = Tuple.Create(b.ForeColor, b.BackColor)
                 AddHandler b.GotFocus, AddressOf B_GotFocus
                 AddHandler b.LostFocus, AddressOf B_LostFocus
             End Sub)
    End Sub

    Private Function GetAllControls(control As Control) As IEnumerable(Of Control)
        Dim controls = control.Controls.Cast(Of Control)()
        Return controls.SelectMany(Function(ctrl) GetAllControls(ctrl)).Concat(controls)
    End Function

    Private Sub B_LostFocus(sender As Object, e As EventArgs)
        Dim b = DirectCast(sender, TextBox)
        Dim colors = DirectCast(b.Tag, Tuple(Of Color, Color))
        b.ForeColor = colors.Item1
        b.BackColor = colors.Item2
    End Sub

    Private Sub B_GotFocus(sender As Object, e As EventArgs)
        Dim b = DirectCast(sender, TextBox)
        b.SelectAll()
        b.ForeColor = focusedForeColor
        b.BackColor = focusedBackColor
    End Sub
    Private Sub CAmbioABM_Save() Handles MyBase.Save
        Dim oData As CambioData
        oDataLayer = New CambioDataLayer

        Try
            oData = New CambioData With
                {
                .OP_Id = IIf(IsAddNew, 0, lblId.Text),
                .OP_Socio = cboSocio.SelectedValue,
                .OP_Cliente = cboCliente.SelectedValue,
                .OP_Pesos = txtPesos.Text.Trim,
                .OP_Bank_Id = DirectCast(cboBanco.SelectedItem, System.Data.DataRowView).Row.ItemArray(0),'cboTasa.SelectedValue,
                .OP_Tasa_id = DirectCast(cboTasa.SelectedItem, System.Data.DataRowView).Row.ItemArray(0),'cboTasa.SelectedValue,
                .OP_USTDBuy = txtUSTDBuy.Text.Trim,
                .OP_USTDSell = txtUSTDSell.Text.Trim,
                .OP_Status_Id = cboStatus.SelectedValue,
                .OP_Operation = lblOperacion.Text.Trim,
                .OP_Session = oApp.GetSalesDateInfo.SSS_Id,
                .OP_ModifiedBy = oApp.CurrentUser.USR_Id,
                .OP_Active = 1
                }

            If IsAddNew Then
                oDataLayer.CreateCambio(oData)
            Else
                oDataLayer.UpdateCambio(oData)
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub CambioABM_SetDefaultValuesOnEdit(row As DataRowView) Handles MyBase.SetDefaultValuesOnEdit
        lblId.Enabled = True
    End Sub

    Private Sub CambioABM_SetBindings(row As DataRowView) Handles MyBase.SetBindings
        lblId.DataBindings.Add("Text", row, "OP_Id")
        cboSocio.DataBindings.Add("SelectedValue", row, "OP_Socio")
        cboCliente.DataBindings.Add("SelectedValue", row, "OP_Cliente")
        cboTasa.DataBindings.Add("SelectedValue", row, "TAS_TasaCliente")
        txtPesos.DataBindings.Add("Text", row, "OP_Pesos")
        txtUSTDBuy.DataBindings.Add("Text", row, "OP_USTDBuy")
        txtUSTDSell.DataBindings.Add("Text", row, "OP_USTDSell")
        cboStatus.DataBindings.Add("SelectedValue", row, "OP_Status_Id")
        lblOperacion.DataBindings.Add("Text", row, "OP_Operation")
    End Sub
    Private Sub CargaCBO()
        Dim oCambioData As New CambioDataLayer
        Dim oBancosoData As New BancoSoDataLayer

        Dim Tasas As New BindingSource
        Dim BancoSo As New BindingSource

        cboSocio.DataSource = oCambioData.GetSocios
        cboSocio.ValueMember = "SOC_Id"
        cboSocio.DisplayMember = "SOC_Name"


        cboCliente.DataSource = oCambioData.GetClientes
        cboCliente.ValueMember = "CLI_Id"
        cboCliente.DisplayMember = "CLI_Nombre"


        Tasas.DataSource = oCambioData.GetTasas

        If Tasas.Item(0).Row.ItemArray(0) = -9999 Then

        Else
            cboTasa.DataSource = Tasas.DataSource
            cboTasa.ValueMember = "TAS_TasaCliente"
            cboTasa.DisplayMember = "TAS_TasaCli"
            tasa = cboTasa.SelectedValue

        End If

        cboStatus.DataSource = oCambioData.GetStatus
        cboStatus.ValueMember = "STA_Id"
        cboStatus.DisplayMember = "STA_Name"

        BancoSo.DataSource = oBancosoData.GetBancoSo
        If BancoSo.Item(0).Row.ItemArray(0) = -1 Then
            With cboBanco
                .Items.Add("No hay registro")
            End With
        Else
            With cboBanco
                .DataSource = BancoSo.DataSource
                .ValueMember = "OSB_Id"
                .DisplayMember = "OSB_Nombre"
            End With
        End If



    End Sub

    Private Sub txtPesos_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPesos.KeyPress
        BoxValidate.ValiText(sender, e)
    End Sub

    Private Sub GeneralText()
        Dim sb As New StringBuilder()
        Dim pesos As Decimal = 0

        If Not String.IsNullOrEmpty(txtPesos.Text) Then
            pesos = txtPesos.Text
        End If

        If Not cboTasa.SelectedItem Is Nothing Then
            tasa = DirectCast(cboTasa.Items(cboTasa.SelectedIndex), System.Data.DataRowView).Row.ItemArray(2)
        End If

        Ope = pesos * tasa

        If Not Ope = 0 Then
            Banco = DirectCast(cboCliente.Items(cboCliente.SelectedIndex), System.Data.DataRowView).Row.ItemArray(3)
            Titular = DirectCast(cboCliente.Items(cboCliente.SelectedIndex), System.Data.DataRowView).Row.ItemArray(5)
            Cuenta = DirectCast(cboCliente.Items(cboCliente.SelectedIndex), System.Data.DataRowView).Row.ItemArray(4)
            Cedula = DirectCast(cboCliente.Items(cboCliente.SelectedIndex), System.Data.DataRowView).Row.ItemArray(6)
            lblOperacion.BackColor = Color.White
            'lblOperacion.Text = String.Format("Pagomovil o Transferencia  " & vbCrLf & "Banco: {0} " & vbCrLf & "Tipo de cuenta: {1} " & vbCrLf & "Numero de cuenta: {2} " & vbCrLf & "Titular: {3} " & vbCrLf & "Cedula: {4} " & vbCrLf & "monto a transferir: {5}", Banco, 0, Cuenta, Titular, Cedula, Ope.ToString("n2"))
            sb.Append("Pago móvil o Transferencia").AppendLine() _
            .Append(String.Format("Banco: {0}", Banco)).AppendLine() _
            .Append(String.Format("Tipo de cuenta: {0}", 0)).AppendLine() _
            .Append(String.Format("Número de cuenta: {0}", Cuenta)).AppendLine() _
            .Append(String.Format("Titular: {0}", Titular)).AppendLine() _
            .Append(String.Format("Cédula: {0}", Cedula)).AppendLine() _
            .Append(String.Format("Monto a transferir: {0:n2}", Ope))

            lblOperacion.Text = sb.ToString()
        End If
    End Sub

    Private Sub txtUSTDBuy_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUSTDBuy.KeyPress
        BoxValidate.ValiText(sender, e)
    End Sub

    Private Sub txtUSTDSell_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUSTDSell.KeyPress
        BoxValidate.ValiText(sender, e)
    End Sub

    Private Sub lblOperacion_Click(sender As Object, e As EventArgs) Handles lblOperacion.Click
        If Not String.IsNullOrEmpty(lblOperacion.Text) Then
            Clipboard.SetText(lblOperacion.Text.Trim)
        End If
    End Sub

    Private Sub txtPesos_TextChanged(sender As Object, e As EventArgs) Handles txtPesos.TextChanged

        GeneralText()
    End Sub
    Private Sub cboCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCliente.SelectedIndexChanged

        GeneralText()

    End Sub

    Private Sub cboTasa_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboTasa.SelectedIndexChanged

        GeneralText()

    End Sub

    Private Sub CambioABM_ValidateControls(ByRef Cancel As Boolean, IsNewAdd As Boolean) Handles MyBase.ValidateControls
        Dim sErrorMsg As String = "Este campo es requerido"

        If txtPesos.Text = String.Empty Or txtPesos.Text = 0 Or txtPesos.Text = 0.00 Then
            MessageBox.Show(sErrorMsg, Me.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cancel = True
            txtPesos.Select()
            Exit Sub
        End If
    End Sub

End Class
