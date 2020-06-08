Module RadixSort

    Enum DigitType
        ones = 1
        tens = 10
    End Enum

    Sub RadixSortTest()
        Dim numbers() As Integer = {91, 46, 82, 15, 92, 35, 31, 22}
        Dim queueArr() As Queue = BuildQueue()

        ShowArray(numbers)

        RadixSort(queueArr, numbers, 1)
        BuildArrayFromQueues(queueArr, numbers)
        Console.WriteLine("First pass: ")
        ShowArray(numbers)

        RadixSort(queueArr, numbers, 10)
        BuildArrayFromQueues(queueArr, numbers)
        Console.WriteLine("Second pass: ")
        ShowArray(numbers)

        Console.Write("Press enter")
        Console.Read()
    End Sub

    Public Function BuildQueue() As Queue()
        Dim queueArr(9) As Queue
        For x As Integer = 0 To 9
            queueArr(x) = New Queue()
        Next
        Return queueArr
    End Function

    Public Sub ShowArray(ByVal arr() As Integer)
        For index As Integer = 0 To arr.Length - 1
            Console.Write(arr(index) & " ")
        Next
        Console.WriteLine()
    End Sub

    Public Sub RadixSort(ByVal queueArr() As Queue, ByVal numbers() As Integer, ByVal digit As DigitType)
        Dim queueIndex As Integer
        For x = 0 To numbers.GetUpperBound(0)
            If digit = DigitType.ones Then
                queueIndex = numbers(x) Mod 10
            Else
                queueIndex = numbers(x) \ 10
            End If
            ' Console.WriteLine("Queue: " & queueIndex & ", Number: " & numbers(x))
            queueArr(queueIndex).Enqueue(numbers(x))
        Next
    End Sub

    Public Sub BuildArrayFromQueues(ByVal queueArr() As Queue, ByVal numbers() As Integer)
        Dim arrIndex As Integer = 0
        For x As Integer = 0 To 9
            While (queueArr(x).Count > 0)
                numbers(arrIndex) = queueArr(x).Dequeue
                arrIndex += 1
            End While
        Next
    End Sub

End Module
