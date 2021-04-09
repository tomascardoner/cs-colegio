Public Class formComprobanteDetalle

#Region "Declarations"

    Private mdbContext As New CSColegioContext(True)

    Private mIDArticuloMatricula As Short
    Private mIDArticuloMensual As Short
    Private mComprobanteActual As Comprobante
    Private mComprobanteDetalleActual As ComprobanteDetalle
    Private mArticuloActual As Articulo
    Private mEntidad As Entidad
    Private mDescuentoRedondeo As Short

    Private mParentEditMode As Boolean = False
    Private mEditMode As Boolean = False

    Private mCambiandoDescuento As Boolean = False

    Private mLoading As Boolean
    Private mIsNew As Boolean

#End Region

#Region "Form stuff"

    Friend Sub LoadAndShow(ByVal ParentEditMode As Boolean, ByVal EditMode As Boolean, ByRef ParentForm As Form, ByRef ComprobanteActual As Comprobante, ByRef ComprobanteDetalleActual As ComprobanteDetalle)
        mParentEditMode = ParentEditMode
        mEditMode = EditMode

        mComprobanteActual = ComprobanteActual
        mComprobanteDetalleActual = ComprobanteDetalleActual
        mIsNew = (mComprobanteDetalleActual.Indice = 0)

        CS_Form.CenterToParent(ParentForm, Me)
        InitializeFormAndControls()
        If mIsNew Then
            CargarAlumnos(mComprobanteActual.IDEntidad, Nothing)
        Else
            SetDataFromObjectToControls()
        End If
        ChangeMode()

        Me.ShowDialog(ParentForm)
    End Sub

    Private Sub ChangeMode()
        buttonGuardar.Visible = mEditMode
        buttonCancelar.Visible = mEditMode
        buttonEditar.Visible = (mParentEditMode And Not mEditMode)
        buttonCerrar.Visible = Not mEditMode

        comboboxArticulo.Enabled = mEditMode
        doubletextboxCantidad.ReadOnly = (mEditMode = False)
        textboxUnidad.ReadOnly = (mEditMode = False)
        comboboxAlumno.Enabled = mEditMode
        buttonAlumno.Enabled = mEditMode
        comboboxAnioLectivoCurso.Enabled = mEditMode
        comboboxCuotaMes.Enabled = mEditMode
        currencytextboxPrecioUnitario.ReadOnly = (mEditMode = False)
        percenttextboxPrecioUnitarioDescuentoPorcentaje.ReadOnly = (mEditMode = False)
        currencytextboxPrecioUnitarioDescuentoImporte.ReadOnly = (mEditMode = False)
    End Sub

    Friend Sub InitializeFormAndControls()
        mIDArticuloMatricula = CS_Parameter_System.GetIntegerAsShort(Parametros.CUOTA_MATRICULA_ARTICULO_ID)
        mIDArticuloMensual = CS_Parameter_System.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_ARTICULO_ID)
        mDescuentoRedondeo = CS_Parameter_System.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_DESCUENTO_REDONDEO)

        ' Cargo los ComboBox
        pFillAndRefreshLists.Articulo(comboboxArticulo, False, False, mComprobanteActual.IDComprobanteTipo)

        For MesNumero As Integer = 1 To 12
            comboboxCuotaMes.Items.Add(DateAndTime.MonthName(MesNumero))
        Next
    End Sub

    Private Sub FormEnd(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        mComprobanteActual = Nothing
        mComprobanteDetalleActual = Nothing
        mArticuloActual = Nothing
        mEntidad = Nothing
        Me.Dispose()
    End Sub

#End Region

#Region "Load and Set Data"

    Friend Sub SetDataFromObjectToControls()

        With mComprobanteDetalleActual
            CardonerSistemas.ComboBox.SetSelectedValue(comboboxArticulo, CardonerSistemas.ComboBox.SelectedItemOptions.Value, .IDArticulo, CShort(0))
            doubletextboxCantidad.DoubleValue = .Cantidad
            textboxUnidad.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Unidad)

            textboxDescripcion.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.DescripcionDisplay)

            ' Cargo los alumnos en el ComboBox
            CargarAlumnos(mComprobanteActual.IDEntidad, .IDEntidad)
            If .IDEntidad Is Nothing Then
                If comboboxAlumno.Items.Count = 1 Then
                    comboboxAlumno.SelectedIndex = 0
                End If
            Else
                If comboboxAlumno.Items.Count = 1 Then
                    comboboxAlumno.SelectedIndex = 0
                Else
                    comboboxAlumno.SelectedValue = .IDEntidad
                End If
                'EstablecerAnioLectivoCurso()
            End If

            If (Not mArticuloActual Is Nothing) AndAlso (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual) Then
                CardonerSistemas.ComboBox.SetSelectedValue(comboboxAnioLectivoCurso, CardonerSistemas.ComboBox.SelectedItemOptions.Value, .IDAnioLectivoCurso, CShort(0))
            Else
                comboboxAlumno.SelectedIndex = -1
                comboboxAnioLectivoCurso.SelectedIndex = -1
            End If
            If (Not mArticuloActual Is Nothing) AndAlso mArticuloActual.IDArticulo = mIDArticuloMensual Then
                If .CuotaMes.HasValue Then
                    comboboxCuotaMes.SelectedIndex = .CuotaMes.Value - 1
                Else
                    comboboxCuotaMes.SelectedIndex = -1
                End If
            Else
                comboboxCuotaMes.SelectedIndex = -1
            End If
            currencytextboxPrecioUnitario.DecimalValue = .PrecioUnitario
            percenttextboxPrecioUnitarioDescuentoPorcentaje.PercentValue = .PrecioUnitarioDescuentoPorcentaje
            currencytextboxPrecioUnitarioDescuentoImporte.DecimalValue = .PrecioUnitarioDescuentoImporte
            currencytextboxPrecioUnitarioFinal.DecimalValue = .PrecioUnitarioFinal
            currencytextboxPrecioTotal.DecimalValue = .PrecioTotal
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mComprobanteDetalleActual
            .IDArticulo = CS_ValueTranslation.FromControlComboBoxToObjectShort(comboboxArticulo.SelectedValue).Value
            .Cantidad = Convert.ToDecimal(doubletextboxCantidad.DoubleValue)
            .Unidad = CS_ValueTranslation.FromControlComboBoxToObjectString(textboxUnidad.Text)

            If mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual Then
                .IDEntidad = CS_ValueTranslation.FromControlComboBoxToObjectInteger(comboboxAlumno.SelectedValue)
                .IDAnioLectivoCurso = CS_ValueTranslation.FromControlComboBoxToObjectShort(comboboxAnioLectivoCurso.SelectedValue)
                .DescripcionDisplay = CS_ValueTranslation.FromControlComboBoxToObjectString(textboxDescripcion.Text)
            Else
                .IDEntidad = Nothing
                .IDAnioLectivoCurso = Nothing
                If textboxDescripcion.Text.Trim.Length = 0 Then
                    .Descripcion = comboboxArticulo.Text
                Else
                    .DescripcionDisplay = CS_ValueTranslation.FromControlComboBoxToObjectString(textboxDescripcion.Text)
                End If
            End If
            If mArticuloActual.IDArticulo = mIDArticuloMensual Then
                .CuotaMes = CByte(IIf(comboboxCuotaMes.SelectedIndex = -1, Nothing, comboboxCuotaMes.SelectedIndex + 1))
            Else
                .CuotaMes = Nothing
            End If
            .PrecioUnitario = currencytextboxPrecioUnitario.DecimalValue
            .PrecioUnitarioDescuentoPorcentaje = Convert.ToDecimal(percenttextboxPrecioUnitarioDescuentoPorcentaje.PercentValue)
            .PrecioUnitarioDescuentoImporte = currencytextboxPrecioUnitarioDescuentoImporte.DecimalValue
            .PrecioUnitarioFinal = currencytextboxPrecioUnitarioFinal.DecimalValue
            .PrecioTotal = currencytextboxPrecioTotal.DecimalValue
        End With
    End Sub

    Private Sub CargarAlumnos(ByVal IDEntidadPadre As Integer, ByVal IDEntidadActual As Integer?)
        Dim listAlumnos As List(Of Entidad)

        mLoading = True

        comboboxAlumno.ValueMember = "IDEntidad"
        comboboxAlumno.DisplayMember = "ApellidoNombre"

        Using dbContext As New CSColegioContext(True)
            If IDEntidadActual Is Nothing Then
                listAlumnos = (From e In dbContext.Entidad.Include("Descuento")
                               Where e.EsActivo AndAlso e.TipoAlumno AndAlso (((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_PADRE Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) And e.IDEntidadPadre = IDEntidadPadre) Or ((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_MADRE Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) And e.IDEntidadMadre = IDEntidadPadre) Or ((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) And e.IDEntidadTercero = IDEntidadPadre))
                               Order By e.ApellidoNombre).ToList
            Else
                listAlumnos = (From e In dbContext.Entidad.Include("Descuento")
                               Where e.EsActivo AndAlso e.TipoAlumno AndAlso (((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_PADRE Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) And e.IDEntidadPadre = IDEntidadPadre) Or ((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_MADRE Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) And e.IDEntidadMadre = IDEntidadPadre) Or ((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) And e.IDEntidadTercero = IDEntidadPadre) Or e.IDEntidad = IDEntidadActual)
                               Order By e.ApellidoNombre).ToList
            End If
        End Using

        comboboxAlumno.DataSource = listAlumnos
        comboboxAlumno.SelectedValue = 0

        mLoading = False
    End Sub

    Private Sub CambiarArticulo()
        If comboboxArticulo.SelectedIndex > -1 Then
            mArticuloActual = CType(comboboxArticulo.SelectedItem, Articulo)

            doubletextboxCantidad.ReadOnly = (mEditMode = False Or mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            textboxUnidad.ReadOnly = (mEditMode = False Or mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            If mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual Then
                doubletextboxCantidad.Text = "1"
                textboxUnidad.Text = ""
            End If

            labelAlumno.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            comboboxAlumno.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            buttonAlumno.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)

            labelAnioLectivoCurso.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            comboboxAnioLectivoCurso.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)

            labelCuotaMes.Visible = (mArticuloActual.IDArticulo = mIDArticuloMensual)
            comboboxCuotaMes.Visible = (mArticuloActual.IDArticulo = mIDArticuloMensual)
        Else
            doubletextboxCantidad.ReadOnly = True
            textboxUnidad.ReadOnly = True

            labelAlumno.Visible = False
            comboboxAlumno.Visible = False
            buttonAlumno.Visible = False

            labelAnioLectivoCurso.Visible = False
            comboboxAnioLectivoCurso.Visible = False
            comboboxAnioLectivoCurso.DataSource = Nothing

            labelCuotaMes.Visible = False
            comboboxCuotaMes.Visible = False
        End If
    End Sub

    Private Sub EstablecerAnioLectivoCurso()
        If mEntidad Is Nothing Then
            comboboxAnioLectivoCurso.DataSource = Nothing
        Else
            If mArticuloActual.IDArticulo = mIDArticuloMatricula Then
                If Permisos.VerificarPermiso(Permisos.COMPROBANTE_DETALLE_PERMITE_MATRICULAANIOANTERIOR, False) Then
                    pFillAndRefreshLists.AnioLectivoCurso(comboboxAnioLectivoCurso, Today.Year - 1, Today.Year + 1, True, mEntidad.IDEntidad)
                Else
                    pFillAndRefreshLists.AnioLectivoCurso(comboboxAnioLectivoCurso, Today.Year, Today.Year + 1, True, mEntidad.IDEntidad)
                End If
            ElseIf mArticuloActual.IDArticulo = mIDArticuloMensual Then
                If Permisos.VerificarPermiso(Permisos.COMPROBANTE_DETALLE_PERMITE_CUOTAANIOANTERIORYSIGUIENTE, False) Then
                    pFillAndRefreshLists.AnioLectivoCurso(comboboxAnioLectivoCurso, Today.Year - 1, Today.Year + 1, True, mEntidad.IDEntidad)
                ElseIf Permisos.VerificarPermiso(Permisos.COMPROBANTE_DETALLE_PERMITE_CUOTAANIOSIGUIENTE, False) Then
                    pFillAndRefreshLists.AnioLectivoCurso(comboboxAnioLectivoCurso, Today.Year, Today.Year + 1, True, mEntidad.IDEntidad)
                Else
                    pFillAndRefreshLists.AnioLectivoCurso(comboboxAnioLectivoCurso, Today.Year, Today.Year, True, mEntidad.IDEntidad)
                End If
            End If
        End If
    End Sub

    Private Sub EstablecerDescripcion()
        If (Not mArticuloActual Is Nothing) AndAlso (mArticuloActual.IDArticulo = mIDArticuloMatricula Or (mArticuloActual.IDArticulo = mIDArticuloMensual And comboboxCuotaMes.SelectedIndex > -1)) And (Not mEntidad Is Nothing) And (Not comboboxAnioLectivoCurso.SelectedItem Is Nothing) Then
            Dim AnioLectivoCursoActual As AnioLectivoCurso

            Try
                AnioLectivoCursoActual = mdbContext.AnioLectivoCurso.Find(CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCursoListItem).IDAnioLectivoCurso)
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener los datos del Curso y Año Lectivo.")
                textboxDescripcion.Text = ""
                Exit Sub
            End Try

            textboxDescripcion.Text = ModuloComprobantes.GenerarDescripcionConEtiquetas(mArticuloActual.Descripcion, mArticuloActual.Nombre, AnioLectivoCursoActual.AnioLectivo.ToString(), comboboxCuotaMes.Text, mEntidad, AnioLectivoCursoActual.Curso.Anio.Nivel.Nombre, AnioLectivoCursoActual.Curso.Anio.Nombre, AnioLectivoCursoActual.Curso.Turno.Nombre).Replace(Environment.NewLine, Constantes.NewLineCharDisplayReplacement)
        Else
            textboxDescripcion.Text = ""
        End If
    End Sub

    Private Sub EstablecerPrecioUnitario()
        Dim AnioLectivo As Short
        Dim IDCurso As Byte
        Dim CursoActual As Curso
        Dim IDCuotaTipo As Byte
        Dim AnioLectivoCuotaActual As AnioLectivoCuota
        Dim PrecioUnitario As Decimal

        If (Not mArticuloActual Is Nothing) AndAlso (Not comboboxAlumno.SelectedIndex = -1) AndAlso (Not comboboxAnioLectivoCurso.SelectedItem Is Nothing) Then
            AnioLectivo = CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCursoListItem).AnioLectivo
            IDCurso = CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCursoListItem).IDCurso
            Select Case mArticuloActual.IDArticulo
                Case mIDArticuloMatricula
                    ' MATRÍCULA
                    Using dbContext As New CSColegioContext(True)
                        CursoActual = dbContext.Curso.Find(IDCurso)
                        If Not CursoActual Is Nothing Then
                            IDCuotaTipo = CursoActual.IDCuotaTipo
                            AnioLectivoCuotaActual = dbContext.AnioLectivoCuota.Where(Function(alci) alci.AnioLectivo = AnioLectivo And alci.MesInicio <= Month(DateAndTime.Today) And alci.IDCuotaTipo = IDCuotaTipo).OrderByDescending(Function(alci) alci.MesInicio).FirstOrDefault
                            If Not AnioLectivoCuotaActual Is Nothing Then
                                PrecioUnitario = AnioLectivoCuotaActual.ImporteMatricula
                            End If
                        End If
                    End Using
                Case mIDArticuloMensual
                    ' CUOTA MENSUAL
                    If comboboxCuotaMes.SelectedIndex > -1 Then
                        Using dbContext As New CSColegioContext(True)
                            CursoActual = dbContext.Curso.Find(IDCurso)
                            If Not CursoActual Is Nothing Then
                                IDCuotaTipo = CursoActual.IDCuotaTipo
                                AnioLectivoCuotaActual = dbContext.AnioLectivoCuota.Where(Function(alci) alci.AnioLectivo = AnioLectivo And alci.MesInicio <= CByte(comboboxCuotaMes.SelectedIndex + 1) And alci.IDCuotaTipo = IDCuotaTipo).OrderByDescending(Function(alci) alci.MesInicio).FirstOrDefault
                                If Not AnioLectivoCuotaActual Is Nothing Then
                                    PrecioUnitario = AnioLectivoCuotaActual.ImporteCuota
                                End If
                            End If
                        End Using
                    End If
            End Select
            currencytextboxPrecioUnitario.DecimalValue = PrecioUnitario
        End If
    End Sub

    Private Sub CalcularPrecioFinal()
        If Not doubletextboxCantidad.IsNull Then
            currencytextboxPrecioTotal.DecimalValue = Convert.ToDecimal(doubletextboxCantidad.DoubleValue) * currencytextboxPrecioUnitarioFinal.DecimalValue
        End If
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

    Private Sub Articulo_Selected() Handles comboboxArticulo.SelectedValueChanged
        CambiarArticulo()
        EstablecerAnioLectivoCurso()
        EstablecerDescripcion()
        EstablecerPrecioUnitario()
    End Sub

    Private Sub CambioCantidad() Handles doubletextboxCantidad.DoubleValueChanged
        CalcularPrecioFinal()
    End Sub

    Private Sub Alumno_Changed() Handles comboboxAlumno.SelectedIndexChanged
        If Not mLoading Then
            If comboboxAlumno.SelectedIndex > -1 Then
                mEntidad = CType(comboboxAlumno.SelectedItem, Entidad)
                If mEntidad.IDDescuento.HasValue Then
                    ' Especifica descuento
                    If mEntidad.IDDescuento.Value = CardonerSistemas.Constants.FIELD_VALUE_OTHER_BYTE Then
                        ' Descuento personalizado para la entidad
                        If mEntidad.DescuentoOtroPorcentaje.HasValue Then
                            percenttextboxPrecioUnitarioDescuentoPorcentaje.PercentValue = mEntidad.DescuentoOtroPorcentaje.Value
                        Else
                            percenttextboxPrecioUnitarioDescuentoPorcentaje.PercentValue = 0
                        End If
                    Else
                        ' Descuento de la tabla de descuentos
                        percenttextboxPrecioUnitarioDescuentoPorcentaje.PercentValue = mEntidad.Descuento.Porcentaje
                    End If
                Else
                    ' No especifica descuento
                    percenttextboxPrecioUnitarioDescuentoPorcentaje.PercentValue = 0
                End If
            End If
            EstablecerAnioLectivoCurso()
            EstablecerDescripcion()
            EstablecerPrecioUnitario()
        End If
    End Sub

    Private Sub Entidad_Click(sender As Object, e As EventArgs) Handles buttonAlumno.Click
        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = True
        formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Otro.Checked = False
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            mLoading = True
            CargarAlumnos(mComprobanteActual.IDEntidad, CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad).IDEntidad)
            mLoading = False
            comboboxAlumno.SelectedValue = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad).IDEntidad
        End If
        formEntidadesSeleccionar.Dispose()

        EstablecerAnioLectivoCurso()
        EstablecerDescripcion()
        EstablecerPrecioUnitario()
    End Sub

    Private Sub AnioLectivoCurso_Selected() Handles comboboxAnioLectivoCurso.SelectedValueChanged
        EstablecerDescripcion()
        EstablecerPrecioUnitario()
    End Sub

    Private Sub CuotaMes_Selected() Handles comboboxCuotaMes.SelectedIndexChanged
        EstablecerDescripcion()
        EstablecerPrecioUnitario()
    End Sub

    Private Sub PrecioUnitario_TextChanged() Handles currencytextboxPrecioUnitario.DecimalValueChanged
        CalcularDescuento()
    End Sub

    Private Sub CalcularDescuento() Handles percenttextboxPrecioUnitarioDescuentoPorcentaje.DoubleValueChanged
        If Not mCambiandoDescuento Then
            currencytextboxPrecioUnitarioDescuentoImporte.DecimalValue = currencytextboxPrecioUnitario.DecimalValue * Convert.ToDecimal(percenttextboxPrecioUnitarioDescuentoPorcentaje.DoubleValue)
            If mDescuentoRedondeo > 0 Then
                currencytextboxPrecioUnitarioDescuentoImporte.DecimalValue = Math.Round(currencytextboxPrecioUnitarioDescuentoImporte.DecimalValue / mDescuentoRedondeo, 0, MidpointRounding.AwayFromZero) * mDescuentoRedondeo
            End If
            PrecioUnitarioDescuentoImporte_TextChanged()
        End If
    End Sub

    Private Sub PrecioUnitarioDescuentoImporte_KeyPressed() Handles currencytextboxPrecioUnitarioDescuentoImporte.KeyPress
        mCambiandoDescuento = True
        percenttextboxPrecioUnitarioDescuentoPorcentaje.DoubleValue = 0
        mCambiandoDescuento = False
    End Sub

    Private Sub PrecioUnitarioDescuentoImporte_TextChanged() Handles currencytextboxPrecioUnitarioDescuentoImporte.DecimalValueChanged
        currencytextboxPrecioUnitarioFinal.DecimalValue = currencytextboxPrecioUnitario.DecimalValue - currencytextboxPrecioUnitarioDescuentoImporte.DecimalValue
        CalcularPrecioFinal()
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxUnidad.GotFocus, textboxDescripcion.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub

