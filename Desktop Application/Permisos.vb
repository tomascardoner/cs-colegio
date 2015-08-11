Module Permisos
    Friend Const NIVEL As String = "NIVEL"
    Friend Const ANIO As String = "ANIO"
    Friend Const TURNO As String = "TURNO"
    Friend Const CURSO As String = "CURSO"
    Friend Const BANCO As String = "BANCO"
    Friend Const RELACIONTIPO As String = "RELACIONTIPO"

    Friend Const ENTIDAD As String = "ENTIDAD"
    Friend Const ENTIDAD_AGREGAR As String = "ENTIDAD_AGREGAR"
    Friend Const ENTIDAD_EDITAR As String = "ENTIDAD_EDITAR"
    Friend Const ENTIDAD_ELIMINAR As String = "ENTIDAD_ELIMINAR"

    Friend Const COMPROBANTE As String = "COMPROBANTE"
    Friend Const COMPROBANTE_AGREGAR As String = "COMPROBANTE_AGREGAR"
    Friend Const COMPROBANTE_EDITAR As String = "COMPROBANTE_EDITAR"
    Friend Const COMPROBANTE_ANULAR As String = "COMPROBANTE_ANULAR"
    Friend Const COMPROBANTE_ELIMINAR As String = "COMPROBANTE_ELIMINAR"
    Friend Const COMPROBANTE_IMPRIMIR As String = "COMPROBANTE_IMPRIMIR"
    Friend Const COMPROBANTE_GENERARLOTE As String = "COMPROBANTE_GENERARLOTE"
    Friend Const COMPROBANTE_TRANSMITIRAAFIP As String = "COMPROBANTE_TRANSMITIRAAFIP"
    Friend Const COMPROBANTE_ENVIAREMAIL As String = "COMPROBANTE_ENVIAREMAIL"

    Friend Const ENTIDADANIOLECTIVOCURSO As String = "ENTIDADANIOLECTIVOCURSO"
    Friend Const ENTIDADANIOLECTIVOCURSO_AGREGAR As String = "ENTIDADANIOLECTIVOCURSO_AGREGAR"
    Friend Const ENTIDADANIOLECTIVOCURSO_ELIMINAR As String = "ENTIDADANIOLECTIVOCURSO_ELIMINAR"
    Friend Const ENTIDADANIOLECTIVOCURSO_IMPRIMIR As String = "ENTIDADANIOLECTIVOCURSO_IMPRIMIR"

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
