Imports System.Data.Entity

Public Class FormLiquidacionesEntidades

#Region "Declarations"

    Private _IdSueldoLiquidacion As Short
    Private _SueldoLiquidacionAnio As Short
    Private _SueldoLiquidacionMes As Byte

    Private Class DataGridRowData
        Public Property IdEntidadGrupo As Byte
        Public Property EntidadGrupoNombre As String
        Public Property IdEntidad As Integer
        Public Property EntidadApellidoNombre As String
        Public Property ModuloCantidad As Decimal?
        Public Property Antiguedad As Decimal?
        Public Property ReciboImporteBasico As Decimal?
        Public Property ReciboImporteNeto As Decimal?
    End Class

    Private _EntitiesAll As List(Of DataGridRowData)
    Private _EntitiesFiltered As List(Of DataGridRowData)

    Private _SkipFilterData As Boolean = True

    Private _OrderColumn As DataGridViewColumn
    Private _OrderType As SortOrder

#End Region

#Region "Form stuff"

    Friend Sub SetAppearance()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.ImageSueldo32)
        ToolStripLabelLiquidacionDatos.Text = $"Período: {MonthName(_SueldoLiquidacionMes)} de {_SueldoLiquidacionAnio}"

        DataGridViewMain.DefaultCellStyle.Font = pAppearanceConfig.ListsFont
        DataGridViewMain.ColumnHeadersDefaultCellStyle.Font = pAppearanceConfig.ListsFont
    End Sub

    Friend Sub InitializeFormAndShow(idSueldoLiquidacion As Short, anio As Short, mes As Byte)
        _IdSueldoLiquidacion = idSueldoLiquidacion
        _SueldoLiquidacionAnio = anio
        _SueldoLiquidacionMes = mes

        SetAppearance()

        Using dbContext As New CSColegioContext(True)
            Comunes.Listas.Entidades.Grupos(ToolStripComboBoxEntidadGrupo.ComboBox, dbContext, True, False)
        End Using

        _OrderColumn = DataGridViewColumnEntidadGrupo
        _OrderType = SortOrder.Ascending

        _SkipFilterData = False
        ReadData()
        CardonerSistemas.Forms.MdiChildShow(CType(pFormMDIMain, Form), Me, False)
    End Sub

    Private Sub Me_Load() Handles Me.Load
        _OrderColumn.HeaderCell.SortGlyphDirection = _OrderType
    End Sub

#End Region

