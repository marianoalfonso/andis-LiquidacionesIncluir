<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm03002
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm03002))
        Me.dgv_DetalleLiquidacion = New System.Windows.Forms.DataGridView()
        Me.cmdExportar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        CType(Me.dgv_DetalleLiquidacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgv_DetalleLiquidacion
        '
        Me.dgv_DetalleLiquidacion.AllowUserToAddRows = False
        Me.dgv_DetalleLiquidacion.AllowUserToDeleteRows = False
        Me.dgv_DetalleLiquidacion.BackgroundColor = System.Drawing.Color.White
        Me.dgv_DetalleLiquidacion.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgv_DetalleLiquidacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv_DetalleLiquidacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnF2
        Me.dgv_DetalleLiquidacion.Location = New System.Drawing.Point(4, 6)
        Me.dgv_DetalleLiquidacion.Name = "dgv_DetalleLiquidacion"
        Me.dgv_DetalleLiquidacion.ReadOnly = True
        Me.dgv_DetalleLiquidacion.Size = New System.Drawing.Size(1184, 406)
        Me.dgv_DetalleLiquidacion.TabIndex = 0
        '
        'cmdExportar
        '
        Me.cmdExportar.BackColor = System.Drawing.SystemColors.Control
        Me.cmdExportar.Image = CType(resources.GetObject("cmdExportar.Image"), System.Drawing.Image)
        Me.cmdExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdExportar.Location = New System.Drawing.Point(958, 418)
        Me.cmdExportar.Name = "cmdExportar"
        Me.cmdExportar.Size = New System.Drawing.Size(105, 29)
        Me.cmdExportar.TabIndex = 1
        Me.cmdExportar.Text = "exportar"
        Me.cmdExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdExportar.UseVisualStyleBackColor = False
        '
        'btnCerrar
        '
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(1074, 418)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(105, 29)
        Me.btnCerrar.TabIndex = 2
        Me.btnCerrar.Text = "cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'frm03002
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1191, 449)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.cmdExportar)
        Me.Controls.Add(Me.dgv_DetalleLiquidacion)
        Me.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm03002"
        Me.Text = "frm03002"
        CType(Me.dgv_DetalleLiquidacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents dgv_DetalleLiquidacion As DataGridView
    Friend WithEvents cmdExportar As Button
    Friend WithEvents btnCerrar As Button
End Class
