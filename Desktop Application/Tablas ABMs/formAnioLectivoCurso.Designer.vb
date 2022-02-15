<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAnioLectivoCurso
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
        Me.labelAnioLectivo = New System.Windows.Forms.Label()
        Me.labelCurso = New System.Windows.Forms.Label()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.textboxIDAnioLectivoCurso = New System.Windows.Forms.TextBox()
        Me.labelIDAnioLectivoCurso = New System.Windows.Forms.Label()
        Me.comboboxCurso = New System.Windows.Forms.ComboBox()
        Me.comboboxAnioLectivo = New System.Windows.Forms.ComboBox()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelAnioLectivo
        '
        Me.labelAnioLectivo.AutoSize = True
        Me.labelAnioLectivo.Location = New System.Drawing.Point(12, 79)
        Me.labelAnioLectivo.Name = "labelAnioLectivo"
        Me.labelAnioLectivo.Size = New System.Drawing.Size(67, 13)
        Me.labelAnioLectivo.TabIndex = 2
        Me.labelAnioLectivo.Text = "Año Lectivo:"
        '
        'labelCurso
        '
        Me.labelCurso.AutoSize = True
        Me.labelCurso.Location = New System.Drawing.Point(12, 106)
        Me.labelCurso.Name = "labelCurso"
        Me.labelCurso.Size = New System.Drawing.Size(37, 13)
        Me.labelCurso.TabIndex = 4
        Me.labelCurso.Text = "Curso:"
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
        Me.toolstripMain.Size = New System.Drawing.Size(409, 39)
        Me.toolstripMain.TabIndex = 10
        '
        'textboxIDAnioLectivoCurso
        '
        Me.textboxIDAnioLectivoCurso.Location = New System.Drawing.Point(92, 50)
        Me.textboxIDAnioLectivoCurso.MaxLength = 10
        Me.textboxIDAnioLectivoCurso.Name = "textboxIDAnioLectivoCurso"
        Me.textboxIDAnioLectivoCurso.ReadOnly = True
        Me.textboxIDAnioLectivoCurso.Size = New System.Drawing.Size(74, 20)
        Me.textboxIDAnioLectivoCurso.TabIndex = 1
        Me.textboxIDAnioLectivoCurso.TabStop = False
        Me.textboxIDAnioLectivoCurso.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'labelIDAnioLectivoCurso
        '
        Me.labelIDAnioLectivoCurso.AutoSize = True
        Me.labelIDAnioLectivoCurso.Location = New System.Drawing.Point(12, 53)
        Me.labelIDAnioLectivoCurso.Name = "labelIDAnioLectivoCurso"
        Me.labelIDAnioLectivoCurso.Size = New System.Drawing.Size(21, 13)
        Me.labelIDAnioLectivoCurso.TabIndex = 0
        Me.labelIDAnioLectivoCurso.Text = "ID:"
        '
        'comboboxCurso
        '
        Me.comboboxCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCurso.FormattingEnabled = True
        Me.comboboxCurso.Location = New System.Drawing.Point(92, 103)
        Me.comboboxCurso.Name = "comboboxCurso"
        Me.comboboxCurso.Size = New System.Drawing.Size(300, 21)
        Me.comboboxCurso.TabIndex = 5
        '
        'comboboxAnioLectivo
        '
        Me.comboboxAnioLectivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnioLectivo.FormattingEnabled = True
        Me.comboboxAnioLectivo.Location = New System.Drawing.Point(92, 76)
        Me.comboboxAnioLectivo.Name = "comboboxAnioLectivo"
        Me.comboboxAnioLectivo.Size = New System.Drawing.Size(59, 21)
        Me.comboboxAnioLectivo.TabIndex = 3
        '
        'formAnioLectivoCurso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(409, 138)
        Me.Controls.Add(Me.comboboxCurso)
        Me.Controls.Add(Me.textboxIDAnioLectivoCurso)
        Me.Controls.Add(Me.labelIDAnioLectivoCurso)
        Me.Controls.Add(Me.comboboxAnioLectivo)
        Me.Controls.Add(Me.labelAnioLectivo)
        Me.Controls.Add(Me.labelCurso)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formAnioLectivoCurso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Curso de Año Lectivo"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelAnioLectivo As System.Windows.Forms.Label
    Friend WithEvents labelCurso As System.Windows.Forms.Label
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents textboxIDAnioLectivoCurso As System.Windows.Forms.TextBox
    Friend WithEvents labelIDAnioLectivoCurso As System.Windows.Forms.Label
    Friend WithEvents comboboxCurso As System.Windows.Forms.ComboBox
    Friend WithEvents comboboxAnioLectivo As System.Windows.Forms.ComboBox
End Class
