<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm04001
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm04001))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkCuit = New System.Windows.Forms.CheckBox()
        Me.mebCuit = New System.Windows.Forms.MaskedTextBox()
        Me.tbxRazonSocial = New System.Windows.Forms.TextBox()
        Me.chkRazonSocial = New System.Windows.Forms.CheckBox()
        Me.tbxCodigo = New System.Windows.Forms.TextBox()
        Me.chkCodigo = New System.Windows.Forms.CheckBox()
        Me.cmdAceptarPeriodo = New System.Windows.Forms.Button()
        Me.dgvPrestadores = New System.Windows.Forms.DataGridView()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.cmdExportar = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvPrestadores, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.GroupBox2.Controls.Add(Me.cmdAceptarPeriodo)
        Me.GroupBox2.Font = New System.Drawing.Font("Lucida Bright", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(4, -12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(710, 80)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'chkCuit
        '
        Me.chkCuit.AutoSize = True
        Me.chkCuit.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCuit.Location = New System.Drawing.Point(211, 18)
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
        Me.mebCuit.Location = New System.Drawing.Point(211, 46)
        Me.mebCuit.Mask = "00-00000000-0"
        Me.mebCuit.Name = "mebCuit"
        Me.mebCuit.Size = New System.Drawing.Size(133, 25)
        Me.mebCuit.TabIndex = 22
        '
        'tbxRazonSocial
        '
        Me.tbxRazonSocial.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxRazonSocial.Location = New System.Drawing.Point(372, 46)
        Me.tbxRazonSocial.Name = "tbxRazonSocial"
        Me.tbxRazonSocial.Size = New System.Drawing.Size(244, 25)
        Me.tbxRazonSocial.TabIndex = 21
        '
        'chkRazonSocial
        '
        Me.chkRazonSocial.AutoSize = True
        Me.chkRazonSocial.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRazonSocial.Location = New System.Drawing.Point(372, 18)
        Me.chkRazonSocial.Name = "chkRazonSocial"
        Me.chkRazonSocial.Size = New System.Drawing.Size(123, 22)
        Me.chkRazonSocial.TabIndex = 20
        Me.chkRazonSocial.Text = "razon social"
        Me.chkRazonSocial.UseVisualStyleBackColor = True
        '
        'tbxCodigo
        '
        Me.tbxCodigo.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxCodigo.Location = New System.Drawing.Point(10, 45)
        Me.tbxCodigo.Name = "tbxCodigo"
        Me.tbxCodigo.Size = New System.Drawing.Size(175, 25)
        Me.tbxCodigo.TabIndex = 19
        '
        'chkCodigo
        '
        Me.chkCodigo.AutoSize = True
        Me.chkCodigo.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkCodigo.Location = New System.Drawing.Point(10, 18)
        Me.chkCodigo.Name = "chkCodigo"
        Me.chkCodigo.Size = New System.Drawing.Size(155, 22)
        Me.chkCodigo.TabIndex = 18
        Me.chkCodigo.Text = "codigo prestador"
        Me.chkCodigo.UseVisualStyleBackColor = True
        '
        'cmdAceptarPeriodo
        '
        Me.cmdAceptarPeriodo.Image = CType(resources.GetObject("cmdAceptarPeriodo.Image"), System.Drawing.Image)
        Me.cmdAceptarPeriodo.Location = New System.Drawing.Point(637, 38)
        Me.cmdAceptarPeriodo.Name = "cmdAceptarPeriodo"
        Me.cmdAceptarPeriodo.Size = New System.Drawing.Size(61, 34)
        Me.cmdAceptarPeriodo.TabIndex = 3
        Me.cmdAceptarPeriodo.UseVisualStyleBackColor = True
        '
        'dgvPrestadores
        '
        Me.dgvPrestadores.BackgroundColor = System.Drawing.Color.White
        Me.dgvPrestadores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvPrestadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrestadores.Location = New System.Drawing.Point(3, 74)
        Me.dgvPrestadores.Name = "dgvPrestadores"
        Me.dgvPrestadores.Size = New System.Drawing.Size(868, 349)
        Me.dgvPrestadores.TabIndex = 13
        '
        'btnCerrar
        '
        Me.btnCerrar.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(757, 41)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(98, 28)
        Me.btnCerrar.TabIndex = 14
        Me.btnCerrar.Text = "cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'cmdExportar
        '
        Me.cmdExportar.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdExportar.Image = CType(resources.GetObject("cmdExportar.Image"), System.Drawing.Image)
        Me.cmdExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportar.Location = New System.Drawing.Point(757, 6)
        Me.cmdExportar.Name = "cmdExportar"
        Me.cmdExportar.Size = New System.Drawing.Size(98, 28)
        Me.cmdExportar.TabIndex = 15
        Me.cmdExportar.Text = "exportar"
        Me.cmdExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdExportar.UseVisualStyleBackColor = True
        '
        'frm04001
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 428)
        Me.Controls.Add(Me.cmdExportar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.dgvPrestadores)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm04001"
        Me.Text = "frm04001"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvPrestadores, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents chkCuit As CheckBox
    Friend WithEvents mebCuit As MaskedTextBox
    Friend WithEvents tbxRazonSocial As TextBox
    Friend WithEvents chkRazonSocial As CheckBox
    Friend WithEvents tbxCodigo As TextBox
    Friend WithEvents chkCodigo As CheckBox
    Friend WithEvents cmdAceptarPeriodo As Button
    Friend WithEvents dgvPrestadores As DataGridView
    Friend WithEvents btnCerrar As Button
    Friend WithEvents cmdExportar As Button
End Class
