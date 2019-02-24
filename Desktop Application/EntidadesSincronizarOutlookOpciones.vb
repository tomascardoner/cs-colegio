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

        EntidadTipoPersonalColegio = My.Settings.Outlook_ContactsSync_EntidadTipo_PersonalColegio
        EntidadTipoDocente = My.Settings.Outlook_ContactsSync_EntidadTipo_Docente
        EntidadTipoAlumno = My.Settings.Outlook_ContactsSync_EntidadTipo_Alumno
        EntidadTipoFamiliar = My.Settings.Outlook_ContactsSync_EntidadTipo_Familiar
        EntidadTipoProveedor = My.Settings.Outlook_ContactsSync_EntidadTipo_Proveedor
        EntidadTipoOtro = My.Settings.Outlook_ContactsSync_EntidadTipo_Otro

        GrupoContactosInexistenteBorrar = My.Settings.Outlook_ContactsSync_GrupoNoEncontrado_Borrar
        ContactoInexistenteBorrar = My.Settings.Outlook_ContactsSync_ContactoNoEncontrado_Borrar

        SincronizarGrupoContactosPorEntidadTipos = My.Settings.Outlook_ContactsSync_SincronizarGrupos_EntidadTipo
        SincronizarGrupoContactosPorNivelesYCursos = My.Settings.Outlook_ContactsSync_SincronizarGrupos_NivelYCurso

        ' Cargo los Años Lectivos
        For Each AnioLectivoString As String In My.Settings.Outlook_ContactsSync_AniosLectivos.Split(CS_Constants.STRING_LIST_SEPARATOR)
            If Short.TryParse(AnioLectivoString, AnioLectivoShort) Then
                AniosLectivos.Add(AnioLectivoShort)
            End If
        Next
        AniosLectivos = AniosLectivos.OrderBy(Function(x) x).ToList()
    End Sub
End Class
