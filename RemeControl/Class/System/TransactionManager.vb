Public Class TransactionManager
    Inherits EWTransactionManager

    Public Overrides Function Execute(sTransation As String) As System.Windows.Forms.UserControl
        Dim oView As UserControl

        Select Case sTransation.Trim

            Case Else
                oView = Nothing
        End Select

        Return oView

    End Function

End Class
