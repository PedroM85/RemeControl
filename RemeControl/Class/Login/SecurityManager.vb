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
                .USR_Password = Password.Trim,
                .USR_IpAddress = oApp.IpPc
                }

            Dim result = JsonConvert.SerializeObject(UserData)

            Dim result_Post = PostJson(url, result, Nothing)

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
            .ULO_Ip = oUser.USR_IpAddress
            }

        Dim result = JsonConvert.SerializeObject(UserData)

        Dim result_Post = PostJson(url, result, oUser)

    End Sub

    Public Sub RegisterLogout(oUser As LoginIn)
        Dim url As String = ApiConstants.RegisterLogout

        Dim UserData As New RegisterLogin With
            {
            .ULO_Id = oUser.USR_Id,
            .ULO_Name = oUser.USR_Name,
            .ULO_TRM = "PC",
            .ULO_Ip = oUser.USR_IpAddress
            }

        Dim result = JsonConvert.SerializeObject(UserData)

        Dim result_Post = PostJson(url, result, oUser)
    End Sub
End Class
