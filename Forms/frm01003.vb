Imports System.Data.SqlClient

Public Class frm01003

    Dim mcls_log As New mcls_log
    Dim seguridad(1) As String
    'Dim bSelecDesdeNodoHijo As Boolean
    Dim mcls_tvws As New mcls_tvws
    Dim mcls_security As New mcls_security
    'Dim sUsuario As String = ""

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        setEnvironment()


    End Sub

    Sub setEnvironment()
        Try
            Me.Text = "seguridad y permisos"
            cmdGuardarCambios.Tag = "01.01.01.02"       'modificar parametros
            cmdVerLog.Tag = "01.01.02.03"               'ver log
            cmdActivarDesactivar.Tag = "01.01.02.04"    'activar / desactivar usuario
            mcls_log.usuario = sUsuario
            mcls_log.area = sArea
            mcls_log.proceso = Me.Tag
        Catch ex As Exception

        End Try
    End Sub

    Sub load_array(usr As String)
        Dim arrayLengh As Int16 = 0
        Dim iteracion As Int16 = 0
        Dim conn As New SqlConnection(gsConnectionString)
        Dim cmd As New SqlCommand("select seg_mod_codigo from mtb_seguridad where seg_usuario_id = '" & usr & "'", conn)
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable
        cmd.CommandType = CommandType.Text
        Try
            conn.Open()
            da.Fill(dt)
            If dt.Rows.Count() > 0 Then
                arrayLengh = dt.Rows.Count() - 1
                ReDim seguridad(arrayLengh)
                For Each elemento As DataRow In dt.Rows
                    seguridad(iteracion) = elemento("seg_mod_codigo")
                    iteracion = iteracion + 1
                Next
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Sub


    Public Sub load_tree()
        Try
            TreeView1.ImageList = ImageList1
            'configuracion
            TreeView1.Nodes.Add("01.01", "configuracion", 0)
            If mcls_tvws.check_security(seguridad, "01.01") Then TreeView1.Nodes("01.01").Checked = True
            'parametros
            TreeView1.Nodes("01.01").Nodes.Add("01.01.01", "parametros", 1)
            If mcls_tvws.check_security(seguridad, "01.01.01") Then TreeView1.Nodes("01.01").Nodes("01.01.01").Checked = vbTrue
            TreeView1.Nodes("01.01").Nodes("01.01.01").Nodes.Add("01.01.01.01", "ver parametros", 2)
            If mcls_tvws.check_security(seguridad, "01.01.01.01") Then TreeView1.Nodes("01.01").Nodes("01.01.01").Nodes("01.01.01.01").Checked = vbTrue
            TreeView1.Nodes("01.01").Nodes("01.01.01").Nodes.Add("01.01.01.02", "modificar parametros", 3)
            If mcls_tvws.check_security(seguridad, "01.01.01.02") Then TreeView1.Nodes("01.01").Nodes("01.01.01").Nodes("01.01.01.02").Checked = vbTrue
            TreeView1.Nodes("01.01").Nodes("01.01.01").Nodes.Add("01.01.01.03", "ver log de parametros", 3)
            If mcls_tvws.check_security(seguridad, "01.01.01.03") Then TreeView1.Nodes("01.01").Nodes("01.01.01").Nodes("01.01.01.03").Checked = vbTrue
            TreeView1.Nodes("01.01").Nodes.Add("01.01.02", "seguridad", 4)
            If mcls_tvws.check_security(seguridad, "01.01.02") Then TreeView1.Nodes("01.01").Nodes("01.01.02").Checked = vbTrue
            TreeView1.Nodes("01.01").Nodes("01.01.02").Nodes.Add("01.01.02.01", "ver permisos", 2)
            If mcls_tvws.check_security(seguridad, "01.01.02.01") Then TreeView1.Nodes("01.01").Nodes("01.01.02").Nodes("01.01.02.01").Checked = vbTrue
            TreeView1.Nodes("01.01").Nodes("01.01.02").Nodes.Add("01.01.02.02", "modificar permisos", 3)
            If mcls_tvws.check_security(seguridad, "01.01.02.02") Then TreeView1.Nodes("01.01").Nodes("01.01.02").Nodes("01.01.02.02").Checked = vbTrue
            TreeView1.Nodes("01.01").Nodes("01.01.02").Nodes.Add("01.01.02.03", "ver log", 5)
            If mcls_tvws.check_security(seguridad, "01.01.02.03") Then TreeView1.Nodes("01.01").Nodes("01.01.02").Nodes("01.01.02.03").Checked = vbTrue
            TreeView1.Nodes("01.01").Nodes("01.01.02").Nodes.Add("01.01.02.04", "activar/desactivar usuario", 6)
            If mcls_tvws.check_security(seguridad, "01.01.02.04") Then TreeView1.Nodes("01.01").Nodes("01.01.02").Nodes("01.01.02.04").Checked = vbTrue
            'autorizaciones
            TreeView1.Nodes.Add("01.02", "autorizaciones", 7)
            If mcls_tvws.check_security(seguridad, "01.02") Then TreeView1.Nodes("01.02").Checked = True
            TreeView1.Nodes("01.02").Nodes.Add("01.02.01", "importar autorizacion")
            If mcls_tvws.check_security(seguridad, "01.02.01") Then TreeView1.Nodes("01.02").Nodes("01.02.01").Checked = vbTrue
            TreeView1.Nodes("01.02").Nodes.Add("01.02.02", "consultar autorizaciones", 9)
            If mcls_tvws.check_security(seguridad, "01.02.02") Then TreeView1.Nodes("01.02").Nodes("01.02.02").Checked = vbTrue
            TreeView1.Nodes("01.02").Nodes("01.02.02").Nodes.Add("01.02.02.01", "ver detalle de autorizacion", 10)
            If mcls_tvws.check_security(seguridad, "01.02.02.01") Then TreeView1.Nodes("01.02").Nodes("01.02.02").Nodes("01.02.02.01").Checked = vbTrue
            TreeView1.Nodes("01.02").Nodes("01.02.02").Nodes.Add("01.02.02.02", "ver liquidaciones asociadas", 11)
            If mcls_tvws.check_security(seguridad, "01.02.02.02") Then TreeView1.Nodes("01.02").Nodes("01.02.02").Nodes("01.02.02.02").Checked = vbTrue
            TreeView1.Nodes("01.02").Nodes("01.02.02").Nodes.Add("01.02.02.03", "borrar autorizacion", 12)
            If mcls_tvws.check_security(seguridad, "01.02.02.03") Then TreeView1.Nodes("01.02").Nodes("01.02.02").Nodes("01.02.02.03").Checked = vbTrue
            TreeView1.Nodes("01.02").Nodes("01.02.02").Nodes.Add("01.02.02.04", "exportar autorizacion", 13)
            If mcls_tvws.check_security(seguridad, "01.02.02.04") Then TreeView1.Nodes("01.02").Nodes("01.02.02").Nodes("01.02.02.04").Checked = vbTrue
            TreeView1.Nodes("01.02").Nodes("01.02.02").Nodes.Add("01.02.02.05", "borrar periodo")
            If mcls_tvws.check_security(seguridad, "01.02.02.05") Then TreeView1.Nodes("01.02").Nodes("01.02.02").Nodes("01.02.02.05").Checked = vbTrue
            'liquidaciones
            TreeView1.Nodes.Add("01.03", "liquidaciones")
            If mcls_tvws.check_security(seguridad, "01.03") Then TreeView1.Nodes("01.03").Checked = True
            TreeView1.Nodes("01.03").Nodes.Add("01.03.01", "generar nueva liquidacion")
            If mcls_tvws.check_security(seguridad, "01.03.01") Then TreeView1.Nodes("01.03").Nodes("01.03.01").Checked = vbTrue
            TreeView1.Nodes("01.03").Nodes("01.03.01").Nodes.Add("01.03.01.01", "previsualizar liquidacion")
            If mcls_tvws.check_security(seguridad, "01.03.01.01") Then TreeView1.Nodes("01.03").Nodes("01.03.01").Nodes("01.03.01.01").Checked = vbTrue
            TreeView1.Nodes("01.03").Nodes("01.03.01").Nodes.Add("01.03.01.02", "liquidar")
            If mcls_tvws.check_security(seguridad, "01.03.01.02") Then TreeView1.Nodes("01.03").Nodes("01.03.01").Nodes("01.03.01.02").Checked = vbTrue
            TreeView1.Nodes("01.03").Nodes.Add("01.03.02", "consultar liquidaciones")
            If mcls_tvws.check_security(seguridad, "01.03.01") Then TreeView1.Nodes("01.03").Nodes("01.03.02").Checked = vbTrue
            TreeView1.Nodes("01.03").Nodes("01.03.02").Nodes.Add("01.03.02.01", "ver detalle liquidacion")
            If mcls_tvws.check_security(seguridad, "01.03.02.01") Then TreeView1.Nodes("01.03").Nodes("01.03.02").Nodes("01.03.02.01").Checked = vbTrue
            TreeView1.Nodes("01.03").Nodes("01.03.02").Nodes.Add("01.03.02.02", "borrar liquidacion")
            If mcls_tvws.check_security(seguridad, "01.03.02.02") Then TreeView1.Nodes("01.03").Nodes("01.03.02").Nodes("01.03.02.02").Checked = vbTrue
            TreeView1.Nodes("01.03").Nodes("01.03.02").Nodes.Add("01.03.02.03", "reimprimir liquidacion")
            If mcls_tvws.check_security(seguridad, "01.03.02.03") Then TreeView1.Nodes("01.03").Nodes("01.03.02").Nodes("01.03.02.03").Checked = vbTrue
            'prestadores
            TreeView1.Nodes.Add("01.04", "prestadores")
            If mcls_tvws.check_security(seguridad, "01.04") Then TreeView1.Nodes("01.04").Checked = True
            TreeView1.Nodes("01.04").Nodes.Add("01.04.01", "consultar prestadores")
            If mcls_tvws.check_security(seguridad, "01.04.01") Then TreeView1.Nodes("01.04").Nodes("01.04.01").Checked = vbTrue
            TreeView1.Nodes("01.04").Nodes("01.04.01").Nodes.Add("01.04.01.01", "exportar prestadores")
            If mcls_tvws.check_security(seguridad, "01.04.01.01") Then TreeView1.Nodes("01.04").Nodes("01.04.01").Nodes("01.04.01.01").Checked = vbTrue
            TreeView1.ExpandAll()
        Catch ex As Exception
            MessageBox.Show("error cargando arbol de seguridad")
        End Try
    End Sub


    Private Sub TreeView1_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterCheck
        Try
            If Not e.Node.Checked Then                          'si el nodo seleccionado no esta chequeado
                mcls_tvws.DesmarcarSubNodos(e.Node.Nodes)       'desmarca todos los subnodos (recursivo)
            ElseIf e.Node.Checked Then                          'si el nodo seleccionado esta chequeado
                mcls_tvws.MarcarNodosPadre(e.Node)              'marca los nodos padre (recursivo)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdGuardarCambios_Click(sender As Object, e As EventArgs)
        Try
            Dim n As TreeNode
            For Each n In TreeView1.Nodes
                mcls_tvws.PrintNode(n)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdAceptarPeriodo_Click(sender As Object, e As EventArgs) Handles cmdAceptarPeriodo.Click
        Dim Conn As New SqlConnection(gsConnectionString)
        Try
            Dim stringSearch As String = ""
            TreeView1.Nodes.Clear()
            sUsuario = Trim(tbxNombreUsuario.Text)
            If sUsuario <> "" Then
                stringSearch = "select usuario_id as [id], usuario_nombre as [usuario], usuario_activo as activo from mtb_usuarios where usuarios.usuario_nombre like '%" & sUsuario & "%'"
            Else
                stringSearch = "select usuario_id as [id], usuario_nombre as [usuario], usuario_activo as activo from mtb_usuarios"
            End If
            dgvUsuarios.DataSource = Nothing
            Me.Cursor = Cursors.WaitCursor
            Dim Cmd As New SqlCommand(stringSearch, Conn)
            Dim Da As New SqlDataAdapter(Cmd)
            Dim Dt As New DataTable()
            Cmd.CommandType = CommandType.Text
            Cmd.Parameters.AddWithValue("@pmt1", Trim(sUsuario))
            Conn.Open()
            Da.Fill(Dt)
            If Dt.Rows.Count() > 0 Then
                dgvUsuarios.DataSource = Dt
                mdtg_Format(dgvUsuarios, "consolas", 11)
                dgvUsuarios.Columns(0).Visible = False
                dgvUsuarios.Columns(1).Width = 130
                dgvUsuarios.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                dgvUsuarios.Columns(2).Width = 70
                dgvUsuarios.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgvUsuarios.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show("error cargando usuarios")
        Finally
            Me.Cursor = Cursors.Default
            Conn.close()
            Conn.Dispose()
        End Try
    End Sub

    'Private Sub dgvUsuarios_SelectionChanged(sender As Object, e As EventArgs) Handles dgvUsuarios.SelectionChanged
    '    Try
    '        If loadState Then
    '            load_array(dgvUsuarios.CurrentRow.Cells(0).Value)
    '            load_tree()
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub


    Private Sub dgvUsuarios_MouseClick(sender As Object, e As MouseEventArgs) Handles dgvUsuarios.MouseClick
        Try
            If dgvUsuarios.CurrentRow.Cells(2).Value = 1 Then
                actualizar_tree()
            Else
                TreeView1.Nodes.Clear()
                MessageBox.Show("el usuario que desea ver se encuentra inactivo", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Sub actualizar_tree()
        Try
            TreeView1.Nodes.Clear()
            load_array(dgvUsuarios.CurrentRow.Cells(0).Value)
            load_tree()
        Catch ex As Exception

        End Try
    End Sub

    'guarda los cambios de seguridad que se realizaron sobre el control tree
    Private Sub cmdGuardarCambios_Click_1(sender As Object, e As EventArgs) Handles cmdGuardarCambios.Click
        If Not mcls_security.mfn_00001(cmdGuardarCambios.Tag) Then
            MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim iteracion As Int16 = 0
        Dim n As TreeNode
        Dim upperbound As Int16 = 0
        Dim conn As New SqlConnection(gsConnectionString)
        Dim cmd As New SqlCommand()
        cmd.Connection = conn
        cmd.CommandType = CommandType.Text
        Dim strsec As String
        Dim usr As String = dgvUsuarios.CurrentRow.Cells(0).Value
        iteration = 0       'seteamos en 0 el valor de la iteracion del array de seguridad
        ReDim valor(iteration)      'cada vez que guardamos la seguridad el array se reinicia
        mcls_log.proceso = "01.01.02.02"
        Try
            Cursor = System.Windows.Forms.Cursors.WaitCursor
            For Each n In TreeView1.Nodes
                mcls_tvws.PrintNode(n)
            Next
            upperbound = valor.GetUpperBound(0)
            If upperbound > 0 Then
                strsec = "delete from mtb_seguridad where seg_usuario_id = '" & Trim(usr) & "'"
                cmd.CommandText = strsec
                conn.Open()
                cmd.ExecuteNonQuery()
                For iteracion = 0 To upperbound
                    strsec = "insert into mtb_seguridad values ('" & usr & "'," & sArea & ",'" & Trim(valor(iteracion)) & "')"
                    cmd.CommandText = strsec
                    cmd.ExecuteNonQuery()
                Next
                conn.Close()
                mcls_log.detalle = "se guardaron las modificaciones de seguridad."
                mcls_log.log_event_ok()
                Cursor = System.Windows.Forms.Cursors.Default
                MessageBox.Show("cambios guardados correctamente, los cambios en la seguridad se aplicaran con el proximo inicio del sistema.", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            mcls_log.detalle = "error guardando modificaciones de seguridad (Sub cmdGuardarCambios_Click_1)"
            mcls_log.error_codigo = Err.Number
            mcls_log.error_descripcion = Err.Description
            mcls_log.log_event_error()
            Cursor = System.Windows.Forms.Cursors.Default
            MessageBox.Show("error guardando los cambios de seguridad", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub cmdSalir_Click(sender As Object, e As EventArgs) Handles cmdSalir.Click
        Me.Hide()
    End Sub

    Private Sub cmdVerLog_Click(sender As Object, e As EventArgs) Handles cmdVerLog.Click
        If Not mcls_security.mfn_00001(cmdVerLog.Tag) Then
            MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

    Private Sub cmdActivarDesactivar_Click(sender As Object, e As EventArgs) Handles cmdActivarDesactivar.Click
        If Not mcls_security.mfn_00001(cmdActivarDesactivar.Tag) Then
            MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

    End Sub

End Class