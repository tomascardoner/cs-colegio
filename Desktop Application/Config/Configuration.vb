Module Configuration
    Private Const ConfigSubFolder As String = "Config"

    Private Const AfipWebServicesFileName As String = "AfipWebServices.config"
    Private Const AppearanceFileName As String = "Appearance.config"
    Private Const ComprobanteFileName As String = "Comprobante.config"
    Private Const DatabaseFileName As String = "Database.config"
    Private Const EmailFileName As String = "Email.config"
    Private Const GeneralFileName As String = "General.config"
    Private Const OutlookContactsSyncFileName As String = "OutlookContactsSync.config"
    Private Const SantanderFileName As String = "Santander.config"

    Friend Function LoadFiles() As Boolean
        Dim ConfigFolder As String

        ConfigFolder = My.Application.Info.DirectoryPath & IIf(My.Application.Info.DirectoryPath.EndsWith("\"), "", "\").ToString() & ConfigSubFolder & "\"

        If Not CardonerSistemas.Configuration.LoadFile(ConfigFolder, AfipWebServicesFileName, pAfipWebServicesConfig) Then
            Return False
        End If

        ' Appearance
        If Not CardonerSistemas.Configuration.LoadFile(ConfigFolder, AppearanceFileName, pAppearanceConfig) Then
            Return False
        End If

        If Not CardonerSistemas.Configuration.LoadFile(ConfigFolder, ComprobanteFileName, pComprobanteConfig) Then
            Return False
        End If
        If Not CardonerSistemas.Configuration.LoadFile(ConfigFolder, DatabaseFileName, pDatabaseConfig) Then
            Return False
        End If
        If Not CardonerSistemas.Configuration.LoadFile(ConfigFolder, EmailFileName, pEmailConfig) Then
            Return False
        End If
        If Not CardonerSistemas.Configuration.LoadFile(ConfigFolder, GeneralFileName, pGeneralConfig) Then
            Return False
        End If
        If Not CardonerSistemas.Configuration.LoadFile(ConfigFolder, OutlookContactsSyncFileName, pOutlookContactsSyncConfig) Then
            Return False
        End If
        If Not CardonerSistemas.Configuration.LoadFile(ConfigFolder, SantanderFileName, pSantanderConfig) Then
            Return False
        End If

        Return True
    End Function

End Module
