
<CLSCompliant(True)>
Public Class User

#Region " Variables "

    Private sId As String
    Private sPassword As String
    Private sFirstName As String
    Private sLastName As String
    Private sDescription As String
    Private bInitialChangePwd As Boolean
    Private sGroupId As Integer
    ' Private nLanguageId As Integer
    Private nMenuId As Integer
    'Private oUserMenu As UserMenu
    Private bEnabled As Boolean
    Private bExpired As Boolean
    Private lCanAccessManager As Boolean
    Private lCanAccessPOS As Boolean
    Private oSecLevel As SecurityLevel
    Private mPasswordExpired As Boolean
    Private mIsSuperUser As Boolean
    Private mIsWaiter As Boolean
    Private mWaiterTableAutoOpen As Boolean
    Private bSpecialAuthentication As Boolean

#End Region

#Region " Properties "

    'Public Property SpecialAuthentication() As Boolean
    '    Get
    '        Return bSpecialAuthentication
    '    End Get
    '    Set(ByVal Value As Boolean)
    '        bSpecialAuthentication = Value
    '    End Set
    'End Property

    Public Property SecurityLevel() As SecurityLevel
        Get
            Return oSecLevel
        End Get

        Set(ByVal Value As SecurityLevel)
            oSecLevel = Value
        End Set

    End Property

    Public Property CanAccessPOS() As Boolean
        Get
            Return lCanAccessPOS
        End Get
        Set(ByVal Value As Boolean)
            lCanAccessPOS = Value
        End Set
    End Property

    Public Property CanAccessManager() As Boolean
        Get
            Return lCanAccessManager
        End Get
        Set(ByVal Value As Boolean)
            lCanAccessManager = Value
        End Set
    End Property

    Public Property Expired() As Boolean
        Get
            Return bExpired
        End Get
        Set(ByVal Value As Boolean)
            bExpired = Value
        End Set
    End Property

    Public Property Enabled() As Boolean
        Get
            Return bEnabled
        End Get
        Set(ByVal Value As Boolean)
            bEnabled = Value
        End Set
    End Property

    Public ReadOnly Property CanEnterApplication() As Boolean
        Get
            Return bEnabled And Not bExpired
        End Get
    End Property

    Public Property InitialChangePassword() As Boolean
        Get
            Return bInitialChangePwd
        End Get
        Set(ByVal Value As Boolean)
            bInitialChangePwd = Value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return sPassword
        End Get
        Set(ByVal Value As String)
            sPassword = MyClass.EncryptPassword(Value)
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return sFirstName
        End Get
        Set(ByVal Value As String)
            sFirstName = Value
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return sLastName
        End Get
        Set(ByVal Value As String)
            sLastName = Value
        End Set
    End Property

    Public Property Id() As String
        Get
            Return sId
        End Get
        Set(ByVal Value As String)
            sId = Value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return sDescription
        End Get
        Set(ByVal Value As String)
            sDescription = Value
        End Set
    End Property
    Public Property MenuId() As Integer
        Get
            Return nMenuId
        End Get
        Set(ByVal Value As Integer)
            nMenuId = Value
        End Set
    End Property
    Public Property GroupId() As Integer
        Get
            Return sGroupId
        End Get
        Set(ByVal Value As Integer)
            sGroupId = Value
        End Set
    End Property

    'Public Property LanguageId() As Integer
    '    Get
    '        Return nLanguageId
    '    End Get
    '    Set(ByVal Value As Integer)
    '        nLanguageId = Value
    '    End Set
    'End Property

    'Public Property MenuId() As Integer
    '    Get
    '        Return CInt(oUserMenu.Id)
    '    End Get
    '    Set(ByVal Value As Integer)
    '        oUserMenu.Id = Str(Value)
    '    End Set
    'End Property

    'Public WriteOnly Property MenuDescription() As String
    '    Set(ByVal Value As String)
    '        oUserMenu.Description = Value
    '    End Set
    'End Property

    'Public ReadOnly Property UserMenu() As UserMenu
    '    Get
    '        Return oUserMenu
    '    End Get
    'End Property

    Public Property IsSuperUser() As Boolean
        Get
            Return mIsSuperUser
        End Get
        Set(ByVal Value As Boolean)
            mIsSuperUser = Value
        End Set
    End Property
    Public Property WaiterTableAutoOpen() As Boolean
        Get
            Return mWaiterTableAutoOpen
        End Get
        Set(ByVal value As Boolean)
            mWaiterTableAutoOpen = value
        End Set
    End Property

    Public Property IsWaiter() As Boolean
        Get
            Return mIsWaiter
        End Get
        Set(ByVal Value As Boolean)
            mIsWaiter = Value
        End Set
    End Property

    Public Property PasswordExpired() As Boolean
        Get
            Return mPasswordExpired
        End Get
        Set(ByVal Value As Boolean)
            mPasswordExpired = Value
        End Set
    End Property

    Public Function EncryptPassword(ByVal Password As String) As String
        Dim bInputArray As Byte()
        Dim bOutputByte As Byte()

        Dim a As New System.Text.ASCIIEncoding

        bInputArray = a.GetBytes(Password)

        Dim oMD5 As System.Security.Cryptography.MD5CryptoServiceProvider = New System.Security.Cryptography.MD5CryptoServiceProvider

        bOutputByte = oMD5.ComputeHash(bInputArray)

        Return System.Convert.ToBase64String(bOutputByte, 0, bOutputByte.Length)
    End Function

#End Region

#Region " Methods "

    Public Sub New(ByVal sIdUser As String)
        sId = sIdUser
        'oUserMenu = New UserMenu
    End Sub

    'Public Sub LoadUserMenu(ByVal oConnection As IDbConnection)

    '    oUserMenu.Connection = oConnection
    '    oUserMenu.FillMenu()

    'End Sub

    'Public Sub LoadSuperUserMenu(ByVal oConnection As IDbConnection)
    '    oUserMenu.Connection = oConnection

    '    If mIsSuperUser Then
    '        oUserMenu.FillSuperUserMenu()
    '    End If

    'End Sub

#End Region

End Class

#Region " Inner Class "

<CLSCompliant(True)>
Public Class SecurityLevel
    Private nId As Integer
    Private sDescription As String

    Public Sub New(ByVal Id As Integer, ByVal Description As String)
        nId = Id
        sDescription = Description
    End Sub

    Public Sub New(ByVal Id As Integer, ByVal oConnection As IDbConnection)
        nId = Id

        Dim oRd As IDataReader
        Dim cmd As IDbCommand = oConnection.CreateCommand

        cmd.CommandType = CommandType.StoredProcedure
        cmd.CommandText = "SEC_GetSecurityLevel"

        Dim oPrm As IDataParameter

        oPrm = DAHelper.CreateParameter(cmd, "SLV_Id", DbType.Int32)
        oPrm.Value = Id
        cmd.Parameters.Add(oPrm)

        oRd = cmd.ExecuteReader()

        If oRd.Read() Then
            If Not oRd.IsDBNull(oRd.GetOrdinal("SLV_Description")) Then
                Me.sDescription = oRd.GetString(oRd.GetOrdinal("SLV_Description"))
            End If
        End If
        oRd.Close()
    End Sub

    Public Property Id() As Integer
        Get
            Return nId
        End Get
        Set(ByVal Value As Integer)
            nId = Value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return sDescription
        End Get
        Set(ByVal Value As String)
            sDescription = Value
        End Set
    End Property
End Class
#End Region
