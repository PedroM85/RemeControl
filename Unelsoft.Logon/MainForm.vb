﻿Imports System.Configuration
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting.Contexts
Imports System.Security.Cryptography
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.Win32
Imports MySqlConnector

'Imports MySql.Data.MySqlClient

Public Class MainForm

    Private port As Integer
    Private secretKey As String = "Ju8ddPkuDNnCahG8GRPKgXAAB6z9DF6V" ' Variable para almacenar la clave secreta
    Private flagUpdate As Boolean = False
    Private connectionString As String
    Private vConn As MySqlConnector.MySqlConnection

#Region "Mover ventana"
    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function ReleaseCapture() As Boolean
    End Function

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(hWnd As IntPtr, Msg As Integer, wParam As Integer, lParam As Integer) As Integer
    End Function

    Private Sub MainForm_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        If e.Button = MouseButtons.Left Then
            ReleaseCapture()
            SendMessage(Handle, &H112, &HF012, 0)
        End If
    End Sub

#End Region
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Initial()
    End Sub
    Private Sub Initial()
        Me.Size = New Size(310, 260)
    End Sub
    Private Sub NewConnection()
        Me.Size = New Size(560, 260)
    End Sub
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            LoadConnectionList()
        Catch ex As Exception
            Dim result As DialogResult = MessageBox.Show("El archivo de configuración no contiene una cadena de conexión. ¿Desea crear el archivo o agregar una cadena de conexión?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                'CreateConfigurationFile()
            Else
                MessageBox.Show("No se pudo cargar la cadena de conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Function GetConnectionString(connectionName As String) As String
        Dim connectionStringSettings As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(connectionName)

        If connectionStringSettings IsNot Nothing Then
            Return connectionStringSettings.ConnectionString
        Else
            Throw New Exception()
        End If
    End Function

    Private Function DecryptConnectionString(encryptedConnectionString As String) As String
        Try
            Dim cipherBytes As Byte() = Convert.FromBase64String(encryptedConnectionString)

            Using aes As Aes = Aes.Create()
                aes.KeySize = 256 ' Establecer el tamaño de la clave a 256 bits
                aes.BlockSize = 128 ' Establecer el tamaño del bloque a 128 bits
                aes.Key = Encoding.UTF8.GetBytes(secretKey.Substring(0, 32)) ' Utilizar los primeros 32 caracteres de la clave
                aes.IV = Encoding.UTF8.GetBytes(secretKey.Substring(0, 16)) ' Utilizar los primeros 16 caracteres de la clave

                Using decryptor As ICryptoTransform = aes.CreateDecryptor()
                    Using ms As New MemoryStream(cipherBytes)
                        Using cs As New CryptoStream(ms, decryptor, CryptoStreamMode.Read)
                            Using reader As New StreamReader(cs)
                                Return reader.ReadToEnd()
                            End Using
                        End Using
                    End Using
                End Using
            End Using
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Private Function EncryptConnectionString(connectionString As String) As String
        Using aes As Aes = Aes.Create()
            aes.KeySize = 256 ' Establecer el tamaño de la clave a 256 bits
            aes.BlockSize = 128 ' Establecer el tamaño del bloque a 128 bits
            aes.Key = Encoding.UTF8.GetBytes(secretKey.Substring(0, 32)) ' Utilizar los primeros 32 caracteres de la clave
            aes.IV = Encoding.UTF8.GetBytes(secretKey.Substring(0, 16)) ' Utilizar los primeros 16 caracteres de la clave

            Using encryptor As ICryptoTransform = aes.CreateEncryptor()
                Using ms As New MemoryStream()
                    Using cs As New CryptoStream(ms, encryptor, CryptoStreamMode.Write)
                        Using writer As New StreamWriter(cs)
                            writer.Write(connectionString)
                        End Using
                    End Using

                    Dim cipherBytes As Byte() = ms.ToArray()
                    Return Convert.ToBase64String(cipherBytes)
                End Using
            End Using
        End Using
    End Function

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            UpdateConnectionString()
            LoadConnectionList()
            'Restaura el form a su tamano
            Initial()
            btnNew.Enabled = True
            If flagUpdate Then
                MessageBox.Show("La cadena de conexión se ha actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
                'Else
                '    MessageBox.Show("El/los campo(s) no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Return
            End If
        Catch ex As Exception
            MessageBox.Show("No se pudo guardar la cadena de conexión.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UpdateConnectionString()
        Dim configFile As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)

        Dim server As String = txtServer.Text
        Dim database As String = txtDatabase.Text
        Dim user As String = txtUser.Text
        Dim password As String = txtPassword.Text

        If IsTextBoxEmpty(txtServer) Then
            MessageBox.Show("El campo 'Servidor' no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            flagUpdate = False
            Return
        End If

        If IsTextBoxEmpty(txtDatabase) Then
            MessageBox.Show("El campo 'Base de datos' no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            flagUpdate = False
            Return
        End If

        If IsTextBoxEmpty(txtUser) Then
            MessageBox.Show("El campo 'Usuario' no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            flagUpdate = False
            Return
        End If

        'If IsTextBoxEmpty(txtPassword) Then
        '    MessageBox.Show("El campo 'Contraseña' no puede estar vacío.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    flagUpdate = False
        '    Return
        'End If

        If Not Integer.TryParse(txtPort.Text, port) Then
            MessageBox.Show("El puerto debe ser un número válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim connectionString As String = $"Server={server};Database={database};UserID={user};Password={password};Port={port};"
        Dim encryptedConnectionString As String = EncryptConnectionString(connectionString)

        Dim providerName As String = "MySql.Data.MySqlClient"

        Dim connectionSettings As ConnectionStringSettings = configFile.ConnectionStrings.ConnectionStrings(TxtName.Text)
        If connectionSettings IsNot Nothing Then
            connectionSettings.ConnectionString = encryptedConnectionString
            connectionSettings.ProviderName = providerName
        Else
            connectionSettings = New ConnectionStringSettings(TxtName.Text, encryptedConnectionString, providerName)
            configFile.ConnectionStrings.ConnectionStrings.Add(connectionSettings)
        End If

        configFile.Save()

        ClearFields()
        lstConnections.Items.Clear()

        flagUpdate = True
    End Sub
    Private Function IsTextBoxEmpty(textBox As System.Windows.Forms.TextBox) As Boolean
        Return String.IsNullOrEmpty(textBox.Text)
    End Function
    Private Sub LoadConnectionList()
        Dim configFile As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
        Dim connectionStrings As ConnectionStringSettingsCollection = configFile.ConnectionStrings.ConnectionStrings

        For Each connection As ConnectionStringSettings In connectionStrings
            lstConnections.Items.Add(connection.Name)
        Next
    End Sub

    Private Sub lstConnections_DoubleClick(sender As Object, e As EventArgs) Handles lstConnections.DoubleClick

        If lstConnections.SelectedItem IsNot Nothing Then
            'para mostrar los campos
            NewConnection()
            TxtName.Enabled = False
            Dim selectedConnectionName As String = lstConnections.SelectedItem.ToString()

            Dim configFile As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Dim selectedConnection As ConnectionStringSettings = configFile.ConnectionStrings.ConnectionStrings(selectedConnectionName)

            If selectedConnection IsNot Nothing Then
                Dim encryptedConnectionString As String = selectedConnection.ConnectionString
                Dim decryptedConnectionString As String = DecryptConnectionString(encryptedConnectionString)

                Dim builder As New MySqlConnectionStringBuilder(decryptedConnectionString)
                TxtName.Text = selectedConnectionName
                txtServer.Text = builder.Server
                txtDatabase.Text = builder.Database
                txtUser.Text = builder.UserID
                txtPassword.Text = builder.Password
                txtPort.Text = builder.Port.ToString()
            End If
        Else
            MessageBox.Show("Seleccione una conexión para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub
    Private Sub ClearFields()
        TxtName.Text = String.Empty
        TxtName.Enabled = True
        txtServer.Text = String.Empty
        txtDatabase.Text = String.Empty
        txtUser.Text = String.Empty
        txtPassword.Text = String.Empty
        'txtPort.Text = String.Empty

        txtPassword.Visible = True
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If lstConnections.SelectedItem IsNot Nothing Then

            Dim selectedConnectionName As String = lstConnections.SelectedItem.ToString()

            Dim configFile As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Dim connectionStrings As ConnectionStringSettingsCollection = configFile.ConnectionStrings.ConnectionStrings

            Dim selectedConnection As ConnectionStringSettings = connectionStrings(selectedConnectionName)

            If selectedConnection IsNot Nothing Then
                connectionStrings.Remove(selectedConnection)

                ' Guardar los cambios en el archivo de configuración
                configFile.Save(ConfigurationSaveMode.Modified)

                ' Limpiar el ListBox
                lstConnections.Items.Clear()

                ' Actualizar la lista de conexiones en el ListBox
                LoadConnectionList()

                ' Limpiar los TextBox después de eliminar la conexión
                ClearFields()
            End If
        Else
            MessageBox.Show("Seleccione una conexión para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        'Amplia el form
        NewConnection()

        ClearFields()
        TxtName.Select()
        btnNew.Enabled = False
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub Get45PlusFromRegistry()
        Const subkey As String = "SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\"

        Using ndpKey As RegistryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey)
            If ndpKey IsNot Nothing AndAlso ndpKey.GetValue("Release") IsNot Nothing Then
                Console.WriteLine($".NET Framework Version: {CheckFor45PlusVersion(ndpKey.GetValue("Release"))}")
            Else
                Console.WriteLine(".NET Framework Version 4.5 or later is not detected.")
            End If
        End Using
    End Sub

    ' Checking the version using >= enables forward compatibility.
    Private Function CheckFor45PlusVersion(releaseKey As Integer) As String
        If releaseKey >= 533320 Then
            Return "4.8.1 or later"
        ElseIf releaseKey >= 528040 Then
            Return "4.8"
        ElseIf releaseKey >= 461808 Then
            Return "4.7.2"
        ElseIf releaseKey >= 461308 Then
            Return "4.7.1"
        ElseIf releaseKey >= 460798 Then
            Return "4.7"
        ElseIf releaseKey >= 394802 Then
            Return "4.6.2"
        ElseIf releaseKey >= 394254 Then
            Return "4.6.1"
        ElseIf releaseKey >= 393295 Then
            Return "4.6"
        ElseIf releaseKey >= 379893 Then
            Return "4.5.2"
        ElseIf releaseKey >= 378675 Then
            Return "4.5.1"
        ElseIf releaseKey >= 378389 Then
            Return "4.5"
        End If
        ' This code should never execute. A non-null release key should mean
        ' that 4.5 or later is installed.
        Return "No 4.5 or later version detected"
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Get45PlusFromRegistry()
    End Sub
    Private Sub ApplyNumericInputRestriction(textBox As System.Windows.Forms.TextBox)
        AddHandler textBox.KeyPress, Sub(sender As Object, e As KeyPressEventArgs)
                                         ' Permitir solo números y puntos
                                         If Not Char.IsDigit(e.KeyChar) AndAlso e.KeyChar <> "." AndAlso e.KeyChar <> ControlChars.Back Then
                                             e.Handled = True
                                         End If
                                     End Sub
    End Sub
    Private Sub txtServer_KeyPress(sender As Object, e As KeyPressEventArgs)
        ApplyNumericInputRestriction(txtServer)
    End Sub

    Private Sub txtPort_KeyPress(sender As Object, e As KeyPressEventArgs)
        ApplyNumericInputRestriction(txtPort)
    End Sub

    Private Sub btnTester_Click(sender As Object, e As EventArgs) Handles btnTester.Click
        If lstConnections.SelectedItem IsNot Nothing Then

            Try
                'connectionString = "server=" & txtServer.Text & ";user=" & txtUser.Text & ";database=" & txtDatabase.Text & ";password=" & txtPassword.Text & ";"
                connectionString = "Server=" & txtServer.Text & "; User ID=" & txtUser.Text & "; password=" & txtPassword.Text & "; database=" & txtDatabase.Text & "; port=" & txtPort.Text & "; SslMode=Preferred"

                vConn = New MySqlConnection(connectionString)
                vConn.Open()

                lblStatus.Text = "Status: Connected"

            Catch ex As Exception
                lblStatus.Text = "Status: Failed"
                connectionString = ""
                vConn = Nothing
                MsgBox("One or more properties are invalid",
        MsgBoxStyle.Critical, "MySql Connection Tester")
                lblStatus.Text = "Status: Disconnected"

                Exit Sub
            End Try
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If lstConnections.SelectedItem IsNot Nothing Then

            NewConnection()
            lstConnections_DoubleClick(sender, e)
        End If

    End Sub



    Private Sub lstConnections_Click(sender As Object, e As EventArgs) Handles lstConnections.Click
        If lstConnections.SelectedItem IsNot Nothing Then
            TxtName.Enabled = False
            Dim selectedConnectionName As String = lstConnections.SelectedItem.ToString()

            Dim configFile As Configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None)
            Dim selectedConnection As ConnectionStringSettings = configFile.ConnectionStrings.ConnectionStrings(selectedConnectionName)

            If selectedConnection IsNot Nothing Then
                Dim encryptedConnectionString As String = selectedConnection.ConnectionString
                Dim decryptedConnectionString As String = DecryptConnectionString(encryptedConnectionString)

                Dim builder As New MySqlConnectionStringBuilder(decryptedConnectionString)
                TxtName.Text = selectedConnectionName
                txtServer.Text = builder.Server
                txtDatabase.Text = builder.Database
                txtUser.Text = builder.UserID
                txtPassword.Text = builder.Password
                txtPort.Text = builder.Port.ToString()
            End If

        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Initial()
        btnNew.Enabled = True
    End Sub

End Class