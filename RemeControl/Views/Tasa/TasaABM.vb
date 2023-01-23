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
    Friend WithEvents txtIdControl As TextBox
    Friend WithEvents dtpFecha As DateTimePicker
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
        Me.txtIdControl = New System.Windows.Forms.TextBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.pnlControls0.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlControls0
        '
        Me.pnlControls0.Controls.Add(Me.dtpFecha)
        Me.pnlControls0.Controls.Add(Me.txtIdControl)
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
        Me.txtBina.Location = New System.Drawing.Point(81, 38)
        Me.txtBina.MaxLength = 6
        Me.txtBina.Name = "txtBina"
        Me.txtBina.Size = New System.Drawing.Size(100, 20)
        Me.txtBina.TabIndex = 0
        Me.txtBina.Tag = ""
        Me.txtBina.Text = "0.00"
        Me.txtBina.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDolarInPais
        '
        Me.txtDolarInPais.Location = New System.Drawing.Point(81, 64)
        Me.txtDolarInPais.MaxLength = 6
        Me.txtDolarInPais.Name = "txtDolarInPais"
        Me.txtDolarInPais.Size = New System.Drawing.Size(100, 20)
        Me.txtDolarInPais.TabIndex = 1
        Me.txtDolarInPais.Text = "0.00"
        Me.txtDolarInPais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblBinance
        '
        Me.lblBinance.AutoSize = True
        Me.lblBinance.Location = New System.Drawing.Point(26, 45)
        Me.lblBinance.Name = "lblBinance"
        Me.lblBinance.Size = New System.Drawing.Size(49, 13)
        Me.lblBinance.TabIndex = 7
        Me.lblBinance.Text = "Binance:"
        '
        'lblDolarInPais
        '
        Me.lblDolarInPais.AutoSize = True
        Me.lblDolarInPais.Location = New System.Drawing.Point(40, 71)
        Me.lblDolarInPais.Name = "lblDolarInPais"
        Me.lblDolarInPais.Size = New System.Drawing.Size(35, 13)
        Me.lblDolarInPais.TabIndex = 8
        Me.lblDolarInPais.Text = "Dolar:"
        '
        'txtComision
        '
        Me.txtComision.Location = New System.Drawing.Point(81, 90)
        Me.txtComision.MaxLength = 4
        Me.txtComision.Name = "txtComision"
        Me.txtComision.ReadOnly = True
        Me.txtComision.Size = New System.Drawing.Size(100, 20)
        Me.txtComision.TabIndex = 2
        Me.txtComision.TabStop = False
        Me.txtComision.Text = "0.05"
        Me.txtComision.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblComision
        '
        Me.lblComision.AutoSize = True
        Me.lblComision.Location = New System.Drawing.Point(23, 97)
        Me.lblComision.Name = "lblComision"
        Me.lblComision.Size = New System.Drawing.Size(52, 13)
        Me.lblComision.TabIndex = 10
        Me.lblComision.Text = "Comisión:"
        '
        'lblTFull
        '
        Me.lblTFull.AutoSize = True
        Me.lblTFull.Location = New System.Drawing.Point(274, 45)
        Me.lblTFull.Name = "lblTFull"
        Me.lblTFull.Size = New System.Drawing.Size(59, 13)
        Me.lblTFull.TabIndex = 12
        Me.lblTFull.Text = "Tasa a full:"
        '
        'txtTasaFull
        '
        Me.txtTasaFull.Location = New System.Drawing.Point(339, 42)
        Me.txtTasaFull.MaxLength = 9
        Me.txtTasaFull.Name = "txtTasaFull"
        Me.txtTasaFull.ReadOnly = True
        Me.txtTasaFull.Size = New System.Drawing.Size(100, 20)
        Me.txtTasaFull.TabIndex = 3
        Me.txtTasaFull.TabStop = False
        Me.txtTasaFull.Text = "0.00"
        Me.txtTasaFull.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTasaVenta
        '
        Me.lblTasaVenta.AutoSize = True
        Me.lblTasaVenta.Location = New System.Drawing.Point(260, 74)
        Me.lblTasaVenta.Name = "lblTasaVenta"
        Me.lblTasaVenta.Size = New System.Drawing.Size(73, 13)
        Me.lblTasaVenta.TabIndex = 14
        Me.lblTasaVenta.Text = "Tasa a venta:"
        '
        'txtTasaVenta
        '
        Me.txtTasaVenta.Location = New System.Drawing.Point(339, 71)
        Me.txtTasaVenta.MaxLength = 8
        Me.txtTasaVenta.Name = "txtTasaVenta"
        Me.txtTasaVenta.ReadOnly = True
        Me.txtTasaVenta.Size = New System.Drawing.Size(100, 20)
        Me.txtTasaVenta.TabIndex = 4
        Me.txtTasaVenta.TabStop = False
        Me.txtTasaVenta.Text = "0.00"
        Me.txtTasaVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkCustom
        '
        Me.chkCustom.AutoSize = True
        Me.chkCustom.Location = New System.Drawing.Point(346, 97)
        Me.chkCustom.Name = "chkCustom"
        Me.chkCustom.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkCustom.Size = New System.Drawing.Size(93, 17)
        Me.chkCustom.TabIndex = 5
        Me.chkCustom.Text = "Ajuste de tasa"
        Me.chkCustom.UseVisualStyleBackColor = True
        '
        'txtTasaVentaCustom
        '
        Me.txtTasaVentaCustom.Location = New System.Drawing.Point(339, 71)
        Me.txtTasaVentaCustom.MaxLength = 8
        Me.txtTasaVentaCustom.Name = "txtTasaVentaCustom"
        Me.txtTasaVentaCustom.Size = New System.Drawing.Size(100, 20)
        Me.txtTasaVentaCustom.TabIndex = 6
        Me.txtTasaVentaCustom.Text = "0.00"
        Me.txtTasaVentaCustom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTasaVentaCustom.Visible = False
        '
        'txtIdControl
        '
        Me.txtIdControl.BackColor = System.Drawing.Color.White
        Me.txtIdControl.Location = New System.Drawing.Point(81, 12)
        Me.txtIdControl.MaxLength = 6
        Me.txtIdControl.Name = "txtIdControl"
        Me.txtIdControl.Size = New System.Drawing.Size(100, 20)
        Me.txtIdControl.TabIndex = 15
        Me.txtIdControl.Tag = ""
        Me.txtIdControl.Text = "0"
        Me.txtIdControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtIdControl.Visible = False
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(339, 12)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(100, 20)
        Me.dtpFecha.TabIndex = 16
        Me.dtpFecha.Visible = False
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
    Private TasaFull As Double = 0
    Private TasaClien As Double = 0

    Public Sub New()
        MyBase.New

        InitializeComponent()

        'txtBina.Text = 0.00
        'txtDolarInPais.Text = 0.00

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


    Private Sub ValiText(sender As Object, e As KeyPressEventArgs)

        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." And Not e.KeyChar = "," And Not e.KeyChar = "*" Then
            e.Handled = True
        End If

    End Sub

    Private Sub txtBina_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBina.KeyPress
        ValiText(sender, e)
    End Sub
    Private Sub txtDolarInPais_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDolarInPais.KeyPress
        ValiText(sender, e)
    End Sub


    Private Sub CalcularTasa()

        Try
            Dim bina As Decimal = 0
            Dim dolarpais As Decimal = 0
            Dim comi As Double = txtComision.Text

            If Not txtBina.Text Is Nothing And Not txtDolarInPais.Text Is Nothing Then
                bina = txtBina.Text
                dolarpais = txtDolarInPais.Text
                TasaFull = dolarpais / bina
            End If

            TasaClien = TasaFull - ((TasaFull / (1 - comi)) - TasaFull)

            txtTasaFull.Text = TasaFull.ToString("n6")
            txtTasaFull.DataBindings.Add("text", TasaFull.ToString("n6"), "")
            txtTasaVenta.Text = TasaClien.ToString("n4")
            txtTasaVenta.DataBindings.Add("Text", TasaClien.ToString("n4"), "")

        Catch ex As Exception

        End Try


    End Sub

    Private Sub txtBina_TextChanged(sender As Object, e As EventArgs) Handles txtBina.TextChanged
        CalcularTasa()
    End Sub

    Private Sub txtDolarInPais_TextChanged(sender As Object, e As EventArgs) Handles txtDolarInPais.TextChanged
        CalcularTasa()
    End Sub

    Private Sub txtTasaVentaCustom_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTasaVentaCustom.KeyPress
        ValiText(sender, e)
    End Sub

    Private Sub TasaABM_Save() Handles MyBase.Save
        Dim oData As TasaData

        Dim tasacliente As Double = 0
        If chkCustom.Checked Then
            tasacliente = txtTasaVentaCustom.Text
        Else
            tasacliente = txtTasaVenta.Text
        End If

        oDataLayer = New TasaDataLayer
        Try
            If IsAddNew Then
                oData = New TasaData With
            {
            .TAS_Date = Now.ToShortDateString(),
            .TAS_Binance = txtBina.Text,
            .TAS_DolarPais = txtDolarInPais.Text,
            .TAS_Comision = txtComision.Text,
            .TAS_TasaFull = txtTasaFull.Text,
            .TAS_TasaMayorista = 0,
            .TAS_TasaCliente = tasacliente,
            .TAS_ModifiedBy = oApp.CurrentUser.USR_Id
            }
                oDataLayer.CreateTasa(oData)
            Else
                oData = New TasaData With
            {
            .TAS_Id = txtIdControl.Text,
            .TAS_Date = dtpFecha.Text,
            .TAS_Binance = txtBina.Text,
            .TAS_DolarPais = txtDolarInPais.Text,
            .TAS_Comision = txtComision.Text,
            .TAS_TasaFull = txtTasaFull.Text,
            .TAS_TasaMayorista = 0,
            .TAS_TasaCliente = tasacliente,
            .TAS_ModifiedBy = oApp.CurrentUser.USR_Id
            }
                oDataLayer.UpdateTasa(oData)
            End If


        Catch ex As Exception

        End Try

    End Sub
    Private Sub TasaABM_SetBindings(row As DataRowView) Handles MyBase.SetBindings
        txtIdControl.DataBindings.Add("Text", row, "TAS_Id")
        txtBina.DataBindings.Add("Text", row, "TAS_Binance")
        txtDolarInPais.DataBindings.Add("Text", row, "TAS_DolarPais")
        txtComision.DataBindings.Add("Text", row, "TAS_Comision")
        txtTasaFull.DataBindings.Add("Text", row, "TAS_TasaFull")
        txtTasaVenta.DataBindings.Add("Text", row, "TAS_TasaCliente")
        dtpFecha.DataBindings.Add("Text", row, "TAS_Date")

    End Sub
    Private Sub TasaABM_SetDefaultValuesOnEdit(row As DataRowView) Handles MyBase.SetDefaultValuesOnEdit
        txtIdControl.Enabled = False
    End Sub
    Private Sub TasaABM_SetDefaultValuesOnAdd(row As DataRowView) Handles MyBase.SetDefaultValuesOnNew

        'row("TAS_Id") = Nothing
        'row("TAS_Binance") = Nothing
        'row("TAS_DolarPais") = Nothing
        'row("TAS_Comision") = Nothing
        'row("TAS_TasaFull") = Nothing
        'row("TAS_TasaCliente") = Nothing
        'row("TAS_Date") = Nothing

    End Sub

    Private Sub TasaABM_ValidateControls(Cancel As Boolean, IsAddNew As Boolean) Handles MyBase.ValidateControls

    End Sub

    Private Sub txtDolarInPais_LostFocus(sender As Object, e As EventArgs) Handles txtDolarInPais.LostFocus
        txtTasaFull.Text = TasaFull.ToString("n6")
        txtTasaVenta.Text = TasaClien.ToString("n4")
    End Sub

    Private Sub txtBina_LostFocus(sender As Object, e As EventArgs) Handles txtBina.LostFocus
        txtTasaFull.Text = TasaFull.ToString("n6")
        txtTasaVenta.Text = TasaClien.ToString("n4")
    End Sub
End Class
