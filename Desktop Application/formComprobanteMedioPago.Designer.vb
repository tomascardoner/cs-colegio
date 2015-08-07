<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formComprobanteMedioPago
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
        Me.labelMedioPago = New System.Windows.Forms.Label()
        Me.comboboxMedioPago = New System.Windows.Forms.ComboBox()
        Me.comboboxCaja = New System.Windows.Forms.ComboBox()
        Me.labelCaja = New System.Windows.Forms.Label()
        Me.labelImporte = New System.Windows.Forms.Label()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.labelFechaHora = New System.Windows.Forms.Label()
        Me.datetimepickerFecha = New System.Windows.Forms.DateTimePicker()
        Me.datetimepickerHora = New System.Windows.Forms.DateTimePicker()
        Me.labelNumero = New System.Windows.Forms.Label()
        Me.textboxNumero = New System.Windows.Forms.TextBox()
        Me.comboboxBanco = New System.Windows.Forms.ComboBox()
        Me.labelBanco = New System.Windows.Forms.Label()
        Me.textboxImporte = New CSColegio.DesktopApplication.CS_Control_TextBox_Currency()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.textboxCuenta = New System.Windows.Forms.TextBox()
        Me.labelCuenta = New System.Windows.Forms.Label()
        Me.textboxTitular = New System.Windows.Forms.TextBox()
        Me.labelTitular = New System.Windows.Forms.Label()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelMedioPago
        '
        Me.labelMedioPago.AutoSize = True
        Me.labelMedioPago.Location = New System.Drawing.Point(12, 53)
        Me.labelMedioPago.Name = "labelMedioPago"
        Me.labelMedioPago.Size = New System.Drawing.Size(82, 13)
        Me.labelMedioPago.TabIndex = 0
        Me.labelMedioPago.Text = "Medio de Pago:"
        '
        'comboboxMedioPago
        '
        Me.comboboxMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxMedioPago.FormattingEnabled = True
        Me.comboboxMedioPago.Location = New System.Drawing.Point(97, 50)
        Me.comboboxMedioPago.Name = "comboboxMedioPago"
        Me.comboboxMedioPago.Size = New System.Drawing.Size(235, 21)
        Me.comboboxMedioPago.TabIndex = 1
        '
        'comboboxCaja
        '
        Me.comboboxCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCaja.FormattingEnabled = True
        Me.comboboxCaja.Location = New System.Drawing.Point(97, 236)
        Me.comboboxCaja.Name = "comboboxCaja"
        Me.comboboxCaja.Size = New System.Drawing.Size(235, 21)
        Me.comboboxCaja.TabIndex = 14
        '
        'labelCaja
        '
        Me.labelCaja.AutoSize = True
        Me.labelCaja.Location = New System.Drawing.Point(12, 239)
        Me.labelCaja.Name = "labelCaja"
        Me.labelCaja.Size = New System.Drawing.Size(31, 13)
        Me.labelCaja.TabIndex = 13
        Me.labelCaja.Text = "Caja:"
        '
        'labelImporte
        '
        Me.labelImporte.AutoSize = True
        Me.labelImporte.Location = New System.Drawing.Point(12, 266)
        Me.labelImporte.Name = "labelImporte"
        Me.labelImporte.Size = New System.Drawing.Size(45, 13)
        Me.labelImporte.TabIndex = 15
        Me.labelImporte.Text = "Importe:"
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(344, 39)
        Me.toolstripMain.TabIndex = 17
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
        'labelFechaHora
        '
        Me.labelFechaHora.AutoSize = True
        Me.labelFechaHora.Location = New System.Drawing.Point(12, 94)
        Me.labelFechaHora.Name = "labelFechaHora"
        Me.labelFechaHora.Size = New System.Drawing.Size(68, 13)
        Me.labelFechaHora.TabIndex = 2
        Me.labelFechaHora.Text = "Fecha/Hora:"
        '
        'datetimepickerFecha
        '
        Me.datetimepickerFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerFecha.Location = New System.Drawing.Point(97, 91)
        Me.datetimepickerFecha.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerFecha.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerFecha.Name = "datetimepickerFecha"
        Me.datetimepickerFecha.Size = New System.Drawing.Size(110, 20)
        Me.datetimepickerFecha.TabIndex = 3
        '
        'datetimepickerHora
        '
        Me.datetimepickerHora.CustomFormat = "HH:mm"
        Me.datetimepickerHora.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.datetimepickerHora.Location = New System.Drawing.Point(213, 91)
        Me.datetimepickerHora.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerHora.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerHora.Name = "datetimepickerHora"
        Me.datetimepickerHora.ShowUpDown = True
        Me.datetimepickerHora.Size = New System.Drawing.Size(62, 20)
        Me.datetimepickerHora.TabIndex = 4
        Me.datetimepickerHora.Value = New Date(2015, 8, 1, 0, 0, 0, 0)
        '
        'labelNumero
        '
        Me.labelNumero.AutoSize = True
        Me.labelNumero.Location = New System.Drawing.Point(12, 120)
        Me.labelNumero.Name = "labelNumero"
        Me.labelNumero.Size = New System.Drawing.Size(47, 13)
        Me.labelNumero.TabIndex = 5
        Me.labelNumero.Text = "Número:"
        '
        'textboxNumero
        '
        Me.textboxNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textboxNumero.Location = New System.Drawing.Point(97, 117)
        Me.textboxNumero.MaxLength = 20
        Me.textboxNumero.Name = "textboxNumero"
        Me.textboxNumero.Size = New System.Drawing.Size(134, 20)
        Me.textboxNumero.TabIndex = 6
        '
        'comboboxBanco
        '
        Me.comboboxBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxBanco.FormattingEnabled = True
        Me.comboboxBanco.Location = New System.Drawing.Point(97, 143)
        Me.comboboxBanco.Name = "comboboxBanco"
        Me.comboboxBanco.Size = New System.Drawing.Size(235, 21)
        Me.comboboxBanco.TabIndex = 8
        '
        'labelBanco
        '
        Me.labelBanco.AutoSize = True
        Me.labelBanco.Location = New System.Drawing.Point(12, 146)
        Me.labelBanco.Name = "labelBanco"
        Me.labelBanco.Size = New System.Drawing.Size(41, 13)
        Me.labelBanco.TabIndex = 7
        Me.labelBanco.Text = "Banco:"
        '
        'textboxImporte
        '
        Me.textboxImporte.Location = New System.Drawing.Point(97, 263)
        Me.textboxImporte.MaxLength = 15
        Me.textboxImporte.Name = "textboxImporte"
        Me.textboxImporte.Size = New System.Drawing.Size(100, 20)
        Me.textboxImporte.TabIndex = 16
        Me.textboxImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(344, 291)
        Me.ShapeContainer1.TabIndex = 14
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 12
        Me.LineShape2.X2 = 335
        Me.LineShape2.Y1 = 226
        Me.LineShape2.Y2 = 226
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 12
        Me.LineShape1.X2 = 335
        Me.LineShape1.Y1 = 81
        Me.LineShape1.Y2 = 81
        '
        'textboxCuenta
        '
        Me.textboxCuenta.Location = New System.Drawing.Point(97, 170)
        Me.textboxCuenta.MaxLength = 30
        Me.textboxCuenta.Name = "textboxCuenta"
        Me.textboxCuenta.Size = New System.Drawing.Size(235, 20)
        Me.textboxCuenta.TabIndex = 10
        '
        'labelCuenta
        '
        Me.labelCuenta.AutoSize = True
        Me.labelCuenta.Location = New System.Drawing.Point(12, 173)
        Me.labelCuenta.Name = "labelCuenta"
        Me.labelCuenta.Size = New System.Drawing.Size(44, 13)
        Me.labelCuenta.TabIndex = 9
        Me.labelCuenta.Text = "Cuenta:"
        '
        'textboxTitular
        '
        Me.textboxTitular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textboxTitular.Location = New System.Drawing.Point(97, 196)
        Me.textboxTitular.MaxLength = 100
        Me.textboxTitular.Name = "textboxTitular"
        Me.textboxTitular.Size = New System.Drawing.Size(235, 20)
        Me.textboxTitular.TabIndex = 12
        '
        'labelTitular
        '
        Me.labelTitular.AutoSize = True
        Me.labelTitular.Location = New System.Drawing.Point(12, 199)
        Me.labelTitular.Name = "labelTitular"
        Me.labelTitular.Size = New System.Drawing.Size(39, 13)
        Me.labelTitular.TabIndex = 11
        Me.labelTitular.Text = "Titular:"
        '
        'formComprobanteMedioPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 291)
        Me.Controls.Add(Me.textboxTitular)
        Me.Controls.Add(Me.labelTitular)
        Me.Controls.Add(Me.textboxCuenta)
        Me.Controls.Add(Me.labelCuenta)
        Me.Controls.Add(Me.comboboxBanco)
        Me.Controls.Add(Me.labelBanco)
        Me.Controls.Add(Me.textboxNumero)
        Me.Controls.Add(Me.labelNumero)
        Me.Controls.Add(Me.datetimepickerHora)
        Me.Controls.Add(Me.datetimepickerFecha)
        Me.Controls.Add(Me.labelFechaHora)
        Me.Controls.Add(Me.textboxImporte)
        Me.Controls.Add(Me.toolstripMain)
        Me.Controls.Add(Me.labelImporte)
        Me.Controls.Add(Me.comboboxCaja)
        Me.Controls.Add(Me.labelCaja)
        Me.Controls.Add(Me.comboboxMedioPago)
        Me.Controls.Add(Me.labelMedioPago)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formComprobanteMedioPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle del Medio de Pago"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelMedioPago As System.Windows.Forms.Label
    Friend WithEvents comboboxMedioPago As System.Windows.Forms.ComboBox
    Friend WithEvents comboboxCaja As System.Windows.Forms.ComboBox
    Friend WithEvents labelCaja As System.Windows.Forms.Label
    Friend WithEvents labelImporte As System.Windows.Forms.Label
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents textboxImporte As CSColegio.DesktopApplication.CS_Control_TextBox_Currency
    Friend WithEvents labelFechaHora As System.Windows.Forms.Label
    Friend WithEvents datetimepickerFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents datetimepickerHora As System.Windows.Forms.DateTimePicker
    Friend WithEvents labelNumero As System.Windows.Forms.Label
    Friend WithEvents textboxNumero As System.Windows.Forms.TextBox
    Friend WithEvents comboboxBanco As System.Windows.Forms.ComboBox
    Friend WithEvents labelBanco As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents textboxCuenta As System.Windows.Forms.TextBox
    Friend WithEvents labelCuenta As System.Windows.Forms.Label
    Friend WithEvents textboxTitular As System.Windows.Forms.TextBox
    Friend WithEvents labelTitular As System.Windows.Forms.Label
End Class
