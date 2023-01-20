Public Class LoginIn
    Private sUSR_Id As String
    Private sUSR_Name As String
    Private sUSR_Password As String
    Private sToken As String
    Private sMessage As String
    Private sUSR_IpAddress As String

    Public Sub New()

    End Sub

    Public Property USR_Id As String
        Get
            Return sUSR_Id
        End Get
        Set(value As String)
            sUSR_Id = value
        End Set
    End Property

    Public Property USR_Name As String
        Get
            Return sUSR_Name
        End Get
        Set(value As String)
            sUSR_Name = value
        End Set
    End Property

    Public Property USR_Password As String
        Get
            Return sUSR_Password
        End Get
        Set(value As String)
            sUSR_Password = value
        End Set
    End Property

    Public Property Token As String
        Get
            Return sToken
        End Get
        Set(value As String)
            sToken = value
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

    Public Property USR_IpAddress As String
        Get
            Return sUSR_IpAddress
        End Get
        Set(value As String)
            sUSR_IpAddress = value
        End Set
    End Property
End Class
