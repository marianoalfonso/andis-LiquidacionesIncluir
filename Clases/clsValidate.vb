Imports System.Data.SqlClient

Public Class clsValidate

    Shared Function validarAutorizacion(ByVal cstring As String, ByVal time_frame As String, ByVal sector As Int16) As Int16
        'abstract: devuelve si existe o no una autorizacion válida para el periodo
        'parameters
        'IN: cstring (cadena conexion)
        'IN: time_Frame (periodo: ej.mmyyyy)
        'IN: sector (area: ej.D = 1)
        'OUT: @p_VALIDO
        Dim Conn As New SqlConnection(cstring)
        Dim Cmd As New SqlCommand
        Try
            Cmd.CommandText = "pa_CHEQUEAR_AUTORIZACION_PERIODO_4"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@p_PERIODO", time_frame)
            Cmd.Parameters.AddWithValue("@sAREA", sector)
            Cmd.Parameters.Add("@p_VALIDO", SqlDbType.TinyInt, 1)
            Cmd.Parameters("@p_VALIDO").Direction = ParameterDirection.Output
            Conn.Open()
            Cmd.ExecuteScalar()
            Dim output_Registros As Int16 = CInt(Cmd.Parameters("@p_VALIDO").Value)
            If output_Registros = 1 Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            Return -1
        Finally
            Conn.Close()
        End Try
    End Function

    Shared Function validarLiquidacion(ByVal cstring As String, ByVal cuit As String, ByVal time_frame As String, ByVal invoice_number As String) As Int16
        'ex funcion Chequear_Liquidacion_Existente
        'abstract: devuelve si existe o no una autorizacion válida para el periodo
        'parameters
        'IN: cstring (cadena conexion)
        'IN: time_Frame (periodo: ej.mmyyyy)
        'IN: sector (area: ej.D)
        'IN: invoice_number (optional: 0 = null)
        'OUT: @p_VALIDO --> 0: no existe, 1: existe, 3: error
        Dim Conn As New SqlConnection(cstring)
        Dim Cmd As New SqlCommand
        Try
            Cmd.CommandText = "pa_VERIFICAR_EXISTENCIA_LIQUIDACION_V3"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@CUIT", Trim(cuit))
            Cmd.Parameters.AddWithValue("@PERIODO", time_frame)
            Cmd.Parameters.AddWithValue("@NUMEROFACTURA", invoice_number)
            Cmd.Parameters.Add("@p_VALIDO", SqlDbType.TinyInt, 1)
            Cmd.Parameters("@p_VALIDO").Direction = ParameterDirection.Output
            Conn.Open()
            Cmd.ExecuteScalar()
            Dim output_Registros As Int16 = CInt(Cmd.Parameters("@p_VALIDO").Value)
            If output_Registros = 1 Then
                Return 1
            Else
                Return 0
            End If
        Catch ex As Exception
            Return 3
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function

End Class
