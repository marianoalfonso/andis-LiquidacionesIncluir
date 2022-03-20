<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm01000
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm01000))
        Me.dgvParametros = New System.Windows.Forms.DataGridView()
        Me.cmdModificar = New System.Windows.Forms.Button()
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cmdVerLog = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.cmdGuardarCambios = New System.Windows.Forms.Button()
        Me.lblParametro = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbxValor = New System.Windows.Forms.TextBox()
        CType(Me.dgvParametros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvParametros
        '
        Me.dgvParametros.AllowUserToAddRows = False
        Me.dgvParametros.AllowUserToDeleteRows = False
        Me.dgvParametros.BackgroundColor = System.Drawing.Color.White
        Me.dgvParametros.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvParametros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvParametros.Location = New System.Drawing.Point(6, 6)
        Me.dgvParametros.Name = "dgvParametros"
        Me.dgvParametros.ReadOnly = True
        Me.dgvParametros.Size = New System.Drawing.Size(1109, 329)
        Me.dgvParametros.TabIndex = 0
        '
        'cmdModificar
        '
        Me.cmdModificar.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdModificar.Image = CType(resources.GetObject("cmdModificar.Image"), System.Drawing.Image)
        Me.cmdModificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdModificar.Location = New System.Drawing.Point(953, 341)
        Me.cmdModificar.Name = "cmdModificar"
        Me.cmdModificar.Size = New System.Drawing.Size(155, 28)
        Me.cmdModificar.TabIndex = 1
        Me.cmdModificar.Text = "modificar valor"
        Me.cmdModificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdModificar.UseVisualStyleBackColor = True
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCerrar.Image = CType(resources.GetObject("cmdCerrar.Image"), System.Drawing.Image)
        Me.cmdCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCerrar.Location = New System.Drawing.Point(953, 400)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(155, 28)
        Me.cmdCerrar.TabIndex = 2
        Me.cmdCerrar.Text = "cerrar"
        Me.cmdCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdVerLog
        '
        Me.cmdVerLog.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVerLog.Image = CType(resources.GetObject("cmdVerLog.Image"), System.Drawing.Image)
        Me.cmdVerLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdVerLog.Location = New System.Drawing.Point(953, 371)
        Me.cmdVerLog.Name = "cmdVerLog"
        Me.cmdVerLog.Size = New System.Drawing.Size(155, 28)
        Me.cmdVerLog.TabIndex = 3
        Me.cmdVerLog.Text = "ver log"
        Me.cmdVerLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdVerLog.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdCancelar)
        Me.GroupBox1.Controls.Add(Me.cmdGuardarCambios)
        Me.GroupBox1.Controls.Add(Me.lblParametro)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbxValor)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 341)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(941, 87)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(788, 48)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(147, 28)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.Text = "cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdGuardarCambios
        '
        Me.cmdGuardarCambios.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardarCambios.Image = CType(resources.GetObject("cmdGuardarCambios.Image"), System.Drawing.Image)
        Me.cmdGuardarCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGuardarCambios.Location = New System.Drawing.Point(788, 18)
        Me.cmdGuardarCambios.Name = "cmdGuardarCambios"
        Me.cmdGuardarCambios.Size = New System.Drawing.Size(147, 28)
        Me.cmdGuardarCambios.TabIndex = 4
        Me.cmdGuardarCambios.Text = "guardar cambios"
        Me.cmdGuardarCambios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGuardarCambios.UseVisualStyleBackColor = True
        '
        'lblParametro
        '
        Me.lblParametro.AutoSize = True
        Me.lblParametro.Location = New System.Drawing.Point(115, 25)
        Me.lblParametro.Name = "lblParametro"
        Me.lblParametro.Size = New System.Drawing.Size(48, 18)
        Me.lblParametro.TabIndex = 3
        Me.lblParametro.Text = ". . ."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(53, 56)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 18)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "valor:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "parametro:"
        '
        'tbxValor
        '
        Me.tbxValor.Location = New System.Drawing.Point(115, 53)
        Me.tbxValor.Name = "tbxValor"
        Me.tbxValor.Size = New System.Drawing.Size(132, 25)
        Me.tbxValor.TabIndex = 0
        '
        'frm01000
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1120, 432)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdVerLog)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Controls.Add(Me.cmdModificar)
        Me.Controls.Add(Me.dgvParametros)
        Me.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frm01000"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frm01000"
        CType(Me.dgvParametros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgvParametros As DataGridView
    Friend WithEvents cmdModificar As Button
    Friend WithEvents cmdCerrar As Button
    Friend WithEvents cmdVerLog As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents lblParametro As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents tbxValor As TextBox
    Friend WithEvents cmdCancelar As Button
    Friend WithEvents cmdGuardarCambios As Button
End Class
