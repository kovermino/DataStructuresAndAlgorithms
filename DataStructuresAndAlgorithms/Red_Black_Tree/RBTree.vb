Public Class RBTree
    Const RED As Integer = 0
    Const BLACK As Integer = 1

    Private current As RBNode
    Private parent As RBNode
    Private grandParent As RBNode
    Private greatParent As RBNode
    Private header As RBNode
    Private nullNode As RBNode

    Public Sub New(ByVal element As String)
        current = New RBNode("")
        parent = New RBNode("")
        grandParent = New RBNode("")
        greatParent = New RBNode("")
        nullNode = New RBNode("")
        nullNode.left = nullNode
        nullNode.right = nullNode
        header = New RBNode(element)
        header.left = nullNode
        header.right = nullNode
    End Sub

    Public Sub Insert(ByVal item As String)
        grandParent = header
        parent = grandParent
        current = parent
        nullNode.element = item

        While (current.element.CompareTo(item) <> 0)
            Dim greatParent As RBNode = grandParent
            grandParent = parent
            parent = current

            If (item.CompareTo(current.element) < 0) Then
                current = current.left
            Else
                current = current.right
            End If

            If (current.left.color = RED And current.right.color = RED) Then
                HandleReorient(item)
            End If
        End While

        If (Not current Is nullNode) Then
            Return
        End If

        current = New RBNode(item, nullNode, nullNode)

        If (item.CompareTo(parent.element) < 0) Then
            parent.left = current
        Else
            parent.right = current
        End If
        HandleReorient(item)
    End Sub

    Public Sub HandleReorient(item As String)
        current.color = RED
        current.left.color = BLACK
        current.right.color = BLACK

        If (parent.color = RED) Then
            grandParent.color = RED
            If ((item.CompareTo(grandParent.element) < 0) <> (item.CompareTo(parent.element))) Then
                current = rotate(item, grandParent)
                current.color = BLACK
            End If
            header.right.color = BLACK
        End If
    End Sub

    Private Function rotate(ByVal item As String, ByVal parent As RBNode) As RBNode
        If (item.CompareTo(parent.left.element) < 0) Then
            parent.left = rotateWithLeftChild(parent.left)
        Else
            parent.left = rotateWithRightChild(parent.left)
        End If
        Return parent.right
    End Function

    Private Function rotateWithLeftChild(ByVal k2 As RBNode) As RBNode
        Dim k1 As RBNode = k2.left
        k2.left = k1.left
        k1.right = k2
        Return k1
    End Function

    Private Function rotateWithRightChild(ByVal k1 As RBNode) As RBNode
        Dim k2 As RBNode = k1.right
        k1.right = k2.left
        k2.left = k1
        Return k2
    End Function

    Public Function FindMin() As String
        If (Me.IsEmpty()) Then
            Return Nothing
        End If
        Dim itrNode As RBNode = header.right
        While (itrNode.left IsNot nullNode)
            itrNode = itrNode.left
        End While
        Return itrNode.element
    End Function

    Public Function FindMax() As String
        If (Me.IsEmpty()) Then
            Return Nothing
        End If

        Dim itrNode As RBNode = header.right
        While (itrNode.right IsNot nullNode)
            itrNode = itrNode.right
        End While
        Return itrNode.element
    End Function

    Public Function Find(ByVal e As String) As String
        nullNode.element = e
        Dim current As RBNode = header.right
        While (True)
            If (e.CompareTo(current.element) < 0) Then
                current = current.left
            ElseIf (e.CompareTo(current.element) > 0) Then
                current = current.right
            ElseIf (current IsNot nullNode) Then
                Return current.element
            Else
                Return Nothing
            End If
        End While
        Return Nothing
    End Function

    Public Function IsEmpty() As Boolean
        Return header.right Is nullNode
    End Function

    Public Sub MakeEmpty()
        header.right = nullNode
    End Sub

    Public Sub PrintRBTree()
        If (Me.IsEmpty()) Then
            Console.WriteLine("Empty")
        Else
            printRB(header.right)
        End If
    End Sub

    Private Sub printRB(ByVal n As RBNode)
        If (n IsNot nullNode) Then
            printRB(n.left)
            Console.WriteLine(n.element)
            printRB(n.right)
        End If
    End Sub
End Class
