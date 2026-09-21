Public Class formMDIMain

#Region "Declarations"

    Private mObjeto_AFIP_WS_Homologacion As CardonerSistemas.AfipWebServices.WebService
    Private mObjeto_AFIP_WS_Produccion As CardonerSistemas.AfipWebServices.WebService

    Private mArcaCredenciales_Homologacion As Armuna.Framework.Tax.Arca.ArcaCredentials
    Private mArcaCredenciales_Produccion As Armuna.Framework.Tax.Arca.ArcaCredentials

#End Region

#Region "Form stuff"

    Private Sub SetAppearance()
        Me.Enabled = False
        Me.Cursor = Cursors.AppStarting
        Me.Icon = My.Resources.IconApplication
        Me.Text = My.Application.Info.Title

        menuitemAyuda_AcercaDe.Text = $"&Acerca de {My.Application.Info.Title}..."
        labelLicenciaCompania.Text = $"Se licencia el uso a: {pLicensedTo.ToUpper()}"
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetAppearance()
    End Sub

    Private Sub Me_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not (e.CloseReason = CloseReason.ApplicationExitCall OrElse e.CloseReason = CloseReason.TaskManagerClosing OrElse e.CloseReason = CloseReason.WindowsShutDown) Then
            If MsgBox("¿Desea salir de la aplicación?", CType(MsgBoxStyle.Information + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                e.Cancel = True
                Return
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

#Region "Menu Debug (Armuna.Framework.Tax)"

    Private Function ObtenerValorInputBoxInteger(ByVal Prompt As String, ByVal Title As String) As Integer
        Dim InputValue As String
        Dim ResultValue As Integer
        InputValue = InputBox(Prompt, Title)
        If Not Integer.TryParse(InputValue, ResultValue) Then
            ResultValue = 0
        End If
        Return ResultValue
    End Function

    Private Function ObtenerValorInputBoxShort(ByVal Prompt As String, ByVal Title As String) As Short
        Dim InputValue As String
        Dim ResultValue As Short
        InputValue = InputBox(Prompt, Title)
        If Not Short.TryParse(InputValue, ResultValue) Then
            ResultValue = 0
        End If
        Return ResultValue
    End Function

    Private Function ObtenerValorInputBoxByte(ByVal Prompt As String, ByVal Title As String) As Byte
        Dim InputValue As String
        Dim ResultValue As Byte
        InputValue = InputBox(Prompt, Title)
        If Not Byte.TryParse(InputValue, ResultValue) Then
            ResultValue = 0
        End If
        Return ResultValue
    End Function


    Private Function Debug_Armuna_CargarCredenciales(ByVal ModoHomologacion As Boolean) As Armuna.Framework.Tax.Arca.ArcaCredentials
        Dim CertificadoPath As String
        Dim Entorno As Armuna.Framework.Tax.Arca.ArcaEnvironment
        Dim Credenciales As Armuna.Framework.Tax.Arca.ArcaCredentials = Nothing
        Dim ResultMessage As String = Nothing

        If ModoHomologacion Then
            CertificadoPath = pAfipWebServicesConfig.CertificadoHomologacion
            Entorno = Armuna.Framework.Tax.Arca.ArcaEnvironment.Homologacion
        Else
            CertificadoPath = pAfipWebServicesConfig.CertificadoProduccion
            Entorno = Armuna.Framework.Tax.Arca.ArcaEnvironment.Produccion
        End If

        If Not Armuna.Framework.Tax.Arca.ArcaCredentialsLoader.TryLoadFromPemFiles(CS_Parameter_System.GetString(Parametros.EMPRESA_CUIT), CertificadoPath, pAfipWebServicesConfig.ClavePrivada, Entorno, Credenciales, ResultMessage) Then
            MsgBox(ResultMessage, vbCritical, My.Application.Info.Title)
            Return Nothing
        End If

        Return Credenciales
    End Function

    Private Async Sub Debug_Armuna_AFIPWSHomologacionLogin() Handles menuitemDebugAFIPWSArmunaHomologacionLogin.Click
        Dim Credenciales = Debug_Armuna_CargarCredenciales(True)
        If Credenciales Is Nothing Then Exit Sub

        Dim Resultado = Await Armuna.Framework.Tax.Arca.Wsaa.WsaaService.GetTicketAsync(Credenciales, Armuna.Framework.Tax.Arca.ArcaServiceId.FacturaElectronica)
        If Resultado.success Then
            mArcaCredenciales_Homologacion = Credenciales
            MsgBox(Resultado.resultMessage, vbInformation, My.Application.Info.Title)
        Else
            MsgBox(Resultado.resultMessage, vbCritical, My.Application.Info.Title)
        End If
    End Sub

    Private Async Sub Debug_Armuna_AFIPWSHomologacionObtenerUltimoComprobante(sender As Object, e As EventArgs) Handles menuitemDebugAFIPWSArmunaHomologacionObtenerUltimoComprobante.Click
        Dim TipoComprobante As Short
        Dim PuntoVenta As Short

        If mArcaCredenciales_Homologacion Is Nothing Then
            MsgBox("No hay credenciales cargadas." & vbCrLf & "¿Ya inició sesión en AFIP?", vbExclamation, My.Application.Info.Title)
        Else
            TipoComprobante = CShort(InputBox("Ingrese el Código de Comprobante:", Me.menuitemDebugAFIPWSArmunaHomologacionObtenerUltimoComprobante.Text))
            PuntoVenta = CShort(InputBox("Ingrese el Punto de Venta:", Me.menuitemDebugAFIPWSArmunaHomologacionObtenerUltimoComprobante.Text))

            Dim Resultado = Await Armuna.Framework.Tax.Arca.Wsfe.WsfeService.ObtenerUltimoComprobanteAutorizadoAsync(mArcaCredenciales_Homologacion, PuntoVenta, TipoComprobante)
            If Resultado.success Then
                MsgBox("El Último Número de comprobante autorizado es: " & Resultado.ultimoComprobante, vbInformation, My.Application.Info.Title)
            Else
                MsgBox(Resultado.resultMessage, vbCritical, My.Application.Info.Title)
            End If
        End If
    End Sub

    Private Async Sub Debug_Armuna_AFIPWSHomologacionConsultarComprobante(sender As Object, e As EventArgs) Handles menuitemDebugAFIPWSArmunaHomologacionConsultarComprobante.Click
        Dim TipoComprobante As Short
        Dim PuntoVenta As Short
        Dim NumeroComprobante As Integer

        If mArcaCredenciales_Homologacion Is Nothing Then
            MsgBox("No hay credenciales cargadas." & vbCrLf & "¿Ya inició sesión en AFIP?", vbExclamation, My.Application.Info.Title)
        Else
            TipoComprobante = CShort(InputBox("Ingrese el Código de Comprobante:", Me.menuitemDebugAFIPWSArmunaHomologacionConsultarComprobante.Text))
            PuntoVenta = CShort(InputBox("Ingrese el Punto de Venta:", Me.menuitemDebugAFIPWSArmunaHomologacionConsultarComprobante.Text))
            NumeroComprobante = CShort(InputBox("Ingrese el Número de Comprobante:", Me.menuitemDebugAFIPWSArmunaHomologacionConsultarComprobante.Text))

            Dim Resultado = Await Armuna.Framework.Tax.Arca.Wsfe.WsfeService.ConsultarComprobanteAsync(mArcaCredenciales_Homologacion, PuntoVenta, TipoComprobante, NumeroComprobante)
            If Resultado.success Then
                If Resultado.resultado.Resultado = "A" Then
                    MsgBox(String.Format("Los datos del comprobante autorizado son:{0}{0}Tipo de Comprobante: {1}{0}Punto de Venta: {2}{0}Número de Comprobante: {3}{0}CAE: {4}{0}Fecha de Vencimiento: {5}", vbCrLf, Resultado.resultado.ComprobanteTipo, Resultado.resultado.PuntoVenta, Resultado.resultado.ComprobanteNumero, Resultado.resultado.CodigoAutorizacion, Resultado.resultado.CaeFechaVencimiento), vbInformation, My.Application.Info.Title)
                Else
                    MsgBox(String.Join(vbCrLf, Resultado.resultado.Errores), vbCritical, My.Application.Info.Title)
                End If
            Else
                MsgBox(Resultado.resultMessage, vbCritical, My.Application.Info.Title)
            End If
        End If
    End Sub

    Private Async Sub Debug_Armuna_AFIPWSProduccionLogin() Handles menuitemDebugAFIPWSArmunaProduccionLogin.Click
        Dim Credenciales = Debug_Armuna_CargarCredenciales(False)
        If Credenciales Is Nothing Then Exit Sub

        Dim Resultado = Await Armuna.Framework.Tax.Arca.Wsaa.WsaaService.GetTicketAsync(Credenciales, Armuna.Framework.Tax.Arca.ArcaServiceId.FacturaElectronica)
        If Resultado.success Then
            mArcaCredenciales_Produccion = Credenciales
            MsgBox(Resultado.resultMessage, vbInformation, My.Application.Info.Title)
        Else
            MsgBox(Resultado.resultMessage, vbCritical, My.Application.Info.Title)
        End If
    End Sub

    Private Async Sub Debug_Armuna_AFIPWSProduccionObtenerUltimoComprobante(sender As Object, e As EventArgs) Handles menuitemDebugAFIPWSArmunaProduccionObtenerUltimoComprobante.Click
        Dim TipoComprobante As Byte
        Dim PuntoVenta As Short

        If mArcaCredenciales_Produccion Is Nothing Then
            MsgBox("No hay credenciales cargadas." & vbCrLf & "¿Ya inició sesión en ARCA?", vbExclamation, My.Application.Info.Title)
        Else
            TipoComprobante = ObtenerValorInputBoxByte("Ingrese el Código de Comprobante:", Me.menuitemDebugAFIPWSArmunaProduccionObtenerUltimoComprobante.Text)
            If TipoComprobante = 0 Then
                Return
            End If
            PuntoVenta = ObtenerValorInputBoxShort("Ingrese el Punto de Venta:", Me.menuitemDebugAFIPWSArmunaProduccionObtenerUltimoComprobante.Text)
            If PuntoVenta = 0 Then
                Return
            End If

            Dim Resultado = Await Armuna.Framework.Tax.Arca.Wsfe.WsfeService.ObtenerUltimoComprobanteAutorizadoAsync(mArcaCredenciales_Produccion, PuntoVenta, TipoComprobante)
            If Resultado.success Then
                MsgBox("El Último Número de comprobante autorizado es: " & Resultado.ultimoComprobante, vbInformation, My.Application.Info.Title)
            Else
                MsgBox(Resultado.resultMessage, vbCritical, My.Application.Info.Title)
            End If
        End If
    End Sub

    Private Async Sub Debug_Armuna_AFIPWSProduccionConsultarComprobante(sender As Object, e As EventArgs) Handles menuitemDebugAFIPWSArmunaProduccionConsultarComprobante.Click
        Dim TipoComprobante As Byte
        Dim PuntoVenta As Short
        Dim NumeroComprobante As Integer

        If mArcaCredenciales_Produccion Is Nothing Then
            MsgBox("No hay credenciales cargadas." & vbCrLf & "¿Ya inició sesión en ARCA?", vbExclamation, My.Application.Info.Title)
        Else
            TipoComprobante = ObtenerValorInputBoxByte("Ingrese el Código de Comprobante:", Me.menuitemDebugAFIPWSArmunaProduccionConsultarComprobante.Text)
            If TipoComprobante = 0 Then
                Return
            End If
            PuntoVenta = ObtenerValorInputBoxShort("Ingrese el Punto de Venta:", Me.menuitemDebugAFIPWSArmunaProduccionConsultarComprobante.Text)
            If PuntoVenta = 0 Then
                Return
            End If
            NumeroComprobante = ObtenerValorInputBoxInteger("Ingrese el Número de Comprobante:", Me.menuitemDebugAFIPWSArmunaProduccionConsultarComprobante.Text)
            If NumeroComprobante = 0 Then
                Return
            End If

            Dim Resultado = Await Armuna.Framework.Tax.Arca.Wsfe.WsfeService.ConsultarComprobanteAsync(mArcaCredenciales_Produccion, PuntoVenta, TipoComprobante, NumeroComprobante)
            If Resultado.success Then
                If Resultado.resultado.Resultado = "A" Then
                    MsgBox(
                        String.Format(
                                "Los datos del comprobante autorizado son:{0}{0}" +
                                "Tipo de Comprobante: {1}{0}Punto de Venta: {2}{0}Número de Comprobante: {3}{0}" +
                                "Tipo de documento: {4}{0}Nº de documento: {5}{0}" +
                                "Importe neto: {6:C}{0}Importe IVA: {7:C}{0}Importe total: {8:C}{0}" +
                                "Fecha de servicio desde: {9:d}{0}Fecha de servicio hasta: {10:d}{0}Fecha de vencimiento de pago: {11:d}{0}" +
                                "CAE: {12}{0}Fecha de Vencimiento: {13:d}{0}Fecha de proceso: {14:g}",
                            Environment.NewLine,
                            Resultado.resultado.ComprobanteTipo, Resultado.resultado.PuntoVenta, Resultado.resultado.ComprobanteNumero,
                            Resultado.resultado.DocumentoTipo, Resultado.resultado.DocumentoNro,
                            Resultado.resultado.ImporteNeto, Resultado.resultado.ImporteIva, Resultado.resultado.ImporteTotal,
                            Resultado.resultado.FechaServicioDesde, Resultado.resultado.FechaServicioHasta, Resultado.resultado.FechaVencimientoPago,
                            Resultado.resultado.CodigoAutorizacion, Resultado.resultado.CaeFechaVencimiento, Resultado.resultado.FechaProceso),
                        vbInformation,
                        My.Application.Info.Title)
                Else
                    MsgBox(String.Join(vbCrLf, Resultado.resultado.Errores), vbCritical, My.Application.Info.Title)
                End If
            Else
                MsgBox(Resultado.resultMessage, vbCritical, My.Application.Info.Title)
            End If
        End If
    End Sub

#End Region

#Region "Menu Ventana"

    Private Sub menuitemVentana_OrganizarIconos_Click() Handles menuitemVentanaOrganizarIconos.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub menuitemVentana_CerrarTodas_Click() Handles menuitemVentanaCerrarTodas.Click
        CardonerSistemas.Forms.MdiChildCloseAll(Me)
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

        FormCurrent = CType(CardonerSistemas.Forms.MdiChildGetInstance(Me, "formCABGenerico", EntityNamePlural), formCABGenerico)
        If FormCurrent Is Nothing Then
            Me.Cursor = Cursors.WaitCursor

            FormCurrent = New formCABGenerico()

            CardonerSistemas.Forms.MdiChildPositionAndSizeToFit(Me, CType(FormCurrent, Form))
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
            CardonerSistemas.Forms.MdiChildShow(Me, CType(formAnios, Form), False)
        End If
    End Sub

    Private Sub menuitemCursos_Click() Handles menuitemCursos.Click
        If Permisos.VerificarPermiso(Permisos.CURSO) Then
            CardonerSistemas.Forms.MdiChildShow(Me, CType(formCursos, Form), False)
        End If
    End Sub

    Private Sub menuitemAniosLectivosCursos_Click() Handles menuitemAniosLectivosCursos.Click
        If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSO) Then
            CardonerSistemas.Forms.MdiChildShow(Me, CType(formAnioLectivoCursos, Form), False)
        End If
    End Sub

    Private Sub menuitemAniosLectivosCuotas_Click() Handles menuitemAniosLectivosCuotas.Click
        If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCUOTA) Then
            CardonerSistemas.Forms.MdiChildShow(Me, CType(formAnioLectivoCuotas, Form), False)
        End If
    End Sub

    Private Sub menuitemBancos_Click(sender As Object, e As EventArgs) Handles menuitemBancos.Click
        Dim formBancos As formCABGenerico

        If Permisos.VerificarPermiso(Permisos.BANCO) Then
            formBancos = FormCABGenerico_CrearOMostrar("Banco", "Bancos")
            If formBancos IsNot Nothing Then
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
            If formRelacionTipo IsNot Nothing Then
                With formRelacionTipo
                    'AGREGO LAS COLUMNAS
                    .datagridviewMain.Columns.Add(CS_DataGridView.CreateColumn_TextBox("IDRelacionTipo", "ID", "IDRelacionTipo", DataGridViewContentAlignment.MiddleCenter))
                    .datagridviewMain.Columns.Add(CS_DataGridView.CreateColumn_TextBox("Nombre", "Nombre", "Nombre", DataGridViewContentAlignment.MiddleLeft))
                    .datagridviewMain.Columns.Add(CS_DataGridView.CreateColumn_CheckBox("Activo", "Activo", "Activo", DataGridViewContentAlignment.MiddleCenter, False, True, False, False))

                    .bindingsourceMain.DataSource = .dbContext.RelacionTipo.Where(Function(rt) rt.IDRelacionTipo <> CardonerSistemas.Constants.FIELD_VALUE_OTHER_BYTE).ToList
                    .Show()
                End With

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub menuitemGruposUsuarios_Click() Handles menuitemGruposUsuarios.Click
        If Permisos.VerificarPermiso(Permisos.USUARIOGRUPO) Then
            CardonerSistemas.Forms.MdiChildShow(Me, CType(formUsuarioGrupos, Form), False)
        End If
    End Sub

    Private Sub menuitemPermisosGruposUsuarios_Click() Handles menuitemPermisosGruposUsuarios.Click
        If Permisos.VerificarPermiso(Permisos.USUARIOGRUPOPERMISO) Then
            CardonerSistemas.Forms.MdiChildShow(Me, CType(formUsuarioGrupoPermisos, Form), False)
        End If
    End Sub

    Private Sub menuitemUsuarios_Click() Handles menuitemUsuarios.Click
        If Permisos.VerificarPermiso(Permisos.USUARIO) Then
            CardonerSistemas.Forms.MdiChildShow(Me, CType(formUsuarios, Form), False)
        End If
    End Sub

