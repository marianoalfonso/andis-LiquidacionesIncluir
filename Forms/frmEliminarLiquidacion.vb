Imports System.Data.SqlClient

Public Class frmEliminarLiquidacion

    Dim sYear As String = ""        'año
    Dim sMonth As String = ""       'mes
    Dim sPeriodoConsulta As String = ""
    Dim sCodigoPrestador As Int32 = 0
    Dim sRazonSocial As String = ""
    Dim sCuit As String = ""
    Dim mcls_log As New mcls_log
    Dim mcls_security As New mcls_security
    Dim mcls_user As New mcls_user
    Dim frmProcessAuth As New frmProcessAuth

    Public Sub New()
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        setEnvironment()

        Try
            load_months()
            load_years()
            set_environment()
            chkPeriodo.Checked = False
            cmbMonthM.Enabled = False
            cmbYearM.Enabled = False
        Catch ex As Exception

        End Try

    End Sub

    Sub setEnvironment()
        Try
            Me.Top = 70
            Me.Left = 60
            Me.Text = "gestion de liquidaciones"
            cmdDetalle.Tag = "01.03.02.01"                  'ver detalle de liquidaciones
            cmdEliminarLiquidacion.Tag = "01.03.02.02"      'eliminar liquidación
            btReimprimir.Tag = "01.03.02.03"                'exportar liquidación
            mcls_log.usuario = sUsuario
            mcls_log.area = sArea
            mcls_log.proceso = Me.Tag
        Catch ex As Exception

        End Try
    End Sub

    Sub habilitar_formulario(state As Boolean)
        If state Then
            cmdDetalle.Enabled = True
            btReimprimir.Enabled = True
            'cmdEliminarLiquidacion.Enabled = True
        Else
            cmdDetalle.Enabled = False
            btReimprimir.Enabled = False
            'cmdEliminarLiquidacion.Enabled = False
        End If
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

    Private Sub set_environment()
        Try
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
        Catch ex As Exception

        End Try
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

    Function assign_parameters() As Boolean
        Dim flagSearchPeriodo As Boolean = False
        Dim flagSearch As Boolean = False
        Dim flagParametros As Int16 = 0
        Try
            'asigno periodo
            If chkPeriodo.Checked Then
                sPeriodoConsulta = sMonth + sYear
                flagParametros = flagParametros + 1
                flagSearchPeriodo = True
                flagSearch = True
            Else
                sPeriodoConsulta = ""
            End If
            'asigno codigo de prestador
            If chkCodigo.Checked Then
                If Not Integer.TryParse(Trim(tbxCodigo.Text), sCodigoPrestador) Then
                    sCodigoPrestador = 0
                End If
                flagParametros = flagParametros + 1
                flagSearch = True
            Else
                sCodigoPrestador = 0
            End If
            'asigno razon social
            If chkRazonSocial.Checked Then
                sRazonSocial = Trim(tbxRazonSocial.Text)
                flagParametros = flagParametros + 1
                flagSearch = True
            Else
                sRazonSocial = ""
            End If
            'asigno cuit
            If chkCuit.Checked Then
                mebCuit.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
                sCuit = Trim(mebCuit.Text)
                mebCuit.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
                flagParametros = flagParametros + 1
                flagSearch = True
            Else
                sCuit = ""
            End If

            If flagSearchPeriodo Then
                If flagParametros > 1 Then
                    Return flagSearch
                Else
                    MessageBox.Show("cuando selecciona el periodo debe seleccionar al menos otro parametro", "consulta liquidaciones", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Return False
                End If
            Else
                Return flagSearch
            End If
        Catch ex As Exception
            MsgBox("revise los parámetros de la consulta", vbCritical)
            Return False
        End Try
    End Function

    Private Sub frmEliminarLiquidacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Top = 60
        Me.Left = 10
        Me.mebCuit.Select()
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        habilitar_formulario(False)
    End Sub

    'eliminar liquidación
    Private Sub cmdEliminarLiquidacion_Click(sender As Object, e As EventArgs) Handles cmdEliminarLiquidacion.Click
        Dim mcls_liquidacion As New mcls_liquidacion
        Dim sLiquidacion = dgvLiquidaciones.Rows(dgvLiquidaciones.CurrentRow.Index).Cells(0).Value
        Dim sPeriodo = dgvLiquidaciones.Rows(dgvLiquidaciones.CurrentRow.Index).Cells(2).Value
        Dim sFactura = dgvLiquidaciones.Rows(dgvLiquidaciones.CurrentRow.Index).Cells(3).Value
        Dim usrValido As Boolean = False
        mcls_log.proceso = "01.03.02.02"
        Try
            Me.Cursor = Cursors.WaitCursor

            'codigo original para ser revisado por el tema de la seguridad
            If Not mcls_security.mfn_00001(cmdDetalle.Tag) Then
                Me.Cursor = Cursors.Default
                MessageBox.Show("módulo no autorizado")
                mcls_log.detalle = "intento de eliminar liquidación sin autorizacion (" & sLiquidacion & ")"
                mcls_log.log_event_ok()
                Exit Sub
            End If

            'codigo temporal hasta ver que pasa con la seguridad
            'If System.Environment.UserName <> "jmedina" Then
            '    Me.Cursor = Cursors.Default
            '    MessageBox.Show("módulo no autorizado")
            '    mcls_log.detalle = "intento de eliminar liquidación sin autorizacion (" & sLiquidacion & ")"
            '    mcls_log.log_event_ok()
            '    Exit Sub
            'End If

            'reemplazar por fomulario de validacion ya que el inputbox no acepta password char
            frmProcessAuth.ShowDialog()
            Dim sPassword As String = Trim(frmProcessAuth.txtPwd.Text)

            If scope = "local" Then
                usrValido = mcls_user.usrValidateLocal(sUsuario, sPassword)         'local authentication
            ElseIf scope = "ad" Then
                usrValido = mcls_user.isAuthenticated(sUsuario, sPassword)
            Else
                MessageBox.Show("error en el archivo de configuracion para el seteo de validación", "configuracion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End If

            'authentication error
            If Not usrValido Then
                Me.Cursor = Cursors.Default
                MessageBox.Show("autenticación incorrecta", "borrar liquidaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
                mcls_log.detalle = "intento de eliminar liquidación con password incorrecto (" & sLiquidacion & ")"
                mcls_log.log_event_ok()
                Exit Sub
            End If

            'authentication ok
            Me.Cursor = Cursors.WaitCursor
            If mcls_liquidacion.mfcn_delete(sLiquidacion) Then
                mcls_log.detalle = "liquidación eliminada (" & sLiquidacion & ")"
                mcls_log.log_event_ok()
                dgvLiquidaciones.Rows.Remove(dgvLiquidaciones.Rows(dgvLiquidaciones.CurrentRow.Index))
                Me.Cursor = Cursors.Default
                MessageBox.Show("liquidación " & sLiquidacion & " eliminada", "eliminar liquidación", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                mcls_log.detalle = "error eliminando liquidacion (" & sLiquidacion & ")"
                mcls_log.error_codigo = Err.Number
                mcls_log.error_descripcion = Err.Description
                mcls_log.log_event_error()
                Me.Cursor = Cursors.Default
                MessageBox.Show("error eliminando la liquidación " & sLiquidacion, "eliminar liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            mcls_log.detalle = "error eliminando liquidacion (" & sLiquidacion & ")"
            mcls_log.error_codigo = Err.Number
            mcls_log.error_descripcion = Err.Description
            mcls_log.log_event_error()
            Me.Cursor = Cursors.Default
            MessageBox.Show("error eliminando la liquidación", "eliminar liquidación", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'PARA REUSAR
    'funcion original de ELIMINACION DE LIQUIDACIONES
    'Private Sub cmdEliminarLiquidacion_Click(sender As System.Object, e As System.EventArgs) Handles cmdEliminarLiquidacion.Click
    '    Dim Conn As New SqlConnection(gsConnectionString)
    '    Dim Cmd As New SqlCommand
    '    Dim iNumLiq As Integer
    '    Dim sPassword As String

    '    Dim sClose As String
    '    Dim sCuit As String
    '    sCuit = Limpiar_Cadena(Trim(mebCuit.Text), "-")

    '    Dim sPeriodo As String
    '    Dim sFactura As String

    '    Dim cPrestador As New clsPrestador

    '    Try
    '        If Not mcls_security.mfn_00001(cmdEliminarLiquidacion.Tag) Then
    '            MessageBox.Show("módulo no autorizado")
    '            Exit Sub
    '        End If
    '        sPeriodo = dgvLiquidaciones.Rows(dgvLiquidaciones.CurrentRow.Index).Cells(2).Value
    '        sFactura = dgvLiquidaciones.Rows(dgvLiquidaciones.CurrentRow.Index).Cells(3).Value

    '        If Not gsStatus Then
    '            MsgBox("usuario no habilitado para eliminar liquidaciones", vbCritical)

    '            'log
    '            gsModulo = "liquidaciones"
    '            gsMensaje = "error.se intento eliminar la liquidacion para la factura: [" + sFactura
    '            gsCodigoError = 0
    '            gsDescripcionError = ""
    '            Registrar_Log(gsModulo, gsMensaje, gsCodigoError, gsDescripcionError)
    '            'log

    '            Exit Sub
    '        Else
    '            sPassword = InputBox("Eliminar liquidacion", "Ingrese Password:", "*", vbInformation)
    '            If sPassword <> "kitesurf2018" Then
    '                MsgBox("password incorrecta . . .", vbCritical)
    '                Exit Sub
    '            End If
    '            iNumLiq = dgvLiquidaciones.Rows(dgvLiquidaciones.CurrentRow.Index).Cells(1).Value

    '            Cmd.CommandText = "pa_ELIMINAR_LIQUIDACION_IMPORTES"
    '            Cmd.CommandType = CommandType.StoredProcedure
    '            Cmd.Connection = Conn
    '            Cmd.Parameters.AddWithValue("@p_NUMEROLIQUIDACION", iNumLiq)
    '            Conn.Open()
    '            Cmd.ExecuteNonQuery()
    '            Conn.Close()
    '            Conn.Dispose()
    '            Cmd.Dispose()
    '            cmdAceptarPeriodo.PerformClick()
    '            MsgBox("Liquidacion eliminada", vbInformation)

    '            If cPrestador.Chequear_Consolidacion_Factura(sCuit, sPeriodo, sFactura) Then
    '                If cPrestador.Chequear_Consolidacion_Existente(sCuit, sPeriodoConsolidacion1, sPeriodoConsolidacion2) Then
    '                    sClose = MsgBox("Recuerde que si va a enviar archivos de facturacion al servidor, " & Chr(13) &
    '                           "DEBE ELIMINAR LA CONSOLIDACION PARA ESTE PRESTADOR" & Chr(13) & Chr(13) &
    '                           "Desea revertir la consolidacion para este prestador?", vbYesNo)
    '                    If sClose = vbYes Then
    '                        'Revertir_Consolidacion()
    '                    End If
    '                End If
    '            End If

    '        End If
    '    Catch ex As Exception
    '        If Err.Number = 91 Then
    '            Err.Clear()
    '        Else
    '            MsgBox("Error eliminando la autorizacion", vbCritical)
    '        End If
    '    Finally
    '        Conn.Close()
    '        Conn.Dispose()
    '        Cmd.Dispose()
    '    End Try
    'End Sub



    'REIMPRIME LA LIQUIDACION SELECCIONADA
    Private Sub btReimprimir_Click(sender As System.Object, e As System.EventArgs) Handles btReimprimir.Click
        Dim sURL As String
        Dim iNumeroLiquidacion As Long
        Try
            'If Not mcls_security.mfn_00001(btReimprimir.Tag) Then
            '    MessageBox.Show("módulo no autorizado")
            '    Exit Sub
            'End If
            iNumeroLiquidacion = dgvLiquidaciones.Rows(dgvLiquidaciones.CurrentRow.Index).Cells(0).Value
            sURL = urlReport & iNumeroLiquidacion & "&p_NUMERO_LIQUIDACION= " & iNumeroLiquidacion
            Shell("C:\Program Files\Internet Explorer\iexplore.exe " & sURL, vbMaximizedFocus)

            sURL = urlReport_PV & iNumeroLiquidacion & "&p_NUMERO_LIQUIDACION= " & iNumeroLiquidacion
            Shell("C:\Program Files\Internet Explorer\iexplore.exe " & sURL, vbMaximizedFocus)

            ' '' '' ''VERIFICAR PORQUE GENERA ERROR (NO BORRAR)
            ' ''Dim sClose As Boolean
            ' ''sClose = bImprimir_Reporte(iNumeroLiquidacion, "C:\Users\22925061\Desktop\x\reporte.pdf")
            ' ''If Not sClose Then
            ' ''    MsgBox("error imprimiendo la liquidacion", vbCritical)
            ' ''End If
            ' '' '' ''VERIFICAR PORQUE GENERA ERROR (NO BORRAR)

        Catch ex As Exception
            MsgBox("error imprimiendo la liquidacion", vbCritical)
        End Try
    End Sub



    Function Totalizar_Liquidacion(Num_Liq As Integer) As Double
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Try
            If Num_Liq > 0 Then
                Cmd.CommandText = "pa_TOTALIZAR_LIQUIDACION"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Connection = Conn
                Cmd.Parameters.AddWithValue("@p_NUMERO_LIQUIDACION", Num_Liq)
                Cmd.Parameters.Add("@p_TOTALLIQUIDADO", SqlDbType.Money)
                Cmd.Parameters("@p_TOTALLIQUIDADO").Direction = ParameterDirection.Output
                Conn.Open()
                Cmd.ExecuteScalar()
                Dim output_TotalLiquidacion As Double = Cmd.Parameters("@p_TOTALLIQUIDADO").Value
                Conn.Close()
                Conn.Dispose()
                Cmd.Dispose()
                Return output_TotalLiquidacion
            Else
                Return 0
            End If
        Catch ex As Exception
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
            MsgBox("Error totalizando la liquidacion", vbCritical)
            Return 0
        End Try
    End Function

    Private Sub cmdAceptarPeriodo_Click(sender As Object, e As EventArgs) Handles cmdAceptarPeriodo.Click
        Try
            dgvLiquidaciones.DataSource = Nothing
            Application.DoEvents()
            If assign_parameters() Then
                Me.Cursor = Cursors.WaitCursor
                habilitar_formulario(True)
                Dim Conn As New SqlConnection(gsConnectionString)
                Dim Cmd As New SqlCommand
                Dim Da As New SqlDataAdapter(Cmd)
                Dim Dt As New DataTable()
                Cmd.CommandText = "mpa_00810"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Connection = Conn

                Cmd.Parameters.AddWithValue("@pmt1", Trim(sPeriodoConsulta))
                Cmd.Parameters.AddWithValue("@pmt2", Trim(sCodigoPrestador))
                Cmd.Parameters.AddWithValue("@pmt3", Trim(sRazonSocial))
                Cmd.Parameters.AddWithValue("@pmt4", Trim(sCuit))
                Cmd.Parameters.AddWithValue("@pmt5", Trim(sArea))
                Conn.Open()
                Da.Fill(Dt)
                If Dt.Rows.Count > 0 Then   'check for any row
                    dgvLiquidaciones.DataSource = Dt
                    Conn.Close()
                    mdtg_Format(dgvLiquidaciones, "Consolas", 9)
                    dgvLiquidaciones.Columns(0).Width = 70
                    dgvLiquidaciones.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvLiquidaciones.Columns(1).Width = 90
                    dgvLiquidaciones.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvLiquidaciones.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    dgvLiquidaciones.Columns(2).Width = 245
                    dgvLiquidaciones.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvLiquidaciones.Columns(3).Width = 100
                    dgvLiquidaciones.Columns(4).Width = 70
                    dgvLiquidaciones.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvLiquidaciones.Columns(5).Width = 110
                    dgvLiquidaciones.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvLiquidaciones.Columns(6).Width = 120
                    dgvLiquidaciones.Columns(6).DefaultCellStyle.Format = "c"
                    dgvLiquidaciones.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvLiquidaciones.Columns(7).Width = 120
                    dgvLiquidaciones.Columns(7).DefaultCellStyle.Format = "c"
                    dgvLiquidaciones.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    dgvLiquidaciones.Columns(8).Width = 120
                    dgvLiquidaciones.Columns(8).DefaultCellStyle.Format = "c"
                    dgvLiquidaciones.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                    Me.Cursor = Cursors.Default
                Else
                    habilitar_formulario(False)
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("su consulta no obtuvo resultados", "consulta de liquidaciones", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Private Sub cmdDetalle_Click(sender As Object, e As EventArgs) Handles cmdDetalle.Click
        'If Not mcls_security.mfn_00001(cmdDetalle.Tag) Then
        '    MessageBox.Show("módulo no autorizado")
        '    Exit Sub
        'End If
        Dim liq As Integer
        Dim frm03002 As New frm03002
        If Integer.TryParse(dgvLiquidaciones.CurrentRow.Cells(0).Value, liq) Then
            frm03002.l_numliq = liq
            frm03002.ShowDialog()
        Else
            MessageBox.Show("error al intentar ver el detalle de la liquidación")
        End If

    End Sub

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Me.Hide()
    End Sub


End Class