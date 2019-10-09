Imports Microsoft.Office.Interop

Module EntidadesSincronizarOutlookGruposABM
    Friend Function CrearGrupoDeTipoDeEntidad(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByVal EntidadTipo As String) As Boolean
        Try
            OutlookDistListItem = CType(OutlookApplication.CreateItem(Outlook.OlItemType.olDistributionListItem), Outlook.DistListItem)
            If OutlookDistListItem Is Nothing Then
                Return False
            Else
                OutlookDistListItem.UserProperties.Add(Constantes.OUTLOOK_USERPROPERTYNAME_GRUPO_TIPO, Outlook.OlUserPropertyType.olText).Value = EntidadTipo
                Debug.Print("Outlook Sync - Contacts Group - Add")
                Return True
            End If

        Catch ex As Exception
            OutlookDistListItem = Nothing
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al crear el Grupo de Contactos de Tipo de Entidad en Microsoft Outlook.")
            Return False
        End Try
    End Function

    Friend Function CrearGrupoDeNivel(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByVal AnioLectivo As Short, ByVal IDNivel As Byte) As Boolean
        Try
            OutlookDistListItem = CType(OutlookApplication.CreateItem(Outlook.OlItemType.olDistributionListItem), Outlook.DistListItem)
            If OutlookDistListItem Is Nothing Then
                Return False
            Else
                OutlookDistListItem.UserProperties.Add(Constantes.OUTLOOK_USERPROPERTYNAME_GRUPO_ANIOLECTIVO, Outlook.OlUserPropertyType.olInteger).Value = AnioLectivo
                OutlookDistListItem.UserProperties.Add(Constantes.OUTLOOK_USERPROPERTYNAME_GRUPO_NIVEL, Outlook.OlUserPropertyType.olInteger).Value = IDNivel
                Debug.Print("Outlook Sync - Contacts Group - Add")
                Return True
            End If

        Catch ex As Exception
            OutlookDistListItem = Nothing
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al crear el Grupo de Contactos de Nivel en Microsoft Outlook.")
            Return False
        End Try
    End Function

    Friend Function CrearGrupoDeCurso(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByVal AnioLectivo As Short, ByVal IDCurso As Byte) As Boolean
        Try
            OutlookDistListItem = CType(OutlookApplication.CreateItem(Outlook.OlItemType.olDistributionListItem), Outlook.DistListItem)
            If OutlookDistListItem Is Nothing Then
                Return False
            Else
                OutlookDistListItem.UserProperties.Add(Constantes.OUTLOOK_USERPROPERTYNAME_GRUPO_ANIOLECTIVO, Outlook.OlUserPropertyType.olInteger).Value = AnioLectivo
                OutlookDistListItem.UserProperties.Add(Constantes.OUTLOOK_USERPROPERTYNAME_GRUPO_CURSO, Outlook.OlUserPropertyType.olInteger).Value = IDCurso
                Debug.Print("Outlook Sync - Contacts Group - Add")
                Return True
            End If

        Catch ex As Exception
            OutlookDistListItem = Nothing
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al crear el Grupo de Contactos de Curso en Microsoft Outlook.")
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
            CardonerSistemas.ErrorHandler.ProcessError(ex, String.Format("Error al actualizar el Grupo de Contactos ({0}) en Microsoft Outlook.", GrupoNombre))
            Return False
        End Try
    End Function

    Friend Function BorrarGrupo(ByRef OutlookDistListItem As Outlook.DistListItem, ByVal DebugMessageReason As String) As Boolean
        Try
            Debug.Print(String.Format("Outlook Sync - Contacts Group - Delete - {0}: {1}", DebugMessageReason, OutlookDistListItem.DLName))
            OutlookDistListItem.Delete()
            Return True

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, String.Format("Error al borrar el Grupo de Contactos ({0}) en Microsoft Outlook.", OutlookDistListItem.DLName))
            Return False
        End Try
    End Function
End Module
