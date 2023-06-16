Imports System.IO
Imports System.Net
Imports System.Net.NetworkInformation
Imports MySqlConnector
'Imports MySql.Data.MySqlClient
Imports Unelsoft
Imports Unelsoft.AccessController

Public Class SalesDate
    Public SalesDateId As Date
    Public OpeningDate As Date
    Public UsersLoggedOn As Int32
    Public message As String
    'Public 
End Class
Public Class MgrFramework

    Protected mUser As LoginIn
    Protected mSalesDateInfo As SalesDateInfo
    Protected mLastAction As Date
    Protected mParams As Parameters
    Protected mConnInfo As ConnectionInfo
    Protected mConn As MySqlConnection

    Public Function Terminal() As String
        Return "1"
    End Function
    Public ReadOnly Property Params() As Parameters
        Get
            Return mParams
        End Get
    End Property


    'Public ReadOnly Property Url() As ProcesarUrl
    '    Get
    '        Return mProcessUrl
    '    End Get
    'End Property
    'Public Function GetSalesDateInfo() As SalesDateInfo
    '    'openning routes
    '    Dim oDataLayer As New SalesDateData

    '    Dim _SalesDateInfo As New SalesDateInfo With {
    '        .SSS_Id = -9999
    '        }

    '    With _SalesDateInfo
    '        oDataLayer.PostGeneralInfo(.SDT_Id, .SDT_DateOpened, .USersLoggedOn, .SSS_Id)
    '    End With

    '    Return _SalesDateInfo
    'End Function
    Public Function InitConnection() As Boolean
        Try
            mConn = New MySqlConnection(mConnInfo.MySQLConnectionString)
            mConn.Open()

            Dim procedureName As String = "SYS_SetupConnection"

            Dim oCmd As MySqlCommand = New MySqlCommand(procedureName, mConn)
            oCmd.CommandType = CommandType.StoredProcedure

            oCmd.ExecuteNonQuery()

            Return True
        Catch ex As Exception
            Return False
        End Try

        'Try
        '    Dim activeInterfaces As New List(Of NetworkInterface)()

        '    ' Obtener todas las tarjetas de red activas
        '    For Each networkInterface As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
        '        ' Verificar si la tarjeta está activa y tiene una dirección IP
        '        If networkInterface.OperationalStatus = OperationalStatus.Up AndAlso networkInterface.NetworkInterfaceType <> NetworkInterfaceType.Loopback AndAlso networkInterface.GetIPProperties().UnicastAddresses.Count > 0 Then
        '            activeInterfaces.Add(networkInterface)
        '        End If
        '    Next

        '    ' Realizar pruebas de ping con cada tarjeta activa
        '    For Each networkInterface As NetworkInterface In activeInterfaces
        '        For Each unicastAddress As UnicastIPAddressInformation In networkInterface.GetIPProperties().UnicastAddresses
        '            If unicastAddress.Address.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork AndAlso My.Computer.Network.Ping(unicastAddress.Address.ToString()) Then
        '                ' La tarjeta está activa y responde al ping
        '                Return True
        '            End If
        '        Next
        '    Next

        '    ' Ninguna tarjeta está activa o responde al ping
        '    Return False
        'Catch ex As Exception
        '    Return False
        'End Try
    End Function
    Public Function GetConnectionInfo() As Boolean
        Dim sArgs As String()
        Dim Sname As String = String.Empty
        Dim nI As Integer

        mConnInfo = New AccessController.ConnectionInfo
        sArgs = Environment.GetCommandLineArgs

        For nI = 0 To sArgs.Length - 1
            If sArgs(nI).Substring(1, 2) = "ls" Then
                Sname = sArgs(nI).Substring(4)
                Exit For
            End If
        Next

        Return mConnInfo.GetConnectionInfo(Sname)
    End Function
    Public Overridable Function Init() As Boolean
        Try
            mParams = New Parameters(mConn)



            SetupLocalizationInfo()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Overridable Sub LoginUser(Optional UserName As String = Nothing, Optional Password As String = Nothing)
        Dim sec As SecurityManager = New SecurityManager(mConn)
        Dim loginDlg As FrmLogonBase

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
    'Public ReadOnly Property IpPc As String
    '    Get
    '        Return GetMyExternalIP()
    '    End Get
    'End Property
    'Public ReadOnly Property WebSites As String
    '    Get
    '        Return mWebSite
    '    End Get
    'End Property
    'Public Function RegisterLogin(oUser As LoginIn) As Boolean
    '    Try
    '        Dim oSec As New SecurityManager()
    '        oSec.RegisterLogin(oUser)
    '        Return True
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function
    'Public Sub RegisterLogout()
    '    If Not mUser Is Nothing Then
    '        Dim oSec As New SecurityManager()
    '        oSec.RegisterLogout(mUser)

    '    End If
    'End Sub
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
    'Public Function IsSaleDateOpened() As SalesDateData.IsOpen
    '    Dim oDataLayer As New SalesDateData
    '    Dim Value As Boolean = False
    '    Try

    '        Dim values As SalesDateData.IsOpen = oDataLayer.IsOpenning()

    '        If values = SalesDateData.IsOpen.Abierto Then
    '            Value = True
    '        ElseIf values = SalesDateData.IsOpen.Desfase Then
    '            MessageBox.Show("No hay turno aperturado en el dia " + DateTime.Today.ToString("dd-MM-yyyy"))
    '            Value = False
    '        ElseIf values = SalesDateData.IsOpen.Cerrado Then
    '            MessageBox.Show("No hay turno aperturado para el dia " + DateTime.Today.ToString("dd-MM-yyyy"))
    '            Value = False
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        Value = False
    '    End Try
    '    Return Value
    'End Function

    Private Function GetMyExternalIP()
        Dim wq As HttpWebRequest = HttpWebRequest.Create("https://api.ipify.org/")
        Dim wr As HttpWebResponse = wq.GetResponse()
        Dim sr As New StreamReader(wr.GetResponseStream(), System.Text.Encoding.UTF8)
        Dim ip As String = sr.ReadToEnd()
        sr.Close()

        Return ip.Trim()
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
