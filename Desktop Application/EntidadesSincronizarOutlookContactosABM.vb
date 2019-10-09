Imports Microsoft.Office.Interop

Module EntidadesSincronizarOutlookContactosABM
    Friend Function CrearContacto(ByRef OutlookApplication As Outlook.Application, ByRef OutlookContactItem As Outlook.ContactItem, ByVal IDEntidad As Integer) As Boolean
        Try
            OutlookContactItem = CType(OutlookApplication.CreateItem(Outlook.OlItemType.olContactItem), Outlook.ContactItem)
            If OutlookContactItem Is Nothing Then
                Return False
            Else
                OutlookContactItem.UserProperties.Add(OUTLOOK_USERPROPERTYNAME_CONTACTO_ENTIDAD, Outlook.OlUserPropertyType.olInteger).Value = IDEntidad
                Debug.Print(String.Format("Outlook Sync - Contacts - Add - IDEntidad: {0}", IDEntidad))
                Return True
            End If

        Catch ex As Exception
            OutlookContactItem = Nothing
            CardonerSistemas.ErrorHandler.ProcessError(ex, String.Format("Error al crear el Contacto en Microsoft Outlook (IDEntidad: {0}).", IDEntidad))
            Return False
        End Try
    End Function

    Friend Function ActualizarContacto(ByRef OutlookContactItem As Outlook.ContactItem, ByRef EntidadActual As Entidad) As Boolean
        Dim ContactoOutlookActualizado As Boolean = False
        Dim OutlookUserProperty As Outlook.UserProperty

        Try
            With OutlookContactItem
                If .LastName <> EntidadActual.Apellido Then
                    .LastName = EntidadActual.Apellido
                    ContactoOutlookActualizado = True
                End If
                If .FirstName <> EntidadActual.Nombre Then
                    .FirstName = EntidadActual.Nombre
                    ContactoOutlookActualizado = True
                End If
                If .FileAs <> EntidadActual.ApellidoNombre Then
                    .FileAs = EntidadActual.ApellidoNombre
                    ContactoOutlookActualizado = True
                End If

                If .Email1Address <> EntidadActual.Email1 Then
                    .Email1Address = EntidadActual.Email1
                    SetDisplayNameOfEmail1(OutlookContactItem, EntidadActual)
                    ContactoOutlookActualizado = True
                End If

                If .Email2Address <> EntidadActual.Email2 Then
                    .Email2Address = EntidadActual.Email2
                    SetDisplayNameOfEmail2(OutlookContactItem, EntidadActual)
                    ContactoOutlookActualizado = True
                End If

                If EntidadActual.FechaNacimiento Is Nothing Then
                    If .Birthday <> CS_Office_Outlook_EarlyBinding.CONTACT_DATE_EMPTYVALUE Then
                        .Birthday = CS_Office_Outlook_EarlyBinding.CONTACT_DATE_EMPTYVALUE
                        ContactoOutlookActualizado = True
                    End If
                ElseIf .Birthday <> EntidadActual.FechaNacimiento Then
                    .Birthday = EntidadActual.FechaNacimiento.Value
                    ContactoOutlookActualizado = True
                End If

                If ContactoOutlookActualizado Then
                    Debug.Print(String.Format("Outlook Sync - Contacts - Update - {0}", EntidadActual.ApellidoNombre))
                    .Save()
                End If
            End With
            OutlookUserProperty = Nothing
            Return True

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, String.Format("Error al actualizar el Contacto ({0}) en Microsoft Outlook.", EntidadActual.ApellidoNombre))
            Return False
        End Try
    End Function

    Friend Function BorrarContacto(ByRef OutlookContactItem As Outlook.ContactItem, ByVal DebugMessageReason As String) As Boolean
        Try
            Debug.Print(String.Format("Outlook Sync - Contacts - Delete - {0}: {1}", DebugMessageReason, OutlookContactItem.FullName))
            OutlookContactItem.Delete()
            Return True

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, String.Format("Error al borrar el Contacto ({0}) en Microsoft Outlook.", OutlookContactItem.FullName))
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Establece el valor de la propiedad DisplayName del Email1 en Outlook
    ''' </summary>
    ''' <param name="OutlookContactItem"></param>
    ''' <param name="EntidadActual"></param>
    ''' <remarks></remarks>
    Private Sub SetDisplayNameOfEmail1(ByRef OutlookContactItem As Outlook.ContactItem, ByRef EntidadActual As Entidad)
        If EntidadActual.Email1 Is Nothing Then
            OutlookContactItem.Email1DisplayName = Nothing
        Else
            If EntidadActual.Email2 Is Nothing Then
                OutlookContactItem.Email1DisplayName = OutlookContactItem.LastNameAndFirstName
            Else
                OutlookContactItem.Email1DisplayName = OutlookContactItem.LastNameAndFirstName & " (" & OutlookContactItem.Email1Address & ")"
            End If
        End If
    End Sub

    ''' <summary>
    ''' Establece el valor de la propiedad DisplayName del Email2 en Outlook
    ''' </summary>
    ''' <param name="OutlookContactItem"></param>
    ''' <param name="EntidadActual"></param>
    ''' <remarks></remarks>
    Private Sub SetDisplayNameOfEmail2(ByRef OutlookContactItem As Outlook.ContactItem, ByRef EntidadActual As Entidad)
        If EntidadActual.Email2 Is Nothing Then
            OutlookContactItem.Email2DisplayName = Nothing
        Else
            If EntidadActual.Email1 Is Nothing Then
                OutlookContactItem.Email2DisplayName = OutlookContactItem.LastNameAndFirstName
            Else
                OutlookContactItem.Email2DisplayName = OutlookContactItem.LastNameAndFirstName & " (" & OutlookContactItem.Email1Address & ")"
            End If
        End If
    End Sub
End Module
