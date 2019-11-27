<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formReportesParametro
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
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonAceptar = New System.Windows.Forms.ToolStripButton()
        Me.labelValor = New System.Windows.Forms.Label()
        Me.datetimepickerValor = New System.Windows.Forms.DateTimePicker()
        Me.currencytextboxMoney = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.doubletextboxNumber = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.comboboxValues = New System.Windows.Forms.ComboBox()
        Me.integertextboxNumber = New Syncfusion.Windows.Forms.Tools.IntegerTextBox()
        Me.toolstripMain.SuspendLayout()
        CType(Me.currencytextboxMoney, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.doubletextboxNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.integertextboxNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCancelar, Me.buttonAceptar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(268, 39)
        Me.toolstripMain.TabIndex = 29
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
        'buttonAceptar
        '
        Me.buttonAceptar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonAceptar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_OK_32
        Me.buttonAceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonAceptar.Name = "buttonAceptar"
        Me.buttonAceptar.Size = New System.Drawing.Size(84, 36)
        Me.buttonAceptar.Text = "Aceptar"
        '
        'labelValor
        '
        Me.labelValor.AutoSize = True
        Me.labelValor.Location = New System.Drawing.Point(12, 68)
        Me.labelValor.Name = "labelValor"
        Me.labelValor.Size = New System.Drawing.Size(34, 13)
        Me.labelValor.TabIndex = 30
        Me.labelValor.Text = "Valor:"
        '
        'datetimepickerValor
        '
        Me.datetimepickerValor.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerValor.Location = New System.Drawing.Point(61, 66)
        Me.datetimepickerValor.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerValor.MinDate = New Date(2015, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerValor.Name = "datetimepickerValor"
        Me.datetimepickerValor.Size = New System.Drawing.Size(120, 20)
        Me.datetimepickerValor.TabIndex = 31
        '
        'currencytextboxMoney
        '
        Me.currencytextboxMoney.BeforeTouchSize = New System.Drawing.Size(69, 20)
        Me.currencytextboxMoney.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxMoney.Location = New System.Drawing.Point(61, 66)
        Me.currencytextboxMoney.MaxValue = New Decimal(New Integer() {99999999, 0, 0, 131072})
        Me.currencytextboxMoney.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.currencytextboxMoney.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxMoney.Name = "currencytextboxMoney"
        Me.currencytextboxMoney.NullString = ""
        Me.currencytextboxMoney.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.currencytextboxMoney.Size = New System.Drawing.Size(100, 20)
        Me.currencytextboxMoney.TabIndex = 32
        Me.currencytextboxMoney.Text = "$ 0,00"
        Me.currencytextboxMoney.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'doubletextboxNumber
        '
        Me.doubletextboxNumber.BeforeTouchSize = New System.Drawing.Size(69, 20)
        Me.doubletextboxNumber.DoubleValue = 0R
        Me.doubletextboxNumber.Location = New System.Drawing.Point(61, 66)
        Me.doubletextboxNumber.MaxValue = 999999.99R
        Me.doubletextboxNumber.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.doubletextboxNumber.MinValue = 0R
        Me.doubletextboxNumber.Name = "doubletextboxNumber"
        Me.doubletextboxNumber.NullString = ""
        Me.doubletextboxNumber.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.doubletextboxNumber.Size = New System.Drawing.Size(69, 20)
        Me.doubletextboxNumber.TabIndex = 33
        Me.doubletextboxNumber.Text = "0,00"
        Me.doubletextboxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'comboboxValues
        '
        Me.comboboxValues.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxValues.FormattingEnabled = True
        Me.comboboxValues.Location = New System.Drawing.Point(61, 65)
        Me.comboboxValues.Name = "comboboxValues"
        Me.comboboxValues.Size = New System.Drawing.Size(195, 21)
        Me.comboboxValues.TabIndex = 34
        '
        'integertextboxNumber
        '
        Me.integertextboxNumber.AllowNull = True
        Me.integertextboxNumber.BeforeTouchSize = New System.Drawing.Size(69, 20)
        Me.integertextboxNumber.IntegerValue = CType(0, Long)
        Me.integertextboxNumber.Location = New System.Drawing.Point(61, 65)
        Me.integertextboxNumber.MaxValue = CType(9999999, Long)
        Me.integertextboxNumber.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.integertextboxNumber.MinValue = CType(0, Long)
        Me.integertextboxNumber.Name = "integertextboxNumber"
        Me.integertextboxNumber.NullString = ""
        Me.integertextboxNumber.Size = New System.Drawing.Size(69, 20)
        Me.integertextboxNumber.TabIndex = 35
        Me.integertextboxNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'formReportesParametro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 105)
        Me.Controls.Add(Me.integertextboxNumber)
        Me.Controls.Add(Me.comboboxValues)
        Me.Controls.Add(Me.doubletextboxNumber)
        Me.Controls.Add(Me.currencytextboxMoney)
        Me.Controls.Add(Me.datetimepickerValor)
        Me.Controls.Add(Me.labelValor)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formReportesParametro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ReportesParametros"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        CType(Me.currencytextboxMoney, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.doubletextboxNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.integertextboxNumber, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonAceptar As System.Windows.Forms.ToolStripButton
    Friend WithEvents labelValor As System.Windows.Forms.Label
    Friend WithEvents datetimepickerValor As System.Windows.Forms.DateTimePicker
    Friend WithEvents currencytextboxMoney As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents doubletextboxNumber As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents comboboxValues As ComboBox
    Friend WithEvents integertextboxNumber As Syncfusion.Windows.Forms.Tools.IntegerTextBox
End Class
