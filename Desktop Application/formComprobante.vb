Public Class formComprobante
    Friend dbcontext As New CSColegioContext(True)
    Friend ComprobanteCurrent As Comprobante

    Friend Sub InitializeFormAndControls()
        ' Cargo los ComboBox
        FillAndRefreshLists.ComprobanteTipo(comboboxComprobanteTipo, Nothing, False, False)
        FillAndRefreshLists.DocumentoTipo(comboboxDocumentoTipo, False)
        CS_ComboBox.SetSelectedValue(comboboxDocumentoTipo, SelectedItemOptions.ValueOrFirst, CS_Parameter.GetIntegerAsByte(Parametros.DEFAULT_DOCUMENTOTIPO_ID))
        FillAndRefreshLists.CategoriaIVA(comboboxCategoriaIVA, False)
        CS_ComboBox.SetSelectedValue(comboboxCategoriaIVA, SelectedItemOptions.ValueOrFirst, CS_Parameter.GetIntegerAsByte(Parametros.DEFAULT_CATEGORIAIVA_ID, 0))
        FillAndRefreshLists.Provincia(comboboxDomicilioProvincia, False)
        CS_ComboBox.SetSelectedValue(comboboxDomicilioProvincia, SelectedItemOptions.ValueOrFirst, CS_Parameter.GetString(Parametros.DEFAULT_PROVINCIA_ID))
        CS_ComboBox.SetSelectedValue(comboboxDomicilioLocalidad, SelectedItemOptions.ValueOrFirst, CS_Parameter.GetIntegerAsShort(Parametros.DEFAULT_LOCALIDAD_ID))
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

            ' Datos sobre Impuestos
            CS_ComboBox.SetSelectedValue(comboboxDocumentoTipo, SelectedItemOptions.Value, .IDDocumentoTipo)
            If CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                maskedtextboxDocumentoNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DocumentoNumero)
            Else
                textboxDocumentoNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DocumentoNumero)
            End If

            CS_ComboBox.SetSelectedValue(comboboxCategoriaIVA, SelectedItemOptions.ValueOrFirst, .IDCategoriaIVA, 0)

            ' Datos de la pestaña Contacto
            textboxTelefono1.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Telefono1)
            textboxTelefono2.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Telefono2)
            textboxTelefono3.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Telefono3)
            textboxEmail1.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Email1)
            textboxEmail2.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Email2)
            textboxDomicilioCalle1.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCalle1)
            textboxDomicilioNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioNumero)
            textboxDomicilioPiso.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioPiso)
            textboxDomicilioDepartamento.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioDepartamento)
            textboxDomicilioCalle2.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCalle2)
            textboxDomicilioCalle3.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCalle3)
            CS_ComboBox.SetSelectedValue(comboboxDomicilioProvincia, SelectedItemOptions.Value, .DomicilioIDProvincia, Constantes.PROVINCIA_NOESPECIFICA)
            CS_ComboBox.SetSelectedValue(comboboxDomicilioLocalidad, SelectedItemOptions.Value, .DomicilioIDLocalidad, 0)
            textboxDomicilioCodigoPostal.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCodigoPostal)


            ' Datos de la pestaña Cursos Asistidos
            Dim listCursosAsistidos As New List(Of Object)
            For Each AnioLectivoCursoCurrent As AnioLectivoCurso In EntidadCurrent.AniosLectivosCursos.OrderByDescending(Function(alc) alc.AnioLectivo).ToList
                listCursosAsistidos.Add(New With {.AnioLectivo = AnioLectivoCursoCurrent.AnioLectivo, .NivelNombre = AnioLectivoCursoCurrent.Curso.Anio.Nivel.Nombre, .AnioNombre = AnioLectivoCursoCurrent.Curso.Anio.Nombre, .TurnoNombre = AnioLectivoCursoCurrent.Curso.Turno.Nombre, .Division = AnioLectivoCursoCurrent.Curso.Division})
            Next
            datagridviewCursosAsistidos.DataSource = listCursosAsistidos

            ' Datos de la pestaña Hijos
            Using dbcHijos As New CSColegioContext(True)
                Dim qryHijos = From ent In dbcHijos.Entidad
                               Where ent.IDEntidadPadre = .IDEntidad Or ent.IDEntidadMadre = .IDEntidad
                               Select IDEntidad = ent.IDEntidad, Apellido = ent.Apellido, Nombre = ent.Nombre
                datagridviewHijos.AutoGenerateColumns = False
                datagridviewHijos.DataSource = qryHijos.ToList
            End Using

            ' Datos de la pestaña Relaciones Padres
            Using dbcRelaciones As New CSColegioContext(True)
                Dim qryRelacionesPadres = From ent In dbcRelaciones.Entidad
                                         Join entxent In dbcRelaciones.EntidadEntidad On ent.IDEntidad Equals entxent.IDEntidadPadre
                                         Join reltip In dbcRelaciones.RelacionTipo On entxent.IDRelacionTipo Equals reltip.IDRelacionTipo
                                         Where entxent.IDEntidadHija = .IDEntidad
                                         Select IDEntidad = ent.IDEntidad, Apellido = ent.Apellido, Nombre = ent.Nombre, RelacionTipoNombre = reltip.Nombre

                datagridviewRelaciones.AutoGenerateColumns = False
                datagridviewRelaciones.DataSource = qryRelacionesPadres.ToList
            End Using

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
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With EntidadCurrent
            ' Datos del Encabezado
            .EsActivo = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxEsActivo.CheckState)
            .Apellido = textboxApellido.Text.Trim
            .Nombre = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNombre.Text.Trim)

            'Datos de la pestaña General
            .TipoPersonalColegio = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoPersonalColegio.CheckState)
            .TipoDocente = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoDocente.CheckState)
            .TipoAlumno = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoAlumno.CheckState)
            .TipoFamiliar = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoFamiliar.CheckState)
            .TipoProveedor = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoProveedor.CheckState)
            .IDDocumentoTipo = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxDocumentoTipo.SelectedValue, 0)
            If CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                .DocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(maskedtextboxDocumentoNumero.Text.Trim)
            Else
                .DocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDocumentoNumero.Text.Trim)
            End If
            .FacturaIDDocumentoTipo = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxFacturaDocumentoTipo.SelectedValue, 0)
            If CType(comboboxFacturaDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                .FacturaDocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(maskedtextboxFacturaDocumentoNumero.Text.Trim)
            Else
                .FacturaDocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxFacturaDocumentoNumero.Text.Trim)
            End If
            .Genero = CS_ValueTranslation.FromControlComboBoxToObjectString(comboboxGenero.SelectedValue, Constantes.GENERO_NOESPECIFICA)
            .FechaNacimiento = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaNacimiento.Value, datetimepickerFechaNacimiento.Checked)
            .IDCategoriaIVA = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxCategoriaIVA.SelectedValue, 0)

            ' Datos de la pestaña Contacto
            .Telefono1 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono1.Text)
            .Telefono2 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono2.Text)
            .Telefono3 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono3.Text)
            .Email1 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxEmail1.Text)
            .Email2 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxEmail2.Text)
            .DomicilioCalle1 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCalle1.Text)
            .DomicilioNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioNumero.Text)
            .DomicilioPiso = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioPiso.Text)
            .DomicilioDepartamento = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioDepartamento.Text)
            .DomicilioCalle2 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCalle2.Text)
            .DomicilioCalle3 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCalle3.Text)
            .DomicilioIDProvincia = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxDomicilioProvincia.SelectedValue, Constantes.PROVINCIA_NOESPECIFICA)
            .DomicilioIDLocalidad = CS_ValueTranslation.FromControlComboBoxToObjectShort(comboboxDomicilioLocalidad.SelectedValue, 0)
            .DomicilioCodigoPostal = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCodigoPostal.Text)

            ' Datos de la pestaña Padres y Facturación
            .IDEntidadPadre = CS_ValueTranslation.FromControlTagToObjectInteger(textboxEntidadPadre.Tag)
            .IDEntidadMadre = CS_ValueTranslation.FromControlTagToObjectInteger(textboxEntidadMadre.Tag)
            .EmitirFacturaA = CS_ValueTranslation.FromControlComboBoxToObjectString(comboboxEmitirFacturaA.SelectedValue, Constantes.EMITIRFACTURAA_NOESPECIFICA)
            If .EmitirFacturaA = Constantes.EMITIRFACTURAA_TERCERO Or .EmitirFacturaA = Constantes.EMITIRFACTURAA_TODOS Then
                .IDEntidadTercero = CS_ValueTranslation.FromControlTagToObjectInteger(textboxEntidadTercero.Tag)
            Else
                .IDEntidadTercero = Nothing
            End If
            .IDDescuento = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxDescuento.SelectedValue, 0)
            .ExcluyeCalculoInteres = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxExcluyeCalculoInteres.CheckState)
            .FacturaIndividual = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxFacturaIndividual.CheckState)
            .ExcluyeFacturaDesde = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerExcluyeFacturaDesde.Value, datetimepickerExcluyeFacturaDesde.Checked)
            .ExcluyeFacturaHasta = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerExcluyeFacturaHasta.Value, datetimepickerExcluyeFacturaHasta.Checked)

            ' Datos de la pestaña Notas y Aditoría
            .Notas = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNotas.Text.Trim)
        End With
    End Sub

    Private Sub comboboxDocumentoTipo_SelectedIndexChanged() Handles comboboxDocumentoTipo.SelectedIndexChanged
        If Not comboboxDocumentoTipo.SelectedItem Is Nothing Then
            textboxDocumentoNumero.Visible = (CByte(comboboxDocumentoTipo.SelectedValue) > 0 AndAlso Not CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11)
            maskedtextboxDocumentoNumero.Visible = (CByte(comboboxDocumentoTipo.SelectedValue) > 0 AndAlso Not textboxDocumentoNumero.Visible)
        End If
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxIDEntidad.GotFocus, textboxApellido.GotFocus, textboxNombre.GotFocus, textboxDocumentoNumero.GotFocus, textboxTelefono1.GotFocus, textboxTelefono2.GotFocus, textboxTelefono3.GotFocus, textboxEmail1.GotFocus, textboxEmail2.GotFocus, textboxDomicilioCalle1.GotFocus, textboxDomicilioNumero.GotFocus, textboxDomicilioPiso.GotFocus, textboxDomicilioDepartamento.GotFocus, textboxDomicilioCodigoPostal.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub MaskedTextBoxs_GotFocus(sender As Object, e As EventArgs) Handles maskedtextboxDocumentoNumero.GotFocus
        CType(sender, MaskedTextBox).SelectAll()
    End Sub


    Private Sub comboboxDomicilioProvincia_SelectedIndexChanged() Handles comboboxDomicilioProvincia.SelectedIndexChanged
        If comboboxDomicilioProvincia.SelectedValue Is Nothing Then
            comboboxDomicilioLocalidad.Items.Clear()
        Else
            FillAndRefreshLists.Localidad(comboboxDomicilioLocalidad, CByte(comboboxDomicilioProvincia.SelectedValue), False)
        End If
    End Sub

    Private Sub comboboxDomicilioLocalidad_SelectedIndexChanged() Handles comboboxDomicilioLocalidad.SelectedIndexChanged
        If Not comboboxDomicilioLocalidad.SelectedItem Is Nothing Then
            textboxDomicilioCodigoPostal.Text = CType(comboboxDomicilioLocalidad.SelectedItem, Localidad).CodigoPostal
        End If
    End Sub
End Class