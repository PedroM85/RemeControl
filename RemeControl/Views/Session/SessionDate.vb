Imports System.Windows.Forms.AxHost

Public Class SessionDate
    Inherits UserControl

    Private dCurrSalesDate As New Date(9999, 12, 31)

#Region "InitializeComponent"

    Friend WithEvents lblCaption As Label
    Friend WithEvents lblOpeningDateValue As Label
    Friend WithEvents lblCurrSalesDateValue As Label
    Friend WithEvents lblUsersValue As Label
    Friend WithEvents lblSessionsValue As Label
    Friend WithEvents lblUsers As Label
    Friend WithEvents lblSessions As Label
    Friend WithEvents lblCurrSalesDate As Label
    Friend WithEvents pnlRestoreSales As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents pnlCloseOpenSales As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents pnlOpenSales As Panel
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents pnlCloseSales As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label

    Private Sub InitializeComponent()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.lblOpeningDateValue = New System.Windows.Forms.Label()
        Me.lblCurrSalesDateValue = New System.Windows.Forms.Label()
        Me.lblUsersValue = New System.Windows.Forms.Label()
        Me.lblSessionsValue = New System.Windows.Forms.Label()
        Me.lblUsers = New System.Windows.Forms.Label()
        Me.lblSessions = New System.Windows.Forms.Label()
        Me.lblCurrSalesDate = New System.Windows.Forms.Label()
        Me.pnlRestoreSales = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.pnlCloseOpenSales = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlOpenSales = New System.Windows.Forms.Panel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlCloseSales = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlRestoreSales.SuspendLayout()
        Me.pnlCloseOpenSales.SuspendLayout()
        Me.pnlOpenSales.SuspendLayout()
        Me.pnlCloseSales.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCaption
        '
        Me.lblCaption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.lblCaption.Location = New System.Drawing.Point(61, 28)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(608, 24)
        Me.lblCaption.TabIndex = 27
        Me.lblCaption.Text = "Administración de días de venta"
        '
        'lblOpeningDateValue
        '
        Me.lblOpeningDateValue.Location = New System.Drawing.Point(389, 60)
        Me.lblOpeningDateValue.Name = "lblOpeningDateValue"
        Me.lblOpeningDateValue.Size = New System.Drawing.Size(280, 24)
        Me.lblOpeningDateValue.TabIndex = 26
        Me.lblOpeningDateValue.Text = "(abierto el ??? a las ???)"
        Me.lblOpeningDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCurrSalesDateValue
        '
        Me.lblCurrSalesDateValue.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrSalesDateValue.Location = New System.Drawing.Point(245, 60)
        Me.lblCurrSalesDateValue.Name = "lblCurrSalesDateValue"
        Me.lblCurrSalesDateValue.Size = New System.Drawing.Size(144, 24)
        Me.lblCurrSalesDateValue.TabIndex = 25
        Me.lblCurrSalesDateValue.Text = "???"
        Me.lblCurrSalesDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsersValue
        '
        Me.lblUsersValue.Location = New System.Drawing.Point(245, 116)
        Me.lblUsersValue.Name = "lblUsersValue"
        Me.lblUsersValue.Size = New System.Drawing.Size(64, 19)
        Me.lblUsersValue.TabIndex = 24
        Me.lblUsersValue.Text = "???"
        Me.lblUsersValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSessionsValue
        '
        Me.lblSessionsValue.Location = New System.Drawing.Point(245, 92)
        Me.lblSessionsValue.Name = "lblSessionsValue"
        Me.lblSessionsValue.Size = New System.Drawing.Size(424, 19)
        Me.lblSessionsValue.TabIndex = 23
        Me.lblSessionsValue.Text = "???"
        Me.lblSessionsValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUsers
        '
        Me.lblUsers.Location = New System.Drawing.Point(69, 116)
        Me.lblUsers.Name = "lblUsers"
        Me.lblUsers.Size = New System.Drawing.Size(168, 19)
        Me.lblUsers.TabIndex = 22
        Me.lblUsers.Text = "Usuarios en el sistema:"
        Me.lblUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSessions
        '
        Me.lblSessions.Location = New System.Drawing.Point(69, 92)
        Me.lblSessions.Name = "lblSessions"
        Me.lblSessions.Size = New System.Drawing.Size(168, 19)
        Me.lblSessions.TabIndex = 21
        Me.lblSessions.Text = "Turnos abiertos:"
        Me.lblSessions.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCurrSalesDate
        '
        Me.lblCurrSalesDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrSalesDate.Location = New System.Drawing.Point(69, 60)
        Me.lblCurrSalesDate.Name = "lblCurrSalesDate"
        Me.lblCurrSalesDate.Size = New System.Drawing.Size(168, 24)
        Me.lblCurrSalesDate.TabIndex = 20
        Me.lblCurrSalesDate.Text = "Día de ventas abierto:"
        Me.lblCurrSalesDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlRestoreSales
        '
        Me.pnlRestoreSales.Controls.Add(Me.Label7)
        Me.pnlRestoreSales.Controls.Add(Me.Label8)
        Me.pnlRestoreSales.Location = New System.Drawing.Point(139, 329)
        Me.pnlRestoreSales.Name = "pnlRestoreSales"
        Me.pnlRestoreSales.Size = New System.Drawing.Size(446, 46)
        Me.pnlRestoreSales.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(56, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(250, 13)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Elimina los días de ventas futuros abiertos por error."
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(56, 4)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(247, 16)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Restaurar estado de día de ventas"
        '
        'pnlCloseOpenSales
        '
        Me.pnlCloseOpenSales.Controls.Add(Me.Label5)
        Me.pnlCloseOpenSales.Controls.Add(Me.Label6)
        Me.pnlCloseOpenSales.Location = New System.Drawing.Point(139, 277)
        Me.pnlCloseOpenSales.Name = "pnlCloseOpenSales"
        Me.pnlCloseOpenSales.Size = New System.Drawing.Size(446, 46)
        Me.pnlCloseOpenSales.TabIndex = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(56, 24)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(224, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Ejecuta ambos procesos en forma secuencial."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(56, 4)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(317, 16)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Cerrar día de ventas actual y abrir uno nuevo"
        '
        'pnlOpenSales
        '
        Me.pnlOpenSales.Controls.Add(Me.Label3)
        Me.pnlOpenSales.Controls.Add(Me.Label4)
        Me.pnlOpenSales.Location = New System.Drawing.Point(139, 225)
        Me.pnlOpenSales.Name = "pnlOpenSales"
        Me.pnlOpenSales.Size = New System.Drawing.Size(446, 46)
        Me.pnlOpenSales.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(56, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Abre un nuevo dia de ventas."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(56, 4)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(204, 16)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Abrir un nuevo día de ventas"
        '
        'pnlCloseSales
        '
        Me.pnlCloseSales.Controls.Add(Me.Label2)
        Me.pnlCloseSales.Controls.Add(Me.Label1)
        Me.pnlCloseSales.Location = New System.Drawing.Point(139, 173)
        Me.pnlCloseSales.Name = "pnlCloseSales"
        Me.pnlCloseSales.Size = New System.Drawing.Size(446, 46)
        Me.pnlCloseSales.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(56, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(362, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ejecuta el cierre del dia de ventas actual junto con los procesos asociados."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(56, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(194, 16)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Cerrar dia de ventas actual"
        '
        'SessionDate
        '
        Me.AutoSize = True
        Me.Controls.Add(Me.pnlRestoreSales)
        Me.Controls.Add(Me.pnlCloseOpenSales)
        Me.Controls.Add(Me.pnlOpenSales)
        Me.Controls.Add(Me.pnlCloseSales)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.lblOpeningDateValue)
        Me.Controls.Add(Me.lblCurrSalesDateValue)
        Me.Controls.Add(Me.lblUsersValue)
        Me.Controls.Add(Me.lblSessionsValue)
        Me.Controls.Add(Me.lblUsers)
        Me.Controls.Add(Me.lblSessions)
        Me.Controls.Add(Me.lblCurrSalesDate)
        Me.Name = "SessionDate"
        Me.Size = New System.Drawing.Size(731, 434)
        Me.pnlRestoreSales.ResumeLayout(False)
        Me.pnlRestoreSales.PerformLayout()
        Me.pnlCloseOpenSales.ResumeLayout(False)
        Me.pnlCloseOpenSales.PerformLayout()
        Me.pnlOpenSales.ResumeLayout(False)
        Me.pnlOpenSales.PerformLayout()
        Me.pnlCloseSales.ResumeLayout(False)
        Me.pnlCloseSales.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New()
        MyBase.New


        InitializeComponent()

    End Sub

    Private Sub pnlCloseSales_Click(sender As Object, e As EventArgs) Handles pnlCloseSales.Click, Label1.Click, Label2.Click
        pnlCloseSales.Focus()
    End Sub

    Private Sub pnlOpenSales_Click(sender As Object, e As EventArgs) Handles pnlOpenSales.Click, Label3.Click, Label4.Click
        pnlOpenSales.Focus()
    End Sub

    Private Sub pnlCloseOpenSales_Click(sender As Object, e As EventArgs) Handles pnlCloseOpenSales.Click, Label5.Click, Label6.Click
        pnlCloseOpenSales.Focus()
    End Sub

    Private Sub pnlRestoreSales_Click(sender As Object, e As EventArgs) Handles pnlRestoreSales.Click, Label7.Click, Label8.Click
        pnlRestoreSales.Focus()
    End Sub
    Private Sub pnlCloseSales_DoubleClick(sender As Object, e As EventArgs) Handles pnlCloseSales.DoubleClick, Label1.DoubleClick, Label2.DoubleClick
        If MessageBox.Show(Me, Msg_CloseSalesDate, "Unelsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            'UpdateSummaries()s

            Try
                Dim oDataLayer As New SalesDateData
                Dim sSalesDate As String = lblCurrSalesDateValue.Text
                'Dim oSumMgr As 

                'GenerateAllSalesMovements()

                ExecuteCounter()

                'Me esta generando un error al cerrar el dia de venta. Verificar
                oDataLayer.postCloseSalesDate(dCurrSalesDate)
                'oDataLayer.DeleteOffLineTransactions()
                'oApp.AuditLogWriter.AddEntry(AccessController.AuditLogWriter.EventType.DayClosed, oApp.CurrentUser.Id, oApp.TerminalId, sSalesDate)
            Catch oEx As Exception
                MessageBox.Show(Me, oEx.Message, "Unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                UpdateData()

            End Try
        End If
    End Sub

    Private Sub ExecuteCounter()
        Dim WF As New WaitForm
        Dim oDataLayer As New SalesDateData

        Try

            With WF
                .Message = "Actualizando contadores" + vbCrLf + "Un momento por favor..."
                .show()
                .ShowAnimation()
                .Refresh()
            End With

            Me.Enabled = False

            oDataLayer.GetCounter()
            WF.Hide()
        Catch ex As Exception
            MessageBox.Show(Me, ex.Message, "Unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Me.Enabled = True
            WF.Hide()
            WF.Dispose()
        End Try
    End Sub

    Private Sub pnlOpenSales_DoubleClick(sender As Object, e As EventArgs) Handles pnlOpenSales.DoubleClick, Label3.DoubleClick, Label4.DoubleClick
        Dim bError As Boolean = False

        If MessageBox.Show(Me, MSg_OpenSalesDate, "Unelsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
            Try
                Dim oDataLayer As New SalesDateData
                oDataLayer.PostOpenSalesDate()
            Catch oEx As Exception
                bError = True

                MessageBox.Show(Me, oEx.Message, "Unelsoft", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                UpdateData()
                If Not bError Then
                    'Escribe en el log
                End If
                oMainForm.SalesDateInfo = oApp.GetSalesDateInfo
            End Try
        End If
    End Sub

    Public Sub UpdateData()
        Dim oDataLayer As New SalesDateData
        Dim dOpeningDate As DateTime
        'Dim nBOCSessions, nCOMSessions As Integer
        Dim nUsers As Integer
        Dim nSessionId As Integer

        'oSalesDataLayer.GetGeneralInfo(dCurrSalesDate, dOpeningDate, nBOCSessions, nCOMSessions, nUsers)
        oDataLayer.GetGeneralInfo(dCurrSalesDate, dOpeningDate, nUsers, nSessionId)

        If dCurrSalesDate = New Date(9999, 12, 31) Then
            lblCurrSalesDateValue.Text = Msg_lblCurrSalesDateValue
            lblOpeningDateValue.Text = ""
        Else
            lblCurrSalesDateValue.Text = dCurrSalesDate.ToShortDateString
            lblOpeningDateValue.Text = Msg_lblCurrSalesDateValue2 & " " & dOpeningDate
        End If

        lblSessionsValue.Text = String.Format("{0} ", "Remesa")
        lblUsersValue.Text = nUsers
    End Sub

    Dim MSg_OpenSalesDate As String = "¿Esta seguro que desea abrir un nuevo día de ventas?"
    Dim Msg_CloseSalesDate As String = "¿Está seguro que desea cerrar el día de ventas actualmente abierto?"
    Dim Msg_CloseOpenSalesDate1 As String = "¿Está seguro que desea cerrar el día de ventas actualmente abierto"
    Dim Msg_CloseOpenSalesDate2 As String = "y abrir uno nuevo?"
    Dim Msg_lblCurrSalesDateValue As String = "Ninguno"
    Dim Msg_lblCurrSalesDateValue2 As String = "abierto el"
    Dim Msg_fldRestoreSalesDate As String = "¿Está seguro que desea restaurar hasta el día de ventas actual?"
    Dim lblSessionsValue1 As String = "en POS y"
    Dim lblSessionsValue2 As String = "en otro"

    Private Sub SessionDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        UpdateData()
    End Sub


End Class
