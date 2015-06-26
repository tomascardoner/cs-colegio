<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formReportViewerCR
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
        Me.CRViewerMain = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'CRViewerMain
        '
        Me.CRViewerMain.ActiveViewIndex = -1
        Me.CRViewerMain.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.CRViewerMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRViewerMain.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRViewerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRViewerMain.Location = New System.Drawing.Point(0, 0)
        Me.CRViewerMain.Name = "CRViewerMain"
        Me.CRViewerMain.Size = New System.Drawing.Size(821, 433)
        Me.CRViewerMain.TabIndex = 0
        Me.CRViewerMain.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'formReportViewerCR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(821, 433)
        Me.Controls.Add(Me.CRViewerMain)
        Me.Name = "formReportViewerCR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "formReportViewerCR"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRViewerMain As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
