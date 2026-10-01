Imports System.IO

Module Configuration
    Private Const ConfigSubFolder As String = "Config"

    Private Const AfipWebServicesFileName As String = "AfipWebServices.json"
    Private Const AppearanceFileName As String = "Appearance.json"
    Private Const ComprobanteFileName As String = "Comprobante.json"
    Private Const DatabaseFileName As String = "Database.json"
    Private Const EmailFileName As String = "Email.json"
    Private Const GeneralFileName As String = "General.json"
    Private Const OutlookContactsSyncFileName As String = "OutlookContactsSync.json"
    Private Const SantanderFileName As String = "Santander.json"

    Friend Function LoadFiles() As Boolean
        Dim decrypter As New CS_Encrypt_TripleDES(CardonerSistemas.Constants.PublicEncryptionPassword)
        Dim decryptedPassword As String = String.Empty
        Dim ConfigFolder As String

        ConfigFolder = Path.Combine(Application.StartupPath, ConfigSubFolder)

        ' AFIP Web Services
        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, AfipWebServicesFileName, pAfipWebServicesConfig) Then
            Return False
        End If
        pAfipWebServicesConfig.Certificado = CardonerSistemas.Files.ProcessFolderName(pAfipWebServicesConfig.Certificado)
        pAfipWebServicesConfig.ClavePrivada = CardonerSistemas.Files.ProcessFolderName(pAfipWebServicesConfig.ClavePrivada)
        Dim dias As Integer = CInt(DateDiff(DateInterval.Day, Now, pAfipWebServicesConfig.CertificadoVencimiento))
        Dim minutos As Integer = CInt(DateDiff(DateInterval.Minute, Now, pAfipWebServicesConfig.CertificadoVencimiento))

        Select Case dias
            Case Is < 0
                MessageBox.Show("El certificado digital de ARCA está vencido.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Case 0 To 1
                Select Case minutos
                    Case Is < 0
                        MessageBox.Show("El certificado digital de ARCA está vencido.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Case 0 To 1439
                        MessageBox.Show("ATENCIÓN: ¡¡El certificado digital de ARCA vence en unas horas!!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Case Else
                        MessageBox.Show("ATENCIÓN: ¡¡El certificado digital de ARCA vence mañana!!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End Select
            Case 2 To 10
                MessageBox.Show("El certificado digital de ARCA vence en " & dias.ToString() & " días.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Case 11 To 20
                MessageBox.Show("El certificado digital de ARCA vence en " & dias.ToString() & " días.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Select

        ' Appearance
        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, AppearanceFileName, pAppearanceConfig) Then
            Return False
        End If

        ' Comprobante
        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, ComprobanteFileName, pComprobanteConfig) Then
            Return False
        End If

        ' Database
        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, DatabaseFileName, pDatabaseConfig) Then
            Return False
        End If

        ' E-mail
        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, EmailFileName, pEmailConfig) Then
            Return False
        End If
        If decrypter.Decrypt(pEmailConfig.SmtpPassword, decryptedPassword) Then
            pEmailConfig.SmtpPassword = decryptedPassword
        Else
            MessageBox.Show("La contraseña de e-mail (SMTP) especificada es incorrecta.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
        decrypter = Nothing
        pEmailConfig.GoogleApiSecretFile = CardonerSistemas.Files.ProcessFolderName(pEmailConfig.GoogleApiSecretFile)

        ' General
        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, GeneralFileName, pGeneralConfig) Then
            Return False
        End If
        pGeneralConfig.ReportsPath = CardonerSistemas.Files.ProcessFolderName(pGeneralConfig.ReportsPath)
        pGeneralConfig.ExchangeOutboundFolder = CardonerSistemas.Files.ProcessFolderName(pGeneralConfig.ExchangeOutboundFolder)

        ' Outlook Sync
        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, OutlookContactsSyncFileName, pOutlookContactsSyncConfig) Then
            Return False
        End If

        ' Banco Santander
        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, SantanderFileName, pSantanderConfig) Then
            Return False
        End If
        pSantanderConfig.AddiOutboundFolder = CardonerSistemas.Files.ProcessFolderName(pSantanderConfig.AddiOutboundFolder)
        pSantanderConfig.AddiInboundFolder = CardonerSistemas.Files.ProcessFolderName(pSantanderConfig.AddiInboundFolder)
        pSantanderConfig.PirypOutboundFolder = CardonerSistemas.Files.ProcessFolderName(pSantanderConfig.PirypOutboundFolder)

        Return True
    End Function

    Friend Function SaveFileDatabase() As Boolean
        Dim ConfigFolder As String

        ConfigFolder = Path.Combine(Application.StartupPath, ConfigSubFolder)

        Return CardonerSistemas.ConfigurationJson.SaveFile(ConfigFolder, DatabaseFileName, StartUp.pDatabaseConfig, True)
    End Function

End Module
