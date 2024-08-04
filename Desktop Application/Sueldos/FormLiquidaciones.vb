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

        pFillAndRefreshLists.AnioLectivo(ToolStripComboBoxAnio.ComboBox, False, SortOrder.Descending)
        ToolStripComboBoxAnio.SelectedIndex = ToolStripComboBoxAnio.FindStringExact(DateTime.Today.Year.ToString)
        pFillAndRefreshLists.MesNombres(ToolStripComboBoxMes.ComboBox, True, True, False)
        ToolStripComboBoxMes.SelectedIndex = 0

        mSkipFilterData = False

        RefreshData()
    End Sub

#End Region

#Region "Mostrar y leer datos"

    Friend Sub RefreshData(Optional PositionIdLiquidacionSueldo As Short = 0, Optional RestoreCurrentPosition As Boolean = False)
        Me.Cursor = Cursors.WaitCursor

        Try
            Using dbContext As New CSColegioContext(True)
                _EntitiesAll = dbContext.SueldoLiquidacion.Where(Function(sl) sl.Anio = CShort(ToolStripComboBoxAnio.Text)).OrderBy(Function(sl) sl.Mes).ToList()
            End Using
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer las Liquidaciones de sueldos.")
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
                If CType(DataGridViewMain.CurrentRow.DataBoundItem, SueldoLiquidacion).IdSueldoLiquidacion = PositionIdLiquidacionSueldo Then
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

#Region "Controls behavior"

    Private Sub CambioAnio(sender As Object, e As EventArgs) Handles ToolStripComboBoxAnio.SelectedIndexChanged
        RefreshData()
    End Sub

    Private Sub CambioMes(sender As Object, e As EventArgs) Handles ToolStripComboBoxMes.SelectedIndexChanged
        FilterData()
    End Sub

#End Region

#Region "Main Toolbar"

    Private Sub Agregar_Click() Handles ToolStripButtonAgregar.Click
        If Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor
            DataGridViewMain.Enabled = False
            FormLiquidacion.LoadAndShow(True, Me, 0, Convert.ToInt16(ToolStripComboBoxAnio.Text))
            DataGridViewMain.Enabled = True
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Editar_Click() Handles ToolStripButtonEditar.Click
        If DataGridViewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna liquidación de sueldo para editar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_EDITAR) Then
                Me.Cursor = Cursors.WaitCursor
                DataGridViewMain.Enabled = False
                FormLiquidacion.LoadAndShow(True, Me, CType(DataGridViewMain.SelectedRows(0).DataBoundItem, SueldoLiquidacion).IdSueldoLiquidacion, Convert.ToInt16(ToolStripComboBoxAnio.Text))
                DataGridViewMain.Enabled = True
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Eliminar_Click() Handles ToolStripButtonEliminar.Click
        If DataGridViewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna liquidación de sueldo para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_ELIMINAR) Then
                Me.Cursor = Cursors.WaitCursor
                Using dbContext = New CSColegioContext(True)
                    Dim SueldoLiquidacionActual As SueldoLiquidacion = dbContext.SueldoLiquidacion.Find(CType(DataGridViewMain.SelectedRows(0).DataBoundItem, SueldoLiquidacion).IdSueldoLiquidacion)
                    Dim Mensaje As String
                    Mensaje = String.Format("Se eliminará la liquidación de sueldo.{0}{0}Año: {1}{0}Mes: {2}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, SueldoLiquidacionActual.Anio, MonthName(SueldoLiquidacionActual.Mes))
                    If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then

                        Try
                            dbContext.SueldoLiquidacion.Remove(SueldoLiquidacionActual)
                            dbContext.SaveChanges()

                        Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                            Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                                Case CardonerSistemas.Database.EntityFramework.Errors.RelatedEntity
                                    MsgBox("No se puede eliminar la liquidación de sueldo porque tiene datos relacionados.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                            End Select
                            Me.Cursor = Cursors.Default
                            Return

                        Catch ex As Exception
                            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al eliminar la liquidación de sueldo.")
                        End Try
                        RefreshData()
                    End If
                End Using
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Ver(sender As Object, e As EventArgs) Handles DataGridViewMain.DoubleClick
        If DataGridViewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna liquidación de sueldo para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor
            DataGridViewMain.Enabled = False
            FormLiquidacion.LoadAndShow(False, Me, CType(DataGridViewMain.SelectedRows(0).DataBoundItem, SueldoLiquidacion).IdSueldoLiquidacion, Convert.ToInt16(ToolStripComboBoxAnio.Text))
            DataGridViewMain.Enabled = True
            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

End Class