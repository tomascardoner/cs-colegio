Public Class formAnioLectivoCuotas

#Region "Declarations"
    Private Class GridRowData
        Public Property AnioLectivo As Short
        Public Property MesInicio As Byte
        Public Property IDCuotaTipo As Byte
        Public Property CuotaTipoNombre As String
        Public Property ImporteMatricula As Decimal
        Public Property ImporteCuota As Decimal
    End Class

    Private mlistAniosLectivosCuotasBase As List(Of GridRowData)
    Private mlistAniosLectivosCuotasFiltradaYOrdenada As List(Of GridRowData)

    Private mSkipFilterData As Boolean = False
    Private mBusquedaAplicada As Boolean = False
    Private mReportSelectionFormula As String

    Private mOrdenColumna As DataGridViewColumn
    Private mOrdenTipo As SortOrder
#End Region

#Region "Form stuff"
    Friend Sub SetAppearance()
        datagridviewMain.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont
    End Sub

    Private Sub Me_Load() Handles Me.Load
        SetAppearance()

        mSkipFilterData = True

        pFillAndRefreshLists.AnioLectivo(comboboxAnioLectivo.ComboBox, False, SortOrder.Ascending)
        comboboxAnioLectivo.SelectedIndex = comboboxAnioLectivo.FindStringExact(DateTime.Today.Year.ToString)

        mSkipFilterData = False

        mOrdenColumna = columnMesInicio
        mOrdenTipo = SortOrder.Ascending

        RefreshData()
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub RefreshData(Optional ByVal PositionAnioLectivo As Short = 0, Optional ByVal PositionMesInicio As Byte = 0, Optional ByVal PositionIDCuotaTipo As Byte = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)
        Dim GridRowDataCurrent As GridRowData

        Me.Cursor = Cursors.WaitCursor

        Try
            Using dbContext As New CSColegioContext(True)
                mlistAniosLectivosCuotasBase = (From alc In dbContext.AnioLectivoCuota
                                                Join ct In dbContext.CuotaTipo On ct.IDCuotaTipo Equals alc.IDCuotaTipo
                                                Select New GridRowData With {.AnioLectivo = alc.AnioLectivo, .MesInicio = alc.MesInicio, .IDCuotaTipo = ct.IDCuotaTipo, .CuotaTipoNombre = ct.Nombre, .ImporteMatricula = alc.ImporteMatricula, .ImporteCuota = alc.ImporteCuota}).ToList
            End Using

        Catch ex As Exception

            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer las Cuotas de los Años Lectivos.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        Me.Cursor = Cursors.Default

        If RestoreCurrentPosition Then
            If datagridviewMain.CurrentRow Is Nothing Then
                PositionAnioLectivo = 0
                PositionMesInicio = 0
                PositionIDCuotaTipo = 0
            Else
                GridRowDataCurrent = CType(datagridviewMain.CurrentRow.DataBoundItem, GridRowData)
                PositionAnioLectivo = GridRowDataCurrent.AnioLectivo
                PositionMesInicio = GridRowDataCurrent.MesInicio
                PositionIDCuotaTipo = GridRowDataCurrent.IDCuotaTipo
            End If
        End If

        FilterData()

        If PositionAnioLectivo <> 0 And PositionMesInicio <> 0 And PositionIDCuotaTipo <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewMain.Rows
                GridRowDataCurrent = CType(CurrentRowChecked.DataBoundItem, GridRowData)
                If GridRowDataCurrent.AnioLectivo = PositionAnioLectivo And GridRowDataCurrent.MesInicio = PositionMesInicio And GridRowDataCurrent.IDCuotaTipo = PositionIDCuotaTipo Then
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
                ' Inicializo las variables
                mReportSelectionFormula = ""
                mlistAniosLectivosCuotasFiltradaYOrdenada = mlistAniosLectivosCuotasBase.ToList

                ' Filtro por Año Lectivo
                mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, "", " AND ").ToString & String.Format("{{AnioLectivoCurso.AnioLectivo}} = {0}", CShort(comboboxAnioLectivo.Text))
                mlistAniosLectivosCuotasFiltradaYOrdenada = mlistAniosLectivosCuotasFiltradaYOrdenada.Where(Function(alc) alc.AnioLectivo = CShort(comboboxAnioLectivo.Text)).ToList

                Select Case mlistAniosLectivosCuotasFiltradaYOrdenada.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Cuotas del Año Lectivo para mostrar.")
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Cuota del Año Lectivo.")
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0} Cuotas del Año Lectivo.", mlistAniosLectivosCuotasFiltradaYOrdenada.Count)
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
            Case columnMesInicio.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosLectivosCuotasFiltradaYOrdenada = mlistAniosLectivosCuotasFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.MesInicio).ThenBy(Function(dgrd) dgrd.CuotaTipoNombre).ToList
                Else
                    mlistAniosLectivosCuotasFiltradaYOrdenada = mlistAniosLectivosCuotasFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.MesInicio).ThenBy(Function(dgrd) dgrd.CuotaTipoNombre).ToList
                End If
            Case columnCuotaTipo.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosLectivosCuotasFiltradaYOrdenada = mlistAniosLectivosCuotasFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.CuotaTipoNombre).ThenBy(Function(dgrd) dgrd.MesInicio).ToList
                Else
                    mlistAniosLectivosCuotasFiltradaYOrdenada = mlistAniosLectivosCuotasFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.CuotaTipoNombre).ThenBy(Function(dgrd) dgrd.MesInicio).ToList
                End If
            Case columnImporteMatricula.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosLectivosCuotasFiltradaYOrdenada = mlistAniosLectivosCuotasFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.ImporteMatricula).ThenBy(Function(dgrd) dgrd.MesInicio).ThenBy(Function(dgrd) dgrd.CuotaTipoNombre).ToList
                Else
                    mlistAniosLectivosCuotasFiltradaYOrdenada = mlistAniosLectivosCuotasFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.ImporteMatricula).ThenBy(Function(dgrd) dgrd.MesInicio).ThenBy(Function(dgrd) dgrd.CuotaTipoNombre).ToList
                End If
            Case columnImporteCuota.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosLectivosCuotasFiltradaYOrdenada = mlistAniosLectivosCuotasFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.ImporteCuota).ThenBy(Function(dgrd) dgrd.MesInicio).ThenBy(Function(dgrd) dgrd.CuotaTipoNombre).ToList
                Else
                    mlistAniosLectivosCuotasFiltradaYOrdenada = mlistAniosLectivosCuotasFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.ImporteCuota).ThenBy(Function(dgrd) dgrd.MesInicio).ThenBy(Function(dgrd) dgrd.CuotaTipoNombre).ToList
                End If
        End Select

        datagridviewMain.AutoGenerateColumns = False
        datagridviewMain.DataSource = mlistAniosLectivosCuotasFiltradaYOrdenada

        ' Muestro el ícono de orden en la columna correspondiente
        mOrdenColumna.HeaderCell.SortGlyphDirection = mOrdenTipo
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub CambioFiltros() Handles comboboxAnioLectivo.SelectedIndexChanged
        FilterData()
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
            If Not mOrdenColumna Is Nothing Then
                mOrdenColumna.HeaderCell.SortGlyphDirection = SortOrder.None
            End If

            ' Ahora preparo todo para la nueva columna
            mOrdenTipo = SortOrder.Ascending
            mOrdenColumna = ClickedColumn
        End If

        OrderData()
    End Sub
