Public Class ShowTurnos
    Inherits Controller

    'Private mFormMain As FormMain
    Private oSessionView As SessionView
    'Public Sub New(oFormMain As FormMain)
    '    Me.mFormMain = oFormMain
    'End Sub
    Public Sub New(oSessionView As SessionView)
        Me.oSessionView = oSessionView
    End Sub
    Public Overrides Sub HandleKey(e As KeyEventArgs)
        e.Handled = True

        Select Case e.KeyCode
            Case Keys.Enter
                SendKeys.Send("{TAB}")
            Case Keys.Subtract
                oSessionView.GoToPreviousDay()
            Case Keys.Add
                oSessionView.GoToNextDay()


        End Select
    End Sub
End Class
