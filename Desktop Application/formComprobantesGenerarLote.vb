Imports System.Drawing.Printing

Public Class formComprobantesGenerarLote
    Private dbcontext As CSColegioContext

    Private listEntidadesSeleccionadasOk As List(Of Entidad)
    Private listEntidadesSeleccionadasCorregir As List(Of EntidadACorregir)

    Private FacturaLote As New ComprobanteLote
    Private listFacturas As List(Of Comprobante)

    Private AnioLectivo As Integer
    Private MesAFacturar As Byte
    Private MesAFacturarNombre As String

    Private FechaEmision As Date
    Private FechaServicioDesde As Date
    Private FechaServicioHasta As Date
    Private FechaVencimiento As Date

    Private Const NODO_CARGANDO_TEXTO As String = "Cargando..."

    Private Class EntidadACorregir
        Public Property IDEntidad() As Integer
        Public Property Apellido As String
        Public Property Nombre As String
        Public Property ApellidoNombre As String
        Public Property CorreccionDescripcion As String
    End Class

    Private Sub formGenerarLoteFacturas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbcontext.Dispose()
        listEntidadesSeleccionadasOk = Nothing
        listEntidadesSeleccionadasCorregir = Nothing
        listFacturas = Nothing
    End Sub

    Private Sub formGenerarLoteFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbcontext = New CSColegioContext(True)

        AnioLectivo = Today.Year
        MesAFacturar = CByte(Today.Month)
        MesAFacturarNombre = StrConv(MonthName(MesAFacturar), VbStrConv.ProperCase)

        FechaEmision = DateTime.Today
        FechaServicioDesde = New Date(AnioLectivo, MesAFacturar, 1)
        FechaServicioHasta = FechaServicioDesde.AddMonths(1).AddDays(-1)
        FechaVencimiento = New Date(AnioLectivo, MesAFacturar, CS_Parameter.GetIntegerAsByte(Parametros.CUOTA_MENSUAL_VENCIMIENTO_DIA))
        If FechaVencimiento.CompareTo(FechaEmision) < 0 Then
            FechaVencimiento = FechaEmision
        End If

        FillTreeViewNiveles()
        FillTreeViewPadres()

        lalbelPaso1Pie.Text = "Período a Facturar: " & MesAFacturarNombre & " de " & AnioLectivo

        MostrarPaneles(1)
    End Sub

    Private Sub MostrarPaneles(ByVal Paso As Byte)
        panelPaso1.Visible = (Paso = 1)
        panelPaso2.Visible = (Paso = 2)
        panelPaso3.Visible = (Paso = 3)
        Application.DoEvents()
    End Sub

