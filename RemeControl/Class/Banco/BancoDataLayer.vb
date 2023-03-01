Imports Newtonsoft.Json
Public Class BancoData
    Private iBAN_Id As Integer
    Private sBAN_Name As String
    Private iBAN_Type As Integer
    Private sBAN_Prefix As String
    Private sBAN_ModifiedBy As String
    Private iBAN_ACtive As Integer

    Public Property BAN_Id As Integer
        Get
            Return iBAN_Id
        End Get
        Set(value As Integer)
            iBAN_Id = value
        End Set
    End Property

    Public Property BAN_Name As String
        Get
            Return sBAN_Name
        End Get
        Set(value As String)
            sBAN_Name = value
        End Set
    End Property

    Public Property BAN_Type As Integer
        Get
            Return iBAN_Type
        End Get
        Set(value As Integer)
            iBAN_Type = value
        End Set
    End Property

    Public Property BAN_Prefix As String
        Get
            Return sBAN_Prefix
        End Get
        Set(value As String)
            sBAN_Prefix = value
        End Set
    End Property

    Public Property BAN_ModifiedBy As String
        Get
            Return sBAN_ModifiedBy
        End Get
        Set(value As String)
            sBAN_ModifiedBy = value
        End Set
    End Property

    Public Property BAN_Active As Integer
        Get
            Return iBAN_ACtive
        End Get
        Set(value As Integer)
            iBAN_ACtive = value
        End Set
    End Property
End Class
Public Class BancoDataLayer
    Inherits JsonConnect

    Public Function GetBancos() As DataTable
        Dim Banco As BancoData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.GetBancos)
        Dim table As DataTable
        Try
            Banco = New BancoData

            Dim result_Get = GetJson(Url, oApp.CurrentUser)


            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
        Catch ex As Exception
            Return Nothing
        End Try

        Return table
    End Function

    Public Sub CreateBanco(Data As BancoData)
        Dim Banco As BancoData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.CreateBanco)
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PostJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of BancoData)(result_Post)

            Banco = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub UpdateBanco(Data As BancoData)
        Dim Banco As BancoData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.UpdateBanco)
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of BancoData)(result_Post)

            Banco = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub DeleteBanco(Data As BancoData)
        Dim Banco As BancoData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.DeleteBanco)
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of BancoData)(result_Post)

            Banco = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Function GetAcountType() As DataTable
        Dim Banco As BancoData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.GetAccountType)
        Dim table As DataTable
        Try
            Banco = New BancoData

            Dim result_Get = GetJson(Url, oApp.CurrentUser)


            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
        Catch ex As Exception
            Return Nothing
        End Try

        Return table
    End Function

    Public Function GetAcount() As DataTable
        Dim Banco As BancoData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.GetAccount)
        Dim table As DataTable
        Try
            Banco = New BancoData

            Dim result_Get = GetJson(Url, oApp.CurrentUser)


            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
        Catch ex As Exception
            Return Nothing
        End Try

        Return table
    End Function

End Class
