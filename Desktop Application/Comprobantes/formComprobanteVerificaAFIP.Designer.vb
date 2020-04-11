<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formComprobanteVerificaAFIP
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
        Me.listviewMain = New System.Windows.Forms.ListView()
        Me.columnPropiedad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnValorLocal = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.columnValorAFIP = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        'listviewMain
        '
        Me.listviewMain.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.columnPropiedad, Me.columnValorLocal, Me.columnValorAFIP})
        Me.listviewMain.FullRowSelect = True
        Me.listviewMain.GridLines = True
        Me.listviewMain.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
        Me.listviewMain.HideSelection = False
        Me.listviewMain.Location = New System.Drawing.Point(12, 12)
        Me.listviewMain.MultiSelect = False
        Me.listviewMain.Name = "listviewMain"
        Me.listviewMain.Size = New System.Drawing.Size(671, 438)
        Me.listviewMain.TabIndex = 0
        Me.listviewMain.UseCompatibleStateImageBehavior = False
        Me.listviewMain.View = System.Windows.Forms.View.Details
        '
        'columnPropiedad
        '
        Me.columnPropiedad.Text = "Propiedad"
        Me.columnPropiedad.Width = 250
        '
        'columnValorLocal
        '
        Me.columnValorLocal.Text = "Valor Sistema"
        Me.columnValorLocal.Width = 200
        '
        'columnValorAFIP
        '
        Me.columnValorAFIP.Text = "Valor AFIP"
        Me.columnValorAFIP.Width = 200
        '
        'formComprobanteVerificaAFIP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(695, 462)
        Me.Controls.Add(Me.listviewMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formComprobanteVerificaAFIP"
        Me.ShowInTaskbar = False
        Me.Text = "Verificación de Comprobante con AFIP"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents listviewMain As System.Windows.Forms.ListView
    Friend WithEvents columnPropiedad As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnValorLocal As System.Windows.Forms.ColumnHeader
    Friend WithEvents columnValorAFIP As System.Windows.Forms.ColumnHeader
End Class
