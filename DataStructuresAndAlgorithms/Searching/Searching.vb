Imports System.IO

Module Searching

    Private data() As Integer

    Public Delegate Sub SearchTest()

    Public Sub TestSeqSearch()
        Dim numbers(99) As Integer
        Dim numbersFile As StreamReader = File.OpenText("C:\numbers")

        For index As Integer = 0 To numbers.GetUpperBound(0)
            numbers(index) = CInt(numbersFile.ReadLine())
        Next

        Console.Write("Enter a number to search for: ")

        Dim searchNumber As Integer = CInt(Console.ReadLine())
        Dim foundAt As Integer = SeqSearchPosition(numbers, searchNumber)

        If (foundAt >= 0) Then
            Console.WriteLine("Founded at " & foundAt)
        Else
            Console.WriteLine("Not exist.")
        End If

        Console.Read()
    End Sub

    Public Sub TestBinSearch()
        Dim myNums As New CArray(20)
        For index As Integer = 0 To 20
            myNums.Insert(CInt(Int(100 * Rnd() + 1)))
        Next
        myNums.InsertionSort()
        myNums.ShowArray()

        Dim arr(myNums.Data.Length) As Integer
        myNums.Data.CopyTo(arr, 0)

        Dim position As Integer = BinarySearch(arr, 77)
        If (position > -1) Then
            Console.WriteLine("found item: " & position)
        Else
            Console.WriteLine("Not found.")
        End If
        'Console.Read()
    End Sub

    Public Sub TestRBinSearch()
        Dim myNums As New CArray(20)
        For index As Integer = 0 To 20
            myNums.Insert(CInt(Int(100 * Rnd() + 1)))
        Next
        myNums.InsertionSort()
        myNums.ShowArray()

        Dim arr(myNums.Data.Length) As Integer
        myNums.Data.CopyTo(arr, 0)

        Dim position As Integer = RBinarySearch(arr, 77, 0, arr.GetUpperBound(0))
        If (position > -1) Then
            Console.WriteLine("found item: " & position)
        Else
            Console.WriteLine("Not found.")
        End If
        'Console.Read()
    End Sub

    Public Function SeqSearch(ByVal arr() As Integer, ByVal sValue As Integer) As Integer
        For index As Integer = 0 To arr.GetUpperBound(0)
            If (arr(index) = sValue) Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function SeqSearchPosition(ByVal arr() As Integer, ByVal sValue As Integer) As Integer
        For index As Integer = 0 To arr.GetUpperBound(0)
            If (arr(index) = sValue) Then
                Return index
            End If
        Next
        Return -1
    End Function

    Public Function SeqSearchSelfOrg(ByVal sValue As Integer) As Boolean
        For index As Integer = 0 To data.GetUpperBound(0)
            If (data(index) = sValue) Then
                Swap(index, index - 1)
                Return True
            End If
        Next
        Return False
    End Function

    Public Function SeqSearchSelfOrgPareto(ByVal sValue As Integer) As Integer
        For index As Integer = 0 To data.GetUpperBound(0)
            If (data(index) = sValue) AndAlso (index > (data.Length * 0.2)) Then
                Swap(index, 0)
                Return index
            Else
                Return index
            End If
        Next
        Return -1
    End Function

    Public Function SeqSearchSelfOrgAdvance(ByVal sValue As Integer) As Integer
        For index As Integer = 0 To data.GetUpperBound(0)
            If (data(index) = sValue) Then
                Swap(index, index - 1)
            End If
        Next
        Return -1
    End Function

    Public Sub Swap(pre As Integer, post As Integer)
        Dim temp As Integer = data(pre)
        data(pre) = data(post)
        data(post) = temp
    End Sub

    Public Function FindMin(ByVal arr() As Integer) As Integer
        Dim min As Integer = arr(0)
        For index As Integer = 0 To arr.GetUpperBound(0)
            If (arr(index) < min) Then
                min = arr(index)
            End If
        Next
        Return min
    End Function

    Public Function FindMax(ByVal arr() As Integer) As Integer
        Dim max As Integer = arr(0)
        For index As Integer = 1 To arr.GetUpperBound(0)
            If (arr(index) > max) Then
                max = arr(index)
            End If
        Next
        Return max
    End Function

    Public Function BinarySearch(ByVal arr() As Integer, ByVal sValue As Integer) As Integer
        Dim upperBound As Integer = arr.GetUpperBound(0)
        Dim lowerBound As Integer = 0
        Dim mid As Integer

        While (upperBound >= lowerBound)
            mid = (upperBound + lowerBound) / 2
            If (arr(mid) = sValue) Then
                Return mid
            ElseIf (arr(mid) > sValue) Then
                upperBound = mid - 1
            Else
                lowerBound = mid + 1
            End If
        End While
        Return -1
    End Function

    Public Function RBinarySearch(ByRef arr() As Integer, ByVal sValue As Integer, ByVal lower As Integer, ByVal upper As Integer) As Integer
        If (lower > upper) Then
            Return -1
        Else
            Dim mid As Integer = (upper + lower) / 2
            If (sValue = arr(mid)) Then
                Return mid
            ElseIf (sValue > arr(mid)) Then
                Return RBinarySearch(arr, sValue, mid + 1, upper)
            Else
                Return RBinarySearch(arr, sValue, lower, mid - 1)
            End If
        End If
    End Function


End Module
