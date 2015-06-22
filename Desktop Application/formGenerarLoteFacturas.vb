Imports System.Drawing.Printing

Public Class formGenerarLoteFacturas
    Private dbcColegio As CSColegioContext

    Private listEntidadesSeleccionadasOk As List(Of Entidad)
    'Private listEntidadesSeleccionadasCorregir As IList(Of EntidadACorregir)
    Private listEntidadesSeleccionadasCorregir As IList(Of Object)

    Private FacturaLote As New ComprobanteLote
    Private listFacturas As List(Of ComprobanteCabecera)

    Private AnioLectivo As Integer
    Private MesAFacturar As Byte
    Private MesAFacturarNombre As String
    Private FechaServicioDesde As Date
    Private FechaServicioHasta As Date
    Private FechaVencimiento As Date

    Private Const NODO_CARGANDO_TEXTO As String = "Cargando..."

    Private Class EntidadACorregir
        Friend Property IDEntidad() As Integer
        Friend Property Apellido As String
        Friend Property Nombre As String
        Friend Property ApellidoNombre As String
        Friend Property CorreccionDescripcion As String
    End Class

    Private Sub formGenerarLoteFacturas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        dbcColegio.Dispose()
        listEntidadesSeleccionadasOk = Nothing
        listEntidadesSeleccionadasCorregir = Nothing
        listFacturas = Nothing
    End Sub

    ' TODO: Verificar que no se facture 2 veces en el mismo período al mismo alumno

    Private Sub formGenerarLoteFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbcColegio = New CSColegioContext

        AnioLectivo = Today.Year
        MesAFacturar = CByte(Today.Month)
        MesAFacturarNombre = StrConv(MonthName(MesAFacturar), VbStrConv.ProperCase)

        FechaServicioDesde = New Date(AnioLectivo, MesAFacturar, 1)
        FechaServicioHasta = FechaServicioDesde.AddMonths(1).AddDays(-1)
        FechaVencimiento = New Date(AnioLectivo, MesAFacturar, CSM_Parameter.GetIntegerAsByte(Parametros.CUOTA_MENSUAL_VENCIMIENTO_DIA))

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

        Select Case EntidadActual.EntidadFactura
            Case Nothing
                CorregirEntidad = True
                CorreccionDescripcion &= "No está especificado a quién se le factura." & vbCrLf

            Case Constantes.ENTIDADFACTURA_ALUMNO
                ' Se le factura al Alumno
                If EntidadActual.IDCategoriaIVA Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "El Alumno no tiene especificada la Categoría de IVA." & vbCrLf
                End If
                If EntidadActual.DocumentoNumero Is Nothing And EntidadActual.FacturaDocumentoNumero Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "El Alumno no tiene especificado el Tipo y Número de Documento." & vbCrLf
                End If

            Case Constantes.ENTIDADFACTURA_PADRE
                ' Se le factura al Padre
                If EntidadActual.IDEntidadPadre Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "Se indica que se facture al Padre, pero no se especifica el mismo." & vbCrLf
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

            Case Constantes.ENTIDADFACTURA_MADRE
                ' Se le factura a la Madre
                If EntidadActual.IDEntidadMadre Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "Se indica que se facture a la Madre, pero no se especifica la misma." & vbCrLf
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

            Case Constantes.ENTIDADFACTURA_AMBOSPADRES
                ' Se le factura a ambos Padres (50% a cada uno)
                If EntidadActual.IDEntidadPadre Is Nothing And EntidadActual.IDEntidadMadre Is Nothing Then
                    CorregirEntidad = True
                    CorreccionDescripcion &= "Se indica que se facture a ambos Padres, pero no se especifica ninguno de los dos." & vbCrLf
                Else

                    ' Padre
                    If EntidadActual.IDEntidadPadre Is Nothing Then
                        CorregirEntidad = True
                        CorreccionDescripcion &= "Se indica que se facture a ambos Padres, pero no se especifica el Padre." & vbCrLf
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

                    ' Madre
                    If EntidadActual.IDEntidadMadre Is Nothing Then
                        CorregirEntidad = True
                        CorreccionDescripcion &= "Se indica que se facture a ambos Padres, pero no se especifica la Madre." & vbCrLf
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
        End Select

        ' Si hay que corregir la Entidad, la agrego a la lista de Entidades a corregir
        If CorregirEntidad Then
            CorreccionDescripcion = CorreccionDescripcion.Remove(CorreccionDescripcion.Length - vbCrLf.Length)
            listEntidadesSeleccionadasCorregir.Add(New With {.IDEntidad = EntidadActual.IDEntidad, .Apellido = EntidadActual.Apellido, .Nombre = EntidadActual.Nombre, .ApellidoNombre = EntidadActual.ApellidoNombre, .CorreccionDescripcion = CorreccionDescripcion})
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
        Dim LoteNombre As String

        LoteNombre = InputBox("Ingrese el nombre del Lote a Generar:", My.Application.Info.Title, String.Format("Período {0}/{1}", MesAFacturar, AnioLectivo))

        GenerarComprobantes(LoteNombre)
        MostrarPaneles(3)
    End Sub
