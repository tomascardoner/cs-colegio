Public Class OutlookContactsSyncConfig
    Public Property EntidadTipoPersonalColegio As String
    Public Property EntidadTipoDocente As String
    Public Property EntidadTipoAlumno As String
    Public Property EntidadTipoFamiliar As String
    Public Property EntidadTipoProveedor As String
    Public Property EntidadTipoOtro As String
    Public Property GrupoNoEncontradoBorrar As String
    Public Property ContactoNoEncontradoBorrar As String
    Public Property GruposEntidadTipo As String
    Public Property GruposNivelYCurso As String
    Public Property GrupoNombre As String

    Friend Property EntidadTipoPersonalColegioAsBoolean As Boolean
        Get
            Boolean.TryParse(EntidadTipoPersonalColegio, EntidadTipoPersonalColegioAsBoolean)
        End Get
        Set(value As Boolean)
            EntidadTipoPersonalColegio = value.ToString()
        End Set
    End Property

    Friend Property EntidadTipoDocenteAsBoolean As Boolean
        Get
            Boolean.TryParse(EntidadTipoDocente, EntidadTipoDocenteAsBoolean)
        End Get
        Set(value As Boolean)
            EntidadTipoDocente = value.ToString()
        End Set
    End Property

    Friend Property EntidadTipoAlumnoAsBoolean As Boolean
        Get
            Boolean.TryParse(EntidadTipoAlumno, EntidadTipoAlumnoAsBoolean)
        End Get
        Set(value As Boolean)
            EntidadTipoAlumno = value.ToString()
        End Set
    End Property

    Friend Property EntidadTipoFamiliarAsBoolean As Boolean
        Get
            Boolean.TryParse(EntidadTipoFamiliar, EntidadTipoFamiliarAsBoolean)
        End Get
        Set(value As Boolean)
            EntidadTipoFamiliar = value.ToString()
        End Set
    End Property

    Friend Property EntidadTipoProveedorAsBoolean As Boolean
        Get
            Boolean.TryParse(EntidadTipoProveedor, EntidadTipoProveedorAsBoolean)
        End Get
        Set(value As Boolean)
            EntidadTipoProveedor = value.ToString()
        End Set
    End Property

    Friend Property EntidadTipoOtroAsBoolean As Boolean
        Get
            Boolean.TryParse(EntidadTipoOtro, EntidadTipoOtroAsBoolean)
        End Get
        Set(value As Boolean)
            EntidadTipoOtro = value.ToString()
        End Set
    End Property

    Friend Property GrupoNoEncontradoBorrarAsBoolean As Boolean
        Get
            Boolean.TryParse(GrupoNoEncontradoBorrar, GrupoNoEncontradoBorrarAsBoolean)
        End Get
        Set(value As Boolean)
            GrupoNoEncontradoBorrar = value.ToString()
        End Set
    End Property

    Friend Property ContactoNoEncontradoBorrarAsBoolean As Boolean
        Get
            Boolean.TryParse(ContactoNoEncontradoBorrar, ContactoNoEncontradoBorrarAsBoolean)
        End Get
        Set(value As Boolean)
            ContactoNoEncontradoBorrar = value.ToString()
        End Set
    End Property

    Friend Property GruposEntidadTipoAsBoolean As Boolean
        Get
            Boolean.TryParse(GruposEntidadTipo, GruposEntidadTipoAsBoolean)
        End Get
        Set(value As Boolean)
            GruposEntidadTipo = value.ToString()
        End Set
    End Property

    Friend Property GruposNivelYCursoAsBoolean As Boolean
        Get
            Boolean.TryParse(GruposNivelYCurso, GruposNivelYCursoAsBoolean)
        End Get
        Set(value As Boolean)
            GruposNivelYCurso = value.ToString()
        End Set
    End Property

End Class
