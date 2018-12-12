Imports Microsoft.Office.Interop

Module EntidadesSincronizarOutlookGrupos


    ''' <summary>
    ''' Verifica los Grupos de Contactos con el Outlook
    ''' </summary>
    ''' <param name="otkContactsItems"></param>
    ''' <param name="dbContext"></param>
    ''' <param name="listGruposDeTipoVerificadosEnOutlook"></param>
    ''' <param name="listGruposDeNivelVerificadosEnOutlook"></param>
    ''' <param name="listGruposDeCursoVerificadosEnOutlook"></param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Private Function SynchronizeWithOutlook_VerifyContactsGroupsInOutlook(ByRef otkContactsItems As Outlook.Items, ByRef dbContext As CSColegioContext, ByRef listGruposDeTipoVerificadosEnOutlook As List(Of String), ByRef listGruposDeNivelVerificadosEnOutlook As List(Of Byte), ByRef listGruposDeCursoVerificadosEnOutlook As List(Of Byte)) As Boolean
        Dim listDistListItemsInOutlook As List(Of Outlook.DistListItem)
        Dim otkContactUserProperty As Outlook.UserProperty

        Dim ItemIndex As Integer = 0
        Dim EntidadTipo As String
        Dim IDNivel As Byte
        Dim NivelActual As Nivel
        Dim IDCurso As Byte
        Dim CursoActual As Curso

        Try
            ' Uso una lista estática porque si uso la carpeta de Outlook directamente en el For Each, al borrar o agregar items, pierde la secuencialidad
            listDistListItemsInOutlook = otkContactsItems.OfType(Of Outlook.DistListItem)().ToList

            progressbarMain.Value = 0
            progressbarMain.Maximum = listDistListItemsInOutlook.Count
            labelStatus.Text = "Verificando Grupos de Contactos existentes en Outlook..."
            Application.DoEvents()

            For Each otkContactItem As Outlook.DistListItem In listDistListItemsInOutlook
                With otkContactItem
                    ' Verifico si es un Grupo de Tipo de Entidad
                    otkContactUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_GRUPO_TIPO)
                    If Not otkContactUserProperty Is Nothing Then
                        EntidadTipo = otkContactUserProperty.Value.ToString
                        If listGruposDeTipoVerificadosEnOutlook.Contains(EntidadTipo) Then
                            ' Ya fue verificado, por lo tanto, está duplicado, hay que borrarlo
                            Debug.Print("Outlook Sync - Contact Group - DELETE: Está duplicado - " & .DLName)
                            .Delete()
                        Else
                            listGruposDeTipoVerificadosEnOutlook.Add(EntidadTipo)
                            If EntidadTipo.Length = 1 AndAlso Constantes.ENTIDADTIPO_TODOS.Contains(EntidadTipo) Then
                                If (checkboxEntidadTipoPersonalColegio.Checked And EntidadTipo = Constantes.ENTIDADTIPO_PERSONALCOLEGIO) Or (checkboxEntidadTipoDocente.Checked And EntidadTipo = Constantes.ENTIDADTIPO_DOCENTE) Or (checkboxEntidadTipoAlumno.Checked And EntidadTipo = Constantes.ENTIDADTIPO_ALUMNO) Or (checkboxEntidadTipoFamiliar.Checked And EntidadTipo = Constantes.ENTIDADTIPO_FAMILIAR) Or (checkboxEntidadTipoProveedor.Checked And EntidadTipo = Constantes.ENTIDADTIPO_PROVEEDOR) Or (checkboxEntidadTipoOtro.Checked And EntidadTipo = Constantes.ENTIDADTIPO_OTRO) Then
                                    ' Verifico y actualizo las propiedades del grupo
                                    If .DLName <> String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, EntidadTipoANombre(EntidadTipo)) Then
                                        .DLName = String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, EntidadTipoANombre(EntidadTipo))
                                        Debug.Print("Outlook Sync - Contact Group - UPDATE: Se actualizó la info - " & .DLName)
                                        .Save()
                                    End If
                                Else
                                    ' No hay que sincronizar este grupo, por lo tanto se borra de Outlook
                                    Debug.Print("Outlook Sync - Contact Group - DELETE: No está seleccionado para sincronizar - " & .DLName)
                                    .Delete()
                                End If
                            Else
                                ' Es un grupo de Tipo pero tiene mal especificado el Tipo
                                Debug.Print("Outlook Sync - Contact Group - DELETE: El campo de Tipo es erróneo - " & .DLName)
                                .Delete()
                            End If
                        End If
                        Continue For
                    End If

                    ' Verifico si es un Grupo de Nivel
                    otkContactUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_GRUPO_NIVEL)
                    If Not otkContactUserProperty Is Nothing Then
                        Byte.TryParse(otkContactUserProperty.Value.ToString, IDNivel)
                        If IDNivel > 0 Then
                            If listGruposDeNivelVerificadosEnOutlook.Contains(IDNivel) Then
                                ' Ya fue verificado, por lo tanto, está duplicado, hay que borrarlo
                                Debug.Print("Outlook Sync - Contact Group - DELETE: Está duplicado - " & .DLName)
                                .Delete()
                            Else
                                listGruposDeNivelVerificadosEnOutlook.Add(IDNivel)
                                NivelActual = dbContext.Nivel.Find(IDNivel)
                                If NivelActual Is Nothing Then
                                    ' No existe el Grupo en la base de datos, lo elimino de Outlook
                                    Debug.Print("Outlook Sync - Contact Group - DELETE: No existe el Nivel en la base de datos - " & .DLName)
                                    .Delete()
                                Else
                                    ' Verifico y actualizo las propiedades del grupo
                                    If .DLName <> String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, NivelActual.Nombre) Then
                                        .DLName = String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, NivelActual.Nombre)
                                        Debug.Print("Outlook Sync - Contact Group - UPDATE: Se actualizó la info - " & .DLName)
                                        .Save()
                                    End If
                                End If
                            End If
                        Else
                            ' El IDNivel Especificado tiene un formato erroneo
                            Debug.Print("Outlook Sync - Contact Group - DELETE: El campo IDNivel es erróneo - " & .DLName)
                            .Delete()
                        End If
                        Continue For
                    End If

                    ' Verifico si es un Grupo de Curso
                    otkContactUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_GRUPO_CURSO)
                    If Not otkContactUserProperty Is Nothing Then
                        Byte.TryParse(otkContactUserProperty.Value.ToString, IDCurso)
                        If IDCurso > 0 Then
                            If listGruposDeCursoVerificadosEnOutlook.Contains(IDCurso) Then
                                ' Ya fue verificado, por lo tanto, está duplicado, hay que borrarlo
                                Debug.Print("Outlook Sync - Contact Group - DELETE: Está duplicado - " & .DLName)
                                .Delete()
                            Else
                                listGruposDeCursoVerificadosEnOutlook.Add(IDCurso)
                                CursoActual = dbContext.Curso.Find(IDCurso)
                                If CursoActual Is Nothing Then
                                    ' No existe el Grupo en la base de datos, lo elimino de Outlook
                                    Debug.Print("Outlook Sync - Contact Group - DELETE: No existe el Curso en la base de datos - " & .DLName)
                                    .Delete()
                                Else
                                    ' Verifico y actualizo las propiedades del grupo
                                    If .DLName <> String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, CursoActual.Nombre) Then
                                        .DLName = String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, CursoActual.Nombre)
                                        Debug.Print("Outlook Sync - Contact Group - UPDATE: Se actualizó la info - " & .DLName)
                                        .Save()
                                    End If
                                End If
                            End If
                        Else
                            ' El IDCurso Especificado tiene un formato erroneo
                            Debug.Print("Outlook Sync - Contact Group - DELETE: El campo IDCurso es erróneo - " & .DLName)
                            .Delete()
                        End If
                        Continue For
                    End If

                    ' Es un Grupo que no depende del sistema, si está especificado, lo elimino
                    If radiobuttonGrupoContactosBorrar.Checked Then
                        Debug.Print("Outlook Sync - Contact Group - DELETE: Es un grupo inexistente - " & .DLName)
                        .Delete()
                    End If
                End With

                ' Progress bar
                ItemIndex += 1
                progressbarMain.Value = ItemIndex
                Application.DoEvents()
            Next

            listDistListItemsInOutlook = Nothing

            Return True

        Catch ex As Exception
            otkContactUserProperty = Nothing

            Me.Cursor = Cursors.Default
            CS_Error.ProcessError(ex, "Error verificando los Grupos de Contactos de Microsoft Outlook")
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Verifico los grupos de contactos de la base de datos para ver si hay que agregar alguno
    ''' </summary>
    ''' <param name="otkApp">Microsoft Outlook Application object</param>
    ''' <param name="qryEntidades">Entidades de la base de datos</param>
    ''' <param name="listGruposDeTipoVerificadosEnOutlook">Lista de IDs de Entidades verificadas en Outlook</param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Private Function SyncronizeWithOutlook_VerifyContactGroupsInDatabase(ByRef otkApp As Outlook.Application, ByRef qryEntidades As System.Linq.IQueryable(Of Entidad), ByRef listGruposDeTipoVerificadosEnOutlook As List(Of String)) As Boolean
        Try
            If checkboxEntidadTipoPersonalColegio.Checked And Not listGruposDeTipoVerificadosEnOutlook.Contains(Constantes.ENTIDADTIPO_PERSONALCOLEGIO) Then
                If Not SynchronizeWithOutlook_CreateContactGroupInOutlook(otkApp, Constantes.ENTIDADTIPO_PERSONALCOLEGIO, qryEntidades.Where(Function(e) e.TipoPersonalColegio)) Then
                    Return False
                End If
            End If
            If checkboxEntidadTipoDocente.Checked And Not listGruposDeTipoVerificadosEnOutlook.Contains(Constantes.ENTIDADTIPO_DOCENTE) Then
                If Not SynchronizeWithOutlook_CreateContactGroupInOutlook(otkApp, Constantes.ENTIDADTIPO_DOCENTE, qryEntidades.Where(Function(e) e.TipoDocente)) Then
                    Return False
                End If
            End If
            If checkboxEntidadTipoAlumno.Checked And Not listGruposDeTipoVerificadosEnOutlook.Contains(Constantes.ENTIDADTIPO_ALUMNO) Then
                If Not SynchronizeWithOutlook_CreateContactGroupInOutlook(otkApp, Constantes.ENTIDADTIPO_ALUMNO, qryEntidades.Where(Function(e) e.TipoAlumno)) Then
                    Return False
                End If
            End If
            If checkboxEntidadTipoFamiliar.Checked And Not listGruposDeTipoVerificadosEnOutlook.Contains(Constantes.ENTIDADTIPO_FAMILIAR) Then
                If Not SynchronizeWithOutlook_CreateContactGroupInOutlook(otkApp, Constantes.ENTIDADTIPO_FAMILIAR, qryEntidades.Where(Function(e) e.TipoFamiliar)) Then
                    Return False
                End If
            End If
            If checkboxEntidadTipoProveedor.Checked And Not listGruposDeTipoVerificadosEnOutlook.Contains(Constantes.ENTIDADTIPO_PROVEEDOR) Then
                If Not SynchronizeWithOutlook_CreateContactGroupInOutlook(otkApp, Constantes.ENTIDADTIPO_PROVEEDOR, qryEntidades.Where(Function(e) e.TipoProveedor)) Then
                    Return False
                End If
            End If
            If checkboxEntidadTipoOtro.Checked And Not listGruposDeTipoVerificadosEnOutlook.Contains(Constantes.ENTIDADTIPO_OTRO) Then
                If Not SynchronizeWithOutlook_CreateContactGroupInOutlook(otkApp, Constantes.ENTIDADTIPO_OTRO, qryEntidades.Where(Function(e) e.TipoOtro)) Then
                    Return False
                End If
            End If
            Return True

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            CS_Error.ProcessError(ex, "Error creando los Grupos de Contactos no existentes en Microsoft Outlook.")
            Return False
        End Try
    End Function

    Private Function CrearGrupo(ByRef OutlookApplication As Outlook.Application, ByVal GrupoNombre As String) As Boolean
        Dim otkDistListItem As Outlook.DistListItem

        ' Verificar que exista el Grupo
        'CrearGrupo
        'String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, EntidadTipoANombre(EntidadTipo))
        '.UserProperties.Add(OUTLOOK_USERPROPERTYNAME_GRUPO_TIPO, Outlook.OlUserPropertyType.olText).Value = EntidadTipo


        Try
            otkDistListItem = CType(OutlookApplication.CreateItem(Outlook.OlItemType.olDistributionListItem), Outlook.DistListItem)
            If Not otkDistListItem Is Nothing Then
                With otkDistListItem
                    .DLName = GrupoNombre
                    Debug.Print("Outlook Sync - Contact Group - Add - Se ha creado el grupo - " & .DLName)
                    .Save()
                End With
            End If

            otkDistListItem = Nothing
            Return True

        Catch ex As Exception
            otkDistListItem = Nothing
            CS_Error.ProcessError(ex, "Error creando el Grupo de Contactos no existentes en Microsoft Outlook.")
            Return False
        End Try
    End Function

End Module
