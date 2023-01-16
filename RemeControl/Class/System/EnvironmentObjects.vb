Public Class EnvironmentObjects

    Private Shared oApp As MgrFramework
    Public Shared Property Framework As MgrFramework
        Get
            Return oApp
        End Get
        Set(value As MgrFramework)
            oApp = value
        End Set
    End Property
End Class
