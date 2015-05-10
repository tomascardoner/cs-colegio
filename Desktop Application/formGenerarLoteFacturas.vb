Public Class formGenerarLoteFacturas
    Private dbcColegio As CSColegioContext
    Private AnioLectivo As Integer = Today.Year
    Private Const NODO_CARGANDO_TEXTO As String = "Cargando..."

    Private listEntidadesSeleccionadasOk As List(Of Entidad)
    Private listEntidadesSeleccionadasCorregir As List(Of Object)

    ' TODO: Verificar que todos los alumnos activos y que se encuentren cursando el año lectivo actual, tengan asociada una Entidad a nombre de la cual se va a emitir la Factura.
    ' Mostrar una lista con los Alumnos que estén "huérfanos" y/o que ninguno de sus "padres" tenga tildada la opción de factrarle

    ' TODO: Verificar que cada Entidad a la cual se le va a facturar, tenga los datos mínimos completos (Situación ante el IVA, etc.)
    ' Ofrecer la opción de aplicar la Categoria de IVA predeterminada a todos los que no hayan especificado otra.

    ' TODO: Verificar que no se facture 2 veces en el mismo período al mismo alumno

    Private Sub formGenerarLoteFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbcColegio = New CSColegioContext

        FillTreeViewNiveles()
        FillTreeViewPadres()

        lalbelPaso1Pie.Text = "Período a Facturar: " & StrConv(MonthName(Today.Month), VbStrConv.ProperCase) & " de " & AnioLectivo
    End Sub

    Private Sub formGenerarLoteFacturas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbcColegio.Dispose()
    End Sub

