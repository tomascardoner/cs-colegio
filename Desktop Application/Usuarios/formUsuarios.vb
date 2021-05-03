Public Class formUsuarios

#Region "Declarations"
    Friend Class GridRowData
        Public Property IDUsuario As Short
        Public Property Nombre As String
        Public Property Descripcion As String
        Public Property IDUsuarioGrupo As Byte
        Public Property UsuarioGrupoNombre As String
        Public Property IDCuartel As Byte?
        Public Property CuartelNombre As String
        Public Property EsActivo As Boolean
    End Class

    Private mlistUsuariosBase As List(Of GridRowData)
    Private mlistUsuariosFiltradaYOrdenada As List(Of GridRowData)

    Private mSkipFilterData As Boolean = False

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

        pFillAndRefreshLists.UsuarioGrupo(comboboxUsuarioGrupo.ComboBox, True, True, False)

        comboboxActivo.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, My.Resources.STRING_YES, My.Resources.STRING_NO})
        comboboxActivo.SelectedIndex = 1

        mSkipFilterData = False

        mOrdenColumna = columnNombre
        mOrdenTipo = SortOrder.Ascending

        RefreshData()
    End Sub
#End Region

#Region "Load and Set Data"

    Friend Sub RefreshData(Optional ByVal PositionIDUsuario As Integer = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)

        Me.Cursor = Cursors.WaitCursor

        Try
            Using dbContext As New CSColegioContext(True)
                mlistUsuariosBase = (From u In dbContext.Usuario
                                     Join ug In dbContext.UsuarioGrupo On u.IDUsuarioGrupo Equals ug.IDUsuarioGrupo
                                     Select New GridRowData With {.IDUsuario = u.IDUsuario, .Nombre = u.Nombre, .Descripcion = u.Descripcion, .IDUsuarioGrupo = u.IDUsuarioGrupo, .UsuarioGrupoNombre = ug.Nombre, .EsActivo = u.EsActivo}).ToList
            End Using

        Catch ex As Exception

            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer los Usuarios.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        Me.Cursor = Cursors.Default

        If RestoreCurrentPosition Then
            If datagridviewMain.CurrentRow Is Nothing Then
                PositionIDUsuario = 0
            Else
                PositionIDUsuario = CType(datagridviewMain.CurrentRow.DataBoundItem, GridRowData).IDUsuario
            End If
        End If

        FilterData()

        If PositionIDUsuario <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewMain.Rows
                If CType(CurrentRowChecked.DataBoundItem, GridRowData).IDUsuario = PositionIDUsuario Then
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
                mlistUsuariosFiltradaYOrdenada = mlistUsuariosBase.ToList

                ' Filtro por Grupo
                If comboboxUsuarioGrupo.SelectedIndex > 0 Then
                    mlistUsuariosFiltradaYOrdenada = mlistUsuariosFiltradaYOrdenada.Where(Function(p) p.IDUsuarioGrupo = CByte(comboboxUsuarioGrupo.ComboBox.SelectedValue)).ToList
                End If

                'Filtro por Activo
                Select Case comboboxActivo.SelectedIndex
                    Case 0      ' Todos
                    Case 1      ' Sí
                        mlistUsuariosFiltradaYOrdenada = mlistUsuariosFiltradaYOrdenada.Where(Function(a) a.EsActivo).ToList
                    Case 2      ' No
                        mlistUsuariosFiltradaYOrdenada = mlistUsuariosFiltradaYOrdenada.Where(Function(a) Not a.EsActivo).ToList
                End Select

                Select Case mlistUsuariosFiltradaYOrdenada.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Usuarios para mostrar.")
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Usuario.")
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0} Usuarios.", mlistUsuariosFiltradaYOrdenada.Count)
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
            Case columnNombre.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistUsuariosFiltradaYOrdenada = mlistUsuariosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Nombre).ThenBy(Function(dgrd) dgrd.EsActivo).ToList
                Else
                    mlistUsuariosFiltradaYOrdenada = mlistUsuariosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Nombre).ThenBy(Function(dgrd) dgrd.EsActivo).ToList
                End If
            Case columnDescripcion.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistUsuariosFiltradaYOrdenada = mlistUsuariosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Descripcion).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                Else
                    mlistUsuariosFiltradaYOrdenada = mlistUsuariosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Descripcion).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                End If
            Case columnUsuarioGrupo.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistUsuariosFiltradaYOrdenada = mlistUsuariosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.UsuarioGrupoNombre).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                Else
                    mlistUsuariosFiltradaYOrdenada = mlistUsuariosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.UsuarioGrupoNombre).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                End If
            Case columnCuartel.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistUsuariosFiltradaYOrdenada = mlistUsuariosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.CuartelNombre).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                Else
                    mlistUsuariosFiltradaYOrdenada = mlistUsuariosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.CuartelNombre).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                End If
            Case columnEsActivo.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistUsuariosFiltradaYOrdenada = mlistUsuariosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.EsActivo).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                Else
                    mlistUsuariosFiltradaYOrdenada = mlistUsuariosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.EsActivo).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                End If
        End Select

        datagridviewMain.AutoGenerateColumns = False
        datagridviewMain.DataSource = mlistUsuariosFiltradaYOrdenada

        ' Muestro el ícono de orden en la columna correspondiente
        mOrdenColumna.HeaderCell.SortGlyphDirection = mOrdenTipo
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub Me_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            For Each RowCurrent As DataGridViewRow In datagridviewMain.Rows
                If RowCurrent.Cells(columnNombre.Name).Value.ToString.StartsWith(e.KeyChar, StringComparison.CurrentCultureIgnoreCase) Then
                    RowCurrent.Cells(columnNombre.Name).Selected = True
                    datagridviewMain.Focus()
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub CambioFiltros() Handles comboboxUsuarioGrupo.SelectedIndexChanged, comboboxActivo.SelectedIndexChanged
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
        If Permisos.VerificarPermiso(Permisos.USUARIO_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            formUsuario.LoadAndShow(True, Me, 0)

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Editar_Click() Handles buttonEditar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Usuario para editar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.USUARIO_EDITAR) Then
                Me.Cursor = Cursors.WaitCursor

                formUsuario.LoadAndShow(True, Me, CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData).IDUsuario)

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Eliminar_Click() Handles buttonEliminar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Usuario para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.USUARIO_ELIMINAR) Then
                Me.Cursor = Cursors.WaitCursor

                Dim Mensaje As String

                Mensaje = String.Format("Se eliminará la Usuario seleccionada.{0}{0}Nombre: {1}{0}Cuartel: {2}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData).Nombre, CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData).CuartelNombre)
                If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then

                    Try
                        Using dbContext = New CSColegioContext(True)
                            Dim UsuarioEliminar As Usuario

                            UsuarioEliminar = dbContext.Usuario.Find(CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData).IDUsuario)
                            dbContext.Usuario.Remove(UsuarioEliminar)
                            dbContext.SaveChanges()
                            UsuarioEliminar = Nothing
                        End Using

                    Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                        Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                            Case CardonerSistemas.Database.EntityFramework.Errors.RelatedEntity
                                MsgBox("No se puede eliminar la Usuario porque tiene datos relacionados.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                        End Select
                        Me.Cursor = Cursors.Default
                        Exit Sub

                    Catch ex As Exception
                        CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al eliminar la Usuario.")
                    End Try

                    RefreshData()

                End If

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Ver() Handles datagridviewMain.DoubleClick
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Usuario para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            formUsuario.LoadAndShow(False, Me, CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData).IDUsuario)

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CambioFiltros(sender As Object, e As EventArgs) Handles comboboxActivo.SelectedIndexChanged, comboboxUsuarioGrupo.SelectedIndexChanged

    End Sub

#End Region

End Class