Imports Microsoft.Office.Interop

Public Class formEntidadesSincronizarOutlook

#Region "Declarations"
    Private mIsLoading As Boolean = False
    Private mEditMode As Boolean = False

    Private Opciones As EntidadesSincronizarOutlookOpciones
#End Region

#Region "Form stuff"
    Private Sub ChangeMode()
        If mIsLoading Then
            Exit Sub
        End If

        checkboxEntidadTipoPersonalColegio.Enabled = mEditMode
        checkboxEntidadTipoDocente.Enabled = mEditMode
        checkboxEntidadTipoAlumno.Enabled = mEditMode
        checkboxEntidadTipoFamiliar.Enabled = mEditMode
        checkboxEntidadTipoProveedor.Enabled = mEditMode
        checkboxEntidadTipoOtro.Enabled = mEditMode

        radiobuttonGrupoContactosIgnorar.Enabled = mEditMode
        radiobuttonGrupoContactosBorrar.Enabled = mEditMode

        radiobuttonContactosIgnorar.Enabled = mEditMode
        radiobuttonContactosBorrar.Enabled = mEditMode

        checkboxSincronizarGruposEntidadTipo.Enabled = mEditMode
        checkboxSincronizarGruposNivelYCurso.Enabled = mEditMode

        checkedlistboxAnioLectivo.Enabled = mEditMode

        buttonEditar.Visible = pUsuario.IDUsuarioGrupo = USUARIOGRUPO_ADMINISTRADORES_ID
    End Sub

    Private Sub SetOpciones()
        Dim ItemIndex As Integer = 0

        With Opciones
            checkboxEntidadTipoPersonalColegio.Checked = .EntidadTipoPersonalColegio
            checkboxEntidadTipoDocente.Checked = .EntidadTipoDocente
            checkboxEntidadTipoAlumno.Checked = .EntidadTipoAlumno
            checkboxEntidadTipoFamiliar.Checked = .EntidadTipoFamiliar
            checkboxEntidadTipoProveedor.Checked = .EntidadTipoProveedor
            checkboxEntidadTipoOtro.Checked = .EntidadTipoOtro

            radiobuttonGrupoContactosIgnorar.Checked = Not .GrupoContactosInexistenteBorrar
            radiobuttonGrupoContactosBorrar.Checked = .GrupoContactosInexistenteBorrar

            radiobuttonContactosIgnorar.Checked = Not .ContactoInexistenteBorrar
            radiobuttonContactosBorrar.Checked = .ContactoInexistenteBorrar

            checkboxSincronizarGruposEntidadTipo.Checked = .SincronizarGrupoContactosPorEntidadTipos
            checkboxSincronizarGruposNivelYCurso.Checked = .SincronizarGrupoContactosPorNivelesYCursos

            For Each AnioLectivoActual As Short In .AniosLectivos
                For ItemIndex = ItemIndex To checkedlistboxAnioLectivo.Items.Count -1
                    If Convert.ToInt16(checkedlistboxAnioLectivo.Items(ItemIndex)) = AnioLectivoActual Then
                        checkedlistboxAnioLectivo.SetItemChecked(ItemIndex, True)
                        Exit For
                    End If
                Next
            Next
        End With
    End Sub

    Private Sub Me_Load(sender As Object, e As EventArgs) Handles Me.Load
        mEditMode = False
        ChangeMode()

        pFillAndRefreshLists.AnioLectivo(checkedlistboxAnioLectivo, False, SortOrder.Ascending)

        Opciones = New EntidadesSincronizarOutlookOpciones
        Opciones.LoadFromSettings()

        SetOpciones()
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub Editar(sender As Object, e As EventArgs) Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.ENTIDAD_SINCRONIZAR_OUTLOOK) Then
            mEditMode = True
            ChangeMode()
        End If
    End Sub

    Private Sub Sincronizar(sender As Object, e As EventArgs) Handles buttonSincronizar.Click
        If Not (checkboxEntidadTipoPersonalColegio.Checked OrElse checkboxEntidadTipoDocente.Checked OrElse checkboxEntidadTipoAlumno.Checked OrElse checkboxEntidadTipoFamiliar.Checked OrElse checkboxEntidadTipoProveedor.Checked OrElse checkboxEntidadTipoOtro.Checked) Then
            MsgBox("Para poder sincronizar con Microsoft Outlook, es necesario que seleccione al menos un Tipo de Entidad.", MsgBoxStyle.Information, My.Application.Info.Title)
            Exit Sub
        End If

        With Opciones
            .EntidadTipoPersonalColegio = checkboxEntidadTipoPersonalColegio.Checked
            .EntidadTipoDocente = checkboxEntidadTipoDocente.Checked
            .EntidadTipoAlumno = checkboxEntidadTipoAlumno.Checked
            .EntidadTipoFamiliar = checkboxEntidadTipoFamiliar.Checked
            .EntidadTipoProveedor = checkboxEntidadTipoProveedor.Checked
            .EntidadTipoOtro = checkboxEntidadTipoOtro.Checked

            .GrupoContactosInexistenteBorrar = radiobuttonGrupoContactosBorrar.Checked
            .ContactoInexistenteBorrar = radiobuttonContactosBorrar.Checked

            .SincronizarGrupoContactosPorEntidadTipos = checkboxSincronizarGruposEntidadTipo.Checked
            .SincronizarGrupoContactosPorNivelesYCursos = checkboxSincronizarGruposNivelYCurso.Checked

            .AniosLectivos = New List(Of Short)
            For Each AnioLectivoChecked As Short In checkedlistboxAnioLectivo.CheckedItems
                .AniosLectivos.Append(AnioLectivoChecked)
            Next
        End With

        ' Si se modificaron, guardo las nuevas opciones de sincronización
        If mEditMode Then
            'My.Settings.Outlook_ContactsSync_EntidadTipo_PersonalColegio = checkboxEntidadTipoPersonalColegio.Checked
            'My.Settings.
            'My.Settings.Save()
        End If

        Me.Cursor = Cursors.WaitCursor
        If EntidadesSincronizarOutlook.Sincronizar(Opciones, labelStatus, progressbarMain) Then
            MsgBox("Se han sincronizado las Entidades con los Contactos de Microsoft Outlook.", MsgBoxStyle.Information, My.Application.Info.Title)
            Me.Close()
        Else
            progressbarMain.Visible = False
            progressbarMain.Value = 0
            labelStatus.Visible = False
            labelStatus.Text = ""
        End If
        Me.Cursor = Cursors.Default
        Opciones = Nothing
    End Sub
#End Region

End Class