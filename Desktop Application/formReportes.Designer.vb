<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formReportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formReportes))
        Me.treeviewReportes = New System.Windows.Forms.TreeView()
        Me.buttonImprimir = New System.Windows.Forms.Button()
        Me.buttonPrevisualizar = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'treeviewReportes
        '
        Me.treeviewReportes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.treeviewReportes.Location = New System.Drawing.Point(12, 12)
        Me.treeviewReportes.Name = "treeviewReportes"
        Me.treeviewReportes.Size = New System.Drawing.Size(553, 336)
        Me.treeviewReportes.TabIndex = 0
        '
        'buttonImprimir
        '
        Me.buttonImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonImprimir.Image = CType(resources.GetObject("buttonImprimir.Image"), System.Drawing.Image)
        Me.buttonImprimir.Location = New System.Drawing.Point(319, 354)
        Me.buttonImprimir.Name = "buttonImprimir"
        Me.buttonImprimir.Size = New System.Drawing.Size(120, 44)
        Me.buttonImprimir.TabIndex = 1
        Me.buttonImprimir.Text = "Imprimir"
        Me.buttonImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.buttonImprimir.UseVisualStyleBackColor = True
        '
        'buttonPrevisualizar
        '
        Me.buttonPrevisualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPrevisualizar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_PRINT_PREVIEW_32
        Me.buttonPrevisualizar.Location = New System.Drawing.Point(445, 354)
        Me.buttonPrevisualizar.Name = "buttonPrevisualizar"
        Me.buttonPrevisualizar.Size = New System.Drawing.Size(120, 44)
        Me.buttonPrevisualizar.TabIndex = 2
        Me.buttonPrevisualizar.Text = "Previsualizar"
        Me.buttonPrevisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.buttonPrevisualizar.UseVisualStyleBackColor = True
        '
        'formReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 410)
        Me.Controls.Add(Me.buttonPrevisualizar)
        Me.Controls.Add(Me.buttonImprimir)
        Me.Controls.Add(Me.treeviewReportes)
        Me.Name = "formReportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reportes"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents treeviewReportes As System.Windows.Forms.TreeView
    Friend WithEvents buttonImprimir As System.Windows.Forms.Button
    Friend WithEvents buttonPrevisualizar As System.Windows.Forms.Button
End Class
