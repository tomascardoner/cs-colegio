Public Class formTransmitirComprobantesAFIP
    Private dbContext As New CSColegioContext
    Private listComprobantes As List(Of ComprobanteCabecera)

    Private Sub formTransmitirComprobantesAFIP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buttonTransmitir.Enabled = False
        FillAndRefreshLists.ComprobanteLote(comboboxLote, False, False)
    End Sub

    Private Sub formTransmitirComprobantesAFIP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbContext.Dispose()
    End Sub

    Private Sub comboboxLote_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboboxLote.SelectedIndexChanged
        Dim IDLoteFiltro As Integer

        If comboboxLote.SelectedIndex > -1 Then
            IDLoteFiltro = CInt(comboboxLote.SelectedValue)

            If IDLoteFiltro = -1 Then
                listComprobantes = (From cc In dbContext.ComprobanteCabecera
                                   Where cc.ComprobanteTipo.EmisionElectronica And cc.CAE Is Nothing
                                   Order By cc.IDComprobante).ToList
            Else
                listComprobantes = (From cc In dbContext.ComprobanteCabecera
                                   Where cc.IDComprobanteLote = IDLoteFiltro And cc.ComprobanteTipo.EmisionElectronica And cc.CAE Is Nothing
                                   Order By cc.IDComprobante).ToList
            End If

            datagridviewPaso3Cabecera.AutoGenerateColumns = False
            datagridviewPaso3Cabecera.DataSource = listComprobantes.ToList

            buttonTransmitir.Enabled = (listComprobantes.Count > 0)
        End If
    End Sub

    Private Sub buttonTransmitir_Click(sender As Object, e As EventArgs) Handles buttonTransmitir.Click
        If listComprobantes.Count > 0 Then
            TransmitirComprobantes()
        End If
    End Sub

    Private Sub TransmitirComprobantes()
        Dim LogPath As String = ""
        Dim LogFileName As String = ""
        Dim WSAA_URL As String
        Dim WSFEv1_URL As String
        Dim AFIP_TicketAcceso As String
        Dim AFIP_Factura As CSM_AFIP_WS.FacturaElectronicaCabecera
        Dim ResultadoCAE As CSM_AFIP_WS.ResultadoCAE
        Dim MensajeError As String

        Dim InternetProxy As String
        Dim CUIT_Emisor As String
        Dim ArticuloActual As Articulo
        Dim MonedaLocal As Moneda
        Dim MonedaLocalCotizacion As MonedaCotizacion
        Dim ComprobanteTipoActual As New ComprobanteTipo

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        If formMDIMain.menuitemDebugAFIPWSHabilitarRegistro.Checked Then
            LogPath = CSM_SpecialFolders.ProcessString(My.Settings.AFIP_WS_LogFolder)
            If Not LogPath.EndsWith("\") Then
                LogPath &= "\"
            End If
            LogFileName = CSM_File.ProcessFilename(My.Settings.AFIP_WS_LogFileName)
        End If

        ' Leo los valores comunes a todas las facturas
        If My.Settings.AFIP_WS_ModoHomologacion Then
            WSAA_URL = CSM_Parameter.GetString(Parametros.AFIP_WS_AA_HOMOLOGACION)
            WSFEv1_URL = CSM_Parameter.GetString(Parametros.AFIP_WS_AA_HOMOLOGACION)
        Else
            WSAA_URL = CSM_Parameter.GetString(Parametros.AFIP_WS_AA_PRODUCCION)
            WSFEv1_URL = CSM_Parameter.GetString(Parametros.AFIP_WS_FE_PRODUCCION)
        End If

        InternetProxy = CSM_Parameter.GetString(Parametros.INTERNET_PROXY, "")
        CUIT_Emisor = CSM_Parameter.GetString(Parametros.EMPRESA_CUIT)
        ArticuloActual = dbContext.Articulo.Find(CSM_Parameter.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_ARTICULO_ID))
        If ArticuloActual Is Nothing Then
            Me.Cursor = Cursors.WaitCursor
            MsgBox("No se ha especificado el Artículo correspondiente a las cuotas mensuales.", vbExclamation, My.Application.Info.Title)
            Exit Sub
        End If
        MonedaLocal = dbContext.Moneda.Find(CSM_Parameter.GetIntegerAsShort(Parametros.DEFAULT_MONEDA_ID))
        If MonedaLocal Is Nothing Then
            Me.Cursor = Cursors.WaitCursor
            MsgBox("No se ha especificado la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
            Exit Sub
        End If
        MonedaLocalCotizacion = dbContext.MonedaCotizacion.Where(Function(mc) mc.IDMoneda = MonedaLocal.IDMoneda).FirstOrDefault
        If MonedaLocalCotizacion Is Nothing Then
            Me.Cursor = Cursors.WaitCursor
            MsgBox("No hay cotizaciones cargadas para la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
            Exit Sub
        End If

        ' Intento realizar la Autenticación en el Servidor de AFIP
        AFIP_TicketAcceso = CSM_AFIP_WS.Login(WSAA_URL, InternetProxy, CSM_AFIP.SERVICIO_FACTURACION_ECLECTRONICA, My.Settings.AFIP_WS_Certificado, My.Settings.AFIP_WS_ClavePrivada, LogPath, LogFileName)
        If AFIP_TicketAcceso <> "" Then
            For Each FacturaActual As ComprobanteCabecera In listComprobantes
                If FacturaActual.CAE Is Nothing Then
                    AFIP_Factura = New CSM_AFIP_WS.FacturaElectronicaCabecera
                    With AFIP_Factura
                        .Concepto = ArticuloActual.IDConcepto

                        ' Documento del Titular
                        .TipoDocumento = CShort(FacturaActual.IDDocumentoTipo)
                        .DocumentoNumero = CLng(FacturaActual.DocumentoNumero)

                        ' Tipo de Comprobante
                        If FacturaActual.IDComprobanteTipo <> ComprobanteTipoActual.IDComprobanteTipo Then
                            ComprobanteTipoActual = dbContext.ComprobanteTipo.Find(FacturaActual.IDComprobanteTipo)
                        End If
                        .TipoComprobante = ComprobanteTipoActual.CodigoAFIP

                        ' Datos de la Cabecera
                        .PuntoVenta = CShort(FacturaActual.PuntoVenta)
                        .ComprobanteDesde = CInt(FacturaActual.Numero)
                        .ComprobanteHasta = CInt(FacturaActual.Numero)
                        .ComprobanteFecha = FacturaActual.Fecha

                        ' Importes
                        .ImporteTotal = FacturaActual.ImporteTotal
                        .ImporteTotalConc = 0
                        .ImporteNeto = FacturaActual.ImporteTotal
                        .ImporteOperacionesExentas = 0
                        .ImporteTributos = 0
                        .ImporteIVA = FacturaActual.ImporteImpuesto

                        ' Fechas
                        .FechaServicioDesde = FacturaActual.FechaServicioDesde.Value
                        .FechaServicioHasta = FacturaActual.FechaServicioHasta.Value
                        .FechaVencimientoPago = FacturaActual.FechaVencimiento

                        ' Moneda
                        .MonedaID = MonedaLocal.CodigoAFIP
                        .MonedaCotizacion = MonedaLocalCotizacion.Cotizacion
                    End With

                    ' Obtengo el CAE
                    ResultadoCAE = CSM_AFIP_WS.ObtenerCAEFacturaElectronica(AFIP_TicketAcceso, WSFEv1_URL, InternetProxy, CUIT_Emisor, AFIP_Factura, LogPath, LogFileName)
                    If Not ResultadoCAE Is Nothing Then
                        If ResultadoCAE.Resultado = CSM_AFIP_WS.SOLICITUD_CAE_RESULTADO_ACEPTADO Then
                            dbContext.ComprobanteCabecera.Attach(FacturaActual)

                            FacturaActual.CAE = ResultadoCAE.Numero
                            FacturaActual.CAEVencimiento = ResultadoCAE.FechaVencimiento
                            FacturaActual.IDUsuarioTransmision = pUsuario.IDUsuario
                            FacturaActual.FechaHoraTransmision = Now

                            dbContext.SaveChanges()
                        Else
                            MensajeError = "Se Rechazó la Solicitud de CAE para la Factura Electrónica:"
                            MensajeError &= vbCrLf & vbCrLf
                            MensajeError &= "Factura N°: " & FacturaActual.Numero
                            MensajeError &= vbCrLf
                            MensajeError &= "Titular:    " & FacturaActual.Entidad.ApellidoNombre
                            MensajeError &= vbCrLf
                            MensajeError &= "Importe:    " & FormatCurrency(FacturaActual.ImporteTotal)
                            If ResultadoCAE.Observaciones <> "" Then
                                MensajeError &= vbCrLf & vbCrLf
                                MensajeError &= "Observaciones: " & ResultadoCAE.Observaciones
                            End If
                            If ResultadoCAE.ErrorMessage <> "" Then
                                MensajeError &= vbCrLf & vbCrLf
                                MensajeError &= "Error: " & ResultadoCAE.ErrorMessage
                            End If
                            MsgBox(MensajeError, MsgBoxStyle.Exclamation, My.Application.Info.Title)
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                End If
            Next
        End If

        Me.Cursor = Cursors.Default
    End Sub
End Class