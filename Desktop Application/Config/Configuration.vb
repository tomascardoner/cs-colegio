Imports System.IO

Module Configuration
    Private Const ConfigSubFolder As String = "Config"

    Private Const AfipWebServicesFileName As String = "AfipWebServices.config"
    Private Const ComprobanteFileName As String = "Comprobante.config"
    Private Const DatabaseFileName As String = "Database.config"
    Private Const EmailFileName As String = "Email.config"
    Private Const OutlookContactsSyncFileName As String = "OutlookContactsSync.config"
    Private Const SantanderFileName As String = "Santander.config"

    Friend Function LoadFiles() As Boolean
        Dim ConfigFolder As String

        ConfigFolder = My.Application.Info.DirectoryPath & IIf(My.Application.Info.DirectoryPath.EndsWith("\"), "", "\").ToString() & ConfigSubFolder & "\"

        If Not LoadAfipWebServicesFile(ConfigFolder) Then
            Return False
        End If
        If Not LoadComprobanteFile(ConfigFolder) Then
            Return False
        End If
        If Not LoadDatabaseFile(ConfigFolder) Then
            Return False
        End If
        If Not LoadEmailFile(ConfigFolder) Then
            Return False
        End If
        If Not LoadOutlookContactsSyncFile(ConfigFolder) Then
            Return False
        End If
        If Not LoadSantanderFile(ConfigFolder) Then
            Return False
        End If

        Return True
    End Function

    Private Function CheckFileExist(ByVal configFolder As String, ByVal fileName As String) As Boolean
        If File.Exists(configFolder & fileName) Then
            Return True
        Else
            MsgBox(String.Format("No se encontró el archivo de configuración '{1}'. Debe estar ubicado en la carpeta '{0}' ubicada en la misma ubicación que el archivo ejecutable (.exe) de la aplicación.", ConfigSubFolder, fileName), MsgBoxStyle.Critical, My.Application.Info.Title)
            Return False
        End If
    End Function

    Private Function LoadAfipWebServicesFile(ByVal configFolder As String) As Boolean
        Dim serializer As Serializer = New Serializer()
        Dim inputText As String

        If Not CheckFileExist(configFolder, AfipWebServicesFileName) Then
            Return False
        End If

        Try
            inputText = File.ReadAllText(configFolder & AfipWebServicesFileName)
            pAfipWebServicesConfig = serializer.Deserialize(Of AfipWebServicesConfig)(inputText)
            serializer = Nothing
            Return True

        Catch ex As Exception
            CardonerSistemas.ProcessError(ex, String.Format("Error al cargar el archivo de configuración '{0}'.", AfipWebServicesFileName))
            serializer = Nothing
            Return False
        End Try
    End Function

    Private Function LoadComprobanteFile(ByVal configFolder As String) As Boolean
        Dim serializer As Serializer = New Serializer()
        Dim inputText As String

        If Not CheckFileExist(configFolder, ComprobanteFileName) Then
            Return False
        End If

        Try
            inputText = File.ReadAllText(configFolder & ComprobanteFileName)
            pComprobanteConfig = serializer.Deserialize(Of ComprobanteConfig)(inputText)
            serializer = Nothing
            Return True

        Catch ex As Exception
            CardonerSistemas.ProcessError(ex, String.Format("Error al cargar el archivo de configuración '{0}'.", ComprobanteFileName))
            serializer = Nothing
            Return False
        End Try
    End Function

    Private Function LoadDatabaseFile(ByVal configFolder As String) As Boolean
        Dim serializer As Serializer = New Serializer()
        Dim inputText As String

        If Not CheckFileExist(configFolder, DatabaseFileName) Then
            Return False
        End If

        Try
            inputText = File.ReadAllText(configFolder & DatabaseFileName)
            pDatabaseConfig = serializer.Deserialize(Of DatabaseConfig)(inputText)
            serializer = Nothing
            Return True

        Catch ex As Exception
            CardonerSistemas.ProcessError(ex, String.Format("Error al cargar el archivo de configuración '{0}'.", DatabaseFileName))
            serializer = Nothing
            Return False
        End Try
    End Function

    Private Function LoadEmailFile(ByVal configFolder As String) As Boolean
        Dim serializer As Serializer = New Serializer()
        Dim inputText As String

        If Not CheckFileExist(configFolder, EmailFileName) Then
            Return False
        End If

        Try
            inputText = File.ReadAllText(configFolder & EmailFileName)
            pEmailConfig = serializer.Deserialize(Of EmailConfig)(inputText)
            serializer = Nothing
            Return True

        Catch ex As Exception
            CardonerSistemas.ProcessError(ex, String.Format("Error al cargar el archivo de configuración '{0}'.", EmailFileName))
            serializer = Nothing
            Return False
        End Try
    End Function

    Private Function LoadOutlookContactsSyncFile(ByVal configFolder As String) As Boolean
        Dim serializer As Serializer = New Serializer()
        Dim inputText As String

        If Not CheckFileExist(configFolder, OutlookContactsSyncFileName) Then
            Return False
        End If

        Try
            inputText = File.ReadAllText(configFolder & OutlookContactsSyncFileName)
            pOutlookContactsSyncConfig = serializer.Deserialize(Of OutlookContactsSyncConfig)(inputText)
            serializer = Nothing
            Return True

        Catch ex As Exception
            CardonerSistemas.ProcessError(ex, String.Format("Error al cargar el archivo de configuración '{0}'.", OutlookContactsSyncFileName))
            serializer = Nothing
            Return False
        End Try
    End Function

    Private Function LoadSantanderFile(ByVal configFolder As String) As Boolean
        Dim serializer As Serializer = New Serializer()
        Dim inputText As String

        If Not CheckFileExist(configFolder, SantanderFileName) Then
            Return False
        End If

        Try
            inputText = File.ReadAllText(configFolder & SantanderFileName)
            pSantanderConfig = serializer.Deserialize(Of SantanderConfig)(inputText)
            serializer = Nothing
            Return True

        Catch ex As Exception
            CardonerSistemas.ProcessError(ex, String.Format("Error al cargar el archivo de configuración '{0}'.", SantanderFileName))
            serializer = Nothing
            Return False
        End Try
    End Function

    Private Function SaveEmailFile(ByVal configFolder As String) As Boolean
        Dim serializer As Serializer = New Serializer()
        Dim oututText As String

        Try
            oututText = serializer.Serialize(Of EmailConfig)(pEmailConfig)
            serializer = Nothing
            Return True

        Catch ex As Exception
            CardonerSistemas.ProcessError(ex, String.Format("Error al guardar el archivo de configuración '{0}'.", EmailFileName))
            serializer = Nothing
            Return False
        End Try

    End Function

End Module
