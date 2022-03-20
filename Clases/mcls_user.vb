Imports System.Data.SqlClient
Imports System.DirectoryServices
Imports System.DirectoryServices.AccountManagement  'must be referenced in the project

Public Class mcls_user
    'attributes


    'methods
    'usrValidateLocal   :   valida usuario / sector de forma local contra la DB                                 tested ok   discontinuado???
    'isAuthenticated    :   valida el usuario contra active directory                                           tested ok
    'usrValidateGrants  :   valida area / sector (y en futuro procesos) de forma local contra la DB             tested ok
    'mfn_00001          :   validate a permission on a preloaded memory array                                   tested ok
    'mfn_00006          :   load user permissions into an array                                                 tested ok

    Public Function usrValidateLocal(usuario As String, password As String) As Boolean
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Dim cmdtext As String = ""
        Dim value As Integer = 0
        Try
            Cmd.CommandType = CommandType.Text
            cmdtext = "select COUNT(*) from [dbo].[mtb_usuarios] where [usuario_id] = '" &
                usuario & "' and [usuario_pwd] = '" & password & "'"
            Cmd.CommandText = cmdtext
            Cmd.Connection = Conn
            Conn.Open()
            value = Cmd.ExecuteScalar()
            If value = 1 Then
                Return True
            ElseIf value = 0 Then
                Return False
            End If
        Catch ex As Exception
            Return False
        Finally
            Conn.Close()
            Conn.Dispose()
        End Try
    End Function

    'Public Function usrValidateGrants() As Boolean
    '    Dim Conn As New SqlConnection(gsConnectionString)
    '    Dim Cmd As New SqlCommand
    '    Dim cmdtext As String = ""
    '    Dim value As Integer = 0
    '    Try
    '        Cmd.CommandType = CommandType.Text
    '        cmdtext = "select count(*) from [dbo].[mvw_security] where [permisos_usuario_id] = '" &
    '            sUsuario & "' and [permisos_sector_id] = " & sSector & " and [permisos_area_id] = " & sArea
    '        Cmd.CommandText = cmdtext
    '        Cmd.Connection = Conn
    '        Conn.Open()
    '        value = Cmd.ExecuteScalar()
    '        If value >= 1 Then
    '            Return True
    '        ElseIf value = 0 Then
    '            Return False
    '        End If
    '    Catch ex As Exception
    '        Return False
    '    Finally
    '        Conn.Close()
    '        Conn.Dispose()
    '    End Try
    'End Function

    'valida el usuario y contraseña contra AD
    Public Function isAuthenticated(usuario As String, password As String) As Boolean
        Try
            Dim grupos As New List(Of String)
            Dim context As New PrincipalContext(ContextType.Domain)
            Dim auth As Boolean = context.ValidateCredentials(usuario, password)
            Dim user As UserPrincipal = UserPrincipal.FindByIdentity(context, usuario)
            If Not IsNothing(user) And auth Then
                Dim userGroups As PrincipalSearchResult(Of Principal) = user.GetAuthorizationGroups()
                For Each group As Principal In userGroups
                    grupos.Add(group.Name)
                Next
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return False
        End Try
    End Function

    Public Function mfn_00006() As String()
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand("mpa_00006", Conn)
        Dim Dr As SqlDataReader

        Dim a As Int16 = -1
        Try
            Cmd.CommandType = CommandType.StoredProcedure
            Cmd.Parameters.AddWithValue("@usuario", sUsuario)
            Cmd.Parameters.AddWithValue("@area", sArea)
            Conn.Open()
            Dr = Cmd.ExecuteReader()
            While Dr.Read = True
                a += 1
                ReDim Preserve seguridad(a)
                seguridad(a) = Dr.Item("modulo")
            End While
            Dr.Close()
            Return seguridad
        Catch ex As Exception
            MessageBox.Show("error seteando environment")
            'ver para retornar matriz vacia (error)
        Finally
            Conn.Close()
            Conn.Dispose()
        End Try
    End Function

    'verifica si esta habiltado para el proceso recibido
    'como parámetro
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
