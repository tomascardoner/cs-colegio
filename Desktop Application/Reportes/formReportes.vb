Public Class formReportes

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)
#End Region

#Region "Form stuff"
    Private Sub formReportes_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarListaReportes()

        treeviewReportes.Font = My.Settings.GridsAndListsFont
        listviewParametros.Font = My.Settings.GridsAndListsFont
    End Sub

    Private Sub formReportes_Unload() Handles Me.FormClosed
        mdbContext.Dispose()
    End Sub
#End Region

#Region "Reportes"
    Private Sub CargarListaReportes()
        Dim ReporteGrupoNode As TreeNode
        Dim ReporteNode As TreeNode

        Try
            treeviewReportes.BeginUpdate()
            For Each ReporteGrupoActual As ReporteGrupo In mdbContext.ReporteGrupo
                ' Agrego el Grupo de Reportes
                ReporteGrupoNode = New TreeNode(ReporteGrupoActual.Nombre)
                ReporteGrupoNode.Tag = ReporteGrupoActual
                treeviewReportes.Nodes.Add(ReporteGrupoNode)

                For Each ReporteActual As Reporte In ReporteGrupoActual.Reportes
                    ' Agrego el Reporte
                    ReporteNode = New TreeNode(ReporteActual.Nombre)
                    ReporteNode.Tag = ReporteActual
                    ReporteGrupoNode.Nodes.Add(ReporteNode)
                Next
            Next
            treeviewReportes.ExpandAll()
            treeviewReportes.EndUpdate()

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer la lista de Reportes.")
        End Try
    End Sub

    Private Sub Siguiente() Handles treeviewReportes.NodeMouseDoubleClick, buttonSiguiente.Click
        If treeviewReportes.SelectedNode Is Nothing Then
            MsgBox("No hay ningún Reporte seleccionado para imprimir.", vbInformation, My.Application.Info.Title)
        Else
            If treeviewReportes.SelectedNode.Level = 0 Then
                MsgBox("Debe seleccionar un Reporte (y no un Grupo) para imprimir.", vbInformation, My.Application.Info.Title)
            Else
                CargarListaParametros()
                panelReportes.Hide()
                panelParametros.Show()
            End If
        End If
    End Sub
#End Region

