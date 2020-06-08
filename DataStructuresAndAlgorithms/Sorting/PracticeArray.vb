Public Class PracticeArray

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

    Public Sub BubbleSort()
        Dim temp As Integer
        For outer As Integer = numElements To 2 Step -1
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
        For outer As Integer = 0 To numElements - 1
            Dim minIndex As Integer = outer
            For inner As Integer = outer + 1 To numElements - 1
                If (arr(minIndex) > arr(inner)) Then
                    minIndex = inner
                End If
            Next
            temp = arr(minIndex)
            arr(minIndex) = arr(outer)
            arr(outer) = temp
        Next
    End Sub

    Public Sub InsertionSort()
        Dim temp As Integer
        Dim inner As Integer
        For outer As Integer = 1 To numElements - 1
            temp = arr(outer)
            inner = outer
            While (inner > 0 AndAlso arr(inner - 1) >= temp)
                arr(inner) = arr(inner - 1)
                inner -= 1
            End While
            arr(inner) = temp
        Next
    End Sub

End Class
