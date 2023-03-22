Public Class formEntidad

#Region "Declarations"

    Private mdbContext As New CSColegioContext(True)
    Private mEntidadActual As Entidad

    Private mIsLoading As Boolean = False
    Private mEditMode As Boolean = False

    Public Class GridRowData_Comprobante
        Public Property IDComprobante As Integer
        Public Property TipoNombre As String
        Public Property NumeroCompleto As String
        Public Property FechaEmision As Date
        Public Property ImporteTotal As Decimal
    End Class

#End Region

#Region "Form stuff"

    Friend Sub LoadAndShow(ByVal EditMode As Boolean, ByRef ParentForm As Form, ByVal IDEntidad As Integer)
        mIsLoading = True
        mEditMode = EditMode

        If IDEntidad = 0 Then
            ' Es Nuevo
            mEntidadActual = New Entidad
            With mEntidadActual
                .IDCategoriaIVA = CS_Parameter_System.GetIntegerAsByte(Parametros.DEFAULT_CATEGORIAIVA_ID)
                .VerificarEmail1 = False
                .VerificarEmail2 = False
                .DomicilioIDProvincia = CS_Parameter_System.GetIntegerAsByte(Parametros.DEFAULT_PROVINCIA_ID)
                .DomicilioIDLocalidad = CS_Parameter_System.GetIntegerAsShort(Parametros.DEFAULT_LOCALIDAD_ID)
                .DomicilioCodigoPostal = CS_Parameter_System.GetString(Parametros.DEFAULT_CODIGOPOSTAL)
                .EsActivo = True
                .IDUsuarioCreacion = pUsuario.IDUsuario
                .FechaHoraCreacion = Now
                .IDUsuarioModificacion = pUsuario.IDUsuario
                .FechaHoraModificacion = .FechaHoraCreacion
            End With
            mdbContext.Entidad.Add(mEntidadActual)
        Else
            mEntidadActual = mdbContext.Entidad.Find(IDEntidad)
        End If

        Me.MdiParent = pFormMDIMain
        CardonerSistemas.Forms.CenterToParent(ParentForm, Me)
        InitializeFormAndControls()
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

        buttonGuardar.Visible = mEditMode
        buttonCancelar.Visible = mEditMode
        buttonEditar.Visible = (mEditMode = False)
        buttonCerrar.Visible = (mEditMode = False)

        textboxApellido.ReadOnly = (mEditMode = False)
        textboxNombre.ReadOnly = (mEditMode = False)

        ' General
        checkboxTipoPersonalColegio.Enabled = mEditMode
        checkboxTipoDocente.Enabled = mEditMode
        checkboxTipoAlumno.Enabled = mEditMode
        checkboxTipoFamiliar.Enabled = mEditMode
        checkboxTipoProveedor.Enabled = mEditMode
        checkboxTipoOtro.Enabled = mEditMode
        comboboxDocumentoTipo.Enabled = mEditMode
        textboxDocumentoNumero.ReadOnly = (mEditMode = False)
        checkboxDocumentoNumeroVerificado.Enabled = mEditMode
        maskedtextboxDocumentoNumero.ReadOnly = (mEditMode = False)
        comboboxFacturaDocumentoTipo.Enabled = mEditMode
        textboxFacturaDocumentoNumero.ReadOnly = (mEditMode = False)
        checkboxFacturaDocumentoNumeroVerificado.Enabled = mEditMode
        maskedtextboxFacturaDocumentoNumero.ReadOnly = (mEditMode = False)
        comboboxGenero.Enabled = mEditMode
        datetimepickerFechaNacimiento.Enabled = mEditMode
        comboboxCategoriaIVA.Enabled = mEditMode

        ' Contacto
        textboxTelefono1.ReadOnly = (mEditMode = False)
        textboxTelefono2.ReadOnly = (mEditMode = False)
        textboxTelefono3.ReadOnly = (mEditMode = False)
        textboxEmail1.ReadOnly = (mEditMode = False)
        checkboxVerificarEmail1.Enabled = mEditMode
        textboxEmail2.ReadOnly = (mEditMode = False)
        checkboxVerificarEmail2.Enabled = mEditMode
        comboboxComprobanteEnviarEmail.Enabled = mEditMode
        textboxDomicilioCalle1.ReadOnly = (mEditMode = False)
        textboxDomicilioNumero.ReadOnly = (mEditMode = False)
        textboxDomicilioPiso.ReadOnly = (mEditMode = False)
        textboxDomicilioDepartamento.ReadOnly = (mEditMode = False)
        textboxDomicilioCalle2.ReadOnly = (mEditMode = False)
        textboxDomicilioCalle3.ReadOnly = (mEditMode = False)
        textboxDomicilioBarrio.ReadOnly = (mEditMode = False)
        comboboxDomicilioProvincia.Enabled = mEditMode
        comboboxDomicilioLocalidad.Enabled = mEditMode
        textboxDomicilioCodigoPostal.ReadOnly = (mEditMode = False)

        ' Padres y Facturación
        buttonEntidadPadre.Enabled = mEditMode
        buttonEntidadPadreBorrar.Enabled = mEditMode
        buttonEntidadMadre.Enabled = mEditMode
        buttonEntidadMadreBorrar.Enabled = mEditMode
        comboboxEmitirFacturaA.Enabled = mEditMode
        buttonEntidadTercero.Enabled = mEditMode
        buttonEntidadTerceroBorrar.Enabled = mEditMode
        comboboxDescuento.Enabled = mEditMode
        checkboxExcluyeCalculoInteres.Enabled = mEditMode
        checkboxFacturaIndividual.Enabled = mEditMode
        datetimepickerExcluyeFacturaDesde.Enabled = mEditMode
        datetimepickerExcluyeFacturaHasta.Enabled = mEditMode
        textboxFacturaLeyenda.ReadOnly = (mEditMode = False)

        ' Débito Automático
        radiobuttonDebitoAutomatico_Tipo_Ninguno.Enabled = mEditMode
        radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.Enabled = mEditMode
        radiobuttonDebitoAutomatico_Tipo_TarjetaCredito.Enabled = mEditMode
        maskedtextboxDebitoAutomaticoCBU.ReadOnly = (mEditMode = False)

        ' Notas y Auditoría
        textboxNotas.ReadOnly = (mEditMode = False)
        checkboxEsActivo.Enabled = mEditMode
        textboxIDOtroSistema.ReadOnly = (mEditMode = False)
    End Sub

    Friend Sub InitializeFormAndControls()
        SetAppearance()

        ' Cargo los ComboBox
        pFillAndRefreshLists.DocumentoTipo(comboboxDocumentoTipo, True)
        pFillAndRefreshLists.DocumentoTipo(comboboxFacturaDocumentoTipo, True)
        pFillAndRefreshLists.Genero(comboboxGenero, True)
        pFillAndRefreshLists.CategoriaIVA(comboboxCategoriaIVA, True)
        pFillAndRefreshLists.Entidad_ComprobanteEnviarEmail(comboboxComprobanteEnviarEmail)
        pFillAndRefreshLists.Provincia(comboboxDomicilioProvincia, True)
        pFillAndRefreshLists.Entidad_EmitirFacturaA(comboboxEmitirFacturaA, True)
        pFillAndRefreshLists.Descuento(comboboxDescuento, True)
    End Sub

    Friend Sub SetAppearance()
        checkboxTipoPersonalColegio.Text = My.Resources.STRING_ENTIDADTIPO_PERSONALCOLEGIO
        checkboxTipoDocente.Text = My.Resources.STRING_ENTIDADTIPO_DOCENTE
        checkboxTipoAlumno.Text = My.Resources.STRING_ENTIDADTIPO_ALUMNO
        checkboxTipoFamiliar.Text = My.Resources.STRING_ENTIDADTIPO_FAMILIAR
        checkboxTipoProveedor.Text = My.Resources.STRING_ENTIDADTIPO_PROVEEDOR
        checkboxTipoOtro.Text = My.Resources.STRING_ENTIDADTIPO_OTRO

        checkboxVerificarEmail1.Visible = Permisos.VerificarPermiso(Permisos.ENTIDAD_VERIFICACIONES_VER, False)
        checkboxVerificarEmail2.Visible = Permisos.VerificarPermiso(Permisos.ENTIDAD_VERIFICACIONES_VER, False)

        datagridviewCursosAsistidos.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        datagridviewCursosAsistidos.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont

        datagridviewHijos.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        datagridviewHijos.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont

        datagridviewComprobantes.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        datagridviewComprobantes.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont

        datagridviewRelaciones.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        datagridviewRelaciones.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        mEntidadActual = Nothing
        Me.Dispose()
    End Sub

