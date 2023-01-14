
Public MustInherit Class EWTransactionManager

        Public Event ViewCreated(View As System.Windows.Forms.UserControl)


        Public MustOverride Function Execute(sTransaction As String) As System.Windows.Forms.UserControl


        Public Sub DoMenuItem(oMenuItem As String)
            RaiseEvent ViewCreated(Execute(oMenuItem))
        End Sub
    End Class

