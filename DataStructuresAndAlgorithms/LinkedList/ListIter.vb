Public Class ListIter
    Private current As Node
    Private previous As Node
    Private theList As ItLinkedList

    Public Sub New(list As ItLinkedList)
        theList = list
        current = theList.getFirst()
        previous = Nothing
    End Sub

    Public Sub NextLink()
        previous = current
        current = current.Blink
    End Sub

    Public Function GetCurrent() As Node
        Return current
    End Function

    Public Sub InsertBefore(theElement As Object)
        Dim newNode As New Node(theElement)
        If (current.Flink Is Nothing) Then
            Throw New Exception("Can't insert before header")
        Else
            previous.Blink = newNode
            newNode.Flink = previous
            newNode.Blink = current
            current.Flink = newNode
        End If
    End Sub

    Public Sub InsertAfter(theElement As Object)
        Dim newNode As New Node(theElement)
        If (current.Blink IsNot Nothing) Then
            current.Blink.Flink = newNode
        End If
        newNode.Blink = current.Blink
        newNode.Flink = current
        current.Blink = newNode
        NextLink()
    End Sub

    Public Sub Remove()
        previous.Blink = current.Blink
    End Sub

    Public Sub Reset()
        current = theList.getFirst()
        previous = Nothing
    End Sub

    Public Function AtEnd() As Boolean
        Return (current.Blink Is Nothing)
    End Function

End Class
