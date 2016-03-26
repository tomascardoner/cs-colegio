<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAniosLectivosCursos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formAniosLectivosCursos))
        Me.statuslabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.statusstripMain = New System.Windows.Forms.StatusStrip()
        Me.datagridviewMain = New System.Windows.Forms.DataGridView()
        Me.columnAnioLectivo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnCurso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelToolbars = New System.Windows.Forms.FlowLayoutPanel()
        Me.toolstripButtons = New System.Windows.Forms.ToolStrip()
        Me.buttonAgregar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEliminar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCopiarAnioLectivo = New System.Windows.Forms.ToolStripButton()
        Me.toolsptripAnioLectivo = New System.Windows.Forms.ToolStrip()
        Me.labelAnioLectivo = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxAnioLectivo = New System.Windows.Forms.ToolStripComboBox()
        Me.toolstripNivel = New System.Windows.Forms.ToolStrip()
        Me.labelNivel = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxNivel = New System.Windows.Forms.ToolStripComboBox()
        Me.toolstripCurso = New System.Windows.Forms.ToolStrip()
        Me.labelCurso = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxCurso = New System.Windows.Forms.ToolStripComboBox()
        Me.buttonImportes = New System.Windows.Forms.ToolStripButton()
        Me.statusstripMain.SuspendLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.panelToolbars.SuspendLayout()
        Me.toolstripButtons.SuspendLayout()
        Me.toolsptripAnioLectivo.SuspendLayout()
        Me.toolstripNivel.SuspendLayout()
        Me.toolstripCurso.SuspendLayout()
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
        Me.datagridviewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnAnioLectivo, Me.columnNivel, Me.columnCurso})
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
        'columnAnioLectivo
        '
        Me.columnAnioLectivo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnAnioLectivo.DataPropertyName = "AnioLectivo"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnAnioLectivo.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnAnioLectivo.HeaderText = "Año Lectivo"
        Me.columnAnioLectivo.Name = "columnAnioLectivo"
        Me.columnAnioLectivo.ReadOnly = True
        Me.columnAnioLectivo.Width = 89
        '
        'columnNivel
        '
        Me.columnNivel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNivel.DataPropertyName = "Nivel"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnNivel.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnNivel.HeaderText = "Nivel"
        Me.columnNivel.Name = "columnNivel"
        Me.columnNivel.ReadOnly = True
        Me.columnNivel.Width = 56
        '
        'columnCurso
        '
        Me.columnCurso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnCurso.DataPropertyName = "Curso"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnCurso.DefaultCellStyle = DataGridViewCellStyle4
        Me.columnCurso.HeaderText = "Curso"
        Me.columnCurso.Name = "columnCurso"
        Me.columnCurso.ReadOnly = True
        Me.columnCurso.Width = 59
        '
        'panelToolbars
        '
        Me.panelToolbars.AutoSize = True
        Me.panelToolbars.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelToolbars.Controls.Add(Me.toolstripButtons)
        Me.panelToolbars.Controls.Add(Me.toolsptripAnioLectivo)
        Me.panelToolbars.Controls.Add(Me.toolstripNivel)
        Me.panelToolbars.Controls.Add(Me.toolstripCurso)
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
        Me.toolstripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonAgregar, Me.buttonEditar, Me.buttonEliminar, Me.buttonImportes, Me.buttonCopiarAnioLectivo})
        Me.toolstripButtons.Location = New System.Drawing.Point(0, 0)
        Me.toolstripButtons.Name = "toolstripButtons"
        Me.toolstripButtons.Size = New System.Drawing.Size(438, 39)
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
        'buttonCopiarAnioLectivo
        '
        Me.buttonCopiarAnioLectivo.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_COPY_32
        Me.buttonCopiarAnioLectivo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCopiarAnioLectivo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCopiarAnioLectivo.Name = "buttonCopiarAnioLectivo"
        Me.buttonCopiarAnioLectivo.Size = New System.Drawing.Size(117, 36)
        Me.buttonCopiarAnioLectivo.Text = "Copiar Cursos"
        '
        'toolsptripAnioLectivo
        '
        Me.toolsptripAnioLectivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolsptripAnioLectivo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolsptripAnioLectivo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelAnioLectivo, Me.comboboxAnioLectivo})
        Me.toolsptripAnioLectivo.Location = New System.Drawing.Point(438, 0)
        Me.toolsptripAnioLectivo.Name = "toolsptripAnioLectivo"
        Me.toolsptripAnioLectivo.Size = New System.Drawing.Size(153, 39)
        Me.toolsptripAnioLectivo.TabIndex = 14
        '
        'labelAnioLectivo
        '
        Me.labelAnioLectivo.Name = "labelAnioLectivo"
        Me.labelAnioLectivo.Size = New System.Drawing.Size(73, 36)
        Me.labelAnioLectivo.Text = "Año Lectivo:"
        '
        'comboboxAnioLectivo
        '
        Me.comboboxAnioLectivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnioLectivo.Name = "comboboxAnioLectivo"
        Me.comboboxAnioLectivo.Size = New System.Drawing.Size(75, 39)
        '
        'toolstripNivel
        '
        Me.toolstripNivel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripNivel.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripNivel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelNivel, Me.comboboxNivel})
        Me.toolstripNivel.Location = New System.Drawing.Point(591, 0)
        Me.toolstripNivel.Name = "toolstripNivel"
        Me.toolstripNivel.Size = New System.Drawing.Size(192, 39)
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
        'toolstripCurso
        '
        Me.toolstripCurso.Dock = System.Windows.Forms.DockStyle.Fill
        Me.toolstripCurso.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripCurso.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelCurso, Me.comboboxCurso})
        Me.toolstripCurso.Location = New System.Drawing.Point(0, 39)
        Me.toolstripCurso.Name = "toolstripCurso"
        Me.toolstripCurso.Size = New System.Drawing.Size(346, 25)
        Me.toolstripCurso.TabIndex = 11
        '
        'labelCurso
        '
        Me.labelCurso.Name = "labelCurso"
        Me.labelCurso.Size = New System.Drawing.Size(41, 22)
        Me.labelCurso.Text = "Curso:"
        '
        'comboboxCurso
        '
        Me.comboboxCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCurso.Name = "comboboxCurso"
        Me.comboboxCurso.Size = New System.Drawing.Size(300, 25)
        '
        'buttonImportes
        '
        Me.buttonImportes.Image = CType(resources.GetObject("buttonImportes.Image"), System.Drawing.Image)
        Me.buttonImportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonImportes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonImportes.Name = "buttonImportes"
        Me.buttonImportes.Size = New System.Drawing.Size(74, 36)
        Me.buttonImportes.Text = "Importes"
        '
        'formAniosLectivosCursos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1032, 411)
        Me.Controls.Add(Me.datagridviewMain)
        Me.Controls.Add(Me.panelToolbars)
        Me.Controls.Add(Me.statusstripMain)
        Me.Name = "formAniosLectivosCursos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cursos de Años Lectivos"
        Me.statusstripMain.ResumeLayout(False)
        Me.statusstripMain.PerformLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.panelToolbars.ResumeLayout(False)
        Me.panelToolbars.PerformLayout()
        Me.toolstripButtons.ResumeLayout(False)
        Me.toolstripButtons.PerformLayout()
        Me.toolsptripAnioLectivo.ResumeLayout(False)
        Me.toolsptripAnioLectivo.PerformLayout()
        Me.toolstripNivel.ResumeLayout(False)
        Me.toolstripNivel.PerformLayout()
        Me.toolstripCurso.ResumeLayout(False)
        Me.toolstripCurso.PerformLayout()
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
    Friend WithEvents toolstripNivel As System.Windows.Forms.ToolStrip
    Friend WithEvents labelNivel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxNivel As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents toolstripCurso As System.Windows.Forms.ToolStrip
    Friend WithEvents labelCurso As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxCurso As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents toolsptripAnioLectivo As System.Windows.Forms.ToolStrip
    Friend WithEvents labelAnioLectivo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxAnioLectivo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents columnAnioLectivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNivel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnCurso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents buttonCopiarAnioLectivo As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonImportes As System.Windows.Forms.ToolStripButton
End Class
