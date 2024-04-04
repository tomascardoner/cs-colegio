<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formComprobanteDetalleAgregarMultiple
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
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.labelArticulo = New System.Windows.Forms.Label()
        Me.buttonAlumno = New System.Windows.Forms.Button()
        Me.labelAlumno = New System.Windows.Forms.Label()
        Me.comboboxAnioLectivoCurso = New System.Windows.Forms.ComboBox()
        Me.labelAnioLectivoCurso = New System.Windows.Forms.Label()
        Me.comboboxCuotaMesDesde = New System.Windows.Forms.ComboBox()
        Me.labelCuotaMesDesde = New System.Windows.Forms.Label()
        Me.labelPrecioUnitario = New System.Windows.Forms.Label()
        Me.labelPrecioUnitarioDescuentoPorcentaje = New System.Windows.Forms.Label()
        Me.labelPrecioUnitarioDescuentoImporte = New System.Windows.Forms.Label()
        Me.labelPrecioUnitarioFinal = New System.Windows.Forms.Label()
        Me.labelPrecioTotal = New System.Windows.Forms.Label()
        Me.comboboxAlumno = New System.Windows.Forms.ComboBox()
        Me.textboxArticulo = New System.Windows.Forms.TextBox()
        Me.comboboxCuotaMesHasta = New System.Windows.Forms.ComboBox()
        Me.labelCuotaMesHasta = New System.Windows.Forms.Label()
        Me.currencytextboxPrecioTotal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.currencytextboxPrecioUnitarioFinal = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.currencytextboxPrecioUnitarioDescuentoImporte = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.percenttextboxPrecioUnitarioDescuentoPorcentaje = New Syncfusion.Windows.Forms.Tools.PercentTextBox()
        Me.currencytextboxPrecioUnitario = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.toolstripMain.SuspendLayout()
        CType(Me.currencytextboxPrecioTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.currencytextboxPrecioUnitarioFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.currencytextboxPrecioUnitarioDescuentoImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.percenttextboxPrecioUnitarioDescuentoPorcentaje, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.currencytextboxPrecioUnitario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(476, 39)
        Me.toolstripMain.TabIndex = 21
        '
        'buttonCancelar
        '
        Me.buttonCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonCancelar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageCancelar32
        Me.buttonCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCancelar.Name = "buttonCancelar"
        Me.buttonCancelar.Size = New System.Drawing.Size(89, 36)
        Me.buttonCancelar.Text = "Cancelar"
        '
        'buttonGuardar
        '
        Me.buttonGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonGuardar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageAceptar32
        Me.buttonGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonGuardar.Name = "buttonGuardar"
        Me.buttonGuardar.Size = New System.Drawing.Size(85, 36)
        Me.buttonGuardar.Text = "Guardar"
        '
        'labelArticulo
        '
        Me.labelArticulo.AutoSize = True
        Me.labelArticulo.Location = New System.Drawing.Point(12, 54)
        Me.labelArticulo.Name = "labelArticulo"
        Me.labelArticulo.Size = New System.Drawing.Size(47, 13)
        Me.labelArticulo.TabIndex = 0
        Me.labelArticulo.Text = "Artículo:"
        '
        'buttonAlumno
        '
        Me.buttonAlumno.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonAlumno.Location = New System.Drawing.Point(440, 76)
        Me.buttonAlumno.Name = "buttonAlumno"
        Me.buttonAlumno.Size = New System.Drawing.Size(22, 23)
        Me.buttonAlumno.TabIndex = 4
        Me.buttonAlumno.UseVisualStyleBackColor = True
        '
        'labelAlumno
        '
        Me.labelAlumno.AutoSize = True
        Me.labelAlumno.Location = New System.Drawing.Point(12, 80)
        Me.labelAlumno.Name = "labelAlumno"
        Me.labelAlumno.Size = New System.Drawing.Size(45, 13)
        Me.labelAlumno.TabIndex = 2
        Me.labelAlumno.Text = "Alumno:"
        '
        'comboboxAnioLectivoCurso
        '
        Me.comboboxAnioLectivoCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnioLectivoCurso.FormattingEnabled = True
        Me.comboboxAnioLectivoCurso.Location = New System.Drawing.Point(123, 104)
        Me.comboboxAnioLectivoCurso.Name = "comboboxAnioLectivoCurso"
        Me.comboboxAnioLectivoCurso.Size = New System.Drawing.Size(339, 21)
        Me.comboboxAnioLectivoCurso.TabIndex = 6
        '
        'labelAnioLectivoCurso
        '
        Me.labelAnioLectivoCurso.AutoSize = True
        Me.labelAnioLectivoCurso.Location = New System.Drawing.Point(12, 107)
        Me.labelAnioLectivoCurso.Name = "labelAnioLectivoCurso"
        Me.labelAnioLectivoCurso.Size = New System.Drawing.Size(105, 13)
        Me.labelAnioLectivoCurso.TabIndex = 5
        Me.labelAnioLectivoCurso.Text = "Año Lectivo y Curso:"
        '
        'comboboxCuotaMesDesde
        '
        Me.comboboxCuotaMesDesde.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCuotaMesDesde.FormattingEnabled = True
        Me.comboboxCuotaMesDesde.Location = New System.Drawing.Point(123, 131)
        Me.comboboxCuotaMesDesde.Name = "comboboxCuotaMesDesde"
        Me.comboboxCuotaMesDesde.Size = New System.Drawing.Size(144, 21)
        Me.comboboxCuotaMesDesde.TabIndex = 8
        '
        'labelCuotaMesDesde
        '
        Me.labelCuotaMesDesde.AutoSize = True
        Me.labelCuotaMesDesde.Location = New System.Drawing.Point(12, 134)
        Me.labelCuotaMesDesde.Name = "labelCuotaMesDesde"
        Me.labelCuotaMesDesde.Size = New System.Drawing.Size(107, 13)
        Me.labelCuotaMesDesde.TabIndex = 7
        Me.labelCuotaMesDesde.Text = "Cuota - Mes - Desde:"
        '
        'labelPrecioUnitario
        '
        Me.labelPrecioUnitario.AutoSize = True
        Me.labelPrecioUnitario.Location = New System.Drawing.Point(12, 188)
        Me.labelPrecioUnitario.Name = "labelPrecioUnitario"
        Me.labelPrecioUnitario.Size = New System.Drawing.Size(79, 13)
        Me.labelPrecioUnitario.TabIndex = 11
        Me.labelPrecioUnitario.Text = "Precio Unitario:"
        '
        'labelPrecioUnitarioDescuentoPorcentaje
        '
        Me.labelPrecioUnitarioDescuentoPorcentaje.AutoSize = True
        Me.labelPrecioUnitarioDescuentoPorcentaje.Location = New System.Drawing.Point(12, 214)
        Me.labelPrecioUnitarioDescuentoPorcentaje.Name = "labelPrecioUnitarioDescuentoPorcentaje"
        Me.labelPrecioUnitarioDescuentoPorcentaje.Size = New System.Drawing.Size(73, 13)
        Me.labelPrecioUnitarioDescuentoPorcentaje.TabIndex = 13
        Me.labelPrecioUnitarioDescuentoPorcentaje.Text = "% Descuento:"
        '
        'labelPrecioUnitarioDescuentoImporte
        '
        Me.labelPrecioUnitarioDescuentoImporte.AutoSize = True
        Me.labelPrecioUnitarioDescuentoImporte.Location = New System.Drawing.Point(12, 240)
        Me.labelPrecioUnitarioDescuentoImporte.Name = "labelPrecioUnitarioDescuentoImporte"
        Me.labelPrecioUnitarioDescuentoImporte.Size = New System.Drawing.Size(100, 13)
        Me.labelPrecioUnitarioDescuentoImporte.TabIndex = 15
        Me.labelPrecioUnitarioDescuentoImporte.Text = "Importe Descuento:"
        '
        'labelPrecioUnitarioFinal
        '
        Me.labelPrecioUnitarioFinal.AutoSize = True
        Me.labelPrecioUnitarioFinal.Location = New System.Drawing.Point(12, 266)
        Me.labelPrecioUnitarioFinal.Name = "labelPrecioUnitarioFinal"
        Me.labelPrecioUnitarioFinal.Size = New System.Drawing.Size(104, 13)
        Me.labelPrecioUnitarioFinal.TabIndex = 17
        Me.labelPrecioUnitarioFinal.Text = "Precio Unitario Final:"
        '
        'labelPrecioTotal
        '
        Me.labelPrecioTotal.AutoSize = True
        Me.labelPrecioTotal.Location = New System.Drawing.Point(12, 292)
        Me.labelPrecioTotal.Name = "labelPrecioTotal"
        Me.labelPrecioTotal.Size = New System.Drawing.Size(67, 13)
        Me.labelPrecioTotal.TabIndex = 19
        Me.labelPrecioTotal.Text = "Precio Total:"
        '
        'comboboxAlumno
        '
        Me.comboboxAlumno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAlumno.FormattingEnabled = True
        Me.comboboxAlumno.Location = New System.Drawing.Point(123, 77)
        Me.comboboxAlumno.Name = "comboboxAlumno"
        Me.comboboxAlumno.Size = New System.Drawing.Size(317, 21)
        Me.comboboxAlumno.TabIndex = 3
        '
        'textboxArticulo
        '
        Me.textboxArticulo.Location = New System.Drawing.Point(123, 51)
        Me.textboxArticulo.Name = "textboxArticulo"
        Me.textboxArticulo.ReadOnly = True
        Me.textboxArticulo.Size = New System.Drawing.Size(339, 20)
        Me.textboxArticulo.TabIndex = 1
        '
        'comboboxCuotaMesHasta
        '
        Me.comboboxCuotaMesHasta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCuotaMesHasta.FormattingEnabled = True
        Me.comboboxCuotaMesHasta.Location = New System.Drawing.Point(123, 158)
        Me.comboboxCuotaMesHasta.Name = "comboboxCuotaMesHasta"
        Me.comboboxCuotaMesHasta.Size = New System.Drawing.Size(144, 21)
        Me.comboboxCuotaMesHasta.TabIndex = 10
        '
        'labelCuotaMesHasta
        '
        Me.labelCuotaMesHasta.AutoSize = True
        Me.labelCuotaMesHasta.Location = New System.Drawing.Point(12, 161)
        Me.labelCuotaMesHasta.Name = "labelCuotaMesHasta"
        Me.labelCuotaMesHasta.Size = New System.Drawing.Size(104, 13)
        Me.labelCuotaMesHasta.TabIndex = 9
        Me.labelCuotaMesHasta.Text = "Cuota - Mes - Hasta:"
        '
        'currencytextboxPrecioTotal
        '
        Me.currencytextboxPrecioTotal.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.currencytextboxPrecioTotal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxPrecioTotal.Location = New System.Drawing.Point(123, 289)
        Me.currencytextboxPrecioTotal.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.currencytextboxPrecioTotal.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxPrecioTotal.Name = "currencytextboxPrecioTotal"
        Me.currencytextboxPrecioTotal.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.currencytextboxPrecioTotal.ReadOnly = True
        Me.currencytextboxPrecioTotal.Size = New System.Drawing.Size(130, 20)
        Me.currencytextboxPrecioTotal.TabIndex = 20
        Me.currencytextboxPrecioTotal.Text = "$ 0,00"
        Me.currencytextboxPrecioTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'currencytextboxPrecioUnitarioFinal
        '
        Me.currencytextboxPrecioUnitarioFinal.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.currencytextboxPrecioUnitarioFinal.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxPrecioUnitarioFinal.Location = New System.Drawing.Point(123, 263)
        Me.currencytextboxPrecioUnitarioFinal.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.currencytextboxPrecioUnitarioFinal.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxPrecioUnitarioFinal.Name = "currencytextboxPrecioUnitarioFinal"
        Me.currencytextboxPrecioUnitarioFinal.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.currencytextboxPrecioUnitarioFinal.ReadOnly = True
        Me.currencytextboxPrecioUnitarioFinal.Size = New System.Drawing.Size(130, 20)
        Me.currencytextboxPrecioUnitarioFinal.TabIndex = 18
        Me.currencytextboxPrecioUnitarioFinal.Text = "$ 0,00"
        Me.currencytextboxPrecioUnitarioFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'currencytextboxPrecioUnitarioDescuentoImporte
        '
        Me.currencytextboxPrecioUnitarioDescuentoImporte.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.currencytextboxPrecioUnitarioDescuentoImporte.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxPrecioUnitarioDescuentoImporte.Location = New System.Drawing.Point(123, 237)
        Me.currencytextboxPrecioUnitarioDescuentoImporte.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.currencytextboxPrecioUnitarioDescuentoImporte.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxPrecioUnitarioDescuentoImporte.Name = "currencytextboxPrecioUnitarioDescuentoImporte"
        Me.currencytextboxPrecioUnitarioDescuentoImporte.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.currencytextboxPrecioUnitarioDescuentoImporte.Size = New System.Drawing.Size(130, 20)
        Me.currencytextboxPrecioUnitarioDescuentoImporte.TabIndex = 16
        Me.currencytextboxPrecioUnitarioDescuentoImporte.Text = "$ 0,00"
        Me.currencytextboxPrecioUnitarioDescuentoImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'percenttextboxPrecioUnitarioDescuentoPorcentaje
        '
        Me.percenttextboxPrecioUnitarioDescuentoPorcentaje.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.percenttextboxPrecioUnitarioDescuentoPorcentaje.Location = New System.Drawing.Point(123, 211)
        Me.percenttextboxPrecioUnitarioDescuentoPorcentaje.MinValue = 0R
        Me.percenttextboxPrecioUnitarioDescuentoPorcentaje.Name = "percenttextboxPrecioUnitarioDescuentoPorcentaje"
        Me.percenttextboxPrecioUnitarioDescuentoPorcentaje.PercentNegativePattern = 1
        Me.percenttextboxPrecioUnitarioDescuentoPorcentaje.PercentPositivePattern = 1
        Me.percenttextboxPrecioUnitarioDescuentoPorcentaje.Size = New System.Drawing.Size(69, 20)
        Me.percenttextboxPrecioUnitarioDescuentoPorcentaje.TabIndex = 14
        Me.percenttextboxPrecioUnitarioDescuentoPorcentaje.Text = "0,00%"
        Me.percenttextboxPrecioUnitarioDescuentoPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'currencytextboxPrecioUnitario
        '
        Me.currencytextboxPrecioUnitario.BeforeTouchSize = New System.Drawing.Size(130, 20)
        Me.currencytextboxPrecioUnitario.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxPrecioUnitario.Location = New System.Drawing.Point(123, 185)
        Me.currencytextboxPrecioUnitario.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.currencytextboxPrecioUnitario.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxPrecioUnitario.Name = "currencytextboxPrecioUnitario"
        Me.currencytextboxPrecioUnitario.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.currencytextboxPrecioUnitario.Size = New System.Drawing.Size(130, 20)
        Me.currencytextboxPrecioUnitario.TabIndex = 12
        Me.currencytextboxPrecioUnitario.Text = "$ 0,00"
        Me.currencytextboxPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'formComprobanteDetalleAgregarMultiple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 323)
        Me.Controls.Add(Me.currencytextboxPrecioTotal)
        Me.Controls.Add(Me.currencytextboxPrecioUnitarioFinal)
        Me.Controls.Add(Me.currencytextboxPrecioUnitarioDescuentoImporte)
        Me.Controls.Add(Me.percenttextboxPrecioUnitarioDescuentoPorcentaje)
        Me.Controls.Add(Me.currencytextboxPrecioUnitario)
        Me.Controls.Add(Me.comboboxCuotaMesHasta)
        Me.Controls.Add(Me.labelCuotaMesHasta)
        Me.Controls.Add(Me.textboxArticulo)
        Me.Controls.Add(Me.comboboxAlumno)
        Me.Controls.Add(Me.labelPrecioTotal)
        Me.Controls.Add(Me.labelPrecioUnitarioFinal)
        Me.Controls.Add(Me.labelPrecioUnitarioDescuentoImporte)
        Me.Controls.Add(Me.labelPrecioUnitarioDescuentoPorcentaje)
        Me.Controls.Add(Me.labelPrecioUnitario)
        Me.Controls.Add(Me.comboboxCuotaMesDesde)
        Me.Controls.Add(Me.labelCuotaMesDesde)
        Me.Controls.Add(Me.comboboxAnioLectivoCurso)
        Me.Controls.Add(Me.labelAnioLectivoCurso)
        Me.Controls.Add(Me.buttonAlumno)
        Me.Controls.Add(Me.labelAlumno)
        Me.Controls.Add(Me.labelArticulo)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formComprobanteDetalleAgregarMultiple"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        CType(Me.currencytextboxPrecioTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.currencytextboxPrecioUnitarioFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.currencytextboxPrecioUnitarioDescuentoImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.percenttextboxPrecioUnitarioDescuentoPorcentaje, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.currencytextboxPrecioUnitario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents labelArticulo As System.Windows.Forms.Label
    Friend WithEvents buttonAlumno As System.Windows.Forms.Button
    Friend WithEvents labelAlumno As System.Windows.Forms.Label
    Friend WithEvents comboboxAnioLectivoCurso As System.Windows.Forms.ComboBox
    Friend WithEvents labelAnioLectivoCurso As System.Windows.Forms.Label
    Friend WithEvents comboboxCuotaMesDesde As System.Windows.Forms.ComboBox
    Friend WithEvents labelCuotaMesDesde As System.Windows.Forms.Label
    Friend WithEvents labelPrecioUnitario As System.Windows.Forms.Label
    Friend WithEvents labelPrecioUnitarioDescuentoPorcentaje As System.Windows.Forms.Label
    Friend WithEvents labelPrecioUnitarioDescuentoImporte As System.Windows.Forms.Label
    Friend WithEvents labelPrecioUnitarioFinal As System.Windows.Forms.Label
    Friend WithEvents labelPrecioTotal As System.Windows.Forms.Label
    Friend WithEvents comboboxAlumno As System.Windows.Forms.ComboBox
    Friend WithEvents textboxArticulo As System.Windows.Forms.TextBox
    Friend WithEvents comboboxCuotaMesHasta As System.Windows.Forms.ComboBox
    Friend WithEvents labelCuotaMesHasta As System.Windows.Forms.Label
    Friend WithEvents currencytextboxPrecioTotal As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents currencytextboxPrecioUnitarioFinal As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents currencytextboxPrecioUnitarioDescuentoImporte As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents percenttextboxPrecioUnitarioDescuentoPorcentaje As Syncfusion.Windows.Forms.Tools.PercentTextBox
    Friend WithEvents currencytextboxPrecioUnitario As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
End Class
