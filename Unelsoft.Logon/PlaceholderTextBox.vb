Public Class PlaceholderTextBox
    Inherits TextBox

    Private placeholderText As String = String.Empty
    Private placeholderColor As Color = Color.Gray
    Private originalColor As Color
    Private isPlaceholder As Boolean = False

    Public Sub New()
        originalColor = Me.ForeColor
        AddHandler Me.GotFocus, AddressOf TextBox_GotFocus
        AddHandler Me.LostFocus, AddressOf TextBox_LostFocus
    End Sub

    Public Property Placeholder As String
        Get
            Return placeholderText
        End Get
        Set(value As String)
            placeholderText = value
            If String.IsNullOrEmpty(Me.Text) Then
                SetPlaceholderText()
            End If
        End Set
    End Property

    Private Sub TextBox_GotFocus(sender As Object, e As EventArgs)
        If isPlaceholder Then
            Me.Text = String.Empty
            Me.ForeColor = originalColor
            isPlaceholder = False
        End If
    End Sub

    Private Sub TextBox_LostFocus(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(Me.Text) Then
            SetPlaceholderText()
        End If
    End Sub

    Private Sub SetPlaceholderText()
        Me.Text = placeholderText
        Me.ForeColor = placeholderColor
        isPlaceholder = True
    End Sub

    Public Sub ResetPlaceholder()
        If isPlaceholder Then
            Me.Text = String.Empty
            Me.ForeColor = originalColor
            isPlaceholder = False
        End If
    End Sub
End Class
