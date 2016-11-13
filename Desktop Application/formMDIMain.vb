Public Class formMDIMain

#Region "Declarations"
    Friend Form_ClientSize As Size
    Private mObjeto_AFIP_WS_Homologacion As CS_AFIP_WS.AFIP_WS
    Private mObjeto_AFIP_WS_Produccion As CS_AFIP_WS.AFIP_WS
#End Region

#Region "Form stuff"
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Cambio el puntero del mouse para indicar que la aplicación está iniciando
        Me.Cursor = Cursors.AppStarting

        ' Deshabilito el Form principal hasta que se cierre el SplashScreen
        Me.Enabled = False

        Me.Text = My.Application.Info.Title

        menuitemAyuda_AcercaDe.Text = "&Acerca de " & My.Application.Info.Title & "..."
    End Sub

    Private Sub formMDIMain_Resize() Handles Me.Resize
        If Not Me.WindowState = FormWindowState.Minimized Then

            'OBTENGO LAS MEDIDAS DEL CLIENT AREA DEL FORM MDI
            Form_ClientSize = New Size(Me.ClientSize.Width - toolstripMain.Width, Me.ClientSize.Height - menustripMain.Height - statusstripMain.Height)

            'HAGO UN RESIZE DE TODOS LOS CHILDS QUE ESTÉN ABIERTOS
            For Each FormCurrent As Form In Me.MdiChildren
                If FormCurrent.FormBorderStyle = Windows.Forms.FormBorderStyle.Sizable Then
                    If FormCurrent.Name = "formComprobante" Then
                        CS_Form.MDIChild_CenterToClientArea(Me, FormCurrent, Form_ClientSize)
                    Else
                        CS_Form.MDIChild_PositionAndSizeToFit(Me, FormCurrent)
                    End If
                Else
                    CS_Form.MDIChild_CenterToClientArea(Me, FormCurrent, Form_ClientSize)
                End If
            Next
        End If
    End Sub

    Private Sub MDIMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not (e.CloseReason = CloseReason.ApplicationExitCall Or e.CloseReason = CloseReason.TaskManagerClosing Or e.CloseReason = CloseReason.WindowsShutDown) Then
            If MsgBox("¿Desea salir de la aplicación?", CType(MsgBoxStyle.Information + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If
        TerminateApplication()
    End Sub
#End Region

#Region "Menu Archivo"
    Private Sub menuitemArchivo_Salir_Click() Handles menuitemArchivo_Salir.Click
        Me.Close()
    End Sub

    Private Sub UsuarioCerrarSesion() Handles menuitemArchivo_CerrarSesion.Click
        CerrarSesionUsuario()
    End Sub
#End Region

#Region "Menu Debug"
    Private Sub Debug_AFIPWSHomologacionLogin() Handles menuitemDebugAFIPWSHomologacionLogin.Click
        mObjeto_AFIP_WS_Homologacion = New CS_AFIP_WS.AFIP_WS

        If ModuloComprobantes.TransmitirAFIP_Inicializar(mObjeto_AFIP_WS_Homologacion, True) Then
            mObjeto_AFIP_WS_Homologacion.FacturaElectronica_Login()
        End If
    End Sub

    Private Sub Debug_AFIPWSHomologacionObtenerUltimoComprobante(sender As Object, e As EventArgs) Handles menuitemDebugAFIPWSHomologacionObtenerUltimoComprobante.Click
        Dim TipoComprobante As Short
        Dim PuntoVenta As Short

        If mObjeto_AFIP_WS_Homologacion Is Nothing Then
            MsgBox("No hay un Ticket de Acceso válido." & vbCrLf & "¿Ya inició sesión en AFIP?", vbExclamation, My.Application.Info.Title)
        Else
            TipoComprobante = CShort(InputBox("Ingrese el Código de Comprobante:", Me.menuitemDebugAFIPWSHomologacionObtenerUltimoComprobante.Text))
            PuntoVenta = CShort(InputBox("Ingrese el Punto de Venta:", Me.menuitemDebugAFIPWSHomologacionObtenerUltimoComprobante.Text))
            If mObjeto_AFIP_WS_Homologacion.FacturaElectronica_ConectarYObtenerUltimoNumeroComprobante(TipoComprobante, PuntoVenta) Then
                MsgBox("El Último Número de comprobante autorizado es: " & mObjeto_AFIP_WS_Homologacion.UltimoComprobanteAutorizado, vbInformation, My.Application.Info.Title)
            End If
        End If
    End Sub

    Private Sub Debug_AFIPWSHomologacionConsultarComprobante(sender As Object, e As EventArgs) Handles menuitemDebugAFIPWSHomologacionConsultarComprobante.Click
        Dim TipoComprobante As Short
        Dim PuntoVenta As Short
        Dim NumeroComprobante As Integer

        If mObjeto_AFIP_WS_Homologacion Is Nothing Then
            MsgBox("No hay un Ticket de Acceso válido." & vbCrLf & "¿Ya inició sesión en AFIP?", vbExclamation, My.Application.Info.Title)
        Else
            TipoComprobante = CShort(InputBox("Ingrese el Código de Comprobante:", Me.menuitemDebugAFIPWSHomologacionConsultarComprobante.Text))
            PuntoVenta = CShort(InputBox("Ingrese el Punto de Venta:", Me.menuitemDebugAFIPWSHomologacionConsultarComprobante.Text))
            NumeroComprobante = CShort(InputBox("Ingrese el Número de Comprobante:", Me.menuitemDebugAFIPWSHomologacionConsultarComprobante.Text))
            If mObjeto_AFIP_WS_Homologacion.FacturaElectronica_ConectarYConsultarComprobante(TipoComprobante, PuntoVenta, NumeroComprobante) Then
                If mObjeto_AFIP_WS_Homologacion.UltimoResultadoConsultaComprobante.Resultado = CS_AFIP_WS.SOLICITUD_CAE_RESULTADO_ACEPTADO Then
                    MsgBox(String.Format("Los datos del comprobante autorizado son:{0}{0}Tipo de Comprobante: {1}{0}Punto de Venta: {2}{0}Número de Comprobante: {3}{0}CAE: {4}{0}Fecha de Vencimiento: {5}{0}Fecha/Hora de Proceso: {6}", vbCrLf, mObjeto_AFIP_WS_Homologacion.UltimoResultadoConsultaComprobante.TipoComprobante, mObjeto_AFIP_WS_Homologacion.UltimoResultadoConsultaComprobante.PuntoVenta, mObjeto_AFIP_WS_Homologacion.UltimoResultadoConsultaComprobante.ComprobanteDesde, mObjeto_AFIP_WS_Homologacion.UltimoResultadoConsultaComprobante.CodigoAutorizacion, mObjeto_AFIP_WS_Homologacion.UltimoResultadoConsultaComprobante.FechaVencimiento, mObjeto_AFIP_WS_Homologacion.UltimoResultadoConsultaComprobante.FechaHoraProceso), vbInformation, My.Application.Info.Title)
                Else
                    MsgBox(mObjeto_AFIP_WS_Homologacion.UltimoResultadoConsultaComprobante.ErrorMessage, vbCritical, My.Application.Info.Title)
                End If
            End If
        End If
    End Sub

    Private Sub Debug_AFIPWSProduccionLogin() Handles menuitemDebugAFIPWSProduccionLogin.Click
        mObjeto_AFIP_WS_Produccion = New CS_AFIP_WS.AFIP_WS

        If ModuloComprobantes.TransmitirAFIP_Inicializar(mObjeto_AFIP_WS_Produccion, False) Then
            mObjeto_AFIP_WS_Produccion.FacturaElectronica_Login()
        End If
    End Sub

    Private Sub Debug_AFIPWSProduccionObtenerUltimoComprobante(sender As Object, e As EventArgs) Handles menuitemDebugAFIPWSProduccionObtenerUltimoComprobante.Click
        Dim TipoComprobante As Short
        Dim PuntoVenta As Short

        If mObjeto_AFIP_WS_Produccion Is Nothing Then
            MsgBox("No hay un Ticket de Acceso válido." & vbCrLf & "¿Ya inició sesión en AFIP?", vbExclamation, My.Application.Info.Title)
        Else
            TipoComprobante = CShort(InputBox("Ingrese el Código de Comprobante:", Me.menuitemDebugAFIPWSProduccionObtenerUltimoComprobante.Text))
            PuntoVenta = CShort(InputBox("Ingrese el Punto de Venta:", Me.menuitemDebugAFIPWSProduccionObtenerUltimoComprobante.Text))
            If mObjeto_AFIP_WS_Produccion.FacturaElectronica_ConectarYObtenerUltimoNumeroComprobante(TipoComprobante, PuntoVenta) Then
                MsgBox("El Último Número de comprobante autorizado es: " & mObjeto_AFIP_WS_Produccion.UltimoComprobanteAutorizado, vbInformation, My.Application.Info.Title)
            End If
        End If
    End Sub

    Private Sub Debug_AFIPWSProduccionConsultarComprobante(sender As Object, e As EventArgs) Handles menuitemDebugAFIPWSProduccionConsultarComprobante.Click
        Dim TipoComprobante As Short
        Dim PuntoVenta As Short
        Dim NumeroComprobante As Integer

        If mObjeto_AFIP_WS_Produccion Is Nothing Then
            MsgBox("No hay un Ticket de Acceso válido." & vbCrLf & "¿Ya inició sesión en AFIP?", vbExclamation, My.Application.Info.Title)
        Else
            TipoComprobante = CShort(InputBox("Ingrese el Código de Comprobante:", Me.menuitemDebugAFIPWSHomologacionConsultarComprobante.Text))
            PuntoVenta = CShort(InputBox("Ingrese el Punto de Venta:", Me.menuitemDebugAFIPWSHomologacionConsultarComprobante.Text))
            NumeroComprobante = CShort(InputBox("Ingrese el Número de Comprobante:", Me.menuitemDebugAFIPWSHomologacionConsultarComprobante.Text))
            If mObjeto_AFIP_WS_Produccion.FacturaElectronica_ConectarYConsultarComprobante(TipoComprobante, PuntoVenta, NumeroComprobante) Then
                If mObjeto_AFIP_WS_Produccion.UltimoResultadoConsultaComprobante.Resultado = CS_AFIP_WS.SOLICITUD_CAE_RESULTADO_ACEPTADO Then
                    MsgBox(String.Format("Los datos del comprobante autorizado son:{0}{0}Tipo de Comprobante: {1}{0}Punto de Venta: {2}{0}Número de Comprobante: {3}{0}CAE: {4}{0}Fecha de Vencimiento: {5}{0}Fecha/Hora de Proceso: {6}", vbCrLf, mObjeto_AFIP_WS_Produccion.UltimoResultadoConsultaComprobante.TipoComprobante, mObjeto_AFIP_WS_Produccion.UltimoResultadoConsultaComprobante.PuntoVenta, mObjeto_AFIP_WS_Produccion.UltimoResultadoConsultaComprobante.ComprobanteDesde, mObjeto_AFIP_WS_Produccion.UltimoResultadoConsultaComprobante.CodigoAutorizacion, mObjeto_AFIP_WS_Produccion.UltimoResultadoConsultaComprobante.FechaVencimiento, mObjeto_AFIP_WS_Produccion.UltimoResultadoConsultaComprobante.FechaHoraProceso), vbInformation, My.Application.Info.Title)
                Else
                    MsgBox(mObjeto_AFIP_WS_Produccion.UltimoResultadoConsultaComprobante.ErrorMessage, vbCritical, My.Application.Info.Title)
                End If
            End If
        End If
    End Sub

#End Region

#Region "Menu Ventana"
    Private Sub menuitemVentana_MosaicoHorizontal_Click() Handles menuitemVentanaMosaicoHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub menuitemVentana_MosaicoVertical_Click() Handles menuitemVentanaMosaicoVertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub menuitemVentana_Cascada_Click() Handles menuitemVentanaCascada.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub menuitemVentana_OrganizarIconos_Click() Handles menuitemVentanaOrganizarIconos.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub menuitemVentana_EncajarEnVentana_Click() Handles menuitemVentanaEncajarEnVentana.Click
        If Not Me.ActiveMdiChild Is Nothing Then
            Me.ActiveMdiChild.Left = 0
            Me.ActiveMdiChild.Top = 0
            Me.ActiveMdiChild.Size = Form_ClientSize
        End If
    End Sub

    Private Sub menuitemVentana_CerrarTodas_Click() Handles menuitemVentanaCerrarTodas.Click
        CS_Form.MDIChild_CloseAll(Me)
    End Sub
#End Region

#Region "Menu Ayuda"
    Private Sub menuitemAyuda_AcercaDe_Click(sender As Object, e As EventArgs) Handles menuitemAyuda_AcercaDe.Click
        formAboutBox.ShowDialog(Me)
    End Sub

#End Region

#Region "Left Toolbar - Tablas"
    Private Function FormCABGenerico_CrearOMostrar(ByVal EntityNameSingular As String, ByVal EntityNamePlural As String) As formCABGenerico
        Dim FormCurrent As formCABGenerico

        FormCurrent = CType(CS_Form.MDIChild_GetInstance(Me, "formCABGenerico", EntityNamePlural), formCABGenerico)
        If FormCurrent Is Nothing Then
            Me.Cursor = Cursors.WaitCursor

            FormCurrent = New formCABGenerico()

            CS_Form.MDIChild_PositionAndSizeToFit(Me, CType(FormCurrent, Form))
            FormCurrent.EntityNameSingular = EntityNameSingular
            FormCurrent.EntityNamePlural = EntityNamePlural
            Return FormCurrent

        Else
            If FormCurrent.WindowState = FormWindowState.Minimized Then
                FormCurrent.WindowState = FormWindowState.Normal
            End If
            FormCurrent.Focus()

            Return Nothing
        End If
    End Function

    Private Sub menuitemAnios_Click() Handles menuitemAnios.Click
        If Permisos.VerificarPermiso(Permisos.ANIO) Then
            Me.Cursor = Cursors.WaitCursor

            CS_Form.MDIChild_PositionAndSizeToFit(Me, CType(formAnios, Form))
            formAnios.Show()
            If formAnios.WindowState = FormWindowState.Minimized Then
                formAnios.WindowState = FormWindowState.Normal
            End If
            formAnios.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub menuitemCursos_Click() Handles menuitemCursos.Click
        If Permisos.VerificarPermiso(Permisos.CURSO) Then
            Me.Cursor = Cursors.WaitCursor

            CS_Form.MDIChild_PositionAndSizeToFit(Me, CType(formCursos, Form))
            formCursos.Show()
            If formCursos.WindowState = FormWindowState.Minimized Then
                formCursos.WindowState = FormWindowState.Normal
            End If
            formCursos.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub menuitemAniosLectivosCursos_Click() Handles menuitemAniosLectivosCursos.Click
        If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSO) Then
            Me.Cursor = Cursors.WaitCursor

            CS_Form.MDIChild_PositionAndSizeToFit(Me, CType(formAnioLectivoCursos, Form))
            formAnioLectivoCursos.Show()
            If formAnioLectivoCursos.WindowState = FormWindowState.Minimized Then
                formAnioLectivoCursos.WindowState = FormWindowState.Normal
            End If
            formAnioLectivoCursos.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub menuitemBancos_Click() Handles menuitemBancos.Click
        Dim formBancos As formCABGenerico

        If Permisos.VerificarPermiso(Permisos.BANCO) Then
            formBancos = FormCABGenerico_CrearOMostrar("Banco", "Bancos")
            If Not formBancos Is Nothing Then
                With formBancos
                    'AGREGO LAS COLUMNAS
                    .datagridviewMain.Columns.Add(CS_DataGridView.CreateColumn_TextBox("IDBanco", "ID", "IDBanco", DataGridViewContentAlignment.MiddleCenter))
                    .datagridviewMain.Columns.Add(CS_DataGridView.CreateColumn_TextBox("Nombre", "Nombre", "Nombre", DataGridViewContentAlignment.MiddleLeft))
                    .datagridviewMain.Columns.Add(CS_DataGridView.CreateColumn_CheckBox("Activo", "Activo", "Activo", DataGridViewContentAlignment.MiddleCenter, False, True, False, False))

                    .bindingsourceMain.DataSource = .dbContext.Banco.ToList
                    .Show()
                End With

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub menuitemRelacionTipos_Click() Handles menuitemRelacionTipos.Click
        Dim formRelacionTipo As formCABGenerico

        If Permisos.VerificarPermiso(Permisos.RELACIONTIPO) Then
            formRelacionTipo = FormCABGenerico_CrearOMostrar("Tipo de Relación", "Tipos de Relación")
            If Not formRelacionTipo Is Nothing Then
                With formRelacionTipo
                    'AGREGO LAS COLUMNAS
                    .datagridviewMain.Columns.Add(CS_DataGridView.CreateColumn_TextBox("IDRelacionTipo", "ID", "IDRelacionTipo", DataGridViewContentAlignment.MiddleCenter))
                    .datagridviewMain.Columns.Add(CS_DataGridView.CreateColumn_TextBox("Nombre", "Nombre", "Nombre", DataGridViewContentAlignment.MiddleLeft))
                    .datagridviewMain.Columns.Add(CS_DataGridView.CreateColumn_CheckBox("Activo", "Activo", "Activo", DataGridViewContentAlignment.MiddleCenter, False, True, False, False))

                    .bindingsourceMain.DataSource = .dbContext.RelacionTipo.ToList
                    .Show()
                End With

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub
#End Region

#Region "Left Toolbar - Entidades"
    Private Sub Entidades() Handles buttonEntidades.ButtonClick
        If Permisos.VerificarPermiso(Permisos.ENTIDAD) Then
            Me.Cursor = Cursors.WaitCursor

            CS_Form.MDIChild_Show(Me, CType(formEntidades, Form), False)

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub EntidadesAniosLectivosYCursos(sender As Object, e As EventArgs) Handles menuitemEntidadesAniosLectivosYCursos.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDADANIOLECTIVOCURSO) Then
            Me.Cursor = Cursors.WaitCursor

            CS_Form.MDIChild_Show(Me, CType(formEntidadesAnioLectivoCurso, Form), True)

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub EntidadesAnioLectivoCursoInscripcion(sender As Object, e As EventArgs) Handles menuitemEntidadesAnioLectivoCursoInscripcion.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDADANIOLECTIVOCURSO_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            CS_Form.MDIChild_Show(Me, CType(formEntidadInscripcion, Form), True)

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub EntidadesVerificarEmails(sender As Object, e As EventArgs) Handles menuitemEntidadesVerificarEmails.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDAD_EDITAR) Then
            Me.Cursor = Cursors.WaitCursor

            CS_Form.MDIChild_Show(Me, CType(formEntidadesVerificadorEmail, Form), True)

            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region

