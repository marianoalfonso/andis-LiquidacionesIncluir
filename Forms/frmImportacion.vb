Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Security
Imports System.Security.Permissions

Public Class frmImportacion
    Dim sArea As Char

    Public Property Area() As Char
        Get
            Return sArea
        End Get
        Set(value As Char)
            sArea = value
        End Set

    End Property

    Private Sub frmImportacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Listar_Archivos()

    End Sub

    Private Sub Listar_Archivos()
        Dim sFiltro As String
        Dim sItem As String
        Try
            Select Case sArea
                Case "D"
                    sFiltro = "CD"
                Case "H"
                    sFiltro = "CH"
                Case "G"
                    sFiltro = "CG"
            End Select
            sFiltro = sFiltro + "*.txt"
            lvArchivos.BeginUpdate()
            lvArchivos.Clear()
            For Each Archivo As String In My.Computer.FileSystem.GetFiles( _
                                 "C:\ArchivosFacturacion", _
                                 FileIO.SearchOption.SearchTopLevelOnly, _
                                 sFiltro)
                sItem = Mid(Archivo, Len(gsPath) + 1, Len(Archivo) - Len(gsPath))
                lvArchivos.Items.Add(sItem)
            Next
            lvArchivos.EndUpdate()
            lblArchivosPendientes.Text = "Archivos pendientes: " + Str(lvArchivos.Items.Count)
        Catch oe As Exception
            MsgBox(oe.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportar.Click
        Dim sArchivoImportado() As Registro

        txtArchivosAImportar.Text = lvArchivos.Items.Count
        txtArchivosAImportar.Text = lvArchivos.Items.Count

        For i = 0 To lvArchivos.Items.Count - 1
            If lvArchivos.Items(i).Checked = True Then

                lblArchivoEnMigracion.Text = lvArchivos.Items(i).Text

                sArchivoImportado = ImportarArchivo2(lvArchivos.Items(i).Text)
                If GrabarFacturacion(sArchivoImportado, Me.Area) Then

                    txtArchivosImportados.Text = i + 1
                    txtArchivosImportados.Refresh()

                    '    MsgBox("Importacion finalizada: " + lvArchivos.Items(i).Text, vbInformation)
                    '    Archivo_Importado(lvArchivos.Items(i).Text)
                End If
            End If
        Next
        Call Listar_Archivos()
        lvArchivos.Refresh()
        MsgBox("Importacion finalizada", vbInformation)
    End Sub

    Private Sub btnSeleccionarTodos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeleccionarTodos.Click
        If btnSeleccionarTodos.Tag = "marcados" Then
            btnSeleccionarTodos.Tag = "desmarcados"
            btnSeleccionarTodos.Text = "Limpiar Seleccion"
            For i = 0 To lvArchivos.Items.Count - 1
                If lvArchivos.Items(i).Checked = False Then
                    lvArchivos.Items(i).Checked = True
                End If
            Next
        Else
            btnSeleccionarTodos.Tag = "marcados"
            btnSeleccionarTodos.Text = "Seleccionar Todos"
            For i = 0 To lvArchivos.Items.Count - 1
                If lvArchivos.Items(i).Checked = True Then
                    lvArchivos.Items(i).Checked = False
                End If
            Next
        End If
    End Sub

    Private Sub brnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brnCerrar.Click
        Me.Close()
    End Sub



    'TESTEO DE CODIGO

End Class