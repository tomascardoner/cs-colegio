Imports System.Net.Mail

Module MiscFunctions
    Friend Sub PreviewCrystalReport(ByRef ReporteActual As Reporte, ByVal WindowText As String)
        Dim VisorReporte As New formReportesVisor

        formMDIMain.Cursor = Cursors.WaitCursor

        CS_Form.MDIChild_PositionAndSizeToFit(CType(formMDIMain, Form), CType(VisorReporte, Form))
        With VisorReporte
            .Text = WindowText
            .CRViewerMain.ReportSource = ReporteActual.ReportObject
            .Show()
            If .WindowState = FormWindowState.Minimized Then
                .WindowState = FormWindowState.Normal
            End If
            .Focus()
        End With

        formMDIMain.Cursor = Cursors.Default
    End Sub

    Friend Sub UserLoggedIn()
        LoadPermisos()

        formMDIMain.menuitemDebug.Visible = (pUsuario.IDUsuario = 1)

        Select Case pUsuario.Genero
            Case Constantes.ENTIDAD_GENERO_MASCULINO
                formMDIMain.labelUsuarioNombre.Image = My.Resources.Resources.IMAGE_USUARIO_HOMBRE_16
            Case Constantes.ENTIDAD_GENERO_FEMENINO
                formMDIMain.labelUsuarioNombre.Image = My.Resources.Resources.IMAGE_USUARIO_MUJER_16
            Case Else
                formMDIMain.labelUsuarioNombre.Image = Nothing
        End Select
        formMDIMain.labelUsuarioNombre.Text = pUsuario.Descripcion

        My.Application.Log.WriteEntry(String.Format("El Usuario '{0}' ha iniciado sesión.", pUsuario.Nombre), TraceEventType.Information)
    End Sub

    Friend Function LoadParameters() As Boolean
        Try
            Using dbcontext As New CSColegioContext(True)
                pParametros = dbcontext.Parametro.ToList
            End Using
            Return True
        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al cargar los Parámetros desde la base de datos.")
            Return False
        End Try
    End Function

    Friend Function LoadPermisos() As Boolean
        Try
            Using dbcontext As New CSColegioContext(True)
                pPermisos = dbcontext.UsuarioGrupoPermiso.ToList
            End Using
            Return True
        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al cargar los Permisos del Usuario.")
            Return False
        End Try
    End Function

    Friend Function EnviarEmailPorNETClient(ByRef Titular As Entidad, ByVal Asunto As String, ByVal Cuerpo As String, ByRef ReporteActual As Reporte, ByVal AdjuntoNombre As String, ByVal ForzarEnvio As Boolean) As Integer
        Dim mail As New MailMessage()
        Dim smtp As New SmtpClient()
        Dim MailCount As Integer = 0

        ' Establezco los recipientes
        mail.From = New MailAddress(My.Settings.Email_Address, My.Settings.Email_DisplayName)

        Select Case Titular.ComprobanteEnviarEmail
            Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_CUALQUIERA
                If Not Titular.Email1 Is Nothing Then
                    mail.To.Add(New MailAddress(Titular.Email1, Titular.ApellidoNombre))
                    MailCount += 1
                Else
                    If Not Titular.Email2 Is Nothing Then
                        mail.To.Add(New MailAddress(Titular.Email2, Titular.ApellidoNombre))
                        MailCount += 1
                    End If
                End If
            Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO
                If ForzarEnvio Then
                    If Not Titular.Email1 Is Nothing Then
                        mail.To.Add(New MailAddress(Titular.Email1, Titular.ApellidoNombre))
                        MailCount += 1
                    End If
                    If Not Titular.Email2 Is Nothing Then
                        mail.To.Add(New MailAddress(Titular.Email2, Titular.ApellidoNombre))
                        MailCount += 1
                    End If
                End If
            Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_AMBAS
                If Not Titular.Email1 Is Nothing Then
                    mail.To.Add(New MailAddress(Titular.Email1, Titular.ApellidoNombre))
                    MailCount += 1
                End If
                If Not Titular.Email2 Is Nothing Then
                    mail.To.Add(New MailAddress(Titular.Email2, Titular.ApellidoNombre))
                    MailCount += 1
                End If
            Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL1
                If Not Titular.Email1 Is Nothing Then
                    mail.To.Add(New MailAddress(Titular.Email1, Titular.ApellidoNombre))
                    MailCount += 1
                End If
            Case Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL2
                If Not Titular.Email2 Is Nothing Then
                    mail.To.Add(New MailAddress(Titular.Email2, Titular.ApellidoNombre))
                    MailCount += 1
                End If
        End Select

        ' Establezco el contenido
        mail.Subject = Asunto
        mail.Body = Cuerpo

        ' Establezco las opciones del Servidor SMTP
        smtp.Host = My.Settings.Email_SMTP_Server
        smtp.EnableSsl = My.Settings.Email_SMTP_UseSSL
        smtp.Port = My.Settings.Email_SMTP_Port
        smtp.Timeout = My.Settings.Email_SMTP_Timeout

        Dim Decrypter As New CS_Encrypt_TripleDES(Constantes.ENCRYPTION_PASSWORD)
        smtp.Credentials = New System.Net.NetworkCredential(My.Settings.Email_SMTP_Username, Decrypter.Decrypt(My.Settings.Email_SMTP_Password))
        Decrypter = Nothing

        ' Attachments
        mail.Attachments.Add(New System.Net.Mail.Attachment(ReporteActual.ReportObject.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), AdjuntoNombre))

        ' Envío el e-mail
        Try
            smtp.Send(mail)
            Return MailCount
        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al enviar el e-mail.")
            Return -1
        End Try

    End Function

    Friend Function EnviarEmailPorMSOutlook(ByRef Titular As Entidad, ByVal Asunto As String, ByVal Cuerpo As String, ByRef ReporteActual As Reporte, ByVal AdjuntoNombre As String, ByVal ForzarEnvio As Boolean) As Integer
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

    Friend Function EnviarEmailPorCrystalReportsMAPI(ByRef Titular As Entidad, ByVal Asunto As String, ByVal Cuerpo As String, ByRef ReporteActual As Reporte, ByVal AdjuntoNombre As String, ByVal ForzarEnvio As Boolean) As Integer
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
            CS_Error.ProcessError(ex, "Error al enviar el e-mail.")
            Return -1   'False

        End Try
    End Function
End Module
