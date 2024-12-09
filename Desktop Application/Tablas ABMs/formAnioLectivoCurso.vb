Public Class formAnioLectivoCurso

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)
    Private mAnioLectivoCursoActual As AnioLectivoCurso

    Private mIsLoading As Boolean = False
    Private mEditMode As Boolean = False
#End Region

#Region "Form stuff"

    Friend Sub LoadAndShow(ByVal EditMode As Boolean, ByRef ParentForm As Form, ByVal IDAnioLectivoCurso As Short)
        mIsLoading = True
        mEditMode = EditMode

        If IDAnioLectivoCurso = 0 Then
            ' Es Nuevo
            mAnioLectivoCursoActual = New AnioLectivoCurso
            With mAnioLectivoCursoActual
                .AnioLectivo = CShort(DateTime.Today.Year)
            End With
            mdbContext.AnioLectivoCurso.Add(mAnioLectivoCursoActual)
        Else
            mAnioLectivoCursoActual = mdbContext.AnioLectivoCurso.Find(IDAnioLectivoCurso)
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

        comboboxAnioLectivo.Enabled = mEditMode
        comboboxCurso.Enabled = mEditMode
    End Sub

    Friend Sub InitializeFormAndControls()
        SetAppearance()

        ' Cargo los ComboBox
        pFillAndRefreshLists.AnioLectivo(comboboxAnioLectivo, False, SortOrder.Descending)
        pFillAndRefreshLists.Curso(comboboxCurso, False, False, True)
    End Sub

    Friend Sub SetAppearance()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.IMAGE_TABLAS_32)
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        mAnioLectivoCursoActual = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Mostrar y leer datos"
    Friend Sub SetDataFromObjectToControls()
        With mAnioLectivoCursoActual
            If .IDAnioLectivoCurso = 0 Then
                textboxIDAnioLectivoCurso.Text = My.Resources.STRING_ITEM_NEW_MALE
            Else
                textboxIDAnioLectivoCurso.Text = String.Format(.IDAnioLectivoCurso.ToString, "G")
            End If
            comboboxAnioLectivo.SelectedIndex = comboboxAnioLectivo.FindStringExact(.AnioLectivo.ToString)
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxCurso, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.Value, .IDCurso)
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mAnioLectivoCursoActual
            .AnioLectivo = CShort(comboboxAnioLectivo.Text)
            .IDCurso = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxCurso.SelectedValue, 0).Value
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

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs)
        CType(sender, TextBox).SelectAll()
    End Sub
#End Region

#Region "Main Toolbar"

    Private Sub Editar_Click() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSO_EDITAR) Then
            mEditMode = True
            ChangeMode()
        End If
    End Sub

    Private Sub CerrarOCancelar_Click() Handles buttonCerrar.Click, buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub Guardar_Click() Handles buttonGuardar.Click
        If comboboxAnioLectivo.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Año Lectivo.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxAnioLectivo.Focus()
            Exit Sub
        End If
        If comboboxCurso.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Curso.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxCurso.Focus()
            Exit Sub
        End If

        ' Generar el ID del Año nuevo
        If mAnioLectivoCursoActual.IDAnioLectivoCurso = 0 Then
            Using dbcMaxID As New CSColegioContext(True)
                If dbcMaxID.Curso.Count = 0 Then
                    mAnioLectivoCursoActual.IDAnioLectivoCurso = 1
                Else
                    mAnioLectivoCursoActual.IDAnioLectivoCurso = dbcMaxID.AnioLectivoCurso.Max(Function(alc) alc.IDAnioLectivoCurso) + CShort(1)
                End If
            End Using
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        If mdbContext.ChangeTracker.HasChanges Then

            Me.Cursor = Cursors.WaitCursor

            Try
                ' Guardo los cambios
                mdbContext.SaveChanges()

                ' Refresco la lista de Cursos de Años Lectivos para mostrar los cambios
                If CardonerSistemas.Forms.MdiChildIsLoaded(CType(pFormMDIMain, Form), "formAnioLectivoCursos") Then
                    Dim formAnioLectivoCursos As formAnioLectivoCursos = CType(CardonerSistemas.Forms.MdiChildGetInstance(CType(pFormMDIMain, Form), "formAnioLectivoCursos"), formAnioLectivoCursos)
                    formAnioLectivoCursos.RefreshData(mAnioLectivoCursoActual.IDAnioLectivoCurso)
                    formAnioLectivoCursos = Nothing
                End If

            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Me.Cursor = Cursors.Default
                Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                    Case CardonerSistemas.Database.EntityFramework.Errors.DuplicatedEntity
                        MsgBox("No se pueden guardar los cambios porque ya existe el Curso para el Año Lectivo.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
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