'FormatearBeneficio: FORMATEA Y DEVUELVE EL NUMERO DE BENEFICIO SIN EL TIPO Y LA CAJA, NI EL DIGITO VERIFICADOR
'ValidarNombreArchivo: VALIDA EL FORMATO DEL ARCHIVO DE FACTURACION Y SU CONTENIDO

Imports System
Imports System.IO


Module Validaciones

    'FORMATEA Y DEVUELVE EL NUMERO DE BENEFICIO SIN EL TIPO Y LA CAJA, NI EL DIGITO VERIFICADOR
    Public Function FormatearBeneficio(ByVal nBeneficio As Long) As String
        'ASUMIMOS QUE NO INGRESA UN VALOR NULO YA QUE SE FORMATEA SOLO SI ES PREVIAMENTE VALIDADO
        'ASUMIMOS QUE EL VALOR ES NUMERICO YA QUE SE FORMATEA SOLO SI ES PREVIAMENTE VALIDADO
        'TAMBIEN SE TIENE EN CUENTA QUE LA APLICACION CLIENTE YA VALIDA LA CARGA PARA QUE NO SEA NULO Y SEA NUMERICO
        Try
            'ELIMINAMOS POSIBLES 0 A LA IZQUIERDA DEL BENEFICIO
            Dim sBeneficio As String = Trim(Str(nBeneficio))
            Dim sSubCadena As String = Trim(Left(sBeneficio, 3))
            Dim sParentesco As String
            'ANALIZAR POSIBLES VARIANTES EN BASE AL PADRON PAMI
            If sSubCadena = "405" Or sSubCadena = "403" Then
                sBeneficio = Trim(Right(sBeneficio, Len(sBeneficio) - 3))
            End If
            'SWICHEAMOS ENTRE VARIABLES NUMERICAS Y DE TEXTO PARA DESCARTAR 0 A LA IZQUIERDA SI LOS HUBIESE
            nBeneficio = Val(sBeneficio)
            sBeneficio = Str(nBeneficio)
            'VALIDAR RANGO DE PARENTESCOS PARA CALCULAR LAS POSIBLES OCURRENCIAS EN LOS ARCHIVOS
            'Y ASI PODER ELIMINAR EL DIGITO VERIFICADOR CONOCIENDO SU POSICION EN BASE AL PARENTESCO
            sParentesco = Trim(Right(sBeneficio, 2))
            sBeneficio = Trim(Left(sBeneficio, Len(sBeneficio) - 3))
            FormatearBeneficio = sBeneficio + sParentesco
        Catch ex As Exception
            MsgBox("Error formateando el numero de beneficio.", vbCritical)
        End Try
    End Function

    'VALIDA EL FORMATO DEL ARCHIVO DE FACTURACION A IMPORTAR
    'PARAMETROS: sArchivo (nombre del archivo)
    '            sPath (ruta del archivo)
    Public Function ValidarArchivo(ByVal sArchivo As String, ByVal sPath As String) As Boolean
        Try
            sArchivo = Trim(sArchivo)
            sPath = Trim(sPath) + "\" + sArchivo
            If sArchivo <> "" Then
                If Mid(sArchivo, 1, 2) = "CD" Or Mid(sArchivo, 1, 2) = "CH" Or Mid(sArchivo, 1, 2) = "CG" Then
                    If IsNumeric(Mid(sArchivo, 3, 6)) Then
                        If Mid(sArchivo, 9, 1) = "-" Then
                            If IsNumeric(Mid(sArchivo, 10, 10)) Then
                                If Mid(sArchivo, 21, 1) = "-" Then
                                    If IsNumeric(Mid(sArchivo, 22, 4)) Then
                                        If Mid(sArchivo, 26, 1) = "-" Then
                                            If IsNumeric(Mid(sArchivo, 27, 8)) Then
                                                If Mid(sArchivo, 35, 1) = "." Then
                                                    If Mid(sArchivo, 36, 3) = "txt" Then
                                                        'VALIDAR CONTENIDO DEL ARCHIVO
                                                        Dim StringArrayOfTextLines() As String = File.ReadAllLines(sPath)
                                                        Dim bContador As Integer
                                                        bContador = 7
                                                        If StringArrayOfTextLines(bContador) = "[DETAIL]" Then
                                                            bContador += 6
                                                            While StringArrayOfTextLines(bContador) = "endline"
                                                                bContador += 6
                                                                If bContador = UBound(StringArrayOfTextLines) Then
                                                                    If Left(StringArrayOfTextLines(bContador), 8) = "CheckSum" Then
                                                                        Return True
                                                                    Else
                                                                        Return False
                                                                    End If
                                                                End If
                                                            End While
                                                        Else
                                                            'NO ENCONTRO [HEADER] EN LINEA 7
                                                            Return False
                                                        End If
                                                    End If
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            Return False
        Catch ex As Exception
            Return False
            MsgBox("Error en el formato del archivo de facturacion a importar: " + sArchivo, vbCritical)
        End Try
    End Function










End Module
