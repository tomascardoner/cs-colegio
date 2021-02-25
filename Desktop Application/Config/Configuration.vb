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
        Dim ConfigFolder As String

        ConfigFolder = Path.Combine(Application.StartupPath, ConfigSubFolder)

        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, AfipWebServicesFileName, pAfipWebServicesConfig) Then
            Return False
        End If

        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, AppearanceFileName, pAppearanceConfig) Then
            Return False
        End If

        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, ComprobanteFileName, pComprobanteConfig) Then
            Return False
        End If
        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, DatabaseFileName, pDatabaseConfig) Then
            Return False
        End If
        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, EmailFileName, pEmailConfig) Then
            Return False
        End If
        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, GeneralFileName, pGeneralConfig) Then
            Return False
        End If
        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, OutlookContactsSyncFileName, pOutlookContactsSyncConfig) Then
            Return False
        End If
        If Not CardonerSistemas.ConfigurationJson.LoadFile(ConfigFolder, SantanderFileName, pSantanderConfig) Then
            Return False
        End If
        pGeneralConfig.ReportsPath = CardonerSistemas.Files.ProcessFolderName(pGeneralConfig.ReportsPath)

        Return True
    End Function

End Module
