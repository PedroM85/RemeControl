Public Class EnvironmentObjects


    Private Shared mConnection As IDbConnection
    Private Shared mUser As AccessController.User
    Private Shared mParam As AccessController.Parameters
    'Private Shared mPublisher As ewave.Publisher.PublishEngine
    Private Shared mSiteId As String
    Private Shared mTerminalId As String

    Private Shared mConnString As String
    'Private Shared mCnHelper As ConnectionHelper

    Public Shared Property Connection() As IDbConnection
        Get
            Return mConnection
        End Get
        Set(ByVal Value As IDbConnection)
            mConnection = Value
        End Set
    End Property

    Public Shared Property User() As AccessController.User
        Get
            Return mUser
        End Get
        Set(ByVal Value As AccessController.User)
            mUser = Value
        End Set
    End Property

    Public Shared Property Parameters() As AccessController.Parameters
        Get
            Return mParam
        End Get
        Set(ByVal Value As AccessController.Parameters)
            mParam = Value
        End Set
    End Property

    'Public Shared ReadOnly Property Publisher() As ewave.Publisher.PublishEngine
    '    Get
    '        Return mPublisher
    '    End Get
    'End Property

    'Public Shared Sub InitializePublisher()
    '    mPublisher = New ewave.Publisher.PublishEngine
    '    mPublisher.Start(mConnection, Parameters.ToHashTable)
    'End Sub

    Public Shared Property SiteId() As String
        Get
            Return mSiteId
        End Get
        Set(ByVal value As String)
            mSiteId = value
        End Set
    End Property

    Public Shared Property TerminalId() As String
        Get
            Return mTerminalId
        End Get
        Set(ByVal value As String)
            mTerminalId = value
        End Set
    End Property


    Public Shared ReadOnly Property SystemUserId() As String
        Get
            Return "system"
        End Get
    End Property

    Public Shared Property ConnectionString() As String
        Get
            Return mConnString
        End Get
        Set(ByVal value As String)
            mConnString = value
        End Set
    End Property


    'Public Shared Property CnHelper() As ConnectionHelper
    '    Get
    '        If mCnHelper Is Nothing AndAlso mConnString IsNot Nothing Then
    '            mCnHelper = New ConnectionHelper(mConnString)
    '        End If
    '        Return mCnHelper
    '    End Get
    '    Set(ByVal value As ConnectionHelper)
    '        mCnHelper = value
    '    End Set
    'End Property

End Class
