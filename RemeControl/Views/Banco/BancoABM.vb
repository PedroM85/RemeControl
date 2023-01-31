Public Class BancoABM
    Inherits ABMBase

#Region "InitializeComponet"


    Friend WithEvents Label3 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPrefix As TextBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents cboBankAcc As ComboBox
    Friend WithEvents lblId As Label
    Friend WithEvents Label2 As Label

    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPrefix = New System.Windows.Forms.TextBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboBankAcc = New System.Windows.Forms.ComboBox()
        Me.lblId = New System.Windows.Forms.Label()
        Me.pnlControls0.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlControls0
        '
        Me.pnlControls0.Controls.Add(Me.lblId)
        Me.pnlControls0.Controls.Add(Me.cboBankAcc)
        Me.pnlControls0.Controls.Add(Me.Label2)
        Me.pnlControls0.Controls.Add(Me.Label6)
        Me.pnlControls0.Controls.Add(Me.chkActive)
        Me.pnlControls0.Controls.Add(Me.Label3)
        Me.pnlControls0.Controls.Add(Me.Label1)
        Me.pnlControls0.Controls.Add(Me.txtPrefix)
        Me.pnlControls0.Controls.Add(Me.txtNombre)
        Me.pnlControls0.Size = New System.Drawing.Size(524, 201)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(62, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 13)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Prefijo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(54, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Nombre:"
        '
        'txtPrefix
        '
        Me.txtPrefix.Location = New System.Drawing.Point(125, 109)
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Size = New System.Drawing.Size(121, 20)
        Me.txtPrefix.TabIndex = 3
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(125, 56)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(121, 20)
        Me.txtNombre.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(61, 142)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 18
        Me.Label6.Text = "Activo:"
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Checked = True
        Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActive.Location = New System.Drawing.Point(125, 141)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.Size = New System.Drawing.Size(15, 14)
        Me.chkActive.TabIndex = 4
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(70, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Tipo:"
        '
        'cboBankAcc
        '
        Me.cboBankAcc.DisplayMember = "BAN_ACC_Name"
        Me.cboBankAcc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBankAcc.FormattingEnabled = True
        Me.cboBankAcc.Location = New System.Drawing.Point(125, 82)
        Me.cboBankAcc.Name = "cboBankAcc"
        Me.cboBankAcc.Size = New System.Drawing.Size(121, 21)
        Me.cboBankAcc.TabIndex = 2
        Me.cboBankAcc.ValueMember = "BAN_ACC_Name"
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.ForeColor = System.Drawing.Color.White
        Me.lblId.Location = New System.Drawing.Point(197, 28)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(13, 13)
        Me.lblId.TabIndex = 20
        Me.lblId.Text = "0"
        '
        'BancoABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "BancoABM"
        Me.pnlControls0.ResumeLayout(False)
        Me.pnlControls0.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private oDataLayer As BancoDataLayer
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

    Private focusedForeColor As Color = Color.Black
    Private focusedBackColor As Color = Color.Gainsboro

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
    Private Sub BancoABM_Save() Handles MyBase.Save
        Dim oData As BancoData

        oDataLayer = New BancoDataLayer

        Try
            'MessageBox.Show(txtId.Text)
            If lblId.Text = Nothing Or lblId.Text = "" Then
                lblId.Text = Nothing
            End If

            oData = New BancoData With
                {
               .BAN_Id = IIf(IsAddNew, 0, lblId.Text),
               .BAN_Type = cboBankAcc.SelectedIndex + 1,
               .BAN_Name = txtNombre.Text.Trim,
               .BAN_Prefix = txtPrefix.Text.Trim,
               .BAN_ModifiedBy = oApp.CurrentUser.USR_Id,
               .BAN_Active = IIf(chkActive.CheckState, 1, 0)
                }

            If IsAddNew Then
                oDataLayer.CreateBanco(oData)
            Else
                oDataLayer.UpdateBanco(oData)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub BancoABM_SetDefaultValuesOnEdit(row As DataRowView) Handles MyBase.SetDefaultValuesOnEdit
        lblId.Enabled = True
    End Sub
    'Private Sub BancoABM_SetDefaultValuesOnAdd(row As DataRowView) Handles MyBase.SetDefaultValuesOnNew
    '    row("SOC_Id") = 0
    '    'row("SOC_Name") = not
    '    'row("SOC_Telefono") = ""
    '    'row("SOC_Active") = True
    'End Sub
    Private Sub BancoABM_SetBindings(row As DataRowView) Handles MyBase.SetBindings
        lblId.DataBindings.Add("Text", row, "BAN_Id")
        txtNombre.DataBindings.Add("Text", row, "BAN_Name")
        txtPrefix.DataBindings.Add("Text", row, "BAN_Prefix")
        chkActive.DataBindings.Add("Checked", row, "BAN_Active")
        cboBankAcc.DataBindings.Add("SelectedValue", row, "BAN_ACC_Name")
    End Sub
    Private Sub ValiText(sender As Object, e As KeyPressEventArgs)

        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub GetBancos()
        Dim oBancoData As BancoDataLayer = Nothing

        oBancoData = New BancoDataLayer

        cboBankAcc.DataSource = oBancoData.GetAcountType
    End Sub


    Private Sub txtPrefix_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrefix.KeyPress
        ValiText(sender, e)
    End Sub
End Class
