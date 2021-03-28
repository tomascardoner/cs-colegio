Public Class formComprobante

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)
    Private mComprobanteActual As Comprobante

    Private mComprobanteTipoActual As ComprobanteTipo
    Private mUtilizaNumerador As Boolean = False
    Private mComprobanteTipoPuntoVentaActual As ComprobanteTipoPuntoVenta
    Private mConceptoActual As New Concepto
    Private mEntidad As Entidad

    Private mIDArticuloMatricula As Short
    Private mIDArticuloMensual As Short

    Private mIsLoading As Boolean = False
    Private mEditMode As Boolean = False

    Public Class GridRowData_Aplicacion
        Public Property ComprobanteAplicacion As ComprobanteAplicacion
        Public Property Motivo As String
        Public Property ComprobanteTipoNombre As String
        Public Property MovimientoTipo As String
        Public Property NumeroCompleto As String
        Public Property FechaEmision As Date
        Public Property ImporteTotal As Decimal
        Public Property ImporteAplicado As Decimal
    End Class

    Public Class GridRowData_MedioPago
        Public Property ComprobanteMedioPago As ComprobanteMedioPago
        Public Property MedioPago As MedioPago
        Public Property MedioPagoNombre As String
        Public Property CajaNombre As String
        Public Property Importe As Decimal
        Public Property BancoNombre As String
        Public Property Numero As String
        Public Property FechaVencimiento As Date
    End Class
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByVal EditMode As Boolean, ByRef ParentForm As Form, ByVal IDComprobante As Integer)
        mIsLoading = True
        mEditMode = EditMode

        ' Antes que nada, cierro las ventanas hijas que pudieran haber quedado abiertas
        If CS_Form.MDIChild_IsLoaded(CType(pFormMDIMain, Form), "formComprobanteMedioPago") Then
            formComprobanteMedioPago.Close()
            formComprobanteMedioPago = Nothing
        End If

        If IDComprobante = 0 Then
            ' Es Nuevo
            mComprobanteActual = New Comprobante
            mComprobanteActual.FechaEmision = DateAndTime.Today
            mdbContext.Comprobante.Add(mComprobanteActual)
        Else
            mComprobanteActual = mdbContext.Comprobante.Find(IDComprobante)
        End If

        Me.MdiParent = pFormMDIMain
        CS_Form.CenterToParent(ParentForm, Me)
        InitializeFormAndControls()
        CardonerSistemas.ComboBox.SetSelectedValue(comboboxComprobanteTipo, CardonerSistemas.ComboBox.SelectedItemOptions.Value, mComprobanteActual.IDComprobanteTipo)
        CambiarTipoComprobante()
        SetDataFromObjectToControls()
        Me.Show()
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
        End If
        Me.Focus()

        mIsLoading = False

        ChangeMode()
    End Sub

    Private Sub ChangeMode()
        If mIsLoading Then
            Exit Sub
        End If

        If mComprobanteTipoActual Is Nothing Then
            buttonAFIP.Visible = False
        Else
            buttonAFIP.Visible = (mEditMode = False And mComprobanteTipoActual.EmisionElectronica And mComprobanteActual.IDUsuarioAnulacion Is Nothing)
            menuitemAFIP_ObtenerCAE.Enabled = (mComprobanteActual.CAE Is Nothing)
            menuitemAFIP_VerificarDatos.Enabled = (Not mComprobanteActual.CAE Is Nothing)
        End If
        buttonGuardar.Visible = mEditMode
        buttonCancelar.Visible = mEditMode
        buttonEditar.Visible = (mEditMode = False And mComprobanteActual.CAE Is Nothing And mComprobanteActual.IDUsuarioAnulacion Is Nothing)
        buttonCerrar.Visible = (mEditMode = False)

        comboboxComprobanteTipo.Enabled = (mEditMode And mComprobanteActual.ComprobanteDetalle.Count = 0 And mComprobanteActual.ComprobanteImpuesto.Count = 0 And mComprobanteActual.ComprobanteAplicacion_Aplicados.Count = 0 And mComprobanteActual.ComprobanteMedioPago.Count = 0)
        textboxPuntoVenta.ReadOnly = (mUtilizaNumerador Or mEditMode = False)
        textboxNumero.ReadOnly = (mUtilizaNumerador Or mEditMode = False)
        datetimepickerFechaEmision.Enabled = mEditMode

        datetimepickerFechaServicioDesde.Enabled = mEditMode
        datetimepickerFechaServicioHasta.Enabled = mEditMode
        datetimepickerFechaVencimiento.Enabled = mEditMode

        buttonEntidad.Enabled = (mEditMode And mComprobanteActual.ComprobanteAplicacion_Aplicados.Count = 0)

        toolstripDetalle.Enabled = mEditMode
        toolstripImpuestos.Enabled = mEditMode
        toolstripAplicaciones.Enabled = (mEditMode And comboboxComprobanteTipo.SelectedIndex > -1)
        toolstripMediosPago.Enabled = mEditMode

        textboxLeyenda.ReadOnly = (mEditMode = False)
        textboxNotas.ReadOnly = (mEditMode = False)

        'currencytextboxImporteTotal.ReadOnly = (comboboxComprobanteTipo.SelectedIndex <> -1 AndAlso (mComprobanteTipoActual.UtilizaDetalle Or mComprobanteTipoActual.UtilizaMedioPago))
    End Sub

    Friend Sub InitializeFormAndControls()
        SetAppearance()

        mIDArticuloMatricula = CS_Parameter_System.GetIntegerAsShort(Parametros.CUOTA_MATRICULA_ARTICULO_ID)
        mIDArticuloMensual = CS_Parameter_System.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_ARTICULO_ID)

        ' Cargo los ComboBox
        pFillAndRefreshLists.ComprobanteTipo(comboboxComprobanteTipo, Nothing, False, False)
    End Sub

    Friend Sub SetAppearance()
        menuitemAFIP_ObtenerQR.Visible = CS_Parameter_System.GetBoolean(Parametros.AFIP_COMPROBANTES_CODIGOQR_GENERAR, False).Value

        datagridviewDetalle.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        datagridviewDetalle.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont

        datagridviewImpuestos.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        datagridviewImpuestos.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont

        datagridviewAplicaciones.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        datagridviewAplicaciones.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont

        datagridviewMediosPago.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        datagridviewMediosPago.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont
    End Sub

    Private Sub formComprobante_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        mComprobanteActual = Nothing
        mComprobanteTipoActual = Nothing
        mComprobanteTipoPuntoVentaActual = Nothing
        mEntidad = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Load and Set Data"

    Friend Sub SetDataFromObjectToControls()
        With mComprobanteActual
            ' Datos de la Identificación
            If .IDComprobante = 0 Then
                textboxIDComprobante.Text = My.Resources.STRING_ITEM_NEW_MALE
            Else
                textboxIDComprobante.Text = String.Format(.IDComprobante.ToString, "G")
            End If
            CardonerSistemas.ComboBox.SetSelectedValue(comboboxComprobanteTipo, CardonerSistemas.ComboBox.SelectedItemOptions.Value, .IDComprobanteTipo)
            textboxPuntoVenta.Text = .PuntoVenta
            textboxNumero.Text = .Numero
            datetimepickerFechaEmision.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaEmision, datetimepickerFechaEmision)

            ' Fechas
            datetimepickerFechaVencimiento.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaVencimiento1, datetimepickerFechaVencimiento)
            datetimepickerFechaServicioDesde.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaServicioDesde, datetimepickerFechaServicioDesde)
            datetimepickerFechaServicioHasta.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaServicioHasta, datetimepickerFechaServicioHasta)

            ' Entidad
            If Not .Entidad Is Nothing Then
                mEntidad = .Entidad
                textboxEntidad.Text = .Entidad.ApellidoNombre
                textboxEntidad.Tag = .Entidad.IDEntidad
            Else
                textboxEntidad.Text = ""
                textboxEntidad.Tag = Nothing
            End If

            ' Datos de la pestaña Detalle
            datagridviewDetalle.AutoGenerateColumns = False
            datagridviewDetalle.DataSource = mComprobanteActual.ComprobanteDetalle.ToList

            ' Datos de la pestaña Notas y Auditoría
            textboxLeyenda.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Leyenda)
            textboxNotas.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Notas)
            If .UsuarioCreacion Is Nothing Then
                textboxFechaHoraCreacion.Text = ""
                textboxUsuarioCreacion.Text = ""
            Else
                textboxFechaHoraCreacion.Text = .FechaHoraCreacion.ToShortDateString & " " & .FechaHoraCreacion.ToShortTimeString
                textboxUsuarioCreacion.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.UsuarioCreacion.Descripcion)
            End If
            If .UsuarioModificacion Is Nothing Then
                textboxFechaHoraModificacion.Text = ""
                textboxUsuarioModificacion.Text = ""
            Else
                textboxFechaHoraModificacion.Text = .FechaHoraModificacion.ToShortDateString & " " & .FechaHoraModificacion.ToShortTimeString
                textboxUsuarioModificacion.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.UsuarioModificacion.Descripcion)
            End If
            If .UsuarioEnvioEmail Is Nothing Then
                textboxFechaHoraEnvioEmail.Text = ""
                textboxUsuarioEnvioEmail.Text = ""
            Else
                If Not .FechaHoraEnvioEmail Is Nothing Then
                    textboxFechaHoraEnvioEmail.Text = .FechaHoraEnvioEmail.Value.ToShortDateString & " " & .FechaHoraEnvioEmail.Value.ToShortTimeString
                End If
                textboxUsuarioEnvioEmail.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.UsuarioEnvioEmail.Descripcion)
            End If

            ' Datos del Pie - Importes Totales
            currencytextboxDetalle_Subtotal.DecimalValue = 0
            currencytextboxImpuestos_Subtotal.DecimalValue = 0
            currencytextboxAplicaciones_Subtotal.DecimalValue = 0
            currencytextboxMediosPago_Subtotal.DecimalValue = 0
            currencytextboxImporteTotal.DecimalValue = .ImporteTotal1

            If .IDComprobante > 0 Then
                If mComprobanteActual.ComprobanteTipo.UtilizaAplicacion Then
                    RefreshData_Aplicaciones()
                End If
                If mComprobanteActual.ComprobanteTipo.UtilizaMedioPago Then
                    RefreshData_MediosPago()
                End If
            End If
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mComprobanteActual
            ' Datos de la Identificación
            .IDComprobanteTipo = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxComprobanteTipo.SelectedValue, 0).Value

            .PuntoVenta = textboxPuntoVenta.Text
            .Numero = textboxNumero.Text

            .FechaEmision = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaEmision.Value).Value

            ' Fechas
            .FechaVencimiento1 = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaVencimiento.Value, datetimepickerFechaVencimiento.Checked)
            .FechaServicioDesde = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaServicioDesde.Value, datetimepickerFechaServicioDesde.Checked)
            .FechaServicioHasta = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaServicioHasta.Value, datetimepickerFechaServicioHasta.Checked)

            ' Entidad
            .IDEntidad = CS_ValueTranslation.FromControlTagToObjectInteger(textboxEntidad.Tag).Value
            If CS_Parameter_System.GetBoolean(Parametros.COMPROBANTE_ENTIDAD_MAYUSCULAS, False).Value Then
                .ApellidoNombre = mEntidad.ApellidoNombre.ToUpper
            Else
                .ApellidoNombre = mEntidad.ApellidoNombre
            End If

            ' Tipo y Número de Documento
            If Not mEntidad.FacturaIDDocumentoTipo Is Nothing Then
                .IDDocumentoTipo = mEntidad.FacturaIDDocumentoTipo.Value
                .DocumentoNumero = mEntidad.FacturaDocumentoNumero
            ElseIf Not mEntidad.IDDocumentoTipo Is Nothing Then
                .IDDocumentoTipo = mEntidad.IDDocumentoTipo.Value
                .DocumentoNumero = mEntidad.DocumentoNumero
            Else
                .IDDocumentoTipo = CS_Parameter_System.GetIntegerAsByte(Parametros.CONSUMIDORFINAL_DOCUMENTOTIPO_ID)
                .DocumentoNumero = CS_Parameter_System.GetString(Parametros.CONSUMIDORFINAL_DOCUMENTONUMERO)
            End If
            .IDCategoriaIVA = mEntidad.IDCategoriaIVA.Value

            ' Domicilio
            .DomicilioCalleCompleto = mEntidad.DomicilioCalleCompleto()
            .DomicilioCodigoPostal = mEntidad.DomicilioCodigoPostal
            .DomicilioIDProvincia = mEntidad.DomicilioIDProvincia
            .DomicilioIDLocalidad = mEntidad.DomicilioIDLocalidad

            ' Datos de la pestaña Notas y Aditoría
            .Leyenda = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxLeyenda.Text.Trim)
            .Notas = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNotas.Text.Trim)

            ' Datos del Pie - Importes Totales
            .ImporteTotal1 = currencytextboxImporteTotal.DecimalValue
            .ImporteImpuesto = currencytextboxImpuestos_Subtotal.DecimalValue
            .ImporteSubtotal = .ImporteTotal1 - .ImporteImpuesto
        End With

    End Sub

