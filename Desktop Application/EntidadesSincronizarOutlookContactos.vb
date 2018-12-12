Imports Microsoft.Office.Interop

Module EntidadesSincronizarOutlookContactos
    ''' <summary>
    ''' Verifico todos los contactos que hay en el Outlook, comparandolos con su respectiva Entidad
    ''' en la base de datos utilizando el campo de id de usuario especificado en los campos de usuario.
    ''' Actualizando los datos de Outlook que hayan cambiado y borrando los contactos de Outlook que no
    ''' estén en la base de datos
    ''' </summary>
    ''' <param name="OutlookContacts">Contactos de Outlook</param>
    ''' <param name="dbContext">Contexto EF de base de datos</param>
    ''' <param name="EntidadIDVerificados">Lista de IDs de Entidades verificads en Outlook</param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Friend Function VerificarContactosEnOutlook(ByRef OutlookContacts As Outlook.Items, ByRef dbContext As CSColegioContext, ByRef EntidadIDVerificados As List(Of Integer), ByRef Opciones As EntidadesSincronizarOutlookOpciones, ByRef ProgressBarToUpdate As ProgressBar) As Boolean
        Dim ListOfOutlookContactItems As List(Of Outlook.ContactItem)
        Dim OutlookUserProperty As Outlook.UserProperty

        Dim IDEntidad As Integer
        Dim EntidadActual As Entidad
        Dim ContactoOutlookActualizado As Boolean
        Dim ItemIndex As Integer = 0

        Try
            ' Uso una lista estática porque si uso la carpeta de Outlook directamente en el For Each, al borrar o agregar items, pierde la secuencialidad
            ListOfOutlookContactItems = OutlookContacts.OfType(Of Outlook.ContactItem)().ToList

            ProgressBarToUpdate.Value = 0
            ProgressBarToUpdate.Maximum = ListOfOutlookContactItems.Count
            Application.DoEvents()

            For Each OutlookContactItem As Outlook.ContactItem In ListOfOutlookContactItems
                With OutlookContactItem
                    OutlookUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_CONTACTO_ENTIDAD)
                    If Not OutlookUserProperty Is Nothing Then
                        Integer.TryParse(OutlookUserProperty.Value.ToString, IDEntidad)
                        If IDEntidad > 0 Then
                            If EntidadIDVerificados.Contains(IDEntidad) Then
                                ' Ya fue verificado, por lo tanto, está duplicado
                                BorrarContacto(OutlookContactItem, "Outlook Sync - Contacts - Delete - Duplicated: {0}")
                            Else
                                EntidadIDVerificados.Add(IDEntidad)
                                EntidadActual = dbContext.Entidad.Find(IDEntidad)
                                If EntidadActual Is Nothing OrElse EntidadActual.EsActivo = False Then
                                    ' No existe la Entidad en la base de datos o está desactivada
                                    BorrarContacto(OutlookContactItem, "Outlook Sync - Contacts - Delete - Doesn't exists anymore in DB or is inactive: {0}")
                                ElseIf Not ((Opciones.EntidadTipoPersonalColegio And EntidadActual.TipoPersonalColegio) Or (Opciones.EntidadTipoDocente And EntidadActual.TipoDocente) Or (Opciones.EntidadTipoAlumno And EntidadActual.TipoAlumno) Or (Opciones.EntidadTipoFamiliar And EntidadActual.TipoFamiliar) Or (Opciones.EntidadTipoProveedor And EntidadActual.TipoProveedor) Or (Opciones.EntidadTipoOtro And EntidadActual.TipoOtro)) Then
                                    ' El Contacto en Outlook no coincide con los Tipos de Entidad seleccionados, lo elimino de Outlook
                                    BorrarContacto(OutlookContactItem, "Outlook Sync - Contacts - Delete - Type doesn't match: {0}")
                                ElseIf EntidadActual.Email1 Is Nothing And EntidadActual.Email2 Is Nothing Then
                                    ' La Entidad no tiene direcciones de e-mail especificadas
                                    BorrarContacto(OutlookContactItem, "Outlook Sync - Contacts - Delete - Doesn't have e-mail addresses: {0}")
                                Else
                                    ' Verifico y actualizo las propiedades del contacto
                                    ActualizarContacto(OutlookContactItem, EntidadActual)
                                End If
                            End If
                        Else
                            ' El IDEntidad Especificado tiene un formato erroneo
                            BorrarContacto(OutlookContactItem, "Outlook Sync - Contacts - Delete - ID field wrong format: {0}")
                        End If
                    Else
                        ' El Contacto no pertenece al sistema, si las opciones lo indican, lo borro
                        If Opciones.ContactoInexistenteBorrar Then
                            BorrarContacto(OutlookContactItem, "Outlook Sync - Contacts - Delete - Doesn't belongs to system: {0}")
                        End If
                    End If
                End With

                ' Progress bar
                ItemIndex += 1
                ProgressBarToUpdate.Value = ItemIndex
                Application.DoEvents()
            Next

            OutlookUserProperty = Nothing
            OutlookUserProperty = Nothing
            Return True

        Catch ex As Exception
            OutlookUserProperty = Nothing
            CS_Error.ProcessError(ex, "Error verificando los Contactos existentes en Microsoft Outlook.")
            Return False
        End Try
    End Function

    Private Function BorrarContacto(ByRef OutlookContactItem As Outlook.ContactItem, ByVal DebugMessage As String) As Boolean
        Try
            Debug.Print(String.Format(DebugMessage, OutlookContactItem.FullName))
            OutlookContactItem.Delete()
            Return True

        Catch ex As Exception
            CS_Error.ProcessError(ex, String.Format("Error borrando el Contacto ({0}) en Microsoft Outlook.", OutlookContactItem.FullName))
            Return False
        End Try
    End Function

    Private Function ActualizarContacto(ByRef OutlookContactItem As Outlook.ContactItem, ByRef EntidadActual As Entidad) As Boolean
        Dim ContactoOutlookActualizado As Boolean = False

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
            Return True

        Catch ex As Exception
            CS_Error.ProcessError(ex, String.Format("Error actualizando el Contacto ({0}) en Microsoft Outlook.", EntidadActual.ApellidoNombre))
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


    ''' <summary>
    ''' Verifico los contactos de la base de datos para ver si hay que agregar alguno
    ''' </summary>
    ''' <param name="otkApp">Microsoft Outlook Application object</param>
    ''' <param name="qryEntidades">Entidades de la base de datos</param>
    ''' <param name="listEntidadesVerificadasEnOutlook">Lista de IDs de Entidades verificadas en Outlook</param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Friend Function SyncronizeWithOutlook_VerifyContactsInDatabase(ByRef otkApp As Outlook.Application, ByRef qryEntidades As System.Linq.IQueryable(Of Entidad), ByRef listEntidadesVerificadasEnOutlook As List(Of Integer)) As Boolean
        Dim ItemIndex As Integer = 0

        Try
            progressbarMain.Value = 0
            progressbarMain.Maximum = qryEntidades.Count
            labelStatus.Text = "Verificando Entidades en el Sistema..."
            Application.DoEvents()

            For Each EntidadActual In qryEntidades
                ' Verifico que no haya sido verificado en el paso anterior
                Dim index As Integer
                index = listEntidadesVerificadasEnOutlook.IndexOf(EntidadActual.IDEntidad)
                If index = -1 Then
                    Dim newOutlookContact As Outlook.ContactItem

                    newOutlookContact = CType(otkApp.CreateItem(Outlook.OlItemType.olContactItem), Outlook.ContactItem)
                    If Not newOutlookContact Is Nothing Then
                        With newOutlookContact
                            .LastName = EntidadActual.Apellido
                            .FirstName = EntidadActual.Nombre
                            .FileAs = EntidadActual.ApellidoNombre

                            .Email1Address = EntidadActual.Email1
                            If .Email1Address <> EntidadActual.Email1 Then
                                .Email1Address = EntidadActual.Email1
                                CS_Office_Outlook_EarlyBinding.Contact_SetDisplayNameOfEmail1(newOutlookContact, EntidadActual)
                            End If

                            .Email2Address = EntidadActual.Email2
                            If .Email2Address <> EntidadActual.Email2 Then
                                .Email2Address = EntidadActual.Email2
                                CS_Office_Outlook_EarlyBinding.Contact_SetDisplayNameOfEmail2(newOutlookContact, EntidadActual)
                            End If

                            .UserProperties.Add(OUTLOOK_USERPROPERTYNAME_CONTACTO_ENTIDAD, Outlook.OlUserPropertyType.olInteger).Value = EntidadActual.IDEntidad

                            Debug.Print("ADDED: Nuevo contacto - " & .FullName)

                            .Save()
                        End With
                    End If
                End If

                ' Progress bar
                ItemIndex += 1
                progressbarMain.Value = ItemIndex
                Application.DoEvents()
            Next

            Return True

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            CS_Error.ProcessError(ex, "Error creando los Contactos no existentes en Microsoft Outlook.")
            Return False
        End Try
    End Function
End Module
