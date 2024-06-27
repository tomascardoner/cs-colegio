Imports System.Net.Mail
Imports MimeKit

Namespace Email
    Module Sender

        Friend Function EnviarSimple(destinatariosTo As InternetAddressList, destinatariosCC As InternetAddressList, destinatariosBcc As InternetAddressList, ByVal asunto As String, ByVal cuerpoEsHtml As Boolean, ByVal cuerpo As String, adjuntoReporte As Reporte, ByVal adjuntoNombre As String, ByVal adjuntoArchivo As String, ByVal forzarEnvio As Boolean) As Boolean
            Dim mailer As New Mailer()

            If Not mailer.SmtpConnect() Then
                Return False
            End If

            If Not mailer.SendEmail(destinatariosTo, destinatariosCC, destinatariosBcc, asunto, cuerpoEsHtml, cuerpo, adjuntoReporte, adjuntoNombre, adjuntoArchivo, forzarEnvio) Then
                Return False
            End If

            mailer.SmtpDisconnect()

            Return True
        End Function

        Friend Function EnviarSimple(ByVal destinatarioTo As MailAddress, ByVal destinatarioCC As MailAddress, ByVal destinatarioBcc As MailAddress, ByVal asunto As String, ByVal cuerpoEsHtml As Boolean, ByVal cuerpo As String, ByRef adjuntoReporte As Reporte, ByVal adjuntoNombre As String, ByVal adjuntoArchivo As String, ByVal forzarEnvio As Boolean) As Boolean
            Dim mailer As New Mailer()

            If Not mailer.SmtpConnect() Then
                Return False
            End If

            If Not mailer.SendEmail(destinatarioTo, destinatarioCC, destinatarioBcc, asunto, cuerpoEsHtml, cuerpo, adjuntoReporte, adjuntoNombre, adjuntoArchivo, forzarEnvio) Then
                Return False
            End If

            mailer.SmtpDisconnect()

            Return True
        End Function

        Friend Function EnviarSimple(ByRef entidadesTo As List(Of Entidad), ByRef entidadesCC As List(Of Entidad), ByRef entidadesBCC As List(Of Entidad), ByVal asunto As String, ByVal cuerpoEsHtml As Boolean, ByVal cuerpo As String, ByRef adjuntoReporte As Reporte, ByVal adjuntoNombre As String, ByVal adjuntoArchivo As String, ByVal forzarEnvio As Boolean) As Integer
            Dim mailer As New Mailer()
            Dim mailCount As Integer

            If Not mailer.SmtpConnect() Then
                Return -1
            End If

            mailCount = mailer.SendEmail(entidadesTo, entidadesCC, entidadesBCC, asunto, cuerpoEsHtml, cuerpo, adjuntoReporte, adjuntoNombre, adjuntoArchivo, forzarEnvio)

            mailer.SmtpDisconnect()

            Return mailCount
        End Function

    End Module
End Namespace
