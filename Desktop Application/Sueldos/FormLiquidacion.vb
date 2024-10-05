Public Class FormLiquidacion

#Region "Declarations"

    Private _dbContext As New CSColegioContext(True)
    Private _SueldoLiquidacion As SueldoLiquidacion

    Private _IsNew As Boolean
    Private _IsLoading As Boolean = False
    Private _IsEditMode As Boolean = False

#End Region

#Region "Form stuff"

    Public Sub New(editMode As Boolean, idSueldoLiquidacion As Short, anio As Short)
        InitializeComponent()
        _IsNew = (idSueldoLiquidacion = 0)
        _IsLoading = True
        _IsEditMode = editMode

        If _IsNew Then
            _SueldoLiquidacion = New SueldoLiquidacion With {.Anio = anio}
            _dbContext.SueldoLiquidacion.Add(_SueldoLiquidacion)
        Else
            _SueldoLiquidacion = _dbContext.SueldoLiquidacion.Find(idSueldoLiquidacion)
        End If
        InitializeForm()
        SetDataToUserInterface()
        _IsLoading = False
        ChangeEditMode()
    End Sub

    Private Sub InitializeForm()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.ImageSueldo32)
        pFillAndRefreshLists.MesNombres(ComboBoxMes, True, False, False)
        ComboBoxMes.SelectedIndex = DateTime.Today.Month - 1
    End Sub

    Private Sub ChangeEditMode()
        If _IsLoading Then
            Return
        End If

        buttonGuardar.Visible = _IsEditMode
        buttonCancelar.Visible = _IsEditMode
        buttonEditar.Visible = Not _IsEditMode
        buttonCerrar.Visible = Not _IsEditMode

        ComboBoxMes.Enabled = (_IsEditMode AndAlso _IsNew)
        CurrencyTextBoxBaseAntiguedadImporte.ReadOnly = Not _IsEditMode
        CurrencyTextBoxModuloImporte.ReadOnly = Not _IsEditMode

        ButtonObtenerImportes.Visible = _IsEditMode
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _dbContext.Dispose()
        _SueldoLiquidacion = Nothing
    End Sub

#End Region

#Region "User interface data"

    Friend Sub SetDataToUserInterface()
        With _SueldoLiquidacion
            TextBoxAnio.Text = .Anio.ToString()
            ComboBoxMes.SelectedIndex = .Mes - 1
            CS_ValueTranslation_Syncfusion.FromValueToControl(.BaseAntiguedadImporte, CurrencyTextBoxBaseAntiguedadImporte)
            CS_ValueTranslation_Syncfusion.FromValueToControl(.ModuloImporte, CurrencyTextBoxModuloImporte)
        End With
    End Sub

    Friend Sub SetDataToEntityObject()
        With _SueldoLiquidacion
            .Mes = CByte(ComboBoxMes.SelectedIndex + 1)
            .BaseAntiguedadImporte = CS_ValueTranslation_Syncfusion.FromControlToDecimal(CurrencyTextBoxBaseAntiguedadImporte)
            .ModuloImporte = CS_ValueTranslation_Syncfusion.FromControlToDecimal(CurrencyTextBoxModuloImporte)
        End With
    End Sub

#End Region

#Region "Controls events"

    Private Sub FormKeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                If _IsEditMode Then
                    buttonGuardar.PerformClick()
                Else
                    buttonCerrar.PerformClick()
                End If
            Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                If _IsEditMode Then
                    buttonCancelar.PerformClick()
                Else
                    buttonCerrar.PerformClick()
                End If
        End Select
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles CurrencyTextBoxBaseAntiguedadImporte.GotFocus, CurrencyTextBoxModuloImporte.GotFocus
        CType(sender, Syncfusion.Windows.Forms.Tools.CurrencyTextBox).SelectAll()
    End Sub

    Private Sub ButtonObtenerImportes_Click(sender As Object, e As EventArgs) Handles ButtonObtenerImportes.Click
        ObtenerImportes()
    End Sub

