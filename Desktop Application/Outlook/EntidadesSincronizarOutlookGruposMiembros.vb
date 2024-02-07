Imports Microsoft.Office.Interop

Module EntidadesSincronizarOutlookGruposMiembros
    Friend Function VerificarMiembros(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByRef Entidades As List(Of Entidad), ByRef ProgressBarToUpdate As ProgressBar) As Boolean
        Dim EntidadesIDVerificados As List(Of Integer) = Nothing
        Dim EntidadesAAgregar As List(Of Entidad)

        If VerificarMiembrosEnOutlook(OutlookApplication, OutlookDistListItem, Entidades, EntidadesIDVerificados, ProgressBarToUpdate) Then
            If Entidades.Count > EntidadesIDVerificados.Count Then
                EntidadesAAgregar = (From dbe In Entidades Where Not EntidadesIDVerificados.Contains(dbe.IDEntidad)).ToList

                If Not AgregarMiembros(OutlookApplication, OutlookDistListItem, EntidadesAAgregar, ProgressBarToUpdate) Then
                    Return False
                End If
            End If
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Verifica cada integrante del Grupo de Contactos de Outlook contra la lista de Entidades del Sistema para verificar si tiene que estar ahí, y si no, lo borra.
    ''' </summary>
    ''' <param name="OutlookDistListItem">Colección de recipientes</param>
    ''' <param name="Entidades">Lista de entidades</param>
    ''' <param name="EntidadIDVerificados">Lista de IDs de Entidades verificadas</param>
    ''' <param name="ProgressBarToUpdate">Control progress bar para mostrar el progreso</param>
    ''' <returns>True si no hubo error</returns>
    Private Function VerificarMiembrosEnOutlook(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByRef Entidades As List(Of Entidad), ByRef EntidadIDVerificados As List(Of Integer), ByRef ProgressBarToUpdate As ProgressBar) As Boolean
        Dim OutlookRecipient As Outlook.Recipient
        Dim OutlookAddressEntry As Outlook.AddressEntry
        Dim OutlookContactItem As Outlook.ContactItem
        Dim OutlookUserProperty As Outlook.UserProperty

        Dim IDEntidad As Integer
        Dim ItemIndex As Integer = 0

        Dim HayAlgunRecipienteBorrado As Boolean = False

        EntidadIDVerificados = New List(Of Integer)

        Try
            ProgressBarToUpdate.Value = 0
            ProgressBarToUpdate.Maximum = OutlookDistListItem.MemberCount
            Application.DoEvents()

            For index As Integer = OutlookDistListItem.MemberCount To 1 Step -1
                OutlookRecipient = OutlookDistListItem.GetMember(index)

                ' Verifico si el contacto existe en la base de datos
                OutlookAddressEntry = OutlookRecipient.AddressEntry
                If OutlookAddressEntry IsNot Nothing Then
                    ' Esto funciona siempre y cuando no haya un contacto con la misma dirección de e-mail en otra carpeta de contactos
                    OutlookContactItem = CType(OutlookApplication.GetNamespace("MAPI").GetItemFromID(Strings.Right(OutlookAddressEntry.ID, 48)), Outlook.ContactItem)

                    If OutlookContactItem IsNot Nothing Then
                        OutlookUserProperty = OutlookContactItem.UserProperties.Find(OUTLOOK_USERPROPERTYNAME_CONTACTO_ENTIDAD)
                        If OutlookUserProperty IsNot Nothing Then
                            Integer.TryParse(OutlookUserProperty.Value.ToString, IDEntidad)
                            If IDEntidad > 0 Then
                                If Entidades.Exists(Function(e) e.IDEntidad = IDEntidad) Then
                                    If EntidadIDVerificados.Contains(IDEntidad) Then
                                        ' Ya está en la Lista de IDs verificados, esto quiere decir que está duplicado, por lo tanto, lo borro
                                        If EntidadesSincronizarOutlookGruposMiembrosABM.BorrarRecipiente(OutlookRecipient, OutlookDistListItem, "Duplicated") Then
                                            HayAlgunRecipienteBorrado = True
                                        End If
                                    Else
                                        ' Está ok, agrego el ID a la lista de Verificados
                                        EntidadIDVerificados.Add(IDEntidad)
                                    End If
                                Else
                                    ' El contacto no existe en la base de datos
                                    If EntidadesSincronizarOutlookGruposMiembrosABM.BorrarRecipiente(OutlookRecipient, OutlookDistListItem, "Doesn't exists anymore in DB or is inactive") Then
                                        HayAlgunRecipienteBorrado = True
                                    End If
                                End If
                            Else
                                ' El IDEntidad es erróneo, borro el Recipiente del grupo
                                If EntidadesSincronizarOutlookGruposMiembrosABM.BorrarRecipiente(OutlookRecipient, OutlookDistListItem, "ID field wrong format") Then
                                    HayAlgunRecipienteBorrado = True
                                End If
                            End If
                        Else
                            ' No tiene especificado el IDEntidad, borro el Recipiente del grupo
                            If EntidadesSincronizarOutlookGruposMiembrosABM.BorrarRecipiente(OutlookRecipient, OutlookDistListItem, "Doesn't belongs to system") Then
                                HayAlgunRecipienteBorrado = True
                            End If
                        End If
                    End If
                End If
                If HayAlgunRecipienteBorrado Then
                    OutlookDistListItem.Save()
                End If

                ' Progress bar
                ItemIndex += 1
                ProgressBarToUpdate.Value = ItemIndex
                Application.DoEvents()
            Next
            Return True

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, String.Format("Error al verificar los Contactos del Grupo ({0}) en Microsoft Outlook.", OutlookDistListItem.DLName))
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Agrega los Contactos de Outlook a la colección de recipientes a partir de la lista de Entidades
    ''' </summary>
    ''' <param name="OutlookApplication"></param>
    ''' <param name="OutlookDistListItem"></param>
    ''' <param name="EntidadesAAgregar"></param>
    ''' <param name="ProgressBarToUpdate"></param>
    ''' <returns></returns>
    Private Function AgregarMiembros(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByRef EntidadesAAgregar As List(Of Entidad), ByRef ProgressBarToUpdate As ProgressBar) As Boolean
        Dim ItemIndex As Integer = 0

        Try
            ProgressBarToUpdate.Value = 0
            ProgressBarToUpdate.Maximum = EntidadesAAgregar.Count
            Application.DoEvents()

            For Each EntidadAgregar As Entidad In EntidadesAAgregar
                If Not AgregarRecipienteDesdeEntidad(OutlookApplication, OutlookDistListItem, EntidadAgregar) Then
                    If MessageBox.Show($"Outlook no pudo resolver el nombre ({EntidadAgregar.ApellidoNombre}) del miembro del Grupo.{vbCrLf}{vbCrLf}¿Desea interrumpir el proceso?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        Exit For
                    End If
                End If
            Next
            OutlookDistListItem.Save()

            ' Progress bar
            ItemIndex += 1
            ProgressBarToUpdate.Value = ItemIndex
            Application.DoEvents()
            Return True

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, String.Format("Error al agregar los Miembros al Grupo ({0}) en Microsoft Outlook.", OutlookDistListItem.DLName))
            Return False
        End Try
    End Function

    Private Function AgregarRecipienteDesdeEntidad(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByRef EntidadAAgregar As Entidad) As Boolean
        With EntidadAAgregar
            If .ComprobanteEnviarEmail <> ENTIDAD_COMPROBANTE_ENVIAREMAIL_NO Then
                If .Email1 Is Nothing OrElse .Email2 Is Nothing Then
                    ' Tiene una sola dirección de email, por lo que no hay conflicto en agregarlo con el nombre
                    Return EntidadesSincronizarOutlookGruposMiembrosABM.AgregarRecipienteYResolver(OutlookApplication, OutlookDistListItem, .ApellidoNombre)
                Else
                    ' Tiene especificada las dos direcciones de e-mail, hay que verificar cual se va a agregar al grupo
                    Select Case .ComprobanteEnviarEmail
                        Case ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL1, ENTIDAD_COMPROBANTE_ENVIAREMAIL_CUALQUIERA
                            Return EntidadesSincronizarOutlookGruposMiembrosABM.AgregarRecipienteYResolver(OutlookApplication, OutlookDistListItem, .ApellidoNombre & " (" & .Email1 & ")")
                        Case ENTIDAD_COMPROBANTE_ENVIAREMAIL_EMAIL2
                            Return EntidadesSincronizarOutlookGruposMiembrosABM.AgregarRecipienteYResolver(OutlookApplication, OutlookDistListItem, .ApellidoNombre & " (" & .Email2 & ")")
                        Case ENTIDAD_COMPROBANTE_ENVIAREMAIL_AMBAS
                            If EntidadesSincronizarOutlookGruposMiembrosABM.AgregarRecipienteYResolver(OutlookApplication, OutlookDistListItem, .ApellidoNombre & " (" & .Email1 & ")") Then
                                Return EntidadesSincronizarOutlookGruposMiembrosABM.AgregarRecipienteYResolver(OutlookApplication, OutlookDistListItem, .ApellidoNombre & " (" & .Email2 & ")")
                            Else
                                Return False
                            End If
                        Case Else
                            Return False
                    End Select
                End If
            Else
                Return True
            End If
        End With
    End Function
End Module
