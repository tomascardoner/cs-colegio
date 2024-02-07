Public Class formComprobantesTransmitirAFIP

#Region "Declarations"
    Private dbContext As New CSColegioContext(True)
    Private listComprobantes As List(Of GridDataRow)
    Private mCancelar As Boolean

    Private Class GridDataRow
        Public Property IDComprobante As Integer
        Public Property ComprobanteTipoNombre As String
        Public Property NumeroCompleto As String
        Public Property ApellidoNombre As String
        Public Property ImporteTotal As Decimal
    End Class
#End Region

#Region "Form stuff"

    Private Sub SetAppearance()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.IMAGE_COMPROBANTES_32)
    End Sub

    Private Sub formComprobantesTransmitirAFIP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetAppearance()

        buttonTransmitir.Enabled = False
        comboboxCantidad.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, "500", "200", "100", "50", "20", "10", "5", "1"})
    End Sub

    Private Sub formComprobantesTransmitirAFIP_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbContext.Dispose()
    End Sub
#End Region

#Region "Mostrar y leer datos"
    Private Sub RefreshData()
        Me.Cursor = Cursors.WaitCursor

        Try

            Select Case comboboxCantidad.SelectedIndex
                Case 0  ' Todos
                    listComprobantes = (From c In dbContext.Comprobante
                                        Join ct In dbContext.ComprobanteTipo On c.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                        Where ct.EmisionElectronica AndAlso c.CAE Is Nothing AndAlso c.IDUsuarioAnulacion Is Nothing
                                        Order By ct.Nombre, c.NumeroCompleto
                                        Select New GridDataRow With {.IDComprobante = c.IDComprobante, .ComprobanteTipoNombre = ct.Nombre, .NumeroCompleto = c.NumeroCompleto, .ApellidoNombre = c.ApellidoNombre, .ImporteTotal = c.ImporteTotal1}).ToList

                Case Is > 0 ' Cantidad de Comprobantes
                    listComprobantes = (From c In dbContext.Comprobante
                                        Join ct In dbContext.ComprobanteTipo On c.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                        Where ct.EmisionElectronica AndAlso c.CAE Is Nothing AndAlso c.IDUsuarioAnulacion Is Nothing
                                        Order By ct.Nombre, c.PuntoVenta, c.Numero
                                        Select New GridDataRow With {.IDComprobante = c.IDComprobante, .ComprobanteTipoNombre = ct.Nombre, .NumeroCompleto = c.NumeroCompleto, .ApellidoNombre = c.ApellidoNombre, .ImporteTotal = c.ImporteTotal1}).Take(CInt(comboboxCantidad.Text)).ToList

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
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener la lista de Comprobantes.")
        End Try

        Me.Cursor = Cursors.Default

        buttonTransmitir.Enabled = (listComprobantes.Count > 0)
    End Sub

#End Region

