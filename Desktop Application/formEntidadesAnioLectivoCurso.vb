Public Class formEntidadesAnioLectivoCurso
    Private dbcEntidadesAnioLectivoCurso As New CSColegioContext
    Private AnioLectivoCurso As AnioLectivoCurso

    Friend Sub RefreshData()
        Me.Cursor = Cursors.WaitCursor

        If comboboxCurso.SelectedItem Is Nothing Then
            AnioLectivoCurso = Nothing
            datagridviewMain.AutoGenerateColumns = False
            datagridviewMain.DataSource = Nothing
        Else
            AnioLectivoCurso = dbcEntidadesAnioLectivoCurso.AnioLectivoCurso.Where(Function(alc) alc.AnioLectivo = CShort(comboboxAnioLectivo.ComboBox.SelectedValue.ToString) And alc.IDCurso = CByte(comboboxCurso.ComboBox.SelectedValue.ToString)).First
            If Not AnioLectivoCurso Is Nothing Then
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

    Friend Sub SetAppearance()
        datagridviewMain.DefaultCellStyle.Font = My.Settings.GridsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsFont
    End Sub

    Private Sub formEntidadesAnioLectivoCurso_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbcEntidadesAnioLectivoCurso.Dispose()
    End Sub

    Private Sub formEntidades_Load() Handles Me.Load
        SetAppearance()

        FillAndRefreshLists.AnioLectivo(comboboxAnioLectivo.ComboBox, SortOrder.Descending)
        FillAndRefreshLists.Nivel(comboboxNivel.ComboBox, False)

        RefreshData()
    End Sub

    Private Sub ComboBoxesChanged() Handles comboboxAnioLectivo.SelectedIndexChanged, comboboxNivel.SelectedIndexChanged
        If (Not comboboxAnioLectivo.SelectedItem Is Nothing) And (Not comboboxNivel.SelectedItem Is Nothing) Then
            FillAndRefreshLists.CursoPorAnioLectivoYNivel(comboboxCurso.ComboBox, CInt(comboboxAnioLectivo.ComboBox.SelectedValue), CByte(comboboxNivel.ComboBox.SelectedValue))
        End If
    End Sub

    Private Sub comboboxCurso_SelectedIndexChanged() Handles comboboxCurso.SelectedIndexChanged
        RefreshData()
    End Sub

    Private Sub buttonAgregar_Click() Handles buttonAgregar.Click
        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            Dim EntidadNueva As Entidad = dbcEntidadesAnioLectivoCurso.Entidad.Find(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).Cells(formEntidadesSeleccionar.COLUMNA_IDENTIDAD).Value)
            AnioLectivoCurso.Entidades.Add(EntidadNueva)
            dbcEntidadesAnioLectivoCurso.SaveChanges()
            RefreshData()
        End If
        formEntidadesSeleccionar.Dispose()
    End Sub

    Private Sub buttonEliminar_Click() Handles buttonEliminar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Entidad para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ENTIDADANIOLECTIVOCURSO_DELETE) Then
                Dim EntidadEliminar = CType(datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
                If MsgBox("Se eliminará la Entidad seleccionada del Curso actual." & vbCrLf & vbCrLf & EntidadEliminar.ApellidoNombre & vbCrLf & vbCrLf & "¿Confirma la eliminación definitiva?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor
                    AnioLectivoCurso.Entidades.Remove(EntidadEliminar)
                    dbcEntidadesAnioLectivoCurso.SaveChanges()
                    RefreshData()
                    Me.Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub
End Class