<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormLiquidacionEntidad
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
        Me.LabelLiquidacion = New System.Windows.Forms.Label()
        Me.ToolStripButtonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonEditar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButtonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.LabelEntidad = New System.Windows.Forms.Label()
        Me.LabelModuloCantidad = New System.Windows.Forms.Label()
        Me.LabelAntiguedad = New System.Windows.Forms.Label()
        Me.ComboBoxEntidad = New System.Windows.Forms.ComboBox()
        Me.ButtonObtenerDatos = New System.Windows.Forms.Button()
        Me.TextBoxLiquidacion = New System.Windows.Forms.TextBox()
        Me.DoubleTextBoxModuloCantidad = New Syncfusion.Windows.Forms.Tools.DoubleTextBox()
        Me.IntegerTextBoxAntiguedad = New Syncfusion.Windows.Forms.Tools.IntegerTextBox()
        Me.LabelAntiguedadPorcentaje = New System.Windows.Forms.Label()
        Me.TableLayoutPanelRecibosSueldo = New System.Windows.Forms.TableLayoutPanel()
        Me.LabelReciboImporteBasico = New System.Windows.Forms.Label()
        Me.LabelReciboImporteNeto = New System.Windows.Forms.Label()
        Me.LabelRecibo1 = New System.Windows.Forms.Label()
        Me.CurrencyTextBoxRecibo1ImporteBasico = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.CurrencyTextBoxRecibo1ImporteNeto = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.LabelRecibo2 = New System.Windows.Forms.Label()
        Me.CurrencyTextBoxRecibo2ImporteBasico = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.CurrencyTextBoxRecibo2ImporteNeto = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.LabelRecibo3 = New System.Windows.Forms.Label()
        Me.CurrencyTextBoxRecibo3ImporteBasico = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.CurrencyTextBoxRecibo3ImporteNeto = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.LabelRecibo4 = New System.Windows.Forms.Label()
        Me.CurrencyTextBoxRecibo4ImporteBasico = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.CurrencyTextBoxRecibo4ImporteNeto = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.LabelRecibo5 = New System.Windows.Forms.Label()
        Me.CurrencyTextBoxRecibo5ImporteBasico = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.CurrencyTextBoxRecibo5ImporteNeto = New Syncfusion.Windows.Forms.Tools.CurrencyTextBox()
        Me.toolstripMain.SuspendLayout()
        CType(Me.DoubleTextBoxModuloCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.IntegerTextBoxAntiguedad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanelRecibosSueldo.SuspendLayout()
        CType(Me.CurrencyTextBoxRecibo1ImporteBasico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBoxRecibo1ImporteNeto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBoxRecibo2ImporteBasico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBoxRecibo2ImporteNeto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBoxRecibo3ImporteBasico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBoxRecibo3ImporteNeto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBoxRecibo4ImporteBasico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBoxRecibo4ImporteNeto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBoxRecibo5ImporteBasico, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrencyTextBoxRecibo5ImporteNeto, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelLiquidacion
        '
        Me.LabelLiquidacion.AutoSize = True
        Me.LabelLiquidacion.Location = New System.Drawing.Point(13, 74)
        Me.LabelLiquidacion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelLiquidacion.Name = "LabelLiquidacion"
        Me.LabelLiquidacion.Size = New System.Drawing.Size(79, 16)
        Me.LabelLiquidacion.TabIndex = 8
        Me.LabelLiquidacion.Text = "Liquidación:"
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
        'ToolStripButtonCancelar
        '
        Me.ToolStripButtonCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonCancelar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.ImageCancelar32
        Me.ToolStripButtonCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCancelar.Name = "ToolStripButtonCancelar"
        Me.ToolStripButtonCancelar.Size = New System.Drawing.Size(102, 36)
        Me.ToolStripButtonCancelar.Text = "Cancelar"
        '
        'ToolStripButtonEditar
        '
        Me.ToolStripButtonEditar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonEditar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_EDIT_32
        Me.ToolStripButtonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonEditar.Name = "ToolStripButtonEditar"
        Me.ToolStripButtonEditar.Size = New System.Drawing.Size(84, 36)
        Me.ToolStripButtonEditar.Text = "Editar"
        '
        'ToolStripButtonCerrar
        '
        Me.ToolStripButtonCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripButtonCerrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_32
        Me.ToolStripButtonCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripButtonCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButtonCerrar.Name = "ToolStripButtonCerrar"
        Me.ToolStripButtonCerrar.Size = New System.Drawing.Size(85, 36)
        Me.ToolStripButtonCerrar.Text = "Cerrar"
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButtonCerrar, Me.ToolStripButtonEditar, Me.ToolStripButtonCancelar, Me.ToolStripButtonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(390, 39)
        Me.toolstripMain.TabIndex = 7
        '
        'LabelEntidad
        '
        Me.LabelEntidad.AutoSize = True
        Me.LabelEntidad.Location = New System.Drawing.Point(13, 106)
        Me.LabelEntidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelEntidad.Name = "LabelEntidad"
        Me.LabelEntidad.Size = New System.Drawing.Size(56, 16)
        Me.LabelEntidad.TabIndex = 0
        Me.LabelEntidad.Text = "Entidad:"
        '
        'LabelModuloCantidad
        '
        Me.LabelModuloCantidad.AutoSize = True
        Me.LabelModuloCantidad.Location = New System.Drawing.Point(13, 138)
        Me.LabelModuloCantidad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelModuloCantidad.Name = "LabelModuloCantidad"
        Me.LabelModuloCantidad.Size = New System.Drawing.Size(62, 16)
        Me.LabelModuloCantidad.TabIndex = 2
        Me.LabelModuloCantidad.Text = "Módulos:"
        '
        'LabelAntiguedad
        '
        Me.LabelAntiguedad.AutoSize = True
        Me.LabelAntiguedad.Location = New System.Drawing.Point(13, 166)
        Me.LabelAntiguedad.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelAntiguedad.Name = "LabelAntiguedad"
        Me.LabelAntiguedad.Size = New System.Drawing.Size(76, 16)
        Me.LabelAntiguedad.TabIndex = 4
        Me.LabelAntiguedad.Text = "Antigüedad"
        '
        'ComboBoxEntidad
        '
        Me.ComboBoxEntidad.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ComboBoxEntidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxEntidad.FormattingEnabled = True
        Me.ComboBoxEntidad.Location = New System.Drawing.Point(100, 103)
        Me.ComboBoxEntidad.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxEntidad.Name = "ComboBoxEntidad"
        Me.ComboBoxEntidad.Size = New System.Drawing.Size(277, 24)
        Me.ComboBoxEntidad.TabIndex = 1
        '
        'ButtonObtenerDatos
        '
        Me.ButtonObtenerDatos.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonObtenerDatos.Location = New System.Drawing.Point(170, 135)
        Me.ButtonObtenerDatos.Name = "ButtonObtenerDatos"
        Me.ButtonObtenerDatos.Size = New System.Drawing.Size(207, 54)
        Me.ButtonObtenerDatos.TabIndex = 6
        Me.ButtonObtenerDatos.Text = "Obtener todos los datos desde la liquidación anterior"
        Me.ButtonObtenerDatos.UseVisualStyleBackColor = True
        '
        'TextBoxLiquidacion
        '
        Me.TextBoxLiquidacion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxLiquidacion.Location = New System.Drawing.Point(100, 71)
        Me.TextBoxLiquidacion.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBoxLiquidacion.Name = "TextBoxLiquidacion"
        Me.TextBoxLiquidacion.ReadOnly = True
        Me.TextBoxLiquidacion.Size = New System.Drawing.Size(277, 22)
        Me.TextBoxLiquidacion.TabIndex = 9
        Me.TextBoxLiquidacion.TabStop = False
        Me.TextBoxLiquidacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'DoubleTextBoxModuloCantidad
        '
        Me.DoubleTextBoxModuloCantidad.AccessibilityEnabled = True
        Me.DoubleTextBoxModuloCantidad.AllowNull = True
        Me.DoubleTextBoxModuloCantidad.BeforeTouchSize = New System.Drawing.Size(119, 22)
        Me.DoubleTextBoxModuloCantidad.DoubleValue = 0R
        Me.DoubleTextBoxModuloCantidad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.DoubleTextBoxModuloCantidad.Location = New System.Drawing.Point(100, 135)
        Me.DoubleTextBoxModuloCantidad.MaxValue = 99.9R
        Me.DoubleTextBoxModuloCantidad.MinValue = 0R
        Me.DoubleTextBoxModuloCantidad.Name = "DoubleTextBoxModuloCantidad"
        Me.DoubleTextBoxModuloCantidad.NumberDecimalDigits = 1
        Me.DoubleTextBoxModuloCantidad.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.DoubleTextBoxModuloCantidad.Size = New System.Drawing.Size(40, 22)
        Me.DoubleTextBoxModuloCantidad.TabIndex = 3
        Me.DoubleTextBoxModuloCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'IntegerTextBoxAntiguedad
        '
        Me.IntegerTextBoxAntiguedad.AccessibilityEnabled = True
        Me.IntegerTextBoxAntiguedad.AllowNull = True
        Me.IntegerTextBoxAntiguedad.BeforeTouchSize = New System.Drawing.Size(119, 22)
        Me.IntegerTextBoxAntiguedad.ForeColor = System.Drawing.SystemColors.WindowText
        Me.IntegerTextBoxAntiguedad.IntegerValue = CType(0, Long)
        Me.IntegerTextBoxAntiguedad.Location = New System.Drawing.Point(100, 163)
        Me.IntegerTextBoxAntiguedad.MaxValue = CType(125, Long)
        Me.IntegerTextBoxAntiguedad.MinValue = CType(1, Long)
        Me.IntegerTextBoxAntiguedad.Name = "IntegerTextBoxAntiguedad"
        Me.IntegerTextBoxAntiguedad.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.IntegerTextBoxAntiguedad.Size = New System.Drawing.Size(40, 22)
        Me.IntegerTextBoxAntiguedad.TabIndex = 5
        Me.IntegerTextBoxAntiguedad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelAntiguedadPorcentaje
        '
        Me.LabelAntiguedadPorcentaje.AutoSize = True
        Me.LabelAntiguedadPorcentaje.Location = New System.Drawing.Point(144, 166)
        Me.LabelAntiguedadPorcentaje.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelAntiguedadPorcentaje.Name = "LabelAntiguedadPorcentaje"
        Me.LabelAntiguedadPorcentaje.Size = New System.Drawing.Size(19, 16)
        Me.LabelAntiguedadPorcentaje.TabIndex = 10
        Me.LabelAntiguedadPorcentaje.Text = "%"
        '
        'TableLayoutPanelRecibosSueldo
        '
        Me.TableLayoutPanelRecibosSueldo.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanelRecibosSueldo.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble
        Me.TableLayoutPanelRecibosSueldo.ColumnCount = 3
        Me.TableLayoutPanelRecibosSueldo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanelRecibosSueldo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelRecibosSueldo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.LabelReciboImporteBasico, 1, 0)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.LabelReciboImporteNeto, 2, 0)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.LabelRecibo1, 0, 1)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.CurrencyTextBoxRecibo1ImporteBasico, 1, 1)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.CurrencyTextBoxRecibo1ImporteNeto, 2, 1)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.LabelRecibo2, 0, 2)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.CurrencyTextBoxRecibo2ImporteBasico, 1, 2)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.CurrencyTextBoxRecibo2ImporteNeto, 2, 2)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.LabelRecibo3, 0, 3)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.CurrencyTextBoxRecibo3ImporteBasico, 1, 3)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.CurrencyTextBoxRecibo3ImporteNeto, 2, 3)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.LabelRecibo4, 0, 4)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.CurrencyTextBoxRecibo4ImporteBasico, 1, 4)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.CurrencyTextBoxRecibo4ImporteNeto, 2, 4)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.LabelRecibo5, 0, 5)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.CurrencyTextBoxRecibo5ImporteBasico, 1, 5)
        Me.TableLayoutPanelRecibosSueldo.Controls.Add(Me.CurrencyTextBoxRecibo5ImporteNeto, 2, 5)
        Me.TableLayoutPanelRecibosSueldo.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize
        Me.TableLayoutPanelRecibosSueldo.Location = New System.Drawing.Point(12, 208)
        Me.TableLayoutPanelRecibosSueldo.Name = "TableLayoutPanelRecibosSueldo"
        Me.TableLayoutPanelRecibosSueldo.RowCount = 7
        Me.TableLayoutPanelRecibosSueldo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanelRecibosSueldo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelRecibosSueldo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelRecibosSueldo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelRecibosSueldo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelRecibosSueldo.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanelRecibosSueldo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanelRecibosSueldo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanelRecibosSueldo.Size = New System.Drawing.Size(366, 268)
        Me.TableLayoutPanelRecibosSueldo.TabIndex = 13
        '
        'LabelReciboImporteBasico
        '
        Me.LabelReciboImporteBasico.AutoSize = True
        Me.LabelReciboImporteBasico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelReciboImporteBasico.Location = New System.Drawing.Point(96, 3)
        Me.LabelReciboImporteBasico.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelReciboImporteBasico.Name = "LabelReciboImporteBasico"
        Me.LabelReciboImporteBasico.Size = New System.Drawing.Size(126, 30)
        Me.LabelReciboImporteBasico.TabIndex = 19
        Me.LabelReciboImporteBasico.Text = "Importe básico"
        Me.LabelReciboImporteBasico.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelReciboImporteNeto
        '
        Me.LabelReciboImporteNeto.AutoSize = True
        Me.LabelReciboImporteNeto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelReciboImporteNeto.Location = New System.Drawing.Point(233, 3)
        Me.LabelReciboImporteNeto.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelReciboImporteNeto.Name = "LabelReciboImporteNeto"
        Me.LabelReciboImporteNeto.Size = New System.Drawing.Size(126, 30)
        Me.LabelReciboImporteNeto.TabIndex = 18
        Me.LabelReciboImporteNeto.Text = "Importe neto"
        Me.LabelReciboImporteNeto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LabelRecibo1
        '
        Me.LabelRecibo1.AutoSize = True
        Me.LabelRecibo1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelRecibo1.Location = New System.Drawing.Point(7, 36)
        Me.LabelRecibo1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelRecibo1.Name = "LabelRecibo1"
        Me.LabelRecibo1.Size = New System.Drawing.Size(78, 30)
        Me.LabelRecibo1.TabIndex = 15
        Me.LabelRecibo1.Text = "Recibo n° 1:"
        Me.LabelRecibo1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CurrencyTextBoxRecibo1ImporteBasico
        '
        Me.CurrencyTextBoxRecibo1ImporteBasico.AccessibilityEnabled = True
        Me.CurrencyTextBoxRecibo1ImporteBasico.AllowNull = True
        Me.CurrencyTextBoxRecibo1ImporteBasico.BeforeTouchSize = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo1ImporteBasico.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.CurrencyTextBoxRecibo1ImporteBasico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyTextBoxRecibo1ImporteBasico.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CurrencyTextBoxRecibo1ImporteBasico.Location = New System.Drawing.Point(96, 40)
        Me.CurrencyTextBoxRecibo1ImporteBasico.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrencyTextBoxRecibo1ImporteBasico.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.CurrencyTextBoxRecibo1ImporteBasico.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.CurrencyTextBoxRecibo1ImporteBasico.Name = "CurrencyTextBoxRecibo1ImporteBasico"
        Me.CurrencyTextBoxRecibo1ImporteBasico.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.CurrencyTextBoxRecibo1ImporteBasico.Size = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo1ImporteBasico.TabIndex = 16
        Me.CurrencyTextBoxRecibo1ImporteBasico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CurrencyTextBoxRecibo1ImporteNeto
        '
        Me.CurrencyTextBoxRecibo1ImporteNeto.AccessibilityEnabled = True
        Me.CurrencyTextBoxRecibo1ImporteNeto.AllowNull = True
        Me.CurrencyTextBoxRecibo1ImporteNeto.BeforeTouchSize = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo1ImporteNeto.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.CurrencyTextBoxRecibo1ImporteNeto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyTextBoxRecibo1ImporteNeto.Location = New System.Drawing.Point(233, 40)
        Me.CurrencyTextBoxRecibo1ImporteNeto.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrencyTextBoxRecibo1ImporteNeto.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.CurrencyTextBoxRecibo1ImporteNeto.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.CurrencyTextBoxRecibo1ImporteNeto.Name = "CurrencyTextBoxRecibo1ImporteNeto"
        Me.CurrencyTextBoxRecibo1ImporteNeto.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.CurrencyTextBoxRecibo1ImporteNeto.Size = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo1ImporteNeto.TabIndex = 17
        Me.CurrencyTextBoxRecibo1ImporteNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelRecibo2
        '
        Me.LabelRecibo2.AutoSize = True
        Me.LabelRecibo2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelRecibo2.Location = New System.Drawing.Point(7, 69)
        Me.LabelRecibo2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelRecibo2.Name = "LabelRecibo2"
        Me.LabelRecibo2.Size = New System.Drawing.Size(78, 30)
        Me.LabelRecibo2.TabIndex = 20
        Me.LabelRecibo2.Text = "Recibo n° 2:"
        Me.LabelRecibo2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CurrencyTextBoxRecibo2ImporteBasico
        '
        Me.CurrencyTextBoxRecibo2ImporteBasico.AccessibilityEnabled = True
        Me.CurrencyTextBoxRecibo2ImporteBasico.AllowNull = True
        Me.CurrencyTextBoxRecibo2ImporteBasico.BeforeTouchSize = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo2ImporteBasico.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.CurrencyTextBoxRecibo2ImporteBasico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyTextBoxRecibo2ImporteBasico.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CurrencyTextBoxRecibo2ImporteBasico.Location = New System.Drawing.Point(96, 73)
        Me.CurrencyTextBoxRecibo2ImporteBasico.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrencyTextBoxRecibo2ImporteBasico.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.CurrencyTextBoxRecibo2ImporteBasico.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.CurrencyTextBoxRecibo2ImporteBasico.Name = "CurrencyTextBoxRecibo2ImporteBasico"
        Me.CurrencyTextBoxRecibo2ImporteBasico.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.CurrencyTextBoxRecibo2ImporteBasico.Size = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo2ImporteBasico.TabIndex = 22
        Me.CurrencyTextBoxRecibo2ImporteBasico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CurrencyTextBoxRecibo2ImporteNeto
        '
        Me.CurrencyTextBoxRecibo2ImporteNeto.AccessibilityEnabled = True
        Me.CurrencyTextBoxRecibo2ImporteNeto.AllowNull = True
        Me.CurrencyTextBoxRecibo2ImporteNeto.BeforeTouchSize = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo2ImporteNeto.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.CurrencyTextBoxRecibo2ImporteNeto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyTextBoxRecibo2ImporteNeto.Location = New System.Drawing.Point(233, 73)
        Me.CurrencyTextBoxRecibo2ImporteNeto.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrencyTextBoxRecibo2ImporteNeto.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.CurrencyTextBoxRecibo2ImporteNeto.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.CurrencyTextBoxRecibo2ImporteNeto.Name = "CurrencyTextBoxRecibo2ImporteNeto"
        Me.CurrencyTextBoxRecibo2ImporteNeto.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.CurrencyTextBoxRecibo2ImporteNeto.Size = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo2ImporteNeto.TabIndex = 21
        Me.CurrencyTextBoxRecibo2ImporteNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelRecibo3
        '
        Me.LabelRecibo3.AutoSize = True
        Me.LabelRecibo3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelRecibo3.Location = New System.Drawing.Point(7, 102)
        Me.LabelRecibo3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelRecibo3.Name = "LabelRecibo3"
        Me.LabelRecibo3.Size = New System.Drawing.Size(78, 30)
        Me.LabelRecibo3.TabIndex = 32
        Me.LabelRecibo3.Text = "Recibo n° 3:"
        Me.LabelRecibo3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CurrencyTextBoxRecibo3ImporteBasico
        '
        Me.CurrencyTextBoxRecibo3ImporteBasico.AccessibilityEnabled = True
        Me.CurrencyTextBoxRecibo3ImporteBasico.AllowNull = True
        Me.CurrencyTextBoxRecibo3ImporteBasico.BeforeTouchSize = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo3ImporteBasico.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.CurrencyTextBoxRecibo3ImporteBasico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyTextBoxRecibo3ImporteBasico.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CurrencyTextBoxRecibo3ImporteBasico.Location = New System.Drawing.Point(96, 106)
        Me.CurrencyTextBoxRecibo3ImporteBasico.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrencyTextBoxRecibo3ImporteBasico.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.CurrencyTextBoxRecibo3ImporteBasico.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.CurrencyTextBoxRecibo3ImporteBasico.Name = "CurrencyTextBoxRecibo3ImporteBasico"
        Me.CurrencyTextBoxRecibo3ImporteBasico.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.CurrencyTextBoxRecibo3ImporteBasico.Size = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo3ImporteBasico.TabIndex = 34
        Me.CurrencyTextBoxRecibo3ImporteBasico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CurrencyTextBoxRecibo3ImporteNeto
        '
        Me.CurrencyTextBoxRecibo3ImporteNeto.AccessibilityEnabled = True
        Me.CurrencyTextBoxRecibo3ImporteNeto.AllowNull = True
        Me.CurrencyTextBoxRecibo3ImporteNeto.BeforeTouchSize = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo3ImporteNeto.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.CurrencyTextBoxRecibo3ImporteNeto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyTextBoxRecibo3ImporteNeto.Location = New System.Drawing.Point(233, 106)
        Me.CurrencyTextBoxRecibo3ImporteNeto.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrencyTextBoxRecibo3ImporteNeto.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.CurrencyTextBoxRecibo3ImporteNeto.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.CurrencyTextBoxRecibo3ImporteNeto.Name = "CurrencyTextBoxRecibo3ImporteNeto"
        Me.CurrencyTextBoxRecibo3ImporteNeto.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.CurrencyTextBoxRecibo3ImporteNeto.Size = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo3ImporteNeto.TabIndex = 33
        Me.CurrencyTextBoxRecibo3ImporteNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelRecibo4
        '
        Me.LabelRecibo4.AutoSize = True
        Me.LabelRecibo4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelRecibo4.Location = New System.Drawing.Point(7, 135)
        Me.LabelRecibo4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelRecibo4.Name = "LabelRecibo4"
        Me.LabelRecibo4.Size = New System.Drawing.Size(78, 30)
        Me.LabelRecibo4.TabIndex = 29
        Me.LabelRecibo4.Text = "Recibo n° 4:"
        Me.LabelRecibo4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CurrencyTextBoxRecibo4ImporteBasico
        '
        Me.CurrencyTextBoxRecibo4ImporteBasico.AccessibilityEnabled = True
        Me.CurrencyTextBoxRecibo4ImporteBasico.AllowNull = True
        Me.CurrencyTextBoxRecibo4ImporteBasico.BeforeTouchSize = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo4ImporteBasico.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.CurrencyTextBoxRecibo4ImporteBasico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyTextBoxRecibo4ImporteBasico.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CurrencyTextBoxRecibo4ImporteBasico.Location = New System.Drawing.Point(96, 139)
        Me.CurrencyTextBoxRecibo4ImporteBasico.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrencyTextBoxRecibo4ImporteBasico.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.CurrencyTextBoxRecibo4ImporteBasico.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.CurrencyTextBoxRecibo4ImporteBasico.Name = "CurrencyTextBoxRecibo4ImporteBasico"
        Me.CurrencyTextBoxRecibo4ImporteBasico.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.CurrencyTextBoxRecibo4ImporteBasico.Size = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo4ImporteBasico.TabIndex = 31
        Me.CurrencyTextBoxRecibo4ImporteBasico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CurrencyTextBoxRecibo4ImporteNeto
        '
        Me.CurrencyTextBoxRecibo4ImporteNeto.AccessibilityEnabled = True
        Me.CurrencyTextBoxRecibo4ImporteNeto.AllowNull = True
        Me.CurrencyTextBoxRecibo4ImporteNeto.BeforeTouchSize = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo4ImporteNeto.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.CurrencyTextBoxRecibo4ImporteNeto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyTextBoxRecibo4ImporteNeto.Location = New System.Drawing.Point(233, 139)
        Me.CurrencyTextBoxRecibo4ImporteNeto.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrencyTextBoxRecibo4ImporteNeto.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.CurrencyTextBoxRecibo4ImporteNeto.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.CurrencyTextBoxRecibo4ImporteNeto.Name = "CurrencyTextBoxRecibo4ImporteNeto"
        Me.CurrencyTextBoxRecibo4ImporteNeto.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.CurrencyTextBoxRecibo4ImporteNeto.Size = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo4ImporteNeto.TabIndex = 30
        Me.CurrencyTextBoxRecibo4ImporteNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'LabelRecibo5
        '
        Me.LabelRecibo5.AutoSize = True
        Me.LabelRecibo5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabelRecibo5.Location = New System.Drawing.Point(7, 168)
        Me.LabelRecibo5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.LabelRecibo5.Name = "LabelRecibo5"
        Me.LabelRecibo5.Size = New System.Drawing.Size(78, 30)
        Me.LabelRecibo5.TabIndex = 26
        Me.LabelRecibo5.Text = "Recibo n° 5:"
        Me.LabelRecibo5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CurrencyTextBoxRecibo5ImporteBasico
        '
        Me.CurrencyTextBoxRecibo5ImporteBasico.AccessibilityEnabled = True
        Me.CurrencyTextBoxRecibo5ImporteBasico.AllowNull = True
        Me.CurrencyTextBoxRecibo5ImporteBasico.BeforeTouchSize = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo5ImporteBasico.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.CurrencyTextBoxRecibo5ImporteBasico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyTextBoxRecibo5ImporteBasico.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CurrencyTextBoxRecibo5ImporteBasico.Location = New System.Drawing.Point(96, 172)
        Me.CurrencyTextBoxRecibo5ImporteBasico.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrencyTextBoxRecibo5ImporteBasico.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.CurrencyTextBoxRecibo5ImporteBasico.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.CurrencyTextBoxRecibo5ImporteBasico.Name = "CurrencyTextBoxRecibo5ImporteBasico"
        Me.CurrencyTextBoxRecibo5ImporteBasico.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.CurrencyTextBoxRecibo5ImporteBasico.Size = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo5ImporteBasico.TabIndex = 28
        Me.CurrencyTextBoxRecibo5ImporteBasico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CurrencyTextBoxRecibo5ImporteNeto
        '
        Me.CurrencyTextBoxRecibo5ImporteNeto.AccessibilityEnabled = True
        Me.CurrencyTextBoxRecibo5ImporteNeto.AllowNull = True
        Me.CurrencyTextBoxRecibo5ImporteNeto.BeforeTouchSize = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo5ImporteNeto.DecimalValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.CurrencyTextBoxRecibo5ImporteNeto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CurrencyTextBoxRecibo5ImporteNeto.Location = New System.Drawing.Point(233, 172)
        Me.CurrencyTextBoxRecibo5ImporteNeto.Margin = New System.Windows.Forms.Padding(4)
        Me.CurrencyTextBoxRecibo5ImporteNeto.MaxValue = New Decimal(New Integer() {276447231, 23283, 0, 131072})
        Me.CurrencyTextBoxRecibo5ImporteNeto.MinValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.CurrencyTextBoxRecibo5ImporteNeto.Name = "CurrencyTextBoxRecibo5ImporteNeto"
        Me.CurrencyTextBoxRecibo5ImporteNeto.OnValidationFailed = Syncfusion.Windows.Forms.Tools.OnValidationFailed.SetNullString
        Me.CurrencyTextBoxRecibo5ImporteNeto.Size = New System.Drawing.Size(126, 22)
        Me.CurrencyTextBoxRecibo5ImporteNeto.TabIndex = 27
        Me.CurrencyTextBoxRecibo5ImporteNeto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'FormLiquidacionEntidad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(390, 488)
        Me.Controls.Add(Me.TableLayoutPanelRecibosSueldo)
        Me.Controls.Add(Me.LabelAntiguedadPorcentaje)
        Me.Controls.Add(Me.IntegerTextBoxAntiguedad)
        Me.Controls.Add(Me.DoubleTextBoxModuloCantidad)
        Me.Controls.Add(Me.TextBoxLiquidacion)
        Me.Controls.Add(Me.ButtonObtenerDatos)
        Me.Controls.Add(Me.ComboBoxEntidad)
        Me.Controls.Add(Me.LabelAntiguedad)
        Me.Controls.Add(Me.LabelModuloCantidad)
        Me.Controls.Add(Me.LabelEntidad)
        Me.Controls.Add(Me.LabelLiquidacion)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormLiquidacionEntidad"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Liquidación de sueldo de entidad"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        CType(Me.DoubleTextBoxModuloCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.IntegerTextBoxAntiguedad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanelRecibosSueldo.ResumeLayout(False)
        Me.TableLayoutPanelRecibosSueldo.PerformLayout()
        CType(Me.CurrencyTextBoxRecibo1ImporteBasico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBoxRecibo1ImporteNeto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBoxRecibo2ImporteBasico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBoxRecibo2ImporteNeto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBoxRecibo3ImporteBasico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBoxRecibo3ImporteNeto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBoxRecibo4ImporteBasico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBoxRecibo4ImporteNeto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBoxRecibo5ImporteBasico, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrencyTextBoxRecibo5ImporteNeto, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelLiquidacion As System.Windows.Forms.Label
    Friend WithEvents ToolStripButtonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButtonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents LabelEntidad As System.Windows.Forms.Label
    Friend WithEvents LabelModuloCantidad As System.Windows.Forms.Label
    Friend WithEvents LabelAntiguedad As System.Windows.Forms.Label
    Friend WithEvents ComboBoxEntidad As System.Windows.Forms.ComboBox
    Friend WithEvents ButtonObtenerDatos As Button
    Friend WithEvents TextBoxLiquidacion As TextBox
    Friend WithEvents DoubleTextBoxModuloCantidad As Syncfusion.Windows.Forms.Tools.DoubleTextBox
    Friend WithEvents IntegerTextBoxAntiguedad As Syncfusion.Windows.Forms.Tools.IntegerTextBox
    Friend WithEvents LabelAntiguedadPorcentaje As Label
    Friend WithEvents TableLayoutPanelRecibosSueldo As TableLayoutPanel
    Friend WithEvents CurrencyTextBoxRecibo1ImporteNeto As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents CurrencyTextBoxRecibo1ImporteBasico As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents LabelRecibo1 As Label
    Friend WithEvents LabelReciboImporteBasico As Label
    Friend WithEvents LabelReciboImporteNeto As Label
    Friend WithEvents CurrencyTextBoxRecibo2ImporteBasico As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents CurrencyTextBoxRecibo2ImporteNeto As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents LabelRecibo2 As Label
    Friend WithEvents LabelRecibo3 As Label
    Friend WithEvents CurrencyTextBoxRecibo3ImporteBasico As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents CurrencyTextBoxRecibo3ImporteNeto As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents LabelRecibo4 As Label
    Friend WithEvents CurrencyTextBoxRecibo4ImporteBasico As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents CurrencyTextBoxRecibo4ImporteNeto As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents LabelRecibo5 As Label
    Friend WithEvents CurrencyTextBoxRecibo5ImporteBasico As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
    Friend WithEvents CurrencyTextBoxRecibo5ImporteNeto As Syncfusion.Windows.Forms.Tools.CurrencyTextBox
End Class
