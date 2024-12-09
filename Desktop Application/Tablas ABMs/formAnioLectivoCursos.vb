Public Class formAnioLectivoCursos

#Region "Declarations"
    Private Class GridRowData
        Public Property IDAnioLectivoCurso As Short
        Public Property AnioLectivo As Short
        Public Property IDNivel As Byte
        Public Property Nivel As String
        Public Property IDCurso As Byte
        Public Property Curso As String
    End Class

    Private mlistAniosLectivosCursosBase As List(Of GridRowData)
    Private mlistAniosLectivosCursosFiltradaYOrdenada As List(Of GridRowData)

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

        pFillAndRefreshLists.AnioLectivo(comboboxAnioLectivo.ComboBox, False, SortOrder.Descending)
        comboboxAnioLectivo.SelectedIndex = comboboxAnioLectivo.FindStringExact(DateTime.Today.Year.ToString)
        pFillAndRefreshLists.Nivel(comboboxNivel.ComboBox, True, False)

        mSkipFilterData = False

        mOrdenColumna = columnNivel
        mOrdenTipo = SortOrder.Ascending

        RefreshData()
    End Sub

#End Region

#Region "Mostrar y leer datos"

    Friend Sub RefreshData(Optional ByVal PositionIDAnioLectivoCurso As Short = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)

        Me.Cursor = Cursors.WaitCursor

        Try
            Using dbContext As New CSColegioContext(True)
                mlistAniosLectivosCursosBase = (From alc In dbContext.AnioLectivoCurso
                                                Join c In dbContext.Curso On c.IDCurso Equals alc.IDCurso
                                                Join a In dbContext.Anio On a.IDAnio Equals c.IDAnio
                                                Join n In dbContext.Nivel On n.IDNivel Equals a.IDNivel
                                                Join t In dbContext.Turno On c.IDTurno Equals t.IDTurno
                                                Select New GridRowData With {.IDAnioLectivoCurso = alc.IDAnioLectivoCurso, .AnioLectivo = alc.AnioLectivo, .IDNivel = a.IDNivel, .Nivel = n.Nombre, .IDCurso = c.IDCurso, .Curso = a.Nombre & " - " & t.Nombre & " - " & c.Division}).ToList
            End Using

        Catch ex As Exception

            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer los Cursos de los Años Lectivos.")
            Me.Cursor = Cursors.Default
            Return
        End Try

        Me.Cursor = Cursors.Default

        If RestoreCurrentPosition Then
            If datagridviewMain.CurrentRow Is Nothing Then
                PositionIDAnioLectivoCurso = 0
            Else
                PositionIDAnioLectivoCurso = CType(datagridviewMain.CurrentRow.DataBoundItem, GridRowData).IDAnioLectivoCurso
            End If
        End If

        FilterData()

        If PositionIDAnioLectivoCurso <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewMain.Rows
                If CType(CurrentRowChecked.DataBoundItem, GridRowData).IDAnioLectivoCurso = PositionIDAnioLectivoCurso Then
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
                mlistAniosLectivosCursosFiltradaYOrdenada = mlistAniosLectivosCursosBase.ToList

                ' Filtro por Año Lectivo
                mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, String.Empty, " AND ").ToString & String.Format("{{AnioLectivoCurso.AnioLectivo}} = {0}", CShort(comboboxAnioLectivo.Text))
                mlistAniosLectivosCursosFiltradaYOrdenada = mlistAniosLectivosCursosFiltradaYOrdenada.Where(Function(alc) alc.AnioLectivo = CShort(comboboxAnioLectivo.Text)).ToList

                ' Filtro por Nivel
                If comboboxNivel.SelectedIndex > 0 Then
                    mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, String.Empty, " AND ").ToString & String.Format("{{Anio.IDNivel}} = {0}", CByte(comboboxNivel.ComboBox.SelectedValue))
                    mlistAniosLectivosCursosFiltradaYOrdenada = mlistAniosLectivosCursosFiltradaYOrdenada.Where(Function(alc) alc.IDNivel = CByte(comboboxNivel.ComboBox.SelectedValue)).ToList
                End If

                ' Filtro por Curso
                If comboboxCurso.SelectedIndex > 0 Then
                    mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, String.Empty, " AND ").ToString & String.Format("{{AnioLectivoCurso.IDCurso}} = {0}", CByte(comboboxCurso.ComboBox.SelectedValue))
                    mlistAniosLectivosCursosFiltradaYOrdenada = mlistAniosLectivosCursosFiltradaYOrdenada.Where(Function(alc) alc.IDCurso = CByte(comboboxCurso.ComboBox.SelectedValue)).ToList
                End If

                Select Case mlistAniosLectivosCursosFiltradaYOrdenada.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Cursos de Años Lectivos para mostrar.")
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Curso de Año Lectivo.")
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0} Cursos de Años Lectivos.", mlistAniosLectivosCursosFiltradaYOrdenada.Count)
                End Select

            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al filtrar los datos.")
                Me.Cursor = Cursors.Default
                Return
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
                    mlistAniosLectivosCursosFiltradaYOrdenada = mlistAniosLectivosCursosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.AnioLectivo).ThenBy(Function(dgrd) dgrd.Curso).ToList
                Else
                    mlistAniosLectivosCursosFiltradaYOrdenada = mlistAniosLectivosCursosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Nivel).ThenByDescending(Function(dgrd) dgrd.AnioLectivo).ThenByDescending(Function(dgrd) dgrd.Curso).ToList
                End If
            Case columnCurso.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosLectivosCursosFiltradaYOrdenada = mlistAniosLectivosCursosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Curso).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.AnioLectivo).ToList
                Else
                    mlistAniosLectivosCursosFiltradaYOrdenada = mlistAniosLectivosCursosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Curso).ThenByDescending(Function(dgrd) dgrd.Nivel).ThenByDescending(Function(dgrd) dgrd.AnioLectivo).ToList
                End If
        End Select

        datagridviewMain.AutoGenerateColumns = False
        datagridviewMain.DataSource = mlistAniosLectivosCursosFiltradaYOrdenada

        ' Muestro el ícono de orden en la columna correspondiente
        mOrdenColumna.HeaderCell.SortGlyphDirection = mOrdenTipo
    End Sub

