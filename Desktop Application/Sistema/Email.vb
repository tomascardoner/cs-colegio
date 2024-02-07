Imports System.Net.Mail
Imports System.Security.Cryptography.X509Certificates
Imports System.Text
Imports MimeKit

Module Email
    Friend Function GetSslOptionsEnumValue(ByVal value As Integer) As MailKit.Security.SecureSocketOptions
        If [Enum].IsDefined(GetType(MailKit.Security.SecureSocketOptions), value) Then
            Return CType(value, MailKit.Security.SecureSocketOptions)
        Else
            Return MailKit.Security.SecureSocketOptions.None
        End If
    End Function


    Public Function MySslCertificateValidationCallback(sender As Object, certificate As X509Certificate, chain As X509Chain, sslPolicyErrors As Net.Security.SslPolicyErrors) As Boolean
        ' If there are no errors, then everything went smoothly.
#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
        If sslPolicyErrors = sslPolicyErrors.None Then
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
            Return True
        End If

        ' Note MailKit will always pass the host name string as the `sender` argument.
        Dim host As String = CStr(sender)

#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
        If (sslPolicyErrors And sslPolicyErrors.RemoteCertificateNotAvailable) <> 0 Then
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
            ' This means that the remote certificate Is unavailable. Notify the user and return false.
            MessageBox.Show(String.Format("The SSL certificate was not available for {0}", host), My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

#Disable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
        If (sslPolicyErrors And sslPolicyErrors.RemoteCertificateNameMismatch) <> 0 Then
#Enable Warning BC42025 ' Access of shared member, constant member, enum member or nested type through an instance
            ' This means that the server's SSL certificate did not match the host name that we are trying to connect to.
            Dim certificate2 As X509Certificate2 = CType(certificate, X509Certificate2)
            Dim certificateName As String

            If certificate2 Is Nothing Then
                certificateName = certificate.Subject
            Else
                certificateName = certificate2.GetNameInfo(X509NameType.SimpleName, False)
            End If

            MessageBox.Show($"The Common Name for the SSL certificate did not match {host}. Instead, it was {certificateName}.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End If

        ' The only other errors left are chain errors.
        Dim sb As New StringBuilder

        ' The first element's certificate will be the server's SSL certificate (and will match the `certificate` argument)
        ' while the last element in the chain will typically either be the Root Certificate Authority's certificate -or- it
        ' will be a non-authoritative self-signed certificate that the server admin created. 
        For Each element In chain.ChainElements
            ' Each element in the chain will have its own status list. If the status list Is empty, it means that the
            ' certificate itself did Not contain any errors.
            If element.ChainElementStatus.Length = 0 Then
                Continue For
            End If

            sb.Append($"- {element.Certificate.Subject}{vbNewLine}")
            For Each er In element.ChainElementStatus
                ' error.StatusInformation` contains a human-readable error string while `error.Status` Is the corresponding enum value.
                sb.Append($"   - {er.StatusInformation}{vbNewLine}")
            Next
        Next

        MessageBox.Show($"The SSL certificate for the server could not be validated for the following reasons:{vbNewLine}{sb.ToString()}", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Return False
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

        ' Establezco las propiedades y la conexión al Servidor SMTP
        'smtp.ServerCertificateValidationCallback = AddressOf MySslCertificateValidationCallback
        smtp.Timeout = pEmailConfig.SmtpTimeout
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
