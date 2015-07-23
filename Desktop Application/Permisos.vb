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

    Friend Const COMPROBANTE As String = "COMPROBANTE"
    Friend Const COMPROBANTE_ADD As String = "COMPROBANTE_ADD"
    Friend Const COMPROBANTE_EDIT As String = "COMPROBANTE_EDIT"
    Friend Const COMPROBANTE_DELETE As String = "COMPROBANTE_DELETE"
    Friend Const COMPROBANTE_PRINT As String = "COMPROBANTE_PRINT"
    Friend Const COMPROBANTE_GENERARLOTE As String = "COMPROBANTE_GENERARLOTE"
    Friend Const COMPROBANTE_TRANSMITIRAAFIP As String = "COMPROBANTE_TRANSMITIRAAFIP"
    Friend Const COMPROBANTE_ENVIAREMAIL As String = "COMPROBANTE_ENVIAREMAIL"

    Friend Const ENTIDADANIOLECTIVOCURSO As String = "ENTIDADANIOLECTIVOCURSO"
    Friend Const ENTIDADANIOLECTIVOCURSO_ADD As String = "ENTIDADANIOLECTIVOCURSO_ADD"
    Friend Const ENTIDADANIOLECTIVOCURSO_DELETE As String = "ENTIDADANIOLECTIVOCURSO_DELETE"

    Friend Const REPORTE As String = "REPORTE"

    Friend Function VerificarPermiso(ByVal IDPermiso As String, Optional ByVal MostrarAviso As Boolean = True) As Boolean
        If pUsuario.IDUsuario = 1 Then
            Return True
        Else
            If pPermisos.Find(Function(usrper) usrper.IDUsuarioGrupo = pUsuario.IDUsuarioGrupo And usrper.IDPermiso.TrimEnd = IDPermiso) Is Nothing Then
                MsgBox("No tiene autorización para realizar esta acción.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                Return False
            Else
                Return True
            End If
        End If
    End Function
End Module
