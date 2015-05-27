Imports System.Drawing.Printing

Public Class formGenerarLoteFacturas
    Private dbcColegio As CSColegioContext
    Private AnioLectivo As Integer = Today.Year
    Private MesAFacturar As Byte = CByte(Today.Month)
    Private MesAFacturarNombre As String = StrConv(MonthName(MesAFacturar), VbStrConv.ProperCase)

    Private listEntidadesSeleccionadasOk As List(Of Entidad)
    'Private listEntidadesSeleccionadasCorregir As IList(Of EntidadACorregir)
    Private listEntidadesSeleccionadasCorregir As IList(Of Object)
    Private listFacturaTitularEItems As List(Of FacturaTitularEItems)

    Private Const NODO_CARGANDO_TEXTO As String = "Cargando..."

    Private Class EntidadACorregir
        Friend Property IDEntidad() As Integer
        Friend Property Apellido As String
        Friend Property Nombre As String
        Friend Property ApellidoNombre As String
        Friend Property CorreccionDescripcion As String
    End Class

    Private Class FacturaItem
        Friend Property Alumno As Entidad
        Friend Property IDAnioLectivoCurso As Short
        Friend Property NivelNombre As String
        Friend Property AnioNombre As String
        Friend Property TurnoNombre As String
        Friend Property Division As String
        Friend Property ImporteCuota As Decimal
    End Class

    Private Class FacturaTitularEItems
        Friend Property IDComprobanteTipo As Byte
        Friend Property IDEntidad() As Integer
        Friend Property ApellidoNombre As String
        Friend Property TitularFactura As Entidad
        Friend Property FacturaItems As List(Of FacturaItem)

        Friend Sub New()
            FacturaItems = New List(Of FacturaItem)
        End Sub

        Protected Overrides Sub Finalize()
            FacturaItems = Nothing
            MyBase.Finalize()
        End Sub
    End Class

    ' TODO: Verificar que no se facture 2 veces en el mismo período al mismo alumno

    Private Sub formGenerarLoteFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbcColegio = New CSColegioContext

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

