Public Class formEntidades

#Region "Declarations"
    Private listEntidadBase As List(Of Entidad)
    Private listEntidadFiltradaYOrdenada As List(Of Entidad)

    Private SkipFilterData As Boolean = False
    Private BusquedaAplicada As Boolean = False

    Private OrdenColumna As DataGridViewColumn
    Private OrdenTipo As SortOrder
#End Region

#Region "Form stuff"
    Friend Sub SetAppearance()
        datagridviewMain.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont
    End Sub

    Private Sub formEntidades_Load() Handles Me.Load
        SetAppearance()

        SkipFilterData = True

        comboboxActivo.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, My.Resources.STRING_YES, My.Resources.STRING_NO})
        comboboxActivo.SelectedIndex = 1

        comboboxVerificarEmail.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, My.Resources.STRING_YES, My.Resources.STRING_NO})
        comboboxVerificarEmail.SelectedIndex = 0

        SkipFilterData = False

        OrdenColumna = columnApellido
        OrdenTipo = SortOrder.Ascending

        RefreshData()
    End Sub

    Private Sub formEntidades_FormClosed() Handles Me.FormClosed
        listEntidadBase = Nothing
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub RefreshData(Optional ByVal PositionIDEntidad As Integer = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)
        Me.Cursor = Cursors.WaitCursor

        Using dbcontext As New CSColegioContext(True)
            listEntidadBase = dbcontext.Entidad.ToList
        End Using

        Me.Cursor = Cursors.Default

        If RestoreCurrentPosition Then
            If datagridviewMain.CurrentRow Is Nothing Then
                PositionIDEntidad = 0
            Else
                PositionIDEntidad = CInt(datagridviewMain.CurrentRow.Cells(columnIDEntidad.Name).Value)
            End If
        End If

        FilterData()

        If PositionIDEntidad <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewMain.Rows
                If CInt(CurrentRowChecked.Cells(columnIDEntidad.Name).Value) = PositionIDEntidad Then
                    datagridviewMain.CurrentCell = CurrentRowChecked.Cells(columnIDEntidad.Name)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub FilterData()

        If Not SkipFilterData Then

            Me.Cursor = Cursors.WaitCursor

            If menuitemEntidadTipo_PersonalColegio.Checked And menuitemEntidadTipo_Docente.Checked And menuitemEntidadTipo_Alumno.Checked And menuitemEntidadTipo_Familiar.Checked And menuitemEntidadTipo_Proveedor.Checked Then
                ' Todos los Tipos de Entidad
                If BusquedaAplicada Then
                    listEntidadFiltradaYOrdenada = (From ent In listEntidadBase
                                                    Where ent.ApellidoNombre.ToLower.Contains(textboxBuscar.Text.ToLower.Trim) And (comboboxActivo.SelectedIndex = 0 Or (comboboxActivo.SelectedIndex = 1 And ent.EsActivo) Or (comboboxActivo.SelectedIndex = 2 And Not ent.EsActivo)) And (comboboxVerificarEmail.SelectedIndex = 0 Or (comboboxVerificarEmail.SelectedIndex = 1 And (ent.VerificarEmail1 Or ent.VerificarEmail2)) Or (comboboxVerificarEmail.SelectedIndex = 2 And Not (ent.VerificarEmail1 Or ent.VerificarEmail2)))
                                                    Select ent).ToList
                Else
                    listEntidadFiltradaYOrdenada = (From ent In listEntidadBase
                                                    Where (comboboxActivo.SelectedIndex = 0 Or (comboboxActivo.SelectedIndex = 1 And ent.EsActivo) Or (comboboxActivo.SelectedIndex = 2 And Not ent.EsActivo)) And (comboboxVerificarEmail.SelectedIndex = 0 Or (comboboxVerificarEmail.SelectedIndex = 1 And (ent.VerificarEmail1 Or ent.VerificarEmail2)) Or (comboboxVerificarEmail.SelectedIndex = 2 And Not (ent.VerificarEmail1 Or ent.VerificarEmail2)))
                                                    Select ent).ToList
                End If

            Else
                If BusquedaAplicada Then
                    listEntidadFiltradaYOrdenada = (From ent In listEntidadBase
                                                    Where ((menuitemEntidadTipo_PersonalColegio.Checked And ent.TipoPersonalColegio) Or (menuitemEntidadTipo_Docente.Checked And ent.TipoDocente) Or (menuitemEntidadTipo_Alumno.Checked And ent.TipoAlumno) Or (menuitemEntidadTipo_Familiar.Checked And ent.TipoFamiliar) Or (menuitemEntidadTipo_Proveedor.Checked And ent.TipoProveedor) Or (menuitemEntidadTipo_Otro.Checked And ent.TipoOtro)) And ent.ApellidoNombre.ToLower.Contains(textboxBuscar.Text.ToLower.Trim) And (comboboxActivo.SelectedIndex = 0 Or (comboboxActivo.SelectedIndex = 1 And ent.EsActivo) Or (comboboxActivo.SelectedIndex = 2 And Not ent.EsActivo)) And (comboboxVerificarEmail.SelectedIndex = 0 Or (comboboxVerificarEmail.SelectedIndex = 1 And (ent.VerificarEmail1 Or ent.VerificarEmail2)) Or (comboboxVerificarEmail.SelectedIndex = 2 And Not (ent.VerificarEmail1 Or ent.VerificarEmail2)))
                                                    Select ent).ToList
                Else
                    listEntidadFiltradaYOrdenada = (From ent In listEntidadBase
                                                    Where ((menuitemEntidadTipo_PersonalColegio.Checked And ent.TipoPersonalColegio) Or (menuitemEntidadTipo_Docente.Checked And ent.TipoDocente) Or (menuitemEntidadTipo_Alumno.Checked And ent.TipoAlumno) Or (menuitemEntidadTipo_Familiar.Checked And ent.TipoFamiliar) Or (menuitemEntidadTipo_Proveedor.Checked And ent.TipoProveedor) Or (menuitemEntidadTipo_Otro.Checked And ent.TipoOtro)) And (comboboxActivo.SelectedIndex = 0 Or (comboboxActivo.SelectedIndex = 1 And ent.EsActivo) Or (comboboxActivo.SelectedIndex = 2 And Not ent.EsActivo)) And (comboboxVerificarEmail.SelectedIndex = 0 Or (comboboxVerificarEmail.SelectedIndex = 1 And (ent.VerificarEmail1 Or ent.VerificarEmail2)) Or (comboboxVerificarEmail.SelectedIndex = 2 And Not (ent.VerificarEmail1 Or ent.VerificarEmail2)))
                                                    Select ent).ToList
                End If

            End If

            Select Case listEntidadFiltradaYOrdenada.Count
                Case 0
                    statuslabelMain.Text = String.Format("No hay Entidades para mostrar.")
                Case 1
                    statuslabelMain.Text = String.Format("Se muestra 1 Entidad.")
                Case Else
                    statuslabelMain.Text = String.Format("Se muestran {0} Entidades.", listEntidadFiltradaYOrdenada.Count)
            End Select

            OrderData()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub OrderData()
        ' Realizo las rutinas de ordenamiento
        Select Case OrdenColumna.Name
            Case columnIDEntidad.Name
                If OrdenTipo = SortOrder.Ascending Then
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.OrderBy(Function(col) col.IDEntidad).ToList
                Else
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.OrderByDescending(Function(col) col.IDEntidad).ToList
                End If
            Case columnApellido.Name
                If OrdenTipo = SortOrder.Ascending Then
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.OrderBy(Function(col) col.Apellido & col.Nombre).ToList
                Else
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.OrderByDescending(Function(col) col.Apellido & col.Nombre).ToList
                End If
            Case columnNombre.Name
                If OrdenTipo = SortOrder.Ascending Then
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.OrderBy(Function(col) col.Nombre & col.Apellido).ToList
                Else
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.OrderByDescending(Function(col) col.Nombre & col.Apellido).ToList
                End If
        End Select
        bindingsourceMain.DataSource = listEntidadFiltradaYOrdenada

        ' Muestro el ícono de orden en la columna correspondiente
        OrdenColumna.HeaderCell.SortGlyphDirection = OrdenTipo
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub formEntidades_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Not textboxBuscar.Focused Then
            If Char.IsLetter(e.KeyChar) Then
                For Each RowCurrent As DataGridViewRow In datagridviewMain.Rows
                    If RowCurrent.Cells(columnApellido.Name).Value.ToString.StartsWith(e.KeyChar, StringComparison.CurrentCultureIgnoreCase) Then
                        RowCurrent.Cells(columnIDEntidad.Name).Selected = True
                        datagridviewMain.Focus()
                        Exit For
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub EntidadTipo_Click() Handles menuitemEntidadTipo_PersonalColegio.Click, menuitemEntidadTipo_Docente.Click, menuitemEntidadTipo_Alumno.Click, menuitemEntidadTipo_Familiar.Click, menuitemEntidadTipo_Proveedor.Click, menuitemEntidadTipo_Otro.Click
        FilterData()
    End Sub

    Private Sub MarcarYDesmarcarTodo_Click(sender As Object, e As EventArgs) Handles menuitemMarcarTodos.Click, menuitemDesmarcarTodos.Click
        SkipFilterData = True

        menuitemEntidadTipo_PersonalColegio.Checked = (CType(sender, ToolStripMenuItem) Is menuitemMarcarTodos)
        menuitemEntidadTipo_Docente.Checked = (CType(sender, ToolStripMenuItem) Is menuitemMarcarTodos)
        menuitemEntidadTipo_Alumno.Checked = (CType(sender, ToolStripMenuItem) Is menuitemMarcarTodos)
        menuitemEntidadTipo_Familiar.Checked = (CType(sender, ToolStripMenuItem) Is menuitemMarcarTodos)
        menuitemEntidadTipo_Proveedor.Checked = (CType(sender, ToolStripMenuItem) Is menuitemMarcarTodos)
        menuitemEntidadTipo_Otro.Checked = (CType(sender, ToolStripMenuItem) Is menuitemMarcarTodos)

        SkipFilterData = False

        FilterData()
    End Sub

    Private Sub textboxBuscar_GotFocus() Handles textboxBuscar.GotFocus
        textboxBuscar.SelectAll()
    End Sub

    Private Sub textboxBuscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textboxBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            If textboxBuscar.Text.Trim.Length < 3 Then
                MsgBox("Se deben especificar al menos 3 letras para buscar.", MsgBoxStyle.Information, My.Application.Info.Title)
                textboxBuscar.Focus()
            Else
                BusquedaAplicada = True
                FilterData()
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub buttonBuscarBorrar_Click() Handles buttonBuscarBorrar.Click
        If BusquedaAplicada Then
            textboxBuscar.Clear()
            BusquedaAplicada = False
            FilterData()
        End If
    End Sub

    Private Sub comboboxActivo_SelectedIndexChanged() Handles comboboxActivo.SelectedIndexChanged
        FilterData()
    End Sub

    Private Sub comboboxVerificarEmail_SelectedIndexChanged() Handles comboboxVerificarEmail.SelectedIndexChanged
        FilterData()
    End Sub

    Private Sub GridChangeOrder(sender As Object, e As DataGridViewCellMouseEventArgs) Handles datagridviewMain.ColumnHeaderMouseClick
        Dim ClickedColumn As DataGridViewColumn

        ClickedColumn = CType(datagridviewMain.Columns(e.ColumnIndex), DataGridViewColumn)

        If ClickedColumn.Name = columnIDEntidad.Name Or ClickedColumn.Name = columnApellido.Name Or ClickedColumn.Name = columnNombre.Name Then
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
        End If

        OrderData()
    End Sub

    Private Sub Ver() Handles datagridviewMain.DoubleClick
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Entidad para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            Dim EntidadActual = CType(datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
            If comboboxVerificarEmail.SelectedIndex <> 1 Then
                EntidadActual.VerificarEmail(True)
            End If
            formEntidad.LoadAndShow(False, Me, EntidadActual.IDEntidad)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub
#End Region

#Region "Main Toolbar"
    Private Sub Agregar_Click() Handles buttonAgregar.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDAD_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formEntidad.LoadAndShow(True, Me, 0)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Editar_Click() Handles buttonEditar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Entidad para editar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ENTIDAD_EDITAR) Then
                Me.Cursor = Cursors.WaitCursor

                datagridviewMain.Enabled = False

                Dim EntidadActual = CType(datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
                If comboboxVerificarEmail.SelectedIndex <> 1 Then
                    EntidadActual.VerificarEmail(True)
                End If
                formEntidad.LoadAndShow(True, Me, EntidadActual.IDEntidad)

                datagridviewMain.Enabled = True

                Me.Cursor = Cursors.Default
            End If
            End If
    End Sub

    Private Sub Eliminar_Click() Handles buttonEliminar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Entidad para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ENTIDAD_ELIMINAR) Then

                Dim EntidadActual = CType(datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)

                If MsgBox("Se eliminará la Entidad seleccionada." & vbCrLf & vbCrLf & EntidadActual.ApellidoNombre & vbCrLf & vbCrLf & "¿Confirma la eliminación definitiva?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                    Me.Cursor = Cursors.WaitCursor

                    Try
                        Using dbContext = New CSColegioContext(True)
                            dbContext.Entidad.Attach(EntidadActual)
                            dbContext.Entidad.Remove(EntidadActual)
                            dbContext.SaveChanges()
                        End Using

                    Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                        Me.Cursor = Cursors.Default
                        Select Case CS_Database_EF_SQL.TryDecodeDbUpdateException(dbuex)
                            Case Errors.RelatedEntity
                                MsgBox("No se puede eliminar la Entidad porque tiene datos relacionados.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                        End Select
                        Exit Sub

                    Catch ex As Exception
                        CS_Error.ProcessError(ex, "Error al eliminar la Entidad.")
                    End Try

                    RefreshData()

                    Me.Cursor = Cursors.Default
                End If
            End If
        End If
    End Sub
#End Region

End Class