<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.txtPOSCode = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.cboWindowsPrinter = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtCode
        '
        Me.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCode.Location = New System.Drawing.Point(64, 46)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(100, 20)
        Me.txtCode.TabIndex = 0
        '
        'txtPOSCode
        '
        Me.txtPOSCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPOSCode.Location = New System.Drawing.Point(239, 46)
        Me.txtPOSCode.Name = "txtPOSCode"
        Me.txtPOSCode.Size = New System.Drawing.Size(100, 20)
        Me.txtPOSCode.TabIndex = 1
        '
        'txtName
        '
        Me.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtName.Location = New System.Drawing.Point(64, 91)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(275, 20)
        Me.txtName.TabIndex = 2
        '
        'cboWindowsPrinter
        '
        Me.cboWindowsPrinter.FormattingEnabled = True
        Me.cboWindowsPrinter.Location = New System.Drawing.Point(64, 138)
        Me.cboWindowsPrinter.Name = "cboWindowsPrinter"
        Me.cboWindowsPrinter.Size = New System.Drawing.Size(275, 22)
        Me.cboWindowsPrinter.TabIndex = 3
        '
        'ConfigControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.cboWindowsPrinter)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtPOSCode)
        Me.Controls.Add(Me.txtCode)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ConfigControl"
        Me.Size = New System.Drawing.Size(429, 490)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCode As TextBox
    Friend WithEvents txtPOSCode As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents cboWindowsPrinter As ComboBox
End Class
