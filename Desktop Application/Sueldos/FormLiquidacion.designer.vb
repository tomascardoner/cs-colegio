<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLiquidacion
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
        Me.LabelBaseAntiguedadImporte = New System.Windows.Forms.Label()
        Me.LabelModuloImporte = New System.Windows.Forms.Label()
        Me.ComboBoxMes = New System.Windows.Forms.ComboBox()
        Me.CurrencyTextBoxBaseAntiguedadImporte = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.CurrencyTextBoxModuloImporte = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.ButtonObtenerImportes = New System.Windows.Forms.Button()
        Me.TextBoxAnio = New System.Windows.Forms.TextBox()
        Me.toolstripMain.SuspendLayout()
        CType(Me.CurrencyTextBoxBaseAntiguedadImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBoxModuloImporte, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelAnio
        '
        Me.LabelAnio.AutoSize = True
        Me.LabelAnio.Location = New System.Drawing.Point(13, 74)
        Me.LabelAnio.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelAnio.Name = "LabelAnio"
        Me.LabelAnio.Size = New System.Drawing.Size(34, 16)
        Me.LabelAnio.TabIndex = 8
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
        Me.toolstripMain.Size = New System.Drawing.Size(447, 39)
        Me.toolstripMain.TabIndex = 7
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
        'LabelBaseAntiguedadImporte
        '
        Me.LabelBaseAntiguedadImporte.AutoSize = True
        Me.LabelBaseAntiguedadImporte.Location = New System.Drawing.Point(13, 138)
        Me.LabelBaseAntiguedadImporte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelBaseAntiguedadImporte.Name = "LabelBaseAntiguedadImporte"
        Me.LabelBaseAntiguedadImporte.Size = New System.Drawing.Size(160, 16)
        Me.LabelBaseAntiguedadImporte.TabIndex = 2
        Me.LabelBaseAntiguedadImporte.Text = "Importe base antigüedad:"
        '
        'LabelModuloImporte
        '
        Me.LabelModuloImporte.AutoSize = True
        Me.LabelModuloImporte.Location = New System.Drawing.Point(13, 170)
        Me.LabelModuloImporte.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelModuloImporte.Name = "LabelModuloImporte"
        Me.LabelModuloImporte.Size = New System.Drawing.Size(125, 16)
        Me.LabelModuloImporte.TabIndex = 4
        Me.LabelModuloImporte.Text = "Importe del módulo:"
        '
        'ComboBoxMes
        '
        Me.ComboBoxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxMes.FormattingEnabled = True
        Me.ComboBoxMes.Location = New System.Drawing.Point(188, 103)
        Me.ComboBoxMes.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxMes.Name = "ComboBoxMes"
        Me.ComboBoxMes.Size = New System.Drawing.Size(111, 24)
        Me.ComboBoxMes.TabIndex = 1
        '
        'CurrencyTextBoxBaseAntiguedadImporte
        '
        Me.CurrencyTextBoxBaseAntiguedadImporte.AccessibilityEnabled = True
        Me.CurrencyTextBoxBaseAntiguedadImporte.AllowNull = True
        Me.CurrencyTextBoxBaseAntiguedadImporte.BeforeTouchSize = New System.Drawing.Size(111, 22)
        Me.CurrencyTextBoxBaseAntiguedadImporte.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.CurrencyTextBoxBaseAntiguedadImporte.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CurrencyTextBoxBaseAntiguedadImporte.Location = New System.Drawing.Point(188, 135)
        Me.CurrencyTextBoxBaseAntiguedadImporte.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrencyTextBoxBaseAntiguedadImporte.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.CurrencyTextBoxBaseAntiguedadImporte.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.CurrencyTextBoxBaseAntiguedadImporte.Name = "CurrencyTextBoxBaseAntiguedadImporte"
        Me.CurrencyTextBoxBaseAntiguedadImporte.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.CurrencyTextBoxBaseAntiguedadImporte.Size = New System.Drawing.Size(111, 22)
        Me.CurrencyTextBoxBaseAntiguedadImporte.TabIndex = 3
        Me.CurrencyTextBoxBaseAntiguedadImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CurrencyTextBoxModuloImporte
        '
        Me.CurrencyTextBoxModuloImporte.AccessibilityEnabled = True
        Me.CurrencyTextBoxModuloImporte.AllowNull = True
        Me.CurrencyTextBoxModuloImporte.BeforeTouchSize = New System.Drawing.Size(111, 22)
        Me.CurrencyTextBoxModuloImporte.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.CurrencyTextBoxModuloImporte.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CurrencyTextBoxModuloImporte.Location = New System.Drawing.Point(188, 167)
        Me.CurrencyTextBoxModuloImporte.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrencyTextBoxModuloImporte.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.CurrencyTextBoxModuloImporte.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.CurrencyTextBoxModuloImporte.Name = "CurrencyTextBoxModuloImporte"
        Me.CurrencyTextBoxModuloImporte.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.CurrencyTextBoxModuloImporte.Size = New System.Drawing.Size(111, 22)
        Me.CurrencyTextBoxModuloImporte.TabIndex = 5
        Me.CurrencyTextBoxModuloImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ButtonObtenerImportes
        '
        Me.ButtonObtenerImportes.Location = New System.Drawing.Point(306, 135)
        Me.ButtonObtenerImportes.Name = "ButtonObtenerImportes"
        Me.ButtonObtenerImportes.Size = New System.Drawing.Size(129, 54)
        Me.ButtonObtenerImportes.TabIndex = 6
        Me.ButtonObtenerImportes.Text = "Obtener desde cálculos"
        Me.ButtonObtenerImportes.UseVisualStyleBackColor = True
        '
        'TextBoxAnio
        '
        Me.TextBoxAnio.Location = New System.Drawing.Point(188, 71)
        Me.TextBoxAnio.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxAnio.Name = "TextBoxAnio"
        Me.TextBoxAnio.ReadOnly = True
        Me.TextBoxAnio.Size = New System.Drawing.Size(65, 22)
        Me.TextBoxAnio.TabIndex = 9
        Me.TextBoxAnio.TabStop = False
        Me.TextBoxAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'FormLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 200)
        Me.Controls.Add(Me.TextBoxAnio)
        Me.Controls.Add(Me.ButtonObtenerImportes)
        Me.Controls.Add(Me.CurrencyTextBoxModuloImporte)
        Me.Controls.Add(Me.CurrencyTextBoxBaseAntiguedadImporte)
        Me.Controls.Add(Me.ComboBoxMes)
        Me.Controls.Add(Me.LabelModuloImporte)
        Me.Controls.Add(Me.LabelBaseAntiguedadImporte)
        Me.Controls.Add(Me.LabelMes)
        Me.Controls.Add(Me.LabelAnio)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormLiquidacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liquidación de sueldo"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        CType(Me.CurrencyTextBoxBaseAntiguedadImporte, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBoxModuloImporte, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LabelBaseAntiguedadImporte As System.Windows.Forms.Label
    Friend WithEvents LabelModuloImporte As System.Windows.Forms.Label
    Friend WithEvents ComboBoxMes As System.Windows.Forms.ComboBox
    Friend WithEvents CurrencyTextBoxBaseAntiguedadImporte As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents CurrencyTextBoxModuloImporte As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents ButtonObtenerImportes As Button
    Friend WithEvents TextBoxAnio As TextBox
End Class
