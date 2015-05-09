Public Class formEntidades
    Private listEntidadBase As List(Of Entidad)
    Private listEntidadFiltradaYOrdenada As List(Of Entidad)
    Private SkipFilterData As Boolean = False
    Private BusquedaAplicada As Boolean = False
    Private OrdenColumna As DataGridViewColumn
    Private OrdenTipo As SortOrder

    Private Const COLUMNA_IDENTIDAD As String = "columnIDEntidad"
    Private Const COLUMNA_APELLIDO As String = "columnApellido"
    Private Const COLUMNA_NOMBRE As String = "columnNombre"

    Friend Sub RefreshData(Optional ByVal PositionIDEntidad As Integer = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)
        Me.Cursor = Cursors.WaitCursor

        Using dbcEntidadList As New CSColegioContext
            listEntidadBase = dbcEntidadList.Entidad.ToList
        End Using

        Me.Cursor = Cursors.Default

        If RestoreCurrentPosition Then
            If datagridviewMain.CurrentRow Is Nothing Then
                PositionIDEntidad = 0
            Else
                PositionIDEntidad = CInt(datagridviewMain.CurrentRow.Cells(COLUMNA_IDENTIDAD).Value)
            End If
        End If

        FilterData()

        If PositionIDEntidad <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewMain.Rows
                If CInt(CurrentRowChecked.Cells(COLUMNA_IDENTIDAD).Value) = PositionIDEntidad Then
                    datagridviewMain.CurrentCell = CurrentRowChecked.Cells(COLUMNA_IDENTIDAD)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub FilterData()

        If Not SkipFilterData Then

            Me.Cursor = Cursors.WaitCursor

            If menuitemEntidadTipo_PersonalColegio.Checked And menuitemEntidadTipo_Docente.Checked And menuitemEntidadTipo_Alumno.Checked And menuitemEntidadTipo_Familiar.Checked And menuitemEntidadTipo_Proveedor.Checked Then
                'TODOS LOS TIPOS DE ENTIDAD SELECCIONADOS
                If BusquedaAplicada Then
                    listEntidadFiltradaYOrdenada = (From ent In listEntidadBase
                                       Where (ent.Apellido.ToLower.Contains(textboxBuscar.Text.ToLower.Trim) Or ent.Nombre.ToLower.Contains(textboxBuscar.Text.ToLower.Trim)) And (comboboxActivo.SelectedIndex = 0 Or (comboboxActivo.SelectedIndex = 1 And ent.EsActivo) Or (comboboxActivo.SelectedIndex = 2 And Not ent.EsActivo))
                                        Select ent).ToList
                Else
                    listEntidadFiltradaYOrdenada = (From ent In listEntidadBase
                                       Where comboboxActivo.SelectedIndex = 0 Or (comboboxActivo.SelectedIndex = 1 And ent.EsActivo) Or (comboboxActivo.SelectedIndex = 2 And Not ent.EsActivo)
                                       Select ent).ToList
                End If

            Else
                If BusquedaAplicada Then
                    listEntidadFiltradaYOrdenada = (From ent In listEntidadBase
                                Where ((menuitemEntidadTipo_PersonalColegio.Checked And ent.TipoPersonalColegio) Or (menuitemEntidadTipo_Docente.Checked And ent.TipoDocente) Or (menuitemEntidadTipo_Alumno.Checked And ent.TipoAlumno) Or (menuitemEntidadTipo_Familiar.Checked And ent.TipoFamiliar) Or (menuitemEntidadTipo_Proveedor.Checked And ent.TipoProveedor)) And (ent.Apellido.ToLower.Contains(textboxBuscar.Text.ToLower.Trim) Or ent.Nombre.ToLower.Contains(textboxBuscar.Text.ToLower.Trim)) And (comboboxActivo.SelectedIndex = 0 Or (comboboxActivo.SelectedIndex = 1 And ent.EsActivo) Or (comboboxActivo.SelectedIndex = 2 And Not ent.EsActivo))
                                Select ent).ToList
                Else
                    listEntidadFiltradaYOrdenada = (From ent In listEntidadBase
                                Where ((menuitemEntidadTipo_PersonalColegio.Checked And ent.TipoPersonalColegio) Or (menuitemEntidadTipo_Docente.Checked And ent.TipoDocente) Or (menuitemEntidadTipo_Alumno.Checked And ent.TipoAlumno) Or (menuitemEntidadTipo_Familiar.Checked And ent.TipoFamiliar) Or (menuitemEntidadTipo_Proveedor.Checked And ent.TipoProveedor)) And (comboboxActivo.SelectedIndex = 0 Or (comboboxActivo.SelectedIndex = 1 And ent.EsActivo) Or (comboboxActivo.SelectedIndex = 2 And Not ent.EsActivo))
                                Select ent).ToList
                End If

            End If

            OrderData()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub OrderData()
        ' Realizo las rutinas de ordenamiento
        Select Case OrdenColumna.Name
            Case COLUMNA_IDENTIDAD
                If OrdenTipo = SortOrder.Ascending Then
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.OrderBy(Function(col) col.IDEntidad).ToList
                Else
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.OrderByDescending(Function(col) col.IDEntidad).ToList
                End If
            Case COLUMNA_APELLIDO
                If OrdenTipo = SortOrder.Ascending Then
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.OrderBy(Function(col) col.Apellido & col.Nombre).ToList
                Else
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.OrderByDescending(Function(col) col.Apellido & col.Nombre).ToList
                End If
            Case COLUMNA_NOMBRE
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

    Friend Sub SetAppearance()
        datagridviewMain.DefaultCellStyle.Font = My.Settings.GridsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsFont
    End Sub

    Private Sub formEntidades_Load() Handles Me.Load
        SetAppearance()

        SkipFilterData = True

        comboboxActivo.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, My.Resources.STRING_YES, My.Resources.STRING_NO})
        comboboxActivo.SelectedIndex = 1

        SkipFilterData = False

        OrdenColumna = columnApellido
        OrdenTipo = SortOrder.Ascending

        RefreshData()
    End Sub

    Private Sub formEntidades_FormClosed() Handles Me.FormClosed
        listEntidadBase = Nothing
    End Sub

    Private Sub bindingsourceEntidad_ListChanged() Handles bindingsourceMain.ListChanged
        Select Case bindingsourceMain.Count
            Case 0
                statuslabelMain.Text = String.Format("No hay Entidades para mostrar.")
            Case 1
                statuslabelMain.Text = String.Format("Se muestra 1 Entidad.")
            Case Else
                statuslabelMain.Text = String.Format("Se muestran {0} Entidades.", bindingsourceMain.Count)
        End Select
    End Sub

    Private Sub menuitemEntidadTipo_Click() Handles menuitemEntidadTipo_PersonalColegio.Click, menuitemEntidadTipo_Docente.Click, menuitemEntidadTipo_Alumno.Click, menuitemEntidadTipo_Familiar.Click, menuitemEntidadTipo_Proveedor.Click
        FilterData()
    End Sub

    Private Sub menuitemMarcarYDesmarcarTodo_Click(sender As Object, e As EventArgs) Handles menuitemMarcarTodo.Click, menuitemDesmarcarTodo.Click
        SkipFilterData = True

        menuitemEntidadTipo_PersonalColegio.Checked = (CType(sender, ToolStripMenuItem).Name = "menuitemMarcarTodo")
        menuitemEntidadTipo_Docente.Checked = (CType(sender, ToolStripMenuItem).Name = "menuitemMarcarTodo")
        menuitemEntidadTipo_Alumno.Checked = (CType(sender, ToolStripMenuItem).Name = "menuitemMarcarTodo")
        menuitemEntidadTipo_Familiar.Checked = (CType(sender, ToolStripMenuItem).Name = "menuitemMarcarTodo")
        menuitemEntidadTipo_Proveedor.Checked = (CType(sender, ToolStripMenuItem).Name = "menuitemMarcarTodo")

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

    Private Sub datagridviewMain_CellContentDoubleClick() Handles datagridviewMain.CellDoubleClick
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Entidad para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            Dim formEntidadVer As New formEntidad

            With formEntidadVer
                .MdiParent = formMDIMain
                .EntidadCurrent = .FormDBContext.Entidad.Find(datagridviewMain.SelectedRows.Item(0).Cells(COLUMNA_IDENTIDAD).Value)
                CSM_Form.CenterToParent(Me, CType(formEntidadVer, Form))
                .buttonGuardar.Visible = False
                .buttonCancelar.Visible = False
                .InitializeFormAndControls()
                .SetDataFromObjectToControls()
                CSM_Form.ControlsChangeStateReadOnly(.Controls, True, True)
                .Show()
            End With

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub buttonAgregar_Click() Handles buttonAgregar.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDAD_ADD) Then
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            Dim formEntidadAgregar As New formEntidad

            With formEntidadAgregar
                .MdiParent = formMDIMain
                Dim EntidadAgregar = .FormDBContext.Entidad.Add(New Entidad)
                With EntidadAgregar
                    .DomicilioIDProvincia = CSM_Parameter.GetString(PARAMETRO_PROVINCIA_PREDETERMINADA)
                    .DomicilioIDLocalidad = CSM_Parameter.GetIntegerAsShort(PARAMETRO_LOCALIDAD_PREDETERMINADA)
                    .DomicilioCodigoPostal = CSM_Parameter.GetString(PARAMETRO_CODIGOPOSTAL_PREDETERMINADO)
                    .EsActivo = True
                    .IDUsuarioCreacion = pUsuario.IDUsuario
                    .FechaHoraCreacion = Now
                    .IDUsuarioModificacion = pUsuario.IDUsuario
                    .FechaHoraModificacion = .FechaHoraCreacion
                End With
                .EntidadCurrent = EntidadAgregar
                CSM_Form.CenterToParent(Me, CType(formEntidadAgregar, Form))
                .buttonEditar.Visible = False
                .buttonCerrar.Visible = False
                .InitializeFormAndControls()
                .SetDataFromObjectToControls()
                .Show()
            End With

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub buttonEditar_Click() Handles buttonEditar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Entidad para editar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ENTIDAD_EDIT) Then
                Me.Cursor = Cursors.WaitCursor

                datagridviewMain.Enabled = False

                Dim formEntidadEditar As New formEntidad

                With formEntidadEditar
                    .MdiParent = formMDIMain
                    .EntidadCurrent = .FormDBContext.Entidad.Find(datagridviewMain.SelectedRows.Item(0).Cells(COLUMNA_IDENTIDAD).Value)
                    CSM_Form.CenterToParent(Me, CType(formEntidadEditar, Form))
                    .buttonEditar.Visible = False
                    .buttonCerrar.Visible = False
                    .InitializeFormAndControls()
                    .SetDataFromObjectToControls()
                    .Show()
                End With

                datagridviewMain.Enabled = True

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub buttonEliminar_Click() Handles buttonEliminar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Entidad para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ENTIDAD_DELETE) Then
                Using DBContextEliminar = New CSColegioContext
                    Dim EntidadEliminar = DBContextEliminar.Entidad.Find(datagridviewMain.SelectedRows.Item(0).Cells(COLUMNA_IDENTIDAD).Value)
                    If MsgBox("Se eliminará la Entidad seleccionada." & vbCrLf & vbCrLf & EntidadEliminar.ApellidoNombre & vbCrLf & vbCrLf & "¿Confirma la eliminación definitiva?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                        Me.Cursor = Cursors.WaitCursor
                        DBContextEliminar.Entidad.Remove(EntidadEliminar)
                        DBContextEliminar.SaveChanges()
                        RefreshData()
                        Me.Cursor = Cursors.Default
                    End If
                End Using
            End If
        End If
    End Sub

    Private Sub GridChangeOrder(sender As Object, e As DataGridViewCellMouseEventArgs) Handles datagridviewMain.ColumnHeaderMouseClick
        Dim ClickedColumn As DataGridViewColumn

        ClickedColumn = CType(datagridviewMain.Columns(e.ColumnIndex), DataGridViewColumn)

        If ClickedColumn.Name = COLUMNA_IDENTIDAD Or ClickedColumn.Name = COLUMNA_APELLIDO Or ClickedColumn.Name = COLUMNA_NOMBRE Then
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
End Class