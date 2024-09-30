<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formAnioLectivoCuotas
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.statuslabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusstripMain = New System.Windows.Forms.StatusStrip()
        Me.panelToolbars = New System.Windows.Forms.FlowLayoutPanel()
        Me.toolstripButtons = New System.Windows.Forms.ToolStrip()
        Me.buttonAgregar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEliminar = New System.Windows.Forms.ToolStripButton()
        Me.toolsptripAnioLectivo = New System.Windows.Forms.ToolStrip()
        Me.labelAnioLectivo = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxAnioLectivo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripMesInicio = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabelMesInicio = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBoxMesInicio = New System.Windows.Forms.ToolStripComboBox()
        Me.datagridviewMain = New System.Windows.Forms.DataGridView()
        Me.columnMesInicio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnCuotaTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteMatricula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statusstripMain.SuspendLayout()
        Me.panelToolbars.SuspendLayout()
        Me.toolstripButtons.SuspendLayout()
        Me.toolsptripAnioLectivo.SuspendLayout()
        Me.ToolStripMesInicio.SuspendLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'statuslabelMain
        '
        Me.statuslabelMain.Name = "statuslabelMain"
        Me.statuslabelMain.Size = New System.Drawing.Size(1356, 16)
        Me.statuslabelMain.Spring = True
        Me.statuslabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'statusstripMain
        '
        Me.statusstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.statusstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statuslabelMain})
        Me.statusstripMain.Location = New System.Drawing.Point(0, 484)
        Me.statusstripMain.Name = "statusstripMain"
        Me.statusstripMain.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.statusstripMain.Size = New System.Drawing.Size(1376, 22)
        Me.statusstripMain.TabIndex = 4
        '
        'panelToolbars
        '
        Me.panelToolbars.AutoSize = True
        Me.panelToolbars.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelToolbars.Controls.Add(Me.toolstripButtons)
        Me.panelToolbars.Controls.Add(Me.toolsptripAnioLectivo)
        Me.panelToolbars.Controls.Add(Me.ToolStripMesInicio)
        Me.panelToolbars.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelToolbars.Location = New System.Drawing.Point(0, 0)
        Me.panelToolbars.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.panelToolbars.Name = "panelToolbars"
        Me.panelToolbars.Size = New System.Drawing.Size(1376, 39)
        Me.panelToolbars.TabIndex = 0
        '
        'toolstripButtons
        '
        Me.toolstripButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripButtons.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonAgregar, Me.buttonEditar, Me.buttonEliminar})
        Me.toolstripButtons.Location = New System.Drawing.Point(0, 0)
        Me.toolstripButtons.Name = "toolstripButtons"
        Me.toolstripButtons.Size = New System.Drawing.Size(285, 39)
        Me.toolstripButtons.TabIndex = 1
        '
        'buttonAgregar
        '
        Me.buttonAgregar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_ADD_32
        Me.buttonAgregar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonAgregar.Name = "buttonAgregar"
        Me.buttonAgregar.Size = New System.Drawing.Size(99, 36)
        Me.buttonAgregar.Text = "Agregar"
        '
        'buttonEditar
        '
        Me.buttonEditar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_EDIT_32
        Me.buttonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEditar.Name = "buttonEditar"
        Me.buttonEditar.Size = New System.Drawing.Size(84, 36)
        Me.buttonEditar.Text = "Editar"
        '
        'buttonEliminar
        '
        Me.buttonEliminar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_DELETE_32
        Me.buttonEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEliminar.Name = "buttonEliminar"
        Me.buttonEliminar.Size = New System.Drawing.Size(99, 36)
        Me.buttonEliminar.Text = "Eliminar"
        '
        'toolsptripAnioLectivo
        '
        Me.toolsptripAnioLectivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolsptripAnioLectivo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolsptripAnioLectivo.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolsptripAnioLectivo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelAnioLectivo, Me.comboboxAnioLectivo})
        Me.toolsptripAnioLectivo.Location = New System.Drawing.Point(285, 0)
        Me.toolsptripAnioLectivo.Name = "toolsptripAnioLectivo"
        Me.toolsptripAnioLectivo.Size = New System.Drawing.Size(194, 39)
        Me.toolsptripAnioLectivo.TabIndex = 14
        '
        'labelAnioLectivo
        '
        Me.labelAnioLectivo.Name = "labelAnioLectivo"
        Me.labelAnioLectivo.Size = New System.Drawing.Size(90, 36)
        Me.labelAnioLectivo.Text = "Año Lectivo:"
        '
        'comboboxAnioLectivo
        '
        Me.comboboxAnioLectivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnioLectivo.Name = "comboboxAnioLectivo"
        Me.comboboxAnioLectivo.Size = New System.Drawing.Size(99, 39)
        '
        'ToolStripMesInicio
        '
        Me.ToolStripMesInicio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripMesInicio.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripMesInicio.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripMesInicio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabelMesInicio, Me.ToolStripComboBoxMesInicio})
        Me.ToolStripMesInicio.Location = New System.Drawing.Point(479, 0)
        Me.ToolStripMesInicio.Name = "ToolStripMesInicio"
        Me.ToolStripMesInicio.Size = New System.Drawing.Size(264, 39)
        Me.ToolStripMesInicio.TabIndex = 15
        '
        'ToolStripLabelMesInicio
        '
        Me.ToolStripLabelMesInicio.Name = "ToolStripLabelMesInicio"
        Me.ToolStripLabelMesInicio.Size = New System.Drawing.Size(100, 36)
        Me.ToolStripLabelMesInicio.Text = "Mes de inicio:"
        '
        'ToolStripComboBoxMesInicio
        '
        Me.ToolStripComboBoxMesInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBoxMesInicio.Name = "ToolStripComboBoxMesInicio"
        Me.ToolStripComboBoxMesInicio.Size = New System.Drawing.Size(159, 39)
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
        Me.datagridviewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnMesInicio, Me.columnCuotaTipo, Me.columnImporteMatricula, Me.columnImporteCuota})
        Me.datagridviewMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datagridviewMain.Location = New System.Drawing.Point(0, 39)
        Me.datagridviewMain.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.datagridviewMain.MultiSelect = False
        Me.datagridviewMain.Name = "datagridviewMain"
        Me.datagridviewMain.ReadOnly = True
        Me.datagridviewMain.RowHeadersVisible = False
        Me.datagridviewMain.RowHeadersWidth = 51
        Me.datagridviewMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewMain.Size = New System.Drawing.Size(1376, 445)
        Me.datagridviewMain.TabIndex = 0
        '
        'columnMesInicio
        '
        Me.columnMesInicio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnMesInicio.DataPropertyName = "MesInicioNombre"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnMesInicio.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnMesInicio.HeaderText = "Mes inicio"
        Me.columnMesInicio.MinimumWidth = 6
        Me.columnMesInicio.Name = "columnMesInicio"
        Me.columnMesInicio.ReadOnly = True
        Me.columnMesInicio.Width = 96
        '
        'columnCuotaTipo
        '
        Me.columnCuotaTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnCuotaTipo.DataPropertyName = "CuotaTipoNombre"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnCuotaTipo.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnCuotaTipo.HeaderText = "Tipo de cuota"
        Me.columnCuotaTipo.MinimumWidth = 6
        Me.columnCuotaTipo.Name = "columnCuotaTipo"
        Me.columnCuotaTipo.ReadOnly = True
        Me.columnCuotaTipo.Width = 119
        '
        'columnImporteMatricula
        '
        Me.columnImporteMatricula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteMatricula.DataPropertyName = "ImporteMatricula"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.columnImporteMatricula.DefaultCellStyle = DataGridViewCellStyle4
        Me.columnImporteMatricula.HeaderText = "Importe matrícula"
        Me.columnImporteMatricula.MinimumWidth = 6
        Me.columnImporteMatricula.Name = "columnImporteMatricula"
        Me.columnImporteMatricula.ReadOnly = True
        Me.columnImporteMatricula.Width = 127
        '
        'columnImporteCuota
        '
        Me.columnImporteCuota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteCuota.DataPropertyName = "ImporteCuota"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.columnImporteCuota.DefaultCellStyle = DataGridViewCellStyle5
        Me.columnImporteCuota.HeaderText = "Importe cuota"
        Me.columnImporteCuota.MinimumWidth = 6
        Me.columnImporteCuota.Name = "columnImporteCuota"
        Me.columnImporteCuota.ReadOnly = True
        Me.columnImporteCuota.Width = 108
        '
        'formAnioLectivoCuotas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1376, 506)
        Me.Controls.Add(Me.datagridviewMain)
        Me.Controls.Add(Me.panelToolbars)
        Me.Controls.Add(Me.statusstripMain)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formAnioLectivoCuotas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cuotas de años lectivos"
        Me.statusstripMain.ResumeLayout(False)
        Me.statusstripMain.PerformLayout()
        Me.panelToolbars.ResumeLayout(False)
        Me.panelToolbars.PerformLayout()
        Me.toolstripButtons.ResumeLayout(False)
        Me.toolstripButtons.PerformLayout()
        Me.toolsptripAnioLectivo.ResumeLayout(False)
        Me.toolsptripAnioLectivo.PerformLayout()
        Me.ToolStripMesInicio.ResumeLayout(False)
        Me.ToolStripMesInicio.PerformLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents statuslabelMain As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents statusstripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents panelToolbars As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents toolstripButtons As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolsptripAnioLectivo As System.Windows.Forms.ToolStrip
    Friend WithEvents labelAnioLectivo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxAnioLectivo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents datagridviewMain As DataGridView
    Friend WithEvents ToolStripMesInicio As ToolStrip
    Friend WithEvents ToolStripLabelMesInicio As ToolStripLabel
    Friend WithEvents ToolStripComboBoxMesInicio As ToolStripComboBox
    Friend WithEvents columnMesInicio As DataGridViewTextBoxColumn
    Friend WithEvents columnCuotaTipo As DataGridViewTextBoxColumn
    Friend WithEvents columnImporteMatricula As DataGridViewTextBoxColumn
    Friend WithEvents columnImporteCuota As DataGridViewTextBoxColumn
End Class
