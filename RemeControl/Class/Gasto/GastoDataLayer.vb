Imports Newtonsoft.Json

Public Class GastoData
    Private iGAT_Id As Integer
    Private dGAT_Date As DateTime
    Private iGAT_SOC_Id As Integer
    Private iGAT_OSB_Id As Integer
    Private IGAT_OSBT_Id As Integer
    Private sGAT_Reason As String
    Private dGAT_Amount As Decimal
    Private sGAT_ModifiedBy As String
    Private iGAT_Active As Integer

    Public Property GAT_Id As Integer
        Get
            Return iGAT_Id
        End Get
        Set(value As Integer)
            iGAT_Id = value
        End Set
    End Property

    Public Property GAT_Date As Date
        Get
            Return dGAT_Date
        End Get
        Set(value As Date)
            dGAT_Date = value
        End Set
    End Property

    Public Property GAT_SOC_Id As Integer
        Get
            Return iGAT_SOC_Id
        End Get
        Set(value As Integer)
            iGAT_SOC_Id = value
        End Set
    End Property

    Public Property GAT_OSB_Id As Integer
        Get
            Return iGAT_OSB_Id
        End Get
        Set(value As Integer)
            iGAT_OSB_Id = value
        End Set
    End Property

    Public Property GAT_OSBT_Id As Integer
        Get
            Return IGAT_OSBT_Id
        End Get
        Set(value As Integer)
            IGAT_OSBT_Id = value
        End Set
    End Property

    Public Property GAT_Reason As String
        Get
            Return sGAT_Reason
        End Get
        Set(value As String)
            sGAT_Reason = value
        End Set
    End Property

    Public Property GAT_Amount As Decimal
        Get
            Return dGAT_Amount
        End Get
        Set(value As Decimal)
            dGAT_Amount = value
        End Set
    End Property

    Public Property GAT_ModifiedBy As String
        Get
            Return sGAT_ModifiedBy
        End Get
        Set(value As String)
            sGAT_ModifiedBy = value
        End Set
    End Property

    Public Property GAT_Active As Integer
        Get
            Return iGAT_Active
        End Get
        Set(value As Integer)
            iGAT_Active = value
        End Set
    End Property
End Class
Public Class GastoDataLayer
    Inherits JsonConnect

    Public Function GetSocios() As DataTable
        Dim Url As String = ApiConstants.GetSocios
        Dim table As DataTable
        Try
            Dim result_Get = GetJson(Url, oApp.CurrentUser)


            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
        Catch ex As Exception
            Return Nothing
        End Try

        Return table
    End Function

    Public Function GetGastos() As DataTable
        Dim Url As String = ApiConstants.GetGasto
        Dim table As DataTable
        Try
            Dim result_Get = GetJson(Url, oApp.CurrentUser)


            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
        Catch ex As Exception
            Return Nothing
        End Try

        Return table
    End Function

    Public Sub CreateGasto(Data As GastoData)
        Dim Gasto As GastoData = Nothing
        Dim Url As String = ApiConstants.CreateGasto
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PostJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of GastoData)(result_Post)

            Gasto = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub UpdateGasto(Data As GastoData)
        Dim Gasto As GastoData = Nothing
        Dim Url As String = ApiConstants.UpdateGasto
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of GastoData)(result_Post)

            Gasto = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub DeleteGasto(Data As GastoData)
        Dim Gasto As GastoData = Nothing
        Dim Url As String = ApiConstants.DeleteGasto
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of GastoData)(result_Post)

            Gasto = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
End Class
