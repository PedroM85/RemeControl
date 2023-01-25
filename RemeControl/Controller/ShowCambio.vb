Public Class ShowCambio
    Inherits Controller

    Private mFormMain As FormMain

    Public Sub New(oFormMain As FormMain)
        Me.mFormMain = oFormMain
    End Sub
    Public Overrides Sub HandleKey(e As KeyEventArgs)
        e.Handled = True

        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
        End Select
    End Sub
End Class
