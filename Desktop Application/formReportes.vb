Public Class formReportes

    Private Sub buttonPrevisualizar_Click(sender As Object, e As EventArgs) Handles buttonImprimir.Click, buttonPrevisualizar.Click
        If treeviewReportes Is Nothing Then
            MsgBox("No hay ningún Reporte seleccionado para imprimir.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.COMPROBANTE_PRINT) Then
                If sender.Equals(buttonImprimir) Then
                    If MsgBox("Se va a imprimir directamente el Reporte seleccionado." & vbCrLf & vbCrLf & "¿Desea continuar?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                Me.Cursor = Cursors.WaitCursor

                Dim Reporte As New CS_CrystalReport
                If Reporte.OpenReport(My.Settings.ReportsPath & "\" & "HermanosSinDescuento.rpt") Then
                    If Reporte.SetDatabaseConnection(pDatabase.DataSource, pDatabase.InitialCatalog, pDatabase.UserID, pDatabase.Password) Then
                        'Reporte.RecordSelectionFormula = "{ComprobanteCabecera.IDComprobante} = " & 

                        If sender.Equals(buttonImprimir) Then
                            Reporte.ReportObject.PrintToPrinter(1, False, 1, 100)
                        Else
                            MiscFunctions.PreviewCrystalReport(Reporte, "Listado de Hermanos")
                        End If
                    End If
                End If

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub
End Class