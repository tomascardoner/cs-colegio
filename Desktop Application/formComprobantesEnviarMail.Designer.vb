<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formComprobantesEnviarMail
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.datagridviewComprobantes = New System.Windows.Forms.DataGridView()
        Me.columnLote = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnComprobanteTipoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNumeroCompleto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnApellidoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.comboboxComprobanteLote = New System.Windows.Forms.ComboBox()
        Me.labelComprobanteLote = New System.Windows.Forms.Label()
        Me.statusstripMain = New System.Windows.Forms.StatusStrip()
        Me.statuslabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.buttonEnviar = New System.Windows.Forms.Button()
        Me.groupboxStatus = New System.Windows.Forms.GroupBox()
        Me.textboxStatus = New System.Windows.Forms.TextBox()
        Me.progressbarStatus = New System.Windows.Forms.ProgressBar()
        Me.comboboxCantidad = New System.Windows.Forms.ComboBox()
        Me.labelCantidad = New System.Windows.Forms.Label()
        CType(Me.datagridviewComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusstripMain.SuspendLayout()
        Me.groupboxStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'datagridviewComprobantes
        '
        Me.datagridviewComprobantes.AllowUserToAddRows = False
        Me.datagridviewComprobantes.AllowUserToDeleteRows = False
        Me.datagridviewComprobantes.AllowUserToResizeRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewComprobantes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.datagridviewComprobantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.datagridviewComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewComprobantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnLote, Me.columnComprobanteTipoNombre, Me.columnNumeroCompleto, Me.columnApellidoNombre, Me.columnImporteTotal})
        Me.datagridviewComprobantes.Location = New System.Drawing.Point(12, 33)
        Me.datagridviewComprobantes.MultiSelect = False
        Me.datagridviewComprobantes.Name = "datagridviewComprobantes"
        Me.datagridviewComprobantes.ReadOnly = True
        Me.datagridviewComprobantes.RowHeadersVisible = False
        Me.datagridviewComprobantes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewComprobantes.Size = New System.Drawing.Size(668, 449)
        Me.datagridviewComprobantes.TabIndex = 5
        '
        'columnLote
        '
        Me.columnLote.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnLote.DataPropertyName = "LoteNombre"
        Me.columnLote.HeaderText = "Lote"
        Me.columnLote.Name = "columnLote"
        Me.columnLote.ReadOnly = True
        Me.columnLote.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnLote.Width = 34
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
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = "0"
        Me.columnImporteTotal.DefaultCellStyle = DataGridViewCellStyle4
        Me.columnImporteTotal.HeaderText = "Importe"
        Me.columnImporteTotal.Name = "columnImporteTotal"
        Me.columnImporteTotal.ReadOnly = True
        Me.columnImporteTotal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnImporteTotal.Width = 48
        '
        'comboboxComprobanteLote
        '
        Me.comboboxComprobanteLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxComprobanteLote.FormattingEnabled = True
        Me.comboboxComprobanteLote.Location = New System.Drawing.Point(177, 6)
        Me.comboboxComprobanteLote.Name = "comboboxComprobanteLote"
        Me.comboboxComprobanteLote.Size = New System.Drawing.Size(242, 21)
        Me.comboboxComprobanteLote.TabIndex = 1
        '
        'labelComprobanteLote
        '
        Me.labelComprobanteLote.AutoSize = True
        Me.labelComprobanteLote.Location = New System.Drawing.Point(12, 9)
        Me.labelComprobanteLote.Name = "labelComprobanteLote"
        Me.labelComprobanteLote.Size = New System.Drawing.Size(159, 13)
        Me.labelComprobanteLote.TabIndex = 0
        Me.labelComprobanteLote.Text = "Lote de Comprobantes a Enviar:"
        '
        'statusstripMain
        '
        Me.statusstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statuslabelMain})
        Me.statusstripMain.Location = New System.Drawing.Point(0, 494)
        Me.statusstripMain.Name = "statusstripMain"
        Me.statusstripMain.Size = New System.Drawing.Size(692, 22)
        Me.statusstripMain.TabIndex = 7
        '
        'statuslabelMain
        '
        Me.statuslabelMain.Name = "statuslabelMain"
        Me.statuslabelMain.Size = New System.Drawing.Size(677, 17)
        Me.statuslabelMain.Spring = True
        Me.statuslabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'buttonEnviar
        '
        Me.buttonEnviar.Location = New System.Drawing.Point(594, 6)
        Me.buttonEnviar.Name = "buttonEnviar"
        Me.buttonEnviar.Size = New System.Drawing.Size(86, 21)
        Me.buttonEnviar.TabIndex = 4
        Me.buttonEnviar.Text = "Enviar"
        Me.buttonEnviar.UseVisualStyleBackColor = True
        '
        'groupboxStatus
        '
        Me.groupboxStatus.Controls.Add(Me.textboxStatus)
        Me.groupboxStatus.Controls.Add(Me.progressbarStatus)
        Me.groupboxStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupboxStatus.Location = New System.Drawing.Point(12, 350)
        Me.groupboxStatus.Name = "groupboxStatus"
        Me.groupboxStatus.Size = New System.Drawing.Size(668, 132)
        Me.groupboxStatus.TabIndex = 6
        Me.groupboxStatus.TabStop = False
        Me.groupboxStatus.Text = "Estado del envío:"
        Me.groupboxStatus.Visible = False
        '
        'textboxStatus
        '
        Me.textboxStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textboxStatus.Location = New System.Drawing.Point(7, 54)
        Me.textboxStatus.MaxLength = 0
        Me.textboxStatus.Multiline = True
        Me.textboxStatus.Name = "textboxStatus"
        Me.textboxStatus.ReadOnly = True
        Me.textboxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textboxStatus.Size = New System.Drawing.Size(655, 71)
        Me.textboxStatus.TabIndex = 1
        '
        'progressbarStatus
        '
        Me.progressbarStatus.Location = New System.Drawing.Point(3, 21)
        Me.progressbarStatus.Name = "progressbarStatus"
        Me.progressbarStatus.Size = New System.Drawing.Size(660, 26)
        Me.progressbarStatus.TabIndex = 0
        '
        'comboboxCantidad
        '
        Me.comboboxCantidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCantidad.FormattingEnabled = True
        Me.comboboxCantidad.Location = New System.Drawing.Point(490, 6)
        Me.comboboxCantidad.Name = "comboboxCantidad"
        Me.comboboxCantidad.Size = New System.Drawing.Size(90, 21)
        Me.comboboxCantidad.TabIndex = 3
        '
        'labelCantidad
        '
        Me.labelCantidad.AutoSize = True
        Me.labelCantidad.Location = New System.Drawing.Point(432, 10)
        Me.labelCantidad.Name = "labelCantidad"
        Me.labelCantidad.Size = New System.Drawing.Size(52, 13)
        Me.labelCantidad.TabIndex = 2
        Me.labelCantidad.Text = "Cantidad:"
        '
        'formComprobantesEnviarMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 516)
        Me.Controls.Add(Me.labelCantidad)
        Me.Controls.Add(Me.comboboxCantidad)
        Me.Controls.Add(Me.comboboxComprobanteLote)
        Me.Controls.Add(Me.labelComprobanteLote)
        Me.Controls.Add(Me.statusstripMain)
        Me.Controls.Add(Me.buttonEnviar)
        Me.Controls.Add(Me.groupboxStatus)
        Me.Controls.Add(Me.datagridviewComprobantes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "formComprobantesEnviarMail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Enviar Lote de Comprobantes por e-mail"
        CType(Me.datagridviewComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusstripMain.ResumeLayout(False)
        Me.statusstripMain.PerformLayout()
        Me.groupboxStatus.ResumeLayout(False)
        Me.groupboxStatus.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents datagridviewComprobantes As System.Windows.Forms.DataGridView
    Friend WithEvents comboboxComprobanteLote As System.Windows.Forms.ComboBox
    Friend WithEvents labelComprobanteLote As System.Windows.Forms.Label
    Friend WithEvents statusstripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents statuslabelMain As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents buttonEnviar As System.Windows.Forms.Button
    Friend WithEvents groupboxStatus As System.Windows.Forms.GroupBox
    Friend WithEvents textboxStatus As System.Windows.Forms.TextBox
    Friend WithEvents progressbarStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents columnLote As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnComprobanteTipoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNumeroCompleto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnApellidoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comboboxCantidad As System.Windows.Forms.ComboBox
    Friend WithEvents labelCantidad As System.Windows.Forms.Label
End Class
