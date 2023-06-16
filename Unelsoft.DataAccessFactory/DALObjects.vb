Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class DALObjects

    Public Enum DataProviderType
        SqlClient = 0
        OleDb = 1
    End Enum

    Private Shared nProviderType As DataProviderType

    Public Shared Function GetParameterName(ByVal ParameterName As String) As String
        If nProviderType = DataProviderType.SqlClient Then
            Return "@" & ParameterName
        Else
            Return ParameterName
        End If
    End Function

    Public Shared Function CreateParameter(ByVal ParameterName As String, ByVal DbType As DbType) As IDataParameter
        Dim oPrm As IDataParameter = GetParameter()

        With oPrm
            .ParameterName = IIf(nProviderType = DataProviderType.SqlClient, "@", "") & ParameterName
            .DbType = DbType
        End With

        Return oPrm
    End Function

    Public Shared Function CreateParameter(ByVal ParameterName As String, ByVal DbType As DbType, ByVal Precision As Integer, ByVal Scale As Integer) As IDataParameter
        Dim oPrm As IDataParameter = GetParameter()
        Dim sPrefix As String = String.Empty

        With oPrm
            If nProviderType = DataProviderType.SqlClient Then
                CType(oPrm, SqlParameter).Precision = Precision
                CType(oPrm, SqlParameter).Scale = Scale
                sPrefix = "@"
            Else
                CType(oPrm, OleDbParameter).Precision = Precision
                CType(oPrm, OleDbParameter).Scale = Scale
            End If

            .ParameterName = sPrefix & ParameterName
            .DbType = DbType

        End With

        Return oPrm
    End Function

    Public Shared Function CreateParameter(ByVal ParameterName As String, ByVal DbType As DbType, ByVal size As Integer) As IDataParameter
        Dim oPrm As IDataParameter = GetParameter()
        Dim sPrefix As String = String.Empty

        With oPrm
            If nProviderType = DataProviderType.SqlClient Then
                CType(oPrm, SqlParameter).Size = size
                sPrefix = "@"
            Else
                CType(oPrm, OleDbParameter).Size = size
            End If

            .ParameterName = sPrefix & ParameterName
            .DbType = DbType
        End With

        Return oPrm
    End Function

    Public Shared Function CreateParameter(ByVal ParameterName As String, ByVal DbType As DbType, ByVal size As Integer, ByVal sourcecolumn As String) As IDataParameter
        Dim oPrm As IDataParameter = GetParameter()
        Dim sPrefix As String = String.Empty

        With oPrm
            If nProviderType = DataProviderType.SqlClient Then
                sPrefix = "@"
                CType(oPrm, SqlParameter).Size = size
            Else
                CType(oPrm, OleDbParameter).Size = size
            End If

            .ParameterName = sPrefix & ParameterName
            .DbType = DbType
            .SourceColumn = sourcecolumn
        End With

        Return oPrm
    End Function

    Public Shared Function CreateParameter(ByVal ParameterName As String, ByVal value As Object) As IDataParameter
        Dim oPrm As IDataParameter = GetParameter()

        With oPrm
            .ParameterName = IIf(nProviderType = DataProviderType.SqlClient, "@", "") & ParameterName
            .Value = value
        End With

        Return oPrm
    End Function

    Public Shared WriteOnly Property ProviderType() As DataProviderType
        Set(ByVal Value As DataProviderType)
            nProviderType = Value
        End Set
    End Property

    Public Shared Function GetConnectionStringFormat(Optional ByVal AppName As String = Nothing) As String

        If AppName Is Nothing Then
            AppName = "Ewave"
        End If
        If nProviderType = DataProviderType.SqlClient Then
            Return "user id={2};password={3};initial catalog={1};data source={0};Connect Timeout=30;Application Name=" + AppName.TrimEnd
        Else
            'Return "Provider=SQLOLEDB.1;Password={3};Persist Security Info=True;User ID={2};Initial Catalog={1};Data Source={0};Application Name=" + AppName.TrimEnd
            Return "Provider={4}; Server={0};Database={1};UID={2};PWD={3}"
        End If
    End Function

    Public Shared Function GetConnection() As IDbConnection
        If nProviderType = DataProviderType.SqlClient Then
            Return New SqlClient.SqlConnection
        Else
            Return New OleDb.OleDbConnection
        End If
    End Function

    Public Shared Function GetCommand() As IDbCommand
        If nProviderType = DataProviderType.SqlClient Then
            Return New SqlClient.SqlCommand
        Else
            Return New OleDb.OleDbCommand
        End If
    End Function

    Public Shared Function GetDataAdapter() As IDbDataAdapter
        If nProviderType = DataProviderType.SqlClient Then
            Return New SqlClient.SqlDataAdapter
        Else
            Return New OleDb.OleDbDataAdapter
        End If
    End Function

    Public Shared Function GetDataAdapter(ByVal selectCommand As IDbCommand) As IDbDataAdapter
        If nProviderType = DataProviderType.SqlClient Then
            Return New SqlClient.SqlDataAdapter(selectCommand)
        Else
            Return New OleDb.OleDbDataAdapter(selectCommand)
        End If
    End Function

    Public Shared Function GetParameter() As IDataParameter
        If nProviderType = DataProviderType.SqlClient Then
            Return New SqlClient.SqlParameter
        Else
            Return New OleDb.OleDbParameter
        End If
    End Function

End Class
