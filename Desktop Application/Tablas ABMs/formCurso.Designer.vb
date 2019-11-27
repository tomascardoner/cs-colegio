<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formCurso
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
        Me.comboboxAnio = New System.Windows.Forms.ComboBox()
        Me.labelAnio = New System.Windows.Forms.Label()
        Me.textboxDivision = New System.Windows.Forms.TextBox()
        Me.labelTurno = New System.Windows.Forms.Label()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.textboxIDCurso = New System.Windows.Forms.TextBox()
        Me.labelIDCurso = New System.Windows.Forms.Label()
        Me.comboboxTurno = New System.Windows.Forms.ComboBox()
        Me.labelDivision = New System.Windows.Forms.Label()
        Me.checkboxEsActivo = New System.Windows.Forms.CheckBox()
        Me.comboboxCuotaTipo = New System.Windows.Forms.ComboBox()
        Me.labelCuotaTipo = New System.Windows.Forms.Label()
        labelEsActivo = New System.Windows.Forms.Label()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelEsActivo
        '
        labelEsActivo.AutoSize = True
        labelEsActivo.Location = New System.Drawing.Point(12, 184)
        labelEsActivo.Name = "labelEsActivo"
        labelEsActivo.Size = New System.Drawing.Size(40, 13)
        labelEsActivo.TabIndex = 10
        labelEsActivo.Text = "Activo:"
        '
        'comboboxAnio
        '
        Me.comboboxAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnio.FormattingEnabled = True
        Me.comboboxAnio.Location = New System.Drawing.Point(95, 76)
        Me.comboboxAnio.Name = "comboboxAnio"
        Me.comboboxAnio.Size = New System.Drawing.Size(266, 21)
        Me.comboboxAnio.TabIndex = 3
        '
        'labelAnio
        '
        Me.labelAnio.AutoSize = True
        Me.labelAnio.Location = New System.Drawing.Point(12, 79)
        Me.labelAnio.Name = "labelAnio"
        Me.labelAnio.Size = New System.Drawing.Size(29, 13)
        Me.labelAnio.TabIndex = 2
        Me.labelAnio.Text = "Año:"
        '
        'textboxDivision
        '
        Me.textboxDivision.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textboxDivision.Location = New System.Drawing.Point(95, 129)
        Me.textboxDivision.MaxLength = 1
        Me.textboxDivision.Name = "textboxDivision"
        Me.textboxDivision.Size = New System.Drawing.Size(23, 20)
        Me.textboxDivision.TabIndex = 7
        '
        'labelTurno
        '
        Me.labelTurno.AutoSize = True
        Me.labelTurno.Location = New System.Drawing.Point(12, 106)
        Me.labelTurno.Name = "labelTurno"
        Me.labelTurno.Size = New System.Drawing.Size(38, 13)
        Me.labelTurno.TabIndex = 4
        Me.labelTurno.Text = "Turno:"
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
        Me.toolstripMain.Size = New System.Drawing.Size(371, 39)
        Me.toolstripMain.TabIndex = 12
        '
        'textboxIDCurso
        '
        Me.textboxIDCurso.Location = New System.Drawing.Point(95, 50)
        Me.textboxIDCurso.MaxLength = 10
        Me.textboxIDCurso.Name = "textboxIDCurso"
        Me.textboxIDCurso.ReadOnly = True
        Me.textboxIDCurso.Size = New System.Drawing.Size(74, 20)
        Me.textboxIDCurso.TabIndex = 1
        Me.textboxIDCurso.TabStop = False
        Me.textboxIDCurso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'labelIDCurso
        '
        Me.labelIDCurso.AutoSize = True
        Me.labelIDCurso.Location = New System.Drawing.Point(12, 53)
        Me.labelIDCurso.Name = "labelIDCurso"
        Me.labelIDCurso.Size = New System.Drawing.Size(21, 13)
        Me.labelIDCurso.TabIndex = 0
        Me.labelIDCurso.Text = "ID:"
        '
        'comboboxTurno
        '
        Me.comboboxTurno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxTurno.FormattingEnabled = True
        Me.comboboxTurno.Location = New System.Drawing.Point(95, 103)
        Me.comboboxTurno.Name = "comboboxTurno"
        Me.comboboxTurno.Size = New System.Drawing.Size(266, 21)
        Me.comboboxTurno.TabIndex = 5
        '
        'labelDivision
        '
        Me.labelDivision.AutoSize = True
        Me.labelDivision.Location = New System.Drawing.Point(12, 132)
        Me.labelDivision.Name = "labelDivision"
        Me.labelDivision.Size = New System.Drawing.Size(47, 13)
        Me.labelDivision.TabIndex = 6
        Me.labelDivision.Text = "División:"
        '
        'checkboxEsActivo
        '
        Me.checkboxEsActivo.AutoSize = True
        Me.checkboxEsActivo.Location = New System.Drawing.Point(95, 184)
        Me.checkboxEsActivo.Name = "checkboxEsActivo"
        Me.checkboxEsActivo.Size = New System.Drawing.Size(15, 14)
        Me.checkboxEsActivo.TabIndex = 11
        Me.checkboxEsActivo.UseVisualStyleBackColor = True
        '
        'comboboxCuotaTipo
        '
        Me.comboboxCuotaTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCuotaTipo.FormattingEnabled = True
        Me.comboboxCuotaTipo.Location = New System.Drawing.Point(95, 155)
        Me.comboboxCuotaTipo.Name = "comboboxCuotaTipo"
        Me.comboboxCuotaTipo.Size = New System.Drawing.Size(266, 21)
        Me.comboboxCuotaTipo.TabIndex = 9
        '
        'labelCuotaTipo
        '
        Me.labelCuotaTipo.AutoSize = True
        Me.labelCuotaTipo.Location = New System.Drawing.Point(12, 158)
        Me.labelCuotaTipo.Name = "labelCuotaTipo"
        Me.labelCuotaTipo.Size = New System.Drawing.Size(77, 13)
        Me.labelCuotaTipo.TabIndex = 8
        Me.labelCuotaTipo.Text = "Tipo de Cuota:"
        '
        'formCurso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 211)
        Me.Controls.Add(Me.comboboxCuotaTipo)
        Me.Controls.Add(Me.labelCuotaTipo)
        Me.Controls.Add(labelEsActivo)
        Me.Controls.Add(Me.comboboxTurno)
        Me.Controls.Add(Me.labelDivision)
        Me.Controls.Add(Me.textboxIDCurso)
        Me.Controls.Add(Me.labelIDCurso)
        Me.Controls.Add(Me.comboboxAnio)
        Me.Controls.Add(Me.labelAnio)
        Me.Controls.Add(Me.textboxDivision)
        Me.Controls.Add(Me.labelTurno)
        Me.Controls.Add(Me.checkboxEsActivo)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formCurso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Curso"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents comboboxAnio As System.Windows.Forms.ComboBox
    Friend WithEvents labelAnio As System.Windows.Forms.Label
    Friend WithEvents textboxDivision As System.Windows.Forms.TextBox
    Friend WithEvents labelTurno As System.Windows.Forms.Label
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents textboxIDCurso As System.Windows.Forms.TextBox
    Friend WithEvents labelIDCurso As System.Windows.Forms.Label
    Friend WithEvents comboboxTurno As System.Windows.Forms.ComboBox
    Friend WithEvents labelDivision As System.Windows.Forms.Label
    Friend WithEvents checkboxEsActivo As System.Windows.Forms.CheckBox
    Friend WithEvents comboboxCuotaTipo As ComboBox
    Friend WithEvents labelCuotaTipo As Label
End Class
