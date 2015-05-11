<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TempDepot
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
        Me.panelPaso4 = New System.Windows.Forms.Panel()
        Me.labelPaso4Titulo = New System.Windows.Forms.Label()
        Me.buttonPaso4Anterior = New System.Windows.Forms.Button()
        Me.buttonPaso4Siguiente = New System.Windows.Forms.Button()
        Me.panelPaso5 = New System.Windows.Forms.Panel()
        Me.labelPaso5Titulo = New System.Windows.Forms.Label()
        Me.buttonPaso5Anterior = New System.Windows.Forms.Button()
        Me.buttonPaso5Siguiente = New System.Windows.Forms.Button()
        Me.panelPaso4.SuspendLayout()
        Me.panelPaso5.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelPaso4
        '
        Me.panelPaso4.Controls.Add(Me.labelPaso4Titulo)
        Me.panelPaso4.Controls.Add(Me.buttonPaso4Anterior)
        Me.panelPaso4.Controls.Add(Me.buttonPaso4Siguiente)
        Me.panelPaso4.Location = New System.Drawing.Point(647, 12)
        Me.panelPaso4.Name = "panelPaso4"
        Me.panelPaso4.Size = New System.Drawing.Size(294, 237)
        Me.panelPaso4.TabIndex = 102
        '
        'labelPaso4Titulo
        '
        Me.labelPaso4Titulo.AutoSize = True
        Me.labelPaso4Titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.labelPaso4Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPaso4Titulo.Location = New System.Drawing.Point(0, 0)
        Me.labelPaso4Titulo.Name = "labelPaso4Titulo"
        Me.labelPaso4Titulo.Size = New System.Drawing.Size(124, 17)
        Me.labelPaso4Titulo.TabIndex = 106
        Me.labelPaso4Titulo.Text = "Paso 4: Emisión"
        '
        'buttonPaso4Anterior
        '
        Me.buttonPaso4Anterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso4Anterior.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_PREVIOUS_24
        Me.buttonPaso4Anterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso4Anterior.Location = New System.Drawing.Point(5, 200)
        Me.buttonPaso4Anterior.Name = "buttonPaso4Anterior"
        Me.buttonPaso4Anterior.Size = New System.Drawing.Size(140, 34)
        Me.buttonPaso4Anterior.TabIndex = 99
        Me.buttonPaso4Anterior.Text = "Paso 3: Confirmación"
        Me.buttonPaso4Anterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso4Anterior.UseVisualStyleBackColor = True
        '
        'buttonPaso4Siguiente
        '
        Me.buttonPaso4Siguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso4Siguiente.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_NEXT_24
        Me.buttonPaso4Siguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso4Siguiente.Location = New System.Drawing.Point(151, 200)
        Me.buttonPaso4Siguiente.Name = "buttonPaso4Siguiente"
        Me.buttonPaso4Siguiente.Size = New System.Drawing.Size(140, 34)
        Me.buttonPaso4Siguiente.TabIndex = 98
        Me.buttonPaso4Siguiente.Text = "Paso 5: Transmisión"
        Me.buttonPaso4Siguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso4Siguiente.UseVisualStyleBackColor = True
        '
        'panelPaso5
        '
        Me.panelPaso5.Controls.Add(Me.labelPaso5Titulo)
        Me.panelPaso5.Controls.Add(Me.buttonPaso5Anterior)
        Me.panelPaso5.Controls.Add(Me.buttonPaso5Siguiente)
        Me.panelPaso5.Location = New System.Drawing.Point(963, 12)
        Me.panelPaso5.Name = "panelPaso5"
        Me.panelPaso5.Size = New System.Drawing.Size(294, 237)
        Me.panelPaso5.TabIndex = 103
        '
        'labelPaso5Titulo
        '
        Me.labelPaso5Titulo.AutoSize = True
        Me.labelPaso5Titulo.Dock = System.Windows.Forms.DockStyle.Top
        Me.labelPaso5Titulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPaso5Titulo.Location = New System.Drawing.Point(0, 0)
        Me.labelPaso5Titulo.Name = "labelPaso5Titulo"
        Me.labelPaso5Titulo.Size = New System.Drawing.Size(156, 17)
        Me.labelPaso5Titulo.TabIndex = 106
        Me.labelPaso5Titulo.Text = "Paso 5: Transmisión"
        '
        'buttonPaso5Anterior
        '
        Me.buttonPaso5Anterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso5Anterior.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_PREVIOUS_24
        Me.buttonPaso5Anterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso5Anterior.Location = New System.Drawing.Point(5, 200)
        Me.buttonPaso5Anterior.Name = "buttonPaso5Anterior"
        Me.buttonPaso5Anterior.Size = New System.Drawing.Size(140, 34)
        Me.buttonPaso5Anterior.TabIndex = 99
        Me.buttonPaso5Anterior.Text = "Paso 4: Emisión"
        Me.buttonPaso5Anterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso5Anterior.UseVisualStyleBackColor = True
        '
        'buttonPaso5Siguiente
        '
        Me.buttonPaso5Siguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso5Siguiente.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_NEXT_24
        Me.buttonPaso5Siguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso5Siguiente.Location = New System.Drawing.Point(151, 200)
        Me.buttonPaso5Siguiente.Name = "buttonPaso5Siguiente"
        Me.buttonPaso5Siguiente.Size = New System.Drawing.Size(140, 34)
        Me.buttonPaso5Siguiente.TabIndex = 98
        Me.buttonPaso5Siguiente.Text = "Paso 6: Envío Mails"
        Me.buttonPaso5Siguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso5Siguiente.UseVisualStyleBackColor = True
        '
        'TempDepot
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1272, 265)
        Me.Controls.Add(Me.panelPaso5)
        Me.Controls.Add(Me.panelPaso4)
        Me.Name = "TempDepot"
        Me.Text = "TempDepot"
        Me.panelPaso4.ResumeLayout(False)
        Me.panelPaso4.PerformLayout()
        Me.panelPaso5.ResumeLayout(False)
        Me.panelPaso5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelPaso4 As System.Windows.Forms.Panel
    Friend WithEvents labelPaso4Titulo As System.Windows.Forms.Label
    Friend WithEvents buttonPaso4Anterior As System.Windows.Forms.Button
    Friend WithEvents buttonPaso4Siguiente As System.Windows.Forms.Button
    Friend WithEvents panelPaso5 As System.Windows.Forms.Panel
    Friend WithEvents labelPaso5Titulo As System.Windows.Forms.Label
    Friend WithEvents buttonPaso5Anterior As System.Windows.Forms.Button
    Friend WithEvents buttonPaso5Siguiente As System.Windows.Forms.Button
End Class
