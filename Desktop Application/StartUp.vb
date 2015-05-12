Module StartUp
    Friend pUsuario As Usuario

    Friend pCSColegioContext As CSColegioContext

    Friend Sub Main()
        Dim StartupTime As Date

        System.Windows.Forms.Cursor.Current = Cursors.AppStarting

        My.Application.Log.WriteEntry("La Aplicación se está iniciando.", TraceEventType.Information)

        ' Verifico si ya hay una instancia ejecutandose, si permite iniciar otra, o de lo contrario, muestro la instancia original
        If My.Settings.SingleInstanceApplication Then

        End If

        ' Realizo la inicialización de la Aplicación
        If My.Settings.EnableVisualStyles Then
            Application.EnableVisualStyles()
        End If

        ' Muestro el SplashScreen y cambio el puntero del mouse para indicar que la aplicación está iniciando.
        formSplashScreen.Show()
        formSplashScreen.Cursor = Cursors.AppStarting
        Application.DoEvents()

        ' Creo un context global para leer los Parámetros y los Permisos
        pCSColegioContext = New CSColegioContext

        ' Verifico que la Base de Datos corresponda a esta Aplicación a través del GUID guardado en los Parámetros
        If CSM_Parameter.GetString(Constants.PARAMETRO_APPLICATION_DATABASE_GUID) <> Constants.APPLICATION_DATABASE_GUID Then
            MsgBox("La Base de Datos especificada no corresponde a esta aplicación.", MsgBoxStyle.Critical, My.Application.Info.Title)
            formSplashScreen.Close()
            formSplashScreen.Dispose()
            TerminateApplication()
            Exit Sub
        End If

        ' Muestro el Nombre de la Compañía a la que está licenciada la Aplicación
        formSplashScreen.labelLicensedTo.Text = CSM_Parameter.GetString(Constants.PARAMETRO_LICENSE_COMPANY_NAME, "")
        Application.DoEvents()

        ' Tomo el tiempo de inicio para controlar los segundos mínimos que se debe mostrar el Splash Screen
        StartupTime = Now

        ' Muestro el form MDI principal
        formMDIMain.Show()
        ' TODO: Arreglar problema de que el Splash Screen queda tapado por el form MDI

        formMDIMain.Cursor = Cursors.AppStarting
        formMDIMain.Enabled = False

        ' Espero el tiempo mínimo para mostrar el Splash Screen y después lo cierro
        If Not CSM_Instance.IsRunningUnderIDE Then
            Do While Now.Subtract(StartupTime).Seconds < My.Settings.MinimumSplashScreenDisplaySeconds
                Application.DoEvents()
            Loop
        End If
        formSplashScreen.Close()
        formSplashScreen.Dispose()

        ' Muestro la imagen de fondo del MDI
        'formMDIMain.BackgroundImage = 

        ' Si no se está ejecutando dentro del IDE de Visual Studio, se requiere que ingrese Usuario y Contraseña
        If CSM_Instance.IsRunningUnderIDE Then
            Using dbcUsuario As New CSColegioContext
                Dim qryUsuarios = From u In dbcUsuario.Usuario
                        Where u.IDUsuario = 1
                        Select u
                pUsuario = qryUsuarios.SingleOrDefault()
                formMDIMain.ShowCurrentUserInfo()
            End Using
        ElseIf Not formLogin.ShowDialog(formMDIMain) = DialogResult.OK Then
            Application.Exit()
            My.Application.Log.WriteEntry("La Aplicación ha finalizado porque el Usuario no ha iniciado sesión.", TraceEventType.Warning)
            Exit Sub
        End If

        ' Está todo listo. Cambio el puntero del mouse a modo normal y habilito el form MDI principal
        formMDIMain.Cursor = Cursors.Default
        formMDIMain.Enabled = True

        System.Windows.Forms.Cursor.Current = Cursors.Default

        ' Inicio el loop sobre el form MDI principal
        My.Application.Log.WriteEntry("La Aplicación se ha iniciado correctamente.", TraceEventType.Information)
        Application.Run(formMDIMain)
    End Sub

    Friend Sub TerminateApplication()
        pCSColegioContext.Dispose()
        pCSColegioContext = Nothing
    End Sub
End Module