#Region "Left Toolbar - Comprobantes"
    Private Sub Comprobantes() Handles buttonComprobantes.ButtonClick
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE) Then
            Me.Cursor = Cursors.WaitCursor

            CS_Form.MDIChild_PositionAndSizeToFit(Me, CType(formComprobantes, Form))
            formComprobantes.Show()
            If formComprobantes.WindowState = FormWindowState.Minimized Then
                formComprobantes.WindowState = FormWindowState.Normal
            End If
            formComprobantes.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ComprobantesGenerarLoteFacturas() Handles menuitemComprobantesGenerarLoteFacturas.Click
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE_GENERARLOTE) Then
            Me.Cursor = Cursors.WaitCursor

            formComprobantesGenerarLote.MdiParent = Me
            CS_Form.CenterToParent(Me, CType(formComprobantesGenerarLote, Form))
            formComprobantesGenerarLote.Show()
            If formComprobantesGenerarLote.WindowState = FormWindowState.Minimized Then
                formComprobantesGenerarLote.WindowState = FormWindowState.Normal
            End If
            formComprobantesGenerarLote.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ComprobantesTransmitirAFIP(sender As Object, e As EventArgs) Handles menuitemComprobantesTransmitirAFIP.Click
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE_TRANSMITIR_AFIP) Then
            Me.Cursor = Cursors.WaitCursor

            formComprobantesTransmitirAFIP.MdiParent = Me
            CS_Form.CenterToParent(Me, CType(formComprobantesTransmitirAFIP, Form))
            formComprobantesTransmitirAFIP.Show()
            If formComprobantesTransmitirAFIP.WindowState = FormWindowState.Minimized Then
                formComprobantesTransmitirAFIP.WindowState = FormWindowState.Normal
            End If
            formComprobantesTransmitirAFIP.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ComprobantesEnviarMail(sender As Object, e As EventArgs) Handles menuitemComprobantesEnviarMail.Click
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE_ENVIAREMAIL) Then
            Me.Cursor = Cursors.WaitCursor

            formComprobantesEnviarMail.MdiParent = Me
            CS_Form.CenterToParent(Me, CType(formComprobantesEnviarMail, Form))
            formComprobantesEnviarMail.Show()
            If formComprobantesEnviarMail.WindowState = FormWindowState.Minimized Then
                formComprobantesEnviarMail.WindowState = FormWindowState.Normal
            End If
            formComprobantesEnviarMail.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ComprobantesExportarPagomiscuentas() Handles menuitemComprobantesExportarPagomiscuentas.Click
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE_EXPORTAR_PAGOMISCUENTAS) Then
            Me.Cursor = Cursors.WaitCursor

            formComprobantesTransmitirPagomiscuentas.MdiParent = Me
            CS_Form.CenterToParent(Me, CType(formComprobantesTransmitirPagomiscuentas, Form))
            formComprobantesTransmitirPagomiscuentas.Show()
            If formComprobantesTransmitirPagomiscuentas.WindowState = FormWindowState.Minimized Then
                formComprobantesTransmitirPagomiscuentas.WindowState = FormWindowState.Normal
            End If
            formComprobantesTransmitirPagomiscuentas.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ComprobantesExportarSantanderDebitoDirecto() Handles menuitemComprobantesExportarSantanderDebitoDirecto.Click
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE_EXPORTAR_SANTANDERDEBITODIRECTO) Then
            Me.Cursor = Cursors.WaitCursor

            formComprobantesTransmitirSantanderDebitoDirecto.MdiParent = Me
            CS_Form.CenterToParent(Me, CType(formComprobantesTransmitirSantanderDebitoDirecto, Form))
            formComprobantesTransmitirSantanderDebitoDirecto.Show()
            If formComprobantesTransmitirSantanderDebitoDirecto.WindowState = FormWindowState.Minimized Then
                formComprobantesTransmitirSantanderDebitoDirecto.WindowState = FormWindowState.Normal
            End If
            formComprobantesTransmitirSantanderDebitoDirecto.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ComprobantesExportarSantanderRecaudacionPorCaja() Handles menuitemComprobantesExportarSantanderRecaudacionPorCaja.Click
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE_EXPORTAR_SANTANDERRECAUDACIONPORCAJA) Then
            Me.Cursor = Cursors.WaitCursor

            formComprobantesTransmitirSantanderRecaudacionPorCaja.MdiParent = Me
            CS_Form.CenterToParent(Me, CType(formComprobantesTransmitirSantanderRecaudacionPorCaja, Form))
            formComprobantesTransmitirSantanderRecaudacionPorCaja.Show()
            If formComprobantesTransmitirSantanderRecaudacionPorCaja.WindowState = FormWindowState.Minimized Then
                formComprobantesTransmitirSantanderRecaudacionPorCaja.WindowState = FormWindowState.Normal
            End If
            formComprobantesTransmitirSantanderRecaudacionPorCaja.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ComprobantesImportarSantanderDebitoDirecto() Handles menuitemComprobantesImportarSantanderDebitoDirecto.Click
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE_IMPORTAR_SANTANDERDEBITODIRECTO) Then
            Me.Cursor = Cursors.WaitCursor

            formComprobantesRecibirSantanderDebitoDirecto.MdiParent = Me
            CS_Form.CenterToParent(Me, CType(formComprobantesRecibirSantanderDebitoDirecto, Form))
            formComprobantesRecibirSantanderDebitoDirecto.Show()
            If formComprobantesRecibirSantanderDebitoDirecto.WindowState = FormWindowState.Minimized Then
                formComprobantesRecibirSantanderDebitoDirecto.WindowState = FormWindowState.Normal
            End If
            formComprobantesRecibirSantanderDebitoDirecto.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ComprobantesImportarSantanderRecaudacionPorCaja() Handles menuitemComprobantesImportarSantanderRecaudacionPorCaja.Click
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE_IMPORTAR_SANTANDERRECAUDACIONPORCAJA) Then
            Me.Cursor = Cursors.WaitCursor

            'formComprobantesRecibirirSantanderRecaudacionPorCaja.MdiParent = Me
            'CS_Form.CenterToParent(Me, CType(formComprobantesRecibirirSantanderRecaudacionPorCaja, Form))
            'formComprobantesRecibirirSantanderRecaudacionPorCaja.Show()
            'If formComprobantesRecibirirSantanderRecaudacionPorCaja.WindowState = FormWindowState.Minimized Then
            '    formComprobantesRecibirirSantanderRecaudacionPorCaja.WindowState = FormWindowState.Normal
            'End If
            'formComprobantesRecibirirSantanderRecaudacionPorCaja.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region

