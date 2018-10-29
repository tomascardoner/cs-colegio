Imports System.Globalization

Public Class formAnioLectivoCursosImportes

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)

    Private Class GridRowData
        Public Property IDAnioLectivoCurso As Short
        Public Property NivelNombre As String
        Public Property CursoNombre As String
        Public Property ImporteMatricula As Decimal
        Public Property ImporteCuota As Decimal
    End Class

    Private mlistGridRowData As List(Of GridRowData)
    Private mlistAnioLectivoCursoImporte As List(Of AnioLectivoCursoImporte)

    Private mSkipFilterData As Boolean = False
    Private mEditMode As Boolean = False
#End Region

#Region "Form stuff"
    Private Sub ChangeMode()
        buttonGuardar.Visible = mEditMode
        buttonCancelar.Visible = mEditMode
        buttonEditar.Visible = (mEditMode = False)
        buttonCerrar.Visible = (mEditMode = False)

        comboboxAnioLectivo.Enabled = Not mEditMode
        comboboxMesInicio.Enabled = Not mEditMode

        columnImporteMatricula.ReadOnly = Not mEditMode
        columnImporteCuota.ReadOnly = Not mEditMode
    End Sub

    Friend Sub SetAppearance()
        datagridviewMain.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont
    End Sub

    Private Sub Me_Load() Handles Me.Load
        SetAppearance()

        mSkipFilterData = True

        ' Cargo los ComboBox
        pFillAndRefreshLists.AnioLectivo(comboboxAnioLectivo, False, SortOrder.Ascending)
        comboboxAnioLectivo.SelectedIndex = comboboxAnioLectivo.FindStringExact(DateTime.Today.Year.ToString)
        pFillAndRefreshLists.Mes(comboboxMesInicio, True, False, True, False, False)
        comboboxMesInicio.SelectedIndex = 0

        mSkipFilterData = False

        ChangeMode()

        SetDataFromObjectToControls()
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        mlistGridRowData = Nothing
        mlistAnioLectivoCursoImporte = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub SetDataFromObjectToControls()
        Dim AnioLectivo As Short
        Dim MesInicio As Byte
        Dim AnioLectivoCursoImporteCurrent As AnioLectivoCursoImporte

        If mSkipFilterData Then
            Exit Sub
        End If

        AnioLectivo = Convert.ToInt16(comboboxAnioLectivo.Text)
        MesInicio = Convert.ToByte(comboboxMesInicio.SelectedIndex + 1)
        mlistAnioLectivoCursoImporte = New List(Of AnioLectivoCursoImporte)

        For Each AnioLectivoCursoCurrent In mdbContext.AnioLectivoCurso.Where(Function(alc) alc.AnioLectivo = AnioLectivo)
            AnioLectivoCursoImporteCurrent = mdbContext.AnioLectivoCursoImporte.Find(AnioLectivoCursoCurrent.IDAnioLectivoCurso, MesInicio)

            If AnioLectivoCursoImporteCurrent Is Nothing Then
                AnioLectivoCursoImporteCurrent = New AnioLectivoCursoImporte

                AnioLectivoCursoImporteCurrent.IDAnioLectivoCurso = AnioLectivoCursoCurrent.IDAnioLectivoCurso
                AnioLectivoCursoImporteCurrent.MesInicio = MesInicio

                mdbContext.AnioLectivoCursoImporte.Add(AnioLectivoCursoImporteCurrent)
            End If
            mlistAnioLectivoCursoImporte.Add(AnioLectivoCursoImporteCurrent)
        Next

        mlistGridRowData = (From alci In mlistAnioLectivoCursoImporte
                            Join alc In mdbContext.AnioLectivoCurso On alci.IDAnioLectivoCurso Equals alc.IDAnioLectivoCurso
                            Join c In mdbContext.Curso On c.IDCurso Equals alc.IDCurso
                            Join a In mdbContext.Anio On a.IDAnio Equals c.IDAnio
                            Join n In mdbContext.Nivel On n.IDNivel Equals a.IDNivel
                            Join t In mdbContext.Turno On c.IDTurno Equals t.IDTurno()
                            Order By n.Nombre, a.Nombre, n.Nombre
                            Where alc.AnioLectivo = AnioLectivo And alci.MesInicio = MesInicio
                            Select New GridRowData With {.IDAnioLectivoCurso = alc.IDAnioLectivoCurso, .NivelNombre = n.Nombre, .CursoNombre = a.Nombre & " - " & t.Nombre & " - " & c.Division, .ImporteMatricula = alci.ImporteMatricula, .ImporteCuota = alci.ImporteCuota}).ToList

        datagridviewMain.AutoGenerateColumns = False
        datagridviewMain.DataSource = mlistGridRowData
    End Sub

    Friend Sub SetDataFromControlsToObject()
        For Each GridRowDataActual As GridRowData In mlistGridRowData
            Dim AnioLectivoCursoImporteCurrent As AnioLectivoCursoImporte

            AnioLectivoCursoImporteCurrent = mlistAnioLectivoCursoImporte.Find(Function(alci) alci.IDAnioLectivoCurso = GridRowDataActual.IDAnioLectivoCurso)
            With AnioLectivoCursoImporteCurrent
                .ImporteMatricula = GridRowDataActual.ImporteMatricula
                .ImporteCuota = GridRowDataActual.ImporteCuota
            End With
        Next
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub FormKeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                buttonGuardar.PerformClick()
            Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                buttonCancelar.PerformClick()
        End Select
    End Sub

    Private Sub AnioLectivoCambio(sender As Object, e As EventArgs) Handles comboboxAnioLectivo.SelectedIndexChanged
        SetDataFromObjectToControls()
    End Sub

    Private Sub MesInicioCambio(sender As Object, e As EventArgs) Handles comboboxMesInicio.SelectedIndexChanged
        SetDataFromObjectToControls()
    End Sub

    Private Sub Grid_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs) Handles datagridviewMain.CellValidating
        Dim style As NumberStyles
        Dim importe As Decimal

        If Not mEditMode Then
            Return
        End If

        ' Don't try to validate the 'new row' until finished 
        ' editing since there is not any point in validating its initial value.
        If datagridviewMain.Rows(e.RowIndex).IsNewRow Then
            Return
        End If

        datagridviewMain.Rows(e.RowIndex).ErrorText = ""

        style = NumberStyles.Number Or NumberStyles.AllowCurrencySymbol

        If e.ColumnIndex > 1 AndAlso Not Decimal.TryParse(e.FormattedValue.ToString(), style, CultureInfo.CurrentCulture, importe) OrElse importe < 0 Then
            e.Cancel = True
            datagridviewMain.Rows(e.RowIndex).ErrorText = "El importe debe ser un valor numérico mayor o igual a cero."
            MsgBox("El importe debe ser un valor numérico mayor o igual a cero.", vbInformation, My.Application.Info.Title)
        End If
    End Sub

    Private Sub Grid_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles datagridviewMain.DataError
        MsgBox("El importe debe ser un valor numérico mayor o igual a cero.", vbInformation, My.Application.Info.Title)
        e.ThrowException = False
    End Sub
#End Region

#Region "Main Toolbar"
    Private Sub buttonEditar_Click() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCURSOIMPORTE_EDITAR) Then
            mEditMode = True
            ChangeMode()
        End If
    End Sub

    Private Sub buttonCerrarOCancelar_Click() Handles buttonCerrar.Click, buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonCancelar_Click() Handles buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonGuardar_Click() Handles buttonGuardar.Click
        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        If mdbContext.ChangeTracker.HasChanges Then

            Me.Cursor = Cursors.WaitCursor

            Try
                ' Guardo los cambios
                mdbContext.SaveChanges()

                mEditMode = False

                ChangeMode()

                Me.Cursor = Cursors.Default

            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Me.Cursor = Cursors.Default
                Select Case CS_Database_EF_SQL.TryDecodeDbUpdateException(dbuex)
                    Case Errors.DuplicatedEntity
                        MsgBox("No se pueden guardar los cambios porque ya existe un Anio Lectivo y Curso - Importe con los mismos datos.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                End Select
                Exit Sub

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                CS_Error.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
                Exit Sub
            End Try
        End If
    End Sub
#End Region

End Class