Public Class formCursos

#Region "Declarations"
    Private Class GridRowData
        Public Property IDCurso As Byte
        Public Property IDNivel As Byte
        Public Property Nivel As String
        Public Property IDAnio As Byte
        Public Property Anio As String
        Public Property IDTurno As Byte
        Public Property Turno As String
        Public Property Division As String
        Public Property CuotaTipo As String
        Public Property EsActivo As Boolean
    End Class

    Private mlistCursosBase As List(Of GridRowData)
    Private mlistCursosFiltradaYOrdenada As List(Of GridRowData)

    Private mSkipFilterData As Boolean = False
    Private mBusquedaAplicada As Boolean = False
    Private mReportSelectionFormula As String

    Private mOrdenColumna As DataGridViewColumn
    Private mOrdenTipo As SortOrder
#End Region

#Region "Form stuff"

    Friend Sub SetAppearance()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.IMAGE_TABLAS_32)

        datagridviewMain.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont
    End Sub

    Private Sub Me_Load() Handles Me.Load
        SetAppearance()

        mSkipFilterData = True

        pFillAndRefreshLists.Nivel(comboboxNivel.ComboBox, True, False)
        pFillAndRefreshLists.Turno(comboboxTurno.ComboBox, True, False)

        comboboxActivo.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, My.Resources.STRING_YES, My.Resources.STRING_NO})
        comboboxActivo.SelectedIndex = 1

        mSkipFilterData = False

        mOrdenColumna = columnNivel
        mOrdenTipo = SortOrder.Ascending

        RefreshData()
    End Sub

#End Region

