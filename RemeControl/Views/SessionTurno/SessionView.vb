Imports System.Reflection.Emit
Imports System.Windows.Forms.AxHost

Public Class SessionView
    Inherits UserControl

    Private Shared sDays() As String = {"Lunes", "Martes", "Miércoles", "Jueves", "Viernes", "Sábado", "Domingo"}
    Private Shared sMonths() As String = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"}

    Private BaseColor As Color = Color.FromArgb(247, 247, 239)
    Private DisabledColor As Color = Color.FromArgb(239, 235, 232)
    Private dDate As DateTime
    Private oBSource As BindingSource

    Friend WithEvents lblInfo As Windows.Forms.Label
    Friend WithEvents lblDate As Windows.Forms.Label
    Friend WithEvents lblDay As Windows.Forms.Label
    Friend WithEvents lblCaption As Windows.Forms.Label



#Region "initializecomponet"

    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.btnPreviousDay = New System.Windows.Forms.Button()
        Me.btnNextDay = New System.Windows.Forms.Button()
        Me.dtpCalendar = New System.Windows.Forms.DateTimePicker()
        Me.pnlBottom = New System.Windows.Forms.Panel()
        Me.btnDetails = New System.Windows.Forms.Button()
        Me.lblInfo = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblDay = New System.Windows.Forms.Label()
        Me.lblCaption = New System.Windows.Forms.Label()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlBottom.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvView
        '
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.AllowUserToResizeColumns = False
        Me.dgvView.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        Me.dgvView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvView.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Blue
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvView.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvView.GridColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.dgvView.Location = New System.Drawing.Point(41, 70)
        Me.dgvView.MultiSelect = False
        Me.dgvView.Name = "dgvView"
        Me.dgvView.ReadOnly = True
        Me.dgvView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.dgvView.RowHeadersVisible = False
        Me.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvView.Size = New System.Drawing.Size(533, 281)
        Me.dgvView.TabIndex = 0
        '
        'btnPreviousDay
        '
        Me.btnPreviousDay.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnPreviousDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviousDay.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreviousDay.Location = New System.Drawing.Point(41, 41)
        Me.btnPreviousDay.Name = "btnPreviousDay"
        Me.btnPreviousDay.Size = New System.Drawing.Size(18, 18)
        Me.btnPreviousDay.TabIndex = 41
        Me.btnPreviousDay.Text = "-"
        Me.btnPreviousDay.UseVisualStyleBackColor = False
        '
        'btnNextDay
        '
        Me.btnNextDay.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(254, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.btnNextDay.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNextDay.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNextDay.Location = New System.Drawing.Point(401, 41)
        Me.btnNextDay.Name = "btnNextDay"
        Me.btnNextDay.Size = New System.Drawing.Size(18, 18)
        Me.btnNextDay.TabIndex = 42
        Me.btnNextDay.Text = "+"
        Me.btnNextDay.UseVisualStyleBackColor = False
        '
        'dtpCalendar
        '
        Me.dtpCalendar.CustomFormat = "dd MMM yy"
        Me.dtpCalendar.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpCalendar.Location = New System.Drawing.Point(179, 43)
        Me.dtpCalendar.Name = "dtpCalendar"
        Me.dtpCalendar.Size = New System.Drawing.Size(104, 20)
        Me.dtpCalendar.TabIndex = 46
        '
        'pnlBottom
        '
        Me.pnlBottom.BackColor = System.Drawing.SystemColors.Highlight
        Me.pnlBottom.Controls.Add(Me.btnDetails)
        Me.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlBottom.Location = New System.Drawing.Point(0, 362)
        Me.pnlBottom.Name = "pnlBottom"
        Me.pnlBottom.Size = New System.Drawing.Size(671, 50)
        Me.pnlBottom.TabIndex = 47
        '
        'btnDetails
        '
        Me.btnDetails.BackColor = System.Drawing.SystemColors.Control
        Me.btnDetails.Location = New System.Drawing.Point(41, 14)
        Me.btnDetails.Name = "btnDetails"
        Me.btnDetails.Size = New System.Drawing.Size(84, 23)
        Me.btnDetails.TabIndex = 3
        Me.btnDetails.Text = "&Ver detalles..."
        Me.btnDetails.UseVisualStyleBackColor = False
        '
        'lblInfo
        '
        Me.lblInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInfo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInfo.Location = New System.Drawing.Point(289, 41)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(104, 18)
        Me.lblInfo.TabIndex = 50
        Me.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDate
        '
        Me.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.lblDate.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(179, 41)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(104, 18)
        Me.lblDate.TabIndex = 49
        Me.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblDay
        '
        Me.lblDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDay.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDay.Location = New System.Drawing.Point(65, 41)
        Me.lblDay.Name = "lblDay"
        Me.lblDay.Size = New System.Drawing.Size(104, 18)
        Me.lblDay.TabIndex = 48
        Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCaption
        '
        Me.lblCaption.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.ForeColor = System.Drawing.Color.FromArgb(CType(CType(55, Byte), Integer), CType(CType(96, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.lblCaption.Location = New System.Drawing.Point(38, 17)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(608, 24)
        Me.lblCaption.TabIndex = 51
        Me.lblCaption.Text = "Administración de turnos"
        '
        'SessionView
        '
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.lblInfo)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblDay)
        Me.Controls.Add(Me.pnlBottom)
        Me.Controls.Add(Me.btnPreviousDay)
        Me.Controls.Add(Me.btnNextDay)
        Me.Controls.Add(Me.dtpCalendar)
        Me.Controls.Add(Me.dgvView)
        Me.Name = "SessionView"
        Me.Size = New System.Drawing.Size(671, 412)
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlBottom.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnPreviousDay As Button
    Friend WithEvents btnNextDay As Button
    Friend WithEvents dtpCalendar As DateTimePicker
    Friend WithEvents pnlBottom As Panel
    Friend WithEvents btnDetails As Button
    Protected WithEvents dgvView As DataGridView
#End Region

    Public Sub New()
        MyBase.New

        InitializeComponent()

        LoadCaptions()
    End Sub
    Public Sub LoadData()
        GoToToday()
    End Sub
    Public Shared Function DayOfWeek(ByVal nDayNumber As Integer) As String
        Return sDays(nDayNumber Mod 7)
    End Function
    Public Shared Function DayOfWeek(ByVal dDate As Date) As String
        Select Case dDate.DayOfWeek
            Case System.DayOfWeek.Monday
                Return sDays(0)
            Case System.DayOfWeek.Tuesday
                Return sDays(1)
            Case System.DayOfWeek.Wednesday
                Return sDays(2)
            Case System.DayOfWeek.Thursday
                Return sDays(3)
            Case System.DayOfWeek.Friday
                Return sDays(4)
            Case System.DayOfWeek.Saturday
                Return sDays(5)
            Case System.DayOfWeek.Sunday
                Return sDays(6)
            Case Else
                Throw New Exception
        End Select
    End Function
    Public Shared Function MonthName(ByVal dDate As Date) As String
        Return sMonths(dDate.Month - 1)
    End Function
    Public Shared Function ShortDateFormat(ByVal dDate As Date) As String
        Return dDate.Day & " " & MonthName(dDate).Substring(0, 3) & " " & dDate.Year.ToString.Substring(2, 2)
    End Function
    Public Shared Function GetSalesDateFromDate(ByVal dDate As Date, ByVal dStartDay As Date) As Date
        'le resta la hora de comienzo
        Return dDate.AddSeconds(-dStartDay.Second).AddMinutes(-dStartDay.Minute).AddHours(-dStartDay.Hour).Date
    End Function
    Public Sub GoToToday()
        dDate = GetSalesDateFromDate(Date.Now, "1899-12-31 00:00:00.000") 'oApp.Parameters.GetValue("DAYSTART"))
        RefreshDate()
        GetSessionList()
    End Sub
    Public Sub GoToNextDay()
        dDate = dDate.AddDays(1)
        RefreshDate()
        GetSessionList()
    End Sub

    Public Sub GoToPreviousDay()
        dDate = dDate.AddDays(-1)
        RefreshDate()
        GetSessionList()
    End Sub
    Private Sub RefreshDate()
        Dim dToday As Date = GetSalesDateFromDate(Date.Now, "1899-12-31 00:00:00.000") 'oApp.Parameters.GetValue("DAYSTART"))

        lblDate.BackColor = BaseColor
        lblDay.BackColor = BaseColor
        lblInfo.BackColor = BaseColor

        lblDate.Text = ShortDateFormat(dDate)
        lblDay.Text = DayOfWeek(dDate)

        If dDate = dToday Then
            lblInfo.Text = Msg_Today
        ElseIf dDate = dToday.AddDays(1) Then
            lblInfo.Text = Msg_Tomorrow
        ElseIf dDate > dToday.AddDays(1) Then
            lblInfo.Text = Msg_Future
        Else
            lblInfo.Text = Msg_Past

            lblDate.BackColor = DisabledColor
            lblDay.BackColor = DisabledColor
            lblInfo.BackColor = DisabledColor
        End If
    End Sub
    Public Sub GetSessionList()
        Dim oSaleDateData As New SalesDateData

        oBSource = New BindingSource

        oBSource.DataSource = oSaleDateData.PostSessionsPerSalesDate(dDate)

        dgvView.DataSource = oBSource.DataSource

    End Sub

    Dim Msg_Past As String = "PASADO"
    Dim Msg_Today As String = "HOY"
    Dim Msg_Tomorrow As String = "MAÑANA"
    Dim Msg_Future As String = "FUTURO"
    Dim Msg_SalesSessionView As String = "Ventas manuales"

    Private Sub SessionView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GoToToday()
    End Sub

    Private Sub btnNextDay_Click(sender As Object, e As EventArgs) Handles btnNextDay.Click
        GoToNextDay()
    End Sub

    Private Sub btnPreviousDay_Click(sender As Object, e As EventArgs) Handles btnPreviousDay.Click
        GoToPreviousDay()
    End Sub



    Private Sub lblDate_Click(sender As Object, e As EventArgs) Handles lblDate.Click
        dtpCalendar.Select()
        SendKeys.Send("%{DOWN}")

        RefreshDate()
        GetSessionList()
    End Sub

    Private Sub dtpCalendar_ValueChanged(sender As Object, e As EventArgs) Handles dtpCalendar.ValueChanged
        lblDate.Text = dtpCalendar.Text
    End Sub

    Private Sub btnDetails_Click(sender As Object, e As EventArgs) Handles btnDetails.Click
        If dgvView.SelectedRows.Count > 0 Then
            ShowDetails(dgvView.CurrentRow)
        End If
    End Sub

    Private Sub dgvView_CellContentDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvView.CellContentDoubleClick
        If dgvView.SelectedRows.Count > 0 Then
            ShowDetails(dgvView.CurrentRow)
        End If
    End Sub
    Private Sub ShowDetails(Row As DataGridViewRow)
        Cursor = Cursors.WaitCursor

        Dim oSaleDateDetails As New SessionDetails


        Me.Visible = False

        oSaleDateDetails.Dock = DockStyle.Fill
        oMainForm.ShowView(oSaleDateDetails)
        oMainForm.HideLeftPanel()

        oSaleDateDetails.SessionDate = dDate
        oSaleDateDetails.SetupDate(oBSource, DirectCast(Row.DataBoundItem, DataRowView))


        Cursor = Cursors.Default
    End Sub

    Private Sub LoadCaptions()
        dgvView.AutoGenerateColumns = False
        dgvView.ColumnCount = 6

        With dgvView
            .Columns(0).Name = "SSS_Id"
            .Columns(0).DataPropertyName = "SSS_Id"
            .Columns(0).HeaderText = "SSS_Id"
            .Columns(0).Visible = False

            .Columns(1).Name = "USR_Id"
            .Columns(1).DataPropertyName = "USR_Id"
            .Columns(1).HeaderText = "Usuario"
            .Columns(1).Width = 120
            .Columns(1).Visible = False

            .Columns(2).Name = "USR_Name"
            .Columns(2).DataPropertyName = "USR_Name"
            .Columns(2).HeaderText = "Usuario"
            .Columns(2).Width = 120

            .Columns(3).Name = "SSS_TRM_Id"
            .Columns(3).DataPropertyName = "SSS_TRM_Id"
            .Columns(3).HeaderText = "TRM_Id"
            .Columns(3).Visible = False

            .Columns(4).Name = "SSS_DateCreated"
            .Columns(4).DataPropertyName = "SSS_DateCreated"
            .Columns(4).HeaderText = "Apertura:"
            .Columns(4).Width = 70

            .Columns(5).Name = "SSS_DateClosed"
            .Columns(5).DataPropertyName = "SSS_DateClosed"
            .Columns(5).HeaderText = "Cierre:"
            .Columns(5).Width = 70


        End With
    End Sub


End Class
