<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmEliminarLiquidacion
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEliminarLiquidacion))
        Me.dgvLiquidaciones = New System.Windows.Forms.DataGridView()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdEliminarLiquidacion = New System.Windows.Forms.Button()
        Me.btReimprimir = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkCuit = New System.Windows.Forms.CheckBox()
        Me.mebCuit = New System.Windows.Forms.MaskedTextBox()
        Me.tbxRazonSocial = New System.Windows.Forms.TextBox()
        Me.chkRazonSocial = New System.Windows.Forms.CheckBox()
        Me.chkPeriodo = New System.Windows.Forms.CheckBox()
        Me.cmbYearM = New System.Windows.Forms.ComboBox()
        Me.cmbMonthM = New System.Windows.Forms.ComboBox()
        Me.cmdAceptarPeriodo = New System.Windows.Forms.Button()
        Me.tbxCodigo = New System.Windows.Forms.TextBox()
        Me.chkCodigo = New System.Windows.Forms.CheckBox()
        Me.cmdDetalle = New System.Windows.Forms.Button()
        CType(Me.dgvLiquidaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvLiquidaciones
        '
        Me.dgvLiquidaciones.AllowUserToAddRows = False
        Me.dgvLiquidaciones.AllowUserToDeleteRows = False
        Me.dgvLiquidaciones.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvLiquidaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvLiquidaciones.GridColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvLiquidaciones.Location = New System.Drawing.Point(4, 81)
        Me.dgvLiquidaciones.MultiSelect = False
        Me.dgvLiquidaciones.Name = "dgvLiquidaciones"
        Me.dgvLiquidaciones.ReadOnly = True
        Me.dgvLiquidaciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvLiquidaciones.ShowEditingIcon = False
        Me.dgvLiquidaciones.Size = New System.Drawing.Size(1110, 518)
        Me.dgvLiquidaciones.TabIndex = 8
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.Image = CType(resources.GetObject("cmdCerrar.Image"), System.Drawing.Image)
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(984, 42)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(130, 29)
        Me.cmdCerrar.TabIndex = 9
        Me.cmdCerrar.Text = "Cerrar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdEliminarLiquidacion
        '
        Me.cmdEliminarLiquidacion.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEliminarLiquidacion.Image = CType(resources.GetObject("cmdEliminarLiquidacion.Image"), System.Drawing.Image)
        Me.cmdEliminarLiquidacion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEliminarLiquidacion.Location = New System.Drawing.Point(836, 42)
        Me.cmdEliminarLiquidacion.Name = "cmdEliminarLiquidacion"
        Me.cmdEliminarLiquidacion.Size = New System.Drawing.Size(142, 29)
        Me.cmdEliminarLiquidacion.TabIndex = 10
        Me.cmdEliminarLiquidacion.Text = "borrar liquid."
        Me.cmdEliminarLiquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEliminarLiquidacion.UseVisualStyleBackColor = True
        '
        'btReimprimir
        '
        Me.btReimprimir.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btReimprimir.Image = CType(resources.GetObject("btReimprimir.Image"), System.Drawing.Image)
        Me.btReimprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btReimprimir.Location = New System.Drawing.Point(984, 9)
        Me.btReimprimir.Name = "btReimprimir"
        Me.btReimprimir.Size = New System.Drawing.Size(130, 29)
        Me.btReimprimir.TabIndex = 2
        Me.btReimprimir.Tag = "prueba tooltip"
        Me.btReimprimir.Text = "reimprimir"
        Me.btReimprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btReimprimir.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkCuit)
        Me.GroupBox2.Controls.Add(Me.mebCuit)
        Me.GroupBox2.Controls.Add(Me.tbxRazonSocial)
        Me.GroupBox2.Controls.Add(Me.chkRazonSocial)
        Me.GroupBox2.Controls.Add(Me.chkPeriodo)
        Me.GroupBox2.Controls.Add(Me.cmbYearM)
        Me.GroupBox2.Controls.Add(Me.cmbMonthM)
        Me.GroupBox2.Controls.Add(Me.cmdAceptarPeriodo)
        Me.GroupBox2.Controls.Add(Me.tbxCodigo)
        Me.GroupBox2.Controls.Add(Me.chkCodigo)
        Me.GroupBox2.Font = New System.Drawing.Font("Lucida Bright", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, -7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(822, 82)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'chkCuit
        '
        Me.chkCuit.AutoSize = True
        Me.chkCuit.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCuit.Location = New System.Drawing.Point(380, 18)
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
        Me.mebCuit.Location = New System.Drawing.Point(374, 46)
        Me.mebCuit.Mask = "00-00000000-0"
        Me.mebCuit.Name = "mebCuit"
        Me.mebCuit.Size = New System.Drawing.Size(115, 25)
        Me.mebCuit.TabIndex = 22
        '
        'tbxRazonSocial
        '
        Me.tbxRazonSocial.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxRazonSocial.Location = New System.Drawing.Point(497, 46)
        Me.tbxRazonSocial.Name = "tbxRazonSocial"
        Me.tbxRazonSocial.Size = New System.Drawing.Size(230, 25)
        Me.tbxRazonSocial.TabIndex = 21
        Me.tbxRazonSocial.Visible = False
        '
        'chkRazonSocial
        '
        Me.chkRazonSocial.AutoSize = True
        Me.chkRazonSocial.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRazonSocial.Location = New System.Drawing.Point(503, 18)
        Me.chkRazonSocial.Name = "chkRazonSocial"
        Me.chkRazonSocial.Size = New System.Drawing.Size(123, 22)
        Me.chkRazonSocial.TabIndex = 20
        Me.chkRazonSocial.Text = "razon social"
        Me.chkRazonSocial.UseVisualStyleBackColor = True
        Me.chkRazonSocial.Visible = False
        '
        'chkPeriodo
        '
        Me.chkPeriodo.AutoSize = True
        Me.chkPeriodo.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkPeriodo.Location = New System.Drawing.Point(19, 18)
        Me.chkPeriodo.Name = "chkPeriodo"
        Me.chkPeriodo.Size = New System.Drawing.Size(83, 22)
        Me.chkPeriodo.TabIndex = 17
        Me.chkPeriodo.Text = "periodo"
        Me.chkPeriodo.UseVisualStyleBackColor = True
        '
        'cmbYearM
        '
        Me.cmbYearM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbYearM.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbYearM.FormattingEnabled = True
        Me.cmbYearM.Location = New System.Drawing.Point(124, 46)
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
        'cmdAceptarPeriodo
        '
        Me.cmdAceptarPeriodo.Image = CType(resources.GetObject("cmdAceptarPeriodo.Image"), System.Drawing.Image)
        Me.cmdAceptarPeriodo.Location = New System.Drawing.Point(739, 45)
        Me.cmdAceptarPeriodo.Name = "cmdAceptarPeriodo"
        Me.cmdAceptarPeriodo.Size = New System.Drawing.Size(64, 27)
        Me.cmdAceptarPeriodo.TabIndex = 3
        Me.cmdAceptarPeriodo.UseVisualStyleBackColor = True
        '
        'tbxCodigo
        '
        Me.tbxCodigo.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCodigo.Location = New System.Drawing.Point(211, 46)
        Me.tbxCodigo.Name = "tbxCodigo"
        Me.tbxCodigo.Size = New System.Drawing.Size(155, 25)
        Me.tbxCodigo.TabIndex = 19
        Me.tbxCodigo.Visible = False
        '
        'chkCodigo
        '
        Me.chkCodigo.AutoSize = True
        Me.chkCodigo.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCodigo.Location = New System.Drawing.Point(211, 18)
        Me.chkCodigo.Name = "chkCodigo"
        Me.chkCodigo.Size = New System.Drawing.Size(155, 22)
        Me.chkCodigo.TabIndex = 18
        Me.chkCodigo.Text = "codigo prestador"
        Me.chkCodigo.UseVisualStyleBackColor = True
        Me.chkCodigo.Visible = False
        '
        'cmdDetalle
        '
        Me.cmdDetalle.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDetalle.Image = CType(resources.GetObject("cmdDetalle.Image"), System.Drawing.Image)
        Me.cmdDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDetalle.Location = New System.Drawing.Point(836, 9)
        Me.cmdDetalle.Name = "cmdDetalle"
        Me.cmdDetalle.Size = New System.Drawing.Size(142, 29)
        Me.cmdDetalle.TabIndex = 13
        Me.cmdDetalle.Text = "ver detalle"
        Me.cmdDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdDetalle.UseVisualStyleBackColor = True
        '
        'frmEliminarLiquidacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1118, 603)
        Me.Controls.Add(Me.cmdDetalle)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btReimprimir)
        Me.Controls.Add(Me.cmdEliminarLiquidacion)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.dgvLiquidaciones)
        Me.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmEliminarLiquidacion"
        Me.Text = "eliminar o reimprimir una liquidacion"
        CType(Me.dgvLiquidaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvLiquidaciones As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents cmdEliminarLiquidacion As System.Windows.Forms.Button
    Friend WithEvents btReimprimir As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkCuit As CheckBox
    Friend WithEvents mebCuit As MaskedTextBox
    Friend WithEvents tbxRazonSocial As TextBox
    Friend WithEvents chkRazonSocial As CheckBox
    Friend WithEvents tbxCodigo As TextBox
    Friend WithEvents chkCodigo As CheckBox
    Friend WithEvents chkPeriodo As CheckBox
    Friend WithEvents cmbYearM As ComboBox
    Friend WithEvents cmbMonthM As ComboBox
    Friend WithEvents cmdAceptarPeriodo As Button
    Friend WithEvents cmdDetalle As Button
End Class
