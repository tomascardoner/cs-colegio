<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formCheque
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
        Dim labelCodigoPostal As System.Windows.Forms.Label
        Me.labelCuenta = New System.Windows.Forms.Label()
        Me.comboboxBanco = New System.Windows.Forms.ComboBox()
        Me.labelBanco = New System.Windows.Forms.Label()
        Me.textboxNumero = New System.Windows.Forms.TextBox()
        Me.labelNumero = New System.Windows.Forms.Label()
        Me.datetimepickerFechaEmision = New System.Windows.Forms.DateTimePicker()
        Me.labelFechaEmision = New System.Windows.Forms.Label()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.textboxCuenta = New System.Windows.Forms.TextBox()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.textboxIDCheque = New System.Windows.Forms.TextBox()
        Me.labelIDCheque = New System.Windows.Forms.Label()
        Me.datetimepickerFechaPago = New System.Windows.Forms.DateTimePicker()
        Me.labelFechaPago = New System.Windows.Forms.Label()
        Me.labelImporte = New System.Windows.Forms.Label()
        Me.maskedtextboxCUIT = New System.Windows.Forms.MaskedTextBox()
        Me.labelCUIT = New System.Windows.Forms.Label()
        Me.textboxTitular = New System.Windows.Forms.TextBox()
        Me.labelTitular = New System.Windows.Forms.Label()
        Me.textboxCodigoPostal = New System.Windows.Forms.TextBox()
        Me.textboxEstado = New System.Windows.Forms.TextBox()
        Me.labelEstado = New System.Windows.Forms.Label()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.labelMotivoRechazo = New System.Windows.Forms.Label()
        Me.comboboxMotivoRechazo = New System.Windows.Forms.ComboBox()
        Me.comboboxMedioPago = New System.Windows.Forms.ComboBox()
        Me.labelMedioPago = New System.Windows.Forms.Label()
        Me.comboboxCaja = New System.Windows.Forms.ComboBox()
        Me.labelCaja = New System.Windows.Forms.Label()
        Me.currencytextboxImporte = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        labelCodigoPostal = New System.Windows.Forms.Label()
        Me.toolstripMain.SuspendLayout()
        CType(Me.currencytextboxImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelCodigoPostal
        '
        labelCodigoPostal.AutoSize = True
        labelCodigoPostal.Location = New System.Drawing.Point(12, 329)
        labelCodigoPostal.Name = "labelCodigoPostal"
        labelCodigoPostal.Size = New System.Drawing.Size(59, 13)
        labelCodigoPostal.TabIndex = 20
        labelCodigoPostal.Text = "Cód. Post.:"
        '
        'labelCuenta
        '
        Me.labelCuenta.AutoSize = True
        Me.labelCuenta.Location = New System.Drawing.Point(12, 251)
        Me.labelCuenta.Name = "labelCuenta"
        Me.labelCuenta.Size = New System.Drawing.Size(44, 13)
        Me.labelCuenta.TabIndex = 14
        Me.labelCuenta.Text = "Cuenta:"
        '
        'comboboxBanco
        '
        Me.comboboxBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxBanco.FormattingEnabled = True
        Me.comboboxBanco.Location = New System.Drawing.Point(123, 117)
        Me.comboboxBanco.Name = "comboboxBanco"
        Me.comboboxBanco.Size = New System.Drawing.Size(235, 21)
        Me.comboboxBanco.TabIndex = 5
        '
        'labelBanco
        '
        Me.labelBanco.AutoSize = True
        Me.labelBanco.Location = New System.Drawing.Point(12, 120)
        Me.labelBanco.Name = "labelBanco"
        Me.labelBanco.Size = New System.Drawing.Size(41, 13)
        Me.labelBanco.TabIndex = 4
        Me.labelBanco.Text = "Banco:"
        '
        'textboxNumero
        '
        Me.textboxNumero.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textboxNumero.Location = New System.Drawing.Point(123, 196)
        Me.textboxNumero.MaxLength = 20
        Me.textboxNumero.Name = "textboxNumero"
        Me.textboxNumero.Size = New System.Drawing.Size(134, 20)
        Me.textboxNumero.TabIndex = 11
        '
        'labelNumero
        '
        Me.labelNumero.AutoSize = True
        Me.labelNumero.Location = New System.Drawing.Point(12, 199)
        Me.labelNumero.Name = "labelNumero"
        Me.labelNumero.Size = New System.Drawing.Size(47, 13)
        Me.labelNumero.TabIndex = 10
        Me.labelNumero.Text = "Número:"
        '
        'datetimepickerFechaEmision
        '
        Me.datetimepickerFechaEmision.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerFechaEmision.Location = New System.Drawing.Point(123, 144)
        Me.datetimepickerFechaEmision.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerFechaEmision.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerFechaEmision.Name = "datetimepickerFechaEmision"
        Me.datetimepickerFechaEmision.Size = New System.Drawing.Size(110, 20)
        Me.datetimepickerFechaEmision.TabIndex = 7
        '
        'labelFechaEmision
        '
        Me.labelFechaEmision.AutoSize = True
        Me.labelFechaEmision.Location = New System.Drawing.Point(12, 147)
        Me.labelFechaEmision.Name = "labelFechaEmision"
        Me.labelFechaEmision.Size = New System.Drawing.Size(94, 13)
        Me.labelFechaEmision.TabIndex = 6
        Me.labelFechaEmision.Text = "Fecha de Emisión:"
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
        'textboxCuenta
        '
        Me.textboxCuenta.Location = New System.Drawing.Point(123, 248)
        Me.textboxCuenta.MaxLength = 20
        Me.textboxCuenta.Name = "textboxCuenta"
        Me.textboxCuenta.Size = New System.Drawing.Size(134, 20)
        Me.textboxCuenta.TabIndex = 15
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(371, 39)
        Me.toolstripMain.TabIndex = 28
        '
        'textboxIDCheque
        '
        Me.textboxIDCheque.Location = New System.Drawing.Point(123, 91)
        Me.textboxIDCheque.MaxLength = 10
        Me.textboxIDCheque.Name = "textboxIDCheque"
        Me.textboxIDCheque.ReadOnly = True
        Me.textboxIDCheque.Size = New System.Drawing.Size(74, 20)
        Me.textboxIDCheque.TabIndex = 3
        Me.textboxIDCheque.TabStop = False
        Me.textboxIDCheque.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'labelIDCheque
        '
        Me.labelIDCheque.AutoSize = True
        Me.labelIDCheque.Location = New System.Drawing.Point(12, 94)
        Me.labelIDCheque.Name = "labelIDCheque"
        Me.labelIDCheque.Size = New System.Drawing.Size(21, 13)
        Me.labelIDCheque.TabIndex = 2
        Me.labelIDCheque.Text = "ID:"
        '
        'datetimepickerFechaPago
        '
        Me.datetimepickerFechaPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerFechaPago.Location = New System.Drawing.Point(123, 170)
        Me.datetimepickerFechaPago.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerFechaPago.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerFechaPago.Name = "datetimepickerFechaPago"
        Me.datetimepickerFechaPago.Size = New System.Drawing.Size(110, 20)
        Me.datetimepickerFechaPago.TabIndex = 9
        '
        'labelFechaPago
        '
        Me.labelFechaPago.AutoSize = True
        Me.labelFechaPago.Location = New System.Drawing.Point(12, 173)
        Me.labelFechaPago.Name = "labelFechaPago"
        Me.labelFechaPago.Size = New System.Drawing.Size(83, 13)
        Me.labelFechaPago.TabIndex = 8
        Me.labelFechaPago.Text = "Fecha de Pago:"
        '
        'labelImporte
        '
        Me.labelImporte.AutoSize = True
        Me.labelImporte.Location = New System.Drawing.Point(12, 225)
        Me.labelImporte.Name = "labelImporte"
        Me.labelImporte.Size = New System.Drawing.Size(45, 13)
        Me.labelImporte.TabIndex = 12
        Me.labelImporte.Text = "Importe:"
        '
        'maskedtextboxCUIT
        '
        Me.maskedtextboxCUIT.AllowPromptAsInput = False
        Me.maskedtextboxCUIT.AsciiOnly = True
        Me.maskedtextboxCUIT.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        Me.maskedtextboxCUIT.HidePromptOnLeave = True
        Me.maskedtextboxCUIT.Location = New System.Drawing.Point(123, 274)
        Me.maskedtextboxCUIT.Mask = "00-00000000-0"
        Me.maskedtextboxCUIT.Name = "maskedtextboxCUIT"
        Me.maskedtextboxCUIT.Size = New System.Drawing.Size(115, 20)
        Me.maskedtextboxCUIT.TabIndex = 17
        Me.maskedtextboxCUIT.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals
        '
        'labelCUIT
        '
        Me.labelCUIT.AutoSize = True
        Me.labelCUIT.Location = New System.Drawing.Point(12, 277)
        Me.labelCUIT.Name = "labelCUIT"
        Me.labelCUIT.Size = New System.Drawing.Size(35, 13)
        Me.labelCUIT.TabIndex = 16
        Me.labelCUIT.Text = "CUIT:"
        '
        'textboxTitular
        '
        Me.textboxTitular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textboxTitular.Location = New System.Drawing.Point(123, 300)
        Me.textboxTitular.MaxLength = 100
        Me.textboxTitular.Name = "textboxTitular"
        Me.textboxTitular.Size = New System.Drawing.Size(235, 20)
        Me.textboxTitular.TabIndex = 19
        '
        'labelTitular
        '
        Me.labelTitular.AutoSize = True
        Me.labelTitular.Location = New System.Drawing.Point(12, 303)
        Me.labelTitular.Name = "labelTitular"
        Me.labelTitular.Size = New System.Drawing.Size(39, 13)
        Me.labelTitular.TabIndex = 18
        Me.labelTitular.Text = "Titular:"
        '
        'textboxCodigoPostal
        '
        Me.textboxCodigoPostal.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textboxCodigoPostal.Location = New System.Drawing.Point(123, 326)
        Me.textboxCodigoPostal.MaxLength = 8
        Me.textboxCodigoPostal.Name = "textboxCodigoPostal"
        Me.textboxCodigoPostal.Size = New System.Drawing.Size(50, 20)
        Me.textboxCodigoPostal.TabIndex = 21
        '
        'textboxEstado
        '
        Me.textboxEstado.Location = New System.Drawing.Point(123, 407)
        Me.textboxEstado.MaxLength = 50
        Me.textboxEstado.Name = "textboxEstado"
        Me.textboxEstado.ReadOnly = True
        Me.textboxEstado.Size = New System.Drawing.Size(235, 20)
        Me.textboxEstado.TabIndex = 25
        Me.textboxEstado.TabStop = False
        Me.textboxEstado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'labelEstado
        '
        Me.labelEstado.AutoSize = True
        Me.labelEstado.Location = New System.Drawing.Point(12, 410)
        Me.labelEstado.Name = "labelEstado"
        Me.labelEstado.Size = New System.Drawing.Size(43, 13)
        Me.labelEstado.TabIndex = 24
        Me.labelEstado.Text = "Estado:"
        '
        'LineShape2
        '
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 12
        Me.LineShape2.X2 = 360
        Me.LineShape2.Y1 = 356
        Me.LineShape2.Y2 = 356
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape3, Me.LineShape1, Me.LineShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(371, 466)
        Me.ShapeContainer1.TabIndex = 46
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape3
        '
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 12
        Me.LineShape3.X2 = 360
        Me.LineShape3.Y1 = 397
        Me.LineShape3.Y2 = 397
        '
        'LineShape1
        '
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 12
        Me.LineShape1.X2 = 360
        Me.LineShape1.Y1 = 81
        Me.LineShape1.Y2 = 81
        '
        'labelMotivoRechazo
        '
        Me.labelMotivoRechazo.AutoSize = True
        Me.labelMotivoRechazo.Location = New System.Drawing.Point(12, 436)
        Me.labelMotivoRechazo.Name = "labelMotivoRechazo"
        Me.labelMotivoRechazo.Size = New System.Drawing.Size(105, 13)
        Me.labelMotivoRechazo.TabIndex = 26
        Me.labelMotivoRechazo.Text = "Motivo del Rechazo:"
        '
        'comboboxMotivoRechazo
        '
        Me.comboboxMotivoRechazo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxMotivoRechazo.FormattingEnabled = True
        Me.comboboxMotivoRechazo.Location = New System.Drawing.Point(123, 433)
        Me.comboboxMotivoRechazo.Name = "comboboxMotivoRechazo"
        Me.comboboxMotivoRechazo.Size = New System.Drawing.Size(235, 21)
        Me.comboboxMotivoRechazo.TabIndex = 27
        '
        'comboboxMedioPago
        '
        Me.comboboxMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxMedioPago.FormattingEnabled = True
        Me.comboboxMedioPago.Location = New System.Drawing.Point(123, 50)
        Me.comboboxMedioPago.Name = "comboboxMedioPago"
        Me.comboboxMedioPago.Size = New System.Drawing.Size(235, 21)
        Me.comboboxMedioPago.TabIndex = 1
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
        'comboboxCaja
        '
        Me.comboboxCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCaja.FormattingEnabled = True
        Me.comboboxCaja.Location = New System.Drawing.Point(123, 366)
        Me.comboboxCaja.Name = "comboboxCaja"
        Me.comboboxCaja.Size = New System.Drawing.Size(235, 21)
        Me.comboboxCaja.TabIndex = 23
        '
        'labelCaja
        '
        Me.labelCaja.AutoSize = True
        Me.labelCaja.Location = New System.Drawing.Point(12, 369)
        Me.labelCaja.Name = "labelCaja"
        Me.labelCaja.Size = New System.Drawing.Size(31, 13)
        Me.labelCaja.TabIndex = 22
        Me.labelCaja.Text = "Caja:"
        '
        'currencytextboxImporte
        '
        Me.currencytextboxImporte.BeforeTouchSize = New System.Drawing.Size(69, 20)
        Me.currencytextboxImporte.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxImporte.Location = New System.Drawing.Point(123, 222)
        Me.currencytextboxImporte.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 131072})
        Me.currencytextboxImporte.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.currencytextboxImporte.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxImporte.Name = "currencytextboxImporte"
        Me.currencytextboxImporte.NullString = ""
        Me.currencytextboxImporte.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.currencytextboxImporte.Size = New System.Drawing.Size(100, 20)
        Me.currencytextboxImporte.TabIndex = 13
        Me.currencytextboxImporte.Text = "$ 0,00"
        Me.currencytextboxImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'formCheque
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 466)
        Me.Controls.Add(Me.currencytextboxImporte)
        Me.Controls.Add(Me.comboboxCaja)
        Me.Controls.Add(Me.labelCaja)
        Me.Controls.Add(Me.comboboxMedioPago)
        Me.Controls.Add(Me.labelMedioPago)
        Me.Controls.Add(Me.comboboxMotivoRechazo)
        Me.Controls.Add(Me.labelMotivoRechazo)
        Me.Controls.Add(Me.textboxEstado)
        Me.Controls.Add(Me.labelEstado)
        Me.Controls.Add(labelCodigoPostal)
        Me.Controls.Add(Me.textboxCodigoPostal)
        Me.Controls.Add(Me.textboxTitular)
        Me.Controls.Add(Me.labelTitular)
        Me.Controls.Add(Me.labelCUIT)
        Me.Controls.Add(Me.maskedtextboxCUIT)
        Me.Controls.Add(Me.labelImporte)
        Me.Controls.Add(Me.datetimepickerFechaPago)
        Me.Controls.Add(Me.labelFechaPago)
        Me.Controls.Add(Me.textboxIDCheque)
        Me.Controls.Add(Me.labelIDCheque)
        Me.Controls.Add(Me.labelCuenta)
        Me.Controls.Add(Me.comboboxBanco)
        Me.Controls.Add(Me.labelBanco)
        Me.Controls.Add(Me.textboxNumero)
        Me.Controls.Add(Me.labelNumero)
        Me.Controls.Add(Me.datetimepickerFechaEmision)
        Me.Controls.Add(Me.labelFechaEmision)
        Me.Controls.Add(Me.textboxCuenta)
        Me.Controls.Add(Me.toolstripMain)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formCheque"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cheque"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        CType(Me.currencytextboxImporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelCuenta As System.Windows.Forms.Label
    Friend WithEvents comboboxBanco As System.Windows.Forms.ComboBox
    Friend WithEvents labelBanco As System.Windows.Forms.Label
    Friend WithEvents textboxNumero As System.Windows.Forms.TextBox
    Friend WithEvents labelNumero As System.Windows.Forms.Label
    Friend WithEvents datetimepickerFechaEmision As System.Windows.Forms.DateTimePicker
    Friend WithEvents labelFechaEmision As System.Windows.Forms.Label
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents textboxCuenta As System.Windows.Forms.TextBox
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents textboxIDCheque As System.Windows.Forms.TextBox
    Friend WithEvents labelIDCheque As System.Windows.Forms.Label
    Friend WithEvents datetimepickerFechaPago As System.Windows.Forms.DateTimePicker
    Friend WithEvents labelFechaPago As System.Windows.Forms.Label
    Friend WithEvents labelImporte As System.Windows.Forms.Label
    Friend WithEvents maskedtextboxCUIT As System.Windows.Forms.MaskedTextBox
    Friend WithEvents labelCUIT As System.Windows.Forms.Label
    Friend WithEvents textboxTitular As System.Windows.Forms.TextBox
    Friend WithEvents labelTitular As System.Windows.Forms.Label
    Friend WithEvents textboxCodigoPostal As System.Windows.Forms.TextBox
    Friend WithEvents textboxEstado As System.Windows.Forms.TextBox
    Friend WithEvents labelEstado As System.Windows.Forms.Label
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents labelMotivoRechazo As System.Windows.Forms.Label
    Friend WithEvents comboboxMotivoRechazo As System.Windows.Forms.ComboBox
    Friend WithEvents comboboxMedioPago As System.Windows.Forms.ComboBox
    Friend WithEvents labelMedioPago As System.Windows.Forms.Label
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents comboboxCaja As System.Windows.Forms.ComboBox
    Friend WithEvents labelCaja As System.Windows.Forms.Label
    Friend WithEvents currencytextboxImporte As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
End Class
