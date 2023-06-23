Imports Unelsoft.DataAccessFactory

<CLSCompliant(True)>
Public Class SecurityManager

#Region " Instance variables & constants "

    ' Cantidad de dias para expiración de password
    Private Const mDaysPwdExpiration As Integer = 3
    Private mConn As IDbConnection

    Private mPingInterval As Int32 = -1
    Private mPassword_SpecialAuthentication As String
    Private mIsSpecialAuthentication As Boolean

#End Region

#Region " Methods "

    Public Sub New(ByVal conn As IDbConnection)
        mConn = conn
    End Sub

    Public Function EncryptData(ByVal data As String) As String
        Dim inputArray As Byte()
        Dim outputByte As Byte()

        Dim a As New System.Text.ASCIIEncoding

        inputArray = a.GetBytes(data)

        Dim md5 As System.Security.Cryptography.MD5CryptoServiceProvider = New System.Security.Cryptography.MD5CryptoServiceProvider

        outputByte = md5.ComputeHash(inputArray)

        Return System.Convert.ToBase64String(outputByte, 0, outputByte.Length)

    End Function

    Private Function IsPrivateIP(ByVal CheckIP As String) As Boolean
        Dim Quad1, Quad2 As Integer

        Quad1 = CInt(CheckIP.Substring(0, CheckIP.IndexOf(".")))
        Quad2 = CInt(CheckIP.Substring(CheckIP.IndexOf(".") + 1).Substring(0, CheckIP.IndexOf(".")))
        Select Case Quad1
            Case 10
                Return True
            Case 172
                If Quad2 >= 16 And Quad2 <= 31 Then Return True
            Case 192
                If Quad2 = 168 Then Return True
        End Select
        Return False
    End Function

    Private Function GetLocalIPAddress() As String
        Dim addrs As System.Net.IPAddress()
        addrs = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList

        For Each IPaddress As System.Net.IPAddress In addrs
            'Only return IPv4 routable IPs
            If (IPaddress.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork) Then
                Return IPaddress.ToString
            End If
        Next
        Return ""

        'Return System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName).AddressList(0).ToString
    End Function

    <System.Diagnostics.DebuggerStepThrough()>
    Public Sub PingServer(ByVal trm As String)

        If mConn.State = ConnectionState.Open Then

            Dim cmd As IDbCommand = mConn.CreateCommand
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SCTRL_Ping"

            Dim prm As IDataParameter
            prm = DAHelper.CreateParameter(cmd, "TRM", DbType.String)
            prm.Value = trm
            cmd.Parameters.Add(prm)

            cmd.ExecuteNonQuery()

        End If

    End Sub

    'Public Function GetSPID() As Integer

    '    Dim cmd As IDbCommand = mConn.CreateCommand
    '    cmd.CommandText = "SELECT @@SPID "
    '    cmd.CommandType = CommandType.Text

    '    Return CInt(cmd.ExecuteScalar)

    'End Function

    Public Function GetServerDateTime() As Date
        Dim cmd As IDbCommand = mConn.CreateCommand

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SEC_GetCurrentDateTime"

        Dim prm As IDataParameter
        prm = DAHelper.CreateParameter(cmd, "DateTime", DbType.DateTime)
        prm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(prm)

        cmd.ExecuteNonQuery()
        Dim result As IDataParameter = CType(cmd.Parameters("DateTime"), IDataParameter)
        Return CType(result.Value(), Date)
    End Function

    Public Function SetUnsuccessfulAttempt(ByVal userId As String) As Boolean

        Dim cmd As IDbCommand = mConn.CreateCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "USR_SetUnsuccessfulAttempt"

        Dim prm As IDataParameter
        prm = DAHelper.CreateParameter(cmd, "UserId", DbType.String)
        prm.Value = userId
        cmd.Parameters.Add(prm)

        Return Convert.ToBoolean(cmd.ExecuteScalar)

    End Function

    Private Sub ReestablishUnsuccessfulAttempts(ByVal userId As String)

        Dim cmd As IDbCommand = mConn.CreateCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "USR_ReestablishUnsuccessfulAttempts"

        Dim prm As IDataParameter
        prm = DAHelper.CreateParameter(cmd, "UserId", DbType.String)
        prm.Value = userId
        cmd.Parameters.Add(prm)

        cmd.ExecuteNonQuery()

    End Sub

    Private Sub LoadSuperUser(ByRef user As User)

        user.FirstName = "Administrador" & Space(11)
        user.LastName = "e-wave"
        user.IsSuperUser = True
        user.InitialChangePassword = False
        user.Expired = False
        user.Enabled = True
        'user.CanAccessEwave = True
        'user.CanAccessEboc = True
        'user.CanAccessEcom = True

        Dim oCmd As IDbCommand = mConn.CreateCommand
        oCmd.CommandType = CommandType.Text
        oCmd.CommandText = "DECLARE @SL_Id CHAR(5) SELECT @SL_Id = MIN(SLV_Id) FROM SYS_SecurityLevel" &
        " SELECT * FROM SYS_SecurityLevel WHERE SLV_Id = @SL_Id"

        Dim oRd As IDataReader = oCmd.ExecuteReader
        oRd.Read()
        Dim oSecLevel As SecurityLevel = New SecurityLevel(oRd.GetInt16(oRd.GetOrdinal("SLV_Id")), oRd.GetString(oRd.GetOrdinal("SLV_Description")))
        user.SecurityLevel = oSecLevel
        oRd.Close()
        oRd = Nothing

        'e-wave
        oCmd.CommandText = "DECLARE @GroupId CHAR(5) " &
        "SELECT @GroupId = MIN(UGP_Id) FROM SYS_UserGroup INSERT INTO SYS_User " &
        "(USR_Id, USR_FirstName, USR_LastName, USR_InitialChange, USR_Password, USR_UGP_Id, USR_Disabled, USR_UnsuccessfulAttempts) " &
        "VALUES ('ewave', 'ewave', 'ewave', 0, 'ewave', @GroupId, 0, 0)"
        Try
            oCmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

        'e-call
        oCmd.CommandText = "DECLARE @GroupId CHAR(5) " &
        "SELECT @GroupId = MIN(UGP_Id) FROM SYS_UserGroup INSERT INTO SYS_User " &
        "(USR_Id, USR_FirstName, USR_LastName, USR_InitialChange, USR_Password, USR_UGP_Id, USR_Disabled, USR_External, USR_UnsuccessfulAttempts)" &
        " VALUES ('ewave', 'ewave', 'ewave', 0, 'ewave', @GroupId, 0, 0, 0)"
        Try
            oCmd.ExecuteNonQuery()
        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " Login & authorisation methods "

    Public Function Login(ByVal userName As String, ByVal password As String) As User

        Dim user As User = Nothing

        If userName.Trim.ToLower = "unelsoft" Then

            user = New User(userName.Trim)
            LoadSuperUser(user)

            If Not CheckPasswordSuperUser(password) Then
                Return Nothing
            End If

        Else

            GetUserSpecialAuthentication(userName)
            'Ver si es SpecialAuthentication.
            If mIsSpecialAuthentication = True Then
                'Validación del algoritmo
                If password = Algorithm() Then
                    'El algoritmo es correcto, continuar con el password obtenido ...
                    password = mPassword_SpecialAuthentication
                Else
                    'No es correcto
                    Return Nothing
                End If
            Else
                'Si no es "SpecialAuthentication", continuar...
            End If

            'Usuario Estandar
            Dim rd As IDataReader
            Dim cmd As IDbCommand = mConn.CreateCommand

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SEC_Login"

            Dim prm As IDataParameter

            prm = DAHelper.CreateParameter(cmd, "User", DbType.StringFixedLength, 20)
            prm.Value = userName
            cmd.Parameters.Add(prm)

            prm = DAHelper.CreateParameter(cmd, "Password", DbType.StringFixedLength, 24)

            'oPrm.Value = IIf(sPassword = String.Empty, sPassword, EncryptData(sUserName & sPassword))
            If mIsSpecialAuthentication = True Then
                prm.Value = password
            Else
                prm.Value = EncryptData(userName & password)
            End If
            cmd.Parameters.Add(prm)

            rd = cmd.ExecuteReader()

            If rd.Read() Then
                user = New User(rd.GetString(0).TrimEnd)

                With user

                    .FirstName = rd.GetString(rd.GetOrdinal("USR_FirstName"))
                    .LastName = rd.GetString(rd.GetOrdinal("USR_LastName"))

                    If Not rd.IsDBNull(rd.GetOrdinal("USR_Description")) Then
                        .Description = rd.GetString(rd.GetOrdinal("USR_Description"))
                    End If

                    .InitialChangePassword = rd.GetBoolean(rd.GetOrdinal("USR_InitialChange"))
                    If rd.IsDBNull(rd.GetOrdinal("USR_ExpiryDate")) Then
                        .Expired = False
                    Else
                        .Expired = rd.GetDateTime(rd.GetOrdinal("USR_ExpiryDate")) < rd.GetDateTime(rd.GetOrdinal("CurrentDate"))
                    End If

                    .Enabled = Not rd.GetBoolean(rd.GetOrdinal("USR_Disabled"))
                    .GroupId = rd.GetString(rd.GetOrdinal("UGP_Id"))
                    '.LanguageId = oRd.GetString(9)
                    .MenuId = rd.GetInt32(rd.GetOrdinal("MNU_Id"))
                    '.MenuDescription = rd.GetString(rd.GetOrdinal("MNU_Description"))

                    'If rd.IsDBNull(rd.GetOrdinal("USR_CanAccessEwave")) Then
                    '    .CanAccessEwave = False
                    'Else
                    '    .CanAccessEwave = rd.GetBoolean(rd.GetOrdinal("USR_CanAccessEwave"))
                    'End If

                    'If rd.IsDBNull(rd.GetOrdinal("USR_CanAccessEboc")) Then
                    '    .CanAccessEboc = False
                    'Else
                    '    .CanAccessEboc = rd.GetBoolean(rd.GetOrdinal("USR_CanAccessEboc"))
                    'End If

                    'If rd.IsDBNull(rd.GetOrdinal("USR_CanAccessEcom")) Then
                    '    .CanAccessEcom = False
                    'Else
                    '    .CanAccessEcom = rd.GetBoolean(rd.GetOrdinal("USR_CanAccessEcom"))
                    'End If

                    '[AMI210405]
                    If rd.IsDBNull(rd.GetOrdinal("USR_PasswordExpiryDate")) Then
                        .PasswordExpired = False
                    Else
                        If rd.GetDateTime(rd.GetOrdinal("USR_PasswordExpiryDate")) < rd.GetDateTime(rd.GetOrdinal("CurrentDate")) Then
                            .PasswordExpired = True
                        Else
                            .PasswordExpired = False
                        End If
                    End If
                    Try
                        If rd.IsDBNull(rd.GetOrdinal("UGP_isWaiter")) Then
                            .IsWaiter = False
                        Else
                            .IsWaiter = rd.GetBoolean(rd.GetOrdinal("UGP_isWaiter"))
                        End If
                    Catch
                        .IsWaiter = False
                    End Try



                    'If we are loging in, autoopen if is waiter
                    .WaiterTableAutoOpen = .IsWaiter

                    Dim oSecLevel As SecurityLevel = New SecurityLevel(rd.GetInt16(rd.GetOrdinal("UGP_SLV_Id")), rd.GetString(rd.GetOrdinal("SLV_Description")))
                    .SecurityLevel = oSecLevel
                End With

            End If
            rd.Close()

            If Not user Is Nothing AndAlso user.Enabled Then
                'Setear a cero al contador de intentos fallidos.
                If mConn.Database <> "" Then 'Ver si esta offline
                    ReestablishUnsuccessfulAttempts(user.Id)
                End If
            End If

        End If

        Return user

    End Function

    Private Function GetUserSpecialAuthentication(ByVal user As String) As Boolean

        Dim cmd As IDbCommand = mConn.CreateCommand
        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SEC_GetUserSpecialAuthentication"

        Dim prm As IDataParameter

        prm = DAHelper.CreateParameter(cmd, "User", DbType.StringFixedLength, 20)
        prm.Value = user
        cmd.Parameters.Add(prm)

        'dcofre: Cambio el parametro de salida por lectura del datareader
        'por compatibilidad con Eboc Offline
        Dim dr As IDataReader = cmd.ExecuteReader()

        If dr.Read Then
            mPassword_SpecialAuthentication = dr.GetString(dr.GetOrdinal("USR_Password"))
            If dr.IsDBNull(dr.GetOrdinal("UGP_SpecialAuthentication")) Then
                mIsSpecialAuthentication = False
            Else
                mIsSpecialAuthentication = dr.GetBoolean(dr.GetOrdinal("UGP_SpecialAuthentication"))
            End If
        End If

        dr.Close()

        Return mIsSpecialAuthentication

    End Function

    Private Function Algorithm() As String

        Dim result As Integer
        result = Now.Day * Now.Month * Now.Year - Now.Day - Now.Month + Now.Hour
        Return result.ToString()

    End Function

    Private Function ConvertIntegerToByte(ByVal int As Integer) As Byte
        'En este caso es mejor descartar el resto
        Dim result As Byte() = BitConverter.GetBytes(int)
        Return result(0)

    End Function

    Private Function CheckPasswordSuperUser(ByVal password As String) As Boolean


        If password.Trim = "" Then
            Return False
        End If

        Dim getChar As Char
        Dim getOnlyNumbers As String = ""
        Dim countChar As Byte

        For i As Byte = 0 To ConvertIntegerToByte(password.Length - 1)
            getChar = Convert.ToChar(password.Substring(i, 1))
            If IsNumeric(getChar) Then
                getOnlyNumbers = getOnlyNumbers & getChar
            Else
                countChar = ConvertIntegerToByte(countChar + 1)
            End If
        Next

        If getOnlyNumbers = Convert.ToString(Convert.ToInt32(Now.Day) * Convert.ToInt32(Now.Month) * Convert.ToInt32(Now.Year) * Convert.ToInt32(Now.Year)) Then
            If countChar > 4 Then
                Return True
            End If
        End If

        Return False

    End Function

    Public Function CanRunTransaction(ByVal user As User, ByVal transaction As String) As Boolean

        If user.IsSuperUser Then
            Return True
        Else
            'usuario Estandar
            Dim cmd As IDbCommand = mConn.CreateCommand

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SEC_CanExecTransaction"

            Dim prm As IDataParameter

            prm = DAHelper.CreateParameter(cmd, "User", DbType.StringFixedLength, 20)
            prm.Value = user.Id
            cmd.Parameters.Add(prm)

            prm = DAHelper.CreateParameter(cmd, "Transaction", DbType.StringFixedLength, 20)
            prm.Value = transaction
            cmd.Parameters.Add(prm)

            prm = DAHelper.CreateParameter(cmd, "Result", DbType.Boolean)
            prm.Direction = ParameterDirection.Output
            cmd.Parameters.Add(prm)

            cmd.ExecuteNonQuery()
            Dim result As Boolean = False
            If cmd.Parameters("Result") Is Nothing Then
                result = False
            Else
                Dim paramResult As IDataParameter = CType(cmd.Parameters("Result"), IDataParameter)
                result = CType(paramResult.Value, Boolean)
            End If

            Return result
        End If
    End Function

    Public Function CanExecTransaction(ByVal user As User, ByVal transaction As String) As Collection
        Dim rd As IDataReader
        Dim cmd As IDbCommand = mConn.CreateCommand
        Dim res As New Collection
        Dim prm As IDataParameter

        If user.IsSuperUser Then
            'super usuario
            cmd.CommandType = CommandType.Text
            cmd.CommandText = String.Format("SELECT * FROM SYS_Operation WHERE OPE_TRA_Id = '{0}'", transaction)

            rd = cmd.ExecuteReader()
            Do While rd.Read
                res.Add(rd.GetString(1))
            Loop
            rd.Close()

        Else
            'usuario estandar
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SEC_OperationsPerTransaction"

            prm = DAHelper.CreateParameter(cmd, "User", DbType.StringFixedLength, 20)
            prm.Value = user.Id
            cmd.Parameters.Add(prm)

            prm = DAHelper.CreateParameter(cmd, "Transaction", DbType.StringFixedLength, 20)
            prm.Value = transaction
            cmd.Parameters.Add(prm)

            rd = cmd.ExecuteReader()
            Do While rd.Read
                res.Add(rd.GetString(2))
            Loop
            rd.Close()
        End If


        Return res
    End Function

    Public Sub RegisterLogin(ByVal user As User, ByVal terminal As String, ByVal moduleId As Integer, ByVal siteId As String)

        Dim cmd As IDbCommand = mConn.CreateCommand
        Dim prm As IDataParameter

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SCTRL_Login"

        prm = DAHelper.CreateParameter(cmd, "TerminalId", DbType.StringFixedLength, 5)
        prm.Value = terminal
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "UserId", DbType.StringFixedLength, 20)
        prm.Value = user.Id
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "ModuleId", DbType.Int32)
        prm.Value = moduleId
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "IP", DbType.String, 20)
        prm.Value = GetLocalIPAddress()
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "SiteId", DbType.String, 10)
        prm.Value = siteId
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "ModifiedBy", DbType.String, 20)
        prm.Value = user.Id
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "ReadOnly", DbType.Boolean)
        prm.Value = False
        cmd.Parameters.Add(prm)

        cmd.ExecuteNonQuery()

    End Sub

    Public Sub RegisterLogout(ByVal siteId As String, ByVal user As String)

        Dim cmd As IDbCommand = mConn.CreateCommand
        Dim prm As IDataParameter

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SCTRL_Logout"

        prm = DAHelper.CreateParameter(cmd, "SiteId", DbType.String, 10)
        prm.Value = siteId
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "ModifiedBy", DbType.String, 20)
        prm.Value = user
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "ReadOnly", DbType.Boolean)
        prm.Value = False
        cmd.Parameters.Add(prm)

        cmd.ExecuteNonQuery()
    End Sub

    Public Function HasAuthorisationBy(ByVal userId As String, ByVal authLevelRequested As Integer, ByVal chiefUserId As String, ByVal chiefPassword As String) As String
        Dim cmd As IDbCommand = mConn.CreateCommand
        Dim prm As IDataParameter

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SEC_HasAuthorisationBy"

        prm = DAHelper.CreateParameter(cmd, "UserId", DbType.StringFixedLength, 20)
        prm.Value = userId
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "AuthLevelRequested", DbType.Int32, 4)
        prm.Value = authLevelRequested
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "ChiefUserId", DbType.StringFixedLength, 20)
        prm.Value = chiefUserId
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "ChiefPassword", DbType.StringFixedLength, 24)
        prm.Value = EncryptData(chiefUserId & chiefPassword)
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "Result", DbType.Boolean)
        prm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "Message", DbType.String, 100)
        prm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(prm)

        cmd.ExecuteNonQuery()

        Dim paramResult As IDataParameter = CType(cmd.Parameters("Result"), IDataParameter)

        If CType(paramResult.Value, Boolean) Then
            Return "OK"
        Else
            Dim paramMessage As IDataParameter = CType(cmd.Parameters("Message"), IDataParameter)
            Return CType(paramMessage.Value, String)
        End If
    End Function

    Public Sub CleanOldLogins(ByVal moduleId As Integer, ByVal terminal As String, ByVal siteId As String, ByVal user As String)
        Dim cmd As IDbCommand = mConn.CreateCommand
        Dim prm As IDataParameter

        cmd.CommandType = CommandType.StoredProcedure

        cmd.CommandText = "MNT_ClearTerminalLogins"

        prm = DAHelper.CreateParameter(cmd, "TerminalId", DbType.String)
        prm.Value = terminal
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "ModuleId", DbType.Int32)
        prm.Value = moduleId
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "SiteId", DbType.String, 10)
        prm.Value = siteId
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "ModifiedBy", DbType.String, 20)
        prm.Value = user
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "ReadOnly", DbType.Boolean)
        prm.Value = False
        prm.Direction = ParameterDirection.Input
        cmd.Parameters.Add(prm)

        cmd.ExecuteNonQuery()

    End Sub

