<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAnioLectivoCursoImporteGenerar
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
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.comboboxAnioLectivo = New System.Windows.Forms.ComboBox()
        Me.labelAnioLectivoOrigen = New System.Windows.Forms.Label()
        Me.labelLeyenda = New System.Windows.Forms.Label()
        Me.listviewAnioLectivoCurso = New System.Windows.Forms.ListView()
        Me.labelImporteCuota = New System.Windows.Forms.Label()
        Me.textboxImporteCuota = New CSColegio.DesktopApplication.CS_Control_TextBox_Currency()
        Me.textboxImporteMatricula = New CSColegio.DesktopApplication.CS_Control_TextBox_Currency()
        Me.labelImporteMatricula = New System.Windows.Forms.Label()
        Me.labelMesInicio = New System.Windows.Forms.Label()
        Me.comboboxMesInicio = New System.Windows.Forms.ComboBox()
        Me.columnNivel = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnCurso = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.toolstripMain.SuspendLayout()
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
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(371, 39)
        Me.toolstripMain.TabIndex = 10
        '
        'comboboxAnioLectivo
        '
        Me.comboboxAnioLectivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnioLectivo.FormattingEnabled = True
        Me.comboboxAnioLectivo.Location = New System.Drawing.Point(111, 197)
        Me.comboboxAnioLectivo.Name = "comboboxAnioLectivo"
        Me.comboboxAnioLectivo.Size = New System.Drawing.Size(59, 21)
        Me.comboboxAnioLectivo.TabIndex = 12
        '
        'labelAnioLectivoOrigen
        '
        Me.labelAnioLectivoOrigen.AutoSize = True
        Me.labelAnioLectivoOrigen.Location = New System.Drawing.Point(12, 200)
        Me.labelAnioLectivoOrigen.Name = "labelAnioLectivoOrigen"
        Me.labelAnioLectivoOrigen.Size = New System.Drawing.Size(67, 13)
        Me.labelAnioLectivoOrigen.TabIndex = 11
        Me.labelAnioLectivoOrigen.Text = "Año Lectivo:"
        '
        'labelLeyenda
        '
        Me.labelLeyenda.Location = New System.Drawing.Point(12, 49)
        Me.labelLeyenda.Name = "labelLeyenda"
        Me.labelLeyenda.Size = New System.Drawing.Size(347, 35)
        Me.labelLeyenda.TabIndex = 15
        Me.labelLeyenda.Text = "Se generarán los Importes de los Cursos del Año Lectivo seleccionados en la lista" & _
    "."
        '
        'listviewAnioLectivoCurso
        '
        Me.listviewAnioLectivoCurso.CheckBoxes = True
        Me.listviewAnioLectivoCurso.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnNivel, Me.columnCurso})
        Me.listviewAnioLectivoCurso.FullRowSelect = True
        Me.listviewAnioLectivoCurso.GridLines = True
        Me.listviewAnioLectivoCurso.Location = New System.Drawing.Point(15, 224)
        Me.listviewAnioLectivoCurso.Name = "listviewAnioLectivoCurso"
        Me.listviewAnioLectivoCurso.Size = New System.Drawing.Size(344, 223)
        Me.listviewAnioLectivoCurso.TabIndex = 16
        Me.listviewAnioLectivoCurso.UseCompatibleStateImageBehavior = False
        Me.listviewAnioLectivoCurso.View = System.Windows.Forms.View.Details
        '
        'labelImporteCuota
        '
        Me.labelImporteCuota.AutoSize = True
        Me.labelImporteCuota.Location = New System.Drawing.Point(12, 148)
        Me.labelImporteCuota.Name = "labelImporteCuota"
        Me.labelImporteCuota.Size = New System.Drawing.Size(76, 13)
        Me.labelImporteCuota.TabIndex = 21
        Me.labelImporteCuota.Text = "Importe Cuota:"
        '
        'textboxImporteCuota
        '
        Me.textboxImporteCuota.Location = New System.Drawing.Point(111, 145)
        Me.textboxImporteCuota.MaxLength = 15
        Me.textboxImporteCuota.Name = "textboxImporteCuota"
        Me.textboxImporteCuota.Size = New System.Drawing.Size(100, 20)
        Me.textboxImporteCuota.TabIndex = 22
        Me.textboxImporteCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'textboxImporteMatricula
        '
        Me.textboxImporteMatricula.Location = New System.Drawing.Point(111, 119)
        Me.textboxImporteMatricula.MaxLength = 15
        Me.textboxImporteMatricula.Name = "textboxImporteMatricula"
        Me.textboxImporteMatricula.Size = New System.Drawing.Size(100, 20)
        Me.textboxImporteMatricula.TabIndex = 20
        Me.textboxImporteMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'labelImporteMatricula
        '
        Me.labelImporteMatricula.AutoSize = True
        Me.labelImporteMatricula.Location = New System.Drawing.Point(12, 122)
        Me.labelImporteMatricula.Name = "labelImporteMatricula"
        Me.labelImporteMatricula.Size = New System.Drawing.Size(93, 13)
        Me.labelImporteMatricula.TabIndex = 19
        Me.labelImporteMatricula.Text = "Importe Matrícula:"
        '
        'labelMesInicio
        '
        Me.labelMesInicio.AutoSize = True
        Me.labelMesInicio.Location = New System.Drawing.Point(12, 95)
        Me.labelMesInicio.Name = "labelMesInicio"
        Me.labelMesInicio.Size = New System.Drawing.Size(73, 13)
        Me.labelMesInicio.TabIndex = 17
        Me.labelMesInicio.Text = "Mes de Inicio:"
        '
        'comboboxMesInicio
        '
        Me.comboboxMesInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxMesInicio.FormattingEnabled = True
        Me.comboboxMesInicio.Location = New System.Drawing.Point(111, 92)
        Me.comboboxMesInicio.Name = "comboboxMesInicio"
        Me.comboboxMesInicio.Size = New System.Drawing.Size(120, 21)
        Me.comboboxMesInicio.TabIndex = 18
        '
        'columnNivel
        '
        Me.columnNivel.Text = "Nivel"
        Me.columnNivel.Width = 130
        '
        'columnCurso
        '
        Me.columnCurso.Text = "Curso"
        Me.columnCurso.Width = 190
        '
        'formAnioLectivoCursoImporteGenerar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 464)
        Me.Controls.Add(Me.labelImporteCuota)
        Me.Controls.Add(Me.textboxImporteCuota)
        Me.Controls.Add(Me.textboxImporteMatricula)
        Me.Controls.Add(Me.labelImporteMatricula)
        Me.Controls.Add(Me.labelMesInicio)
        Me.Controls.Add(Me.comboboxMesInicio)
        Me.Controls.Add(Me.listviewAnioLectivoCurso)
        Me.Controls.Add(Me.labelLeyenda)
        Me.Controls.Add(Me.comboboxAnioLectivo)
        Me.Controls.Add(Me.labelAnioLectivoOrigen)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formAnioLectivoCursoImporteGenerar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Copiar Cursos de Año Lectivo"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents comboboxAnioLectivo As System.Windows.Forms.ComboBox
    Friend WithEvents labelAnioLectivoOrigen As System.Windows.Forms.Label
    Friend WithEvents labelLeyenda As System.Windows.Forms.Label
    Friend WithEvents listviewAnioLectivoCurso As System.Windows.Forms.ListView
    Friend WithEvents labelImporteCuota As System.Windows.Forms.Label
    Friend WithEvents textboxImporteCuota As CSColegio.DesktopApplication.CS_Control_TextBox_Currency
    Friend WithEvents textboxImporteMatricula As CSColegio.DesktopApplication.CS_Control_TextBox_Currency
    Friend WithEvents labelImporteMatricula As System.Windows.Forms.Label
    Friend WithEvents labelMesInicio As System.Windows.Forms.Label
    Friend WithEvents comboboxMesInicio As System.Windows.Forms.ComboBox
    Friend WithEvents columnNivel As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnCurso As System.Windows.Forms.ColumnHeader
End Class
