<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim labelDocumento As System.Windows.Forms.Label
        Dim labelGenero As System.Windows.Forms.Label
        Dim labelFechaNacimiento As System.Windows.Forms.Label
        Dim labelCUIT_CUIL As System.Windows.Forms.Label
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
        Dim labelNotas As System.Windows.Forms.Label
        Dim labelTipo As System.Windows.Forms.Label
        Dim labelDomicilioCalle2 As System.Windows.Forms.Label
        Dim labelDomicilioCalle3 As System.Windows.Forms.Label
        Dim labelModificacion As System.Windows.Forms.Label
        Dim labelCreacion As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formEntidad))
        Me.textboxApellido = New System.Windows.Forms.TextBox()
        Me.textboxIDEntidad = New System.Windows.Forms.TextBox()
        Me.textboxNombre = New System.Windows.Forms.TextBox()
        Me.pictureboxMain = New System.Windows.Forms.PictureBox()
        Me.tabcontrolMain = New System.Windows.Forms.TabControl()
        Me.tabpageGeneral = New System.Windows.Forms.TabPage()
        Me.maskedtextboxCUIT_CUIL = New System.Windows.Forms.MaskedTextBox()
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
        Me.textboxUsuarioModificacion = New System.Windows.Forms.TextBox()
        Me.textboxUsuarioCreacion = New System.Windows.Forms.TextBox()
        Me.textboxFechaHoraModificacion = New System.Windows.Forms.TextBox()
        Me.textboxFechaHoraCreacion = New System.Windows.Forms.TextBox()
        Me.textboxNotas = New System.Windows.Forms.TextBox()
        Me.checkboxActivo = New System.Windows.Forms.CheckBox()
        Me.tabpageRelacionesHijas = New System.Windows.Forms.TabPage()
        Me.datagridviewRelacionesHijas = New System.Windows.Forms.DataGridView()
        Me.tabpageRelacionesPadres = New System.Windows.Forms.TabPage()
        Me.datagridviewRelacionesPadres = New System.Windows.Forms.DataGridView()
        Me.tabpageCursosAsistidos = New System.Windows.Forms.TabPage()
        Me.datagridviewCursosAsistidos = New System.Windows.Forms.DataGridView()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.tooltipMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.columnAnioLectivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNivelNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnAnioNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnTurnoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnDivision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPadresIDEntidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPadresApellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPadresNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPadresRelacionTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnHijasIDEntidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnHijasApellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnHijasNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnHijasRelacionTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        labelApellido = New System.Windows.Forms.Label()
        labelIDEntidad = New System.Windows.Forms.Label()
        labelNombre = New System.Windows.Forms.Label()
        labelDocumento = New System.Windows.Forms.Label()
        labelGenero = New System.Windows.Forms.Label()
        labelFechaNacimiento = New System.Windows.Forms.Label()
        labelCUIT_CUIL = New System.Windows.Forms.Label()
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
        labelNotas = New System.Windows.Forms.Label()
        labelTipo = New System.Windows.Forms.Label()
        labelDomicilioCalle2 = New System.Windows.Forms.Label()
        labelDomicilioCalle3 = New System.Windows.Forms.Label()
        labelModificacion = New System.Windows.Forms.Label()
        labelCreacion = New System.Windows.Forms.Label()
        CType(Me.pictureboxMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabcontrolMain.SuspendLayout()
        Me.tabpageGeneral.SuspendLayout()
        Me.tabpageContacto.SuspendLayout()
        Me.tabpageExtra.SuspendLayout()
        Me.tabpageRelacionesHijas.SuspendLayout()
        CType(Me.datagridviewRelacionesHijas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpageRelacionesPadres.SuspendLayout()
        CType(Me.datagridviewRelacionesPadres, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpageCursosAsistidos.SuspendLayout()
        CType(Me.datagridviewCursosAsistidos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelApellido
        '
        labelApellido.AutoSize = True
        labelApellido.Location = New System.Drawing.Point(75, 80)
        labelApellido.Name = "labelApellido"
        labelApellido.Size = New System.Drawing.Size(52, 13)
        labelApellido.TabIndex = 2
        labelApellido.Text = "Apellidos:"
        '
        'labelIDEntidad
        '
        labelIDEntidad.AutoSize = True
        labelIDEntidad.Location = New System.Drawing.Point(73, 52)
        labelIDEntidad.Name = "labelIDEntidad"
        labelIDEntidad.Size = New System.Drawing.Size(76, 13)
        labelIDEntidad.TabIndex = 0
        labelIDEntidad.Text = "N° de Entidad:"
        '
        'labelNombre
        '
        labelNombre.AutoSize = True
        labelNombre.Location = New System.Drawing.Point(75, 108)
        labelNombre.Name = "labelNombre"
        labelNombre.Size = New System.Drawing.Size(52, 13)
        labelNombre.TabIndex = 4
        labelNombre.Text = "Nombres:"
        '
        'labelDocumento
        '
        labelDocumento.AutoSize = True
        labelDocumento.Location = New System.Drawing.Point(6, 40)
        labelDocumento.Name = "labelDocumento"
        labelDocumento.Size = New System.Drawing.Size(65, 13)
        labelDocumento.TabIndex = 6
        labelDocumento.Text = "Documento:"
        Me.tooltipMain.SetToolTip(labelDocumento, "Ingrese el Número de Documento sin utilizar puntos.")
        '
        'labelGenero
        '
        labelGenero.AutoSize = True
        labelGenero.Location = New System.Drawing.Point(6, 70)
        labelGenero.Name = "labelGenero"
        labelGenero.Size = New System.Drawing.Size(45, 13)
        labelGenero.TabIndex = 9
        labelGenero.Text = "Género:"
        '
        'labelFechaNacimiento
        '
        labelFechaNacimiento.AutoSize = True
        labelFechaNacimiento.Location = New System.Drawing.Point(6, 100)
        labelFechaNacimiento.Name = "labelFechaNacimiento"
        labelFechaNacimiento.Size = New System.Drawing.Size(111, 13)
        labelFechaNacimiento.TabIndex = 11
        labelFechaNacimiento.Text = "Fecha de Nacimiento:"
        '
        'labelCUIT_CUIL
        '
        labelCUIT_CUIL.AutoSize = True
        labelCUIT_CUIL.Location = New System.Drawing.Point(6, 130)
        labelCUIT_CUIL.Name = "labelCUIT_CUIL"
        labelCUIT_CUIL.Size = New System.Drawing.Size(70, 13)
        labelCUIT_CUIL.TabIndex = 13
        labelCUIT_CUIL.Text = "CUIT / CUIL:"
        '
        'labelCategoriaIVA
        '
        labelCategoriaIVA.AutoSize = True
        labelCategoriaIVA.Location = New System.Drawing.Point(6, 160)
        labelCategoriaIVA.Name = "labelCategoriaIVA"
        labelCategoriaIVA.Size = New System.Drawing.Size(92, 13)
        labelCategoriaIVA.TabIndex = 15
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
        'labelNotas
        '
        labelNotas.AutoSize = True
        labelNotas.Location = New System.Drawing.Point(6, 33)
        labelNotas.Name = "labelNotas"
        labelNotas.Size = New System.Drawing.Size(38, 13)
        labelNotas.TabIndex = 1
        labelNotas.Text = "Notas:"
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
        labelModificacion.Location = New System.Drawing.Point(6, 192)
        labelModificacion.Name = "labelModificacion"
        labelModificacion.Size = New System.Drawing.Size(102, 13)
        labelModificacion.TabIndex = 6
        labelModificacion.Text = "Ultima Modificación:"
        '
        'labelCreacion
        '
        labelCreacion.AutoSize = True
        labelCreacion.Location = New System.Drawing.Point(6, 170)
        labelCreacion.Name = "labelCreacion"
        labelCreacion.Size = New System.Drawing.Size(52, 13)
        labelCreacion.TabIndex = 3
        labelCreacion.Text = "Creación:"
        '
        'textboxApellido
        '
        Me.textboxApellido.Location = New System.Drawing.Point(155, 77)
        Me.textboxApellido.MaxLength = 100
        Me.textboxApellido.Name = "textboxApellido"
        Me.textboxApellido.Size = New System.Drawing.Size(371, 20)
        Me.textboxApellido.TabIndex = 3
        '
        'textboxIDEntidad
        '
        Me.textboxIDEntidad.Location = New System.Drawing.Point(155, 49)
        Me.textboxIDEntidad.MaxLength = 8
        Me.textboxIDEntidad.Name = "textboxIDEntidad"
        Me.textboxIDEntidad.ReadOnly = True
        Me.textboxIDEntidad.Size = New System.Drawing.Size(72, 20)
        Me.textboxIDEntidad.TabIndex = 1
        Me.textboxIDEntidad.TabStop = False
        '
        'textboxNombre
        '
        Me.textboxNombre.Location = New System.Drawing.Point(155, 103)
        Me.textboxNombre.MaxLength = 50
        Me.textboxNombre.Name = "textboxNombre"
        Me.textboxNombre.Size = New System.Drawing.Size(239, 20)
        Me.textboxNombre.TabIndex = 5
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
        Me.tabcontrolMain.Controls.Add(Me.tabpageRelacionesHijas)
        Me.tabcontrolMain.Controls.Add(Me.tabpageRelacionesPadres)
        Me.tabcontrolMain.Controls.Add(Me.tabpageCursosAsistidos)
        Me.tabcontrolMain.Location = New System.Drawing.Point(12, 138)
        Me.tabcontrolMain.Name = "tabcontrolMain"
        Me.tabcontrolMain.SelectedIndex = 0
        Me.tabcontrolMain.Size = New System.Drawing.Size(514, 248)
        Me.tabcontrolMain.TabIndex = 6
        '
        'tabpageGeneral
        '
        Me.tabpageGeneral.Controls.Add(Me.maskedtextboxCUIT_CUIL)
        Me.tabpageGeneral.Controls.Add(labelTipo)
        Me.tabpageGeneral.Controls.Add(Me.checkboxTipoAlumno)
        Me.tabpageGeneral.Controls.Add(Me.checkboxTipoDocente)
        Me.tabpageGeneral.Controls.Add(Me.checkboxTipoFamiliar)
        Me.tabpageGeneral.Controls.Add(Me.checkboxTipoPersonalColegio)
        Me.tabpageGeneral.Controls.Add(Me.checkboxTipoProveedor)
        Me.tabpageGeneral.Controls.Add(Me.comboboxCategoriaIVA)
        Me.tabpageGeneral.Controls.Add(labelCategoriaIVA)
        Me.tabpageGeneral.Controls.Add(labelCUIT_CUIL)
        Me.tabpageGeneral.Controls.Add(labelFechaNacimiento)
        Me.tabpageGeneral.Controls.Add(Me.datetimepickerFechaNacimiento)
        Me.tabpageGeneral.Controls.Add(Me.comboboxGenero)
        Me.tabpageGeneral.Controls.Add(labelGenero)
        Me.tabpageGeneral.Controls.Add(Me.comboboxDocumentoTipo)
        Me.tabpageGeneral.Controls.Add(Me.textboxDocumentoNumero)
        Me.tabpageGeneral.Controls.Add(labelDocumento)
        Me.tabpageGeneral.Location = New System.Drawing.Point(4, 25)
        Me.tabpageGeneral.Name = "tabpageGeneral"
        Me.tabpageGeneral.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageGeneral.Size = New System.Drawing.Size(506, 219)
        Me.tabpageGeneral.TabIndex = 0
        Me.tabpageGeneral.Text = "General"
        Me.tabpageGeneral.UseVisualStyleBackColor = True
        '
        'maskedtextboxCUIT_CUIL
        '
        Me.maskedtextboxCUIT_CUIL.AllowPromptAsInput = False
        Me.maskedtextboxCUIT_CUIL.AsciiOnly = True
        Me.maskedtextboxCUIT_CUIL.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.maskedtextboxCUIT_CUIL.HidePromptOnLeave = True
        Me.maskedtextboxCUIT_CUIL.Location = New System.Drawing.Point(123, 127)
        Me.maskedtextboxCUIT_CUIL.Mask = "00-00000000-0"
        Me.maskedtextboxCUIT_CUIL.Name = "maskedtextboxCUIT_CUIL"
        Me.maskedtextboxCUIT_CUIL.Size = New System.Drawing.Size(100, 20)
        Me.maskedtextboxCUIT_CUIL.TabIndex = 14
        Me.maskedtextboxCUIT_CUIL.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'checkboxTipoAlumno
        '
        Me.checkboxTipoAlumno.AutoSize = True
        Me.checkboxTipoAlumno.Location = New System.Drawing.Point(280, 9)
        Me.checkboxTipoAlumno.Name = "checkboxTipoAlumno"
        Me.checkboxTipoAlumno.Size = New System.Drawing.Size(61, 17)
        Me.checkboxTipoAlumno.TabIndex = 3
        Me.checkboxTipoAlumno.Text = "Alumno"
        Me.checkboxTipoAlumno.UseVisualStyleBackColor = True
        '
        'checkboxTipoDocente
        '
        Me.checkboxTipoDocente.AutoSize = True
        Me.checkboxTipoDocente.Location = New System.Drawing.Point(204, 9)
        Me.checkboxTipoDocente.Name = "checkboxTipoDocente"
        Me.checkboxTipoDocente.Size = New System.Drawing.Size(67, 17)
        Me.checkboxTipoDocente.TabIndex = 2
        Me.checkboxTipoDocente.Text = "Docente"
        Me.checkboxTipoDocente.UseVisualStyleBackColor = True
        '
        'checkboxTipoFamiliar
        '
        Me.checkboxTipoFamiliar.AutoSize = True
        Me.checkboxTipoFamiliar.Location = New System.Drawing.Point(350, 9)
        Me.checkboxTipoFamiliar.Name = "checkboxTipoFamiliar"
        Me.checkboxTipoFamiliar.Size = New System.Drawing.Size(61, 17)
        Me.checkboxTipoFamiliar.TabIndex = 4
        Me.checkboxTipoFamiliar.Text = "Familiar"
        Me.checkboxTipoFamiliar.UseVisualStyleBackColor = True
        '
        'checkboxTipoPersonalColegio
        '
        Me.checkboxTipoPersonalColegio.AutoSize = True
        Me.checkboxTipoPersonalColegio.Location = New System.Drawing.Point(90, 9)
        Me.checkboxTipoPersonalColegio.Name = "checkboxTipoPersonalColegio"
        Me.checkboxTipoPersonalColegio.Size = New System.Drawing.Size(105, 17)
        Me.checkboxTipoPersonalColegio.TabIndex = 1
        Me.checkboxTipoPersonalColegio.Text = "Personal Colegio"
        Me.checkboxTipoPersonalColegio.UseVisualStyleBackColor = True
        '
        'checkboxTipoProveedor
        '
        Me.checkboxTipoProveedor.AutoSize = True
        Me.checkboxTipoProveedor.Location = New System.Drawing.Point(420, 9)
        Me.checkboxTipoProveedor.Name = "checkboxTipoProveedor"
        Me.checkboxTipoProveedor.Size = New System.Drawing.Size(75, 17)
        Me.checkboxTipoProveedor.TabIndex = 5
        Me.checkboxTipoProveedor.Text = "Proveedor"
        Me.checkboxTipoProveedor.UseVisualStyleBackColor = True
        '
        'comboboxCategoriaIVA
        '
        Me.comboboxCategoriaIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCategoriaIVA.FormattingEnabled = True
        Me.comboboxCategoriaIVA.Location = New System.Drawing.Point(123, 157)
        Me.comboboxCategoriaIVA.Name = "comboboxCategoriaIVA"
        Me.comboboxCategoriaIVA.Size = New System.Drawing.Size(200, 21)
        Me.comboboxCategoriaIVA.TabIndex = 16
        '
        'datetimepickerFechaNacimiento
        '
        Me.datetimepickerFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerFechaNacimiento.Location = New System.Drawing.Point(123, 97)
        Me.datetimepickerFechaNacimiento.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerFechaNacimiento.MinDate = New Date(1910, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerFechaNacimiento.Name = "datetimepickerFechaNacimiento"
        Me.datetimepickerFechaNacimiento.ShowCheckBox = True
        Me.datetimepickerFechaNacimiento.Size = New System.Drawing.Size(148, 20)
        Me.datetimepickerFechaNacimiento.TabIndex = 12
        '
        'comboboxGenero
        '
        Me.comboboxGenero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxGenero.FormattingEnabled = True
        Me.comboboxGenero.Location = New System.Drawing.Point(123, 67)
        Me.comboboxGenero.Name = "comboboxGenero"
        Me.comboboxGenero.Size = New System.Drawing.Size(102, 21)
        Me.comboboxGenero.TabIndex = 10
        '
        'comboboxDocumentoTipo
        '
        Me.comboboxDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxDocumentoTipo.FormattingEnabled = True
        Me.comboboxDocumentoTipo.Location = New System.Drawing.Point(123, 37)
        Me.comboboxDocumentoTipo.Name = "comboboxDocumentoTipo"
        Me.comboboxDocumentoTipo.Size = New System.Drawing.Size(102, 21)
        Me.comboboxDocumentoTipo.TabIndex = 7
        '
        'textboxDocumentoNumero
        '
        Me.textboxDocumentoNumero.Location = New System.Drawing.Point(231, 38)
        Me.textboxDocumentoNumero.MaxLength = 11
        Me.textboxDocumentoNumero.Name = "textboxDocumentoNumero"
        Me.textboxDocumentoNumero.Size = New System.Drawing.Size(115, 20)
        Me.textboxDocumentoNumero.TabIndex = 8
        Me.tooltipMain.SetToolTip(Me.textboxDocumentoNumero, "Ingrese el Número de Documento sin utilizar puntos.")
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
        Me.tabpageContacto.Size = New System.Drawing.Size(506, 219)
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
        Me.tabpageExtra.Controls.Add(Me.textboxUsuarioModificacion)
        Me.tabpageExtra.Controls.Add(Me.textboxUsuarioCreacion)
        Me.tabpageExtra.Controls.Add(Me.textboxFechaHoraModificacion)
        Me.tabpageExtra.Controls.Add(Me.textboxFechaHoraCreacion)
        Me.tabpageExtra.Controls.Add(labelModificacion)
        Me.tabpageExtra.Controls.Add(labelCreacion)
        Me.tabpageExtra.Controls.Add(labelNotas)
        Me.tabpageExtra.Controls.Add(Me.textboxNotas)
        Me.tabpageExtra.Controls.Add(Me.checkboxActivo)
        Me.tabpageExtra.Location = New System.Drawing.Point(4, 25)
        Me.tabpageExtra.Name = "tabpageExtra"
        Me.tabpageExtra.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageExtra.Size = New System.Drawing.Size(506, 219)
        Me.tabpageExtra.TabIndex = 2
        Me.tabpageExtra.Text = "Extra"
        Me.tabpageExtra.UseVisualStyleBackColor = True
        '
        'textboxUsuarioModificacion
        '
        Me.textboxUsuarioModificacion.Location = New System.Drawing.Point(241, 189)
        Me.textboxUsuarioModificacion.MaxLength = 50
        Me.textboxUsuarioModificacion.Name = "textboxUsuarioModificacion"
        Me.textboxUsuarioModificacion.ReadOnly = True
        Me.textboxUsuarioModificacion.Size = New System.Drawing.Size(259, 20)
        Me.textboxUsuarioModificacion.TabIndex = 8
        '
        'textboxUsuarioCreacion
        '
        Me.textboxUsuarioCreacion.Location = New System.Drawing.Point(241, 163)
        Me.textboxUsuarioCreacion.MaxLength = 50
        Me.textboxUsuarioCreacion.Name = "textboxUsuarioCreacion"
        Me.textboxUsuarioCreacion.ReadOnly = True
        Me.textboxUsuarioCreacion.Size = New System.Drawing.Size(259, 20)
        Me.textboxUsuarioCreacion.TabIndex = 5
        '
        'textboxFechaHoraModificacion
        '
        Me.textboxFechaHoraModificacion.Location = New System.Drawing.Point(114, 189)
        Me.textboxFechaHoraModificacion.MaxLength = 0
        Me.textboxFechaHoraModificacion.Name = "textboxFechaHoraModificacion"
        Me.textboxFechaHoraModificacion.ReadOnly = True
        Me.textboxFechaHoraModificacion.Size = New System.Drawing.Size(121, 20)
        Me.textboxFechaHoraModificacion.TabIndex = 7
        '
        'textboxFechaHoraCreacion
        '
        Me.textboxFechaHoraCreacion.Location = New System.Drawing.Point(114, 163)
        Me.textboxFechaHoraCreacion.MaxLength = 0
        Me.textboxFechaHoraCreacion.Name = "textboxFechaHoraCreacion"
        Me.textboxFechaHoraCreacion.ReadOnly = True
        Me.textboxFechaHoraCreacion.Size = New System.Drawing.Size(121, 20)
        Me.textboxFechaHoraCreacion.TabIndex = 4
        '
        'textboxNotas
        '
        Me.textboxNotas.Location = New System.Drawing.Point(72, 30)
        Me.textboxNotas.MaxLength = 0
        Me.textboxNotas.Multiline = True
        Me.textboxNotas.Name = "textboxNotas"
        Me.textboxNotas.Size = New System.Drawing.Size(428, 127)
        Me.textboxNotas.TabIndex = 2
        '
        'checkboxActivo
        '
        Me.checkboxActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.checkboxActivo.Location = New System.Drawing.Point(3, 6)
        Me.checkboxActivo.Name = "checkboxActivo"
        Me.checkboxActivo.Size = New System.Drawing.Size(83, 18)
        Me.checkboxActivo.TabIndex = 0
        Me.checkboxActivo.Text = "Activo"
        Me.checkboxActivo.UseVisualStyleBackColor = True
        '
        'tabpageRelacionesHijas
        '
        Me.tabpageRelacionesHijas.Controls.Add(Me.datagridviewRelacionesHijas)
        Me.tabpageRelacionesHijas.Location = New System.Drawing.Point(4, 25)
        Me.tabpageRelacionesHijas.Name = "tabpageRelacionesHijas"
        Me.tabpageRelacionesHijas.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageRelacionesHijas.Size = New System.Drawing.Size(506, 219)
        Me.tabpageRelacionesHijas.TabIndex = 4
        Me.tabpageRelacionesHijas.Text = "Relaciones Hijas"
        Me.tabpageRelacionesHijas.UseVisualStyleBackColor = True
        '
        'datagridviewRelacionesHijas
        '
        Me.datagridviewRelacionesHijas.AllowUserToAddRows = False
        Me.datagridviewRelacionesHijas.AllowUserToDeleteRows = False
        Me.datagridviewRelacionesHijas.AllowUserToOrderColumns = True
        Me.datagridviewRelacionesHijas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewRelacionesHijas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewRelacionesHijas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewRelacionesHijas.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnHijasIDEntidad, Me.columnHijasApellido, Me.columnHijasNombre, Me.columnHijasRelacionTipo})
        Me.datagridviewRelacionesHijas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewRelacionesHijas.Location = New System.Drawing.Point(3, 3)
        Me.datagridviewRelacionesHijas.MultiSelect = False
        Me.datagridviewRelacionesHijas.Name = "datagridviewRelacionesHijas"
        Me.datagridviewRelacionesHijas.ReadOnly = True
        Me.datagridviewRelacionesHijas.RowHeadersVisible = False
        Me.datagridviewRelacionesHijas.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewRelacionesHijas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewRelacionesHijas.Size = New System.Drawing.Size(500, 213)
        Me.datagridviewRelacionesHijas.TabIndex = 3
        '
        'tabpageRelacionesPadres
        '
        Me.tabpageRelacionesPadres.Controls.Add(Me.datagridviewRelacionesPadres)
        Me.tabpageRelacionesPadres.Location = New System.Drawing.Point(4, 25)
        Me.tabpageRelacionesPadres.Name = "tabpageRelacionesPadres"
        Me.tabpageRelacionesPadres.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageRelacionesPadres.Size = New System.Drawing.Size(506, 219)
        Me.tabpageRelacionesPadres.TabIndex = 5
        Me.tabpageRelacionesPadres.Text = "Relaciones Padres"
        Me.tabpageRelacionesPadres.UseVisualStyleBackColor = True
        '
        'datagridviewRelacionesPadres
        '
        Me.datagridviewRelacionesPadres.AllowUserToAddRows = False
        Me.datagridviewRelacionesPadres.AllowUserToDeleteRows = False
        Me.datagridviewRelacionesPadres.AllowUserToOrderColumns = True
        Me.datagridviewRelacionesPadres.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewRelacionesPadres.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.datagridviewRelacionesPadres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewRelacionesPadres.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnPadresIDEntidad, Me.columnPadresApellido, Me.columnPadresNombre, Me.columnPadresRelacionTipo})
        Me.datagridviewRelacionesPadres.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewRelacionesPadres.Location = New System.Drawing.Point(3, 3)
        Me.datagridviewRelacionesPadres.MultiSelect = False
        Me.datagridviewRelacionesPadres.Name = "datagridviewRelacionesPadres"
        Me.datagridviewRelacionesPadres.ReadOnly = True
        Me.datagridviewRelacionesPadres.RowHeadersVisible = False
        Me.datagridviewRelacionesPadres.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewRelacionesPadres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewRelacionesPadres.Size = New System.Drawing.Size(500, 213)
        Me.datagridviewRelacionesPadres.TabIndex = 4
        '
        'tabpageCursosAsistidos
        '
        Me.tabpageCursosAsistidos.Controls.Add(Me.datagridviewCursosAsistidos)
        Me.tabpageCursosAsistidos.Location = New System.Drawing.Point(4, 25)
        Me.tabpageCursosAsistidos.Name = "tabpageCursosAsistidos"
        Me.tabpageCursosAsistidos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageCursosAsistidos.Size = New System.Drawing.Size(506, 219)
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
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewCursosAsistidos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
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
        Me.datagridviewCursosAsistidos.Size = New System.Drawing.Size(500, 213)
        Me.datagridviewCursosAsistidos.TabIndex = 5
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(537, 39)
        Me.toolstripMain.TabIndex = 94
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
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnNivelNombre.DefaultCellStyle = DataGridViewCellStyle10
        Me.columnNivelNombre.HeaderText = "Nivel"
        Me.columnNivelNombre.Name = "columnNivelNombre"
        Me.columnNivelNombre.ReadOnly = True
        Me.columnNivelNombre.Width = 56
        '
        'columnAnioNombre
        '
        Me.columnAnioNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnAnioNombre.DataPropertyName = "AnioNombre"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnAnioNombre.DefaultCellStyle = DataGridViewCellStyle11
        Me.columnAnioNombre.HeaderText = "Año"
        Me.columnAnioNombre.Name = "columnAnioNombre"
        Me.columnAnioNombre.ReadOnly = True
        Me.columnAnioNombre.Width = 51
        '
        'columnTurnoNombre
        '
        Me.columnTurnoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTurnoNombre.DataPropertyName = "TurnoNombre"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnTurnoNombre.DefaultCellStyle = DataGridViewCellStyle12
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
        'columnPadresIDEntidad
        '
        Me.columnPadresIDEntidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPadresIDEntidad.DataPropertyName = "IDEntidad"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnPadresIDEntidad.DefaultCellStyle = DataGridViewCellStyle6
        Me.columnPadresIDEntidad.HeaderText = "N° Entidad"
        Me.columnPadresIDEntidad.Name = "columnPadresIDEntidad"
        Me.columnPadresIDEntidad.ReadOnly = True
        Me.columnPadresIDEntidad.Width = 83
        '
        'columnPadresApellido
        '
        Me.columnPadresApellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPadresApellido.DataPropertyName = "Apellido"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnPadresApellido.DefaultCellStyle = DataGridViewCellStyle7
        Me.columnPadresApellido.HeaderText = "Apellido"
        Me.columnPadresApellido.Name = "columnPadresApellido"
        Me.columnPadresApellido.ReadOnly = True
        Me.columnPadresApellido.Width = 69
        '
        'columnPadresNombre
        '
        Me.columnPadresNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPadresNombre.DataPropertyName = "Nombre"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnPadresNombre.DefaultCellStyle = DataGridViewCellStyle8
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
        'columnHijasIDEntidad
        '
        Me.columnHijasIDEntidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnHijasIDEntidad.DataPropertyName = "IDEntidad"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnHijasIDEntidad.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnHijasIDEntidad.HeaderText = "N° Entidad"
        Me.columnHijasIDEntidad.Name = "columnHijasIDEntidad"
        Me.columnHijasIDEntidad.ReadOnly = True
        Me.columnHijasIDEntidad.Width = 83
        '
        'columnHijasApellido
        '
        Me.columnHijasApellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnHijasApellido.DataPropertyName = "Apellido"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnHijasApellido.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnHijasApellido.HeaderText = "Apellido"
        Me.columnHijasApellido.Name = "columnHijasApellido"
        Me.columnHijasApellido.ReadOnly = True
        Me.columnHijasApellido.Width = 69
        '
        'columnHijasNombre
        '
        Me.columnHijasNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnHijasNombre.DataPropertyName = "Nombre"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnHijasNombre.DefaultCellStyle = DataGridViewCellStyle4
        Me.columnHijasNombre.HeaderText = "Nombre"
        Me.columnHijasNombre.Name = "columnHijasNombre"
        Me.columnHijasNombre.ReadOnly = True
        Me.columnHijasNombre.Width = 69
        '
        'columnHijasRelacionTipo
        '
        Me.columnHijasRelacionTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnHijasRelacionTipo.DataPropertyName = "RelacionTipoNombre"
        Me.columnHijasRelacionTipo.HeaderText = "Relación"
        Me.columnHijasRelacionTipo.Name = "columnHijasRelacionTipo"
        Me.columnHijasRelacionTipo.ReadOnly = True
        Me.columnHijasRelacionTipo.Width = 74
        '
        'formEntidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(537, 399)
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
        Me.tabpageRelacionesHijas.ResumeLayout(False)
        CType(Me.datagridviewRelacionesHijas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpageRelacionesPadres.ResumeLayout(False)
        CType(Me.datagridviewRelacionesPadres, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpageCursosAsistidos.ResumeLayout(False)
        CType(Me.datagridviewCursosAsistidos, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents textboxNotas As System.Windows.Forms.TextBox
    Friend WithEvents checkboxActivo As System.Windows.Forms.CheckBox
    Friend WithEvents comboboxDomicilioProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents comboboxDomicilioLocalidad As System.Windows.Forms.ComboBox
    Friend WithEvents checkboxTipoAlumno As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxTipoDocente As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxTipoFamiliar As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxTipoPersonalColegio As System.Windows.Forms.CheckBox
    Friend WithEvents checkboxTipoProveedor As System.Windows.Forms.CheckBox
    Friend WithEvents textboxDomicilioCalle3 As System.Windows.Forms.TextBox
    Friend WithEvents textboxDomicilioCalle2 As System.Windows.Forms.TextBox
    Friend WithEvents tabpageRelacionesHijas As System.Windows.Forms.TabPage
    Friend WithEvents textboxFechaHoraModificacion As System.Windows.Forms.TextBox
    Friend WithEvents textboxFechaHoraCreacion As System.Windows.Forms.TextBox
    Friend WithEvents textboxUsuarioModificacion As System.Windows.Forms.TextBox
    Friend WithEvents textboxUsuarioCreacion As System.Windows.Forms.TextBox
    Friend WithEvents datagridviewRelacionesHijas As System.Windows.Forms.DataGridView
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tabpageRelacionesPadres As System.Windows.Forms.TabPage
    Friend WithEvents datagridviewRelacionesPadres As System.Windows.Forms.DataGridView
    Friend WithEvents tooltipMain As System.Windows.Forms.ToolTip
    Friend WithEvents maskedtextboxCUIT_CUIL As System.Windows.Forms.MaskedTextBox
    Friend WithEvents tabpageCursosAsistidos As System.Windows.Forms.TabPage
    Friend WithEvents datagridviewCursosAsistidos As System.Windows.Forms.DataGridView
    Friend WithEvents columnAnioLectivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNivelNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnAnioNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnTurnoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnDivision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnHijasIDEntidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnHijasApellido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnHijasNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnHijasRelacionTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPadresIDEntidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPadresApellido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPadresNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPadresRelacionTipo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
