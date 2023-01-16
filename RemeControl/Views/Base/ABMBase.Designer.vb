<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ABMBase
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
        Me.pnlLeft = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.lblRequiredFields = New System.Windows.Forms.Label()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.pnlTitle0 = New System.Windows.Forms.Panel()
        Me.lblTitle0 = New System.Windows.Forms.Label()
        Me.pnlControls0 = New System.Windows.Forms.Panel()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.pnlLeft.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.pnlBottom.SuspendLayout()
        Me.pnlTitle0.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlLeft
        '
        Me.pnlLeft.BackColor = System.Drawing.SystemColors.Highlight
        Me.pnlLeft.Controls.Add(Me.Panel3)
        Me.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlLeft.Location = New System.Drawing.Point(0, 0)
        Me.pnlLeft.Name = "pnlLeft"
        Me.pnlLeft.Size = New System.Drawing.Size(132, 402)
        Me.pnlLeft.TabIndex = 0
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.Panel3.Controls.Add(Me.lblDate)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(132, 36)
        Me.Panel3.TabIndex = 3
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Location = New System.Drawing.Point(47, 12)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(40, 13)
        Me.lblDate.TabIndex = 5
        Me.lblDate.Text = "lblDate"
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.SystemColors.Highlight
        Me.pnlBottom.Controls.Add(Me.lblRequiredFields)
        Me.pnlBottom.Controls.Add(Me.btnCancel)
        Me.pnlBottom.Controls.Add(Me.btnOk)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(132, 353)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(556, 49)
        Me.pnlBottom.TabIndex = 1
        '
        'lblRequiredFields
        '
        Me.lblRequiredFields.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblRequiredFields.AutoSize = True
        Me.lblRequiredFields.Location = New System.Drawing.Point(448, 22)
        Me.lblRequiredFields.Name = "lblRequiredFields"
        Me.lblRequiredFields.Size = New System.Drawing.Size(104, 13)
        Me.lblRequiredFields.TabIndex = 6
        Me.lblRequiredFields.Text = "* Campos requeridos"
        Me.lblRequiredFields.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancel.Location = New System.Drawing.Point(109, 12)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "&Cancelar"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnOk
        '
        Me.btnOk.BackColor = System.Drawing.SystemColors.Control
        Me.btnOk.Location = New System.Drawing.Point(28, 12)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "&Aceptar"
        Me.btnOk.UseVisualStyleBackColor = False
        '
        'pnlTitle0
        '
        Me.pnlTitle0.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnlTitle0.Controls.Add(Me.lblTitle0)
        Me.pnlTitle0.Location = New System.Drawing.Point(161, 70)
        Me.pnlTitle0.Name = "pnlTitle0"
        Me.pnlTitle0.Size = New System.Drawing.Size(524, 25)
        Me.pnlTitle0.TabIndex = 2
        '
        'lblTitle0
        '
        Me.lblTitle0.AutoSize = True
        Me.lblTitle0.Location = New System.Drawing.Point(11, 6)
        Me.lblTitle0.Name = "lblTitle0"
        Me.lblTitle0.Size = New System.Drawing.Size(43, 13)
        Me.lblTitle0.TabIndex = 5
        Me.lblTitle0.Text = "lblTitle0"
        '
        'pnlControls0
        '
        Me.pnlControls0.BackColor = System.Drawing.Color.White
        Me.pnlControls0.Location = New System.Drawing.Point(160, 95)
        Me.pnlControls0.Name = "pnlControls0"
        Me.pnlControls0.Size = New System.Drawing.Size(524, 160)
        Me.pnlControls0.TabIndex = 3
        '
        'lblCaption
        '
        Me.lblCaption.AutoSize = True
        Me.lblCaption.Location = New System.Drawing.Point(158, 41)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(53, 13)
        Me.lblCaption.TabIndex = 4
        Me.lblCaption.Text = "lblCaption"
        '
        'TasaBase
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.pnlLeft)
        Me.Controls.Add(Me.pnlControls0)
        Me.Controls.Add(Me.pnlTitle0)
        Me.Name = "TasaBase"
        Me.Size = New System.Drawing.Size(688, 402)
        Me.pnlLeft.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.pnlBottom.ResumeLayout(False)
        Me.pnlBottom.PerformLayout()
        Me.pnlTitle0.ResumeLayout(False)
        Me.pnlTitle0.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnlLeft As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents lblDate As Label
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents lblRequiredFields As Label
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnOk As Button
    Friend WithEvents lblTitle0 As Label
    Friend WithEvents lblCaption As Label
    Protected WithEvents pnlControls0 As Panel
    Protected WithEvents pnlTitle0 As Panel
End Class
