Public Structure pqItem
    Dim priority As Integer
    Dim name As String
End Structure

Public Class PQueue
    Inherits Queue

    Public Sub New()
        MyBase.New()
    End Sub

    Public Overrides Function Dequeue() As Object
        Dim items() As Object = Me.ToArray()
        Dim minPriority As Integer = CType(items(0), pqItem).priority
        Dim position As Integer
        For x As Integer = 1 To items.GetUpperBound(0)
            If (CType(items(x), pqItem).priority < minPriority) Then
                minPriority = CType(items(x), pqItem).priority
                position = x
            End If
        Next

        Me.Clear()

        For x = 0 To items.GetUpperBound(0)
            If (x <> position) And (CType(items(x), pqItem).name <> "") Then
                Me.Enqueue(items(x))
            End If
        Next
        Return items(position)
    End Function

End Class
