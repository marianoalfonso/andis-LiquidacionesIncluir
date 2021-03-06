Public Class mcls_tvws

    Public Sub MarcarNodosPadre(ByVal Nodo As TreeNode)
        Try
            While (Nodo.Parent IsNot Nothing)   'si existe un nodo padre
                Nodo = Nodo.Parent              'establece nodo padre como el activo 
                Nodo.Checked = vbTrue           'chequea el nodo padre
            End While
        Catch ex As Exception

        End Try
    End Sub

    'desmarca los nodos hijos cuando se desmarca el nodo superior
    Public Sub DesmarcarSubNodos(ByVal colCollection As TreeNodeCollection)     'recibe como parametro los nodos hijo del nodo seleccionado
        Try
            For Each sNode As TreeNode In colCollection         'para cada nodo
                sNode.Checked = vbFalse                         'sacamos el check
                If sNode.Nodes.Count > 0 Then                   'si existen nodos hijo
                    DesmarcarSubNodos(sNode.Nodes)              'funcion recursiva
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Function PrintNode(ByVal n As TreeNode) As String
        Try
            If n.Checked Then
                ReDim Preserve valor(iteration)
                'MessageBox.Show(n.Name)
                valor(iteration) = n.Name
                iteration = iteration + 1
            End If
            Dim aNode As TreeNode
            For Each aNode In n.Nodes
                PrintNode(aNode)
            Next
        Catch ex As Exception

        End Try
    End Function

    'makes a security verification
    Public Function check_security(modulos As Array, permiso As String) As Boolean
        Try
            If Array.IndexOf(modulos, permiso) <> -1 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
        End Try
    End Function


End Class
