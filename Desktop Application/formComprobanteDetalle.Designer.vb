<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formComprobanteDetalle
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
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.labelArticulo = New System.Windows.Forms.Label()
        Me.comboboxArticulo = New System.Windows.Forms.ComboBox()
        Me.buttonAlumno = New System.Windows.Forms.Button()
        Me.labelAlumno = New System.Windows.Forms.Label()
        Me.comboboxAnioLectivoCurso = New System.Windows.Forms.ComboBox()
        Me.labelAnioLectivoCurso = New System.Windows.Forms.Label()
        Me.comboboxCuotaMes = New System.Windows.Forms.ComboBox()
        Me.labelCuotaMes = New System.Windows.Forms.Label()
        Me.labelCantidad = New System.Windows.Forms.Label()
        Me.textboxCantidad = New System.Windows.Forms.TextBox()
        Me.textboxUnidad = New System.Windows.Forms.TextBox()
        Me.labelUnidad = New System.Windows.Forms.Label()
        Me.textboxDescripcion = New System.Windows.Forms.TextBox()
        Me.labelDescripcion = New System.Windows.Forms.Label()
        Me.labelPrecioUnitario = New System.Windows.Forms.Label()
        Me.labelPrecioUnitarioDescuentoPorcentaje = New System.Windows.Forms.Label()
        Me.labelPrecioUnitarioDescuentoImporte = New System.Windows.Forms.Label()
        Me.labelPrecioUnitarioFinal = New System.Windows.Forms.Label()
        Me.labelPrecioTotal = New System.Windows.Forms.Label()
        Me.textboxPrecioUnitarioDescuentoPorcentaje = New System.Windows.Forms.TextBox()
        Me.textboxPrecioTotal = New CSColegio.DesktopApplication.CS_Control_TextBox_Currency()
        Me.textboxPrecioUnitarioFinal = New CSColegio.DesktopApplication.CS_Control_TextBox_Currency()
        Me.textboxPrecioUnitarioDescuentoImporte = New CSColegio.DesktopApplication.CS_Control_TextBox_Currency()
        Me.textboxPrecioUnitario = New CSColegio.DesktopApplication.CS_Control_TextBox_Currency()
        Me.comboboxAlumno = New System.Windows.Forms.ComboBox()
        Me.toolstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(476, 39)
        Me.toolstripMain.TabIndex = 25
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
        'labelArticulo
        '
        Me.labelArticulo.AutoSize = True
        Me.labelArticulo.Location = New System.Drawing.Point(12, 54)
        Me.labelArticulo.Name = "labelArticulo"
        Me.labelArticulo.Size = New System.Drawing.Size(47, 13)
        Me.labelArticulo.TabIndex = 0
        Me.labelArticulo.Text = "Artículo:"
        '
        'comboboxArticulo
        '
        Me.comboboxArticulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxArticulo.FormattingEnabled = True
        Me.comboboxArticulo.Location = New System.Drawing.Point(123, 51)
        Me.comboboxArticulo.Name = "comboboxArticulo"
        Me.comboboxArticulo.Size = New System.Drawing.Size(339, 21)
        Me.comboboxArticulo.TabIndex = 1
        '
        'buttonAlumno
        '
        Me.buttonAlumno.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonAlumno.Location = New System.Drawing.Point(440, 129)
        Me.buttonAlumno.Name = "buttonAlumno"
        Me.buttonAlumno.Size = New System.Drawing.Size(22, 23)
        Me.buttonAlumno.TabIndex = 8
        Me.buttonAlumno.Text = "…"
        Me.buttonAlumno.UseVisualStyleBackColor = True
        '
        'labelAlumno
        '
        Me.labelAlumno.AutoSize = True
        Me.labelAlumno.Location = New System.Drawing.Point(12, 133)
        Me.labelAlumno.Name = "labelAlumno"
        Me.labelAlumno.Size = New System.Drawing.Size(45, 13)
        Me.labelAlumno.TabIndex = 6
        Me.labelAlumno.Text = "Alumno:"
        '
        'comboboxAnioLectivoCurso
        '
        Me.comboboxAnioLectivoCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnioLectivoCurso.FormattingEnabled = True
        Me.comboboxAnioLectivoCurso.Location = New System.Drawing.Point(123, 157)
        Me.comboboxAnioLectivoCurso.Name = "comboboxAnioLectivoCurso"
        Me.comboboxAnioLectivoCurso.Size = New System.Drawing.Size(339, 21)
        Me.comboboxAnioLectivoCurso.TabIndex = 10
        '
        'labelAnioLectivoCurso
        '
        Me.labelAnioLectivoCurso.AutoSize = True
        Me.labelAnioLectivoCurso.Location = New System.Drawing.Point(12, 160)
        Me.labelAnioLectivoCurso.Name = "labelAnioLectivoCurso"
        Me.labelAnioLectivoCurso.Size = New System.Drawing.Size(105, 13)
        Me.labelAnioLectivoCurso.TabIndex = 9
        Me.labelAnioLectivoCurso.Text = "Año Lectivo y Curso:"
        '
        'comboboxCuotaMes
        '
        Me.comboboxCuotaMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCuotaMes.FormattingEnabled = True
        Me.comboboxCuotaMes.Location = New System.Drawing.Point(123, 184)
        Me.comboboxCuotaMes.Name = "comboboxCuotaMes"
        Me.comboboxCuotaMes.Size = New System.Drawing.Size(144, 21)
        Me.comboboxCuotaMes.TabIndex = 12
        '
        'labelCuotaMes
        '
        Me.labelCuotaMes.AutoSize = True
        Me.labelCuotaMes.Location = New System.Drawing.Point(12, 187)
        Me.labelCuotaMes.Name = "labelCuotaMes"
        Me.labelCuotaMes.Size = New System.Drawing.Size(67, 13)
        Me.labelCuotaMes.TabIndex = 11
        Me.labelCuotaMes.Text = "Cuota - Mes:"
        '
        'labelCantidad
        '
        Me.labelCantidad.AutoSize = True
        Me.labelCantidad.Location = New System.Drawing.Point(12, 81)
        Me.labelCantidad.Name = "labelCantidad"
        Me.labelCantidad.Size = New System.Drawing.Size(52, 13)
        Me.labelCantidad.TabIndex = 2
        Me.labelCantidad.Text = "Cantidad:"
        '
        'textboxCantidad
        '
        Me.textboxCantidad.Location = New System.Drawing.Point(123, 78)
        Me.textboxCantidad.MaxLength = 3
        Me.textboxCantidad.Name = "textboxCantidad"
        Me.textboxCantidad.Size = New System.Drawing.Size(69, 20)
        Me.textboxCantidad.TabIndex = 3
        Me.textboxCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'textboxUnidad
        '
        Me.textboxUnidad.Location = New System.Drawing.Point(123, 104)
        Me.textboxUnidad.MaxLength = 10
        Me.textboxUnidad.Name = "textboxUnidad"
        Me.textboxUnidad.Size = New System.Drawing.Size(69, 20)
        Me.textboxUnidad.TabIndex = 5
        '
        'labelUnidad
        '
        Me.labelUnidad.AutoSize = True
        Me.labelUnidad.Location = New System.Drawing.Point(12, 107)
        Me.labelUnidad.Name = "labelUnidad"
        Me.labelUnidad.Size = New System.Drawing.Size(44, 13)
        Me.labelUnidad.TabIndex = 4
        Me.labelUnidad.Text = "Unidad:"
        '
        'textboxDescripcion
        '
        Me.textboxDescripcion.Location = New System.Drawing.Point(123, 211)
        Me.textboxDescripcion.MaxLength = 100
        Me.textboxDescripcion.Name = "textboxDescripcion"
        Me.textboxDescripcion.ReadOnly = True
        Me.textboxDescripcion.Size = New System.Drawing.Size(339, 20)
        Me.textboxDescripcion.TabIndex = 14
        Me.textboxDescripcion.TabStop = False
        '
        'labelDescripcion
        '
        Me.labelDescripcion.AutoSize = True
        Me.labelDescripcion.Location = New System.Drawing.Point(12, 214)
        Me.labelDescripcion.Name = "labelDescripcion"
        Me.labelDescripcion.Size = New System.Drawing.Size(66, 13)
        Me.labelDescripcion.TabIndex = 13
        Me.labelDescripcion.Text = "Descripción:"
        '
        'labelPrecioUnitario
        '
        Me.labelPrecioUnitario.AutoSize = True
        Me.labelPrecioUnitario.Location = New System.Drawing.Point(12, 240)
        Me.labelPrecioUnitario.Name = "labelPrecioUnitario"
        Me.labelPrecioUnitario.Size = New System.Drawing.Size(79, 13)
        Me.labelPrecioUnitario.TabIndex = 15
        Me.labelPrecioUnitario.Text = "Precio Unitario:"
        '
        'labelPrecioUnitarioDescuentoPorcentaje
        '
        Me.labelPrecioUnitarioDescuentoPorcentaje.AutoSize = True
        Me.labelPrecioUnitarioDescuentoPorcentaje.Location = New System.Drawing.Point(12, 266)
        Me.labelPrecioUnitarioDescuentoPorcentaje.Name = "labelPrecioUnitarioDescuentoPorcentaje"
        Me.labelPrecioUnitarioDescuentoPorcentaje.Size = New System.Drawing.Size(73, 13)
        Me.labelPrecioUnitarioDescuentoPorcentaje.TabIndex = 17
        Me.labelPrecioUnitarioDescuentoPorcentaje.Text = "% Descuento:"
        '
        'labelPrecioUnitarioDescuentoImporte
        '
        Me.labelPrecioUnitarioDescuentoImporte.AutoSize = True
        Me.labelPrecioUnitarioDescuentoImporte.Location = New System.Drawing.Point(12, 292)
        Me.labelPrecioUnitarioDescuentoImporte.Name = "labelPrecioUnitarioDescuentoImporte"
        Me.labelPrecioUnitarioDescuentoImporte.Size = New System.Drawing.Size(100, 13)
        Me.labelPrecioUnitarioDescuentoImporte.TabIndex = 19
        Me.labelPrecioUnitarioDescuentoImporte.Text = "Importe Descuento:"
        '
        'labelPrecioUnitarioFinal
        '
        Me.labelPrecioUnitarioFinal.AutoSize = True
        Me.labelPrecioUnitarioFinal.Location = New System.Drawing.Point(12, 318)
        Me.labelPrecioUnitarioFinal.Name = "labelPrecioUnitarioFinal"
        Me.labelPrecioUnitarioFinal.Size = New System.Drawing.Size(104, 13)
        Me.labelPrecioUnitarioFinal.TabIndex = 21
        Me.labelPrecioUnitarioFinal.Text = "Precio Unitario Final:"
        '
        'labelPrecioTotal
        '
        Me.labelPrecioTotal.AutoSize = True
        Me.labelPrecioTotal.Location = New System.Drawing.Point(12, 344)
        Me.labelPrecioTotal.Name = "labelPrecioTotal"
        Me.labelPrecioTotal.Size = New System.Drawing.Size(67, 13)
        Me.labelPrecioTotal.TabIndex = 23
        Me.labelPrecioTotal.Text = "Precio Total:"
        '
        'textboxPrecioUnitarioDescuentoPorcentaje
        '
        Me.textboxPrecioUnitarioDescuentoPorcentaje.Location = New System.Drawing.Point(123, 263)
        Me.textboxPrecioUnitarioDescuentoPorcentaje.MaxLength = 5
        Me.textboxPrecioUnitarioDescuentoPorcentaje.Name = "textboxPrecioUnitarioDescuentoPorcentaje"
        Me.textboxPrecioUnitarioDescuentoPorcentaje.Size = New System.Drawing.Size(69, 20)
        Me.textboxPrecioUnitarioDescuentoPorcentaje.TabIndex = 18
        Me.textboxPrecioUnitarioDescuentoPorcentaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'textboxPrecioTotal
        '
        Me.textboxPrecioTotal.Location = New System.Drawing.Point(123, 341)
        Me.textboxPrecioTotal.MaxLength = 15
        Me.textboxPrecioTotal.Name = "textboxPrecioTotal"
        Me.textboxPrecioTotal.ReadOnly = True
        Me.textboxPrecioTotal.Size = New System.Drawing.Size(100, 20)
        Me.textboxPrecioTotal.TabIndex = 24
        Me.textboxPrecioTotal.TabStop = False
        Me.textboxPrecioTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'textboxPrecioUnitarioFinal
        '
        Me.textboxPrecioUnitarioFinal.Location = New System.Drawing.Point(123, 315)
        Me.textboxPrecioUnitarioFinal.MaxLength = 15
        Me.textboxPrecioUnitarioFinal.Name = "textboxPrecioUnitarioFinal"
        Me.textboxPrecioUnitarioFinal.ReadOnly = True
        Me.textboxPrecioUnitarioFinal.Size = New System.Drawing.Size(100, 20)
        Me.textboxPrecioUnitarioFinal.TabIndex = 22
        Me.textboxPrecioUnitarioFinal.TabStop = False
        Me.textboxPrecioUnitarioFinal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'textboxPrecioUnitarioDescuentoImporte
        '
        Me.textboxPrecioUnitarioDescuentoImporte.Location = New System.Drawing.Point(123, 289)
        Me.textboxPrecioUnitarioDescuentoImporte.MaxLength = 15
        Me.textboxPrecioUnitarioDescuentoImporte.Name = "textboxPrecioUnitarioDescuentoImporte"
        Me.textboxPrecioUnitarioDescuentoImporte.Size = New System.Drawing.Size(100, 20)
        Me.textboxPrecioUnitarioDescuentoImporte.TabIndex = 20
        Me.textboxPrecioUnitarioDescuentoImporte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'textboxPrecioUnitario
        '
        Me.textboxPrecioUnitario.Location = New System.Drawing.Point(123, 237)
        Me.textboxPrecioUnitario.MaxLength = 15
        Me.textboxPrecioUnitario.Name = "textboxPrecioUnitario"
        Me.textboxPrecioUnitario.Size = New System.Drawing.Size(100, 20)
        Me.textboxPrecioUnitario.TabIndex = 16
        Me.textboxPrecioUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'comboboxAlumno
        '
        Me.comboboxAlumno.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAlumno.FormattingEnabled = True
        Me.comboboxAlumno.Location = New System.Drawing.Point(123, 130)
        Me.comboboxAlumno.Name = "comboboxAlumno"
        Me.comboboxAlumno.Size = New System.Drawing.Size(317, 21)
        Me.comboboxAlumno.TabIndex = 7
        '
        'formComprobanteDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 374)
        Me.Controls.Add(Me.comboboxAlumno)
        Me.Controls.Add(Me.textboxPrecioUnitarioDescuentoPorcentaje)
        Me.Controls.Add(Me.textboxPrecioTotal)
        Me.Controls.Add(Me.labelPrecioTotal)
        Me.Controls.Add(Me.textboxPrecioUnitarioFinal)
        Me.Controls.Add(Me.labelPrecioUnitarioFinal)
        Me.Controls.Add(Me.textboxPrecioUnitarioDescuentoImporte)
        Me.Controls.Add(Me.labelPrecioUnitarioDescuentoImporte)
        Me.Controls.Add(Me.labelPrecioUnitarioDescuentoPorcentaje)
        Me.Controls.Add(Me.textboxPrecioUnitario)
        Me.Controls.Add(Me.labelPrecioUnitario)
        Me.Controls.Add(Me.labelDescripcion)
        Me.Controls.Add(Me.textboxDescripcion)
        Me.Controls.Add(Me.textboxUnidad)
        Me.Controls.Add(Me.labelUnidad)
        Me.Controls.Add(Me.textboxCantidad)
        Me.Controls.Add(Me.labelCantidad)
        Me.Controls.Add(Me.comboboxCuotaMes)
        Me.Controls.Add(Me.labelCuotaMes)
        Me.Controls.Add(Me.comboboxAnioLectivoCurso)
        Me.Controls.Add(Me.labelAnioLectivoCurso)
        Me.Controls.Add(Me.buttonAlumno)
        Me.Controls.Add(Me.labelAlumno)
        Me.Controls.Add(Me.comboboxArticulo)
        Me.Controls.Add(Me.labelArticulo)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formComprobanteDetalle"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents labelArticulo As System.Windows.Forms.Label
    Friend WithEvents comboboxArticulo As System.Windows.Forms.ComboBox
    Friend WithEvents buttonAlumno As System.Windows.Forms.Button
    Friend WithEvents labelAlumno As System.Windows.Forms.Label
    Friend WithEvents comboboxAnioLectivoCurso As System.Windows.Forms.ComboBox
    Friend WithEvents labelAnioLectivoCurso As System.Windows.Forms.Label
    Friend WithEvents comboboxCuotaMes As System.Windows.Forms.ComboBox
    Friend WithEvents labelCuotaMes As System.Windows.Forms.Label
    Friend WithEvents labelCantidad As System.Windows.Forms.Label
    Friend WithEvents textboxCantidad As System.Windows.Forms.TextBox
    Friend WithEvents textboxUnidad As System.Windows.Forms.TextBox
    Friend WithEvents labelUnidad As System.Windows.Forms.Label
    Friend WithEvents textboxDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents labelDescripcion As System.Windows.Forms.Label
    Friend WithEvents labelPrecioUnitario As System.Windows.Forms.Label
    Friend WithEvents textboxPrecioUnitario As CSColegio.DesktopApplication.CS_Control_TextBox_Currency
    Friend WithEvents labelPrecioUnitarioDescuentoPorcentaje As System.Windows.Forms.Label
    Friend WithEvents textboxPrecioUnitarioDescuentoImporte As CSColegio.DesktopApplication.CS_Control_TextBox_Currency
    Friend WithEvents labelPrecioUnitarioDescuentoImporte As System.Windows.Forms.Label
    Friend WithEvents textboxPrecioUnitarioFinal As CSColegio.DesktopApplication.CS_Control_TextBox_Currency
    Friend WithEvents labelPrecioUnitarioFinal As System.Windows.Forms.Label
    Friend WithEvents textboxPrecioTotal As CSColegio.DesktopApplication.CS_Control_TextBox_Currency
    Friend WithEvents labelPrecioTotal As System.Windows.Forms.Label
    Friend WithEvents textboxPrecioUnitarioDescuentoPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents comboboxAlumno As System.Windows.Forms.ComboBox
End Class
