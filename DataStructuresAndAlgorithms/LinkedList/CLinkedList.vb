Public Class CLinkedList
    Protected current As ListNode
    Protected header As ListNode
    Private count As Integer = 0

    Public Sub New()
        header = New ListNode("header")
        header.Link = header
    End Sub

    Public Function IsEmpty() As Boolean
        Return (header.Link Is Nothing)
    End Function

    Public Sub MakeEmpty()
        header.Link = Nothing
    End Sub

    Public Sub PrintList()
        Dim current As ListNode = header
        While (current.Link.Element <> "header")
            Console.WriteLine(current.Link.Element)
            current = current.Link
        End While
    End Sub

    Private Function FindPrevious(ByVal x As Object) As ListNode
        Dim current As ListNode = header
        While (current.Link IsNot Nothing) And (current.Link.Element <> x)
            current = current.Link
        End While
        Return current
    End Function

    Private Function Find(ByVal x As Object)
        Dim current As ListNode = header
        While (current.Link IsNot Nothing) And (current.Link.Element <> x)
            current = current.Link
        End While
        Return current
    End Function

    Public Sub Remove(ByVal x As Object)
        Dim p As ListNode = FindPrevious(x)
        If (p.Link IsNot Nothing) Then
            p.Link = p.Link.Link
        End If
        count -= 1
    End Sub

    Public Sub Insert(ByVal x As Object, ByVal y As Object)
        Dim current As ListNode = Find(y)
        Dim newNode As New ListNode
        newNode.Link = current.Link
        current.Link = newNode
        count += 1
    End Sub

    Public Sub InsertFirst(ByVal x As Object)
        Dim current As New ListNode(x)
        current.Link = header.Link
        header.Link = current
        count += 1
    End Sub

    Public Function Move(ByVal n As Integer) As ListNode
        Static current As ListNode = header.Link
        For x As Integer = 1 To n
            current = current.Link
        Next
        If (current.Element = "header") Then
            current = current.Link
        End If
        Dim temp As ListNode = current
        Return temp
    End Function

    Public ReadOnly Property NumNodes() As Integer
        Get
            Return count
        End Get
    End Property
End Class
