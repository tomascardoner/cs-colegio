Public Class FormCalculoModuloObtener

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

    End Sub

    Friend Sub InitializeFormAndControls()
        Me.Icon = CardonerSistemas.Graphics.GetIconFromBitmap(My.Resources.ImageSueldo32)
        pFillAndRefreshLists.MesNombres(ToolStripComboBoxMes.ComboBox, True, False, False)
        ToolStripComboBoxMes.SelectedIndex = DateTime.Today.Month - 1
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
            'TextBoxAnio.Text = .Anio.ToString()
            ToolStripComboBoxMes.SelectedIndex = .Mes - 1
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With _SueldoLiquidacion
            .Mes = CByte(ToolStripComboBoxMes.SelectedIndex + 1)
        End With
    End Sub

#End Region

#Region "Controls events"

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs)
        CType(sender, TextBox).SelectAll()
    End Sub

#End Region

#Region "Main Toolbar"


#End Region

#Region "Extra stuff"

    Private Function VerificarDatos() As Boolean
        If ToolStripComboBoxAnio.SelectedIndex = -1 Then
            MsgBox("Debe especificar el año.", MsgBoxStyle.Information, My.Application.Info.Title)
            ToolStripComboBoxAnio.Focus()
            Return False
        End If

        If ToolStripComboBoxMes.SelectedIndex = -1 Then
            MsgBox("Debe especificar el mes.", MsgBoxStyle.Information, My.Application.Info.Title)
            ToolStripComboBoxMes.Focus()
            Return False
        End If

        Return True
    End Function

#End Region

End Class