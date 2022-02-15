<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAnio
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
        Dim labelEsActivo As System.Windows.Forms.Label
        Me.comboboxNivel = New System.Windows.Forms.ComboBox()
        Me.labelNivel = New System.Windows.Forms.Label()
        Me.textboxNombre = New System.Windows.Forms.TextBox()
        Me.labelNombre = New System.Windows.Forms.Label()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.textboxIDAnio = New System.Windows.Forms.TextBox()
        Me.labelIDAnio = New System.Windows.Forms.Label()
        Me.comboboxAnioSiguiente = New System.Windows.Forms.ComboBox()
        Me.labelAnioSiguiente = New System.Windows.Forms.Label()
        Me.checkboxEsActivo = New System.Windows.Forms.CheckBox()
        labelEsActivo = New System.Windows.Forms.Label()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelEsActivo
        '
        labelEsActivo.AutoSize = True
        labelEsActivo.Location = New System.Drawing.Point(12, 159)
        labelEsActivo.Name = "labelEsActivo"
        labelEsActivo.Size = New System.Drawing.Size(40, 13)
        labelEsActivo.TabIndex = 8
        labelEsActivo.Text = "Activo:"
        '
        'comboboxNivel
        '
        Me.comboboxNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxNivel.FormattingEnabled = True
        Me.comboboxNivel.Location = New System.Drawing.Point(92, 76)
        Me.comboboxNivel.Name = "comboboxNivel"
        Me.comboboxNivel.Size = New System.Drawing.Size(266, 21)
        Me.comboboxNivel.TabIndex = 3
        '
        'labelNivel
        '
        Me.labelNivel.AutoSize = True
        Me.labelNivel.Location = New System.Drawing.Point(12, 79)
        Me.labelNivel.Name = "labelNivel"
        Me.labelNivel.Size = New System.Drawing.Size(34, 13)
        Me.labelNivel.TabIndex = 2
        Me.labelNivel.Text = "Nivel:"
        '
        'textboxNombre
        '
        Me.textboxNombre.Location = New System.Drawing.Point(92, 103)
        Me.textboxNombre.MaxLength = 50
        Me.textboxNombre.Name = "textboxNombre"
        Me.textboxNombre.Size = New System.Drawing.Size(266, 20)
        Me.textboxNombre.TabIndex = 5
        '
        'labelNombre
        '
        Me.labelNombre.AutoSize = True
        Me.labelNombre.Location = New System.Drawing.Point(12, 106)
        Me.labelNombre.Name = "labelNombre"
        Me.labelNombre.Size = New System.Drawing.Size(47, 13)
        Me.labelNombre.TabIndex = 4
        Me.labelNombre.Text = "Nombre:"
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
        Me.toolstripMain.Size = New System.Drawing.Size(371, 39)
        Me.toolstripMain.TabIndex = 10
        '
        'textboxIDAnio
        '
        Me.textboxIDAnio.Location = New System.Drawing.Point(92, 50)
        Me.textboxIDAnio.MaxLength = 10
        Me.textboxIDAnio.Name = "textboxIDAnio"
        Me.textboxIDAnio.ReadOnly = True
        Me.textboxIDAnio.Size = New System.Drawing.Size(74, 20)
        Me.textboxIDAnio.TabIndex = 1
        Me.textboxIDAnio.TabStop = False
        Me.textboxIDAnio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'labelIDAnio
        '
        Me.labelIDAnio.AutoSize = True
        Me.labelIDAnio.Location = New System.Drawing.Point(12, 53)
        Me.labelIDAnio.Name = "labelIDAnio"
        Me.labelIDAnio.Size = New System.Drawing.Size(21, 13)
        Me.labelIDAnio.TabIndex = 0
        Me.labelIDAnio.Text = "ID:"
        '
        'comboboxAnioSiguiente
        '
        Me.comboboxAnioSiguiente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnioSiguiente.FormattingEnabled = True
        Me.comboboxAnioSiguiente.Location = New System.Drawing.Point(92, 129)
        Me.comboboxAnioSiguiente.Name = "comboboxAnioSiguiente"
        Me.comboboxAnioSiguiente.Size = New System.Drawing.Size(266, 21)
        Me.comboboxAnioSiguiente.TabIndex = 7
        '
        'labelAnioSiguiente
        '
        Me.labelAnioSiguiente.AutoSize = True
        Me.labelAnioSiguiente.Location = New System.Drawing.Point(12, 132)
        Me.labelAnioSiguiente.Name = "labelAnioSiguiente"
        Me.labelAnioSiguiente.Size = New System.Drawing.Size(74, 13)
        Me.labelAnioSiguiente.TabIndex = 6
        Me.labelAnioSiguiente.Text = "Año siguiente:"
        '
        'checkboxEsActivo
        '
        Me.checkboxEsActivo.AutoSize = True
        Me.checkboxEsActivo.Location = New System.Drawing.Point(92, 159)
        Me.checkboxEsActivo.Name = "checkboxEsActivo"
        Me.checkboxEsActivo.Size = New System.Drawing.Size(15, 14)
        Me.checkboxEsActivo.TabIndex = 9
        Me.checkboxEsActivo.UseVisualStyleBackColor = True
        '
        'formAnio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 192)
        Me.Controls.Add(Me.checkboxEsActivo)
        Me.Controls.Add(labelEsActivo)
        Me.Controls.Add(Me.comboboxAnioSiguiente)
        Me.Controls.Add(Me.labelAnioSiguiente)
        Me.Controls.Add(Me.textboxIDAnio)
        Me.Controls.Add(Me.labelIDAnio)
        Me.Controls.Add(Me.comboboxNivel)
        Me.Controls.Add(Me.labelNivel)
        Me.Controls.Add(Me.textboxNombre)
        Me.Controls.Add(Me.labelNombre)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formAnio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Año"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents comboboxNivel As System.Windows.Forms.ComboBox
    Friend WithEvents labelNivel As System.Windows.Forms.Label
    Friend WithEvents textboxNombre As System.Windows.Forms.TextBox
    Friend WithEvents labelNombre As System.Windows.Forms.Label
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents textboxIDAnio As System.Windows.Forms.TextBox
    Friend WithEvents labelIDAnio As System.Windows.Forms.Label
    Friend WithEvents comboboxAnioSiguiente As System.Windows.Forms.ComboBox
    Friend WithEvents labelAnioSiguiente As System.Windows.Forms.Label
    Friend WithEvents checkboxEsActivo As System.Windows.Forms.CheckBox
End Class
