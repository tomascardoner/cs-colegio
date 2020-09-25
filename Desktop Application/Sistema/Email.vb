Imports System.Net.Mail
Imports AegisImplicitMail

Module Email

    Friend Function EnviarPorAimClient(ByVal DestinatarioTo As MailAddress, ByVal DestinatarioCC As MailAddress, ByVal DestinatarioBCC As MailAddress, ByVal Asunto As String, ByVal CuerpoEnHTML As Boolean, ByVal Cuerpo As String, ByRef AdjuntoReporte As Reporte, ByVal AdjuntoNombre As String, ByVal AdjuntoArchivo As String, ByVal ForzarEnvio As Boolean) As Boolean
        Dim mail As New MimeMailMessage()
        Dim smtp As New MimeMailer()

        ' Establezco los recipientes
        mail.From = New MimeMailAddress(pEmailConfig.Address, pEmailConfig.DisplayName)

        If Not DestinatarioTo Is Nothing Then
            mail.To.Add(DestinatarioTo)
        End If
        If Not DestinatarioCC Is Nothing Then
            mail.CC.Add(DestinatarioCC)
        End If
        If Not DestinatarioBCC Is Nothing Then
            mail.Bcc.Add(DestinatarioBCC)
        End If

        ' Establezco el contenido
        mail.Subject = Asunto
        mail.IsBodyHtml = CuerpoEnHTML
        mail.Body = Cuerpo

        ' Establezco las propiedades del Servidor SMTP
        smtp.Host = pEmailConfig.SmtpServer
        smtp.EnableImplicitSsl = True
        smtp.SslType = pEmailConfig.SmtpSslTypeValue
        smtp.Port = pEmailConfig.SmtpPort
        smtp.Timeout = pEmailConfig.SmtpTimeout
        smtp.AuthenticationMode = AuthenticationType.Base64

        Dim Decrypter As New CS_Encrypt_TripleDES(CardonerSistemas.Constants.PUBLIC_ENCRYPTION_PASSWORD)
        Dim DecryptedPassword As String = ""
        If Not Decrypter.Decrypt(pEmailConfig.SmtpPassword, DecryptedPassword) Then
            MsgBox("La contraseña de e-mail (SMTP) especificada es incorrecta.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Return False
        End If
        smtp.Credentials = New System.Net.NetworkCredential(pEmailConfig.SmtpUserName, DecryptedPassword)
        Decrypter = Nothing

        ' Attachments
        If Not AdjuntoReporte Is Nothing Then
            mail.Attachments.Add(CType(New System.Net.Mail.Attachment(AdjuntoReporte.ReportObject.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), AdjuntoNombre), MimeAttachment))
        End If
        If AdjuntoArchivo <> "" Then
            mail.Attachments.Add(New MimeAttachment(AdjuntoArchivo))
        End If

        ' Envío el e-mail
        Try
            smtp.Send(mail)
            Return True
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al enviar el e-mail.")
            Return False
        End Try
    End Function

    Friend Function EnviarPorNetClient(ByVal DestinatarioTo As MailAddress, ByVal DestinatarioCC As MailAddress, ByVal DestinatarioBCC As MailAddress, ByVal Asunto As String, ByVal CuerpoEnHTML As Boolean, ByVal Cuerpo As String, ByRef AdjuntoReporte As Reporte, ByVal AdjuntoNombre As String, ByVal AdjuntoArchivo As String, ByVal ForzarEnvio As Boolean) As Boolean
        Dim mail As New MailMessage()
        Dim smtp As New SmtpClient()

        ' Establezco los recipientes
        mail.From = New MailAddress(pEmailConfig.Address, pEmailConfig.DisplayName)

        If Not DestinatarioTo Is Nothing Then
            mail.To.Add(DestinatarioTo)
        End If
        If Not DestinatarioCC Is Nothing Then
            mail.CC.Add(DestinatarioCC)
        End If
        If Not DestinatarioBCC Is Nothing Then
            mail.Bcc.Add(DestinatarioBCC)
        End If

        ' Establezco el contenido
        mail.Subject = Asunto
        mail.IsBodyHtml = CuerpoEnHTML
        mail.Body = Cuerpo

        ' Establezco las propiedades del Servidor SMTP
        smtp.Host = pEmailConfig.SmtpServer
        smtp.Port = pEmailConfig.SmtpPort
        smtp.Timeout = pEmailConfig.SmtpTimeout

        Dim Decrypter As New CS_Encrypt_TripleDES(CardonerSistemas.Constants.PUBLIC_ENCRYPTION_PASSWORD)
        Dim DecryptedPassword As String = ""
        If Not Decrypter.Decrypt(pEmailConfig.SmtpPassword, DecryptedPassword) Then
            MsgBox("La contraseña de e-mail (SMTP) especificada es incorrecta.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Return False
        End If
        smtp.Credentials = New System.Net.NetworkCredential(pEmailConfig.SmtpUserName, DecryptedPassword)
        Decrypter = Nothing

        ' Attachments
        If Not AdjuntoReporte Is Nothing Then
            mail.Attachments.Add(New System.Net.Mail.Attachment(AdjuntoReporte.ReportObject.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), AdjuntoNombre))
        End If
        If AdjuntoArchivo <> "" Then
            mail.Attachments.Add(New System.Net.Mail.Attachment(AdjuntoArchivo))
        End If

        ' Envío el e-mail
        Try
            smtp.Send(mail)
            Return True
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al enviar el e-mail.")
            Return False
        End Try
    End Function

    Friend Function EnviarAEntidadesPorNetClient(ByRef listEntidadesTo As List(Of Entidad), ByRef listEntidadesCC As List(Of Entidad), ByRef listEntidadesBCC As List(Of Entidad), ByVal Asunto As String, ByVal CuerpoEnHTML As Boolean, ByVal Cuerpo As String, ByRef AdjuntoReporte As Reporte, ByVal AdjuntoNombre As String, ByVal AdjuntoArchivo As String, ByVal ForzarEnvio As Boolean) As Integer
        Dim mail As New MailMessage()
        Dim smtp As New SmtpClient()
        Dim MailCount As Integer = 0

        ' Establezco los recipientes
        mail.From = New MailAddress(pEmailConfig.Address, pEmailConfig.DisplayName)

        ' Destinatarios - To
        MailCount += EnviarPorNetClientAgregarDestinatarios(listEntidadesTo, mail.To, ForzarEnvio)

        ' Destinatarios - CC
        MailCount += EnviarPorNetClientAgregarDestinatarios(listEntidadesCC, mail.CC, ForzarEnvio)

        ' Destinatarios - BCC
        MailCount += EnviarPorNetClientAgregarDestinatarios(listEntidadesBCC, mail.Bcc, ForzarEnvio)

        If MailCount = 0 Then
            Return MailCount
        End If

        ' Establezco el contenido
        mail.Subject = Asunto
        mail.IsBodyHtml = CuerpoEnHTML
        mail.Body = Cuerpo

        ' Establezco las opciones del Servidor SMTP
        smtp.Host = pEmailConfig.SmtpServer
        smtp.Port = pEmailConfig.SmtpPort
        smtp.Timeout = pEmailConfig.SmtpTimeout

        Dim Decrypter As New CS_Encrypt_TripleDES(CardonerSistemas.Constants.PUBLIC_ENCRYPTION_PASSWORD)
        Dim DecryptedPassword As String = ""

        If Not Decrypter.Decrypt(pEmailConfig.SmtpPassword, DecryptedPassword) Then
            MsgBox("La contraseña de e-mail (SMTP) especificada es incorrecta.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Return -1
        End If
        smtp.Credentials = New System.Net.NetworkCredential(pEmailConfig.SmtpUserName, DecryptedPassword)
        Decrypter = Nothing

        ' Attachments
        If Not AdjuntoReporte Is Nothing Then
            mail.Attachments.Add(New System.Net.Mail.Attachment(AdjuntoReporte.ReportObject.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), AdjuntoNombre))
        End If
        If AdjuntoArchivo <> "" Then
            mail.Attachments.Add(New System.Net.Mail.Attachment(AdjuntoArchivo))
        End If

        ' Envío el e-mail
        Try
            smtp.Send(mail)
            Return MailCount
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al enviar el e-mail.")
            Return -1
        End Try
    End Function

    Private Function EnviarPorNetClientAgregarDestinatarios(ByRef listDestinatarios As List(Of Entidad), ByRef colMailDestinatarios As System.Net.Mail.MailAddressCollection, ByVal ForzarEnvio As Boolean) As Integer
        Dim DestinatariosCount As Integer = 0

        For Each Destinatario As Entidad In listDestinatarios
            With Destinatario
                Select Case .ComprobanteEnviarEmail
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_CUALQUIERA
                        If Not .Email1 Is Nothing Then
                            colMailDestinatarios.Add(New MailAddress(.Email1, .ApellidoNombre))
                            DestinatariosCount += 1
                        ElseIf Not .Email2 Is Nothing Then
                            colMailDestinatarios.Add(New MailAddress(.Email2, .ApellidoNombre))
                            DestinatariosCount += 1
                        End If
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO
                        If ForzarEnvio Then
                            If Not .Email1 Is Nothing Then
                                colMailDestinatarios.Add(New MailAddress(.Email1, .ApellidoNombre))
                                DestinatariosCount += 1
                            End If
                            If Not .Email2 Is Nothing Then
                                colMailDestinatarios.Add(New MailAddress(.Email2, .ApellidoNombre))
                                DestinatariosCount += 1
                            End If
                        End If
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_AMBAS
                        If Not .Email1 Is Nothing Then
                            colMailDestinatarios.Add(New MailAddress(.Email1, .ApellidoNombre))
                            DestinatariosCount += 1
                        End If
                        If Not .Email2 Is Nothing Then
                            colMailDestinatarios.Add(New MailAddress(.Email2, .ApellidoNombre))
                            DestinatariosCount += 1
                        End If
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL1
                        If Not .Email1 Is Nothing Then
                            colMailDestinatarios.Add(New MailAddress(.Email1, .ApellidoNombre))
                            DestinatariosCount += 1
                        End If
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL2
                        If Not .Email2 Is Nothing Then
                            colMailDestinatarios.Add(New MailAddress(.Email2, .ApellidoNombre))
                            DestinatariosCount += 1
                        End If
                End Select
            End With
        Next

        Return DestinatariosCount
    End Function

    Friend Function EnviarPorMSOutlook(ByRef Titular As Entidad, ByVal Asunto As String, ByVal Cuerpo As String, ByRef ReporteActual As Reporte, ByVal AdjuntoNombre As String, ByVal ForzarEnvio As Boolean) As Integer
        Dim mail As New CS_Office_Outlook_LateBinding.MailItem

        If (Not Titular.Email1 Is Nothing) And (Not Titular.Email2 Is Nothing) Then
            mail.To = Titular.Email1 & "; " & Titular.Email2
        ElseIf Not Titular.Email1 Is Nothing Then
            mail.To = Titular.Email1
        ElseIf Not Titular.Email2 Is Nothing Then
            mail.To = Titular.Email2
        End If

        mail.Subject = Asunto
        mail.Body = Cuerpo

        mail.Attachments.Add(New CS_Office_Outlook_LateBinding.Attachment(ReporteActual.ReportObject.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), AdjuntoNombre))

        Return -1 'CS_Office_Outlook_LateBinding.SendMail(My.Settings.Email_Address, mail)
    End Function

    Friend Function EnviarPorCrystalReportsMapi(ByRef Titular As Entidad, ByVal Asunto As String, ByVal Cuerpo As String, ByRef ReporteActual As Reporte, ByVal AdjuntoNombre As String, ByVal ForzarEnvio As Boolean) As Integer
        'Preparo las opciones del mail
        Dim mailOpts As New CrystalDecisions.Shared.MicrosoftMailDestinationOptions
        If Not Titular.Email1 Is Nothing Then
            mailOpts.MailToList = Titular.Email1
        ElseIf Not Titular.Email2 Is Nothing Then
            mailOpts.MailToList = Titular.Email2
        End If
        mailOpts.MailSubject = Asunto
        mailOpts.MailMessage = Cuerpo

        'Ahora preparo las opciones de exportación
        Dim expopt As New CrystalDecisions.Shared.ExportOptions
        expopt.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.MicrosoftMail
        expopt.ExportDestinationOptions = mailOpts
        expopt.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat

        Try
            ReporteActual.ReportObject.Export(expopt)
            Return -1   'True

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al enviar el e-mail.")
            Return -1   'False

        End Try
    End Function

End Module
