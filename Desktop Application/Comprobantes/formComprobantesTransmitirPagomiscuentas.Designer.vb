<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formComprobantesTransmitirPagomiscuentas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formComprobantesTransmitirPagomiscuentas))
        Me.datagridviewComprobantes = New System.Windows.Forms.DataGridView()
        Me.columnComprobanteTipoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNumeroCompleto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnApellidoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.buttonExportar = New System.Windows.Forms.Button()
        Me.statusstripMain = New System.Windows.Forms.StatusStrip()
        Me.statuslabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.pictureboxLogo = New System.Windows.Forms.PictureBox()
        Me.comboboxComprobanteLote = New System.Windows.Forms.ComboBox()
        Me.labelComprobanteLote = New System.Windows.Forms.Label()
        CType(Me.datagridviewComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusstripMain.SuspendLayout()
        CType(Me.pictureboxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'datagridviewComprobantes
        '
        Me.datagridviewComprobantes.AllowUserToAddRows = False
        Me.datagridviewComprobantes.AllowUserToDeleteRows = False
        Me.datagridviewComprobantes.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewComprobantes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewComprobantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.datagridviewComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewComprobantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnComprobanteTipoNombre, Me.columnNumeroCompleto, Me.columnApellidoNombre, Me.columnImporteTotal})
        Me.datagridviewComprobantes.Location = New System.Drawing.Point(16, 78)
        Me.datagridviewComprobantes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.datagridviewComprobantes.MultiSelect = False
        Me.datagridviewComprobantes.Name = "datagridviewComprobantes"
        Me.datagridviewComprobantes.ReadOnly = True
        Me.datagridviewComprobantes.RowHeadersVisible = False
        Me.datagridviewComprobantes.RowHeadersWidth = 51
        Me.datagridviewComprobantes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewComprobantes.Size = New System.Drawing.Size(891, 516)
        Me.datagridviewComprobantes.TabIndex = 3
        '
        'columnComprobanteTipoNombre
        '
        Me.columnComprobanteTipoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnComprobanteTipoNombre.DataPropertyName = "ComprobanteTipoNombre"
        Me.columnComprobanteTipoNombre.HeaderText = "Tipo"
        Me.columnComprobanteTipoNombre.MinimumWidth = 6
        Me.columnComprobanteTipoNombre.Name = "columnComprobanteTipoNombre"
        Me.columnComprobanteTipoNombre.ReadOnly = True
        Me.columnComprobanteTipoNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnComprobanteTipoNombre.Width = 41
        '
        'columnNumeroCompleto
        '
        Me.columnNumeroCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNumeroCompleto.DataPropertyName = "NumeroCompleto"
        Me.columnNumeroCompleto.HeaderText = "Comprobante N°"
        Me.columnNumeroCompleto.MinimumWidth = 6
        Me.columnNumeroCompleto.Name = "columnNumeroCompleto"
        Me.columnNumeroCompleto.ReadOnly = True
        Me.columnNumeroCompleto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnNumeroCompleto.Width = 101
        '
        'columnApellidoNombre
        '
        Me.columnApellidoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnApellidoNombre.DataPropertyName = "ApellidoNombre"
        Me.columnApellidoNombre.HeaderText = "Apellido y Nombre"
        Me.columnApellidoNombre.MinimumWidth = 6
        Me.columnApellidoNombre.Name = "columnApellidoNombre"
        Me.columnApellidoNombre.ReadOnly = True
        Me.columnApellidoNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnApellidoNombre.Width = 113
        '
        'columnImporteTotal
        '
        Me.columnImporteTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.columnImporteTotal.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnImporteTotal.HeaderText = "Importe"
        Me.columnImporteTotal.MinimumWidth = 6
        Me.columnImporteTotal.Name = "columnImporteTotal"
        Me.columnImporteTotal.ReadOnly = True
        Me.columnImporteTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnImporteTotal.Width = 58
        '
        'buttonExportar
        '
        Me.buttonExportar.Location = New System.Drawing.Point(443, 23)
        Me.buttonExportar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.buttonExportar.Name = "buttonExportar"
        Me.buttonExportar.Size = New System.Drawing.Size(76, 26)
        Me.buttonExportar.TabIndex = 2
        Me.buttonExportar.Text = "Exportar"
        Me.buttonExportar.UseVisualStyleBackColor = True
        '
        'statusstripMain
        '
        Me.statusstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.statusstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statuslabelMain})
        Me.statusstripMain.Location = New System.Drawing.Point(0, 613)
        Me.statusstripMain.Name = "statusstripMain"
        Me.statusstripMain.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.statusstripMain.Size = New System.Drawing.Size(923, 22)
        Me.statusstripMain.TabIndex = 4
        '
        'statuslabelMain
        '
        Me.statuslabelMain.Name = "statuslabelMain"
        Me.statuslabelMain.Size = New System.Drawing.Size(903, 16)
        Me.statuslabelMain.Spring = True
        Me.statuslabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pictureboxLogo
        '
        Me.pictureboxLogo.BackColor = System.Drawing.Color.White
        Me.pictureboxLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pictureboxLogo.Image = CType(resources.GetObject("pictureboxLogo.Image"), System.Drawing.Image)
        Me.pictureboxLogo.Location = New System.Drawing.Point(527, 7)
        Me.pictureboxLogo.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.pictureboxLogo.Name = "pictureboxLogo"
        Me.pictureboxLogo.Size = New System.Drawing.Size(379, 62)
        Me.pictureboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureboxLogo.TabIndex = 9
        Me.pictureboxLogo.TabStop = False
        '
        'comboboxComprobanteLote
        '
        Me.comboboxComprobanteLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxComprobanteLote.FormattingEnabled = True
        Me.comboboxComprobanteLote.Location = New System.Drawing.Point(61, 25)
        Me.comboboxComprobanteLote.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.comboboxComprobanteLote.Name = "comboboxComprobanteLote"
        Me.comboboxComprobanteLote.Size = New System.Drawing.Size(375, 24)
        Me.comboboxComprobanteLote.TabIndex = 13
        '
        'labelComprobanteLote
        '
        Me.labelComprobanteLote.AutoSize = True
        Me.labelComprobanteLote.Location = New System.Drawing.Point(13, 27)
        Me.labelComprobanteLote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelComprobanteLote.Name = "labelComprobanteLote"
        Me.labelComprobanteLote.Size = New System.Drawing.Size(36, 16)
        Me.labelComprobanteLote.TabIndex = 12
        Me.labelComprobanteLote.Text = "Lote:"
        '
        'formComprobantesTransmitirPagomiscuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 635)
        Me.Controls.Add(Me.comboboxComprobanteLote)
        Me.Controls.Add(Me.labelComprobanteLote)
        Me.Controls.Add(Me.pictureboxLogo)
        Me.Controls.Add(Me.statusstripMain)
        Me.Controls.Add(Me.buttonExportar)
        Me.Controls.Add(Me.datagridviewComprobantes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formComprobantesTransmitirPagomiscuentas"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Exportar archivo de Comprobantes para envío a PagoMisCuentas"
        CType(Me.datagridviewComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusstripMain.ResumeLayout(False)
        Me.statusstripMain.PerformLayout()
        CType(Me.pictureboxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents datagridviewComprobantes As System.Windows.Forms.DataGridView
    Friend WithEvents buttonExportar As System.Windows.Forms.Button
    Friend WithEvents statusstripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents statuslabelMain As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents columnComprobanteTipoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNumeroCompleto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnApellidoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pictureboxLogo As System.Windows.Forms.PictureBox
    Friend WithEvents comboboxComprobanteLote As System.Windows.Forms.ComboBox
    Friend WithEvents labelComprobanteLote As System.Windows.Forms.Label
End Class
