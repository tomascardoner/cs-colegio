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
                        VerificarGrupoDeTipo(OutlookApplication, OutlookDistListItem, OutlookUserProperty, dbContext, GruposDeTipoVerificadosEnOutlook, Opciones, ProgressBarProgreso)
                        Continue For
                    End If

                    ' Verifico si es un Grupo de Nivel
                    OutlookUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_GRUPO_NIVEL)
                    If Not OutlookUserProperty Is Nothing Then
                        'VerificarGrupoDeNivel(OutlookApplication, OutlookDistListItem, OutlookUserProperty, dbContext, GruposDeNivelVerificadosEnOutlook, Opciones, ProgressBarProgreso)
                        Continue For
                    End If

                    ' Verifico si es un Grupo de Curso
                    OutlookUserProperty = .UserProperties.Find(OUTLOOK_USERPROPERTYNAME_GRUPO_CURSO)
                    If Not OutlookUserProperty Is Nothing Then
                        'VerificarGrupoDeCurso(OutlookApplication, OutlookDistListItem, OutlookUserProperty, dbContext, GruposDeCursoVerificadosEnOutlook, Opciones, ProgressBarProgreso)
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
            CS_Error.ProcessError(ex, "Error verificando los Grupos de Contactos de Microsoft Outlook")
            OutlookDistListItems = Nothing
            OutlookUserProperty = Nothing
            Return False
        End Try
    End Function

    Private Function VerificarGrupoDeTipo(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByRef OutlookUserProperty As Outlook.UserProperty, ByRef dbContext As CSColegioContext, ByRef GruposDeTipoVerificadosEnOutlook As List(Of String), ByRef Opciones As EntidadesSincronizarOutlookOpciones, ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim EntidadTipo As String
        Dim Entidades As List(Of Entidad) = Nothing

        EntidadTipo = OutlookUserProperty.Value.ToString
        If GruposDeTipoVerificadosEnOutlook.Contains(EntidadTipo) Then
            ' Ya fue verificado, por lo tanto, está duplicado, hay que borrarlo
            EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Duplicated")
        Else
            If EntidadTipo.Length = 1 AndAlso Constantes.ENTIDADTIPO_TODOS.Contains(EntidadTipo) Then
                If (Opciones.EntidadTipoPersonalColegio And EntidadTipo = Constantes.ENTIDADTIPO_PERSONALCOLEGIO) Or (Opciones.EntidadTipoDocente And EntidadTipo = Constantes.ENTIDADTIPO_DOCENTE) Or (Opciones.EntidadTipoAlumno And EntidadTipo = Constantes.ENTIDADTIPO_ALUMNO) Or (Opciones.EntidadTipoFamiliar And EntidadTipo = Constantes.ENTIDADTIPO_FAMILIAR) Or (Opciones.EntidadTipoProveedor And EntidadTipo = Constantes.ENTIDADTIPO_PROVEEDOR) Or (Opciones.EntidadTipoOtro And EntidadTipo = Constantes.ENTIDADTIPO_OTRO) Then
                    GruposDeTipoVerificadosEnOutlook.Add(EntidadTipo)
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
                        CS_Error.ProcessError(ex, "Error al filtrar las Entidades por Tipo.")
                        Entidades = Nothing
                        Return False
                    End Try
                    EntidadesSincronizarOutlookGruposABM.ActualizarGrupo(OutlookApplication, OutlookDistListItem, String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, EntidadTipoANombre(EntidadTipo)), Entidades, ProgressBarProgreso)
                Else
                    ' No hay que sincronizar este grupo, por lo tanto se borra de Outlook
                    EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Type not selected")
                End If
            Else
                ' Es un grupo de Tipo pero tiene mal especificado el Tipo
                EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Type field wrong format")
            End If
        End If
        Entidades = Nothing
        Return True
    End Function

    Private Function VerificarGrupoDeNivel(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByRef OutlookUserProperty As Outlook.UserProperty, ByRef dbContext As CSColegioContext, ByRef GruposDeNivelVerificadosEnOutlook As List(Of Byte), ByRef Entidades As List(Of Entidad), ByRef Opciones As EntidadesSincronizarOutlookOpciones, ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim IDNivel As Byte
        Dim NivelActual As Nivel

        Byte.TryParse(OutlookUserProperty.Value.ToString, IDNivel)
        If IDNivel > 0 Then
            If GruposDeNivelVerificadosEnOutlook.Contains(IDNivel) Then
                ' Ya fue verificado, por lo tanto, está duplicado, hay que borrarlo
                EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Duplicated")
            Else
                GruposDeNivelVerificadosEnOutlook.Add(IDNivel)
                NivelActual = dbContext.Nivel.Find(IDNivel)
                If NivelActual Is Nothing OrElse NivelActual.EsActivo = False Then
                    ' No existe el Grupo en la base de datos o está incativo, lo elimino de Outlook
                    EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Doesn't exists anymore in DB or is inactive")
                Else
                    ' Verifico y actualizo las propiedades del grupo
                    EntidadesSincronizarOutlookGruposABM.ActualizarGrupo(OutlookApplication, OutlookDistListItem, NivelActual.Nombre, Entidades, ProgressBarProgreso)
                End If
            End If
        Else
            ' El IDNivel Especificado tiene un formato erroneo
            EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "IDNivel field wrong format")
        End If
        Return True
    End Function

    Private Function VerificarGrupoDeCurso(ByRef OutlookApplication As Outlook.Application, ByRef OutlookDistListItem As Outlook.DistListItem, ByRef OutlookUserProperty As Outlook.UserProperty, ByRef dbContext As CSColegioContext, ByRef GruposDeCursoVerificadosEnOutlook As List(Of Byte), ByRef Entidades As List(Of Entidad), ByRef Opciones As EntidadesSincronizarOutlookOpciones, ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim IDCurso As Byte
        Dim CursoActual As Curso

        Byte.TryParse(OutlookUserProperty.Value.ToString, IDCurso)
        If IDCurso > 0 Then
            If GruposDeCursoVerificadosEnOutlook.Contains(IDCurso) Then
                ' Ya fue verificado, por lo tanto, está duplicado, hay que borrarlo
                EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Duplicated")
            Else
                GruposDeCursoVerificadosEnOutlook.Add(IDCurso)
                CursoActual = dbContext.Curso.Find(IDCurso)
                If CursoActual Is Nothing OrElse CursoActual.EsActivo = False Then
                    ' No existe el Grupo en la base de datos o está incativo, lo elimino de Outlook
                    EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "Doesn't exists anymore in DB or is inactive")
                Else
                    ' Verifico y actualizo las propiedades del grupo
                    EntidadesSincronizarOutlookGruposABM.ActualizarGrupo(OutlookApplication, OutlookDistListItem, CursoActual.Nombre, Entidades, ProgressBarProgreso)
                End If
            End If
        Else
            ' El IDCurso Especificado tiene un formato erroneo
            EntidadesSincronizarOutlookGruposABM.BorrarGrupo(OutlookDistListItem, "IDCurso field wrong format")
        End If
        Return True
    End Function
End Module
