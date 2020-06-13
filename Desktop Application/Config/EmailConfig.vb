Public Class EmailConfig
    Public Property DisplayName As String
    Public Property Address As String
    Public Property ReplyToAddress As String
    Public Property Signature As String
    Public Property SmtpServer As String
    Public Property SmtpUserName As String
    Public Property SmtpPassword As String
    Public Property SmtpPort As Integer
    Public Property SmtpUseSsl As Boolean
    Public Property SmtpTimeout As Integer
    Public Property SendMethod As String
    Public Property SendMaxPerHour As Integer
    Public Property DeliveryFailedSubject As String
    Public Property DeliveryFailedErrorText As String
    Public Property DeliveryFailedRejectedAddressPreviousText As String
    Public Property DeliveryFailedSenderAddress As String
End Class