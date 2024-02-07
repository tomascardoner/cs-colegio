Public Class formEntidadInscripcionDetalle

#Region "Declarations"

    Private mdbContext As New CSColegioContext(True)
    Private mAnioLectivoCursoActual As AnioLectivoCurso
    Private mAnioLectivoProximo As Integer
    Private mIDAnioProximo As Byte
    Private mIDTurnoProximo As Byte
    Private mDivisionProximo As String

    Private mIsLoading As Boolean = False
    Private ReadOnly mEditMode As Boolean = False

#End Region

#Region "Form stuff"
    Friend Function LoadAndShow(ByRef ParentForm As Form, ByVal AlumnoApellidoNombre As String, ByRef AnioLectivoCursoActual As AnioLectivoCurso, ByVal AnioLectivoProximo As Integer, ByRef IDAnioProximo As Byte, ByRef IDTurnoProximo As Byte, ByRef DivisionProximo As String) As Boolean
        mIsLoading = True

        textboxAlumno.Text = AlumnoApellidoNombre
        mAnioLectivoCursoActual = AnioLectivoCursoActual
        mAnioLectivoProximo = AnioLectivoProximo
        mIDAnioProximo = IDAnioProximo
        mIDTurnoProximo = IDTurnoProximo
        mDivisionProximo = DivisionProximo

        CardonerSistemas.Forms.CenterToParent(ParentForm, Me)
        InitializeFormAndControls()
        SetDataFromObjectToControls()

        mIsLoading = False

        If Me.ShowDialog(ParentForm) = Windows.Forms.DialogResult.OK Then
            IDAnioProximo = mIDAnioProximo
            IDTurnoProximo = mIDTurnoProximo
            DivisionProximo = mDivisionProximo
            Return True
        Else
            Return False
        End If

    End Function

    Friend Sub InitializeFormAndControls()
        SetAppearance()
    End Sub

    Friend Sub SetAppearance()

    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        mAnioLectivoCursoActual = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Mostrar y leer datos"

    Friend Sub SetDataFromObjectToControls()
        With mAnioLectivoCursoActual
            textboxAnioActual.Text = .Curso.Anio.Nivel.Nombre & " - " & .Curso.Anio.Nombre
            textboxTurnoActual.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Curso.Turno.Nombre)
            textboxDivisionActual.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Curso.Division)

            ' Cargo el ComboBox de Nivel
            comboboxAnioProximo.ValueMember = "IDAnio"
            comboboxAnioProximo.DisplayMember = "Nombre"
            Dim listAnios As New List(Of Anio)

            ' Anio actual
            Dim itemAnioActual As New Anio
            itemAnioActual.IDAnio = .Curso.Anio.IDAnio
            itemAnioActual.Nombre = .Curso.Anio.Nivel.Nombre & " - " & .Curso.Anio.Nombre
            listAnios.Add(itemAnioActual)

            If (.Curso.Anio.AnioSiguiente IsNot Nothing) Then
                ' Anio siguiente
                Dim itemAnioSiguiente As New Anio
                itemAnioSiguiente.IDAnio = .Curso.Anio.AnioSiguiente.IDAnio
                itemAnioSiguiente.Nombre = .Curso.Anio.AnioSiguiente.Nivel.Nombre & " - " & .Curso.Anio.AnioSiguiente.Nombre
                listAnios.Add(itemAnioSiguiente)
            End If

            comboboxAnioProximo.DataSource = listAnios
            If listAnios.Count > 1 Then
                If mIDAnioProximo = 0 Then
                    comboboxAnioProximo.SelectedIndex = 1
                Else
                    CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxAnioProximo, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrLast, mIDAnioProximo)
                    CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxTurnoProximo, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirstIfUnique, mIDTurnoProximo)
                    CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxDivisionProximo, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirstIfUnique, mDivisionProximo)
                End If
            End If
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        mIDAnioProximo = CByte(comboboxAnioProximo.SelectedValue)
        mIDTurnoProximo = CByte(comboboxTurnoProximo.SelectedValue)
        mDivisionProximo = CStr(comboboxDivisionProximo.SelectedValue)
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

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs)
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub CambiarAnio() Handles comboboxAnioProximo.SelectedValueChanged
        Dim listTurnos As List(Of Turno)

        If comboboxAnioProximo.SelectedValue Is Nothing Then
            comboboxTurnoProximo.DataSource = Nothing
        Else
            Dim IDAnioProximo As Byte

            IDAnioProximo = CByte(comboboxAnioProximo.SelectedValue)
            listTurnos = (From c In mdbContext.Curso
                          Join alc In mdbContext.AnioLectivoCurso On c.IDCurso Equals alc.IDCurso
                          Join t In mdbContext.Turno On c.IDTurno Equals t.IDTurno
                          Where alc.AnioLectivo = mAnioLectivoProximo AndAlso c.IDAnio = IDAnioProximo
                          Select t).ToList

            comboboxTurnoProximo.ValueMember = "IDTurno"
            comboboxTurnoProximo.DisplayMember = "Nombre"
            comboboxTurnoProximo.DataSource = listTurnos
            ' Intento seleccionar el mismo Turno que el Año anterior
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxTurnoProximo, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirstIfUnique, mAnioLectivoCursoActual.Curso.IDTurno)
        End If
    End Sub

    Private Sub CambiarTurno() Handles comboboxTurnoProximo.SelectedValueChanged
        If comboboxTurnoProximo.SelectedValue Is Nothing Then
            comboboxDivisionProximo.DataSource = Nothing
        Else
            Dim IDAnioProximo As Byte
            Dim IDTurnoProximo As Byte

            IDAnioProximo = CByte(comboboxAnioProximo.SelectedValue)
            IDTurnoProximo = CByte(comboboxTurnoProximo.SelectedValue)
            comboboxDivisionProximo.ValueMember = "Division"
            comboboxDivisionProximo.DataSource = (From c In mdbContext.Curso
                          Join alc In mdbContext.AnioLectivoCurso On c.IDCurso Equals alc.IDCurso
                          Where alc.AnioLectivo = mAnioLectivoProximo AndAlso c.IDAnio = IDAnioProximo AndAlso c.IDTurno = IDTurnoProximo
                          Select c.Division).ToList

            ' Intento seleccionar la misma Division que el Año anterior
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(comboboxDivisionProximo, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirstIfUnique, mAnioLectivoCursoActual.Curso.Division)
        End If
    End Sub

