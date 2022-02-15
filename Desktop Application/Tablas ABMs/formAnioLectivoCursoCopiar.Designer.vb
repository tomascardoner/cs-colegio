<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formAnioLectivoCursoCopiar
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
        Me.comboboxAnioLectivoOrigen = New System.Windows.Forms.ComboBox()
        Me.labelAnioLectivoOrigen = New System.Windows.Forms.Label()
        Me.comboboxAnioLectivoDestino = New System.Windows.Forms.ComboBox()
        Me.labelAnioLectivoDestino = New System.Windows.Forms.Label()
        Me.labelLeyenda = New System.Windows.Forms.Label()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'buttonGuardar
        '
        Me.buttonGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonGuardar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageAceptar32
        Me.buttonGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonGuardar.Name = "buttonGuardar"
        Me.buttonGuardar.Size = New System.Drawing.Size(85, 36)
        Me.buttonGuardar.Text = "Guardar"
        '
        'buttonCancelar
        '
        Me.buttonCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonCancelar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageCancelar32
        Me.buttonCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCancelar.Name = "buttonCancelar"
        Me.buttonCancelar.Size = New System.Drawing.Size(89, 36)
        Me.buttonCancelar.Text = "Cancelar"
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(371, 39)
        Me.toolstripMain.TabIndex = 10
        '
        'comboboxAnioLectivoOrigen
        '
        Me.comboboxAnioLectivoOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnioLectivoOrigen.FormattingEnabled = True
        Me.comboboxAnioLectivoOrigen.Location = New System.Drawing.Point(198, 99)
        Me.comboboxAnioLectivoOrigen.Name = "comboboxAnioLectivoOrigen"
        Me.comboboxAnioLectivoOrigen.Size = New System.Drawing.Size(59, 21)
        Me.comboboxAnioLectivoOrigen.TabIndex = 12
        '
        'labelAnioLectivoOrigen
        '
        Me.labelAnioLectivoOrigen.AutoSize = True
        Me.labelAnioLectivoOrigen.Location = New System.Drawing.Point(86, 102)
        Me.labelAnioLectivoOrigen.Name = "labelAnioLectivoOrigen"
        Me.labelAnioLectivoOrigen.Size = New System.Drawing.Size(101, 13)
        Me.labelAnioLectivoOrigen.TabIndex = 11
        Me.labelAnioLectivoOrigen.Text = "Año Lectivo Origen:"
        '
        'comboboxAnioLectivoDestino
        '
        Me.comboboxAnioLectivoDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnioLectivoDestino.FormattingEnabled = True
        Me.comboboxAnioLectivoDestino.Location = New System.Drawing.Point(198, 126)
        Me.comboboxAnioLectivoDestino.Name = "comboboxAnioLectivoDestino"
        Me.comboboxAnioLectivoDestino.Size = New System.Drawing.Size(59, 21)
        Me.comboboxAnioLectivoDestino.TabIndex = 14
        '
        'labelAnioLectivoDestino
        '
        Me.labelAnioLectivoDestino.AutoSize = True
        Me.labelAnioLectivoDestino.Location = New System.Drawing.Point(86, 129)
        Me.labelAnioLectivoDestino.Name = "labelAnioLectivoDestino"
        Me.labelAnioLectivoDestino.Size = New System.Drawing.Size(106, 13)
        Me.labelAnioLectivoDestino.TabIndex = 13
        Me.labelAnioLectivoDestino.Text = "Año Lectivo Destino:"
        '
        'labelLeyenda
        '
        Me.labelLeyenda.Location = New System.Drawing.Point(12, 49)
        Me.labelLeyenda.Name = "labelLeyenda"
        Me.labelLeyenda.Size = New System.Drawing.Size(347, 35)
        Me.labelLeyenda.TabIndex = 15
        Me.labelLeyenda.Text = "Se copiarán todos los Cursos del Año Lectivo Origen en el Año Lectivo Destino."
        '
        'formAnioLectivoCursoCopiar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(371, 163)
        Me.Controls.Add(Me.labelLeyenda)
        Me.Controls.Add(Me.comboboxAnioLectivoDestino)
        Me.Controls.Add(Me.labelAnioLectivoDestino)
        Me.Controls.Add(Me.comboboxAnioLectivoOrigen)
        Me.Controls.Add(Me.labelAnioLectivoOrigen)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formAnioLectivoCursoCopiar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Copiar Cursos de Año Lectivo"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents comboboxAnioLectivoOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents labelAnioLectivoOrigen As System.Windows.Forms.Label
    Friend WithEvents comboboxAnioLectivoDestino As System.Windows.Forms.ComboBox
    Friend WithEvents labelAnioLectivoDestino As System.Windows.Forms.Label
    Friend WithEvents labelLeyenda As System.Windows.Forms.Label
End Class
