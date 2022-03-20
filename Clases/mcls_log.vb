Imports System.Data.SqlClient
Public Class mcls_log
    'Private fecha As String = Format(DateTime.Today(), "yyyymmdd")
    'Private hora As String = Format(Now, "hh: mm:ss")

    Public usuario As String = ""
    Public area As Int16 = 0
    Public proceso As String = ""
    Public detalle As String = ""
    Public error_codigo As String = ""
    Public error_descripcion As String = ""

    Public Sub log_event_ok()
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand("mpa_01000", Conn)
        Dim Da As New SqlDataAdapter(Cmd)
        Try
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@usuario", usuario)
            Cmd.Parameters.AddWithValue("@area", area)
            Cmd.Parameters.AddWithValue("@proceso", proceso)
            Cmd.Parameters.AddWithValue("@detalle", detalle)
            Conn.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("no pudo registrarse en el log.")
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Sub

    Public Sub log_event_error()
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand("mpa_01002", Conn)
        Dim Da As New SqlDataAdapter(Cmd)
        Try
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@usuario", usuario)
            Cmd.Parameters.AddWithValue("@area", area)
            Cmd.Parameters.AddWithValue("@proceso", proceso)
            Cmd.Parameters.AddWithValue("@detalle", detalle)
            Cmd.Parameters.AddWithValue("@error_numero", error_codigo)
            Cmd.Parameters.AddWithValue("@error_descripcion", error_descripcion)
            Conn.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("no pudo registrarse en el log.")
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Sub

End Class
