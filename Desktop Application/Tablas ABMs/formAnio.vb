Public Class formAnio

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)
    Private mAnioActual As Anio

    Private mIsLoading As Boolean = False
    Private mEditMode As Boolean = False
#End Region

#Region "Form stuff"

    Friend Sub LoadAndShow(ByVal EditMode As Boolean, ByRef ParentForm As Form, ByVal IDAnio As Byte)
        mIsLoading = True
        mEditMode = EditMode

        If IDAnio = 0 Then
            ' Es Nuevo
            mAnioActual = New Anio
            With mAnioActual
                .EsActivo = True
                .IDUsuarioCreacion = pUsuario.IDUsuario
                .FechaHoraCreacion = Now
                .IDUsuarioModificacion = pUsuario.IDUsuario
                .FechaHoraModificacion = .FechaHoraCreacion
            End With
            mdbContext.Anio.Add(mAnioActual)
        Else
            mAnioActual = mdbContext.Anio.Find(IDAnio)
        End If

        Me.MdiParent = pFormMDIMain
        CardonerSistemas.Forms.CenterToParent(ParentForm, Me)
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

        comboboxNivel.Enabled = mEditMode
        textboxNombre.ReadOnly = Not mEditMode
        comboboxAnioSiguiente.Enabled = mEditMode
        checkboxEsActivo.Enabled = mEditMode
    End Sub

    Friend Sub InitializeFormAndControls()
        SetAppearance()

        ' Cargo los ComboBox
        pFillAndRefreshLists.Nivel(comboboxNivel, False, False)
        pFillAndRefreshLists.Anio(comboboxAnioSiguiente, False, True, True, mAnioActual.IDAnio)
    End Sub

    Friend Sub SetAppearance()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.IMAGE_TABLAS_32)
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        mAnioActual = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub SetDataFromObjectToControls()
        With mAnioActual
            If .IDAnio = 0 Then
                textboxIDAnio.Text = My.Resources.STRING_ITEM_NEW_MALE
            Else
                textboxIDAnio.Text = String.Format(.IDAnio.ToString, "G")
            End If
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxNivel, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.Value, .IDNivel)
            textboxNombre.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Nombre)
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxAnioSiguiente, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.Value, .IDAnioSiguiente, CByte(0))
            checkboxEsActivo.CheckState = CS_ValueTranslation.FromObjectBooleanToControlCheckBox(.EsActivo)
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mAnioActual
            .IDNivel = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxNivel.SelectedValue, 0).Value
            .Nombre = CS_ValueTranslation.FromControlTextBoxToObjectString(textboxNombre.Text)
            .IDAnioSiguiente = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxAnioSiguiente.SelectedValue, 0)
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

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxNombre.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub
#End Region

#Region "Main Toolbar"

    Private Sub Editar_Click() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.ANIO_EDITAR) Then
            mEditMode = True
            ChangeMode()
        End If
    End Sub

    Private Sub CerrarOCancelar_Click() Handles buttonCerrar.Click, buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub Guardar_Click() Handles buttonGuardar.Click
        If comboboxNivel.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Nivel.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxNivel.Focus()
            Exit Sub
        End If
        If textboxNombre.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar el Nombre.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxNombre.Focus()
            Exit Sub
        End If

        ' Generar el ID del Año nuevo
        If mAnioActual.IDAnio = 0 Then
            Using dbcMaxID As New CSColegioContext(True)
                If dbcMaxID.Anio.Count = 0 Then
                    mAnioActual.IDAnio = 1
                Else
                    mAnioActual.IDAnio = dbcMaxID.Anio.Max(Function(a) a.IDAnio) + CByte(1)
                End If
            End Using
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        If mdbContext.ChangeTracker.HasChanges Then

            Me.Cursor = Cursors.WaitCursor

            mAnioActual.IDUsuarioModificacion = pUsuario.IDUsuario
            mAnioActual.FechaHoraModificacion = Now

            Try

                ' Guardo los cambios
                mdbContext.SaveChanges()

                ' Refresco la lista de Entidades para mostrar los cambios
                If CardonerSistemas.Forms.MdiChildIsLoaded(CType(pFormMDIMain, Form), "formAnios") Then
                    Dim formAnios As formAnios = CType(CardonerSistemas.Forms.MdiChildGetInstance(CType(pFormMDIMain, Form), "formAnios"), formAnios)
                    formAnios.RefreshData(mAnioActual.IDAnio)
                    formAnios = Nothing
                End If

            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Me.Cursor = Cursors.Default
                Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                    Case CardonerSistemas.Database.EntityFramework.Errors.DuplicatedEntity
                        MsgBox("No se pueden guardar los cambios porque ya existe un Año con el mismo Nombre.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
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