#End Region

#Region "Paso 3 - Generación"
    Private Sub GenerarComprobantes(ByVal LoteNombre As String)
        Dim dbcGeneracion As New CSColegioContext

        ' Parámetros
        Dim IDArticulo As Short
        Dim ComprobanteEntidadMayusculas As Boolean

        ' Datos de la Factura
        Dim NextID As Integer
        Dim ComprobanteTipo As New ComprobanteTipo
        Dim ComprobanteTipoPuntoVenta As ComprobanteTipoPuntoVenta
        Dim PuntoVenta As New PuntoVenta
        Dim NextComprobanteNumero As String = ""

        Dim FacturaCabecera As New ComprobanteCabecera
        Dim FacturaDetalle As ComprobanteDetalle

        Dim Fecha As Date

        Me.Cursor = Cursors.WaitCursor

        listFacturas = New List(Of ComprobanteCabecera)

        ' Cargo los parámetros en variables para reducir tiempo de procesamiento
        IDArticulo = CSM_Parameter.GetIntegerAsShort(Parametros.CUOTA_MENSUAL_ARTICULO_ID)
        ComprobanteEntidadMayusculas = CSM_Parameter.GetBoolean(Parametros.COMPROBANTE_ENTIDAD_MAYUSCULAS, False).Value
        Fecha = System.DateTime.Now.Date

        ' Creo el Lote de Comprobantes
        With FacturaLote
            If dbcGeneracion.ComprobanteLote.Count = 0 Then
                .IDComprobanteLote = 1
            Else
                .IDComprobanteLote = dbcGeneracion.ComprobanteLote.Max(Function(cl) cl.IDComprobanteLote) + 1
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
            Select Case EntidadAlumno.EntidadFactura
                Case Constantes.ENTIDADFACTURA_ALUMNO
                    ' Se factura directamente al Alumno, así que lo agrego a él mismo como Titular de la Factura y como Alumno
                    FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno, Fecha, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, ComprobanteEntidadMayusculas)
                    FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                    FacturaCabecera.ImporteNeto = FacturaDetalle.PrecioTotal
                    FacturaCabecera.ImporteImpuesto = 0
                    FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteNeto
                    listFacturas.Add(FacturaCabecera)

                Case Constantes.ENTIDADFACTURA_PADRE
                    ' Se factura al Padre, así que primero busco si no está cargado en la lista (por otro Alumno)
                    FacturaCabecera = listFacturas.Find(Function(fc) fc.IDEntidad = EntidadAlumno.EntidadPadre.IDEntidad)
                    If FacturaCabecera Is Nothing Then
                        ' No existe la Factura del Padre
                        FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno.EntidadPadre, Fecha, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, ComprobanteEntidadMayusculas)
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                        FacturaCabecera.ImporteNeto = FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteNeto
                        listFacturas.Add(FacturaCabecera)
                    Else
                        ' Ya existem así que sólo agrego un item al Detalle
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                        FacturaCabecera.ImporteNeto = FacturaCabecera.ImporteNeto + FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteNeto
                    End If

                Case Constantes.ENTIDADFACTURA_MADRE
                    ' Se factura a la Madre, así que primero busco si no está cargada en la lista (por otro Alumno)
                    FacturaCabecera = listFacturas.Find(Function(fc) fc.IDEntidad = EntidadAlumno.EntidadMadre.IDEntidad)
                    If FacturaCabecera Is Nothing Then
                        ' No existe la Factura de la Madre
                        FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno.EntidadMadre, Fecha, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, ComprobanteEntidadMayusculas)
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                        FacturaCabecera.ImporteNeto = FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteNeto
                        listFacturas.Add(FacturaCabecera)
                    Else
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                        FacturaCabecera.ImporteNeto = FacturaCabecera.ImporteNeto + FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteNeto
                    End If

                Case Constantes.ENTIDADFACTURA_AMBOSPADRES
                    ' Se factura a los 2 Padres (50% a cada uno)

                    ' Busco si no está cargado el Padre en la lista (por otro Alumno)
                    FacturaCabecera = listFacturas.Find(Function(fc) fc.IDEntidad = EntidadAlumno.EntidadPadre.IDEntidad)
                    If FacturaCabecera Is Nothing Then
                        ' No existe la Factura del Padre
                        FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno.EntidadPadre, Fecha, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, ComprobanteEntidadMayusculas)
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                        FacturaCabecera.ImporteNeto = FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteNeto
                        listFacturas.Add(FacturaCabecera)
                    Else
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                        FacturaCabecera.ImporteNeto = FacturaCabecera.ImporteNeto + FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteNeto
                    End If

                    ' Busco si no está cargada la Madre en la lista (por otro Alumno)
                    FacturaCabecera = listFacturas.Find(Function(fc) fc.IDEntidad = EntidadAlumno.EntidadMadre.IDEntidad)
                    If FacturaCabecera Is Nothing Then
                        ' No existe la Factura de la Madre
                        FacturaCabecera = GenerarComprobanteCabecera(EntidadAlumno.EntidadMadre, Fecha, FechaVencimiento, FechaServicioDesde, FechaServicioHasta, FacturaLote.IDComprobanteLote, ComprobanteEntidadMayusculas)
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                        FacturaCabecera.ImporteNeto = FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteNeto
                        listFacturas.Add(FacturaCabecera)
                    Else
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, EntidadAlumno, IDArticulo)
                        FacturaCabecera.ImporteNeto = FacturaCabecera.ImporteNeto + FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteNeto
                    End If
            End Select
        Next

        ' Ordeno la lista de Facturas por Tipo de Comprobante
        listFacturas.OrderBy(Function(cc) cc.IDComprobanteTipo)

        ' Obtengo el ID del último Comprobante cargado
        If dbcGeneracion.ComprobanteCabecera.Count = 0 Then
            NextID = 0
        Else
            NextID = dbcGeneracion.ComprobanteCabecera.Max(Function(cc) cc.IDComprobante)
        End If

        ' Recorro todas las Facturas generadas para aplicarles los ID y los Números de Comprobante
        For Each FacturaCabeceraActual As ComprobanteCabecera In listFacturas
            With FacturaCabeceraActual
                NextID += 1
                .IDComprobante = NextID
                If ComprobanteTipo.IDComprobanteTipo <> .IDComprobanteTipo Then
                    ComprobanteTipo = dbcGeneracion.ComprobanteTipo.Find(.IDComprobanteTipo)
                    ComprobanteTipoPuntoVenta = ComprobanteTipo.ComprobanteTipoPuntoVenta.Where(Function(ctpv) ctpv.IDPuntoVenta = My.Settings.IDPuntoVenta).FirstOrDefault
                    If Not ComprobanteTipoPuntoVenta Is Nothing Then
                        PuntoVenta = ComprobanteTipoPuntoVenta.PuntoVenta
                    End If

                    ' Busco si ya hay un comprobante creado de este tipo para obtener el último número
                    NextComprobanteNumero = dbcGeneracion.ComprobanteCabecera.Where(Function(cc) cc.IDComprobanteTipo = .IDComprobanteTipo).Max(Function(cc) cc.Numero)
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

        dbcGeneracion.Dispose()

        datagridviewPaso3Cabecera.AutoGenerateColumns = False
        datagridviewPaso3Cabecera.DataSource = listFacturas

        labelPaso3Pie.Text = String.Format("Se generarán {0} Facturas.", listFacturas.Count)

        Me.Cursor = Cursors.Default
    End Sub

    Private Function GenerarComprobanteCabecera(ByRef EntidadCabecera As Entidad, ByVal Fecha As Date, ByVal FechaVencimiento As Date, ByVal FechaServicioDesde As Date, ByVal FechaServicioHasta As Date, ByVal IDFacturaLote As Integer, ByVal ComprobanteEntidadMayusculas As Boolean) As ComprobanteCabecera
        Dim FacturaCabecera As New ComprobanteCabecera

        With FacturaCabecera
            ' Cabecera
            .IDComprobanteTipo = EntidadCabecera.CategoriaIVA.VentaIDComprobanteTipo
            .Fecha = Fecha
            .FechaVencimiento = FechaVencimiento
            .FechaServicioDesde = FechaServicioDesde
            .FechaServicioHasta = FechaServicioHasta

            ' Entidad
            .IDEntidad = EntidadCabecera.IDEntidad
            If ComprobanteEntidadMayusculas Then
                .EntidadApellido = EntidadCabecera.Apellido.ToUpper
                .EntidadNombre = EntidadCabecera.Nombre.ToUpper
            Else
                .EntidadApellido = EntidadCabecera.Apellido
                .EntidadNombre = EntidadCabecera.Nombre
            End If

            ' Tipo y Número de Documento
            If Not EntidadCabecera.FacturaIDDocumentoTipo Is Nothing Then
                .IDDocumentoTipo = EntidadCabecera.FacturaIDDocumentoTipo.Value
                .DocumentoNumero = EntidadCabecera.FacturaDocumentoNumero
            ElseIf Not EntidadCabecera.IDDocumentoTipo Is Nothing Then
                .IDDocumentoTipo = EntidadCabecera.IDDocumentoTipo.Value
                .DocumentoNumero = EntidadCabecera.DocumentoNumero
            Else
                .IDDocumentoTipo = CSM_Parameter.GetIntegerAsByte(Parametros.CONSUMIDORFINAL_DOCUMENTOTIPO_ID)
                .DocumentoNumero = CSM_Parameter.GetString(Parametros.CONSUMIDORFINAL_DOCUMENTONUMERO)
            End If
            .IDCategoriaIVA = EntidadCabecera.IDCategoriaIVA.Value

            ' Domicilio
            .DomicilioCalle1 = EntidadCabecera.DomicilioCalle1
            .DomicilioNumero = EntidadCabecera.DomicilioNumero
            .DomicilioPiso = EntidadCabecera.DomicilioPiso
            .DomicilioDepartamento = EntidadCabecera.DomicilioDepartamento
            .DomicilioCalle2 = EntidadCabecera.DomicilioCalle2
            .DomicilioCalle3 = EntidadCabecera.DomicilioCalle3
            .DomicilioCodigoPostal = EntidadCabecera.DomicilioCodigoPostal
            .DomicilioIDProvincia = EntidadCabecera.DomicilioIDProvincia
            .DomicilioIDLocalidad = EntidadCabecera.DomicilioIDLocalidad

            .IDComprobanteLote = IDFacturaLote

            ' Auditoría
            .IDUsuarioCreacion = pUsuario.IDUsuario
            .FechaHoraCreacion = System.DateTime.Now
            .IDUsuarioModificacion = pUsuario.IDUsuario
            .FechaHoraModificacion = .FechaHoraCreacion
        End With

        Return FacturaCabecera
    End Function

    Private Function GenerarComprobanteDetalle(ByRef FacturaCabecera As ComprobanteCabecera, ByRef EntidadDetalle As Entidad, ByVal IDArticulo As Short) As ComprobanteDetalle
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
                If EntidadDetalle.EntidadFactura = Constantes.ENTIDADFACTURA_AMBOSPADRES Then
                    .PrecioUnitario = AnioLectivoCursoActual.ImporteCuota / 2
                Else
                    .PrecioUnitario = AnioLectivoCursoActual.ImporteCuota
                End If
                If EntidadDetalle.IDDescuento Is Nothing Then
                    .PrecioUnitarioDescuentoPorcentaje = 0
                    .PrecioUnitarioDescuentoImporte = 0
                Else
                    .PrecioUnitarioDescuentoPorcentaje = EntidadDetalle.Descuento.Porcentaje
                    .PrecioUnitarioDescuentoImporte = .PrecioUnitario * .PrecioUnitarioDescuentoPorcentaje / 100
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

            Using dbcGuardado As New CSColegioContext
                dbcGuardado.ComprobanteLote.Add(FacturaLote)
                dbcGuardado.ComprobanteCabecera.AddRange(listFacturas)

                dbcGuardado.SaveChanges()
            End Using

            Me.Cursor = Cursors.Default
            Return True
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            CSM_Error.ProcessError(ex, "Error al guardar las Facturas Generadas")
            Return False
        End Try
    End Function

    Private Sub Paso4MostrarDetalle() Handles datagridviewPaso3Cabecera.SelectionChanged
        datagridviewPaso3Detalle.AutoGenerateColumns = False
        datagridviewPaso3Detalle.DataSource = CType(datagridviewPaso3Cabecera.SelectedRows(0).DataBoundItem, ComprobanteCabecera).ComprobanteDetalle.ToList
    End Sub

    Private Sub buttonPaso3Anterior_Click() Handles buttonPaso3Anterior.Click
        MostrarPaneles(2)
    End Sub

    Private Sub buttonPaso3Finalizar_Click() Handles buttonPaso3Finalizar.Click
        If MsgBox("¿Confirma la Generación del Lote de Facturas?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
            If GuardarComprobantes() Then
                Me.Close()
            End If
        End If
    End Sub
#End Region

End Class