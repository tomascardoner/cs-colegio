Public Class formEntidadesVerificadorEmail

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)
    Private listEntidadesEmail1 As List(Of Entidad)
    Private listEntidadesEmail2 As List(Of Entidad)
    Private listEntidades As List(Of Entidad)
#End Region

#Region "Form stuff"
    Private Sub Me_Load() Handles Me.Load

    End Sub

    Private Sub Me_Closed() Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        listEntidadesEmail1 = Nothing
        listEntidadesEmail2 = Nothing
        listEntidades = Nothing
        Me.Dispose()
    End Sub

#End Region

#Region "Load and Set Data"

#End Region

#Region "Controls behavior"
    Private Sub BuscarEnOutlook() Handles buttonBuscarEnOutlook.Click
        Dim CRejectedEmailAddresses As Collection

        If datetimepickerOutlookFechaDesde.Value.Date > Date.Today Then
            MsgBox("Le Fecha Desde, para la Búsqueda en Microsoft Outlook, debe ser menor o igual a hoy.", MsgBoxStyle.Information, My.Application.Info.Title)
            datetimepickerOutlookFechaDesde.Focus()
            Exit Sub
        End If
        If datetimepickerOutlookFechaHasta.Value.Date > Date.Today Then
            MsgBox("Le Fecha Hasta, para la Búsqueda en Microsoft Outlook, debe ser menor o igual a hoy.", MsgBoxStyle.Information, My.Application.Info.Title)
            datetimepickerOutlookFechaHasta.Focus()
            Exit Sub
        End If
        If datetimepickerOutlookFechaDesde.Value.Date > datetimepickerOutlookFechaHasta.Value.Date Then
            MsgBox("Le Fecha Hasta, para la Búsqueda en Microsoft Outlook, debe ser mayor o igual a la Fecha Desde.", MsgBoxStyle.Information, My.Application.Info.Title)
            datetimepickerOutlookFechaHasta.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Application.DoEvents()

        CRejectedEmailAddresses = CS_Office_Outlook_EarlyBinding.FindRejectedEmails(datetimepickerOutlookFechaDesde.Value, datetimepickerOutlookFechaHasta.Value)
        If CRejectedEmailAddresses.Count > 0 Then
            textboxDireccionesEmail.Text = ""
            For Each RejectedEmailAddress As String In CRejectedEmailAddresses
                If textboxDireccionesEmail.Text.Length > 0 Then
                    textboxDireccionesEmail.Text &= "; "
                End If
                textboxDireccionesEmail.Text &= RejectedEmailAddress
            Next
        End If
        CRejectedEmailAddresses = Nothing

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BuscarEntidades() Handles buttonBuscarEntidades.Click
        Dim aDireccionesEmail() As String

        If textboxDireccionesEmail.Text.Trim.Length = 0 Then
            MsgBox("Debe especificar al menos una dirección de e-mail para buscar en las Entidades.", MsgBoxStyle.Information, My.Application.Info.Title)
            textboxDireccionesEmail.Focus()
            Exit Sub
        End If

        listEntidadesEmail1 = New List(Of Entidad)
        listEntidadesEmail2 = New List(Of Entidad)
        listEntidades = New List(Of Entidad)

        aDireccionesEmail = textboxDireccionesEmail.Text.Trim.Split(";"c)
        For Each DireccionEmail As String In aDireccionesEmail
            DireccionEmail = DireccionEmail.Trim
            If DireccionEmail.Length > 0 Then
                If CS_Email.IsValidEmail(DireccionEmail) Then
                    listEntidadesEmail1.AddRange(mdbContext.Entidad.Where(Function(ent) ent.Email1 = DireccionEmail))
                    listEntidadesEmail2.AddRange(mdbContext.Entidad.Where(Function(ent) ent.Email2 = DireccionEmail))
                End If
            End If
        Next
        listEntidades.AddRange(listEntidadesEmail1)
        listEntidades.AddRange(listEntidadesEmail2)

        datagridviewEntidades.AutoGenerateColumns = False
        datagridviewEntidades.DataSource = listEntidades
    End Sub

    Private Sub MarcarEntidades() Handles buttonMarcarEntidades.Click
        If listEntidades.Count = 0 Then
            MsgBox("No hay ninguna Entidad para marcar.", MsgBoxStyle.Information, My.Application.Info.Title)
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        For Each EntidadActual As Entidad In listEntidadesEmail1
            EntidadActual.VerificarEmail1 = True
        Next
        For Each EntidadActual As Entidad In listEntidadesEmail2
            EntidadActual.VerificarEmail2 = True
        Next

        Try
            mdbContext.SaveChanges()
            Me.Cursor = Cursors.Default
            MsgBox("Se han marcado las direcciones de e-mail de las Entidades.", MsgBoxStyle.Information, My.Application.Info.Title)
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            CS_Error.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
        End Try
    End Sub

    Private Sub Ver() Handles datagridviewEntidades.DoubleClick
        If datagridviewEntidades.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Entidad para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewEntidades.Enabled = False

            Dim EntidadActual = CType(datagridviewEntidades.SelectedRows(0).DataBoundItem, Entidad)
            formEntidad.LoadAndShow(False, Me, EntidadActual.IDEntidad)

            datagridviewEntidades.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

#End Region

End Class