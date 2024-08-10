<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLiquidaciones
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripStatusLabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStripMain = New System.Windows.Forms.StatusStrip()
        Me.FlowLayoutPanelToolbars = New System.Windows.Forms.FlowLayoutPanel()
        Me.ToolStripButtons = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonAgregar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEntidades = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripFiltroAnio = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabelAnio = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBoxAnio = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripFiltroMes = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabelMes = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBoxMes = New System.Windows.Forms.ToolStripComboBox()
        Me.DataGridViewMain = New System.Windows.Forms.DataGridView()
        Me.DataGridViewColumnMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnImporteMatricula = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnImporteCuota = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStripMain.SuspendLayout()
        Me.FlowLayoutPanelToolbars.SuspendLayout()
        Me.ToolStripButtons.SuspendLayout()
        Me.ToolStripFiltroAnio.SuspendLayout()
        Me.ToolStripFiltroMes.SuspendLayout()
        CType(Me.DataGridViewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripStatusLabelMain
        '
        Me.ToolStripStatusLabelMain.Name = "ToolStripStatusLabelMain"
        Me.ToolStripStatusLabelMain.Size = New System.Drawing.Size(760, 16)
        Me.ToolStripStatusLabelMain.Spring = True
        Me.ToolStripStatusLabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStripMain
        '
        Me.StatusStripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelMain})
        Me.StatusStripMain.Location = New System.Drawing.Point(0, 499)
        Me.StatusStripMain.Name = "StatusStripMain"
        Me.StatusStripMain.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripMain.Size = New System.Drawing.Size(780, 22)
        Me.StatusStripMain.TabIndex = 4
        '
        'FlowLayoutPanelToolbars
        '
        Me.FlowLayoutPanelToolbars.AutoSize = True
        Me.FlowLayoutPanelToolbars.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanelToolbars.Controls.Add(Me.ToolStripButtons)
        Me.FlowLayoutPanelToolbars.Controls.Add(Me.ToolStripFiltroAnio)
        Me.FlowLayoutPanelToolbars.Controls.Add(Me.ToolStripFiltroMes)
        Me.FlowLayoutPanelToolbars.Dock = System.Windows.Forms.DockStyle.Top
        Me.FlowLayoutPanelToolbars.Location = New System.Drawing.Point(0, 0)
        Me.FlowLayoutPanelToolbars.Margin = New System.Windows.Forms.Padding(4)
        Me.FlowLayoutPanelToolbars.Name = "FlowLayoutPanelToolbars"
        Me.FlowLayoutPanelToolbars.Size = New System.Drawing.Size(780, 39)
        Me.FlowLayoutPanelToolbars.TabIndex = 0
        '
        'ToolStripButtons
        '
        Me.ToolStripButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripButtons.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonAgregar, Me.ToolStripButtonEditar, Me.ToolStripButtonEliminar, Me.ToolStripButtonEntidades})
        Me.ToolStripButtons.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripButtons.Name = "ToolStripButtons"
        Me.ToolStripButtons.Size = New System.Drawing.Size(395, 39)
        Me.ToolStripButtons.TabIndex = 1
        '
        'ToolStripButtonAgregar
        '
        Me.ToolStripButtonAgregar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_ADD_32
        Me.ToolStripButtonAgregar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonAgregar.Name = "ToolStripButtonAgregar"
        Me.ToolStripButtonAgregar.Size = New System.Drawing.Size(99, 36)
        Me.ToolStripButtonAgregar.Text = "Agregar"
        '
        'ToolStripButtonEditar
        '
        Me.ToolStripButtonEditar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_EDIT_32
        Me.ToolStripButtonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonEditar.Name = "ToolStripButtonEditar"
        Me.ToolStripButtonEditar.Size = New System.Drawing.Size(84, 36)
        Me.ToolStripButtonEditar.Text = "Editar"
        '
        'ToolStripButtonEliminar
        '
        Me.ToolStripButtonEliminar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_DELETE_32
        Me.ToolStripButtonEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonEliminar.Name = "ToolStripButtonEliminar"
        Me.ToolStripButtonEliminar.Size = New System.Drawing.Size(99, 36)
        Me.ToolStripButtonEliminar.Text = "Eliminar"
        '
        'ToolStripButtonEntidades
        '
        Me.ToolStripButtonEntidades.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ENTIDADES_32
        Me.ToolStripButtonEntidades.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonEntidades.Name = "ToolStripButtonEntidades"
        Me.ToolStripButtonEntidades.Size = New System.Drawing.Size(110, 36)
        Me.ToolStripButtonEntidades.Text = "Entidades"
        '
        'ToolStripFiltroAnio
        '
        Me.ToolStripFiltroAnio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripFiltroAnio.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripFiltroAnio.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripFiltroAnio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabelAnio, Me.ToolStripComboBoxAnio})
        Me.ToolStripFiltroAnio.Location = New System.Drawing.Point(395, 0)
        Me.ToolStripFiltroAnio.Name = "ToolStripFiltroAnio"
        Me.ToolStripFiltroAnio.Size = New System.Drawing.Size(119, 39)
        Me.ToolStripFiltroAnio.TabIndex = 14
        '
        'ToolStripLabelAnio
        '
        Me.ToolStripLabelAnio.Name = "ToolStripLabelAnio"
        Me.ToolStripLabelAnio.Size = New System.Drawing.Size(39, 36)
        Me.ToolStripLabelAnio.Text = "Año:"
        '
        'ToolStripComboBoxAnio
        '
        Me.ToolStripComboBoxAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBoxAnio.Name = "ToolStripComboBoxAnio"
        Me.ToolStripComboBoxAnio.Size = New System.Drawing.Size(75, 39)
        '
        'ToolStripFiltroMes
        '
        Me.ToolStripFiltroMes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripFiltroMes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripFiltroMes.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripFiltroMes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabelMes, Me.ToolStripComboBoxMes})
        Me.ToolStripFiltroMes.Location = New System.Drawing.Point(514, 0)
        Me.ToolStripFiltroMes.Name = "ToolStripFiltroMes"
        Me.ToolStripFiltroMes.Size = New System.Drawing.Size(244, 39)
        Me.ToolStripFiltroMes.TabIndex = 15
        '
        'ToolStripLabelMes
        '
        Me.ToolStripLabelMes.Name = "ToolStripLabelMes"
        Me.ToolStripLabelMes.Size = New System.Drawing.Size(39, 36)
        Me.ToolStripLabelMes.Text = "Mes:"
        '
        'ToolStripComboBoxMes
        '
        Me.ToolStripComboBoxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBoxMes.Name = "ToolStripComboBoxMes"
        Me.ToolStripComboBoxMes.Size = New System.Drawing.Size(159, 39)
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
        Me.DataGridViewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewColumnMes, Me.DataGridViewColumnImporteMatricula, Me.DataGridViewColumnImporteCuota})
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
        Me.DataGridViewMain.Size = New System.Drawing.Size(780, 460)
        Me.DataGridViewMain.TabIndex = 0
        '
        'DataGridViewColumnMes
        '
        Me.DataGridViewColumnMes.DataPropertyName = "Mes"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewColumnMes.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridViewColumnMes.HeaderText = "Mes"
        Me.DataGridViewColumnMes.MinimumWidth = 6
        Me.DataGridViewColumnMes.Name = "DataGridViewColumnMes"
        Me.DataGridViewColumnMes.ReadOnly = True
        Me.DataGridViewColumnMes.Width = 62
        '
        'DataGridViewColumnImporteMatricula
        '
        Me.DataGridViewColumnImporteMatricula.DataPropertyName = "BaseAntiguedadImporte"
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewColumnImporteMatricula.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewColumnImporteMatricula.HeaderText = "Importe base antigüedad"
        Me.DataGridViewColumnImporteMatricula.MinimumWidth = 6
        Me.DataGridViewColumnImporteMatricula.Name = "DataGridViewColumnImporteMatricula"
        Me.DataGridViewColumnImporteMatricula.ReadOnly = True
        Me.DataGridViewColumnImporteMatricula.Width = 170
        '
        'DataGridViewColumnImporteCuota
        '
        Me.DataGridViewColumnImporteCuota.DataPropertyName = "ModuloImporte"
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewColumnImporteCuota.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewColumnImporteCuota.HeaderText = "Importe módulo"
        Me.DataGridViewColumnImporteCuota.MinimumWidth = 6
        Me.DataGridViewColumnImporteCuota.Name = "DataGridViewColumnImporteCuota"
        Me.DataGridViewColumnImporteCuota.ReadOnly = True
        Me.DataGridViewColumnImporteCuota.Width = 119
        '
        'FormLiquidaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(780, 521)
        Me.Controls.Add(Me.DataGridViewMain)
        Me.Controls.Add(Me.FlowLayoutPanelToolbars)
        Me.Controls.Add(Me.StatusStripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormLiquidaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Liquidaciones de sueldos"
        Me.StatusStripMain.ResumeLayout(False)
        Me.StatusStripMain.PerformLayout()
        Me.FlowLayoutPanelToolbars.ResumeLayout(False)
        Me.FlowLayoutPanelToolbars.PerformLayout()
        Me.ToolStripButtons.ResumeLayout(False)
        Me.ToolStripButtons.PerformLayout()
        Me.ToolStripFiltroAnio.ResumeLayout(False)
        Me.ToolStripFiltroAnio.PerformLayout()
        Me.ToolStripFiltroMes.ResumeLayout(False)
        Me.ToolStripFiltroMes.PerformLayout()
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
    Friend WithEvents DataGridViewColumnMes As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnImporteMatricula As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnImporteCuota As DataGridViewTextBoxColumn
    Friend WithEvents ToolStripButtonEntidades As ToolStripButton
    Friend WithEvents ToolStripFiltroAnio As ToolStrip
    Friend WithEvents ToolStripLabelAnio As ToolStripLabel
    Friend WithEvents ToolStripComboBoxAnio As ToolStripComboBox
    Friend WithEvents ToolStripFiltroMes As ToolStrip
    Friend WithEvents ToolStripLabelMes As ToolStripLabel
    Friend WithEvents ToolStripComboBoxMes As ToolStripComboBox
End Class
