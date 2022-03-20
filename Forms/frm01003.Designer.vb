<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm01003
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm01003))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbxNombreUsuario = New System.Windows.Forms.TextBox()
        Me.cmdAceptarPeriodo = New System.Windows.Forms.Button()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.cmdGuardarCambios = New System.Windows.Forms.Button()
        Me.cmdVerLog = New System.Windows.Forms.Button()
        Me.cmdSalir = New System.Windows.Forms.Button()
        Me.cmdActivarDesactivar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.tbxNombreUsuario)
        Me.GroupBox2.Controls.Add(Me.cmdAceptarPeriodo)
        Me.GroupBox2.Font = New System.Drawing.Font("Lucida Bright", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(6, -12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(262, 86)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 18)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "nombre de usuario"
        '
        'tbxNombreUsuario
        '
        Me.tbxNombreUsuario.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbxNombreUsuario.Location = New System.Drawing.Point(6, 53)
        Me.tbxNombreUsuario.Name = "tbxNombreUsuario"
        Me.tbxNombreUsuario.Size = New System.Drawing.Size(168, 25)
        Me.tbxNombreUsuario.TabIndex = 21
        '
        'cmdAceptarPeriodo
        '
        Me.cmdAceptarPeriodo.Image = CType(resources.GetObject("cmdAceptarPeriodo.Image"), System.Drawing.Image)
        Me.cmdAceptarPeriodo.Location = New System.Drawing.Point(191, 48)
        Me.cmdAceptarPeriodo.Name = "cmdAceptarPeriodo"
        Me.cmdAceptarPeriodo.Size = New System.Drawing.Size(61, 34)
        Me.cmdAceptarPeriodo.TabIndex = 3
        Me.cmdAceptarPeriodo.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.Location = New System.Drawing.Point(274, 1)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(419, 629)
        Me.TreeView1.TabIndex = 13
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AllowUserToDeleteRows = False
        Me.dgvUsuarios.BackgroundColor = System.Drawing.Color.White
        Me.dgvUsuarios.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvUsuarios.Location = New System.Drawing.Point(2, 78)
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.Size = New System.Drawing.Size(266, 413)
        Me.dgvUsuarios.TabIndex = 15
        '
        'cmdGuardarCambios
        '
        Me.cmdGuardarCambios.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdGuardarCambios.Image = CType(resources.GetObject("cmdGuardarCambios.Image"), System.Drawing.Image)
        Me.cmdGuardarCambios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGuardarCambios.Location = New System.Drawing.Point(77, 497)
        Me.cmdGuardarCambios.Name = "cmdGuardarCambios"
        Me.cmdGuardarCambios.Size = New System.Drawing.Size(181, 28)
        Me.cmdGuardarCambios.TabIndex = 16
        Me.cmdGuardarCambios.Text = "guardar cambios"
        Me.cmdGuardarCambios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGuardarCambios.UseVisualStyleBackColor = True
        '
        'cmdVerLog
        '
        Me.cmdVerLog.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVerLog.Image = CType(resources.GetObject("cmdVerLog.Image"), System.Drawing.Image)
        Me.cmdVerLog.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdVerLog.Location = New System.Drawing.Point(77, 528)
        Me.cmdVerLog.Name = "cmdVerLog"
        Me.cmdVerLog.Size = New System.Drawing.Size(181, 28)
        Me.cmdVerLog.TabIndex = 17
        Me.cmdVerLog.Text = "ver log"
        Me.cmdVerLog.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdVerLog.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSalir.Image = CType(resources.GetObject("cmdSalir.Image"), System.Drawing.Image)
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(77, 590)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(181, 28)
        Me.cmdSalir.TabIndex = 18
        Me.cmdSalir.Text = "salir"
        Me.cmdSalir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'cmdActivarDesactivar
        '
        Me.cmdActivarDesactivar.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdActivarDesactivar.Image = CType(resources.GetObject("cmdActivarDesactivar.Image"), System.Drawing.Image)
        Me.cmdActivarDesactivar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdActivarDesactivar.Location = New System.Drawing.Point(77, 559)
        Me.cmdActivarDesactivar.Name = "cmdActivarDesactivar"
        Me.cmdActivarDesactivar.Size = New System.Drawing.Size(181, 28)
        Me.cmdActivarDesactivar.TabIndex = 19
        Me.cmdActivarDesactivar.Text = "activar / desactivar"
        Me.cmdActivarDesactivar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdActivarDesactivar.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "config.png")
        Me.ImageList1.Images.SetKeyName(1, "parametros.png")
        Me.ImageList1.Images.SetKeyName(2, "ver permisos.png")
        Me.ImageList1.Images.SetKeyName(3, "mod-parametros.png")
        Me.ImageList1.Images.SetKeyName(4, "seguridad.png")
        Me.ImageList1.Images.SetKeyName(5, "log.png")
        Me.ImageList1.Images.SetKeyName(6, "activar-desactivar.png")
        Me.ImageList1.Images.SetKeyName(7, "autorizaciones.png")
        Me.ImageList1.Images.SetKeyName(8, "modificar parametros.png")
        Me.ImageList1.Images.SetKeyName(9, "consultar-autorizaciones.png")
        Me.ImageList1.Images.SetKeyName(10, "ver detalle.png")
        Me.ImageList1.Images.SetKeyName(11, "liquidaciones.png")
        Me.ImageList1.Images.SetKeyName(12, "borrar.png")
        Me.ImageList1.Images.SetKeyName(13, "exportar.png")
        Me.ImageList1.Images.SetKeyName(14, "atom-regular-24.png")
        Me.ImageList1.Images.SetKeyName(15, "buscar 2.png")
        Me.ImageList1.Images.SetKeyName(16, "buscar.png")
        Me.ImageList1.Images.SetKeyName(17, "cerrar.png")
        Me.ImageList1.Images.SetKeyName(18, "certification-solid-24.png")
        Me.ImageList1.Images.SetKeyName(19, "door-open-solid-24.png")
        Me.ImageList1.Images.SetKeyName(20, "guardar.png")
        Me.ImageList1.Images.SetKeyName(21, "liquida.png")
        Me.ImageList1.Images.SetKeyName(22, "liquidar.png")
        Me.ImageList1.Images.SetKeyName(23, "log.png")
        Me.ImageList1.Images.SetKeyName(24, "prestadores.png")
        Me.ImageList1.Images.SetKeyName(25, "previsualizr.png")
        Me.ImageList1.Images.SetKeyName(26, "redux-logo-24.png")
        Me.ImageList1.Images.SetKeyName(27, "user-rectangle-solid-24.png")
        '
        'frm01003
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(696, 634)
        Me.Controls.Add(Me.cmdActivarDesactivar)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.cmdVerLog)
        Me.Controls.Add(Me.cmdGuardarCambios)
        Me.Controls.Add(Me.dgvUsuarios)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frm01003"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frm01003"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents tbxNombreUsuario As TextBox
    Friend WithEvents cmdAceptarPeriodo As Button
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents dgvUsuarios As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdGuardarCambios As Button
    Friend WithEvents cmdVerLog As Button
    Friend WithEvents cmdSalir As Button
    Friend WithEvents cmdActivarDesactivar As Button
    Friend WithEvents ImageList1 As ImageList
End Class
