﻿
Imports Newtonsoft.Json

Public Class CambioDataLayer
    Inherits JsonConnect

    Private dataset As DataSet

    Public Sub New()
        dataset = New DataSet()
        dataset.Tables.Add("Socios")
        dataset.Tables.Add("Clientes")
        dataset.Tables.Add("Tasas")
        dataset.Tables.Add("Status")
        dataset.Tables.Add("Cambios")

        LoadData()
    End Sub

    Public Sub LoadData()
        LoadSocios()
        LoadClientes()
        LoadTasas()
        LoadStatus()
        LoadCambios()
    End Sub

    Public Function GetSocios() As DataTable
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.GetSocios)
        Return GetData(url)
    End Function

    Public Function GetClientes() As DataTable
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.GetCliente)
        Return GetData(url)
    End Function

    Public Function GetTasas() As DataTable
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.PostTasaCliente)
        Dim Datos = New With {
            .Fecha = Now.ToString("yyyy-MM-dd 00:00:00")
        }
        Dim result = JsonConvert.SerializeObject(Datos)
        Dim result_Post = PostJson(url, result, oApp.CurrentUser)
        Dim table As DataTable = JsonConvert.DeserializeObject(Of DataTable)(result_Post)
        If table IsNot Nothing Then
            dataset.Tables("Tasas").Rows.Clear()
            dataset.Tables("Tasas").Merge(table)
        End If
        Return dataset.Tables("Tasas")
    End Function

    Public Function GetStatus() As DataTable
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.GetStatus)
        Return GetData(url)
    End Function

    Public Function GetCambios() As DataTable
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.PostCambios)
        Dim Datos = New With {
            .Fecha = Now.ToString("yyyy-MM-dd HH:mm:ss")
        }
        Dim result = JsonConvert.SerializeObject(Datos)
        Dim result_Post = PostJson(url, result, oApp.CurrentUser)
        Dim table As DataTable = JsonConvert.DeserializeObject(Of DataTable)(result_Post)
        If table IsNot Nothing Then
            dataset.Tables("Cambios").Rows.Clear()
            dataset.Tables("Cambios").Merge(table)
        End If
        Return dataset.Tables("Cambios")
    End Function

    Private Sub LoadSocios()
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.GetSocios)
        Dim table As DataTable = GetData(url)
        If table IsNot Nothing Then
            dataset.Tables("Socios").Rows.Clear()
            dataset.Tables("Socios").Merge(table)
        End If
    End Sub

    Private Sub LoadClientes()
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.GetCliente)
        Dim table As DataTable = GetData(url)
        If table IsNot Nothing Then
            dataset.Tables("Clientes").Rows.Clear()
            dataset.Tables("Clientes").Merge(table)
        End If
    End Sub

    Private Sub LoadTasas()
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.PostTasaCliente)
        Dim Datos = New With {
            .Fecha = Now.ToString("yyyy-MM-dd 00:00:00")
        }
        Dim result = JsonConvert.SerializeObject(Datos)
        Dim result_Post = PostJson(url, result, oApp.CurrentUser)
        Dim table As DataTable = JsonConvert.DeserializeObject(Of DataTable)(result_Post)
        If table IsNot Nothing Then
            dataset.Tables("Tasas").Rows.Clear()
            dataset.Tables("Tasas").Merge(table)
        End If
    End Sub

    Private Sub LoadStatus()
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.GetStatus)
        Dim table As DataTable = GetData(url)
        If table IsNot Nothing Then
            dataset.Tables("Status").Rows.Clear()
            dataset.Tables("Status").Merge(table)
        End If
    End Sub

    Private Sub LoadCambios()
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.PostCambios)
        Dim Datos = New With {
            .Fecha = Now.ToString("yyyy-MM-dd HH:mm:ss")
        }
        Dim result = JsonConvert.SerializeObject(Datos)
        Dim result_Post = PostJson(url, result, oApp.CurrentUser)
        Dim table As DataTable = JsonConvert.DeserializeObject(Of DataTable)(result_Post)
        If table IsNot Nothing Then
            dataset.Tables("Cambios").Rows.Clear()
            dataset.Tables("Cambios").Merge(table)
        End If
    End Sub

    Private Function GetData(url As String) As DataTable
        Dim table As DataTable = Nothing

        Try
            Dim result_Get = GetJson(url, oApp.CurrentUser)
            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
        Catch ex As Exception
            Return Nothing
        End Try

        Return table
    End Function
    Public Sub CreateCambio(Data As CambioDataLayer)
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.CreateCambio)

        Try
            Dim result = JsonConvert.SerializeObject(Data)
            Dim result_Post = PostJson(url, result, oApp.CurrentUser)
            Dim coso = JsonConvert.DeserializeObject(Of CambioDataLayer)(result_Post)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub UpdateCambio(Data As CambioDataLayer)
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.UpdateCambio)

        Try
            Dim result = JsonConvert.SerializeObject(Data)
            Dim result_Post = PutJson(url, result, oApp.CurrentUser)
            Dim coso = JsonConvert.DeserializeObject(Of CambioDataLayer)(result_Post)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub DeleteCambio(Data As CambioDataLayer)
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.DeleteCambio)

        Try
            Dim result = JsonConvert.SerializeObject(Data)
            Dim result_Post = PutJson(url, result, oApp.CurrentUser)
            Dim coso = JsonConvert.DeserializeObject(Of CambioDataLayer)(result_Post)
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    ' Resto de métodos y funciones...
#Region "Properties"
    Public Property OP_Id As Integer
    Public Property OP_Date As Date
    Public Property OP_Socio As Integer
    Public Property OP_Cliente As Integer
    Public Property OP_Pesos As Decimal
    Public Property OP_Tasa_id As Integer
    Public Property OP_USTDBuy As Decimal
    Public Property OP_USTDSell As Decimal
    Public Property OP_Status_Id As Integer
    Public Property OP_Operation As String
    Public Property OP_ModifiedBy As String
    Public Property OP_Active As Integer
    Public Property OP_ModifiedDateTime As Date
    Public Property OP_CreatedDateTime As Date
    Public Property OP_Bank_Id As Integer
    Public Property OP_Session As Integer
