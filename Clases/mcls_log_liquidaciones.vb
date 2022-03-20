Imports System.Data.SqlClient

'clase para registrar los procesos de liquidacion cuando se genera la misma sin error
Public Class mcls_log_liquidaciones

    Public _usuario As String = ""
    Public _numerofactura As String = ""
    Public _cuit As String = ""
    Public _periodo As String = ""  'yyyymm
    Public _sector As String = ""

    Public Sub registrar_liquidacion()
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand("mpa_01010", Conn)
        Dim Da As New SqlDataAdapter(Cmd)
        Try
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@usuario", _usuario)
            Cmd.Parameters.AddWithValue("@numerofactura", _numerofactura)
            Cmd.Parameters.AddWithValue("@cuit", _cuit)
            Cmd.Parameters.AddWithValue("@periodo", _periodo)
            Cmd.Parameters.AddWithValue("@sector", _sector)
            Conn.Open()
            Cmd.ExecuteNonQuery()
        Catch ex As Exception
            MessageBox.Show("la liquidacion no pudo registrarse en el log.")
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try

    End Sub

End Class
