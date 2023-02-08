Imports Newtonsoft.Json
Imports System.IO
Imports System.Text
Imports System.Net
Public Class JsonConnect

    Public Function SendRequest(ByVal url As String, ByVal dataEncoding As String,
                                         ByVal method As String, Optional oUser As LoginIn = Nothing) As String


        Dim request As HttpWebRequest
        Dim response As HttpWebResponse = Nothing
        Dim reader As StreamReader
        Dim retval As String = String.Empty

        Try
            request = DirectCast(WebRequest.Create(url), HttpWebRequest)
            request.Method = method
            request.ContentType = "application/json"
            If oUser IsNot Nothing Then
                request.Headers("Authorization") = "Bearer " & oUser.Token
            End If

            If Not String.IsNullOrEmpty(dataEncoding) Then
                If (method = WebRequestMethods.Http.Post) Or (method = WebRequestMethods.Http.Put) Then
                    Dim strPost As String = dataEncoding
                    Dim data As Byte() = Encoding.UTF8.GetBytes(strPost)
                    request.ContentLength = data.Length
                    Dim stream As Stream = request.GetRequestStream()
                    stream.Write(data, 0, data.Length)
                    stream.Close()
                End If
            End If

            response = DirectCast(request.GetResponse(), HttpWebResponse)
            reader = New StreamReader(response.GetResponseStream())
                retval = reader.ReadToEnd()
                Return retval
            Catch ex As WebException
                If ex.Response IsNot Nothing Then
                    Using myreader As New StreamReader(ex.Response.GetResponseStream)
                        Throw New Exception(ex.Message + vbCrLf + myreader.ReadToEnd + vbCrLf + url)
                        '    Dim weError As eWallet.eWalletError = eWallet.eWalletError.fromString(myreader.ReadToEnd)
                        '    Dim msg As String = ex.Message
                        '    If weError.Status <= eWallet.eWalletError.errcodeCannotInterpret Then
                        '        msg = weError.errorMsg + vbCrLf + weError.message
                        '    End If

                        '    Throw New eWallet.eWalletException(msg, ex, weError)
                    End Using
                Else
                    Throw New Exception(ex.Message)
                End If

            Finally
                If Not response Is Nothing Then response.Close()

            End Try
            Return retval

    End Function

    Sub New()
        ServicePointManager.Expect100Continue = True
        ServicePointManager.SecurityProtocol = CType(3072, SecurityProtocolType) ' Tls12
        ServicePointManager.DefaultConnectionLimit = 9999

    End Sub

    Public Function SendJson(ByVal Url As String, ByVal Method As String, ByVal obj As Object, oUser As LoginIn) As String
        Dim str As String
        If TypeOf (obj) Is String Then
            str = CType(obj, String)
        Else
            str = JsonConvert.SerializeObject(obj)
        End If
        Return SendRequest(Url, str, Method, oUser)
    End Function

    Public Function DeleteJson(ByVal Url As String, oUser As LoginIn) As String
        Return SendJson(Url, "DELETE", Nothing, oApp.CurrentUser)
    End Function

    Public Function GetJson(ByVal Url As String, oUser As LoginIn) As String
        Return SendJson(Url, WebRequestMethods.Http.Get, Nothing, oApp.CurrentUser)
    End Function

    Public Function PutJson(ByVal Url As String, ByVal obj As Object, oUser As LoginIn) As String
        Return SendJson(Url, WebRequestMethods.Http.Put, obj, oApp.CurrentUser)
    End Function

    Public Function PostJson(ByVal Url As String, ByVal obj As Object, oUser As LoginIn) As String
        Return SendJson(Url, WebRequestMethods.Http.Post, obj, oApp.CurrentUser)
    End Function


End Class
