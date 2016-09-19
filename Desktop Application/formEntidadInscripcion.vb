Public Class formEntidadInscripcion

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)
    Private listAlumnosCursos As List(Of GridRowData_AlumnoCurso)
    Private listFacturas As List(Of Comprobante)
    Private mAnioLectivoActual As Integer
    Private mAnioLectivoProximo As Integer
    Private mFechaServicioDesde As Date
    Private mFechaServicioHasta As Date

    Public Class GridRowData_AlumnoCurso
        Public Property Seleccionado As Boolean
        Public Property Entidad As Entidad
        Public Property ApellidoNombre As String
        Public Property AnioLectivoCursoActual As AnioLectivoCurso
        Public Property AnioLectivoCursoActualNombre As String
        Public Property AnioLectivoCursoProximo As AnioLectivoCurso
        Public Property AnioLectivoCursoProximoNombre As String
    End Class
#End Region

#Region "Form stuff"
    Private Sub Me_Load() Handles Me.Load
        If Today.Month < 8 Then
            mAnioLectivoProximo = Today.Year
        Else
            mAnioLectivoProximo = Today.Year + 1
        End If
        mAnioLectivoActual = mAnioLectivoProximo - 1
        textboxAnioLectivo.Text = mAnioLectivoProximo.ToString
        mFechaServicioDesde = New Date(mAnioLectivoProximo, 1, 1)
        mFechaServicioHasta = New Date(mAnioLectivoProximo, 12, 31)
    End Sub

    Private Sub Me_Closed() Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        listAlumnosCursos = Nothing
        Me.Dispose()
    End Sub

#End Region

#Region "Load and Set Data"
 
#End Region

#Region "Controls behavior"
    Private Sub FacturaMostrarDetalle() Handles datagridviewFacturaCabecera.SelectionChanged
        datagridviewFacturaDetalle.AutoGenerateColumns = False
        If datagridviewFacturaCabecera.SelectedRows.Count > 0 Then
            datagridviewFacturaDetalle.DataSource = CType(datagridviewFacturaCabecera.SelectedRows(0).DataBoundItem, Comprobante).ComprobanteDetalle.ToList
        End If
    End Sub

    Private Sub Detalle_Ver() Handles datagridviewEntidades.DoubleClick
        Dim IDAnioProximo As Byte
        Dim IDTurnoProximo As Byte
        Dim DivisionProximo As String

        If datagridviewEntidades.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Alumno / Año-Curso Lectivo para editar.", vbInformation, My.Application.Info.Title)
        Else
            Dim GridRowData_AlumnoCursoActual As GridRowData_AlumnoCurso

            GridRowData_AlumnoCursoActual = CType(datagridviewEntidades.SelectedRows(0).DataBoundItem, GridRowData_AlumnoCurso)
            If GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo Is Nothing Then
                IDAnioProximo = 0
                IDTurnoProximo = 0
                DivisionProximo = ""
            Else
                IDAnioProximo = GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo.Curso.IDAnio
                IDTurnoProximo = GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo.Curso.IDTurno
                DivisionProximo = GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo.Curso.Division
            End If

            If formEntidadInscripcionDetalle.LoadAndShow(Me, GridRowData_AlumnoCursoActual.Entidad.ApellidoNombre, GridRowData_AlumnoCursoActual.AnioLectivoCursoActual, mAnioLectivoProximo, IDAnioProximo, IDTurnoProximo, DivisionProximo) Then
                Dim listAnioLectivoCursoProximo As List(Of AnioLectivoCurso)
                listAnioLectivoCursoProximo = (From c In mdbContext.Curso
                                               Join alc In mdbContext.AnioLectivoCurso On c.IDCurso Equals alc.IDCurso
                                               Where alc.AnioLectivo = mAnioLectivoProximo And c.IDAnio = IDAnioProximo And c.IDTurno = IDTurnoProximo And c.Division = DivisionProximo
                                               Select alc).ToList
                If listAnioLectivoCursoProximo.Count > 0 Then
                    GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo = listAnioLectivoCursoProximo.First
                Else
                    GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo = Nothing
                End If
                GenerarDescripcionAnioLectivoCursoProximo(GridRowData_AlumnoCursoActual)
                datagridviewEntidades.Refresh()
            End If
        End If
    End Sub
#End Region

#Region "Extra stuff"
    Private Sub MostrarPaneles(ByVal Paso As Byte)
        panelPaso1.Visible = (Paso = 1)
        panelPaso2.Visible = (Paso = 2)
        Application.DoEvents()
    End Sub
#End Region

