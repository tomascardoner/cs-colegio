Public Class formTest

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            MyTab.ShowTabPageByName(TabPage1.Name)
        Else
            MyTab.HideTabPageByName(TabPage1.Name)
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            MyTab.ShowTabPageByName(TabPage2.Name)
        Else
            MyTab.HideTabPageByName(TabPage2.Name)
        End If

    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        If CheckBox3.Checked Then
            MyTab.ShowTabPageByName(TabPage3.Name)
        Else
            MyTab.HideTabPageByName(TabPage3.Name)
        End If

    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked Then
            MyTab.ShowTabPageByName(TabPage4.Name)
        Else
            MyTab.HideTabPageByName(TabPage4.Name)
        End If

    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked Then
            MyTab.ShowTabPageByName(TabPage5.Name)
        Else
            MyTab.HideTabPageByName(TabPage5.Name)
        End If
    End Sub
End Class