#Region "Parámetros"
    Private Sub CargarListaParametros()
        Dim ReporteActual As Reporte
        Dim ParametroListViewItem As ListViewItem

        listviewParametros.Items.Clear()

        Try
            listviewParametros.BeginUpdate()
            ReporteActual = CType(treeviewReportes.SelectedNode.Tag, Reporte)
            For Each ParametroActual As ReporteParametro In ReporteActual.ReporteParametros.OrderBy(Function(rp) rp.Orden)

                With ParametroActual
                    ' Agrego el Parámetro

                    ParametroListViewItem = New ListViewItem(.Nombre)
                    ParametroListViewItem.Tag = .IDParametro
                    If .Requerido Then
                        ParametroListViewItem.SubItems.Add("Sí")
                    Else
                        ParametroListViewItem.SubItems.Add("No")
                    End If

                    If VarType(.Valor) = vbEmpty Then
                        ParametroListViewItem.SubItems.Add("")
                    Else
                        ParametroListViewItem.SubItems.Add(.ValorParaMostrar)
                    End If
                End With

                listviewParametros.Items.Add(ParametroListViewItem)
            Next
            listviewParametros.EndUpdate()

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer la lista de Parámetros del Reporte.")
        End Try
    End Sub

    Private Sub EditarParametro() Handles listviewParametros.DoubleClick
        Dim ReporteActual As Reporte
        Dim ParametroActual As ReporteParametro
        Dim ListViewItemActual As ListViewItem

        If listviewParametros.SelectedItems.Count = 0 Then
            MsgBox("No hay ningún Parámetro seleccionado para modificar.", vbInformation, My.Application.Info.Title)
        Else
            ReporteActual = CType(treeviewReportes.SelectedNode.Tag, Reporte)
            ParametroActual = ReporteActual.ReporteParametros.Where(Function(rp) rp.IDParametro = CStr(listviewParametros.SelectedItems(0).Tag)).First
            ListViewItemActual = listviewParametros.SelectedItems(0)

            Select Case ParametroActual.Tipo
                ' Entidades
                Case Constantes.REPORTE_PARAMETRO_ENTIDAD, Constantes.REPORTE_PARAMETRO_ENTIDAD_PERSONALCOLEGIO, Constantes.REPORTE_PARAMETRO_ENTIDAD_DOCENTE, Constantes.REPORTE_PARAMETRO_ENTIDAD_ALUMNO, Constantes.REPORTE_PARAMETRO_ENTIDAD_FAMILIAR, Constantes.REPORTE_PARAMETRO_ENTIDAD_PROVEEDOR
                    formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = (ParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_ENTIDAD Or ParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_ENTIDAD_PERSONALCOLEGIO)
                    formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = (ParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_ENTIDAD Or ParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_ENTIDAD_DOCENTE)
                    formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = (ParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_ENTIDAD Or ParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_ENTIDAD_ALUMNO)
                    formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = (ParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_ENTIDAD Or ParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_ENTIDAD_FAMILIAR)
                    formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = (ParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_ENTIDAD Or ParametroActual.Tipo = Constantes.REPORTE_PARAMETRO_ENTIDAD_PROVEEDOR)
                    If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        Dim EntidadSeleccionada As Entidad

                        EntidadSeleccionada = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
                        ParametroActual.Valor = EntidadSeleccionada.IDEntidad
                        ParametroActual.ValorParaMostrar = EntidadSeleccionada.ApellidoNombre
                        ListViewItemActual.SubItems(2).Text = ParametroActual.ValorParaMostrar

                        EntidadSeleccionada = Nothing
                    End If
                    formEntidadesSeleccionar.Dispose()

                Case Constantes.REPORTE_PARAMETRO_TIPO_NUMBER_INTEGER, Constantes.REPORTE_PARAMETRO_TIPO_NUMBER_DECIMAL, Constantes.REPORTE_PARAMETRO_TIPO_MONEY, Constantes.REPORTE_PARAMETRO_TIPO_DATETIME, Constantes.REPORTE_PARAMETRO_TIPO_DATE, Constantes.REPORTE_PARAMETRO_TIPO_TIME, Constantes.REPORTE_PARAMETRO_TIPO_YEAR, Constantes.REPORTE_PARAMETRO_TIPO_MONTH, Constantes.REPORTE_PARAMETRO_TIPO_SINO
                    formReportesParametro.SetAppearance(ParametroActual, ListViewItemActual.Text)
                    If formReportesParametro.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                        ListViewItemActual.SubItems(2).Text = ParametroActual.ValorParaMostrar
                    End If
                    formReportesParametro.Close()
                    formReportesParametro.Dispose()
            End Select
        End If
    End Sub

    Private Sub Parametros_KeyDown(sender As Object, e As KeyEventArgs) Handles listviewParametros.KeyDown
        Dim ReporteActual As Reporte
        Dim ParametroActual As ReporteParametro
        Dim ListViewItemActual As ListViewItem

        If listviewParametros.SelectedItems.Count > 0 AndAlso e.KeyCode = Keys.Delete Then
            ReporteActual = CType(treeviewReportes.SelectedNode.Tag, Reporte)
            ParametroActual = ReporteActual.ReporteParametros.Where(Function(rp) rp.IDParametro = CStr(listviewParametros.SelectedItems(0).Tag)).First
            ListViewItemActual = listviewParametros.SelectedItems(0)

            ParametroActual.Valor = Nothing
            ListViewItemActual.SubItems(2).Text = ""
        End If
    End Sub

    Private Sub Anterior() Handles buttonAnterior.Click
        panelReportes.Show()
        panelParametros.Hide()
    End Sub
#End Region

#Region "Mostrar Reporte"
    Private Sub MostrarReporte(sender As Object, e As EventArgs) Handles buttonImprimir.Click, buttonPrevisualizar.Click
        Dim ReporteActual As Reporte

        If sender.Equals(buttonImprimir) Then
            If MsgBox("Se va a imprimir directamente el Reporte seleccionado." & vbCrLf & vbCrLf & "¿Desea continuar?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        ReporteActual = CType(treeviewReportes.SelectedNode.Tag, Reporte)
        For Each ParametroActual In ReporteActual.ReporteParametros
            If ParametroActual.Requerido AndAlso ParametroActual.Valor Is Nothing Then
                MsgBox(ParametroActual.RequeridoLeyenda, MsgBoxStyle.Information, My.Application.Info.Title)
                listviewParametros.Focus()
                Exit Sub
            End If
        Next

        Me.Cursor = Cursors.WaitCursor

        If ReporteActual.Open(My.Settings.ReportsPath & "\" & ReporteActual.Archivo) Then
            If ReporteActual.SetDatabaseConnection(pDatabase.DataSource, pDatabase.InitialCatalog, pDatabase.UserID, pDatabase.Password) Then
                If sender.Equals(buttonImprimir) Then
                    ReporteActual.ReportObject.PrintToPrinter(1, False, 1, 1000)
                Else
                    Reportes.PreviewCrystalReport(ReporteActual, ReporteActual.Titulo)
                End If
            End If
        End If

        Me.Cursor = Cursors.Default
    End Sub
#End Region

End Class