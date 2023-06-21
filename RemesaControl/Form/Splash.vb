Public Class Splash

    Public Sub New()
        MyBase.New
        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        Dim ver() As String = Application.ProductVersion.Split(".")

        lblVersion.text = String.Format("Versión: {0}.{1}    (build {2})", ver)
    End Sub


End Class
