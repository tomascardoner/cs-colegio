Public Class AfipWebServicesConfig
    Public Property CertificadoHomologacion As String
    Public Property CertificadoProduccion As String
    Public Property ModoHomologacion As String
    Public Property ClavePrivada As String
    Public Property TtlTicketRequerimientoAcceso As String
    Public Property LogFolder As String
    Public Property LogFileName As String
    Public Property LogEnabled As String

    Friend Property ModoHomologacionAsBoolean As Boolean
        Get
            Boolean.TryParse(ModoHomologacion, ModoHomologacionAsBoolean)
        End Get
        Set(value As Boolean)
            ModoHomologacion = value.ToString()
        End Set
    End Property

    Friend Property TtlTicketRequerimientoAccesoAsInteger As Integer
        Get
            Integer.TryParse(TtlTicketRequerimientoAcceso, TtlTicketRequerimientoAccesoAsInteger)
        End Get
        Set(value As Integer)
            TtlTicketRequerimientoAcceso = value.ToString()
        End Set
    End Property

    Friend Property LogEnabledAsBoolean As Boolean
        Get
            Boolean.TryParse(LogEnabled, LogEnabledAsBoolean)
        End Get
        Set(value As Boolean)
            LogEnabled = value.ToString()
        End Set
    End Property

End Class
