Imports System.IO

Module Configuration
    Private Const ConfigSubFolder As String = "Config"
    Private Const AfipWebServicesFileName As String = "AfipWebServices.config"
    Private Const DatabaseFileName As String = "Database.config"
    Private Const EmailFileName As String = "Email.config"
    Private Const SantanderAddiFileName As String = "SantanderAddi.config"

    Friend Function LoadFiles() As Boolean
        Dim ConfigFolder As String

        ConfigFolder = My.Application.Info.DirectoryPath & IIf(My.Application.Info.DirectoryPath.EndsWith("\"), "", "\").ToString() & ConfigSubFolder & "\"

        If Not LoadAfipWebServicesFile(ConfigFolder) Then
            Return False
        End If
        If Not LoadDatabaseFile(ConfigFolder) Then
            Return False
        End If
        If Not LoadEmailFile(ConfigFolder) Then
            Return False
        End If
        If Not LoadSantanderAddiFile(ConfigFolder) Then
            Return False
        End If

        Return True
    End Function

    Private Function CheckFileExist(ByVal configFolder As String, ByVal fileName As String) As Boolean
        If File.Exists(configFolder & fileName) Then
            Return True
        Else
            MsgBox(String.Format("No se encontró el archivo de configuración '{0}'. Debe estar ubicado en la carpeta '{0}' ubicada en la misma ubicación que el archivo ejecutable (.exe) de la aplicación.", ConfigSubFolder, fileName), MsgBoxStyle.Critical, My.Application.Info.Title)
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

    Private Function LoadSantanderAddiFile(ByVal configFolder As String) As Boolean
        Dim serializer As Serializer = New Serializer()
        Dim inputText As String

        If Not CheckFileExist(configFolder, SantanderAddiFileName) Then
            Return False
        End If

        Try
            inputText = File.ReadAllText(configFolder & SantanderAddiFileName)
            pSantanderAddiConfig = serializer.Deserialize(Of SantanderAddiConfig)(inputText)
            serializer = Nothing
            Return True

        Catch ex As Exception
            CardonerSistemas.ProcessError(ex, String.Format("Error al cargar el archivo de configuración '{0}'.", SantanderAddiFileName))
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
