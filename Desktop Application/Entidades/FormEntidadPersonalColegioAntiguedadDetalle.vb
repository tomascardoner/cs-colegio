Public Class FormEntidadPersonalColegioAntiguedadDetalle

#Region "Declarations"

    Private _Entidad As Entidad
    Private _EntidadPersonalColegioAntiguedadDetalle As EntidadPersonalColegioAntiguedadDetalle

    Private _IsNew As Boolean
    Private _IsLoading As Boolean = False
    Private _ParentIsEditMode As Boolean = False
    Private _IsEditMode As Boolean = False

#End Region

#Region "Form stuff"

    Public Sub New(parentEditMode As Boolean, editMode As Boolean, entidad As Entidad, idDetalle As Byte)
        _ParentIsEditMode = parentEditMode
        _IsEditMode = editMode
        _Entidad = entidad

        _IsNew = (idDetalle = 0)
        If _IsNew Then
            _EntidadPersonalColegioAntiguedadDetalle = New EntidadPersonalColegioAntiguedadDetalle With {
                .FechaDesde = Now,
                .IdDetalle = If(_Entidad.EntidadPersonalColegio.EntidadPersonalColegioAntiguedadDetalle.Any(), _Entidad.EntidadPersonalColegio.EntidadPersonalColegioAntiguedadDetalle.Max(Function(epcad) epcad.IdDetalle) + CByte(1), CByte(1))
            }
        Else
            _EntidadPersonalColegioAntiguedadDetalle = entidad.EntidadPersonalColegio.EntidadPersonalColegioAntiguedadDetalle.FirstOrDefault(Function(epcad) epcad.IdDetalle = idDetalle)
        End If

        InitializeComponent()

        SetDataToUserInterface()
        ChangeMode()
    End Sub

    Private Sub ChangeMode()
        ToolStripButtonGuardar.Visible = _IsEditMode
        ToolStripButtonCancelar.Visible = _IsEditMode
        ToolStripButtonEditar.Visible = (_ParentIsEditMode AndAlso Not _IsEditMode)
        ToolStripButtonCerrar.Visible = Not _IsEditMode

        TextBoxInstitucion.ReadOnly = Not _IsEditMode
        DateTimePickerFechaDesde.Enabled = _IsEditMode
        DateTimePickerFechaHasta.Enabled = _IsEditMode
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _Entidad = Nothing
        _EntidadPersonalColegioAntiguedadDetalle = Nothing
        Me.Dispose()
    End Sub

#End Region

#Region "User interface data"

    Friend Sub SetDataToUserInterface()
        With _EntidadPersonalColegioAntiguedadDetalle
            TextBoxInstitucion.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Institucion)
            DateTimePickerFechaDesde.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaDesde)
            DateTimePickerFechaHasta.Value = CS_ValueTranslation.FromObjectDateToControlDateTimePicker(.FechaHasta, DateTimePickerFechaHasta)
        End With
    End Sub

    Friend Sub SetDataToEntityObject()
        With _EntidadPersonalColegioAntiguedadDetalle
            .Institucion = CS_ValueTranslation.FromControlTextBoxToObjectString(TextBoxInstitucion.Text)
            .FechaDesde = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(DateTimePickerFechaDesde.Value.Date).Value
            .FechaHasta = CS_ValueTranslation.FromControlDateTimePickerToObjectDate(DateTimePickerFechaHasta.Value.Date, DateTimePickerFechaHasta.Checked)
        End With
    End Sub

#End Region

#Region "Toolbar events"

    Private Sub Editar(sender As Object, e As EventArgs) Handles ToolStripButtonEditar.Click
        _IsEditMode = True
        ChangeMode()
    End Sub

    Private Sub Cerrar(sender As Object, e As EventArgs) Handles ToolStripButtonCerrar.Click
        Me.Close()
    End Sub

    Private Sub Guardar(sender As Object, e As EventArgs) Handles ToolStripButtonGuardar.Click
        SetDataToEntityObject()
        If _IsNew Then
            _Entidad.EntidadPersonalColegio.EntidadPersonalColegioAntiguedadDetalle.Add(_EntidadPersonalColegioAntiguedadDetalle)
        End If

        If CardonerSistemas.Forms.MdiChildIsLoaded(CType(pFormMDIMain, Form), "formEntidad") Then
            Dim form As formEntidad = CType(CardonerSistemas.Forms.MdiChildGetInstance(CType(pFormMDIMain, Form), "formEntidad"), formEntidad)
            form.RefreshData_EmpleadosAntiguedad(_EntidadPersonalColegioAntiguedadDetalle.IdDetalle)
        End If

        Me.Close()
    End Sub

    Private Sub Cancelar(sender As Object, e As EventArgs) Handles ToolStripButtonCancelar.Click
        Me.Close()
    End Sub

#End Region

#Region "Controls events"

    Private Sub FormKeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                If _IsEditMode Then
                    ToolStripButtonGuardar.PerformClick()
                Else
                    ToolStripButtonCerrar.PerformClick()
                End If
            Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                If _IsEditMode Then
                    ToolStripButtonCancelar.PerformClick()
                Else
                    ToolStripButtonCerrar.PerformClick()
                End If
        End Select
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles TextBoxInstitucion.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub

#End Region

End Class