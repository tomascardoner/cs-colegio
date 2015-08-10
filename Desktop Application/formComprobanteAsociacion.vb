Public Class formComprobanteAsociacion

#Region "Declarations"
    Private mComprobanteActual As Comprobante
    Private mComprobanteTipoActual As ComprobanteTipo
    Private mComprobanteAsociacionActual As ComprobanteAsociacion

    Private mEditMode As Boolean = False

    Public Class GridRowData_Comprobante
        Public Property IDComprobante As Integer
        Public Property TipoNombre As String
        Public Property NumeroCompleto As String
        Public Property FechaEmision As Date
        Public Property ImporteTotal As Decimal
    End Class
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByVal ParentEditMode As Boolean, ByVal EditMode As Boolean, ByRef ParentForm As Form, ByRef ComprobanteActual As Comprobante, ByRef ComprobanteTipoActual As ComprobanteTipo, ByRef ComprobanteAsocacionActual As ComprobanteAsociacion)
        mEditMode = EditMode

        mComprobanteActual = ComprobanteActual
        mComprobanteTipoActual = ComprobanteTipoActual
        mComprobanteAsociacionActual = ComprobanteAsocacionActual

        'Me.MdiParent = formMDIMain
        CS_Form.CenterToParent(ParentForm, Me)
        ChangeMode()
        buttonEditar.Visible = (ParentEditMode And Not mEditMode)
        InitializeFormAndControls()
        SetDataFromObjectToControls()
        Me.ShowDialog(ParentForm)
        'If Me.WindowState = FormWindowState.Minimized Then
        '    Me.WindowState = FormWindowState.Normal
        'End If
        'Me.Focus()
    End Sub

    Private Sub ChangeMode()
        buttonGuardar.Visible = mEditMode
        buttonCancelar.Visible = mEditMode
        buttonEditar.Visible = Not mEditMode
        buttonCerrar.Visible = Not mEditMode

        CS_Form.ControlsChangeStateEnabled(Me.Controls, mEditMode, True, True, True, toolstripMain.Name)
    End Sub

    Friend Sub InitializeFormAndControls()
        ' Cargo los ComboBox
        pFillAndRefreshLists.ComprobanteAsociacionMotivo(comboboxMotivo)
        FillList_Comprobante()
    End Sub

    Private Sub formEntidad_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mComprobanteActual = Nothing
        mComprobanteAsociacionActual = Nothing
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub FillList_Comprobante()
        Dim listComprobantes As List(Of GridRowData_Comprobante)

        Using dbContext As New CSColegioContext(True)
            listComprobantes = (From ct In dbContext.ComprobanteTipo
                                From cta In ct.ComprobanteTipo_Asociantes
                                From c In ct.Comprobante
                                Where c.IDEntidad = mComprobanteActual.IDEntidad And ct.OperacionTipo = mComprobanteTipoActual.OperacionTipo And cta.IDComprobanteTipo = mComprobanteActual.IDComprobanteTipo
                                Order By c.FechaEmision Descending
                                Select New GridRowData_Comprobante With {.IDComprobante = c.IDComprobante, .TipoNombre = ct.NombreConLetra, .NumeroCompleto = c.NumeroCompleto, .FechaEmision = c.FechaEmision, .ImporteTotal = c.ImporteTotal}).ToList
        End Using

        datagridviewMain.AutoGenerateColumns = False
        datagridviewMain.DataSource = listComprobantes
    End Sub
    Friend Sub SetDataFromObjectToControls()
        With mComprobanteAsociacionActual
            comboboxMotivo.Text = CS_ValueTranslation.FromObjectStringToControlTextBox(.Motivo)
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mComprobanteAsociacionActual
            .IDComprobanteAsociado = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData_Comprobante).IDComprobante
            .Motivo = CS_ValueTranslation.FromControlTextBoxToObjectString(comboboxMotivo.Text)
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
#End Region

#Region "Main Toolbar"
    Private Sub buttonEditar_Click() Handles buttonEditar.Click
        mEditMode = True
        ChangeMode()
    End Sub

    Private Sub buttonCerrarOCancelar_Click() Handles buttonCerrar.Click, buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonGuardar_Click() Handles buttonGuardar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ningún Comprobante para asociar.", vbInformation, My.Application.Info.Title)
            datagridviewMain.Focus()
            Exit Sub
        End If
        If comboboxMotivo.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar el Motivo de la Asociación.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxMotivo.Focus()
            Exit Sub
        End If

        ' Si es un nuevo item, busco el próximo Indice y agrego el objeto nuevo a la colección del parent
        If mComprobanteAsociacionActual.IDComprobanteAsociado = 0 Then
            mComprobanteActual.ComprobanteAsociacion_Asociados.Add(mComprobanteAsociacionActual)
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        ' Refresco la lista para mostrar los cambios
        If CS_Form.MDIChild_IsLoaded(CType(formMDIMain, Form), "formComprobante") Then
            Dim formComprobante As formComprobante = CType(CS_Form.MDIChild_GetInstance(CType(formMDIMain, Form), "formComprobante"), formComprobante)
            formComprobante.RefreshData_Asociaciones(mComprobanteAsociacionActual.IDComprobanteAsociado)
            formComprobante = Nothing
        End If

        Me.Close()
    End Sub
#End Region

End Class