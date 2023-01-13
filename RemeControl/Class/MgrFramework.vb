Public Class MgrFramework

    Protected mUser As LoginIn

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
            mUser = loginDlg.Token
        End If
    End Sub
    Public ReadOnly Property CurrentUser() As LoginIn
        Get
            Return mUser
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
End Class