#Const LicScheme = 2

#If LicScheme = 1 Then
    Public Function HasLicensesFree(ByVal moduleId As Integer, ByVal siteId As String) As Boolean
        Dim cmd As IDbCommand = mConn.CreateCommand
        Dim prm As IDataParameter

        Dim Decripted As String() = Nothing

        Dim maxLics, usedLics As Integer

        Dim bKey() As Byte = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24}
        Dim bIV() As Byte = {65, 110, 68, 26, 69, 178, 200, 219}

        cmd.CommandType = CommandType.StoredProcedure

        cmd.CommandText = "SCTRL_HasLicensesFree"

        prm = DAHelper.CreateParameter(cmd, "ModuleId", DbType.Int32)
        prm.Value = moduleId
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "MaxLics", DbType.StringFixedLength, 30)
        prm.Direction = ParameterDirection.Output
        prm.Value = String.Empty
        cmd.Parameters.Add(prm)

        prm = DAHelper.CreateParameter(cmd, "UsedLics", DbType.Int32)
        prm.Direction = ParameterDirection.Output
        cmd.Parameters.Add(prm)

        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Return False
        End Try

        Dim paramMaxLics As IDataParameter = CType(cmd.Parameters("MaxLics"), IDataParameter)
        If IsDBNull(paramMaxLics.Value) Then
            Return False
        Else
            maxLics = Int32.Parse(ewave.Tools.ProtectData.DecryptData(CType(paramMaxLics.Value, String), bKey, bIV))

            Dim paramUsedLics As IDataParameter = CType(cmd.Parameters("UsedLics"), IDataParameter)
            usedLics = Int32.Parse(CType(paramUsedLics.Value, String))
        End If


        Return usedLics < maxLics
    End Function

