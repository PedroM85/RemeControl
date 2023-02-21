Imports System.Security.Policy

Public Class DashView

    Private CurrentButton As Button
    Private oDashData As DashboardDataLayer

    Public Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()
        dtpStartDate.Value = DateTime.Today.AddDays(-7)
        dtpEndDate.Value = DateTime.Now.ToString("d")
        btnLast7.Select()
        SetDateMenuButtons(btnLast7)

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        LoadLeyendaSerie

    End Sub

    Private Sub LoadLeyendaSerie()
        oDashData = New DashboardDataLayer
        Dim Data As DataTable
        Try
            Data = oDashData.GetSocios()
            If Data.Rows.Item(0).ItemArray(0) = -9999 Then

            Else
                Chart1.Series.Add(Data.Rows(0).ItemArray(1))

            End If

        Catch ex As Exception

        End Try


    End Sub

    Public Sub LoadData()
        oDashData = New DashboardDataLayer


        lblStartDate.Text = dtpStartDate.Value.ToString("yyyy-MM-dd")
        lblEndDate.Text = dtpEndDate.Value.ToString("yyyy-MM-dd")

        Chart()
        TotalInfo()



    End Sub
    Public Sub TotalInfo()

        Dim Data As DataTable

        Data = oDashData.GetTotalInfo


        If Data IsNot Nothing Then
            lblNCambios.Text = String.Format("Clientes: {0}", Data.Rows(0).ItemArray(2))
            lblTotalCambios.Text = String.Format("Cambios: {0}", Data.Rows(0).ItemArray(3))
            lblOrdenReady.Text = Data.Rows(0).ItemArray(1)
            lblTotalMensual.Text = String.Format("Total: ${0}", Data.Rows(0).ItemArray(0))

        End If

    End Sub
    Public Sub Chart()
        Dim oDash As DashboardData
        Dim Data As DataTable
        oDash = New DashboardData With
            {
            .OP_DateStart = lblStartDate.Text,
            .OP_DateEnd = lblEndDate.Text
        }

        Try

            Chart1.DataSource = Nothing
            Data = oDashData.GetCambios(oDash)
            If Data IsNot Nothing Then
                Chart1.DataSource = Data
                Chart1.Series(0).XValueMember = "OP_Fecha"
                Chart1.Series(0).YValueMembers = "OP_Pesos"
                Chart1.DataBind()
            Else
                Chart1.Series(0).Points.Clear()

                Console.WriteLine("No hay datos")
            End If

        Catch ex As Exception

        End Try


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

    Private Sub lblEndDate_Click(sender As Object, e As EventArgs)
        If CurrentButton Is btnCustom Then
            dtpEndDate.Select()
            SendKeys.Send("%{DOWN}")
        End If
    End Sub

    Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
        lblStartDate.Text = dtpStartDate.Value
    End Sub

    Private Sub dtpEndDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpEndDate.ValueChanged
        lblEndDate.Text = dtpEndDate.Value
    End Sub

    Private Sub btnCustomDate_Click(sender As Object, e As EventArgs) Handles btnCustomDate.Click
        LoadData()
    End Sub


End Class
