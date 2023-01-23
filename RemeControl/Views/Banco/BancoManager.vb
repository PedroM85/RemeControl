Public Class BancoManager

    Private oBancoView As BancoView

    Public Function CreateBancaView() As BancoView
        oBancoView = New BancoView

        With oBancoView

            .Caption = "Administrador de Banco"

            .LoadData()

        End With

        Return oBancoView
    End Function

End Class
