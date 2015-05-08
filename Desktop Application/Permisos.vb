Module Permisos
    Friend Const NIVEL As String = "NIVEL"
    Friend Const ANIO As String = "ANIO"
    Friend Const TURNO As String = "TURNO"
    Friend Const CURSO As String = "CURSO"
    Friend Const BANCO As String = "BANCO"
    Friend Const RELACIONTIPO As String = "RELACIONTIPO"

    Friend Const ENTIDAD As String = "ENTIDAD"
    Friend Const ENTIDAD_ADD As String = "ENTIDAD_ADD"
    Friend Const ENTIDAD_EDIT As String = "ENTIDAD_EDIT"
    Friend Const ENTIDAD_DELETE As String = "ENTIDAD_DELETE"

    Friend Function VerificarPermiso(ByVal IDPermiso As String, Optional ByVal MostrarAviso As Boolean = True) As Boolean
        If pUsuario.IDUsuario = 1 Then
            Return True
        Else
            If pCSColegioContext.UsuarioGrupoPermiso.Find(pUsuario.IDUsuarioGrupo, IDPermiso) Is Nothing Then
                MsgBox("No tiene autorización para realizar esta acción.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Return False
            Else
                Return True
            End If
        End If
    End Function
End Module