#Region "Paso 1 - Selección - TreeView de Padres - Alumnos"
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
        'listEntidadesSeleccionadasCorregir = New List(Of EntidadACorregir)
        listEntidadesSeleccionadasCorregir = New List(Of Object)

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
        If EntidadActual.EntidadFactura Is Nothing Then
            CorregirEntidad = True
            CorreccionDescripcion &= "No está especificado a quién se le factura." & vbCrLf
        ElseIf EntidadActual.EntidadFactura = "A" Then
            ' Se le factura al Alumno
            If EntidadActual.IDCategoriaIVA Is Nothing Then
                CorregirEntidad = True
                CorreccionDescripcion &= "El Alumno no tiene especificada la Categoría de IVA." & vbCrLf
            End If
        ElseIf EntidadActual.EntidadFactura = "P" Then
            ' Se le factura al Padre
            If EntidadActual.IDEntidadPadre Is Nothing Then
                CorregirEntidad = True
                CorreccionDescripcion &= "Se indica que se facture al Padre, pero no se especifica el mismo." & vbCrLf
            ElseIf EntidadActual.EntidadPadre.IDCategoriaIVA Is Nothing Then
                CorregirEntidad = True
                CorreccionDescripcion &= "El Padre no tiene especificada la Categoría de IVA." & vbCrLf
            End If
        ElseIf EntidadActual.EntidadFactura = "M" Then
            ' Se le factura a la Madre
            If EntidadActual.IDEntidadMadre Is Nothing Then
                CorregirEntidad = True
                CorreccionDescripcion &= "Se indica que se facture a la Madre, pero no se especifica la misma." & vbCrLf
            ElseIf EntidadActual.EntidadMadre.IDCategoriaIVA Is Nothing Then
                CorregirEntidad = True
                CorreccionDescripcion &= "La Madre no tiene especificada la Categoría de IVA." & vbCrLf
            End If
        ElseIf EntidadActual.EntidadFactura = "2" Then
            ' Se le factura a ambos Padres (50% a cada uno)
            If EntidadActual.IDEntidadPadre Is Nothing And EntidadActual.IDEntidadMadre Is Nothing Then
                CorregirEntidad = True
                CorreccionDescripcion &= "Se indica que se facture a ambos Padres, pero no se especifica ninguno de los dos." & vbCrLf
            Else
                If EntidadActual.IDEntidadPadre Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "Se indica que se facture a ambos Padres, pero no se especifica el Padre." & vbCrLf
                ElseIf EntidadActual.EntidadPadre.IDCategoriaIVA Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "El Padre no tiene especificada la Categoría de IVA." & vbCrLf
                End If
                If EntidadActual.IDEntidadMadre Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "Se indica que se facture a ambos Padres, pero no se especifica la Madre." & vbCrLf
                ElseIf EntidadActual.EntidadMadre.IDCategoriaIVA Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "La Madre no tiene especificada la Categoría de IVA." & vbCrLf
                End If
            End If
        End If

        ' Si hay que corregir la Entidad, la agrego a la lista de Entidades a corregir
        If CorregirEntidad Then
            CorreccionDescripcion = CorreccionDescripcion.Remove(CorreccionDescripcion.Length - vbCrLf.Length)
            listEntidadesSeleccionadasCorregir.Add(New With {.IDEntidad = EntidadActual.IDEntidad, .Apellido = EntidadActual.Apellido, .Nombre = EntidadActual.Nombre, .ApellidoNombre = EntidadActual.ApellidoNombre, .CorreccionDescripcion = CorreccionDescripcion})
        Else
            listEntidadesSeleccionadasOk.Add(EntidadActual)
        End If
    End Sub

    Private Sub MostrarEntidadesACorregir()
        ' TODO - BUG: La Grilla de Entidades a corregir se muestra desordenada

        datagridviewPaso2.AutoGenerateColumns = False
        datagridviewPaso2.DataSource = listEntidadesSeleccionadasCorregir

        labelPaso2Pie.Text = "Entidades a corregir: " & listEntidadesSeleccionadasCorregir.Count.ToString

        buttonPaso2Siguiente.Enabled = (listEntidadesSeleccionadasCorregir.Count = 0)
    End Sub

    Private Sub buttonPaso2Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles buttonPaso2Print.Click
        Dim PreviewForm As New PrintPreviewDialog

        Me.Cursor = Cursors.WaitCursor

        PreviewForm.PrintPreviewControl.Zoom = 1
        PreviewForm.Document = printdocumentPaso2
        printdocumentPaso2.DefaultPageSettings.Landscape = True
        CType(PreviewForm, Form).StartPosition = FormStartPosition.Manual
        CSM_Form.MDIChild_PositionAndSize(CType(formMDIMain, Form), CType(PreviewForm, Form), formMDIMain.Form_ClientSize)
        PreviewForm.Show()

        Me.Cursor = Cursors.Default
    End Sub

    Protected Sub printdocumentPaso2_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs) Handles printdocumentPaso2.PrintPage
        Dim ColumnCount As Integer = datagridviewPaso2.ColumnCount
        Dim RowCount As Integer = datagridviewPaso2.RowCount

        Dim CellTopPos As Integer = printdocumentPaso2.PrinterSettings.DefaultPageSettings.Margins.Top

        For Row = 0 To RowCount - 1

            Dim CellLeftPos As Integer = printdocumentPaso2.PrinterSettings.DefaultPageSettings.Margins.Left

            For Cell = 0 To ColumnCount - 1

                Dim CellValue As String = datagridviewPaso2.Rows(Row).Cells(Cell).Value.ToString()
                Dim CellWidth = datagridviewPaso2.Rows(Row).Cells(Cell).Size.Width + 50
                Dim CellHeight = datagridviewPaso2.Rows(Row).Cells(Cell).Size.Height

                Dim Brush As New SolidBrush(Color.Black)
                e.Graphics.DrawString(CellValue, New Font("Century Gothic", 10), Brush, CellLeftPos, CellTopPos)
                If Cell = 3 Then
                    CellWidth = CInt(CellWidth * 1.3)
                End If
                e.Graphics.DrawRectangle(Pens.Black, CellLeftPos, CellTopPos, CellWidth, CellHeight)

                CellLeftPos += CellWidth
            Next

            CellTopPos += datagridviewPaso2.Rows(Row).Cells(0).Size.Height
        Next
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

