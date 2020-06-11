Imports System.IO
Public Class formComprobantesTransmitirSantanderDebitoDirecto

#Region "Declarations"
    Private dbContext As New CSColegioContext(True)
    Private listComprobantes As List(Of GridDataRow)
    Private FechaVencimientoComprobantes As Date = Nothing

    Private Class GridDataRow
        Public Property IDComprobante As Integer
        Public Property ComprobanteTipoNombre As String
        Public Property NumeroCompleto As String
        Public Property ApellidoNombre As String
        Public Property ImporteTotal As Decimal
        Public Property FechaVencimiento As Date
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

        Me.Cursor = Cursors.WaitCursor

        Try

            If Not comboboxComprobanteLote.SelectedValue Is Nothing Then
                ComprobanteLoteActual = CType(comboboxComprobanteLote.SelectedItem, ComprobanteLote)

                listComprobantes = (From c In dbContext.Comprobante
                                    Join cl In dbContext.ComprobanteLote On c.IDComprobanteLote Equals cl.IDComprobanteLote
                                    Join ct In dbContext.ComprobanteTipo On c.IDComprobanteTipo Equals ct.IDComprobanteTipo
                                    Join e In dbContext.Entidad On c.IDEntidad Equals e.IDEntidad
                                    Where c.IDComprobanteLote = ComprobanteLoteActual.IDComprobanteLote And ct.EmisionElectronica And c.CAE IsNot Nothing And c.IDUsuarioAnulacion Is Nothing And e.DebitoAutomaticoTipo = Constantes.ENTIDAD_DEBITOAUTOMATICOTIPO_DEBITODIRECTO
                                    Order By ct.Nombre, c.NumeroCompleto
                                    Select New GridDataRow With {.IDComprobante = c.IDComprobante, .ComprobanteTipoNombre = ct.Nombre, .NumeroCompleto = c.NumeroCompleto, .ApellidoNombre = c.ApellidoNombre, .ImporteTotal = c.ImporteTotal1, .FechaVencimiento = c.FechaVencimiento1.Value}).ToList

                Select Case listComprobantes.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Comprobantes para mostrar.")
                        FechaVencimientoComprobantes = Nothing
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Comprobante.")
                        FechaVencimientoComprobantes = listComprobantes.First.FechaVencimiento
                        datetimepickkerFechaVencimiento.Value = listComprobantes.First.FechaVencimiento
                        datetimepickkerFechaVencimiento.Checked = False
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0} Comprobantes.", listComprobantes.Count)
                        FechaVencimientoComprobantes = listComprobantes.First.FechaVencimiento
                        datetimepickkerFechaVencimiento.Value = listComprobantes.First.FechaVencimiento
                        datetimepickkerFechaVencimiento.Checked = False
                End Select
            Else
                listComprobantes = Nothing
                FechaVencimientoComprobantes = Nothing
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

    Private Sub Exportar_Click(sender As Object, e As EventArgs) Handles buttonExportar.Click
        Dim DiasPreviosAlVencimiento As Integer

        If listComprobantes.Count > 0 Then
            If CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_CODIGOEMPRESA) = "" Then
                MsgBox("No está especificado el Código de Empresa otorgado por el Banco Santander.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Exit Sub
            End If
            If CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_CODIGOSERVICIO) = "" Then
                MsgBox("No está especificado el Código de Servicio otorgado por el Banco Santander.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Exit Sub
            End If

            DiasPreviosAlVencimiento = CS_Parameter_System.GetIntegerAsInteger(Parametros.BANCOSANTANDER_ADDI_DIASPREVIOSVENCIMIENTO, 0)
            If DiasPreviosAlVencimiento > 0 Then
                If datetimepickkerFechaVencimiento.Checked Then
                    If DateAndTime.DateDiff("d", Today, datetimepickkerFechaVencimiento.Value) < DiasPreviosAlVencimiento Then
                        MsgBox(String.Format("La fecha de vencimiento debe ser mayor a la fecha actual al menos en {0} días.", DiasPreviosAlVencimiento), MsgBoxStyle.Exclamation, My.Application.Info.Title)
                        Exit Sub
                    End If
                Else
                    If DateAndTime.DateDiff("d", Today, FechaVencimientoComprobantes) < DiasPreviosAlVencimiento Then
                        MsgBox(String.Format("La fecha de vencimiento debe ser mayor a la fecha actual al menos en {0} días.", DiasPreviosAlVencimiento), MsgBoxStyle.Exclamation, My.Application.Info.Title)
                        Exit Sub
                    End If
                End If
            Else
                If DateAndTime.DateDiff("d", Today, FechaVencimientoComprobantes) < 0 Then
                    MsgBox("La fecha de vencimiento debe ser mayor o igual a la fecha actual.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                    Exit Sub
                End If
            End If

            ExportarComprobantes()
        End If
    End Sub
#End Region

#Region "Extra stuff"

    Private Function ExportarComprobantes() As Boolean
        Dim HeaderTextStream As String = ""
        Dim DetalleTextStream As String = ""

        Dim GridDataRowActual As GridDataRow
        Dim ComprobanteActual As Comprobante
        Dim DetalleCount As Integer = 0
        Dim DetalleImporteTotal As Decimal = 0

        Dim FolderName As String = ""
        Dim FileName As String

        ' Obtengo y verifico si existe la carpeta de destino de los archivos a exportar
        Try
            FolderName = CardonerSistemas.SpecialFolders.ProcessString(pSantanderAddiConfig.OutboundFolder)
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

        FileName = CardonerSistemas.Files.RemoveInvalidFileNameChars(String.Format("Lote - {0}.deb", comboboxComprobanteLote.Text))

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        Using outputFile As New StreamWriter(FolderName & FileName, False, New System.Text.UTF8Encoding)

            For Each RowActual As DataGridViewRow In datagridviewComprobantes.Rows
                GridDataRowActual = CType(RowActual.DataBoundItem, GridDataRow)
                ComprobanteActual = dbContext.Comprobante.Find(GridDataRowActual.IDComprobante)
                If Not ComprobanteActual Is Nothing Then
                    ' Detalle
                    DetalleTextStream &= "11"                                                               ' Tipo de Registro
                    DetalleTextStream &= CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_CODIGOSERVICIO).PadRight(10, " "c)  ' Código de Servicio
                    DetalleTextStream &= ComprobanteActual.Entidad.IDEntidad.ToString("000000").PadRight(22, " "c)          ' Número de Partida
                    DetalleTextStream &= ComprobanteActual.Entidad.DebitoAutomatico_Directo_CBU             ' CBU
                    If datetimepickkerFechaVencimiento.Checked Then
                        DetalleTextStream &= datetimepickkerFechaVencimiento.Value.ToString("yyyyMMdd")     ' Fecha 1er. vencimiento
                    Else
                        DetalleTextStream &= ComprobanteActual.FechaVencimiento1.Value.ToString("yyyyMMdd")     ' Fecha 1er. vencimiento
                    End If
                    DetalleTextStream &= ComprobanteActual.ImporteTotal1.ToString("00000000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")    ' Importe 1er. vencimiento
                    DetalleTextStream &= (ComprobanteActual.ComprobanteTipo.Sigla & ComprobanteActual.PuntoVenta & ComprobanteActual.Numero).PadRight(15, " "c)       ' Identificación Débito

                    ' Esto se modificó para no tener que informar el nombre del adherente porque a veces se debita de la cuenta de otro titular diferente al de la factura
                    DetalleTextStream &= Space(30)          ' Nombre del Adherente
                    'DetalleTextStream &= CS_String.RemoveDiacritics(ComprobanteActual.ApellidoNombre).PadRight(30, " "c).Substring(0, 30)   ' Nombre del Adherente

                    DetalleTextStream &= " "                                                                ' Filler
                    DetalleTextStream &= ComprobanteActual.IDComprobante.ToString.PadRight(50, " "c)        ' Referencia Empresa

                    DetalleTextStream &= vbCrLf

                    DetalleCount += 1
                    DetalleImporteTotal += ComprobanteActual.ImporteTotal1
                End If
            Next

            ' Header
            HeaderTextStream = "10"                                                                             ' Tipo de Registro
            HeaderTextStream &= DateTime.Today.ToString("yyyyMMdd")                                             ' Fecha de generación del archivo
            HeaderTextStream &= DetalleCount.ToString.PadLeft(5, "0"c)                                          ' Cantidad de registros de detalle
            HeaderTextStream &= DetalleImporteTotal.ToString("00000000000000000.00").Replace(My.Application.Culture.NumberFormat.NumberDecimalSeparator, "")      ' Total Importe

            ' Exporto todo al archivo
            outputFile.WriteLine(HeaderTextStream & vbCrLf & DetalleTextStream)
        End Using

        MsgBox(String.Format("Se ha generado exitosamente el archivo de intercambio con Banco Santander - Débito Directo, conteniendo {0} Comprobantes.", DetalleCount), MsgBoxStyle.Information, My.Application.Info.Title)

        RefreshData()

        Me.Cursor = Cursors.Default

        Return True
    End Function

#End Region

End Class