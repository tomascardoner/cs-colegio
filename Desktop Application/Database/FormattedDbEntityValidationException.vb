Imports System.Data.Entity.Validation
Imports System.Text

Public Class FormattedDbEntityValidationException
    Inherits Exception

    Public Sub New(ByRef inEx As DbEntityValidationException)
        MyBase.New(Nothing, inEx)
    End Sub

    Public Overrides ReadOnly Property Message() As String
        Get
            Dim innerException As DbEntityValidationException = CType(MyBase.InnerException, DbEntityValidationException)

            If innerException IsNot Nothing Then
                Dim sb As New StringBuilder()

                sb.AppendLine()
                sb.AppendLine()
                For Each eve In innerException.EntityValidationErrors
                    sb.AppendLine(String.Format("La entidad de tipo ""{0}"" en el estado ""{1}"" tiene los siguientes errores de validación:", eve.Entry.Entity.GetType().FullName, eve.Entry.State))
                    For Each ve In eve.ValidationErrors
                        sb.AppendLine(String.Format("-- Propiedad: ""{0}"", Valor: ""{1}"", Error: ""{2}""", ve.PropertyName, eve.Entry.CurrentValues.GetValue(Of Object)(ve.PropertyName), ve.ErrorMessage))
                    Next
                Next
                sb.AppendLine()

                Return sb.ToString()
            End If

            Return MyBase.Message
        End Get
    End Property

End Class