#Region "Controls behavior"

    Private Sub comboboxLote_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboboxCantidad.SelectedIndexChanged
        RefreshData()
    End Sub

    Private Sub Transmitir_Click(sender As Object, e As EventArgs) Handles buttonTransmitir.Click
        If listComprobantes.Count > 0 Then
            Dim Objeto_AFIP_WS As New CardonerSistemas.AfipWebServices.WebService
            Dim GridDataRowActual As GridDataRow
            Dim ComprobanteActual As Comprobante
            Dim MensajeError As String
            Dim GenerarCodigoQR As Boolean
            Dim idMoneda As Short
            Dim monedaCodigoAfip As String = ""
            Dim monedaCotizacion As Decimal
            Dim comprobanteTipoCodigoAfip As Short = 0
            Dim comprobantesEnviadosCount As Integer = 0

            GenerarCodigoQR = CS_Parameter_System.GetBoolean(Parametros.AFIP_COMPROBANTES_CODIGOQR_GENERAR, False).Value
            If GenerarCodigoQR Then
                Dim monedaActual As Moneda
                Dim monedaCotizacionActual As MonedaCotizacion

                ' Moneda
                monedaActual = dbContext.Moneda.Find(CS_Parameter_System.GetIntegerAsShort(Parametros.DEFAULT_MONEDA_ID))
                If monedaActual Is Nothing Then
                    MsgBox("No se ha especificado la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
                    Return
                End If
                idMoneda = monedaActual.IDMoneda
                monedaCodigoAfip = monedaActual.CodigoAFIP
                monedaActual = Nothing

                ' Cotización
                monedaCotizacionActual = dbContext.MonedaCotizacion.Where(Function(mc) mc.IDMoneda = idMoneda).FirstOrDefault
                If monedaCotizacionActual Is Nothing Then
                    MsgBox("No hay cotizaciones cargadas para la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
                    Return
                End If
                monedaCotizacion = monedaCotizacionActual.CotizacionVenta
            End If

            If ModuloComprobantes.TransmitirAFIP_Inicializar(Objeto_AFIP_WS, pAfipWebServicesConfig.ModoHomologacion) Then
                Me.Cursor = Cursors.WaitCursor
                Application.DoEvents()

                MostrarOcultarEstado(True)
                mCancelar = False
                textboxStatus.Text = "Estableciendo conexión y autenticando con el Servidor de AFIP..."

                If ModuloComprobantes.TransmitirAFIP_IniciarSesion(Objeto_AFIP_WS) Then
                    textboxStatus.AppendText("OK")

                    textboxStatus.AppendText(vbCrLf & "Creando conexión al Servicio de Factura Electrónica...")
                    If ModuloComprobantes.TransmitirAFIP_ConectarServicio(Objeto_AFIP_WS) Then
                        textboxStatus.AppendText("OK")

                        For Each RowActual As DataGridViewRow In datagridviewComprobantes.Rows
                            ' Hago que la grilla vaya mostrando la fila que se está procesando
                            datagridviewComprobantes.CurrentCell = RowActual.Cells(0)
                            GridDataRowActual = CType(RowActual.DataBoundItem, GridDataRow)
                            ComprobanteActual = dbContext.Comprobante.Find(GridDataRowActual.IDComprobante)
                            If Not ComprobanteActual Is Nothing Then
                                If ComprobanteActual.CAE Is Nothing Then
                                    textboxStatus.AppendText(vbCrLf & String.Format("{0} n° {1} - Autorizando...", ComprobanteActual.ComprobanteTipo.Nombre, ComprobanteActual.NumeroCompleto))
                                    If ModuloComprobantes.TransmitirAFIP_Comprobante(Objeto_AFIP_WS, ComprobanteActual.IDComprobante) Then
                                        progressbarStatus.Value += 1
                                        If GenerarCodigoQR Then
                                            comprobantesEnviadosCount += 1
                                            textboxStatus.AppendText("CAE: " & Objeto_AFIP_WS.UltimoResultadoCAE.Numero & " - Obteniendo código QR...")
                                            Application.DoEvents()
                                            If ModuloComprobantes.GenerarCodigoQR(ComprobanteActual.IDComprobante, , idMoneda, monedaCodigoAfip, monedaCotizacion) Then
                                                textboxStatus.AppendText("OK")
                                            Else
                                                textboxStatus.AppendText("ERROR")
                                                MensajeError = "Error al obtener el código QR del comprobante electrónico:"
                                                MensajeError &= vbCrLf & vbCrLf
                                                MensajeError &= String.Format("{0} N°: {1}", ComprobanteActual.ComprobanteTipo.Nombre, ComprobanteActual.Numero)
                                                MsgBox(MensajeError, MsgBoxStyle.Exclamation, My.Application.Info.Title)
                                                RefreshData()
                                                MostrarOcultarEstado(False)
                                                Me.Cursor = Cursors.Default
                                                Exit Sub
                                            End If
                                        Else
                                            comprobantesEnviadosCount += 1
                                            textboxStatus.AppendText("CAE: " & Objeto_AFIP_WS.UltimoResultadoCAE.Numero)
                                            Application.DoEvents()
                                        End If

                                    ElseIf Objeto_AFIP_WS.UltimoResultadoCAE.Resultado = CardonerSistemas.AfipWebServices.SolicitudCaeResultadoAceptado Then
                                        textboxStatus.AppendText("RECHAZADO!!")

                                        MensajeError = "Se Rechazó la Solicitud de CAE para el Comprobante Electrónico:"
                                        MensajeError &= vbCrLf & vbCrLf
                                        MensajeError &= String.Format("{0} N°: {1}", ComprobanteActual.ComprobanteTipo.Nombre, ComprobanteActual.Numero)
                                        MensajeError &= vbCrLf
                                        MensajeError &= "Titular: " & ComprobanteActual.ApellidoNombre
                                        MensajeError &= vbCrLf
                                        MensajeError &= "Importe: " & FormatCurrency(ComprobanteActual.ImporteTotal1)
                                        If Objeto_AFIP_WS.UltimoResultadoCAE.Observaciones <> "" Then
                                            MensajeError &= vbCrLf & vbCrLf
                                            MensajeError &= "Observaciones: " & Objeto_AFIP_WS.UltimoResultadoCAE.Observaciones
                                        End If
                                        If Objeto_AFIP_WS.UltimoResultadoCAE.ErrorMessage <> "" Then
                                            MensajeError &= vbCrLf & vbCrLf
                                            MensajeError &= "Error: " & Objeto_AFIP_WS.UltimoResultadoCAE.ErrorMessage
                                        End If
                                        MsgBox(MensajeError, MsgBoxStyle.Exclamation, My.Application.Info.Title)
                                        RefreshData()
                                        MostrarOcultarEstado(False)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    Else
                                        RefreshData()
                                        MostrarOcultarEstado(False)
                                        Me.Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                End If
                            End If
                            ' Verifico que no se cancele la Transmisión
                            Application.DoEvents()
                            If mCancelar Then
                                Exit For
                            End If
                        Next
                        If mCancelar Then
                            MsgBox(String.Format("Se ha cancelado la transmisión.{1}{1}Se transmitieron exitosamente {0} Comprobantes a AFIP.", comprobantesEnviadosCount, vbCrLf), MsgBoxStyle.Information, My.Application.Info.Title)
                        Else
                            MsgBox(String.Format("Se han transmitido exitosamente {0} Comprobantes a AFIP.", comprobantesEnviadosCount, vbCrLf), MsgBoxStyle.Information, My.Application.Info.Title)
                        End If

                        RefreshData()
                        MostrarOcultarEstado(False)
                        Me.Cursor = Cursors.Default
                    Else
                        RefreshData()
                        MostrarOcultarEstado(False)
                        Me.Cursor = Cursors.Default
                    End If
                Else
                    MostrarOcultarEstado(False)
                    Me.Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub Cancelar_Click() Handles buttonCancelar.Click
        mCancelar = True
    End Sub

#End Region

#Region "Extra stuff"

    Private Sub MostrarOcultarEstado(ByVal Mostrar As Boolean)
        buttonTransmitir.Visible = Not Mostrar
        buttonCancelar.Visible = Mostrar
        If Mostrar Then
            datagridviewComprobantes.Height = 270
            progressbarStatus.Maximum = listComprobantes.Count
            progressbarStatus.Value = 0
            textboxStatus.Text = ""
        Else
            datagridviewComprobantes.Height = 408
        End If
        groupboxStatus.Visible = Mostrar
    End Sub

#End Region

End Class