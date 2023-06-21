Public Class EnvironmentObjects
    Private Shared oApp As EWFramework

    Public Shared Property Framework() As EWFramework
        Get
            Return oApp
        End Get
        Set(value As EWFramework)
            oApp = value
        End Set
    End Property
End Class
