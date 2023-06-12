Imports System.IO
Imports Microsoft.Office.Interop

Public Class formComprobantesTransmitirPagosEduc

#Region "Declarations"

    Private ReadOnly dbContext As New CSColegioContext(True)

    Private Class GridDataRow
        Public Property IDComprobante As Integer
        Public Property ComprobanteTipoNombre As String
        Public Property NumeroCompleto As String
        Public Property IDEntidad As Integer
        Public Property ApellidoNombre As String
        Public Property DocumentoNumero As String
        Public Property ImporteTotal As Decimal
    End Class

#End Region

#Region "Form stuff"

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buttonExportar.Enabled = False
        pFillAndRefreshLists.ComprobanteLote(comboboxComprobanteLote, False, False)
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbContext.Dispose()
    End Sub

#End Region

#Region "Load and Set Data"

    Private Sub RefreshData()
        Dim ComprobanteLoteActual As ComprobanteLote
        Dim listComprobantes As List(Of GridDataRow) = Nothing

        Me.Cursor = Cursors.WaitCursor

        Try

            If comboboxComprobanteLote.SelectedValue IsNot Nothing Then
                ComprobanteLoteActual = CType(comboboxComprobanteLote.SelectedItem, ComprobanteLote)

                listComprobantes = (From c In dbContext.Comprobante
                                    Join e In dbContext.Entidad On c.IDEntidad Equals e.IDEntidad
                                    Join cl In dbContext.ComprobanteLote On c.IDComprobanteLote Equals cl.IDComprobanteLote
                                    Join ct In dbContext.ComprobanteTipo On c.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                    Where c.IDComprobanteLote = ComprobanteLoteActual.IDComprobanteLote And ct.EmisionElectronica And c.CAE IsNot Nothing And c.IDUsuarioAnulacion Is Nothing
                                    Order By ct.Nombre, c.NumeroCompleto
                                    Select New GridDataRow With {.IDComprobante = c.IDComprobante, .ComprobanteTipoNombre = ct.Nombre, .NumeroCompleto = c.NumeroCompleto, .IDEntidad = e.IDEntidad, .ApellidoNombre = e.ApellidoNombre, .DocumentoNumero = e.DocumentoNumero, .ImporteTotal = c.ImporteTotal1}).ToList

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
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener la lista de Comprobantes.")
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

    Private Sub Transmitir_Click(sender As Object, e As EventArgs) Handles buttonExportar.Click

        If datagridviewComprobantes.Rows.Count > 0 Then
            If CS_Parameter_System.GetIntegerAsInteger(Parametros.EMPRESA_PAGOSEDUC_NUMERO) = 0 Then
                MsgBox("No está especificado el Número de Empresa otorgado por PAGOSEduc.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Exit Sub
            End If

            Dim codigoEmpresa As Integer = CS_Parameter_System.GetIntegerAsInteger(Parametros.EMPRESA_PAGOSEDUC_NUMERO, 0)
            If ExportarComprobantes(codigoEmpresa) Then
                If ExportArchivoBase(codigoEmpresa) Then

                End If
            End If
        End If

    End Sub

#End Region

#Region "Extra stuff"

    Private Function ExportarComprobantes(ByVal codigoEmpresa As Integer) As Boolean
        Dim DetalleTextStream As String

        Dim ComprobanteActual As Comprobante
        Dim DetalleCount As Integer = 0
        Dim DetalleImporteTotal As Decimal = 0

        Dim FolderName As String = ""
        Dim FileName As String

        ' Obtengo y verifico si existe la carpeta de destino de los archivos a exportar
        Try
            FolderName = pGeneralConfig.ExchangeOutboundFolder
            If Not FolderName.EndsWith("\") Then
                FolderName &= "\"
            End If
            FolderName &= pGeneralConfig.ExchangeOutboundPagosEducSubFolder
            If Not FolderName.EndsWith("\") Then
                FolderName &= "\"
            End If
            If Not My.Computer.FileSystem.DirectoryExists(FolderName) Then
                My.Computer.FileSystem.CreateDirectory(FolderName)
            End If

        Catch avex As AccessViolationException
            MsgBox("La aplicación no tiene permisos para acceder o crear la carpeta especificada.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Return False

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error el acceder o crear la carpeta especificada.")
        End Try

        FileName = $"FAC{codigoEmpresa.ToString.PadLeft(5, "0"c)}.{DateTime.Today:ddMMyy}"

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Using outputFile As New StreamWriter(FolderName & FileName)

            For Each RowActual As DataGridViewRow In datagridviewComprobantes.Rows
                ComprobanteActual = dbContext.Comprobante.Find(CType(RowActual.DataBoundItem, GridDataRow).IDComprobante)

                If ComprobanteActual IsNot Nothing Then
                    ' Detalle
                    DetalleTextStream = "5"                                                                 ' Código de Registro
                    DetalleTextStream &= codigoEmpresa.ToString.PadLeft(5, "0"c)                            ' Código de Entidad
                    DetalleTextStream &= ComprobanteActual.Entidad.DocumentoNumero.RemoveNotNumbers().Truncate(9).PadRight(14, " "c)               ' Número de Referencia
                    DetalleTextStream &= ComprobanteActual.IDComprobante.ToString.PadRight(20, " "c)        ' Id. Factura
                    DetalleTextStream &= "0"                                                                ' Código de Moneda
                    DetalleTextStream &= ComprobanteActual.FechaVencimiento1.Value.ToString("yyyyMMdd")     ' Fecha 1er. vencimiento
                    DetalleTextStream &= ComprobanteActual.ImporteTotal1.ToString("000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")   ' Importe 1er. vencimiento
                    If ComprobanteActual.ImporteTotal2.HasValue Then
                        DetalleTextStream &= ComprobanteActual.FechaVencimiento2.Value.ToString("yyyyMMdd")     ' Fecha 2do. vencimiento
                        DetalleTextStream &= ComprobanteActual.ImporteTotal2.Value.ToString("000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")   ' Importe 2do. vencimiento
                    Else
                        DetalleTextStream &= StrDup(8, "0"c)                                                    ' Fecha 2do. vencimiento
                        DetalleTextStream &= StrDup(11, "0"c)                                                   ' Importe 2do. vencimiento
                    End If
                    If ComprobanteActual.ImporteTotal3.HasValue Then
                        DetalleTextStream &= ComprobanteActual.FechaVencimiento3.Value.ToString("yyyyMMdd")     ' Fecha 3er. vencimiento
                        DetalleTextStream &= ComprobanteActual.ImporteTotal3.Value.ToString("000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")   ' Importe 3er. vencimiento
                    Else
                        DetalleTextStream &= StrDup(8, "0"c)                                                    ' Fecha 3er. vencimiento
                        DetalleTextStream &= StrDup(11, "0"c)                                                   ' Importe 3er. vencimiento
                    End If
                    DetalleTextStream &= StrDup(19, "0"c)                                                   ' Filler
                    DetalleTextStream &= ComprobanteActual.Entidad.DocumentoNumero.PadRight(19, " "c)       ' Número de Referencia anterior
                    DetalleTextStream &= (ComprobanteActual.ComprobanteTipo.NombreConLetra.ToUpper.Replace("""", "") & " " & ComprobanteActual.NumeroCompleto).PadRight(40, " "c) ' Mensaje Ticket
                    DetalleTextStream &= (ComprobanteActual.ComprobanteTipo.Sigla & ComprobanteActual.PuntoVenta & ComprobanteActual.Numero).PadRight(15, " "c) ' Mensaje Pantalla
                    DetalleTextStream &= StrDup(60, " "c)                                                   ' Código de barras
                    DetalleTextStream &= StrDup(29, "0"c)                                                   ' Filler
                    outputFile.WriteLine(DetalleTextStream)

                    DetalleCount += 1
                    DetalleImporteTotal += ComprobanteActual.ImporteTotal1
                End If
            Next
        End Using

        MsgBox(String.Format("Se generó el archivo de intercambio con PAGOS Educ, conteniendo {1} comprobantes.{0}{0}Nombre del archivo: {2}{0}{0}Ubicación: {3}", Environment.NewLine, DetalleCount, FileName, FolderName), MsgBoxStyle.Information, My.Application.Info.Title)

        Me.Cursor = Cursors.Default

        Return True
    End Function

    Private Function ExportArchivoBase(ByVal codigoEmpresa As Integer) As Boolean
        Dim FolderName As String = String.Empty
        Dim FileName As String

        Dim GridDataRowActual As GridDataRow
        Dim EntidadExportacionActual As EntidadExportacion

        Dim listEntidadesAExportar As New List(Of GridDataRow)
        Dim listEntidadExportacion As New List(Of EntidadExportacion)
        Dim EntidadCount As Integer = 0

        ' Obtengo y verifico si existe la carpeta de destino de los archivos a exportar
        Try
            FolderName = pGeneralConfig.ExchangeOutboundFolder
            If Not FolderName.EndsWith("\") Then
                FolderName &= "\"
            End If
            FolderName &= pGeneralConfig.ExchangeOutboundPagosEducSubFolder
            If Not FolderName.EndsWith("\") Then
                FolderName &= "\"
            End If
            If Not My.Computer.FileSystem.DirectoryExists(FolderName) Then
                My.Computer.FileSystem.CreateDirectory(FolderName)
            End If

        Catch avex As AccessViolationException
            MsgBox("La aplicación no tiene permisos para acceder o crear la carpeta especificada.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Return False

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error el acceder o crear la carpeta especificada.")
        End Try

        FileName = $"Base.{codigoEmpresa.ToString.PadLeft(5, "0"c)}.xlsx"

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        For Each row As DataGridViewRow In datagridviewComprobantes.Rows
            GridDataRowActual = CType(row.DataBoundItem, GridDataRow)
            EntidadExportacionActual = dbContext.EntidadExportacion.Find(GridDataRowActual.IDEntidad, Constantes.ExportacionSistemaPagosEduc)

            If EntidadExportacionActual Is Nothing AndAlso Not listEntidadExportacion.Exists(Function(ee) ee.IDEntidad = GridDataRowActual.IDEntidad AndAlso ee.Sistema = Constantes.ExportacionSistemaPagosEduc) Then
                listEntidadesAExportar.Add(GridDataRowActual)

                EntidadExportacionActual = New EntidadExportacion
                With EntidadExportacionActual
                    .IDEntidad = GridDataRowActual.IDEntidad
                    .Sistema = Constantes.ExportacionSistemaPagosEduc
                    .Fecha = DateAndTime.Today
                End With
                listEntidadExportacion.Add(EntidadExportacionActual)

                EntidadCount += 1
            End If
        Next

        ' Exporto a Excel
        If EntidadCount > 0 Then
            Dim excelApp As Excel.Application
            Dim excelWorkbook As Excel.Workbook
            Dim excelWorksheet As Excel.Worksheet
            Dim excelRange As Excel.Range

            Const ExcelColumnaCodigoEntidad As Integer = 1
            Const ExcelColumnaDni As Integer = 2
            Const ExcelColumnaLegajo As Integer = 3
            Const ExcelColumnaApellidoNombre As Integer = 4

            ' Creo una instancia de Excel
            Try
                excelApp = New Excel.Application()
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al crear un instancia de Microsoft Excel.")
                listEntidadesAExportar = Nothing
                listEntidadExportacion = Nothing
                Return False
            End Try
            If excelApp Is Nothing Then
                Me.Cursor = Cursors.Default
                MsgBox("Microsoft Excel no está instalado en esta computadora.", MsgBoxStyle.Critical, My.Application.Info.Title)
                listEntidadesAExportar = Nothing
                listEntidadExportacion = Nothing
                Return False
            End If

            ' Creo el libro y la hoja
            Try
                excelWorkbook = excelApp.Workbooks.Add(System.Reflection.Missing.Value)
                excelWorksheet = CType(excelWorkbook.Worksheets(1), Excel.Worksheet)
            Catch ex As Exception
                Me.Cursor = Cursors.Default
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al crear un libro y hoja de Microsoft Excel.")
                listEntidadesAExportar = Nothing
                listEntidadExportacion = Nothing
                excelApp.Quit()
                ReleaseObject(excelApp)
                Return False
            End Try

            ' Creo los encabezados
            excelRange = CType(excelWorksheet.Cells(1, ExcelColumnaCodigoEntidad), Excel.Range)
            excelRange.Value = "código de entidad*"
            excelRange.Font.Bold = True

            excelRange = CType(excelWorksheet.Cells(1, ExcelColumnaDni), Excel.Range)
            excelRange.Value = "dni"
            excelRange.Font.Bold = True

            excelRange = CType(excelWorksheet.Cells(1, ExcelColumnaLegajo), Excel.Range)
            excelRange.Value = "legajo"
            excelRange.Font.Bold = True

            excelRange = CType(excelWorksheet.Cells(1, ExcelColumnaApellidoNombre), Excel.Range)
            excelRange.Value = "nombre y apellido"
            excelRange.Font.Bold = True

            ' Exporto las Entidades
            Dim rowNumber As Integer = 0
            For Each row As GridDataRow In listEntidadesAExportar
                rowNumber += 1
                excelWorksheet.Cells(1 + rowNumber, ExcelColumnaCodigoEntidad) = codigoEmpresa.ToString.PadLeft(5, "0"c)
                excelWorksheet.Cells(1 + rowNumber, ExcelColumnaDni) = row.DocumentoNumero.RemoveNotNumbers().Truncate(9)
                ' excelWorksheet.Cells(1 + rowNumber, ExcelColumnaLegajo) = 
                excelWorksheet.Cells(1 + rowNumber, ExcelColumnaApellidoNombre) = row.ApellidoNombre
            Next

            ' Ajusto el ancho de las Columnas
            CType(excelWorksheet.Columns(ExcelColumnaCodigoEntidad), Excel.Range).AutoFit()
            CType(excelWorksheet.Columns(ExcelColumnaDni), Excel.Range).AutoFit()
            CType(excelWorksheet.Columns(ExcelColumnaLegajo), Excel.Range).AutoFit()
            CType(excelWorksheet.Columns(ExcelColumnaApellidoNombre), Excel.Range).AutoFit()

            ' Guardo el libro de Excel
            Try
                excelWorkbook.SaveAs(FolderName & FileName)
                excelWorkbook.Close()
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al guardar el libro de Microsoft Excel.")
                listEntidadesAExportar = Nothing
                listEntidadExportacion = Nothing
                ReleaseObject(excelRange)
                ReleaseObject(excelWorksheet)
                ReleaseObject(excelWorkbook)
                excelApp.Quit()
                ReleaseObject(excelApp)
                Return False
            End Try

            ' Cierro el Excel
            ReleaseObject(excelRange)
            ReleaseObject(excelWorksheet)
            ReleaseObject(excelWorkbook)
            excelApp.Quit()
            ReleaseObject(excelApp)

            ' Guardo las entidades exportadas en la base de datos
            Try
                dbContext.EntidadExportacion.AddRange(listEntidadExportacion)
                dbContext.SaveChanges()
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al guardar las entidades exportadas en la base de datos.")
                listEntidadesAExportar = Nothing
                listEntidadExportacion = Nothing
                Return False
            End Try

            Me.Cursor = Cursors.Default
            MsgBox(String.Format("Se generó el archivo de alta de Personas para PAGOS Educ, conteniendo {1} personas.{0}{0}Nombre del archivo: {2}{0}{0}Ubicación: {3}", Environment.NewLine, EntidadCount, FileName, FolderName), MsgBoxStyle.Information, My.Application.Info.Title)
        End If

        Me.Cursor = Cursors.Default
        listEntidadesAExportar = Nothing
        listEntidadExportacion = Nothing
        Return True
    End Function

    Private Sub ReleaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

#End Region

End Class