#End Region

#Region "Main Toolbar"

    Private Sub buttonEditar_Click() Handles buttonEditar.Click
        mEditMode = True
        ChangeMode()
    End Sub

    Private Sub buttonCerrarOCancelar_Click() Handles buttonCerrar.Click, buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonGuardar_Click() Handles buttonGuardar.Click
        If comboboxArticulo.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Artículo.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxArticulo.Focus()
            Exit Sub
        End If

        If doubletextboxCantidad.DoubleValue = 0 Then
            MsgBox("Debe ingresar la Cantidad.", MsgBoxStyle.Information, My.Application.Info.Title)
            doubletextboxCantidad.Focus()
            Exit Sub
        End If

        If mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual Then
            If comboboxAlumno.SelectedIndex = -1 Then
                MsgBox("Debe especificar el Alumno.", MsgBoxStyle.Information, My.Application.Info.Title)
                buttonAlumno.Focus()
                Exit Sub
            End If
            If comboboxAnioLectivoCurso.SelectedIndex = -1 Then
                MsgBox("Debe especificar el Año Lectivo y Curso.", MsgBoxStyle.Information, My.Application.Info.Title)
                comboboxAnioLectivoCurso.Focus()
                Exit Sub
            End If
        End If
        If mArticuloActual.IDArticulo = mIDArticuloMensual Then
            If comboboxCuotaMes.SelectedIndex = -1 Then
                MsgBox("Debe especificar la Cuota - Mes.", MsgBoxStyle.Information, My.Application.Info.Title)
                comboboxCuotaMes.Focus()
                Exit Sub
            End If
        End If

        ' Si es un nuevo item, busco el próximo Indice y agrego el objeto nuevo a la colección del parent
        If mComprobanteDetalleActual.Indice = 0 Then
            If mComprobanteActual.ComprobanteDetalle.Count = 0 Then
                mComprobanteDetalleActual.Indice = 1
            Else
                mComprobanteDetalleActual.Indice = mComprobanteActual.ComprobanteDetalle.Max(Function(cmp) cmp.Indice) + CByte(1)
            End If
            mComprobanteActual.ComprobanteDetalle.Add(mComprobanteDetalleActual)
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        ' Refresco la lista para mostrar los cambios
        If CS_Form.MDIChild_IsLoaded(CType(pFormMDIMain, Form), "formComprobante") Then
            Dim formComprobante As formComprobante = CType(CS_Form.MDIChild_GetInstance(CType(pFormMDIMain, Form), "formComprobante"), formComprobante)
            formComprobante.RefreshData_Detalle(mComprobanteDetalleActual.Indice)
            formComprobante = Nothing
        End If

        Me.Close()
    End Sub

#End Region

End Class