Imports Microsoft.Office.Interop

Module EntidadesSincronizarOutlookGruposExistentes
    ''' <summary>
    ''' Verifica los Grupos de Contactos con el Outlook
    ''' </summary>
    ''' <param name="Opciones">Opciones de sincronización</param>
    ''' <param name="OutlookContacts">Contactos de Outlook</param>
    ''' <param name="dbContext"></param>
    ''' <param name="GruposDeTipoVerificadosEnOutlook"></param>
    ''' <param name="GruposDeNivelVerificadosEnOutlook"></param>
    ''' <param name="GruposDeCursoVerificadosEnOutlook"></param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Friend Function VerificarGrupos(ByRef OutlookApplication As Outlook.Application, ByRef OutlookContacts As Outlook.Items, ByRef dbContext As CSColegioContext, ByRef GruposDeTipoVerificadosEnOutlook As List(Of String), ByRef GruposDeNivelVerificadosEnOutlook As List(Of Byte), ByRef GruposDeCursoVerificadosEnOutlook As List(Of Byte), ByRef Opciones As EntidadesSincronizarOutlookOpciones, ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim OutlookDistListItems As List(Of Outlook.DistListItem)
        Dim OutlookUserProperty As Outlook.UserProperty

        Dim ItemIndex As Integer = 0

        Try
            ' Uso una lista estática porque si uso la carpeta de Outlook directamente en el For Each, al borrar o agregar items, pierde la secuencialidad
            OutlookDistListItems = OutlookContacts.OfType(Of Outlook.DistListItem)().ToList

            ProgressBarProgreso.Value = 0
            ProgressBarProgreso.Maximum = OutlookDistListItems.Count
            Application.DoEvents()

            For Each OutlookDistListItem As Outlook.DistListItem In OutlookDistListItems
                With OutlookDistListItem
                    ' Verifico si es un Grupo de Tipo de Entidad
                    OutlookUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_GRUPO_TIPO)
                    If Not OutlookUserProperty Is Nothing Then
                        If Not VerificarGrupoDeTipo(OutlookApplication, OutlookDistListItem, OutlookUserProperty.Value.ToString, dbContext, GruposDeTipoVerificadosEnOutlook, Opciones, ProgressBarProgreso) Then
                            OutlookDistListItems = Nothing
                            OutlookUserProperty = Nothing
                            Return False
                        End If
                        Continue For
                    End If

                    ' Verifico si es un Grupo de Nivel
                    OutlookUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_GRUPO_NIVEL)
                    If Not OutlookUserProperty Is Nothing Then
                        If Not VerificarGrupoDeNivel(OutlookApplication, OutlookDistListItem, OutlookUserProperty.Value.ToString, dbContext, GruposDeNivelVerificadosEnOutlook, Opciones, ProgressBarProgreso) Then
                            OutlookDistListItems = Nothing
                            OutlookUserProperty = Nothing
                            Return False
                        End If
                        Continue For
                    End If

                    ' Verifico si es un Grupo de Curso
                    OutlookUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_GRUPO_CURSO)
                    If Not OutlookUserProperty Is Nothing Then
                        If Not VerificarGrupoDeCurso(OutlookApplication, OutlookDistListItem, OutlookUserProperty.Value.ToString, dbContext, GruposDeCursoVerificadosEnOutlook, Opciones, ProgressBarProgreso) Then
                            OutlookDistListItems = Nothing
                            OutlookUserProperty = Nothing
                            Return False
                        End If
                        Continue For
                    End If

                    ' Es un Grupo que no depende del sistema, si está especificado, lo elimino
                    If Opciones.GrupoContactosInexistenteBorrar Then
                        EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Doesn't belongs to system")
                    End If
                End With

                ' Progress bar
                ItemIndex += 1
                ProgressBarProgreso.Value = ItemIndex
                Application.DoEvents()
            Next

            OutlookDistListItems = Nothing
            OutlookUserProperty = Nothing
            Return True

        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error verificando los Grupos de Contactos de Microsoft Outlook")
            OutlookDistListItems = Nothing
            Return False
        End Try
    End Function

    Private Function VerificarGrupoDeTipo(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByVal EntidadTipo As String, ByRef dbContext As CSColegioContext, ByRef GruposDeTipoVerificadosEnOutlook As List(Of String), ByRef Opciones As EntidadesSincronizarOutlookOpciones, ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim Entidades As List(Of Entidad) = Nothing

        ' Verifico que el dato contenido en la Property sea válido
        If EntidadTipo.Length = 1 AndAlso Constantes.ENTIDADTIPO_TODOS.Contains(EntidadTipo) Then
            If (Opciones.EntidadTipoPersonalColegio And EntidadTipo = Constantes.ENTIDADTIPO_PERSONALCOLEGIO) Or (Opciones.EntidadTipoDocente And EntidadTipo = Constantes.ENTIDADTIPO_DOCENTE) Or (Opciones.EntidadTipoAlumno And EntidadTipo = Constantes.ENTIDADTIPO_ALUMNO) Or (Opciones.EntidadTipoFamiliar And EntidadTipo = Constantes.ENTIDADTIPO_FAMILIAR) Or (Opciones.EntidadTipoProveedor And EntidadTipo = Constantes.ENTIDADTIPO_PROVEEDOR) Or (Opciones.EntidadTipoOtro And EntidadTipo = Constantes.ENTIDADTIPO_OTRO) Then
                If Not GruposDeTipoVerificadosEnOutlook.Contains(EntidadTipo) Then
                    ' Verifico y actualizo las propiedades del grupo
                    Try
                        Select Case EntidadTipo
                            Case Constantes.ENTIDADTIPO_PERSONALCOLEGIO
                                Entidades = dbContext.Entidad.Where(Function(e) e.EsActivo And e.TipoPersonalColegio And Not (e.Email1 Is Nothing And e.Email2 Is Nothing)).ToList
                            Case Constantes.ENTIDADTIPO_DOCENTE
                                Entidades = dbContext.Entidad.Where(Function(e) e.EsActivo And e.TipoDocente And Not (e.Email1 Is Nothing And e.Email2 Is Nothing)).ToList
                            Case Constantes.ENTIDADTIPO_ALUMNO
                                Entidades = dbContext.Entidad.Where(Function(e) e.EsActivo And e.TipoAlumno And Not (e.Email1 Is Nothing And e.Email2 Is Nothing)).ToList
                            Case Constantes.ENTIDADTIPO_FAMILIAR
                                Entidades = dbContext.Entidad.Where(Function(e) e.EsActivo And e.TipoFamiliar And Not (e.Email1 Is Nothing And e.Email2 Is Nothing)).ToList
                            Case Constantes.ENTIDADTIPO_PROVEEDOR
                                Entidades = dbContext.Entidad.Where(Function(e) e.EsActivo And e.TipoProveedor And Not (e.Email1 Is Nothing And e.Email2 Is Nothing)).ToList
                            Case Constantes.ENTIDADTIPO_OTRO
                                Entidades = dbContext.Entidad.Where(Function(e) e.EsActivo And e.TipoOtro And Not (e.Email1 Is Nothing And e.Email2 Is Nothing)).ToList
                        End Select
                    Catch ex As Exception
                        CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al filtrar las Entidades por Tipo.")
                        Entidades = Nothing
                        Return False
                    End Try
                    If Not EntidadesSincronizarOutlookGruposABM.ActualizarGrupo(OutlookApplication, OutlookDistListItem, String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, EntidadTipoANombre(EntidadTipo)), Entidades, ProgressBarProgreso) Then
                        Entidades = Nothing
                        Return False
                    End If
                    GruposDeTipoVerificadosEnOutlook.Add(EntidadTipo)
                Else
                    ' Ya fue verificado y está duplicado, por lo tanto, lo borro de Outlook
                    EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Duplicated")
                End If
            Else
                ' No hay que sincronizar este grupo, por lo tanto, lo borro de Outlook
                EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Type not selected")
            End If
        Else
            ' Es un grupo de Tipo pero tiene mal especificado el Tipo, por lo tanto, lo borro de Outlook
            EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Type field wrong data format")
        End If
        Entidades = Nothing
        Return True
    End Function

    Private Function VerificarGrupoDeNivel(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByVal IDNivelString As String, ByRef dbContext As CSColegioContext, ByRef GruposDeNivelVerificadosEnOutlook As List(Of Byte), ByRef Opciones As EntidadesSincronizarOutlookOpciones, ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim IDNivel As Byte
        Dim OutlookUserPropertyAnioLectivo As Outlook.UserProperty
        Dim AnioLectivo As Short = 0
        Dim NivelActual As Nivel
        Dim Entidades As List(Of Entidad) = Nothing

        Byte.TryParse(IDNivelString, IDNivel)
        If IDNivel > 0 Then
            OutlookUserPropertyAnioLectivo = OutlookDistListItem.UserProperties.Find(OUTLOOK_USERPROPERTYNAME_GRUPO_ANIOLECTIVO)
            If Not OutlookUserPropertyAnioLectivo Is Nothing Then
                Short.TryParse(OutlookUserPropertyAnioLectivo.Value.ToString, AnioLectivo)
                If AnioLectivo > 0 Then
                    If Opciones.AniosLectivos.Contains(AnioLectivo) AndAlso Opciones.SincronizarGrupoContactosPorNivelesYCursos And Opciones.EntidadTipoAlumno Then
                        If Not GruposDeNivelVerificadosEnOutlook.Contains(IDNivel) Then
                            Try
                                NivelActual = dbContext.Nivel.Find(IDNivel)
                                If (Not NivelActual Is Nothing) AndAlso NivelActual.EsActivo Then
                                    Entidades = (From alc In dbContext.AnioLectivoCurso
                                                 From e In alc.Entidades
                                                 Where alc.Curso.Anio.IDNivel = IDNivel And alc.AnioLectivo = AnioLectivo And e.EsActivo And e.TipoAlumno And Not (e.Email1 Is Nothing And e.Email2 Is Nothing)
                                                 Select e).ToList
                                    ' Verifico y actualizo las propiedades del grupo
                                    EntidadesSincronizarOutlookGruposABM.ActualizarGrupo(OutlookApplication, OutlookDistListItem, String.Format("{0} - {1}", AnioLectivo, NivelActual.Nombre), Entidades, ProgressBarProgreso)
                                Else
                                    ' No existe el Nivel en la base de datos o está inactivo, por lo tanto, lo borro de Outlook
                                    EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Doesn't exists anymore in DB or is inactive")
                                End If
                            Catch ex As Exception
                                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al filtrar las Entidades por Año Lectivo y Nivel.")
                                Entidades = Nothing
                                Return False
                            End Try
                            GruposDeNivelVerificadosEnOutlook.Add(IDNivel)
                        Else
                            ' Ya fue verificado y está duplicado, por lo tanto, lo borro de Outlook
                            EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Duplicated")
                        End If
                    Else
                        ' No hay que sincronizar, por lo tanto, borro el Grupo
                        EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Not Sync this kind of Group")
                    End If
                Else
                    ' El Año Lectivo especificado tiene un formato incorrecto, por lo tanto, lo borro de Outlook
                    EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Año Lectivo property wrong data format")
                End If
            Else
                ' No tiene especificado el Año Lectivo, por lo tanto, lo borro de Outlook
                EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Año Lectivo not specified")
            End If
        Else
            ' El IDNivel Especificado tiene un formato erroneo, por lo tanto, lo borro de Outlook
            EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "IDNivel field wrong data format")
        End If
        OutlookUserPropertyAnioLectivo = Nothing
        Return True
    End Function

    Private Function VerificarGrupoDeCurso(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByVal IDCursoString As String, ByRef dbContext As CSColegioContext, ByRef GruposDeCursoVerificadosEnOutlook As List(Of Byte), ByRef Opciones As EntidadesSincronizarOutlookOpciones, ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim IDCurso As Byte
        Dim OutlookUserPropertyAnioLectivo As Outlook.UserProperty
        Dim AnioLectivo As Short = 0
        Dim CursoActual As Curso
        Dim Entidades As List(Of Entidad) = Nothing

        Byte.TryParse(IDCursoString, IDCurso)
        If IDCurso > 0 Then
            OutlookUserPropertyAnioLectivo = OutlookDistListItem.UserProperties.Find(OUTLOOK_USERPROPERTYNAME_GRUPO_ANIOLECTIVO)
            If Not OutlookUserPropertyAnioLectivo Is Nothing Then
                Short.TryParse(OutlookUserPropertyAnioLectivo.Value.ToString, AnioLectivo)
                If AnioLectivo > 0 Then
                    If Opciones.AniosLectivos.Contains(AnioLectivo) AndAlso Opciones.SincronizarGrupoContactosPorNivelesYCursos And Opciones.EntidadTipoAlumno Then
                        If Not GruposDeCursoVerificadosEnOutlook.Contains(IDCurso) Then
                            Try
                                CursoActual = dbContext.Curso.Find(IDCurso)
                                If (Not CursoActual Is Nothing) AndAlso CursoActual.EsActivo Then
                                    Entidades = (From alc In dbContext.AnioLectivoCurso
                                                 From e In alc.Entidades
                                                 Where alc.Curso.IDCurso = IDCurso And alc.AnioLectivo = AnioLectivo And e.EsActivo And e.TipoAlumno And Not (e.Email1 Is Nothing And e.Email2 Is Nothing)
                                                 Select e).ToList
                                    ' Verifico y actualizo las propiedades del grupo
                                    EntidadesSincronizarOutlookGruposABM.ActualizarGrupo(OutlookApplication, OutlookDistListItem, String.Format("{0} - {1}", AnioLectivo, CursoActual.Nombre), Entidades, ProgressBarProgreso)
                                Else
                                    ' No existe el Curso en la base de datos o está inactivo, por lo tanto, lo borro de Outlook
                                    EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Doesn't exists anymore in DB or is inactive")
                                End If
                            Catch ex As Exception
                                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al filtrar las Entidades por Año Lectivo y Curso.")
                                Entidades = Nothing
                                Return False
                            End Try
                            GruposDeCursoVerificadosEnOutlook.Add(IDCurso)
                        Else
                            ' Ya fue verificado y está duplicado, por lo tanto, lo borro de Outlook
                            EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Duplicated")
                        End If
                    Else
                        ' No hay que sincronizar, por lo tanto, borro el Grupo
                        EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Not Sync this kind of Group")
                    End If
                Else
                    ' El Año Lectivo especificado tiene un formato incorrecto, por lo tanto, lo borro de Outlook
                    EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Año Lectivo property wrong data format")
                End If
            Else
                ' No tiene especificado el Año Lectivo, por lo tanto, lo borro de Outlook
                EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Año Lectivo not specified")
            End If
        Else
            ' El IDNivel Especificado tiene un formato erroneo, por lo tanto, lo borro de Outlook
            EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "IDNivel field wrong data format")
        End If
        OutlookUserPropertyAnioLectivo = Nothing
        Return True
    End Function
End Module
