<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formSplashScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formSplashScreen))
        Me.labelAppTitle = New System.Windows.Forms.Label()
        Me.labelCompanyName = New System.Windows.Forms.Label()
        Me.labelCopyright = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.labelLicensedTo = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelAppTitle
        '
        Me.labelAppTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.labelAppTitle.BackColor = System.Drawing.Color.Transparent
        Me.labelAppTitle.Font = New System.Drawing.Font("Tahoma", 39.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelAppTitle.ForeColor = System.Drawing.Color.White
        Me.labelAppTitle.Location = New System.Drawing.Point(52, 72)
        Me.labelAppTitle.Name = "labelAppTitle"
        Me.labelAppTitle.Size = New System.Drawing.Size(434, 71)
        Me.labelAppTitle.TabIndex = 0
        Me.labelAppTitle.Text = "Title"
        '
        'labelCompanyName
        '
        Me.labelCompanyName.BackColor = System.Drawing.Color.Transparent
        Me.labelCompanyName.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelCompanyName.Location = New System.Drawing.Point(60, 57)
        Me.labelCompanyName.Name = "labelCompanyName"
        Me.labelCompanyName.Size = New System.Drawing.Size(426, 23)
        Me.labelCompanyName.TabIndex = 1
        Me.labelCompanyName.Text = "CompanyName"
        '
        'labelCopyright
        '
        Me.labelCopyright.BackColor = System.Drawing.Color.Transparent
        Me.labelCopyright.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelCopyright.ForeColor = System.Drawing.Color.White
        Me.labelCopyright.Location = New System.Drawing.Point(12, 304)
        Me.labelCopyright.Name = "labelCopyright"
        Me.labelCopyright.Size = New System.Drawing.Size(474, 16)
        Me.labelCopyright.TabIndex = 2
        Me.labelCopyright.Text = "Copyright"
        Me.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SENAL_ESCUELA_152
        Me.PictureBox1.Location = New System.Drawing.Point(396, 146)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(90, 96)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PictureBox1.TabIndex = 3
        Me.PictureBox1.TabStop = False
        '
        'labelLicensedTo
        '
        Me.labelLicensedTo.BackColor = System.Drawing.Color.Transparent
        Me.labelLicensedTo.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelLicensedTo.ForeColor = System.Drawing.Color.Gold
        Me.labelLicensedTo.Location = New System.Drawing.Point(12, 263)
        Me.labelLicensedTo.Name = "labelLicensedTo"
        Me.labelLicensedTo.Size = New System.Drawing.Size(474, 31)
        Me.labelLicensedTo.TabIndex = 4
        Me.labelLicensedTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'formSplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.BackgroundImage = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SPLASH_SCREEN_BACKGROUND
        Me.ClientSize = New System.Drawing.Size(498, 329)
        Me.ControlBox = False
        Me.Controls.Add(Me.labelLicensedTo)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.labelCopyright)
        Me.Controls.Add(Me.labelCompanyName)
        Me.Controls.Add(Me.labelAppTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formSplashScreen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "App.Title"
        Me.TopMost = True
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents labelAppTitle As System.Windows.Forms.Label
    Friend WithEvents labelCompanyName As System.Windows.Forms.Label
    Friend WithEvents labelCopyright As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents labelLicensedTo As System.Windows.Forms.Label

End Class
