<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formComprobanteAplicacion
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.labelComprobanteAplicado = New System.Windows.Forms.Label()
        Me.labelImporteAplicado = New System.Windows.Forms.Label()
        Me.datagridviewMain = New System.Windows.Forms.DataGridView()
        Me.columnTipoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNumeroCompleto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnFechaEmision = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteAplicado = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteSinAplicar = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comboboxMotivo = New System.Windows.Forms.ComboBox()
        Me.labelMotivo = New System.Windows.Forms.Label()
        Me.currencytextboxImporteAplicado = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.toolstripMain.SuspendLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.currencytextboxImporteAplicado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(563, 39)
        Me.toolstripMain.TabIndex = 6
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
        'labelComprobanteAplicado
        '
        Me.labelComprobanteAplicado.AutoSize = True
        Me.labelComprobanteAplicado.Location = New System.Drawing.Point(9, 53)
        Me.labelComprobanteAplicado.Name = "labelComprobanteAplicado"
        Me.labelComprobanteAplicado.Size = New System.Drawing.Size(116, 13)
        Me.labelComprobanteAplicado.TabIndex = 0
        Me.labelComprobanteAplicado.Text = "Comprobante a aplicar:"
        '
        'labelImporteAplicado
        '
        Me.labelImporteAplicado.AutoSize = True
        Me.labelImporteAplicado.Location = New System.Drawing.Point(9, 320)
        Me.labelImporteAplicado.Name = "labelImporteAplicado"
        Me.labelImporteAplicado.Size = New System.Drawing.Size(88, 13)
        Me.labelImporteAplicado.TabIndex = 4
        Me.labelImporteAplicado.Text = "Importe a aplicar:"
        '
        'datagridviewMain
        '
        Me.datagridviewMain.AllowUserToAddRows = False
        Me.datagridviewMain.AllowUserToDeleteRows = False
        Me.datagridviewMain.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnTipoNombre, Me.columnNumeroCompleto, Me.columnFechaEmision, Me.columnImporteTotal, Me.columnImporteAplicado, Me.columnImporteSinAplicar})
        Me.datagridviewMain.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.datagridviewMain.Location = New System.Drawing.Point(12, 69)
        Me.datagridviewMain.MultiSelect = False
        Me.datagridviewMain.Name = "datagridviewMain"
        Me.datagridviewMain.ReadOnly = True
        Me.datagridviewMain.RowHeadersVisible = False
        Me.datagridviewMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewMain.Size = New System.Drawing.Size(539, 215)
        Me.datagridviewMain.TabIndex = 1
        '
        'columnTipoNombre
        '
        Me.columnTipoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnTipoNombre.DataPropertyName = "TipoNombre"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnTipoNombre.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnTipoNombre.HeaderText = "Tipo"
        Me.columnTipoNombre.Name = "columnTipoNombre"
        Me.columnTipoNombre.ReadOnly = True
        Me.columnTipoNombre.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.columnTipoNombre.Width = 53
        '
        'columnNumeroCompleto
        '
        Me.columnNumeroCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNumeroCompleto.DataPropertyName = "NumeroCompleto"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnNumeroCompleto.DefaultCellStyle = DataGridViewCellStyle3
        Me.columnNumeroCompleto.HeaderText = "Número"
        Me.columnNumeroCompleto.Name = "columnNumeroCompleto"
        Me.columnNumeroCompleto.ReadOnly = True
        Me.columnNumeroCompleto.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.columnNumeroCompleto.Width = 69
        '
        'columnFechaEmision
        '
        Me.columnFechaEmision.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnFechaEmision.DataPropertyName = "FechaEmision"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnFechaEmision.DefaultCellStyle = DataGridViewCellStyle4
        Me.columnFechaEmision.HeaderText = "Fecha"
        Me.columnFechaEmision.Name = "columnFechaEmision"
        Me.columnFechaEmision.ReadOnly = True
        Me.columnFechaEmision.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.columnFechaEmision.Width = 62
        '
        'columnImporteTotal
        '
        Me.columnImporteTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "C2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.columnImporteTotal.DefaultCellStyle = DataGridViewCellStyle5
        Me.columnImporteTotal.HeaderText = "Importe total"
        Me.columnImporteTotal.Name = "columnImporteTotal"
        Me.columnImporteTotal.ReadOnly = True
        Me.columnImporteTotal.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.columnImporteTotal.Width = 83
        '
        'columnImporteAplicado
        '
        Me.columnImporteAplicado.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteAplicado.DataPropertyName = "ImporteAplicado"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.columnImporteAplicado.DefaultCellStyle = DataGridViewCellStyle6
        Me.columnImporteAplicado.HeaderText = "Importe aplicado"
        Me.columnImporteAplicado.Name = "columnImporteAplicado"
        Me.columnImporteAplicado.ReadOnly = True
        Me.columnImporteAplicado.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.columnImporteAplicado.Width = 101
        '
        'columnImporteSinAplicar
        '
        Me.columnImporteSinAplicar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteSinAplicar.DataPropertyName = "ImporteSinAplicar"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "C2"
        Me.columnImporteSinAplicar.DefaultCellStyle = DataGridViewCellStyle7
        Me.columnImporteSinAplicar.HeaderText = "Importe pendiente"
        Me.columnImporteSinAplicar.Name = "columnImporteSinAplicar"
        Me.columnImporteSinAplicar.ReadOnly = True
        Me.columnImporteSinAplicar.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.columnImporteSinAplicar.Width = 107
        '
        'comboboxMotivo
        '
        Me.comboboxMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxMotivo.FormattingEnabled = True
        Me.comboboxMotivo.Location = New System.Drawing.Point(103, 290)
        Me.comboboxMotivo.Name = "comboboxMotivo"
        Me.comboboxMotivo.Size = New System.Drawing.Size(291, 21)
        Me.comboboxMotivo.TabIndex = 3
        '
        'labelMotivo
        '
        Me.labelMotivo.AutoSize = True
        Me.labelMotivo.Location = New System.Drawing.Point(9, 293)
        Me.labelMotivo.Name = "labelMotivo"
        Me.labelMotivo.Size = New System.Drawing.Size(42, 13)
        Me.labelMotivo.TabIndex = 2
        Me.labelMotivo.Text = "Motivo:"
        '
        'currencytextboxImporteAplicado
        '
        Me.currencytextboxImporteAplicado.BeforeTouchSize = New System.Drawing.Size(69, 20)
        Me.currencytextboxImporteAplicado.DecimalValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxImporteAplicado.Location = New System.Drawing.Point(103, 317)
        Me.currencytextboxImporteAplicado.MaxValue = New Decimal(New Integer() {999999999, 0, 0, 131072})
        Me.currencytextboxImporteAplicado.Metrocolor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.currencytextboxImporteAplicado.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.currencytextboxImporteAplicado.Name = "currencytextboxImporteAplicado"
        Me.currencytextboxImporteAplicado.NullString = ""
        Me.currencytextboxImporteAplicado.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.currencytextboxImporteAplicado.Size = New System.Drawing.Size(100, 20)
        Me.currencytextboxImporteAplicado.TabIndex = 7
        Me.currencytextboxImporteAplicado.Text = "$ 0,00"
        Me.currencytextboxImporteAplicado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'formComprobanteAplicacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(563, 346)
        Me.Controls.Add(Me.currencytextboxImporteAplicado)
        Me.Controls.Add(Me.comboboxMotivo)
        Me.Controls.Add(Me.labelMotivo)
        Me.Controls.Add(Me.datagridviewMain)
        Me.Controls.Add(Me.labelImporteAplicado)
        Me.Controls.Add(Me.labelComprobanteAplicado)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formComprobanteAplicacion"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Aplicación de Comprobantes"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.currencytextboxImporteAplicado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents labelComprobanteAplicado As System.Windows.Forms.Label
    Friend WithEvents labelImporteAplicado As System.Windows.Forms.Label
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents datagridviewMain As System.Windows.Forms.DataGridView
    Friend WithEvents comboboxMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents labelMotivo As System.Windows.Forms.Label
    Friend WithEvents columnTipoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNumeroCompleto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnFechaEmision As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteAplicado As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteSinAplicar As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents currencytextboxImporteAplicado As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
End Class
