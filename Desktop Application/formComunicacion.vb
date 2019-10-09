Public Class formComunicacion

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)
    Private mComunicacionActual As Comunicacion

    Private mIsLoading As Boolean = False
    Private mEditMode As Boolean = False
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByVal EditMode As Boolean, ByRef ParentForm As Form, ByVal IDComunicacion As Short, Optional ByVal EsCopia As Boolean = False)
        mIsLoading = True
        mEditMode = EditMode

        If IDComunicacion = 0 Then
            ' Es Nuevo
            mComunicacionActual = New Comunicacion
            With mComunicacionActual
                .EsActivo = True
                .IDUsuarioCreacion = pUsuario.IDUsuario
                .FechaHoraCreacion = Now
                .IDUsuarioModificacion = pUsuario.IDUsuario
                .FechaHoraModificacion = .FechaHoraCreacion
            End With
            mdbContext.Comunicacion.Add(mComunicacionActual)
        ElseIf EsCopia Then
            ' Es Copia
            Dim ComunicacionDeOrigen As Comunicacion = mdbContext.Comunicacion.Find(IDComunicacion)

            mComunicacionActual = New Comunicacion
            With mComunicacionActual
                .Nombre = ComunicacionDeOrigen.Nombre
                .Asunto = ComunicacionDeOrigen.Asunto
                .CuerpoMensajeEsHTML = ComunicacionDeOrigen.CuerpoMensajeEsHTML
                .CuerpoMensaje = ComunicacionDeOrigen.CuerpoMensaje
                .UtilizarCampos = ComunicacionDeOrigen.UtilizarCampos
                .CantidadDestinatariosPorEmail = ComunicacionDeOrigen.CantidadDestinatariosPorEmail
                .DestinatariosEnCampoBCC = ComunicacionDeOrigen.DestinatariosEnCampoBCC
                .ArchivoAdjunto = ComunicacionDeOrigen.ArchivoAdjunto
                .EsActivo = ComunicacionDeOrigen.EsActivo
                .Notas = ComunicacionDeOrigen.Notas
                .IDUsuarioCreacion = pUsuario.IDUsuario
                .FechaHoraCreacion = Now
                .IDUsuarioModificacion = pUsuario.IDUsuario
                .FechaHoraModificacion = .FechaHoraCreacion
            End With
            mdbContext.Comunicacion.Add(mComunicacionActual)
        Else
            ' Es Edición
            mComunicacionActual = mdbContext.Comunicacion.Find(IDComunicacion)
        End If

        Me.MdiParent = pFormMDIMain
        CS_Form.CenterToParent(ParentForm, Me)
        InitializeFormAndControls()
        SetDataFromObjectToControls()
        Me.Show()
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
        End If
        Me.Focus()

        mIsLoading = False

        ChangeMode()
    End Sub

    Private Sub ChangeMode()
        If mIsLoading Then
            Exit Sub
        End If

        buttonGuardar.Visible = mEditMode
        buttonCancelar.Visible = mEditMode
        buttonEditar.Visible = (mEditMode = False)
        buttonCerrar.Visible = (mEditMode = False)

        textboxNombre.ReadOnly = Not mEditMode
        textboxAsunto.ReadOnly = Not mEditMode
        textboxCuerpoMensaje.ReadOnly = Not mEditMode
        checkboxCuerpoMensajeEsHTML.Enabled = mEditMode
        checkboxUtilizarCampos.Enabled = mEditMode
        comboboxCantidadDestinatariosPorEmail.Enabled = mEditMode
        checkboxDestinatariosEnCampoBCC.Enabled = mEditMode
        textboxArchivoAdjunto.ReadOnly = Not mEditMode
        buttonArchivoAdjunto.Enabled = mEditMode
        buttonArchivoAdjuntoBorrar.Enabled = mEditMode
        checkboxEsActivo.Enabled = mEditMode
    End Sub

    Friend Sub InitializeFormAndControls()
        SetAppearance()

        ' Cargo los ComboBox
        comboboxCantidadDestinatariosPorEmail.Items.AddRange({"1", "2", "3", "4", "5", "10", "20", "30", "50", "75", "100", "150", "200"})
        comboboxCantidadDestinatariosPorEmail.SelectedIndex = 0
    End Sub

    Friend Sub SetAppearance()

    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        mComunicacionActual = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub SetDataFromObjectToControls()
        With mComunicacionActual
            If .IDComunicacion = 0 Then
                textboxIDComunicacion.Text = My.Resources.STRING_ITEM_NEW_MALE
            Else
                textboxIDComunicacion.Text = String.Format(.IDComunicacion.ToString, "G")
            End If
            textboxNombre.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Nombre)
            textboxAsunto.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Asunto)
            textboxCuerpoMensaje.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.CuerpoMensaje)
            checkboxCuerpoMensajeEsHTML.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.CuerpoMensajeEsHTML)
            checkboxUtilizarCampos.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.UtilizarCampos)
            CS_ComboBox.SetSelectedIndexByDisplayValue(comboboxCantidadDestinatariosPorEmail, .CantidadDestinatariosPorEmail.ToString)
            checkboxDestinatariosEnCampoBCC.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.DestinatariosEnCampoBCC)
            textboxArchivoAdjunto.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.ArchivoAdjunto)
            checkboxEsActivo.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.EsActivo)
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mComunicacionActual
            .Nombre = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNombre.Text)
            .Asunto = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxAsunto.Text)
            .CuerpoMensaje = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxCuerpoMensaje.Text, , False)
            .CuerpoMensajeEsHTML = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxCuerpoMensajeEsHTML.CheckState)
            .UtilizarCampos = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxUtilizarCampos.CheckState)
            .CantidadDestinatariosPorEmail = CByte(comboboxCantidadDestinatariosPorEmail.Text)
            .DestinatariosEnCampoBCC = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxDestinatariosEnCampoBCC.CheckState)
            .ArchivoAdjunto = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxArchivoAdjunto.Text)
            .EsActivo = CS_ValueTranslation.FromControlCheckBoxToObjectBoolean(checkboxEsActivo.CheckState)
        End With
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub FormKeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                If mEditMode Then
                    buttonGuardar.PerformClick()
                Else
                    buttonCerrar.PerformClick()
                End If
            Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                If mEditMode Then
                    buttonCancelar.PerformClick()
                Else
                    buttonCerrar.PerformClick()
                End If
        End Select
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxNombre.GotFocus, textboxAsunto.GotFocus, textboxCuerpoMensaje.GotFocus, textboxArchivoAdjunto.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub ArchivoAdjuntoBuscar() Handles buttonArchivoAdjunto.Click
        Dim dialogOpenFile As New OpenFileDialog

        With dialogOpenFile
            .CheckFileExists = True
            .FileName = textboxArchivoAdjunto.Text
            .Multiselect = False
            .ReadOnlyChecked = True
            .Title = "Seleccione el Archivo a adjuntar"
            If .ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                textboxArchivoAdjunto.Text = .FileName
            End If
        End With
    End Sub

    Private Sub ArchivoAdjuntoBorrar() Handles buttonArchivoAdjuntoBorrar.Click
        textboxArchivoAdjunto.Text = ""
    End Sub
