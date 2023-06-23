Public Class EWTerminalConfigDialog

    Public Sub New()
        MyBase.New
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AddTerminalConfigCtrl
    End Sub


    Private sTerminalId As String = String.Empty
    Private ctlConfig1 As New Unelsoft.TerminalConfig.ConfigControl

    Private Sub EWTerminalConfigDialog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With ctlConfig1
            .DataLayer = New TerminalConfig.DataLayer(EnvironmentObjects.Framework.Connection)
            .TerminalId = sTerminalId
        End With
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        ctlConfig1.SaveData()
        DialogResult = DialogResult.OK
    End Sub

    Public WriteOnly Property TerminalId As String
        Set(value As String)
            sTerminalId = value
        End Set
    End Property

    Public Property Dataload() As Unelsoft.TerminalConfig.ConfigControl.DataLoadMode
        Get
            Return ctlConfig1.DataLoad
        End Get
        Set(value As Unelsoft.TerminalConfig.ConfigControl.DataLoadMode)
            ctlConfig1.DataLoad = value
        End Set
    End Property

    Private Sub AddTerminalConfigCtrl()
        '
        'ctlConfig1
        '
        Me.ctlConfig1.BackColor = System.Drawing.Color.FromArgb(CType(252, Byte), CType(249, Byte), CType(242, Byte))
        Me.ctlConfig1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ctlConfig1.ForeColor = System.Drawing.Color.Black
        Me.ctlConfig1.Location = New System.Drawing.Point(16, 50)
        Me.ctlConfig1.Name = "ctlConfig1"
        Me.ctlConfig1.Size = New System.Drawing.Size(424, 280)
        Me.ctlConfig1.TabIndex = 110


        Me.Controls.Add(Me.ctlConfig1)

        Me.ctlConfig1.BringToFront()
    End Sub
End Class