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
        Me.PlaceholderTextBox1 = New Unelsoft.Logon.PlaceholderTextBox()
        Me.txtPassword = New Unelsoft.Logon.PlaceholderTextBox()
        Me.txtPort = New Unelsoft.Logon.PlaceholderTextBox()
        Me.txtUser = New Unelsoft.Logon.PlaceholderTextBox()
        Me.txtDatabase = New Unelsoft.Logon.PlaceholderTextBox()
        Me.TxtName = New Unelsoft.Logon.PlaceholderTextBox()
        Me.txtServer = New Unelsoft.Logon.PlaceholderTextBox()
        Me.SuspendLayout()
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(304, 200)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(78, 30)
        Me.btnSave.TabIndex = 7
        Me.btnSave.Text = "Guardar..."
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'lstConnections
        '
        Me.lstConnections.FormattingEnabled = True
        Me.lstConnections.Location = New System.Drawing.Point(12, 12)
        Me.lstConnections.Name = "lstConnections"
        Me.lstConnections.Size = New System.Drawing.Size(169, 186)
        Me.lstConnections.TabIndex = 8
        Me.lstConnections.TabStop = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(388, 200)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(78, 30)
        Me.btnDelete.TabIndex = 8
        Me.btnDelete.Text = "Eliminar"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(220, 200)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(78, 30)
        Me.btnNew.TabIndex = 6
        Me.btnNew.Text = "Nuevo..."
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'PlaceholderTextBox1
        '
        Me.PlaceholderTextBox1.ForeColor = System.Drawing.Color.Gray
        Me.PlaceholderTextBox1.Location = New System.Drawing.Point(227, 150)
        Me.PlaceholderTextBox1.Name = "PlaceholderTextBox1"
        Me.PlaceholderTextBox1.Placeholder = "Contraseña:"
        Me.PlaceholderTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.PlaceholderTextBox1.TabIndex = 9
        Me.PlaceholderTextBox1.Text = "Contraseña:"
        '
        'txtPassword
        '
        Me.txtPassword.ForeColor = System.Drawing.Color.Gray
        Me.txtPassword.Location = New System.Drawing.Point(227, 124)
        Me.txtPassword.MaxLength = 15
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Placeholder = ""
        Me.txtPassword.Size = New System.Drawing.Size(100, 20)
        Me.txtPassword.TabIndex = 4
        '
        'txtPort
        '
        Me.txtPort.ForeColor = System.Drawing.Color.Gray
        Me.txtPort.Location = New System.Drawing.Point(341, 124)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Placeholder = "Puerto:"
        Me.txtPort.Size = New System.Drawing.Size(100, 20)
        Me.txtPort.TabIndex = 5
        Me.txtPort.Text = "Puerto:"
        '
        'txtUser
        '
        Me.txtUser.ForeColor = System.Drawing.Color.Gray
        Me.txtUser.Location = New System.Drawing.Point(341, 83)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Placeholder = "Usuario:"
        Me.txtUser.Size = New System.Drawing.Size(100, 20)
        Me.txtUser.TabIndex = 3
        Me.txtUser.Text = "Usuario:"
        '
        'txtDatabase
        '
        Me.txtDatabase.ForeColor = System.Drawing.Color.Gray
        Me.txtDatabase.Location = New System.Drawing.Point(227, 83)
        Me.txtDatabase.Name = "txtDatabase"
        Me.txtDatabase.Placeholder = "Base de datos:"
        Me.txtDatabase.Size = New System.Drawing.Size(100, 20)
        Me.txtDatabase.TabIndex = 2
        Me.txtDatabase.Text = "Base de datos:"
        '
        'TxtName
        '
        Me.TxtName.ForeColor = System.Drawing.Color.Gray
        Me.TxtName.Location = New System.Drawing.Point(227, 44)
        Me.TxtName.Name = "TxtName"
        Me.TxtName.Placeholder = "Nombre:"
        Me.TxtName.Size = New System.Drawing.Size(100, 20)
        Me.TxtName.TabIndex = 0
        Me.TxtName.Text = "Nombre:"
        '
        'txtServer
        '
        Me.txtServer.ForeColor = System.Drawing.Color.Gray
        Me.txtServer.Location = New System.Drawing.Point(341, 44)
        Me.txtServer.Name = "txtServer"
        Me.txtServer.Placeholder = "Ip:"
        Me.txtServer.Size = New System.Drawing.Size(100, 20)
        Me.txtServer.TabIndex = 1
        Me.txtServer.Text = "Ip:"
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(478, 242)
        Me.Controls.Add(Me.PlaceholderTextBox1)
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
    Friend WithEvents PlaceholderTextBox1 As PlaceholderTextBox
End Class
