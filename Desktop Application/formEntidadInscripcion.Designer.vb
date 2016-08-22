<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formEntidadInscripcion
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
        Me.labelEntidad = New System.Windows.Forms.Label()
        Me.buttonEntidad = New System.Windows.Forms.Button()
        Me.panelPaso1 = New System.Windows.Forms.Panel()
        Me.labelAlumnos = New System.Windows.Forms.Label()
        Me.textboxEntidad = New System.Windows.Forms.TextBox()
        Me.buttonPaso1Cancelar = New System.Windows.Forms.Button()
        Me.buttonPaso1Siguiente = New System.Windows.Forms.Button()
        Me.labelPaso1 = New System.Windows.Forms.Label()
        Me.listviewAlumnosAniosLectivosCursos = New System.Windows.Forms.ListView()
        Me.columnAlumno = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnCursoActual = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnCursoNuevo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.panelPaso1.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelEntidad
        '
        Me.labelEntidad.AutoSize = True
        Me.labelEntidad.Location = New System.Drawing.Point(16, 70)
        Me.labelEntidad.Name = "labelEntidad"
        Me.labelEntidad.Size = New System.Drawing.Size(60, 17)
        Me.labelEntidad.TabIndex = 0
        Me.labelEntidad.Text = "Entidad:"
        '
        'buttonEntidad
        '
        Me.buttonEntidad.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonEntidad.Location = New System.Drawing.Point(506, 64)
        Me.buttonEntidad.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonEntidad.Name = "buttonEntidad"
        Me.buttonEntidad.Size = New System.Drawing.Size(29, 28)
        Me.buttonEntidad.TabIndex = 10
        Me.buttonEntidad.UseVisualStyleBackColor = True
        '
        'panelPaso1
        '
        Me.panelPaso1.Controls.Add(Me.listviewAlumnosAniosLectivosCursos)
        Me.panelPaso1.Controls.Add(Me.labelAlumnos)
        Me.panelPaso1.Controls.Add(Me.textboxEntidad)
        Me.panelPaso1.Controls.Add(Me.labelEntidad)
        Me.panelPaso1.Controls.Add(Me.buttonEntidad)
        Me.panelPaso1.Controls.Add(Me.buttonPaso1Cancelar)
        Me.panelPaso1.Controls.Add(Me.buttonPaso1Siguiente)
        Me.panelPaso1.Controls.Add(Me.labelPaso1)
        Me.panelPaso1.Location = New System.Drawing.Point(12, 12)
        Me.panelPaso1.Name = "panelPaso1"
        Me.panelPaso1.Size = New System.Drawing.Size(844, 404)
        Me.panelPaso1.TabIndex = 12
        '
        'labelAlumnos
        '
        Me.labelAlumnos.AutoSize = True
        Me.labelAlumnos.Location = New System.Drawing.Point(16, 118)
        Me.labelAlumnos.Name = "labelAlumnos"
        Me.labelAlumnos.Size = New System.Drawing.Size(182, 17)
        Me.labelAlumnos.TabIndex = 13
        Me.labelAlumnos.Text = "Alumnos y Cursos actuales:"
        '
        'textboxEntidad
        '
        Me.textboxEntidad.Location = New System.Drawing.Point(83, 67)
        Me.textboxEntidad.Margin = New System.Windows.Forms.Padding(4)
        Me.textboxEntidad.MaxLength = 150
        Me.textboxEntidad.Name = "textboxEntidad"
        Me.textboxEntidad.ReadOnly = True
        Me.textboxEntidad.Size = New System.Drawing.Size(422, 22)
        Me.textboxEntidad.TabIndex = 11
        Me.textboxEntidad.TabStop = False
        '
        'buttonPaso1Cancelar
        '
        Me.buttonPaso1Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso1Cancelar.Location = New System.Drawing.Point(549, 362)
        Me.buttonPaso1Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonPaso1Cancelar.Name = "buttonPaso1Cancelar"
        Me.buttonPaso1Cancelar.Size = New System.Drawing.Size(100, 42)
        Me.buttonPaso1Cancelar.TabIndex = 7
        Me.buttonPaso1Cancelar.Text = "Cancelar"
        Me.buttonPaso1Cancelar.UseVisualStyleBackColor = True
        '
        'buttonPaso1Siguiente
        '
        Me.buttonPaso1Siguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso1Siguiente.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_NEXT_24
        Me.buttonPaso1Siguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso1Siguiente.Location = New System.Drawing.Point(657, 362)
        Me.buttonPaso1Siguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonPaso1Siguiente.Name = "buttonPaso1Siguiente"
        Me.buttonPaso1Siguiente.Size = New System.Drawing.Size(187, 42)
        Me.buttonPaso1Siguiente.TabIndex = 8
        Me.buttonPaso1Siguiente.Text = "Paso 2: Verificación"
        Me.buttonPaso1Siguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso1Siguiente.UseVisualStyleBackColor = True
        '
        'labelPaso1
        '
        Me.labelPaso1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPaso1.Location = New System.Drawing.Point(3, 0)
        Me.labelPaso1.Name = "labelPaso1"
        Me.labelPaso1.Size = New System.Drawing.Size(838, 51)
        Me.labelPaso1.TabIndex = 0
        Me.labelPaso1.Text = "Paso 1: Seleccione la Entidad para iniciar el proceso de Inscripción de uno o más" & _
    " alumnos a un nuevo Ciclo Lectivo. Puede seleccionar el Alumno o el Titular de l" & _
    "a Factura."
        '
        'listviewAlumnosAniosLectivosCursos
        '
        Me.listviewAlumnosAniosLectivosCursos.CheckBoxes = True
        Me.listviewAlumnosAniosLectivosCursos.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnAlumno, Me.columnCursoActual, Me.columnCursoNuevo})
        Me.listviewAlumnosAniosLectivosCursos.Location = New System.Drawing.Point(19, 138)
        Me.listviewAlumnosAniosLectivosCursos.Name = "listviewAlumnosAniosLectivosCursos"
        Me.listviewAlumnosAniosLectivosCursos.Size = New System.Drawing.Size(805, 194)
        Me.listviewAlumnosAniosLectivosCursos.TabIndex = 14
        Me.listviewAlumnosAniosLectivosCursos.UseCompatibleStateImageBehavior = False
        Me.listviewAlumnosAniosLectivosCursos.View = System.Windows.Forms.View.Details
        '
        'columnAlumno
        '
        Me.columnAlumno.Text = "Alumno"
        Me.columnAlumno.Width = 180
        '
        'columnCursoActual
        '
        Me.columnCursoActual.Text = "Curso Actual"
        Me.columnCursoActual.Width = 280
        '
        'columnCursoNuevo
        '
        Me.columnCursoNuevo.Text = "Curso Nuevo"
        Me.columnCursoNuevo.Width = 280
        '
        'formEntidadInscripcion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(868, 428)
        Me.Controls.Add(Me.panelPaso1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "formEntidadInscripcion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Inscripción a un nuevo Ciclo Lectivo"
        Me.panelPaso1.ResumeLayout(False)
        Me.panelPaso1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents labelEntidad As System.Windows.Forms.Label
    Friend WithEvents buttonEntidad As System.Windows.Forms.Button
    Friend WithEvents panelPaso1 As System.Windows.Forms.Panel
    Friend WithEvents buttonPaso1Cancelar As System.Windows.Forms.Button
    Friend WithEvents buttonPaso1Siguiente As System.Windows.Forms.Button
    Friend WithEvents labelPaso1 As System.Windows.Forms.Label
    Friend WithEvents textboxEntidad As System.Windows.Forms.TextBox
    Friend WithEvents labelAlumnos As System.Windows.Forms.Label
    Friend WithEvents listviewAlumnosAniosLectivosCursos As System.Windows.Forms.ListView
    Friend WithEvents columnAlumno As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnCursoActual As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnCursoNuevo As System.Windows.Forms.ColumnHeader
End Class
