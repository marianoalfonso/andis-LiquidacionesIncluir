Public Class clsConfiguration

    Private local_file As String        'archivo de configuracion
    'Private local_section As String      'seccion de la configuracion
    'Public local_item As String         'valor buscado

    'constructor de la clase
    Sub New(ByVal file As String)
        Me.local_file = file
    End Sub


    'busca el valor sobre los parametros recibidos
    Public Function SearchValue(ByVal section As String, ByVal item As String) As String
        Try
            Dim sAux As String
            Dim bytFound As Byte
            Dim sPath As String = Trim(local_file)
            Dim sFile As New IO.StreamReader(sPath)
            Dim found As String = ""
            Do While Not sFile.EndOfStream
                sAux = Trim(sFile.ReadLine)
                bytFound = InStr(sAux, section)
                If bytFound > 0 Then
                    Exit Do
                End If
            Loop
            If bytFound > 0 Then    'Si encontro la cadena
                bytFound = 0
                Do While Not sFile.EndOfStream
                    sAux = Trim(sFile.ReadLine)
                    bytFound = InStr(sAux, item)  'InStr Busca strItem en el archivo
                    If bytFound > 0 Then
                        found = Mid(sAux, InStr(sAux, "=") + 1) 'Extrae el resultado
                        Return found
                        Exit Do
                    End If
                Loop
            End If
        Catch ex As Exception
            MsgBox("error obteniendo la configuracion . . .", vbCritical)
            Return ""
        End Try
    End Function

End Class
