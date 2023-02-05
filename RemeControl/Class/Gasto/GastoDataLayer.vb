Imports Newtonsoft.Json

Public Class GastoData

End Class
Public Class GastoDataLayer
    Inherits JsonConnect

    Public Function GetTest() As DataTable
        'Dim Dash As DashboardData = Nothing
        Dim Url As String = ApiConstants.Pong
        Dim table As DataTable
        Try
            'Dash = New DashboardData

            'Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Get = GetJson(Url, oApp.CurrentUser)


            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
        Catch ex As Exception
            Return Nothing
        End Try

        Return table
    End Function
End Class
