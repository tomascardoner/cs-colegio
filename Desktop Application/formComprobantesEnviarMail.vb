Public Class formComprobantesEnviarMail
    Private dbContext As New CSColegioContext(True)
    Private listComprobantes As List(Of GridDataRow)

    Private Class GridDataRow
        Public Property IDComprobante As Integer
        Public Property IDComprobanteTipo As Byte
        Public Property IDComprobanteLote As Integer
        Public Property LoteNombre As String
        Public Property ComprobanteTipoNombre As String
        Public Property NumeroCompleto As String
        Public Property IDEntidad As Integer
        Public Property ApellidoNombre As String
        Public Property ImporteTotal As Decimal
    End Class

    Private Sub formComprobantesEnviarMail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buttonEnviar.Enabled = False
        pFillAndRefreshLists.ComprobanteLote(comboboxComprobanteLote, False, False)
    End Sub

    Private Sub formComprobantesEnviarMail_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbContext.Dispose()
    End Sub

    Private Sub comboboxComprobanteLote_SelectedIndexChanged(sender As Object, e As EventArgs) Handles comboboxComprobanteLote.SelectedIndexChanged
        RefreshData()
    End Sub

    Private Sub RefreshData()
        Dim ComprobanteLoteActual As ComprobanteLote

        Me.Cursor = Cursors.WaitCursor

        Try

            If comboboxComprobanteLote.SelectedIndex > -1 Then
                ComprobanteLoteActual = CType(comboboxComprobanteLote.SelectedItem, ComprobanteLote)
                listComprobantes = (From cc In dbContext.Comprobante
                                    Join cl In dbContext.ComprobanteLote On cc.IDComprobanteLote Equals cl.IDComprobanteLote
                                    Join ct In dbContext.ComprobanteTipo On cc.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                    Where cc.IDComprobanteLote = ComprobanteLoteActual.IDComprobanteLote And cc.FechaHoraEnvioEmail Is Nothing And ct.EmisionElectronica And Not cc.CAE Is Nothing
                                    Order By ct.Nombre, cc.NumeroCompleto
                                    Select New GridDataRow With {.IDComprobante = cc.IDComprobante, .IDComprobanteTipo = cc.IDComprobanteTipo, .IDComprobanteLote = cc.IDComprobanteLote.Value, .LoteNombre = cl.Nombre, .ComprobanteTipoNombre = ct.Nombre, .NumeroCompleto = cc.NumeroCompleto, .IDEntidad = cc.IDEntidad, .ApellidoNombre = cc.ApellidoNombre, .ImporteTotal = cc.ImporteTotal}).ToList
            Else
                listComprobantes = Nothing
            End If

            datagridviewComprobantes.AutoGenerateColumns = False
            datagridviewComprobantes.DataSource = listComprobantes

            Select Case listComprobantes.Count
                Case 0
                    statuslabelMain.Text = String.Format("No hay Comprobantes para mostrar.")
                Case 1
                    statuslabelMain.Text = String.Format("Se muestra 1 Comprobante.")
                Case Else
                    statuslabelMain.Text = String.Format("Se muestran {0} Comprobantes.", listComprobantes.Count)
            End Select

        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al obtener la lista de Comprobantes.")
        End Try

        Me.Cursor = Cursors.Default

        buttonEnviar.Enabled = (listComprobantes.Count > 0)
    End Sub

    Private Sub buttonEnviar_Click(sender As Object, e As EventArgs) Handles buttonEnviar.Click
        If listComprobantes.Count > 0 Then
            EnviarComprobantes()
        End If
    End Sub

    Private Sub EnviarComprobantes()
        Dim GridDataRowActual As GridDataRow
        Dim ComprobanteActual As Comprobante
        Dim IDComprobanteTipo As Byte
        Dim Reporte As New CS_CrystalReport

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        textboxStatus.Text = "Iniciando el envío de Comprobantes..."
        MostrarOcultarEstado(True)

        For Each RowActual As DataGridViewRow In datagridviewComprobantes.Rows
            ' Hago que la grilla vaya mostrando la fila que se está procesando
            datagridviewComprobantes.CurrentCell = RowActual.Cells(0)
            GridDataRowActual = CType(RowActual.DataBoundItem, GridDataRow)

            ComprobanteActual = dbContext.Comprobante.Find(GridDataRowActual.IDComprobante)
            If Not ComprobanteActual Is Nothing Then
                If (Not ComprobanteActual.Entidad.Email1 Is Nothing) Or (Not ComprobanteActual.Entidad.Email2 Is Nothing) Then
                    If IDComprobanteTipo <> ComprobanteActual.IDComprobanteTipo Then
                        IDComprobanteTipo = ComprobanteActual.IDComprobanteTipo
                        Reporte = New CS_CrystalReport
                        If Not Reporte.OpenReport(My.Settings.ReportsPath & "\" & ComprobanteActual.ComprobanteTipo.ReporteNombre) Then
                            Exit For
                        End If
                        If Not Reporte.SetDatabaseConnection(pDatabase.DataSource, pDatabase.InitialCatalog, pDatabase.UserID, pDatabase.Password) Then
                            Exit For
                        End If
                    End If
                    Reporte.RecordSelectionFormula = "{Comprobante.IDComprobante} = " & ComprobanteActual.IDComprobante
                    Reporte.ReportObject.Refresh()

                    Dim Asunto As String = String.Format(My.Settings.Comprobante_EnviarEmail_Subject, ComprobanteActual.ComprobanteTipo.NombreConLetra, GridDataRowActual.NumeroCompleto)
                    Dim Cuerpo As String = String.Format(My.Settings.Comprobante_EnvioEmail_Body, vbCrLf) & String.Format(My.Settings.Email_Signature, vbCrLf)
                    Dim AdjuntoNombre As String = String.Format("{0}-{1}.pdf", ComprobanteActual.ComprobanteTipo.Sigla.TrimEnd, ComprobanteActual.NumeroCompleto)

                    textboxStatus.AppendText(vbCrLf & String.Format("Enviando la {0} N° {1} a {2}...", ComprobanteActual.ComprobanteTipo.Nombre, ComprobanteActual.Numero, ComprobanteActual.Entidad.ApellidoNombre))

                    Select Case My.Settings.LoteComprobantes_EnviarEmail_Metodo
                        Case Constantes.EMAIL_CLIENT_NETDLL
                            If Not MiscFunctions.EnviarEmailPorNETClient(ComprobanteActual.Entidad, Asunto, Cuerpo, Reporte, AdjuntoNombre) Then
                                Exit For
                            End If
                        Case Constantes.EMAIL_CLIENT_MSOUTLOOK
                            If Not MiscFunctions.EnviarEmailPorMSOutlook(ComprobanteActual.Entidad, Asunto, Cuerpo, Reporte, AdjuntoNombre) Then
                                Exit For
                            End If
                        Case Constantes.EMAIL_CLIENT_CRYSTALREPORTSMAPI
                            If Not MiscFunctions.EnviarEmailPorCrystalReportsMAPI(ComprobanteActual.Entidad, Asunto, Cuerpo, Reporte, AdjuntoNombre) Then
                                Exit For
                            End If
                    End Select

                    dbContext.Comprobante.Attach(ComprobanteActual)

                    ComprobanteActual.IDUsuarioEnvioEmail = pUsuario.IDUsuario
                    ComprobanteActual.FechaHoraEnvioEmail = DateTime.Now

                    dbContext.SaveChanges()

                    textboxStatus.AppendText("OK")
                Else
                    textboxStatus.AppendText(vbCrLf & String.Format("El Titular de la {0} N° {1} ({2}) no especifica e-mail...", ComprobanteActual.ComprobanteTipo.Nombre, ComprobanteActual.Numero, ComprobanteActual.Entidad.ApellidoNombre))
                End If
            End If
        Next

        MsgBox("Se han enviado los e-Mails.", MsgBoxStyle.Information, My.Application.Info.Title)

        RefreshData()
        MostrarOcultarEstado(False)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MostrarOcultarEstado(ByVal Mostrar As Boolean)
        If Mostrar Then
            datagridviewComprobantes.Height = 311
            progressbarStatus.Maximum = listComprobantes.Count
            progressbarStatus.Value = 0
            textboxStatus.Text = ""
        Else
            datagridviewComprobantes.Height = 449
        End If
        groupboxStatus.Visible = Mostrar
    End Sub
End Class