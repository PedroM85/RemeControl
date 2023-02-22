Public Class CommonFunction
    Public Function ManejarDecimalEnTextBox(sender As Object, e As KeyPressEventArgs) As Boolean
        'textBox As TextBox
        Dim txt = CType(sender, TextBox)
        ' Verificar si la tecla presionada es un número o un símbolo decimal
        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." And Not e.KeyChar = "," And Not e.KeyChar = "*" Then
            e.Handled = True
        End If
        'If Not Char.IsControl(e.KeyChar) And Not Char.IsDigit(e.KeyChar) And e.KeyChar <> "."c Then
        '    Return True
        'End If

        ' Permitir solo un símbolo decimal
        If e.KeyChar = "."c AndAlso txt.Text.IndexOf("."c) > -1 Then
            Return True
        End If

        Return False
    End Function

    Public Sub ValiText(sender As Object, e As KeyPressEventArgs)

        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) And Not e.KeyChar = "." And Not e.KeyChar = "," And Not e.KeyChar = "*" Then
            e.Handled = True
        End If

    End Sub

    Public Sub ValiNum(sender As Object, e As KeyPressEventArgs)

        If Not IsNumeric(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If


    End Sub


End Class
