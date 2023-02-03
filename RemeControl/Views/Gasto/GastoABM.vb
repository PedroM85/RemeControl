Public Class GastoABM
    Inherits ABMBase

    Private oDataLayer As ClienteDataLayer
    Private focusedForeColor As Color = Color.Black
        Private focusedBackColor As Color = Color.Gainsboro

    Private Sub InitializeComponent()

    End Sub

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
    Private Sub ClienteABM_Save() Handles MyBase.Save
        Dim oData As ClienteData

        oDataLayer = New ClienteDataLayer

        Try

            '.SOC_Id = IIf(IsAddNew, 0, txtId.Text),
            '.SOC_Name = txtName.Text.Trim,
            '.SOC_Telefono = txtPhone.Text.Trim,
            '.SOC_ModifiedBy = oApp.CurrentUser.USR_Id,
            '.SOC_Active = IIf(chkActive.CheckState, 1, 0)
            'oData = New ClienteData With
            '    {
            '    .CLI_Id = IIf(IsAddNew, 0, lblId.Text),
            '    .CLI_Nombre = txtNombre.Text.Trim,
            '    .CLI_Banco = cboBanco.SelectedValue,
            '    .CLI_Cuenta = txtCuenta.Text.Trim,
            '    .CLI_Titular = txtTitular.Text.Trim,
            '    .CLI_Cedula = txtCedula.Text.Trim,
            '    .CLI_ModifiedBy = oApp.CurrentUser.USR_Id,
            '    .CLI_Active = IIf(chkActive.CheckState, 1, 0)
            '    }


            'If IsAddNew Then
            '    oDataLayer.CreateCliente(oData)
            'Else
            '    oDataLayer.UpdateCliente(oData)
            'End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub SocioABM_SetDefaultValuesOnEdit(row As DataRowView) Handles MyBase.SetDefaultValuesOnEdit

        'lblId.Visible = True
    End Sub
    'Private Sub SocioABM_SetDefaultValuesOnAdd(row As DataRowView) Handles MyBase.SetDefaultValuesOnNew
    '    row("SOC_Id") = 0
    '    'row("SOC_Name") = not
    '    'row("SOC_Telefono") = ""
    '    'row("SOC_Active") = True
    'End Sub
    Private Sub SocioABM_SetBindings(row As DataRowView) Handles MyBase.SetBindings
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

    Private Sub GetBancos()
        Dim oBancoData As BancoDataLayer = Nothing

        oBancoData = New BancoDataLayer

        'cboBanco.DataSource = oBancoData.GetAcount
        ''cboBanco.ValueMember = "BAN_Name2"
        'Me.cboBanco.ValueMember = "BAN_Id"
        'Me.cboBanco.DisplayMember = "BAN_Name"


    End Sub

End Class
