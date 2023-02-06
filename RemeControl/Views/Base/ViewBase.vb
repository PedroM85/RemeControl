Public Class ViewBase
    Inherits UserControl


    Public Event AddNew()
    Public Event Delete(ByVal row As DataRowView)
    Public Event Edit()
    Public Event SetDataBinding()
    Public Property Caption() As String
        Get
            Return lblCaption.Text
        End Get
        Set(ByVal Value As String)
            lblCaption.Text = Value

            'oApp.Tools.DatosgeneralesABM(lblCaption)
        End Set
    End Property


    Private Sub ExecEdit()
        If oApp.SessionActive Then
            RaiseEvent Edit()
        Else
            MessageBox.Show("La session caduco", Me.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            Application.Exit()
        End If

    End Sub

    Private Sub ExecAddNew()
        If oApp.SessionActive Then
            RaiseEvent AddNew()
        Else
            MessageBox.Show("La session caduco", Me.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)
            Application.Exit()
        End If

    End Sub
    Private Sub ExecDelete()
        If oApp.SessionActive Then

            If dgvView.RowCount > 0 Then
                RaiseEvent Delete(dgvView.CurrentRow().DataBoundItem)
            End If
        Else
            MessageBox.Show("La session caduco", Me.Caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

            Application.Exit()
        End If
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click

        ExecAddNew()

    End Sub


    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        ExecEdit()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        ExecEdit()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        ExecDelete()
    End Sub


    Private Sub dgvView_DoubleClick(sender As Object, e As MouseEventArgs) Handles dgvView.DoubleClick
        Dim hit As DataGridView.HitTestInfo = dgvView.HitTest(e.X, e.Y)
        If hit.Type = DataGridViewHitTestType.Cell Then
            ExecEdit()
        End If
    End Sub

    Private Sub dgvView_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dgvView.KeyPress
        If e.KeyChar = Chr(Keys.Enter) Then
            'Dim oRow As DataGridViewRow = dgvView.CurrentRow.DataBoundItem
            'If Not oRow Is Nothing Then
            ExecEdit()
            'End If
        End If
    End Sub





    'Private Sub UnelBaseView_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
    '    EnvironmentObjects.Framework.LastAction = Now
    'End Sub

    'Private Sub UnelBaseView_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
    '    EnvironmentObjects.Framework.LastAction = Now
    'End Sub

    'Private Sub UnelBaseView_Click(sender As Object, e As EventArgs) Handles MyBase.Click
    '    EnvironmentObjects.Framework.LastAction = Now
    'End Sub

End Class
