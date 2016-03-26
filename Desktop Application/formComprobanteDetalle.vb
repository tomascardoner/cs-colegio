Public Class formComprobanteDetalle

#Region "Declarations"
    Private mIDArticuloMatricula As Short
    Private mIDArticuloMensual As Short
    Private mComprobanteActual As Comprobante
    Private mComprobanteDetalleActual As ComprobanteDetalle
    Private mArticuloActual As Articulo
    Private mEntidad As Entidad

    Private mParentEditMode As Boolean = False
    Private mEditMode As Boolean = False

    Private mCambiandoDescuento As Boolean = False

    Private mLoading As Boolean
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByVal ParentEditMode As Boolean, ByVal EditMode As Boolean, ByRef ParentForm As Form, ByRef ComprobanteActual As Comprobante, ByRef ComprobanteDetalleActual As ComprobanteDetalle)
        mParentEditMode = ParentEditMode
        mEditMode = EditMode

        mComprobanteActual = ComprobanteActual
        mComprobanteDetalleActual = ComprobanteDetalleActual

        'Me.MdiParent = formMDIMain
        CS_Form.CenterToParent(ParentForm, Me)
        InitializeFormAndControls()
        SetDataFromObjectToControls()
        ChangeMode()

        Me.ShowDialog(ParentForm)
        'If Me.WindowState = FormWindowState.Minimized Then
        '    Me.WindowState = FormWindowState.Normal
        'End If
        'Me.Focus()
    End Sub

    Private Sub ChangeMode()
        buttonGuardar.Visible = mEditMode
        buttonCancelar.Visible = mEditMode
        buttonEditar.Visible = (mParentEditMode And Not mEditMode)
        buttonCerrar.Visible = Not mEditMode

        comboboxArticulo.Enabled = mEditMode
        textboxCantidad.ReadOnly = (mEditMode = False)
        textboxUnidad.ReadOnly = (mEditMode = False)
        buttonAlumno.Enabled = mEditMode
        comboboxAnioLectivoCurso.Enabled = mEditMode
        comboboxCuotaMes.Enabled = mEditMode
        textboxPrecioUnitario.ReadOnly = (mEditMode = False)
        textboxPrecioUnitarioDescuentoPorcentaje.ReadOnly = (mEditMode = False)
        textboxPrecioUnitarioDescuentoImporte.ReadOnly = (mEditMode = False)
    End Sub

    Friend Sub InitializeFormAndControls()
        mIDArticuloMatricula = CS_Parameter.GetIntegerAsShort(Parametros.CUOTA_MATRICULA_ARTICULO_ID)
        mIDArticuloMensual = CS_Parameter.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_ARTICULO_ID)

        ' Cargo los ComboBox
        pFillAndRefreshLists.Articulo(comboboxArticulo, False, False)

        For MesNumero As Integer = 1 To 12
            comboboxCuotaMes.Items.Add(StrConv(MonthName(MesNumero), VbStrConv.ProperCase))
        Next
    End Sub

    Private Sub FormEnd(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
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
            CS_Control_ComboBox.SetSelectedValue(comboboxArticulo, SelectedItemOptions.Value, .IDArticulo, CShort(0))
            textboxCantidad.Text = CS_ValueTranslation.FromObjectDecimalToControlTextBox(.Cantidad)
            textboxUnidad.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Unidad)
            textboxDescripcion.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Descripcion)

            If (Not mArticuloActual Is Nothing) AndAlso (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual) Then
                CargarAlumnos(mComprobanteActual.IDEntidad, .IDEntidad)
                If .IDEntidad Is Nothing Then
                    If comboboxAlumno.Items.Count = 1 Then
                        comboboxAlumno.SelectedIndex = 0
                    End If
                Else
                    comboboxAlumno.SelectedValue = .IDEntidad
                    If comboboxAlumno.Items.Count = 1 Then
                        comboboxAlumno.SelectedIndex = 0
                    End If
                    'EstablecerAnioLectivoCurso()
                End If
                CS_Control_ComboBox.SetSelectedValue(comboboxAnioLectivoCurso, SelectedItemOptions.Value, .IDAnioLectivoCurso, CShort(0))
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
            textboxPrecioUnitario.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.PrecioUnitario)
            textboxPrecioUnitarioDescuentoPorcentaje.Text = CS_ValueTranslation.FromObjectPercentToControlTextBox(.PrecioUnitarioDescuentoPorcentaje)
            textboxPrecioUnitarioDescuentoImporte.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.PrecioUnitarioDescuentoImporte)
            textboxPrecioUnitarioFinal.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.PrecioUnitarioFinal)
            textboxPrecioTotal.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.PrecioTotal)
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mComprobanteDetalleActual
            .IDArticulo = CS_ValueTranslation.FromControlComboBoxToObjectShort(comboboxArticulo.SelectedValue).Value
            .Cantidad = CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxCantidad.Text).Value
            .Unidad = CS_ValueTranslation.FromControlComboBoxToObjectString(textboxUnidad.Text)

            If mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual Then
                .IDEntidad = CS_ValueTranslation.FromControlComboBoxToObjectInteger(comboboxAlumno.SelectedValue)
                .IDAnioLectivoCurso = CS_ValueTranslation.FromControlComboBoxToObjectShort(comboboxAnioLectivoCurso.SelectedValue)
                .Descripcion = CS_ValueTranslation.FromControlComboBoxToObjectString(textboxDescripcion.Text)
            Else
                .IDEntidad = Nothing
                .IDAnioLectivoCurso = Nothing
                .Descripcion = comboboxArticulo.Text
            End If
            If mArticuloActual.IDArticulo = mIDArticuloMensual Then
                .CuotaMes = CByte(IIf(comboboxCuotaMes.SelectedIndex = -1, Nothing, comboboxCuotaMes.SelectedIndex + 1))
            Else
                .CuotaMes = Nothing
            End If
            .PrecioUnitario = CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitario.Text).Value
            .PrecioUnitarioDescuentoPorcentaje = CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitarioDescuentoPorcentaje.Text).Value
            .PrecioUnitarioDescuentoImporte = CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitarioDescuentoImporte.Text).Value
            .PrecioUnitarioFinal = CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitarioFinal.Text).Value
            .PrecioTotal = CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioTotal.Text).Value
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

            textboxCantidad.ReadOnly = (mEditMode = False Or mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            textboxUnidad.ReadOnly = (mEditMode = False Or mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            If mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual Then
                textboxCantidad.Text = "1"
                textboxUnidad.Text = ""
            End If

            labelDescripcion.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            textboxDescripcion.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)

            labelAlumno.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            comboboxAlumno.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            buttonAlumno.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)

            labelAnioLectivoCurso.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            comboboxAnioLectivoCurso.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)

            labelCuotaMes.Visible = (mArticuloActual.IDArticulo = mIDArticuloMensual)
            comboboxCuotaMes.Visible = (mArticuloActual.IDArticulo = mIDArticuloMensual)
        Else
            textboxCantidad.ReadOnly = True
            textboxUnidad.ReadOnly = True

            labelDescripcion.Visible = False
            textboxDescripcion.Visible = False

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
                pFillAndRefreshLists.AnioLectivoCurso(comboboxAnioLectivoCurso, Today.Year, Today.Year + 1, True, mEntidad.IDEntidad)
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
            textboxDescripcion.Text = String.Format(mArticuloActual.Descripcion, vbCrLf, mArticuloActual.Nombre, mEntidad.IDEntidad, mEntidad.Apellido, mEntidad.Nombre, mEntidad.ApellidoNombre, CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCurso_ListItem).AnioLectivo, comboboxCuotaMes.Text)
        Else
            textboxDescripcion.Text = ""
        End If
    End Sub

    Private Sub EstablecerPrecioUnitario()
        Dim AnioLectivoCursoActual As AnioLectivoCurso
        Dim AnioLectivoCursoImporteActual As AnioLectivoCursoImporte
        Dim PrecioUnitario As Decimal

        If (Not mArticuloActual Is Nothing) AndAlso (Not comboboxAlumno.SelectedIndex = -1) AndAlso (Not comboboxAnioLectivoCurso.SelectedItem Is Nothing) Then
            Select Case mArticuloActual.IDArticulo
                Case mIDArticuloMatricula
                    ' MATRÍCULA
                    Using dbContext As New CSColegioContext(True)
                        AnioLectivoCursoActual = dbContext.AnioLectivoCurso.Find(CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCurso_ListItem).IDAnioLectivoCurso)
                        AnioLectivoCursoImporteActual = AnioLectivoCursoActual.AnioLectivoCursoImporte.Where(Function(alci) alci.MesInicio <= Month(DateAndTime.Today)).OrderByDescending(Function(alci) alci.MesInicio).FirstOrDefault
                    End Using
                    If Not AnioLectivoCursoImporteActual Is Nothing Then
                        PrecioUnitario = AnioLectivoCursoImporteActual.ImporteMatricula
                    End If
                Case mIDArticuloMensual
                    ' CUOTA MENSUAL
                    If comboboxCuotaMes.SelectedIndex > -1 Then
                        Using dbContext As New CSColegioContext(True)
                            AnioLectivoCursoActual = dbContext.AnioLectivoCurso.Find(CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCurso_ListItem).IDAnioLectivoCurso)
                            AnioLectivoCursoImporteActual = AnioLectivoCursoActual.AnioLectivoCursoImporte.Where(Function(alci) alci.MesInicio <= CByte(comboboxCuotaMes.SelectedIndex + 1)).OrderByDescending(Function(alci) alci.MesInicio).FirstOrDefault
                        End Using
                        If Not AnioLectivoCursoImporteActual Is Nothing Then
                            PrecioUnitario = AnioLectivoCursoImporteActual.ImporteCuota
                        End If
                    End If
            End Select
            textboxPrecioUnitario.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(PrecioUnitario)
        End If
    End Sub

    Private Sub CalcularPrecioFinal()
        If CS_ValueTranslation.ValidateCurrency(textboxPrecioUnitarioFinal.Text) Then
            If CS_ValueTranslation.ValidateDecimal(textboxCantidad.Text) Then
                textboxPrecioTotal.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxCantidad.Text) * CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitarioFinal.Text))
            End If
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

    Private Sub CambioCantidad() Handles textboxCantidad.TextChanged
        CalcularPrecioFinal()
    End Sub

    Private Sub Alumno_Changed() Handles comboboxAlumno.SelectedIndexChanged
        If Not mLoading Then
            If comboboxAlumno.SelectedIndex > -1 Then
                mEntidad = CType(comboboxAlumno.SelectedItem, Entidad)
                If mEntidad.IDDescuento Is Nothing Then
                    textboxPrecioUnitarioDescuentoPorcentaje.Text = CS_ValueTranslation.FromObjectPercentToControlTextBox(0)
                    'textboxPrecioUnitarioDescuentoImporte.Text = "0"
                Else
                    textboxPrecioUnitarioDescuentoPorcentaje.Text = CS_ValueTranslation.FromObjectPercentToControlTextBox(mEntidad.Descuento.Porcentaje)
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

    Private Sub PrecioUnitario_TextChanged() Handles textboxPrecioUnitario.TextChanged
        CalcularDescuento()
    End Sub

    Private Sub CalcularDescuento() Handles textboxPrecioUnitarioDescuentoPorcentaje.TextChanged
        If Not mCambiandoDescuento Then
            If CS_ValueTranslation.ValidateCurrency(textboxPrecioUnitario.Text) Then
                If CS_ValueTranslation.ValidateDecimal(textboxPrecioUnitarioDescuentoPorcentaje.Text) Then
                    textboxPrecioUnitarioDescuentoImporte.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitario.Text) * CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitarioDescuentoPorcentaje.Text) / 100)
                    PrecioUnitarioDescuentoImporte_TextChanged()
                End If
            End If
        End If
    End Sub

    Private Sub PrecioUnitarioDescuentoImporte_KeyPressed() Handles textboxPrecioUnitarioDescuentoImporte.KeyPress
        mCambiandoDescuento = True
        textboxPrecioUnitarioDescuentoPorcentaje.Text = "0"
        mCambiandoDescuento = False
    End Sub

    Private Sub PrecioUnitarioDescuentoImporte_TextChanged() Handles textboxPrecioUnitarioDescuentoImporte.TextChanged
        If CS_ValueTranslation.ValidateCurrency(textboxPrecioUnitario.Text) Then
            If CS_ValueTranslation.ValidateCurrency(textboxPrecioUnitarioDescuentoImporte.Text) AndAlso CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitarioDescuentoImporte.Text) > 0 Then
                textboxPrecioUnitarioFinal.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitario.Text) - CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitarioDescuentoImporte.Text))
            Else
                textboxPrecioUnitarioFinal.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitario.Text))
            End If
        End If
        CalcularPrecioFinal()
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxCantidad.GotFocus, textboxUnidad.GotFocus, textboxDescripcion.GotFocus, textboxPrecioUnitario.GotFocus, textboxPrecioUnitarioDescuentoPorcentaje.GotFocus, textboxPrecioUnitarioDescuentoImporte.GotFocus, textboxPrecioUnitarioFinal.GotFocus, textboxPrecioTotal.GotFocus
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

        If textboxCantidad.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar la Cantidad.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxCantidad.Focus()
            Exit Sub
        End If
        If Not CS_ValueTranslation.ValidateDecimal(textboxCantidad.Text) Then
            MsgBox("La Cantidad ingresada no es válida.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxCantidad.Focus()
            Exit Sub
        End If
        If CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxCantidad.Text).Value <= 0 Then
            MsgBox("La Cantidad debe ser mayor a cero.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxCantidad.Focus()
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

        If textboxPrecioUnitario.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar el Importe.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxPrecioUnitario.Focus()
            Exit Sub
        End If
        If Not CS_ValueTranslation.ValidateCurrency(textboxPrecioUnitario.Text) Then
            MsgBox("El Importe ingresado no es válido.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxPrecioUnitario.Focus()
            Exit Sub
        End If

        '##########################################
        ' Update by: Tomas Cardoner
        ' Date: 13/03/2016
        ' Description: Commented for no cero checking to allow a General discount item without amount, and only applied in discount field
        'If CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitario.Text).Value <= 0 Then
        '    MsgBox("El Importe debe ser mayor a cero.", MsgBoxStyle.Information, My.Application.Info.Title)
        '    textboxPrecioUnitario.Focus()
        '    Exit Sub
        'End If
        '##########################################

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
        If CS_Form.MDIChild_IsLoaded(CType(formMDIMain, Form), "formComprobante") Then
            Dim formComprobante As formComprobante = CType(CS_Form.MDIChild_GetInstance(CType(formMDIMain, Form), "formComprobante"), formComprobante)
            formComprobante.RefreshData_Detalle(mComprobanteDetalleActual.Indice)
            formComprobante = Nothing
        End If

        Me.Close()
    End Sub

#End Region

End Class