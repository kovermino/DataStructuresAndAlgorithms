Module CArrayTest

    Public Sub TestBubbleSort()
        Dim cArr As New CArray(10)
        cArr.Insert(2)
        cArr.Insert(1)
        cArr.Insert(5)
        cArr.Insert(11)
        cArr.Insert(6)
        cArr.Insert(9)
        cArr.Insert(3)
        cArr.Insert(7)
        cArr.Insert(15)
        cArr.Insert(8)
        cArr.Insert(20)
        cArr.Insert(4)
        cArr.Insert(0)
        cArr.MergeSort()
        cArr.ShowArray()
    End Sub

End Module
