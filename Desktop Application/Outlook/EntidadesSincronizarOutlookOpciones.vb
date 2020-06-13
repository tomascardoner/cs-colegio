Public Class EntidadesSincronizarOutlookOpciones
    Public Property EntidadTipoPersonalColegio As Boolean
    Public Property EntidadTipoDocente As Boolean
    Public Property EntidadTipoAlumno As Boolean
    Public Property EntidadTipoFamiliar As Boolean
    Public Property EntidadTipoProveedor As Boolean
    Public Property EntidadTipoOtro As Boolean

    Public Property GrupoContactosInexistenteBorrar As Boolean
    Public Property ContactoInexistenteBorrar As Boolean

    Public Property SincronizarGrupoContactosPorEntidadTipos As Boolean
    Public Property SincronizarGrupoContactosPorNivelesYCursos As Boolean

    Public Property AniosLectivos As New List(Of Short)

    Friend Sub LoadFromSettings()
        Dim AnioLectivoShort As Short

        EntidadTipoPersonalColegio = pOutlookContactsSyncConfig.EntidadTipoPersonalColegioAsBoolean
        EntidadTipoDocente = pOutlookContactsSyncConfig.EntidadTipoDocenteAsBoolean
        EntidadTipoAlumno = pOutlookContactsSyncConfig.EntidadTipoAlumnoAsBoolean
        EntidadTipoFamiliar = pOutlookContactsSyncConfig.EntidadTipoFamiliarAsBoolean
        EntidadTipoProveedor = pOutlookContactsSyncConfig.EntidadTipoProveedorAsBoolean
        EntidadTipoOtro = pOutlookContactsSyncConfig.EntidadTipoOtroAsBoolean

        GrupoContactosInexistenteBorrar = pOutlookContactsSyncConfig.GrupoNoEncontradoBorrarAsBoolean
        ContactoInexistenteBorrar = pOutlookContactsSyncConfig.ContactoNoEncontradoBorrarAsBoolean

        SincronizarGrupoContactosPorEntidadTipos = pOutlookContactsSyncConfig.GruposEntidadTipoAsBoolean
        SincronizarGrupoContactosPorNivelesYCursos = pOutlookContactsSyncConfig.GruposNivelYCursoAsBoolean

        ' Cargo los Años Lectivos
        'For Each AnioLectivoString As String In My.Settings.Outlook_ContactsSync_AniosLectivos.Split(CardonerSistemas.Constants.STRING_LIST_SEPARATOR)
        '    If Short.TryParse(AnioLectivoString, AnioLectivoShort) Then
        '        AniosLectivos.Add(AnioLectivoShort)
        '    End If
        'Next
        'AniosLectivos = AniosLectivos.OrderBy(Function(x) x).ToList()
    End Sub
End Class
