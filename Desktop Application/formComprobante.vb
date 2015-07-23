Public Class formComprobante

#Region "Declarations"
    Private dbContext As New CSColegioContext(True)
    Private mComprobanteCurrent As Comprobante

    Private mComprobanteTipoCurrent As ComprobanteTipo
    Private mUtilizaNumerador As Boolean = False
    Private mComprobanteTipoPuntoVentaActual As ComprobanteTipoPuntoVenta
    Private mEntidad As Entidad

    Private mEditMode As Boolean = False

    Public Class GridRowData_MedioPago
        Public Property ComprobanteMedioPago As ComprobanteMedioPago
        Public Property MedioPagoNombre As String
        Public Property CajaNombre As String
        Public Property Importe As Decimal
        Public Property BancoNombre As String
        Public Property Numero As String
        Public Property FechaVencimiento As Date
    End Class
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByVal EditMode As Boolean, ByRef ParentForm As Form, ByVal IDComprobante As Long)
        mEditMode = EditMode

        ' Antes que nada, cierro las ventanas hijas que pudieran haber quedado abiertas
        If CS_Form.MDIChild_IsLoaded(CType(formMDIMain, Form), "formComprobanteMedioPago") Then
            formComprobanteMedioPago.Close()
            formComprobanteMedioPago = Nothing
        End If

        If IDComprobante = 0 Then
            ' Es Nuevo
            mComprobanteCurrent = New Comprobante
            mComprobanteCurrent.FechaEmision = DateAndTime.Today
            dbContext.Comprobante.Add(mComprobanteCurrent)
        Else
            mComprobanteCurrent = dbContext.Comprobante.Find(IDComprobante)
        End If

        Me.MdiParent = formMDIMain
        CS_Form.CenterToParent(ParentForm, Me)
        ChangeMode()
        InitializeFormAndControls()
        SetDataFromObjectToControls()
        Me.Show()
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
        End If
        Me.Focus()

        If IDComprobante > 0 Then
            If mComprobanteCurrent.ComprobanteTipo.EmisionElectronica AndAlso Not mComprobanteCurrent.CAE Is Nothing Then
                If mEditMode Then
                    mEditMode = False
                    ChangeMode()
                    buttonEditar.Visible = False
                    MsgBox("No se puede editar este Comprobante porque es de Emisión Electrónica y ya tiene un CAE asignado.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Else
                    buttonEditar.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub ChangeMode()
        Dim ExceptControlsArray() As String
        Dim ExceptControlsString As String

        buttonGuardar.Visible = mEditMode
        buttonCancelar.Visible = mEditMode
        buttonEditar.Visible = Not mEditMode
        buttonCerrar.Visible = Not mEditMode

        ExceptControlsArray = {toolstripMain.Name, textboxIDComprobante.Name, textboxEntidad.Name, textboxFechaHoraCreacion.Name, textboxUsuarioCreacion.Name, textboxFechaHoraModificacion.Name, textboxUsuarioModificacion.Name}
        ExceptControlsString = String.Join(",", ExceptControlsArray)
        If mEditMode And mComprobanteCurrent.IDComprobante > 0 Then
            ExceptControlsString &= "," & comboboxComprobanteTipo.Name
        End If
        If mEditMode And mUtilizaNumerador Then
            ExceptControlsString &= "," & textboxPuntoVenta.Name & "," & textboxNumero.Name
        End If
        ExceptControlsArray = ExceptControlsString.Split(","c)
        CS_Form.ControlsChangeStateReadOnly(Me.Controls, Not mEditMode, True, ExceptControlsArray)
    End Sub

    Friend Sub InitializeFormAndControls()
        SetAppearance()

        ' Cargo los ComboBox
        pFillAndRefreshLists.ComprobanteTipo(comboboxComprobanteTipo, Nothing, False, False)
    End Sub

    Friend Sub SetAppearance()
        datagridviewDetalle.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewDetalle.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont

        datagridviewImpuestos.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewImpuestos.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont

        datagridviewMediosPago.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewMediosPago.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont
    End Sub

    Private Sub formComprobante_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbcontext.Dispose()
        dbcontext = Nothing
        mComprobanteCurrent = Nothing
        mComprobanteTipoCurrent = Nothing
        mComprobanteTipoPuntoVentaActual = Nothing
        mEntidad = Nothing
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub SetDataFromObjectToControls()
        With mComprobanteCurrent
            ' Datos de la Identificación
            If .IDComprobante = 0 Then
                textboxIDComprobante.Text = My.Resources.STRING_ITEM_NEW_MALE
            Else
                textboxIDComprobante.Text = String.Format(.IDComprobante.ToString, "G")
            End If
            CS_Control_ComboBox.SetSelectedValue(comboboxComprobanteTipo, SelectedItemOptions.Value, .IDComprobanteTipo)
            textboxPuntoVenta.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.PuntoVenta)
            textboxNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Numero)
            datetimepickerFechaEmision.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaEmision, datetimepickerFechaEmision)

            ' Fechas
            datetimepickerFechaVencimiento.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaVencimiento, datetimepickerFechaVencimiento)
            datetimepickerFechaServicioDesde.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaServicioDesde, datetimepickerFechaServicioDesde)
            datetimepickerFechaServicioHasta.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaServicioHasta, datetimepickerFechaServicioHasta)

            ' Entidad
            If Not .Entidad Is Nothing Then
                mEntidad = .Entidad
                textboxEntidad.Text = .Entidad.ApellidoNombre
                textboxEntidad.Tag = .Entidad.IDEntidad
            End If

            ' Datos de la pestaña Detalle
            datagridviewDetalle.AutoGenerateColumns = False
            datagridviewDetalle.DataSource = mComprobanteCurrent.ComprobanteDetalle.ToList

            ' Datos de la pestaña Notas y Auditoría
            textboxNotas.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Notas)
            textboxFechaHoraCreacion.Text = .FechaHoraCreacion.ToShortDateString & " " & .FechaHoraCreacion.ToShortTimeString
            If .UsuarioCreacion Is Nothing Then
                textboxUsuarioCreacion.Text = ""
            Else
                textboxUsuarioCreacion.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.UsuarioCreacion.Descripcion)
            End If
            textboxFechaHoraModificacion.Text = .FechaHoraModificacion.ToShortDateString & " " & .FechaHoraModificacion.ToShortTimeString
            If .UsuarioModificacion Is Nothing Then
                textboxUsuarioModificacion.Text = ""
            Else
                textboxUsuarioModificacion.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.UsuarioModificacion.Descripcion)
            End If

            ' Datos del Pie - Importes Totales
            textboxImporteSubtotal.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.ImporteSubtotal)
            textboxImporteImpuesto.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.ImporteImpuesto)
            textboxImporteTotal.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.ImporteTotal)
        End With

        RefreshData_MediosPago()
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mComprobanteCurrent
            ' Datos de la Identificación
            .IDComprobanteTipo = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxComprobanteTipo.SelectedValue, 0).Value

            .PuntoVenta = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxPuntoVenta.Text)
            .Numero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNumero.Text)

            .FechaEmision = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaEmision.Value).Value

            ' Fechas
            .FechaVencimiento = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaVencimiento.Value, datetimepickerFechaVencimiento.Checked)
            .FechaServicioDesde = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaServicioDesde.Value, datetimepickerFechaServicioDesde.Checked)
            .FechaServicioHasta = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaServicioHasta.Value, datetimepickerFechaServicioHasta.Checked)

            ' Entidad
            .IDEntidad = CS_ValueTranslation.FromControlTagToObjectInteger(textboxEntidad.Tag).Value
            If CS_Parameter.GetBoolean(Parametros.COMPROBANTE_ENTIDAD_MAYUSCULAS, False).Value Then
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
                .IDDocumentoTipo = CS_Parameter.GetIntegerAsByte(Parametros.CONSUMIDORFINAL_DOCUMENTOTIPO_ID)
                .DocumentoNumero = CS_Parameter.GetString(Parametros.CONSUMIDORFINAL_DOCUMENTONUMERO)
            End If
            .IDCategoriaIVA = mEntidad.IDCategoriaIVA.Value

            ' Domicilio
            .DomicilioCalleCompleto = mEntidad.DomicilioCalleCompleto()
            .DomicilioCodigoPostal = mEntidad.DomicilioCodigoPostal
            .DomicilioIDProvincia = mEntidad.DomicilioIDProvincia
            .DomicilioIDLocalidad = mEntidad.DomicilioIDLocalidad

            ' Datos de la pestaña Notas y Aditoría
            .Notas = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNotas.Text.Trim)

            ' Datos del Pie - Importes Totales
            .ImporteSubtotal = CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxImporteSubtotal.Text).Value
            .ImporteImpuesto = CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxImporteImpuesto.Text).Value
            .ImporteTotal = CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxImporteTotal.Text).Value
        End With
    End Sub

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
            listMediosPago = (From cmp In mComprobanteCurrent.ComprobanteMedioPago
                              Join mp In dbContext.MedioPago On cmp.IDMedioPago Equals mp.IDMedioPago
                              Join c In dbContext.Caja On cmp.IDCaja Equals c.IDCaja
                              Select New GridRowData_MedioPago With {.ComprobanteMedioPago = cmp, .MedioPagoNombre = mp.Nombre, .CajaNombre = c.Nombre, .Importe = cmp.Importe}).ToList

            datagridviewMediosPago.AutoGenerateColumns = False
            datagridviewMediosPago.DataSource = listMediosPago

        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al leer los Medios de Pago.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        For Each GridRowData_MedioPagoCurrent As GridRowData_MedioPago In listMediosPago
            Total += GridRowData_MedioPagoCurrent.Importe
        Next
        textboxImporteSubtotal.Text = FormatCurrency(Total)
        textboxImporteTotal.Text = FormatCurrency(Total)

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


