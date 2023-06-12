Public Class TransactionManager
    Inherits EWTransactionManager

    Public Overrides Function Execute(sTransaction As String) As UserControl
        Dim oView As UserControl
        Select Case sTransaction
            Case Else
                oView = Nothing
        End Select
        Return oView
    End Function
End Class
