Imports System.Data.SqlClient
Public Class clsLog

    'Private fecha As String = Format(DateTime.Today(), "yyyymmdd")
    'Private hora As String = Format(Now, "hh: mm:ss")

    Public usuario As String = ""
    Public area As Int16 = 0
    Public proceso As String = ""
    Public detalle As String = ""
    Public error_codigo As String = ""
    Public error_descripcion As String = ""

    Sub log_event_ok()
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand("pa_REGISTRAR_LOG", Conn)
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
            MsgBox("no pudo registrarse en el log.", vbInformation)
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Sub

End Class
