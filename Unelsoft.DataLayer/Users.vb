Imports System.Data.Entity

Public Class Users
    Inherits DbContext

    Private mConn As IDbConnection

    Public Sub New(conn As IDbConnection)
        mConn = conn
    End Sub

    Public Sub New()
        Me.New(EnvironmentObjects.Connection)
    End Sub

    Public Class User
        Public Property USR_Id As String
        Public Property USR_Name As String
        Public Property USR_Password As String

    End Class

    Public Property Users As DbSet(Of User)

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        MyBase.OnModelCreating(modelBuilder)
    End Sub
End Class
