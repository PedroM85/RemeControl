Imports Newtonsoft.Json

Public Class BancoSoData
    Private iOSB_Id As Integer
    Private sOSB_Nombre As String
    Private iOSB_Type As Integer
    Private sOSB_Account As String
    Private dOSB_InitialBalance As Decimal
    Private dOSB_BeginninBalanceDate As DateTime
    Private sOSB_Description As String
    Private sOSB_ModifiedBy As String
    Private bOSB_Active As Integer

    Public Property OSB_Id As Integer
        Get
            Return iOSB_Id
        End Get
        Set(value As Integer)
            iOSB_Id = value
        End Set
    End Property

    Public Property OSB_Nombre As String
        Get
            Return sOSB_Nombre
        End Get
        Set(value As String)
            sOSB_Nombre = value
        End Set
    End Property

    Public Property OSB_Type As Integer
        Get
            Return iOSB_Type
        End Get
        Set(value As Integer)
            iOSB_Type = value
        End Set
    End Property

    Public Property OSB_Account As String
        Get
            Return sOSB_Account
        End Get
        Set(value As String)
            sOSB_Account = value
        End Set
    End Property

    Public Property OSB_InitialBalance As Decimal
        Get
            Return dOSB_InitialBalance
        End Get
        Set(value As Decimal)
            dOSB_InitialBalance = value
        End Set
    End Property

    Public Property OSB_BeginninBalanceDate As Date
        Get
            Return dOSB_BeginninBalanceDate
        End Get
        Set(value As Date)
            dOSB_BeginninBalanceDate = value
        End Set
    End Property

    Public Property OSB_Description As String
        Get
            Return sOSB_Description
        End Get
        Set(value As String)
            sOSB_Description = value
        End Set
    End Property

    Public Property OSB_ModifiedBy As String
        Get
            Return sOSB_ModifiedBy
        End Get
        Set(value As String)
            sOSB_ModifiedBy = value
        End Set
    End Property

    Public Property OSB_Active As Integer
        Get
            Return bOSB_Active
        End Get
        Set(value As Integer)
            bOSB_Active = value
        End Set
    End Property
End Class

Public Class BancoSoDataLayer
    Inherits JsonConnect

    Public Function GetBancoSo() As DataTable
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.GetBancoSocio)
        Dim table As DataTable
        Try
            Dim result_Get = GetJson(Url, oApp.CurrentUser)

            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
        Catch ex As Exception
            Return Nothing
        End Try

        Return table
    End Function

    Public Function GetAcountType() As DataTable
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.GetBancoSoType)
        Dim table As DataTable

        Try
            Dim result_Get = GetJson(Url, oApp.CurrentUser)

            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
        Catch ex As Exception
            Return Nothing
        End Try

        Return table
    End Function
    Public Sub CreateBancoSo(Data As BancoSoData)
        Dim Banco As BancoData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.CreateBancoSo)
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PostJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of BancoData)(result_Post)

            Banco = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub UpdateBancoSo(Data As BancoSoData)
        Dim Banco As BancoData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.UpdateBancoSo)
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of BancoData)(result_Post)

            Banco = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub DeleteBancoSo(Data As BancoSoData)
        Dim BancoSo As BancoSoData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.DeleteBancoSocio)
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of BancoSoData)(result_Post)

            BancoSo = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

End Class
