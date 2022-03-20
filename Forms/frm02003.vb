Imports System.Data.SqlClient
Public Class frm02003
    Private Sub frm02003_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mfc_load_comp()
    End Sub

    Sub mfc_load_comp()
        Dim conn As New SqlConnection(gsConnectionString)
        Dim cmd As New SqlCommand("mpa_00260", conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try
            conn.Open()
            da.Fill(dt)
            If dt.Rows.Count() > 0 Then
                dgvComplementarias.DataSource = dt
            End If
        Catch ex As Exception

        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub
End Class