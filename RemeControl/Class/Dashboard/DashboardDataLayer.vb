Imports Newtonsoft.Json

Public Class DashboardData
    Private dOP_DateStart As String
    Private dOP_DateEnd As String
    Private iOP_Socio As Integer

    Public Property OP_DateStart As String
        Get
            Return dOP_DateStart
        End Get
        Set(value As String)
            dOP_DateStart = value
        End Set
    End Property

    Public Property OP_DateEnd As String
        Get
            Return dOP_DateEnd
        End Get
        Set(value As String)
            dOP_DateEnd = value
        End Set
    End Property

    Public Property OP_Socio As Integer
        Get
            Return iOP_Socio
        End Get
        Set(value As Integer)
            iOP_Socio = value
        End Set
    End Property
End Class
Public Class DashboardDataLayer
    Inherits JsonConnect

    Public Function GetCambios(Data As DashboardData) As DataTable
        Dim Dash As DashboardData = Nothing
        Dim Url As String = ApiConstants.GetCambiosDiarios
        Dim table As DataTable
        Try
            Dash = New DashboardData

            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Get = PostJson(Url, result, oApp.CurrentUser)


            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
        Catch ex As Exception
            Return Nothing
        End Try

        Return table
    End Function

End Class
