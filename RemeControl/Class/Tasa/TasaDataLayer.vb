Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Public Class TasaData
    Private iTAS_Id As Int32
    Private dTAS_Date As Date
    Private doTAS_Binance As Decimal
    Private doTAS_DolarPais As Decimal
    Private doTAS_Comision As Decimal
    Private doTAS_TasaFull As Decimal
    Private doTAS_TasaMayorista As Decimal
    Private doTAS_TasaCliente As Decimal
    Private sTAS_ModifiedBy As String
    Private bTAS_Active As Boolean
    Private sMessage As String


    Public Property TAS_Id As Integer
        Get
            Return iTAS_Id
        End Get
        Set(value As Integer)
            iTAS_Id = value
        End Set
    End Property

    Public Property TAS_Date As Date
        Get
            Return dTAS_Date
        End Get
        Set(value As Date)
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

    Public Property TAS_Active As Boolean
        Get
            Return bTAS_Active
        End Get
        Set(value As Boolean)
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
End Class
Public Class TasaDataLayer
    Inherits JsonConnect

    Public Function GetTasas() As DataTable
        Dim tasa As TasaData = Nothing
        Dim url As String = ApiConstants.GetTasas

        tasa = New TasaData

        'Dim result = JsonConvert.SerializeObject(UserData)

        Dim result_Post = GetJson(url, oApp.CurrentUser)

        'tasa = JsonConvert.DeserializeObject(Of TasaData)(result_Post)
        Dim table = JsonConvert.DeserializeObject(Of DataTable)(result_Post)

        Return table

    End Function

    Public Sub CreateTasa(Data As TasaData)
        Dim tasa As TasaData = Nothing
        Dim Url As String = ApiConstants.CreateTasa


        Dim result = JsonConvert.SerializeObject(Data)

        Dim result_Post = PostJson(Url, result, oApp.CurrentUser)

        Dim coso = JsonConvert.DeserializeObject(Of TasaData)(result_Post)

        tasa = coso

    End Sub

    Public Sub UpdateTasa(Data As TasaData)
        Dim tasa As TasaData = Nothing
        Dim Url As String = ApiConstants.UpdateTasa


        Dim result = JsonConvert.SerializeObject(Data)

        Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

        Dim coso = JsonConvert.DeserializeObject(Of TasaData)(result_Post)

        tasa = coso
    End Sub

    Public Sub DeleteTasa(Data As TasaData)
        Dim tasa As TasaData = Nothing
        Dim Url As String = ApiConstants.DeleteTasa


        Dim result = JsonConvert.SerializeObject(Data)

        Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

        Dim coso = JsonConvert.DeserializeObject(Of TasaData)(result_Post)

        tasa = coso
    End Sub

End Class

