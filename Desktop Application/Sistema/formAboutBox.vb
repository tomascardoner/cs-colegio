Imports System.Reflection

Public NotInheritable Class formAboutBox

    Private Sub formAboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = String.Format("Acerca de {0}", My.Application.Info.Title)
        labelApplicationTitle.Text = My.Application.Info.Title
        labelVersion.Text = String.Format("Version {0} - ({1})", My.Application.Info.Version.ToString, IO.File.GetLastWriteTime(Assembly.GetExecutingAssembly().Location).ToString("yyyyMMdd"))
        labelCopyright.Text = My.Application.Info.Copyright
        labelLicensedTo.Text = pLicensedTo

        ' Propiedades
        listviewPropiedades.Items.Clear()
        Dim NewItem As ListViewItem

        NewItem = New ListViewItem
        NewItem.Text = "Datasource"
        NewItem.SubItems.Add(pDatabase.Datasource)
        listviewPropiedades.Items.Add(NewItem)

        NewItem = New ListViewItem
        NewItem.Text = "Database"
        NewItem.SubItems.Add(pDatabase.InitialCatalog)
        listviewPropiedades.Items.Add(NewItem)

        NewItem = New ListViewItem
        NewItem.Text = "Reports path"
        NewItem.SubItems.Add(pGeneralConfig.ReportsPath)
        listviewPropiedades.Items.Add(NewItem)

        Try
            NewItem = New ListViewItem
            NewItem.Text = "Crystal Reports version"
            NewItem.SubItems.Add(CrystalDecisions.Shared.ReportingVersion.ASSEMBLY_VERSION)
            listviewPropiedades.Items.Add(NewItem)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
        Me.Close()
    End Sub
End Class
