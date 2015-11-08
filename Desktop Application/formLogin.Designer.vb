<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formLogin))
        Me.pictureboxMain = New System.Windows.Forms.PictureBox()
        Me.labelNombre = New System.Windows.Forms.Label()
        Me.labelPassword = New System.Windows.Forms.Label()
        Me.textboxNombre = New System.Windows.Forms.TextBox()
        Me.textboxPassword = New System.Windows.Forms.TextBox()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonAceptar = New System.Windows.Forms.ToolStripButton()
        CType(Me.pictureboxMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'pictureboxMain
        '
        Me.pictureboxMain.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_INICIO_SESION_48
        Me.pictureboxMain.Location = New System.Drawing.Point(12, 42)
        Me.pictureboxMain.Name = "pictureboxMain"
        Me.pictureboxMain.Size = New System.Drawing.Size(48, 48)
        Me.pictureboxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureboxMain.TabIndex = 0
        Me.pictureboxMain.TabStop = False
        '
        'labelNombre
        '
        Me.labelNombre.AutoSize = True
        Me.labelNombre.Location = New System.Drawing.Point(65, 61)
        Me.labelNombre.Name = "labelNombre"
        Me.labelNombre.Size = New System.Drawing.Size(46, 13)
        Me.labelNombre.TabIndex = 0
        Me.labelNombre.Text = "Usuario:"
        '
        'labelPassword
        '
        Me.labelPassword.AutoSize = True
        Me.labelPassword.Location = New System.Drawing.Point(65, 94)
        Me.labelPassword.Name = "labelPassword"
        Me.labelPassword.Size = New System.Drawing.Size(64, 13)
        Me.labelPassword.TabIndex = 2
        Me.labelPassword.Text = "Contraseña:"
        '
        'textboxNombre
        '
        Me.textboxNombre.Location = New System.Drawing.Point(139, 58)
        Me.textboxNombre.MaxLength = 30
        Me.textboxNombre.Name = "textboxNombre"
        Me.textboxNombre.Size = New System.Drawing.Size(158, 20)
        Me.textboxNombre.TabIndex = 1
        '
        'textboxPassword
        '
        Me.textboxPassword.Location = New System.Drawing.Point(139, 91)
        Me.textboxPassword.Name = "textboxPassword"
        Me.textboxPassword.Size = New System.Drawing.Size(158, 20)
        Me.textboxPassword.TabIndex = 3
        Me.textboxPassword.UseSystemPasswordChar = True
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCancelar, Me.buttonAceptar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(306, 39)
        Me.toolstripMain.TabIndex = 4
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
        'buttonAceptar
        '
        Me.buttonAceptar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonAceptar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_OK_32
        Me.buttonAceptar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonAceptar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonAceptar.Name = "buttonAceptar"
        Me.buttonAceptar.Size = New System.Drawing.Size(84, 36)
        Me.buttonAceptar.Text = "Aceptar"
        '
        'formLogin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(306, 122)
        Me.ControlBox = False
        Me.Controls.Add(Me.toolstripMain)
        Me.Controls.Add(Me.textboxPassword)
        Me.Controls.Add(Me.textboxNombre)
        Me.Controls.Add(Me.labelPassword)
        Me.Controls.Add(Me.labelNombre)
        Me.Controls.Add(Me.pictureboxMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formLogin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Inicio de sesión"
        CType(Me.pictureboxMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pictureboxMain As System.Windows.Forms.PictureBox
    Friend WithEvents labelNombre As System.Windows.Forms.Label
    Friend WithEvents labelPassword As System.Windows.Forms.Label
    Friend WithEvents textboxNombre As System.Windows.Forms.TextBox
    Friend WithEvents textboxPassword As System.Windows.Forms.TextBox
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonAceptar As System.Windows.Forms.ToolStripButton
End Class
