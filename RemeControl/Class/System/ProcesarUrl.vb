Imports Newtonsoft.Json
Public Class ProcesarUrl

    'Dim WebSites As String
    'Public Sub New(website As String)
    '    WebSites = website
    'End Sub
    Public Overloads Function ProcessUrl(ByVal url As String, Optional ByVal id As String = Nothing) As String
        'Return ProcessUrl(WebSites, url, id)
        'Return ProcessUrl(WebSites, url)
        Return ProcessUrl(oApp.WebSite, url, id)
    End Function

    Public Overloads Function ProcessUrl(ByVal Baseurl As String, ByVal url As String, ByVal id As String) As String
        Dim path As String = Baseurl
        If Not Baseurl.EndsWith("/") Then
            path += "/"
        End If

        If url.StartsWith("/") Then
            url = url.Substring(1)
        End If

        path += url
        'path = path.Replace("{accesstoken}", WalletConfig.APIKey)
        'path = path.Replace("{user_id}", WalletConfig.ExternalUserId)
        'If String.IsNullOrEmpty(WalletConfig.ExternalSiteName) Then
        '    path = path.Replace("{site_name}", WalletConfig.FullyQualifiedStoreId)
        'Else
        '    path = path.Replace("{site_name}", WalletConfig.ExternalSiteName)
        'End If
        'If String.IsNullOrEmpty(WalletConfig.ExternalPosId) Then
        '    path = path.Replace("{pos_id}", WalletConfig.FullyQualifiedPOSId)
        'Else
        '    path = path.Replace("{pos_id}", WalletConfig.ExternalPosId)
        'End If
        'If id IsNot Nothing Then
        '    path = path.Replace("{id}", id)
        'End If

        Return path
    End Function
End Class
