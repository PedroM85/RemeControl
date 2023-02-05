Public Class FormMain
    Private mSalesDateInfo As SalesDateInfo

    Private oView As UserControl

    Private CurrentButton As Button

    Private mCurrStep As State
    Private mControllers(6) As Controller
    Private WithEvents mTrMgr As EWTransactionManager


#Region "Keydown"
    Private Enum State
        ShowTasa
        ShowClient
        ShowBank
        ShowCambio
        ShowSocio
        ShowDash


    End Enum

#End Region

    Private Function SessionActive() As Boolean
        Dim a As DateTime = oApp.CurrentUser.USR_SessionEnd
        Dim b As DateTime = DateTime.Now
        Try
            If a > b Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)

        End Try
    End Function


    Public Sub New()
        'MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        btnHome.Select()
        SetDateMenuButtons(btnHome)


        mControllers(State.ShowTasa) = New ShowTasa(Me)
        mControllers(State.ShowSocio) = New ShowSocio(Me)
        mControllers(State.ShowClient) = New ShowClient(Me)
        mControllers(State.ShowBank) = New ShowBank(Me)
        mControllers(State.ShowDash) = New ShowDash(Me)

    End Sub

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

        mTrMgr.DoMenuItem("DASH")
        mCurrStep = State.ShowDash

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
    Public Sub ShowLeftPanel()
        pnlLeft.Visible = True

        ActiveControl = pnlLeft
    End Sub
    Public Sub HideLeftPanel()
        pnlLeft.Visible = False
    End Sub


#Region "Abrir usercontrol"
    Public Property TransactionManager As EWTransactionManager
        Get
            Return mTrMgr
        End Get
        Set(value As EWTransactionManager)
            mTrMgr = value
        End Set
    End Property

    Private Sub mTrMgr_ViewClicked(view As UserControl) Handles mTrMgr.ViewCreated
        ShowTransaction(view)
    End Sub

    Public Sub ShowTransaction(oTransView As UserControl)
        If oTransView Is Nothing Then
            'MessageBox.Show("Vacio")
        Else
            DisposeView()

            oView = oTransView
            oView.Dock = DockStyle.Fill
            pnlFill.Controls.Clear()
            pnlFill.Controls.Add(oView)
            oView.Focus()

        End If
    End Sub

    Public Sub DisposeView()
        If Not oView Is Nothing Then
            oView.Dispose()
            oView = Nothing
        End If
    End Sub

    Public Sub ShowView(View As UserControl)
        pnlFill.Controls.Add(View)
    End Sub



#End Region

    Private Sub SetDateMenuButtons(button As Object)

        Dim btn = CType(button, Button)

        btn.BackColor = btnBank.FlatAppearance.BorderColor
        btn.ForeColor = Color.Black

        If CurrentButton IsNot Nothing And CurrentButton IsNot btn Then
            CurrentButton.BackColor = Me.BackColor
            CurrentButton.ForeColor = Color.White
        End If

        CurrentButton = btn

    End Sub
    Private Sub FormMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If mControllers(mCurrStep).BasicKeysEnabled Then

            If e.KeyCode = Keys.Escape Then

            Else
                mControllers(mCurrStep).HandleKey(e)
            End If

        Else
            mControllers(mCurrStep).HandleKey(e)
        End If
    End Sub
    Private Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        If SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("TASA")
            mCurrStep = State.ShowTasa
        Else
            Me.Close()
        End If

    End Sub
    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        If SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("DASH")
            mCurrStep = State.ShowDash
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnSocio_Click(sender As Object, e As EventArgs) Handles btnSocio.Click
        If SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("SOCIO")
            mCurrStep = State.ShowSocio
        Else
            oApp.LoginUser()
        End If

    End Sub

    Private Sub btnClients_Click(sender As Object, e As EventArgs) Handles btnClients.Click
        If SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("CLIENTE")
            mCurrStep = State.ShowClient
        Else
            oApp.LoginUser()
        End If

    End Sub

    Private Sub btnBank_Click(sender As Object, e As EventArgs) Handles btnBank.Click
        If SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("BANCO")
            mCurrStep = State.ShowBank
        Else
            oApp.LoginUser()
        End If

    End Sub

    Private Sub btnCambio_Click(sender As Object, e As EventArgs) Handles btnCambio.Click

        If SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("CAMBIO")
            mCurrStep = State.ShowBank
        Else
            oApp.LoginUser()
        End If

    End Sub

    Private Sub btnGasto_Click(sender As Object, e As EventArgs) Handles btnGasto.Click

        If SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("GASTO")
            mCurrStep = State.ShowBank
        Else
            oApp.LoginUser()
        End If

    End Sub
End Class
