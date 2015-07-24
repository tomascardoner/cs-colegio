Public Class formComprobantesTransmitirAFIP
    Private dbcontext As New CSColegioContext(True)
    Private listComprobantes As List(Of GridDataRow)

    Private Class GridDataRow
        Public Property IDComprobante As Integer
        Public Property IDComprobanteLote As Integer
        Public Property LoteNombre As String
        Public Property ComprobanteTipoNombre As String
        Public Property NumeroCompleto As String
        Public Property ApellidoNombre As String
        Public Property ImporteTotal As Decimal
    End Class

    Private Sub formComprobantesTransmitirAFIP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buttonTransmitir.Enabled = False
        comboboxCantidad.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, "Lote (primero pendiente)", "100", "50", "20", "10", "5", "1"})
    End Sub

    Private Sub formComprobantesTransmitirAFIP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbcontext.Dispose()
    End Sub

    Private Sub comboboxLote_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboboxCantidad.SelectedIndexChanged
        RefreshData()
    End Sub

    Private Sub RefreshData()
        Dim PrimerLotePendiente As ComprobanteLote

        Me.Cursor = Cursors.WaitCursor

        Try

            Select Case comboboxCantidad.SelectedIndex
                Case 0  ' Todos
                    listComprobantes = (From cc In dbcontext.Comprobante
                                        Join cl In dbcontext.ComprobanteLote On cc.IDComprobanteLote Equals cl.IDComprobanteLote
                                        Join ct In dbcontext.ComprobanteTipo On cc.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                        Where ct.EmisionElectronica And cc.CAE Is Nothing
                                        Order By ct.Nombre, cc.NumeroCompleto
                                        Select New GridDataRow With {.IDComprobante = cc.IDComprobante, .IDComprobanteLote = cc.IDComprobanteLote.Value, .LoteNombre = cl.Nombre, .ComprobanteTipoNombre = ct.Nombre, .NumeroCompleto = cc.NumeroCompleto, .ApellidoNombre = cc.ApellidoNombre, .ImporteTotal = cc.ImporteTotal}).ToList

                Case 1  ' Primer Lote pendiente
                    ' Busco el primer Lote a partir de los Comprobantes pendientes
                    PrimerLotePendiente = (From cc In dbcontext.Comprobante
                                           Join cl In dbcontext.ComprobanteLote On cc.IDComprobanteLote Equals cl.IDComprobanteLote
                                           Join ct In dbcontext.ComprobanteTipo On cc.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                           Where ct.EmisionElectronica And cc.CAE Is Nothing
                                           Order By cc.IDComprobanteLote
                                           Select cl).FirstOrDefault

                    If PrimerLotePendiente Is Nothing Then
                        listComprobantes = Nothing
                    Else
                        listComprobantes = (From cc In dbcontext.Comprobante
                                            Join cl In dbcontext.ComprobanteLote On cc.IDComprobanteLote Equals cl.IDComprobanteLote
                                            Join ct In dbcontext.ComprobanteTipo On cc.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                            Where cc.IDComprobanteLote = PrimerLotePendiente.IDComprobanteLote = ct.EmisionElectronica And cc.CAE Is Nothing
                                            Order By ct.Nombre, cc.PuntoVenta, cc.Numero
                                            Select New GridDataRow With {.IDComprobante = cc.IDComprobante, .IDComprobanteLote = cc.IDComprobanteLote.Value, .LoteNombre = cl.Nombre, .ComprobanteTipoNombre = ct.Nombre, .NumeroCompleto = cc.NumeroCompleto, .ApellidoNombre = cc.ApellidoNombre, .ImporteTotal = cc.ImporteTotal}).ToList
                    End If

                Case 2 To 7 ' Cantidad de Comprobantes
                    listComprobantes = (From cc In dbcontext.Comprobante
                                        Join cl In dbcontext.ComprobanteLote On cc.IDComprobanteLote Equals cl.IDComprobanteLote
                                        Join ct In dbcontext.ComprobanteTipo On cc.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                        Where ct.EmisionElectronica And cc.CAE Is Nothing
                                        Order By ct.Nombre, cc.PuntoVenta, cc.Numero
                                        Select New GridDataRow With {.IDComprobante = cc.IDComprobante, .IDComprobanteLote = cc.IDComprobanteLote.Value, .LoteNombre = cl.Nombre, .ComprobanteTipoNombre = ct.Nombre, .NumeroCompleto = cc.NumeroCompleto, .ApellidoNombre = cc.ApellidoNombre, .ImporteTotal = cc.ImporteTotal}).Take(CInt(comboboxCantidad.Text)).ToList

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
        Dim FacturaActual As Comprobante
        Dim ArticuloActual As Articulo
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
        ArticuloActual = dbcontext.Articulo.Find(CS_Parameter.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_ARTICULO_ID))
        If ArticuloActual Is Nothing Then
            Me.Cursor = Cursors.WaitCursor
            MsgBox("No se ha especificado el Artículo correspondiente a las cuotas mensuales.", vbExclamation, My.Application.Info.Title)
            Exit Sub
        End If
        MonedaLocal = dbcontext.Moneda.Find(CS_Parameter.GetIntegerAsShort(Parametros.DEFAULT_MONEDA_ID))
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

        textboxStatus.Text &= "OK"

        For Each RowActual As DataGridViewRow In datagridviewComprobantes.Rows
            ' Hago que la grilla vaya mostrando la fila que se está procesando
            datagridviewComprobantes.CurrentCell = RowActual.Cells(0)
            GridDataRowActual = CType(RowActual.DataBoundItem, GridDataRow)
            FacturaActual = dbcontext.Comprobante.Find(GridDataRowActual.IDComprobante)
            If Not FacturaActual Is Nothing Then
                If Not FacturaActual.CAE Is Nothing Then
                    ' La Factura ya tiene un CAE asignado. Esto no debería pasar, excepto que otra instancia de la Aplicación haya obtenido el CAE mientras esta ventana estaba abierta
                    textboxStatus.Text &= vbCrLf & String.Format("La {0} N° {1} ya tiene una C.A.E. asignado, por lo tanto, no se trasnmitirá.", FacturaActual.ComprobanteTipo.Nombre, FacturaActual.Numero)
                Else
                    AFIP_Factura = New CS_AFIP_WS.FacturaElectronicaCabecera
                    With AFIP_Factura
                        .Concepto = ArticuloActual.IDConcepto

                        ' Documento del Titular
                        .TipoDocumento = CShort(FacturaActual.IDDocumentoTipo)
                        .DocumentoNumero = CLng(FacturaActual.DocumentoNumero)

                        ' Tipo de Comprobante
                        If FacturaActual.IDComprobanteTipo <> ComprobanteTipoActual.IDComprobanteTipo Then
                            ComprobanteTipoActual = dbcontext.ComprobanteTipo.Find(FacturaActual.IDComprobanteTipo)
                        End If
                        .TipoComprobante = ComprobanteTipoActual.CodigoAFIP

                        ' Datos de la Cabecera
                        .PuntoVenta = CShort(FacturaActual.PuntoVenta)
                        .ComprobanteDesde = CInt(FacturaActual.Numero)
                        .ComprobanteHasta = CInt(FacturaActual.Numero)
                        .ComprobanteFecha = FacturaActual.FechaEmision

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
                        .FechaVencimientoPago = FacturaActual.FechaVencimiento.Value

                        ' Moneda
                        .MonedaID = MonedaLocal.CodigoAFIP
                        .MonedaCotizacion = MonedaLocalCotizacion.Cotizacion
                    End With

                    ' Obtengo el CAE
                    textboxStatus.Text &= vbCrLf & String.Format("Solicitando el C.A.E. para la {0} N° {1}...", FacturaActual.ComprobanteTipo.Nombre, FacturaActual.Numero)
                    ResultadoCAE = CS_AFIP_WS.ObtenerCAEFacturaElectronica(AFIP_TicketAcceso, WSFEv1_URL, InternetProxy, CUIT_Emisor, AFIP_Factura, LogPath, LogFileName)
                    If ResultadoCAE Is Nothing Then
                        RefreshData()
                        MostrarOcultarEstado(False)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                    If ResultadoCAE.Resultado = CS_AFIP_WS.SOLICITUD_CAE_RESULTADO_ACEPTADO Then
                        progressbarStatus.Value += 1
                        textboxStatus.Text &= "OK - CAE: " & ResultadoCAE.Numero

                        dbcontext.Comprobante.Attach(FacturaActual)

                        FacturaActual.CAE = ResultadoCAE.Numero
                        FacturaActual.CAEVencimiento = ResultadoCAE.FechaVencimiento
                        FacturaActual.IDUsuarioTransmision = pUsuario.IDUsuario
                        FacturaActual.FechaHoraTransmision = DateTime.Now

                        dbcontext.SaveChanges()
                    Else
                        textboxStatus.Text &= "RECHAZADO!!"

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