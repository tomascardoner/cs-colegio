Public Class formComprobantesTransmitirAFIP
    Private dbContext As New CSColegioContext(True)
    Private listComprobantes As List(Of GridDataRow)

    Private Class GridDataRow
        Public Property IDComprobante As Integer
        Public Property ComprobanteTipoNombre As String
        Public Property NumeroCompleto As String
        Public Property ApellidoNombre As String
        Public Property ImporteTotal As Decimal
    End Class

    Private Sub formComprobantesTransmitirAFIP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buttonTransmitir.Enabled = False
        comboboxCantidad.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, "500", "200", "100", "50", "20", "10", "5", "1"})
    End Sub

    Private Sub formComprobantesTransmitirAFIP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbcontext.Dispose()
    End Sub

    Private Sub comboboxLote_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboboxCantidad.SelectedIndexChanged
        RefreshData()
    End Sub

    Private Sub RefreshData()
        Me.Cursor = Cursors.WaitCursor

        Try

            Select Case comboboxCantidad.SelectedIndex
                Case 0  ' Todos
                    listComprobantes = (From c In dbContext.Comprobante
                                        Join ct In dbContext.ComprobanteTipo On c.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                        Where ct.EmisionElectronica And c.CAE Is Nothing
                                        Order By ct.Nombre, c.NumeroCompleto
                                        Select New GridDataRow With {.IDComprobante = c.IDComprobante, .ComprobanteTipoNombre = ct.Nombre, .NumeroCompleto = c.NumeroCompleto, .ApellidoNombre = c.ApellidoNombre, .ImporteTotal = c.ImporteTotal}).ToList

                Case Is > 0 ' Cantidad de Comprobantes
                    listComprobantes = (From c In dbContext.Comprobante
                                        Join ct In dbContext.ComprobanteTipo On c.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                        Where ct.EmisionElectronica And c.CAE Is Nothing
                                        Order By ct.Nombre, c.PuntoVenta, c.Numero
                                        Select New GridDataRow With {.IDComprobante = c.IDComprobante, .ComprobanteTipoNombre = ct.Nombre, .NumeroCompleto = c.NumeroCompleto, .ApellidoNombre = c.ApellidoNombre, .ImporteTotal = c.ImporteTotal}).Take(CInt(comboboxCantidad.Text)).ToList

            End Select

            datagridviewComprobantes.AutoGenerateColumns = False
            datagridviewComprobantes.DataSource = listComprobantes

            Select Case listComprobantes.Count
                Case 0
                    statuslabelMain.Text = String.Format("No hay Comprobantes para mostrar.")
                Case 1
                    statuslabelMain.Text = String.Format("Se muestra 1 Comprobante.")
                Case Else
                    statuslabelMain.Text = String.Format("Se muestran {0} Comprobantes.", listComprobantes.Count)
            End Select

        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al obtener la lista de Comprobantes.")
        End Try

        Me.Cursor = Cursors.Default

        buttonTransmitir.Enabled = (listComprobantes.Count > 0)
    End Sub

    Private Sub buttonTransmitir_Click(sender As Object, e As EventArgs) Handles buttonTransmitir.Click
        If listComprobantes.Count > 0 Then
            TransmitirComprobantes()
        End If
    End Sub

    Private Sub TransmitirComprobantes()
        Dim LogPath As String = ""
        Dim LogFileName As String = ""
        Dim Certificado As String
        Dim WSAA_URL As String
        Dim WSFEv1_URL As String
        Dim AFIP_TicketAcceso As String
        Dim AFIP_Factura As CS_AFIP_WS.FacturaElectronicaCabecera
        Dim ResultadoCAE As CS_AFIP_WS.ResultadoCAE
        Dim MensajeError As String

        Dim InternetProxy As String
        Dim CUIT_Emisor As String
        Dim GridDataRowActual As GridDataRow
        Dim ComprobanteActual As Comprobante
        Dim IDConcepto As Byte = 0
        Dim MonedaLocal As Moneda
        Dim MonedaLocalCotizacion As MonedaCotizacion
        Dim ComprobanteTipoActual As New ComprobanteTipo

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        If formMDIMain.menuitemDebugAFIPWSHabilitarRegistro.Checked Then
            LogPath = CS_SpecialFolders.ProcessString(My.Settings.AFIP_WS_LogFolder)
            If Not LogPath.EndsWith("\") Then
                LogPath &= "\"
            End If
            LogFileName = CS_File.ProcessFilename(My.Settings.AFIP_WS_LogFileName)
        End If

        ' Leo los valores comunes a todas las facturas
        If My.Settings.AFIP_WS_ModoHomologacion Then
            Certificado = My.Settings.AFIP_WS_Certificado_Homologacion
            WSAA_URL = CS_Parameter.GetString(Parametros.AFIP_WS_AA_HOMOLOGACION)
            WSFEv1_URL = CS_Parameter.GetString(Parametros.AFIP_WS_FE_HOMOLOGACION)
        Else
            Certificado = My.Settings.AFIP_WS_Certificado_Produccion
            WSAA_URL = CS_Parameter.GetString(Parametros.AFIP_WS_AA_PRODUCCION)
            WSFEv1_URL = CS_Parameter.GetString(Parametros.AFIP_WS_FE_PRODUCCION)
        End If

        InternetProxy = CS_Parameter.GetString(Parametros.INTERNET_PROXY, "")
        CUIT_Emisor = CS_Parameter.GetString(Parametros.EMPRESA_CUIT)
        MonedaLocal = dbContext.Moneda.Find(CS_Parameter.GetIntegerAsShort(Parametros.DEFAULT_MONEDA_ID))
        If MonedaLocal Is Nothing Then
            Me.Cursor = Cursors.WaitCursor
            MsgBox("No se ha especificado la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
            Exit Sub
        End If
        MonedaLocalCotizacion = dbcontext.MonedaCotizacion.Where(Function(mc) mc.IDMoneda = MonedaLocal.IDMoneda).FirstOrDefault
        If MonedaLocalCotizacion Is Nothing Then
            Me.Cursor = Cursors.WaitCursor
            MsgBox("No hay cotizaciones cargadas para la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
            Exit Sub
        End If

        MostrarOcultarEstado(True)
        textboxStatus.Text = "Estableciendo conexión y autenticando con el Servidor de AFIP..."

        ' Intento realizar la Autenticación en el Servidor de AFIP
        AFIP_TicketAcceso = CS_AFIP_WS.Login(WSAA_URL, InternetProxy, CS_AFIP_WS.SERVICIO_FACTURACION_ELECTRONICA, Certificado, My.Settings.AFIP_WS_ClavePrivada, LogPath, LogFileName)
        If AFIP_TicketAcceso = "" Then
            MostrarOcultarEstado(False)
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        textboxStatus.AppendText("OK")

        For Each RowActual As DataGridViewRow In datagridviewComprobantes.Rows
            ' Hago que la grilla vaya mostrando la fila que se está procesando
            datagridviewComprobantes.CurrentCell = RowActual.Cells(0)
            GridDataRowActual = CType(RowActual.DataBoundItem, GridDataRow)
            ComprobanteActual = dbContext.Comprobante.Find(GridDataRowActual.IDComprobante)
            If Not ComprobanteActual Is Nothing Then
                If Not ComprobanteActual.CAE Is Nothing Then
                    ' La Factura ya tiene un CAE asignado. Esto no debería pasar, excepto que otra instancia de la Aplicación haya obtenido el CAE mientras esta ventana estaba abierta
                    textboxStatus.AppendText(vbCrLf & String.Format("La {0} N° {1} ya tiene una C.A.E. asignado, por lo tanto, no se trasnmitirá.", ComprobanteActual.ComprobanteTipo.Nombre, ComprobanteActual.Numero))
                Else
                    AFIP_Factura = New CS_AFIP_WS.FacturaElectronicaCabecera
                    With AFIP_Factura

                        ' Todo esto es para determinar el Concepto a especificar en el pedido del CAE
                        If ComprobanteTipoActual.UtilizaDetalle AndAlso ComprobanteActual.ComprobanteDetalle.Count > 0 Then
                            For Each CDetalle As ComprobanteDetalle In ComprobanteActual.ComprobanteDetalle
                                Select Case IDConcepto
                                    Case CByte(0)
                                        ' Es el primer Artículo, así que lo guardo
                                        IDConcepto = CDetalle.Articulo.IDConcepto

                                    Case CDetalle.Articulo.IDConcepto
                                        ' Es el mismo Concepto que el/los Artículos anteriores, no hago nada

                                    Case Else
                                        If (IDConcepto = 1 Or IDConcepto = 2) And (CDetalle.Articulo.IDConcepto = 1 Or CDetalle.Articulo.IDConcepto = 2) Then
                                            ' Hay Productos y Servicios, así que utilizo el Concepto correspondiente
                                            IDConcepto = Constantes.COMPROBANTE_CONCEPTO_PRODUCTOSYSERVICIOS
                                            Exit For
                                        End If
                                End Select
                            Next
                        Else
                            IDConcepto = Constantes.COMPROBANTE_CONCEPTO_PRODUCTO
                        End If
                        .Concepto = IDConcepto

                        ' Documento del Titular
                        .TipoDocumento = CShort(ComprobanteActual.IDDocumentoTipo)
                        .DocumentoNumero = CLng(ComprobanteActual.DocumentoNumero)

                        ' Tipo de Comprobante
                        If ComprobanteActual.IDComprobanteTipo <> ComprobanteTipoActual.IDComprobanteTipo Then
                            ComprobanteTipoActual = dbContext.ComprobanteTipo.Find(ComprobanteActual.IDComprobanteTipo)
                        End If
                        .TipoComprobante = ComprobanteTipoActual.CodigoAFIP

                        ' Datos de la Cabecera
                        .PuntoVenta = CShort(ComprobanteActual.PuntoVenta)
                        .ComprobanteDesde = CInt(ComprobanteActual.Numero)
                        .ComprobanteHasta = CInt(ComprobanteActual.Numero)
                        .ComprobanteFecha = ComprobanteActual.FechaEmision

                        ' Importes
                        .ImporteTotal = ComprobanteActual.ImporteTotal
                        .ImporteTotalConc = 0
                        .ImporteNeto = ComprobanteActual.ImporteTotal
                        .ImporteOperacionesExentas = 0
                        .ImporteTributos = 0
                        .ImporteIVA = ComprobanteActual.ImporteImpuesto

                        ' Fechas
                        If ComprobanteActual.FechaServicioDesde.HasValue Then
                            .FechaServicioDesde = ComprobanteActual.FechaServicioDesde.Value
                        End If
                        If ComprobanteActual.FechaServicioHasta.HasValue Then
                            .FechaServicioHasta = ComprobanteActual.FechaServicioHasta.Value
                        End If
                        If ComprobanteActual.FechaVencimiento.HasValue Then
                            .FechaVencimientoPago = ComprobanteActual.FechaVencimiento.Value
                        End If

                        ' Moneda
                        .MonedaID = MonedaLocal.CodigoAFIP
                        .MonedaCotizacion = MonedaLocalCotizacion.Cotizacion

                        ' Comprobantes Asociados
                        For Each ComprobanteAsociacionActual As ComprobanteAsociacion In ComprobanteActual.ComprobanteAsociacion_Asociados
                            Dim AFIP_ComprobanteAsociado As New ComprobanteAsociado
                            AFIP_ComprobanteAsociado.TipoComprobante = ComprobanteAsociacionActual.ComprobanteAsociado.ComprobanteTipo.CodigoAFIP
                            AFIP_ComprobanteAsociado.ComprobanteNumero = CInt(ComprobanteAsociacionActual.ComprobanteAsociado.Numero)
                            AFIP_ComprobanteAsociado.PuntoVenta = CShort(ComprobanteAsociacionActual.ComprobanteAsociado.PuntoVenta)
                            .ComprobantesAsociados.Add(AFIP_ComprobanteAsociado)
                        Next
                    End With

                    ' Obtengo el CAE
                    textboxStatus.AppendText(vbCrLf & String.Format("Solicitando el C.A.E. para la {0} N° {1}...", ComprobanteActual.ComprobanteTipo.Nombre, ComprobanteActual.Numero))
                    ResultadoCAE = CS_AFIP_WS.FacturaElectronica_ObtenerCAE(AFIP_TicketAcceso, WSFEv1_URL, InternetProxy, CUIT_Emisor, AFIP_Factura, LogPath, LogFileName)
                    If ResultadoCAE Is Nothing Then
                        RefreshData()
                        MostrarOcultarEstado(False)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If ResultadoCAE.Resultado = CS_AFIP_WS.SOLICITUD_CAE_RESULTADO_ACEPTADO Then
                        progressbarStatus.Value += 1
                        textboxStatus.AppendText("OK - CAE: " & ResultadoCAE.Numero)

                        dbContext.Comprobante.Attach(ComprobanteActual)

                        ComprobanteActual.CAE = ResultadoCAE.Numero
                        ComprobanteActual.CAEVencimiento = ResultadoCAE.FechaVencimiento
                        ComprobanteActual.IDUsuarioTransmision = pUsuario.IDUsuario
                        ComprobanteActual.FechaHoraTransmision = DateTime.Now

                        dbContext.SaveChanges()
                    Else
                        textboxStatus.AppendText("RECHAZADO!!")

                        MensajeError = "Se Rechazó la Solicitud de CAE para el Comprobante Electrónico:"
                        MensajeError &= vbCrLf & vbCrLf
                        MensajeError &= String.Format("{0} N°: {1}", ComprobanteTipoActual.Nombre, ComprobanteActual.Numero)
                        MensajeError &= vbCrLf
                        MensajeError &= "Titular: " & ComprobanteActual.ApellidoNombre
                        MensajeError &= vbCrLf
                        MensajeError &= "Importe: " & FormatCurrency(ComprobanteActual.ImporteTotal)
                        If ResultadoCAE.Observaciones <> "" Then
                            MensajeError &= vbCrLf & vbCrLf
                            MensajeError &= "Observaciones: " & ResultadoCAE.Observaciones
                        End If
                        If ResultadoCAE.ErrorMessage <> "" Then
                            MensajeError &= vbCrLf & vbCrLf
                            MensajeError &= "Error: " & ResultadoCAE.ErrorMessage
                        End If
                        MsgBox(MensajeError, MsgBoxStyle.Exclamation, My.Application.Info.Title)
                        RefreshData()
                        MostrarOcultarEstado(False)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
            End If
        Next

        MsgBox(String.Format("Se han transmitido exitosamente {0} Comprobantes a AFIP.", listComprobantes.Count), MsgBoxStyle.Information, My.Application.Info.Title)

        RefreshData()
        MostrarOcultarEstado(False)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MostrarOcultarEstado(ByVal Mostrar As Boolean)
        If Mostrar Then
            datagridviewComprobantes.Height = 311
            progressbarStatus.Maximum = listComprobantes.Count
            progressbarStatus.Value = 0
            textboxStatus.Text = ""
        Else
            datagridviewComprobantes.Height = 449
        End If
        groupboxStatus.Visible = Mostrar
    End Sub
End Class