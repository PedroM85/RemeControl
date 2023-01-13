Public Class RegisterLogin

    Private sULO_Id As String
    Private sULO_TRM As String
    Private sULO_Name As String
    Private sULO_Ip As String

    Public Property ULO_Id As String
        Get
            Return sULO_Id
        End Get
        Set(value As String)
            sULO_Id = value
        End Set
    End Property

    Public Property ULO_TRM As String
        Get
            Return sULO_TRM
        End Get
        Set(value As String)
            sULO_TRM = value
        End Set
    End Property

    Public Property ULO_Name As String
        Get
            Return sULO_Name
        End Get
        Set(value As String)
            sULO_Name = value
        End Set
    End Property

    Public Property ULO_Ip As String
        Get
            Return sULO_Ip
        End Get
        Set(value As String)
            sULO_Ip = value
        End Set
    End Property
End Class
