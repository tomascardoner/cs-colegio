Public Class formComprobantes
    Private Class GridRowData
        Friend Property IDComprobante As Integer
        Friend Property OperacionTipo As String
        Friend Property IDComprobanteTipo As Byte
        Friend Property ComprobanteTipo As String
        Friend Property PuntoVenta As String
        Friend Property Numero As String
        Friend Property Fecha As Date
        Friend Property Titular As String
        Friend Property ImporteTotal As Decimal
        Friend Property CAE As String
    End Class

    Private listComprobantesBase As List(Of GridRowData)
    Private listComprobantesFiltradaYOrdenada As List(Of GridRowData)

    Private SkipFilterData As Boolean = False
    Private BusquedaAplicada As Boolean = False

    Private OrdenColumna As DataGridViewColumn
    Private OrdenTipo As SortOrder

    Private Const COLUMNA_TIPO As String = "columnTipo"
    Private Const COLUMNA_PUNTOVENTA As String = "columnPuntoVenta"
    Private Const COLUMNA_NUMERO As String = "columnNumero"
    Private Const COLUMNA_FECHA As String = "columnFecha"
    Private Const COLUMNA_TITULAR As String = "columnTitular"
    Private Const COLUMNA_IMPORTETOTAL As String = "columnImporteTotal"
    Private Const COLUMNA_CAE As String = "columnCAE"

    Friend Sub RefreshData(Optional ByVal PositionIDComprobante As Integer = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)
        Dim FechaDesde As Date
        Dim FechaHasta As Date

        Me.Cursor = Cursors.WaitCursor

        FechaDesde = System.DateTime.Now.AddMonths(-2)
        FechaHasta = System.DateTime.Now

        Try
            Using context As New CSColegioContext
                listComprobantesBase = (From cc In context.ComprobanteCabecera
                                        Join ct In context.ComprobanteTipo On cc.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                        Join e In context.Entidad On cc.IDEntidad Equals e.IDEntidad
                                        Where cc.Fecha >= FechaDesde And cc.Fecha <= FechaHasta
                                        Order By cc.Fecha, cc.IDComprobante
                                        Select New GridRowData With {.IDComprobante = cc.IDComprobante, .OperacionTipo = ct.OperacionTipo, .IDComprobanteTipo = cc.IDComprobanteTipo, .ComprobanteTipo = ct.Nombre, .PuntoVenta = cc.PuntoVenta, .Numero = cc.Numero, .Fecha = cc.Fecha, .Titular = e.ApellidoNombre, .ImporteTotal = cc.ImporteTotal, .CAE = cc.CAE}).ToList
            End Using

        Catch ex As Exception

            CSM_Error.ProcessError(ex, "Error al leer los Comprobantes.")
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
                If CType(datagridviewMain.CurrentRow.DataBoundItem, GridRowData).IDComprobante = PositionIDComprobante Then
                    datagridviewMain.CurrentCell = CurrentRowChecked.Cells(COLUMNA_TIPO)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub FilterData()

        If Not SkipFilterData Then

            Me.Cursor = Cursors.WaitCursor

            If BusquedaAplicada Then
                ' Hay una búsqueda aplicada
                Select Case comboboxBuscarTipo.SelectedIndex
                    Case 0
                        ' Búsqueda por Entidad Titular
                        listComprobantesFiltradaYOrdenada = (From comp In listComprobantesBase
                                                             Where comp.Titular.ToLower.Contains(textboxBuscar.Text.ToLower.Trim)).ToList
                    Case 1
                        ' Búsqueda por Número de Comprobante
                        listComprobantesFiltradaYOrdenada = (From comp In listComprobantesBase
                                                             Where comp.Numero.Contains(textboxBuscar.Text.Trim)).ToList
                End Select
            Else
                If comboboxOperacionTipo.SelectedIndex = 0 Then
                    ' Todos los tipos de comprobantes
                    listComprobantesFiltradaYOrdenada = (From comp In listComprobantesBase).ToList
                ElseIf comboboxComprobanteTipo.SelectedIndex = 0 Then
                    ' Todos los comprobantes
                    listComprobantesFiltradaYOrdenada = (From comp In listComprobantesBase
                                                         Where comp.OperacionTipo = Choose(comboboxOperacionTipo.SelectedIndex, Constantes.OPERACIONTIPO_COMPRA, Constantes.OPERACIONTIPO_VENTA).ToString).ToList
                Else
                    ' Tipo de comprobante seleccionado
                    listComprobantesFiltradaYOrdenada = (From comp In listComprobantesBase
                                                         Where comp.IDComprobanteTipo = CByte(comboboxComprobanteTipo.ComboBox.SelectedValue)).ToList
                End If
            End If

            Select Case listComprobantesFiltradaYOrdenada.Count
                Case 0
                    statuslabelMain.Text = String.Format("No hay Comprobantes para mostrar.")
                Case 1
                    statuslabelMain.Text = String.Format("Se muestra 1 Comprobante.")
                Case Else
                    statuslabelMain.Text = String.Format("Se muestran {0} Comprobantes.", listComprobantesFiltradaYOrdenada.Count)
            End Select

            OrderData()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub OrderData()
        ' Realizo las rutinas de ordenamiento
        Select Case OrdenColumna.Name
            Case COLUMNA_TIPO
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.ComprobanteTipo).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.Numero).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.ComprobanteTipo).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.Numero).ToList
                End If
            Case COLUMNA_PUNTOVENTA
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.ComprobanteTipo).ThenBy(Function(dgrd) dgrd.Numero).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.ComprobanteTipo).ThenByDescending(Function(dgrd) dgrd.Numero).ToList
                End If
            Case COLUMNA_NUMERO
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Numero).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.ComprobanteTipo).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Numero).ThenByDescending(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.ComprobanteTipo).ToList
                End If
            Case COLUMNA_FECHA
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Fecha).ThenBy(Function(dgrd) dgrd.ComprobanteTipo).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.Numero).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Fecha).ThenBy(Function(dgrd) dgrd.ComprobanteTipo).ThenByDescending(Function(dgrd) dgrd.PuntoVenta).ThenByDescending(Function(dgrd) dgrd.Numero).ToList
                End If
            Case COLUMNA_TITULAR
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Titular).ThenBy(Function(dgrd) dgrd.Fecha).ThenBy(Function(dgrd) dgrd.ComprobanteTipo).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.Numero).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Titular).ThenByDescending(Function(dgrd) dgrd.Fecha).ThenBy(Function(dgrd) dgrd.ComprobanteTipo).ThenByDescending(Function(dgrd) dgrd.PuntoVenta).ThenByDescending(Function(dgrd) dgrd.Numero).ToList
                End If
            Case COLUMNA_IMPORTETOTAL
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.ImporteTotal).ThenBy(Function(dgrd) dgrd.Fecha).ThenBy(Function(dgrd) dgrd.ComprobanteTipo).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.Numero).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.ImporteTotal).ThenByDescending(Function(dgrd) dgrd.Fecha).ThenBy(Function(dgrd) dgrd.ComprobanteTipo).ThenByDescending(Function(dgrd) dgrd.PuntoVenta).ThenByDescending(Function(dgrd) dgrd.Numero).ToList
                End If
            Case COLUMNA_CAE
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.CAE).ThenBy(Function(dgrd) dgrd.Fecha).ThenBy(Function(dgrd) dgrd.ComprobanteTipo).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.Numero).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.CAE).ThenByDescending(Function(dgrd) dgrd.Fecha).ThenBy(Function(dgrd) dgrd.ComprobanteTipo).ThenByDescending(Function(dgrd) dgrd.PuntoVenta).ThenByDescending(Function(dgrd) dgrd.Numero).ToList
                End If
        End Select

        datagridviewMain.DataSource = listComprobantesFiltradaYOrdenada

        ' Muestro el ícono de orden en la columna correspondiente
        OrdenColumna.HeaderCell.SortGlyphDirection = OrdenTipo
    End Sub

    Friend Sub SetAppearance()
        datagridviewMain.DefaultCellStyle.Font = My.Settings.GridsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsFont
    End Sub

    Private Sub formComprobantes_Load() Handles Me.Load
        SetAppearance()

        SkipFilterData = True

        comboboxPeriodo.Items.AddRange({"Día:", "Semana:", "Mes:"})
        comboboxPeriodo.SelectedIndex = 0

        ' Tipos de Comprobantes
        comboboxOperacionTipo.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, My.Resources.STRING_OPERACIONTIPO_COMPRA, My.Resources.STRING_OPERACIONTIPO_VENTA})
        comboboxOperacionTipo.SelectedIndex = 0

        comboboxBuscarTipo.Items.AddRange({"Titular:", "Número:"})
        comboboxBuscarTipo.SelectedIndex = 1

        SkipFilterData = False

        OrdenColumna = columnFecha
        OrdenTipo = SortOrder.Ascending

        RefreshData()
    End Sub

    Private Sub buttonEntidad_Click() Handles buttonEntidad.Click
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            textboxEntidad.Text = CStr(formEntidadesSeleccionar.datagridviewMain.SelectedRows.Item(0).Cells(formEntidadesSeleccionar.COLUMNA_APELLIDO).Value()) & CStr(IIf(formEntidadesSeleccionar.datagridviewMain.SelectedRows.Item(0).Cells(formEntidadesSeleccionar.COLUMNA_NOMBRE).Value Is Nothing, "", ", " & CStr(formEntidadesSeleccionar.datagridviewMain.SelectedRows.Item(0).Cells(formEntidadesSeleccionar.COLUMNA_NOMBRE).Value)))
            textboxEntidad.Tag = CInt(formEntidadesSeleccionar.datagridviewMain.SelectedRows.Item(0).Cells(formEntidadesSeleccionar.COLUMNA_IDENTIDAD).Value())
            FilterData()
        End If
        formEntidadesSeleccionar.Dispose()
    End Sub

    Private Sub buttonEntidadBorrar_Click() Handles buttonEntidadBorrar.Click
        If Not textboxEntidad.Tag Is Nothing Then
            textboxEntidad.Text = ""
            textboxEntidad.Tag = Nothing
            FilterData()
        End If
    End Sub

    Private Sub comboboxBuscarTipo_SelectedIndexChanged() Handles comboboxBuscarTipo.SelectedIndexChanged
        Select Case comboboxBuscarTipo.SelectedIndex
            Case 0
                textboxBuscar.MaxLength = 152
                textboxBuscar.Width = 200
            Case 1
                textboxBuscar.MaxLength = 8
                textboxBuscar.Width = 80
        End Select
    End Sub

    Private Sub textboxBuscar_GotFocus() Handles textboxBuscar.GotFocus
        textboxBuscar.SelectAll()
    End Sub

    Private Sub textboxBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textboxBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            Select comboboxBuscarTipo.SelectedIndex
                Case 0
                    If textboxBuscar.Text.Trim.Length < 3 Then
                        MsgBox("Se deben especificar al menos 3 letras de la Entidad a buscar.", MsgBoxStyle.Information, My.Application.Info.Title)
                        textboxBuscar.Focus()
                    Else
                        BusquedaAplicada = True
                        FilterData()
                    End If
                Case 1
                    If textboxBuscar.Text.Trim.Length < 1 Then
                        MsgBox("Se debe especificar al menos 1 número del Comprobante a buscar.", MsgBoxStyle.Information, My.Application.Info.Title)
                        textboxBuscar.Focus()
                    Else
                        BusquedaAplicada = True
                        FilterData()
                    End If
            End Select
            e.Handled = True
        ElseIf comboboxBuscarTipo.SelectedIndex = 1 Then
            If e.KeyChar <= "0" Or e.KeyChar >= "9" Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub buttonBuscarBorrar_Click() Handles buttonBuscarBorrar.Click
        If BusquedaAplicada Then
            textboxBuscar.Clear()
            BusquedaAplicada = False
            FilterData()
        End If
    End Sub

    Private Sub comboboxComprobanteTipo_SelectedIndexChanged() Handles comboboxComprobanteTipo.SelectedIndexChanged
        FilterData()
    End Sub

    Private Sub comboboxOperacionTipo_SelectedIndexChanged() Handles comboboxOperacionTipo.SelectedIndexChanged
        Select comboboxOperacionTipo.SelectedIndex
            Case -1, 0
                comboboxComprobanteTipo.ComboBox.DataSource = Nothing
                comboboxComprobanteTipo.Items.Clear()
                comboboxComprobanteTipo.Enabled = False
            Case 1
                FillAndRefreshLists.ComprobanteTipo(comboboxComprobanteTipo.ComboBox, OPERACIONTIPO_COMPRA, True, False)
                comboboxComprobanteTipo.Enabled = True
            Case 2
                FillAndRefreshLists.ComprobanteTipo(comboboxComprobanteTipo.ComboBox, OPERACIONTIPO_VENTA, True, False)
                comboboxComprobanteTipo.Enabled = True
        End Select
    End Sub
End Class