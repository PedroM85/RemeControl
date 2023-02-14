Public Class SessionDetails

    Public Sub New()
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Private dSessionDate As DateTime
    Private nSessionId As Integer
    Private sUserId As String
    Private oBSources As BindingSource

    Public Event Close()

    Public Property SessionDate As DateTime
        Get
            Return dSessionDate
        End Get
        Set(value As DateTime)
            dSessionDate = value
        End Set
    End Property

    Public Sub SetupDate(Data As BindingSource, row As DataRowView)
        nSessionId = row("SSS_Id")

        sUserId = row("USR_Id")

        lblUserValue.Text = row("USR_Name")
        lblTerminalValue.Text = row("SSS_TRM_Id")
        lblOpenedValue.Text = row("SSS_DateCreated")
        If row("SSS_DateClosed") Is DBNull.Value Then
            lblClosedValue.Text = ""
            btnCloseSession.Enabled = True
            btnModify.Enabled = True
            btnReOpen.Enabled = True
        Else
            lblClosedValue.Text = row("SSS_DateClosed")
            btnCloseSession.Enabled = False
            btnModify.Enabled = False
            btnReOpen.Enabled = False
        End If

        SetupDepositsData

    End Sub
    Private Sub SetupDepositsData()
        Dim oDataLayer As New SalesDateData
        oBSources = New BindingSource

        oBSources.DataSource = oDataLayer.PostSessionPaymentType(nSessionId)

        dgvView.DataSource = oBSources

    End Sub

    Private Sub btnCloseSession_Click(sender As Object, e As EventArgs) Handles btnCloseSession.Click
        Dim oDataLayer As New SalesDateData
        Dim dCreated, dClosed As DateTime

        CloseSession(nSessionId)

        btnCloseSession.Enabled = False
        btnModify.Enabled = True

        oDataLayer.PostSessionInfo(nSessionId, dCreated, dClosed)

        If dClosed <> New DateTime(9999, 12, 31, 0, 0, 0, 0) Then
            lblClosedValue.Text = dClosed
        End If

        UpdateData

    End Sub
    Public Sub CloseSession(nSessionId As Integer)
        Dim oDataLayer As New SalesDateData


        oDataLayer.PostCloseSession(nSessionId)

    End Sub
    Private Sub UpdateData()

    End Sub
    Private Function UserSignedOk() As Boolean
        Dim oSec As New SecurityManager
        Dim Auth As New AuthorizationForm

        Auth.Title = "Firma del usuario"
        Auth.TxtUser.Text = sUserId.Trim
        Auth.TxtUser.Enabled = False

        Dim oResult As DialogResult = Auth.ShowDialog

        If oResult = DialogResult.OK Then
            If Not oSec.Login(sUserId.Trim, Auth.txtPassword.Text) Is Nothing Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Public Sub ReOpenSession(nSessionId As Integer)
        Dim oDataLayer As New SalesDateData

        'oDataLayer.ReOpenSession
    End Sub
    Private Sub btnReOpen_Click(sender As Object, e As EventArgs) Handles btnReOpen.Click

        If MessageBox.Show(Me, "re abrir turno", "Unelsoft", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            If UserSignedOk() Then
                Try
                    ReOpenSession(nSessionId)

                Catch ex As Exception

                End Try
            End If
        End If
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click

    End Sub
End Class
