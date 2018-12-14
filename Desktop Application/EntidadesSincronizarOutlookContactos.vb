Imports Microsoft.Office.Interop

Module EntidadesSincronizarOutlookContactos
    ''' <summary>
    ''' Verifico todos los contactos que hay en el Outlook, comparandolos con su respectiva Entidad
    ''' en la base de datos utilizando el campo de IDEntidad especificado en los campos de usuario.
    ''' Actualizando los datos de Outlook que hayan cambiado y borrando los contactos de Outlook que no
    ''' estén en la base de datos
    ''' </summary>
    ''' <param name="OutlookContacts">Contactos de Outlook</param>
    ''' <param name="dbContext">Contexto EF de base de datos</param>
    ''' <param name="IDEntidadesVerificadasEnOutlook">Lista de IDs de Entidades verificads en Outlook</param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Friend Function VerificarContactosEnOutlook(ByRef OutlookContacts As Outlook.Items, ByRef dbContext As CSColegioContext, ByRef IDEntidadesVerificadasEnOutlook As List(Of Integer), ByRef Opciones As EntidadesSincronizarOutlookOpciones, ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim ListOfOutlookContactItems As List(Of Outlook.ContactItem)
        Dim OutlookUserProperty As Outlook.UserProperty

        Dim IDEntidad As Integer
        Dim EntidadActual As Entidad
        Dim ItemIndex As Integer = 0

        Try
            ' Uso una lista estática porque si uso la carpeta de Outlook directamente en el For Each, al borrar o agregar items, pierde la secuencialidad
            ListOfOutlookContactItems = OutlookContacts.OfType(Of Outlook.ContactItem)().ToList

            ProgressBarProgreso.Value = 0
            ProgressBarProgreso.Maximum = ListOfOutlookContactItems.Count
            Application.DoEvents()

            For Each OutlookContactItem As Outlook.ContactItem In ListOfOutlookContactItems
                With OutlookContactItem
                    OutlookUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_CONTACTO_ENTIDAD)
                    If Not OutlookUserProperty Is Nothing Then
                        Integer.TryParse(OutlookUserProperty.Value.ToString, IDEntidad)
                        If IDEntidad > 0 Then
                            If IDEntidadesVerificadasEnOutlook.Contains(IDEntidad) Then
                                ' Ya fue verificado, por lo tanto, está duplicado
                                EntidadesSincronizarOutlookContactosABM.BorrarContacto(OutlookContactItem, "Duplicated")
                            Else
                                IDEntidadesVerificadasEnOutlook.Add(IDEntidad)
                                EntidadActual = dbContext.Entidad.Find(IDEntidad)
                                If EntidadActual Is Nothing OrElse EntidadActual.EsActivo = False Then
                                    ' No existe la Entidad en la base de datos o está desactivada
                                    EntidadesSincronizarOutlookContactosABM.BorrarContacto(OutlookContactItem, "Doesn't exists anymore in DB or is inactive")
                                ElseIf Not ((Opciones.EntidadTipoPersonalColegio And EntidadActual.TipoPersonalColegio) Or (Opciones.EntidadTipoDocente And EntidadActual.TipoDocente) Or (Opciones.EntidadTipoAlumno And EntidadActual.TipoAlumno) Or (Opciones.EntidadTipoFamiliar And EntidadActual.TipoFamiliar) Or (Opciones.EntidadTipoProveedor And EntidadActual.TipoProveedor) Or (Opciones.EntidadTipoOtro And EntidadActual.TipoOtro)) Then
                                    ' El Contacto en Outlook no coincide con los Tipos de Entidad seleccionados, lo elimino de Outlook
                                    EntidadesSincronizarOutlookContactosABM.BorrarContacto(OutlookContactItem, "Type doesn't match")
                                ElseIf EntidadActual.Email1 Is Nothing And EntidadActual.Email2 Is Nothing Then
                                    ' La Entidad no tiene direcciones de e-mail especificadas
                                    EntidadesSincronizarOutlookContactosABM.BorrarContacto(OutlookContactItem, "Doesn't have e-mail addresses")
                                Else
                                    ' Verifico y actualizo las propiedades del contacto
                                    EntidadesSincronizarOutlookContactosABM.ActualizarContacto(OutlookContactItem, EntidadActual)
                                End If
                            End If
                        Else
                            ' El IDEntidad Especificado tiene un formato erroneo
                            EntidadesSincronizarOutlookContactosABM.BorrarContacto(OutlookContactItem, "ID field wrong format")
                        End If
                    Else
                        ' El Contacto no pertenece al sistema, si las opciones lo indican, lo borro
                        If Opciones.ContactoInexistenteBorrar Then
                            EntidadesSincronizarOutlookContactosABM.BorrarContacto(OutlookContactItem, "Doesn't belongs to system")
                        End If
                    End If
                End With

                ' Progress bar
                ItemIndex += 1
                ProgressBarProgreso.Value = ItemIndex
                Application.DoEvents()
            Next

            OutlookUserProperty = Nothing
            Return True

        Catch ex As Exception
            OutlookUserProperty = Nothing
            CS_Error.ProcessError(ex, "Error verificando los Contactos existentes en Microsoft Outlook.")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Verifico los contactos de la base de datos para ver si hay que agregar alguno
    ''' </summary>
    ''' <param name="OutlookApplication">Microsoft Outlook Application object</param>
    ''' <param name="Entidades">Entidades de la base de datos</param>
    ''' <param name="IDEntidadesVerificadasEnOutlook">Lista de IDs de Entidades verificadas en Outlook</param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Friend Function VerificarContactosEnBaseDeDatos(ByRef OutlookApplication As Outlook.Application, ByRef Entidades As List(Of Entidad), ByRef IDEntidadesVerificadasEnOutlook As List(Of Integer), ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim OutlookContactItem As Outlook.ContactItem = Nothing
        Dim ItemIndex As Integer = 0

        Try
            ProgressBarProgreso.Value = 0
            ProgressBarProgreso.Maximum = Entidades.Count
            Application.DoEvents()

            For Each EntidadActual In Entidades
                ' Verifico que no haya sido verificado en el paso anterior
                If Not IDEntidadesVerificadasEnOutlook.Contains(EntidadActual.IDEntidad) Then
                    If EntidadesSincronizarOutlookContactosABM.CrearContacto(OutlookApplication, OutlookContactItem, EntidadActual.IDEntidad) Then
                        If Not EntidadesSincronizarOutlookContactosABM.ActualizarContacto(OutlookContactItem, EntidadActual) Then
                            Exit For
                        End If
                    Else
                        Exit For
                    End If
                End If

                ' Progress bar
                ItemIndex += 1
                ProgressBarProgreso.Value = ItemIndex
                Application.DoEvents()
            Next
            OutlookContactItem = Nothing
            Return True

        Catch ex As Exception
            CS_Error.ProcessError(ex, "Error creando los Contactos no existentes en Microsoft Outlook.")
            OutlookContactItem = Nothing
            Return False
        End Try
    End Function
End Module
