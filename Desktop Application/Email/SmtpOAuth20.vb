Imports Google.Apis.Auth.OAuth2
Imports Google.Apis.Util.Store
Imports System.Threading
Imports MailKit.Net
Imports Google.Apis.Auth.OAuth2.Responses
Imports Google.Apis.Auth.OAuth2.Flows
Imports System.Text.Json
Imports Microsoft.VisualBasic.ApplicationServices

Namespace Email
    Module SmtpOAuth20

        Private Function ClientSecretsFileLoad(fullPath As String) As GoogleClientSecrets
            Try
                If Not IO.File.Exists(fullPath) Then
                    MessageBox.Show($"No se encontró el archivo de Google Client Secrets en '{fullPath}'.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return Nothing
                End If
                Return GoogleClientSecrets.FromFile(fullPath)
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, $"Error al abrir el archivo de Google Client Secrets desde '{fullPath}'.")
                Return Nothing
            End Try
        End Function

        Private Async Function TokenResponseGetFromFile() As Tasks.Task(Of TokenResponse)
            Dim fileDataStore As FileDataStore

            Try
                fileDataStore = New FileDataStore(My.Application.Info.DirectoryPath, True)
                Return Await fileDataStore.GetAsync(Of TokenResponse)(pEmailConfig.SmtpUserName)
            Catch ex As Exception
                CardonerSistemas.ProcessError(ex, $"Error al leer el archivo local del Token Response de Google.")
                Return Nothing
            End Try
        End Function

        Private Function AuthorizeNew(logPath As String, logFileName As String, secrets As GoogleClientSecrets, ByRef accessToken As String) As Boolean
            Const GoogleScope As String = "https://mail.google.com/"

            Dim scopes As IEnumerable(Of String) = {GoogleScope}
            Dim credential As UserCredential

            Try
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Autorización de Google API: inicio")
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(secrets.Secrets, scopes, pEmailConfig.SmtpUserName, CancellationToken.None, New FileDataStore(My.Application.Info.DirectoryPath, True)).Result
                accessToken = credential.Token.AccessToken
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Autorización de Google API: fin")
                Return True
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al generar la autorización de acceso a GMail.")
                Return False
            End Try
        End Function

        Private Function AuthorizeRefresh(logPath As String, logFileName As String, secrets As GoogleClientSecrets, tokenResponse As TokenResponse, ByRef accessToken As String) As Boolean
            Dim googleInitializer As GoogleAuthorizationCodeFlow.Initializer
            Dim googleAuthorizationCodeFlow As GoogleAuthorizationCodeFlow
            Dim fileDataStore As FileDataStore
            Dim credential As UserCredential

            Try
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Refresh de autorización de Google API: inicio")
                'tokenResponse = New TokenResponse With {.AccessToken = accessToken, .RefreshToken = refreshToken}
                'googleInitializer = New GoogleAuthorizationCodeFlow.Initializer With {.DataStore = New FileDataStore(My.Application.Info.DirectoryPath, True), .ClientSecrets = secrets.Secrets}
                'googleAuthorizationCodeFlow = New GoogleAuthorizationCodeFlow(googleInitializer)

                credential = New UserCredential(googleAuthorizationCodeFlow, pEmailConfig.SmtpUserName, tokenResponse)
                accessToken = credential.Token.AccessToken
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Refresh de autorización de Google API: fin")
                Return True
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al renovar la autorización de acceso a GMail.")
                Return False
            End Try
        End Function

        Friend Function Authorize(logPath As String, logFileName As String, ByRef accessToken As String) As Boolean
            Dim tokenResponse As TokenResponse
            Dim secrets As GoogleClientSecrets

            ' Leo el archivo de Google Client Secrets
            secrets = ClientSecretsFileLoad(pEmailConfig.GoogleApiSecretFile)
            If secrets Is Nothing Then
                Return False
            End If

            ' Leo el token si existe
            tokenResponse = TokenResponseGetFromFile().Result
            accessToken = tokenResponse?.AccessToken

            If tokenResponse Is Nothing Then
                Return AuthorizeNew(logPath, logFileName, secrets, accessToken)
            ElseIf DateDiff(DateInterval.Second, DateTime.UtcNow, tokenResponse.IssuedUtc.AddSeconds(CType(tokenResponse.ExpiresInSeconds, Double))) < 0 Then
                Return AuthorizeRefresh(logPath, logFileName, secrets, tokenResponse, accessToken)
            Else
                accessToken = tokenResponse.RefreshToken
                Return True
            End If
        End Function

        Friend Function Connect(logPath As String, logFileName As String, smtpClient As Smtp.SmtpClient) As Boolean
            Try
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Conexión al servidor SMTP: inicio")
                smtpClient.Connect(pEmailConfig.SmtpServer, pEmailConfig.SmtpPort, True)
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Conexión al servidor SMTP: fin")
                Return True
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al conectar al servidor SMTP.")
                Return False
            End Try
        End Function

        Friend Function Authenticate(logPath As String, logFileName As String, smtpClient As Smtp.SmtpClient, accessToken As String) As Boolean
            Dim oauth2 As MailKit.Security.SaslMechanismOAuth2

            Try
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Autenticación al servidor SMTP: inicio")
                oauth2 = New MailKit.Security.SaslMechanismOAuth2(pEmailConfig.SmtpUserName, accessToken)
                smtpClient.Authenticate(oauth2)
                CS_FileLog.WriteLine(pEmailConfig.LogEnabled, logPath, logFileName, LogEntryType.Information, "Autenticación al servidor SMTP: fin")

                Return True
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al autenticar la conexión al servidor SMTP.")
                Return False
            End Try
        End Function
    End Module
End Namespace