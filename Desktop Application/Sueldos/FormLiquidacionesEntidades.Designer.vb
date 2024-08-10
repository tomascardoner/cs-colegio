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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripStatusLabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStripMain = New System.Windows.Forms.StatusStrip()
        Me.FlowLayoutPanelToolbars = New System.Windows.Forms.FlowLayoutPanel()
        Me.ToolStripButtons = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonAgregar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEliminar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCopiarDatos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripDropDownButtonImprimir = New System.Windows.Forms.ToolStripDropDownButton()
        Me.ToolStripMenuItemImprimirResumenDirectoras = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemImprimirResumenDocentesIngles = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripMenuItemImprimirRecibosDocentesInglesTodos = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemImprimirReciboDocenteIngles = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripFiltroEntidadGrupo = New System.Windows.Forms.ToolStrip()
        Me.ToolStripLabelEntidadGrupo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBoxEntidadGrupo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabelLiquidacionDatos = New System.Windows.Forms.ToolStripLabel()
        Me.DataGridViewMain = New System.Windows.Forms.DataGridView()
        Me.DataGridViewColumnEntidadGrupo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnEntidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnModuloCantidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnAntiguedad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnReciboImporteBasico = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnReciboImporteNeto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StatusStripMain.SuspendLayout()
        Me.FlowLayoutPanelToolbars.SuspendLayout()
        Me.ToolStripButtons.SuspendLayout()
        Me.ToolStripFiltroEntidadGrupo.SuspendLayout()
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
        Me.FlowLayoutPanelToolbars.Controls.Add(Me.ToolStripFiltroEntidadGrupo)
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
        Me.ToolStripButtons.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonAgregar, Me.ToolStripButtonEditar, Me.ToolStripButtonEliminar, Me.ToolStripButtonCopiarDatos, Me.ToolStripDropDownButtonImprimir})
        Me.ToolStripButtons.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripButtons.Name = "ToolStripButtons"
        Me.ToolStripButtons.Size = New System.Drawing.Size(527, 39)
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
        'ToolStripButtonCopiarDatos
        '
        Me.ToolStripButtonCopiarDatos.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_COPY_32
        Me.ToolStripButtonCopiarDatos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonCopiarDatos.Name = "ToolStripButtonCopiarDatos"
        Me.ToolStripButtonCopiarDatos.Size = New System.Drawing.Size(130, 36)
        Me.ToolStripButtonCopiarDatos.Text = "Copiar datos"
        '
        'ToolStripDropDownButtonImprimir
        '
        Me.ToolStripDropDownButtonImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItemImprimirResumenDirectoras, Me.ToolStripMenuItemImprimirResumenDocentesIngles, Me.ToolStripSeparator2, Me.ToolStripMenuItemImprimirRecibosDocentesInglesTodos, Me.ToolStripMenuItemImprimirReciboDocenteIngles})
        Me.ToolStripDropDownButtonImprimir.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_PRINT_PREVIEW_32
        Me.ToolStripDropDownButtonImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripDropDownButtonImprimir.Name = "ToolStripDropDownButtonImprimir"
        Me.ToolStripDropDownButtonImprimir.Size = New System.Drawing.Size(112, 36)
        Me.ToolStripDropDownButtonImprimir.Text = "Imprimir"
        '
        'ToolStripMenuItemImprimirResumenDirectoras
        '
        Me.ToolStripMenuItemImprimirResumenDirectoras.Name = "ToolStripMenuItemImprimirResumenDirectoras"
        Me.ToolStripMenuItemImprimirResumenDirectoras.Size = New System.Drawing.Size(376, 26)
        Me.ToolStripMenuItemImprimirResumenDirectoras.Text = "Resumen de directores"
        '
        'ToolStripMenuItemImprimirResumenDocentesIngles
        '
        Me.ToolStripMenuItemImprimirResumenDocentesIngles.Name = "ToolStripMenuItemImprimirResumenDocentesIngles"
        Me.ToolStripMenuItemImprimirResumenDocentesIngles.Size = New System.Drawing.Size(376, 26)
        Me.ToolStripMenuItemImprimirResumenDocentesIngles.Text = "Resumen de docentes de inglés"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(373, 6)
        '
        'ToolStripMenuItemImprimirRecibosDocentesInglesTodos
        '
        Me.ToolStripMenuItemImprimirRecibosDocentesInglesTodos.Name = "ToolStripMenuItemImprimirRecibosDocentesInglesTodos"
        Me.ToolStripMenuItemImprimirRecibosDocentesInglesTodos.Size = New System.Drawing.Size(376, 26)
        Me.ToolStripMenuItemImprimirRecibosDocentesInglesTodos.Text = "Recibos de docentes de inglés"
        '
        'ToolStripMenuItemImprimirReciboDocenteIngles
        '
        Me.ToolStripMenuItemImprimirReciboDocenteIngles.Name = "ToolStripMenuItemImprimirReciboDocenteIngles"
        Me.ToolStripMenuItemImprimirReciboDocenteIngles.Size = New System.Drawing.Size(376, 26)
        Me.ToolStripMenuItemImprimirReciboDocenteIngles.Text = "Recibo del docente de inglés seleccionado"
        '
        'ToolStripFiltroEntidadGrupo
        '
        Me.ToolStripFiltroEntidadGrupo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolStripFiltroEntidadGrupo.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripFiltroEntidadGrupo.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripFiltroEntidadGrupo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripLabelEntidadGrupo, Me.ToolStripComboBoxEntidadGrupo, Me.ToolStripSeparator1, Me.ToolStripLabelLiquidacionDatos})
        Me.ToolStripFiltroEntidadGrupo.Location = New System.Drawing.Point(527, 0)
        Me.ToolStripFiltroEntidadGrupo.Name = "ToolStripFiltroEntidadGrupo"
        Me.ToolStripFiltroEntidadGrupo.Size = New System.Drawing.Size(223, 39)
        Me.ToolStripFiltroEntidadGrupo.TabIndex = 16
        '
        'ToolStripLabelEntidadGrupo
        '
        Me.ToolStripLabelEntidadGrupo.Name = "ToolStripLabelEntidadGrupo"
        Me.ToolStripLabelEntidadGrupo.Size = New System.Drawing.Size(53, 36)
        Me.ToolStripLabelEntidadGrupo.Text = "Grupo:"
        '
        'ToolStripComboBoxEntidadGrupo
        '
        Me.ToolStripComboBoxEntidadGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBoxEntidadGrupo.Name = "ToolStripComboBoxEntidadGrupo"
        Me.ToolStripComboBoxEntidadGrupo.Size = New System.Drawing.Size(159, 39)
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
        Me.DataGridViewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewColumnEntidadGrupo, Me.DataGridViewColumnEntidad, Me.DataGridViewColumnModuloCantidad, Me.DataGridViewColumnAntiguedad, Me.DataGridViewColumnReciboImporteBasico, Me.DataGridViewColumnReciboImporteNeto})
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
        'DataGridViewColumnEntidadGrupo
        '
        Me.DataGridViewColumnEntidadGrupo.DataPropertyName = "EntidadGrupoNombre"
        Me.DataGridViewColumnEntidadGrupo.HeaderText = "Grupo"
        Me.DataGridViewColumnEntidadGrupo.MinimumWidth = 6
        Me.DataGridViewColumnEntidadGrupo.Name = "DataGridViewColumnEntidadGrupo"
        Me.DataGridViewColumnEntidadGrupo.ReadOnly = True
        Me.DataGridViewColumnEntidadGrupo.Width = 73
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
        'DataGridViewColumnReciboImporteBasico
        '
        Me.DataGridViewColumnReciboImporteBasico.DataPropertyName = "ReciboImporteBasico"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DataGridViewColumnReciboImporteBasico.DefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewColumnReciboImporteBasico.HeaderText = "Básico recibo"
        Me.DataGridViewColumnReciboImporteBasico.MinimumWidth = 6
        Me.DataGridViewColumnReciboImporteBasico.Name = "DataGridViewColumnReciboImporteBasico"
        Me.DataGridViewColumnReciboImporteBasico.ReadOnly = True
        Me.DataGridViewColumnReciboImporteBasico.Width = 119
        '
        'DataGridViewColumnReciboImporteNeto
        '
        Me.DataGridViewColumnReciboImporteNeto.DataPropertyName = "ReciboImporteNeto"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewColumnReciboImporteNeto.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewColumnReciboImporteNeto.HeaderText = "Neto recibo"
        Me.DataGridViewColumnReciboImporteNeto.MinimumWidth = 6
        Me.DataGridViewColumnReciboImporteNeto.Name = "DataGridViewColumnReciboImporteNeto"
        Me.DataGridViewColumnReciboImporteNeto.ReadOnly = True
        Me.DataGridViewColumnReciboImporteNeto.Width = 106
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
        Me.ToolStripFiltroEntidadGrupo.ResumeLayout(False)
        Me.ToolStripFiltroEntidadGrupo.PerformLayout()
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
    Friend WithEvents ToolStripButtonCopiarDatos As ToolStripButton
    Friend WithEvents ToolStripDropDownButtonImprimir As ToolStripDropDownButton
    Friend WithEvents ToolStripMenuItemImprimirResumenDirectoras As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemImprimirResumenDocentesIngles As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripMenuItemImprimirRecibosDocentesInglesTodos As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemImprimirReciboDocenteIngles As ToolStripMenuItem
    Friend WithEvents ToolStripFiltroEntidadGrupo As ToolStrip
    Friend WithEvents ToolStripLabelEntidadGrupo As ToolStripLabel
    Friend WithEvents ToolStripComboBoxEntidadGrupo As ToolStripComboBox
    Friend WithEvents ToolStripLabelLiquidacionDatos As ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents DataGridViewColumnEntidadGrupo As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnEntidad As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnModuloCantidad As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnAntiguedad As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnReciboImporteBasico As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnReciboImporteNeto As DataGridViewTextBoxColumn
End Class
