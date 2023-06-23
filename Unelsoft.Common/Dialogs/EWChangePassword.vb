Imports System.Windows.Forms

Public Class EWChangePassword


    Private mUser As Unelsoft.AccessController.User
    Private oSecMgr As New AccessController.SecurityManager(EnvironmentObjects.Framework.Connection)
    'Private mAudit As Unelsoft.AccessController.AuditLogWriter = New AccessController.AuditLogWriter(EnvironmentObjects.Framework.Connection, EnvironmentObjects.Framework.SiteId)
    Private mTerminalId As String

    Public Sub New(sTerminal As String, User As Unelsoft.AccessController.User)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        mUser = User
        mTerminalId = sTerminal

        Me.LoadGlobalCaptions()

    End Sub

    Dim mRejectSamePassword As Boolean = True

    Private Sub btnAccept_Click(sender As Object, e As EventArgs) Handles btnAccept.Click
        'Dim sErrorMsg As String = GlobalCaptions.MESSAGE_EmptyField

        If txtPassword.Text <> txtConfirmPassword.Text Then
            EWMessageBox.Show(Me, btnAcceptMsg1, "unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If Me.RejectSamePassword Then
            ' Verifica que el nuevo password sea diferente al anterior
            If mUser.EncryptPassword(txtPassword.Text) = mUser.Password Then
                EWMessageBox.Show(btnAcceptMsg4, , MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        End If

        If txtPassword.Text.Trim = String.Empty Then
            EWMessageBox.Show(sErrorMsg, , MessageBoxButtons.OK, MessageBoxIcon.Information)
            txtPassword.Select()
            Exit Sub
        End If

        If txtPassword.Text.Length < Convert.ToSingle(EnvironmentObjects.Framework.Parameters("PWDCHARMIN")) Then
            Unelsoft.Common.EWMessageBox.Show(btnAcceptMsg5 & Space(1) & Convert.ToSingle(EnvironmentObjects.Framework.Parameters("PWDCHARMIN")).ToString & Space(1) & btnAcceptMsg6, , MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtPassword.Select()
            Exit Sub
        End If

        If EnvironmentObjects.Framework.Parameters("PWDCOMPLEX") = "complex" Then
            If Not oSecMgr.IsComplexPassword(txtPassword.Text) Then
                Unelsoft.Common.EWMessageBox.Show(ErrorPasswordComplex)
                txtPassword.Select()
                Exit Sub
            End If
        End If

        If oSecMgr.IsRepeatPassword(EnvironmentObjects.Framework.CurrentUser.Id, oSecMgr.EncryptData(EnvironmentObjects.Framework.CurrentUser.Id & txtPassword.Text)) Then
            Unelsoft.Common.EWMessageBox.Show(ErrorPasswordRepeat)
            txtPassword.Select()
            Exit Sub
        End If

        Try
            Dim oSecMgr As New AccessController.SecurityManager(EnvironmentObjects.Framework.Connection)
            oSecMgr.ChangePassword(mUser.Id, txtPassword.Text)
            'mAudit.AddEntry(AccessController.AuditLogWriter.EventType.PasswordChange, mUser.Id, mTerminalId, "")
            mUser.Password = txtPassword.Text ' Actualiza el password
            EWMessageBox.Show(Me, btnAcceptMsg2, "unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.DialogResult = DialogResult.OK
            Close()
        Catch oEx As Exception
            EWMessageBox.Show(Me, btnAcceptMsg3, "unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub
    Public WriteOnly Property UserId() As String
        Set(ByVal Value As String)
            mUser.Id = Value
        End Set
    End Property

    Private Property RejectSamePassword() As Boolean
        Get
            Return mRejectSamePassword
        End Get
        Set(ByVal Value As Boolean)
            mRejectSamePassword = Value
        End Set
    End Property
#Region " GlobalResourcesLoader "

    Dim btnAcceptMsg1 As String
    Dim btnAcceptMsg2 As String
    Dim btnAcceptMsg3 As String
    Dim btnAcceptMsg4 As String
    Dim btnAcceptMsg5 As String
    Dim btnAcceptMsg6 As String
    Dim sErrorMsg As String
    Dim ErrorPasswordComplex As String
    Dim ErrorPasswordRepeat As String

    Public Sub LoadGlobalCaptions()

        'btnAccept.Text = "Aceptar"
        'btnCancel.Text = "Cancelar"
        'lblConfirmPassword.Text = "ConfirmPassword"
        'lblPassword.Text = "lblPasswordText"
        'Me.Text = "a"
        btnAcceptMsg1 = "La contraseña ingresada no coincide."
        btnAcceptMsg2 = "La contraseña fue cambiada con éxito."
        btnAcceptMsg3 = "Error al cambiar la contraseña."
        btnAcceptMsg4 = "La nueva clave debe ser distinta a la anterior."
        btnAcceptMsg5 = "La contraseña debe contener al menos"
        btnAcceptMsg6 = "caracteres"
        sErrorMsg = "Los campos estan vacios."
        ErrorPasswordComplex = "La contraseña debe contener letras y números."
        ErrorPasswordRepeat = "La contraseña ingresada ya fue utilizada anteriormente."
    End Sub

#End Region
End Class