#Region "Paso 1 - TreeView de Niveles - Cursos - Alumnos"
    Private Sub FillTreeViewNiveles()
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewSeleccionarNivelCursoAlumno.BeginUpdate()
        For Each NivelCurrent As Nivel In dbcColegio.Nivel.Where(Function(niv) niv.EsActivo = True)
            ' Agrego el nodo correspondiente al Nivel actual y agrego un nodo hijo que diga "cargando..." para cuando se expanda el nodo
            NewNode = New TreeNode(NivelCurrent.Nombre, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = My.Settings.GenerarLoteFacturasPreseleccionarTodos
            NewNode.Tag = NivelCurrent
            treeviewSeleccionarNivelCursoAlumno.Nodes.Add(NewNode)
        Next
        treeviewSeleccionarNivelCursoAlumno.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillTreeViewAniosDelNivel(ByRef NodoNivel As TreeNode)
        Dim NivelCurrent As Nivel
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewSeleccionarNivelCursoAlumno.BeginUpdate()
        NodoNivel.Nodes.RemoveAt(0)
        NivelCurrent = CType(NodoNivel.Tag, Nivel)
        For Each AnioCurrent As Anio In NivelCurrent.Anio.Where(Function(ani) ani.EsActivo = True)
            ' Agrego el nodo correspondiente al Año actual
            NewNode = New TreeNode(AnioCurrent.Nombre, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = NodoNivel.Checked
            NewNode.Tag = AnioCurrent
            NodoNivel.Nodes.Add(NewNode)
        Next
        treeviewSeleccionarNivelCursoAlumno.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillTreeViewCursosDelAnio(ByRef NodoAnio As TreeNode)
        Dim AnioCurrent As Anio
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewSeleccionarNivelCursoAlumno.BeginUpdate()
        NodoAnio.Nodes.RemoveAt(0)
        AnioCurrent = CType(NodoAnio.Tag, Anio)
        For Each CursoCurrent As Curso In AnioCurrent.Curso
            ' Agrego el nodo correspondiente al Curso actual
            NewNode = New TreeNode("Turno: " & CursoCurrent.Turno.Nombre & " - División: " & CursoCurrent.Division, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = NodoAnio.Checked
            NewNode.Tag = CursoCurrent
            NodoAnio.Nodes.Add(NewNode)
        Next
        treeviewSeleccionarNivelCursoAlumno.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillTreeViewEntidadesDelCurso(ByRef NodoCurso As TreeNode)
        Dim CursoCurrent As Curso
        Dim AnioLectivoCursoCurrent As AnioLectivoCurso
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewSeleccionarNivelCursoAlumno.BeginUpdate()
        NodoCurso.Nodes.RemoveAt(0)
        CursoCurrent = CType(NodoCurso.Tag, Curso)
        AnioLectivoCursoCurrent = CursoCurrent.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = AnioLectivo).FirstOrDefault()
        If Not AnioLectivoCursoCurrent Is Nothing Then
            For Each EntidadCurrent As Entidad In AnioLectivoCursoCurrent.Entidades.Where(Function(ent) ent.EsActivo = True).OrderBy(Function(ent) ent.ApellidoNombre)
                ' Agrego el nodo correspondiente a la Entidad actual
                NewNode = New TreeNode(EntidadCurrent.ApellidoNombre)
                NewNode.Checked = NodoCurso.Checked
                NewNode.Tag = EntidadCurrent
                NodoCurso.Nodes.Add(NewNode)
            Next
        End If
        treeviewSeleccionarNivelCursoAlumno.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub treeviewNivelCursoAlumno_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles treeviewSeleccionarNivelCursoAlumno.AfterCheck
        For Each NodoActual As TreeNode In e.Node.Nodes
            NodoActual.Checked = e.Node.Checked
        Next
    End Sub

    Private Sub treeviewNivelCursoAlumno_AfterExpand(sender As Object, e As TreeViewEventArgs) Handles treeviewSeleccionarNivelCursoAlumno.AfterExpand
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
        For Each TreeNodeCurrent As TreeNode In treeviewSeleccionarNivelCursoAlumno.Nodes
            TreeNodeCurrent.Checked = (CType(sender, ToolStripMenuItem) Is menuitemNivelCursoAlumnoMarcarTodos)
        Next
    End Sub
#End Region

#Region "Paso 1 - TreeView de Padres - Alumnos"
    Private Sub FillTreeViewPadres()
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewSeleccionarPadresAlumnos.BeginUpdate()
        For Each EntidadCurrent As Entidad In dbcColegio.Entidad.Where(Function(ent) ent.EsActivo = True And ent.TipoFamiliar).OrderBy(Function(ent) ent.ApellidoNombre)
            ' Agrego el nodo correspondiente al Padre/Madre actual y agrego un nodo hijo que diga "cargando..." para cuando se expanda el nodo
            NewNode = New TreeNode(EntidadCurrent.ApellidoNombre, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = My.Settings.GenerarLoteFacturasPreseleccionarTodos
            NewNode.Tag = EntidadCurrent
            treeviewSeleccionarPadresAlumnos.Nodes.Add(NewNode)
        Next
        treeviewSeleccionarPadresAlumnos.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillTreeViewEntidadesDeLaEntidad(ByRef NodoEntidad As TreeNode)
        Dim EntidadNodoCurrent As Entidad
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewSeleccionarPadresAlumnos.BeginUpdate()
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
        treeviewSeleccionarPadresAlumnos.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub treeviewPadresAlumnos_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles treeviewSeleccionarPadresAlumnos.AfterCheck
        For Each NodoActual As TreeNode In e.Node.Nodes
            NodoActual.Checked = e.Node.Checked
        Next
    End Sub

    Private Sub treeviewPadresAlumnos_AfterExpand(sender As Object, e As TreeViewEventArgs) Handles treeviewSeleccionarPadresAlumnos.AfterExpand
        If e.Node.Nodes.Count = 1 AndAlso e.Node.Nodes(0).Tag Is Nothing Then
            Application.DoEvents()
            FillTreeViewEntidadesDeLaEntidad(e.Node)
        End If
    End Sub

    Private Sub PadreAlumno_MarcarYDesmarcarTodo(sender As Object, e As EventArgs) Handles menuitemPadreAlumnoMarcarTodos.Click, menuitemPadreAlumnoDesmarcarTodos.Click
        For Each TreeNodeCurrent As TreeNode In treeviewSeleccionarPadresAlumnos.Nodes
            TreeNodeCurrent.Checked = (CType(sender, ToolStripMenuItem) Is menuitemPadreAlumnoMarcarTodos)
        Next
    End Sub
#End Region

#Region "Paso 1 - Botones"
    Private Sub buttonPaso1Cancelar_Click() Handles buttonPaso1Cancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonPaso1Siguiente_Click() Handles buttonPaso1Siguiente.Click
        VerificarEntidades()
        MostrarEntidadesACorregir()

        panelPaso1.Visible = False
        panelPaso2.Visible = True
    End Sub
#End Region

#Region "Paso 2"
    Private Sub VerificarEntidades()
        Dim EntidadActual As Entidad
        Dim CorregirEntidad As Boolean
        Dim CorreccionDescripcion As String

        Const CORRECCION_DESCRIPCION_NOESALUMNO As String = "No es una Entidad del tipo Alumno."
        Const CORRECCION_DESCRIPCION_NOESPECIFICAENTIDADFACTURA As String = "No está especificado a quién se le factura."
        Const CORRECCION_DESCRIPCION_NOESPECIFICAPADRE As String = "Se indica que se facture a nombre del Padre, pero no se especifica el mismo."
        Const CORRECCION_DESCRIPCION_NOESPECIFICAMADRE As String = "Se indica que se facture a nombre de la Madre, pero no se especifica la misma."
        Const CORRECCION_DESCRIPCION_NOESPECIFICACATEGORIAIVA As String = "La Entidad a la que se le va a facturar, no tiene especificada la Categoría de IVA."

        Me.Cursor = Cursors.WaitCursor

        listEntidadesSeleccionadasOk = New List(Of Entidad)
        listEntidadesSeleccionadasCorregir = New List(Of Object)

        If tabcontrolMain.SelectedTab Is tabpageNivelesCursosAlumnos Then
            ' La selección está hecha por Niveles - Cursos - Alumnos

            ' Desactivo la actualización gráfica para expandir todos y que se carguen todos los Nodos
            treeviewSeleccionarNivelCursoAlumno.BeginUpdate()
            treeviewSeleccionarNivelCursoAlumno.ExpandAll()

            For Each TreeNodeNivel As TreeNode In treeviewSeleccionarNivelCursoAlumno.Nodes
                For Each TreeNodeAnio As TreeNode In TreeNodeNivel.Nodes
                    For Each TreeNodeCurso As TreeNode In TreeNodeAnio.Nodes
                        For Each TreeNodeEntidad As TreeNode In TreeNodeCurso.Nodes
                            CorregirEntidad = False
                            CorreccionDescripcion = ""

                            ' Si está seleccionado, lo verifico
                            If TreeNodeEntidad.Checked Then
                                EntidadActual = CType(TreeNodeEntidad.Tag, Entidad)

                                If EntidadActual.TipoAlumno = False Then
                                    CorregirEntidad = True
                                    CorreccionDescripcion &= CORRECCION_DESCRIPCION_NOESALUMNO & vbCrLf
                                End If
                                If EntidadActual.EntidadFactura Is Nothing Then
                                    CorregirEntidad = True
                                    CorreccionDescripcion &= CORRECCION_DESCRIPCION_NOESPECIFICAENTIDADFACTURA & vbCrLf
                                ElseIf EntidadActual.EntidadFactura = "A" Then
                                    If EntidadActual.IDCategoriaIVA Is Nothing Then
                                        CorregirEntidad = True
                                        CorreccionDescripcion &= CORRECCION_DESCRIPCION_NOESPECIFICACATEGORIAIVA & vbCrLf
                                    End If
                                ElseIf EntidadActual.EntidadFactura = "P" Then
                                    If EntidadActual.IDEntidadPadre Is Nothing Then
                                        CorregirEntidad = True
                                        CorreccionDescripcion &= CORRECCION_DESCRIPCION_NOESPECIFICAPADRE & vbCrLf
                                    ElseIf EntidadActual.EntidadPadre.IDCategoriaIVA Is Nothing Then
                                        CorregirEntidad = True
                                        CorreccionDescripcion &= CORRECCION_DESCRIPCION_NOESPECIFICACATEGORIAIVA & vbCrLf
                                    End If
                                ElseIf EntidadActual.EntidadFactura = "M" Then
                                    If EntidadActual.IDEntidadMadre Is Nothing Then
                                        CorregirEntidad = True
                                        CorreccionDescripcion &= CORRECCION_DESCRIPCION_NOESPECIFICAMADRE & vbCrLf
                                    ElseIf EntidadActual.EntidadMadre.IDCategoriaIVA Is Nothing Then
                                        CorregirEntidad = True
                                        CorreccionDescripcion &= CORRECCION_DESCRIPCION_NOESPECIFICACATEGORIAIVA & vbCrLf
                                    End If
                                End If

                                ' Si hay que corregir la Entidad, la agrego a la lista de Entidades a corregir
                                If CorregirEntidad Then
                                    CorreccionDescripcion = CorreccionDescripcion.Remove(CorreccionDescripcion.Length - vbCrLf.Length)
                                    listEntidadesSeleccionadasCorregir.Add(New With {.IDEntidad = EntidadActual.IDEntidad, .Apellido = EntidadActual.Apellido, .Nombre = EntidadActual.Nombre, .CorreccionDescripcion = CorreccionDescripcion})
                                Else
                                    listEntidadesSeleccionadasOk.Add(EntidadActual)
                                End If
                            End If
                        Next
                    Next
                Next
            Next
            treeviewSeleccionarNivelCursoAlumno.EndUpdate()
        Else
            ' La selección está hecha por Padres - Hijos
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MostrarEntidadesACorregir()
        ' TODO: Ordenar la lista de Entidades a corregir
        datagridviewEntidadesCorregir.AutoGenerateColumns = False
        datagridviewEntidadesCorregir.DataSource = listEntidadesSeleccionadasCorregir

        labelPaso2Pie.Text = "Entidades a corregir: " & listEntidadesSeleccionadasCorregir.Count.ToString
    End Sub

    Private Sub buttonPaso2Anterior_Click() Handles buttonPaso2Anterior.Click
        panelPaso1.Visible = True
        panelPaso2.Visible = False
    End Sub
#End Region

End Class