<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formComprobanteDetalle
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
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.labelArticulo = New System.Windows.Forms.Label()
        Me.comboboxArticulo = New System.Windows.Forms.ComboBox()
        Me.buttonEntidad = New System.Windows.Forms.Button()
        Me.textboxEntidad = New System.Windows.Forms.TextBox()
        Me.labelEntidad = New System.Windows.Forms.Label()
        Me.comboboxAnioLectivoCurso = New System.Windows.Forms.ComboBox()
        Me.labelAnioLectivoCurso = New System.Windows.Forms.Label()
        Me.comboboxCuotaMes = New System.Windows.Forms.ComboBox()
        Me.labelCuotaMes = New System.Windows.Forms.Label()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(476, 39)
        Me.toolstripMain.TabIndex = 18
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
        'labelArticulo
        '
        Me.labelArticulo.AutoSize = True
        Me.labelArticulo.Location = New System.Drawing.Point(12, 54)
        Me.labelArticulo.Name = "labelArticulo"
        Me.labelArticulo.Size = New System.Drawing.Size(47, 13)
        Me.labelArticulo.TabIndex = 19
        Me.labelArticulo.Text = "Artículo:"
        '
        'comboboxArticulo
        '
        Me.comboboxArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxArticulo.FormattingEnabled = True
        Me.comboboxArticulo.Location = New System.Drawing.Point(123, 51)
        Me.comboboxArticulo.Name = "comboboxArticulo"
        Me.comboboxArticulo.Size = New System.Drawing.Size(339, 21)
        Me.comboboxArticulo.TabIndex = 20
        '
        'buttonEntidad
        '
        Me.buttonEntidad.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonEntidad.Location = New System.Drawing.Point(440, 77)
        Me.buttonEntidad.Name = "buttonEntidad"
        Me.buttonEntidad.Size = New System.Drawing.Size(22, 22)
        Me.buttonEntidad.TabIndex = 24
        Me.buttonEntidad.Text = "…"
        Me.buttonEntidad.UseVisualStyleBackColor = True
        '
        'textboxEntidad
        '
        Me.textboxEntidad.Location = New System.Drawing.Point(123, 78)
        Me.textboxEntidad.MaxLength = 150
        Me.textboxEntidad.Name = "textboxEntidad"
        Me.textboxEntidad.ReadOnly = True
        Me.textboxEntidad.Size = New System.Drawing.Size(317, 20)
        Me.textboxEntidad.TabIndex = 23
        '
        'labelEntidad
        '
        Me.labelEntidad.AutoSize = True
        Me.labelEntidad.Location = New System.Drawing.Point(12, 81)
        Me.labelEntidad.Name = "labelEntidad"
        Me.labelEntidad.Size = New System.Drawing.Size(46, 13)
        Me.labelEntidad.TabIndex = 22
        Me.labelEntidad.Text = "Entidad:"
        '
        'comboboxAnioLectivoCurso
        '
        Me.comboboxAnioLectivoCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnioLectivoCurso.FormattingEnabled = True
        Me.comboboxAnioLectivoCurso.Location = New System.Drawing.Point(123, 105)
        Me.comboboxAnioLectivoCurso.Name = "comboboxAnioLectivoCurso"
        Me.comboboxAnioLectivoCurso.Size = New System.Drawing.Size(339, 21)
        Me.comboboxAnioLectivoCurso.TabIndex = 26
        '
        'labelAnioLectivoCurso
        '
        Me.labelAnioLectivoCurso.AutoSize = True
        Me.labelAnioLectivoCurso.Location = New System.Drawing.Point(12, 108)
        Me.labelAnioLectivoCurso.Name = "labelAnioLectivoCurso"
        Me.labelAnioLectivoCurso.Size = New System.Drawing.Size(105, 13)
        Me.labelAnioLectivoCurso.TabIndex = 25
        Me.labelAnioLectivoCurso.Text = "Año Lectivo y Curso:"
        '
        'comboboxCuotaMes
        '
        Me.comboboxCuotaMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCuotaMes.FormattingEnabled = True
        Me.comboboxCuotaMes.Location = New System.Drawing.Point(123, 132)
        Me.comboboxCuotaMes.Name = "comboboxCuotaMes"
        Me.comboboxCuotaMes.Size = New System.Drawing.Size(144, 21)
        Me.comboboxCuotaMes.TabIndex = 28
        '
        'labelCuotaMes
        '
        Me.labelCuotaMes.AutoSize = True
        Me.labelCuotaMes.Location = New System.Drawing.Point(12, 135)
        Me.labelCuotaMes.Name = "labelCuotaMes"
        Me.labelCuotaMes.Size = New System.Drawing.Size(67, 13)
        Me.labelCuotaMes.TabIndex = 27
        Me.labelCuotaMes.Text = "Cuota - Mes:"
        '
        'formComprobanteDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 332)
        Me.Controls.Add(Me.comboboxCuotaMes)
        Me.Controls.Add(Me.labelCuotaMes)
        Me.Controls.Add(Me.comboboxAnioLectivoCurso)
        Me.Controls.Add(Me.labelAnioLectivoCurso)
        Me.Controls.Add(Me.buttonEntidad)
        Me.Controls.Add(Me.textboxEntidad)
        Me.Controls.Add(Me.labelEntidad)
        Me.Controls.Add(Me.comboboxArticulo)
        Me.Controls.Add(Me.labelArticulo)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formComprobanteDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents labelArticulo As System.Windows.Forms.Label
    Friend WithEvents comboboxArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents buttonEntidad As System.Windows.Forms.Button
    Friend WithEvents textboxEntidad As System.Windows.Forms.TextBox
    Friend WithEvents labelEntidad As System.Windows.Forms.Label
    Friend WithEvents comboboxAnioLectivoCurso As System.Windows.Forms.ComboBox
    Friend WithEvents labelAnioLectivoCurso As System.Windows.Forms.Label
    Friend WithEvents comboboxCuotaMes As System.Windows.Forms.ComboBox
    Friend WithEvents labelCuotaMes As System.Windows.Forms.Label
End Class
