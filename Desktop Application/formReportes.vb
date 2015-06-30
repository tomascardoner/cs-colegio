Public Class formReportes
    Private Sub buttonPrevisualizar_Click(sender As Object, e As EventArgs) Handles buttonImprimir.Click, buttonPrevisualizar.Click
        If treeviewReportes.SelectedNode Is Nothing Then
            MsgBox("No hay ningún Reporte seleccionado para imprimir.", vbInformation, My.Application.Info.Title)
        Else
            If treeviewReportes.SelectedNode.Level = 0 Then
                MsgBox("Debe seleccionar un Reporte (y no un Grupo) para imprimir.", vbInformation, My.Application.Info.Title)
            Else
                If sender.Equals(buttonImprimir) Then
                    If MsgBox("Se va a imprimir directamente el Reporte seleccionado." & vbCrLf & vbCrLf & "¿Desea continuar?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                Me.Cursor = Cursors.WaitCursor

                Dim ReporteSeleccionado As Reporte = CType(treeviewReportes.SelectedNode.Tag, Reporte)
                Dim ReporteCrystal As New CS_CrystalReport
                If ReporteCrystal.OpenReport(My.Settings.ReportsPath & "\" & ReporteSeleccionado.Archivo) Then
                    If ReporteCrystal.SetDatabaseConnection(pDatabase.DataSource, pDatabase.InitialCatalog, pDatabase.UserID, pDatabase.Password) Then
                        If sender.Equals(buttonImprimir) Then
                            ReporteCrystal.ReportObject.PrintToPrinter(1, False, 1, 1000)
                        Else
                            MiscFunctions.PreviewCrystalReport(ReporteCrystal, ReporteSeleccionado.Titulo)
                        End If
                    End If
                End If

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub formReportes_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim ReporteGrupoNode As TreeNode
        Dim ReporteNode As TreeNode

        treeviewReportes.Font = My.Settings.GridsAndListsFont

        Try
            Using dbcontext As New CSColegioContext(True)
                treeviewReportes.BeginUpdate()
                For Each ReporteGrupoActual As ReporteGrupo In dbcontext.ReporteGrupo
                    ' Agrego el Grupo de Reportes
                    ReporteGrupoNode = New TreeNode(ReporteGrupoActual.Nombre)
                    ReporteGrupoNode.Tag = ReporteGrupoActual
                    treeviewReportes.Nodes.Add(ReporteGrupoNode)

                    For Each ReporteActual As Reporte In ReporteGrupoActual.Reporte
                        ' Agrego el Reporte
                        ReporteNode = New TreeNode(ReporteActual.Nombre)
                        ReporteNode.Tag = ReporteActual
                        ReporteGrupoNode.Nodes.Add(ReporteNode)
                    Next
                Next
                treeviewReportes.EndUpdate()
            End Using

        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al leer la lista de Reportes.")
        End Try
    End Sub
End Class