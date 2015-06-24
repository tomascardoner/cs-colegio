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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.panelPie = New System.Windows.Forms.FlowLayoutPanel()
        Me.panelSubtotales = New System.Windows.Forms.Panel()
        Me.textboxImporteTotal = New System.Windows.Forms.TextBox()
        Me.labelImporteTotal = New System.Windows.Forms.Label()
        Me.textboxImporteIVA = New System.Windows.Forms.TextBox()
        Me.labelImporteIVA = New System.Windows.Forms.Label()
        Me.textboxImporteImpuesto = New System.Windows.Forms.TextBox()
        Me.labelImporteImpuesto = New System.Windows.Forms.Label()
        Me.textboxImporteNeto = New System.Windows.Forms.TextBox()
        Me.labelImporteNeto = New System.Windows.Forms.Label()
        Me.panelCabecera = New System.Windows.Forms.FlowLayoutPanel()
        Me.panelIdentificacion = New System.Windows.Forms.Panel()
        Me.comboboxComprobanteTipo = New System.Windows.Forms.ComboBox()
        Me.labelComprobanteTipo = New System.Windows.Forms.Label()
        Me.textboxComprobanteNumero = New System.Windows.Forms.TextBox()
        Me.labelComprobanteNumero = New System.Windows.Forms.Label()
        Me.datetimepickerFecha = New System.Windows.Forms.DateTimePicker()
        Me.labelFecha = New System.Windows.Forms.Label()
        Me.textboxIDComprobante = New System.Windows.Forms.TextBox()
        Me.labelIDComprobante = New System.Windows.Forms.Label()
        Me.panelEntidad = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.textboxEntidad = New System.Windows.Forms.TextBox()
        Me.labelEntidad = New System.Windows.Forms.Label()
        Me.panelImpuesto = New System.Windows.Forms.Panel()
        Me.comboboxCategoriaIVA = New System.Windows.Forms.ComboBox()
        Me.textboxCUIT = New System.Windows.Forms.TextBox()
        Me.labelCUIT = New System.Windows.Forms.Label()
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
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelPie.SuspendLayout()
        Me.panelSubtotales.SuspendLayout()
        Me.panelCabecera.SuspendLayout()
        Me.panelIdentificacion.SuspendLayout()
        Me.panelEntidad.SuspendLayout()
        Me.panelImpuesto.SuspendLayout()
        Me.panelDomicilio.SuspendLayout()
        Me.panelDomicilioExtra.SuspendLayout()
        Me.panelProvincia.SuspendLayout()
        Me.panelLocalidad.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelCategoriaIVA
        '
        labelCategoriaIVA.AutoSize = True
        labelCategoriaIVA.Location = New System.Drawing.Point(174, 6)
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
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DataGridView1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.panelPie, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.panelCabecera, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1212, 514)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 148)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1206, 314)
        Me.DataGridView1.TabIndex = 4
        '
        'panelPie
        '
        Me.panelPie.AutoSize = True
        Me.panelPie.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelPie.Controls.Add(Me.panelSubtotales)
        Me.panelPie.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelPie.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.panelPie.Location = New System.Drawing.Point(3, 468)
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
        Me.panelSubtotales.Controls.Add(Me.textboxImporteIVA)
        Me.panelSubtotales.Controls.Add(Me.labelImporteIVA)
        Me.panelSubtotales.Controls.Add(Me.textboxImporteImpuesto)
        Me.panelSubtotales.Controls.Add(Me.labelImporteImpuesto)
        Me.panelSubtotales.Controls.Add(Me.textboxImporteNeto)
        Me.panelSubtotales.Controls.Add(Me.labelImporteNeto)
        Me.panelSubtotales.Location = New System.Drawing.Point(546, 7)
        Me.panelSubtotales.Name = "panelSubtotales"
        Me.panelSubtotales.Size = New System.Drawing.Size(649, 29)
        Me.panelSubtotales.TabIndex = 3
        '
        'textboxImporteTotal
        '
        Me.textboxImporteTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textboxImporteTotal.Location = New System.Drawing.Point(539, 2)
        Me.textboxImporteTotal.Name = "textboxImporteTotal"
        Me.textboxImporteTotal.Size = New System.Drawing.Size(105, 22)
        Me.textboxImporteTotal.TabIndex = 7
        Me.textboxImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'labelImporteTotal
        '
        Me.labelImporteTotal.AutoSize = True
        Me.labelImporteTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelImporteTotal.Location = New System.Drawing.Point(485, 5)
        Me.labelImporteTotal.Name = "labelImporteTotal"
        Me.labelImporteTotal.Size = New System.Drawing.Size(48, 16)
        Me.labelImporteTotal.TabIndex = 6
        Me.labelImporteTotal.Text = "Total:"
        '
        'textboxImporteIVA
        '
        Me.textboxImporteIVA.Location = New System.Drawing.Point(375, 3)
        Me.textboxImporteIVA.Name = "textboxImporteIVA"
        Me.textboxImporteIVA.Size = New System.Drawing.Size(80, 20)
        Me.textboxImporteIVA.TabIndex = 5
        Me.textboxImporteIVA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'labelImporteIVA
        '
        Me.labelImporteIVA.AutoSize = True
        Me.labelImporteIVA.Location = New System.Drawing.Point(342, 6)
        Me.labelImporteIVA.Name = "labelImporteIVA"
        Me.labelImporteIVA.Size = New System.Drawing.Size(27, 13)
        Me.labelImporteIVA.TabIndex = 4
        Me.labelImporteIVA.Text = "IVA:"
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
        'panelCabecera
        '
        Me.panelCabecera.AutoSize = True
        Me.panelCabecera.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelCabecera.Controls.Add(Me.panelIdentificacion)
        Me.panelCabecera.Controls.Add(Me.panelEntidad)
        Me.panelCabecera.Controls.Add(Me.panelImpuesto)
        Me.panelCabecera.Controls.Add(Me.panelDomicilio)
        Me.panelCabecera.Controls.Add(Me.panelDomicilioExtra)
        Me.panelCabecera.Controls.Add(Me.panelProvincia)
        Me.panelCabecera.Controls.Add(Me.panelLocalidad)
        Me.panelCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelCabecera.Location = New System.Drawing.Point(3, 3)
        Me.panelCabecera.Name = "panelCabecera"
        Me.panelCabecera.Size = New System.Drawing.Size(1206, 139)
        Me.panelCabecera.TabIndex = 1
        '
        'panelIdentificacion
        '
        Me.panelIdentificacion.AutoSize = True
        Me.panelIdentificacion.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelIdentificacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelIdentificacion.Controls.Add(Me.comboboxComprobanteTipo)
        Me.panelIdentificacion.Controls.Add(Me.labelComprobanteTipo)
        Me.panelIdentificacion.Controls.Add(Me.textboxComprobanteNumero)
        Me.panelIdentificacion.Controls.Add(Me.labelComprobanteNumero)
        Me.panelIdentificacion.Controls.Add(Me.datetimepickerFecha)
        Me.panelIdentificacion.Controls.Add(Me.labelFecha)
        Me.panelIdentificacion.Controls.Add(Me.textboxIDComprobante)
        Me.panelIdentificacion.Controls.Add(Me.labelIDComprobante)
        Me.panelIdentificacion.Location = New System.Drawing.Point(3, 3)
        Me.panelIdentificacion.Name = "panelIdentificacion"
        Me.panelIdentificacion.Size = New System.Drawing.Size(661, 29)
        Me.panelIdentificacion.TabIndex = 0
        '
        'comboboxComprobanteTipo
        '
        Me.comboboxComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxComprobanteTipo.FormattingEnabled = True
        Me.comboboxComprobanteTipo.Location = New System.Drawing.Point(171, 3)
        Me.comboboxComprobanteTipo.Name = "comboboxComprobanteTipo"
        Me.comboboxComprobanteTipo.Size = New System.Drawing.Size(122, 21)
        Me.comboboxComprobanteTipo.TabIndex = 3
        '
        'labelComprobanteTipo
        '
        Me.labelComprobanteTipo.AutoSize = True
        Me.labelComprobanteTipo.Location = New System.Drawing.Point(134, 7)
        Me.labelComprobanteTipo.Name = "labelComprobanteTipo"
        Me.labelComprobanteTipo.Size = New System.Drawing.Size(31, 13)
        Me.labelComprobanteTipo.TabIndex = 2
        Me.labelComprobanteTipo.Text = "Tipo:"
        '
        'textboxComprobanteNumero
        '
        Me.textboxComprobanteNumero.Location = New System.Drawing.Point(376, 3)
        Me.textboxComprobanteNumero.MaxLength = 13
        Me.textboxComprobanteNumero.Name = "textboxComprobanteNumero"
        Me.textboxComprobanteNumero.Size = New System.Drawing.Size(100, 20)
        Me.textboxComprobanteNumero.TabIndex = 5
        '
        'labelComprobanteNumero
        '
        Me.labelComprobanteNumero.AutoSize = True
        Me.labelComprobanteNumero.Location = New System.Drawing.Point(323, 6)
        Me.labelComprobanteNumero.Name = "labelComprobanteNumero"
        Me.labelComprobanteNumero.Size = New System.Drawing.Size(47, 13)
        Me.labelComprobanteNumero.TabIndex = 4
        Me.labelComprobanteNumero.Text = "Número:"
        '
        'datetimepickerFecha
        '
        Me.datetimepickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerFecha.Location = New System.Drawing.Point(552, 3)
        Me.datetimepickerFecha.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerFecha.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerFecha.Name = "datetimepickerFecha"
        Me.datetimepickerFecha.Size = New System.Drawing.Size(104, 20)
        Me.datetimepickerFecha.TabIndex = 7
        '
        'labelFecha
        '
        Me.labelFecha.AutoSize = True
        Me.labelFecha.Location = New System.Drawing.Point(506, 6)
        Me.labelFecha.Name = "labelFecha"
        Me.labelFecha.Size = New System.Drawing.Size(40, 13)
        Me.labelFecha.TabIndex = 6
        Me.labelFecha.Text = "Fecha:"
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
        'panelEntidad
        '
        Me.panelEntidad.AutoSize = True
        Me.panelEntidad.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelEntidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelEntidad.Controls.Add(Me.Button1)
        Me.panelEntidad.Controls.Add(Me.textboxEntidad)
        Me.panelEntidad.Controls.Add(Me.labelEntidad)
        Me.panelEntidad.Location = New System.Drawing.Point(3, 38)
        Me.panelEntidad.Name = "panelEntidad"
        Me.panelEntidad.Size = New System.Drawing.Size(565, 29)
        Me.panelEntidad.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.Button1.Location = New System.Drawing.Point(538, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(22, 22)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "…"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.panelImpuesto.Controls.Add(Me.comboboxCategoriaIVA)
        Me.panelImpuesto.Controls.Add(labelCategoriaIVA)
        Me.panelImpuesto.Controls.Add(Me.textboxCUIT)
        Me.panelImpuesto.Controls.Add(Me.labelCUIT)
        Me.panelImpuesto.Location = New System.Drawing.Point(574, 38)
        Me.panelImpuesto.Name = "panelImpuesto"
        Me.panelImpuesto.Size = New System.Drawing.Size(477, 28)
        Me.panelImpuesto.TabIndex = 2
        '
        'comboboxCategoriaIVA
        '
        Me.comboboxCategoriaIVA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCategoriaIVA.FormattingEnabled = True
        Me.comboboxCategoriaIVA.Location = New System.Drawing.Point(272, 2)
        Me.comboboxCategoriaIVA.Name = "comboboxCategoriaIVA"
        Me.comboboxCategoriaIVA.Size = New System.Drawing.Size(200, 21)
        Me.comboboxCategoriaIVA.TabIndex = 3
        '
        'textboxCUIT
        '
        Me.textboxCUIT.Location = New System.Drawing.Point(44, 3)
        Me.textboxCUIT.MaxLength = 11
        Me.textboxCUIT.Name = "textboxCUIT"
        Me.textboxCUIT.Size = New System.Drawing.Size(100, 20)
        Me.textboxCUIT.TabIndex = 1
        '
        'labelCUIT
        '
        Me.labelCUIT.AutoSize = True
        Me.labelCUIT.Location = New System.Drawing.Point(3, 6)
        Me.labelCUIT.Name = "labelCUIT"
        Me.labelCUIT.Size = New System.Drawing.Size(35, 13)
        Me.labelCUIT.TabIndex = 0
        Me.labelCUIT.Text = "CUIT:"
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
        Me.panelDomicilio.Location = New System.Drawing.Point(3, 73)
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
        Me.panelDomicilioExtra.Location = New System.Drawing.Point(641, 73)
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
        Me.panelProvincia.Location = New System.Drawing.Point(3, 107)
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
        Me.panelLocalidad.Location = New System.Drawing.Point(335, 107)
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
        'formComprobante
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1212, 514)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.MinimumSize = New System.Drawing.Size(690, 38)
        Me.Name = "formComprobante"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelPie.ResumeLayout(False)
        Me.panelPie.PerformLayout()
        Me.panelSubtotales.ResumeLayout(False)
        Me.panelSubtotales.PerformLayout()
        Me.panelCabecera.ResumeLayout(False)
        Me.panelCabecera.PerformLayout()
        Me.panelIdentificacion.ResumeLayout(False)
        Me.panelIdentificacion.PerformLayout()
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents panelPie As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents panelSubtotales As System.Windows.Forms.Panel
    Friend WithEvents textboxImporteTotal As System.Windows.Forms.TextBox
    Friend WithEvents labelImporteTotal As System.Windows.Forms.Label
    Friend WithEvents textboxImporteIVA As System.Windows.Forms.TextBox
    Friend WithEvents labelImporteIVA As System.Windows.Forms.Label
    Friend WithEvents textboxImporteImpuesto As System.Windows.Forms.TextBox
    Friend WithEvents labelImporteImpuesto As System.Windows.Forms.Label
    Friend WithEvents textboxImporteNeto As System.Windows.Forms.TextBox
    Friend WithEvents labelImporteNeto As System.Windows.Forms.Label
    Friend WithEvents panelCabecera As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents panelIdentificacion As System.Windows.Forms.Panel
    Friend WithEvents textboxComprobanteNumero As System.Windows.Forms.TextBox
    Friend WithEvents labelComprobanteNumero As System.Windows.Forms.Label
    Friend WithEvents datetimepickerFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents labelFecha As System.Windows.Forms.Label
    Friend WithEvents textboxIDComprobante As System.Windows.Forms.TextBox
    Friend WithEvents labelIDComprobante As System.Windows.Forms.Label
    Friend WithEvents panelEntidad As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents textboxEntidad As System.Windows.Forms.TextBox
    Friend WithEvents labelEntidad As System.Windows.Forms.Label
    Friend WithEvents panelImpuesto As System.Windows.Forms.Panel
    Friend WithEvents comboboxCategoriaIVA As System.Windows.Forms.ComboBox
    Friend WithEvents textboxCUIT As System.Windows.Forms.TextBox
    Friend WithEvents labelCUIT As System.Windows.Forms.Label
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
End Class
