Public Class FormMain
    Private mSalesDateInfo As SalesDateInfo

    Private oView As UserControl

    Private CurrentButton As Button

    Private mCurrStep As State
    Private mControllers(15) As Controller
    Private WithEvents mTrMgr As EWTransactionManager

    Public FlagRed As Boolean = False

#Region "Keydown"
    Private Enum State
        ShowTasa
        ShowClient
        ShowBank
        ShowCambio
        ShowSocio
        ShowDash
        ShowBankSo
        ShowSession
        ShowTurnos
        ShowGastos

    End Enum

#End Region


    Public Sub New()
        'MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().


        btnHome.Select()
        SetDateMenuButtons(btnHome)

        Dim oSessionVew As New SessionView

        mControllers(State.ShowTasa) = New ShowTasa(Me)
        mControllers(State.ShowSocio) = New ShowSocio(Me)
        mControllers(State.ShowClient) = New ShowClient(Me)
        mControllers(State.ShowBank) = New ShowBank(Me)
        mControllers(State.ShowDash) = New ShowDash(Me)
        mControllers(State.ShowBankSo) = New ShowBankSo(Me)
        mControllers(State.ShowSession) = New ShowSession(Me)
        mControllers(State.ShowTurnos) = New ShowTurnos(oSessionVew)
        mControllers(State.ShowCambio) = New ShowCambio(Me)
        mControllers(State.ShowGastos) = New ShowGasto(Me)

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

        Me.SalesDateInfo = Nothing
        LoadData()
        RefreshInfo()

    End Sub

    Public Sub LoadData()
        lblUser.Text = String.Format("Usuario: {0}", oApp.CurrentUser.USR_Name)

        mSalesDateInfo = oApp.GetSalesDateInfo
        RefreshInfo()
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


            If mSalesDateInfo.SDT_Id = New Date(1, 1, 1) Then
                lblInfo.Text = String.Format("Dia de cambios:  Ninguno |Hora: {0} ", Date.Now.ToShortTimeString)
            Else
                lblInfo.Text = String.Format("Dia de cambios: {0} | Hora: {1} ", mSalesDateInfo.SDT_Id.ToString("dd MMM yyyy"), Date.Now.ToShortTimeString)
            End If

            If mSalesDateInfo.SDT_Id <> Date.Now.Date Then
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
    Public Sub ExitView(View As UserControl)
        Try
            pnlLeft.Controls.Remove(View)

        Catch ex As System.IndexOutOfRangeException

        End Try
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
            oView.BringToFront()
            pnlFill.Controls.Clear()
            pnlFill.Controls.Add(oView)
            pnlFill.BringToFront()
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

    Public Sub SetDateMenuButtons(button As Object)

        Dim btn = CType(button, Button)

        btn.BackColor = btnBank.FlatAppearance.BorderColor
        btn.ForeColor = Color.Black

        If CurrentButton IsNot Nothing And CurrentButton IsNot btn Then
            CurrentButton.BackColor = Me.BackColor
            CurrentButton.ForeColor = Color.White
            'CurrentButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End If

        CurrentButton = btn

    End Sub
    Private Sub FormMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If mControllers(mCurrStep).BasicKeysEnabled Then

            If e.KeyCode = Keys.Escape Then

            ElseIf e.KeyCode = Keys.C AndAlso Keys.O AndAlso e.Alt Then
                MessageBox.Show("algo va a pasar")

            Else
                mControllers(mCurrStep).HandleKey(e)
            End If

        Else
            mControllers(mCurrStep).HandleKey(e)
        End If
    End Sub
    Public Sub CallCalcule()
        Dim sender As Object = DirectCast(btnCalcular, Button)
        SetDateMenuButtons(sender)
        mTrMgr.DoMenuItem("TASA")


    End Sub
    Public Sub btnCalcular_Click(sender As Object, e As EventArgs) Handles btnCalcular.Click
        If oApp.SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("TASA")
            mCurrStep = State.ShowTasa
        Else
            MessageBox.Show("La session caduco", "Remesa Control", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            Me.Close()
        End If

    End Sub
    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        If oApp.SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("DASH")
            mCurrStep = State.ShowDash
        Else
            MessageBox.Show("La session caduco", "Remesa Control", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            Me.Close()
        End If
    End Sub

    Private Sub btnSocio_Click(sender As Object, e As EventArgs) Handles btnSocio.Click
        If oApp.SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("SOCIO")
            mCurrStep = State.ShowSocio
        Else
            MessageBox.Show("La session caduco", "Remesa Control", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            Me.Close()
        End If

    End Sub

    Private Sub btnClients_Click(sender As Object, e As EventArgs) Handles btnClients.Click
        If oApp.SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("CLIENTE")
            mCurrStep = State.ShowClient
        Else
            MessageBox.Show("La session caduco", "Remesa Control", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            Me.Close()
        End If

    End Sub

    Private Sub btnBank_Click(sender As Object, e As EventArgs) Handles btnBank.Click
        If oApp.SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("BANCO")
            mCurrStep = State.ShowBank
        Else
            MessageBox.Show("La session caduco", "Remesa Control", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            Me.Close()
        End If

    End Sub

    Private Sub btnCambio_Click(sender As Object, e As EventArgs) Handles btnCambio.Click

        If oApp.SessionActive() Then
            'If oApp.IsSaleDateOpened Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("CAMBIO")
            If FlagRed Then
                CallCalcule()
            End If
            mCurrStep = State.ShowCambio
            'End If
        Else
            MessageBox.Show("La session caduco", "Remesa Control", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            Me.Close()
        End If

    End Sub

    Private Sub btnGasto_Click(sender As Object, e As EventArgs) Handles btnGasto.Click

        If oApp.SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("GASTO")
            mCurrStep = State.ShowGastos
        Else
            MessageBox.Show("La session caduco", "Remesa Control", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            Me.Close()
        End If

    End Sub

    Private Sub btnBancoSo_Click(sender As Object, e As EventArgs) Handles btnBancoSo.Click
        If oApp.SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("BANCOSO")
            mCurrStep = State.ShowBankSo
        Else
            MessageBox.Show("La session caduco", "Remesa Control", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            Me.Close()
        End If
    End Sub

    Private Sub btnSession_Click(sender As Object, e As EventArgs) Handles btnSesion.Click
        If oApp.SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("SESION")
            mCurrStep = State.ShowSession
        Else
            MessageBox.Show("La session caduco", "Remesa Control", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            Me.Close()
        End If
    End Sub

    Private Sub btnTurno_Click(sender As Object, e As EventArgs) Handles btnTurno.Click
        If oApp.SessionActive() Then
            SetDateMenuButtons(sender)
            mTrMgr.DoMenuItem("TURNOS")
            mCurrStep = State.ShowTurnos
        Else
            MessageBox.Show("La session caduco", "Remesa Control", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            Me.Close()
        End If
    End Sub
End Class
