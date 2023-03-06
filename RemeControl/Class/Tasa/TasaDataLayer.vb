Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Public Class TasaData
    Private iTAS_Id As Int32
    Private dTAS_Date As DateTime
    Private iTAS_Socio As Integer
    Private doTAS_Binance As Decimal
    Private doTAS_DolarPais As Decimal
    Private doTAS_Comision As Decimal
    Private doTAS_TasaFull As Decimal
    Private doTAS_TasaMayorista As Decimal
    Private doTAS_TasaCliente As Decimal
    Private sTAS_ModifiedBy As String
    Private bTAS_Active As Integer
    Private sMessage As String


    Public Property TAS_Id As Integer
        Get
            Return iTAS_Id
        End Get
        Set(value As Integer)
            iTAS_Id = value
        End Set
    End Property

    Public Property TAS_Date As DateTime
        Get
            Return dTAS_Date
        End Get
        Set(value As DateTime)
            dTAS_Date = value
        End Set
    End Property

    Public Property TAS_Binance As Decimal
        Get
            Return doTAS_Binance
        End Get
        Set(value As Decimal)
            doTAS_Binance = value.ToString("n2")
        End Set
    End Property

    Public Property TAS_DolarPais As Decimal
        Get
            Return doTAS_DolarPais
        End Get
        Set(value As Decimal)
            doTAS_DolarPais = value.ToString("n2")
        End Set
    End Property

    Public Property TAS_Comision As Decimal
        Get
            Return doTAS_Comision
        End Get
        Set(value As Decimal)
            doTAS_Comision = value.ToString("n2")
        End Set
    End Property

    Public Property TAS_TasaFull As Decimal
        Get
            Return doTAS_TasaFull
        End Get
        Set(value As Decimal)
            doTAS_TasaFull = value.ToString("n6")
        End Set
    End Property

    Public Property TAS_TasaMayorista As Decimal
        Get
            Return doTAS_TasaMayorista
        End Get
        Set(value As Decimal)
            doTAS_TasaMayorista = value.ToString("n6")
        End Set
    End Property

    Public Property TAS_TasaCliente As Decimal
        Get
            Return doTAS_TasaCliente
        End Get
        Set(value As Decimal)
            doTAS_TasaCliente = value.ToString("n4")
        End Set
    End Property

    Public Property Message As String
        Get
            Return sMessage
        End Get
        Set(value As String)
            sMessage = value
        End Set
    End Property

    Public Property TAS_Active As Integer
        Get
            Return bTAS_Active
        End Get
        Set(value As Integer)
            bTAS_Active = value
        End Set
    End Property

    Public Property TAS_ModifiedBy As String
        Get
            Return sTAS_ModifiedBy
        End Get
        Set(value As String)
            sTAS_ModifiedBy = value
        End Set
    End Property

    Public Property TAS_Socio As Integer
        Get
            Return iTAS_Socio
        End Get
        Set(value As Integer)
            iTAS_Socio = value
        End Set
    End Property
End Class
Public Class TasaDataLayer
    Inherits JsonConnect

    Public Function GetSocios() As DataTable
        Dim Socios As SocioData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.GetSocios)
        Dim table As DataTable
        Try
            Socios = New SocioData

            Dim result_Get = GetJson(Url, oApp.CurrentUser)


            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
        Catch ex As Exception
            Return Nothing
        End Try

        Return table
    End Function
    Public Function GetTasas() As DataTable
        Dim Table As DataTable = Nothing
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.GetTasas)
        Try

            Dim result_Post = GetJson(url, oApp.CurrentUser)

            Table = JsonConvert.DeserializeObject(Of DataTable)(result_Post)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

        Return Table

    End Function

    Public Sub CreateTasa(Data As TasaData)
        Dim tasa As TasaData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.CreateTasa)


        Dim result = JsonConvert.SerializeObject(Data)

        Dim result_Post = PostJson(Url, result, oApp.CurrentUser)

        Dim coso = JsonConvert.DeserializeObject(Of TasaData)(result_Post)

        tasa = coso

    End Sub

    Public Sub UpdateTasa(Data As TasaData)
        Dim tasa As TasaData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.UpdateTasa)


        Dim result = JsonConvert.SerializeObject(Data)

        Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

        Dim coso = JsonConvert.DeserializeObject(Of TasaData)(result_Post)

        tasa = coso
    End Sub

    Public Sub DeleteTasa(Data As TasaData)
        Dim tasa As TasaData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.DeleteTasa)


        Dim result = JsonConvert.SerializeObject(Data)

        Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

        Dim coso = JsonConvert.DeserializeObject(Of TasaData)(result_Post)

        tasa = coso
    End Sub

End Class

