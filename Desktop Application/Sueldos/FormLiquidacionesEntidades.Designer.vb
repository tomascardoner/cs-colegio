<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLiquidacionesEntidades
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripStatusLabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStripMain = New System.Windows.Forms.StatusStrip()
        Me.FlowLayoutPanelToolbars = New System.Windows.Forms.FlowLayoutPanel()
        Me.ToolStripButtons = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonAgregar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabelLiquidacionDatos = New System.Windows.Forms.ToolStripLabel()
        Me.DataGridViewMain = New System.Windows.Forms.DataGridView()
        Me.DataGridViewColumnEntidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnModuloCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnAntiguedad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripButtonCopiarDatos = New System.Windows.Forms.ToolStripButton()
        Me.StatusStripMain.SuspendLayout()
        Me.FlowLayoutPanelToolbars.SuspendLayout()
        Me.ToolStripButtons.SuspendLayout()
        CType(Me.DataGridViewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripStatusLabelMain
        '
        Me.ToolStripStatusLabelMain.Name = "ToolStripStatusLabelMain"
        Me.ToolStripStatusLabelMain.Size = New System.Drawing.Size(919, 16)
        Me.ToolStripStatusLabelMain.Spring = True
        Me.ToolStripStatusLabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStripMain
        '
        Me.StatusStripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelMain})
        Me.StatusStripMain.Location = New System.Drawing.Point(0, 454)
        Me.StatusStripMain.Name = "StatusStripMain"
        Me.StatusStripMain.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripMain.Size = New System.Drawing.Size(939, 22)
        Me.StatusStripMain.TabIndex = 4
        '
        'FlowLayoutPanelToolbars
        '
        Me.FlowLayoutPanelToolbars.AutoSize = True
        Me.FlowLayoutPanelToolbars.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanelToolbars.Controls.Add(Me.ToolStripButtons)
        Me.FlowLayoutPanelToolbars.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanelToolbars.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanelToolbars.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanelToolbars.Name = "FlowLayoutPanelToolbars"
        Me.FlowLayoutPanelToolbars.Size = New System.Drawing.Size(939, 39)
        Me.FlowLayoutPanelToolbars.TabIndex = 0
        '
        'ToolStripButtons
        '
        Me.ToolStripButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripButtons.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonAgregar, Me.ToolStripButtonEditar, Me.ToolStripButtonEliminar, Me.ToolStripButtonCopiarDatos, Me.ToolStripSeparator1, Me.ToolStripLabelLiquidacionDatos})
        Me.ToolStripButtons.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripButtons.Name = "ToolStripButtons"
        Me.ToolStripButtons.Size = New System.Drawing.Size(460, 39)
        Me.ToolStripButtons.TabIndex = 1
        '
        'ToolStripButtonAgregar
        '
        Me.ToolStripButtonAgregar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_ADD_32
        Me.ToolStripButtonAgregar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAgregar.Name = "ToolStripButtonAgregar"
        Me.ToolStripButtonAgregar.Size = New System.Drawing.Size(99, 36)
        Me.ToolStripButtonAgregar.Text = "Agregar"
        '
        'ToolStripButtonEditar
        '
        Me.ToolStripButtonEditar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_EDIT_32
        Me.ToolStripButtonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonEditar.Name = "ToolStripButtonEditar"
        Me.ToolStripButtonEditar.Size = New System.Drawing.Size(84, 36)
        Me.ToolStripButtonEditar.Text = "Editar"
        '
        'ToolStripButtonEliminar
        '
        Me.ToolStripButtonEliminar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_DELETE_32
        Me.ToolStripButtonEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonEliminar.Name = "ToolStripButtonEliminar"
        Me.ToolStripButtonEliminar.Size = New System.Drawing.Size(99, 36)
        Me.ToolStripButtonEliminar.Text = "Eliminar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'ToolStripLabelLiquidacionDatos
        '
        Me.ToolStripLabelLiquidacionDatos.Name = "ToolStripLabelLiquidacionDatos"
        Me.ToolStripLabelLiquidacionDatos.Size = New System.Drawing.Size(0, 36)
        '
        'DataGridViewMain
        '
        Me.DataGridViewMain.AllowUserToAddRows = False
        Me.DataGridViewMain.AllowUserToDeleteRows = False
        Me.DataGridViewMain.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridViewMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewColumnEntidad, Me.DataGridViewColumnModuloCantidad, Me.DataGridViewColumnAntiguedad})
        Me.DataGridViewMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridViewMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridViewMain.Location = New System.Drawing.Point(0, 39)
        Me.DataGridViewMain.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridViewMain.MultiSelect = False
        Me.DataGridViewMain.Name = "DataGridViewMain"
        Me.DataGridViewMain.ReadOnly = True
        Me.DataGridViewMain.RowHeadersVisible = False
        Me.DataGridViewMain.RowHeadersWidth = 51
        Me.DataGridViewMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DataGridViewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridViewMain.Size = New System.Drawing.Size(939, 415)
        Me.DataGridViewMain.TabIndex = 0
        '
        'DataGridViewColumnEntidad
        '
        Me.DataGridViewColumnEntidad.DataPropertyName = "EntidadApellidoNombre"
        Me.DataGridViewColumnEntidad.HeaderText = "Personal"
        Me.DataGridViewColumnEntidad.MinimumWidth = 6
        Me.DataGridViewColumnEntidad.Name = "DataGridViewColumnEntidad"
        Me.DataGridViewColumnEntidad.ReadOnly = True
        Me.DataGridViewColumnEntidad.Width = 90
        '
        'DataGridViewColumnModuloCantidad
        '
        Me.DataGridViewColumnModuloCantidad.DataPropertyName = "ModuloCantidad"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.Format = "#.##"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.DataGridViewColumnModuloCantidad.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewColumnModuloCantidad.HeaderText = "Módulos"
        Me.DataGridViewColumnModuloCantidad.MinimumWidth = 6
        Me.DataGridViewColumnModuloCantidad.Name = "DataGridViewColumnModuloCantidad"
        Me.DataGridViewColumnModuloCantidad.ReadOnly = True
        Me.DataGridViewColumnModuloCantidad.Width = 88
        '
        'DataGridViewColumnAntiguedad
        '
        Me.DataGridViewColumnAntiguedad.DataPropertyName = "Antiguedad"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.Format = "0%"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewColumnAntiguedad.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewColumnAntiguedad.HeaderText = "Antigüedad"
        Me.DataGridViewColumnAntiguedad.MinimumWidth = 6
        Me.DataGridViewColumnAntiguedad.Name = "DataGridViewColumnAntiguedad"
        Me.DataGridViewColumnAntiguedad.ReadOnly = True
        Me.DataGridViewColumnAntiguedad.Width = 105
        '
        'ToolStripButtonCopiarDatos
        '
        Me.ToolStripButtonCopiarDatos.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_COPY_32
        Me.ToolStripButtonCopiarDatos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonCopiarDatos.Name = "ToolStripButtonCopiarDatos"
        Me.ToolStripButtonCopiarDatos.Size = New System.Drawing.Size(130, 36)
        Me.ToolStripButtonCopiarDatos.Text = "Copiar datos"
        '
        'FormLiquidacionesEntidades
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(939, 476)
        Me.Controls.Add(Me.DataGridViewMain)
        Me.Controls.Add(Me.FlowLayoutPanelToolbars)
        Me.Controls.Add(Me.StatusStripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormLiquidacionesEntidades"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Liquidaciones de sueldos de entidades"
        Me.StatusStripMain.ResumeLayout(False)
        Me.StatusStripMain.PerformLayout()
        Me.FlowLayoutPanelToolbars.ResumeLayout(False)
        Me.FlowLayoutPanelToolbars.PerformLayout()
        Me.ToolStripButtons.ResumeLayout(False)
        Me.ToolStripButtons.PerformLayout()
        CType(Me.DataGridViewMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripStatusLabelMain As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents FlowLayoutPanelToolbars As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ToolStripButtons As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButtonAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents DataGridViewMain As DataGridView
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabelLiquidacionDatos As ToolStripLabel
    Friend WithEvents DataGridViewColumnEntidad As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnModuloCantidad As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnAntiguedad As DataGridViewTextBoxColumn
    Friend WithEvents ToolStripButtonCopiarDatos As ToolStripButton
End Class
