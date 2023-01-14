Imports Newtonsoft.Json
Imports System.Security.Policy

Public Class SalesDateData
    Inherits JsonConnect

    Public Function GetGeneralInfo() As SalesDateInfo
        Dim Openning As SalesDateInfo = Nothing
        Dim url As String = ApiConstants.SalesDateInfo

        Openning = New SalesDateInfo

        Dim OpenningDate As New SalesDateInfo With
            {
            .SDT_DateClosed = Nothing,
            .SDT_SIT_Id = oApp.Terminal
            }

        Dim result = JsonConvert.SerializeObject(OpenningDate)

        Dim result_post = PostJson(url, result, oApp.CurrentUser)

        Openning = JsonConvert.DeserializeObject(Of SalesDateInfo)(result_post)

        Return Openning

    End Function

End Class