#End Region
End Class


'Imports Newtonsoft.Json
'Public Class CambioData
'    Private iOP_Id As Integer
'    Private dOP_Date As DateTime
'    Private iOP_Socio As Integer
'    Private iOP_Cliente As Integer
'    Private dOP_Pesos As Decimal
'    Private dOP_Bank_Id As Integer
'    Private iOP_Tasa_id As Integer
'    Private dOP_USTDBuy As Decimal
'    Private dOP_USTDSell As Decimal
'    Private iOP_Status_Id As Integer
'    Private sOP_Operation As String
'    Private iOP_Session As Integer
'    Private sOP_ModifiedBy As String
'    Private dOP_CreatedDateTime As DateTime
'    Private dOP_ModifiedDateTime As DateTime
'    Private bOP_Active As Integer



'    Public Property OP_Id As Integer
'        Get
'            Return iOP_Id
'        End Get
'        Set(value As Integer)
'            iOP_Id = value
'        End Set
'    End Property

'    Public Property OP_Date As Date
'        Get
'            Return dOP_Date
'        End Get
'        Set(value As Date)
'            dOP_Date = value
'        End Set
'    End Property

'    Public Property OP_Socio As Integer
'        Get
'            Return iOP_Socio
'        End Get
'        Set(value As Integer)
'            iOP_Socio = value
'        End Set
'    End Property

'    Public Property OP_Cliente As Integer
'        Get
'            Return iOP_Cliente
'        End Get
'        Set(value As Integer)
'            iOP_Cliente = value
'        End Set
'    End Property

'    Public Property OP_Pesos As Decimal
'        Get
'            Return dOP_Pesos
'        End Get
'        Set(value As Decimal)
'            dOP_Pesos = value
'        End Set
'    End Property

'    Public Property OP_Tasa_id As Integer
'        Get
'            Return iOP_Tasa_id
'        End Get
'        Set(value As Integer)
'            iOP_Tasa_id = value
'        End Set
'    End Property

'    Public Property OP_USTDBuy As Decimal
'        Get
'            Return dOP_USTDBuy
'        End Get
'        Set(value As Decimal)
'            dOP_USTDBuy = value
'        End Set
'    End Property

'    Public Property OP_USTDSell As Decimal
'        Get
'            Return dOP_USTDSell
'        End Get
'        Set(value As Decimal)
'            dOP_USTDSell = value
'        End Set
'    End Property

'    Public Property OP_Status_Id As Integer
'        Get
'            Return iOP_Status_Id
'        End Get
'        Set(value As Integer)
'            iOP_Status_Id = value
'        End Set
'    End Property

'    Public Property OP_Operation As String
'        Get
'            Return sOP_Operation
'        End Get
'        Set(value As String)
'            sOP_Operation = value
'        End Set
'    End Property

'    Public Property OP_ModifiedBy As String
'        Get
'            Return sOP_ModifiedBy
'        End Get
'        Set(value As String)
'            sOP_ModifiedBy = value
'        End Set
'    End Property

'    Public Property OP_Active As Integer
'        Get
'            Return bOP_Active
'        End Get
'        Set(value As Integer)
'            bOP_Active = value
'        End Set
'    End Property

