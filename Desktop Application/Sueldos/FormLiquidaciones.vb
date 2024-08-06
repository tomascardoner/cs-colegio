Public Class FormLiquidaciones

#Region "Declarations"

    Private _EntitiesAll As List(Of SueldoLiquidacion)
    Private _EntitiesFiltered As List(Of SueldoLiquidacion)

    Private mSkipFilterData As Boolean = False
    Private mBusquedaAplicada As Boolean = False

#End Region

#Region "Form stuff"

    Friend Sub SetAppearance()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.ImageSueldo32)

        DataGridViewMain.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        DataGridViewMain.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont
    End Sub

    Private Sub Me_Load() Handles Me.Load
        SetAppearance()

        mSkipFilterData = True

        Comunes.Listas.General.PeriodosAnios(ToolStripComboBoxAnio.ComboBox, 2024, CShort(Today.AddMonths(1).Year), False, False, False)
        ToolStripComboBoxAnio.SelectedIndex = ToolStripComboBoxAnio.FindStringExact(DateTime.Today.Year.ToString)
        pFillAndRefreshLists.MesNombres(ToolStripComboBoxMes.ComboBox, True, True, False)
        ToolStripComboBoxMes.SelectedIndex = 0

        mSkipFilterData = False

        ReadData()
    End Sub

#End Region

#Region "Mostrar y leer datos"

    Friend Sub ReadData(Optional PositionIdLiquidacionSueldo As Short = 0, Optional RestoreCurrentPosition As Boolean = False)
        Me.Cursor = Cursors.WaitCursor

        Try
            Using dbContext As New CSColegioContext(True)
                _EntitiesAll = dbContext.SueldoLiquidacion.Where(Function(sl) sl.Anio = CShort(ToolStripComboBoxAnio.Text)).OrderBy(Function(sl) sl.Mes).ToList()
            End Using
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer las liquidaciones de sueldos.")
            Me.Cursor = Cursors.Default
            Return
        End Try

        Me.Cursor = Cursors.Default

        If RestoreCurrentPosition Then
            If DataGridViewMain.CurrentRow Is Nothing Then
                PositionIdLiquidacionSueldo = 0
            Else
                PositionIdLiquidacionSueldo = CType(DataGridViewMain.CurrentRow.DataBoundItem, SueldoLiquidacion).IdSueldoLiquidacion
            End If
        End If

        FilterData()

        If PositionIdLiquidacionSueldo <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In DataGridViewMain.Rows
                If CType(CurrentRowChecked.DataBoundItem, SueldoLiquidacion).IdSueldoLiquidacion = PositionIdLiquidacionSueldo Then
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

                ' Filtro por mes
                If ToolStripComboBoxMes.SelectedIndex > 0 Then
                    _EntitiesFiltered = _EntitiesFiltered.Where(Function(sl) sl.Mes = ToolStripComboBoxMes.SelectedIndex).ToList
                End If

                Select Case _EntitiesFiltered.Count
                    Case 0
                        ToolStripStatusLabelMain.Text = String.Format("No hay liquidaciones de sueldo para mostrar.")
                    Case 1
                        ToolStripStatusLabelMain.Text = String.Format("Se muestra 1 liquidación de sueldo.")
                    Case Else
                        ToolStripStatusLabelMain.Text = String.Format("Se muestran {0} liquidaciones de sueldo.", _EntitiesFiltered.Count)
                End Select

            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al filtrar los datos.")
                Me.Cursor = Cursors.Default
                Return
            End Try

            DataGridViewMain.AutoGenerateColumns = False
            DataGridViewMain.DataSource = _EntitiesFiltered

            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

#Region "Main Toolbar"

    Private Sub Agregar_Click() Handles ToolStripButtonAgregar.Click
        If Not Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_AGREGAR) Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Using form = New FormLiquidacion(True, 0, Convert.ToInt16(ToolStripComboBoxAnio.Text))
            form.ShowDialog(Me)
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Editar_Click() Handles ToolStripButtonEditar.Click
        If DataGridViewMain.CurrentRow Is Nothing Then
            MessageBox.Show("No hay ninguna liquidación de sueldo para editar.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_EDITAR) Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Using form = New FormLiquidacion(True, CType(DataGridViewMain.SelectedRows(0).DataBoundItem, SueldoLiquidacion).IdSueldoLiquidacion, Convert.ToInt16(ToolStripComboBoxAnio.Text))
            form.ShowDialog(Me)
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Eliminar_Click() Handles ToolStripButtonEliminar.Click
        If DataGridViewMain.CurrentRow Is Nothing Then
            MessageBox.Show("No hay ninguna liquidación de sueldo para eliminar.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_ELIMINAR) Then
            Return
        End If

        Dim mensaje As String = String.Format("Se eliminará la liquidación de sueldo.{0}{0}Año: {1}{0}Mes: {2}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, ToolStripComboBoxAnio.Text, MonthName(CType(DataGridViewMain.CurrentRow.DataBoundItem, SueldoLiquidacion).Mes))
        If MessageBox.Show(mensaje, My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Using dbContext = New CSColegioContext(True)
            Try
                Dim sueldoLiquidacionActual As SueldoLiquidacion = dbContext.SueldoLiquidacion.Find(CType(DataGridViewMain.CurrentRow.DataBoundItem, SueldoLiquidacion).IdSueldoLiquidacion)
                dbContext.SueldoLiquidacion.Remove(sueldoLiquidacionActual)
                dbContext.SaveChanges()
            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                    Case CardonerSistemas.Database.EntityFramework.Errors.RelatedEntity
                        MessageBox.Show("No se puede eliminar la liquidación de sueldo porque tiene datos relacionados.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Select
                Me.Cursor = Cursors.Default
                Return
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al eliminar la liquidación de sueldo.")
            End Try
        End Using
        ReadData()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Ver(sender As Object, e As EventArgs) Handles DataGridViewMain.DoubleClick
        If DataGridViewMain.CurrentRow Is Nothing Then
            MessageBox.Show("No hay ninguna liquidación de sueldo para ver.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Using form = New FormLiquidacion(False, CType(DataGridViewMain.SelectedRows(0).DataBoundItem, SueldoLiquidacion).IdSueldoLiquidacion, Convert.ToInt16(ToolStripComboBoxAnio.Text))
            form.ShowDialog(Me)
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Entidades(sender As Object, e As EventArgs) Handles ToolStripButtonEntidades.Click
        If DataGridViewMain.CurrentRow Is Nothing Then
            MessageBox.Show("No hay ninguna liquidación de sueldo para ver.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_ENTIDAD) Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim form As FormLiquidacionesEntidades = Comunes.Forms.SueldosLiquidacionesEntidades.InstanciaActualONueva()
        form.InitializeFormAndShow(CType(DataGridViewMain.SelectedRows(0).DataBoundItem, SueldoLiquidacion).IdSueldoLiquidacion, Convert.ToInt16(ToolStripComboBoxAnio.Text), MonthName(CType(DataGridViewMain.SelectedRows(0).DataBoundItem, SueldoLiquidacion).Mes))
        Me.Cursor = Cursors.Default
    End Sub

#End Region

#Region "Controls behavior"

    Private Sub CambioAnio(sender As Object, e As EventArgs) Handles ToolStripComboBoxAnio.SelectedIndexChanged
        ReadData()
    End Sub

    Private Sub CambioMes(sender As Object, e As EventArgs) Handles ToolStripComboBoxMes.SelectedIndexChanged
        FilterData()
    End Sub

#End Region

End Class