#Region "Paso 3 - Confirmación"
    Private Sub GeneraArbolDeEntidadesConAlumnos()
        Dim FacturaTitularEItemsActual As FacturaTitularEItems
        Dim FacturaItemNuevo As FacturaItem

        Me.Cursor = Cursors.WaitCursor

        listFacturaTitularEItems = New List(Of FacturaTitularEItems)

        For Each EntidadAlumno As Entidad In listEntidadesSeleccionadasOk
            FacturaItemNuevo = New FacturaItem
            Select Case EntidadAlumno.EntidadFactura
                Case "A"
                    ' Se factura directamente al Alumno, así que lo agrego a él mismo como Titular de la Factura y como Alumno
                    FacturaTitularEItemsActual = New FacturaTitularEItems
                    FacturaTitularEItemsActual.IDComprobanteTipo = EntidadAlumno.CategoriaIVA.VentaIDComprobanteTipo
                    FacturaTitularEItemsActual.IDEntidad = EntidadAlumno.IDEntidad
                    FacturaTitularEItemsActual.ApellidoNombre = EntidadAlumno.ApellidoNombre
                    FacturaTitularEItemsActual.TitularFactura = EntidadAlumno
                    FacturaItemNuevo.Alumno = EntidadAlumno
                    FacturaTitularEItemsActual.FacturaItems.Add(FacturaItemNuevo)
                    listFacturaTitularEItems.Add(FacturaTitularEItemsActual)
                Case "P"
                    ' Se factura al Padre, así que primero busco si no está cargado en la lista (por otro Alumno)
                    FacturaTitularEItemsActual = listFacturaTitularEItems.Find(Function(eaf) eaf.IDEntidad = EntidadAlumno.EntidadPadre.IDEntidad)
                    If FacturaTitularEItemsActual Is Nothing Then
                        ' No existe el Padre
                        FacturaTitularEItemsActual = New FacturaTitularEItems
                        FacturaTitularEItemsActual.IDComprobanteTipo = EntidadAlumno.EntidadPadre.CategoriaIVA.VentaIDComprobanteTipo
                        FacturaTitularEItemsActual.IDEntidad = EntidadAlumno.EntidadPadre.IDEntidad
                        FacturaTitularEItemsActual.ApellidoNombre = EntidadAlumno.EntidadPadre.ApellidoNombre
                        FacturaTitularEItemsActual.TitularFactura = EntidadAlumno.EntidadPadre
                        FacturaItemNuevo.Alumno = EntidadAlumno
                        FacturaTitularEItemsActual.FacturaItems.Add(FacturaItemNuevo)
                        listFacturaTitularEItems.Add(FacturaTitularEItemsActual)
                    Else
                        FacturaItemNuevo.Alumno = EntidadAlumno
                        FacturaTitularEItemsActual.FacturaItems.Add(FacturaItemNuevo)
                    End If
                Case "M"
                    ' Se factura a la Madre, así que primero busco si no está cargada en la lista (por otro Alumno)
                    FacturaTitularEItemsActual = listFacturaTitularEItems.Find(Function(eaf) eaf.IDEntidad = EntidadAlumno.EntidadMadre.IDEntidad)
                    If FacturaTitularEItemsActual Is Nothing Then
                        ' No existe la Madre
                        FacturaTitularEItemsActual = New FacturaTitularEItems
                        FacturaTitularEItemsActual.IDComprobanteTipo = EntidadAlumno.EntidadMadre.CategoriaIVA.VentaIDComprobanteTipo
                        FacturaTitularEItemsActual.IDEntidad = EntidadAlumno.EntidadMadre.IDEntidad
                        FacturaTitularEItemsActual.ApellidoNombre = EntidadAlumno.EntidadMadre.ApellidoNombre
                        FacturaTitularEItemsActual.TitularFactura = EntidadAlumno.EntidadMadre
                        FacturaItemNuevo.Alumno = EntidadAlumno
                        FacturaTitularEItemsActual.FacturaItems.Add(FacturaItemNuevo)
                        listFacturaTitularEItems.Add(FacturaTitularEItemsActual)
                    Else
                        FacturaItemNuevo.Alumno = EntidadAlumno
                        FacturaTitularEItemsActual.FacturaItems.Add(FacturaItemNuevo)
                    End If
                Case "2"
                    ' Se factura a los 2 Padres (50% a cada uno)

                    ' Busco si no está cargado el Padre en la lista (por otro Alumno)
                    FacturaTitularEItemsActual = listFacturaTitularEItems.Find(Function(eaf) eaf.IDEntidad = EntidadAlumno.EntidadPadre.IDEntidad)
                    If FacturaTitularEItemsActual Is Nothing Then
                        ' No existe el Padre
                        FacturaTitularEItemsActual = New FacturaTitularEItems
                        FacturaTitularEItemsActual.IDComprobanteTipo = EntidadAlumno.EntidadPadre.CategoriaIVA.VentaIDComprobanteTipo
                        FacturaTitularEItemsActual.IDEntidad = EntidadAlumno.EntidadPadre.IDEntidad
                        FacturaTitularEItemsActual.ApellidoNombre = EntidadAlumno.EntidadPadre.ApellidoNombre
                        FacturaTitularEItemsActual.TitularFactura = EntidadAlumno.EntidadPadre
                        FacturaItemNuevo.Alumno = EntidadAlumno
                        FacturaTitularEItemsActual.FacturaItems.Add(FacturaItemNuevo)
                        listFacturaTitularEItems.Add(FacturaTitularEItemsActual)
                    Else
                        FacturaItemNuevo.Alumno = EntidadAlumno
                        FacturaTitularEItemsActual.FacturaItems.Add(FacturaItemNuevo)
                    End If

                    ' Busco si no está cargada la Madre en la lista (por otro Alumno)
                    FacturaTitularEItemsActual = listFacturaTitularEItems.Find(Function(eaf) eaf.IDEntidad = EntidadAlumno.EntidadMadre.IDEntidad)
                    If FacturaTitularEItemsActual Is Nothing Then
                        ' No existe la Madre
                        FacturaTitularEItemsActual = New FacturaTitularEItems
                        FacturaTitularEItemsActual.IDComprobanteTipo = EntidadAlumno.EntidadMadre.CategoriaIVA.VentaIDComprobanteTipo
                        FacturaTitularEItemsActual.IDEntidad = EntidadAlumno.EntidadMadre.IDEntidad
                        FacturaTitularEItemsActual.ApellidoNombre = EntidadAlumno.EntidadMadre.ApellidoNombre
                        FacturaTitularEItemsActual.TitularFactura = EntidadAlumno.EntidadMadre
                        FacturaItemNuevo.Alumno = EntidadAlumno
                        FacturaTitularEItemsActual.FacturaItems.Add(FacturaItemNuevo)
                        listFacturaTitularEItems.Add(FacturaTitularEItemsActual)
                    Else
                        FacturaItemNuevo.Alumno = EntidadAlumno
                        FacturaTitularEItemsActual.FacturaItems.Add(FacturaItemNuevo)
                    End If
            End Select
        Next

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MostrarArbolDeEntidadesConAlumnos()
        Dim EntidadesCount As Integer = 0
        Dim AlumnosCount As Integer = 0
        Dim EntidadNode As TreeNode
        Dim AnioLectivoCursoActual As AnioLectivoCurso
        Dim AlumnoImporteAFacturar As Decimal

        Me.Cursor = Cursors.WaitCursor

        listFacturaTitularEItems.Sort(Function(eac1, eac2) eac1.ApellidoNombre.CompareTo(eac2.ApellidoNombre))

        treeviewPaso3.BeginUpdate()
        treeviewPaso3.Nodes.Clear()
        For Each EntidadYAlumnosAFacturarActual As FacturaTitularEItems In listFacturaTitularEItems
            EntidadesCount += 1
            EntidadNode = New TreeNode(EntidadYAlumnosAFacturarActual.TitularFactura.ApellidoNombre)
            For Each FacturaItemActual As FacturaItem In EntidadYAlumnosAFacturarActual.FacturaItems
                AnioLectivoCursoActual = FacturaItemActual.Alumno.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = AnioLectivo).FirstOrDefault
                If Not AnioLectivoCursoActual Is Nothing Then
                    FacturaItemActual.IDAnioLectivoCurso = AnioLectivoCursoActual.IDAnioLectivoCurso
                    FacturaItemActual.NivelNombre = AnioLectivoCursoActual.Curso.Anio.Nivel.Nombre
                    FacturaItemActual.AnioNombre = AnioLectivoCursoActual.Curso.Anio.Nombre
                    FacturaItemActual.TurnoNombre = AnioLectivoCursoActual.Curso.Turno.Nombre
                    FacturaItemActual.Division = AnioLectivoCursoActual.Curso.Division

                    If FacturaItemActual.Alumno.IDDescuento Is Nothing Then
                        AlumnoImporteAFacturar = AnioLectivoCursoActual.ImporteCuota
                    Else
                        AlumnoImporteAFacturar = AnioLectivoCursoActual.ImporteCuota * (1 - (FacturaItemActual.Alumno.Descuento.Porcentaje / 100))
                    End If
                    If FacturaItemActual.Alumno.EntidadFactura = "2" Then
                        If EntidadYAlumnosAFacturarActual.TitularFactura Is FacturaItemActual.Alumno.EntidadPadre Then
                            AlumnosCount += 1
                        End If
                        AlumnoImporteAFacturar = AlumnoImporteAFacturar / 2
                    Else
                        AlumnosCount += 1
                    End If
                    FacturaItemActual.ImporteCuota = AlumnoImporteAFacturar
                    EntidadNode.Nodes.Add(New TreeNode(String.Format("Alumno: {0} - Curso: {1}, {2}, {3}, {4} - Importe: {5}", FacturaItemActual.Alumno.ApellidoNombre, FacturaItemActual.NivelNombre, FacturaItemActual.AnioNombre, FacturaItemActual.TurnoNombre, FacturaItemActual.Division, FormatCurrency(FacturaItemActual.ImporteCuota))))
                End If
            Next
            treeviewPaso3.Nodes.Add(EntidadNode)
        Next
        treeviewPaso3.EndUpdate()

        labelPaso3Pie.Text = "Facturas a emitir: " & EntidadesCount & " - Alumnos: " & AlumnosCount

        buttonPaso3Siguiente.Enabled = (listFacturaTitularEItems.Count > 0)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub buttonPaso3Anterior_Click() Handles buttonPaso3Anterior.Click
        MostrarPaneles(2)
    End Sub

    Private Sub buttonPaso3Siguiente_Click() Handles buttonPaso3Siguiente.Click
        MostrarPaneles(4)
        EmitirComprobantes()
    End Sub
