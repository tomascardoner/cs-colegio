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
        Me.labelCantidad = New System.Windows.Forms.Label()
        Me.comboboxCantidad = New System.Windows.Forms.ComboBox()
        Me.datagridviewComprobantes = New System.Windows.Forms.DataGridView()
        Me.columnComprobanteTipoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNumeroCompleto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnApellidoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.buttonTransmitir = New System.Windows.Forms.Button()
        Me.statusstripMain = New System.Windows.Forms.StatusStrip()
        Me.statuslabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.groupboxStatus = New System.Windows.Forms.GroupBox()
        Me.textboxStatus = New System.Windows.Forms.TextBox()
        Me.progressbarStatus = New System.Windows.Forms.ProgressBar()
        Me.pictureboxLogo = New System.Windows.Forms.PictureBox()
        CType(Me.datagridviewComprobantes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusstripMain.SuspendLayout()
        Me.groupboxStatus.SuspendLayout()
        CType(Me.pictureboxLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelCantidad
        '
        Me.labelCantidad.AutoSize = True
        Me.labelCantidad.Location = New System.Drawing.Point(12, 21)
        Me.labelCantidad.Name = "labelCantidad"
        Me.labelCantidad.Size = New System.Drawing.Size(180, 13)
        Me.labelCantidad.TabIndex = 0
        Me.labelCantidad.Text = "Cantidad de Comprobantes a Enviar:"
        '
        'comboboxCantidad
        '
        Me.comboboxCantidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCantidad.FormattingEnabled = True
        Me.comboboxCantidad.Location = New System.Drawing.Point(210, 18)
        Me.comboboxCantidad.Name = "comboboxCantidad"
        Me.comboboxCantidad.Size = New System.Drawing.Size(75, 21)
        Me.comboboxCantidad.TabIndex = 1
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
        'buttonTransmitir
        '
        Me.buttonTransmitir.Location = New System.Drawing.Point(291, 18)
        Me.buttonTransmitir.Name = "buttonTransmitir"
        Me.buttonTransmitir.Size = New System.Drawing.Size(86, 21)
        Me.buttonTransmitir.TabIndex = 2
        Me.buttonTransmitir.Text = "Transmitir"
        Me.buttonTransmitir.UseVisualStyleBackColor = True
        '
        'statusstripMain
        '
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
        'groupboxStatus
        '
        Me.groupboxStatus.Controls.Add(Me.textboxStatus)
        Me.groupboxStatus.Controls.Add(Me.progressbarStatus)
        Me.groupboxStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupboxStatus.Location = New System.Drawing.Point(12, 350)
        Me.groupboxStatus.Name = "groupboxStatus"
        Me.groupboxStatus.Size = New System.Drawing.Size(668, 132)
        Me.groupboxStatus.TabIndex = 7
        Me.groupboxStatus.TabStop = False
        Me.groupboxStatus.Text = "Estado de la Transmisión:"
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
        Me.textboxStatus.TabIndex = 8
        '
        'progressbarStatus
        '
        Me.progressbarStatus.Location = New System.Drawing.Point(3, 21)
        Me.progressbarStatus.Name = "progressbarStatus"
        Me.progressbarStatus.Size = New System.Drawing.Size(660, 26)
        Me.progressbarStatus.TabIndex = 7
        '
        'pictureboxLogo
        '
        Me.pictureboxLogo.BackColor = System.Drawing.Color.White
        Me.pictureboxLogo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pictureboxLogo.Image = CType(resources.GetObject("pictureboxLogo.Image"), System.Drawing.Image)
        Me.pictureboxLogo.Location = New System.Drawing.Point(395, 6)
        Me.pictureboxLogo.Name = "pictureboxLogo"
        Me.pictureboxLogo.Size = New System.Drawing.Size(285, 51)
        Me.pictureboxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.pictureboxLogo.TabIndex = 9
        Me.pictureboxLogo.TabStop = False
        '
        'formComprobantesTransmitirPagomiscuentas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 516)
        Me.Controls.Add(Me.pictureboxLogo)
        Me.Controls.Add(Me.groupboxStatus)
        Me.Controls.Add(Me.statusstripMain)
        Me.Controls.Add(Me.buttonTransmitir)
        Me.Controls.Add(Me.datagridviewComprobantes)
        Me.Controls.Add(Me.comboboxCantidad)
        Me.Controls.Add(Me.labelCantidad)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "formComprobantesTransmitirPagomiscuentas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Transmitir Comprobantes a PagoMisCuentas"
        CType(Me.datagridviewComprobantes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusstripMain.ResumeLayout(False)
        Me.statusstripMain.PerformLayout()
        Me.groupboxStatus.ResumeLayout(False)
        Me.groupboxStatus.PerformLayout()
        CType(Me.pictureboxLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelCantidad As System.Windows.Forms.Label
    Friend WithEvents comboboxCantidad As System.Windows.Forms.ComboBox
    Friend WithEvents datagridviewComprobantes As System.Windows.Forms.DataGridView
    Friend WithEvents buttonTransmitir As System.Windows.Forms.Button
    Friend WithEvents statusstripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents statuslabelMain As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents groupboxStatus As System.Windows.Forms.GroupBox
    Friend WithEvents progressbarStatus As System.Windows.Forms.ProgressBar
    Friend WithEvents textboxStatus As System.Windows.Forms.TextBox
    Friend WithEvents columnComprobanteTipoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNumeroCompleto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnApellidoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnImporteTotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pictureboxLogo As System.Windows.Forms.PictureBox
End Class
