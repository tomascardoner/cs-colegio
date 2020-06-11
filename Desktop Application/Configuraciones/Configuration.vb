Imports System.IO

Module Configuration
    Private Const EmailConfigFileName As String = "Email.config"

    Friend Function LoadFiles() As Boolean
        If Not LoadEmailFile() Then
            Return False
        End If

        Return True
    End Function

    Private Function CheckFileExist(ByVal fileName As String) As Boolean
        Dim filePathAndName As String

        filePathAndName = My.Application.Info.DirectoryPath & IIf(My.Application.Info.DirectoryPath.EndsWith("\"), "", "\").ToString() & fileName
        If File.Exists(filePathAndName) Then
            Return True
        Else
            MsgBox(String.Format("No se encontró el archivo de configuración '{0}'. Debe estar ubicado en la misma ubicación que el archivo ejecutable (.exe) de la aplicación.", fileName), MsgBoxStyle.Critical, My.Application.Info.Title)
            Return False
        End If
    End Function

    Private Function LoadEmailFile() As Boolean
        Dim filePathAndName As String
        Dim serializer As Serializer = New Serializer()
        Dim inputText As String

        If Not CheckFileExist(EmailConfigFileName) Then
            Return False
        End If

        filePathAndName = My.Application.Info.DirectoryPath & IIf(My.Application.Info.DirectoryPath.EndsWith("\"), "", "\").ToString() & EmailConfigFileName
        Try
            inputText = File.ReadAllText(filePathAndName)
            pEmailConfig = serializer.Deserialize(Of EmailConfig)(inputText)
            Return True

        Catch ex As Exception
            CardonerSistemas.ProcessError(ex, String.Format("Error al cargar el archivo de configuración '{0}'.", EmailConfigFileName))
            Return False
        End Try
    End Function

End Module
