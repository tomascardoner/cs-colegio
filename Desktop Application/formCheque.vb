Public Class formCheque

#Region "Declarations"
    Private mdbContext As CSColegioContext
    Private mComprobanteActual As Comprobante
    Private mComprobanteMedioPagoActual As ComprobanteMedioPago

    Private mEditMode As Boolean = False
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByVal ParentEditMode As Boolean, ByVal EditMode As Boolean, ByRef ParentForm As Form, ByRef dbContext As CSColegioContext, ByRef ComprobanteActual As Comprobante, ByRef ComprobanteMedioPagoActual As ComprobanteMedioPago)
        mEditMode = EditMode

        mdbContext = dbContext
        mComprobanteActual = ComprobanteActual
        mComprobanteMedioPagoActual = ComprobanteMedioPagoActual

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
        buttonEditar.Visible = Not mEditMode
        buttonCerrar.Visible = Not mEditMode

        labelEstado.Visible = False
        textboxEstado.Visible = False
        labelMotivoRechazo.Visible = False
        comboboxMotivoRechazo.Visible = False

        CS_Form.ControlsChangeStateEnabled(Me.Controls, mEditMode, True, True, True, toolstripMain.Name)
    End Sub

    Friend Sub InitializeFormAndControls()
        ' Cargo los ComboBox
        pFillAndRefreshLists.MedioPago(comboboxMedioPago, False, True, False)
        pFillAndRefreshLists.Banco(comboboxBanco, False)
        pFillAndRefreshLists.ChequeMotivoRechazo(comboboxMotivoRechazo, True, False)
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mComprobanteActual = Nothing
        mComprobanteMedioPagoActual = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub SetDataFromObjectToControls()
        With mComprobanteMedioPagoActual
            CS_ComboBox.SetSelectedValue(comboboxMedioPago, SelectedItemOptions.ValueOrFirstIfUnique, .IDMedioPago, CByte(0))
            CS_ComboBox.SetSelectedValue(comboboxCaja, SelectedItemOptions.ValueOrFirstIfUnique, .IDCaja, CByte(0))
        End With
        With mComprobanteMedioPagoActual.Cheque
            If .IDCheque = 0 Then
                textboxIDCheque.Text = My.Resources.STRING_ITEM_NEW_MALE
            Else
                textboxIDCheque.Text = String.Format(.IDCheque.ToString, "G")
            End If
            CS_ComboBox.SetSelectedValue(comboboxBanco, SelectedItemOptions.Value, .IDBanco, CShort(0))
            datetimepickerFechaEmision.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaEmision)
            datetimepickerFechaPago.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaPago)
            textboxNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Numero)
            currencytextboxImporte.DecimalValue = .Importe
            textboxCuenta.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Cuenta)
            maskedtextboxCUIT.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.CUIT)
            textboxTitular.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Titular)
            textboxCodigoPostal.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.CodigoPostal)

            'textboxEstado.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Estado)
            CS_ComboBox.SetSelectedValue(comboboxMotivoRechazo, SelectedItemOptions.Value, .IDChequeMotivoRechazo, CShort(0))
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mComprobanteMedioPagoActual
            .IDMedioPago = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxMedioPago.SelectedValue, 0).Value
            .Numero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNumero.Text)
            .IDBanco = CS_ValueTranslation.FromControlComboBoxToObjectShort(comboboxBanco.SelectedValue, 0).Value
            .Cuenta = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxCuenta.Text)
            .Titular = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTitular.Text)
            .IDCaja = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxCaja.SelectedValue, 0).Value
            .Importe = currencytextboxImporte.DecimalValue
        End With
        With mComprobanteMedioPagoActual.Cheque
            .IDBanco = CS_ValueTranslation.FromControlComboBoxToObjectShort(comboboxBanco.SelectedValue, 0).Value
            .FechaEmision = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaEmision.Value)
            .FechaPago = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFechaPago.Value)
            .Numero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNumero.Text)
            .Importe = currencytextboxImporte.DecimalValue
            .Cuenta = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxCuenta.Text)
            .CUIT = CS_ValueTranslation.FromControlTextBoxToObjectString(maskedtextboxCUIT.Text)
            .Titular = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxTitular.Text)
            .CodigoPostal = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxCodigoPostal.Text)

            '.Estado= CS_ValueTranslation.FromControlTextBoxToObjectString(textboxCuenta.Text)
            '.IDChequeMotivoRechazo = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxMotivoRechazo.SelectedValue, 0).Value
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

    Private Sub MedioPago_Selected() Handles comboboxMedioPago.SelectedValueChanged
        If comboboxMedioPago.SelectedIndex > -1 Then
            pFillAndRefreshLists.Caja(comboboxCaja, CByte(comboboxMedioPago.SelectedValue), False)
        Else
            comboboxCaja.DataSource = Nothing
        End If
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxNumero.GotFocus, textboxCuenta.GotFocus
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
        If comboboxBanco.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Banco.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxBanco.Focus()
            Exit Sub
        End If

        If datetimepickerFechaPago.Value.CompareTo(datetimepickerFechaEmision.Value) < 0 Then
            MsgBox("La Fecha de Pago, debe ser posterior o igual a la Fecha de Emisión.", MsgBoxStyle.Information, My.Application.Info.Title)
            datetimepickerFechaPago.Focus()
            Exit Sub
        End If

        If currencytextboxImporte.DecimalValue = 0 Then
            MsgBox("Debe ingresar el Importe del Cheque.", MsgBoxStyle.Information, My.Application.Info.Title)
            currencytextboxImporte.Focus()
            Exit Sub
        End If

        ' Si es un nuevo cheque...
        If mComprobanteMedioPagoActual.Cheque.IDCheque = 0 Then
            Dim IDChequeMaxEnObjeto As Integer
            Dim IDChequeMaxEnBaseDatos As Integer

            mComprobanteMedioPagoActual.Cheque.Estado = Constantes.CHEQUE_ESTADO_ENCARTERA
            ' Obtengo el máximo ID en la base de datos
            If mdbContext.Cheque.Count = 0 Then
                ' No hay ningún cheque cargado aún en la base de datos
                IDChequeMaxEnBaseDatos = 0
            Else
                ' Hay cheques en la base de datos
                IDChequeMaxEnBaseDatos = mdbContext.Cheque.Max(Function(chq) chq.IDCheque)
            End If
            ' Obtengo el máximo ID en los Medios de Pago del Comprobante actual
            If mComprobanteActual.ComprobanteMedioPago.Where(Function(cmp) cmp.IDCheque.HasValue).Count = 0 Then
                ' No hay ningún cheque cargado en los Medios de Pago del Comprobante actual
                IDChequeMaxEnObjeto = 0
            Else
                ' Ya hay algún cheque cargado en los Medios de Pago del Comprobante actual
                IDChequeMaxEnObjeto = mComprobanteActual.ComprobanteMedioPago.Where(Function(cmp) cmp.IDCheque.HasValue).Max(Function(cmp) cmp.Cheque.IDCheque)
            End If
            ' Asigno el ID que corresponda
            If IDChequeMaxEnObjeto > IDChequeMaxEnBaseDatos Then
                mComprobanteMedioPagoActual.Cheque.IDCheque = IDChequeMaxEnObjeto + CInt(1)
            Else
                mComprobanteMedioPagoActual.Cheque.IDCheque = IDChequeMaxEnBaseDatos + CInt(1)
            End If
            mComprobanteMedioPagoActual.IDCheque = mComprobanteMedioPagoActual.Cheque.IDCheque
        End If
        ' Si es un nuevo item, busco el próximo Indice y agrego el objeto nuevo a la colección del parent
        If mComprobanteMedioPagoActual.Indice = 0 Then
            If mComprobanteActual.ComprobanteMedioPago.Count = 0 Then
                mComprobanteMedioPagoActual.Indice = 1
            Else
                mComprobanteMedioPagoActual.Indice = mComprobanteActual.ComprobanteMedioPago.Max(Function(cmp) cmp.Indice) + CByte(1)
            End If
            mComprobanteActual.ComprobanteMedioPago.Add(mComprobanteMedioPagoActual)
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        ' Refresco la lista para mostrar los cambios
        If CS_Form.MDIChild_IsLoaded(CType(formMDIMain, Form), "formComprobante") Then
            Dim formComprobante As formComprobante = CType(CS_Form.MDIChild_GetInstance(CType(formMDIMain, Form), "formComprobante"), formComprobante)
            formComprobante.RefreshData_MediosPago(mComprobanteMedioPagoActual.Indice)
            formComprobante = Nothing
        End If

        Me.Close()
    End Sub
#End Region

End Class