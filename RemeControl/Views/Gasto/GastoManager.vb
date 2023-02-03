Public Class GastoManager
    Private oGastoView As GastoView

    Public Function CreateGastoView() As GastoView
        oGastoView = New GastoView

        With oGastoView

            .Caption = "Administrador de gasto"

            .LoadData()

        End With

        Return oGastoView
    End Function
End Class
