Imports System.Configuration
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports MySql.Data.MySqlClient
Imports System.Windows.Forms
Imports Unelsoft.AccessController.My
Imports MySqlConnector

Public Class ConnectionInfo

    Public Property Name As String
    Public Property Server As String
    Public Property Database As String
    Public Property UserId As String
    Public Property Password As String
    Public Property FileName As String
    Public Property SPID As Integer
    Public Property Provider As String
    Public Property Port As Integer

    Private secretKey As String = "Ju8ddPkuDNnCahG8GRPKgXAAB6z9DF6V" ' Variable para almacenar la clave secreta
    Public Sub New()
        Me.New(Application.StartupPath)
    End Sub
    Public Sub New(LogonPath As String)
        FileName = LogonPath & "\Unelsoft.Logon.exe.Config"

    End Sub
    Public Overloads Function GetConnectionInfo(ByVal sName As String) As Boolean
        Return Connection(Server)
    End Function

    Public ReadOnly Property OLEDBConnectionString(Optional ByVal AppName As String = Nothing, Optional ByVal AlternativeDB As String = Nothing) As String
        Get
            If AppName Is Nothing Then
                AppName = "Unelsoft"
            End If
            If AlternativeDB Is Nothing Then
                AlternativeDB = Database
            End If
            'aca eboc
            Return String.Format("Provider={5};Password={3};Persist Security Info=True;User ID={2};Initial Catalog={1};Data Source={0};Application Name={4}", New String() {Server, AlternativeDB, UserId, Password, AppName, Provider})
            'Return String.Format("Provider=SQLOLEDB.1;Password={3};Persist Security Info=True;User ID={2};Initial Catalog={1};Data Source={0};Application Name={4}", New String() {sServer, AlternativeDB, sUserId, sPassword, AppName})
        End Get
    End Property
    Public ReadOnly Property MySQLConnectionString(Optional ByVal AppName As String = Nothing, Optional ByVal AlternativeDB As String = Nothing) As String
        Get
            If AppName Is Nothing Then
                AppName = "Unelsoft"
            End If
            If AlternativeDB Is Nothing Then
                AlternativeDB = Database
            End If

            '' Parámetros de conexión para MySQL
            'Dim server As String = "nombre_del_servidor"
            'Dim database As String = AlternativeDB
            'Dim username As String = "nombre_de_usuario"
            'Dim password As String = "contraseña"

            '' Opcionalmente, puedes ajustar más parámetros según tus necesidades
            'Dim port As Integer = 3306 ' Puerto predeterminado de MySQL

            ' Cadena de conexión para MySQL
            Dim connectionString As String = String.Format("Server={0}; User ID={1}; password={2}; database={3}; port={4}; SslMode=Preferred", Server, UserId, Password, Database, Port)
            'Dim connectionString As String = String.Format("Server={0};Port={1};Database={2};uid={3};password={4};", Server, Port, Database, UserId, Password)

            Return connectionString
        End Get
    End Property

    Private Function Connection(server1) As Boolean
        Dim selectedConnectionName As String = GetConnection()

        ' Ruta al archivo Unelsoft.Logon.exe.config
        Dim pathToConfigFile As String = FileName

        Dim configFileMap As New ExeConfigurationFileMap()
        configFileMap.ExeConfigFilename = pathToConfigFile
        Dim configFile As Configuration = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None)

        Dim selectedConnection As ConnectionStringSettings = configFile.ConnectionStrings.ConnectionStrings(selectedConnectionName)

        If selectedConnection IsNot Nothing Then
            Dim encryptedConnectionString As String = selectedConnection.ConnectionString
            Dim decryptedConnectionString As String = DecryptConnectionString(encryptedConnectionString)

            Dim builder As New MySql.Data.MySqlClient.MySqlConnectionStringBuilder(decryptedConnectionString)

            Server = builder.Server
            Database = builder.Database
            UserId = builder.UserID
            Password = builder.Password
            Port = builder.Port.ToString()
            Return True
        Else
            Return False
        End If
    End Function
    Public Overloads Function GetConnection() As String

        'Dim selectedConnectionName As String = ConfigurationManager.AppSettings("ConnectionName")

        'Try
        '    Dim pathToConfigFile As String = FileName2
        '    Dim configFileMap As New ExeConfigurationFileMap()
        '    configFileMap.ExeConfigFilename = pathToConfigFile
        '    Dim configFile As Configuration = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None)


        '    Dim selectedConnection As ConnectionStringSettings = configFile.ConnectionStrings.ConnectionStrings(selectedConnectionName)

        '    Return selectedConnection.ToString
        'Catch ex As Exception
        'End Try
        'Dim connectionName As String = ConfigurationManager.AppSettings("ConnectionName")
        Dim connectionName As String = MySettings.Default.ConnectionName
        Return connectionName.ToString
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
End Class
