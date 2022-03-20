<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm02002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm02002))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkCuit = New System.Windows.Forms.CheckBox()
        Me.mebCuit = New System.Windows.Forms.MaskedTextBox()
        Me.tbxRazonSocial = New System.Windows.Forms.TextBox()
        Me.chkRazonSocial = New System.Windows.Forms.CheckBox()
        Me.tbxCodigo = New System.Windows.Forms.TextBox()
        Me.chkCodigo = New System.Windows.Forms.CheckBox()
        Me.chkPeriodo = New System.Windows.Forms.CheckBox()
        Me.cmdAceptarPeriodo = New System.Windows.Forms.Button()
        Me.cmbYearM = New System.Windows.Forms.ComboBox()
        Me.cmbMonthM = New System.Windows.Forms.ComboBox()
        Me.dtgAutorizaciones = New System.Windows.Forms.DataGridView()
        Me.dtvDetalleAutorizacion = New System.Windows.Forms.DataGridView()
        Me.btnDetalleAutorizacion = New System.Windows.Forms.Button()
        Me.btnExportar = New System.Windows.Forms.Button()
        Me.btnBorrarAutorizacion = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnLiquidaciones = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnBorrarPeriodo = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtgAutorizaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtvDetalleAutorizacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkCuit)
        Me.GroupBox2.Controls.Add(Me.mebCuit)
        Me.GroupBox2.Controls.Add(Me.tbxRazonSocial)
        Me.GroupBox2.Controls.Add(Me.chkRazonSocial)
        Me.GroupBox2.Controls.Add(Me.tbxCodigo)
        Me.GroupBox2.Controls.Add(Me.chkCodigo)
        Me.GroupBox2.Controls.Add(Me.chkPeriodo)
        Me.GroupBox2.Controls.Add(Me.cmdAceptarPeriodo)
        Me.GroupBox2.Controls.Add(Me.cmbYearM)
        Me.GroupBox2.Controls.Add(Me.cmbMonthM)
        Me.GroupBox2.Font = New System.Drawing.Font("Lucida Bright", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, -7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(963, 92)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        '
        'chkCuit
        '
        Me.chkCuit.AutoSize = True
        Me.chkCuit.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCuit.Location = New System.Drawing.Point(430, 18)
        Me.chkCuit.Name = "chkCuit"
        Me.chkCuit.Size = New System.Drawing.Size(59, 22)
        Me.chkCuit.TabIndex = 23
        Me.chkCuit.Text = "cuit"
        Me.chkCuit.UseVisualStyleBackColor = True
        '
        'mebCuit
        '
        Me.mebCuit.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.mebCuit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.mebCuit.Location = New System.Drawing.Point(430, 46)
        Me.mebCuit.Mask = "00-00000000-0"
        Me.mebCuit.Name = "mebCuit"
        Me.mebCuit.Size = New System.Drawing.Size(133, 25)
        Me.mebCuit.TabIndex = 22
        '
        'tbxRazonSocial
        '
        Me.tbxRazonSocial.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxRazonSocial.Location = New System.Drawing.Point(591, 46)
        Me.tbxRazonSocial.Name = "tbxRazonSocial"
        Me.tbxRazonSocial.Size = New System.Drawing.Size(244, 25)
        Me.tbxRazonSocial.TabIndex = 21
        '
        'chkRazonSocial
        '
        Me.chkRazonSocial.AutoSize = True
        Me.chkRazonSocial.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRazonSocial.Location = New System.Drawing.Point(591, 18)
        Me.chkRazonSocial.Name = "chkRazonSocial"
        Me.chkRazonSocial.Size = New System.Drawing.Size(123, 22)
        Me.chkRazonSocial.TabIndex = 20
        Me.chkRazonSocial.Text = "razon social"
        Me.chkRazonSocial.UseVisualStyleBackColor = True
        '
        'tbxCodigo
        '
        Me.tbxCodigo.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCodigo.Location = New System.Drawing.Point(231, 46)
        Me.tbxCodigo.Name = "tbxCodigo"
        Me.tbxCodigo.Size = New System.Drawing.Size(175, 25)
        Me.tbxCodigo.TabIndex = 19
        '
        'chkCodigo
        '
        Me.chkCodigo.AutoSize = True
        Me.chkCodigo.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCodigo.Location = New System.Drawing.Point(229, 18)
        Me.chkCodigo.Name = "chkCodigo"
        Me.chkCodigo.Size = New System.Drawing.Size(155, 22)
        Me.chkCodigo.TabIndex = 18
        Me.chkCodigo.Text = "codigo prestador"
        Me.chkCodigo.UseVisualStyleBackColor = True
        '
        'chkPeriodo
        '
        Me.chkPeriodo.AutoSize = True
        Me.chkPeriodo.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPeriodo.Location = New System.Drawing.Point(11, 18)
        Me.chkPeriodo.Name = "chkPeriodo"
        Me.chkPeriodo.Size = New System.Drawing.Size(83, 22)
        Me.chkPeriodo.TabIndex = 17
        Me.chkPeriodo.Text = "periodo"
        Me.chkPeriodo.UseVisualStyleBackColor = True
        '
        'cmdAceptarPeriodo
        '
        Me.cmdAceptarPeriodo.Image = CType(resources.GetObject("cmdAceptarPeriodo.Image"), System.Drawing.Image)
        Me.cmdAceptarPeriodo.Location = New System.Drawing.Point(856, 38)
        Me.cmdAceptarPeriodo.Name = "cmdAceptarPeriodo"
        Me.cmdAceptarPeriodo.Size = New System.Drawing.Size(61, 34)
        Me.cmdAceptarPeriodo.TabIndex = 3
        Me.cmdAceptarPeriodo.UseVisualStyleBackColor = True
        '
        'cmbYearM
        '
        Me.cmbYearM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYearM.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbYearM.FormattingEnabled = True
        Me.cmbYearM.Location = New System.Drawing.Point(126, 46)
        Me.cmbYearM.Name = "cmbYearM"
        Me.cmbYearM.Size = New System.Drawing.Size(75, 26)
        Me.cmbYearM.TabIndex = 16
        '
        'cmbMonthM
        '
        Me.cmbMonthM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMonthM.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMonthM.FormattingEnabled = True
        Me.cmbMonthM.Location = New System.Drawing.Point(11, 46)
        Me.cmbMonthM.Name = "cmbMonthM"
        Me.cmbMonthM.Size = New System.Drawing.Size(108, 26)
        Me.cmbMonthM.TabIndex = 15
        '
        'dtgAutorizaciones
        '
        Me.dtgAutorizaciones.AllowUserToAddRows = False
        Me.dtgAutorizaciones.AllowUserToDeleteRows = False
        Me.dtgAutorizaciones.AllowUserToOrderColumns = True
        Me.dtgAutorizaciones.BackgroundColor = System.Drawing.Color.White
        Me.dtgAutorizaciones.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dtgAutorizaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAutorizaciones.Location = New System.Drawing.Point(4, 117)
        Me.dtgAutorizaciones.MultiSelect = False
        Me.dtgAutorizaciones.Name = "dtgAutorizaciones"
        Me.dtgAutorizaciones.ReadOnly = True
        Me.dtgAutorizaciones.Size = New System.Drawing.Size(711, 162)
        Me.dtgAutorizaciones.TabIndex = 12
        '
        'dtvDetalleAutorizacion
        '
        Me.dtvDetalleAutorizacion.AllowUserToAddRows = False
        Me.dtvDetalleAutorizacion.AllowUserToDeleteRows = False
        Me.dtvDetalleAutorizacion.AllowUserToOrderColumns = True
        Me.dtvDetalleAutorizacion.BackgroundColor = System.Drawing.Color.White
        Me.dtvDetalleAutorizacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dtvDetalleAutorizacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtvDetalleAutorizacion.Location = New System.Drawing.Point(4, 307)
        Me.dtvDetalleAutorizacion.MultiSelect = False
        Me.dtvDetalleAutorizacion.Name = "dtvDetalleAutorizacion"
        Me.dtvDetalleAutorizacion.ReadOnly = True
        Me.dtvDetalleAutorizacion.Size = New System.Drawing.Size(965, 258)
        Me.dtvDetalleAutorizacion.TabIndex = 13
        '
        'btnDetalleAutorizacion
        '
        Me.btnDetalleAutorizacion.Image = CType(resources.GetObject("btnDetalleAutorizacion.Image"), System.Drawing.Image)
        Me.btnDetalleAutorizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDetalleAutorizacion.Location = New System.Drawing.Point(734, 106)
        Me.btnDetalleAutorizacion.Name = "btnDetalleAutorizacion"
        Me.btnDetalleAutorizacion.Size = New System.Drawing.Size(175, 29)
        Me.btnDetalleAutorizacion.TabIndex = 14
        Me.btnDetalleAutorizacion.Text = "ver detalle"
        Me.btnDetalleAutorizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDetalleAutorizacion.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Enabled = False
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportar.Location = New System.Drawing.Point(734, 233)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(175, 29)
        Me.btnExportar.TabIndex = 15
        Me.btnExportar.Text = "exportar"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'btnBorrarAutorizacion
        '
        Me.btnBorrarAutorizacion.Enabled = False
        Me.btnBorrarAutorizacion.Image = CType(resources.GetObject("btnBorrarAutorizacion.Image"), System.Drawing.Image)
        Me.btnBorrarAutorizacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrarAutorizacion.Location = New System.Drawing.Point(734, 169)
        Me.btnBorrarAutorizacion.Name = "btnBorrarAutorizacion"
        Me.btnBorrarAutorizacion.Size = New System.Drawing.Size(175, 29)
        Me.btnBorrarAutorizacion.TabIndex = 16
        Me.btnBorrarAutorizacion.Text = "borrar autorizacion"
        Me.btnBorrarAutorizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBorrarAutorizacion.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(734, 265)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(175, 29)
        Me.btnCerrar.TabIndex = 19
        Me.btnCerrar.Text = "cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnLiquidaciones
        '
        Me.btnLiquidaciones.Image = CType(resources.GetObject("btnLiquidaciones.Image"), System.Drawing.Image)
        Me.btnLiquidaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLiquidaciones.Location = New System.Drawing.Point(734, 137)
        Me.btnLiquidaciones.Name = "btnLiquidaciones"
        Me.btnLiquidaciones.Size = New System.Drawing.Size(175, 29)
        Me.btnLiquidaciones.TabIndex = 20
        Me.btnLiquidaciones.Text = "ver liquidaciones"
        Me.btnLiquidaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLiquidaciones.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(15, 289)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(192, 18)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "detalle de autorización"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 18)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "autorizaciones"
        '
        'btnBorrarPeriodo
        '
        Me.btnBorrarPeriodo.Enabled = False
        Me.btnBorrarPeriodo.Image = CType(resources.GetObject("btnBorrarPeriodo.Image"), System.Drawing.Image)
        Me.btnBorrarPeriodo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrarPeriodo.Location = New System.Drawing.Point(734, 201)
        Me.btnBorrarPeriodo.Name = "btnBorrarPeriodo"
        Me.btnBorrarPeriodo.Size = New System.Drawing.Size(175, 29)
        Me.btnBorrarPeriodo.TabIndex = 23
        Me.btnBorrarPeriodo.Text = "borrar periodo"
        Me.btnBorrarPeriodo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBorrarPeriodo.UseVisualStyleBackColor = True
        '
        'frm02002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(974, 569)
        Me.Controls.Add(Me.btnBorrarPeriodo)
        Me.Controls.Add(Me.dtvDetalleAutorizacion)
        Me.Controls.Add(Me.dtgAutorizaciones)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnLiquidaciones)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnBorrarAutorizacion)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.btnDetalleAutorizacion)
        Me.Controls.Add(Me.GroupBox2)
        Me.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm02002"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frm02002"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dtgAutorizaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtvDetalleAutorizacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents cmbYearM As ComboBox
    Friend WithEvents cmbMonthM As ComboBox
    Friend WithEvents cmdAceptarPeriodo As Button
    Friend WithEvents chkPeriodo As CheckBox
    Friend WithEvents chkCodigo As CheckBox
    Friend WithEvents tbxCodigo As TextBox
    Friend WithEvents chkRazonSocial As CheckBox
    Friend WithEvents tbxRazonSocial As TextBox
    Friend WithEvents chkCuit As CheckBox
    Friend WithEvents mebCuit As MaskedTextBox
    Friend WithEvents dtgAutorizaciones As DataGridView
    Friend WithEvents dtvDetalleAutorizacion As DataGridView
    Friend WithEvents btnDetalleAutorizacion As Button
    Friend WithEvents btnExportar As Button
    Friend WithEvents btnBorrarAutorizacion As Button
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnLiquidaciones As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnBorrarPeriodo As Button
End Class
