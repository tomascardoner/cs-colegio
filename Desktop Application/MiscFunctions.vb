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

    Friend Function EnviarEmailPorNETClient(ByRef Titular As Entidad, ByVal Asunto As String, ByVal CuerpoEnHTML As Boolean, ByVal Cuerpo As String, ByRef AdjuntoReporte As Reporte, ByVal AdjuntoNombre As String, ByVal AdjuntoArchivo As String, ByVal ForzarEnvio As Boolean) As Integer
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
        mail.IsBodyHtml = CuerpoEnHTML
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


    ''' <summary>
    ''' Verifica que una Entidad tenga todos los datos correctos para emitirle un Comprobante
    ''' </summary>
    ''' <param name="EntidadAVerificar">Especifica la Entidad a Verificar</param>
    ''' <param name="AnioLectivo">Año Lectivo</param>
    ''' <param name="FechaServicioDesde">Fecha de Inicio del Servicio a Facturar</param>
    ''' <param name="FechaServicioHasta">Fecha de Fin del Servicio a Facturar</param>
    ''' <param name="FechaExclusionEsError">Especifica si cuando la Entidad tiene exclusión de facturación, se genera error o simplemente se devuelve False</param>
    ''' <param name="CorreccionDescripcion">Por medio de este parámetro, se devuelve la leyenda de los errores encontrados</param>
    ''' <returns>Devuelve True si la Entidad tiene todos los datos correctos para facturar o False si no</returns>
    ''' <remarks></remarks>
    Friend Function Entidad_VerificarParaEmitirComprobante(ByRef EntidadAVerificar As Entidad, ByVal AnioLectivo As Integer, ByVal AgregarAlCurso As Boolean, ByVal FechaServicioDesde As Date, ByVal FechaServicioHasta As Date, ByVal FechaExclusionEsError As Boolean, ByRef CorreccionDescripcion As String) As Boolean
        ' El primer paso es verificar que la Entidad especificada, sea de tipo Alumno
        If EntidadAVerificar.TipoAlumno = False Then
            CorreccionDescripcion &= "No es una Entidad del tipo Alumno." & vbCrLf
        End If

        If AgregarAlCurso Then
            ' Verifico que el Alumno no esté cargado en algún Curso para el mismo Año Lectivo
            If EntidadAVerificar.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = AnioLectivo).Count > 0 Then
                CorreccionDescripcion &= "El Alumno ya está cargado en un curso para el Año Lectivo que se va a facturar." & vbCrLf
            End If
        Else
            ' Verifico que el Alumno no esté cargado en más de un Curso para el mismo Año Lectivo
            If EntidadAVerificar.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = AnioLectivo).Count > 1 Then
                CorreccionDescripcion &= "El Alumno está cargado en más de un curso para el Año Lectivo que se va a facturar." & vbCrLf
            End If
        End If

        ' Verifico a quién se le va a Facturar
        If EntidadAVerificar.EmitirFacturaA Is Nothing Then
            CorreccionDescripcion &= "No está especificado a quién se le factura." & vbCrLf
        Else
            If EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_ALUMNO Then
                ' Se le factura al Alumno, verifico que tenga los datos completos
                Entidad_VerificarDatosCompletosParaEmitirComprobante(EntidadAVerificar, "El Alumno", CorreccionDescripcion)
            End If

            If EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_PADRE Or EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                ' Se le factura al Padre (entre otros)
                If EntidadAVerificar.IDEntidadPadre Is Nothing Then
                    CorreccionDescripcion &= "Debe especificar el Padre para poder facturarle." & vbCrLf
                Else
                    Entidad_VerificarDatosCompletosParaEmitirComprobante(EntidadAVerificar.EntidadPadre, "El Padre", CorreccionDescripcion)
                End If
            End If

            If EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_MADRE Or EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                ' Se le factura a la Madre (entre otros)
                If EntidadAVerificar.IDEntidadMadre Is Nothing Then
                    CorreccionDescripcion &= "Debe especificar la Madre para poder facturarle." & vbCrLf
                Else
                    Entidad_VerificarDatosCompletosParaEmitirComprobante(EntidadAVerificar.EntidadMadre, "La Madre", CorreccionDescripcion)
                End If
            End If

            If EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or EntidadAVerificar.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                ' Se le factura a Otro (entre otros)
                If EntidadAVerificar.IDEntidadTercero Is Nothing Then
                    CorreccionDescripcion &= "Debe especificar el Tercero para poder facturarle." & vbCrLf
                Else
                    Entidad_VerificarDatosCompletosParaEmitirComprobante(EntidadAVerificar.EntidadTercero, "El tercero a quien se le va a facturar", CorreccionDescripcion)
                End If
            End If
        End If

        ' Si hay que corregir la Entidad, la agrego a la lista de Entidades a corregir
        If CorreccionDescripcion.Length > 0 Then
            CorreccionDescripcion = CorreccionDescripcion.Remove(CorreccionDescripcion.Length - vbCrLf.Length)
            Return False
        Else
            ' La Entidad está verificada, pero  falta verificar que no tenga exclusión de facturación
            ' Verifico primero la exclusión Desde
            If Not EntidadAVerificar.ExcluyeFacturaDesde Is Nothing Then
                ' Especifica exclusión Desde, así que la verifico
                If EntidadAVerificar.ExcluyeFacturaDesde.Value.CompareTo(FechaServicioHasta) < 0 Then
                    ' Está dentro de la exclusión Desde, así que verifico la exclusión Hasta
                    If EntidadAVerificar.ExcluyeFacturaHasta Is Nothing Then
                        ' No especifica exclusión Hasta, por ende, no se debe incluir en la Facturación
                        If FechaExclusionEsError Then
                            CorreccionDescripcion = "El Alumno especifica Fechas de Exclusión de Facturación y coinciden con la Fecha de esta Factura."
                            Return False
                        Else
                            CorreccionDescripcion = ""
                            Return False
                        End If
                    ElseIf EntidadAVerificar.ExcluyeFacturaHasta.Value.CompareTo(FechaServicioDesde) > 0 Then
                        ' Está dentro de la exclusión Hasta, por lo tanto, se excluye
                        If FechaExclusionEsError Then
                            CorreccionDescripcion = "El Alumno especifica Fechas de Exclusión de Facturación y coinciden con la Fecha de esta Factura."
                            Return False
                        Else
                            CorreccionDescripcion = ""
                            Return False
                        End If
                    Else
                        ' Está fuera de la exclusión
                        Return True
                    End If
                Else
                    ' Está fuera de la exclusión
                    Return True
                End If
            ElseIf Not EntidadAVerificar.ExcluyeFacturaHasta Is Nothing Then
                ' Especifica exclusión Hasta, así que la verifico
                If EntidadAVerificar.ExcluyeFacturaHasta.Value.CompareTo(FechaServicioDesde) > 0 Then
                    ' Está dentro de la exclusión, así que no lo agrego a la lista
                    If FechaExclusionEsError Then
                        CorreccionDescripcion = "El Alumno especifica Fechas de Exclusión de Facturación y coinciden con la Fecha de esta Factura."
                        Return False
                    Else
                        CorreccionDescripcion = ""
                        Return False
                    End If
                Else
                    ' Está fuera de la exclusión
                    Return True
                End If
            Else
                ' No especifica ninguna exclusión
                Return True
            End If
        End If
    End Function

    Private Sub Entidad_VerificarDatosCompletosParaEmitirComprobante(ByRef EntidadAVerificar As Entidad, ByVal SujetoDescripcion As String, ByRef CorreccionDescripcion As String)
        If EntidadAVerificar.IDCategoriaIVA Is Nothing Then
            CorreccionDescripcion &= String.Format("{1} no tiene especificada la Categoría de IVA.{0}", vbCrLf, SujetoDescripcion)
        End If

        If EntidadAVerificar.DocumentoNumero Is Nothing And EntidadAVerificar.FacturaDocumentoNumero Is Nothing Then
            CorreccionDescripcion &= String.Format("{1} no tiene especificado el Tipo y Número de Documento.{0}", vbCrLf, SujetoDescripcion)
        End If

        If My.Settings.Comprobante_RequiereDomicilioCompleto Then
            If EntidadAVerificar.DomicilioCalle1 Is Nothing Then
                CorreccionDescripcion &= String.Format("{1} no tiene especificado el Domicilio.{0}", vbCrLf, SujetoDescripcion)
            End If
        End If
    End Sub
End Module