#Region "Load and Set Data"
    Friend Sub RefreshData(Optional ByVal PositionIDCurso As Byte = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)

        Me.Cursor = Cursors.WaitCursor

        Try
            Using dbContext As New CSColegioContext(True)
                mlistCursosBase = (From c In dbContext.Curso
                                   Join a In dbContext.Anio On a.IDAnio Equals c.IDAnio
                                   Join n In dbContext.Nivel On n.IDNivel Equals a.IDNivel
                                   Join t In dbContext.Turno On c.IDTurno Equals t.IDTurno
                                   Join ct In dbContext.CuotaTipo On c.IDCuotaTipo Equals ct.IDCuotaTipo
                                   Select New GridRowData With {.IDCurso = c.IDCurso, .IDNivel = a.IDNivel, .Nivel = n.Nombre, .IDAnio = a.IDAnio, .Anio = a.Nombre, .IDTurno = c.IDTurno, .Turno = t.Nombre, .Division = c.Division, .CuotaTipo = ct.Nombre, .EsActivo = a.EsActivo}).ToList
            End Using

        Catch ex As Exception

            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer los Cursos.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        Me.Cursor = Cursors.Default

        If RestoreCurrentPosition Then
            If datagridviewMain.CurrentRow Is Nothing Then
                PositionIDCurso = 0
            Else
                PositionIDCurso = CType(datagridviewMain.CurrentRow.DataBoundItem, GridRowData).IDAnio
            End If
        End If

        FilterData()

        If PositionIDCurso <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewMain.Rows
                If CType(CurrentRowChecked.DataBoundItem, GridRowData).IDCurso = PositionIDCurso Then
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
                mlistCursosFiltradaYOrdenada = mlistCursosBase.ToList

                ' Filtro por Nivel
                If comboboxNivel.SelectedIndex > 0 Then
                    mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, "", " AND ").ToString & String.Format("{{Anio.IDNivel}} = {0}", CByte(comboboxNivel.ComboBox.SelectedValue))
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.Where(Function(c) c.IDNivel = CByte(comboboxNivel.ComboBox.SelectedValue)).ToList
                End If

                ' Filtro por Curso
                If comboboxAnio.SelectedIndex > 0 Then
                    mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, "", " AND ").ToString & String.Format("{{Anio.IDNivel}} = {0}", CByte(comboboxAnio.ComboBox.SelectedValue))
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.Where(Function(c) c.IDAnio = CByte(comboboxAnio.ComboBox.SelectedValue)).ToList
                End If

                ' Filtro por Turno
                If comboboxTurno.SelectedIndex > 0 Then
                    mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, "", " AND ").ToString & String.Format("{{Curso.IDTurno}} = {0}", CByte(comboboxTurno.ComboBox.SelectedValue))
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.Where(Function(c) c.IDTurno = CByte(comboboxTurno.ComboBox.SelectedValue)).ToList
                End If

                'Filtro por Activo
                Select Case comboboxActivo.SelectedIndex
                    Case 0      ' Todos
                    Case 1      ' Sí
                        mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, "", " AND ").ToString & "{Curso.EsActivo} = 1"
                        mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.Where(Function(c) c.EsActivo).ToList
                    Case 2      ' No
                        mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, "", " AND ").ToString & "{Curso.EsActivo} = 0"
                        mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.Where(Function(c) Not c.EsActivo).ToList
                End Select

                Select Case mlistCursosFiltradaYOrdenada.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Cursos para mostrar.")
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Curso.")
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0} Cursos.", mlistCursosFiltradaYOrdenada.Count)
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
            Case columnNivel.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Anio).ThenBy(Function(dgrd) dgrd.Turno).ThenBy(Function(dgrd) dgrd.Division).ToList
                Else
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Nivel).ThenByDescending(Function(dgrd) dgrd.Anio).ThenByDescending(Function(dgrd) dgrd.Turno).ThenByDescending(Function(dgrd) dgrd.Division).ToList
                End If
            Case columnAnio.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Anio).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Turno).ThenBy(Function(dgrd) dgrd.Division).ToList
                Else
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Anio).ThenByDescending(Function(dgrd) dgrd.Nivel).ThenByDescending(Function(dgrd) dgrd.Turno).ThenByDescending(Function(dgrd) dgrd.Division).ToList
                End If
            Case columnTurno.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Turno).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Anio).ThenBy(Function(dgrd) dgrd.Division).ToList
                Else
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Turno).ThenByDescending(Function(dgrd) dgrd.Nivel).ThenByDescending(Function(dgrd) dgrd.Anio).ThenBy(Function(dgrd) dgrd.Division).ToList
                End If
            Case columnDivision.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Division).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Anio).ThenBy(Function(dgrd) dgrd.Turno).ToList
                Else
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Division).ThenByDescending(Function(dgrd) dgrd.Nivel).ThenByDescending(Function(dgrd) dgrd.Anio).ThenBy(Function(dgrd) dgrd.Turno).ToList
                End If
            Case columnCuotaTipo.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.CuotaTipo).ThenBy(Function(dgrd) dgrd.Turno).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Anio).ThenBy(Function(dgrd) dgrd.Division).ToList
                Else
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.CuotaTipo).ThenBy(Function(dgrd) dgrd.Turno).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Anio).ThenBy(Function(dgrd) dgrd.Division).ToList
                End If
            Case columnEsActivo.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.EsActivo).ThenBy(Function(dgrd) dgrd.Turno).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Anio).ThenBy(Function(dgrd) dgrd.Division).ToList
                Else
                    mlistCursosFiltradaYOrdenada = mlistCursosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.EsActivo).ThenBy(Function(dgrd) dgrd.Turno).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Anio).ThenBy(Function(dgrd) dgrd.Division).ToList
                End If
        End Select

        datagridviewMain.AutoGenerateColumns = False
        datagridviewMain.DataSource = mlistCursosFiltradaYOrdenada

        ' Muestro el ícono de orden en la columna correspondiente
        mOrdenColumna.HeaderCell.SortGlyphDirection = mOrdenTipo
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub comboboxNivel_SelectedIndexChanged() Handles comboboxNivel.SelectedIndexChanged
        pFillAndRefreshLists.Anio(comboboxAnio.ComboBox, True, False, CByte(comboboxNivel.ComboBox.SelectedValue) = 0, 0, CByte(comboboxNivel.ComboBox.SelectedValue))
        FilterData()
    End Sub

    Private Sub CambioFiltros() Handles comboboxAnio.SelectedIndexChanged, comboboxTurno.SelectedIndexChanged, comboboxActivo.SelectedIndexChanged
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
        If Permisos.VerificarPermiso(Permisos.CURSO_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formCurso.LoadAndShow(True, Me, 0)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Editar_Click() Handles buttonEditar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Curso para editar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.CURSO_EDITAR) Then
                Me.Cursor = Cursors.WaitCursor

                datagridviewMain.Enabled = False

                Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
                formCurso.LoadAndShow(True, Me, CurrentRow.IDCurso)

                datagridviewMain.Enabled = True

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Eliminar_Click() Handles buttonEliminar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Curso para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.CURSO_ELIMINAR) Then

                Me.Cursor = Cursors.WaitCursor

                Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)

                Using dbContext = New CSColegioContext(True)
                    Dim CursoActual As Curso = dbContext.Curso.Find(CurrentRow.IDCurso)
                    Dim Mensaje As String
                    Mensaje = String.Format("Se eliminará el Curso seleccionado.{0}{0}{1} - {2} - {3} - {4}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, CurrentRow.Nivel, CurrentRow.Anio, CurrentRow.Turno, CurrentRow.Division)
                    If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then

                        Try
                            dbContext.Curso.Remove(CursoActual)
                            dbContext.SaveChanges()

                        Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                            Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                                Case CardonerSistemas.Database.EntityFramework.Errors.RelatedEntity
                                    MsgBox("No se puede eliminar el Curso porque tiene datos relacionados.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                            End Select
                            Me.Cursor = Cursors.Default
                            Exit Sub

                        Catch ex As Exception
                            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al eliminar el Curso.")
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
            MsgBox("No hay ningún Curso para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
            formCurso.LoadAndShow(False, Me, CurrentRow.IDCurso)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

End Class