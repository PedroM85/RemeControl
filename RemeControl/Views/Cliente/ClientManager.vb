Public Class ClientManager
    Private oClientView As ClientView

    Public Function CreateClientView() As ClientView
        oClientView = New ClientView

        With oClientView

            .Caption = "Administrador de cliente"

            .LoadData()

        End With

        Return oClientView
    End Function
End Class
