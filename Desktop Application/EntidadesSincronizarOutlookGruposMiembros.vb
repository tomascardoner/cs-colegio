Imports Microsoft.Office.Interop

Module EntidadesSincronizarOutlookGruposMiembros
    Friend Function VerificarGrupo(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByRef DatabaseEntidades As List(Of Entidad), ByRef ProgressBarToUpdate As ProgressBar) As Boolean
        Dim EntidadesIDVerificados As List(Of Integer) = Nothing
        Dim EntidadesAAgregar As List(Of Entidad)
        Dim OutlookRecipientes As Outlook.Recipients

        OutlookRecipientes = CType(OutlookDistListItem.Members, Outlook.Recipients)

        If VerificarMiembrosDeGrupoEnOutlook(OutlookDistListItem.DLName, OutlookRecipientes, DatabaseEntidades, EntidadesIDVerificados, ProgressBarToUpdate) Then
            If DatabaseEntidades.Count > EntidadesIDVerificados.Count Then
                EntidadesAAgregar = (From dbe In DatabaseEntidades Where Not EntidadesIDVerificados.Contains(dbe.IDEntidad)).ToList

                If GenerarRecipientesParaMiembrosDelGrupo(OutlookApplication, OutlookRecipientes) Then
                    If Not AgregarMiembrosAGrupoEnOutlook(OutlookDistListItem.DLName, OutlookRecipientes, EntidadesAAgregar, ProgressBarToUpdate) Then
                        Return False
                    End If
                Else
                    Return False
                End If
            End If
        Else
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Verifica cada integrante del Grupo de Contactos de Outlook contra la lista de Entidades del Sistema para verificar si tiene que estar ahí, y si no, lo borra.
    ''' </summary>
    ''' <param name="OutlookGrupoNombre">Nombre del grupo de Outlook</param>
    ''' <param name="OutlookRecipientes">Colección de recipientes</param>
    ''' <param name="DatabaseEntidades">Lista de entidades</param>
    ''' <param name="EntidadIDVerificados">Lista de IDs de Entidades verificadas</param>
    ''' <param name="ProgressBarToUpdate">Control progress bar para mostrar el progreso</param>
    ''' <returns>True si no hubo error</returns>
    Private Function VerificarMiembrosDeGrupoEnOutlook(ByVal OutlookGrupoNombre As String, ByRef OutlookRecipientes As Outlook.Recipients, ByRef DatabaseEntidades As List(Of Entidad), ByRef EntidadIDVerificados As List(Of Integer), ByRef ProgressBarToUpdate As ProgressBar) As Boolean
        Dim otkRecipient As Outlook.Recipient
        Dim otkContactUserProperty As Outlook.UserProperty
        Dim otkPropertyAccessor As Outlook.PropertyAccessor

        Dim IDEntidad As Integer
        Dim ItemIndex As Integer = 0

        EntidadIDVerificados = New List(Of Integer)

        Try
            ProgressBarToUpdate.Value = 0
            ProgressBarToUpdate.Maximum = OutlookRecipientes.Count
            Application.DoEvents()

            For index As Integer = OutlookRecipientes.Count To 1 Step -1
                otkRecipient = CType(OutlookRecipientes(index), Outlook.Recipient)
                otkPropertyAccessor = otkRecipient.PropertyAccessor

                ' Verifico si el contacto existe en la base de datos
                otkContactUserProperty = otkPropertyAccessor.GetProperties(OUTLOOK_USERPROPERTYNAME_CONTACTO_ENTIDAD)
                If Not otkContactUserProperty Is Nothing Then
                    Integer.TryParse(otkContactUserProperty.Value.ToString, IDEntidad)
                    If IDEntidad > 0 Then
                        If DatabaseEntidades.Exists(Function(e) e.IDEntidad = IDEntidad) Then
                            If EntidadIDVerificados.Contains(IDEntidad) Then
                                ' Ya está en la Lista de IDs verificados, esto quiere decir que está suplicado, por lo tanto, lo borro
                                Debug.Print(String.Format("Outlook Sync - Contact Group Member - Delete - Duplicated: {0}", OutlookGrupoNombre, otkRecipient.Address))
                                OutlookRecipientes.Remove(index)
                            Else
                                ' Está ok, agrego el ID a la lista de Verificados
                                EntidadIDVerificados.Add(IDEntidad)
                            End If
                        Else
                            ' 
                            Debug.Print(String.Format("Outlook Sync - Contact Group Member - Delete - Not in database - ({0})>>>({1})", OutlookGrupoNombre, otkRecipient.Address))
                            OutlookRecipientes.Remove(index)
                        End If
                    Else
                        ' El IDEntidad es erróneo, borro el Recipiente del grupo
                        Debug.Print(String.Format("Outlook Sync - Contact Group Member - Delete - Invalid ID - ({0})>>>({1})", OutlookGrupoNombre, otkRecipient.Address))
                        OutlookRecipientes.Remove(index)
                    End If
                Else
                    ' No tiene especificado el IDEntidad, borro el Recipiente del grupo
                    Debug.Print(String.Format("Outlook Sync - Contact Group Member - Delete - ID not specified - ({0})>>>({1})", OutlookGrupoNombre, otkRecipient.Address))
                    OutlookRecipientes.Remove(index)
                End If

                ' Progress bar
                ItemIndex += 1
                ProgressBarToUpdate.Value = ItemIndex
                Application.DoEvents()
            Next
            Return True

        Catch ex As Exception
            CS_Error.ProcessError(ex, String.Format("Error al verificar los Contactos del Grupo ({0}) en Microsoft Outlook.", OutlookGrupoNombre))
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Agrega los Contactos de Outlook a la colección de recipientes a partir de la lista de Entidades
    ''' </summary>
    ''' <param name="OutlookGrupoNombre"></param>
    ''' <param name="OutlookRecipientes"></param>
    ''' <param name="EntidadesAAgregar"></param>
    ''' <param name="ProgressBarToUpdate"></param>
    ''' <returns></returns>
    Private Function AgregarMiembrosAGrupoEnOutlook(ByVal OutlookGrupoNombre As String, ByRef OutlookRecipientes As Outlook.Recipients, ByRef EntidadesAAgregar As List(Of Entidad), ByRef ProgressBarToUpdate As ProgressBar) As Boolean
        Dim ItemIndex As Integer = 0

        Try
            ProgressBarToUpdate.Value = 0
            ProgressBarToUpdate.Maximum = EntidadesAAgregar.Count
            Application.DoEvents()

            For Each EntidadAgregar As Entidad In EntidadesAAgregar
                If AgregarRecipienteYResolver(OutlookGrupoNombre, OutlookRecipientes, EntidadAgregar) Then
                    'OutlookRecipientes.Add()
                Else

                    If MsgBox(String.Format("Outlook no pudo resolver el nombre ({1}) del miembro del Grupo.{0}{0}¿Desea interrumpir el proceso?", Environment.NewLine, EntidadAgregar.ApellidoNombre), CType(MsgBoxStyle.YesNo Or MsgBoxStyle.Information Or MsgBoxStyle.DefaultButton2, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                        Exit For
                    End If
                End If
            Next

            ' Progress bar
            ItemIndex += 1
            ProgressBarToUpdate.Value = ItemIndex
            Application.DoEvents()
            Return True

        Catch ex As Exception
            CS_Error.ProcessError(ex, String.Format("Error al agregar los Miembros al Grupo ({0}) en Microsoft Outlook.", OutlookGrupoNombre))
            Return False
        End Try
    End Function

    Private Function GenerarRecipientesParaMiembrosDelGrupo(ByRef OutlookApplication As Outlook.Application, ByRef OutlookRecipientes As Outlook.Recipients) As Boolean
        Dim otkNameSpace As Outlook.NameSpace
        Dim otkContactsFolder As Outlook.MAPIFolder
        Dim otkContactsItems As Outlook.Items
        Dim otkMailItem As Outlook.MailItem
        Dim otkRecipientNew As Outlook.Recipient = Nothing

        Try
            otkNameSpace = OutlookApplication.Session
            otkContactsFolder = otkNameSpace.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderContacts)
            otkContactsItems = otkContactsFolder.Items

            otkMailItem = CType(otkContactsItems.Add(Outlook.OlItemType.olMailItem), Outlook.MailItem)
            OutlookRecipientes = otkMailItem.Recipients

            ' Dispose all objects
            otkMailItem.Delete()
            otkMailItem = Nothing
            otkContactsItems = Nothing
            otkContactsFolder = Nothing
            otkNameSpace = Nothing
            Return True

        Catch ex As Exception
            otkMailItem = Nothing
            otkContactsItems = Nothing
            otkContactsFolder = Nothing
            otkNameSpace = Nothing
            CS_Error.ProcessError(ex, "Error al generar los Recipientes para agregar los miembros al Grupo de Contactos en Microsoft Outlook.")
            Return False
        End Try
    End Function

    Private Function AgregarRecipienteYResolver(ByVal GrupoNombre As String, ByRef OutlookRecipientes As Outlook.Recipients, ByRef EntidadAgregar As Entidad) As Boolean
        Dim otkRecipientNew As Outlook.Recipient = Nothing

        Try
            With EntidadAgregar
                If Not ((.Email1 Is Nothing And .Email2 Is Nothing) Or .ComprobanteEnviarEmail = ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO) Then
                    If .Email1 Is Nothing Or .Email2 Is Nothing Then
                        ' Tiene una sola dirección de email, por lo que no hay conflicto en agregarlo con el nombre
                        otkRecipientNew = OutlookRecipientes.Add(.ApellidoNombre)
                    Else
                        ' Tiene especificada las dos direcciones de e-mail, hay que verificar cual se va a agregar al grupo
                        Select Case .ComprobanteEnviarEmail
                            Case ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL1, ENTIDAD_COMPROBANTE_ENVIAREMAIL_CUALQUIERA
                                otkRecipientNew = OutlookRecipientes.Add(.ApellidoNombre & " (" & .Email1 & ")")
                            Case ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL2
                                otkRecipientNew = OutlookRecipientes.Add(.ApellidoNombre & " (" & .Email2 & ")")
                            Case ENTIDAD_COMPROBANTE_ENVIAREMAIL_AMBAS
                                otkRecipientNew = OutlookRecipientes.Add(.ApellidoNombre & " (" & .Email1 & ")")
                                otkRecipientNew = OutlookRecipientes.Add(.ApellidoNombre & " (" & .Email2 & ")")
                        End Select
                    End If
                    If (Not otkRecipientNew.Resolved) AndAlso (Not otkRecipientNew.Resolve()) Then
                        Return False
                    End If
                End If
            End With
            Return True

        Catch ex As Exception
            CS_Error.ProcessError(ex, String.Format("Error al agregar el Recipiente ({1}) a la lista de recipientes del Grupo ({0}) en Microsoft Outlook.", GrupoNombre, EntidadAgregar.ApellidoNombre))
            Return False
        End Try
    End Function
End Module
