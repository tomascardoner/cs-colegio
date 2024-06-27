Imports System.Data.Entity

Public Class formComprobantes

#Region "Declarations"

    Private Const MaximoNumeroComprobantes As Integer = 2000

    Private WithEvents datetimepickerFechaDesdeHost As ToolStripControlHost
    Private WithEvents datetimepickerFechaHastaHost As ToolStripControlHost

    Private Class GridRowData
        Public Property IDComprobante As Integer
        Public Property OperacionTipo As String
        Public Property IDComprobanteTipo As Byte
        Public Property ComprobanteTipoNombre As String
        Public Property IDComprobanteLote As Integer?
        Public Property NumeroCompleto As String
        Public Property FechaEmision As Date
        Public Property IDEntidad As Integer
        Public Property EntidadNombre As String
        Public Property DocumentoNumero As String
        Public Property ImporteTotal As Decimal
        Public Property CAE As String
        Public Property Anulado As Boolean
    End Class

    Private mlistComprobantesBase As List(Of GridRowData)
    Private mlistComprobantesFiltradaYOrdenada As List(Of GridRowData)

    Private mSkipFilterData As Boolean = False
    Private mReportSelectionFormulaBase As String
    Private mReportSelectionFormula As String

    Private mOrdenColumna As DataGridViewColumn
    Private mOrdenTipo As SortOrder

    Private Const COLUMNA_TIPO As String = "columnTipo"
    Private Const COLUMNA_NUMEROCOMPLETO As String = "columnNumeroCompleto"
    Private Const COLUMNA_FECHA As String = "columnFecha"
    Private Const COLUMNA_TITULAR As String = "columnEntidadNombre"
    Private Const COLUMNA_IMPORTETOTAL As String = "columnImporteTotal"
    Private Const COLUMNA_CAE As String = "columnCAE"

#End Region

#Region "Form stuff"

    Friend Sub SetAppearance()
        datagridviewMain.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont
        toolstripTareas.Visible = (pUsuario.IDUsuarioGrupo = Constantes.USUARIOGRUPO_ADMINISTRADORES_ID)
        ToolStripMenuItemGenerarCodigosQR.Visible = CS_Parameter_System.GetBoolean(Parametros.AFIP_COMPROBANTES_CODIGOQR_GENERAR, False).Value
    End Sub

    Private Sub formComprobantes_Load() Handles Me.Load
        SetAppearance()

        mSkipFilterData = True

        ' Filtro de período
        InicializarFiltroDeFechas()
        CardonerSistemas.DateTime.FillPeriodTypesComboBox(comboboxPeriodoTipo.ComboBox, CardonerSistemas.DateTime.PeriodTypes.Day)

        ' Tipos de Comprobantes
        comboboxOperacionTipo.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, My.Resources.STRING_OPERACIONTIPO_COMPRA, My.Resources.STRING_OPERACIONTIPO_VENTA})
        comboboxOperacionTipo.SelectedIndex = 0

        pFillAndRefreshLists.ComprobanteLote(comboboxComprobanteLote.ComboBox, True, False)

        ' Buscar
        comboboxBuscarTipo.Items.AddRange({"titular:", "número:", "documento:"})
        comboboxBuscarTipo.SelectedIndex = 0

        mSkipFilterData = False

        mOrdenColumna = columnFecha
        mOrdenTipo = SortOrder.Ascending

        RefreshData()
    End Sub

    Private Sub InicializarFiltroDeFechas()
        ' Create a new ToolStripControlHost, passing in a control.
        datetimepickerFechaDesdeHost = New ToolStripControlHost(New DateTimePicker())
        datetimepickerFechaHastaHost = New ToolStripControlHost(New DateTimePicker())

        ' Set the font on the ToolStripControlHost, this will affect the hosted control.
        'dateTimePickerHost.Font = New Font("Arial", 7.0F, FontStyle.Italic)

        ' Set the Width property, this will also affect the hosted control.
        datetimepickerFechaDesdeHost.Width = 100
        datetimepickerFechaDesdeHost.DisplayStyle = ToolStripItemDisplayStyle.Text
        datetimepickerFechaHastaHost.Width = 100
        datetimepickerFechaHastaHost.DisplayStyle = ToolStripItemDisplayStyle.Text

        ' Setting the Text property requires a string that converts to a  
        ' DateTime type since that is what the hosted control requires.
        datetimepickerFechaDesdeHost.Text = DateTime.Today.ToShortDateString
        datetimepickerFechaHastaHost.Text = DateTime.Today.ToShortDateString

        ' Cast the Control property back to the original type to set a  
        ' type-specific property. 
        CType(datetimepickerFechaDesdeHost.Control, DateTimePicker).Format = DateTimePickerFormat.Short
        CType(datetimepickerFechaHastaHost.Control, DateTimePicker).Format = DateTimePickerFormat.Short

        ' Add the control host to the ToolStrip.
        toolstripPeriodo.Items.Insert(3, datetimepickerFechaDesdeHost)
        toolstripPeriodo.Items.Add(datetimepickerFechaHastaHost)

        datetimepickerFechaDesdeHost.Visible = False
        datetimepickerFechaHastaHost.Visible = False
    End Sub

#End Region

