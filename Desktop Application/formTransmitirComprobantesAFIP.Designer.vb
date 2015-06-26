<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formTransmitirComprobantesAFIP
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
        Me.labelLote = New System.Windows.Forms.Label()
        Me.comboboxLote = New System.Windows.Forms.ComboBox()
        Me.datagridviewPaso3Cabecera = New System.Windows.Forms.DataGridView()
        Me.buttonTransmitir = New System.Windows.Forms.Button()
        Me.columnComprobanteTipoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPuntoVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnApellidoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnDocumentoNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnCategoriaIVANombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.datagridviewPaso3Cabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelLote
        '
        Me.labelLote.AutoSize = True
        Me.labelLote.Location = New System.Drawing.Point(12, 9)
        Me.labelLote.Name = "labelLote"
        Me.labelLote.Size = New System.Drawing.Size(132, 13)
        Me.labelLote.TabIndex = 0
        Me.labelLote.Text = "Lote de Facturas a Enviar:"
        '
        'comboboxLote
        '
        Me.comboboxLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxLote.FormattingEnabled = True
        Me.comboboxLote.Location = New System.Drawing.Point(150, 6)
        Me.comboboxLote.Name = "comboboxLote"
        Me.comboboxLote.Size = New System.Drawing.Size(333, 21)
        Me.comboboxLote.TabIndex = 1
        '
        'datagridviewPaso3Cabecera
        '
        Me.datagridviewPaso3Cabecera.AllowUserToAddRows = False
        Me.datagridviewPaso3Cabecera.AllowUserToDeleteRows = False
        Me.datagridviewPaso3Cabecera.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewPaso3Cabecera.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewPaso3Cabecera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.datagridviewPaso3Cabecera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewPaso3Cabecera.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnComprobanteTipoNombre, Me.columnPuntoVenta, Me.columnNumero, Me.columnApellidoNombre, Me.columnDocumentoNumero, Me.columnCategoriaIVANombre, Me.columnImporteTotal})
        Me.datagridviewPaso3Cabecera.Location = New System.Drawing.Point(12, 33)
        Me.datagridviewPaso3Cabecera.MultiSelect = False
        Me.datagridviewPaso3Cabecera.Name = "datagridviewPaso3Cabecera"
        Me.datagridviewPaso3Cabecera.ReadOnly = True
        Me.datagridviewPaso3Cabecera.RowHeadersVisible = False
        Me.datagridviewPaso3Cabecera.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewPaso3Cabecera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewPaso3Cabecera.Size = New System.Drawing.Size(668, 372)
        Me.datagridviewPaso3Cabecera.TabIndex = 3
        '
        'buttonTransmitir
        '
        Me.buttonTransmitir.Location = New System.Drawing.Point(503, 6)
        Me.buttonTransmitir.Name = "buttonTransmitir"
        Me.buttonTransmitir.Size = New System.Drawing.Size(86, 21)
        Me.buttonTransmitir.TabIndex = 2
        Me.buttonTransmitir.Text = "Transmitir"
        Me.buttonTransmitir.UseVisualStyleBackColor = True
        '
        'columnComprobanteTipoNombre
        '
        Me.columnComprobanteTipoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnComprobanteTipoNombre.DataPropertyName = "ComprobanteTipo.Nombre"
        Me.columnComprobanteTipoNombre.HeaderText = "Tipo"
        Me.columnComprobanteTipoNombre.Name = "columnComprobanteTipoNombre"
        Me.columnComprobanteTipoNombre.ReadOnly = True
        Me.columnComprobanteTipoNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnComprobanteTipoNombre.Width = 34
        '
        'columnPuntoVenta
        '
        Me.columnPuntoVenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPuntoVenta.DataPropertyName = "PuntoVenta"
        Me.columnPuntoVenta.HeaderText = "Punto Venta"
        Me.columnPuntoVenta.Name = "columnPuntoVenta"
        Me.columnPuntoVenta.ReadOnly = True
        Me.columnPuntoVenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnPuntoVenta.Width = 72
        '
        'columnNumero
        '
        Me.columnNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNumero.DataPropertyName = "Numero"
        Me.columnNumero.HeaderText = "Factura N°"
        Me.columnNumero.Name = "columnNumero"
        Me.columnNumero.ReadOnly = True
        Me.columnNumero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnNumero.Width = 64
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
        'columnDocumentoNumero
        '
        Me.columnDocumentoNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnDocumentoNumero.DataPropertyName = "DocumentoNumero"
        Me.columnDocumentoNumero.HeaderText = "N° Documento"
        Me.columnDocumentoNumero.Name = "columnDocumentoNumero"
        Me.columnDocumentoNumero.ReadOnly = True
        Me.columnDocumentoNumero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnDocumentoNumero.Width = 75
        '
        'columnCategoriaIVANombre
        '
        Me.columnCategoriaIVANombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnCategoriaIVANombre.DataPropertyName = "CategoriaIVANombre"
        Me.columnCategoriaIVANombre.HeaderText = "IVA"
        Me.columnCategoriaIVANombre.Name = "columnCategoriaIVANombre"
        Me.columnCategoriaIVANombre.ReadOnly = True
        Me.columnCategoriaIVANombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnCategoriaIVANombre.Width = 30
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
        'formTransmitirComprobantesAFIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 417)
        Me.Controls.Add(Me.buttonTransmitir)
        Me.Controls.Add(Me.datagridviewPaso3Cabecera)
        Me.Controls.Add(Me.comboboxLote)
        Me.Controls.Add(Me.labelLote)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "formTransmitirComprobantesAFIP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Transmitir Comprobantes a AFIP"
        CType(Me.datagridviewPaso3Cabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelLote As System.Windows.Forms.Label
    Friend WithEvents comboboxLote As System.Windows.Forms.ComboBox
    Friend WithEvents datagridviewPaso3Cabecera As System.Windows.Forms.DataGridView
    Friend WithEvents buttonTransmitir As System.Windows.Forms.Button
    Friend WithEvents columnComprobanteTipoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPuntoVenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnApellidoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnDocumentoNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnCategoriaIVANombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
