<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SessionDetails
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblClosed = New System.Windows.Forms.Label()
        Me.lblOpenedValue = New System.Windows.Forms.Label()
        Me.lblOpened = New System.Windows.Forms.Label()
        Me.lblTerminalValue = New System.Windows.Forms.Label()
        Me.lblTerminal = New System.Windows.Forms.Label()
        Me.lblUserValue = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.lblClosedValue = New System.Windows.Forms.Label()
        Me.btnAccept = New System.Windows.Forms.Button()
        Me.btnReOpen = New System.Windows.Forms.Button()
        Me.btnSessionReport = New System.Windows.Forms.Button()
        Me.btnCloseSession = New System.Windows.Forms.Button()
        Me.btnModify = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblClosed
        '
        Me.lblClosed.Location = New System.Drawing.Point(300, 69)
        Me.lblClosed.Name = "lblClosed"
        Me.lblClosed.Size = New System.Drawing.Size(72, 19)
        Me.lblClosed.TabIndex = 37
        Me.lblClosed.Text = "Cierre:"
        Me.lblClosed.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOpenedValue
        '
        Me.lblOpenedValue.Location = New System.Drawing.Point(372, 45)
        Me.lblOpenedValue.Name = "lblOpenedValue"
        Me.lblOpenedValue.Size = New System.Drawing.Size(144, 19)
        Me.lblOpenedValue.TabIndex = 36
        Me.lblOpenedValue.Text = "???"
        Me.lblOpenedValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOpened
        '
        Me.lblOpened.Location = New System.Drawing.Point(300, 45)
        Me.lblOpened.Name = "lblOpened"
        Me.lblOpened.Size = New System.Drawing.Size(72, 19)
        Me.lblOpened.TabIndex = 35
        Me.lblOpened.Text = "Comienzo:"
        Me.lblOpened.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTerminalValue
        '
        Me.lblTerminalValue.Location = New System.Drawing.Point(92, 69)
        Me.lblTerminalValue.Name = "lblTerminalValue"
        Me.lblTerminalValue.Size = New System.Drawing.Size(208, 19)
        Me.lblTerminalValue.TabIndex = 34
        Me.lblTerminalValue.Text = "???"
        Me.lblTerminalValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTerminal
        '
        Me.lblTerminal.Location = New System.Drawing.Point(20, 69)
        Me.lblTerminal.Name = "lblTerminal"
        Me.lblTerminal.Size = New System.Drawing.Size(72, 19)
        Me.lblTerminal.TabIndex = 33
        Me.lblTerminal.Text = "Terminal:"
        Me.lblTerminal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUserValue
        '
        Me.lblUserValue.Location = New System.Drawing.Point(92, 45)
        Me.lblUserValue.Name = "lblUserValue"
        Me.lblUserValue.Size = New System.Drawing.Size(208, 19)
        Me.lblUserValue.TabIndex = 32
        Me.lblUserValue.Text = "???"
        Me.lblUserValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUser
        '
        Me.lblUser.Location = New System.Drawing.Point(20, 45)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(72, 19)
        Me.lblUser.TabIndex = 31
        Me.lblUser.Text = "Usuario:"
        Me.lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCaption
        '
        Me.lblCaption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.lblCaption.Location = New System.Drawing.Point(12, 13)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(374, 24)
        Me.lblCaption.TabIndex = 30
        Me.lblCaption.Text = "Detalle de turnos por usuario"
        '
        'lblClosedValue
        '
        Me.lblClosedValue.Location = New System.Drawing.Point(372, 69)
        Me.lblClosedValue.Name = "lblClosedValue"
        Me.lblClosedValue.Size = New System.Drawing.Size(152, 19)
        Me.lblClosedValue.TabIndex = 38
        Me.lblClosedValue.Text = "???"
        Me.lblClosedValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAccept
        '
        Me.btnAccept.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAccept.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.btnAccept.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccept.Location = New System.Drawing.Point(14, 411)
        Me.btnAccept.Name = "btnAccept"
        Me.btnAccept.Size = New System.Drawing.Size(72, 21)
        Me.btnAccept.TabIndex = 47
        Me.btnAccept.Text = "Aceptar"
        Me.btnAccept.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAccept.UseVisualStyleBackColor = False
        Me.btnAccept.Visible = False
        '
        'btnReOpen
        '
        Me.btnReOpen.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnReOpen.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.btnReOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReOpen.Location = New System.Drawing.Point(310, 438)
        Me.btnReOpen.Name = "btnReOpen"
        Me.btnReOpen.Size = New System.Drawing.Size(88, 21)
        Me.btnReOpen.TabIndex = 45
        Me.btnReOpen.Text = "Reabrir turno"
        Me.btnReOpen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReOpen.UseVisualStyleBackColor = False
        '
        'btnSessionReport
        '
        Me.btnSessionReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSessionReport.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.btnSessionReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSessionReport.Location = New System.Drawing.Point(454, 438)
        Me.btnSessionReport.Name = "btnSessionReport"
        Me.btnSessionReport.Size = New System.Drawing.Size(144, 21)
        Me.btnSessionReport.TabIndex = 46
        Me.btnSessionReport.Text = "Informe de fin de turno"
        Me.btnSessionReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSessionReport.UseVisualStyleBackColor = False
        '
        'btnCloseSession
        '
        Me.btnCloseSession.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCloseSession.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.btnCloseSession.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCloseSession.Location = New System.Drawing.Point(214, 438)
        Me.btnCloseSession.Name = "btnCloseSession"
        Me.btnCloseSession.Size = New System.Drawing.Size(88, 21)
        Me.btnCloseSession.TabIndex = 44
        Me.btnCloseSession.Text = "Cerrar turno"
        Me.btnCloseSession.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCloseSession.UseVisualStyleBackColor = False
        '
        'btnModify
        '
        Me.btnModify.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnModify.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.btnModify.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnModify.Location = New System.Drawing.Point(131, 438)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(72, 21)
        Me.btnModify.TabIndex = 42
        Me.btnModify.Text = "Modificar"
        Me.btnModify.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnModify.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBack.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(205, Byte), Integer))
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Location = New System.Drawing.Point(14, 438)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(70, 21)
        Me.btnBack.TabIndex = 40
        Me.btnBack.Text = "< Atrás"
        Me.btnBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.AllowUserToResizeColumns = False
        Me.dgvView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvView.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvView.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvView.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvView.Location = New System.Drawing.Point(23, 99)
        Me.dgvView.MultiSelect = False
        Me.dgvView.Name = "dgvView"
        Me.dgvView.ReadOnly = True
        Me.dgvView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvView.RowHeadersVisible = False
        Me.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvView.Size = New System.Drawing.Size(548, 281)
        Me.dgvView.TabIndex = 48
        '
        'SessionDetails
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.dgvView)
        Me.Controls.Add(Me.btnAccept)
        Me.Controls.Add(Me.btnReOpen)
        Me.Controls.Add(Me.btnSessionReport)
        Me.Controls.Add(Me.btnCloseSession)
        Me.Controls.Add(Me.btnModify)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.lblClosed)
        Me.Controls.Add(Me.lblOpenedValue)
        Me.Controls.Add(Me.lblOpened)
        Me.Controls.Add(Me.lblTerminalValue)
        Me.Controls.Add(Me.lblTerminal)
        Me.Controls.Add(Me.lblUserValue)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.lblClosedValue)
        Me.Name = "SessionDetails"
        Me.Size = New System.Drawing.Size(646, 479)
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblClosed As Label
    Friend WithEvents lblOpenedValue As Label
    Friend WithEvents lblOpened As Label
    Friend WithEvents lblTerminalValue As Label
    Friend WithEvents lblTerminal As Label
    Friend WithEvents lblUserValue As Label
    Friend WithEvents lblUser As Label
    Friend WithEvents lblCaption As Label
    Friend WithEvents lblClosedValue As Label
    Friend WithEvents btnAccept As Button
    Friend WithEvents btnReOpen As Button
    Friend WithEvents btnSessionReport As Button
    Friend WithEvents btnCloseSession As Button
    Friend WithEvents btnModify As Button
    Friend WithEvents btnBack As Button
    Protected WithEvents dgvView As DataGridView
End Class
