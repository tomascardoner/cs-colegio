Imports System.Net.Mail
Imports MimeKit

Namespace Email
    Module Sender

        Friend Function Enviar(destinatariosTo As InternetAddressList, destinatariosCC As InternetAddressList, destinatariosBcc As InternetAddressList, ByVal asunto As String, ByVal cuerpoEsHtml As Boolean, ByVal cuerpo As String, adjuntoReporte As Reporte, ByVal adjuntoNombre As String, ByVal adjuntoArchivo As String, ByVal forzarEnvio As Boolean) As Boolean
            Dim mail As MimeMessage
            Dim bodyBuilder As BodyBuilder
            Dim smtpClient As MailKit.Net.Smtp.SmtpClient
            Dim logPath As String = String.Empty
            Dim logFileName As String = String.Empty

            ' Log settings
            If pEmailConfig.LogEnabled Then
                logPath = CardonerSistemas.Files.ProcessFolderName(pEmailConfig.LogFolder)
                logFileName = CardonerSistemas.Files.ProcessFilename(pEmailConfig.LogFileName)
            End If

            ' Creo el mensaje
            mail = New MimeMessage() With {
                .Subject = asunto
            }

            ' Establezco los recipientes
            mail.From.Add(New MailboxAddress(pEmailConfig.DisplayName, pEmailConfig.Address))
            mail.To.AddRange(destinatariosTo)
            mail.Cc.AddRange(destinatariosCC)
            mail.Bcc.AddRange(destinatariosBcc)

            ' Adjuntos
            bodyBuilder = New BodyBuilder()
            If adjuntoReporte IsNot Nothing Then
                bodyBuilder.Attachments.Add(adjuntoNombre, adjuntoReporte.ReportObject.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat))
            End If
            If adjuntoArchivo <> String.Empty Then
                bodyBuilder.Attachments.Add(adjuntoArchivo)
            End If

            ' Cuerpo del mensaje
            If cuerpoEsHtml Then
                bodyBuilder.HtmlBody = cuerpo
            Else
                bodyBuilder.TextBody = cuerpo
            End If
            mail.Body = bodyBuilder.ToMessageBody

            ' Establezco la conexión al Servidor SMTP
            CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, StrDup(20, "="))
            smtpClient = New MailKit.Net.Smtp.SmtpClient With {
                .Timeout = pEmailConfig.SmtpTimeout
            }
            If pEmailConfig.SmtpServerUseOAuth20 Then
                Dim accessToken As String = String.Empty
                If Not SmtpOAuth20.Authorize(logPath, logFileName, accessToken) Then
                    Return False
                End If
                If Not SmtpOAuth20.Connect(logPath, logFileName, smtpClient) Then
                    Return False
                End If
                If Not SmtpOAuth20.Authenticate(logPath, logFileName, smtpClient, accessToken) Then
                    Return False
                End If
            Else
                If Not SmtpStandard.Connect(logPath, logFileName, smtpClient) Then
                    Return False
                End If
                If Not SmtpStandard.Authenticate(logPath, logFileName, smtpClient) Then
                    Return False
                End If
            End If

            ' Envío el e-mail
            Try
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Envío del e-mail al servidor SMTP: inicio")
                smtpClient.Send(mail)
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Envío del e-mail al servidor SMTP: fin")
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, $"E-mail enviado - Destinatario 1: {destinatariosTo.FirstOrDefault()?.ToString()} - Asunto: {asunto} - Adjuntos: {bodyBuilder.Attachments.Count}")
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al enviar el e-mail.")
                Return False
            End Try

            ' Cierro la conexión al servidor SMTP
            Try
                CS_FileLog.WriteLine(logPath, logFileName, LogEntryType.Information, "Desconexión al servidor SMTP: inicio")
                smtpClient.Disconnect(True)
                smtpClient.Dispose()
                CS_FileLog.WriteLine(logPath, logFileName, LogEntryType.Information, "Desconexión al servidor SMTP: fin")
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al desconectar al servidor SMTP.")
                Return False
            End Try

            Return True
        End Function

        Friend Function Enviar(ByVal destinatarioTo As MailAddress, ByVal destinatarioCC As MailAddress, ByVal destinatarioBcc As MailAddress, ByVal asunto As String, ByVal cuerpoEsHtml As Boolean, ByVal cuerpo As String, ByRef adjuntoReporte As Reporte, ByVal adjuntoNombre As String, ByVal adjuntoArchivo As String, ByVal forzarEnvio As Boolean) As Boolean
            Dim destinatariosTo As New InternetAddressList
            Dim destinatariosCC As New InternetAddressList
            Dim destinatariosBcc As New InternetAddressList

            If destinatarioTo IsNot Nothing Then
                destinatariosTo.Add(New MailboxAddress(destinatarioTo.DisplayName, destinatarioTo.Address))
            End If
            If destinatarioCC IsNot Nothing Then
                destinatariosCC.Add(New MailboxAddress(destinatarioCC.DisplayName, destinatarioCC.Address))
            End If
            If destinatarioBcc IsNot Nothing Then
                destinatariosBcc.Add(New MailboxAddress(destinatarioBcc.DisplayName, destinatarioBcc.Address))
            End If

            Return Enviar(destinatariosTo, destinatariosCC, destinatariosBcc, asunto, cuerpoEsHtml, cuerpo, adjuntoReporte, adjuntoNombre, adjuntoArchivo, forzarEnvio)
        End Function

        Friend Function Enviar(ByRef entidadesTo As List(Of Entidad), ByRef entidadesCC As List(Of Entidad), ByRef entidadesBCC As List(Of Entidad), ByVal asunto As String, ByVal cuerpoEsHtml As Boolean, ByVal cuerpo As String, ByRef adjuntoReporte As Reporte, ByVal adjuntoNombre As String, ByVal adjuntoArchivo As String, ByVal forzarEnvio As Boolean) As Integer
            Dim destinatariosTo As New InternetAddressList
            Dim destinatariosCC As New InternetAddressList
            Dim destinatariosBcc As New InternetAddressList
            Dim mailCount As Integer

            mailCount += Recipients.Add(entidadesTo, destinatariosTo, forzarEnvio)
            mailCount += Recipients.Add(entidadesCC, destinatariosCC, forzarEnvio)
            mailCount += Recipients.Add(entidadesBCC, destinatariosBcc, forzarEnvio)

            If mailCount = 0 Then
                Return 0
            Else
                If Enviar(destinatariosTo, destinatariosCC, destinatariosBcc, asunto, cuerpoEsHtml, cuerpo, adjuntoReporte, adjuntoNombre, adjuntoArchivo, forzarEnvio) Then
                    Return mailCount
                Else
                    Return -1
                End If
            End If
        End Function

    End Module
End Namespace
