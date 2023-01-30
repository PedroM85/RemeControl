Module EntryPoints

    Private mUserName As String
    Private mPassword As String
    Public Sub Main()


        oApp = New MgrFramework
        Dim TM As New TransactionManager

        If oApp.InitConnection() Then

            oApp.SetupLocalizationInfo()

            oApp.LoginUser(mUserName, mPassword)

            If Not oApp.CurrentUser Is Nothing Then

                If oApp.RegisterLogin(oApp.CurrentUser) Then

                    oMainForm = New FormMain
                    oMainForm.TransactionManager = TM

                    oMainForm.Show()

                    Application.Run(oMainForm)

                    oApp.RegisterLogout()

                End If
            Else
                MessageBox.Show("Se produjeron errores al inicializar la aplicacion." & vbCrLf & "Compruebe la información de conexión o contáctese con el administrador del sistema." & vbCrLf & "La ip publica es: " & oApp.IpPc & " con error 0x00034404", "Unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Else
            MessageBox.Show("Se produjeron errores al inicializar la aplicacion." & vbCrLf & "Compruebe la información de conexión o contáctese con el administrador del sistema.", "Unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If



    End Sub



End Module
