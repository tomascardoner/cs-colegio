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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formEntidades))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.buttonAgregar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.dropdownbuttonEntidadTipos = New System.Windows.Forms.ToolStripDropDownButton()
        Me.menuitemEntidadTipo_PersonalColegio = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemEntidadTipo_Docente = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemEntidadTipo_Alumno = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemEntidadTipo_Familiar = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemEntidadTipo_Proveedor = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.menuitemMarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemDesmarcarTodo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.labelBuscar = New System.Windows.Forms.ToolStripLabel()
        Me.textboxBuscar = New System.Windows.Forms.ToolStripTextBox()
        Me.buttonBuscarBorrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.labelActivo = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxActivo = New System.Windows.Forms.ToolStripComboBox()
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
        Me.bindingsourceMain = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingsourceMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
		Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonAgregar, Me.buttonEditar, Me.buttonEliminar, Me.ToolStripSeparator1, Me.dropdownbuttonEntidadTipos, Me.ToolStripSeparator3, Me.labelBuscar, Me.textboxBuscar, Me.buttonBuscarBorrar, Me.ToolStripSeparator4, Me.labelActivo, Me.comboboxActivo})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(781, 25)
        Me.toolstripMain.TabIndex = 0
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'dropdownbuttonEntidadTipos
        '
        Me.dropdownbuttonEntidadTipos.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.dropdownbuttonEntidadTipos.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemEntidadTipo_PersonalColegio, Me.menuitemEntidadTipo_Docente, Me.menuitemEntidadTipo_Alumno, Me.menuitemEntidadTipo_Familiar, Me.menuitemEntidadTipo_Proveedor, Me.ToolStripSeparator2, Me.menuitemMarcarTodo, Me.menuitemDesmarcarTodo})
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
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(160, 6)
        '
        'menuitemMarcarTodo
        '
        Me.menuitemMarcarTodo.Name = "menuitemMarcarTodo"
        Me.menuitemMarcarTodo.Size = New System.Drawing.Size(163, 22)
        Me.menuitemMarcarTodo.Text = "Marcar todos"
        '
        'menuitemDesmarcarTodo
        '
        Me.menuitemDesmarcarTodo.Name = "menuitemDesmarcarTodo"
        Me.menuitemDesmarcarTodo.Size = New System.Drawing.Size(163, 22)
        Me.menuitemDesmarcarTodo.Text = "Desmarcar todos"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
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
        Me.buttonBuscarBorrar.Size = New System.Drawing.Size(23, 36)
        Me.buttonBuscarBorrar.ToolTipText = "Limpiar búsqueda"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 39)
        '
        'labelActivo
        '
        Me.labelActivo.Name = "labelActivo"
        Me.labelActivo.Size = New System.Drawing.Size(41, 36)
        Me.labelActivo.Text = "Activo"
        '
        'comboboxActivo
        '
        Me.comboboxActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxActivo.Name = "comboboxActivo"
        Me.comboboxActivo.Size = New System.Drawing.Size(75, 23)
        '
        'statusstripMain
        '
		Me.statusstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statuslabelMain})
        Me.statusstripMain.Location = New System.Drawing.Point(0, 347)
        Me.statusstripMain.Name = "statusstripMain"
        Me.statusstripMain.Size = New System.Drawing.Size(781, 22)
        Me.statusstripMain.TabIndex = 1
        Me.statusstripMain.Text = "StatusStrip1"
        '
        'statuslabelMain
        '
        Me.statuslabelMain.Name = "statuslabelMain"
        Me.statuslabelMain.Size = New System.Drawing.Size(766, 17)
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
        Me.datagridviewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnIDEntidad, Me.columnApellido, Me.columnNombre, Me.columnTipoPersonalColegio, Me.columnTipoDocente, Me.columnTipoAlumno, Me.columnTipoFamiliar, Me.columnTipoProveedor})
        Me.datagridviewMain.DataSource = Me.bindingsourceMain
        Me.datagridviewMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewMain.Location = New System.Drawing.Point(0, 25)
        Me.datagridviewMain.MultiSelect = False
        Me.datagridviewMain.Name = "datagridviewMain"
        Me.datagridviewMain.ReadOnly = True
        Me.datagridviewMain.RowHeadersVisible = False
        Me.datagridviewMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewMain.Size = New System.Drawing.Size(781, 322)
        Me.datagridviewMain.TabIndex = 2
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
        Me.columnIDEntidad.Width = 83
        '
        'columnApellido
        '
        Me.columnApellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnApellido.DataPropertyName = "Apellido"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnApellido.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnApellido.HeaderText = "Apellidos"
        Me.columnApellido.Name = "columnApellido"
        Me.columnApellido.ReadOnly = True
        Me.columnApellido.Width = 74
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
        'bindingsourceMain
        '
        '
        'formEntidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(781, 369)
        Me.Controls.Add(Me.datagridviewMain)
        Me.Controls.Add(Me.statusstripMain)
        Me.Controls.Add(Me.toolstripMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formEntidades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Entidades"
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingsourceMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents statusstripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents statuslabelMain As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents datagridviewMain As System.Windows.Forms.DataGridView
    Friend WithEvents bindingsourceMain As System.Windows.Forms.BindingSource
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dropdownbuttonEntidadTipos As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents menuitemEntidadTipo_PersonalColegio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemEntidadTipo_Docente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemEntidadTipo_Alumno As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemEntidadTipo_Familiar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemEntidadTipo_Proveedor As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents menuitemMarcarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemDesmarcarTodo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents labelBuscar As System.Windows.Forms.ToolStripLabel
    Friend WithEvents textboxBuscar As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents buttonBuscarBorrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents labelActivo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxActivo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents columnIDEntidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnApellido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnTipoPersonalColegio As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents columnTipoDocente As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents columnTipoAlumno As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents columnTipoFamiliar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents columnTipoProveedor As System.Windows.Forms.DataGridViewCheckBoxColumn
End Class
