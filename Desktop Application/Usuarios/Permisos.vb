Module Permisos

#Region "Definición de constantes"

    Friend Const DESCRIPCION_AGREGAR As String = "Agregar"
    Friend Const DESCRIPCION_EDITAR As String = "Editar"
    Friend Const DESCRIPCION_ELIMINAR As String = "Eliminar"
    Friend Const DESCRIPCION_IMPRIMIR As String = "Imprimir"

    Friend Const USUARIOGRUPO As String = "USUARIOGRUPO"
    Friend Const USUARIOGRUPO_AGREGAR As String = "USUARIOGRUPO_AGREGAR"
    Friend Const USUARIOGRUPO_EDITAR As String = "USUARIOGRUPO_EDITAR"
    Friend Const USUARIOGRUPO_ELIMINAR As String = "USUARIOGRUPO_ELIMINAR"

    Friend Const USUARIOGRUPOPERMISO As String = "USUARIOGRUPOPERMISO"

    Friend Const USUARIO As String = "USUARIO"
    Friend Const USUARIO_AGREGAR As String = "USUARIO_AGREGAR"
    Friend Const USUARIO_EDITAR As String = "USUARIO_EDITAR"
    Friend Const USUARIO_ELIMINAR As String = "USUARIO_ELIMINAR"
    Friend Const USUARIO_CAMBIARCLAVE As String = "USUARIO_CAMBIARCLAVE"

    Friend Const NIVEL As String = "NIVEL"
    Friend Const NIVEL_AGREGAR As String = "NIVEL_AGREGAR"
    Friend Const NIVEL_EDITAR As String = "NIVEL_EDITAR"
    Friend Const NIVEL_ELIMINAR As String = "NIVEL_ELIMINAR"

    Friend Const ANIO As String = "ANIO"
    Friend Const ANIO_AGREGAR As String = "ANIO_AGREGAR"
    Friend Const ANIO_EDITAR As String = "ANIO_EDITAR"
    Friend Const ANIO_ELIMINAR As String = "ANIO_ELIMINAR"

    Friend Const TURNO As String = "TURNO"
    Friend Const TURNO_AGREGAR As String = "TURNO_AGREGAR"
    Friend Const TURNO_EDITAR As String = "TURNO_EDITAR"
    Friend Const TURNO_ELIMINAR As String = "TURNO_ELIMINAR"

    Friend Const CURSO As String = "CURSO"
    Friend Const CURSO_AGREGAR As String = "CURSO_AGREGAR"
    Friend Const CURSO_EDITAR As String = "CURSO_EDITAR"
    Friend Const CURSO_ELIMINAR As String = "CURSO_ELIMINAR"

    Friend Const ANIOLECTIVOCURSO As String = "ANIOLECTIVOCURSO"
    Friend Const ANIOLECTIVOCURSO_AGREGAR As String = "ANIOLECTIVOCURSO_AGREGAR"
    Friend Const ANIOLECTIVOCURSO_EDITAR As String = "ANIOLECTIVOCURSO_EDITAR"
    Friend Const ANIOLECTIVOCURSO_ELIMINAR As String = "ANIOLECTIVOCURSO_ELIMINAR"

    Friend Const ANIOLECTIVOCURSOIMPORTE As String = "ANIOLECTIVOCURSOIMPORTE"
    Friend Const ANIOLECTIVOCURSOIMPORTE_AGREGAR As String = "ANIOLECTIVOCURSOIMPORTE_AGREGAR"
    Friend Const ANIOLECTIVOCURSOIMPORTE_EDITAR As String = "ANIOLECTIVOCURSOIMPORTE_EDITAR"
    Friend Const ANIOLECTIVOCURSOIMPORTE_ELIMINAR As String = "ANIOLECTIVOCURSOIMPORTE_ELIMINAR"

    Friend Const ANIOLECTIVOCUOTA As String = "ANIOLECTIVOCUOTA"
    Friend Const ANIOLECTIVOCUOTA_AGREGAR As String = "ANIOLECTIVOCUOTA_AGREGAR"
    Friend Const ANIOLECTIVOCUOTA_EDITAR As String = "ANIOLECTIVOCUOTA_EDITAR"
    Friend Const ANIOLECTIVOCUOTA_ELIMINAR As String = "ANIOLECTIVOCUOTA_ELIMINAR"

    Friend Const BANCO As String = "BANCO"
    Friend Const BANCO_AGREGAR As String = "BANCO_AGREGAR"
    Friend Const BANCO_EDITAR As String = "BANCO_EDITAR"
    Friend Const BANCO_ELIMINAR As String = "BANCO_ELIMINAR"

    Friend Const RELACIONTIPO As String = "RELACIONTIPO"
    Friend Const RELACIONTIPO_AGREGAR As String = "RELACIONTIPO_AGREGAR"
    Friend Const RELACIONTIPO_EDITAR As String = "RELACIONTIPO_EDITAR"
    Friend Const RELACIONTIPO_ELIMINAR As String = "RELACIONTIPO_ELIMINAR"

    Friend Const ENTIDAD As String = "ENTIDAD"
    Friend Const ENTIDAD_AGREGAR As String = "ENTIDAD_AGREGAR"
    Friend Const ENTIDAD_EDITAR As String = "ENTIDAD_EDITAR"
    Friend Const ENTIDAD_ELIMINAR As String = "ENTIDAD_ELIMINAR"
    Friend Const ENTIDAD_VERIFICACIONES_VER As String = "ENTIDAD_VERIFICACIONES_VER"
    Friend Const ENTIDAD_SINCRONIZAR_OUTLOOK As String = "ENTIDAD_SINCRONIZAR_OUTLOOK"
    Friend Const ENTIDAD_SINCRONIZAR_OUTLOOK_EDITAROPCIONES As String = "ENTIDAD_SINCRONIZAR_OUTLOOK_EDITAROPCIONES"

    Friend Const COMPROBANTE As String = "COMPROBANTE"
    Friend Const COMPROBANTE_AGREGAR As String = "COMPROBANTE_AGREGAR"
    Friend Const COMPROBANTE_EDITAR As String = "COMPROBANTE_EDITAR"
    Friend Const COMPROBANTE_ANULAR As String = "COMPROBANTE_ANULAR"
    Friend Const COMPROBANTE_ELIMINAR As String = "COMPROBANTE_ELIMINAR"
    Friend Const COMPROBANTE_IMPRIMIR As String = "COMPROBANTE_IMPRIMIR"
    Friend Const COMPROBANTE_IMPRIMIR_SINCAE As String = "COMPROBANTE_IMPRIMIR_SINCAE"
    Friend Const COMPROBANTE_GENERARLOTE As String = "COMPROBANTE_GENERARLOTE"
    Friend Const COMPROBANTE_TRANSMITIR_AFIP As String = "COMPROBANTE_TRANSMITIR_AFIP"
    Friend Const COMPROBANTE_ENVIAREMAIL As String = "COMPROBANTE_ENVIAREMAIL"
    Friend Const COMPROBANTE_EXPORTAR_PAGOMISCUENTAS As String = "COMPROBANTE_EXPORTAR_PAGOMISCUENTAS"
    Friend Const COMPROBANTE_EXPORTAR_PAGOSEDUC As String = "COMPROBANTE_EXPORTAR_PAGOSEDUC"
    Friend Const COMPROBANTE_EXPORTAR_SANTANDERDEBITODIRECTO As String = "COMPROBANTE_EXPORTAR_SANTANDERDEBITODIRECTO"
    Friend Const COMPROBANTE_EXPORTAR_SANTANDERRECAUDACIONPORCAJA As String = "COMPROBANTE_EXPORTAR_SANTANDERRECAUDACIONPORCAJA"
    Friend Const COMPROBANTE_IMPORTAR_SANTANDERDEBITODIRECTO As String = "COMPROBANTE_IMPORTAR_SANTANDERDEBITODIRECTO"
    Friend Const COMPROBANTE_IMPORTAR_SANTANDERRECAUDACIONPORCAJA As String = "COMPROBANTE_IMPORTAR_SANTANDERRECAUDACIONPORCAJA"
    Friend Const COMPROBANTE_DETALLE_PERMITE_MATRICULAANIOANTERIOR As String = "COMPROBANTE_DETALLE_PERMITE_MATRICULAANIOANTERIOR"
    Friend Const COMPROBANTE_DETALLE_PERMITE_CUOTAANIOSIGUIENTE As String = "COMPROBANTE_DETALLE_PERMITE_CUOTAANIOSIGUIENTE"
    Friend Const COMPROBANTE_DETALLE_PERMITE_CUOTAANIOANTERIORYSIGUIENTE As String = "COMPROBANTE_DETALLE_PERMITE_CUOTAANIOANTERIORYSIGUIENTE"

    Friend Const SUELDO_LIQUIDACION As String = "SUELDO_LIQUIDACION"
    Friend Const SUELDO_LIQUIDACION_AGREGAR As String = "SUELDO_LIQUIDACION_AGREGAR"
    Friend Const SUELDO_LIQUIDACION_EDITAR As String = "SUELDO_LIQUIDACION_EDITAR"
    Friend Const SUELDO_LIQUIDACION_ELIMINAR As String = "SUELDO_LIQUIDACION_ELIMINAR"

    Friend Const SUELDO_LIQUIDACION_ENTIDAD As String = "SUELDO_LIQUIDACION_ENTIDAD"
    Friend Const SUELDO_LIQUIDACION_ENTIDAD_AGREGAR As String = "SUELDO_LIQUIDACION_ENTIDAD_AGREGAR"
    Friend Const SUELDO_LIQUIDACION_ENTIDAD_EDITAR As String = "SUELDO_LIQUIDACION_ENTIDAD_EDITAR"
    Friend Const SUELDO_LIQUIDACION_ENTIDAD_ELIMINAR As String = "SUELDO_LIQUIDACION_ENTIDAD_ELIMINAR"

    Friend Const SUELDO_LIQUIDACION_ENTIDAD_RECIBO As String = "SUELDO_LIQUIDACION_ENTIDAD_RECIBO"
    Friend Const SUELDO_LIQUIDACION_ENTIDAD_RECIBO_AGREGAR As String = "SUELDO_LIQUIDACION_ENTIDAD_RECIBO_AGREGAR"
    Friend Const SUELDO_LIQUIDACION_ENTIDAD_RECIBO_EDITAR As String = "SUELDO_LIQUIDACION_ENTIDAD_RECIBO_EDITAR"
    Friend Const SUELDO_LIQUIDACION_ENTIDAD_RECIBO_ELIMINAR As String = "SUELDO_LIQUIDACION_ENTIDAD_RECIBO_ELIMINAR"

    Friend Const SUELDO_CALCULOMODULO As String = "SUELDO_CALCULOMODULO"
    Friend Const SUELDO_CALCULOMODULO_AGREGAR As String = "SUELDO_CALCULOMODULO_AGREGAR"
    Friend Const SUELDO_CALCULOMODULO_EDITAR As String = "SUELDO_CALCULOMODULO_EDITAR"
    Friend Const SUELDO_CALCULOMODULO_ELIMINAR As String = "SUELDO_CALCULOMODULO_ELIMINAR"

    Friend Const COMUNICACION As String = "COMUNICACION"
    Friend Const COMUNICACION_AGREGAR As String = "COMUNICACION_AGREGAR"
    Friend Const COMUNICACION_EDITAR As String = "COMUNICACION_EDITAR"
    Friend Const COMUNICACION_ELIMINAR As String = "COMUNICACION_ELIMINAR"
    Friend Const COMUNICACION_ENVIAREMAIL As String = "COMUNICACION_ENVIAREMAIL"

    Friend Const ENTIDADANIOLECTIVOCURSO As String = "ENTIDADANIOLECTIVOCURSO"
    Friend Const ENTIDADANIOLECTIVOCURSO_AGREGAR As String = "ENTIDADANIOLECTIVOCURSO_AGREGAR"
    Friend Const ENTIDADANIOLECTIVOCURSO_ELIMINAR As String = "ENTIDADANIOLECTIVOCURSO_ELIMINAR"
    Friend Const ENTIDADANIOLECTIVOCURSO_IMPRIMIR As String = "ENTIDADANIOLECTIVOCURSO_IMPRIMIR"

    Friend Const REPORTE As String = "REPORTE"

