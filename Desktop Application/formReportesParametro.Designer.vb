<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formReportesParametro
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
        Me.buttonAceptar = New System.Windows.Forms.ToolStripButton()
        Me.labelValor = New System.Windows.Forms.Label()
        Me.datetimepickerValor = New System.Windows.Forms.DateTimePicker()
        Me.textboxMoney = New CSColegio.DesktopApplication.CS_Control_TextBox_Currency()
        Me.textboxNumber = New CSColegio.DesktopApplication.CS_Control_TextBox_Number()
        Me.toolstripMain.SuspendLayout()
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
        'textboxMoney
        '
        Me.textboxMoney.Location = New System.Drawing.Point(61, 65)
        Me.textboxMoney.Name = "textboxMoney"
        Me.textboxMoney.Size = New System.Drawing.Size(120, 20)
        Me.textboxMoney.TabIndex = 32
        '
        'textboxNumber
        '
        Me.textboxNumber.Location = New System.Drawing.Point(61, 65)
        Me.textboxNumber.Name = "textboxNumber"
        Me.textboxNumber.NumberStyle = System.Globalization.NumberStyles.None
        Me.textboxNumber.Size = New System.Drawing.Size(100, 20)
        Me.textboxNumber.TabIndex = 33
        '
        'formReportesParametro
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(268, 105)
        Me.Controls.Add(Me.textboxNumber)
        Me.Controls.Add(Me.textboxMoney)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonAceptar As System.Windows.Forms.ToolStripButton
    Friend WithEvents labelValor As System.Windows.Forms.Label
    Friend WithEvents datetimepickerValor As System.Windows.Forms.DateTimePicker
    Friend WithEvents textboxMoney As CSColegio.DesktopApplication.CS_Control_TextBox_Currency
    Friend WithEvents textboxNumber As CSColegio.DesktopApplication.CS_Control_TextBox_Number
End Class