#End Region

#Region "Main Toolbar"
    Private Sub Agregar_Click() Handles buttonAgregar.Click
        If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCUOTA_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formAnioLectivoCuota.LoadAndShow(True, Me, Convert.ToInt16(comboboxAnioLectivo.Text), 0, 0)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Editar_Click() Handles buttonEditar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Cuota de Año Lectivo para editar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCUOTA_EDITAR) Then
                Me.Cursor = Cursors.WaitCursor

                datagridviewMain.Enabled = False

                Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
                formAnioLectivoCuota.LoadAndShow(True, Me, Convert.ToInt16(comboboxAnioLectivo.Text), CurrentRow.MesInicio, CurrentRow.IDCuotaTipo)

                datagridviewMain.Enabled = True

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Eliminar_Click() Handles buttonEliminar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Cuota de Año Lectivo para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCUOTA_ELIMINAR) Then

                Me.Cursor = Cursors.WaitCursor

                Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)

                Using dbContext = New CSColegioContext(True)
                    Dim AnioLectivoCuotaActual As AnioLectivoCuota = dbContext.AnioLectivoCuota.Find(CurrentRow.AnioLectivo, CurrentRow.MesInicio, CurrentRow.IDCuotaTipo)
                    Dim Mensaje As String
                    Mensaje = String.Format("Se eliminará la Cuota del Año Lectivo.{0}{0}Año Lectivo: {1}{0}Mes de inicio: {2}{0}Tipo de Cuota: {3}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, CurrentRow.AnioLectivo, MonthName(CurrentRow.MesInicio), CurrentRow.CuotaTipoNombre)
                    If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then

                        Try
                            dbContext.AnioLectivoCuota.Remove(AnioLectivoCuotaActual)
                            dbContext.SaveChanges()

                        Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                            Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                                Case CardonerSistemas.Database.EntityFramework.Errors.RelatedEntity
                                    MsgBox("No se puede eliminar la Cuota del Año Lectivo porque tiene datos relacionados.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                            End Select
                            Me.Cursor = Cursors.Default
                            Exit Sub

                        Catch ex As Exception
                            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al eliminar la Cuota del Año Lectivo.")
                        End Try

                        RefreshData()
                    End If
                End Using

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Ver(sender As Object, e As EventArgs) Handles datagridviewMain.DoubleClick
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Cuota de Año Lectivo para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
            formAnioLectivoCuota.LoadAndShow(False, Me, Convert.ToInt16(comboboxAnioLectivo.Text), CurrentRow.MesInicio, CurrentRow.IDCuotaTipo)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region

End Class