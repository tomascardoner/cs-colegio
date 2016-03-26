Public Class formAnioLectivoCursoImporte

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)
    Private mAnioLectivoCursoImporteActual As AnioLectivoCursoImporte

    Private mIsLoading As Boolean = False
    Private mEditMode As Boolean = False
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByVal EditMode As Boolean, ByRef ParentForm As Form, ByVal IDAnioLectivoCurso As Short, ByVal MesInicio As Byte)
        mIsLoading = True
        mEditMode = EditMode

        If MesInicio = 0 Then
            ' Es Nuevo
            mAnioLectivoCursoImporteActual = New AnioLectivoCursoImporte
            With mAnioLectivoCursoImporteActual
                .IDAnioLectivoCurso = IDAnioLectivoCurso
                .MesInicio = MesInicio
            End With
            mdbContext.AnioLectivoCursoImporte.Add(mAnioLectivoCursoImporteActual)
        Else
            mAnioLectivoCursoImporteActual = mdbContext.AnioLectivoCursoImporte.Find(IDAnioLectivoCurso, MesInicio)
        End If

        Me.MdiParent = formMDIMain
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

        comboboxMesInicio.Enabled = (mEditMode And mAnioLectivoCursoImporteActual.IDAnioLectivoCurso = 0)
        textboxImporteMatricula.ReadOnly = Not mEditMode
        textboxImporteCuota.ReadOnly = Not mEditMode
    End Sub

    Friend Sub InitializeFormAndControls()
        SetAppearance()

        ' Cargo los ComboBox
        pFillAndRefreshLists.Mes(comboboxMesInicio, True, False, False)
    End Sub

    Friend Sub SetAppearance()

    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        mAnioLectivoCursoImporteActual = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub SetDataFromObjectToControls()
        With mAnioLectivoCursoImporteActual
            textboxAnioLectivo.Text = .AnioLectivoCurso.AnioLectivo.ToString
            textboxCurso.Text = .AnioLectivoCurso.Curso.Anio.Nombre & " - " & .AnioLectivoCurso.Curso.Turno.Nombre & " - " & .AnioLectivoCurso.Curso.Division
            comboboxMesInicio.SelectedIndex = .MesInicio - 1
            textboxImporteMatricula.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.ImporteMatricula)
            textboxImporteCuota.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.ImporteCuota)
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mAnioLectivoCursoImporteActual
            .MesInicio = CByte(comboboxMesInicio.SelectedIndex + 1)
            .ImporteMatricula = CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxImporteMatricula.Text).Value
            .ImporteCuota = CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxImporteCuota.Text).Value
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

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxImporteMatricula.GotFocus, textboxImporteCuota.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub
#End Region

#Region "Main Toolbar"
    Private Sub buttonEditar_Click() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSOIMPORTE_EDITAR) Then
            mEditMode = True
            ChangeMode()
        End If
    End Sub

    Private Sub buttonCerrarOCancelar_Click() Handles buttonCerrar.Click, buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonGuardar_Click() Handles buttonGuardar.Click
        If comboboxMesInicio.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Mes de Inicio.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxMesInicio.Focus()
            Exit Sub
        End If
        If Not textboxImporteMatricula.Value.HasValue Then
            MsgBox("Debe especificar el Importe de la Matrícula.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxImporteMatricula.Focus()
            Exit Sub
        End If
        If Not textboxImporteCuota.Value.HasValue Then
            MsgBox("Debe especificar el Importe de la Cuota.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxImporteCuota.Focus()
            Exit Sub
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        If mdbContext.ChangeTracker.HasChanges Then

            Me.Cursor = Cursors.WaitCursor

            Try
                ' Guardo los cambios
                mdbContext.SaveChanges()

                ' Refresco la lista de Importes de Cursos de Años Lectivos para mostrar los cambios
                If CS_Form.MDIChild_IsLoaded(CType(formMDIMain, Form), "formAnioLectivoCursoImportes") Then
                    Dim formAnioLectivoCursoImportes As formAnioLectivoCursoImportes = CType(CS_Form.MDIChild_GetInstance(CType(formMDIMain, Form), "formAnioLectivoCursoImportes"), formAnioLectivoCursoImportes)
                    formAnioLectivoCursoImportes.RefreshData(mAnioLectivoCursoImporteActual.MesInicio, True)
                    formAnioLectivoCursoImportes = Nothing
                End If

            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Me.Cursor = Cursors.Default
                Select Case CS_Database_EF_SQL.TryDecodeDbUpdateException(dbuex)
                    Case Errors.DuplicatedEntity
                        MsgBox("No se pueden guardar los cambios porque ya existe el Mes de Inicio del Importe del Curso para el Año Lectivo.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                End Select
                Exit Sub

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                CS_Error.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
                Exit Sub
            End Try
        End If

        Me.Close()
    End Sub
#End Region

End Class