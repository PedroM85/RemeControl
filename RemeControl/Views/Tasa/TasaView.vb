Public Class TasaView
    Inherits ViewBase

    Private WithEvents oTasaABM As TasaABM

    Public Sub New()
        MyBase.New



        LoadGlobalCaptions()
    End Sub
    Public Sub LoadData()
        Dim oTasaData As TasaDataLayer = Nothing

        oTasaData = New TasaDataLayer

        'oTasaData.GetTasas()



        dgvView.DataSource = Nothing

        dgvView.DataSource = oTasaData.GetTasas

    End Sub

    Private Sub TasaView_Addnew() Handles MyBase.AddNew

        Cursor = Cursors.WaitCursor

        oTasaABM = New TasaABM

        oTasaABM.Caption = "asdasda"

        Me.Visible = False
        oTasaABM.Dock = DockStyle.Fill
        oMainForm.ShowView(oTasaABM)
        oMainForm.HideLeftPanel

        Cursor = Cursors.Arrow
    End Sub

    Private Sub oTasaABM_Close() Handles oTasaABM.Close
        Close_ABM()
    End Sub


    Public Sub LoadGlobalCaptions()

    End Sub

    Private Sub Close_ABM()
        oMainForm.ShowLeftPanel()

        oTasaABM.Dispose()
        oTasaABM = Nothing

        LoadData()
        Me.Visible = True
    End Sub

End Class
