<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formEntidadInscripcionDetalle
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
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.textboxAlumno = New System.Windows.Forms.TextBox()
        Me.labelAlumno = New System.Windows.Forms.Label()
        Me.comboboxAnioProximo = New System.Windows.Forms.ComboBox()
        Me.groupboxCursoActual = New System.Windows.Forms.GroupBox()
        Me.textboxDivisionActual = New System.Windows.Forms.TextBox()
        Me.labelDivisionActual = New System.Windows.Forms.Label()
        Me.textboxTurnoActual = New System.Windows.Forms.TextBox()
        Me.labelTurnoActual = New System.Windows.Forms.Label()
        Me.textboxAnioActual = New System.Windows.Forms.TextBox()
        Me.labelAnioActual = New System.Windows.Forms.Label()
        Me.groupboxCursoProximo = New System.Windows.Forms.GroupBox()
        Me.comboboxDivisionProximo = New System.Windows.Forms.ComboBox()
        Me.comboboxTurnoProximo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.toolstripMain.SuspendLayout()
        Me.groupboxCursoActual.SuspendLayout()
        Me.groupboxCursoProximo.SuspendLayout()
        Me.SuspendLayout()
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
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(349, 39)
        Me.toolstripMain.TabIndex = 1
        '
        'textboxAlumno
        '
        Me.textboxAlumno.Location = New System.Drawing.Point(66, 50)
        Me.textboxAlumno.MaxLength = 10
        Me.textboxAlumno.Name = "textboxAlumno"
        Me.textboxAlumno.ReadOnly = True
        Me.textboxAlumno.Size = New System.Drawing.Size(266, 20)
        Me.textboxAlumno.TabIndex = 3
        Me.textboxAlumno.TabStop = False
        '
        'labelAlumno
        '
        Me.labelAlumno.AutoSize = True
        Me.labelAlumno.Location = New System.Drawing.Point(14, 53)
        Me.labelAlumno.Name = "labelAlumno"
        Me.labelAlumno.Size = New System.Drawing.Size(45, 13)
        Me.labelAlumno.TabIndex = 2
        Me.labelAlumno.Text = "Alumno:"
        '
        'comboboxAnioProximo
        '
        Me.comboboxAnioProximo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnioProximo.FormattingEnabled = True
        Me.comboboxAnioProximo.Location = New System.Drawing.Point(57, 29)
        Me.comboboxAnioProximo.Name = "comboboxAnioProximo"
        Me.comboboxAnioProximo.Size = New System.Drawing.Size(266, 21)
        Me.comboboxAnioProximo.TabIndex = 1
        '
        'groupboxCursoActual
        '
        Me.groupboxCursoActual.Controls.Add(Me.textboxDivisionActual)
        Me.groupboxCursoActual.Controls.Add(Me.labelDivisionActual)
        Me.groupboxCursoActual.Controls.Add(Me.textboxTurnoActual)
        Me.groupboxCursoActual.Controls.Add(Me.labelTurnoActual)
        Me.groupboxCursoActual.Controls.Add(Me.textboxAnioActual)
        Me.groupboxCursoActual.Controls.Add(Me.labelAnioActual)
        Me.groupboxCursoActual.Location = New System.Drawing.Point(9, 90)
        Me.groupboxCursoActual.Margin = New System.Windows.Forms.Padding(2)
        Me.groupboxCursoActual.Name = "groupboxCursoActual"
        Me.groupboxCursoActual.Padding = New System.Windows.Forms.Padding(2)
        Me.groupboxCursoActual.Size = New System.Drawing.Size(332, 106)
        Me.groupboxCursoActual.TabIndex = 4
        Me.groupboxCursoActual.TabStop = False
        Me.groupboxCursoActual.Text = "Curso actual:"
        '
        'textboxDivisionActual
        '
        Me.textboxDivisionActual.Location = New System.Drawing.Point(57, 78)
        Me.textboxDivisionActual.MaxLength = 10
        Me.textboxDivisionActual.Name = "textboxDivisionActual"
        Me.textboxDivisionActual.ReadOnly = True
        Me.textboxDivisionActual.Size = New System.Drawing.Size(20, 20)
        Me.textboxDivisionActual.TabIndex = 5
        Me.textboxDivisionActual.TabStop = False
        '
        'labelDivisionActual
        '
        Me.labelDivisionActual.AutoSize = True
        Me.labelDivisionActual.Location = New System.Drawing.Point(5, 80)
        Me.labelDivisionActual.Name = "labelDivisionActual"
        Me.labelDivisionActual.Size = New System.Drawing.Size(47, 13)
        Me.labelDivisionActual.TabIndex = 4
        Me.labelDivisionActual.Text = "División:"
        '
        'textboxTurnoActual
        '
        Me.textboxTurnoActual.Location = New System.Drawing.Point(57, 54)
        Me.textboxTurnoActual.MaxLength = 10
        Me.textboxTurnoActual.Name = "textboxTurnoActual"
        Me.textboxTurnoActual.ReadOnly = True
        Me.textboxTurnoActual.Size = New System.Drawing.Size(266, 20)
        Me.textboxTurnoActual.TabIndex = 3
        Me.textboxTurnoActual.TabStop = False
        '
        'labelTurnoActual
        '
        Me.labelTurnoActual.AutoSize = True
        Me.labelTurnoActual.Location = New System.Drawing.Point(5, 56)
        Me.labelTurnoActual.Name = "labelTurnoActual"
        Me.labelTurnoActual.Size = New System.Drawing.Size(38, 13)
        Me.labelTurnoActual.TabIndex = 2
        Me.labelTurnoActual.Text = "Turno:"
        '
        'textboxAnioActual
        '
        Me.textboxAnioActual.Location = New System.Drawing.Point(57, 29)
        Me.textboxAnioActual.MaxLength = 10
        Me.textboxAnioActual.Name = "textboxAnioActual"
        Me.textboxAnioActual.ReadOnly = True
        Me.textboxAnioActual.Size = New System.Drawing.Size(266, 20)
        Me.textboxAnioActual.TabIndex = 1
        Me.textboxAnioActual.TabStop = False
        '
        'labelAnioActual
        '
        Me.labelAnioActual.AutoSize = True
        Me.labelAnioActual.Location = New System.Drawing.Point(5, 32)
        Me.labelAnioActual.Name = "labelAnioActual"
        Me.labelAnioActual.Size = New System.Drawing.Size(29, 13)
        Me.labelAnioActual.TabIndex = 0
        Me.labelAnioActual.Text = "Año:"
        '
        'groupboxCursoProximo
        '
        Me.groupboxCursoProximo.Controls.Add(Me.comboboxDivisionProximo)
        Me.groupboxCursoProximo.Controls.Add(Me.comboboxTurnoProximo)
        Me.groupboxCursoProximo.Controls.Add(Me.comboboxAnioProximo)
        Me.groupboxCursoProximo.Controls.Add(Me.Label1)
        Me.groupboxCursoProximo.Controls.Add(Me.Label2)
        Me.groupboxCursoProximo.Controls.Add(Me.Label3)
        Me.groupboxCursoProximo.Location = New System.Drawing.Point(9, 219)
        Me.groupboxCursoProximo.Margin = New System.Windows.Forms.Padding(2)
        Me.groupboxCursoProximo.Name = "groupboxCursoProximo"
        Me.groupboxCursoProximo.Padding = New System.Windows.Forms.Padding(2)
        Me.groupboxCursoProximo.Size = New System.Drawing.Size(332, 106)
        Me.groupboxCursoProximo.TabIndex = 0
        Me.groupboxCursoProximo.TabStop = False
        Me.groupboxCursoProximo.Text = "Curso próximo:"
        '
        'comboboxDivisionProximo
        '
        Me.comboboxDivisionProximo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxDivisionProximo.FormattingEnabled = True
        Me.comboboxDivisionProximo.Location = New System.Drawing.Point(57, 80)
        Me.comboboxDivisionProximo.Name = "comboboxDivisionProximo"
        Me.comboboxDivisionProximo.Size = New System.Drawing.Size(35, 21)
        Me.comboboxDivisionProximo.TabIndex = 5
        '
        'comboboxTurnoProximo
        '
        Me.comboboxTurnoProximo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxTurnoProximo.FormattingEnabled = True
        Me.comboboxTurnoProximo.Location = New System.Drawing.Point(57, 55)
        Me.comboboxTurnoProximo.Name = "comboboxTurnoProximo"
        Me.comboboxTurnoProximo.Size = New System.Drawing.Size(266, 21)
        Me.comboboxTurnoProximo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "División:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Turno:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Año:"
        '
        'formEntidadInscripcionDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(349, 340)
        Me.Controls.Add(Me.groupboxCursoProximo)
        Me.Controls.Add(Me.groupboxCursoActual)
        Me.Controls.Add(Me.textboxAlumno)
        Me.Controls.Add(Me.labelAlumno)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formEntidadInscripcionDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Alumno - Cursos"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.groupboxCursoActual.ResumeLayout(False)
        Me.groupboxCursoActual.PerformLayout()
        Me.groupboxCursoProximo.ResumeLayout(False)
        Me.groupboxCursoProximo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents textboxAlumno As System.Windows.Forms.TextBox
    Friend WithEvents labelAlumno As System.Windows.Forms.Label
    Friend WithEvents comboboxAnioProximo As System.Windows.Forms.ComboBox
    Friend WithEvents groupboxCursoActual As System.Windows.Forms.GroupBox
    Friend WithEvents textboxDivisionActual As System.Windows.Forms.TextBox
    Friend WithEvents labelDivisionActual As System.Windows.Forms.Label
    Friend WithEvents textboxTurnoActual As System.Windows.Forms.TextBox
    Friend WithEvents labelTurnoActual As System.Windows.Forms.Label
    Friend WithEvents textboxAnioActual As System.Windows.Forms.TextBox
    Friend WithEvents labelAnioActual As System.Windows.Forms.Label
    Friend WithEvents groupboxCursoProximo As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents comboboxDivisionProximo As System.Windows.Forms.ComboBox
    Friend WithEvents comboboxTurnoProximo As System.Windows.Forms.ComboBox
End Class
