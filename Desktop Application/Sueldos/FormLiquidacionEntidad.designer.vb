<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLiquidacionEntidad
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
        Me.LabelLiquidacion = New System.Windows.Forms.Label()
        Me.ToolStripButtonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.LabelEntidad = New System.Windows.Forms.Label()
        Me.LabelModuloCantidad = New System.Windows.Forms.Label()
        Me.LabelAntiguedad = New System.Windows.Forms.Label()
        Me.ComboBoxEntidad = New System.Windows.Forms.ComboBox()
        Me.ButtonObtenerDatos = New System.Windows.Forms.Button()
        Me.TextBoxLiquidacion = New System.Windows.Forms.TextBox()
        Me.DoubleTextBoxModuloCantidad = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.IntegerTextBoxAntiguedad = New Syncfusion.Windows.Forms.Tools.IntegerTextBox()
        Me.LabelAntiguedadPorcentaje = New System.Windows.Forms.Label()
        Me.toolstripMain.SuspendLayout()
        CType(Me.DoubleTextBoxModuloCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerTextBoxAntiguedad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelLiquidacion
        '
        Me.LabelLiquidacion.AutoSize = True
        Me.LabelLiquidacion.Location = New System.Drawing.Point(13, 74)
        Me.LabelLiquidacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelLiquidacion.Name = "LabelLiquidacion"
        Me.LabelLiquidacion.Size = New System.Drawing.Size(79, 16)
        Me.LabelLiquidacion.TabIndex = 8
        Me.LabelLiquidacion.Text = "Liquidación:"
        '
        'ToolStripButtonGuardar
        '
        Me.ToolStripButtonGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonGuardar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageAceptar32
        Me.ToolStripButtonGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonGuardar.Name = "ToolStripButtonGuardar"
        Me.ToolStripButtonGuardar.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButtonGuardar.Text = "Guardar"
        '
        'ToolStripButtonCancelar
        '
        Me.ToolStripButtonCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonCancelar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageCancelar32
        Me.ToolStripButtonCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCancelar.Name = "ToolStripButtonCancelar"
        Me.ToolStripButtonCancelar.Size = New System.Drawing.Size(102, 36)
        Me.ToolStripButtonCancelar.Text = "Cancelar"
        '
        'ToolStripButtonEditar
        '
        Me.ToolStripButtonEditar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonEditar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_EDIT_32
        Me.ToolStripButtonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonEditar.Name = "ToolStripButtonEditar"
        Me.ToolStripButtonEditar.Size = New System.Drawing.Size(84, 36)
        Me.ToolStripButtonEditar.Text = "Editar"
        '
        'ToolStripButtonCerrar
        '
        Me.ToolStripButtonCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonCerrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_32
        Me.ToolStripButtonCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCerrar.Name = "ToolStripButtonCerrar"
        Me.ToolStripButtonCerrar.Size = New System.Drawing.Size(85, 36)
        Me.ToolStripButtonCerrar.Text = "Cerrar"
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonCerrar, Me.ToolStripButtonEditar, Me.ToolStripButtonCancelar, Me.ToolStripButtonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(386, 39)
        Me.toolstripMain.TabIndex = 7
        '
        'LabelEntidad
        '
        Me.LabelEntidad.AutoSize = True
        Me.LabelEntidad.Location = New System.Drawing.Point(13, 106)
        Me.LabelEntidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelEntidad.Name = "LabelEntidad"
        Me.LabelEntidad.Size = New System.Drawing.Size(56, 16)
        Me.LabelEntidad.TabIndex = 0
        Me.LabelEntidad.Text = "Entidad:"
        '
        'LabelModuloCantidad
        '
        Me.LabelModuloCantidad.AutoSize = True
        Me.LabelModuloCantidad.Location = New System.Drawing.Point(13, 138)
        Me.LabelModuloCantidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelModuloCantidad.Name = "LabelModuloCantidad"
        Me.LabelModuloCantidad.Size = New System.Drawing.Size(62, 16)
        Me.LabelModuloCantidad.TabIndex = 2
        Me.LabelModuloCantidad.Text = "Módulos:"
        '
        'LabelAntiguedad
        '
        Me.LabelAntiguedad.AutoSize = True
        Me.LabelAntiguedad.Location = New System.Drawing.Point(13, 166)
        Me.LabelAntiguedad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelAntiguedad.Name = "LabelAntiguedad"
        Me.LabelAntiguedad.Size = New System.Drawing.Size(76, 16)
        Me.LabelAntiguedad.TabIndex = 4
        Me.LabelAntiguedad.Text = "Antigüedad"
        '
        'ComboBoxEntidad
        '
        Me.ComboBoxEntidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEntidad.FormattingEnabled = True
        Me.ComboBoxEntidad.Location = New System.Drawing.Point(100, 103)
        Me.ComboBoxEntidad.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxEntidad.Name = "ComboBoxEntidad"
        Me.ComboBoxEntidad.Size = New System.Drawing.Size(273, 24)
        Me.ComboBoxEntidad.TabIndex = 1
        '
        'ButtonObtenerDatos
        '
        Me.ButtonObtenerDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonObtenerDatos.Location = New System.Drawing.Point(170, 135)
        Me.ButtonObtenerDatos.Name = "ButtonObtenerDatos"
        Me.ButtonObtenerDatos.Size = New System.Drawing.Size(203, 54)
        Me.ButtonObtenerDatos.TabIndex = 6
        Me.ButtonObtenerDatos.Text = "Obtener desde liquidación anterior"
        Me.ButtonObtenerDatos.UseVisualStyleBackColor = True
        '
        'TextBoxLiquidacion
        '
        Me.TextBoxLiquidacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxLiquidacion.Location = New System.Drawing.Point(100, 71)
        Me.TextBoxLiquidacion.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxLiquidacion.Name = "TextBoxLiquidacion"
        Me.TextBoxLiquidacion.ReadOnly = True
        Me.TextBoxLiquidacion.Size = New System.Drawing.Size(273, 22)
        Me.TextBoxLiquidacion.TabIndex = 9
        Me.TextBoxLiquidacion.TabStop = False
        Me.TextBoxLiquidacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DoubleTextBoxModuloCantidad
        '
        Me.DoubleTextBoxModuloCantidad.AccessibilityEnabled = True
        Me.DoubleTextBoxModuloCantidad.AllowNull = True
        Me.DoubleTextBoxModuloCantidad.BeforeTouchSize = New System.Drawing.Size(40, 22)
        Me.DoubleTextBoxModuloCantidad.DoubleValue = 0R
        Me.DoubleTextBoxModuloCantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DoubleTextBoxModuloCantidad.Location = New System.Drawing.Point(100, 135)
        Me.DoubleTextBoxModuloCantidad.MaxValue = 99.9R
        Me.DoubleTextBoxModuloCantidad.MinValue = 0R
        Me.DoubleTextBoxModuloCantidad.Name = "DoubleTextBoxModuloCantidad"
        Me.DoubleTextBoxModuloCantidad.NumberDecimalDigits = 1
        Me.DoubleTextBoxModuloCantidad.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.DoubleTextBoxModuloCantidad.Size = New System.Drawing.Size(40, 22)
        Me.DoubleTextBoxModuloCantidad.TabIndex = 3
        Me.DoubleTextBoxModuloCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'IntegerTextBoxAntiguedad
        '
        Me.IntegerTextBoxAntiguedad.AccessibilityEnabled = True
        Me.IntegerTextBoxAntiguedad.AllowNull = True
        Me.IntegerTextBoxAntiguedad.BeforeTouchSize = New System.Drawing.Size(40, 22)
        Me.IntegerTextBoxAntiguedad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.IntegerTextBoxAntiguedad.IntegerValue = CType(0, Long)
        Me.IntegerTextBoxAntiguedad.Location = New System.Drawing.Point(100, 163)
        Me.IntegerTextBoxAntiguedad.MaxValue = CType(125, Long)
        Me.IntegerTextBoxAntiguedad.MinValue = CType(1, Long)
        Me.IntegerTextBoxAntiguedad.Name = "IntegerTextBoxAntiguedad"
        Me.IntegerTextBoxAntiguedad.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.IntegerTextBoxAntiguedad.Size = New System.Drawing.Size(40, 22)
        Me.IntegerTextBoxAntiguedad.TabIndex = 5
        Me.IntegerTextBoxAntiguedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelAntiguedadPorcentaje
        '
        Me.LabelAntiguedadPorcentaje.AutoSize = True
        Me.LabelAntiguedadPorcentaje.Location = New System.Drawing.Point(144, 166)
        Me.LabelAntiguedadPorcentaje.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelAntiguedadPorcentaje.Name = "LabelAntiguedadPorcentaje"
        Me.LabelAntiguedadPorcentaje.Size = New System.Drawing.Size(19, 16)
        Me.LabelAntiguedadPorcentaje.TabIndex = 10
        Me.LabelAntiguedadPorcentaje.Text = "%"
        '
        'FormLiquidacionEntidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(386, 200)
        Me.Controls.Add(Me.LabelAntiguedadPorcentaje)
        Me.Controls.Add(Me.IntegerTextBoxAntiguedad)
        Me.Controls.Add(Me.DoubleTextBoxModuloCantidad)
        Me.Controls.Add(Me.TextBoxLiquidacion)
        Me.Controls.Add(Me.ButtonObtenerDatos)
        Me.Controls.Add(Me.ComboBoxEntidad)
        Me.Controls.Add(Me.LabelAntiguedad)
        Me.Controls.Add(Me.LabelModuloCantidad)
        Me.Controls.Add(Me.LabelEntidad)
        Me.Controls.Add(Me.LabelLiquidacion)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormLiquidacionEntidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liquidación de sueldo de entidad"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        CType(Me.DoubleTextBoxModuloCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerTextBoxAntiguedad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelLiquidacion As System.Windows.Forms.Label
    Friend WithEvents ToolStripButtonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents LabelEntidad As System.Windows.Forms.Label
    Friend WithEvents LabelModuloCantidad As System.Windows.Forms.Label
    Friend WithEvents LabelAntiguedad As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEntidad As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonObtenerDatos As Button
    Friend WithEvents TextBoxLiquidacion As TextBox
    Friend WithEvents DoubleTextBoxModuloCantidad As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents IntegerTextBoxAntiguedad As Syncfusion.Windows.Forms.Tools.IntegerTextBox
    Friend WithEvents LabelAntiguedadPorcentaje As Label
End Class