#End Region

#Region "Controls behavior"
    Private Sub comboboxComprobanteTipo_SelectedValueChanged(sender As Object, e As EventArgs) Handles comboboxComprobanteTipo.SelectedValueChanged
        Dim NextComprobanteNumero As String

        If comboboxComprobanteTipo.SelectedIndex > -1 Then
            mComprobanteTipoCurrent = CType(comboboxComprobanteTipo.SelectedItem, ComprobanteTipo)

            ' Verifico la asignación del número de comprobante
            mComprobanteTipoPuntoVentaActual = mComprobanteTipoCurrent.ComprobanteTipoPuntoVenta.Where(Function(ctpv) ctpv.IDPuntoVenta = My.Settings.IDPuntoVenta).FirstOrDefault()
            If mComprobanteTipoPuntoVentaActual Is Nothing Then
                ' No hay un numerador definido, habilito los campos de Punto de Venta y Numero
                mUtilizaNumerador = False
                textboxPuntoVenta.ReadOnly = False
                textboxNumero.ReadOnly = False
                textboxPuntoVenta.Text = ""
                textboxNumero.Text = ""
            Else
                ' Hay un numerador definido, así que busco el siguiente número, como para ir mostrándolo, aunque antes de grabar, puede volver a cambiar
                mUtilizaNumerador = True
                textboxPuntoVenta.ReadOnly = mEditMode
                textboxNumero.ReadOnly = mEditMode

                textboxPuntoVenta.Text = mComprobanteTipoPuntoVentaActual.PuntoVenta.Numero
                ' Busco si ya hay un comprobante creado de este tipo para obtener el último número
                NextComprobanteNumero = dbcontext.Comprobante.Where(Function(cc) cc.IDComprobanteTipo = mComprobanteTipoCurrent.IDComprobanteTipo And cc.PuntoVenta = mComprobanteTipoPuntoVentaActual.PuntoVenta.Numero).Max(Function(cc) cc.Numero)
                If NextComprobanteNumero Is Nothing Then
                    ' No hay ningún comprobante creado de este tipo, así que tomo el número inicial 
                    NextComprobanteNumero = mComprobanteTipoPuntoVentaActual.NumeroInicio.ToString.PadLeft(Constantes.COMPROBANTE_NUMERO_CARACTERES, "0"c)
                Else
                    NextComprobanteNumero = CStr(CInt(NextComprobanteNumero) + 1).PadLeft(Constantes.COMPROBANTE_NUMERO_CARACTERES, "0"c)
                End If
                textboxNumero.Text = NextComprobanteNumero
            End If

            ' Habilito los Controles según corresponda
            panelFechas.Visible = mComprobanteTipoCurrent.UtilizaDetalle

            radiobuttonTabPageDetalle.Visible = mComprobanteTipoCurrent.UtilizaDetalle
            panelDetalle.Visible = mComprobanteTipoCurrent.UtilizaDetalle

            radiobuttonTabPageImpuestos.Visible = mComprobanteTipoCurrent.UtilizaImpuesto
            panelImpuestos.Visible = mComprobanteTipoCurrent.UtilizaImpuesto
            If mComprobanteTipoCurrent.UtilizaDetalle = False Then
                radiobuttonTabPageImpuestos.Checked = True
            End If

            radiobuttonTabPageAplicaciones.Visible = mComprobanteTipoCurrent.UtilizaAplicacion
            If mComprobanteTipoCurrent.UtilizaDetalle = False And mComprobanteTipoCurrent.UtilizaImpuesto = False Then
                radiobuttonTabPageAplicaciones.Checked = True
            End If

            radiobuttonTabPageAsociaciones.Visible = mComprobanteTipoCurrent.UtilizaAsociacion
            If mComprobanteTipoCurrent.UtilizaDetalle = False And mComprobanteTipoCurrent.UtilizaImpuesto = False And mComprobanteTipoCurrent.UtilizaAplicacion = False Then
                radiobuttonTabPageAsociaciones.Checked = True
            End If

            radiobuttonTabPageMediosPago.Visible = mComprobanteTipoCurrent.UtilizaMedioPago
            panelMediosPago.Visible = mComprobanteTipoCurrent.UtilizaMedioPago
            If mComprobanteTipoCurrent.UtilizaDetalle = False And mComprobanteTipoCurrent.UtilizaImpuesto = False And mComprobanteTipoCurrent.UtilizaAplicacion = False And mComprobanteTipoCurrent.UtilizaAsociacion = False Then
                radiobuttonTabPageMediosPago.Checked = True
            End If

            If mComprobanteTipoCurrent.UtilizaDetalle = False And mComprobanteTipoCurrent.UtilizaImpuesto = False And mComprobanteTipoCurrent.UtilizaAplicacion = False And mComprobanteTipoCurrent.UtilizaAsociacion = False And mComprobanteTipoCurrent.UtilizaMedioPago = False Then
                radiobuttonTabPageNotasAuditoria.Checked = True
            End If
        Else
            panelFechas.Visible = False

            radiobuttonTabPageDetalle.Visible = False
            panelDetalle.Visible = False

            radiobuttonTabPageImpuestos.Visible = False
            panelImpuestos.Visible = False

            radiobuttonTabPageAplicaciones.Visible = False

            radiobuttonTabPageAsociaciones.Visible = False

            radiobuttonTabPageMediosPago.Visible = False
            panelMediosPago.Visible = False

            radiobuttonTabPageNotasAuditoria.Checked = True
        End If
    End Sub

    Private Sub buttonEntidad_Click(sender As Object, e As EventArgs) Handles buttonEntidad.Click
        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = (mComprobanteTipoCurrent.OperacionTipo = Constantes.OPERACIONTIPO_VENTA)
        formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = (mComprobanteTipoCurrent.OperacionTipo = Constantes.OPERACIONTIPO_VENTA)
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = (mComprobanteTipoCurrent.OperacionTipo = Constantes.OPERACIONTIPO_COMPRA)
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            mEntidad = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
            textboxEntidad.Text = mEntidad.ApellidoNombre
            textboxEntidad.Tag = mEntidad.IDEntidad
        End If
        formEntidadesSeleccionar.Dispose()
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxIDComprobante.GotFocus, textboxPuntoVenta.GotFocus, textboxNumero.GotFocus, textboxEntidad.GotFocus, textboxImporteSubtotal.GotFocus, textboxImporteImpuesto.GotFocus, textboxImporteTotal.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub TabPageDetalle_CheckedChanged(sender As Object, e As EventArgs) Handles radiobuttonTabPageDetalle.CheckedChanged
        panelDetalle.Visible = radiobuttonTabPageDetalle.Checked
        TabButtonChanged(radiobuttonTabPageDetalle)
    End Sub

    Private Sub TabPageImpuestos_CheckedChanged(sender As Object, e As EventArgs) Handles radiobuttonTabPageImpuestos.CheckedChanged
        panelImpuestos.Visible = radiobuttonTabPageImpuestos.Checked
        TabButtonChanged(radiobuttonTabPageImpuestos)
    End Sub

    Private Sub TabPageAplicaciones_CheckedChanged(sender As Object, e As EventArgs) Handles radiobuttonTabPageAplicaciones.CheckedChanged
        'panelAplicaciones.Visible = radiobuttonTabPageAplicaciones.Checked
        TabButtonChanged(radiobuttonTabPageAplicaciones)
    End Sub

    Private Sub TabPageAsociaciones_CheckedChanged(sender As Object, e As EventArgs) Handles radiobuttonTabPageAsociaciones.CheckedChanged
        'panelAsociaciones.Visible = radiobuttonTabPageAsociaciones.Checked
        TabButtonChanged(radiobuttonTabPageAsociaciones)
    End Sub

    Private Sub TabPageMediosPago_CheckedChanged(sender As Object, e As EventArgs) Handles radiobuttonTabPageMediosPago.CheckedChanged
        panelMediosPago.Visible = radiobuttonTabPageMediosPago.Checked
        TabButtonChanged(radiobuttonTabPageMediosPago)
    End Sub

    Private Sub TabPageNotasAuditoria_CheckedChanged(sender As Object, e As EventArgs) Handles radiobuttonTabPageNotasAuditoria.CheckedChanged
        panelNotasAuditoria.Visible = radiobuttonTabPageNotasAuditoria.Checked
        TabButtonChanged(radiobuttonTabPageNotasAuditoria)
    End Sub

    Private Sub TabButtonChanged(ByRef radiobuttonChanged As RadioButton)
        If radiobuttonChanged.Checked Then
            radiobuttonChanged.Font = New Font(radiobuttonChanged.Font, FontStyle.Bold)
        Else
            radiobuttonChanged.Font = New Font(radiobuttonChanged.Font, FontStyle.Regular)
        End If
    End Sub
