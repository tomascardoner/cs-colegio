<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formEntidades
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formEntidades))
        Me.toolstripButtons = New System.Windows.Forms.ToolStrip()
        Me.buttonAgregar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEliminar = New System.Windows.Forms.ToolStripButton()
        Me.buttonSincronizarOutlook = New System.Windows.Forms.ToolStripButton()
        Me.statusstripMain = New System.Windows.Forms.StatusStrip()
        Me.statuslabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.datagridviewMain = New System.Windows.Forms.DataGridView()
        Me.columnIDEntidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnApellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnTipoPersonalColegio = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.columnTipoDocente = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.columnTipoAlumno = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.columnTipoFamiliar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.columnTipoProveedor = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.columnTipoOtro = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.bindingsourceMain = New System.Windows.Forms.BindingSource(Me.components)
        Me.toolstripEntidadTipo = New System.Windows.Forms.ToolStrip()
        Me.dropdownbuttonEntidadTipos = New System.Windows.Forms.ToolStripDropDownButton()
        Me.menuitemEntidadTipo_PersonalColegio = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemEntidadTipo_Docente = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemEntidadTipo_Alumno = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemEntidadTipo_Familiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemEntidadTipo_Proveedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemEntidadTipo_Otro = New System.Windows.Forms.ToolStripMenuItem()
        Me.separatorMarcarTodos = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemMarcarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDesmarcarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.panelToolbars = New System.Windows.Forms.FlowLayoutPanel()
        Me.toolstripBuscar = New System.Windows.Forms.ToolStrip()
        Me.labelBuscar = New System.Windows.Forms.ToolStripLabel()
        Me.textboxBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.buttonBuscarBorrar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripActivo = New System.Windows.Forms.ToolStrip()
        Me.labelActivo = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxActivo = New System.Windows.Forms.ToolStripComboBox()
        Me.toolstripVerificarEmail = New System.Windows.Forms.ToolStrip()
        Me.labelVerificarEmail = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxVerificarEmail = New System.Windows.Forms.ToolStripComboBox()
        Me.toolstripButtons.SuspendLayout()
        Me.statusstripMain.SuspendLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingsourceMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolstripEntidadTipo.SuspendLayout()
        Me.panelToolbars.SuspendLayout()
        Me.toolstripBuscar.SuspendLayout()
        Me.toolstripActivo.SuspendLayout()
        Me.toolstripVerificarEmail.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolstripButtons
        '
        Me.toolstripButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripButtons.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonAgregar, Me.buttonEditar, Me.buttonEliminar, Me.buttonSincronizarOutlook})
        Me.toolstripButtons.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.toolstripButtons.Location = New System.Drawing.Point(0, 0)
        Me.toolstripButtons.Name = "toolstripButtons"
        Me.toolstripButtons.Size = New System.Drawing.Size(367, 39)
        Me.toolstripButtons.TabIndex = 0
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
        'buttonEliminar
        '
        Me.buttonEliminar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_DELETE_32
        Me.buttonEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEliminar.Name = "buttonEliminar"
        Me.buttonEliminar.Size = New System.Drawing.Size(86, 36)
        Me.buttonEliminar.Text = "Eliminar"
        '
        'buttonSincronizarOutlook
        '
        Me.buttonSincronizarOutlook.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_OUTLOOK_32
        Me.buttonSincronizarOutlook.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonSincronizarOutlook.Name = "buttonSincronizarOutlook"
        Me.buttonSincronizarOutlook.Size = New System.Drawing.Size(89, 36)
        Me.buttonSincronizarOutlook.Text = "Sincronizar"
        '
        'statusstripMain
        '
        Me.statusstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.statusstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statuslabelMain})
        Me.statusstripMain.Location = New System.Drawing.Point(0, 347)
        Me.statusstripMain.Name = "statusstripMain"
        Me.statusstripMain.Size = New System.Drawing.Size(1061, 22)
        Me.statusstripMain.TabIndex = 1
        '
        'statuslabelMain
        '
        Me.statuslabelMain.Name = "statuslabelMain"
        Me.statuslabelMain.Size = New System.Drawing.Size(1046, 17)
        Me.statuslabelMain.Spring = True
        Me.statuslabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'datagridviewMain
        '
        Me.datagridviewMain.AllowUserToAddRows = False
        Me.datagridviewMain.AllowUserToDeleteRows = False
        Me.datagridviewMain.AllowUserToOrderColumns = True
        Me.datagridviewMain.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewMain.AutoGenerateColumns = False
        Me.datagridviewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnIDEntidad, Me.columnApellido, Me.columnNombre, Me.columnTipoPersonalColegio, Me.columnTipoDocente, Me.columnTipoAlumno, Me.columnTipoFamiliar, Me.columnTipoProveedor, Me.columnTipoOtro})
        Me.datagridviewMain.DataSource = Me.bindingsourceMain
        Me.datagridviewMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewMain.Location = New System.Drawing.Point(0, 39)
        Me.datagridviewMain.MultiSelect = False
        Me.datagridviewMain.Name = "datagridviewMain"
        Me.datagridviewMain.ReadOnly = True
        Me.datagridviewMain.RowHeadersVisible = False
        Me.datagridviewMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewMain.Size = New System.Drawing.Size(1061, 308)
        Me.datagridviewMain.TabIndex = 0
        '
        'columnIDEntidad
        '
        Me.columnIDEntidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnIDEntidad.DataPropertyName = "IDEntidad"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnIDEntidad.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnIDEntidad.HeaderText = "N° Entidad"
        Me.columnIDEntidad.Name = "columnIDEntidad"
        Me.columnIDEntidad.ReadOnly = True
        Me.columnIDEntidad.Width = 77
        '
        'columnApellido
        '
        Me.columnApellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnApellido.DataPropertyName = "Apellido"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnApellido.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnApellido.HeaderText = "Apellidos / Razón Social"
        Me.columnApellido.Name = "columnApellido"
        Me.columnApellido.ReadOnly = True
        Me.columnApellido.Width = 109
        '
        'columnNombre
        '
        Me.columnNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNombre.DataPropertyName = "Nombre"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnNombre.DefaultCellStyle = DataGridViewCellStyle4
        Me.columnNombre.HeaderText = "Nombres"
        Me.columnNombre.Name = "columnNombre"
        Me.columnNombre.ReadOnly = True
        Me.columnNombre.Width = 74
        '
        'columnTipoPersonalColegio
        '
        Me.columnTipoPersonalColegio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTipoPersonalColegio.DataPropertyName = "TipoPersonalColegio"
        Me.columnTipoPersonalColegio.HeaderText = "Personal"
        Me.columnTipoPersonalColegio.Name = "columnTipoPersonalColegio"
        Me.columnTipoPersonalColegio.ReadOnly = True
        Me.columnTipoPersonalColegio.Width = 54
        '
        'columnTipoDocente
        '
        Me.columnTipoDocente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTipoDocente.DataPropertyName = "TipoDocente"
        Me.columnTipoDocente.HeaderText = "Docente"
        Me.columnTipoDocente.Name = "columnTipoDocente"
        Me.columnTipoDocente.ReadOnly = True
        Me.columnTipoDocente.Width = 54
        '
        'columnTipoAlumno
        '
        Me.columnTipoAlumno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTipoAlumno.DataPropertyName = "TipoAlumno"
        Me.columnTipoAlumno.HeaderText = "Alumno"
        Me.columnTipoAlumno.Name = "columnTipoAlumno"
        Me.columnTipoAlumno.ReadOnly = True
        Me.columnTipoAlumno.Width = 48
        '
        'columnTipoFamiliar
        '
        Me.columnTipoFamiliar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTipoFamiliar.DataPropertyName = "TipoFamiliar"
        Me.columnTipoFamiliar.HeaderText = "Familiar"
        Me.columnTipoFamiliar.Name = "columnTipoFamiliar"
        Me.columnTipoFamiliar.ReadOnly = True
        Me.columnTipoFamiliar.Width = 48
        '
        'columnTipoProveedor
        '
        Me.columnTipoProveedor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTipoProveedor.DataPropertyName = "TipoProveedor"
        Me.columnTipoProveedor.HeaderText = "Proveedor"
        Me.columnTipoProveedor.Name = "columnTipoProveedor"
        Me.columnTipoProveedor.ReadOnly = True
        Me.columnTipoProveedor.Width = 62
        '
        'columnTipoOtro
        '
        Me.columnTipoOtro.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTipoOtro.DataPropertyName = "TipoOtro"
        Me.columnTipoOtro.HeaderText = "Otro"
        Me.columnTipoOtro.Name = "columnTipoOtro"
        Me.columnTipoOtro.ReadOnly = True
        Me.columnTipoOtro.Width = 33
        '
        'toolstripEntidadTipo
        '
        Me.toolstripEntidadTipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripEntidadTipo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripEntidadTipo.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripEntidadTipo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.dropdownbuttonEntidadTipos})
        Me.toolstripEntidadTipo.Location = New System.Drawing.Point(367, 0)
        Me.toolstripEntidadTipo.Name = "toolstripEntidadTipo"
        Me.toolstripEntidadTipo.Size = New System.Drawing.Size(111, 39)
        Me.toolstripEntidadTipo.TabIndex = 1
        '
        'dropdownbuttonEntidadTipos
        '
        Me.dropdownbuttonEntidadTipos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.dropdownbuttonEntidadTipos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemEntidadTipo_PersonalColegio, Me.menuitemEntidadTipo_Docente, Me.menuitemEntidadTipo_Alumno, Me.menuitemEntidadTipo_Familiar, Me.menuitemEntidadTipo_Proveedor, Me.menuitemEntidadTipo_Otro, Me.separatorMarcarTodos, Me.menuitemMarcarTodos, Me.menuitemDesmarcarTodos})
        Me.dropdownbuttonEntidadTipos.Image = CType(resources.GetObject("dropdownbuttonEntidadTipos.Image"), System.Drawing.Image)
        Me.dropdownbuttonEntidadTipos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.dropdownbuttonEntidadTipos.Name = "dropdownbuttonEntidadTipos"
        Me.dropdownbuttonEntidadTipos.Size = New System.Drawing.Size(108, 36)
        Me.dropdownbuttonEntidadTipos.Text = "Tipos de Entidad"
        '
        'menuitemEntidadTipo_PersonalColegio
        '
        Me.menuitemEntidadTipo_PersonalColegio.Checked = True
        Me.menuitemEntidadTipo_PersonalColegio.CheckOnClick = True
        Me.menuitemEntidadTipo_PersonalColegio.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuitemEntidadTipo_PersonalColegio.Name = "menuitemEntidadTipo_PersonalColegio"
        Me.menuitemEntidadTipo_PersonalColegio.Size = New System.Drawing.Size(163, 22)
        Me.menuitemEntidadTipo_PersonalColegio.Text = "Personal"
        '
        'menuitemEntidadTipo_Docente
        '
        Me.menuitemEntidadTipo_Docente.Checked = True
        Me.menuitemEntidadTipo_Docente.CheckOnClick = True
        Me.menuitemEntidadTipo_Docente.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuitemEntidadTipo_Docente.Name = "menuitemEntidadTipo_Docente"
        Me.menuitemEntidadTipo_Docente.Size = New System.Drawing.Size(163, 22)
        Me.menuitemEntidadTipo_Docente.Text = "Docente"
        '
        'menuitemEntidadTipo_Alumno
        '
        Me.menuitemEntidadTipo_Alumno.Checked = True
        Me.menuitemEntidadTipo_Alumno.CheckOnClick = True
        Me.menuitemEntidadTipo_Alumno.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuitemEntidadTipo_Alumno.Name = "menuitemEntidadTipo_Alumno"
        Me.menuitemEntidadTipo_Alumno.Size = New System.Drawing.Size(163, 22)
        Me.menuitemEntidadTipo_Alumno.Text = "Alumno"
        '
        'menuitemEntidadTipo_Familiar
        '
        Me.menuitemEntidadTipo_Familiar.Checked = True
        Me.menuitemEntidadTipo_Familiar.CheckOnClick = True
        Me.menuitemEntidadTipo_Familiar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuitemEntidadTipo_Familiar.Name = "menuitemEntidadTipo_Familiar"
        Me.menuitemEntidadTipo_Familiar.Size = New System.Drawing.Size(163, 22)
        Me.menuitemEntidadTipo_Familiar.Text = "Familiar"
        '
        'menuitemEntidadTipo_Proveedor
        '
        Me.menuitemEntidadTipo_Proveedor.Checked = True
        Me.menuitemEntidadTipo_Proveedor.CheckOnClick = True
        Me.menuitemEntidadTipo_Proveedor.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuitemEntidadTipo_Proveedor.Name = "menuitemEntidadTipo_Proveedor"
        Me.menuitemEntidadTipo_Proveedor.Size = New System.Drawing.Size(163, 22)
        Me.menuitemEntidadTipo_Proveedor.Text = "Proveedor"
        '
        'menuitemEntidadTipo_Otro
        '
        Me.menuitemEntidadTipo_Otro.Checked = True
        Me.menuitemEntidadTipo_Otro.CheckOnClick = True
        Me.menuitemEntidadTipo_Otro.CheckState = System.Windows.Forms.CheckState.Checked
        Me.menuitemEntidadTipo_Otro.Name = "menuitemEntidadTipo_Otro"
        Me.menuitemEntidadTipo_Otro.Size = New System.Drawing.Size(163, 22)
        Me.menuitemEntidadTipo_Otro.Text = "Otro"
        '
        'separatorMarcarTodos
        '
        Me.separatorMarcarTodos.Name = "separatorMarcarTodos"
        Me.separatorMarcarTodos.Size = New System.Drawing.Size(160, 6)
        '
        'menuitemMarcarTodos
        '
        Me.menuitemMarcarTodos.Name = "menuitemMarcarTodos"
        Me.menuitemMarcarTodos.Size = New System.Drawing.Size(163, 22)
        Me.menuitemMarcarTodos.Text = "Marcar todos"
        '
        'menuitemDesmarcarTodos
        '
        Me.menuitemDesmarcarTodos.Name = "menuitemDesmarcarTodos"
        Me.menuitemDesmarcarTodos.Size = New System.Drawing.Size(163, 22)
        Me.menuitemDesmarcarTodos.Text = "Desmarcar todos"
        '
        'panelToolbars
        '
        Me.panelToolbars.AutoSize = True
        Me.panelToolbars.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelToolbars.Controls.Add(Me.toolstripButtons)
        Me.panelToolbars.Controls.Add(Me.toolstripEntidadTipo)
        Me.panelToolbars.Controls.Add(Me.toolstripBuscar)
        Me.panelToolbars.Controls.Add(Me.toolstripActivo)
        Me.panelToolbars.Controls.Add(Me.toolstripVerificarEmail)
        Me.panelToolbars.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelToolbars.Location = New System.Drawing.Point(0, 0)
        Me.panelToolbars.Name = "panelToolbars"
        Me.panelToolbars.Size = New System.Drawing.Size(1061, 39)
        Me.panelToolbars.TabIndex = 2
        '
        'toolstripBuscar
        '
        Me.toolstripBuscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripBuscar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripBuscar.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripBuscar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelBuscar, Me.textboxBuscar, Me.buttonBuscarBorrar})
        Me.toolstripBuscar.Location = New System.Drawing.Point(478, 0)
        Me.toolstripBuscar.Name = "toolstripBuscar"
        Me.toolstripBuscar.Size = New System.Drawing.Size(194, 39)
        Me.toolstripBuscar.TabIndex = 2
        '
        'labelBuscar
        '
        Me.labelBuscar.Name = "labelBuscar"
        Me.labelBuscar.Size = New System.Drawing.Size(45, 36)
        Me.labelBuscar.Text = "Buscar:"
        '
        'textboxBuscar
        '
        Me.textboxBuscar.MaxLength = 100
        Me.textboxBuscar.Name = "textboxBuscar"
        Me.textboxBuscar.Size = New System.Drawing.Size(120, 39)
        '
        'buttonBuscarBorrar
        '
        Me.buttonBuscarBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.buttonBuscarBorrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_16
        Me.buttonBuscarBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonBuscarBorrar.Name = "buttonBuscarBorrar"
        Me.buttonBuscarBorrar.Size = New System.Drawing.Size(24, 36)
        Me.buttonBuscarBorrar.ToolTipText = "Limpiar búsqueda"
        '
        'toolstripActivo
        '
        Me.toolstripActivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripActivo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripActivo.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripActivo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelActivo, Me.comboboxActivo})
        Me.toolstripActivo.Location = New System.Drawing.Point(672, 0)
        Me.toolstripActivo.Name = "toolstripActivo"
        Me.toolstripActivo.Size = New System.Drawing.Size(124, 39)
        Me.toolstripActivo.TabIndex = 3
        '
        'labelActivo
        '
        Me.labelActivo.Name = "labelActivo"
        Me.labelActivo.Size = New System.Drawing.Size(44, 36)
        Me.labelActivo.Text = "Activo:"
        '
        'comboboxActivo
        '
        Me.comboboxActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxActivo.Name = "comboboxActivo"
        Me.comboboxActivo.Size = New System.Drawing.Size(75, 39)
        '
        'toolstripVerificarEmail
        '
        Me.toolstripVerificarEmail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripVerificarEmail.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripVerificarEmail.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripVerificarEmail.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelVerificarEmail, Me.comboboxVerificarEmail})
        Me.toolstripVerificarEmail.Location = New System.Drawing.Point(796, 0)
        Me.toolstripVerificarEmail.Name = "toolstripVerificarEmail"
        Me.toolstripVerificarEmail.Size = New System.Drawing.Size(169, 39)
        Me.toolstripVerificarEmail.TabIndex = 4
        '
        'labelVerificarEmail
        '
        Me.labelVerificarEmail.Name = "labelVerificarEmail"
        Me.labelVerificarEmail.Size = New System.Drawing.Size(89, 36)
        Me.labelVerificarEmail.Text = "Verificar e-Mail:"
        '
        'comboboxVerificarEmail
        '
        Me.comboboxVerificarEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxVerificarEmail.Name = "comboboxVerificarEmail"
        Me.comboboxVerificarEmail.Size = New System.Drawing.Size(75, 39)
        '
        'formEntidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1061, 369)
        Me.Controls.Add(Me.datagridviewMain)
        Me.Controls.Add(Me.panelToolbars)
        Me.Controls.Add(Me.statusstripMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "formEntidades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Entidades"
        Me.toolstripButtons.ResumeLayout(False)
        Me.toolstripButtons.PerformLayout()
        Me.statusstripMain.ResumeLayout(False)
        Me.statusstripMain.PerformLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingsourceMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolstripEntidadTipo.ResumeLayout(False)
        Me.toolstripEntidadTipo.PerformLayout()
        Me.panelToolbars.ResumeLayout(False)
        Me.panelToolbars.PerformLayout()
        Me.toolstripBuscar.ResumeLayout(False)
        Me.toolstripBuscar.PerformLayout()
        Me.toolstripActivo.ResumeLayout(False)
        Me.toolstripActivo.PerformLayout()
        Me.toolstripVerificarEmail.ResumeLayout(False)
        Me.toolstripVerificarEmail.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolstripButtons As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents statusstripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents statuslabelMain As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents datagridviewMain As System.Windows.Forms.DataGridView
    Friend WithEvents bindingsourceMain As System.Windows.Forms.BindingSource
    Friend WithEvents toolstripEntidadTipo As System.Windows.Forms.ToolStrip
    Friend WithEvents panelToolbars As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents dropdownbuttonEntidadTipos As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents menuitemEntidadTipo_PersonalColegio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemEntidadTipo_Docente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemEntidadTipo_Alumno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemEntidadTipo_Familiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemEntidadTipo_Proveedor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents separatorMarcarTodos As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuitemMarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemDesmarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolstripBuscar As System.Windows.Forms.ToolStrip
    Friend WithEvents toolstripActivo As System.Windows.Forms.ToolStrip
    Friend WithEvents labelBuscar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents textboxBuscar As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents buttonBuscarBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents labelActivo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxActivo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents menuitemEntidadTipo_Otro As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents columnIDEntidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnApellido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnTipoPersonalColegio As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents columnTipoDocente As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents columnTipoAlumno As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents columnTipoFamiliar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents columnTipoProveedor As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents columnTipoOtro As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents toolstripVerificarEmail As System.Windows.Forms.ToolStrip
    Friend WithEvents labelVerificarEmail As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxVerificarEmail As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents buttonSincronizarOutlook As System.Windows.Forms.ToolStripButton
End Class
