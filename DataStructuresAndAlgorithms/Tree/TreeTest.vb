Module TreeTest

    Public Sub InOrderTest()
        Dim nums As New BinarySearchTree()
        nums.Insert(23)
        nums.Insert(45)
        nums.Insert(16)
        nums.Insert(37)
        nums.Insert(3)
        nums.Insert(99)
        nums.Insert(22)
        Console.WriteLine("Inorder traversal: ")
        nums.InOrder(nums.root)
    End Sub
    Public Sub PreOrderTest()
        Dim nums As New BinarySearchTree()
        nums.Insert(23)
        nums.Insert(45)
        nums.Insert(16)
        nums.Insert(37)
        nums.Insert(3)
        nums.Insert(99)
        nums.Insert(22)
        Console.WriteLine("Preorder traversal: ")
        nums.PreOrder(nums.root)
    End Sub

    Public Sub PostOrderTest()
        Dim nums As New BinarySearchTree()
        nums.Insert(23)
        nums.Insert(45)
        nums.Insert(16)
        nums.Insert(37)
        nums.Insert(3)
        nums.Insert(99)
        nums.Insert(22)
        Console.WriteLine("Postorder traversal: ")
        nums.PostOrder(nums.root)
    End Sub

End Module
