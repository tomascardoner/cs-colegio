<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formEntidadesVerificadorEmail
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
        Me.labelDireccionesEmail = New System.Windows.Forms.Label()
        Me.textboxDireccionesEmail = New System.Windows.Forms.TextBox()
        Me.buttonBuscarEntidades = New System.Windows.Forms.Button()
        Me.buttonMarcarEntidades = New System.Windows.Forms.Button()
        Me.datagridviewEntidades = New System.Windows.Forms.DataGridView()
        Me.columnApellidoNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnEmail1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnEmail2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.buttonBuscarEnOutlook = New System.Windows.Forms.Button()
        Me.labelOutlookFechaDesde = New System.Windows.Forms.Label()
        Me.datetimepickerOutlookFechaDesde = New System.Windows.Forms.DateTimePicker()
        Me.datetimepickerOutlookFechaHasta = New System.Windows.Forms.DateTimePicker()
        Me.labelOutlookFechaHasta = New System.Windows.Forms.Label()
        CType(Me.datagridviewEntidades, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'labelDireccionesEmail
        '
        Me.labelDireccionesEmail.AutoSize = True
        Me.labelDireccionesEmail.Location = New System.Drawing.Point(12, 42)
        Me.labelDireccionesEmail.Name = "labelDireccionesEmail"
        Me.labelDireccionesEmail.Size = New System.Drawing.Size(254, 13)
        Me.labelDireccionesEmail.TabIndex = 5
        Me.labelDireccionesEmail.Text = "Direcciones de e-mail (separadas por punto y coma):"
        '
        'textboxDireccionesEmail
        '
        Me.textboxDireccionesEmail.Location = New System.Drawing.Point(10, 61)
        Me.textboxDireccionesEmail.Multiline = True
        Me.textboxDireccionesEmail.Name = "textboxDireccionesEmail"
        Me.textboxDireccionesEmail.Size = New System.Drawing.Size(610, 115)
        Me.textboxDireccionesEmail.TabIndex = 6
        '
        'buttonBuscarEntidades
        '
        Me.buttonBuscarEntidades.Location = New System.Drawing.Point(496, 182)
        Me.buttonBuscarEntidades.Name = "buttonBuscarEntidades"
        Me.buttonBuscarEntidades.Size = New System.Drawing.Size(124, 23)
        Me.buttonBuscarEntidades.TabIndex = 7
        Me.buttonBuscarEntidades.Text = "Buscar en Entidades"
        Me.buttonBuscarEntidades.UseVisualStyleBackColor = True
        '
        'buttonMarcarEntidades
        '
        Me.buttonMarcarEntidades.Location = New System.Drawing.Point(394, 457)
        Me.buttonMarcarEntidades.Name = "buttonMarcarEntidades"
        Me.buttonMarcarEntidades.Size = New System.Drawing.Size(226, 23)
        Me.buttonMarcarEntidades.TabIndex = 9
        Me.buttonMarcarEntidades.Text = "Marcar direcciones de e-mail para verificar"
        Me.buttonMarcarEntidades.UseVisualStyleBackColor = True
        '
        'datagridviewEntidades
        '
        Me.datagridviewEntidades.AllowUserToAddRows = False
        Me.datagridviewEntidades.AllowUserToDeleteRows = False
        Me.datagridviewEntidades.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewEntidades.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewEntidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.datagridviewEntidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewEntidades.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnApellidoNombre, Me.columnEmail1, Me.columnEmail2})
        Me.datagridviewEntidades.Location = New System.Drawing.Point(10, 221)
        Me.datagridviewEntidades.MultiSelect = False
        Me.datagridviewEntidades.Name = "datagridviewEntidades"
        Me.datagridviewEntidades.ReadOnly = True
        Me.datagridviewEntidades.RowHeadersVisible = False
        Me.datagridviewEntidades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewEntidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewEntidades.Size = New System.Drawing.Size(610, 230)
        Me.datagridviewEntidades.TabIndex = 8
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
        'columnEmail1
        '
        Me.columnEmail1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnEmail1.DataPropertyName = "Email1"
        Me.columnEmail1.HeaderText = "e-Mail 1"
        Me.columnEmail1.Name = "columnEmail1"
        Me.columnEmail1.ReadOnly = True
        Me.columnEmail1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnEmail1.Width = 45
        '
        'columnEmail2
        '
        Me.columnEmail2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnEmail2.DataPropertyName = "Email2"
        Me.columnEmail2.HeaderText = "e-Mail 2"
        Me.columnEmail2.Name = "columnEmail2"
        Me.columnEmail2.ReadOnly = True
        Me.columnEmail2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.columnEmail2.Width = 45
        '
        'buttonBuscarEnOutlook
        '
        Me.buttonBuscarEnOutlook.Location = New System.Drawing.Point(350, 32)
        Me.buttonBuscarEnOutlook.Name = "buttonBuscarEnOutlook"
        Me.buttonBuscarEnOutlook.Size = New System.Drawing.Size(272, 23)
        Me.buttonBuscarEnOutlook.TabIndex = 4
        Me.buttonBuscarEnOutlook.Text = "Buscar en Bandeja de entrada de Microsoft Outlook"
        Me.buttonBuscarEnOutlook.UseVisualStyleBackColor = True
        '
        'labelOutlookFechaDesde
        '
        Me.labelOutlookFechaDesde.AutoSize = True
        Me.labelOutlookFechaDesde.Location = New System.Drawing.Point(272, 9)
        Me.labelOutlookFechaDesde.Name = "labelOutlookFechaDesde"
        Me.labelOutlookFechaDesde.Size = New System.Drawing.Size(72, 13)
        Me.labelOutlookFechaDesde.TabIndex = 0
        Me.labelOutlookFechaDesde.Text = "Fecha desde:"
        '
        'datetimepickerOutlookFechaDesde
        '
        Me.datetimepickerOutlookFechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerOutlookFechaDesde.Location = New System.Drawing.Point(350, 6)
        Me.datetimepickerOutlookFechaDesde.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerOutlookFechaDesde.MinDate = New Date(2016, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerOutlookFechaDesde.Name = "datetimepickerOutlookFechaDesde"
        Me.datetimepickerOutlookFechaDesde.Size = New System.Drawing.Size(111, 20)
        Me.datetimepickerOutlookFechaDesde.TabIndex = 1
        '
        'datetimepickerOutlookFechaHasta
        '
        Me.datetimepickerOutlookFechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.datetimepickerOutlookFechaHasta.Location = New System.Drawing.Point(509, 6)
        Me.datetimepickerOutlookFechaHasta.MaxDate = New Date(2100, 12, 31, 0, 0, 0, 0)
        Me.datetimepickerOutlookFechaHasta.MinDate = New Date(2016, 1, 1, 0, 0, 0, 0)
        Me.datetimepickerOutlookFechaHasta.Name = "datetimepickerOutlookFechaHasta"
        Me.datetimepickerOutlookFechaHasta.Size = New System.Drawing.Size(111, 20)
        Me.datetimepickerOutlookFechaHasta.TabIndex = 3
        '
        'labelOutlookFechaHasta
        '
        Me.labelOutlookFechaHasta.AutoSize = True
        Me.labelOutlookFechaHasta.Location = New System.Drawing.Point(467, 9)
        Me.labelOutlookFechaHasta.Name = "labelOutlookFechaHasta"
        Me.labelOutlookFechaHasta.Size = New System.Drawing.Size(36, 13)
        Me.labelOutlookFechaHasta.TabIndex = 2
        Me.labelOutlookFechaHasta.Text = "hasta:"
        '
        'formEntidadesVerificadorEmail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 494)
        Me.Controls.Add(Me.datetimepickerOutlookFechaHasta)
        Me.Controls.Add(Me.labelOutlookFechaHasta)
        Me.Controls.Add(Me.datetimepickerOutlookFechaDesde)
        Me.Controls.Add(Me.labelOutlookFechaDesde)
        Me.Controls.Add(Me.buttonBuscarEnOutlook)
        Me.Controls.Add(Me.datagridviewEntidades)
        Me.Controls.Add(Me.buttonMarcarEntidades)
        Me.Controls.Add(Me.buttonBuscarEntidades)
        Me.Controls.Add(Me.textboxDireccionesEmail)
        Me.Controls.Add(Me.labelDireccionesEmail)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "formEntidadesVerificadorEmail"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Verificar direcciones de e-mail"
        CType(Me.datagridviewEntidades, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelDireccionesEmail As System.Windows.Forms.Label
    Friend WithEvents textboxDireccionesEmail As System.Windows.Forms.TextBox
    Friend WithEvents buttonBuscarEntidades As System.Windows.Forms.Button
    Friend WithEvents buttonMarcarEntidades As System.Windows.Forms.Button
    Friend WithEvents datagridviewEntidades As System.Windows.Forms.DataGridView
    Friend WithEvents columnApellidoNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnEmail1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnEmail2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents buttonBuscarEnOutlook As System.Windows.Forms.Button
    Friend WithEvents labelOutlookFechaDesde As System.Windows.Forms.Label
    Friend WithEvents datetimepickerOutlookFechaDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents datetimepickerOutlookFechaHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents labelOutlookFechaHasta As System.Windows.Forms.Label
End Class
