<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDefault
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDefault))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ImportacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarArchivosDiscapacidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.parametros_generales = New System.Windows.Forms.ToolStripMenuItem()
        Me.SeguridadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.autorizacionesToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportarNuevaAutorizacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarAutorizacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarComplementariasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LiquidacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaLiquidacionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsultarLiquidacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HerramientasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportacionToolStripMenuItem, Me.autorizacionesToolStripMenuItem1, Me.LiquidacionToolStripMenuItem, Me.HerramientasToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(725, 26)
        Me.MenuStrip1.TabIndex = 2
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ImportacionToolStripMenuItem
        '
        Me.ImportacionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportarArchivosDiscapacidadToolStripMenuItem, Me.parametros_generales, Me.SeguridadToolStripMenuItem})
        Me.ImportacionToolStripMenuItem.Image = CType(resources.GetObject("ImportacionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ImportacionToolStripMenuItem.Name = "ImportacionToolStripMenuItem"
        Me.ImportacionToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.ImportacionToolStripMenuItem.Text = "configuracion"
        '
        'ImportarArchivosDiscapacidadToolStripMenuItem
        '
        Me.ImportarArchivosDiscapacidadToolStripMenuItem.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ImportarArchivosDiscapacidadToolStripMenuItem.Name = "ImportarArchivosDiscapacidadToolStripMenuItem"
        Me.ImportarArchivosDiscapacidadToolStripMenuItem.Overflow = System.Windows.Forms.ToolStripItemOverflow.AsNeeded
        Me.ImportarArchivosDiscapacidadToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.ImportarArchivosDiscapacidadToolStripMenuItem.Text = "Importar archivos pendientes"
        '
        'parametros_generales
        '
        Me.parametros_generales.Image = CType(resources.GetObject("parametros_generales.Image"), System.Drawing.Image)
        Me.parametros_generales.Name = "parametros_generales"
        Me.parametros_generales.Size = New System.Drawing.Size(300, 22)
        Me.parametros_generales.Text = "parametros generales"
        '
        'SeguridadToolStripMenuItem
        '
        Me.SeguridadToolStripMenuItem.Image = CType(resources.GetObject("SeguridadToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SeguridadToolStripMenuItem.Name = "SeguridadToolStripMenuItem"
        Me.SeguridadToolStripMenuItem.Size = New System.Drawing.Size(300, 22)
        Me.SeguridadToolStripMenuItem.Text = "seguridad"
        '
        'autorizacionesToolStripMenuItem1
        '
        Me.autorizacionesToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ImportarNuevaAutorizacionToolStripMenuItem, Me.ConsultarAutorizacionesToolStripMenuItem, Me.ConsultarComplementariasToolStripMenuItem})
        Me.autorizacionesToolStripMenuItem1.Image = CType(resources.GetObject("autorizacionesToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.autorizacionesToolStripMenuItem1.Name = "autorizacionesToolStripMenuItem1"
        Me.autorizacionesToolStripMenuItem1.Size = New System.Drawing.Size(148, 22)
        Me.autorizacionesToolStripMenuItem1.Text = "autorizaciones"
        '
        'ImportarNuevaAutorizacionToolStripMenuItem
        '
        Me.ImportarNuevaAutorizacionToolStripMenuItem.Enabled = False
        Me.ImportarNuevaAutorizacionToolStripMenuItem.Name = "ImportarNuevaAutorizacionToolStripMenuItem"
        Me.ImportarNuevaAutorizacionToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.ImportarNuevaAutorizacionToolStripMenuItem.Text = "importar nueva autorizacion"
        '
        'ConsultarAutorizacionesToolStripMenuItem
        '
        Me.ConsultarAutorizacionesToolStripMenuItem.Image = CType(resources.GetObject("ConsultarAutorizacionesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConsultarAutorizacionesToolStripMenuItem.Name = "ConsultarAutorizacionesToolStripMenuItem"
        Me.ConsultarAutorizacionesToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.ConsultarAutorizacionesToolStripMenuItem.Text = "consultar autorizaciones"
        '
        'ConsultarComplementariasToolStripMenuItem
        '
        Me.ConsultarComplementariasToolStripMenuItem.Enabled = False
        Me.ConsultarComplementariasToolStripMenuItem.Image = CType(resources.GetObject("ConsultarComplementariasToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConsultarComplementariasToolStripMenuItem.Name = "ConsultarComplementariasToolStripMenuItem"
        Me.ConsultarComplementariasToolStripMenuItem.Size = New System.Drawing.Size(292, 22)
        Me.ConsultarComplementariasToolStripMenuItem.Text = "consultar complementarias"
        '
        'LiquidacionToolStripMenuItem
        '
        Me.LiquidacionToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaLiquidacionToolStripMenuItem, Me.ConsultarLiquidacionesToolStripMenuItem})
        Me.LiquidacionToolStripMenuItem.Image = CType(resources.GetObject("LiquidacionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.LiquidacionToolStripMenuItem.Name = "LiquidacionToolStripMenuItem"
        Me.LiquidacionToolStripMenuItem.Size = New System.Drawing.Size(140, 22)
        Me.LiquidacionToolStripMenuItem.Text = "liquidaciones"
        '
        'NuevaLiquidacionToolStripMenuItem
        '
        Me.NuevaLiquidacionToolStripMenuItem.Image = CType(resources.GetObject("NuevaLiquidacionToolStripMenuItem.Image"), System.Drawing.Image)
        Me.NuevaLiquidacionToolStripMenuItem.Name = "NuevaLiquidacionToolStripMenuItem"
        Me.NuevaLiquidacionToolStripMenuItem.Size = New System.Drawing.Size(276, 22)
        Me.NuevaLiquidacionToolStripMenuItem.Text = "generar nueva liquidacion"
        '
        'ConsultarLiquidacionesToolStripMenuItem
        '
        Me.ConsultarLiquidacionesToolStripMenuItem.Image = CType(resources.GetObject("ConsultarLiquidacionesToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ConsultarLiquidacionesToolStripMenuItem.Name = "ConsultarLiquidacionesToolStripMenuItem"
        Me.ConsultarLiquidacionesToolStripMenuItem.Size = New System.Drawing.Size(276, 22)
        Me.ConsultarLiquidacionesToolStripMenuItem.Text = "consultar liquidaciones"
        '
        'HerramientasToolStripMenuItem
        '
        Me.HerramientasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
        Me.HerramientasToolStripMenuItem.Image = CType(resources.GetObject("HerramientasToolStripMenuItem.Image"), System.Drawing.Image)
        Me.HerramientasToolStripMenuItem.Name = "HerramientasToolStripMenuItem"
        Me.HerramientasToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.HerramientasToolStripMenuItem.Text = "prestadores"
        Me.HerramientasToolStripMenuItem.Visible = False
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(244, 22)
        Me.ToolStripMenuItem1.Text = "consultar prestadores"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Image = CType(resources.GetObject("SalirToolStripMenuItem.Image"), System.Drawing.Image)
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(76, 22)
        Me.SalirToolStripMenuItem.Text = "salir"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 26)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(725, 421)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'frmDefault
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(725, 447)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmDefault"
        Me.Text = "Agencia Nacional de Discapacidad"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ImportacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImportarArchivosDiscapacidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LiquidacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevaLiquidacionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HerramientasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents parametros_generales As ToolStripMenuItem
    Friend WithEvents autorizacionesToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ImportarNuevaAutorizacionToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultarAutorizacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultarLiquidacionesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents SeguridadToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ConsultarComplementariasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PictureBox1 As PictureBox
End Class
