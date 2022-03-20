Imports Microsoft.Reporting.WinForms
Imports System.IO
Imports System.Threading
Imports System.Diagnostics

Friend Class clsSSRSManager

    Private Shared ReportServerURL As String = "http://mrburns/ReportServer"
    Private Shared ReportName As String
    Private Shared Parameters() As ReportParameter
    Private Shared FileName As String
    Private Shared OpenAfterSaving As Boolean
    Private Shared FileFormat As String

    Public Structure nResult

        Const Ok As Integer = 0
        Const ErrorFormatExport As Integer = 1
        Const ErrorCreateDirectory As Integer = 2
        Const ErrorDeleteLastReport As Integer = 3
        Const ErrorInvokeReport As Integer = 4
        Const ErrorFileSave As Integer = 5
        Const ErrorFileOpen As Integer = 6

    End Structure

    Friend Function ExportToFile(ReportName As String, Parameters() As ReportParameter, FileName As String,
                               Optional OpenAfterSaving As Boolean = False) As Integer


        clsSSRSManager.ReportName = ReportName
        clsSSRSManager.Parameters = Parameters
        clsSSRSManager.FileName = FileName
        clsSSRSManager.OpenAfterSaving = OpenAfterSaving

        Dim format As String = Path.GetExtension(clsSSRSManager.FileName).ToUpper

        Select Case format

            Case Is = ".XLS"
                clsSSRSManager.FileFormat = "EXCEL"
            Case Is = ".PDF"
                clsSSRSManager.FileFormat = "PDF"
            Case Else
                Return nResult.ErrorFormatExport
        End Select

        Return clsSSRSManager.Export()

    End Function

    Private Shared Function Export() As Boolean

        '---------------------------------------------------------------------------
        'Establecer directorio
        '---------------------------------------------------------------------------
        Dim DirOutput As String = Path.GetDirectoryName(clsSSRSManager.FileName) & "\"

        If DirOutput = "" Then DirOutput = Path.GetTempPath & "SSRS\"

        Try
            If Not Directory.Exists(DirOutput) Then
                Directory.CreateDirectory(DirOutput)
                Thread.Sleep(2000)
            End If
        Catch ex As Exception
            Return nResult.ErrorCreateDirectory
            Exit Function
        End Try


        '---------------------------------------------------------------------------
        'Establecer nombre de archivo
        '---------------------------------------------------------------------------
        Dim FileNamex As String = Path.GetFileName(clsSSRSManager.FileName)


        '---------------------------------------------------------------------------
        'Establecer fullpath de archivo
        '---------------------------------------------------------------------------
        Dim FullPathFileName As String = DirOutput & FileNamex


        '---------------------------------------------------------------------------
        'Borrar posible reporte existente en directorio
        '---------------------------------------------------------------------------
        Try
            If File.Exists(FullPathFileName) Then
                File.Delete(FullPathFileName)
            End If
        Catch ex As Exception
            Return nResult.ErrorDeleteLastReport
            Exit Function
        End Try


        '---------------------------------------------------------------------------
        'Invocar reporte
        '---------------------------------------------------------------------------
        Dim ReportViewer As New ReportViewer
        Try
            ReportViewer.ProcessingMode = ProcessingMode.Remote
            ReportViewer.ShowCredentialPrompts = False
            ReportViewer.ServerReport.ReportServerUrl = New Uri(clsSSRSManager.ReportServerURL)
            ReportViewer.ServerReport.ReportPath = "/" & ReportName
            ReportViewer.ServerReport.SetParameters(clsSSRSManager.Parameters)
            ReportViewer.ServerReport.Refresh()
            ReportViewer.Refresh()
        Catch ex As Exception
            Return nResult.ErrorInvokeReport
            Exit Function
        End Try



        '---------------------------------------------------------------------------
        'Exportar reporte a archivo
        '---------------------------------------------------------------------------
        Try
            Dim rptContent As Byte() = ReportViewer.ServerReport.Render(clsSSRSManager.FileFormat)
            Dim pdfPath As String = FullPathFileName
            Dim pdfFile As New FileStream(pdfPath, FileMode.Create)

            pdfFile.Write(rptContent, 0, rptContent.Length)
            pdfFile.Close()

        Catch ex As Exception
            Return nResult.ErrorFileSave
            Exit Function
        End Try



        '---------------------------------------------------------------------------
        'Abrir reporte
        '---------------------------------------------------------------------------
        Try
            If clsSSRSManager.OpenAfterSaving Then
                Dim p As Process = New Process
                p.StartInfo.FileName = FullPathFileName
                p.StartInfo.WindowStyle = ProcessWindowStyle.Maximized
                p.Start()
            End If
        Catch ex As Exception
            Return nResult.ErrorFileOpen
            Exit Function
        End Try

        Return nResult.Ok

    End Function

End Class

'---------------------------------------------------------------------------------------
'DOCU BACK
'---------------------------------------------------------------------------------------
'ReportViewer1.ServerReport.ReportServerCredentials = New CredencialesReporting("Usuario", "*********", "")

'Get a reference to the default credentials  
'Dim credentials As System.Net.ICredentials
'credentials = System.Net.CredentialCache.DefaultCredentials

'Get a reference to the report server credentials  
'Dim rsCredentials As ReportServerCredentials
'rsCredentials = serverReport.ReportServerCredentials

'Set the credentials for the server report  
'rsCredentials.NetworkCredentials = credentials
'---------------------------------------------------------------------------------------
