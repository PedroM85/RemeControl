Public Class EnvironmentObjects

    Private Shared oConnection As IDbConnection

    Private Shared oTxIconMgr As System.Resources.ResourceManager

    Public Shared Property TransactionIconManager() As System.Resources.ResourceManager
        Get
            Return oTxIconMgr
        End Get
        Set(ByVal Value As System.Resources.ResourceManager)
            oTxIconMgr = Value
        End Set
    End Property

    Public Shared Property Connection() As IDbConnection
        Get
            Return oConnection
        End Get
        Set(ByVal Value As IDbConnection)
            If TypeOf (Value) Is Data.SqlClient.SqlConnection Then
                Unelsoft.DataAccessFactory.DALObjects.ProviderType = DataAccessFactory.DALObjects.DataProviderType.SqlClient
            Else
                Unelsoft.DataAccessFactory.DALObjects.ProviderType = DataAccessFactory.DALObjects.DataProviderType.OleDb
            End If
            oConnection = Value
        End Set
    End Property

    'Public Shared Property GlobalResources() As ewave.GlobalResourcesEngine.ResourceLoader
    '    Get
    '        Return mGlobalResources
    '    End Get
    '    Set(ByVal Value As ewave.GlobalResourcesEngine.ResourceLoader)
    '        mGlobalResources = Value
    '    End Set
    'End Property
End Class
