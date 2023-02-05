Public Class BancoSoABM
    Inherits ABMBase

#Region "InitializeComponent"



    Private Sub InitializeComponent()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlControls0.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlControls0
        '
        Me.pnlControls0.Controls.Add(Me.Label4)
        Me.pnlControls0.Controls.Add(Me.Label3)
        Me.pnlControls0.Controls.Add(Me.Label2)
        Me.pnlControls0.Controls.Add(Me.TextBox2)
        Me.pnlControls0.Controls.Add(Me.ComboBox1)
        Me.pnlControls0.Controls.Add(Me.TextBox1)
        Me.pnlControls0.Size = New System.Drawing.Size(524, 103)
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(131, 18)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(121, 20)
        Me.TextBox1.TabIndex = 0
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(375, 17)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(130, 55)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(238, 20)
        Me.TextBox2.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.TextBox4)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.DateTimePicker1)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Location = New System.Drawing.Point(193, 198)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(524, 127)
        Me.Panel1.TabIndex = 6
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
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(131, 67)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(238, 20)
        Me.TextBox4.TabIndex = 8
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
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(376, 26)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(121, 20)
        Me.DateTimePicker1.TabIndex = 4
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(131, 25)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(121, 20)
        Me.TextBox3.TabIndex = 3
        Me.TextBox3.Text = "0.00"
        Me.TextBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Protected WithEvents Panel1 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox1 As TextBox
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

        'Try
        '    'MessageBox.Show(txtId.Text)
        '    If lblId.Text = Nothing Or lblId.Text = "" Then
        '        lblId.Text = Nothing
        '    End If

        '    oData = New BancoData With
        '        {
        '       .BAN_Id = IIf(IsAddNew, 0, lblId.Text),
        '       .BAN_Type = cboBankAcc.SelectedIndex + 1,
        '       .BAN_Name = txtNombre.Text.Trim,
        '       .BAN_Prefix = txtPrefix.Text.Trim,
        '       .BAN_ModifiedBy = oApp.CurrentUser.USR_Id,
        '       .BAN_Active = IIf(chkActive.CheckState, 1, 0)
        '        }

        '    If IsAddNew Then
        '        oDataLayer.CreateBanco(oData)
        '    Else
        '        oDataLayer.UpdateBanco(oData)
        '    End If
        'Catch ex As Exception
        '    Throw New Exception(ex.Message)
        'End Try
    End Sub
    Private Sub BancoABM_SetDefaultValuesOnEdit(row As DataRowView) Handles MyBase.SetDefaultValuesOnEdit
        'lblId.Enabled = True
    End Sub
    'Private Sub BancoABM_SetDefaultValuesOnAdd(row As DataRowView) Handles MyBase.SetDefaultValuesOnNew
    '    row("SOC_Id") = 0
    '    'row("SOC_Name") = not
    '    'row("SOC_Telefono") = ""
    '    'row("SOC_Active") = True
    'End Sub
    Private Sub BancoABM_SetBindings(row As DataRowView) Handles MyBase.SetBindings
        'lblId.DataBindings.Add("Text", row, "BAN_Id")
        'txtNombre.DataBindings.Add("Text", row, "BAN_Name")
        'txtPrefix.DataBindings.Add("Text", row, "BAN_Prefix")
        'chkActive.DataBindings.Add("Checked", row, "BAN_Active")
        'cboBankAcc.DataBindings.Add("SelectedValue", row, "BAN_ACC_Name")
    End Sub
    Private Sub ValiText(sender As Object, e As KeyPressEventArgs)

        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub

    Private Sub GetBancos()
        Dim oBancoData As BancoDataLayer = Nothing

        oBancoData = New BancoDataLayer

        'cboBankAcc.DataSource = oBancoData.GetAcountType
    End Sub


    'Private Sub txtPrefix_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPrefix.KeyPress
    '    ValiText(sender, e)
    'End Sub
End Class
