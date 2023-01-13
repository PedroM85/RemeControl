Imports Newtonsoft.Json

Public Class SecurityManager
    Inherits JsonConnect

    Public Function Login(Username As String, Password As String) As LoginIn
        Dim user As LoginIn = Nothing
        Dim url As String = ApiConstants.LoginIn
        If Username.Trim.ToLower = "unelca" Then

        Else

            user = New LoginIn

            Dim UserData As New LoginIn With
                {
                .USR_Id = Username.Trim,
                .USR_Password = Password.Trim
                }

            Dim result = JsonConvert.SerializeObject(UserData)

            Dim result_Post = PostJson(url, result)

            user = JsonConvert.DeserializeObject(Of LoginIn)(result_Post)

        End If

        Return user
    End Function

    Public Sub RegisterLogin(oUser As LoginIn)
        Dim url As String = ApiConstants.RegisterLogin

        Dim UserData As New RegisterLogin With
            {
            .ULO_Id = oUser.USR_Id,
            .ULO_Name = oUser.USR_Name,
            .ULO_TRM = "PC",
            .ULO_Ip = "192.168.0.1"
            }

        Dim result = JsonConvert.SerializeObject(UserData)

        Dim result_Post = PostJson(url, result)

    End Sub


End Class
