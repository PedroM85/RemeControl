Imports Newtonsoft.Json

Public Class ClienteData
    Private iCLI_Id As Integer
    Private sCLI_Nombre As String
    Private iCLI_Banco As Integer
    Private sCLI_Cuenta As String
    Private sCLI_Titular As String
    Private sCLI_Cedula As String
    Private sCLI_ModifiedBy As String
    Private sCLI_Active As Integer

    Public Property CLI_Id As Integer
        Get
            Return iCLI_Id
        End Get
        Set(value As Integer)
            iCLI_Id = value
        End Set
    End Property

    Public Property CLI_Nombre As String
        Get
            Return sCLI_Nombre
        End Get
        Set(value As String)
            sCLI_Nombre = value
        End Set
    End Property

    Public Property CLI_Banco As Integer
        Get
            Return iCLI_Banco
        End Get
        Set(value As Integer)
            iCLI_Banco = value
        End Set
    End Property

    Public Property CLI_Cuenta As String
        Get
            Return sCLI_Cuenta
        End Get
        Set(value As String)
            sCLI_Cuenta = value
        End Set
    End Property

    Public Property CLI_Titular As String
        Get
            Return sCLI_Titular
        End Get
        Set(value As String)
            sCLI_Titular = value
        End Set
    End Property

    Public Property CLI_Cedula As String
        Get
            Return sCLI_Cedula
        End Get
        Set(value As String)
            sCLI_Cedula = value
        End Set
    End Property

    Public Property CLI_ModifiedBy As String
        Get
            Return sCLI_ModifiedBy
        End Get
        Set(value As String)
            sCLI_ModifiedBy = value
        End Set
    End Property

    Public Property CLI_Active As Integer
        Get
            Return sCLI_Active
        End Get
        Set(value As Integer)
            sCLI_Active = value
        End Set
    End Property
End Class
Public Class ClienteDataLayer
    Inherits JsonConnect

    Public Function GetClientes() As DataTable
        Dim Cliente As ClienteData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.PostCliente)
        Dim table As DataTable
        Try
            Cliente = New ClienteData

            Dim result_Get = GetJson(Url, oApp.CurrentUser)


            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
        Catch ex As Exception
            Return Nothing
        End Try

        Return table
    End Function

    Public Sub CreateCliente(Data As ClienteData)
        Dim Cliente As ClienteData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.CreateCliente)
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PostJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of ClienteData)(result_Post)

            Cliente = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub UpdateCliente(Data As ClienteData)
        Dim Cliente As ClienteData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.UpdateCliente)
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of ClienteData)(result_Post)

            Cliente = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub DeleteCliente(Data As ClienteData)
        Dim Cliente As ClienteData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.DeleteCliente)
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of ClienteData)(result_Post)

            Cliente = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
End Class
