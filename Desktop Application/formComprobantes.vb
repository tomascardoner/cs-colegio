Imports System.Net.Mail

Public Class formComprobantes

#Region "Declarations"
    Private Class GridRowData
        Public Property IDComprobante As Integer
        Public Property OperacionTipo As String
        Public Property IDComprobanteTipo As Byte
        Public Property ComprobanteTipoNombre As String
        Public Property PuntoVenta As String
        Public Property Numero As String
        Public Property FechaEmision As Date
        Public Property IDEntidad As Integer
        Public Property EntidadNombre As String
        Public Property ImporteTotal As Decimal
        Public Property CAE As String
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
    Private Const COLUMNA_TITULAR As String = "columnEntidadNombre"
    Private Const COLUMNA_IMPORTETOTAL As String = "columnImporteTotal"
    Private Const COLUMNA_CAE As String = "columnCAE"
#End Region

#Region "Form stuff"
    Friend Sub SetAppearance()
        datagridviewMain.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont
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
#End Region

#Region "Load and Set Data"
    Friend Sub RefreshData(Optional ByVal PositionIDComprobante As Integer = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)
        Dim FechaDesde As Date
        Dim FechaHasta As Date

        Me.Cursor = Cursors.WaitCursor

        FechaDesde = System.DateTime.Now.AddMonths(-2)
        FechaHasta = System.DateTime.Now

        Try
            Using dbContext As New CSColegioContext(True)
                listComprobantesBase = (From cc In dbContext.Comprobante
                                        Join ct In dbContext.ComprobanteTipo On cc.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                        Where cc.FechaEmision >= FechaDesde And cc.FechaEmision <= FechaHasta
                                        Order By cc.FechaEmision, cc.IDComprobante
                                        Select New GridRowData With {.IDComprobante = cc.IDComprobante, .OperacionTipo = ct.OperacionTipo, .IDComprobanteTipo = cc.IDComprobanteTipo, .ComprobanteTipoNombre = ct.Nombre, .PuntoVenta = cc.PuntoVenta, .Numero = cc.Numero, .FechaEmision = cc.FechaEmision, .IDEntidad = cc.IDEntidad, .EntidadNombre = cc.ApellidoNombre, .ImporteTotal = cc.ImporteTotal, .CAE = cc.CAE}).ToList
            End Using

        Catch ex As Exception

            CS_Error.ProcessError(ex, "Error al leer los Comprobantes.")
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

        If Not SkipFilterData Then
            Me.Cursor = Cursors.WaitCursor

            Try
                If BusquedaAplicada Then
                    ' Hay una búsqueda aplicada
                    Select Case comboboxBuscarTipo.SelectedIndex
                        Case 0
                            ' Búsqueda por Entidad Titular
                            listComprobantesFiltradaYOrdenada = (From comp In listComprobantesBase
                                                                 Where comp.EntidadNombre.ToLower.Contains(textboxBuscar.Text.ToLower.Trim)).ToList
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

            Catch ex As Exception
                CS_Error.ProcessError(ex, "Error al filtrar los datos.")
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            OrderData()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub OrderData()
        ' Realizo las rutinas de ordenamiento
        Select Case OrdenColumna.Name
            Case COLUMNA_TIPO
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.Numero).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.Numero).ToList
                End If
            Case COLUMNA_PUNTOVENTA
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenBy(Function(dgrd) dgrd.Numero).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenByDescending(Function(dgrd) dgrd.Numero).ToList
                End If
            Case COLUMNA_NUMERO
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Numero).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Numero).ThenByDescending(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ToList
                End If
            Case COLUMNA_FECHA
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.Numero).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenByDescending(Function(dgrd) dgrd.PuntoVenta).ThenByDescending(Function(dgrd) dgrd.Numero).ToList
                End If
            Case COLUMNA_TITULAR
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.EntidadNombre).ThenBy(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.Numero).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.EntidadNombre).ThenByDescending(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenByDescending(Function(dgrd) dgrd.PuntoVenta).ThenByDescending(Function(dgrd) dgrd.Numero).ToList
                End If
            Case COLUMNA_IMPORTETOTAL
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.ImporteTotal).ThenBy(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.Numero).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.ImporteTotal).ThenByDescending(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenByDescending(Function(dgrd) dgrd.PuntoVenta).ThenByDescending(Function(dgrd) dgrd.Numero).ToList
                End If
            Case COLUMNA_CAE
                If OrdenTipo = SortOrder.Ascending Then
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.CAE).ThenBy(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenBy(Function(dgrd) dgrd.PuntoVenta).ThenBy(Function(dgrd) dgrd.Numero).ToList
                Else
                    listComprobantesFiltradaYOrdenada = listComprobantesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.CAE).ThenByDescending(Function(dgrd) dgrd.FechaEmision).ThenBy(Function(dgrd) dgrd.ComprobanteTipoNombre).ThenByDescending(Function(dgrd) dgrd.PuntoVenta).ThenByDescending(Function(dgrd) dgrd.Numero).ToList
                End If
        End Select

        datagridviewMain.AutoGenerateColumns = False
        datagridviewMain.DataSource = listComprobantesFiltradaYOrdenada

        ' Muestro el ícono de orden en la columna correspondiente
        OrdenColumna.HeaderCell.SortGlyphDirection = OrdenTipo
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub buttonEntidad_Click() Handles buttonEntidad.Click
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim EntidadSeleccionada As Entidad
            EntidadSeleccionada = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
            textboxEntidad.Text = EntidadSeleccionada.ApellidoNombre
            textboxEntidad.Tag = EntidadSeleccionada.IDEntidad
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
            Select Case comboboxBuscarTipo.SelectedIndex
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
        Select Case comboboxOperacionTipo.SelectedIndex
            Case -1, 0
                comboboxComprobanteTipo.ComboBox.DataSource = Nothing
                comboboxComprobanteTipo.Items.Clear()
                comboboxComprobanteTipo.Enabled = False
            Case 1
                pFillAndRefreshLists.ComprobanteTipo(comboboxComprobanteTipo.ComboBox, OPERACIONTIPO_COMPRA, True, False)
                comboboxComprobanteTipo.Enabled = True
            Case 2
                pFillAndRefreshLists.ComprobanteTipo(comboboxComprobanteTipo.ComboBox, OPERACIONTIPO_VENTA, True, False)
                comboboxComprobanteTipo.Enabled = True
        End Select
    End Sub

    Private Sub Imprimir(sender As Object, e As EventArgs) Handles buttonImprimir.ButtonClick, menuitemImprimirPrevisualizar.Click
        Dim CurrentRow As GridRowData
        Dim ComprobanteTipoActual As ComprobanteTipo

        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comprobante para imprimir.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.COMPROBANTE_PRINT) Then
                If sender.Equals(buttonImprimir) Then
                    If MsgBox("Se va a imprimir directamente el Comprobante seleccionado." & vbCrLf & vbCrLf & "¿Desea continuar?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                CurrentRow = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
                Using dbcontext As New CSColegioContext(True)
                    ComprobanteTipoActual = dbcontext.ComprobanteTipo.Find(CurrentRow.IDComprobanteTipo)
                End Using

                ' Verifico que tenga un CAE asignado, si es que corresponde
                If ComprobanteTipoActual.OperacionTipo = Constantes.OPERACIONTIPO_VENTA AndAlso ComprobanteTipoActual.EmisionElectronica AndAlso CurrentRow.CAE = "" Then
                    If MsgBox("El comprobante que está por imprimir no tiene un C.A.E. asignado." & vbCrLf & "Esto puede ocurrir porque aún no fue enviado a AFIP o porque AFIP rechazó el comprobante." & vbCrLf & "Por este motivo, este comprobante no tiene validez legal." & vbCrLf & vbCrLf & "¿Desea imrimirlo de todos modos?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                Me.Cursor = Cursors.WaitCursor

                datagridviewMain.Enabled = False

                Dim Reporte As New CS_CrystalReport
                If Reporte.OpenReport(My.Settings.ReportsPath & "\" & ComprobanteTipoActual.ReporteNombre) Then
                    If Reporte.SetDatabaseConnection(pDatabase.DataSource, pDatabase.InitialCatalog, pDatabase.UserID, pDatabase.Password) Then
                        Reporte.RecordSelectionFormula = "{Comprobante.IDComprobante} = " & CurrentRow.IDComprobante

                        If sender.Equals(buttonImprimir) Then
                            Reporte.ReportObject.PrintToPrinter(1, False, 1, 100)
                        Else
                            MiscFunctions.PreviewCrystalReport(Reporte, CurrentRow.ComprobanteTipoNombre & " N° " & CurrentRow.PuntoVenta & "-" & CurrentRow.Numero)
                        End If
                    End If
                End If

                datagridviewMain.Enabled = True

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub buttonEnviarEmail_Click() Handles buttonEnviarEmail.Click
        Dim CurrentRow As GridRowData
        Dim ComprobanteTipoActual As ComprobanteTipo
        Dim Titular As Entidad

        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comprobante para enviar por e-mail.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.COMPROBANTE_PRINT) Then
                If MsgBox("Se va a enviar por e-mail el Comprobante seleccionado." & vbCrLf & vbCrLf & "¿Desea continuar?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                    Exit Sub
                End If

                CurrentRow = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
                Using dbcontext As New CSColegioContext(True)
                    ComprobanteTipoActual = dbcontext.ComprobanteTipo.Find(CurrentRow.IDComprobanteTipo)
                    Titular = dbcontext.Entidad.Find(CurrentRow.IDEntidad)
                End Using

                ' Verifico que sea un comprobante de venta y de emisión electrónica
                If ComprobanteTipoActual.OperacionTipo <> Constantes.OPERACIONTIPO_VENTA Or Not ComprobanteTipoActual.EmisionElectronica Then
                    MsgBox("Sólo se pueden enviar por e-mail, Comprobantes de Venta de Emisión Electrónica.", MsgBoxStyle.Information, My.Application.Info.Title)
                    Exit Sub
                End If

                ' Verifico que el Titular tenga especificada una dirección de e-mail
                If Titular.Email1 Is Nothing And Titular.Email2 Is Nothing Then
                    MsgBox("El Titular del Comprobante no tiene especificada ninguna dirección de e-mail.", MsgBoxStyle.Information, My.Application.Info.Title)
                    Exit Sub
                End If

                ' Verifico que tenga un CAE asignado, si es que corresponde
                If CurrentRow.CAE = "" Then
                    If MsgBox("El comprobante que está por enviar no tiene un C.A.E. asignado." & vbCrLf & "Esto puede ocurrir porque aún no fue enviado a AFIP o porque AFIP rechazó el comprobante." & vbCrLf & "Por este motivo, este comprobante no tiene validez legal." & vbCrLf & vbCrLf & "¿Desea imrimirlo de todos modos?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                Me.Cursor = Cursors.WaitCursor

                datagridviewMain.Enabled = False

                Dim Reporte As New CS_CrystalReport
                If Reporte.OpenReport(My.Settings.ReportsPath & "\" & ComprobanteTipoActual.ReporteNombre) Then
                    If Reporte.SetDatabaseConnection(pDatabase.DataSource, pDatabase.InitialCatalog, pDatabase.UserID, pDatabase.Password) Then
                        Reporte.RecordSelectionFormula = "{Comprobante.IDComprobante} = " & CurrentRow.IDComprobante

                        Dim Asunto As String = String.Format(My.Settings.Comprobante_EnviarEmail_Subject, ComprobanteTipoActual.NombreConLetra, CurrentRow.PuntoVenta, CurrentRow.Numero)
                        Dim Cuerpo As String = String.Format(My.Settings.Comprobante_EnvioEmail_Body, vbCrLf) & String.Format(My.Settings.Email_Signature, vbCrLf)
                        Dim AdjuntoNombre As String = ComprobanteTipoActual.Sigla.TrimEnd & CurrentRow.PuntoVenta & CurrentRow.Numero & ".pdf"

                        Select Case My.Settings.LoteComprobantes_EnviarEmail_Metodo
                            Case Constantes.EMAIL_CLIENT_NETDLL
                                EnviarEmailPorNETClient(Titular, Asunto, Cuerpo, Reporte, AdjuntoNombre)
                            Case Constantes.EMAIL_CLIENT_MSOUTLOOK
                                EnviarEmailPorMSOutlook(Titular, Asunto, Cuerpo, Reporte, AdjuntoNombre)
                            Case Constantes.EMAIL_CLIENT_CRYSTALREPORTSMAPI
                                EnviarEmailPorCrystalReportsMAPI(Titular, Asunto, Cuerpo, Reporte, AdjuntoNombre)
                        End Select
                    End If
                End If

                datagridviewMain.Enabled = True

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub GridChangeOrder(sender As Object, e As DataGridViewCellMouseEventArgs) Handles datagridviewMain.ColumnHeaderMouseClick
        Dim ClickedColumn As DataGridViewColumn

        ClickedColumn = CType(datagridviewMain.Columns(e.ColumnIndex), DataGridViewColumn)

        If ClickedColumn Is OrdenColumna Then
            ' La columna clickeada es la misma por la que ya estaba ordenado, así que cambio la dirección del orden
            If OrdenTipo = SortOrder.Ascending Then
                OrdenTipo = SortOrder.Descending
            Else
                OrdenTipo = SortOrder.Ascending
            End If
        Else
            ' La columna clickeada es diferencte a la que ya estaba ordenada.
            ' En primer lugar saco el ícono de orden de la columna vieja
            If Not OrdenColumna Is Nothing Then
                OrdenColumna.HeaderCell.SortGlyphDirection = SortOrder.None
            End If

            ' Ahora preparo todo para la nueva columna
            OrdenTipo = SortOrder.Ascending
            OrdenColumna = ClickedColumn
        End If

        OrderData()
    End Sub
#End Region

#Region "Main Toolbar"
    Private Sub Agregar_Click() Handles buttonAgregar.Click
        If Permisos.VerificarPermiso(Permisos.COMPROBANTE_ADD) Then
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formComprobante.LoadAndShow(True, Me, 0)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Editar_Click() Handles buttonEditar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comprobante para editar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.COMPROBANTE_EDIT) Then
                Me.Cursor = Cursors.WaitCursor

                datagridviewMain.Enabled = False

                formComprobante.LoadAndShow(True, Me, CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData).IDComprobante)

                datagridviewMain.Enabled = True

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Eliminar_Click() Handles buttonEliminar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comprobante para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.COMPROBANTE_DELETE) Then

                Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)

                Using dbContext = New CSColegioContext(True)
                    Dim ComprobanteEliminar = dbContext.Comprobante.Find(CurrentRow.IDComprobante)
                    If ComprobanteEliminar.ComprobanteTipo.EmisionElectronica AndAlso Not ComprobanteEliminar.CAE Is Nothing Then
                        MsgBox("No se puede eliminar este Comprobante porque es de Emisión Electrónica y ya tiene un CAE asignado.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                    Else
                        Dim Mensaje As String
                        Mensaje = String.Format("Se eliminará el Comprobante seleccionado.{0}{0}{1} N° {2}-{3}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, CurrentRow.ComprobanteTipoNombre, CurrentRow.PuntoVenta, CurrentRow.Numero)
                        If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then

                            Me.Cursor = Cursors.WaitCursor

                            Try
                                dbContext.Comprobante.Remove(ComprobanteEliminar)
                                dbContext.SaveChanges()

                            Catch ex As Exception
                                CS_Error.ProcessError(ex, "Error al eliminar el Comprobante.")
                            End Try

                            RefreshData()
                            Me.Cursor = Cursors.Default
                        End If
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub Ver() Handles datagridviewMain.DoubleClick
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comporbante para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formComprobante.LoadAndShow(False, Me, CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData).IDComprobante)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region

#Region "Extra Stuff"
    Private Function EnviarEmailPorNETClient(ByRef Titular As Entidad, ByVal Asunto As String, ByVal Cuerpo As String, ByRef Reporte As CS_CrystalReport, ByVal AdjuntoNombre As String) As Boolean
        Dim mail As New MailMessage()
        Dim smtp As New SmtpClient()

        ' Establezco los recipientes
        mail.From = New MailAddress(My.Settings.Email_Address, My.Settings.Email_DisplayName)
        If Not Titular.Email1 Is Nothing Then
            mail.To.Add(New MailAddress(Titular.Email1, Titular.ApellidoNombre))
        End If
        If Not Titular.Email2 Is Nothing Then
            mail.To.Add(New MailAddress(Titular.Email2, Titular.ApellidoNombre))
        End If

        ' Establezco el contenido
        mail.Subject = Asunto
        mail.Body = Cuerpo

        ' Establezco las opciones del Servidor SMTP
        smtp.Host = My.Settings.Email_SMTP_Server
        smtp.EnableSsl = My.Settings.Email_SMTP_UseSSL
        smtp.Port = My.Settings.Email_SMTP_Port
        smtp.Timeout = My.Settings.Email_SMTP_Timeout

        Dim Decrypter As New CS_Encrypt_TripleDES(Constantes.ENCRYPTION_PASSWORD)
        smtp.Credentials = New System.Net.NetworkCredential(My.Settings.Email_SMTP_Username, Decrypter.Decrypt(My.Settings.Email_SMTP_Password))
        Decrypter = Nothing

        ' Attachments
        mail.Attachments.Add(New System.Net.Mail.Attachment(Reporte.ReportObject.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat), "FVC000100000545.pdf"))

        ' Envío el e-mail
        Try
            smtp.Send(mail)
            MsgBox("Se ha enviado el Comprobante por e-mail.", vbInformation, My.Application.Info.Title)
            Return True
        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al enviar el e-mail.")
            Return False
        End Try
    End Function

    Private Function EnviarEmailPorMSOutlook(ByRef Titular As Entidad, ByVal Asunto As String, ByVal Cuerpo As String, ByRef Reporte As CS_CrystalReport, ByVal AdjuntoNombre As String) As Boolean
        MsgBox("Se ha enviado el Comprobante por e-mail.", vbInformation, My.Application.Info.Title)
        Return True
    End Function

    Private Function EnviarEmailPorCrystalReportsMAPI(ByRef Titular As Entidad, ByVal Asunto As String, ByVal Cuerpo As String, ByRef Reporte As CS_CrystalReport, ByVal AdjuntoNombre As String) As Boolean
        'Preparo las opciones del mail
        Dim mailOpts As New CrystalDecisions.Shared.MicrosoftMailDestinationOptions
        If Not Titular.Email1 Is Nothing Then
            mailOpts.MailToList = Titular.Email1
        ElseIf Not Titular.Email2 Is Nothing Then
            mailOpts.MailToList = Titular.Email2
        End If
        mailOpts.MailSubject = "Comprobante electronico"
        mailOpts.MailMessage = "En el adjunto le enviamos el comprobante solicitado."

        'Ahora preparo las opciones de exportación
        Dim expopt As New CrystalDecisions.Shared.ExportOptions
        expopt.ExportDestinationType = CrystalDecisions.Shared.ExportDestinationType.MicrosoftMail
        expopt.ExportDestinationOptions = mailOpts
        expopt.ExportFormatType = CrystalDecisions.Shared.ExportFormatType.PortableDocFormat

        Try
            Reporte.ReportObject.Export(expopt)
            MsgBox("Se ha enviado el Comprobante por e-mail.", vbInformation, My.Application.Info.Title)
            Return True
        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al exportar el reporte.")
            Return False
        End Try
    End Function
#End Region

End Class