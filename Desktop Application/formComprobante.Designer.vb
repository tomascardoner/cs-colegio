<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formComprobante
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
        Dim labelCategoriaIVA As System.Windows.Forms.Label
        Dim labelDomicilioDepartamento As System.Windows.Forms.Label
        Dim labelDomicilioPiso As System.Windows.Forms.Label
        Dim labelDomicilioNumero As System.Windows.Forms.Label
        Dim labelDomicilioCalle1 As System.Windows.Forms.Label
        Dim labelDomicilioCalle3 As System.Windows.Forms.Label
        Dim labelDomicilioCalle2 As System.Windows.Forms.Label
        Dim labelDomicilioProvincia As System.Windows.Forms.Label
        Dim labelDomicilioLocalidad As System.Windows.Forms.Label
        Dim labelDomicilioCodigoPostal As System.Windows.Forms.Label
        Dim labelFechaServicioDesde As System.Windows.Forms.Label
        Dim labelFechaServicioHasta As System.Windows.Forms.Label
        Dim labelDocumento As System.Windows.Forms.Label
        Me.panelMain = New System.Windows.Forms.TableLayoutPanel()
        Me.panelCabecera = New System.Windows.Forms.FlowLayoutPanel()
        Me.panelIdentificacion = New System.Windows.Forms.Panel()
        Me.textboxPuntoVenta = New System.Windows.Forms.TextBox()
        Me.labelPuntoVenta = New System.Windows.Forms.Label()
        Me.comboboxComprobanteTipo = New System.Windows.Forms.ComboBox()
        Me.labelComprobanteTipo = New System.Windows.Forms.Label()
        Me.textboxNumero = New System.Windows.Forms.TextBox()
        Me.labelComprobanteNumero = New System.Windows.Forms.Label()
        Me.datetimepickerFechaEmision = New System.Windows.Forms.DateTimePicker()
        Me.labelFechaEmision = New System.Windows.Forms.Label()
        Me.textboxIDComprobante = New System.Windows.Forms.TextBox()
        Me.labelIDComprobante = New System.Windows.Forms.Label()
        Me.panelFechas = New System.Windows.Forms.Panel()
        Me.datetimepickerFechaServicioHasta = New System.Windows.Forms.DateTimePicker()
        Me.datetimepickerFechaServicioDesde = New System.Windows.Forms.DateTimePicker()
        Me.datetimepickerFechaVencimiento = New System.Windows.Forms.DateTimePicker()
        Me.labelFechaVencimiento = New System.Windows.Forms.Label()
        Me.panelEntidad = New System.Windows.Forms.Panel()
        Me.buttonEntidad = New System.Windows.Forms.Button()
        Me.textboxEntidad = New System.Windows.Forms.TextBox()
        Me.labelEntidad = New System.Windows.Forms.Label()
        Me.panelImpuesto = New System.Windows.Forms.Panel()
        Me.comboboxDocumentoTipo = New System.Windows.Forms.ComboBox()
        Me.textboxDocumentoNumero = New System.Windows.Forms.TextBox()
        Me.comboboxCategoriaIVA = New System.Windows.Forms.ComboBox()
        Me.panelDomicilio = New System.Windows.Forms.Panel()
        Me.textboxDomicilioDepartamento = New System.Windows.Forms.TextBox()
        Me.textboxDomicilioPiso = New System.Windows.Forms.TextBox()
        Me.textboxDomicilioNumero = New System.Windows.Forms.TextBox()
        Me.textboxDomicilioCalle1 = New System.Windows.Forms.TextBox()
        Me.panelDomicilioExtra = New System.Windows.Forms.Panel()
        Me.textboxDomicilioCalle3 = New System.Windows.Forms.TextBox()
        Me.textboxDomicilioCalle2 = New System.Windows.Forms.TextBox()
        Me.panelProvincia = New System.Windows.Forms.Panel()
        Me.comboboxDomicilioProvincia = New System.Windows.Forms.ComboBox()
        Me.panelLocalidad = New System.Windows.Forms.Panel()
        Me.comboboxDomicilioLocalidad = New System.Windows.Forms.ComboBox()
        Me.textboxDomicilioCodigoPostal = New System.Windows.Forms.TextBox()
        Me.tabcontrolMain = New System.Windows.Forms.TabControl()
        Me.tabpageDetalle = New System.Windows.Forms.TabPage()
        Me.datagridviewDetalle = New System.Windows.Forms.DataGridView()
        Me.tabpageImpuestos = New System.Windows.Forms.TabPage()
        Me.tabpageAplicaciones = New System.Windows.Forms.TabPage()
        Me.tabpageAsociaciones = New System.Windows.Forms.TabPage()
        Me.panelPie = New System.Windows.Forms.FlowLayoutPanel()
        Me.panelSubtotales = New System.Windows.Forms.Panel()
        Me.textboxImporteTotal = New System.Windows.Forms.TextBox()
        Me.labelImporteTotal = New System.Windows.Forms.Label()
        Me.textboxImporteImpuesto = New System.Windows.Forms.TextBox()
        Me.labelImporteImpuesto = New System.Windows.Forms.Label()
        Me.textboxImporteNeto = New System.Windows.Forms.TextBox()
        Me.labelImporteNeto = New System.Windows.Forms.Label()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.maskedtextboxDocumentoNumero = New System.Windows.Forms.MaskedTextBox()
        labelCategoriaIVA = New System.Windows.Forms.Label()
        labelDomicilioDepartamento = New System.Windows.Forms.Label()
        labelDomicilioPiso = New System.Windows.Forms.Label()
        labelDomicilioNumero = New System.Windows.Forms.Label()
        labelDomicilioCalle1 = New System.Windows.Forms.Label()
        labelDomicilioCalle3 = New System.Windows.Forms.Label()
        labelDomicilioCalle2 = New System.Windows.Forms.Label()
        labelDomicilioProvincia = New System.Windows.Forms.Label()
        labelDomicilioLocalidad = New System.Windows.Forms.Label()
        labelDomicilioCodigoPostal = New System.Windows.Forms.Label()
        labelFechaServicioDesde = New System.Windows.Forms.Label()
        labelFechaServicioHasta = New System.Windows.Forms.Label()
        labelDocumento = New System.Windows.Forms.Label()
        Me.panelMain.SuspendLayout()
        Me.panelCabecera.SuspendLayout()
        Me.panelIdentificacion.SuspendLayout()
        Me.panelFechas.SuspendLayout()
        Me.panelEntidad.SuspendLayout()
        Me.panelImpuesto.SuspendLayout()
        Me.panelDomicilio.SuspendLayout()
        Me.panelDomicilioExtra.SuspendLayout()
        Me.panelProvincia.SuspendLayout()
        Me.panelLocalidad.SuspendLayout()
        Me.tabcontrolMain.SuspendLayout()
        Me.tabpageDetalle.SuspendLayout()
        CType(Me.datagridviewDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelPie.SuspendLayout()
        Me.panelSubtotales.SuspendLayout()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelCategoriaIVA
        '
        labelCategoriaIVA.AutoSize = True
        labelCategoriaIVA.Location = New System.Drawing.Point(303, 6)
        labelCategoriaIVA.Name = "labelCategoriaIVA"
        labelCategoriaIVA.Size = New System.Drawing.Size(92, 13)
        labelCategoriaIVA.TabIndex = 2
        labelCategoriaIVA.Text = "Categoría de IVA:"
        '
        'labelDomicilioDepartamento
        '
        labelDomicilioDepartamento.AutoSize = True
        labelDomicilioDepartamento.Location = New System.Drawing.Point(510, 6)
        labelDomicilioDepartamento.Name = "labelDomicilioDepartamento"
        labelDomicilioDepartamento.Size = New System.Drawing.Size(54, 13)
        labelDomicilioDepartamento.TabIndex = 6
        labelDomicilioDepartamento.Text = "Dto/Ofic.:"
        '
        'labelDomicilioPiso
        '
        labelDomicilioPiso.AutoSize = True
        labelDomicilioPiso.Location = New System.Drawing.Point(415, 6)
        labelDomicilioPiso.Name = "labelDomicilioPiso"
        labelDomicilioPiso.Size = New System.Drawing.Size(30, 13)
        labelDomicilioPiso.TabIndex = 4
        labelDomicilioPiso.Text = "Piso:"
        '
        'labelDomicilioNumero
        '
        labelDomicilioNumero.AutoSize = True
        labelDomicilioNumero.Location = New System.Drawing.Point(306, 6)
        labelDomicilioNumero.Name = "labelDomicilioNumero"
        labelDomicilioNumero.Size = New System.Drawing.Size(47, 13)
        labelDomicilioNumero.TabIndex = 2
        labelDomicilioNumero.Text = "Número:"
        '
        'labelDomicilioCalle1
        '
        labelDomicilioCalle1.AutoSize = True
        labelDomicilioCalle1.Location = New System.Drawing.Point(3, 6)
        labelDomicilioCalle1.Name = "labelDomicilioCalle1"
        labelDomicilioCalle1.Size = New System.Drawing.Size(33, 13)
        labelDomicilioCalle1.TabIndex = 0
        labelDomicilioCalle1.Text = "Calle:"
        '
        'labelDomicilioCalle3
        '
        labelDomicilioCalle3.AutoSize = True
        labelDomicilioCalle3.Location = New System.Drawing.Point(251, 6)
        labelDomicilioCalle3.Name = "labelDomicilioCalle3"
        labelDomicilioCalle3.Size = New System.Drawing.Size(42, 13)
        labelDomicilioCalle3.TabIndex = 2
        labelDomicilioCalle3.Text = "Calle 3:"
        '
        'labelDomicilioCalle2
        '
        labelDomicilioCalle2.AutoSize = True
        labelDomicilioCalle2.Location = New System.Drawing.Point(3, 6)
        labelDomicilioCalle2.Name = "labelDomicilioCalle2"
        labelDomicilioCalle2.Size = New System.Drawing.Size(42, 13)
        labelDomicilioCalle2.TabIndex = 0
        labelDomicilioCalle2.Text = "Calle 2:"
        '
        'labelDomicilioProvincia
        '
        labelDomicilioProvincia.AutoSize = True
        labelDomicilioProvincia.Location = New System.Drawing.Point(3, 6)
        labelDomicilioProvincia.Name = "labelDomicilioProvincia"
        labelDomicilioProvincia.Size = New System.Drawing.Size(54, 13)
        labelDomicilioProvincia.TabIndex = 0
        labelDomicilioProvincia.Text = "Provincia:"
        '
        'labelDomicilioLocalidad
        '
        labelDomicilioLocalidad.AutoSize = True
        labelDomicilioLocalidad.Location = New System.Drawing.Point(3, 6)
        labelDomicilioLocalidad.Name = "labelDomicilioLocalidad"
        labelDomicilioLocalidad.Size = New System.Drawing.Size(56, 13)
        labelDomicilioLocalidad.TabIndex = 0
        labelDomicilioLocalidad.Text = "Localidad:"
        '
        'labelDomicilioCodigoPostal
        '
        labelDomicilioCodigoPostal.AutoSize = True
        labelDomicilioCodigoPostal.Location = New System.Drawing.Point(353, 6)
        labelDomicilioCodigoPostal.Name = "labelDomicilioCodigoPostal"
        labelDomicilioCodigoPostal.Size = New System.Drawing.Size(59, 13)
        labelDomicilioCodigoPostal.TabIndex = 2
        labelDomicilioCodigoPostal.Text = "Cód. Post.:"
        '
        'labelFechaServicioDesde
        '
        labelFechaServicioDesde.AutoSize = True
        labelFechaServicioDesde.Location = New System.Drawing.Point(251, 6)
        labelFechaServicioDesde.Name = "labelFechaServicioDesde"
        labelFechaServicioDesde.Size = New System.Drawing.Size(133, 13)
        labelFechaServicioDesde.TabIndex = 2
        labelFechaServicioDesde.Text = "Período Facturado Desde:"
        '
        'labelFechaServicioHasta
        '
        labelFechaServicioHasta.AutoSize = True
        labelFechaServicioHasta.Location = New System.Drawing.Point(516, 6)
        labelFechaServicioHasta.Name = "labelFechaServicioHasta"
        labelFechaServicioHasta.Size = New System.Drawing.Size(38, 13)
        labelFechaServicioHasta.TabIndex = 10
        labelFechaServicioHasta.Text = "Hasta:"
        '
        'labelDocumento
        '
        labelDocumento.AutoSize = True
        labelDocumento.Location = New System.Drawing.Point(3, 6)
        labelDocumento.Name = "labelDocumento"
        labelDocumento.Size = New System.Drawing.Size(65, 13)
        labelDocumento.TabIndex = 14
        labelDocumento.Text = "Documento:"
        '
        'panelMain
        '
        Me.panelMain.AutoSize = True
        Me.panelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelMain.ColumnCount = 1
        Me.panelMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.panelMain.Controls.Add(Me.panelCabecera, 0, 0)
        Me.panelMain.Controls.Add(Me.tabcontrolMain, 0, 1)
        Me.panelMain.Controls.Add(Me.panelPie, 0, 2)
        Me.panelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelMain.Location = New System.Drawing.Point(0, 39)
        Me.panelMain.Name = "panelMain"
        Me.panelMain.RowCount = 3
        Me.panelMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.panelMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.panelMain.Size = New System.Drawing.Size(1212, 475)
        Me.panelMain.TabIndex = 2
        '
        'panelCabecera
        '
        Me.panelCabecera.AutoSize = True
        Me.panelCabecera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelCabecera.Controls.Add(Me.panelIdentificacion)
        Me.panelCabecera.Controls.Add(Me.panelFechas)
        Me.panelCabecera.Controls.Add(Me.panelEntidad)
        Me.panelCabecera.Controls.Add(Me.panelImpuesto)
        Me.panelCabecera.Controls.Add(Me.panelDomicilio)
        Me.panelCabecera.Controls.Add(Me.panelDomicilioExtra)
        Me.panelCabecera.Controls.Add(Me.panelProvincia)
        Me.panelCabecera.Controls.Add(Me.panelLocalidad)
        Me.panelCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelCabecera.Location = New System.Drawing.Point(3, 3)
        Me.panelCabecera.Name = "panelCabecera"
        Me.panelCabecera.Size = New System.Drawing.Size(1206, 172)
        Me.panelCabecera.TabIndex = 1
        '
        'panelIdentificacion
        '
        Me.panelIdentificacion.AutoSize = True
        Me.panelIdentificacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelIdentificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelIdentificacion.Controls.Add(Me.textboxPuntoVenta)
        Me.panelIdentificacion.Controls.Add(Me.labelPuntoVenta)
        Me.panelIdentificacion.Controls.Add(Me.comboboxComprobanteTipo)
        Me.panelIdentificacion.Controls.Add(Me.labelComprobanteTipo)
        Me.panelIdentificacion.Controls.Add(Me.textboxNumero)
        Me.panelIdentificacion.Controls.Add(Me.labelComprobanteNumero)
        Me.panelIdentificacion.Controls.Add(Me.datetimepickerFechaEmision)
        Me.panelIdentificacion.Controls.Add(Me.labelFechaEmision)
        Me.panelIdentificacion.Controls.Add(Me.textboxIDComprobante)
        Me.panelIdentificacion.Controls.Add(Me.labelIDComprobante)
        Me.panelIdentificacion.Location = New System.Drawing.Point(3, 3)
        Me.panelIdentificacion.Name = "panelIdentificacion"
        Me.panelIdentificacion.Size = New System.Drawing.Size(777, 29)
        Me.panelIdentificacion.TabIndex = 0
        '
        'textboxPuntoVenta
        '
        Me.textboxPuntoVenta.Location = New System.Drawing.Point(407, 3)
        Me.textboxPuntoVenta.MaxLength = 4
        Me.textboxPuntoVenta.Name = "textboxPuntoVenta"
        Me.textboxPuntoVenta.Size = New System.Drawing.Size(36, 20)
        Me.textboxPuntoVenta.TabIndex = 9
        '
        'labelPuntoVenta
        '
        Me.labelPuntoVenta.AutoSize = True
        Me.labelPuntoVenta.Location = New System.Drawing.Point(317, 6)
        Me.labelPuntoVenta.Name = "labelPuntoVenta"
        Me.labelPuntoVenta.Size = New System.Drawing.Size(84, 13)
        Me.labelPuntoVenta.TabIndex = 8
        Me.labelPuntoVenta.Text = "Punto de Venta:"
        '
        'comboboxComprobanteTipo
        '
        Me.comboboxComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxComprobanteTipo.FormattingEnabled = True
        Me.comboboxComprobanteTipo.Location = New System.Drawing.Point(152, 3)
        Me.comboboxComprobanteTipo.Name = "comboboxComprobanteTipo"
        Me.comboboxComprobanteTipo.Size = New System.Drawing.Size(159, 21)
        Me.comboboxComprobanteTipo.TabIndex = 3
        '
        'labelComprobanteTipo
        '
        Me.labelComprobanteTipo.AutoSize = True
        Me.labelComprobanteTipo.Location = New System.Drawing.Point(110, 6)
        Me.labelComprobanteTipo.Name = "labelComprobanteTipo"
        Me.labelComprobanteTipo.Size = New System.Drawing.Size(31, 13)
        Me.labelComprobanteTipo.TabIndex = 2
        Me.labelComprobanteTipo.Text = "Tipo:"
        '
        'textboxNumero
        '
        Me.textboxNumero.Location = New System.Drawing.Point(502, 3)
        Me.textboxNumero.MaxLength = 8
        Me.textboxNumero.Name = "textboxNumero"
        Me.textboxNumero.Size = New System.Drawing.Size(60, 20)
        Me.textboxNumero.TabIndex = 5
        '
        'labelComprobanteNumero
        '
        Me.labelComprobanteNumero.AutoSize = True
        Me.labelComprobanteNumero.Location = New System.Drawing.Point(449, 6)
        Me.labelComprobanteNumero.Name = "labelComprobanteNumero"
        Me.labelComprobanteNumero.Size = New System.Drawing.Size(47, 13)
        Me.labelComprobanteNumero.TabIndex = 4
        Me.labelComprobanteNumero.Text = "Número:"
        '
        'datetimepickerFechaEmision
        '
        Me.datetimepickerFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerFechaEmision.Location = New System.Drawing.Point(668, 3)
        Me.datetimepickerFechaEmision.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerFechaEmision.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerFechaEmision.Name = "datetimepickerFechaEmision"
        Me.datetimepickerFechaEmision.Size = New System.Drawing.Size(104, 20)
        Me.datetimepickerFechaEmision.TabIndex = 7
        '
        'labelFechaEmision
        '
        Me.labelFechaEmision.AutoSize = True
        Me.labelFechaEmision.Location = New System.Drawing.Point(568, 6)
        Me.labelFechaEmision.Name = "labelFechaEmision"
        Me.labelFechaEmision.Size = New System.Drawing.Size(94, 13)
        Me.labelFechaEmision.TabIndex = 6
        Me.labelFechaEmision.Text = "Fecha de Emisión:"
        '
        'textboxIDComprobante
        '
        Me.textboxIDComprobante.Location = New System.Drawing.Point(30, 3)
        Me.textboxIDComprobante.MaxLength = 7
        Me.textboxIDComprobante.Name = "textboxIDComprobante"
        Me.textboxIDComprobante.Size = New System.Drawing.Size(74, 20)
        Me.textboxIDComprobante.TabIndex = 1
        '
        'labelIDComprobante
        '
        Me.labelIDComprobante.AutoSize = True
        Me.labelIDComprobante.Location = New System.Drawing.Point(3, 6)
        Me.labelIDComprobante.Name = "labelIDComprobante"
        Me.labelIDComprobante.Size = New System.Drawing.Size(21, 13)
        Me.labelIDComprobante.TabIndex = 0
        Me.labelIDComprobante.Text = "ID:"
        '
        'panelFechas
        '
        Me.panelFechas.AutoSize = True
        Me.panelFechas.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelFechas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelFechas.Controls.Add(Me.datetimepickerFechaServicioHasta)
        Me.panelFechas.Controls.Add(labelFechaServicioHasta)
        Me.panelFechas.Controls.Add(Me.datetimepickerFechaServicioDesde)
        Me.panelFechas.Controls.Add(Me.datetimepickerFechaVencimiento)
        Me.panelFechas.Controls.Add(labelFechaServicioDesde)
        Me.panelFechas.Controls.Add(Me.labelFechaVencimiento)
        Me.panelFechas.Location = New System.Drawing.Point(3, 38)
        Me.panelFechas.Name = "panelFechas"
        Me.panelFechas.Size = New System.Drawing.Size(685, 27)
        Me.panelFechas.TabIndex = 7
        '
        'datetimepickerFechaServicioHasta
        '
        Me.datetimepickerFechaServicioHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerFechaServicioHasta.Location = New System.Drawing.Point(560, 2)
        Me.datetimepickerFechaServicioHasta.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerFechaServicioHasta.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerFechaServicioHasta.Name = "datetimepickerFechaServicioHasta"
        Me.datetimepickerFechaServicioHasta.ShowCheckBox = True
        Me.datetimepickerFechaServicioHasta.Size = New System.Drawing.Size(120, 20)
        Me.datetimepickerFechaServicioHasta.TabIndex = 11
        '
        'datetimepickerFechaServicioDesde
        '
        Me.datetimepickerFechaServicioDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerFechaServicioDesde.Location = New System.Drawing.Point(390, 2)
        Me.datetimepickerFechaServicioDesde.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerFechaServicioDesde.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerFechaServicioDesde.Name = "datetimepickerFechaServicioDesde"
        Me.datetimepickerFechaServicioDesde.ShowCheckBox = True
        Me.datetimepickerFechaServicioDesde.Size = New System.Drawing.Size(120, 20)
        Me.datetimepickerFechaServicioDesde.TabIndex = 9
        '
        'datetimepickerFechaVencimiento
        '
        Me.datetimepickerFechaVencimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerFechaVencimiento.Location = New System.Drawing.Point(125, 2)
        Me.datetimepickerFechaVencimiento.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerFechaVencimiento.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerFechaVencimiento.Name = "datetimepickerFechaVencimiento"
        Me.datetimepickerFechaVencimiento.ShowCheckBox = True
        Me.datetimepickerFechaVencimiento.Size = New System.Drawing.Size(120, 20)
        Me.datetimepickerFechaVencimiento.TabIndex = 8
        '
        'labelFechaVencimiento
        '
        Me.labelFechaVencimiento.AutoSize = True
        Me.labelFechaVencimiento.Location = New System.Drawing.Point(3, 6)
        Me.labelFechaVencimiento.Name = "labelFechaVencimiento"
        Me.labelFechaVencimiento.Size = New System.Drawing.Size(116, 13)
        Me.labelFechaVencimiento.TabIndex = 0
        Me.labelFechaVencimiento.Text = "Fecha de Vencimiento:"
        '
        'panelEntidad
        '
        Me.panelEntidad.AutoSize = True
        Me.panelEntidad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelEntidad.Controls.Add(Me.buttonEntidad)
        Me.panelEntidad.Controls.Add(Me.textboxEntidad)
        Me.panelEntidad.Controls.Add(Me.labelEntidad)
        Me.panelEntidad.Location = New System.Drawing.Point(3, 71)
        Me.panelEntidad.Name = "panelEntidad"
        Me.panelEntidad.Size = New System.Drawing.Size(565, 29)
        Me.panelEntidad.TabIndex = 1
        '
        'buttonEntidad
        '
        Me.buttonEntidad.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonEntidad.Location = New System.Drawing.Point(538, 2)
        Me.buttonEntidad.Name = "buttonEntidad"
        Me.buttonEntidad.Size = New System.Drawing.Size(22, 22)
        Me.buttonEntidad.TabIndex = 2
        Me.buttonEntidad.Text = "…"
        Me.buttonEntidad.UseVisualStyleBackColor = True
        '
        'textboxEntidad
        '
        Me.textboxEntidad.Location = New System.Drawing.Point(55, 3)
        Me.textboxEntidad.MaxLength = 150
        Me.textboxEntidad.Name = "textboxEntidad"
        Me.textboxEntidad.Size = New System.Drawing.Size(483, 20)
        Me.textboxEntidad.TabIndex = 1
        '
        'labelEntidad
        '
        Me.labelEntidad.AutoSize = True
        Me.labelEntidad.Location = New System.Drawing.Point(3, 6)
        Me.labelEntidad.Name = "labelEntidad"
        Me.labelEntidad.Size = New System.Drawing.Size(46, 13)
        Me.labelEntidad.TabIndex = 0
        Me.labelEntidad.Text = "Entidad:"
        '
        'panelImpuesto
        '
        Me.panelImpuesto.AutoSize = True
        Me.panelImpuesto.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelImpuesto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelImpuesto.Controls.Add(Me.comboboxDocumentoTipo)
        Me.panelImpuesto.Controls.Add(Me.textboxDocumentoNumero)
        Me.panelImpuesto.Controls.Add(labelDocumento)
        Me.panelImpuesto.Controls.Add(Me.comboboxCategoriaIVA)
        Me.panelImpuesto.Controls.Add(labelCategoriaIVA)
        Me.panelImpuesto.Controls.Add(Me.maskedtextboxDocumentoNumero)
        Me.panelImpuesto.Location = New System.Drawing.Point(574, 71)
        Me.panelImpuesto.Name = "panelImpuesto"
        Me.panelImpuesto.Size = New System.Drawing.Size(606, 28)
        Me.panelImpuesto.TabIndex = 2
        '
        'comboboxDocumentoTipo
        '
        Me.comboboxDocumentoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxDocumentoTipo.FormattingEnabled = True
        Me.comboboxDocumentoTipo.Location = New System.Drawing.Point(74, 2)
        Me.comboboxDocumentoTipo.Name = "comboboxDocumentoTipo"
        Me.comboboxDocumentoTipo.Size = New System.Drawing.Size(102, 21)
        Me.comboboxDocumentoTipo.TabIndex = 15
        '
        'textboxDocumentoNumero
        '
        Me.textboxDocumentoNumero.Location = New System.Drawing.Point(182, 3)
        Me.textboxDocumentoNumero.MaxLength = 11
        Me.textboxDocumentoNumero.Name = "textboxDocumentoNumero"
        Me.textboxDocumentoNumero.Size = New System.Drawing.Size(115, 20)
        Me.textboxDocumentoNumero.TabIndex = 16
        '
        'comboboxCategoriaIVA
        '
        Me.comboboxCategoriaIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCategoriaIVA.FormattingEnabled = True
        Me.comboboxCategoriaIVA.Location = New System.Drawing.Point(401, 2)
        Me.comboboxCategoriaIVA.Name = "comboboxCategoriaIVA"
        Me.comboboxCategoriaIVA.Size = New System.Drawing.Size(200, 21)
        Me.comboboxCategoriaIVA.TabIndex = 3
        '
        'panelDomicilio
        '
        Me.panelDomicilio.AutoSize = True
        Me.panelDomicilio.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelDomicilio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelDomicilio.Controls.Add(labelDomicilioDepartamento)
        Me.panelDomicilio.Controls.Add(Me.textboxDomicilioDepartamento)
        Me.panelDomicilio.Controls.Add(labelDomicilioPiso)
        Me.panelDomicilio.Controls.Add(Me.textboxDomicilioPiso)
        Me.panelDomicilio.Controls.Add(labelDomicilioNumero)
        Me.panelDomicilio.Controls.Add(Me.textboxDomicilioNumero)
        Me.panelDomicilio.Controls.Add(labelDomicilioCalle1)
        Me.panelDomicilio.Controls.Add(Me.textboxDomicilioCalle1)
        Me.panelDomicilio.Location = New System.Drawing.Point(3, 106)
        Me.panelDomicilio.Name = "panelDomicilio"
        Me.panelDomicilio.Size = New System.Drawing.Size(632, 28)
        Me.panelDomicilio.TabIndex = 3
        '
        'textboxDomicilioDepartamento
        '
        Me.textboxDomicilioDepartamento.Location = New System.Drawing.Point(577, 3)
        Me.textboxDomicilioDepartamento.MaxLength = 10
        Me.textboxDomicilioDepartamento.Name = "textboxDomicilioDepartamento"
        Me.textboxDomicilioDepartamento.Size = New System.Drawing.Size(50, 20)
        Me.textboxDomicilioDepartamento.TabIndex = 7
        '
        'textboxDomicilioPiso
        '
        Me.textboxDomicilioPiso.Location = New System.Drawing.Point(451, 3)
        Me.textboxDomicilioPiso.MaxLength = 10
        Me.textboxDomicilioPiso.Name = "textboxDomicilioPiso"
        Me.textboxDomicilioPiso.Size = New System.Drawing.Size(50, 20)
        Me.textboxDomicilioPiso.TabIndex = 5
        '
        'textboxDomicilioNumero
        '
        Me.textboxDomicilioNumero.Location = New System.Drawing.Point(359, 3)
        Me.textboxDomicilioNumero.MaxLength = 10
        Me.textboxDomicilioNumero.Name = "textboxDomicilioNumero"
        Me.textboxDomicilioNumero.Size = New System.Drawing.Size(50, 20)
        Me.textboxDomicilioNumero.TabIndex = 3
        '
        'textboxDomicilioCalle1
        '
        Me.textboxDomicilioCalle1.Location = New System.Drawing.Point(42, 3)
        Me.textboxDomicilioCalle1.MaxLength = 100
        Me.textboxDomicilioCalle1.Name = "textboxDomicilioCalle1"
        Me.textboxDomicilioCalle1.Size = New System.Drawing.Size(258, 20)
        Me.textboxDomicilioCalle1.TabIndex = 1
        '
        'panelDomicilioExtra
        '
        Me.panelDomicilioExtra.AutoSize = True
        Me.panelDomicilioExtra.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelDomicilioExtra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelDomicilioExtra.Controls.Add(labelDomicilioCalle3)
        Me.panelDomicilioExtra.Controls.Add(Me.textboxDomicilioCalle3)
        Me.panelDomicilioExtra.Controls.Add(labelDomicilioCalle2)
        Me.panelDomicilioExtra.Controls.Add(Me.textboxDomicilioCalle2)
        Me.panelDomicilioExtra.Location = New System.Drawing.Point(641, 106)
        Me.panelDomicilioExtra.Name = "panelDomicilioExtra"
        Me.panelDomicilioExtra.Size = New System.Drawing.Size(474, 28)
        Me.panelDomicilioExtra.TabIndex = 4
        '
        'textboxDomicilioCalle3
        '
        Me.textboxDomicilioCalle3.Location = New System.Drawing.Point(299, 3)
        Me.textboxDomicilioCalle3.MaxLength = 50
        Me.textboxDomicilioCalle3.Name = "textboxDomicilioCalle3"
        Me.textboxDomicilioCalle3.Size = New System.Drawing.Size(170, 20)
        Me.textboxDomicilioCalle3.TabIndex = 3
        '
        'textboxDomicilioCalle2
        '
        Me.textboxDomicilioCalle2.Location = New System.Drawing.Point(51, 3)
        Me.textboxDomicilioCalle2.MaxLength = 50
        Me.textboxDomicilioCalle2.Name = "textboxDomicilioCalle2"
        Me.textboxDomicilioCalle2.Size = New System.Drawing.Size(170, 20)
        Me.textboxDomicilioCalle2.TabIndex = 1
        '
        'panelProvincia
        '
        Me.panelProvincia.AutoSize = True
        Me.panelProvincia.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelProvincia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelProvincia.Controls.Add(Me.comboboxDomicilioProvincia)
        Me.panelProvincia.Controls.Add(labelDomicilioProvincia)
        Me.panelProvincia.Location = New System.Drawing.Point(3, 140)
        Me.panelProvincia.Name = "panelProvincia"
        Me.panelProvincia.Size = New System.Drawing.Size(326, 29)
        Me.panelProvincia.TabIndex = 5
        '
        'comboboxDomicilioProvincia
        '
        Me.comboboxDomicilioProvincia.DisplayMember = "Nombre"
        Me.comboboxDomicilioProvincia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxDomicilioProvincia.FormattingEnabled = True
        Me.comboboxDomicilioProvincia.Location = New System.Drawing.Point(63, 3)
        Me.comboboxDomicilioProvincia.Name = "comboboxDomicilioProvincia"
        Me.comboboxDomicilioProvincia.Size = New System.Drawing.Size(258, 21)
        Me.comboboxDomicilioProvincia.TabIndex = 1
        Me.comboboxDomicilioProvincia.ValueMember = "IDProvincia"
        '
        'panelLocalidad
        '
        Me.panelLocalidad.AutoSize = True
        Me.panelLocalidad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelLocalidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelLocalidad.Controls.Add(Me.comboboxDomicilioLocalidad)
        Me.panelLocalidad.Controls.Add(labelDomicilioLocalidad)
        Me.panelLocalidad.Controls.Add(labelDomicilioCodigoPostal)
        Me.panelLocalidad.Controls.Add(Me.textboxDomicilioCodigoPostal)
        Me.panelLocalidad.Location = New System.Drawing.Point(335, 140)
        Me.panelLocalidad.Name = "panelLocalidad"
        Me.panelLocalidad.Size = New System.Drawing.Size(473, 29)
        Me.panelLocalidad.TabIndex = 6
        '
        'comboboxDomicilioLocalidad
        '
        Me.comboboxDomicilioLocalidad.DisplayMember = "Nombre"
        Me.comboboxDomicilioLocalidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxDomicilioLocalidad.FormattingEnabled = True
        Me.comboboxDomicilioLocalidad.Location = New System.Drawing.Point(65, 3)
        Me.comboboxDomicilioLocalidad.Name = "comboboxDomicilioLocalidad"
        Me.comboboxDomicilioLocalidad.Size = New System.Drawing.Size(258, 21)
        Me.comboboxDomicilioLocalidad.TabIndex = 1
        Me.comboboxDomicilioLocalidad.ValueMember = "IDLocalidad"
        '
        'textboxDomicilioCodigoPostal
        '
        Me.textboxDomicilioCodigoPostal.Location = New System.Drawing.Point(418, 3)
        Me.textboxDomicilioCodigoPostal.MaxLength = 8
        Me.textboxDomicilioCodigoPostal.Name = "textboxDomicilioCodigoPostal"
        Me.textboxDomicilioCodigoPostal.Size = New System.Drawing.Size(50, 20)
        Me.textboxDomicilioCodigoPostal.TabIndex = 3
        '
        'tabcontrolMain
        '
        Me.tabcontrolMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabcontrolMain.Controls.Add(Me.tabpageDetalle)
        Me.tabcontrolMain.Controls.Add(Me.tabpageImpuestos)
        Me.tabcontrolMain.Controls.Add(Me.tabpageAplicaciones)
        Me.tabcontrolMain.Controls.Add(Me.tabpageAsociaciones)
        Me.tabcontrolMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabcontrolMain.Location = New System.Drawing.Point(3, 181)
        Me.tabcontrolMain.Name = "tabcontrolMain"
        Me.tabcontrolMain.SelectedIndex = 0
        Me.tabcontrolMain.Size = New System.Drawing.Size(1206, 242)
        Me.tabcontrolMain.TabIndex = 5
        '
        'tabpageDetalle
        '
        Me.tabpageDetalle.Controls.Add(Me.datagridviewDetalle)
        Me.tabpageDetalle.Location = New System.Drawing.Point(4, 25)
        Me.tabpageDetalle.Name = "tabpageDetalle"
        Me.tabpageDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageDetalle.Size = New System.Drawing.Size(1198, 213)
        Me.tabpageDetalle.TabIndex = 0
        Me.tabpageDetalle.Text = "Detalle"
        Me.tabpageDetalle.UseVisualStyleBackColor = True
        '
        'datagridviewDetalle
        '
        Me.datagridviewDetalle.AllowUserToAddRows = False
        Me.datagridviewDetalle.AllowUserToDeleteRows = False
        Me.datagridviewDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewDetalle.Location = New System.Drawing.Point(3, 3)
        Me.datagridviewDetalle.Name = "datagridviewDetalle"
        Me.datagridviewDetalle.ReadOnly = True
        Me.datagridviewDetalle.Size = New System.Drawing.Size(1192, 207)
        Me.datagridviewDetalle.TabIndex = 5
        '
        'tabpageImpuestos
        '
        Me.tabpageImpuestos.Location = New System.Drawing.Point(4, 25)
        Me.tabpageImpuestos.Name = "tabpageImpuestos"
        Me.tabpageImpuestos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageImpuestos.Size = New System.Drawing.Size(1198, 213)
        Me.tabpageImpuestos.TabIndex = 1
        Me.tabpageImpuestos.Text = "Impuestos"
        Me.tabpageImpuestos.UseVisualStyleBackColor = True
        '
        'tabpageAplicaciones
        '
        Me.tabpageAplicaciones.Location = New System.Drawing.Point(4, 25)
        Me.tabpageAplicaciones.Name = "tabpageAplicaciones"
        Me.tabpageAplicaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageAplicaciones.Size = New System.Drawing.Size(1198, 213)
        Me.tabpageAplicaciones.TabIndex = 2
        Me.tabpageAplicaciones.Text = "Aplicaciones"
        Me.tabpageAplicaciones.UseVisualStyleBackColor = True
        '
        'tabpageAsociaciones
        '
        Me.tabpageAsociaciones.Location = New System.Drawing.Point(4, 25)
        Me.tabpageAsociaciones.Name = "tabpageAsociaciones"
        Me.tabpageAsociaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageAsociaciones.Size = New System.Drawing.Size(1198, 213)
        Me.tabpageAsociaciones.TabIndex = 3
        Me.tabpageAsociaciones.Text = "Asociaciones"
        Me.tabpageAsociaciones.UseVisualStyleBackColor = True
        '
        'panelPie
        '
        Me.panelPie.AutoSize = True
        Me.panelPie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelPie.Controls.Add(Me.panelSubtotales)
        Me.panelPie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelPie.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.panelPie.Location = New System.Drawing.Point(3, 429)
        Me.panelPie.Name = "panelPie"
        Me.panelPie.Padding = New System.Windows.Forms.Padding(4)
        Me.panelPie.Size = New System.Drawing.Size(1206, 43)
        Me.panelPie.TabIndex = 3
        '
        'panelSubtotales
        '
        Me.panelSubtotales.AutoSize = True
        Me.panelSubtotales.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelSubtotales.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelSubtotales.Controls.Add(Me.textboxImporteTotal)
        Me.panelSubtotales.Controls.Add(Me.labelImporteTotal)
        Me.panelSubtotales.Controls.Add(Me.textboxImporteImpuesto)
        Me.panelSubtotales.Controls.Add(Me.labelImporteImpuesto)
        Me.panelSubtotales.Controls.Add(Me.textboxImporteNeto)
        Me.panelSubtotales.Controls.Add(Me.labelImporteNeto)
        Me.panelSubtotales.Location = New System.Drawing.Point(689, 7)
        Me.panelSubtotales.Name = "panelSubtotales"
        Me.panelSubtotales.Size = New System.Drawing.Size(506, 29)
        Me.panelSubtotales.TabIndex = 3
        '
        'textboxImporteTotal
        '
        Me.textboxImporteTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textboxImporteTotal.Location = New System.Drawing.Point(396, 2)
        Me.textboxImporteTotal.Name = "textboxImporteTotal"
        Me.textboxImporteTotal.Size = New System.Drawing.Size(105, 22)
        Me.textboxImporteTotal.TabIndex = 7
        Me.textboxImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'labelImporteTotal
        '
        Me.labelImporteTotal.AutoSize = True
        Me.labelImporteTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelImporteTotal.Location = New System.Drawing.Point(342, 5)
        Me.labelImporteTotal.Name = "labelImporteTotal"
        Me.labelImporteTotal.Size = New System.Drawing.Size(48, 16)
        Me.labelImporteTotal.TabIndex = 6
        Me.labelImporteTotal.Text = "Total:"
        '
        'textboxImporteImpuesto
        '
        Me.textboxImporteImpuesto.Location = New System.Drawing.Point(232, 3)
        Me.textboxImporteImpuesto.Name = "textboxImporteImpuesto"
        Me.textboxImporteImpuesto.Size = New System.Drawing.Size(80, 20)
        Me.textboxImporteImpuesto.TabIndex = 3
        Me.textboxImporteImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'labelImporteImpuesto
        '
        Me.labelImporteImpuesto.AutoSize = True
        Me.labelImporteImpuesto.Location = New System.Drawing.Point(168, 6)
        Me.labelImporteImpuesto.Name = "labelImporteImpuesto"
        Me.labelImporteImpuesto.Size = New System.Drawing.Size(58, 13)
        Me.labelImporteImpuesto.TabIndex = 2
        Me.labelImporteImpuesto.Text = "Impuestos:"
        '
        'textboxImporteNeto
        '
        Me.textboxImporteNeto.Location = New System.Drawing.Point(58, 3)
        Me.textboxImporteNeto.Name = "textboxImporteNeto"
        Me.textboxImporteNeto.Size = New System.Drawing.Size(80, 20)
        Me.textboxImporteNeto.TabIndex = 1
        Me.textboxImporteNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'labelImporteNeto
        '
        Me.labelImporteNeto.AutoSize = True
        Me.labelImporteNeto.Location = New System.Drawing.Point(3, 6)
        Me.labelImporteNeto.Name = "labelImporteNeto"
        Me.labelImporteNeto.Size = New System.Drawing.Size(49, 13)
        Me.labelImporteNeto.TabIndex = 0
        Me.labelImporteNeto.Text = "Subtotal:"
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(1212, 39)
        Me.toolstripMain.TabIndex = 3
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
        'maskedtextboxDocumentoNumero
        '
        Me.maskedtextboxDocumentoNumero.AllowPromptAsInput = False
        Me.maskedtextboxDocumentoNumero.AsciiOnly = True
        Me.maskedtextboxDocumentoNumero.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.maskedtextboxDocumentoNumero.HidePromptOnLeave = True
        Me.maskedtextboxDocumentoNumero.Location = New System.Drawing.Point(182, 3)
        Me.maskedtextboxDocumentoNumero.Mask = "00-00000000-0"
        Me.maskedtextboxDocumentoNumero.Name = "maskedtextboxDocumentoNumero"
        Me.maskedtextboxDocumentoNumero.Size = New System.Drawing.Size(115, 20)
        Me.maskedtextboxDocumentoNumero.TabIndex = 17
        Me.maskedtextboxDocumentoNumero.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'formComprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1212, 514)
        Me.Controls.Add(Me.panelMain)
        Me.Controls.Add(Me.toolstripMain)
        Me.MinimumSize = New System.Drawing.Size(690, 38)
        Me.Name = "formComprobante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.panelMain.ResumeLayout(False)
        Me.panelMain.PerformLayout()
        Me.panelCabecera.ResumeLayout(False)
        Me.panelCabecera.PerformLayout()
        Me.panelIdentificacion.ResumeLayout(False)
        Me.panelIdentificacion.PerformLayout()
        Me.panelFechas.ResumeLayout(False)
        Me.panelFechas.PerformLayout()
        Me.panelEntidad.ResumeLayout(False)
        Me.panelEntidad.PerformLayout()
        Me.panelImpuesto.ResumeLayout(False)
        Me.panelImpuesto.PerformLayout()
        Me.panelDomicilio.ResumeLayout(False)
        Me.panelDomicilio.PerformLayout()
        Me.panelDomicilioExtra.ResumeLayout(False)
        Me.panelDomicilioExtra.PerformLayout()
        Me.panelProvincia.ResumeLayout(False)
        Me.panelProvincia.PerformLayout()
        Me.panelLocalidad.ResumeLayout(False)
        Me.panelLocalidad.PerformLayout()
        Me.tabcontrolMain.ResumeLayout(False)
        Me.tabpageDetalle.ResumeLayout(False)
        CType(Me.datagridviewDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelPie.ResumeLayout(False)
        Me.panelPie.PerformLayout()
        Me.panelSubtotales.ResumeLayout(False)
        Me.panelSubtotales.PerformLayout()
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents panelMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents panelCabecera As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents panelIdentificacion As System.Windows.Forms.Panel
    Friend WithEvents panelPie As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents panelSubtotales As System.Windows.Forms.Panel
    Friend WithEvents panelImpuesto As System.Windows.Forms.Panel
    Friend WithEvents textboxImporteTotal As System.Windows.Forms.TextBox
    Friend WithEvents labelImporteTotal As System.Windows.Forms.Label
    Friend WithEvents textboxImporteImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents labelImporteImpuesto As System.Windows.Forms.Label
    Friend WithEvents textboxImporteNeto As System.Windows.Forms.TextBox
    Friend WithEvents labelImporteNeto As System.Windows.Forms.Label
    Friend WithEvents textboxNumero As System.Windows.Forms.TextBox
    Friend WithEvents labelComprobanteNumero As System.Windows.Forms.Label
    Friend WithEvents datetimepickerFechaEmision As System.Windows.Forms.DateTimePicker
    Friend WithEvents labelFechaEmision As System.Windows.Forms.Label
    Friend WithEvents textboxIDComprobante As System.Windows.Forms.TextBox
    Friend WithEvents labelIDComprobante As System.Windows.Forms.Label
    Friend WithEvents panelEntidad As System.Windows.Forms.Panel
    Friend WithEvents buttonEntidad As System.Windows.Forms.Button
    Friend WithEvents textboxEntidad As System.Windows.Forms.TextBox
    Friend WithEvents labelEntidad As System.Windows.Forms.Label
    Friend WithEvents comboboxCategoriaIVA As System.Windows.Forms.ComboBox
    Friend WithEvents panelDomicilio As System.Windows.Forms.Panel
    Friend WithEvents textboxDomicilioDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents textboxDomicilioPiso As System.Windows.Forms.TextBox
    Friend WithEvents textboxDomicilioNumero As System.Windows.Forms.TextBox
    Friend WithEvents textboxDomicilioCalle1 As System.Windows.Forms.TextBox
    Friend WithEvents panelDomicilioExtra As System.Windows.Forms.Panel
    Friend WithEvents textboxDomicilioCalle3 As System.Windows.Forms.TextBox
    Friend WithEvents textboxDomicilioCalle2 As System.Windows.Forms.TextBox
    Friend WithEvents panelProvincia As System.Windows.Forms.Panel
    Friend WithEvents comboboxDomicilioProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents panelLocalidad As System.Windows.Forms.Panel
    Friend WithEvents comboboxDomicilioLocalidad As System.Windows.Forms.ComboBox
    Friend WithEvents textboxDomicilioCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents labelComprobanteTipo As System.Windows.Forms.Label
    Friend WithEvents comboboxComprobanteTipo As System.Windows.Forms.ComboBox
    Friend WithEvents textboxPuntoVenta As System.Windows.Forms.TextBox
    Friend WithEvents labelPuntoVenta As System.Windows.Forms.Label
    Friend WithEvents panelFechas As System.Windows.Forms.Panel
    Friend WithEvents datetimepickerFechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents labelFechaVencimiento As System.Windows.Forms.Label
    Friend WithEvents datetimepickerFechaServicioHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents datetimepickerFechaServicioDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents comboboxDocumentoTipo As System.Windows.Forms.ComboBox
    Friend WithEvents textboxDocumentoNumero As System.Windows.Forms.TextBox
    Friend WithEvents tabcontrolMain As System.Windows.Forms.TabControl
    Friend WithEvents tabpageDetalle As System.Windows.Forms.TabPage
    Friend WithEvents tabpageImpuestos As System.Windows.Forms.TabPage
    Friend WithEvents datagridviewDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents tabpageAplicaciones As System.Windows.Forms.TabPage
    Friend WithEvents tabpageAsociaciones As System.Windows.Forms.TabPage
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents maskedtextboxDocumentoNumero As System.Windows.Forms.MaskedTextBox
End Class
