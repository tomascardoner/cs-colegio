﻿Public Class formComunicacionesEnviarMail

#Region "Declarations"
    Private dbContext As New CSColegioContext(True)
    Private listEntidades As List(Of Entidad)
    Private mCancelar As Boolean
#End Region

#Region "Form stuff"
    Private Sub formComunicacionesEnviarMail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buttonEnviar.Enabled = False
        pFillAndRefreshLists.Comunicacion(comboboxComunicacion, False, False)
        comboboxCantidad.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, "500", "200", "150", "100", "50", "20", "10", "5", "1"})
        comboboxCantidad.SelectedIndex = 3

        checkboxTipoPersonalColegio.Checked = True
        checkboxTipoDocente.Checked = True
        checkboxTipoAlumno.Checked = True
        checkboxTipoFamiliar.Checked = True
        checkboxTipoProveedor.Checked = False
    End Sub

    Private Sub formComunicacionesEnviarMail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbContext.Dispose()
    End Sub
#End Region

#Region "Load and Set Data"
    Private Sub RefreshData()
        Dim ComunicacionActual As Comunicacion

        Me.Cursor = Cursors.WaitCursor

        Try

            If Not comboboxComunicacion.SelectedValue Is Nothing Then

                ComunicacionActual = CType(comboboxComunicacion.SelectedItem, Comunicacion)

                ' Muestro las Entidades a las que no se les ha enviado la Comunicación seleccionada

                If checkboxTipoPersonalColegio.Checked And checkboxTipoDocente.Checked And checkboxTipoAlumno.Checked And checkboxTipoFamiliar.Checked And checkboxTipoProveedor.Checked Then
                    listEntidades = (From e In dbContext.Entidad
                                     Group Join ComunicacionEntidad In dbContext.ComunicacionEntidad On e.IDEntidad Equals ComunicacionEntidad.IDEntidad Into Entidad_ComunicacionEntidad_Join = Group
                                     From ComunicacionEntidad In Entidad_ComunicacionEntidad_Join.DefaultIfEmpty()
                                     Where e.TipoFamiliar And e.EsActivo And (Not e.ComprobanteEnviarEmail = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO) And (Not (e.Email1 Is Nothing And e.Email2 Is Nothing)) And ComunicacionEntidad Is Nothing
                                     Order By e.ApellidoNombre
                                     Select e).ToList
                Else
                    listEntidades = (From e In dbContext.Entidad
                                     Group Join ComunicacionEntidad In dbContext.ComunicacionEntidad On e.IDEntidad Equals ComunicacionEntidad.IDEntidad Into Entidad_ComunicacionEntidad_Join = Group
                                     From ComunicacionEntidad In Entidad_ComunicacionEntidad_Join.DefaultIfEmpty()
                                     Where e.EsActivo And ((checkboxTipoPersonalColegio.Checked And e.TipoPersonalColegio) Or (checkboxTipoDocente.Checked And e.TipoDocente) Or (checkboxTipoAlumno.Checked And e.TipoAlumno) Or (checkboxTipoFamiliar.Checked And e.TipoFamiliar) Or (checkboxTipoProveedor.Checked And e.TipoProveedor)) And (Not e.ComprobanteEnviarEmail = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO) And (Not (e.Email1 Is Nothing And e.Email2 Is Nothing)) And ComunicacionEntidad Is Nothing
                                     Order By e.ApellidoNombre
                                     Select e).ToList
                End If

                Select Case listEntidades.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Entidades para mostrar.")
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Entidad.")
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0} Entidades.", listEntidades.Count)
                End Select
            Else
                listEntidades = Nothing
            End If

            datagridviewEntidades.AutoGenerateColumns = False
            datagridviewEntidades.DataSource = listEntidades

        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al obtener la lista de Comprobantes.")
        End Try

        Me.Cursor = Cursors.Default

        If listEntidades Is Nothing Then
            buttonEnviar.Enabled = False
        Else
            buttonEnviar.Enabled = (listEntidades.Count > 0)
        End If
    End Sub

#End Region

