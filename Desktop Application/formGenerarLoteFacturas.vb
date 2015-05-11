Public Class formGenerarLoteFacturas
    Private dbcColegio As CSColegioContext
    Private AnioLectivo As Integer = Today.Year
    Private Const NODO_CARGANDO_TEXTO As String = "Cargando..."

    Private listEntidadesSeleccionadasOk As List(Of Entidad)
    Private listEntidadesSeleccionadasCorregir As IList(Of EntidadACorregir)
    Private listEntidadesYAlumnosAFacturar As List(Of EntidadYAlumnosAFacturar)

    Private Class EntidadACorregir
        Friend Property IDEntidad() As Integer
        Friend Property Apellido As String
        Friend Property Nombre As String
        Friend Property ApellidoNombre As String
        Friend Property CorreccionDescripcion As String
    End Class

    Private Class EntidadYAlumnosAFacturar
        Friend Property IDEntidad() As Integer
        Friend Property ApellidoNombre As String
        Friend Property TitularFactura As Entidad
        Friend Property Alumnos As List(Of Entidad)

        Friend Sub New()
            Alumnos = New List(Of Entidad)
        End Sub

        Protected Overrides Sub Finalize()
            Alumnos = Nothing
            MyBase.Finalize()
        End Sub
    End Class

    ' TODO: Verificar que no se facture 2 veces en el mismo período al mismo alumno

    Private Sub formGenerarLoteFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbcColegio = New CSColegioContext

        FillTreeViewNiveles()
        FillTreeViewPadres()

        lalbelPaso1Pie.Text = "Período a Facturar: " & StrConv(MonthName(Today.Month), VbStrConv.ProperCase) & " de " & AnioLectivo

        MostrarPaneles(1)
    End Sub

    Private Sub formGenerarLoteFacturas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbcColegio.Dispose()
    End Sub

    Private Sub MostrarPaneles(ByVal Paso As Byte)
        panelPaso1.Visible = (Paso = 1)
        panelPaso2.Visible = (Paso = 2)
        panelPaso3.Visible = (Paso = 3)
    End Sub

