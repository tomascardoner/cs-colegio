﻿Public Class formAnioLectivoCursoImporteGenerar

#Region "Declarations"
    Private mdbContext As New CSColegioContext(True)

    Private mIsLoading As Boolean = False
#End Region

#Region "Form stuff"
    Friend Sub LoadAndShow(ByRef ParentForm As Form)
        mIsLoading = True

        Me.MdiParent = formMDIMain
        CS_Form.CenterToParent(ParentForm, Me)
        InitializeFormAndControls()
        Me.Show()
        If Me.WindowState = FormWindowState.Minimized Then
            Me.WindowState = FormWindowState.Normal
        End If
        Me.Focus()

        mIsLoading = False
    End Sub

    Friend Sub InitializeFormAndControls()
        SetAppearance()

        ' Cargo los ComboBox
        pFillAndRefreshLists.Mes(comboboxMesInicio, True, False, False)
        pFillAndRefreshLists.AnioLectivo(comboboxAnioLectivo, False, SortOrder.Ascending)
    End Sub

    Friend Sub SetAppearance()

    End Sub

    Private Sub Me_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        mdbContext.Dispose()
        mdbContext = Nothing
        Me.Dispose()
    End Sub
#End Region

#Region "Controls behavior"
    Private Sub AnioLectivoChange() Handles comboboxAnioLectivo.SelectedValueChanged
        If Not comboboxAnioLectivo.SelectedValue Is Nothing Then
            Me.Cursor = Cursors.WaitCursor

            listviewAnioLectivoCurso.Items.Clear()

            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub FormKeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Select Case e.KeyChar
            Case Microsoft.VisualBasic.ChrW(Keys.Return)
                buttonGuardar.PerformClick()
            Case Microsoft.VisualBasic.ChrW(Keys.Escape)
                buttonCancelar.PerformClick()
        End Select
    End Sub

    Private Sub TextBoxs_GotFocus(sender As Object, e As EventArgs) Handles textboxImporteMatricula.GotFocus, textboxImporteCuota.GotFocus
        CType(sender, TextBox).SelectAll()
    End Sub
#End Region

#Region "Main Toolbar"
    Private Sub buttonCerrarOCancelar_Click() Handles buttonCancelar.Click
        Me.Close()
    End Sub

    Private Sub buttonGuardar_Click() Handles buttonGuardar.Click
        If comboboxAnioLectivo.SelectedIndex = -1 Then
            MsgBox("Debe especificar el Año Lectivo de Origen.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxAnioLectivo.Focus()
            Exit Sub
        End If
        
        ' Leo en una lista los Cursos del Año Lectivo de Origen
        Dim listAniosLectivosCursos As List(Of AnioLectivoCurso)

        ' Verifico que tenga Cursos asociados
        listAniosLectivosCursos = mdbContext.AnioLectivoCurso.Where(Function(alc) alc.AnioLectivo = CShort(comboboxAnioLectivo.Text) And alc.Curso.EsActivo).ToList
        If listAniosLectivosCursos.Count = 0 Then
            MsgBox("El Año Lectivo de Origen no tiene Cursos asociados.", MsgBoxStyle.Information, My.Application.Info.Title)
            comboboxAnioLectivo.Focus()
            Exit Sub
        End If

        ' Pido confirmación de la operación y procedo
        If MsgBox(String.Format("Se copiarán {3} Cursos desde el Año Lectivo {1} al Año Lectivo {2}.{0}{0}¿Desea continuar?", vbCrLf, comboboxAnioLectivo.Text, listAniosLectivosCursos.Count), CType(MsgBoxStyle.Question + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
            Me.Cursor = Cursors.WaitCursor

            ' Obtengo el Siguiente ID. Siempre hay algún registro en la Base de Datos, ya que antes verificamos que el Año Lectivo de Origen tenga Cursos asignados
            Dim NewID As Short
            Using dbcMaxID As New CSColegioContext(True)
                NewID = dbcMaxID.AnioLectivoCurso.Max(Function(alc) alc.IDAnioLectivoCurso) + CShort(1)
            End Using

            Try
                For Each AnioLectivoCursoActual As AnioLectivoCurso In listAniosLectivosCursos
                    Dim AnioLectivoCursoDestino As New AnioLectivoCurso

                    With AnioLectivoCursoDestino
                        .IDAnioLectivoCurso = NewID
                        .IDCurso = AnioLectivoCursoActual.IDCurso
                    End With
                    mdbContext.AnioLectivoCurso.Add(AnioLectivoCursoDestino)

                    NewID += CShort(1)
                Next
                mdbContext.SaveChanges()

            Catch dbuex As System.Data.Entity.Infrastructure.DbUpdateException
                Me.Cursor = Cursors.Default
                Select Case CS_Database_EF_SQL.TryDecodeDbUpdateException(dbuex)
                    Case Errors.DuplicatedEntity
                        MsgBox("No se pueden guardar los cambios porque ya existe el Curso en el Año Lectivo.", MsgBoxStyle.Exclamation, My.Application.Info.Title)
                End Select
                Exit Sub

            Catch ex As Exception
                Me.Cursor = Cursors.Default
                CS_Error.ProcessError(ex, My.Resources.STRING_ERROR_SAVING_CHANGES)
                Exit Sub

            End Try

            ' Refresco la lista para mostrar los cambios
            If CS_Form.MDIChild_IsLoaded(CType(formMDIMain, Form), "formAniosLectivosCursos") Then
                Dim formAniosLectivosCursos As formAniosLectivosCursos = CType(CS_Form.MDIChild_GetInstance(CType(formMDIMain, Form), "formAniosLectivosCursos"), formAniosLectivosCursos)
                formAniosLectivosCursos.RefreshData()
                formAniosLectivosCursos = Nothing
            End If

            Me.Cursor = Cursors.Default
        End If

        Me.Close()
    End Sub
#End Region

End Class