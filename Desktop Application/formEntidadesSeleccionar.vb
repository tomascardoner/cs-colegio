Public Class formEntidadesSeleccionar

#Region "Declarations"
    Private listEntidadBase As List(Of Entidad)
    Private listEntidadFiltradaYOrdenada As List(Of Entidad)

    Private SkipFilterData As Boolean = False
    Private BusquedaAplicada As Boolean = False

    Private OrdenColumna As DataGridViewColumn
    Private OrdenTipo As SortOrder

    Friend Const COLUMNA_IDENTIDAD As String = "columnIDEntidad"
    Private Const COLUMNA_APELLIDO As String = "columnApellido"
    Private Const COLUMNA_NOMBRE As String = "columnNombre"
#End Region

#Region "Form stuff"
    Friend Sub SetAppearance()
        datagridviewMain.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont
    End Sub

    Private Sub formEntidadesSeleccionar_Load() Handles Me.Load
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
                                       Where ent.ApellidoNombre.ToLower.Contains(textboxBuscar.Text.ToLower.Trim) And (comboboxActivo.SelectedIndex = 0 Or (comboboxActivo.SelectedIndex = 1 And ent.EsActivo) Or (comboboxActivo.SelectedIndex = 2 And Not ent.EsActivo))
                                        Select ent).ToList
                Else
                    listEntidadFiltradaYOrdenada = (From ent In listEntidadBase
                                       Where comboboxActivo.SelectedIndex = 0 Or (comboboxActivo.SelectedIndex = 1 And ent.EsActivo) Or (comboboxActivo.SelectedIndex = 2 And Not ent.EsActivo)
                                       Select ent).ToList
                End If

            Else
                If BusquedaAplicada Then
                    listEntidadFiltradaYOrdenada = (From ent In listEntidadBase
                                Where ((menuitemEntidadTipo_PersonalColegio.Checked And ent.TipoPersonalColegio) Or (menuitemEntidadTipo_Docente.Checked And ent.TipoDocente) Or (menuitemEntidadTipo_Alumno.Checked And ent.TipoAlumno) Or (menuitemEntidadTipo_Familiar.Checked And ent.TipoFamiliar) Or (menuitemEntidadTipo_Proveedor.Checked And ent.TipoProveedor)) And ent.ApellidoNombre.ToLower.Contains(textboxBuscar.Text.ToLower.Trim) And (comboboxActivo.SelectedIndex = 0 Or (comboboxActivo.SelectedIndex = 1 And ent.EsActivo) Or (comboboxActivo.SelectedIndex = 2 And Not ent.EsActivo))
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

#End Region

#Region "Controls behavior"
    Private Sub formEntidadesSeleccionar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Not textboxBuscar.Focused Then
            If Char.IsLetter(e.KeyChar) Then
                For Each RowCurrent As DataGridViewRow In datagridviewMain.Rows
                    If RowCurrent.Cells(COLUMNA_APELLIDO).Value.ToString.StartsWith(e.KeyChar, StringComparison.CurrentCultureIgnoreCase) Then
                        RowCurrent.Cells(COLUMNA_IDENTIDAD).Selected = True
                        datagridviewMain.Focus()
                        Exit For
                    End If
                Next
            End If
        End If
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
#End Region

#Region "Main Toolbar"
    Private Sub Seleccionar() Handles datagridviewMain.DoubleClick, buttonSeleccionar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Entidad para seleccionar.", vbInformation, My.Application.Info.Title)
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

    Private Sub Cancelar() Handles buttonCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub datagridviewMain_KeyPress(sender As Object, e As KeyPressEventArgs) Handles datagridviewMain.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Seleccionar()
        ElseIf e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
            Cancelar()
        End If
    End Sub
#End Region

End Class