#End Region

#Region "Left Toolbar - Entidades"

    Private Sub Entidades() Handles ToolStripSplitButtonEntidades.ButtonClick
        If Permisos.VerificarPermiso(Permisos.ENTIDAD) Then
            Me.Cursor = Cursors.WaitCursor

            CardonerSistemas.Forms.MdiChildShow(Me, CType(formEntidades, Form), False)

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub EntidadesAniosLectivosYCursos(sender As Object, e As EventArgs) Handles menuitemEntidadesAniosLectivosYCursos.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDADANIOLECTIVOCURSO) Then
            Me.Cursor = Cursors.WaitCursor

            CardonerSistemas.Forms.MdiChildShow(Me, CType(formEntidadesAnioLectivoCurso, Form), False)

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub EntidadesAnioLectivoCursoInscripcion(sender As Object, e As EventArgs) Handles menuitemEntidadesAnioLectivoCursoInscripcion.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDADANIOLECTIVOCURSO_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            CardonerSistemas.Forms.MdiChildShow(Me, CType(FormEntidadInscripcion, Form), True)

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub EntidadesVerificarEmails(sender As Object, e As EventArgs) Handles menuitemEntidadesVerificarEmails.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDAD_EDITAR) Then
            Me.Cursor = Cursors.WaitCursor

            CardonerSistemas.Forms.MdiChildShow(Me, CType(formEntidadesVerificadorEmail, Form), True)

            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region