#End Region

#Region "Controls behavior"
    Private Sub comboboxNivel_SelectedIndexChanged() Handles comboboxNivel.SelectedIndexChanged
        pFillAndRefreshLists.Curso(comboboxCurso.ComboBox, True, False, CByte(comboboxNivel.ComboBox.SelectedValue) = 0, CByte(comboboxNivel.ComboBox.SelectedValue))
        FilterData()
    End Sub

    Private Sub CambioFiltros() Handles comboboxAnioLectivo.SelectedIndexChanged, comboboxCurso.SelectedIndexChanged
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
        If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSO_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formAnioLectivoCurso.LoadAndShow(True, Me, 0)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Editar_Click() Handles buttonEditar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Curso de Año Lectivo para editar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSO_EDITAR) Then
                Me.Cursor = Cursors.WaitCursor

                datagridviewMain.Enabled = False

                Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
                formAnioLectivoCurso.LoadAndShow(True, Me, CurrentRow.IDAnioLectivoCurso)

                datagridviewMain.Enabled = True

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Eliminar_Click() Handles buttonEliminar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Curso de Año Lectivo para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSO_ELIMINAR) Then

                Me.Cursor = Cursors.WaitCursor

                Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)

                Using dbContext = New CSColegioContext(True)
                    Dim AnioLectivoCursoActual As AnioLectivoCurso = dbContext.AnioLectivoCurso.Find(CurrentRow.IDAnioLectivoCurso)
                    Dim Mensaje As String
                    Mensaje = String.Format("Se eliminará el Curso del Año Lectivo seleccionado.{0}{0}{1} - {2} - {3}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, CurrentRow.AnioLectivo, CurrentRow.Nivel, CurrentRow.Curso)
                    If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then

                        Try
                            dbContext.AnioLectivoCurso.Remove(AnioLectivoCursoActual)
                            dbContext.SaveChanges()

                        Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                            Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                                Case CardonerSistemas.Database.EntityFramework.Errors.RelatedEntity
                                    MsgBox("No se puede eliminar el Curso del Año Lectivo porque tiene datos relacionados.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                            End Select
                            Me.Cursor = Cursors.Default
                            Exit Sub

                        Catch ex As Exception
                            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al eliminar el Curso del Año Lectivo.")
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
            MsgBox("No hay ningún Curso de Año Lectivo para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
            formAnioLectivoCurso.LoadAndShow(False, Me, CurrentRow.IDAnioLectivoCurso)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Copiar_Click() Handles buttonCopiarAnioLectivo.Click
        If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSO_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formAnioLectivoCursoCopiar.LoadAndShow(Me)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

End Class