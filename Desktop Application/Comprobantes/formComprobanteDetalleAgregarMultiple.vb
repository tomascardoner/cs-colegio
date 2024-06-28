Public Class formComprobanteDetalleAgregarMultiple

#Region "Declarations"

    Private mComprobanteActual As Comprobante
    Private mArticuloActual As Articulo
    Private mEntidad As Entidad
    Private mDescuentoRedondeo As Short

    Private mParentEditMode As Boolean = False
    Private mEditMode As Boolean = False

    Private mCambiandoDescuento As Boolean = False

    Private mLoading As Boolean

#End Region

#Region "Form stuff"

    Friend Sub LoadAndShow(ByVal ParentEditMode As Boolean, ByVal EditMode As Boolean, ByRef ParentForm As Form, ByRef ComprobanteActual As Comprobante)
        mParentEditMode = ParentEditMode
        mEditMode = EditMode

        mComprobanteActual = ComprobanteActual

        CardonerSistemas.Forms.CenterToParent(ParentForm, Me)
        InitializeFormAndControls()
        SetDataFromObjectToControls()

        Me.ShowDialog(ParentForm)
    End Sub

    Friend Sub InitializeFormAndControls()
        Using dbContext As New CSColegioContext(True)
            mArticuloActual = dbContext.Articulo.Find(CS_Parameter_System.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_ARTICULO_ID))
        End Using

        For MesNumero As Integer = 1 To 12
            comboboxCuotaMesDesde.Items.Add(DateAndTime.MonthName(MesNumero))
            comboboxCuotaMesHasta.Items.Add(DateAndTime.MonthName(MesNumero))
        Next

        mDescuentoRedondeo = CS_Parameter_System.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_DESCUENTO_REDONDEO)
    End Sub

    Private Sub FormEnd(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mComprobanteActual = Nothing
        mArticuloActual = Nothing
        mEntidad = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Mostrar y leer datos"

    Friend Sub SetDataFromObjectToControls()
        textboxArticulo.Text = mArticuloActual.Nombre
        EstablecerAnioLectivoCurso()
        EstablecerPrecioUnitario()

        ' Cargo los alumnos en el ComboBox
        CargarAlumnos(mComprobanteActual.IDEntidad)
        If comboboxAlumno.Items.Count = 1 Then
            comboboxAlumno.SelectedIndex = 0
        End If

        comboboxCuotaMesDesde.SelectedIndex = -1
        comboboxCuotaMesHasta.SelectedIndex = -1
    End Sub

    Friend Sub SetDataFromControlsToObject(ByRef comprobanteDetalleActual As ComprobanteDetalle, ByVal cuotaMes As Byte, ByVal anioLectivo As String, ByVal nivel As String, ByVal anio As String, ByVal turno As String, ByVal usarDescripcionCorta As Boolean)
        With comprobanteDetalleActual
            .IDArticulo = mArticuloActual.IDArticulo
            .Cantidad = 1
            .Unidad = Nothing

            .IDEntidad = CS_ValueTranslation.FromControlComboBoxToObjectInteger(comboboxAlumno.SelectedValue)
            .IDAnioLectivoCurso = CS_ValueTranslation.FromControlComboBoxToObjectShort(comboboxAnioLectivoCurso.SelectedValue)

            If usarDescripcionCorta Then
                .Descripcion = ModuloComprobantes.GenerarDescripcionConEtiquetas(mArticuloActual.DescripcionCorta, mArticuloActual.Nombre, anioLectivo, DateAndTime.MonthName(cuotaMes), mEntidad, nivel, anio, turno)
            Else
                .Descripcion = ModuloComprobantes.GenerarDescripcionConEtiquetas(mArticuloActual.Descripcion, mArticuloActual.Nombre, anioLectivo, DateAndTime.MonthName(cuotaMes), mEntidad, nivel, anio, turno)
            End If

            .CuotaMes = cuotaMes

            .PrecioUnitario = currencytextboxPrecioUnitario.DecimalValue
            .PrecioUnitarioDescuentoPorcentaje = Convert.ToDecimal(percenttextboxPrecioUnitarioDescuentoPorcentaje.PercentValue)
            .PrecioUnitarioDescuentoImporte = currencytextboxPrecioUnitarioDescuentoImporte.DecimalValue
            .PrecioUnitarioFinal = currencytextboxPrecioUnitarioFinal.DecimalValue
            .PrecioTotal = currencytextboxPrecioTotal.DecimalValue
        End With
    End Sub

    Private Sub CargarAlumnos(ByVal IDEntidadPadre As Integer)
        Dim listAlumnos As List(Of Entidad)

        mLoading = True

        comboboxAlumno.ValueMember = "IDEntidad"
        comboboxAlumno.DisplayMember = "ApellidoNombre"

        Using dbContext As New CSColegioContext(True)
            listAlumnos = (From e In dbContext.Entidad.Include("Descuento")
                           Where e.EsActivo AndAlso e.TipoAlumno AndAlso (((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_PADRE OrElse e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES OrElse e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) AndAlso e.IDEntidadPadre = IDEntidadPadre) OrElse ((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_MADRE OrElse e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES OrElse e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) AndAlso e.IDEntidadMadre = IDEntidadPadre) OrElse ((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO OrElse e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) AndAlso e.IDEntidadTercero = IDEntidadPadre))
                           Order By e.ApellidoNombre).ToList
        End Using

        comboboxAlumno.DataSource = listAlumnos
        comboboxAlumno.SelectedValue = 0

        mLoading = False
    End Sub

    Private Sub EstablecerAnioLectivoCurso()
        If mEntidad Is Nothing Then
            comboboxAnioLectivoCurso.DataSource = Nothing
        Else
            If Permisos.VerificarPermiso(Permisos.COMPROBANTE_DETALLE_PERMITE_CUOTAANIOANTERIORYSIGUIENTE, False) Then
                pFillAndRefreshLists.AnioLectivoCurso(comboboxAnioLectivoCurso, Today.Year - 1, Today.Year + 1, True, mEntidad.IDEntidad)
            ElseIf Permisos.VerificarPermiso(Permisos.COMPROBANTE_DETALLE_PERMITE_CUOTAANIOSIGUIENTE, False) Then
                pFillAndRefreshLists.AnioLectivoCurso(comboboxAnioLectivoCurso, Today.Year, Today.Year + 1, True, mEntidad.IDEntidad)
            Else
                pFillAndRefreshLists.AnioLectivoCurso(comboboxAnioLectivoCurso, Today.Year, Today.Year, True, mEntidad.IDEntidad)
            End If
        End If
    End Sub

    Private Sub EstablecerPrecioUnitario()
        Dim AnioLectivo As Short
        Dim IDCurso As Byte
        Dim CursoActual As Curso
        Dim IDCuotaTipo As Byte
        Dim AnioLectivoCuotaActual As AnioLectivoCuota
        Dim PrecioUnitario As Decimal

        If (mArticuloActual IsNot Nothing) AndAlso (Not comboboxAlumno.SelectedIndex = -1) AndAlso (comboboxAnioLectivoCurso.SelectedItem IsNot Nothing) Then
            If comboboxCuotaMesDesde.SelectedIndex > -1 Then
                AnioLectivo = CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCursoListItem).AnioLectivo
                IDCurso = CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCursoListItem).IDCurso
                Using dbContext As New CSColegioContext(True)
                    CursoActual = dbContext.Curso.Find(IDCurso)
                    If CursoActual IsNot Nothing Then
                        IDCuotaTipo = CursoActual.IDCuotaTipo
                        AnioLectivoCuotaActual = dbContext.AnioLectivoCuota.Where(Function(alci) alci.AnioLectivo = AnioLectivo AndAlso alci.MesInicio <= CByte(comboboxCuotaMesDesde.SelectedIndex + 1) AndAlso alci.IDCuotaTipo = IDCuotaTipo).OrderByDescending(Function(alci) alci.MesInicio).FirstOrDefault
                        If AnioLectivoCuotaActual IsNot Nothing Then
                            PrecioUnitario = AnioLectivoCuotaActual.ImporteCuota
                        End If
                    End If
                End Using
            End If
            currencytextboxPrecioUnitario.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(PrecioUnitario)
        End If
    End Sub

    Private Sub CalcularPrecioFinal()
        currencytextboxPrecioTotal.Text = currencytextboxPrecioUnitarioFinal.Text
    End Sub

