Public Class formAnioLectivoCursosImportesAgregar

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)

    Private mIsLoading As Boolean = False
    Private mEditMode As Boolean = False

    Private mAnioLectivo As Short

    Private Class GridRowData_NivelTurno
        Public Property IDNivel As Byte
        Public Property NivelNombre As String
        Public Property IDTurno As Byte
        Public Property TurnoNombre As String
    End Class
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByVal AnioLectivo As Short)
        mIsLoading = True

        mAnioLectivo = AnioLectivo
        textboxAnioLectivo.Text = mAnioLectivo.ToString

        Me.MdiParent = formMDIMain
        InitializeFormAndControls()
        Me.Show()
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
        End If
        Me.Focus()

        mIsLoading = False
    End Sub

    Private Sub InitializeFormAndControls()
        SetAppearance()

        ' Cargo los ComboBox
        pFillAndRefreshLists.Mes(comboboxMesInicio, True, False, True, False, False)
    End Sub

    Friend Sub SetAppearance()

    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Load and Set Data"
    Private Sub RefreshData()
        'Dim listNivelesTurnos As List(Of GridRowData_NivelTurno)

        'If comboboxMesInicio.SelectedIndex > -1 Then
        '    listNivelesTurnos = (From alc In mdbContext.AnioLectivoCurso
        '                         Join c In mdbContext.Curso On alc.IDCurso Equals c.IDCurso
        '                         Join a In mdbContext.Anio On c.IDAnio Equals a.IDAnio
        '                         Join n In mdbContext.Nivel On a.IDNivel Equals n.IDNivel
        '                         Group Join AnioSiguiente In dbContext.Anio On New With {.IDAnioSiguiente = CByte(a.IDAnioSiguiente)} Equals New With {.IDAnioSiguiente = AnioSiguiente.IDAnio} Into AnioSiguiente_join = Group
        '                         From AnioSiguiente In AnioSiguiente_join.DefaultIfEmpty()

        '                         Join t In mdbContext.Turno On c.IDTurno Equals t.IDTurno
        '    Where alc.AnioLectivo = mAnioLectivo
        '                         Order By n.Nombre, t.Nombre
        '                         Select New GridRowData_NivelTurno With {.IDNivel = n.IDNivel, .NivelNombre = n.Nombre, .IDTurno = t.IDTurno, .TurnoNombre = t.Nombre}).ToList
        '    datagridviewNivelesTurnos.AutoGenerateColumns = False
        '    datagridviewNivelesTurnos.DataSource = listNivelesTurnos
        'End If
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub FormKeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                buttonGuardar.PerformClick()
            Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                buttonCancelar.PerformClick()
        End Select
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs)
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub CargarGrilla(sender As Object, e As EventArgs) Handles comboboxMesInicio.SelectedValueChanged
        RefreshData()
    End Sub
#End Region

#Region "Main Toolbar"
    Private Sub buttonCancelar_Click() Handles buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonGuardar_Click() Handles buttonGuardar.Click
        ' Generar el ID del Año nuevo
        'If mCursoActual.IDCurso = 0 Then
        '    Using dbcMaxID As New CSColegioContext(True)
        '        If dbcMaxID.Curso.Count = 0 Then
        '            mCursoActual.IDCurso = 1
        '        Else
        '            mCursoActual.IDCurso = dbcMaxID.Curso.Max(Function(a) a.IDCurso) + CByte(1)
        '        End If
        '    End Using
        'End If

        '' Paso los datos desde los controles al Objecto de EF
        'SetDataFromControlsToObject()

        'If mdbContext.ChangeTracker.HasChanges Then

        '    Me.Cursor = Cursors.WaitCursor

        '    mCursoActual.IDUsuarioModificacion = pUsuario.IDUsuario
        '    mCursoActual.FechaHoraModificacion = Now

        '    Try

        '        ' Guardo los cambios
        '        mdbContext.SaveChanges()

        '        ' Refresco la lista de Entidades para mostrar los cambios
        '        If CS_Form.MDIChild_IsLoaded(CType(formMDIMain, Form), "formCursos") Then
        '            Dim formCursos As formCursos = CType(CS_Form.MDIChild_GetInstance(CType(formMDIMain, Form), "formCursos"), formCursos)
        '            formCursos.RefreshData(mCursoActual.IDCurso)
        '            formCursos = Nothing
        '        End If

        '    Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
        '        Me.Cursor = Cursors.Default
        '        Select Case CS_Database_EF_SQL.TryDecodeDbUpdateException(dbuex)
        '            Case Errors.DuplicatedEntity
        '                MsgBox("No se pueden guardar los cambios porque ya existe un Curso con el mismo Año, Turno y División.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
        '        End Select
        '        Exit Sub

        '    Catch ex As Exception
        '        Me.Cursor = Cursors.Default
        '        CS_Error.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
        '        Exit Sub
        '    End Try
        'End If

        'Me.Close()
    End Sub
#End Region

End Class