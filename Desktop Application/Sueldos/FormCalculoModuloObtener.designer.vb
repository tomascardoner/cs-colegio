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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ToolStripFiltroAnio = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButtonObtenerDatos = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripComboBoxMes = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabelMes = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripComboBoxAnio = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripLabelAnio = New System.Windows.Forms.ToolStripLabel()
        Me.DataGridViewMain = New System.Windows.Forms.DataGridView()
        Me.DataGridViewColumnCodigo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnConcepto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewColumnImporte = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ToolStripFiltroAnio.SuspendLayout()
        CType(Me.DataGridViewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripFiltroAnio
        '
        Me.ToolStripFiltroAnio.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStripFiltroAnio.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStripFiltroAnio.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonObtenerDatos, Me.ToolStripButtonGuardar, Me.ToolStripComboBoxMes, Me.ToolStripLabelMes, Me.ToolStripComboBoxAnio, Me.ToolStripLabelAnio})
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
        'ToolStripComboBoxMes
        '
        Me.ToolStripComboBoxMes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripComboBoxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBoxMes.Name = "ToolStripComboBoxMes"
        Me.ToolStripComboBoxMes.Size = New System.Drawing.Size(159, 39)
        '
        'ToolStripLabelMes
        '
        Me.ToolStripLabelMes.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabelMes.Name = "ToolStripLabelMes"
        Me.ToolStripLabelMes.Size = New System.Drawing.Size(39, 36)
        Me.ToolStripLabelMes.Text = "Mes:"
        '
        'ToolStripComboBoxAnio
        '
        Me.ToolStripComboBoxAnio.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripComboBoxAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ToolStripComboBoxAnio.Name = "ToolStripComboBoxAnio"
        Me.ToolStripComboBoxAnio.Size = New System.Drawing.Size(75, 39)
        '
        'ToolStripLabelAnio
        '
        Me.ToolStripLabelAnio.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabelAnio.Name = "ToolStripLabelAnio"
        Me.ToolStripLabelAnio.Size = New System.Drawing.Size(39, 36)
        Me.ToolStripLabelAnio.Text = "Año:"
        '
        'DataGridViewMain
        '
        Me.DataGridViewMain.AllowUserToAddRows = False
        Me.DataGridViewMain.AllowUserToDeleteRows = False
        Me.DataGridViewMain.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.DataGridViewMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
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
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridViewColumnCodigo.DefaultCellStyle = DataGridViewCellStyle2
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
        DataGridViewCellStyle3.Format = "C2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DataGridViewColumnImporte.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewColumnImporte.HeaderText = "Importe"
        Me.DataGridViewColumnImporte.MinimumWidth = 6
        Me.DataGridViewColumnImporte.Name = "DataGridViewColumnImporte"
        Me.DataGridViewColumnImporte.ReadOnly = True
        Me.DataGridViewColumnImporte.Width = 81
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
    Friend WithEvents ToolStripLabelAnio As ToolStripLabel
    Friend WithEvents ToolStripComboBoxAnio As ToolStripComboBox
    Friend WithEvents ToolStripLabelMes As ToolStripLabel
    Friend WithEvents ToolStripComboBoxMes As ToolStripComboBox
    Friend WithEvents ToolStripButtonObtenerDatos As ToolStripButton
    Friend WithEvents ToolStripButtonGuardar As ToolStripButton
    Friend WithEvents DataGridViewMain As DataGridView
    Friend WithEvents DataGridViewColumnCodigo As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnConcepto As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewColumnImporte As DataGridViewTextBoxColumn
End Class
