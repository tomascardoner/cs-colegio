<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formTest
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
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.flowpanelMediosPago_Subtotal = New System.Windows.Forms.FlowLayoutPanel()
        Me.panelMediosPago_Subtotal = New System.Windows.Forms.Panel()
        Me.textboxMediosPago_Subtotal = New System.Windows.Forms.TextBox()
        Me.labelMediosPago_Subtotal = New System.Windows.Forms.Label()
        Me.flowpanelMediosPago_Subtotal.SuspendLayout()
        Me.panelMediosPago_Subtotal.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'flowpanelMediosPago_Subtotal
        '
        Me.flowpanelMediosPago_Subtotal.AutoSize = True
        Me.flowpanelMediosPago_Subtotal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.flowpanelMediosPago_Subtotal.Controls.Add(Me.panelMediosPago_Subtotal)
        Me.flowpanelMediosPago_Subtotal.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.flowpanelMediosPago_Subtotal.Location = New System.Drawing.Point(191, 113)
        Me.flowpanelMediosPago_Subtotal.Name = "flowpanelMediosPago_Subtotal"
        Me.flowpanelMediosPago_Subtotal.Size = New System.Drawing.Size(149, 34)
        Me.flowpanelMediosPago_Subtotal.TabIndex = 3
        '
        'panelMediosPago_Subtotal
        '
        Me.panelMediosPago_Subtotal.AutoSize = True
        Me.panelMediosPago_Subtotal.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.panelMediosPago_Subtotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.panelMediosPago_Subtotal.Controls.Add(Me.textboxMediosPago_Subtotal)
        Me.panelMediosPago_Subtotal.Controls.Add(Me.labelMediosPago_Subtotal)
        Me.panelMediosPago_Subtotal.Location = New System.Drawing.Point(3, 3)
        Me.panelMediosPago_Subtotal.Name = "panelMediosPago_Subtotal"
        Me.panelMediosPago_Subtotal.Size = New System.Drawing.Size(143, 28)
        Me.panelMediosPago_Subtotal.TabIndex = 3
        '
        'textboxMediosPago_Subtotal
        '
        Me.textboxMediosPago_Subtotal.Location = New System.Drawing.Point(58, 3)
        Me.textboxMediosPago_Subtotal.Name = "textboxMediosPago_Subtotal"
        Me.textboxMediosPago_Subtotal.Size = New System.Drawing.Size(80, 20)
        Me.textboxMediosPago_Subtotal.TabIndex = 1
        Me.textboxMediosPago_Subtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'labelMediosPago_Subtotal
        '
        Me.labelMediosPago_Subtotal.AutoSize = True
        Me.labelMediosPago_Subtotal.Location = New System.Drawing.Point(3, 6)
        Me.labelMediosPago_Subtotal.Name = "labelMediosPago_Subtotal"
        Me.labelMediosPago_Subtotal.Size = New System.Drawing.Size(49, 13)
        Me.labelMediosPago_Subtotal.TabIndex = 0
        Me.labelMediosPago_Subtotal.Text = "Subtotal:"
        '
        'formTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(853, 467)
        Me.Controls.Add(Me.flowpanelMediosPago_Subtotal)
        Me.Name = "formTest"
        Me.Text = "formTest"
        Me.flowpanelMediosPago_Subtotal.ResumeLayout(False)
        Me.flowpanelMediosPago_Subtotal.PerformLayout()
        Me.panelMediosPago_Subtotal.ResumeLayout(False)
        Me.panelMediosPago_Subtotal.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents flowpanelMediosPago_Subtotal As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents panelMediosPago_Subtotal As System.Windows.Forms.Panel
    Friend WithEvents textboxMediosPago_Subtotal As System.Windows.Forms.TextBox
    Friend WithEvents labelMediosPago_Subtotal As System.Windows.Forms.Label
End Class
