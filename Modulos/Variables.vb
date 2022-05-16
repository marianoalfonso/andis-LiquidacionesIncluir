Module Variables

    Public gsSector As String
    Public gsArea As String
    Public gsAreaAbreviada As Char
    Public gsPath As String
    Public gsSistema As String
    Public gsConnectionString As String
    Public gsStatus As Boolean
    Public gsError As Integer = 0

    'variables de reportes
    Public urlReport As String
    Public urlReport_PV As String
    Public gsMontoLimiteReporte As Double

    'variables temporales
    Public sPeriodoConsolidacion1 As String
    Public sPeriodoConsolidacion2 As String
    Public sPeriodoConsolidacion3 As String
    Public sPeriodoConsolidacion4 As String

    Public gsMontoElevacion As Double
    Public gsUsuarioLogueado As String

    '2020
    'variable for active user
    Public gsUsuario As String = "null"
    Public gsModulo As String = "null"
    Public gsMensaje As String = "null"
    Public gsCodigoError As Integer = 0
    Public gsDescripcionError As String = "null"

    'variable para log
    Public gsFormulario As String = ""
    'Public sModulo As SByte = 0
    Public sProceso As SByte = 0

    'variables for security
    Public sUsuario As String = ""
    Public sPassword As String = ""
    'Public sSector As String = ""
    Public sSector As SByte = 0
    'Public sArea As String = ""
    Public sArea As Int16 = 0
    Public sModulo As SByte = 0
    Public iSeguridad() As SByte

    'configuration file route
    Public pathConfig As String = Application.StartupPath & "\configuracion_local.txt"

    Public sPeriodo As String = ""     'mes + año consolidado

    'security array config
    Public valor() As String    'array to load security
    Public iteration As Int16 = 0

    'parameters config
    Public g_monto_elevacion As Double = 0
    Public g_dias_eliminacion_liquidacion As Int16 = 0

    'authentication scope
    Public scope As String = "local"

End Module
