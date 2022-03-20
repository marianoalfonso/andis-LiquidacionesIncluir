Imports System.Data.SqlClient

Friend Class clsLiquidacion

    Public Function detalleliquidacion(l_numliq As Integer) As DataTable
        Dim conn As New SqlConnection(gsConnectionString)
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try
            cmd.CommandText = "select * from mvw_03002 where num_liq = " + l_numliq.ToString
            cmd.CommandType = CommandType.Text
            cmd.Connection = conn
            conn.Open()
            da.Fill(dt)
            conn.Close()
            Return dt
        Catch ex As Exception
            Return dt
        End Try
    End Function

    Public Function liquidacionesasociadas(l_periodo As String, l_cuit As String, l_area As Int16)
        Dim conn As New SqlConnection(gsConnectionString)
        Dim cmd As New SqlCommand
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        Try
            cmd.CommandText = "mpa_00820"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Connection = conn
            cmd.Parameters.AddWithValue("@pmt1", l_periodo)
            cmd.Parameters.AddWithValue("@pmt4", l_cuit)
            cmd.Parameters.AddWithValue("@pmt5", l_area)
            conn.Open()
            da.Fill(dt)
            conn.Close()
            Return dt
        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return dt
        End Try
    End Function

    'TOTALIZA EL DEBITO DE UNA LIQUIDACION RECIBIDA COMO PARAMETRO
    Friend Function Totalizar_Liquidacion(ByVal iNum_Liq As Integer) As Double
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Try
            If iNum_Liq > 0 Then
                Cmd.CommandText = "pa_TOTALIZAR_LIQUIDACION"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Connection = Conn
                Cmd.Parameters.AddWithValue("@p_NUMERO_LIQUIDACION", iNum_Liq)
                'Cmd.Parameters.Add("@p_TOTALLIQUIDADO", SqlDbType.Money)
                Cmd.Parameters.Add("@p_TOTALLIQUIDADO", SqlDbType.Decimal)
                Cmd.Parameters("@p_TOTALLIQUIDADO").Direction = ParameterDirection.Output
                Conn.Open()
                Cmd.ExecuteScalar()
                Dim output_TotalLiquidacion As Double = Cmd.Parameters("@p_TOTALLIQUIDADO").Value
                Return output_TotalLiquidacion
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox("Error totalizando la liquidacion", vbCritical)
            Return -1
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function

    'TOTALIZA EL DEBITO DE UNA LIQUIDACION RECIBIDA COMO PARAMETRO
    Friend Function Totalizar_Debitos(ByVal Num_Liq As Integer) As Double
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Try
            If Num_Liq > 0 Then
                Cmd.CommandText = "pa_TOTALIZAR_DEBITO"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Connection = Conn
                Cmd.Parameters.AddWithValue("@p_NUMERO_LIQUIDACION", Num_Liq)
                Cmd.Parameters.Add("@p_TOTALDEBITADO", SqlDbType.Money)
                Cmd.Parameters("@p_TOTALDEBITADO").Direction = ParameterDirection.Output
                Conn.Open()
                Cmd.ExecuteScalar()
                Dim output_TotalDebito As Double = Cmd.Parameters("@p_TOTALDEBITADO").Value
                Return output_TotalDebito
            Else
                Return 0
            End If
        Catch ex As Exception
            MsgBox("Error totalizando los debitos", vbCritical)
            Return -1
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function

    'FUNCION PARA COMPENSAR EL VALOR CUANDO EL VALOR FACTURADO ELECTRONICAMENTE ES SUPERIOR AL FACTURADO EN LA FACTURA PAPEL
    'SI EL MONTO ES MENOR A $5, LA FUNCION TOMA EL PRIMER VALOR DE LA FACTURACION Y LE RESTA LA DIFERENCIA
    Friend Function Compensar_Factura(ByVal sPeriodo As String, ByVal sCuit As String, ByVal NumeroFactura As String, ByVal tempMontoFactura As Double) As Boolean
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Dim Da As New SqlDataAdapter(Cmd)
        Dim Dt As New DataTable()
        Try
            Cmd.CommandText = "pa_COMPENSAR_SALDO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@p_PERIODO", Trim(sPeriodo))
            Cmd.Parameters.AddWithValue("@p_CUIT", Trim(sCuit))
            Cmd.Parameters.AddWithValue("@p_NUMEROFACTURA", Trim(NumeroFactura))
            Cmd.Parameters.AddWithValue("@p_MONTO_FACTURADO_EN_PAPEL", tempMontoFactura)
            Conn.Open()
            Cmd.ExecuteNonQuery()
            Conn.Close()
            Return True
        Catch ex As Exception
            MsgBox("Error Compensando la factura", vbCritical)
            Return False
        End Try
    End Function

    'DEVUELVE EL TOTAL SUMARIZADO DE UNA FACTURACION PARA UN CUIT, PERIODO Y NUMERO DE FACTURA RECIBIDOS COMO PARAMETRO
    'Friend Function Totalizar_Facturacion(ByVal lArea As SByte, ByVal lCuit As String, ByVal lPeriodo As String, ByVal lSucursal As String, ByVal lNumeroFactura As String) As Double
    Friend Function Totalizar_Facturacion(ByVal area As Int16, ByVal cuit As String, ByVal periodo As String, ByVal sucursal As String, ByVal numeroFactura As String) As Double
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        'Try
        '    Cmd.CommandText = "mpa_00911"
        '    Cmd.CommandType = CommandType.StoredProcedure
        '    Cmd.Connection = Conn
        '    'Cmd.Parameters.AddWithValue("@p_AREA", Trim(sArea))
        '    Cmd.Parameters.AddWithValue("@sAREA", area) 'variable global
        '    Cmd.Parameters.AddWithValue("@p_CUIT", cuit)
        '    Cmd.Parameters.AddWithValue("@p_PERIODO", periodo)
        '    Cmd.Parameters.AddWithValue("@p_SUCURSAL", sucursal)
        '    Cmd.Parameters.AddWithValue("@p_NUMEROFACTURA", numeroFactura)
        '    Cmd.Parameters.Add("@p_TOTALFACTURADO", SqlDbType.Money)
        '    Cmd.Parameters("@p_TOTALFACTURADO").Direction = ParameterDirection.Output
        '    Conn.Open()
        '    Cmd.ExecuteScalar()
        '    Dim output_TotalFacturacion As Double = Cmd.Parameters("@p_TOTALFACTURADO").Value
        '    Return output_TotalFacturacion
        'Catch ex As Exception
        '    If Err.Number = 5 Then
        '        MsgBox("error de tiempo de espera totalizando la facturacion" & Chr(13) &
        '               "Informe al administrador del sistema", vbCritical)
        '    Else
        '        MsgBox("Error totalizando la facturacion" & Chr(13) &
        '               "Informe al administrador del sistema", vbCritical)
        '    End If
        '    Return 0
        'Finally
        '    Conn.Close()
        '    Conn.Dispose()
        '    Cmd.Dispose()
        'End Try
        Try
            'Cmd.CommandText = "select isnull(sum(total),0) from mvw_facturaciones_totalizadas where area = '" & area & "' and cuit = '" & cuit & "' and periodo = '" & periodo & "'' and factura= '" & numeroFactura & "'"
            Cmd.CommandText = "select isnull(total,0) from mvw_facturaciones_totalizadas where area = 'D' and cuit = '" & cuit & "' and periodo = '" & periodo & "' and factura= '" & numeroFactura & "'"
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Conn
            Conn.Open()
            'Cmd.ExecuteScalar()
            Dim output_TotalFacturacion As Double = Cmd.ExecuteScalar()
            Return output_TotalFacturacion
        Catch ex As Exception
            If Err.Number = 5 Then
                MsgBox("error de tiempo de espera totalizando la facturacion" & Chr(13) &
                       "Informe al administrador del sistema", vbCritical)
            Else
                MsgBox("Error totalizando la facturacion" & Chr(13) &
                       "Informe al administrador del sistema", vbCritical)
            End If
            Return 0
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function

    'DEVUELVE TRUE O FALSE SI EXISTE O NO UNA LIQUIDACION PARA UN CUIT + PERIODO
    Friend Function Chequear_Liquidacion_Existente(ByVal cuit As String, ByVal periodo As String, ByVal numeroFactura As String) As Boolean
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Dim iRegistros As Integer
        Try
            Cmd.CommandText = "mpa_900"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@cuit", cuit)
            Cmd.Parameters.AddWithValue("@periodo", periodo)
            Cmd.Parameters.AddWithValue("@numerofactura", numeroFactura)
            Conn.Open()
            iRegistros = Cmd.ExecuteScalar()
            If iRegistros > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("error en la funcion fChequear_Liquidacion_Existente (" & Err.Description & ")", vbCritical)
            Return False
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function

    'VALIDA LA SELECCION VALIDA DE UN PERIODO PARA UNA NUEVA LIQUIDACION
    Friend Function Validar_Periodo(ByVal Periodo As String, Area As String) As Boolean
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Try
            Cmd.CommandText = "pa_CHEQUEAR_AUTORIZACION_PERIODO_NEW"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@p_PERIODO", Periodo)
            Cmd.Parameters.AddWithValue("@p_AREA", Area)
            Cmd.Parameters.Add("@p_VALIDO", SqlDbType.Char, 1)
            Cmd.Parameters("@p_VALIDO").Direction = ParameterDirection.Output
            Conn.Open()
            Cmd.ExecuteScalar()
            Dim output_Registros As Integer = CInt(Cmd.Parameters("@p_VALIDO").Value)
            If output_Registros = 1 Then
                Return True
            ElseIf output_Registros = 0 Then
                Return False
            End If
        Catch ex As Exception
            gsError = Err.Number
            Return False
        Finally
            Conn.Close()
        End Try
    End Function

    'verifica el monto facturado electronicamente contra el informado en la factura física
    'totalElectronicInvoice: total factura electronica
    'totalPaperInvoice: total factura fisica
    '0: no es posible la liquidacion
    '1: si es posible la liquidacion
    Friend Function Validar_Montofacturado(totalElectronicInvoice As Double, totalPaperInvoice As Double) As System.SByte

        If (totalElectronicInvoice > totalPaperInvoice) And (totalElectronicInvoice - totalPaperInvoice) > 5 Then
            Return 0
        Else
            Return 1
        End If

    End Function

End Class
