<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAnioLectivoCursosImportesAgregar
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
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.labelMesInicio = New System.Windows.Forms.Label()
        Me.comboboxMesInicio = New System.Windows.Forms.ComboBox()
        Me.labelAnioLectivoOrigen = New System.Windows.Forms.Label()
        Me.datagridviewNivelesTurnos = New System.Windows.Forms.DataGridView()
        Me.textboxAnioLectivo = New System.Windows.Forms.TextBox()
        Me.columnNivel = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnTurno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteMatricula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toolstripMain.SuspendLayout()
        CType(Me.datagridviewNivelesTurnos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'buttonGuardar
        '
        Me.buttonGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonGuardar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_OK_32
        Me.buttonGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonGuardar.Name = "buttonGuardar"
        Me.buttonGuardar.Size = New System.Drawing.Size(98, 36)
        Me.buttonGuardar.Text = "Guardar"
        '
        'buttonCancelar
        '
        Me.buttonCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonCancelar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CANCEL_32
        Me.buttonCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCancelar.Name = "buttonCancelar"
        Me.buttonCancelar.Size = New System.Drawing.Size(102, 36)
        Me.buttonCancelar.Text = "Cancelar"
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(664, 39)
        Me.toolstripMain.TabIndex = 5
        '
        'labelMesInicio
        '
        Me.labelMesInicio.AutoSize = True
        Me.labelMesInicio.Location = New System.Drawing.Point(13, 96)
        Me.labelMesInicio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelMesInicio.Name = "labelMesInicio"
        Me.labelMesInicio.Size = New System.Drawing.Size(94, 17)
        Me.labelMesInicio.TabIndex = 2
        Me.labelMesInicio.Text = "Mes de Inicio:"
        '
        'comboboxMesInicio
        '
        Me.comboboxMesInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxMesInicio.FormattingEnabled = True
        Me.comboboxMesInicio.Location = New System.Drawing.Point(115, 93)
        Me.comboboxMesInicio.Margin = New System.Windows.Forms.Padding(4)
        Me.comboboxMesInicio.Name = "comboboxMesInicio"
        Me.comboboxMesInicio.Size = New System.Drawing.Size(133, 24)
        Me.comboboxMesInicio.TabIndex = 3
        '
        'labelAnioLectivoOrigen
        '
        Me.labelAnioLectivoOrigen.AutoSize = True
        Me.labelAnioLectivoOrigen.Location = New System.Drawing.Point(13, 64)
        Me.labelAnioLectivoOrigen.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelAnioLectivoOrigen.Name = "labelAnioLectivoOrigen"
        Me.labelAnioLectivoOrigen.Size = New System.Drawing.Size(86, 17)
        Me.labelAnioLectivoOrigen.TabIndex = 0
        Me.labelAnioLectivoOrigen.Text = "Año Lectivo:"
        '
        'datagridviewNivelesTurnos
        '
        Me.datagridviewNivelesTurnos.AllowUserToAddRows = False
        Me.datagridviewNivelesTurnos.AllowUserToDeleteRows = False
        Me.datagridviewNivelesTurnos.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewNivelesTurnos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewNivelesTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewNivelesTurnos.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnNivel, Me.columnTurno, Me.columnImporteMatricula, Me.columnImporteCuota})
        Me.datagridviewNivelesTurnos.Location = New System.Drawing.Point(16, 125)
        Me.datagridviewNivelesTurnos.Margin = New System.Windows.Forms.Padding(4)
        Me.datagridviewNivelesTurnos.MultiSelect = False
        Me.datagridviewNivelesTurnos.Name = "datagridviewNivelesTurnos"
        Me.datagridviewNivelesTurnos.RowHeadersVisible = False
        Me.datagridviewNivelesTurnos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewNivelesTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewNivelesTurnos.Size = New System.Drawing.Size(635, 268)
        Me.datagridviewNivelesTurnos.TabIndex = 4
        '
        'textboxAnioLectivo
        '
        Me.textboxAnioLectivo.Location = New System.Drawing.Point(115, 61)
        Me.textboxAnioLectivo.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxAnioLectivo.MaxLength = 10
        Me.textboxAnioLectivo.Name = "textboxAnioLectivo"
        Me.textboxAnioLectivo.ReadOnly = True
        Me.textboxAnioLectivo.Size = New System.Drawing.Size(65, 22)
        Me.textboxAnioLectivo.TabIndex = 6
        Me.textboxAnioLectivo.TabStop = False
        Me.textboxAnioLectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'columnNivel
        '
        Me.columnNivel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNivel.DataPropertyName = "NivelNombre"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnNivel.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnNivel.HeaderText = "Nivel"
        Me.columnNivel.Name = "columnNivel"
        Me.columnNivel.ReadOnly = True
        Me.columnNivel.Width = 68
        '
        'columnTurno
        '
        Me.columnTurno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTurno.DataPropertyName = "TurnoNombre"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnTurno.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnTurno.HeaderText = "Turno"
        Me.columnTurno.Name = "columnTurno"
        Me.columnTurno.ReadOnly = True
        Me.columnTurno.Width = 75
        '
        'columnImporteMatricula
        '
        Me.columnImporteMatricula.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteMatricula.DataPropertyName = "ImporteMatricula"
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.columnImporteMatricula.DefaultCellStyle = DataGridViewCellStyle4
        Me.columnImporteMatricula.HeaderText = "Importe Matrícula"
        Me.columnImporteMatricula.Name = "columnImporteMatricula"
        Me.columnImporteMatricula.Width = 133
        '
        'columnImporteCuota
        '
        Me.columnImporteCuota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteCuota.DataPropertyName = "ImporteCuota"
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.columnImporteCuota.DefaultCellStyle = DataGridViewCellStyle5
        Me.columnImporteCuota.HeaderText = "Importe Cuota"
        Me.columnImporteCuota.Name = "columnImporteCuota"
        Me.columnImporteCuota.Width = 115
        '
        'formAnioLectivoCursosImportesAgregar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8!, 16!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 406)
        Me.Controls.Add(Me.textboxAnioLectivo)
        Me.Controls.Add(Me.datagridviewNivelesTurnos)
        Me.Controls.Add(Me.labelMesInicio)
        Me.Controls.Add(Me.comboboxMesInicio)
        Me.Controls.Add(Me.labelAnioLectivoOrigen)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "formAnioLectivoCursosImportesAgregar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Año Lectivo - Curso - Agregar Importes"
        Me.toolstripMain.ResumeLayout(false)
        Me.toolstripMain.PerformLayout
        CType(Me.datagridviewNivelesTurnos,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents labelMesInicio As System.Windows.Forms.Label
    Friend WithEvents comboboxMesInicio As System.Windows.Forms.ComboBox
    Friend WithEvents labelAnioLectivoOrigen As System.Windows.Forms.Label
    Friend WithEvents datagridviewNivelesTurnos As System.Windows.Forms.DataGridView
    Friend WithEvents textboxAnioLectivo As System.Windows.Forms.TextBox
    Friend WithEvents columnNivel As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnTurno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteMatricula As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteCuota As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
