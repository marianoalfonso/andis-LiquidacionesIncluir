'ImportarArchivo: RECIBE UNA REFERENCIA A UN ARCHIVO DE TEXTO Y LO DEVUELVE EN UN ARRAY
Imports System.Data.SqlClient
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Security
Imports System.Security.Permissions
Imports Microsoft.Reporting.WinForms
Imports System.Configuration

Module Funciones

    'ESTRUCTURA DONDE SE ALMACENARA EL REGISTRO LEIDO DEL TXT
    Public Structure Registro
        Dim Cuit As String
        Dim RazonSocial As String
        Dim Periodo As String
        Dim Sucursal As String
        Dim Factura As String
        Dim Renglon As Integer
        Dim BeneficioPami As String
        Dim Beneficio As String
        Dim Nombre As String
        Dim Prestacion As String
        Dim Descripcion As String
        Dim Importe As String
    End Structure

    'devuelve un valor de la tabla liq_PARAMETROS
    Public Function parameterGet(ByVal idParametro As Int16) As String
        Dim conn As New SqlConnection(gsConnectionString)
        Dim cmd As New SqlCommand
        Dim resultParameter As String
        Try
            cmd.CommandType = CommandType.Text
            cmd.CommandText = "select par_valor from mtb_parametros where par_id = " & idParametro
            cmd.Connection = conn
            conn.Open()
            resultParameter = Trim(cmd.ExecuteScalar())
            Return resultParameter
        Catch ex As Exception
            Return 0
        Finally
            conn.Close()
            conn.Dispose()
        End Try
    End Function

    Public Function ConfigGet(ByVal sArchivo As String, ByVal strSection As String, ByVal strItem As String) As String
        'FUNCION: ConfigGet
        'FECHA DE CREACION: 27 de febrero de 2007
        'ULTIMA MODIFICACION: 26 de julio de 2012 (migracion a vb.NET 2008)
        'AUTOR: Mariano Alfonso (NetworkIt)
        'DESCRIPCION: Dado un encabezado de grupo y un valor, devuelve el
        '             resultado obtenido de un archivo externo de configuracion
        '             parametrizable.
        'PARAMETROS: strSelection --> Cabecera de grupo (String)
        '            strItem      --> Item a buscar (String)
        'DEVOLUCION: (String)
        Try
            'Dim intFile As Integer
            Dim sAux As String
            Dim bytFound As Byte

            Dim sPath As String
            '        sPath = Trim(sArchivo) + ".txt"
            sPath = Trim(sArchivo)
            Dim sFile As New IO.StreamReader(sPath)
            Do While Not sFile.EndOfStream
                sAux = Trim(sFile.ReadLine)
                bytFound = InStr(sAux, strSection)
                If bytFound > 0 Then
                    Exit Do
                End If
            Loop
            If bytFound > 0 Then    'Si encontro la cadena
                bytFound = 0

                Do While Not sFile.EndOfStream
                    sAux = Trim(sFile.ReadLine)
                    bytFound = InStr(sAux, strItem)  'InStr Busca strItem en el archivo
                    If bytFound > 0 Then
                        ConfigGet = Mid(sAux, InStr(sAux, "=") + 1) 'Extrae el resultado
                        Exit Do
                    End If
                Loop
            End If
        Catch ex As Exception
            Err.Clear()
        End Try
    End Function


    Public Function ImportarArchivo2(sArchivo As String) As Array
        Dim sRazonSocial As String
        Dim sCuit As String
        Dim sPeriodo As String
        Dim sSucursal As String
        Dim sFactura As String
        Dim sRenglon As Integer
        Dim sImporte As String
        Dim sRegistro(0) As Registro
        Dim sLinea As String
        Dim iContador, iAux As Integer
        Dim rValor1, rValor2 As Double
        Dim iLimiteSuperiorArray As Integer

        Try
            iContador = 0
            Dim sPath As String = "c:\ArchivosFacturacion\" + sArchivo
            Dim sContent As String = vbNullString

            'OBTENEMOS LOS DATOS DE CABECERA
            sRazonSocial = ConfigGet("C:\ArchivosFacturacion\" + sArchivo, "HEADER", "PRESTADOR")
            sCuit = ConfigGet("C:\ArchivosFacturacion\" + sArchivo, "HEADER", "CUIT")
            sCuit = Limpiar_Cadena(sCuit, "-")
            sPeriodo = ConfigGet("C:\ArchivosFacturacion\" + sArchivo, "HEADER", "PERIODOFACTURADO")
            sPeriodo = Limpiar_Cadena(sPeriodo, "-")
            sSucursal = ConfigGet("C:\ArchivosFacturacion\" + sArchivo, "HEADER", "NUMEROFACTURA")
            sFactura = ConfigGet("C:\ArchivosFacturacion\" + sArchivo, "HEADER", "NUMEROFACTURA")

            Dim sFile As New IO.StreamReader(sPath)
            sLinea = Trim(sFile.ReadLine)
            While sLinea <> "[BOTTOM]"
                sRenglon = 1

                If sLinea = "[DETAIL]" Or sLinea = "endline" Then   'si es "DETAIL[ o "endline" asume que a continuación hay datos
                    sRegistro(iContador).Beneficio = Trim(sFile.ReadLine)   'leo la siguiente linea
                    If sRegistro(iContador).Beneficio = "[BOTTOM]" Then 'si la linea leida es "BOTTOM" es el final del archivo y salimos del proceso
                        Exit While
                    Else    'si la linea leida NO es "BOTTOM" hay datos de consumo
                        sRegistro(iContador).BeneficioPami = sRegistro(iContador).Beneficio
                        sRegistro(iContador).Beneficio = Limpiar_Beneficio(sRegistro(iContador).Beneficio)
                    End If
                    sRegistro(iContador).RazonSocial = sRazonSocial
                    sRegistro(iContador).Cuit = sCuit
                    sRegistro(iContador).Periodo = sPeriodo
                    sRegistro(iContador).Sucursal = sSucursal
                    sRegistro(iContador).Factura = sFactura
                    sRegistro(iContador).Renglon = sRenglon
                    sRegistro(iContador).Nombre = Trim(sFile.ReadLine)
                    sRegistro(iContador).Prestacion = Trim(sFile.ReadLine)
                    sRegistro(iContador).Descripcion = Trim(sFile.ReadLine)
                    sImporte = Trim(sFile.ReadLine)
                    iLimiteSuperiorArray = UBound(sRegistro)
                    'CHEQUEAMOS EXISTENCIA
                    If iLimiteSuperiorArray > 0 Then
                        iAux = 0
                        Do Until iAux = iLimiteSuperiorArray
                            If sRegistro(iAux).Beneficio = sRegistro(iContador).Beneficio Then
                                If sRegistro(iAux).Prestacion = sRegistro(iContador).Prestacion Then
                                    rValor1 = Val(Replace(sRegistro(iContador).Importe, ",", "."))
                                    rValor2 = Val(Replace(sRegistro(iAux).Importe, ",", "."))
                                    sRegistro(iAux).Importe = (rValor1 + rValor2).ToString
                                    ReDim Preserve sRegistro(UBound(sRegistro) - 1)
                                    iContador -= 1
                                    Exit Do
                                Else
                                    sRegistro(iContador).Importe = sImporte
                                End If
                            Else
                                sRegistro(iContador).Importe = sImporte
                            End If
                            iAux += 1
                        Loop
                    Else
                        sRegistro(iContador).Importe = sImporte
                    End If
                    iContador += 1
                    ReDim Preserve sRegistro(UBound(sRegistro) + 1)
                End If
                sLinea = Trim(sFile.ReadLine)

                If sLinea = "" Then MsgBox(sArchivo)

                Application.DoEvents()


            End While
            ReDim Preserve sRegistro(UBound(sRegistro) - 1)

            sFile.Close()
            sFile.Dispose()
            Return sRegistro
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Critical)
        End Try
    End Function


    'INSERTA EN LA TABLA FACTURACIONES CADA ELEMENTO DEL ARRAY PASADO COMO PARAMETRO
    Public Function GrabarFacturacion(ByVal sArray() As Registro, sArea As Char) As Boolean
        Dim Elementos, iElemento As Integer
        Dim Conn As New SqlConnection("Data Source=mrburns;Initial Catalog=LIQUIDACIONES_PAMI;User ID=usrLiquidacionPami;Password=Cocolandia877")
        'Dim sqlConn As New SqlConnection("Data Source=MARIANO-VAIO;Initial Catalog=LIQUIDACIONES_PAMI;User ID=sa;Password=cerati123")
        Try
            Elementos = sArray.Length - 1
            For iElemento = 0 To Elementos
                Dim Cmd As New SqlCommand
                Cmd.CommandText = "SP_IMPORTAR_FACTURACION"
                Cmd.CommandType = CommandType.StoredProcedure
                Cmd.Connection = Conn
                Cmd.Parameters.AddWithValue("@AREA", Trim(sArea))
                Cmd.Parameters.AddWithValue("@CUIT", Trim(sArray(iElemento).Cuit))
                Cmd.Parameters.AddWithValue("@RAZON_SOCIAL", Trim(sArray(iElemento).RazonSocial))
                Cmd.Parameters.AddWithValue("@PERIODO", Trim(sArray(iElemento).Periodo))
                Cmd.Parameters.AddWithValue("@SUCURSAL", Trim(sArray(iElemento).Sucursal))
                Cmd.Parameters.AddWithValue("@FACTURA", Trim(sArray(iElemento).Factura))
                Cmd.Parameters.AddWithValue("@RENGLON", Trim(sArray(iElemento).Renglon))
                Cmd.Parameters.AddWithValue("@BENEFICIOPAMI", Trim(sArray(iElemento).BeneficioPami))
                Cmd.Parameters.AddWithValue("@BENEFICIO", Trim(sArray(iElemento).Beneficio))
                Cmd.Parameters.AddWithValue("@NOMBRE", Trim(sArray(iElemento).Nombre))
                If Trim(sArray(iElemento).Prestacion) = "Geriatria" Or Trim(sArray(iElemento).Prestacion) = "Hemodialisis" Then
                    sArray(iElemento).Prestacion = "Prestacion"
                End If
                Cmd.Parameters.AddWithValue("@PRESTACION", Trim(sArray(iElemento).Prestacion))
                Cmd.Parameters.AddWithValue("@DESCRIPCION", Trim(sArray(iElemento).Descripcion))
                Cmd.Parameters.AddWithValue("@IMPORTE", Trim(Replace(sArray(iElemento).Importe, ",", ".")))
                Conn.Open()
                Cmd.ExecuteScalar()
                Conn.Close()
            Next iElemento
            Conn = Nothing
            Return True
        Catch ex As Exception
            If Err.Number = 5 Then
                MsgBox("El archivo seleccionado ya fue importado", vbCritical)
                Err.Clear()
                Return False
            End If
        End Try
    End Function

    Public Function Obtener_Cuit(ByVal Archivo As String)
        Obtener_Cuit = Mid(Archivo, 33, 11)
    End Function

    Public Function Obtener_Factura(ByVal Archivo As String)
        Obtener_Factura = Mid(Archivo, 45, 13)
    End Function

    'MUEVE UN ARCHIVO IMPORTADO DE UNA CARPETA A OTRA
    Public Sub Archivo_Importado(ByVal Archivo As String)
        Dim PathOrigen As String = "c:\ArchivosFacturacion\" + Archivo
        Dim PathDestino As String = "c:\ArchivosFacturacion\Archivos Importados\" + Archivo
        Try
            Mover_Archivo(Archivo)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    '  Public Function Mover_Archivo(ByVal Archivo As String, ByVal Validado As Boolean) As Boolean
    ' Dim PathOrigen As String = "c:\ArchivosFacturacion\" + Archivo
    ' Dim PathDestino As String = "c:\ArchivosFacturacion\Archivos Validados\" + Archivo
    '     Try
    '         If Validado Then
    '             My.Computer.FileSystem.MoveFile(PathOrigen, PathDestino, False)
    '             Return True
    '             MsgBox("Archivo movido", MsgBoxStyle.Information, "MOVER ARCHIVO")
    '         Else
    '             Return False
    '         End If
    '     Catch ex As Exception
    '         MsgBox(ex.Message, MsgBoxStyle.Critical)
    '         Return False
    '     End Try
    ' End Function

    Public Function Mover_Archivo(ByVal Archivo As String) As Boolean
        ' Create a StringBuilder used to create the result string 
        Dim resultText As New StringBuilder()
        Dim permFileIO As New FileIOPermission(FileIOPermissionAccess.AllAccess, "c:\ArchivosFacturacion")
        Dim permFileIO_2 As New FileIOPermission(FileIOPermissionAccess.AllAccess, "c:\ArchivosFacturacion\Archivos Importados")
        Dim PathOrigen As String = "c:\ArchivosFacturacion\" + Archivo
        Dim PathDestino As String = "c:\ArchivosFacturacion\Archivos Importados\" + Archivo
        ' Create an FileIOPermission for accessing the C:\Temp folder 

        Try
            ' Demand the permission to access the C:\Temp folder. 
            permFileIO.Demand()
            permFileIO_2.Demand()
            System.IO.File.Move(PathOrigen, PathDestino)
            Return (True)
        Catch se As SecurityException
            MsgBox(Err.Description)
            Return False
        End Try
    End Function

    Public Function Limpiar_Cadena(sTexto As String, sCaracter As Char) As String
        Dim auxPos1 As Integer
        Dim auxString1, auxString2 As String
        Try
            If sTexto <> "" Then
                While InStr(sTexto, sCaracter) > 0
                    auxPos1 = InStr(sTexto, sCaracter)
                    auxString1 = Mid(sTexto, 1, auxPos1 - 1)
                    auxString2 = Mid(sTexto, auxPos1 + 1, Len(sTexto))
                    sTexto = auxString1 + auxString2
                End While
                Return sTexto
            Else
                Return sTexto
            End If
        Catch ex As Exception
            sTexto = ""
            Return sTexto
        End Try
    End Function

    Public Function Limpiar_Beneficio(sBeneficio As String) As String
        Dim lBeneficio As Long
        If sBeneficio <> "" Then
            If Len(sBeneficio) = 14 Then
                sBeneficio = Mid(sBeneficio, 4, 8) + Mid(sBeneficio, 13, 2)
                lBeneficio = Val(sBeneficio)
                sBeneficio = Str(lBeneficio)
            Else
                sBeneficio = ""
                Return sBeneficio
            End If
            Return sBeneficio
        Else
            sBeneficio = ""
            Return sBeneficio
        End If
    End Function

    Public Function Real2Text(ByVal valor As String) As String
        Try
            Dim Componentes() As String = Split(valor, ",")
            Dim Entero As Integer = CInt(Componentes(0))
            Dim Resto As Integer = CInt(Componentes(1))
            Dim EnteroConvertido As String = Num2Text(Entero)
            Dim RestoConvertido As String = Num2Text(Resto)
            Dim Cadena As String = Trim(EnteroConvertido) & " pesos con " & Trim(RestoConvertido) & " centavos"
            Return Cadena
        Catch ex As Exception
            MsgBox("Error convirtiendo numero a descripcion", vbCritical)
            Return ""
        End Try
    End Function

    Public Function Num2Text(ByVal value As Double) As String
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function


    'INICIO FUNCION ALTERNATIVA PASAR NUMERO A LETRAS
    Public Function Cambio(ByVal Valor As Double)
        Dim numero(9), fraccion(2), entero, casillas, i, j As Integer
        Dim CienMillo, deci, decim, Millo, centanamil, Unidec, unidecmil, centena As String
        Dim completo As Double
        Dim ResultadoCambio As String

        entero = Int(Valor)
        completo = CDbl(Valor)
        deci = Format((completo - entero), "#.00")

        'El limite fue rebalsado solo se permiten valores menores a 999,999,999

        casillas = CStr(entero).Length
        j = 0
        For i = casillas - 1 To 0 Step -1
            j = j + 1

            numero(j) = CInt(CStr(entero).Substring(i, 1))
        Next i
        For i = (casillas + 1) To 9
            numero(i) = 0
        Next i
        For i = 1 To 2
            fraccion(i) = CInt(CStr(deci).Substring(i, 1))
        Next i
        Unidec = Conver((numero(1)), (numero(2)))
        centena = ConvCent((numero(3)))
        If centena = "Ciento " And Unidec = "" Then
            centena = "Cien "
        End If
        unidecmil = Conver((numero(4)), (numero(5)))
        If unidecmil <> "" Then
            If unidecmil = "Uno" Then
                unidecmil = "Un mil "
            Else
                If numero(4) = 1 Then

                    unidecmil = unidecmil.Substring(0, unidecmil.Length - 1) & " mil "
                Else
                    unidecmil = unidecmil & " mil "
                End If

            End If
        End If
        centanamil = ConvCent((numero(6)))
        If centanamil = "Ciento " And unidecmil = "" Then
            centanamil = "Cien mil "
        Else
            If centanamil <> "" And unidecmil = "" Then
                centanamil = centanamil & " mil "
            End If
        End If
        Millo = Conver((numero(7)), (numero(8)))
        If Millo <> "" Then
            If Millo = "Uno" Then
                Millo = "Un Millon "
            Else
                If numero(7) = 1 Then
                    Millo = Millo.Substring(0, Millo.Length - 1) & " Milloes "
                Else
                    Millo = Millo & " Millones "
                End If

            End If

        End If
        CienMillo = ConvCent((numero(9)))
        If CienMillo = "Ciento " And Millo = "" Then
            CienMillo = "Cien Millones "
        End If
        If deci <> "0" Then
            decim = Conver((fraccion(2)), (fraccion(1)))
            If decim <> "" Then
                decim = " Con " & decim
            End If
        Else
            decim = ""
        End If
        'Diseñado por Victor Hugo Cardenas
        ResultadoCambio = CienMillo & Millo & centanamil & unidecmil & centena & Unidec & decim
        If ResultadoCambio = "" Then
            ResultadoCambio = "Cero"
        End If


        Return ResultadoCambio
    End Function

    Private Function Conver(ByVal ValorUno As Integer, ByVal ValorDos As Integer) As String
        Dim unidad, decena As String
        Dim grupo1 As Integer
        Dim ResConver As String
        grupo1 = CInt(ValorDos & ValorUno)

        Select Case grupo1
            Case 11
                ResConver = "Once"
            Case 12
                ResConver = "Doce"
            Case 13
                ResConver = "Trece"
            Case 14
                ResConver = "Catorce"
            Case 15
                ResConver = "Quince"
            Case Else
                Select Case ValorUno
                    Case 0
                        unidad = ""
                    Case 1
                        unidad = "Uno"
                    Case 2
                        unidad = "Dos"
                    Case 3
                        unidad = "Tres"
                    Case 4
                        unidad = "Cuatro"
                    Case 5
                        unidad = "Cinco"
                    Case 6
                        unidad = "Seis"
                    Case 7
                        unidad = "Siete"
                    Case 8
                        unidad = "Ocho"
                    Case 9
                        unidad = "Nueve"
                    Case Else
                        unidad = ""
                End Select
                Select Case ValorDos
                    Case 0
                        decena = ""
                    Case 1
                        decena = "Diez"
                    Case 2
                        If ValorUno <> 0 Then
                            decena = "Veinti"
                        Else
                            decena = "Veinte "
                        End If
                    Case 3
                        decena = "Treinta"
                    Case 4
                        decena = "Cuarenta"
                    Case 5
                        decena = "Cincuenta"
                    Case 6
                        decena = "Sesenta"
                    Case 7
                        decena = "Setenta"
                    Case 8
                        decena = "Ochenta"
                    Case 9
                        decena = "Noventa"
                    Case Else
                        decena = ""
                End Select
                If ValorUno = 0 Then
                    ResConver = decena & unidad
                Else
                    If ValorDos = 0 Then
                        ResConver = unidad
                    Else
                        If ValorDos = 2 Then
                            ResConver = decena & unidad
                        Else
                            ResConver = decena & " y " & unidad
                        End If
                    End If
                End If

        End Select
        Return ResConver
    End Function
    Private Function ConvCent(ByVal Valor As Integer) As String
        'Diseñado por Victor Hugo Cardenas
        Dim ResConvCent As String
        Select Case Valor
            Case 0
                ResConvCent = ""
            Case 1
                ResConvCent = "Ciento "
            Case 2
                ResConvCent = "Docientos "
            Case 3
                ResConvCent = "Trecientos "
            Case 4
                ResConvCent = "Cuatrocientos "
            Case 5
                ResConvCent = "Quinientos "
            Case 6
                ResConvCent = "Seis cientos "
            Case 7
                ResConvCent = "Setecientos "
            Case 8
                ResConvCent = "Ochocientos "
            Case 9
                ResConvCent = "Novecientos "
            Case Else
                ResConvCent = ""
        End Select
        Return ResConvCent
    End Function
    'FIN FUNCION ALTERNATIVA PASAR NUMERO A LETRAS


    'RECIBE UN PERIODO EN FORMATO 072012 Y DEVUELVE JULIO DE 2012
    Public Function ConvertirPeriodo(Periodo As String) As String
        Dim sNombreMes As String
        Dim sNombrePeriodo As String
        Try
            Dim sMes As String = Periodo.Substring(0, 2)
            Select Case sMes
                Case "01"
                    sNombreMes = "Enero"
                Case "02"
                    sNombreMes = "Febrero"
                Case "03"
                    sNombreMes = "Marzo"
                Case "04"
                    sNombreMes = "Abril"
                Case "05"
                    sNombreMes = "Mayo"
                Case "06"
                    sNombreMes = "Junio"
                Case "07"
                    sNombreMes = "Julio"
                Case "08"
                    sNombreMes = "Agosto"
                Case "09"
                    sNombreMes = "Septiembre"
                Case "10"
                    sNombreMes = "Octubre"
                Case "11"
                    sNombreMes = "Noviembre"
                Case "12"
                    sNombreMes = "Diciembre"
                Case Else
                    sNombreMes = ""
            End Select
            Dim sAnio As String = Periodo.Substring(2, 4)
            sNombrePeriodo = sNombreMes & " de " & sAnio
            Return sNombrePeriodo
        Catch ex As Exception
            MsgBox("Error convirtiendo periodo a texto.", vbCritical)
            Err.Clear()
            Return "-"
        End Try
    End Function

    Public Function ConvertirModulo(area As Int16, sector As Int16) As String
        Dim sSector As String
        Dim sArea As String
        Try
            Select Case sector
                Case 1
                    sSector = "Incluir Salud"
                Case 2
                    sSector = "Pami"
            End Select

            Select Case area
                Case 1, 4
                    sArea = "Discapacidad"
                Case 2, 5
                    sArea = "Hemodialisis"
                Case 3,6
                    sArea = "Geriatria"
            End Select
            Return sArea & " " & sSector
        Catch ex As Exception
            MsgBox("Error convirtiendo el string de modulo", vbCritical)
            Err.Clear()
            Return "-"
        End Try

    End Function

    'RECIBE UN PERIODO CON EL FORMATO MMYYYY Y LO DEVUELVE MM/YYYY
    Public Function Formatear_Periodo(ByVal sPeriodo As String) As String

        Try
            Return Left(sPeriodo, 2) & "/" & Right(sPeriodo, 4)
        Catch ex As Exception
            Return "00/0000"
        End Try
    End Function

    '20181114
    Function Compensar_Centavos(ByVal iNumeroLiquidacion As Integer, ByVal dTotalFactura As Double, ByVal dFacturaElectronica As Double, ByVal dDebito As Double) As Double
        Dim dTotalAux As Double
        Try
            dTotalAux = dFacturaElectronica + dDebito
            If dTotalAux <> dTotalFactura Then
                dFacturaElectronica = dFacturaElectronica + (dTotalFactura - dTotalAux)
                Return dFacturaElectronica
            Else
                Return dFacturaElectronica
            End If
        Catch ex As Exception
            Return dFacturaElectronica
        End Try
    End Function

    ''20181114
    'Function Totalizar_Liquidacion(ByVal iNum_Liq As Integer) As Double
    '    Dim Conn As New SqlConnection(gsConnectionString)
    '    Dim Cmd As New SqlCommand
    '    Try
    '        If iNum_Liq > 0 Then
    '            Cmd.CommandText = "pa_TOTALIZAR_LIQUIDACION"
    '            Cmd.CommandType = CommandType.StoredProcedure
    '            Cmd.Connection = Conn
    '            Cmd.Parameters.AddWithValue("@p_NUMERO_LIQUIDACION", iNum_Liq)
    '            'Cmd.Parameters.Add("@p_TOTALLIQUIDADO", SqlDbType.Money)
    '            Cmd.Parameters.Add("@p_TOTALLIQUIDADO", SqlDbType.Decimal)
    '            Cmd.Parameters("@p_TOTALLIQUIDADO").Direction = ParameterDirection.Output
    '            Conn.Open()
    '            Cmd.ExecuteScalar()
    '            Dim output_TotalLiquidacion As Double = Cmd.Parameters("@p_TOTALLIQUIDADO").Value
    '            Return output_TotalLiquidacion
    '        Else
    '            Return 0
    '        End If
    '    Catch ex As Exception
    '        MsgBox("Error totalizando la liquidacion", vbCritical)
    '        Return 0
    '    Finally
    '        Conn.Close()
    '        Conn.Dispose()
    '        Cmd.Dispose()
    '    End Try
    'End Function

    'IMPRIME EL REPORTE PASADO COMO PARAMETRO
    Function bImprimir_Reporte(ByVal NumeroLiquidacion As Integer, ByVal RutaReporte As String) As Boolean
        Dim sURL As String
        Dim Parameters(1) As ReportParameter
        Dim clsM As New clsSSRSManager

        Try

            If gsMontoElevacion = 0 Then
                If gsSector = "Pfis" Or gsSector = "PfisDesarrollo" Then
                    Parameters(0) = New ReportParameter("p_NUMLIQ", NumeroLiquidacion)
                    Parameters(1) = New ReportParameter("p_NUMERO_LIQUIDACION", NumeroLiquidacion)
                    clsM.ExportToFile("Liquidaciones/Reporte_Unico_ANDIS", Parameters, RutaReporte, True)
                    'sURL = "http://mrburns/ReportServer/Pages/ReportViewer.aspx?/Liquidaciones/Reporte_unico_ANDIS&rs:Command=Render&p_NUMLIQ=" & iNumLiq & "&p_NUMERO_LIQUIDACION= " & iNumLiq
                ElseIf gsSector = "Pami" Then
                    MsgBox("SE IMPRIME EL REPORTE DE PAMI !!!!!!!!!!!!!!!!!!!!!", vbCritical)
                    'sURL = "http://mrburns/ReportServer/Pages/ReportViewer.aspx?/Liquidaciones_Pami/Reporte_unico_A_pami&rs:Command=Render&p_NUMLIQ=" & iNumLiq & "&p_NUMERO_LIQUIDACION= " & iNumLiq
                End If
            Else
                MsgBox("debe setear el monto de elevación", vbCritical)
                Return False
            End If
            'Shell("C:\Program Files\Internet Explorer\iexplore.exe " & sURL, vbMaximizedFocus)
            Return True
        Catch ex As Exception
            MsgBox("error imprimiendo la liquidacion", vbCritical)
            Return False
        End Try
    End Function

    Sub Registrar_Log(ByVal Modulo As String, ByVal Detalle As String, ByVal Codigo As Integer, ByVal Descripcion As String)

        Dim log As New clsLog
        log.usuario = Environment.UserName
        'log.fecha = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")

        'If IsNothing(Modulo) Then
        '    log.modulo = ""
        'Else
        '    log.modulo = Modulo
        'End If

        'If IsNothing(Detalle) Then
        '    log.detalle = ""
        'Else
        '    log.detalle = Detalle
        'End If

        'If IsNothing(Codigo) Then
        '    log.codigo = 0
        'Else
        '    log.codigo = Codigo
        'End If

        'If IsNothing(Descripcion) Then
        '    log.descripcion = ""
        'Else
        '    log.descripcion = Descripcion
        'End If

        'log.Registrar_Log()
        'log = Nothing

    End Sub

    'calcula la diferencia entre el total facturado electronicamente y el total en la factura papel
    Function calculateDiff(ByVal totalElectronico As Decimal, ByVal totalPapel As Decimal) As Decimal
        Try
            Return totalElectronico - totalPapel
        Catch ex As Exception
            Return Nothing
        End Try
    End Function





End Module