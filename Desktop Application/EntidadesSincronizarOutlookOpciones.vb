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
End Class
