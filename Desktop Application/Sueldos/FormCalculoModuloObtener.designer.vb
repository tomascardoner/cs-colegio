<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCalculoModuloObtener
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripFiltroAnio = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonObtenerDatos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.DataGridViewMain = New System.Windows.Forms.DataGridView()
        Me.DataGridViewColumnCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnImporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripLabelPeriodo = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripFiltroAnio.SuspendLayout()
        CType(Me.DataGridViewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripFiltroAnio
        '
        Me.ToolStripFiltroAnio.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripFiltroAnio.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripFiltroAnio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonObtenerDatos, Me.ToolStripButtonGuardar, Me.ToolStripSeparator1, Me.ToolStripLabelPeriodo})
        Me.ToolStripFiltroAnio.Location = New System.Drawing.Point(0, 0)
        Me.ToolStripFiltroAnio.Name = "ToolStripFiltroAnio"
        Me.ToolStripFiltroAnio.Size = New System.Drawing.Size(658, 39)
        Me.ToolStripFiltroAnio.TabIndex = 15
        '
        'ToolStripButtonObtenerDatos
        '
        Me.ToolStripButtonObtenerDatos.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageCalcular32
        Me.ToolStripButtonObtenerDatos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonObtenerDatos.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonObtenerDatos.Name = "ToolStripButtonObtenerDatos"
        Me.ToolStripButtonObtenerDatos.Size = New System.Drawing.Size(140, 36)
        Me.ToolStripButtonObtenerDatos.Text = "Obtener datos"
        '
        'ToolStripButtonGuardar
        '
        Me.ToolStripButtonGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonGuardar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageAceptar32
        Me.ToolStripButtonGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonGuardar.Name = "ToolStripButtonGuardar"
        Me.ToolStripButtonGuardar.Size = New System.Drawing.Size(98, 36)
        Me.ToolStripButtonGuardar.Text = "Guardar"
        '
        'DataGridViewMain
        '
        Me.DataGridViewMain.AllowUserToAddRows = False
        Me.DataGridViewMain.AllowUserToDeleteRows = False
        Me.DataGridViewMain.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridViewMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridViewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridViewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewColumnCodigo, Me.DataGridViewColumnConcepto, Me.DataGridViewColumnImporte})
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
        Me.DataGridViewMain.Size = New System.Drawing.Size(658, 316)
        Me.DataGridViewMain.TabIndex = 16
        '
        'DataGridViewColumnCodigo
        '
        Me.DataGridViewColumnCodigo.DataPropertyName = "Codigo"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewColumnCodigo.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewColumnCodigo.HeaderText = "Código"
        Me.DataGridViewColumnCodigo.MinimumWidth = 6
        Me.DataGridViewColumnCodigo.Name = "DataGridViewColumnCodigo"
        Me.DataGridViewColumnCodigo.ReadOnly = True
        Me.DataGridViewColumnCodigo.Width = 80
        '
        'DataGridViewColumnConcepto
        '
        Me.DataGridViewColumnConcepto.DataPropertyName = "Concepto"
        Me.DataGridViewColumnConcepto.HeaderText = "Concepto"
        Me.DataGridViewColumnConcepto.MinimumWidth = 6
        Me.DataGridViewColumnConcepto.Name = "DataGridViewColumnConcepto"
        Me.DataGridViewColumnConcepto.ReadOnly = True
        Me.DataGridViewColumnConcepto.Width = 94
        '
        'DataGridViewColumnImporte
        '
        Me.DataGridViewColumnImporte.DataPropertyName = "Importe"
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DataGridViewColumnImporte.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewColumnImporte.HeaderText = "Importe"
        Me.DataGridViewColumnImporte.MinimumWidth = 6
        Me.DataGridViewColumnImporte.Name = "DataGridViewColumnImporte"
        Me.DataGridViewColumnImporte.ReadOnly = True
        Me.DataGridViewColumnImporte.Width = 81
        '
        'ToolStripLabelPeriodo
        '
        Me.ToolStripLabelPeriodo.Name = "ToolStripLabelPeriodo"
        Me.ToolStripLabelPeriodo.Size = New System.Drawing.Size(0, 36)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'FormCalculoModuloObtener
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(658, 355)
        Me.Controls.Add(Me.DataGridViewMain)
        Me.Controls.Add(Me.ToolStripFiltroAnio)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCalculoModuloObtener"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Obtener datos de módulo de sueldos"
        Me.ToolStripFiltroAnio.ResumeLayout(False)
        Me.ToolStripFiltroAnio.PerformLayout()
        CType(Me.DataGridViewMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripFiltroAnio As ToolStrip
    Friend WithEvents ToolStripButtonObtenerDatos As ToolStripButton
    Friend WithEvents ToolStripButtonGuardar As ToolStripButton
    Friend WithEvents DataGridViewMain As DataGridView
    Friend WithEvents DataGridViewColumnCodigo As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnConcepto As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnImporte As DataGridViewTextBoxColumn
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripLabelPeriodo As ToolStripLabel
End Class
