Public Class BancoSoABM
    Inherits ABMBase

#Region "InitializeComponent"



    Private Sub InitializeComponent()
        Me.txtNombreAcc = New System.Windows.Forms.TextBox()
        Me.cboBankType = New System.Windows.Forms.ComboBox()
        Me.txtAccountNumber = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtpBeginninDate = New System.Windows.Forms.DateTimePicker()
        Me.txtInitialBalance = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.pnlControls0.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlControls0
        '
        Me.pnlControls0.Controls.Add(Me.lblId)
        Me.pnlControls0.Controls.Add(Me.Label4)
        Me.pnlControls0.Controls.Add(Me.Label3)
        Me.pnlControls0.Controls.Add(Me.Label2)
        Me.pnlControls0.Controls.Add(Me.txtAccountNumber)
        Me.pnlControls0.Controls.Add(Me.cboBankType)
        Me.pnlControls0.Controls.Add(Me.txtNombreAcc)
        Me.pnlControls0.Size = New System.Drawing.Size(524, 103)
        Me.pnlControls0.TabIndex = 0
        '
        'txtNombreAcc
        '
        Me.txtNombreAcc.Location = New System.Drawing.Point(131, 18)
        Me.txtNombreAcc.Name = "txtNombreAcc"
        Me.txtNombreAcc.Size = New System.Drawing.Size(121, 20)
        Me.txtNombreAcc.TabIndex = 1
        '
        'cboBankType
        '
        Me.cboBankType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBankType.FormattingEnabled = True
        Me.cboBankType.Location = New System.Drawing.Point(375, 17)
        Me.cboBankType.Name = "cboBankType"
        Me.cboBankType.Size = New System.Drawing.Size(121, 21)
        Me.cboBankType.TabIndex = 2
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.Location = New System.Drawing.Point(130, 55)
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.Size = New System.Drawing.Size(238, 20)
        Me.txtAccountNumber.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtDescription)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.dtpBeginninDate)
        Me.Panel1.Controls.Add(Me.txtInitialBalance)
        Me.Panel1.Location = New System.Drawing.Point(193, 198)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(524, 127)
        Me.Panel1.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(59, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 13)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Descripción:"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(131, 67)
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(238, 20)
        Me.txtDescription.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(257, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Fecha de saldo Inicial:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(58, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(67, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Saldo Inicial:"
        '
        'dtpBeginninDate
        '
        Me.dtpBeginninDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpBeginninDate.Location = New System.Drawing.Point(376, 26)
        Me.dtpBeginninDate.Name = "dtpBeginninDate"
        Me.dtpBeginninDate.Size = New System.Drawing.Size(121, 20)
        Me.dtpBeginninDate.TabIndex = 2
        '
        'txtInitialBalance
        '
        Me.txtInitialBalance.Location = New System.Drawing.Point(131, 25)
        Me.txtInitialBalance.Name = "txtInitialBalance"
        Me.txtInitialBalance.Size = New System.Drawing.Size(121, 20)
        Me.txtInitialBalance.TabIndex = 1
        Me.txtInitialBalance.Text = "0.00"
        Me.txtInitialBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(109, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Nombre de la cuenta:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(286, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Tipo de cuenta:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 62)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Numero de cuenta:"
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.ForeColor = System.Drawing.Color.White
        Me.lblId.Location = New System.Drawing.Point(409, 62)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(13, 13)
        Me.lblId.TabIndex = 7
        Me.lblId.Text = "0"
        '
        'BancoSoABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScroll = True
        Me.Controls.Add(Me.Panel1)
        Me.Name = "BancoSoABM"
        Me.Size = New System.Drawing.Size(833, 402)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.pnlTitle0, 0)
        Me.Controls.SetChildIndex(Me.pnlControls0, 0)
        Me.pnlControls0.ResumeLayout(False)
        Me.pnlControls0.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAccountNumber As TextBox
    Friend WithEvents cboBankType As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Protected WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDescription As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents dtpBeginninDate As DateTimePicker
    Friend WithEvents txtInitialBalance As TextBox
    Friend WithEvents txtNombreAcc As TextBox
    Friend WithEvents lblId As Label
#End Region

    Private oDataLayer As BancoSoDataLayer
    Public Sub New()
        MyBase.New

        InitializeComponent()

        GetBancoSoType()

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
        Dim oData As BancoSoData

        oDataLayer = New BancoSoDataLayer

        Try
            'MessageBox.Show(txtId.Text)
            If lblId.Text = Nothing Or lblId.Text = "" Then
                lblId.Text = Nothing
            End If

            oData = New BancoSoData With
                {
                .OSB_Id = IIf(IsAddNew, 0, lblId.Text),
                .OSB_Nombre = txtNombreAcc.Text.Trim,
                .OSB_Account = txtAccountNumber.Text.Trim,
                .OSB_Type = cboBankType.SelectedValue,
                .OSB_InitialBalance = txtInitialBalance.Text.Trim,
                .OSB_BeginninBalanceDate = dtpBeginninDate.Text,
                .OSB_Description = txtDescription.Text.Trim,
                .OSB_ModifiedBy = oApp.CurrentUser.USR_Id,
                .OSB_Active = 1'IIf(chkActive.CheckState, 1, 0)
                }

            If IsAddNew Then
                oDataLayer.CreateBancoSo(oData)
            Else
                oDataLayer.UpdateBancoSo(oData)
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub BancoABM_SetDefaultValuesOnEdit(row As DataRowView) Handles MyBase.SetDefaultValuesOnEdit
        lblId.Enabled = True
    End Sub

    Private Sub BancoABM_SetBindings(row As DataRowView) Handles MyBase.SetBindings
        lblId.DataBindings.Add("Text", row, "OSB_Id")
        txtNombreAcc.DataBindings.Add("Text", row, "OSB_Nombre")
        cboBankType.DataBindings.Add("SelectedValue", row, "OSB_Type")
        txtAccountNumber.DataBindings.Add("Text", row, "OSB_Account")
        txtInitialBalance.DataBindings.Add("Text", row, "OSB_InitialBalance")
        dtpBeginninDate.DataBindings.Add("Text", row, "OSB_BeginninBalanceDate")
        txtDescription.DataBindings.Add("Text", row, "OSB_Description")

    End Sub
    Private Sub ValiText(sender As Object, e As KeyPressEventArgs)

        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub GetBancoSoType()
        Try

            Dim oBancoSoData As BancoSoDataLayer = Nothing

            oBancoSoData = New BancoSoDataLayer

            cboBankType.DataSource = oBancoSoData.GetAcountType

            cboBankType.ValueMember = "OSBT_Id"
            cboBankType.DisplayMember = "OSBT_Nombre"
        Catch ex As Exception

        End Try
    End Sub



End Class
