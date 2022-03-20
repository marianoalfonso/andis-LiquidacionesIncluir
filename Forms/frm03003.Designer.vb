<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm03003
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm03003))
        Me.dtvLiquidacionesAsociadas = New System.Windows.Forms.DataGridView()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.btnDetalle = New System.Windows.Forms.Button()
        CType(Me.dtvLiquidacionesAsociadas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtvLiquidacionesAsociadas
        '
        Me.dtvLiquidacionesAsociadas.BackgroundColor = System.Drawing.Color.White
        Me.dtvLiquidacionesAsociadas.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dtvLiquidacionesAsociadas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtvLiquidacionesAsociadas.Location = New System.Drawing.Point(2, 4)
        Me.dtvLiquidacionesAsociadas.Name = "dtvLiquidacionesAsociadas"
        Me.dtvLiquidacionesAsociadas.Size = New System.Drawing.Size(601, 110)
        Me.dtvLiquidacionesAsociadas.TabIndex = 0
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(609, 75)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(120, 29)
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'btnDetalle
        '
        Me.btnDetalle.Image = CType(resources.GetObject("btnDetalle.Image"), System.Drawing.Image)
        Me.btnDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDetalle.Location = New System.Drawing.Point(609, 41)
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(120, 29)
        Me.btnDetalle.TabIndex = 2
        Me.btnDetalle.Text = "ver detalle"
        Me.btnDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDetalle.UseVisualStyleBackColor = True
        '
        'frm03003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(734, 119)
        Me.Controls.Add(Me.btnDetalle)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.dtvLiquidacionesAsociadas)
        Me.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm03003"
        Me.Text = "frm03003"
        Me.TransparencyKey = System.Drawing.Color.Red
        CType(Me.dtvLiquidacionesAsociadas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dtvLiquidacionesAsociadas As DataGridView
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnDetalle As Button
End Class
