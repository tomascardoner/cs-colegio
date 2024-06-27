Imports MimeKit

Namespace Email
    Module Recipients

        Friend Function Add(ByRef entidades As List(Of Entidad), ByRef destinatarios As InternetAddressList, forzarEnvio As Boolean) As Integer
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
End Namespace
