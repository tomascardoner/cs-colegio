Option Strict Off

Public Class formCABGenerico
    Friend dbcontext As New CSColegioContext(True)
    Friend EntityDBSet As System.Data.Entity.DbSet

    Friend EntityNameSingular As String
    Friend EntityNamePlural As String

    Private mExtraToolbars() As ToolStrip = {}

    Private Sub formCABGenerico_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.Text = EntityNamePlural
    End Sub

    Private Sub bindingsourceMain_ListChanged(sender As Object, e As System.ComponentModel.ListChangedEventArgs) Handles bindingsourceMain.ListChanged
        Select Case bindingsourceMain.Count
            Case 0
                statuslabelMain.Text = String.Format("No hay {0} para mostrar.", EntityNamePlural)
            Case 1
                statuslabelMain.Text = String.Format("Se muestra 1 {0}.", EntityNameSingular)
            Case Else
                statuslabelMain.Text = String.Format("Se muestran {0} {1}.", bindingsourceMain.Count, EntityNamePlural)
        End Select
    End Sub

    Private Sub formCABGenerico_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If dbcontext.ChangeTracker.HasChanges Then
            If MsgBox("Se han realizado cambios a los datos." & vbCr & "¿Desea guardarlos?", CType(MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, MsgBoxStyle), My.Application.Info.Title) = MsgBoxResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                dbcontext.SaveChanges()
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub formCABGenerico_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        EntityDBSet = Nothing
    End Sub

    Friend Function AddToolbar(ByVal ToolbarName As String) As ToolStrip
        Dim NewIndex As Integer = mExtraToolbars.Length

        ReDim Preserve mExtraToolbars(NewIndex)

        mExtraToolbars(NewIndex) = New ToolStrip
        With mExtraToolbars(NewIndex)
            .Name = ToolbarName

        End With
        flowlayoutpanelMain.Controls.Add(mExtraToolbars(NewIndex))
        Return mExtraToolbars(NewIndex)
    End Function

    Private Sub bindingnavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles bindingnavigatorSaveItem.Click
        dbcontext.SaveChanges()
    End Sub
End Class