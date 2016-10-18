Public Class formEntidadInscripcion

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)
    Private listAlumnosCursos As List(Of GridRowData_AlumnoCurso)
    Private listFacturas As List(Of Comprobante)
    Private mAnioLectivoActual As Short
    Private mAnioLectivoProximo As Short
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
            mAnioLectivoProximo = CShort(Today.Year)
        Else
            mAnioLectivoProximo = CShort(Today.Year + 1)
        End If
        mAnioLectivoActual = mAnioLectivoProximo - CShort(1)
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
            Dim listAlumno_AnioLectivoCurso_AFacturar As New List(Of Alumno_AnioLectivoCurso_AFacturar)
            Dim Alumno_AnioLectivoCurso_AFacturarNuevo As Alumno_AnioLectivoCurso_AFacturar

            listFacturas = New List(Of Comprobante)

            For Each GridRowData_AlumnoCursoActual As GridRowData_AlumnoCurso In listAlumnosCursos
                If GridRowData_AlumnoCursoActual.Seleccionado Then
                    Alumno_AnioLectivoCurso_AFacturarNuevo = New Alumno_AnioLectivoCurso_AFacturar
                    Alumno_AnioLectivoCurso_AFacturarNuevo.Alumno = GridRowData_AlumnoCursoActual.Entidad
                    Alumno_AnioLectivoCurso_AFacturarNuevo.AnioLectivoCurso_AFacturar = GridRowData_AlumnoCursoActual.AnioLectivoCursoProximo

                    listAlumno_AnioLectivoCurso_AFacturar.Add(Alumno_AnioLectivoCurso_AFacturarNuevo)
                End If
            Next

            If ModuloComprobantes.GenerarComprobantes(DateTime.Today, DateTime.Today, mFechaServicioDesde, mFechaServicioHasta, Constantes.COMPROBANTE_CONCEPTO_SERVICIOS, Nothing, mAnioLectivoProximo, 0, True, listAlumno_AnioLectivoCurso_AFacturar, listFacturas) Then
                datagridviewFacturaCabecera.AutoGenerateColumns = False
                datagridviewFacturaCabecera.DataSource = listFacturas

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
                If Not ModuloComprobantes.Entidad_VerificarParaEmitirComprobante(GridRowData_AlumnoCursoActual.Entidad, mAnioLectivoProximo, True, mFechaServicioDesde, mFechaServicioHasta, True, CorreccionDescripcion) Then
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
                    AnioLectivoCursoActual.Entidades.Add(EntidadActual)
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
        Dim Objeto_AFIP_WS As New CS_AFIP_WS.AFIP_WS

        Dim MensajeError As String

        If ModuloComprobantes.TransmitirAFIP_Inicializar(Objeto_AFIP_WS, My.Settings.AFIP_WS_ModoHomologacion) Then
            Me.Cursor = Cursors.WaitCursor
            Application.DoEvents()

            If ModuloComprobantes.TransmitirAFIP_IniciarSesion(Objeto_AFIP_WS) Then
                If ModuloComprobantes.TransmitirAFIP_ConectarServicio(Objeto_AFIP_WS) Then
                    For Each ComprobanteActual As Comprobante In listFacturas
                        If Not ComprobanteActual Is Nothing Then
                            If Not ComprobanteActual.CAE Is Nothing Then
                                If ModuloComprobantes.TransmitirAFIP_Comprobante(Objeto_AFIP_WS, ComprobanteActual) Then
                                    ' OK
                                ElseIf Objeto_AFIP_WS.UltimoResultadoCAE.Resultado = CS_AFIP_WS.SOLICITUD_CAE_RESULTADO_RECHAZADO Then
                                    MensajeError = "Se Rechazó la Solicitud de CAE para el Comprobante Electrónico:"
                                    MensajeError &= vbCrLf & vbCrLf
                                    MensajeError &= String.Format("{0} N°: {1}", ComprobanteActual.ComprobanteTipo.Nombre, ComprobanteActual.Numero)
                                    MensajeError &= vbCrLf
                                    MensajeError &= "Titular: " & ComprobanteActual.ApellidoNombre
                                    MensajeError &= vbCrLf
                                    MensajeError &= "Importe: " & FormatCurrency(ComprobanteActual.ImporteTotal)
                                    If Objeto_AFIP_WS.UltimoResultadoCAE.Observaciones <> "" Then
                                        MensajeError &= vbCrLf & vbCrLf
                                        MensajeError &= "Observaciones: " & Objeto_AFIP_WS.UltimoResultadoCAE.Observaciones
                                    End If
                                    If Objeto_AFIP_WS.UltimoResultadoCAE.ErrorMessage <> "" Then
                                        MensajeError &= vbCrLf & vbCrLf
                                        MensajeError &= "Error: " & Objeto_AFIP_WS.UltimoResultadoCAE.ErrorMessage
                                    End If
                                    MsgBox(MensajeError, MsgBoxStyle.Exclamation, My.Application.Info.Title)
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                Else
                                    Me.Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End If
                        End If
                    Next
                    MsgBox(String.Format("Se han transmitido exitosamente {0} Comprobantes a AFIP.", listFacturas.Count, vbCrLf), MsgBoxStyle.Information, My.Application.Info.Title)
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

End Class