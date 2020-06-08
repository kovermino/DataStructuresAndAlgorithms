Public Class LinkedList
    Protected header As Node

    Public Sub New()
        header = New Node("header")
    End Sub

    Public Function getFirst() As Node
        Return header
    End Function

    Private Function Find(ByVal item As Object) As Node
        Dim current As Node = header
        While (current.Element <> item)
            current = current.Blink
        End While
        Return current
    End Function

    Public Sub Insert(ByVal newItem As Object, ByVal after As Object)
        Dim current As Node = Find(after)
        Dim newNode As New Node(newItem)
        newNode.Flink = current.Flink
        newNode.Blink = current
        current.Flink = newNode
    End Sub
    Public Sub Remove(ByVal x As Object)
        Dim p As Node = Find(x)
        If (Not (p.Flink Is Nothing)) Then
            p.Blink.Flink = p.Flink
            p.Flink.Blink = p.Blink
            p.Flink = Nothing
            p.Blink = Nothing
        End If
    End Sub
    Public Sub PrintList()
        Dim current As Node = header
        While (current.Flink IsNot Nothing)
            Console.WriteLine(current.Flink.Element)
            current = current.Flink
        End While
    End Sub

    Public Sub PrintReverse()
        Dim current As Node = FindLast()
        While (current.Blink IsNot Nothing)
            Console.WriteLine(current.Element)
            current = current.Blink
        End While
    End Sub

    Private Function FindLast() As Node
        Dim current As Node = header
        While (current.Flink IsNot Nothing)
            current = current.Flink
        End While
        Return current
    End Function



End Class
