Public Class formTransmitirComprobantesAFIP
    Private listComprobantes As List(Of ComprobanteCabecera)

    Private Sub formTransmitirComprobantesAFIP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buttonTransmitir.Enabled = False
        FillAndRefreshLists.ComprobanteLote(comboboxLote, False, False)
    End Sub

    Private Sub comboboxLote_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboboxLote.SelectedIndexChanged
        Dim IDLoteFiltro As Integer

        If comboboxLote.SelectedIndex > -1 Then
            IDLoteFiltro = CInt(comboboxLote.SelectedValue)

            Using dbContext As New CSColegioContext
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
            End Using

            buttonTransmitir.Enabled = (listComprobantes.Count > 0)
        End If
    End Sub

    Private Sub buttonTransmitir_Click(sender As Object, e As EventArgs) Handles buttonTransmitir.Click
        If listComprobantes.Count > 0 Then
            TransmitirComprobantes()
        End If
    End Sub

    Private Sub TransmitirComprobantes()
        Dim AFIP_TicketAcceso As String
        Dim AFIP_Factura As CSM_AFIP_WS.FacturaElectronicaCabecera
        Dim CAE As String

        Dim InternetProxy As String
        Dim CUIT_Emisor As String
        Dim ArticuloActual As Articulo
        Dim MonedaLocal As Moneda
        Dim MonedaLocalCotizacion As MonedaCotizacion
        Dim ComprobanteTipoActual As New ComprobanteTipo

        Dim dbContext As New CSColegioContext

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        ' Leo los valores comunes a todas las facturas
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
        AFIP_TicketAcceso = CSM_AFIP_WS.Login(CSM_Parameter.GetString(Parametros.AFIP_WS_AA_HOMOLOGACION), InternetProxy, CSM_AFIP.SERVICIO_FACTURACION_ECLECTRONICA, My.Settings.AFIP_Certificado, My.Settings.AFIP_ClavePrivada, formMDIMain.menuitemDebugAFIPWSHabilitarRegistro.Checked)
        If AFIP_TicketAcceso <> "" Then
            For Each FacturaActual In listComprobantes
                AFIP_Factura = New CSM_AFIP_WS.FacturaElectronicaCabecera
                With AFIP_Factura
                    .Concepto = ArticuloActual.IDConcepto

                    ' Documento del Titular
                    .TipoDocumento = CShort(FacturaActual.IDDocumentoTipo)
                    .DocumentoNumero = CInt(FacturaActual.DocumentoNumero)

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

                CAE = CSM_AFIP_WS.CrearFacturaElectronica(AFIP_TicketAcceso, CSM_Parameter.GetString(Parametros.AFIP_WS_FE_HOMOLOGACION), InternetProxy, CUIT_Emisor, AFIP_Factura, formMDIMain.menuitemDebugAFIPWSHabilitarRegistro.Checked)
                If CAE = "" Then
                    Exit For
                Else
                    FacturaActual.Numero = CAE
                End If
            Next
        End If

        dbContext.Dispose()

        Me.Cursor = Cursors.Default
    End Sub
End Class