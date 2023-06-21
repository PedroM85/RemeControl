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

End Class
