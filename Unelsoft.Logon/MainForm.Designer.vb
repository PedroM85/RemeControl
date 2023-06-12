<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.lstConnections = New System.Windows.Forms.ListBox()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnNew = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtPassword = New Unelsoft.Logon.PlaceholderTextBox()
        Me.txtPort = New Unelsoft.Logon.PlaceholderTextBox()
        Me.txtUser = New Unelsoft.Logon.PlaceholderTextBox()
        Me.txtDatabase = New Unelsoft.Logon.PlaceholderTextBox()
        Me.TxtName = New Unelsoft.Logon.PlaceholderTextBox()
        Me.txtServer = New Unelsoft.Logon.PlaceholderTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Location = New System.Drawing.Point(237, 221)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(74, 26)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Guardar..."
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'lstConnections
        '
        Me.lstConnections.FormattingEnabled = True
        Me.lstConnections.ItemHeight = 14
        Me.lstConnections.Location = New System.Drawing.Point(12, 13)
        Me.lstConnections.Name = "lstConnections"
        Me.lstConnections.Size = New System.Drawing.Size(169, 186)
        Me.lstConnections.TabIndex = 8
        Me.lstConnections.TabStop = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.btnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDelete.Location = New System.Drawing.Point(317, 221)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(74, 26)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "Eliminar"
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnNew
        '
        Me.btnNew.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.btnNew.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.btnNew.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnNew.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNew.Location = New System.Drawing.Point(157, 221)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(74, 26)
        Me.btnNew.TabIndex = 6
        Me.btnNew.Text = "Nuevo..."
        Me.btnNew.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.btnCancel.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(162, Byte), Integer), CType(CType(216, Byte), Integer))
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(228, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(248, Byte), Integer))
        Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCancel.Location = New System.Drawing.Point(397, 221)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(74, 26)
        Me.btnCancel.TabIndex = 10
        Me.btnCancel.Text = "Salir"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(393, 177)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(78, 32)
        Me.Button1.TabIndex = 11
        Me.Button1.Text = "Salir"
        Me.Button1.UseVisualStyleBackColor = True
        Me.Button1.Visible = False
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPassword.ForeColor = System.Drawing.Color.Gray
        Me.txtPassword.Location = New System.Drawing.Point(227, 134)
        Me.txtPassword.MaxLength = 15
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Placeholder = "Contraseña:"
        Me.txtPassword.Size = New System.Drawing.Size(100, 13)
        Me.txtPassword.TabIndex = 4
        Me.txtPassword.Text = "Contraseña:"
        '
        'txtPort
        '
        Me.txtPort.BackColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtPort.ForeColor = System.Drawing.Color.Gray
        Me.txtPort.Location = New System.Drawing.Point(341, 134)
        Me.txtPort.MaxLength = 20
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Placeholder = "Puerto:"
        Me.txtPort.Size = New System.Drawing.Size(100, 13)
        Me.txtPort.TabIndex = 5
        Me.txtPort.Text = "Puerto:"
        '
        'txtUser
        '
        Me.txtUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.txtUser.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtUser.ForeColor = System.Drawing.Color.Gray
        Me.txtUser.Location = New System.Drawing.Point(341, 89)
        Me.txtUser.MaxLength = 20
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Placeholder = "Usuario:"
        Me.txtUser.Size = New System.Drawing.Size(100, 13)
        Me.txtUser.TabIndex = 3
        Me.txtUser.Text = "Usuario:"
        '
        'txtDatabase
        '
        Me.txtDatabase.BackColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.txtDatabase.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtDatabase.ForeColor = System.Drawing.Color.Gray
        Me.txtDatabase.Location = New System.Drawing.Point(225, 89)
        Me.txtDatabase.MaxLength = 30
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Placeholder = "Base de datos:"
        Me.txtDatabase.Size = New System.Drawing.Size(100, 13)
        Me.txtDatabase.TabIndex = 2
        Me.txtDatabase.Text = "Base de datos:"
        '
        'TxtName
        '
        Me.TxtName.BackColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.TxtName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtName.ForeColor = System.Drawing.Color.Gray
        Me.TxtName.Location = New System.Drawing.Point(227, 47)
        Me.TxtName.MaxLength = 20
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Placeholder = "Nombre:"
        Me.TxtName.Size = New System.Drawing.Size(100, 13)
        Me.TxtName.TabIndex = 0
        Me.TxtName.Text = "Nombre:"
        '
        'txtServer
        '
        Me.txtServer.BackColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.txtServer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtServer.ForeColor = System.Drawing.Color.Gray
        Me.txtServer.Location = New System.Drawing.Point(341, 47)
        Me.txtServer.MaxLength = 20
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Placeholder = "Ip:"
        Me.txtServer.Size = New System.Drawing.Size(100, 13)
        Me.txtServer.TabIndex = 1
        Me.txtServer.Text = "Ip:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(341, 148)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(100, 5)
        Me.Panel1.TabIndex = 12
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Location = New System.Drawing.Point(341, 104)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(100, 5)
        Me.Panel2.TabIndex = 13
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel3.Location = New System.Drawing.Point(341, 62)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(100, 5)
        Me.Panel3.TabIndex = 13
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel4.Location = New System.Drawing.Point(227, 62)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(100, 5)
        Me.Panel4.TabIndex = 13
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel5.Location = New System.Drawing.Point(225, 104)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(100, 5)
        Me.Panel5.TabIndex = 13
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(44, Byte), Integer), CType(CType(27, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel6.Location = New System.Drawing.Point(227, 148)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(100, 5)
        Me.Panel6.TabIndex = 13
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(114, Byte), Integer), CType(CType(76, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(478, 261)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.txtDatabase)
        Me.Controls.Add(Me.TxtName)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lstConnections)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.txtServer)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSave As Button
    Friend WithEvents lstConnections As ListBox
    Friend WithEvents btnDelete As Button
    Friend WithEvents btnNew As Button
    Friend WithEvents TxtName As PlaceholderTextBox
    Friend WithEvents txtServer As PlaceholderTextBox
    Friend WithEvents txtDatabase As PlaceholderTextBox
    Friend WithEvents txtUser As PlaceholderTextBox
    Friend WithEvents txtPort As PlaceholderTextBox
    Friend WithEvents txtPassword As PlaceholderTextBox
    Friend WithEvents btnCancel As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
End Class