#Region "Controls behavior"
    Private Sub CambiarComunicacion() Handles comboboxComunicacion.SelectedIndexChanged
        RefreshData()
    End Sub

    Private Sub CambiarTipoEntidad() Handles checkboxTipoPersonalColegio.CheckedChanged, checkboxTipoDocente.CheckedChanged, checkboxTipoAlumno.CheckedChanged, checkboxTipoFamiliar.CheckedChanged, checkboxTipoProveedor.CheckedChanged
        RefreshData()
    End Sub

    Private Sub Enviar_Click() Handles buttonEnviar.Click
        If listEntidades.Count > 0 Then
            If My.Settings.Email_MaxPerHour > 0 Then
                If comboboxCantidad.SelectedIndex = 0 Then
                    If MsgBox(String.Format("Está por enviar la Comunicación a Todas las Entidades por e-mail.{2}Tenga en cuenta que por cuestiones de seguridad (para evitar el spam), los servidores actuales no permiten enviar más de {1} e-mails por hora.{2}{2}¿Desea continuar de todos modos?", comboboxCantidad.SelectedText, My.Settings.Email_MaxPerHour, vbCrLf), CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                Else
                    If CShort(comboboxCantidad.Text) >= My.Settings.Email_MaxPerHour Then
                        If MsgBox(String.Format("Está por enviar {0} e-mails.{2}Tenga en cuenta que por cuestiones de seguridad (para evitar el spam), los servidores actuales no permiten enviar más de {1} e-mails por hora.{2}{2}¿Desea continuar de todos modos?", comboboxCantidad.Text, My.Settings.Email_MaxPerHour, vbCrLf), CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If
                End If
            End If
            EnviarComunicaciones()
        End If
    End Sub

    Private Sub Cancelar_Click() Handles buttonCancelar.Click
        mCancelar = True
    End Sub
#End Region

#Region "Extra stuff"
    Private Sub EnviarComunicaciones()
        Dim EntidadActual As Entidad
        Dim Result As Integer
        Dim MailCount As Integer = 0
        Dim ComunicacionActual As Comunicacion

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        MostrarOcultarEstado(True)
        mCancelar = False
        textboxStatus.Text = "Iniciando el envío de Comunicaciones..."

        ComunicacionActual = CType(comboboxComunicacion.SelectedItem, Comunicacion)

        For Each RowActual As DataGridViewRow In datagridviewEntidades.Rows
            ' Hago que la grilla vaya mostrando la fila que se está procesando
            datagridviewEntidades.CurrentCell = RowActual.Cells(0)
            Application.DoEvents()
            EntidadActual = CType(RowActual.DataBoundItem, Entidad)

            If Not EntidadActual Is Nothing Then
                textboxStatus.AppendText(vbCrLf & String.Format("Enviando Comunicación a {0}...", EntidadActual.ApellidoNombre))

                Select Case My.Settings.LoteComprobantes_EnviarEmail_Metodo
                    Case Constantes.EMAIL_CLIENT_NETDLL
                        Result = MiscFunctions.EnviarEmailPorNETClient(EntidadActual, ComunicacionActual.Asunto, ComunicacionActual.CuerpoMensajeEsHTML, ComunicacionActual.CuerpoMensaje, Nothing, "", ComunicacionActual.ArchivoAdjunto, False)
                        If Result = -1 Then
                            Exit For
                        End If
                        MailCount += Result
                    Case Constantes.EMAIL_CLIENT_MSOUTLOOK
                        'Result = MiscFunctions.EnviarEmailPorMSOutlook(ComprobanteActual.Entidad, Asunto, Cuerpo, ReporteActual, AdjuntoNombre, False)
                        If Result = -1 Then
                            Exit For
                        End If
                        MailCount += Result
                    Case Constantes.EMAIL_CLIENT_CRYSTALREPORTSMAPI
                        'Result = MiscFunctions.EnviarEmailPorCrystalReportsMAPI(ComprobanteActual.Entidad, Asunto, Cuerpo, ReporteActual, AdjuntoNombre, False)
                        If Result = -1 Then
                            Exit For
                        End If
                        MailCount += Result
                End Select

                Dim ComunicacionEntidadNueva As New ComunicacionEntidad
                ComunicacionEntidadNueva.IDComunicacion = ComunicacionActual.IDComunicacion
                ComunicacionEntidadNueva.IDEntidad = EntidadActual.IDEntidad
                ComunicacionEntidadNueva.IDUsuarioEnvioEmail = pUsuario.IDUsuario
                ComunicacionEntidadNueva.FechaHoraEnvioEmail = DateTime.Now
                dbContext.ComunicacionEntidad.Add(ComunicacionEntidadNueva)

                dbContext.SaveChanges()

                textboxStatus.AppendText("OK")

                If comboboxCantidad.SelectedIndex > 0 AndAlso MailCount >= CShort(comboboxCantidad.Text) Then
                    Exit For
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
        RefreshData()
        MostrarOcultarEstado(False)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MostrarOcultarEstado(ByVal Mostrar As Boolean)
        buttonEnviar.Visible = Not Mostrar
        buttonCancelar.Visible = Mostrar
        If Mostrar Then
            datagridviewEntidades.Height = 311
            progressbarStatus.Maximum = listEntidades.Count
            progressbarStatus.Value = 0
            textboxStatus.Text = ""
        Else
            datagridviewEntidades.Height = 449
        End If
        groupboxStatus.Visible = Mostrar
    End Sub

#End Region

End Class