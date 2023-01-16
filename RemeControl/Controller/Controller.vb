Public MustInherit Class Controller

    Private oFormMain As FormMain

    Public MustOverride Sub HandleKey(e As KeyEventArgs)

    Public Overridable ReadOnly Property StepNumber() As Integer
        Get
            Return -1
        End Get
    End Property

    Public Overridable ReadOnly Property BasicKeysEnabled() As Boolean
        Get
            Return True
        End Get
    End Property

    Public Overridable ReadOnly Property CancelTrasactionAllowed() As Boolean
        Get
            Return True
        End Get
    End Property
End Class
