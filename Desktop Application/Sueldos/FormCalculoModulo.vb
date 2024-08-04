Public Class FormCalculoModulo

#Region "Declarations"

    Private _dbContext As New CSColegioContext(True)
    Private _SueldoCalculoModulo As SueldoCalculoModulo

    Private mIsNew As Boolean
    Private mIsLoading As Boolean = False
    Private mEditMode As Boolean = False

#End Region

#Region "Form stuff"

    Friend Sub LoadAndShow(EditMode As Boolean, ByRef ParentForm As Form, Anio As Short, Mes As Byte, IdSueldoConcepto As Short)
        mIsNew = (IdSueldoConcepto = 0)
        mIsLoading = True
        mEditMode = EditMode

        If mIsNew Then
            ' Es Nuevo
            _SueldoCalculoModulo = New SueldoCalculoModulo With {.Anio = Anio, .Mes = Mes}
            _dbContext.SueldoCalculoModulo.Add(_SueldoCalculoModulo)
        Else
            _SueldoCalculoModulo = _dbContext.SueldoCalculoModulo.Find(Anio, Mes, IdSueldoConcepto)
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
        ComboBoxConcepto.Enabled = (mEditMode AndAlso mIsNew)
        CurrencyTextBoxImporte.ReadOnly = Not mEditMode
    End Sub

    Friend Sub InitializeFormAndControls()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.ImageSueldo32)
        pFillAndRefreshLists.MesNombres(ComboBoxMes, True, False, False)
        ComboBoxMes.SelectedIndex = DateTime.Today.Month - 1
        pFillAndRefreshLists.SueldoConcepto(ComboBoxConcepto, False, False)
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _dbContext.Dispose()
        _SueldoCalculoModulo = Nothing
        Me.Dispose()
    End Sub

#End Region

#Region "Mostrar y leer datos"

    Friend Sub SetDataFromObjectToControls()
        With _SueldoCalculoModulo
            TextBoxAnio.Text = .Anio.ToString()
            ComboBoxMes.SelectedIndex = .Mes - 1
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(ComboBoxConcepto, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirstIfUnique, .IdSueldoConcepto)
            CS_ValueTranslation_Syncfusion.FromValueToControl(.Importe, CurrencyTextBoxImporte)
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With _SueldoCalculoModulo
            .Mes = CByte(ComboBoxMes.SelectedIndex + 1)
            .IdSueldoConcepto = CS_ValueTranslation.FromControlComboBoxToObjectShort(ComboBoxConcepto.SelectedValue).Value
            .Importe = CS_ValueTranslation_Syncfusion.FromControlToDecimal(CurrencyTextBoxImporte).Value
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

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles CurrencyTextBoxImporte.GotFocus
        CType(sender, Syncfusion.Windows.Forms.Tools.CurrencyTextBox).SelectAll()
    End Sub

#End Region

#Region "Main Toolbar"

    Private Sub Editar_Click() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.SUELDO_CALCULOMODULO_EDITAR) Then
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
                _SueldoCalculoModulo.IdUsuarioCreacion = pUsuario.IDUsuario
                _SueldoCalculoModulo.FechaHoraCreacion = Now
            End If
            _SueldoCalculoModulo.IdUsuarioModificacion = pUsuario.IDUsuario
            _SueldoCalculoModulo.FechaHoraModificacion = Now
            Try
                ' Guardo los cambios
                _dbContext.SaveChanges()

                ' Refresco la lista de Importes de Cursos de Años Lectivos para mostrar los cambios
                If CardonerSistemas.Forms.MdiChildIsLoaded(CType(pFormMDIMain, Form), "FormCalculosModulos") Then
                    Dim form As FormCalculosModulos = CType(CardonerSistemas.Forms.MdiChildGetInstance(CType(pFormMDIMain, Form), "FormCalculosModulos"), FormCalculosModulos)
                    form.RefreshData(_SueldoCalculoModulo.Mes, _SueldoCalculoModulo.IdSueldoConcepto, False)
                    form = Nothing
                End If

            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Me.Cursor = Cursors.Default
                Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                    Case CardonerSistemas.Database.EntityFramework.Errors.DuplicatedEntity
                        MsgBox("No se pueden guardar los cambios porque ya existe un ítem con el mismo mes, año y concepto.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
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

        If ComboBoxConcepto.SelectedIndex = -1 Then
            MsgBox("Debe especificar el concepto.", MsgBoxStyle.Information, My.Application.Info.Title)
            ComboBoxConcepto.Focus()
            Return False
        End If

        Return True
    End Function

#End Region

End Class