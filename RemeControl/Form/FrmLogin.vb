Public Class FrmLogin
    Private mSec As SecurityManager

    Private mUser As LoginIn

    Public Sub New()
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()


        Dim ver() As String = Application.ProductVersion.Split(".")
        lblVersion.Text = String.Format("Version: {0}.{1}   (build {2})", ver)

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
        Try
            mUser = mSec.Login(sUserName, sPassword)

            If mUser Is Nothing Then

            Else
                Close()
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Activate()

    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class