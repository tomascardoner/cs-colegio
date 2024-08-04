<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCalculosModulos
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
        Me.ToolStripButtonEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripFiltroAnio = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabelAnio = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBoxAnio = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripFiltroMes = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabelMes = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBoxMes = New System.Windows.Forms.ToolStripComboBox()
        Me.DataGridViewMain = New System.Windows.Forms.DataGridView()
        Me.DataGridViewColumnMes = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnImporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripButtonAgregar = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItemAgregarDesdeInternet = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemAgregarManualmente = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.ToolStripStatusLabelMain.Size = New System.Drawing.Size(822, 16)
        Me.ToolStripStatusLabelMain.Spring = True
        Me.ToolStripStatusLabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStripMain
        '
        Me.StatusStripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.StatusStripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabelMain})
        Me.StatusStripMain.Location = New System.Drawing.Point(0, 484)
        Me.StatusStripMain.Name = "StatusStripMain"
        Me.StatusStripMain.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.StatusStripMain.Size = New System.Drawing.Size(842, 22)
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
        Me.FlowLayoutPanelToolbars.Size = New System.Drawing.Size(842, 39)
        Me.FlowLayoutPanelToolbars.TabIndex = 0
        '
        'ToolStripButtons
        '
        Me.ToolStripButtons.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripButtons.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripButtons.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonAgregar, Me.ToolStripButtonEditar, Me.ToolStripButtonEliminar})
        Me.ToolStripButtons.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripButtons.Name = "ToolStripButtons"
        Me.ToolStripButtons.Size = New System.Drawing.Size(334, 39)
        Me.ToolStripButtons.TabIndex = 1
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
        'ToolStripFiltroAnio
        '
        Me.ToolStripFiltroAnio.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripFiltroAnio.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripFiltroAnio.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripFiltroAnio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabelAnio, Me.ToolStripComboBoxAnio})
        Me.ToolStripFiltroAnio.Location = New System.Drawing.Point(334, 0)
        Me.ToolStripFiltroAnio.Name = "ToolStripFiltroAnio"
        Me.ToolStripFiltroAnio.Size = New System.Drawing.Size(143, 39)
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
        Me.ToolStripComboBoxAnio.Size = New System.Drawing.Size(99, 39)
        '
        'ToolStripFiltroMes
        '
        Me.ToolStripFiltroMes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripFiltroMes.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripFiltroMes.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripFiltroMes.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabelMes, Me.ToolStripComboBoxMes})
        Me.ToolStripFiltroMes.Location = New System.Drawing.Point(477, 0)
        Me.ToolStripFiltroMes.Name = "ToolStripFiltroMes"
        Me.ToolStripFiltroMes.Size = New System.Drawing.Size(203, 39)
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
        Me.DataGridViewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewColumnMes, Me.DataGridViewColumnCodigo, Me.DataGridViewColumnConcepto, Me.DataGridViewColumnImporte})
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
        Me.DataGridViewMain.Size = New System.Drawing.Size(842, 445)
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
        'DataGridViewColumnCodigo
        '
        Me.DataGridViewColumnCodigo.DataPropertyName = "SueldoConceptoCodigo"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewColumnCodigo.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewColumnCodigo.HeaderText = "Código"
        Me.DataGridViewColumnCodigo.MinimumWidth = 6
        Me.DataGridViewColumnCodigo.Name = "DataGridViewColumnCodigo"
        Me.DataGridViewColumnCodigo.ReadOnly = True
        Me.DataGridViewColumnCodigo.Width = 80
        '
        'DataGridViewColumnConcepto
        '
        Me.DataGridViewColumnConcepto.DataPropertyName = "SueldoConceptoNombre"
        Me.DataGridViewColumnConcepto.HeaderText = "Concepto"
        Me.DataGridViewColumnConcepto.MinimumWidth = 6
        Me.DataGridViewColumnConcepto.Name = "DataGridViewColumnConcepto"
        Me.DataGridViewColumnConcepto.ReadOnly = True
        Me.DataGridViewColumnConcepto.Width = 94
        '
        'DataGridViewColumnImporte
        '
        Me.DataGridViewColumnImporte.DataPropertyName = "Importe"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewColumnImporte.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewColumnImporte.HeaderText = "Importe"
        Me.DataGridViewColumnImporte.MinimumWidth = 6
        Me.DataGridViewColumnImporte.Name = "DataGridViewColumnImporte"
        Me.DataGridViewColumnImporte.ReadOnly = True
        Me.DataGridViewColumnImporte.Width = 81
        '
        'ToolStripButtonAgregar
        '
        Me.ToolStripButtonAgregar.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemAgregarDesdeInternet, Me.ToolStripMenuItemAgregarManualmente})
        Me.ToolStripButtonAgregar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_ADD_32
        Me.ToolStripButtonAgregar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonAgregar.Name = "ToolStripButtonAgregar"
        Me.ToolStripButtonAgregar.Size = New System.Drawing.Size(109, 36)
        Me.ToolStripButtonAgregar.Text = "Agregar"
        '
        'ToolStripMenuItemAgregarDesdeInternet
        '
        Me.ToolStripMenuItemAgregarDesdeInternet.Name = "ToolStripMenuItemAgregarDesdeInternet"
        Me.ToolStripMenuItemAgregarDesdeInternet.Size = New System.Drawing.Size(224, 26)
        Me.ToolStripMenuItemAgregarDesdeInternet.Text = "Desde internet"
        '
        'ToolStripMenuItemAgregarManualmente
        '
        Me.ToolStripMenuItemAgregarManualmente.Name = "ToolStripMenuItemAgregarManualmente"
        Me.ToolStripMenuItemAgregarManualmente.Size = New System.Drawing.Size(224, 26)
        Me.ToolStripMenuItemAgregarManualmente.Text = "Manualmente"
        '
        'FormCalculosModulos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(842, 506)
        Me.Controls.Add(Me.DataGridViewMain)
        Me.Controls.Add(Me.FlowLayoutPanelToolbars)
        Me.Controls.Add(Me.StatusStripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCalculosModulos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Cálculos de módulos de sueldos"
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
    Friend WithEvents ToolStripButtonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripFiltroAnio As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripLabelAnio As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripComboBoxAnio As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents DataGridViewMain As DataGridView
    Friend WithEvents ToolStripFiltroMes As ToolStrip
    Friend WithEvents ToolStripLabelMes As ToolStripLabel
    Friend WithEvents ToolStripComboBoxMes As ToolStripComboBox
    Friend WithEvents DataGridViewColumnMes As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnCodigo As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnConcepto As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnImporte As DataGridViewTextBoxColumn
    Friend WithEvents ToolStripButtonAgregar As ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItemAgregarDesdeInternet As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemAgregarManualmente As ToolStripMenuItem
End Class
