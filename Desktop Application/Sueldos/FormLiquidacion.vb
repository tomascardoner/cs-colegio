Public Class FormLiquidacion

#Region "Declarations"

    Private _dbContext As New CSColegioContext(True)
    Private _SueldoLiquidacion As SueldoLiquidacion

    Private mIsNew As Boolean
    Private mIsLoading As Boolean = False
    Private mEditMode As Boolean = False

#End Region

#Region "Form stuff"

    Friend Sub LoadAndShow(EditMode As Boolean, ByRef ParentForm As Form, IdSueldoLiquidacion As Short, Anio As Short)
        mIsNew = (IdSueldoLiquidacion = 0)
        mIsLoading = True
        mEditMode = EditMode

        If mIsNew Then
            ' Es Nuevo
            _SueldoLiquidacion = New SueldoLiquidacion With {.Anio = Anio}
            _dbContext.SueldoLiquidacion.Add(_SueldoLiquidacion)
        Else
            _SueldoLiquidacion = _dbContext.SueldoLiquidacion.Find(IdSueldoLiquidacion)
        End If

        Me.MdiParent = pFormMDIMain
        CardonerSistemas.Forms.CenterToParent(ParentForm, Me)
        InitializeFormAndControls()
        SetDataFromObjectToControls()
        Me.Show()
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
        End If
        Me.Focus()

        mIsLoading = False

        ChangeMode()
    End Sub

    Private Sub ChangeMode()
        If mIsLoading Then
            Return
        End If

        buttonGuardar.Visible = mEditMode
        buttonCancelar.Visible = mEditMode
        buttonEditar.Visible = Not mEditMode
        buttonCerrar.Visible = Not mEditMode

        ComboBoxMes.Enabled = (mEditMode AndAlso mIsNew)
        CurrencyTextBoxBaseAntiguedadImporte.ReadOnly = Not mEditMode
        CurrencyTextBoxModuloImporte.ReadOnly = Not mEditMode

        ButtonObtenerImportes.Visible = mEditMode
    End Sub

    Friend Sub InitializeFormAndControls()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.ImageSueldo32)
        pFillAndRefreshLists.MesNombres(ComboBoxMes, True, False, False)
        ComboBoxMes.SelectedIndex = DateTime.Today.Month - 1
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _dbContext.Dispose()
        _SueldoLiquidacion = Nothing
        Me.Dispose()
    End Sub

#End Region

#Region "Mostrar y leer datos"

    Friend Sub SetDataFromObjectToControls()
        With _SueldoLiquidacion
            TextBoxAnio.Text = .Anio.ToString()
            ComboBoxMes.SelectedIndex = .Mes - 1
            CS_ValueTranslation_Syncfusion.FromValueToControl(.BaseAntiguedadImporte, CurrencyTextBoxBaseAntiguedadImporte)
            CS_ValueTranslation_Syncfusion.FromValueToControl(.ModuloImporte, CurrencyTextBoxModuloImporte)
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
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
                If mEditMode Then
                    buttonGuardar.PerformClick()
                Else
                    buttonCerrar.PerformClick()
                End If
            Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                If mEditMode Then
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

