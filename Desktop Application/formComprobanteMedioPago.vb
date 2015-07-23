Public Class formComprobanteMedioPago

#Region "Declarations"
    Private mMedioPagoCurrent As MedioPago
    Private mComprobanteCurrent As Comprobante
    Private mComprobanteMedioPagoCurrent As ComprobanteMedioPago

    Private mEditMode As Boolean = False
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByVal ParentEditMode As Boolean, ByVal EditMode As Boolean, ByRef ParentForm As Form, ByRef ComprobanteCurrent As Comprobante, ByRef ComprobanteMedioPagoCurrent As ComprobanteMedioPago)


        mEditMode = EditMode

        mComprobanteCurrent = ComprobanteCurrent
        mComprobanteMedioPagoCurrent = ComprobanteMedioPagoCurrent

        Me.MdiParent = formMDIMain
        CS_Form.CenterToParent(ParentForm, Me)
        ChangeMode()
        buttonEditar.Visible = (ParentEditMode And Not mEditMode)
        InitializeFormAndControls()
        SetDataFromObjectToControls()
        Me.Show()
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
        End If
        Me.Focus()
    End Sub

    Private Sub ChangeMode()
        buttonGuardar.Visible = mEditMode
        buttonCancelar.Visible = mEditMode
        buttonEditar.Visible = Not mEditMode
        buttonCerrar.Visible = Not mEditMode

        CS_Form.ControlsChangeStateEnabled(Me.Controls, mEditMode, True, True, True, toolstripMain.Name)
    End Sub

    Friend Sub InitializeFormAndControls()
        ' Cargo los ComboBox
        pFillAndRefreshLists.MedioPago(comboboxMedioPago, False)
        pFillAndRefreshLists.Banco(comboboxBanco, False)
    End Sub

    Private Sub formEntidad_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mComprobanteCurrent = Nothing
        mComprobanteMedioPagoCurrent = Nothing
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub SetDataFromObjectToControls()
        With mComprobanteMedioPagoCurrent
            CS_Control_ComboBox.SetSelectedValue(comboboxMedioPago, SelectedItemOptions.Value, .IDMedioPago, CByte(0))

            If mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEPOSITOBANCARIO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITODIRECTO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITOAUTOMATICO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_TRANSFERENCIABANCARIA Then
                datetimepickerFecha.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaHora)
                textboxNumero.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Numero)
                CS_Control_ComboBox.SetSelectedValue(comboboxBanco, SelectedItemOptions.Value, .IDBanco, CShort(0))
            Else
                datetimepickerFecha.Value = DateTime.Today
                datetimepickerHora.Value = DateTime.Now
            End If

            CS_Control_ComboBox.SetSelectedValue(comboboxCaja, SelectedItemOptions.Value, .IDCaja, CByte(0))

            If mMedioPagoCurrent.Tipo <> Constantes.MEDIOPAGO_TIPO_CHEQUE Then
                textboxImporte.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.Importe)
            End If
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mComprobanteMedioPagoCurrent
            .IDMedioPago = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxMedioPago.SelectedValue, 0).Value

            If mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEPOSITOBANCARIO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITODIRECTO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITOAUTOMATICO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_TRANSFERENCIABANCARIA Then
                .FechaHora = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(datetimepickerFecha.Value)
                .Numero = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNumero.Text)
                .IDBanco = CS_ValueTranslation.FromControlComboBoxToObjectShort(comboboxBanco.SelectedValue, 0).Value
            Else
                .FechaHora = Nothing
                .Numero = Nothing
                .IDBanco = Nothing
            End If

            .IDCaja = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxCaja.SelectedValue, 0).Value

            If mMedioPagoCurrent.Tipo <> Constantes.MEDIOPAGO_TIPO_CHEQUE Then
                .Importe = CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxImporte.Text).Value
            End If
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
            mMedioPagoCurrent = CType(comboboxMedioPago.SelectedItem, MedioPago)

            labelFechaHora.Visible = (mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEPOSITOBANCARIO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITODIRECTO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITOAUTOMATICO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_TRANSFERENCIABANCARIA)
            datetimepickerFecha.Visible = (mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEPOSITOBANCARIO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITODIRECTO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITOAUTOMATICO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_TRANSFERENCIABANCARIA)
            datetimepickerHora.Visible = (mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEPOSITOBANCARIO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITODIRECTO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITOAUTOMATICO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_TRANSFERENCIABANCARIA)

            labelNumero.Visible = (mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEPOSITOBANCARIO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITODIRECTO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITOAUTOMATICO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_TRANSFERENCIABANCARIA)
            textboxNumero.Visible = (mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEPOSITOBANCARIO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITODIRECTO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITOAUTOMATICO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_TRANSFERENCIABANCARIA)

            labelBanco.Visible = (mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEPOSITOBANCARIO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITODIRECTO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITOAUTOMATICO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_TRANSFERENCIABANCARIA)
            comboboxBanco.Visible = (mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEPOSITOBANCARIO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITODIRECTO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_DEBITOAUTOMATICO Or mMedioPagoCurrent.Tipo = Constantes.MEDIOPAGO_TIPO_TRANSFERENCIABANCARIA)

            labelImporte.Visible = (mMedioPagoCurrent.Tipo <> Constantes.MEDIOPAGO_TIPO_CHEQUE)
            textboxImporte.Visible = (mMedioPagoCurrent.Tipo <> Constantes.MEDIOPAGO_TIPO_CHEQUE)

            'pFillAndRefreshLists.Caja(comboboxCaja, CByte(comboboxMedioPago.SelectedValue), False)
            pFillAndRefreshLists.Caja(comboboxCaja, Nothing, False)
        End If
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxNumero.GotFocus
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
        If comboboxMedioPago.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Medio de Pago.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxMedioPago.Focus()
            Exit Sub
        End If
        If comboboxCaja.SelectedIndex = -1 Then
            MsgBox("Debe especificar la Caja.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxCaja.Focus()
            Exit Sub
        End If
        If textboxImporte.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar el Importe.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxImporte.Focus()
            Exit Sub
        End If
        If Not CS_ValueTranslation.ValidateCurrency(textboxImporte.Text) Then
            MsgBox("El Importe ingresado no es válido.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxImporte.Focus()
            Exit Sub
        End If

        ' Si es un nuevo item, busco el próximo Indice y agrego el objeto nuevo a la colección del parent
        If mComprobanteMedioPagoCurrent.Indice = 0 Then
            If mComprobanteCurrent.ComprobanteMedioPago.Count = 0 Then
                mComprobanteMedioPagoCurrent.Indice = 1
            Else
                mComprobanteMedioPagoCurrent.Indice = mComprobanteCurrent.ComprobanteMedioPago.Max(Function(cmp) cmp.Indice) + CByte(1)
            End If
            mComprobanteCurrent.ComprobanteMedioPago.Add(mComprobanteMedioPagoCurrent)
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        ' Refresco la lista de Entidades para mostrar los cambios
        If CS_Form.MDIChild_IsLoaded(CType(formMDIMain, Form), "formComprobante") Then
            Dim formComprobante As formComprobante = CType(CS_Form.MDIChild_GetInstance(CType(formMDIMain, Form), "formComprobante"), formComprobante)
            formComprobante.RefreshData_MediosPago(mComprobanteMedioPagoCurrent.Indice)
            formComprobante = Nothing
        End If

        Me.Close()
    End Sub
#End Region

End Class