Public Class PlaceholderTextBox
    Inherits TextBox

    Private placeholderText As String = String.Empty
    Private placeholderColor As Color = Color.Gray
    Private originalColor As Color
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
                Me.Text = placeholderText
                Me.ForeColor = placeholderColor
            End If
        End Set
    End Property
    Private Sub TextBox_GotFocus(sender As Object, e As EventArgs)
        If Me.Text = placeholderText Then
            Me.Text = String.Empty
            Me.ForeColor = originalColor
        End If
    End Sub

    Private Sub TextBox_LostFocus(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(Me.Text) Then
            Me.Text = placeholderText
            Me.ForeColor = placeholderColor
        End If
    End Sub

End Class
