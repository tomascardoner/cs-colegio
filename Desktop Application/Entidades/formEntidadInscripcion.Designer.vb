<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formEntidadInscripcion
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
        Me.labelEntidad = New System.Windows.Forms.Label()
        Me.buttonEntidad = New System.Windows.Forms.Button()
        Me.panelPaso1 = New System.Windows.Forms.Panel()
        Me.textboxAnioLectivo = New System.Windows.Forms.TextBox()
        Me.labelAnioLectivo = New System.Windows.Forms.Label()
        Me.datagridviewEntidades = New System.Windows.Forms.DataGridView()
        Me.columnSeleccionado = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.columnApellidoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnCursoActual = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnCursoProximo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.labelAlumnos = New System.Windows.Forms.Label()
        Me.textboxEntidad = New System.Windows.Forms.TextBox()
        Me.buttonPaso1Cancelar = New System.Windows.Forms.Button()
        Me.buttonPaso1Siguiente = New System.Windows.Forms.Button()
        Me.labelPaso1 = New System.Windows.Forms.Label()
        Me.panelPaso2 = New System.Windows.Forms.Panel()
        Me.buttonPaso2Anterior = New System.Windows.Forms.Button()
        Me.buttonPaso2Finalizar = New System.Windows.Forms.Button()
        Me.labelPaso2 = New System.Windows.Forms.Label()
        Me.datagridviewFacturaDetalle = New System.Windows.Forms.DataGridView()
        Me.columnDescripcion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPrecioTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.datagridviewFacturaCabecera = New System.Windows.Forms.DataGridView()
        Me.columnComprobanteTipoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPuntoVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnDocumentoNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnCategoriaIVANombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelPaso1.SuspendLayout()
        CType(Me.datagridviewEntidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelPaso2.SuspendLayout()
        CType(Me.datagridviewFacturaDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.datagridviewFacturaCabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelEntidad
        '
        Me.labelEntidad.AutoSize = True
        Me.labelEntidad.Location = New System.Drawing.Point(4, 82)
        Me.labelEntidad.Name = "labelEntidad"
        Me.labelEntidad.Size = New System.Drawing.Size(60, 17)
        Me.labelEntidad.TabIndex = 0
        Me.labelEntidad.Text = "Entidad:"
        '
        'buttonEntidad
        '
        Me.buttonEntidad.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonEntidad.Location = New System.Drawing.Point(519, 76)
        Me.buttonEntidad.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonEntidad.Name = "buttonEntidad"
        Me.buttonEntidad.Size = New System.Drawing.Size(29, 28)
        Me.buttonEntidad.TabIndex = 10
        Me.buttonEntidad.UseVisualStyleBackColor = True
        '
        'panelPaso1
        '
        Me.panelPaso1.Controls.Add(Me.textboxAnioLectivo)
        Me.panelPaso1.Controls.Add(Me.labelAnioLectivo)
        Me.panelPaso1.Controls.Add(Me.datagridviewEntidades)
        Me.panelPaso1.Controls.Add(Me.labelAlumnos)
        Me.panelPaso1.Controls.Add(Me.textboxEntidad)
        Me.panelPaso1.Controls.Add(Me.labelEntidad)
        Me.panelPaso1.Controls.Add(Me.buttonEntidad)
        Me.panelPaso1.Controls.Add(Me.buttonPaso1Cancelar)
        Me.panelPaso1.Controls.Add(Me.buttonPaso1Siguiente)
        Me.panelPaso1.Controls.Add(Me.labelPaso1)
        Me.panelPaso1.Location = New System.Drawing.Point(12, 12)
        Me.panelPaso1.Name = "panelPaso1"
        Me.panelPaso1.Size = New System.Drawing.Size(886, 404)
        Me.panelPaso1.TabIndex = 12
        '
        'textboxAnioLectivo
        '
        Me.textboxAnioLectivo.Location = New System.Drawing.Point(96, 48)
        Me.textboxAnioLectivo.Name = "textboxAnioLectivo"
        Me.textboxAnioLectivo.ReadOnly = True
        Me.textboxAnioLectivo.Size = New System.Drawing.Size(49, 22)
        Me.textboxAnioLectivo.TabIndex = 17
        Me.textboxAnioLectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'labelAnioLectivo
        '
        Me.labelAnioLectivo.AutoSize = True
        Me.labelAnioLectivo.Location = New System.Drawing.Point(4, 51)
        Me.labelAnioLectivo.Name = "labelAnioLectivo"
        Me.labelAnioLectivo.Size = New System.Drawing.Size(86, 17)
        Me.labelAnioLectivo.TabIndex = 16
        Me.labelAnioLectivo.Text = "Año Lectivo:"
        '
        'datagridviewEntidades
        '
        Me.datagridviewEntidades.AllowUserToAddRows = False
        Me.datagridviewEntidades.AllowUserToDeleteRows = False
        Me.datagridviewEntidades.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewEntidades.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewEntidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.datagridviewEntidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewEntidades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnSeleccionado, Me.columnApellidoNombre, Me.columnCursoActual, Me.columnCursoProximo})
        Me.datagridviewEntidades.Location = New System.Drawing.Point(4, 135)
        Me.datagridviewEntidades.Margin = New System.Windows.Forms.Padding(4)
        Me.datagridviewEntidades.MultiSelect = False
        Me.datagridviewEntidades.Name = "datagridviewEntidades"
        Me.datagridviewEntidades.RowHeadersVisible = False
        Me.datagridviewEntidades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewEntidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewEntidades.Size = New System.Drawing.Size(878, 204)
        Me.datagridviewEntidades.TabIndex = 15
        '
        'columnSeleccionado
        '
        Me.columnSeleccionado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnSeleccionado.DataPropertyName = "Seleccionado"
        Me.columnSeleccionado.HeaderText = ""
        Me.columnSeleccionado.Name = "columnSeleccionado"
        Me.columnSeleccionado.Width = 5
        '
        'columnApellidoNombre
        '
        Me.columnApellidoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnApellidoNombre.DataPropertyName = "ApellidoNombre"
        Me.columnApellidoNombre.HeaderText = "Alumno"
        Me.columnApellidoNombre.Name = "columnApellidoNombre"
        Me.columnApellidoNombre.ReadOnly = True
        Me.columnApellidoNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnApellidoNombre.Width = 61
        '
        'columnCursoActual
        '
        Me.columnCursoActual.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnCursoActual.DataPropertyName = "AnioLectivoCursoActualNombre"
        Me.columnCursoActual.HeaderText = "Curso actual"
        Me.columnCursoActual.Name = "columnCursoActual"
        Me.columnCursoActual.ReadOnly = True
        Me.columnCursoActual.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnCursoActual.Width = 93
        '
        'columnCursoProximo
        '
        Me.columnCursoProximo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnCursoProximo.DataPropertyName = "AnioLectivoCursoProximoNombre"
        Me.columnCursoProximo.HeaderText = "Curso próximo"
        Me.columnCursoProximo.Name = "columnCursoProximo"
        Me.columnCursoProximo.ReadOnly = True
        Me.columnCursoProximo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.columnCursoProximo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnCursoProximo.Width = 104
        '
        'labelAlumnos
        '
        Me.labelAlumnos.AutoSize = True
        Me.labelAlumnos.Location = New System.Drawing.Point(4, 114)
        Me.labelAlumnos.Name = "labelAlumnos"
        Me.labelAlumnos.Size = New System.Drawing.Size(182, 17)
        Me.labelAlumnos.TabIndex = 13
        Me.labelAlumnos.Text = "Alumnos y Cursos actuales:"
        '
        'textboxEntidad
        '
        Me.textboxEntidad.Location = New System.Drawing.Point(96, 79)
        Me.textboxEntidad.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxEntidad.MaxLength = 150
        Me.textboxEntidad.Name = "textboxEntidad"
        Me.textboxEntidad.ReadOnly = True
        Me.textboxEntidad.Size = New System.Drawing.Size(422, 22)
        Me.textboxEntidad.TabIndex = 11
        Me.textboxEntidad.TabStop = False
        '
        'buttonPaso1Cancelar
        '
        Me.buttonPaso1Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso1Cancelar.Location = New System.Drawing.Point(591, 362)
        Me.buttonPaso1Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonPaso1Cancelar.Name = "buttonPaso1Cancelar"
        Me.buttonPaso1Cancelar.Size = New System.Drawing.Size(100, 42)
        Me.buttonPaso1Cancelar.TabIndex = 7
        Me.buttonPaso1Cancelar.Text = "Cancelar"
        Me.buttonPaso1Cancelar.UseVisualStyleBackColor = True
        '
        'buttonPaso1Siguiente
        '
        Me.buttonPaso1Siguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso1Siguiente.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_NEXT_24
        Me.buttonPaso1Siguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso1Siguiente.Location = New System.Drawing.Point(699, 362)
        Me.buttonPaso1Siguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonPaso1Siguiente.Name = "buttonPaso1Siguiente"
        Me.buttonPaso1Siguiente.Size = New System.Drawing.Size(187, 42)
        Me.buttonPaso1Siguiente.TabIndex = 8
        Me.buttonPaso1Siguiente.Text = "Paso 2: Verificación"
        Me.buttonPaso1Siguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso1Siguiente.UseVisualStyleBackColor = True
        '
        'labelPaso1
        '
        Me.labelPaso1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPaso1.Location = New System.Drawing.Point(3, 0)
        Me.labelPaso1.Name = "labelPaso1"
        Me.labelPaso1.Size = New System.Drawing.Size(880, 51)
        Me.labelPaso1.TabIndex = 0
        Me.labelPaso1.Text = "Paso 1: Seleccione la Entidad para iniciar el proceso de Inscripción de uno o más" & _
    " alumnos a un nuevo Ciclo Lectivo. Puede seleccionar el Alumno o el Titular de l" & _
    "a Factura."
        '
        'panelPaso2
        '
        Me.panelPaso2.Controls.Add(Me.buttonPaso2Anterior)
        Me.panelPaso2.Controls.Add(Me.buttonPaso2Finalizar)
        Me.panelPaso2.Controls.Add(Me.labelPaso2)
        Me.panelPaso2.Controls.Add(Me.datagridviewFacturaDetalle)
        Me.panelPaso2.Controls.Add(Me.datagridviewFacturaCabecera)
        Me.panelPaso2.Location = New System.Drawing.Point(12, 12)
        Me.panelPaso2.Name = "panelPaso2"
        Me.panelPaso2.Size = New System.Drawing.Size(886, 404)
        Me.panelPaso2.TabIndex = 13
        '
        'buttonPaso2Anterior
        '
        Me.buttonPaso2Anterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso2Anterior.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_PREVIOUS_24
        Me.buttonPaso2Anterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso2Anterior.Location = New System.Drawing.Point(504, 362)
        Me.buttonPaso2Anterior.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonPaso2Anterior.Name = "buttonPaso2Anterior"
        Me.buttonPaso2Anterior.Size = New System.Drawing.Size(187, 42)
        Me.buttonPaso2Anterior.TabIndex = 10
        Me.buttonPaso2Anterior.Text = "Paso 1: Selección"
        Me.buttonPaso2Anterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso2Anterior.UseVisualStyleBackColor = True
        '
        'buttonPaso2Finalizar
        '
        Me.buttonPaso2Finalizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso2Finalizar.Location = New System.Drawing.Point(699, 362)
        Me.buttonPaso2Finalizar.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonPaso2Finalizar.Name = "buttonPaso2Finalizar"
        Me.buttonPaso2Finalizar.Size = New System.Drawing.Size(187, 42)
        Me.buttonPaso2Finalizar.TabIndex = 9
        Me.buttonPaso2Finalizar.Text = "Finalizar"
        Me.buttonPaso2Finalizar.UseVisualStyleBackColor = True
        '
        'labelPaso2
        '
        Me.labelPaso2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPaso2.Location = New System.Drawing.Point(3, 0)
        Me.labelPaso2.Name = "labelPaso2"
        Me.labelPaso2.Size = New System.Drawing.Size(880, 30)
        Me.labelPaso2.TabIndex = 3
        Me.labelPaso2.Text = "Paso 2: Verifique que la(s) Factura(s) a generar esté(n) correcta(s)."
        '
        'datagridviewFacturaDetalle
        '
        Me.datagridviewFacturaDetalle.AllowUserToAddRows = False
        Me.datagridviewFacturaDetalle.AllowUserToDeleteRows = False
        Me.datagridviewFacturaDetalle.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewFacturaDetalle.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.datagridviewFacturaDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.datagridviewFacturaDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewFacturaDetalle.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnDescripcion, Me.columnPrecioTotal})
        Me.datagridviewFacturaDetalle.Location = New System.Drawing.Point(38, 221)
        Me.datagridviewFacturaDetalle.Margin = New System.Windows.Forms.Padding(4)
        Me.datagridviewFacturaDetalle.MultiSelect = False
        Me.datagridviewFacturaDetalle.Name = "datagridviewFacturaDetalle"
        Me.datagridviewFacturaDetalle.ReadOnly = True
        Me.datagridviewFacturaDetalle.RowHeadersVisible = False
        Me.datagridviewFacturaDetalle.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewFacturaDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewFacturaDetalle.Size = New System.Drawing.Size(807, 123)
        Me.datagridviewFacturaDetalle.TabIndex = 2
        '
        'columnDescripcion
        '
        Me.columnDescripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnDescripcion.DataPropertyName = "Descripcion"
        Me.columnDescripcion.HeaderText = "Descripción"
        Me.columnDescripcion.Name = "columnDescripcion"
        Me.columnDescripcion.ReadOnly = True
        Me.columnDescripcion.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnDescripcion.Width = 88
        '
        'columnPrecioTotal
        '
        Me.columnPrecioTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPrecioTotal.DataPropertyName = "PrecioTotal"
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = "0"
        Me.columnPrecioTotal.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnPrecioTotal.HeaderText = "Precio"
        Me.columnPrecioTotal.Name = "columnPrecioTotal"
        Me.columnPrecioTotal.ReadOnly = True
        Me.columnPrecioTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnPrecioTotal.Width = 54
        '
        'datagridviewFacturaCabecera
        '
        Me.datagridviewFacturaCabecera.AllowUserToAddRows = False
        Me.datagridviewFacturaCabecera.AllowUserToDeleteRows = False
        Me.datagridviewFacturaCabecera.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewFacturaCabecera.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.datagridviewFacturaCabecera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.datagridviewFacturaCabecera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewFacturaCabecera.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnComprobanteTipoNombre, Me.columnPuntoVenta, Me.columnNumero, Me.DataGridViewTextBoxColumn1, Me.columnDocumentoNumero, Me.columnCategoriaIVANombre, Me.columnImporteTotal})
        Me.datagridviewFacturaCabecera.Location = New System.Drawing.Point(38, 34)
        Me.datagridviewFacturaCabecera.Margin = New System.Windows.Forms.Padding(4)
        Me.datagridviewFacturaCabecera.MultiSelect = False
        Me.datagridviewFacturaCabecera.Name = "datagridviewFacturaCabecera"
        Me.datagridviewFacturaCabecera.ReadOnly = True
        Me.datagridviewFacturaCabecera.RowHeadersVisible = False
        Me.datagridviewFacturaCabecera.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewFacturaCabecera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewFacturaCabecera.Size = New System.Drawing.Size(807, 156)
        Me.datagridviewFacturaCabecera.TabIndex = 1
        '
        'columnComprobanteTipoNombre
        '
        Me.columnComprobanteTipoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnComprobanteTipoNombre.DataPropertyName = "ComprobanteTipo.Nombre"
        Me.columnComprobanteTipoNombre.HeaderText = "Tipo"
        Me.columnComprobanteTipoNombre.Name = "columnComprobanteTipoNombre"
        Me.columnComprobanteTipoNombre.ReadOnly = True
        Me.columnComprobanteTipoNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnComprobanteTipoNombre.Width = 42
        '
        'columnPuntoVenta
        '
        Me.columnPuntoVenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPuntoVenta.DataPropertyName = "PuntoVenta"
        Me.columnPuntoVenta.HeaderText = "Punto Venta"
        Me.columnPuntoVenta.Name = "columnPuntoVenta"
        Me.columnPuntoVenta.ReadOnly = True
        Me.columnPuntoVenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnPuntoVenta.Width = 83
        '
        'columnNumero
        '
        Me.columnNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNumero.DataPropertyName = "Numero"
        Me.columnNumero.HeaderText = "Factura N°"
        Me.columnNumero.Name = "columnNumero"
        Me.columnNumero.ReadOnly = True
        Me.columnNumero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnNumero.Width = 74
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ApellidoNombre"
        Me.DataGridViewTextBoxColumn1.HeaderText = "Apellido y Nombre"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.DataGridViewTextBoxColumn1.Width = 116
        '
        'columnDocumentoNumero
        '
        Me.columnDocumentoNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnDocumentoNumero.DataPropertyName = "DocumentoNumero"
        Me.columnDocumentoNumero.HeaderText = "N° Documento"
        Me.columnDocumentoNumero.Name = "columnDocumentoNumero"
        Me.columnDocumentoNumero.ReadOnly = True
        Me.columnDocumentoNumero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnDocumentoNumero.Width = 95
        '
        'columnCategoriaIVANombre
        '
        Me.columnCategoriaIVANombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnCategoriaIVANombre.DataPropertyName = "CategoriaIVANombre"
        Me.columnCategoriaIVANombre.HeaderText = "IVA"
        Me.columnCategoriaIVANombre.Name = "columnCategoriaIVANombre"
        Me.columnCategoriaIVANombre.ReadOnly = True
        Me.columnCategoriaIVANombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnCategoriaIVANombre.Width = 35
        '
        'columnImporteTotal
        '
        Me.columnImporteTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = "0"
        Me.columnImporteTotal.DefaultCellStyle = DataGridViewCellStyle5
        Me.columnImporteTotal.HeaderText = "Importe"
        Me.columnImporteTotal.Name = "columnImporteTotal"
        Me.columnImporteTotal.ReadOnly = True
        Me.columnImporteTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnImporteTotal.Width = 61
        '
        'formEntidadInscripcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(913, 428)
        Me.Controls.Add(Me.panelPaso1)
        Me.Controls.Add(Me.panelPaso2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = false
        Me.Name = "formEntidadInscripcion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Inscripción a un nuevo Ciclo Lectivo"
        Me.panelPaso1.ResumeLayout(false)
        Me.panelPaso1.PerformLayout
        CType(Me.datagridviewEntidades,System.ComponentModel.ISupportInitialize).EndInit
        Me.panelPaso2.ResumeLayout(false)
        CType(Me.datagridviewFacturaDetalle,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.datagridviewFacturaCabecera,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents labelEntidad As System.Windows.Forms.Label
    Friend WithEvents buttonEntidad As System.Windows.Forms.Button
    Friend WithEvents panelPaso1 As System.Windows.Forms.Panel
    Friend WithEvents buttonPaso1Cancelar As System.Windows.Forms.Button
    Friend WithEvents buttonPaso1Siguiente As System.Windows.Forms.Button
    Friend WithEvents labelPaso1 As System.Windows.Forms.Label
    Friend WithEvents textboxEntidad As System.Windows.Forms.TextBox
    Friend WithEvents labelAlumnos As System.Windows.Forms.Label
    Friend WithEvents datagridviewEntidades As System.Windows.Forms.DataGridView
    Friend WithEvents labelAnioLectivo As System.Windows.Forms.Label
    Friend WithEvents textboxAnioLectivo As System.Windows.Forms.TextBox
    Friend WithEvents panelPaso2 As System.Windows.Forms.Panel
    Friend WithEvents datagridviewFacturaCabecera As System.Windows.Forms.DataGridView
    Friend WithEvents columnComprobanteTipoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPuntoVenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnDocumentoNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnCategoriaIVANombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents datagridviewFacturaDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents columnDescripcion As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPrecioTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents labelPaso2 As System.Windows.Forms.Label
    Friend WithEvents buttonPaso2Finalizar As System.Windows.Forms.Button
    Friend WithEvents buttonPaso2Anterior As System.Windows.Forms.Button
    Friend WithEvents columnSeleccionado As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents columnApellidoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnCursoActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnCursoProximo As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