#End Region

#Region "Controls behavior"

    Private Sub FormKeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                buttonGuardar.PerformClick()
            Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                buttonCancelar.PerformClick()
        End Select
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
            CargarAlumnos(mComprobanteActual.IDEntidad)
            mLoading = False
            comboboxAlumno.SelectedValue = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad).IDEntidad
        End If
        formEntidadesSeleccionar.Dispose()

        EstablecerAnioLectivoCurso()
        EstablecerPrecioUnitario()
    End Sub

    Private Sub AnioLectivoCurso_Selected() Handles comboboxAnioLectivoCurso.SelectedValueChanged
        EstablecerPrecioUnitario()
    End Sub

    Private Sub CuotaMes_Selected() Handles comboboxCuotaMesDesde.SelectedIndexChanged
        EstablecerPrecioUnitario()
    End Sub

    Private Sub PrecioUnitario_TextChanged() Handles currencytextboxPrecioUnitario.DecimalValueChanged
        CalcularDescuento()
        CalcularPrecioFinal()
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

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs)
        CType(sender, TextBox).SelectAll()
    End Sub
#End Region

#Region "Main Toolbar"

    Private Sub CerrarOCancelar_Click() Handles buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub Guardar_Click() Handles buttonGuardar.Click
        Dim anioLectivo As String
        Dim nivel As String
        Dim anio As String
        Dim turno As String

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
        If comboboxCuotaMesDesde.SelectedIndex = -1 Then
            MsgBox("Debe especificar la Cuota - Mes - Desde.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxCuotaMesDesde.Focus()
            Exit Sub
        End If
        If comboboxCuotaMesHasta.SelectedIndex = -1 Then
            MsgBox("Debe especificar la Cuota - Mes - Hasta.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxCuotaMesHasta.Focus()
            Exit Sub
        End If
        If comboboxCuotaMesDesde.SelectedIndex > comboboxCuotaMesHasta.SelectedIndex Then
            MsgBox("La Cuota - Mes - Desde debe ser menor a la Cuota - Mes - Hasta.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxCuotaMesHasta.Focus()
            Exit Sub
        End If

        Using dbContext As New CSColegioContext(True)
            Try
                Dim anioLectivoCurso As AnioLectivoCurso

                anioLectivoCurso = dbContext.AnioLectivoCurso.Find(CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCursoListItem).IDAnioLectivoCurso)
                anioLectivo = AnioLectivoCurso.AnioLectivo.ToString()
                nivel = AnioLectivoCurso.Curso.Anio.Nivel.Nombre
                anio = AnioLectivoCurso.Curso.Anio.Nombre
                turno = anioLectivoCurso.Curso.Turno.Nombre

                anioLectivoCurso = Nothing

            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener el Curso del Año lectivo.")
                Exit Sub
            End Try
        End Using

        For Indice As Integer = comboboxCuotaMesDesde.SelectedIndex + 1 To comboboxCuotaMesHasta.SelectedIndex + 1
            Dim ComprobanteDetalleActual As New ComprobanteDetalle

            ' Busco el próximo Indice y agrego el objeto nuevo a la colección del parent
            If mComprobanteActual.ComprobanteDetalle.Count = 0 Then
                ComprobanteDetalleActual.Indice = 1
            Else
                ComprobanteDetalleActual.Indice = mComprobanteActual.ComprobanteDetalle.Max(Function(cmp) cmp.Indice) + CByte(1)
            End If
            mComprobanteActual.ComprobanteDetalle.Add(ComprobanteDetalleActual)

            ' Paso los datos desde los controles al Objecto de EF
            If (comboboxCuotaMesHasta.SelectedIndex - comboboxCuotaMesDesde.SelectedIndex + 1) > 3 AndAlso (Indice - comboboxCuotaMesDesde.SelectedIndex) > 1 Then
                ' Son más de 3 items iguales, así que a los ítems siguientes al primero, se les aplica la descripción corta
                SetDataFromControlsToObject(ComprobanteDetalleActual, CByte(Indice), anioLectivo, nivel, anio, turno, True)
            Else
                SetDataFromControlsToObject(ComprobanteDetalleActual, CByte(Indice), anioLectivo, nivel, anio, turno, False)
            End If
        Next Indice

        ' Refresco la lista para mostrar los cambios
        If CardonerSistemas.Forms.MdiChildIsLoaded(CType(pFormMDIMain, Form), "formComprobante") Then
            Dim formComprobante As FormComprobante = CType(CardonerSistemas.Forms.MdiChildGetInstance(CType(pFormMDIMain, Form), "formComprobante"), FormComprobante)
            formComprobante.RefreshData_Detalle()
            formComprobante = Nothing
        End If

        Me.Close()
    End Sub

#End Region

End Class