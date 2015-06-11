<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formReportViewer
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
        Me.reportviewerMain = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'reportviewerMain
        '
        Me.reportviewerMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.reportviewerMain.Location = New System.Drawing.Point(0, 0)
        Me.reportviewerMain.Name = "reportviewerMain"
        Me.reportviewerMain.Size = New System.Drawing.Size(1068, 561)
        Me.reportviewerMain.TabIndex = 0
        Me.reportviewerMain.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage
        '
        'formReportViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1068, 561)
        Me.Controls.Add(Me.reportviewerMain)
        Me.Name = "formReportViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reporte"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents reportviewerMain As Microsoft.Reporting.WinForms.ReportViewer
End Class
