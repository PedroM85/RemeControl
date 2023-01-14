Public Class MgrFramework

    Protected mUser As LoginIn
    Protected mSalesDateInfo As SalesDateInfo

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
            If My.Computer.Network.Ping("168.181.187.165") Then
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

        If mUser Is Nothing Then
            loginDlg = New FrmLogin()

            If Not UserName Is Nothing Then
                loginDlg.txtUserName.Text = UserName

            End If

            loginDlg.ShowDialog()
            mUser = loginDlg.User
        End If
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
End Class