#End Region

#Region "Main Toolbar"
    Private Sub buttonEditar_Click() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.COMUNICACION_EDITAR) Then
            mEditMode = True
            ChangeMode()
        End If
    End Sub

    Private Sub buttonCerrarOCancelar_Click() Handles buttonCerrar.Click, buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonGuardar_Click() Handles buttonGuardar.Click
        If textboxNombre.Text.Trim.Length = 0 Then
            MsgBox("Debe especificar el Nombre.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxNombre.Focus()
            Exit Sub
        End If
        If textboxAsunto.Text.Trim.Length = 0 Then
            MsgBox("Debe especificar el Asunto.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxAsunto.Focus()
            Exit Sub
        End If
        If comboboxCantidadDestinatariosPorEmail.SelectedIndex = -1 Then
            MsgBox("Debe especificar la Cantidad de Destinatarios por e-Mail.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxCantidadDestinatariosPorEmail.Focus()
            Exit Sub
        End If
        If textboxArchivoAdjunto.Text.Trim.Length > 0 Then
            If Not My.Computer.FileSystem.FileExists(textboxArchivoAdjunto.Text.Trim) Then
                MsgBox("El Archivo adjunto especificado no existe.", MsgBoxStyle.Information, My.Application.Info.Title)
                textboxArchivoAdjunto.Focus()
                Exit Sub
            End If
        End If

        ' Generar el ID de la Comunicación nueva
        If mComunicacionActual.IDComunicacion = 0 Then
            Using dbcMaxID As New CSColegioContext(True)
                If dbcMaxID.Comunicacion.Count = 0 Then
                    mComunicacionActual.IDComunicacion = 1
                Else
                    mComunicacionActual.IDComunicacion = dbcMaxID.Comunicacion.Max(Function(alc) alc.IDComunicacion) + CShort(1)
                End If
            End Using
            mComunicacionActual.FechaHoraCreacion = Now
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        If mdbContext.ChangeTracker.HasChanges Then

            Me.Cursor = Cursors.WaitCursor

            mComunicacionActual.IDUsuarioModificacion = pUsuario.IDUsuario
            mComunicacionActual.FechaHoraModificacion = Now

            Try
                ' Guardo los cambios
                mdbContext.SaveChanges()

                ' Refresco la lista de Cursos de Años Lectivos para mostrar los cambios
                If CS_Form.MDIChild_IsLoaded(CType(pFormMDIMain, Form), "formComunicaciones") Then
                    Dim formComunicaciones As formComunicaciones = CType(CS_Form.MDIChild_GetInstance(CType(pFormMDIMain, Form), "formComunicaciones"), formComunicaciones)
                    formComunicaciones.RefreshData(mComunicacionActual.IDComunicacion)
                    formComunicaciones = Nothing
                End If

            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Me.Cursor = Cursors.Default
                Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                    Case CardonerSistemas.Database.EntityFramework.Errors.DuplicatedEntity
                        MsgBox("No se pueden guardar los cambios porque ya existe una Comunicación con el mismo ID o Nombre.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                End Select
                Exit Sub

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                CardonerSistemas.ErrorHandler.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
                Exit Sub
            End Try
        End If

        Me.Close()
    End Sub
#End Region

End Class