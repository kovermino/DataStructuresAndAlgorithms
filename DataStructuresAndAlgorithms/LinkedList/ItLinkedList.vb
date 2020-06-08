Public Class ItLinkedList

    Protected header As Node

    Public Sub New()
        header = New Node("Header")
    End Sub

    Public Function IsEmpty() As Boolean
        Return (header.Blink Is Nothing)
    End Function

    Public Function GetFirst() As Node
        Return header
    End Function

    Public Sub ShowList()
        Dim current As Node = header.Blink
        While (current IsNot Nothing)
            Console.WriteLine(current.Element)
            current = current.Blink
        End While
    End Sub

End Class
