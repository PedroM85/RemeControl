Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Security.Policy
Public Class SalesDateInfo
    Public SDT_Id As DateTime
    Public SDT_DateOpened As DateTime

    Public SSS_Id As Integer

    'Private sSDT_USR_OpenedBy As String
    'Private dSDT_DateCreated As DateTime
    Private dSDT_DateClosed As DateTime
    'Private sSDT_USR_ClosedBy As String
    Private sSDT_ModifiedBy As String


    Public SalesDateId As Date
    Public Message As String
    Public USersLoggedOn As Integer

    'Public Property SDT_Id As DateTime
    '    Get
    '        Return iSDT_Id
    '    End Get
    '    Set(value As DateTime)
    '        iSDT_Id = value
    '    End Set
    'End Property

    'Public Property SDT_DateOpened As DateTime
    '    Get
    '        Return dSDT_DateOpened
    '    End Get
    '    Set(value As DateTime)
    '        dSDT_DateOpened = value
    '    End Set
    'End Property

    'Public Property SDT_USR_OpenedBy As String
    '    Get
    '        Return sSDT_USR_OpenedBy
    '    End Get
    '    Set(value As String)
    '        sSDT_USR_OpenedBy = value
    '    End Set
    'End Property

    'Public Property SDT_DateCreated As DateTime
    '    Get
    '        Return dSDT_DateCreated
    '    End Get
    '    Set(value As DateTime)
    '        dSDT_DateCreated = value
    '    End Set
    'End Property

    Public Property SDT_DateClosed As DateTime
        Get
            Return dSDT_DateClosed
        End Get
        Set(value As DateTime)
            dSDT_DateClosed = value
        End Set
    End Property

    'Public Property SDT_USR_ClosedBy As String
    '    Get
    '        Return sSDT_USR_ClosedBy
    '    End Get
    '    Set(value As String)
    '        sSDT_USR_ClosedBy = value
    '    End Set
    'End Property

    Public Property SDT_ModifiedBy As String
        Get
            Return sSDT_ModifiedBy
        End Get
        Set(value As String)
            sSDT_ModifiedBy = value
        End Set
    End Property

    'Public Property UsersLoggedOn As Integer
    '    Get
    '        Return iUSersLoggedOn
    '    End Get
    '    Set(value As Integer)
    '        iUSersLoggedOn = value
    '    End Set
    'End Property

    'Public Property Message As String
    '    Get
    '        Return sMessage
    '    End Get
    '    Set(value As String)
    '        sMessage = value
    '    End Set
    'End Property
End Class
'Public Class SalesDateList
'    Private _SalesDateMovi As List(Of SalesDateInfo)

'    Public Property SalesDateMovi As List(Of SalesDateInfo)
'        Get
'            Return _SalesDateMovi
'        End Get
'        Set(value As List(Of SalesDateInfo))
'            _SalesDateMovi = value
'        End Set
'    End Property
'End Class
Public Class SalesDateData
    Inherits JsonConnect

    Public Sub GetGeneralInfo(ByRef dOpenedSalesDate As DateTime, ByRef dOpeningDate As DateTime, ByRef nUsersLoggedOn As Integer)
        'Ver dia de ventas activo 


        Dim dt As New DataTable

        Dim _SalesDate As New SalesDateInfo
        Dim url As String = ApiConstants.GetSalesDateInfo


        Try

            Dim result_post = GetJson(url, oApp.CurrentUser)
            'Dim tempPost = Message.
            'Dim results = JsonConvert.DeserializeAnonymousType(result_post, tempPost)

            '_SalesDate = JsonConvert.DeserializeObject(Of SalesDateInfo)(result_post)
            Dim objSalesDateList = JsonConvert.DeserializeObject(Of List(Of SalesDateInfo))(result_post)

            'MessageBox.Show(objSalesDateList.ToString)
            If objSalesDateList(0).Message = "No hay dia aperturado" Then
                dOpenedSalesDate = New Date(9999, 12, 31)
                dOpeningDate = dOpenedSalesDate
                nUsersLoggedOn = 0
            Else
                dOpenedSalesDate = objSalesDateList(0).SDT_Id 'dt.Rows.Item(0).ItemArray(0)
                dOpeningDate = objSalesDateList(0).SDT_DateOpened 'dt.Rows.Item(0).ItemArray(1)
                nUsersLoggedOn = objSalesDateList(0).USersLoggedOn 'dt.Rows.Item(0).ItemArray(2)
            End If
            'If _SalesDate.Message = "No hay dia aperturado" Then
            '   
            'Else
            '    dOpenedSalesDate = _SalesDate.SDT_Id 'dt.Rows.Item(0).ItemArray(0)
            '    dOpeningDate = _SalesDate.SDT_DateOpened 'dt.Rows.Item(0).ItemArray(1)
            '    nUsersLoggedOn = _SalesDate.USersLoggedOn 'dt.Rows.Item(0).ItemArray(2)
            'End If


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try



    End Sub

    Public Function PostSessionsPerSalesDate(dDate As DateTime) As DataTable
        Dim dt As New DataTable
        Dim Openning As SalesDateInfo = Nothing
        Dim url As String = ApiConstants.PostSessionPerSaleDate

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

    Public Sub PostOpenSalesDate()
        Dim dt As New DataTable
        ' Dim Openning As SalesDateInfo = Nothing
        Dim url As String = ApiConstants.PostOpenSalesDate

        Try
            Dim OpenningDate As New SalesDateInfo With
           {
           .SDT_ModifiedBy = oApp.CurrentUser.USR_Id
           }

            Dim result = JsonConvert.SerializeObject(OpenningDate)

            Dim result_post = PostJson(url, result, oApp.CurrentUser)

            JsonConvert.DeserializeObject(Of SalesDateInfo)(result_post)


            'Return Openning
        Catch ex As Exception

            Throw New Exception(ex.Message)
        End Try

    End Sub

    Public Sub postCloseSalesDate(dDate As DateTime)
        Dim dt As New DataTable
        'Dim Openning As SalesDateInfo = Nothing
        Dim url As String = ApiConstants.CreateCloseSalesDate

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
            Throw New Exception(ex.Message)
        End Try


    End Sub

    Public Sub PostCloseSession(nSessionId As Integer)

        Dim Url As String = ApiConstants.PostCloseSession

        Try
            Dim Openning As New SalesDateInfo With
                {
                .SDT_ModifiedBy = oApp.CurrentUser.USR_Id,
                .SSS_Id = nSessionId
                }

            Dim result = JsonConvert.SerializeObject(Openning)

            Dim result_post = PostJson(Url, result, oApp.CurrentUser)


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub PostSessionInfo(nSessionId As Integer, dCreated As DateTime, dClosed As DateTime)
        Dim Url As String = ApiConstants.PostSessionInfo

        Try
            Dim Openning As New SalesDateInfo With
                {
                .SSS_Id = nSessionId
                }

            Dim result = JsonConvert.SerializeObject(Openning)

            Dim result_post = PostJson(Url, result, oApp.CurrentUser)


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub PostReOpenSession(nSessionId As Integer)
        Dim Url As String = ApiConstants.PostSessionInfo

        Try
            Dim Openning As New SalesDateInfo With
                {
                .SSS_Id = nSessionId
                }

            Dim result = JsonConvert.SerializeObject(Openning)

            Dim result_post = PostJson(Url, result, oApp.CurrentUser)


        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

End Class
