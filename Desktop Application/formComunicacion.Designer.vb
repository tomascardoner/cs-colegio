<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formComunicacion
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
        Me.labelNombre = New System.Windows.Forms.Label()
        Me.labelAsunto = New System.Windows.Forms.Label()
        Me.buttonGuardar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCancelar = New System.Windows.Forms.ToolStripButton()
        Me.buttonEditar = New System.Windows.Forms.ToolStripButton()
        Me.buttonCerrar = New System.Windows.Forms.ToolStripButton()
        Me.toolstripMain = New System.Windows.Forms.ToolStrip()
        Me.textboxIDComunicacion = New System.Windows.Forms.TextBox()
        Me.labelIDComunicacion = New System.Windows.Forms.Label()
        Me.textboxNombre = New System.Windows.Forms.TextBox()
        Me.textboxAsunto = New System.Windows.Forms.TextBox()
        Me.labelCuerpoMensajeEsHTML = New System.Windows.Forms.Label()
        Me.checkboxCuerpoMensajeEsHTML = New System.Windows.Forms.CheckBox()
        Me.labelCuerpoMensaje = New System.Windows.Forms.Label()
        Me.textboxCuerpoMensaje = New System.Windows.Forms.TextBox()
        Me.labelUtilizarCampos = New System.Windows.Forms.Label()
        Me.checkboxUtilizarCampos = New System.Windows.Forms.CheckBox()
        Me.labelCantidadDestinatariosPorEmail = New System.Windows.Forms.Label()
        Me.comboboxCantidadDestinatariosPorEmail = New System.Windows.Forms.ComboBox()
        Me.checkboxDestinatariosEnCampoBCC = New System.Windows.Forms.CheckBox()
        Me.labelDestinatariosEnCampoBCC = New System.Windows.Forms.Label()
        Me.labelArchivoAdjunto = New System.Windows.Forms.Label()
        Me.panelEntidadPadre = New System.Windows.Forms.Panel()
        Me.buttonArchivoAdjuntoBorrar = New System.Windows.Forms.Button()
        Me.buttonArchivoAdjunto = New System.Windows.Forms.Button()
        Me.textboxArchivoAdjunto = New System.Windows.Forms.TextBox()
        Me.checkboxEsActivo = New System.Windows.Forms.CheckBox()
        Me.labelEsActivo = New System.Windows.Forms.Label()
        Me.toolstripMain.SuspendLayout()
        Me.panelEntidadPadre.SuspendLayout()
        Me.SuspendLayout()
        '
        'labelNombre
        '
        Me.labelNombre.AutoSize = True
        Me.labelNombre.Location = New System.Drawing.Point(12, 79)
        Me.labelNombre.Name = "labelNombre"
        Me.labelNombre.Size = New System.Drawing.Size(47, 13)
        Me.labelNombre.TabIndex = 2
        Me.labelNombre.Text = "Nombre:"
        '
        'labelAsunto
        '
        Me.labelAsunto.AutoSize = True
        Me.labelAsunto.Location = New System.Drawing.Point(12, 106)
        Me.labelAsunto.Name = "labelAsunto"
        Me.labelAsunto.Size = New System.Drawing.Size(43, 13)
        Me.labelAsunto.TabIndex = 4
        Me.labelAsunto.Text = "Asunto:"
        '
        'buttonGuardar
        '
        Me.buttonGuardar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonGuardar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_OK_32
        Me.buttonGuardar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonGuardar.Name = "buttonGuardar"
        Me.buttonGuardar.Size = New System.Drawing.Size(85, 36)
        Me.buttonGuardar.Text = "Guardar"
        '
        'buttonCancelar
        '
        Me.buttonCancelar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonCancelar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CANCEL_32
        Me.buttonCancelar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCancelar.Name = "buttonCancelar"
        Me.buttonCancelar.Size = New System.Drawing.Size(89, 36)
        Me.buttonCancelar.Text = "Cancelar"
        '
        'buttonEditar
        '
        Me.buttonEditar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonEditar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_ITEM_EDIT_32
        Me.buttonEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonEditar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonEditar.Name = "buttonEditar"
        Me.buttonEditar.Size = New System.Drawing.Size(73, 36)
        Me.buttonEditar.Text = "Editar"
        '
        'buttonCerrar
        '
        Me.buttonCerrar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.buttonCerrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_32
        Me.buttonCerrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.buttonCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.buttonCerrar.Name = "buttonCerrar"
        Me.buttonCerrar.Size = New System.Drawing.Size(75, 36)
        Me.buttonCerrar.Text = "Cerrar"
        '
        'toolstripMain
        '
        Me.toolstripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.toolstripMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.buttonCerrar, Me.buttonEditar, Me.buttonCancelar, Me.buttonGuardar})
        Me.toolstripMain.Location = New System.Drawing.Point(0, 0)
        Me.toolstripMain.Name = "toolstripMain"
        Me.toolstripMain.Size = New System.Drawing.Size(665, 39)
        Me.toolstripMain.TabIndex = 20
        '
        'textboxIDComunicacion
        '
        Me.textboxIDComunicacion.Location = New System.Drawing.Point(100, 50)
        Me.textboxIDComunicacion.MaxLength = 10
        Me.textboxIDComunicacion.Name = "textboxIDComunicacion"
        Me.textboxIDComunicacion.ReadOnly = True
        Me.textboxIDComunicacion.Size = New System.Drawing.Size(66, 20)
        Me.textboxIDComunicacion.TabIndex = 1
        Me.textboxIDComunicacion.TabStop = False
        Me.textboxIDComunicacion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'labelIDComunicacion
        '
        Me.labelIDComunicacion.AutoSize = True
        Me.labelIDComunicacion.Location = New System.Drawing.Point(12, 53)
        Me.labelIDComunicacion.Name = "labelIDComunicacion"
        Me.labelIDComunicacion.Size = New System.Drawing.Size(21, 13)
        Me.labelIDComunicacion.TabIndex = 0
        Me.labelIDComunicacion.Text = "ID:"
        '
        'textboxNombre
        '
        Me.textboxNombre.Location = New System.Drawing.Point(100, 76)
        Me.textboxNombre.MaxLength = 50
        Me.textboxNombre.Name = "textboxNombre"
        Me.textboxNombre.Size = New System.Drawing.Size(292, 20)
        Me.textboxNombre.TabIndex = 3
        '
        'textboxAsunto
        '
        Me.textboxAsunto.Location = New System.Drawing.Point(100, 103)
        Me.textboxAsunto.MaxLength = 100
        Me.textboxAsunto.Name = "textboxAsunto"
        Me.textboxAsunto.Size = New System.Drawing.Size(553, 20)
        Me.textboxAsunto.TabIndex = 5
        '
        'labelCuerpoMensajeEsHTML
        '
        Me.labelCuerpoMensajeEsHTML.AutoSize = True
        Me.labelCuerpoMensajeEsHTML.Location = New System.Drawing.Point(12, 158)
        Me.labelCuerpoMensajeEsHTML.Name = "labelCuerpoMensajeEsHTML"
        Me.labelCuerpoMensajeEsHTML.Size = New System.Drawing.Size(55, 13)
        Me.labelCuerpoMensajeEsHTML.TabIndex = 8
        Me.labelCuerpoMensajeEsHTML.Text = "Es HTML:"
        '
        'checkboxCuerpoMensajeEsHTML
        '
        Me.checkboxCuerpoMensajeEsHTML.AutoSize = True
        Me.checkboxCuerpoMensajeEsHTML.Location = New System.Drawing.Point(73, 158)
        Me.checkboxCuerpoMensajeEsHTML.Name = "checkboxCuerpoMensajeEsHTML"
        Me.checkboxCuerpoMensajeEsHTML.Size = New System.Drawing.Size(15, 14)
        Me.checkboxCuerpoMensajeEsHTML.TabIndex = 9
        Me.checkboxCuerpoMensajeEsHTML.UseVisualStyleBackColor = True
        '
        'labelCuerpoMensaje
        '
        Me.labelCuerpoMensaje.AutoSize = True
        Me.labelCuerpoMensaje.Location = New System.Drawing.Point(12, 133)
        Me.labelCuerpoMensaje.Name = "labelCuerpoMensaje"
        Me.labelCuerpoMensaje.Size = New System.Drawing.Size(87, 13)
        Me.labelCuerpoMensaje.TabIndex = 6
        Me.labelCuerpoMensaje.Text = "Cuerpo Mensaje:"
        '
        'textboxCuerpoMensaje
        '
        Me.textboxCuerpoMensaje.Location = New System.Drawing.Point(100, 130)
        Me.textboxCuerpoMensaje.MaxLength = 0
        Me.textboxCuerpoMensaje.Multiline = True
        Me.textboxCuerpoMensaje.Name = "textboxCuerpoMensaje"
        Me.textboxCuerpoMensaje.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.textboxCuerpoMensaje.Size = New System.Drawing.Size(553, 256)
        Me.textboxCuerpoMensaje.TabIndex = 7
        '
        'labelUtilizarCampos
        '
        Me.labelUtilizarCampos.AutoSize = True
        Me.labelUtilizarCampos.Location = New System.Drawing.Point(12, 398)
        Me.labelUtilizarCampos.Name = "labelUtilizarCampos"
        Me.labelUtilizarCampos.Size = New System.Drawing.Size(82, 13)
        Me.labelUtilizarCampos.TabIndex = 10
        Me.labelUtilizarCampos.Text = "Utilizar Campos:"
        '
        'checkboxUtilizarCampos
        '
        Me.checkboxUtilizarCampos.AutoSize = True
        Me.checkboxUtilizarCampos.Location = New System.Drawing.Point(206, 398)
        Me.checkboxUtilizarCampos.Name = "checkboxUtilizarCampos"
        Me.checkboxUtilizarCampos.Size = New System.Drawing.Size(15, 14)
        Me.checkboxUtilizarCampos.TabIndex = 11
        Me.checkboxUtilizarCampos.UseVisualStyleBackColor = True
        '
        'labelCantidadDestinatariosPorEmail
        '
        Me.labelCantidadDestinatariosPorEmail.AutoSize = True
        Me.labelCantidadDestinatariosPorEmail.Location = New System.Drawing.Point(12, 425)
        Me.labelCantidadDestinatariosPorEmail.Name = "labelCantidadDestinatariosPorEmail"
        Me.labelCantidadDestinatariosPorEmail.Size = New System.Drawing.Size(180, 13)
        Me.labelCantidadDestinatariosPorEmail.TabIndex = 12
        Me.labelCantidadDestinatariosPorEmail.Text = "Cantidad de Destinatarios por e-Mail:"
        '
        'comboboxCantidadDestinatariosPorEmail
        '
        Me.comboboxCantidadDestinatariosPorEmail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboboxCantidadDestinatariosPorEmail.FormattingEnabled = True
        Me.comboboxCantidadDestinatariosPorEmail.Location = New System.Drawing.Point(206, 422)
        Me.comboboxCantidadDestinatariosPorEmail.Name = "comboboxCantidadDestinatariosPorEmail"
        Me.comboboxCantidadDestinatariosPorEmail.Size = New System.Drawing.Size(63, 21)
        Me.comboboxCantidadDestinatariosPorEmail.TabIndex = 13
        '
        'checkboxDestinatariosEnCampoBCC
        '
        Me.checkboxDestinatariosEnCampoBCC.AutoSize = True
        Me.checkboxDestinatariosEnCampoBCC.Location = New System.Drawing.Point(206, 452)
        Me.checkboxDestinatariosEnCampoBCC.Name = "checkboxDestinatariosEnCampoBCC"
        Me.checkboxDestinatariosEnCampoBCC.Size = New System.Drawing.Size(15, 14)
        Me.checkboxDestinatariosEnCampoBCC.TabIndex = 15
        Me.checkboxDestinatariosEnCampoBCC.UseVisualStyleBackColor = True
        '
        'labelDestinatariosEnCampoBCC
        '
        Me.labelDestinatariosEnCampoBCC.AutoSize = True
        Me.labelDestinatariosEnCampoBCC.Location = New System.Drawing.Point(12, 452)
        Me.labelDestinatariosEnCampoBCC.Name = "labelDestinatariosEnCampoBCC"
        Me.labelDestinatariosEnCampoBCC.Size = New System.Drawing.Size(146, 13)
        Me.labelDestinatariosEnCampoBCC.TabIndex = 14
        Me.labelDestinatariosEnCampoBCC.Text = "Destinatarios en Campo BCC:"
        '
        'labelArchivoAdjunto
        '
        Me.labelArchivoAdjunto.AutoSize = True
        Me.labelArchivoAdjunto.Location = New System.Drawing.Point(12, 479)
        Me.labelArchivoAdjunto.Name = "labelArchivoAdjunto"
        Me.labelArchivoAdjunto.Size = New System.Drawing.Size(84, 13)
        Me.labelArchivoAdjunto.TabIndex = 16
        Me.labelArchivoAdjunto.Text = "Archivo adjunto:"
        '
        'panelEntidadPadre
        '
        Me.panelEntidadPadre.Controls.Add(Me.buttonArchivoAdjuntoBorrar)
        Me.panelEntidadPadre.Controls.Add(Me.buttonArchivoAdjunto)
        Me.panelEntidadPadre.Controls.Add(Me.textboxArchivoAdjunto)
        Me.panelEntidadPadre.Location = New System.Drawing.Point(206, 472)
        Me.panelEntidadPadre.Name = "panelEntidadPadre"
        Me.panelEntidadPadre.Size = New System.Drawing.Size(447, 22)
        Me.panelEntidadPadre.TabIndex = 17
        '
        'buttonArchivoAdjuntoBorrar
        '
        Me.buttonArchivoAdjuntoBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonArchivoAdjuntoBorrar.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_CLOSE_16
        Me.buttonArchivoAdjuntoBorrar.Location = New System.Drawing.Point(425, 0)
        Me.buttonArchivoAdjuntoBorrar.Name = "buttonArchivoAdjuntoBorrar"
        Me.buttonArchivoAdjuntoBorrar.Size = New System.Drawing.Size(22, 22)
        Me.buttonArchivoAdjuntoBorrar.TabIndex = 2
        Me.buttonArchivoAdjuntoBorrar.Text = "…"
        Me.buttonArchivoAdjuntoBorrar.UseVisualStyleBackColor = True
        '
        'buttonArchivoAdjunto
        '
        Me.buttonArchivoAdjunto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.buttonArchivoAdjunto.Image = Global.CSColegio.DesktopApplication.My.Resources.Resources.IMAGE_SEARCH_16
        Me.buttonArchivoAdjunto.Location = New System.Drawing.Point(404, 0)
        Me.buttonArchivoAdjunto.Name = "buttonArchivoAdjunto"
        Me.buttonArchivoAdjunto.Size = New System.Drawing.Size(22, 22)
        Me.buttonArchivoAdjunto.TabIndex = 1
        Me.buttonArchivoAdjunto.Text = "…"
        Me.buttonArchivoAdjunto.UseVisualStyleBackColor = True
        '
        'textboxArchivoAdjunto
        '
        Me.textboxArchivoAdjunto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textboxArchivoAdjunto.Location = New System.Drawing.Point(0, 1)
        Me.textboxArchivoAdjunto.MaxLength = 1000
        Me.textboxArchivoAdjunto.Name = "textboxArchivoAdjunto"
        Me.textboxArchivoAdjunto.Size = New System.Drawing.Size(404, 20)
        Me.textboxArchivoAdjunto.TabIndex = 0
        Me.textboxArchivoAdjunto.TabStop = False
        '
        'checkboxEsActivo
        '
        Me.checkboxEsActivo.AutoSize = True
        Me.checkboxEsActivo.Location = New System.Drawing.Point(206, 506)
        Me.checkboxEsActivo.Name = "checkboxEsActivo"
        Me.checkboxEsActivo.Size = New System.Drawing.Size(15, 14)
        Me.checkboxEsActivo.TabIndex = 19
        Me.checkboxEsActivo.UseVisualStyleBackColor = True
        '
        'labelEsActivo
        '
        Me.labelEsActivo.AutoSize = True
        Me.labelEsActivo.Location = New System.Drawing.Point(12, 506)
        Me.labelEsActivo.Name = "labelEsActivo"
        Me.labelEsActivo.Size = New System.Drawing.Size(40, 13)
        Me.labelEsActivo.TabIndex = 18
        Me.labelEsActivo.Text = "Activo:"
        '
        'formComunicacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(665, 535)
        Me.Controls.Add(Me.checkboxEsActivo)
        Me.Controls.Add(Me.labelEsActivo)
        Me.Controls.Add(Me.panelEntidadPadre)
        Me.Controls.Add(Me.labelArchivoAdjunto)
        Me.Controls.Add(Me.checkboxDestinatariosEnCampoBCC)
        Me.Controls.Add(Me.labelDestinatariosEnCampoBCC)
        Me.Controls.Add(Me.comboboxCantidadDestinatariosPorEmail)
        Me.Controls.Add(Me.labelCantidadDestinatariosPorEmail)
        Me.Controls.Add(Me.checkboxUtilizarCampos)
        Me.Controls.Add(Me.labelUtilizarCampos)
        Me.Controls.Add(Me.textboxCuerpoMensaje)
        Me.Controls.Add(Me.labelCuerpoMensaje)
        Me.Controls.Add(Me.checkboxCuerpoMensajeEsHTML)
        Me.Controls.Add(Me.labelCuerpoMensajeEsHTML)
        Me.Controls.Add(Me.textboxAsunto)
        Me.Controls.Add(Me.textboxNombre)
        Me.Controls.Add(Me.textboxIDComunicacion)
        Me.Controls.Add(Me.labelIDComunicacion)
        Me.Controls.Add(Me.labelNombre)
        Me.Controls.Add(Me.labelAsunto)
        Me.Controls.Add(Me.toolstripMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "formComunicacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Comunicación"
        Me.toolstripMain.ResumeLayout(False)
        Me.toolstripMain.PerformLayout()
        Me.panelEntidadPadre.ResumeLayout(False)
        Me.panelEntidadPadre.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents labelNombre As System.Windows.Forms.Label
    Friend WithEvents labelAsunto As System.Windows.Forms.Label
    Friend WithEvents buttonGuardar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonEditar As System.Windows.Forms.ToolStripButton
    Friend WithEvents buttonCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolstripMain As System.Windows.Forms.ToolStrip
    Friend WithEvents textboxIDComunicacion As System.Windows.Forms.TextBox
    Friend WithEvents labelIDComunicacion As System.Windows.Forms.Label
    Friend WithEvents textboxNombre As System.Windows.Forms.TextBox
    Friend WithEvents textboxAsunto As System.Windows.Forms.TextBox
    Friend WithEvents labelCuerpoMensajeEsHTML As System.Windows.Forms.Label
    Friend WithEvents checkboxCuerpoMensajeEsHTML As System.Windows.Forms.CheckBox
    Friend WithEvents labelCuerpoMensaje As System.Windows.Forms.Label
    Friend WithEvents textboxCuerpoMensaje As System.Windows.Forms.TextBox
    Friend WithEvents labelUtilizarCampos As System.Windows.Forms.Label
    Friend WithEvents checkboxUtilizarCampos As System.Windows.Forms.CheckBox
    Friend WithEvents labelCantidadDestinatariosPorEmail As System.Windows.Forms.Label
    Friend WithEvents comboboxCantidadDestinatariosPorEmail As System.Windows.Forms.ComboBox
    Friend WithEvents checkboxDestinatariosEnCampoBCC As System.Windows.Forms.CheckBox
    Friend WithEvents labelDestinatariosEnCampoBCC As System.Windows.Forms.Label
    Friend WithEvents labelArchivoAdjunto As System.Windows.Forms.Label
    Friend WithEvents panelEntidadPadre As System.Windows.Forms.Panel
    Friend WithEvents buttonArchivoAdjuntoBorrar As System.Windows.Forms.Button
    Friend WithEvents buttonArchivoAdjunto As System.Windows.Forms.Button
    Friend WithEvents textboxArchivoAdjunto As System.Windows.Forms.TextBox
    Friend WithEvents checkboxEsActivo As System.Windows.Forms.CheckBox
    Friend WithEvents labelEsActivo As System.Windows.Forms.Label
End Class