#End Region

#Region "Load and Set Data"

    Friend Sub SetDataFromObjectToControls()
        With mEntidadActual
            ' Datos del Encabezado
            If .IDEntidad = 0 Then
                textboxIDEntidad.Text = My.Resources.STRING_ITEM_NEW_MALE
            Else
                textboxIDEntidad.Text = String.Format(.IDEntidad.ToString, "G")
            End If
            textboxApellido.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Apellido)
            textboxNombre.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Nombre)

            ' Datos de la pestaña General
            checkboxTipoPersonalColegio.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoPersonalColegio)
            checkboxTipoDocente.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoDocente)
            checkboxTipoAlumno.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoAlumno)
            checkboxTipoFamiliar.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoFamiliar)
            checkboxTipoProveedor.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoProveedor)
            checkboxTipoOtro.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoOtro)
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxDocumentoTipo, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirst, .IDDocumentoTipo, CardonerSistemas.Constants.FIELD_VALUE_NOTSPECIFIED_BYTE)
            If .IDDocumentoTipo.HasValue Then
                If CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                    maskedtextboxDocumentoNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DocumentoNumero)
                Else
                    textboxDocumentoNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DocumentoNumero)
                End If
            Else
                maskedtextboxDocumentoNumero.Text = ""
                textboxDocumentoNumero.Text = ""
            End If
            checkboxDocumentoNumeroVerificado.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.DocumentoNumeroVerificado)
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxFacturaDocumentoTipo, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirst, .FacturaIDDocumentoTipo, CardonerSistemas.Constants.FIELD_VALUE_NOTSPECIFIED_BYTE)
            If .FacturaIDDocumentoTipo.HasValue Then
                If CType(comboboxFacturaDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                    maskedtextboxFacturaDocumentoNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.FacturaDocumentoNumero)
                Else
                    textboxFacturaDocumentoNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.FacturaDocumentoNumero)
                End If
            Else
                maskedtextboxFacturaDocumentoNumero.Text = ""
                textboxFacturaDocumentoNumero.Text = ""
            End If
            checkboxFacturaDocumentoNumeroVerificado.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.FacturaDocumentoNumeroVerificado)
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxGenero, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirst, .Genero, Constantes.EntidadGeneroNoEspecifica)
            datetimepickerFechaNacimiento.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaNacimiento, datetimepickerFechaNacimiento)
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxCategoriaIVA, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirst, .IDCategoriaIVA, 0)

            ' Datos de la pestaña Contacto
            textboxTelefono1.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Telefono1)
            textboxTelefono2.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Telefono2)
            textboxTelefono3.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Telefono3)
            textboxEmail1.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Email1)
            checkboxVerificarEmail1.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.VerificarEmail1)
            textboxEmail2.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Email2)
            checkboxVerificarEmail2.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.VerificarEmail2)
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxComprobanteEnviarEmail, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirst, .ComprobanteEnviarEmail, Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_CUALQUIERA)
            textboxDomicilioCalle1.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCalle1)
            textboxDomicilioNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioNumero)
            textboxDomicilioPiso.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioPiso)
            textboxDomicilioDepartamento.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioDepartamento)
            textboxDomicilioCalle2.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCalle2)
            textboxDomicilioCalle3.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCalle3)
            textboxDomicilioBarrio.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioBarrio)
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxDomicilioProvincia, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.Value, .DomicilioIDProvincia, Constantes.PROVINCIA_NOESPECIFICA)
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxDomicilioLocalidad, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.Value, .DomicilioIDLocalidad, 0)
            textboxDomicilioCodigoPostal.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCodigoPostal)

            ' Datos de la pestaña Padres y Facturación
            If .EntidadPadre Is Nothing Then
                textboxEntidadPadre.Text = ""
                textboxEntidadPadre.Tag = Nothing
            Else
                textboxEntidadPadre.Text = .EntidadPadre.ApellidoNombre
                textboxEntidadPadre.Tag = .EntidadPadre.IDEntidad
            End If
            If .EntidadMadre Is Nothing Then
                textboxEntidadMadre.Text = ""
                textboxEntidadMadre.Tag = Nothing
            Else
                textboxEntidadMadre.Text = .EntidadMadre.ApellidoNombre
                textboxEntidadMadre.Tag = .EntidadMadre.IDEntidad
            End If
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxEmitirFacturaA, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirst, .EmitirFacturaA, Constantes.ENTIDAD_EMITIRFACTURAA_NOESPECIFICA)
            If .EntidadTercero Is Nothing OrElse (.EmitirFacturaA <> Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO And .EmitirFacturaA <> Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) Then
                textboxEntidadTercero.Text = ""
                textboxEntidadTercero.Tag = Nothing
            Else
                If .IDEntidadTercero Is Nothing Then
                    textboxEntidadTercero.Text = ""
                    textboxEntidadTercero.Tag = Nothing
                Else
                    textboxEntidadTercero.Text = .EntidadTercero.ApellidoNombre
                    textboxEntidadTercero.Tag = .EntidadTercero.IDEntidad
                End If
            End If
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxDescuento, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirst, .IDDescuento, 0)
            If .IDDescuento = CardonerSistemas.Constants.FIELD_VALUE_OTHER_BYTE Then
                CS_ValueTranslation_Syncfusion.FromValueToControl(.DescuentoOtroPorcentaje, percenttextboxDescuentoOtroPorcentaje)
            Else
                percenttextboxDescuentoOtroPorcentaje.PercentValue = 0
            End If
            checkboxFacturaIndividual.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.FacturaIndividual)
            checkboxExcluyeCalculoInteres.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.ExcluyeCalculoInteres)
            datetimepickerExcluyeFacturaDesde.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.ExcluyeFacturaDesde, datetimepickerExcluyeFacturaDesde)
            datetimepickerExcluyeFacturaHasta.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.ExcluyeFacturaHasta, datetimepickerExcluyeFacturaHasta)
            textboxFacturaLeyenda.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.FacturaLeyenda)

            ' Datos de la pestaña Débito Automático
            Select Case .DebitoAutomaticoTipo
                Case Nothing
                    radiobuttonDebitoAutomatico_Tipo_Ninguno.Checked = True
                    maskedtextboxDebitoAutomaticoCBU.Text = ""
                Case Constantes.ENTIDAD_DEBITOAUTOMATICOTIPO_DEBITODIRECTO
                    radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.Checked = True
                    maskedtextboxDebitoAutomaticoCBU.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DebitoAutomaticoDirectoCBU)
                Case Constantes.ENTIDAD_DEBITOAUTOMATICOTIPO_TARJETACREDITO
                    radiobuttonDebitoAutomatico_Tipo_TarjetaCredito.Checked = True
                    maskedtextboxDebitoAutomaticoCBU.Text = ""
            End Select

            ' Datos de la pestaña Cursos Asistidos
            RefreshData_CursosAsistidos()

            ' Datos de la pestaña Hijos
            RefreshData_Hijos()

            ' Datos de la pestaña Comprobantes
            RefreshData_Comprobantes()

            ' Datos de la pestaña Relaciones Padres
            'RefreshData_Relaciones()

            ' Datos de la pestaña Notas y Auditoría
            textboxNotas.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Notas)
            checkboxEsActivo.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.EsActivo)
            textboxIDOtroSistema.Text = String.Format(.IDOtroSistema.ToString, "G")
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
        With mEntidadActual
            ' Datos del Encabezado
            .Apellido = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxApellido.Text)
            .Nombre = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNombre.Text)

            'Datos de la pestaña General
            .TipoPersonalColegio = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoPersonalColegio.CheckState)
            .TipoDocente = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoDocente.CheckState)
            .TipoAlumno = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoAlumno.CheckState)
            .TipoFamiliar = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoFamiliar.CheckState)
            .TipoProveedor = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoProveedor.CheckState)
            .TipoOtro = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoOtro.CheckState)
            .IDDocumentoTipo = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxDocumentoTipo.SelectedValue, CardonerSistemas.Constants.FIELD_VALUE_NOTSPECIFIED_BYTE)
            If CByte(comboboxDocumentoTipo.SelectedValue) = CardonerSistemas.Constants.FIELD_VALUE_NOTSPECIFIED_BYTE Then
                .DocumentoNumero = Nothing
                .DocumentoNumeroVerificado = False
            Else
                If CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                    .DocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(maskedtextboxDocumentoNumero.Text)
                Else
                    .DocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDocumentoNumero.Text)
                End If
                .DocumentoNumeroVerificado = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxDocumentoNumeroVerificado.CheckState)
            End If
            .FacturaIDDocumentoTipo = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxFacturaDocumentoTipo.SelectedValue, CardonerSistemas.Constants.FIELD_VALUE_NOTSPECIFIED_BYTE)
            If CByte(comboboxFacturaDocumentoTipo.SelectedValue) = CardonerSistemas.Constants.FIELD_VALUE_NOTSPECIFIED_BYTE Then
                .FacturaDocumentoNumero = Nothing
                .FacturaDocumentoNumeroVerificado = False
            Else
                If CType(comboboxFacturaDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                    .FacturaDocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(maskedtextboxFacturaDocumentoNumero.Text)
                Else
                    .FacturaDocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxFacturaDocumentoNumero.Text)
                End If
                .FacturaDocumentoNumeroVerificado = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxFacturaDocumentoNumeroVerificado.CheckState)
            End If
            .Genero = CS_ValueTranslation.FromControlComboBoxToObjectString(comboboxGenero.SelectedValue, Constantes.EntidadGeneroNoEspecifica)
            .FechaNacimiento = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaNacimiento.Value, datetimepickerFechaNacimiento.Checked)
            .IDCategoriaIVA = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxCategoriaIVA.SelectedValue, 0)

            ' Datos de la pestaña Contacto
            .Telefono1 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono1.Text)
            .Telefono2 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono2.Text)
            .Telefono3 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono3.Text)
            .Email1 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxEmail1.Text)
            .VerificarEmail1 = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxVerificarEmail1.CheckState)
            .Email2 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxEmail2.Text)
            .VerificarEmail2 = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxVerificarEmail2.CheckState)
            .ComprobanteEnviarEmail = CS_ValueTranslation.FromControlComboBoxToObjectString(comboboxComprobanteEnviarEmail.SelectedValue)
            .DomicilioCalle1 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCalle1.Text)
            .DomicilioNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioNumero.Text)
            .DomicilioPiso = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioPiso.Text)
            .DomicilioDepartamento = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioDepartamento.Text)
            .DomicilioCalle2 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCalle2.Text)
            .DomicilioCalle3 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCalle3.Text)
            .DomicilioBarrio = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioBarrio.Text)
            .DomicilioIDProvincia = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxDomicilioProvincia.SelectedValue, Constantes.PROVINCIA_NOESPECIFICA)
            .DomicilioIDLocalidad = CS_ValueTranslation.FromControlComboBoxToObjectShort(comboboxDomicilioLocalidad.SelectedValue, 0)
            .DomicilioCodigoPostal = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCodigoPostal.Text)

            ' Datos de la pestaña Padres y Facturación
            .IDEntidadPadre = CS_ValueTranslation.FromControlTagToObjectInteger(textboxEntidadPadre.Tag)
            .IDEntidadMadre = CS_ValueTranslation.FromControlTagToObjectInteger(textboxEntidadMadre.Tag)
            .EmitirFacturaA = CS_ValueTranslation.FromControlComboBoxToObjectString(comboboxEmitirFacturaA.SelectedValue, Constantes.ENTIDAD_EMITIRFACTURAA_NOESPECIFICA)
            If .EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or .EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                .IDEntidadTercero = CS_ValueTranslation.FromControlTagToObjectInteger(textboxEntidadTercero.Tag)
            Else
                .IDEntidadTercero = Nothing
            End If
            .IDDescuento = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxDescuento.SelectedValue, 0)
            If comboboxDescuento.SelectedIndex > -1 AndAlso CByte(comboboxDescuento.SelectedValue) = CardonerSistemas.Constants.FIELD_VALUE_OTHER_BYTE Then
                .DescuentoOtroPorcentaje = CS_ValueTranslation_Syncfusion.FromControlToDecimal(percenttextboxDescuentoOtroPorcentaje)
            Else
                .DescuentoOtroPorcentaje = Nothing
            End If
            .FacturaIndividual = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxFacturaIndividual.CheckState)
            .ExcluyeCalculoInteres = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxExcluyeCalculoInteres.CheckState)
            .ExcluyeFacturaDesde = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerExcluyeFacturaDesde.Value, datetimepickerExcluyeFacturaDesde.Checked)
            .ExcluyeFacturaHasta = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerExcluyeFacturaHasta.Value, datetimepickerExcluyeFacturaHasta.Checked)
            .FacturaLeyenda = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxFacturaLeyenda.Text)

            ' Datos de la pestaña Débito Automático
            If radiobuttonDebitoAutomatico_Tipo_Ninguno.Checked Then
                .DebitoAutomaticoTipo = Nothing
                .DebitoAutomaticoDirectoCBU = Nothing
            ElseIf radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.Checked Then
                .DebitoAutomaticoTipo = Constantes.ENTIDAD_DEBITOAUTOMATICOTIPO_DEBITODIRECTO
                .DebitoAutomaticoDirectoCBU = CS_ValueTranslation.FromControlTextBoxToObjectString(maskedtextboxDebitoAutomaticoCBU.Text)
            ElseIf radiobuttonDebitoAutomatico_Tipo_TarjetaCredito.Checked Then
                .DebitoAutomaticoTipo = Constantes.ENTIDAD_DEBITOAUTOMATICOTIPO_TARJETACREDITO
                .DebitoAutomaticoDirectoCBU = Nothing
            End If

            ' Datos de la pestaña Notas y Aditoría
            .Notas = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNotas.Text)
            .EsActivo = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxEsActivo.CheckState)
            .IDOtroSistema = CS_ValueTranslation.FromControlTextBoxToObjectInteger(textboxIDOtroSistema.Text)
        End With
    End Sub

    Friend Sub RefreshData_CursosAsistidos()
        Dim listCursosAsistidos As New List(Of Object)
        For Each AnioLectivoCursoCurrent As AnioLectivoCurso In mEntidadActual.AniosLectivosCursos.OrderByDescending(Function(alc) alc.AnioLectivo).ToList
            listCursosAsistidos.Add(New With {AnioLectivoCursoCurrent.AnioLectivo, .NivelNombre = AnioLectivoCursoCurrent.Curso.Anio.Nivel.Nombre, .AnioNombre = AnioLectivoCursoCurrent.Curso.Anio.Nombre, .TurnoNombre = AnioLectivoCursoCurrent.Curso.Turno.Nombre, AnioLectivoCursoCurrent.Curso.Division})
        Next
        datagridviewCursosAsistidos.DataSource = listCursosAsistidos
    End Sub

    Friend Sub RefreshData_Hijos()
        Using dbcHijos As New CSColegioContext(True)
            Dim qryHijos = From ent In dbcHijos.Entidad
                           Where ent.IDEntidadPadre = mEntidadActual.IDEntidad Or ent.IDEntidadMadre = mEntidadActual.IDEntidad
                           Select IDEntidad = ent.IDEntidad, Apellido = ent.Apellido, Nombre = ent.Nombre
            datagridviewHijos.AutoGenerateColumns = False
            datagridviewHijos.DataSource = qryHijos.ToList
        End Using
    End Sub

    Friend Sub RefreshData_Comprobantes()
        Dim listComprobantes As List(Of GridRowData_Comprobante)

        Using dbContext As New CSColegioContext(True)
            listComprobantes = (From c In dbContext.Comprobante
                                Where c.IDEntidad = mEntidadActual.IDEntidad And c.IDUsuarioAnulacion Is Nothing
                                Order By c.FechaEmision Descending
                                Select New GridRowData_Comprobante With {.IDComprobante = c.IDComprobante, .TipoNombre = c.ComprobanteTipo.NombreConLetra, .NumeroCompleto = c.NumeroCompleto, .FechaEmision = c.FechaEmision, .ImporteTotal = c.ImporteTotal1}).ToList
        End Using

        datagridviewComprobantes.AutoGenerateColumns = False
        datagridviewComprobantes.DataSource = listComprobantes
    End Sub

    Friend Sub RefreshData_Relaciones()
        Using dbcRelaciones As New CSColegioContext(True)
            Dim qryRelacionesPadres = From ent In dbcRelaciones.Entidad
                                      Join entxent In dbcRelaciones.EntidadEntidad On ent.IDEntidad Equals entxent.IDEntidadPadre
                                      Join reltip In dbcRelaciones.RelacionTipo On entxent.IDRelacionTipo Equals reltip.IDRelacionTipo
                                      Where entxent.IDEntidadHija = mEntidadActual.IDEntidad
                                      Select IDEntidad = ent.IDEntidad, Apellido = ent.Apellido, Nombre = ent.Nombre, RelacionTipoNombre = reltip.Nombre

            datagridviewRelaciones.AutoGenerateColumns = False
            datagridviewRelaciones.DataSource = qryRelacionesPadres.ToList
        End Using
    End Sub

