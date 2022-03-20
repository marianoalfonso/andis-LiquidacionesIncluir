<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLiquidacion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLiquidacion))
        Me.Button2 = New System.Windows.Forms.Button()
        Me.dgvLiquidacion = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbYearM = New System.Windows.Forms.ComboBox()
        Me.cmbMonthM = New System.Windows.Forms.ComboBox()
        Me.lblAutorizacionExistente = New System.Windows.Forms.Label()
        Me.cmdAceptarPeriodo = New System.Windows.Forms.Button()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.gbxCuit = New System.Windows.Forms.GroupBox()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdSimularLiquidacion = New System.Windows.Forms.Button()
        Me.btnCopiarMonto = New System.Windows.Forms.Button()
        Me.mebMontoFactura = New System.Windows.Forms.TextBox()
        Me.cmbTipoComprobante = New System.Windows.Forms.ComboBox()
        Me.lblTipoComprobante = New System.Windows.Forms.Label()
        Me.mebExpediente = New System.Windows.Forms.MaskedTextBox()
        Me.lblExpediente = New System.Windows.Forms.Label()
        Me.btnBuscarCuit = New System.Windows.Forms.Button()
        Me.lblMontoLiquidado = New System.Windows.Forms.Label()
        Me.lblSeleccioneFactura = New System.Windows.Forms.Label()
        Me.lblRazonSocialPrestador = New System.Windows.Forms.Label()
        Me.cmbFacturas = New System.Windows.Forms.ComboBox()
        Me.mebCuit = New System.Windows.Forms.MaskedTextBox()
        Me.lblCuit = New System.Windows.Forms.Label()
        Me.dgvDebitos = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.lblDiferenciaFActurado = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblImporteFacturadoElectronico = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblNumeroLiquidacion = New System.Windows.Forms.Label()
        Me.lblNumeroDebito = New System.Windows.Forms.Label()
        Me.lblImporteDebitado = New System.Windows.Forms.Label()
        Me.lblImporteLiquidado = New System.Windows.Forms.Label()
        Me.lblImporteFacturado = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.gbInfoConsolidacion = New System.Windows.Forms.GroupBox()
        Me.lblTotalFacturadoConsolidado = New System.Windows.Forms.Label()
        Me.lblTotalAutorizadoConsolidado = New System.Windows.Forms.Label()
        Me.lblFacturasConsolidadasComprobante = New System.Windows.Forms.Label()
        Me.lblFacturacionConsolidadaPeriodoB = New System.Windows.Forms.Label()
        Me.lblFacturacionConsolidadaPeriodoA = New System.Windows.Forms.Label()
        Me.lblAutorizacionConsolidadaPeriodoB = New System.Windows.Forms.Label()
        Me.lblAutorizacionConsolidadaPeriodoA = New System.Windows.Forms.Label()
        CType(Me.dgvLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.gbxCuit.SuspendLayout()
        CType(Me.dgvDebitos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.gbInfoConsolidacion.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(370, 80)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(133, 28)
        Me.Button2.TabIndex = 10
        Me.Button2.Text = "liquidar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'dgvLiquidacion
        '
        Me.dgvLiquidacion.BackgroundColor = System.Drawing.Color.White
        Me.dgvLiquidacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvLiquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLiquidacion.Location = New System.Drawing.Point(3, 225)
        Me.dgvLiquidacion.Name = "dgvLiquidacion"
        Me.dgvLiquidacion.Size = New System.Drawing.Size(982, 218)
        Me.dgvLiquidacion.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbYearM)
        Me.GroupBox1.Controls.Add(Me.cmbMonthM)
        Me.GroupBox1.Controls.Add(Me.lblAutorizacionExistente)
        Me.GroupBox1.Controls.Add(Me.cmdAceptarPeriodo)
        Me.GroupBox1.Controls.Add(Me.lblPeriodo)
        Me.GroupBox1.Font = New System.Drawing.Font("Lucida Bright", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(13, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(647, 44)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'cmbYearM
        '
        Me.cmbYearM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYearM.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbYearM.FormattingEnabled = True
        Me.cmbYearM.Location = New System.Drawing.Point(166, 12)
        Me.cmbYearM.Name = "cmbYearM"
        Me.cmbYearM.Size = New System.Drawing.Size(64, 26)
        Me.cmbYearM.TabIndex = 16
        '
        'cmbMonthM
        '
        Me.cmbMonthM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonthM.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMonthM.FormattingEnabled = True
        Me.cmbMonthM.Location = New System.Drawing.Point(71, 12)
        Me.cmbMonthM.Name = "cmbMonthM"
        Me.cmbMonthM.Size = New System.Drawing.Size(92, 26)
        Me.cmbMonthM.TabIndex = 15
        '
        'lblAutorizacionExistente
        '
        Me.lblAutorizacionExistente.AutoSize = True
        Me.lblAutorizacionExistente.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutorizacionExistente.Location = New System.Drawing.Point(289, 19)
        Me.lblAutorizacionExistente.Name = "lblAutorizacionExistente"
        Me.lblAutorizacionExistente.Size = New System.Drawing.Size(48, 18)
        Me.lblAutorizacionExistente.TabIndex = 14
        Me.lblAutorizacionExistente.Text = ". . ."
        '
        'cmdAceptarPeriodo
        '
        Me.cmdAceptarPeriodo.Image = CType(resources.GetObject("cmdAceptarPeriodo.Image"), System.Drawing.Image)
        Me.cmdAceptarPeriodo.Location = New System.Drawing.Point(235, 10)
        Me.cmdAceptarPeriodo.Name = "cmdAceptarPeriodo"
        Me.cmdAceptarPeriodo.Size = New System.Drawing.Size(45, 29)
        Me.cmdAceptarPeriodo.TabIndex = 3
        Me.cmdAceptarPeriodo.UseVisualStyleBackColor = True
        '
        'lblPeriodo
        '
        Me.lblPeriodo.AutoSize = True
        Me.lblPeriodo.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodo.Location = New System.Drawing.Point(6, 17)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(64, 18)
        Me.lblPeriodo.TabIndex = 12
        Me.lblPeriodo.Text = "Periodo"
        '
        'gbxCuit
        '
        Me.gbxCuit.Controls.Add(Me.cmdCancelar)
        Me.gbxCuit.Controls.Add(Me.cmdSimularLiquidacion)
        Me.gbxCuit.Controls.Add(Me.btnCopiarMonto)
        Me.gbxCuit.Controls.Add(Me.mebMontoFactura)
        Me.gbxCuit.Controls.Add(Me.cmbTipoComprobante)
        Me.gbxCuit.Controls.Add(Me.lblTipoComprobante)
        Me.gbxCuit.Controls.Add(Me.mebExpediente)
        Me.gbxCuit.Controls.Add(Me.lblExpediente)
        Me.gbxCuit.Controls.Add(Me.btnBuscarCuit)
        Me.gbxCuit.Controls.Add(Me.lblMontoLiquidado)
        Me.gbxCuit.Controls.Add(Me.lblSeleccioneFactura)
        Me.gbxCuit.Controls.Add(Me.lblRazonSocialPrestador)
        Me.gbxCuit.Controls.Add(Me.cmbFacturas)
        Me.gbxCuit.Controls.Add(Me.mebCuit)
        Me.gbxCuit.Controls.Add(Me.lblCuit)
        Me.gbxCuit.Controls.Add(Me.Button2)
        Me.gbxCuit.Font = New System.Drawing.Font("Lucida Bright", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbxCuit.Location = New System.Drawing.Point(3, 51)
        Me.gbxCuit.Name = "gbxCuit"
        Me.gbxCuit.Size = New System.Drawing.Size(657, 155)
        Me.gbxCuit.TabIndex = 11
        Me.gbxCuit.TabStop = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(370, 112)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(133, 28)
        Me.cmdCancelar.TabIndex = 15
        Me.cmdCancelar.Text = "cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdSimularLiquidacion
        '
        Me.cmdSimularLiquidacion.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSimularLiquidacion.Image = CType(resources.GetObject("cmdSimularLiquidacion.Image"), System.Drawing.Image)
        Me.cmdSimularLiquidacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSimularLiquidacion.Location = New System.Drawing.Point(370, 48)
        Me.cmdSimularLiquidacion.Name = "cmdSimularLiquidacion"
        Me.cmdSimularLiquidacion.Size = New System.Drawing.Size(133, 28)
        Me.cmdSimularLiquidacion.TabIndex = 13
        Me.cmdSimularLiquidacion.Text = "previsualizar"
        Me.cmdSimularLiquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSimularLiquidacion.UseVisualStyleBackColor = True
        Me.cmdSimularLiquidacion.Visible = False
        '
        'btnCopiarMonto
        '
        Me.btnCopiarMonto.Location = New System.Drawing.Point(546, 94)
        Me.btnCopiarMonto.Name = "btnCopiarMonto"
        Me.btnCopiarMonto.Size = New System.Drawing.Size(31, 22)
        Me.btnCopiarMonto.TabIndex = 12
        Me.btnCopiarMonto.Text = "c"
        Me.btnCopiarMonto.UseVisualStyleBackColor = True
        Me.btnCopiarMonto.Visible = False
        '
        'mebMontoFactura
        '
        Me.mebMontoFactura.AllowDrop = True
        Me.mebMontoFactura.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mebMontoFactura.Location = New System.Drawing.Point(211, 91)
        Me.mebMontoFactura.Name = "mebMontoFactura"
        Me.mebMontoFactura.Size = New System.Drawing.Size(143, 25)
        Me.mebMontoFactura.TabIndex = 8
        Me.mebMontoFactura.Visible = False
        '
        'cmbTipoComprobante
        '
        Me.cmbTipoComprobante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoComprobante.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoComprobante.FormattingEnabled = True
        Me.cmbTipoComprobante.Location = New System.Drawing.Point(211, 64)
        Me.cmbTipoComprobante.Name = "cmbTipoComprobante"
        Me.cmbTipoComprobante.Size = New System.Drawing.Size(143, 26)
        Me.cmbTipoComprobante.TabIndex = 7
        Me.cmbTipoComprobante.Visible = False
        '
        'lblTipoComprobante
        '
        Me.lblTipoComprobante.AutoSize = True
        Me.lblTipoComprobante.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoComprobante.Location = New System.Drawing.Point(66, 71)
        Me.lblTipoComprobante.Name = "lblTipoComprobante"
        Me.lblTipoComprobante.Size = New System.Drawing.Size(136, 18)
        Me.lblTipoComprobante.TabIndex = 11
        Me.lblTipoComprobante.Text = "Tipo Comprobante"
        Me.lblTipoComprobante.Visible = False
        '
        'mebExpediente
        '
        Me.mebExpediente.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mebExpediente.Location = New System.Drawing.Point(211, 118)
        Me.mebExpediente.Mask = "ex-0000-000000000"
        Me.mebExpediente.Name = "mebExpediente"
        Me.mebExpediente.Size = New System.Drawing.Size(143, 25)
        Me.mebExpediente.TabIndex = 9
        Me.mebExpediente.Visible = False
        '
        'lblExpediente
        '
        Me.lblExpediente.AutoSize = True
        Me.lblExpediente.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExpediente.Location = New System.Drawing.Point(114, 125)
        Me.lblExpediente.Name = "lblExpediente"
        Me.lblExpediente.Size = New System.Drawing.Size(88, 18)
        Me.lblExpediente.TabIndex = 9
        Me.lblExpediente.Text = "Expediente"
        Me.lblExpediente.Visible = False
        '
        'btnBuscarCuit
        '
        Me.btnBuscarCuit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnBuscarCuit.Image = CType(resources.GetObject("btnBuscarCuit.Image"), System.Drawing.Image)
        Me.btnBuscarCuit.Location = New System.Drawing.Point(331, 9)
        Me.btnBuscarCuit.Name = "btnBuscarCuit"
        Me.btnBuscarCuit.Size = New System.Drawing.Size(41, 27)
        Me.btnBuscarCuit.TabIndex = 5
        Me.btnBuscarCuit.UseVisualStyleBackColor = True
        '
        'lblMontoLiquidado
        '
        Me.lblMontoLiquidado.AutoSize = True
        Me.lblMontoLiquidado.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoLiquidado.Location = New System.Drawing.Point(10, 98)
        Me.lblMontoLiquidado.Name = "lblMontoLiquidado"
        Me.lblMontoLiquidado.Size = New System.Drawing.Size(192, 18)
        Me.lblMontoLiquidado.TabIndex = 7
        Me.lblMontoLiquidado.Text = "Ingrese monto Facturado"
        Me.lblMontoLiquidado.Visible = False
        '
        'lblSeleccioneFactura
        '
        Me.lblSeleccioneFactura.AutoSize = True
        Me.lblSeleccioneFactura.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSeleccioneFactura.Location = New System.Drawing.Point(18, 44)
        Me.lblSeleccioneFactura.Name = "lblSeleccioneFactura"
        Me.lblSeleccioneFactura.Size = New System.Drawing.Size(184, 18)
        Me.lblSeleccioneFactura.TabIndex = 6
        Me.lblSeleccioneFactura.Text = "Seleccione una factura"
        Me.lblSeleccioneFactura.Visible = False
        '
        'lblRazonSocialPrestador
        '
        Me.lblRazonSocialPrestador.AutoSize = True
        Me.lblRazonSocialPrestador.Location = New System.Drawing.Point(282, 21)
        Me.lblRazonSocialPrestador.Name = "lblRazonSocialPrestador"
        Me.lblRazonSocialPrestador.Size = New System.Drawing.Size(0, 14)
        Me.lblRazonSocialPrestador.TabIndex = 5
        '
        'cmbFacturas
        '
        Me.cmbFacturas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFacturas.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFacturas.FormattingEnabled = True
        Me.cmbFacturas.Location = New System.Drawing.Point(211, 37)
        Me.cmbFacturas.Name = "cmbFacturas"
        Me.cmbFacturas.Size = New System.Drawing.Size(143, 26)
        Me.cmbFacturas.TabIndex = 6
        Me.cmbFacturas.Visible = False
        '
        'mebCuit
        '
        Me.mebCuit.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mebCuit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.mebCuit.Location = New System.Drawing.Point(211, 10)
        Me.mebCuit.Mask = "00-00000000-0"
        Me.mebCuit.Name = "mebCuit"
        Me.mebCuit.Size = New System.Drawing.Size(114, 25)
        Me.mebCuit.TabIndex = 4
        '
        'lblCuit
        '
        Me.lblCuit.AutoSize = True
        Me.lblCuit.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuit.Location = New System.Drawing.Point(162, 17)
        Me.lblCuit.Name = "lblCuit"
        Me.lblCuit.Size = New System.Drawing.Size(40, 18)
        Me.lblCuit.TabIndex = 0
        Me.lblCuit.Text = "Cuit"
        '
        'dgvDebitos
        '
        Me.dgvDebitos.BackgroundColor = System.Drawing.Color.White
        Me.dgvDebitos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvDebitos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDebitos.Location = New System.Drawing.Point(4, 465)
        Me.dgvDebitos.Name = "dgvDebitos"
        Me.dgvDebitos.Size = New System.Drawing.Size(647, 123)
        Me.dgvDebitos.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 449)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 18)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "detalle débitos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 209)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(160, 18)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "detalle liquidación"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblDiferenciaFActurado)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.lblImporteFacturadoElectronico)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.lblNumeroLiquidacion)
        Me.GroupBox2.Controls.Add(Me.lblNumeroDebito)
        Me.GroupBox2.Controls.Add(Me.lblImporteDebitado)
        Me.GroupBox2.Controls.Add(Me.lblImporteLiquidado)
        Me.GroupBox2.Controls.Add(Me.lblImporteFacturado)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.txtObservaciones)
        Me.GroupBox2.Font = New System.Drawing.Font("Lucida Bright", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(671, 5)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox2.Size = New System.Drawing.Size(314, 202)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "información general"
        '
        'lblDiferenciaFActurado
        '
        Me.lblDiferenciaFActurado.AutoSize = True
        Me.lblDiferenciaFActurado.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferenciaFActurado.Location = New System.Drawing.Point(150, 126)
        Me.lblDiferenciaFActurado.Name = "lblDiferenciaFActurado"
        Me.lblDiferenciaFActurado.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblDiferenciaFActurado.Size = New System.Drawing.Size(48, 18)
        Me.lblDiferenciaFActurado.TabIndex = 32
        Me.lblDiferenciaFActurado.Text = ". . ."
        Me.lblDiferenciaFActurado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(32, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(112, 18)
        Me.Label9.TabIndex = 31
        Me.Label9.Text = "$ diferencia:"
        '
        'lblImporteFacturadoElectronico
        '
        Me.lblImporteFacturadoElectronico.AutoSize = True
        Me.lblImporteFacturadoElectronico.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteFacturadoElectronico.Location = New System.Drawing.Point(150, 80)
        Me.lblImporteFacturadoElectronico.Name = "lblImporteFacturadoElectronico"
        Me.lblImporteFacturadoElectronico.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblImporteFacturadoElectronico.Size = New System.Drawing.Size(48, 18)
        Me.lblImporteFacturadoElectronico.TabIndex = 30
        Me.lblImporteFacturadoElectronico.Text = ". . ."
        Me.lblImporteFacturadoElectronico.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(16, 80)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 18)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "$ fact. elect.:"
        '
        'lblNumeroLiquidacion
        '
        Me.lblNumeroLiquidacion.AutoSize = True
        Me.lblNumeroLiquidacion.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroLiquidacion.Location = New System.Drawing.Point(150, 34)
        Me.lblNumeroLiquidacion.Name = "lblNumeroLiquidacion"
        Me.lblNumeroLiquidacion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNumeroLiquidacion.Size = New System.Drawing.Size(48, 18)
        Me.lblNumeroLiquidacion.TabIndex = 28
        Me.lblNumeroLiquidacion.Text = ". . ."
        Me.lblNumeroLiquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblNumeroDebito
        '
        Me.lblNumeroDebito.AutoSize = True
        Me.lblNumeroDebito.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDebito.Location = New System.Drawing.Point(150, 57)
        Me.lblNumeroDebito.Name = "lblNumeroDebito"
        Me.lblNumeroDebito.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblNumeroDebito.Size = New System.Drawing.Size(48, 18)
        Me.lblNumeroDebito.TabIndex = 27
        Me.lblNumeroDebito.Text = ". . ."
        Me.lblNumeroDebito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteDebitado
        '
        Me.lblImporteDebitado.AutoSize = True
        Me.lblImporteDebitado.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteDebitado.Location = New System.Drawing.Point(150, 172)
        Me.lblImporteDebitado.Name = "lblImporteDebitado"
        Me.lblImporteDebitado.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblImporteDebitado.Size = New System.Drawing.Size(48, 18)
        Me.lblImporteDebitado.TabIndex = 26
        Me.lblImporteDebitado.Text = ". . ."
        Me.lblImporteDebitado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteLiquidado
        '
        Me.lblImporteLiquidado.AutoSize = True
        Me.lblImporteLiquidado.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteLiquidado.Location = New System.Drawing.Point(150, 149)
        Me.lblImporteLiquidado.Name = "lblImporteLiquidado"
        Me.lblImporteLiquidado.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblImporteLiquidado.Size = New System.Drawing.Size(48, 18)
        Me.lblImporteLiquidado.TabIndex = 25
        Me.lblImporteLiquidado.Text = ". . ."
        Me.lblImporteLiquidado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteFacturado
        '
        Me.lblImporteFacturado.AllowDrop = True
        Me.lblImporteFacturado.AutoSize = True
        Me.lblImporteFacturado.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteFacturado.Location = New System.Drawing.Point(150, 103)
        Me.lblImporteFacturado.Name = "lblImporteFacturado"
        Me.lblImporteFacturado.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblImporteFacturado.Size = New System.Drawing.Size(48, 18)
        Me.lblImporteFacturado.TabIndex = 24
        Me.lblImporteFacturado.Text = ". . ."
        Me.lblImporteFacturado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(48, 172)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 18)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "$ debitado:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(40, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 18)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "$ liquidado:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(40, 103)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 18)
        Me.Label4.TabIndex = 18
        Me.Label4.Text = "$ facturado:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(56, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 18)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "debito n°:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 18)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "liquidacion n°:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Font = New System.Drawing.Font("Lucida Bright", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(128, 55)
        Me.txtObservaciones.MaxLength = 200
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(197, 155)
        Me.txtObservaciones.TabIndex = 25
        Me.txtObservaciones.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Lucida Bright", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(900, 209)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(89, 14)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Observaciones"
        Me.Label10.Visible = False
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.Image = CType(resources.GetObject("cmdCerrar.Image"), System.Drawing.Image)
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(868, 551)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(99, 28)
        Me.cmdCerrar.TabIndex = 13
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'gbInfoConsolidacion
        '
        Me.gbInfoConsolidacion.Controls.Add(Me.lblTotalFacturadoConsolidado)
        Me.gbInfoConsolidacion.Controls.Add(Me.lblTotalAutorizadoConsolidado)
        Me.gbInfoConsolidacion.Controls.Add(Me.lblFacturasConsolidadasComprobante)
        Me.gbInfoConsolidacion.Controls.Add(Me.lblFacturacionConsolidadaPeriodoB)
        Me.gbInfoConsolidacion.Controls.Add(Me.lblFacturacionConsolidadaPeriodoA)
        Me.gbInfoConsolidacion.Controls.Add(Me.lblAutorizacionConsolidadaPeriodoB)
        Me.gbInfoConsolidacion.Controls.Add(Me.lblAutorizacionConsolidadaPeriodoA)
        Me.gbInfoConsolidacion.Font = New System.Drawing.Font("Lucida Bright", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbInfoConsolidacion.Location = New System.Drawing.Point(790, 25)
        Me.gbInfoConsolidacion.Name = "gbInfoConsolidacion"
        Me.gbInfoConsolidacion.Size = New System.Drawing.Size(177, 168)
        Me.gbInfoConsolidacion.TabIndex = 27
        Me.gbInfoConsolidacion.TabStop = False
        '
        'lblTotalFacturadoConsolidado
        '
        Me.lblTotalFacturadoConsolidado.AutoSize = True
        Me.lblTotalFacturadoConsolidado.Location = New System.Drawing.Point(6, 162)
        Me.lblTotalFacturadoConsolidado.Name = "lblTotalFacturadoConsolidado"
        Me.lblTotalFacturadoConsolidado.Size = New System.Drawing.Size(22, 14)
        Me.lblTotalFacturadoConsolidado.TabIndex = 9
        Me.lblTotalFacturadoConsolidado.Text = ". . ."
        '
        'lblTotalAutorizadoConsolidado
        '
        Me.lblTotalAutorizadoConsolidado.AutoSize = True
        Me.lblTotalAutorizadoConsolidado.Location = New System.Drawing.Point(6, 140)
        Me.lblTotalAutorizadoConsolidado.Name = "lblTotalAutorizadoConsolidado"
        Me.lblTotalAutorizadoConsolidado.Size = New System.Drawing.Size(22, 14)
        Me.lblTotalAutorizadoConsolidado.TabIndex = 8
        Me.lblTotalAutorizadoConsolidado.Text = ". . ."
        '
        'lblFacturasConsolidadasComprobante
        '
        Me.lblFacturasConsolidadasComprobante.AutoSize = True
        Me.lblFacturasConsolidadasComprobante.Location = New System.Drawing.Point(6, 118)
        Me.lblFacturasConsolidadasComprobante.Name = "lblFacturasConsolidadasComprobante"
        Me.lblFacturasConsolidadasComprobante.Size = New System.Drawing.Size(22, 14)
        Me.lblFacturasConsolidadasComprobante.TabIndex = 7
        Me.lblFacturasConsolidadasComprobante.Text = ". . ."
        '
        'lblFacturacionConsolidadaPeriodoB
        '
        Me.lblFacturacionConsolidadaPeriodoB.AutoSize = True
        Me.lblFacturacionConsolidadaPeriodoB.Location = New System.Drawing.Point(6, 96)
        Me.lblFacturacionConsolidadaPeriodoB.Name = "lblFacturacionConsolidadaPeriodoB"
        Me.lblFacturacionConsolidadaPeriodoB.Size = New System.Drawing.Size(22, 14)
        Me.lblFacturacionConsolidadaPeriodoB.TabIndex = 6
        Me.lblFacturacionConsolidadaPeriodoB.Text = ". . ."
        '
        'lblFacturacionConsolidadaPeriodoA
        '
        Me.lblFacturacionConsolidadaPeriodoA.AutoSize = True
        Me.lblFacturacionConsolidadaPeriodoA.Location = New System.Drawing.Point(6, 52)
        Me.lblFacturacionConsolidadaPeriodoA.Name = "lblFacturacionConsolidadaPeriodoA"
        Me.lblFacturacionConsolidadaPeriodoA.Size = New System.Drawing.Size(22, 14)
        Me.lblFacturacionConsolidadaPeriodoA.TabIndex = 5
        Me.lblFacturacionConsolidadaPeriodoA.Text = ". . ."
        '
        'lblAutorizacionConsolidadaPeriodoB
        '
        Me.lblAutorizacionConsolidadaPeriodoB.AutoSize = True
        Me.lblAutorizacionConsolidadaPeriodoB.Location = New System.Drawing.Point(6, 74)
        Me.lblAutorizacionConsolidadaPeriodoB.Name = "lblAutorizacionConsolidadaPeriodoB"
        Me.lblAutorizacionConsolidadaPeriodoB.Size = New System.Drawing.Size(22, 14)
        Me.lblAutorizacionConsolidadaPeriodoB.TabIndex = 4
        Me.lblAutorizacionConsolidadaPeriodoB.Text = ". . ."
        '
        'lblAutorizacionConsolidadaPeriodoA
        '
        Me.lblAutorizacionConsolidadaPeriodoA.AutoSize = True
        Me.lblAutorizacionConsolidadaPeriodoA.Location = New System.Drawing.Point(6, 30)
        Me.lblAutorizacionConsolidadaPeriodoA.Name = "lblAutorizacionConsolidadaPeriodoA"
        Me.lblAutorizacionConsolidadaPeriodoA.Size = New System.Drawing.Size(22, 14)
        Me.lblAutorizacionConsolidadaPeriodoA.TabIndex = 3
        Me.lblAutorizacionConsolidadaPeriodoA.Text = ". . ."
        '
        'frmLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(988, 591)
        Me.Controls.Add(Me.dgvDebitos)
        Me.Controls.Add(Me.dgvLiquidacion)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gbInfoConsolidacion)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.gbxCuit)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmLiquidacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmLiquidacion"
        CType(Me.dgvLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gbxCuit.ResumeLayout(False)
        Me.gbxCuit.PerformLayout()
        CType(Me.dgvDebitos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gbInfoConsolidacion.ResumeLayout(False)
        Me.gbInfoConsolidacion.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents dgvLiquidacion As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblAutorizacionExistente As System.Windows.Forms.Label
    Friend WithEvents cmdAceptarPeriodo As System.Windows.Forms.Button
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents gbxCuit As System.Windows.Forms.GroupBox
    Friend WithEvents mebCuit As System.Windows.Forms.MaskedTextBox
    Friend WithEvents btnBuscarCuit As System.Windows.Forms.Button
    Friend WithEvents lblCuit As System.Windows.Forms.Label
    Friend WithEvents cmbFacturas As System.Windows.Forms.ComboBox
    Friend WithEvents lblRazonSocialPrestador As System.Windows.Forms.Label
    Friend WithEvents lblSeleccioneFactura As System.Windows.Forms.Label
    Friend WithEvents dgvDebitos As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblMontoLiquidado As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblExpediente As System.Windows.Forms.Label
    Friend WithEvents mebExpediente As System.Windows.Forms.MaskedTextBox
    Friend WithEvents lblTipoComprobante As System.Windows.Forms.Label
    Friend WithEvents cmbTipoComprobante As System.Windows.Forms.ComboBox
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents mebMontoFactura As System.Windows.Forms.TextBox
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents gbInfoConsolidacion As System.Windows.Forms.GroupBox
    Friend WithEvents lblAutorizacionConsolidadaPeriodoA As System.Windows.Forms.Label
    Friend WithEvents lblAutorizacionConsolidadaPeriodoB As System.Windows.Forms.Label
    Friend WithEvents lblFacturacionConsolidadaPeriodoA As System.Windows.Forms.Label
    Friend WithEvents lblFacturacionConsolidadaPeriodoB As System.Windows.Forms.Label
    Friend WithEvents lblTotalFacturadoConsolidado As System.Windows.Forms.Label
    Friend WithEvents lblTotalAutorizadoConsolidado As System.Windows.Forms.Label
    Friend WithEvents lblFacturasConsolidadasComprobante As System.Windows.Forms.Label
    Friend WithEvents btnCopiarMonto As System.Windows.Forms.Button
    Friend WithEvents lblImporteDebitado As System.Windows.Forms.Label
    Friend WithEvents lblImporteLiquidado As System.Windows.Forms.Label
    Friend WithEvents lblImporteFacturado As System.Windows.Forms.Label
    Friend WithEvents cmdSimularLiquidacion As System.Windows.Forms.Button
    Friend WithEvents lblNumeroDebito As System.Windows.Forms.Label
    Friend WithEvents lblNumeroLiquidacion As System.Windows.Forms.Label
    Friend WithEvents cmbMonthM As ComboBox
    Friend WithEvents cmbYearM As ComboBox
    Friend WithEvents lblImporteFacturadoElectronico As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents lblDiferenciaFActurado As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents cmdCancelar As Button
End Class
