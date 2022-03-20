<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProcessAuth
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProcessAuth))
        Me.txtPwd = New System.Windows.Forms.TextBox()
        Me.lblTexto = New System.Windows.Forms.Label()
        Me.cmdConfirmar = New System.Windows.Forms.Button()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtPwd
        '
        Me.txtPwd.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPwd.Location = New System.Drawing.Point(12, 78)
        Me.txtPwd.Name = "txtPwd"
        Me.txtPwd.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPwd.Size = New System.Drawing.Size(198, 25)
        Me.txtPwd.TabIndex = 0
        '
        'lblTexto
        '
        Me.lblTexto.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTexto.Image = CType(resources.GetObject("lblTexto.Image"), System.Drawing.Image)
        Me.lblTexto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTexto.Location = New System.Drawing.Point(36, 29)
        Me.lblTexto.Name = "lblTexto"
        Me.lblTexto.Size = New System.Drawing.Size(161, 18)
        Me.lblTexto.TabIndex = 1
        Me.lblTexto.Text = "Label1"
        Me.lblTexto.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'cmdConfirmar
        '
        Me.cmdConfirmar.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdConfirmar.Location = New System.Drawing.Point(102, 111)
        Me.cmdConfirmar.Name = "cmdConfirmar"
        Me.cmdConfirmar.Size = New System.Drawing.Size(99, 31)
        Me.cmdConfirmar.TabIndex = 2
        Me.cmdConfirmar.Text = "confirmar"
        Me.cmdConfirmar.UseVisualStyleBackColor = True
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(22, 57)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(56, 18)
        Me.lblUsuario.TabIndex = 3
        Me.lblUsuario.Text = "Label1"
        '
        'frmProcessAuth
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(221, 148)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.cmdConfirmar)
        Me.Controls.Add(Me.lblTexto)
        Me.Controls.Add(Me.txtPwd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmProcessAuth"
        Me.Text = "frmProcessAuth"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtPwd As TextBox
    Friend WithEvents lblTexto As Label
    Friend WithEvents cmdConfirmar As Button
    Friend WithEvents lblUsuario As Label
End Class