#End Region

#Region "Main Toolbar"

    Private Sub Cancelar_Click() Handles buttonCancelar.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Guardar_Click() Handles buttonGuardar.Click
        If comboboxAnioProximo.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Año.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxAnioProximo.Focus()
            Exit Sub
        End If
        If comboboxTurnoProximo.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Turno.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxTurnoProximo.Focus()
            Exit Sub
        End If
        If comboboxDivisionProximo.SelectedIndex = -1 Then
            MsgBox("Debe especificar la División.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxDivisionProximo.Focus()
            Exit Sub
        End If

        ' Si el Año asignado es el mismo que el anterior, me aseguro que está bien que el Alumno repita
        If CByte(comboboxAnioProximo.SelectedValue) = mAnioLectivoCursoActual.Curso.IDAnio Then
            If MsgBox(String.Format("El Año seleccionado como próximo, es el mismo que el actual. Esto significa que el Alumno va a recursar el Año.{0}{0}¿Esto es correcto?", vbCrLf), CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        ' Si el Turno asignado es diferente que el anterior, me aseguro que está bien el cambio de Turno
        If CByte(comboboxTurnoProximo.SelectedValue) <> mAnioLectivoCursoActual.Curso.IDTurno Then
            If MsgBox(String.Format("El Turno seleccionado como próximo, es diferente que el actual.{0}{0}¿Esto es correcto?", vbCrLf), CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        ' Si la División asignada es diferente que la anterior, me aseguro que está bien el cambio de División
        If CStr(comboboxDivisionProximo.SelectedValue) <> mAnioLectivoCursoActual.Curso.Division Then
            If MsgBox(String.Format("La División seleccionada como próxima, es diferente que la actual.{0}{0}¿Esto es correcto?", vbCrLf), CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub
#End Region

End Class