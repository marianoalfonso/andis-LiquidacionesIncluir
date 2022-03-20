<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSimulacionLiquidacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSimulacionLiquidacion))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dgvLiquidacion = New System.Windows.Forms.DataGridView()
        Me.lblPeriodoSimulado = New System.Windows.Forms.Label()
        Me.lblCuitPrestador = New System.Windows.Forms.Label()
        Me.lblFacturaSimulada = New System.Windows.Forms.Label()
        Me.cmdCerrarFormulario = New System.Windows.Forms.Button()
        Me.lblTotalFacturado = New System.Windows.Forms.Label()
        Me.lblTotalAutorizado = New System.Windows.Forms.Label()
        Me.lblTotalDebitado = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.lblErrorSuma = New System.Windows.Forms.Label()
        Me.lblTotalFacturaFisica = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblMensaje = New System.Windows.Forms.Label()
        CType(Me.dgvLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(32, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(256, 18)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "previsualización de liquidación"
        '
        'dgvLiquidacion
        '
        Me.dgvLiquidacion.AllowUserToAddRows = False
        Me.dgvLiquidacion.AllowUserToDeleteRows = False
        Me.dgvLiquidacion.AllowUserToResizeRows = False
        Me.dgvLiquidacion.BackgroundColor = System.Drawing.SystemColors.Window
        Me.dgvLiquidacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvLiquidacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken
        Me.dgvLiquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLiquidacion.Location = New System.Drawing.Point(4, 94)
        Me.dgvLiquidacion.MultiSelect = False
        Me.dgvLiquidacion.Name = "dgvLiquidacion"
        Me.dgvLiquidacion.ReadOnly = True
        Me.dgvLiquidacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLiquidacion.Size = New System.Drawing.Size(979, 492)
        Me.dgvLiquidacion.TabIndex = 19
        '
        'lblPeriodoSimulado
        '
        Me.lblPeriodoSimulado.AutoSize = True
        Me.lblPeriodoSimulado.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodoSimulado.Location = New System.Drawing.Point(104, 8)
        Me.lblPeriodoSimulado.Name = "lblPeriodoSimulado"
        Me.lblPeriodoSimulado.Size = New System.Drawing.Size(48, 18)
        Me.lblPeriodoSimulado.TabIndex = 21
        Me.lblPeriodoSimulado.Text = ". . ."
        '
        'lblCuitPrestador
        '
        Me.lblCuitPrestador.AutoSize = True
        Me.lblCuitPrestador.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuitPrestador.Location = New System.Drawing.Point(104, 26)
        Me.lblCuitPrestador.Name = "lblCuitPrestador"
        Me.lblCuitPrestador.Size = New System.Drawing.Size(48, 18)
        Me.lblCuitPrestador.TabIndex = 22
        Me.lblCuitPrestador.Text = ". . ."
        '
        'lblFacturaSimulada
        '
        Me.lblFacturaSimulada.AutoSize = True
        Me.lblFacturaSimulada.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFacturaSimulada.Location = New System.Drawing.Point(104, 44)
        Me.lblFacturaSimulada.Name = "lblFacturaSimulada"
        Me.lblFacturaSimulada.Size = New System.Drawing.Size(48, 18)
        Me.lblFacturaSimulada.TabIndex = 23
        Me.lblFacturaSimulada.Text = ". . ."
        '
        'cmdCerrarFormulario
        '
        Me.cmdCerrarFormulario.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrarFormulario.Image = CType(resources.GetObject("cmdCerrarFormulario.Image"), System.Drawing.Image)
        Me.cmdCerrarFormulario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrarFormulario.Location = New System.Drawing.Point(881, 590)
        Me.cmdCerrarFormulario.Name = "cmdCerrarFormulario"
        Me.cmdCerrarFormulario.Size = New System.Drawing.Size(91, 27)
        Me.cmdCerrarFormulario.TabIndex = 24
        Me.cmdCerrarFormulario.Text = "cerrar"
        Me.cmdCerrarFormulario.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrarFormulario.UseVisualStyleBackColor = True
        '
        'lblTotalFacturado
        '
        Me.lblTotalFacturado.AutoSize = True
        Me.lblTotalFacturado.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFacturado.Location = New System.Drawing.Point(400, 8)
        Me.lblTotalFacturado.Name = "lblTotalFacturado"
        Me.lblTotalFacturado.Size = New System.Drawing.Size(48, 18)
        Me.lblTotalFacturado.TabIndex = 25
        Me.lblTotalFacturado.Text = ". . ."
        '
        'lblTotalAutorizado
        '
        Me.lblTotalAutorizado.AutoSize = True
        Me.lblTotalAutorizado.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAutorizado.Location = New System.Drawing.Point(400, 26)
        Me.lblTotalAutorizado.Name = "lblTotalAutorizado"
        Me.lblTotalAutorizado.Size = New System.Drawing.Size(48, 18)
        Me.lblTotalAutorizado.TabIndex = 26
        Me.lblTotalAutorizado.Text = ". . ."
        '
        'lblTotalDebitado
        '
        Me.lblTotalDebitado.AutoSize = True
        Me.lblTotalDebitado.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalDebitado.Location = New System.Drawing.Point(400, 44)
        Me.lblTotalDebitado.Name = "lblTotalDebitado"
        Me.lblTotalDebitado.Size = New System.Drawing.Size(48, 18)
        Me.lblTotalDebitado.TabIndex = 27
        Me.lblTotalDebitado.Text = ". . ."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(783, 76)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 37
        Me.Label4.Text = "débito"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(866, 76)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 15)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "crédito"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(922, 72)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(21, 19)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 39
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(833, 72)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(21, 19)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 40
        Me.PictureBox2.TabStop = False
        '
        'lblErrorSuma
        '
        Me.lblErrorSuma.AutoSize = True
        Me.lblErrorSuma.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblErrorSuma.Location = New System.Drawing.Point(674, 26)
        Me.lblErrorSuma.Name = "lblErrorSuma"
        Me.lblErrorSuma.Size = New System.Drawing.Size(48, 18)
        Me.lblErrorSuma.TabIndex = 42
        Me.lblErrorSuma.Text = ". . ."
        '
        'lblTotalFacturaFisica
        '
        Me.lblTotalFacturaFisica.AutoSize = True
        Me.lblTotalFacturaFisica.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFacturaFisica.Location = New System.Drawing.Point(674, 8)
        Me.lblTotalFacturaFisica.Name = "lblTotalFacturaFisica"
        Me.lblTotalFacturaFisica.Size = New System.Drawing.Size(48, 18)
        Me.lblTotalFacturaFisica.TabIndex = 41
        Me.lblTotalFacturaFisica.Text = ". . ."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(27, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 18)
        Me.Label1.TabIndex = 43
        Me.Label1.Text = "periodo:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 18)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "cuit:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(27, 44)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 18)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "factura:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(218, 8)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(176, 18)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "tot.fact.electronica:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(532, 8)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(136, 18)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "tot.fact.física:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(250, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(144, 18)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "total autorizado:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(274, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 18)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "dif. aut/fact:"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(548, 26)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(120, 18)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "error de suma:"
        '
        'lblMensaje
        '
        Me.lblMensaje.AutoSize = True
        Me.lblMensaje.Font = New System.Drawing.Font("Lucida Bright", 8.25!)
        Me.lblMensaje.Location = New System.Drawing.Point(290, 80)
        Me.lblMensaje.Name = "lblMensaje"
        Me.lblMensaje.Size = New System.Drawing.Size(0, 14)
        Me.lblMensaje.TabIndex = 51
        '
        'frmSimulacionLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(988, 619)
        Me.Controls.Add(Me.dgvLiquidacion)
        Me.Controls.Add(Me.lblMensaje)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblErrorSuma)
        Me.Controls.Add(Me.lblTotalFacturaFisica)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblTotalDebitado)
        Me.Controls.Add(Me.lblTotalAutorizado)
        Me.Controls.Add(Me.lblTotalFacturado)
        Me.Controls.Add(Me.cmdCerrarFormulario)
        Me.Controls.Add(Me.lblFacturaSimulada)
        Me.Controls.Add(Me.lblCuitPrestador)
        Me.Controls.Add(Me.lblPeriodoSimulado)
        Me.Controls.Add(Me.Label3)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSimulacionLiquidacion"
        Me.Text = "frmSimulacionLiquidacion"
        CType(Me.dgvLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvLiquidacion As System.Windows.Forms.DataGridView
    Friend WithEvents lblPeriodoSimulado As System.Windows.Forms.Label
    Friend WithEvents lblCuitPrestador As System.Windows.Forms.Label
    Friend WithEvents lblFacturaSimulada As System.Windows.Forms.Label
    Friend WithEvents cmdCerrarFormulario As System.Windows.Forms.Button
    Friend WithEvents lblTotalFacturado As System.Windows.Forms.Label
    Friend WithEvents lblTotalAutorizado As System.Windows.Forms.Label
    Friend WithEvents lblTotalDebitado As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents lblErrorSuma As System.Windows.Forms.Label
    Friend WithEvents lblTotalFacturaFisica As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblMensaje As System.Windows.Forms.Label
End Class
