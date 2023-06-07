Imports System.Globalization
Imports System.Text.RegularExpressions

Public Class TasaABM
    Inherits ABMBase


#Region "Form Designer"



    Friend WithEvents chkCustom As CheckBox
    Friend WithEvents lblTasaVenta As Label
    Friend WithEvents txtTasaVenta As TextBox
    Friend WithEvents lblTFull As Label
    Friend WithEvents txtTasaFull As TextBox
    Friend WithEvents lblComision As Label
    Friend WithEvents txtComision As TextBox
    Friend WithEvents lblDolarInPais As Label
    Friend WithEvents lblBinance As Label
    Friend WithEvents txtDolarInPais As TextBox
    Friend WithEvents txtTasaVentaCustom As TextBox
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cboSocio As ComboBox
    Friend WithEvents lblIdControl As Label
    Friend WithEvents txtBina As TextBox

    Private Sub InitializeComponent()
        Me.txtBina = New System.Windows.Forms.TextBox()
        Me.txtDolarInPais = New System.Windows.Forms.TextBox()
        Me.lblBinance = New System.Windows.Forms.Label()
        Me.lblDolarInPais = New System.Windows.Forms.Label()
        Me.txtComision = New System.Windows.Forms.TextBox()
        Me.lblComision = New System.Windows.Forms.Label()
        Me.lblTFull = New System.Windows.Forms.Label()
        Me.txtTasaFull = New System.Windows.Forms.TextBox()
        Me.lblTasaVenta = New System.Windows.Forms.Label()
        Me.txtTasaVenta = New System.Windows.Forms.TextBox()
        Me.chkCustom = New System.Windows.Forms.CheckBox()
        Me.txtTasaVentaCustom = New System.Windows.Forms.TextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.cboSocio = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblIdControl = New System.Windows.Forms.Label()
        Me.pnlControls0.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlControls0
        '
        Me.pnlControls0.Controls.Add(Me.lblIdControl)
        Me.pnlControls0.Controls.Add(Me.Label2)
        Me.pnlControls0.Controls.Add(Me.Label1)
        Me.pnlControls0.Controls.Add(Me.cboSocio)
        Me.pnlControls0.Controls.Add(Me.dtpFecha)
        Me.pnlControls0.Controls.Add(Me.chkCustom)
        Me.pnlControls0.Controls.Add(Me.lblTasaVenta)
        Me.pnlControls0.Controls.Add(Me.txtTasaVenta)
        Me.pnlControls0.Controls.Add(Me.lblTFull)
        Me.pnlControls0.Controls.Add(Me.txtTasaFull)
        Me.pnlControls0.Controls.Add(Me.lblComision)
        Me.pnlControls0.Controls.Add(Me.txtComision)
        Me.pnlControls0.Controls.Add(Me.lblDolarInPais)
        Me.pnlControls0.Controls.Add(Me.lblBinance)
        Me.pnlControls0.Controls.Add(Me.txtDolarInPais)
        Me.pnlControls0.Controls.Add(Me.txtBina)
        Me.pnlControls0.Controls.Add(Me.txtTasaVentaCustom)
        Me.pnlControls0.TabIndex = 0
        '
        'txtBina
        '
        Me.txtBina.BackColor = System.Drawing.Color.White
        Me.txtBina.Location = New System.Drawing.Point(92, 62)
        Me.txtBina.MaxLength = 6
        Me.txtBina.Name = "txtBina"
        Me.txtBina.Size = New System.Drawing.Size(129, 20)
        Me.txtBina.TabIndex = 1
        Me.txtBina.Tag = ""
        Me.txtBina.Text = "0.00"
        Me.txtBina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDolarInPais
        '
        Me.txtDolarInPais.Location = New System.Drawing.Point(92, 88)
        Me.txtDolarInPais.MaxLength = 6
        Me.txtDolarInPais.Name = "txtDolarInPais"
        Me.txtDolarInPais.Size = New System.Drawing.Size(129, 20)
        Me.txtDolarInPais.TabIndex = 2
        Me.txtDolarInPais.Text = "0.00"
        Me.txtDolarInPais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBinance
        '
        Me.lblBinance.AutoSize = True
        Me.lblBinance.Location = New System.Drawing.Point(26, 69)
        Me.lblBinance.Name = "lblBinance"
        Me.lblBinance.Size = New System.Drawing.Size(49, 13)
        Me.lblBinance.TabIndex = 7
        Me.lblBinance.Text = "Binance:"
        '
        'lblDolarInPais
        '
        Me.lblDolarInPais.AutoSize = True
        Me.lblDolarInPais.Location = New System.Drawing.Point(40, 95)
        Me.lblDolarInPais.Name = "lblDolarInPais"
        Me.lblDolarInPais.Size = New System.Drawing.Size(35, 13)
        Me.lblDolarInPais.TabIndex = 8
        Me.lblDolarInPais.Text = "Dolar:"
        '
        'txtComision
        '
        Me.txtComision.Location = New System.Drawing.Point(92, 114)
        Me.txtComision.MaxLength = 4
        Me.txtComision.Name = "txtComision"
        Me.txtComision.ReadOnly = True
        Me.txtComision.Size = New System.Drawing.Size(129, 20)
        Me.txtComision.TabIndex = 3
        Me.txtComision.TabStop = False
        Me.txtComision.Text = "0.05"
        Me.txtComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblComision
        '
        Me.lblComision.AutoSize = True
        Me.lblComision.Location = New System.Drawing.Point(23, 121)
        Me.lblComision.Name = "lblComision"
        Me.lblComision.Size = New System.Drawing.Size(52, 13)
        Me.lblComision.TabIndex = 10
        Me.lblComision.Text = "Comisión:"
        '
        'lblTFull
        '
        Me.lblTFull.AutoSize = True
        Me.lblTFull.Location = New System.Drawing.Point(274, 69)
        Me.lblTFull.Name = "lblTFull"
        Me.lblTFull.Size = New System.Drawing.Size(59, 13)
        Me.lblTFull.TabIndex = 12
        Me.lblTFull.Text = "Tasa a full:"
        '
        'txtTasaFull
        '
        Me.txtTasaFull.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTasaFull.Location = New System.Drawing.Point(339, 66)
        Me.txtTasaFull.MaxLength = 9
        Me.txtTasaFull.Name = "txtTasaFull"
        Me.txtTasaFull.ReadOnly = True
        Me.txtTasaFull.Size = New System.Drawing.Size(129, 20)
        Me.txtTasaFull.TabIndex = 9
        Me.txtTasaFull.TabStop = False
        Me.txtTasaFull.Text = "0.000000"
        Me.txtTasaFull.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTasaVenta
        '
        Me.lblTasaVenta.AutoSize = True
        Me.lblTasaVenta.Location = New System.Drawing.Point(260, 98)
        Me.lblTasaVenta.Name = "lblTasaVenta"
        Me.lblTasaVenta.Size = New System.Drawing.Size(73, 13)
        Me.lblTasaVenta.TabIndex = 14
        Me.lblTasaVenta.Text = "Tasa a venta:"
        '
        'txtTasaVenta
        '
        Me.txtTasaVenta.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTasaVenta.Location = New System.Drawing.Point(339, 95)
        Me.txtTasaVenta.MaxLength = 8
        Me.txtTasaVenta.Name = "txtTasaVenta"
        Me.txtTasaVenta.ReadOnly = True
        Me.txtTasaVenta.Size = New System.Drawing.Size(129, 13)
        Me.txtTasaVenta.TabIndex = 4
        Me.txtTasaVenta.TabStop = False
        Me.txtTasaVenta.Text = "0.0000"
        Me.txtTasaVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkCustom
        '
        Me.chkCustom.AutoSize = True
        Me.chkCustom.Location = New System.Drawing.Point(339, 127)
        Me.chkCustom.Name = "chkCustom"
        Me.chkCustom.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkCustom.Size = New System.Drawing.Size(15, 14)
        Me.chkCustom.TabIndex = 3
        Me.chkCustom.UseVisualStyleBackColor = True
        '
        'txtTasaVentaCustom
        '
        Me.txtTasaVentaCustom.Location = New System.Drawing.Point(339, 95)
        Me.txtTasaVentaCustom.MaxLength = 8
        Me.txtTasaVentaCustom.Name = "txtTasaVentaCustom"
        Me.txtTasaVentaCustom.Size = New System.Drawing.Size(129, 20)
        Me.txtTasaVentaCustom.TabIndex = 5
        Me.txtTasaVentaCustom.Text = "0.0000"
        Me.txtTasaVentaCustom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTasaVentaCustom.Visible = False
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(339, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(129, 20)
        Me.dtpFecha.TabIndex = 16
        Me.dtpFecha.Visible = False
        '
        'cboSocio
        '
        Me.cboSocio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSocio.FormattingEnabled = True
        Me.cboSocio.Location = New System.Drawing.Point(92, 35)
        Me.cboSocio.Name = "cboSocio"
        Me.cboSocio.Size = New System.Drawing.Size(129, 21)
        Me.cboSocio.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Socio:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(256, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(77, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Ajuste de tasa:"
        '
        'lblIdControl
        '
        Me.lblIdControl.AutoSize = True
        Me.lblIdControl.ForeColor = System.Drawing.Color.White
        Me.lblIdControl.Location = New System.Drawing.Point(191, 12)
        Me.lblIdControl.Name = "lblIdControl"
        Me.lblIdControl.Size = New System.Drawing.Size(13, 13)
        Me.lblIdControl.TabIndex = 20
        Me.lblIdControl.Text = "0"
        '
        'TasaABM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.Name = "TasaABM"
        Me.pnlControls0.ResumeLayout(False)
        Me.pnlControls0.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
#End Region

    Private oDataLayer As TasaDataLayer
    Private FuntionCon As New CommonFunction
    Private TasaFull As Double = 0
    Private TasaClien As Double = 0

    Private focusedForeColor As Color = Color.Black
    Private focusedBackColor As Color = Color.Gainsboro


    Public Sub New()
        MyBase.New

        InitializeComponent()

        CargaBOX()

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
    Private Sub chkCustom_CheckedChanged(sender As Object, e As EventArgs) Handles chkCustom.CheckedChanged
        If chkCustom.CheckState Then
            txtTasaVentaCustom.Visible = True
            txtTasaVenta.Visible = False
            txtTasaVentaCustom.Focus()
        Else
            txtTasaVentaCustom.Visible = False
            txtTasaVenta.Visible = True
        End If
    End Sub

    Private Sub txtBina_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBina.KeyPress
        'ValiText(sender, e)
        FuntionCon.ManejarDecimalEnTextBox(sender, e)
    End Sub
    Private Sub txtDolarInPais_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDolarInPais.KeyPress
        'ValiText(sender, e)
        FuntionCon.ManejarDecimalEnTextBox(sender, e)
    End Sub


    Private Sub CalcularTasa()

        Try
            If Not String.IsNullOrEmpty(txtBina.Text) OrElse Not Val(txtBina.Text) = 0 Then
                If Not String.IsNullOrEmpty(txtDolarInPais.Text) OrElse Not Val(txtDolarInPais.Text) = 0 Then
                    If Val(txtBina.Text) = 0 Then
                        TasaFull = 0
                    Else
                        TasaFull = Val(txtDolarInPais.Text) / Val(txtBina.Text)
                    End If
                End If
            End If

            If Not TasaFull = 0 Then
                TasaClien = TasaFull - ((TasaFull / (1 - Val(txtComision.Text))) - TasaFull)

                txtTasaFull.Text = TasaFull.ToString("n6")
                'txtTasaFull.DataBindings.Add("text", TasaFull.ToString("n6"), "")
                txtTasaVenta.Text = TasaClien.ToString("n4")
                'txtTasaVenta.DataBindings.Add("Text", TasaClien.ToString("n4"), "")
            Else
                'txtTasaFull.Text = "0.000000"
                TasaFull = "0.000000"
                txtTasaFull.ResetText()
                'txtTasaVenta.Text = "0.0000"
                TasaClien = "0.0000"
                txtTasaVenta.ResetText()
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub txtBina_TextChanged(sender As Object, e As EventArgs) Handles txtBina.TextChanged

        CalcularTasa()

    End Sub

    Private Sub txtDolarInPais_TextChanged(sender As Object, e As EventArgs) Handles txtDolarInPais.TextChanged
        CalcularTasa()
    End Sub

    Private Sub txtTasaVentaCustom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTasaVentaCustom.KeyPress
        FuntionCon.ValiText(sender, e)
    End Sub

    Private Sub TasaABM_Save() Handles MyBase.Save
        oDataLayer = New TasaDataLayer
        Dim oData As New TasaData
        Dim tasacliente As Double = 0

        Try

            oData = New TasaData With {
            .TAS_Id = IIf(IsAddNew, 0, lblIdControl.Text),
            .TAS_Date = Now.ToString("yyyy/MM/dd 00:00:00"),
            .TAS_Binance = txtBina.Text,
            .TAS_Socio = cboSocio.SelectedValue,
            .TAS_DolarPais = txtDolarInPais.Text,
            .TAS_Comision = txtComision.Text,
            .TAS_TasaFull = txtTasaFull.Text,
            .TAS_TasaMayorista = 0,
            .TAS_TasaCliente = IIf(chkCustom.Checked, txtTasaVentaCustom.Text, txtTasaVenta.Text),
            .TAS_ModifiedBy = oApp.CurrentUser.USR_Id,
            .TAS_Active = 1
            }

            If IsAddNew Then
                oDataLayer.CreateTasa(oData)
            Else
                oDataLayer.UpdateTasa(oData)
            End If


        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


    Private Sub TasaABM_SetBindings(row As DataRowView) Handles MyBase.SetBindings
        lblIdControl.DataBindings.Add("Text", row, "TAS_Id")
        cboSocio.DataBindings.Add("SelectedValue", row, "TAS_Socio")
        txtBina.DataBindings.Add("Text", row, "TAS_Binance")
        txtDolarInPais.DataBindings.Add("Text", row, "TAS_DolarPais")
        txtComision.DataBindings.Add("Text", row, "TAS_Comision")
        txtTasaFull.DataBindings.Add("Text", row, "TAS_TasaFull")
        txtTasaVenta.DataBindings.Add("Text", row, "TAS_TasaCliente")
        dtpFecha.DataBindings.Add("Text", row, "TAS_Date")

    End Sub
    Private Sub TasaABM_SetDefaultValuesOnEdit(row As DataRowView) Handles MyBase.SetDefaultValuesOnEdit
        lblIdControl.Enabled = False
    End Sub
    Private Sub TasaABM_SetDefaultValuesOnAdd(row As DataRowView) Handles MyBase.SetDefaultValuesOnNew


    End Sub

    Private Sub TasaABM_ValidateControls(ByRef Cancel As Boolean, IsAddNew As Boolean) Handles MyBase.ValidateControls
        Dim sErrorMsg As String = "Este campo es requerido"

        If txtBina.Text = String.Empty Or txtBina.Text = "0.00" Then
            MessageBox.Show(sErrorMsg, Me.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cancel = True
            txtBina.Select()
            Exit Sub
        End If
        If txtDolarInPais.Text = String.Empty Or txtDolarInPais.Text = "0.00" Then
            MessageBox.Show(sErrorMsg, Me.Caption, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Cancel = True
            txtDolarInPais.Select()
            Exit Sub
        End If

    End Sub

    Private Sub txtDolarInPais_LostFocus(sender As Object, e As EventArgs) Handles txtDolarInPais.LostFocus
        txtTasaFull.Text = TasaFull.ToString("n6")
        txtTasaVenta.Text = TasaClien.ToString("n4")
    End Sub

    Private Sub txtBina_LostFocus(sender As Object, e As EventArgs) Handles txtBina.LostFocus
        txtTasaFull.Text = TasaFull.ToString("n6")
        txtTasaVenta.Text = TasaClien.ToString("n4")
    End Sub

    Private Sub CargaBOX()
        Dim oBSource As New BindingSource
        oDataLayer = New TasaDataLayer

        oBSource.DataSource = oDataLayer.GetSocios

        If oBSource.List.Item(0).Row.ItemArray(0) = -9999 Then
            With cboSocio
                .Items.Add("No hay socios")
            End With
            cboSocio.Refresh()

            btnOk.Enabled = False
        Else
            With cboSocio
                .DataSource = oBSource.DataSource
                .ValueMember = "SOC_Id"
                .DisplayMember = "SOC_Name"

            End With
        End If
    End Sub

    Private Sub TasaABM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