#Region "Paso 1 - Selección"
    Private Sub EntidadSeleccionar() Handles buttonEntidad.Click
        Dim EntidadSeleccionada As Entidad

        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = True
        formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = True
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Otro.Checked = False
        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            EntidadSeleccionada = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
            textboxEntidad.Text = EntidadSeleccionada.ApellidoNombre
            textboxEntidad.Tag = EntidadSeleccionada.IDEntidad

            BuscarEntidadesYAniosLectivosCursos(EntidadSeleccionada)
        End If
        formEntidadesSeleccionar.Dispose()
    End Sub

    Private Sub BuscarEntidadesYAniosLectivosCursos(ByVal EntidadSeleccionada As Entidad)
        Me.Cursor = Cursors.WaitCursor

        datagridviewEntidades.SuspendLayout()

        ' Cargo la información de los Alumnos y de los Años Lectivos - Cursos de la base de datos
        If EntidadSeleccionada.TipoAlumno Then
            listAlumnosCursos = (From e In mdbContext.Entidad
                           From alca In e.AniosLectivosCursos
                           Join ca In mdbContext.Curso On alca.IDCurso Equals ca.IDCurso
                           Join aa In mdbContext.Anio On ca.IDAnio Equals aa.IDAnio
                           Join na In mdbContext.Nivel On aa.IDNivel Equals na.IDNivel
                           Join ta In mdbContext.Turno On ca.IDTurno Equals ta.IDTurno
                           Where e.IDEntidad = EntidadSeleccionada.IDEntidad And alca.AnioLectivo = mAnioLectivoActual
                           Select New GridRowData_AlumnoCurso With {.Seleccionado = True, .Entidad = e, .ApellidoNombre = e.ApellidoNombre, .AnioLectivoCursoActual = alca, .AnioLectivoCursoActualNombre = na.Nombre & " - " & aa.Nombre & " - " & ta.Nombre & " - " & ca.Division}).ToList
        ElseIf EntidadSeleccionada.TipoFamiliar Then
            listAlumnosCursos = (From e In mdbContext.Entidad
                           From alca In e.AniosLectivosCursos
                           Join ca In mdbContext.Curso On alca.IDCurso Equals ca.IDCurso
                           Join aa In mdbContext.Anio On ca.IDAnio Equals aa.IDAnio
                           Join na In mdbContext.Nivel On aa.IDNivel Equals na.IDNivel
                           Join ta In mdbContext.Turno On ca.IDTurno Equals ta.IDTurno
                           Where (e.IDEntidad = EntidadSeleccionada.IDEntidad Or e.IDEntidadPadre = EntidadSeleccionada.IDEntidad Or e.IDEntidadMadre = EntidadSeleccionada.IDEntidad Or e.IDEntidadTercero = EntidadSeleccionada.IDEntidad) And alca.AnioLectivo = mAnioLectivoActual
                           Select New GridRowData_AlumnoCurso With {.Seleccionado = True, .Entidad = e, .ApellidoNombre = e.ApellidoNombre, .AnioLectivoCursoActual = alca, .AnioLectivoCursoActualNombre = na.Nombre & " - " & aa.Nombre & " - " & ta.Nombre & " - " & ca.Division}).ToList
        End If

        ' Ahora busco el Curso próximo para cada uno de los Alumnos
        For Each GridRowData_AlumnoCursoActual As GridRowData_AlumnoCurso In listAlumnosCursos
            Dim AnioProximo As Anio

            AnioProximo = GridRowData_AlumnoCursoActual.AnioLectivoCursoActual.Curso.Anio.AnioSiguiente
            If (Not AnioProximo Is Nothing) Then
                Dim IDAnioProximo As Byte
                Dim IDTurnoActual As Byte
                Dim DivisionActual As String

                Dim listAnioLectivoCursoProximo As List(Of AnioLectivoCurso)

                Dim listTurnosProximos As List(Of Turno)
                Dim TurnoProximo As Turno
                Dim IDTurnoProximo As Byte

                Dim listDivisionesProximos As List(Of String)
                Dim DivisionProximo As String

                IDAnioProximo = AnioProximo.IDAnio
                IDTurnoActual = GridRowData_AlumnoCursoActual.AnioLectivoCursoActual.Curso.IDTurno
                DivisionActual = GridRowData_AlumnoCursoActual.AnioLectivoCursoActual.Curso.Division

                ' Busco si existe el Año próximo para el nuevo Año Lectivo - Curso con el mismo Turno y División
                listAnioLectivoCursoProximo = (From c In mdbContext.Curso
                                               Join alc In mdbContext.AnioLectivoCurso On c.IDCurso Equals alc.IDCurso
                                               Where alc.AnioLectivo = mAnioLectivoProximo And c.IDAnio = IDAnioProximo And c.IDTurno = IDTurnoActual And c.Division = DivisionActual
                                               Select alc).ToList
                If listAnioLectivoCursoProximo.Count > 0 Then
                    ' Si existe, así que lo asigno
                    GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo= listAnioLectivoCursoProximo.First
                    GenerarDescripcionAnioLectivoCursoProximo(GridRowData_AlumnoCursoActual)
                Else
                    ' No existe, así que verifico si el Turno disponible es el único
                    listTurnosProximos = (From c In mdbContext.Curso
                                          Join alc In mdbContext.AnioLectivoCurso On c.IDCurso Equals alc.IDCurso
                                          Join t In mdbContext.Turno On c.IDTurno Equals t.IDTurno
                                          Where alc.AnioLectivo = mAnioLectivoProximo And c.IDAnio = IDAnioProximo
                                          Select t).ToList
                    If listTurnosProximos.Count = 1 Then
                        ' Hay un sólo Turno, lo asigno
                        TurnoProximo = listTurnosProximos.First
                        IDTurnoProximo = TurnoProximo.IDTurno

                        ' Verifico si la División es la única
                        listDivisionesProximos = (From c In mdbContext.Curso
                                                  Join alc In mdbContext.AnioLectivoCurso On c.IDCurso Equals alc.IDCurso
                                                  Where alc.AnioLectivo = mAnioLectivoProximo And c.IDAnio = IDAnioProximo And c.IDTurno = IDTurnoProximo
                                                  Select c.Division).ToList
                        If listDivisionesProximos.Count = 1 Then
                            ' Hay una sola División, la asigno
                            DivisionProximo = listDivisionesProximos.First

                            listAnioLectivoCursoProximo = (From c In mdbContext.Curso
                                                           Join alc In mdbContext.AnioLectivoCurso On c.IDCurso Equals alc.IDCurso
                                                           Where alc.AnioLectivo = mAnioLectivoProximo And c.IDAnio = IDAnioProximo And c.IDTurno = IDTurnoProximo And c.Division = DivisionProximo
                                                           Select alc).ToList
                            If listAnioLectivoCursoProximo.Count > 0 Then
                                ' Asigno el nuevo Año Lectivo-Curso
                                GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo = listAnioLectivoCursoProximo.First
                                GenerarDescripcionAnioLectivoCursoProximo(GridRowData_AlumnoCursoActual)
                            End If
                        End If
                    End If
                End If
            End If
        Next

        datagridviewEntidades.AutoGenerateColumns = False
        datagridviewEntidades.DataSource = listAlumnosCursos

        datagridviewEntidades.ResumeLayout()

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub GenerarDescripcionAnioLectivoCursoProximo(ByRef GridRowData_AlumnoCursoActual As GridRowData_AlumnoCurso)
        With GridRowData_AlumnoCursoActual
            .AnioLectivoCursoProximoNombre = .AnioLectivoCursoProximo.Curso.Anio.Nivel.Nombre & " - " & .AnioLectivoCursoProximo.Curso.Anio.Nombre & " - " & .AnioLectivoCursoProximo.Curso.Turno.Nombre & " - " & .AnioLectivoCursoProximo.Curso.Division
        End With
    End Sub

    Private Sub buttonPaso1Cancelar_Click() Handles buttonPaso1Cancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonPaso1Siguiente_Click() Handles buttonPaso1Siguiente.Click
        If VerificarEntidades() Then
            If GenerarComprobantes() Then
                MostrarPaneles(2)
            End If
        End If
    End Sub
