<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmImportacion
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
        Me.brnCerrar = New System.Windows.Forms.Button()
        Me.lvArchivos = New System.Windows.Forms.ListView()
        Me.btnImportar = New System.Windows.Forms.Button()
        Me.btnSeleccionarTodos = New System.Windows.Forms.Button()
        Me.lblArchivosPendientes = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtArchivosAImportar = New System.Windows.Forms.TextBox()
        Me.txtArchivosImportados = New System.Windows.Forms.TextBox()
        Me.lblArchivoEnMigracion = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'brnCerrar
        '
        Me.brnCerrar.Location = New System.Drawing.Point(639, 353)
        Me.brnCerrar.Name = "brnCerrar"
        Me.brnCerrar.Size = New System.Drawing.Size(78, 26)
        Me.brnCerrar.TabIndex = 0
        Me.brnCerrar.Text = "Cerrar"
        Me.brnCerrar.UseVisualStyleBackColor = True
        '
        'lvArchivos
        '
        Me.lvArchivos.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvArchivos.CheckBoxes = True
        Me.lvArchivos.GridLines = True
        Me.lvArchivos.HotTracking = True
        Me.lvArchivos.HoverSelection = True
        Me.lvArchivos.Location = New System.Drawing.Point(35, 12)
        Me.lvArchivos.Name = "lvArchivos"
        Me.lvArchivos.Size = New System.Drawing.Size(708, 329)
        Me.lvArchivos.TabIndex = 2
        Me.lvArchivos.UseCompatibleStateImageBehavior = False
        Me.lvArchivos.View = System.Windows.Forms.View.List
        '
        'btnImportar
        '
        Me.btnImportar.Location = New System.Drawing.Point(553, 353)
        Me.btnImportar.Name = "btnImportar"
        Me.btnImportar.Size = New System.Drawing.Size(80, 26)
        Me.btnImportar.TabIndex = 4
        Me.btnImportar.Text = "Importar"
        Me.btnImportar.UseVisualStyleBackColor = True
        '
        'btnSeleccionarTodos
        '
        Me.btnSeleccionarTodos.Location = New System.Drawing.Point(35, 347)
        Me.btnSeleccionarTodos.Name = "btnSeleccionarTodos"
        Me.btnSeleccionarTodos.Size = New System.Drawing.Size(119, 26)
        Me.btnSeleccionarTodos.TabIndex = 5
        Me.btnSeleccionarTodos.Tag = "marcados"
        Me.btnSeleccionarTodos.Text = "Seleccionar Todos"
        Me.btnSeleccionarTodos.UseVisualStyleBackColor = True
        '
        'lblArchivosPendientes
        '
        Me.lblArchivosPendientes.AutoSize = True
        Me.lblArchivosPendientes.Location = New System.Drawing.Point(206, 353)
        Me.lblArchivosPendientes.Name = "lblArchivosPendientes"
        Me.lblArchivosPendientes.Size = New System.Drawing.Size(0, 13)
        Me.lblArchivosPendientes.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(409, 351)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "A importar:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(409, 372)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Importados:"
        '
        'txtArchivosAImportar
        '
        Me.txtArchivosAImportar.Location = New System.Drawing.Point(473, 346)
        Me.txtArchivosAImportar.Name = "txtArchivosAImportar"
        Me.txtArchivosAImportar.Size = New System.Drawing.Size(74, 20)
        Me.txtArchivosAImportar.TabIndex = 9
        '
        'txtArchivosImportados
        '
        Me.txtArchivosImportados.Location = New System.Drawing.Point(473, 369)
        Me.txtArchivosImportados.Name = "txtArchivosImportados"
        Me.txtArchivosImportados.Size = New System.Drawing.Size(74, 20)
        Me.txtArchivosImportados.TabIndex = 10
        '
        'lblArchivoEnMigracion
        '
        Me.lblArchivoEnMigracion.AutoSize = True
        Me.lblArchivoEnMigracion.Location = New System.Drawing.Point(161, 352)
        Me.lblArchivoEnMigracion.Name = "lblArchivoEnMigracion"
        Me.lblArchivoEnMigracion.Size = New System.Drawing.Size(0, 13)
        Me.lblArchivoEnMigracion.TabIndex = 11
        '
        'frmImportacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 426)
        Me.Controls.Add(Me.lblArchivoEnMigracion)
        Me.Controls.Add(Me.txtArchivosImportados)
        Me.Controls.Add(Me.txtArchivosAImportar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblArchivosPendientes)
        Me.Controls.Add(Me.btnSeleccionarTodos)
        Me.Controls.Add(Me.btnImportar)
        Me.Controls.Add(Me.lvArchivos)
        Me.Controls.Add(Me.brnCerrar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmImportacion"
        Me.Text = "frmImportacion"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents brnCerrar As System.Windows.Forms.Button
    Friend WithEvents lvArchivos As System.Windows.Forms.ListView
    Friend WithEvents btnImportar As System.Windows.Forms.Button
    Friend WithEvents btnSeleccionarTodos As System.Windows.Forms.Button
    Friend WithEvents lblArchivosPendientes As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtArchivosAImportar As System.Windows.Forms.TextBox
    Friend WithEvents txtArchivosImportados As System.Windows.Forms.TextBox
    Friend WithEvents lblArchivoEnMigracion As System.Windows.Forms.Label
End Class
