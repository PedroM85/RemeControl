Public Class DashView

    Private CurrentButton As Button

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        dtpStartDate.Value = DateTime.Today.AddDays(-7)
        dtpEndDate.Value = DateTime.Now
        btnLast7.Select()
        SetDateMenuButtons(btnLast7)

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Sub LoadData()
        'Dim oClientData As ClienteDataLayer = Nothing

        'oClientData = New ClienteDataLayer

        'dgvView.DataSource = Nothing

        'If oClientData.GetClientes Is Nothing Then
        '    Label1.Visible = True

        'Else
        '    'pnlVacio.Visible = False
        '    dgvView.DataSource = oClientData.GetClientes
        'End If
        Chart()

        lblStartDate.Text = dtpStartDate.Text
        lblEndDate.Text = dtpEndDate.Text

    End Sub

    Public Sub Chart()
        Chart1.Series(0).Points.AddXY("sss", 60)
    End Sub

    Private Sub SetDateMenuButtons(button As Object)

        Dim btn = CType(button, Button)

        btn.BackColor = btnLast30.FlatAppearance.BorderColor
        btn.ForeColor = Color.White

        If CurrentButton IsNot Nothing And CurrentButton IsNot btn Then
            CurrentButton.BackColor = Me.BackColor
            CurrentButton.ForeColor = Color.Blue
        End If

        CurrentButton = btn

        If btn Is btnCustom Then
            dtpStartDate.Enabled = True
            dtpEndDate.Enabled = True
            btnCustomDate.Visible = True
            lblStartDate.Cursor = Cursors.Hand
            lblEndDate.Cursor = Cursors.Hand
        Else
            dtpStartDate.Enabled = False
            dtpEndDate.Enabled = False
            btnCustomDate.Visible = False
            lblStartDate.Cursor = Cursors.Default
            lblEndDate.Cursor = Cursors.Default
        End If

        'dtpStartDate.Enabled = False
        'dtpEndDate.Enabled = False
        'btnCustomDate.Visible = False
    End Sub

    Private Sub btnHoy_Click(sender As Object, e As EventArgs) Handles btnHoy.Click
        dtpStartDate.Value = DateTime.Today
        dtpEndDate.Value = DateTime.Now
        LoadData()
        SetDateMenuButtons(sender)
    End Sub

    Private Sub btnLast7_Click(sender As Object, e As EventArgs) Handles btnLast7.Click
        dtpStartDate.Value = DateTime.Today.AddDays(-7)
        dtpEndDate.Value = DateTime.Now
        LoadData()
        SetDateMenuButtons(sender)
    End Sub

    Private Sub btnLast30_Click(sender As Object, e As EventArgs) Handles btnLast30.Click
        dtpStartDate.Value = DateTime.Today.AddDays(-30)
        dtpEndDate.Value = DateTime.Now
        LoadData()
        SetDateMenuButtons(sender)
    End Sub

    Private Sub btnThisMonth_Click(sender As Object, e As EventArgs) Handles btnThisMonth.Click
        dtpStartDate.Value = New DateTime(DateTime.Today.Year, DateTime.Today.Month, 1)
        dtpEndDate.Value = DateTime.Now
        LoadData()
        SetDateMenuButtons(sender)
    End Sub

    Private Sub btnCustom_Click(sender As Object, e As EventArgs) Handles btnCustom.Click
        dtpStartDate.Enabled = True
        dtpEndDate.Enabled = True
        btnCustomDate.Visible = True
        SetDateMenuButtons(sender)
    End Sub

    Private Sub lblStartDate_Click(sender As Object, e As EventArgs) Handles lblStartDate.Click
        If CurrentButton Is btnCustom Then
            dtpStartDate.Select()
            SendKeys.Send("%{DOWN}")
        End If
    End Sub

    Private Sub lblEndDate_Click(sender As Object, e As EventArgs) Handles lblEndDate.Click
        If CurrentButton Is btnCustom Then
            dtpEndDate.Select()
            SendKeys.Send("%{DOWN}")
        End If
    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        lblStartDate.Text = dtpStartDate.Text
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        lblEndDate.Text = dtpEndDate.Text
    End Sub
End Class
