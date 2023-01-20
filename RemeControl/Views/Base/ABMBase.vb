Public Class ABMBase


    Private lAddNew As Boolean

    Public Event Cancel()
    Public Event Close()
    Public Event Save()

    Public Property Caption() As String
        Get
            Return lblCaption.Text
        End Get
        Set(value As String)
            lblCaption.Text = value
        End Set
    End Property

    Public ReadOnly Property IsAddNew() As Boolean
        Get
            Return lAddNew
        End Get
    End Property

    Public Sub New()
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        lblDate.Text = Date.Now.ToShortTimeString


    End Sub

    Public Sub Edit()

    End Sub
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        RaiseEvent Cancel()
        RaiseEvent Close()
    End Sub
    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click

        RaiseEvent Save()

    End Sub

    Public Sub FormatDecimal(sender As Object, cevent As ConvertEventArgs)
        If cevent.DesiredType Is GetType(String) Then
            cevent.Value = CType(cevent.Value, Decimal).ToString("n")
        End If

    End Sub

    Private Sub TasaBase_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.F1 Then
            MessageBox.Show("prueba")
        End If
    End Sub

    Private Sub ABMBase_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        EnvironmentObjects.Framework.LastAction = Now
    End Sub
End Class
