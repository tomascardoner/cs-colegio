Public Class formAnioLectivoCuota

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)
    Private mAnioLectivoCuotaActual As AnioLectivoCuota

    Private mIsNew As Boolean
    Private mIsLoading As Boolean = False
    Private mEditMode As Boolean = False
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByVal EditMode As Boolean, ByRef ParentForm As Form, ByVal AnioLectivo As Short, ByVal MesInicio As Byte, ByVal IDCuotaTipo As Byte)
        mIsNew = (IDCuotaTipo = 0)
        mIsLoading = True
        mEditMode = EditMode

        If mIsNew Then
            ' Es Nuevo
            mAnioLectivoCuotaActual = New AnioLectivoCuota
            With mAnioLectivoCuotaActual
                .AnioLectivo = AnioLectivo
            End With
            mdbContext.AnioLectivoCuota.Add(mAnioLectivoCuotaActual)
        Else
            mAnioLectivoCuotaActual = mdbContext.AnioLectivoCuota.Find(AnioLectivo, MesInicio, IDCuotaTipo)
        End If

        Me.MdiParent = pFormMDIMain
        CS_Form.CenterToParent(ParentForm, Me)
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
            Exit Sub
        End If

        buttonGuardar.Visible = mEditMode
        buttonCancelar.Visible = mEditMode
        buttonEditar.Visible = Not mEditMode
        buttonCerrar.Visible = Not mEditMode

        comboboxMesInicio.Enabled = (mEditMode And mIsNew)
        comboboxCuotaTipo.Enabled = (mEditMode And mIsNew)
        currencytextboxImporteMatricula.ReadOnly = Not mEditMode
        currencytextboxImporteCuota.ReadOnly = Not mEditMode
    End Sub

    Friend Sub InitializeFormAndControls()
        SetAppearance()

        ' Cargo los ComboBox
        pFillAndRefreshLists.Mes(comboboxMesInicio, True, False, True, False, False)
        pFillAndRefreshLists.CuotaTipo(comboboxCuotaTipo, False, False)
    End Sub

    Friend Sub SetAppearance()

    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        mAnioLectivoCuotaActual = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub SetDataFromObjectToControls()
        With mAnioLectivoCuotaActual
            textboxAnioLectivo.Text = mAnioLectivoCuotaActual.AnioLectivo.ToString
            comboboxMesInicio.SelectedIndex = .MesInicio - 1
            CS_ComboBox.SetSelectedValue(comboboxCuotaTipo, SelectedItemOptions.ValueOrFirstIfUnique, .IDCuotaTipo)
            currencytextboxImporteMatricula.DecimalValue = .ImporteMatricula
            currencytextboxImporteCuota.DecimalValue = .ImporteCuota
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mAnioLectivoCuotaActual
            .MesInicio = CByte(comboboxMesInicio.SelectedIndex + 1)
            .IDCuotaTipo = CS_ValueTranslation.FromControlComboBoxToObjectByte(comboboxCuotaTipo.SelectedValue).Value
            .ImporteMatricula = currencytextboxImporteMatricula.DecimalValue
            .ImporteCuota = currencytextboxImporteCuota.DecimalValue
        End With
    End Sub
#End Region

#Region "Controls behavior"
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

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs)
        CType(sender, TextBox).SelectAll()
    End Sub
#End Region

#Region "Main Toolbar"
    Private Sub buttonEditar_Click() Handles buttonEditar.Click
        If Permisos.VerificarPermiso(Permisos.ANIOLECTIVOCUOTA_EDITAR) Then
            mEditMode = True
            ChangeMode()
        End If
    End Sub

    Private Sub buttonCerrarOCancelar_Click() Handles buttonCerrar.Click, buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonGuardar_Click() Handles buttonGuardar.Click
        If comboboxMesInicio.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Mes de Inicio.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxMesInicio.Focus()
            Exit Sub
        End If
        If comboboxCuotaTipo.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Tipo de Cuota.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxCuotaTipo.Focus()
            Exit Sub
        End If


        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        If mdbContext.ChangeTracker.HasChanges Then

            Me.Cursor = Cursors.WaitCursor

            Try
                ' Guardo los cambios
                mdbContext.SaveChanges()

                ' Refresco la lista de Importes de Cursos de Años Lectivos para mostrar los cambios
                If CS_Form.MDIChild_IsLoaded(CType(pFormMDIMain, Form), "formAnioLectivoCuotas") Then
                    Dim formAnioLectivoCuotas As formAnioLectivoCuotas = CType(CS_Form.MDIChild_GetInstance(CType(pFormMDIMain, Form), "formAnioLectivoCuotas"), formAnioLectivoCuotas)
                    formAnioLectivoCuotas.RefreshData(mAnioLectivoCuotaActual.AnioLectivo, mAnioLectivoCuotaActual.MesInicio, mAnioLectivoCuotaActual.IDCuotaTipo, False)
                    formAnioLectivoCuotas = Nothing
                End If

            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Me.Cursor = Cursors.Default
                Select Case CS_Database_EF_SQL.TryDecodeDbUpdateException(dbuex)
                    Case Errors.DuplicatedEntity
                        MsgBox("No se pueden guardar los cambios porque ya existe el Mes de Inicio del Importe del Curso para el Año Lectivo.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                End Select
                Exit Sub

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                CS_Error.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
                Exit Sub
            End Try
        End If

        Me.Close()
    End Sub
#End Region

End Class