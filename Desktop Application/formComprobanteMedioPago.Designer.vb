<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formComprobanteMedioPago
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
        Me.labelMedioPago = New System.Windows.Forms.Label()
        Me.comboboxMedioPago = New System.Windows.Forms.ComboBox()
        Me.comboboxCaja = New System.Windows.Forms.ComboBox()
        Me.labelCaja = New System.Windows.Forms.Label()
        Me.labelImporte = New System.Windows.Forms.Label()
        Me.textboxImporte = New System.Windows.Forms.TextBox()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelMedioPago
        '
        Me.labelMedioPago.AutoSize = True
        Me.labelMedioPago.Location = New System.Drawing.Point(9, 45)
        Me.labelMedioPago.Name = "labelMedioPago"
        Me.labelMedioPago.Size = New System.Drawing.Size(82, 13)
        Me.labelMedioPago.TabIndex = 0
        Me.labelMedioPago.Text = "Medio de Pago:"
        '
        'comboboxMedioPago
        '
        Me.comboboxMedioPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxMedioPago.FormattingEnabled = True
        Me.comboboxMedioPago.Location = New System.Drawing.Point(97, 42)
        Me.comboboxMedioPago.Name = "comboboxMedioPago"
        Me.comboboxMedioPago.Size = New System.Drawing.Size(178, 21)
        Me.comboboxMedioPago.TabIndex = 1
        '
        'comboboxCaja
        '
        Me.comboboxCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCaja.FormattingEnabled = True
        Me.comboboxCaja.Location = New System.Drawing.Point(97, 69)
        Me.comboboxCaja.Name = "comboboxCaja"
        Me.comboboxCaja.Size = New System.Drawing.Size(178, 21)
        Me.comboboxCaja.TabIndex = 3
        '
        'labelCaja
        '
        Me.labelCaja.AutoSize = True
        Me.labelCaja.Location = New System.Drawing.Point(9, 72)
        Me.labelCaja.Name = "labelCaja"
        Me.labelCaja.Size = New System.Drawing.Size(31, 13)
        Me.labelCaja.TabIndex = 2
        Me.labelCaja.Text = "Caja:"
        '
        'labelImporte
        '
        Me.labelImporte.AutoSize = True
        Me.labelImporte.Location = New System.Drawing.Point(9, 104)
        Me.labelImporte.Name = "labelImporte"
        Me.labelImporte.Size = New System.Drawing.Size(45, 13)
        Me.labelImporte.TabIndex = 4
        Me.labelImporte.Text = "Importe:"
        '
        'textboxImporte
        '
        Me.textboxImporte.Location = New System.Drawing.Point(97, 101)
        Me.textboxImporte.Name = "textboxImporte"
        Me.textboxImporte.Size = New System.Drawing.Size(100, 20)
        Me.textboxImporte.TabIndex = 5
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(344, 39)
        Me.toolstripMain.TabIndex = 7
        '
        'buttonCerrar
        '
        Me.buttonCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonCerrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_32
        Me.buttonCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCerrar.Name = "buttonCerrar"
        Me.buttonCerrar.Size = New System.Drawing.Size(75, 36)
        Me.buttonCerrar.Text = "Cerrar"
        '
        'buttonEditar
        '
        Me.buttonEditar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonEditar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_EDIT_32
        Me.buttonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEditar.Name = "buttonEditar"
        Me.buttonEditar.Size = New System.Drawing.Size(73, 36)
        Me.buttonEditar.Text = "Editar"
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
        'formComprobanteMedioPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 139)
        Me.Controls.Add(Me.toolstripMain)
        Me.Controls.Add(Me.textboxImporte)
        Me.Controls.Add(Me.labelImporte)
        Me.Controls.Add(Me.comboboxCaja)
        Me.Controls.Add(Me.labelCaja)
        Me.Controls.Add(Me.comboboxMedioPago)
        Me.Controls.Add(Me.labelMedioPago)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "formComprobanteMedioPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Detalle del Medio de Pago"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelMedioPago As System.Windows.Forms.Label
    Friend WithEvents comboboxMedioPago As System.Windows.Forms.ComboBox
    Friend WithEvents comboboxCaja As System.Windows.Forms.ComboBox
    Friend WithEvents labelCaja As System.Windows.Forms.Label
    Friend WithEvents labelImporte As System.Windows.Forms.Label
    Friend WithEvents textboxImporte As System.Windows.Forms.TextBox
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
End Class
