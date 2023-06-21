<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EWMessageBox
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EWMessageBox))
        Me.picInformation = New System.Windows.Forms.PictureBox()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.btn3 = New System.Windows.Forms.Button()
        Me.btn2 = New System.Windows.Forms.Button()
        Me.btn1 = New System.Windows.Forms.Button()
        Me.picExclamation = New System.Windows.Forms.PictureBox()
        Me.picError = New System.Windows.Forms.PictureBox()
        Me.picQuestion = New System.Windows.Forms.PictureBox()
        CType(Me.picInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picExclamation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picError, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picQuestion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picInformation
        '
        Me.picInformation.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.picInformation.Image = CType(resources.GetObject("picInformation.Image"), System.Drawing.Image)
        Me.picInformation.Location = New System.Drawing.Point(31, 50)
        Me.picInformation.Name = "picInformation"
        Me.picInformation.Size = New System.Drawing.Size(32, 32)
        Me.picInformation.TabIndex = 10
        Me.picInformation.TabStop = False
        Me.picInformation.Visible = False
        '
        'lblInfo
        '
        Me.lblInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.lblInfo.Location = New System.Drawing.Point(92, 36)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(304, 66)
        Me.lblInfo.TabIndex = 9
        Me.lblInfo.Text = "???"
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btn3
        '
        Me.btn3.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.btn3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn3.Location = New System.Drawing.Point(302, 115)
        Me.btn3.Name = "btn3"
        Me.btn3.Size = New System.Drawing.Size(80, 22)
        Me.btn3.TabIndex = 13
        Me.btn3.Text = "3???"
        Me.btn3.UseVisualStyleBackColor = False
        Me.btn3.Visible = False
        '
        'btn2
        '
        Me.btn2.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.btn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn2.Location = New System.Drawing.Point(206, 115)
        Me.btn2.Name = "btn2"
        Me.btn2.Size = New System.Drawing.Size(80, 22)
        Me.btn2.TabIndex = 12
        Me.btn2.Text = "2???"
        Me.btn2.UseVisualStyleBackColor = False
        Me.btn2.Visible = False
        '
        'btn1
        '
        Me.btn1.BackColor = System.Drawing.Color.FromArgb(CType(CType(222, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(206, Byte), Integer))
        Me.btn1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn1.Location = New System.Drawing.Point(110, 115)
        Me.btn1.Name = "btn1"
        Me.btn1.Size = New System.Drawing.Size(80, 22)
        Me.btn1.TabIndex = 11
        Me.btn1.Text = "1???"
        Me.btn1.UseVisualStyleBackColor = False
        Me.btn1.Visible = False
        '
        'picExclamation
        '
        Me.picExclamation.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.picExclamation.Image = CType(resources.GetObject("picExclamation.Image"), System.Drawing.Image)
        Me.picExclamation.Location = New System.Drawing.Point(31, 50)
        Me.picExclamation.Name = "picExclamation"
        Me.picExclamation.Size = New System.Drawing.Size(32, 32)
        Me.picExclamation.TabIndex = 14
        Me.picExclamation.TabStop = False
        Me.picExclamation.Visible = False
        '
        'picError
        '
        Me.picError.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.picError.Image = CType(resources.GetObject("picError.Image"), System.Drawing.Image)
        Me.picError.Location = New System.Drawing.Point(31, 50)
        Me.picError.Name = "picError"
        Me.picError.Size = New System.Drawing.Size(32, 32)
        Me.picError.TabIndex = 15
        Me.picError.TabStop = False
        Me.picError.Visible = False
        '
        'picQuestion
        '
        Me.picQuestion.BackColor = System.Drawing.Color.FromArgb(CType(CType(252, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(242, Byte), Integer))
        Me.picQuestion.Image = CType(resources.GetObject("picQuestion.Image"), System.Drawing.Image)
        Me.picQuestion.Location = New System.Drawing.Point(31, 50)
        Me.picQuestion.Name = "picQuestion"
        Me.picQuestion.Size = New System.Drawing.Size(32, 32)
        Me.picQuestion.TabIndex = 16
        Me.picQuestion.TabStop = False
        Me.picQuestion.Visible = False
        '
        'EWMessageBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(486, 149)
        Me.Controls.Add(Me.picQuestion)
        Me.Controls.Add(Me.picError)
        Me.Controls.Add(Me.picExclamation)
        Me.Controls.Add(Me.btn3)
        Me.Controls.Add(Me.btn2)
        Me.Controls.Add(Me.btn1)
        Me.Controls.Add(Me.picInformation)
        Me.Controls.Add(Me.lblInfo)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "EWMessageBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "EWMessageBox"
        CType(Me.picInformation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picExclamation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picError, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picQuestion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents picInformation As Windows.Forms.PictureBox
    Friend WithEvents lblInfo As Windows.Forms.Label
    Friend WithEvents btn3 As Windows.Forms.Button
    Friend WithEvents btn2 As Windows.Forms.Button
    Friend WithEvents btn1 As Windows.Forms.Button
    Friend WithEvents picExclamation As Windows.Forms.PictureBox
    Friend WithEvents picError As Windows.Forms.PictureBox
    Friend WithEvents picQuestion As Windows.Forms.PictureBox
End Class
