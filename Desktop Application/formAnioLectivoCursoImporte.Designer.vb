<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAnioLectivoCursoImporte
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formAnioLectivoCursoImporte))
        Me.labelAnioLectivo = New System.Windows.Forms.Label()
        Me.labelCurso = New System.Windows.Forms.Label()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.labelMesInicio = New System.Windows.Forms.Label()
        Me.labelImporteMatricula = New System.Windows.Forms.Label()
        Me.labelImporteCuota = New System.Windows.Forms.Label()
        Me.textboxAnioLectivo = New System.Windows.Forms.TextBox()
        Me.textboxCurso = New System.Windows.Forms.TextBox()
        Me.comboboxMesInicio = New System.Windows.Forms.ComboBox()
        Me.currencytextboxImporteMatricula = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.currencytextboxImporteCuota = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.toolstripMain.SuspendLayout()
        CType(Me.currencytextboxImporteMatricula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.currencytextboxImporteCuota, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelAnioLectivo
        '
        Me.labelAnioLectivo.AutoSize = True
        Me.labelAnioLectivo.Location = New System.Drawing.Point(12, 61)
        Me.labelAnioLectivo.Name = "labelAnioLectivo"
        Me.labelAnioLectivo.Size = New System.Drawing.Size(67, 13)
        Me.labelAnioLectivo.TabIndex = 7
        Me.labelAnioLectivo.Text = "Año Lectivo:"
        '
        'labelCurso
        '
        Me.labelCurso.AutoSize = True
        Me.labelCurso.Location = New System.Drawing.Point(12, 88)
        Me.labelCurso.Name = "labelCurso"
        Me.labelCurso.Size = New System.Drawing.Size(37, 13)
        Me.labelCurso.TabIndex = 9
        Me.labelCurso.Text = "Curso:"
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
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(429, 39)
        Me.toolstripMain.TabIndex = 6
        '
        'labelMesInicio
        '
        Me.labelMesInicio.AutoSize = True
        Me.labelMesInicio.Location = New System.Drawing.Point(12, 115)
        Me.labelMesInicio.Name = "labelMesInicio"
        Me.labelMesInicio.Size = New System.Drawing.Size(73, 13)
        Me.labelMesInicio.TabIndex = 0
        Me.labelMesInicio.Text = "Mes de Inicio:"
        '
        'labelImporteMatricula
        '
        Me.labelImporteMatricula.AutoSize = True
        Me.labelImporteMatricula.Location = New System.Drawing.Point(12, 142)
        Me.labelImporteMatricula.Name = "labelImporteMatricula"
        Me.labelImporteMatricula.Size = New System.Drawing.Size(93, 13)
        Me.labelImporteMatricula.TabIndex = 2
        Me.labelImporteMatricula.Text = "Importe Matrícula:"
        '
        'labelImporteCuota
        '
        Me.labelImporteCuota.AutoSize = True
        Me.labelImporteCuota.Location = New System.Drawing.Point(12, 168)
        Me.labelImporteCuota.Name = "labelImporteCuota"
        Me.labelImporteCuota.Size = New System.Drawing.Size(76, 13)
        Me.labelImporteCuota.TabIndex = 4
        Me.labelImporteCuota.Text = "Importe Cuota:"
        '
        'textboxAnioLectivo
        '
        Me.textboxAnioLectivo.Location = New System.Drawing.Point(111, 58)
        Me.textboxAnioLectivo.MaxLength = 10
        Me.textboxAnioLectivo.Name = "textboxAnioLectivo"
        Me.textboxAnioLectivo.ReadOnly = True
        Me.textboxAnioLectivo.Size = New System.Drawing.Size(50, 20)
        Me.textboxAnioLectivo.TabIndex = 8
        Me.textboxAnioLectivo.TabStop = False
        Me.textboxAnioLectivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'textboxCurso
        '
        Me.textboxCurso.Location = New System.Drawing.Point(111, 85)
        Me.textboxCurso.MaxLength = 10
        Me.textboxCurso.Name = "textboxCurso"
        Me.textboxCurso.ReadOnly = True
        Me.textboxCurso.Size = New System.Drawing.Size(306, 20)
        Me.textboxCurso.TabIndex = 10
        Me.textboxCurso.TabStop = False
        '
        'comboboxMesInicio
        '
        Me.comboboxMesInicio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxMesInicio.FormattingEnabled = True
        Me.comboboxMesInicio.Location = New System.Drawing.Point(111, 112)
        Me.comboboxMesInicio.Name = "comboboxMesInicio"
        Me.comboboxMesInicio.Size = New System.Drawing.Size(118, 21)
        Me.comboboxMesInicio.TabIndex = 1
        '
        'currencytextboxImporteMatricula
        '
        Me.currencytextboxImporteMatricula.BeforeTouchSize = New System.Drawing.Size(69, 20)
        Me.currencytextboxImporteMatricula.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxImporteMatricula.Location = New System.Drawing.Point(111, 139)
        Me.currencytextboxImporteMatricula.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 131072})
        Me.currencytextboxImporteMatricula.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.currencytextboxImporteMatricula.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxImporteMatricula.Name = "currencytextboxImporteMatricula"
        Me.currencytextboxImporteMatricula.NullString = ""
        Me.currencytextboxImporteMatricula.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.currencytextboxImporteMatricula.Size = New System.Drawing.Size(100, 20)
        Me.currencytextboxImporteMatricula.TabIndex = 3
        Me.currencytextboxImporteMatricula.Text = "$ 0,00"
        Me.currencytextboxImporteMatricula.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'currencytextboxImporteCuota
        '
        Me.currencytextboxImporteCuota.BeforeTouchSize = New System.Drawing.Size(69, 20)
        Me.currencytextboxImporteCuota.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxImporteCuota.Location = New System.Drawing.Point(111, 165)
        Me.currencytextboxImporteCuota.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 131072})
        Me.currencytextboxImporteCuota.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.currencytextboxImporteCuota.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxImporteCuota.Name = "currencytextboxImporteCuota"
        Me.currencytextboxImporteCuota.NullString = ""
        Me.currencytextboxImporteCuota.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.currencytextboxImporteCuota.Size = New System.Drawing.Size(100, 20)
        Me.currencytextboxImporteCuota.TabIndex = 5
        Me.currencytextboxImporteCuota.Text = "$ 0,00"
        Me.currencytextboxImporteCuota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'formAnioLectivoCursoImporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(429, 201)
        Me.Controls.Add(Me.currencytextboxImporteCuota)
        Me.Controls.Add(Me.currencytextboxImporteMatricula)
        Me.Controls.Add(Me.comboboxMesInicio)
        Me.Controls.Add(Me.textboxCurso)
        Me.Controls.Add(Me.textboxAnioLectivo)
        Me.Controls.Add(Me.labelImporteCuota)
        Me.Controls.Add(Me.labelImporteMatricula)
        Me.Controls.Add(Me.labelMesInicio)
        Me.Controls.Add(Me.labelAnioLectivo)
        Me.Controls.Add(Me.labelCurso)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formAnioLectivoCursoImporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Curso de Año Lectivo"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        CType(Me.currencytextboxImporteMatricula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.currencytextboxImporteCuota, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelAnioLectivo As System.Windows.Forms.Label
    Friend WithEvents labelCurso As System.Windows.Forms.Label
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents labelMesInicio As System.Windows.Forms.Label
    Friend WithEvents labelImporteMatricula As System.Windows.Forms.Label
    Friend WithEvents labelImporteCuota As System.Windows.Forms.Label
    Friend WithEvents textboxAnioLectivo As System.Windows.Forms.TextBox
    Friend WithEvents textboxCurso As System.Windows.Forms.TextBox
    Friend WithEvents comboboxMesInicio As System.Windows.Forms.ComboBox
    Friend WithEvents currencytextboxImporteMatricula As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents currencytextboxImporteCuota As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
End Class
