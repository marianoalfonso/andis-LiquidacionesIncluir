Imports isl64.isl64.isl64_validate
Imports System.Data.SqlClient
Imports System.Globalization


Public Class frmLiquidacion

    Dim mLog As New mcls_log_liquidaciones

    Dim log As New clsLog
    Dim sYear As String = ""        'año
    Dim sMonth As String = ""       'mes
    'Dim sPeriodo As String = ""     'mes + año consolidado    SE CONFIGURO GLOBAL
    Dim sCuit As String = ""

    'Private sArea As String
    Private sNumeroLiquidacion As String
    Private sTotalFactura As Double
    Private sTotalFacturado As Double

    'VARIABLES PARA LA IMPRESION
    Private iNumLiq As Integer
    Private iNumeroLiquidacion As String
    Private iCuit As String
    Private iRazonSocial As String

    'Private iPeriodo As String

    Private iTipoFactura As String
    Private iNumeroFactura As String
    Private iModulo As String
    Private iImporteFacturado As Double
    Private iNumeroDebito As String
    Private iImporteDebito As Double
    Private iNumeroBafc As String
    Private iImporteBafc As Double
    Public iImporteLiquidado As Double
    Private iLeyendaImporteLiquidado As String
    Private iLiquidadoAlFondo As Double
    Private iObservaciones As String
    Private iFechaLiquidacion As String
    Private iExpediente As String
    Private iReferencia As String
    Private iUsuario As String

    Private decImporteFacturadoElectronico As Decimal = 0     'almacena el importe facturado en forma electronica
    Private decImporteFacturadoFisico As Decimal = 0          'almacena el importe facturado en la factura papel

    ''VARIABLES PARA CONSOLIDACION
    'Dim bConsolidacionEnCurso As Boolean = False
    'Dim sFacturaPeriodoA As String
    'Dim sFacturaPeriodoB As String
    'Dim TotalFacturadoConsolidado As Double

    Dim clsLiqui_1 As New clsLiquidacion    'REEMPLAZO PARCIAL DE FUNCIONES POR UNA CLASE

    'EMPROLIJAMIENTO DE USO DE VARIABLES
    Dim mPeriodo As String = Nothing
    Dim mCuit As String = Nothing
    Dim mNumeroFactura As String = Nothing
    Dim sSucursal As String = Nothing

    'CONTROL DE ERRORES EN FUNCIONES
    Dim bERROR As Boolean = False

    Dim dtFacturas As New DataTable
    Dim mcls_00006 As New mcls_00006
    Dim mcls_log As New mcls_log



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-AR")
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = "."

        ' Add any initialization after the InitializeComponent() call.
        Try
            setSecurityEnvironment()
            load_months()
            load_years()
            load_comprobantes()


        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmLiquidacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call Configurar_Formulario()    'deprecated
        Call configForm()
        Call enableForm(0)
        'Call resizeForm(0)
    End Sub

    Sub configForm()
        Try
            'Me.Top = 60
            'Me.Left = 20
            Me.Width = 1004
            Me.Height = 630
            bERROR = False
        Catch ex As Exception

        End Try
    End Sub

    Sub Configurar_Formulario()
        Try
            'Me.Top = 60
            'Me.Left = 20
            Me.Width = 1200
            Me.Height = 672
            bERROR = False
            'bConsolidacionEnCurso = False

        Catch ex As Exception

        End Try
    End Sub

    'seteamos las variables que determinan los codigos de modulos y procesos
    Private Sub setSecurityEnvironment()

        cmdSimularLiquidacion.Tag = "01.03.01.01"
        Button2.Tag = "01.03.01.02"
        gsFormulario = "frmLiquidacion"
        sModulo = 2
        sProceso = Nothing
        log.detalle = ""
        log.error_codigo = 0
        log.error_descripcion = ""
    End Sub

    'seteamos en blanco las variables que determinan los codigos de modulos y procesos
    Private Sub cleanSecurityEnvironment()
        sModulo = 0
        sProceso = 0
    End Sub

    Private Sub enableSecurityOptions()
        'Try
        '    ImportarArchivosDiscapacidadToolStripMenuItem.Enabled = False
        '    ConfigurarConsolidacionesToolStripMenuItem.Enabled = False
        'Catch ex As Exception

        'End Try
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

    'carga los tipos de comprobantes de la tabla liq_COMPROBANTES
    Sub load_comprobantes()
        Dim stringConexion As New SqlConnection(gsConnectionString)
        Try
            Dim cmd As New SqlCommand("mpa_COMPROBANTES_LOAD", stringConexion)
            cmd.CommandType = CommandType.StoredProcedure
            Dim tabla As New DataTable
            Dim dataAdapter As New SqlDataAdapter(cmd)
            dataAdapter.Fill(tabla)
            cmbTipoComprobante.ValueMember = "liq_COMPROBANTE_ID"
            cmbTipoComprobante.DisplayMember = "liq_COMPROBANTE_NOMBRE"
            cmbTipoComprobante.DataSource = tabla
        Catch ex As Exception
            MsgBox(Err.Description, vbCritical)
        Finally
            stringConexion.Dispose()
        End Try
    End Sub

    Sub reiniciar_controles()
        lblCuit.Visible = False
        mebCuit.Text = ""
        mebCuit.Visible = False
        btnBuscarCuit.Visible = False
        lblSeleccioneFactura.Visible = False
        cmbFacturas.DataSource = Nothing
        cmbFacturas.Visible = False
        lblTipoComprobante.Visible = False
        cmbTipoComprobante.Visible = False
        lblMontoLiquidado.Visible = False
        mebMontoFactura.Text = ""
        mebMontoFactura.Visible = False
        lblExpediente.Visible = False
        mebExpediente.Text = ""
        mebExpediente.Visible = False
        cmdSimularLiquidacion.Visible = False
        Button2.Visible = False
        cmdCancelar.Visible = False
        lblNumeroLiquidacion.Text = ". . ."
        lblNumeroDebito.Text = ". . ."
        lblImporteFacturadoElectronico.Text = ". . ."
        lblImporteFacturado.Text = ". . ."
        lblDiferenciaFActurado.Text = ". . ."
        lblImporteLiquidado.Text = ". . ."
        lblImporteDebitado.Text = ". . ."
    End Sub

    'BUSCA UNA AUTORIZACION VALIDA PARA EL PERIODO SELECCIONADO
    Private Sub cmdAceptarPeriodo_Click_1(sender As System.Object, e As System.EventArgs) Handles cmdAceptarPeriodo.Click
        Dim cls_00001 As New cls_00001
        Try
            reiniciar_controles()
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            sPeriodo = sMonth & sYear
            If cls_00001.mfn_00002(sPeriodo) Then
                lblAutorizacionExistente.ForeColor = Color.Green
                lblAutorizacionExistente.Text = "autorizacion valida . . ."
                'resizeForm(1)
                enableForm(12)
            Else
                lblAutorizacionExistente.Text = ""
                MessageBox.Show("no existe autorizacion para el período seleccionado . . .")
            End If
        Catch ex As Exception
            MsgBox("error validando autorizacion para el período", vbCritical)
        Finally
            Cursor = System.Windows.Forms.Cursors.Default
        End Try

        'Dim clsValidate As New clsValidate
        'Dim validate As Integer
        'Cursor = System.Windows.Forms.Cursors.WaitCursor
        'enableForm(11)
        'Try
        '    sPeriodo = sMonth & sYear       'asignamos periodo
        '    validate = clsValidate.validarAutorizacion(gsConnectionString, sPeriodo, sArea)

        '    Select Case validate
        '        Case 1
        '            'cmbFacturas.Items.Clear()
        '            lblAutorizacionExistente.ForeColor = Color.Green
        '            lblAutorizacionExistente.Text = "autorizacion valida . . ."
        '            resizeForm(1)
        '            enableForm(12)
        '            'mebCuit.Focus()                 'ponemos foco en el boton cuit
        '        Case 0
        '            'lblAutorizacionExistente.ForeColor = Color.Red
        '            'lblAutorizacionExistente.Text = "no existe autorizacion . . ."
        '            MsgBox("no existe autorizacion para el período seleccionado . . .", vbInformation)
        '        Case -1
        '            MsgBox("error validando autorizacion para el período . . .", vbCritical)
        '    End Select
        'Catch ex As Exception
        '    MsgBox("error validando autorizacion para el período", vbCritical)
        'Finally
        '    Cursor = System.Windows.Forms.Cursors.Default
        'End Try
    End Sub


    'Public Property Area() As String
    '    Get
    '        Return sArea
    '    End Get
    '    Set(value As String)
    '        If value <> "" Then
    '            sArea = value
    '        End If
    '    End Set
    'End Property


    Sub Reiniciar_Formulario()
        Try
            'Button2.Visible = False
            mebExpediente.Clear()
            mebExpediente.Visible = False
            lblExpediente.Visible = False
            mebMontoFactura.Clear()
            lblMontoLiquidado.Visible = False
            'btnCopiarMonto.Visible = False
            mebMontoFactura.Visible = False
            cmbTipoComprobante.Visible = False
            lblTipoComprobante.Visible = False
            cmbFacturas.Items.Clear()
            lblSeleccioneFactura.Visible = False
            cmdSimularLiquidacion.Visible = False
            mebCuit.Clear()
            lblCuit.Visible = False
            'cmbMonth.SelectedIndex = -1
            'cmbYear.SelectedIndex = -1
            mebCuit.Visible = False
            btnBuscarCuit.Visible = False

            'lblImporteLiquidado.Visible = False
            'Label6.Visible = False
            'lblImporteDebitado.Visible = False
            'Label4.Visible = False
            'lblImporteFacturado.Visible = False
            'Label5.Visible = False
            'lblNumeroDebito.Visible = False
            'Label1.Visible = False
            'lblNumeroLiquidacion.Visible = False
            'Label7.Visible = False
            'gbxCuit.Text = ""
        Catch ex As Exception
            MsgBox("error reiniciando el formulario . . .", vbCritical)
        Finally

        End Try
    End Sub

    Function Validar_Formulario() As Boolean
        If cmbFacturas.Text = "" Then
            MsgBox("Seleccione una factura para liquidar", vbCritical)
            Return False
        End If
        If mebMontoFactura.Text = "" Then
            MsgBox("Ingrese el monto de la factura a liquidar", vbCritical)
            Return False
        End If
        If Not IsNumeric(mebMontoFactura.Text) Then
            MsgBox("Ingrese un valor numerico en el monto de la factura", vbCritical)
            mebMontoFactura.Clear()
            Return False
        End If
        If mebExpediente.Text = "" Then
            MsgBox("Ingrese el numero de expediente", vbCritical)
            mebExpediente.Focus()
            Return False
        End If
        Return True
    End Function

    'LIQUIDACION (BOTON)
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click

        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand("mpa_00245", Conn)
        Cmd.CommandTimeout = 120
        Dim Da As New SqlDataAdapter(Cmd)
        Dim Dt As New DataTable()
        Dim iContador As Integer
        'If Not mcls_00006.mfn_00001(Button2.Tag) Then
        '    MessageBox.Show("módulo no autorizado")
        '    Exit Sub
        'End If

        Dim sFactura As String
        Dim sSucursal As String
        Dim tempMontoFactura As Double

        Dim bLiquidado As Boolean = False
        Dim dLiquidacionTotalizada As Double
        Dim dDebitosTotalizados As Double
        Dim sNombreReporte As String
        Dim sNumeroPrestador As String

        Dim clsLiqui3 As New clsLiquidacion

        Try
            sFactura = Trim(cmbFacturas.Text)
            sSucursal = Mid(Trim(cmbFacturas.Text), 1, 4)

            'ver proceso de bloqueo de prestador/factura (2020)

            'validamos los datos de ingreso de los datos de facturacion
            If Not Validar_Formulario() Then    'si faltan datos sale de la rutina de liquidacion
                Exit Sub
            Else
                cmbMonthM.Enabled = False
                cmbYearM.Enabled = False
                btnBuscarCuit.Enabled = False
                cmdSimularLiquidacion.Enabled = False
                cmdCancelar.Enabled = False
                mebCuit.Enabled = False
                btnBuscarCuit.Enabled = False
                cmbFacturas.Enabled = False
                cmbTipoComprobante.Enabled = False
                mebMontoFactura.Enabled = False
                mebExpediente.Enabled = False
            End If

            sTotalFacturado = decImporteFacturadoFisico
            sTotalFactura = decImporteFacturadoFisico
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@SUCURSAL", Trim(sSucursal))
            Cmd.Parameters.AddWithValue("@sAREA", Trim(sArea))
            Cmd.Parameters.AddWithValue("@CUIT", Trim(sCuit))
            Cmd.Parameters.AddWithValue("@PERIODO", Trim(sPeriodo))
            Cmd.Parameters.AddWithValue("@NUMERO_FACTURA", Trim(sFactura))
            Cmd.Parameters.AddWithValue("@p_TOTAL_FACTURA", decImporteFacturadoFisico)
            Cmd.Parameters.AddWithValue("@p_TOTAL_FACTURADO", decImporteFacturadoFisico)

            Cursor = System.Windows.Forms.Cursors.WaitCursor

            'deshabilitado para poder hacer pruebas
            Conn.Open()
            Da.Fill(Dt)

            'log
            'se graba el detalle de la liquidacion en la tabla mtb_log_liquidaciones
            mLog._usuario = sUsuario
            mLog._numerofactura = sFactura
            mLog._cuit = sCuit
            mLog._periodo = sPeriodo
            mLog._sector = sArea
            mLog.registrar_liquidacion()
            'log

            If Dt.Rows.Count() > 0 Then
                dgvLiquidacion.DataSource = Dt
                mdtg_Format(dgvLiquidacion, "consolas", 9)
                dgvLiquidacion.Columns(0).Visible = False
                sNumeroLiquidacion = dgvLiquidacion.Rows(0).Cells(0).Value
                iNumLiq = CInt(sNumeroLiquidacion)
                lblNumeroLiquidacion.Text = Str(sNumeroLiquidacion) + "/" + sPeriodo.Substring(4, 2)
                For iContador = 8 To 15
                    dgvLiquidacion.Columns(iContador).Visible = False
                Next
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
                dgvLiquidacion.Columns(5).DefaultCellStyle.Format = "c"
                dgvLiquidacion.Columns(6).Width = 80
                dgvLiquidacion.Columns(6).HeaderText = "Imp. Autorizado"
                dgvLiquidacion.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvLiquidacion.Columns(6).DefaultCellStyle.Format = "c"
                dgvLiquidacion.Columns(7).HeaderText = "Saldo"
                dgvLiquidacion.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvLiquidacion.Columns(7).DefaultCellStyle.Format = "c"
            End If
            'grid coloration depending on values
            Dim iValorAuxiliar As Double
            For Each row As DataGridViewRow In dgvLiquidacion.Rows
                iValorAuxiliar = row.Cells(7).Value
                If iValorAuxiliar < 0 Then
                    row.DefaultCellStyle.BackColor = Color.Orange
                ElseIf iValorAuxiliar > 0 Then
                    row.DefaultCellStyle.BackColor = Color.GreenYellow
                End If
            Next
            'end grid coloration depending on values
            'PENDING (isolate the settlement procedure)
            Call Mostrar_Debitos(sNumeroLiquidacion)
            If bERROR = True Then
                bERROR = False
                Dim iNumeroLiquidacion As Integer
                iNumeroLiquidacion = dgvLiquidacion.Rows(0).Cells(0).Value
                Call Cancelar_Liquidacion(iNumeroLiquidacion)
                Call Habilitar_Formulario(True)
                Me.Close()
                Exit Sub
            End If

            dLiquidacionTotalizada = clsLiqui_1.Totalizar_Liquidacion(iNumLiq)  'settlement total
            dDebitosTotalizados = clsLiqui_1.Totalizar_Debitos(iNumLiq)         'debit total

            Dim dValorCompensado As Double
            dValorCompensado = Compensar_Centavos(iNumLiq, sTotalFactura, dLiquidacionTotalizada, dDebitosTotalizados)

            'labels data
            lblImporteLiquidado.Visible = True
            lblImporteLiquidado.TextAlign = HorizontalAlignment.Right
            lblImporteLiquidado.Text = Format(dValorCompensado, "$ ##,###,###.00.")
            lblImporteDebitado.Visible = True
            lblImporteDebitado.TextAlign = HorizontalAlignment.Right
            lblImporteDebitado.Text = Format(dDebitosTotalizados, "$ ##,###,###.00.")

            'START NEW BLOCK
            Dim auxImporteLiquidado As Double

            If Not Actualizar_Autorizacion(sNumeroLiquidacion) Then
                Me.UseWaitCursor = False
                Cursor = System.Windows.Forms.Cursors.Default
                Call Cancelar_Liquidacion(iNumeroLiquidacion)
                MessageBox.Show("Error Actualizando los saldos de la autorizacion en curso.")
            Else
                'If Asignar_Variables_Impresion(dValorCompensado, dDebitosTotalizados, bConsolidacionEnCurso) Then
                If Asignar_Variables_Impresion(dValorCompensado, dDebitosTotalizados, False) Then   'forzamos a falso la consolidacion en curso
                    'auxImporteLiquidado = CDbl(Me.txtImporteLiquidado.Text)
                    auxImporteLiquidado = dValorCompensado

                    Me.UseWaitCursor = False
                    Cursor = System.Windows.Forms.Cursors.Default

                    MsgBox("liquidacion cerrada correctamente." & Chr(13) &
                           "A continuacion se generará el reporte de liquidación . . .", vbInformation)

                    ''log
                    ''se graba el detalle de la liquidacion en la tabla mtb_log_liquidaciones
                    'mLog._usuario = sUsuario
                    'mLog._numerofactura = sFactura
                    'mLog._cuit = sCuit
                    'mLog._periodo = sPeriodo
                    'mLog._sector = sArea
                    'mLog.registrar_liquidacion()
                    ''log
                    Dim sURL As String
                    If scope <> "local" Then
                        sURL = urlReport & sNumeroLiquidacion & "&p_NUMERO_LIQUIDACION=" & sNumeroLiquidacion
                        Shell("C:\Program Files\Internet Explorer\iexplore.exe " & sURL, vbMaximizedFocus)

                        If MessageBox.Show("¿ imprimir reporte PV ?", "reporte PV", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = vbYes Then
                            sURL = urlReport_PV & iNumeroLiquidacion & "&p_NUMERO_LIQUIDACION= " & iNumeroLiquidacion
                            Shell("C:\Program Files\Internet Explorer\iexplore.exe " & sURL, vbMaximizedFocus)
                        End If

                        ' '' '' ''VERIFICAR PORQUE GENERA ERROR (NO BORRAR)
                        ' '' '' ''generamos el nombre con el que el reporta va a grabarse en el disco
                        '' '' ''sNumeroPrestador = InputBox(sPeriodo & sFactura, "ingrese el nombre del reporte a grabarse")
                        '' '' ''sNombreReporte = "C:\temp1\" & sNumeroPrestador & " " & sPeriodo & " " & sFactura & ".pdf"
                        '' '' ''Cursor = System.Windows.Forms.Cursors.WaitCursor

                        '' '' ''Dim sClose As Boolean
                        '' '' ''sClose = bImprimir_Reporte(sNumeroLiquidacion, sNombreReporte)
                        ' '' '' ''VERIFICAR PORQUE GENERA ERROR (NO BORRAR)
                    End If


                    Dim sClose As Boolean = True
                    If Not sClose Then
                        Cursor = System.Windows.Forms.Cursors.Default
                        MsgBox("error imprimiendo la liquidacion", vbCritical)
                    End If
                Else
                    Me.UseWaitCursor = Cursor = System.Windows.Forms.Cursors.Default
                    MsgBox("Error Actualizando valores de impresion." & Chr(13) &
                           "ELIMINE LA LIQUIDACION y vuelva a generarla", vbCritical)

                    ''log
                    'gsModulo = "liquidacion"
                    'gsMensaje = "error.actualizando valores de impresion de la liquidación: [" + sNumeroLiquidacion + "]"
                    'gsCodigoError = 0
                    'gsDescripcionError = ""
                    'Registrar_Log(gsModulo, gsMensaje, gsCodigoError, gsDescripcionError)
                    ''log

                End If
            End If
            'END NEW BLOCK


            dgvLiquidacion.ReadOnly = True
            Button2.Enabled = False

        Catch ex As Exception
            MsgBox("Error generando la liquidacion" & Chr(13) &
                   "Informe al administrador del sistema", vbCritical)

            'log
            If IsNothing(sNumeroLiquidacion) Then sNumeroLiquidacion = ""
            If IsNothing(sCuit) Then sCuit = ""
            If IsNothing(sPeriodo) Then sPeriodo = ""
            gsModulo = "liquidacion"
            gsMensaje = "error.general al generar la liquidación: [" + sNumeroLiquidacion + "], prestador: [" + sCuit + "], periodo: [" + sPeriodo + "]"
            gsCodigoError = Err.Number
            gsDescripcionError = Err.Description
            Registrar_Log(gsModulo, gsMensaje, gsCodigoError, gsDescripcionError)
            'log

        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
            Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub


    Sub Mostrar_Debitos(Num_liq As Integer)
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand("mpa_00250", Conn)
        Dim Da As New SqlDataAdapter(Cmd)
        Dim Dt As New DataTable()
        Dim iNumeroDebito As Integer
        Try
            'Cmd.CommandText = "mpa_00250"
            Cmd.CommandType = CommandType.StoredProcedure
            'Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@p_NUMERO_LIQUIDACION", Num_liq)
            Conn.Open()
            Cmd.ExecuteNonQuery()
            Da.Fill(Dt)
            dgvDebitos.DataSource = Dt

            iNumeroDebito = dgvDebitos.Rows(0).Cells(0).Value
            mdtg_Format(dgvDebitos, "consolas", 9)
            'lblNumeroDebito.Text = Str(iNumeroDebito) + "/12"
            lblNumeroDebito.Visible = True
            lblNumeroDebito.Text = Str(iNumeroDebito) + "/" + Me.cmbYearM.Text.Substring(2, 2)
            dgvDebitos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            dgvDebitos.Columns(0).Visible = False
            dgvDebitos.Columns(1).HeaderText = "Beneficio"
            dgvDebitos.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            dgvDebitos.Columns(2).Width = 180
            dgvDebitos.Columns(2).HeaderText = "Nombre"
            dgvDebitos.Columns(3).Width = 190
            dgvDebitos.Columns(3).HeaderText = "Tipo Debito"
            dgvDebitos.Columns(4).HeaderText = "Saldo"
            dgvDebitos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            dgvDebitos.Columns(4).DefaultCellStyle.Format = "c"
            dgvDebitos.ReadOnly = True

            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        Catch ex As Exception
            MsgBox("Error mostrando los debitos" & Chr(13) &
                   "Informe al administrador del sistema", vbCritical)

            ''log
            'gsModulo = "debitos"
            'gsMensaje = "error.mostrando los debitos de la liquidación: [" + Num_liq + "]"
            'gsCodigoError = Err.Number
            'gsDescripcionError = Err.Description
            'Registrar_Log(gsModulo, gsMensaje, gsCodigoError, gsDescripcionError)
            ''log

            bERROR = True
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Sub


    'BUSCA UN PRESTADOR EN BASE AL CUIT INGRESADO
    Private Sub btnBuscarCuit_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscarCuit.Click
        'Dim sPeriodo As String
        'Dim sCuit As String
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Cmd.CommandTimeout = 500
        Dim Dr As SqlDataReader
        Dim objPrestador As New clsPrestador
        Dim objLiquidacion As New clsLiquidacion
        Dim bPrestadorConsolidado As Boolean = False
        Dim bConsolidacionLiquidada As Boolean = False
        Dim sFacturaConsolidada As String

        Dim aFacturas As String()   'array de facturas (2020)

        Dim rPeriodo As String

        Try
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            cmbFacturas.Items.Clear()
            'sPeriodo = Trim(cmbMonth.Text) & Trim(cmbYear.Text)
            mebCuit.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
            sCuit = mebCuit.Text
            mebCuit.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
            'sCuit = Limpiar_Cadena(Trim(mebCuit.Text), "-")
            'mPeriodo = Trim(cmbMonth.Text) & Trim(cmbYear.Text)
            'sPeriodo = mPeriodo
            rPeriodo = mPeriodo
            'VER PARA SACAR
            'mCuit = Limpiar_Cadena(Trim(mebCuit.Text), "-")
            'sCuit = mCuit                                               'VER PARA SACAR


            'gbxCuit.ForeColor = Color.Green
            'gbxCuit.Text = objPrestador.Obtener_Razon_Social(sCuit)



            'verificamos si el prestador forma parte de una consolidacion
            'sFacturaConsolidada = objPrestador.Obtener_Factura_Consolidada(sCuit, rPeriodo)

            '****************************************************************************
            'si seteamos activa la siguiente linea, ignoramos el chequeo de consolidacion
            sFacturaConsolidada = "0"
            '****************************************************************************
            If sFacturaConsolidada <> "0" Then
                '''LINEAS DE CONSOLIDACION COMENTADAS TEMPORALMENTE
                ''''si el prestador tiene una consolidacion buscamos si la factura recibida como parametro ya fue liquidada
                '''If objLiquidacion.Chequear_Liquidacion_Existente(sCuit, rPeriodo, sFacturaConsolidada) Then
                '''    'factura ya liquidada? ENTONCES CARGAMOS EL RESTO DE LAS FACTURAS EXCEPTO ESTA
                '''    aFacturas = objPrestador.Listar_Facturas_Periodo(sCuit, sPeriodo, sArea)
                '''    'cargamos el array en el combo
                '''    If Not IsNothing(aFacturas) Then
                '''        For Each Factura As String In aFacturas
                '''            'si ya fue liquidada la factura
                '''            If Factura <> sFacturaConsolidada Then
                '''                cmbFacturas.Items.Add(Factura)
                '''            End If
                '''        Next
                '''    End If
                '''Else
                '''    'factura NO liquidada? ENTONCES CARGAMOS SOLAMENTE ESTA FACTURA
                '''    cmbMonth.SelectedIndex = 10     'HARCODEO (ESTABLECER EL INDICE PARA EL MES SUPERIOR DE LA CONSOLIDACION
                '''    mPeriodo = rPeriodo
                '''    cmbFacturas.Items.Add(sFacturaConsolidada)
                '''    Cargar_Detalle_Consolidacion(sCuit, rPeriodo)
                '''End If
            Else
                'en este punto el prestador no tiene una consolidacion, por lo que cargamos todas las facturas en el combo
                'aFacturas = objPrestador.Listar_Facturas_Periodo(sCuit, sPeriodo, sArea)

                dtFacturas = objPrestador.Listar_Facturas_Periodo(sCuit, sPeriodo, sArea)
                If dtFacturas.Rows.Count() = 0 Then
                    MsgBox("no existen facturas para el periodo seleccionado . . .", vbInformation)
                    Reiniciar_Formulario()
                    Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                Else    'existen facturas para el periodo + cuit + sector
                    gbxCuit.Text = Trim(LCase(dtFacturas.Rows(0).Item("nombre")))
                    lblAutorizacionExistente.Text = Trim(LCase(dtFacturas.Rows(0).Item("nombre")))
                    cmbFacturas.ValueMember = "total"
                    cmbFacturas.DisplayMember = "factura"
                    cmbFacturas.DataSource = dtFacturas


                    'For Each Facturas In aFacturas
                    '    cmbFacturas.Items.Add(Facturas)
                    'Next


                    'Button2.Visible = True
                    'mebExpediente.Visible = True
                    'lblExpediente.Visible = True
                    'lblMontoLiquidado.Visible = True
                    ''btnCopiarMonto.Visible = True
                    'mebMontoFactura.Visible = True
                    'cmbTipoComprobante.Visible = True
                    'lblTipoComprobante.Visible = True
                    'lblSeleccioneFactura.Visible = True
                    'cmdSimularLiquidacion.Visible = True

                    enableForm(1)

                    Cursor = System.Windows.Forms.Cursors.Default
                End If
            End If


            'If cmbFacturas.Items.Count = 0 Then
            '    MsgBox("no existen facturas para el periodo seleccionado . . .", vbInformation)

            '    ''log
            '    'gsModulo = "autorizacion"
            '    'gsMensaje = "error.no se encuentra autorizacion para el prestador [" + sCuit + "] para el periodo: [" + rPeriodo + "]"
            '    'gsCodigoError = 0
            '    'gsDescripcionError = ""
            '    'Registrar_Log(gsModulo, gsMensaje, gsCodigoError, gsDescripcionError)
            '    ''log

            '    Reiniciar_Formulario()
            '    Cursor = System.Windows.Forms.Cursors.Default
            '    Exit Sub
            'Else
            '    Button2.Visible = True
            '    'mebExpediente.Clear()
            '    mebExpediente.Visible = True
            '    lblExpediente.Visible = True
            '    'mebMontoFactura.Clear()
            '    lblMontoLiquidado.Visible = True
            '    btnCopiarMonto.Visible = True
            '    mebMontoFactura.Visible = True
            '    cmbTipoComprobante.Visible = True
            '    lblTipoComprobante.Visible = True
            '    'cmbFacturas.Items.Clear()
            '    lblSeleccioneFactura.Visible = True
            '    cmdSimularLiquidacion.Visible = True
            '    'mebCuit.Clear()
            '    'lblCuit.Visible = False
            '    'cmbMonth.SelectedIndex = -1
            '    'cmbYear.SelectedIndex = -1
            '    'mebCuit.Visible = False
            '    'btnBuscarCuit.Visible = False
            '    Cursor = System.Windows.Forms.Cursors.Default


            '    'If gsUsuario = "jmedina" And sPeriodo = "032019" Then
            '    '    cmdImportarMarzo2019.Visible = True
            '    'ElseIf gsUsuario = "chermida" And sPeriodo = "032019" Then
            '    '    cmdImportarMarzo2019.Visible = True
            '    'ElseIf gsUsuario = "fgonzalez" And sPeriodo = "032019" Then
            '    '    cmdImportarMarzo2019.Visible = True
            '    'ElseIf gsUsuario = "malfonso" And sPeriodo = "032019" Then
            '    '    cmdImportarMarzo2019.Visible = True
            '    'Else
            '    '    cmdImportarMarzo2019.Visible = False
            '    'End If



            'End If

            'lblSeleccioneFactura.Visible = True
            'cmbFacturas.Visible = True
            'lblTipoComprobante.Visible = True
            'cmbTipoComprobante.Visible = True
            'lblMontoLiquidado.Visible = True
            'mebMontoFactura.Visible = True
            'lblExpediente.Visible = True
            'mebExpediente.Visible = True
            enableForm(2)
            'VER MENSAJE CUANDO NO HAY FACTURAS

            'Habilitar_Formulario(True)
            Cursor = System.Windows.Forms.Cursors.Default
        Catch ex As Exception
            Cursor = System.Windows.Forms.Cursors.Default
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
            Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub



    'llena el formulario con los datos de la consolidacion
    'Sub Cargar_Detalle_Consolidacion(ByVal sCuit As String, ByVal sPeriodo As String)
    '    Dim Conn As New SqlConnection(gsConnectionString)
    '    Dim Cmd As New SqlCommand
    '    Dim Dr As SqlDataReader
    '    Try
    '        Cmd.CommandText = "pa_CHEQUEAR_CONSOLIDACIONES"
    '        Cmd.CommandType = CommandType.StoredProcedure
    '        Cmd.Connection = Conn
    '        Cmd.Parameters.AddWithValue("@CUIT", sCuit)
    '        Cmd.Parameters.AddWithValue("@PERIODO", sPeriodo)
    '        Conn.Open()
    '        Dr = Cmd.ExecuteReader()
    '        If Dr.Read <> Nothing Then
    '            'ASIGNACION DE VARIABLES
    '            sFacturaPeriodoA = Trim(Dr.Item("CONS_FACTURAS_PA"))
    '            sFacturaPeriodoB = Trim(Dr.Item("CONS_FACTURAS_PB"))

    '            MsgBox("El prestador seleccionado para la liquidación esta bajo una modalidad de consolidación de dos períodos." & Chr(13) &
    '                    "debe liquidar la factura consolidada en primer lugar, luego podrá liquidar facturas individuales . . .", vbInformation)
    '            Cursor = System.Windows.Forms.Cursors.WaitCursor
    '            txtObservaciones.Text = "liquidación consolidada para los periodos " & Trim(Dr.Item("CONS_PERIODO_A")) & " / " & Trim(Dr.Item("CONS_PERIODO_B")) & vbCrLf &
    '                                    "Facturas " & Formatear_Periodo(Trim(Dr.Item("CONS_PERIODO_A"))) & ": " & Trim(Dr.Item("CONS_FACTURAS_PA")) & vbCrLf &
    '                                    "Facturas " & Formatear_Periodo(Trim(Dr.Item("CONS_PERIODO_B"))) & ": " & Trim(Dr.Item("CONS_FACTURAS_PB"))

    '            lblAutorizacionConsolidadaPeriodoA.Text = "Autorizacion " & Formatear_Periodo(Trim(Dr.Item("CONS_PERIODO_A"))) & ": $" & Trim(Dr.Item("CONS_AUTORIZADO_PA"))
    '            lblFacturacionConsolidadaPeriodoA.Text = "Facturacion " & Formatear_Periodo(Trim(Dr.Item("CONS_PERIODO_A"))) & ": $" & Trim(Dr.Item("CONS_FACTURADO_PA"))
    '            lblAutorizacionConsolidadaPeriodoB.Text = "Autorizacion " & Formatear_Periodo(Trim(Dr.Item("CONS_PERIODO_B"))) & ": $" & Trim(Dr.Item("CONS_AUTORIZADO_PB"))
    '            lblFacturacionConsolidadaPeriodoB.Text = "Facturacion " & Formatear_Periodo(Trim(Dr.Item("CONS_PERIODO_B"))) & ": $" & Trim(Dr.Item("CONS_FACTURADO_PB"))
    '            lblFacturasConsolidadasComprobante.Text = "Factura consolidada: " & Trim(Dr.Item("CONS_FACTURA_CONSOLIDADA"))
    '            lblTotalAutorizadoConsolidado.Text = "Total aut. consolidado: $" & Trim(Dr.Item("CONS_MONTO_AUTORIZADO_CONSOLIDADO"))
    '            lblTotalFacturadoConsolidado.Text = "Total fact. consolidado: $" & Trim(Dr.Item("CONS_MONTO_FACTURADO_CONSOLIDADO"))
    '            TotalFacturadoConsolidado = Dr.Item("CONS_MONTO_FACTURADO_CONSOLIDADO")
    '            'btnCopiarMonto.Visible = True
    '            cmbFacturas.SelectedIndex = 0
    '            'Return True
    '        Else
    '            'btnCopiarMonto.Visible = False
    '            'Return False
    '        End If

    '    Catch
    '        'Return False
    '    Finally
    '        Cursor = System.Windows.Forms.Cursors.Default
    '        Dr.Close()
    '        Conn.Close()
    '        Conn.Dispose()
    '        Cmd.Dispose()
    '    End Try
    'End Sub

    'FUNCION PARA ELIMINAR UNA LIQUIDACIÓN
    Sub CancelarLiquidacion(iNumLiq As Integer)
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Dim iNumeroLiquidacion As Integer
        Try
            iNumeroLiquidacion = dgvLiquidacion.Rows(0).Cells(0).Value
            Cmd.CommandText = "pa_ELIMINAR_LIQUIDACION"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@p_NUMEROLIQUIDACION", iNumeroLiquidacion)
            Conn.Open()
            Cmd.ExecuteNonQuery()

            'log
            If IsNothing(iNumeroLiquidacion) Then iNumeroLiquidacion = 0
            gsModulo = "liquidacion"
            gsMensaje = "ok.liquidacion: [" + iNumeroLiquidacion + "] cancelada"
            gsCodigoError = 0
            gsDescripcionError = ""
            Registrar_Log(gsModulo, gsMensaje, gsCodigoError, gsDescripcionError)
            'log

            MsgBox("Liquidacion Cancelada", vbInformation)
        Catch ex As Exception

            'log
            If IsNothing(iNumeroLiquidacion) Then iNumeroLiquidacion = 0
            gsModulo = "liquidacion"
            gsMensaje = "error.cancelando la liquidacion: [" + iNumeroLiquidacion + "]"
            gsCodigoError = Err.Number
            gsDescripcionError = Err.Description
            Registrar_Log(gsModulo, gsMensaje, gsCodigoError, gsDescripcionError)
            'log

            MsgBox("Error actualizando saldos de la autorizacion", vbCritical)
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Sub

    'GRABAMOS EN ANEXO_LIQUIDACIONES LOS DATOS CONSOLIDADOS PARA LOS REPORTES
    Function Asignar_Variables_Impresion(ByVal dImporteLiquidado As Double, ByVal dImporteDebitado As Double, bConsolidacion As Boolean) As Boolean
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        'Dim iNumeroLiquidacion As Integer

        'VARIABLES PARA PERIODOS CONSOLIDADOS
        Dim sPeriodos As String
        Dim sFacturas As String

        Try
            Dim auxString As String = Trim(lblNumeroLiquidacion.Text)
            'iNumLiq = CInt(auxString.Substring(0, (auxString.Length) - 3)) 'VER PARA PASAR EL NUMERO DE LIQUIDACION 
            iNumLiq = sNumeroLiquidacion  '¿para que asignamos esta variable?
            'iNumeroLiquidacion = auxString
            iCuit = Trim(mebCuit.Text)
            iRazonSocial = Trim(gbxCuit.Text)
            If bConsolidacion Then
                'sPeriodos = sPeriodoConsolidacion1 & " / " & sPeriodoConsolidacion2
                'sFacturas = sFacturaPeriodoA & " / " & sFacturaPeriodoB
            Else
                'sPeriodos = ConvertirPeriodo(Trim(cmbMonthM.Text) & Trim(cmbYearM.Text))
                sPeriodos = Trim(cmbMonthM.Text) & " de " & Trim(cmbYearM.Text)
                sFacturas = Trim(cmbFacturas.Text)
            End If

            iTipoFactura = Trim(cmbTipoComprobante.Text)

            'iModulo = ConvertirModulo(sArea) & " PFIS"
            iModulo = ConvertirModulo(sArea, sSector)
            'iImporteFacturado = CDbl(txtImporteFacturado.Text)
            iImporteFacturado = sTotalFactura
            'iImporteFacturado = CDbl(mebMontoFactura.Text)
            auxString = Trim(lblNumeroDebito.Text)
            iNumeroDebito = auxString.Substring(0, (auxString.Length) - 3)
            'iNumeroDebito = "Débito N°: " & iNumeroDebito
            'iImporteDebito = CDbl(txtImporteDebitado.Text)
            iImporteDebito = dImporteDebitado
            iNumeroBafc = ""
            iImporteBafc = 0
            'iImporteLiquidado = CDbl(txtImporteLiquidado.Text)
            iImporteLiquidado = dImporteLiquidado
            auxString = Format(iImporteLiquidado, "0.00").ToString
            'auxString = Replace(auxString, ",", ".")

            'Dim cadena() As String

            'TEST
            'cadena = auxString.Split(".")
            'iLeyendaImporteLiquidado = Num2Text(cadena(0)) & " PESOS CON " & Num2Text(cadena(1)) & " CENTAVOS"
            'MsgBox(iLeyendaImporteLiquidado)
            'FIN TEST

            If iImporteLiquidado > 0 Then
                iLeyendaImporteLiquidado = Cambio(iImporteLiquidado)
            Else
                iLeyendaImporteLiquidado = ""
            End If

            iLiquidadoAlFondo = 0
            iObservaciones = Trim(LCase(txtObservaciones.Text))
            auxString = Now.ToString("dd") & " de " & Now.ToString("MMMM") & " de " & Now.ToString("yyyy")
            'iFechaLiquidacion = "Control y Liquidación, " & auxString
            iFechaLiquidacion = auxString
            iExpediente = Trim(mebExpediente.Text)
            iReferencia = "Facturacion " & ConvertirModulo(sArea, sSector)

            iUsuario = ""

            Cmd.CommandText = "pa_INSERTAR_ANEXOLIQUIDACIONES"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@ANX_NUMLIQ", iNumLiq)
            'Cmd.Parameters.AddWithValue("@ANX_NUMEROLIQUIDACION", iNumeroLiquidacion)
            Cmd.Parameters.AddWithValue("@ANX_NUMEROLIQUIDACION", sNumeroLiquidacion)
            Cmd.Parameters.AddWithValue("@ANX_CUIT", iCuit)
            Cmd.Parameters.AddWithValue("@ANX_RAZONSOCIAL", iRazonSocial)
            Cmd.Parameters.AddWithValue("@ANX_PERIODO", sPeriodos)
            Cmd.Parameters.AddWithValue("@ANX_TIPOFACTURA", iTipoFactura)
            Cmd.Parameters.AddWithValue("@ANX_NUMEROFACTURA", sFacturas)
            Cmd.Parameters.AddWithValue("@ANX_MODULO", iModulo)
            Cmd.Parameters.AddWithValue("@ANX_IMPORTEFACTURADO", iImporteFacturado)
            Cmd.Parameters.AddWithValue("@AUX_NUMERODEBITO", iNumeroDebito)
            Cmd.Parameters.AddWithValue("@ANX_IMPORTEDEBITO", iImporteDebito)
            Cmd.Parameters.AddWithValue("@ANX_NUMEROBAFC", iNumeroBafc)
            Cmd.Parameters.AddWithValue("@ANX_IMPORTEBAFC", iImporteBafc)
            Cmd.Parameters.AddWithValue("@ANX_IMPORTELIQUIDADO", iImporteLiquidado)
            Cmd.Parameters.AddWithValue("@ANX_LEYENDAIMPORTELIQUIDADO", iLeyendaImporteLiquidado)
            Cmd.Parameters.AddWithValue("@ANX_LIQUIDADOALFONDO", iLiquidadoAlFondo)
            Cmd.Parameters.AddWithValue("@ANX_OBSERVACIONES", iObservaciones)
            Cmd.Parameters.AddWithValue("@ANX_FECHALIQUIDACION", iFechaLiquidacion)
            Cmd.Parameters.AddWithValue("@ANX_EXPEDIENTE", iExpediente)
            Cmd.Parameters.AddWithValue("@ANX_REFERENCIA", iReferencia)
            Cmd.Parameters.AddWithValue("@ANX_USUARIO", iUsuario)

            Conn.Open()
            Cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception
            'log
            gsModulo = "liquidacion"
            gsMensaje = "error.actualizando datos de liquidacion extensivos de la liquidacion: [" + iNumLiq + "]"
            gsCodigoError = 0
            gsDescripcionError = ""
            Registrar_Log(gsModulo, gsMensaje, gsCodigoError, gsDescripcionError)
            'log

            MsgBox("Error actualizando datos de liquidacion extensivos" & Chr(13) &
                   "Informe al administrador del sistema para restablecer la factura del Prestador", vbCritical)
            Return False
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function

    'ACTUALIZA LOS SALDOS DE LAS AUTORIZACIONES AL EFECTUAR UNA LIQUIDACION
    Function Actualizar_Autorizacion(ByVal iNumLiq As Integer) As Boolean
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand

        'Dim sClose As String

        Try
            Cmd.CommandTimeout = 0
            'sclose = MsgBox("version nueva?", vbYesNo)
            'If sclose = vbYes Then
            Cmd.CommandText = "pa_ACTUALIZAR_VALORES_AUTORIZACIONES"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@p_NUMERO_LIQUIDACION", iNumLiq)
            Conn.Open()
            Cmd.ExecuteNonQuery()
            Return True
        Catch ex As Exception

            'log
            gsModulo = "liquidacion"
            gsMensaje = "error.actualizando saldos de la autorizacion sobre la liquidacion: [" + iNumLiq + "]"
            gsCodigoError = 0
            gsDescripcionError = ""
            Registrar_Log(gsModulo, gsMensaje, gsCodigoError, gsDescripcionError)
            'log

            MsgBox("Error actualizando saldos de la autorizacion", vbCritical)
            Return False
        Finally
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        End Try
    End Function


    Function Cancelar_Liquidacion(iNumLiq As Integer) As Boolean
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Try
            Cmd.CommandText = "pa_ELIMINAR_LIQUIDACION"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@p_NUMEROLIQUIDACION", iNumLiq)
            Conn.Open()
            Cmd.ExecuteNonQuery()
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
            Return True
        Catch ex As Exception
            MsgBox("Error cancelando y eliminando la liquidacion" & Chr(13) &
                   "Informe al administrador del sistema para eliminar la liquidacion", vbCritical)
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
            Return False
        End Try
    End Function

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Habilitar_Formulario(True)
        Me.Close()
        Me.Dispose()
        Me.DestroyHandle()
    End Sub

    Private Sub cmbFacturas_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbFacturas.SelectedIndexChanged
        'Dim lFactura As String = Trim(cmbFacturas.Text)
        mNumeroFactura = Trim(cmbFacturas.Text)
        sSucursal = Mid(Trim(cmbFacturas.Text), 1, 4)
        Dim liqFactura As New clsLiquidacion
        Try
            Me.Cursor = Cursors.WaitCursor
            'CHEQUEAR SI YA FUE LIQUIDADA
            'If liqFactura.Chequear_Liquidacion_Existente(sCuit, sPeriodo, mNumeroFactura) Then
            '    MsgBox("factura ya liquidada para el periodo seleccionado . . .", vbInformation)
            '    cmbFacturas.SelectedIndex = -1
            '    lblImporteFacturadoElectronico.Text = ". . ."
            '    Exit Sub
            'End If
            decImporteFacturadoElectronico = cmbFacturas.SelectedValue
            'lblImporteFacturadoElectronico.Text = cmbFacturas.SelectedValue.ToString
            lblImporteFacturadoElectronico.Text = Format(CDbl(Trim(cmbFacturas.SelectedValue.ToString)), "##,##0.00")


            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            mNumeroFactura = Nothing
        End Try
    End Sub

    Private Sub mebMontoFactura_GotFocus(sender As Object, e As System.EventArgs) Handles mebMontoFactura.GotFocus
        lblImporteFacturado.Text = ". . ."
        lblDiferenciaFActurado.Text = ". . ."
        mebMontoFactura.Clear()

    End Sub

    'CONTROLAMOS EL MONTO INGRESADO EN EL BOX DE IMPORTE FACTURADO
    Private Sub mebMontoFactura_LostFocus(sender As Object, e As System.EventArgs) Handles mebMontoFactura.LostFocus
        Try
            If Not IsNumeric(mebMontoFactura.Text) Then 'ver si es numerico
                Return
            Else
                mebMontoFactura.TextAlign = HorizontalAlignment.Right
                mebMontoFactura.Text = Replace(mebMontoFactura.Text, ".", ",")
                mebMontoFactura.Text = Format(CDbl(Trim(mebMontoFactura.Text)), "##,##0.00")
                lblImporteFacturado.Text = mebMontoFactura.Text
                decImporteFacturadoFisico = Trim(mebMontoFactura.Text)
                If decImporteFacturadoFisico > 99999999 Then
                    MsgBox("revise el importe del monto facturado . . .", vbCritical)
                    mebMontoFactura.Text = ""
                    lblImporteFacturado.Text = ". . ."
                Else
                    Dim diferenciaFacturada As Decimal = decImporteFacturadoFisico - decImporteFacturadoElectronico 'calculateDiff(decImporteFacturadoElectronico, decImporteFacturadoFisico)
                    Label4.ForeColor = Color.Black
                    lblImporteFacturado.ForeColor = Color.Black
                    Label9.ForeColor = Color.Black
                    lblDiferenciaFActurado.ForeColor = Color.Black

                    lblDiferenciaFActurado.Text = diferenciaFacturada.ToString

                    If (diferenciaFacturada > 0) Then   'se elimina el concepto de compensacion
                        Label4.ForeColor = Color.Red
                        lblImporteFacturado.ForeColor = Color.Red
                        Label9.ForeColor = Color.Red
                        lblDiferenciaFActurado.ForeColor = Color.Red
                        MsgBox("El monto facturado es menor al informado en el detalle electronico." & Chr(13) &
                               "diferencia: $ " & Format(diferenciaFacturada, "##,##0.00") & Chr(13) & Chr(13) &
                               "No es posible liquidar esta factura." & Chr(13) & Chr(13) &
                               "Total liquidacion electronica: $ " & Format(decImporteFacturadoElectronico, "##,##0.00") & Chr(13) &
                               "Total liquidacion en factrura papel: $ " & Format(decImporteFacturadoFisico, "##,##0.00"), vbCritical)
                        mebMontoFactura.Clear()
                        mebMontoFactura.Focus()
                        Exit Sub
                    Else
                        Button2.Enabled = True
                        Button2.Visible = True
                        cmdCancelar.Visible = True
                    End If
                End If
            End If
        Catch ex As Exception
            Return
        End Try
    End Sub

    Sub Habilitar_Formulario(Habilitar As Boolean)
        If Habilitar Then
            frmDefault.MenuStrip1.Enabled = True
            cmdAceptarPeriodo.Enabled = True
            btnBuscarCuit.Enabled = True
            Button2.Visible = True
            Button2.Enabled = True 'liquidar
            cmbFacturas.Enabled = True
            cmbTipoComprobante.Enabled = True
            mebMontoFactura.Enabled = True
            mebExpediente.Enabled = True
            'txtObservaciones.Enabled = True
            cmdCerrar.Enabled = True
        Else
            frmDefault.MenuStrip1.Enabled = False
            cmdAceptarPeriodo.Enabled = False
            btnBuscarCuit.Enabled = False
            Button2.Enabled = False 'liquidar
            cmbFacturas.Enabled = False
            cmbTipoComprobante.Enabled = False
            mebMontoFactura.Enabled = False
            mebExpediente.Enabled = False
            'txtObservaciones.Enabled = False
            'cmdCerrar.Enabled = False
        End If
    End Sub

    'COPIA EL MONTO CALCULADO PARA LA SUMATORIA DE LA CONSOLIDACION
    'Private Sub btnCopiarMonto_Click(sender As System.Object, e As System.EventArgs) Handles btnCopiarMonto.Click
    '    mebMontoFactura.Text = TotalFacturadoConsolidado
    'End Sub


    'SIMULA LA LIQUIDACIÓN EN PANTALLA PERO SIN TOCAR LAS BASES DE DATOS
    Private Sub cmdSimularLiquidacion_Click(sender As System.Object, e As System.EventArgs) Handles cmdSimularLiquidacion.Click
        'Dim sFactura As String
        Dim impFacturaPapel As Decimal = decImporteFacturadoFisico
        Try
            'If Not mcls_00006.mfn_00001(cmdSimularLiquidacion.Tag) Then
            '    MessageBox.Show("módulo no autorizado")
            '    Exit Sub
            'End If
            If mNumeroFactura = "" Then
                MsgBox("debe seleccionar una factura para evaluar . . .", vbInformation)
                Exit Sub
            End If

            Cursor = System.Windows.Forms.Cursors.WaitCursor
            Me.Refresh()



            Dim frmSimulacionLiquidacion As New frmSimulacionLiquidacion
            frmSimulacionLiquidacion.localArea = sArea
            frmSimulacionLiquidacion.simCuit = sCuit
            frmSimulacionLiquidacion.simPeriodo = sPeriodo
            frmSimulacionLiquidacion.simSucursal = sSucursal
            frmSimulacionLiquidacion.simFactura = mNumeroFactura
            frmSimulacionLiquidacion.simTotalFacturadoFisico = decImporteFacturadoFisico
            frmSimulacionLiquidacion.simTotalFacturadoElectronico = decImporteFacturadoElectronico
            If decImporteFacturadoFisico > 0 Then
                frmSimulacionLiquidacion.simErrorSuma = decImporteFacturadoFisico - decImporteFacturadoElectronico
            Else
                frmSimulacionLiquidacion.simErrorSuma = -1
            End If
            frmSimulacionLiquidacion.ShowDialog()
        Catch ex As Exception
        Finally
            Cursor = System.Windows.Forms.Cursors.Default
        End Try
    End Sub


    'habilitamos o deshabilitamos sectores del formulario segun demanda
    Sub enableForm(ByVal state As Int16)
        Select Case state
            Case 0
                'gbxCuit.Visible = False         'ocultamos el groupbox de busqueda de cuit
                lblCuit.Visible = False
                mebCuit.Clear()                 'vaciamos el textbox de cuit
                mebCuit.Visible = False
                btnBuscarCuit.Visible = False
                cmbFacturas.Items.Clear()       'vaciamos el combo de facturas
                lblSeleccioneFactura.Visible = False
                cmbFacturas.Visible = False
                cmdSimularLiquidacion.Visible = False
                lblTipoComprobante.Visible = False
                cmbTipoComprobante.Visible = False
                lblMontoLiquidado.Visible = False
                mebMontoFactura.Visible = False
                mebMontoFactura.Clear()         'vaciamos el textbox de monto de factura
                lblExpediente.Visible = False
                mebExpediente.Visible = False
                mebExpediente.Clear()           'vaciamos el textbox de expediente
                Button2.Enabled = False
                'Button2.Visible = False




            Case 1
                'Button2.Visible = True
                mebExpediente.Visible = True
                lblExpediente.Visible = True
                lblMontoLiquidado.Visible = True
                'btnCopiarMonto.Visible = True
                mebMontoFactura.Visible = True
                cmbTipoComprobante.Visible = True
                lblTipoComprobante.Visible = True
                lblSeleccioneFactura.Visible = True
                cmdSimularLiquidacion.Visible = True
            Case 2
                lblSeleccioneFactura.Visible = True
                cmbFacturas.Visible = True
                lblTipoComprobante.Visible = True
                cmbTipoComprobante.Visible = True
                lblMontoLiquidado.Visible = True
                mebMontoFactura.Visible = True
                lblExpediente.Visible = True
                mebExpediente.Visible = True

                frmDefault.MenuStrip1.Enabled = True
                cmdAceptarPeriodo.Enabled = True
                btnBuscarCuit.Enabled = True
                'Button2.Visible = True
               'Button2.Enabled = True 'liquidar
                cmbFacturas.Enabled = True
                cmbTipoComprobante.Enabled = True
                mebMontoFactura.Enabled = True
                mebExpediente.Enabled = True
                'txtObservaciones.Enabled = True
                cmdCerrar.Enabled = True
            Case 3      'TEMPORAL, VER SI SE USA
                mebCuit.Clear()
                cmbFacturas.Items.Clear()
                mebMontoFactura.Clear()
                mebExpediente.Clear()
                'Button2.Visible = False
            'btnCopiarMonto.Visible = False

            Case 10 'habilitamos controles de busqueda luego de validar el periodo
                mebCuit.Clear()                 'vaciamos el textbox de cuit
                cmbFacturas.Items.Clear()       'vaciamos el combo de facturas
                mebMontoFactura.Clear()         'vaciamos el textbox de monto de factura
                mebExpediente.Clear()           'vaciamos el textbox de expediente
                'Button2.Visible = False         'ocultamos el boton liquidar
                gbxCuit.Visible = True          'ponemos visible el groupbox de datos de facturacion
                mebCuit.Visible = True          'ponemos visible el textbox de cuit
                btnBuscarCuit.Visible = True    'ponemos visible el boton de buscar cuit
                mebCuit.Focus()                 'ponemos foco en el boton cuit

            'case 12 validado
            Case 11     'deshabilitamos y ocultamos los controles de datos de facturacion
                'gbxCuit.Visible = False         'ocultamos el groupbox de busqueda de cuit
                lblCuit.Visible = False
                mebCuit.Clear()                 'vaciamos el textbox de cuit
                mebCuit.Visible = False
                btnBuscarCuit.Visible = False
                cmbFacturas.Items.Clear()       'vaciamos el combo de facturas
                lblSeleccioneFactura.Visible = False
                cmbFacturas.Visible = False
                cmdSimularLiquidacion.Visible = False
                lblTipoComprobante.Visible = False
                cmbTipoComprobante.Visible = False
                lblMontoLiquidado.Visible = False
                mebMontoFactura.Visible = False
                mebMontoFactura.Clear()         'vaciamos el textbox de monto de factura
                lblExpediente.Visible = False
                mebExpediente.Visible = False
                mebExpediente.Clear()           'vaciamos el textbox de expediente
                'Button2.Visible = False

            'case 12 validado
            Case 12 'habilitamos el combo para buscar cuit ya con periodo de autorizacion validada
                gbxCuit.Visible = True
                lblCuit.Visible = True
                mebCuit.Visible = True
                btnBuscarCuit.Visible = True
                mebCuit.Focus()

            'case 13 validado
            Case 13 'habilitamos los controles de informacion general
                lblImporteLiquidado.Visible = True
                Label6.Visible = True
                lblImporteDebitado.Visible = True
                Label4.Visible = True
                Label8.Visible = True
                lblImporteFacturadoElectronico.Visible = True
                lblImporteFacturado.Visible = True
                Label5.Visible = True
                lblNumeroDebito.Visible = True
                Label1.Visible = True
                lblNumeroLiquidacion.Visible = True
                Label7.Visible = True

        End Select

    End Sub

    'Sub resizeForm(ByVal state As SByte)
    '    Select Case state
    '        Case 0
    '            Me.Width = 531 : Me.Height = 91 : Me.Top = 60 : Me.Left = 20
    '        Case 1
    '            Me.Width = 806 : Me.Height = 238 : Me.Top = 60 : Me.Left = 20
    '        Case 2
    '            Me.Width = 1074 : Me.Height = 688 : Me.Top = 60 : Me.Left = 20
    '    End Select
    'End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub mebExpediente_LostFocus(sender As Object, e As EventArgs) Handles mebExpediente.LostFocus
        'mebExpediente.Text = Format(CDbl(Trim(mebMontoFactura.Text)), "##,##0.00")
    End Sub


End Class