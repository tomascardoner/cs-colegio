Public Class FormLiquidacionEntidad

#Region "Declarations"

    Private _dbContext As New CSColegioContext(True)
    Private _SueldoLiquidacionEntidad As SueldoLiquidacionEntidad

    Private _IsNew As Boolean
    Private _IsLoading As Boolean = False
    Private _IsEditMode As Boolean = False

#End Region

#Region "Form stuff"

    Public Sub New(editMode As Boolean, idSueldoLiquidacion As Short, idEntidad As Integer, liquidacionTexto As String)
        InitializeComponent()
        _IsNew = (idEntidad = 0)
        _IsLoading = True
        _IsEditMode = editMode

        TextBoxLiquidacion.Text = liquidacionTexto
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
            Comunes.Listas.Entidades.PersonalColegio(ComboBoxEntidad, dbContext)
        End Using
    End Sub

    Private Sub SetAppearance()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.ImageSueldo32)
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
        Dim sueldoCalculoModulo As SueldoCalculoModulo

        If Not VerificarDatos() Then
            Return
        End If

        ' Obtener los importes para el período actual
        'If ObtenerImportes(_SueldoLiquidacionEntidad.Anio, Convert.ToByte(ComboBoxEntidad.SelectedIndex + 1)) Then
        '    Return
        'End If

        If MessageBox.Show($"No hay datos para el período especificado.{Environment.NewLine}{Environment.NewLine}¿Desea obtener los importes desde el cálculo anterior disponible?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If
        'sueldoCalculoModulo = _dbContext.SueldoCalculoModulo.Where(Function(scm) (scm.Anio = _SueldoLiquidacion.Anio AndAlso scm.Mes < CByte(ComboBoxEntidad.SelectedIndex + 1)) OrElse scm.Anio < _SueldoLiquidacion.Anio).OrderByDescending(Function(scm) scm.Anio).ThenByDescending(Function(scm) scm.Mes).FirstOrDefault()
        If sueldoCalculoModulo Is Nothing Then
            MessageBox.Show($"No se encontraron datos de cálculo de módulo de sueldos.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        ' Obtener los importes del período anterior
        ObtenerImportes(sueldoCalculoModulo.Anio, sueldoCalculoModulo.Mes)
    End Sub

    Private Function ObtenerImportes(anio As Short, mes As Byte) As Boolean
        Dim sueldoCalculoModulos As IEnumerable(Of SueldoCalculoModulo)

        Try
            Me.Cursor = Cursors.WaitCursor
            sueldoCalculoModulos = _dbContext.SueldoCalculoModulo.Where(Function(scm) scm.Anio = anio AndAlso scm.Mes = mes)
            If Not sueldoCalculoModulos.Any() Then
                Return False
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener los datos de cálculo de módulo de sueldos desde la base de datos.")
            Return False
        End Try

        Try
            Dim BaseAntiguedadImporte As Decimal? = sueldoCalculoModulos.Where(Function(scm) scm.SueldoConcepto.Codigo.HasValue AndAlso scm.SueldoConcepto.Codigo.Value = CS_Parameter_System.GetIntegerAsShort(Parametros.SUELDO_CONCEPTO_BASICO_CODIGO)).FirstOrDefault()?.Importe
            Dim ModuloImporte As Decimal = sueldoCalculoModulos.Where(Function(scm) (Not scm.SueldoConcepto.Codigo.HasValue) OrElse (scm.SueldoConcepto.Codigo.HasValue AndAlso scm.SueldoConcepto.Codigo.Value <> CS_Parameter_System.GetIntegerAsShort(Parametros.SUELDO_CONCEPTO_ANTIGUEDAD_CODIGO))).Sum(Function(scm) scm.Importe * If(scm.SueldoConcepto.Tipo = Constantes.SueldoConceptoTipoDescuento, -1, 1))

            'CurrencyTextBoxBaseAntiguedadImporte.BindableValue = BaseAntiguedadImporte
            'CurrencyTextBoxModuloImporte.DecimalValue = ModuloImporte
            Me.Cursor = Cursors.Default
            Return True
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al realizar los cálculos del módulo de sueldos.")
            Return False
        End Try
    End Function

#End Region

End Class