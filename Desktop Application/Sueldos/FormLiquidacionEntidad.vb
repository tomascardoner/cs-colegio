Public Class FormLiquidacionEntidad

#Region "Declarations"

    Private _dbContext As New CSColegioContext(True)
    Private _SueldoLiquidacionEntidad As SueldoLiquidacionEntidad
    Private _SueldoLiquidacionAnio As Short
    Private _SueldoLiquidacionMes As Byte

    Private _IsNew As Boolean
    Private _IsLoading As Boolean = False
    Private _IsEditMode As Boolean = False

#End Region

#Region "Form stuff"

    Public Sub New(editMode As Boolean, idSueldoLiquidacion As Short, idEntidad As Integer, anio As Short, mes As Byte)
        InitializeComponent()
        _IsNew = (idEntidad = 0)
        _IsLoading = True
        _IsEditMode = editMode

        _SueldoLiquidacionAnio = anio
        _SueldoLiquidacionMes = mes

        If _IsNew Then
            _SueldoLiquidacionEntidad = New SueldoLiquidacionEntidad With {.IdSueldoLiquidacion = idSueldoLiquidacion}
            _dbContext.SueldoLiquidacionEntidad.Add(_SueldoLiquidacionEntidad)
        Else
            _SueldoLiquidacionEntidad = _dbContext.SueldoLiquidacionEntidad.Find(idSueldoLiquidacion, idEntidad)
        End If
        InitializeForm()
        SetDataToUserInterface()
        _IsLoading = False
        ChangeEditMode()
    End Sub

    Private Sub InitializeForm()
        SetAppearance()
        Using dbContext = New CSColegioContext(True)
            Comunes.Listas.Entidades.ConSueldos(ComboBoxEntidad, dbContext)
        End Using
    End Sub

    Private Sub SetAppearance()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.ImageSueldo32)
        TextBoxLiquidacion.Text = $"{MonthName(_SueldoLiquidacionMes)} de {_SueldoLiquidacionAnio}"
    End Sub

    Private Sub ChangeEditMode()
        If _IsLoading Then
            Return
        End If

        ToolStripButtonGuardar.Visible = _IsEditMode
        ToolStripButtonCancelar.Visible = _IsEditMode
        ToolStripButtonEditar.Visible = Not _IsEditMode
        ToolStripButtonCerrar.Visible = Not _IsEditMode

        ComboBoxEntidad.Enabled = (_IsEditMode AndAlso _IsNew)
        DoubleTextBoxModuloCantidad.ReadOnly = Not _IsEditMode
        IntegerTextBoxAntiguedad.ReadOnly = Not _IsEditMode

        ButtonObtenerDatos.Visible = _IsEditMode
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _dbContext.Dispose()
        _SueldoLiquidacionEntidad = Nothing
    End Sub

#End Region

#Region "User interface data"

    Friend Sub SetDataToUserInterface()
        With _SueldoLiquidacionEntidad
            'TextBoxLiquidacion.Text = .Anio.ToString()
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(ComboBoxEntidad, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.Value, .IdEntidad)
            CS_ValueTranslation_Syncfusion.FromValueToControl(.ModuloCantidad, DoubleTextBoxModuloCantidad)
            CS_ValueTranslation_Syncfusion.FromValueToControl(.Antiguedad, IntegerTextBoxAntiguedad)
        End With
    End Sub

    Friend Sub SetDataToEntityObject()
        With _SueldoLiquidacionEntidad
            .IdEntidad = CS_ValueTranslation.FromControlComboBoxToObjectInteger(ComboBoxEntidad.SelectedValue).Value
            .ModuloCantidad = CS_ValueTranslation_Syncfusion.FromControlToDecimal(DoubleTextBoxModuloCantidad)
            .Antiguedad = CS_ValueTranslation_Syncfusion.FromControlToDecimal(IntegerTextBoxAntiguedad)
        End With
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

    Private Sub DoubleTextBoxModuloCantidad_GotFocus(sender As Object, e As EventArgs) Handles DoubleTextBoxModuloCantidad.GotFocus
        DoubleTextBoxModuloCantidad.SelectAll()
    End Sub

    Private Sub IntegerTextBoxAntiguedad_GotFocus(sender As Object, e As EventArgs) Handles IntegerTextBoxAntiguedad.GotFocus
        IntegerTextBoxAntiguedad.SelectAll()
    End Sub

    Private Sub ButtonObtenerImportes_Click(sender As Object, e As EventArgs) Handles ButtonObtenerDatos.Click
        ObtenerImportes()
    End Sub

