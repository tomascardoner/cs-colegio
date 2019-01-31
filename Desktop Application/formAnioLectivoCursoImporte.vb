Public Class formAnioLectivoCursoImporte

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)
    Private mAnioLectivoCursoActual As AnioLectivoCurso
    Private mAnioLectivoCursoImporteActual As AnioLectivoCursoImporte

    Private mIsLoading As Boolean = False
    Private mEditMode As Boolean = False
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByVal EditMode As Boolean, ByRef ParentForm As Form, ByRef AnioLectivoCursoActual As AnioLectivoCurso, ByVal MesInicio As Byte)
        mIsLoading = True
        mEditMode = EditMode

        mAnioLectivoCursoActual = AnioLectivoCursoActual

        If MesInicio = 0 Then
            ' Es Nuevo
            mAnioLectivoCursoImporteActual = New AnioLectivoCursoImporte
            With mAnioLectivoCursoImporteActual
                .IDAnioLectivoCurso = mAnioLectivoCursoActual.IDAnioLectivoCurso
                .MesInicio = MesInicio
            End With
            mdbContext.AnioLectivoCursoImporte.Add(mAnioLectivoCursoImporteActual)
        Else
            mAnioLectivoCursoImporteActual = mdbContext.AnioLectivoCursoImporte.Find(mAnioLectivoCursoActual.IDAnioLectivoCurso, MesInicio)
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
        buttonEditar.Visible = Not mEditMode
        buttonCerrar.Visible = Not mEditMode

        comboboxMesInicio.Enabled = (mEditMode And mAnioLectivoCursoImporteActual.MesInicio = 0)
        currencytextboxImporteMatricula.ReadOnly = Not mEditMode
        currencytextboxImporteCuota.ReadOnly = Not mEditMode
    End Sub

    Friend Sub InitializeFormAndControls()
        SetAppearance()

        ' Cargo los ComboBox
        pFillAndRefreshLists.Mes(comboboxMesInicio, True, False, True, False, False)
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
            textboxAnioLectivo.Text = mAnioLectivoCursoActual.AnioLectivo.ToString
            textboxCurso.Text = mAnioLectivoCursoActual.Curso.Anio.Nombre & " - " & mAnioLectivoCursoActual.Curso.Turno.Nombre & " - " & mAnioLectivoCursoActual.Curso.Division
            comboboxMesInicio.SelectedIndex = .MesInicio - 1
            currencytextboxImporteMatricula.DecimalValue = .ImporteMatricula
            currencytextboxImporteCuota.DecimalValue = .ImporteCuota
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mAnioLectivoCursoImporteActual
            .MesInicio = CByte(comboboxMesInicio.SelectedIndex + 1)
            .ImporteMatricula = currencytextboxImporteMatricula.DecimalValue
            .ImporteCuota = currencytextboxImporteCuota.DecimalValue
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