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
        datagridviewMain.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont
    End Sub

    Private Sub formEntidades_Load() Handles Me.Load
        SetAppearance()

        SkipFilterData = True

        comboboxBuscar.Items.AddRange({"nombre:", "documento:"})
        comboboxBuscar.SelectedIndex = 0

        comboboxActivo.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, My.Resources.STRING_YES, My.Resources.STRING_NO})
        comboboxActivo.SelectedIndex = 1

        comboboxVerificarDocumento.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, My.Resources.STRING_YES, My.Resources.STRING_NO})
        comboboxVerificarDocumento.SelectedIndex = 0

        comboboxVerificarEmail.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, My.Resources.STRING_YES, My.Resources.STRING_NO})
        comboboxVerificarEmail.SelectedIndex = 0

        SkipFilterData = False

        OrdenColumna = columnApellido
        OrdenTipo = SortOrder.Ascending

        RefreshData()
    End Sub

    Private Sub formEntidades_FormClosed() Handles Me.FormClosed
        listEntidadBase = Nothing
        listEntidadFiltradaYOrdenada = Nothing
    End Sub

#End Region

#Region "Load and Set Data"

    Friend Sub RefreshData(Optional ByVal PositionIDEntidad As Integer = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)
        If SkipFilterData Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Using dbcontext As New CSColegioContext(True)
            Select Case comboboxActivo.SelectedIndex
                Case 0
                    listEntidadBase = dbcontext.Entidad.ToList()
                Case 1
                    listEntidadBase = dbcontext.Entidad.Where(Function(e) e.EsActivo).ToList()
                Case 2
                    listEntidadBase = dbcontext.Entidad.Where(Function(e) Not e.EsActivo).ToList()
                Case Else
            End Select
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

        If SkipFilterData Then
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        Try

            listEntidadFiltradaYOrdenada = listEntidadBase

            ' Tipos de Entidad
            If Not (menuitemEntidadTipo_PersonalColegio.Checked And menuitemEntidadTipo_Docente.Checked And menuitemEntidadTipo_Alumno.Checked And menuitemEntidadTipo_Familiar.Checked And menuitemEntidadTipo_Proveedor.Checked And menuitemEntidadTipo_Otro.Checked) Then
                listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.Where(Function(e) (menuitemEntidadTipo_PersonalColegio.Checked And e.TipoPersonalColegio) Or (menuitemEntidadTipo_Docente.Checked And e.TipoDocente) Or (menuitemEntidadTipo_Alumno.Checked And e.TipoAlumno) Or (menuitemEntidadTipo_Familiar.Checked And e.TipoFamiliar) Or (menuitemEntidadTipo_Proveedor.Checked And e.TipoProveedor) Or (menuitemEntidadTipo_Otro.Checked And e.TipoOtro)).ToList()
            End If

            ' Verificar documento
            Select Case comboboxVerificarDocumento.SelectedIndex
                Case 0
                    ' Todos
                Case 1
                    ' Si
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.Where(Function(e) (e.IDDocumentoTipo IsNot Nothing AndAlso Not e.DocumentoNumeroVerificado) Or (e.FacturaIDDocumentoTipo IsNot Nothing AndAlso Not e.FacturaDocumentoNumeroVerificado)).ToList()
                Case 2
                    ' No
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.Where(Function(e) (e.IDDocumentoTipo Is Nothing Or e.DocumentoNumeroVerificado) And (e.FacturaIDDocumentoTipo Is Nothing Or e.FacturaDocumentoNumeroVerificado)).ToList()
            End Select

            ' Verificar e-mail
            Select Case comboboxVerificarEmail.SelectedIndex
                Case 0
                    ' Todos
                Case 1
                    ' Si
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.Where(Function(e) e.VerificarEmail1 Or e.VerificarEmail2).ToList()
                Case 2
                    ' No
                    listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.Where(Function(e) Not (e.VerificarEmail1 Or e.VerificarEmail2)).ToList()
            End Select

            ' Búsqueda
            If BusquedaAplicada Then
                Select Case comboboxBuscar.SelectedIndex
                    Case 0
                        ' Nombre
                        listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.Where(Function(e) e.ApellidoNombre.ToLower().RemoveDiacritics().Contains(textboxBuscar.Text.ToLower().RemoveDiacritics().Trim())).ToList()
                    Case 1
                        ' Documento
                        listEntidadFiltradaYOrdenada = listEntidadFiltradaYOrdenada.Where(Function(e) (e.DocumentoNumero IsNot Nothing AndAlso e.DocumentoNumero.ToLower().Contains(textboxBuscar.Text.ToLower().Trim())) Or (e.FacturaDocumentoNumero IsNot Nothing AndAlso e.FacturaDocumentoNumero.ToLower().Contains(textboxBuscar.Text.ToLower().Trim()))).ToList()
                End Select
            End If

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al filtrar los datos.")
        End Try

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

    Private Sub Me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
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

    Private Sub ToolstripTextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxBuscar.GotFocus
        CType(sender, ToolStripTextBox).SelectAll()
    End Sub

    Private Sub BuscarCambiarTipo(sender As Object, e As EventArgs) Handles comboboxBuscar.SelectedIndexChanged
        If comboboxBuscar.SelectedIndex = 0 Then
            textboxBuscar.MaxLength = 100
        Else
            textboxBuscar.Text = textboxBuscar.Text.Truncate(12)
            textboxBuscar.MaxLength = 12
        End If
        If textboxBuscar.Text.Trim().Length >= 3 Then
            FilterData()
        End If
    End Sub

    Private Sub Buscar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles textboxBuscar.KeyPress
        If e.KeyChar = ChrW(Keys.Return) Then
            If textboxBuscar.Text.Trim.Length < 3 Then
                MsgBox("Se deben especificar al menos 3 caracteres para buscar.", MsgBoxStyle.Information, My.Application.Info.Title)
                textboxBuscar.Focus()
            Else
                BusquedaAplicada = True
                FilterData()
            End If
            e.Handled = True
        End If
    End Sub

    Private Sub Buscar_Borrar() Handles buttonBuscarBorrar.Click
        If BusquedaAplicada Then
            textboxBuscar.Clear()
            BusquedaAplicada = False
            FilterData()
        End If
    End Sub

    Private Sub RefrescarDatos() Handles comboboxActivo.SelectedIndexChanged
        RefreshData()
    End Sub

    Private Sub AplicarFiltros() Handles menuitemEntidadTipo_PersonalColegio.Click, menuitemEntidadTipo_Docente.Click, menuitemEntidadTipo_Alumno.Click, menuitemEntidadTipo_Familiar.Click, menuitemEntidadTipo_Proveedor.Click, menuitemEntidadTipo_Otro.Click, comboboxVerificarDocumento.SelectedIndexChanged, comboboxVerificarEmail.SelectedIndexChanged
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

#End Region

#Region "Main Toolbar"

    Private Sub Agregar(sender As Object, e As EventArgs) Handles buttonAgregar.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDAD_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formEntidad.LoadAndShow(True, Me, 0)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Editar(sender As Object, e As EventArgs) Handles buttonEditar.Click
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

    Private Sub Eliminar(sender As Object, e As EventArgs) Handles buttonEliminar.Click
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
                        Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                            Case CardonerSistemas.Database.EntityFramework.Errors.RelatedEntity
                                MsgBox("No se puede eliminar la Entidad porque tiene datos relacionados.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                        End Select
                        Exit Sub

                    Catch ex As Exception
                        CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al eliminar la Entidad.")
                    End Try

                    RefreshData()

                    Me.Cursor = Cursors.Default
                End If
            End If
        End If
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

    Private Sub SincronizarOutlook(sender As Object, e As EventArgs) Handles buttonSincronizarOutlook.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDAD_SINCRONIZAR_OUTLOOK) Then
            formEntidadesSincronizarOutlook.ShowDialog(pFormMDIMain)
        End If
    End Sub

#End Region

End Class