Public Class formComprobantesRecibirSantanderDebitoDirecto

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
    Private Sub formComprobantesRecibirSantanderDebitoDirecto_Load() Handles Me.Load
        textboxUbicacionArchivos.Text = CardonerSistemas.SpecialFolders.ProcessString(pSantanderConfig.AddiInboundFolder)
    End Sub

    Private Sub formComprobantesRecibirSantanderDebitoDirecto_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbContext.Dispose()
    End Sub
#End Region

#Region "Controls"
    Private Sub Examinar() Handles buttonUbicacionArchivos.Click
        Dim SeleccionadorCarpeta As New System.Windows.Forms.FolderBrowserDialog()

    End Sub

    Private Sub ListarArchivos(sender As Object, e As EventArgs) Handles buttonMostrar.Click
        If CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_CODIGOEMPRESA) = "" Then
            MsgBox("No está especificado el Código de Empresa otorgado por el Banco Santander.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Exit Sub
        End If
        If CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_CODIGOSERVICIO) = "" Then
            MsgBox("No está especificado el Código de Servicio otorgado por el Banco Santander.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Exit Sub
        End If

        If textboxUbicacionArchivos.Text.Trim.Length = 0 Then
            MsgBox("Debe especificar la Carpeta de ubicación de los archivos.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxUbicacionArchivos.Focus()
            Exit Sub
        End If

        Try
            If Not My.Computer.FileSystem.DirectoryExists(textboxUbicacionArchivos.Text.Trim) Then
                MsgBox("La Carpeta especificada no existe.", MsgBoxStyle.Information, My.Application.Info.Title)
                Exit Sub
            End If

        Catch avex As AccessViolationException
            MsgBox("La aplicación no tiene permisos para acceder a la Carpeta especificada.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
            Exit Sub

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error el acceder a la Carpeta especificada.")
        End Try

        Dim CollectionOfFileNames As System.Collections.ObjectModel.ReadOnlyCollection(Of String)

        Try
            CollectionOfFileNames = My.Computer.FileSystem.GetFiles(textboxUbicacionArchivos.Text.Trim, FileIO.SearchOption.SearchTopLevelOnly, CS_Parameter_System.GetString(Parametros.BANCOSANTANDER_ADDI_CODIGOSERVICIO).Substring(0, 4) & "*.deb")
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener la lista de Archivos de la Carpeta especificada.")
            Exit Sub
        End Try

        listboxArchivosEncontrados.SuspendLayout()
        listboxArchivosEncontrados.Items.Clear()
        For Each CurrentFileName As String In CollectionOfFileNames
            listboxArchivosEncontrados.Items.Add(CurrentFileName)
        Next
        listboxArchivosEncontrados.ResumeLayout()
    End Sub

#End Region

End Class