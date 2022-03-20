Imports System.Data.SqlClient
Public Class frm04001

    Dim sCodigoPrestador As Int32 = 0
    Dim sRazonSocial As String = ""
    Dim sCuit As String = ""
    Dim mcls_00006 As New mcls_00006

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub frm04001_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 70
        Me.Left = 20
        Me.Text = "consulta de prestadores"

        set_environment()
    End Sub


    Private Sub set_environment()
        Try
            cmdExportar.Tag = "01.04.01"
            'codigo
            chkCodigo.Checked = False
            tbxCodigo.Enabled = False
            tbxCodigo.Visible = False
            'cuit
            chkCuit.Checked = False
            mebCuit.Enabled = False
            mebCuit.Visible = False
            'razon social
            chkRazonSocial.Checked = False
            tbxRazonSocial.Enabled = False
            tbxRazonSocial.Visible = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub chkCodigo_CheckedChanged(sender As Object, e As EventArgs) Handles chkCodigo.CheckedChanged
        If chkCodigo.Checked Then
            tbxCodigo.Enabled = True
            tbxCodigo.Visible = True
            tbxCodigo.Text = ""
        Else
            tbxCodigo.Enabled = False
            tbxCodigo.Visible = False
        End If
    End Sub

    Private Sub chkCuit_CheckedChanged(sender As Object, e As EventArgs) Handles chkCuit.CheckedChanged
        If chkCuit.Checked Then
            mebCuit.Enabled = True
            mebCuit.Visible = True
            mebCuit.Text = ""
        Else
            mebCuit.Enabled = False
            mebCuit.Visible = False
        End If
    End Sub

    Private Sub chkRazonSocial_CheckedChanged(sender As Object, e As EventArgs) Handles chkRazonSocial.CheckedChanged
        If chkRazonSocial.Checked Then
            tbxRazonSocial.Enabled = True
            tbxRazonSocial.Visible = True
            tbxRazonSocial.Text = ""
        Else
            tbxRazonSocial.Enabled = False
            tbxRazonSocial.Visible = False
        End If
    End Sub

    'asigno valores de busqueda y habilito la busqueda
    Function assign_parameters() As Boolean
        Dim flagSearch As Boolean = False
        Try
            'asigno codigo de prestador
            If chkCodigo.Checked Then
                If Not Integer.TryParse(Trim(tbxCodigo.Text), sCodigoPrestador) Then
                    sCodigoPrestador = 0
                End If
                flagSearch = True
            Else
                sCodigoPrestador = 0
                flagSearch = True
            End If
            'asigno razon social
            If chkRazonSocial.Checked Then
                sRazonSocial = Trim(tbxRazonSocial.Text)
                flagSearch = True
            Else
                sRazonSocial = ""
            End If
            'asigno cuit
            If chkCuit.Checked Then
                mebCuit.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals
                sCuit = Trim(mebCuit.Text)
                mebCuit.TextMaskFormat = MaskFormat.IncludePromptAndLiterals
                flagSearch = True
            Else
                sCuit = ""
            End If
            Return flagSearch
        Catch ex As Exception
            MsgBox("revise los parámetros de la consulta", vbCritical)
            Return False
        End Try
    End Function

    Private Sub cmdAceptarPeriodo_Click(sender As Object, e As EventArgs) Handles cmdAceptarPeriodo.Click
        Try
            dgvPrestadores.DataSource = Nothing
            Application.DoEvents()
            If assign_parameters() Then
                Me.Cursor = Cursors.WaitCursor
                Dim Conn As New SqlConnection(gsConnectionString)
                Dim Cmd As New SqlCommand("mpa_00700", Conn)
                Dim Da As New SqlDataAdapter(Cmd)
                Dim Dt As New DataTable()
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Parameters.AddWithValue("@pmt2", Trim(sCodigoPrestador))
                Cmd.Parameters.AddWithValue("@pmt3", Trim(sRazonSocial))
                Cmd.Parameters.AddWithValue("@pmt4", Trim(sCuit))
                Cmd.Parameters.AddWithValue("@pmt5", Trim(sArea))
                Conn.Open()
                Da.Fill(Dt)
                If Dt.Rows.Count > 0 Then   'check for any row
                    dgvPrestadores.DataSource = Dt
                    mdtg_Format(dgvPrestadores, "consolas", 9)

                    'formato grid
                    dgvPrestadores.Columns(0).Width = 60
                    dgvPrestadores.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPrestadores.Columns(1).Width = 100
                    dgvPrestadores.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPrestadores.Columns(2).Width = 220
                    dgvPrestadores.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    dgvPrestadores.Columns(3).Width = 80
                    dgvPrestadores.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPrestadores.Columns(4).Width = 120
                    dgvPrestadores.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                    dgvPrestadores.Columns(5).Width = 100
                    dgvPrestadores.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    dgvPrestadores.Columns(6).Width = 80
                    dgvPrestadores.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    Me.Cursor = Cursors.Default
                Else
                    Me.Cursor = Cursors.Default
                    MessageBox.Show("no se encontraron datos")
                End If
            End If
        Catch ex As Exception
            Me.Cursor = Cursors.Default
            MessageBox.Show(Err.Description)
        End Try
    End Sub

    Private Sub cmdExportar_Click(sender As Object, e As EventArgs) Handles cmdExportar.Click
        If Not mcls_00006.mfn_00001(cmdExportar.Tag) Then
            MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Hide()
    End Sub

End Class