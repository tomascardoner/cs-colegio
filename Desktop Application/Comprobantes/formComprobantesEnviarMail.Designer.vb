﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.datagridviewComprobantes = New System.Windows.Forms.DataGridView()
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
        Me.buttonCancelar = New System.Windows.Forms.Button()
        Me.columnComprobanteTipoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNumeroCompleto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnApellidoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnImporteTotal = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewComprobantes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewComprobantes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.datagridviewComprobantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewComprobantes.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnComprobanteTipoNombre, Me.columnNumeroCompleto, Me.columnApellidoNombre, Me.columnImporteTotal})
        Me.datagridviewComprobantes.Location = New System.Drawing.Point(16, 41)
        Me.datagridviewComprobantes.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.datagridviewComprobantes.MultiSelect = False
        Me.datagridviewComprobantes.Name = "datagridviewComprobantes"
        Me.datagridviewComprobantes.ReadOnly = True
        Me.datagridviewComprobantes.RowHeadersVisible = False
        Me.datagridviewComprobantes.RowHeadersWidth = 51
        Me.datagridviewComprobantes.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewComprobantes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewComprobantes.Size = New System.Drawing.Size(891, 553)
        Me.datagridviewComprobantes.TabIndex = 5
        '
        'comboboxComprobanteLote
        '
        Me.comboboxComprobanteLote.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxComprobanteLote.FormattingEnabled = True
        Me.comboboxComprobanteLote.Location = New System.Drawing.Point(180, 7)
        Me.comboboxComprobanteLote.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.comboboxComprobanteLote.Name = "comboboxComprobanteLote"
        Me.comboboxComprobanteLote.Size = New System.Drawing.Size(321, 24)
        Me.comboboxComprobanteLote.TabIndex = 1
        '
        'labelComprobanteLote
        '
        Me.labelComprobanteLote.AutoSize = True
        Me.labelComprobanteLote.Location = New System.Drawing.Point(16, 11)
        Me.labelComprobanteLote.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelComprobanteLote.Name = "labelComprobanteLote"
        Me.labelComprobanteLote.Size = New System.Drawing.Size(147, 16)
        Me.labelComprobanteLote.TabIndex = 0
        Me.labelComprobanteLote.Text = "Lote de Comprobantes:"
        '
        'statusstripMain
        '
        Me.statusstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.statusstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statuslabelMain})
        Me.statusstripMain.Location = New System.Drawing.Point(0, 613)
        Me.statusstripMain.Name = "statusstripMain"
        Me.statusstripMain.Padding = New System.Windows.Forms.Padding(1, 0, 19, 0)
        Me.statusstripMain.Size = New System.Drawing.Size(923, 22)
        Me.statusstripMain.TabIndex = 7
        '
        'statuslabelMain
        '
        Me.statuslabelMain.Name = "statuslabelMain"
        Me.statuslabelMain.Size = New System.Drawing.Size(903, 16)
        Me.statuslabelMain.Spring = True
        Me.statuslabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'buttonEnviar
        '
        Me.buttonEnviar.Location = New System.Drawing.Point(824, 6)
        Me.buttonEnviar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.buttonEnviar.Name = "buttonEnviar"
        Me.buttonEnviar.Size = New System.Drawing.Size(83, 26)
        Me.buttonEnviar.TabIndex = 4
        Me.buttonEnviar.Text = "Enviar"
        Me.buttonEnviar.UseVisualStyleBackColor = True
        '
        'groupboxStatus
        '
        Me.groupboxStatus.Controls.Add(Me.textboxStatus)
        Me.groupboxStatus.Controls.Add(Me.progressbarStatus)
        Me.groupboxStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.groupboxStatus.Location = New System.Drawing.Point(16, 431)
        Me.groupboxStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupboxStatus.Name = "groupboxStatus"
        Me.groupboxStatus.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.groupboxStatus.Size = New System.Drawing.Size(891, 162)
        Me.groupboxStatus.TabIndex = 6
        Me.groupboxStatus.TabStop = False
        Me.groupboxStatus.Text = "Estado del envío:"
        Me.groupboxStatus.Visible = False
        '
        'textboxStatus
        '
        Me.textboxStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textboxStatus.Location = New System.Drawing.Point(9, 66)
        Me.textboxStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.textboxStatus.MaxLength = 0
        Me.textboxStatus.Multiline = True
        Me.textboxStatus.Name = "textboxStatus"
        Me.textboxStatus.ReadOnly = True
        Me.textboxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textboxStatus.Size = New System.Drawing.Size(872, 86)
        Me.textboxStatus.TabIndex = 1
        '
        'progressbarStatus
        '
        Me.progressbarStatus.Location = New System.Drawing.Point(9, 26)
        Me.progressbarStatus.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.progressbarStatus.Name = "progressbarStatus"
        Me.progressbarStatus.Size = New System.Drawing.Size(875, 32)
        Me.progressbarStatus.TabIndex = 0
        '
        'comboboxCantidad
        '
        Me.comboboxCantidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCantidad.FormattingEnabled = True
        Me.comboboxCantidad.Location = New System.Drawing.Point(679, 7)
        Me.comboboxCantidad.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.comboboxCantidad.Name = "comboboxCantidad"
        Me.comboboxCantidad.Size = New System.Drawing.Size(119, 24)
        Me.comboboxCantidad.TabIndex = 3
        '
        'labelCantidad
        '
        Me.labelCantidad.AutoSize = True
        Me.labelCantidad.Location = New System.Drawing.Point(535, 11)
        Me.labelCantidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.labelCantidad.Name = "labelCantidad"
        Me.labelCantidad.Size = New System.Drawing.Size(130, 16)
        Me.labelCantidad.TabIndex = 2
        Me.labelCantidad.Text = "Cantidad de e-mails:"
        '
        'buttonCancelar
        '
        Me.buttonCancelar.Location = New System.Drawing.Point(824, 7)
        Me.buttonCancelar.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.buttonCancelar.Name = "buttonCancelar"
        Me.buttonCancelar.Size = New System.Drawing.Size(83, 26)
        Me.buttonCancelar.TabIndex = 10
        Me.buttonCancelar.Text = "Cancelar"
        Me.buttonCancelar.UseVisualStyleBackColor = True
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
        'formComprobantesEnviarMail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(923, 635)
        Me.Controls.Add(Me.labelCantidad)
        Me.Controls.Add(Me.comboboxCantidad)
        Me.Controls.Add(Me.comboboxComprobanteLote)
        Me.Controls.Add(Me.labelComprobanteLote)
        Me.Controls.Add(Me.statusstripMain)
        Me.Controls.Add(Me.buttonEnviar)
        Me.Controls.Add(Me.groupboxStatus)
        Me.Controls.Add(Me.datagridviewComprobantes)
        Me.Controls.Add(Me.buttonCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formComprobantesEnviarMail"
        Me.ShowInTaskbar = False
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
    Friend WithEvents comboboxCantidad As System.Windows.Forms.ComboBox
    Friend WithEvents labelCantidad As System.Windows.Forms.Label
    Friend WithEvents buttonCancelar As System.Windows.Forms.Button
    Friend WithEvents columnComprobanteTipoNombre As DataGridViewTextBoxColumn
    Friend WithEvents columnNumeroCompleto As DataGridViewTextBoxColumn
    Friend WithEvents columnApellidoNombre As DataGridViewTextBoxColumn
    Friend WithEvents columnImporteTotal As DataGridViewTextBoxColumn
End Class