#Region "Paso 1 - Selección - TreeView de Niveles - Cursos - Alumnos"
    Private Sub FillTreeViewNiveles()
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewPaso1NivelCursoAlumno.BeginUpdate()
        For Each NivelCurrent As Nivel In dbcontext.Nivel.Where(Function(niv) niv.EsActivo = True)
            ' Agrego el nodo correspondiente al Nivel actual y agrego un nodo hijo que diga "cargando..." para cuando se expanda el nodo
            NewNode = New TreeNode(NivelCurrent.Nombre, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = My.Settings.LoteComprobantes_PreseleccionarTodos
            NewNode.Tag = NivelCurrent
            treeviewPaso1NivelCursoAlumno.Nodes.Add(NewNode)
        Next
        treeviewPaso1NivelCursoAlumno.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillTreeViewAniosDelNivel(ByRef NodoNivel As TreeNode)
        Dim NivelCurrent As Nivel
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewPaso1NivelCursoAlumno.BeginUpdate()
        NodoNivel.Nodes.RemoveAt(0)
        NivelCurrent = CType(NodoNivel.Tag, Nivel)
        For Each AnioCurrent As Anio In NivelCurrent.Anio.Where(Function(ani) ani.EsActivo = True)
            ' Agrego el nodo correspondiente al Año actual
            NewNode = New TreeNode(AnioCurrent.Nombre, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = NodoNivel.Checked
            NewNode.Tag = AnioCurrent
            NodoNivel.Nodes.Add(NewNode)
        Next
        treeviewPaso1NivelCursoAlumno.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillTreeViewCursosDelAnio(ByRef NodoAnio As TreeNode)
        Dim AnioCurrent As Anio
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewPaso1NivelCursoAlumno.BeginUpdate()
        NodoAnio.Nodes.RemoveAt(0)
        AnioCurrent = CType(NodoAnio.Tag, Anio)
        For Each CursoCurrent As Curso In AnioCurrent.Curso
            ' Agrego el nodo correspondiente al Curso actual
            NewNode = New TreeNode("Turno: " & CursoCurrent.Turno.Nombre & " - División: " & CursoCurrent.Division, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = NodoAnio.Checked
            NewNode.Tag = CursoCurrent
            NodoAnio.Nodes.Add(NewNode)
        Next
        treeviewPaso1NivelCursoAlumno.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillTreeViewEntidadesDelCurso(ByRef NodoCurso As TreeNode)
        Dim CursoCurrent As Curso
        Dim AnioLectivoCursoCurrent As AnioLectivoCurso
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewPaso1NivelCursoAlumno.BeginUpdate()
        NodoCurso.Nodes.RemoveAt(0)
        CursoCurrent = CType(NodoCurso.Tag, Curso)
        AnioLectivoCursoCurrent = CursoCurrent.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = AnioLectivo).SingleOrDefault()
        If Not AnioLectivoCursoCurrent Is Nothing Then
            For Each EntidadCurrent As Entidad In AnioLectivoCursoCurrent.Entidades.Where(Function(ent) ent.EsActivo = True).OrderBy(Function(ent) ent.ApellidoNombre)
                ' Agrego el nodo correspondiente a la Entidad actual
                NewNode = New TreeNode(EntidadCurrent.ApellidoNombre)
                NewNode.Checked = NodoCurso.Checked
                NewNode.Tag = EntidadCurrent
                NodoCurso.Nodes.Add(NewNode)
            Next
        End If
        treeviewPaso1NivelCursoAlumno.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub treeviewPaso1NivelCursoAlumno_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles treeviewPaso1NivelCursoAlumno.AfterCheck
        For Each NodoActual As TreeNode In e.Node.Nodes
            NodoActual.Checked = e.Node.Checked
        Next
    End Sub

    Private Sub treeviewPaso1NivelCursoAlumno_AfterExpand(sender As Object, e As TreeViewEventArgs) Handles treeviewPaso1NivelCursoAlumno.AfterExpand
        If e.Node.Nodes.Count = 1 AndAlso e.Node.Nodes(0).Tag Is Nothing Then
            Application.DoEvents()
            Select Case e.Node.Level
                Case 0
                    ' Es un nodo de Nivel, cargo los Años
                    FillTreeViewAniosDelNivel(e.Node)
                Case 1
                    ' Es un nodo de Año, cargo los Cursos
                    FillTreeViewCursosDelAnio(e.Node)
                Case 2
                    ' Es un nodo de Curso, cargo las Entidades
                    FillTreeViewEntidadesDelCurso(e.Node)
            End Select
        End If
    End Sub

    Private Sub NivelCursoAlumno_MarcarYDesmarcarTodo(sender As Object, e As EventArgs) Handles menuitemNivelCursoAlumnoMarcarTodos.Click, menuitemNivelCursoAlumnoDesmarcarTodos.Click
        For Each TreeNodeCurrent As TreeNode In treeviewPaso1NivelCursoAlumno.Nodes
            TreeNodeCurrent.Checked = (CType(sender, ToolStripMenuItem) Is menuitemNivelCursoAlumnoMarcarTodos)
        Next
    End Sub
#End Region

#Region "Paso 1 - Selección - TreeView de Padres - Alumnos"
    Private Sub FillTreeViewPadres()
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewPaso1PadresAlumnos.BeginUpdate()
        For Each EntidadCurrent As Entidad In dbcontext.Entidad.Where(Function(ent) ent.EsActivo = True And ent.TipoFamiliar And (ent.EntidadPadreHijas.Count > 0 Or ent.EntidadMadreHijas.Count > 0)).OrderBy(Function(ent) ent.ApellidoNombre)
            ' Agrego el nodo correspondiente al Padre/Madre actual y agrego un nodo hijo que diga "cargando..." para cuando se expanda el nodo
            NewNode = New TreeNode(EntidadCurrent.ApellidoNombre, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = My.Settings.LoteComprobantes_PreseleccionarTodos
            NewNode.Tag = EntidadCurrent
            treeviewPaso1PadresAlumnos.Nodes.Add(NewNode)
        Next
        treeviewPaso1PadresAlumnos.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillTreeViewAlumnosDeLaEntidad(ByRef NodoEntidad As TreeNode)
        Dim EntidadNodoCurrent As Entidad
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewPaso1PadresAlumnos.BeginUpdate()
        NodoEntidad.Nodes.RemoveAt(0)
        EntidadNodoCurrent = CType(NodoEntidad.Tag, Entidad)
        ' Primero busco los Hijos del Padre
        For Each EntidadHijoCurrent As Entidad In EntidadNodoCurrent.EntidadPadreHijas.Where(Function(ent) ent.EsActivo).OrderBy(Function(ent) ent.ApellidoNombre)
            If EntidadHijoCurrent.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = AnioLectivo).Count > 0 Then
                NewNode = New TreeNode(EntidadHijoCurrent.ApellidoNombre)
                NewNode.Checked = NodoEntidad.Checked
                NewNode.Tag = EntidadHijoCurrent
                NodoEntidad.Nodes.Add(NewNode)
            End If
        Next
        ' Ahora busco los Hijos de la Madre
        For Each EntidadHijoCurrent As Entidad In EntidadNodoCurrent.EntidadMadreHijas.Where(Function(ent) ent.EsActivo).OrderBy(Function(ent) ent.ApellidoNombre)
            If EntidadHijoCurrent.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = AnioLectivo).Count > 0 Then
                NewNode = New TreeNode(EntidadHijoCurrent.ApellidoNombre)
                NewNode.Checked = NodoEntidad.Checked
                NewNode.Tag = EntidadHijoCurrent
                NodoEntidad.Nodes.Add(NewNode)
            End If
        Next
        treeviewPaso1PadresAlumnos.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub treeviewPaso1PadresAlumnos_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles treeviewPaso1PadresAlumnos.AfterCheck
        For Each NodoActual As TreeNode In e.Node.Nodes
            NodoActual.Checked = e.Node.Checked
        Next
    End Sub

    Private Sub treeviewPaso1PadresAlumnos_AfterExpand(sender As Object, e As TreeViewEventArgs) Handles treeviewPaso1PadresAlumnos.AfterExpand
        If e.Node.Nodes.Count = 1 AndAlso e.Node.Nodes(0).Tag Is Nothing Then
            Application.DoEvents()
            FillTreeViewAlumnosDeLaEntidad(e.Node)
        End If
    End Sub

    Private Sub PadreAlumno_MarcarYDesmarcarTodo(sender As Object, e As EventArgs) Handles menuitemPadreAlumnoMarcarTodos.Click, menuitemPadreAlumnoDesmarcarTodos.Click
        For Each TreeNodeCurrent As TreeNode In treeviewPaso1PadresAlumnos.Nodes
            TreeNodeCurrent.Checked = (CType(sender, ToolStripMenuItem) Is menuitemPadreAlumnoMarcarTodos)
        Next
    End Sub
#End Region

#Region "Paso 1 - Selección - Botones"
    Private Sub buttonPaso1Cancelar_Click() Handles buttonPaso1Cancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonPaso1Siguiente_Click() Handles buttonPaso1Siguiente.Click
        VerificarEntidades()
        MostrarEntidadesACorregir()
        MostrarPaneles(2)
    End Sub
#End Region

#Region "Paso 2 - Verificación"
    Private Sub VerificarEntidades()
        Me.Cursor = Cursors.WaitCursor

        listEntidadesSeleccionadasOk = New List(Of Entidad)
        listEntidadesSeleccionadasCorregir = New List(Of EntidadACorregir)

        'Antes que nada verifico que no haya Alumnos que están en más de un curso a la vez
        ''dbcontext.Database.ExecuteSqlCommand("", qq)

        If tabcontrolMain.SelectedTab Is tabpageNivelesCursosAlumnos Then
            ' La selección está hecha por Niveles - Cursos - Alumnos

            ' Desactivo la actualización gráfica para expandir todos y que se carguen todos los Nodos
            treeviewPaso1NivelCursoAlumno.BeginUpdate()
            For Each TreeNodeNivel As TreeNode In treeviewPaso1NivelCursoAlumno.Nodes
                ' Si no se cargaron los Nodos hijos y el Nodo no está tildado, ignoro este Nodo, si no, lo expando
                If TreeNodeNivel.Nodes.Count = 1 AndAlso TreeNodeNivel.Nodes(0).Tag Is Nothing Then
                    If TreeNodeNivel.Checked Then
                        TreeNodeNivel.Expand()
                    Else
                        Continue For
                    End If
                End If
                For Each TreeNodeAnio As TreeNode In TreeNodeNivel.Nodes
                    ' Si no se cargaron los Nodos hijos y el Nodo no está tildado, ignoro este Nodo, si no, lo expando
                    If TreeNodeAnio.Nodes.Count = 1 AndAlso TreeNodeAnio.Nodes(0).Tag Is Nothing Then
                        If TreeNodeAnio.Checked Then
                            TreeNodeAnio.Expand()
                        Else
                            Continue For
                        End If
                    End If
                    For Each TreeNodeCurso As TreeNode In TreeNodeAnio.Nodes
                        ' Si no se cargaron los Nodos hijos y el Nodo no está tildado, ignoro este Nodo, si no, lo expando
                        If TreeNodeCurso.Nodes.Count = 1 AndAlso TreeNodeCurso.Nodes(0).Tag Is Nothing Then
                            If TreeNodeCurso.Checked Then
                                TreeNodeCurso.Expand()
                            Else
                                Continue For
                            End If
                        End If
                        For Each TreeNodeEntidad As TreeNode In TreeNodeCurso.Nodes
                            If TreeNodeEntidad.Checked Then
                                VerificarEntidad(CType(TreeNodeEntidad.Tag, Entidad))
                            End If
                        Next
                    Next
                Next
            Next
            treeviewPaso1NivelCursoAlumno.EndUpdate()
        Else
            ' La selección está hecha por Padres - Hijos

            ' Desactivo la actualización gráfica para expandir todos y que se carguen todos los Nodos
            treeviewPaso1PadresAlumnos.BeginUpdate()

            For Each TreeNodeEntidad As TreeNode In treeviewPaso1PadresAlumnos.Nodes
                If TreeNodeEntidad.Checked Then
                    TreeNodeEntidad.Expand()
                    For Each TreeNodeAlumno As TreeNode In TreeNodeEntidad.Nodes
                        If TreeNodeAlumno.Checked Then
                            VerificarEntidad(CType(TreeNodeAlumno.Tag, Entidad))
                        End If
                    Next
                End If
            Next

            treeviewPaso1PadresAlumnos.EndUpdate()
        End If

        listEntidadesSeleccionadasOk.OrderBy(Function(ent) ent.ApellidoNombre)
        listEntidadesSeleccionadasCorregir.OrderBy(Function(eac) CType(eac, EntidadACorregir).ApellidoNombre)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VerificarEntidad(ByRef EntidadActual As Entidad)
        Dim CorregirEntidad As Boolean = False
        Dim CorreccionDescripcion As String = ""

        If EntidadActual.TipoAlumno = False Then
            CorregirEntidad = True
            CorreccionDescripcion &= "No es una Entidad del tipo Alumno." & vbCrLf
        End If

        If EntidadActual.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = AnioLectivo).Count > 1 Then
            CorregirEntidad = True
            CorreccionDescripcion &= "El Alumno está cargado en más de un curso para el Año Lectivo que se va a facturar." & vbCrLf
        End If

        If EntidadActual.EmitirFacturaA Is Nothing Then
            CorregirEntidad = True
            CorreccionDescripcion &= "No está especificado a quién se le factura." & vbCrLf

        Else

            If EntidadActual.EmitirFacturaA = Constantes.EMITIRFACTURAA_ALUMNO Then
                ' Se le factura al Alumno
                If EntidadActual.IDCategoriaIVA Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "El Alumno no tiene especificada la Categoría de IVA." & vbCrLf
                End If
                If EntidadActual.DocumentoNumero Is Nothing And EntidadActual.FacturaDocumentoNumero Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "El Alumno no tiene especificado el Tipo y Número de Documento." & vbCrLf
                End If
            End If

            If EntidadActual.EmitirFacturaA = Constantes.EMITIRFACTURAA_PADRE Or EntidadActual.EmitirFacturaA = Constantes.EMITIRFACTURAA_AMBOSPADRES Or EntidadActual.EmitirFacturaA = Constantes.EMITIRFACTURAA_TODOS Then
                ' Se le factura al Padre (entre otros)
                If EntidadActual.IDEntidadPadre Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "Debe especificar el Padre para poder facturarle." & vbCrLf
                Else
                    If EntidadActual.EntidadPadre.IDCategoriaIVA Is Nothing Then
                        CorregirEntidad = True
                        CorreccionDescripcion &= "El Padre no tiene especificada la Categoría de IVA." & vbCrLf
                    End If
                    If EntidadActual.EntidadPadre.DocumentoNumero Is Nothing And EntidadActual.EntidadPadre.FacturaDocumentoNumero Is Nothing Then
                        CorregirEntidad = True
                        CorreccionDescripcion &= "El Padre no tiene especificado el Tipo y Número de Documento." & vbCrLf
                    End If
                End If
            End If

            If EntidadActual.EmitirFacturaA = Constantes.EMITIRFACTURAA_MADRE Or EntidadActual.EmitirFacturaA = Constantes.EMITIRFACTURAA_AMBOSPADRES Or EntidadActual.EmitirFacturaA = Constantes.EMITIRFACTURAA_TODOS Then
                ' Se le factura a la Madre (entre otros)
                If EntidadActual.IDEntidadMadre Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "Debe especificar la Madre para poder facturarle." & vbCrLf
                Else
                    If EntidadActual.EntidadMadre.IDCategoriaIVA Is Nothing Then
                        CorregirEntidad = True
                        CorreccionDescripcion &= "La Madre no tiene especificada la Categoría de IVA." & vbCrLf
                    End If
                    If EntidadActual.EntidadMadre.DocumentoNumero Is Nothing And EntidadActual.EntidadMadre.FacturaDocumentoNumero Is Nothing Then
                        CorregirEntidad = True
                        CorreccionDescripcion &= "La Madre no tiene especificado el Tipo y Número de Documento." & vbCrLf
                    End If
                End If
            End If

            If EntidadActual.EmitirFacturaA = Constantes.EMITIRFACTURAA_TERCERO Or EntidadActual.EmitirFacturaA = Constantes.EMITIRFACTURAA_TODOS Then
                ' Se le factura a Otro (entre otros)
                If EntidadActual.IDEntidadTercero Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "Debe especificar el Tercero para poder facturarle." & vbCrLf
                Else
                    If EntidadActual.EntidadTercero.IDCategoriaIVA Is Nothing Then
                        CorregirEntidad = True
                        CorreccionDescripcion &= "El Tercero a quien se le va a facurar no tiene especificada la Categoría de IVA." & vbCrLf
                    End If
                    If EntidadActual.EntidadTercero.DocumentoNumero Is Nothing And EntidadActual.EntidadTercero.FacturaDocumentoNumero Is Nothing Then
                        CorregirEntidad = True
                        CorreccionDescripcion &= "El Tercero a quien se le va a facurar no tiene especificado el Tipo y Número de Documento." & vbCrLf
                    End If
                End If
            End If
        End If

        ' Si hay que corregir la Entidad, la agrego a la lista de Entidades a corregir
        If CorregirEntidad Then
            CorreccionDescripcion = CorreccionDescripcion.Remove(CorreccionDescripcion.Length - vbCrLf.Length)
            listEntidadesSeleccionadasCorregir.Add(New EntidadACorregir With {.IDEntidad = EntidadActual.IDEntidad, .Apellido = EntidadActual.Apellido, .Nombre = EntidadActual.Nombre, .ApellidoNombre = EntidadActual.ApellidoNombre, .CorreccionDescripcion = CorreccionDescripcion})
        Else
            ' La Entidad está verificada, pero antes de agregarla, verifico que no tenga exclusión de facturación
            If (Not EntidadActual.ExcluyeFacturaDesde Is Nothing) AndAlso EntidadActual.ExcluyeFacturaDesde.Value.CompareTo(FechaServicioHasta) < 0 Then
                ' Está dentro de la exclusión, así que no lo agrego a la lista
            ElseIf (Not EntidadActual.ExcluyeFacturaHasta Is Nothing) AndAlso EntidadActual.ExcluyeFacturaHasta.Value.CompareTo(FechaServicioDesde) > 0 Then
                ' Está dentro de la exclusión, así que no lo agrego a la lista
            Else
                ' Está fuera de la exclusión, asi que lo agrego
                listEntidadesSeleccionadasOk.Add(EntidadActual)
            End If
        End If
    End Sub

    Private Sub MostrarEntidadesACorregir()
        listEntidadesSeleccionadasCorregir = listEntidadesSeleccionadasCorregir.OrderBy(Function(ent) ent.ApellidoNombre).ToList

        datagridviewPaso2.AutoGenerateColumns = False
        datagridviewPaso2.DataSource = listEntidadesSeleccionadasCorregir

        labelPaso2Pie.Text = "Entidades a corregir: " & listEntidadesSeleccionadasCorregir.Count.ToString

        buttonPaso2Siguiente.Enabled = (listEntidadesSeleccionadasCorregir.Count = 0)
    End Sub

    Private Sub buttonPaso2Anterior_Click() Handles buttonPaso2Anterior.Click
        MostrarPaneles(1)
    End Sub

    Private Sub buttonPaso2Siguiente_Click() Handles buttonPaso2Siguiente.Click
        Dim LoteNombre As String

        LoteNombre = InputBox("Ingrese el nombre del Lote a Generar:", My.Application.Info.Title, String.Format("Período {0:00}/{1}", MesAFacturar, AnioLectivo))

        GenerarComprobantes(LoteNombre)
        MostrarPaneles(3)
    End Sub
