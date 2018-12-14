Public Class EntidadesSincronizarOutlookOpciones
    Public Property EntidadTipoPersonalColegio As Boolean
    Public Property EntidadTipoDocente As Boolean
    Public Property EntidadTipoAlumno As Boolean
    Public Property EntidadTipoFamiliar As Boolean
    Public Property EntidadTipoProveedor As Boolean
    Public Property EntidadTipoOtro As Boolean

    Public Property GrupoContactosInexistenteBorrar As Boolean
    Public Property ContactoInexistenteBorrar As Boolean

    Public Property CrearGrupoContactosPorEntidadTipos As Boolean
    Public Property CrearGrupoContactosPorNivelesYCursos As Boolean

    Public Property AniosLectivos As List(Of Short)

    Friend Sub LoadFromSettings()
        EntidadTipoPersonalColegio = My.Settings.Outlook_ContactsSync_EntidadTipo_PersonalColegio
        EntidadTipoDocente = My.Settings.Outlook_ContactsSync_EntidadTipo_Docente
        EntidadTipoAlumno = My.Settings.Outlook_ContactsSync_EntidadTipo_Alumno
        EntidadTipoFamiliar = My.Settings.Outlook_ContactsSync_EntidadTipo_Familiar
        EntidadTipoProveedor = My.Settings.Outlook_ContactsSync_EntidadTipo_Proveedor
        EntidadTipoOtro = My.Settings.Outlook_ContactsSync_EntidadTipo_Otro

        GrupoContactosInexistenteBorrar = My.Settings.Outlook_ContactsSync_GrupoNoEncontrado_Borrar
        ContactoInexistenteBorrar = My.Settings.Outlook_ContactsSync_ContactoNoEncontrado_Borrar

        CrearGrupoContactosPorEntidadTipos = My.Settings.Outlook_ContactsSync_CrearGrupos_EntidadTipo
        CrearGrupoContactosPorNivelesYCursos = My.Settings.Outlook_ContactsSync_CrearGrupos_NivelYCurso
    End Sub
End Class
