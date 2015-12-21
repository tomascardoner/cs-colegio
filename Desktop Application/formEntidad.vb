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
                .IDCategoriaIVA = CS_Parameter.GetIntegerAsByte(Parametros.DEFAULT_CATEGORIAIVA_ID)
                .DomicilioIDProvincia = CS_Parameter.GetIntegerAsByte(Parametros.DEFAULT_PROVINCIA_ID)
                .DomicilioIDLocalidad = CS_Parameter.GetIntegerAsShort(Parametros.DEFAULT_LOCALIDAD_ID)
                .DomicilioCodigoPostal = CS_Parameter.GetString(Parametros.DEFAULT_CODIGOPOSTAL)
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

        Me.MdiParent = formMDIMain
        CS_Form.CenterToParent(ParentForm, Me)
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

        checkboxEsActivo.Enabled = mEditMode
        textboxApellido.ReadOnly = (mEditMode = False)
        textboxNombre.ReadOnly = (mEditMode = False)

        ' General
        checkboxTipoPersonalColegio.Enabled = mEditMode
        checkboxTipoDocente.Enabled = mEditMode
        checkboxTipoAlumno.Enabled = mEditMode
        checkboxTipoFamiliar.Enabled = mEditMode
        checkboxTipoProveedor.Enabled = mEditMode
        comboboxDocumentoTipo.Enabled = mEditMode
        textboxDocumentoNumero.ReadOnly = (mEditMode = False)
        maskedtextboxDocumentoNumero.ReadOnly = (mEditMode = False)
        comboboxFacturaDocumentoTipo.Enabled = mEditMode
        textboxFacturaDocumentoNumero.ReadOnly = (mEditMode = False)
        maskedtextboxFacturaDocumentoNumero.ReadOnly = (mEditMode = False)
        comboboxGenero.Enabled = mEditMode
        datetimepickerFechaNacimiento.Enabled = mEditMode
        comboboxCategoriaIVA.Enabled = mEditMode

        ' Contacto
        textboxTelefono1.ReadOnly = (mEditMode = False)
        textboxTelefono2.ReadOnly = (mEditMode = False)
        textboxTelefono3.ReadOnly = (mEditMode = False)
        textboxEmail1.ReadOnly = (mEditMode = False)
        textboxEmail2.ReadOnly = (mEditMode = False)
        comboboxComprobanteEnviarEmail.Enabled = mEditMode
        textboxDomicilioCalle1.ReadOnly = (mEditMode = False)
        textboxDomicilioNumero.ReadOnly = (mEditMode = False)
        textboxDomicilioPiso.ReadOnly = (mEditMode = False)
        textboxDomicilioDepartamento.ReadOnly = (mEditMode = False)
        textboxDomicilioCalle2.ReadOnly = (mEditMode = False)
        textboxDomicilioCalle3.ReadOnly = (mEditMode = False)
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

        ' Notas y Auditoría
        textboxNotas.ReadOnly = (mEditMode = False)
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
        datagridviewCursosAsistidos.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewCursosAsistidos.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont

        datagridviewHijos.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewHijos.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont

        datagridviewComprobantes.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewComprobantes.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont

        datagridviewRelaciones.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewRelaciones.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont
    End Sub

    Private Sub formEntidad_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
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
            checkboxEsActivo.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.EsActivo)
            textboxApellido.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Apellido)
            textboxNombre.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Nombre)

            ' Datos de la pestaña General
            checkboxTipoPersonalColegio.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoPersonalColegio)
            checkboxTipoDocente.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoDocente)
            checkboxTipoAlumno.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoAlumno)
            checkboxTipoFamiliar.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoFamiliar)
            checkboxTipoProveedor.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoProveedor)
            CS_Control_ComboBox.SetSelectedValue(comboboxDocumentoTipo, SelectedItemOptions.ValueOrFirst, .IDDocumentoTipo, CByte(0))
            If CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                maskedtextboxDocumentoNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DocumentoNumero)
            Else
                textboxDocumentoNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DocumentoNumero)
            End If
            CS_Control_ComboBox.SetSelectedValue(comboboxFacturaDocumentoTipo, SelectedItemOptions.ValueOrFirst, .FacturaIDDocumentoTipo, CByte(0))
            If CType(comboboxFacturaDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                maskedtextboxFacturaDocumentoNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.FacturaDocumentoNumero)
            Else
                textboxFacturaDocumentoNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.FacturaDocumentoNumero)
            End If
            CS_Control_ComboBox.SetSelectedValue(comboboxGenero, SelectedItemOptions.ValueOrFirst, .Genero, Constantes.ENTIDAD_GENERO_NOESPECIFICA)
            datetimepickerFechaNacimiento.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaNacimiento, datetimepickerFechaNacimiento)
            CS_Control_ComboBox.SetSelectedValue(comboboxCategoriaIVA, SelectedItemOptions.ValueOrFirst, .IDCategoriaIVA, 0)

            ' Datos de la pestaña Contacto
            textboxTelefono1.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Telefono1)
            textboxTelefono2.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Telefono2)
            textboxTelefono3.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Telefono3)
            textboxEmail1.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Email1)
            textboxEmail2.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Email2)
            CS_Control_ComboBox.SetSelectedValue(comboboxComprobanteEnviarEmail, SelectedItemOptions.ValueOrFirst, .ComprobanteEnviarEmail, Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_CUALQUIERA)
            textboxDomicilioCalle1.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCalle1)
            textboxDomicilioNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioNumero)
            textboxDomicilioPiso.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioPiso)
            textboxDomicilioDepartamento.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioDepartamento)
            textboxDomicilioCalle2.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCalle2)
            textboxDomicilioCalle3.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCalle3)
            CS_Control_ComboBox.SetSelectedValue(comboboxDomicilioProvincia, SelectedItemOptions.Value, .DomicilioIDProvincia, Constantes.PROVINCIA_NOESPECIFICA)
            CS_Control_ComboBox.SetSelectedValue(comboboxDomicilioLocalidad, SelectedItemOptions.Value, .DomicilioIDLocalidad, 0)
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
            CS_Control_ComboBox.SetSelectedValue(comboboxEmitirFacturaA, SelectedItemOptions.ValueOrFirst, .EmitirFacturaA, Constantes.ENTIDAD_EMITIRFACTURAA_NOESPECIFICA)
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
            CS_Control_ComboBox.SetSelectedValue(comboboxDescuento, SelectedItemOptions.ValueOrFirst, .IDDescuento, 0)
            checkboxFacturaIndividual.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.FacturaIndividual)
            checkboxExcluyeCalculoInteres.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.ExcluyeCalculoInteres)
            datetimepickerExcluyeFacturaDesde.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.ExcluyeFacturaDesde, datetimepickerExcluyeFacturaDesde)
            datetimepickerExcluyeFacturaHasta.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.ExcluyeFacturaHasta, datetimepickerExcluyeFacturaHasta)
            textboxFacturaLeyenda.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.FacturaLeyenda)

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
            .EsActivo = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxEsActivo.CheckState)
            .Apellido = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxApellido.Text)
            .Nombre = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNombre.Text)

            'Datos de la pestaña General
            .TipoPersonalColegio = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoPersonalColegio.CheckState)
            .TipoDocente = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoDocente.CheckState)
            .TipoAlumno = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoAlumno.CheckState)
            .TipoFamiliar = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoFamiliar.CheckState)
            .TipoProveedor = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoProveedor.CheckState)
            .IDDocumentoTipo = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxDocumentoTipo.SelectedValue, 0)
            If CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                .DocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(maskedtextboxDocumentoNumero.Text)
            Else
                .DocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxDocumentoNumero.Text)
            End If
            .FacturaIDDocumentoTipo = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxFacturaDocumentoTipo.SelectedValue, 0)
            If CType(comboboxFacturaDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                .FacturaDocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(maskedtextboxFacturaDocumentoNumero.Text)
            Else
                .FacturaDocumentoNumero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxFacturaDocumentoNumero.Text)
            End If
            .Genero = CS_ValueTranslation.FromControlComboBoxToObjectString(comboboxGenero.SelectedValue, Constantes.ENTIDAD_GENERO_NOESPECIFICA)
            .FechaNacimiento = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaNacimiento.Value, datetimepickerFechaNacimiento.Checked)
            .IDCategoriaIVA = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxCategoriaIVA.SelectedValue, 0)

            ' Datos de la pestaña Contacto
            .Telefono1 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono1.Text)
            .Telefono2 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono2.Text)
            .Telefono3 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono3.Text)
            .Email1 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxEmail1.Text)
            .Email2 = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxEmail2.Text)
            .ComprobanteEnviarEmail = CS_ValueTranslation.FromControlComboBoxToObjectString(comboboxComprobanteEnviarEmail.SelectedValue)
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
            .EmitirFacturaA = CS_ValueTranslation.FromControlComboBoxToObjectString(comboboxEmitirFacturaA.SelectedValue, Constantes.ENTIDAD_EMITIRFACTURAA_NOESPECIFICA)
            If .EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or .EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                .IDEntidadTercero = CS_ValueTranslation.FromControlTagToObjectInteger(textboxEntidadTercero.Tag)
            Else
                .IDEntidadTercero = Nothing
            End If
            .IDDescuento = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxDescuento.SelectedValue, 0)
            .FacturaIndividual = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxFacturaIndividual.CheckState)
            .ExcluyeCalculoInteres = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxExcluyeCalculoInteres.CheckState)
            .ExcluyeFacturaDesde = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerExcluyeFacturaDesde.Value, datetimepickerExcluyeFacturaDesde.Checked)
            .ExcluyeFacturaHasta = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerExcluyeFacturaHasta.Value, datetimepickerExcluyeFacturaHasta.Checked)
            .FacturaLeyenda = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxFacturaLeyenda.Text)

            ' Datos de la pestaña Notas y Aditoría
            .Notas = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNotas.Text)
        End With
    End Sub

    Friend Sub RefreshData_CursosAsistidos()
        Dim listCursosAsistidos As New List(Of Object)
        For Each AnioLectivoCursoCurrent As AnioLectivoCurso In mEntidadActual.AniosLectivosCursos.OrderByDescending(Function(alc) alc.AnioLectivo).ToList
            listCursosAsistidos.Add(New With {.AnioLectivo = AnioLectivoCursoCurrent.AnioLectivo, .NivelNombre = AnioLectivoCursoCurrent.Curso.Anio.Nivel.Nombre, .AnioNombre = AnioLectivoCursoCurrent.Curso.Anio.Nombre, .TurnoNombre = AnioLectivoCursoCurrent.Curso.Turno.Nombre, .Division = AnioLectivoCursoCurrent.Curso.Division})
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
                                Select New GridRowData_Comprobante With {.IDComprobante = c.IDComprobante, .TipoNombre = c.ComprobanteTipo.NombreConLetra, .NumeroCompleto = c.NumeroCompleto, .FechaEmision = c.FechaEmision, .ImporteTotal = c.ImporteTotal}).ToList
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
    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxIDEntidad.GotFocus, textboxApellido.GotFocus, textboxNombre.GotFocus, textboxDocumentoNumero.GotFocus, textboxTelefono1.GotFocus, textboxTelefono2.GotFocus, textboxTelefono3.GotFocus, textboxEmail1.GotFocus, textboxEmail2.GotFocus, textboxDomicilioCalle1.GotFocus, textboxDomicilioNumero.GotFocus, textboxDomicilioPiso.GotFocus, textboxDomicilioDepartamento.GotFocus, textboxDomicilioCodigoPostal.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub MaskedTextBoxs_GotFocus(sender As Object, e As EventArgs) Handles maskedtextboxDocumentoNumero.GotFocus
        CType(sender, MaskedTextBox).SelectAll()
    End Sub

    Private Sub comboboxDocumentoTipo_SelectedIndexChanged() Handles comboboxDocumentoTipo.SelectedIndexChanged
        If Not comboboxDocumentoTipo.SelectedItem Is Nothing Then
            textboxDocumentoNumero.Visible = (CByte(comboboxDocumentoTipo.SelectedValue) > 0 AndAlso Not CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11)
            maskedtextboxDocumentoNumero.Visible = (CByte(comboboxDocumentoTipo.SelectedValue) > 0 AndAlso Not textboxDocumentoNumero.Visible)
        End If
    End Sub

    Private Sub comboboxFacturaDocumentoTipo_SelectedIndexChanged() Handles comboboxFacturaDocumentoTipo.SelectedIndexChanged
        If Not comboboxFacturaDocumentoTipo.SelectedItem Is Nothing Then
            textboxFacturaDocumentoNumero.Visible = (CByte(comboboxFacturaDocumentoTipo.SelectedValue) > 0 AndAlso Not CType(comboboxFacturaDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11)
            maskedtextboxFacturaDocumentoNumero.Visible = (CByte(comboboxFacturaDocumentoTipo.SelectedValue) > 0 AndAlso Not textboxFacturaDocumentoNumero.Visible)
        End If
    End Sub

    Private Sub DocumentoNumero_LimpiarCaracteres(sender As Object, e As EventArgs) Handles textboxDocumentoNumero.LostFocus, textboxFacturaDocumentoNumero.LostFocus
        CType(sender, TextBox).Text = CType(sender, TextBox).Text.Replace(".", "")
    End Sub

    Private Sub comboboxDomicilioProvincia_SelectedValueChanged() Handles comboboxDomicilioProvincia.SelectedValueChanged
        If comboboxDomicilioProvincia.SelectedValue Is Nothing Then
            comboboxDomicilioLocalidad.DataSource = Nothing
        Else
            pFillAndRefreshLists.Localidad(comboboxDomicilioLocalidad, CByte(comboboxDomicilioProvincia.SelectedValue), False)
            If CByte(comboboxDomicilioProvincia.SelectedValue) = CS_Parameter.GetIntegerAsByte(Parametros.DEFAULT_PROVINCIA_ID) Then
                CS_Control_ComboBox.SetSelectedValue(comboboxDomicilioLocalidad, SelectedItemOptions.ValueOrFirst, CS_Parameter.GetIntegerAsShort(Parametros.DEFAULT_LOCALIDAD_ID))
            End If
        End If
    End Sub

    Private Sub comboboxDomicilioLocalidad_SelectedValueChanged() Handles comboboxDomicilioLocalidad.SelectedValueChanged
        If Not comboboxDomicilioLocalidad.SelectedValue Is Nothing Then
            textboxDomicilioCodigoPostal.Text = CType(comboboxDomicilioLocalidad.SelectedItem, Localidad).CodigoPostal
        End If
    End Sub

    Private Sub buttonEntidadPadre_Click(sender As Object, e As EventArgs) Handles buttonEntidadPadre.Click
        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = True
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim EntidadSeleccionada As Entidad
            EntidadSeleccionada = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
            textboxEntidadPadre.Text = EntidadSeleccionada.ApellidoNombre
            textboxEntidadPadre.Tag = EntidadSeleccionada.IDEntidad
        End If
        formEntidadesSeleccionar.Dispose()
    End Sub

    Private Sub buttonEntidadPadreBorrar_Click(sender As Object, e As EventArgs) Handles buttonEntidadPadreBorrar.Click
        textboxEntidadPadre.Text = ""
        textboxEntidadPadre.Tag = Nothing
    End Sub

    Private Sub buttonEntidadMadre_Click(sender As Object, e As EventArgs) Handles buttonEntidadMadre.Click
        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = True
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim EntidadSeleccionada As Entidad
            EntidadSeleccionada = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
            textboxEntidadMadre.Text = EntidadSeleccionada.ApellidoNombre
            textboxEntidadMadre.Tag = EntidadSeleccionada.IDEntidad
        End If
        formEntidadesSeleccionar.Dispose()
    End Sub

    Private Sub buttonEntidadMadreBorrar_Click(sender As Object, e As EventArgs) Handles buttonEntidadMadreBorrar.Click
        textboxEntidadMadre.Text = ""
        textboxEntidadMadre.Tag = Nothing
    End Sub

    Private Sub comboboxEmitirFacturaA_SelectedIndexChanged() Handles comboboxEmitirFacturaA.SelectedIndexChanged
        If comboboxEmitirFacturaA.SelectedIndex > -1 Then
            labelEntidadTercero.Visible = (comboboxEmitirFacturaA.SelectedValue.ToString = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or comboboxEmitirFacturaA.SelectedValue.ToString = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS)
            panelEntidadTercero.Visible = (comboboxEmitirFacturaA.SelectedValue.ToString = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or comboboxEmitirFacturaA.SelectedValue.ToString = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS)
        End If
    End Sub

    Private Sub buttonEntidadTercero_Click(sender As Object, e As EventArgs) Handles buttonEntidadTercero.Click
        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = True
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim EntidadSeleccionada As Entidad
            EntidadSeleccionada = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
            textboxEntidadTercero.Text = EntidadSeleccionada.ApellidoNombre
            textboxEntidadTercero.Tag = EntidadSeleccionada.IDEntidad
        End If
        formEntidadesSeleccionar.Dispose()
    End Sub

    Private Sub buttonEntidadTerceroBorrar_Click(sender As Object, e As EventArgs) Handles buttonEntidadTerceroBorrar.Click
        textboxEntidadTercero.Text = ""
        textboxEntidadTercero.Tag = Nothing
    End Sub

#End Region

#Region "Main Toolbar"
    Private Sub buttonEditar_Click() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDAD_EDITAR) Then
            mEditMode = True
            ChangeMode()
        End If
    End Sub

    Private Sub buttonCerrar_Click() Handles buttonCerrar.Click
        Me.Close()
    End Sub

    Private Sub buttonGuardar_Click() Handles buttonGuardar.Click
        ' Verificar que estén todos los campos con datos coherentes
        If textboxApellido.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar el Apellido.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxApellido.Focus()
            Exit Sub
        End If
        If checkboxTipoPersonalColegio.Checked = False And checkboxTipoDocente.Checked = False And checkboxTipoAlumno.Checked = False And checkboxTipoFamiliar.Checked = False And checkboxTipoPersonalColegio.Checked = False Then
            tabcontrolMain.SelectedTab = tabpageGeneral
            MsgBox("Debe especificar el Tipo de Entidad.", MsgBoxStyle.Information, My.Application.Info.Title)
            Exit Sub
        End If

        ' Verifico el Número de Documento
        If comboboxDocumentoTipo.SelectedIndex > 0 AndAlso textboxDocumentoNumero.Text.Length = 0 Then
            If CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).VerificaModulo11 Then
                If maskedtextboxDocumentoNumero.Text.Length = 0 Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("Si especifica el Tipo de Documento, también debe especificar el Número de Documento.", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxDocumentoNumero.Focus()
                    Exit Sub
                End If
                If maskedtextboxDocumentoNumero.Text.Trim.Length < 11 Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("El Número de " & CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).Nombre & " debe contener 11 dígitos (sin contar los guiones).", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxDocumentoNumero.Focus()
                    Exit Sub
                End If
                If Not CS_AFIP.VerificarCUIT(maskedtextboxDocumentoNumero.Text) Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("El Número de " & CType(comboboxDocumentoTipo.SelectedItem, DocumentoTipo).Nombre & " ingresado es incorrecto.", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxDocumentoNumero.Focus()
                    Exit Sub
                End If
            Else
                If textboxDocumentoNumero.Text.Length = 0 Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("Si especifica el Tipo de Documento, también debe especificar el Número de Documento.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxDocumentoNumero.Focus()
                    Exit Sub
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
                    Exit Sub
                End If
                If maskedtextboxFacturaDocumentoNumero.Text.Trim.Length < 11 Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("El Número de " & CType(comboboxFacturaDocumentoTipo.SelectedItem, DocumentoTipo).Nombre & " debe contener 11 dígitos (sin contar los guiones).", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxFacturaDocumentoNumero.Focus()
                    Exit Sub
                End If
                If Not CS_AFIP.VerificarCUIT(maskedtextboxFacturaDocumentoNumero.Text) Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("El Número de " & CType(comboboxFacturaDocumentoTipo.SelectedItem, DocumentoTipo).Nombre & " ingresado es incorrecto.", MsgBoxStyle.Information, My.Application.Info.Title)
                    maskedtextboxFacturaDocumentoNumero.Focus()
                    Exit Sub
                End If
            Else
                If textboxFacturaDocumentoNumero.Text.Length = 0 Then
                    tabcontrolMain.SelectedTab = tabpageGeneral
                    MsgBox("Si especifica el Tipo de Documento, también debe especificar el Número de Documento para Facturar.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxFacturaDocumentoNumero.Focus()
                    Exit Sub
                End If
            End If
        End If

        ' Fecha de Nacimiento
        If datetimepickerFechaNacimiento.Checked And datetimepickerFechaNacimiento.Value.Year = Today.Year Then
            tabcontrolMain.SelectedTab = tabpageGeneral
            MsgBox("Se ha especificado una Fecha de Nacimiento que no parece ser válida ya que es del año actual.", MsgBoxStyle.Information, My.Application.Info.Title)
            datetimepickerFechaNacimiento.Focus()
            Exit Sub
        End If

        ' Direcciones de Email
        If textboxEmail1.Text.Trim.Length > 0 Then
            If Not CS_Email.IsValidEmail(textboxEmail1.Text.Trim, CS_Parameter.GetString(Parametros.EMAIL_VALIDATION_REGULAREXPRESSION)) Then
                tabcontrolMain.SelectedTab = tabpageContacto
                MsgBox("La dirección de E-mail 1 es incorrecta.", vbInformation, My.Application.Info.Title)
                textboxEmail1.Focus()
                Exit Sub
            End If
        End If
        If textboxEmail2.Text.Trim.Length > 0 Then
            If Not CS_Email.IsValidEmail(textboxEmail2.Text.Trim, CS_Parameter.GetString(Parametros.EMAIL_VALIDATION_REGULAREXPRESSION)) Then
                tabcontrolMain.SelectedTab = tabpageContacto
                MsgBox("La dirección de E-mail 2 es incorrecta.", vbInformation, My.Application.Info.Title)
                textboxEmail2.Focus()
                Exit Sub
            End If
        End If

        ' Emitir Factura A:
        Select Case CStr(comboboxEmitirFacturaA.SelectedValue)
            Case Constantes.ENTIDAD_EMITIRFACTURAA_NOESPECIFICA
                If checkboxTipoAlumno.Checked AndAlso ((Not textboxEntidadPadre.Tag Is Nothing) And (Not textboxEntidadMadre.Tag Is Nothing)) Then
                    If MsgBox("Ha especificado el Padre y/o la Madre del Alumno, pero no especificó a quien se le facturará." & vbCrLf & vbCrLf & "¿Desea hacerlo ahora?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                        tabcontrolMain.SelectedTab = tabpageExtra
                        comboboxEmitirFacturaA.Focus()
                        Exit Sub
                    End If
                End If
            Case Constantes.ENTIDAD_EMITIRFACTURAA_PADRE
                If textboxEntidadPadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpageExtra
                    MsgBox("Si las facturas se emitirán a nombre del Padre / Tutor, debe especificar el mismo.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadPadre.Focus()
                    Exit Sub
                End If
            Case Constantes.ENTIDAD_EMITIRFACTURAA_MADRE
                If textboxEntidadMadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpageExtra
                    MsgBox("Si las facturas se emitirán a nombre de la Madre / Tutora, debe especificar la misma.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadMadre.Focus()
                    Exit Sub
                End If
            Case Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO
                If textboxEntidadTercero.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpageExtra
                    MsgBox("Si las facturas se emitirán a nombre de un Tercero, debe especificar el mismo.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadTercero.Focus()
                    Exit Sub
                End If
            Case Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES
                If textboxEntidadPadre.Tag Is Nothing And textboxEntidadMadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpageExtra
                    MsgBox("Si las facturas se emitirán a nombre de ambos Padres, debe especificarlos.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadPadre.Focus()
                    Exit Sub
                ElseIf textboxEntidadPadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpageExtra
                    MsgBox("Si las facturas se emitirán a nombre de ambos Padres, debe especificar el Padre.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadPadre.Focus()
                    Exit Sub
                ElseIf textboxEntidadMadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpageExtra
                    MsgBox("Si las facturas se emitirán a nombre de ambos Padres, debe especificar la Madre.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadMadre.Focus()
                    Exit Sub
                End If
            Case Constantes.ENTIDAD_EMITIRFACTURAA_TODOS
                If textboxEntidadPadre.Tag Is Nothing And textboxEntidadMadre.Tag Is Nothing And textboxEntidadTercero.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpageExtra
                    MsgBox("Si las facturas se emitirán a nombre de Todos (Padres y Tercero), debe especificarlos.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadPadre.Focus()
                    Exit Sub
                ElseIf textboxEntidadPadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpageExtra
                    MsgBox("Si las facturas se emitirán a nombre de Todos (Padres y Tercero), debe especificar el Padre.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadPadre.Focus()
                    Exit Sub
                ElseIf textboxEntidadMadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpageExtra
                    MsgBox("Si las facturas se emitirán a nombre de Todos (Padres y Tercero), debe especificar la Madre.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadMadre.Focus()
                    Exit Sub
                ElseIf textboxEntidadTercero.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpageExtra
                    MsgBox("Si las facturas se emitirán a nombre de Todos (Padres y Tercero), debe especificar el Tercero.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadTercero.Focus()
                    Exit Sub
                End If
        End Select

        ' Generar el ID de la Entidad nueva
        If mEntidadActual.IDEntidad = 0 Then
            Using dbcMaxID As New CSColegioContext(True)
                If dbcMaxID.Entidad.Count = 0 Then
                    mEntidadActual.IDEntidad = 1
                Else
                    mEntidadActual.IDEntidad = dbcMaxID.Entidad.Max(Function(ent) ent.IDEntidad) + 1
                End If
            End Using
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
                If CS_Form.MDIChild_IsLoaded(CType(formMDIMain, Form), "formEntidades") Then
                    Dim formEntidades As formEntidades = CType(CS_Form.MDIChild_GetInstance(CType(formMDIMain, Form), "formEntidades"), formEntidades)
                    formEntidades.RefreshData(mEntidadActual.IDEntidad)
                    formEntidades = Nothing
                End If

            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Me.Cursor = Cursors.Default
                Select Case CS_Database_EF_SQL.TryDecodeDbUpdateException(dbuex)
                    Case Errors.DuplicatedEntity
                        MsgBox("No se pueden guardar los cambios porque ya existe una Entidad con el mismo Apellido y Nombre.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                End Select
                Exit Sub

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                CS_Error.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
                Exit Sub
            End Try
        End If

        Me.Close()
    End Sub

    Private Sub buttonCancelar_Click() Handles buttonCancelar.Click
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

            formComprobante.LoadAndShow(False, Me, CType(datagridviewComprobantes.SelectedRows(0).DataBoundItem, GridRowData_Comprobante).IDComprobante)

            datagridviewComprobantes.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub comboboxEmitirFacturaA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboboxEmitirFacturaA.SelectedIndexChanged

    End Sub
#End Region

End Class