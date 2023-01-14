Public Class FormMain
    Private mSalesDateInfo As SalesDateInfo

    Public Property SalesDateInfo() As SalesDateInfo
        Get
            Return mSalesDateInfo
        End Get
        Set(value As SalesDateInfo)
            mSalesDateInfo = value
            RefreshInfo()
        End Set
    End Property
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Public Sub LoadData()
        lblUser.Text = String.Format("Usuario: {0}", oApp.CurrentUser.USR_Name)

        Me.SalesDateInfo = oApp.GetSalesDateInfo

        Application.DoEvents()

    End Sub
    Public Sub RefreshSite()
        Me.SalesDateInfo = Nothing
        Application.DoEvents()
    End Sub

    Public Sub RefreshInfo()
        If mSalesDateInfo Is Nothing Then
            tmrBlinkyBlinky2.Enabled = False
            lblInfo.Visible = False
        Else

            If mSalesDateInfo.SalesDateId = New Date(1, 1, 1) Then
                lblInfo.Text = String.Format("Dia de cambios:  Ninguno |Hora: {0} ", Date.Now.ToShortTimeString)
            Else
                lblInfo.Text = String.Format("Dia de cambios: {0} |Hora: {1} ", mSalesDateInfo.SalesDateId.ToString("dd MMM yyyy"), Date.Now.ToShortTimeString)
            End If

            If mSalesDateInfo.SalesDateId <> Date.Now.Date Then
                tmrBlinkyBlinky2.Enabled = True
            Else
                tmrBlinkyBlinky2.Enabled = False
                lblInfo.Visible = True
            End If

        End If
    End Sub

    Private Sub tmrBlinkyBlinky2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBlinkyBlinky2.Tick
        lblInfo.Visible = Not lblInfo.Visible
    End Sub
End Class
