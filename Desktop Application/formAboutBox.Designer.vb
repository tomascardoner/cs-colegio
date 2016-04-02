<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAboutBox
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

    Friend WithEvents labelApplicationTitle As System.Windows.Forms.Label
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents OKButton As System.Windows.Forms.Button
    Friend WithEvents LabelCopyright As System.Windows.Forms.Label

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.labelApplicationTitle = New System.Windows.Forms.Label()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.LabelCopyright = New System.Windows.Forms.Label()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.listviewPropiedades = New System.Windows.Forms.ListView()
        Me.columnPropiedad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnValor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pictureboxIcon = New System.Windows.Forms.PictureBox()
        Me.labelLicensedTo = New System.Windows.Forms.Label()
        CType(Me.pictureboxIcon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelApplicationTitle
        '
        Me.labelApplicationTitle.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.labelApplicationTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelApplicationTitle.Location = New System.Drawing.Point(111, 12)
        Me.labelApplicationTitle.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.labelApplicationTitle.Name = "labelApplicationTitle"
        Me.labelApplicationTitle.Size = New System.Drawing.Size(319, 29)
        Me.labelApplicationTitle.TabIndex = 0
        Me.labelApplicationTitle.Text = "Application Title"
        Me.labelApplicationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelVersion
        '
        Me.LabelVersion.Location = New System.Drawing.Point(111, 41)
        Me.LabelVersion.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(319, 18)
        Me.LabelVersion.TabIndex = 0
        Me.LabelVersion.Text = "Version"
        Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelCopyright
        '
        Me.LabelCopyright.Location = New System.Drawing.Point(111, 70)
        Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(6, 0, 3, 0)
        Me.LabelCopyright.Name = "LabelCopyright"
        Me.LabelCopyright.Size = New System.Drawing.Size(319, 38)
        Me.LabelCopyright.TabIndex = 0
        Me.LabelCopyright.Text = "Copyright"
        '
        'OKButton
        '
        Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.OKButton.Location = New System.Drawing.Point(355, 267)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 23)
        Me.OKButton.TabIndex = 0
        Me.OKButton.Text = "&OK"
        '
        'listviewPropiedades
        '
        Me.listviewPropiedades.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnPropiedad, Me.columnValor})
        Me.listviewPropiedades.FullRowSelect = True
        Me.listviewPropiedades.GridLines = True
        Me.listviewPropiedades.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.listviewPropiedades.Location = New System.Drawing.Point(12, 145)
        Me.listviewPropiedades.MultiSelect = False
        Me.listviewPropiedades.Name = "listviewPropiedades"
        Me.listviewPropiedades.ShowGroups = False
        Me.listviewPropiedades.ShowItemToolTips = True
        Me.listviewPropiedades.Size = New System.Drawing.Size(418, 116)
        Me.listviewPropiedades.TabIndex = 1
        Me.listviewPropiedades.UseCompatibleStateImageBehavior = False
        Me.listviewPropiedades.View = System.Windows.Forms.View.Details
        '
        'columnPropiedad
        '
        Me.columnPropiedad.Text = "Propiedad"
        Me.columnPropiedad.Width = 95
        '
        'columnValor
        '
        Me.columnValor.Text = "Valor"
        Me.columnValor.Width = 315
        '
        'pictureboxIcon
        '
        Me.pictureboxIcon.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SENAL_ESCUELA_152
        Me.pictureboxIcon.Location = New System.Drawing.Point(12, 12)
        Me.pictureboxIcon.Name = "pictureboxIcon"
        Me.pictureboxIcon.Size = New System.Drawing.Size(90, 96)
        Me.pictureboxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureboxIcon.TabIndex = 0
        Me.pictureboxIcon.TabStop = False
        '
        'labelLicensedTo
        '
        Me.labelLicensedTo.BackColor = System.Drawing.Color.Transparent
        Me.labelLicensedTo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.labelLicensedTo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelLicensedTo.ForeColor = System.Drawing.SystemColors.ControlText
        Me.labelLicensedTo.Location = New System.Drawing.Point(12, 111)
        Me.labelLicensedTo.Name = "labelLicensedTo"
        Me.labelLicensedTo.Size = New System.Drawing.Size(418, 31)
        Me.labelLicensedTo.TabIndex = 6
        Me.labelLicensedTo.Text = "LicensedTo"
        Me.labelLicensedTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'formAboutBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.OKButton
        Me.ClientSize = New System.Drawing.Size(442, 302)
        Me.Controls.Add(Me.labelLicensedTo)
        Me.Controls.Add(Me.pictureboxIcon)
        Me.Controls.Add(Me.labelApplicationTitle)
        Me.Controls.Add(Me.LabelVersion)
        Me.Controls.Add(Me.LabelCopyright)
        Me.Controls.Add(Me.listviewPropiedades)
        Me.Controls.Add(Me.OKButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formAboutBox"
        Me.Padding = New System.Windows.Forms.Padding(9)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "formAboutBox"
        CType(Me.pictureboxIcon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents listviewPropiedades As System.Windows.Forms.ListView
    Friend WithEvents columnPropiedad As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnValor As System.Windows.Forms.ColumnHeader
    Friend WithEvents pictureboxIcon As System.Windows.Forms.PictureBox
    Friend WithEvents labelLicensedTo As System.Windows.Forms.Label

End Class
