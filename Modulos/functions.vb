Module functions


    Sub Cargar_Variables_Globales()
        'Dim configuracion As New clsConfiguration(pathConfig)
        Dim configuracion As New mcls_config(pathConfig)
        Try
            gsMontoElevacion = configuracion.SearchValue("CONFIGURACION_GENERAL", "MONTO_ELEVACION")
            urlReport = configuracion.SearchValue("REPORTING", "URL")
            urlReport_PV = configuracion.SearchValue("REPORTING", "URL_PV")
        Catch ex As Exception
            MsgBox("error en Cargar_Variables_Globales()", vbCritical)
        Finally
            configuracion = Nothing
        End Try
    End Sub

    Function load_conectionString() As Boolean
        'Dim configuracion As New clsConfiguration(pathConfig)
        Dim configuracion As New mcls_config(pathConfig)
        Try
            scope = configuracion.SearchValue("AUTHENTICATION", "SCOPE")
            Dim dataSource As String = configuracion.SearchValue("DATABASE_CREDENTIALS", "DATA_SOURCE")
            Dim initialCatalog As String = configuracion.SearchValue("DATABASE_CREDENTIALS", "INITIAL_CATALOG")
            Dim userId As String = configuracion.SearchValue("DATABASE_CREDENTIALS", "USER_ID")
            Dim password As String = configuracion.SearchValue("DATABASE_CREDENTIALS", "PASSWORD")
            Dim connectionTimeout As String = configuracion.SearchValue("DATABASE_CREDENTIALS", "CONNECTION_TIMEOUT")
            gsConnectionString = "Data Source=" & dataSource & ";Initial Catalog=" & initialCatalog & ";User ID=" & userId & ";Password=" & password & ";Connection Timeout=" & connectionTimeout
            'MessageBox.Show(gsConnectionString)
            Return True
        Catch ex As Exception
            MsgBox("error generando la cadena de conexion . . .", vbCritical)
            Return False
        Finally
            configuracion = Nothing
        End Try
    End Function


End Module
