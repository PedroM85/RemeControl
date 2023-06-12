Public Class DAHelper

    Private Shared Function CreateParameter(ByVal cmd As IDbCommand) As IDbDataParameter
        Return cmd.CreateParameter()
    End Function

    Public Shared Function CreateParameter(ByVal cmd As IDbCommand, ByVal parameterName As String, ByVal dbType As DbType) As IDbDataParameter
        Dim retPar As IDataParameter = CreateParameter(cmd)
        retPar.ParameterName = parameterName
        retPar.DbType = dbType
        Return retPar
    End Function

    Public Shared Function CreateParameter(ByVal cmd As IDbCommand, ByVal parameterName As String, ByVal dbType As DbType, ByVal size As Int32) As IDbDataParameter
        Dim retPar As IDataParameter = CreateParameter(cmd, parameterName, dbType)
        If cmd.GetType() Is GetType(OleDb.OleDbCommand) Then
            DirectCast(retPar, OleDb.OleDbParameter).Size = size
        ElseIf cmd.GetType() Is GetType(SqlClient.SqlCommand) Then
            DirectCast(retPar, SqlClient.SqlParameter).Size = size
        End If
        Return retPar
    End Function

    Public Shared Function CreateParameter(ByVal cmd As IDbCommand, ByVal ParameterName As String, ByVal value As Object) As IDbDataParameter
        Dim retPar As IDataParameter = CreateParameter(cmd)
        retPar.ParameterName = ParameterName
        retPar.Value = value
        Return retPar
    End Function

End Class
