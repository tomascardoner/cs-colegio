Public Class formEntidadesAnioLectivoCurso

#Region "Declarations"

    Private ReadOnly dbcontext As New CSColegioContext(True)
    Private AnioLectivoCurso As AnioLectivoCurso

    Private Const COLUMNA_IDENTIDAD As String = "columnIDEntidad"
    Private Const COLUMNA_APELLIDO As String = "columnApellido"
    Private Const COLUMNA_NOMBRE As String = "columnNombre"

#End Region

#Region "Form stuff"

    Private Sub formEntidades_Load() Handles Me.Load
        SetAppearance()

        pFillAndRefreshLists.AnioLectivo(comboboxAnioLectivo.ComboBox, True, SortOrder.Descending)
        pFillAndRefreshLists.Nivel(comboboxNivel.ComboBox, False, False)

        RefreshData()
    End Sub

    Friend Sub SetAppearance()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.IMAGE_ENTIDADES_32)

        datagridviewMain.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont
    End Sub

    Private Sub formEntidadesAnioLectivoCurso_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbcontext.Dispose()
    End Sub

#End Region

#Region "Mostrar y leer datos"

    Friend Sub RefreshData()
        Me.Cursor = Cursors.WaitCursor

        If comboboxCurso.SelectedItem Is Nothing Then
            AnioLectivoCurso = Nothing
            datagridviewMain.AutoGenerateColumns = False
            datagridviewMain.DataSource = Nothing
        Else
            AnioLectivoCurso = dbcontext.AnioLectivoCurso.Where(Function(alc) alc.AnioLectivo = CShort(comboboxAnioLectivo.ComboBox.SelectedValue.ToString) AndAlso alc.IDCurso = CByte(comboboxCurso.ComboBox.SelectedValue.ToString)).First
            If AnioLectivoCurso IsNot Nothing Then
                datagridviewMain.AutoGenerateColumns = False
                datagridviewMain.DataSource = AnioLectivoCurso.Entidades.OrderBy(Function(ent) ent.ApellidoNombre).ToList
            End If
        End If

        Select Case AnioLectivoCurso.Entidades.Count
            Case 0
                statuslabelMain.Text = String.Format("No hay Entidades para mostrar.")
            Case 1
                statuslabelMain.Text = String.Format("Se muestra 1 Entidad.")
            Case Else
                statuslabelMain.Text = String.Format("Se muestran {0} Entidades.", AnioLectivoCurso.Entidades.Count)
        End Select

        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "Controls behavior"

    Private Sub ComboBoxesChanged() Handles comboboxAnioLectivo.SelectedIndexChanged, comboboxNivel.SelectedIndexChanged
        If (comboboxAnioLectivo.SelectedItem IsNot Nothing) AndAlso (comboboxNivel.SelectedItem IsNot Nothing) Then
            pFillAndRefreshLists.CursoPorAnioLectivoYNivel(comboboxCurso.ComboBox, CInt(comboboxAnioLectivo.ComboBox.SelectedValue), CByte(comboboxNivel.ComboBox.SelectedValue))
        End If
    End Sub

    Private Sub comboboxCurso_SelectedIndexChanged() Handles comboboxCurso.SelectedIndexChanged
        RefreshData()
    End Sub

    Private Sub datagridviewMain_DoubleClick() Handles datagridviewMain.DoubleClick
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Entidad para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formEntidad.LoadAndShow(False, Me, CInt(datagridviewMain.SelectedRows.Item(0).Cells(COLUMNA_IDENTIDAD).Value))

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

