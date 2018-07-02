Imports System.IO

Public Class formComprobantesTransmitirSantanderRecaudacionPorCaja

#Region "Declarations"
    Private dbContext As New CSColegioContext(True)
    Private listComprobantes As List(Of GridDataRow)

    Private Class GridDataRow
        Public Property IDComprobante As Integer
        Public Property ComprobanteTipoNombre As String
        Public Property NumeroCompleto As String
        Public Property ApellidoNombre As String
        Public Property ImporteTotal As Decimal
    End Class
#End Region

#Region "Form stuff"
    Private Sub formComprobantesTransmitirPagomiscuentas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buttonExportar.Enabled = False
        pFillAndRefreshLists.ComprobanteLote(comboboxComprobanteLote, False, False)
    End Sub

    Private Sub formComprobantesTransmitirPagomiscuentas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbContext.Dispose()
    End Sub
#End Region

#Region "Load and Set Data"
    Private Sub RefreshData()
        Dim ComprobanteLoteActual As ComprobanteLote

        Me.Cursor = Cursors.WaitCursor

        Try

            If Not comboboxComprobanteLote.SelectedValue Is Nothing Then
                ComprobanteLoteActual = CType(comboboxComprobanteLote.SelectedItem, ComprobanteLote)

                listComprobantes = (From c In dbContext.Comprobante
                                    Join cl In dbContext.ComprobanteLote On c.IDComprobanteLote Equals cl.IDComprobanteLote
                                    Join ct In dbContext.ComprobanteTipo On c.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                    Join e In dbContext.Entidad On c.IDEntidad Equals e.IDEntidad
                                    Where c.IDComprobanteLote = ComprobanteLoteActual.IDComprobanteLote And ct.EmisionElectronica And c.CAE IsNot Nothing And c.IDUsuarioAnulacion Is Nothing
                                    Order By ct.Nombre, c.NumeroCompleto
                                    Select New GridDataRow With {.IDComprobante = c.IDComprobante, .ComprobanteTipoNombre = ct.Nombre, .NumeroCompleto = c.NumeroCompleto, .ApellidoNombre = c.ApellidoNombre, .ImporteTotal = c.ImporteTotal1}).ToList

                Select Case listComprobantes.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Comprobantes para mostrar.")
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Comprobante.")
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0} Comprobantes.", listComprobantes.Count)
                End Select
            Else
                listComprobantes = Nothing
            End If

            datagridviewComprobantes.AutoGenerateColumns = False
            datagridviewComprobantes.DataSource = listComprobantes

        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error al obtener la lista de Comprobantes.")
        End Try

        Me.Cursor = Cursors.Default

        If listComprobantes Is Nothing Then
            buttonExportar.Enabled = False
        Else
            buttonExportar.Enabled = (listComprobantes.Count > 0)
        End If
    End Sub

#End Region

