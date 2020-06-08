Imports System

Module Program
    Sub Main(args As String())
        AdvancedTopSortTest()
    End Sub

    Public Sub CallByValue(ByVal p As Person)
        p = New Person("New person", 10)
    End Sub

    Public Sub CallByReference(ByRef p As Person)
        p = New Person("New person", 10)
    End Sub

    Public Function IsPalindrome(ByVal str As String) As Boolean
        Dim stack As New CStack()
        Dim myStack As New Stack(20)

        Dim names() As String = {"Raymond", "David", "Mike"}
        Dim nameStack As New Stack(names)

        For index As Integer = 0 To str.Length - 1
            stack.Push(str.Chars(index))
        Next

        For index As Integer = 0 To str.Length - 1
            If stack.Pop() <> str.Chars(index) Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Sub TimeChecking(ByRef timer As Timer, ByRef test As SearchTest)
        timer.StartTime()
        test.Invoke()
        timer.StopTime()
        Console.WriteLine("Elapsed time: " & timer.Result.TotalMilliseconds)
    End Sub

    Private Sub SearchingTest()
        Dim sortTime As New Timer
        Dim numItems As Integer = 999999999
        Dim arrayForSearching As New CArray(numItems)

        Dim current As Integer
        For index As Integer = 0 To numItems
            ' current = CInt(numItems + 1) * Rnd() + 1
            arrayForSearching.Insert(index)
        Next


        'arrayForSearching.SelectionSort()

        sortTime.StartTime()
        Dim binPos As Integer = arrayForSearching.BinarySearch(77)
        sortTime.StopTime()
        Console.WriteLine("BinarySearch: " & binPos & ", " & sortTime.Result.TotalMilliseconds)

        sortTime.StartTime()
        Dim rbinPos As Integer = arrayForSearching.RBinarySearch(77, 0, arrayForSearching.Data.GetUpperBound(0))
        sortTime.StopTime()
        Console.WriteLine("RBinarySearch: " & rbinPos & ", " & sortTime.Result.TotalMilliseconds)
        Console.Read()
    End Sub

    Private Sub SortingTest()
        Dim sortTime As New Timer
        Dim numItems As Integer = 9999
        Dim arrayForSelectionSort As New CArray(numItems)
        Dim arrayForSelectionSortCustom As New CArray(numItems)
        Dim arrayForBubbleSort As New CArray(numItems)
        Dim arrayForInsertionSort As New CArray(numItems)

        Dim current As Integer
        For index As Integer = 0 To numItems
            current = CInt(numItems + 1) * Rnd() + 1
            arrayForSelectionSort.Insert(current)
            arrayForSelectionSortCustom.Insert(current)
            arrayForBubbleSort.Insert(current)
            arrayForInsertionSort.Insert(current)
        Next

        sortTime.StartTime()
        arrayForSelectionSort.SelectionSort()
        sortTime.StopTime()
        Console.WriteLine("Selection Sort: " & sortTime.Result.TotalMilliseconds)

        sortTime.StartTime()
        arrayForSelectionSortCustom.SelectionSortCustom()
        sortTime.StopTime()
        Console.WriteLine("Selection Sort Custom: " & sortTime.Result.TotalMilliseconds)

        sortTime.StartTime()
        arrayForBubbleSort.BubbleSort()
        sortTime.StopTime()
        Console.WriteLine("Bubble Sort: " & sortTime.Result.TotalMilliseconds)

        sortTime.StartTime()
        arrayForInsertionSort.InsertionSort()
        sortTime.StopTime()
        Console.WriteLine("Insertion Sort: " & sortTime.Result.TotalMilliseconds)
        Console.Read()
    End Sub

    Public Sub PrimeGenTest()
        Dim size As Integer = 100
        Dim primes As New CArray(size - 1)

        For index As Integer = 0 To size - 1
            primes.Insert(1)
        Next
        primes.GenPrimes()
        primes.ShowPrimes()
        Console.Read()
    End Sub
End Module

Public Class Timer
    Private startingTime As TimeSpan
    Private duration As TimeSpan

    Public Sub New()
        startingTime = New TimeSpan(0)
        duration = New TimeSpan(0)
    End Sub

    Public Sub StopTime()
        duration = Process.GetCurrentProcess.Threads(0).UserProcessorTime.Subtract(startingTime)
    End Sub

    Public Sub StartTime()
        GC.Collect()
        GC.WaitForPendingFinalizers()
        startingTime = Process.GetCurrentProcess.Threads(0).UserProcessorTime
    End Sub

    Public ReadOnly Property Result() As TimeSpan
        Get
            Return duration
        End Get
    End Property
End Class

Public Class Person
    Private _name As String
    Private _age As Integer

    Public Property Name
        Get
            Return _name
        End Get
        Set(value)
            _name = value
        End Set
    End Property

    Public Property Age
        Get
            Return _age
        End Get
        Set(value)
            _age = value
        End Set
    End Property

    Public Sub New(name As String, age As Integer)
        _name = name
        _age = age
    End Sub
End Class
