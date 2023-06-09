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
        pnlLeft = New Panel()
        MenuStrip1 = New MenuStrip()
        AguaToolStripMenuItem = New ToolStripMenuItem()
        ArrorToolStripMenuItem = New ToolStripMenuItem()
        PegaToolStripMenuItem = New ToolStripMenuItem()
        pnlLeft.SuspendLayout()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' pnlBottom
        ' 
        pnlBottom.BackColor = Color.FromArgb(CByte(44), CByte(27), CByte(71))
        pnlBottom.Dock = DockStyle.Bottom
        pnlBottom.Location = New Point(184, 475)
        pnlBottom.Name = "pnlBottom"
        pnlBottom.Size = New Size(635, 39)
        pnlBottom.TabIndex = 0
        ' 
        ' pnlLeft
        ' 
        pnlLeft.BackColor = Color.FromArgb(CByte(44), CByte(27), CByte(71))
        pnlLeft.Controls.Add(MenuStrip1)
        pnlLeft.Dock = DockStyle.Left
        pnlLeft.Location = New Point(0, 0)
        pnlLeft.Name = "pnlLeft"
        pnlLeft.Size = New Size(184, 514)
        pnlLeft.TabIndex = 1
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Dock = DockStyle.Left
        MenuStrip1.Items.AddRange(New ToolStripItem() {AguaToolStripMenuItem, PegaToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.MdiWindowListItem = AguaToolStripMenuItem
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.RenderMode = ToolStripRenderMode.System
        MenuStrip1.Size = New Size(126, 514)
        MenuStrip1.Stretch = False
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"' 
        ' AguaToolStripMenuItem
        ' 
        AguaToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {ArrorToolStripMenuItem})
        AguaToolStripMenuItem.Name = "AguaToolStripMenuItem"
        AguaToolStripMenuItem.Size = New Size(113, 19)
        AguaToolStripMenuItem.Text = "Agua"' 
        ' ArrorToolStripMenuItem
        ' 
        ArrorToolStripMenuItem.Name = "ArrorToolStripMenuItem"
        ArrorToolStripMenuItem.Size = New Size(180, 22)
        ArrorToolStripMenuItem.Text = "Arror"' 
        ' PegaToolStripMenuItem
        ' 
        PegaToolStripMenuItem.Name = "PegaToolStripMenuItem"
        PegaToolStripMenuItem.Size = New Size(113, 19)
        PegaToolStripMenuItem.Text = "Pega"' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(114), CByte(76), CByte(157))
        ClientSize = New Size(819, 514)
        Controls.Add(pnlBottom)
        Controls.Add(pnlLeft)
        Font = New Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point)
        MainMenuStrip = MenuStrip1
        Name = "frmMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmMain"
        pnlLeft.ResumeLayout(False)
        pnlLeft.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents pnlBottom As Panel
    Friend WithEvents pnlLeft As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AguaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ArrorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PegaToolStripMenuItem As ToolStripMenuItem
End Class
