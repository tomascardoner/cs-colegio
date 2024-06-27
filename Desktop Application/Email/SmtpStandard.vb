Imports MailKit.Net

Namespace Email
    Module SmtpStandard

        Private Function GetSslOptionsEnumValue(value As Integer) As MailKit.Security.SecureSocketOptions
            If [Enum].IsDefined(GetType(MailKit.Security.SecureSocketOptions), value) Then
                Return CType(value, MailKit.Security.SecureSocketOptions)
            Else
                Return MailKit.Security.SecureSocketOptions.None
            End If
        End Function

        Friend Function Connect(logPath As String, logFileName As String, smtpClient As Smtp.SmtpClient) As Boolean
            Try
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Conexión al servidor SMTP: inicio")
                smtpClient.Connect(pEmailConfig.SmtpServer, pEmailConfig.SmtpPort, GetSslOptionsEnumValue(pEmailConfig.SmtpSslOptions))
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Conexión al servidor SMTP: fin")
                Return True
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al conectar al servidor SMTP.")
                Return False
            End Try
        End Function

        Friend Function Authenticate(logPath As String, logFileName As String, smtpClient As Smtp.SmtpClient) As Boolean
            Try
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Autenticación al servidor SMTP: inicio")
                smtpClient.Authenticate(New Net.NetworkCredential(pEmailConfig.SmtpUserName, pEmailConfig.SmtpPassword))
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Autenticación al servidor SMTP: fin")
                Return True
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al autenticar la conexión al servidor SMTP.")
                Return False
            End Try
        End Function
    End Module
End Namespace