#Region "Controls behavior"
    Private Sub CambiarLote() Handles comboboxComprobanteLote.SelectedIndexChanged
        RefreshData()
    End Sub

    Private Sub buttonTransmitir_Click(sender As Object, e As EventArgs) Handles buttonExportar.Click
        If listComprobantes.Count > 0 Then
            If CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_CODIGOSERVICIO) = "" Then
                MsgBox("No está especificado el Código de Servicio otorgado por el Banco Santander.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Exit Sub
            End If

            ExportarComprobantes()
        End If
    End Sub
#End Region

#Region "Extra stuff"
    Private Function ExportarComprobantes() As Boolean
        Dim DetalleTextStream As String = ""

        Dim GridDataRowActual As GridDataRow
        Dim ComprobanteActual As Comprobante
        Dim DetalleCount As Integer = 0
        Dim DetalleImporteTotal As Decimal = 0

        Dim FolderName As String
        Dim FileName As String

        ' Obtengo y verifico si existe la carpeta de destino de los archivos a exportar
        FolderName = CS_SpecialFolders.ProcessString(My.Settings.Exchange_Outbound_Santander_Piryp_Folder)
        If Not FolderName.EndsWith("\") Then
            FolderName &= "\"
        End If
        If Not FolderName.EndsWith("\") Then
            FolderName &= "\"
        End If
        If Not Directory.Exists(FolderName) Then
            Directory.CreateDirectory(FolderName)
        End If

        FileName = CS_File.RemoveInvalidFileNameChars(String.Format("Lote - {0}.txt", comboboxComprobanteLote.Text))

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Using outputFile As New StreamWriter(FolderName & FileName, False, New System.Text.UTF8Encoding)

            For Each RowActual As DataGridViewRow In datagridviewComprobantes.Rows
                GridDataRowActual = CType(RowActual.DataBoundItem, GridDataRow)
                ComprobanteActual = dbContext.Comprobante.Find(GridDataRowActual.IDComprobante)
                If Not ComprobanteActual Is Nothing Then
                    ' Detalle
                    DetalleTextStream &= ComprobanteActual.ComprobanteTipo.Sigla.Substring(0, 2)            ' Tipo de Comprobante
                    DetalleTextStream &= ComprobanteActual.NumeroCompleto.PadRight(15, " "c)                ' Nro. Comprobante
                    DetalleTextStream &= "0001"                                                             ' Nro. Cuota
                    DetalleTextStream &= ComprobanteActual.Entidad.IDEntidad.ToString.PadRight(15, " "c)    ' Nro. Cliente Empresa
                    DetalleTextStream &= CS_String.RemoveDiacritics(ComprobanteActual.ApellidoNombre).PadRight(30, " "c).Substring(0, 30)   ' Nombre Cliente
                    DetalleTextStream &= StrDup(11, "0"c)                                                   ' CUIT Cliente
                    DetalleTextStream &= ComprobanteActual.FechaVencimiento1.Value.ToString("yyyyMMdd")     ' Fecha 1er. vencimiento
                    DetalleTextStream &= ComprobanteActual.ImporteTotal1.ToString("0000000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")   ' Importe 1er. vencimiento
                    DetalleTextStream &= "0"                                                                ' Moneda
                    DetalleTextStream &= "     "                                                            ' Filler
                    DetalleTextStream &= ComprobanteActual.IDComprobante.ToString.PadRight(30, " "c)        ' Referencia Empresa
                    If ComprobanteActual.FechaVencimiento2.HasValue Then
                        DetalleTextStream &= ComprobanteActual.FechaVencimiento2.Value.ToString("yyyyMMdd")      ' Fecha 2do. vencimiento
                        DetalleTextStream &= ComprobanteActual.ImporteTotal2.Value.ToString("0000000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")    ' Importe 2do. vencimiento
                    Else
                        DetalleTextStream &= ComprobanteActual.FechaVencimiento1.Value.AddDays(10).ToString("yyyyMMdd")      ' Fecha 2do. vencimiento
                        DetalleTextStream &= ComprobanteActual.ImporteTotal1.ToString("0000000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")    ' Importe 2do. vencimiento
                    End If
                    DetalleTextStream &= ComprobanteActual.FechaVencimiento1.Value.AddMonths(6).ToString("yyyyMMdd") ' Fecha Vto. Punitorios
                    DetalleTextStream &= "0003600"                                                          ' TNA
                    DetalleTextStream &= "S"                                                                ' Publica con Nro. Cliente Empresa
                    DetalleTextStream &= "00000000"                                                         ' Fecha Pronto Pago
                    DetalleTextStream &= StrDup(15, "0"c)                                                   ' Importe Pronto Pago
                    DetalleTextStream &= StrDup(18, " "c)                                                   ' Observacion 1
                    DetalleTextStream &= StrDup(15, " "c)                                                   ' Observacion 2
                    DetalleTextStream &= StrDup(15, " "c)                                                   ' Observacion 3
                    DetalleTextStream &= "0000"                                                             ' Cantidad Cuotas
                    DetalleTextStream &= StrDup(49, " "c)                                                   ' Filler

                    DetalleTextStream &= vbCrLf

                    DetalleCount += 1
                    DetalleImporteTotal += ComprobanteActual.ImporteTotal1
                End If
            Next

            ' Exporto todo al archivo
            outputFile.WriteLine(DetalleTextStream)
        End Using

        MsgBox(String.Format("Se ha generado exitosamente el archivo de intercambio con Banco Santander - Recaudación Por Caja, conteniendo {0} Comprobantes.", DetalleCount), MsgBoxStyle.Information, My.Application.Info.Title)

        RefreshData()

        Me.Cursor = Cursors.Default

        Return True
    End Function

#End Region

End Class