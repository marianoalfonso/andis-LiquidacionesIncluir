Imports System.Data.SqlClient

Public Class frm02002

    Dim sYear As String = ""        'año
    Dim sMonth As String = ""       'mes
    Dim sPeriodoConsulta As String = ""
    Dim sCodigoPrestador As Int32 = 0
    Dim sRazonSocial As String = ""
    Dim sCuit As String = ""
    Dim mcls_00006 As New mcls_00006
    Dim mcls_log As New mcls_log

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            'load_months()
            'load_years()
            set_environment()
            chkPeriodo.Checked = False
            cmbMonthM.Enabled = False
            cmbYearM.Enabled = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub set_environment()
        Try
            'log settings
            mcls_log.usuario = sUsuario
            mcls_log.area = sArea
            mcls_log.proceso = Me.Tag
            'security settings
            btnDetalleAutorizacion.Tag = "01.02.02.01"
            btnLiquidaciones.Tag = "01.02.02.02"
            btnBorrarAutorizacion.Tag = "01.02.02.03"
            btnExportar.Tag = "01.02.02.04"

            'periodo
            chkPeriodo.Checked = False
            cmbMonthM.Enabled = False
            cmbYearM.Enabled = False
            cmbMonthM.Visible = False
            cmbYearM.Visible = False
            'codigo
            chkCodigo.Checked = False
            tbxCodigo.Enabled = False
            tbxCodigo.Visible = False
            'cuit
            chkCuit.Checked = False
            mebCuit.Enabled = False
            mebCuit.Visible = False
            'razon social
            chkRazonSocial.Checked = False
            tbxRazonSocial.Enabled = False
            tbxRazonSocial.Visible = False

            'Me.Top = 70
            'Me.Left = 20
            Me.Text = "autorizaciones mensuales"
            Me.StartPosition = FormStartPosition.CenterScreen
            load_months()
            load_years()
            habilitar_formulario(False)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frm02002_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.Top = 70
        'Me.Left = 20
        'Me.Text = "autorizaciones mensuales"
        'Me.StartPosition = FormStartPosition.CenterScreen
        'habilitar_formulario(False)
    End Sub

    'carga los meses tomados de la tabla liq_MESES
    Sub load_months()
        Dim stringConexion As New SqlConnection(gsConnectionString)
        Try
            Dim cmd As New SqlCommand("mpa_MONTHS_LOAD", stringConexion)
            cmd.CommandType = CommandType.StoredProcedure
            Dim tabla As New DataTable
            Dim dataAdapter As New SqlDataAdapter(cmd)
            dataAdapter.Fill(tabla)
            cmbMonthM.ValueMember = "liq_MES_ID"
            cmbMonthM.DisplayMember = "liq_MES_NOMBRE"
            cmbMonthM.DataSource = tabla
        Catch ex As Exception
            MsgBox(Err.Description, vbCritical)
        Finally
            stringConexion.Dispose()
        End Try
    End Sub

    'asignamos el mes seleccionado a la variable sMonth
    Private Sub cmbMonthM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbMonthM.SelectedIndexChanged
        sMonth = cmbMonthM.SelectedValue
        sMonth = IIf(Len(sMonth) = 1, sMonth.PadLeft(2, "0"c), sMonth)
    End Sub

    'carga los años en base a parametros preestablecidos en liq_PARAMETROS
    'https://stackoverflow.com/questions/38206678/set-displaymember-and-valuemember-on-combobox-without-datasource
    Sub load_years()
        Dim resultado As Int16 = CInt(parameterGet(1))
        Dim anioActual As Int16 = Year(DateTime.Now)

        While resultado >= 0
            cmbYearM.Items.Add(anioActual - resultado)
            resultado = resultado - 1
        End While
        cmbYearM.SelectedIndex = cmbYearM.Items.Count - 1
    End Sub

    'asignamos el mes seleccionado a la variable sYear
    Private Sub cmbYearM_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbYearM.SelectedIndexChanged
        sYear = cmbYearM.Text
    End Sub



    Sub habilitar_formulario(status As Boolean)
        If status Then
            btnDetalleAutorizacion.Enabled = True
            btnLiquidaciones.Enabled = True
            'btnBorrarAutorizacion.Enabled = True
            btnExportar.Enabled = True
        Else
            btnDetalleAutorizacion.Enabled = False
            btnLiquidaciones.Enabled = False
            btnBorrarAutorizacion.Enabled = False
            btnExportar.Enabled = False
        End If

    End Sub

    Private Sub chkPeriodo_CheckedChanged(sender As Object, e As EventArgs) Handles chkPeriodo.CheckedChanged
        If chkPeriodo.Checked Then
            cmbMonthM.Enabled = True
            cmbYearM.Enabled = True
            cmbMonthM.Visible = True
            cmbYearM.Visible = True
        Else
            cmbMonthM.Enabled = False
            cmbYearM.Enabled = False
            cmbMonthM.Visible = False
            cmbYearM.Visible = False
        End If
    End Sub

    Private Sub chkCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles chkCodigo.CheckedChanged
        If chkCodigo.Checked Then
            tbxCodigo.Enabled = True
            tbxCodigo.Visible = True
            tbxCodigo.Text = ""
        Else
            tbxCodigo.Enabled = False
            tbxCodigo.Visible = False
        End If
    End Sub

    Private Sub chkCuit_CheckedChanged(sender As Object, e As EventArgs) Handles chkCuit.CheckedChanged
        If chkCuit.Checked Then
            mebCuit.Enabled = True
            mebCuit.Visible = True
            mebCuit.Text = ""
        Else
            mebCuit.Enabled = False
            mebCuit.Visible = False
        End If
    End Sub

    Private Sub chkRazonSocial_CheckedChanged(sender As Object, e As EventArgs) Handles chkRazonSocial.CheckedChanged
        If chkRazonSocial.Checked Then
            tbxRazonSocial.Enabled = True
            tbxRazonSocial.Visible = True
            tbxRazonSocial.Text = ""
        Else
            tbxRazonSocial.Enabled = False
            tbxRazonSocial.Visible = False
        End If
    End Sub

    Private Sub cmdAceptarPeriodo_Click(sender As Object, e As EventArgs) Handles cmdAceptarPeriodo.Click
        Try
            dtgAutorizaciones.DataSource = Nothing
            dtvDetalleAutorizacion.DataSource = Nothing
            Application.DoEvents()
            If assign_parameters() Then
                Me.Cursor = Cursors.WaitCursor
                Dim Conn As New SqlConnection(gsConnectionString)
                Dim Cmd As New SqlCommand("mpa_00800", Conn)
                Dim Da As New SqlDataAdapter(Cmd)
                Dim Dt As New DataTable()
                'Cmd.CommandText = "mpa_00800"
                Cmd.CommandType = CommandType.StoredProcedure
                'Cmd.Connection = Conn
                Cmd.Parameters.AddWithValue("@pmt1", Trim(sPeriodoConsulta))
                Cmd.Parameters.AddWithValue("@pmt2", Trim(sCodigoPrestador))
                Cmd.Parameters.AddWithValue("@pmt3", Trim(sRazonSocial))
                Cmd.Parameters.AddWithValue("@pmt4", Trim(sCuit))
                Cmd.Parameters.AddWithValue("@pmt5", Trim(sArea))
                Conn.Open()
                Da.Fill(Dt)
                If Dt.Rows.Count > 0 Then   'check for any row
                    habilitar_formulario(True)
                    dtgAutorizaciones.DataSource = Dt
                    mdtg_Format(dtgAutorizaciones, "consolas", 9)
                    dtgAutorizaciones.Columns(0).Width = 70
                    dtgAutorizaciones.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dtgAutorizaciones.Columns(1).Width = 100
                    dtgAutorizaciones.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dtgAutorizaciones.Columns(2).Width = 260
                    dtgAutorizaciones.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    dtgAutorizaciones.Columns(3).Visible = False
                    dtgAutorizaciones.Columns(3).Width = 70
                    dtgAutorizaciones.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    dtgAutorizaciones.Columns(4).Width = 70
                    dtgAutorizaciones.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

                    dtgAutorizaciones.Columns(5).Width = 150
                    dtgAutorizaciones.Columns(5).DefaultCellStyle.Format = "c"
                    dtgAutorizaciones.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.Cursor = Cursors.Default
                Else
                    habilitar_formulario(False)
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("su consulta no obtuvo resultados", "consulta de autorizaciones")
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(Err.Description)
        End Try

    End Sub

    'asigno valores de busqueda y habilito la busqueda
    Function assign_parameters() As Boolean
        Dim flagSearch As Boolean = False
        Try
            'asigno periodo
            If chkPeriodo.Checked Then
                sPeriodoConsulta = sMonth + sYear
                flagSearch = True
            Else
                sPeriodoConsulta = ""
            End If
            'asigno codigo de prestador
            If chkCodigo.Checked Then
                If Not Integer.TryParse(Trim(tbxCodigo.Text), sCodigoPrestador) Then
                    sCodigoPrestador = 0
                End If
                flagSearch = True
            Else
                    sCodigoPrestador = 0
            End If
            'asigno razon social
            If chkRazonSocial.Checked Then
                sRazonSocial = Trim(tbxRazonSocial.Text)
                flagSearch = True
            Else
                sRazonSocial = ""
            End If
            'asigno cuit
            If chkCuit.Checked Then
                mebCuit.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
                sCuit = Trim(mebCuit.Text)
                mebCuit.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
                flagSearch = True
            Else
                sCuit = ""
            End If
            Return flagSearch
        Catch ex As Exception
            MsgBox("revise los parámetros de la consulta", vbCritical)
            Return False
        End Try
    End Function

    Private Sub btnDetalleAutorizacion_Click(sender As Object, e As EventArgs) Handles btnDetalleAutorizacion.Click
        Try
            'If Not mcls_00006.mfn_00001(btnDetalleAutorizacion.Tag) Then
            '    MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            Me.Cursor = Cursors.WaitCursor
            sPeriodoConsulta = dtgAutorizaciones.CurrentRow.Cells(3).Value
            sCodigoPrestador = dtgAutorizaciones.CurrentRow.Cells(0).Value
            sCuit = dtgAutorizaciones.CurrentRow.Cells(1).Value

            Dim Conn As New SqlConnection(gsConnectionString)
            Dim Cmd As New SqlCommand("mpa_00801", Conn)
            Dim Da As New SqlDataAdapter(Cmd)
            Dim Dt As New DataTable()
            'Cmd.CommandText = "mpa_00801"
            Cmd.CommandType = CommandType.StoredProcedure
            'Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@pmt1", Trim(sPeriodoConsulta))
            Cmd.Parameters.AddWithValue("@pmt2", Trim(sCodigoPrestador))
            Cmd.Parameters.AddWithValue("@pmt3", Trim(sArea))
            Conn.Open()
            Da.Fill(Dt)
            dtvDetalleAutorizacion.DataSource = Dt
            Conn.Close()
            If Dt.Rows.Count > 0 Then
                mdtg_Format(dtvDetalleAutorizacion, "Consolas", 9)
                dtvDetalleAutorizacion.Columns(0).Width = 80
                dtvDetalleAutorizacion.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dtvDetalleAutorizacion.Columns(1).Width = 190
                dtvDetalleAutorizacion.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                dtvDetalleAutorizacion.Columns(2).Width = 90
                dtvDetalleAutorizacion.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dtvDetalleAutorizacion.Columns(3).Width = 70
                dtvDetalleAutorizacion.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtvDetalleAutorizacion.Columns(4).Width = 220
                dtvDetalleAutorizacion.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                dtvDetalleAutorizacion.Columns(5).Width = 70
                dtvDetalleAutorizacion.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtvDetalleAutorizacion.Columns(6).Width = 90
                dtvDetalleAutorizacion.Columns(6).DefaultCellStyle.Format = "c"
                dtvDetalleAutorizacion.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dtvDetalleAutorizacion.Columns(7).Width = 90
                dtvDetalleAutorizacion.Columns(7).DefaultCellStyle.Format = "c"
                dtvDetalleAutorizacion.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                'DetalleLiquidacionesAsociadas()

                Me.Cursor = Cursors.Default
            Else
                Me.Cursor = Cursors.Default
                MessageBox.Show("su consulta no obtuvo resultados", "detalle de autorizacion")
            End If
        Catch ex As Exception
            mcls_log.detalle = "error mostrando detalle de autorizacion (Sub btnDetalleAutorizacion_Click)"
            mcls_log.error_codigo = Err.Number
            mcls_log.error_descripcion = Err.Description
            mcls_log.log_event_error()
            Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show("error mostrando detalle de autorizacion", "autorizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBorrarAutorizacion_Click(sender As Object, e As EventArgs) Handles btnBorrarAutorizacion.Click
        Dim n_aut As New cls_00001
        Dim lPeriodo As String = dtgAutorizaciones.CurrentRow.Cells(3).Value
        Dim lCuit As String = dtgAutorizaciones.CurrentRow.Cells(1).Value
        mcls_log.proceso = btnBorrarAutorizacion.Tag
        Try
            If Not mcls_00006.mfn_00001(btnBorrarAutorizacion.Tag) Then
                MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            'n_aut.pmt1 = sPeriodoConsulta
            'n_aut.pmt2 = sCuit
            n_aut.pmt1 = lPeriodo
            n_aut.pmt2 = lCuit
            Dim state As Boolean = n_aut.mfn_00001
            If Not state Then
                MessageBox.Show("no puede eliminarse una autorizacion con liquidaciones asociadas", "eliminar autorizaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else

                'write procedure to erase autorizacion

                mcls_log.detalle = "autorizacion eliminada ()"
                mcls_log.log_event_ok()
                MessageBox.Show("autorizacion eliminada", "autorizaciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            mcls_log.detalle = "error borrando autorizacion (Sub btnBorrarAutorizacion_Click)"
            mcls_log.error_codigo = Err.Number
            mcls_log.error_descripcion = Err.Description
            mcls_log.log_event_error()
            Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show("error borrando autorizacion", "autorizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnLiquidaciones_Click(sender As Object, e As EventArgs) Handles btnLiquidaciones.Click
        Try
            'If Not mcls_00006.mfn_00001(btnLiquidaciones.Tag) Then
            '    MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            '    Exit Sub
            'End If
            Me.Cursor = Cursors.WaitCursor

            'DetalleLiquidacionesAsociadas()

            Dim frm03003 As New frm03003
            frm03003.l_periodo = dtgAutorizaciones.CurrentRow.Cells(3).Value
            frm03003.l_cuit = dtgAutorizaciones.CurrentRow.Cells(1).Value
            frm03003.l_area = sArea
            frm03003.ShowDialog()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            mcls_log.detalle = "error mostrando liquidaciones asociadas (Sub btnLiquidaciones_Click)"
            mcls_log.error_codigo = Err.Number
            mcls_log.error_descripcion = Err.Description
            mcls_log.log_event_error()
            Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show("error mostrando liquidaciones asociadas", "autorizaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Sub DetalleLiquidacionesAsociadas()
        Dim frm03003 As New frm03003
        frm03003.l_periodo = dtgAutorizaciones.CurrentRow.Cells(3).Value
        frm03003.l_cuit = dtgAutorizaciones.CurrentRow.Cells(1).Value
        frm03003.l_area = sArea
        frm03003.ShowDialog()
        'Dim objLiq As New cls_00001
        'Try
        '    objLiq.pmt1 = sPeriodoConsulta
        '    objLiq.pmt2 = sCuit
        '    objLiq.pmt3 = sArea
        '    dgvDetalleLiquidaciones.DataSource = objLiq.mfn_00002
        '    mdtg_Format(dgvDetalleLiquidaciones, "Verdana", 9)
        '    dgvDetalleLiquidaciones.Columns(1).Width = 200
        '    dgvDetalleLiquidaciones.Columns(4).DefaultCellStyle.Format = "c"
        '    dgvDetalleLiquidaciones.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    dgvDetalleLiquidaciones.Columns(5).DefaultCellStyle.Format = "c"
        '    dgvDetalleLiquidaciones.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        '    dgvDetalleLiquidaciones.Columns(6).DefaultCellStyle.Format = "c"
        '    dgvDetalleLiquidaciones.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Hide()
    End Sub

    Private Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
        If Not mcls_00006.mfn_00001(btnExportar.Tag) Then
            MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        'exportar a reporte
    End Sub

    Private Sub btnBorrarPeriodo_Click(sender As Object, e As EventArgs) Handles btnBorrarPeriodo.Click

    End Sub
End Class