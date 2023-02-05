Public Class BancoSoManager
    Private oBancoSoView As BancoSoView

    Public Function CreateBancoView() As BancoSoView
        oBancoSoView = New BancoSoView

        With oBancoSoView

            .Caption = "Administrador de banco socios"

            .LoadData()

        End With

        Return oBancoSoView
    End Function
End Class