#End Region

#Region "Main toolbar events"

    Private Sub Guardar_Click() Handles ToolStripButtonGuardar.Click
        If Not VerificarDatos() Then
            Return
        End If

        SetDataToEntityObject()

        If Not _dbContext.ChangeTracker.HasChanges Then
            Return
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            _dbContext.SaveChanges()
        Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
            Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                Case CardonerSistemas.Database.EntityFramework.Errors.DuplicatedEntity
                    MessageBox.Show("No se pueden guardar los cambios porque ya existe la entidad en la liquidación de sueldo.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Select
            Me.Cursor = Cursors.Default
            Return
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
            Me.Cursor = Cursors.Default
            Return
        End Try

        Comunes.RefreshLists.SueldosLiquidacionesEntidades.Refresh(_SueldoLiquidacionEntidad.IdEntidad)
        Me.Close()
    End Sub

    Private Sub Cerrar_Click() Handles ToolStripButtonCerrar.Click
        Me.Close()
    End Sub

    Private Sub Editar_Click() Handles ToolStripButtonEditar.Click
        If Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_EDITAR) Then
            _IsEditMode = True
            ChangeEditMode()
        End If
    End Sub

    Private Sub Cancelar_Click() Handles ToolStripButtonCancelar.Click
        Me.Close()
    End Sub

#End Region

#Region "Extra stuff"

    Private Function VerificarDatos() As Boolean
        If ComboBoxEntidad.SelectedIndex = -1 Then
            MsgBox("Debe especificar la entidad.", MsgBoxStyle.Information, My.Application.Info.Title)
            ComboBoxEntidad.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub ObtenerImportes()
        If Not VerificarDatos() Then
            Return
        End If

        Try
            Me.Cursor = Cursors.WaitCursor
            Dim idEntidad As Integer = Convert.ToInt32(ComboBoxEntidad.SelectedValue)
            Dim sueldoLiquidacionEntidad = _dbContext.SueldoLiquidacionEntidad.AsNoTracking().Where(Function(sle) sle.IdEntidad = idEntidad AndAlso (sle.SueldoLiquidacion.Anio = _SueldoLiquidacionAnio AndAlso sle.SueldoLiquidacion.Mes < _SueldoLiquidacionMes) OrElse sle.SueldoLiquidacion.Anio < _SueldoLiquidacionAnio).OrderByDescending(Function(sle) sle.SueldoLiquidacion.Anio).ThenByDescending(Function(sle) sle.SueldoLiquidacion.Mes).Take(1).FirstOrDefault()
            If sueldoLiquidacionEntidad Is Nothing Then
                Me.Cursor = Cursors.Default
                MessageBox.Show($"No se encontró una liquidación de sueldos anterrior de la entidad.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If
            CS_ValueTranslation_Syncfusion.FromValueToControl(sueldoLiquidacionEntidad.ModuloCantidad, DoubleTextBoxModuloCantidad)
            CS_ValueTranslation_Syncfusion.FromValueToControl(sueldoLiquidacionEntidad.Antiguedad, IntegerTextBoxAntiguedad)
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener los datos de la última liquidación de sueldos de la entidad.")
        End Try
        Me.Cursor = Cursors.Default
    End Sub

#End Region

End Class