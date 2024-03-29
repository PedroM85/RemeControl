﻿Public Class SocioABM
    Inherits ABMBase

#Region "Iniciati"


    Friend WithEvents lblActivo As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblName As Label
    Friend WithEvents chkActive As CheckBox
    Friend WithEvents txtPhone As TextBox
    Friend WithEvents lblId As Label
    Friend WithEvents txtName As TextBox

    Private Sub InitializeComponent()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtPhone = New System.Windows.Forms.TextBox()
        Me.chkActive = New System.Windows.Forms.CheckBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblActivo = New System.Windows.Forms.Label()
        Me.lblId = New System.Windows.Forms.Label()
        Me.pnlControls0.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlControls0
        '
        Me.pnlControls0.Controls.Add(Me.lblId)
        Me.pnlControls0.Controls.Add(Me.lblActivo)
        Me.pnlControls0.Controls.Add(Me.lblPhone)
        Me.pnlControls0.Controls.Add(Me.lblName)
        Me.pnlControls0.Controls.Add(Me.chkActive)
        Me.pnlControls0.Controls.Add(Me.txtPhone)
        Me.pnlControls0.Controls.Add(Me.txtName)
        Me.pnlControls0.Size = New System.Drawing.Size(524, 193)
        Me.pnlControls0.TabIndex = 1
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(163, 70)
        Me.txtName.MaxLength = 50
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(186, 20)
        Me.txtName.TabIndex = 0
        '
        'txtPhone
        '
        Me.txtPhone.Location = New System.Drawing.Point(163, 96)
        Me.txtPhone.MaxLength = 20
        Me.txtPhone.Name = "txtPhone"
        Me.txtPhone.Size = New System.Drawing.Size(125, 20)
        Me.txtPhone.TabIndex = 1
        '
        'chkActive
        '
        Me.chkActive.AutoSize = True
        Me.chkActive.Checked = True
        Me.chkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkActive.Location = New System.Drawing.Point(163, 122)
        Me.chkActive.Name = "chkActive"
        Me.chkActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkActive.Size = New System.Drawing.Size(15, 14)
        Me.chkActive.TabIndex = 2
        Me.chkActive.UseVisualStyleBackColor = True
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Location = New System.Drawing.Point(84, 70)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(47, 13)
        Me.lblName.TabIndex = 4
        Me.lblName.Text = "Nombre:"
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Location = New System.Drawing.Point(79, 96)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(52, 13)
        Me.lblPhone.TabIndex = 5
        Me.lblPhone.Text = "Telefono:"
        '
        'lblActivo
        '
        Me.lblActivo.AutoSize = True
        Me.lblActivo.Location = New System.Drawing.Point(91, 122)
        Me.lblActivo.Name = "lblActivo"
        Me.lblActivo.Size = New System.Drawing.Size(40, 13)
        Me.lblActivo.TabIndex = 6
        Me.lblActivo.Text = "Activo:"
        '
        'lblId
        '
        Me.lblId.AutoSize = True
        Me.lblId.ForeColor = System.Drawing.Color.White
        Me.lblId.Location = New System.Drawing.Point(336, 44)
        Me.lblId.Name = "lblId"
        Me.lblId.Size = New System.Drawing.Size(13, 13)
        Me.lblId.TabIndex = 7
        Me.lblId.Text = "0"
        '
        'SocioABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "SocioABM"
        Me.pnlControls0.ResumeLayout(False)
        Me.pnlControls0.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private oDataLayer As SocioDataLayer
    Private FuntionCon As New CommonFunction


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
    Private Sub SocioABM_Save() Handles MyBase.Save
        Dim oData As SocioData

        oDataLayer = New SocioDataLayer
        Try


            oData = New SocioData With
                {
                .SOC_Id = IIf(IsAddNew, 0, lblId.Text),
                .SOC_Name = txtName.Text.Trim,
                .SOC_Telefono = txtPhone.Text.Trim,
                .SOC_ModifiedBy = oApp.CurrentUser.USR_Id,
                .SOC_Active = IIf(chkActive.CheckState, 1, 0)
                }

            If IsAddNew Then
                oDataLayer.CreateSocios(oData)
            Else
                oDataLayer.UpdateSocios(oData)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub SocioABM_ValidateControls(ByRef Cancel As Boolean, IsAddNew As Boolean) Handles MyBase.ValidateControls
        Dim sErrorMsg As String = "Este campo es requerido"

        If txtName.Text = String.Empty Then
            MessageBox.Show(sErrorMsg, Me.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cancel = True
            txtName.Select()
            Exit Sub
        End If
        If txtPhone.Text = String.Empty Then
            MessageBox.Show(sErrorMsg, Me.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cancel = True
            txtPhone.Select()
            Exit Sub
        End If
    End Sub
    Private Sub SocioABM_SetDefaultValuesOnEdit(row As DataRowView) Handles MyBase.SetDefaultValuesOnEdit
        lblId.Enabled = False
    End Sub

    Private Sub SocioABM_SetBindings(row As DataRowView) Handles MyBase.SetBindings
        lblId.DataBindings.Add("Text", row, "SOC_Id")
        txtName.DataBindings.Add("Text", row, "SOC_Name")
        txtPhone.DataBindings.Add("Text", row, "SOC_Telefono")
        chkActive.DataBindings.Add("Checked", row, "SOC_Active")
    End Sub

    Private Sub txtPhone_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPhone.KeyPress
        FuntionCon.ValiText(sender, e)
    End Sub
End Class
