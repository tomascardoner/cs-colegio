Public Class FormCalculoModulo

#Region "Declarations"

    Private _dbContext As New CSColegioContext(True)
    Private _SueldoCalculoModulo As SueldoCalculoModulo

    Private _IsNew As Boolean
    Private _IsLoading As Boolean = False
    Private _IsEditMode As Boolean = False

#End Region

#Region "Form stuff"

    Public Sub New(editMode As Boolean, anio As Short, mes As Byte, idSueldoConcepto As Short)
        InitializeComponent()
        _IsNew = (idSueldoConcepto = 0)
        _IsLoading = True
        _IsEditMode = editMode

        If _IsNew Then
            _SueldoCalculoModulo = New SueldoCalculoModulo With {.Anio = anio, .Mes = mes}
            _dbContext.SueldoCalculoModulo.Add(_SueldoCalculoModulo)
        Else
            _SueldoCalculoModulo = _dbContext.SueldoCalculoModulo.Find(anio, mes, idSueldoConcepto)
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
        pFillAndRefreshLists.SueldoConcepto(ComboBoxConcepto, False, False)
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
        ComboBoxConcepto.Enabled = (_IsEditMode AndAlso _IsNew)
        CurrencyTextBoxImporte.ReadOnly = Not _IsEditMode
    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        _dbContext.Dispose()
        _SueldoCalculoModulo = Nothing
    End Sub

#End Region

#Region "User interface data"

    Friend Sub SetDataToUserInterface()
        With _SueldoCalculoModulo
            TextBoxAnio.Text = .Anio.ToString()
            ComboBoxMes.SelectedIndex = .Mes - 1
            CardonerSistemas.Controls.ComboBox.SetSelectedValue(ComboBoxConcepto, CardonerSistemas.Controls.ComboBox.SelectedItemOptions.ValueOrFirstIfUnique, .IdSueldoConcepto)
            CS_ValueTranslation_Syncfusion.FromValueToControl(.Importe, CurrencyTextBoxImporte)
        End With
    End Sub

    Friend Sub SetDataToEntityObject()
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

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles CurrencyTextBoxImporte.GotFocus
        CType(sender, Syncfusion.Windows.Forms.Tools.CurrencyTextBox).SelectAll()
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
        If _IsNew Then
            _SueldoCalculoModulo.IdUsuarioCreacion = pUsuario.IDUsuario
            _SueldoCalculoModulo.FechaHoraCreacion = Now
        End If
        _SueldoCalculoModulo.IdUsuarioModificacion = pUsuario.IDUsuario
        _SueldoCalculoModulo.FechaHoraModificacion = Now

        Try
            Me.Cursor = Cursors.WaitCursor
            _dbContext.SaveChanges()
        Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
            Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                Case CardonerSistemas.Database.EntityFramework.Errors.DuplicatedEntity
                    MessageBox.Show("No se pueden guardar los cambios porque ya existe un ítem con el mismo mes, año y concepto.", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End Select
            Me.Cursor = Cursors.Default
            Return
        Catch ex As Exception
            CardonerSistemas.ErrorHandler.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
            Me.Cursor = Cursors.Default
            Return
        End Try

        Comunes.RefreshLists.SueldosCalculosModulos.Refresh(_SueldoCalculoModulo.Mes, _SueldoCalculoModulo.IdSueldoConcepto)
        Me.Close()
    End Sub

    Private Sub Cerrar_Click() Handles buttonCerrar.Click
        Me.Close()
    End Sub

    Private Sub Editar_Click() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.SUELDO_CALCULOMODULO_EDITAR) Then
            _IsEditMode = True
            ChangeEditMode()
        End If
    End Sub

    Private Sub Cancelar_Click() Handles buttonCancelar.Click
        Me.Close()
    End Sub

#End Region

#Region "Extra stuff"

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