Imports System.Data.Entity.SqlServer

Public Class FormCalculosModulos

#Region "Declarations"

    Private Class DataGridRowData
        Public Property Mes As Byte
        Public Property IdSueldoConcepto As Short
        Public Property SueldoConceptoCodigo As String
        Public Property SueldoConceptoNombre As String
        Public Property Importe As Decimal
    End Class

    Private _EntitiesAll As List(Of DataGridRowData)
    Private _EntitiesFiltered As List(Of DataGridRowData)

    Private mSkipFilterData As Boolean = False
    Private mBusquedaAplicada As Boolean = False

    Private mOrdenColumna As DataGridViewColumn
    Private mOrdenTipo As SortOrder

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

    Friend Sub RefreshData(Optional PositionMes As Byte = 0, Optional PositionIdSueldoConcepto As Short = 0, Optional RestoreCurrentPosition As Boolean = False)
        Me.Cursor = Cursors.WaitCursor

        Try
            Using dbContext As New CSColegioContext(True)
                _EntitiesAll = (From scm In dbContext.SueldoCalculoModulo
                                Join sc In dbContext.SueldoConcepto On scm.IdSueldoConcepto Equals sc.IdSueldoConcepto
                                Where scm.Anio = CShort(ToolStripComboBoxAnio.Text)
                                Order By scm.Mes, scm.IdSueldoConcepto
                                Select New DataGridRowData With {.Mes = scm.Mes, .IdSueldoConcepto = scm.IdSueldoConcepto, .SueldoConceptoCodigo = If(sc.Codigo.HasValue, SqlFunctions.Replicate("0", 5 - sc.Codigo.Value.ToString.Length) & sc.Codigo.Value, String.Empty), .SueldoConceptoNombre = sc.Nombre, .Importe = scm.Importe}).ToList()
            End Using
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer los cálculos de módulos de sueldos.")
            Me.Cursor = Cursors.Default
            Return
        End Try

        Me.Cursor = Cursors.Default

        If RestoreCurrentPosition Then
            If DataGridViewMain.CurrentRow Is Nothing Then
                PositionMes = 0
                PositionIdSueldoConcepto = 0
            Else
                PositionMes = CType(DataGridViewMain.CurrentRow.DataBoundItem, DataGridRowData).Mes
                PositionIdSueldoConcepto = CType(DataGridViewMain.CurrentRow.DataBoundItem, DataGridRowData).IdSueldoConcepto
            End If
        End If

        FilterData()

        If PositionMes <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In DataGridViewMain.Rows
                If CType(CurrentRowChecked.DataBoundItem, DataGridRowData).Mes = PositionMes AndAlso CType(CurrentRowChecked.DataBoundItem, DataGridRowData).IdSueldoConcepto = PositionIdSueldoConcepto Then
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
                    _EntitiesFiltered = _EntitiesFiltered.Where(Function(scm) scm.Mes = ToolStripComboBoxMes.SelectedIndex).ToList
                End If

                Select Case _EntitiesFiltered.Count
                    Case 0
                        ToolStripStatusLabelMain.Text = String.Format("No hay cálculos de módulos de sueldos para mostrar.")
                    Case 1
                        ToolStripStatusLabelMain.Text = String.Format("Se muestra 1 cálculo de módulo de sueldo.")
                    Case Else
                        ToolStripStatusLabelMain.Text = String.Format("Se muestran {0} cálculos de módulos de sueldos.", _EntitiesFiltered.Count)
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

    Private Sub AgregarDesdeInternet_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItemAgregarDesdeInternet.Click
        If Permisos.VerificarPermiso(Permisos.SUELDO_CALCULOMODULO_AGREGAR) Then
            Using formCalculoModuloObtener As New FormCalculoModuloObtener(Convert.ToInt16(ToolStripComboBoxAnio.Text), CType(ToolStripComboBoxMes.SelectedIndex, Byte))
                formCalculoModuloObtener.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub AgregarManualmente_Click() Handles ToolStripMenuItemAgregarManualmente.Click
        If Permisos.VerificarPermiso(Permisos.SUELDO_CALCULOMODULO_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor
            DataGridViewMain.Enabled = False
            FormCalculoModulo.LoadAndShow(True, Me, Convert.ToInt16(ToolStripComboBoxAnio.Text), CType(ToolStripComboBoxMes.SelectedIndex, Byte), 0)
            DataGridViewMain.Enabled = True
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Editar_Click() Handles ToolStripButtonEditar.Click
        If DataGridViewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún cálculo de módulo de sueldo para editar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.SUELDO_CALCULOMODULO_EDITAR) Then
                Me.Cursor = Cursors.WaitCursor
                DataGridViewMain.Enabled = False
                FormCalculoModulo.LoadAndShow(True, Me, Convert.ToInt16(ToolStripComboBoxAnio.Text), CType(DataGridViewMain.SelectedRows(0).DataBoundItem, DataGridRowData).Mes, CType(DataGridViewMain.SelectedRows(0).DataBoundItem, DataGridRowData).IdSueldoConcepto)
                DataGridViewMain.Enabled = True
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Eliminar_Click() Handles ToolStripButtonEliminar.Click
        If DataGridViewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún cálculo de módulo de sueldo para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.SUELDO_CALCULOMODULO_ELIMINAR) Then
                Me.Cursor = Cursors.WaitCursor
                Using dbContext = New CSColegioContext(True)
                    Dim SueldoCalculoModuloActual As SueldoCalculoModulo = dbContext.SueldoCalculoModulo.Find(CShort(ToolStripComboBoxAnio.Text), CType(DataGridViewMain.SelectedRows(0).DataBoundItem, DataGridRowData).Mes, CType(DataGridViewMain.SelectedRows(0).DataBoundItem, DataGridRowData).IdSueldoConcepto)
                    Dim Mensaje As String
                    Mensaje = String.Format("Se eliminará el cálculo de módulo de sueldo.{0}{0}Año: {1}{0}Mes: {2}{0}Código: {3}{0}Concepto: {4}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, SueldoCalculoModuloActual.Anio, MonthName(SueldoCalculoModuloActual.Mes), SueldoCalculoModuloActual.SueldoConcepto.Codigo, SueldoCalculoModuloActual.SueldoConcepto.Nombre)
                    If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then

                        Try
                            dbContext.SueldoCalculoModulo.Remove(SueldoCalculoModuloActual)
                            dbContext.SaveChanges()

                        Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                            Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                                Case CardonerSistemas.Database.EntityFramework.Errors.RelatedEntity
                                    MsgBox("No se puede eliminar el cálculo de módulo de sueldo porque tiene datos relacionados.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                            End Select
                            Me.Cursor = Cursors.Default
                            Return

                        Catch ex As Exception
                            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al eliminar el cálculo de módulo de sueldo.")
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
            MsgBox("No hay ningún cálculo de módulo de sueldo para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor
            DataGridViewMain.Enabled = False
            FormCalculoModulo.LoadAndShow(False, Me, Convert.ToInt16(ToolStripComboBoxAnio.Text), CType(DataGridViewMain.SelectedRows(0).DataBoundItem, DataGridRowData).Mes, CType(DataGridViewMain.SelectedRows(0).DataBoundItem, DataGridRowData).IdSueldoConcepto)
            DataGridViewMain.Enabled = True
            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

End Class