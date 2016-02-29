Public Class formAniosLectivosCursosImportes

#Region "Declarations"
    Private Class GridRowData
        Public Property IDAnioLectivoCurso As Short
        Public Property AnioLectivo As Short
        Public Property IDNivel As Byte
        Public Property Nivel As String
        Public Property IDCurso As Byte
        Public Property Curso As String
        Public Property MesInicio As Byte
        Public Property ImporteMatricula As Decimal
        Public Property ImporteCuota As Decimal
    End Class

    Private mlistAniosLectivosCursosImportesBase As List(Of GridRowData)
    Private mlistAniosLectivosCursosImportesFiltradaYOrdenada As List(Of GridRowData)

    Private mSkipFilterData As Boolean = False
    Private mBusquedaAplicada As Boolean = False
    Private mReportSelectionFormula As String

    Private mOrdenColumna As DataGridViewColumn
    Private mOrdenTipo As SortOrder
#End Region

#Region "Form stuff"
    Friend Sub SetAppearance()
        datagridviewMain.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont
    End Sub

    Private Sub Me_Load() Handles Me.Load
        SetAppearance()

        mSkipFilterData = True

        pFillAndRefreshLists.AnioLectivo(comboboxAnioLectivo.ComboBox, False, SortOrder.Ascending)
        comboboxAnioLectivo.SelectedIndex = comboboxAnioLectivo.FindStringExact(DateTime.Today.Year.ToString)
        pFillAndRefreshLists.Nivel(comboboxNivel.ComboBox, True, False)
        pFillAndRefreshLists.Mes(comboboxMesInicio.ComboBox, True, True, False)
        comboboxMesInicio.SelectedIndex = 0

        mSkipFilterData = False

        mOrdenColumna = columnAnioLectivo
        mOrdenTipo = SortOrder.Ascending

        RefreshData()
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub RefreshData(Optional ByVal PositionIDAnioLectivoCurso As Short = 0, Optional ByVal PositionMesInicio As Byte = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)

        Me.Cursor = Cursors.WaitCursor

        Try
            Using dbContext As New CSColegioContext(True)
                mlistAniosLectivosCursosImportesBase = (From alc In dbContext.AnioLectivoCurso
                                                        Join alci In dbContext.AnioLectivoCursoImporte On alci.IDAnioLectivoCurso Equals alc.IDAnioLectivoCurso
                                                        Join c In dbContext.Curso On c.IDCurso Equals alc.IDCurso
                                                        Join a In dbContext.Anio On a.IDAnio Equals c.IDAnio
                                                        Join n In dbContext.Nivel On n.IDNivel Equals a.IDNivel
                                                        Join t In dbContext.Turno On c.IDTurno Equals t.IDTurno
                                                        Select New GridRowData With {.IDAnioLectivoCurso = alc.IDAnioLectivoCurso, .AnioLectivo = alc.AnioLectivo, .IDNivel = a.IDNivel, .Nivel = n.Nombre, .IDCurso = c.IDCurso, .Curso = a.Nombre & " - " & t.Nombre & " - " & c.Division, .MesInicio = alci.MesInicio, .ImporteMatricula = alci.ImporteMatricula, .ImporteCuota = alci.ImporteCuota}).ToList
            End Using

        Catch ex As Exception

            CS_Error.ProcessError(ex, "Error al leer los Importes de los Cursos de los Años Lectivos.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        Me.Cursor = Cursors.Default

        If RestoreCurrentPosition Then
            If datagridviewMain.CurrentRow Is Nothing Then
                PositionIDAnioLectivoCurso = 0
                PositionMesInicio = 0
            Else
                PositionIDAnioLectivoCurso = CType(datagridviewMain.CurrentRow.DataBoundItem, GridRowData).IDAnioLectivoCurso
                PositionMesInicio = CType(datagridviewMain.CurrentRow.DataBoundItem, GridRowData).MesInicio
            End If
        End If

        FilterData()

        If PositionIDAnioLectivoCurso <> 0 And PositionMesInicio <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewMain.Rows
                If CType(CurrentRowChecked.DataBoundItem, GridRowData).IDAnioLectivoCurso = PositionIDAnioLectivoCurso And CType(CurrentRowChecked.DataBoundItem, GridRowData).MesInicio = PositionMesInicio Then
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
                mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesBase.ToList

                ' Filtro por Año Lectivo
                mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, "", " AND ").ToString & String.Format("{{AnioLectivoCurso.AnioLectivo}} = {0}", CShort(comboboxAnioLectivo.Text))
                mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.Where(Function(alc) alc.AnioLectivo = CShort(comboboxAnioLectivo.Text)).ToList

                ' Filtro por Nivel
                If comboboxNivel.SelectedIndex > 0 Then
                    mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, "", " AND ").ToString & String.Format("{{Anio.IDNivel}} = {0}", CByte(comboboxNivel.ComboBox.SelectedValue))
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.Where(Function(alc) alc.IDNivel = CByte(comboboxNivel.ComboBox.SelectedValue)).ToList
                End If

                ' Filtro por Curso
                If comboboxCurso.SelectedIndex > 0 Then
                    mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, "", " AND ").ToString & String.Format("{{AnioLectivoCurso.IDCurso}} = {0}", CByte(comboboxCurso.ComboBox.SelectedValue))
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.Where(Function(alc) alc.IDCurso = CByte(comboboxCurso.ComboBox.SelectedValue)).ToList
                End If

                ' Filtro por Mes de Inicio
                If comboboxMesInicio.SelectedIndex > 0 Then
                    mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, "", " AND ").ToString & String.Format("{{AnioLectivoCursoImporte.MesInicio}} = {0}", comboboxMesInicio.ComboBox.SelectedIndex)
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.Where(Function(alc) alc.MesInicio = CByte(comboboxMesInicio.ComboBox.SelectedIndex)).ToList
                End If

                Select Case mlistAniosLectivosCursosImportesFiltradaYOrdenada.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Importes de Cursos de Años Lectivos para mostrar.")
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Importe de Curso de Año Lectivo.")
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0} Importes de Cursos de Años Lectivos.", mlistAniosLectivosCursosImportesFiltradaYOrdenada.Count)
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
        Select Case mOrdenColumna.Name
            Case columnAnioLectivo.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.AnioLectivo).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Curso).ToList
                Else
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.AnioLectivo).ThenByDescending(Function(dgrd) dgrd.Nivel).ThenByDescending(Function(dgrd) dgrd.Curso).ToList
                End If
            Case columnNivel.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.AnioLectivo).ThenBy(Function(dgrd) dgrd.Curso).ToList
                Else
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Nivel).ThenByDescending(Function(dgrd) dgrd.AnioLectivo).ThenByDescending(Function(dgrd) dgrd.Curso).ToList
                End If
            Case columnCurso.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Curso).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.AnioLectivo).ToList
                Else
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Curso).ThenByDescending(Function(dgrd) dgrd.Nivel).ThenByDescending(Function(dgrd) dgrd.AnioLectivo).ToList
                End If
            Case columnMesInicio.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.MesInicio).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.AnioLectivo).ThenBy(Function(dgrd) dgrd.Curso).ToList
                Else
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.MesInicio).ThenByDescending(Function(dgrd) dgrd.Nivel).ThenByDescending(Function(dgrd) dgrd.AnioLectivo).ThenByDescending(Function(dgrd) dgrd.Curso).ToList
                End If
            Case columnImporteMatricula.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.ImporteMatricula).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.AnioLectivo).ThenBy(Function(dgrd) dgrd.Curso).ThenBy(Function(dgrd) dgrd.MesInicio).ToList
                Else
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.ImporteMatricula).ThenByDescending(Function(dgrd) dgrd.Nivel).ThenByDescending(Function(dgrd) dgrd.AnioLectivo).ThenByDescending(Function(dgrd) dgrd.Curso).ThenByDescending(Function(dgrd) dgrd.MesInicio).ToList
                End If
            Case columnImporteCuota.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.ImporteCuota).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.AnioLectivo).ThenBy(Function(dgrd) dgrd.Curso).ThenBy(Function(dgrd) dgrd.MesInicio).ToList
                Else
                    mlistAniosLectivosCursosImportesFiltradaYOrdenada = mlistAniosLectivosCursosImportesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.ImporteCuota).ThenByDescending(Function(dgrd) dgrd.Nivel).ThenByDescending(Function(dgrd) dgrd.AnioLectivo).ThenByDescending(Function(dgrd) dgrd.Curso).ThenByDescending(Function(dgrd) dgrd.MesInicio).ToList
                End If
        End Select

        datagridviewMain.AutoGenerateColumns = False
        datagridviewMain.DataSource = mlistAniosLectivosCursosImportesFiltradaYOrdenada

        ' Muestro el ícono de orden en la columna correspondiente
        mOrdenColumna.HeaderCell.SortGlyphDirection = mOrdenTipo
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub comboboxNivel_SelectedIndexChanged() Handles comboboxNivel.SelectedIndexChanged
        pFillAndRefreshLists.Curso(comboboxCurso.ComboBox, True, False, CByte(comboboxNivel.ComboBox.SelectedValue) = 0, CByte(comboboxNivel.ComboBox.SelectedValue))
        FilterData()
    End Sub

    Private Sub CambioFiltros() Handles comboboxAnioLectivo.SelectedIndexChanged, comboboxCurso.SelectedIndexChanged, comboboxMesInicio.SelectedIndexChanged
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
        If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSOIMPORTE_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formAnioLectivoCursoImporte.LoadAndShow(True, Me, 0, 0)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Editar_Click() Handles buttonEditar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Importe de Curso de Año Lectivo para editar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSOIMPORTE_EDITAR) Then
                Me.Cursor = Cursors.WaitCursor

                datagridviewMain.Enabled = False

                Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
                formAnioLectivoCursoImporte.LoadAndShow(True, Me, CurrentRow.IDAnioLectivoCurso, CurrentRow.MesInicio)

                datagridviewMain.Enabled = True

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Eliminar_Click() Handles buttonEliminar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Importe de Curso de Año Lectivo para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSOIMPORTE_ELIMINAR) Then

                Me.Cursor = Cursors.WaitCursor

                Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)

                Using dbContext = New CSColegioContext(True)
                    Dim AnioLectivoCursoImporteActual As AnioLectivoCursoImporte = dbContext.AnioLectivoCursoImporte.Find(CurrentRow.IDAnioLectivoCurso, CurrentRow.MesInicio)
                    Dim Mensaje As String
                    Mensaje = String.Format("Se eliminará el Importe del Curso del Año Lectivo seleccionado.{0}{0}{1} - {2} - {3} - Mes de Inicio: {4}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, CurrentRow.AnioLectivo, CurrentRow.Nivel, CurrentRow.Curso, CurrentRow.MesInicio)
                    If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then

                        Try
                            dbContext.AnioLectivoCursoImporte.Remove(AnioLectivoCursoImporteActual)
                            dbContext.SaveChanges()

                        Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                            Select Case CS_Database_EF_SQL.TryDecodeDbUpdateException(dbuex)
                                Case Errors.RelatedEntity
                                    MsgBox("No se puede eliminar el Importe del Curso del Año Lectivo porque tiene datos relacionados.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                            End Select
                            Me.Cursor = Cursors.Default
                            Exit Sub

                        Catch ex As Exception
                            CS_Error.ProcessError(ex, "Error al eliminar el Importe del Curso del Año Lectivo.")
                        End Try

                        RefreshData()
                    End If
                End Using

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Ver() Handles datagridviewMain.DoubleClick
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Importe de Curso de Año Lectivo para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
            formAnioLectivoCursoImporte.LoadAndShow(False, Me, CurrentRow.IDAnioLectivoCurso, CurrentRow.MesInicio)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Copiar_Click() Handles buttonCopiarAnioLectivo.Click
        If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSO_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            'formAnioLectivoCursoCopiar.LoadAndShow(Me)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

End Class