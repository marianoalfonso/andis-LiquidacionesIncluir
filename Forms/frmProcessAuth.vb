Public Class frmProcessAuth
    Private Sub frmProcessAuth_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToParent()
        lblUsuario.Text = Trim(sUsuario)
        lblTexto.Text = "ingrese password"
        txtPwd.Text = ""
    End Sub

    Private Sub cmdConfirmar_Click(sender As Object, e As EventArgs) Handles cmdConfirmar.Click
        Me.Hide()
    End Sub
End Class