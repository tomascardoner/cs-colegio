Public Class formComunicacionesEnviarMail

#Region "Declarations"
    Private mLoading As Boolean
    Private mdbContext As New CSColegioContext(True)
    Private mlistGridRowData As List(Of GridRowData)
    Private mCancelar As Boolean

    Private Class GridRowData
        Public Property IDEntidad As Integer
        Public Property ApellidoNombre As String
        Public Property Email1 As String
        Public Property Email2 As String
        Public Property Destinatario As Entidad
        Public Property FechaHoraEnvio As Date
    End Class
#End Region

#Region "Form stuff"
    Private Sub formComunicacionesEnviarMail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mLoading = True

        buttonEnviar.Enabled = False
        pFillAndRefreshLists.Comunicacion(comboboxComunicacion, False, False, False)
        comboboxCantidad.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, "500", "200", "150", "100", "50", "20", "10", "5", "1"})
        comboboxCantidad.SelectedIndex = 3

        checkboxTipoPersonalColegio.Checked = True
        checkboxTipoDocente.Checked = True
        checkboxTipoAlumno.Checked = True
        checkboxTipoFamiliar.Checked = True
        checkboxTipoProveedor.Checked = True
        checkboxTipoOtro.Checked = True

        mLoading = False

        RefreshData()
    End Sub

    Private Sub formComunicacionesEnviarMail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Load and Set Data"
    Private Sub RefreshData()
        Dim ComunicacionActual As Comunicacion
        Dim listEntidades As New List(Of Entidad)
        Dim listComunicacionEntidades As List(Of ComunicacionEntidad)

        If mLoading Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Try

            If Not comboboxComunicacion.SelectedValue Is Nothing Then

                ComunicacionActual = CType(comboboxComunicacion.SelectedItem, Comunicacion)

                ' Primero obtengo la lista de posibles Entidades
                If checkboxTipoPersonalColegio.Checked And checkboxTipoDocente.Checked And checkboxTipoAlumno.Checked And checkboxTipoFamiliar.Checked And checkboxTipoProveedor.Checked And checkboxTipoOtro.Checked Then
                    listEntidades = (From ent In mdbContext.Entidad
                                     Where ent.EsActivo And ent.ComprobanteEnviarEmail <> Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO And (Not (ent.Email1 Is Nothing And ent.Email2 Is Nothing)) _
                                     And (ent.VerificarEmail1 = False Or ent.ComprobanteEnviarEmail = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL2) And (ent.VerificarEmail2 = False Or ent.ComprobanteEnviarEmail = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL1)).ToList
                Else
                    listEntidades = (From ent In mdbContext.Entidad
                                     Where ent.EsActivo And ent.ComprobanteEnviarEmail <> Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO And (Not (ent.Email1 Is Nothing And ent.Email2 Is Nothing)) _
                                     And ((checkboxTipoPersonalColegio.Checked And ent.TipoPersonalColegio) Or (checkboxTipoDocente.Checked And ent.TipoDocente) Or (checkboxTipoAlumno.Checked And ent.TipoAlumno) Or (checkboxTipoFamiliar.Checked And ent.TipoFamiliar) Or (checkboxTipoProveedor.Checked And ent.TipoProveedor) Or (checkboxTipoOtro.Checked And ent.TipoOtro)) _
                                     And (ent.VerificarEmail1 = False Or ent.ComprobanteEnviarEmail = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL2) And (ent.VerificarEmail2 = False Or ent.ComprobanteEnviarEmail = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL1)).ToList
                End If

                ' Ahora obtengo la lista de Entidades a las que se le envió la Comunicación
                listComunicacionEntidades = (From coment In mdbContext.ComunicacionEntidad
                                             Where coment.IDComunicacion = ComunicacionActual.IDComunicacion).ToList

                ' Muestro las Entidades a las que no se les ha enviado la Comunicación seleccionada
                mlistGridRowData = (From ent In listEntidades
                                    Group Join coment In listComunicacionEntidades On ent.IDEntidad Equals coment.IDEntidad Into ComunicacionEntidad_Group = Group
                                    From comentgrp In ComunicacionEntidad_Group.DefaultIfEmpty
                                    Where comentgrp Is Nothing
                                    Order By ent.ApellidoNombre
                                    Select New GridRowData With {.IDEntidad = ent.IDEntidad, .ApellidoNombre = ent.ApellidoNombre, .Email1 = ent.Email1, .Email2 = ent.Email2, .Destinatario = ent}).ToList

                Select Case mlistGridRowData.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Entidades para mostrar.")
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Entidad.")
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0} Entidades.", mlistGridRowData.Count)
                End Select
            Else
                listEntidades = Nothing
            End If

            datagridviewEntidades.AutoGenerateColumns = False
            datagridviewEntidades.DataSource = mlistGridRowData

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

    Private Sub CambiarTipoEntidad() Handles checkboxTipoPersonalColegio.CheckedChanged, checkboxTipoDocente.CheckedChanged, checkboxTipoAlumno.CheckedChanged, checkboxTipoFamiliar.CheckedChanged, checkboxTipoProveedor.CheckedChanged, checkboxTipoOtro.CheckedChanged
        RefreshData()
    End Sub

    Private Sub Enviar_Click() Handles buttonEnviar.Click
        If mlistGridRowData.Count > 0 Then
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
        Dim ComunicacionActual As Comunicacion
        Dim listEntidadesTo As New List(Of Entidad)
        Dim listEntidadesCC As New List(Of Entidad)
        Dim listEntidadesBCC As New List(Of Entidad)
        Dim Result As Integer = 0
        Dim TotalMailsEnviados As Integer = 0

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

            If ComunicacionActual.DestinatariosEnCampoBCC Then
                listEntidadesBCC.Add(CType(RowActual.DataBoundItem, GridRowData).Destinatario)
            Else
                listEntidadesTo.Add(CType(RowActual.DataBoundItem, GridRowData).Destinatario)
            End If

            If (listEntidadesTo.Count + listEntidadesCC.Count + listEntidadesBCC.Count) >= ComunicacionActual.CantidadDestinatariosPorEmail Then
                Result = EnviarComunicacion(listEntidadesTo, listEntidadesCC, listEntidadesBCC, ComunicacionActual)
                If Result < 1 Then
                    RefreshData()
                    MostrarOcultarEstado(False)
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
                TotalMailsEnviados += Result
            End If

            If comboboxCantidad.SelectedIndex > 0 AndAlso (TotalMailsEnviados + (listEntidadesTo.Count + listEntidadesCC.Count + listEntidadesBCC.Count)) >= CShort(comboboxCantidad.Text) Then
                If (listEntidadesTo.Count + listEntidadesCC.Count + listEntidadesBCC.Count) > 0 Then
                    Result = EnviarComunicacion(listEntidadesTo, listEntidadesCC, listEntidadesBCC, ComunicacionActual)
                    If Result < 1 Then
                        RefreshData()
                        MostrarOcultarEstado(False)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    TotalMailsEnviados += Result
                    Exit For
                Else
                    Exit For
                End If
            End If

            ' Verifico que no se cancele el Envío
            Application.DoEvents()
            If mCancelar Then
                Exit For
            End If
        Next
        If (listEntidadesTo.Count + listEntidadesCC.Count + listEntidadesBCC.Count) > 0 Then
            Result = EnviarComunicacion(listEntidadesTo, listEntidadesCC, listEntidadesBCC, ComunicacionActual)
            If Result < 1 Then
                RefreshData()
                MostrarOcultarEstado(False)
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
            TotalMailsEnviados += Result
        End If

        If mCancelar Then
            MsgBox(String.Format("Se ha cancelado el envío de e-mails.{1}Se enviaron {0} e-mails.", TotalMailsEnviados, vbCrLf), MsgBoxStyle.Information, My.Application.Info.Title)
        Else
            MsgBox(String.Format("Se han enviado {0} e-mails.", TotalMailsEnviados, vbCrLf), MsgBoxStyle.Information, My.Application.Info.Title)
        End If

        RefreshData()

        MostrarOcultarEstado(False)
        Me.Cursor = Cursors.Default
    End Sub

    Private Function EnviarComunicacion(ByRef listEntidadesTo As List(Of Entidad), ByRef listEntidadesCC As List(Of Entidad), ByRef listEntidadesBCC As List(Of Entidad), ByRef ComunicacionActual As Comunicacion) As Integer
        Dim MailCount As Integer = 0

        If listEntidadesTo.Count + listEntidadesCC.Count + listEntidadesBCC.Count = 1 Then
            If listEntidadesTo.Count = 1 Then
                textboxStatus.AppendText(vbCrLf & String.Format("Enviando Comunicación a {0}...", listEntidadesTo(0).ApellidoNombre))
            ElseIf listEntidadesCC.Count = 1 Then
                textboxStatus.AppendText(vbCrLf & String.Format("Enviando Comunicación a {0}...", listEntidadesCC(0).ApellidoNombre))
            ElseIf listEntidadesBCC.Count = 1 Then
                textboxStatus.AppendText(vbCrLf & String.Format("Enviando Comunicación a {0}...", listEntidadesBCC(0).ApellidoNombre))
            End If
        Else
            textboxStatus.AppendText(vbCrLf & String.Format("Enviando Comunicación a {0} Entidades...", listEntidadesTo.Count + listEntidadesCC.Count + listEntidadesBCC.Count))
        End If

        Select Case My.Settings.LoteComprobantes_EnviarEmail_Metodo
            Case EMAIL_CLIENT_NETDLL
                MailCount = MiscFunctions.EnviarEmail_PorNETClient_AEntidades(listEntidadesTo, listEntidadesCC, listEntidadesBCC, ComunicacionActual.Asunto, ComunicacionActual.CuerpoMensajeEsHTML, ComunicacionActual.CuerpoMensaje, Nothing, "", ComunicacionActual.ArchivoAdjunto, False)
                If MailCount = -1 Then
                    Return 0
                End If
            Case EMAIL_CLIENT_MSOUTLOOK
                'Result = MiscFunctions.EnviarEmailPorMSOutlook(ComprobanteActual.Entidad, Asunto, Cuerpo, ReporteActual, AdjuntoNombre, False)
                'If MailCount = -1 Then
                '    Return 0
                'End If
            Case EMAIL_CLIENT_CRYSTALREPORTSMAPI
                'Result = MiscFunctions.EnviarEmailPorCrystalReportsMAPI(ComprobanteActual.Entidad, Asunto, Cuerpo, ReporteActual, AdjuntoNombre, False)
                'If Result = -1 Then
                '    Return 0
                'End If
        End Select

        If MailCount > 0 Then
            For Each EntidadDestinatario As Entidad In listEntidadesTo
                Dim ComunicacionEntidadNueva As New ComunicacionEntidad
                ComunicacionEntidadNueva.IDComunicacion = ComunicacionActual.IDComunicacion
                ComunicacionEntidadNueva.IDEntidad = EntidadDestinatario.IDEntidad
                ComunicacionEntidadNueva.IDUsuarioEnvioEmail = pUsuario.IDUsuario
                ComunicacionEntidadNueva.FechaHoraEnvioEmail = DateTime.Now
                mdbContext.ComunicacionEntidad.Add(ComunicacionEntidadNueva)
            Next
            For Each EntidadDestinatario As Entidad In listEntidadesCC
                Dim ComunicacionEntidadNueva As New ComunicacionEntidad
                ComunicacionEntidadNueva.IDComunicacion = ComunicacionActual.IDComunicacion
                ComunicacionEntidadNueva.IDEntidad = EntidadDestinatario.IDEntidad
                ComunicacionEntidadNueva.IDUsuarioEnvioEmail = pUsuario.IDUsuario
                ComunicacionEntidadNueva.FechaHoraEnvioEmail = DateTime.Now
                mdbContext.ComunicacionEntidad.Add(ComunicacionEntidadNueva)
            Next
            For Each EntidadDestinatario As Entidad In listEntidadesBCC
                Dim ComunicacionEntidadNueva As New ComunicacionEntidad
                ComunicacionEntidadNueva.IDComunicacion = ComunicacionActual.IDComunicacion
                ComunicacionEntidadNueva.IDEntidad = EntidadDestinatario.IDEntidad
                ComunicacionEntidadNueva.IDUsuarioEnvioEmail = pUsuario.IDUsuario
                ComunicacionEntidadNueva.FechaHoraEnvioEmail = DateTime.Now
                mdbContext.ComunicacionEntidad.Add(ComunicacionEntidadNueva)
            Next
            mdbContext.SaveChanges()

            textboxStatus.AppendText("OK")

            listEntidadesTo = New List(Of Entidad)
            listEntidadesCC = New List(Of Entidad)
            listEntidadesBCC = New List(Of Entidad)
        End If

        Return MailCount
    End Function

    Private Sub MostrarOcultarEstado(ByVal Mostrar As Boolean)
        buttonEnviar.Visible = Not Mostrar
        buttonCancelar.Visible = Mostrar
        If Mostrar Then
            datagridviewEntidades.Height = 270
            progressbarStatus.Maximum = mlistGridRowData.Count
            progressbarStatus.Value = 0
            textboxStatus.Text = ""
        Else
            datagridviewEntidades.Height = 408
        End If
        groupboxStatus.Visible = Mostrar
    End Sub

#End Region

End Class