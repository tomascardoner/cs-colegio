Public Class formComunicaciones

#Region "Declarations"
    Private mlistComunicacionesBase As List(Of Comunicacion)
    Private mlistComunicacionesFiltradaYOrdenada As List(Of Comunicacion)

    Private mSkipFilterData As Boolean = False
    Private mBusquedaAplicada As Boolean = False

    Private mOrdenColumna As DataGridViewColumn
    Private mOrdenTipo As SortOrder
#End Region

#Region "Form stuff"
    Friend Sub SetAppearance()
        datagridviewMain.DefaultCellStyle.Font = My.Settings.GridsAndListsFont
        datagridviewMain.ColumnHeadersDefaultCellStyle.Font = My.Settings.GridsAndListsFont
    End Sub

    Private Sub Me_Load() Handles Me.Load
        SetAppearance()

        mSkipFilterData = True

        comboboxActivo.Items.AddRange({My.Resources.STRING_ITEM_ALL_MALE, My.Resources.STRING_YES, My.Resources.STRING_NO})
        comboboxActivo.SelectedIndex = 1

        mSkipFilterData = False

        mOrdenColumna = columnNombre
        mOrdenTipo = SortOrder.Ascending

        RefreshData()
    End Sub
#End Region

#Region "Load and Set Data"
    Friend Sub RefreshData(Optional ByVal PositionIDComunicacion As Short = 0, Optional ByVal RestoreCurrentPosition As Boolean = False)

        Me.Cursor = Cursors.WaitCursor

        Try
            Using dbContext As New CSColegioContext(True)
                mlistComunicacionesBase = (From com In dbContext.Comunicacion
                                           Select com).ToList
            End Using

        Catch ex As Exception

            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al leer las Comunicaciones.")
            Me.Cursor = Cursors.Default
            Exit Sub
        End Try

        Me.Cursor = Cursors.Default

        If RestoreCurrentPosition Then
            If datagridviewMain.CurrentRow Is Nothing Then
                PositionIDComunicacion = 0
            Else
                PositionIDComunicacion = CType(datagridviewMain.CurrentRow.DataBoundItem, Comunicacion).IDComunicacion
            End If
        End If

        FilterData()

        If PositionIDComunicacion <> 0 Then
            For Each CurrentRowChecked As DataGridViewRow In datagridviewMain.Rows
                If CType(CurrentRowChecked.DataBoundItem, Comunicacion).IDComunicacion = PositionIDComunicacion Then
                    datagridviewMain.CurrentCell = CurrentRowChecked.Cells(0)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub FilterData()

        If Not mSkipFilterData Then
            Me.Cursor = Cursors.WaitCursor

            Try
                ' Inicializo las variables
                mlistComunicacionesFiltradaYOrdenada = mlistComunicacionesBase.ToList

                'Filtro por Activo
                Select Case comboboxActivo.SelectedIndex
                    Case 0      ' Todos
                    Case 1      ' Sí
                        mlistComunicacionesFiltradaYOrdenada = mlistComunicacionesFiltradaYOrdenada.Where(Function(a) a.EsActivo).ToList
                    Case 2      ' No
                        mlistComunicacionesFiltradaYOrdenada = mlistComunicacionesFiltradaYOrdenada.Where(Function(a) Not a.EsActivo).ToList
                End Select

                Select Case mlistComunicacionesFiltradaYOrdenada.Count
                    Case 0
                        statuslabelMain.Text = String.Format("No hay Comunicaciones para mostrar.")
                    Case 1
                        statuslabelMain.Text = String.Format("Se muestra 1 Comunicación.")
                    Case Else
                        statuslabelMain.Text = String.Format("Se muestran {0} Comunicaciones.", mlistComunicacionesFiltradaYOrdenada.Count)
                End Select

            Catch ex As Exception
                CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al filtrar los datos.")
                Me.Cursor = Cursors.Default
                Exit Sub
            End Try

            OrderData()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub OrderData()
        ' Realizo las rutinas de ordenamiento
        Select Case mOrdenColumna.Name
            Case columnIDComunicacion.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistComunicacionesFiltradaYOrdenada = mlistComunicacionesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.IDComunicacion).ToList
                Else
                    mlistComunicacionesFiltradaYOrdenada = mlistComunicacionesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.IDComunicacion).ToList
                End If
            Case columnNombre.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistComunicacionesFiltradaYOrdenada = mlistComunicacionesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Nombre).ToList
                Else
                    mlistComunicacionesFiltradaYOrdenada = mlistComunicacionesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Nombre).ToList
                End If
            Case columnAsunto.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistComunicacionesFiltradaYOrdenada = mlistComunicacionesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.Asunto).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                Else
                    mlistComunicacionesFiltradaYOrdenada = mlistComunicacionesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.Asunto).ThenByDescending(Function(dgrd) dgrd.Nombre).ToList
                End If
            Case columnEsActivo.Name
                If mOrdenTipo = SortOrder.Ascending Then
                    mlistComunicacionesFiltradaYOrdenada = mlistComunicacionesFiltradaYOrdenada.OrderBy(Function(dgrd) dgrd.EsActivo).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                Else
                    mlistComunicacionesFiltradaYOrdenada = mlistComunicacionesFiltradaYOrdenada.OrderByDescending(Function(dgrd) dgrd.EsActivo).ThenBy(Function(dgrd) dgrd.Nombre).ToList
                End If
        End Select

        datagridviewMain.AutoGenerateColumns = False
        datagridviewMain.DataSource = mlistComunicacionesFiltradaYOrdenada

        ' Muestro el ícono de orden en la columna correspondiente
        mOrdenColumna.HeaderCell.SortGlyphDirection = mOrdenTipo
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub CambioFiltros() Handles comboboxActivo.SelectedIndexChanged
        FilterData()
    End Sub

    Private Sub GridChangeOrder(sender As Object, e As DataGridViewCellMouseEventArgs) Handles datagridviewMain.ColumnHeaderMouseClick
        Dim ClickedColumn As DataGridViewColumn

        ClickedColumn = CType(datagridviewMain.Columns(e.ColumnIndex), DataGridViewColumn)

        If ClickedColumn Is mOrdenColumna Then
            ' La columna clickeada es la misma por la que ya estaba ordenado, así que cambio la dirección del orden
            If mOrdenTipo = SortOrder.Ascending Then
                mOrdenTipo = SortOrder.Descending
            Else
                mOrdenTipo = SortOrder.Ascending
            End If
        Else
            ' La columna clickeada es diferencte a la que ya estaba ordenada.
            ' En primer lugar saco el ícono de orden de la columna vieja
            If Not mOrdenColumna Is Nothing Then
                mOrdenColumna.HeaderCell.SortGlyphDirection = SortOrder.None
            End If

            ' Ahora preparo todo para la nueva columna
            mOrdenTipo = SortOrder.Ascending
            mOrdenColumna = ClickedColumn
        End If

        OrderData()
    End Sub
