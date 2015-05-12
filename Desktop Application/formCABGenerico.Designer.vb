<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formCABGenerico
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
                FormDBContext.Dispose()
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formCABGenerico))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.bindingsourceMain = New System.Windows.Forms.BindingSource(Me.components)
        Me.statusstripMain = New System.Windows.Forms.StatusStrip()
        Me.statuslabelMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.flowlayoutpanelMain = New System.Windows.Forms.FlowLayoutPanel()
        Me.bindingnavigatorMain = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.bindingnavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingnavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.bindingnavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingnavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingnavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingnavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.bindingnavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.bindingnavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.bindingnavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingnavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.bindingnavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.bindingnavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.datagridviewMain = New System.Windows.Forms.DataGridView()
        CType(Me.bindingsourceMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.statusstripMain.SuspendLayout()
        Me.flowlayoutpanelMain.SuspendLayout()
        CType(Me.bindingnavigatorMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.bindingnavigatorMain.SuspendLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'bindingsourceMain
        '
        '
        'statusstripMain
        '
        Me.statusstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statuslabelMain})
        Me.statusstripMain.Location = New System.Drawing.Point(0, 395)
        Me.statusstripMain.Name = "statusstripMain"
        Me.statusstripMain.Size = New System.Drawing.Size(708, 22)
        Me.statusstripMain.TabIndex = 3
        Me.statusstripMain.Text = "StatusStrip1"
        '
        'statuslabelMain
        '
        Me.statuslabelMain.Name = "statuslabelMain"
        Me.statuslabelMain.Size = New System.Drawing.Size(693, 17)
        Me.statuslabelMain.Spring = True
        Me.statuslabelMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'flowlayoutpanelMain
        '
        Me.flowlayoutpanelMain.AutoSize = True
        Me.flowlayoutpanelMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowlayoutpanelMain.Controls.Add(Me.bindingnavigatorMain)
        Me.flowlayoutpanelMain.Dock = System.Windows.Forms.DockStyle.Top
        Me.flowlayoutpanelMain.Location = New System.Drawing.Point(0, 0)
        Me.flowlayoutpanelMain.Name = "flowlayoutpanelMain"
        Me.flowlayoutpanelMain.Size = New System.Drawing.Size(708, 25)
        Me.flowlayoutpanelMain.TabIndex = 4
        '
        'bindingnavigatorMain
        '
        Me.bindingnavigatorMain.AddNewItem = Me.bindingnavigatorAddNewItem
        Me.bindingnavigatorMain.BindingSource = Me.bindingsourceMain
        Me.bindingnavigatorMain.CountItem = Me.bindingnavigatorCountItem
        Me.bindingnavigatorMain.CountItemFormat = "de {0}"
        Me.bindingnavigatorMain.DeleteItem = Me.bindingnavigatorDeleteItem
        Me.bindingnavigatorMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.bindingnavigatorMoveFirstItem, Me.bindingnavigatorMovePreviousItem, Me.bindingnavigatorSeparator, Me.bindingnavigatorPositionItem, Me.bindingnavigatorCountItem, Me.bindingnavigatorSeparator1, Me.bindingnavigatorMoveNextItem, Me.bindingnavigatorMoveLastItem, Me.bindingnavigatorSeparator2, Me.bindingnavigatorAddNewItem, Me.bindingnavigatorDeleteItem, Me.bindingnavigatorSaveItem})
        Me.bindingnavigatorMain.Location = New System.Drawing.Point(0, 0)
        Me.bindingnavigatorMain.MoveFirstItem = Me.bindingnavigatorMoveFirstItem
        Me.bindingnavigatorMain.MoveLastItem = Me.bindingnavigatorMoveLastItem
        Me.bindingnavigatorMain.MoveNextItem = Me.bindingnavigatorMoveNextItem
        Me.bindingnavigatorMain.MovePreviousItem = Me.bindingnavigatorMovePreviousItem
        Me.bindingnavigatorMain.Name = "bindingnavigatorMain"
        Me.bindingnavigatorMain.PositionItem = Me.bindingnavigatorPositionItem
        Me.bindingnavigatorMain.Size = New System.Drawing.Size(311, 25)
        Me.bindingnavigatorMain.TabIndex = 3
        '
        'bindingnavigatorAddNewItem
        '
        Me.bindingnavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingnavigatorAddNewItem.Image = CType(resources.GetObject("bindingnavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.bindingnavigatorAddNewItem.Name = "bindingnavigatorAddNewItem"
        Me.bindingnavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.bindingnavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingnavigatorAddNewItem.Text = "Add new"
        '
        'bindingnavigatorCountItem
        '
        Me.bindingnavigatorCountItem.Name = "bindingnavigatorCountItem"
        Me.bindingnavigatorCountItem.Size = New System.Drawing.Size(37, 22)
        Me.bindingnavigatorCountItem.Text = "de {0}"
        Me.bindingnavigatorCountItem.ToolTipText = "Total number of items"
        '
        'bindingnavigatorDeleteItem
        '
        Me.bindingnavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingnavigatorDeleteItem.Image = CType(resources.GetObject("bindingnavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.bindingnavigatorDeleteItem.Name = "bindingnavigatorDeleteItem"
        Me.bindingnavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.bindingnavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingnavigatorDeleteItem.Text = "Delete"
        '
        'bindingnavigatorMoveFirstItem
        '
        Me.bindingnavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingnavigatorMoveFirstItem.Image = CType(resources.GetObject("bindingnavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.bindingnavigatorMoveFirstItem.Name = "bindingnavigatorMoveFirstItem"
        Me.bindingnavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.bindingnavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingnavigatorMoveFirstItem.Text = "Move first"
        '
        'bindingnavigatorMovePreviousItem
        '
        Me.bindingnavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingnavigatorMovePreviousItem.Image = CType(resources.GetObject("bindingnavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.bindingnavigatorMovePreviousItem.Name = "bindingnavigatorMovePreviousItem"
        Me.bindingnavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.bindingnavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingnavigatorMovePreviousItem.Text = "Move previous"
        '
        'bindingnavigatorSeparator
        '
        Me.bindingnavigatorSeparator.Name = "bindingnavigatorSeparator"
        Me.bindingnavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'bindingnavigatorPositionItem
        '
        Me.bindingnavigatorPositionItem.AccessibleName = "Position"
        Me.bindingnavigatorPositionItem.AutoSize = False
        Me.bindingnavigatorPositionItem.Name = "bindingnavigatorPositionItem"
        Me.bindingnavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.bindingnavigatorPositionItem.Text = "0"
        Me.bindingnavigatorPositionItem.ToolTipText = "Current position"
        '
        'bindingnavigatorSeparator1
        '
        Me.bindingnavigatorSeparator1.Name = "bindingnavigatorSeparator1"
        Me.bindingnavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'bindingnavigatorMoveNextItem
        '
        Me.bindingnavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingnavigatorMoveNextItem.Image = CType(resources.GetObject("bindingnavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.bindingnavigatorMoveNextItem.Name = "bindingnavigatorMoveNextItem"
        Me.bindingnavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.bindingnavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingnavigatorMoveNextItem.Text = "Move next"
        '
        'bindingnavigatorMoveLastItem
        '
        Me.bindingnavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingnavigatorMoveLastItem.Image = CType(resources.GetObject("bindingnavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.bindingnavigatorMoveLastItem.Name = "bindingnavigatorMoveLastItem"
        Me.bindingnavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.bindingnavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingnavigatorMoveLastItem.Text = "Move last"
        '
        'bindingnavigatorSeparator2
        '
        Me.bindingnavigatorSeparator2.Name = "bindingnavigatorSeparator2"
        Me.bindingnavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'bindingnavigatorSaveItem
        '
        Me.bindingnavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.bindingnavigatorSaveItem.Image = CType(resources.GetObject("bindingnavigatorSaveItem.Image"), System.Drawing.Image)
        Me.bindingnavigatorSaveItem.Name = "bindingnavigatorSaveItem"
        Me.bindingnavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.bindingnavigatorSaveItem.Text = "Save Data"
        '
        'datagridviewMain
        '
        Me.datagridviewMain.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText
        Me.datagridviewMain.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.datagridviewMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.datagridviewMain.AutoGenerateColumns = False
        Me.datagridviewMain.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.datagridviewMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.datagridviewMain.DataSource = Me.bindingsourceMain
        Me.datagridviewMain.Location = New System.Drawing.Point(0, 28)
        Me.datagridviewMain.MultiSelect = False
        Me.datagridviewMain.Name = "datagridviewMain"
        Me.datagridviewMain.RowHeadersVisible = False
        Me.datagridviewMain.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.datagridviewMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.datagridviewMain.Size = New System.Drawing.Size(708, 364)
        Me.datagridviewMain.TabIndex = 2
        '
        'formCABGenerico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(708, 417)
        Me.Controls.Add(Me.flowlayoutpanelMain)
        Me.Controls.Add(Me.statusstripMain)
        Me.Controls.Add(Me.datagridviewMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formCABGenerico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        CType(Me.bindingsourceMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.statusstripMain.ResumeLayout(False)
        Me.statusstripMain.PerformLayout()
        Me.flowlayoutpanelMain.ResumeLayout(False)
        Me.flowlayoutpanelMain.PerformLayout()
        CType(Me.bindingnavigatorMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.bindingnavigatorMain.ResumeLayout(False)
        Me.bindingnavigatorMain.PerformLayout()
        CType(Me.datagridviewMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents bindingsourceMain As System.Windows.Forms.BindingSource
    Friend WithEvents statusstripMain As System.Windows.Forms.StatusStrip
    Friend WithEvents statuslabelMain As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents flowlayoutpanelMain As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents bindingnavigatorMain As System.Windows.Forms.BindingNavigator
    Friend WithEvents bindingnavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingnavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents bindingnavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingnavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingnavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingnavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bindingnavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents bindingnavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bindingnavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingnavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents bindingnavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents bindingnavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents datagridviewMain As System.Windows.Forms.DataGridView
End Class
