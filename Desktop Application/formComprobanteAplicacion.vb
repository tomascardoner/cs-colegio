Public Class formComprobanteAplicacion

#Region "Declarations"
    Private mComprobanteActual As Comprobante
    Private mComprobanteTipoActual As ComprobanteTipo
    Private mComprobanteAplicacionActual As ComprobanteAplicacion

    Private mEditMode As Boolean = False

    Public Class GridRowData_Comprobante
        Public Property IDComprobante As Integer
        Public Property TipoNombre As String
        Public Property NumeroCompleto As String
        Public Property FechaEmision As Date
        Public Property ImporteTotal As Decimal
        Public Property ImporteAplicado As Decimal?
        Public Property ImporteSinAplicar As Decimal?
    End Class
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByVal ParentEditMode As Boolean, ByVal EditMode As Boolean, ByRef ParentForm As Form, ByRef ComprobanteActual As Comprobante, ByRef ComprobanteTipoActual As ComprobanteTipo, ByRef ComprobanteAplicacionActual As ComprobanteAplicacion)
        mEditMode = EditMode

        mComprobanteActual = ComprobanteActual
        mComprobanteTipoActual = ComprobanteTipoActual
        mComprobanteAplicacionActual = ComprobanteAplicacionActual

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
        FillList_Comprobante()
    End Sub

    Private Sub formEntidad_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mComprobanteActual = Nothing
        mComprobanteAplicacionActual = Nothing
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub FillList_Comprobante()
        Dim listComprobantes As List(Of GridRowData_Comprobante)

        Using dbContext As New CSColegioContext(True)
            listComprobantes = (From c In dbContext.Comprobante
                                Group Join ca In dbContext.ComprobanteAplicacion On c.IDComprobante Equals ca.IDComprobanteAplicado Into ComprobanteAplicacion_join = Group
                                From ca In ComprobanteAplicacion_join.DefaultIfEmpty()
                                Where c.IDEntidad = mComprobanteActual.IDEntidad And c.IDComprobanteTipo <> mComprobanteActual.IDComprobanteTipo And c.ComprobanteTipo.OperacionTipo = mComprobanteTipoActual.OperacionTipo
                                Group New With {c, c.ComprobanteTipo, ca} By c.IDComprobante, c.ComprobanteTipo.NombreConLetra, c.NumeroCompleto, c.FechaEmision, c.ImporteTotal Into g = Group
                                Where (ImporteTotal - If(CType(g.Sum(Function(p) p.ca.Importe), Decimal?) Is Nothing, 0, g.Sum(Function(p) p.ca.Importe))) > 0
                                Select New GridRowData_Comprobante With {.IDComprobante = IDComprobante, .TipoNombre = NombreConLetra, .NumeroCompleto = NumeroCompleto, .FechaEmision = FechaEmision, .ImporteTotal = ImporteTotal, .ImporteAplicado = If(CType(g.Sum(Function(p) p.ca.Importe), Decimal?) Is Nothing, 0, g.Sum(Function(p) p.ca.Importe)), .ImporteSinAplicar = (ImporteTotal - If(CType(g.Sum(Function(p) p.ca.Importe), Decimal?) Is Nothing, 0, g.Sum(Function(p) p.ca.Importe)))}).ToList
        End Using

        datagridviewMain.AutoGenerateColumns = False
        datagridviewMain.DataSource = listComprobantes
    End Sub
    Friend Sub SetDataFromObjectToControls()
        With mComprobanteAplicacionActual
            textboxImporteAplicado.Text = CS_ValueTranslation.FromObjectMoneyToControlTextBox(.Importe)
        End With
    End Sub

    Friend Sub SetDataFromControlsToObject()
        With mComprobanteAplicacionActual
            .IDComprobanteAplicado = CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData_Comprobante).IDComprobante
            .Importe = CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxImporteAplicado.Text).Value
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

    Private Sub AplicarComprobante() Handles datagridviewMain.DoubleClick
        If Not datagridviewMain.CurrentRow Is Nothing Then
            textboxImporteAplicado.Text = FormatCurrency(CType(datagridviewMain.SelectedRows(0).DataBoundItem, GridRowData_Comprobante).ImporteSinAplicar)
        End If
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
            MsgBox("No hay ningún Comprobante para aplicar.", vbInformation, My.Application.Info.Title)
            datagridviewMain.Focus()
            Exit Sub
        End If
        If textboxImporteAplicado.Text.Trim.Length = 0 Then
            MsgBox("Debe ingresar el Importe a aplicar.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxImporteAplicado.Focus()
            Exit Sub
        End If
        If Not CS_ValueTranslation.ValidateCurrency(textboxImporteAplicado.Text) Then
            MsgBox("El Importe ingresado no es válido.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxImporteAplicado.Focus()
            Exit Sub
        End If
        If CS_ValueTranslation.FromControlTextBoxToObjectDecimal(textboxImporteAplicado.Text).Value <= 0 Then
            MsgBox("El Importe a aplicar debe ser mayor a cero.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxImporteAplicado.Focus()
            Exit Sub
        End If

        ' Si es un nuevo item, busco el próximo Indice y agrego el objeto nuevo a la colección del parent
        If mComprobanteAplicacionActual.IDComprobanteAplicado = 0 Then
            mComprobanteActual.ComprobanteAplicacion_Aplicados.Add(mComprobanteAplicacionActual)
        End If

        ' Paso los datos desde los controles al Objecto de EF
        SetDataFromControlsToObject()

        ' Refresco la lista para mostrar los cambios
        If CS_Form.MDIChild_IsLoaded(CType(formMDIMain, Form), "formComprobante") Then
            Dim formComprobante As formComprobante = CType(CS_Form.MDIChild_GetInstance(CType(formMDIMain, Form), "formComprobante"), formComprobante)
            formComprobante.RefreshData_Aplicaciones(mComprobanteAplicacionActual.IDComprobanteAplicado)
            formComprobante = Nothing
        End If

        Me.Close()
    End Sub
#End Region

End Class