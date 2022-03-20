Imports System.Data.SqlClient

Public Class frm03002

    Public l_numliq As Integer = 0
    Dim c_liq As New clsLiquidacion

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        setEnvironment()

    End Sub

    Sub setEnvironment()
        Me.Text = "detalle de liquidación"
        Me.Top = 100
        Me.Left = 70
    End Sub

    Private Sub frm03002_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim dt As DataTable
        Try
            dgv_DetalleLiquidacion.DataSource = Nothing
            dt = c_liq.detalleliquidacion(l_numliq)
            If dt.Rows.Count > 0 Then
                dgv_DetalleLiquidacion.DataSource = dt
                mdtg_Format(dgv_DetalleLiquidacion, "consolas", 9)
                dgv_DetalleLiquidacion.Columns(0).Visible = False
                dgv_DetalleLiquidacion.Columns(0).Width = 70
                dgv_DetalleLiquidacion.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv_DetalleLiquidacion.Columns(1).Width = 110
                dgv_DetalleLiquidacion.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv_DetalleLiquidacion.Columns(2).Width = 210
                dgv_DetalleLiquidacion.Columns(3).Width = 90
                dgv_DetalleLiquidacion.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                dgv_DetalleLiquidacion.Columns(4).Width = 220
                dgv_DetalleLiquidacion.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv_DetalleLiquidacion.Columns(5).Width = 120
                dgv_DetalleLiquidacion.Columns(5).DefaultCellStyle.Format = "c"
                dgv_DetalleLiquidacion.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv_DetalleLiquidacion.Columns(6).Width = 120
                dgv_DetalleLiquidacion.Columns(6).DefaultCellStyle.Format = "c"
                dgv_DetalleLiquidacion.Columns(6).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv_DetalleLiquidacion.Columns(7).Width = 120
                dgv_DetalleLiquidacion.Columns(7).DefaultCellStyle.Format = "c"
                dgv_DetalleLiquidacion.Columns(7).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
                dgv_DetalleLiquidacion.Columns(8).Width = 120
                dgv_DetalleLiquidacion.Columns(8).DefaultCellStyle.Format = "c"
                dgv_DetalleLiquidacion.Columns(8).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Hide()
    End Sub

End Class