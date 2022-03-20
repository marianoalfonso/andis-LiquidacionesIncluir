Imports System.Globalization
Imports System.Data.SqlClient
Imports System.DirectoryServices
Imports System.DirectoryServices.AccountManagement

Public Class Login
    Dim mcls_log As New mcls_log
    Dim mcls_user As New mcls_user

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        'setSecurityEnvironment()

        System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("es-AR")
        System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyDecimalSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.CurrencyGroupSeparator = "."
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator = ","
        System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator = "."

        'Dim configuracion As New clsConfiguration(pathConfig)
        Dim configuracion As New mcls_config(pathConfig)

        'MessageBox.Show(pathConfig)

        setTags()
        Try
            'Me.Tag = "01.05"
            If Not load_conectionString() Then
                MessageBox.Show("error - no pudo generarse la cadena de conexion . . .", "configuracion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            Else
                setDataEnvironment()

                If scope = "ad" Then
                    UsernameTextBox.Text = System.Environment.UserName
                    UsernameTextBox.Enabled = False
                End If

            End If
            'load_areas()
        Catch ex As Exception
            MessageBox.Show("no pudo inicializarse el sistema . . .", "configuracion", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End
        Finally
        End Try
    End Sub


    Private Sub setDataEnvironment()
        Try
            mfn_00001()     'parametros generales
            mfn_00005()     'periodos autorizados
            'mfn_00010()    'prestadores
            load_areas()
        Catch ex As Exception
            MessageBox.Show("error setDataEnvironment()")
        End Try
    End Sub

    Private Sub setTags()
        Me.Tag = "01.05"            'login form
        'Button1.Tag = "010101"      'ingreasar button
    End Sub

    'carga las areas disponibles en el combobox cmbAreas en base al sector seleccionado
    Private Sub load_areas()
        Dim stringConexion As New SqlConnection(gsConnectionString)
        Try
            Dim cmd As New SqlCommand("mpa_01200", stringConexion)
            'Dim param As New SqlParameter("@SECTOR", SqlDbType.TinyInt)
            'param.Value = sSector
            cmd.CommandType = CommandType.StoredProcedure
            'cmd.Parameters.Add(param)
            Dim tabla As New DataTable
            Dim dataAdapter As New SqlDataAdapter(cmd)
            dataAdapter.Fill(tabla)
            cmbAreas.ValueMember = "a_area_id"
            cmbAreas.DisplayMember = "s_area_descripcion"
            cmbAreas.DataSource = tabla
        Catch ex As Exception
            MsgBox(Err.Description, vbCritical)
        Finally
            stringConexion.Dispose()
        End Try
    End Sub

    'seleccionamos y asignamos el indice del commbo cuando cambia
    Private Sub cmbAreas_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbAreas.SelectedIndexChanged
        'sArea = cmbAreas.SelectedValue
        sArea = 1                           'VER PORQUE DA ERROR AL ASIGNAR EL SELECTEDVALUE
    End Sub

    'validamos entrada de datos
    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        'Dim usr As New clsUser
        Dim usrValido As Boolean = False
        Try
            Label2.ForeColor = Color.Green
            Label2.Text = "validando credenciales . . ."
            Application.DoEvents()
            sUsuario = Trim(UsernameTextBox.Text)
            sPassword = Trim(PasswordTextBox.Text)
            mcls_log.usuario = sUsuario
            mcls_log.area = sArea
            mcls_log.proceso = Me.Tag
            If scope = "local" Then
                usrValido = mcls_user.usrValidateLocal(sUsuario, sPassword)         'local authentication
            ElseIf scope = "ad" Then
                usrValido = mcls_user.isAuthenticated(sUsuario, sPassword)
            Else
                MessageBox.Show("error en el archivo de configuracion para el seteo de validación", "configuracion", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End
            End If
            If usrValido Then
                'usr.usrValidateGrants()                'validar usuario / sector
                mfn_00006() 'load user grants
                Cargar_Variables_Globales()
                mcls_log.detalle = "inicio de sesión correcto"
                Me.Hide()
                frmDefault.Show()
            Else
                mcls_log.detalle = "inicio de sesión incorrecto"
                MessageBox.Show("credenciales no válidas . . .", "credenciales", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            mcls_log.log_event_ok()
        Catch ex As Exception
            mcls_log.detalle = "error validando credenciales (Sub OK_Click)"
            mcls_log.error_codigo = Err.Number
            mcls_log.error_descripcion = Err.Description
            mcls_log.log_event_error()
            MessageBox.Show("error de procedimiento validando credenciales", "app error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally

        End Try
    End Sub

    ''chequea usuario contra AD
    'Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    '    If mcls_user.isAuthenticated(UsernameTextBox.Text, PasswordTextBox.Text) Then
    '        MessageBox.Show("usuario existente")
    '    Else
    '        MessageBox.Show("usuario no existente")
    '    End If
    'End Sub



    ''establece la conexion con una de las siguientes bases de datos MRBURNS>LIQUIDACIONES_PFIS o MRBURNS>LIQUIDACIONES_PAMI
    'Sub Establecer_Conexion()
    '    Try
    '        If gsSector = "Pfis" Then
    '            'forces the Named Pipes instead of the default of TCP
    '            gsConnectionString = "Data Source=np:riv-sql03;Initial Catalog=LIQUIDACIONES_PFIS;User ID=usrLiquidacionPfis;Password=usuariopfis;Connection Timeout=0"
    '        ElseIf gsSector = "Pami" Then
    '            gsConnectionString = "Data Source=np:riv-sql03;Initial Catalog=LIQUIDACIONES_PAMI;User ID=usrLiquidacionPami;Password=usuarioliquidacion"
    '        ElseIf gsSector = "laptop" Then
    '            gsConnectionString = "Data Source=BANGHO;Initial Catalog=LIQUIDACIONES_PFIS;User ID=sa;Password=G@rbage123"
    '        ElseIf gsSector = "PfisDesarrollo" Then
    '            gsConnectionString = "Data Source=riv-sqldev01;Initial Catalog=LIQUIDACIONES_PFIS;User ID=usrLiquidacionPfis;Password=usuariopfis"
    '        Else
    '            MsgBox("Error de conexion con la base de datos." & Chr(13) & "No existe SECTOR habilitado", vbCritical)
    '            Application.Exit()
    '        End If

    '    Catch ex As Exception
    '        MsgBox("Error de conexion con la base de datos." & Chr(13) & "Contactese con TECNOLOGIA INFORMATICA", vbCritical)
    '        Application.Exit()
    '    End Try
    'End Sub

    'AD authentication
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
                MessageBox.Show("usuario valido")
                Return True
            End If
            Return False
        Catch ex As Exception
            MessageBox.Show(Err.Description)
            Return False
        End Try
    End Function

    'close the app
    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

End Class