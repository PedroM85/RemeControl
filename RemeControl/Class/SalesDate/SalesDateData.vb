Imports Newtonsoft.Json
Imports System.Security.Policy
Public Class SalesDateInfo
    Public SalesDateId As Date
    Private iSTD_Id As Integer
    Private dSTD_DateOpened As DateTime
    Private sSDT_USR_OpenedBy As String
    Private dSDT_DateCreated As DateTime
    Private dSDT_DateClosed As DateTime
    Private sSDT_USR_ClosedBy As String
    Private iUSersLoggedOn As Integer
    Private sMessage As String
    Private sSDT_ModifiedBy As String

    Public Property STD_Id As Integer
        Get
            Return iSTD_Id
        End Get
        Set(value As Integer)
            iSTD_Id = value
        End Set
    End Property

    Public Property STD_DateOpened As Date
        Get
            Return dSTD_DateOpened
        End Get
        Set(value As Date)
            dSTD_DateOpened = value
        End Set
    End Property

    Public Property SDT_USR_OpenedBy As String
        Get
            Return sSDT_USR_OpenedBy
        End Get
        Set(value As String)
            sSDT_USR_OpenedBy = value
        End Set
    End Property

    Public Property SDT_DateCreated As Date
        Get
            Return dSDT_DateCreated
        End Get
        Set(value As Date)
            dSDT_DateCreated = value
        End Set
    End Property

    Public Property SDT_DateClosed As Date
        Get
            Return dSDT_DateClosed
        End Get
        Set(value As Date)
            dSDT_DateClosed = value
        End Set
    End Property

    Public Property SDT_USR_ClosedBy As String
        Get
            Return sSDT_USR_ClosedBy
        End Get
        Set(value As String)
            sSDT_USR_ClosedBy = value
        End Set
    End Property

    Public Property SDT_ModifiedBy As String
        Get
            Return sSDT_ModifiedBy
        End Get
        Set(value As String)
            sSDT_ModifiedBy = value
        End Set
    End Property

    Public Property UsersLoggedOn As Integer
        Get
            Return iUSersLoggedOn
        End Get
        Set(value As Integer)
            iUSersLoggedOn = value
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
End Class
Public Class SalesDateData
    Inherits JsonConnect

    'Ver dia de ventas activo 
    Public Function GetGeneralInfo() As SalesDateInfo
        Dim Openning As SalesDateInfo = Nothing
        Dim url As String = ApiConstants.GetSalesDateInfo

        Openning = New SalesDateInfo

        Dim OpenningDate As New SalesDateInfo With
            {
            .SDT_DateClosed = Nothing
            }

        Dim result = JsonConvert.SerializeObject(OpenningDate)

        Dim result_post = PostJson(url, result, oApp.CurrentUser)

        Openning = JsonConvert.DeserializeObject(Of SalesDateInfo)(result_post)

        Return Openning

    End Function

    Public Function GetSessionsPerSalesDate(dDate As DateTime) As DataTable
        Dim dt As New DataTable
        Dim Openning As SalesDateInfo = Nothing
        Dim url As String = ApiConstants.GetSessionSaleDate

        Try
            Dim OpenningDate As New SalesDateInfo With
           {
           .SDT_DateClosed = dDate
           }

            Dim result = JsonConvert.SerializeObject(OpenningDate)

            Dim result_post = PostJson(url, result, oApp.CurrentUser)

            dt = JsonConvert.DeserializeObject(Of DataTable)(result_post)


            'Return Openning
        Catch ex As Exception
            Return Nothing
        End Try

        Return dt
    End Function

    Public Function PostOpenSalesDate(Optional dDate As DateTime = Nothing) As DataTable
        Dim dt As New DataTable
        Dim Openning As SalesDateInfo = Nothing
        Dim url As String = ApiConstants.GetSessionSaleDate

        Try
            Dim OpenningDate As New SalesDateInfo With
           {
           .SDT_ModifiedBy = oApp.CurrentUser.USR_Id
           }

            Dim result = JsonConvert.SerializeObject(OpenningDate)

            Dim result_post = PostJson(url, result, oApp.CurrentUser)

            dt = JsonConvert.DeserializeObject(Of DataTable)(result_post)


            'Return Openning
        Catch ex As Exception
            Return Nothing
        End Try

        Return dt
    End Function

    Public Function postCloseSalesDate(dDate As DateTime) As DataTable
        Dim dt As New DataTable
        Dim Openning As SalesDateInfo = Nothing
        Dim url As String = ApiConstants.GetSessionSaleDate

        Try
            Dim OpenningDate As New SalesDateInfo With
           {
           .SDT_ModifiedBy = oApp.CurrentUser.USR_Id
           }

            Dim result = JsonConvert.SerializeObject(OpenningDate)

            Dim result_post = PostJson(url, result, oApp.CurrentUser)

            dt = JsonConvert.DeserializeObject(Of DataTable)(result_post)


            'Return Openning
        Catch ex As Exception
            Return Nothing
        End Try

        Return dt
    End Function

End Class