'    Public Property OP_ModifiedDateTime As Date
'        Get
'            Return dOP_ModifiedDateTime
'        End Get
'        Set(value As Date)
'            dOP_ModifiedDateTime = value
'        End Set
'    End Property

'    Public Property OP_CreatedDateTime As Date
'        Get
'            Return dOP_CreatedDateTime
'        End Get
'        Set(value As Date)
'            dOP_CreatedDateTime = value
'        End Set
'    End Property

'    Public Property OP_Bank_Id As Integer
'        Get
'            Return dOP_Bank_Id
'        End Get
'        Set(value As Integer)
'            dOP_Bank_Id = value
'        End Set
'    End Property

'    Public Property OP_Session As Integer
'        Get
'            Return iOP_Session
'        End Get
'        Set(value As Integer)
'            iOP_Session = value
'        End Set
'    End Property
'End Class
'Public Class CambioDataLayer
'    Inherits JsonConnect

'    Public Function GetSocios() As DataTable
'        Dim Socios As SocioData = Nothing
'        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.GetSocios)
'        Dim table As DataTable
'        Try
'            Socios = New SocioData

'            Dim result_Get = GetJson(Url, oApp.CurrentUser)


'            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
'        Catch ex As Exception
'            Return Nothing
'        End Try

'        Return table
'    End Function
'    Public Function GetClientes() As DataTable
'        Dim Clientes As ClienteData = Nothing
'        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.GetCliente)
'        Dim table As DataTable
'        Try
'            Clientes = New ClienteData

'            Dim result_Get = GetJson(Url, oApp.CurrentUser)


'            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
'        Catch ex As Exception
'            Return Nothing
'        End Try

'        Return table
'    End Function

'    Public Function GetTasas() As DataTable
'        Dim Tasa As New TasaData
'        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.PostTasaCliente)
'        Dim table As DataTable
'        Try

'            Dim Datos = New With {
'            .Fecha = Now.ToString("yyyy-MM-dd 00:00:00")
'            }

'            Dim result = JsonConvert.SerializeObject(Datos)

'            Dim result_Post = PostJson(Url, result, oApp.CurrentUser)


'            table = JsonConvert.DeserializeObject(Of DataTable)(result_Post)
'        Catch ex As Exception
'            Return Nothing
'        End Try

'        Return table
'    End Function
'    Public Function GetStatus() As DataTable
'        Dim Status As StatusData = Nothing
'        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.GetStatus)
'        Dim table As DataTable
'        Try
'            Status = New StatusData

'            Dim result_Get = GetJson(Url, oApp.CurrentUser)


'            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
'        Catch ex As Exception
'            Return Nothing
'        End Try

'        Return table
'    End Function
'    Public Function PostCambios() As DataTable
'        Dim Cambio As New CambioData
'        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.PostCambios)
'        Dim table As DataTable
'        Try
'            Dim Datos = New With {
'                .Fecha = Now.ToString("yyyy-MM-dd HH:mm:ss")
'            }

'            Dim result = JsonConvert.SerializeObject(Datos)

'            Dim result_Post = PostJson(Url, result, oApp.CurrentUser)


'            table = JsonConvert.DeserializeObject(Of DataTable)(result_Post)
'        Catch ex As Exception
'            Return Nothing
'        End Try

'        Return table
'    End Function

'    Public Sub CreateCambio(Data As CambioData)
'        Dim Cambio As CambioData = Nothing
'        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.CreateCambio)
'        Try
'            Dim result = JsonConvert.SerializeObject(Data)

'            Dim result_Post = PostJson(Url, result, oApp.CurrentUser)

'            Dim coso = JsonConvert.DeserializeObject(Of CambioData)(result_Post)

'            Cambio = coso
'        Catch ex As Exception
'            Throw New Exception(ex.Message)
'        End Try

'    End Sub

'    Public Sub UpdateCambio(Data As CambioData)
'        Dim Cambio As CambioData = Nothing
'        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.UpdateCambio)
'        Try
'            Dim result = JsonConvert.SerializeObject(Data)

'            Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

'            Dim coso = JsonConvert.DeserializeObject(Of CambioData)(result_Post)

'            Cambio = coso
'        Catch ex As Exception
'            Throw New Exception(ex.Message)
'        End Try

'    End Sub

'    Public Sub DeleteCambio(Data As CambioData)
'        Dim Cambio As CambioData = Nothing
'        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.DeleteCambio)
'        Try
'            Dim result = JsonConvert.SerializeObject(Data)

'            Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

'            Dim coso = JsonConvert.DeserializeObject(Of CambioData)(result_Post)

'            Cambio = coso
'        Catch ex As Exception
'            Throw New Exception(ex.Message)
'        End Try

'    End Sub

'End Class