#End Region

#Region "Controls behavior"

    Private Sub FormKeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                If mEditMode Then
                    buttonGuardar.PerformClick()
                Else
                    buttonCerrar.PerformClick()
                End If
            Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                If mEditMode Then
                    buttonCancelar.PerformClick()
                Else
                    buttonCerrar.PerformClick()
                End If
        End Select
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxIDEntidad.GotFocus, textboxApellido.GotFocus, textboxNombre.GotFocus, textboxDocumentoNumero.GotFocus, textboxTelefono1.GotFocus, textboxTelefono2.GotFocus, textboxTelefono3.GotFocus, textboxEmail1.GotFocus, textboxEmail2.GotFocus, textboxDomicilioCalle1.GotFocus, textboxDomicilioNumero.GotFocus, textboxDomicilioPiso.GotFocus, textboxDomicilioDepartamento.GotFocus, textboxDomicilioCodigoPostal.GotFocus, textboxNotas.GotFocus, textboxIDOtroSistema.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub MaskedTextBoxs_GotFocus(sender As Object, e As EventArgs) Handles maskedtextboxDocumentoNumero.GotFocus, maskedtextboxFacturaDocumentoNumero.GotFocus, maskedtextboxDebitoAutomaticoCBU.GotFocus
        CType(sender, MaskedTextBox).SelectAll()
    End Sub

    Private Sub ComboboxDocumentoTipo_SelectedIndexChanged() Handles comboboxDocumentoTipo.SelectedIndexChanged
        If comboboxDocumentoTipo.SelectedItem IsNot Nothing Then
            textboxDocumentoNumero.Visible = (CByte(comboboxDocumentoTipo.SelectedValue) > 0 AndAlso Not CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11)
            maskedtextboxDocumentoNumero.Visible = (CByte(comboboxDocumentoTipo.SelectedValue) > 0 AndAlso Not textboxDocumentoNumero.Visible)
            labelDocumentoNumeroVerificado.Visible = (CByte(comboboxDocumentoTipo.SelectedValue) > 0 AndAlso Permisos.VerificarPermiso(Permisos.ENTIDAD_VERIFICACIONES_VER, False))
            checkboxDocumentoNumeroVerificado.Visible = (CByte(comboboxDocumentoTipo.SelectedValue) > 0 AndAlso Permisos.VerificarPermiso(Permisos.ENTIDAD_VERIFICACIONES_VER, False))
        End If
    End Sub

    Private Sub ComboboxFacturaDocumentoTipo_SelectedIndexChanged() Handles comboboxFacturaDocumentoTipo.SelectedIndexChanged
        If comboboxFacturaDocumentoTipo.SelectedItem IsNot Nothing Then
            textboxFacturaDocumentoNumero.Visible = (CByte(comboboxFacturaDocumentoTipo.SelectedValue) > 0 AndAlso Not CType(comboboxFacturaDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11)
            maskedtextboxFacturaDocumentoNumero.Visible = (CByte(comboboxFacturaDocumentoTipo.SelectedValue) > 0 AndAlso Not textboxFacturaDocumentoNumero.Visible)
            labelFacturaDocumentoNumeroVerificado.Visible = (CByte(comboboxFacturaDocumentoTipo.SelectedValue) > 0 AndAlso Permisos.VerificarPermiso(Permisos.ENTIDAD_VERIFICACIONES_VER, False))
            checkboxFacturaDocumentoNumeroVerificado.Visible = (CByte(comboboxFacturaDocumentoTipo.SelectedValue) > 0 AndAlso Permisos.VerificarPermiso(Permisos.ENTIDAD_VERIFICACIONES_VER, False))
        End If
    End Sub

    Private Sub DocumentoNumero_LimpiarCaracteres(sender As Object, e As EventArgs) Handles textboxDocumentoNumero.LostFocus, textboxFacturaDocumentoNumero.LostFocus
        CType(sender, TextBox).Text = CType(sender, TextBox).Text.Replace(".", "")
    End Sub

    Private Sub ComboboxDomicilioProvincia_SelectedValueChanged() Handles comboboxDomicilioProvincia.SelectedValueChanged
        If comboboxDomicilioProvincia.SelectedValue Is Nothing Then
            comboboxDomicilioLocalidad.DataSource = Nothing
        Else
            pFillAndRefreshLists.Localidad(comboboxDomicilioLocalidad, CByte(comboboxDomicilioProvincia.SelectedValue), False)
            If CByte(comboboxDomicilioProvincia.SelectedValue) = CS_Parameter_System.GetIntegerAsByte(Parametros.DEFAULT_PROVINCIA_ID) Then
                CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxDomicilioLocalidad, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirst, CS_Parameter_System.GetIntegerAsShort(Parametros.DEFAULT_LOCALIDAD_ID))
            End If
        End If
    End Sub

    Private Sub ComboboxDomicilioLocalidad_SelectedValueChanged() Handles comboboxDomicilioLocalidad.SelectedValueChanged
        If comboboxDomicilioLocalidad.SelectedValue IsNot Nothing Then
            textboxDomicilioCodigoPostal.Text = CType(comboboxDomicilioLocalidad.SelectedItem, Localidad).CodigoPostal
        End If
    End Sub

    Private Sub EntidadPadre_Click(sender As Object, e As EventArgs) Handles buttonEntidadPadre.Click
        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = True
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Otro.Checked = False
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim EntidadSeleccionada As Entidad
            EntidadSeleccionada = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
            textboxEntidadPadre.Text = EntidadSeleccionada.ApellidoNombre
            textboxEntidadPadre.Tag = EntidadSeleccionada.IDEntidad
        End If
        formEntidadesSeleccionar.Dispose()
    End Sub

    Private Sub EntidadPadreBorrar_Click(sender As Object, e As EventArgs) Handles buttonEntidadPadreBorrar.Click
        textboxEntidadPadre.Text = ""
        textboxEntidadPadre.Tag = Nothing
    End Sub

    Private Sub EntidadMadre_Click(sender As Object, e As EventArgs) Handles buttonEntidadMadre.Click
        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = True
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Otro.Checked = False
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim EntidadSeleccionada As Entidad
            EntidadSeleccionada = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
            textboxEntidadMadre.Text = EntidadSeleccionada.ApellidoNombre
            textboxEntidadMadre.Tag = EntidadSeleccionada.IDEntidad
        End If
        formEntidadesSeleccionar.Dispose()
    End Sub

    Private Sub EntidadMadreBorrar_Click(sender As Object, e As EventArgs) Handles buttonEntidadMadreBorrar.Click
        textboxEntidadMadre.Text = ""
        textboxEntidadMadre.Tag = Nothing
    End Sub

    Private Sub ComboboxEmitirFacturaA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboboxEmitirFacturaA.SelectedIndexChanged
        If comboboxEmitirFacturaA.SelectedIndex > -1 Then
            labelEntidadTercero.Visible = (comboboxEmitirFacturaA.SelectedValue.ToString = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or comboboxEmitirFacturaA.SelectedValue.ToString = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS)
            panelEntidadTercero.Visible = (comboboxEmitirFacturaA.SelectedValue.ToString = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or comboboxEmitirFacturaA.SelectedValue.ToString = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS)
        End If
    End Sub

    Private Sub EntidadTercero_Click(sender As Object, e As EventArgs) Handles buttonEntidadTercero.Click
        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = True
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Otro.Checked = False
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim EntidadSeleccionada As Entidad
            EntidadSeleccionada = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
            textboxEntidadTercero.Text = EntidadSeleccionada.ApellidoNombre
            textboxEntidadTercero.Tag = EntidadSeleccionada.IDEntidad
        End If
        formEntidadesSeleccionar.Dispose()
    End Sub

    Private Sub EntidadTerceroBorrar_Click(sender As Object, e As EventArgs) Handles buttonEntidadTerceroBorrar.Click
        textboxEntidadTercero.Text = ""
        textboxEntidadTercero.Tag = Nothing
    End Sub

    Private Sub ComboboxDescuento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboboxDescuento.SelectedIndexChanged
        If comboboxDescuento.SelectedIndex > -1 AndAlso CByte(comboboxDescuento.SelectedValue) = CardonerSistemas.Constants.FIELD_VALUE_OTHER_BYTE Then
            percenttextboxDescuentoOtroPorcentaje.Visible = True
        Else
            percenttextboxDescuentoOtroPorcentaje.Visible = False
        End If
    End Sub

    Private Sub DebitoAutomaticoTipo_CheckedChanged(sender As Object, e As EventArgs) Handles radiobuttonDebitoAutomatico_Tipo_Ninguno.CheckedChanged, radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.CheckedChanged, radiobuttonDebitoAutomatico_Tipo_TarjetaCredito.CheckedChanged
        labelDebitoAutomaticoCBU.visible = (CType(sender, RadioButton) Is radiobuttonDebitoAutomatico_Tipo_DebitoDirecto)
        maskedtextboxDebitoAutomaticoCBU.Visible = (CType(sender, RadioButton) Is radiobuttonDebitoAutomatico_Tipo_DebitoDirecto)
    End Sub

