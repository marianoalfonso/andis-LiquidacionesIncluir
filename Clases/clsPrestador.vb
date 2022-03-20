Imports System.Data.SqlClient

Public Class clsPrestador


    'ANALIZA QUE FACTURAS FUERON INCLUIDAS EN LA CONSOLIDACION DE LOS PERIODOS Y DEVUELVE VERDADERO O FALSO SI FUE O NO CONSOLIDADA
    Friend Function Analizar_Facturas_Periodo_Consolidado(ByVal Cuit As String, ByVal Periodo As String, ByVal NumeroFactura As String) As Boolean
        Dim Arr As String()
        Dim bFacturaExiste As Boolean
        Try
            bFacturaExiste = False
            Arr = Listar_Facturas_Consolidadas(Cuit, Periodo)
            For Each Valor As String In Arr
                If Trim(Valor) = NumeroFactura Then bFacturaExiste = True
            Next
            Return bFacturaExiste
        Catch ex As Exception
            Return False
        Finally
        End Try
    End Function

    'DEVUELVE UN ARRAY CON LAS FACTURAS CONSOLIDADAS EN UN PERIODO DADO
    Friend Function Listar_Facturas_Consolidadas(ByVal Cuit As String, ByVal Periodo As String) As String()
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Dim Dr As SqlDataReader
        Try

            Cmd.CommandText = "pa_CHEQUEAR_CONSOLIDACIONES_FACTURAS"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@CUIT", Cuit)
            Cmd.Parameters.AddWithValue("@PERIODO", Periodo)
            Conn.Open()
            Dr = Cmd.ExecuteReader()
            If Dr.Read = Nothing Then
                Return Nothing
            Else
                Dim ArrFacturas As String() = Dr.Item("Facturas_Consolidadas").Split(",")
                Return ArrFacturas
            End If
            Dr.Close()
        Catch ex As Exception
            Return Nothing
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function

    'DEVUELVE UN ARRAY CON LAS FACTURAS DISPONIBLES PARA UN PRESTADOR EN UN PERIODO DADO
    'Friend Function Listar_Facturas_Periodo(ByVal cuit As String, ByVal periodo As String, ByVal sector As Int16) As String()
    '    Dim Conn As New SqlConnection(gsConnectionString)
    '    Dim Cmd As New SqlCommand
    '    Dim Dr As SqlDataReader
    '    Dim Facturas() As String
    '    Dim a As Integer = 0
    '    Try
    '        Cmd.CommandText = "pa_OBTENER_FACTURAS_PERIODO_4"
    '        Cmd.CommandType = CommandType.StoredProcedure
    '        Cmd.Connection = Conn
    '        Cmd.Parameters.AddWithValue("@p_PERIODO", periodo)
    '        Cmd.Parameters.AddWithValue("@sAREA", sector)
    '        Cmd.Parameters.AddWithValue("@p_CUIT", cuit)
    '        Conn.Open()
    '        Dr = Cmd.ExecuteReader()
    '        If Dr.Read = Nothing Then
    '            Return Nothing
    '        Else
    '            ReDim Facturas(a)
    '            Facturas(a) = Dr.Item("FAC_NUMEROFACTURA")
    '        End If
    '        While Dr.Read = True
    '            a += 1
    '            ReDim Preserve Facturas(a)
    '            Facturas(a) = Dr.Item("FAC_NUMEROFACTURA")
    '        End While
    '        Return Facturas
    '        Dr.Close()
    '    Catch ex As Exception
    '        Return Nothing
    '    Finally
    '        Conn.Close()
    '        Conn.Dispose()
    '        Cmd.Dispose()
    '    End Try
    'End Function

    'DEVUELVE UN ARRAY CON LAS FACTURAS DISPONIBLES PARA UN PRESTADOR EN UN PERIODO DADO
    Public Function Listar_Facturas_Periodo(ByVal cuit As String, ByVal periodo As String, ByVal sector As Int16) As DataTable
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand("mpa_00200", Conn)
        Cmd.CommandTimeout = 120
        Cmd.CommandType = CommandType.StoredProcedure
        Dim Dt As New DataTable
        Dim Da As New SqlDataAdapter(Cmd)
        'Dim Facturas() As String
        'Dim a As Integer = 0
        Try
            'Cmd.CommandText = "mpa_00200"
            'Cmd.CommandType = CommandType.StoredProcedure
            'Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@p_PERIODO", periodo)
            Cmd.Parameters.AddWithValue("@sAREA", sector)
            Cmd.Parameters.AddWithValue("@p_CUIT", cuit)
            Da.Fill(Dt)
            Return Dt
        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return Nothing
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function

    'CHEQUEA SI UN PRESTADOR O CUALQUIERA DE LOS DOS PERIODOS RECIBIDOS COMO PARMAMETRO FORMAN PARTE DE UNA CONSOLIDACION
    Friend Function Chequear_Consolidacion_Existente(ByVal Cuit As String, ByVal Periodo_A As String, ByVal Periodo_B As String) As Boolean
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Dim iRegistros As Integer
        Try
            Cmd.CommandText = "pa_VERIFICAR_EXISTENCIA_CONSOLIDACION"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@CUIT", Trim(Cuit))
            Cmd.Parameters.AddWithValue("@PERIODO_A", Periodo_A)
            Cmd.Parameters.AddWithValue("@PERIODO_B", Periodo_B)
            Conn.Open()
            iRegistros = Cmd.ExecuteScalar()
            If iRegistros > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function

    'SI EXISTE UNA CONSOLIDACION PARA ESTE PRESTADOR, DEVUELVE EL NUMERO DE FACTURA CONSOLIDADA (UNICO)
    Friend Function Obtener_Factura_Consolidada(ByVal Cuit As String, ByRef rPeriodo As String) As String
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Dim Dr As SqlDataReader
        Dim FacturaConsolidada As String
        Try
            Cmd.CommandText = "pa_OBTENER_FACTURA_CONSOLIDADA"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@CUIT", Trim(Cuit))
            Cmd.Parameters.AddWithValue("@PERIODO", Trim(rPeriodo))
            Conn.Open()
            Dr = Cmd.ExecuteReader()
            If Dr.Read = Nothing Then
                Return "0"
            Else
                FacturaConsolidada = Dr.Item("CONS_FACTURA_CONSOLIDADA")
                rPeriodo = Dr.Item("CONS_PERIODO_B")
                Return FacturaConsolidada
            End If
            Dr.Close()
        Catch ex As Exception
            Return "0"
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function

    'EN PROCESO DE CONSTRUCCION
    'DEVUELVE TRUE O FALSE SI LA FACTURA RECIBIDA COMO PARAMETRO ESTA INCLUIDA EN UNA CONSOLIDACION
    Friend Function Chequear_Consolidacion_Factura(ByVal Cuit As String, ByVal Periodo As String, ByVal sNumeroFactura As String) As Boolean
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Dim iRegistros As Integer
        Try
            Cmd.CommandText = "pa_VERIFICAR_CONSOLIDACION_FACTURA"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@CUIT", Trim(Cuit))
            Cmd.Parameters.AddWithValue("@PERIODO", Periodo)
            Cmd.Parameters.AddWithValue("@FACTURA", sNumeroFactura)
            Conn.Open()
            iRegistros = Cmd.ExecuteScalar()
            If iRegistros > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MsgBox("error verificando si una factura esta consolidada", vbCritical)
            Return False
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function

    'DEVUELVE LA RAZON SOCIAL DE UN PRESTADOR EN BASE AL CUIT RECIBIDO
    Friend Function Obtener_Razon_Social(ByVal Cuit As String) As String
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Dim Dr As SqlDataReader
        Dim RazonSocial As String
        Try
            Cmd.CommandText = "pa_OBTENER_RAZON_SOCIAL_4"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@CUIT", Trim(Cuit))
            Conn.Open()
            Dr = Cmd.ExecuteReader()
            If Dr.Read = Nothing Then
                Return Nothing
            Else
                RazonSocial = Dr.Item("FAC_RAZONSOCIAL")
                Return RazonSocial
            End If
            Dr.Close()
        Catch ex As Exception
            Return Nothing
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function


End Class
