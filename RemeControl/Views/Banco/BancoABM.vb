Public Class BancoABM
    Inherits ABMBase

#Region "InitializeComponet"


    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtPrefix As TextBox
    Friend WithEvents cboBancoAcc As ComboBox
    Friend WithEvents txtNombre As TextBox
    Friend WithEvents txtId As TextBox

    Private Sub InitializeComponent()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPrefix = New System.Windows.Forms.TextBox()
        Me.cboBancoAcc = New System.Windows.Forms.ComboBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.pnlControls0.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlControls0
        '
        Me.pnlControls0.Controls.Add(Me.Label3)
        Me.pnlControls0.Controls.Add(Me.Label2)
        Me.pnlControls0.Controls.Add(Me.Label1)
        Me.pnlControls0.Controls.Add(Me.txtPrefix)
        Me.pnlControls0.Controls.Add(Me.cboBancoAcc)
        Me.pnlControls0.Controls.Add(Me.txtNombre)
        Me.pnlControls0.Controls.Add(Me.txtId)
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Tipo de cuenta:"
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
        Me.txtPrefix.TabIndex = 13
        '
        'cboBancoAcc
        '
        Me.cboBancoAcc.FormattingEnabled = True
        Me.cboBancoAcc.Location = New System.Drawing.Point(125, 82)
        Me.cboBancoAcc.Name = "cboBancoAcc"
        Me.cboBancoAcc.Size = New System.Drawing.Size(121, 21)
        Me.cboBancoAcc.TabIndex = 12
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(125, 56)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(121, 20)
        Me.txtNombre.TabIndex = 11
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(125, 30)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(100, 20)
        Me.txtId.TabIndex = 10
        Me.txtId.Text = "0"
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
            If txtId.Text = Nothing Or txtId.Text = "" Then
                txtId.Text = Nothing
            End If
            '.SOC_Id = IIf(IsAddNew, 0, txtId.Text),
            '.SOC_Name = txtName.Text.Trim,
            '.SOC_Telefono = txtPhone.Text.Trim,
            '.SOC_ModifiedBy = oApp.CurrentUser.USR_Id,
            '.SOC_Active = IIf(chkActive.CheckState, 1, 0)
            oData = New BancoData With
                {
               .BAN_Id = IIf(IsAddNew, 0, txtId.Text)
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
        'txtId.Enabled = False
    End Sub
    'Private Sub BancoABM_SetDefaultValuesOnAdd(row As DataRowView) Handles MyBase.SetDefaultValuesOnNew
    '    row("SOC_Id") = 0
    '    'row("SOC_Name") = not
    '    'row("SOC_Telefono") = ""
    '    'row("SOC_Active") = True
    'End Sub
    Private Sub BancoABM_SetBindings(row As DataRowView) Handles MyBase.SetBindings
        'txtId.DataBindings.Add("Text", row, "SOC_Id")
        'txtName.DataBindings.Add("Text", row, "SOC_Name")
        'txtPhone.DataBindings.Add("Text", row, "SOC_Telefono")
        'chkActive.DataBindings.Add("Checked", row, "SOC_Active")
    End Sub
    Private Sub ValiText(sender As Object, e As KeyPressEventArgs)

        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
        End If

    End Sub
End Class
