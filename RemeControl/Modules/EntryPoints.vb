Module EntryPoints

    Private mUserName As String
    Private mPassword As String


    Public Sub Main()


        oApp = New MgrFramework
        Dim TM As New TransactionManager

        If oApp.InitConnection() Then

            If oApp.Init Then
                oApp.SetupLocalizationInfo()


                GetCommandLineArgs()


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
                    MessageBox.Show("El usuario o contraseña invalido" & vbCrLf & "Compruebe la información de conexión." & vbCrLf & "La ip publica es: " & oApp.IpPc & vbCrLf & " Error 0x00010615", "Unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If

            End If
        Else
            MessageBox.Show("Se produjeron errores al inicializar la aplicacion." & vbCrLf & "Compruebe la información de conexión o contáctese con el administrador del sistema.", "Unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If


        'Codigo de error
        'Clave o contraseña invalido - >0x00010615
    End Sub

    Public Sub GetCommandLineArgs()
        Dim Args() As String = Environment.GetCommandLineArgs
        Dim KeyValue() As String

        For Each Arg As String In Args
            If Arg.IndexOf("="c) > -1 Then
                KeyValue = Arg.Split("=")
                Select Case KeyValue(0).ToLower
                    Case "usr"
                        If KeyValue(1).Trim.Length > 0 Then
                            mUserName = KeyValue(1)
                        End If
                    Case "pwd"
                        If KeyValue(1).Trim.Length > 0 Then
                            mPassword = KeyValue(1)
                        End If
                End Select
            End If
        Next
    End Sub

End Module
