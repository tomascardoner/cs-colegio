﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formEntidad
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
        Me.components = New System.ComponentModel.Container()
        Dim labelApellido As System.Windows.Forms.Label
        Dim labelIDEntidad As System.Windows.Forms.Label
        Dim labelNombre As System.Windows.Forms.Label
        Dim labelEsActivo As System.Windows.Forms.Label
        Dim labelFacturaDocumento As System.Windows.Forms.Label
        Dim labelTipo As System.Windows.Forms.Label
        Dim labelCategoriaIVA As System.Windows.Forms.Label
        Dim labelFechaNacimiento As System.Windows.Forms.Label
        Dim labelGenero As System.Windows.Forms.Label
        Dim labelDocumento As System.Windows.Forms.Label
        Dim labelComprobanteEnviarEmail As System.Windows.Forms.Label
        Dim labelDomicilioCalle3 As System.Windows.Forms.Label
        Dim labelDomicilioCalle2 As System.Windows.Forms.Label
        Dim labelDomicilioCalle1 As System.Windows.Forms.Label
        Dim labelDomicilioCodigoPostal As System.Windows.Forms.Label
        Dim labelDomicilioDepartamento As System.Windows.Forms.Label
        Dim labelDomicilioLocalidad As System.Windows.Forms.Label
        Dim labelDomicilioProvincia As System.Windows.Forms.Label
        Dim labelDomicilioNumero As System.Windows.Forms.Label
        Dim labelDomicilioPiso As System.Windows.Forms.Label
        Dim labelEmail1 As System.Windows.Forms.Label
        Dim labelEmail2 As System.Windows.Forms.Label
        Dim labelTelefono1 As System.Windows.Forms.Label
        Dim labelTelefono2 As System.Windows.Forms.Label
        Dim labelTelefono3 As System.Windows.Forms.Label
        Dim labelFacturaLeyenda As System.Windows.Forms.Label
        Dim labelVarios As System.Windows.Forms.Label
        Dim labelFacturaIndividual As System.Windows.Forms.Label
        Dim labelExcluyeCalculoInteres As System.Windows.Forms.Label
        Dim labelExcluyeFacturaHasta As System.Windows.Forms.Label
        Dim labelExcluyeFacturaDesde As System.Windows.Forms.Label
        Dim labelDescuento As System.Windows.Forms.Label
        Dim labelDebitoAutomatico_Tipo As System.Windows.Forms.Label
        Dim labelNotas As System.Windows.Forms.Label
        Dim labelModificacion As System.Windows.Forms.Label
        Dim labelCreacion As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formEntidad))
        Me.textboxApellido = New System.Windows.Forms.TextBox()
        Me.textboxIDEntidad = New System.Windows.Forms.TextBox()
        Me.textboxNombre = New System.Windows.Forms.TextBox()
        Me.pictureboxMain = New System.Windows.Forms.PictureBox()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.tooltipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.textboxFacturaDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.textboxDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.checkboxEsActivo = New System.Windows.Forms.CheckBox()
        Me.tabcontrolMain = New CSColegio.DesktopApplication.CS_Control_TabControl()
        Me.tabpageGeneral = New System.Windows.Forms.TabPage()
        Me.comboboxFacturaDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.labelTipoProveedor = New System.Windows.Forms.Label()
        Me.labelTipoFamiliar = New System.Windows.Forms.Label()
        Me.labelTipoAlumno = New System.Windows.Forms.Label()
        Me.labelTipoDocente = New System.Windows.Forms.Label()
        Me.labelTipoPersonalColegio = New System.Windows.Forms.Label()
        Me.checkboxTipoAlumno = New System.Windows.Forms.CheckBox()
        Me.checkboxTipoDocente = New System.Windows.Forms.CheckBox()
        Me.checkboxTipoFamiliar = New System.Windows.Forms.CheckBox()
        Me.checkboxTipoPersonalColegio = New System.Windows.Forms.CheckBox()
        Me.checkboxTipoProveedor = New System.Windows.Forms.CheckBox()
        Me.comboboxCategoriaIVA = New System.Windows.Forms.ComboBox()
        Me.datetimepickerFechaNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.comboboxGenero = New System.Windows.Forms.ComboBox()
        Me.comboboxDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.maskedtextboxDocumentoNumero = New System.Windows.Forms.MaskedTextBox()
        Me.maskedtextboxFacturaDocumentoNumero = New System.Windows.Forms.MaskedTextBox()
        Me.tabpageContacto = New System.Windows.Forms.TabPage()
        Me.comboboxComprobanteEnviarEmail = New System.Windows.Forms.ComboBox()
        Me.textboxDomicilioCalle3 = New System.Windows.Forms.TextBox()
        Me.textboxDomicilioCalle2 = New System.Windows.Forms.TextBox()
        Me.comboboxDomicilioLocalidad = New System.Windows.Forms.ComboBox()
        Me.comboboxDomicilioProvincia = New System.Windows.Forms.ComboBox()
        Me.textboxDomicilioCalle1 = New System.Windows.Forms.TextBox()
        Me.textboxDomicilioCodigoPostal = New System.Windows.Forms.TextBox()
        Me.textboxDomicilioDepartamento = New System.Windows.Forms.TextBox()
        Me.textboxDomicilioNumero = New System.Windows.Forms.TextBox()
        Me.textboxDomicilioPiso = New System.Windows.Forms.TextBox()
        Me.textboxEmail1 = New System.Windows.Forms.TextBox()
        Me.textboxEmail2 = New System.Windows.Forms.TextBox()
        Me.textboxTelefono1 = New System.Windows.Forms.TextBox()
        Me.textboxTelefono2 = New System.Windows.Forms.TextBox()
        Me.textboxTelefono3 = New System.Windows.Forms.TextBox()
        Me.tabpagePadresYFacturacion = New System.Windows.Forms.TabPage()
        Me.textboxFacturaLeyenda = New System.Windows.Forms.TextBox()
        Me.checkboxFacturaIndividual = New System.Windows.Forms.CheckBox()
        Me.checkboxExcluyeCalculoInteres = New System.Windows.Forms.CheckBox()
        Me.panelEntidadTercero = New System.Windows.Forms.Panel()
        Me.buttonEntidadTerceroBorrar = New System.Windows.Forms.Button()
        Me.buttonEntidadTercero = New System.Windows.Forms.Button()
        Me.textboxEntidadTercero = New System.Windows.Forms.TextBox()
        Me.labelEntidadTercero = New System.Windows.Forms.Label()
        Me.datetimepickerExcluyeFacturaHasta = New System.Windows.Forms.DateTimePicker()
        Me.datetimepickerExcluyeFacturaDesde = New System.Windows.Forms.DateTimePicker()
        Me.comboboxDescuento = New System.Windows.Forms.ComboBox()
        Me.comboboxEmitirFacturaA = New System.Windows.Forms.ComboBox()
        Me.labelEmitirFacturaA = New System.Windows.Forms.Label()
        Me.labelEntidadMadre = New System.Windows.Forms.Label()
        Me.panelEntidadMadre = New System.Windows.Forms.Panel()
        Me.buttonEntidadMadreBorrar = New System.Windows.Forms.Button()
        Me.buttonEntidadMadre = New System.Windows.Forms.Button()
        Me.textboxEntidadMadre = New System.Windows.Forms.TextBox()
        Me.panelEntidadPadre = New System.Windows.Forms.Panel()
        Me.buttonEntidadPadreBorrar = New System.Windows.Forms.Button()
        Me.buttonEntidadPadre = New System.Windows.Forms.Button()
        Me.textboxEntidadPadre = New System.Windows.Forms.TextBox()
        Me.labelEntidadPadre = New System.Windows.Forms.Label()
        Me.tabpageDebitoAutomatico = New System.Windows.Forms.TabPage()
        Me.radiobuttonDebitoAutomatico_Tipo_Ninguno = New System.Windows.Forms.RadioButton()
        Me.radiobuttonDebitoAutomatico_Tipo_DebitoDirecto = New System.Windows.Forms.RadioButton()
        Me.radiobuttonDebitoAutomatico_Tipo_TarjetaCredito = New System.Windows.Forms.RadioButton()
        Me.maskedtextboxDebitoAutomatico_CBU = New System.Windows.Forms.MaskedTextBox()
        Me.tabpageCursosAsistidos = New System.Windows.Forms.TabPage()
        Me.datagridviewCursosAsistidos = New System.Windows.Forms.DataGridView()
        Me.columnAnioLectivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNivelNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnAnioNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnTurnoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnDivision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabpageHijos = New System.Windows.Forms.TabPage()
        Me.datagridviewHijos = New System.Windows.Forms.DataGridView()
        Me.columnHijosIDEntidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnHijosApellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnHijosNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabpageComprobantes = New System.Windows.Forms.TabPage()
        Me.datagridviewComprobantes = New System.Windows.Forms.DataGridView()
        Me.columnTipoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNumeroCompleto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabpageRelaciones = New System.Windows.Forms.TabPage()
        Me.datagridviewRelaciones = New System.Windows.Forms.DataGridView()
        Me.columnPadresIDEntidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPadresApellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPadresNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPadresRelacionTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabpageNotasAuditoria = New System.Windows.Forms.TabPage()
        Me.textboxNotas = New System.Windows.Forms.TextBox()
        Me.textboxUsuarioModificacion = New System.Windows.Forms.TextBox()
        Me.textboxUsuarioCreacion = New System.Windows.Forms.TextBox()
        Me.textboxFechaHoraModificacion = New System.Windows.Forms.TextBox()
        Me.textboxFechaHoraCreacion = New System.Windows.Forms.TextBox()
        Me.checkboxVerificarEmail1 = New System.Windows.Forms.CheckBox()
        Me.checkboxVerificarEmail2 = New System.Windows.Forms.CheckBox()
        labelApellido = New System.Windows.Forms.Label()
        labelIDEntidad = New System.Windows.Forms.Label()
        labelNombre = New System.Windows.Forms.Label()
        labelEsActivo = New System.Windows.Forms.Label()
        labelFacturaDocumento = New System.Windows.Forms.Label()
        labelTipo = New System.Windows.Forms.Label()
        labelCategoriaIVA = New System.Windows.Forms.Label()
        labelFechaNacimiento = New System.Windows.Forms.Label()
        labelGenero = New System.Windows.Forms.Label()
        labelDocumento = New System.Windows.Forms.Label()
        labelComprobanteEnviarEmail = New System.Windows.Forms.Label()
        labelDomicilioCalle3 = New System.Windows.Forms.Label()
        labelDomicilioCalle2 = New System.Windows.Forms.Label()
        labelDomicilioCalle1 = New System.Windows.Forms.Label()
        labelDomicilioCodigoPostal = New System.Windows.Forms.Label()
        labelDomicilioDepartamento = New System.Windows.Forms.Label()
        labelDomicilioLocalidad = New System.Windows.Forms.Label()
        labelDomicilioProvincia = New System.Windows.Forms.Label()
        labelDomicilioNumero = New System.Windows.Forms.Label()
        labelDomicilioPiso = New System.Windows.Forms.Label()
        labelEmail1 = New System.Windows.Forms.Label()
        labelEmail2 = New System.Windows.Forms.Label()
        labelTelefono1 = New System.Windows.Forms.Label()
        labelTelefono2 = New System.Windows.Forms.Label()
        labelTelefono3 = New System.Windows.Forms.Label()
        labelFacturaLeyenda = New System.Windows.Forms.Label()
        labelVarios = New System.Windows.Forms.Label()
        labelFacturaIndividual = New System.Windows.Forms.Label()
        labelExcluyeCalculoInteres = New System.Windows.Forms.Label()
        labelExcluyeFacturaHasta = New System.Windows.Forms.Label()
        labelExcluyeFacturaDesde = New System.Windows.Forms.Label()
        labelDescuento = New System.Windows.Forms.Label()
        Me.labelDebitoAutomatico_CBU = New System.Windows.Forms.Label()
        labelDebitoAutomatico_Tipo = New System.Windows.Forms.Label()
        labelNotas = New System.Windows.Forms.Label()
        labelModificacion = New System.Windows.Forms.Label()
        labelCreacion = New System.Windows.Forms.Label()
        CType(Me.pictureboxMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolstripMain.SuspendLayout()
        Me.tabcontrolMain.SuspendLayout()
        Me.tabpageGeneral.SuspendLayout()
        Me.tabpageContacto.SuspendLayout()
        Me.tabpagePadresYFacturacion.SuspendLayout()
        Me.panelEntidadTercero.SuspendLayout()
        Me.panelEntidadMadre.SuspendLayout()
        Me.panelEntidadPadre.SuspendLayout()
        Me.tabpageDebitoAutomatico.SuspendLayout()
        Me.tabpageCursosAsistidos.SuspendLayout()
        CType(Me.datagridviewCursosAsistidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpageHijos.SuspendLayout()
        CType(Me.datagridviewHijos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpageComprobantes.SuspendLayout()
        CType(Me.datagridviewComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpageRelaciones.SuspendLayout()
        CType(Me.datagridviewRelaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpageNotasAuditoria.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelApellido
        '
        labelApellido.AutoSize = True
        labelApellido.Location = New System.Drawing.Point(97, 98)
        labelApellido.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelApellido.Name = "labelApellido"
        labelApellido.Size = New System.Drawing.Size(69, 17)
        labelApellido.TabIndex = 3
        labelApellido.Text = "Apellidos:"
        '
        'labelIDEntidad
        '
        labelIDEntidad.AutoSize = True
        labelIDEntidad.Location = New System.Drawing.Point(97, 64)
        labelIDEntidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelIDEntidad.Name = "labelIDEntidad"
        labelIDEntidad.Size = New System.Drawing.Size(100, 17)
        labelIDEntidad.TabIndex = 1
        labelIDEntidad.Text = "N° de Entidad:"
        '
        'labelNombre
        '
        labelNombre.AutoSize = True
        labelNombre.Location = New System.Drawing.Point(97, 130)
        labelNombre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelNombre.Name = "labelNombre"
        labelNombre.Size = New System.Drawing.Size(69, 17)
        labelNombre.TabIndex = 5
        labelNombre.Text = "Nombres:"
        '
        'labelEsActivo
        '
        labelEsActivo.AutoSize = True
        labelEsActivo.Location = New System.Drawing.Point(364, 64)
        labelEsActivo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelEsActivo.Name = "labelEsActivo"
        labelEsActivo.Size = New System.Drawing.Size(50, 17)
        labelEsActivo.TabIndex = 94
        labelEsActivo.Text = "Activo:"
        '
        'labelFacturaDocumento
        '
        labelFacturaDocumento.AutoSize = True
        labelFacturaDocumento.Location = New System.Drawing.Point(8, 217)
        labelFacturaDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelFacturaDocumento.Name = "labelFacturaDocumento"
        labelFacturaDocumento.Size = New System.Drawing.Size(174, 17)
        labelFacturaDocumento.TabIndex = 21
        labelFacturaDocumento.Text = "Documento para Facturar:"
        Me.tooltipMain.SetToolTip(labelFacturaDocumento, "Ingrese el Número de Documento sin utilizar puntos.")
        '
        'labelTipo
        '
        labelTipo.AutoSize = True
        labelTipo.Location = New System.Drawing.Point(8, 12)
        labelTipo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelTipo.Name = "labelTipo"
        labelTipo.Size = New System.Drawing.Size(40, 17)
        labelTipo.TabIndex = 0
        labelTipo.Text = "Tipo:"
        '
        'labelCategoriaIVA
        '
        labelCategoriaIVA.AutoSize = True
        labelCategoriaIVA.Location = New System.Drawing.Point(8, 183)
        labelCategoriaIVA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelCategoriaIVA.Name = "labelCategoriaIVA"
        labelCategoriaIVA.Size = New System.Drawing.Size(118, 17)
        labelCategoriaIVA.TabIndex = 19
        labelCategoriaIVA.Text = "Categoría de IVA:"
        '
        'labelFechaNacimiento
        '
        labelFechaNacimiento.AutoSize = True
        labelFechaNacimiento.Location = New System.Drawing.Point(8, 98)
        labelFechaNacimiento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelFechaNacimiento.Name = "labelFechaNacimiento"
        labelFechaNacimiento.Size = New System.Drawing.Size(145, 17)
        labelFechaNacimiento.TabIndex = 13
        labelFechaNacimiento.Text = "Fecha de Nacimiento:"
        '
        'labelGenero
        '
        labelGenero.AutoSize = True
        labelGenero.Location = New System.Drawing.Point(8, 65)
        labelGenero.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelGenero.Name = "labelGenero"
        labelGenero.Size = New System.Drawing.Size(60, 17)
        labelGenero.TabIndex = 11
        labelGenero.Text = "Género:"
        '
        'labelDocumento
        '
        labelDocumento.AutoSize = True
        labelDocumento.Location = New System.Drawing.Point(8, 130)
        labelDocumento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelDocumento.Name = "labelDocumento"
        labelDocumento.Size = New System.Drawing.Size(84, 17)
        labelDocumento.TabIndex = 15
        labelDocumento.Text = "Documento:"
        Me.tooltipMain.SetToolTip(labelDocumento, "Ingrese el Número de Documento sin utilizar puntos.")
        '
        'labelComprobanteEnviarEmail
        '
        labelComprobanteEnviarEmail.AutoSize = True
        labelComprobanteEnviarEmail.Location = New System.Drawing.Point(8, 121)
        labelComprobanteEnviarEmail.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelComprobanteEnviarEmail.Name = "labelComprobanteEnviarEmail"
        labelComprobanteEnviarEmail.Size = New System.Drawing.Size(158, 17)
        labelComprobanteEnviarEmail.TabIndex = 10
        labelComprobanteEnviarEmail.Text = "Enviar comprobantes a:"
        '
        'labelDomicilioCalle3
        '
        labelDomicilioCalle3.AutoSize = True
        labelDomicilioCalle3.Location = New System.Drawing.Point(355, 229)
        labelDomicilioCalle3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelDomicilioCalle3.Name = "labelDomicilioCalle3"
        labelDomicilioCalle3.Size = New System.Drawing.Size(55, 17)
        labelDomicilioCalle3.TabIndex = 22
        labelDomicilioCalle3.Text = "Calle 3:"
        '
        'labelDomicilioCalle2
        '
        labelDomicilioCalle2.AutoSize = True
        labelDomicilioCalle2.Location = New System.Drawing.Point(8, 229)
        labelDomicilioCalle2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelDomicilioCalle2.Name = "labelDomicilioCalle2"
        labelDomicilioCalle2.Size = New System.Drawing.Size(55, 17)
        labelDomicilioCalle2.TabIndex = 20
        labelDomicilioCalle2.Text = "Calle 2:"
        '
        'labelDomicilioCalle1
        '
        labelDomicilioCalle1.AutoSize = True
        labelDomicilioCalle1.Location = New System.Drawing.Point(8, 165)
        labelDomicilioCalle1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelDomicilioCalle1.Name = "labelDomicilioCalle1"
        labelDomicilioCalle1.Size = New System.Drawing.Size(43, 17)
        labelDomicilioCalle1.TabIndex = 12
        labelDomicilioCalle1.Text = "Calle:"
        '
        'labelDomicilioCodigoPostal
        '
        labelDomicilioCodigoPostal.AutoSize = True
        labelDomicilioCodigoPostal.Location = New System.Drawing.Point(512, 294)
        labelDomicilioCodigoPostal.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelDomicilioCodigoPostal.Name = "labelDomicilioCodigoPostal"
        labelDomicilioCodigoPostal.Size = New System.Drawing.Size(77, 17)
        labelDomicilioCodigoPostal.TabIndex = 28
        labelDomicilioCodigoPostal.Text = "Cód. Post.:"
        '
        'labelDomicilioDepartamento
        '
        labelDomicilioDepartamento.AutoSize = True
        labelDomicilioDepartamento.Location = New System.Drawing.Point(293, 197)
        labelDomicilioDepartamento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelDomicilioDepartamento.Name = "labelDomicilioDepartamento"
        labelDomicilioDepartamento.Size = New System.Drawing.Size(67, 17)
        labelDomicilioDepartamento.TabIndex = 18
        labelDomicilioDepartamento.Text = "Dto/Ofic.:"
        '
        'labelDomicilioLocalidad
        '
        labelDomicilioLocalidad.AutoSize = True
        labelDomicilioLocalidad.Location = New System.Drawing.Point(8, 294)
        labelDomicilioLocalidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelDomicilioLocalidad.Name = "labelDomicilioLocalidad"
        labelDomicilioLocalidad.Size = New System.Drawing.Size(73, 17)
        labelDomicilioLocalidad.TabIndex = 26
        labelDomicilioLocalidad.Text = "Localidad:"
        '
        'labelDomicilioProvincia
        '
        labelDomicilioProvincia.AutoSize = True
        labelDomicilioProvincia.Location = New System.Drawing.Point(8, 261)
        labelDomicilioProvincia.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelDomicilioProvincia.Name = "labelDomicilioProvincia"
        labelDomicilioProvincia.Size = New System.Drawing.Size(70, 17)
        labelDomicilioProvincia.TabIndex = 24
        labelDomicilioProvincia.Text = "Provincia:"
        '
        'labelDomicilioNumero
        '
        labelDomicilioNumero.AutoSize = True
        labelDomicilioNumero.Location = New System.Drawing.Point(8, 197)
        labelDomicilioNumero.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelDomicilioNumero.Name = "labelDomicilioNumero"
        labelDomicilioNumero.Size = New System.Drawing.Size(62, 17)
        labelDomicilioNumero.TabIndex = 14
        labelDomicilioNumero.Text = "Número:"
        '
        'labelDomicilioPiso
        '
        labelDomicilioPiso.AutoSize = True
        labelDomicilioPiso.Location = New System.Drawing.Point(171, 197)
        labelDomicilioPiso.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelDomicilioPiso.Name = "labelDomicilioPiso"
        labelDomicilioPiso.Size = New System.Drawing.Size(39, 17)
        labelDomicilioPiso.TabIndex = 16
        labelDomicilioPiso.Text = "Piso:"
        '
        'labelEmail1
        '
        labelEmail1.AutoSize = True
        labelEmail1.Location = New System.Drawing.Point(8, 89)
        labelEmail1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelEmail1.Name = "labelEmail1"
        labelEmail1.Size = New System.Drawing.Size(63, 17)
        labelEmail1.TabIndex = 6
        labelEmail1.Text = "E-mail 1:"
        '
        'labelEmail2
        '
        labelEmail2.AutoSize = True
        labelEmail2.Location = New System.Drawing.Point(355, 89)
        labelEmail2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelEmail2.Name = "labelEmail2"
        labelEmail2.Size = New System.Drawing.Size(63, 17)
        labelEmail2.TabIndex = 8
        labelEmail2.Text = "E-mail 2:"
        '
        'labelTelefono1
        '
        labelTelefono1.AutoSize = True
        labelTelefono1.Location = New System.Drawing.Point(8, 12)
        labelTelefono1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelTelefono1.Name = "labelTelefono1"
        labelTelefono1.Size = New System.Drawing.Size(76, 17)
        labelTelefono1.TabIndex = 0
        labelTelefono1.Text = "Teléfono1:"
        '
        'labelTelefono2
        '
        labelTelefono2.AutoSize = True
        labelTelefono2.Location = New System.Drawing.Point(355, 12)
        labelTelefono2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelTelefono2.Name = "labelTelefono2"
        labelTelefono2.Size = New System.Drawing.Size(76, 17)
        labelTelefono2.TabIndex = 2
        labelTelefono2.Text = "Teléfono2:"
        '
        'labelTelefono3
        '
        labelTelefono3.AutoSize = True
        labelTelefono3.Location = New System.Drawing.Point(8, 44)
        labelTelefono3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelTelefono3.Name = "labelTelefono3"
        labelTelefono3.Size = New System.Drawing.Size(76, 17)
        labelTelefono3.TabIndex = 4
        labelTelefono3.Text = "Teléfono3:"
        '
        'labelFacturaLeyenda
        '
        labelFacturaLeyenda.AutoSize = True
        labelFacturaLeyenda.Location = New System.Drawing.Point(8, 244)
        labelFacturaLeyenda.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelFacturaLeyenda.Name = "labelFacturaLeyenda"
        labelFacturaLeyenda.Size = New System.Drawing.Size(119, 17)
        labelFacturaLeyenda.TabIndex = 18
        labelFacturaLeyenda.Text = "Leyenda Factura:"
        '
        'labelVarios
        '
        labelVarios.AutoSize = True
        labelVarios.Location = New System.Drawing.Point(8, 182)
        labelVarios.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelVarios.Name = "labelVarios"
        labelVarios.Size = New System.Drawing.Size(52, 17)
        labelVarios.TabIndex = 9
        labelVarios.Text = "Varios:"
        '
        'labelFacturaIndividual
        '
        labelFacturaIndividual.AutoSize = True
        labelFacturaIndividual.Location = New System.Drawing.Point(171, 182)
        labelFacturaIndividual.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelFacturaIndividual.Name = "labelFacturaIndividual"
        labelFacturaIndividual.Size = New System.Drawing.Size(154, 17)
        labelFacturaIndividual.TabIndex = 11
        labelFacturaIndividual.Text = "Emitir factura individual"
        '
        'labelExcluyeCalculoInteres
        '
        labelExcluyeCalculoInteres.AutoSize = True
        labelExcluyeCalculoInteres.Location = New System.Drawing.Point(407, 182)
        labelExcluyeCalculoInteres.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelExcluyeCalculoInteres.Name = "labelExcluyeCalculoInteres"
        labelExcluyeCalculoInteres.Size = New System.Drawing.Size(202, 17)
        labelExcluyeCalculoInteres.TabIndex = 13
        labelExcluyeCalculoInteres.Text = "Excluir del cálculo de intereses"
        '
        'labelExcluyeFacturaHasta
        '
        labelExcluyeFacturaHasta.AutoSize = True
        labelExcluyeFacturaHasta.Location = New System.Drawing.Point(348, 212)
        labelExcluyeFacturaHasta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelExcluyeFacturaHasta.Name = "labelExcluyeFacturaHasta"
        labelExcluyeFacturaHasta.Size = New System.Drawing.Size(47, 17)
        labelExcluyeFacturaHasta.TabIndex = 16
        labelExcluyeFacturaHasta.Text = "hasta:"
        '
        'labelExcluyeFacturaDesde
        '
        labelExcluyeFacturaDesde.AutoSize = True
        labelExcluyeFacturaDesde.Location = New System.Drawing.Point(8, 214)
        labelExcluyeFacturaDesde.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelExcluyeFacturaDesde.Name = "labelExcluyeFacturaDesde"
        labelExcluyeFacturaDesde.Size = New System.Drawing.Size(126, 17)
        labelExcluyeFacturaDesde.TabIndex = 14
        labelExcluyeFacturaDesde.Text = "No facturar desde:"
        '
        'labelDescuento
        '
        labelDescuento.AutoSize = True
        labelDescuento.Location = New System.Drawing.Point(8, 150)
        labelDescuento.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelDescuento.Name = "labelDescuento"
        labelDescuento.Size = New System.Drawing.Size(80, 17)
        labelDescuento.TabIndex = 7
        labelDescuento.Text = "Descuento:"
        '
        'labelDebitoAutomatico_CBU
        '
        labelDebitoAutomatico_CBU.AutoSize = True
        labelDebitoAutomatico_CBU.Location = New System.Drawing.Point(8, 53)
        labelDebitoAutomatico_CBU.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelDebitoAutomatico_CBU.Name = "labelDebitoAutomatico_CBU"
        labelDebitoAutomatico_CBU.Size = New System.Drawing.Size(40, 17)
        labelDebitoAutomatico_CBU.TabIndex = 5
        labelDebitoAutomatico_CBU.Text = "CBU:"
        '
        'labelDebitoAutomatico_Tipo
        '
        labelDebitoAutomatico_Tipo.AutoSize = True
        labelDebitoAutomatico_Tipo.Location = New System.Drawing.Point(7, 12)
        labelDebitoAutomatico_Tipo.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelDebitoAutomatico_Tipo.Name = "labelDebitoAutomatico_Tipo"
        labelDebitoAutomatico_Tipo.Size = New System.Drawing.Size(40, 17)
        labelDebitoAutomatico_Tipo.TabIndex = 1
        labelDebitoAutomatico_Tipo.Text = "Tipo:"
        '
        'labelNotas
        '
        labelNotas.AutoSize = True
        labelNotas.Location = New System.Drawing.Point(8, 11)
        labelNotas.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelNotas.Name = "labelNotas"
        labelNotas.Size = New System.Drawing.Size(49, 17)
        labelNotas.TabIndex = 15
        labelNotas.Text = "Notas:"
        '
        'labelModificacion
        '
        labelModificacion.AutoSize = True
        labelModificacion.Location = New System.Drawing.Point(8, 241)
        labelModificacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelModificacion.Name = "labelModificacion"
        labelModificacion.Size = New System.Drawing.Size(133, 17)
        labelModificacion.TabIndex = 12
        labelModificacion.Text = "Ultima Modificación:"
        '
        'labelCreacion
        '
        labelCreacion.AutoSize = True
        labelCreacion.Location = New System.Drawing.Point(8, 214)
        labelCreacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        labelCreacion.Name = "labelCreacion"
        labelCreacion.Size = New System.Drawing.Size(68, 17)
        labelCreacion.TabIndex = 9
        labelCreacion.Text = "Creación:"
        '
        'textboxApellido
        '
        Me.textboxApellido.Location = New System.Drawing.Point(207, 95)
        Me.textboxApellido.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxApellido.MaxLength = 100
        Me.textboxApellido.Name = "textboxApellido"
        Me.textboxApellido.Size = New System.Drawing.Size(493, 22)
        Me.textboxApellido.TabIndex = 4
        '
        'textboxIDEntidad
        '
        Me.textboxIDEntidad.Location = New System.Drawing.Point(207, 60)
        Me.textboxIDEntidad.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxIDEntidad.MaxLength = 10
        Me.textboxIDEntidad.Name = "textboxIDEntidad"
        Me.textboxIDEntidad.ReadOnly = True
        Me.textboxIDEntidad.Size = New System.Drawing.Size(95, 22)
        Me.textboxIDEntidad.TabIndex = 2
        Me.textboxIDEntidad.TabStop = False
        Me.textboxIDEntidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'textboxNombre
        '
        Me.textboxNombre.Location = New System.Drawing.Point(207, 127)
        Me.textboxNombre.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxNombre.MaxLength = 50
        Me.textboxNombre.Name = "textboxNombre"
        Me.textboxNombre.Size = New System.Drawing.Size(317, 22)
        Me.textboxNombre.TabIndex = 6
        '
        'pictureboxMain
        '
        Me.pictureboxMain.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ENTIDAD_48
        Me.pictureboxMain.Location = New System.Drawing.Point(16, 60)
        Me.pictureboxMain.Margin = New System.Windows.Forms.Padding(4)
        Me.pictureboxMain.Name = "pictureboxMain"
        Me.pictureboxMain.Size = New System.Drawing.Size(48, 48)
        Me.pictureboxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureboxMain.TabIndex = 93
        Me.pictureboxMain.TabStop = False
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(719, 39)
        Me.toolstripMain.TabIndex = 0
        '
        'buttonCerrar
        '
        Me.buttonCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonCerrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_32
        Me.buttonCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCerrar.Name = "buttonCerrar"
        Me.buttonCerrar.Size = New System.Drawing.Size(85, 36)
        Me.buttonCerrar.Text = "Cerrar"
        '
        'buttonEditar
        '
        Me.buttonEditar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonEditar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_EDIT_32
        Me.buttonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEditar.Name = "buttonEditar"
        Me.buttonEditar.Size = New System.Drawing.Size(84, 36)
        Me.buttonEditar.Text = "Editar"
        '
        'buttonCancelar
        '
        Me.buttonCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonCancelar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CANCEL_32
        Me.buttonCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCancelar.Name = "buttonCancelar"
        Me.buttonCancelar.Size = New System.Drawing.Size(102, 36)
        Me.buttonCancelar.Text = "Cancelar"
        '
        'buttonGuardar
        '
        Me.buttonGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonGuardar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_OK_32
        Me.buttonGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonGuardar.Name = "buttonGuardar"
        Me.buttonGuardar.Size = New System.Drawing.Size(98, 36)
        Me.buttonGuardar.Text = "Guardar"
        '
        'textboxFacturaDocumentoNumero
        '
        Me.textboxFacturaDocumentoNumero.Location = New System.Drawing.Point(333, 212)
        Me.textboxFacturaDocumentoNumero.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxFacturaDocumentoNumero.MaxLength = 11
        Me.textboxFacturaDocumentoNumero.Name = "textboxFacturaDocumentoNumero"
        Me.textboxFacturaDocumentoNumero.Size = New System.Drawing.Size(152, 22)
        Me.textboxFacturaDocumentoNumero.TabIndex = 23
        Me.tooltipMain.SetToolTip(Me.textboxFacturaDocumentoNumero, "Ingrese el Número de Documento sin utilizar puntos.")
        '
        'textboxDocumentoNumero
        '
        Me.textboxDocumentoNumero.Location = New System.Drawing.Point(333, 128)
        Me.textboxDocumentoNumero.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxDocumentoNumero.MaxLength = 11
        Me.textboxDocumentoNumero.Name = "textboxDocumentoNumero"
        Me.textboxDocumentoNumero.Size = New System.Drawing.Size(152, 22)
        Me.textboxDocumentoNumero.TabIndex = 17
        Me.tooltipMain.SetToolTip(Me.textboxDocumentoNumero, "Ingrese el Número de Documento sin utilizar puntos.")
        '
        'checkboxEsActivo
        '
        Me.checkboxEsActivo.AutoSize = True
        Me.checkboxEsActivo.Location = New System.Drawing.Point(425, 64)
        Me.checkboxEsActivo.Margin = New System.Windows.Forms.Padding(4)
        Me.checkboxEsActivo.Name = "checkboxEsActivo"
        Me.checkboxEsActivo.Size = New System.Drawing.Size(18, 17)
        Me.checkboxEsActivo.TabIndex = 95
        Me.checkboxEsActivo.UseVisualStyleBackColor = True
        '
        'tabcontrolMain
        '
        Me.tabcontrolMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabcontrolMain.Controls.Add(Me.tabpageGeneral)
        Me.tabcontrolMain.Controls.Add(Me.tabpageContacto)
        Me.tabcontrolMain.Controls.Add(Me.tabpagePadresYFacturacion)
        Me.tabcontrolMain.Controls.Add(Me.tabpageDebitoAutomatico)
        Me.tabcontrolMain.Controls.Add(Me.tabpageCursosAsistidos)
        Me.tabcontrolMain.Controls.Add(Me.tabpageHijos)
        Me.tabcontrolMain.Controls.Add(Me.tabpageComprobantes)
        Me.tabcontrolMain.Controls.Add(Me.tabpageRelaciones)
        Me.tabcontrolMain.Controls.Add(Me.tabpageNotasAuditoria)
        Me.tabcontrolMain.Location = New System.Drawing.Point(16, 170)
        Me.tabcontrolMain.Margin = New System.Windows.Forms.Padding(4)
        Me.tabcontrolMain.Name = "tabcontrolMain"
        Me.tabcontrolMain.SelectedIndex = 0
        Me.tabcontrolMain.Size = New System.Drawing.Size(685, 361)
        Me.tabcontrolMain.TabIndex = 0
        '
        'tabpageGeneral
        '
        Me.tabpageGeneral.Controls.Add(Me.comboboxFacturaDocumentoTipo)
        Me.tabpageGeneral.Controls.Add(Me.textboxFacturaDocumentoNumero)
        Me.tabpageGeneral.Controls.Add(labelFacturaDocumento)
        Me.tabpageGeneral.Controls.Add(Me.labelTipoProveedor)
        Me.tabpageGeneral.Controls.Add(Me.labelTipoFamiliar)
        Me.tabpageGeneral.Controls.Add(Me.labelTipoAlumno)
        Me.tabpageGeneral.Controls.Add(Me.labelTipoDocente)
        Me.tabpageGeneral.Controls.Add(Me.labelTipoPersonalColegio)
        Me.tabpageGeneral.Controls.Add(labelTipo)
        Me.tabpageGeneral.Controls.Add(Me.checkboxTipoAlumno)
        Me.tabpageGeneral.Controls.Add(Me.checkboxTipoDocente)
        Me.tabpageGeneral.Controls.Add(Me.checkboxTipoFamiliar)
        Me.tabpageGeneral.Controls.Add(Me.checkboxTipoPersonalColegio)
        Me.tabpageGeneral.Controls.Add(Me.checkboxTipoProveedor)
        Me.tabpageGeneral.Controls.Add(Me.comboboxCategoriaIVA)
        Me.tabpageGeneral.Controls.Add(labelCategoriaIVA)
        Me.tabpageGeneral.Controls.Add(labelFechaNacimiento)
        Me.tabpageGeneral.Controls.Add(Me.datetimepickerFechaNacimiento)
        Me.tabpageGeneral.Controls.Add(Me.comboboxGenero)
        Me.tabpageGeneral.Controls.Add(labelGenero)
        Me.tabpageGeneral.Controls.Add(Me.comboboxDocumentoTipo)
        Me.tabpageGeneral.Controls.Add(Me.textboxDocumentoNumero)
        Me.tabpageGeneral.Controls.Add(labelDocumento)
        Me.tabpageGeneral.Controls.Add(Me.maskedtextboxDocumentoNumero)
        Me.tabpageGeneral.Controls.Add(Me.maskedtextboxFacturaDocumentoNumero)
        Me.tabpageGeneral.Location = New System.Drawing.Point(4, 28)
        Me.tabpageGeneral.Margin = New System.Windows.Forms.Padding(4)
        Me.tabpageGeneral.Name = "tabpageGeneral"
        Me.tabpageGeneral.Padding = New System.Windows.Forms.Padding(4)
        Me.tabpageGeneral.Size = New System.Drawing.Size(677, 329)
        Me.tabpageGeneral.TabIndex = 0
        Me.tabpageGeneral.Text = "General"
        Me.tabpageGeneral.UseVisualStyleBackColor = True
        '
        'comboboxFacturaDocumentoTipo
        '
        Me.comboboxFacturaDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxFacturaDocumentoTipo.FormattingEnabled = True
        Me.comboboxFacturaDocumentoTipo.Location = New System.Drawing.Point(189, 212)
        Me.comboboxFacturaDocumentoTipo.Margin = New System.Windows.Forms.Padding(4)
        Me.comboboxFacturaDocumentoTipo.Name = "comboboxFacturaDocumentoTipo"
        Me.comboboxFacturaDocumentoTipo.Size = New System.Drawing.Size(135, 24)
        Me.comboboxFacturaDocumentoTipo.TabIndex = 22
        '
        'labelTipoProveedor
        '
        Me.labelTipoProveedor.AutoSize = True
        Me.labelTipoProveedor.Location = New System.Drawing.Point(580, 11)
        Me.labelTipoProveedor.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelTipoProveedor.Name = "labelTipoProveedor"
        Me.labelTipoProveedor.Size = New System.Drawing.Size(74, 17)
        Me.labelTipoProveedor.TabIndex = 10
        Me.labelTipoProveedor.Text = "Proveedor"
        '
        'labelTipoFamiliar
        '
        Me.labelTipoFamiliar.AutoSize = True
        Me.labelTipoFamiliar.Location = New System.Drawing.Point(487, 11)
        Me.labelTipoFamiliar.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelTipoFamiliar.Name = "labelTipoFamiliar"
        Me.labelTipoFamiliar.Size = New System.Drawing.Size(57, 17)
        Me.labelTipoFamiliar.TabIndex = 8
        Me.labelTipoFamiliar.Text = "Familiar"
        '
        'labelTipoAlumno
        '
        Me.labelTipoAlumno.AutoSize = True
        Me.labelTipoAlumno.Location = New System.Drawing.Point(393, 11)
        Me.labelTipoAlumno.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelTipoAlumno.Name = "labelTipoAlumno"
        Me.labelTipoAlumno.Size = New System.Drawing.Size(55, 17)
        Me.labelTipoAlumno.TabIndex = 6
        Me.labelTipoAlumno.Text = "Alumno"
        '
        'labelTipoDocente
        '
        Me.labelTipoDocente.AutoSize = True
        Me.labelTipoDocente.Location = New System.Drawing.Point(292, 11)
        Me.labelTipoDocente.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelTipoDocente.Name = "labelTipoDocente"
        Me.labelTipoDocente.Size = New System.Drawing.Size(61, 17)
        Me.labelTipoDocente.TabIndex = 4
        Me.labelTipoDocente.Text = "Docente"
        '
        'labelTipoPersonalColegio
        '
        Me.labelTipoPersonalColegio.AutoSize = True
        Me.labelTipoPersonalColegio.Location = New System.Drawing.Point(140, 11)
        Me.labelTipoPersonalColegio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelTipoPersonalColegio.Name = "labelTipoPersonalColegio"
        Me.labelTipoPersonalColegio.Size = New System.Drawing.Size(115, 17)
        Me.labelTipoPersonalColegio.TabIndex = 2
        Me.labelTipoPersonalColegio.Text = "Personal Colegio"
        '
        'checkboxTipoAlumno
        '
        Me.checkboxTipoAlumno.AutoSize = True
        Me.checkboxTipoAlumno.Location = New System.Drawing.Point(373, 11)
        Me.checkboxTipoAlumno.Margin = New System.Windows.Forms.Padding(4)
        Me.checkboxTipoAlumno.Name = "checkboxTipoAlumno"
        Me.checkboxTipoAlumno.Size = New System.Drawing.Size(18, 17)
        Me.checkboxTipoAlumno.TabIndex = 5
        Me.checkboxTipoAlumno.UseVisualStyleBackColor = True
        '
        'checkboxTipoDocente
        '
        Me.checkboxTipoDocente.AutoSize = True
        Me.checkboxTipoDocente.Location = New System.Drawing.Point(272, 11)
        Me.checkboxTipoDocente.Margin = New System.Windows.Forms.Padding(4)
        Me.checkboxTipoDocente.Name = "checkboxTipoDocente"
        Me.checkboxTipoDocente.Size = New System.Drawing.Size(18, 17)
        Me.checkboxTipoDocente.TabIndex = 3
        Me.checkboxTipoDocente.UseVisualStyleBackColor = True
        '
        'checkboxTipoFamiliar
        '
        Me.checkboxTipoFamiliar.AutoSize = True
        Me.checkboxTipoFamiliar.Location = New System.Drawing.Point(467, 11)
        Me.checkboxTipoFamiliar.Margin = New System.Windows.Forms.Padding(4)
        Me.checkboxTipoFamiliar.Name = "checkboxTipoFamiliar"
        Me.checkboxTipoFamiliar.Size = New System.Drawing.Size(18, 17)
        Me.checkboxTipoFamiliar.TabIndex = 7
        Me.checkboxTipoFamiliar.UseVisualStyleBackColor = True
        '
        'checkboxTipoPersonalColegio
        '
        Me.checkboxTipoPersonalColegio.AutoSize = True
        Me.checkboxTipoPersonalColegio.Location = New System.Drawing.Point(120, 11)
        Me.checkboxTipoPersonalColegio.Margin = New System.Windows.Forms.Padding(4)
        Me.checkboxTipoPersonalColegio.Name = "checkboxTipoPersonalColegio"
        Me.checkboxTipoPersonalColegio.Size = New System.Drawing.Size(18, 17)
        Me.checkboxTipoPersonalColegio.TabIndex = 1
        Me.checkboxTipoPersonalColegio.UseVisualStyleBackColor = True
        '
        'checkboxTipoProveedor
        '
        Me.checkboxTipoProveedor.AutoSize = True
        Me.checkboxTipoProveedor.Location = New System.Drawing.Point(560, 11)
        Me.checkboxTipoProveedor.Margin = New System.Windows.Forms.Padding(4)
        Me.checkboxTipoProveedor.Name = "checkboxTipoProveedor"
        Me.checkboxTipoProveedor.Size = New System.Drawing.Size(18, 17)
        Me.checkboxTipoProveedor.TabIndex = 9
        Me.checkboxTipoProveedor.UseVisualStyleBackColor = True
        '
        'comboboxCategoriaIVA
        '
        Me.comboboxCategoriaIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCategoriaIVA.FormattingEnabled = True
        Me.comboboxCategoriaIVA.Location = New System.Drawing.Point(189, 180)
        Me.comboboxCategoriaIVA.Margin = New System.Windows.Forms.Padding(4)
        Me.comboboxCategoriaIVA.Name = "comboboxCategoriaIVA"
        Me.comboboxCategoriaIVA.Size = New System.Drawing.Size(265, 24)
        Me.comboboxCategoriaIVA.TabIndex = 20
        '
        'datetimepickerFechaNacimiento
        '
        Me.datetimepickerFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerFechaNacimiento.Location = New System.Drawing.Point(189, 95)
        Me.datetimepickerFechaNacimiento.Margin = New System.Windows.Forms.Padding(4)
        Me.datetimepickerFechaNacimiento.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerFechaNacimiento.MinDate = New Date(1910, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerFechaNacimiento.Name = "datetimepickerFechaNacimiento"
        Me.datetimepickerFechaNacimiento.ShowCheckBox = True
        Me.datetimepickerFechaNacimiento.Size = New System.Drawing.Size(196, 22)
        Me.datetimepickerFechaNacimiento.TabIndex = 14
        '
        'comboboxGenero
        '
        Me.comboboxGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxGenero.FormattingEnabled = True
        Me.comboboxGenero.Location = New System.Drawing.Point(189, 62)
        Me.comboboxGenero.Margin = New System.Windows.Forms.Padding(4)
        Me.comboboxGenero.Name = "comboboxGenero"
        Me.comboboxGenero.Size = New System.Drawing.Size(135, 24)
        Me.comboboxGenero.TabIndex = 12
        '
        'comboboxDocumentoTipo
        '
        Me.comboboxDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxDocumentoTipo.FormattingEnabled = True
        Me.comboboxDocumentoTipo.Location = New System.Drawing.Point(189, 127)
        Me.comboboxDocumentoTipo.Margin = New System.Windows.Forms.Padding(4)
        Me.comboboxDocumentoTipo.Name = "comboboxDocumentoTipo"
        Me.comboboxDocumentoTipo.Size = New System.Drawing.Size(135, 24)
        Me.comboboxDocumentoTipo.TabIndex = 16
        '
        'maskedtextboxDocumentoNumero
        '
        Me.maskedtextboxDocumentoNumero.AllowPromptAsInput = False
        Me.maskedtextboxDocumentoNumero.AsciiOnly = True
        Me.maskedtextboxDocumentoNumero.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.maskedtextboxDocumentoNumero.HidePromptOnLeave = True
        Me.maskedtextboxDocumentoNumero.Location = New System.Drawing.Point(333, 128)
        Me.maskedtextboxDocumentoNumero.Margin = New System.Windows.Forms.Padding(4)
        Me.maskedtextboxDocumentoNumero.Mask = "00-00000000-0"
        Me.maskedtextboxDocumentoNumero.Name = "maskedtextboxDocumentoNumero"
        Me.maskedtextboxDocumentoNumero.Size = New System.Drawing.Size(152, 22)
        Me.maskedtextboxDocumentoNumero.TabIndex = 18
        Me.maskedtextboxDocumentoNumero.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'maskedtextboxFacturaDocumentoNumero
        '
        Me.maskedtextboxFacturaDocumentoNumero.AllowPromptAsInput = False
        Me.maskedtextboxFacturaDocumentoNumero.AsciiOnly = True
        Me.maskedtextboxFacturaDocumentoNumero.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.maskedtextboxFacturaDocumentoNumero.HidePromptOnLeave = True
        Me.maskedtextboxFacturaDocumentoNumero.Location = New System.Drawing.Point(333, 212)
        Me.maskedtextboxFacturaDocumentoNumero.Margin = New System.Windows.Forms.Padding(4)
        Me.maskedtextboxFacturaDocumentoNumero.Mask = "00-00000000-0"
        Me.maskedtextboxFacturaDocumentoNumero.Name = "maskedtextboxFacturaDocumentoNumero"
        Me.maskedtextboxFacturaDocumentoNumero.Size = New System.Drawing.Size(152, 22)
        Me.maskedtextboxFacturaDocumentoNumero.TabIndex = 24
        Me.maskedtextboxFacturaDocumentoNumero.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'tabpageContacto
        '
        Me.tabpageContacto.Controls.Add(Me.checkboxVerificarEmail2)
        Me.tabpageContacto.Controls.Add(Me.checkboxVerificarEmail1)
        Me.tabpageContacto.Controls.Add(Me.comboboxComprobanteEnviarEmail)
        Me.tabpageContacto.Controls.Add(labelComprobanteEnviarEmail)
        Me.tabpageContacto.Controls.Add(labelDomicilioCalle3)
        Me.tabpageContacto.Controls.Add(labelDomicilioCalle2)
        Me.tabpageContacto.Controls.Add(Me.textboxDomicilioCalle3)
        Me.tabpageContacto.Controls.Add(Me.textboxDomicilioCalle2)
        Me.tabpageContacto.Controls.Add(Me.comboboxDomicilioLocalidad)
        Me.tabpageContacto.Controls.Add(Me.comboboxDomicilioProvincia)
        Me.tabpageContacto.Controls.Add(labelDomicilioCalle1)
        Me.tabpageContacto.Controls.Add(Me.textboxDomicilioCalle1)
        Me.tabpageContacto.Controls.Add(labelDomicilioCodigoPostal)
        Me.tabpageContacto.Controls.Add(Me.textboxDomicilioCodigoPostal)
        Me.tabpageContacto.Controls.Add(labelDomicilioDepartamento)
        Me.tabpageContacto.Controls.Add(Me.textboxDomicilioDepartamento)
        Me.tabpageContacto.Controls.Add(labelDomicilioLocalidad)
        Me.tabpageContacto.Controls.Add(labelDomicilioProvincia)
        Me.tabpageContacto.Controls.Add(labelDomicilioNumero)
        Me.tabpageContacto.Controls.Add(Me.textboxDomicilioNumero)
        Me.tabpageContacto.Controls.Add(labelDomicilioPiso)
        Me.tabpageContacto.Controls.Add(Me.textboxDomicilioPiso)
        Me.tabpageContacto.Controls.Add(labelEmail1)
        Me.tabpageContacto.Controls.Add(Me.textboxEmail1)
        Me.tabpageContacto.Controls.Add(labelEmail2)
        Me.tabpageContacto.Controls.Add(Me.textboxEmail2)
        Me.tabpageContacto.Controls.Add(labelTelefono1)
        Me.tabpageContacto.Controls.Add(Me.textboxTelefono1)
        Me.tabpageContacto.Controls.Add(labelTelefono2)
        Me.tabpageContacto.Controls.Add(Me.textboxTelefono2)
        Me.tabpageContacto.Controls.Add(labelTelefono3)
        Me.tabpageContacto.Controls.Add(Me.textboxTelefono3)
        Me.tabpageContacto.Location = New System.Drawing.Point(4, 28)
        Me.tabpageContacto.Margin = New System.Windows.Forms.Padding(4)
        Me.tabpageContacto.Name = "tabpageContacto"
        Me.tabpageContacto.Padding = New System.Windows.Forms.Padding(4)
        Me.tabpageContacto.Size = New System.Drawing.Size(677, 329)
        Me.tabpageContacto.TabIndex = 1
        Me.tabpageContacto.Text = "Contacto"
        Me.tabpageContacto.UseVisualStyleBackColor = True
        '
        'comboboxComprobanteEnviarEmail
        '
        Me.comboboxComprobanteEnviarEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxComprobanteEnviarEmail.FormattingEnabled = True
        Me.comboboxComprobanteEnviarEmail.Location = New System.Drawing.Point(175, 117)
        Me.comboboxComprobanteEnviarEmail.Margin = New System.Windows.Forms.Padding(4)
        Me.comboboxComprobanteEnviarEmail.Name = "comboboxComprobanteEnviarEmail"
        Me.comboboxComprobanteEnviarEmail.Size = New System.Drawing.Size(467, 24)
        Me.comboboxComprobanteEnviarEmail.TabIndex = 11
        '
        'textboxDomicilioCalle3
        '
        Me.textboxDomicilioCalle3.Location = New System.Drawing.Point(440, 225)
        Me.textboxDomicilioCalle3.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxDomicilioCalle3.MaxLength = 50
        Me.textboxDomicilioCalle3.Name = "textboxDomicilioCalle3"
        Me.textboxDomicilioCalle3.Size = New System.Drawing.Size(225, 22)
        Me.textboxDomicilioCalle3.TabIndex = 23
        '
        'textboxDomicilioCalle2
        '
        Me.textboxDomicilioCalle2.Location = New System.Drawing.Point(96, 225)
        Me.textboxDomicilioCalle2.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxDomicilioCalle2.MaxLength = 50
        Me.textboxDomicilioCalle2.Name = "textboxDomicilioCalle2"
        Me.textboxDomicilioCalle2.Size = New System.Drawing.Size(225, 22)
        Me.textboxDomicilioCalle2.TabIndex = 21
        '
        'comboboxDomicilioLocalidad
        '
        Me.comboboxDomicilioLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxDomicilioLocalidad.FormattingEnabled = True
        Me.comboboxDomicilioLocalidad.Location = New System.Drawing.Point(96, 290)
        Me.comboboxDomicilioLocalidad.Margin = New System.Windows.Forms.Padding(4)
        Me.comboboxDomicilioLocalidad.Name = "comboboxDomicilioLocalidad"
        Me.comboboxDomicilioLocalidad.Size = New System.Drawing.Size(343, 24)
        Me.comboboxDomicilioLocalidad.TabIndex = 27
        '
        'comboboxDomicilioProvincia
        '
        Me.comboboxDomicilioProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxDomicilioProvincia.FormattingEnabled = True
        Me.comboboxDomicilioProvincia.Location = New System.Drawing.Point(96, 257)
        Me.comboboxDomicilioProvincia.Margin = New System.Windows.Forms.Padding(4)
        Me.comboboxDomicilioProvincia.Name = "comboboxDomicilioProvincia"
        Me.comboboxDomicilioProvincia.Size = New System.Drawing.Size(343, 24)
        Me.comboboxDomicilioProvincia.TabIndex = 25
        '
        'textboxDomicilioCalle1
        '
        Me.textboxDomicilioCalle1.Location = New System.Drawing.Point(96, 161)
        Me.textboxDomicilioCalle1.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxDomicilioCalle1.MaxLength = 100
        Me.textboxDomicilioCalle1.Name = "textboxDomicilioCalle1"
        Me.textboxDomicilioCalle1.Size = New System.Drawing.Size(343, 22)
        Me.textboxDomicilioCalle1.TabIndex = 13
        '
        'textboxDomicilioCodigoPostal
        '
        Me.textboxDomicilioCodigoPostal.Location = New System.Drawing.Point(600, 290)
        Me.textboxDomicilioCodigoPostal.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxDomicilioCodigoPostal.MaxLength = 8
        Me.textboxDomicilioCodigoPostal.Name = "textboxDomicilioCodigoPostal"
        Me.textboxDomicilioCodigoPostal.Size = New System.Drawing.Size(65, 22)
        Me.textboxDomicilioCodigoPostal.TabIndex = 29
        '
        'textboxDomicilioDepartamento
        '
        Me.textboxDomicilioDepartamento.Location = New System.Drawing.Point(373, 193)
        Me.textboxDomicilioDepartamento.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxDomicilioDepartamento.MaxLength = 10
        Me.textboxDomicilioDepartamento.Name = "textboxDomicilioDepartamento"
        Me.textboxDomicilioDepartamento.Size = New System.Drawing.Size(65, 22)
        Me.textboxDomicilioDepartamento.TabIndex = 19
        '
        'textboxDomicilioNumero
        '
        Me.textboxDomicilioNumero.Location = New System.Drawing.Point(96, 193)
        Me.textboxDomicilioNumero.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxDomicilioNumero.MaxLength = 10
        Me.textboxDomicilioNumero.Name = "textboxDomicilioNumero"
        Me.textboxDomicilioNumero.Size = New System.Drawing.Size(65, 22)
        Me.textboxDomicilioNumero.TabIndex = 15
        '
        'textboxDomicilioPiso
        '
        Me.textboxDomicilioPiso.Location = New System.Drawing.Point(219, 193)
        Me.textboxDomicilioPiso.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxDomicilioPiso.MaxLength = 10
        Me.textboxDomicilioPiso.Name = "textboxDomicilioPiso"
        Me.textboxDomicilioPiso.Size = New System.Drawing.Size(65, 22)
        Me.textboxDomicilioPiso.TabIndex = 17
        '
        'textboxEmail1
        '
        Me.textboxEmail1.Location = New System.Drawing.Point(96, 85)
        Me.textboxEmail1.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxEmail1.MaxLength = 50
        Me.textboxEmail1.Name = "textboxEmail1"
        Me.textboxEmail1.Size = New System.Drawing.Size(200, 22)
        Me.textboxEmail1.TabIndex = 7
        '
        'textboxEmail2
        '
        Me.textboxEmail2.Location = New System.Drawing.Point(440, 85)
        Me.textboxEmail2.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxEmail2.MaxLength = 50
        Me.textboxEmail2.Name = "textboxEmail2"
        Me.textboxEmail2.Size = New System.Drawing.Size(202, 22)
        Me.textboxEmail2.TabIndex = 9
        '
        'textboxTelefono1
        '
        Me.textboxTelefono1.Location = New System.Drawing.Point(96, 9)
        Me.textboxTelefono1.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxTelefono1.MaxLength = 50
        Me.textboxTelefono1.Name = "textboxTelefono1"
        Me.textboxTelefono1.Size = New System.Drawing.Size(225, 22)
        Me.textboxTelefono1.TabIndex = 1
        '
        'textboxTelefono2
        '
        Me.textboxTelefono2.Location = New System.Drawing.Point(440, 9)
        Me.textboxTelefono2.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxTelefono2.MaxLength = 50
        Me.textboxTelefono2.Name = "textboxTelefono2"
        Me.textboxTelefono2.Size = New System.Drawing.Size(225, 22)
        Me.textboxTelefono2.TabIndex = 3
        '
        'textboxTelefono3
        '
        Me.textboxTelefono3.Location = New System.Drawing.Point(96, 41)
        Me.textboxTelefono3.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxTelefono3.MaxLength = 50
        Me.textboxTelefono3.Name = "textboxTelefono3"
        Me.textboxTelefono3.Size = New System.Drawing.Size(225, 22)
        Me.textboxTelefono3.TabIndex = 5
        '
        'tabpagePadresYFacturacion
        '
        Me.tabpagePadresYFacturacion.Controls.Add(Me.textboxFacturaLeyenda)
        Me.tabpagePadresYFacturacion.Controls.Add(labelFacturaLeyenda)
        Me.tabpagePadresYFacturacion.Controls.Add(labelVarios)
        Me.tabpagePadresYFacturacion.Controls.Add(Me.checkboxFacturaIndividual)
        Me.tabpagePadresYFacturacion.Controls.Add(labelFacturaIndividual)
        Me.tabpagePadresYFacturacion.Controls.Add(Me.checkboxExcluyeCalculoInteres)
        Me.tabpagePadresYFacturacion.Controls.Add(labelExcluyeCalculoInteres)
        Me.tabpagePadresYFacturacion.Controls.Add(Me.panelEntidadTercero)
        Me.tabpagePadresYFacturacion.Controls.Add(Me.labelEntidadTercero)
        Me.tabpagePadresYFacturacion.Controls.Add(Me.datetimepickerExcluyeFacturaHasta)
        Me.tabpagePadresYFacturacion.Controls.Add(labelExcluyeFacturaHasta)
        Me.tabpagePadresYFacturacion.Controls.Add(Me.datetimepickerExcluyeFacturaDesde)
        Me.tabpagePadresYFacturacion.Controls.Add(labelExcluyeFacturaDesde)
        Me.tabpagePadresYFacturacion.Controls.Add(Me.comboboxDescuento)
        Me.tabpagePadresYFacturacion.Controls.Add(labelDescuento)
        Me.tabpagePadresYFacturacion.Controls.Add(Me.comboboxEmitirFacturaA)
        Me.tabpagePadresYFacturacion.Controls.Add(Me.labelEmitirFacturaA)
        Me.tabpagePadresYFacturacion.Controls.Add(Me.labelEntidadMadre)
        Me.tabpagePadresYFacturacion.Controls.Add(Me.panelEntidadMadre)
        Me.tabpagePadresYFacturacion.Controls.Add(Me.panelEntidadPadre)
        Me.tabpagePadresYFacturacion.Controls.Add(Me.labelEntidadPadre)
        Me.tabpagePadresYFacturacion.Location = New System.Drawing.Point(4, 28)
        Me.tabpagePadresYFacturacion.Margin = New System.Windows.Forms.Padding(4)
        Me.tabpagePadresYFacturacion.Name = "tabpagePadresYFacturacion"
        Me.tabpagePadresYFacturacion.Padding = New System.Windows.Forms.Padding(4)
        Me.tabpagePadresYFacturacion.Size = New System.Drawing.Size(677, 329)
        Me.tabpagePadresYFacturacion.TabIndex = 2
        Me.tabpagePadresYFacturacion.Text = "Padres y Facturación"
        Me.tabpagePadresYFacturacion.UseVisualStyleBackColor = True
        '
        'textboxFacturaLeyenda
        '
        Me.textboxFacturaLeyenda.Location = New System.Drawing.Point(143, 240)
        Me.textboxFacturaLeyenda.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxFacturaLeyenda.MaxLength = 0
        Me.textboxFacturaLeyenda.Multiline = True
        Me.textboxFacturaLeyenda.Name = "textboxFacturaLeyenda"
        Me.textboxFacturaLeyenda.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textboxFacturaLeyenda.Size = New System.Drawing.Size(523, 52)
        Me.textboxFacturaLeyenda.TabIndex = 19
        '
        'checkboxFacturaIndividual
        '
        Me.checkboxFacturaIndividual.AutoSize = True
        Me.checkboxFacturaIndividual.Location = New System.Drawing.Point(143, 181)
        Me.checkboxFacturaIndividual.Margin = New System.Windows.Forms.Padding(4)
        Me.checkboxFacturaIndividual.Name = "checkboxFacturaIndividual"
        Me.checkboxFacturaIndividual.Size = New System.Drawing.Size(18, 17)
        Me.checkboxFacturaIndividual.TabIndex = 10
        Me.checkboxFacturaIndividual.UseVisualStyleBackColor = True
        '
        'checkboxExcluyeCalculoInteres
        '
        Me.checkboxExcluyeCalculoInteres.AutoSize = True
        Me.checkboxExcluyeCalculoInteres.Location = New System.Drawing.Point(379, 182)
        Me.checkboxExcluyeCalculoInteres.Margin = New System.Windows.Forms.Padding(4)
        Me.checkboxExcluyeCalculoInteres.Name = "checkboxExcluyeCalculoInteres"
        Me.checkboxExcluyeCalculoInteres.Size = New System.Drawing.Size(18, 17)
        Me.checkboxExcluyeCalculoInteres.TabIndex = 12
        Me.checkboxExcluyeCalculoInteres.UseVisualStyleBackColor = True
        '
        'panelEntidadTercero
        '
        Me.panelEntidadTercero.Controls.Add(Me.buttonEntidadTerceroBorrar)
        Me.panelEntidadTercero.Controls.Add(Me.buttonEntidadTercero)
        Me.panelEntidadTercero.Controls.Add(Me.textboxEntidadTercero)
        Me.panelEntidadTercero.Location = New System.Drawing.Point(143, 112)
        Me.panelEntidadTercero.Margin = New System.Windows.Forms.Padding(4)
        Me.panelEntidadTercero.Name = "panelEntidadTercero"
        Me.panelEntidadTercero.Size = New System.Drawing.Size(524, 27)
        Me.panelEntidadTercero.TabIndex = 7
        '
        'buttonEntidadTerceroBorrar
        '
        Me.buttonEntidadTerceroBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonEntidadTerceroBorrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_16
        Me.buttonEntidadTerceroBorrar.Location = New System.Drawing.Point(495, 0)
        Me.buttonEntidadTerceroBorrar.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonEntidadTerceroBorrar.Name = "buttonEntidadTerceroBorrar"
        Me.buttonEntidadTerceroBorrar.Size = New System.Drawing.Size(29, 27)
        Me.buttonEntidadTerceroBorrar.TabIndex = 2
        Me.buttonEntidadTerceroBorrar.Text = "…"
        Me.buttonEntidadTerceroBorrar.UseVisualStyleBackColor = True
        '
        'buttonEntidadTercero
        '
        Me.buttonEntidadTercero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonEntidadTercero.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonEntidadTercero.Location = New System.Drawing.Point(467, 0)
        Me.buttonEntidadTercero.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonEntidadTercero.Name = "buttonEntidadTercero"
        Me.buttonEntidadTercero.Size = New System.Drawing.Size(29, 27)
        Me.buttonEntidadTercero.TabIndex = 1
        Me.buttonEntidadTercero.Text = "…"
        Me.buttonEntidadTercero.UseVisualStyleBackColor = True
        '
        'textboxEntidadTercero
        '
        Me.textboxEntidadTercero.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxEntidadTercero.Location = New System.Drawing.Point(0, 1)
        Me.textboxEntidadTercero.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxEntidadTercero.MaxLength = 150
        Me.textboxEntidadTercero.Name = "textboxEntidadTercero"
        Me.textboxEntidadTercero.ReadOnly = True
        Me.textboxEntidadTercero.Size = New System.Drawing.Size(465, 22)
        Me.textboxEntidadTercero.TabIndex = 0
        Me.textboxEntidadTercero.TabStop = False
        '
        'labelEntidadTercero
        '
        Me.labelEntidadTercero.AutoSize = True
        Me.labelEntidadTercero.Location = New System.Drawing.Point(8, 118)
        Me.labelEntidadTercero.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelEntidadTercero.Name = "labelEntidadTercero"
        Me.labelEntidadTercero.Size = New System.Drawing.Size(62, 17)
        Me.labelEntidadTercero.TabIndex = 6
        Me.labelEntidadTercero.Text = "Tercero:"
        '
        'datetimepickerExcluyeFacturaHasta
        '
        Me.datetimepickerExcluyeFacturaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerExcluyeFacturaHasta.Location = New System.Drawing.Point(404, 208)
        Me.datetimepickerExcluyeFacturaHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.datetimepickerExcluyeFacturaHasta.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerExcluyeFacturaHasta.MinDate = New Date(2008, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerExcluyeFacturaHasta.Name = "datetimepickerExcluyeFacturaHasta"
        Me.datetimepickerExcluyeFacturaHasta.ShowCheckBox = True
        Me.datetimepickerExcluyeFacturaHasta.Size = New System.Drawing.Size(196, 22)
        Me.datetimepickerExcluyeFacturaHasta.TabIndex = 17
        '
        'datetimepickerExcluyeFacturaDesde
        '
        Me.datetimepickerExcluyeFacturaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerExcluyeFacturaDesde.Location = New System.Drawing.Point(143, 208)
        Me.datetimepickerExcluyeFacturaDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.datetimepickerExcluyeFacturaDesde.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerExcluyeFacturaDesde.MinDate = New Date(2008, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerExcluyeFacturaDesde.Name = "datetimepickerExcluyeFacturaDesde"
        Me.datetimepickerExcluyeFacturaDesde.ShowCheckBox = True
        Me.datetimepickerExcluyeFacturaDesde.Size = New System.Drawing.Size(196, 22)
        Me.datetimepickerExcluyeFacturaDesde.TabIndex = 15
        '
        'comboboxDescuento
        '
        Me.comboboxDescuento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxDescuento.FormattingEnabled = True
        Me.comboboxDescuento.Location = New System.Drawing.Point(143, 146)
        Me.comboboxDescuento.Margin = New System.Windows.Forms.Padding(4)
        Me.comboboxDescuento.Name = "comboboxDescuento"
        Me.comboboxDescuento.Size = New System.Drawing.Size(212, 24)
        Me.comboboxDescuento.TabIndex = 8
        '
        'comboboxEmitirFacturaA
        '
        Me.comboboxEmitirFacturaA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxEmitirFacturaA.FormattingEnabled = True
        Me.comboboxEmitirFacturaA.Location = New System.Drawing.Point(143, 79)
        Me.comboboxEmitirFacturaA.Margin = New System.Windows.Forms.Padding(4)
        Me.comboboxEmitirFacturaA.Name = "comboboxEmitirFacturaA"
        Me.comboboxEmitirFacturaA.Size = New System.Drawing.Size(212, 24)
        Me.comboboxEmitirFacturaA.TabIndex = 3
        '
        'labelEmitirFacturaA
        '
        Me.labelEmitirFacturaA.AutoSize = True
        Me.labelEmitirFacturaA.Location = New System.Drawing.Point(8, 82)
        Me.labelEmitirFacturaA.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelEmitirFacturaA.Name = "labelEmitirFacturaA"
        Me.labelEmitirFacturaA.Size = New System.Drawing.Size(111, 17)
        Me.labelEmitirFacturaA.TabIndex = 2
        Me.labelEmitirFacturaA.Text = "Emitir Factura a:"
        '
        'labelEntidadMadre
        '
        Me.labelEntidadMadre.AutoSize = True
        Me.labelEntidadMadre.Location = New System.Drawing.Point(8, 50)
        Me.labelEntidadMadre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelEntidadMadre.Name = "labelEntidadMadre"
        Me.labelEntidadMadre.Size = New System.Drawing.Size(106, 17)
        Me.labelEntidadMadre.TabIndex = 1
        Me.labelEntidadMadre.Text = "Madre / Tutora:"
        '
        'panelEntidadMadre
        '
        Me.panelEntidadMadre.Controls.Add(Me.buttonEntidadMadreBorrar)
        Me.panelEntidadMadre.Controls.Add(Me.buttonEntidadMadre)
        Me.panelEntidadMadre.Controls.Add(Me.textboxEntidadMadre)
        Me.panelEntidadMadre.Location = New System.Drawing.Point(143, 44)
        Me.panelEntidadMadre.Margin = New System.Windows.Forms.Padding(4)
        Me.panelEntidadMadre.Name = "panelEntidadMadre"
        Me.panelEntidadMadre.Size = New System.Drawing.Size(524, 27)
        Me.panelEntidadMadre.TabIndex = 3
        '
        'buttonEntidadMadreBorrar
        '
        Me.buttonEntidadMadreBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonEntidadMadreBorrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_16
        Me.buttonEntidadMadreBorrar.Location = New System.Drawing.Point(495, 0)
        Me.buttonEntidadMadreBorrar.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonEntidadMadreBorrar.Name = "buttonEntidadMadreBorrar"
        Me.buttonEntidadMadreBorrar.Size = New System.Drawing.Size(29, 27)
        Me.buttonEntidadMadreBorrar.TabIndex = 2
        Me.buttonEntidadMadreBorrar.Text = "…"
        Me.buttonEntidadMadreBorrar.UseVisualStyleBackColor = True
        '
        'buttonEntidadMadre
        '
        Me.buttonEntidadMadre.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonEntidadMadre.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonEntidadMadre.Location = New System.Drawing.Point(467, 0)
        Me.buttonEntidadMadre.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonEntidadMadre.Name = "buttonEntidadMadre"
        Me.buttonEntidadMadre.Size = New System.Drawing.Size(29, 27)
        Me.buttonEntidadMadre.TabIndex = 1
        Me.buttonEntidadMadre.Text = "…"
        Me.buttonEntidadMadre.UseVisualStyleBackColor = True
        '
        'textboxEntidadMadre
        '
        Me.textboxEntidadMadre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxEntidadMadre.Location = New System.Drawing.Point(0, 1)
        Me.textboxEntidadMadre.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxEntidadMadre.MaxLength = 150
        Me.textboxEntidadMadre.Name = "textboxEntidadMadre"
        Me.textboxEntidadMadre.ReadOnly = True
        Me.textboxEntidadMadre.Size = New System.Drawing.Size(465, 22)
        Me.textboxEntidadMadre.TabIndex = 0
        Me.textboxEntidadMadre.TabStop = False
        '
        'panelEntidadPadre
        '
        Me.panelEntidadPadre.Controls.Add(Me.buttonEntidadPadreBorrar)
        Me.panelEntidadPadre.Controls.Add(Me.buttonEntidadPadre)
        Me.panelEntidadPadre.Controls.Add(Me.textboxEntidadPadre)
        Me.panelEntidadPadre.Location = New System.Drawing.Point(143, 10)
        Me.panelEntidadPadre.Margin = New System.Windows.Forms.Padding(4)
        Me.panelEntidadPadre.Name = "panelEntidadPadre"
        Me.panelEntidadPadre.Size = New System.Drawing.Size(524, 27)
        Me.panelEntidadPadre.TabIndex = 1
        '
        'buttonEntidadPadreBorrar
        '
        Me.buttonEntidadPadreBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonEntidadPadreBorrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_16
        Me.buttonEntidadPadreBorrar.Location = New System.Drawing.Point(495, 0)
        Me.buttonEntidadPadreBorrar.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonEntidadPadreBorrar.Name = "buttonEntidadPadreBorrar"
        Me.buttonEntidadPadreBorrar.Size = New System.Drawing.Size(29, 27)
        Me.buttonEntidadPadreBorrar.TabIndex = 2
        Me.buttonEntidadPadreBorrar.Text = "…"
        Me.buttonEntidadPadreBorrar.UseVisualStyleBackColor = True
        '
        'buttonEntidadPadre
        '
        Me.buttonEntidadPadre.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonEntidadPadre.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonEntidadPadre.Location = New System.Drawing.Point(467, 0)
        Me.buttonEntidadPadre.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonEntidadPadre.Name = "buttonEntidadPadre"
        Me.buttonEntidadPadre.Size = New System.Drawing.Size(29, 27)
        Me.buttonEntidadPadre.TabIndex = 1
        Me.buttonEntidadPadre.Text = "…"
        Me.buttonEntidadPadre.UseVisualStyleBackColor = True
        '
        'textboxEntidadPadre
        '
        Me.textboxEntidadPadre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxEntidadPadre.Location = New System.Drawing.Point(0, 1)
        Me.textboxEntidadPadre.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxEntidadPadre.MaxLength = 150
        Me.textboxEntidadPadre.Name = "textboxEntidadPadre"
        Me.textboxEntidadPadre.ReadOnly = True
        Me.textboxEntidadPadre.Size = New System.Drawing.Size(465, 22)
        Me.textboxEntidadPadre.TabIndex = 0
        Me.textboxEntidadPadre.TabStop = False
        '
        'labelEntidadPadre
        '
        Me.labelEntidadPadre.AutoSize = True
        Me.labelEntidadPadre.Location = New System.Drawing.Point(8, 15)
        Me.labelEntidadPadre.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelEntidadPadre.Name = "labelEntidadPadre"
        Me.labelEntidadPadre.Size = New System.Drawing.Size(96, 17)
        Me.labelEntidadPadre.TabIndex = 0
        Me.labelEntidadPadre.Text = "Padre / Tutor:"
        '
        'tabpageDebitoAutomatico
        '
        Me.tabpageDebitoAutomatico.Controls.Add(labelDebitoAutomatico_Tipo)
        Me.tabpageDebitoAutomatico.Controls.Add(Me.radiobuttonDebitoAutomatico_Tipo_Ninguno)
        Me.tabpageDebitoAutomatico.Controls.Add(Me.radiobuttonDebitoAutomatico_Tipo_DebitoDirecto)
        Me.tabpageDebitoAutomatico.Controls.Add(Me.radiobuttonDebitoAutomatico_Tipo_TarjetaCredito)
        Me.tabpageDebitoAutomatico.Controls.Add(labelDebitoAutomatico_CBU)
        Me.tabpageDebitoAutomatico.Controls.Add(Me.maskedtextboxDebitoAutomatico_CBU)
        Me.tabpageDebitoAutomatico.Location = New System.Drawing.Point(4, 28)
        Me.tabpageDebitoAutomatico.Name = "tabpageDebitoAutomatico"
        Me.tabpageDebitoAutomatico.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageDebitoAutomatico.Size = New System.Drawing.Size(677, 329)
        Me.tabpageDebitoAutomatico.TabIndex = 9
        Me.tabpageDebitoAutomatico.Text = "Débito Automático"
        Me.tabpageDebitoAutomatico.UseVisualStyleBackColor = True
        '
        'radiobuttonDebitoAutomatico_Tipo_Ninguno
        '
        Me.radiobuttonDebitoAutomatico_Tipo_Ninguno.AutoSize = True
        Me.radiobuttonDebitoAutomatico_Tipo_Ninguno.Checked = True
        Me.radiobuttonDebitoAutomatico_Tipo_Ninguno.Location = New System.Drawing.Point(80, 10)
        Me.radiobuttonDebitoAutomatico_Tipo_Ninguno.Name = "radiobuttonDebitoAutomatico_Tipo_Ninguno"
        Me.radiobuttonDebitoAutomatico_Tipo_Ninguno.Size = New System.Drawing.Size(82, 21)
        Me.radiobuttonDebitoAutomatico_Tipo_Ninguno.TabIndex = 2
        Me.radiobuttonDebitoAutomatico_Tipo_Ninguno.TabStop = True
        Me.radiobuttonDebitoAutomatico_Tipo_Ninguno.Text = "Ninguno"
        Me.radiobuttonDebitoAutomatico_Tipo_Ninguno.UseVisualStyleBackColor = True
        '
        'radiobuttonDebitoAutomatico_Tipo_DebitoDirecto
        '
        Me.radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.AutoSize = True
        Me.radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.Checked = True
        Me.radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.Location = New System.Drawing.Point(206, 10)
        Me.radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.Name = "radiobuttonDebitoAutomatico_Tipo_DebitoDirecto"
        Me.radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.Size = New System.Drawing.Size(141, 21)
        Me.radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.TabIndex = 3
        Me.radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.TabStop = True
        Me.radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.Text = "Directo en cuenta"
        Me.radiobuttonDebitoAutomatico_Tipo_DebitoDirecto.UseVisualStyleBackColor = True
        '
        'radiobuttonDebitoAutomatico_Tipo_TarjetaCredito
        '
        Me.radiobuttonDebitoAutomatico_Tipo_TarjetaCredito.AutoSize = True
        Me.radiobuttonDebitoAutomatico_Tipo_TarjetaCredito.Checked = True
        Me.radiobuttonDebitoAutomatico_Tipo_TarjetaCredito.Location = New System.Drawing.Point(387, 10)
        Me.radiobuttonDebitoAutomatico_Tipo_TarjetaCredito.Name = "radiobuttonDebitoAutomatico_Tipo_TarjetaCredito"
        Me.radiobuttonDebitoAutomatico_Tipo_TarjetaCredito.Size = New System.Drawing.Size(141, 21)
        Me.radiobuttonDebitoAutomatico_Tipo_TarjetaCredito.TabIndex = 4
        Me.radiobuttonDebitoAutomatico_Tipo_TarjetaCredito.TabStop = True
        Me.radiobuttonDebitoAutomatico_Tipo_TarjetaCredito.Text = "Tarjeta de crédito"
        Me.radiobuttonDebitoAutomatico_Tipo_TarjetaCredito.UseVisualStyleBackColor = True
        '
        'maskedtextboxDebitoAutomatico_CBU
        '
        Me.maskedtextboxDebitoAutomatico_CBU.AllowPromptAsInput = False
        Me.maskedtextboxDebitoAutomatico_CBU.AsciiOnly = True
        Me.maskedtextboxDebitoAutomatico_CBU.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.maskedtextboxDebitoAutomatico_CBU.HidePromptOnLeave = True
        Me.maskedtextboxDebitoAutomatico_CBU.Location = New System.Drawing.Point(80, 50)
        Me.maskedtextboxDebitoAutomatico_CBU.Mask = "0000000-0 0000000000000-0"
        Me.maskedtextboxDebitoAutomatico_CBU.Name = "maskedtextboxDebitoAutomatico_CBU"
        Me.maskedtextboxDebitoAutomatico_CBU.Size = New System.Drawing.Size(203, 22)
        Me.maskedtextboxDebitoAutomatico_CBU.TabIndex = 6
        Me.maskedtextboxDebitoAutomatico_CBU.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'tabpageCursosAsistidos
        '
        Me.tabpageCursosAsistidos.Controls.Add(Me.datagridviewCursosAsistidos)
        Me.tabpageCursosAsistidos.Location = New System.Drawing.Point(4, 28)
        Me.tabpageCursosAsistidos.Margin = New System.Windows.Forms.Padding(4)
        Me.tabpageCursosAsistidos.Name = "tabpageCursosAsistidos"
        Me.tabpageCursosAsistidos.Padding = New System.Windows.Forms.Padding(4)
        Me.tabpageCursosAsistidos.Size = New System.Drawing.Size(677, 329)
        Me.tabpageCursosAsistidos.TabIndex = 6
        Me.tabpageCursosAsistidos.Text = "Cursos Asistidos"
        Me.tabpageCursosAsistidos.UseVisualStyleBackColor = True
        '
        'datagridviewCursosAsistidos
        '
        Me.datagridviewCursosAsistidos.AllowUserToAddRows = False
        Me.datagridviewCursosAsistidos.AllowUserToDeleteRows = False
        Me.datagridviewCursosAsistidos.AllowUserToOrderColumns = True
        Me.datagridviewCursosAsistidos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewCursosAsistidos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewCursosAsistidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewCursosAsistidos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnAnioLectivo, Me.columnNivelNombre, Me.columnAnioNombre, Me.columnTurnoNombre, Me.columnDivision})
        Me.datagridviewCursosAsistidos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewCursosAsistidos.Location = New System.Drawing.Point(4, 4)
        Me.datagridviewCursosAsistidos.Margin = New System.Windows.Forms.Padding(4)
        Me.datagridviewCursosAsistidos.MultiSelect = False
        Me.datagridviewCursosAsistidos.Name = "datagridviewCursosAsistidos"
        Me.datagridviewCursosAsistidos.ReadOnly = True
        Me.datagridviewCursosAsistidos.RowHeadersVisible = False
        Me.datagridviewCursosAsistidos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewCursosAsistidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewCursosAsistidos.Size = New System.Drawing.Size(669, 321)
        Me.datagridviewCursosAsistidos.TabIndex = 5
        '
        'columnAnioLectivo
        '
        Me.columnAnioLectivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnAnioLectivo.DataPropertyName = "AnioLectivo"
        Me.columnAnioLectivo.HeaderText = "Año Lectivo"
        Me.columnAnioLectivo.Name = "columnAnioLectivo"
        Me.columnAnioLectivo.ReadOnly = True
        Me.columnAnioLectivo.Width = 111
        '
        'columnNivelNombre
        '
        Me.columnNivelNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNivelNombre.DataPropertyName = "NivelNombre"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnNivelNombre.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnNivelNombre.HeaderText = "Nivel"
        Me.columnNivelNombre.Name = "columnNivelNombre"
        Me.columnNivelNombre.ReadOnly = True
        Me.columnNivelNombre.Width = 68
        '
        'columnAnioNombre
        '
        Me.columnAnioNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnAnioNombre.DataPropertyName = "AnioNombre"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnAnioNombre.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnAnioNombre.HeaderText = "Año"
        Me.columnAnioNombre.Name = "columnAnioNombre"
        Me.columnAnioNombre.ReadOnly = True
        Me.columnAnioNombre.Width = 62
        '
        'columnTurnoNombre
        '
        Me.columnTurnoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTurnoNombre.DataPropertyName = "TurnoNombre"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnTurnoNombre.DefaultCellStyle = DataGridViewCellStyle4
        Me.columnTurnoNombre.HeaderText = "Turno"
        Me.columnTurnoNombre.Name = "columnTurnoNombre"
        Me.columnTurnoNombre.ReadOnly = True
        Me.columnTurnoNombre.Width = 75
        '
        'columnDivision
        '
        Me.columnDivision.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnDivision.DataPropertyName = "Division"
        Me.columnDivision.HeaderText = "División"
        Me.columnDivision.Name = "columnDivision"
        Me.columnDivision.ReadOnly = True
        Me.columnDivision.Width = 86
        '
        'tabpageHijos
        '
        Me.tabpageHijos.Controls.Add(Me.datagridviewHijos)
        Me.tabpageHijos.Location = New System.Drawing.Point(4, 28)
        Me.tabpageHijos.Margin = New System.Windows.Forms.Padding(4)
        Me.tabpageHijos.Name = "tabpageHijos"
        Me.tabpageHijos.Padding = New System.Windows.Forms.Padding(4)
        Me.tabpageHijos.Size = New System.Drawing.Size(677, 329)
        Me.tabpageHijos.TabIndex = 4
        Me.tabpageHijos.Text = "Hijos"
        Me.tabpageHijos.UseVisualStyleBackColor = True
        '
        'datagridviewHijos
        '
        Me.datagridviewHijos.AllowUserToAddRows = False
        Me.datagridviewHijos.AllowUserToDeleteRows = False
        Me.datagridviewHijos.AllowUserToOrderColumns = True
        Me.datagridviewHijos.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewHijos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.datagridviewHijos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewHijos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnHijosIDEntidad, Me.columnHijosApellido, Me.columnHijosNombre})
        Me.datagridviewHijos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewHijos.Location = New System.Drawing.Point(4, 4)
        Me.datagridviewHijos.Margin = New System.Windows.Forms.Padding(4)
        Me.datagridviewHijos.MultiSelect = False
        Me.datagridviewHijos.Name = "datagridviewHijos"
        Me.datagridviewHijos.ReadOnly = True
        Me.datagridviewHijos.RowHeadersVisible = False
        Me.datagridviewHijos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewHijos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewHijos.Size = New System.Drawing.Size(669, 321)
        Me.datagridviewHijos.TabIndex = 3
        '
        'columnHijosIDEntidad
        '
        Me.columnHijosIDEntidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnHijosIDEntidad.DataPropertyName = "IDEntidad"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnHijosIDEntidad.DefaultCellStyle = DataGridViewCellStyle6
        Me.columnHijosIDEntidad.HeaderText = "N° Entidad"
        Me.columnHijosIDEntidad.Name = "columnHijosIDEntidad"
        Me.columnHijosIDEntidad.ReadOnly = True
        Me.columnHijosIDEntidad.Width = 105
        '
        'columnHijosApellido
        '
        Me.columnHijosApellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnHijosApellido.DataPropertyName = "Apellido"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnHijosApellido.DefaultCellStyle = DataGridViewCellStyle7
        Me.columnHijosApellido.HeaderText = "Apellido"
        Me.columnHijosApellido.Name = "columnHijosApellido"
        Me.columnHijosApellido.ReadOnly = True
        Me.columnHijosApellido.Width = 87
        '
        'columnHijosNombre
        '
        Me.columnHijosNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnHijosNombre.DataPropertyName = "Nombre"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnHijosNombre.DefaultCellStyle = DataGridViewCellStyle8
        Me.columnHijosNombre.HeaderText = "Nombre"
        Me.columnHijosNombre.Name = "columnHijosNombre"
        Me.columnHijosNombre.ReadOnly = True
        Me.columnHijosNombre.Width = 87
        '
        'tabpageComprobantes
        '
        Me.tabpageComprobantes.Controls.Add(Me.datagridviewComprobantes)
        Me.tabpageComprobantes.Location = New System.Drawing.Point(4, 28)
        Me.tabpageComprobantes.Margin = New System.Windows.Forms.Padding(4)
        Me.tabpageComprobantes.Name = "tabpageComprobantes"
        Me.tabpageComprobantes.Size = New System.Drawing.Size(677, 329)
        Me.tabpageComprobantes.TabIndex = 8
        Me.tabpageComprobantes.Text = "Comprobantes"
        Me.tabpageComprobantes.UseVisualStyleBackColor = True
        '
        'datagridviewComprobantes
        '
        Me.datagridviewComprobantes.AllowUserToAddRows = False
        Me.datagridviewComprobantes.AllowUserToDeleteRows = False
        Me.datagridviewComprobantes.AllowUserToResizeRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewComprobantes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.datagridviewComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewComprobantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnTipoNombre, Me.columnNumeroCompleto, Me.columnFecha, Me.columnImporteTotal})
        Me.datagridviewComprobantes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewComprobantes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datagridviewComprobantes.Location = New System.Drawing.Point(0, 0)
        Me.datagridviewComprobantes.Margin = New System.Windows.Forms.Padding(4)
        Me.datagridviewComprobantes.MultiSelect = False
        Me.datagridviewComprobantes.Name = "datagridviewComprobantes"
        Me.datagridviewComprobantes.ReadOnly = True
        Me.datagridviewComprobantes.RowHeadersVisible = False
        Me.datagridviewComprobantes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewComprobantes.Size = New System.Drawing.Size(677, 329)
        Me.datagridviewComprobantes.TabIndex = 2
        '
        'columnTipoNombre
        '
        Me.columnTipoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTipoNombre.DataPropertyName = "TipoNombre"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnTipoNombre.DefaultCellStyle = DataGridViewCellStyle10
        Me.columnTipoNombre.HeaderText = "Tipo"
        Me.columnTipoNombre.Name = "columnTipoNombre"
        Me.columnTipoNombre.ReadOnly = True
        Me.columnTipoNombre.Width = 65
        '
        'columnNumeroCompleto
        '
        Me.columnNumeroCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNumeroCompleto.DataPropertyName = "NumeroCompleto"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnNumeroCompleto.DefaultCellStyle = DataGridViewCellStyle11
        Me.columnNumeroCompleto.HeaderText = "Número"
        Me.columnNumeroCompleto.Name = "columnNumeroCompleto"
        Me.columnNumeroCompleto.ReadOnly = True
        Me.columnNumeroCompleto.Width = 87
        '
        'columnFecha
        '
        Me.columnFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnFecha.DataPropertyName = "FechaEmision"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnFecha.DefaultCellStyle = DataGridViewCellStyle12
        Me.columnFecha.HeaderText = "Fecha"
        Me.columnFecha.Name = "columnFecha"
        Me.columnFecha.ReadOnly = True
        Me.columnFecha.Width = 76
        '
        'columnImporteTotal
        '
        Me.columnImporteTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.Format = "C2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.columnImporteTotal.DefaultCellStyle = DataGridViewCellStyle13
        Me.columnImporteTotal.HeaderText = "Importe total"
        Me.columnImporteTotal.Name = "columnImporteTotal"
        Me.columnImporteTotal.ReadOnly = True
        Me.columnImporteTotal.Width = 115
        '
        'tabpageRelaciones
        '
        Me.tabpageRelaciones.Controls.Add(Me.datagridviewRelaciones)
        Me.tabpageRelaciones.Location = New System.Drawing.Point(4, 28)
        Me.tabpageRelaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.tabpageRelaciones.Name = "tabpageRelaciones"
        Me.tabpageRelaciones.Padding = New System.Windows.Forms.Padding(4)
        Me.tabpageRelaciones.Size = New System.Drawing.Size(677, 329)
        Me.tabpageRelaciones.TabIndex = 5
        Me.tabpageRelaciones.Text = "Relaciones"
        Me.tabpageRelaciones.UseVisualStyleBackColor = True
        '
        'datagridviewRelaciones
        '
        Me.datagridviewRelaciones.AllowUserToAddRows = False
        Me.datagridviewRelaciones.AllowUserToDeleteRows = False
        Me.datagridviewRelaciones.AllowUserToOrderColumns = True
        Me.datagridviewRelaciones.AllowUserToResizeRows = False
        DataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewRelaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle14
        Me.datagridviewRelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewRelaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnPadresIDEntidad, Me.columnPadresApellido, Me.columnPadresNombre, Me.columnPadresRelacionTipo})
        Me.datagridviewRelaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewRelaciones.Location = New System.Drawing.Point(4, 4)
        Me.datagridviewRelaciones.Margin = New System.Windows.Forms.Padding(4)
        Me.datagridviewRelaciones.MultiSelect = False
        Me.datagridviewRelaciones.Name = "datagridviewRelaciones"
        Me.datagridviewRelaciones.ReadOnly = True
        Me.datagridviewRelaciones.RowHeadersVisible = False
        Me.datagridviewRelaciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewRelaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewRelaciones.Size = New System.Drawing.Size(669, 321)
        Me.datagridviewRelaciones.TabIndex = 4
        '
        'columnPadresIDEntidad
        '
        Me.columnPadresIDEntidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPadresIDEntidad.DataPropertyName = "IDEntidad"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnPadresIDEntidad.DefaultCellStyle = DataGridViewCellStyle15
        Me.columnPadresIDEntidad.HeaderText = "N° Entidad"
        Me.columnPadresIDEntidad.Name = "columnPadresIDEntidad"
        Me.columnPadresIDEntidad.ReadOnly = True
        Me.columnPadresIDEntidad.Width = 105
        '
        'columnPadresApellido
        '
        Me.columnPadresApellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPadresApellido.DataPropertyName = "Apellido"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnPadresApellido.DefaultCellStyle = DataGridViewCellStyle16
        Me.columnPadresApellido.HeaderText = "Apellido"
        Me.columnPadresApellido.Name = "columnPadresApellido"
        Me.columnPadresApellido.ReadOnly = True
        Me.columnPadresApellido.Width = 87
        '
        'columnPadresNombre
        '
        Me.columnPadresNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPadresNombre.DataPropertyName = "Nombre"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnPadresNombre.DefaultCellStyle = DataGridViewCellStyle17
        Me.columnPadresNombre.HeaderText = "Nombre"
        Me.columnPadresNombre.Name = "columnPadresNombre"
        Me.columnPadresNombre.ReadOnly = True
        Me.columnPadresNombre.Width = 87
        '
        'columnPadresRelacionTipo
        '
        Me.columnPadresRelacionTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPadresRelacionTipo.DataPropertyName = "RelacionTipoNombre"
        Me.columnPadresRelacionTipo.HeaderText = "Relación"
        Me.columnPadresRelacionTipo.Name = "columnPadresRelacionTipo"
        Me.columnPadresRelacionTipo.ReadOnly = True
        Me.columnPadresRelacionTipo.Width = 92
        '
        'tabpageNotasAuditoria
        '
        Me.tabpageNotasAuditoria.Controls.Add(labelNotas)
        Me.tabpageNotasAuditoria.Controls.Add(Me.textboxNotas)
        Me.tabpageNotasAuditoria.Controls.Add(Me.textboxUsuarioModificacion)
        Me.tabpageNotasAuditoria.Controls.Add(Me.textboxUsuarioCreacion)
        Me.tabpageNotasAuditoria.Controls.Add(Me.textboxFechaHoraModificacion)
        Me.tabpageNotasAuditoria.Controls.Add(Me.textboxFechaHoraCreacion)
        Me.tabpageNotasAuditoria.Controls.Add(labelModificacion)
        Me.tabpageNotasAuditoria.Controls.Add(labelCreacion)
        Me.tabpageNotasAuditoria.Location = New System.Drawing.Point(4, 28)
        Me.tabpageNotasAuditoria.Margin = New System.Windows.Forms.Padding(4)
        Me.tabpageNotasAuditoria.Name = "tabpageNotasAuditoria"
        Me.tabpageNotasAuditoria.Padding = New System.Windows.Forms.Padding(4)
        Me.tabpageNotasAuditoria.Size = New System.Drawing.Size(677, 329)
        Me.tabpageNotasAuditoria.TabIndex = 7
        Me.tabpageNotasAuditoria.Text = "Notas y Auditoría"
        Me.tabpageNotasAuditoria.UseVisualStyleBackColor = True
        '
        'textboxNotas
        '
        Me.textboxNotas.Location = New System.Drawing.Point(152, 7)
        Me.textboxNotas.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxNotas.MaxLength = 0
        Me.textboxNotas.Multiline = True
        Me.textboxNotas.Name = "textboxNotas"
        Me.textboxNotas.Size = New System.Drawing.Size(513, 190)
        Me.textboxNotas.TabIndex = 16
        '
        'textboxUsuarioModificacion
        '
        Me.textboxUsuarioModificacion.Location = New System.Drawing.Point(321, 238)
        Me.textboxUsuarioModificacion.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxUsuarioModificacion.MaxLength = 50
        Me.textboxUsuarioModificacion.Name = "textboxUsuarioModificacion"
        Me.textboxUsuarioModificacion.ReadOnly = True
        Me.textboxUsuarioModificacion.Size = New System.Drawing.Size(344, 22)
        Me.textboxUsuarioModificacion.TabIndex = 14
        '
        'textboxUsuarioCreacion
        '
        Me.textboxUsuarioCreacion.Location = New System.Drawing.Point(321, 206)
        Me.textboxUsuarioCreacion.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxUsuarioCreacion.MaxLength = 50
        Me.textboxUsuarioCreacion.Name = "textboxUsuarioCreacion"
        Me.textboxUsuarioCreacion.ReadOnly = True
        Me.textboxUsuarioCreacion.Size = New System.Drawing.Size(344, 22)
        Me.textboxUsuarioCreacion.TabIndex = 11
        '
        'textboxFechaHoraModificacion
        '
        Me.textboxFechaHoraModificacion.Location = New System.Drawing.Point(152, 238)
        Me.textboxFechaHoraModificacion.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxFechaHoraModificacion.MaxLength = 0
        Me.textboxFechaHoraModificacion.Name = "textboxFechaHoraModificacion"
        Me.textboxFechaHoraModificacion.ReadOnly = True
        Me.textboxFechaHoraModificacion.Size = New System.Drawing.Size(160, 22)
        Me.textboxFechaHoraModificacion.TabIndex = 13
        '
        'textboxFechaHoraCreacion
        '
        Me.textboxFechaHoraCreacion.Location = New System.Drawing.Point(152, 206)
        Me.textboxFechaHoraCreacion.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxFechaHoraCreacion.MaxLength = 0
        Me.textboxFechaHoraCreacion.Name = "textboxFechaHoraCreacion"
        Me.textboxFechaHoraCreacion.ReadOnly = True
        Me.textboxFechaHoraCreacion.Size = New System.Drawing.Size(160, 22)
        Me.textboxFechaHoraCreacion.TabIndex = 10
        '
        'checkboxVerificarEmail1
        '
        Me.checkboxVerificarEmail1.AutoSize = True
        Me.checkboxVerificarEmail1.Location = New System.Drawing.Point(303, 89)
        Me.checkboxVerificarEmail1.Name = "checkboxVerificarEmail1"
        Me.checkboxVerificarEmail1.Size = New System.Drawing.Size(18, 17)
        Me.checkboxVerificarEmail1.TabIndex = 8
        Me.checkboxVerificarEmail1.TabStop = False
        Me.tooltipMain.SetToolTip(Me.checkboxVerificarEmail1, "Verificar")
        Me.checkboxVerificarEmail1.UseVisualStyleBackColor = True
        '
        'checkboxVerificarEmail2
        '
        Me.checkboxVerificarEmail2.AutoSize = True
        Me.checkboxVerificarEmail2.Location = New System.Drawing.Point(647, 89)
        Me.checkboxVerificarEmail2.Name = "checkboxVerificarEmail2"
        Me.checkboxVerificarEmail2.Size = New System.Drawing.Size(18, 17)
        Me.checkboxVerificarEmail2.TabIndex = 10
        Me.checkboxVerificarEmail2.TabStop = False
        Me.tooltipMain.SetToolTip(Me.checkboxVerificarEmail2, "Verificar")
        Me.checkboxVerificarEmail2.UseVisualStyleBackColor = True
        '
        'formEntidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(719, 545)
        Me.Controls.Add(Me.checkboxEsActivo)
        Me.Controls.Add(labelEsActivo)
        Me.Controls.Add(Me.toolstripMain)
        Me.Controls.Add(Me.tabcontrolMain)
        Me.Controls.Add(Me.pictureboxMain)
        Me.Controls.Add(labelApellido)
        Me.Controls.Add(Me.textboxApellido)
        Me.Controls.Add(labelIDEntidad)
        Me.Controls.Add(Me.textboxIDEntidad)
        Me.Controls.Add(labelNombre)
        Me.Controls.Add(Me.textboxNombre)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.Name = "formEntidad"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Detalle de la Entidad"
        CType(Me.pictureboxMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.tabcontrolMain.ResumeLayout(False)
        Me.tabpageGeneral.ResumeLayout(False)
        Me.tabpageGeneral.PerformLayout()
        Me.tabpageContacto.ResumeLayout(False)
        Me.tabpageContacto.PerformLayout()
        Me.tabpagePadresYFacturacion.ResumeLayout(False)
        Me.tabpagePadresYFacturacion.PerformLayout()
        Me.panelEntidadTercero.ResumeLayout(False)
        Me.panelEntidadTercero.PerformLayout()
        Me.panelEntidadMadre.ResumeLayout(False)
        Me.panelEntidadMadre.PerformLayout()
        Me.panelEntidadPadre.ResumeLayout(False)
        Me.panelEntidadPadre.PerformLayout()
        Me.tabpageDebitoAutomatico.ResumeLayout(False)
        Me.tabpageDebitoAutomatico.PerformLayout()
        Me.tabpageCursosAsistidos.ResumeLayout(False)
        CType(Me.datagridviewCursosAsistidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpageHijos.ResumeLayout(False)
        CType(Me.datagridviewHijos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpageComprobantes.ResumeLayout(False)
        CType(Me.datagridviewComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpageRelaciones.ResumeLayout(False)
        CType(Me.datagridviewRelaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpageNotasAuditoria.ResumeLayout(False)
        Me.tabpageNotasAuditoria.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textboxApellido As System.Windows.Forms.TextBox
    Friend WithEvents textboxIDEntidad As System.Windows.Forms.TextBox
    Friend WithEvents textboxNombre As System.Windows.Forms.TextBox
    Friend WithEvents pictureboxMain As System.Windows.Forms.PictureBox
    Friend WithEvents tabpageGeneral As System.Windows.Forms.TabPage
    Friend WithEvents tabpageContacto As System.Windows.Forms.TabPage
    Friend WithEvents textboxDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents comboboxDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents comboboxGenero As System.Windows.Forms.ComboBox
    Friend WithEvents datetimepickerFechaNacimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents comboboxCategoriaIVA As System.Windows.Forms.ComboBox
    Friend WithEvents textboxDomicilioCalle1 As System.Windows.Forms.TextBox
    Friend WithEvents textboxDomicilioCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents textboxDomicilioDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents textboxDomicilioNumero As System.Windows.Forms.TextBox
    Friend WithEvents textboxDomicilioPiso As System.Windows.Forms.TextBox
    Friend WithEvents textboxEmail1 As System.Windows.Forms.TextBox
    Friend WithEvents textboxEmail2 As System.Windows.Forms.TextBox
    Friend WithEvents textboxTelefono1 As System.Windows.Forms.TextBox
    Friend WithEvents textboxTelefono2 As System.Windows.Forms.TextBox
    Friend WithEvents textboxTelefono3 As System.Windows.Forms.TextBox
    Friend WithEvents tabpagePadresYFacturacion As System.Windows.Forms.TabPage
    Friend WithEvents comboboxDomicilioProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents comboboxDomicilioLocalidad As System.Windows.Forms.ComboBox
    Friend WithEvents checkboxTipoAlumno As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxTipoDocente As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxTipoFamiliar As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxTipoPersonalColegio As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxTipoProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents textboxDomicilioCalle3 As System.Windows.Forms.TextBox
    Friend WithEvents textboxDomicilioCalle2 As System.Windows.Forms.TextBox
    Friend WithEvents tabpageHijos As System.Windows.Forms.TabPage
    Friend WithEvents datagridviewHijos As System.Windows.Forms.DataGridView
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabpageRelaciones As System.Windows.Forms.TabPage
    Friend WithEvents datagridviewRelaciones As System.Windows.Forms.DataGridView
    Friend WithEvents tooltipMain As System.Windows.Forms.ToolTip
    Friend WithEvents maskedtextboxDocumentoNumero As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tabpageCursosAsistidos As System.Windows.Forms.TabPage
    Friend WithEvents datagridviewCursosAsistidos As System.Windows.Forms.DataGridView
    Friend WithEvents columnPadresIDEntidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPadresApellido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPadresNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPadresRelacionTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents labelEntidadPadre As System.Windows.Forms.Label
    Friend WithEvents panelEntidadPadre As System.Windows.Forms.Panel
    Friend WithEvents buttonEntidadPadreBorrar As System.Windows.Forms.Button
    Friend WithEvents buttonEntidadPadre As System.Windows.Forms.Button
    Friend WithEvents textboxEntidadPadre As System.Windows.Forms.TextBox
    Friend WithEvents labelEntidadMadre As System.Windows.Forms.Label
    Friend WithEvents panelEntidadMadre As System.Windows.Forms.Panel
    Friend WithEvents buttonEntidadMadreBorrar As System.Windows.Forms.Button
    Friend WithEvents buttonEntidadMadre As System.Windows.Forms.Button
    Friend WithEvents textboxEntidadMadre As System.Windows.Forms.TextBox
    Friend WithEvents comboboxEmitirFacturaA As System.Windows.Forms.ComboBox
    Friend WithEvents labelEmitirFacturaA As System.Windows.Forms.Label
    Friend WithEvents tabpageNotasAuditoria As System.Windows.Forms.TabPage
    Friend WithEvents textboxUsuarioModificacion As System.Windows.Forms.TextBox
    Friend WithEvents textboxUsuarioCreacion As System.Windows.Forms.TextBox
    Friend WithEvents textboxFechaHoraModificacion As System.Windows.Forms.TextBox
    Friend WithEvents textboxFechaHoraCreacion As System.Windows.Forms.TextBox
    Friend WithEvents columnHijosIDEntidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnHijosApellido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnHijosNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnAnioLectivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNivelNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnAnioNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnTurnoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnDivision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents labelTipoProveedor As System.Windows.Forms.Label
    Friend WithEvents labelTipoFamiliar As System.Windows.Forms.Label
    Friend WithEvents labelTipoAlumno As System.Windows.Forms.Label
    Friend WithEvents labelTipoDocente As System.Windows.Forms.Label
    Friend WithEvents labelTipoPersonalColegio As System.Windows.Forms.Label
	Friend WithEvents labelDebitoAutomatico_CBU As System.Windows.Forms.Label
    Friend WithEvents comboboxDescuento As System.Windows.Forms.ComboBox
    Friend WithEvents checkboxEsActivo As System.Windows.Forms.CheckBox
    Friend WithEvents comboboxFacturaDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents textboxFacturaDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents maskedtextboxFacturaDocumentoNumero As System.Windows.Forms.MaskedTextBox
    Friend WithEvents textboxNotas As System.Windows.Forms.TextBox
    Friend WithEvents datetimepickerExcluyeFacturaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents datetimepickerExcluyeFacturaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents panelEntidadTercero As System.Windows.Forms.Panel
    Friend WithEvents buttonEntidadTerceroBorrar As System.Windows.Forms.Button
    Friend WithEvents buttonEntidadTercero As System.Windows.Forms.Button
    Friend WithEvents textboxEntidadTercero As System.Windows.Forms.TextBox
    Friend WithEvents labelEntidadTercero As System.Windows.Forms.Label
    Friend WithEvents checkboxFacturaIndividual As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxExcluyeCalculoInteres As System.Windows.Forms.CheckBox
    Friend WithEvents textboxFacturaLeyenda As System.Windows.Forms.TextBox
    Friend WithEvents tabpageComprobantes As System.Windows.Forms.TabPage
    Friend WithEvents tabcontrolMain As CSColegio.DesktopApplication.CS_Control_TabControl
    Friend WithEvents datagridviewComprobantes As System.Windows.Forms.DataGridView
    Friend WithEvents columnTipoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNumeroCompleto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comboboxComprobanteEnviarEmail As ComboBox
    Friend WithEvents tabpageDebitoAutomatico As System.Windows.Forms.TabPage
    Friend WithEvents radiobuttonDebitoAutomatico_Tipo_DebitoDirecto As System.Windows.Forms.RadioButton
    Friend WithEvents radiobuttonDebitoAutomatico_Tipo_Ninguno As System.Windows.Forms.RadioButton
    Friend WithEvents radiobuttonDebitoAutomatico_Tipo_TarjetaCredito As System.Windows.Forms.RadioButton
    Friend WithEvents maskedtextboxDebitoAutomatico_CBU As System.Windows.Forms.MaskedTextBox
    Friend WithEvents checkboxVerificarEmail2 As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxVerificarEmail1 As System.Windows.Forms.CheckBox
End Class
