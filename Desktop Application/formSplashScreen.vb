Public Class formSplashScreen
    Private Sub SplashScreen_Load() Handles MyBase.Load
        labelCompanyName.Text = My.Application.Info.CompanyName
        labelAppTitle.Text = My.Application.Info.Title
        labelCopyright.Text = My.Application.Info.Copyright
    End Sub
End Class
