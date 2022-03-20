Public Class mcls_00006

    Public Function mfn_00001(param As String)
        Try
            For Each element In seguridad
                If element = param Then
                    Return True
                End If
            Next
            Return False
        Catch ex As Exception
            Return False
        End Try
    End Function


End Class
