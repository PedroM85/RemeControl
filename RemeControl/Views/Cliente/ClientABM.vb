Public Class ClientABM
    Inherits ABMBase

#Region "Component"
    Private Sub InitializeComponent()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.cboBanco = New System.Windows.Forms.ComboBox()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.txtTitular = New System.Windows.Forms.TextBox()
        Me.txtCedula = New System.Windows.Forms.TextBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.pnlControls0.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlControls0
        '
        Me.pnlControls0.Controls.Add(Me.lblId)
        Me.pnlControls0.Controls.Add(Me.Label6)
        Me.pnlControls0.Controls.Add(Me.Label5)
        Me.pnlControls0.Controls.Add(Me.Label4)
        Me.pnlControls0.Controls.Add(Me.Label3)
        Me.pnlControls0.Controls.Add(Me.Label2)
        Me.pnlControls0.Controls.Add(Me.Label1)
        Me.pnlControls0.Controls.Add(Me.chkActive)
        Me.pnlControls0.Controls.Add(Me.txtCedula)
        Me.pnlControls0.Controls.Add(Me.txtTitular)
        Me.pnlControls0.Controls.Add(Me.txtCuenta)
        Me.pnlControls0.Controls.Add(Me.cboBanco)
        Me.pnlControls0.Controls.Add(Me.txtNombre)
        Me.pnlControls0.Size = New System.Drawing.Size(524, 225)
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(138, 55)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(169, 20)
        Me.txtNombre.TabIndex = 1
        '
        'cboBanco
        '
        Me.cboBanco.DisplayMember = "Banco"
        Me.cboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBanco.FormattingEnabled = True
        Me.cboBanco.Location = New System.Drawing.Point(138, 81)
        Me.cboBanco.Name = "cboBanco"
        Me.cboBanco.Size = New System.Drawing.Size(169, 21)
        Me.cboBanco.TabIndex = 2
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(138, 108)
        Me.txtCuenta.MaxLength = 24
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(169, 20)
        Me.txtCuenta.TabIndex = 3
        '
        'txtTitular
        '
        Me.txtTitular.Location = New System.Drawing.Point(138, 134)
        Me.txtTitular.MaxLength = 50
        Me.txtTitular.Name = "txtTitular"
        Me.txtTitular.Size = New System.Drawing.Size(169, 20)
        Me.txtTitular.TabIndex = 4
        '
        'txtCedula
        '
        Me.txtCedula.Location = New System.Drawing.Point(138, 160)
        Me.txtCedula.MaxLength = 10
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(169, 20)
        Me.txtCedula.TabIndex = 5
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Checked = True
        Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActive.Location = New System.Drawing.Point(138, 193)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(15, 14)
        Me.chkActive.TabIndex = 6
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Nombre:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(43, 89)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Banco:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(40, 115)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Cuenta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 141)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Titular:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(41, 167)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Cedula:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(44, 194)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Activo:"
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.Location = New System.Drawing.Point(260, 36)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(31, 13)
        Me.lblId.TabIndex = 13
        Me.lblId.Text = "????"
        Me.lblId.Visible = False
        '
        'ClientABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "ClientABM"
        Me.pnlControls0.ResumeLayout(False)
        Me.pnlControls0.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents txtCedula As TextBox
    Friend WithEvents txtTitular As TextBox
    Friend WithEvents txtCuenta As TextBox
    Friend WithEvents cboBanco As ComboBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Private focusedForeColor As Color = Color.Black
    Private focusedBackColor As Color = Color.Gainsboro
    Friend WithEvents lblId As Label
#End Region

    Private oDataLayer As ClienteDataLayer
    Private oBsource As BindingSource
    Private FuntionCon As New CommonFunction
    Public Sub New()
        MyBase.New

        InitializeComponent()

        GetBancos()

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
    Private Sub ClientABM_Save() Handles MyBase.Save
        Dim oData As ClienteData

        oDataLayer = New ClienteDataLayer

        Try

            oData = New ClienteData With
                {
                .CLI_Id = IIf(IsAddNew, 0, lblId.Text),
                .CLI_Nombre = txtNombre.Text.Trim,
                .CLI_Banco = cboBanco.SelectedValue,
                .CLI_Cuenta = txtCuenta.Text.Trim,
                .CLI_Titular = txtTitular.Text.Trim,
                .CLI_Cedula = txtCedula.Text.Trim,
                .CLI_ModifiedBy = oApp.CurrentUser.USR_Id,
                .CLI_Active = IIf(chkActive.CheckState, 1, 0)
                }


            If IsAddNew Then
                oDataLayer.CreateCliente(oData)
            Else
                oDataLayer.UpdateCliente(oData)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub ClientABM_SetDefaultValuesOnEdit(row As DataRowView) Handles MyBase.SetDefaultValuesOnEdit
        lblId.Visible = True
    End Sub
    Private Sub ClientABM_ValidateControls(ByRef Cancel As Boolean, IsAddNew As Boolean) Handles MyBase.ValidateControls
        Dim sErrorMsg As String = "Este campo es requerido"

        If txtNombre.Text = String.Empty Then
            MessageBox.Show(sErrorMsg, Me.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cancel = True
            txtNombre.Select()
            Exit Sub
        End If
        If txtCuenta.Text = String.Empty Then
            MessageBox.Show(sErrorMsg, Me.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cancel = True
            txtCuenta.Select()
            Exit Sub
        End If
        If txtTitular.Text = String.Empty Then
            MessageBox.Show(sErrorMsg, Me.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cancel = True
            txtTitular.Select()
            Exit Sub
        End If
        If txtCedula.Text = String.Empty Then
            MessageBox.Show(sErrorMsg, Me.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cancel = True
            txtCedula.Select()
            Exit Sub
        End If
    End Sub
    Private Sub ClientABM_SetBindings(row As DataRowView) Handles MyBase.SetBindings

        lblId.DataBindings.Add("Text", row, "CLI_Id")
        txtNombre.DataBindings.Add("Text", row, "CLI_Nombre")
        txtCuenta.DataBindings.Add("Text", row, "CLI_Cuenta")
        txtTitular.DataBindings.Add("Text", row, "CLI_Titular")
        txtCedula.DataBindings.Add("Text", row, "CLI_Cedula")
        chkActive.DataBindings.Add("Checked", row, "CLI_Active")
        cboBanco.DataBindings.Add("SelectedValue", row, "CLI_Banco")
    End Sub
   
    Private Sub GetBancos()
        Dim oBancoData As BancoDataLayer = Nothing
        oBancoData = New BancoDataLayer

        oBsource = New BindingSource

        oBsource.DataSource = oBancoData.GetAcount

        If oBsource.List.Item(0).Row.ItemArray(0) = -1 Then
            cboBanco.Items.Add("No hay registros previos")
        Else
            cboBanco.DataSource = oBsource.DataSource
            Me.cboBanco.ValueMember = "BAN_Id"
            Me.cboBanco.DisplayMember = "BAN_Name"
        End If


    End Sub
    Private Sub txtCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCuenta.KeyPress
        FuntionCon.ValiText(sender, e)
    End Sub
End Class
