<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormEntidadPersonalColegioAntiguedadDetalle
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
        Me.ToolStripMain = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.TableLayoutPanelMain = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelInstitucion = New System.Windows.Forms.Label()
        Me.TextBoxInstitucion = New System.Windows.Forms.TextBox()
        Me.LabelFechaDesde = New System.Windows.Forms.Label()
        Me.DateTimePickerFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.LabelFechaHasta = New System.Windows.Forms.Label()
        Me.DateTimePickerFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.ToolStripMain.SuspendLayout()
        Me.TableLayoutPanelMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripMain
        '
        Me.ToolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonCerrar, Me.ToolStripButtonEditar, Me.ToolStripButtonCancelar, Me.ToolStripButtonGuardar})
        Me.ToolStripMain.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripMain.Name = "ToolStripMain"
        Me.ToolStripMain.Size = New System.Drawing.Size(462, 39)
        Me.ToolStripMain.TabIndex = 1
        '
        'ToolStripButtonCerrar
        '
        Me.ToolStripButtonCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonCerrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_32
        Me.ToolStripButtonCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonCerrar.Name = "ToolStripButtonCerrar"
        Me.ToolStripButtonCerrar.Size = New System.Drawing.Size(85, 36)
        Me.ToolStripButtonCerrar.Text = "Cerrar"
        '
        'ToolStripButtonEditar
        '
        Me.ToolStripButtonEditar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonEditar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_EDIT_32
        Me.ToolStripButtonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonEditar.Name = "ToolStripButtonEditar"
        Me.ToolStripButtonEditar.Size = New System.Drawing.Size(84, 36)
        Me.ToolStripButtonEditar.Text = "Editar"
        '
        'ToolStripButtonCancelar
        '
        Me.ToolStripButtonCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonCancelar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageCancelar32
        Me.ToolStripButtonCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonCancelar.Name = "ToolStripButtonCancelar"
        Me.ToolStripButtonCancelar.Size = New System.Drawing.Size(102, 36)
        Me.ToolStripButtonCancelar.Text = "Cancelar"
        '
        'ToolStripButtonGuardar
        '
        Me.ToolStripButtonGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonGuardar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageAceptar32
        Me.ToolStripButtonGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonGuardar.Name = "ToolStripButtonGuardar"
        Me.ToolStripButtonGuardar.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButtonGuardar.Text = "Guardar"
        '
        'TableLayoutPanelMain
        '
        Me.TableLayoutPanelMain.AutoSize = True
        Me.TableLayoutPanelMain.ColumnCount = 2
        Me.TableLayoutPanelMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelMain.Controls.Add(Me.LabelInstitucion, 0, 0)
        Me.TableLayoutPanelMain.Controls.Add(Me.TextBoxInstitucion, 1, 0)
        Me.TableLayoutPanelMain.Controls.Add(Me.LabelFechaDesde, 0, 1)
        Me.TableLayoutPanelMain.Controls.Add(Me.DateTimePickerFechaDesde, 1, 1)
        Me.TableLayoutPanelMain.Controls.Add(Me.LabelFechaHasta, 0, 2)
        Me.TableLayoutPanelMain.Controls.Add(Me.DateTimePickerFechaHasta, 1, 2)
        Me.TableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanelMain.Location = New System.Drawing.Point(0, 39)
        Me.TableLayoutPanelMain.Name = "TableLayoutPanelMain"
        Me.TableLayoutPanelMain.RowCount = 4
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelMain.Size = New System.Drawing.Size(462, 105)
        Me.TableLayoutPanelMain.TabIndex = 0
        '
        'LabelInstitucion
        '
        Me.LabelInstitucion.AutoSize = True
        Me.LabelInstitucion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelInstitucion.Location = New System.Drawing.Point(4, 0)
        Me.LabelInstitucion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelInstitucion.Name = "LabelInstitucion"
        Me.LabelInstitucion.Size = New System.Drawing.Size(90, 30)
        Me.LabelInstitucion.TabIndex = 0
        Me.LabelInstitucion.Text = "Institución:"
        Me.LabelInstitucion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBoxInstitucion
        '
        Me.TextBoxInstitucion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxInstitucion.Location = New System.Drawing.Point(102, 4)
        Me.TextBoxInstitucion.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxInstitucion.MaxLength = 50
        Me.TextBoxInstitucion.Name = "TextBoxInstitucion"
        Me.TextBoxInstitucion.Size = New System.Drawing.Size(356, 22)
        Me.TextBoxInstitucion.TabIndex = 1
        '
        'LabelFechaDesde
        '
        Me.LabelFechaDesde.AutoSize = True
        Me.LabelFechaDesde.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelFechaDesde.Location = New System.Drawing.Point(4, 30)
        Me.LabelFechaDesde.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelFechaDesde.Name = "LabelFechaDesde"
        Me.LabelFechaDesde.Size = New System.Drawing.Size(90, 30)
        Me.LabelFechaDesde.TabIndex = 2
        Me.LabelFechaDesde.Text = "Fecha desde:"
        Me.LabelFechaDesde.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePickerFechaDesde
        '
        Me.DateTimePickerFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerFechaDesde.Location = New System.Drawing.Point(102, 34)
        Me.DateTimePickerFechaDesde.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePickerFechaDesde.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.DateTimePickerFechaDesde.MinDate = New Date(1940, 1, 1, 0, 0, 0, 0)
        Me.DateTimePickerFechaDesde.Name = "DateTimePickerFechaDesde"
        Me.DateTimePickerFechaDesde.Size = New System.Drawing.Size(145, 22)
        Me.DateTimePickerFechaDesde.TabIndex = 3
        '
        'LabelFechaHasta
        '
        Me.LabelFechaHasta.AutoSize = True
        Me.LabelFechaHasta.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelFechaHasta.Location = New System.Drawing.Point(4, 60)
        Me.LabelFechaHasta.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelFechaHasta.Name = "LabelFechaHasta"
        Me.LabelFechaHasta.Size = New System.Drawing.Size(90, 30)
        Me.LabelFechaHasta.TabIndex = 4
        Me.LabelFechaHasta.Text = "Fecha hasta:"
        Me.LabelFechaHasta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DateTimePickerFechaHasta
        '
        Me.DateTimePickerFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerFechaHasta.Location = New System.Drawing.Point(102, 64)
        Me.DateTimePickerFechaHasta.Margin = New System.Windows.Forms.Padding(4)
        Me.DateTimePickerFechaHasta.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.DateTimePickerFechaHasta.MinDate = New Date(1940, 1, 1, 0, 0, 0, 0)
        Me.DateTimePickerFechaHasta.Name = "DateTimePickerFechaHasta"
        Me.DateTimePickerFechaHasta.ShowCheckBox = True
        Me.DateTimePickerFechaHasta.Size = New System.Drawing.Size(171, 22)
        Me.DateTimePickerFechaHasta.TabIndex = 5
        '
        'FormEntidadPersonalColegioAntiguedadDetalle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(462, 144)
        Me.Controls.Add(Me.TableLayoutPanelMain)
        Me.Controls.Add(Me.ToolStripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormEntidadPersonalColegioAntiguedadDetalle"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Detalle de antigüedad del empleado"
        Me.ToolStripMain.ResumeLayout(False)
        Me.ToolStripMain.PerformLayout()
        Me.TableLayoutPanelMain.ResumeLayout(False)
        Me.TableLayoutPanelMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents TableLayoutPanelMain As TableLayoutPanel
    Friend WithEvents LabelInstitucion As Label
    Friend WithEvents TextBoxInstitucion As TextBox
    Friend WithEvents LabelFechaDesde As Label
    Friend WithEvents DateTimePickerFechaDesde As DateTimePicker
    Friend WithEvents LabelFechaHasta As Label
    Friend WithEvents DateTimePickerFechaHasta As DateTimePicker
End Class
