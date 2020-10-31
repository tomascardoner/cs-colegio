Imports System.Net.Mail
Imports MimeKit

Module Email
    Friend Function GetSslOptionsEnumValue(ByVal value As Integer) As MailKit.Security.SecureSocketOptions
        Dim name As String = ""

        If [Enum].IsDefined(GetType(MailKit.Security.SecureSocketOptions), value) Then
            Return CType(value, MailKit.Security.SecureSocketOptions)
        Else
            Return MailKit.Security.SecureSocketOptions.None
        End If
    End Function


    ''' <summary>
    '''     Esta función, envía un e-mail utilizando el componente MailKit
    '''     ya que el componente incluído con .Net (System.Net.Mail) no sporta SSL implícito.
    '''     Envía a todos los recipientes especificados en las 3 listas de destinatarios
    '''     especificadas en los parámetros.
    ''' </summary>
    ''' <param name="destinatariosTo"></param>
    ''' <param name="destinatariosCC"></param>
    ''' <param name="destinatariosBcc"></param>
    ''' <param name="asunto"></param>
    ''' <param name="cuerpoEsHtml"></param>
    ''' <param name="cuerpo"></param>
    ''' <param name="adjuntoReporte"></param>
    ''' <param name="adjuntoNombre"></param>
    ''' <param name="adjuntoArchivo"></param>
    ''' <param name="forzarEnvio"></param>
    ''' <returns></returns>
    Friend Function Enviar(ByRef destinatariosTo As InternetAddressList, ByRef destinatariosCC As InternetAddressList, ByRef destinatariosBcc As InternetAddressList, ByVal asunto As String, ByVal cuerpoEsHtml As Boolean, ByVal cuerpo As String, ByRef adjuntoReporte As Reporte, ByVal adjuntoNombre As String, ByVal adjuntoArchivo As String, ByVal forzarEnvio As Boolean) As Boolean
        Dim mail As New MimeMessage()
        Dim bodyBuilder As New BodyBuilder()
        Dim smtp As New MailKit.Net.Smtp.SmtpClient()

        ' Establezco los recipientes
        mail.From.Add(New MailboxAddress(pEmailConfig.DisplayName, pEmailConfig.Address))
        mail.To.AddRange(destinatariosTo)
        mail.Cc.AddRange(destinatariosCC)
        mail.Bcc.AddRange(destinatariosBcc)

        ' Establezco las propiedades del Servidor SMTP
        smtp.Connect(pEmailConfig.SmtpServer, pEmailConfig.SmtpPort, GetSslOptionsEnumValue(pEmailConfig.SmtpSslOptions))
        smtp.Timeout = pEmailConfig.SmtpTimeout

        Dim Decrypter As New CS_Encrypt_TripleDES(CardonerSistemas.Constants.PUBLIC_ENCRYPTION_PASSWORD)
        Dim DecryptedPassword As String = ""
        If Not Decrypter.Decrypt(pEmailConfig.SmtpPassword, DecryptedPassword) Then
            MsgBox("La contraseña de e-mail (SMTP) especificada es incorrecta.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Return False
        End If
        smtp.Authenticate(New System.Net.NetworkCredential(pEmailConfig.SmtpUserName, DecryptedPassword))
        Decrypter = Nothing

        ' Establezco el contenido
        mail.Subject = asunto
        If cuerpoEsHtml Then
            bodyBuilder.HtmlBody = cuerpo
        Else
            bodyBuilder.TextBody = cuerpo
        End If

        ' Adjuntos
        If Not adjuntoReporte Is Nothing Then
            bodyBuilder.Attachments.Add(adjuntoNombre, adjuntoReporte.ReportObject.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat))
        End If
        If adjuntoArchivo <> "" Then
            bodyBuilder.Attachments.Add(adjuntoArchivo)
        End If

        mail.Body = bodyBuilder.ToMessageBody

        ' Envío el e-mail
        Try
            smtp.Send(mail)
            Return True
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al enviar el e-mail.")
            Return False
        End Try
    End Function

    ''' <summary>
    '''     Esta función, envía un e-mail utilizando el componente MailKit
    '''     ya que el componente incluído con .Net (System.Net.Mail) no sporta SSL implícito.
    '''     Envía a un recipiente por cada tipo (To, CC, BCC).
    ''' </summary>
    ''' <param name="destinatarioTo"></param>
    ''' <param name="destinatarioCC"></param>
    ''' <param name="destinatarioBcc"></param>
    ''' <param name="asunto"></param>
    ''' <param name="cuerpoEsHtml"></param>
    ''' <param name="cuerpo"></param>
    ''' <param name="adjuntoReporte"></param>
    ''' <param name="adjuntoNombre"></param>
    ''' <param name="adjuntoArchivo"></param>
    ''' <param name="forzarEnvio"></param>
    ''' <returns></returns>
    Friend Function Enviar(ByVal destinatarioTo As MailAddress, ByVal destinatarioCC As MailAddress, ByVal destinatarioBcc As MailAddress, ByVal asunto As String, ByVal cuerpoEsHtml As Boolean, ByVal cuerpo As String, ByRef adjuntoReporte As Reporte, ByVal adjuntoNombre As String, ByVal adjuntoArchivo As String, ByVal forzarEnvio As Boolean) As Boolean
        Dim destinatariosTo As New InternetAddressList
        Dim destinatariosCC As New InternetAddressList
        Dim destinatariosBcc As New InternetAddressList

        If Not destinatarioTo Is Nothing Then
            destinatariosTo.Add(New MailboxAddress(destinatarioTo.DisplayName, destinatarioTo.Address))
        End If
        If Not destinatarioCC Is Nothing Then
            destinatariosCC.Add(New MailboxAddress(destinatarioCC.DisplayName, destinatarioCC.Address))
        End If
        If Not destinatarioBcc Is Nothing Then
            destinatariosBcc.Add(New MailboxAddress(destinatarioBcc.DisplayName, destinatarioBcc.Address))
        End If

        Return Enviar(destinatariosTo, destinatariosCC, destinatariosBcc, asunto, cuerpoEsHtml, cuerpo, adjuntoReporte, adjuntoNombre, adjuntoArchivo, forzarEnvio)
    End Function

    Friend Function Enviar(ByRef entidadesTo As List(Of Entidad), ByRef entidadesCC As List(Of Entidad), ByRef entidadesBCC As List(Of Entidad), ByVal asunto As String, ByVal cuerpoEsHtml As Boolean, ByVal cuerpo As String, ByRef adjuntoReporte As Reporte, ByVal adjuntoNombre As String, ByVal adjuntoArchivo As String, ByVal forzarEnvio As Boolean) As Integer
        Dim destinatariosTo As New InternetAddressList
        Dim destinatariosCC As New InternetAddressList
        Dim destinatariosBcc As New InternetAddressList
        Dim mailCount As Integer = 0

        mailCount += AgregarRecipientes(entidadesTo, destinatariosTo, forzarEnvio)
        mailCount += AgregarRecipientes(entidadesCC, destinatariosCC, forzarEnvio)
        mailCount += AgregarRecipientes(entidadesBCC, destinatariosBcc, forzarEnvio)

        If mailCount = 0 Then
            Return 0
        Else
            If Enviar(destinatariosTo, destinatariosCC, destinatariosBcc, asunto, cuerpoEsHtml, cuerpo, adjuntoReporte, adjuntoNombre, adjuntoArchivo, forzarEnvio) Then
                Return mailCount
            Else
                Return 0
            End If
        End If
    End Function

    Private Function AgregarRecipientes(ByRef entidades As List(Of Entidad), ByRef destinatarios As InternetAddressList, ByVal forzarEnvio As Boolean) As Integer
        Dim destinatariosCount As Integer = 0

        For Each entidad As Entidad In entidades
            With entidad
                Select Case .ComprobanteEnviarEmail
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_CUALQUIERA
                        If Not .Email1 Is Nothing Then
                            destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email1))
                            destinatariosCount += 1
                        ElseIf Not .Email2 Is Nothing Then
                            destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email2))
                            destinatariosCount += 1
                        End If
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO
                        If forzarEnvio Then
                            If Not .Email1 Is Nothing Then
                                destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email1))
                                destinatariosCount += 1
                            End If
                            If Not .Email2 Is Nothing Then
                                destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email2))
                                destinatariosCount += 1
                            End If
                        End If
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_AMBAS
                        If Not .Email1 Is Nothing Then
                            destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email1))
                            destinatariosCount += 1
                        End If
                        If Not .Email2 Is Nothing Then
                            destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email2))
                            destinatariosCount += 1
                        End If
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL1
                        If Not .Email1 Is Nothing Then
                            destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email1))
                            destinatariosCount += 1
                        End If
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL2
                        If Not .Email2 Is Nothing Then
                            destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email2))
                            destinatariosCount += 1
                        End If
                End Select
            End With
        Next

        Return destinatariosCount
    End Function

End Module
