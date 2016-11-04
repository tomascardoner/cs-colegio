Public Class formComunicacionesEnviarMail

#Region "Declarations"
    Private mLoading As Boolean
    Private dbContext As New CSColegioContext(True)
    Private listEntidades As List(Of Entidad)
    Private listGridRowData As List(Of GridRowData)
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

        listEntidades = dbContext.Entidad.Where(Function(ent) ent.EsActivo And (Not ent.ComprobanteEnviarEmail = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO) And (Not (ent.Email1 Is Nothing And ent.Email2 Is Nothing))).OrderBy(Function(ent) ent.ApellidoNombre).ToList

        mLoading = False

        RefreshData()
    End Sub

    Private Sub formComunicacionesEnviarMail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbContext.Dispose()
    End Sub
#End Region

#Region "Load and Set Data"
    Private Sub RefreshData()
        Dim ComunicacionActual As Comunicacion
        Dim ComunicacionEntidad As ComunicacionEntidad

        If mLoading Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Try

            If Not comboboxComunicacion.SelectedValue Is Nothing Then

                ComunicacionActual = CType(comboboxComunicacion.SelectedItem, Comunicacion)

                ' Muestro las Entidades a las que no se les ha enviado la Comunicación seleccionada

                If checkboxTipoPersonalColegio.Checked And checkboxTipoDocente.Checked And checkboxTipoAlumno.Checked And checkboxTipoFamiliar.Checked And checkboxTipoProveedor.Checked And checkboxTipoOtro.Checked Then
                    listGridRowData = (From e In listEntidades
                                       Select New GridRowData With {.IDEntidad = e.IDEntidad, .ApellidoNombre = e.ApellidoNombre, .Email1 = e.Email1, .Email2 = e.Email2, .Destinatario = e}).ToList
                Else
                    listGridRowData = (From e In listEntidades
                                       Where ((checkboxTipoPersonalColegio.Checked And e.TipoPersonalColegio) Or (checkboxTipoDocente.Checked And e.TipoDocente) Or (checkboxTipoAlumno.Checked And e.TipoAlumno) Or (checkboxTipoFamiliar.Checked And e.TipoFamiliar) Or (checkboxTipoProveedor.Checked And e.TipoProveedor) Or (checkboxTipoOtro.Checked And e.TipoOtro))
                                       Select New GridRowData With {.IDEntidad = e.IDEntidad, .ApellidoNombre = e.ApellidoNombre, .Email1 = e.Email1, .Email2 = e.Email2, .Destinatario = e}).ToList
                End If

                ' Esto es una horrible solución provisoria, hasta poder armar un LINQ query como corresponde
                For Each GridRowDataActual As GridRowData In listGridRowData
                    ComunicacionEntidad = dbContext.ComunicacionEntidad.Find(ComunicacionActual.IDComunicacion, GridRowDataActual.IDEntidad)
                    If Not ComunicacionEntidad Is Nothing Then
                        GridRowDataActual.FechaHoraEnvio = ComunicacionEntidad.FechaHoraEnvioEmail
                    End If
                Next
                listGridRowData = listGridRowData.Where(Function(grd) grd.FechaHoraEnvio = Date.MinValue).ToList

                Select Case listGridRowData.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Entidades para mostrar.")
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Entidad.")
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0} Entidades.", listGridRowData.Count)
                End Select
            Else
                listEntidades = Nothing
            End If

            datagridviewEntidades.AutoGenerateColumns = False
            datagridviewEntidades.DataSource = listGridRowData

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
        Dim ComunicacionActual As Comunicacion
        Dim listEntidadesBCC As New List(Of Entidad)
        Dim Result As Integer = 0
        Dim TotalMailCount As Integer = 0

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

            listEntidadesBCC.Add(CType(RowActual.DataBoundItem, GridRowData).Destinatario)

            If listEntidadesBCC.Count >= ComunicacionActual.CantidadDestinatariosPorEmail Then
                Result = EnviarComunicacion(New List(Of Entidad), New List(Of Entidad), listEntidadesBCC, ComunicacionActual)
                If Result < 1 Then
                    Exit Sub
                End If
                TotalMailCount += Result
            End If

            If comboboxCantidad.SelectedIndex > 0 AndAlso TotalMailCount + listEntidadesBCC.Count >= CShort(comboboxCantidad.Text) Then
                If listEntidadesBCC.Count > 0 Then
                    TotalMailCount += EnviarComunicacion(New List(Of Entidad), New List(Of Entidad), listEntidadesBCC, ComunicacionActual)
                    Exit For
                End If
            End If

            ' Verifico que no se cancele el Envío
            Application.DoEvents()
            If mCancelar Then
                Exit For
            End If
        Next
        If listEntidadesBCC.Count > 0 Then
            TotalMailCount += EnviarComunicacion(New List(Of Entidad), New List(Of Entidad), listEntidadesBCC, ComunicacionActual)
        End If

        If mCancelar Then
            MsgBox(String.Format("Se ha cancelado el envío de e-mails.{1}Se enviaron {0} e-mails.", TotalMailCount, vbCrLf), MsgBoxStyle.Information, My.Application.Info.Title)
        Else
            MsgBox(String.Format("Se han enviado {0} e-mails.", TotalMailCount, vbCrLf), MsgBoxStyle.Information, My.Application.Info.Title)
        End If

        RefreshData()

        MostrarOcultarEstado(False)
        Me.Cursor = Cursors.Default
    End Sub

    Private Function EnviarComunicacion(ByRef listEntidadesTo As List(Of Entidad), ByRef listEntidadesCC As List(Of Entidad), ByRef listEntidadesBCC As List(Of Entidad), ByRef ComunicacionActual As Comunicacion) As Integer
        Dim MailCount As Integer = 0

        textboxStatus.AppendText(vbCrLf & String.Format("Enviando Comunicación a {0} Entidades...", listEntidadesBCC.Count))

        Select Case My.Settings.LoteComprobantes_EnviarEmail_Metodo
            Case Constantes.EMAIL_CLIENT_NETDLL
                MailCount = MiscFunctions.EnviarEmailPorNETClient(listEntidadesTo, listEntidadesCC, listEntidadesBCC, ComunicacionActual.Asunto, ComunicacionActual.CuerpoMensajeEsHTML, ComunicacionActual.CuerpoMensaje, Nothing, "", ComunicacionActual.ArchivoAdjunto, False)
                If MailCount = -1 Then
                    Return 0
                End If
            Case Constantes.EMAIL_CLIENT_MSOUTLOOK
                'Result = MiscFunctions.EnviarEmailPorMSOutlook(ComprobanteActual.Entidad, Asunto, Cuerpo, ReporteActual, AdjuntoNombre, False)
                'If MailCount = -1 Then
                '    Return 0
                'End If
            Case Constantes.EMAIL_CLIENT_CRYSTALREPORTSMAPI
                'Result = MiscFunctions.EnviarEmailPorCrystalReportsMAPI(ComprobanteActual.Entidad, Asunto, Cuerpo, ReporteActual, AdjuntoNombre, False)
                'If Result = -1 Then
                '    Return 0
                'End If
        End Select

        If MailCount > 0 Then
            For Each EntidadDestinatario As Entidad In listEntidadesBCC
                Dim ComunicacionEntidadNueva As New ComunicacionEntidad
                ComunicacionEntidadNueva.IDComunicacion = ComunicacionActual.IDComunicacion
                ComunicacionEntidadNueva.IDEntidad = EntidadDestinatario.IDEntidad
                ComunicacionEntidadNueva.IDUsuarioEnvioEmail = pUsuario.IDUsuario
                ComunicacionEntidadNueva.FechaHoraEnvioEmail = DateTime.Now
                dbContext.ComunicacionEntidad.Add(ComunicacionEntidadNueva)
            Next
            dbContext.SaveChanges()

            textboxStatus.AppendText("OK")

            listEntidadesBCC = New List(Of Entidad)
        End If

        Return MailCount
    End Function

    Private Sub MostrarOcultarEstado(ByVal Mostrar As Boolean)
        buttonEnviar.Visible = Not Mostrar
        buttonCancelar.Visible = Mostrar
        If Mostrar Then
            datagridviewEntidades.Height = 270
            progressbarStatus.Maximum = listEntidades.Count
            progressbarStatus.Value = 0
            textboxStatus.Text = ""
        Else
            datagridviewEntidades.Height = 408
        End If
        groupboxStatus.Visible = Mostrar
    End Sub

#End Region

End Class