#End Region

#Region "Main Toolbar"
    Private Sub buttonEditar_Click() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDAD_EDIT) Then
            mEditMode = True
            ChangeMode()
        End If
    End Sub

    Private Sub buttonCerrar_Click() Handles buttonCerrar.Click
        Me.Close()
    End Sub

    Private Sub buttonGuardar_Click() Handles buttonGuardar.Click
        Dim ComprobanteTipoActual As ComprobanteTipo
        Dim ConceptoActual As New Concepto
        Dim EntidadActual As Entidad
        Dim NextComprobanteNumero As String

        If comboboxComprobanteTipo.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Tipo de Comprobante.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxComprobanteTipo.Focus()
            Exit Sub
        End If
        ComprobanteTipoActual = CType(comboboxComprobanteTipo.SelectedItem, ComprobanteTipo)

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

        ' Fecha - Corroborar con el Concepto de los artículos
        If ComprobanteTipoActual.EmisionElectronica AndAlso Math.Abs(datetimepickerFechaEmision.Value.CompareTo(DateAndTime.Today)) > ConceptoActual.FechaRangoDia Then
            MsgBox(String.Format("La Fecha de Emisión no puede tener más de {0} días de diferencia con la Fecha actual.", ConceptoActual.FechaRangoDia), MsgBoxStyle.Information, My.Application.Info.Title)
            datetimepickerFechaEmision.Focus()
            Exit Sub
        End If
        If Math.Abs(datetimepickerFechaEmision.Value.CompareTo(DateAndTime.Today)) > 30 Then
            If MsgBox(String.Format("La Fecha de Emisión tiene más de {0} días de diferencia con la Fecha actual.", ConceptoActual.FechaRangoDia) & vbCrLf & vbCrLf & "¿Es correcto?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
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
        If ComprobanteTipoActual.OperacionTipo = Constantes.OPERACIONTIPO_VENTA AndAlso ComprobanteTipoActual.EmisionElectronica AndAlso (ConceptoActual.IDConcepto = 2 Or ConceptoActual.IDConcepto = 3) Then
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
        EntidadActual = dbContext.Entidad.Find(textboxEntidad.Tag)
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

        ' Es un Comprobante Nuevo
        If mComprobanteCurrent.IDComprobante = 0 Then
            ' Calculo el nuevo ID
            Using dbcMaxID As New CSColegioContext(True)
                If dbcMaxID.Comprobante.Count = 0 Then
                    mComprobanteCurrent.IDComprobante = 1
                Else
                    mComprobanteCurrent.IDComprobante = dbcMaxID.Comprobante.Max(Function(comp) comp.IDComprobante) + 1
                End If
            End Using

            ' Si corresponde, recalculo el Número del Comprobante
            If mUtilizaNumerador Then
                ' El Número de Comprobante es calculado automáticamente, así que lo verifico por si alguien agregó uno antes de grabar este
                NextComprobanteNumero = dbContext.Comprobante.Where(Function(cc) cc.IDComprobanteTipo = mComprobanteTipoCurrent.IDComprobanteTipo And cc.PuntoVenta = mComprobanteTipoPuntoVentaActual.PuntoVenta.Numero).Max(Function(cc) cc.Numero)
                If NextComprobanteNumero Is Nothing Then
                    ' No hay ningún comprobante creado de este tipo, así que tomo el número inicial 
                    NextComprobanteNumero = mComprobanteTipoPuntoVentaActual.NumeroInicio.ToString.PadLeft(Constantes.COMPROBANTE_NUMERO_CARACTERES, "0"c)
                Else
                    NextComprobanteNumero = CStr(CInt(NextComprobanteNumero) + 1).PadLeft(Constantes.COMPROBANTE_NUMERO_CARACTERES, "0"c)
                End If
                textboxNumero.Text = NextComprobanteNumero
            End If

            mComprobanteCurrent.IDUsuarioCreacion = pUsuario.IDUsuario
            mComprobanteCurrent.FechaHoraCreacion = Now
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        If dbContext.ChangeTracker.HasChanges Then

            Me.Cursor = Cursors.WaitCursor

            mComprobanteCurrent.IDUsuarioModificacion = pUsuario.IDUsuario
            mComprobanteCurrent.FechaHoraModificacion = Now

            Try
                ' Guardo los cambios
                dbContext.SaveChanges()

                ' Refresco la lista de Comprobantes para mostrar los cambios
                If CS_Form.MDIChild_IsLoaded(CType(formMDIMain, Form), "formComprobantes") Then
                    Dim formComprobantes As formComprobantes = CType(CS_Form.MDIChild_GetInstance(CType(formMDIMain, Form), "formComprobantes"), formComprobantes)
                    formComprobantes.RefreshData(mComprobanteCurrent.IDComprobante)
                    formComprobantes = Nothing
                End If

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                CS_Error.ProcessError(ex, "Error al intentar guardar los cambios en la Base de Datos.")
                Exit Sub
            End Try

            If mComprobanteTipoCurrent.EmisionElectronica And mComprobanteCurrent.CAE Is Nothing Then
                If MsgBox("Este Comprobante necesita ser autorizado en AFIP para tener validez." & vbCrLf & vbCrLf & "¿Desea hacerlo ahora?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                    If TransmitirComprobante(mComprobanteCurrent) Then

                    End If
                End If
            End If
        End If

        Me.Close()
    End Sub

    Private Sub buttonCancelar_Click() Handles buttonCancelar.Click
        If dbContext.ChangeTracker.HasChanges Then
            If MsgBox("Ha realizado cambios en los datos y seleccionó cancelar, los cambios se perderán." & vbCr & vbCr & "¿Confirma la pérdida de los cambios?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub
#End Region

#Region "Medios de Pago Toolbar"
    Private Sub MedioPago_Agregar() Handles buttonMediosPago_Agregar.Click
        Me.Cursor = Cursors.WaitCursor

        datagridviewMediosPago.Enabled = False

        Dim ComprobanteMedioPagoNuevo As New ComprobanteMedioPago
        ComprobanteMedioPagoNuevo.FechaHora = DateTime.Now
        formComprobanteMedioPago.LoadAndShow(True, True, Me, mComprobanteCurrent, ComprobanteMedioPagoNuevo)

        datagridviewMediosPago.Enabled = True

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MedioPago_Editar() Handles buttonMediosPago_Editar.Click
        If datagridviewMediosPago.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Medio de Pago para editar.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMediosPago.Enabled = False

            formComprobanteMedioPago.LoadAndShow(True, True, Me, mComprobanteCurrent, CType(datagridviewMediosPago.SelectedRows(0).DataBoundItem, GridRowData_MedioPago).ComprobanteMedioPago)

            datagridviewMediosPago.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub MedioPago_Eliminar() Handles buttonMediosPago_Eliminar.Click
        If datagridviewMediosPago.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Medio de Pago para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            Dim GridRowData_MedioPago_Eliminar As GridRowData_MedioPago
            GridRowData_MedioPago_Eliminar = CType(datagridviewMediosPago.SelectedRows(0).DataBoundItem, GridRowData_MedioPago)

            Dim Mensaje As String
            Mensaje = String.Format("Se eliminará el Medio de Pago seleccionado.{0}{0}Medio de Pago: {1}{0}Caja: {2}{0}Importe: {3}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, GridRowData_MedioPago_Eliminar.MedioPagoNombre, GridRowData_MedioPago_Eliminar.CajaNombre, FormatCurrency(GridRowData_MedioPago_Eliminar.Importe))
            If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor

                mComprobanteCurrent.ComprobanteMedioPago.Remove(GridRowData_MedioPago_Eliminar.ComprobanteMedioPago)

                RefreshData_MediosPago()

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub MedioPago_Ver() Handles datagridviewMediosPago.DoubleClick
        If datagridviewMediosPago.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Medio de Pago para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMediosPago.Enabled = False

            formComprobanteMedioPago.LoadAndShow(mEditMode, False, Me, mComprobanteCurrent, CType(datagridviewMediosPago.SelectedRows(0).DataBoundItem, GridRowData_MedioPago).ComprobanteMedioPago)

            datagridviewMediosPago.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region

#Region "Extra stuff"
    Private Function TransmitirComprobante(ByRef ComprobanteATransmitir As Comprobante) As Boolean
        Dim LogPath As String = ""
        Dim LogFileName As String = ""
        Dim WSAA_URL As String
        Dim WSFEv1_URL As String
        Dim AFIP_TicketAcceso As String
        Dim AFIP_Factura As CS_AFIP_WS.FacturaElectronicaCabecera
        Dim ResultadoCAE As CS_AFIP_WS.ResultadoCAE
        Dim MensajeError As String

        Dim InternetProxy As String
        Dim CUIT_Emisor As String
        Dim MonedaLocal As Moneda
        Dim MonedaLocalCotizacion As MonedaCotizacion
        Dim ComprobanteTipoActual As New ComprobanteTipo
        Dim IDConcepto As Byte = 0

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
            WSAA_URL = CS_Parameter.GetString(Parametros.AFIP_WS_AA_HOMOLOGACION)
            WSFEv1_URL = CS_Parameter.GetString(Parametros.AFIP_WS_FE_HOMOLOGACION)
        Else
            WSAA_URL = CS_Parameter.GetString(Parametros.AFIP_WS_AA_PRODUCCION)
            WSFEv1_URL = CS_Parameter.GetString(Parametros.AFIP_WS_FE_PRODUCCION)
        End If

        InternetProxy = CS_Parameter.GetString(Parametros.INTERNET_PROXY, "")
        CUIT_Emisor = CS_Parameter.GetString(Parametros.EMPRESA_CUIT)

        MonedaLocal = dbContext.Moneda.Find(CS_Parameter.GetIntegerAsShort(Parametros.DEFAULT_MONEDA_ID))
        If MonedaLocal Is Nothing Then
            Me.Cursor = Cursors.WaitCursor
            MsgBox("No se ha especificado la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
            Return False
        End If
        MonedaLocalCotizacion = dbContext.MonedaCotizacion.Where(Function(mc) mc.IDMoneda = MonedaLocal.IDMoneda).FirstOrDefault
        If MonedaLocalCotizacion Is Nothing Then
            Me.Cursor = Cursors.WaitCursor
            MsgBox("No hay cotizaciones cargadas para la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
            Return False
        End If

        ' Intento realizar la Autenticación en el Servidor de AFIP
        AFIP_TicketAcceso = CS_AFIP_WS.Login(WSAA_URL, InternetProxy, CS_AFIP_WS.SERVICIO_FACTURACION_ELECTRONICA, My.Settings.AFIP_WS_Certificado, My.Settings.AFIP_WS_ClavePrivada, LogPath, LogFileName)
        If AFIP_TicketAcceso = "" Then
            Me.Cursor = Cursors.Default
            Return False
        End If

        AFIP_Factura = New CS_AFIP_WS.FacturaElectronicaCabecera
        With AFIP_Factura
            If ComprobanteATransmitir.ComprobanteDetalle.Count > 0 Then
                For Each CDetalle As ComprobanteDetalle In ComprobanteATransmitir.ComprobanteDetalle
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
                ' TODO - Buscar el concepto de los Comprobantes aplicados en caso de que corresponda
                IDConcepto = Constantes.COMPROBANTE_CONCEPTO_SERVICIOS
            End If
            .Concepto = IDConcepto

            ' Documento del Titular
            .TipoDocumento = CShort(ComprobanteATransmitir.IDDocumentoTipo)
            .DocumentoNumero = CLng(ComprobanteATransmitir.DocumentoNumero)

            ' Tipo de Comprobante
            If ComprobanteATransmitir.IDComprobanteTipo <> ComprobanteTipoActual.IDComprobanteTipo Then
                ComprobanteTipoActual = dbContext.ComprobanteTipo.Find(ComprobanteATransmitir.IDComprobanteTipo)
            End If
            .TipoComprobante = ComprobanteTipoActual.CodigoAFIP

            ' Datos de la Cabecera
            .PuntoVenta = CShort(ComprobanteATransmitir.PuntoVenta)
            .ComprobanteDesde = CInt(ComprobanteATransmitir.Numero)
            .ComprobanteHasta = CInt(ComprobanteATransmitir.Numero)
            .ComprobanteFecha = ComprobanteATransmitir.FechaEmision

            ' Importes
            .ImporteTotal = ComprobanteATransmitir.ImporteTotal
            .ImporteTotalConc = 0
            .ImporteNeto = ComprobanteATransmitir.ImporteTotal
            .ImporteOperacionesExentas = 0
            .ImporteTributos = 0
            .ImporteIVA = ComprobanteATransmitir.ImporteImpuesto

            ' Fechas
            .FechaServicioDesde = ComprobanteATransmitir.FechaServicioDesde.Value
            .FechaServicioHasta = ComprobanteATransmitir.FechaServicioHasta.Value
            .FechaVencimientoPago = ComprobanteATransmitir.FechaVencimiento.Value

            ' Moneda
            .MonedaID = MonedaLocal.CodigoAFIP
            .MonedaCotizacion = MonedaLocalCotizacion.Cotizacion
        End With

        ResultadoCAE = CS_AFIP_WS.ObtenerCAEFacturaElectronica(AFIP_TicketAcceso, WSFEv1_URL, InternetProxy, CUIT_Emisor, AFIP_Factura, LogPath, LogFileName)
        If ResultadoCAE Is Nothing Then
            Me.Cursor = Cursors.Default
            Return False
        End If
        If ResultadoCAE.Resultado = CS_AFIP_WS.SOLICITUD_CAE_RESULTADO_ACEPTADO Then
            ComprobanteATransmitir.CAE = ResultadoCAE.Numero
            ComprobanteATransmitir.CAEVencimiento = ResultadoCAE.FechaVencimiento
            ComprobanteATransmitir.IDUsuarioTransmision = pUsuario.IDUsuario
            ComprobanteATransmitir.FechaHoraTransmision = Now

            dbContext.SaveChanges()

            Me.Cursor = Cursors.Default
            Return True
        Else
            MensajeError = "Se Rechazó la Solicitud de CAE para la Factura Electrónica:"
            MensajeError &= vbCrLf & vbCrLf
            MensajeError &= "Factura N°: " & ComprobanteATransmitir.Numero
            MensajeError &= vbCrLf
            MensajeError &= "Titular:    " & ComprobanteATransmitir.Entidad.ApellidoNombre
            MensajeError &= vbCrLf
            MensajeError &= "Importe:    " & FormatCurrency(ComprobanteATransmitir.ImporteTotal)
            If ResultadoCAE.Observaciones <> "" Then
                MensajeError &= vbCrLf & vbCrLf
                MensajeError &= "Observaciones: " & ResultadoCAE.Observaciones
            End If
            If ResultadoCAE.ErrorMessage <> "" Then
                MensajeError &= vbCrLf & vbCrLf
                MensajeError &= "Error: " & ResultadoCAE.ErrorMessage
            End If
            MsgBox(MensajeError, MsgBoxStyle.Exclamation, My.Application.Info.Title)

            Me.Cursor = Cursors.Default
            Return False
        End If
    End Function
#End Region

End Class