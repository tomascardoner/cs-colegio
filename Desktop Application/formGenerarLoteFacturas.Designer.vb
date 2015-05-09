<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formGenerarLoteFacturas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formGenerarLoteFacturas))
        Me.panelPaso1 = New System.Windows.Forms.Panel()
        Me.lalbelPaso1Periodo = New System.Windows.Forms.Label()
        Me.tabcontrolMain = New System.Windows.Forms.TabControl()
        Me.tabpageNivelesCursosAlumnos = New System.Windows.Forms.TabPage()
        Me.treeviewNivelCursoAlumno = New System.Windows.Forms.TreeView()
        Me.tabpagePadresAlumnos = New System.Windows.Forms.TabPage()
        Me.treeviewPadresAlumnos = New System.Windows.Forms.TreeView()
        Me.pictureboxMain = New System.Windows.Forms.PictureBox()
        Me.labelPaso1Titulo = New System.Windows.Forms.Label()
        Me.buttonPaso1Cancelar = New System.Windows.Forms.Button()
        Me.buttonPaso1Siguiente = New System.Windows.Forms.Button()
        Me.labelPaso1Mensaje = New System.Windows.Forms.Label()
        Me.panelPaso1.SuspendLayout()
        Me.tabcontrolMain.SuspendLayout()
        Me.tabpageNivelesCursosAlumnos.SuspendLayout()
        Me.tabpagePadresAlumnos.SuspendLayout()
        CType(Me.pictureboxMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelPaso1
        '
        Me.panelPaso1.Controls.Add(Me.lalbelPaso1Periodo)
        Me.panelPaso1.Controls.Add(Me.tabcontrolMain)
        Me.panelPaso1.Controls.Add(Me.pictureboxMain)
        Me.panelPaso1.Controls.Add(Me.labelPaso1Titulo)
        Me.panelPaso1.Controls.Add(Me.buttonPaso1Cancelar)
        Me.panelPaso1.Controls.Add(Me.buttonPaso1Siguiente)
        Me.panelPaso1.Controls.Add(Me.labelPaso1Mensaje)
        Me.panelPaso1.Location = New System.Drawing.Point(12, 12)
        Me.panelPaso1.Name = "panelPaso1"
        Me.panelPaso1.Size = New System.Drawing.Size(611, 441)
        Me.panelPaso1.TabIndex = 102
        '
        'lalbelPaso1Periodo
        '
        Me.lalbelPaso1Periodo.AutoSize = True
        Me.lalbelPaso1Periodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lalbelPaso1Periodo.Location = New System.Drawing.Point(7, 413)
        Me.lalbelPaso1Periodo.Name = "lalbelPaso1Periodo"
        Me.lalbelPaso1Periodo.Size = New System.Drawing.Size(141, 16)
        Me.lalbelPaso1Periodo.TabIndex = 108
        Me.lalbelPaso1Periodo.Text = "Período a Facturar:"
        '
        'tabcontrolMain
        '
        Me.tabcontrolMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons
        Me.tabcontrolMain.Controls.Add(Me.tabpageNivelesCursosAlumnos)
        Me.tabcontrolMain.Controls.Add(Me.tabpagePadresAlumnos)
        Me.tabcontrolMain.Location = New System.Drawing.Point(3, 84)
        Me.tabcontrolMain.Name = "tabcontrolMain"
        Me.tabcontrolMain.SelectedIndex = 0
        Me.tabcontrolMain.Size = New System.Drawing.Size(605, 314)
        Me.tabcontrolMain.TabIndex = 107
        '
        'tabpageNivelesCursosAlumnos
        '
        Me.tabpageNivelesCursosAlumnos.Controls.Add(Me.treeviewNivelCursoAlumno)
        Me.tabpageNivelesCursosAlumnos.Location = New System.Drawing.Point(4, 25)
        Me.tabpageNivelesCursosAlumnos.Name = "tabpageNivelesCursosAlumnos"
        Me.tabpageNivelesCursosAlumnos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageNivelesCursosAlumnos.Size = New System.Drawing.Size(597, 285)
        Me.tabpageNivelesCursosAlumnos.TabIndex = 0
        Me.tabpageNivelesCursosAlumnos.Text = "Niveles - Cursos - Alumnos"
        Me.tabpageNivelesCursosAlumnos.UseVisualStyleBackColor = True
        '
        'treeviewNivelCursoAlumno
        '
        Me.treeviewNivelCursoAlumno.CheckBoxes = True
        Me.treeviewNivelCursoAlumno.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeviewNivelCursoAlumno.Location = New System.Drawing.Point(3, 3)
        Me.treeviewNivelCursoAlumno.Name = "treeviewNivelCursoAlumno"
        Me.treeviewNivelCursoAlumno.Size = New System.Drawing.Size(591, 279)
        Me.treeviewNivelCursoAlumno.TabIndex = 107
        '
        'tabpagePadresAlumnos
        '
        Me.tabpagePadresAlumnos.Controls.Add(Me.treeviewPadresAlumnos)
        Me.tabpagePadresAlumnos.Location = New System.Drawing.Point(4, 25)
        Me.tabpagePadresAlumnos.Name = "tabpagePadresAlumnos"
        Me.tabpagePadresAlumnos.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpagePadresAlumnos.Size = New System.Drawing.Size(597, 285)
        Me.tabpagePadresAlumnos.TabIndex = 1
        Me.tabpagePadresAlumnos.Text = "Padres - Alumnos"
        Me.tabpagePadresAlumnos.UseVisualStyleBackColor = True
        '
        'treeviewPadresAlumnos
        '
        Me.treeviewPadresAlumnos.CheckBoxes = True
        Me.treeviewPadresAlumnos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.treeviewPadresAlumnos.Location = New System.Drawing.Point(3, 3)
        Me.treeviewPadresAlumnos.Name = "treeviewPadresAlumnos"
        Me.treeviewPadresAlumnos.Size = New System.Drawing.Size(591, 279)
        Me.treeviewPadresAlumnos.TabIndex = 0
        '
        'pictureboxMain
        '
        Me.pictureboxMain.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_COMPROBANTE_48
        Me.pictureboxMain.Location = New System.Drawing.Point(3, 20)
        Me.pictureboxMain.Name = "pictureboxMain"
        Me.pictureboxMain.Size = New System.Drawing.Size(48, 48)
        Me.pictureboxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureboxMain.TabIndex = 105
        Me.pictureboxMain.TabStop = False
        '
        'labelPaso1Titulo
        '
        Me.labelPaso1Titulo.AutoSize = True
        Me.labelPaso1Titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.labelPaso1Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPaso1Titulo.Location = New System.Drawing.Point(0, 0)
        Me.labelPaso1Titulo.Name = "labelPaso1Titulo"
        Me.labelPaso1Titulo.Size = New System.Drawing.Size(138, 17)
        Me.labelPaso1Titulo.TabIndex = 104
        Me.labelPaso1Titulo.Text = "Paso 1: Selección"
        '
        'buttonPaso1Cancelar
        '
        Me.buttonPaso1Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso1Cancelar.Location = New System.Drawing.Point(387, 404)
        Me.buttonPaso1Cancelar.Name = "buttonPaso1Cancelar"
        Me.buttonPaso1Cancelar.Size = New System.Drawing.Size(75, 34)
        Me.buttonPaso1Cancelar.TabIndex = 103
        Me.buttonPaso1Cancelar.Text = "Cancelar"
        Me.buttonPaso1Cancelar.UseVisualStyleBackColor = True
        '
        'buttonPaso1Siguiente
        '
        Me.buttonPaso1Siguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso1Siguiente.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_NEXT_24
        Me.buttonPaso1Siguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso1Siguiente.Location = New System.Drawing.Point(468, 404)
        Me.buttonPaso1Siguiente.Name = "buttonPaso1Siguiente"
        Me.buttonPaso1Siguiente.Size = New System.Drawing.Size(140, 34)
        Me.buttonPaso1Siguiente.TabIndex = 102
        Me.buttonPaso1Siguiente.Text = "Paso 2: Verificación"
        Me.buttonPaso1Siguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso1Siguiente.UseVisualStyleBackColor = True
        '
        'labelPaso1Mensaje
        '
        Me.labelPaso1Mensaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPaso1Mensaje.Location = New System.Drawing.Point(57, 20)
        Me.labelPaso1Mensaje.Name = "labelPaso1Mensaje"
        Me.labelPaso1Mensaje.Size = New System.Drawing.Size(551, 61)
        Me.labelPaso1Mensaje.TabIndex = 100
        Me.labelPaso1Mensaje.Text = resources.GetString("labelPaso1Mensaje.Text")
        '
        'formGenerarLoteFacturas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(636, 465)
        Me.Controls.Add(Me.panelPaso1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "formGenerarLoteFacturas"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Generación de Lote de Facturas"
        Me.panelPaso1.ResumeLayout(False)
        Me.panelPaso1.PerformLayout()
        Me.tabcontrolMain.ResumeLayout(False)
        Me.tabpageNivelesCursosAlumnos.ResumeLayout(False)
        Me.tabpagePadresAlumnos.ResumeLayout(False)
        CType(Me.pictureboxMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelPaso1 As System.Windows.Forms.Panel
    Friend WithEvents labelPaso1Titulo As System.Windows.Forms.Label
    Friend WithEvents buttonPaso1Cancelar As System.Windows.Forms.Button
    Friend WithEvents buttonPaso1Siguiente As System.Windows.Forms.Button
    Friend WithEvents labelPaso1Mensaje As System.Windows.Forms.Label
    Friend WithEvents pictureboxMain As System.Windows.Forms.PictureBox
    Friend WithEvents tabcontrolMain As System.Windows.Forms.TabControl
    Friend WithEvents tabpageNivelesCursosAlumnos As System.Windows.Forms.TabPage
    Friend WithEvents treeviewNivelCursoAlumno As System.Windows.Forms.TreeView
    Friend WithEvents tabpagePadresAlumnos As System.Windows.Forms.TabPage
    Friend WithEvents treeviewPadresAlumnos As System.Windows.Forms.TreeView
    Friend WithEvents lalbelPaso1Periodo As System.Windows.Forms.Label
End Class
