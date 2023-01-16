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
    Friend WithEvents txtBinance As TextBox

    Private Sub InitializeComponent()
        Me.txtBinance = New System.Windows.Forms.TextBox()
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
        Me.pnlControls0.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlControls0
        '
        Me.pnlControls0.Controls.Add(Me.txtTasaVentaCustom)
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
        Me.pnlControls0.Controls.Add(Me.txtBinance)
        '
        'txtBinance
        '
        Me.txtBinance.Location = New System.Drawing.Point(81, 38)
        Me.txtBinance.MaxLength = 6
        Me.txtBinance.Name = "txtBinance"
        Me.txtBinance.Size = New System.Drawing.Size(100, 20)
        Me.txtBinance.TabIndex = 5
        Me.txtBinance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDolarInPais
        '
        Me.txtDolarInPais.Location = New System.Drawing.Point(81, 64)
        Me.txtDolarInPais.MaxLength = 6
        Me.txtDolarInPais.Name = "txtDolarInPais"
        Me.txtDolarInPais.Size = New System.Drawing.Size(100, 20)
        Me.txtDolarInPais.TabIndex = 6
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
        Me.txtComision.Size = New System.Drawing.Size(100, 20)
        Me.txtComision.TabIndex = 9
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
        Me.txtTasaFull.Size = New System.Drawing.Size(100, 20)
        Me.txtTasaFull.TabIndex = 11
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
        Me.txtTasaVenta.Size = New System.Drawing.Size(100, 20)
        Me.txtTasaVenta.TabIndex = 13
        Me.txtTasaVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'chkCustom
        '
        Me.chkCustom.AutoSize = True
        Me.chkCustom.Location = New System.Drawing.Point(346, 97)
        Me.chkCustom.Name = "chkCustom"
        Me.chkCustom.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.chkCustom.Size = New System.Drawing.Size(93, 17)
        Me.chkCustom.TabIndex = 15
        Me.chkCustom.Text = "Ajuste de tasa"
        Me.chkCustom.UseVisualStyleBackColor = True
        '
        'txtTasaVentaCustom
        '
        Me.txtTasaVentaCustom.Location = New System.Drawing.Point(339, 120)
        Me.txtTasaVentaCustom.MaxLength = 8
        Me.txtTasaVentaCustom.Name = "txtTasaVentaCustom"
        Me.txtTasaVentaCustom.Size = New System.Drawing.Size(100, 20)
        Me.txtTasaVentaCustom.TabIndex = 16
        Me.txtTasaVentaCustom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtTasaVentaCustom.Visible = False
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

    Private Expre_Regu As String = "\d{1,3}\.\d{1,2}"

    Public Sub New()
        MyBase.New

        InitializeComponent()

    End Sub

    Public Function Vali(e As KeyPressEventArgs)
        Dim r As Regex = New Regex(Expre_Regu)
        'If r.IsMatch() Then
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." And Not e.KeyChar = "," And Not e.KeyChar = "*" Then

            e.Handled = True
        End If
    End Function
    Private Sub chkCustom_CheckedChanged(sender As Object, e As EventArgs) Handles chkCustom.CheckedChanged
        If chkCustom.CheckState Then
            txtTasaVentaCustom.Visible = True
            txtTasaVenta.Visible = False
        Else
            txtTasaVentaCustom.Visible = False
            txtTasaVenta.Visible = True
        End If
    End Sub



End Class
