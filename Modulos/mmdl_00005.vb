Imports System.Data.SqlClient
Module mmdl_00005

    Public periodos() As String
    Public prestadores As New Dictionary(Of String, String)
    Public seguridad() As String
    'Public prest_facturas As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))
    Public prest_facturas()() As String = New String()() {}
    Dim mcls_log As New mcls_log


    'load general parameters
    Public Sub mfn_00001()
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand("select parametro, valor from mvw_parametros", Conn)
        Dim Dr As SqlDataReader
        Try
            Cmd.CommandType = CommandType.Text
            Conn.Open()
            Dr = Cmd.ExecuteReader()
            While Dr.Read = True
                If Trim(Dr.Item(0)) = "dias_elim_fact" Then             'dias retroactivos para eliminacion de facturas
                    g_dias_eliminacion_liquidacion = Integer.Parse(Dr.Item(1))
                ElseIf Trim(Dr.Item(0)) = "monto_elevacion" Then        'monto de elevación en pesos
                    g_monto_elevacion = Integer.Parse(Dr.Item(1))
                End If
            End While
        Catch ex As Exception
            mcls_log.usuario = "app"
            mcls_log.area = 0
            mcls_log.proceso = "parametros seteo"
            mcls_log.detalle = "error seteando parametros (Sub mfn_00001)"
            mcls_log.error_codigo = Err.Number
            mcls_log.error_descripcion = Err.Description
            mcls_log.log_event_error()
            MessageBox.Show("error seteando parametros", "parametros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Finally
            Conn.Close()
        End Try
    End Sub


    'load authorizations periods
    Public Sub mfn_00005()
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Dim Dr As SqlDataReader

        Dim a As Int16 = -1
        Try
            Cmd.CommandText = "select aut_periodo from autorizaciones group by aut_periodo"
            Cmd.CommandType = CommandType.Text
            Cmd.Connection = Conn
            Conn.Open()
            Dr = Cmd.ExecuteReader()
            While Dr.Read = True
                a += 1
                ReDim Preserve periodos(a)
                periodos(a) = Dr.Item("aut_periodo")
            End While
            Dr.Close()
        Catch ex As Exception
            mcls_log.usuario = "app"
            mcls_log.area = 0
            mcls_log.proceso = "autorizaciones periodos"
            mcls_log.detalle = "error cargando periodos autorizados (Sub mfn_00005)"
            mcls_log.error_codigo = Err.Number
            mcls_log.error_descripcion = Err.Description
            mcls_log.log_event_error()
            MessageBox.Show("error seteando periodos autorizados", "parametros", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Finally
            Conn.Close()
            Conn.Dispose()
        End Try
    End Sub

    'deshabilitado temporalmente
    'load providers
    'Public Sub mfn_00010()
    '    Dim Conn As New SqlConnection(gsConnectionString)
    '    Dim Cmd As New SqlCommand
    '    Dim Dr As SqlDataReader
    '    Dim a As Int16 = -1
    '    Try
    '        Cmd.CommandText = "select prest_cuit,prest_nombre from mvw_prestadores order by prest_cuit"
    '        Cmd.CommandType = CommandType.Text
    '        Cmd.Connection = Conn
    '        Conn.Open()
    '        Dr = Cmd.ExecuteReader()

    '        'no puede agregarse a una lista dos items con el mismo ID (ver como solucionar con otro objeto)
    '        While Dr.Read = True
    '            prestadores.Add(Dr.Item("prest_cuit"), Dr.Item("prest_nombre"))
    '        End While

    '        Dr.Close()
    '    Catch ex As Exception
    '        mcls_log.usuario = "app"
    '        mcls_log.area = 0
    '        mcls_log.proceso = "autorizaciones periodos"
    '        mcls_log.detalle = "error cargando prestadores (Sub mfn_00010)"
    '        mcls_log.error_codigo = Err.Number
    '        mcls_log.error_descripcion = Err.Description
    '        mcls_log.log_event_error()
    '        MessageBox.Show("error cargando prestadores", "parametros", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '        'End
    '    Finally
    '        Conn.Close()
    '        Conn.Dispose()
    '    End Try
    'End Sub

    'load security into array
    Public Sub mfn_00006()
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand("mpa_00006", Conn)
        Dim Dr As SqlDataReader

        Dim a As Int16 = -1
        Try
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@usuario", sUsuario)
            Cmd.Parameters.AddWithValue("@area", sArea)
            Conn.Open()
            Dr = Cmd.ExecuteReader()
            While Dr.Read = True
                a += 1
                ReDim Preserve seguridad(a)
                seguridad(a) = Dr.Item("modulo")
            End While
            Dr.Close()
        Catch ex As Exception
            mcls_log.usuario = sUsuario
            mcls_log.area = sArea
            mcls_log.proceso = "01.05"
            mcls_log.detalle = "error seteando seguridad (Sub mfn_00006)"
            mcls_log.error_codigo = Err.Number
            mcls_log.error_descripcion = Err.Description
            mcls_log.log_event_error()
            MessageBox.Show("error seteando seguridad", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Finally
            Conn.Close()
            Conn.Dispose()
        End Try
    End Sub

End Module
