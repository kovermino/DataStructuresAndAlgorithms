Module BSetTest
    Sub TestBSet()
        Dim setA As New BSet
        Dim setB As New BSet

        setA.Add(1)
        setA.Add(2)
        setA.Add(3)

        setB.Add(2)
        setB.Add(3)

        Console.WriteLine(setA.ToString())
        Console.WriteLine(setB.ToString())

        Dim setC As New BSet
        setC = setA.Union(setB)
        Console.WriteLine()
        Console.WriteLine(setC.ToString())

        setC = setA.Intersection(setB)
        Console.WriteLine(setC.ToString())

        setC = setA.Difference(setB)
        Console.WriteLine(setC.ToString())

        If setB.IsSubsetOf(setA) Then
            Console.WriteLine("b is subset of a")
        Else
            Console.WriteLine("b is not subset of a")
        End If
    End Sub
End Module
