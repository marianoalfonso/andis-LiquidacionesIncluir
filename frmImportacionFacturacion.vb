Public Class frmImportacionFacturacion

    Private mCuit As String
    Public Property Cuit() As String
        Get
            Return mCuit
        End Get
        Set(ByVal value As String)
            mCuit = value
        End Set
    End Property

    Sub Listar_Archivos_Periodo(ByVal Periodo As String)
        Dim Filtro As String
        Filtro = "CD" + Trim(Periodo) + "*.txt"
        Try
            For Each Archivo As String In My.Computer.FileSystem.GetFiles _
                ("c:\ArchivosFacturacion", FileIO.SearchOption.SearchAllSubDirectories, Filtro)
                '   lstArchivosFacturacion.Items.Add(Obtener_Cuit(Archivo) + " - " + Obtener_Factura(Archivo))

                lstArchivosFacturacion.Items.Add(Mid(Archivo, 24, Len(Archivo) - 23))

                '      lstArchivosFacturacion.Items.Add(Archivo)
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        lstArchivosFacturacion.Items.Clear()
        Listar_Archivos_Periodo(Trim(TextBox1.Text))
    End Sub


    '    Private Sub txtValidar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtValidar.Click
    '       If ValidarArchivo(lstArchivosFacturacion.SelectedItem.ToString) Then
    '          Label1.Text = "archivo validado"
    '     Else
    '        Label1.Text = "ERROR DE VALIDACION"
    '   End If
    'End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim sRuta As String
        Dim sPrestador As String
        sRuta = lstArchivosFacturacion.SelectedItem.ToString
        '     a = ImportarArchivo(lstArchivosFacturacion.SelectedItem.ToString)
        sPrestador = ConfigGet(sRuta, "HEADER", "PRESTADOR")
    End Sub

    Private Sub frmImportacionFacturacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox2.Text = mCuit
    End Sub
End Class
