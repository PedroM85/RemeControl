Public Class StatusData
    Private iSTA_Id As Integer
    Private sSTA_Name As String
    Private sSTA_ModifiedBy As String
    Private bSTA_Active As Integer

    Public Property STA_Id As Integer
        Get
            Return iSTA_Id
        End Get
        Set(value As Integer)
            iSTA_Id = value
        End Set
    End Property

    Public Property STA_Name As String
        Get
            Return sSTA_Name
        End Get
        Set(value As String)
            sSTA_Name = value
        End Set
    End Property

    Public Property STA_ModifiedBy As String
        Get
            Return sSTA_ModifiedBy
        End Get
        Set(value As String)
            sSTA_ModifiedBy = value
        End Set
    End Property

    Public Property STA_Active As Integer
        Get
            Return bSTA_Active
        End Get
        Set(value As Integer)
            bSTA_Active = value
        End Set
    End Property
End Class
Public Class StatusDataLayer


End Class