#End Region

#Region "Controls behavior"
    Private Sub ComprobanteTipoChanged() Handles comboboxComprobanteTipo.SelectedValueChanged
        If Not mIsLoading Then
            CambiarTipoComprobante()
            ChangeMode()
        End If
    End Sub

    Private Sub EntidadBuscar(sender As Object, e As EventArgs) Handles buttonEntidad.Click
        If datagridviewDetalle.Rows.Count > 0 Then
            MsgBox("No se puede cambiar la Entidad porque hay Detalles cargados.", MsgBoxStyle.Information, My.Application.Info.Title)
            Exit Sub
        End If
        If datagridviewImpuestos.Rows.Count > 0 Then
            MsgBox("No se puede cambiar la Entidad porque hay Impuestos cargados.", MsgBoxStyle.Information, My.Application.Info.Title)
            Exit Sub
        End If
        If datagridviewAplicaciones.Rows.Count > 0 Then
            MsgBox("No se puede cambiar la Entidad porque hay Aplicaciones cargadas.", MsgBoxStyle.Information, My.Application.Info.Title)
            Exit Sub
        End If
        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        If Not mComprobanteTipoActual Is Nothing Then
            formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = (mComprobanteTipoActual.OperacionTipo = Constantes.OPERACIONTIPO_VENTA)
            formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = (mComprobanteTipoActual.OperacionTipo = Constantes.OPERACIONTIPO_VENTA)
            formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = (mComprobanteTipoActual.OperacionTipo = Constantes.OPERACIONTIPO_COMPRA)
            formEntidadesSeleccionar.menuitemEntidadTipo_Otro.Checked = (mComprobanteTipoActual.OperacionTipo = Constantes.OPERACIONTIPO_VENTA)
        End If
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            mEntidad = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
            Using dbContext As New CSColegioContext(True)
                Dim EntidadMovimientos As Entidad
                EntidadMovimientos = dbContext.Entidad.Find(mEntidad.IDEntidad)
                If EntidadMovimientos.Comprobante.Count = 0 Then
                    MsgBox("La Entidad seleccionada no tiene Movimientos generados en su cuenta.", MsgBoxStyle.Information, My.Application.Info.Title)
                End If
            End Using
            If mEntidad.IDCategoriaIVA Is Nothing Then
                MsgBox("La Entidad seleccionada no tiene especificada la Categoría de IVA.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Else
                textboxEntidad.Text = mEntidad.ApellidoNombre
                textboxEntidad.Tag = mEntidad.IDEntidad
            End If
        End If
        formEntidadesSeleccionar.Dispose()
        formEntidadesSeleccionar = Nothing
    End Sub

    Private Sub EntidadVerSaldo() Handles buttonEntidadVerSaldo.Click
        If textboxEntidad.Tag Is Nothing Then
            MsgBox("Para ver el Saldo, antes debe especificar la Entidad.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxEntidad.Focus()
            Exit Sub
        End If

        Using dbContext As New CSColegioContext(True)
            Dim EntidadActual As Entidad

            Dim Debitos As Decimal
            Dim Creditos As Decimal
            Dim SaldoActual As Decimal

            EntidadActual = dbContext.Entidad.Find(mEntidad.IDEntidad)

            Debitos = EntidadActual.Comprobante.Where(Function(c) c.IDUsuarioAnulacion Is Nothing And c.ComprobanteTipo.MovimientoTipo = "D").Sum(Function(c) c.ImporteTotal1)
            Creditos = EntidadActual.Comprobante.Where(Function(c) c.IDUsuarioAnulacion Is Nothing And c.ComprobanteTipo.MovimientoTipo = "C").Sum(Function(c) c.ImporteTotal1)
            SaldoActual = Debitos - Creditos

            MsgBox(String.Format("El Saldo actual es: {0}", FormatCurrency(SaldoActual)), MsgBoxStyle.Information, My.Application.Info.Title)
        End Using
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxIDComprobante.GotFocus, textboxEntidad.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub
#End Region

#Region "Main Toolbar"

    Private Sub buttonEditar_Click(sender As Object, e As EventArgs) Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDAD_EDITAR) Then
            mEditMode = True
            ChangeMode()
        End If
    End Sub

    Private Sub buttonCerrar_Click(sender As Object, e As EventArgs) Handles buttonCerrar.Click
        Me.Close()
    End Sub

    Private Sub buttonGuardar_Click(sender As Object, e As EventArgs) Handles buttonGuardar.Click
        Dim EntidadActual As Entidad
        Dim ArticuloActual As Articulo

        Dim NextComprobanteNumero As String

        If comboboxComprobanteTipo.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Tipo de Comprobante.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxComprobanteTipo.Focus()
            Exit Sub
        End If

        ' Punto de Venta
        If textboxPuntoVenta.Text.Trim.Length = 0 Then
            MsgBox("Debe especificar el Punto de Venta.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxPuntoVenta.Focus()
            Exit Sub
        End If
        If textboxPuntoVenta.Text.Trim.Length < Constantes.COMPROBANTE_PUNTOVENTA_CARACTERES Then
            MsgBox(String.Format("El Punto de Venta debe contener {0} números.", Constantes.COMPROBANTE_PUNTOVENTA_CARACTERES), MsgBoxStyle.Information, My.Application.Info.Title)
            textboxPuntoVenta.Focus()
            Exit Sub
        End If

        ' Número
        If textboxNumero.Text.Trim.Length = 0 Then
            MsgBox("Debe especificar el Número de Comprobante.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxNumero.Focus()
            Exit Sub
        End If
        If textboxNumero.Text.Trim.Length < Constantes.COMPROBANTE_NUMERO_CARACTERES Then
            MsgBox(String.Format("El Número de Comprobante debe contener {0} números.", Constantes.COMPROBANTE_PUNTOVENTA_CARACTERES), MsgBoxStyle.Information, My.Application.Info.Title)
            textboxNumero.Focus()
            Exit Sub
        End If

        ' Obtengo el Concepto del Comprobante
        If mComprobanteTipoActual.UtilizaDetalle AndAlso mComprobanteTipoActual.OperacionTipo = Constantes.OPERACIONTIPO_VENTA AndAlso mComprobanteTipoActual.EmisionElectronica Then
            If mComprobanteActual.ComprobanteDetalle.Count > 0 Then
                For Each CDetalle As ComprobanteDetalle In mComprobanteActual.ComprobanteDetalle
                    ArticuloActual = mdbContext.Articulo.Find(CDetalle.IDArticulo)
                    Select Case mConceptoActual.IDConcepto
                        Case CByte(0)
                            ' Es el primer Artículo, así que lo guardo
                            mConceptoActual = mdbContext.Concepto.Find(ArticuloActual.ArticuloGrupo.IDConcepto)
                        Case ArticuloActual.ArticuloGrupo.IDConcepto
                            ' Es el mismo Concepto que el/los Artículos anteriores, no hago nada

                        Case Else
                            If (mConceptoActual.IDConcepto = Constantes.COMPROBANTE_CONCEPTO_PRODUCTO Or mConceptoActual.IDConcepto = Constantes.COMPROBANTE_CONCEPTO_SERVICIOS) And (ArticuloActual.ArticuloGrupo.IDConcepto = Constantes.COMPROBANTE_CONCEPTO_PRODUCTO Or ArticuloActual.ArticuloGrupo.IDConcepto = Constantes.COMPROBANTE_CONCEPTO_SERVICIOS) Then
                                ' Hay Productos y Servicios, así que utilizo el Concepto correspondiente
                                mConceptoActual = mdbContext.Concepto.Find(Constantes.COMPROBANTE_CONCEPTO_PRODUCTOSYSERVICIOS)
                                Exit For
                            End If
                    End Select
                Next
            Else
                mConceptoActual = mdbContext.Concepto.Find(Constantes.COMPROBANTE_CONCEPTO_PRODUCTO)
            End If
        Else
            mConceptoActual = New Concepto
        End If

        ' Fecha - Corroborar con el Concepto de los artículos
        If mComprobanteTipoActual.OperacionTipo = Constantes.OPERACIONTIPO_VENTA AndAlso mComprobanteTipoActual.EmisionElectronica AndAlso Math.Abs(datetimepickerFechaEmision.Value.CompareTo(DateAndTime.Today)) > mConceptoActual.FechaRangoDia Then
            MsgBox(String.Format("La Fecha de Emisión no puede tener más de {0} días de diferencia con la Fecha actual.", mConceptoActual.FechaRangoDia), MsgBoxStyle.Information, My.Application.Info.Title)
            datetimepickerFechaEmision.Focus()
            Exit Sub
        End If
        If Math.Abs(datetimepickerFechaEmision.Value.CompareTo(DateAndTime.Today)) > 30 Then
            If MsgBox(String.Format("La Fecha de Emisión tiene más de {0} días de diferencia con la Fecha actual.", mConceptoActual.FechaRangoDia) & vbCrLf & vbCrLf & "¿Es correcto?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                datetimepickerFechaEmision.Focus()
                Exit Sub
            End If
        End If

        ' Fecha de Vencimiento
        If datetimepickerFechaVencimiento.Checked AndAlso datetimepickerFechaVencimiento.Value.CompareTo(datetimepickerFechaEmision.Value) < 0 Then
            MsgBox("La Fecha de Vencimiento debe ser posterior o igual a la Fecha de Emisión.", MsgBoxStyle.Information, My.Application.Info.Title)
            datetimepickerFechaVencimiento.Focus()
            Exit Sub
        End If

        ' Fechas de Servicio
        If mComprobanteTipoActual.UtilizaDetalle AndAlso mComprobanteTipoActual.OperacionTipo = Constantes.OPERACIONTIPO_VENTA AndAlso mComprobanteTipoActual.EmisionElectronica AndAlso (mConceptoActual.IDConcepto = Constantes.COMPROBANTE_CONCEPTO_SERVICIOS Or mConceptoActual.IDConcepto = Constantes.COMPROBANTE_CONCEPTO_PRODUCTOSYSERVICIOS) Then
            If Not datetimepickerFechaVencimiento.Checked Then
                MsgBox("Por estar facturando Servicios, debe especificar la Fecha de Vencimiento.", MsgBoxStyle.Information, My.Application.Info.Title)
                datetimepickerFechaVencimiento.Focus()
                Exit Sub
            End If
            If Not datetimepickerFechaServicioDesde.Checked Then
                MsgBox("Por estar facturando Servicios, debe especificar la Fecha del Período Facturado Desde.", MsgBoxStyle.Information, My.Application.Info.Title)
                datetimepickerFechaServicioDesde.Focus()
                Exit Sub
            End If
            If Not datetimepickerFechaServicioHasta.Checked Then
                MsgBox("Por estar facturando Servicios, debe especificar la Fecha del Período Facturado Hasta.", MsgBoxStyle.Information, My.Application.Info.Title)
                datetimepickerFechaServicioHasta.Focus()
                Exit Sub
            End If
            If datetimepickerFechaServicioHasta.Value.CompareTo(datetimepickerFechaServicioDesde.Value) < 0 Then
                MsgBox("La Fecha del Período Facturado Hasta, debe ser posterior o igual a la Fecha del Período Facturado Desde.", MsgBoxStyle.Information, My.Application.Info.Title)
                datetimepickerFechaServicioHasta.Focus()
                Exit Sub
            End If
        End If

        ' Entidad
        If textboxEntidad.Tag Is Nothing Then
            MsgBox("Debe especificar la Entidad.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxEntidad.Focus()
            Exit Sub
        End If
        EntidadActual = mdbContext.Entidad.Find(textboxEntidad.Tag)


        If Not EntidadActual.EmitirFacturaA Is Nothing Then
            If MsgBox("La Entidad seleccionada, tiene especificado que se le facture otra Entidad." & vbCrLf & vbCrLf & "¿Desea continuar de todos modos?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If EntidadActual.IDCategoriaIVA Is Nothing Then
            MsgBox("La Entidad no tiene especificada la Categoría de IVA.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxEntidad.Focus()
            Exit Sub
        End If
        If EntidadActual.DocumentoNumero Is Nothing And EntidadActual.FacturaDocumentoNumero Is Nothing Then
            MsgBox("La Entidad no tiene especificado el Tipo y Número de Documento.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxEntidad.Focus()
            Exit Sub
        End If

        ' Importe Total
        If mComprobanteTipoActual.UtilizaDetalle = False And mComprobanteTipoActual.UtilizaMedioPago = False Then
            If currencytextboxImporteTotal.IsNull Or currencytextboxImporteTotal.DecimalValue <= 0 Then
                MsgBox("El Total debe ser mayor a cero.", MsgBoxStyle.Information, My.Application.Info.Title)
                currencytextboxImporteTotal.Focus()
                Exit Sub
            End If
        End If

        ' Subtotales de cada solapa
        If mComprobanteTipoActual.UtilizaAplicacion Then
            If currencytextboxAplicaciones_Subtotal.DecimalValue > 0 AndAlso currencytextboxAplicaciones_Subtotal.DecimalValue > currencytextboxImporteTotal.DecimalValue Then
                MsgBox("El Subtotal de los Comprobantes aplicados no puede ser mayor al Total del Comprobante actual.", MsgBoxStyle.Information, My.Application.Info.Title)
                Exit Sub
            End If
        End If

        ' Es un Comprobante Nuevo
        If mComprobanteActual.IDComprobante = 0 Then
            ' Calculo el nuevo ID
            Using dbcMaxID As New CSColegioContext(True)
                If dbcMaxID.Comprobante.Count = 0 Then
                    mComprobanteActual.IDComprobante = 1
                Else
                    mComprobanteActual.IDComprobante = (From c In dbcMaxID.Comprobante Select c.IDComprobante).Max + 1
                End If
            End Using

            ' Si corresponde, recalculo el Número del Comprobante
            If mUtilizaNumerador Then
                ' El Número de Comprobante es calculado automáticamente, así que lo verifico por si alguien agregó uno antes de grabar este
                NextComprobanteNumero = mdbContext.Comprobante.Where(Function(cc) cc.IDComprobanteTipo = mComprobanteTipoActual.IDComprobanteTipo And cc.PuntoVenta = mComprobanteTipoPuntoVentaActual.PuntoVenta.Numero).Max(Function(cc) cc.Numero)
                If NextComprobanteNumero Is Nothing Then
                    ' No hay ningún comprobante creado de este tipo, así que tomo el número inicial 
                    NextComprobanteNumero = mComprobanteTipoPuntoVentaActual.NumeroInicio.ToString.PadLeft(Constantes.COMPROBANTE_NUMERO_CARACTERES, "0"c)
                Else
                    NextComprobanteNumero = CStr(CInt(NextComprobanteNumero) + 1).PadLeft(Constantes.COMPROBANTE_NUMERO_CARACTERES, "0"c)
                End If
                textboxNumero.Text = NextComprobanteNumero
            End If

            mComprobanteActual.IDUsuarioCreacion = pUsuario.IDUsuario
            mComprobanteActual.FechaHoraCreacion = Now
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()
        If mConceptoActual.IDConcepto = 0 Then
            mComprobanteActual.IDConcepto = Nothing
        Else
            mComprobanteActual.IDConcepto = mConceptoActual.IDConcepto
        End If

        ' Si es una factura, calculo el código de barras Sepsa
        If mComprobanteTipoActual.OperacionTipo = Constantes.OPERACIONTIPO_VENTA AndAlso (mComprobanteTipoActual.CodigoAFIP = Constantes.ComprobanteCodigoAfipFacturaA OrElse mComprobanteTipoActual.CodigoAFIP = Constantes.ComprobanteCodigoAfipFacturaB OrElse mComprobanteTipoActual.CodigoAFIP = Constantes.ComprobanteCodigoAfipFacturaC) Then
            mComprobanteActual.CalcularCodigoBarrasSepsa(mEntidad.DocumentoNumero)
        End If

        If mdbContext.ChangeTracker.HasChanges Then

            Me.Cursor = Cursors.WaitCursor

            mComprobanteActual.IDUsuarioModificacion = pUsuario.IDUsuario
            mComprobanteActual.FechaHoraModificacion = Now

            Try
                ' Guardo los cambios
                mdbContext.SaveChanges()

            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Me.Cursor = Cursors.Default
                Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                    Case CardonerSistemas.Database.EntityFramework.Errors.DuplicatedEntity
                        MsgBox("No se pueden guardar los cambios porque ya existe un Comprobante con el mismo ID.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                    Case CardonerSistemas.Database.EntityFramework.Errors.Unknown, CardonerSistemas.Database.EntityFramework.Errors.NoDBError
                        CardonerSistemas.ErrorHandler.ProcessError(dbuex.GetBaseException, My.Resources.STRING_ERROR_SAVING_CHANGES)
                    Case Else
                        CardonerSistemas.ErrorHandler.ProcessError(dbuex.GetBaseException, My.Resources.STRING_ERROR_SAVING_CHANGES)
                End Select
                Exit Sub

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                CardonerSistemas.ErrorHandler.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
                Exit Sub
            End Try

            If mComprobanteTipoActual.EmisionElectronica AndAlso mComprobanteActual.CAE Is Nothing Then
                If Permisos.VerificarPermiso(Permisos.COMPROBANTE_TRANSMITIR_AFIP) Then
                    If MsgBox("Este Comprobante necesita ser autorizado en AFIP para tener validez." & vbCrLf & vbCrLf & "¿Desea hacerlo ahora?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                        If TransmitirComprobante(mComprobanteActual) Then
                            MsgBox("Se ha transmitido exitosamente el Comprobante a AFIP.", MsgBoxStyle.Information, My.Application.Info.Title)
                            If CS_Parameter_System.GetBoolean(Parametros.AFIP_COMPROBANTES_CODIGOQR_GENERAR, False) Then
                                ModuloComprobantes.GenerarCodigoQR(mComprobanteActual.IDComprobante)
                            End If
                        End If
                    End If
                End If
            End If

            ' Refresco la lista de Comprobantes para mostrar los cambios
            pFillAndRefreshLists.Comprobantes(mComprobanteActual.IDComprobante)
        End If

        Me.Close()
    End Sub

    Private Sub AFIP_TransmitirComprobante(sender As Object, e As EventArgs) Handles menuitemAFIP_ObtenerCAE.Click
        If Not mComprobanteActual Is Nothing Then
            If mComprobanteTipoActual.EmisionElectronica AndAlso mComprobanteActual.CAE Is Nothing Then
                If Permisos.VerificarPermiso(Permisos.COMPROBANTE_TRANSMITIR_AFIP) Then
                    If MsgBox("Este Comprobante necesita ser autorizado en AFIP para tener validez." & vbCrLf & vbCrLf & "¿Desea hacerlo ahora?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                        If TransmitirComprobante(mComprobanteActual) Then
                            buttonAFIP.Visible = False

                            ' Refresco la lista de Comprobantes para mostrar los cambios
                            If CS_Form.MDIChild_IsLoaded(CType(pFormMDIMain, Form), "formComprobantes") Then
                                Dim formComprobantes As formComprobantes = CType(CS_Form.MDIChild_GetInstance(CType(pFormMDIMain, Form), "formComprobantes"), formComprobantes)
                                formComprobantes.RefreshData(mComprobanteActual.IDComprobante)
                                formComprobantes = Nothing
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub AFIP_ObtenerCodigoQR(sender As Object, e As EventArgs) Handles menuitemAFIP_ObtenerQR.Click
        If Not mComprobanteActual Is Nothing Then
            If mComprobanteTipoActual.EmisionElectronica AndAlso mComprobanteActual.CAE IsNot Nothing Then
                If mComprobanteActual.CodigoQR Is Nothing OrElse MsgBox("Este Comprobante ya tiene generado el Código QR." & vbCrLf & vbCrLf & "¿Desea generarlo nuevamente?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                    If ModuloComprobantes.GenerarCodigoQR(mComprobanteActual.IDComprobante,,,,, True) Then
                        buttonAFIP.Visible = False

                        ' Refresco la lista de Comprobantes para mostrar los cambios
                        If CS_Form.MDIChild_IsLoaded(CType(pFormMDIMain, Form), "formComprobantes") Then
                            Dim formComprobantes As formComprobantes = CType(CS_Form.MDIChild_GetInstance(CType(pFormMDIMain, Form), "formComprobantes"), formComprobantes)
                            formComprobantes.RefreshData(mComprobanteActual.IDComprobante)
                            formComprobantes = Nothing
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub AFIP_VerificarComprobante(sender As Object, e As EventArgs) Handles menuitemAFIP_VerificarDatos.Click
        Dim Objeto_AFIP_WS As New CardonerSistemas.AfipWebServices.WebService

        If Not mComprobanteActual Is Nothing Then
            If mComprobanteTipoActual.EmisionElectronica AndAlso Not mComprobanteActual.CAE Is Nothing Then
                If Permisos.VerificarPermiso(Permisos.COMPROBANTE_TRANSMITIR_AFIP) Then
                    Me.Cursor = Cursors.WaitCursor
                    Application.DoEvents()

                    If ModuloComprobantes.TransmitirAFIP_Inicializar(Objeto_AFIP_WS, pAfipWebServicesConfig.ModoHomologacion) Then
                        If ModuloComprobantes.TransmitirAFIP_IniciarSesion(Objeto_AFIP_WS) Then
                            If ModuloComprobantes.TransmitirAFIP_ConectarServicio(Objeto_AFIP_WS) Then
                                If Objeto_AFIP_WS.FacturaElectronica_ConsultarComprobante(mComprobanteTipoActual.CodigoAFIP, CShort(mComprobanteActual.PuntoVenta), CInt(mComprobanteActual.Numero)) Then
                                    If Objeto_AFIP_WS.UltimoResultadoConsultaComprobante.Resultado = CardonerSistemas.AfipWebServices.SolicitudCaeResultadoAceptado Then
                                        formComprobanteVerificaAFIP.LoadAndShow(Me, mComprobanteActual, Objeto_AFIP_WS.UltimoResultadoConsultaComprobante)

                                        ' Si actualizo el Comprobante local:
                                        '' Refresco la lista de Comprobantes para mostrar los cambios
                                        'If CS_Form.MDIChild_IsLoaded(CType(pFormMDIMain, Form), "formComprobantes") Then
                                        '    Dim formComprobantes As formComprobantes = CType(CS_Form.MDIChild_GetInstance(CType(pFormMDIMain, Form), "formComprobantes"), formComprobantes)
                                        '    formComprobantes.RefreshData(mComprobanteActual.IDComprobante)
                                        '    formComprobantes = Nothing
                                        'End If
                                    End If
                                End If
                            End If
                        End If
                    End If

                    Me.Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub Cancelar(sender As Object, e As EventArgs) Handles buttonCancelar.Click
        If mdbContext.ChangeTracker.HasChanges Then
            If MsgBox("Ha realizado cambios en los datos y seleccionó cancelar, los cambios se perderán." & vbCr & vbCr & "¿Confirma la pérdida de los cambios?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub
#End Region

#Region "Detalles"

    Friend Sub RefreshData_Detalle(Optional ByVal PositionIndice As Byte = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)
        Dim Total As Decimal = 0

        If RestoreCurrentPosition Then
            If datagridviewDetalle.CurrentRow Is Nothing Then
                PositionIndice = 0
            Else
                PositionIndice = CType(datagridviewDetalle.CurrentRow.DataBoundItem, ComprobanteDetalle).Indice
            End If
        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            datagridviewDetalle.AutoGenerateColumns = False
            datagridviewDetalle.DataSource = mComprobanteActual.ComprobanteDetalle.ToList

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer los Detalles.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        For Each ComprobanteDetalleActual As ComprobanteDetalle In mComprobanteActual.ComprobanteDetalle
            Total += ComprobanteDetalleActual.PrecioUnitarioFinal
        Next
        currencytextboxDetalle_Subtotal.DecimalValue = Total
        If mComprobanteTipoActual.UtilizaDetalle Then
            currencytextboxImporteTotal.DecimalValue = Total
        End If

        Me.Cursor = Cursors.Default

        If PositionIndice <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewDetalle.Rows
                If CType(datagridviewDetalle.CurrentRow.DataBoundItem, ComprobanteDetalle).Indice = PositionIndice Then
                    datagridviewDetalle.CurrentCell = CurrentRowChecked.Cells(0)
                    Exit For
                End If
            Next
        End If

        ChangeMode()
    End Sub

    Private Sub Detalle_Agregar(sender As Object, e As EventArgs) Handles buttonDetalle_Agregar.ButtonClick
        If textboxEntidad.Tag Is Nothing Then
            MsgBox("Antes de poder agregar Detalles, debe especificar la Entidad.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxEntidad.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        datagridviewDetalle.Enabled = False

        SetDataFromControlsToObject()

        Dim ComprobanteDetalleNuevo As New ComprobanteDetalle
        formComprobanteDetalle.LoadAndShow(True, True, Me, mComprobanteActual, ComprobanteDetalleNuevo)

        EstablecerFechasSegunDetalle()

        datagridviewDetalle.Enabled = True

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Detalle_AgregarMultiple(sender As Object, e As EventArgs) Handles buttonDetalle_AgregarMultiple.Click
        If textboxEntidad.Tag Is Nothing Then
            MsgBox("Antes de poder agregar Detalles, debe especificar la Entidad.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxEntidad.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        datagridviewDetalle.Enabled = False

        SetDataFromControlsToObject()

        formComprobanteDetalleAgregarMultiple.LoadAndShow(True, True, Me, mComprobanteActual)

        EstablecerFechasSegunDetalle()

        datagridviewDetalle.Enabled = True

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Detalle_Editar(sender As Object, e As EventArgs) Handles buttonDetalle_Editar.Click
        If datagridviewDetalle.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Detalle para editar.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewDetalle.Enabled = False

            Dim ComprobanteDetalleActual As ComprobanteDetalle

            ComprobanteDetalleActual = CType(datagridviewDetalle.SelectedRows(0).DataBoundItem, ComprobanteDetalle)
            formComprobanteDetalle.LoadAndShow(True, True, Me, mComprobanteActual, ComprobanteDetalleActual)

            EstablecerFechasSegunDetalle()

            datagridviewDetalle.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Detalle_Eliminar(sender As Object, e As EventArgs) Handles buttonDetalle_Eliminar.Click
        If datagridviewDetalle.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Detalle para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            Dim ComprobanteDetalleEliminar As ComprobanteDetalle
            ComprobanteDetalleEliminar = CType(datagridviewDetalle.SelectedRows(0).DataBoundItem, ComprobanteDetalle)

            Dim Mensaje As String
            Mensaje = String.Format("Se eliminará el Detalle seleccionado.{0}{0}Descripción: {1}{0}Precio Unitario: {2}{0}Precio Total: {3}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, ComprobanteDetalleEliminar.Descripcion, FormatCurrency(ComprobanteDetalleEliminar.PrecioUnitario), FormatCurrency(ComprobanteDetalleEliminar.PrecioTotal))
            If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor

                mComprobanteActual.ComprobanteDetalle.Remove(ComprobanteDetalleEliminar)


                EstablecerFechasSegunDetalle()

                RefreshData_Detalle()

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Detalle_Ver(sender As Object, e As EventArgs) Handles datagridviewDetalle.DoubleClick
        If datagridviewDetalle.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Detalle para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewDetalle.Enabled = False

            Dim ComprobanteDetalleActual As ComprobanteDetalle

            ComprobanteDetalleActual = CType(datagridviewDetalle.SelectedRows(0).DataBoundItem, ComprobanteDetalle)
            formComprobanteDetalle.LoadAndShow(mEditMode, False, Me, mComprobanteActual, ComprobanteDetalleActual)

            EstablecerFechasSegunDetalle()

            datagridviewDetalle.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

#Region "Aplicaciones"

    Friend Sub RefreshData_Aplicaciones(Optional ByVal PositionIDComprobanteAplicado As Integer = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)
        Dim listAplicaciones As List(Of GridRowData_Aplicacion)
        Dim Total As Decimal = 0

        If RestoreCurrentPosition Then
            If datagridviewAplicaciones.CurrentRow Is Nothing Then
                PositionIDComprobanteAplicado = 0
            Else
                PositionIDComprobanteAplicado = CType(datagridviewAplicaciones.CurrentRow.DataBoundItem, GridRowData_Aplicacion).ComprobanteAplicacion.IDComprobanteAplicado
            End If
        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            listAplicaciones = New List(Of GridRowData_Aplicacion)

            If mComprobanteActual.ComprobanteAplicacion_Aplicados.Count > 0 Then

                Using dbContext As New CSColegioContext(True)

                    For Each ca As ComprobanteAplicacion In mComprobanteActual.ComprobanteAplicacion_Aplicados
                        Dim GridRowData As New GridRowData_Aplicacion
                        Dim ComprobanteAplicado As Comprobante
                        Dim ComprobanteAplicacionMotivoActual As ComprobanteAplicacionMotivo

                        With GridRowData
                            .ComprobanteAplicacion = ca

                            If ca.IDComprobanteAplicacionMotivo.HasValue Then
                                ComprobanteAplicacionMotivoActual = dbContext.ComprobanteAplicacionMotivo.Find(ca.IDComprobanteAplicacionMotivo)
                                .Motivo = ComprobanteAplicacionMotivoActual.Nombre
                            Else
                                .Motivo = ""
                            End If

                            ComprobanteAplicado = dbContext.Comprobante.Find(ca.IDComprobanteAplicado)
                            .ComprobanteTipoNombre = ComprobanteAplicado.ComprobanteTipo.Nombre
                            .MovimientoTipo = ComprobanteAplicado.ComprobanteTipo.MovimientoTipo

                            .NumeroCompleto = ComprobanteAplicado.NumeroCompleto
                            .FechaEmision = ComprobanteAplicado.FechaEmision
                            .ImporteTotal = ComprobanteAplicado.ImporteTotal1
                            .ImporteAplicado = ca.Importe
                        End With

                        listAplicaciones.Add(GridRowData)

                        ComprobanteAplicado = Nothing
                        ComprobanteAplicacionMotivoActual = Nothing
                        GridRowData = Nothing
                    Next

                End Using

            End If

            datagridviewAplicaciones.AutoGenerateColumns = False
            datagridviewAplicaciones.DataSource = listAplicaciones

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer los Comprobantes aplicados.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        For Each GridRowData_AplicacionActual As GridRowData_Aplicacion In listAplicaciones
            Select Case GridRowData_AplicacionActual.MovimientoTipo
                Case Constantes.MOVIMIENTOTIPO_CREDITO
                    Total += GridRowData_AplicacionActual.ImporteAplicado
                Case Constantes.MOVIMIENTOTIPO_DEBITO
                    Total -= GridRowData_AplicacionActual.ImporteAplicado
            End Select
        Next
        currencytextboxAplicaciones_Subtotal.DecimalValue = Total

        If mComprobanteTipoActual.UtilizaDetalle = False And mComprobanteTipoActual.UtilizaMedioPago = False Then
            currencytextboxImporteTotal.DecimalValue = Total
            currencytextboxImporteTotal.ReadOnly = (listAplicaciones.Count > 0)
        End If

        Me.Cursor = Cursors.Default

        If PositionIDComprobanteAplicado <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewAplicaciones.Rows
                If CType(datagridviewAplicaciones.CurrentRow.DataBoundItem, GridRowData_Aplicacion).ComprobanteAplicacion.IDComprobanteAplicado = PositionIDComprobanteAplicado Then
                    datagridviewAplicaciones.CurrentCell = CurrentRowChecked.Cells(0)
                    Exit For
                End If
            Next
        End If

        ChangeMode()
    End Sub

    Private Sub Aplicacion_Agregar(sender As Object, e As EventArgs) Handles buttonAplicaciones_Agregar.Click
        If textboxEntidad.Tag Is Nothing Then
            MsgBox("Antes de poder agregar Aplicaciones, debe especificar la Entidad.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxEntidad.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        datagridviewAplicaciones.Enabled = False

        SetDataFromControlsToObject()

        Dim ComprobanteAplicacionNuevo As New ComprobanteAplicacion
        formComprobanteAplicacion.LoadAndShow(True, True, Me, mComprobanteActual, mComprobanteTipoActual, ComprobanteAplicacionNuevo)

        datagridviewAplicaciones.Enabled = True

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Aplicacion_Eliminar(sender As Object, e As EventArgs) Handles buttonAplicaciones_Eliminar.Click
        If datagridviewAplicaciones.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Aplicación para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            Dim GridRowData_Aplicacion_Eliminar As GridRowData_Aplicacion
            GridRowData_Aplicacion_Eliminar = CType(datagridviewAplicaciones.SelectedRows(0).DataBoundItem, GridRowData_Aplicacion)

            Dim Mensaje As String
            Mensaje = String.Format("Se eliminará la Aplicación seleccionada.{0}{0}Tipo de Comprobante: {1}{0}Número de Comprobante: {2}{0}Importe: {3}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, GridRowData_Aplicacion_Eliminar.ComprobanteTipoNombre, GridRowData_Aplicacion_Eliminar.NumeroCompleto, FormatCurrency(GridRowData_Aplicacion_Eliminar.ImporteTotal))
            If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor

                mComprobanteActual.ComprobanteAplicacion_Aplicados.Remove(GridRowData_Aplicacion_Eliminar.ComprobanteAplicacion)

                RefreshData_Aplicaciones()

                Me.Cursor = Cursors.Default
            End If
        End If

    End Sub
#End Region

#Region "Medios de Pago"

    Friend Sub RefreshData_MediosPago(Optional ByVal PositionIndice As Byte = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)
        Dim listMediosPago As List(Of GridRowData_MedioPago)
        Dim Total As Decimal = 0

        If RestoreCurrentPosition Then
            If datagridviewMediosPago.CurrentRow Is Nothing Then
                PositionIndice = 0
            Else
                PositionIndice = CType(datagridviewMediosPago.CurrentRow.DataBoundItem, GridRowData_MedioPago).ComprobanteMedioPago.Indice
            End If
        End If

        Me.Cursor = Cursors.WaitCursor

        Try
            listMediosPago = (From cmp In mComprobanteActual.ComprobanteMedioPago
                              Join mp In mdbContext.MedioPago On cmp.IDMedioPago Equals mp.IDMedioPago
                              Join c In mdbContext.Caja On cmp.IDCaja Equals c.IDCaja
                              Select New GridRowData_MedioPago With {.ComprobanteMedioPago = cmp, .MedioPago = mp, .MedioPagoNombre = mp.Nombre, .CajaNombre = c.Nombre, .Importe = cmp.Importe}).ToList

            datagridviewMediosPago.AutoGenerateColumns = False
            datagridviewMediosPago.DataSource = listMediosPago

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer los Medios de Pago.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        For Each GridRowData_MedioPagoCurrent As GridRowData_MedioPago In listMediosPago
            Total += GridRowData_MedioPagoCurrent.Importe
        Next
        currencytextboxMediosPago_Subtotal.DecimalValue = Total
        currencytextboxImporteTotal.DecimalValue = Total

        Me.Cursor = Cursors.Default

        If PositionIndice <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewMediosPago.Rows
                If CType(datagridviewMediosPago.CurrentRow.DataBoundItem, GridRowData_MedioPago).ComprobanteMedioPago.Indice = PositionIndice Then
                    datagridviewMediosPago.CurrentCell = CurrentRowChecked.Cells(0)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub MedioPago_AgregarOtro(sender As Object, e As EventArgs) Handles buttonMediosPago_AgregarOtro.Click
        Me.Cursor = Cursors.WaitCursor

        datagridviewMediosPago.Enabled = False

        Dim ComprobanteMedioPagoNuevo As New ComprobanteMedioPago
        ComprobanteMedioPagoNuevo.FechaHora = DateTime.Now
        formComprobanteMedioPago.LoadAndShow(True, True, Me, mComprobanteActual, ComprobanteMedioPagoNuevo)

        datagridviewMediosPago.Enabled = True

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MedioPago_AgregarCheque(sender As Object, e As EventArgs) Handles buttonMediosPago_AgregarCheque.Click
        Me.Cursor = Cursors.WaitCursor

        datagridviewMediosPago.Enabled = False

        Dim ComprobanteMedioPagoNuevo As New ComprobanteMedioPago
        Dim ChequeNuevo As New Cheque
        ChequeNuevo.FechaEmision = DateTime.Today
        ChequeNuevo.FechaPago = DateTime.Today
        ComprobanteMedioPagoNuevo.Cheque = ChequeNuevo
        formCheque.LoadAndShow(True, True, Me, mdbContext, mComprobanteActual, ComprobanteMedioPagoNuevo)

        datagridviewMediosPago.Enabled = True

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MedioPago_Editar(sender As Object, e As EventArgs) Handles buttonMediosPago_Editar.Click
        If datagridviewMediosPago.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Medio de Pago para editar.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMediosPago.Enabled = False

            Dim ComprobanteMedioPagoActual As ComprobanteMedioPago
            Dim MedioPagoActual As MedioPago

            ComprobanteMedioPagoActual = CType(datagridviewMediosPago.SelectedRows(0).DataBoundItem, GridRowData_MedioPago).ComprobanteMedioPago
            MedioPagoActual = CType(datagridviewMediosPago.SelectedRows(0).DataBoundItem, GridRowData_MedioPago).MedioPago

            If MedioPagoActual.EsCheque Then
                formCheque.LoadAndShow(True, True, Me, mdbContext, mComprobanteActual, ComprobanteMedioPagoActual)
            Else
                formComprobanteMedioPago.LoadAndShow(True, True, Me, mComprobanteActual, ComprobanteMedioPagoActual)
            End If

            datagridviewMediosPago.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub MedioPago_Eliminar(sender As Object, e As EventArgs) Handles buttonMediosPago_Eliminar.Click
        If datagridviewMediosPago.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Medio de Pago para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            Dim GridRowData_MedioPago_Eliminar As GridRowData_MedioPago
            GridRowData_MedioPago_Eliminar = CType(datagridviewMediosPago.SelectedRows(0).DataBoundItem, GridRowData_MedioPago)

            Dim Mensaje As String
            Mensaje = String.Format("Se eliminará el Medio de Pago seleccionado.{0}{0}Medio de Pago: {1}{0}Caja: {2}{0}Importe: {3}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, GridRowData_MedioPago_Eliminar.MedioPagoNombre, GridRowData_MedioPago_Eliminar.CajaNombre, FormatCurrency(GridRowData_MedioPago_Eliminar.Importe))
            If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor

                mComprobanteActual.ComprobanteMedioPago.Remove(GridRowData_MedioPago_Eliminar.ComprobanteMedioPago)

                RefreshData_MediosPago()

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub MedioPago_Ver(sender As Object, e As EventArgs) Handles datagridviewMediosPago.DoubleClick
        If datagridviewMediosPago.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Medio de Pago para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMediosPago.Enabled = False

            Dim ComprobanteMedioPagoActual As ComprobanteMedioPago
            Dim MedioPagoActual As MedioPago

            ComprobanteMedioPagoActual = CType(datagridviewMediosPago.SelectedRows(0).DataBoundItem, GridRowData_MedioPago).ComprobanteMedioPago
            MedioPagoActual = CType(datagridviewMediosPago.SelectedRows(0).DataBoundItem, GridRowData_MedioPago).MedioPago

            If MedioPagoActual.EsCheque Then
                formCheque.LoadAndShow(mEditMode, False, Me, mdbContext, mComprobanteActual, ComprobanteMedioPagoActual)
            Else
                formComprobanteMedioPago.LoadAndShow(mEditMode, False, Me, mComprobanteActual, ComprobanteMedioPagoActual)
            End If

            datagridviewMediosPago.Enabled = True

            Me.Cursor = Cursors.Default
        End If

    End Sub

#End Region

#Region "Extra stuff"
    Private Sub CambiarTipoComprobante()
        Dim NextComprobanteNumero As String

        If comboboxComprobanteTipo.SelectedIndex > -1 Then
            mComprobanteTipoActual = CType(comboboxComprobanteTipo.SelectedItem, ComprobanteTipo)

            ' Verifico la asignación del número de comprobante
            ' TODO: Poder especificar el punto de venta para cada comprobante
            mComprobanteTipoPuntoVentaActual = mComprobanteTipoActual.ComprobanteTipoPuntoVenta.Where(Function(ctpv) ctpv.IDPuntoVenta = pGeneralConfig.IdPuntoVenta).FirstOrDefault()
            If mComprobanteTipoPuntoVentaActual Is Nothing Then
                ' No hay un numerador definido, habilito los campos de Punto de Venta y Numero
                mUtilizaNumerador = False
                textboxPuntoVenta.Text = ""
                textboxNumero.Text = ""
            Else
                ' Hay un numerador definido, así que si es un comprobante nuevo, busco el siguiente número, como para ir mostrándolo, aunque antes de grabar, puede volver a cambiar
                mUtilizaNumerador = True
                If mComprobanteActual.IDComprobante = 0 Then
                    textboxPuntoVenta.Text = mComprobanteTipoPuntoVentaActual.PuntoVenta.Numero
                    ' Busco si ya hay un comprobante creado de este tipo para obtener el último número
                    NextComprobanteNumero = mdbContext.Comprobante.Where(Function(cc) cc.IDComprobanteTipo = mComprobanteTipoActual.IDComprobanteTipo And cc.PuntoVenta = mComprobanteTipoPuntoVentaActual.PuntoVenta.Numero).Max(Function(cc) cc.Numero)
                    If NextComprobanteNumero Is Nothing Then
                        ' No hay ningún comprobante creado de este tipo, así que tomo el número inicial 
                        NextComprobanteNumero = mComprobanteTipoPuntoVentaActual.NumeroInicio.ToString.PadLeft(Constantes.COMPROBANTE_NUMERO_CARACTERES, "0"c)
                    Else
                        NextComprobanteNumero = CStr(CInt(NextComprobanteNumero) + 1).PadLeft(Constantes.COMPROBANTE_NUMERO_CARACTERES, "0"c)
                    End If
                    textboxNumero.Text = NextComprobanteNumero
                End If
            End If

            ' Habilito los Controles según corresponda
            textboxPuntoVenta.TabStop = Not mUtilizaNumerador
            textboxNumero.TabStop = Not mUtilizaNumerador

            panelFechas.Visible = mComprobanteTipoActual.UtilizaDetalle
            If mComprobanteTipoActual.UtilizaDetalle Then
                tabcontrolMain.ShowTabPageByName(tabpageDetalle.Name)
                panelDetalle_Subtotal.Visible = True
            Else
                tabcontrolMain.HideTabPageByName(tabpageDetalle.Name)
                panelDetalle_Subtotal.Visible = False
            End If
            If mComprobanteTipoActual.UtilizaImpuesto Then
                tabcontrolMain.ShowTabPageByName(tabpageImpuestos.Name)
                panelImpuestos_Subtotal.Visible = True
            Else
                tabcontrolMain.HideTabPageByName(tabpageImpuestos.Name)
                panelImpuestos_Subtotal.Visible = False
            End If
            If mComprobanteTipoActual.UtilizaAplicacion Then
                tabcontrolMain.ShowTabPageByName(tabpageAplicaciones.Name)
                panelAplicaciones_Subtotal.Visible = True
            Else
                tabcontrolMain.HideTabPageByName(tabpageAplicaciones.Name)
                panelAplicaciones_Subtotal.Visible = False
            End If
            If mComprobanteTipoActual.UtilizaMedioPago Then
                tabcontrolMain.ShowTabPageByName(tabpageMediosPago.Name)
                panelMediosPago_Subtotal.Visible = True
            Else
                tabcontrolMain.HideTabPageByName(tabpageMediosPago.Name)
                panelMediosPago_Subtotal.Visible = False
            End If

            If mComprobanteTipoActual.UtilizaDetalle = False And mComprobanteTipoActual.UtilizaMedioPago = False Then
                currencytextboxImporteTotal.ReadOnly = False
            End If

        Else
            panelFechas.Visible = False
            tabcontrolMain.HideTabPageByName(tabpageDetalle.Name)
            panelDetalle_Subtotal.Visible = False
            tabcontrolMain.HideTabPageByName(tabpageImpuestos.Name)
            panelImpuestos_Subtotal.Visible = False
            tabcontrolMain.HideTabPageByName(tabpageAplicaciones.Name)
            panelAplicaciones_Subtotal.Visible = False
            tabcontrolMain.HideTabPageByName(tabpageMediosPago.Name)
            panelMediosPago_Subtotal.Visible = False
        End If
        tabcontrolMain.SelectTab(0)
    End Sub

    Private Sub EstablecerFechasSegunDetalle()
        Dim AnioLectivoCursoActual As AnioLectivoCurso

        If mComprobanteTipoActual.UtilizaDetalle AndAlso mComprobanteTipoActual.OperacionTipo = Constantes.OPERACIONTIPO_VENTA AndAlso mComprobanteTipoActual.EmisionElectronica Then
            For Each DetalleActual As ComprobanteDetalle In mComprobanteActual.ComprobanteDetalle
                Select Case DetalleActual.IDArticulo
                    Case mIDArticuloMatricula
                        Using dbContext As New CSColegioContext(True)
                            AnioLectivoCursoActual = dbContext.AnioLectivoCurso.Find(DetalleActual.IDAnioLectivoCurso)
                        End Using
                        If datetimepickerFechaVencimiento.Checked = False Then
                            datetimepickerFechaVencimiento.Value = DateAndTime.Today
                        End If
                        If datetimepickerFechaServicioDesde.Checked = False Or datetimepickerFechaServicioDesde.Value > New Date(AnioLectivoCursoActual.AnioLectivo, 1, 1) Then
                            datetimepickerFechaServicioDesde.Value = New Date(AnioLectivoCursoActual.AnioLectivo, 1, 1)
                        End If
                        If datetimepickerFechaServicioHasta.Checked = False Or datetimepickerFechaServicioHasta.Value < New Date(AnioLectivoCursoActual.AnioLectivo, 12, 31) Then
                            datetimepickerFechaServicioHasta.Value = New Date(AnioLectivoCursoActual.AnioLectivo, 12, 31)
                        End If
                    Case mIDArticuloMensual
                        Using dbContext As New CSColegioContext(True)
                            AnioLectivoCursoActual = dbContext.AnioLectivoCurso.Find(DetalleActual.IDAnioLectivoCurso)
                        End Using
                        If datetimepickerFechaVencimiento.Checked = False Then
                            datetimepickerFechaVencimiento.Value = DateAndTime.Today
                        End If
                        If datetimepickerFechaServicioDesde.Checked = False Or datetimepickerFechaServicioDesde.Value > New Date(AnioLectivoCursoActual.AnioLectivo, DetalleActual.CuotaMes.Value, 1) Then
                            datetimepickerFechaServicioDesde.Value = New Date(AnioLectivoCursoActual.AnioLectivo, DetalleActual.CuotaMes.Value, 1)
                        End If
                        If datetimepickerFechaServicioHasta.Checked = False Or datetimepickerFechaServicioHasta.Value < New Date(AnioLectivoCursoActual.AnioLectivo, DetalleActual.CuotaMes.Value, Date.DaysInMonth(AnioLectivoCursoActual.AnioLectivo, DetalleActual.CuotaMes.Value)) Then
                            datetimepickerFechaServicioHasta.Value = New Date(AnioLectivoCursoActual.AnioLectivo, DetalleActual.CuotaMes.Value, Date.DaysInMonth(AnioLectivoCursoActual.AnioLectivo, DetalleActual.CuotaMes.Value))
                        End If
                End Select
            Next
        End If
    End Sub

    Private Function TransmitirComprobante(ByRef ComprobanteActual As Comprobante) As Boolean
        Dim Objeto_AFIP_WS As New CardonerSistemas.AfipWebServices.WebService

        Dim MensajeError As String

        If ModuloComprobantes.TransmitirAFIP_Inicializar(Objeto_AFIP_WS, pAfipWebServicesConfig.ModoHomologacion) Then
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()

            If ModuloComprobantes.TransmitirAFIP_IniciarSesion(Objeto_AFIP_WS) Then
                If ModuloComprobantes.TransmitirAFIP_ConectarServicio(Objeto_AFIP_WS) Then
                    If Not ComprobanteActual Is Nothing Then
                        If ComprobanteActual.CAE Is Nothing Then
                            If ModuloComprobantes.TransmitirAFIP_Comprobante(Objeto_AFIP_WS, ComprobanteActual.IDComprobante) Then
                                MsgBox(String.Format("Se han transmitido exitosamente el Comprobante a AFIP."), MsgBoxStyle.Information, My.Application.Info.Title)
                                Me.Cursor = Cursors.Default
                                Return True
                            ElseIf Objeto_AFIP_WS.UltimoResultadoCAE.Resultado = CardonerSistemas.AfipWebServices.SolicitudCaeResultadoRechazado Then
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
                                Me.Cursor = Cursors.Default
                                Return False
                            Else
                                Me.Cursor = Cursors.Default
                                Return False
                            End If
                        End If
                    End If
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
        Return False
    End Function
#End Region

End Class