Imports Microsoft.Office.Interop

Module EntidadesSincronizarOutlookGruposInexistentes
    Friend Function VerificarYCrearGruposDeTiposDeEntidad(ByRef OutlookApplication As Outlook.Application, ByRef Entidades As List(Of Entidad), ByRef GruposDeTipoDeEntidadVerificadosEnOutlook As List(Of String), ByRef Opciones As EntidadesSincronizarOutlookOpciones, ByRef ProgressBarProgreso As ProgressBar) As Boolean
        If Opciones.SincronizarGrupoContactosPorEntidadTipos AndAlso Opciones.EntidadTipoPersonalColegio Then
            If Not VerificarYCrearGrupoDeTipoDeEntidad(OutlookApplication, Entidades.Where(Function(e) e.TipoPersonalColegio).ToList, Constantes.ENTIDADTIPO_PERSONALCOLEGIO, GruposDeTipoDeEntidadVerificadosEnOutlook, ProgressBarProgreso) Then
                Return False
            End If
        End If

        If Opciones.SincronizarGrupoContactosPorEntidadTipos AndAlso Opciones.EntidadTipoDocente Then
            If Not VerificarYCrearGrupoDeTipoDeEntidad(OutlookApplication, Entidades.Where(Function(e) e.TipoDocente).ToList, Constantes.ENTIDADTIPO_DOCENTE, GruposDeTipoDeEntidadVerificadosEnOutlook, ProgressBarProgreso) Then
                Return False
            End If
        End If

        If Opciones.SincronizarGrupoContactosPorEntidadTipos AndAlso Opciones.EntidadTipoAlumno Then
            If Not VerificarYCrearGrupoDeTipoDeEntidad(OutlookApplication, Entidades.Where(Function(e) e.TipoAlumno).ToList, Constantes.ENTIDADTIPO_ALUMNO, GruposDeTipoDeEntidadVerificadosEnOutlook, ProgressBarProgreso) Then
                Return False
            End If
        End If

        If Opciones.SincronizarGrupoContactosPorEntidadTipos AndAlso Opciones.EntidadTipoFamiliar Then
            If Not VerificarYCrearGrupoDeTipoDeEntidad(OutlookApplication, Entidades.Where(Function(e) e.TipoFamiliar).ToList, Constantes.ENTIDADTIPO_FAMILIAR, GruposDeTipoDeEntidadVerificadosEnOutlook, ProgressBarProgreso) Then
                Return False
            End If
        End If

        If Opciones.SincronizarGrupoContactosPorEntidadTipos AndAlso Opciones.EntidadTipoProveedor Then
            If Not VerificarYCrearGrupoDeTipoDeEntidad(OutlookApplication, Entidades.Where(Function(e) e.TipoProveedor).ToList, Constantes.ENTIDADTIPO_PROVEEDOR, GruposDeTipoDeEntidadVerificadosEnOutlook, ProgressBarProgreso) Then
                Return False
            End If
        End If

        If Opciones.SincronizarGrupoContactosPorEntidadTipos AndAlso Opciones.EntidadTipoOtro Then
            If Not VerificarYCrearGrupoDeTipoDeEntidad(OutlookApplication, Entidades.Where(Function(e) e.TipoOtro).ToList, Constantes.ENTIDADTIPO_OTRO, GruposDeTipoDeEntidadVerificadosEnOutlook, ProgressBarProgreso) Then
                Return False
            End If
        End If
        Return True
    End Function

    Private Function VerificarYCrearGrupoDeTipoDeEntidad(ByRef OutlookApplication As Outlook.Application, ByRef Entidades As List(Of Entidad), ByVal EntidadTipo As String, ByRef GruposDeTipoVerificadosEnOutlook As List(Of String), ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim OutlookDistListItem As Outlook.DistListItem = Nothing

        If GruposDeTipoVerificadosEnOutlook.Contains(EntidadTipo) Then
            Return True
        Else
            If EntidadesSincronizarOutlookGruposABM.CrearGrupoDeTipoDeEntidad(OutlookApplication, OutlookDistListItem, EntidadTipo) Then
                If EntidadesSincronizarOutlookGruposABM.ActualizarGrupo(OutlookApplication, OutlookDistListItem, String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, EntidadTipoANombre(EntidadTipo)), Entidades, ProgressBarProgreso) Then
                    Return True
                End If
            End If
            Return False
        End If
    End Function

    Friend Function VerificarYCrearGruposDeNiveles(ByRef OutlookApplication As Outlook.Application, ByRef Entidades As List(Of Entidad), ByRef GruposDeNivelVerificadosEnOutlook As List(Of ValueTuple(Of Short, Byte)), ByRef Opciones As EntidadesSincronizarOutlookOpciones, ByRef ProgressBarProgreso As ProgressBar) As Boolean
        If Opciones.SincronizarGrupoContactosPorNivelesYCursos Then
            For Each AnioLectivoActual As Short In Opciones.AniosLectivos

            Next
        End If
    End Function

    Private Function VerificarYCrearGrupoDeNivel(ByRef OutlookApplication As Outlook.Application, ByRef Entidades As List(Of Entidad), ByVal AnioLectivo As Short, ByVal IDNivel As Byte, ByVal GrupoNombre As String, ByRef GruposDeNivelVerificadosEnOutlook As List(Of ValueTuple(Of Short, Byte)), ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim OutlookDistListItem As Outlook.DistListItem = Nothing

        If GruposDeNivelVerificadosEnOutlook.Any(Function(t) t.Item1 = AnioLectivo AndAlso t.Item2 = IDNivel) Then
            Return True
        Else
            If EntidadesSincronizarOutlookGruposABM.CrearGrupoDeNivel(OutlookApplication, OutlookDistListItem, AnioLectivo, IDNivel) Then
                If EntidadesSincronizarOutlookGruposABM.ActualizarGrupo(OutlookApplication, OutlookDistListItem, String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, GrupoNombre), Entidades, ProgressBarProgreso) Then
                    Return True
                End If
            End If
            Return False
        End If
    End Function

    Friend Function VerificarYCrearGrupoDeCurso(ByRef OutlookApplication As Outlook.Application, ByRef Entidades As List(Of Entidad), ByVal AnioLectivo As Short, ByVal IDCurso As Byte, ByVal GrupoNombre As String, ByRef GruposDeCursoVerificadosEnOutlook As List(Of ValueTuple(Of Short, Byte)), ByRef ProgressBarProgreso As ProgressBar) As Boolean
        Dim OutlookDistListItem As Outlook.DistListItem = Nothing

        If GruposDeCursoVerificadosEnOutlook.Any(Function(t) t.Item1 = AnioLectivo AndAlso t.Item2 = IDCurso) Then
            Return True
        Else
            If EntidadesSincronizarOutlookGruposABM.CrearGrupoDeNivel(OutlookApplication, OutlookDistListItem, AnioLectivo, IDCurso) Then
                If EntidadesSincronizarOutlookGruposABM.ActualizarGrupo(OutlookApplication, OutlookDistListItem, String.Format(My.Settings.Outlook_ContactsSync_GrupoNombre, GrupoNombre), Entidades, ProgressBarProgreso) Then
                    Return True
                End If
            End If
            Return False
        End If
    End Function
End Module
