Public Class formReportesParametro
    Private mParametroActual As ReporteParametro

    Friend Sub SetAppearance(ByRef ParametroActual As ReporteParametro, ByVal Title As String)
        Me.Text = Title

        mParametroActual = ParametroActual

        integertextboxNumber.Visible = (mParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_TIPO_NUMBER_INTEGER)
        doubletextboxNumber.Visible = (mParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_TIPO_NUMBER_DECIMAL)
        currencytextboxMoney.Visible = (mParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_TIPO_MONEY)
        datetimepickerValor.Visible = (mParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_TIPO_DATE Or mParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_TIPO_DATETIME)
        comboboxValues.Visible = (mParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_TIPO_YEAR Or mParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_TIPO_MONTH)


        Select Case mParametroActual.Tipo
            Case Constantes.REPORTE_PARAMETRO_TIPO_NUMBER_INTEGER, Constantes.REPORTE_PARAMETRO_TIPO_NUMBER_DECIMAL
                If Not mParametroActual.Valor Is Nothing Then
                    doubletextboxNumber.Text = CStr(mParametroActual.Valor)
                End If
            Case Constantes.REPORTE_PARAMETRO_TIPO_MONEY
                If Not mParametroActual.Valor Is Nothing Then
                    currencytextboxMoney.Text = CStr(mParametroActual.Valor)
                End If
            Case Constantes.REPORTE_PARAMETRO_TIPO_DATE
                If Not mParametroActual.Valor Is Nothing Then
                    datetimepickerValor.Value = CDate(mParametroActual.Valor)
                End If
            Case Constantes.REPORTE_PARAMETRO_TIPO_YEAR
                pFillAndRefreshLists.AnioLectivo(comboboxValues, False, SortOrder.Descending)
                If Not mParametroActual.Valor Is Nothing Then
                    CardonerSistemas.ComboBox.SetSelectedValue(comboboxValues, CardonerSistemas.ComboBox.SelectedItemOptions.ValueOrFirstIfUnique, mParametroActual.Valor)
                End If
            Case Constantes.REPORTE_PARAMETRO_TIPO_MONTH
                pFillAndRefreshLists.Mes(comboboxValues, True, False, True, False, False)
                If Not mParametroActual.Valor Is Nothing Then
                    comboboxValues.SelectedIndex = CInt(mParametroActual.Valor) - 1
                End If
        End Select
    End Sub

    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles buttonAceptar.Click
        Select Case mParametroActual.Tipo
            Case Constantes.REPORTE_PARAMETRO_TIPO_NUMBER_INTEGER, Constantes.REPORTE_PARAMETRO_TIPO_NUMBER_DECIMAL
                mParametroActual.Valor = doubletextboxNumber.DoubleValue
            Case Constantes.REPORTE_PARAMETRO_TIPO_MONEY
                mParametroActual.Valor = currencytextboxMoney.DecimalValue
            Case Constantes.REPORTE_PARAMETRO_TIPO_DATE
                mParametroActual.Valor = datetimepickerValor.Value
            Case Constantes.REPORTE_PARAMETRO_TIPO_YEAR
                If comboboxValues.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Año.", MsgBoxStyle.Information, My.Application.Info.Title)
                    comboboxValues.Focus()
                    Exit Sub
                End If
                mParametroActual.Valor = comboboxValues.Text
            Case Constantes.REPORTE_PARAMETRO_TIPO_MONTH
                If comboboxValues.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Mes.", MsgBoxStyle.Information, My.Application.Info.Title)
                    comboboxValues.Focus()
                    Exit Sub
                End If
                mParametroActual.Valor = comboboxValues.SelectedIndex + 1
        End Select

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub Cancelar_Click(sender As Object, e As EventArgs) Handles buttonCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mParametroActual = Nothing
    End Sub
End Class