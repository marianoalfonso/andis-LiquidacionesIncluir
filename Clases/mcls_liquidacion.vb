Imports System.Data.SqlClient
Public Class mcls_liquidacion

    'mfcn_delete    :   elimina una liquidación recibida como parámetro

    Public Function mfcn_delete(ByVal numliq As Int32) As Boolean
        Dim conn As New SqlConnection(gsConnectionString)
        Dim cmd As New SqlCommand("mpa_00822", conn)
        Dim da As New SqlDataAdapter(cmd)
        cmd.CommandType = CommandType.StoredProcedure
        Try
            cmd.Parameters.AddWithValue("@p_numeroliquidacion", numliq)
            conn.Open()
            If cmd.ExecuteNonQuery() > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Function



End Class
