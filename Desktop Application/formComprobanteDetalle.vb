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
        buttonEntidad.Enabled = mEditMode
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
                If Not .Entidad Is Nothing Then
                    textboxEntidad.Text = .Entidad.ApellidoNombre
                    textboxEntidad.Tag = .Entidad.IDEntidad
                End If
                CS_Control_ComboBox.SetSelectedValue(comboboxAnioLectivoCurso, SelectedItemOptions.Value, .IDAnioLectivoCurso, CShort(0))
            Else
                textboxEntidad.Text = ""
                textboxEntidad.Tag = Nothing
                comboboxAnioLectivoCurso.SelectedIndex = -1
            End If
            If (Not mArticuloActual Is Nothing) AndAlso mArticuloActual.IDArticulo = mIDArticuloMensual Then
                If .CuotaMes.HasValue Then
                    comboboxCuotaMes.SelectedIndex = .CuotaMes.Value
                Else
                    comboboxCuotaMes.SelectedIndex = 0
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
            .Descripcion = CS_ValueTranslation.FromControlComboBoxToObjectString(textboxDescripcion.Text)

            If mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual Then
                .IDEntidad = CS_ValueTranslation.FromControlTagToObjectInteger(textboxEntidad.Tag)
                .IDAnioLectivoCurso = CS_ValueTranslation.FromControlComboBoxToObjectShort(comboboxAnioLectivoCurso.SelectedValue)
            Else
                .IDEntidad = Nothing
                .IDAnioLectivoCurso = Nothing
            End If
            If mArticuloActual.IDArticulo = mIDArticuloMensual Then
                .CuotaMes = CByte(IIf(comboboxCuotaMes.SelectedIndex = 0, Nothing, comboboxCuotaMes.SelectedIndex))
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

    Private Sub Entidad_Click(sender As Object, e As EventArgs) Handles buttonEntidad.Click
        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = True
        formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Using dbContext As New CSColegioContext(True)
                mEntidad = dbContext.Entidad.Find(CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad).IDEntidad)
                If Not mEntidad.IDDescuento Is Nothing Then
                    mEntidad.Descuento.ToString()
                End If
            End Using
            textboxEntidad.Tag = mEntidad.IDEntidad
            textboxEntidad.Text = mEntidad.ApellidoNombre
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
    End Sub

    Private Sub PrecioUnitario_TextChanged() Handles textboxPrecioUnitario.TextChanged
        CalcularDescuento()
    End Sub

    Private Sub CalcularDescuento() Handles textboxPrecioUnitarioDescuentoPorcentaje.TextChanged
        If Not mCambiandoDescuento Then
            If CS_ValueTranslation.ValidateCurrency(textboxPrecioUnitario.Text) Then
                If CS_ValueTranslation.ValidateDecimal(textboxPrecioUnitarioDescuentoPorcentaje.Text) Then
                    textboxPrecioUnitarioDescuentoImporte.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitario.Text) * CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitarioDescuentoPorcentaje.Text) / 100)
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
            If textboxEntidad.Tag Is Nothing Then
                MsgBox("Debe especificar el Alumno.", MsgBoxStyle.Information, My.Application.Info.Title)
                buttonEntidad.Focus()
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
        If CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxPrecioUnitario.Text).Value <= 0 Then
            MsgBox("El Importe debe ser mayor a cero.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxPrecioUnitario.Focus()
            Exit Sub
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
        If CS_Form.MDIChild_IsLoaded(CType(formMDIMain, Form), "formComprobante") Then
            Dim formComprobante As formComprobante = CType(CS_Form.MDIChild_GetInstance(CType(formMDIMain, Form), "formComprobante"), formComprobante)
            formComprobante.RefreshData_Detalle(mComprobanteDetalleActual.Indice)
            formComprobante = Nothing
        End If

        Me.Close()
    End Sub

#End Region

#Region "Extra stuff"
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

            labelEntidad.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            textboxEntidad.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            buttonEntidad.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)

            labelAnioLectivoCurso.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)
            comboboxAnioLectivoCurso.Visible = (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual)

            labelCuotaMes.Visible = (mArticuloActual.IDArticulo = mIDArticuloMensual)
            comboboxCuotaMes.Visible = (mArticuloActual.IDArticulo = mIDArticuloMensual)
        Else
            textboxCantidad.ReadOnly = True
            textboxUnidad.ReadOnly = True

            labelDescripcion.Visible = False
            textboxDescripcion.Visible = False

            labelEntidad.Visible = False
            textboxEntidad.Visible = False
            buttonEntidad.Visible = False

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
                pFillAndRefreshLists.AnioLectivoCurso(comboboxAnioLectivoCurso, Today.Year, Today.Year + 1, mEntidad.IDEntidad)
            ElseIf mArticuloActual.IDArticulo = mIDArticuloMensual Then
                pFillAndRefreshLists.AnioLectivoCurso(comboboxAnioLectivoCurso, Today.Year, Today.Year, mEntidad.IDEntidad)
            End If
        End If
    End Sub

    Private Sub EstablecerDescripcion()
        If (Not mArticuloActual Is Nothing) AndAlso (mArticuloActual.IDArticulo = mIDArticuloMatricula Or mArticuloActual.IDArticulo = mIDArticuloMensual) And (Not mEntidad Is Nothing) And (Not comboboxAnioLectivoCurso.SelectedItem Is Nothing) And comboboxCuotaMes.SelectedIndex > -1 Then
            textboxDescripcion.Text = String.Format(mArticuloActual.Descripcion, vbCrLf, mArticuloActual.Nombre, mEntidad.IDEntidad, mEntidad.Apellido, mEntidad.Nombre, mEntidad.ApellidoNombre, CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCurso_ListItem).AnioLectivo, comboboxCuotaMes.Text)
        Else
            textboxDescripcion.Text = ""
        End If
    End Sub

    Private Sub EstablecerPrecioUnitario()
        Dim PrecioUnitario As Decimal

        If (Not mArticuloActual Is Nothing) AndAlso (Not textboxEntidad.Tag Is Nothing) AndAlso (Not comboboxAnioLectivoCurso.SelectedItem Is Nothing) Then
            If mArticuloActual.IDArticulo = mIDArticuloMatricula Then
                PrecioUnitario = CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCurso_ListItem).ImporteMatricula
            ElseIf mArticuloActual.IDArticulo = mIDArticuloMensual Then
                PrecioUnitario = CType(comboboxAnioLectivoCurso.SelectedItem, FillAndRefreshLists.AnioLectivoCurso_ListItem).ImporteCuota
            End If
            textboxPrecioUnitario.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(PrecioUnitario)
            If Not mEntidad.IDDescuento Is Nothing Then
                textboxPrecioUnitarioDescuentoPorcentaje.Text = CS_ValueTranslation.FromObjectPercentToControlTextBox(mEntidad.Descuento.Porcentaje)
            End If
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

End Class