#Region "Left Toolbar - Comprobantes"

    Private Sub Comprobantes() Handles ToolStripSplitButtonComprobantes.ButtonClick
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE) Then
            Me.Cursor = Cursors.WaitCursor

            CardonerSistemas.Forms.MdiChildPositionAndSizeToFit(Me, CType(formComprobantes, Form))
            formComprobantes.Show()
            formComprobantes.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ComprobantesGenerarLoteFacturas() Handles menuitemComprobantesGenerarLoteFacturas.Click
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE_GENERARLOTE) Then
            Me.Cursor = Cursors.WaitCursor

            formComprobantesGenerarLote.MdiParent = Me
            CardonerSistemas.Forms.CenterToParent(Me, CType(formComprobantesGenerarLote, Form))
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
            CardonerSistemas.Forms.CenterToParent(Me, CType(formComprobantesTransmitirAFIP, Form))
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
            CardonerSistemas.Forms.CenterToParent(Me, CType(formComprobantesEnviarMail, Form))
            formComprobantesEnviarMail.Show()
            If formComprobantesEnviarMail.WindowState = FormWindowState.Minimized Then
                formComprobantesEnviarMail.WindowState = FormWindowState.Normal
            End If
            formComprobantesEnviarMail.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ComprobantesExportarPagosEduca() Handles menuitemComprobantesExportarPagosEduc.Click
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE_EXPORTAR_PAGOSEDUC) Then
            Me.Cursor = Cursors.WaitCursor

            formComprobantesTransmitirPagosEduc.MdiParent = Me
            CardonerSistemas.Forms.CenterToParent(Me, CType(formComprobantesTransmitirPagosEduc, Form))
            formComprobantesTransmitirPagosEduc.Show()
            If formComprobantesTransmitirPagosEduc.WindowState = FormWindowState.Minimized Then
                formComprobantesTransmitirPagosEduc.WindowState = FormWindowState.Normal
            End If
            formComprobantesTransmitirPagosEduc.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ComprobantesExportarPagomiscuentas() Handles menuitemComprobantesExportarPagomiscuentas.Click
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE_EXPORTAR_PAGOMISCUENTAS) Then
            Me.Cursor = Cursors.WaitCursor

            formComprobantesTransmitirPagomiscuentas.MdiParent = Me
            CardonerSistemas.Forms.CenterToParent(Me, CType(formComprobantesTransmitirPagomiscuentas, Form))
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
            CardonerSistemas.Forms.CenterToParent(Me, CType(formComprobantesTransmitirSantanderDebitoDirecto, Form))
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
            CardonerSistemas.Forms.CenterToParent(Me, CType(formComprobantesTransmitirSantanderRecaudacionPorCaja, Form))
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
            CardonerSistemas.Forms.CenterToParent(Me, CType(formComprobantesRecibirSantanderDebitoDirecto, Form))
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
            'CardonerSistemas.Forms.CenterToParent(Me, CType(formComprobantesRecibirirSantanderRecaudacionPorCaja, Form))
            'formComprobantesRecibirirSantanderRecaudacionPorCaja.Show()
            'If formComprobantesRecibirirSantanderRecaudacionPorCaja.WindowState = FormWindowState.Minimized Then
            '    formComprobantesRecibirirSantanderRecaudacionPorCaja.WindowState = FormWindowState.Normal
            'End If
            'formComprobantesRecibirirSantanderRecaudacionPorCaja.Focus()

            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region

