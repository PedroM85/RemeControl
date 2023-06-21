Imports System.Drawing
Imports System.Windows.Forms

Public Class EWMessageBox
    Public Sub New()
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Overloads Shared Function Show(ByVal owner As IWin32Window,
                                          ByVal text As String,
                                          Optional ByVal caption As String = "",
                                          Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK,
                                          Optional ByVal icon As MessageBoxIcon = MessageBoxIcon.None,
                                          Optional ByVal defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Dim oForm As New EWMessageBox()
        Dim oResult As DialogResult

        oForm.lblInfo.Text = text

        Select Case buttons
            Case MessageBoxButtons.OK
                ' Boton de Aceptar
                oForm.btn1.Text = "Aceptar"
                oForm.btn1.DialogResult = System.Windows.Forms.DialogResult.OK
                oForm.btn1.Location = New Point(200, 110)
                oForm.btn1.Visible = True
                oForm.AcceptButton = oForm.btn1
                oForm.btn2.Visible = False
                oForm.btn3.Visible = False
            Case MessageBoxButtons.OKCancel
                ' Boton de Aceptar
                oForm.btn1.Text = "Aceptar"
                oForm.btn1.DialogResult = System.Windows.Forms.DialogResult.OK
                oForm.btn1.Location = New Point(152, 110)
                oForm.btn1.Visible = True
                oForm.AcceptButton = oForm.btn1
                ' Boton de Cancelar
                oForm.btn2.Text = "Cancelar"
                oForm.btn2.DialogResult = System.Windows.Forms.DialogResult.Cancel
                oForm.btn2.Location = New Point(248, 110)
                oForm.btn2.Visible = True
                oForm.CancelButton = oForm.btn2
                oForm.btn3.Visible = False
            Case MessageBoxButtons.YesNo
                ' Boton de Si
                oForm.btn1.Text = "Si"
                oForm.btn1.DialogResult = System.Windows.Forms.DialogResult.Yes
                oForm.btn1.Location = New Point(152, 110)
                oForm.btn1.Visible = True
                oForm.AcceptButton = Nothing
                ' Boton de Cancelar
                oForm.btn2.Text = "No"
                oForm.btn2.DialogResult = System.Windows.Forms.DialogResult.No
                oForm.btn2.Location = New Point(248, 110)
                oForm.btn2.Visible = True
                oForm.CancelButton = Nothing
                oForm.btn3.Visible = False
            Case MessageBoxButtons.YesNoCancel
                ' Boton de Si
                oForm.btn1.Text = "Si"
                oForm.btn1.DialogResult = System.Windows.Forms.DialogResult.Yes
                oForm.btn1.Location = New Point(104, 110)
                oForm.btn1.Visible = True
                oForm.AcceptButton = Nothing
                ' Boton de No
                oForm.btn2.Text = "No"
                oForm.btn2.DialogResult = System.Windows.Forms.DialogResult.No
                oForm.btn2.Location = New Point(200, 110)
                oForm.btn2.Visible = True
                ' Boton de Cancelar
                oForm.btn3.Text = "Cancelar"
                oForm.btn3.DialogResult = System.Windows.Forms.DialogResult.Cancel
                oForm.btn3.Location = New Point(296, 110)
                oForm.btn3.Visible = True
                oForm.CancelButton = oForm.btn3

        End Select

        Select Case defaultButton
            Case MessageBoxDefaultButton.Button1
                oForm.AcceptButton = oForm.btn1
            Case MessageBoxDefaultButton.Button2
                oForm.AcceptButton = oForm.btn2
            Case MessageBoxDefaultButton.Button3
                oForm.AcceptButton = oForm.btn3
        End Select

        Select Case icon
            Case MessageBoxIcon.Error
                oForm.picError.Visible = True
            Case MessageBoxIcon.Exclamation
                oForm.picExclamation.Visible = True
            Case MessageBoxIcon.Information
                oForm.picInformation.Visible = True
            Case MessageBoxIcon.Question
                oForm.picQuestion.Visible = True
        End Select

        oResult = oForm.ShowDialog(owner)

        oForm.Dispose()

        Return oResult
    End Function

    Public Overloads Shared Function Show(ByVal text As String,
                                          Optional ByVal caption As String = "",
                                          Optional ByVal buttons As MessageBoxButtons = MessageBoxButtons.OK,
                                          Optional ByVal icon As MessageBoxIcon = MessageBoxIcon.None,
                                          Optional ByVal defaultButton As MessageBoxDefaultButton = MessageBoxDefaultButton.Button1) As DialogResult
        Return Show(Nothing, text, caption, buttons, icon, defaultButton)
    End Function
End Class