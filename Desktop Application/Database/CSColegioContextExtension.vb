Imports System.Data.Entity
Imports System.Data.Entity.Core.EntityClient
Imports System.Data.Entity.Validation

Partial Public Class CSColegioContext
    Inherits DbContext

    Public Shared Property ConnectionString As String

    Public Sub New(ByVal UseCustomConnectionString As Boolean)
        MyBase.New(ConnectionString)
    End Sub

    Public Overrides Function SaveChanges() As Integer
        Try
            Return MyBase.SaveChanges()
        Catch ex As DbEntityValidationException
            Dim newException As New FormattedDbEntityValidationException(ex)
            Throw newException
        End Try
    End Function
End Class