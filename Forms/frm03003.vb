Public Class frm03003
    Public l_periodo As String
    Public l_cuit As String
    Public l_area As Int16
    Dim c_liq As New clsLiquidacion
    Dim mcls_00006 As New mcls_00006

    Private Sub frm03003_Load(sender As Object, e As EventArgs) Handles Me.Load
        btnDetalle.Tag = "01.03.02.01"
        Me.Top = 250
        Me.Left = 300
        Me.Text = "liquidaciones asociadas a la autorizacion seleccionada"
        Dim dt As DataTable
        Try
            dtvLiquidacionesAsociadas.DataSource = Nothing
            dt = c_liq.liquidacionesasociadas(l_periodo, l_cuit, l_area)
            If dt.Rows.Count > 0 Then
                dtvLiquidacionesAsociadas.DataSource = dt
                mdtg_Format(dtvLiquidacionesAsociadas, "Consolas", 9)
                dtvLiquidacionesAsociadas.Columns(0).Width = 70
                dtvLiquidacionesAsociadas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dtvLiquidacionesAsociadas.Columns(1).Width = 110
                dtvLiquidacionesAsociadas.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dtvLiquidacionesAsociadas.Columns(2).Width = 120
                dtvLiquidacionesAsociadas.Columns(2).DefaultCellStyle.Format = "c"
                dtvLiquidacionesAsociadas.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtvLiquidacionesAsociadas.Columns(3).Width = 120
                dtvLiquidacionesAsociadas.Columns(3).DefaultCellStyle.Format = "c"
                dtvLiquidacionesAsociadas.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtvLiquidacionesAsociadas.Columns(4).Width = 120
                dtvLiquidacionesAsociadas.Columns(4).DefaultCellStyle.Format = "c"
                dtvLiquidacionesAsociadas.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            Else
                MessageBox.Show("no existen liquidaciones asociadas")
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("error mostrando liquidaciones asociadas")
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Hide()
    End Sub

    Private Sub btnDetalle_Click(sender As Object, e As EventArgs) Handles btnDetalle.Click
        If Not mcls_00006.mfn_00001(btnDetalle.Tag) Then
            MessageBox.Show("módulo no autorizado")
            Exit Sub
        End If
        Dim liq As Integer
        Dim frm03002 As New frm03002
        If Integer.TryParse(dtvLiquidacionesAsociadas.CurrentRow.Cells(0).Value, liq) Then
            frm03002.l_numliq = liq
            frm03002.ShowDialog()
        Else
            MessageBox.Show("error al intentar ver el detalle de la liquidación")
        End If
    End Sub
End Class