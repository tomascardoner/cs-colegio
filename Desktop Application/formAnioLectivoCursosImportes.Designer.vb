<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAnioLectivoCursosImportes
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.labelMesInicio = New System.Windows.Forms.Label()
        Me.labelAnioLectivoOrigen = New System.Windows.Forms.Label()
        Me.datagridviewMain = New System.Windows.Forms.DataGridView()
        Me.comboboxMesInicio = New System.Windows.Forms.ComboBox()
        Me.comboboxAnioLectivo = New System.Windows.Forms.ComboBox()
        Me.columnNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnCurso = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteMatricula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain.SuspendLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(498, 39)
        Me.toolstripMain.TabIndex = 5
        '
        'labelMesInicio
        '
        Me.labelMesInicio.AutoSize = True
        Me.labelMesInicio.Location = New System.Drawing.Point(190, 52)
        Me.labelMesInicio.Name = "labelMesInicio"
        Me.labelMesInicio.Size = New System.Drawing.Size(73, 13)
        Me.labelMesInicio.TabIndex = 2
        Me.labelMesInicio.Text = "Mes de Inicio:"
        '
        'labelAnioLectivoOrigen
        '
        Me.labelAnioLectivoOrigen.AutoSize = True
        Me.labelAnioLectivoOrigen.Location = New System.Drawing.Point(10, 52)
        Me.labelAnioLectivoOrigen.Name = "labelAnioLectivoOrigen"
        Me.labelAnioLectivoOrigen.Size = New System.Drawing.Size(67, 13)
        Me.labelAnioLectivoOrigen.TabIndex = 0
        Me.labelAnioLectivoOrigen.Text = "Año Lectivo:"
        '
        'datagridviewMain
        '
        Me.datagridviewMain.AllowUserToAddRows = False
        Me.datagridviewMain.AllowUserToDeleteRows = False
        Me.datagridviewMain.AllowUserToResizeRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.datagridviewMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datagridviewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnNivel, Me.columnCurso, Me.columnImporteMatricula, Me.columnImporteCuota})
        Me.datagridviewMain.Location = New System.Drawing.Point(12, 76)
        Me.datagridviewMain.MultiSelect = False
        Me.datagridviewMain.Name = "datagridviewMain"
        Me.datagridviewMain.RowHeadersVisible = False
        Me.datagridviewMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.datagridviewMain.Size = New System.Drawing.Size(476, 244)
        Me.datagridviewMain.TabIndex = 4
        '
        'comboboxMesInicio
        '
        Me.comboboxMesInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxMesInicio.FormattingEnabled = True
        Me.comboboxMesInicio.Location = New System.Drawing.Point(269, 49)
        Me.comboboxMesInicio.Name = "comboboxMesInicio"
        Me.comboboxMesInicio.Size = New System.Drawing.Size(118, 21)
        Me.comboboxMesInicio.TabIndex = 3
        '
        'comboboxAnioLectivo
        '
        Me.comboboxAnioLectivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnioLectivo.FormattingEnabled = True
        Me.comboboxAnioLectivo.Location = New System.Drawing.Point(83, 49)
        Me.comboboxAnioLectivo.Name = "comboboxAnioLectivo"
        Me.comboboxAnioLectivo.Size = New System.Drawing.Size(59, 21)
        Me.comboboxAnioLectivo.TabIndex = 6
        '
        'columnNivel
        '
        Me.columnNivel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNivel.DataPropertyName = "NivelNombre"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnNivel.DefaultCellStyle = DataGridViewCellStyle12
        Me.columnNivel.HeaderText = "Nivel"
        Me.columnNivel.Name = "columnNivel"
        Me.columnNivel.ReadOnly = True
        Me.columnNivel.Width = 56
        '
        'columnCurso
        '
        Me.columnCurso.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnCurso.DataPropertyName = "CursoNombre"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnCurso.DefaultCellStyle = DataGridViewCellStyle13
        Me.columnCurso.HeaderText = "Curso"
        Me.columnCurso.Name = "columnCurso"
        Me.columnCurso.ReadOnly = True
        Me.columnCurso.Width = 59
        '
        'columnImporteMatricula
        '
        Me.columnImporteMatricula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteMatricula.DataPropertyName = "ImporteMatricula"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "C2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.columnImporteMatricula.DefaultCellStyle = DataGridViewCellStyle14
        Me.columnImporteMatricula.HeaderText = "Importe Matrícula"
        Me.columnImporteMatricula.Name = "columnImporteMatricula"
        Me.columnImporteMatricula.Width = 105
        '
        'columnImporteCuota
        '
        Me.columnImporteCuota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteCuota.DataPropertyName = "ImporteCuota"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "C2"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.columnImporteCuota.DefaultCellStyle = DataGridViewCellStyle15
        Me.columnImporteCuota.HeaderText = "Importe Cuota"
        Me.columnImporteCuota.Name = "columnImporteCuota"
        Me.columnImporteCuota.Width = 90
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
        'formAnioLectivoCursosImportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 330)
        Me.Controls.Add(Me.comboboxAnioLectivo)
        Me.Controls.Add(Me.comboboxMesInicio)
        Me.Controls.Add(Me.datagridviewMain)
        Me.Controls.Add(Me.labelMesInicio)
        Me.Controls.Add(Me.labelAnioLectivoOrigen)
        Me.Controls.Add(Me.toolstripMain)
        Me.KeyPreview = True
        Me.Name = "formAnioLectivoCursosImportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Año Lectivo - Cursos - Editar Importes"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents labelMesInicio As System.Windows.Forms.Label
    Friend WithEvents labelAnioLectivoOrigen As System.Windows.Forms.Label
    Friend WithEvents datagridviewMain As System.Windows.Forms.DataGridView
    Friend WithEvents comboboxMesInicio As System.Windows.Forms.ComboBox
    Friend WithEvents comboboxAnioLectivo As System.Windows.Forms.ComboBox
    Friend WithEvents columnNivel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnCurso As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteMatricula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteCuota As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
End Class
