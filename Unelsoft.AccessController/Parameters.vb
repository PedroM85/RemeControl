<CLSCompliant(True)>
Public Class Parameters
    Inherits Hashtable

#Region " Instance variables "

    Private oConn As IDbConnection

#End Region

#Region " Methods "

    Public Sub New(ByVal oConn As IDbConnection)
        MyBase.New()
        Me.oConn = oConn
        Refresh()
    End Sub

    Public Sub Refresh()

        If oConn.State = ConnectionState.Open Then

            Dim oCmd As IDbCommand = oConn.CreateCommand
            Dim oRd As IDataReader
            Dim sId As String
            Dim oValue As Object = Nothing

            'oParams.Clear()
            Clear()

            oCmd.CommandType = CommandType.StoredProcedure
            oCmd.CommandText = "Mgr_PAR_GetCacheableParameters"

            oRd = oCmd.ExecuteReader()
            Try
                Do While oRd.Read
                    sId = oRd.GetString(oRd.GetOrdinal("PAR_Id")).Trim
                    Select Case oRd.GetString(oRd.GetOrdinal("PAR_Type"))
                        Case "N"
                            If oRd.IsDBNull(oRd.GetOrdinal("PAR_NumericValue")) Then
                                oValue = Nothing
                            Else
                                oValue = oRd.GetDecimal(oRd.GetOrdinal("PAR_NumericValue"))
                            End If

                        Case "S"

                            If oRd.IsDBNull(oRd.GetOrdinal("PAR_StringValue")) Then
                                oValue = Nothing
                            Else
                                oValue = oRd.GetString(oRd.GetOrdinal("PAR_StringValue"))
                            End If

                        Case "D"
                            If oRd.IsDBNull(oRd.GetOrdinal("PAR_DateTimeValue")) Then
                                oValue = Nothing
                            Else
                                oValue = oRd.GetDateTime(oRd.GetOrdinal("PAR_DateTimeValue"))
                            End If

                    End Select
                    Item(sId) = oValue
                    'oParams.Item(sId) = oValue
                    Debug.WriteLine(sId + ": " + CStr(oValue))
                Loop
            Catch ex As Exception

            Finally
                oRd.Close()
            End Try

        End If

    End Sub

    Public Function GetValue(ByVal sParameterId As String) As Object
        If ContainsKey(sParameterId) Then
            'If oParams.ContainsKey(sParameterId) Then
            'Return oParams.Item(sParameterId)
            Return Item(sParameterId)
        Else
            Dim oValue As Object = RetrieveValue(sParameterId)
            If oValue Is Nothing Then
                Throw New ArgumentException(String.Format("Couldn't find '{0}' in system parameter collection", sParameterId))
            Else
                Return oValue
            End If
        End If
    End Function

    Private Function CheckColorArgument(ByVal color As String) As Integer
        Dim res As Integer
        Try
            res = CType(color, Integer)
        Catch ex As InvalidCastException
            Throw New ArgumentException
        End Try

        If res > 255 OrElse res < 0 Then
            Throw New ArgumentException
        End If

        Return res
    End Function

    Public Function GetDecimal(ByVal sParameterId As String) As Decimal
        Dim val As Object = GetValue(sParameterId)
        Try
            Dim s As Decimal = DirectCast(val, Decimal)
            'Dim nfi As New System.Globalization.NumberFormatInfo
            'nfi.NumberDecimalSeparator = ","
            'nfi.NumberGroupSeparator = "."
            'Return Decimal.Parse(s, nfi)
        Catch ex As InvalidCastException
            Throw New ArgumentException(String.Format("Parameter '{0}' couldn't be parsed as decimal.", sParameterId))
        End Try

    End Function

    Public Function GetInteger(ByVal sParameterId As String) As Integer
        Dim val As Object = GetValue(sParameterId)
        Try
            Return Convert.ToInt32(val)
        Catch ex As InvalidCastException
            Throw New ArgumentException(String.Format("Parameter '{0}' couldn't be parsed as integer.", sParameterId))
        End Try
    End Function

    Public Function GetBooleanWithDefault(ByVal sParameterId As String, DefaultValue As Boolean) As Boolean
        Try
            Return GetBoolean(sParameterId)
        Catch ex As Exception
            Return DefaultValue
        End Try
    End Function

    Public Function GetBoolean(ByVal sParameterId As String) As Boolean
        Dim val As Object = GetValue(sParameterId)
        Dim strVal As String = CType(val, String)
        strVal = strVal.ToUpper()
        If "SYN".IndexOf(strVal) >= 0 Then
            If strVal = "S" Or strVal = "Y" Then
                Return True
            Else
                Return False
            End If
        Else
            Try
                Dim b As Int32
                b = Convert.ToInt32(val)

                If b = 0 Then
                    Return False
                ElseIf b = 1 Then
                    Return True
                Else
                    Throw New Exception
                End If
            Catch ex As Exception
                Throw New ArgumentException(String.Format("Parameter '{0}' couldn't be parsed as boolean. Must be 0 or 1.", sParameterId))
            End Try
        End If
    End Function

    Public Overloads Function GetString(ByVal sParameterId As String) As String
        Dim val As Object = GetValue(sParameterId)
        Try
            Return DirectCast(val, String)
        Catch ex As Exception
            Throw New ArgumentException(String.Format("Parameter '{0}' couldn't be parsed as string.", sParameterId))
        End Try
    End Function

    Public Overloads Function GetString(ByVal sParameterId As String, ByVal DefaultStr As String) As String
        Try
            Return GetString(sParameterId)
        Catch
            Return DefaultStr
        End Try

    End Function

    Public Function GetDate(ByVal sParameterId As String) As Date
        Dim val As Object = GetValue(sParameterId)
        Try
            Return DirectCast(val, Date)
        Catch ex As Exception
            Throw New ArgumentException(String.Format("Parameter '{0}' couldn't be parsed as date.", sParameterId))
        End Try
    End Function

    Private Function RetrieveValue(ByVal sParameterId As String) As Object
        Dim oValue As Object = Nothing

        If oConn.State = ConnectionState.Open Then
            Dim oCmd As IDbCommand = oConn.CreateCommand
            Dim oRd As IDataReader
            Dim oPrm As IDataParameter

            oCmd.CommandType = CommandType.StoredProcedure
            oCmd.CommandText = "Mgr_PAR_GetParameter"

            oPrm = DAHelper.CreateParameter(oCmd, "ParameterId", DbType.StringFixedLength, 10)
            oPrm.Value = sParameterId
            oCmd.Parameters.Add(oPrm)

            oRd = oCmd.ExecuteReader()

            Do While oRd.Read
                Select Case oRd.GetString(oRd.GetOrdinal("PAR_Type"))
                    Case "N"
                        oValue = oRd.GetDecimal(oRd.GetOrdinal("PAR_NumericValue"))
                    Case "S"
                        '15-1-08 - Si el string esta null devuelvo un Empty para evitar errores por Nothing
                        If oRd.IsDBNull(oRd.GetOrdinal("PAR_StringValue")) Then
                            oValue = String.Empty
                        Else
                            oValue = oRd.GetString(oRd.GetOrdinal("PAR_StringValue"))
                        End If
                    Case "D"
                        oValue = oRd.GetDateTime(oRd.GetOrdinal("PAR_DateTimeValue"))
                End Select
            Loop

            oRd.Close()
        End If

        Return oValue
    End Function

    Public Function ToHashTable() As Hashtable
        Return Me
    End Function

#End Region



End Class
