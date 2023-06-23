Imports Microsoft.Win32
Imports Unelsoft.DataAccessFactory

Public Class DataLayer
    Private oConn As IDbConnection

    Public Sub New(ByVal oConn As IDbConnection)

        Me.oConn = oConn

    End Sub
    Public Sub SetTerminal(ByVal sId As String, ByVal sName As String, ByVal nLocationId As Integer, ByVal sPrinter As String, ByVal sPrinterConnectionType As String, ByVal sPrinterConnectionParameters As String, ByVal nPOSDesignerId As Integer, ByVal sPOSCode As String, ByVal sFiscalPrinter As String, ByVal sFiscalPrinterConnectionType As String, ByVal sFiscalPrinterConnectionParameters As String, ByVal sWindowsPrinter As String, ByVal nStockLocation As Integer, ByVal siteId As String)

        Dim oCmd As IDbCommand = oConn.CreateCommand
        Dim oPrm As IDbDataParameter
        With oCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TRM_SetTerminal"
            oPrm = DALObjects.CreateParameter("TerminalId", DbType.AnsiStringFixedLength, 5)
            oPrm.Value = sId
            .Parameters.Add(oPrm)
            oPrm = DALObjects.CreateParameter("Name", DbType.AnsiString, 60)
            oPrm.Value = sName
            .Parameters.Add(oPrm)
            oPrm = DALObjects.CreateParameter("LocationId", DbType.Int32)
            oPrm.Value = IIf(nLocationId = -1, DBNull.Value, nLocationId)
            .Parameters.Add(oPrm)
            oPrm = DALObjects.CreateParameter("Printer", DbType.AnsiStringFixedLength, 5)
            oPrm.Value = IIf(sPrinter = "", DBNull.Value, sPrinter)
            .Parameters.Add(oPrm)
            oPrm = DALObjects.CreateParameter("PrinterConnectionType", DbType.AnsiStringFixedLength, 1)
            oPrm.Value = IIf(sPrinterConnectionType = "", DBNull.Value, sPrinterConnectionType)
            .Parameters.Add(oPrm)
            oPrm = DALObjects.CreateParameter("PrinterConnectionParameters", DbType.AnsiString, 60)
            oPrm.Value = IIf(sPrinterConnectionParameters = "", DBNull.Value, sPrinterConnectionParameters)
            .Parameters.Add(oPrm)
            oPrm = DALObjects.CreateParameter("POSDesignerId", DbType.Int32)
            oPrm.Value = IIf(nPOSDesignerId = -1, DBNull.Value, nPOSDesignerId)
            .Parameters.Add(oPrm)
            oPrm = DALObjects.CreateParameter("POSCode", DbType.AnsiStringFixedLength, 4)
            oPrm.Value = IIf(sPOSCode = "", DBNull.Value, sPOSCode)
            .Parameters.Add(oPrm)

            '[AMI130405] Impresora fiscal
            oPrm = DALObjects.CreateParameter("FiscalPrinter", DbType.AnsiString, 10)
            oPrm.Value = IIf(sFiscalPrinter = "", DBNull.Value, sFiscalPrinter)
            .Parameters.Add(oPrm)
            oPrm = DALObjects.CreateParameter("FiscalPrinterConnectionType", DbType.AnsiStringFixedLength, 1)
            oPrm.Value = IIf(sFiscalPrinterConnectionType = "", DBNull.Value, sFiscalPrinterConnectionType)
            .Parameters.Add(oPrm)

            oPrm = DALObjects.CreateParameter("FiscalPrinterConnectionParameters", DbType.AnsiString, 60)
            oPrm.Value = IIf(sFiscalPrinterConnectionParameters = "", DBNull.Value, sFiscalPrinterConnectionParameters)
            .Parameters.Add(oPrm)

            'dcofre 19/9/05 Impresora Windows default
            oPrm = DALObjects.CreateParameter("WinDriverPrinterName", DbType.AnsiString, 255)
            oPrm.Value = IIf(sWindowsPrinter = "", DBNull.Value, sWindowsPrinter)
            .Parameters.Add(oPrm)

            'pmitidieri 26/7/06 Ubicación de Stock
            oPrm = DALObjects.CreateParameter("StockLocationId", DbType.Int32)
            oPrm.Value = IIf(nStockLocation = -1, DBNull.Value, nStockLocation)
            .Parameters.Add(oPrm)

            oPrm = DALObjects.CreateParameter("SiteId", DbType.AnsiString, 10)
            oPrm.Value = siteId
            .Parameters.Add(oPrm)

            oPrm = DALObjects.CreateParameter("ModifiedBy", DbType.AnsiString, 20)
            oPrm.Value = DBNull.Value
            .Parameters.Add(oPrm)

            oPrm = DALObjects.CreateParameter("ReadOnly", DbType.Boolean)
            oPrm.Value = False
            .Parameters.Add(oPrm)

            Try
                .ExecuteNonQuery()

            Catch ex As Exception
                Throw ex
            End Try

        End With
    End Sub
    Public Sub GetTerminal(ByVal sId As String, ByRef sName As String, ByRef nLocationId As Integer, ByRef sPrinter As String, ByRef sPrinterConnectionType As String, ByRef sPrinterConnectionParameters As String, ByRef nPOSDesignerId As Integer, ByRef sPOSCode As String, ByRef sFiscalPrinter As String, ByRef sFiscalPrinterConnectionType As String, ByRef sFiscalPrinterConnectionParameters As String, ByRef sWindowsPrinter As String, ByRef nStockLocation As Integer)

        Dim oCmd As IDbCommand = oConn.CreateCommand
        Dim oRd As IDataReader
        Dim oPrm As IDataParameter

        With oCmd
            .CommandType = CommandType.StoredProcedure
            .CommandText = "TRM_GetTerminal"
            oPrm = DALObjects.CreateParameter("TerminalId", DbType.AnsiStringFixedLength, 5)
            oPrm.Value = sId
            .Parameters.Add(oPrm)
            oRd = .ExecuteReader
        End With

        If oRd.Read Then
            sName = oRd.GetString(oRd.GetOrdinal("TRM_Name"))
            If oRd.IsDBNull(oRd.GetOrdinal("TRM_LOC_Id")) Then
                nLocationId = -1
            Else
                nLocationId = oRd.GetInt32(oRd.GetOrdinal("TRM_LOC_Id"))
            End If
            If oRd.IsDBNull(oRd.GetOrdinal("TRM_LCT_Id")) Then
                nStockLocation = -1
            Else
                nStockLocation = oRd.GetInt32(oRd.GetOrdinal("TRM_LCT_Id"))
            End If
            If oRd.IsDBNull(oRd.GetOrdinal("TRM_Printer")) Then
                sPrinter = ""
            Else
                sPrinter = oRd.GetString(oRd.GetOrdinal("TRM_Printer"))
            End If
            If oRd.IsDBNull(oRd.GetOrdinal("TRM_PrinterConnectionType")) Then
                sPrinterConnectionType = ""
            Else
                sPrinterConnectionType = oRd.GetString(oRd.GetOrdinal("TRM_PrinterConnectionType"))
            End If
            If oRd.IsDBNull(oRd.GetOrdinal("TRM_PrinterConnectionParameters")) Then
                sPrinterConnectionParameters = ""
            Else
                sPrinterConnectionParameters = oRd.GetString(oRd.GetOrdinal("TRM_PrinterConnectionParameters"))
            End If
            If oRd.IsDBNull(oRd.GetOrdinal("TRM_PDS_Id")) Then
                nPOSDesignerId = -1
            Else
                nPOSDesignerId = oRd.GetInt32(oRd.GetOrdinal("TRM_PDS_Id"))
            End If
            If oRd.IsDBNull(oRd.GetOrdinal("TRM_POSCode")) Then
                sPOSCode = ""
            Else
                sPOSCode = oRd.GetString(oRd.GetOrdinal("TRM_POSCode"))
            End If

            ' Impresora fiscal [AMI130405]
            If oRd.IsDBNull(oRd.GetOrdinal("TRM_FiscalPrinter")) Then
                sFiscalPrinter = ""
            Else
                sFiscalPrinter = oRd.GetString(oRd.GetOrdinal("TRM_FiscalPrinter"))
            End If
            If oRd.IsDBNull(oRd.GetOrdinal("TRM_FiscalPrinterConnectionType")) Then
                sFiscalPrinterConnectionType = ""
            Else
                sFiscalPrinterConnectionType = oRd.GetString(oRd.GetOrdinal("TRM_FiscalPrinterConnectionType"))
            End If
            If oRd.IsDBNull(oRd.GetOrdinal("TRM_FiscalPrinterConnectionParameters")) Then
                sFiscalPrinterConnectionParameters = ""
            Else
                sFiscalPrinterConnectionParameters = oRd.GetString(oRd.GetOrdinal("TRM_FiscalPrinterConnectionParameters"))
            End If

            If oRd.IsDBNull(oRd.GetOrdinal("TRM_WinDriverPrinterName")) Then
                sWindowsPrinter = ""
            Else
                sWindowsPrinter = oRd.GetString(oRd.GetOrdinal("TRM_WinDriverPrinterName"))
            End If

        Else
            sName = ""
            nLocationId = -1
            sPrinter = ""
            sPrinterConnectionType = ""
            sPrinterConnectionParameters = ""
            nPOSDesignerId = -1
            sPOSCode = ""
            sFiscalPrinter = ""
            sFiscalPrinterConnectionType = ""
            sFiscalPrinterConnectionParameters = ""
            sWindowsPrinter = ""
            nStockLocation = -1
        End If

        oRd.Close()
        oRd = Nothing
    End Sub
    Public Sub SetTerminalInRegistry(ByVal sTerminalId As String)
        Dim oRKey As RegistryKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\unelsoft")
        oRKey.SetValue("TerminalId", sTerminalId)
        oRKey.Close()
    End Sub
    Public Shared Function GetTerminalInRegistry() As String
        Dim sTerminalId As String

        Dim oRKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\unelsoft", False)

        If oRKey Is Nothing Then
            sTerminalId = ""
        Else
            sTerminalId = oRKey.GetValue("TerminalId", "")
            oRKey.Close()
        End If

        Return sTerminalId
    End Function

    Public Function GetSiteId() As String

        Dim oCmd As IDbCommand = oConn.CreateCommand
        oCmd.CommandType = CommandType.Text
        oCmd.CommandText = "SELECT PAR_StringValue FROM SYS_Parameter WHERE PAR_Id ='SITEID'"
        Return oCmd.ExecuteScalar.ToString

    End Function
End Class
