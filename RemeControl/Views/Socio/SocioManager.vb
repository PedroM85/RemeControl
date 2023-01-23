Public Class SocioManager
    Private oSocioView As SocioView

    Public Function CreateSocioView() As SocioView
        oSocioView = New SocioView

        With oSocioView

            .Caption = "Administrador de socio"

            .LoadData()

        End With

        Return oSocioView
    End Function

End Class
