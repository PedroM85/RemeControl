Public Class WaitForm

    Public Sub New()
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub

    Public Property Message() As String
        Get
            Return lblMessage.Text
        End Get
        Set(value As String)
            lblMessage.Text = value
        End Set
    End Property


    Public Shadows Sub show(Optional Message As String = "")
        If Message.Length > 0 Then
            Me.lblMessage.Text = Message
        End If

        MyBase.Show()
        Application.DoEvents()
    End Sub

    Public Sub IncrementProgress()
        If ProgressBar1.Visible Then
            ProgressBar1.Value += 1
        End If
    End Sub

    Public Sub ResetProgress()
        If ProgressBar1.Visible Then
            ProgressBar1.Value = 0
        End If
    End Sub

    Public Sub ShowProgress(Start As Int32, [End] As Int32)
        HideAnimation
        With ProgressBar1
            .Minimum = Start
            .Maximum = [End]
            .Value = .Minimum
            .Visible = True
        End With
    End Sub

    Public Sub HideProgress()
        With ProgressBar1
            .Minimum = 0
            .Maximum = 0
            .Value = 0
            .Visible = False
        End With
    End Sub

    Public Sub ShowAnimation()
        HideProgress()
    End Sub

    Public Sub HideAnimation()

    End Sub
End Class