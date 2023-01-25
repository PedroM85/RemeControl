Public Class CambioManager
    Private oCambioView As CambioView

    Public Function CreateCambioView() As CambioView
        oCambioView = New CambioView

        With oCambioView

            .Caption = "Administrador de cambios"

            .LoadData()

        End With

        Return oCambioView
    End Function
End Class