#Region "Left Toolbar - Sueldos"

    Private Sub ToolStripMenuItemSueldosModulos_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSueldosModulos.Click
        If Permisos.VerificarPermiso(Permisos.SUELDO_CALCULOMODULO) Then
            CardonerSistemas.Forms.MdiChildShow(Me, CType(FormCalculosModulos, Form), False)
        End If
    End Sub

    Private Sub ToolStripMenuItemSueldosLiquidaciones_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemSueldosLiquidaciones.Click
        If Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION) Then
            CardonerSistemas.Forms.MdiChildShow(Me, CType(FormLiquidaciones, Form), False)
        End If
    End Sub

#End Region

#Region "Left Toolbar - Comunicaciones"

    Private Sub Comunicaciones() Handles ToolStripSplitButtonComunicaciones.ButtonClick
        If Permisos.VerificarPermiso(Permisos.COMUNICACION) Then
            CardonerSistemas.Forms.MdiChildShow(Me, CType(formComunicaciones, Form), False)
        End If
    End Sub


    Private Sub ComunicacionesEnviarMail(sender As Object, e As EventArgs) Handles menuitemComunicacionesEnviarMail.Click
        If Permisos.VerificarPermiso(Permisos.COMUNICACION_ENVIAREMAIL) Then
            CardonerSistemas.Forms.MdiChildShow(Me, CType(formComunicacionesEnviarMail, Form), True)
        End If
    End Sub
#End Region

#Region "Left Toolbar - Reportes"
    Private Sub Reportes_Click(sender As Object, e As EventArgs) Handles ToolStripButtonReportes.Click
        If Permisos.VerificarPermiso(Permisos.REPORTE) Then
            CardonerSistemas.Forms.MdiChildShow(Me, CType(formReportes, Form), False)
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
            CardonerSistemas.Forms.MdiChildCloseAll(Me)
            labelUsuarioNombre.Image = Nothing
            labelUsuarioNombre.Text = String.Empty
            pUsuario = Nothing
            If formLogin.ShowDialog(Me) <> DialogResult.OK Then
                Application.Exit()
                My.Application.Log.WriteEntry("La Aplicación ha finalizado porque el Usuario no ha iniciado sesión.", TraceEventType.Warning)
                Return
            End If
            formLogin.Close()
            formLogin.Dispose()
        End If
    End Sub

#End Region

End Class