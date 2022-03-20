Imports System.Data.SqlClient
Imports System.DirectoryServices

Public Class clsUser

    'attributes


    'methods
    'usrValidateLocal   : valida usuario / sector de forma local contra la DB                               ok
    'usrValidateAD      : valida el usuario contra active directory                                         pending
    'usrValidateGrants  : valida area / sector (y en futuro procesos) de forma local contra la DB           ok

    Public Function usrValidateLocal() As Boolean
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Dim cmdtext As String = ""
        Dim value As Integer = 0
        Try
            Cmd.CommandType = CommandType.Text
            cmdtext = "select COUNT(*) from [dbo].[usuarios] where [usuario_id] = '" & sUsuario & "' and [usuario_pwd] = '" & sPassword & "'"
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

    Public Function usrValidateGrants() As Boolean
        Dim Conn As New SqlConnection(gsConnectionString)
        Dim Cmd As New SqlCommand
        Dim cmdtext As String = ""
        Dim value As Integer = 0
        Try
            Cmd.CommandType = CommandType.Text
            cmdtext = "select COUNT(*) from [dbo].[mvw_SECURITY] where [PERMISOS_USUARIO_ID] = '" & sUsuario & "' and [PERMISOS_SECTOR_ID] = " & sSector & " and [PERMISOS_AREA_ID] = " & sArea
            Cmd.CommandText = cmdtext
            Cmd.Connection = Conn
            Conn.Open()
            value = Cmd.ExecuteScalar()
            If value >= 1 Then
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

    'Public Function usrLoadGrants() As SByte()
    '    Dim Conn As New SqlConnection(gsConnectionString)
    '    Dim Cmd As New SqlCommand
    '    Dim cmdtext As String = ""
    '    Dim drSecurity As SqlDataReader
    '    Try
    '        Cmd.CommandType = CommandType.Text
    '        cmdtext = "select PERMISOS_SECTOR_ID, PERMISOS_AREA_ID, PERMISOS_MODULO_ID, PERMISOS_PROCESO_ID from [dbo].[mvw_SECURITY] where [PERMISOS_USUARIO_ID] = '" & sUsuario & "'"
    '        Cmd.CommandText = cmdtext
    '        Cmd.Connection = Conn
    '        drSecurity.Read()
    '        Conn.Open()




    '    Catch ex As Exception

    '    End Try
    'End Function

    ''PARA DESARROLLAR ---> VALIDAR EL USUARIO CONTRA ACTIVE DIRECTORY
    ''DEBE AUTENTICARSE PRIMERO, LUEGO VERIFICAR AREAS AUTORIZADAS

    'Private strLDAPRuta As String
    'Public [Error] As String

    ''validar contra AD
    'Sub New(ByVal strRuta As String)
    '    Me.strLDAPRuta = strRuta
    'End Sub

    'Public Function EstaAutentificado(ByVal strDominio As String, ByVal strUsuario As String, ByVal strContrasena As String) As Boolean
    '    Dim blnExito As Boolean = False
    '    Dim strDominioUsuario As String = strDominio & "\" & strUsuario
    '    Dim deEntrada As DirectoryEntry = New DirectoryEntry(z, strDominioUsuario, strContrasena)
    '    Try
    '        Dim objObjecto As Object = deEntrada.NativeObject
    '        Dim dsBuscador As New DirectorySearcher(deEntrada)
    '        dsBuscador.Filter = "(SAMAccountName=" & strUsuario & ")"
    '        Dim srResultado As SearchResult = dsBuscador.FindOne()
    '        If Not srResultado Is Nothing Then
    '            blnExito = True
    '        Else
    '            blnExito = False
    '        End If
    '        dsBuscador.Dispose()
    '    Catch ex As Exception
    '        Me.Error = ex.Message()
    '    Finally
    '        deEntrada.Dispose()
    '    End Try
    '    Return blnExito
    'End Function


End Class
