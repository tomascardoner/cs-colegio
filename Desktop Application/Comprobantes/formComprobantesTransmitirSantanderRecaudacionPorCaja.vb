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

    Private Sub buttonTransmitir_Click(sender As Object, e As EventArgs) Handles buttonExportar.Click
        If listComprobantes.Count > 0 Then
            If CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_CODIGOSERVICIO) = "" Then
                MsgBox("No está especificado el Código de Servicio otorgado por el Banco Santander.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Exit Sub
            End If

            ExportarComprobantesACashManagement()
        End If
    End Sub
#End Region

#Region "Extra stuff"

    Private Function ExportarComprobantesACashManagement() As Boolean
        Dim HeaderTextStream As String = ""
        Dim DetalleTextStream As String = ""
        Dim TrailerTextStream As String = ""

        Dim GridDataRowActual As GridDataRow
        Dim ComprobanteActual As Comprobante
        Dim DetalleCount As Integer = 0
        Dim DetalleImporteTotal As Decimal = 0

        Dim InteresTasaNominalAnual As Decimal
        Dim NumeroUltimoEnvio As Integer

        Dim FolderName As String = ""
        Dim FileName As String

        ' Obtengo y verifico si existe la carpeta de destino de los archivos a exportar
        Try
            FolderName = CardonerSistemas.SpecialFolders.ProcessString(My.Settings.Exchange_Outbound_Santander_Piryp_Folder)
            If Not FolderName.EndsWith("\") Then
                FolderName &= "\"
            End If
            If Not Directory.Exists(FolderName) Then
                Directory.CreateDirectory(FolderName)
            End If

        Catch avex As AccessViolationException
            MsgBox("La aplicación no tiene permisos para acceder o crear la carpeta especificada.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Return False

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error el acceder o crear la carpeta especificada.")
        End Try

        FileName = CardonerSistemas.Files.RemoveInvalidFileNameChars(String.Format("Lote - {0}.txt", comboboxComprobanteLote.Text))

        Try
            If FileSystem.Dir(FolderName & FileName) <> "" Then
                If MessageBox.Show(String.Format("El archivo '{1}' ya existe.{0}¿Desea sobreescribirlo?", vbCrLf, FolderName & FileName), My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = DialogResult.No Then
                    Return False
                End If
            End If
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "No se puede verificar la existencia del archivo de destino. Esto puede deberse a que la aplicación no tenga permisos para acceder a la carpeta de destino.")
            Return False
        End Try

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        InteresTasaNominalAnual = CS_Parameter_System.GetDecimal(Parametros.INTERES_TASA_NOMINAL_ANUAL)
        NumeroUltimoEnvio = CS_Parameter_System.GetIntegerAsInteger(Parametros.BANCOSANTANDER_PIRYP_NUMEROULTIMOENVIO)

        Try

            Using outputFile As New StreamWriter(FolderName & FileName, False, New System.Text.UTF8Encoding)

                For Each RowActual As DataGridViewRow In datagridviewComprobantes.Rows
                    GridDataRowActual = CType(RowActual.DataBoundItem, GridDataRow)
                    ComprobanteActual = dbContext.Comprobante.Find(GridDataRowActual.IDComprobante)
                    If Not ComprobanteActual Is Nothing Then
                        ' Detalle
                        DetalleTextStream &= "D"                                                                ' Tipo de Registro DETALLE
                        DetalleTextStream &= "A"                                                                ' Tipo de Operación (A=Actualización / B=Baja)
                        DetalleTextStream &= "0"                                                                ' Código de Moneda (0=Pesos / 2=Dólares)
                        DetalleTextStream &= ComprobanteActual.Entidad.IDEntidad.ToString.PadRight(15, " "c)    ' Número de Cliente
                        DetalleTextStream &= ComprobanteActual.ComprobanteTipo.Sigla.Substring(0, 2)            ' Tipo de Comprobante
                        DetalleTextStream &= ComprobanteActual.NumeroCompleto.PadRight(15, " "c)                ' Número de Comprobante
                        DetalleTextStream &= "0001"                                                             ' Número de Cuota
                        DetalleTextStream &= CS_String.RemoveDiacritics(ComprobanteActual.ApellidoNombre).PadRight(30, " "c).Substring(0, 30)   ' Nombre del Cliente
                        If ComprobanteActual.DomicilioCalleCompleto Is Nothing Then
                            DetalleTextStream &= StrDup(30, " ")                ' Dirección del Cliente
                        Else
                            DetalleTextStream &= CS_String.RemoveDiacritics(ComprobanteActual.DomicilioCalleCompleto).PadRight(30, " "c).Substring(0, 30)   ' Dirección del Cliente
                        End If
                        If ComprobanteActual.DomicilioIDLocalidad.HasValue Then
                            DetalleTextStream &= CS_String.RemoveDiacritics(ComprobanteActual.Localidad.Nombre).PadRight(20, " "c).Substring(0, 20)   ' Localidad del Cliente
                        Else
                            DetalleTextStream &= StrDup(20, " ")                ' Localidad del Cliente
                        End If
                        If ComprobanteActual.DomicilioCodigoPostal Is Nothing Then
                            DetalleTextStream &= " "              ' Prefijo del Código Postal
                            DetalleTextStream &= StrDup(5, " ")   ' Número del Código Postal
                            DetalleTextStream &= StrDup(4, " ")   ' Ubicación manzana del Código Postal
                        Else
                            Select Case ComprobanteActual.DomicilioCodigoPostal.Length
                                Case 4
                                    DetalleTextStream &= " "   ' Prefijo del Código Postal
                                    DetalleTextStream &= ComprobanteActual.DomicilioCodigoPostal.PadRight(5, " "c)   ' Número del Código Postal
                                    DetalleTextStream &= StrDup(4, " ")   ' Ubicación manzana del Código Postal
                                Case 8
                                    DetalleTextStream &= ComprobanteActual.DomicilioCodigoPostal.Substring(0, 1)    ' Prefijo del Código Postal
                                    DetalleTextStream &= ComprobanteActual.DomicilioCodigoPostal.Substring(1, 4).PadRight(5, " "c)  ' Número del Código Postal
                                    DetalleTextStream &= ComprobanteActual.DomicilioCodigoPostal.Substring(5, 3).PadRight(4, " "c)  ' Ubicación manzana del Código Postal
                                Case Else
                                    DetalleTextStream &= " "              ' Prefijo del Código Postal
                                    DetalleTextStream &= StrDup(5, " ")   ' Número del Código Postal
                                    DetalleTextStream &= StrDup(4, " ")   ' Ubicación manzana del Código Postal
                            End Select
                        End If
                        DetalleTextStream &= ComprobanteActual.FechaVencimiento1.Value.ToString("yyyyMMdd")     ' Fecha 1er. vencimiento
                        DetalleTextStream &= ComprobanteActual.ImporteTotal1.ToString("0000000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")   ' Importe 1er. vencimiento
                        If ComprobanteActual.FechaVencimiento2.HasValue Then
                            DetalleTextStream &= ComprobanteActual.FechaVencimiento2.Value.ToString("yyyyMMdd") ' Fecha 2do. vencimiento
                            DetalleTextStream &= ComprobanteActual.ImporteTotal2.Value.ToString("0000000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")    ' Importe 2do. vencimiento
                        Else
                            DetalleTextStream &= ComprobanteActual.FechaVencimiento1.Value.AddDays(10).ToString("yyyyMMdd")      ' Fecha 2do. vencimiento
                            DetalleTextStream &= ComprobanteActual.ImporteTotal1.ToString("0000000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")    ' Importe 2do. vencimiento
                        End If
                        DetalleTextStream &= ComprobanteActual.FechaVencimiento1.Value.ToString("yyyyMMdd")     ' Fecha Pronto Pago
                        DetalleTextStream &= ComprobanteActual.ImporteTotal1.ToString("0000000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")   ' Importe Pronto Pago
                        DetalleTextStream &= ComprobanteActual.FechaVencimiento1.Value.AddMonths(1).ToString("yyyyMMdd") ' Fecha hasta Punitorios
                        DetalleTextStream &= InteresTasaNominalAnual.ToString("0000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "") ' Tasa de Punitorios
                        DetalleTextStream &= "N"                                                                ' Marca de Excepción de cobro de comisión al depositante (S=Cobra al depositante / N=Cobra a la Empresa)
                        DetalleTextStream &= StrDup(10, " "c)                                                   ' Formas de Cobro Permitidas
                        If ComprobanteActual.DocumentoTipo.IDDocumentoTipo = CS_Parameter_System.GetIntegerAsByte(Parametros.DOCUMENTOTIPO_CUIT_ID) Or ComprobanteActual.DocumentoTipo.IDDocumentoTipo = CS_Parameter_System.GetIntegerAsByte(Parametros.DOCUMENTOTIPO_CUIL_ID) Then
                            DetalleTextStream &= ComprobanteActual.DocumentoNumero                                  ' Número de CUIT del Cliente
                        Else
                            DetalleTextStream &= StrDup(11, "0"c)                                                   ' Número de CUIT del Cliente
                        End If
                        DetalleTextStream &= "9"                                                                    ' Código de Ingresos Brutos del Cliente(9=No Informa)
                        DetalleTextStream &= "1"                                                                    ' Código de Condición de IVA del Cliente (1=consumidor Final)
                        DetalleTextStream &= StrDup(3, " "c)                                                        ' Código de Concepto
                        DetalleTextStream &= StrDup(40, " "c)                                                       ' Descripción del Concepto
                        DetalleTextStream &= ComprobanteActual.NumeroCompleto.ToString.PadRight(18, " "c)           ' Observación Libre 1ra.
                        DetalleTextStream &= ComprobanteActual.IDComprobante.ToString.PadRight(15, " "c)            ' Observación Libre 2da.
                        DetalleTextStream &= StrDup(15, " "c)                                                       ' Observación Libre 3ra.
                        DetalleTextStream &= StrDup(80, " "c)                                                       ' Observación Libre 4ta.
                        DetalleTextStream &= StrDup(243, " "c)                                                      ' Relleno

                        DetalleTextStream &= vbCrLf

                        DetalleCount += 1
                        DetalleImporteTotal += ComprobanteActual.ImporteTotal1
                    End If
                Next

                ' Header
                HeaderTextStream = "H"                                                                              ' Tipo de Registro HEADER
                HeaderTextStream &= CS_Parameter_System.GetString(Parametros.EMPRESA_CUIT)                          ' CUIT de la Empresa
                HeaderTextStream &= "0"                                                                             ' Empresa
                HeaderTextStream &= "001"                                                                           ' Código de Producto
                HeaderTextStream &= CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_PIRYP_NUMEROACUERDO)    ' Número de Acuerdo
                HeaderTextStream &= "007"                                                                           ' Código de Canal
                HeaderTextStream &= (NumeroUltimoEnvio + 1).ToString("00000")                                       ' Número de envío (secuencial)
                ' TODO: poner el número de la última rendición procesada
                HeaderTextStream &= (0).ToString("00000")                                                           ' Última rendición procesada
                HeaderTextStream &= "S"                                                                             ' Marca de Actualización de Cuenta Comercial
                HeaderTextStream &= "B"                                                                             ' Marca para publicación ON-LINE
                HeaderTextStream &= StrDup(617, " ")                                                                ' Relleno

                ' Trailer
                TrailerTextStream = "T"                                                                              ' Tipo de Registro TRAILER
                TrailerTextStream &= DetalleImporteTotal.ToString("0000000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")    ' Total Importe 1er. vencimiento
                TrailerTextStream &= StrDup(15, "0")                                                                 ' Ceros
                TrailerTextStream &= DetalleCount.ToString("0000000")                                                ' Cantidad de registros de detalle
                TrailerTextStream &= StrDup(612, " ")                                                                ' Relleno

                ' Exporto todo al archivo
                outputFile.Write(HeaderTextStream & vbCrLf & DetalleTextStream & TrailerTextStream)
            End Using

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al intentar guardar los datos en el archivo de destino.")
            Return False
        End Try

        CS_Parameter_System.SetIntegerAsInteger(Parametros.BANCOSANTANDER_PIRYP_NUMEROULTIMOENVIO, NumeroUltimoEnvio + 1)

        HeaderTextStream = Nothing
        DetalleTextStream = Nothing
        TrailerTextStream = Nothing

        MsgBox(String.Format("Se ha generado exitosamente el archivo de intercambio con Banco Santander - Recaudación Por Caja, conteniendo {1} Comprobantes.{0}{0}Ubicación:{0}{2}", vbCrLf, DetalleCount, FolderName & FileName), MsgBoxStyle.Information, My.Application.Info.Title)

        RefreshData()

        Me.Cursor = Cursors.Default

        Return True
    End Function

    Private Function ExportarComprobantesAPiryp() As Boolean
        Dim DetalleTextStream As String = ""

        Dim GridDataRowActual As GridDataRow
        Dim ComprobanteActual As Comprobante
        Dim DetalleCount As Integer = 0
        Dim DetalleImporteTotal As Decimal = 0

        Dim InteresTasaNominalAnual As Decimal

        Dim FolderName As String = ""
        Dim FileName As String

        ' Obtengo y verifico si existe la carpeta de destino de los archivos a exportar
        Try
            FolderName = CardonerSistemas.SpecialFolders.ProcessString(My.Settings.Exchange_Outbound_Santander_Piryp_Folder)
            If Not FolderName.EndsWith("\") Then
                FolderName &= "\"
            End If
            If Not FolderName.EndsWith("\") Then
                FolderName &= "\"
            End If
            If Not Directory.Exists(FolderName) Then
                Directory.CreateDirectory(FolderName)
            End If

        Catch avex As AccessViolationException
            MsgBox("La aplicación no tiene permisos para acceder o crear la carpeta especificada.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Return False

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error el acceder o crear la carpeta especificada.")
        End Try

        FileName = CardonerSistemas.Files.RemoveInvalidFileNameChars(String.Format("Lote - {0}.txt", comboboxComprobanteLote.Text))

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        InteresTasaNominalAnual = CS_Parameter_System.GetDecimal(Parametros.INTERES_TASA_NOMINAL_ANUAL)

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
                    DetalleTextStream &= StrDup(5, "0"c)                                                    ' Filler
                    DetalleTextStream &= ComprobanteActual.IDComprobante.ToString.PadRight(30, " "c)        ' Referencia Empresa
                    If ComprobanteActual.FechaVencimiento2.HasValue Then
                        DetalleTextStream &= ComprobanteActual.FechaVencimiento2.Value.ToString("yyyyMMdd") ' Fecha 2do. vencimiento
                        DetalleTextStream &= ComprobanteActual.ImporteTotal2.Value.ToString("0000000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")    ' Importe 2do. vencimiento
                    Else
                        DetalleTextStream &= ComprobanteActual.FechaVencimiento1.Value.AddDays(10).ToString("yyyyMMdd")      ' Fecha 2do. vencimiento
                        DetalleTextStream &= ComprobanteActual.ImporteTotal1.ToString("0000000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")    ' Importe 2do. vencimiento
                    End If
                    DetalleTextStream &= ComprobanteActual.FechaVencimiento1.Value.AddMonths(1).ToString("yyyyMMdd") ' Fecha Vto. Punitorios
                    DetalleTextStream &= InteresTasaNominalAnual.ToString("00000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "") ' TNA
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