#Region "Mostrar y leer datos"

    Friend Sub ReadData(Optional idEntidad As Integer = 0, Optional restoreCurrentPosition As Boolean = False)
        If _SkipFilterData Then
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Try
            Using dbContext As New CSColegioContext(True)
                _EntitiesAll = (From sle In dbContext.SueldoLiquidacionEntidad
                                Join e In dbContext.Entidad On sle.IdEntidad Equals e.IDEntidad
                                Join epc In dbContext.EntidadPersonalColegio On e.IDEntidad Equals epc.IdEntidad
                                Join eg In dbContext.EntidadGrupo On epc.IdEntidadGrupo Equals eg.IdEntidadGrupo
                                Where sle.IdSueldoLiquidacion = _IdSueldoLiquidacion
                                Select New DataGridRowData With {.IdEntidadGrupo = e.EntidadPersonalColegio.IdEntidadGrupo, .EntidadGrupoNombre = eg.Nombre, .IdEntidad = sle.IdEntidad, .EntidadApellidoNombre = e.ApellidoNombre, .ModuloCantidad = sle.ModuloCantidad, .Antiguedad = sle.Antiguedad, .ReciboImporteBasico = If(sle.Recibo1ImporteBasico, 0) + If(sle.Recibo2ImporteBasico, 0) + If(sle.Recibo3ImporteBasico, 0) + If(sle.Recibo4ImporteBasico, 0) + If(sle.Recibo5ImporteBasico, 0), .ReciboImporteNeto = If(sle.Recibo1ImporteNeto, 0) + If(sle.Recibo2ImporteNeto, 0) + If(sle.Recibo3ImporteNeto, 0) + If(sle.Recibo4ImporteNeto, 0) + If(sle.Recibo5ImporteNeto, 0)}).ToList()
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
        If _SkipFilterData Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Try
            ' Inicializo las variables
            _EntitiesFiltered = _EntitiesAll.ToList

            If ToolStripComboBoxEntidadGrupo.SelectedIndex > 0 Then
                _EntitiesFiltered = _EntitiesFiltered.Where(Function(e) e.IdEntidadGrupo = CByte(ToolStripComboBoxEntidadGrupo.ComboBox.SelectedValue)).ToList()
            End If

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
    End Sub

    Private Sub OrderData()
        ' Realizo las rutinas de ordenamiento
        Select Case _OrderColumn.Name
            Case DataGridViewColumnEntidadGrupo.Name
                If _OrderType = SortOrder.Ascending Then
                    _EntitiesFiltered = _EntitiesFiltered.OrderBy(Function(r) r.EntidadGrupoNombre).ThenBy(Function(r) r.EntidadApellidoNombre).ToList
                Else
                    _EntitiesFiltered = _EntitiesFiltered.OrderByDescending(Function(r) r.EntidadGrupoNombre).ThenBy(Function(r) r.EntidadApellidoNombre).ToList
                End If
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

    Private Sub CambioGrupo(sender As Object, e As EventArgs) Handles ToolStripComboBoxEntidadGrupo.SelectedIndexChanged
        FilterData()
    End Sub

    Private Sub CambioColumnaOrden(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridViewMain.ColumnHeaderMouseClick
        Dim ClickedColumn As DataGridViewColumn

        ClickedColumn = CType(DataGridViewMain.Columns(e.ColumnIndex), DataGridViewColumn)

        If {DataGridViewColumnEntidadGrupo.Name, DataGridViewColumnEntidad.Name, DataGridViewColumnModuloCantidad.Name, DataGridViewColumnAntiguedad.Name}.Contains(ClickedColumn.Name) Then
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

    Private Sub Agregar_Click(sender As Object, e As EventArgs) Handles ToolStripButtonAgregar.Click
        If Not Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_ENTIDAD_AGREGAR) Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Using form = New FormLiquidacionEntidad(True, _IdSueldoLiquidacion, 0, _SueldoLiquidacionAnio, _SueldoLiquidacionMes)
            form.ShowDialog(Me)
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Editar_Click(sender As Object, e As EventArgs) Handles ToolStripButtonEditar.Click
        If DataGridViewMain.CurrentRow Is Nothing Then
            MessageBox.Show("No hay ninguna entidad para editar.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If
        If Not Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_ENTIDAD_EDITAR) Then
            Return
        End If
        Me.Cursor = Cursors.WaitCursor
        Using form = New FormLiquidacionEntidad(True, _IdSueldoLiquidacion, CType(DataGridViewMain.SelectedRows(0).DataBoundItem, DataGridRowData).IdEntidad, _SueldoLiquidacionAnio, _SueldoLiquidacionMes)
            form.ShowDialog(Me)
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Eliminar_Click(sender As Object, e As EventArgs) Handles ToolStripButtonEliminar.Click
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
        Using form = New FormLiquidacionEntidad(False, _IdSueldoLiquidacion, CType(DataGridViewMain.SelectedRows(0).DataBoundItem, DataGridRowData).IdEntidad, _SueldoLiquidacionAnio, _SueldoLiquidacionMes)
            form.ShowDialog(Me)
        End Using
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ToolStripButtonCopiarDatos_Click(sender As Object, e As EventArgs) Handles ToolStripButtonCopiarDatos.Click
        If Not Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_ENTIDAD_AGREGAR) Then
            Return
        End If
        If MessageBox.Show("¿Desea copiar los datos desde la última liquidación anterior?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim count As Integer
            Dim totalCount As Integer
            Using dbContext = New CSColegioContext(True)
                Dim sueldoLiquidacion = dbContext.SueldoLiquidacion.AsNoTracking().Where(Function(sl) (sl.Anio = _SueldoLiquidacionAnio AndAlso sl.Mes < _SueldoLiquidacionMes) OrElse sl.Anio < _SueldoLiquidacionAnio).OrderByDescending(Function(sl) sl.Anio).ThenByDescending(Function(sl) sl.Mes).Take(1).FirstOrDefault()
                If sueldoLiquidacion Is Nothing Then
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("No se encontró una liquidación de sueldos anterior.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return
                End If
                Dim idSueldoLiquidacionAnterior As Short = sueldoLiquidacion.IdSueldoLiquidacion
                For Each sueldoLiquidacionEntidad In dbContext.SueldoLiquidacionEntidad.AsNoTracking().Where(Function(sle) sle.IdSueldoLiquidacion = idSueldoLiquidacionAnterior)
                    Dim idEntidad As Integer = sueldoLiquidacionEntidad.IdEntidad
                    totalCount += 1
                    If Not dbContext.SueldoLiquidacionEntidad.Any(Function(sle) sle.IdSueldoLiquidacion = _IdSueldoLiquidacion AndAlso sle.IdEntidad = idEntidad) Then
                        dbContext.SueldoLiquidacionEntidad.Add(New SueldoLiquidacionEntidad With {
                            .IdSueldoLiquidacion = _IdSueldoLiquidacion,
                            .IdEntidad = idEntidad,
                            .ModuloCantidad = sueldoLiquidacionEntidad.ModuloCantidad,
                            .Antiguedad = sueldoLiquidacionEntidad.Antiguedad,
                            .Recibo1ImporteBasico = sueldoLiquidacionEntidad.Recibo1ImporteBasico,
                            .Recibo1ImporteNeto = sueldoLiquidacionEntidad.Recibo1ImporteNeto,
                            .Recibo2ImporteBasico = sueldoLiquidacionEntidad.Recibo2ImporteBasico,
                            .Recibo2ImporteNeto = sueldoLiquidacionEntidad.Recibo2ImporteNeto,
                            .Recibo3ImporteBasico = sueldoLiquidacionEntidad.Recibo3ImporteBasico,
                            .Recibo3ImporteNeto = sueldoLiquidacionEntidad.Recibo3ImporteNeto,
                            .Recibo4ImporteBasico = sueldoLiquidacionEntidad.Recibo4ImporteBasico,
                            .Recibo4ImporteNeto = sueldoLiquidacionEntidad.Recibo4ImporteNeto,
                            .Recibo5ImporteBasico = sueldoLiquidacionEntidad.Recibo5ImporteBasico,
                            .Recibo5ImporteNeto = sueldoLiquidacionEntidad.Recibo5ImporteNeto
                        })
                        count += 1
                    End If
                Next
                If dbContext.ChangeTracker.HasChanges Then
                    dbContext.SaveChanges()
                End If
            End Using
            ReadData()
            If totalCount = 0 Then
                MessageBox.Show($"No se encontraron datos de entidades en la liquidación de sueldos anterior.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Select Case count
                    Case 0
                        MessageBox.Show($"No se copiaron los datos de las entidades porque ya existen en la liquidación actual.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case 1
                        MessageBox.Show($"Se copiaron los datos de 1 entidad.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Case Else
                        MessageBox.Show($"Se copiaron los datos de {count} entidades.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                End Select
            End If
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener los datos de la última liquidación de sueldos de la entidad.")
        End Try
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Imprimir(sender As Object, e As EventArgs) Handles ToolStripMenuItemImprimirResumenDirectoras.Click, ToolStripMenuItemImprimirResumenDocentesIngles.Click, ToolStripMenuItemImprimirRecibosDocentesInglesTodos.Click, ToolStripMenuItemImprimirReciboDocenteIngles.Click
        If Not Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_ENTIDAD_IMPRIMIR) Then
            Return
        End If
        If DataGridViewMain.CurrentRow Is Nothing Then
            MessageBox.Show("No hay ninguna entidad para imprimir los reportes.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim idReporte As Integer
        If sender.Equals(ToolStripMenuItemImprimirResumenDirectoras) Then
            idReporte = CS_Parameter_System.GetIntegerAsShort(Parametros.REPORTE_ID_SUELDO_DIRECTOR_RESUMEN)
        ElseIf sender.Equals(ToolStripMenuItemImprimirResumenDocentesIngles) Then
            idReporte = CS_Parameter_System.GetIntegerAsShort(Parametros.REPORTE_ID_SUELDO_DOCENTE_INGLES_RESUMEN)
        ElseIf sender.Equals(ToolStripMenuItemImprimirRecibosDocentesInglesTodos) OrElse sender.Equals(ToolStripMenuItemImprimirReciboDocenteIngles) Then
            idReporte = CS_Parameter_System.GetIntegerAsShort(Parametros.REPORTE_ID_SUELDO_DOCENTE_INGLES_RECIBO)
        End If
        If idReporte = 0 Then
            Me.Cursor = Cursors.Default
            MessageBox.Show("No está especificado el id del reporte.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        Using dbContext As New CSColegioContext(True)
            Dim reporteActual = dbContext.Reporte.FirstOrDefault(Function(r) r.IDReporte = idReporte)
            Dim reporteParametroActual As ReporteParametro

            If reporteActual Is Nothing Then
                Me.Cursor = Cursors.Default
                MessageBox.Show("No se encontró la información del reporte.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            ' Año
            reporteParametroActual = reporteActual.ReporteParametros.FirstOrDefault(Function(rp) rp.IDParametro.TrimEnd() = "Anio")
            If reporteParametroActual Is Nothing Then
                Me.Cursor = Cursors.Default
                MessageBox.Show("No se encontró la información del parámetro del reporte.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            reporteParametroActual.Valor = _SueldoLiquidacionAnio

            ' Mes
            reporteParametroActual = reporteActual.ReporteParametros.FirstOrDefault(Function(rp) rp.IDParametro.TrimEnd() = "Mes")
            If reporteParametroActual Is Nothing Then
                Me.Cursor = Cursors.Default
                MessageBox.Show("No se encontró la información del parámetro del reporte.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            reporteParametroActual.Valor = _SueldoLiquidacionMes

            ' IdEntidad
            If sender.Equals(ToolStripMenuItemImprimirResumenDocentesIngles) OrElse sender.Equals(ToolStripMenuItemImprimirRecibosDocentesInglesTodos) OrElse sender.Equals(ToolStripMenuItemImprimirReciboDocenteIngles) Then
                reporteParametroActual = reporteActual.ReporteParametros.FirstOrDefault(Function(rp) rp.IDParametro.TrimEnd() = "IdEntidad")
                If reporteParametroActual Is Nothing Then
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("No se encontró la información del parámetro del reporte.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                If sender.Equals(ToolStripMenuItemImprimirResumenDocentesIngles) OrElse sender.Equals(ToolStripMenuItemImprimirRecibosDocentesInglesTodos) Then
                    reporteParametroActual.Valor = Nothing
                Else
                    reporteParametroActual.Valor = CType(DataGridViewMain.CurrentRow.DataBoundItem, DataGridRowData).IdEntidad
                End If
            End If

            If reporteActual.Open(System.IO.Path.Combine(pGeneralConfig.ReportsPath, reporteActual.Archivo)) Then
                If reporteActual.SetDatabaseConnection(pDatabase.Datasource, pDatabase.InitialCatalog, pDatabase.UserId, pDatabase.Password) Then
                    Reportes.PreviewCrystalReport(reporteActual, reporteActual.Titulo & $" - Período: {MonthName(_SueldoLiquidacionMes)} de {_SueldoLiquidacionAnio}")
                End If
            End If
        End Using
        Me.Cursor = Cursors.Default
    End Sub

#End Region

End Class