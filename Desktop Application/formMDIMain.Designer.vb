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
        Me.menuitemVentana = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaMosaicoHorizontal = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaMosaicoVertical = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaCascada = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaOrganizarIconos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaSeparadorCerrarTodas = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemVentanaCerrarTodas = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaEncajarEnVentana = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemVentanaSeparadorListaVentanas = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemDebug = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDebugAFIPWS = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDebugAFIPWSHomologacionLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDebugAFIPWSHomologacionObtenerUltimoComprobante = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDebugAFIPWSHomologacionConsultarComprobante = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDebugAFIPWSSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemDebugAFIPWSProduccionLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDebugAFIPWSProduccionObtenerUltimoComprobante = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDebugAFIPWSProduccionConsultarComprobante = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemAyuda_AcercaDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.dropdownbuttonTablas = New System.Windows.Forms.ToolStripDropDownButton()
        Me.menuitemAnios = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemCursos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemAniosLectivosCursos = New System.Windows.Forms.ToolStripMenuItem()
        Me.separatorBancos = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemBancos = New System.Windows.Forms.ToolStripMenuItem()
        Me.separatorRelacionTipos = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemRelacionTipos = New System.Windows.Forms.ToolStripMenuItem()
        Me.buttonEntidades = New System.Windows.Forms.ToolStripSplitButton()
        Me.menuitemEntidadesAniosLectivosYCursos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemEntidadesAnioLectivoCursoInscripcion = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemEntidadesVerificarEmails = New System.Windows.Forms.ToolStripMenuItem()
        Me.buttonComprobantes = New System.Windows.Forms.ToolStripSplitButton()
        Me.menuitemComprobantesGenerarLoteFacturas = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemComprobantesTransmitirAFIP = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemComprobantesEnviarMail = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemComprobantesExportar = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemComprobantesExportarPagomiscuentas = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemComprobantesExportarSantanderDebitoDirecto = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemComprobantesExportarSantanderRecaudacionPorCaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemComprobantesExportarRapipago = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarArchivosDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemComprobantesImportarPagomiscuentas = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemComprobantesImportarSantanderDebitoDirecto = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemComprobantesImportarSantanderRecaudacionPorCaja = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemComprobantesImportarRapipago = New System.Windows.Forms.ToolStripMenuItem()
        Me.buttonComunicaciones = New System.Windows.Forms.ToolStripSplitButton()
        Me.menuitemComunicacionesEnviarMail = New System.Windows.Forms.ToolStripMenuItem()
        Me.buttonReportes = New System.Windows.Forms.ToolStripButton()
        Me.statusstripMain.SuspendLayout()
        Me.menustripMain.SuspendLayout()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'statusstripMain
        '
        Me.statusstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
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
        Me.menustripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menustripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemArchivo, Me.menuitemVentana, Me.menuitemDebug, Me.menuitemAyuda})
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
        'menuitemDebug
        '
        Me.menuitemDebug.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemDebugAFIPWS})
        Me.menuitemDebug.Name = "menuitemDebug"
        Me.menuitemDebug.Size = New System.Drawing.Size(54, 20)
        Me.menuitemDebug.Text = "Debug"
        Me.menuitemDebug.Visible = False
        '
        'menuitemDebugAFIPWS
        '
        Me.menuitemDebugAFIPWS.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemDebugAFIPWSHomologacionLogin, Me.menuitemDebugAFIPWSHomologacionObtenerUltimoComprobante, Me.menuitemDebugAFIPWSHomologacionConsultarComprobante, Me.menuitemDebugAFIPWSSeparator1, Me.menuitemDebugAFIPWSProduccionLogin, Me.menuitemDebugAFIPWSProduccionObtenerUltimoComprobante, Me.menuitemDebugAFIPWSProduccionConsultarComprobante})
        Me.menuitemDebugAFIPWS.Name = "menuitemDebugAFIPWS"
        Me.menuitemDebugAFIPWS.Size = New System.Drawing.Size(167, 22)
        Me.menuitemDebugAFIPWS.Text = "AFIP WebServices"
        '
        'menuitemDebugAFIPWSHomologacionLogin
        '
        Me.menuitemDebugAFIPWSHomologacionLogin.Name = "menuitemDebugAFIPWSHomologacionLogin"
        Me.menuitemDebugAFIPWSHomologacionLogin.Size = New System.Drawing.Size(323, 22)
        Me.menuitemDebugAFIPWSHomologacionLogin.Text = "Homologación - Login"
        '
        'menuitemDebugAFIPWSHomologacionObtenerUltimoComprobante
        '
        Me.menuitemDebugAFIPWSHomologacionObtenerUltimoComprobante.Name = "menuitemDebugAFIPWSHomologacionObtenerUltimoComprobante"
        Me.menuitemDebugAFIPWSHomologacionObtenerUltimoComprobante.Size = New System.Drawing.Size(323, 22)
        Me.menuitemDebugAFIPWSHomologacionObtenerUltimoComprobante.Text = "Homologación - Verificar Ultimo Comprobante"
        '
        'menuitemDebugAFIPWSHomologacionConsultarComprobante
        '
        Me.menuitemDebugAFIPWSHomologacionConsultarComprobante.Name = "menuitemDebugAFIPWSHomologacionConsultarComprobante"
        Me.menuitemDebugAFIPWSHomologacionConsultarComprobante.Size = New System.Drawing.Size(323, 22)
        Me.menuitemDebugAFIPWSHomologacionConsultarComprobante.Text = "Homologación - Consultar Comprobante"
        '
        'menuitemDebugAFIPWSSeparator1
        '
        Me.menuitemDebugAFIPWSSeparator1.Name = "menuitemDebugAFIPWSSeparator1"
        Me.menuitemDebugAFIPWSSeparator1.Size = New System.Drawing.Size(320, 6)
        '
        'menuitemDebugAFIPWSProduccionLogin
        '
        Me.menuitemDebugAFIPWSProduccionLogin.Name = "menuitemDebugAFIPWSProduccionLogin"
        Me.menuitemDebugAFIPWSProduccionLogin.Size = New System.Drawing.Size(323, 22)
        Me.menuitemDebugAFIPWSProduccionLogin.Text = "Producción - Login"
        '
        'menuitemDebugAFIPWSProduccionObtenerUltimoComprobante
        '
        Me.menuitemDebugAFIPWSProduccionObtenerUltimoComprobante.Name = "menuitemDebugAFIPWSProduccionObtenerUltimoComprobante"
        Me.menuitemDebugAFIPWSProduccionObtenerUltimoComprobante.Size = New System.Drawing.Size(323, 22)
        Me.menuitemDebugAFIPWSProduccionObtenerUltimoComprobante.Text = "Producción - Verificar Ultimo Comprobante"
        '
        'menuitemDebugAFIPWSProduccionConsultarComprobante
        '
        Me.menuitemDebugAFIPWSProduccionConsultarComprobante.Name = "menuitemDebugAFIPWSProduccionConsultarComprobante"
        Me.menuitemDebugAFIPWSProduccionConsultarComprobante.Size = New System.Drawing.Size(323, 22)
        Me.menuitemDebugAFIPWSProduccionConsultarComprobante.Text = "Producción - Consultar Comprobante"
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
        Me.toolstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.dropdownbuttonTablas, Me.buttonEntidades, Me.buttonComprobantes, Me.buttonComunicaciones, Me.buttonReportes})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 24)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(145, 489)
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
        Me.dropdownbuttonTablas.Size = New System.Drawing.Size(142, 36)
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
        'menuitemAniosLectivosCursos
        '
        Me.menuitemAniosLectivosCursos.Name = "menuitemAniosLectivosCursos"
        Me.menuitemAniosLectivosCursos.Size = New System.Drawing.Size(195, 22)
        Me.menuitemAniosLectivosCursos.Text = "Años Lectivos y Cursos"
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
        Me.buttonEntidades.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemEntidadesAniosLectivosYCursos, Me.menuitemEntidadesAnioLectivoCursoInscripcion, Me.menuitemEntidadesVerificarEmails})
        Me.buttonEntidades.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ENTIDADES_32
        Me.buttonEntidades.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonEntidades.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEntidades.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEntidades.Name = "buttonEntidades"
        Me.buttonEntidades.Size = New System.Drawing.Size(142, 36)
        Me.buttonEntidades.Text = "Entidades"
        '
        'menuitemEntidadesAniosLectivosYCursos
        '
        Me.menuitemEntidadesAniosLectivosYCursos.Name = "menuitemEntidadesAniosLectivosYCursos"
        Me.menuitemEntidadesAniosLectivosYCursos.Size = New System.Drawing.Size(253, 22)
        Me.menuitemEntidadesAniosLectivosYCursos.Text = "Años Lectivos y Cursos"
        '
        'menuitemEntidadesAnioLectivoCursoInscripcion
        '
        Me.menuitemEntidadesAnioLectivoCursoInscripcion.Name = "menuitemEntidadesAnioLectivoCursoInscripcion"
        Me.menuitemEntidadesAnioLectivoCursoInscripcion.Size = New System.Drawing.Size(253, 22)
        Me.menuitemEntidadesAnioLectivoCursoInscripcion.Text = "Inscripción al Año Lectivo y Curso"
        '
        'menuitemEntidadesVerificarEmails
        '
        Me.menuitemEntidadesVerificarEmails.Name = "menuitemEntidadesVerificarEmails"
        Me.menuitemEntidadesVerificarEmails.Size = New System.Drawing.Size(253, 22)
        Me.menuitemEntidadesVerificarEmails.Text = "Verificar direcciones e-mail"
        '
        'buttonComprobantes
        '
        Me.buttonComprobantes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemComprobantesGenerarLoteFacturas, Me.menuitemComprobantesTransmitirAFIP, Me.menuitemComprobantesEnviarMail, Me.ToolStripMenuItem1, Me.menuitemComprobantesExportar, Me.ImportarArchivosDeToolStripMenuItem})
        Me.buttonComprobantes.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_COMPROBANTES_32
        Me.buttonComprobantes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonComprobantes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonComprobantes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonComprobantes.Name = "buttonComprobantes"
        Me.buttonComprobantes.Size = New System.Drawing.Size(142, 36)
        Me.buttonComprobantes.Text = "Comprobantes"
        '
        'menuitemComprobantesGenerarLoteFacturas
        '
        Me.menuitemComprobantesGenerarLoteFacturas.Name = "menuitemComprobantesGenerarLoteFacturas"
        Me.menuitemComprobantesGenerarLoteFacturas.Size = New System.Drawing.Size(215, 38)
        Me.menuitemComprobantesGenerarLoteFacturas.Text = "Generar lote de facturas"
        '
        'menuitemComprobantesTransmitirAFIP
        '
        Me.menuitemComprobantesTransmitirAFIP.Name = "menuitemComprobantesTransmitirAFIP"
        Me.menuitemComprobantesTransmitirAFIP.Size = New System.Drawing.Size(215, 38)
        Me.menuitemComprobantesTransmitirAFIP.Text = "Transmitir a AFIP"
        '
        'menuitemComprobantesEnviarMail
        '
        Me.menuitemComprobantesEnviarMail.Name = "menuitemComprobantesEnviarMail"
        Me.menuitemComprobantesEnviarMail.Size = New System.Drawing.Size(215, 38)
        Me.menuitemComprobantesEnviarMail.Text = "Enviar por e-mail"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(212, 6)
        '
        'menuitemComprobantesExportar
        '
        Me.menuitemComprobantesExportar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemComprobantesExportarPagomiscuentas, Me.menuitemComprobantesExportarSantanderDebitoDirecto, Me.menuitemComprobantesExportarSantanderRecaudacionPorCaja, Me.menuitemComprobantesExportarRapipago})
        Me.menuitemComprobantesExportar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_EXPORT_32
        Me.menuitemComprobantesExportar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.menuitemComprobantesExportar.Name = "menuitemComprobantesExportar"
        Me.menuitemComprobantesExportar.Size = New System.Drawing.Size(215, 38)
        Me.menuitemComprobantesExportar.Text = "Exportar archivos para..."
        '
        'menuitemComprobantesExportarPagomiscuentas
        '
        Me.menuitemComprobantesExportarPagomiscuentas.Name = "menuitemComprobantesExportarPagomiscuentas"
        Me.menuitemComprobantesExportarPagomiscuentas.Size = New System.Drawing.Size(289, 22)
        Me.menuitemComprobantesExportarPagomiscuentas.Text = "PagoMisCuentas"
        '
        'menuitemComprobantesExportarSantanderDebitoDirecto
        '
        Me.menuitemComprobantesExportarSantanderDebitoDirecto.Name = "menuitemComprobantesExportarSantanderDebitoDirecto"
        Me.menuitemComprobantesExportarSantanderDebitoDirecto.Size = New System.Drawing.Size(289, 22)
        Me.menuitemComprobantesExportarSantanderDebitoDirecto.Text = "Banco Santander - Débito Directo"
        '
        'menuitemComprobantesExportarSantanderRecaudacionPorCaja
        '
        Me.menuitemComprobantesExportarSantanderRecaudacionPorCaja.Name = "menuitemComprobantesExportarSantanderRecaudacionPorCaja"
        Me.menuitemComprobantesExportarSantanderRecaudacionPorCaja.Size = New System.Drawing.Size(289, 22)
        Me.menuitemComprobantesExportarSantanderRecaudacionPorCaja.Text = "Banco Santander - Recaudación Por Caja"
        '
        'menuitemComprobantesExportarRapipago
        '
        Me.menuitemComprobantesExportarRapipago.Name = "menuitemComprobantesExportarRapipago"
        Me.menuitemComprobantesExportarRapipago.Size = New System.Drawing.Size(289, 22)
        Me.menuitemComprobantesExportarRapipago.Text = "Rapipago"
        '
        'ImportarArchivosDeToolStripMenuItem
        '
        Me.ImportarArchivosDeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemComprobantesImportarPagomiscuentas, Me.menuitemComprobantesImportarSantanderDebitoDirecto, Me.menuitemComprobantesImportarSantanderRecaudacionPorCaja, Me.menuitemComprobantesImportarRapipago})
        Me.ImportarArchivosDeToolStripMenuItem.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_IMPORT_32
        Me.ImportarArchivosDeToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ImportarArchivosDeToolStripMenuItem.Name = "ImportarArchivosDeToolStripMenuItem"
        Me.ImportarArchivosDeToolStripMenuItem.Size = New System.Drawing.Size(215, 38)
        Me.ImportarArchivosDeToolStripMenuItem.Text = "Importar archivos de..."
        '
        'menuitemComprobantesImportarPagomiscuentas
        '
        Me.menuitemComprobantesImportarPagomiscuentas.Name = "menuitemComprobantesImportarPagomiscuentas"
        Me.menuitemComprobantesImportarPagomiscuentas.Size = New System.Drawing.Size(289, 22)
        Me.menuitemComprobantesImportarPagomiscuentas.Text = "PagoMisCuentas"
        '
        'menuitemComprobantesImportarSantanderDebitoDirecto
        '
        Me.menuitemComprobantesImportarSantanderDebitoDirecto.Name = "menuitemComprobantesImportarSantanderDebitoDirecto"
        Me.menuitemComprobantesImportarSantanderDebitoDirecto.Size = New System.Drawing.Size(289, 22)
        Me.menuitemComprobantesImportarSantanderDebitoDirecto.Text = "Banco Santander - Débito Directo"
        '
        'menuitemComprobantesImportarSantanderRecaudacionPorCaja
        '
        Me.menuitemComprobantesImportarSantanderRecaudacionPorCaja.Name = "menuitemComprobantesImportarSantanderRecaudacionPorCaja"
        Me.menuitemComprobantesImportarSantanderRecaudacionPorCaja.Size = New System.Drawing.Size(289, 22)
        Me.menuitemComprobantesImportarSantanderRecaudacionPorCaja.Text = "Banco Santander - Recaudación Por Caja"
        '
        'menuitemComprobantesImportarRapipago
        '
        Me.menuitemComprobantesImportarRapipago.Name = "menuitemComprobantesImportarRapipago"
        Me.menuitemComprobantesImportarRapipago.Size = New System.Drawing.Size(289, 22)
        Me.menuitemComprobantesImportarRapipago.Text = "Rapipago"
        '
        'buttonComunicaciones
        '
        Me.buttonComunicaciones.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemComunicacionesEnviarMail})
        Me.buttonComunicaciones.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_EMAIL_32
        Me.buttonComunicaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonComunicaciones.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonComunicaciones.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonComunicaciones.Name = "buttonComunicaciones"
        Me.buttonComunicaciones.Size = New System.Drawing.Size(142, 36)
        Me.buttonComunicaciones.Text = "Comunicaciones"
        '
        'menuitemComunicacionesEnviarMail
        '
        Me.menuitemComunicacionesEnviarMail.Name = "menuitemComunicacionesEnviarMail"
        Me.menuitemComunicacionesEnviarMail.Size = New System.Drawing.Size(164, 22)
        Me.menuitemComunicacionesEnviarMail.Text = "Enviar por e-mail"
        '
        'buttonReportes
        '
        Me.buttonReportes.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_REPORTES_32
        Me.buttonReportes.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonReportes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonReportes.Name = "buttonReportes"
        Me.buttonReportes.Size = New System.Drawing.Size(142, 36)
        Me.buttonReportes.Text = "Reportes"
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
    Friend WithEvents menuitemDebugAFIPWSHomologacionLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemComprobantesTransmitirAFIP As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemComprobantesEnviarMail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents buttonReportes As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuitemComprobantesExportar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemComprobantesExportarPagomiscuentas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemComprobantesExportarSantanderDebitoDirecto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemComprobantesExportarRapipago As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemAniosLectivosCursos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemComprobantesExportarSantanderRecaudacionPorCaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportarArchivosDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemComprobantesImportarSantanderDebitoDirecto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemComprobantesImportarSantanderRecaudacionPorCaja As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemComprobantesImportarRapipago As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemComprobantesImportarPagomiscuentas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemEntidadesAnioLectivoCursoInscripcion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents buttonComunicaciones As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents menuitemComunicacionesEnviarMail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemDebugAFIPWSProduccionLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemDebugAFIPWSSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuitemDebugAFIPWSHomologacionObtenerUltimoComprobante As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemDebugAFIPWSProduccionObtenerUltimoComprobante As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemDebugAFIPWSProduccionConsultarComprobante As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemDebugAFIPWSHomologacionConsultarComprobante As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemEntidadesVerificarEmails As System.Windows.Forms.ToolStripMenuItem
End Class
