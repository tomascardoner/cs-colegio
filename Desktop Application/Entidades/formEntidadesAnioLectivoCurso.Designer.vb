﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formEntidadesAnioLectivoCurso
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.labelAnioLectivo = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxAnioLectivo = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.labelNivel = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxNivel = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.labelCurso = New System.Windows.Forms.ToolStripLabel()
        Me.comboboxCurso = New System.Windows.Forms.ToolStripComboBox()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.buttonAgregar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEliminar = New System.Windows.Forms.ToolStripButton()
        Me.datagridviewMain = New System.Windows.Forms.DataGridView()
        Me.columnIDEntidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnApellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.columnNombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.statusstripMain = New System.Windows.Forms.StatusStrip()
        Me.statuslabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.menuitemImprimir = New System.Windows.Forms.ToolStripSplitButton()
        Me.menuitemImprimirListadoCompleto = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuitemImprimirListadoDelCurso = New System.Windows.Forms.ToolStripMenuItem()
        Me.toolstripMain.SuspendLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusstripMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.labelAnioLectivo, Me.comboboxAnioLectivo, Me.ToolStripSeparator2, Me.labelNivel, Me.comboboxNivel, Me.ToolStripSeparator1, Me.labelCurso, Me.comboboxCurso, Me.ToolStripSeparator3, Me.buttonAgregar, Me.buttonEliminar, Me.menuitemImprimir})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(896, 39)
        Me.toolstripMain.TabIndex = 0
        '
        'labelAnioLectivo
        '
        Me.labelAnioLectivo.Name = "labelAnioLectivo"
        Me.labelAnioLectivo.Size = New System.Drawing.Size(73, 36)
        Me.labelAnioLectivo.Text = "Año Lectivo:"
        '
        'comboboxAnioLectivo
        '
        Me.comboboxAnioLectivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxAnioLectivo.DropDownWidth = 76
        Me.comboboxAnioLectivo.Name = "comboboxAnioLectivo"
        Me.comboboxAnioLectivo.Size = New System.Drawing.Size(75, 39)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 39)
        '
        'labelNivel
        '
        Me.labelNivel.Name = "labelNivel"
        Me.labelNivel.Size = New System.Drawing.Size(37, 36)
        Me.labelNivel.Text = "Nivel:"
        '
        'comboboxNivel
        '
        Me.comboboxNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxNivel.Name = "comboboxNivel"
        Me.comboboxNivel.Size = New System.Drawing.Size(121, 39)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 39)
        '
        'labelCurso
        '
        Me.labelCurso.Name = "labelCurso"
        Me.labelCurso.Size = New System.Drawing.Size(41, 36)
        Me.labelCurso.Text = "Curso:"
        '
        'comboboxCurso
        '
        Me.comboboxCurso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCurso.Name = "comboboxCurso"
        Me.comboboxCurso.Size = New System.Drawing.Size(220, 39)
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 39)
        '
        'buttonAgregar
        '
        Me.buttonAgregar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_ADD_32
        Me.buttonAgregar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonAgregar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonAgregar.Name = "buttonAgregar"
        Me.buttonAgregar.Size = New System.Drawing.Size(85, 36)
        Me.buttonAgregar.Text = "Agregar"
        '
        'buttonEliminar
        '
        Me.buttonEliminar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_DELETE_32
        Me.buttonEliminar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEliminar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEliminar.Name = "buttonEliminar"
        Me.buttonEliminar.Size = New System.Drawing.Size(86, 36)
        Me.buttonEliminar.Text = "Eliminar"
        '
        'datagridviewMain
        '
        Me.datagridviewMain.AllowUserToAddRows = False
        Me.datagridviewMain.AllowUserToDeleteRows = False
        Me.datagridviewMain.AllowUserToOrderColumns = True
        Me.datagridviewMain.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.datagridviewMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datagridviewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewMain.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.columnIDEntidad, Me.columnApellido, Me.columnNombre})
        Me.datagridviewMain.Location = New System.Drawing.Point(0, 39)
        Me.datagridviewMain.MultiSelect = False
        Me.datagridviewMain.Name = "datagridviewMain"
        Me.datagridviewMain.ReadOnly = True
        Me.datagridviewMain.RowHeadersVisible = False
        Me.datagridviewMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.datagridviewMain.Size = New System.Drawing.Size(896, 282)
        Me.datagridviewMain.TabIndex = 1
        '
        'columnIDEntidad
        '
        Me.columnIDEntidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnIDEntidad.DataPropertyName = "IDEntidad"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.columnIDEntidad.DefaultCellStyle = DataGridViewCellStyle6
        Me.columnIDEntidad.HeaderText = "N° Entidad"
        Me.columnIDEntidad.Name = "columnIDEntidad"
        Me.columnIDEntidad.ReadOnly = True
        Me.columnIDEntidad.Width = 83
        '
        'columnApellido
        '
        Me.columnApellido.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnApellido.DataPropertyName = "Apellido"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnApellido.DefaultCellStyle = DataGridViewCellStyle7
        Me.columnApellido.HeaderText = "Apellido"
        Me.columnApellido.Name = "columnApellido"
        Me.columnApellido.ReadOnly = True
        Me.columnApellido.Width = 69
        '
        'columnNombre
        '
        Me.columnNombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.columnNombre.DataPropertyName = "Nombre"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.columnNombre.DefaultCellStyle = DataGridViewCellStyle8
        Me.columnNombre.HeaderText = "Nombre"
        Me.columnNombre.Name = "columnNombre"
        Me.columnNombre.ReadOnly = True
        Me.columnNombre.Width = 69
        '
        'statusstripMain
        '
        Me.statusstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statuslabelMain})
        Me.statusstripMain.Location = New System.Drawing.Point(0, 324)
        Me.statusstripMain.Name = "statusstripMain"
        Me.statusstripMain.Size = New System.Drawing.Size(896, 22)
        Me.statusstripMain.TabIndex = 2
        '
        'statuslabelMain
        '
        Me.statuslabelMain.Name = "statuslabelMain"
        Me.statuslabelMain.Size = New System.Drawing.Size(881, 17)
        Me.statuslabelMain.Spring = True
        Me.statuslabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'menuitemImprimir
        '
        Me.menuitemImprimir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuitemImprimirListadoCompleto, Me.menuitemImprimirListadoDelCurso})
        Me.menuitemImprimir.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_PRINT_32
        Me.menuitemImprimir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.menuitemImprimir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.menuitemImprimir.Name = "menuitemImprimir"
        Me.menuitemImprimir.Size = New System.Drawing.Size(101, 36)
        Me.menuitemImprimir.Text = "Imprimir"
        '
        'menuitemImprimirListadoCompleto
        '
        Me.menuitemImprimirListadoCompleto.Name = "menuitemImprimirListadoCompleto"
        Me.menuitemImprimirListadoCompleto.Size = New System.Drawing.Size(168, 22)
        Me.menuitemImprimirListadoCompleto.Text = "Listado Completo"
        '
        'menuitemImprimirListadoDelCurso
        '
        Me.menuitemImprimirListadoDelCurso.Name = "menuitemImprimirListadoDelCurso"
        Me.menuitemImprimirListadoDelCurso.Size = New System.Drawing.Size(168, 22)
        Me.menuitemImprimirListadoDelCurso.Text = "Listado del Curso"
        '
        'formEntidadesAnioLectivoCurso
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(896, 346)
        Me.Controls.Add(Me.statusstripMain)
        Me.Controls.Add(Me.datagridviewMain)
        Me.Controls.Add(Me.toolstripMain)
        Me.Name = "formEntidadesAnioLectivoCurso"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Entidades por Año Lectivo y Curso"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusstripMain.ResumeLayout(False)
        Me.statusstripMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents labelAnioLectivo As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxAnioLectivo As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents labelCurso As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxCurso As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents buttonAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents datagridviewMain As System.Windows.Forms.DataGridView
    Friend WithEvents labelNivel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents comboboxNivel As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents statusstripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents statuslabelMain As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents columnIDEntidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnApellido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents columnNombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents menuitemImprimir As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents menuitemImprimirListadoCompleto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuitemImprimirListadoDelCurso As System.Windows.Forms.ToolStripMenuItem
End Class
