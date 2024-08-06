Public Class FormLiquidacionesEntidades

#Region "Declarations"

    Private _IdSueldoLiquidacion As Short
    Private _SueldoLiquidacionTexto As String

    Private Class DataGridRowData
        Public Property IdEntidad As Integer
        Public Property EntidadApellidoNombre As String
        Public Property ModuloCantidad As Decimal?
        Public Property Antiguedad As Decimal?
    End Class

    Private _EntitiesAll As List(Of DataGridRowData)
    Private _EntitiesFiltered As List(Of DataGridRowData)

    Private mSkipFilterData As Boolean = False
    Private mBusquedaAplicada As Boolean = False

    Private _OrderColumn As DataGridViewColumn
    Private _OrderType As SortOrder

#End Region

#Region "Form stuff"

    Friend Sub SetAppearance()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.ImageSueldo32)
        ToolStripLabelLiquidacionDatos.Text = $"Período: " & _SueldoLiquidacionTexto

        DataGridViewMain.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        DataGridViewMain.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont
    End Sub

    Friend Sub InitializeFormAndShow(idSueldoLiquidacion As Short, anio As Short, mesNombre As String)
        _IdSueldoLiquidacion = idSueldoLiquidacion
        _SueldoLiquidacionTexto = $"{mesNombre} de {anio}"

        SetAppearance()

        _OrderColumn = DataGridViewColumnEntidad
        _OrderType = SortOrder.Ascending

        ReadData()
        CardonerSistemas.Forms.MdiChildShow(CType(pFormMDIMain, Form), Me, False)
    End Sub

    Private Sub Me_Load() Handles Me.Load
        _OrderColumn.HeaderCell.SortGlyphDirection = _OrderType
    End Sub

#End Region

#Region "Mostrar y leer datos"

    Friend Sub ReadData(Optional idEntidad As Integer = 0, Optional restoreCurrentPosition As Boolean = False)
        Me.Cursor = Cursors.WaitCursor

        Try
            Using dbContext As New CSColegioContext(True)
                _EntitiesAll = (From sle In dbContext.SueldoLiquidacionEntidad
                                Join e In dbContext.Entidad On sle.IdEntidad Equals e.IDEntidad
                                Where sle.IdSueldoLiquidacion = _IdSueldoLiquidacion
                                Select New DataGridRowData With {.IdEntidad = sle.IdEntidad, .EntidadApellidoNombre = e.ApellidoNombre, .ModuloCantidad = sle.ModuloCantidad, .Antiguedad = sle.Antiguedad}).ToList()
            End Using
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer las entidades de la liquidación de sueldos.")
            Me.Cursor = Cursors.Default
            Return
        End Try

        Me.Cursor = Cursors.Default

        If restoreCurrentPosition Then
            If DataGridViewMain.CurrentRow Is Nothing Then
                idEntidad = 0
            Else
                idEntidad = CType(DataGridViewMain.CurrentRow.DataBoundItem, DataGridRowData).IdEntidad
            End If
        End If

        FilterData()

        If idEntidad <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In DataGridViewMain.Rows
                If idEntidad = CType(CurrentRowChecked.DataBoundItem, DataGridRowData).IdEntidad Then
                    DataGridViewMain.CurrentCell = CurrentRowChecked.Cells(0)
                    Return
                End If
            Next
        End If
    End Sub

    Private Sub FilterData()

        If Not mSkipFilterData Then
            Me.Cursor = Cursors.WaitCursor

            Try
                ' Inicializo las variables
                _EntitiesFiltered = _EntitiesAll.ToList

                Select Case _EntitiesFiltered.Count
                    Case 0
                        ToolStripStatusLabelMain.Text = String.Format("No hay entidades en la liquidación de sueldos para mostrar.")
                    Case 1
                        ToolStripStatusLabelMain.Text = String.Format("Se muestra 1 entidad en la liquidación de sueldos.")
                    Case Else
                        ToolStripStatusLabelMain.Text = String.Format("Se muestran {0} entidades en la liquidación de sueldos.", _EntitiesFiltered.Count)
                End Select

            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al filtrar los datos.")
                Me.Cursor = Cursors.Default
                Return
            End Try

            OrderData()
        End If
    End Sub

    Private Sub OrderData()
        ' Realizo las rutinas de ordenamiento
        Select Case _OrderColumn.Name
            Case DataGridViewColumnEntidad.Name
                If _OrderType = SortOrder.Ascending Then
                    _EntitiesFiltered = _EntitiesFiltered.OrderBy(Function(r) r.EntidadApellidoNombre).ToList
                Else
                    _EntitiesFiltered = _EntitiesFiltered.OrderByDescending(Function(r) r.EntidadApellidoNombre).ToList
                End If
            Case DataGridViewColumnModuloCantidad.Name
                If _OrderType = SortOrder.Ascending Then
                    _EntitiesFiltered = _EntitiesFiltered.OrderBy(Function(r) r.ModuloCantidad).ThenBy(Function(r) r.EntidadApellidoNombre).ToList
                Else
                    _EntitiesFiltered = _EntitiesFiltered.OrderByDescending(Function(r) r.ModuloCantidad).ThenBy(Function(r) r.EntidadApellidoNombre).ToList
                End If
            Case DataGridViewColumnAntiguedad.Name
                If _OrderType = SortOrder.Ascending Then
                    _EntitiesFiltered = _EntitiesFiltered.OrderBy(Function(r) r.Antiguedad).ThenBy(Function(r) r.EntidadApellidoNombre).ToList
                Else
                    _EntitiesFiltered = _EntitiesFiltered.OrderByDescending(Function(r) r.Antiguedad).ThenBy(Function(r) r.EntidadApellidoNombre).ToList
                End If
        End Select
        DataGridViewMain.AutoGenerateColumns = False
        DataGridViewMain.DataSource = _EntitiesFiltered

        Me.Cursor = Cursors.Default

        ' Muestro el ícono de orden en la columna correspondiente
        _OrderColumn.HeaderCell.SortGlyphDirection = _OrderType
    End Sub

