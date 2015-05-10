<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formGenerarLoteFacturas
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelPaso1 = New System.Windows.Forms.Panel()
        Me.lalbelPaso1Pie = New System.Windows.Forms.Label()
        Me.tabcontrolMain = New System.Windows.Forms.TabControl()
        Me.tabpageNivelesCursosAlumnos = New System.Windows.Forms.TabPage()
        Me.treeviewSeleccionarNivelCursoAlumno = New System.Windows.Forms.TreeView()
        Me.contextmenuNivelCursoAlumno = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuitemNivelCursoAlumnoMarcarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemNivelCursoAlumnoDesmarcarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.tabpagePadresAlumnos = New System.Windows.Forms.TabPage()
        Me.treeviewSeleccionarPadresAlumnos = New System.Windows.Forms.TreeView()
        Me.contextmenuPadreAlumno = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.menuitemPadreAlumnoMarcarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemPadreAlumnoDesmarcarTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.pictureboxPaso1 = New System.Windows.Forms.PictureBox()
        Me.labelPaso1Titulo = New System.Windows.Forms.Label()
        Me.buttonPaso1Cancelar = New System.Windows.Forms.Button()
        Me.buttonPaso1Siguiente = New System.Windows.Forms.Button()
        Me.labelPaso1Mensaje = New System.Windows.Forms.Label()
        Me.panelPaso2 = New System.Windows.Forms.Panel()
        Me.datagridviewEntidadesCorregir = New System.Windows.Forms.DataGridView()
        Me.pictureboxPaso2 = New System.Windows.Forms.PictureBox()
        Me.labelPaso2Mensaje = New System.Windows.Forms.Label()
        Me.labelPaso2Titulo = New System.Windows.Forms.Label()
        Me.buttonPaso2Anterior = New System.Windows.Forms.Button()
        Me.buttonPaso2Siguiente = New System.Windows.Forms.Button()
        Me.columnVerificacionIDEntidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnVerificacionApellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnVerificacionNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnCorrecionDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.labelPaso2Pie = New System.Windows.Forms.Label()
        Me.panelPaso1.SuspendLayout()
        Me.tabcontrolMain.SuspendLayout()
        Me.tabpageNivelesCursosAlumnos.SuspendLayout()
        Me.contextmenuNivelCursoAlumno.SuspendLayout()
        Me.tabpagePadresAlumnos.SuspendLayout()
        Me.contextmenuPadreAlumno.SuspendLayout()
        CType(Me.pictureboxPaso1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelPaso2.SuspendLayout()
        CType(Me.datagridviewEntidadesCorregir, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pictureboxPaso2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelPaso1
        '
        Me.panelPaso1.Controls.Add(Me.lalbelPaso1Pie)
        Me.panelPaso1.Controls.Add(Me.tabcontrolMain)
        Me.panelPaso1.Controls.Add(Me.pictureboxPaso1)
        Me.panelPaso1.Controls.Add(Me.labelPaso1Titulo)
        Me.panelPaso1.Controls.Add(Me.buttonPaso1Cancelar)
        Me.panelPaso1.Controls.Add(Me.buttonPaso1Siguiente)
        Me.panelPaso1.Controls.Add(Me.labelPaso1Mensaje)
        Me.panelPaso1.Location = New System.Drawing.Point(12, 12)
        Me.panelPaso1.Name = "panelPaso1"
        Me.panelPaso1.Size = New System.Drawing.Size(611, 441)
        Me.panelPaso1.TabIndex = 102
        '
        'lalbelPaso1Pie
        '
        Me.lalbelPaso1Pie.AutoSize = True
        Me.lalbelPaso1Pie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lalbelPaso1Pie.Location = New System.Drawing.Point(7, 413)
        Me.lalbelPaso1Pie.Name = "lalbelPaso1Pie"
        Me.lalbelPaso1Pie.Size = New System.Drawing.Size(0, 16)
        Me.lalbelPaso1Pie.TabIndex = 108
        '
        'tabcontrolMain
        '
        Me.tabcontrolMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabcontrolMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabcontrolMain.Controls.Add(Me.tabpageNivelesCursosAlumnos)
        Me.tabcontrolMain.Controls.Add(Me.tabpagePadresAlumnos)
        Me.tabcontrolMain.Location = New System.Drawing.Point(3, 84)
        Me.tabcontrolMain.Name = "tabcontrolMain"
        Me.tabcontrolMain.SelectedIndex = 0
        Me.tabcontrolMain.Size = New System.Drawing.Size(605, 314)
        Me.tabcontrolMain.TabIndex = 107
        '
        'tabpageNivelesCursosAlumnos
        '
        Me.tabpageNivelesCursosAlumnos.Controls.Add(Me.treeviewSeleccionarNivelCursoAlumno)
        Me.tabpageNivelesCursosAlumnos.Location = New System.Drawing.Point(4, 25)
        Me.tabpageNivelesCursosAlumnos.Name = "tabpageNivelesCursosAlumnos"
        Me.tabpageNivelesCursosAlumnos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageNivelesCursosAlumnos.Size = New System.Drawing.Size(597, 285)
        Me.tabpageNivelesCursosAlumnos.TabIndex = 0
        Me.tabpageNivelesCursosAlumnos.Text = "Niveles - Cursos - Alumnos"
        Me.tabpageNivelesCursosAlumnos.UseVisualStyleBackColor = True
        '
        'treeviewSeleccionarNivelCursoAlumno
        '
        Me.treeviewSeleccionarNivelCursoAlumno.CheckBoxes = True
        Me.treeviewSeleccionarNivelCursoAlumno.ContextMenuStrip = Me.contextmenuNivelCursoAlumno
        Me.treeviewSeleccionarNivelCursoAlumno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeviewSeleccionarNivelCursoAlumno.Location = New System.Drawing.Point(3, 3)
        Me.treeviewSeleccionarNivelCursoAlumno.Name = "treeviewSeleccionarNivelCursoAlumno"
        Me.treeviewSeleccionarNivelCursoAlumno.Size = New System.Drawing.Size(591, 279)
        Me.treeviewSeleccionarNivelCursoAlumno.TabIndex = 107
        '
        'contextmenuNivelCursoAlumno
        '
        Me.contextmenuNivelCursoAlumno.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemNivelCursoAlumnoMarcarTodos, Me.menuitemNivelCursoAlumnoDesmarcarTodos})
        Me.contextmenuNivelCursoAlumno.Name = "contextmenuMain"
        Me.contextmenuNivelCursoAlumno.Size = New System.Drawing.Size(170, 48)
        '
        'menuitemNivelCursoAlumnoMarcarTodos
        '
        Me.menuitemNivelCursoAlumnoMarcarTodos.Name = "menuitemNivelCursoAlumnoMarcarTodos"
        Me.menuitemNivelCursoAlumnoMarcarTodos.Size = New System.Drawing.Size(169, 22)
        Me.menuitemNivelCursoAlumnoMarcarTodos.Text = "Marcar todos"
        '
        'menuitemNivelCursoAlumnoDesmarcarTodos
        '
        Me.menuitemNivelCursoAlumnoDesmarcarTodos.Name = "menuitemNivelCursoAlumnoDesmarcarTodos"
        Me.menuitemNivelCursoAlumnoDesmarcarTodos.Size = New System.Drawing.Size(169, 22)
        Me.menuitemNivelCursoAlumnoDesmarcarTodos.Text = "Desemarcar todos"
        '
        'tabpagePadresAlumnos
        '
        Me.tabpagePadresAlumnos.Controls.Add(Me.treeviewSeleccionarPadresAlumnos)
        Me.tabpagePadresAlumnos.Location = New System.Drawing.Point(4, 25)
        Me.tabpagePadresAlumnos.Name = "tabpagePadresAlumnos"
        Me.tabpagePadresAlumnos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpagePadresAlumnos.Size = New System.Drawing.Size(597, 285)
        Me.tabpagePadresAlumnos.TabIndex = 1
        Me.tabpagePadresAlumnos.Text = "Padres - Alumnos"
        Me.tabpagePadresAlumnos.UseVisualStyleBackColor = True
        '
        'treeviewSeleccionarPadresAlumnos
        '
        Me.treeviewSeleccionarPadresAlumnos.CheckBoxes = True
        Me.treeviewSeleccionarPadresAlumnos.ContextMenuStrip = Me.contextmenuPadreAlumno
        Me.treeviewSeleccionarPadresAlumnos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeviewSeleccionarPadresAlumnos.Location = New System.Drawing.Point(3, 3)
        Me.treeviewSeleccionarPadresAlumnos.Name = "treeviewSeleccionarPadresAlumnos"
        Me.treeviewSeleccionarPadresAlumnos.Size = New System.Drawing.Size(591, 279)
        Me.treeviewSeleccionarPadresAlumnos.TabIndex = 0
        '
        'contextmenuPadreAlumno
        '
        Me.contextmenuPadreAlumno.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemPadreAlumnoMarcarTodos, Me.menuitemPadreAlumnoDesmarcarTodos})
        Me.contextmenuPadreAlumno.Name = "contextmenuMain"
        Me.contextmenuPadreAlumno.Size = New System.Drawing.Size(170, 48)
        '
        'menuitemPadreAlumnoMarcarTodos
        '
        Me.menuitemPadreAlumnoMarcarTodos.Name = "menuitemPadreAlumnoMarcarTodos"
        Me.menuitemPadreAlumnoMarcarTodos.Size = New System.Drawing.Size(169, 22)
        Me.menuitemPadreAlumnoMarcarTodos.Text = "Marcar todos"
        '
        'menuitemPadreAlumnoDesmarcarTodos
        '
        Me.menuitemPadreAlumnoDesmarcarTodos.Name = "menuitemPadreAlumnoDesmarcarTodos"
        Me.menuitemPadreAlumnoDesmarcarTodos.Size = New System.Drawing.Size(169, 22)
        Me.menuitemPadreAlumnoDesmarcarTodos.Text = "Desemarcar todos"
        '
        'pictureboxPaso1
        '
        Me.pictureboxPaso1.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_COMPROBANTE_48
        Me.pictureboxPaso1.Location = New System.Drawing.Point(3, 20)
        Me.pictureboxPaso1.Name = "pictureboxPaso1"
        Me.pictureboxPaso1.Size = New System.Drawing.Size(48, 48)
        Me.pictureboxPaso1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureboxPaso1.TabIndex = 105
        Me.pictureboxPaso1.TabStop = False
        '
        'labelPaso1Titulo
        '
        Me.labelPaso1Titulo.AutoSize = True
        Me.labelPaso1Titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.labelPaso1Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPaso1Titulo.Location = New System.Drawing.Point(0, 0)
        Me.labelPaso1Titulo.Name = "labelPaso1Titulo"
        Me.labelPaso1Titulo.Size = New System.Drawing.Size(138, 17)
        Me.labelPaso1Titulo.TabIndex = 104
        Me.labelPaso1Titulo.Text = "Paso 1: Selección"
        '
        'buttonPaso1Cancelar
        '
        Me.buttonPaso1Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso1Cancelar.Location = New System.Drawing.Point(387, 404)
        Me.buttonPaso1Cancelar.Name = "buttonPaso1Cancelar"
        Me.buttonPaso1Cancelar.Size = New System.Drawing.Size(75, 34)
        Me.buttonPaso1Cancelar.TabIndex = 103
        Me.buttonPaso1Cancelar.Text = "Cancelar"
        Me.buttonPaso1Cancelar.UseVisualStyleBackColor = True
        '
        'buttonPaso1Siguiente
        '
        Me.buttonPaso1Siguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso1Siguiente.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_NEXT_24
        Me.buttonPaso1Siguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso1Siguiente.Location = New System.Drawing.Point(468, 404)
        Me.buttonPaso1Siguiente.Name = "buttonPaso1Siguiente"
        Me.buttonPaso1Siguiente.Size = New System.Drawing.Size(140, 34)
        Me.buttonPaso1Siguiente.TabIndex = 102
        Me.buttonPaso1Siguiente.Text = "Paso 2: Verificación"
        Me.buttonPaso1Siguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso1Siguiente.UseVisualStyleBackColor = True
        '
        'labelPaso1Mensaje
        '
        Me.labelPaso1Mensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelPaso1Mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPaso1Mensaje.Location = New System.Drawing.Point(57, 20)
        Me.labelPaso1Mensaje.Name = "labelPaso1Mensaje"
        Me.labelPaso1Mensaje.Size = New System.Drawing.Size(551, 61)
        Me.labelPaso1Mensaje.TabIndex = 100
        Me.labelPaso1Mensaje.Text = "Este asistente le permitirá generar un lote de facturas para un período determina" & _
    "do. Seleccione lo que desee facturar o continúe sin cambiar nada para facturar a" & _
    " todas las entidades."
        '
        'panelPaso2
        '
        Me.panelPaso2.Controls.Add(Me.labelPaso2Pie)
        Me.panelPaso2.Controls.Add(Me.datagridviewEntidadesCorregir)
        Me.panelPaso2.Controls.Add(Me.pictureboxPaso2)
        Me.panelPaso2.Controls.Add(Me.labelPaso2Mensaje)
        Me.panelPaso2.Controls.Add(Me.labelPaso2Titulo)
        Me.panelPaso2.Controls.Add(Me.buttonPaso2Anterior)
        Me.panelPaso2.Controls.Add(Me.buttonPaso2Siguiente)
        Me.panelPaso2.Location = New System.Drawing.Point(12, 12)
        Me.panelPaso2.Name = "panelPaso2"
        Me.panelPaso2.Size = New System.Drawing.Size(611, 441)
        Me.panelPaso2.TabIndex = 103
        '
        'datagridviewEntidadesCorregir
        '
        Me.datagridviewEntidadesCorregir.AllowUserToAddRows = False
        Me.datagridviewEntidadesCorregir.AllowUserToDeleteRows = False
        Me.datagridviewEntidadesCorregir.AllowUserToOrderColumns = True
        Me.datagridviewEntidadesCorregir.AllowUserToResizeRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewEntidadesCorregir.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.datagridviewEntidadesCorregir.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datagridviewEntidadesCorregir.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewEntidadesCorregir.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnVerificacionIDEntidad, Me.columnVerificacionApellido, Me.columnVerificacionNombre, Me.columnCorrecionDescripcion})
        Me.datagridviewEntidadesCorregir.Location = New System.Drawing.Point(3, 84)
        Me.datagridviewEntidadesCorregir.MultiSelect = False
        Me.datagridviewEntidadesCorregir.Name = "datagridviewEntidadesCorregir"
        Me.datagridviewEntidadesCorregir.ReadOnly = True
        Me.datagridviewEntidadesCorregir.RowHeadersVisible = False
        Me.datagridviewEntidadesCorregir.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewEntidadesCorregir.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewEntidadesCorregir.Size = New System.Drawing.Size(605, 307)
        Me.datagridviewEntidadesCorregir.TabIndex = 108
        '
        'pictureboxPaso2
        '
        Me.pictureboxPaso2.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_COMPROBANTE_48
        Me.pictureboxPaso2.Location = New System.Drawing.Point(3, 20)
        Me.pictureboxPaso2.Name = "pictureboxPaso2"
        Me.pictureboxPaso2.Size = New System.Drawing.Size(48, 48)
        Me.pictureboxPaso2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureboxPaso2.TabIndex = 107
        Me.pictureboxPaso2.TabStop = False
        '
        'labelPaso2Mensaje
        '
        Me.labelPaso2Mensaje.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelPaso2Mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPaso2Mensaje.Location = New System.Drawing.Point(57, 17)
        Me.labelPaso2Mensaje.Name = "labelPaso2Mensaje"
        Me.labelPaso2Mensaje.Size = New System.Drawing.Size(551, 51)
        Me.labelPaso2Mensaje.TabIndex = 106
        Me.labelPaso2Mensaje.Text = "Las siguientes Entidades tienen algún tipo de problema que hay que corregir."
        '
        'labelPaso2Titulo
        '
        Me.labelPaso2Titulo.AutoSize = True
        Me.labelPaso2Titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.labelPaso2Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPaso2Titulo.Location = New System.Drawing.Point(0, 0)
        Me.labelPaso2Titulo.Name = "labelPaso2Titulo"
        Me.labelPaso2Titulo.Size = New System.Drawing.Size(153, 17)
        Me.labelPaso2Titulo.TabIndex = 105
        Me.labelPaso2Titulo.Text = "Paso 2: Verificación"
        '
        'buttonPaso2Anterior
        '
        Me.buttonPaso2Anterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso2Anterior.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_PREVIOUS_24
        Me.buttonPaso2Anterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso2Anterior.Location = New System.Drawing.Point(322, 404)
        Me.buttonPaso2Anterior.Name = "buttonPaso2Anterior"
        Me.buttonPaso2Anterior.Size = New System.Drawing.Size(140, 34)
        Me.buttonPaso2Anterior.TabIndex = 99
        Me.buttonPaso2Anterior.Text = "Paso 1: Selección"
        Me.buttonPaso2Anterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso2Anterior.UseVisualStyleBackColor = True
        '
        'buttonPaso2Siguiente
        '
        Me.buttonPaso2Siguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso2Siguiente.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_NEXT_24
        Me.buttonPaso2Siguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso2Siguiente.Location = New System.Drawing.Point(468, 404)
        Me.buttonPaso2Siguiente.Name = "buttonPaso2Siguiente"
        Me.buttonPaso2Siguiente.Size = New System.Drawing.Size(140, 34)
        Me.buttonPaso2Siguiente.TabIndex = 98
        Me.buttonPaso2Siguiente.Text = "Paso 3: Confirmación"
        Me.buttonPaso2Siguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso2Siguiente.UseVisualStyleBackColor = True
        '
        'columnVerificacionIDEntidad
        '
        Me.columnVerificacionIDEntidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnVerificacionIDEntidad.DataPropertyName = "IDEntidad"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnVerificacionIDEntidad.DefaultCellStyle = DataGridViewCellStyle7
        Me.columnVerificacionIDEntidad.HeaderText = "N° Entidad"
        Me.columnVerificacionIDEntidad.Name = "columnVerificacionIDEntidad"
        Me.columnVerificacionIDEntidad.ReadOnly = True
        Me.columnVerificacionIDEntidad.Width = 83
        '
        'columnVerificacionApellido
        '
        Me.columnVerificacionApellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnVerificacionApellido.DataPropertyName = "Apellido"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnVerificacionApellido.DefaultCellStyle = DataGridViewCellStyle8
        Me.columnVerificacionApellido.HeaderText = "Apellido"
        Me.columnVerificacionApellido.Name = "columnVerificacionApellido"
        Me.columnVerificacionApellido.ReadOnly = True
        Me.columnVerificacionApellido.Width = 69
        '
        'columnVerificacionNombre
        '
        Me.columnVerificacionNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnVerificacionNombre.DataPropertyName = "Nombre"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnVerificacionNombre.DefaultCellStyle = DataGridViewCellStyle9
        Me.columnVerificacionNombre.HeaderText = "Nombre"
        Me.columnVerificacionNombre.Name = "columnVerificacionNombre"
        Me.columnVerificacionNombre.ReadOnly = True
        Me.columnVerificacionNombre.Width = 69
        '
        'columnCorrecionDescripcion
        '
        Me.columnCorrecionDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnCorrecionDescripcion.DataPropertyName = "CorreccionDescripcion"
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.columnCorrecionDescripcion.DefaultCellStyle = DataGridViewCellStyle10
        Me.columnCorrecionDescripcion.HeaderText = "Descripción del problema"
        Me.columnCorrecionDescripcion.Name = "columnCorrecionDescripcion"
        Me.columnCorrecionDescripcion.ReadOnly = True
        Me.columnCorrecionDescripcion.Width = 99
        '
        'labelPaso2Pie
        '
        Me.labelPaso2Pie.AutoSize = True
        Me.labelPaso2Pie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPaso2Pie.Location = New System.Drawing.Point(12, 413)
        Me.labelPaso2Pie.Name = "labelPaso2Pie"
        Me.labelPaso2Pie.Size = New System.Drawing.Size(0, 16)
        Me.labelPaso2Pie.TabIndex = 109
        '
        'formGenerarLoteFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 464)
        Me.Controls.Add(Me.panelPaso1)
        Me.Controls.Add(Me.panelPaso2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "formGenerarLoteFacturas"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Generación de Lote de Facturas"
        Me.panelPaso1.ResumeLayout(False)
        Me.panelPaso1.PerformLayout()
        Me.tabcontrolMain.ResumeLayout(False)
        Me.tabpageNivelesCursosAlumnos.ResumeLayout(False)
        Me.contextmenuNivelCursoAlumno.ResumeLayout(False)
        Me.tabpagePadresAlumnos.ResumeLayout(False)
        Me.contextmenuPadreAlumno.ResumeLayout(False)
        CType(Me.pictureboxPaso1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelPaso2.ResumeLayout(False)
        Me.panelPaso2.PerformLayout()
        CType(Me.datagridviewEntidadesCorregir, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pictureboxPaso2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelPaso1 As System.Windows.Forms.Panel
    Friend WithEvents labelPaso1Titulo As System.Windows.Forms.Label
    Friend WithEvents buttonPaso1Cancelar As System.Windows.Forms.Button
    Friend WithEvents buttonPaso1Siguiente As System.Windows.Forms.Button
    Friend WithEvents labelPaso1Mensaje As System.Windows.Forms.Label
    Friend WithEvents pictureboxPaso1 As System.Windows.Forms.PictureBox
    Friend WithEvents tabcontrolMain As System.Windows.Forms.TabControl
    Friend WithEvents tabpageNivelesCursosAlumnos As System.Windows.Forms.TabPage
    Friend WithEvents treeviewSeleccionarNivelCursoAlumno As System.Windows.Forms.TreeView
    Friend WithEvents tabpagePadresAlumnos As System.Windows.Forms.TabPage
    Friend WithEvents treeviewSeleccionarPadresAlumnos As System.Windows.Forms.TreeView
    Friend WithEvents lalbelPaso1Pie As System.Windows.Forms.Label
    Friend WithEvents contextmenuNivelCursoAlumno As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuitemNivelCursoAlumnoMarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemNivelCursoAlumnoDesmarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents panelPaso2 As System.Windows.Forms.Panel
    Friend WithEvents pictureboxPaso2 As System.Windows.Forms.PictureBox
    Friend WithEvents labelPaso2Mensaje As System.Windows.Forms.Label
    Friend WithEvents labelPaso2Titulo As System.Windows.Forms.Label
    Friend WithEvents buttonPaso2Anterior As System.Windows.Forms.Button
    Friend WithEvents buttonPaso2Siguiente As System.Windows.Forms.Button
    Friend WithEvents datagridviewEntidadesCorregir As System.Windows.Forms.DataGridView
    Friend WithEvents contextmenuPadreAlumno As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents menuitemPadreAlumnoMarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemPadreAlumnoDesmarcarTodos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents columnVerificacionIDEntidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnVerificacionApellido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnVerificacionNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnCorrecionDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents labelPaso2Pie As System.Windows.Forms.Label
End Class
