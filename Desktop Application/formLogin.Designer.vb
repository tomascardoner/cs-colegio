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
        Me.buttonCancelar = New System.Windows.Forms.Button()
        Me.buttonAceptar = New System.Windows.Forms.Button()
        CType(Me.pictureboxMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pictureboxMain
        '
        Me.pictureboxMain.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_INICIO_SESION_48
        Me.pictureboxMain.Location = New System.Drawing.Point(12, 12)
        Me.pictureboxMain.Name = "pictureboxMain"
        Me.pictureboxMain.Size = New System.Drawing.Size(48, 48)
        Me.pictureboxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.pictureboxMain.TabIndex = 0
        Me.pictureboxMain.TabStop = False
        '
        'labelNombre
        '
        Me.labelNombre.AutoSize = True
        Me.labelNombre.Location = New System.Drawing.Point(65, 31)
        Me.labelNombre.Name = "labelNombre"
        Me.labelNombre.Size = New System.Drawing.Size(46, 13)
        Me.labelNombre.TabIndex = 0
        Me.labelNombre.Text = "Usuario:"
        '
        'labelPassword
        '
        Me.labelPassword.AutoSize = True
        Me.labelPassword.Location = New System.Drawing.Point(65, 64)
        Me.labelPassword.Name = "labelPassword"
        Me.labelPassword.Size = New System.Drawing.Size(64, 13)
        Me.labelPassword.TabIndex = 2
        Me.labelPassword.Text = "Contraseña:"
        '
        'textboxNombre
        '
        Me.textboxNombre.Location = New System.Drawing.Point(139, 28)
        Me.textboxNombre.MaxLength = 30
        Me.textboxNombre.Name = "textboxNombre"
        Me.textboxNombre.Size = New System.Drawing.Size(158, 20)
        Me.textboxNombre.TabIndex = 1
        '
        'textboxPassword
        '
        Me.textboxPassword.Location = New System.Drawing.Point(139, 61)
        Me.textboxPassword.Name = "textboxPassword"
        Me.textboxPassword.Size = New System.Drawing.Size(158, 20)
        Me.textboxPassword.TabIndex = 3
        Me.textboxPassword.UseSystemPasswordChar = True
        '
        'buttonCancelar
        '
        Me.buttonCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonCancelar.Location = New System.Drawing.Point(222, 112)
        Me.buttonCancelar.Name = "buttonCancelar"
        Me.buttonCancelar.Size = New System.Drawing.Size(75, 23)
        Me.buttonCancelar.TabIndex = 5
        Me.buttonCancelar.Text = "Cancelar"
        Me.buttonCancelar.UseVisualStyleBackColor = True
        '
        'buttonAceptar
        '
        Me.buttonAceptar.Location = New System.Drawing.Point(139, 112)
        Me.buttonAceptar.Name = "buttonAceptar"
        Me.buttonAceptar.Size = New System.Drawing.Size(75, 23)
        Me.buttonAceptar.TabIndex = 4
        Me.buttonAceptar.Text = "Aceptar"
        Me.buttonAceptar.UseVisualStyleBackColor = True
        '
        'formLogin
        '
        Me.AcceptButton = Me.buttonAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.buttonCancelar
        Me.ClientSize = New System.Drawing.Size(306, 147)
        Me.ControlBox = False
        Me.Controls.Add(Me.buttonAceptar)
        Me.Controls.Add(Me.buttonCancelar)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pictureboxMain As System.Windows.Forms.PictureBox
    Friend WithEvents labelNombre As System.Windows.Forms.Label
    Friend WithEvents labelPassword As System.Windows.Forms.Label
    Friend WithEvents textboxNombre As System.Windows.Forms.TextBox
    Friend WithEvents textboxPassword As System.Windows.Forms.TextBox
    Friend WithEvents buttonCancelar As System.Windows.Forms.Button
    Friend WithEvents buttonAceptar As System.Windows.Forms.Button
End Class
