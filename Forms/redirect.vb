Public Class redirect


    Private Sub redirect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TabControl1.SelectedTab.TabIndex < 6 Then
            TabControl1.SelectedIndex = TabControl1.SelectedTab.TabIndex + 1
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TabControl1.SelectedTab.TabIndex > 0 Then
            TabControl1.SelectedIndex = TabControl1.SelectedTab.TabIndex - 1
        End If
    End Sub

End Class