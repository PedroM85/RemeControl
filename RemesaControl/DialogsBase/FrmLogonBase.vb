Imports Unelsoft

Public Class FrmLogonBase
    Inherits System.Windows.Forms.Form

    Private mSecMgr As AccessController.SecurityManager
    Private mUser As AccessController.User
    'Private mAudit As AccessController.AuditLogWriter
    Private mTerminalId As String

    Public Sub New(sTerminalId As String, oSec As AccessController.SecurityManager, DBConnection As IDbConnection)
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        LoadGlobalCaptions()
        mTerminalId = sTerminalId
        mSecMgr = oSec
        'mAudit = New AccessController.AuditLogWriter(DBConnection, EnvironmentObjects.Framework.SiteId)
    End Sub

#Region " Properties "

    Public ReadOnly Property User() As AccessController.User
        Get
            Return mUser
        End Get
    End Property

#End Region

#Region " Procedures "

#End Region

#Region " Events "


    Private Sub Login_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Activate()

        txtUser.Select()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Dim sUserName As String = txtUser.Text
        Dim sPassword As String = txtPassword.Text
        Dim bDisabled As Boolean

        MyBase.Cursor = Cursors.WaitCursor

        mUser = mSecMgr.Login(sUserName, sPassword)

        If mUser Is Nothing Then
            'mAudit.AddEntry(AccessController.AuditLogWriter.EventType.LoginFailed, txtUser.Text, mTerminalId, "")

            bDisabled = mSecMgr.SetUnsuccessfulAttempt(sUserName)

            If bDisabled Then
                'EWMessageBox.Show("Ha superado la cantidad máxima de intentos permitidos. La cuenta ha sido bloqueada.", "e-wave", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            Else
                ' EWMessageBox.Show("El nombre de usuario y la contraseña no coinciden con un perfil válido. Por favor intentelo nuevamente.", "e-wave", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                txtPassword.Focus()
            End If
        Else
            ' mAudit.AddEntry(AccessController.AuditLogWriter.EventType.LoginSucceded, mUser.Id, mTerminalId, "")
            mUser.Password = txtPassword.Text '[AMI220405]
            Close()
        End If

        Cursor = Cursors.Arrow
    End Sub

#End Region

#Region " GlobalResourcesLoader "

    Private Sub LoadGlobalCaptions()
        'Me.Text = EnvironmentObjects.Framework.GlobalResources.GetString("FormText", Me.Text)
        'lblUser.Text = EnvironmentObjects.Framework.GlobalResources.GetString("lblUser", Me.lblUser.Text)
        'lblPassword.Text = EnvironmentObjects.Framework.GlobalResources.GetString("lblPassword", Me.lblPassword.Text)
        'btnOk.Text = EnvironmentObjects.Framework.GlobalResources.GetString("btnOk", Me.btnOk.Text)
        'btnCancel.Text = EnvironmentObjects.Framework.GlobalResources.GetString("btnCancel", Me.btnCancel.Text)
    End Sub
#End Region
End Class
