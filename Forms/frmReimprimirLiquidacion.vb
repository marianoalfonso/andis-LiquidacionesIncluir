Imports System.Data.SqlClient

Public Class frmEliminarLiquidacion

    Private Sub btnBuscarCuit_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarCuit.Click
        Try
            Dim sCuit As String
            Dim Conn As New SqlConnection("Data Source=mrburns;Initial Catalog=LIQUIDACIONES_PAMI;User ID=usrLiquidacionPami;Password=Cocolandia877")
            'Dim Conn As New SqlConnection("Data Source=MARIANO-VAIO;Initial Catalog=LIQUIDACIONES_PAMI;User ID=sa;Password=cerati123")
            Dim Cmd As New SqlCommand
            Dim Da As New SqlDataAdapter(Cmd)
            Dim Dt As New DataTable()
            sCuit = Limpiar_Cadena(Trim(mebCuit.Text), "-")
            Cmd.CommandText = "SP_LISTAR_LIQUIDACIONES_PRESTADOR"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@p_CUITPRESTADOR", sCuit)
            Conn.Open()
            Da.Fill(Dt)
            dgvLiquidaciones.DataSource = Dt
            Me.dgvLiquidaciones.Font = New System.Drawing.Font("Times New Roman", 10)
            dgvLiquidaciones.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvLiquidaciones.Columns(0).Width = 300
            dgvLiquidaciones.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            dgvLiquidaciones.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            dgvLiquidaciones.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        Catch ex As Exception
            MsgBox(Err.Description)

        End Try
    End Sub

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Me.Close()
        Me.Dispose()
        Me.DestroyHandle()
    End Sub

    Private Sub cmdEliminarLiquidacion_Click(sender As System.Object, e As System.EventArgs) Handles cmdEliminarLiquidacion.Click
        Dim Conn As New SqlConnection("Data Source=mrburns;Initial Catalog=LIQUIDACIONES_PAMI;User ID=usrLiquidacionPami;Password=Cocolandia877")
        'Dim Conn As New SqlConnection("Data Source=MARIANO-VAIO;Initial Catalog=LIQUIDACIONES_PAMI;User ID=sa;Password=cerati123")
        Dim Cmd As New SqlCommand
        Dim iNumLiq As Integer
        Try
            iNumLiq = dgvLiquidaciones.Rows(dgvLiquidaciones.CurrentRow.Index).Cells(1).Value
            Cmd.CommandText = "SP_ELIMINAR_LIQUIDACION_IMPORTES"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@p_NUMEROLIQUIDACION", iNumLiq)
            Conn.Open()
            Cmd.ExecuteNonQuery()
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
            btnBuscarCuit.PerformClick()
            MsgBox("Liquidacion eliminada", vbInformation)
        Catch ex As Exception
            If Err.Number = 91 Then
                Err.Clear()
            Else
                MsgBox("Error eliminando la autorizacion", vbCritical)
            End If
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Sub

    Private Sub frmEliminarLiquidacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 10
        Me.Left = 10
    End Sub
End Class