Imports System.Drawing.Printing

Public Class formComprobantesGenerarLote

#Region "Declarations"
    Private mdbContext As CSColegioContext

    Private mlistEntidadesSeleccionadasOk As List(Of Entidad)
    Private mlistEntidadesSeleccionadasCorregir As List(Of EntidadACorregir)

    Private mFacturaLote As New ComprobanteLote
    Private mlistFacturas As List(Of Comprobante)

    Private mAnioLectivo As Short
    Private mMesAFacturar As Byte
    Private mMesAFacturarNombre As String

    Private mFechaEmision As Date
    Private mFechaServicioDesde As Date
    Private mFechaServicioHasta As Date

    Private Const NODO_CARGANDO_TEXTO As String = "Cargando..."

    Private Class EntidadACorregir
        Public Property IDEntidad() As Integer
        Public Property Apellido As String
        Public Property Nombre As String
        Public Property ApellidoNombre As String
        Public Property CorreccionDescripcion As String
    End Class

#End Region

#Region "Form stuff"
    Private Sub formGenerarLoteFacturas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mdbContext = New CSColegioContext(True)

        mAnioLectivo = CShort(Today.Year)
        mMesAFacturar = CByte(Today.Month)
        mMesAFacturarNombre = StrConv(MonthName(mMesAFacturar), VbStrConv.ProperCase)

        mFechaEmision = DateTime.Today
        mFechaServicioDesde = New Date(mAnioLectivo, mMesAFacturar, 1)
        mFechaServicioHasta = mFechaServicioDesde.AddMonths(1).AddDays(-1)

        datetimepickerFechaVencimiento.Value = New Date(mAnioLectivo, mMesAFacturar, CS_Parameter_System.GetIntegerAsByte(Parametros.CUOTA_MENSUAL_VENCIMIENTO1_DIA))
        If datetimepickerFechaVencimiento.Value.CompareTo(mFechaEmision) < 0 Then
            datetimepickerFechaVencimiento.Value = mFechaEmision
        End If
        datetimepickerFechaVencimiento.Checked = False

        FillTreeViewNiveles()
        FillTreeViewPadres()

        lalbelPaso1Pie.Text = "Período a Facturar: " & mMesAFacturarNombre & " de " & mAnioLectivo

        MostrarPaneles(1)
    End Sub

    Private Sub formGenerarLoteFacturas_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mlistEntidadesSeleccionadasOk = Nothing
        mlistEntidadesSeleccionadasCorregir = Nothing
        mlistFacturas = Nothing
    End Sub

#End Region

#Region "Extra stuff"
    Private Sub MostrarPaneles(ByVal Paso As Byte)
        panelPaso1.Visible = (Paso = 1)
        panelPaso2.Visible = (Paso = 2)
        panelPaso3.Visible = (Paso = 3)
        Application.DoEvents()
    End Sub
#End Region

