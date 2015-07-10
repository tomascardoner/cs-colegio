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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.statuslabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusstripMain = New System.Windows.Forms.StatusStrip()
        Me.datagridviewMain = New System.Windows.Forms.DataGridView()
        Me.columnComprobanteTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPuntoVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnFecha = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnTitular = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnCAE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelToolbars = New System.Windows.Forms.FlowLayoutPanel()
        Me.toolstripButtons = New System.Windows.Forms.ToolStrip()
        Me.buttonAgregar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEliminar = New System.Windows.Forms.ToolStripButton()
        Me.buttonImprimir = New System.Windows.Forms.ToolStripSplitButton()
        Me.menuitemImprimirPrevisualizar = New System.Windows.Forms.ToolStripMenuItem()
        Me.buttonEnviarEmail = New System.Windows.Forms.ToolStripButton()
        Me.toolstripPeriodo = New System.Windows.Forms.ToolStrip()
        Me.labelPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxPeriodo = New System.Windows.Forms.ToolStripComboBox()
        Me.toolstripComprobanteTipo = New System.Windows.Forms.ToolStrip()
        Me.labelComprobanteTipo = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxOperacionTipo = New System.Windows.Forms.ToolStripComboBox()
        Me.comboboxComprobanteTipo = New System.Windows.Forms.ToolStripComboBox()
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
        Me.statusstripMain.SuspendLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelToolbars.SuspendLayout()
        Me.toolstripButtons.SuspendLayout()
        Me.toolstripPeriodo.SuspendLayout()
        Me.toolstripComprobanteTipo.SuspendLayout()
        Me.toolstripTitular.SuspendLayout()
        Me.toolstripBuscar.SuspendLayout()
        Me.SuspendLayout()
        '
        'statuslabelMain
        '
        Me.statuslabelMain.Name = "statuslabelMain"
        Me.statuslabelMain.Size = New System.Drawing.Size(981, 17)
        Me.statuslabelMain.Spring = True
        Me.statuslabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'statusstripMain
        '
        Me.statusstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statuslabelMain})
        Me.statusstripMain.Location = New System.Drawing.Point(0, 389)
        Me.statusstripMain.Name = "statusstripMain"
        Me.statusstripMain.Size = New System.Drawing.Size(996, 22)
        Me.statusstripMain.TabIndex = 4
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
        Me.datagridviewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnComprobanteTipo, Me.columnPuntoVenta, Me.columnNumero, Me.columnFecha, Me.columnTitular, Me.columnImporteTotal, Me.columnCAE})
        Me.datagridviewMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datagridviewMain.Location = New System.Drawing.Point(0, 64)
        Me.datagridviewMain.MultiSelect = False
        Me.datagridviewMain.Name = "datagridviewMain"
        Me.datagridviewMain.ReadOnly = True
        Me.datagridviewMain.RowHeadersVisible = False
        Me.datagridviewMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewMain.Size = New System.Drawing.Size(996, 325)
        Me.datagridviewMain.TabIndex = 0
        '
        'columnComprobanteTipo
        '
        Me.columnComprobanteTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnComprobanteTipo.DataPropertyName = "ComprobanteTipoNombre"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnComprobanteTipo.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnComprobanteTipo.HeaderText = "Tipo"
        Me.columnComprobanteTipo.Name = "columnComprobanteTipo"
        Me.columnComprobanteTipo.ReadOnly = True
        Me.columnComprobanteTipo.Width = 53
        '
        'columnPuntoVenta
        '
        Me.columnPuntoVenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPuntoVenta.DataPropertyName = "PuntoVenta"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnPuntoVenta.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnPuntoVenta.HeaderText = "Punto de Venta"
        Me.columnPuntoVenta.Name = "columnPuntoVenta"
        Me.columnPuntoVenta.ReadOnly = True
        Me.columnPuntoVenta.Width = 106
        '
        'columnNumero
        '
        Me.columnNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNumero.DataPropertyName = "Numero"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnNumero.DefaultCellStyle = DataGridViewCellStyle4
        Me.columnNumero.HeaderText = "Número"
        Me.columnNumero.Name = "columnNumero"
        Me.columnNumero.ReadOnly = True
        Me.columnNumero.Width = 69
        '
        'columnFecha
        '
        Me.columnFecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnFecha.DataPropertyName = "FechaEmision"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnFecha.DefaultCellStyle = DataGridViewCellStyle5
        Me.columnFecha.HeaderText = "Fecha"
        Me.columnFecha.Name = "columnFecha"
        Me.columnFecha.ReadOnly = True
        Me.columnFecha.Width = 62
        '
        'columnTitular
        '
        Me.columnTitular.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTitular.DataPropertyName = "EntidadNombre"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnTitular.DefaultCellStyle = DataGridViewCellStyle6
        Me.columnTitular.HeaderText = "Titular"
        Me.columnTitular.Name = "columnTitular"
        Me.columnTitular.ReadOnly = True
        Me.columnTitular.Width = 61
        '
        'columnImporteTotal
        '
        Me.columnImporteTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.columnImporteTotal.DefaultCellStyle = DataGridViewCellStyle7
        Me.columnImporteTotal.HeaderText = "Importe Total"
        Me.columnImporteTotal.Name = "columnImporteTotal"
        Me.columnImporteTotal.ReadOnly = True
        Me.columnImporteTotal.Width = 94
        '
        'columnCAE
        '
        Me.columnCAE.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnCAE.DataPropertyName = "CAE"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnCAE.DefaultCellStyle = DataGridViewCellStyle8
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
        Me.panelToolbars.Controls.Add(Me.toolstripTitular)
        Me.panelToolbars.Controls.Add(Me.toolstripBuscar)
        Me.panelToolbars.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelToolbars.Location = New System.Drawing.Point(0, 0)
        Me.panelToolbars.Name = "panelToolbars"
        Me.panelToolbars.Size = New System.Drawing.Size(996, 64)
        Me.panelToolbars.TabIndex = 0
        '
        'toolstripButtons
        '
        Me.toolstripButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonAgregar, Me.buttonEditar, Me.buttonEliminar, Me.buttonImprimir, Me.buttonEnviarEmail})
        Me.toolstripButtons.Location = New System.Drawing.Point(0, 0)
        Me.toolstripButtons.Name = "toolstripButtons"
        Me.toolstripButtons.Size = New System.Drawing.Size(465, 39)
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
        Me.buttonImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemImprimirPrevisualizar})
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
        Me.menuitemImprimirPrevisualizar.Size = New System.Drawing.Size(155, 38)
        Me.menuitemImprimirPrevisualizar.Text = "Previsualizar"
        '
        'buttonEnviarEmail
        '
        Me.buttonEnviarEmail.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_EMAIL_32
        Me.buttonEnviarEmail.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEnviarEmail.Name = "buttonEnviarEmail"
        Me.buttonEnviarEmail.Size = New System.Drawing.Size(117, 36)
        Me.buttonEnviarEmail.Text = "Enviar por e-mail"
        '
        'toolstripPeriodo
        '
        Me.toolstripPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripPeriodo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripPeriodo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelPeriodo, Me.comboboxPeriodo})
        Me.toolstripPeriodo.Location = New System.Drawing.Point(465, 0)
        Me.toolstripPeriodo.Name = "toolstripPeriodo"
        Me.toolstripPeriodo.Size = New System.Drawing.Size(131, 39)
        Me.toolstripPeriodo.TabIndex = 8
        '
        'labelPeriodo
        '
        Me.labelPeriodo.Name = "labelPeriodo"
        Me.labelPeriodo.Size = New System.Drawing.Size(51, 36)
        Me.labelPeriodo.Text = "Período:"
        '
        'comboboxPeriodo
        '
        Me.comboboxPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxPeriodo.Name = "comboboxPeriodo"
        Me.comboboxPeriodo.Size = New System.Drawing.Size(75, 39)
        '
        'toolstripComprobanteTipo
        '
        Me.toolstripComprobanteTipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripComprobanteTipo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripComprobanteTipo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelComprobanteTipo, Me.comboboxOperacionTipo, Me.comboboxComprobanteTipo})
        Me.toolstripComprobanteTipo.Location = New System.Drawing.Point(596, 0)
        Me.toolstripComprobanteTipo.Name = "toolstripComprobanteTipo"
        Me.toolstripComprobanteTipo.Size = New System.Drawing.Size(266, 39)
        Me.toolstripComprobanteTipo.TabIndex = 10
        '
        'labelComprobanteTipo
        '
        Me.labelComprobanteTipo.Name = "labelComprobanteTipo"
        Me.labelComprobanteTipo.Size = New System.Drawing.Size(34, 36)
        Me.labelComprobanteTipo.Text = "Tipo:"
        '
        'comboboxOperacionTipo
        '
        Me.comboboxOperacionTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxOperacionTipo.Name = "comboboxOperacionTipo"
        Me.comboboxOperacionTipo.Size = New System.Drawing.Size(75, 39)
        '
        'comboboxComprobanteTipo
        '
        Me.comboboxComprobanteTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxComprobanteTipo.Name = "comboboxComprobanteTipo"
        Me.comboboxComprobanteTipo.Size = New System.Drawing.Size(150, 39)
        '
        'toolstripTitular
        '
        Me.toolstripTitular.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripTitular.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripTitular.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelEntidad, Me.textboxEntidad, Me.buttonEntidad, Me.buttonEntidadBorrar})
        Me.toolstripTitular.Location = New System.Drawing.Point(0, 39)
        Me.toolstripTitular.Name = "toolstripTitular"
        Me.toolstripTitular.Size = New System.Drawing.Size(295, 25)
        Me.toolstripTitular.TabIndex = 7
        '
        'labelEntidad
        '
        Me.labelEntidad.Name = "labelEntidad"
        Me.labelEntidad.Size = New System.Drawing.Size(44, 22)
        Me.labelEntidad.Text = "Titular:"
        '
        'textboxEntidad
        '
        Me.textboxEntidad.Name = "textboxEntidad"
        Me.textboxEntidad.ReadOnly = True
        Me.textboxEntidad.Size = New System.Drawing.Size(200, 25)
        '
        'buttonEntidad
        '
        Me.buttonEntidad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.buttonEntidad.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonEntidad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEntidad.Name = "buttonEntidad"
        Me.buttonEntidad.Size = New System.Drawing.Size(23, 22)
        '
        'buttonEntidadBorrar
        '
        Me.buttonEntidadBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.buttonEntidadBorrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_16
        Me.buttonEntidadBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEntidadBorrar.Name = "buttonEntidadBorrar"
        Me.buttonEntidadBorrar.Size = New System.Drawing.Size(23, 22)
        '
        'toolstripBuscar
        '
        Me.toolstripBuscar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripBuscar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripBuscar.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelBuscar, Me.comboboxBuscarTipo, Me.textboxBuscar, Me.buttonBuscarBorrar})
        Me.toolstripBuscar.Location = New System.Drawing.Point(295, 39)
        Me.toolstripBuscar.Name = "toolstripBuscar"
        Me.toolstripBuscar.Size = New System.Drawing.Size(296, 25)
        Me.toolstripBuscar.TabIndex = 9
        '
        'labelBuscar
        '
        Me.labelBuscar.Name = "labelBuscar"
        Me.labelBuscar.Size = New System.Drawing.Size(66, 22)
        Me.labelBuscar.Text = "Buscar por:"
        '
        'comboboxBuscarTipo
        '
        Me.comboboxBuscarTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxBuscarTipo.Name = "comboboxBuscarTipo"
        Me.comboboxBuscarTipo.Size = New System.Drawing.Size(80, 25)
        '
        'textboxBuscar
        '
        Me.textboxBuscar.MaxLength = 100
        Me.textboxBuscar.Name = "textboxBuscar"
        Me.textboxBuscar.Size = New System.Drawing.Size(120, 25)
        '
        'buttonBuscarBorrar
        '
        Me.buttonBuscarBorrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.buttonBuscarBorrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_16
        Me.buttonBuscarBorrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonBuscarBorrar.Name = "buttonBuscarBorrar"
        Me.buttonBuscarBorrar.Size = New System.Drawing.Size(23, 22)
        Me.buttonBuscarBorrar.ToolTipText = "Limpiar búsqueda"
        '
        'formComprobantes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(996, 411)
        Me.Controls.Add(Me.datagridviewMain)
        Me.Controls.Add(Me.panelToolbars)
        Me.Controls.Add(Me.statusstripMain)
        Me.Name = "formComprobantes"
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
        Me.toolstripTitular.ResumeLayout(False)
        Me.toolstripTitular.PerformLayout()
        Me.toolstripBuscar.ResumeLayout(False)
        Me.toolstripBuscar.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents statuslabelMain As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusstripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents datagridviewMain As System.Windows.Forms.DataGridView
    Friend WithEvents panelToolbars As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents toolstripButtons As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonAgregar As System.Windows.Forms.ToolStripButton
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
    Friend WithEvents comboboxPeriodo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents toolstripComprobanteTipo As System.Windows.Forms.ToolStrip
    Friend WithEvents labelComprobanteTipo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxComprobanteTipo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents comboboxOperacionTipo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents buttonImprimir As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents menuitemImprimirPrevisualizar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents buttonEnviarEmail As System.Windows.Forms.ToolStripButton
    Friend WithEvents columnComprobanteTipo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPuntoVenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnFecha As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnTitular As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnCAE As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
