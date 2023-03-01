Imports Newtonsoft.Json
Public Class SocioData
    Private iSOC_Id As Integer
    Private sSOC_Name As String
    Private sSOC_Telefono As String
    Private sSOC_ModifiedBy As String
    Private bSOC_Active As Integer

    Public Property SOC_Id As Integer
        Get
            Return iSOC_Id
        End Get
        Set(value As Integer)
            iSOC_Id = value
        End Set
    End Property

    Public Property SOC_Name As String
        Get
            Return sSOC_Name
        End Get
        Set(value As String)
            sSOC_Name = value
        End Set
    End Property

    Public Property SOC_Telefono As String
        Get
            Return sSOC_Telefono
        End Get
        Set(value As String)
            sSOC_Telefono = value
        End Set
    End Property

    Public Property SOC_ModifiedBy As String
        Get
            Return sSOC_ModifiedBy
        End Get
        Set(value As String)
            sSOC_ModifiedBy = value
        End Set
    End Property

    Public Property SOC_Active As Integer
        Get
            Return bSOC_Active
        End Get
        Set(value As Integer)
            bSOC_Active = value
        End Set
    End Property
End Class

Public Class SocioDataLayer
    Inherits JsonConnect

    Public Function GetSocios() As DataTable
        Dim Socio As SocioData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.GetSocios)
        Dim table As DataTable
        Try
            Socio = New SocioData

            Dim result_Get = GetJson(Url, oApp.CurrentUser)


            table = JsonConvert.DeserializeObject(Of DataTable)(result_Get)
        Catch ex As Exception
            Return Nothing
        End Try

        Return table
    End Function

    Public Sub CreateSocios(Data As SocioData)
        Dim Socio As SocioData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.CreateSocio)
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PostJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of SocioData)(result_Post)

            Socio = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub UpdateSocios(Data As SocioData)
        Dim Socio As SocioData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.UpdateSocio)
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of SocioData)(result_Post)

            Socio = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub DeleteSocios(Data As SocioData)
        Dim Socio As SocioData = Nothing
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.DeleteSocio)
        Try
            Dim result = JsonConvert.SerializeObject(Data)

            Dim result_Post = PutJson(Url, result, oApp.CurrentUser)

            Dim coso = JsonConvert.DeserializeObject(Of SocioData)(result_Post)

            Socio = coso
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Sub
End Class
