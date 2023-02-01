Public Class DashManager
    Private oDashView As DashView

    Public Function CreateDashView() As DashView
        oDashView = New DashView

        With oDashView

            '.Caption = "Administrador de cliente"

            .LoadData()

        End With

        Return oDashView
    End Function
End Class