#Region "Mostrar y leer datos"

    Friend Sub RefreshData(Optional ByVal PositionIDComprobante As Integer = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)
        Dim FechaDesde As Date
        Dim FechaHasta As Date

        Me.Cursor = Cursors.WaitCursor

        CardonerSistemas.DateTime.GetDatesFromPeriodTypeAndValue(CType(comboboxPeriodoTipo.SelectedIndex, CardonerSistemas.DateTime.PeriodTypes), CByte(comboboxPeriodoValor.SelectedIndex), FechaDesde, FechaHasta, CType(datetimepickerFechaDesdeHost.Control, DateTimePicker).Value, CType(datetimepickerFechaHastaHost.Control, DateTimePicker).Value)

        Try
            mReportSelectionFormulaBase = String.Format("{{Comprobante.FechaEmision}} >= DateTime({0}, {1}, {2}) AndAlso {{Comprobante.FechaEmision}} <= DateTime({3}, {4}, {5})", FechaDesde.Year, FechaDesde.Month, FechaDesde.Day, FechaHasta.Year, FechaHasta.Month, FechaHasta.Day)

            Using dbContext As New CSColegioContext(True)
                mlistComprobantesBase = (From cc In dbContext.Comprobante
                                         Join ct In dbContext.ComprobanteTipo On cc.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                         Where cc.FechaEmision >= FechaDesde AndAlso cc.FechaEmision <= FechaHasta
                                         Order By cc.FechaEmision, cc.IDComprobante
                                         Select New GridRowData With {.IDComprobante = cc.IDComprobante, .OperacionTipo = ct.OperacionTipo, .IDComprobanteTipo = cc.IDComprobanteTipo, .ComprobanteTipoNombre = ct.Nombre, .IDComprobanteLote = cc.IDComprobanteLote, .NumeroCompleto = cc.NumeroCompleto, .FechaEmision = cc.FechaEmision, .IDEntidad = cc.IDEntidad, .EntidadNombre = cc.ApellidoNombre, .DocumentoNumero = cc.DocumentoNumero, .ImporteTotal = cc.ImporteTotal1, .CAE = cc.CAE, .Anulado = cc.IDUsuarioAnulacion IsNot Nothing}).Take(MaximoNumeroComprobantes).ToList
            End Using

        Catch ex As Exception

            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer los Comprobantes.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        Me.Cursor = Cursors.Default

        If RestoreCurrentPosition Then
            If datagridviewMain.CurrentRow Is Nothing Then
                PositionIDComprobante = 0
            Else
                PositionIDComprobante = CType(datagridviewMain.CurrentRow.DataBoundItem, GridRowData).IDComprobante
            End If
        End If

        FilterData()

        If PositionIDComprobante <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewMain.Rows
                If CType(CurrentRowChecked.DataBoundItem, GridRowData).IDComprobante = PositionIDComprobante Then
                    datagridviewMain.CurrentCell = CurrentRowChecked.Cells(0)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub FilterData()

        If Not mSkipFilterData Then
            Me.Cursor = Cursors.WaitCursor

            Try
                ' Filtro inicial por Tipos de Comprobante
                If comboboxOperacionTipo.SelectedIndex = 0 Then
                    ' Todos los tipos de comprobantes
                    mReportSelectionFormula = mReportSelectionFormulaBase
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesBase.ToList
                ElseIf comboboxComprobanteTipo.SelectedIndex = 0 Then
                    ' Todos los comprobantes según la Operación (Compra o Venta)
                    mReportSelectionFormula = mReportSelectionFormulaBase & String.Format(" AndAlso {{ComprobanteTipo.OperacionTipo}} = ""{0}""", Choose(comboboxOperacionTipo.SelectedIndex, Constantes.OPERACIONTIPO_COMPRA, Constantes.OPERACIONTIPO_VENTA).ToString)
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesBase.Where(Function(comp) comp.OperacionTipo = Choose(comboboxOperacionTipo.SelectedIndex, Constantes.OPERACIONTIPO_COMPRA, Constantes.OPERACIONTIPO_VENTA).ToString).ToList
                Else
                    ' Tipo de comprobante seleccionado
                    mReportSelectionFormula = mReportSelectionFormulaBase & String.Format(" AndAlso {{Comprobante.IDComprobanteTipo}} = {0}", CByte(comboboxComprobanteTipo.ComboBox.SelectedValue))
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesBase.Where(Function(comp) comp.IDComprobanteTipo = CByte(comboboxComprobanteTipo.ComboBox.SelectedValue)).ToList
                End If

                ' Aplico el filtro de Lotes, si corresponde
                If comboboxComprobanteLote.SelectedIndex > 0 Then
                    mReportSelectionFormula &= String.Format(" AndAlso {{Comprobante.IDComprobanteLote}} = {0}", CType(comboboxComprobanteLote.SelectedItem, ComprobanteLote).IDComprobanteLote)
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.Where(Function(comp) comp.IDComprobanteLote.HasValue AndAlso comp.IDComprobanteLote.Value = CType(comboboxComprobanteLote.SelectedItem, ComprobanteLote).IDComprobanteLote).ToList
                End If

                ' Si hay una búsqueda aplicada, filtro por eso
                If Not String.IsNullOrWhiteSpace(textboxBuscar.Text) Then
                    Select Case comboboxBuscarTipo.SelectedIndex
                        Case 0
                            ' Búsqueda por Entidad Titular
                            mReportSelectionFormula &= String.Format(" AndAlso InStr(LCase({{Comprobante.ApellidoNombre}}), ""{0}"") > 0", textboxBuscar.Text.ToLower.Trim)
                            mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.Where(Function(comp) comp.EntidadNombre.ToLower().RemoveDiacritics().Contains(textboxBuscar.Text.ToLower().RemoveDiacritics().Trim())).ToList
                        Case 1
                            ' Búsqueda por Número de Comprobante
                            mReportSelectionFormula &= String.Format(" AndAlso InStr({{Comprobante.Numero}}, ""{0}"") > 0", textboxBuscar.Text.Trim)
                            mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.Where(Function(comp) comp.NumeroCompleto.Contains(textboxBuscar.Text.ToLower().Trim())).ToList
                        Case 2
                            ' Búsqueda por Número de Documento del Titular
                            mReportSelectionFormula &= String.Format(" AndAlso InStr({{Comprobante.DocumentoNumero}}, ""{0}"") > 0", textboxBuscar.Text.Trim)
                            mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.Where(Function(comp) comp.DocumentoNumero.ToLower().Contains(textboxBuscar.Text.ToLower().Trim())).ToList
                    End Select
                End If

                ' Entidad
                If textboxEntidad.Tag IsNot Nothing Then
                    mReportSelectionFormula &= String.Format(" AndAlso {{Comprobante.IDEntidad}} = {0}", CInt(textboxEntidad.Tag))
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.Where(Function(comp) comp.IDEntidad = CInt(textboxEntidad.Tag)).ToList
                End If

                Select Case mlistComprobantesFiltradaYOrdenada.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Comprobantes para mostrar.")
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Comprobante.")
                    Case MaximoNumeroComprobantes
                        statuslabelMain.Text = String.Format("Se muestran {0:N0} Comprobantes (limitado a la cantidad máxima permitida).", mlistComprobantesFiltradaYOrdenada.Count)
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0:N0} Comprobantes.", mlistComprobantesFiltradaYOrdenada.Count)
                End Select

            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al filtrar los datos.")
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            OrderData()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub OrderData()
        ' Realizo las rutinas de ordenamiento
        Select Case mOrdenColumna.Name
            Case COLUMNA_TIPO
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenBy(Function(dgrd) dgrd.NumeroCompleto).ToList
                Else
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenBy(Function(dgrd) dgrd.NumeroCompleto).ToList
                End If
            Case COLUMNA_NUMEROCOMPLETO
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.NumeroCompleto).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ToList
                Else
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.NumeroCompleto).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ToList
                End If
            Case COLUMNA_FECHA
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenBy(Function(dgrd) dgrd.NumeroCompleto).ToList
                Else
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenByDescending(Function(dgrd) dgrd.NumeroCompleto).ToList
                End If
            Case COLUMNA_TITULAR
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.EntidadNombre).ThenBy(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenBy(Function(dgrd) dgrd.NumeroCompleto).ToList
                Else
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.EntidadNombre).ThenByDescending(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenByDescending(Function(dgrd) dgrd.NumeroCompleto).ToList
                End If
            Case COLUMNA_IMPORTETOTAL
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.ImporteTotal).ThenBy(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenBy(Function(dgrd) dgrd.NumeroCompleto).ToList
                Else
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.ImporteTotal).ThenByDescending(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenByDescending(Function(dgrd) dgrd.NumeroCompleto).ToList
                End If
            Case COLUMNA_CAE
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.CAE).ThenBy(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenBy(Function(dgrd) dgrd.NumeroCompleto).ToList
                Else
                    mlistComprobantesFiltradaYOrdenada = mlistComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.CAE).ThenByDescending(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenByDescending(Function(dgrd) dgrd.NumeroCompleto).ToList
                End If
        End Select

        datagridviewMain.AutoGenerateColumns = False
        datagridviewMain.DataSource = mlistComprobantesFiltradaYOrdenada

        ' Muestro el ícono de orden en la columna correspondiente
        mOrdenColumna.HeaderCell.SortGlyphDirection = mOrdenTipo
    End Sub
#End Region

#Region "Controls behavior"

    Private Sub PeriodoTipoSeleccionar() Handles comboboxPeriodoTipo.SelectedIndexChanged
        CardonerSistemas.DateTime.FillPeriodValuesComboBox(comboboxPeriodoValor.ComboBox, CType(comboboxPeriodoTipo.SelectedIndex, CardonerSistemas.DateTime.PeriodTypes))
    End Sub

    Private Sub PeriodoValorSeleccionar() Handles comboboxPeriodoValor.SelectedIndexChanged
        datetimepickerFechaDesdeHost.Visible = (comboboxPeriodoTipo.SelectedIndex = CInt(CardonerSistemas.DateTime.PeriodTypes.Range))
        labelPeriodoFechaY.Visible = (comboboxPeriodoTipo.SelectedIndex = CInt(CardonerSistemas.DateTime.PeriodTypes.Range) AndAlso comboboxPeriodoValor.SelectedIndex = CInt(CardonerSistemas.DateTime.PeriodRangeValues.DateBetween))
        datetimepickerFechaHastaHost.Visible = labelPeriodoFechaY.Visible
        RefreshData()
    End Sub

    Private Sub FechaCambiar() Handles datetimepickerFechaDesdeHost.TextChanged, datetimepickerFechaHastaHost.TextChanged
        RefreshData()
    End Sub

    Private Sub comboboxOperacionTipo_SelectedIndexChanged() Handles comboboxOperacionTipo.SelectedIndexChanged
        Select Case comboboxOperacionTipo.SelectedIndex
            Case -1, 0
                comboboxComprobanteTipo.ComboBox.DataSource = Nothing
                comboboxComprobanteTipo.Items.Clear()
                comboboxComprobanteTipo.Enabled = False
            Case 1
                pFillAndRefreshLists.ComprobanteTipo(comboboxComprobanteTipo.ComboBox, OPERACIONTIPO_COMPRA, True, False)
                comboboxComprobanteTipo.Enabled = True
                comboboxComprobanteTipo.SelectedIndex = 0
            Case 2
                pFillAndRefreshLists.ComprobanteTipo(comboboxComprobanteTipo.ComboBox, OPERACIONTIPO_VENTA, True, False)
                comboboxComprobanteTipo.Enabled = True
                comboboxComprobanteTipo.SelectedIndex = 0
        End Select
    End Sub

    Private Sub comboboxComprobanteTipo_SelectedIndexChanged() Handles comboboxComprobanteTipo.SelectedIndexChanged
        FilterData()
    End Sub

    Private Sub comboboxComprobanteLote_SelectedIndexChanged() Handles comboboxComprobanteLote.SelectedIndexChanged
        FilterData()
    End Sub

    Private Sub Entidad_Click() Handles buttonEntidad.Click
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim EntidadSeleccionada As Entidad
            EntidadSeleccionada = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
            textboxEntidad.Text = EntidadSeleccionada.ApellidoNombre
            textboxEntidad.Tag = EntidadSeleccionada.IDEntidad
            FilterData()
        End If
        formEntidadesSeleccionar.Dispose()
    End Sub

    Private Sub EntidadBorrar_Click() Handles buttonEntidadBorrar.Click
        If textboxEntidad.Tag IsNot Nothing Then
            textboxEntidad.Text = ""
            textboxEntidad.Tag = Nothing
            FilterData()
        End If
    End Sub

    Private Sub comboboxBuscarTipo_SelectedIndexChanged() Handles comboboxBuscarTipo.SelectedIndexChanged
        Select Case comboboxBuscarTipo.SelectedIndex
            Case 0
                textboxBuscar.MaxLength = 152
            Case 1
                textboxBuscar.MaxLength = 13
            Case 2
                textboxBuscar.MaxLength = 12
        End Select
        If textboxBuscar.Text.Trim().Length >= 3 Then
            FilterData()
        End If
    End Sub

    Private Sub textboxBuscar_GotFocus() Handles textboxBuscar.GotFocus
        textboxBuscar.SelectAll()
    End Sub

    Private Sub textboxBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textboxBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            If textboxBuscar.Text.Trim.Length < 3 Then
                MsgBox("Se deben especificar al menos 3 caracteres para buscar.", MsgBoxStyle.Information, My.Application.Info.Title)
                textboxBuscar.Focus()
            Else
                FilterData()
            End If
            e.Handled = True
        ElseIf comboboxBuscarTipo.SelectedIndex = 1 Then
            If (Not Char.IsDigit(e.KeyChar)) AndAlso e.KeyChar <> Chr(Keys.Back) AndAlso e.KeyChar <> Chr(Keys.Delete) AndAlso e.KeyChar <> Chr(Keys.Separator) Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub BuscarBorrar_Click() Handles buttonBuscarBorrar.Click
        If Not String.IsNullOrWhiteSpace(textboxBuscar.Text) Then
            textboxBuscar.Clear()
            FilterData()
        End If
    End Sub

    Private Sub GridChangeOrder(sender As Object, e As DataGridViewCellMouseEventArgs) Handles datagridviewMain.ColumnHeaderMouseClick
        Dim ClickedColumn As DataGridViewColumn

        ClickedColumn = CType(datagridviewMain.Columns(e.ColumnIndex), DataGridViewColumn)

        If ClickedColumn Is mOrdenColumna Then
            ' La columna clickeada es la misma por la que ya estaba ordenado, así que cambio la dirección del orden
            If mOrdenTipo = SortOrder.Ascending Then
                mOrdenTipo = SortOrder.Descending
            Else
                mOrdenTipo = SortOrder.Ascending
            End If
        Else
            ' La columna clickeada es diferencte a la que ya estaba ordenada.
            ' En primer lugar saco el ícono de orden de la columna vieja
            If mOrdenColumna IsNot Nothing Then
                mOrdenColumna.HeaderCell.SortGlyphDirection = SortOrder.None
            End If

            ' Ahora preparo las variables para la nueva columna
            mOrdenTipo = SortOrder.Ascending
            mOrdenColumna = ClickedColumn
        End If

        OrderData()
    End Sub

    Private Sub ToolStripMenuItemGenerarCodigosQR_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemGenerarCodigosQR.Click
        Dim CurrentGridRowData As GridRowData
        Dim ComprobanteActual As Comprobante

        If MessageBox.Show($"Se van a generar los códigos QR de los comprobantes mostrados.{vbNewLine}{vbNewLine}¿Desea continuar?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        datagridviewMain.Enabled = False
        Using dbContext = New CSColegioContext(True)
            Dim idMoneda As Short
            Dim monedaCodigoAfip As String
            Dim monedaActual As Moneda
            Dim monedaCotizacionActual As MonedaCotizacion
            Dim monedaCotizacion As Decimal

            monedaActual = dbContext.Moneda.Find(CS_Parameter_System.GetIntegerAsShort(Parametros.DEFAULT_MONEDA_ID))
            If monedaActual Is Nothing Then
                MessageBox.Show("No se ha especificado la Moneda predeterminada.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                datagridviewMain.Enabled = True
                Me.Cursor = Cursors.Default
                Return
            End If
            idMoneda = monedaActual.IDMoneda
            monedaCodigoAfip = monedaActual.CodigoAFIP
            monedaActual = Nothing
            monedaCotizacionActual = dbContext.MonedaCotizacion.Where(Function(mc) mc.IDMoneda = idMoneda).FirstOrDefault
            If monedaCotizacionActual Is Nothing Then
                MessageBox.Show("No hay cotizaciones cargadas para la Moneda predeterminada.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                datagridviewMain.Enabled = True
                Me.Cursor = Cursors.Default
                Return
            End If
            monedaCotizacion = monedaCotizacionActual.CotizacionVenta
            monedaCotizacionActual = Nothing

            For Each row As DataGridViewRow In datagridviewMain.Rows
                datagridviewMain.CurrentCell = row.Cells(0)
                Application.DoEvents()
                CurrentGridRowData = CType(row.DataBoundItem, GridRowData)
                If Not (CurrentGridRowData.Anulado OrElse CurrentGridRowData.CAE Is Nothing) Then
                    Try
                        ComprobanteActual = dbContext.Comprobante.Find(CurrentGridRowData.IDComprobante)
                    Catch ex As Exception
                        datagridviewMain.Enabled = True
                        Me.Cursor = Cursors.Default
                        CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al cargar los datos del comprobante.")
                        Return
                    End Try
                    If ComprobanteActual.ComprobanteTipo.OperacionTipo = Constantes.OPERACIONTIPO_VENTA AndAlso ComprobanteActual.ComprobanteTipo.EmisionElectronica AndAlso ComprobanteActual.CodigoQR Is Nothing Then
                        If Not ModuloComprobantes.GenerarCodigoQR(ComprobanteActual, CS_Parameter_System.GetString(Parametros.AFIP_COMPROBANTES_CODIGOQR_DATA), CS_Parameter_System.GetString(Parametros.AFIP_COMPROBANTES_CODIGOQR_URL), idMoneda, monedaCodigoAfip, monedaCotizacion) Then
                            Return
                        End If
                    End If
                End If
            Next
            If dbContext.ChangeTracker.HasChanges Then
                Try
                    ' Guardo los cambios
                    dbContext.SaveChanges()
                Catch ex As Exception
                    datagridviewMain.Enabled = True
                    Me.Cursor = Cursors.Default
                    CardonerSistemas.ErrorHandler.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
                    Return
                End Try

                MessageBox.Show("Se han generado los códigos QR.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End Using
        datagridviewMain.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GenerarCódigosBarrasSEPSA_Click(sender As Object, e As EventArgs) Handles menuitemGenerarCódigosBarrasSEPSA.Click
        Dim CurrentGridRowData As GridRowData
        Dim ComprobanteActual As Comprobante

        If MessageBox.Show($"Se van a generar los códigos de barras SEPSA de los comprobantes mostrados.{vbNewLine}{vbNewLine}¿Desea continuar?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If
        Dim idCliente As Integer = CS_Parameter_System.GetIntegerAsInteger(Parametros.EMPRESA_PAGOSEDUC_NUMERO)
        If idCliente = 0 Then
            MessageBox.Show("No está especificado el número de empresa para PagosEDUC.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        datagridviewMain.Enabled = False
        Using dbContext = New CSColegioContext(True)
            For Each row As DataGridViewRow In datagridviewMain.Rows
                datagridviewMain.CurrentCell = row.Cells(0)
                Application.DoEvents()

                CurrentGridRowData = CType(row.DataBoundItem, GridRowData)
                If Not CurrentGridRowData.Anulado Then
                    Try
                        ComprobanteActual = dbContext.Comprobante.Find(CurrentGridRowData.IDComprobante)
                    Catch ex As Exception
                        datagridviewMain.Enabled = True
                        Me.Cursor = Cursors.Default
                        CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al cargar los datos del comprobante.")
                        Return
                    End Try
                    If ComprobanteActual.ComprobanteTipo.OperacionTipo = Constantes.OPERACIONTIPO_VENTA AndAlso (ComprobanteActual.ComprobanteTipo.CodigoAFIP = Constantes.ComprobanteCodigoAfipFacturaA OrElse ComprobanteActual.ComprobanteTipo.CodigoAFIP = Constantes.ComprobanteCodigoAfipFacturaB OrElse ComprobanteActual.ComprobanteTipo.CodigoAFIP = Constantes.ComprobanteCodigoAfipFacturaC) Then
                        If Not ComprobanteActual.CalcularCodigoBarrasSepsa(idCliente, ComprobanteActual.DocumentoNumero) Then
                            Return
                        End If
                    End If
                End If
            Next

            If dbContext.ChangeTracker.HasChanges Then
                Try
                    ' Guardo los cambios
                    dbContext.SaveChanges()
                Catch ex As Exception
                    datagridviewMain.Enabled = True
                    Me.Cursor = Cursors.Default
                    CardonerSistemas.ErrorHandler.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
                    Return
                End Try

                MsgBox("Se han actualizado los códigos.", MsgBoxStyle.Information, My.Application.Info.Title)
            End If
        End Using
        datagridviewMain.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "Main Toolbar"

    Private Sub Agregar(sender As Object, e As EventArgs) Handles buttonAgregar.Click
        If Not Permisos.VerificarPermiso(Permisos.COMPROBANTE_AGREGAR) Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        datagridviewMain.Enabled = False
        formComprobante.LoadAndShow(True, Me, 0)
        datagridviewMain.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Editar() Handles buttonEditar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comprobante para editar.", vbInformation, My.Application.Info.Title)
            Return
        End If
        If Not Permisos.VerificarPermiso(Permisos.COMPROBANTE_EDITAR) Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        datagridviewMain.Enabled = False
        Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
        If CurrentRow.Anulado Then
            MsgBox("No se puede editar este Comprobante porque está anulado.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
        Else
            Using dbContext = New CSColegioContext(True)
                Dim ComprobanteActual As Comprobante = dbContext.Comprobante.Find(CurrentRow.IDComprobante)
                If ComprobanteActual.ComprobanteTipo.EmisionElectronica AndAlso ComprobanteActual.CAE IsNot Nothing Then
                    Me.Cursor = Cursors.Default
                    MsgBox("No se puede editar este Comprobante porque es de Emisión Electrónica y ya tiene un CAE asignado.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Else
                    formComprobante.LoadAndShow(True, Me, CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData).IDComprobante)
                End If
            End Using
        End If
        datagridviewMain.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Anular() Handles buttonAnular.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comprobante para anular.", vbInformation, My.Application.Info.Title)
            Return
        End If
        If Not Permisos.VerificarPermiso(Permisos.COMPROBANTE_ANULAR) Then
            Return
        End If

        Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)

        Me.Cursor = Cursors.WaitCursor
        Using dbContext = New CSColegioContext(True)
            Dim ComprobanteActual As Comprobante = dbContext.Comprobante.Find(CurrentRow.IDComprobante)
            Dim Mensaje As String

            If CurrentRow.Anulado Then
                Mensaje = String.Format("Este comprobante ya se encuentra anulado. ¿Desea reactivarlo?.{0}{0}{1} N° {2}{0}{0}¿Confirma?", vbCrLf, CurrentRow.ComprobanteTipoNombre, CurrentRow.NumeroCompleto)
                If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                    Try
                        ComprobanteActual.IDUsuarioAnulacion = Nothing
                        ComprobanteActual.FechaHoraAnulacion = Nothing
                        dbContext.SaveChanges()

                    Catch ex As Exception
                        CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al reactivar el Comprobante.")
                    End Try

                    RefreshData()
                End If
            Else
                If ComprobanteActual.ComprobanteTipo.EmisionElectronica AndAlso ComprobanteActual.CAE IsNot Nothing Then
                    MsgBox("No se puede anular este Comprobante porque es de Emisión Electrónica y ya tiene un CAE asignado.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Else
                    Mensaje = String.Format("Se anulará el Comprobante seleccionado.{0}{0}{1} N° {2}{0}{0}¿Confirma?", vbCrLf, CurrentRow.ComprobanteTipoNombre, CurrentRow.NumeroCompleto)
                    If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                        Try
                            ComprobanteActual.IDUsuarioAnulacion = pUsuario.IDUsuario
                            ComprobanteActual.FechaHoraAnulacion = DateTime.Now
                            dbContext.SaveChanges()

                        Catch ex As Exception
                            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al anular el Comprobante.")
                        End Try

                        RefreshData()
                    End If
                End If
            End If
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Eliminar() Handles buttonEliminar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comprobante para eliminar.", vbInformation, My.Application.Info.Title)
            Return
        End If
        If Not Permisos.VerificarPermiso(Permisos.COMPROBANTE_ELIMINAR) Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor

        Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)

        Using dbContext = New CSColegioContext(True)
            Dim ComprobanteActual As Comprobante = dbContext.Comprobante.Find(CurrentRow.IDComprobante)
            If ComprobanteActual.ComprobanteTipo.EmisionElectronica AndAlso ComprobanteActual.CAE IsNot Nothing Then
                MsgBox("No se puede eliminar este Comprobante porque es de Emisión Electrónica y ya tiene un CAE asignado.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Return
            End If
            Dim Mensaje As String = $"Se eliminará el Comprobante seleccionado.{vbNewLine}{vbNewLine}{CurrentRow.ComprobanteTipoNombre} Nº {CurrentRow.NumeroCompleto}{vbNewLine}{vbNewLine}¿Confirma la eliminación definitiva?"
            If MessageBox.Show(Mensaje, My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                Me.Cursor = Cursors.Default
                Return
            End If

            Try
                dbContext.Comprobante.Remove(ComprobanteActual)
                dbContext.SaveChanges()
            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                    Case CardonerSistemas.Database.EntityFramework.Errors.RelatedEntity
                        MsgBox("No se puede eliminar el Comprobante porque tiene datos relacionados.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                End Select
                Me.Cursor = Cursors.Default
                Return
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al eliminar el Comprobante.")
            End Try

            RefreshData()
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Ver() Handles datagridviewMain.DoubleClick
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comprobante para ver.", vbInformation, My.Application.Info.Title)
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        datagridviewMain.Enabled = False
        formComprobante.LoadAndShow(False, Me, CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData).IDComprobante)
        datagridviewMain.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Imprimir(sender As Object, e As EventArgs) Handles buttonImprimir.ButtonClick, menuitemImprimirPrevisualizar.Click
        Dim CurrentRow As GridRowData
        Dim ComprobanteTipoActual As ComprobanteTipo

        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comprobante para imprimir.", vbInformation, My.Application.Info.Title)
            Return
        End If
        If Not Permisos.VerificarPermiso(Permisos.COMPROBANTE_IMPRIMIR) Then
            Return
        End If
        If sender.Equals(buttonImprimir) AndAlso MessageBox.Show($"Se va a imprimir directamente el Comprobante seleccionado.{vbNewLine}{vbNewLine}¿Desea continuar?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If
        CurrentRow = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
        If CurrentRow.Anulado Then
            MessageBox.Show("No se puede imprimir este Comprobante porque está anulado.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If
        Using dbcontext As New CSColegioContext(True)
            ComprobanteTipoActual = dbcontext.ComprobanteTipo.Find(CurrentRow.IDComprobanteTipo)
        End Using

        ' Verifico que tenga un CAE asignado, si es que corresponde
        If ComprobanteTipoActual.OperacionTipo = Constantes.OPERACIONTIPO_VENTA AndAlso ComprobanteTipoActual.EmisionElectronica AndAlso CurrentRow.CAE = "" AndAlso Not Permisos.VerificarPermiso(Permisos.COMPROBANTE_IMPRIMIR_SINCAE, False) Then
            MessageBox.Show($"El comprobante que desea imprimir no tiene un C.A.E. asignado.{vbNewLine}Esto puede ocurrir porque aún no fue enviado a AFIP o porque AFIP rechazó el comprobante.{vbNewLine}Por este motivo, este comprobante no tiene validez legal.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        datagridviewMain.Enabled = False

        Dim ReporteActual As New Reporte
        If ReporteActual.Open($"{pGeneralConfig.ReportsPath}\{ComprobanteTipoActual.ReporteNombre}") Then
            If ReporteActual.SetDatabaseConnection(pDatabase.Datasource, pDatabase.InitialCatalog, pDatabase.UserId, pDatabase.Password) Then
                ReporteActual.RecordSelectionFormula = "{Comprobante.IDComprobante} = " & CurrentRow.IDComprobante

                If sender.Equals(buttonImprimir) Then
                    ReporteActual.ReportObject.PrintToPrinter(1, False, 1, 100)
                Else
                    Reportes.PreviewCrystalReport(ReporteActual, CurrentRow.ComprobanteTipoNombre & " N° " & CurrentRow.NumeroCompleto)
                End If
            End If
        End If
        datagridviewMain.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Imprimir_ListadoDeComprobantes() Handles menuitemImprimirListadoDeComprobantes.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comprobante para imprimir.", vbInformation, My.Application.Info.Title)
            Return
        End If
        If Not Permisos.VerificarPermiso(Permisos.COMPROBANTE_IMPRIMIR) Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        datagridviewMain.Enabled = False
        Dim ReporteActual As New Reporte
        If ReporteActual.Open($"{pGeneralConfig.ReportsPath}\Comprobantes.rpt") Then
            If ReporteActual.SetDatabaseConnection(pDatabase.Datasource, pDatabase.InitialCatalog, pDatabase.UserId, pDatabase.Password) Then
                ReporteActual.RecordSelectionFormula = mReportSelectionFormula
                Reportes.PreviewCrystalReport(ReporteActual, "Listado de Comprobantes")
            End If
        End If
        datagridviewMain.Enabled = True
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub EnviarEmail_Click() Handles buttonEnviarEmail.Click
        Dim CurrentRow As GridRowData
        Dim ComprobanteTipoActual As ComprobanteTipo
        Dim ComprobanteActual As Comprobante
        Dim Titular As Entidad

        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comprobante para enviar por e-mail.", vbInformation, My.Application.Info.Title)
            Return
        End If
        If Not Permisos.VerificarPermiso(Permisos.COMPROBANTE_IMPRIMIR) Then
            Return
        End If
        CurrentRow = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
        If CurrentRow.Anulado Then
            MsgBox("No se puede enviar por e-mail este Comprobante porque está anulado.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Return
        End If

        Using dbContext As New CSColegioContext(True)
            ComprobanteActual = dbContext.Comprobante.Find(CurrentRow.IDComprobante)
            ComprobanteTipoActual = dbContext.ComprobanteTipo.Find(CurrentRow.IDComprobanteTipo)
            Titular = dbContext.Entidad.Find(CurrentRow.IDEntidad)

            ' Verifico que sea un comprobante de venta
            If ComprobanteTipoActual.OperacionTipo <> Constantes.OPERACIONTIPO_VENTA Then
                MsgBox("Sólo se pueden enviar por e-mail los Comprobantes de Venta.", MsgBoxStyle.Information, My.Application.Info.Title)
                Return
            End If

            ' Verifico que el Titular no especifique que no se le envíen por e-mail
            If Titular.ComprobanteEnviarEmail = Constantes.ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO Then
                If MsgBox("El Titular del Comprobante especificó que no se le envíen los Comprobantes por e-mail." & vbCrLf & vbCrLf & "¿Desea enviarlo de todos modos?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                    Return
                End If
            End If

            ' Verifico que el Titular tenga especificada una dirección de e-mail
            If Titular.Email1 Is Nothing AndAlso Titular.Email2 Is Nothing Then
                MsgBox("El Titular del Comprobante no tiene especificada ninguna dirección de e-mail.", MsgBoxStyle.Information, My.Application.Info.Title)
                Return
            End If

            ' Verifico que tenga un CAE asignado, si es que corresponde
            If ComprobanteTipoActual.EmisionElectronica AndAlso CurrentRow.CAE = "" Then
                MsgBox("El Comprobante que está intentando enviar no tiene un C.A.E. asignado." & vbCrLf & "Esto puede ocurrir porque aún no fue enviado a AFIP o porque AFIP rechazó el comprobante." & vbCrLf & "Por este motivo, este comprobante no tiene validez legal.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Return
            End If

            ' Verifico que no se haya enviado ya
            If ComprobanteActual.FechaHoraEnvioEmail IsNot Nothing Then
                If MsgBox(String.Format("El Comprobante que está por enviar, ya fue enviado el {1}.{0}{0}¿Desea enviarlo otra vez?", vbCrLf, ComprobanteActual.FechaHoraEnvioEmail.Value.ToShortDateString), CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                    Return
                End If
            End If

            If MsgBox("Se va a enviar el Comprobante seleccionado por e-mail." & vbCrLf & vbCrLf & "¿Desea continuar?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                Return
            End If

            Me.Cursor = Cursors.WaitCursor
            datagridviewMain.Enabled = False
            Dim ReporteActual As New Reporte
            If ReporteActual.Open($"{pGeneralConfig.ReportsPath}\{ComprobanteTipoActual.ReporteNombre}") Then
                If ReporteActual.SetDatabaseConnection(pDatabase.Datasource, pDatabase.InitialCatalog, pDatabase.UserId, pDatabase.Password) Then
                    ReporteActual.RecordSelectionFormula = "{Comprobante.IDComprobante} = " & CurrentRow.IDComprobante

                    Dim Asunto As String = String.Format(pComprobanteConfig.SendEmailSubject, ComprobanteTipoActual.NombreConLetra, CurrentRow.NumeroCompleto)
                    Dim Cuerpo As String = String.Format(pComprobanteConfig.SendEmailBody, vbCrLf) & String.Format(pEmailConfig.Signature, vbCrLf)
                    Dim AdjuntoNombre As String = String.Format("{0}-{1}.pdf", ComprobanteTipoActual.Sigla.TrimEnd, CurrentRow.NumeroCompleto)

                    If Email.EnviarSimple(New List(Of Entidad)({Titular}), New List(Of Entidad), New List(Of Entidad), Asunto, False, Cuerpo, ReporteActual, AdjuntoNombre, String.Empty, True) = -1 Then
                        datagridviewMain.Enabled = True
                        Me.Cursor = Cursors.Default
                        Return
                    End If

                    ComprobanteActual.IDUsuarioEnvioEmail = pUsuario.IDUsuario
                    ComprobanteActual.FechaHoraEnvioEmail = DateTime.Now
                    Try
                        dbContext.SaveChanges()
                    Catch ex As Exception
                        CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al actualizar los datos de envío de e-mail del Comprobante.")
                    End Try
                    MsgBox("Se ha enviado el Comprobante por e-mail.", vbInformation, My.Application.Info.Title)
                End If
            End If
            datagridviewMain.Enabled = True
            Me.Cursor = Cursors.Default
        End Using
    End Sub

#End Region

#Region "Extra stuff"

    Private Sub CambiarColorAFilaAnulada(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles datagridviewMain.RowPostPaint
        If e.RowIndex < datagridviewMain.RowCount - 1 Then
            Dim DataGridViewRowActual As DataGridViewRow

            DataGridViewRowActual = datagridviewMain.Rows(e.RowIndex)
            If CType(DataGridViewRowActual.DataBoundItem, GridRowData).Anulado Then
                DataGridViewRowActual.DefaultCellStyle.ForeColor = Color.DarkGray
                DataGridViewRowActual.DefaultCellStyle.Font = New System.Drawing.Font(pAppearanceConfig.ListsFont, FontStyle.Strikeout)
            End If
        End If
    End Sub

#End Region

End Class