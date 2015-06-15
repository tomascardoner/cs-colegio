Public Class TempDepot


    Private Sub TransmitirComprobantes()
        '    Dim AFIP_TicketAcceso As String
        '    Dim AFIP_Factura As CSM_AFIP_WS.FacturaElectronicaCabecera
        '    Dim CAE As String

        '    Dim ArticuloActual As Articulo
        '    Dim MonedaLocal As Moneda
        '    Dim MonedaLocalCotizacion As MonedaCotizacion
        '    Dim ComprobanteTipoActual As New ComprobanteTipo

        '    Dim MesAFacturarFechaInicio As Date
        '    Dim MesAFacturarFechaFin As Date
        '    Dim FacturaVencimiento As Date

        '    Me.Cursor = Cursors.WaitCursor
        '    Application.DoEvents()

        '    ' Leo los valores comunes a todas las facturas
        '    ArticuloActual = dbcColegio.Articulo.Find(CSM_Parameter.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_ARTICULO_ID))
        '    If ArticuloActual Is Nothing Then
        '        Me.Cursor = Cursors.WaitCursor
        '        MsgBox("No se ha especificado el Artículo correspondiente a las cuotas mensuales.", vbExclamation, My.Application.Info.Title)
        '        Exit Sub
        '    End If
        '    MonedaLocal = dbcColegio.Moneda.Find(CSM_Parameter.GetIntegerAsShort(Parametros.DEFAULT_MONEDA_ID))
        '    If MonedaLocal Is Nothing Then
        '        Me.Cursor = Cursors.WaitCursor
        '        MsgBox("No se ha especificado la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
        '        Exit Sub
        '    End If
        '    MonedaLocalCotizacion = dbcColegio.MonedaCotizacion.Where(Function(mc) mc.IDMoneda = MonedaLocal.IDMoneda).FirstOrDefault
        '    If MonedaLocalCotizacion Is Nothing Then
        '        Me.Cursor = Cursors.WaitCursor
        '        MsgBox("No hay cotizaciones cargadas para la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
        '        Exit Sub
        '    End If
        '    MesAFacturarFechaInicio = New Date(AnioLectivo, MesAFacturar, 1)
        '    MesAFacturarFechaFin = MesAFacturarFechaInicio.AddMonths(1).AddDays(-1)
        '    FacturaVencimiento = New Date(AnioLectivo, MesAFacturar, CSM_Parameter.GetIntegerAsByte(Parametros.CUOTA_MENSUAL_VENCIMIENTO_DIA))

        '    ' Intento realizar la Autenticación en el Servidor de AFIP
        '    AFIP_TicketAcceso = CSM_AFIP_WS.Login(CSM_Parameter.GetString(Parametros.AFIP_WS_AA_HOMOLOGACION), "", CSM_AFIP.SERVICIO_FACTURACION_ECLECTRONICA, My.Settings.AFIP_Certificado, My.Settings.AFIP_ClavePrivada, formMDIMain.menuitemDebugAFIPWSHabilitarRegistro.Checked)
        '    If AFIP_TicketAcceso <> "" Then
        '        For Each FacturaActual In listFacturas
        '            AFIP_Factura = New CSM_AFIP_WS.FacturaElectronicaCabecera
        '            With AFIP_Factura
        '                .Concepto = ArticuloActual.IDConcepto

        '                ' Documento del Titular
        '                .TipoDocumento = CShort(FacturaActual.IDDocumentoTipo)
        '                .DocumentoNumero = CInt(FacturaActual.DocumentoNumero)

        '                ' Tipo de Comprobante
        '                If FacturaActual.IDComprobanteTipo <> ComprobanteTipoActual.IDComprobanteTipo Then
        '                    ComprobanteTipoActual = dbcColegio.ComprobanteTipo.Find(FacturaActual.IDComprobanteTipo)
        '                End If
        '                .TipoComprobante = ComprobanteTipoActual.CodigoAFIP

        '                ' Datos de la Cabecera
        '                .PuntoVenta = CShort(FacturaActual.PuntoVenta)
        '                .ComprobanteDesde = FacturaActual.IDComprobante
        '                .ComprobanteHasta = FacturaActual.IDComprobante
        '                .ComprobanteFecha = FacturaActual.Fecha

        '                ' Importes
        '                .ImporteTotal = FacturaActual.ImporteTotal
        '                .ImporteTotalConc = 0
        '                .ImporteNeto = FacturaActual.ImporteTotal
        '                .ImporteOperacionesExentas = 0
        '                .ImporteTributos = 0
        '                .ImporteIVA = FacturaActual.ImporteImpuesto

        '                ' Fechas
        '                .FechaServicioDesde = MesAFacturarFechaInicio
        '                .FechaServicioHasta = MesAFacturarFechaFin
        '                .FechaVencimientoPago = FacturaVencimiento

        '                ' Moneda
        '                .MonedaID = MonedaLocal.CodigoAFIP
        '                .MonedaCotizacion = MonedaLocalCotizacion.Cotizacion
        '            End With
        '            CAE = CSM_AFIP_WS.CrearFacturaElectronica(AFIP_TicketAcceso, CSM_Parameter.GetString(Parametros.AFIP_WS_FE_HOMOLOGACION), "", "30710717946", AFIP_Factura, formMDIMain.menuitemDebugAFIPWSHabilitarRegistro.Checked)
        '            If CAE = "" Then
        '                Exit For
        '            End If
        '        Next
        '    End If

        '    Me.Cursor = Cursors.Default
    End Sub

End Class