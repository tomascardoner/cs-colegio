Public Class formReportViewer

    Private Sub formReportViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.reportviewerMain.RefreshReport()
    End Sub
End Class