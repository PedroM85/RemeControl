Imports Microsoft.VisualBasic.Devices

Public Enum UneSysModule As Integer
    none
    mgr_gral = 1
    POS = 2
End Enum
Public Class EWFramework
    Public Event MustClose()
    Public Event InstantMessageArriver(Message As String)

    Public Class LoginResult
        Public DialogOk As Boolean
        Public LoginResponse As String
        Public Logged As Boolean
        Sub New()
            DialogOk = False
            LoginResponse = ""
            Logged = False
        End Sub
    End Class

    Public Class SalesDateInfo
        Public SalesDateId As Date
        Public OpeningDate As Date
        Public PosSessionsOpened As Int32
        Public UserLoggedOn As Int32
        Public TrainingMode As Boolean
    End Class

    Public Class Site
        Private mId As String
        Private mName As String

        Public Sub New(id As String, name As String)
            mId = id
            mName = name
        End Sub

        Public Property Id As String
        Public Property Name As String
    End Class

    Protected mConnInfo As Unelsoft.AccessController.ConnectionInfo
    Protected mConn As OleDb.OleDbConnection
    Protected mParams As AccessController.Parameters
    Protected mTerminalId As String
    Protected mConnectionName As String
    Protected mShutdownForced As Boolean = False
    Protected mUser As Unelsoft.AccessController.User
    Protected mLastAction As Date
    Protected mSiteId As String
    Protected mNewSession As Boolean

    Dim mUserSites As New List(Of Site)


    Public Sub New()
        Me.New("")
    End Sub
    Public Overridable Function MainModuleId() As Integer
        Return UneSysModule.mgr_gral
    End Function
    Public Overridable Sub CleanOldLogins()
        Dim oSecMgr As New AccessController.SecurityManager(mConn)
        oSecMgr.CleanOldLogins(MainModuleId(), mTerminalId, mSiteId, mUser.Id)
    End Sub
    Public Overridable Function HasLicensesFree() As Boolean
        Dim oSecMgr As New AccessController.SecurityManager(mConn)
        Return oSecMgr.HasLicensesFree(MainModuleId(), SiteId)
    End Function
    Public Function InitConnection() As Boolean
        Try
            'mConn = New OleDb.OleDbConnection(GetConnectionString)
            mConn = New OleDb.OleDbConnection(mConnInfo.OLEDBConnectionString)
            mConn.Open()

            Dim oSecMgr As New AccessController.SecurityManager(mConn)
            'mConnInfo.SPID = oSecMgr.GetSPID

            Dim oCmd As OleDb.OleDbCommand = mConn.CreateCommand
            oCmd.CommandType = CommandType.StoredProcedure
            oCmd.CommandText = "MNT_SetupConnection"
            oCmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Overridable Function Init() As Boolean
        Try
            Dim oSecMgr As New AccessController.SecurityManager(mConn)
            Try
                Unelsoft.Tools.OperatingSystem.SetDateTime(oSecMgr.GetServerDateTime)
            Catch

            End Try


            mParams = New Unelsoft.AccessController.Parameters(mConn)
            mSiteId = mParams.GetValue("SITEID").TrimEnd().ToUpper()
            'mLockMgr = New AccessController.LockManager(mConn)
            'mAudit = New AccessController.AuditLogWriter(mConn, mSiteId)
            'LoadLanguage()
            SetupLocalizationInfo()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub SetupLocalizationInfo()
        Dim oCulture As New System.Globalization.CultureInfo("")
        Dim oNumberFormat As New System.Globalization.NumberFormatInfo
        Dim oDateFormat As New System.Globalization.DateTimeFormatInfo
        Dim oAbbrDays As String() = {"Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb"}
        Dim oDays As String() = {"Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sabado"}
        Dim oAbbrMonths As String() = {"Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic", ""}
        Dim oMonths As String() = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre", ""}
        Dim nSize() As Integer = {0}

        With oNumberFormat
            .CurrencyDecimalDigits = mParams.GetValue("NUMDEC")
            .CurrencyDecimalSeparator = mParams.GetValue("DECSEP")
            .CurrencyGroupSeparator = " "
            .CurrencyGroupSizes = nSize
            .CurrencyNegativePattern = 1
            .CurrencyPositivePattern = 0
            .CurrencySymbol = mParams.GetValue("CURRSYM")
            .NumberDecimalDigits = mParams.GetValue("NUMDEC")
            .NumberDecimalSeparator() = mParams.GetValue("DECSEP")
            .NumberGroupSeparator = " "
            .NumberGroupSizes = nSize
            .NumberNegativePattern = 1
        End With

        With oDateFormat
            .AbbreviatedDayNames = oAbbrDays
            .AbbreviatedMonthNames = oAbbrMonths
            .DayNames = oDays
            .MonthNames = oMonths
            .ShortDatePattern = "dd/MM/yyyy"
            .LongDatePattern = "dddd, dd \de MMMM \de yyyy"
            .ShortTimePattern = IIf(mParams.GetValue("TIMEAMPM") = "S", "h:mm tt", "HH:mm")
            .LongTimePattern = IIf(mParams.GetValue("TIMEAMPM") = "S", "h:mm:ss tt", "HH:mm:ss")
        End With

        oCulture.NumberFormat = oNumberFormat
        oCulture.DateTimeFormat = oDateFormat

        System.Threading.Thread.CurrentThread.CurrentCulture = oCulture
    End Sub

    Public Function GetConnectionInfo() As Boolean
        Dim sArgs As String()
        Dim sName As String = String.Empty
        Dim nI As Integer

        mConnInfo = New AccessController.ConnectionInfo
        sArgs = Environment.GetCommandLineArgs

        For nI = 0 To sArgs.Length - 1
            If sArgs(nI).Substring(1, 2) = "ls" Then
                sName = sArgs(nI).Substring(4)
                Exit For
            End If
        Next

        Return mConnInfo.GetConnectionInfo(sName)
    End Function

    Public Overridable Sub LoginUser(Optional UserName As String = Nothing, Optional Password As String = Nothing)
        Dim sec As AccessController.SecurityManager = New AccessController.SecurityManager(mConn)
        Dim loginDlg As Unelsoft.Common.EWLogin

        If Not UserName Is Nothing AndAlso Not Password Is Nothing Then
            mUser = sec.Login(UserName, Password)
        End If

        If mUser Is Nothing Then
            loginDlg = New Unelsoft.Common.EWLogin(mTerminalId, sec, mConn)

            If Not UserName Is Nothing Then
                loginDlg.txtUser.Text = UserName
            End If

            loginDlg.ShowDialog()
            mUser = loginDlg.User
        End If
    End Sub

    Public ReadOnly Property CurrentUser() As Unelsoft.AccessController.User
        Get
            Return mUser
        End Get
    End Property
    Public Property LastAction As Date
        Get
            Return mLastAction
        End Get
        Set(value As Date)
            mLastAction = value
        End Set
    End Property
    Public Property SiteId() As String
        Get
            Return mSiteId
        End Get
        Set(value As String)
            mSiteId = value.TrimEnd().ToUpper
        End Set
    End Property

End Class
