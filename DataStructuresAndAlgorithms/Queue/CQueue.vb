Public Class CQueue

    Private prear As Integer = 0
    Private pqueue As New ArrayList()

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub Enqueue(ByVal item As Object)
        pqueue.Add(item)
    End Sub

    Public Sub Dequeue()
        pqueue.RemoveAt(0)
    End Sub

    Public Function Peek() As Object
        Return pqueue.Item(0)
    End Function

    Public Sub ClearQueue()
        pqueue.Clear()
    End Sub

    Public Function Count() As Integer
        Return pqueue.Count()
    End Function

End Class
