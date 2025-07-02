Module StartUp
    ' Config files
    Friend pAfipWebServicesConfig As AfipWebServicesConfig
    Friend pAppearanceConfig As New AppearanceConfig
    Friend pComprobanteConfig As ComprobanteConfig
    Friend pDatabaseConfig As DatabaseConfig
    Friend pEmailConfig As EmailConfig
    Friend pGeneralConfig As GeneralConfig
    Friend pOutlookContactsSyncConfig As OutlookContactsSyncConfig
    Friend pSantanderConfig As SantanderConfig

    ' Database stuff
    Friend pDatabase As CardonerSistemas.Database.ADO.SqlServer
    Friend pFillAndRefreshLists As FillAndRefreshLists

    Friend pFormMDIMain As formMDIMain
    Friend pPermisos As List(Of UsuarioGrupoPermiso)
    Friend pParametros As List(Of Parametro)
    Friend pLicensedTo As String
    Friend pUsuario As Usuario

    <STAThread()>
    Friend Sub Main()
        Dim StartupTime As Date

        Cursor.Current = Cursors.AppStarting

        My.Application.Log.WriteEntry("La Aplicación se está iniciando.", TraceEventType.Information)

        ' Cargo los archivos de configuración de la aplicación
        If Not Configuration.LoadFiles() Then
            TerminateApplication()
            Return
        End If

        ' Register Syncfusion License
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1JEaF5cXmtCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXhecnVTRWFcVkJ0VkpWYEk=")

        ' Realizo la inicialización de la Aplicación
        If pAppearanceConfig.EnableVisualStyles Then
            Application.EnableVisualStyles()
        End If

        ' Muestro el SplashScreen y cambio el puntero del mouse para indicar que la aplicación está iniciando.
        formSplashScreen.Show()
        formSplashScreen.Cursor = Cursors.AppStarting
        formSplashScreen.labelStatus.Text = "Obteniendo los parámetros de conexión a la Base de datos..."
        Application.DoEvents()

        ' Obtengo el Connection String para las conexiones de ADO .NET
        pDatabase = New CardonerSistemas.Database.Ado.SqlServer()
        If Not pDatabase.SetProperties(pDatabaseConfig.Datasource, pDatabaseConfig.Database, String.Empty, False, pDatabaseConfig.UserId, pDatabaseConfig.Password, True, pDatabaseConfig.ConnectTimeout, pDatabaseConfig.ConnectRetryCount, pDatabaseConfig.ConnectRetryInterval) Then
            TerminateApplication()
            Return
        End If
        If Not pDatabase.PasswordUnencrypt() Then
            TerminateApplication()
            Return
        End If
        pDatabase.CreateConnectionString()

        ' Verifico que se pueda establecer la conexión a la base de datos
        Dim newLoginData As Boolean = False
        If Not pDatabase.Connect(pDatabaseConfig, newLoginData) Then
            TerminateApplication()
            Return
        End If
        If newLoginData Then
            Configuration.SaveFileDatabase()
        End If

        ' Obtengo el Connection String para las conexiones de Entity Framework
        CSColegioContext.ConnectionString = CardonerSistemas.Database.EntityFramework.CreateConnectionString(pDatabaseConfig.Provider, pDatabase.ConnectionString, "CSColegio")

        ' Cargos los Parámetros desde la Base de datos
        formSplashScreen.labelStatus.Text = "Cargando los parámetros desde la Base de datos..."
        Application.DoEvents()
        If Not Parametros.LoadParameters() Then
            formSplashScreen.Close()
            formSplashScreen.Dispose()
            TerminateApplication()
            Return
        End If

        ' Verifico que la Base de Datos corresponda a esta Aplicación a través del GUID guardado en los Parámetros
        If CS_Parameter_System.GetString(Parametros.APPLICATION_DATABASE_GUID) <> Constantes.APPLICATION_DATABASE_GUID Then
            MsgBox("La Base de Datos especificada no corresponde a esta aplicación.", MsgBoxStyle.Critical, My.Application.Info.Title)
            formSplashScreen.Close()
            formSplashScreen.Dispose()
            TerminateApplication()
            Return
        End If

        formSplashScreen.Focus()

        ' Muestro el Nombre de la Compañía a la que está licenciada la Aplicación
        If Not CardonerSistemas.Encrypt.StringCipher.Decrypt(CS_Parameter_System.GetString(Parametros.LICENSE_COMPANY_NAME, "EMPTY"), Constantes.APPLICATION_LICENSE_PASSWORD, pLicensedTo) Then
            MsgBox("La Licencia especificada es incorrecta.", MsgBoxStyle.Critical, My.Application.Info.Title)
            formSplashScreen.Close()
            formSplashScreen.Dispose()
            TerminateApplication()
            Return
        End If
        formSplashScreen.labelLicensedTo.Text = pLicensedTo
        Application.DoEvents()

        ' Preparo instancia de clase para llenar los ComboBox
        pFillAndRefreshLists = New FillAndRefreshLists

        formSplashScreen.Focus()

        ' Tomo el tiempo de inicio para controlar los segundos mínimos que se debe mostrar el Splash Screen
        StartupTime = Now

        ' Muestro el form MDI principal
        pFormMDIMain = New formMDIMain()
        pFormMDIMain.Show()

        pFormMDIMain.Focus()
        formSplashScreen.Focus()
        Application.DoEvents()

        pFormMDIMain.Cursor = Cursors.AppStarting
        pFormMDIMain.Enabled = False

        formSplashScreen.labelStatus.Text = "Todo completado."
        formSplashScreen.Focus()
        Application.DoEvents()

        ' Espero el tiempo mínimo para mostrar el Splash Screen y después lo cierro
        If Not CS_Instance.IsRunningUnderIDE Then
            Do While Now.Subtract(StartupTime).Seconds < pAppearanceConfig.MinimumSplashScreenDisplaySeconds
                Application.DoEvents()
            Loop
        End If
        formSplashScreen.Close()
        formSplashScreen.Dispose()
        pFormMDIMain.Focus()

        If CS_Instance.IsRunningUnderIDE Then
            ' Como se está ejecutando dentro del IDE de Visual Studio, en lugar de pedir Usuario y contraseña, asumo que es el Administrador
            Using dbcontext As New CSColegioContext(True)
                pUsuario = dbcontext.Usuario.Find(1)
                Appearance.UserLoggedIn()
            End Using
        Else
            If formLogin.ShowDialog(pFormMDIMain) <> DialogResult.OK Then
                Application.Exit()
                My.Application.Log.WriteEntry("La Aplicación ha finalizado porque el Usuario no ha iniciado sesión.", TraceEventType.Warning)
                Return
            End If
            formLogin.Close()
            formLogin.Dispose()
        End If

        ' Cambio el puntero del mouse a modo normal y habilito el form MDI principal
        pFormMDIMain.Cursor = Cursors.Default
        pFormMDIMain.Enabled = True
        pFormMDIMain.Focus()

        Cursor.Current = Cursors.Default

        ' Inicio el loop sobre el form MDI principal
        My.Application.Log.WriteEntry("La Aplicación se ha iniciado correctamente.", TraceEventType.Information)
        Application.Run(pFormMDIMain)
    End Sub

    Friend Sub TerminateApplication()
        If pFormMDIMain IsNot Nothing Then
            For Each formCurrent As Form In pFormMDIMain.MdiChildren()
                formCurrent.Close()
                formCurrent.Dispose()
            Next
        End If

        pAfipWebServicesConfig = Nothing
        pAppearanceConfig = Nothing
        pComprobanteConfig = Nothing
        pDatabaseConfig = Nothing
        pEmailConfig = Nothing
        pGeneralConfig = Nothing
        pOutlookContactsSyncConfig = Nothing
        pSantanderConfig = Nothing

        pDatabase = Nothing
        pFillAndRefreshLists = Nothing
        pPermisos = Nothing
        pParametros = Nothing
        pLicensedTo = Nothing
        pUsuario = Nothing
    End Sub
End Module
