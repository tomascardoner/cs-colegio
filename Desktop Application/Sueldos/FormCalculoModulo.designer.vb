<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCalculoModulo
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
        Me.LabelAnio = New System.Windows.Forms.Label()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.LabelMes = New System.Windows.Forms.Label()
        Me.LabelConcepto = New System.Windows.Forms.Label()
        Me.LabelImporte = New System.Windows.Forms.Label()
        Me.ComboBoxMes = New System.Windows.Forms.ComboBox()
        Me.CurrencyTextBoxImporte = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.TextBoxAnio = New System.Windows.Forms.TextBox()
        Me.ComboBoxConcepto = New System.Windows.Forms.ComboBox()
        Me.toolstripMain.SuspendLayout()
        CType(Me.CurrencyTextBoxImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelAnio
        '
        Me.LabelAnio.AutoSize = True
        Me.LabelAnio.Location = New System.Drawing.Point(13, 74)
        Me.LabelAnio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelAnio.Name = "LabelAnio"
        Me.LabelAnio.Size = New System.Drawing.Size(34, 16)
        Me.LabelAnio.TabIndex = 7
        Me.LabelAnio.Text = "Año:"
        '
        'buttonGuardar
        '
        Me.buttonGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonGuardar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageAceptar32
        Me.buttonGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonGuardar.Name = "buttonGuardar"
        Me.buttonGuardar.Size = New System.Drawing.Size(98, 36)
        Me.buttonGuardar.Text = "Guardar"
        '
        'buttonCancelar
        '
        Me.buttonCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonCancelar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageCancelar32
        Me.buttonCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCancelar.Name = "buttonCancelar"
        Me.buttonCancelar.Size = New System.Drawing.Size(102, 36)
        Me.buttonCancelar.Text = "Cancelar"
        '
        'buttonEditar
        '
        Me.buttonEditar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonEditar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_EDIT_32
        Me.buttonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEditar.Name = "buttonEditar"
        Me.buttonEditar.Size = New System.Drawing.Size(84, 36)
        Me.buttonEditar.Text = "Editar"
        '
        'buttonCerrar
        '
        Me.buttonCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonCerrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_32
        Me.buttonCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCerrar.Name = "buttonCerrar"
        Me.buttonCerrar.Size = New System.Drawing.Size(85, 36)
        Me.buttonCerrar.Text = "Cerrar"
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(450, 39)
        Me.toolstripMain.TabIndex = 6
        '
        'LabelMes
        '
        Me.LabelMes.AutoSize = True
        Me.LabelMes.Location = New System.Drawing.Point(13, 106)
        Me.LabelMes.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelMes.Name = "LabelMes"
        Me.LabelMes.Size = New System.Drawing.Size(36, 16)
        Me.LabelMes.TabIndex = 0
        Me.LabelMes.Text = "Mes:"
        '
        'LabelConcepto
        '
        Me.LabelConcepto.AutoSize = True
        Me.LabelConcepto.Location = New System.Drawing.Point(13, 138)
        Me.LabelConcepto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelConcepto.Name = "LabelConcepto"
        Me.LabelConcepto.Size = New System.Drawing.Size(68, 16)
        Me.LabelConcepto.TabIndex = 2
        Me.LabelConcepto.Text = "Concepto:"
        '
        'LabelImporte
        '
        Me.LabelImporte.AutoSize = True
        Me.LabelImporte.Location = New System.Drawing.Point(13, 170)
        Me.LabelImporte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelImporte.Name = "LabelImporte"
        Me.LabelImporte.Size = New System.Drawing.Size(55, 16)
        Me.LabelImporte.TabIndex = 4
        Me.LabelImporte.Text = "Importe:"
        '
        'ComboBoxMes
        '
        Me.ComboBoxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxMes.FormattingEnabled = True
        Me.ComboBoxMes.Location = New System.Drawing.Point(89, 103)
        Me.ComboBoxMes.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxMes.Name = "ComboBoxMes"
        Me.ComboBoxMes.Size = New System.Drawing.Size(111, 24)
        Me.ComboBoxMes.TabIndex = 1
        '
        'CurrencyTextBoxImporte
        '
        Me.CurrencyTextBoxImporte.AccessibilityEnabled = True
        Me.CurrencyTextBoxImporte.AllowNull = True
        Me.CurrencyTextBoxImporte.BeforeTouchSize = New System.Drawing.Size(111, 22)
        Me.CurrencyTextBoxImporte.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.CurrencyTextBoxImporte.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CurrencyTextBoxImporte.Location = New System.Drawing.Point(89, 167)
        Me.CurrencyTextBoxImporte.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrencyTextBoxImporte.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.CurrencyTextBoxImporte.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.CurrencyTextBoxImporte.Name = "CurrencyTextBoxImporte"
        Me.CurrencyTextBoxImporte.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.CurrencyTextBoxImporte.Size = New System.Drawing.Size(111, 22)
        Me.CurrencyTextBoxImporte.TabIndex = 5
        Me.CurrencyTextBoxImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TextBoxAnio
        '
        Me.TextBoxAnio.Location = New System.Drawing.Point(89, 71)
        Me.TextBoxAnio.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxAnio.MaxLength = 10
        Me.TextBoxAnio.Name = "TextBoxAnio"
        Me.TextBoxAnio.ReadOnly = True
        Me.TextBoxAnio.Size = New System.Drawing.Size(65, 22)
        Me.TextBoxAnio.TabIndex = 8
        Me.TextBoxAnio.TabStop = False
        Me.TextBoxAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ComboBoxConcepto
        '
        Me.ComboBoxConcepto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxConcepto.FormattingEnabled = True
        Me.ComboBoxConcepto.Location = New System.Drawing.Point(89, 135)
        Me.ComboBoxConcepto.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxConcepto.Name = "ComboBoxConcepto"
        Me.ComboBoxConcepto.Size = New System.Drawing.Size(348, 24)
        Me.ComboBoxConcepto.TabIndex = 3
        '
        'FormCalculoModulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(450, 200)
        Me.Controls.Add(Me.ComboBoxConcepto)
        Me.Controls.Add(Me.TextBoxAnio)
        Me.Controls.Add(Me.CurrencyTextBoxImporte)
        Me.Controls.Add(Me.ComboBoxMes)
        Me.Controls.Add(Me.LabelImporte)
        Me.Controls.Add(Me.LabelConcepto)
        Me.Controls.Add(Me.LabelMes)
        Me.Controls.Add(Me.LabelAnio)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCalculoModulo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cálculo de módulo"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        CType(Me.CurrencyTextBoxImporte, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelAnio As System.Windows.Forms.Label
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents LabelMes As System.Windows.Forms.Label
    Friend WithEvents LabelConcepto As System.Windows.Forms.Label
    Friend WithEvents LabelImporte As System.Windows.Forms.Label
    Friend WithEvents ComboBoxMes As System.Windows.Forms.ComboBox
    Friend WithEvents CurrencyTextBoxImporte As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents TextBoxAnio As TextBox
    Friend WithEvents ComboBoxConcepto As ComboBox
End Class