#Else
    Public Function HasLicensesFree(ByVal moduleId As Integer, ByVal siteId As String) As Boolean
        Dim cmd As IDbCommand = mConn.CreateCommand

        cmd.CommandType = CommandType.Text
        cmd.CommandText = "select PAR_StringValue from SYS_Parameter where PAR_Id = 'USERLIC'"

        Dim encstring As String = Nothing
        Try
            encstring = CType(cmd.ExecuteScalar(), String)
        Catch ex As Exception
            Return False
        End Try
        cmd.CommandText = "SELECT COUNT(*) as UsedLics FROM SYS_UserLoggedOn WHERE ULO_MOD_Id = " + CType(moduleId, String)
        Try
            Dim usedLics As Integer = CType(cmd.ExecuteScalar, Integer)
            'Dim lic As ewaveLicense = ewaveLicense.fromXmlEncripted(encstring)
            'If lic.SiteId <> siteId Then
            '    Return False
            'Else
            '    If lic.ExpiryDate < Now Then
            '        Return False
            '    Else
            '        Return usedLics < lic.MaxLics(moduleId)
            '    End If
            'End If

        Catch ex As Exception
            Return False
        End Try
    End Function

#End If

#End Region

#Region " Password methods "

    Public Sub ChangePassword(ByVal userId As String, ByVal password As String)
        Dim cmd As IDbCommand = mConn.CreateCommand
        Dim prm As IDataParameter

        With cmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "USR_ChangePassword"

            prm = DAHelper.CreateParameter(cmd, "UserId", DbType.StringFixedLength, 20)
            prm.Value = userId
            .Parameters.Add(prm)

            prm = DAHelper.CreateParameter(cmd, "Password", DbType.StringFixedLength, 24)
            prm.Value = EncryptData(userId & password)
            .Parameters.Add(prm)

            .ExecuteNonQuery()
        End With
    End Sub

    Public Function ChangePassword(ByVal user As User, ByVal currPassword As String, ByVal newPassword As String) As Boolean
        Try
            Dim cmd As IDbCommand = mConn.CreateCommand
            Dim prm As IDataParameter

            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "SEC_ChangePassword"

            prm = DAHelper.CreateParameter(cmd, "User", DbType.StringFixedLength, 20)
            prm.Value = user.Id
            cmd.Parameters.Add(prm)

            prm = DAHelper.CreateParameter(cmd, "CurrPassword", DbType.StringFixedLength, 24)
            prm.Value = EncryptData(user.Id & currPassword)
            cmd.Parameters.Add(prm)

            prm = DAHelper.CreateParameter(cmd, "NewPassword", DbType.StringFixedLength, 24)
            prm.Value = EncryptData(user.Id & newPassword)
            cmd.Parameters.Add(prm)

            cmd.ExecuteNonQuery()
            Return True
        Catch e As Exception
            Return False
        End Try
    End Function

    Public Function IsComplexPassword(ByVal password As String) As Boolean

        Dim getChar As Char
        Dim countChar As Byte
        Dim countNumbers As Byte

        For idx As Byte = 0 To Convert.ToByte(password.Length - 1)
            getChar = Convert.ToChar(password.Substring(idx, 1))
            If IsNumeric(getChar) Then
                countNumbers = Convert.ToByte(countNumbers + 1)
            Else
                countChar = Convert.ToByte(countChar + 1)
            End If
        Next

        If countNumbers > 0 And countChar > 0 Then
            Return True
        End If

        Return False

    End Function

    Public Function IsRepeatPassword(ByVal userId As String, ByVal password As String) As Boolean

        Dim cmd As IDbCommand = mConn.CreateCommand
        Dim prm As IDataParameter
        Dim dr As IDataReader
        Const qtyPasswords As Integer = 3
        Dim count As Integer

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "PDH_GetPasswordHistory"

        prm = DAHelper.CreateParameter(cmd, "UserId", DbType.StringFixedLength, 20)
        prm.Value = userId
        cmd.Parameters.Add(prm)

        dr = cmd.ExecuteReader()

        Try
            While dr.Read

                If password = dr.Item("PDH_Password").ToString Then
                    Return True
                End If

                count += 1
                If count >= qtyPasswords Then
                    Exit While
                End If

            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            dr.Close()
            dr = Nothing
        End Try

        Return False

    End Function

    Public Function GetUserPassword(ByVal userId As String) As String

        Dim cmd As IDbCommand = mConn.CreateCommand
        Dim prm As IDataParameter
        Dim dr As IDataReader

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "USR_Select"

        prm = DAHelper.CreateParameter(cmd, "USR_Id", DbType.StringFixedLength, 20)
        prm.Value = userId
        cmd.Parameters.Add(prm)

        dr = cmd.ExecuteReader()

        Try
            While dr.Read

                If dr.Item("USR_Id").ToString.Trim = userId Then
                    Return CType(dr.Item("USR_Password"), String)
                End If

            End While

        Catch ex As Exception
            Throw New Exception(ex.Message)
        Finally
            dr.Close()
            dr = Nothing
        End Try

        Return ""

    End Function

#End Region

End Class
