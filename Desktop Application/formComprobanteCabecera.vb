Public Class formComprobanteCabecera

    Private Sub formComprobanteCabecera_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Cargo los ComboBox
        FillAndRefreshLists.ComprobanteTipo(comboboxComprobanteTipo, OPERACIONTIPO_VENTA, False)

        FillAndRefreshLists.CategoriaIVA(comboboxCategoriaIVA, False)
        CSM_ComboBox.SetSelectedValue(comboboxCategoriaIVA, SelectedItemOptions.ValueOrFirst, CSM_Parameter.GetIntegerAsByte(Constants.PARAMETRO_CATEGORIAIVA_PREDETERMINADA, 0))

        FillAndRefreshLists.Provincia(comboboxDomicilioProvincia, False)
        CSM_ComboBox.SetSelectedValue(comboboxDomicilioProvincia, SelectedItemOptions.ValueOrFirst, CSM_Parameter.GetString(Constants.PARAMETRO_PROVINCIA_PREDETERMINADA))

        CSM_ComboBox.SetSelectedValue(comboboxDomicilioLocalidad, SelectedItemOptions.ValueOrFirst, CSM_Parameter.GetIntegerAsShort(Constants.PARAMETRO_LOCALIDAD_PREDETERMINADA))
    End Sub

    Private Sub comboboxDomicilioProvincia_SelectedIndexChanged() Handles comboboxDomicilioProvincia.SelectedIndexChanged
        If comboboxDomicilioProvincia.SelectedValue Is Nothing Then
            comboboxDomicilioLocalidad.Items.Clear()
        Else
            FillAndRefreshLists.Localidad(comboboxDomicilioLocalidad, CByte(comboboxDomicilioProvincia.SelectedValue), False)
        End If
    End Sub

    Private Sub comboboxDomicilioLocalidad_SelectedIndexChanged() Handles comboboxDomicilioLocalidad.SelectedIndexChanged
        If Not comboboxDomicilioLocalidad.SelectedItem Is Nothing Then
            textboxDomicilioCodigoPostal.Text = CType(comboboxDomicilioLocalidad.SelectedItem, Localidad).CodigoPostal
        End If
    End Sub
End Class