#Region "Left Toolbar - Comunicaciones"
    Private Sub Comunicaciones(sender As Object, e As EventArgs) Handles menuitemComunicacionesEnviarMail.Click
        If Permisos.VerificarPermiso(Permisos.COMUNICACION_ENVIAREMAIL) Then
            Me.Cursor = Cursors.WaitCursor

            formComunicacionesEnviarMail.MdiParent = Me
            CS_Form.CenterToParent(Me, CType(formComunicacionesEnviarMail, Form))
            formComunicacionesEnviarMail.Show()
            If formComunicacionesEnviarMail.WindowState = FormWindowState.Minimized Then
                formComunicacionesEnviarMail.WindowState = FormWindowState.Normal
            End If
            formComunicacionesEnviarMail.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region

#Region "Left Toolbar - Reportes"
    Private Sub buttonReportes_Click(sender As Object, e As EventArgs) Handles buttonReportes.Click
        If Permisos.VerificarPermiso(Permisos.REPORTE) Then
            Me.Cursor = Cursors.WaitCursor

            CS_Form.MDIChild_PositionAndSizeToFit(Me, CType(formReportes, Form))
            formReportes.Show()
            If formReportes.WindowState = FormWindowState.Minimized Then
                formReportes.WindowState = FormWindowState.Normal
            End If
            formReportes.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub labelUsuarioNombre_DoubleClick() Handles labelUsuarioNombre.MouseDown
        CerrarSesionUsuario()
    End Sub
#End Region

#Region "Extra stuff"
    Private Sub CerrarSesionUsuario()
        If MsgBox("¿Desea cerrar la sesión del Usuario actual?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
            CS_Form.MDIChild_CloseAll(Me)
            labelUsuarioNombre.Image = Nothing
            labelUsuarioNombre.Text = ""
            pUsuario = Nothing
            If Not formLogin.ShowDialog(Me) = DialogResult.OK Then
                Application.Exit()
                My.Application.Log.WriteEntry("La Aplicación ha finalizado porque el Usuario no ha iniciado sesión.", TraceEventType.Warning)
                Exit Sub
            End If
            formLogin.Close()
            formLogin.Dispose()
        End If
    End Sub

#End Region

End Class