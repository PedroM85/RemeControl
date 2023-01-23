Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions

Public Class MgrFramework

    Protected mUser As LoginIn
    Protected mSalesDateInfo As SalesDateInfo
    Protected mLastAction As Date

    Public Function Terminal() As String
        Return "1"
    End Function
    Public Function GetSalesDateInfo()
        Dim oDataLayer As SalesDateData = New SalesDateData


        'With _SalesDateInfo
        '    oDataLayer.GetGeneralInfo(.SalesDateId, .OpeningDate, .UsersLoggedOn)
        'End With
        If Not oDataLayer Is Nothing Then
            mSalesDateInfo = oDataLayer.GetGeneralInfo
        End If

        mSalesDateInfo = oDataLayer.GetGeneralInfo

        Return mSalesDateInfo
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
End Class
