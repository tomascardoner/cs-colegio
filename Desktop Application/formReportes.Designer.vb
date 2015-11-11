<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formReportes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formReportes))
        Me.panelReportes = New System.Windows.Forms.Panel()
        Me.treeviewReportes = New System.Windows.Forms.TreeView()
        Me.buttonSiguiente = New System.Windows.Forms.Button()
        Me.panelParametros = New System.Windows.Forms.Panel()
        Me.labelParametrosTitulo = New System.Windows.Forms.Label()
        Me.listviewParametros = New System.Windows.Forms.ListView()
        Me.columnNombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnRequerido = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnValor = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.buttonAnterior = New System.Windows.Forms.Button()
        Me.buttonPrevisualizar = New System.Windows.Forms.Button()
        Me.buttonImprimir = New System.Windows.Forms.Button()
        Me.panelReportes.SuspendLayout()
        Me.panelParametros.SuspendLayout()
        Me.SuspendLayout()
        '
        'panelReportes
        '
        Me.panelReportes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelReportes.Controls.Add(Me.treeviewReportes)
        Me.panelReportes.Controls.Add(Me.buttonSiguiente)
        Me.panelReportes.Location = New System.Drawing.Point(12, 12)
        Me.panelReportes.Name = "panelReportes"
        Me.panelReportes.Size = New System.Drawing.Size(566, 386)
        Me.panelReportes.TabIndex = 0
        '
        'treeviewReportes
        '
        Me.treeviewReportes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.treeviewReportes.HideSelection = False
        Me.treeviewReportes.Location = New System.Drawing.Point(0, 0)
        Me.treeviewReportes.Name = "treeviewReportes"
        Me.treeviewReportes.Size = New System.Drawing.Size(566, 330)
        Me.treeviewReportes.TabIndex = 0
        '
        'buttonSiguiente
        '
        Me.buttonSiguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonSiguiente.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_NEXT_24
        Me.buttonSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.buttonSiguiente.Location = New System.Drawing.Point(446, 342)
        Me.buttonSiguiente.Name = "buttonSiguiente"
        Me.buttonSiguiente.Size = New System.Drawing.Size(120, 44)
        Me.buttonSiguiente.TabIndex = 1
        Me.buttonSiguiente.Text = "Siguiente"
        Me.buttonSiguiente.UseVisualStyleBackColor = True
        '
        'panelParametros
        '
        Me.panelParametros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.panelParametros.Controls.Add(Me.labelParametrosTitulo)
        Me.panelParametros.Controls.Add(Me.listviewParametros)
        Me.panelParametros.Controls.Add(Me.buttonAnterior)
        Me.panelParametros.Controls.Add(Me.buttonPrevisualizar)
        Me.panelParametros.Controls.Add(Me.buttonImprimir)
        Me.panelParametros.Location = New System.Drawing.Point(12, 12)
        Me.panelParametros.Name = "panelParametros"
        Me.panelParametros.Size = New System.Drawing.Size(566, 386)
        Me.panelParametros.TabIndex = 1
        '
        'labelParametrosTitulo
        '
        Me.labelParametrosTitulo.AutoSize = True
        Me.labelParametrosTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelParametrosTitulo.Location = New System.Drawing.Point(0, 0)
        Me.labelParametrosTitulo.Name = "labelParametrosTitulo"
        Me.labelParametrosTitulo.Size = New System.Drawing.Size(92, 16)
        Me.labelParametrosTitulo.TabIndex = 4
        Me.labelParametrosTitulo.Text = "Parámetros:"
        '
        'listviewParametros
        '
        Me.listviewParametros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.listviewParametros.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnNombre, Me.columnRequerido, Me.columnValor})
        Me.listviewParametros.FullRowSelect = True
        Me.listviewParametros.GridLines = True
        Me.listviewParametros.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.listviewParametros.HideSelection = False
        Me.listviewParametros.Location = New System.Drawing.Point(0, 21)
        Me.listviewParametros.MultiSelect = False
        Me.listviewParametros.Name = "listviewParametros"
        Me.listviewParametros.ShowGroups = False
        Me.listviewParametros.Size = New System.Drawing.Size(566, 312)
        Me.listviewParametros.TabIndex = 0
        Me.listviewParametros.UseCompatibleStateImageBehavior = False
        Me.listviewParametros.View = System.Windows.Forms.View.Details
        '
        'columnNombre
        '
        Me.columnNombre.Text = "Nombre"
        Me.columnNombre.Width = 300
        '
        'columnRequerido
        '
        Me.columnRequerido.Text = "Requerido"
        Me.columnRequerido.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.columnRequerido.Width = 80
        '
        'columnValor
        '
        Me.columnValor.Text = "Valor"
        Me.columnValor.Width = 250
        '
        'buttonAnterior
        '
        Me.buttonAnterior.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.buttonAnterior.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_MOVE_PREVIOUS_24
        Me.buttonAnterior.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.buttonAnterior.Location = New System.Drawing.Point(0, 342)
        Me.buttonAnterior.Name = "buttonAnterior"
        Me.buttonAnterior.Size = New System.Drawing.Size(120, 44)
        Me.buttonAnterior.TabIndex = 1
        Me.buttonAnterior.Text = "Anterior"
        Me.buttonAnterior.UseVisualStyleBackColor = True
        '
        'buttonPrevisualizar
        '
        Me.buttonPrevisualizar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonPrevisualizar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_PRINT_PREVIEW_32
        Me.buttonPrevisualizar.Location = New System.Drawing.Point(446, 342)
        Me.buttonPrevisualizar.Name = "buttonPrevisualizar"
        Me.buttonPrevisualizar.Size = New System.Drawing.Size(120, 44)
        Me.buttonPrevisualizar.TabIndex = 3
        Me.buttonPrevisualizar.Text = "Previsualizar"
        Me.buttonPrevisualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.buttonPrevisualizar.UseVisualStyleBackColor = True
        '
        'buttonImprimir
        '
        Me.buttonImprimir.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonImprimir.Image = CType(resources.GetObject("buttonImprimir.Image"), System.Drawing.Image)
        Me.buttonImprimir.Location = New System.Drawing.Point(320, 342)
        Me.buttonImprimir.Name = "buttonImprimir"
        Me.buttonImprimir.Size = New System.Drawing.Size(120, 44)
        Me.buttonImprimir.TabIndex = 2
        Me.buttonImprimir.Text = "Imprimir"
        Me.buttonImprimir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.buttonImprimir.UseVisualStyleBackColor = True
        '
        'formReportes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(591, 410)
        Me.Controls.Add(Me.panelReportes)
        Me.Controls.Add(Me.panelParametros)
        Me.Name = "formReportes"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reportes"
        Me.panelReportes.ResumeLayout(False)
        Me.panelParametros.ResumeLayout(False)
        Me.panelParametros.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents panelReportes As System.Windows.Forms.Panel
    Friend WithEvents buttonSiguiente As System.Windows.Forms.Button
    Friend WithEvents treeviewReportes As System.Windows.Forms.TreeView
    Friend WithEvents panelParametros As System.Windows.Forms.Panel
    Friend WithEvents buttonAnterior As System.Windows.Forms.Button
    Friend WithEvents buttonPrevisualizar As System.Windows.Forms.Button
    Friend WithEvents buttonImprimir As System.Windows.Forms.Button
    Friend WithEvents listviewParametros As System.Windows.Forms.ListView
    Friend WithEvents columnNombre As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnValor As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnRequerido As System.Windows.Forms.ColumnHeader
    Friend WithEvents labelParametrosTitulo As System.Windows.Forms.Label
End Class
