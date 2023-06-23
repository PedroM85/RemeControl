Module EntryPoints

    Public Sub Main(args As String())
        Try
            Dim userName As String = GetCommandLineArgValue(args, "usr")
            Dim password As String = GetCommandLineArgValue(args, "pwd")

            Dim oSplash As Splash
            Dim oApp As New MgrFramework()
            Dim TM As New TransactionManager()

            If oApp.GetConnectionInfo() Then
                oSplash = New Splash
                oSplash.Show()
                oSplash.Update()
                Application.DoEvents()

                If oApp.InitConnection Then
                    Unelsoft.Common.EnvironmentObjects.Framework = oApp
                    If oApp.CheckIfTerminalRegistered() Then
                        If oApp.Init Then

                            oSplash.Hide()
                            oApp.LoginUser(userName, password)

                            If Not oApp.CurrentUser Is Nothing Then
                                If oApp.CurrentUser.CanEnterApplication Then
                                    oApp.CleanOldLogins()
                                    If oApp.HasLicensesFree Then
                                        oSplash.Show()
                                        oSplash.Update()

                                        If oApp.RegisterLogin(oApp.CurrentUser, True) Then
                                            If oApp.CheckIfPasswordMustBeChanged Then
                                                If oApp.CurrentUser.CanAccessManager Then

                                                    'Datalayer

                                                End If
                                            End If
                                        End If
                                    End If

                                End If
                            End If

                        End If

                    Else
                        Unelsoft.Common.EWMessageBox.Show("No se encuentra la información correspondiente a la terminal en la Registry de Windows.", "Unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    MessageBox.Show("Se produjeron errores al inicializar la aplicación." & vbCrLf & "Compruebe la información de conexión o contáctese con el administrador del sistema.", "Unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                'If oApp.InitConnection() AndAlso oApp.Init() Then
                '    'GetCommandLineArgs()
                '    oApp.LoginUser(userName, password)

                '    If oApp.CurrentUser IsNot Nothing AndAlso oApp.RegisterLogin(oApp.CurrentUser) Then
                '        Dim oMainForm As New frmMainBase()
                '        oMainForm.TransactionManager = TM

                '        oMainForm.Show()
                '        Application.Run(oMainForm)
                '        oApp.RegisterLogout()
                '    ElseIf oApp.CurrentUser Is Nothing Then
                '        MessageBox.Show("El usuario o contraseña son inválidos." & vbCrLf & "Compruebe la información de conexión." & vbCrLf & "La IP pública es: " & oApp.IpPc, "Unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    End If
                'Else
                '    MessageBox.Show("Se produjeron errores al inicializar la aplicación." & vbCrLf & "Compruebe la información de conexión o contáctese con el administrador del sistema.", "Unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End If
            Else
                MessageBox.Show("No se encontró la información de conexión de la aplicación.", "Unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Function GetCommandLineArgValue(args As String(), key As String) As String
        For Each arg As String In args
            If arg.StartsWith(key & "=") Then
                Return arg.Substring(key.Length + 1).Trim()
            End If
        Next
        Return ""
    End Function


End Module
