Imports System.Data.SqlClient
Imports System
Imports System.IO
Imports System.Data
Imports System.Text
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports Microsoft.Reporting.WinForms
Imports System.Configuration


Public Class frmDefault

    Dim log As New clsLog
    Dim mcls_00006 As New mcls_00006

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            setSecurityEnvironment()
            'enableSecurityOptions()
        Catch ex As Exception

        End Try
    End Sub

    'seteamos las variables que determinan los codigos de modulos y procesos
    Private Sub setSecurityEnvironment()
        gsFormulario = "frmDefault"
        sModulo = 0
        sProceso = Nothing
        Log.detalle = ""
        Log.error_codigo = 0
        log.error_descripcion = ""




    End Sub

    'seteamos en blanco las variables que determinan los codigos de modulos y procesos
    Private Sub cleanSecurityEnvironment()
        sModulo = 0
        sProceso = 0
    End Sub

    Private Sub enableSecurityOptions()
        'Try
        '    ImportarArchivosDiscapacidadToolStripMenuItem.Enabled = False
        '    ConfigurarConsolidacionesToolStripMenuItem.Enabled = False
        'Catch ex As Exception

        'End Try
    End Sub


    Private Sub frmDefault_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Configurar_Formulario()
    End Sub

    Sub Configurar_Formulario()
        Me.Text = gsSistema

        'If gsArea = "Discapacidad" Then
        '    ConsolidarPeriodosToolStripMenuItem.Enabled = True
        'Else
        '    ConsolidarPeriodosToolStripMenuItem.Enabled = False
        'End If
    End Sub

    Private Sub ImportarArchivosDiscapacidadToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImportarArchivosDiscapacidadToolStripMenuItem.Click
        Dim frmImportacion As New frmImportacion
        'frmImportacion.MdiParent = Me
        'frmImportacion.WindowState = FormWindowState.Maximized
        frmImportacion.Area = UCase(Mid(Login.cmbAreas.Text, 1, 1))
        frmImportacion.ShowDialog()
    End Sub


    Private Sub NuevaLiquidacionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles NuevaLiquidacionToolStripMenuItem.Click
        Dim frmLiquidacion As New frmLiquidacion
        frmLiquidacion.Tag = "01.03.01"
        frmLiquidacion.WindowState = FormWindowState.Normal
        'If mcls_00006.mfn_00001(frmLiquidacion.Tag) Then

        frmLiquidacion.Show()
        'frmLiquidacion.ShowDialog()

        'Else
        '    MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub




    'Private Sub EliminarLiquidacionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EliminarLiquidacionToolStripMenuItem.Click
    '    Try
    '        Dim frmEliminarLiquidacion As New frmEliminarLiquidacion
    '        'frmEliminarLiquidacion.MdiParent = Me
    '        frmEliminarLiquidacion.ShowDialog()
    '    Catch ex As Exception
    '        MsgBox(Err.Description)
    '        Me.Close()
    '    End Try
    'End Sub

    'Private Sub VersionToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
    '    Try
    '        Dim frmAboutBox As New frmAboutBox
    '        frmAboutBox.MdiParent = Me
    '        frmAboutBox.Show()
    '    Catch ex As Exception
    '        MsgBox(Err.Description)
    '        Me.Close()
    '    End Try
    'End Sub

    Private Sub ConsultarCreditosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Try

            Dim frmConsultarCreditos As New frmConsultarCreditos
            '    frmConsultarCreditos.MdiParent = Me

            frmConsultarCreditos.WindowState = FormWindowState.Normal
            frmConsultarCreditos.Area = UCase(gsArea.Substring(0, 1))

            frmConsultarCreditos.ShowDialog()

        Catch ex As Exception
            MsgBox(Err.Description)
            Me.Close()
        End Try
    End Sub

    'Private Sub EliminarLiquidacionPorPeriodoToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles EliminarLiquidacionPorPeriodoToolStripMenuItem.Click

    '    Dim Password As String
    '    Password = InputBox("Ingrese Password:", vbCritical)
    '    If Password <> "@cerati@" Then
    '        MsgBox("Error. No tiene autorizacion para eliminar liquidaciones", vbCritical)
    '        Exit Sub
    '    Else
    '        Dim frmEliminarLiquidacionPeriodo As New frmEliminarLiquidacionPeriodo
    '        frmEliminarLiquidacionPeriodo.MdiParent = Me
    '        frmEliminarLiquidacionPeriodo.WindowState = FormWindowState.Normal
    '        frmEliminarLiquidacionPeriodo.Show()
    '    End If
    'End Sub

    Private Sub UsuarioToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs)
        Dim usrLogueado As String
        usrLogueado = Environment.UserName
        MsgBox("UserName: " & usrLogueado)

    End Sub


    'Private Sub TecnicalStatusToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TecnicalStatusToolStripMenuItem.Click
    '    Dim Cadena_Conexion As String = gsConnectionString
    '    Dim Area As String = gsArea
    '    Dim Sector As String = gsSector
    '    If InputBox("<.>", "<.>", "⌘") = "incluir877" Then
    '        MsgBox(Cadena_Conexion & Chr(13) & Area & Chr(13) & Sector, vbInformation)
    '        MsgBox("periodo1: " & sPeriodoConsolidacion1 & Chr(13) & "periodo2: " & sPeriodoConsolidacion2, vbInformation)
    '    Else
    '        MsgBox("secuence override")
    '    End If
    'End Sub

    'Private Sub ConsolidarPeriodosToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ConsolidarPeriodosToolStripMenuItem.Click
    '    Dim frmConsolidacion As New frmConsolidacion
    '    frmConsolidacion.ShowDialog()
    'End Sub

    'Private Sub TestAreaToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles TestAreaToolStripMenuItem.Click
    '    sandbox.Show()

    'End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles SalirToolStripMenuItem.Click
        Environment.Exit(0)
    End Sub

    Private Sub ConsultarAutorizacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarAutorizacionesToolStripMenuItem.Click
        'Dim mcls_00006 As New mcls_00006
        Dim frmAutorizaciones As New frm02002
        frmAutorizaciones.Tag = "01.02.02"
        frmAutorizaciones.WindowState = FormWindowState.Normal
        'If mcls_00006.mfn_00001(frmAutorizaciones.Tag) Then
        frmAutorizaciones.ShowDialog()
        'Else
        '    MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        'End If
    End Sub

    Private Sub ConsultarLiquidacionesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarLiquidacionesToolStripMenuItem.Click
        Try
            Dim frmEliminarLiquidacion As New frmEliminarLiquidacion
            frmEliminarLiquidacion.Tag = "01.03.02"
            'If mcls_00006.mfn_00001(frmEliminarLiquidacion.Tag) Then
            frmEliminarLiquidacion.ShowDialog()
            'Else
            '    MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            'End If
        Catch ex As Exception
            MsgBox(Err.Description)
            Me.Close()
        End Try
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        Dim frm04001 As New frm04001
        Try
            frm04001.Tag = "01.04.01"
            If mcls_00006.mfn_00001(frm04001.Tag) Then
                frm04001.ShowDialog()
            Else
                MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        End Try
    End Sub


    Private Sub SeguridadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SeguridadToolStripMenuItem.Click
        Dim frm01003 As New frm01003

        frm01003.ShowDialog()

        'Try
        '    frm01003.Tag = "01.01.02"
        '    If mcls_00006.mfn_00001(frm01003.Tag) Then
        '        frm01003.ShowDialog()
        '    Else
        '        MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub parametros_generales_Click(sender As Object, e As EventArgs) Handles parametros_generales.Click
        Dim frm01000 As New frm01000
        Try
            frm01000.Tag = "01.01.01"
            If mcls_00006.mfn_00001(frm01000.Tag) Then
                frm01000.ShowDialog()
            Else
                MessageBox.Show("módulo no autorizado", "seguridad", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ConsultarComplementariasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarComplementariasToolStripMenuItem.Click
        Dim frm02003 As New frm02003
        Try
            'frm02003.Tag = ""
            'If mcls_00006.mfn_00001(frm02003.Tag) Then
            frm02003.ShowDialog()
            'Else
            '    MessageBox.Show("módulo no autorizado")
            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmDefault_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Environment.Exit(0)
    End Sub
End Class