Public Class formAnioLectivoCursoImportes

#Region "Declarations"
    Private Class GridRowData
        Public Property MesInicio As Byte
        Public Property MesInicioNombre As String
        Public Property ImporteMatricula As Decimal
        Public Property ImporteCuota As Decimal
    End Class

    Private mAnioLectivoCursoActual As AnioLectivoCurso

    Private mlistAniosLectivosCursosImportesBase As List(Of GridRowData)
    Private mlistAniosLectivosCursosImportesFiltradaYOrdenada As List(Of GridRowData)

    Private mSkipFilterData As Boolean = False
    Private mBusquedaAplicada As Boolean = False
    Private mReportSelectionFormula As String

    Private mOrdenColumna As DataGridViewColumn
    Private mOrdenTipo As SortOrder
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByRef AnioLectivoCursoActual As AnioLectivoCurso)

        mAnioLectivoCursoActual = AnioLectivoCursoActual

        Me.MdiParent = formMDIMain
        Me.Show()
        textboxAnioLectivo.Text = AnioLectivoCursoActual.AnioLectivo.ToString
        textboxCurso.Text = AnioLectivoCursoActual.Curso.Anio.Nombre & " - " & AnioLectivoCursoActual.Curso.Turno.Nombre & " - " & AnioLectivoCursoActual.Curso.Division

        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
        End If
        Me.Focus()
    End Sub

    Friend Sub SetAppearance()
        datagridviewMain.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont
    End Sub

    Private Sub Me_Load() Handles Me.Load
        SetAppearance()

        mSkipFilterData = True

        mSkipFilterData = False

        mOrdenColumna = columnMesInicio
        mOrdenTipo = SortOrder.Ascending

        RefreshData()
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub RefreshData(Optional ByVal PositionMesInicio As Byte = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)

        Me.Cursor = Cursors.WaitCursor

        Try
            Using dbContext As New CSColegioContext(True)
                mlistAniosLectivosCursosImportesBase = (From alc In dbContext.AnioLectivoCurso
                                                        Join alci In dbContext.AnioLectivoCursoImporte On alci.IDAnioLectivoCurso Equals alc.IDAnioLectivoCurso
                                                        Where alc.IDAnioLectivoCurso = mAnioLectivoCursoActual.IDAnioLectivoCurso
                                                        Order By alci.MesInicio
                                                        Select New GridRowData With {.MesInicio = alci.MesInicio, .ImporteMatricula = alci.ImporteMatricula, .ImporteCuota = alci.ImporteCuota}).ToList
            End Using

            ' Agrego los nombres de los meses
            For Each RowCurrent As GridRowData In mlistAniosLectivosCursosImportesBase
                RowCurrent.MesInicioNombre = MonthName(RowCurrent.MesInicio).ElementAt(0).ToString.ToUpper & MonthName(RowCurrent.MesInicio).Substring(1).ToLower
            Next

        Catch ex As Exception

            CS_Error.ProcessError(ex, "Error al leer los Importes de los Cursos de los Años Lectivos.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        Me.Cursor = Cursors.Default

        If RestoreCurrentPosition Then
            If datagridviewMain.CurrentRow Is Nothing Then
                PositionMesInicio = 0
            Else
                PositionMesInicio = CType(datagridviewMain.CurrentRow.DataBoundItem, GridRowData).MesInicio
            End If
        End If

        FilterData()

        If PositionMesInicio <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewMain.Rows
                If CType(CurrentRowChecked.DataBoundItem, GridRowData).MesInicio = PositionMesInicio Then
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

            datagridviewMain.AutoGenerateColumns = False
            datagridviewMain.DataSource = mlistAniosLectivosCursosImportesFiltradaYOrdenada

            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region

#Region "Main Toolbar"
    Private Sub Agregar_Click() Handles buttonAgregar.Click
        If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSOIMPORTE_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formAnioLectivoCursoImporte.LoadAndShow(True, Me, mAnioLectivoCursoActual, 0)

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
                formAnioLectivoCursoImporte.LoadAndShow(True, Me, mAnioLectivoCursoActual, CurrentRow.MesInicio)

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
                    Dim AnioLectivoCursoImporteActual As AnioLectivoCursoImporte = dbContext.AnioLectivoCursoImporte.Find(mAnioLectivoCursoActual.IDAnioLectivoCurso, CurrentRow.MesInicio)
                    Dim Mensaje As String
                    Mensaje = String.Format("Se eliminará el Importe del Curso del Año Lectivo seleccionado.{0}{0}Mes de Inicio: {1}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, MonthName(CurrentRow.MesInicio).ElementAt(0).ToString.ToUpper & MonthName(CurrentRow.MesInicio).Substring(1).ToLower)
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
            formAnioLectivoCursoImporte.LoadAndShow(False, Me, mAnioLectivoCursoActual, CurrentRow.MesInicio)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

End Class