Imports System.Data.SqlClient

Public Class frmConsultarCreditos
    Private sArea As String
    Private sPeriodo As String
    Private sCuit As String


    'RECIBE LA VARIABLE DE AREA
    Public Property Area() As String
        Get
            Return sArea
        End Get
        Set(value As String)
            If value <> "" Then
                sArea = value
            End If
        End Set
    End Property

    Private Sub frmConsultarCreditos_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Call Configurar_Formulario()
    End Sub

    Sub Configurar_Formulario()
        Try
            cmbMonth.Items.Add("01")
            cmbMonth.Items.Add("02")
            cmbMonth.Items.Add("03")
            cmbMonth.Items.Add("04")
            cmbMonth.Items.Add("05")
            cmbMonth.Items.Add("06")
            cmbMonth.Items.Add("07")
            cmbMonth.Items.Add("08")
            cmbMonth.Items.Add("09")
            cmbMonth.Items.Add("10")
            cmbMonth.Items.Add("11")
            cmbMonth.Items.Add("12")
            cmbYear.Items.Add("2012")
            cmbYear.Items.Add("2013")
            cmbYear.Items.Add("2014")
            cmbYear.Items.Add("2015")
            cmbYear.Items.Add("2016")
            cmbYear.Items.Add("2017")
            cmbYear.Items.Add("2018")
            cmbYear.Items.Add("2019")
            cmbYear.Items.Add("2020")
            Me.Top = 2
            Me.Left = 2
        Catch ex As Exception
            MsgBox(Err.Description)
        End Try
    End Sub



    Private Sub cmdAceptarPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cmdAceptarPeriodo.Click
        Try
            Cursor.Current = Cursors.WaitCursor

            sPeriodo = Trim(cmbMonth.Text) & Trim(cmbYear.Text)
            sCuit = Limpiar_Cadena(Trim(mebCuit.Text), "-")

            Dim Conn As New SqlConnection(gsConnectionString)
            Dim Cmd As New SqlCommand
            Dim Da As New SqlDataAdapter(Cmd)
            Dim Dt As New DataTable()

            Cmd.CommandText = "pa_OBTENER_CREDITOS"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@p_PERIODO", Trim(sPeriodo))
            Cmd.Parameters.AddWithValue("@p_AREA", Trim(sArea))
            Cmd.Parameters.AddWithValue("@p_CUIT", Trim(sCuit))
            Conn.Open()
            'Cmd.ExecuteNonQuery()
            REM SI EJECUTO EL NONQUERY ME VUELVE A EJECUTAR EL STORE

            Da.Fill(Dt)
            DataGridView1.DataSource = Dt


            Me.DataGridView1.Font = New System.Drawing.Font("Times New Roman", 8)

            'ALINEAMOS AL CENTRO LAS CABECERAS
            DataGridView1.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView1.Columns(0).HeaderText = "Periodo"
            DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            DataGridView1.Columns(1).Width = 170
            DataGridView1.Columns(1).HeaderText = "Establecimiento"
            DataGridView1.Columns(2).Width = 80
            DataGridView1.Columns(2).HeaderText = "Beneficio"
            DataGridView1.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            DataGridView1.Columns(3).Width = 200
            DataGridView1.Columns(3).HeaderText = "Nombre"
            DataGridView1.Columns(4).Width = 80
            DataGridView1.Columns(4).HeaderText = "Detalle Prestacion"
            DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(5).Width = 300
            DataGridView1.Columns(5).HeaderText = "Descripcion"
            DataGridView1.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(6).HeaderText = "Saldo"
            DataGridView1.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            DataGridView1.Columns(6).DefaultCellStyle.Format = "##,##0.00"
            DataGridView1.ColumnHeadersDefaultCellStyle.Font = New Font("Tahoma", 9, FontStyle.Bold)
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()

            Call Consultar_Liquidaciones_Periodo()

        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub


    Sub Consultar_Liquidaciones_Periodo()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim Conn As New SqlConnection(gsConnectionString)
            Dim Cmd As New SqlCommand
            Dim Da As New SqlDataAdapter(Cmd)
            Dim Dt As New DataTable()
            Cmd.CommandText = "pa_LISTAR_LIQUIDACIONES_PRESTADOR_PERIODO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@p_CUITPRESTADOR", sCuit)
            Cmd.Parameters.AddWithValue("@p_PERIODO", sPeriodo)
            Conn.Open()
            Da.Fill(Dt)
            DataGridView2.DataSource = Dt
            Me.DataGridView2.Font = New System.Drawing.Font("Times New Roman", 8)
            DataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DataGridView2.Columns(0).Width = 300
            DataGridView2.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            DataGridView2.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            Conn.Close()
            Conn.Dispose()
            Cmd.Dispose()
        Catch ex As Exception
            MsgBox(Err.Description)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Me.Close()
        Me.Dispose()
        Me.DestroyHandle()
    End Sub
End Class