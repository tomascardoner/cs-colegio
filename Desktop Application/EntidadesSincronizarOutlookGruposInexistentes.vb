Imports Microsoft.Office.Interop

Module EntidadesSincronizarOutlookGruposInexistentes
    ''' <summary>
    ''' Verifico los grupos de contactos de la base de datos para ver si hay que agregar alguno
    ''' </summary>
    ''' <param name="Entidades">Entidades de la base de datos</param>
    ''' <param name="GruposDeTipoVerificadosEnOutlook">Lista de IDs de Entidades verificadas en Outlook</param>
    ''' <returns>True if succeded or False if failed</returns>
    ''' <remarks></remarks>
    Friend Function CrearGrupos(ByRef OutlookApplication As Outlook.Application, ByRef Entidades As List(Of Entidad), ByRef GruposDeTipoVerificadosEnOutlook As List(Of String), ByRef Opciones As EntidadesSincronizarOutlookOpciones, ByRef ProgressBarProgreso As ProgressBar) As Boolean
        If Opciones.EntidadTipoPersonalColegio Then
            If Not VerificarYCrearGrupoDeTipo(OutlookApplication, Entidades.Where(Function(e) e.TipoPersonalColegio).ToList, Constantes.ENTIDADTIPO_PERSONALCOLEGIO, GruposDeTipoVerificadosEnOutlook, ProgressBarProgreso) Then
                Return False
            End If
        End If

        If Opciones.EntidadTipoDocente Then
            If Not VerificarYCrearGrupoDeTipo(OutlookApplication, Entidades.Where(Function(e) e.TipoDocente).ToList, Constantes.ENTIDADTIPO_DOCENTE, GruposDeTipoVerificadosEnOutlook, ProgressBarProgreso) Then
                Return False
            End If
        End If

        If Opciones.EntidadTipoAlumno Then
            If Not VerificarYCrearGrupoDeTipo(OutlookApplication, Entidades.Where(Function(e) e.TipoAlumno).ToList, Constantes.ENTIDADTIPO_ALUMNO, GruposDeTipoVerificadosEnOutlook, ProgressBarProgreso) Then
                Return False
            End If
        End If

        If Opciones.EntidadTipoFamiliar Then
            If Not VerificarYCrearGrupoDeTipo(OutlookApplication, Entidades.Where(Function(e) e.TipoFamiliar).ToList, Constantes.ENTIDADTIPO_FAMILIAR, GruposDeTipoVerificadosEnOutlook, ProgressBarProgreso) Then
                Return False
            End If
        End If

        If Opciones.EntidadTipoProveedor Then
            If Not VerificarYCrearGrupoDeTipo(OutlookApplication, Entidades.Where(Function(e) e.TipoProveedor).ToList, Constantes.ENTIDADTIPO_PROVEEDOR, GruposDeTipoVerificadosEnOutlook, ProgressBarProgreso) Then
                Return False
            End If
        End If

        If Opciones.EntidadTipoOtro Then
            If Not VerificarYCrearGrupoDeTipo(OutlookApplication, Entidades.Where(Function(e) e.TipoOtro).ToList, Constantes.ENTIDADTIPO_OTRO, GruposDeTipoVerificadosEnOutlook, ProgressBarProgreso) Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Function VerificarYCrearGrupoDeTipo(ByRef OutlookApplication As Outlook.Application, ByRef Entidades As List(Of Entidad), ByVal EntidadTipo As String, ByRef GruposDeTipoVerificadosEnOutlook As List(Of String), ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim OutlookDistListItem As Outlook.DistListItem = Nothing

        If GruposDeTipoVerificadosEnOutlook.Contains(EntidadTipo) Then
            Return True
        Else
            If EntidadesSincronizarOutlookGruposABM.CrearGrupo(OutlookApplication, OutlookDistListItem, Constantes.OUTLOOK_USERPROPERTYNAME_GRUPO_TIPO, EntidadTipo) Then
                If EntidadesSincronizarOutlookGruposABM.ActualizarGrupo(OutlookApplication, OutlookDistListItem, String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, EntidadTipoANombre(EntidadTipo)), Entidades, ProgressBarProgreso) Then
                    Return True
                End If
            End If
            Return False
        End If
    End Function
End Module