#End Region

#Region "Main toolbar events"

    Private Sub Guardar_Click() Handles buttonGuardar.Click
        If Not VerificarDatos() Then
            Return
        End If

        SetDataToEntityObject()

        If Not _dbContext.ChangeTracker.HasChanges Then
            Return
        End If
        If _IsNew AndAlso Not InitializeNewObjectData() Then
            Return
        End If
        _SueldoLiquidacion.IdUsuarioModificacion = pUsuario.IDUsuario
        _SueldoLiquidacion.FechaHoraModificacion = DateAndTime.Now

        Try
            Me.Cursor = Cursors.WaitCursor
            _dbContext.SaveChanges()
        Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
            Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                Case CardonerSistemas.Database.EntityFramework.Errors.DuplicatedEntity
                    MessageBox.Show("No se pueden guardar los cambios porque ya existe una liquidación con el mismo mes y año.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Select
            Me.Cursor = Cursors.Default
            Return
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
            Me.Cursor = Cursors.Default
            Return
        End Try

        Comunes.RefreshLists.SueldosLiquidaciones.Refresh(_SueldoLiquidacion.IdSueldoLiquidacion)
        Me.Close()
    End Sub

    Private Sub Cerrar_Click() Handles buttonCerrar.Click
        Me.Close()
    End Sub

    Private Sub Editar_Click() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_EDITAR) Then
            _IsEditMode = True
            ChangeEditMode()
        End If
    End Sub

    Private Sub Cancelar_Click() Handles buttonCancelar.Click
        Me.Close()
    End Sub

#End Region

#Region "New object initialization"

    Private Function InitializeNewObjectData() As Boolean
        If _SueldoLiquidacion Is Nothing Then
            Return False
        End If

        Me.Cursor = Cursors.WaitCursor
        _SueldoLiquidacion.IdUsuarioCreacion = pUsuario.IDUsuario
        _SueldoLiquidacion.FechaHoraCreacion = Now

        Try
            Using dbContext As New CSColegioContext(True)
                If dbContext.SueldoLiquidacion.Any() Then
                    _SueldoLiquidacion.IdSueldoLiquidacion = CShort(dbContext.SueldoLiquidacion.Max(Function(sl) sl.IdSueldoLiquidacion) + 1)
                Else
                    _SueldoLiquidacion.IdSueldoLiquidacion = 1
                End If
            End Using
            Me.Cursor = Cursors.Default
            Return True
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener el nuevo id de la liquidación de sueldos.")
            Return False
        End Try
    End Function

#End Region

#Region "Extra stuff"

    Private Function VerificarDatos() As Boolean
        If ComboBoxMes.SelectedIndex = -1 Then
            MsgBox("Debe especificar el mes.", MsgBoxStyle.Information, My.Application.Info.Title)
            ComboBoxMes.Focus()
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
        If ObtenerImportes(_SueldoLiquidacion.Anio, Convert.ToByte(ComboBoxMes.SelectedIndex + 1)) Then
            Return
        End If

        If MessageBox.Show($"No hay datos para el período especificado.{Environment.NewLine}{Environment.NewLine}¿Desea obtener los importes desde el cálculo anterior disponible?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
            Return
        End If
        sueldoCalculoModulo = _dbContext.SueldoCalculoModulo.Where(Function(scm) (scm.Anio = _SueldoLiquidacion.Anio AndAlso scm.Mes < CByte(ComboBoxMes.SelectedIndex + 1)) OrElse scm.Anio < _SueldoLiquidacion.Anio).OrderByDescending(Function(scm) scm.Anio).ThenByDescending(Function(scm) scm.Mes).FirstOrDefault()
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
                Me.Cursor = Cursors.Default
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

            CurrencyTextBoxBaseAntiguedadImporte.BindableValue = BaseAntiguedadImporte
            CurrencyTextBoxModuloImporte.DecimalValue = ModuloImporte
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