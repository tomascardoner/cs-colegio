﻿Public Class formComprobantesEnviarMail

#Region "Declarations"

    Private dbContext As New CSColegioContext(True)
    Private listComprobantes As List(Of GridDataRow)
    Private mCancelar As Boolean

    Private Class GridDataRow
        Public Property IDComprobante As Integer
        Public Property IDComprobanteTipo As Byte
        Public Property IDComprobanteLote As Integer
        Public Property ComprobanteTipoNombre As String
        Public Property NumeroCompleto As String
        Public Property IDEntidad As Integer
        Public Property ApellidoNombre As String
        Public Property ImporteTotal As Decimal
    End Class

#End Region

#Region "Form stuff"

    Private Sub SetAppearance()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.IMAGE_COMPROBANTES_32)
    End Sub

    Private Sub formComprobantesEnviarMail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetAppearance()
        buttonEnviar.Enabled = False
        pFillAndRefreshLists.ComprobanteLote(comboboxComprobanteLote, False, False)
        comboboxCantidad.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, "500", "200", "150", "100", "50", "20", "10", "5", "1"})
        comboboxCantidad.SelectedIndex = 3
    End Sub

    Private Sub formComprobantesEnviarMail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbContext.Dispose()
    End Sub
#End Region

#Region "Mostrar y leer datos"

    Private Sub RefreshData()
        Dim ComprobanteLoteActual As ComprobanteLote

        Me.Cursor = Cursors.WaitCursor

        Try

            If comboboxComprobanteLote.SelectedValue IsNot Nothing Then
                ComprobanteLoteActual = CType(comboboxComprobanteLote.SelectedItem, ComprobanteLote)

                ' Muestro los comprobantes que cumplan las siguientes condiciones:
                '   - pertenezcan al Lote seleccionado
                '   - no estén anulados
                '   - no hayan sido enviados por e-mail anteriormente
                '   - son de emisión electrónica
                '   - tienen una C.A.E. asignado
                '   - el titular tiene asignada una dirección de e-mail
                '   - el titular no especifica que no se le envíen los e-mails
                listComprobantes = (From c In dbContext.Comprobante
                                    Join cl In dbContext.ComprobanteLote On c.IDComprobanteLote Equals cl.IDComprobanteLote
                                    Join ct In dbContext.ComprobanteTipo On c.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                    Join e In dbContext.Entidad On c.IDEntidad Equals e.IDEntidad
                                    Where c.IDComprobanteLote = ComprobanteLoteActual.IDComprobanteLote AndAlso c.IDUsuarioAnulacion Is Nothing AndAlso c.IDUsuarioEnvioEmail Is Nothing AndAlso ct.EmisionElectronica AndAlso (c.CAE IsNot Nothing) AndAlso (Not (e.Email1 Is Nothing AndAlso e.Email2 Is Nothing)) AndAlso (Not e.ComprobanteEnviarEmail = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO)
                                    Order By ct.Nombre, c.NumeroCompleto
                                    Select New GridDataRow With {.IDComprobante = c.IDComprobante, .IDComprobanteTipo = c.IDComprobanteTipo, .IDComprobanteLote = c.IDComprobanteLote.Value, .ComprobanteTipoNombre = ct.Nombre, .NumeroCompleto = c.NumeroCompleto, .IDEntidad = c.IDEntidad, .ApellidoNombre = c.ApellidoNombre, .ImporteTotal = c.ImporteTotal1}).ToList

                Select Case listComprobantes.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Comprobantes para mostrar.")
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Comprobante.")
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0} Comprobantes.", listComprobantes.Count)
                End Select
            Else
                listComprobantes = Nothing
            End If

            datagridviewComprobantes.AutoGenerateColumns = False
            datagridviewComprobantes.DataSource = listComprobantes

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener la lista de Comprobantes.")
        End Try

        Me.Cursor = Cursors.Default

        If listComprobantes Is Nothing Then
            buttonEnviar.Enabled = False
        Else
            buttonEnviar.Enabled = (listComprobantes.Count > 0)
        End If
    End Sub

