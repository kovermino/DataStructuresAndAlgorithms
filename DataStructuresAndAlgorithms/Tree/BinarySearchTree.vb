Public Class BinarySearchTree

    Public root As TreeNode

    Public Sub New()
        root = Nothing
    End Sub

    Public Sub Insert(ByVal i As Integer)
        Dim newNode As New TreeNode()
        newNode.iData = i

        If (root Is Nothing) Then
            root = newNode
        Else
            Dim current As TreeNode = root
            Dim parent As TreeNode
            While (True)
                parent = current
                If (i < current.iData) Then
                    current = current.Left
                    If (current Is Nothing) Then
                        parent.Left = newNode
                        Exit While
                    End If
                Else
                    current = current.Right
                    If (current Is Nothing) Then
                        parent.Right = newNode
                        Exit While
                    End If
                End If
            End While
        End If
    End Sub

    Public Sub InOrder(ByVal theRoot As TreeNode)
        If (theRoot IsNot Nothing) Then
            InOrder(theRoot.Left)
            theRoot.DisplayNode()
            InOrder(theRoot.Right)
        End If
    End Sub

    Public Sub PreOrder(ByVal theRoot As TreeNode)
        If (theRoot IsNot Nothing) Then
            theRoot.DisplayNode()
            PreOrder(theRoot.Left)
            PreOrder(theRoot.Right)
        End If
    End Sub

    Public Sub PostOrder(ByVal theRoot As TreeNode)
        If (theRoot IsNot Nothing) Then
            PostOrder(theRoot.Left)
            PostOrder(theRoot.Right)
            theRoot.DisplayNode()
        End If
    End Sub

    Public Function FindMin() As Integer
        Dim current As TreeNode = root
        While (current.Left IsNot Nothing)
            current = current.Left
        End While
        Return current.iData
    End Function

    Public Function FindMax() As Integer
        Dim current As TreeNode = root
        While (current.Right IsNot Nothing)
            current = current.Right
        End While
        Return current.iData
    End Function

    Public Function Find(ByVal key As Integer) As TreeNode
        Dim current As TreeNode = root
        While (current IsNot Nothing)
            If (key > current.iData) Then
                current = current.Right
            ElseIf (key < current.idata) Then
                current = current.Left
            Else
                Return current
            End If
        End While
        Return Nothing
    End Function

    Public Function Delete(ByVal key As Integer) As Boolean
        Dim current As TreeNode = root
        Dim parent As TreeNode = root
        Dim isLeftChild As Boolean = True

        While (current.iData <> key)
            parent = current
            If (key < current.iData) Then
                isLeftChild = True
                current = current.Left
            Else
                isLeftChild = False
                current = current.Right
            End If

            If (current Is Nothing) Then
                Return False
            End If
        End While

        ' 데이터를 찾았는데, leaf node인 경우
        If (current.Left Is Nothing) And (current.Right Is Nothing) Then
            If (current Is root) Then
                root = Nothing
            ElseIf (isLeftChild) Then
                parent.Left = Nothing
            Else
                parent.Right = Nothing
            End If
        ElseIf (current.Right Is Nothing) Then
            If (current Is root) Then
                root = current.Left
            ElseIf (isLeftChild) Then
                parent.Left = current.Left
            Else
                parent.Right = current.Left
            End If
        ElseIf (current.Left Is Nothing) Then
            If (current Is root) Then
                root = current.Right
            ElseIf (isLeftChild) Then
                parent.Left = current.Right
            Else
                parent.Right = current.Right
            End If
        Else
            Dim successor As TreeNode = getSuccessor(current)
            If (current Is root) Then
                root = successor
            ElseIf (isLeftChild) Then
                parent.Left = successor
            Else
                parent.Right = successor
            End If
            successor.Left = current.Left
        End If
        Return True
    End Function

    Public Function getSuccessor(ByVal delNode As TreeNode) As TreeNode
        Dim successorParent As TreeNode = delNode
        Dim successor As TreeNode = delNode
        Dim current As TreeNode = delNode.Right

        While (current IsNot Nothing)
            successorParent = successor
            successor = current
            current = current.Left
        End While

        If (successor IsNot delNode.Right) Then
            successorParent.Left = successor.Right
            successor.Right = delNode.Right
        End If
        Return successor
    End Function

End Class
