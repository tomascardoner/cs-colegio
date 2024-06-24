Imports System.Net.Mail
Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Util.Store
Imports System.Threading
Imports MimeKit

Module Email
    Friend Function GetSslOptionsEnumValue(ByVal value As Integer) As MailKit.Security.SecureSocketOptions
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
    Friend Function Enviar(destinatariosTo As InternetAddressList, destinatariosCC As InternetAddressList, destinatariosBcc As InternetAddressList, ByVal asunto As String, ByVal cuerpoEsHtml As Boolean, ByVal cuerpo As String, adjuntoReporte As Reporte, ByVal adjuntoNombre As String, ByVal adjuntoArchivo As String, ByVal forzarEnvio As Boolean) As Boolean
        Dim mail As New MimeMessage()
        Dim bodyBuilder As New BodyBuilder()
        Dim smtp As New MailKit.Net.Smtp.SmtpClient()

        ' Establezco los recipientes
        mail.From.Add(New MailboxAddress(pEmailConfig.DisplayName, pEmailConfig.Address))
        mail.To.AddRange(destinatariosTo)
        mail.Cc.AddRange(destinatariosCC)
        mail.Bcc.AddRange(destinatariosBcc)

        ' Establezco la conexión al Servidor SMTP
        smtp.Timeout = pEmailConfig.SmtpTimeout
        If pEmailConfig.SmtpServerUseOAuth20 Then
            Try
                ' Authorize And get credentials
                Dim scopes As IEnumerable(Of String) = {"https://mail.google.com/"}
                Dim credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromFile(pEmailConfig.GoogleApiSecretFile).Secrets,
                scopes,
                pEmailConfig.SmtpUserName,
                CancellationToken.None,
                New FileDataStore(My.Application.Info.DirectoryPath, True)).Result

                smtp.Connect(pEmailConfig.SmtpServer, pEmailConfig.SmtpPort, True)
                Dim oauth2 = New MailKit.Security.SaslMechanismOAuth2(pEmailConfig.SmtpUserName, credential.Token.AccessToken)
                smtp.Authenticate(oauth2)

            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al autorizar la conexión a la API de Google.")
                Return False
            End Try
        Else
            Try
                smtp.Connect(pEmailConfig.SmtpServer, pEmailConfig.SmtpPort, GetSslOptionsEnumValue(pEmailConfig.SmtpSslOptions))
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al conectar al servidor SMTP.")
                Return False
            End Try

            Dim Decrypter As New CS_Encrypt_TripleDES(CardonerSistemas.Constants.PublicEncryptionPassword)
            Dim DecryptedPassword As String = ""
            If Not Decrypter.Decrypt(pEmailConfig.SmtpPassword, DecryptedPassword) Then
                MessageBox.Show("La contraseña de e-mail (SMTP) especificada es incorrecta.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
            Try
                smtp.Authenticate(New System.Net.NetworkCredential(pEmailConfig.SmtpUserName, DecryptedPassword))
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al iniciar sesión en el servidor SMTP.")
                Return False
            End Try
            Decrypter = Nothing
        End If

        ' Establezco el contenido
        mail.Subject = asunto
        If cuerpoEsHtml Then
            bodyBuilder.HtmlBody = cuerpo
        Else
            bodyBuilder.TextBody = cuerpo
        End If

        ' Adjuntos
        If adjuntoReporte IsNot Nothing Then
            bodyBuilder.Attachments.Add(adjuntoNombre, adjuntoReporte.ReportObject.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat))
        End If
        If adjuntoArchivo <> String.Empty Then
            bodyBuilder.Attachments.Add(adjuntoArchivo)
        End If

        mail.Body = bodyBuilder.ToMessageBody

        ' Envío el e-mail
        Try
            smtp.Send(mail)
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al enviar el e-mail.")
            Return False
        End Try

        ' Cierro la conexión al servidor SMTP
        Try
            smtp.Disconnect(True)
            Return True
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al desconectar al servidor SMTP.")
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

        mailCount += AgregarRecipientes(entidadesTo, destinatariosTo, forzarEnvio)
        mailCount += AgregarRecipientes(entidadesCC, destinatariosCC, forzarEnvio)
        mailCount += AgregarRecipientes(entidadesBCC, destinatariosBcc, forzarEnvio)

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

    Private Function AgregarRecipientes(ByRef entidades As List(Of Entidad), ByRef destinatarios As InternetAddressList, ByVal forzarEnvio As Boolean) As Integer
        Dim destinatariosCount As Integer = 0

        For Each entidad As Entidad In entidades
            With entidad
                Select Case .ComprobanteEnviarEmail
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_CUALQUIERA
                        If .Email1 IsNot Nothing Then
                            destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email1))
                            destinatariosCount += 1
                        ElseIf .Email2 IsNot Nothing Then
                            destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email2))
                            destinatariosCount += 1
                        End If
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO
                        If forzarEnvio Then
                            If .Email1 IsNot Nothing Then
                                destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email1))
                                destinatariosCount += 1
                            End If
                            If .Email2 IsNot Nothing Then
                                destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email2))
                                destinatariosCount += 1
                            End If
                        End If
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_AMBAS
                        If .Email1 IsNot Nothing Then
                            destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email1))
                            destinatariosCount += 1
                        End If
                        If .Email2 IsNot Nothing Then
                            destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email2))
                            destinatariosCount += 1
                        End If
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL1
                        If .Email1 IsNot Nothing Then
                            destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email1))
                            destinatariosCount += 1
                        End If
                    Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL2
                        If .Email2 IsNot Nothing Then
                            destinatarios.Add(New MailboxAddress(.ApellidoNombre, .Email2))
                            destinatariosCount += 1
                        End If
                End Select
            End With
        Next

        Return destinatariosCount
    End Function

End Module