#End Region

#Region "Controls behavior"
    Private Sub CambiarLote() Handles comboboxComprobanteLote.SelectedIndexChanged
        RefreshData()
    End Sub

    Private Sub Enviar_Click(sender As Object, e As EventArgs) Handles buttonEnviar.Click
        If listComprobantes.Count > 0 Then
            If pEmailConfig.SendMaxPerHour > 0 Then
                If comboboxCantidad.SelectedIndex = 0 Then
                    If MsgBox(String.Format("Está por enviar Todos los Comprobantes por e-mail.{2}Tenga en cuenta que por cuestiones de seguridad (para evitar el spam), los servidores actuales no permiten enviar más de {1} e-mails por hora.{2}{2}¿Desea continuar de todos modos?", comboboxCantidad.SelectedText, pEmailConfig.SendMaxPerHour, vbCrLf), CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                Else
                    If CShort(comboboxCantidad.Text) >= pEmailConfig.SendMaxPerHour Then
                        If MsgBox(String.Format("Está por enviar {0} e-mails.{2}Tenga en cuenta que por cuestiones de seguridad (para evitar el spam), los servidores actuales no permiten enviar más de {1} e-mails por hora.{2}{2}¿Desea continuar de todos modos?", comboboxCantidad.Text, pEmailConfig.SendMaxPerHour, vbCrLf), CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If
                End If
            End If
            EnviarComprobantes()
        End If
    End Sub

    Private Sub Cancelar_Click() Handles buttonCancelar.Click
        mCancelar = True
    End Sub
#End Region

#Region "Extra stuff"

    Private Sub EnviarComprobantes()
        Dim GridDataRowActual As GridDataRow
        Dim ComprobanteActual As Comprobante
        Dim mailer As New Email.Mailer()
        Dim IDComprobanteTipo As Byte
        Dim ReporteActual As New Reporte
        Dim Result As Integer
        Dim MailCount As Integer = 0

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        MostrarOcultarEstado(True)
        mCancelar = False
        textboxStatus.Text = "Iniciando el envío de Comprobantes..."
        Application.DoEvents()

        If Not mailer.SmtpConnect Then
            MostrarOcultarEstado(False)
            Me.Cursor = Cursors.Default
            Return
        End If

        For Each RowActual As DataGridViewRow In datagridviewComprobantes.Rows
            ' Hago que la grilla vaya mostrando la fila que se está procesando
            datagridviewComprobantes.CurrentCell = RowActual.Cells(0)
            GridDataRowActual = CType(RowActual.DataBoundItem, GridDataRow)

            ComprobanteActual = dbContext.Comprobante.Find(GridDataRowActual.IDComprobante)
            If ComprobanteActual IsNot Nothing Then
                If (ComprobanteActual.Entidad.Email1 IsNot Nothing) OrElse (ComprobanteActual.Entidad.Email2 IsNot Nothing) Then
                    If IDComprobanteTipo <> ComprobanteActual.IDComprobanteTipo Then
                        IDComprobanteTipo = ComprobanteActual.IDComprobanteTipo
                        ReporteActual = New Reporte
                        If Not ReporteActual.Open(pGeneralConfig.ReportsPath & "\" & ComprobanteActual.ComprobanteTipo.ReporteNombre) Then
                            mailer.SmtpDisconnect()
                            RefreshData()
                            MostrarOcultarEstado(False)
                            Me.Cursor = Cursors.Default
                            Return
                        End If
                        If Not ReporteActual.SetDatabaseConnection(pDatabase.Datasource, pDatabase.InitialCatalog, pDatabase.UserId, pDatabase.Password) Then
                            mailer.SmtpDisconnect()
                            RefreshData()
                            MostrarOcultarEstado(False)
                            Me.Cursor = Cursors.Default
                            Return
                        End If
                    End If
                    ReporteActual.RecordSelectionFormula = "{Comprobante.IDComprobante} = " & ComprobanteActual.IDComprobante
                    ReporteActual.ReportObject.Refresh()

                    Dim Asunto As String = String.Format(pComprobanteConfig.SendEmailSubject, ComprobanteActual.ComprobanteTipo.NombreConLetra, GridDataRowActual.NumeroCompleto)
                    Dim Cuerpo As String = String.Format(pComprobanteConfig.SendEmailBody, vbCrLf) & String.Format(pEmailConfig.Signature, vbCrLf)
                    Dim AdjuntoNombre As String = String.Format("{0}-{1}.pdf", ComprobanteActual.ComprobanteTipo.Sigla.TrimEnd, ComprobanteActual.NumeroCompleto)

                    textboxStatus.AppendText(vbCrLf & String.Format("Enviando {0} N° {1} a {2}...", ComprobanteActual.ComprobanteTipo.Nombre, ComprobanteActual.NumeroCompleto, ComprobanteActual.Entidad.ApellidoNombre))

                    Result = mailer.SendEmail(New List(Of Entidad)({ComprobanteActual.Entidad}), New List(Of Entidad), New List(Of Entidad), Asunto, False, Cuerpo, ReporteActual, AdjuntoNombre, String.Empty, False)
                    Select Case Result
                        Case 0
                            MsgBox("No hay una dirección de e-mail para la Entidad.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                            mailer.SmtpDisconnect()
                            RefreshData()
                            MostrarOcultarEstado(False)
                            Me.Cursor = Cursors.Default
                            Return
                        Case -1
                            mailer.SmtpDisconnect()
                            RefreshData()
                            MostrarOcultarEstado(False)
                            Me.Cursor = Cursors.Default
                            Return
                    End Select
                    MailCount += Result

                    dbContext.Comprobante.Attach(ComprobanteActual)

                    ComprobanteActual.IDUsuarioEnvioEmail = pUsuario.IDUsuario
                    ComprobanteActual.FechaHoraEnvioEmail = DateTime.Now

                    dbContext.SaveChanges()

                    textboxStatus.AppendText("OK")

                    If comboboxCantidad.SelectedIndex > 0 AndAlso MailCount >= CShort(comboboxCantidad.Text) Then
                        Exit For
                    End If
                Else
                    textboxStatus.AppendText(vbCrLf & String.Format("El Titular de {0} N° {1} ({2}) no especifica e-mail...", ComprobanteActual.ComprobanteTipo.Nombre, ComprobanteActual.Numero, ComprobanteActual.Entidad.ApellidoNombre))
                End If
            End If

            ' Verifico que no se cancele el Envío
            Application.DoEvents()
            If mCancelar Then
                Exit For
            End If
        Next
        If mCancelar Then
            MsgBox(String.Format("Se ha cancelado el envío de e-mails.{1}Se enviaron {0} e-mails.", MailCount, vbCrLf), MsgBoxStyle.Information, My.Application.Info.Title)
        Else
            MsgBox(String.Format("Se han enviado {0} e-mails.", MailCount, vbCrLf), MsgBoxStyle.Information, My.Application.Info.Title)
        End If
        mailer.SmtpDisconnect()
        RefreshData()
        MostrarOcultarEstado(False)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MostrarOcultarEstado(ByVal Mostrar As Boolean)
        buttonEnviar.Visible = Not Mostrar
        buttonCancelar.Visible = Mostrar
        If Mostrar Then
            datagridviewComprobantes.Height = 270
            progressbarStatus.Maximum = listComprobantes.Count
            progressbarStatus.Value = 0
            textboxStatus.Text = ""
        Else
            datagridviewComprobantes.Height = 408
        End If
        groupboxStatus.Visible = Mostrar
    End Sub

#End Region

End Class