#End Region

#Region "Verificación de permisos"

    Friend Function VerificarPermiso(ByVal IDPermiso As String, Optional ByVal MostrarAviso As Boolean = True) As Boolean
        If pUsuario.IDUsuarioGrupo = USUARIOGRUPO_ADMINISTRADORES_ID Then
            Return True
        Else
            If pPermisos.Find(Function(usrper) usrper.IDUsuarioGrupo = pUsuario.IDUsuarioGrupo AndAlso usrper.IDPermiso.TrimEnd = IDPermiso) Is Nothing Then
                If MostrarAviso Then
                    MessageBox.Show("No tiene autorización para realizar esta acción.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                Return False
            Else
                Return True
            End If
        End If
    End Function

    Friend Function LoadPermisos() As Boolean
        Try
            Using dbcontext As New CSColegioContext(True)
                pPermisos = dbcontext.UsuarioGrupoPermiso.ToList
            End Using
            Return True
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al cargar los Permisos del Usuario.")
            Return False
        End Try
    End Function

#End Region

#Region "Asignación de permisos"

    Friend Function AgregarNodos(ByRef arbol As TreeView, ByRef parent As TreeNode, ByVal permissionKey As String, ByVal permissionDisplay As String, ByVal permissionAddKey As String, ByVal permissionAddDisplay As String, ByVal permissionEditKey As String, ByVal permissionEditDisplay As String, ByVal permissionDeleteKey As String, ByVal permissionDeleteDisplay As String) As TreeNode
        Dim newNode As TreeNode

        If parent Is Nothing Then
            newNode = arbol.Nodes.Add(permissionKey, permissionDisplay)
        Else
            newNode = parent.Nodes.Add(permissionKey, permissionDisplay)
        End If

        With newNode
            If permissionAddKey <> String.Empty Then
                .Nodes.Add(permissionAddKey, permissionAddDisplay)
            End If
            If permissionEditKey <> String.Empty Then
                .Nodes.Add(permissionEditKey, permissionEditDisplay)
            End If
            If permissionDeleteKey <> String.Empty Then
                .Nodes.Add(permissionDeleteKey, permissionDeleteDisplay)
            End If
        End With
        Return newNode
    End Function

    Friend Sub CargarArbolDePermisos(ByRef Arbol As TreeView, ByVal IDUsuarioGrupo As Byte)
        Dim nodeRoot As TreeNode
        Dim nodeCurrent As TreeNode

        Arbol.SuspendLayout()
        Application.DoEvents()

        Arbol.Nodes.Clear()

        ' TABLAS
        nodeRoot = Arbol.Nodes.Add("TABLAS", "Tablas")
        AgregarNodos(Arbol, nodeRoot, ANIO, "Años", ANIO_AGREGAR, DESCRIPCION_AGREGAR, ANIO_EDITAR, DESCRIPCION_EDITAR, ANIO_ELIMINAR, DESCRIPCION_ELIMINAR)
        AgregarNodos(Arbol, nodeRoot, CURSO, "Cursos", CURSO_AGREGAR, DESCRIPCION_AGREGAR, CURSO_EDITAR, DESCRIPCION_EDITAR, CURSO_ELIMINAR, DESCRIPCION_ELIMINAR)
        AgregarNodos(Arbol, nodeRoot, ANIOLECTIVOCURSO, "Años Lectivos y Cursos", ANIOLECTIVOCURSO_AGREGAR, DESCRIPCION_AGREGAR, ANIOLECTIVOCURSO_EDITAR, DESCRIPCION_EDITAR, ANIOLECTIVOCURSO_ELIMINAR, DESCRIPCION_ELIMINAR)
        AgregarNodos(Arbol, nodeRoot, ANIOLECTIVOCUOTA, "Cuotas", ANIOLECTIVOCUOTA_AGREGAR, DESCRIPCION_AGREGAR, ANIOLECTIVOCUOTA_EDITAR, DESCRIPCION_EDITAR, ANIOLECTIVOCUOTA_ELIMINAR, DESCRIPCION_ELIMINAR)
        AgregarNodos(Arbol, nodeRoot, BANCO, "Bancos", BANCO_AGREGAR, DESCRIPCION_AGREGAR, BANCO_EDITAR, DESCRIPCION_EDITAR, BANCO_ELIMINAR, DESCRIPCION_ELIMINAR)
        AgregarNodos(Arbol, nodeRoot, RELACIONTIPO, "Tipos de relación", RELACIONTIPO_AGREGAR, DESCRIPCION_AGREGAR, RELACIONTIPO_EDITAR, DESCRIPCION_EDITAR, RELACIONTIPO_ELIMINAR, DESCRIPCION_ELIMINAR)
        AgregarNodos(Arbol, nodeRoot, USUARIOGRUPO, "Grupos de usuarios", USUARIOGRUPO_AGREGAR, DESCRIPCION_AGREGAR, USUARIOGRUPO_EDITAR, DESCRIPCION_EDITAR, USUARIOGRUPO_ELIMINAR, DESCRIPCION_ELIMINAR)
        nodeRoot.Nodes.Add(USUARIOGRUPOPERMISO, "Permisos")
        AgregarNodos(Arbol, nodeRoot, USUARIO, "Usuarios", USUARIO_AGREGAR, DESCRIPCION_AGREGAR, USUARIO_EDITAR, DESCRIPCION_EDITAR, USUARIO_ELIMINAR, DESCRIPCION_ELIMINAR)

        ' ENTIDADES
        nodeRoot = AgregarNodos(Arbol, Nothing, ENTIDAD, "Entidades", ENTIDAD_AGREGAR, DESCRIPCION_AGREGAR, ENTIDAD_EDITAR, DESCRIPCION_EDITAR, ENTIDAD_ELIMINAR, DESCRIPCION_ELIMINAR)
        nodeRoot.Nodes.Add(ENTIDAD_VERIFICACIONES_VER, "Ver campos de verificación (Documentos + eMails")
        nodeRoot.Nodes.Add(ENTIDAD_SINCRONIZAR_OUTLOOK, "Sincronizar datos con Microsoft Outlook")
        nodeRoot.Nodes.Add(ENTIDAD_SINCRONIZAR_OUTLOOK_EDITAROPCIONES, "Editar opciones de sincronización de datos con Microsoft Outlook")
        nodeCurrent = AgregarNodos(Arbol, nodeRoot, ENTIDADANIOLECTIVOCURSO, "Años Lectivos y Cursos", ENTIDADANIOLECTIVOCURSO_AGREGAR, DESCRIPCION_AGREGAR, String.Empty, String.Empty, ENTIDADANIOLECTIVOCURSO_ELIMINAR, DESCRIPCION_ELIMINAR)
        nodeCurrent.Nodes.Add(ENTIDADANIOLECTIVOCURSO_IMPRIMIR, "Imprimir")

        ' COMPROBANTES
        nodeRoot = AgregarNodos(Arbol, Nothing, COMPROBANTE, "Comprobantes", COMPROBANTE_AGREGAR, DESCRIPCION_AGREGAR, COMPROBANTE_EDITAR, DESCRIPCION_EDITAR, COMPROBANTE_ELIMINAR, DESCRIPCION_ELIMINAR)
        nodeRoot.Nodes.Add(COMPROBANTE_ANULAR, "Anular")
        nodeRoot.Nodes.Add(COMPROBANTE_IMPRIMIR, "Imprimir")
        nodeRoot.Nodes.Add(COMPROBANTE_IMPRIMIR_SINCAE, "Imprimir comprobante sin autorización de AFIP")
        nodeRoot.Nodes.Add(COMPROBANTE_DETALLE_PERMITE_MATRICULAANIOANTERIOR, "Permite cargar matrícula del año anterior")
        nodeRoot.Nodes.Add(COMPROBANTE_DETALLE_PERMITE_CUOTAANIOSIGUIENTE, "Permite cargar cuota del año anterior")
        nodeRoot.Nodes.Add(COMPROBANTE_DETALLE_PERMITE_CUOTAANIOANTERIORYSIGUIENTE, "Permite cargar cuota del año anterior y del año siguiente")
        nodeRoot.Nodes.Add(COMPROBANTE_GENERARLOTE, "Generar lote")
        nodeRoot.Nodes.Add(COMPROBANTE_TRANSMITIR_AFIP, "Transmitir a AFIP")
        nodeRoot.Nodes.Add(COMPROBANTE_ENVIAREMAIL, "Enviar por e-mail")
        nodeRoot.Nodes.Add(COMPROBANTE_EXPORTAR_PAGOSEDUC, "Exportar para PagosEDUC")
        nodeRoot.Nodes.Add(COMPROBANTE_EXPORTAR_SANTANDERDEBITODIRECTO, "Exportar para Débito Directo de Santander")

        ' SUELDOS
        nodeRoot = AgregarNodos(Arbol, Nothing, SUELDO_CALCULOMODULO, "Cálculos de módulos de sueldos", SUELDO_CALCULOMODULO_AGREGAR, DESCRIPCION_AGREGAR, SUELDO_CALCULOMODULO_EDITAR, DESCRIPCION_EDITAR, SUELDO_CALCULOMODULO_ELIMINAR, DESCRIPCION_ELIMINAR)
        nodeRoot = AgregarNodos(Arbol, Nothing, SUELDO_LIQUIDACION, "Liquidaciones de sueldos", SUELDO_LIQUIDACION_AGREGAR, DESCRIPCION_AGREGAR, SUELDO_LIQUIDACION_EDITAR, DESCRIPCION_EDITAR, SUELDO_LIQUIDACION_ELIMINAR, DESCRIPCION_ELIMINAR)
        nodeRoot = AgregarNodos(Arbol, Nothing, SUELDO_LIQUIDACION_ENTIDAD, "Liquidaciones de sueldos - entidades", SUELDO_LIQUIDACION_ENTIDAD_AGREGAR, DESCRIPCION_AGREGAR, SUELDO_LIQUIDACION_ENTIDAD_EDITAR, DESCRIPCION_EDITAR, SUELDO_LIQUIDACION_ENTIDAD_ELIMINAR, DESCRIPCION_ELIMINAR)
        nodeRoot = AgregarNodos(Arbol, Nothing, SUELDO_LIQUIDACION_ENTIDAD_RECIBO, "Liquidaciones de sueldos - recibos de entidades", SUELDO_LIQUIDACION_ENTIDAD_RECIBO_AGREGAR, DESCRIPCION_AGREGAR, SUELDO_LIQUIDACION_ENTIDAD_RECIBO_EDITAR, DESCRIPCION_EDITAR, SUELDO_LIQUIDACION_ENTIDAD_RECIBO_ELIMINAR, DESCRIPCION_ELIMINAR)

        ' COMUNICACIONES
        nodeRoot = AgregarNodos(Arbol, Nothing, COMUNICACION, "Comunicaciones", COMUNICACION_AGREGAR, DESCRIPCION_AGREGAR, COMUNICACION_EDITAR, DESCRIPCION_EDITAR, COMUNICACION_ELIMINAR, DESCRIPCION_ELIMINAR)
        nodeRoot.Nodes.Add(COMUNICACION_ENVIAREMAIL, "Enviar e-mails")

        ' REPORTES
        nodeRoot.Nodes.Add(REPORTE, "Reportes")

        Arbol.TopNode = Arbol.Nodes(0)

        ' Muestro los permisos asignados
        MostrarPermisosEstablecidos(Arbol, IDUsuarioGrupo)

        Arbol.ResumeLayout()
    End Sub

    Private Sub MostrarPermisosEstablecidos(ByRef Arbol As TreeView, ByVal IDUsuarioGrupo As Byte)
        Dim listPermisos As List(Of UsuarioGrupoPermiso)

        ' Obtengo la lista de permisos para el Grupo de Usuarios
        Using dbcontext As New CSColegioContext(True)
            Try
                listPermisos = dbcontext.UsuarioGrupoPermiso.Where(Function(ugp) ugp.IDUsuarioGrupo = IDUsuarioGrupo).OrderBy(Function(ugp) ugp.IDPermiso).ToList()
            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer la lista de permisos efectivos.")
                Return
            End Try
        End Using

        ' Marco los items del Tree View que tienen asignado el permiso
        For Each permiso As UsuarioGrupoPermiso In listPermisos
            Arbol.Nodes.Find(permiso.IDPermiso.Trim(), True).First.Checked = True
        Next

        listPermisos = Nothing
    End Sub

#End Region

End Module