#End Region

#Region "Main Toolbar"
    Private Sub Agregar_Click() Handles buttonAgregar.Click
        If Permisos.VerificarPermiso(Permisos.COMUNICACION_AGREGAR) Then
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formComunicacion.LoadAndShow(True, Me, 0)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Copiar_Click() Handles buttonCopiar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Comunicación para copiar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.COMUNICACION_AGREGAR) Then
                Me.Cursor = Cursors.WaitCursor

                datagridviewMain.Enabled = False

                formComunicacion.LoadAndShow(True, Me, CType(datagridviewMain.SelectedRows(0).DataBoundItem, Comunicacion).IDComunicacion, True)

                datagridviewMain.Enabled = True

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Editar_Click() Handles buttonEditar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Comunicación para editar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.COMUNICACION_EDITAR) Then
                Me.Cursor = Cursors.WaitCursor

                datagridviewMain.Enabled = False

                formComunicacion.LoadAndShow(True, Me, CType(datagridviewMain.SelectedRows(0).DataBoundItem, Comunicacion).IDComunicacion, False)

                datagridviewMain.Enabled = True

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Eliminar_Click() Handles buttonEliminar.Click
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Comunicación para eliminar.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.ANIO_ELIMINAR) Then

                Me.Cursor = Cursors.WaitCursor

                Using dbContext = New CSColegioContext(True)
                    Dim ComunicacionActual As Comunicacion = dbContext.Comunicacion.Find(CType(datagridviewMain.SelectedRows(0).DataBoundItem, Comunicacion).IDComunicacion)
                    Dim Mensaje As String
                    Mensaje = String.Format("Se eliminará la Comunicación seleccionada.{0}{0}{1}{0}{0}¿Confirma la eliminación definitiva?", vbCrLf, ComunicacionActual.Nombre)
                    If MsgBox(Mensaje, CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then

                        Try
                            dbContext.Comunicacion.Remove(ComunicacionActual)
                            dbContext.SaveChanges()

                        Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                            Select Case CardonerSistemas.Database.EntityFramework.TryDecodeDbUpdateException(dbuex)
                                Case CardonerSistemas.Database.EntityFramework.Errors.RelatedEntity
                                    MsgBox("No se puede eliminar la Comunicación porque tiene datos relacionados.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                            End Select
                            Me.Cursor = Cursors.Default
                            Exit Sub

                        Catch ex As Exception
                            CardonerSistemas.ErrorHandler.ProcessError(ex, "Error al eliminar la Comunicación.")
                        End Try

                        RefreshData()
                    End If
                End Using

                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Ver() Handles datagridviewMain.DoubleClick
        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Comunicación para ver.", vbInformation, My.Application.Info.Title)
        Else
            Me.Cursor = Cursors.WaitCursor

            datagridviewMain.Enabled = False

            formComunicacion.LoadAndShow(False, Me, CType(datagridviewMain.SelectedRows(0).DataBoundItem, Comunicacion).IDComunicacion)

            datagridviewMain.Enabled = True

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub EnviarEmail_Click() Handles buttonEnviarEmail.Click
        Dim ComunicacionActual As Comunicacion

        If datagridviewMain.CurrentRow Is Nothing Then
            MsgBox("No hay ninguna Comunicación para enviar por e-mail.", vbInformation, My.Application.Info.Title)
        Else
            If Permisos.VerificarPermiso(Permisos.COMUNICACION_ENVIAREMAIL) Then
                ComunicacionActual = CType(datagridviewMain.SelectedRows(0).DataBoundItem, Comunicacion)

                Dim DireccionEmailDestino As String = ""
                DireccionEmailDestino = InputBox("Ingrese la dirección de e-mail del Destinatario.", My.Application.Info.Title)
                If DireccionEmailDestino <> "" Then
                    If Not CS_Email.IsValidEmail(DireccionEmailDestino.Trim, CS_Parameter_System.GetString(Parametros.EMAIL_VALIDATION_REGULAREXPRESSION)) Then                        
                        MsgBox("La dirección de e-mail es incorrecta.", vbInformation, My.Application.Info.Title)
                        Exit Sub
                    End If

                    Me.Cursor = Cursors.WaitCursor
                    datagridviewMain.Enabled = False

                    Select Case My.Settings.LoteComprobantes_EnviarEmail_Metodo
                        Case CardonerSistemas.Constants.EMAIL_CLIENT_NETDLL
                            If MiscFunctions.EnviarEmail_PorNETClient(New System.Net.Mail.MailAddress(DireccionEmailDestino), Nothing, Nothing, ComunicacionActual.Asunto, ComunicacionActual.CuerpoMensajeEsHTML, ComunicacionActual.CuerpoMensaje, Nothing, "", ComunicacionActual.ArchivoAdjunto, False) Then
                                MsgBox("Se ha enviado la Comunicación por e-mail.", vbInformation, My.Application.Info.Title)
                            End If
                        Case CardonerSistemas.Constants.EMAIL_CLIENT_MSOUTLOOK
                            'MiscFunctions.EnviarEmailPorMSOutlook(ComprobanteActual.Entidad, Asunto, Cuerpo, ReporteActual, AdjuntoNombre, False)
                            'If MailCount = -1 Then
                            '    Return 0
                            'End If
                        Case CardonerSistemas.Constants.EMAIL_CLIENT_CRYSTALREPORTSMAPI
                            'Result = MiscFunctions.EnviarEmailPorCrystalReportsMAPI(ComprobanteActual.Entidad, Asunto, Cuerpo, ReporteActual, AdjuntoNombre, False)
                            'If Result = -1 Then
                            '    Return 0
                            'End If
                    End Select

                    datagridviewMain.Enabled = True
                    Me.Cursor = Cursors.Default

                End If
            End If
        End If
    End Sub

#End Region

End Class