Imports System.Data.SqlClient

Public Class cls_00002

    Friend Function mfn_00002(periodo As String) As Boolean
        'search periodo in a previously loaded array
        Try
            Dim find As Int16 = Array.IndexOf(periodos, periodo)
            If find <> -1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class
