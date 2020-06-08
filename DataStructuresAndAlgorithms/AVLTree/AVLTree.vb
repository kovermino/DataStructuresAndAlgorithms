Public Class AVLTree

    Private Function Insert(ByVal item As Object, ByVal n As ANode) As ANode
        If (n Is Nothing) Then
            n = New ANode(item, Nothing, Nothing)
        ElseIf (item.compareto(n.element) < 0) Then
            n.left = Insert(item, n.left)
            If (n.left.getHeight() - n.right.getHeight() = 2) Then
                If (item.compareto(n.left.element) < 0) Then
                    n = rotateWithLeftChild(n)
                Else
                    n = doubleWithLeftChild(n)
                End If
            End If
        ElseIf (item.compareto(n.element) > 0) Then
            n.right = Insert(item, n.right)
            If (n.left.getHeight() - n.right.getHeight() = 2) Then
                If (item.compareto(n.left.element) > 0) Then
                    n = rotateWithRightChild(n)
                Else
                    n = doubleWithRightChild(n)
                End If
            End If
        Else
            ' do nothing, duplicate value
        End If
        n.height = Math.Max(n.left.getHeight, n.right.getHeight) + 1
        Return n
    End Function

    Private Function rotateWithLeftChild(ByVal n2 As ANode) As ANode
        Dim n1 As ANode = n2.left
        n2.left = n1.right
        n1.right = n2
        n2.height = Math.Max(n2.left.getHeight, n2.right.getHeight) + 1
        n1.height = Math.Max(n1.left.getHeight, n2.getHeight) + 1
        Return n1
    End Function

    Private Function rotateWithRightChild(ByVal n1 As ANode) As ANode
        Dim n2 As ANode = n1.right
        n1.right = n2.left
        n2.left = n1
        n1.height = Math.Max(n1.left.getHeight, n2.right.getHeight) + 1
        n2.height = Math.Max(n2.right.getHeight, n1.getHeight) + 1
        Return n2
    End Function

    Private Function doubleWithLeftChild(ByVal n3 As ANode) As ANode
        n3.left = rotateWithRightChild(n3.left)
        Return rotateWithLeftChild(n3)
    End Function

    Private Function doubleWithRightChild(ByVal n1 As ANode) As ANode
        n1.right = rotateWithLeftChild(n1.right)
        Return rotateWithRightChild(n1)
    End Function

End Class
