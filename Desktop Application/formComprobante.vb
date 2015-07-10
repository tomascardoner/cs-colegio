Public Class formComprobante
    Friend dbcontext As New CSColegioContext(True)
    Friend ComprobanteCurrent As Comprobante

    Friend Sub InitializeFormAndControls()
        SetAppearance()

        ' Cargo los ComboBox
        FillAndRefreshLists.ComprobanteTipo(comboboxComprobanteTipo, Nothing, False, False)
    End Sub

    Friend Sub SetAppearance()
        datagridviewDetalle.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewDetalle.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont
    End Sub

    Friend Sub SetDataFromObjectToControls()
        With ComprobanteCurrent
            ' Datos de la Identificación
            If .IDComprobante = 0 Then
                textboxIDComprobante.Text = My.Resources.STRING_ITEM_NEW_MALE
            Else
                textboxIDComprobante.Text = String.Format(.IDComprobante.ToString, "G")
            End If
            CS_ComboBox.SetSelectedValue(comboboxComprobanteTipo, SelectedItemOptions.Value, .IDComprobanteTipo)
            textboxPuntoVenta.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.PuntoVenta)
            textboxNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Numero)
            datetimepickerFechaEmision.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaEmision, datetimepickerFechaEmision)

            ' Fechas
            datetimepickerFechaVencimiento.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaVencimiento, datetimepickerFechaVencimiento)
            datetimepickerFechaServicioDesde.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaServicioDesde, datetimepickerFechaServicioDesde)
            datetimepickerFechaServicioHasta.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaServicioHasta, datetimepickerFechaServicioHasta)

            ' Entidad
            textboxEntidad.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Entidad.ApellidoNombre)
            textboxEntidad.Tag = .Entidad.IDEntidad

            ' Datos de la pestaña Detalle
            datagridviewDetalle.AutoGenerateColumns = False
            datagridviewDetalle.DataSource = ComprobanteCurrent.ComprobanteDetalle.ToList

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
            textboxImporteNeto.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.ImporteNeto)
            textboxImporteImpuesto.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.ImporteImpuesto)
            textboxImporteTotal.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.ImporteTotal)
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        'With EntidadCurrent
        '    ' Datos del Encabezado
        '    .EsActivo = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxEsActivo.CheckState)
        '    .Apellido = textboxApellido.Text.Trim
        '    .Nombre = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNombre.Text.Trim)

        '    'Datos de la pestaña General
        '    .TipoPersonalColegio = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoPersonalColegio.CheckState)
        '    .TipoDocente = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoDocente.CheckState)
        '    .TipoAlumno = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoAlumno.CheckState)
        '    .TipoFamiliar = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoFamiliar.CheckState)
        '    .TipoProveedor = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoProveedor.CheckState)
        '    .IDDocumentoTipo = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxDocumentoTipo.SelectedValue, 0)
        '    If CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
        '        .DocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(maskedtextboxDocumentoNumero.Text.Trim)
        '    Else
        '        .DocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDocumentoNumero.Text.Trim)
        '    End If
        '    .FacturaIDDocumentoTipo = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxFacturaDocumentoTipo.SelectedValue, 0)
        '    If CType(comboboxFacturaDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
        '        .FacturaDocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(maskedtextboxFacturaDocumentoNumero.Text.Trim)
        '    Else
        '        .FacturaDocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxFacturaDocumentoNumero.Text.Trim)
        '    End If
        '    .Genero = CS_ValueTranslation.FromControlComboBoxToObjectString(comboboxGenero.SelectedValue, Constantes.GENERO_NOESPECIFICA)
        '    .FechaNacimiento = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaNacimiento.Value, datetimepickerFechaNacimiento.Checked)
        '    .IDCategoriaIVA = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxCategoriaIVA.SelectedValue, 0)

        '    ' Datos de la pestaña Contacto
        '    .Telefono1 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono1.Text)
        '    .Telefono2 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono2.Text)
        '    .Telefono3 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono3.Text)
        '    .Email1 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxEmail1.Text)
        '    .Email2 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxEmail2.Text)
        '    .DomicilioCalle1 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCalle1.Text)
        '    .DomicilioNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioNumero.Text)
        '    .DomicilioPiso = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioPiso.Text)
        '    .DomicilioDepartamento = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioDepartamento.Text)
        '    .DomicilioCalle2 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCalle2.Text)
        '    .DomicilioCalle3 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCalle3.Text)
        '    .DomicilioIDProvincia = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxDomicilioProvincia.SelectedValue, Constantes.PROVINCIA_NOESPECIFICA)
        '    .DomicilioIDLocalidad = CS_ValueTranslation.FromControlComboBoxToObjectShort(comboboxDomicilioLocalidad.SelectedValue, 0)
        '    .DomicilioCodigoPostal = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCodigoPostal.Text)

        '    ' Datos de la pestaña Padres y Facturación
        '    .IDEntidadPadre = CS_ValueTranslation.FromControlTagToObjectInteger(textboxEntidadPadre.Tag)
        '    .IDEntidadMadre = CS_ValueTranslation.FromControlTagToObjectInteger(textboxEntidadMadre.Tag)
        '    .EmitirFacturaA = CS_ValueTranslation.FromControlComboBoxToObjectString(comboboxEmitirFacturaA.SelectedValue, Constantes.EMITIRFACTURAA_NOESPECIFICA)
        '    If .EmitirFacturaA = Constantes.EMITIRFACTURAA_TERCERO Or .EmitirFacturaA = Constantes.EMITIRFACTURAA_TODOS Then
        '        .IDEntidadTercero = CS_ValueTranslation.FromControlTagToObjectInteger(textboxEntidadTercero.Tag)
        '    Else
        '        .IDEntidadTercero = Nothing
        '    End If
        '    .IDDescuento = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxDescuento.SelectedValue, 0)
        '    .ExcluyeCalculoInteres = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxExcluyeCalculoInteres.CheckState)
        '    .FacturaIndividual = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxFacturaIndividual.CheckState)
        '    .ExcluyeFacturaDesde = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerExcluyeFacturaDesde.Value, datetimepickerExcluyeFacturaDesde.Checked)
        '    .ExcluyeFacturaHasta = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerExcluyeFacturaHasta.Value, datetimepickerExcluyeFacturaHasta.Checked)

        '    ' Datos de la pestaña Notas y Aditoría
        '    .Notas = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNotas.Text.Trim)
        'End With
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxIDComprobante.GotFocus, textboxPuntoVenta.GotFocus, textboxNumero.GotFocus, textboxEntidad.GotFocus, textboxImporteNeto.GotFocus, textboxImporteImpuesto.GotFocus, textboxImporteTotal.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub MaskedTextBoxs_GotFocus(sender As Object, e As EventArgs)
        CType(sender, MaskedTextBox).SelectAll()
    End Sub
End Class