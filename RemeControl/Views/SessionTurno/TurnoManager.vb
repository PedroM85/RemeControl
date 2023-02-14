Public Class TurnoManager
    Private oSessionDate As SessionView

    Public Function CreateoSessionViewDate() As SessionView
        oSessionDate = New SessionView

        With oSessionDate

            .LoadData()


        End With

        Return oSessionDate
    End Function
End Class
