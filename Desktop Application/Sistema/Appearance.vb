Module Appearance

    Friend Sub UserLoggedIn()
        LoadPermisos()

        pFormMDIMain.menuitemDebug.Visible = (pUsuario.IDUsuario = 1)

        Select Case pUsuario.Genero
            Case Constantes.ENTIDAD_GENERO_MASCULINO
                pFormMDIMain.labelUsuarioNombre.Image = My.Resources.Resources.IMAGE_USUARIO_HOMBRE_16
            Case Constantes.ENTIDAD_GENERO_FEMENINO
                pFormMDIMain.labelUsuarioNombre.Image = My.Resources.Resources.IMAGE_USUARIO_MUJER_16
            Case Else
                pFormMDIMain.labelUsuarioNombre.Image = Nothing
        End Select
        pFormMDIMain.labelUsuarioNombre.Text = pUsuario.Descripcion

        My.Application.Log.WriteEntry(String.Format("El Usuario '{0}' ha iniciado sesión.", pUsuario.Nombre), TraceEventType.Information)
    End Sub

End Module
