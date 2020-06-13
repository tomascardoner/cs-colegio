Public Class ComprobanteConfig
    Public Property RequiereDomicilioCompleto As String
    Public Property SendEmailSubject As String
    Public Property SendEmailBody As String
    Public Property SendEmailMethod As String

    Friend Property RequiereDomicilioCompletoAsBoolean As Boolean
        Get
            Boolean.TryParse(RequiereDomicilioCompleto, RequiereDomicilioCompletoAsBoolean)
        End Get
        Set(value As Boolean)
            RequiereDomicilioCompleto = value.ToString()
        End Set
    End Property
End Class
