<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.btnSesion = New System.Windows.Forms.Button()
        Me.btnBancoSo = New System.Windows.Forms.Button()
        Me.btnGasto = New System.Windows.Forms.Button()
        Me.btnSocio = New System.Windows.Forms.Button()
        Me.btnBank = New System.Windows.Forms.Button()
        Me.btnCalcular = New System.Windows.Forms.Button()
        Me.btnClients = New System.Windows.Forms.Button()
        Me.btnCambio = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.pnlFill = New System.Windows.Forms.Panel()
        Me.tmrBlinkyBlinky2 = New System.Windows.Forms.Timer(Me.components)
        Me.pnlBottom.SuspendLayout()
        Me.pnlLeft.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.pnlBottom.Controls.Add(Me.lblInfo)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlBottom.Location = New System.Drawing.Point(0, 464)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(908, 20)
        Me.pnlBottom.TabIndex = 0
        '
        'lblInfo
        '
        Me.lblInfo.AutoSize = True
        Me.lblInfo.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblInfo.Location = New System.Drawing.Point(880, 0)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(28, 13)
        Me.lblInfo.TabIndex = 0
        Me.lblInfo.Text = "???"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlLeft
        '
        Me.pnlLeft.AutoScroll = True
        Me.pnlLeft.BackColor = System.Drawing.SystemColors.Highlight
        Me.pnlLeft.Controls.Add(Me.btnSesion)
        Me.pnlLeft.Controls.Add(Me.btnBancoSo)
        Me.pnlLeft.Controls.Add(Me.btnGasto)
        Me.pnlLeft.Controls.Add(Me.btnSocio)
        Me.pnlLeft.Controls.Add(Me.btnBank)
        Me.pnlLeft.Controls.Add(Me.btnCalcular)
        Me.pnlLeft.Controls.Add(Me.btnClients)
        Me.pnlLeft.Controls.Add(Me.btnCambio)
        Me.pnlLeft.Controls.Add(Me.btnHome)
        Me.pnlLeft.Controls.Add(Me.Panel1)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(202, 464)
        Me.pnlLeft.TabIndex = 1
        '
        'btnSesion
        '
        Me.btnSesion.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnSesion.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSesion.ForeColor = System.Drawing.Color.White
        Me.btnSesion.Location = New System.Drawing.Point(0, 496)
        Me.btnSesion.Name = "btnSesion"
        Me.btnSesion.Size = New System.Drawing.Size(185, 45)
        Me.btnSesion.TabIndex = 8
        Me.btnSesion.Text = "Sesiones"
        Me.btnSesion.UseVisualStyleBackColor = False
        '
        'btnBancoSo
        '
        Me.btnBancoSo.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnBancoSo.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnBancoSo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBancoSo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBancoSo.ForeColor = System.Drawing.Color.White
        Me.btnBancoSo.Location = New System.Drawing.Point(0, 451)
        Me.btnBancoSo.Name = "btnBancoSo"
        Me.btnBancoSo.Size = New System.Drawing.Size(185, 45)
        Me.btnBancoSo.TabIndex = 7
        Me.btnBancoSo.Text = "Banco Socios"
        Me.btnBancoSo.UseVisualStyleBackColor = False
        '
        'btnGasto
        '
        Me.btnGasto.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnGasto.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnGasto.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnGasto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGasto.ForeColor = System.Drawing.Color.White
        Me.btnGasto.Location = New System.Drawing.Point(0, 406)
        Me.btnGasto.Name = "btnGasto"
        Me.btnGasto.Size = New System.Drawing.Size(185, 45)
        Me.btnGasto.TabIndex = 6
        Me.btnGasto.Text = "Gasto"
        Me.btnGasto.UseVisualStyleBackColor = False
        '
        'btnSocio
        '
        Me.btnSocio.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnSocio.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnSocio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnSocio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSocio.ForeColor = System.Drawing.Color.White
        Me.btnSocio.Location = New System.Drawing.Point(0, 361)
        Me.btnSocio.Name = "btnSocio"
        Me.btnSocio.Size = New System.Drawing.Size(185, 45)
        Me.btnSocio.TabIndex = 5
        Me.btnSocio.Text = "Socio | Sucursal"
        Me.btnSocio.UseVisualStyleBackColor = False
        '
        'btnBank
        '
        Me.btnBank.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnBank.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnBank.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnBank.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBank.ForeColor = System.Drawing.Color.White
        Me.btnBank.Location = New System.Drawing.Point(0, 316)
        Me.btnBank.Name = "btnBank"
        Me.btnBank.Size = New System.Drawing.Size(185, 45)
        Me.btnBank.TabIndex = 2
        Me.btnBank.Text = "Bancos"
        Me.btnBank.UseVisualStyleBackColor = False
        '
        'btnCalcular
        '
        Me.btnCalcular.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnCalcular.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCalcular.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCalcular.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCalcular.ForeColor = System.Drawing.Color.White
        Me.btnCalcular.Location = New System.Drawing.Point(0, 271)
        Me.btnCalcular.Name = "btnCalcular"
        Me.btnCalcular.Size = New System.Drawing.Size(185, 45)
        Me.btnCalcular.TabIndex = 1
        Me.btnCalcular.Text = "Tasa del dia"
        Me.btnCalcular.UseVisualStyleBackColor = False
        '
        'btnClients
        '
        Me.btnClients.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnClients.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnClients.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnClients.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClients.ForeColor = System.Drawing.Color.White
        Me.btnClients.Location = New System.Drawing.Point(0, 226)
        Me.btnClients.Name = "btnClients"
        Me.btnClients.Size = New System.Drawing.Size(185, 45)
        Me.btnClients.TabIndex = 3
        Me.btnClients.Text = "Clientes"
        Me.btnClients.UseVisualStyleBackColor = False
        '
        'btnCambio
        '
        Me.btnCambio.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnCambio.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnCambio.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCambio.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCambio.ForeColor = System.Drawing.Color.White
        Me.btnCambio.Location = New System.Drawing.Point(0, 181)
        Me.btnCambio.Name = "btnCambio"
        Me.btnCambio.Size = New System.Drawing.Size(185, 45)
        Me.btnCambio.TabIndex = 4
        Me.btnCambio.Text = "Cambios"
        Me.btnCambio.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnHome.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnHome.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.ForeColor = System.Drawing.Color.White
        Me.btnHome.Location = New System.Drawing.Point(0, 136)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(185, 45)
        Me.btnHome.TabIndex = 0
        Me.btnHome.Text = "Inicio"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel1.Controls.Add(Me.lblUser)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(185, 136)
        Me.Panel1.TabIndex = 0
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUser.Location = New System.Drawing.Point(35, 96)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(79, 13)
        Me.lblUser.TabIndex = 0
        Me.lblUser.Text = "Usuario: ???"
        '
        'pnlFill
        '
        Me.pnlFill.BackColor = System.Drawing.Color.White
        Me.pnlFill.BackgroundImage = Global.RemeControl.My.Resources.Resources.a121da0d53673528f12400465d0dfb71
        Me.pnlFill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlFill.Location = New System.Drawing.Point(202, 0)
        Me.pnlFill.Name = "pnlFill"
        Me.pnlFill.Size = New System.Drawing.Size(706, 464)
        Me.pnlFill.TabIndex = 2
        '
        'tmrBlinkyBlinky2
        '
        Me.tmrBlinkyBlinky2.Interval = 500
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.HotTrack
        Me.ClientSize = New System.Drawing.Size(908, 484)
        Me.Controls.Add(Me.pnlFill)
        Me.Controls.Add(Me.pnlLeft)
        Me.Controls.Add(Me.pnlBottom)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "FormMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.pnlLeft.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlBottom As Panel
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents lblUser As Label
    Friend WithEvents pnlFill As Panel
    Friend WithEvents lblInfo As Label
    Protected WithEvents tmrBlinkyBlinky2 As Timer
    Friend WithEvents btnCalcular As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents btnBank As Button
    Friend WithEvents btnClients As Button
    Friend WithEvents btnCambio As Button
    Friend WithEvents btnSocio As Button
    Friend WithEvents btnGasto As Button
    Friend WithEvents btnBancoSo As Button
    Friend WithEvents btnSesion As Button
End Class