#Region "Paso 1 - TreeView de Niveles - Cursos - Alumnos"
    Private Sub FillTreeViewNiveles()
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewPaso1NivelCursoAlumno.BeginUpdate()
        For Each NivelCurrent As Nivel In dbcColegio.Nivel.Where(Function(niv) niv.EsActivo = True)
            ' Agrego el nodo correspondiente al Nivel actual y agrego un nodo hijo que diga "cargando..." para cuando se expanda el nodo
            NewNode = New TreeNode(NivelCurrent.Nombre, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = My.Settings.GenerarLoteFacturasPreseleccionarTodos
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

#Region "Paso 1 - TreeView de Padres - Alumnos"
    Private Sub FillTreeViewPadres()
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewPaso1PadresAlumnos.BeginUpdate()
        For Each EntidadCurrent As Entidad In dbcColegio.Entidad.Where(Function(ent) ent.EsActivo = True And ent.TipoFamiliar And (ent.EntidadPadreHijas.Count > 0 Or ent.EntidadMadreHijas.Count > 0)).OrderBy(Function(ent) ent.ApellidoNombre)
            ' Agrego el nodo correspondiente al Padre/Madre actual y agrego un nodo hijo que diga "cargando..." para cuando se expanda el nodo
            NewNode = New TreeNode(EntidadCurrent.ApellidoNombre, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = My.Settings.GenerarLoteFacturasPreseleccionarTodos
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

#Region "Paso 1 - Botones"
    Private Sub buttonPaso1Cancelar_Click() Handles buttonPaso1Cancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonPaso1Siguiente_Click() Handles buttonPaso1Siguiente.Click
        VerificarEntidades()
        MostrarEntidadesACorregir()
        MostrarPaneles(2)
    End Sub
#End Region

#Region "Paso 2"
    Private Sub VerificarEntidades()
        ' TODO: Verificar que el mismo Alumno no esté en 2 cursos a la vez

        Me.Cursor = Cursors.WaitCursor

        listEntidadesSeleccionadasOk = New List(Of Entidad)
        listEntidadesSeleccionadasCorregir = New List(Of EntidadACorregir)

        If tabcontrolMain.SelectedTab Is tabpageNivelesCursosAlumnos Then
            ' La selección está hecha por Niveles - Cursos - Alumnos

            ' Desactivo la actualización gráfica para expandir todos y que se carguen todos los Nodos
            treeviewPaso1NivelCursoAlumno.BeginUpdate()
            'treeviewPaso1NivelCursoAlumno.ExpandAll()
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
            treeviewPaso1PadresAlumnos.ExpandAll()

            For Each TreeNodeEntidad As TreeNode In treeviewPaso1PadresAlumnos.Nodes
                For Each TreeNodeAlumno As TreeNode In TreeNodeEntidad.Nodes
                    If TreeNodeAlumno.Checked Then
                        VerificarEntidad(CType(TreeNodeAlumno.Tag, Entidad))
                    End If
                Next
            Next

            treeviewPaso1PadresAlumnos.EndUpdate()
        End If

        listEntidadesSeleccionadasOk.OrderBy(Function(ent) ent.ApellidoNombre)
        listEntidadesSeleccionadasCorregir.OrderBy(Function(eac) eac.ApellidoNombre)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VerificarEntidad(ByRef EntidadActual As Entidad)
        Dim CorregirEntidad As Boolean = False
        Dim CorreccionDescripcion As String = ""
        Dim EntidadACorregirActual As EntidadACorregir

        Const CORRECCION_DESCRIPCION_NOESALUMNO As String = "No es una Entidad del tipo Alumno."
        Const CORRECCION_DESCRIPCION_NOESPECIFICAENTIDADFACTURA As String = "No está especificado a quién se le factura."
        Const CORRECCION_DESCRIPCION_NOESPECIFICAPADRE As String = "Se indica que se facture a nombre del Padre, pero no se especifica el mismo."
        Const CORRECCION_DESCRIPCION_NOESPECIFICAMADRE As String = "Se indica que se facture a nombre de la Madre, pero no se especifica la misma."
        Const CORRECCION_DESCRIPCION_NOESPECIFICACATEGORIAIVA As String = "La Entidad a la que se le va a facturar, no tiene especificada la Categoría de IVA."

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
            EntidadACorregirActual = New EntidadACorregir
            EntidadACorregirActual.IDEntidad = EntidadActual.IDEntidad
            EntidadACorregirActual.Apellido = EntidadActual.Apellido
            EntidadACorregirActual.Nombre = EntidadActual.Nombre
            EntidadACorregirActual.ApellidoNombre = EntidadActual.ApellidoNombre
            EntidadACorregirActual.CorreccionDescripcion = CorreccionDescripcion

            listEntidadesSeleccionadasCorregir.Add(EntidadACorregirActual)
        Else
            listEntidadesSeleccionadasOk.Add(EntidadActual)
        End If
    End Sub

    Private Sub MostrarEntidadesACorregir()
        ' TODO - BUG: La Grilla de Entidades a corregir no muestra los datos de la Lista

        datagridviewPaso2.AutoGenerateColumns = True
        datagridviewPaso2.DataSource = listEntidadesSeleccionadasCorregir

        labelPaso2Pie.Text = "Entidades a corregir: " & listEntidadesSeleccionadasCorregir.Count.ToString

        buttonPaso2Siguiente.Enabled = (listEntidadesSeleccionadasCorregir.Count = 0)
    End Sub

    Private Sub buttonPaso2Anterior_Click() Handles buttonPaso2Anterior.Click
        MostrarPaneles(1)
    End Sub

    Private Sub buttonPaso2Siguiente_Click() Handles buttonPaso2Siguiente.Click
        GeneraArbolDeEntidadesConAlumnos()
        MostrarArbolDeEntidadesConAlumnos()
        MostrarPaneles(3)
    End Sub
#End Region

#Region "Paso 3"
    Private Sub GeneraArbolDeEntidadesConAlumnos()
        Dim EntidadYAlumnosAFacturarActual As EntidadYAlumnosAFacturar

        Me.Cursor = Cursors.WaitCursor

        listEntidadesYAlumnosAFacturar = New List(Of EntidadYAlumnosAFacturar)

        For Each EntidadAlumno As Entidad In listEntidadesSeleccionadasOk
            Select Case EntidadAlumno.EntidadFactura
                Case "A"
                    ' Se factura directamente al Alumno, así que lo agrego a él mismo como Titular de la Factura y como Alumno
                    EntidadYAlumnosAFacturarActual = New EntidadYAlumnosAFacturar
                    EntidadYAlumnosAFacturarActual.IDEntidad = EntidadAlumno.IDEntidad
                    EntidadYAlumnosAFacturarActual.ApellidoNombre = EntidadAlumno.ApellidoNombre
                    EntidadYAlumnosAFacturarActual.TitularFactura = EntidadAlumno
                    EntidadYAlumnosAFacturarActual.Alumnos.Add(EntidadAlumno)
                    listEntidadesYAlumnosAFacturar.Add(EntidadYAlumnosAFacturarActual)
                Case "P"
                    ' Se factura al Padre, así que primero busco si no está cargado en la lista (por otro Alumno)
                    EntidadYAlumnosAFacturarActual = listEntidadesYAlumnosAFacturar.Find(Function(eaf) eaf.IDEntidad = EntidadAlumno.EntidadPadre.IDEntidad)
                    If EntidadYAlumnosAFacturarActual Is Nothing Then
                        ' No existe el Padre
                        EntidadYAlumnosAFacturarActual = New EntidadYAlumnosAFacturar
                        EntidadYAlumnosAFacturarActual.IDEntidad = EntidadAlumno.EntidadPadre.IDEntidad
                        EntidadYAlumnosAFacturarActual.ApellidoNombre = EntidadAlumno.EntidadPadre.ApellidoNombre
                        EntidadYAlumnosAFacturarActual.TitularFactura = EntidadAlumno.EntidadPadre
                        EntidadYAlumnosAFacturarActual.Alumnos.Add(EntidadAlumno)
                        listEntidadesYAlumnosAFacturar.Add(EntidadYAlumnosAFacturarActual)
                    Else
                        EntidadYAlumnosAFacturarActual.Alumnos.Add(EntidadAlumno)
                    End If
                Case "M"
                    ' Se factura a la Madre, así que primero busco si no está cargada en la lista (por otro Alumno)
                    EntidadYAlumnosAFacturarActual = listEntidadesYAlumnosAFacturar.Find(Function(eaf) eaf.IDEntidad = EntidadAlumno.EntidadMadre.IDEntidad)
                    If EntidadYAlumnosAFacturarActual Is Nothing Then
                        ' No existe la Madre
                        EntidadYAlumnosAFacturarActual = New EntidadYAlumnosAFacturar
                        EntidadYAlumnosAFacturarActual.IDEntidad = EntidadAlumno.EntidadMadre.IDEntidad
                        EntidadYAlumnosAFacturarActual.ApellidoNombre = EntidadAlumno.EntidadMadre.ApellidoNombre
                        EntidadYAlumnosAFacturarActual.TitularFactura = EntidadAlumno.EntidadMadre
                        EntidadYAlumnosAFacturarActual.Alumnos.Add(EntidadAlumno)
                        listEntidadesYAlumnosAFacturar.Add(EntidadYAlumnosAFacturarActual)
                    Else
                        EntidadYAlumnosAFacturarActual.Alumnos.Add(EntidadAlumno)
                    End If
            End Select
        Next

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MostrarArbolDeEntidadesConAlumnos()
        Dim EntidadesCount As Integer = 0
        Dim AlumnosCount As Integer = 0
        Dim EntidadNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        listEntidadesYAlumnosAFacturar.Sort(Function(eac1, eac2) eac1.ApellidoNombre.CompareTo(eac2.ApellidoNombre))

        treeviewPaso3.BeginUpdate()
        For Each EntidadYAlumnosAFacturarActual As EntidadYAlumnosAFacturar In listEntidadesYAlumnosAFacturar
            EntidadesCount += 1
            EntidadNode = New TreeNode(EntidadYAlumnosAFacturarActual.TitularFactura.ApellidoNombre)
            For Each AlumnoActual As Entidad In EntidadYAlumnosAFacturarActual.Alumnos
                AlumnosCount += 1
                EntidadNode.Nodes.Add(New TreeNode(AlumnoActual.ApellidoNombre))
            Next
            treeviewPaso3.Nodes.Add(EntidadNode)
        Next
        treeviewPaso3.EndUpdate()

        labelPaso3Pie.Text = "Facturas a emitir: " & EntidadesCount & " - Alumnos: " & AlumnosCount

        buttonPaso3Siguiente.Enabled = (listEntidadesYAlumnosAFacturar.Count > 0)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub buttonPaso3Anterior_Click() Handles buttonPaso3Anterior.Click
        MostrarPaneles(2)
    End Sub

    Private Sub buttonPaso3Siguiente_Click() Handles buttonPaso3Siguiente.Click
        MostrarPaneles(4)
    End Sub
#End Region

End Class