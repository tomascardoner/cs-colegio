Public Class formEntidadInscripcion

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)

    Public Class GridRowData_AlumnoCurso
        Public Property EntidadApellidoNombre As String
        Public Property NivelNombre As String
        Public Property AnioNombre As String
        Public Property TurnoNombre As String
        Public Property Division As String
    End Class
#End Region

#Region "Form stuff"

#End Region

#Region "Load and Set Data"

#End Region

#Region "Controls behavior"
    Private Sub EntidadSeleccionar() Handles buttonEntidad.Click
        Dim EntidadSeleccionada As Entidad

        formEntidadesSeleccionar.menuitemEntidadTipo_PersonalColegio.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Docente.Checked = False
        formEntidadesSeleccionar.menuitemEntidadTipo_Alumno.Checked = True
        formEntidadesSeleccionar.menuitemEntidadTipo_Familiar.Checked = True
        formEntidadesSeleccionar.menuitemEntidadTipo_Proveedor.Checked = False

        If formEntidadesSeleccionar.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then

            listviewAlumnosAniosLectivosCursos.SuspendLayout()
            listviewAlumnosAniosLectivosCursos.Items.Clear()

            EntidadSeleccionada = CType(formEntidadesSeleccionar.datagridviewMain.SelectedRows(0).DataBoundItem, Entidad)
            textboxEntidad.Text = EntidadSeleccionada.ApellidoNombre
            textboxEntidad.Tag = EntidadSeleccionada.IDEntidad

            If EntidadSeleccionada.TipoAlumno Then

                Dim qryAlumnosCursos = From e In mdbContext.Entidad
                                       From alc In e.AniosLectivosCursos
                                       Join c In mdbContext.Curso On alc.IDCurso Equals c.IDCurso
                                       Join a In mdbContext.Anio On c.IDAnio Equals a.IDAnio
                                       Join n In mdbContext.Nivel On a.IDNivel Equals n.IDNivel
                                       Join t In mdbContext.Turno On c.IDTurno Equals t.IDTurno
                                       Where e.IDEntidad = EntidadSeleccionada.IDEntidad And alc.AnioLectivo = Today.Year
                                       Select New GridRowData_AlumnoCurso With {.EntidadApellidoNombre = e.ApellidoNombre, .NivelNombre = n.Nombre, .AnioNombre = a.Nombre, .TurnoNombre = t.Nombre, .Division = c.Division}

                For Each DataRow As GridRowData_AlumnoCurso In qryAlumnosCursos
                    Dim listviewitemAlumnoAnioLectivoCurso As New ListViewItem
                    listviewitemAlumnoAnioLectivoCurso = New ListViewItem
                    listviewitemAlumnoAnioLectivoCurso.Checked = True
                    listviewitemAlumnoAnioLectivoCurso.Text = DataRow.EntidadApellidoNombre
                    listviewitemAlumnoAnioLectivoCurso.SubItems.Add(String.Format("{0} - {1} - {2} - {3}", DataRow.NivelNombre, DataRow.AnioNombre, DataRow.TurnoNombre, DataRow.Division))
                    listviewAlumnosAniosLectivosCursos.Items.Add(listviewitemAlumnoAnioLectivoCurso)
                Next

            ElseIf EntidadSeleccionada.TipoFamiliar Then

                Dim qryAlumnosCursos = From e In mdbContext.Entidad
                                       From alc In e.AniosLectivosCursos
                                       Join c In mdbContext.Curso On alc.IDCurso Equals c.IDCurso
                                       Join a In mdbContext.Anio On c.IDAnio Equals a.IDAnio
                                       Join n In mdbContext.Nivel On a.IDNivel Equals n.IDNivel
                                       Join t In mdbContext.Turno On c.IDTurno Equals t.IDTurno
                                       Where ((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_ALUMNO And e.IDEntidad = EntidadSeleccionada.IDEntidad) Or ((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_PADRE Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) And e.IDEntidadPadre = EntidadSeleccionada.IDEntidad) Or ((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_MADRE Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_AMBOSPADRES Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) And e.IDEntidadMadre = EntidadSeleccionada.IDEntidad) Or ((e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TERCERO Or e.EmitirFacturaA = Constantes.ENTIDAD_EMITIRFACTURAA_TODOS) And e.IDEntidadTercero = EntidadSeleccionada.IDEntidad)) And alc.AnioLectivo = Today.Year
                                       Select New GridRowData_AlumnoCurso With {.EntidadApellidoNombre = e.ApellidoNombre, .NivelNombre = n.Nombre, .AnioNombre = a.Nombre, .TurnoNombre = t.Nombre, .Division = c.Division}

                For Each DataRow As GridRowData_AlumnoCurso In qryAlumnosCursos
                    Dim listviewitemAlumnoAnioLectivoCurso As New ListViewItem
                    listviewitemAlumnoAnioLectivoCurso = New ListViewItem
                    listviewitemAlumnoAnioLectivoCurso.Checked = True
                    listviewitemAlumnoAnioLectivoCurso.Text = DataRow.EntidadApellidoNombre
                    listviewitemAlumnoAnioLectivoCurso.SubItems.Add(String.Format("{0} - {1} - {2} - {3}", DataRow.NivelNombre, DataRow.AnioNombre, DataRow.TurnoNombre, DataRow.Division))
                    listviewAlumnosAniosLectivosCursos.Items.Add(listviewitemAlumnoAnioLectivoCurso)
                Next
            End If

            listviewAlumnosAniosLectivosCursos.ResumeLayout()
        End If
        formEntidadesSeleccionar.Dispose()
    End Sub
#End Region

End Class