#End Region

#Region "Paso 4 - Emisión"
    Private Sub EmitirComprobantes()
        Dim dbcEmision As New CSColegioContext
        Dim FacturaCabecera As ComprobanteCabecera
        Dim FacturaDetalle As ComprobanteDetalle

        Dim ComprobanteTipo As New ComprobanteTipo
        Dim NextComprobanteNumero As String = ""
        Dim FirstID As Integer
        Dim LastID As Integer
        Dim NextID As Integer
        Dim NextIndice As Byte
        Dim IDArticulo As Short
        Dim ComprobanteEntidadMayusculas As Boolean

        Dim ImporteNeto As Decimal
        Dim ImporteImpuesto As Decimal

        Dim listFacturas As New List(Of ComprobanteCabecera)

        Me.Cursor = Cursors.WaitCursor

        ' Ordeno la lista por Tipo de Comprobante para que de esa manera, para calcular la numeración, consulto la base de datos una sola vez por tipo de comprobante y después voy sumando uno
        listFacturaTitularEItems.OrderBy(Function(ftei) ftei.IDComprobanteTipo)

        If dbcEmision.ComprobanteCabecera.Count = 0 Then
            NextID = 0
        Else
            NextID = dbcEmision.ComprobanteCabecera.Max(Function(cc) cc.IDComprobante)
        End If
        FirstID = NextID + 1

        IDArticulo = CSM_Parameter.GetIntegerAsShort(Constants.PARAMETRO_ARTICULO_CUOTA_MENSUAL)
        ComprobanteEntidadMayusculas = CSM_Parameter.GetBoolean(Constants.PARAMETRO_COMPROBANTE_ENTIDAD_MAYUSCULAS, False).Value

        For Each EntidadYAlumnosAFacturarActual As FacturaTitularEItems In listFacturaTitularEItems
            If ComprobanteTipo.IDComprobanteTipo <> EntidadYAlumnosAFacturarActual.IDComprobanteTipo Then
                ComprobanteTipo = dbcEmision.ComprobanteTipo.Find(EntidadYAlumnosAFacturarActual.IDComprobanteTipo)
                ' Si el Comprobante no es de Emisión Electrónica, obtengo el nuevo Número de Comprobante
                If ComprobanteTipo.EmisionElectronica Then
                    NextComprobanteNumero = New String("0"c, 12)
                Else
                    NextComprobanteNumero = ComprobanteTipo.UltimoNumero
                End If
            End If
            If Not ComprobanteTipo.EmisionElectronica Then
                NextComprobanteNumero = NextComprobanteNumero.Substring(0, NextComprobanteNumero.Length - 8) & CStr(CInt(NextComprobanteNumero.Substring(NextComprobanteNumero.Length - 8)) + 1).PadLeft(8, "0"c)
            End If
            NextID += 1
            NextIndice = 0
            ImporteNeto = 0
            ImporteImpuesto = 0
            FacturaCabecera = New ComprobanteCabecera
            With FacturaCabecera
                .IDComprobante = NextID
                .IDComprobanteTipo = ComprobanteTipo.IDComprobanteTipo
                .ComprobanteNumero = NextComprobanteNumero
                .Fecha = System.DateTime.Now
                .IDEntidad = EntidadYAlumnosAFacturarActual.IDEntidad
                If ComprobanteEntidadMayusculas Then
                    .EntidadApellido = EntidadYAlumnosAFacturarActual.TitularFactura.Apellido.ToUpper
                    .EntidadNombre = EntidadYAlumnosAFacturarActual.TitularFactura.Nombre.ToUpper
                Else
                    .EntidadApellido = EntidadYAlumnosAFacturarActual.TitularFactura.Apellido
                    .EntidadNombre = EntidadYAlumnosAFacturarActual.TitularFactura.Nombre
                End If
                .CUIT = EntidadYAlumnosAFacturarActual.TitularFactura.CUIT_CUIL
                .IDCategoriaIVA = EntidadYAlumnosAFacturarActual.TitularFactura.IDCategoriaIVA.Value
                .DomicilioCalle1 = EntidadYAlumnosAFacturarActual.TitularFactura.DomicilioCalle1
                .DomicilioNumero = EntidadYAlumnosAFacturarActual.TitularFactura.DomicilioNumero
                .DomicilioPiso = EntidadYAlumnosAFacturarActual.TitularFactura.DomicilioPiso
                .DomicilioDepartamento = EntidadYAlumnosAFacturarActual.TitularFactura.DomicilioDepartamento
                .DomicilioCalle2 = EntidadYAlumnosAFacturarActual.TitularFactura.DomicilioCalle2
                .DomicilioCalle3 = EntidadYAlumnosAFacturarActual.TitularFactura.DomicilioCalle3
                .DomicilioCodigoPostal = EntidadYAlumnosAFacturarActual.TitularFactura.DomicilioCodigoPostal
                .DomicilioIDProvincia = EntidadYAlumnosAFacturarActual.TitularFactura.DomicilioIDProvincia
                .DomicilioIDLocalidad = EntidadYAlumnosAFacturarActual.TitularFactura.DomicilioIDLocalidad
                For Each FacturaItemActual As FacturaItem In EntidadYAlumnosAFacturarActual.FacturaItems
                    NextIndice += CByte(1)
                    FacturaDetalle = New ComprobanteDetalle
                    FacturaDetalle.Indice = NextIndice
                    FacturaDetalle.IDArticulo = IDArticulo
                    FacturaDetalle.IDEntidad = FacturaItemActual.Alumno.IDEntidad
                    FacturaDetalle.IDAnioLectivoCurso = FacturaItemActual.IDAnioLectivoCurso
                    FacturaDetalle.CuotaMes = MesAFacturar
                    FacturaDetalle.Cantidad = 1
                    FacturaDetalle.Descripcion = String.Format("Cuota de {0} de {1} - {2}", MesAFacturarNombre, AnioLectivo, FacturaItemActual.Alumno.ApellidoNombre)
                    FacturaDetalle.PrecioUnitario = FacturaItemActual.ImporteCuota
                    FacturaDetalle.PrecioUnitarioFinal = FacturaItemActual.ImporteCuota
                    FacturaDetalle.PrecioTotal = FacturaItemActual.ImporteCuota
                    .ComprobanteDetalle.Add(FacturaDetalle)
                    ImporteNeto += FacturaItemActual.ImporteCuota
                Next
                .ImporteNeto = ImporteNeto
                .ImporteImpuesto = ImporteImpuesto
                .ImporteTotal = ImporteNeto + ImporteImpuesto
                .IDUsuarioCreacion = pUsuario.IDUsuario
                .FechaHoraCreacion = System.DateTime.Now
                .IDUsuarioModificacion = pUsuario.IDUsuario
                .FechaHoraModificacion = .FechaHoraCreacion
            End With
            dbcColegio.ComprobanteCabecera.Add(FacturaCabecera)
            listFacturas.Add(FacturaCabecera)
        Next
        LastID = NextID

        Try
            dbcColegio.SaveChanges()
        Catch ex As Exception
            CSM_Error.ProcessError(ex, "Error al guardar los datos de las Facturas")
        End Try

        ' Muestro los comprobantes generados en la Grilla
        'Dim listFacturasGeneradas = (From cc In dbcEmision.ComprobanteCabecera
        '                            Join ct In dbcEmision.ComprobanteTipo On cc.IDComprobanteTipo Equals ct.IDComprobanteTipo
        '                            Join ci In dbcEmision.CategoriaIVA On cc.IDCategoriaIVA Equals ci.IDCategoriaIVA
        '                            Where cc.IDComprobante >= FirstID And cc.IDComprobante <= LastID
        '                            Order By cc.IDComprobante
        '                            Select ComprobanteTipoNombre = ct.Nombre, ComprobanteNumero = cc.ComprobanteNumero, EntidadApellido = cc.EntidadApellido, EntidadNombre = cc.EntidadNombre, CUIT = cc.CUIT, CategoriaIVANombre = ci.Nombre, ImporteTotal = cc.ImporteTotal).ToList

        datagridviewPaso4Cabecera.AutoGenerateColumns = False
        datagridviewPaso4Cabecera.DataSource = listFacturas

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Paso4MostrarDetalle() Handles datagridviewPaso4Cabecera.SelectionChanged
        'Dim listDetalleFactura = (From cd In dbcColegio.ComprobanteDetalle
        '                          Where cd.IDComprobante = CInt(datagridviewPaso4Cabecera.SelectedRows(0).Cells(0).Value)
        '                          Order By cd.Indice
        '                          Select Descripcion = cd.Descripcion, PrecioTotal = cd.PrecioTotal).ToList

        datagridviewPaso4Detalle.AutoGenerateColumns = False
        datagridviewPaso4Detalle.DataSource = CType(datagridviewPaso4Cabecera.SelectedRows(0).DataBoundItem, ComprobanteCabecera).ComprobanteDetalle.ToList
    End Sub

    Private Sub buttonPaso4Anterior_Click() Handles buttonPaso4Anterior.Click
        MostrarPaneles(3)
    End Sub

    Private Sub buttonPaso4Siguiente_Click() Handles buttonPaso4Siguiente.Click
        MostrarPaneles(5)
    End Sub
#End Region
End Class