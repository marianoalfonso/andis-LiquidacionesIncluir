Imports System.Data.SqlClient

Public Class cls_00001

    Friend pmt1 As String = ""
    Friend pmt2 As String = ""
    Friend pmt3 As Int16 = 0

    Friend Function mfn_00002(periodo As String) As Boolean
        'search periodo in a previously loaded array
        Try
            Dim find As Int16 = Array.IndexOf(periodos, periodo)
            If find <> -1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

    'returns true or false depending on whether an authorization exists or not
    Friend Function mfn_00001() As Boolean
        Dim cnn As New SqlConnection(gsConnectionString)
        Dim comm As New SqlCommand
        Try
            If pmt1 <> "" And pmt2 <> "" Then
                comm.CommandText = "mpa_00600"
                comm.CommandType = CommandType.StoredProcedure
                comm.Connection = cnn
                comm.Parameters.AddWithValue("@pmt1", pmt1)
                comm.Parameters.AddWithValue("@pmt2", pmt2)
                'seteamos el parametro output
                comm.Parameters.Add("@pmt3", SqlDbType.Int)
                comm.Parameters("@pmt3").Direction = ParameterDirection.Output
                cnn.Open()
                comm.ExecuteScalar()
                Dim reg As Integer = comm.Parameters("@pmt3").Value
                comm.Dispose()
                cnn.Close()
                If reg > 0 Then
                    Return False
                Else
                    Return True
                End If
            Else
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)

            cnn.Dispose()
            Return True
        End Try
    End Function



    Friend Function mfn_00002() As DataTable
        Dim cnn As New SqlConnection(gsConnectionString)
        Dim comm As New SqlCommand
        Dim Da As New SqlDataAdapter(comm)
        Dim Dt As New DataTable()
        Try
            If pmt1 <> "" And pmt2 <> "" And pmt3 <> 0 Then
                comm.CommandText = "mpa_00802"
                comm.CommandType = CommandType.StoredProcedure
                comm.Connection = cnn
                comm.Parameters.AddWithValue("@pmt1", pmt1)
                comm.Parameters.AddWithValue("@pmt2", pmt2)
                comm.Parameters.AddWithValue("@pmt3", pmt3)
                cnn.Open()
                Da.Fill(Dt)
                cnn.Close()
                cnn.Dispose()
                Return Dt
            Else
                Return Dt
            End If
        Catch ex As Exception
            MessageBox.Show("error obteniendo detalle de liquidaciones", "detalle de liquidaciones")
            Return Dt
        End Try
    End Function

End Class
