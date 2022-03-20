Imports System.Data.SqlClient

Public Class frmSimulacionLiquidacion
    Public localArea As Int16   'RECIBO SAREA global que es sByte y me da problemas en los stored procedures
    Public simCuit As String
    Public simPeriodo As String
    Public simSucursal As String
    Public simFactura As String
    Public simTotalFacturadoFisico As Decimal
    Public simTotalFacturadoElectronico As Decimal
    Public simErrorSuma As Decimal

    Private Sub frmSimulacionLiquidacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim cLiquidacion As New clsLiquidacion
        Me.Top = 40
        Me.Left = 40
        Me.Text = "previsualizción de liquidación"
        lblPeriodoSimulado.Text = Formatear_Periodo(simPeriodo)
        lblCuitPrestador.Text = simCuit
        lblFacturaSimulada.Text = simFactura
        If simTotalFacturadoFisico > 0 Then
            lblTotalFacturaFisica.Text = FormatCurrency(simTotalFacturadoFisico, 2)
        Else
            lblTotalFacturaFisica.Text = "sin datos"
        End If
        Call Simular_Liquidacion(simCuit, simPeriodo, simFactura, simSucursal)
    End Sub


    'Sub Simular_Liquidacion(ByVal sArea As SByte, ByVal sCuit As String, sPeriodo As String, ByVal sFactura As String, ByVal sSucursal As String)
    Sub Simular_Liquidacion(ByVal sCuit As String, sPeriodo As String, ByVal sFactura As String, ByVal sSucursal As String)
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand("pa_SIMULAR_LIQUIDACION_V4", Conn)
        Cmd.CommandTimeout = 120
        Dim Da As New SqlDataAdapter(Cmd)
        Dim Dt As New DataTable()
        Dim iContador As Integer
        'Dim sSucursal As String
        Dim dTotalAutorizado As Double = 0
        Dim dTotalFacturado As Double = 0
        Dim dTotalDebitado As Double = 0

        Try
            'Cmd.CommandText = "pa_SIMULAR_LIQUIDACION_V4"
            Cmd.CommandType = CommandType.StoredProcedure
            'Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@sAREA", localArea)
            Cmd.Parameters.AddWithValue("@CUIT", Trim(sCuit))
            Cmd.Parameters.AddWithValue("@PERIODO", Trim(sPeriodo))
            Cmd.Parameters.AddWithValue("@NUMERO_FACTURA", Trim(sFactura))

            Conn.Open()
            Da.Fill(Dt)
            If Dt.Rows.Count() > 0 Then
                dgvLiquidacion.DataSource = Dt
                'dgvLiquidacion.Font = New System.Drawing.Font("Times New Roman", 8)
                mdtg_Format(dgvLiquidacion, "consolas", 9)
                dgvLiquidacion.Columns(0).Visible = False
                'sNumeroLiquidacion = DataGridView1.Rows(0).Cells(0).Value
                'lblNumeroLiquidacion.Text = Str(sNumeroLiquidacion) + "/" + sPeriodo.Substring(4, 2)
                '          lblNumeroLiquidacion.Text = Str(sNumeroLiquidacion) + "/12"
                For iContador = 8 To 14
                    dgvLiquidacion.Columns(iContador).Visible = False
                Next
                'ALINEAMOS AL CENTRO LAS CABECERAS
                dgvLiquidacion.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvLiquidacion.Columns(1).HeaderText = "Beneficio"
                dgvLiquidacion.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                dgvLiquidacion.Columns(2).Width = 170
                dgvLiquidacion.Columns(2).HeaderText = "Nombre"
                dgvLiquidacion.Columns(3).Width = 80
                dgvLiquidacion.Columns(3).HeaderText = "Tipo"
                dgvLiquidacion.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
                dgvLiquidacion.Columns(4).Width = 300
                dgvLiquidacion.Columns(4).HeaderText = "Detalle Prestacion"
                dgvLiquidacion.Columns(5).Width = 80
                dgvLiquidacion.Columns(5).HeaderText = "Imp. Facturado"
                dgvLiquidacion.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'dgvLiquidacion.Columns(5).DefaultCellStyle.Format = "##,##0.00"
                dgvLiquidacion.Columns(5).DefaultCellStyle.Format = "c"
                dgvLiquidacion.Columns(6).Width = 80
                dgvLiquidacion.Columns(6).HeaderText = "Imp. Autorizado"
                dgvLiquidacion.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'dgvLiquidacion.Columns(6).DefaultCellStyle.Format = "##,##0.00"
                dgvLiquidacion.Columns(6).DefaultCellStyle.Format = "c"
                dgvLiquidacion.Columns(7).HeaderText = "Saldo"
                dgvLiquidacion.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'dgvLiquidacion.Columns(7).DefaultCellStyle.Format = "##,##0.00"
                dgvLiquidacion.Columns(7).DefaultCellStyle.Format = "c"
                'dgvLiquidacion.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)
                Colorear_Simulacion(dgvLiquidacion)
            End If


        Catch ex As Exception
            MsgBox("Error simulando la liquidacion" & Chr(13) &
                   "Informe al administrador del sistema", vbCritical)
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
            Cursor = System.Windows.Forms.Cursors.Default
            cmdCerrarFormulario.Focus()
        End Try
    End Sub

    'colorea el grid de acuerdo al estado de los montos
    Sub Colorear_Simulacion(grid As DataGridView)
        Dim totalFacturado As Decimal = 0
        Dim totalAutorizado As Decimal = 0
        Dim totalDebitado As Decimal = 0
        Dim iValorAuxiliar As Double
        For Each row As DataGridViewRow In grid.Rows
            totalFacturado = totalFacturado + row.Cells(5).Value
            totalAutorizado = totalAutorizado + row.Cells(6).Value
            totalDebitado = totalDebitado + row.Cells(7).Value
            iValorAuxiliar = row.Cells(7).Value
            If iValorAuxiliar < 0 Then
                'row.Cells(7).Style.BackColor = Color.Red
                row.DefaultCellStyle.BackColor = Color.Orange
                row.DefaultCellStyle.ForeColor = Color.Black
            ElseIf iValorAuxiliar > 0 Then
                'row.Cells(7).Style.BackColor = Color.GreenYellow
                row.DefaultCellStyle.BackColor = Color.GreenYellow
                row.DefaultCellStyle.ForeColor = Color.Black
            End If
        Next
        lblTotalFacturado.Text = FormatCurrency(totalFacturado, 2)
        lblTotalAutorizado.Text = FormatCurrency(totalAutorizado, 2)
        lblTotalDebitado.Text = FormatCurrency(totalDebitado, 2)
        If simErrorSuma = -1 Then
            lblErrorSuma.Text = "sin datos"
        Else
            lblErrorSuma.Text = FormatCurrency(simErrorSuma, 2)
        End If
    End Sub

    Private Sub cmdCerrarFormulario_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrarFormulario.Click
        Me.Close()
    End Sub


    Private Sub dgvLiquidacion_Sorted(sender As Object, e As System.EventArgs) Handles dgvLiquidacion.Sorted
        Colorear_Simulacion(dgvLiquidacion)
    End Sub

End Class