#End Region

#Region "Paso 2 - Verificación"
    Private Function VerificarEntidades() As Boolean
        Dim NoVerificada As Boolean = False
        Dim CorreccionDescripcion As String

        For Each GridRowData_AlumnoCursoActual As GridRowData_AlumnoCurso In listAlumnosCursos
            If GridRowData_AlumnoCursoActual.Seleccionado Then
                CorreccionDescripcion = ""
                If Not MiscFunctions.Entidad_VerificarParaEmitirComprobante(GridRowData_AlumnoCursoActual.Entidad, mAnioLectivoProximo, True, mFechaServicioDesde, mFechaServicioHasta, True, CorreccionDescripcion) Then
                    NoVerificada = True
                    MsgBox(String.Format("El Alumno {1} necesita correcciones.{0}{0}{2}", vbCrLf, GridRowData_AlumnoCursoActual.Entidad.ApellidoNombre, CorreccionDescripcion), MsgBoxStyle.Exclamation, My.Application.Info.Title)
                End If
                If GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo Is Nothing Then
                    MsgBox(String.Format("El Alumno {1} no tiene especificado el Año Lectivo-Curso próximo.", vbCrLf, GridRowData_AlumnoCursoActual.Entidad.ApellidoNombre), MsgBoxStyle.Exclamation, My.Application.Info.Title)
                End If
            End If
        Next
        Return Not NoVerificada
    End Function

    Private Sub buttonPaso2Anterior_Click() Handles buttonPaso2Anterior.Click
        MostrarPaneles(1)
    End Sub

    Private Sub buttonPaso2Finalizar_Click() Handles buttonPaso2Finalizar.Click
        If MsgBox("¿Confirma la Generación de la(s) Factura(s)?", CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
            If GuardarCambios() Then
                MsgBox(String.Format("Se han generado {1} Facturas.{0}{0}A continuación, se enviarán a la AFIP para obtener el C.A.E. correspondiente.", vbCrLf, listFacturas.Count), MsgBoxStyle.Information, My.Application.Info.Title)
                TransmitirComprobantes()
                Me.Close()
            End If
        End If
    End Sub
#End Region

#Region "Finalizar - Generación"
    Private Sub AgregarAnioLectivoCursos()
        For Each GridRowData_AlumnoCursoActual As GridRowData_AlumnoCurso In listAlumnosCursos
            If GridRowData_AlumnoCursoActual.Seleccionado Then
                GridRowData_AlumnoCursoActual.Entidad.AniosLectivosCursos.Add(GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo)
            End If
        Next
    End Sub

    Private Function GenerarComprobantes() As Boolean
        ' Parámetros
        Dim ArticuloActual As Articulo
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
        ArticuloActual = mdbContext.Articulo.Find(CS_Parameter.GetIntegerAsShort(Parametros.CUOTA_MATRICULA_ARTICULO_ID))
        ComprobanteEntidadMayusculas = CS_Parameter.GetBoolean(Parametros.COMPROBANTE_ENTIDAD_MAYUSCULAS, False).Value

        For Each GridRowData_AlumnoCursoActual As GridRowData_AlumnoCurso In listAlumnosCursos
            If GridRowData_AlumnoCursoActual.Entidad.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_ALUMNO Then
                ' Se factura directamente al Alumno, así que lo agrego a él mismo como Titular de la Factura y como Alumno
                FacturaCabecera = GenerarComprobanteCabecera(GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda, ComprobanteEntidadMayusculas)
                FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo, ArticuloActual)
                FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                FacturaCabecera.ImporteImpuesto = 0
                FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                listFacturas.Add(FacturaCabecera)
            End If

            '//////////////////////////////////////////////////////
            ' FACTURAR AL PADRE
            '//////////////////////////////////////////////////////
            If GridRowData_AlumnoCursoActual.Entidad.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_PADRE Or GridRowData_AlumnoCursoActual.Entidad.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or GridRowData_AlumnoCursoActual.Entidad.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                ' Se factura al Padre (entre otros posibles)
                If GridRowData_AlumnoCursoActual.Entidad.FacturaIndividual Then
                    ' El Alumno especifica que se le facture individualmente
                    FacturaCabecera = GenerarComprobanteCabecera(GridRowData_AlumnoCursoActual.Entidad.EntidadPadre, GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda, ComprobanteEntidadMayusculas)
                    FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo, ArticuloActual)
                    FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                    FacturaCabecera.ImporteImpuesto = 0
                    FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                    listFacturas.Add(FacturaCabecera)
                Else
                    ' Busco si existe una Factura de esta Entidad en la lista de Facturas (por otro Alumno)
                    FacturaCabecera = listFacturas.Find(Function(fc) fc.IDEntidad = GridRowData_AlumnoCursoActual.Entidad.IDEntidadPadre.Value)
                    If FacturaCabecera Is Nothing Then
                        ' No existe la Factura, la creo.
                        FacturaCabecera = GenerarComprobanteCabecera(GridRowData_AlumnoCursoActual.Entidad.EntidadPadre, GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda, ComprobanteEntidadMayusculas)
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo, ArticuloActual)
                        If FacturaDetalle Is Nothing Then
                            Return False
                        End If
                        FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                        listFacturas.Add(FacturaCabecera)
                    Else
                        ' Ya existe una Factura de ese Titular
                        If mdbContext.Entidad.Find(FacturaCabecera.ComprobanteDetalle.First.IDEntidad).FacturaIndividual Then
                            ' El Alumno que ya está en la Factura especifica que se le facture individualmente
                            FacturaCabecera = GenerarComprobanteCabecera(GridRowData_AlumnoCursoActual.Entidad.EntidadPadre, GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda, ComprobanteEntidadMayusculas)
                            FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo, ArticuloActual)
                            If FacturaDetalle Is Nothing Then
                                Return False
                            End If
                            FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                            FacturaCabecera.ImporteImpuesto = 0
                            FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                            listFacturas.Add(FacturaCabecera)
                        Else
                            ' No hay restricciones, así que sólo agrego un item al Detalle
                            FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo, ArticuloActual)
                            If FacturaDetalle Is Nothing Then
                                Return False
                            End If
                            If Not GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda Is Nothing Then
                                If FacturaCabecera.Leyenda Is Nothing Then
                                    FacturaCabecera.Leyenda = GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda
                                Else
                                    FacturaCabecera.Leyenda &= vbCrLf & GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda
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
            If GridRowData_AlumnoCursoActual.Entidad.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_MADRE Or GridRowData_AlumnoCursoActual.Entidad.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or GridRowData_AlumnoCursoActual.Entidad.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                ' Se factura a la Madre (entre otros posibles)
                If GridRowData_AlumnoCursoActual.Entidad.FacturaIndividual Then
                    ' El Alumno especifica que se le facture individualmente
                    FacturaCabecera = GenerarComprobanteCabecera(GridRowData_AlumnoCursoActual.Entidad.EntidadMadre, GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda, ComprobanteEntidadMayusculas)
                    FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo, ArticuloActual)
                    If FacturaDetalle Is Nothing Then
                        Return False
                    End If
                    FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                    FacturaCabecera.ImporteImpuesto = 0
                    FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                    listFacturas.Add(FacturaCabecera)
                Else
                    ' Busco si existe una Factura de esta Entidad en la lista de Facturas (por otro Alumno)
                    FacturaCabecera = listFacturas.Find(Function(fc) fc.IDEntidad = GridRowData_AlumnoCursoActual.Entidad.IDEntidadMadre.Value)
                    If FacturaCabecera Is Nothing Then
                        ' No existe la Factura, la creo.
                        FacturaCabecera = GenerarComprobanteCabecera(GridRowData_AlumnoCursoActual.Entidad.EntidadMadre, GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda, ComprobanteEntidadMayusculas)
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo, ArticuloActual)
                        If FacturaDetalle Is Nothing Then
                            Return False
                        End If
                        FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                        listFacturas.Add(FacturaCabecera)
                    Else
                        ' Ya existe una Factura de ese Titular
                        If mdbContext.Entidad.Find(FacturaCabecera.ComprobanteDetalle.First.IDEntidad).FacturaIndividual Then
                            ' El Alumno que ya está en la Factura especifica que se le facture individualmente
                            FacturaCabecera = GenerarComprobanteCabecera(GridRowData_AlumnoCursoActual.Entidad.EntidadMadre, GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda, ComprobanteEntidadMayusculas)
                            FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo, ArticuloActual)
                            If FacturaDetalle Is Nothing Then
                                Return False
                            End If
                            FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                            FacturaCabecera.ImporteImpuesto = 0
                            FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                            listFacturas.Add(FacturaCabecera)
                        Else
                            ' No hay restricciones, así que sólo agrego un item al Detalle
                            FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo, ArticuloActual)
                            If FacturaDetalle Is Nothing Then
                                Return False
                            End If
                            If Not GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda Is Nothing Then
                                If FacturaCabecera.Leyenda Is Nothing Then
                                    FacturaCabecera.Leyenda = GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda
                                Else
                                    FacturaCabecera.Leyenda &= vbCrLf & GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda
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
            If GridRowData_AlumnoCursoActual.Entidad.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or GridRowData_AlumnoCursoActual.Entidad.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS Then
                ' Se factura a un Tercero (entre otros posibles)
                If GridRowData_AlumnoCursoActual.Entidad.FacturaIndividual Then
                    ' El Alumno especifica que se le facture individualmente
                    FacturaCabecera = GenerarComprobanteCabecera(GridRowData_AlumnoCursoActual.Entidad.EntidadTercero, GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda, ComprobanteEntidadMayusculas)
                    FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo, ArticuloActual)
                    If FacturaDetalle Is Nothing Then
                        Return False
                    End If
                    FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                    FacturaCabecera.ImporteImpuesto = 0
                    FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                    listFacturas.Add(FacturaCabecera)
                Else
                    ' Busco si existe una Factura de esta Entidad en la lista de Facturas (por otro Alumno)
                    FacturaCabecera = listFacturas.Find(Function(fc) fc.IDEntidad = GridRowData_AlumnoCursoActual.Entidad.IDEntidadTercero.Value)
                    If FacturaCabecera Is Nothing Then
                        ' No existe la Factura, la creo.
                        FacturaCabecera = GenerarComprobanteCabecera(GridRowData_AlumnoCursoActual.Entidad.EntidadTercero, GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda, ComprobanteEntidadMayusculas)
                        FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo, ArticuloActual)
                        If FacturaDetalle Is Nothing Then
                            Return False
                        End If
                        FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                        FacturaCabecera.ImporteImpuesto = 0
                        FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                        listFacturas.Add(FacturaCabecera)
                    Else
                        ' Ya existe una Factura de ese Titular
                        If mdbContext.Entidad.Find(FacturaCabecera.ComprobanteDetalle.First.IDEntidad).FacturaIndividual Then
                            ' El Alumno que ya está en la Factura especifica que se le facture individualmente
                            FacturaCabecera = GenerarComprobanteCabecera(GridRowData_AlumnoCursoActual.Entidad.EntidadTercero, GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda, ComprobanteEntidadMayusculas)
                            FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo, ArticuloActual)
                            If FacturaDetalle Is Nothing Then
                                Return False
                            End If
                            FacturaCabecera.ImporteSubtotal = FacturaDetalle.PrecioTotal
                            FacturaCabecera.ImporteImpuesto = 0
                            FacturaCabecera.ImporteTotal = FacturaCabecera.ImporteSubtotal
                            listFacturas.Add(FacturaCabecera)
                        Else
                            ' No hay restricciones, así que sólo agrego un item al Detalle
                            FacturaDetalle = GenerarComprobanteDetalle(FacturaCabecera, GridRowData_AlumnoCursoActual.Entidad, GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo, ArticuloActual)
                            If FacturaDetalle Is Nothing Then
                                Return False
                            End If
                            If Not GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda Is Nothing Then
                                If FacturaCabecera.Leyenda Is Nothing Then
                                    FacturaCabecera.Leyenda = GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda
                                Else
                                    FacturaCabecera.Leyenda &= vbCrLf & GridRowData_AlumnoCursoActual.Entidad.FacturaLeyenda
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
        If mdbContext.Comprobante.Count = 0 Then
            NextID = 0
        Else
            NextID = mdbContext.Comprobante.Max(Function(cc) cc.IDComprobante)
        End If

        ' Recorro todas las Facturas generadas para aplicarles los ID y los Números de Comprobante
        For Each FacturaCabeceraActual As Comprobante In listFacturas
            With FacturaCabeceraActual
                NextID += 1
                .IDComprobante = NextID
                If ComprobanteTipo.IDComprobanteTipo <> .IDComprobanteTipo Then
                    ComprobanteTipo = mdbContext.ComprobanteTipo.Find(.IDComprobanteTipo)
                    ComprobanteTipoPuntoVenta = ComprobanteTipo.ComprobanteTipoPuntoVenta.Where(Function(ctpv) ctpv.IDPuntoVenta = My.Settings.IDPuntoVenta).FirstOrDefault
                    If ComprobanteTipoPuntoVenta Is Nothing Then
                        Exit For
                    End If
                    PuntoVenta = ComprobanteTipoPuntoVenta.PuntoVenta

                    ' Busco si ya hay un comprobante creado de este tipo para obtener el último número
                    NextComprobanteNumero = mdbContext.Comprobante.Where(Function(cc) cc.IDComprobanteTipo = .IDComprobanteTipo And cc.PuntoVenta = PuntoVenta.Numero).Max(Function(cc) cc.Numero)
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

        datagridviewFacturaCabecera.AutoGenerateColumns = False
        datagridviewFacturaCabecera.DataSource = listFacturas

        Me.Cursor = Cursors.Default

        Return True
    End Function

    Private Function GenerarComprobanteCabecera(ByRef EntidadCabecera As Entidad, ByVal LeyendaAlumno As String, ByVal ComprobanteEntidadMayusculas As Boolean) As Comprobante
        Dim FacturaCabecera As New Comprobante

        With FacturaCabecera
            ' Cabecera
            .IDComprobanteTipo = EntidadCabecera.CategoriaIVA.VentaIDComprobanteTipo
            .FechaEmision = DateTime.Today
            .FechaVencimiento = DateTime.Today
            .IDConcepto = Constantes.COMPROBANTE_CONCEPTO_SERVICIOS
            .FechaServicioDesde = mFechaServicioDesde
            .FechaServicioHasta = mFechaServicioHasta

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

            .IDComprobanteLote = Nothing

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

    Private Function GenerarComprobanteDetalle(ByRef FacturaCabecera As Comprobante, ByRef EntidadDetalle As Entidad, ByRef AnioLectivoCursoActual As AnioLectivoCurso, ByRef ArticuloActual As Articulo) As ComprobanteDetalle
        Dim FacturaDetalle As New ComprobanteDetalle
        Dim AnioLectivoCursoImporteActual As AnioLectivoCursoImporte

        AnioLectivoCursoImporteActual = AnioLectivoCursoActual.AnioLectivoCursoImporte.OrderByDescending(Function(alci) alci.MesInicio).FirstOrDefault

        If Not AnioLectivoCursoImporteActual Is Nothing Then
            With FacturaDetalle
                .Indice = CByte(FacturaCabecera.ComprobanteDetalle.Count + 1)
                .IDArticulo = ArticuloActual.IDArticulo
                .IDEntidad = EntidadDetalle.IDEntidad
                .IDAnioLectivoCurso = AnioLectivoCursoActual.IDAnioLectivoCurso
                .CuotaMes = Nothing
                .Cantidad = 1
                .Descripcion = String.Format(ArticuloActual.Descripcion, vbCrLf, ArticuloActual.Nombre, EntidadDetalle.IDEntidad, EntidadDetalle.Apellido, EntidadDetalle.Nombre, EntidadDetalle.ApellidoNombre, mAnioLectivoProximo)

                ' Precios
                Select Case EntidadDetalle.EmitirFacturaA
                    Case Constantes.ENTIDAD_EMITIRFACTURAA_ALUMNO, Constantes.ENTIDAD_EMITIRFACTURAA_PADRE, Constantes.ENTIDAD_EMITIRFACTURAA_MADRE, Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO
                        .PrecioUnitario = AnioLectivoCursoImporteActual.ImporteCuota
                    Case Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES
                        .PrecioUnitario = Decimal.Round(AnioLectivoCursoImporteActual.ImporteCuota / 2, My.Settings.DecimalesEnImportes, MidpointRounding.ToEven)
                    Case Constantes.ENTIDAD_EMITIRFACTURAA_TODOS
                        .PrecioUnitario = Decimal.Round(AnioLectivoCursoImporteActual.ImporteCuota / 3, My.Settings.DecimalesEnImportes, MidpointRounding.ToEven)
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
            Me.Cursor = Cursors.Default
            MsgBox("No hay precios cargados para la(s) Factura(s) que se intentan emitir.", MsgBoxStyle.Information, My.Application.Info.Title)
            Return Nothing
        End If
    End Function

    Private Function GuardarCambios() As Boolean
        Try
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()

            Using dbContext As New CSColegioContext(True)
                Dim EntidadActual As Entidad
                Dim AnioLectivoCursoActual As AnioLectivoCurso

                ' Agrego los Alumnos a los Cursos indicados
                For Each GridRowData_AlumnoCursoActual As GridRowData_AlumnoCurso In listAlumnosCursos
                    EntidadActual = dbContext.Entidad.Find(GridRowData_AlumnoCursoActual.Entidad.IDEntidad)
                    AnioLectivoCursoActual = dbContext.AnioLectivoCurso.Find(GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo.IDAnioLectivoCurso)
                    EntidadActual.AniosLectivosCursos.Add(AnioLectivoCursoActual)
                Next
                ' Agrego las Facturas generadas
                dbContext.Comprobante.AddRange(listFacturas)

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

    Private Sub TransmitirComprobantes()
        Dim LogPath As String = ""
        Dim LogFileName As String = ""

        Dim Certificado As String
        Dim WSAA_URL As String
        Dim WSFEv1_URL As String
        Dim AFIP_TicketAcceso As String
        Dim AFIP_Factura As CS_AFIP_WS.FacturaElectronicaCabecera
        Dim ConexionFacturaElectronica As Object = Nothing
        Dim ResultadoCAE As CS_AFIP_WS.ResultadoCAE
        Dim MensajeError As String

        Dim InternetProxy As String
        Dim CUIT_Emisor As String
        Dim MonedaLocal As Moneda
        Dim MonedaLocalCotizacion As MonedaCotizacion
        Dim ComprobanteTipoActual As New ComprobanteTipo

        Dim ArticuloActual As Articulo
        Dim IDConcepto As Byte = 0

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        If My.Settings.AFIP_WS_LogEnabled Then
            LogPath = CS_SpecialFolders.ProcessString(My.Settings.AFIP_WS_LogFolder)
            If Not LogPath.EndsWith("\") Then
                LogPath &= "\"
            End If
            LogFileName = CS_File.ProcessFilename(My.Settings.AFIP_WS_LogFileName)
        End If

        ' Leo los valores comunes a todas las facturas
        If My.Settings.AFIP_WS_ModoHomologacion Then
            Certificado = My.Settings.AFIP_WS_Certificado_Homologacion
            WSAA_URL = CS_Parameter.GetString(Parametros.AFIP_WS_AA_HOMOLOGACION)
            WSFEv1_URL = CS_Parameter.GetString(Parametros.AFIP_WS_FE_HOMOLOGACION)
        Else
            Certificado = My.Settings.AFIP_WS_Certificado_Produccion
            WSAA_URL = CS_Parameter.GetString(Parametros.AFIP_WS_AA_PRODUCCION)
            WSFEv1_URL = CS_Parameter.GetString(Parametros.AFIP_WS_FE_PRODUCCION)
        End If

        InternetProxy = CS_Parameter.GetString(Parametros.INTERNET_PROXY, "")
        CUIT_Emisor = CS_Parameter.GetString(Parametros.EMPRESA_CUIT)
        MonedaLocal = mdbContext.Moneda.Find(CS_Parameter.GetIntegerAsShort(Parametros.DEFAULT_MONEDA_ID))
        If MonedaLocal Is Nothing Then
            Me.Cursor = Cursors.WaitCursor
            MsgBox("No se ha especificado la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
            Exit Sub
        End If
        MonedaLocalCotizacion = mdbContext.MonedaCotizacion.Where(Function(mc) mc.IDMoneda = MonedaLocal.IDMoneda).FirstOrDefault
        If MonedaLocalCotizacion Is Nothing Then
            Me.Cursor = Cursors.WaitCursor
            MsgBox("No hay cotizaciones cargadas para la Moneda predeterminada.", vbExclamation, My.Application.Info.Title)
            Exit Sub
        End If

        ' Intento realizar la Autenticación en el Servidor de AFIP
        AFIP_TicketAcceso = CS_AFIP_WS.Login(WSAA_URL, InternetProxy, CS_AFIP_WS.SERVICIO_FACTURACION_ELECTRONICA, Certificado, My.Settings.AFIP_WS_ClavePrivada, LogPath, LogFileName)
        If AFIP_TicketAcceso = "" Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        For Each ComprobanteActual As Comprobante In listFacturas
            ' Hago que la grilla vaya mostrando la fila que se está procesando
            If Not ComprobanteActual Is Nothing Then
                If Not ComprobanteActual.CAE Is Nothing Then
                    ' La Factura ya tiene un CAE asignado. Esto no debería pasar, excepto que otra instancia de la Aplicación haya obtenido el CAE mientras esta ventana estaba abierta
                Else
                    AFIP_Factura = New CS_AFIP_WS.FacturaElectronicaCabecera
                    With AFIP_Factura
                        ' Cargo el Tipo de Comprobante si es distinto al anterior
                        If ComprobanteActual.IDComprobanteTipo <> ComprobanteTipoActual.IDComprobanteTipo Then
                            ComprobanteTipoActual = mdbContext.ComprobanteTipo.Find(ComprobanteActual.IDComprobanteTipo)
                        End If

                        ' Esto es para determinar el Concepto a especificar en el pedido del CAE
                        If ComprobanteActual.ComprobanteDetalle.Count > 0 Then
                            For Each CDetalle As ComprobanteDetalle In ComprobanteActual.ComprobanteDetalle
                                ArticuloActual = mdbContext.Articulo.Find(CDetalle.IDArticulo)
                                Select Case IDConcepto
                                    Case CByte(0)
                                        ' Es el primer Artículo, así que lo guardo
                                        IDConcepto = ArticuloActual.ArticuloGrupo.IDConcepto
                                    Case ArticuloActual.ArticuloGrupo.IDConcepto
                                        ' Es el mismo Concepto que el/los Artículos anteriores, no hago nada

                                    Case Else
                                        If (IDConcepto = Constantes.COMPROBANTE_CONCEPTO_PRODUCTO Or IDConcepto = Constantes.COMPROBANTE_CONCEPTO_SERVICIOS) And (ArticuloActual.ArticuloGrupo.IDConcepto = Constantes.COMPROBANTE_CONCEPTO_PRODUCTO Or ArticuloActual.ArticuloGrupo.IDConcepto = Constantes.COMPROBANTE_CONCEPTO_SERVICIOS) Then
                                            ' Hay Productos y Servicios, así que utilizo el Concepto correspondiente
                                            IDConcepto = Constantes.COMPROBANTE_CONCEPTO_PRODUCTOSYSERVICIOS
                                            Exit For
                                        End If
                                End Select
                            Next
                        Else
                            IDConcepto = Constantes.COMPROBANTE_CONCEPTO_PRODUCTO
                        End If
                        .Concepto = IDConcepto

                        ' Documento del Titular
                        .TipoDocumento = CShort(ComprobanteActual.IDDocumentoTipo)
                        .DocumentoNumero = CLng(CS_ValueTranslation.FromStringToOnlyDigitsString(ComprobanteActual.DocumentoNumero))

                        ' Tipo de Comprobante
                        .TipoComprobante = ComprobanteTipoActual.CodigoAFIP

                        ' Datos de la Cabecera
                        .PuntoVenta = CShort(ComprobanteActual.PuntoVenta)
                        .ComprobanteDesde = CInt(ComprobanteActual.Numero)
                        .ComprobanteHasta = CInt(ComprobanteActual.Numero)
                        .ComprobanteFecha = ComprobanteActual.FechaEmision

                        ' Importes
                        .ImporteTotal = ComprobanteActual.ImporteTotal
                        .ImporteTotalConc = 0
                        .ImporteNeto = ComprobanteActual.ImporteTotal
                        .ImporteOperacionesExentas = 0
                        .ImporteTributos = 0
                        .ImporteIVA = ComprobanteActual.ImporteImpuesto

                        ' Fechas
                        If ComprobanteActual.FechaServicioDesde.HasValue Then
                            .FechaServicioDesde = ComprobanteActual.FechaServicioDesde.Value
                        End If
                        If ComprobanteActual.FechaServicioHasta.HasValue Then
                            .FechaServicioHasta = ComprobanteActual.FechaServicioHasta.Value
                        End If
                        If ComprobanteActual.FechaVencimiento.HasValue Then
                            .FechaVencimientoPago = ComprobanteActual.FechaVencimiento.Value
                        End If

                        ' Moneda
                        .MonedaID = MonedaLocal.CodigoAFIP
                        .MonedaCotizacion = MonedaLocalCotizacion.CotizacionVenta

                        ' Comprobantes Aplicados
                        For Each ComprobanteAplicacionActual As ComprobanteAplicacion In ComprobanteActual.ComprobanteAplicacion_Aplicados
                            Dim AFIP_ComprobanteAsociado As New ComprobanteAsociado
                            AFIP_ComprobanteAsociado.TipoComprobante = ComprobanteAplicacionActual.ComprobanteAplicado.ComprobanteTipo.CodigoAFIP
                            AFIP_ComprobanteAsociado.ComprobanteNumero = CInt(ComprobanteAplicacionActual.ComprobanteAplicado.Numero)
                            AFIP_ComprobanteAsociado.PuntoVenta = CShort(ComprobanteAplicacionActual.ComprobanteAplicado.PuntoVenta)
                            .ComprobantesAsociados.Add(AFIP_ComprobanteAsociado)
                        Next
                    End With

                    ' Conecto al Servicio de Factura Electrónica
                    If ConexionFacturaElectronica Is Nothing Then
                        ConexionFacturaElectronica = CS_AFIP_WS.FacturaElectronica_Conectar(AFIP_TicketAcceso, WSFEv1_URL, InternetProxy, CUIT_Emisor, LogPath, LogFileName)
                        If ConexionFacturaElectronica Is Nothing Then
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End If

                    ' Obtengo el CAE
                    ResultadoCAE = CS_AFIP_WS.FacturaElectronica_ObtenerCAE(ConexionFacturaElectronica, AFIP_Factura, LogPath, LogFileName)
                    If ResultadoCAE Is Nothing Then
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    If ResultadoCAE.Resultado = CS_AFIP_WS.SOLICITUD_CAE_RESULTADO_ACEPTADO Then
                        mdbContext.Comprobante.Attach(ComprobanteActual)

                        ComprobanteActual.CAE = ResultadoCAE.Numero
                        ComprobanteActual.CAEVencimiento = ResultadoCAE.FechaVencimiento
                        ComprobanteActual.IDUsuarioTransmisionAFIP = pUsuario.IDUsuario
                        ComprobanteActual.FechaHoraTransmisionAFIP = DateTime.Now

                        mdbContext.SaveChanges()
                    Else
                        MensajeError = "Se Rechazó la Solicitud de CAE para el Comprobante Electrónico:"
                        MensajeError &= vbCrLf & vbCrLf
                        MensajeError &= String.Format("{0} N°: {1}", ComprobanteTipoActual.Nombre, ComprobanteActual.Numero)
                        MensajeError &= vbCrLf
                        MensajeError &= "Titular: " & ComprobanteActual.ApellidoNombre
                        MensajeError &= vbCrLf
                        MensajeError &= "Importe: " & FormatCurrency(ComprobanteActual.ImporteTotal)
                        If ResultadoCAE.Observaciones <> "" Then
                            MensajeError &= vbCrLf & vbCrLf
                            MensajeError &= "Observaciones: " & ResultadoCAE.Observaciones
                        End If
                        If ResultadoCAE.ErrorMessage <> "" Then
                            MensajeError &= vbCrLf & vbCrLf
                            MensajeError &= "Error: " & ResultadoCAE.ErrorMessage
                        End If
                        MsgBox(MensajeError, MsgBoxStyle.Exclamation, My.Application.Info.Title)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
            End If
        Next
        MsgBox(String.Format("Se han transmitido exitosamente {0} Comprobantes a AFIP.", listFacturas.Count, vbCrLf), MsgBoxStyle.Information, My.Application.Info.Title)

        Me.Cursor = Cursors.Default
    End Sub

#End Region

End Class