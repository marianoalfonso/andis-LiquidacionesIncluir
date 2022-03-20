Imports System.Data.SqlClient

Public Class clsConsolidacion


    'CHEQUEA EL ESTADO DE UN PRESTADOR PARA UN PERIODO DADO
    '1 (no consolidado y no liquidado)
    '2 (no consolidado y liquidado)
    '3 (consolidado y no liquidado)
    '4 (consolidado y liquidado)

    Function Estado_Prestador_Factura(ByVal sCuit As String, ByVal sPeriodo As String, Optional ByVal sNumeroFactura As String = "0") As Boolean
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Dim Dr As SqlDataReader
        Try
            Cmd.CommandText = "pa_CHEQUEAR_CONSOLIDACIONES"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@CUIT", sCuit)
            Cmd.Parameters.AddWithValue("@PERIODO", sPeriodo)
            Conn.Open()
            Dr = Cmd.ExecuteReader()
            If Dr.Read <> Nothing Then

                MsgBox("El prestador seleccionado para la liquidación esta bajo una modalidad de consolidación de dos períodos.", vbInformation)


            Else
                'btnCopiarMonto.Visible = False
                Return False
            End If

        Catch
            Return False
        Finally
            Dr.Close()
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function




End Class
