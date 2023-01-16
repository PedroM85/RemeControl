Public Class FrmLogin
    Private mSec As SecurityManager

    Private mUser As LoginIn

    Public Sub New()
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        mSec = New SecurityManager
    End Sub

    Public ReadOnly Property User As LoginIn
        Get
            Return mUser
        End Get
    End Property

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Dim sUserName As String = txtUserName.Text.Trim
        Dim sPassword As String = txtPassword.Text.Trim

        'mUser = New LoginIn
        Cursor = Cursors.WaitCursor

        mUser = mSec.Login(sUserName, sPassword)

        If mUser Is Nothing Then

        Else
            Close()
        End If
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Activate()

    End Sub
End Class