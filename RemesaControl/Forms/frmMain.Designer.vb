<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        pnlBottom = New Panel()
        Label1 = New Label()
        pnlLeft = New Panel()
        pnlBottom.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlBottom
        ' 
        pnlBottom.BackColor = Color.FromArgb(CByte(44), CByte(27), CByte(71))
        pnlBottom.Controls.Add(Label1)
        pnlBottom.Dock = DockStyle.Bottom
        pnlBottom.Location = New Point(184, 475)
        pnlBottom.Name = "pnlBottom"
        pnlBottom.Size = New Size(635, 39)
        pnlBottom.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        Label1.Location = New Point(383, 10)
        Label1.Name = "Label1"
        Label1.RightToLeft = RightToLeft.Yes
        Label1.Size = New Size(240, 20)
        Label1.TabIndex = 0
        Label1.Text = "Label1"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.FromArgb(CByte(44), CByte(27), CByte(71))
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(184, 514)
        pnlLeft.TabIndex = 1
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(114), CByte(76), CByte(157))
        ClientSize = New Size(819, 514)
        Controls.Add(pnlBottom)
        Controls.Add(pnlLeft)
        Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point)
        ForeColor = Color.White
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmMain"
        pnlBottom.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlBottom As Panel
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents Label1 As Label
End Class
