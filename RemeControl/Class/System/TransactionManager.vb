Public Class TransactionManager
    Inherits EWTransactionManager

    Public Overrides Function Execute(sTransation As String) As System.Windows.Forms.UserControl
        Dim oView As UserControl

        Select Case sTransation.Trim

            Case "TASA"
                Dim oTasa As TasaManager = New TasaManager
                oView = oTasa.CreateTasaView
            Case "SOCIO"
                Dim oSocio As SocioManager = New SocioManager
                oView = oSocio.CreateSocioView
            Case "CLIENTE"
                Dim oCliente As ClientManager = New ClientManager
                oView = oCliente.CreateClientView
            Case "BANCO"
                Dim oBanco As BancoManager = New BancoManager
                oView = oBanco.CreateBancoView

            Case Else
                oView = Nothing
        End Select

        Return oView

    End Function

End Class