#Region "Main Toolbar"

    Private Sub Editar_Click() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.SUELDO_LIQUIDACION_EDITAR) Then
            mEditMode = True
            ChangeMode()
        End If
    End Sub

    Private Sub CerrarOCancelar_Click() Handles buttonCerrar.Click, buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub Guardar_Click() Handles buttonGuardar.Click
        If Not VerificarDatos() Then
            Return
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        If _dbContext.ChangeTracker.HasChanges Then

            Me.Cursor = Cursors.WaitCursor

            If mIsNew Then
                _SueldoLiquidacion.IdUsuarioCreacion = pUsuario.IDUsuario
                _SueldoLiquidacion.FechaHoraCreacion = Now
            End If
            _SueldoLiquidacion.IdUsuarioModificacion = pUsuario.IDUsuario
            _SueldoLiquidacion.FechaHoraModificacion = Now
            Try
                ' Guardo los cambios
                _dbContext.SaveChanges()

                ' Refresco la lista de Importes de Cursos de Años Lectivos para mostrar los cambios
                If CardonerSistemas.Forms.MdiChildIsLoaded(CType(pFormMDIMain, Form), "FormLiquidaciones") Then
                    Dim form As FormLiquidaciones = CType(CardonerSistemas.Forms.MdiChildGetInstance(CType(pFormMDIMain, Form), "FormLiquidaciones"), FormLiquidaciones)
                    form.RefreshData(_SueldoLiquidacion.IdSueldoLiquidacion, False)
                    form = Nothing
                End If

            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Me.Cursor = Cursors.Default
                Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                    Case CardonerSistemas.Database.EntityFramework.Errors.DuplicatedEntity
                        MsgBox("No se pueden guardar los cambios porque ya existe una liquidación con el mismo mes y año.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                End Select
                Return

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                CardonerSistemas.ErrorHandler.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
                Return
            End Try
        End If

        Me.Close()
    End Sub

#End Region

#Region "Extras"

    Private Function VerificarDatos() As Boolean
        If ComboBoxMes.SelectedIndex = -1 Then
            MsgBox("Debe especificar el mes.", MsgBoxStyle.Information, My.Application.Info.Title)
            ComboBoxMes.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub ObtenerImportes()
        If Not VerificarDatos() Then
            Return
        End If

        Dim sueldoCalculoModulos As IEnumerable(Of SueldoCalculoModulo)

        Try
            sueldoCalculoModulos = _dbContext.SueldoCalculoModulo.Where(Function(scm) scm.Anio = _SueldoLiquidacion.Anio AndAlso scm.Mes = ComboBoxMes.SelectedIndex + 1)
            If Not sueldoCalculoModulos.Any() AndAlso MessageBox.Show($"No hay datos para el período especificado.{Environment.NewLine}{Environment.NewLine}¿Desea obtener los importes desde el último cálculo disponible?", My.Application.Info.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim sueldoCalculoModulo As SueldoCalculoModulo = _dbContext.SueldoCalculoModulo.OrderByDescending(Function(scm) scm.Anio).ThenByDescending(Function(scm) scm.Mes).FirstOrDefault()
                If sueldoCalculoModulo Is Nothing Then
                    MessageBox.Show($"No se encontraron datos de cálculo de módulo de sueldos.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return
                End If
                sueldoCalculoModulos = _dbContext.SueldoCalculoModulo.Where(Function(scm) scm.Anio = sueldoCalculoModulo.Anio AndAlso scm.Mes = sueldoCalculoModulo.Mes)
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al obtener los datos de cálculo de módulo de sueldos desde la base de datos.")
            Return
        End Try

        Try
            Dim BaseAntiguedadImporte As Decimal? = sueldoCalculoModulos.Where(Function(scm) scm.IdSueldoConcepto = CS_Parameter_System.GetIntegerAsShort(Parametros.SUELDO_CONCEPTO_BASICO_CODIGO)).FirstOrDefault()?.Importe
            If BaseAntiguedadImporte IsNot Nothing Then
                CurrencyTextBoxBaseAntiguedadImporte.DecimalValue = BaseAntiguedadImporte.Value
            Else
                CurrencyTextBoxBaseAntiguedadImporte.BindableValue = Nothing
            End If
            Dim ModuloImporte As Decimal = sueldoCalculoModulos.Where(Function(scm) scm.IdSueldoConcepto <> CS_Parameter_System.GetIntegerAsShort(Parametros.SUELDO_CONCEPTO_ANTIGUEDAD_CODIGO)).Sum(Function(scm) scm.Importe)
            CurrencyTextBoxModuloImporte.DecimalValue = ModuloImporte

        Catch ex As Exception
            Me.Cursor = Cursors.Default
            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al realizar los cálculos del módulo de sueldos.")
            Return
        End Try
    End Sub

#End Region

End Class