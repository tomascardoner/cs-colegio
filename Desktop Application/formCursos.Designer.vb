<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formCursos
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
        Me.statuslabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusstripMain = New System.Windows.Forms.StatusStrip()
        Me.datagridviewMain = New System.Windows.Forms.DataGridView()
        Me.panelToolbars = New System.Windows.Forms.FlowLayoutPanel()
        Me.toolstripButtons = New System.Windows.Forms.ToolStrip()
        Me.buttonAgregar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEliminar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripNivel = New System.Windows.Forms.ToolStrip()
        Me.labelNivel = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxNivel = New System.Windows.Forms.ToolStripComboBox()
        Me.labelAnio = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxAnio = New System.Windows.Forms.ToolStripComboBox()
        Me.toolstripTurno = New System.Windows.Forms.ToolStrip()
        Me.labelTurno = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxTurno = New System.Windows.Forms.ToolStripComboBox()
        Me.toolstripActivo = New System.Windows.Forms.ToolStrip()
        Me.labelActivo = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxActivo = New System.Windows.Forms.ToolStripComboBox()
        Me.columnNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnAnio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnTurno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnDivision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnCuotaTipo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnEsActivo = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.statusstripMain.SuspendLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelToolbars.SuspendLayout()
        Me.toolstripButtons.SuspendLayout()
        Me.toolstripNivel.SuspendLayout()
        Me.toolstripTurno.SuspendLayout()
        Me.toolstripActivo.SuspendLayout()
        Me.SuspendLayout()
        '
        'statuslabelMain
        '
        Me.statuslabelMain.Name = "statuslabelMain"
        Me.statuslabelMain.Size = New System.Drawing.Size(1017, 17)
        Me.statuslabelMain.Spring = True
        Me.statuslabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'statusstripMain
        '
        Me.statusstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statuslabelMain})
        Me.statusstripMain.Location = New System.Drawing.Point(0, 389)
        Me.statusstripMain.Name = "statusstripMain"
        Me.statusstripMain.Size = New System.Drawing.Size(1032, 22)
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
        Me.datagridviewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnNivel, Me.columnAnio, Me.columnTurno, Me.columnDivision, Me.columnCuotaTipo, Me.columnEsActivo})
        Me.datagridviewMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.datagridviewMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datagridviewMain.Location = New System.Drawing.Point(0, 64)
        Me.datagridviewMain.MultiSelect = False
        Me.datagridviewMain.Name = "datagridviewMain"
        Me.datagridviewMain.ReadOnly = True
        Me.datagridviewMain.RowHeadersVisible = False
        Me.datagridviewMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewMain.Size = New System.Drawing.Size(1032, 325)
        Me.datagridviewMain.TabIndex = 0
        '
        'panelToolbars
        '
        Me.panelToolbars.AutoSize = True
        Me.panelToolbars.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelToolbars.Controls.Add(Me.toolstripButtons)
        Me.panelToolbars.Controls.Add(Me.toolstripNivel)
        Me.panelToolbars.Controls.Add(Me.toolstripTurno)
        Me.panelToolbars.Controls.Add(Me.toolstripActivo)
        Me.panelToolbars.Dock = System.Windows.Forms.DockStyle.Top
        Me.panelToolbars.Location = New System.Drawing.Point(0, 0)
        Me.panelToolbars.Name = "panelToolbars"
        Me.panelToolbars.Size = New System.Drawing.Size(1032, 64)
        Me.panelToolbars.TabIndex = 0
        '
        'toolstripButtons
        '
        Me.toolstripButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonAgregar, Me.buttonEditar, Me.buttonEliminar})
        Me.toolstripButtons.Location = New System.Drawing.Point(0, 0)
        Me.toolstripButtons.Name = "toolstripButtons"
        Me.toolstripButtons.Size = New System.Drawing.Size(247, 39)
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
        'toolstripNivel
        '
        Me.toolstripNivel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripNivel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripNivel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelNivel, Me.comboboxNivel, Me.labelAnio, Me.comboboxAnio})
        Me.toolstripNivel.Location = New System.Drawing.Point(247, 0)
        Me.toolstripNivel.Name = "toolstripNivel"
        Me.toolstripNivel.Size = New System.Drawing.Size(476, 39)
        Me.toolstripNivel.TabIndex = 13
        '
        'labelNivel
        '
        Me.labelNivel.Name = "labelNivel"
        Me.labelNivel.Size = New System.Drawing.Size(37, 36)
        Me.labelNivel.Text = "Nivel:"
        '
        'comboboxNivel
        '
        Me.comboboxNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxNivel.Name = "comboboxNivel"
        Me.comboboxNivel.Size = New System.Drawing.Size(150, 39)
        '
        'labelAnio
        '
        Me.labelAnio.Name = "labelAnio"
        Me.labelAnio.Size = New System.Drawing.Size(32, 36)
        Me.labelAnio.Text = "Año:"
        '
        'comboboxAnio
        '
        Me.comboboxAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnio.Name = "comboboxAnio"
        Me.comboboxAnio.Size = New System.Drawing.Size(250, 39)
        '
        'toolstripTurno
        '
        Me.toolstripTurno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripTurno.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripTurno.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelTurno, Me.comboboxTurno})
        Me.toolstripTurno.Location = New System.Drawing.Point(723, 0)
        Me.toolstripTurno.Name = "toolstripTurno"
        Me.toolstripTurno.Size = New System.Drawing.Size(196, 39)
        Me.toolstripTurno.TabIndex = 11
        '
        'labelTurno
        '
        Me.labelTurno.Name = "labelTurno"
        Me.labelTurno.Size = New System.Drawing.Size(41, 36)
        Me.labelTurno.Text = "Turno:"
        '
        'comboboxTurno
        '
        Me.comboboxTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxTurno.Name = "comboboxTurno"
        Me.comboboxTurno.Size = New System.Drawing.Size(150, 39)
        '
        'toolstripActivo
        '
        Me.toolstripActivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripActivo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripActivo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelActivo, Me.comboboxActivo})
        Me.toolstripActivo.Location = New System.Drawing.Point(0, 39)
        Me.toolstripActivo.Name = "toolstripActivo"
        Me.toolstripActivo.Size = New System.Drawing.Size(124, 25)
        Me.toolstripActivo.TabIndex = 12
        '
        'labelActivo
        '
        Me.labelActivo.Name = "labelActivo"
        Me.labelActivo.Size = New System.Drawing.Size(44, 22)
        Me.labelActivo.Text = "Activo:"
        '
        'comboboxActivo
        '
        Me.comboboxActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxActivo.Name = "comboboxActivo"
        Me.comboboxActivo.Size = New System.Drawing.Size(75, 25)
        '
        'columnNivel
        '
        Me.columnNivel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNivel.DataPropertyName = "Nivel"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnNivel.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnNivel.HeaderText = "Nivel"
        Me.columnNivel.Name = "columnNivel"
        Me.columnNivel.ReadOnly = True
        Me.columnNivel.Width = 56
        '
        'columnAnio
        '
        Me.columnAnio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnAnio.DataPropertyName = "Anio"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnAnio.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnAnio.HeaderText = "Año"
        Me.columnAnio.Name = "columnAnio"
        Me.columnAnio.ReadOnly = True
        Me.columnAnio.Width = 51
        '
        'columnTurno
        '
        Me.columnTurno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTurno.DataPropertyName = "Turno"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnTurno.DefaultCellStyle = DataGridViewCellStyle4
        Me.columnTurno.HeaderText = "Turno"
        Me.columnTurno.Name = "columnTurno"
        Me.columnTurno.ReadOnly = True
        Me.columnTurno.Width = 60
        '
        'columnDivision
        '
        Me.columnDivision.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnDivision.DataPropertyName = "Division"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnDivision.DefaultCellStyle = DataGridViewCellStyle5
        Me.columnDivision.HeaderText = "División"
        Me.columnDivision.Name = "columnDivision"
        Me.columnDivision.ReadOnly = True
        Me.columnDivision.Width = 69
        '
        'columnCuotaTipo
        '
        Me.columnCuotaTipo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnCuotaTipo.DataPropertyName = "CuotaTipo"
        Me.columnCuotaTipo.HeaderText = "Tipo Cuota"
        Me.columnCuotaTipo.Name = "columnCuotaTipo"
        Me.columnCuotaTipo.ReadOnly = True
        Me.columnCuotaTipo.Width = 84
        '
        'columnEsActivo
        '
        Me.columnEsActivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnEsActivo.DataPropertyName = "EsActivo"
        Me.columnEsActivo.HeaderText = "Activo"
        Me.columnEsActivo.Name = "columnEsActivo"
        Me.columnEsActivo.ReadOnly = True
        Me.columnEsActivo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.columnEsActivo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.columnEsActivo.Width = 62
        '
        'formCursos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1032, 411)
        Me.Controls.Add(Me.datagridviewMain)
        Me.Controls.Add(Me.panelToolbars)
        Me.Controls.Add(Me.statusstripMain)
        Me.Name = "formCursos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cursos"
        Me.statusstripMain.ResumeLayout(False)
        Me.statusstripMain.PerformLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelToolbars.ResumeLayout(False)
        Me.panelToolbars.PerformLayout()
        Me.toolstripButtons.ResumeLayout(False)
        Me.toolstripButtons.PerformLayout()
        Me.toolstripNivel.ResumeLayout(False)
        Me.toolstripNivel.PerformLayout()
        Me.toolstripTurno.ResumeLayout(False)
        Me.toolstripTurno.PerformLayout()
        Me.toolstripActivo.ResumeLayout(False)
        Me.toolstripActivo.PerformLayout()
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
    Friend WithEvents toolstripActivo As System.Windows.Forms.ToolStrip
    Friend WithEvents labelActivo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxActivo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents toolstripNivel As System.Windows.Forms.ToolStrip
    Friend WithEvents labelNivel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxNivel As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents labelAnio As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxAnio As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents toolstripTurno As System.Windows.Forms.ToolStrip
    Friend WithEvents labelTurno As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxTurno As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents columnNivel As DataGridViewTextBoxColumn
    Friend WithEvents columnAnio As DataGridViewTextBoxColumn
    Friend WithEvents columnTurno As DataGridViewTextBoxColumn
    Friend WithEvents columnDivision As DataGridViewTextBoxColumn
    Friend WithEvents columnCuotaTipo As DataGridViewTextBoxColumn
    Friend WithEvents columnEsActivo As DataGridViewCheckBoxColumn
End Class
