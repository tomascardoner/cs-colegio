<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formMDIMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formMDIMain))
        Me.statusstripMain = New System.Windows.Forms.StatusStrip()
        Me.labelStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.labelUsuarioNombre = New System.Windows.Forms.ToolStripStatusLabel()
        Me.menustripMain = New System.Windows.Forms.MenuStrip()
        Me.menuitemArchivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemArchivo_Opciones = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemArchivo_Separador_CerrarSesion = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemArchivo_CerrarSesion = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemArchivo_Separador_Salir = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemArchivo_Salir = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDebug = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDebugAFIPWS = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDebugAFIPWSHomologacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDebugAFIPWSHomologacionLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDebugAFIPWSHomologacionCompConsultar = New System.Windows.Forms.ToolStripMenuItem()
        Me.TestFormToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentana = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaMosaicoHorizontal = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaMosaicoVertical = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaCascada = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaOrganizarIconos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaSeparadorCerrarTodas = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemVentanaCerrarTodas = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaEncajarEnVentana = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaSeparadorListaVentanas = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemAyuda_AcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.dropdownbuttonTablas = New System.Windows.Forms.ToolStripDropDownButton()
        Me.menuitemAnios = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemCursos = New System.Windows.Forms.ToolStripMenuItem()
        Me.separatorBancos = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemBancos = New System.Windows.Forms.ToolStripMenuItem()
        Me.separatorRelacionTipos = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemRelacionTipos = New System.Windows.Forms.ToolStripMenuItem()
        Me.buttonEntidades = New System.Windows.Forms.ToolStripSplitButton()
        Me.menuitemEntidadesAniosLectivosYCursos = New System.Windows.Forms.ToolStripMenuItem()
        Me.buttonComprobantes = New System.Windows.Forms.ToolStripSplitButton()
        Me.menuitemComprobantesGenerarLoteFacturas = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemComprobantesTransmitirAFIP = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemComprobantesEnviarMail = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemComprobantesExportar = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemComprobantesExportarPagomiscuentas = New System.Windows.Forms.ToolStripMenuItem()
        Me.DébitoDirectoSantanderToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RapipagoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.buttonReportes = New System.Windows.Forms.ToolStripButton()
        Me.menuitemAniosLectivosCursos = New System.Windows.Forms.ToolStripMenuItem()
        Me.statusstripMain.SuspendLayout()
        Me.menustripMain.SuspendLayout()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'statusstripMain
        '
        Me.statusstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelStatus, Me.labelUsuarioNombre})
        Me.statusstripMain.Location = New System.Drawing.Point(0, 513)
        Me.statusstripMain.Name = "statusstripMain"
        Me.statusstripMain.Size = New System.Drawing.Size(928, 22)
        Me.statusstripMain.TabIndex = 2
        '
        'labelStatus
        '
        Me.labelStatus.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.labelStatus.Name = "labelStatus"
        Me.labelStatus.Size = New System.Drawing.Size(913, 17)
        Me.labelStatus.Spring = True
        '
        'labelUsuarioNombre
        '
        Me.labelUsuarioNombre.Name = "labelUsuarioNombre"
        Me.labelUsuarioNombre.Size = New System.Drawing.Size(0, 17)
        '
        'menustripMain
        '
        Me.menustripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemArchivo, Me.menuitemDebug, Me.menuitemVentana, Me.menuitemAyuda})
        Me.menustripMain.Location = New System.Drawing.Point(0, 0)
        Me.menustripMain.MdiWindowListItem = Me.menuitemVentana
        Me.menustripMain.Name = "menustripMain"
        Me.menustripMain.Size = New System.Drawing.Size(928, 24)
        Me.menustripMain.TabIndex = 0
        '
        'menuitemArchivo
        '
        Me.menuitemArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemArchivo_Opciones, Me.menuitemArchivo_Separador_CerrarSesion, Me.menuitemArchivo_CerrarSesion, Me.menuitemArchivo_Separador_Salir, Me.menuitemArchivo_Salir})
        Me.menuitemArchivo.Name = "menuitemArchivo"
        Me.menuitemArchivo.Size = New System.Drawing.Size(60, 20)
        Me.menuitemArchivo.Text = "&Archivo"
        '
        'menuitemArchivo_Opciones
        '
        Me.menuitemArchivo_Opciones.Name = "menuitemArchivo_Opciones"
        Me.menuitemArchivo_Opciones.Size = New System.Drawing.Size(204, 22)
        Me.menuitemArchivo_Opciones.Text = "Opciones"
        '
        'menuitemArchivo_Separador_CerrarSesion
        '
        Me.menuitemArchivo_Separador_CerrarSesion.Name = "menuitemArchivo_Separador_CerrarSesion"
        Me.menuitemArchivo_Separador_CerrarSesion.Size = New System.Drawing.Size(201, 6)
        '
        'menuitemArchivo_CerrarSesion
        '
        Me.menuitemArchivo_CerrarSesion.Name = "menuitemArchivo_CerrarSesion"
        Me.menuitemArchivo_CerrarSesion.Size = New System.Drawing.Size(204, 22)
        Me.menuitemArchivo_CerrarSesion.Text = "Cerrar sesión del Usuario"
        '
        'menuitemArchivo_Separador_Salir
        '
        Me.menuitemArchivo_Separador_Salir.Name = "menuitemArchivo_Separador_Salir"
        Me.menuitemArchivo_Separador_Salir.Size = New System.Drawing.Size(201, 6)
        '
        'menuitemArchivo_Salir
        '
        Me.menuitemArchivo_Salir.Name = "menuitemArchivo_Salir"
        Me.menuitemArchivo_Salir.Size = New System.Drawing.Size(204, 22)
        Me.menuitemArchivo_Salir.Text = "&Salir"
        '
        'menuitemDebug
        '
        Me.menuitemDebug.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemDebugAFIPWS, Me.TestFormToolStripMenuItem})
        Me.menuitemDebug.Name = "menuitemDebug"
        Me.menuitemDebug.Size = New System.Drawing.Size(54, 20)
        Me.menuitemDebug.Text = "Debug"
        Me.menuitemDebug.Visible = False
        '
        'menuitemDebugAFIPWS
        '
        Me.menuitemDebugAFIPWS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemDebugAFIPWSHomologacion})
        Me.menuitemDebugAFIPWS.Name = "menuitemDebugAFIPWS"
        Me.menuitemDebugAFIPWS.Size = New System.Drawing.Size(167, 22)
        Me.menuitemDebugAFIPWS.Text = "AFIP WebServices"
        '
        'menuitemDebugAFIPWSHomologacion
        '
        Me.menuitemDebugAFIPWSHomologacion.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemDebugAFIPWSHomologacionLogin, Me.menuitemDebugAFIPWSHomologacionCompConsultar})
        Me.menuitemDebugAFIPWSHomologacion.Name = "menuitemDebugAFIPWSHomologacion"
        Me.menuitemDebugAFIPWSHomologacion.Size = New System.Drawing.Size(154, 22)
        Me.menuitemDebugAFIPWSHomologacion.Text = "Homologación"
        '
        'menuitemDebugAFIPWSHomologacionLogin
        '
        Me.menuitemDebugAFIPWSHomologacionLogin.Name = "menuitemDebugAFIPWSHomologacionLogin"
        Me.menuitemDebugAFIPWSHomologacionLogin.Size = New System.Drawing.Size(238, 22)
        Me.menuitemDebugAFIPWSHomologacionLogin.Text = "Login"
        '
        'menuitemDebugAFIPWSHomologacionCompConsultar
        '
        Me.menuitemDebugAFIPWSHomologacionCompConsultar.Name = "menuitemDebugAFIPWSHomologacionCompConsultar"
        Me.menuitemDebugAFIPWSHomologacionCompConsultar.Size = New System.Drawing.Size(238, 22)
        Me.menuitemDebugAFIPWSHomologacionCompConsultar.Text = "Consultar último comprobante"
        '
        'TestFormToolStripMenuItem
        '
        Me.TestFormToolStripMenuItem.Name = "TestFormToolStripMenuItem"
        Me.TestFormToolStripMenuItem.Size = New System.Drawing.Size(167, 22)
        Me.TestFormToolStripMenuItem.Text = "Test Form"
        '
        'menuitemVentana
        '
        Me.menuitemVentana.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemVentanaMosaicoHorizontal, Me.menuitemVentanaMosaicoVertical, Me.menuitemVentanaCascada, Me.menuitemVentanaOrganizarIconos, Me.menuitemVentanaSeparadorCerrarTodas, Me.menuitemVentanaCerrarTodas, Me.menuitemVentanaEncajarEnVentana, Me.menuitemVentanaSeparadorListaVentanas})
        Me.menuitemVentana.Name = "menuitemVentana"
        Me.menuitemVentana.Size = New System.Drawing.Size(61, 20)
        Me.menuitemVentana.Text = "&Ventana"
        '
        'menuitemVentanaMosaicoHorizontal
        '
        Me.menuitemVentanaMosaicoHorizontal.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MENU_WINDOW_TILE_HORIZONTALLY
        Me.menuitemVentanaMosaicoHorizontal.Name = "menuitemVentanaMosaicoHorizontal"
        Me.menuitemVentanaMosaicoHorizontal.Size = New System.Drawing.Size(177, 22)
        Me.menuitemVentanaMosaicoHorizontal.Text = "Mosaico &Horizontal"
        '
        'menuitemVentanaMosaicoVertical
        '
        Me.menuitemVentanaMosaicoVertical.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MENU_WINDOW_TILE_VERTICALLY
        Me.menuitemVentanaMosaicoVertical.Name = "menuitemVentanaMosaicoVertical"
        Me.menuitemVentanaMosaicoVertical.Size = New System.Drawing.Size(177, 22)
        Me.menuitemVentanaMosaicoVertical.Text = "Mosaico &Vertical"
        '
        'menuitemVentanaCascada
        '
        Me.menuitemVentanaCascada.Name = "menuitemVentanaCascada"
        Me.menuitemVentanaCascada.Size = New System.Drawing.Size(177, 22)
        Me.menuitemVentanaCascada.Text = "&Cascada"
        '
        'menuitemVentanaOrganizarIconos
        '
        Me.menuitemVentanaOrganizarIconos.Name = "menuitemVentanaOrganizarIconos"
        Me.menuitemVentanaOrganizarIconos.Size = New System.Drawing.Size(177, 22)
        Me.menuitemVentanaOrganizarIconos.Text = "&Organizar Iconos"
        '
        'menuitemVentanaSeparadorCerrarTodas
        '
        Me.menuitemVentanaSeparadorCerrarTodas.Name = "menuitemVentanaSeparadorCerrarTodas"
        Me.menuitemVentanaSeparadorCerrarTodas.Size = New System.Drawing.Size(174, 6)
        '
        'menuitemVentanaCerrarTodas
        '
        Me.menuitemVentanaCerrarTodas.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MENU_WINDOW_CLOSE_ALL
        Me.menuitemVentanaCerrarTodas.Name = "menuitemVentanaCerrarTodas"
        Me.menuitemVentanaCerrarTodas.Size = New System.Drawing.Size(177, 22)
        Me.menuitemVentanaCerrarTodas.Text = "Cerrar todas"
        '
        'menuitemVentanaEncajarEnVentana
        '
        Me.menuitemVentanaEncajarEnVentana.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MENU_WINDOW_FIT_SIZE
        Me.menuitemVentanaEncajarEnVentana.Name = "menuitemVentanaEncajarEnVentana"
        Me.menuitemVentanaEncajarEnVentana.Size = New System.Drawing.Size(177, 22)
        Me.menuitemVentanaEncajarEnVentana.Text = "Encajar en ventana"
        '
        'menuitemVentanaSeparadorListaVentanas
        '
        Me.menuitemVentanaSeparadorListaVentanas.Name = "menuitemVentanaSeparadorListaVentanas"
        Me.menuitemVentanaSeparadorListaVentanas.Size = New System.Drawing.Size(174, 6)
        '
        'menuitemAyuda
        '
        Me.menuitemAyuda.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemAyuda_AcercaDe})
        Me.menuitemAyuda.Name = "menuitemAyuda"
        Me.menuitemAyuda.Size = New System.Drawing.Size(53, 20)
        Me.menuitemAyuda.Text = "A&yuda"
        '
        'menuitemAyuda_AcercaDe
        '
        Me.menuitemAyuda_AcercaDe.Name = "menuitemAyuda_AcercaDe"
        Me.menuitemAyuda_AcercaDe.Size = New System.Drawing.Size(135, 22)
        Me.menuitemAyuda_AcercaDe.Text = "&Acerca de..."
        '
        'toolstripMain
        '
        Me.toolstripMain.AllowMerge = False
        Me.toolstripMain.Dock = System.Windows.Forms.DockStyle.Left
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.dropdownbuttonTablas, Me.buttonEntidades, Me.buttonComprobantes, Me.buttonReportes})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 24)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(135, 489)
        Me.toolstripMain.TabIndex = 1
        Me.toolstripMain.Text = "Principal"
        '
        'dropdownbuttonTablas
        '
        Me.dropdownbuttonTablas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemAnios, Me.menuitemCursos, Me.menuitemAniosLectivosCursos, Me.separatorBancos, Me.menuitemBancos, Me.separatorRelacionTipos, Me.menuitemRelacionTipos})
        Me.dropdownbuttonTablas.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_TABLAS_32
        Me.dropdownbuttonTablas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.dropdownbuttonTablas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.dropdownbuttonTablas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.dropdownbuttonTablas.Name = "dropdownbuttonTablas"
        Me.dropdownbuttonTablas.Size = New System.Drawing.Size(132, 36)
        Me.dropdownbuttonTablas.Text = "Tablas"
        '
        'menuitemAnios
        '
        Me.menuitemAnios.Name = "menuitemAnios"
        Me.menuitemAnios.Size = New System.Drawing.Size(195, 22)
        Me.menuitemAnios.Text = "Años"
        '
        'menuitemCursos
        '
        Me.menuitemCursos.Name = "menuitemCursos"
        Me.menuitemCursos.Size = New System.Drawing.Size(195, 22)
        Me.menuitemCursos.Text = "Cursos"
        '
        'separatorBancos
        '
        Me.separatorBancos.Name = "separatorBancos"
        Me.separatorBancos.Size = New System.Drawing.Size(192, 6)
        '
        'menuitemBancos
        '
        Me.menuitemBancos.Name = "menuitemBancos"
        Me.menuitemBancos.Size = New System.Drawing.Size(195, 22)
        Me.menuitemBancos.Text = "Bancos"
        '
        'separatorRelacionTipos
        '
        Me.separatorRelacionTipos.Name = "separatorRelacionTipos"
        Me.separatorRelacionTipos.Size = New System.Drawing.Size(192, 6)
        '
        'menuitemRelacionTipos
        '
        Me.menuitemRelacionTipos.Name = "menuitemRelacionTipos"
        Me.menuitemRelacionTipos.Size = New System.Drawing.Size(195, 22)
        Me.menuitemRelacionTipos.Text = "Tipos de Relación"
        '
        'buttonEntidades
        '
        Me.buttonEntidades.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemEntidadesAniosLectivosYCursos})
        Me.buttonEntidades.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ENTIDADES_32
        Me.buttonEntidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonEntidades.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEntidades.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEntidades.Name = "buttonEntidades"
        Me.buttonEntidades.Size = New System.Drawing.Size(132, 36)
        Me.buttonEntidades.Text = "Entidades"
        '
        'menuitemEntidadesAniosLectivosYCursos
        '
        Me.menuitemEntidadesAniosLectivosYCursos.Name = "menuitemEntidadesAniosLectivosYCursos"
        Me.menuitemEntidadesAniosLectivosYCursos.Size = New System.Drawing.Size(195, 22)
        Me.menuitemEntidadesAniosLectivosYCursos.Text = "Años Lectivos y Cursos"
        '
        'buttonComprobantes
        '
        Me.buttonComprobantes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemComprobantesGenerarLoteFacturas, Me.menuitemComprobantesTransmitirAFIP, Me.menuitemComprobantesEnviarMail, Me.ToolStripMenuItem1, Me.menuitemComprobantesExportar})
        Me.buttonComprobantes.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_COMPROBANTES_32
        Me.buttonComprobantes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonComprobantes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonComprobantes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonComprobantes.Name = "buttonComprobantes"
        Me.buttonComprobantes.Size = New System.Drawing.Size(132, 36)
        Me.buttonComprobantes.Text = "Comprobantes"
        '
        'menuitemComprobantesGenerarLoteFacturas
        '
        Me.menuitemComprobantesGenerarLoteFacturas.Name = "menuitemComprobantesGenerarLoteFacturas"
        Me.menuitemComprobantesGenerarLoteFacturas.Size = New System.Drawing.Size(220, 38)
        Me.menuitemComprobantesGenerarLoteFacturas.Text = "Generar Lote de Facturas"
        '
        'menuitemComprobantesTransmitirAFIP
        '
        Me.menuitemComprobantesTransmitirAFIP.Name = "menuitemComprobantesTransmitirAFIP"
        Me.menuitemComprobantesTransmitirAFIP.Size = New System.Drawing.Size(220, 38)
        Me.menuitemComprobantesTransmitirAFIP.Text = "Transmitir a AFIP"
        '
        'menuitemComprobantesEnviarMail
        '
        Me.menuitemComprobantesEnviarMail.Name = "menuitemComprobantesEnviarMail"
        Me.menuitemComprobantesEnviarMail.Size = New System.Drawing.Size(220, 38)
        Me.menuitemComprobantesEnviarMail.Text = "Enviar por e-mail"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(217, 6)
        '
        'menuitemComprobantesExportar
        '
        Me.menuitemComprobantesExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemComprobantesExportarPagomiscuentas, Me.DébitoDirectoSantanderToolStripMenuItem, Me.RapipagoToolStripMenuItem})
        Me.menuitemComprobantesExportar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_EXPORT_32
        Me.menuitemComprobantesExportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.menuitemComprobantesExportar.Name = "menuitemComprobantesExportar"
        Me.menuitemComprobantesExportar.Size = New System.Drawing.Size(220, 38)
        Me.menuitemComprobantesExportar.Text = "Exportar archivos para..."
        '
        'menuitemComprobantesExportarPagomiscuentas
        '
        Me.menuitemComprobantesExportarPagomiscuentas.Name = "menuitemComprobantesExportarPagomiscuentas"
        Me.menuitemComprobantesExportarPagomiscuentas.Size = New System.Drawing.Size(206, 22)
        Me.menuitemComprobantesExportarPagomiscuentas.Text = "PagoMisCuentas"
        '
        'DébitoDirectoSantanderToolStripMenuItem
        '
        Me.DébitoDirectoSantanderToolStripMenuItem.Name = "DébitoDirectoSantanderToolStripMenuItem"
        Me.DébitoDirectoSantanderToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.DébitoDirectoSantanderToolStripMenuItem.Text = "Débito Directo Santander"
        '
        'RapipagoToolStripMenuItem
        '
        Me.RapipagoToolStripMenuItem.Name = "RapipagoToolStripMenuItem"
        Me.RapipagoToolStripMenuItem.Size = New System.Drawing.Size(206, 22)
        Me.RapipagoToolStripMenuItem.Text = "Rapipago"
        '
        'buttonReportes
        '
        Me.buttonReportes.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_REPORTES_32
        Me.buttonReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonReportes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonReportes.Name = "buttonReportes"
        Me.buttonReportes.Size = New System.Drawing.Size(132, 36)
        Me.buttonReportes.Text = "Reportes"
        '
        'menuitemAniosLectivosCursos
        '
        Me.menuitemAniosLectivosCursos.Name = "menuitemAniosLectivosCursos"
        Me.menuitemAniosLectivosCursos.Size = New System.Drawing.Size(195, 22)
        Me.menuitemAniosLectivosCursos.Text = "Años Lectivos y Cursos"
        '
        'formMDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(928, 535)
        Me.Controls.Add(Me.toolstripMain)
        Me.Controls.Add(Me.statusstripMain)
        Me.Controls.Add(Me.menustripMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.menustripMain
        Me.Name = "formMDIMain"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds
        Me.Text = "Title"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.statusstripMain.ResumeLayout(False)
        Me.statusstripMain.PerformLayout()
        Me.menustripMain.ResumeLayout(False)
        Me.menustripMain.PerformLayout()
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents statusstripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents labelUsuarioNombre As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents labelStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents menustripMain As System.Windows.Forms.MenuStrip
    Friend WithEvents menuitemArchivo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemArchivo_Opciones As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemArchivo_Separador_CerrarSesion As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuitemArchivo_CerrarSesion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemArchivo_Separador_Salir As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuitemArchivo_Salir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemVentana As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemVentanaMosaicoHorizontal As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemVentanaMosaicoVertical As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemVentanaCascada As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemVentanaOrganizarIconos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemVentanaSeparadorCerrarTodas As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuitemVentanaCerrarTodas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemVentanaEncajarEnVentana As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemAyuda As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemAyuda_AcercaDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents dropdownbuttonTablas As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents menuitemAnios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemCursos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents separatorBancos As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuitemBancos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents separatorRelacionTipos As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuitemRelacionTipos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemVentanaSeparadorListaVentanas As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents buttonComprobantes As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents menuitemComprobantesGenerarLoteFacturas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents buttonEntidades As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents menuitemEntidadesAniosLectivosYCursos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemDebug As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemDebugAFIPWS As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemDebugAFIPWSHomologacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemDebugAFIPWSHomologacionLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemComprobantesTransmitirAFIP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemComprobantesEnviarMail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents buttonReportes As System.Windows.Forms.ToolStripButton
    Friend WithEvents menuitemDebugAFIPWSHomologacionCompConsultar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TestFormToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuitemComprobantesExportar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemComprobantesExportarPagomiscuentas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DébitoDirectoSantanderToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RapipagoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemAniosLectivosCursos As System.Windows.Forms.ToolStripMenuItem
End Class
