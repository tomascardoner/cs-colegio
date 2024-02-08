<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formComprobantes
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formComprobantes))
        Me.statuslabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusstripMain = New System.Windows.Forms.StatusStrip()
        Me.datagridviewMain = New System.Windows.Forms.DataGridView()
        Me.columnTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNumeroCompleto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnEntidadNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnCAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelToolbars = New System.Windows.Forms.FlowLayoutPanel()
        Me.toolstripButtons = New System.Windows.Forms.ToolStrip()
        Me.buttonAgregar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonAnular = New System.Windows.Forms.ToolStripButton()
        Me.buttonEliminar = New System.Windows.Forms.ToolStripButton()
        Me.buttonImprimir = New System.Windows.Forms.ToolStripSplitButton()
        Me.menuitemImprimirPrevisualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemImprimirListadoDeComprobantes = New System.Windows.Forms.ToolStripMenuItem()
        Me.buttonEnviarEmail = New System.Windows.Forms.ToolStripButton()
        Me.toolstripPeriodo = New System.Windows.Forms.ToolStrip()
        Me.labelPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxPeriodoTipo = New System.Windows.Forms.ToolStripComboBox()
        Me.comboboxPeriodoValor = New System.Windows.Forms.ToolStripComboBox()
        Me.labelPeriodoFechaY = New System.Windows.Forms.ToolStripLabel()
        Me.toolstripComprobanteTipo = New System.Windows.Forms.ToolStrip()
        Me.labelComprobanteTipo = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxOperacionTipo = New System.Windows.Forms.ToolStripComboBox()
        Me.comboboxComprobanteTipo = New System.Windows.Forms.ToolStripComboBox()
        Me.toolstripComprobanteLote = New System.Windows.Forms.ToolStrip()
        Me.labelComprobanteLote = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxComprobanteLote = New System.Windows.Forms.ToolStripComboBox()
        Me.toolstripTitular = New System.Windows.Forms.ToolStrip()
        Me.labelEntidad = New System.Windows.Forms.ToolStripLabel()
        Me.textboxEntidad = New System.Windows.Forms.ToolStripTextBox()
        Me.buttonEntidad = New System.Windows.Forms.ToolStripButton()
        Me.buttonEntidadBorrar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripBuscar = New System.Windows.Forms.ToolStrip()
        Me.labelBuscar = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxBuscarTipo = New System.Windows.Forms.ToolStripComboBox()
        Me.textboxBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.buttonBuscarBorrar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripTareas = New System.Windows.Forms.ToolStrip()
        Me.dropdownbuttonTareas = New System.Windows.Forms.ToolStripDropDownButton()
        Me.menuitemGenerarCódigosBarrasSEPSA = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemGenerarCodigosQR = New System.Windows.Forms.ToolStripMenuItem()
        Me.statusstripMain.SuspendLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelToolbars.SuspendLayout()
        Me.toolstripButtons.SuspendLayout()
        Me.toolstripPeriodo.SuspendLayout()
        Me.toolstripComprobanteTipo.SuspendLayout()
        Me.toolstripComprobanteLote.SuspendLayout()
        Me.toolstripTitular.SuspendLayout()
        Me.toolstripBuscar.SuspendLayout()
        Me.toolstripTareas.SuspendLayout()
        Me.SuspendLayout()
        '
        'statuslabelMain
        '
        Me.statuslabelMain.Name = "statuslabelMain"
        Me.statuslabelMain.Size = New System.Drawing.Size(1013, 17)
        Me.statuslabelMain.Spring = True
        Me.statuslabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'statusstripMain
        '
        Me.statusstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.statusstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statuslabelMain})
        Me.statusstripMain.Location = New System.Drawing.Point(0, 389)
        Me.statusstripMain.Name = "statusstripMain"
        Me.statusstripMain.Size = New System.Drawing.Size(1028, 22)
        Me.statusstripMain.TabIndex = 4
        '
        'datagridviewMain
        '
        Me.datagridviewMain.AllowUserToAddRows = False
        Me.datagridviewMain.AllowUserToDeleteRows = False
        Me.datagridviewMain.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnTipo, Me.columnNumeroCompleto, Me.columnFecha, Me.columnEntidadNombre, Me.columnImporteTotal, Me.columnCAE})
        Me.datagridviewMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datagridviewMain.Location = New System.Drawing.Point(0, 93)
        Me.datagridviewMain.MultiSelect = False
        Me.datagridviewMain.Name = "datagridviewMain"
        Me.datagridviewMain.ReadOnly = True
        Me.datagridviewMain.RowHeadersVisible = False
        Me.datagridviewMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewMain.Size = New System.Drawing.Size(1028, 296)
        Me.datagridviewMain.TabIndex = 0
        '
        'columnTipo
        '
        Me.columnTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTipo.DataPropertyName = "ComprobanteTipoNombre"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnTipo.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnTipo.HeaderText = "Tipo"
        Me.columnTipo.Name = "columnTipo"
        Me.columnTipo.ReadOnly = True
        Me.columnTipo.Width = 53
        '
        'columnNumeroCompleto
        '
        Me.columnNumeroCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNumeroCompleto.DataPropertyName = "NumeroCompleto"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnNumeroCompleto.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnNumeroCompleto.HeaderText = "Número"
        Me.columnNumeroCompleto.Name = "columnNumeroCompleto"
        Me.columnNumeroCompleto.ReadOnly = True
        Me.columnNumeroCompleto.Width = 69
        '
        'columnFecha
        '
        Me.columnFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnFecha.DataPropertyName = "FechaEmision"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnFecha.DefaultCellStyle = DataGridViewCellStyle4
        Me.columnFecha.HeaderText = "Fecha"
        Me.columnFecha.Name = "columnFecha"
        Me.columnFecha.ReadOnly = True
        Me.columnFecha.Width = 62
        '
        'columnEntidadNombre
        '
        Me.columnEntidadNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnEntidadNombre.DataPropertyName = "EntidadNombre"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnEntidadNombre.DefaultCellStyle = DataGridViewCellStyle5
        Me.columnEntidadNombre.HeaderText = "Titular"
        Me.columnEntidadNombre.Name = "columnEntidadNombre"
        Me.columnEntidadNombre.ReadOnly = True
        Me.columnEntidadNombre.Width = 61
        '
        'columnImporteTotal
        '
        Me.columnImporteTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.columnImporteTotal.DefaultCellStyle = DataGridViewCellStyle6
        Me.columnImporteTotal.HeaderText = "Importe Total"
        Me.columnImporteTotal.Name = "columnImporteTotal"
        Me.columnImporteTotal.ReadOnly = True
        Me.columnImporteTotal.Width = 94
        '
        'columnCAE
        '
        Me.columnCAE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnCAE.DataPropertyName = "CAE"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnCAE.DefaultCellStyle = DataGridViewCellStyle7
        Me.columnCAE.HeaderText = "CAE"
        Me.columnCAE.Name = "columnCAE"
        Me.columnCAE.ReadOnly = True
        Me.columnCAE.Width = 53
        '
        'panelToolbars
        '
        Me.panelToolbars.AutoSize = True
        Me.panelToolbars.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelToolbars.Controls.Add(Me.toolstripButtons)
        Me.panelToolbars.Controls.Add(Me.toolstripPeriodo)
        Me.panelToolbars.Controls.Add(Me.toolstripComprobanteTipo)
        Me.panelToolbars.Controls.Add(Me.toolstripComprobanteLote)
        Me.panelToolbars.Controls.Add(Me.toolstripTitular)
        Me.panelToolbars.Controls.Add(Me.toolstripBuscar)
        Me.panelToolbars.Controls.Add(Me.toolstripTareas)
        Me.panelToolbars.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelToolbars.Location = New System.Drawing.Point(0, 0)
        Me.panelToolbars.Name = "panelToolbars"
        Me.panelToolbars.Size = New System.Drawing.Size(1028, 93)
        Me.panelToolbars.TabIndex = 0
        '
        'toolstripButtons
        '
        Me.toolstripButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripButtons.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonAgregar, Me.buttonEditar, Me.buttonAnular, Me.buttonEliminar, Me.buttonImprimir, Me.buttonEnviarEmail})
        Me.toolstripButtons.Location = New System.Drawing.Point(0, 0)
        Me.toolstripButtons.Name = "toolstripButtons"
        Me.toolstripButtons.Size = New System.Drawing.Size(559, 39)
        Me.toolstripButtons.TabIndex = 1
        '
        'buttonAgregar
        '
        Me.buttonAgregar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_ADD_32
        Me.buttonAgregar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonAgregar.Name = "buttonAgregar"
        Me.buttonAgregar.Size = New System.Drawing.Size(85, 36)
        Me.buttonAgregar.Text = "Agregar"
        '
        'buttonEditar
        '
        Me.buttonEditar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_EDIT_32
        Me.buttonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEditar.Name = "buttonEditar"
        Me.buttonEditar.Size = New System.Drawing.Size(73, 36)
        Me.buttonEditar.Text = "Editar"
        '
        'buttonAnular
        '
        Me.buttonAnular.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageCancelar32
        Me.buttonAnular.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonAnular.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonAnular.Name = "buttonAnular"
        Me.buttonAnular.Size = New System.Drawing.Size(78, 36)
        Me.buttonAnular.Text = "Anular"
        '
        'buttonEliminar
        '
        Me.buttonEliminar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_DELETE_32
        Me.buttonEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEliminar.Name = "buttonEliminar"
        Me.buttonEliminar.Size = New System.Drawing.Size(86, 36)
        Me.buttonEliminar.Text = "Eliminar"
        '
        'buttonImprimir
        '
        Me.buttonImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemImprimirPrevisualizar, Me.menuitemImprimirListadoDeComprobantes})
        Me.buttonImprimir.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_PRINT_32
        Me.buttonImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonImprimir.Name = "buttonImprimir"
        Me.buttonImprimir.Size = New System.Drawing.Size(101, 36)
        Me.buttonImprimir.Text = "Imprimir"
        '
        'menuitemImprimirPrevisualizar
        '
        Me.menuitemImprimirPrevisualizar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_PRINT_PREVIEW_32
        Me.menuitemImprimirPrevisualizar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.menuitemImprimirPrevisualizar.Name = "menuitemImprimirPrevisualizar"
        Me.menuitemImprimirPrevisualizar.Size = New System.Drawing.Size(226, 38)
        Me.menuitemImprimirPrevisualizar.Text = "Previsualizar"
        '
        'menuitemImprimirListadoDeComprobantes
        '
        Me.menuitemImprimirListadoDeComprobantes.Name = "menuitemImprimirListadoDeComprobantes"
        Me.menuitemImprimirListadoDeComprobantes.Size = New System.Drawing.Size(226, 38)
        Me.menuitemImprimirListadoDeComprobantes.Text = "Listado de Comprobantes"
        '
        'buttonEnviarEmail
        '
        Me.buttonEnviarEmail.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_EMAIL_32
        Me.buttonEnviarEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEnviarEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEnviarEmail.Name = "buttonEnviarEmail"
        Me.buttonEnviarEmail.Size = New System.Drawing.Size(133, 36)
        Me.buttonEnviarEmail.Text = "Enviar por e-mail"
        '
        'toolstripPeriodo
        '
        Me.toolstripPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripPeriodo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripPeriodo.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripPeriodo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelPeriodo, Me.comboboxPeriodoTipo, Me.comboboxPeriodoValor, Me.labelPeriodoFechaY})
        Me.toolstripPeriodo.Location = New System.Drawing.Point(559, 0)
        Me.toolstripPeriodo.Name = "toolstripPeriodo"
        Me.toolstripPeriodo.Size = New System.Drawing.Size(267, 39)
        Me.toolstripPeriodo.TabIndex = 8
        '
        'labelPeriodo
        '
        Me.labelPeriodo.Name = "labelPeriodo"
        Me.labelPeriodo.Size = New System.Drawing.Size(51, 36)
        Me.labelPeriodo.Text = "Período:"
        '
        'comboboxPeriodoTipo
        '
        Me.comboboxPeriodoTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxPeriodoTipo.Name = "comboboxPeriodoTipo"
        Me.comboboxPeriodoTipo.Size = New System.Drawing.Size(75, 39)
        '
        'comboboxPeriodoValor
        '
        Me.comboboxPeriodoValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxPeriodoValor.Name = "comboboxPeriodoValor"
        Me.comboboxPeriodoValor.Size = New System.Drawing.Size(121, 39)
        '
        'labelPeriodoFechaY
        '
        Me.labelPeriodoFechaY.Name = "labelPeriodoFechaY"
        Me.labelPeriodoFechaY.Size = New System.Drawing.Size(13, 36)
        Me.labelPeriodoFechaY.Text = "y"
        '
        'toolstripComprobanteTipo
        '
        Me.toolstripComprobanteTipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripComprobanteTipo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripComprobanteTipo.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripComprobanteTipo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelComprobanteTipo, Me.comboboxOperacionTipo, Me.comboboxComprobanteTipo})
        Me.toolstripComprobanteTipo.Location = New System.Drawing.Point(0, 39)
        Me.toolstripComprobanteTipo.Name = "toolstripComprobanteTipo"
        Me.toolstripComprobanteTipo.Size = New System.Drawing.Size(265, 27)
        Me.toolstripComprobanteTipo.TabIndex = 10
        '
        'labelComprobanteTipo
        '
        Me.labelComprobanteTipo.Name = "labelComprobanteTipo"
        Me.labelComprobanteTipo.Size = New System.Drawing.Size(33, 24)
        Me.labelComprobanteTipo.Text = "Tipo:"
        '
        'comboboxOperacionTipo
        '
        Me.comboboxOperacionTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxOperacionTipo.Name = "comboboxOperacionTipo"
        Me.comboboxOperacionTipo.Size = New System.Drawing.Size(75, 27)
        '
        'comboboxComprobanteTipo
        '
        Me.comboboxComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxComprobanteTipo.Name = "comboboxComprobanteTipo"
        Me.comboboxComprobanteTipo.Size = New System.Drawing.Size(150, 27)
        '
        'toolstripComprobanteLote
        '
        Me.toolstripComprobanteLote.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripComprobanteLote.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripComprobanteLote.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripComprobanteLote.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelComprobanteLote, Me.comboboxComprobanteLote})
        Me.toolstripComprobanteLote.Location = New System.Drawing.Point(265, 39)
        Me.toolstripComprobanteLote.Name = "toolstripComprobanteLote"
        Me.toolstripComprobanteLote.Size = New System.Drawing.Size(189, 27)
        Me.toolstripComprobanteLote.TabIndex = 11
        '
        'labelComprobanteLote
        '
        Me.labelComprobanteLote.Name = "labelComprobanteLote"
        Me.labelComprobanteLote.Size = New System.Drawing.Size(33, 24)
        Me.labelComprobanteLote.Text = "Lote:"
        '
        'comboboxComprobanteLote
        '
        Me.comboboxComprobanteLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxComprobanteLote.Name = "comboboxComprobanteLote"
        Me.comboboxComprobanteLote.Size = New System.Drawing.Size(151, 27)
        '
        'toolstripTitular
        '
        Me.toolstripTitular.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripTitular.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripTitular.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripTitular.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelEntidad, Me.textboxEntidad, Me.buttonEntidad, Me.buttonEntidadBorrar})
        Me.toolstripTitular.Location = New System.Drawing.Point(454, 39)
        Me.toolstripTitular.Name = "toolstripTitular"
        Me.toolstripTitular.Size = New System.Drawing.Size(296, 27)
        Me.toolstripTitular.TabIndex = 7
        '
        'labelEntidad
        '
        Me.labelEntidad.Name = "labelEntidad"
        Me.labelEntidad.Size = New System.Drawing.Size(43, 24)
        Me.labelEntidad.Text = "Titular:"
        '
        'textboxEntidad
        '
        Me.textboxEntidad.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.textboxEntidad.Name = "textboxEntidad"
        Me.textboxEntidad.ReadOnly = True
        Me.textboxEntidad.Size = New System.Drawing.Size(200, 27)
        '
        'buttonEntidad
        '
        Me.buttonEntidad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.buttonEntidad.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonEntidad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEntidad.Name = "buttonEntidad"
        Me.buttonEntidad.Size = New System.Drawing.Size(24, 24)
        '
        'buttonEntidadBorrar
        '
        Me.buttonEntidadBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.buttonEntidadBorrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_16
        Me.buttonEntidadBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEntidadBorrar.Name = "buttonEntidadBorrar"
        Me.buttonEntidadBorrar.Size = New System.Drawing.Size(24, 24)
        '
        'toolstripBuscar
        '
        Me.toolstripBuscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripBuscar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripBuscar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripBuscar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelBuscar, Me.comboboxBuscarTipo, Me.textboxBuscar, Me.buttonBuscarBorrar})
        Me.toolstripBuscar.Location = New System.Drawing.Point(0, 66)
        Me.toolstripBuscar.Name = "toolstripBuscar"
        Me.toolstripBuscar.Size = New System.Drawing.Size(304, 27)
        Me.toolstripBuscar.TabIndex = 9
        '
        'labelBuscar
        '
        Me.labelBuscar.Name = "labelBuscar"
        Me.labelBuscar.Size = New System.Drawing.Size(63, 24)
        Me.labelBuscar.Text = "Buscar por"
        '
        'comboboxBuscarTipo
        '
        Me.comboboxBuscarTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxBuscarTipo.Name = "comboboxBuscarTipo"
        Me.comboboxBuscarTipo.Size = New System.Drawing.Size(90, 27)
        '
        'textboxBuscar
        '
        Me.textboxBuscar.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.textboxBuscar.MaxLength = 100
        Me.textboxBuscar.Name = "textboxBuscar"
        Me.textboxBuscar.Size = New System.Drawing.Size(120, 27)
        '
        'buttonBuscarBorrar
        '
        Me.buttonBuscarBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.buttonBuscarBorrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_16
        Me.buttonBuscarBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonBuscarBorrar.Name = "buttonBuscarBorrar"
        Me.buttonBuscarBorrar.Size = New System.Drawing.Size(24, 24)
        Me.buttonBuscarBorrar.ToolTipText = "Limpiar búsqueda"
        '
        'toolstripTareas
        '
        Me.toolstripTareas.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripTareas.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.dropdownbuttonTareas})
        Me.toolstripTareas.Location = New System.Drawing.Point(304, 66)
        Me.toolstripTareas.Name = "toolstripTareas"
        Me.toolstripTareas.Size = New System.Drawing.Size(86, 25)
        Me.toolstripTareas.TabIndex = 12
        '
        'dropdownbuttonTareas
        '
        Me.dropdownbuttonTareas.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.dropdownbuttonTareas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemGenerarCodigosQR, Me.menuitemGenerarCódigosBarrasSEPSA})
        Me.dropdownbuttonTareas.Image = CType(resources.GetObject("dropdownbuttonTareas.Image"), System.Drawing.Image)
        Me.dropdownbuttonTareas.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.dropdownbuttonTareas.Name = "dropdownbuttonTareas"
        Me.dropdownbuttonTareas.Size = New System.Drawing.Size(52, 22)
        Me.dropdownbuttonTareas.Text = "Tareas"
        '
        'menuitemGenerarCódigosBarrasSEPSA
        '
        Me.menuitemGenerarCódigosBarrasSEPSA.Name = "menuitemGenerarCódigosBarrasSEPSA"
        Me.menuitemGenerarCódigosBarrasSEPSA.Size = New System.Drawing.Size(247, 22)
        Me.menuitemGenerarCódigosBarrasSEPSA.Text = "Generar códigos de barras SEPSA"
        '
        'ToolStripMenuItemGenerarCodigosQR
        '
        Me.ToolStripMenuItemGenerarCodigosQR.Name = "ToolStripMenuItemGenerarCodigosQR"
        Me.ToolStripMenuItemGenerarCodigosQR.Size = New System.Drawing.Size(247, 22)
        Me.ToolStripMenuItemGenerarCodigosQR.Text = "Generar códigos QR"
        '
        'formComprobantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 411)
        Me.Controls.Add(Me.datagridviewMain)
        Me.Controls.Add(Me.panelToolbars)
        Me.Controls.Add(Me.statusstripMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formComprobantes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Comprobantes"
        Me.statusstripMain.ResumeLayout(False)
        Me.statusstripMain.PerformLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelToolbars.ResumeLayout(False)
        Me.panelToolbars.PerformLayout()
        Me.toolstripButtons.ResumeLayout(False)
        Me.toolstripButtons.PerformLayout()
        Me.toolstripPeriodo.ResumeLayout(False)
        Me.toolstripPeriodo.PerformLayout()
        Me.toolstripComprobanteTipo.ResumeLayout(False)
        Me.toolstripComprobanteTipo.PerformLayout()
        Me.toolstripComprobanteLote.ResumeLayout(False)
        Me.toolstripComprobanteLote.PerformLayout()
        Me.toolstripTitular.ResumeLayout(False)
        Me.toolstripTitular.PerformLayout()
        Me.toolstripBuscar.ResumeLayout(False)
        Me.toolstripBuscar.PerformLayout()
        Me.toolstripTareas.ResumeLayout(False)
        Me.toolstripTareas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents statuslabelMain As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusstripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents datagridviewMain As System.Windows.Forms.DataGridView
    Friend WithEvents panelToolbars As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents toolstripButtons As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripTitular As System.Windows.Forms.ToolStrip
    Friend WithEvents labelEntidad As System.Windows.Forms.ToolStripLabel
    Friend WithEvents textboxEntidad As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents buttonEntidad As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEntidadBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripPeriodo As System.Windows.Forms.ToolStrip
    Friend WithEvents toolstripBuscar As System.Windows.Forms.ToolStrip
    Friend WithEvents labelBuscar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxBuscarTipo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents textboxBuscar As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents buttonBuscarBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents labelPeriodo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxPeriodoTipo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents toolstripComprobanteTipo As System.Windows.Forms.ToolStrip
    Friend WithEvents labelComprobanteTipo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxComprobanteTipo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents comboboxOperacionTipo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents buttonImprimir As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents menuitemImprimirPrevisualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents buttonEnviarEmail As System.Windows.Forms.ToolStripButton
    Friend WithEvents menuitemImprimirListadoDeComprobantes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolstripComprobanteLote As System.Windows.Forms.ToolStrip
    Friend WithEvents labelComprobanteLote As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxComprobanteLote As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents columnTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNumeroCompleto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnEntidadNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnCAE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents buttonAnular As System.Windows.Forms.ToolStripButton
    Friend WithEvents comboboxPeriodoValor As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents labelPeriodoFechaY As System.Windows.Forms.ToolStripLabel
    Friend WithEvents buttonAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripTareas As ToolStrip
    Friend WithEvents dropdownbuttonTareas As ToolStripDropDownButton
    Friend WithEvents menuitemGenerarCódigosBarrasSEPSA As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemGenerarCodigosQR As ToolStripMenuItem
End Class
