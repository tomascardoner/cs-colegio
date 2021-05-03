<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formUsuarioGrupoPermisos
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
        Me.labelUsuarioGrupo = New System.Windows.Forms.Label()
        Me.comboboxUsuarioGrupo = New System.Windows.Forms.ComboBox()
        Me.treeviewPermisos = New System.Windows.Forms.TreeView()
        Me.SuspendLayout()
        '
        'labelUsuarioGrupo
        '
        Me.labelUsuarioGrupo.AutoSize = True
        Me.labelUsuarioGrupo.Location = New System.Drawing.Point(12, 15)
        Me.labelUsuarioGrupo.Name = "labelUsuarioGrupo"
        Me.labelUsuarioGrupo.Size = New System.Drawing.Size(98, 13)
        Me.labelUsuarioGrupo.TabIndex = 0
        Me.labelUsuarioGrupo.Text = "Grupo de Usuarios:"
        '
        'comboboxUsuarioGrupo
        '
        Me.comboboxUsuarioGrupo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.comboboxUsuarioGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxUsuarioGrupo.FormattingEnabled = True
        Me.comboboxUsuarioGrupo.Location = New System.Drawing.Point(134, 12)
        Me.comboboxUsuarioGrupo.Name = "comboboxUsuarioGrupo"
        Me.comboboxUsuarioGrupo.Size = New System.Drawing.Size(582, 21)
        Me.comboboxUsuarioGrupo.TabIndex = 1
        '
        'treeviewPermisos
        '
        Me.treeviewPermisos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.treeviewPermisos.CheckBoxes = True
        Me.treeviewPermisos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.treeviewPermisos.Location = New System.Drawing.Point(12, 39)
        Me.treeviewPermisos.Name = "treeviewPermisos"
        Me.treeviewPermisos.Size = New System.Drawing.Size(704, 422)
        Me.treeviewPermisos.TabIndex = 2
        '
        'formUsuarioGrupoPermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 473)
        Me.Controls.Add(Me.treeviewPermisos)
        Me.Controls.Add(Me.comboboxUsuarioGrupo)
        Me.Controls.Add(Me.labelUsuarioGrupo)
        Me.Name = "formUsuarioGrupoPermisos"
        Me.ShowInTaskbar = False
        Me.Text = "Permisos del Grupo de Usuarios"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelUsuarioGrupo As System.Windows.Forms.Label
    Friend WithEvents comboboxUsuarioGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents treeviewPermisos As System.Windows.Forms.TreeView
End Class
