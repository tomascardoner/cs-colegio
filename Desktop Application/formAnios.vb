Public Class formAnios

#Region "Declarations"
    Private Class GridRowData
        Public Property IDAnio As Byte
        Public Property IDNivel As Byte
        Public Property Nivel As String
        Public Property Nombre As String
        Public Property AnioSiguiente As String
        Public Property EsActivo As Boolean
    End Class

    Private mlistAniosBase As List(Of GridRowData)
    Private mlistAniosFiltradaYOrdenada As List(Of GridRowData)

    Private mSkipFilterData As Boolean = False
    Private mBusquedaAplicada As Boolean = False
    Private mReportSelectionFormula As String

    Private mOrdenColumna As DataGridViewColumn
    Private mOrdenTipo As SortOrder
#End Region

#Region "Form stuff"
    Friend Sub SetAppearance()
        datagridviewMain.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont
    End Sub

    Private Sub formAnios_Load() Handles Me.Load
        SetAppearance()

        mSkipFilterData = True

        pFillAndRefreshLists.Nivel(comboboxNivel.ComboBox, True, False)

        comboboxActivo.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, My.Resources.STRING_YES, My.Resources.STRING_NO})
        comboboxActivo.SelectedIndex = 1

        mSkipFilterData = False

        mOrdenColumna = columnNivel
        mOrdenTipo = SortOrder.Ascending

        RefreshData()
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub RefreshData(Optional ByVal PositionIDAnio As Integer = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)

        Me.Cursor = Cursors.WaitCursor

        Try
            Using dbContext As New CSColegioContext(True)
                mlistAniosBase = (From a In dbContext.Anio
                                  Join n In dbContext.Nivel On a.IDNivel Equals n.IDNivel
                                  Order By n.Nombre, a.Nombre
                                  Select New GridRowData With {.IDAnio = a.IDAnio, .IDNivel = a.IDNivel, .Nivel = n.Nombre, .Nombre = a.Nombre, .AnioSiguiente = "", .EsActivo = a.EsActivo}).ToList
            End Using

        Catch ex As Exception

            CS_Error.ProcessError(ex, "Error al leer los Años.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        Me.Cursor = Cursors.Default

        If RestoreCurrentPosition Then
            If datagridviewMain.CurrentRow Is Nothing Then
                PositionIDAnio = 0
            Else
                PositionIDAnio = CType(datagridviewMain.CurrentRow.DataBoundItem, GridRowData).IDAnio
            End If
        End If

        FilterData()

        If PositionIDAnio <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewMain.Rows
                If CType(CurrentRowChecked.DataBoundItem, GridRowData).IDAnio = PositionIDAnio Then
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
                mlistAniosFiltradaYOrdenada = mlistAniosBase.ToList

                ' Filtro por Nivel
                If comboboxNivel.SelectedIndex > 0 Then
                    mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, "", " AND ").ToString & String.Format("{{Anio.IDNivel}} = {0}", CByte(comboboxNivel.ComboBox.SelectedValue))
                    mlistAniosFiltradaYOrdenada = mlistAniosBase.Where(Function(a) a.IDNivel = CByte(comboboxNivel.ComboBox.SelectedValue)).ToList
                End If

                'Filtro por Activo
                Select Case comboboxActivo.SelectedIndex
                    Case 0      ' Todos
                    Case 1      ' Sí
                        mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, "", " AND ").ToString & "{Anio.EsActivo} = 1"
                        mlistAniosFiltradaYOrdenada = mlistAniosBase.Where(Function(a) a.EsActivo).ToList
                    Case 2      ' No
                        mReportSelectionFormula &= IIf(mReportSelectionFormula.Length = 0, "", " AND ").ToString & "{Anio.EsActivo} = 0"
                        mlistAniosFiltradaYOrdenada = mlistAniosBase.Where(Function(a) Not a.EsActivo).ToList
                End Select

                Select Case mlistAniosFiltradaYOrdenada.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Años para mostrar.")
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Año.")
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0} Años.", mlistAniosFiltradaYOrdenada.Count)
                End Select

            Catch ex As Exception
                CS_Error.ProcessError(ex, "Error al filtrar los datos.")
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
                    mlistAniosFiltradaYOrdenada = mlistAniosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                Else
                    mlistAniosFiltradaYOrdenada = mlistAniosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                End If
            Case columnNombre.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosFiltradaYOrdenada = mlistAniosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Nombre).ThenBy(Function(dgrd) dgrd.Nivel).ToList
                Else
                    mlistAniosFiltradaYOrdenada = mlistAniosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Nombre).ThenBy(Function(dgrd) dgrd.Nivel).ToList
                End If
            Case columnAnioSiguiente.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosFiltradaYOrdenada = mlistAniosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.AnioSiguiente).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                Else
                    mlistAniosFiltradaYOrdenada = mlistAniosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.AnioSiguiente).ThenBy(Function(dgrd) dgrd.Nivel).ThenByDescending(Function(dgrd) dgrd.Nombre).ToList
                End If
            Case columnEsActivo.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistAniosFiltradaYOrdenada = mlistAniosFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.EsActivo).ThenBy(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                Else
                    mlistAniosFiltradaYOrdenada = mlistAniosFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.EsActivo).ThenByDescending(Function(dgrd) dgrd.Nivel).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                End If
        End Select

        datagridviewMain.AutoGenerateColumns = False
        datagridviewMain.DataSource = mlistAniosFiltradaYOrdenada

        ' Muestro el ícono de orden en la columna correspondiente
        mOrdenColumna.HeaderCell.SortGlyphDirection = mOrdenTipo
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub CambioFiltros() Handles comboboxNivel.SelectedIndexChanged, comboboxActivo.SelectedIndexChanged
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
        If Permisos.VerificarPermiso(Permisos.ANIO_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formAnio.LoadAndShow(True, Me, 0)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Editar_Click() Handles buttonEditar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Año para editar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ANIO_EDITAR) Then
                Me.Cursor = Cursors.WaitCursor

                datagridviewMain.Enabled = False

                Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)
                Using dbContext = New CSColegioContext(True)
                    Dim AnioActual As Anio = dbContext.Anio.Find(CurrentRow.IDAnio)
                    formAnio.LoadAndShow(True, Me, CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData).IDAnio)
                End Using

                datagridviewMain.Enabled = True

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Eliminar_Click() Handles buttonEliminar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Año para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ANIO_ELIMINAR) Then

                Me.Cursor = Cursors.WaitCursor

                Dim CurrentRow As GridRowData = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData)

                Using dbContext = New CSColegioContext(True)
                    Dim AnioActual As Anio = dbContext.Anio.Find(CurrentRow.IDAnio)
                    Dim Mensaje As String
                    Mensaje = String.Format("Se eliminará el Año seleccionado.{0}{0}{1} - {2}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, CurrentRow.Nombre, CurrentRow.Nombre)
                    If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then

                        Try
                            dbContext.Anio.Remove(AnioActual)
                            dbContext.SaveChanges()

                        Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                            Select Case CS_Database_EF_SQL.TryDecodeDbUpdateException(dbuex)
                                Case Errors.RelatedEntity
                                    MsgBox("No se puede eliminar el Año porque tiene datos relacionados.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                            End Select
                            Me.Cursor = Cursors.Default
                            Exit Sub

                        Catch ex As Exception
                            CS_Error.ProcessError(ex, "Error al eliminar el Año.")
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
            MsgBox("No hay ningún Año para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formAnio.LoadAndShow(False, Me, CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData).IDAnio)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

End Class