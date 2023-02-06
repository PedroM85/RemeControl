﻿Public Class GastoABM
    Inherits ABMBase

    Private oDataLayer As GastoDataLayer
    Private focusedForeColor As Color = Color.Black
    Private focusedBackColor As Color = Color.Gainsboro

#Region "InitializeComponent"


    Friend WithEvents lblMonto As Label
    Friend WithEvents lblConcepto As Label
    Friend WithEvents lblMetPago As Label
    Friend WithEvents lblCuenta As Label
    Friend WithEvents lblName As Label
    Friend WithEvents lblFecha As Label
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents txtConcepto As TextBox
    Friend WithEvents cboMetPago As ComboBox
    Friend WithEvents cboCuenta As ComboBox
    Friend WithEvents cboNombre As ComboBox
    Friend WithEvents lblId As Label
    Friend WithEvents dtpFecha As DateTimePicker

    Private Sub InitializeComponent()
        Me.cboCuenta = New System.Windows.Forms.ComboBox()
        Me.cboMetPago = New System.Windows.Forms.ComboBox()
        Me.txtConcepto = New System.Windows.Forms.TextBox()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.lblMetPago = New System.Windows.Forms.Label()
        Me.lblConcepto = New System.Windows.Forms.Label()
        Me.lblMonto = New System.Windows.Forms.Label()
        Me.cboNombre = New System.Windows.Forms.ComboBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblId = New System.Windows.Forms.Label()
        Me.pnlControls0.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlControls0
        '
        Me.pnlControls0.Controls.Add(Me.lblId)
        Me.pnlControls0.Controls.Add(Me.dtpFecha)
        Me.pnlControls0.Controls.Add(Me.cboNombre)
        Me.pnlControls0.Controls.Add(Me.lblMonto)
        Me.pnlControls0.Controls.Add(Me.lblConcepto)
        Me.pnlControls0.Controls.Add(Me.lblMetPago)
        Me.pnlControls0.Controls.Add(Me.lblCuenta)
        Me.pnlControls0.Controls.Add(Me.lblName)
        Me.pnlControls0.Controls.Add(Me.lblFecha)
        Me.pnlControls0.Controls.Add(Me.txtMonto)
        Me.pnlControls0.Controls.Add(Me.txtConcepto)
        Me.pnlControls0.Controls.Add(Me.cboMetPago)
        Me.pnlControls0.Controls.Add(Me.cboCuenta)
        Me.pnlControls0.Size = New System.Drawing.Size(524, 205)
        '
        'cboCuenta
        '
        Me.cboCuenta.FormattingEnabled = True
        Me.cboCuenta.Location = New System.Drawing.Point(182, 80)
        Me.cboCuenta.Name = "cboCuenta"
        Me.cboCuenta.Size = New System.Drawing.Size(200, 21)
        Me.cboCuenta.TabIndex = 2
        '
        'cboMetPago
        '
        Me.cboMetPago.FormattingEnabled = True
        Me.cboMetPago.Location = New System.Drawing.Point(182, 107)
        Me.cboMetPago.Name = "cboMetPago"
        Me.cboMetPago.Size = New System.Drawing.Size(200, 21)
        Me.cboMetPago.TabIndex = 3
        '
        'txtConcepto
        '
        Me.txtConcepto.Location = New System.Drawing.Point(182, 134)
        Me.txtConcepto.Name = "txtConcepto"
        Me.txtConcepto.Size = New System.Drawing.Size(200, 20)
        Me.txtConcepto.TabIndex = 4
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(182, 160)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(200, 20)
        Me.txtMonto.TabIndex = 5
        Me.txtMonto.Text = "0.00"
        Me.txtMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(88, 34)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(40, 13)
        Me.lblFecha.TabIndex = 6
        Me.lblFecha.Text = "Fecha:"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(81, 61)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(47, 13)
        Me.lblName.TabIndex = 7
        Me.lblName.Text = "Nombre:"
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Location = New System.Drawing.Point(40, 88)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(88, 13)
        Me.lblCuenta.TabIndex = 8
        Me.lblCuenta.Text = "Cuenta bancaria:"
        '
        'lblMetPago
        '
        Me.lblMetPago.AutoSize = True
        Me.lblMetPago.Location = New System.Drawing.Point(40, 115)
        Me.lblMetPago.Name = "lblMetPago"
        Me.lblMetPago.Size = New System.Drawing.Size(88, 13)
        Me.lblMetPago.TabIndex = 9
        Me.lblMetPago.Text = "Método de pago:"
        '
        'lblConcepto
        '
        Me.lblConcepto.AutoSize = True
        Me.lblConcepto.Location = New System.Drawing.Point(72, 141)
        Me.lblConcepto.Name = "lblConcepto"
        Me.lblConcepto.Size = New System.Drawing.Size(56, 13)
        Me.lblConcepto.TabIndex = 10
        Me.lblConcepto.Text = "Concepto:"
        '
        'lblMonto
        '
        Me.lblMonto.AutoSize = True
        Me.lblMonto.Location = New System.Drawing.Point(88, 167)
        Me.lblMonto.Name = "lblMonto"
        Me.lblMonto.Size = New System.Drawing.Size(40, 13)
        Me.lblMonto.TabIndex = 11
        Me.lblMonto.Text = "Monto:"
        '
        'cboNombre
        '
        Me.cboNombre.FormattingEnabled = True
        Me.cboNombre.Location = New System.Drawing.Point(182, 54)
        Me.cboNombre.Name = "cboNombre"
        Me.cboNombre.Size = New System.Drawing.Size(200, 21)
        Me.cboNombre.TabIndex = 12
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(182, 27)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(200, 20)
        Me.dtpFecha.TabIndex = 13
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(403, 64)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(13, 13)
        Me.lblId.TabIndex = 14
        Me.lblId.Text = "0"
        '
        'GastoABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "GastoABM"
        Me.pnlControls0.ResumeLayout(False)
        Me.pnlControls0.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region
    Public Sub New()
        MyBase.New

        InitializeComponent()

        GetSocios()
        GetBancoSo()
        GetBancoType()

        Me.GetAllControls(Me).OfType(Of TextBox)().ToList() _
         .ForEach(Sub(b)
                      b.Tag = Tuple.Create(b.ForeColor, b.BackColor)
                      AddHandler b.GotFocus, AddressOf b_GotFocus
                      AddHandler b.LostFocus, AddressOf b_LostFocus
                  End Sub)
    End Sub



    Private Function GetAllControls(control As Control) As IEnumerable(Of Control)
        Dim controls = control.Controls.Cast(Of Control)()
        Return controls.SelectMany(Function(ctrl) GetAllControls(ctrl)).Concat(controls)
    End Function

    Private Sub b_LostFocus(sender As Object, e As EventArgs)
        Dim b = DirectCast(sender, TextBox)
        Dim colors = DirectCast(b.Tag, Tuple(Of Color, Color))
        b.ForeColor = colors.Item1
        b.BackColor = colors.Item2
    End Sub

    Private Sub b_GotFocus(sender As Object, e As EventArgs)
        Dim b = DirectCast(sender, TextBox)
        b.SelectAll()
        b.ForeColor = focusedForeColor
        b.BackColor = focusedBackColor
    End Sub
    Private Sub GastoABM_Save() Handles MyBase.Save
        Dim oData As GastoData

        oDataLayer = New GastoDataLayer

        Try

            oData = New GastoData With
                {
                .GAT_Id = IIf(IsAddNew, 0, lblId.Text),
                .GAT_Date = dtpFecha.Text,
                .GAT_SOC_Id = cboNombre.SelectedValue,
                .GAT_OSB_Id = cboCuenta.SelectedValue,
                .GAT_OSBT_Id = cboMetPago.SelectedValue,
                .GAT_Reason = txtConcepto.Text.Trim,
                .GAT_Amount = txtMonto.Text.Trim,
                .GAT_ModifiedBy = oApp.CurrentUser.USR_Id,
                .GAT_Active = 1'            
                }

            If IsAddNew Then
                oDataLayer.CreateGasto(oData)
            Else
                oDataLayer.UpdateGasto(oData)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub GastoABM_SetDefaultValuesOnEdit(row As DataRowView) Handles MyBase.SetDefaultValuesOnEdit
        'lblId.Visible = True
    End Sub

    Private Sub GastoABM_SetBindings(row As DataRowView) Handles MyBase.SetBindings
        'txtId.DataBindings.Add("Text", row, "CLI_Id")
        'lblId.DataBindings.Add("Text", row, "CLI_Id")
        'txtNombre.DataBindings.Add("Text", row, "CLI_Nombre")
        'txtCuenta.DataBindings.Add("Text", row, "CLI_Cuenta")
        'txtTitular.DataBindings.Add("Text", row, "CLI_Titular")
        'txtCedula.DataBindings.Add("Text", row, "CLI_Cedula")
        'chkActive.DataBindings.Add("Checked", row, "CLI_Active")
        'cboBanco.DataBindings.Add("SelectedValue", row, "CLI_Banco")
    End Sub
    Private Sub ValiText(sender As Object, e As KeyPressEventArgs)

        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub GetSocios()
        Dim oGastoData As GastoDataLayer = Nothing


        oGastoData = New GastoDataLayer

        cboNombre.DataSource = oGastoData.GetSocios
        Me.cboNombre.ValueMember = "SOC_Id"
        Me.cboNombre.DisplayMember = "SOC_Name"
        Me.cboNombre.DropDownStyle = ComboBoxStyle.DropDownList


    End Sub
    Private Sub GetBancoSo()
        Dim oBancoSoData As BancoSoDataLayer = Nothing


        oBancoSoData = New BancoSoDataLayer

        cboCuenta.DataSource = oBancoSoData.GetBancoSo
        Me.cboCuenta.ValueMember = "OSB_Id"
        Me.cboCuenta.DisplayMember = "OSB_Nombre"
        Me.cboCuenta.DropDownStyle = ComboBoxStyle.DropDownList


    End Sub

    Private Sub GetBancoType()
        Dim oBancoSoData As BancoSoDataLayer = Nothing


        oBancoSoData = New BancoSoDataLayer

        cboMetPago.DataSource = oBancoSoData.GetAcountType

        Me.cboMetPago.ValueMember = "OSBT_Id"
        Me.cboMetPago.DisplayMember = "OSBT_Nombre"
        Me.cboMetPago.DropDownStyle = ComboBoxStyle.DropDownList


    End Sub

    Private Sub txtMonto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtMonto.KeyPress
        ValiText(sender, e)
    End Sub
End Class