#End Region

#Region "Paso 3 - Generación"
    Private Sub GenerarComprobantes(ByVal LoteNombre As String)
        Dim dbcontext As New CSColegioContext(True)

        ' Parámetros
        Dim IDArticulo As Short
        Dim ComprobanteEntidadMayusculas As Boolean

        ' Datos de la Factura
        Dim NextID As Integer
        Dim ComprobanteTipo As New ComprobanteTipo
        Dim ComprobanteTipoPuntoVenta As ComprobanteTipoPuntoVenta
        Dim PuntoVenta As New PuntoVenta
        Dim NextComprobanteNumero As String = ""

        Dim FacturaCabecera As New Comprobante
        Dim FacturaDetalle As ComprobanteDetalle

        Me.Cursor = Cursors.WaitCursor

        listFacturas = New List(Of Comprobante)

        ' Cargo los parámetros en variables para reducir tiempo de procesamiento
        IDArticulo = CS_Parameter.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_ARTICULO_ID)
        ComprobanteEntidadMayusculas = CS_Parameter.GetBoolean(Parametros.COMPROBANTE_ENTIDAD_MAYUSCULAS, False).Value

        ' Creo el Lote de Comprobantes
        With FacturaLote
            If dbcontext.ComprobanteLote.Count = 0 Then
                .IDComprobanteLote = 1
            Else
                .IDComprobanteLote = dbcontext.ComprobanteLote.Max(Function(cl) cl.IDComprobanteLote) + 1
            End If
            .FechaHora = Now
            .Nombre = LoteNombre

            ' Auditoría
            .IDUsuarioCreacion = pUsuario.IDUsuario
            .FechaHoraCreacion = System.DateTime.Now
            .IDUsuarioModificacion = pUsuario.IDUsuario
            .FechaHoraModificacion = .FechaHoraCreacion
        End With

        For Each EntidadAlumno As Entidad In listEntidadesSeleccionadasOk
            If EntidadAlumno.EmitirFacturaA = Constantes.EMITIRFACTURAA_ALUMNO Then
                ' Se factura directamente al Alumno, así que lo agrego a él mismo como Titular de la Factura y como Alumno
                FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno, FechaEmision, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, Nothing, ComprobanteEntidadMayusculas)
                FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                FacturaCabecera.ImporteImpuesto = 0
                FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                listFacturas.Add(FacturaCabecera)
            End If

            '//////////////////////////////////////////////////////
            ' FACTURAR AL PADRE
            '//////////////////////////////////////////////////////
            If EntidadAlumno.EmitirFacturaA = Constantes.EMITIRFACTURAA_PADRE Or EntidadAlumno.EmitirFacturaA = Constantes.EMITIRFACTURAA_AMBOSPADRES Or EntidadAlumno.EmitirFacturaA = Constantes.EMITIRFACTURAA_TODOS Then
                ' Se factura al Padre (entre otros posibles)
                If EntidadAlumno.FacturaIndividual Then
                    ' El Alumno especifica que se le facture individualmente
                    FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno.EntidadPadre, FechaEmision, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, EntidadAlumno.FacturaLeyenda, ComprobanteEntidadMayusculas)
                    FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                    FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                    FacturaCabecera.ImporteImpuesto = 0
                    FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                    listFacturas.Add(FacturaCabecera)
                Else
                    ' Busco si existe una Factura de esta Entidad en la lista de Facturas (por otro Alumno)
                    FacturaCabecera = listFacturas.Find(Function(fc) fc.IDEntidad = EntidadAlumno.IDEntidadPadre.Value)
                    If FacturaCabecera Is Nothing Then
                        ' No existe la Factura, la creo.
                        FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno.EntidadPadre, FechaEmision, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, EntidadAlumno.FacturaLeyenda, ComprobanteEntidadMayusculas)
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                        FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                        listFacturas.Add(FacturaCabecera)
                    Else
                        ' Ya existe una Factura de ese Titular
                        If dbcontext.Entidad.Find(FacturaCabecera.ComprobanteDetalle.First.IDEntidad).FacturaIndividual Then
                            ' El Alumno que ya está en la Factura especifica que se le facture individualmente
                            FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno.EntidadPadre, FechaEmision, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, EntidadAlumno.FacturaLeyenda, ComprobanteEntidadMayusculas)
                            FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                            FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                            FacturaCabecera.ImporteImpuesto = 0
                            FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                            listFacturas.Add(FacturaCabecera)
                        Else
                            ' No hay restricciones, así que sólo agrego un item al Detalle
                            FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                            If Not EntidadAlumno.FacturaLeyenda Is Nothing Then
                                If FacturaCabecera.Leyenda Is Nothing Then
                                    FacturaCabecera.Leyenda = EntidadAlumno.FacturaLeyenda
                                Else
                                    FacturaCabecera.Leyenda &= vbCrLf & EntidadAlumno.FacturaLeyenda
                                End If
                            End If
                            FacturaCabecera.ImporteSubtotal = FacturaCabecera.ImporteSubtotal + FacturaDetalle.PrecioTotal
                            FacturaCabecera.ImporteImpuesto = 0
                            FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                        End If
                    End If
                End If
            End If

            '//////////////////////////////////////////////////////
            ' FACTURAR A LA MADRE
            '//////////////////////////////////////////////////////
            If EntidadAlumno.EmitirFacturaA = Constantes.EMITIRFACTURAA_MADRE Or EntidadAlumno.EmitirFacturaA = Constantes.EMITIRFACTURAA_AMBOSPADRES Or EntidadAlumno.EmitirFacturaA = Constantes.EMITIRFACTURAA_TODOS Then
                ' Se factura a la Madre (entre otros posibles)
                If EntidadAlumno.FacturaIndividual Then
                    ' El Alumno especifica que se le facture individualmente
                    FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno.EntidadMadre, FechaEmision, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, EntidadAlumno.FacturaLeyenda, ComprobanteEntidadMayusculas)
                    FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                    FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                    FacturaCabecera.ImporteImpuesto = 0
                    FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                    listFacturas.Add(FacturaCabecera)
                Else
                    ' Busco si existe una Factura de esta Entidad en la lista de Facturas (por otro Alumno)
                    FacturaCabecera = listFacturas.Find(Function(fc) fc.IDEntidad = EntidadAlumno.IDEntidadMadre.Value)
                    If FacturaCabecera Is Nothing Then
                        ' No existe la Factura, la creo.
                        FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno.EntidadMadre, FechaEmision, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, EntidadAlumno.FacturaLeyenda, ComprobanteEntidadMayusculas)
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                        FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                        listFacturas.Add(FacturaCabecera)
                    Else
                        ' Ya existe una Factura de ese Titular
                        If dbcontext.Entidad.Find(FacturaCabecera.ComprobanteDetalle.First.IDEntidad).FacturaIndividual Then
                            ' El Alumno que ya está en la Factura especifica que se le facture individualmente
                            FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno.EntidadMadre, FechaEmision, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, EntidadAlumno.FacturaLeyenda, ComprobanteEntidadMayusculas)
                            FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                            FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                            FacturaCabecera.ImporteImpuesto = 0
                            FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                            listFacturas.Add(FacturaCabecera)
                        Else
                            ' No hay restricciones, así que sólo agrego un item al Detalle
                            FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                            If Not EntidadAlumno.FacturaLeyenda Is Nothing Then
                                If FacturaCabecera.Leyenda Is Nothing Then
                                    FacturaCabecera.Leyenda = EntidadAlumno.FacturaLeyenda
                                Else
                                    FacturaCabecera.Leyenda &= vbCrLf & EntidadAlumno.FacturaLeyenda
                                End If
                            End If
                            FacturaCabecera.ImporteSubtotal = FacturaCabecera.ImporteSubtotal + FacturaDetalle.PrecioTotal
                            FacturaCabecera.ImporteImpuesto = 0
                            FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                        End If
                    End If
                End If
            End If

            '//////////////////////////////////////////////////////
            ' FACTURAR A UN TERCERO
            '//////////////////////////////////////////////////////
            If EntidadAlumno.EmitirFacturaA = Constantes.EMITIRFACTURAA_TERCERO Or EntidadAlumno.EmitirFacturaA = Constantes.EMITIRFACTURAA_TODOS Then
                ' Se factura a un Tercero (entre otros posibles)
                If EntidadAlumno.FacturaIndividual Then
                    ' El Alumno especifica que se le facture individualmente
                    FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno.EntidadTercero, FechaEmision, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, EntidadAlumno.FacturaLeyenda, ComprobanteEntidadMayusculas)
                    FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                    FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                    FacturaCabecera.ImporteImpuesto = 0
                    FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                    listFacturas.Add(FacturaCabecera)
                Else
                    ' Busco si existe una Factura de esta Entidad en la lista de Facturas (por otro Alumno)
                    FacturaCabecera = listFacturas.Find(Function(fc) fc.IDEntidad = EntidadAlumno.IDEntidadTercero.Value)
                    If FacturaCabecera Is Nothing Then
                        ' No existe la Factura, la creo.
                        FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno.EntidadTercero, FechaEmision, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, EntidadAlumno.FacturaLeyenda, ComprobanteEntidadMayusculas)
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                        FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                        listFacturas.Add(FacturaCabecera)
                    Else
                        ' Ya existe una Factura de ese Titular
                        If dbcontext.Entidad.Find(FacturaCabecera.ComprobanteDetalle.First.IDEntidad).FacturaIndividual Then
                            ' El Alumno que ya está en la Factura especifica que se le facture individualmente
                            FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno.EntidadTercero, FechaEmision, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, EntidadAlumno.FacturaLeyenda, ComprobanteEntidadMayusculas)
                            FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                            FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                            FacturaCabecera.ImporteImpuesto = 0
                            FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                            listFacturas.Add(FacturaCabecera)
                        Else
                            ' No hay restricciones, así que sólo agrego un item al Detalle
                            FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                            If Not EntidadAlumno.FacturaLeyenda Is Nothing Then
                                If FacturaCabecera.Leyenda Is Nothing Then
                                    FacturaCabecera.Leyenda = EntidadAlumno.FacturaLeyenda
                                Else
                                    FacturaCabecera.Leyenda &= vbCrLf & EntidadAlumno.FacturaLeyenda
                                End If
                            End If
                            FacturaCabecera.ImporteSubtotal = FacturaCabecera.ImporteSubtotal + FacturaDetalle.PrecioTotal
                            FacturaCabecera.ImporteImpuesto = 0
                            FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                        End If
                    End If
                End If
            End If
        Next

        ' Ordeno la lista de Facturas por Tipo de Comprobante
        listFacturas.OrderBy(Function(cc) cc.IDComprobanteTipo)

        ' Obtengo el ID del último Comprobante cargado
        If dbcontext.Comprobante.Count = 0 Then
            NextID = 0
        Else
            NextID = dbcontext.Comprobante.Max(Function(cc) cc.IDComprobante)
        End If

        ' Recorro todas las Facturas generadas para aplicarles los ID y los Números de Comprobante
        For Each FacturaCabeceraActual As Comprobante In listFacturas
            With FacturaCabeceraActual
                NextID += 1
                .IDComprobante = NextID
                If ComprobanteTipo.IDComprobanteTipo <> .IDComprobanteTipo Then
                    ComprobanteTipo = dbcontext.ComprobanteTipo.Find(.IDComprobanteTipo)
                    ComprobanteTipoPuntoVenta = ComprobanteTipo.ComprobanteTipoPuntoVenta.Where(Function(ctpv) ctpv.IDPuntoVenta = My.Settings.IDPuntoVenta).FirstOrDefault
                    If ComprobanteTipoPuntoVenta Is Nothing Then
                        Exit For
                    End If
                    PuntoVenta = ComprobanteTipoPuntoVenta.PuntoVenta

                    ' Busco si ya hay un comprobante creado de este tipo para obtener el último número
                    NextComprobanteNumero = dbcontext.Comprobante.Where(Function(cc) cc.IDComprobanteTipo = .IDComprobanteTipo And cc.PuntoVenta = PuntoVenta.Numero).Max(Function(cc) cc.Numero)
                    If NextComprobanteNumero Is Nothing Then
                        ' No hay ningún comprobante creado de este tipo, así que tomo el número inicial y le resto 1 porque después se lo sumo
                        NextComprobanteNumero = CStr(CInt(ComprobanteTipoPuntoVenta.NumeroInicio) - 1).PadLeft(Constantes.COMPROBANTE_NUMERO_CARACTERES, "0"c)
                    End If
                End If
                NextComprobanteNumero = CStr(CInt(NextComprobanteNumero) + 1).PadLeft(Constantes.COMPROBANTE_NUMERO_CARACTERES, "0"c)
                .PuntoVenta = PuntoVenta.Numero
                .Numero = NextComprobanteNumero
            End With
        Next

        dbcontext.Dispose()

        datagridviewPaso3Cabecera.AutoGenerateColumns = False
        datagridviewPaso3Cabecera.DataSource = listFacturas

        labelPaso3Pie.Text = String.Format("Se generarán {0} Facturas.", listFacturas.Count)

        Me.Cursor = Cursors.Default
    End Sub

    Private Function GenerarComprobanteCabecera(ByRef EntidadCabecera As Entidad, ByVal FechaEmision As Date, ByVal FechaVencimiento As Date, ByVal FechaServicioDesde As Date, ByVal FechaServicioHasta As Date, ByVal IDFacturaLote As Integer, ByVal LeyendaAlumno As String, ByVal ComprobanteEntidadMayusculas As Boolean) As Comprobante
        Dim FacturaCabecera As New Comprobante

        With FacturaCabecera
            ' Cabecera
            .IDComprobanteTipo = EntidadCabecera.CategoriaIVA.VentaIDComprobanteTipo
            .FechaEmision = FechaEmision
            .FechaVencimiento = FechaVencimiento
            .FechaServicioDesde = FechaServicioDesde
            .FechaServicioHasta = FechaServicioHasta

            ' Entidad
            .IDEntidad = EntidadCabecera.IDEntidad
            If ComprobanteEntidadMayusculas Then
                .ApellidoNombre = EntidadCabecera.ApellidoNombre.ToUpper
            Else
                .ApellidoNombre = EntidadCabecera.ApellidoNombre
            End If

            ' Tipo y Número de Documento
            If Not EntidadCabecera.FacturaIDDocumentoTipo Is Nothing Then
                .IDDocumentoTipo = EntidadCabecera.FacturaIDDocumentoTipo.Value
                .DocumentoNumero = EntidadCabecera.FacturaDocumentoNumero
            ElseIf Not EntidadCabecera.IDDocumentoTipo Is Nothing Then
                .IDDocumentoTipo = EntidadCabecera.IDDocumentoTipo.Value
                .DocumentoNumero = EntidadCabecera.DocumentoNumero
            Else
                .IDDocumentoTipo = CS_Parameter.GetIntegerAsByte(Parametros.CONSUMIDORFINAL_DOCUMENTOTIPO_ID)
                .DocumentoNumero = CS_Parameter.GetString(Parametros.CONSUMIDORFINAL_DOCUMENTONUMERO)
            End If
            .IDCategoriaIVA = EntidadCabecera.IDCategoriaIVA.Value

            ' Domicilio
            .DomicilioCalleCompleto = EntidadCabecera.DomicilioCalleCompleto()
            .DomicilioCodigoPostal = EntidadCabecera.DomicilioCodigoPostal
            .DomicilioIDProvincia = EntidadCabecera.DomicilioIDProvincia
            .DomicilioIDLocalidad = EntidadCabecera.DomicilioIDLocalidad

            .IDComprobanteLote = IDFacturaLote

            .Leyenda = EntidadCabecera.FacturaLeyenda
            If Not LeyendaAlumno Is Nothing Then
                If .Leyenda Is Nothing Then
                    .Leyenda = LeyendaAlumno
                Else
                    .Leyenda &= vbCrLf & LeyendaAlumno
                End If
            End If

            ' Auditoría
            .IDUsuarioCreacion = pUsuario.IDUsuario
            .FechaHoraCreacion = System.DateTime.Now
            .IDUsuarioModificacion = pUsuario.IDUsuario
            .FechaHoraModificacion = .FechaHoraCreacion
        End With

        Return FacturaCabecera
    End Function

    Private Function GenerarComprobanteDetalle(ByRef FacturaCabecera As Comprobante, ByRef EntidadDetalle As Entidad, ByVal IDArticulo As Short) As ComprobanteDetalle
        Dim FacturaDetalle As New ComprobanteDetalle
        Dim AnioLectivoCursoActual As AnioLectivoCurso

        AnioLectivoCursoActual = EntidadDetalle.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = AnioLectivo).FirstOrDefault
        If Not AnioLectivoCursoActual Is Nothing Then
            With FacturaDetalle
                .Indice = CByte(FacturaCabecera.ComprobanteDetalle.Count + 1)
                .IDArticulo = IDArticulo
                .IDEntidad = EntidadDetalle.IDEntidad
                .IDAnioLectivoCurso = AnioLectivoCursoActual.IDAnioLectivoCurso
                .CuotaMes = MesAFacturar
                .Cantidad = 1
                .Descripcion = String.Format("Cuota de {0} de {1} - {2}", MesAFacturarNombre, AnioLectivo, EntidadDetalle.ApellidoNombre)

                ' Precios
                Select Case EntidadDetalle.EmitirFacturaA
                    Case Constantes.EMITIRFACTURAA_ALUMNO, Constantes.EMITIRFACTURAA_PADRE, Constantes.EMITIRFACTURAA_MADRE, Constantes.EMITIRFACTURAA_TERCERO
                        .PrecioUnitario = AnioLectivoCursoActual.ImporteCuota
                    Case Constantes.EMITIRFACTURAA_AMBOSPADRES
                        .PrecioUnitario = Decimal.Round(AnioLectivoCursoActual.ImporteCuota / 2, My.Settings.DecimalesEnImportes, MidpointRounding.ToEven)
                    Case Constantes.EMITIRFACTURAA_TODOS
                        .PrecioUnitario = Decimal.Round(AnioLectivoCursoActual.ImporteCuota / 3, My.Settings.DecimalesEnImportes, MidpointRounding.ToEven)
                End Select
                If EntidadDetalle.IDDescuento Is Nothing Then
                    .PrecioUnitarioDescuentoPorcentaje = 0
                    .PrecioUnitarioDescuentoImporte = 0
                Else
                    .PrecioUnitarioDescuentoPorcentaje = EntidadDetalle.Descuento.Porcentaje
                    .PrecioUnitarioDescuentoImporte = Decimal.Round(.PrecioUnitario * .PrecioUnitarioDescuentoPorcentaje / 100, My.Settings.DecimalesEnImportes, MidpointRounding.ToEven)
                End If
                .PrecioUnitarioFinal = .PrecioUnitario - .PrecioUnitarioDescuentoImporte
                .PrecioTotal = .PrecioUnitarioFinal
            End With

            FacturaCabecera.ComprobanteDetalle.Add(FacturaDetalle)

            Return FacturaDetalle
        Else
            Return Nothing
        End If
    End Function

    Private Function GuardarComprobantes() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()

            Using dbcontext As New CSColegioContext(True)
                dbcontext.ComprobanteLote.Add(FacturaLote)
                dbcontext.Comprobante.AddRange(listFacturas)

                dbcontext.SaveChanges()
            End Using

            Me.Cursor = Cursors.Default
            Return True
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            CS_Error.ProcessError(ex, "Error al guardar las Facturas Generadas")
            Return False
        End Try
    End Function

    Private Sub Paso4MostrarDetalle() Handles datagridviewPaso3Cabecera.SelectionChanged
        datagridviewPaso3Detalle.AutoGenerateColumns = False
        datagridviewPaso3Detalle.DataSource = CType(datagridviewPaso3Cabecera.SelectedRows(0).DataBoundItem, Comprobante).ComprobanteDetalle.ToList
    End Sub

    Private Sub buttonPaso3Anterior_Click() Handles buttonPaso3Anterior.Click
        MostrarPaneles(2)
    End Sub

    Private Sub buttonPaso3Finalizar_Click() Handles buttonPaso3Finalizar.Click
        If MsgBox("¿Confirma la Generación del Lote de Facturas?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
            If GuardarComprobantes() Then
                MsgBox(String.Format("Se han generado {0} Facturas.", listFacturas.Count), MsgBoxStyle.Information, My.Application.Info.Title)
                Me.Close()
            End If
        End If
    End Sub
#End Region

End Class