#Region "Paso 1 - Selección - TreeView de Niveles - Cursos - Alumnos"
    Private Sub FillTreeViewNiveles()
        Dim NewNode As TreeNode

        Me.Cursor = Cursors.WaitCursor

        treeviewPaso1NivelCursoAlumno.BeginUpdate()
        For Each NivelCurrent As Nivel In mdbContext.Nivel.Where(Function(niv) niv.EsActivo = True)
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
        For Each AnioCurrent As Anio In NivelCurrent.Anios.Where(Function(ani) ani.EsActivo = True)
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
        AnioLectivoCursoCurrent = CursoCurrent.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = mAnioLectivo).SingleOrDefault()
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
        For Each EntidadCurrent As Entidad In mdbContext.Entidad.Where(Function(ent) ent.EsActivo = True And ent.TipoFamiliar And (ent.EntidadPadreHijas.Count > 0 Or ent.EntidadMadreHijas.Count > 0)).OrderBy(Function(ent) ent.ApellidoNombre)
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
            If EntidadHijoCurrent.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = mAnioLectivo).Count > 0 Then
                NewNode = New TreeNode(EntidadHijoCurrent.ApellidoNombre)
                NewNode.Checked = NodoEntidad.Checked
                NewNode.Tag = EntidadHijoCurrent
                NodoEntidad.Nodes.Add(NewNode)
            End If
        Next
        ' Ahora busco los Hijos de la Madre
        For Each EntidadHijoCurrent As Entidad In EntidadNodoCurrent.EntidadMadreHijas.Where(Function(ent) ent.EsActivo).OrderBy(Function(ent) ent.ApellidoNombre)
            If EntidadHijoCurrent.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = mAnioLectivo).Count > 0 Then
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
        Dim EntidadActual As Entidad
        Dim CorreccionDescripcion As String

        Me.Cursor = Cursors.WaitCursor

        mlistEntidadesSeleccionadasOk = New List(Of Entidad)
        mlistEntidadesSeleccionadasCorregir = New List(Of EntidadACorregir)

        'Antes que nada verifico que no haya Alumnos que están en más de un curso a la vez

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
                                EntidadActual = CType(TreeNodeEntidad.Tag, Entidad)
                                CorreccionDescripcion = ""
                                If ModuloComprobantes.Entidad_VerificarParaEmitirComprobante(EntidadActual, mAnioLectivo, False, mFechaServicioDesde, mFechaServicioHasta, False, CorreccionDescripcion) Then
                                    mlistEntidadesSeleccionadasOk.Add(EntidadActual)
                                Else
                                    If CorreccionDescripcion.Length > 0 Then
                                        mlistEntidadesSeleccionadasCorregir.Add(New EntidadACorregir With {.IDEntidad = EntidadActual.IDEntidad, .Apellido = EntidadActual.Apellido, .Nombre = EntidadActual.Nombre, .ApellidoNombre = EntidadActual.ApellidoNombre, .CorreccionDescripcion = CorreccionDescripcion})
                                    End If
                                End If
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
                            EntidadActual = CType(TreeNodeAlumno.Tag, Entidad)
                            CorreccionDescripcion = ""
                            If ModuloComprobantes.Entidad_VerificarParaEmitirComprobante(EntidadActual, mAnioLectivo, False, mFechaServicioDesde, mFechaServicioHasta, False, CorreccionDescripcion) Then
                                mlistEntidadesSeleccionadasOk.Add(EntidadActual)
                            Else
                                If CorreccionDescripcion.Length > 0 Then
                                    mlistEntidadesSeleccionadasCorregir.Add(New EntidadACorregir With {.IDEntidad = EntidadActual.IDEntidad, .Apellido = EntidadActual.Apellido, .Nombre = EntidadActual.Nombre, .ApellidoNombre = EntidadActual.ApellidoNombre, .CorreccionDescripcion = CorreccionDescripcion})
                                End If
                            End If
                        End If
                    Next
                End If
            Next

            treeviewPaso1PadresAlumnos.EndUpdate()
        End If

        mlistEntidadesSeleccionadasOk.OrderBy(Function(ent) ent.ApellidoNombre)
        mlistEntidadesSeleccionadasCorregir.OrderBy(Function(eac) CType(eac, EntidadACorregir).ApellidoNombre)

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub MostrarEntidadesACorregir()
        mlistEntidadesSeleccionadasCorregir = mlistEntidadesSeleccionadasCorregir.OrderBy(Function(ent) ent.ApellidoNombre).ToList

        datagridviewPaso2.AutoGenerateColumns = False
        datagridviewPaso2.DataSource = mlistEntidadesSeleccionadasCorregir

        labelPaso2Pie.Text = "Entidades a corregir: " & mlistEntidadesSeleccionadasCorregir.Count.ToString

        buttonPaso2Siguiente.Enabled = (mlistEntidadesSeleccionadasCorregir.Count = 0)
    End Sub

    Private Sub buttonPaso2Anterior_Click() Handles buttonPaso2Anterior.Click
        MostrarPaneles(1)
    End Sub

    Private Sub buttonPaso2Siguiente_Click() Handles buttonPaso2Siguiente.Click
        Dim LoteNombre As String
        Dim listAlumno_AnioLectivoCurso_AFacturar As New List(Of Alumno_AnioLectivoCurso_AFacturar)
        Dim Alumno_AnioLectivoCurso_AFacturarNuevo As Alumno_AnioLectivoCurso_AFacturar

        If datetimepickerFechaVencimiento.Checked Then
            If datetimepickerFechaVencimiento.Value.CompareTo(mFechaEmision) < 0 Then
                MsgBox("La Fecha de Vencimiento de las Facturas debe ser mayor o igual a la Fecha de Emisión, que es hoy.", MsgBoxStyle.Information, My.Application.Info.Title)
                datetimepickerFechaVencimiento.Focus()
                Exit Sub
            End If
        Else
            MsgBox("Debe especificar la Fecha de Vencimiento de las Facturas.", MsgBoxStyle.Information, My.Application.Info.Title)
            datetimepickerFechaVencimiento.Focus()
            Exit Sub
        End If

        LoteNombre = InputBox("Ingrese el nombre del Lote a Generar:", My.Application.Info.Title, String.Format("Período {0:00}/{1}", mMesAFacturar, mAnioLectivo))

        If LoteNombre.Trim.Length > 0 Then
            Using dbContext As New CSColegioContext(True)

                ' Verifico que no exista un Lote de Comprobantes con el mismo nombre, ya que esto no se permite en la
                ' base de datos, y además, porque podría significar que se están duplicando los Comprobentes
                If dbContext.ComprobanteLote.Where(Function(cl) cl.Nombre = LoteNombre.Trim).Count > 0 Then
                    MsgBox(String.Format("Ya existe un Lote con el mismo Nombre.{0}Verifique que no esté dupicando el Lote de Comprobantes.", ControlChars.CrLf), MsgBoxStyle.Exclamation, My.Application.Info.Title)
                    Exit Sub
                End If

                ' Creo el Lote de Comprobantes
                With mFacturaLote
                    If dbContext.ComprobanteLote.Count = 0 Then
                        .IDComprobanteLote = 1
                    Else
                        .IDComprobanteLote = dbContext.ComprobanteLote.Max(Function(cl) cl.IDComprobanteLote) + 1
                    End If
                    .FechaHora = Now
                    .Nombre = LoteNombre

                    ' Auditoría
                    .IDUsuarioCreacion = pUsuario.IDUsuario
                    .FechaHoraCreacion = System.DateTime.Now
                    .IDUsuarioModificacion = pUsuario.IDUsuario
                    .FechaHoraModificacion = .FechaHoraCreacion
                End With
            End Using

            mlistFacturas = New List(Of Comprobante)

            For Each EntidadActual As Entidad In mlistEntidadesSeleccionadasOk
                Alumno_AnioLectivoCurso_AFacturarNuevo = New Alumno_AnioLectivoCurso_AFacturar
                Alumno_AnioLectivoCurso_AFacturarNuevo.Alumno = EntidadActual
                Alumno_AnioLectivoCurso_AFacturarNuevo.AnioLectivoCurso_AFacturar = EntidadActual.AniosLectivosCursos.Where(Function(alc) alc.AnioLectivo = mAnioLectivo).FirstOrDefault

                listAlumno_AnioLectivoCurso_AFacturar.Add(Alumno_AnioLectivoCurso_AFacturarNuevo)
            Next

            If ModuloComprobantes.GenerarComprobantes(mFechaEmision, datetimepickerFechaVencimiento.Value, New Date(datetimepickerFechaVencimiento.Value.Year, datetimepickerFechaVencimiento.Value.Month, CS_Parameter_System.GetIntegerAsByte(Parametros.CUOTA_MENSUAL_VENCIMIENTO2_DIA)), New Date(datetimepickerFechaVencimiento.Value.Year, datetimepickerFechaVencimiento.Value.Month, CS_Parameter_System.GetIntegerAsByte(Parametros.CUOTA_MENSUAL_VENCIMIENTO3_DIA)), mFechaServicioDesde, mFechaServicioHasta, Constantes.COMPROBANTE_CONCEPTO_SERVICIOS, mFacturaLote.IDComprobanteLote, mAnioLectivo, mMesAFacturar, False, listAlumno_AnioLectivoCurso_AFacturar, mlistFacturas) Then

                datagridviewPaso3Cabecera.AutoGenerateColumns = False
                datagridviewPaso3Cabecera.DataSource = mlistFacturas

                labelPaso3Pie.Text = String.Format("Se generarán {0} Facturas.", mlistFacturas.Count)

                Me.Cursor = Cursors.Default

                MostrarPaneles(3)
            End If

        End If
    End Sub
#End Region

#Region "Paso 3 - Generación"
    Private Function GuardarComprobantes() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()

            Using dbContext As New CSColegioContext(True)
                dbContext.ComprobanteLote.Add(mFacturaLote)
                dbContext.Comprobante.AddRange(mlistFacturas)

                dbContext.SaveChanges()
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
        If datagridviewPaso3Cabecera.SelectedRows.Count > 0 Then
            datagridviewPaso3Detalle.DataSource = CType(datagridviewPaso3Cabecera.SelectedRows(0).DataBoundItem, Comprobante).ComprobanteDetalle.ToList
        End If
    End Sub

    Private Sub buttonPaso3Anterior_Click() Handles buttonPaso3Anterior.Click
        MostrarPaneles(2)
    End Sub

    Private Sub buttonPaso3Finalizar_Click() Handles buttonPaso3Finalizar.Click
        If MsgBox("¿Confirma la Generación del Lote de Facturas?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
            If GuardarComprobantes() Then
                MsgBox(String.Format("Se han generado {0} Facturas.", mlistFacturas.Count), MsgBoxStyle.Information, My.Application.Info.Title)
                Me.Close()
            End If
        End If
    End Sub
#End Region

End Class