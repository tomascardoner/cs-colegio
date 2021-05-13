Module Database
    Friend Function ObtenerParametrosDeConexion() As Boolean
        Dim dataSourceIndex As Integer

        ' Si hay más de un Datasource especificado, muestro la ventana de selección
        If pDatabaseConfig.Datasource.Contains(CardonerSistemas.Constants.STRING_LIST_SEPARATOR) Then
            CS_Database_SelectSource.comboboxDataSource.Items.AddRange(pDatabaseConfig.Datasource.Split(CChar(CardonerSistemas.Constants.STRING_LIST_SEPARATOR)))
            If Not CS_Database_SelectSource.ShowDialog(formSplashScreen) = DialogResult.OK Then
                My.Application.Log.WriteEntry("La Aplicación ha finalizado porque el Usuario no ha seleccionado el origen de los datos.", TraceEventType.Warning)
                Return False
            End If
            dataSourceIndex = CS_Database_SelectSource.comboboxDataSource.SelectedIndex
            CS_Database_SelectSource.Close()
            CS_Database_SelectSource.Dispose()
        Else
            dataSourceIndex = -1
        End If

        ' Obtengo el Connection String para las conexiones de ADO .NET
        pDatabase = New CardonerSistemas.Database.ADO.SQLServer
        pDatabase.ApplicationName = My.Application.Info.Title
        If dataSourceIndex > -1 Then
            pDatabase.Datasource = pDatabaseConfig.Datasource.Split(CChar(CardonerSistemas.Constants.STRING_LIST_SEPARATOR)).ElementAt(dataSourceIndex)
            ' Database
            If pDatabaseConfig.Database.Contains(CardonerSistemas.Constants.STRING_LIST_SEPARATOR) Then
                Dim aDatabase() As String
                aDatabase = pDatabaseConfig.Database.Split(CChar(CardonerSistemas.Constants.STRING_LIST_SEPARATOR))
                If aDatabase.GetUpperBound(0) >= dataSourceIndex Then
                    pDatabase.InitialCatalog = aDatabase(dataSourceIndex)
                Else
                    pDatabase.InitialCatalog = ""
                End If
                aDatabase = Nothing
            Else
                pDatabase.InitialCatalog = pDatabaseConfig.Database
            End If
            ' UserID
            If pDatabaseConfig.UserId.Contains(CardonerSistemas.Constants.STRING_LIST_SEPARATOR) Then
                Dim aUserID() As String
                aUserID = pDatabaseConfig.UserId.Split(CChar(CardonerSistemas.Constants.STRING_LIST_SEPARATOR))
                If aUserID.GetUpperBound(0) >= dataSourceIndex Then
                    pDatabase.UserId = aUserID(dataSourceIndex)
                Else
                    pDatabase.UserId = ""
                End If
                aUserID = Nothing
            Else
                pDatabase.UserId = pDatabaseConfig.UserId
            End If
            ' Password
            Dim PasswordEncrypted As String
            If pDatabaseConfig.Password.Contains(CardonerSistemas.Constants.STRING_LIST_SEPARATOR) Then
                Dim aPassword() As String
                aPassword = pDatabaseConfig.Password.Split(CChar(CardonerSistemas.Constants.STRING_LIST_SEPARATOR))
                If aPassword.GetUpperBound(0) >= dataSourceIndex Then
                    PasswordEncrypted = aPassword(dataSourceIndex)
                Else
                    PasswordEncrypted = ""
                End If
                aPassword = Nothing
            Else
                PasswordEncrypted = pDatabaseConfig.Password
            End If
            ' Desencripto la contraseña de la conexión a la base de datos que está en el archivo app.config
            If PasswordEncrypted.Length > 0 Then
                Dim PasswordDecrypter As New CS_Encrypt_TripleDES(CardonerSistemas.Constants.PublicEncryptionPassword)
                Dim DecryptedPassword As String = ""
                If Not PasswordDecrypter.Decrypt(PasswordEncrypted, DecryptedPassword) Then
                    MsgBox("La contraseña de conexión a la base de datos es incorrecta.", MsgBoxStyle.Critical, My.Application.Info.Title)
                    PasswordDecrypter = Nothing
                    Return False
                End If
                pDatabase.Password = DecryptedPassword
                PasswordDecrypter = Nothing
            Else
                pDatabase.Password = ""
            End If
            PasswordEncrypted = Nothing
        Else
            pDatabase.Datasource = pDatabaseConfig.Datasource
            pDatabase.InitialCatalog = pDatabaseConfig.Database
            pDatabase.UserId = pDatabaseConfig.UserId
            ' Desencripto la contraseña de la conexión a la base de datos que está en el archivo app.config
            Dim PasswordDecrypter As New CS_Encrypt_TripleDES(CardonerSistemas.Constants.PublicEncryptionPassword)
            Dim DecryptedPassword As String = ""
            If Not PasswordDecrypter.Decrypt(pDatabaseConfig.Password, DecryptedPassword) Then
                MsgBox("La contraseña de conexión a la base de datos es incorrecta.", MsgBoxStyle.Critical, My.Application.Info.Title)
                PasswordDecrypter = Nothing
                Return False
            End If
            pDatabase.Password = DecryptedPassword
            PasswordDecrypter = Nothing
        End If
        pDatabase.MultipleActiveResultsets = True
        pDatabase.WorkstationID = My.Computer.Name
        pDatabase.CreateConnectionString()

        ' Obtengo el Connection String para las conexiones de Entity Framework
        CSColegioContext.ConnectionString = CardonerSistemas.Database.EntityFramework.CreateConnectionString(pDatabaseConfig.Provider, pDatabase.ConnectionString, "CSColegio")

        Return True
    End Function
End Module