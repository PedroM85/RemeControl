Public Class SessionManager
    'Private oSessionView As SessionView
    Private oSessionDate As SessionDate

    Public Function CreateoSessionDate() As SessionDate
        oSessionDate = New SessionDate

        With oSessionDate


        End With

        Return oSessionDate
    End Function
    'Public Function CreateoSessionView() As SessionView
    '    oSessionView = New SessionView

    '    With oSessionView

    '        '.Caption = "Administrador de gasto"

    '        '.LoadData()

    '    End With

    '    Return oSessionView
    'End Function
End Class
