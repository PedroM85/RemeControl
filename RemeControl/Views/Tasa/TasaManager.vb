Public Class TasaManager
    Private oTasaView As TasaView

    Public Function CreateTasaView() As TasaView
        oTasaView = New TasaView

        With oTasaView

            .Caption = "Administrador de tasa"

            .LoadData()

        End With

        Return oTasaView
    End Function


End Class
