Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports System.Security.Policy

Public Class MiClaseTest
    Private _dSDT_DateClosed As DateTime?

    Public Property SDT_DateClosed As DateTime?
        Get
            Return _dSDT_DateClosed
        End Get
        Set(value As DateTime?)
            _dSDT_DateClosed = value
        End Set
    End Property
End Class
Public Class SalesDateInfo
    Public SDT_Id As DateTime
    Public SDT_DateOpened As DateTime
    Public SDT_Fecha As DateTime
    Public SSS_Id As Integer?

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

    Public Enum IsOpen
        Abierto
        Cerrado
        Desfase
    End Enum


    Public Sub PostGeneralInfo(ByRef dOpenedSalesDate As DateTime, ByRef dOpeningDate As DateTime, ByRef nUsersLoggedOn As Integer, ByRef nSessionId As Int32)
        'Ver dia de ventas activo 
        Dim dt As New DataTable

        Dim _SalesDate As New SalesDateInfo
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.PostSalesDateInfo)
        nSessionId = 0

        Try

            Dim Datos = New With {
            .Fecha = DateTime.Now
            }

            Dim result = JsonConvert.SerializeObject(Datos)

            Dim result_post = PostJson(url, result, oApp.CurrentUser)
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
                If objSalesDateList(0).SSS_Id Is Nothing Then
                    nSessionId = -1
                Else
                    nSessionId = objSalesDateList(0).SSS_Id
                End If
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
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.PostSessionPerSaleDate)

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
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.PostOpenSalesDate)

        Try
            Dim OpenningDate As New SalesDateInfo With
           {
           .SDT_ModifiedBy = oApp.CurrentUser.USR_Id,
           .SDT_Fecha = DateTime.Now
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
        Dim url As String = oApp.Url.ProcessUrl(ApiConstants.CreateCloseSalesDate)
        MessageBox.Show("Verifica antes de terminar el primer cierra para debug error")
        Try
            Dim OpenningDate As New SalesDateInfo With
           {
           .SDT_ModifiedBy = oApp.CurrentUser.USR_Id,
           .SDT_Fecha = DateTime.Now
           }

            Dim result = JsonConvert.SerializeObject(OpenningDate)

            Dim result_post = PostJson(url, result, oApp.CurrentUser)

            Dim objSalesDateList = JsonConvert.DeserializeObject(Of List(Of SalesDateInfo))(result_post)

            'dt = JsonConvert.DeserializeObject(Of DataTable)(result_post)
            'Dim dta As Object = JsonConvert.DeserializeObject(result_post)


            'Return Openning
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try


    End Sub

    Public Sub PostCloseSession(nSessionId As Integer)

        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.PostCloseSession)

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
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.PostSessionInfo)

        Try
            Dim Openning As New SalesDateInfo With
                {
                .SSS_Id = nSessionId
                }

            Dim result = JsonConvert.SerializeObject(Openning)

            Dim result_post = PostJson(Url, result, oApp.CurrentUser)

            Dim objSalesDateList = JsonConvert.DeserializeObject(Of List(Of SalesDateInfo))(result_post)

            'Usa esto de ejemplo para fix este error

            'MessageBox.Show(objSalesDateList.ToString)
            'If objSalesDateList(0).Message = "No hay dia aperturado" Then
            '    dOpenedSalesDate = New Date(9999, 12, 31)
            '    dOpeningDate = dOpenedSalesDate
            '    nUsersLoggedOn = 0
            'Else
            '    dOpenedSalesDate = objSalesDateList(0).SDT_Id 'dt.Rows.Item(0).ItemArray(0)
            '    dOpeningDate = objSalesDateList(0).SDT_DateOpened 'dt.Rows.Item(0).ItemArray(1)
            '    nUsersLoggedOn = objSalesDateList(0).USersLoggedOn 'dt.Rows.Item(0).ItemArray(2)
            'End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub

    Public Sub PostReOpenSession(nSessionId As Integer)
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.PostSessionInfo)

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

    Public Function PostSessionPaymentType(nSessionId As Integer) As DataTable
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.PostSessionPaymentType)
        Dim dt As New DataTable
        Try
            Dim Openning As New SalesDateInfo With
                {
                .SSS_Id = nSessionId
                }

            Dim result = JsonConvert.SerializeObject(Openning)

            Dim result_post = PostJson(Url, result, oApp.CurrentUser)


            'dt = JsonConvert.DeserializeObject(Of DataTable)(result_post)
            Dim respuesta As Object = JsonConvert.DeserializeObject(result_post)



        Catch ex As Exception
            dt = Nothing
            Throw New Exception(ex.Message)
        End Try
        Return dt
    End Function

    Public Function IsOpenning() As IsOpen
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.GetIsOpenning)
        Dim ValueDate As New DateTime(1999, 12, 31, 0, 0, 0, 0)
        Dim Hoy As Date = Date.Now.ToString("yyyy-MM-dd")
        Try
            Dim result_get = GetJson(Url, oApp.CurrentUser)

            Dim varObj As MiClaseTest = JsonConvert.DeserializeObject(Of MiClaseTest)(result_get)

            'MessageBox.Show(varObj.SDT_DateClosed.ToString)
            If varObj.SDT_DateClosed Is Nothing Then
                Return IsOpen.Abierto
            ElseIf varObj.SDT_DateClosed = Hoy Then
                Return IsOpen.Desfase
            Else
                Return IsOpen.Cerrado
            End If

        Catch ex As Exception
            'No hay salesDate aperturados
            Return False
        End Try

    End Function

    Public Sub PostCounter()
        Dim Url As String = oApp.Url.ProcessUrl(ApiConstants.PostCounter)
        Try
            Dim Datos = New With {
                .Fecha = DateTime.Now
            }

            Dim result = JsonConvert.SerializeObject(Datos)

            Dim result_Post = PostJson(Url, result, oApp.CurrentUser)

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
End Class
