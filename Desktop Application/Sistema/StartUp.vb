﻿Imports System.Xml

Module StartUp
    ' Database stuff
    Friend pDatabase As CardonerSistemas.Database.ADO.SQLServer
    Friend pFillAndRefreshLists As FillAndRefreshLists

    ' Config files
    Friend pAfipWebServicesConfig As AfipWebServicesConfig
    Friend pAppearanceConfig As New AppearanceConfig
    Friend pComprobanteConfig As ComprobanteConfig
    Friend pDatabaseConfig As DatabaseConfig
    Friend pEmailConfig As EmailConfig
    Friend pGeneralConfig As GeneralConfig
    Friend pOutlookContactsSyncConfig As OutlookContactsSyncConfig
    Friend pSantanderConfig As SantanderConfig

    Friend pFormMDIMain As formMDIMain
    Friend pPermisos As List(Of UsuarioGrupoPermiso)
    Friend pParametros As List(Of Parametro)
    Friend pLicensedTo As String
    Friend pUsuario As Usuario

    Friend Sub Main()
        Dim StartupTime As Date

        System.Windows.Forms.Cursor.Current = Cursors.AppStarting

        My.Application.Log.WriteEntry("La Aplicación se está iniciando.", TraceEventType.Information)

        ' Cargo los archivos de configuración de la aplicación
        If Not Configuration.LoadFiles() Then
            TerminateApplication()
            Exit Sub
        End If

        ' Verifico si ya hay una instancia ejecutandose, si permite iniciar otra, o de lo contrario, muestro la instancia original
        If pAppearanceConfig.SingleInstanceApplication Then

        End If

        ' Realizo la inicialización de la Aplicación
        If pAppearanceConfig.EnableVisualStyles Then
            Application.EnableVisualStyles()
        End If

        ' Muestro el SplashScreen y cambio el puntero del mouse para indicar que la aplicación está iniciando.
        formSplashScreen.Show()
        formSplashScreen.Cursor = Cursors.AppStarting
        formSplashScreen.labelStatus.Text = "Obteniendo los parámetros de conexión a la Base de datos..."
        Application.DoEvents()

        formSplashScreen.Focus()

        ' Obtengo el Connection String para las conexiones de ADO .NET
        pDatabase = New CardonerSistemas.Database.ADO.SQLServer
        pDatabase.ApplicationName = My.Application.Info.Title
        pDatabase.Datasource = pDatabaseConfig.Datasource
        pDatabase.InitialCatalog = pDatabaseConfig.Database
        pDatabase.UserId = pDatabaseConfig.UserId
        ' Desencripto la contraseña de la conexión a la base de datos que está en el archivo app.config
        Dim PasswordDecrypter As New CS_Encrypt_TripleDES(CardonerSistemas.Constants.PUBLIC_ENCRYPTION_PASSWORD)
        Dim DecryptedPassword As String = ""
        If Not PasswordDecrypter.Decrypt(pDatabaseConfig.Password, DecryptedPassword) Then
            MsgBox("La contraseña de conexión a la base de datos es incorrecta.", MsgBoxStyle.Critical, My.Application.Info.Title)
            formSplashScreen.Close()
            formSplashScreen.Dispose()
            TerminateApplication()
            Exit Sub
        End If
        pDatabase.Password = DecryptedPassword
        PasswordDecrypter = Nothing
        pDatabase.MultipleActiveResultsets = True
        pDatabase.WorkstationID = My.Computer.Name
        pDatabase.CreateConnectionString()

        formSplashScreen.Focus()

        ' Obtengo el Connection String para las conexiones de Entity Framework
        CSColegioContext.CreateConnectionString(pDatabaseConfig.Provider, pDatabase.ConnectionString)

        ' Cargos los Parámetros desde la Base de datos
        formSplashScreen.labelStatus.Text = "Cargando los parámetros desde la Base de datos..."
        Application.DoEvents()
        If Not Parametros.LoadParameters() Then
            formSplashScreen.Close()
            formSplashScreen.Dispose()
            TerminateApplication()
            Exit Sub
        End If

        ' Verifico que la Base de Datos corresponda a esta Aplicación a través del GUID guardado en los Parámetros
        If CS_Parameter_System.GetString(Parametros.APPLICATION_DATABASE_GUID) <> Constantes.APPLICATION_DATABASE_GUID Then
            MsgBox("La Base de Datos especificada no corresponde a esta aplicación.", MsgBoxStyle.Critical, My.Application.Info.Title)
            formSplashScreen.Close()
            formSplashScreen.Dispose()
            TerminateApplication()
            Exit Sub
        End If

        formSplashScreen.Focus()

        ' Muestro el Nombre de la Compañía a la que está licenciada la Aplicación
        Dim LicenseDecrypter As New CS_Encrypt_TripleDES(APPLICATION_LICENSE_PASSWORD)
        Dim DecryptedLicense As String = ""
        If Not LicenseDecrypter.Decrypt(CS_Parameter_System.GetString(Parametros.LICENSE_COMPANY_NAME, "EMPTY"), DecryptedLicense) Then
            MsgBox("La Licencia especificada no es válida.", MsgBoxStyle.Critical, My.Application.Info.Title)
            formSplashScreen.Close()
            formSplashScreen.Dispose()
            TerminateApplication()
            Exit Sub
        End If
        pLicensedTo = DecryptedLicense
        LicenseDecrypter = Nothing
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

        pFormMDIMain.Cursor = Cursors.AppStarting
        pFormMDIMain.Enabled = False

        formSplashScreen.labelStatus.Text = "Todo completado."
        Application.DoEvents()

        ' Espero el tiempo mínimo para mostrar el Splash Screen y después lo cierro
        If Not CS_Instance.IsRunningUnderIDE Then
            Do While Now.Subtract(StartupTime).Seconds < pAppearanceConfig.MinimumSplashScreenDisplaySeconds
                Application.DoEvents()
            Loop
        End If
        formSplashScreen.Close()
        formSplashScreen.Dispose()

        If CS_Instance.IsRunningUnderIDE Then
            ' Como se está ejecutando dentro del IDE de Visual Studio, en lugar de pedir Usuario y contraseña, asumo que es el Administrador
            Using dbcontext As New CSColegioContext(True)
                pUsuario = dbcontext.Usuario.Find(1)
                Appearance.UserLoggedIn()
            End Using
        Else
            If Not formLogin.ShowDialog(pFormMDIMain) = DialogResult.OK Then
                Application.Exit()
                My.Application.Log.WriteEntry("La Aplicación ha finalizado porque el Usuario no ha iniciado sesión.", TraceEventType.Warning)
                Exit Sub
            End If
            formLogin.Close()
            formLogin.Dispose()
        End If

        ' Está todo listo. Cambio el puntero del mouse a modo normal y habilito el form MDI principal
        pFormMDIMain.Cursor = Cursors.Default
        pFormMDIMain.Enabled = True

        System.Windows.Forms.Cursor.Current = Cursors.Default

        ' Inicio el loop sobre el form MDI principal
        My.Application.Log.WriteEntry("La Aplicación se ha iniciado correctamente.", TraceEventType.Information)
        Application.Run(pFormMDIMain)
    End Sub

    Friend Sub TerminateApplication()
        If Not pFormMDIMain Is Nothing Then
            For Each formCurrent As Form In pFormMDIMain.MdiChildren()
                formCurrent.Close()
                formCurrent.Dispose()
            Next
        End If
        pDatabase = Nothing

        pAfipWebServicesConfig = Nothing
        pAppearanceConfig = Nothing
        pComprobanteConfig = Nothing
        pDatabaseConfig = Nothing
        pEmailConfig = Nothing
        pGeneralConfig = Nothing
        pOutlookContactsSyncConfig = Nothing
        pSantanderConfig = Nothing

        pFillAndRefreshLists = Nothing
        pPermisos = Nothing
        pParametros = Nothing
        pLicensedTo = Nothing
        pUsuario = Nothing
    End Sub
End Module
