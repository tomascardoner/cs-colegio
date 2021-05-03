Public Class formUsuarioGrupoPermisos

#Region "Declarations"

    Private mdbContext As New CSColegioContext(True)

#End Region

#Region "Form stuff"

    Friend Sub SetAppearance()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.IMAGE_TABLAS_32)
    End Sub

    Private Sub Me_Load() Handles Me.Load
        SetAppearance()

        pFillAndRefreshLists.UsuarioGrupo(comboboxUsuarioGrupo, False, False, False)
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        Me.Dispose()
    End Sub

#End Region

#Region "Controls behavior"

    Private Sub comboboxUsuarioGrupo_SelectedValueChanged() Handles comboboxUsuarioGrupo.SelectedValueChanged
        Cursor.Current = Cursors.WaitCursor

        Permisos.CargarArbolDePermisos(treeviewPermisos, CByte(comboboxUsuarioGrupo.SelectedValue))

        Cursor.Current = Cursors.Default
    End Sub

    Private Sub treeviewPermisos_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles treeviewPermisos.AfterCheck
        Dim nodeCurrent As TreeNode
        Dim permisoCurrent As UsuarioGrupoPermiso

        If e.Action <> TreeViewAction.ByMouse And e.Action <> TreeViewAction.ByKeyboard Then
            Exit Sub
        End If

        nodeCurrent = e.Node

        If nodeCurrent.Checked Then
            ' Agregar permiso
            permisoCurrent = New UsuarioGrupoPermiso
            permisoCurrent.IDUsuarioGrupo = CByte(comboboxUsuarioGrupo.SelectedValue)
            permisoCurrent.IDPermiso = nodeCurrent.Name

            Try
                mdbContext.UsuarioGrupoPermiso.Add(permisoCurrent)
                mdbContext.SaveChanges()
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al establecer el permiso.")
            End Try
        Else
            ' Quitar permiso
            Try
                permisoCurrent = mdbContext.UsuarioGrupoPermiso.Find(CByte(comboboxUsuarioGrupo.SelectedValue), nodeCurrent.Name)
                mdbContext.UsuarioGrupoPermiso.Remove(permisoCurrent)
                mdbContext.SaveChanges()
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al quitar el permiso.")
            End Try
        End If
    End Sub

#End Region

End Class