#End Region

#Region "Main Toolbar"

    Private Sub Editar() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDAD_EDITAR) Then
            mEditMode = True
            ChangeMode()
        End If
    End Sub

    Private Sub Cerrar() Handles buttonCerrar.Click
        Me.Close()
    End Sub

    Private Sub Guardar() Handles buttonGuardar.Click
        If Not VerificarDatos() Then
            Exit Sub
        End If

        ' Generar el ID de la Entidad nueva
        If mEntidadActual.IDEntidad = 0 Then
            Using dbcMaxID As New CSColegioContext(True)
                If dbcMaxID.Entidad.Count = 0 Then
                    mEntidadActual.IDEntidad = 1
                Else
                    mEntidadActual.IDEntidad = dbcMaxID.Entidad.Max(Function(ent) ent.IDEntidad) + 1
                End If
            End Using
            mEntidadActual.FechaHoraCreacion = Now
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        If mdbContext.ChangeTracker.HasChanges Then

            Me.Cursor = Cursors.WaitCursor

            mEntidadActual.IDUsuarioModificacion = pUsuario.IDUsuario
            mEntidadActual.FechaHoraModificacion = Now

            Try
                ' Guardo los cambios
                mdbContext.SaveChanges()

                ' Refresco la lista de Entidades para mostrar los cambios
                If CardonerSistemas.Forms.MdiChildIsLoaded(CType(pFormMDIMain, Form), "formEntidades") Then
                    Dim formEntidades As formEntidades = CType(CardonerSistemas.Forms.MdiChildGetInstance(CType(pFormMDIMain, Form), "formEntidades"), formEntidades)
                    formEntidades.RefreshData(mEntidadActual.IDEntidad)
                    formEntidades = Nothing
                End If

            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Me.Cursor = Cursors.Default
                Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                    Case CardonerSistemas.Database.EntityFramework.Errors.DuplicatedEntity
                        If dbuex.InnerException IsNot Nothing AndAlso dbuex.InnerException.InnerException IsNot Nothing Then
                            If dbuex.InnerException.InnerException.Message.Contains("UX_Entidad_ApellidoNombre") Then
                                MsgBox("No se pueden guardar los cambios porque ya existe una Entidad con el mismo Apellido y Nombre.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                                Return
                            ElseIf dbuex.InnerException.InnerException.Message.Contains("UX_Entidad_Documento") Then
                                MsgBox("No se pueden guardar los cambios porque ya existe una Entidad con el mismo Tipo y Número de Documento.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                                Return
                            ElseIf dbuex.InnerException.InnerException.Message.Contains("UX_Entidad_FacturaDocumento") Then
                                MsgBox("No se pueden guardar los cambios porque ya existe una Entidad con el mismo Tipo y Número de Documento para Facturar.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                                Return
                            End If
                        End If
                        MsgBox("No se pueden guardar los cambios porque ya existe una Entidad con algunos valores iguales.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
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
        End If

        Me.Close()
    End Sub

    Private Sub Cancelar_Click() Handles buttonCancelar.Click
        If mdbContext.ChangeTracker.HasChanges Then
            If MsgBox("Ha realizado cambios en los datos y seleccionó cancelar, los cambios se perderán." & vbCr & vbCr & "¿Confirma la pérdida de los cambios?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

#End Region

#Region "Extra stuff"

    Private Sub HijoVer() Handles datagridviewHijos.DoubleClick
        If datagridviewHijos.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Hijo para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewHijos.Enabled = False

            Me.LoadAndShow(False, Me, CInt(datagridviewHijos.SelectedRows(0).Cells(0).Value))

            datagridviewHijos.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub ComprobanteVer() Handles datagridviewComprobantes.DoubleClick
        If datagridviewComprobantes.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comprobante para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewComprobantes.Enabled = False

            FormComprobante.LoadAndShow(False, Me, CType(datagridviewComprobantes.SelectedRows(0).DataBoundItem, GridRowData_Comprobante).IDComprobante)

            datagridviewComprobantes.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Function VerificarDatos() As Boolean
        ' Verificar que estén todos los campos con datos coherentes
        If textboxApellido.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar el Apellido.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxApellido.Focus()
            Return False
        End If
        If checkboxTipoPersonalColegio.Checked = False And checkboxTipoDocente.Checked = False And checkboxTipoAlumno.Checked = False And checkboxTipoFamiliar.Checked = False And checkboxTipoProveedor.Checked = False And checkboxTipoOtro.Checked = False Then
            tabcontrolMain.SelectedTab = tabpageGeneral
            MsgBox("Debe especificar el Tipo de Entidad.", MsgBoxStyle.Information, My.Application.Info.Title)
            Return False
        End If

        ' Verifico el Número de Documento
        If comboboxDocumentoTipo.SelectedIndex > 0 AndAlso textboxDocumentoNumero.Text.Length = 0 Then
            If CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                If maskedtextboxDocumentoNumero.Text.Length = 0 Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("Si especifica el Tipo de Documento, también debe especificar el Número de Documento.", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxDocumentoNumero.Focus()
                    Return False
                End If
                If maskedtextboxDocumentoNumero.Text.Trim.Length < 11 Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("El Número de " & CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).Nombre & " debe contener 11 dígitos (sin contar los guiones).", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxDocumentoNumero.Focus()
                    Return False
                End If
                If Not CardonerSistemas.Afip.VerificarCuit(maskedtextboxDocumentoNumero.Text) Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("El Número de " & CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).Nombre & " ingresado es incorrecto.", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxDocumentoNumero.Focus()
                    Return False
                End If
            Else
                If textboxDocumentoNumero.Text.Length = 0 Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("Si especifica el Tipo de Documento, también debe especificar el Número de Documento.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxDocumentoNumero.Focus()
                    Return False
                End If
            End If
        End If

        ' Verifico el Número de Documento para la Factura
        If comboboxFacturaDocumentoTipo.SelectedIndex > 0 AndAlso textboxFacturaDocumentoNumero.Text.Length = 0 Then
            If CType(comboboxFacturaDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                If maskedtextboxFacturaDocumentoNumero.Text.Trim.Length = 0 Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("Si especifica el Tipo de Documento para Facturar, también debe especificar el Número de Documento para Facturar.", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxFacturaDocumentoNumero.Focus()
                    Return False
                End If
                If maskedtextboxFacturaDocumentoNumero.Text.Trim.Length < 11 Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("El Número de " & CType(comboboxFacturaDocumentoTipo.SelectedItem, DocumentoTipo).Nombre & " debe contener 11 dígitos (sin contar los guiones).", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxFacturaDocumentoNumero.Focus()
                    Return False
                End If
                If Not CardonerSistemas.Afip.VerificarCuit(maskedtextboxFacturaDocumentoNumero.Text) Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("El Número de " & CType(comboboxFacturaDocumentoTipo.SelectedItem, DocumentoTipo).Nombre & " ingresado es incorrecto.", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxFacturaDocumentoNumero.Focus()
                    Return False
                End If
            Else
                If textboxFacturaDocumentoNumero.Text.Length = 0 Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("Si especifica el Tipo de Documento, también debe especificar el Número de Documento para Facturar.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxFacturaDocumentoNumero.Focus()
                    Return False
                End If
            End If
        End If

        ' Fecha de Nacimiento
        If datetimepickerFechaNacimiento.Checked And datetimepickerFechaNacimiento.Value.Year = Today.Year Then
            tabcontrolMain.SelectedTab = tabpageGeneral
            MsgBox("Se ha especificado una Fecha de Nacimiento que no parece ser válida ya que es del año actual.", MsgBoxStyle.Information, My.Application.Info.Title)
            datetimepickerFechaNacimiento.Focus()
            Return False
        End If

        ' Direcciones de Email
        If textboxEmail1.Text.Trim.Length > 0 Then
            If Not CS_Email.IsValidEmail(textboxEmail1.Text.Trim) Then
                tabcontrolMain.SelectedTab = tabpageContacto
                MsgBox("La dirección de e-Mail 1 es incorrecta.", vbInformation, My.Application.Info.Title)
                textboxEmail1.Focus()
                Return False
            End If
        Else
            If checkboxVerificarEmail1.Checked Then
                checkboxVerificarEmail1.Checked = False
            End If
        End If
        If textboxEmail2.Text.Trim.Length > 0 Then
            If Not CS_Email.IsValidEmail(textboxEmail2.Text.Trim) Then
                tabcontrolMain.SelectedTab = tabpageContacto
                MsgBox("La dirección de e-Mail 2 es incorrecta.", vbInformation, My.Application.Info.Title)
                textboxEmail2.Focus()
                Return False
            End If
        Else
            If checkboxVerificarEmail2.Checked Then
                checkboxVerificarEmail2.Checked = False
            End If
        End If
        If textboxEmail1.Text.Trim.Length > 0 And textboxEmail2.Text.Trim.Length > 0 Then
            If textboxEmail1.Text.Trim = textboxEmail2.Text.Trim Then
                tabcontrolMain.SelectedTab = tabpageContacto
                MsgBox("Ambas direcciones de e-Mail son iguales.", vbInformation, My.Application.Info.Title)
                textboxEmail2.Focus()
                Return False
            End If
        End If

        ' Emitir Factura A:
        Select Case CStr(comboboxEmitirFacturaA.SelectedValue)
            Case Constantes.ENTIDAD_EMITIRFACTURAA_NOESPECIFICA
                If checkboxTipoAlumno.Checked AndAlso ((textboxEntidadPadre.Tag IsNot Nothing) And (textboxEntidadMadre.Tag IsNot Nothing)) Then
                    If MsgBox("Ha especificado el Padre y/o la Madre del Alumno, pero no especificó a quien se le facturará." & vbCrLf & vbCrLf & "¿Desea hacerlo ahora?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                        tabcontrolMain.SelectedTab = tabpagePadresYFacturacion
                        comboboxEmitirFacturaA.Focus()
                        Return False
                    End If
                End If
            Case Constantes.ENTIDAD_EMITIRFACTURAA_PADRE
                If textboxEntidadPadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpagePadresYFacturacion
                    MsgBox("Si las facturas se emitirán a nombre del Padre / Tutor, debe especificar el mismo.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadPadre.Focus()
                    Return False
                End If
            Case Constantes.ENTIDAD_EMITIRFACTURAA_MADRE
                If textboxEntidadMadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpagePadresYFacturacion
                    MsgBox("Si las facturas se emitirán a nombre de la Madre / Tutora, debe especificar la misma.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadMadre.Focus()
                    Return False
                End If
            Case Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO
                If textboxEntidadTercero.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpagePadresYFacturacion
                    MsgBox("Si las facturas se emitirán a nombre de un Tercero, debe especificar el mismo.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadTercero.Focus()
                    Return False
                End If
            Case Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES
                If textboxEntidadPadre.Tag Is Nothing And textboxEntidadMadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpagePadresYFacturacion
                    MsgBox("Si las facturas se emitirán a nombre de ambos Padres, debe especificarlos.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadPadre.Focus()
                    Return False
                ElseIf textboxEntidadPadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpagePadresYFacturacion
                    MsgBox("Si las facturas se emitirán a nombre de ambos Padres, debe especificar el Padre.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadPadre.Focus()
                    Return False
                ElseIf textboxEntidadMadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpagePadresYFacturacion
                    MsgBox("Si las facturas se emitirán a nombre de ambos Padres, debe especificar la Madre.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadMadre.Focus()
                    Return False
                End If
            Case Constantes.ENTIDAD_EMITIRFACTURAA_TODOS
                If textboxEntidadPadre.Tag Is Nothing And textboxEntidadMadre.Tag Is Nothing And textboxEntidadTercero.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpagePadresYFacturacion
                    MsgBox("Si las facturas se emitirán a nombre de Todos (Padres y Tercero), debe especificarlos.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadPadre.Focus()
                    Return False
                ElseIf textboxEntidadPadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpagePadresYFacturacion
                    MsgBox("Si las facturas se emitirán a nombre de Todos (Padres y Tercero), debe especificar el Padre.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadPadre.Focus()
                    Return False
                ElseIf textboxEntidadMadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpagePadresYFacturacion
                    MsgBox("Si las facturas se emitirán a nombre de Todos (Padres y Tercero), debe especificar la Madre.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadMadre.Focus()
                    Return False
                ElseIf textboxEntidadTercero.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpagePadresYFacturacion
                    MsgBox("Si las facturas se emitirán a nombre de Todos (Padres y Tercero), debe especificar el Tercero.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadTercero.Focus()
                    Return False
                End If
        End Select

        ' Débito Directo
        If radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.Checked Then
            If checkboxTipoAlumno.Checked AndAlso CStr(comboboxEmitirFacturaA.SelectedValue) <> Constantes.ENTIDAD_EMITIRFACTURAA_ALUMNO Then
                tabcontrolMain.SelectedTab = tabpageDebitoAutomatico
                MsgBox("El CBU para realizar el Débito Directo, debe ser especificado en la(s) Entidad(es) a la(s) cual(es) se le factura.", MsgBoxStyle.Information, My.Application.Info.Title)
                maskedtextboxDebitoAutomaticoCBU.Focus()
                Return False
            End If
            If maskedtextboxDebitoAutomaticoCBU.Text = "" Then
                tabcontrolMain.SelectedTab = tabpageDebitoAutomatico
                MsgBox("Debe especificar el CBU en el cual realizar el Débito Directo.", MsgBoxStyle.Information, My.Application.Info.Title)
                maskedtextboxDebitoAutomaticoCBU.Focus()
                Return False
            End If
            If maskedtextboxDebitoAutomaticoCBU.Text.Length < 22 Then
                tabcontrolMain.SelectedTab = tabpageDebitoAutomatico
                MsgBox("Debe completar todos los dígitos del CBU en el cual realizar el Débito Directo.", MsgBoxStyle.Information, My.Application.Info.Title)
                maskedtextboxDebitoAutomaticoCBU.Focus()
                Return False
            End If
            Select Case CS_Bank.VerificarCBU(maskedtextboxDebitoAutomaticoCBU.Text)
                Case 0
                    tabcontrolMain.SelectedTab = tabpageDebitoAutomatico
                    MsgBox("El CBU ingresado es incorrecto.", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxDebitoAutomaticoCBU.Focus()
                    Return False
                Case 1
                    tabcontrolMain.SelectedTab = tabpageDebitoAutomatico
                    MsgBox("El CBU ingresado tiene un error en el 1er. bloque.", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxDebitoAutomaticoCBU.Focus()
                    Return False
                Case 2
                    tabcontrolMain.SelectedTab = tabpageDebitoAutomatico
                    MsgBox("El CBU ingresado tiene un error en el 2do. bloque.", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxDebitoAutomaticoCBU.Focus()
                    Return False
            End Select
        End If

        Return True
    End Function

#End Region

End Class