#Region "Main Toolbar"

    Private Sub Agregar_Click() Handles buttonAgregar.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDADANIOLECTIVOCURSO_AGREGAR) Then
            formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
            formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
            formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = True
            formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = False
            formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False
            If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                Dim EntidadNueva As Entidad = dbcontext.Entidad.Find(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).Cells(formEntidadesSeleccionar.columnIDEntidad.Name).Value)
                Try
                    Me.Cursor = Cursors.WaitCursor
                    AnioLectivoCurso.Entidades.Add(EntidadNueva)
                    dbcontext.SaveChanges()

                Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                    Me.Cursor = Cursors.Default
                    Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                        Case CardonerSistemas.Database.EntityFramework.Errors.DuplicatedEntity
                            MsgBox("No se puede agregar el Alumno al Curso porque ya está en el mismo.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                    End Select
                    Exit Sub

                Catch ex As Exception
                    Me.Cursor = Cursors.Default
                    CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al agregar el Alumno al Curso.")
                    Exit Sub
                End Try

                RefreshData()
                Me.Cursor = Cursors.Default
            End If
            formEntidadesSeleccionar.Dispose()
        End If
    End Sub

    Private Sub Eliminar_Click() Handles buttonEliminar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Entidad para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ENTIDADANIOLECTIVOCURSO_ELIMINAR) Then
                Dim EntidadEliminar = CType(datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
                If MsgBox("Se eliminará la Entidad seleccionada del Curso actual." & vbCrLf & vbCrLf & EntidadEliminar.ApellidoNombre & vbCrLf & vbCrLf & "¿Confirma la eliminación definitiva?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                    Try
                        Me.Cursor = Cursors.WaitCursor
                        AnioLectivoCurso.Entidades.Remove(EntidadEliminar)
                        dbcontext.SaveChanges()

                    Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                        Me.Cursor = Cursors.Default
                        Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                            Case CardonerSistemas.Database.EntityFramework.Errors.RelatedEntity
                                MsgBox("No se puede eliminar la Entidad del Curso porque tiene datos relacionados.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                        End Select
                        Exit Sub

                    Catch ex As Exception
                        CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al eliminar la Entidad del Curso.")
                    End Try

                    RefreshData()
                    Me.Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub

    Private Sub Imprimir(sender As Object, e As EventArgs) Handles menuitemImprimirListadoAnioLectivo.Click, menuitemImprimirListadoNivel.Click, menuitemImprimirListadoCurso.Click
        If sender.Equals(menuitemImprimirListadoCurso) AndAlso datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Alumno para imprimir.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ENTIDADANIOLECTIVOCURSO_IMPRIMIR) Then
                Me.Cursor = Cursors.WaitCursor

                datagridviewMain.Enabled = False

                Dim ReporteActual As New Reporte
                If ReporteActual.Open(pGeneralConfig.ReportsPath & "\AlumnosPorCurso.rpt") Then
                    If ReporteActual.SetDatabaseConnection(pDatabase.Datasource, pDatabase.InitialCatalog, pDatabase.UserId, pDatabase.Password) Then

                        If sender.Equals(menuitemImprimirListadoAnioLectivo) Then
                            ReporteActual.RecordSelectionFormula = String.Format("{{AnioLectivoCurso.AnioLectivo}} = {0}", comboboxAnioLectivo.ComboBox.SelectedValue.ToString)
                            Reportes.PreviewCrystalReport(ReporteActual, String.Format("Listado de Alumnos por Curso (Año Lectivo {0})", comboboxAnioLectivo.Text))
                        ElseIf sender.Equals(menuitemImprimirListadoNivel) Then
                            ReporteActual.RecordSelectionFormula = String.Format("{{AnioLectivoCurso.AnioLectivo}} = {0} AndAlso {{Anio.IDNivel}} = {1}", comboboxAnioLectivo.ComboBox.SelectedValue.ToString, comboboxNivel.ComboBox.SelectedValue.ToString)
                            Reportes.PreviewCrystalReport(ReporteActual, String.Format("Listado de Alumnos por Curso (Año Lectivo {0} - Nivel {1})", comboboxAnioLectivo.Text, comboboxNivel.Text))
                        ElseIf sender.Equals(menuitemImprimirListadoCurso) Then
                            ReporteActual.RecordSelectionFormula = String.Format("{{AnioLectivoCurso.AnioLectivo}} = {0} AndAlso {{AnioLectivoCurso.IDCurso}} = {1}", comboboxAnioLectivo.ComboBox.SelectedValue.ToString, comboboxCurso.ComboBox.SelectedValue.ToString)
                            Reportes.PreviewCrystalReport(ReporteActual, String.Format("Listado de Alumnos por Curso (Año Lectivo {0} - Nivel {1} - Curso {2})", comboboxAnioLectivo.Text, comboboxNivel.Text, comboboxCurso.Text))
                        End If
                    End If
                End If

                datagridviewMain.Enabled = True

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

#End Region

End Class