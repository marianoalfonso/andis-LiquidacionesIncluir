Imports System.Data.SqlClient
Public Class frm01000

    Dim mcls_log As New mcls_log
    Dim mcls_00006 As New mcls_00006
    Dim old_value As String = ""
    Dim new_value As String = ""

    Private Sub frm01000_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If Not setEnvironment() Then Throw New System.Exception()
            If Not load_parameters() Then Throw New System.Exception()
        Catch ex As Exception
            Me.Hide()
        End Try
    End Sub

    Function setEnvironment() As Boolean
        Try
            Me.Text = "parámetros generales"
            cmdModificar.Tag = "01.01.01.02"       'modificar parametros
            cmdVerLog.Tag = "01.01.01.03"               'ver log
            mcls_log.usuario = sUsuario
            mcls_log.area = sArea
            GroupBox1.Visible = False
            Return True
        Catch ex As Exception
            MessageBox.Show(Err.Description, "error general", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Function load_parameters() As Boolean
        Dim Conn As New SqlConnection(gsConnectionString)
        Try
            Dim stringSearch As String = "select parametro,valor,tipo,descripcion from mvw_parametros"
            dgvParametros.DataSource = Nothing
            Me.Cursor = Cursors.WaitCursor
            Dim Cmd As New SqlCommand(stringSearch, Conn)
            Dim Da As New SqlDataAdapter(Cmd)
            Dim Dt As New DataTable()
            Cmd.CommandType = CommandType.Text
            Conn.Open()
            Da.Fill(Dt)
            If Dt.Rows.Count() > 0 Then
                dgvParametros.DataSource = Dt
                mdtg_Format(dgvParametros, "consolas", 11)
                dgvParametros.Columns(0).Visible = False
                dgvParametros.Columns(0).Width = 170
                dgvParametros.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                dgvParametros.Columns(1).Width = 80
                dgvParametros.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgvParametros.Columns(2).Visible = False
                dgvParametros.Columns(3).Width = 790
                dgvParametros.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show("error cargando usuarios")
            MessageBox.Show(Err.Description, "error general", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        Finally
            Me.Cursor = Cursors.Default
            Conn.Close()
            Conn.Dispose()
        End Try
    End Function

    Private Sub cmdModificar_Click(sender As Object, e As EventArgs) Handles cmdModificar.Click
        Try
            If Not mcls_00006.mfn_00001(cmdModificar.Tag) Then
                MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
            lblParametro.Text = ""
            tbxValor.Text = ""
            lblParametro.Text = Trim(dgvParametros.CurrentRow.Cells(0).Value)
            old_value = Trim(dgvParametros.CurrentRow.Cells(1).Value)
            tbxValor.Text = Trim(dgvParametros.CurrentRow.Cells(1).Value)
            dgvParametros.Enabled = False
            cmdModificar.Enabled = False
            cmdVerLog.Enabled = False
            cmdCerrar.Enabled = False
            cmdGuardarCambios.Enabled = True
            cmdCancelar.Enabled = True
            GroupBox1.Visible = True
        Catch ex As Exception
            MessageBox.Show("error cargando datos para modificación")
            MessageBox.Show(Err.Description, "error general", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        GroupBox1.Visible = False
        dgvParametros.Enabled = True
        cmdModificar.Enabled = True
        cmdVerLog.Enabled = True
        cmdCerrar.Enabled = True
    End Sub


    Private Sub cmdGuardarCambios_Click(sender As Object, e As EventArgs) Handles cmdGuardarCambios.Click
        mcls_log.proceso = Me.Tag
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim cmd As New SqlCommand("mpa_00005", Conn)
        Dim reg As Int16 = 0
        Dim parametro As String = lblParametro.Text
        Dim valor As String = Trim(tbxValor.Text)
        new_value = valor
        Dim tipo As String = Trim(dgvParametros.CurrentRow.Cells(2).Value)
        Try
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            If tipo = "numerico" Then
                If Not IsNumeric(valor) Then
                    tbxValor.BackColor = Color.PaleVioletRed
                    tbxValor.Focus()
                    Cursor = System.Windows.Forms.Cursors.Default
                    MessageBox.Show("valor incorrecto", "parametros", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Conn.Dispose()
                    Exit Sub
                End If
            End If
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.AddWithValue("@pmt_01", lblParametro.Text)
            'cmd.Parameters.AddWithValue("@pmt_02", Trim(tbxValor.Text))
            cmd.Parameters.AddWithValue("@pmt_02", Trim(valor))
            Conn.Open()
            reg = cmd.ExecuteNonQuery()
            If reg > 0 Then
                dgvParametros.CurrentRow.Cells(1).Value = Trim(valor)
            End If
            GroupBox1.Visible = False
            dgvParametros.Enabled = True
            cmdModificar.Enabled = True
            cmdVerLog.Enabled = True
            cmdCerrar.Enabled = True
            tbxValor.BackColor = Color.White
            mcls_log.detalle = "cambio de parámetro realizado: " & Trim(lblParametro.Text) & ": " & Trim(old_value) & " --> " & Trim(new_value)
            mcls_log.log_event_ok()
            Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show("valores guardados correctamente" & Chr(13) &
                            "los cambios se veran reflejados con el reinicio del sistema", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            tbxValor.BackColor = Color.White
            mcls_log.detalle = "error guardando modificaciones de parámetros (Sub cmdGuardarCambios_Click)"
            mcls_log.error_codigo = Err.Number
            mcls_log.error_descripcion = Err.Description
            mcls_log.log_event_error()
            Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show("error guardando los cambios de parámetros", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdCerrar_Click(sender As Object, e As EventArgs) Handles cmdCerrar.Click
        Me.Hide()
    End Sub

    Private Sub cmdVerLog_Click(sender As Object, e As EventArgs) Handles cmdVerLog.Click
        If Not mcls_00006.mfn_00001(cmdVerLog.Tag) Then
            MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If



    End Sub


End Class