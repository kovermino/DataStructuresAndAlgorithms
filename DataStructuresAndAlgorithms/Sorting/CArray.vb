Public Class CArray
    Private arr() As Integer
    Private numElements As Integer

    Public ReadOnly Property Data As Integer()
        Get
            Return arr
        End Get
    End Property

    Public Sub New(ByVal number As Integer)
        ReDim Preserve arr(number)
        numElements = 0
    End Sub

    Public Sub Insert(ByVal item As Integer)
        If (numElements > arr.GetUpperBound(0)) Then
            ReDim Preserve arr(numElements * 1.25)
        End If

        arr(numElements) = item
        numElements += 1
    End Sub

    Public Sub ShowArray()
        For index As Integer = 0 To numElements - 1
            Console.Write(arr(index) & " ")
        Next
        Console.WriteLine()
    End Sub

    Public Sub BubbleSort()
        Dim temp As Integer
        For outer As Integer = numElements - 1 To 1 Step -1
            For inner As Integer = 0 To outer - 1
                If (arr(inner) > arr(inner + 1)) Then
                    temp = arr(inner)
                    arr(inner) = arr(inner + 1)
                    arr(inner + 1) = temp
                End If
            Next
        Next
    End Sub

    Public Sub SelectionSort()
        Dim temp As Integer
        Dim min As Integer
        For outer As Integer = 0 To numElements - 1
            min = outer
            For inner As Integer = outer + 1 To numElements - 1
                If (arr(inner) < arr(min)) Then
                    min = inner
                End If
            Next
            temp = arr(outer)
            arr(outer) = arr(min)
            arr(min) = temp
        Next
    End Sub

    Public Sub SelectionSortCustom()
        Dim temp As Integer
        For outer As Integer = 0 To numElements - 1
            Dim minIndex As Integer = outer
            For inner As Integer = outer + 1 To numElements - 1
                If (arr(minIndex) > arr(inner)) Then
                    minIndex = inner
                End If
            Next
            temp = arr(outer)
            arr(outer) = arr(minIndex)
            arr(minIndex) = temp
        Next
    End Sub

    Public Sub InsertionSort()
        Dim temp As Integer
        Dim inner As Integer
        For outer As Integer = 1 To numElements - 1
            temp = arr(outer)
            inner = outer
            While (inner > 0 AndAlso (arr(inner - 1) >= temp))
                arr(inner) = arr(inner - 1)
                inner -= 1
            End While
            arr(inner) = temp
        Next
    End Sub

    Public Sub MergeSort()
        Dim tempArr(numElements) As Integer
        RecMergeSort(tempArr, 0, numElements - 1)
    End Sub

    Public Sub RecMergeSort(ByVal temparr() As Integer, ByVal lower As Integer, ByVal upper As Integer)
        If (lower = upper) Then
            Return
        Else
            Dim mid As Integer = (lower + upper) \ 2
            RecMergeSort(temparr, lower, mid)
            RecMergeSort(temparr, mid + 1, upper)
            Merge(temparr, lower, mid + 1, upper)
        End If
    End Sub

    Public Sub Merge(ByVal tempArr() As Integer, ByVal firstArrIndex As Integer, ByVal secondArrIndex As Integer, ByVal ubound As Integer)
        Dim tempArrIndex As Integer = 0
        Dim lbound As Integer = firstArrIndex
        Dim mid As Integer = secondArrIndex - 1
        Dim n As Integer = ubound - lbound + 1

        While (firstArrIndex <= mid And secondArrIndex <= ubound)
            If (arr(firstArrIndex) < arr(secondArrIndex)) Then
                tempArr(tempArrIndex) = arr(firstArrIndex)
                tempArrIndex += 1
                firstArrIndex += 1
            Else
                tempArr(tempArrIndex) = arr(secondArrIndex)
                tempArrIndex += 1
                secondArrIndex += 1
            End If
        End While

        While (firstArrIndex <= mid)
            tempArr(tempArrIndex) = arr(firstArrIndex)
            tempArrIndex += 1
            firstArrIndex += 1
        End While

        While (secondArrIndex <= ubound)
            tempArr(tempArrIndex) = arr(secondArrIndex)
            tempArrIndex += 1
            secondArrIndex += 1
        End While

        For tempArrIndex = 0 To n - 1
            arr(lbound + tempArrIndex) = tempArr(tempArrIndex)
        Next
    End Sub

    Public Function BinarySearch(ByVal sValue As Integer) As Integer
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

    Public Function RBinarySearch(ByVal sValue As Integer, ByVal lower As Integer, ByVal upper As Integer) As Integer
        If (lower > upper) Then
            Return -1
        Else
            Dim mid As Integer = (upper + lower) / 2
            If (sValue = arr(mid)) Then
                Return mid
            ElseIf (sValue > arr(mid)) Then
                Return RBinarySearch(sValue, mid + 1, upper)
            Else
                Return RBinarySearch(sValue, lower, mid - 1)
            End If
        End If
    End Function

    Public Sub GenPrimes()
        For outer As Integer = 2 To arr.GetUpperBound(0)
            For inner As Integer = outer + 1 To arr.GetUpperBound(0)
                If (arr(inner) = 1) Then
                    If (inner Mod outer) = 0 Then
                        arr(inner) = 0
                    End If
                End If
            Next
        Next
    End Sub

    Public Sub ShowPrimes()
        For index As Integer = 2 To arr.GetUpperBound(0)
            If (arr(index) = 1) Then
                Console.Write(index & " ")
            End If
        Next
    End Sub
End Class
