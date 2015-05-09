Public Class formGenerarLoteFacturas
    Private dbcColegio As CSColegioContext
    Private AnioLectivo As Integer = Today.Year
    Private Const NODO_CARGANDO_TEXTO As String = "Cargando..."

    Private Sub formGenerarLoteFacturas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbcColegio.Dispose()
    End Sub
    ' TODO: Verificar que todos los alumnos activos y que se encuentren cursando el año lectivo actual, tengan asociada una Entidad a nombre de la cual se va a emitir la Factura.
    ' Mostrar una lista con los Alumnos que estén "huérfanos" y/o que ninguno de sus "padres" tenga tildada la opción de factrarle

    ' TODO: Verificar que cada Entidad a la cual se le va a facturar, tenga los datos mínimos completos (Situación ante el IVA, etc.)
    ' Ofrecer la opción de aplicar la Categoria de IVA predeterminada a todos los que no hayan especificado otra.

    ' TODO: Verificar que no se facture 2 veces en el mismo período al mismo alumno

    Private Sub formGenerarLoteFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbcColegio = New CSColegioContext

        FillTreeViewNiveles()
        FillTreeViewPadres()

        lalbelPaso1Periodo.Text = "Período a Facturar: " & StrConv(MonthName(Today.Month), VbStrConv.ProperCase) & " de " & AnioLectivo
    End Sub

    Private Sub FillTreeViewNiveles()
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewNivelCursoAlumno.BeginUpdate()
        For Each NivelCurrent As Nivel In dbcColegio.Nivel.Where(Function(niv) niv.EsActivo = True)
            ' Agrego el nodo correspondiente al Nivel actual y agrego un nodo hijo que diga "cargando..." para cuando se expanda el nodo
            NewNode = New TreeNode(NivelCurrent.Nombre, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = My.Settings.GenerarLoteFacturasPreseleccionarTodos
            NewNode.Tag = NivelCurrent
            treeviewNivelCursoAlumno.Nodes.Add(NewNode)
        Next
        treeviewNivelCursoAlumno.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillTreeViewAniosDelNivel(ByRef NodoNivel As TreeNode)
        Dim NivelCurrent As Nivel
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewNivelCursoAlumno.BeginUpdate()
        NodoNivel.Nodes.RemoveAt(0)
        NivelCurrent = CType(NodoNivel.Tag, Nivel)
        For Each AnioCurrent As Anio In NivelCurrent.Anio.Where(Function(ani) ani.EsActivo = True)
            ' Agrego el nodo correspondiente al Año actual
            NewNode = New TreeNode(AnioCurrent.Nombre, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = NodoNivel.Checked
            NewNode.Tag = AnioCurrent
            NodoNivel.Nodes.Add(NewNode)
        Next
        treeviewNivelCursoAlumno.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillTreeViewCursosDelAnio(ByRef NodoAnio As TreeNode)
        Dim AnioCurrent As Anio
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewNivelCursoAlumno.BeginUpdate()
        NodoAnio.Nodes.RemoveAt(0)
        AnioCurrent = CType(NodoAnio.Tag, Anio)
        For Each CursoCurrent As Curso In AnioCurrent.Curso
            ' Agrego el nodo correspondiente al Curso actual
            NewNode = New TreeNode("Turno: " & CursoCurrent.Turno.Nombre & " - División: " & CursoCurrent.Division, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = NodoAnio.Checked
            NewNode.Tag = CursoCurrent
            NodoAnio.Nodes.Add(NewNode)
        Next
        treeviewNivelCursoAlumno.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillTreeViewEntidadesDelCurso(ByRef NodoCurso As TreeNode)
        Dim CursoCurrent As Curso
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewNivelCursoAlumno.BeginUpdate()
        NodoCurso.Nodes.RemoveAt(0)
        CursoCurrent = CType(NodoCurso.Tag, Curso)
        For Each EntidadCurrent As Entidad In CursoCurrent.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = AnioLectivo).FirstOrDefault().Entidades.Where(Function(ent) ent.EsActivo = True).OrderBy(Function(ent) ent.ApellidoNombre)
            ' Agrego el nodo correspondiente a la Entidad actual
            NewNode = New TreeNode(EntidadCurrent.ApellidoNombre)
            NewNode.Checked = NodoCurso.Checked
            NewNode.Tag = EntidadCurrent
            NodoCurso.Nodes.Add(NewNode)
        Next
        treeviewNivelCursoAlumno.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub treeviewNivelCursoAlumno_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles treeviewNivelCursoAlumno.AfterCheck
        For Each NodoActual As TreeNode In e.Node.Nodes
            NodoActual.Checked = e.Node.Checked
        Next
    End Sub

    Private Sub treeviewNivelCursoAlumno_AfterExpand(sender As Object, e As TreeViewEventArgs) Handles treeviewNivelCursoAlumno.AfterExpand
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

    Private Sub FillTreeViewPadres()
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewPadresAlumnos.BeginUpdate()
        For Each EntidadCurrent As Entidad In dbcColegio.Entidad.Where(Function(ent) ent.EsActivo = True And ent.TipoFamiliar).OrderBy(Function(ent) ent.ApellidoNombre)
            ' Agrego el nodo correspondiente al Padre/Madre actual y agrego un nodo hijo que diga "cargando..." para cuando se expanda el nodo
            NewNode = New TreeNode(EntidadCurrent.ApellidoNombre, {New TreeNode(NODO_CARGANDO_TEXTO)})
            NewNode.Checked = My.Settings.GenerarLoteFacturasPreseleccionarTodos
            NewNode.Tag = EntidadCurrent
            treeviewPadresAlumnos.Nodes.Add(NewNode)
        Next
        treeviewPadresAlumnos.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub FillTreeViewEntidadesDeLaEntidad(ByRef NodoEntidad As TreeNode)
        Dim EntidadNodoCurrent As Entidad
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewPadresAlumnos.BeginUpdate()
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
        treeviewPadresAlumnos.EndUpdate()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub treeviewPadresAlumnos_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles treeviewPadresAlumnos.AfterCheck
        For Each NodoActual As TreeNode In e.Node.Nodes
            NodoActual.Checked = e.Node.Checked
        Next
    End Sub

    Private Sub treeviewPadresAlumnos_AfterExpand(sender As Object, e As TreeViewEventArgs) Handles treeviewPadresAlumnos.AfterExpand
        If e.Node.Nodes.Count = 1 AndAlso e.Node.Nodes(0).Tag Is Nothing Then
            Application.DoEvents()
            FillTreeViewEntidadesDeLaEntidad(e.Node)
        End If
    End Sub

    Private Sub buttonPaso1Cancelar_Click(sender As Object, e As EventArgs) Handles buttonPaso1Cancelar.Click
        Me.Close()
    End Sub
End Class