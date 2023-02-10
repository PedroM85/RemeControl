Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Public Class SalesDate
    Public SalesDateId As Date
    Public OpeningDate As Date
    Public UsersLoggedOn As Int32
End Class
Public Class MgrFramework

    Protected mUser As LoginIn
    Protected mSalesDateInfo As SalesDateInfo
    Protected mLastAction As Date

    Public Function Terminal() As String
        Return "1"
    End Function

    Public Function GetSalesDateInfo() As SalesDateInfo
        'openning routes
        Dim oDataLayer As New SalesDateData
        Dim _SalesDateInfo As New SalesDateInfo

        With _SalesDateInfo
            oDataLayer.GetGeneralInfo(.SDT_Id, .SDT_DateOpened, .UsersLoggedOn)
        End With

        Return _SalesDateInfo
    End Function
    Public Function InitConnection() As Boolean
        Try
            If My.Computer.Network.Ping("8.8.8.8") Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            Return False
        End Try
    End Function


    Public Overridable Sub LoginUser(Optional UserName As String = Nothing, Optional Password As String = Nothing)
        Dim sec As SecurityManager = New SecurityManager
        Dim loginDlg As FrmLogin
        If Not UserName Is Nothing AndAlso Not Password Is Nothing Then
            mUser = sec.Login(UserName, Password)
        End If
        Try

            If mUser Is Nothing Then
                loginDlg = New FrmLogin()

                If Not UserName Is Nothing Then
                    loginDlg.txtUserName.Text = UserName

                End If

                loginDlg.ShowDialog()
                mUser = loginDlg.User

            End If
        Catch ex As Exception
            mUser = Nothing
            'Throw New Exception(ex.Message)
        End Try

    End Sub
    Public ReadOnly Property CurrentUser() As LoginIn
        Get
            Return mUser
        End Get
    End Property
    Public ReadOnly Property SaleDate As SalesDateInfo
        Get
            Return mSalesDateInfo
        End Get
    End Property

    Public ReadOnly Property IpPc As String
        Get
            Return GetMyExternalIP()
        End Get
    End Property

    Public Function RegisterLogin(oUser As LoginIn) As Boolean
        Try
            Dim oSec As New SecurityManager
            oSec.RegisterLogin(oUser)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub RegisterLogout()
        If Not mUser Is Nothing Then
            Dim oSec As New SecurityManager
            oSec.RegisterLogout(mUser)

        End If
    End Sub
    Public Function SessionActive() As Boolean
        Dim a As DateTime = oApp.CurrentUser.USR_SessionEnd
        Dim b As DateTime = DateTime.Now
        Try
            If a > b Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
    End Function
    Private Function GetMyExternalIP()
        Dim wq As HttpWebRequest = HttpWebRequest.Create("https://api.ipify.org/")
        'Dim wq As HttpWebRequest = HttpWebRequest.Create("http://whatismyip.org/")

        Dim wr As HttpWebResponse = wq.GetResponse()
        Dim sr As New StreamReader(wr.GetResponseStream(), System.Text.Encoding.UTF8)
        Dim ipa As IPAddress = IPAddress.Parse(sr.ReadToEnd)
        sr.Close()
        sr.Close()
        Dim ip As String = ipa.ToString
        ip = Replace(ip, "{}", "")

        Return ip.ToString
    End Function

    Public Property LastAction() As Date
        Get
            Return mLastAction
        End Get
        Set(value As Date)
            mLastAction = value
        End Set
    End Property

    Public Sub SetupLocalizationInfo()
        Dim oCulture As New System.Globalization.CultureInfo("es-AR")
        Dim oNumberFormat As New System.Globalization.NumberFormatInfo
        Dim oDateFormat As New System.Globalization.DateTimeFormatInfo
        Dim oAbbrDays As String() = {"Dom", "Lun", "Mar", "Mié", "Jue", "Vie", "Sáb"}
        Dim oDays As String() = {"Domingo", "Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sabado"}
        Dim oAbbrMonths As String() = {"Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic", ""}
        Dim oMonths As String() = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre", ""}
        Dim nSize() As Integer = {0}

        With oNumberFormat
            .CurrencyDecimalDigits = 2 'mParams.GetValue("NUMDEC")
            .CurrencyDecimalSeparator = "." 'mParams.GetValue("DECSEP")
            .CurrencyGroupSeparator = " "
            .CurrencyGroupSizes = nSize
            .CurrencyNegativePattern = 1
            .CurrencyPositivePattern = 0
            .CurrencySymbol = "$" 'mParams.GetValue("CURRSYM")
            .NumberDecimalDigits = 2 'mParams.GetValue("NUMDEC")
            .NumberDecimalSeparator() = "." 'mParams.GetValue("DECSEP")
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
            .ShortTimePattern = IIf("S" = "S", "h:mm tt", "HH:mm") 'IIf(mParams.GetValue("TIMEAMPM") = "S", "h:mm tt", "HH:mm")
            .LongTimePattern = IIf("S" = "S", "h:mm:ss tt", "HH:mm:ss") 'IIf(mParams.GetValue("TIMEAMPM") = "S", "h:mm:ss tt", "HH:mm:ss")

        End With

        oCulture.NumberFormat = oNumberFormat
        oCulture.DateTimeFormat = oDateFormat

        System.Threading.Thread.CurrentThread.CurrentCulture = oCulture
    End Sub
End Class
