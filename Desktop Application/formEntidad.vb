Public Class formEntidad
    Friend FormDBContext As New CSColegioContext
    Friend EntidadCurrent As Entidad

    Friend Sub InitializeFormAndControls()
        ' Cargo los ComboBox
        FillAndRefreshLists.DocumentoTipo(comboboxDocumentoTipo, True)
        FillAndRefreshLists.Genero(comboboxGenero, True)
        FillAndRefreshLists.CategoriaIVA(comboboxCategoriaIVA, True)
        FillAndRefreshLists.Provincia(comboboxDomicilioProvincia, True)
        FillAndRefreshLists.EntidadFactura(comboboxEntidadFactura, True)
    End Sub

    Friend Sub SetDataFromObjectToControls()
        With EntidadCurrent
            ' Datos del Encabezado
            If EntidadCurrent.IDEntidad = 0 Then
                textboxIDEntidad.Text = My.Resources.STRING_ITEM_NEW_MALE
            Else
                textboxIDEntidad.Text = String.Format(.IDEntidad.ToString, "G")
            End If
            textboxApellido.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.Apellido)
            textboxNombre.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.Nombre)

            ' Datos de la pestaña General
            checkboxTipoPersonalColegio.CheckState = CSM_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoPersonalColegio)
            checkboxTipoDocente.CheckState = CSM_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoDocente)
            checkboxTipoAlumno.CheckState = CSM_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoAlumno)
            checkboxTipoFamiliar.CheckState = CSM_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoFamiliar)
            checkboxTipoProveedor.CheckState = CSM_ValueTranslation.FromObjectBooleanToControlCheckBox(.TipoProveedor)
            CSM_ComboBox.SetSelectedValue(comboboxDocumentoTipo, SelectedItemOptions.ValueOrFirst, .IDDocumentoTipo, 0)
            textboxDocumentoNumero.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.DocumentoNumero)
            CSM_ComboBox.SetSelectedValue(comboboxGenero, SelectedItemOptions.ValueOrFirst, .Genero, "-")
            datetimepickerFechaNacimiento.Value = CSM_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaNacimiento, datetimepickerFechaNacimiento)
            maskedtextboxCUIT_CUIL.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.CUIT_CUIL)
            CSM_ComboBox.SetSelectedValue(comboboxCategoriaIVA, SelectedItemOptions.ValueOrFirst, .IDCategoriaIVA, 0)

            ' Datos de la pestaña Contacto
            textboxTelefono1.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.Telefono1)
            textboxTelefono2.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.Telefono2)
            textboxTelefono3.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.Telefono3)
            textboxEmail1.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.Email1)
            textboxEmail2.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.Email2)
            textboxDomicilioCalle1.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCalle1)
            textboxDomicilioNumero.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioNumero)
            textboxDomicilioPiso.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioPiso)
            textboxDomicilioDepartamento.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioDepartamento)
            textboxDomicilioCalle2.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCalle2)
            textboxDomicilioCalle3.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCalle3)
            CSM_ComboBox.SetSelectedValue(comboboxDomicilioProvincia, SelectedItemOptions.Value, .DomicilioIDProvincia, "-")
            CSM_ComboBox.SetSelectedValue(comboboxDomicilioLocalidad, SelectedItemOptions.Value, .DomicilioIDLocalidad, 0)
            textboxDomicilioCodigoPostal.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.DomicilioCodigoPostal)

            ' Datos de la pestaña Extra
            If .EntidadPadre Is Nothing Then
                textboxEntidadPadre.Text = ""
                textboxEntidadPadre.Tag = Nothing
            Else
                textboxEntidadPadre.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.EntidadPadre.ApellidoNombre)
                textboxEntidadPadre.Tag = .EntidadPadre.IDEntidad
            End If
            If .EntidadMadre Is Nothing Then
                textboxEntidadMadre.Text = ""
                textboxEntidadMadre.Tag = Nothing
            Else
                textboxEntidadMadre.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.EntidadMadre.ApellidoNombre)
                textboxEntidadMadre.Tag = .EntidadMadre.IDEntidad
            End If
            CSM_ComboBox.SetSelectedValue(comboboxEntidadFactura, SelectedItemOptions.ValueOrFirst, .EntidadFactura, "-")
            checkboxActivo.CheckState = CSM_ValueTranslation.FromObjectBooleanToControlCheckBox(.EsActivo)
            textboxNotas.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.Notas)

            ' Datos de la pestaña Relaciones Hijas
            'Dim EntidadHija As Entidad
            'Dim datagridrowNew As DataGridViewRow
            'For Each EntidadEntidadCurrent In EntidadCurrent.EntidadesHijas
            '    datagridrowNew = New DataGridViewRow

            '    datagridviewRelacionesHijas.Rows.Add()
            'Next
            'Using dbcRelaciones As New CSColegioContext
            '    Dim qryRelacionesHijas = From ent In dbcRelaciones.Entidad
            '                             Join entxent In dbcRelaciones.EntidadEntidad On ent.IDEntidad Equals entxent.IDEntidadHija
            '                             Join reltip In dbcRelaciones.RelacionTipo On entxent.IDRelacionTipo Equals reltip.IDRelacionTipo
            '                             Where entxent.IDEntidadPadre = .IDEntidad
            '                             Select IDEntidad = ent.IDEntidad, Apellido = ent.Apellido, Nombre = ent.Nombre, RelacionTipoNombre = reltip.Nombre

            '    datagridviewRelacionesHijas.AutoGenerateColumns = False
            '    datagridviewRelacionesHijas.DataSource = qryRelacionesHijas.ToList
            'End Using

            ' Datos de la pestaña Relaciones Padres
            Using dbcRelaciones As New CSColegioContext
                Dim qryRelacionesPadres = From ent In dbcRelaciones.Entidad
                                         Join entxent In dbcRelaciones.EntidadEntidad On ent.IDEntidad Equals entxent.IDEntidadPadre
                                         Join reltip In dbcRelaciones.RelacionTipo On entxent.IDRelacionTipo Equals reltip.IDRelacionTipo
                                         Where entxent.IDEntidadHija = .IDEntidad
                                         Select IDEntidad = ent.IDEntidad, Apellido = ent.Apellido, Nombre = ent.Nombre, RelacionTipoNombre = reltip.Nombre

                datagridviewRelacionesPadres.AutoGenerateColumns = False
                datagridviewRelacionesPadres.DataSource = qryRelacionesPadres.ToList
            End Using

            ' Datos de la pestaña Cursos Asistidos
            Using dbcCursosAsistidos As New CSColegioContext
                Dim qryCursosAsistidos = From niv In dbcCursosAsistidos.Nivel
                                         Join ani In dbcCursosAsistidos.Anio On niv.IDNivel Equals ani.IDNivel
                                         Join curs In dbcCursosAsistidos.Curso On ani.IDAnio Equals curs.IDAnio
                                         Join turn In dbcCursosAsistidos.Turno On curs.IDTurno Equals turn.IDTurno
                                         Join entcur In dbcCursosAsistidos.EntidadCurso On curs.IDCurso Equals entcur.IDCurso
                                         Where entcur.IDEntidad = .IDEntidad
                                         Order By entcur.AnioLectivo Descending
                                         Select AnioLectivo = entcur.AnioLectivo, NivelNombre = niv.Nombre, AnioNombre = ani.Nombre, TurnoNombre = turn.Nombre, Division = curs.Division

                datagridviewCursosAsistidos.AutoGenerateColumns = False
                datagridviewCursosAsistidos.DataSource = qryCursosAsistidos.ToList
            End Using

            ' Datos de la pestaña Auditoría
            textboxFechaHoraCreacion.Text = .FechaHoraCreacion.ToShortDateString & " " & .FechaHoraCreacion.ToShortTimeString
            If .UsuarioCreacion Is Nothing Then
                textboxUsuarioCreacion.Text = ""
            Else
                textboxUsuarioCreacion.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.UsuarioCreacion.Descripcion)
            End If
            textboxFechaHoraModificacion.Text = .FechaHoraModificacion.ToShortDateString & " " & .FechaHoraModificacion.ToShortTimeString
            If .UsuarioModificacion Is Nothing Then
                textboxUsuarioModificacion.Text = ""
            Else
                textboxUsuarioModificacion.Text = CSM_ValueTranslation.FromObjectStringToControlTextBox(.UsuarioModificacion.Descripcion)
            End If
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With EntidadCurrent
            ' Datos del Encabezado
            .Apellido = textboxApellido.Text.Trim
            .Nombre = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxNombre.Text.Trim)

            'Datos de la pestaña General
            .TipoPersonalColegio = CSM_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoPersonalColegio.CheckState)
            .TipoDocente = CSM_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoDocente.CheckState)
            .TipoAlumno = CSM_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoAlumno.CheckState)
            .TipoFamiliar = CSM_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoFamiliar.CheckState)
            .TipoProveedor = CSM_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxTipoProveedor.CheckState)
            .IDDocumentoTipo = CSM_ValueTranslation.FromControlComboBoxToObjectByte(comboboxDocumentoTipo.SelectedValue, 0)
            .DocumentoNumero = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxDocumentoNumero.Text.Trim)
            .Genero = CSM_ValueTranslation.FromControlComboBoxToObjectString(comboboxGenero.SelectedValue, "-")
            .FechaNacimiento = CSM_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaNacimiento.Value, datetimepickerFechaNacimiento.Checked)
            .CUIT_CUIL = CSM_ValueTranslation.FromControlTextBoxToObjectString(maskedtextboxCUIT_CUIL.Text.Trim)
            .IDCategoriaIVA = CSM_ValueTranslation.FromControlComboBoxToObjectByte(comboboxCategoriaIVA.SelectedValue, 0)

            ' Datos de la pestaña Contacto
            .Telefono1 = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono1.Text)
            .Telefono2 = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono2.Text)
            .Telefono3 = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxTelefono3.Text)
            .Email1 = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxEmail1.Text)
            .Email2 = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxEmail2.Text)
            .DomicilioCalle1 = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCalle1.Text)
            .DomicilioNumero = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioNumero.Text)
            .DomicilioPiso = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioPiso.Text)
            .DomicilioDepartamento = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioDepartamento.Text)
            .DomicilioCalle2 = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCalle2.Text)
            .DomicilioCalle3 = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCalle3.Text)
            .DomicilioIDProvincia = CSM_ValueTranslation.FromControlComboBoxToObjectString(comboboxDomicilioProvincia.SelectedValue, "-")
            .DomicilioIDLocalidad = CSM_ValueTranslation.FromControlComboBoxToObjectShort(comboboxDomicilioLocalidad.SelectedValue, 0)
            .DomicilioCodigoPostal = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxDomicilioCodigoPostal.Text)

            ' Datos de la pestaña Extra
            .IDEntidadPadre = CSM_ValueTranslation.FromControlTagToObjectInteger(textboxEntidadPadre.Tag)
            .IDEntidadMadre = CSM_ValueTranslation.FromControlTagToObjectInteger(textboxEntidadMadre.Tag)
            .EntidadFactura = CSM_ValueTranslation.FromControlComboBoxToObjectString(comboboxEntidadFactura.SelectedValue, "-")
            .EsActivo = CSM_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxActivo.CheckState)
            .Notas = CSM_ValueTranslation.FromControlTextBoxToObjectString(textboxNotas.Text.Trim)
        End With
    End Sub

    Private Sub formEntidad_FormClosed() Handles Me.FormClosed
        FormDBContext.Dispose()
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxIDEntidad.GotFocus, textboxApellido.GotFocus, textboxNombre.GotFocus, textboxDocumentoNumero.GotFocus, maskedtextboxCUIT_CUIL.GotFocus, textboxTelefono1.GotFocus, textboxTelefono2.GotFocus, textboxTelefono3.GotFocus, textboxEmail1.GotFocus, textboxEmail2.GotFocus, textboxDomicilioCalle1.GotFocus, textboxDomicilioNumero.GotFocus, textboxDomicilioPiso.GotFocus, textboxDomicilioDepartamento.GotFocus, textboxDomicilioCodigoPostal.GotFocus, textboxNotas.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub comboboxDomicilioProvincia_SelectedValueChanged() Handles comboboxDomicilioProvincia.SelectedValueChanged
        If comboboxDomicilioProvincia.SelectedValue Is Nothing Then
            comboboxDomicilioLocalidad.DataSource = Nothing
        Else
            FillAndRefreshLists.Localidad(comboboxDomicilioLocalidad, comboboxDomicilioProvincia.SelectedValue.ToString, False)
            If comboboxDomicilioProvincia.SelectedValue.ToString = CSM_Parameter.GetString(PARAMETRO_PROVINCIA_PREDETERMINADA) Then
                CSM_ComboBox.SetSelectedValue(comboboxDomicilioLocalidad, SelectedItemOptions.ValueOrFirst, CSM_Parameter.GetIntegerAsShort(PARAMETRO_LOCALIDAD_PREDETERMINADA))
            End If
        End If
    End Sub

    Private Sub comboboxDomicilioLocalidad_SelectedValueChanged() Handles comboboxDomicilioLocalidad.SelectedValueChanged
        If Not comboboxDomicilioLocalidad.SelectedValue Is Nothing Then
            textboxDomicilioCodigoPostal.Text = CType(comboboxDomicilioLocalidad.SelectedItem, Localidad).CodigoPostal
        End If
    End Sub

    Private Sub buttonEditar_Click() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDAD_EDIT) Then
            buttonGuardar.Visible = True
            buttonCancelar.Visible = True
            buttonEditar.Visible = False
            buttonCerrar.Visible = False
            CSM_Form.ControlsChangeStateReadOnly(Me.Controls, False, True, textboxIDEntidad.Name, textboxEntidadPadre.Name, textboxEntidadMadre.Name, textboxFechaHoraCreacion.Name, textboxUsuarioCreacion.Name, textboxFechaHoraModificacion.Name, textboxUsuarioModificacion.Name)
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
        If comboboxDocumentoTipo.SelectedIndex > 0 And textboxDocumentoNumero.Text.Length = 0 Then
            tabcontrolMain.SelectedTab = tabpageGeneral
            MsgBox("Si especifica el Tipo de Documento, también debe especificar el Número de Documento.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxDocumentoNumero.Focus()
            Exit Sub
        End If
        If datetimepickerFechaNacimiento.Checked And datetimepickerFechaNacimiento.Value.Year = Today.Year Then
            tabcontrolMain.SelectedTab = tabpageGeneral
            MsgBox("Se ha especificado una Fecha de Nacimiento que no parece ser válida ya que es del año actual.", MsgBoxStyle.Information, My.Application.Info.Title)
            datetimepickerFechaNacimiento.Focus()
            Exit Sub
        End If
        If maskedtextboxCUIT_CUIL.Text.Trim.Length > 0 Then
            If maskedtextboxCUIT_CUIL.Text.Trim.Length < 11 Then
                tabcontrolMain.SelectedTab = tabpageGeneral
                MsgBox("El número de CUIT / CUIL debe contener 11 dígitos (sin guiones).", MsgBoxStyle.Information, My.Application.Info.Title)
                maskedtextboxCUIT_CUIL.Focus()
                Exit Sub
            End If
            If Not CSM_AFIP.VerificarCUIT(maskedtextboxCUIT_CUIL.Text) Then
                tabcontrolMain.SelectedTab = tabpageGeneral
                MsgBox("El CUIT / CUIL ingresado es incorrecto.", MsgBoxStyle.Information, My.Application.Info.Title)
                maskedtextboxCUIT_CUIL.Focus()
                Exit Sub
            End If
        End If
        Select Case CStr(comboboxEntidadFactura.SelectedValue)
            Case "P"
                If textboxEntidadPadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpageExtra
                    MsgBox("Si las facturas se emitirán a nombre del Padre / Tutor, debe especificar el mismo.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadPadre.Focus()
                    Exit Sub
                End If
            Case "M"
                If textboxEntidadPadre.Tag Is Nothing Then
                    tabcontrolMain.SelectedTab = tabpageExtra
                    MsgBox("Si las facturas se emitirán a nombre de la Madre / Tutora, debe especificar la misma.", MsgBoxStyle.Information, My.Application.Info.Title)
                    textboxEntidadMadre.Focus()
                    Exit Sub
                End If
        End Select

        ' Generar el ID de la Entidad nueva
        If EntidadCurrent.IDEntidad = 0 Then
            Using dbcMaxID As New CSColegioContext
                If dbcMaxID.Entidad.Count = 0 Then
                    EntidadCurrent.IDEntidad = 1
                Else
                    EntidadCurrent.IDEntidad = dbcMaxID.Entidad.Max(Function(ent) ent.IDEntidad) + 1
                End If
            End Using
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        If FormDBContext.ChangeTracker.HasChanges Then

            Me.Cursor = Cursors.WaitCursor

            EntidadCurrent.IDUsuarioModificacion = pUsuario.IDUsuario
            EntidadCurrent.FechaHoraModificacion = Now

            Try

                ' Guardo los cambios
                FormDBContext.SaveChanges()

                ' Refresco la lista de Entidades para mostrar los cambios
                If CSM_Form.MDIChild_IsLoaded(CType(formMDIMain, Form), "formEntidades") Then
                    Dim formEntidades As formEntidades = CType(CSM_Form.MDIChild_GetInstance(CType(formMDIMain, Form), "formEntidades"), formEntidades)
                    formEntidades.RefreshData(EntidadCurrent.IDEntidad)
                    formEntidades = Nothing
                End If

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                CSM_Error.ProcessError(ex, "Error al intentar guardar los cambios a la Base de Datos.")
                Exit Sub
            End Try
        End If

        Me.Close()
    End Sub

    Private Sub buttonCancelar_Click() Handles buttonCancelar.Click
        If FormDBContext.ChangeTracker.HasChanges Then
            If MsgBox("Ha realizado cambios en los datos y seleccionó cancelar, los cambios se perderán." & vbCr & vbCr & "¿Confirma la pérdida de los cambios?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub buttonEntidadPadre_Click(sender As Object, e As EventArgs) Handles buttonEntidadPadre.Click
        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            textboxEntidadPadre.Text = CStr(formEntidadesSeleccionar.datagridviewMain.SelectedRows.Item(0).Cells(formEntidadesSeleccionar.COLUMNA_APELLIDO).Value()) & CStr(IIf(formEntidadesSeleccionar.datagridviewMain.SelectedRows.Item(0).Cells(formEntidadesSeleccionar.COLUMNA_NOMBRE).Value Is Nothing, "", ", " & CStr(formEntidadesSeleccionar.datagridviewMain.SelectedRows.Item(0).Cells(formEntidadesSeleccionar.COLUMNA_NOMBRE).Value)))
            textboxEntidadPadre.Tag = CInt(formEntidadesSeleccionar.datagridviewMain.SelectedRows.Item(0).Cells(formEntidadesSeleccionar.COLUMNA_IDENTIDAD).Value())
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
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            textboxEntidadMadre.Text = CStr(formEntidadesSeleccionar.datagridviewMain.SelectedRows.Item(0).Cells(formEntidadesSeleccionar.COLUMNA_APELLIDO).Value()) & CStr(IIf(formEntidadesSeleccionar.datagridviewMain.SelectedRows.Item(0).Cells(formEntidadesSeleccionar.COLUMNA_NOMBRE).Value Is Nothing, "", ", " & CStr(formEntidadesSeleccionar.datagridviewMain.SelectedRows.Item(0).Cells(formEntidadesSeleccionar.COLUMNA_NOMBRE).Value)))
            textboxEntidadMadre.Tag = CInt(formEntidadesSeleccionar.datagridviewMain.SelectedRows.Item(0).Cells(formEntidadesSeleccionar.COLUMNA_IDENTIDAD).Value())
        End If
        formEntidadesSeleccionar.Dispose()
    End Sub

    Private Sub buttonEntidadMadreBorrar_Click(sender As Object, e As EventArgs) Handles buttonEntidadMadreBorrar.Click
        textboxEntidadMadre.Text = ""
        textboxEntidadMadre.Tag = Nothing
    End Sub
End Class