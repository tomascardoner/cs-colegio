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
        Dim labelFechaServicioDesde As System.Windows.Forms.Label
        Dim labelFechaServicioHasta As System.Windows.Forms.Label
        Dim labelNotas As System.Windows.Forms.Label
        Dim labelModificacion As System.Windows.Forms.Label
        Dim labelCreacion As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.tabcontrolMain = New System.Windows.Forms.TabControl()
        Me.tabpageDetalle = New System.Windows.Forms.TabPage()
        Me.datagridviewDetalle = New System.Windows.Forms.DataGridView()
        Me.tabpageImpuestos = New System.Windows.Forms.TabPage()
        Me.tabpageAplicaciones = New System.Windows.Forms.TabPage()
        Me.tabpageAsociaciones = New System.Windows.Forms.TabPage()
        Me.tabpageNotasAuditoria = New System.Windows.Forms.TabPage()
        Me.textboxNotas = New System.Windows.Forms.TextBox()
        Me.textboxUsuarioModificacion = New System.Windows.Forms.TextBox()
        Me.textboxUsuarioCreacion = New System.Windows.Forms.TextBox()
        Me.textboxFechaHoraModificacion = New System.Windows.Forms.TextBox()
        Me.textboxFechaHoraCreacion = New System.Windows.Forms.TextBox()
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
        Me.columnDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPrecioUnitario = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPrecioUnitarioDescuentoPorcentaje = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columntPrecioUnitarioDescuentoImporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPrecioTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        labelFechaServicioDesde = New System.Windows.Forms.Label()
        labelFechaServicioHasta = New System.Windows.Forms.Label()
        labelNotas = New System.Windows.Forms.Label()
        labelModificacion = New System.Windows.Forms.Label()
        labelCreacion = New System.Windows.Forms.Label()
        Me.panelMain.SuspendLayout()
        Me.panelCabecera.SuspendLayout()
        Me.panelIdentificacion.SuspendLayout()
        Me.panelFechas.SuspendLayout()
        Me.panelEntidad.SuspendLayout()
        Me.tabcontrolMain.SuspendLayout()
        Me.tabpageDetalle.SuspendLayout()
        CType(Me.datagridviewDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabpageNotasAuditoria.SuspendLayout()
        Me.panelPie.SuspendLayout()
        Me.panelSubtotales.SuspendLayout()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
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
        labelFechaServicioHasta.TabIndex = 4
        labelFechaServicioHasta.Text = "Hasta:"
        '
        'labelNotas
        '
        labelNotas.AutoSize = True
        labelNotas.Location = New System.Drawing.Point(5, 9)
        labelNotas.Name = "labelNotas"
        labelNotas.Size = New System.Drawing.Size(38, 13)
        labelNotas.TabIndex = 23
        labelNotas.Text = "Notas:"
        '
        'labelModificacion
        '
        labelModificacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        labelModificacion.AutoSize = True
        labelModificacion.Location = New System.Drawing.Point(5, 259)
        labelModificacion.Name = "labelModificacion"
        labelModificacion.Size = New System.Drawing.Size(102, 13)
        labelModificacion.TabIndex = 20
        labelModificacion.Text = "Ultima Modificación:"
        '
        'labelCreacion
        '
        labelCreacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        labelCreacion.AutoSize = True
        labelCreacion.Location = New System.Drawing.Point(5, 237)
        labelCreacion.Name = "labelCreacion"
        labelCreacion.Size = New System.Drawing.Size(52, 13)
        labelCreacion.TabIndex = 17
        labelCreacion.Text = "Creación:"
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
        Me.panelCabecera.Dock = System.Windows.Forms.DockStyle.Fill
        Me.panelCabecera.Location = New System.Drawing.Point(3, 3)
        Me.panelCabecera.Name = "panelCabecera"
        Me.panelCabecera.Size = New System.Drawing.Size(1206, 103)
        Me.panelCabecera.TabIndex = 0
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
        Me.panelIdentificacion.Size = New System.Drawing.Size(793, 29)
        Me.panelIdentificacion.TabIndex = 0
        '
        'textboxPuntoVenta
        '
        Me.textboxPuntoVenta.Location = New System.Drawing.Point(407, 3)
        Me.textboxPuntoVenta.MaxLength = 4
        Me.textboxPuntoVenta.Name = "textboxPuntoVenta"
        Me.textboxPuntoVenta.Size = New System.Drawing.Size(38, 20)
        Me.textboxPuntoVenta.TabIndex = 5
        Me.textboxPuntoVenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'labelPuntoVenta
        '
        Me.labelPuntoVenta.AutoSize = True
        Me.labelPuntoVenta.Location = New System.Drawing.Point(317, 6)
        Me.labelPuntoVenta.Name = "labelPuntoVenta"
        Me.labelPuntoVenta.Size = New System.Drawing.Size(84, 13)
        Me.labelPuntoVenta.TabIndex = 4
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
        Me.textboxNumero.Location = New System.Drawing.Point(510, 3)
        Me.textboxNumero.MaxLength = 8
        Me.textboxNumero.Name = "textboxNumero"
        Me.textboxNumero.Size = New System.Drawing.Size(62, 20)
        Me.textboxNumero.TabIndex = 7
        Me.textboxNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'labelComprobanteNumero
        '
        Me.labelComprobanteNumero.AutoSize = True
        Me.labelComprobanteNumero.Location = New System.Drawing.Point(457, 6)
        Me.labelComprobanteNumero.Name = "labelComprobanteNumero"
        Me.labelComprobanteNumero.Size = New System.Drawing.Size(47, 13)
        Me.labelComprobanteNumero.TabIndex = 6
        Me.labelComprobanteNumero.Text = "Número:"
        '
        'datetimepickerFechaEmision
        '
        Me.datetimepickerFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerFechaEmision.Location = New System.Drawing.Point(684, 3)
        Me.datetimepickerFechaEmision.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerFechaEmision.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerFechaEmision.Name = "datetimepickerFechaEmision"
        Me.datetimepickerFechaEmision.Size = New System.Drawing.Size(104, 20)
        Me.datetimepickerFechaEmision.TabIndex = 9
        '
        'labelFechaEmision
        '
        Me.labelFechaEmision.AutoSize = True
        Me.labelFechaEmision.Location = New System.Drawing.Point(584, 6)
        Me.labelFechaEmision.Name = "labelFechaEmision"
        Me.labelFechaEmision.Size = New System.Drawing.Size(94, 13)
        Me.labelFechaEmision.TabIndex = 8
        Me.labelFechaEmision.Text = "Fecha de Emisión:"
        '
        'textboxIDComprobante
        '
        Me.textboxIDComprobante.Location = New System.Drawing.Point(30, 3)
        Me.textboxIDComprobante.MaxLength = 7
        Me.textboxIDComprobante.Name = "textboxIDComprobante"
        Me.textboxIDComprobante.Size = New System.Drawing.Size(74, 20)
        Me.textboxIDComprobante.TabIndex = 1
        Me.textboxIDComprobante.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        Me.panelFechas.TabIndex = 1
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
        Me.datetimepickerFechaServicioHasta.TabIndex = 5
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
        Me.datetimepickerFechaServicioDesde.TabIndex = 3
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
        Me.datetimepickerFechaVencimiento.TabIndex = 1
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
        Me.panelEntidad.TabIndex = 2
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
        Me.textboxEntidad.ReadOnly = True
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
        'tabcontrolMain
        '
        Me.tabcontrolMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabcontrolMain.Controls.Add(Me.tabpageDetalle)
        Me.tabcontrolMain.Controls.Add(Me.tabpageImpuestos)
        Me.tabcontrolMain.Controls.Add(Me.tabpageAplicaciones)
        Me.tabcontrolMain.Controls.Add(Me.tabpageAsociaciones)
        Me.tabcontrolMain.Controls.Add(Me.tabpageNotasAuditoria)
        Me.tabcontrolMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabcontrolMain.Location = New System.Drawing.Point(3, 112)
        Me.tabcontrolMain.Name = "tabcontrolMain"
        Me.tabcontrolMain.SelectedIndex = 0
        Me.tabcontrolMain.Size = New System.Drawing.Size(1206, 311)
        Me.tabcontrolMain.TabIndex = 1
        '
        'tabpageDetalle
        '
        Me.tabpageDetalle.Controls.Add(Me.datagridviewDetalle)
        Me.tabpageDetalle.Location = New System.Drawing.Point(4, 25)
        Me.tabpageDetalle.Name = "tabpageDetalle"
        Me.tabpageDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageDetalle.Size = New System.Drawing.Size(1198, 282)
        Me.tabpageDetalle.TabIndex = 0
        Me.tabpageDetalle.Text = "Detalle"
        Me.tabpageDetalle.UseVisualStyleBackColor = True
        '
        'datagridviewDetalle
        '
        Me.datagridviewDetalle.AllowUserToAddRows = False
        Me.datagridviewDetalle.AllowUserToDeleteRows = False
        Me.datagridviewDetalle.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnDescripcion, Me.columnPrecioUnitario, Me.columnPrecioUnitarioDescuentoPorcentaje, Me.columntPrecioUnitarioDescuentoImporte, Me.columnPrecioTotal})
        Me.datagridviewDetalle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewDetalle.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datagridviewDetalle.Location = New System.Drawing.Point(3, 3)
        Me.datagridviewDetalle.MultiSelect = False
        Me.datagridviewDetalle.Name = "datagridviewDetalle"
        Me.datagridviewDetalle.ReadOnly = True
        Me.datagridviewDetalle.RowHeadersVisible = False
        Me.datagridviewDetalle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewDetalle.Size = New System.Drawing.Size(1192, 276)
        Me.datagridviewDetalle.TabIndex = 0
        '
        'tabpageImpuestos
        '
        Me.tabpageImpuestos.Location = New System.Drawing.Point(4, 25)
        Me.tabpageImpuestos.Name = "tabpageImpuestos"
        Me.tabpageImpuestos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageImpuestos.Size = New System.Drawing.Size(1198, 282)
        Me.tabpageImpuestos.TabIndex = 1
        Me.tabpageImpuestos.Text = "Impuestos"
        Me.tabpageImpuestos.UseVisualStyleBackColor = True
        '
        'tabpageAplicaciones
        '
        Me.tabpageAplicaciones.Location = New System.Drawing.Point(4, 25)
        Me.tabpageAplicaciones.Name = "tabpageAplicaciones"
        Me.tabpageAplicaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageAplicaciones.Size = New System.Drawing.Size(1198, 282)
        Me.tabpageAplicaciones.TabIndex = 2
        Me.tabpageAplicaciones.Text = "Aplicaciones"
        Me.tabpageAplicaciones.UseVisualStyleBackColor = True
        '
        'tabpageAsociaciones
        '
        Me.tabpageAsociaciones.Location = New System.Drawing.Point(4, 25)
        Me.tabpageAsociaciones.Name = "tabpageAsociaciones"
        Me.tabpageAsociaciones.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageAsociaciones.Size = New System.Drawing.Size(1198, 282)
        Me.tabpageAsociaciones.TabIndex = 3
        Me.tabpageAsociaciones.Text = "Asociaciones"
        Me.tabpageAsociaciones.UseVisualStyleBackColor = True
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
        Me.tabpageNotasAuditoria.Size = New System.Drawing.Size(1198, 282)
        Me.tabpageNotasAuditoria.TabIndex = 4
        Me.tabpageNotasAuditoria.Text = "Notas y Auditoría"
        Me.tabpageNotasAuditoria.UseVisualStyleBackColor = True
        '
        'textboxNotas
        '
        Me.textboxNotas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxNotas.Location = New System.Drawing.Point(113, 6)
        Me.textboxNotas.MaxLength = 0
        Me.textboxNotas.Multiline = True
        Me.textboxNotas.Name = "textboxNotas"
        Me.textboxNotas.Size = New System.Drawing.Size(1079, 218)
        Me.textboxNotas.TabIndex = 24
        '
        'textboxUsuarioModificacion
        '
        Me.textboxUsuarioModificacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.textboxUsuarioModificacion.Location = New System.Drawing.Point(240, 256)
        Me.textboxUsuarioModificacion.MaxLength = 50
        Me.textboxUsuarioModificacion.Name = "textboxUsuarioModificacion"
        Me.textboxUsuarioModificacion.ReadOnly = True
        Me.textboxUsuarioModificacion.Size = New System.Drawing.Size(259, 20)
        Me.textboxUsuarioModificacion.TabIndex = 22
        '
        'textboxUsuarioCreacion
        '
        Me.textboxUsuarioCreacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.textboxUsuarioCreacion.Location = New System.Drawing.Point(240, 230)
        Me.textboxUsuarioCreacion.MaxLength = 50
        Me.textboxUsuarioCreacion.Name = "textboxUsuarioCreacion"
        Me.textboxUsuarioCreacion.ReadOnly = True
        Me.textboxUsuarioCreacion.Size = New System.Drawing.Size(259, 20)
        Me.textboxUsuarioCreacion.TabIndex = 19
        '
        'textboxFechaHoraModificacion
        '
        Me.textboxFechaHoraModificacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.textboxFechaHoraModificacion.Location = New System.Drawing.Point(113, 256)
        Me.textboxFechaHoraModificacion.MaxLength = 0
        Me.textboxFechaHoraModificacion.Name = "textboxFechaHoraModificacion"
        Me.textboxFechaHoraModificacion.ReadOnly = True
        Me.textboxFechaHoraModificacion.Size = New System.Drawing.Size(121, 20)
        Me.textboxFechaHoraModificacion.TabIndex = 21
        '
        'textboxFechaHoraCreacion
        '
        Me.textboxFechaHoraCreacion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.textboxFechaHoraCreacion.Location = New System.Drawing.Point(113, 230)
        Me.textboxFechaHoraCreacion.MaxLength = 0
        Me.textboxFechaHoraCreacion.Name = "textboxFechaHoraCreacion"
        Me.textboxFechaHoraCreacion.ReadOnly = True
        Me.textboxFechaHoraCreacion.Size = New System.Drawing.Size(121, 20)
        Me.textboxFechaHoraCreacion.TabIndex = 18
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
        Me.panelPie.TabIndex = 2
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
        Me.panelSubtotales.TabIndex = 0
        '
        'textboxImporteTotal
        '
        Me.textboxImporteTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textboxImporteTotal.Location = New System.Drawing.Point(396, 2)
        Me.textboxImporteTotal.Name = "textboxImporteTotal"
        Me.textboxImporteTotal.Size = New System.Drawing.Size(105, 22)
        Me.textboxImporteTotal.TabIndex = 5
        Me.textboxImporteTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'labelImporteTotal
        '
        Me.labelImporteTotal.AutoSize = True
        Me.labelImporteTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelImporteTotal.Location = New System.Drawing.Point(342, 5)
        Me.labelImporteTotal.Name = "labelImporteTotal"
        Me.labelImporteTotal.Size = New System.Drawing.Size(48, 16)
        Me.labelImporteTotal.TabIndex = 4
        Me.labelImporteTotal.Text = "Total:"
        '
        'textboxImporteImpuesto
        '
        Me.textboxImporteImpuesto.Location = New System.Drawing.Point(232, 3)
        Me.textboxImporteImpuesto.Name = "textboxImporteImpuesto"
        Me.textboxImporteImpuesto.ReadOnly = True
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
        'columnDescripcion
        '
        Me.columnDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnDescripcion.DataPropertyName = "Descripcion"
        Me.columnDescripcion.HeaderText = "Descripción"
        Me.columnDescripcion.Name = "columnDescripcion"
        Me.columnDescripcion.ReadOnly = True
        Me.columnDescripcion.Width = 88
        '
        'columnPrecioUnitario
        '
        Me.columnPrecioUnitario.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPrecioUnitario.DataPropertyName = "PrecioUnitario"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.columnPrecioUnitario.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnPrecioUnitario.HeaderText = "Precio Unitario"
        Me.columnPrecioUnitario.Name = "columnPrecioUnitario"
        Me.columnPrecioUnitario.ReadOnly = True
        Me.columnPrecioUnitario.Width = 101
        '
        'columnPrecioUnitarioDescuentoPorcentaje
        '
        Me.columnPrecioUnitarioDescuentoPorcentaje.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPrecioUnitarioDescuentoPorcentaje.DataPropertyName = "PrecioUnitarioDescuentoPorcentaje"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "0.00"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.columnPrecioUnitarioDescuentoPorcentaje.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnPrecioUnitarioDescuentoPorcentaje.HeaderText = "% Descuento"
        Me.columnPrecioUnitarioDescuentoPorcentaje.Name = "columnPrecioUnitarioDescuentoPorcentaje"
        Me.columnPrecioUnitarioDescuentoPorcentaje.ReadOnly = True
        Me.columnPrecioUnitarioDescuentoPorcentaje.Width = 95
        '
        'columntPrecioUnitarioDescuentoImporte
        '
        Me.columntPrecioUnitarioDescuentoImporte.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columntPrecioUnitarioDescuentoImporte.DataPropertyName = "PrecioUnitarioDescuentoImporte"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.columntPrecioUnitarioDescuentoImporte.DefaultCellStyle = DataGridViewCellStyle4
        Me.columntPrecioUnitarioDescuentoImporte.HeaderText = "$ Descuento"
        Me.columntPrecioUnitarioDescuentoImporte.Name = "columntPrecioUnitarioDescuentoImporte"
        Me.columntPrecioUnitarioDescuentoImporte.ReadOnly = True
        Me.columntPrecioUnitarioDescuentoImporte.Width = 93
        '
        'columnPrecioTotal
        '
        Me.columnPrecioTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPrecioTotal.DataPropertyName = "PrecioTotal"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.columnPrecioTotal.DefaultCellStyle = DataGridViewCellStyle5
        Me.columnPrecioTotal.HeaderText = "Subtotal"
        Me.columnPrecioTotal.Name = "columnPrecioTotal"
        Me.columnPrecioTotal.ReadOnly = True
        Me.columnPrecioTotal.Width = 71
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
        Me.Text = "Detalle del Comprobante"
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
        Me.tabcontrolMain.ResumeLayout(False)
        Me.tabpageDetalle.ResumeLayout(False)
        CType(Me.datagridviewDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabpageNotasAuditoria.ResumeLayout(False)
        Me.tabpageNotasAuditoria.PerformLayout()
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
    Friend WithEvents labelComprobanteTipo As System.Windows.Forms.Label
    Friend WithEvents comboboxComprobanteTipo As System.Windows.Forms.ComboBox
    Friend WithEvents textboxPuntoVenta As System.Windows.Forms.TextBox
    Friend WithEvents labelPuntoVenta As System.Windows.Forms.Label
    Friend WithEvents panelFechas As System.Windows.Forms.Panel
    Friend WithEvents datetimepickerFechaVencimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents labelFechaVencimiento As System.Windows.Forms.Label
    Friend WithEvents datetimepickerFechaServicioHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents datetimepickerFechaServicioDesde As System.Windows.Forms.DateTimePicker
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
    Friend WithEvents tabpageNotasAuditoria As System.Windows.Forms.TabPage
    Friend WithEvents textboxNotas As System.Windows.Forms.TextBox
    Friend WithEvents textboxUsuarioModificacion As System.Windows.Forms.TextBox
    Friend WithEvents textboxUsuarioCreacion As System.Windows.Forms.TextBox
    Friend WithEvents textboxFechaHoraModificacion As System.Windows.Forms.TextBox
    Friend WithEvents textboxFechaHoraCreacion As System.Windows.Forms.TextBox
    Friend WithEvents columnDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPrecioUnitario As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPrecioUnitarioDescuentoPorcentaje As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columntPrecioUnitarioDescuentoImporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPrecioTotal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
