Imports Microsoft.Office.Interop

Module EntidadesSincronizarOutlookGruposABM
    Friend Function CrearGrupo(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByVal UserPropertyName As String, ByVal UserPropertyValue As String) As Boolean
        Return CrearGrupoInterno(OutlookApplication, OutlookDistListItem, UserPropertyName, Outlook.OlUserPropertyType.olText, UserPropertyValue)
    End Function

    Friend Function CrearGrupo(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByVal UserPropertyName As String, ByVal UserPropertyValue As Integer) As Boolean
        Return CrearGrupoInterno(OutlookApplication, OutlookDistListItem, UserPropertyName, Outlook.OlUserPropertyType.olInteger, UserPropertyValue)
    End Function

    Private Function CrearGrupoInterno(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByVal UserPropertyName As String, ByVal UserPropertyType As Outlook.OlUserPropertyType, ByVal UserPropertyValue As Object) As Boolean
        Try
            OutlookDistListItem = CType(OutlookApplication.CreateItem(Outlook.OlItemType.olDistributionListItem), Outlook.DistListItem)
            If OutlookDistListItem Is Nothing Then
                Return False
            Else
                OutlookDistListItem.UserProperties.Add(UserPropertyName, UserPropertyType).Value = UserPropertyValue
                Debug.Print("Outlook Sync - Contacts Group - Add")
                Return True
            End If

        Catch ex As Exception
            OutlookDistListItem = Nothing
            CS_Error.ProcessError(ex, "Error al crear el Grupo de Contactos en Microsoft Outlook.")
            Return False
        End Try
    End Function

    Friend Function ActualizarGrupo(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByVal GrupoNombre As String, ByRef Entidades As List(Of Entidad), ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim GrupoOutlookActualizado As Boolean = False

        Try
            With OutlookDistListItem
                If .DLName <> GrupoNombre Then
                    .DLName = GrupoNombre
                    GrupoOutlookActualizado = True
                End If

                If GrupoOutlookActualizado Then
                    Debug.Print(String.Format("Outlook Sync - Contacts Group - Update - {0}", GrupoNombre))
                    .Save()
                End If

                If Not EntidadesSincronizarOutlookGruposMiembros.VerificarMiembros(OutlookApplication, OutlookDistListItem, Entidades, ProgressBarProgreso) Then
                    Return False
                End If
            End With
            Return True

        Catch ex As Exception
            CS_Error.ProcessError(ex, String.Format("Error al actualizar el Grupo de Contactos ({0}) en Microsoft Outlook.", GrupoNombre))
            Return False
        End Try
    End Function

    Friend Function BorrarGrupo(ByRef OutlookDistListItem As Outlook.DistListItem, ByVal DebugMessageReason As String) As Boolean
        Try
            Debug.Print(String.Format("Outlook Sync - Contacts Group - Delete - {0}: {1}", DebugMessageReason, OutlookDistListItem.DLName))
            OutlookDistListItem.Delete()
            Return True

        Catch ex As Exception
            CS_Error.ProcessError(ex, String.Format("Error al borrar el Grupo de Contactos ({0}) en Microsoft Outlook.", OutlookDistListItem.DLName))
            Return False
        End Try
    End Function
End Module
