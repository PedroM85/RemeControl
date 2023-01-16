Imports Microsoft.VisualBasic.ApplicationServices
Imports Newtonsoft.Json
Public Class TasaData
    Private iTAS_Id As Int32
    Private dTAS_Date As Date
    Private doTAS_Amount As Double
    Private doTAS_Mayorista As Double

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

    Public Property TAS_Amount As Double
        Get
            Return doTAS_Amount
        End Get
        Set(value As Double)
            doTAS_Amount = value
        End Set
    End Property

    Public Property TAS_Mayorista As Double
        Get
            Return doTAS_Mayorista
        End Get
        Set(value As Double)
            doTAS_Mayorista = value
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

End Class
