Public Class EmailConfig
    Public Property DisplayName As String
    Public Property Address As String
    Public Property ReplyToAddress As String
    Public Property Signature As String
    Public Property SmtpServer As String
    Public Property SmtpUserName As String
    Public Property SmtpPassword As String
    Public Property SmtpPort As String
    Public Property SmtpUseSsl As String
    Public Property SmtpTimeout As String
    Public Property SendMethod As String
    Public Property SendMaxPerHour As String

    Friend Property SmtpPortAsInteger As Integer
        Get
            Integer.TryParse(SmtpPort, SmtpPortAsInteger)
        End Get
        Set(value As Integer)
            SmtpPort = value.ToString()
        End Set
    End Property

    Friend Property SmtpUseSslAsBoolean As Boolean
        Get
            Boolean.TryParse(SmtpUseSsl, SmtpUseSslAsBoolean)
        End Get
        Set(value As Boolean)
            SmtpUseSsl = IIf(value, 0, 1).ToString()
        End Set
    End Property

    Friend Property SmtpTimeoutAsInteger As Integer
        Get
            Integer.TryParse(SmtpTimeout, SmtpTimeoutAsInteger)
        End Get
        Set(value As Integer)
            SmtpTimeout = value.ToString()
        End Set
    End Property

    Friend Property SendMaxPerHourAsInteger As Integer
        Get
            Integer.TryParse(SendMaxPerHour, SendMaxPerHourAsInteger)
        End Get
        Set(value As Integer)
            SendMaxPerHour = value.ToString()
        End Set
    End Property

End Class