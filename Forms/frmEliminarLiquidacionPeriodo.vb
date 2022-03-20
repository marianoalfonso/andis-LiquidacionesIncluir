Imports System.Data.SqlClient

Public Class frmEliminarLiquidacionPeriodo

    Private Sub frmEliminarLiquidacionPeriodo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Cargar_Combos()
    End Sub

    Sub Cargar_Combos()
        cmbMonth.Items.Clear()
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
        cmbMonth.SelectedIndex = 0
        cmbYear.Items.Clear()
        cmbYear.Items.Add("2014")
        cmbYear.Items.Add("2015")
        cmbYear.Items.Add("2016")
        cmbYear.Items.Add("2017")
        cmbYear.Items.Add("2018")
        cmbYear.Items.Add("2019")
        cmbYear.Items.Add("2020")
        cmbYear.Items.Add("2021")
        cmbYear.Items.Add("2022")
        cmbYear.Items.Add("2023")
        cmbYear.Items.Add("2024")
        cmbYear.Items.Add("2025")
        cmbYear.Items.Add("2026")
        cmbYear.Items.Add("2027")
        cmbYear.Items.Add("2028")
        cmbYear.Items.Add("2029")
        cmbYear.Items.Add("2030")
        cmbYear.SelectedIndex = 1
        cmbArea.Items.Clear()
        cmbArea.Items.Add("Discapacidad")
        cmbArea.Items.Add("Geriatria")
        cmbArea.Items.Add("Hemodialisis")
        cmbArea.SelectedIndex = 0
        Me.Top = 2
        Me.Left = 2
    End Sub

    Private Sub cmdAceptarPeriodo_Click(sender As System.Object, e As System.EventArgs) Handles cmdAceptarPeriodo.Click
        Dim sPeriodo As String
        Dim sArea As String
        Dim sEntidad As String
        Dim result1 As DialogResult = MessageBox.Show("Recuerde realizar backup antes de proceder", _
            "Important Question", _
            MessageBoxButtons.YesNo)
        If result1 = vbYes Then
            sPeriodo = Trim(cmbMonth.Text) & Trim(cmbYear.Text)
            sArea = cmbArea.Text.Substring(0, 1)
            sEntidad = gsSector
            Borrar_Datos(sPeriodo, sArea, sEntidad)
        ElseIf result1 = vbNo Then
            Me.Close()
            Me.Dispose()
            Me.DestroyHandle()
        End If
    End Sub

    Sub Borrar_Datos(ByVal sPeriodo As String, ByVal sArea As String, ByVal sEntidad As String)
        Try
            Dim Conn As New SqlConnection(gsConnectionString)
            Dim Cmd As New SqlCommand
            Cmd.CommandText = "sp_ELIMINAR_LIQUIDACION_PERIODO"
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Connection = Conn
            Cmd.Parameters.AddWithValue("@ENTIDAD", sEntidad)
            Cmd.Parameters.AddWithValue("@AREA", sArea)
            Cmd.Parameters.AddWithValue("@PERIODO", sPeriodo)
            Conn.Open()
            Cmd.ExecuteScalar()
            Conn.Close()
            MessageBox.Show("Proceso de eliminación generado en forma correcta", "Important Question", _
            MessageBoxButtons.OK)
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub


End Class