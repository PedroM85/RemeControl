Public Class SalesDateDataLayer
    Dim _cnx As OleDb.OleDbConnection

    Public Sub New()
        Me.New(EnvironmentObjects.Connection)
    End Sub
    Public Sub New(cnx As OleDb.OleDbConnection)
        _cnx = cnx
    End Sub

    Public Function IsSalesDateOpened(dDate As DateTime) As Boolean
        Dim oCmd As OleDb.OleDbCommand = _cnx.CreateCommand
        Dim prm As OleDb.OleDbParameter

        oCmd.CommandType = CommandType.StoredProcedure
        oCmd.CommandText = "SDT_IsSalesDateOpened"
        oCmd.Parameters.Add("Date", Data.OleDb.OleDbType.Date).Value = dDate
        prm = oCmd.Parameters.Add("Opened", Data.OleDb.OleDbType.Boolean)
        prm.Direction = ParameterDirection.Output
        oCmd.Parameters.Add("SiteId", Data.OleDb.OleDbType.Char, 10).Value = EnvironmentObjects.SiteId

        oCmd.ExecuteNonQuery()

        Return prm.Value
    End Function

    Public Sub GetGeneralInfo(ByRef dOpenedSalesDate As DateTime, ByRef dOpeningDate As DateTime, ByRef nPosSessionOpened As Integer, nUsersLoggedOn As Integer)

        Dim oCmd As OleDb.OleDbCommand = _cnx.CreateCommand

        oCmd.CommandType = CommandType.StoredProcedure
        oCmd.CommandText = "SDT_GetGeneralInfo"
        oCmd.Parameters.Add("SaledDateId", Data.OleDb.OleDbType.Date).Direction = ParameterDirection.Output
        oCmd.Parameters.Add("OpeningDate", Data.OleDb.OleDbType.Date).Direction = ParameterDirection.Output
        oCmd.Parameters.Add("PosSessionOpened", Data.OleDb.OleDbType.Integer).Direction = ParameterDirection.Output
        oCmd.Parameters.Add("UsersLoggedOn", Data.OleDb.OleDbType.Integer).Direction = ParameterDirection.Output
        oCmd.Parameters.Add("SiteId", Data.OleDb.OleDbType.Char, 10).Value = EnvironmentObjects.SiteId
        oCmd.ExecuteNonQuery()

        If oCmd.Parameters("SalesDateId").Value Is DBNull.Value Then
            dOpenedSalesDate = New Date(9999, 12, 31)
            dOpeningDate = dOpenedSalesDate
        Else
            dOpenedSalesDate = oCmd.Parameters("SalesDateId").Value
            dOpeningDate = oCmd.Parameters("OpeningDate").Value
        End If

        nPosSessionOpened = oCmd.Parameters("PosSessionOpened").Value
        nUsersLoggedOn = oCmd.Parameters("UsersLoggedOn").Value
    End Sub
End Class
