Public Class formComprobanteDetalleAgregarMultiple

#Region "Declarations"
    Private mComprobanteActual As Comprobante
    Private mArticuloActual As Articulo
    Private mEntidad As Entidad

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

        'Me.MdiParent = pFormMDIMain
        CS_Form.CenterToParent(ParentForm, Me)
        InitializeFormAndControls()
        SetDataFromObjectToControls()

        Me.ShowDialog(ParentForm)
        'If Me.WindowState = FormWindowState.Minimized Then
        '    Me.WindowState = FormWindowState.Normal
        'End If
        'Me.Focus()
    End Sub

    Friend Sub InitializeFormAndControls()
        Using dbContext As New CSColegioContext(True)
            mArticuloActual = dbContext.Articulo.Find(CS_Parameter_System.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_ARTICULO_ID))
        End Using

        For MesNumero As Integer = 1 To 12
            comboboxCuotaMesDesde.Items.Add(StrConv(MonthName(MesNumero), VbStrConv.ProperCase))
            comboboxCuotaMesHasta.Items.Add(StrConv(MonthName(MesNumero), VbStrConv.ProperCase))
        Next
    End Sub

    Private Sub FormEnd(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mComprobanteActual = Nothing
        mArticuloActual = Nothing
        mEntidad = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Load and Set Data"
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

    Friend Sub SetDataFromControlsToObject(ByRef ComprobanteDetalleActual As ComprobanteDetalle, ByVal CuotaMes As Byte)
        With ComprobanteDetalleActual
            .IDArticulo = mArticuloActual.IDArticulo
            .Cantidad = 1
            .Unidad = Nothing

            .IDEntidad = CS_ValueTranslation.FromControlComboBoxToObjectInteger(comboboxAlumno.SelectedValue)
            .IDAnioLectivoCurso = CS_ValueTranslation.FromControlComboBoxToObjectShort(comboboxAnioLectivoCurso.SelectedValue)

            .Descripcion = String.Format(mArticuloActual.Descripcion, vbCrLf, mArticuloActual.Nombre, mEntidad.IDEntidad, mEntidad.Apellido, mEntidad.Nombre, mEntidad.ApellidoNombre, CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCurso_ListItem).AnioLectivo, StrConv(MonthName(CuotaMes), VbStrConv.ProperCase))

            .CuotaMes = CByte(IIf(comboboxCuotaMesDesde.SelectedIndex = -1, Nothing, comboboxCuotaMesDesde.SelectedIndex + 1))

            .PrecioUnitario = currencytextboxPrecioUnitario.DecimalValue
            .PrecioUnitarioDescuentoPorcentaje = Convert.ToDecimal(percenttextboxPrecioUnitarioDescuentoPorcentaje.DoubleValue)
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
                           Where e.EsActivo AndAlso e.TipoAlumno AndAlso (((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_PADRE Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) And e.IDEntidadPadre = IDEntidadPadre) Or ((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_MADRE Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) And e.IDEntidadMadre = IDEntidadPadre) Or ((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) And e.IDEntidadTercero = IDEntidadPadre))
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
        Dim AnioLectivoCursoActual As AnioLectivoCurso
        Dim AnioLectivoCursoImporteActual As AnioLectivoCursoImporte
        Dim PrecioUnitario As Decimal

        If (Not mArticuloActual Is Nothing) AndAlso (Not comboboxAlumno.SelectedIndex = -1) AndAlso (Not comboboxAnioLectivoCurso.SelectedItem Is Nothing) Then
            ' CUOTA MENSUAL
            If comboboxCuotaMesDesde.SelectedIndex > -1 Then
                Using dbContext As New CSColegioContext(True)
                    AnioLectivoCursoActual = dbContext.AnioLectivoCurso.Find(CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCurso_ListItem).IDAnioLectivoCurso)
                    AnioLectivoCursoImporteActual = AnioLectivoCursoActual.AnioLectivoCursoImporte.Where(Function(alci) alci.MesInicio <= CByte(comboboxCuotaMesDesde.SelectedIndex + 1)).OrderByDescending(Function(alci) alci.MesInicio).FirstOrDefault
                End Using
                If Not AnioLectivoCursoImporteActual Is Nothing Then
                    PrecioUnitario = AnioLectivoCursoImporteActual.ImporteCuota
                End If
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
                If mEntidad.IDDescuento Is Nothing Then
                    percenttextboxPrecioUnitarioDescuentoPorcentaje.DoubleValue = 0
                    'textboxPrecioUnitarioDescuentoImporte.Text = "0"
                Else
                    percenttextboxPrecioUnitarioDescuentoPorcentaje.DoubleValue = mEntidad.Descuento.Porcentaje / 100
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
    Private Sub buttonCerrarOCancelar_Click() Handles buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonGuardar_Click() Handles buttonGuardar.Click

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
            SetDataFromControlsToObject(ComprobanteDetalleActual, CByte(Indice))
        Next Indice

        ' Refresco la lista para mostrar los cambios
        If CS_Form.MDIChild_IsLoaded(CType(pFormMDIMain, Form), "formComprobante") Then
            Dim formComprobante As formComprobante = CType(CS_Form.MDIChild_GetInstance(CType(pFormMDIMain, Form), "formComprobante"), formComprobante)
            formComprobante.RefreshData_Detalle()
            formComprobante = Nothing
        End If

        Me.Close()
    End Sub

#End Region

End Class