#End Region

#Region "Controls behavior"

    Private Sub CambioAnio(sender As Object, e As EventArgs)
        ReadData()
    End Sub

    Private Sub CambioMes(sender As Object, e As EventArgs)
        FilterData()
    End Sub

    Private Sub CambioColumnaOrden(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridViewMain.ColumnHeaderMouseClick
        Dim ClickedColumn As DataGridViewColumn

        ClickedColumn = CType(DataGridViewMain.Columns(e.ColumnIndex), DataGridViewColumn)

        If {DataGridViewColumnEntidad.Name, DataGridViewColumnModuloCantidad.Name, DataGridViewColumnAntiguedad.Name}.Contains(ClickedColumn.Name) Then
            If ClickedColumn Is _OrderColumn Then
                ' La columna clickeada es la misma por la que ya estaba ordenado, así que cambio la dirección del orden
                If _OrderType = SortOrder.Ascending Then
                    _OrderType = SortOrder.Descending
                Else
                    _OrderType = SortOrder.Ascending
                End If
            Else
                ' La columna clickeada es diferencte a la que ya estaba ordenada.
                If _OrderColumn IsNot Nothing Then
                    _OrderColumn.HeaderCell.SortGlyphDirection = SortOrder.None
                End If

                _OrderColumn = ClickedColumn
                _OrderType = SortOrder.Ascending
            End If
        End If

        OrderData()
    End Sub

#End Region

#Region "Main Toolbar"

    Private Sub Agregar_Click() Handles ToolStripButtonAgregar.Click
        If Not Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_ENTIDAD_AGREGAR) Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Using form = New FormLiquidacionEntidad(True, _IdSueldoLiquidacion, 0, _SueldoLiquidacionTexto)
            form.ShowDialog(Me)
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Editar_Click() Handles ToolStripButtonEditar.Click
        If DataGridViewMain.CurrentRow Is Nothing Then
            MessageBox.Show("No hay ninguna entidad para editar.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_ENTIDAD_EDITAR) Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Using form = New FormLiquidacionEntidad(True, _IdSueldoLiquidacion, CType(DataGridViewMain.SelectedRows(0).DataBoundItem, DataGridRowData).IdEntidad, _SueldoLiquidacionTexto)
            form.ShowDialog(Me)
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Eliminar_Click() Handles ToolStripButtonEliminar.Click
        If DataGridViewMain.CurrentRow Is Nothing Then
            MessageBox.Show("No hay ninguna entidad para eliminar.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_ENTIDAD_ELIMINAR) Then
            Return
        End If

        Dim row As DataGridRowData = CType(DataGridViewMain.CurrentRow.DataBoundItem, DataGridRowData)
        Dim mensaje As String = String.Format("Se eliminará la entidad de la liquidación de sueldo.{0}{0}Entidad: {1}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, row.EntidadApellidoNombre)
        If MessageBox.Show(mensaje, My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Using dbContext = New CSColegioContext(True)
            Try
                Dim sueldoLiquidacionEntidadActual As SueldoLiquidacionEntidad = dbContext.SueldoLiquidacionEntidad.Find(_IdSueldoLiquidacion, row.IdEntidad)
                dbContext.SueldoLiquidacionEntidad.Remove(sueldoLiquidacionEntidadActual)
                dbContext.SaveChanges()
            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                    Case CardonerSistemas.Database.EntityFramework.Errors.RelatedEntity
                        MessageBox.Show("No se puede eliminar la entidad de la liquidación de sueldo porque tiene datos relacionados.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Select
                Me.Cursor = Cursors.Default
                Return
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al eliminar la entidad de la liquidación de sueldo.")
            End Try
        End Using
        ReadData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Ver(sender As Object, e As EventArgs) Handles DataGridViewMain.DoubleClick
        If DataGridViewMain.CurrentRow Is Nothing Then
            MessageBox.Show("No hay ninguna entidad para ver.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Using form = New FormLiquidacionEntidad(False, _IdSueldoLiquidacion, CType(DataGridViewMain.SelectedRows(0).DataBoundItem, DataGridRowData).IdEntidad, _SueldoLiquidacionTexto)
            form.ShowDialog(Me)
        End Using
        Me.Cursor = Cursors.Default
    End Sub

#End Region

End Class