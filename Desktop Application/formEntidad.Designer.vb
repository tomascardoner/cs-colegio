<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formEntidad
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                dbcontext.Dispose()
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
        Dim labelDocumento As System.Windows.Forms.Label
        Dim labelGenero As System.Windows.Forms.Label
        Dim labelFechaNacimiento As System.Windows.Forms.Label
        Dim labelCategoriaIVA As System.Windows.Forms.Label
        Dim labelTelefono1 As System.Windows.Forms.Label
        Dim labelTelefono2 As System.Windows.Forms.Label
        Dim labelTelefono3 As System.Windows.Forms.Label
        Dim labelEmail1 As System.Windows.Forms.Label
        Dim labelEmail2 As System.Windows.Forms.Label
        Dim labelDomicilioCalle1 As System.Windows.Forms.Label
        Dim labelDomicilioCodigoPostal As System.Windows.Forms.Label
        Dim labelDomicilioDepartamento As System.Windows.Forms.Label
        Dim labelDomicilioLocalidad As System.Windows.Forms.Label
        Dim labelDomicilioProvincia As System.Windows.Forms.Label
        Dim labelDomicilioNumero As System.Windows.Forms.Label
        Dim labelDomicilioPiso As System.Windows.Forms.Label
        Dim labelTipo As System.Windows.Forms.Label
        Dim labelDomicilioCalle2 As System.Windows.Forms.Label
        Dim labelDomicilioCalle3 As System.Windows.Forms.Label
        Dim labelModificacion As System.Windows.Forms.Label
        Dim labelCreacion As System.Windows.Forms.Label
        Dim labelDescuento As System.Windows.Forms.Label
        Dim labelEsActivo As System.Windows.Forms.Label
        Dim labelFacturaDocumento As System.Windows.Forms.Label
        Dim labelNotas As System.Windows.Forms.Label
        Dim labelExcluyeFacturaDesde As System.Windows.Forms.Label
        Dim labelExcluyeFacturaHasta As System.Windows.Forms.Label
        Dim labelExcluyeCalculoInteres As System.Windows.Forms.Label
        Dim labelFacturaIndividual As System.Windows.Forms.Label
        Dim labelVarios As System.Windows.Forms.Label
        Dim labelFacturaLeyenda As System.Windows.Forms.Label
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formEntidad))
        Me.textboxApellido = New System.Windows.Forms.TextBox()
        Me.textboxIDEntidad = New System.Windows.Forms.TextBox()
        Me.textboxNombre = New System.Windows.Forms.TextBox()
        Me.pictureboxMain = New System.Windows.Forms.PictureBox()
        Me.tabcontrolMain = New System.Windows.Forms.TabControl()
        Me.tabpageGeneral = New System.Windows.Forms.TabPage()
        Me.comboboxFacturaDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.textboxFacturaDocumentoNumero = New System.Windows.Forms.TextBox()
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
        Me.textboxDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.maskedtextboxDocumentoNumero = New System.Windows.Forms.MaskedTextBox()
        Me.maskedtextboxFacturaDocumentoNumero = New System.Windows.Forms.MaskedTextBox()
        Me.tabpageContacto = New System.Windows.Forms.TabPage()
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
        Me.tabpageExtra = New System.Windows.Forms.TabPage()
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
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.tooltipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.checkboxEsActivo = New System.Windows.Forms.CheckBox()
        labelApellido = New System.Windows.Forms.Label()
        labelIDEntidad = New System.Windows.Forms.Label()
        labelNombre = New System.Windows.Forms.Label()
        labelDocumento = New System.Windows.Forms.Label()
        labelGenero = New System.Windows.Forms.Label()
        labelFechaNacimiento = New System.Windows.Forms.Label()
        labelCategoriaIVA = New System.Windows.Forms.Label()
        labelTelefono1 = New System.Windows.Forms.Label()
        labelTelefono2 = New System.Windows.Forms.Label()
        labelTelefono3 = New System.Windows.Forms.Label()
        labelEmail1 = New System.Windows.Forms.Label()
        labelEmail2 = New System.Windows.Forms.Label()
        labelDomicilioCalle1 = New System.Windows.Forms.Label()
        labelDomicilioCodigoPostal = New System.Windows.Forms.Label()
        labelDomicilioDepartamento = New System.Windows.Forms.Label()
        labelDomicilioLocalidad = New System.Windows.Forms.Label()
        labelDomicilioProvincia = New System.Windows.Forms.Label()
        labelDomicilioNumero = New System.Windows.Forms.Label()
        labelDomicilioPiso = New System.Windows.Forms.Label()
        labelTipo = New System.Windows.Forms.Label()
        labelDomicilioCalle2 = New System.Windows.Forms.Label()
        labelDomicilioCalle3 = New System.Windows.Forms.Label()
        labelModificacion = New System.Windows.Forms.Label()
        labelCreacion = New System.Windows.Forms.Label()
        labelDescuento = New System.Windows.Forms.Label()
        labelEsActivo = New System.Windows.Forms.Label()
        labelFacturaDocumento = New System.Windows.Forms.Label()
        labelNotas = New System.Windows.Forms.Label()
        labelExcluyeFacturaDesde = New System.Windows.Forms.Label()
        labelExcluyeFacturaHasta = New System.Windows.Forms.Label()
        labelExcluyeCalculoInteres = New System.Windows.Forms.Label()
        labelFacturaIndividual = New System.Windows.Forms.Label()
        labelVarios = New System.Windows.Forms.Label()
        labelFacturaLeyenda = New System.Windows.Forms.Label()
        CType(Me.pictureboxMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabcontrolMain.SuspendLayout()
        Me.tabpageGeneral.SuspendLayout()
        Me.tabpageContacto.SuspendLayout()
        Me.tabpageExtra.SuspendLayout()
        Me.panelEntidadTercero.SuspendLayout()
        Me.panelEntidadMadre.SuspendLayout()
        Me.panelEntidadPadre.SuspendLayout()
        Me.tabpageCursosAsistidos.SuspendLayout()
        CType(Me.datagridviewCursosAsistidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpageHijos.SuspendLayout()
        CType(Me.datagridviewHijos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpageRelaciones.SuspendLayout()
        CType(Me.datagridviewRelaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpageNotasAuditoria.SuspendLayout()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelApellido
        '
        labelApellido.AutoSize = True
        labelApellido.Location = New System.Drawing.Point(75, 80)
        labelApellido.Name = "labelApellido"
        labelApellido.Size = New System.Drawing.Size(52, 13)
        labelApellido.TabIndex = 3
        labelApellido.Text = "Apellidos:"
        '
        'labelIDEntidad
        '
        labelIDEntidad.AutoSize = True
        labelIDEntidad.Location = New System.Drawing.Point(73, 52)
        labelIDEntidad.Name = "labelIDEntidad"
        labelIDEntidad.Size = New System.Drawing.Size(76, 13)
        labelIDEntidad.TabIndex = 1
        labelIDEntidad.Text = "N° de Entidad:"
        '
        'labelNombre
        '
        labelNombre.AutoSize = True
        labelNombre.Location = New System.Drawing.Point(75, 108)
        labelNombre.Name = "labelNombre"
        labelNombre.Size = New System.Drawing.Size(52, 13)
        labelNombre.TabIndex = 5
        labelNombre.Text = "Nombres:"
        '
        'labelDocumento
        '
        labelDocumento.AutoSize = True
        labelDocumento.Location = New System.Drawing.Point(6, 40)
        labelDocumento.Name = "labelDocumento"
        labelDocumento.Size = New System.Drawing.Size(65, 13)
        labelDocumento.TabIndex = 11
        labelDocumento.Text = "Documento:"
        Me.tooltipMain.SetToolTip(labelDocumento, "Ingrese el Número de Documento sin utilizar puntos.")
        '
        'labelGenero
        '
        labelGenero.AutoSize = True
        labelGenero.Location = New System.Drawing.Point(6, 94)
        labelGenero.Name = "labelGenero"
        labelGenero.Size = New System.Drawing.Size(45, 13)
        labelGenero.TabIndex = 19
        labelGenero.Text = "Género:"
        '
        'labelFechaNacimiento
        '
        labelFechaNacimiento.AutoSize = True
        labelFechaNacimiento.Location = New System.Drawing.Point(6, 123)
        labelFechaNacimiento.Name = "labelFechaNacimiento"
        labelFechaNacimiento.Size = New System.Drawing.Size(111, 13)
        labelFechaNacimiento.TabIndex = 21
        labelFechaNacimiento.Text = "Fecha de Nacimiento:"
        '
        'labelCategoriaIVA
        '
        labelCategoriaIVA.AutoSize = True
        labelCategoriaIVA.Location = New System.Drawing.Point(6, 149)
        labelCategoriaIVA.Name = "labelCategoriaIVA"
        labelCategoriaIVA.Size = New System.Drawing.Size(92, 13)
        labelCategoriaIVA.TabIndex = 23
        labelCategoriaIVA.Text = "Categoría de IVA:"
        '
        'labelTelefono1
        '
        labelTelefono1.AutoSize = True
        labelTelefono1.Location = New System.Drawing.Point(6, 10)
        labelTelefono1.Name = "labelTelefono1"
        labelTelefono1.Size = New System.Drawing.Size(58, 13)
        labelTelefono1.TabIndex = 0
        labelTelefono1.Text = "Teléfono1:"
        '
        'labelTelefono2
        '
        labelTelefono2.AutoSize = True
        labelTelefono2.Location = New System.Drawing.Point(266, 10)
        labelTelefono2.Name = "labelTelefono2"
        labelTelefono2.Size = New System.Drawing.Size(58, 13)
        labelTelefono2.TabIndex = 2
        labelTelefono2.Text = "Teléfono2:"
        '
        'labelTelefono3
        '
        labelTelefono3.AutoSize = True
        labelTelefono3.Location = New System.Drawing.Point(6, 36)
        labelTelefono3.Name = "labelTelefono3"
        labelTelefono3.Size = New System.Drawing.Size(58, 13)
        labelTelefono3.TabIndex = 4
        labelTelefono3.Text = "Teléfono3:"
        '
        'labelEmail1
        '
        labelEmail1.AutoSize = True
        labelEmail1.Location = New System.Drawing.Point(6, 62)
        labelEmail1.Name = "labelEmail1"
        labelEmail1.Size = New System.Drawing.Size(47, 13)
        labelEmail1.TabIndex = 6
        labelEmail1.Text = "E-mail 1:"
        '
        'labelEmail2
        '
        labelEmail2.AutoSize = True
        labelEmail2.Location = New System.Drawing.Point(266, 62)
        labelEmail2.Name = "labelEmail2"
        labelEmail2.Size = New System.Drawing.Size(47, 13)
        labelEmail2.TabIndex = 8
        labelEmail2.Text = "E-mail 2:"
        '
        'labelDomicilioCalle1
        '
        labelDomicilioCalle1.AutoSize = True
        labelDomicilioCalle1.Location = New System.Drawing.Point(6, 88)
        labelDomicilioCalle1.Name = "labelDomicilioCalle1"
        labelDomicilioCalle1.Size = New System.Drawing.Size(33, 13)
        labelDomicilioCalle1.TabIndex = 10
        labelDomicilioCalle1.Text = "Calle:"
        '
        'labelDomicilioCodigoPostal
        '
        labelDomicilioCodigoPostal.AutoSize = True
        labelDomicilioCodigoPostal.Location = New System.Drawing.Point(384, 193)
        labelDomicilioCodigoPostal.Name = "labelDomicilioCodigoPostal"
        labelDomicilioCodigoPostal.Size = New System.Drawing.Size(59, 13)
        labelDomicilioCodigoPostal.TabIndex = 26
        labelDomicilioCodigoPostal.Text = "Cód. Post.:"
        '
        'labelDomicilioDepartamento
        '
        labelDomicilioDepartamento.AutoSize = True
        labelDomicilioDepartamento.Location = New System.Drawing.Point(220, 114)
        labelDomicilioDepartamento.Name = "labelDomicilioDepartamento"
        labelDomicilioDepartamento.Size = New System.Drawing.Size(54, 13)
        labelDomicilioDepartamento.TabIndex = 16
        labelDomicilioDepartamento.Text = "Dto/Ofic.:"
        '
        'labelDomicilioLocalidad
        '
        labelDomicilioLocalidad.AutoSize = True
        labelDomicilioLocalidad.Location = New System.Drawing.Point(6, 193)
        labelDomicilioLocalidad.Name = "labelDomicilioLocalidad"
        labelDomicilioLocalidad.Size = New System.Drawing.Size(56, 13)
        labelDomicilioLocalidad.TabIndex = 24
        labelDomicilioLocalidad.Text = "Localidad:"
        '
        'labelDomicilioProvincia
        '
        labelDomicilioProvincia.AutoSize = True
        labelDomicilioProvincia.Location = New System.Drawing.Point(6, 166)
        labelDomicilioProvincia.Name = "labelDomicilioProvincia"
        labelDomicilioProvincia.Size = New System.Drawing.Size(54, 13)
        labelDomicilioProvincia.TabIndex = 22
        labelDomicilioProvincia.Text = "Provincia:"
        '
        'labelDomicilioNumero
        '
        labelDomicilioNumero.AutoSize = True
        labelDomicilioNumero.Location = New System.Drawing.Point(6, 114)
        labelDomicilioNumero.Name = "labelDomicilioNumero"
        labelDomicilioNumero.Size = New System.Drawing.Size(47, 13)
        labelDomicilioNumero.TabIndex = 12
        labelDomicilioNumero.Text = "Número:"
        '
        'labelDomicilioPiso
        '
        labelDomicilioPiso.AutoSize = True
        labelDomicilioPiso.Location = New System.Drawing.Point(128, 114)
        labelDomicilioPiso.Name = "labelDomicilioPiso"
        labelDomicilioPiso.Size = New System.Drawing.Size(30, 13)
        labelDomicilioPiso.TabIndex = 14
        labelDomicilioPiso.Text = "Piso:"
        '
        'labelTipo
        '
        labelTipo.AutoSize = True
        labelTipo.Location = New System.Drawing.Point(6, 10)
        labelTipo.Name = "labelTipo"
        labelTipo.Size = New System.Drawing.Size(31, 13)
        labelTipo.TabIndex = 0
        labelTipo.Text = "Tipo:"
        '
        'labelDomicilioCalle2
        '
        labelDomicilioCalle2.AutoSize = True
        labelDomicilioCalle2.Location = New System.Drawing.Point(6, 140)
        labelDomicilioCalle2.Name = "labelDomicilioCalle2"
        labelDomicilioCalle2.Size = New System.Drawing.Size(42, 13)
        labelDomicilioCalle2.TabIndex = 18
        labelDomicilioCalle2.Text = "Calle 2:"
        '
        'labelDomicilioCalle3
        '
        labelDomicilioCalle3.AutoSize = True
        labelDomicilioCalle3.Location = New System.Drawing.Point(266, 140)
        labelDomicilioCalle3.Name = "labelDomicilioCalle3"
        labelDomicilioCalle3.Size = New System.Drawing.Size(42, 13)
        labelDomicilioCalle3.TabIndex = 20
        labelDomicilioCalle3.Text = "Calle 3:"
        '
        'labelModificacion
        '
        labelModificacion.AutoSize = True
        labelModificacion.Location = New System.Drawing.Point(6, 196)
        labelModificacion.Name = "labelModificacion"
        labelModificacion.Size = New System.Drawing.Size(102, 13)
        labelModificacion.TabIndex = 12
        labelModificacion.Text = "Ultima Modificación:"
        '
        'labelCreacion
        '
        labelCreacion.AutoSize = True
        labelCreacion.Location = New System.Drawing.Point(6, 174)
        labelCreacion.Name = "labelCreacion"
        labelCreacion.Size = New System.Drawing.Size(52, 13)
        labelCreacion.TabIndex = 9
        labelCreacion.Text = "Creación:"
        '
        'labelDescuento
        '
        labelDescuento.AutoSize = True
        labelDescuento.Location = New System.Drawing.Point(6, 122)
        labelDescuento.Name = "labelDescuento"
        labelDescuento.Size = New System.Drawing.Size(62, 13)
        labelDescuento.TabIndex = 8
        labelDescuento.Text = "Descuento:"
        '
        'labelEsActivo
        '
        labelEsActivo.AutoSize = True
        labelEsActivo.Location = New System.Drawing.Point(273, 52)
        labelEsActivo.Name = "labelEsActivo"
        labelEsActivo.Size = New System.Drawing.Size(40, 13)
        labelEsActivo.TabIndex = 94
        labelEsActivo.Text = "Activo:"
        '
        'labelFacturaDocumento
        '
        labelFacturaDocumento.AutoSize = True
        labelFacturaDocumento.Location = New System.Drawing.Point(6, 67)
        labelFacturaDocumento.Name = "labelFacturaDocumento"
        labelFacturaDocumento.Size = New System.Drawing.Size(131, 13)
        labelFacturaDocumento.TabIndex = 15
        labelFacturaDocumento.Text = "Documento para Facturar:"
        Me.tooltipMain.SetToolTip(labelFacturaDocumento, "Ingrese el Número de Documento sin utilizar puntos.")
        '
        'labelNotas
        '
        labelNotas.AutoSize = True
        labelNotas.Location = New System.Drawing.Point(6, 9)
        labelNotas.Name = "labelNotas"
        labelNotas.Size = New System.Drawing.Size(38, 13)
        labelNotas.TabIndex = 15
        labelNotas.Text = "Notas:"
        '
        'labelExcluyeFacturaDesde
        '
        labelExcluyeFacturaDesde.AutoSize = True
        labelExcluyeFacturaDesde.Location = New System.Drawing.Point(6, 174)
        labelExcluyeFacturaDesde.Name = "labelExcluyeFacturaDesde"
        labelExcluyeFacturaDesde.Size = New System.Drawing.Size(95, 13)
        labelExcluyeFacturaDesde.TabIndex = 15
        labelExcluyeFacturaDesde.Text = "No facturar desde:"
        '
        'labelExcluyeFacturaHasta
        '
        labelExcluyeFacturaHasta.AutoSize = True
        labelExcluyeFacturaHasta.Location = New System.Drawing.Point(261, 172)
        labelExcluyeFacturaHasta.Name = "labelExcluyeFacturaHasta"
        labelExcluyeFacturaHasta.Size = New System.Drawing.Size(36, 13)
        labelExcluyeFacturaHasta.TabIndex = 17
        labelExcluyeFacturaHasta.Text = "hasta:"
        '
        'labelExcluyeCalculoInteres
        '
        labelExcluyeCalculoInteres.AutoSize = True
        labelExcluyeCalculoInteres.Location = New System.Drawing.Point(128, 148)
        labelExcluyeCalculoInteres.Name = "labelExcluyeCalculoInteres"
        labelExcluyeCalculoInteres.Size = New System.Drawing.Size(152, 13)
        labelExcluyeCalculoInteres.TabIndex = 12
        labelExcluyeCalculoInteres.Text = "Excluir del cálculo de intereses"
        '
        'labelFacturaIndividual
        '
        labelFacturaIndividual.AutoSize = True
        labelFacturaIndividual.Location = New System.Drawing.Point(349, 148)
        labelFacturaIndividual.Name = "labelFacturaIndividual"
        labelFacturaIndividual.Size = New System.Drawing.Size(115, 13)
        labelFacturaIndividual.TabIndex = 14
        labelFacturaIndividual.Text = "Emitir factura individual"
        '
        'labelVarios
        '
        labelVarios.AutoSize = True
        labelVarios.Location = New System.Drawing.Point(6, 148)
        labelVarios.Name = "labelVarios"
        labelVarios.Size = New System.Drawing.Size(39, 13)
        labelVarios.TabIndex = 10
        labelVarios.Text = "Varios:"
        '
        'labelFacturaLeyenda
        '
        labelFacturaLeyenda.AutoSize = True
        labelFacturaLeyenda.Location = New System.Drawing.Point(6, 198)
        labelFacturaLeyenda.Name = "labelFacturaLeyenda"
        labelFacturaLeyenda.Size = New System.Drawing.Size(51, 13)
        labelFacturaLeyenda.TabIndex = 19
        labelFacturaLeyenda.Text = "Leyenda:"
        '
        'textboxApellido
        '
        Me.textboxApellido.Location = New System.Drawing.Point(155, 77)
        Me.textboxApellido.MaxLength = 100
        Me.textboxApellido.Name = "textboxApellido"
        Me.textboxApellido.Size = New System.Drawing.Size(371, 20)
        Me.textboxApellido.TabIndex = 4
        '
        'textboxIDEntidad
        '
        Me.textboxIDEntidad.Location = New System.Drawing.Point(155, 49)
        Me.textboxIDEntidad.MaxLength = 10
        Me.textboxIDEntidad.Name = "textboxIDEntidad"
        Me.textboxIDEntidad.ReadOnly = True
        Me.textboxIDEntidad.Size = New System.Drawing.Size(72, 20)
        Me.textboxIDEntidad.TabIndex = 2
        Me.textboxIDEntidad.TabStop = False
        Me.textboxIDEntidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'textboxNombre
        '
        Me.textboxNombre.Location = New System.Drawing.Point(155, 103)
        Me.textboxNombre.MaxLength = 50
        Me.textboxNombre.Name = "textboxNombre"
        Me.textboxNombre.Size = New System.Drawing.Size(239, 20)
        Me.textboxNombre.TabIndex = 6
        '
        'pictureboxMain
        '
        Me.pictureboxMain.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ENTIDAD_48
        Me.pictureboxMain.Location = New System.Drawing.Point(12, 49)
        Me.pictureboxMain.Name = "pictureboxMain"
        Me.pictureboxMain.Size = New System.Drawing.Size(48, 48)
        Me.pictureboxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureboxMain.TabIndex = 93
        Me.pictureboxMain.TabStop = False
        '
        'tabcontrolMain
        '
        Me.tabcontrolMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabcontrolMain.Controls.Add(Me.tabpageGeneral)
        Me.tabcontrolMain.Controls.Add(Me.tabpageContacto)
        Me.tabcontrolMain.Controls.Add(Me.tabpageExtra)
        Me.tabcontrolMain.Controls.Add(Me.tabpageCursosAsistidos)
        Me.tabcontrolMain.Controls.Add(Me.tabpageHijos)
        Me.tabcontrolMain.Controls.Add(Me.tabpageRelaciones)
        Me.tabcontrolMain.Controls.Add(Me.tabpageNotasAuditoria)
        Me.tabcontrolMain.Location = New System.Drawing.Point(12, 138)
        Me.tabcontrolMain.Name = "tabcontrolMain"
        Me.tabcontrolMain.SelectedIndex = 0
        Me.tabcontrolMain.Size = New System.Drawing.Size(514, 252)
        Me.tabcontrolMain.TabIndex = 7
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
        Me.tabpageGeneral.Location = New System.Drawing.Point(4, 25)
        Me.tabpageGeneral.Name = "tabpageGeneral"
        Me.tabpageGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageGeneral.Size = New System.Drawing.Size(506, 223)
        Me.tabpageGeneral.TabIndex = 0
        Me.tabpageGeneral.Text = "General"
        Me.tabpageGeneral.UseVisualStyleBackColor = True
        '
        'comboboxFacturaDocumentoTipo
        '
        Me.comboboxFacturaDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxFacturaDocumentoTipo.FormattingEnabled = True
        Me.comboboxFacturaDocumentoTipo.Location = New System.Drawing.Point(142, 63)
        Me.comboboxFacturaDocumentoTipo.Name = "comboboxFacturaDocumentoTipo"
        Me.comboboxFacturaDocumentoTipo.Size = New System.Drawing.Size(102, 21)
        Me.comboboxFacturaDocumentoTipo.TabIndex = 16
        '
        'textboxFacturaDocumentoNumero
        '
        Me.textboxFacturaDocumentoNumero.Location = New System.Drawing.Point(250, 64)
        Me.textboxFacturaDocumentoNumero.MaxLength = 11
        Me.textboxFacturaDocumentoNumero.Name = "textboxFacturaDocumentoNumero"
        Me.textboxFacturaDocumentoNumero.Size = New System.Drawing.Size(115, 20)
        Me.textboxFacturaDocumentoNumero.TabIndex = 17
        Me.tooltipMain.SetToolTip(Me.textboxFacturaDocumentoNumero, "Ingrese el Número de Documento sin utilizar puntos.")
        '
        'labelTipoProveedor
        '
        Me.labelTipoProveedor.AutoSize = True
        Me.labelTipoProveedor.Location = New System.Drawing.Point(435, 9)
        Me.labelTipoProveedor.Name = "labelTipoProveedor"
        Me.labelTipoProveedor.Size = New System.Drawing.Size(56, 13)
        Me.labelTipoProveedor.TabIndex = 10
        Me.labelTipoProveedor.Text = "Proveedor"
        '
        'labelTipoFamiliar
        '
        Me.labelTipoFamiliar.AutoSize = True
        Me.labelTipoFamiliar.Location = New System.Drawing.Point(365, 9)
        Me.labelTipoFamiliar.Name = "labelTipoFamiliar"
        Me.labelTipoFamiliar.Size = New System.Drawing.Size(42, 13)
        Me.labelTipoFamiliar.TabIndex = 8
        Me.labelTipoFamiliar.Text = "Familiar"
        '
        'labelTipoAlumno
        '
        Me.labelTipoAlumno.AutoSize = True
        Me.labelTipoAlumno.Location = New System.Drawing.Point(295, 9)
        Me.labelTipoAlumno.Name = "labelTipoAlumno"
        Me.labelTipoAlumno.Size = New System.Drawing.Size(42, 13)
        Me.labelTipoAlumno.TabIndex = 6
        Me.labelTipoAlumno.Text = "Alumno"
        '
        'labelTipoDocente
        '
        Me.labelTipoDocente.AutoSize = True
        Me.labelTipoDocente.Location = New System.Drawing.Point(219, 9)
        Me.labelTipoDocente.Name = "labelTipoDocente"
        Me.labelTipoDocente.Size = New System.Drawing.Size(48, 13)
        Me.labelTipoDocente.TabIndex = 4
        Me.labelTipoDocente.Text = "Docente"
        '
        'labelTipoPersonalColegio
        '
        Me.labelTipoPersonalColegio.AutoSize = True
        Me.labelTipoPersonalColegio.Location = New System.Drawing.Point(105, 9)
        Me.labelTipoPersonalColegio.Name = "labelTipoPersonalColegio"
        Me.labelTipoPersonalColegio.Size = New System.Drawing.Size(86, 13)
        Me.labelTipoPersonalColegio.TabIndex = 2
        Me.labelTipoPersonalColegio.Text = "Personal Colegio"
        '
        'checkboxTipoAlumno
        '
        Me.checkboxTipoAlumno.AutoSize = True
        Me.checkboxTipoAlumno.Location = New System.Drawing.Point(280, 9)
        Me.checkboxTipoAlumno.Name = "checkboxTipoAlumno"
        Me.checkboxTipoAlumno.Size = New System.Drawing.Size(15, 14)
        Me.checkboxTipoAlumno.TabIndex = 5
        Me.checkboxTipoAlumno.UseVisualStyleBackColor = True
        '
        'checkboxTipoDocente
        '
        Me.checkboxTipoDocente.AutoSize = True
        Me.checkboxTipoDocente.Location = New System.Drawing.Point(204, 9)
        Me.checkboxTipoDocente.Name = "checkboxTipoDocente"
        Me.checkboxTipoDocente.Size = New System.Drawing.Size(15, 14)
        Me.checkboxTipoDocente.TabIndex = 3
        Me.checkboxTipoDocente.UseVisualStyleBackColor = True
        '
        'checkboxTipoFamiliar
        '
        Me.checkboxTipoFamiliar.AutoSize = True
        Me.checkboxTipoFamiliar.Location = New System.Drawing.Point(350, 9)
        Me.checkboxTipoFamiliar.Name = "checkboxTipoFamiliar"
        Me.checkboxTipoFamiliar.Size = New System.Drawing.Size(15, 14)
        Me.checkboxTipoFamiliar.TabIndex = 7
        Me.checkboxTipoFamiliar.UseVisualStyleBackColor = True
        '
        'checkboxTipoPersonalColegio
        '
        Me.checkboxTipoPersonalColegio.AutoSize = True
        Me.checkboxTipoPersonalColegio.Location = New System.Drawing.Point(90, 9)
        Me.checkboxTipoPersonalColegio.Name = "checkboxTipoPersonalColegio"
        Me.checkboxTipoPersonalColegio.Size = New System.Drawing.Size(15, 14)
        Me.checkboxTipoPersonalColegio.TabIndex = 1
        Me.checkboxTipoPersonalColegio.UseVisualStyleBackColor = True
        '
        'checkboxTipoProveedor
        '
        Me.checkboxTipoProveedor.AutoSize = True
        Me.checkboxTipoProveedor.Location = New System.Drawing.Point(420, 9)
        Me.checkboxTipoProveedor.Name = "checkboxTipoProveedor"
        Me.checkboxTipoProveedor.Size = New System.Drawing.Size(15, 14)
        Me.checkboxTipoProveedor.TabIndex = 9
        Me.checkboxTipoProveedor.UseVisualStyleBackColor = True
        '
        'comboboxCategoriaIVA
        '
        Me.comboboxCategoriaIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCategoriaIVA.FormattingEnabled = True
        Me.comboboxCategoriaIVA.Location = New System.Drawing.Point(142, 146)
        Me.comboboxCategoriaIVA.Name = "comboboxCategoriaIVA"
        Me.comboboxCategoriaIVA.Size = New System.Drawing.Size(200, 21)
        Me.comboboxCategoriaIVA.TabIndex = 24
        '
        'datetimepickerFechaNacimiento
        '
        Me.datetimepickerFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerFechaNacimiento.Location = New System.Drawing.Point(142, 120)
        Me.datetimepickerFechaNacimiento.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerFechaNacimiento.MinDate = New Date(1910, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerFechaNacimiento.Name = "datetimepickerFechaNacimiento"
        Me.datetimepickerFechaNacimiento.ShowCheckBox = True
        Me.datetimepickerFechaNacimiento.Size = New System.Drawing.Size(148, 20)
        Me.datetimepickerFechaNacimiento.TabIndex = 22
        '
        'comboboxGenero
        '
        Me.comboboxGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxGenero.FormattingEnabled = True
        Me.comboboxGenero.Location = New System.Drawing.Point(142, 91)
        Me.comboboxGenero.Name = "comboboxGenero"
        Me.comboboxGenero.Size = New System.Drawing.Size(102, 21)
        Me.comboboxGenero.TabIndex = 20
        '
        'comboboxDocumentoTipo
        '
        Me.comboboxDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxDocumentoTipo.FormattingEnabled = True
        Me.comboboxDocumentoTipo.Location = New System.Drawing.Point(142, 37)
        Me.comboboxDocumentoTipo.Name = "comboboxDocumentoTipo"
        Me.comboboxDocumentoTipo.Size = New System.Drawing.Size(102, 21)
        Me.comboboxDocumentoTipo.TabIndex = 12
        '
        'textboxDocumentoNumero
        '
        Me.textboxDocumentoNumero.Location = New System.Drawing.Point(250, 38)
        Me.textboxDocumentoNumero.MaxLength = 11
        Me.textboxDocumentoNumero.Name = "textboxDocumentoNumero"
        Me.textboxDocumentoNumero.Size = New System.Drawing.Size(115, 20)
        Me.textboxDocumentoNumero.TabIndex = 13
        Me.tooltipMain.SetToolTip(Me.textboxDocumentoNumero, "Ingrese el Número de Documento sin utilizar puntos.")
        '
        'maskedtextboxDocumentoNumero
        '
        Me.maskedtextboxDocumentoNumero.AllowPromptAsInput = False
        Me.maskedtextboxDocumentoNumero.AsciiOnly = True
        Me.maskedtextboxDocumentoNumero.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.maskedtextboxDocumentoNumero.HidePromptOnLeave = True
        Me.maskedtextboxDocumentoNumero.Location = New System.Drawing.Point(250, 38)
        Me.maskedtextboxDocumentoNumero.Mask = "00-00000000-0"
        Me.maskedtextboxDocumentoNumero.Name = "maskedtextboxDocumentoNumero"
        Me.maskedtextboxDocumentoNumero.Size = New System.Drawing.Size(115, 20)
        Me.maskedtextboxDocumentoNumero.TabIndex = 14
        Me.maskedtextboxDocumentoNumero.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'maskedtextboxFacturaDocumentoNumero
        '
        Me.maskedtextboxFacturaDocumentoNumero.AllowPromptAsInput = False
        Me.maskedtextboxFacturaDocumentoNumero.AsciiOnly = True
        Me.maskedtextboxFacturaDocumentoNumero.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.maskedtextboxFacturaDocumentoNumero.HidePromptOnLeave = True
        Me.maskedtextboxFacturaDocumentoNumero.Location = New System.Drawing.Point(250, 64)
        Me.maskedtextboxFacturaDocumentoNumero.Mask = "00-00000000-0"
        Me.maskedtextboxFacturaDocumentoNumero.Name = "maskedtextboxFacturaDocumentoNumero"
        Me.maskedtextboxFacturaDocumentoNumero.Size = New System.Drawing.Size(115, 20)
        Me.maskedtextboxFacturaDocumentoNumero.TabIndex = 18
        Me.maskedtextboxFacturaDocumentoNumero.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'tabpageContacto
        '
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
        Me.tabpageContacto.Location = New System.Drawing.Point(4, 25)
        Me.tabpageContacto.Name = "tabpageContacto"
        Me.tabpageContacto.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageContacto.Size = New System.Drawing.Size(506, 223)
        Me.tabpageContacto.TabIndex = 1
        Me.tabpageContacto.Text = "Contacto"
        Me.tabpageContacto.UseVisualStyleBackColor = True
        '
        'textboxDomicilioCalle3
        '
        Me.textboxDomicilioCalle3.Location = New System.Drawing.Point(330, 137)
        Me.textboxDomicilioCalle3.MaxLength = 50
        Me.textboxDomicilioCalle3.Name = "textboxDomicilioCalle3"
        Me.textboxDomicilioCalle3.Size = New System.Drawing.Size(170, 20)
        Me.textboxDomicilioCalle3.TabIndex = 21
        '
        'textboxDomicilioCalle2
        '
        Me.textboxDomicilioCalle2.Location = New System.Drawing.Point(72, 137)
        Me.textboxDomicilioCalle2.MaxLength = 50
        Me.textboxDomicilioCalle2.Name = "textboxDomicilioCalle2"
        Me.textboxDomicilioCalle2.Size = New System.Drawing.Size(170, 20)
        Me.textboxDomicilioCalle2.TabIndex = 19
        '
        'comboboxDomicilioLocalidad
        '
        Me.comboboxDomicilioLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxDomicilioLocalidad.FormattingEnabled = True
        Me.comboboxDomicilioLocalidad.Location = New System.Drawing.Point(72, 190)
        Me.comboboxDomicilioLocalidad.Name = "comboboxDomicilioLocalidad"
        Me.comboboxDomicilioLocalidad.Size = New System.Drawing.Size(258, 21)
        Me.comboboxDomicilioLocalidad.TabIndex = 25
        '
        'comboboxDomicilioProvincia
        '
        Me.comboboxDomicilioProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxDomicilioProvincia.FormattingEnabled = True
        Me.comboboxDomicilioProvincia.Location = New System.Drawing.Point(72, 163)
        Me.comboboxDomicilioProvincia.Name = "comboboxDomicilioProvincia"
        Me.comboboxDomicilioProvincia.Size = New System.Drawing.Size(258, 21)
        Me.comboboxDomicilioProvincia.TabIndex = 23
        '
        'textboxDomicilioCalle1
        '
        Me.textboxDomicilioCalle1.Location = New System.Drawing.Point(72, 85)
        Me.textboxDomicilioCalle1.MaxLength = 100
        Me.textboxDomicilioCalle1.Name = "textboxDomicilioCalle1"
        Me.textboxDomicilioCalle1.Size = New System.Drawing.Size(258, 20)
        Me.textboxDomicilioCalle1.TabIndex = 11
        '
        'textboxDomicilioCodigoPostal
        '
        Me.textboxDomicilioCodigoPostal.Location = New System.Drawing.Point(450, 190)
        Me.textboxDomicilioCodigoPostal.MaxLength = 8
        Me.textboxDomicilioCodigoPostal.Name = "textboxDomicilioCodigoPostal"
        Me.textboxDomicilioCodigoPostal.Size = New System.Drawing.Size(50, 20)
        Me.textboxDomicilioCodigoPostal.TabIndex = 27
        '
        'textboxDomicilioDepartamento
        '
        Me.textboxDomicilioDepartamento.Location = New System.Drawing.Point(280, 111)
        Me.textboxDomicilioDepartamento.MaxLength = 10
        Me.textboxDomicilioDepartamento.Name = "textboxDomicilioDepartamento"
        Me.textboxDomicilioDepartamento.Size = New System.Drawing.Size(50, 20)
        Me.textboxDomicilioDepartamento.TabIndex = 17
        '
        'textboxDomicilioNumero
        '
        Me.textboxDomicilioNumero.Location = New System.Drawing.Point(72, 111)
        Me.textboxDomicilioNumero.MaxLength = 10
        Me.textboxDomicilioNumero.Name = "textboxDomicilioNumero"
        Me.textboxDomicilioNumero.Size = New System.Drawing.Size(50, 20)
        Me.textboxDomicilioNumero.TabIndex = 13
        '
        'textboxDomicilioPiso
        '
        Me.textboxDomicilioPiso.Location = New System.Drawing.Point(164, 111)
        Me.textboxDomicilioPiso.MaxLength = 10
        Me.textboxDomicilioPiso.Name = "textboxDomicilioPiso"
        Me.textboxDomicilioPiso.Size = New System.Drawing.Size(50, 20)
        Me.textboxDomicilioPiso.TabIndex = 15
        '
        'textboxEmail1
        '
        Me.textboxEmail1.Location = New System.Drawing.Point(72, 59)
        Me.textboxEmail1.MaxLength = 50
        Me.textboxEmail1.Name = "textboxEmail1"
        Me.textboxEmail1.Size = New System.Drawing.Size(170, 20)
        Me.textboxEmail1.TabIndex = 7
        '
        'textboxEmail2
        '
        Me.textboxEmail2.Location = New System.Drawing.Point(330, 59)
        Me.textboxEmail2.MaxLength = 50
        Me.textboxEmail2.Name = "textboxEmail2"
        Me.textboxEmail2.Size = New System.Drawing.Size(170, 20)
        Me.textboxEmail2.TabIndex = 9
        '
        'textboxTelefono1
        '
        Me.textboxTelefono1.Location = New System.Drawing.Point(72, 7)
        Me.textboxTelefono1.MaxLength = 50
        Me.textboxTelefono1.Name = "textboxTelefono1"
        Me.textboxTelefono1.Size = New System.Drawing.Size(170, 20)
        Me.textboxTelefono1.TabIndex = 1
        '
        'textboxTelefono2
        '
        Me.textboxTelefono2.Location = New System.Drawing.Point(330, 7)
        Me.textboxTelefono2.MaxLength = 50
        Me.textboxTelefono2.Name = "textboxTelefono2"
        Me.textboxTelefono2.Size = New System.Drawing.Size(170, 20)
        Me.textboxTelefono2.TabIndex = 3
        '
        'textboxTelefono3
        '
        Me.textboxTelefono3.Location = New System.Drawing.Point(72, 33)
        Me.textboxTelefono3.MaxLength = 50
        Me.textboxTelefono3.Name = "textboxTelefono3"
        Me.textboxTelefono3.Size = New System.Drawing.Size(170, 20)
        Me.textboxTelefono3.TabIndex = 5
        '
        'tabpageExtra
        '
        Me.tabpageExtra.Controls.Add(Me.textboxFacturaLeyenda)
        Me.tabpageExtra.Controls.Add(labelFacturaLeyenda)
        Me.tabpageExtra.Controls.Add(labelVarios)
        Me.tabpageExtra.Controls.Add(Me.checkboxFacturaIndividual)
        Me.tabpageExtra.Controls.Add(labelFacturaIndividual)
        Me.tabpageExtra.Controls.Add(Me.checkboxExcluyeCalculoInteres)
        Me.tabpageExtra.Controls.Add(labelExcluyeCalculoInteres)
        Me.tabpageExtra.Controls.Add(Me.panelEntidadTercero)
        Me.tabpageExtra.Controls.Add(Me.labelEntidadTercero)
        Me.tabpageExtra.Controls.Add(Me.datetimepickerExcluyeFacturaHasta)
        Me.tabpageExtra.Controls.Add(labelExcluyeFacturaHasta)
        Me.tabpageExtra.Controls.Add(Me.datetimepickerExcluyeFacturaDesde)
        Me.tabpageExtra.Controls.Add(labelExcluyeFacturaDesde)
        Me.tabpageExtra.Controls.Add(Me.comboboxDescuento)
        Me.tabpageExtra.Controls.Add(labelDescuento)
        Me.tabpageExtra.Controls.Add(Me.comboboxEmitirFacturaA)
        Me.tabpageExtra.Controls.Add(Me.labelEmitirFacturaA)
        Me.tabpageExtra.Controls.Add(Me.labelEntidadMadre)
        Me.tabpageExtra.Controls.Add(Me.panelEntidadMadre)
        Me.tabpageExtra.Controls.Add(Me.panelEntidadPadre)
        Me.tabpageExtra.Controls.Add(Me.labelEntidadPadre)
        Me.tabpageExtra.Location = New System.Drawing.Point(4, 25)
        Me.tabpageExtra.Name = "tabpageExtra"
        Me.tabpageExtra.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageExtra.Size = New System.Drawing.Size(506, 223)
        Me.tabpageExtra.TabIndex = 2
        Me.tabpageExtra.Text = "Padres y Facturación"
        Me.tabpageExtra.UseVisualStyleBackColor = True
        '
        'textboxFacturaLeyenda
        '
        Me.textboxFacturaLeyenda.Location = New System.Drawing.Point(107, 195)
        Me.textboxFacturaLeyenda.MaxLength = 0
        Me.textboxFacturaLeyenda.Multiline = True
        Me.textboxFacturaLeyenda.Name = "textboxFacturaLeyenda"
        Me.textboxFacturaLeyenda.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textboxFacturaLeyenda.Size = New System.Drawing.Size(393, 20)
        Me.textboxFacturaLeyenda.TabIndex = 20
        '
        'checkboxFacturaIndividual
        '
        Me.checkboxFacturaIndividual.AutoSize = True
        Me.checkboxFacturaIndividual.Location = New System.Drawing.Point(328, 148)
        Me.checkboxFacturaIndividual.Name = "checkboxFacturaIndividual"
        Me.checkboxFacturaIndividual.Size = New System.Drawing.Size(15, 14)
        Me.checkboxFacturaIndividual.TabIndex = 13
        Me.checkboxFacturaIndividual.UseVisualStyleBackColor = True
        '
        'checkboxExcluyeCalculoInteres
        '
        Me.checkboxExcluyeCalculoInteres.AutoSize = True
        Me.checkboxExcluyeCalculoInteres.Location = New System.Drawing.Point(107, 148)
        Me.checkboxExcluyeCalculoInteres.Name = "checkboxExcluyeCalculoInteres"
        Me.checkboxExcluyeCalculoInteres.Size = New System.Drawing.Size(15, 14)
        Me.checkboxExcluyeCalculoInteres.TabIndex = 11
        Me.checkboxExcluyeCalculoInteres.UseVisualStyleBackColor = True
        '
        'panelEntidadTercero
        '
        Me.panelEntidadTercero.Controls.Add(Me.buttonEntidadTerceroBorrar)
        Me.panelEntidadTercero.Controls.Add(Me.buttonEntidadTercero)
        Me.panelEntidadTercero.Controls.Add(Me.textboxEntidadTercero)
        Me.panelEntidadTercero.Location = New System.Drawing.Point(107, 91)
        Me.panelEntidadTercero.Name = "panelEntidadTercero"
        Me.panelEntidadTercero.Size = New System.Drawing.Size(393, 22)
        Me.panelEntidadTercero.TabIndex = 7
        '
        'buttonEntidadTerceroBorrar
        '
        Me.buttonEntidadTerceroBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonEntidadTerceroBorrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_16
        Me.buttonEntidadTerceroBorrar.Location = New System.Drawing.Point(371, 0)
        Me.buttonEntidadTerceroBorrar.Name = "buttonEntidadTerceroBorrar"
        Me.buttonEntidadTerceroBorrar.Size = New System.Drawing.Size(22, 22)
        Me.buttonEntidadTerceroBorrar.TabIndex = 2
        Me.buttonEntidadTerceroBorrar.Text = "…"
        Me.buttonEntidadTerceroBorrar.UseVisualStyleBackColor = True
        '
        'buttonEntidadTercero
        '
        Me.buttonEntidadTercero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonEntidadTercero.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonEntidadTercero.Location = New System.Drawing.Point(350, 0)
        Me.buttonEntidadTercero.Name = "buttonEntidadTercero"
        Me.buttonEntidadTercero.Size = New System.Drawing.Size(22, 22)
        Me.buttonEntidadTercero.TabIndex = 1
        Me.buttonEntidadTercero.Text = "…"
        Me.buttonEntidadTercero.UseVisualStyleBackColor = True
        '
        'textboxEntidadTercero
        '
        Me.textboxEntidadTercero.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxEntidadTercero.Location = New System.Drawing.Point(0, 1)
        Me.textboxEntidadTercero.MaxLength = 150
        Me.textboxEntidadTercero.Name = "textboxEntidadTercero"
        Me.textboxEntidadTercero.ReadOnly = True
        Me.textboxEntidadTercero.Size = New System.Drawing.Size(350, 20)
        Me.textboxEntidadTercero.TabIndex = 0
        Me.textboxEntidadTercero.TabStop = False
        '
        'labelEntidadTercero
        '
        Me.labelEntidadTercero.AutoSize = True
        Me.labelEntidadTercero.Location = New System.Drawing.Point(6, 96)
        Me.labelEntidadTercero.Name = "labelEntidadTercero"
        Me.labelEntidadTercero.Size = New System.Drawing.Size(47, 13)
        Me.labelEntidadTercero.TabIndex = 6
        Me.labelEntidadTercero.Text = "Tercero:"
        '
        'datetimepickerExcluyeFacturaHasta
        '
        Me.datetimepickerExcluyeFacturaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerExcluyeFacturaHasta.Location = New System.Drawing.Point(303, 169)
        Me.datetimepickerExcluyeFacturaHasta.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerExcluyeFacturaHasta.MinDate = New Date(2008, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerExcluyeFacturaHasta.Name = "datetimepickerExcluyeFacturaHasta"
        Me.datetimepickerExcluyeFacturaHasta.ShowCheckBox = True
        Me.datetimepickerExcluyeFacturaHasta.Size = New System.Drawing.Size(148, 20)
        Me.datetimepickerExcluyeFacturaHasta.TabIndex = 18
        '
        'datetimepickerExcluyeFacturaDesde
        '
        Me.datetimepickerExcluyeFacturaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerExcluyeFacturaDesde.Location = New System.Drawing.Point(107, 169)
        Me.datetimepickerExcluyeFacturaDesde.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerExcluyeFacturaDesde.MinDate = New Date(2008, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerExcluyeFacturaDesde.Name = "datetimepickerExcluyeFacturaDesde"
        Me.datetimepickerExcluyeFacturaDesde.ShowCheckBox = True
        Me.datetimepickerExcluyeFacturaDesde.Size = New System.Drawing.Size(148, 20)
        Me.datetimepickerExcluyeFacturaDesde.TabIndex = 16
        '
        'comboboxDescuento
        '
        Me.comboboxDescuento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxDescuento.FormattingEnabled = True
        Me.comboboxDescuento.Location = New System.Drawing.Point(107, 119)
        Me.comboboxDescuento.Name = "comboboxDescuento"
        Me.comboboxDescuento.Size = New System.Drawing.Size(160, 21)
        Me.comboboxDescuento.TabIndex = 9
        '
        'comboboxEmitirFacturaA
        '
        Me.comboboxEmitirFacturaA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxEmitirFacturaA.FormattingEnabled = True
        Me.comboboxEmitirFacturaA.Location = New System.Drawing.Point(107, 64)
        Me.comboboxEmitirFacturaA.Name = "comboboxEmitirFacturaA"
        Me.comboboxEmitirFacturaA.Size = New System.Drawing.Size(160, 21)
        Me.comboboxEmitirFacturaA.TabIndex = 5
        '
        'labelEmitirFacturaA
        '
        Me.labelEmitirFacturaA.AutoSize = True
        Me.labelEmitirFacturaA.Location = New System.Drawing.Point(6, 67)
        Me.labelEmitirFacturaA.Name = "labelEmitirFacturaA"
        Me.labelEmitirFacturaA.Size = New System.Drawing.Size(83, 13)
        Me.labelEmitirFacturaA.TabIndex = 4
        Me.labelEmitirFacturaA.Text = "Emitir Factura a:"
        '
        'labelEntidadMadre
        '
        Me.labelEntidadMadre.AutoSize = True
        Me.labelEntidadMadre.Location = New System.Drawing.Point(6, 41)
        Me.labelEntidadMadre.Name = "labelEntidadMadre"
        Me.labelEntidadMadre.Size = New System.Drawing.Size(82, 13)
        Me.labelEntidadMadre.TabIndex = 2
        Me.labelEntidadMadre.Text = "Madre / Tutora:"
        '
        'panelEntidadMadre
        '
        Me.panelEntidadMadre.Controls.Add(Me.buttonEntidadMadreBorrar)
        Me.panelEntidadMadre.Controls.Add(Me.buttonEntidadMadre)
        Me.panelEntidadMadre.Controls.Add(Me.textboxEntidadMadre)
        Me.panelEntidadMadre.Location = New System.Drawing.Point(107, 36)
        Me.panelEntidadMadre.Name = "panelEntidadMadre"
        Me.panelEntidadMadre.Size = New System.Drawing.Size(393, 22)
        Me.panelEntidadMadre.TabIndex = 3
        '
        'buttonEntidadMadreBorrar
        '
        Me.buttonEntidadMadreBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonEntidadMadreBorrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_16
        Me.buttonEntidadMadreBorrar.Location = New System.Drawing.Point(371, 0)
        Me.buttonEntidadMadreBorrar.Name = "buttonEntidadMadreBorrar"
        Me.buttonEntidadMadreBorrar.Size = New System.Drawing.Size(22, 22)
        Me.buttonEntidadMadreBorrar.TabIndex = 2
        Me.buttonEntidadMadreBorrar.Text = "…"
        Me.buttonEntidadMadreBorrar.UseVisualStyleBackColor = True
        '
        'buttonEntidadMadre
        '
        Me.buttonEntidadMadre.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonEntidadMadre.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonEntidadMadre.Location = New System.Drawing.Point(350, 0)
        Me.buttonEntidadMadre.Name = "buttonEntidadMadre"
        Me.buttonEntidadMadre.Size = New System.Drawing.Size(22, 22)
        Me.buttonEntidadMadre.TabIndex = 1
        Me.buttonEntidadMadre.Text = "…"
        Me.buttonEntidadMadre.UseVisualStyleBackColor = True
        '
        'textboxEntidadMadre
        '
        Me.textboxEntidadMadre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxEntidadMadre.Location = New System.Drawing.Point(0, 1)
        Me.textboxEntidadMadre.MaxLength = 150
        Me.textboxEntidadMadre.Name = "textboxEntidadMadre"
        Me.textboxEntidadMadre.ReadOnly = True
        Me.textboxEntidadMadre.Size = New System.Drawing.Size(350, 20)
        Me.textboxEntidadMadre.TabIndex = 0
        Me.textboxEntidadMadre.TabStop = False
        '
        'panelEntidadPadre
        '
        Me.panelEntidadPadre.Controls.Add(Me.buttonEntidadPadreBorrar)
        Me.panelEntidadPadre.Controls.Add(Me.buttonEntidadPadre)
        Me.panelEntidadPadre.Controls.Add(Me.textboxEntidadPadre)
        Me.panelEntidadPadre.Location = New System.Drawing.Point(107, 8)
        Me.panelEntidadPadre.Name = "panelEntidadPadre"
        Me.panelEntidadPadre.Size = New System.Drawing.Size(393, 22)
        Me.panelEntidadPadre.TabIndex = 1
        '
        'buttonEntidadPadreBorrar
        '
        Me.buttonEntidadPadreBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonEntidadPadreBorrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_16
        Me.buttonEntidadPadreBorrar.Location = New System.Drawing.Point(371, 0)
        Me.buttonEntidadPadreBorrar.Name = "buttonEntidadPadreBorrar"
        Me.buttonEntidadPadreBorrar.Size = New System.Drawing.Size(22, 22)
        Me.buttonEntidadPadreBorrar.TabIndex = 2
        Me.buttonEntidadPadreBorrar.Text = "…"
        Me.buttonEntidadPadreBorrar.UseVisualStyleBackColor = True
        '
        'buttonEntidadPadre
        '
        Me.buttonEntidadPadre.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonEntidadPadre.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonEntidadPadre.Location = New System.Drawing.Point(350, 0)
        Me.buttonEntidadPadre.Name = "buttonEntidadPadre"
        Me.buttonEntidadPadre.Size = New System.Drawing.Size(22, 22)
        Me.buttonEntidadPadre.TabIndex = 1
        Me.buttonEntidadPadre.Text = "…"
        Me.buttonEntidadPadre.UseVisualStyleBackColor = True
        '
        'textboxEntidadPadre
        '
        Me.textboxEntidadPadre.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxEntidadPadre.Location = New System.Drawing.Point(0, 1)
        Me.textboxEntidadPadre.MaxLength = 150
        Me.textboxEntidadPadre.Name = "textboxEntidadPadre"
        Me.textboxEntidadPadre.ReadOnly = True
        Me.textboxEntidadPadre.Size = New System.Drawing.Size(350, 20)
        Me.textboxEntidadPadre.TabIndex = 0
        Me.textboxEntidadPadre.TabStop = False
        '
        'labelEntidadPadre
        '
        Me.labelEntidadPadre.AutoSize = True
        Me.labelEntidadPadre.Location = New System.Drawing.Point(6, 12)
        Me.labelEntidadPadre.Name = "labelEntidadPadre"
        Me.labelEntidadPadre.Size = New System.Drawing.Size(74, 13)
        Me.labelEntidadPadre.TabIndex = 0
        Me.labelEntidadPadre.Text = "Padre / Tutor:"
        '
        'tabpageCursosAsistidos
        '
        Me.tabpageCursosAsistidos.Controls.Add(Me.datagridviewCursosAsistidos)
        Me.tabpageCursosAsistidos.Location = New System.Drawing.Point(4, 25)
        Me.tabpageCursosAsistidos.Name = "tabpageCursosAsistidos"
        Me.tabpageCursosAsistidos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageCursosAsistidos.Size = New System.Drawing.Size(506, 223)
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
        Me.datagridviewCursosAsistidos.Location = New System.Drawing.Point(3, 3)
        Me.datagridviewCursosAsistidos.MultiSelect = False
        Me.datagridviewCursosAsistidos.Name = "datagridviewCursosAsistidos"
        Me.datagridviewCursosAsistidos.ReadOnly = True
        Me.datagridviewCursosAsistidos.RowHeadersVisible = False
        Me.datagridviewCursosAsistidos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewCursosAsistidos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewCursosAsistidos.Size = New System.Drawing.Size(500, 217)
        Me.datagridviewCursosAsistidos.TabIndex = 5
        '
        'columnAnioLectivo
        '
        Me.columnAnioLectivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnAnioLectivo.DataPropertyName = "AnioLectivo"
        Me.columnAnioLectivo.HeaderText = "Año Lectivo"
        Me.columnAnioLectivo.Name = "columnAnioLectivo"
        Me.columnAnioLectivo.ReadOnly = True
        Me.columnAnioLectivo.Width = 89
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
        Me.columnNivelNombre.Width = 56
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
        Me.columnAnioNombre.Width = 51
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
        Me.columnTurnoNombre.Width = 60
        '
        'columnDivision
        '
        Me.columnDivision.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnDivision.DataPropertyName = "Division"
        Me.columnDivision.HeaderText = "División"
        Me.columnDivision.Name = "columnDivision"
        Me.columnDivision.ReadOnly = True
        Me.columnDivision.Width = 69
        '
        'tabpageHijos
        '
        Me.tabpageHijos.Controls.Add(Me.datagridviewHijos)
        Me.tabpageHijos.Location = New System.Drawing.Point(4, 25)
        Me.tabpageHijos.Name = "tabpageHijos"
        Me.tabpageHijos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageHijos.Size = New System.Drawing.Size(506, 223)
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
        Me.datagridviewHijos.Location = New System.Drawing.Point(3, 3)
        Me.datagridviewHijos.MultiSelect = False
        Me.datagridviewHijos.Name = "datagridviewHijos"
        Me.datagridviewHijos.ReadOnly = True
        Me.datagridviewHijos.RowHeadersVisible = False
        Me.datagridviewHijos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewHijos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewHijos.Size = New System.Drawing.Size(500, 217)
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
        Me.columnHijosIDEntidad.Width = 83
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
        Me.columnHijosApellido.Width = 69
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
        Me.columnHijosNombre.Width = 69
        '
        'tabpageRelaciones
        '
        Me.tabpageRelaciones.Controls.Add(Me.datagridviewRelaciones)
        Me.tabpageRelaciones.Location = New System.Drawing.Point(4, 25)
        Me.tabpageRelaciones.Name = "tabpageRelaciones"
        Me.tabpageRelaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageRelaciones.Size = New System.Drawing.Size(506, 223)
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
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewRelaciones.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.datagridviewRelaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewRelaciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnPadresIDEntidad, Me.columnPadresApellido, Me.columnPadresNombre, Me.columnPadresRelacionTipo})
        Me.datagridviewRelaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewRelaciones.Location = New System.Drawing.Point(3, 3)
        Me.datagridviewRelaciones.MultiSelect = False
        Me.datagridviewRelaciones.Name = "datagridviewRelaciones"
        Me.datagridviewRelaciones.ReadOnly = True
        Me.datagridviewRelaciones.RowHeadersVisible = False
        Me.datagridviewRelaciones.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewRelaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewRelaciones.Size = New System.Drawing.Size(500, 217)
        Me.datagridviewRelaciones.TabIndex = 4
        '
        'columnPadresIDEntidad
        '
        Me.columnPadresIDEntidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPadresIDEntidad.DataPropertyName = "IDEntidad"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnPadresIDEntidad.DefaultCellStyle = DataGridViewCellStyle10
        Me.columnPadresIDEntidad.HeaderText = "N° Entidad"
        Me.columnPadresIDEntidad.Name = "columnPadresIDEntidad"
        Me.columnPadresIDEntidad.ReadOnly = True
        Me.columnPadresIDEntidad.Width = 83
        '
        'columnPadresApellido
        '
        Me.columnPadresApellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPadresApellido.DataPropertyName = "Apellido"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnPadresApellido.DefaultCellStyle = DataGridViewCellStyle11
        Me.columnPadresApellido.HeaderText = "Apellido"
        Me.columnPadresApellido.Name = "columnPadresApellido"
        Me.columnPadresApellido.ReadOnly = True
        Me.columnPadresApellido.Width = 69
        '
        'columnPadresNombre
        '
        Me.columnPadresNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPadresNombre.DataPropertyName = "Nombre"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnPadresNombre.DefaultCellStyle = DataGridViewCellStyle12
        Me.columnPadresNombre.HeaderText = "Nombre"
        Me.columnPadresNombre.Name = "columnPadresNombre"
        Me.columnPadresNombre.ReadOnly = True
        Me.columnPadresNombre.Width = 69
        '
        'columnPadresRelacionTipo
        '
        Me.columnPadresRelacionTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPadresRelacionTipo.DataPropertyName = "RelacionTipoNombre"
        Me.columnPadresRelacionTipo.HeaderText = "Relación"
        Me.columnPadresRelacionTipo.Name = "columnPadresRelacionTipo"
        Me.columnPadresRelacionTipo.ReadOnly = True
        Me.columnPadresRelacionTipo.Width = 74
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
        Me.tabpageNotasAuditoria.Location = New System.Drawing.Point(4, 25)
        Me.tabpageNotasAuditoria.Name = "tabpageNotasAuditoria"
        Me.tabpageNotasAuditoria.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageNotasAuditoria.Size = New System.Drawing.Size(506, 223)
        Me.tabpageNotasAuditoria.TabIndex = 7
        Me.tabpageNotasAuditoria.Text = "Notas y Auditoría"
        Me.tabpageNotasAuditoria.UseVisualStyleBackColor = True
        '
        'textboxNotas
        '
        Me.textboxNotas.Location = New System.Drawing.Point(114, 6)
        Me.textboxNotas.MaxLength = 0
        Me.textboxNotas.Multiline = True
        Me.textboxNotas.Name = "textboxNotas"
        Me.textboxNotas.Size = New System.Drawing.Size(386, 155)
        Me.textboxNotas.TabIndex = 16
        '
        'textboxUsuarioModificacion
        '
        Me.textboxUsuarioModificacion.Location = New System.Drawing.Point(241, 193)
        Me.textboxUsuarioModificacion.MaxLength = 50
        Me.textboxUsuarioModificacion.Name = "textboxUsuarioModificacion"
        Me.textboxUsuarioModificacion.ReadOnly = True
        Me.textboxUsuarioModificacion.Size = New System.Drawing.Size(259, 20)
        Me.textboxUsuarioModificacion.TabIndex = 14
        '
        'textboxUsuarioCreacion
        '
        Me.textboxUsuarioCreacion.Location = New System.Drawing.Point(241, 167)
        Me.textboxUsuarioCreacion.MaxLength = 50
        Me.textboxUsuarioCreacion.Name = "textboxUsuarioCreacion"
        Me.textboxUsuarioCreacion.ReadOnly = True
        Me.textboxUsuarioCreacion.Size = New System.Drawing.Size(259, 20)
        Me.textboxUsuarioCreacion.TabIndex = 11
        '
        'textboxFechaHoraModificacion
        '
        Me.textboxFechaHoraModificacion.Location = New System.Drawing.Point(114, 193)
        Me.textboxFechaHoraModificacion.MaxLength = 0
        Me.textboxFechaHoraModificacion.Name = "textboxFechaHoraModificacion"
        Me.textboxFechaHoraModificacion.ReadOnly = True
        Me.textboxFechaHoraModificacion.Size = New System.Drawing.Size(121, 20)
        Me.textboxFechaHoraModificacion.TabIndex = 13
        '
        'textboxFechaHoraCreacion
        '
        Me.textboxFechaHoraCreacion.Location = New System.Drawing.Point(114, 167)
        Me.textboxFechaHoraCreacion.MaxLength = 0
        Me.textboxFechaHoraCreacion.Name = "textboxFechaHoraCreacion"
        Me.textboxFechaHoraCreacion.ReadOnly = True
        Me.textboxFechaHoraCreacion.Size = New System.Drawing.Size(121, 20)
        Me.textboxFechaHoraCreacion.TabIndex = 10
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(539, 39)
        Me.toolstripMain.TabIndex = 0
        '
        'buttonCerrar
        '
        Me.buttonCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonCerrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_32
        Me.buttonCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCerrar.Name = "buttonCerrar"
        Me.buttonCerrar.Size = New System.Drawing.Size(75, 36)
        Me.buttonCerrar.Text = "Cerrar"
        '
        'buttonEditar
        '
        Me.buttonEditar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonEditar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_EDIT_32
        Me.buttonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEditar.Name = "buttonEditar"
        Me.buttonEditar.Size = New System.Drawing.Size(73, 36)
        Me.buttonEditar.Text = "Editar"
        '
        'buttonCancelar
        '
        Me.buttonCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonCancelar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CANCEL_32
        Me.buttonCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCancelar.Name = "buttonCancelar"
        Me.buttonCancelar.Size = New System.Drawing.Size(89, 36)
        Me.buttonCancelar.Text = "Cancelar"
        '
        'buttonGuardar
        '
        Me.buttonGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonGuardar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_OK_32
        Me.buttonGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonGuardar.Name = "buttonGuardar"
        Me.buttonGuardar.Size = New System.Drawing.Size(85, 36)
        Me.buttonGuardar.Text = "Guardar"
        '
        'checkboxEsActivo
        '
        Me.checkboxEsActivo.AutoSize = True
        Me.checkboxEsActivo.Location = New System.Drawing.Point(319, 52)
        Me.checkboxEsActivo.Name = "checkboxEsActivo"
        Me.checkboxEsActivo.Size = New System.Drawing.Size(15, 14)
        Me.checkboxEsActivo.TabIndex = 95
        Me.checkboxEsActivo.UseVisualStyleBackColor = True
        '
        'formEntidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(539, 404)
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
        Me.MaximizeBox = False
        Me.Name = "formEntidad"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Detalle de la Entidad"
        CType(Me.pictureboxMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabcontrolMain.ResumeLayout(False)
        Me.tabpageGeneral.ResumeLayout(False)
        Me.tabpageGeneral.PerformLayout()
        Me.tabpageContacto.ResumeLayout(False)
        Me.tabpageContacto.PerformLayout()
        Me.tabpageExtra.ResumeLayout(False)
        Me.tabpageExtra.PerformLayout()
        Me.panelEntidadTercero.ResumeLayout(False)
        Me.panelEntidadTercero.PerformLayout()
        Me.panelEntidadMadre.ResumeLayout(False)
        Me.panelEntidadMadre.PerformLayout()
        Me.panelEntidadPadre.ResumeLayout(False)
        Me.panelEntidadPadre.PerformLayout()
        Me.tabpageCursosAsistidos.ResumeLayout(False)
        CType(Me.datagridviewCursosAsistidos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpageHijos.ResumeLayout(False)
        CType(Me.datagridviewHijos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpageRelaciones.ResumeLayout(False)
        CType(Me.datagridviewRelaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpageNotasAuditoria.ResumeLayout(False)
        Me.tabpageNotasAuditoria.PerformLayout()
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents textboxApellido As System.Windows.Forms.TextBox
    Friend WithEvents textboxIDEntidad As System.Windows.Forms.TextBox
    Friend WithEvents textboxNombre As System.Windows.Forms.TextBox
    Friend WithEvents pictureboxMain As System.Windows.Forms.PictureBox
    Friend WithEvents tabcontrolMain As System.Windows.Forms.TabControl
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
    Friend WithEvents tabpageExtra As System.Windows.Forms.TabPage
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
End Class
