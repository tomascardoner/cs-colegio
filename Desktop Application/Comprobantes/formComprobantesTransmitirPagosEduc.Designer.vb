<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class formComprobantesTransmitirPagosEduc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formComprobantesTransmitirPagosEduc))
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
        Me.datagridviewComprobantes.Location = New System.Drawing.Point(12, 63)
        Me.datagridviewComprobantes.MultiSelect = False
        Me.datagridviewComprobantes.Name = "datagridviewComprobantes"
        Me.datagridviewComprobantes.ReadOnly = True
        Me.datagridviewComprobantes.RowHeadersVisible = False
        Me.datagridviewComprobantes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewComprobantes.Size = New System.Drawing.Size(668, 419)
        Me.datagridviewComprobantes.TabIndex = 3
        '
        'columnComprobanteTipoNombre
        '
        Me.columnComprobanteTipoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnComprobanteTipoNombre.DataPropertyName = "ComprobanteTipoNombre"
        Me.columnComprobanteTipoNombre.HeaderText = "Tipo"
        Me.columnComprobanteTipoNombre.Name = "columnComprobanteTipoNombre"
        Me.columnComprobanteTipoNombre.ReadOnly = True
        Me.columnComprobanteTipoNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnComprobanteTipoNombre.Width = 34
        '
        'columnNumeroCompleto
        '
        Me.columnNumeroCompleto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNumeroCompleto.DataPropertyName = "NumeroCompleto"
        Me.columnNumeroCompleto.HeaderText = "Comprobante N°"
        Me.columnNumeroCompleto.Name = "columnNumeroCompleto"
        Me.columnNumeroCompleto.ReadOnly = True
        Me.columnNumeroCompleto.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnNumeroCompleto.Width = 82
        '
        'columnApellidoNombre
        '
        Me.columnApellidoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnApellidoNombre.DataPropertyName = "ApellidoNombre"
        Me.columnApellidoNombre.HeaderText = "Apellido y Nombre"
        Me.columnApellidoNombre.Name = "columnApellidoNombre"
        Me.columnApellidoNombre.ReadOnly = True
        Me.columnApellidoNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnApellidoNombre.Width = 88
        '
        'columnImporteTotal
        '
        Me.columnImporteTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnImporteTotal.DataPropertyName = "ImporteTotal"
        DataGridViewCellStyle2.Format = "C2"
        DataGridViewCellStyle2.NullValue = "0"
        Me.columnImporteTotal.DefaultCellStyle = DataGridViewCellStyle2
        Me.columnImporteTotal.HeaderText = "Importe"
        Me.columnImporteTotal.Name = "columnImporteTotal"
        Me.columnImporteTotal.ReadOnly = True
        Me.columnImporteTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnImporteTotal.Width = 48
        '
        'buttonExportar
        '
        Me.buttonExportar.Location = New System.Drawing.Point(332, 19)
        Me.buttonExportar.Name = "buttonExportar"
        Me.buttonExportar.Size = New System.Drawing.Size(57, 21)
        Me.buttonExportar.TabIndex = 2
        Me.buttonExportar.Text = "Exportar"
        Me.buttonExportar.UseVisualStyleBackColor = True
        '
        'statusstripMain
        '
        Me.statusstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.statusstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statuslabelMain})
        Me.statusstripMain.Location = New System.Drawing.Point(0, 494)
        Me.statusstripMain.Name = "statusstripMain"
        Me.statusstripMain.Size = New System.Drawing.Size(692, 22)
        Me.statusstripMain.TabIndex = 4
        '
        'statuslabelMain
        '
        Me.statuslabelMain.Name = "statuslabelMain"
        Me.statuslabelMain.Size = New System.Drawing.Size(677, 17)
        Me.statuslabelMain.Spring = True
        Me.statuslabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pictureboxLogo
        '
        Me.pictureboxLogo.BackColor = System.Drawing.Color.White
        Me.pictureboxLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pictureboxLogo.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_LOGO_PAGOSEDUC
        Me.pictureboxLogo.Location = New System.Drawing.Point(517, 6)
        Me.pictureboxLogo.Name = "pictureboxLogo"
        Me.pictureboxLogo.Size = New System.Drawing.Size(52, 51)
        Me.pictureboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureboxLogo.TabIndex = 9
        Me.pictureboxLogo.TabStop = False
        '
        'comboboxComprobanteLote
        '
        Me.comboboxComprobanteLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxComprobanteLote.FormattingEnabled = True
        Me.comboboxComprobanteLote.Location = New System.Drawing.Point(46, 20)
        Me.comboboxComprobanteLote.Name = "comboboxComprobanteLote"
        Me.comboboxComprobanteLote.Size = New System.Drawing.Size(282, 21)
        Me.comboboxComprobanteLote.TabIndex = 13
        '
        'labelComprobanteLote
        '
        Me.labelComprobanteLote.AutoSize = True
        Me.labelComprobanteLote.Location = New System.Drawing.Point(10, 22)
        Me.labelComprobanteLote.Name = "labelComprobanteLote"
        Me.labelComprobanteLote.Size = New System.Drawing.Size(31, 13)
        Me.labelComprobanteLote.TabIndex = 12
        Me.labelComprobanteLote.Text = "Lote:"
        '
        'formComprobantesTransmitirPagosEduc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 516)
        Me.Controls.Add(Me.comboboxComprobanteLote)
        Me.Controls.Add(Me.labelComprobanteLote)
        Me.Controls.Add(Me.pictureboxLogo)
        Me.Controls.Add(Me.statusstripMain)
        Me.Controls.Add(Me.buttonExportar)
        Me.Controls.Add(Me.datagridviewComprobantes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "formComprobantesTransmitirPagosEduc"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Exportar archivo de Comprobantes para envío a PAGOS Educ"
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
