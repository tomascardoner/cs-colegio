<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formComprobantesRecibirSantanderDebitoDirecto
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.panelPaso1 = New System.Windows.Forms.Panel()
        Me.buttonPaso1Cancelar = New System.Windows.Forms.Button()
        Me.buttonPaso1Siguiente = New System.Windows.Forms.Button()
        Me.labelArchivosEncontrados = New System.Windows.Forms.Label()
        Me.listboxArchivosEncontrados = New System.Windows.Forms.ListBox()
        Me.buttonMostrar = New System.Windows.Forms.Button()
        Me.buttonUbicacionArchivos = New System.Windows.Forms.Button()
        Me.textboxUbicacionArchivos = New System.Windows.Forms.TextBox()
        Me.labelUbicacionArchivos = New System.Windows.Forms.Label()
        Me.labelPaso1 = New System.Windows.Forms.Label()
        Me.panelPaso2 = New System.Windows.Forms.Panel()
        Me.textboxImporteTotal = New System.Windows.Forms.TextBox()
        Me.labelImporteTotal = New System.Windows.Forms.Label()
        Me.textboxCantidadRegistros = New System.Windows.Forms.TextBox()
        Me.labelCantidadRegistros = New System.Windows.Forms.Label()
        Me.textboxFechaEmision = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.labelFechaEmision = New System.Windows.Forms.Label()
        Me.buttonPaso2Siguiente = New System.Windows.Forms.Button()
        Me.buttonPaso2Anterior = New System.Windows.Forms.Button()
        Me.datagridviewPaso3Cabecera = New System.Windows.Forms.DataGridView()
        Me.columnComprobanteTipoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnPuntoVenta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnApellidoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnDocumentoNumero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnCategoriaIVANombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.panelPaso1.SuspendLayout()
        Me.panelPaso2.SuspendLayout()
        CType(Me.datagridviewPaso3Cabecera, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelPaso1
        '
        Me.panelPaso1.Controls.Add(Me.buttonPaso1Cancelar)
        Me.panelPaso1.Controls.Add(Me.buttonPaso1Siguiente)
        Me.panelPaso1.Controls.Add(Me.labelArchivosEncontrados)
        Me.panelPaso1.Controls.Add(Me.listboxArchivosEncontrados)
        Me.panelPaso1.Controls.Add(Me.buttonMostrar)
        Me.panelPaso1.Controls.Add(Me.buttonUbicacionArchivos)
        Me.panelPaso1.Controls.Add(Me.textboxUbicacionArchivos)
        Me.panelPaso1.Controls.Add(Me.labelUbicacionArchivos)
        Me.panelPaso1.Controls.Add(Me.labelPaso1)
        Me.panelPaso1.Location = New System.Drawing.Point(12, 12)
        Me.panelPaso1.Name = "panelPaso1"
        Me.panelPaso1.Size = New System.Drawing.Size(844, 404)
        Me.panelPaso1.TabIndex = 0
        '
        'buttonPaso1Cancelar
        '
        Me.buttonPaso1Cancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso1Cancelar.Location = New System.Drawing.Point(549, 362)
        Me.buttonPaso1Cancelar.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonPaso1Cancelar.Name = "buttonPaso1Cancelar"
        Me.buttonPaso1Cancelar.Size = New System.Drawing.Size(100, 42)
        Me.buttonPaso1Cancelar.TabIndex = 7
        Me.buttonPaso1Cancelar.Text = "Cancelar"
        Me.buttonPaso1Cancelar.UseVisualStyleBackColor = True
        '
        'buttonPaso1Siguiente
        '
        Me.buttonPaso1Siguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso1Siguiente.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_NEXT_24
        Me.buttonPaso1Siguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso1Siguiente.Location = New System.Drawing.Point(657, 362)
        Me.buttonPaso1Siguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonPaso1Siguiente.Name = "buttonPaso1Siguiente"
        Me.buttonPaso1Siguiente.Size = New System.Drawing.Size(187, 42)
        Me.buttonPaso1Siguiente.TabIndex = 8
        Me.buttonPaso1Siguiente.Text = "Paso 2: Verificación"
        Me.buttonPaso1Siguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso1Siguiente.UseVisualStyleBackColor = True
        '
        'labelArchivosEncontrados
        '
        Me.labelArchivosEncontrados.AutoSize = True
        Me.labelArchivosEncontrados.Location = New System.Drawing.Point(3, 83)
        Me.labelArchivosEncontrados.Name = "labelArchivosEncontrados"
        Me.labelArchivosEncontrados.Size = New System.Drawing.Size(149, 17)
        Me.labelArchivosEncontrados.TabIndex = 6
        Me.labelArchivosEncontrados.Text = "Archivos encontrados:"
        '
        'listboxArchivosEncontrados
        '
        Me.listboxArchivosEncontrados.FormattingEnabled = True
        Me.listboxArchivosEncontrados.ItemHeight = 16
        Me.listboxArchivosEncontrados.Location = New System.Drawing.Point(158, 83)
        Me.listboxArchivosEncontrados.Name = "listboxArchivosEncontrados"
        Me.listboxArchivosEncontrados.Size = New System.Drawing.Size(676, 260)
        Me.listboxArchivosEncontrados.TabIndex = 5
        '
        'buttonMostrar
        '
        Me.buttonMostrar.Location = New System.Drawing.Point(754, 36)
        Me.buttonMostrar.Name = "buttonMostrar"
        Me.buttonMostrar.Size = New System.Drawing.Size(80, 28)
        Me.buttonMostrar.TabIndex = 4
        Me.buttonMostrar.Text = "Listar"
        Me.buttonMostrar.UseVisualStyleBackColor = True
        '
        'buttonUbicacionArchivos
        '
        Me.buttonUbicacionArchivos.Location = New System.Drawing.Point(668, 36)
        Me.buttonUbicacionArchivos.Name = "buttonUbicacionArchivos"
        Me.buttonUbicacionArchivos.Size = New System.Drawing.Size(80, 28)
        Me.buttonUbicacionArchivos.TabIndex = 3
        Me.buttonUbicacionArchivos.Text = "Examinar"
        Me.buttonUbicacionArchivos.UseVisualStyleBackColor = True
        '
        'textboxUbicacionArchivos
        '
        Me.textboxUbicacionArchivos.Location = New System.Drawing.Point(158, 39)
        Me.textboxUbicacionArchivos.MaxLength = 255
        Me.textboxUbicacionArchivos.Name = "textboxUbicacionArchivos"
        Me.textboxUbicacionArchivos.Size = New System.Drawing.Size(504, 22)
        Me.textboxUbicacionArchivos.TabIndex = 2
        '
        'labelUbicacionArchivos
        '
        Me.labelUbicacionArchivos.AutoSize = True
        Me.labelUbicacionArchivos.Location = New System.Drawing.Point(3, 42)
        Me.labelUbicacionArchivos.Name = "labelUbicacionArchivos"
        Me.labelUbicacionArchivos.Size = New System.Drawing.Size(146, 17)
        Me.labelUbicacionArchivos.TabIndex = 1
        Me.labelUbicacionArchivos.Text = "Carpeta de ubicación:"
        '
        'labelPaso1
        '
        Me.labelPaso1.AutoSize = True
        Me.labelPaso1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelPaso1.Location = New System.Drawing.Point(3, 0)
        Me.labelPaso1.Name = "labelPaso1"
        Me.labelPaso1.Size = New System.Drawing.Size(337, 20)
        Me.labelPaso1.TabIndex = 0
        Me.labelPaso1.Text = "Paso 1: Selección del archivo de datos"
        '
        'panelPaso2
        '
        Me.panelPaso2.Controls.Add(Me.textboxImporteTotal)
        Me.panelPaso2.Controls.Add(Me.labelImporteTotal)
        Me.panelPaso2.Controls.Add(Me.textboxCantidadRegistros)
        Me.panelPaso2.Controls.Add(Me.labelCantidadRegistros)
        Me.panelPaso2.Controls.Add(Me.textboxFechaEmision)
        Me.panelPaso2.Controls.Add(Me.Label1)
        Me.panelPaso2.Controls.Add(Me.labelFechaEmision)
        Me.panelPaso2.Controls.Add(Me.buttonPaso2Siguiente)
        Me.panelPaso2.Controls.Add(Me.buttonPaso2Anterior)
        Me.panelPaso2.Controls.Add(Me.datagridviewPaso3Cabecera)
        Me.panelPaso2.Location = New System.Drawing.Point(12, 12)
        Me.panelPaso2.Name = "panelPaso2"
        Me.panelPaso2.Size = New System.Drawing.Size(844, 404)
        Me.panelPaso2.TabIndex = 1
        '
        'textboxImporteTotal
        '
        Me.textboxImporteTotal.Location = New System.Drawing.Point(659, 33)
        Me.textboxImporteTotal.Name = "textboxImporteTotal"
        Me.textboxImporteTotal.ReadOnly = True
        Me.textboxImporteTotal.Size = New System.Drawing.Size(112, 22)
        Me.textboxImporteTotal.TabIndex = 12
        '
        'labelImporteTotal
        '
        Me.labelImporteTotal.AutoSize = True
        Me.labelImporteTotal.Location = New System.Drawing.Point(558, 36)
        Me.labelImporteTotal.Name = "labelImporteTotal"
        Me.labelImporteTotal.Size = New System.Drawing.Size(95, 17)
        Me.labelImporteTotal.TabIndex = 11
        Me.labelImporteTotal.Text = "Importe Total:"
        '
        'textboxCantidadRegistros
        '
        Me.textboxCantidadRegistros.Location = New System.Drawing.Point(445, 33)
        Me.textboxCantidadRegistros.Name = "textboxCantidadRegistros"
        Me.textboxCantidadRegistros.ReadOnly = True
        Me.textboxCantidadRegistros.Size = New System.Drawing.Size(60, 22)
        Me.textboxCantidadRegistros.TabIndex = 10
        '
        'labelCantidadRegistros
        '
        Me.labelCantidadRegistros.AutoSize = True
        Me.labelCantidadRegistros.Location = New System.Drawing.Point(287, 36)
        Me.labelCantidadRegistros.Name = "labelCantidadRegistros"
        Me.labelCantidadRegistros.Size = New System.Drawing.Size(152, 17)
        Me.labelCantidadRegistros.TabIndex = 9
        Me.labelCantidadRegistros.Text = "Cantidad de Registros:"
        '
        'textboxFechaEmision
        '
        Me.textboxFechaEmision.Location = New System.Drawing.Point(133, 33)
        Me.textboxFechaEmision.Name = "textboxFechaEmision"
        Me.textboxFechaEmision.ReadOnly = True
        Me.textboxFechaEmision.Size = New System.Drawing.Size(112, 22)
        Me.textboxFechaEmision.TabIndex = 8
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(234, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Paso 2: Verificar los datos"
        '
        'labelFechaEmision
        '
        Me.labelFechaEmision.AutoSize = True
        Me.labelFechaEmision.Location = New System.Drawing.Point(3, 36)
        Me.labelFechaEmision.Name = "labelFechaEmision"
        Me.labelFechaEmision.Size = New System.Drawing.Size(124, 17)
        Me.labelFechaEmision.TabIndex = 6
        Me.labelFechaEmision.Text = "Fecha de Emisión:"
        '
        'buttonPaso2Siguiente
        '
        Me.buttonPaso2Siguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso2Siguiente.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_NEXT_24
        Me.buttonPaso2Siguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso2Siguiente.Location = New System.Drawing.Point(657, 362)
        Me.buttonPaso2Siguiente.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonPaso2Siguiente.Name = "buttonPaso2Siguiente"
        Me.buttonPaso2Siguiente.Size = New System.Drawing.Size(187, 42)
        Me.buttonPaso2Siguiente.TabIndex = 5
        Me.buttonPaso2Siguiente.Text = "Paso 3: Confirmación"
        Me.buttonPaso2Siguiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso2Siguiente.UseVisualStyleBackColor = True
        '
        'buttonPaso2Anterior
        '
        Me.buttonPaso2Anterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPaso2Anterior.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_PREVIOUS_24
        Me.buttonPaso2Anterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonPaso2Anterior.Location = New System.Drawing.Point(462, 362)
        Me.buttonPaso2Anterior.Margin = New System.Windows.Forms.Padding(4)
        Me.buttonPaso2Anterior.Name = "buttonPaso2Anterior"
        Me.buttonPaso2Anterior.Size = New System.Drawing.Size(187, 42)
        Me.buttonPaso2Anterior.TabIndex = 4
        Me.buttonPaso2Anterior.Text = "Paso 1: Selección"
        Me.buttonPaso2Anterior.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonPaso2Anterior.UseVisualStyleBackColor = True
        '
        'datagridviewPaso3Cabecera
        '
        Me.datagridviewPaso3Cabecera.AllowUserToAddRows = False
        Me.datagridviewPaso3Cabecera.AllowUserToDeleteRows = False
        Me.datagridviewPaso3Cabecera.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewPaso3Cabecera.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.datagridviewPaso3Cabecera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.datagridviewPaso3Cabecera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewPaso3Cabecera.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnComprobanteTipoNombre, Me.columnPuntoVenta, Me.columnNumero, Me.columnApellidoNombre, Me.columnDocumentoNumero, Me.columnCategoriaIVANombre})
        Me.datagridviewPaso3Cabecera.Location = New System.Drawing.Point(4, 68)
        Me.datagridviewPaso3Cabecera.Margin = New System.Windows.Forms.Padding(4)
        Me.datagridviewPaso3Cabecera.MultiSelect = False
        Me.datagridviewPaso3Cabecera.Name = "datagridviewPaso3Cabecera"
        Me.datagridviewPaso3Cabecera.ReadOnly = True
        Me.datagridviewPaso3Cabecera.RowHeadersVisible = False
        Me.datagridviewPaso3Cabecera.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewPaso3Cabecera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewPaso3Cabecera.Size = New System.Drawing.Size(836, 286)
        Me.datagridviewPaso3Cabecera.TabIndex = 1
        '
        'columnComprobanteTipoNombre
        '
        Me.columnComprobanteTipoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnComprobanteTipoNombre.DataPropertyName = "Partida"
        Me.columnComprobanteTipoNombre.HeaderText = "N° Cliente"
        Me.columnComprobanteTipoNombre.Name = "columnComprobanteTipoNombre"
        Me.columnComprobanteTipoNombre.ReadOnly = True
        Me.columnComprobanteTipoNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnComprobanteTipoNombre.Width = 69
        '
        'columnPuntoVenta
        '
        Me.columnPuntoVenta.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnPuntoVenta.DataPropertyName = "FechaVencimiento"
        Me.columnPuntoVenta.HeaderText = "Fecha de Venc."
        Me.columnPuntoVenta.Name = "columnPuntoVenta"
        Me.columnPuntoVenta.ReadOnly = True
        Me.columnPuntoVenta.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnPuntoVenta.Width = 102
        '
        'columnNumero
        '
        Me.columnNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNumero.DataPropertyName = "ImporteDebito"
        Me.columnNumero.HeaderText = "Importe"
        Me.columnNumero.Name = "columnNumero"
        Me.columnNumero.ReadOnly = True
        Me.columnNumero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnNumero.Width = 61
        '
        'columnApellidoNombre
        '
        Me.columnApellidoNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnApellidoNombre.DataPropertyName = "IdentificacionDebito"
        Me.columnApellidoNombre.HeaderText = "Factura"
        Me.columnApellidoNombre.Name = "columnApellidoNombre"
        Me.columnApellidoNombre.ReadOnly = True
        Me.columnApellidoNombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnApellidoNombre.Width = 62
        '
        'columnDocumentoNumero
        '
        Me.columnDocumentoNumero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnDocumentoNumero.DataPropertyName = "CodigoError"
        Me.columnDocumentoNumero.HeaderText = "Error"
        Me.columnDocumentoNumero.Name = "columnDocumentoNumero"
        Me.columnDocumentoNumero.ReadOnly = True
        Me.columnDocumentoNumero.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnDocumentoNumero.Width = 46
        '
        'columnCategoriaIVANombre
        '
        Me.columnCategoriaIVANombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnCategoriaIVANombre.DataPropertyName = "ReferenciaEmpresa"
        Me.columnCategoriaIVANombre.HeaderText = "ID de Comprobante"
        Me.columnCategoriaIVANombre.Name = "columnCategoriaIVANombre"
        Me.columnCategoriaIVANombre.ReadOnly = True
        Me.columnCategoriaIVANombre.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnCategoriaIVANombre.Width = 122
        '
        'formComprobantesRecibirSantanderDebitoDirecto
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(871, 432)
        Me.Controls.Add(Me.panelPaso1)
        Me.Controls.Add(Me.panelPaso2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "formComprobantesRecibirSantanderDebitoDirecto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Recibir datos de Banco Santander - Débito Directo"
        Me.panelPaso1.ResumeLayout(False)
        Me.panelPaso1.PerformLayout()
        Me.panelPaso2.ResumeLayout(False)
        Me.panelPaso2.PerformLayout()
        CType(Me.datagridviewPaso3Cabecera, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelPaso1 As System.Windows.Forms.Panel
    Friend WithEvents buttonUbicacionArchivos As System.Windows.Forms.Button
    Friend WithEvents textboxUbicacionArchivos As System.Windows.Forms.TextBox
    Friend WithEvents labelUbicacionArchivos As System.Windows.Forms.Label
    Friend WithEvents labelPaso1 As System.Windows.Forms.Label
    Friend WithEvents buttonMostrar As System.Windows.Forms.Button
    Friend WithEvents labelArchivosEncontrados As System.Windows.Forms.Label
    Friend WithEvents listboxArchivosEncontrados As System.Windows.Forms.ListBox
    Friend WithEvents buttonPaso1Cancelar As System.Windows.Forms.Button
    Friend WithEvents buttonPaso1Siguiente As System.Windows.Forms.Button
    Friend WithEvents panelPaso2 As System.Windows.Forms.Panel
    Friend WithEvents datagridviewPaso3Cabecera As System.Windows.Forms.DataGridView
    Friend WithEvents buttonPaso2Anterior As System.Windows.Forms.Button
    Friend WithEvents buttonPaso2Siguiente As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents labelFechaEmision As System.Windows.Forms.Label
    Friend WithEvents textboxFechaEmision As System.Windows.Forms.TextBox
    Friend WithEvents textboxCantidadRegistros As System.Windows.Forms.TextBox
    Friend WithEvents labelCantidadRegistros As System.Windows.Forms.Label
    Friend WithEvents textboxImporteTotal As System.Windows.Forms.TextBox
    Friend WithEvents labelImporteTotal As System.Windows.Forms.Label
    Friend WithEvents columnComprobanteTipoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnPuntoVenta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnApellidoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnDocumentoNumero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnCategoriaIVANombre As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
