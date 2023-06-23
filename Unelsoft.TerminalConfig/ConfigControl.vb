Imports System.Drawing.Printing

Public Class ConfigControl
    Inherits System.Windows.Forms.UserControl

    Public Sub New()
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private oDataLayer As DataLayer
    Dim bValidData As Boolean

    Dim mDataload As DataLoadMode = DataLoadMode.Default
    Public Enum DataLoadMode
        [Default]
        Minimun
    End Enum

    Public WriteOnly Property TerminalId As String
        Set(value As String)
            txtCode.Text = value
            LoadData(value)
        End Set
    End Property

    Public WriteOnly Property DataLayer As DataLayer
        Set(value As DataLayer)
            oDataLayer = value
        End Set
    End Property

    Public Property ValidData As Boolean
        Get
            Return bValidData
        End Get
        Set(value As Boolean)
            bValidData = value
        End Set
    End Property

    Public Property DataLoad() As DataLoadMode
        Get
            Return mDataload
        End Get
        Set(value As DataLoadMode)
            mDataload = value
        End Set
    End Property


    Private Sub LoadData(sTerminalId As String)
        If sTerminalId = Unelsoft.TerminalConfig.DataLayer.GetTerminalInRegistry Then
            Dim i As Integer
            cboWindowsPrinter.Items.Add(DBNull.Value)
            For i = 0 To PrinterSettings.InstalledPrinters.Count - 1
                cboWindowsPrinter.Items.Add(PrinterSettings.InstalledPrinters.Item(i))
            Next
            cboWindowsPrinter.SelectedIndex = 0
        Else
            cboWindowsPrinter.Enabled = False
        End If

        If sTerminalId <> String.Empty Then
            Dim sName As String = String.Empty
            Dim nLocationId As Integer
            Dim nStockLocation As Integer
            Dim nPOSDesignerId As Integer
            Dim sPrinter As String = String.Empty
            Dim sPrinterConnectionType As String = String.Empty
            Dim sPrinterConnectionParameters As String = String.Empty
            Dim sPOSCode As String = String.Empty
            Dim sWindowsPrinter As String = String.Empty
            Dim sFiscalPrinter As String = String.Empty
            Dim sFiscalPrinterConnectionType As String = String.Empty
            Dim sFiscalPrinterConnectionParameters As String = String.Empty

            oDataLayer.GetTerminal(sTerminalId, sName, nLocationId, sPrinter, sPrinterConnectionType, sPrinterConnectionParameters, nPOSDesignerId, sPOSCode, sFiscalPrinter, sFiscalPrinterConnectionType, sFiscalPrinterConnectionParameters, sWindowsPrinter, nStockLocation)

            txtCode.Enabled = False

            txtName.Text = sName
            txtPOSCode.Text = sPOSCode

            'cboLocation.SelectedValue = nLocationId
            'cboStockLocation.SelectedValue = nStockLocation
            'cboPOSDesign.SelectedValue = nPOSDesignerId

            If cboWindowsPrinter.Enabled Then
                cboWindowsPrinter.SelectedValue = sWindowsPrinter
            End If

            'For i = 0 To cboWindowsPrinter.Items.Count - 1
            '    If (Not cboWindowsPrinter.Items(i) Is DBNull.Value) AndAlso cboWindowsPrinter.Items(i) = sWindowsPrinter Then
            '        cboWindowsPrinter.SelectedIndex = i
            '        Exit For
            '    End If
            'Next

            'cboPrinterPOS.SelectedValue = sPrinter.Trim
            'optParallelPOS.Checked = (sPrinterConnectionType = "P")

            'If sPrinterConnectionType = "S" Then
            '    optSerialPOS.Checked = True
            '    Dim sParams() As String = sPrinterConnectionParameters.Split(",")

            '    cboSerialPortPOS.SelectedItem = sParams(0)
            '    cboBaudsPOS.SelectedItem = sParams(1)
            '    cboDataBitsPOS.SelectedItem = sParams(2)
            '    Select Case sParams(3)
            '        Case "N"
            '            cboParityPOS.SelectedItem = "None"
            '        Case "E"
            '            cboParityPOS.SelectedItem = "Even"
            '        Case "O"
            '            cboParityPOS.SelectedItem = "Odd"
            '        Case "M"
            '            cboParityPOS.SelectedItem = "Mark"
            '    End Select
            '    cboStopBitsPOS.SelectedItem = sParams(4)
            'End If

            'If sPrinterConnectionType = "P" Then
            '    optParallelPOS.Checked = True
            '    cboParallelPortPOS.SelectedItem = sPrinterConnectionParameters
            'End If


            '' Impresora fiscal [AMI130405]
            'cboPrinterFiscal.SelectedValue = sFiscalPrinter.Trim
            'optParallelFiscal.Checked = (sFiscalPrinterConnectionType = "P")

            'If sFiscalPrinterConnectionType = "S" Then
            '    optSerialFiscal.Checked = True
            '    Dim sFiscalParams() As String = sFiscalPrinterConnectionParameters.Split(",")

            '    cboSerialPort.SelectedItem = sFiscalParams(0)
            '    cboBauds.SelectedItem = sFiscalParams(1)
            '    cboDataBits.SelectedItem = sFiscalParams(2)
            '    Select Case sFiscalParams(3)
            '        Case "N"
            '            cboParity.SelectedItem = "None"
            '        Case "E"
            '            cboParity.SelectedItem = "Even"
            '        Case "O"
            '            cboParity.SelectedItem = "Odd"
            '        Case "M"
            '            cboParity.SelectedItem = "Mark"
            '    End Select
            '    cboStopBits.SelectedItem = sFiscalParams(4)
            'End If

            'If sFiscalPrinterConnectionType = "P" Then
            '    optParallelFiscal.Checked = True
            '    cboParallelPort.SelectedItem = sFiscalPrinterConnectionParameters
            'End If

            txtPOSCode.Focus()
        Else
            txtCode.Enabled = True

            txtCode.Focus()
        End If


    End Sub

    Public Sub SaveData()
        Dim sPrinterConnectionType As String
        Dim sPrinterConnectionParameters As String
        Dim sFiscalPrinterConnectionType As String
        Dim sFiscalPrinterConnectionParameters As String
        Dim sFiscalValue As String
        Dim sPOSValue As String

        'If optSerialPOS.Checked Then
        '    sPrinterConnectionType = "S"
        '    sPrinterConnectionParameters = String.Format("{0},{1},{2},{3},{4}", cboSerialPortPOS.SelectedItem, cboBaudsPOS.SelectedItem, cboDataBitsPOS.SelectedItem, cboParityPOS.SelectedItem.Chars(0), cboStopBitsPOS.SelectedItem)
        'ElseIf optParallelPOS.Checked Then
        '    sPrinterConnectionType = "P"
        '    sPrinterConnectionParameters = cboParallelPortPOS.SelectedItem
        'Else
        '    sPrinterConnectionType = ""
        '    sPrinterConnectionParameters = ""
        'End If

        ''[AMI130405] Impresora fiscal
        'If optSerialFiscal.Checked Then
        '    sFiscalPrinterConnectionType = "S"
        '    sFiscalPrinterConnectionParameters = String.Format("{0},{1},{2},{3},{4}", cboSerialPort.SelectedItem, cboBauds.SelectedItem, cboDataBits.SelectedItem, cboParity.SelectedItem.Chars(0), cboStopBits.SelectedItem)
        'ElseIf optParallelFiscal.Checked Then
        '    sFiscalPrinterConnectionType = "P"
        '    sFiscalPrinterConnectionParameters = cboParallelPort.SelectedItem
        'Else
        '    sFiscalPrinterConnectionType = ""
        '    sFiscalPrinterConnectionParameters = ""
        'End If

        'sPOSValue = IIf(dsPOSPrinters.Rows(cboPrinterPOS.SelectedIndex).Item("Code") Is DBNull.Value, "", cboPrinterPOS.SelectedValue)
        'sFiscalValue = IIf(dsFiscalPrinters.Rows(cboPrinterFiscal.SelectedIndex).Item("Code") Is DBNull.Value, "", cboPrinterFiscal.SelectedValue)

        Dim siteId As String = oDataLayer.GetSiteId
        'oDataLayer.SetTerminal(txtCode.Text, txtName.Text, cboLocation.SelectedValue, sPOSValue, sPrinterConnectionType, sPrinterConnectionParameters, cboPOSDesign.SelectedValue, txtPOSCode.Text, sFiscalValue, sFiscalPrinterConnectionType, sFiscalPrinterConnectionParameters, cboWindowsPrinter.Text, cboStockLocation.SelectedValue, siteId)
        oDataLayer.SetTerminal(txtCode.Text, txtName.Text, 0, 0, 0, 0, 0, txtPOSCode.Text, 0, 0, 0, cboWindowsPrinter.Text, 0, siteId)
        If txtCode.Enabled Then
            oDataLayer.SetTerminalInRegistry(txtCode.Text)
        End If
    End Sub
End Class
