Module CSetTest

    Sub TestCSet()
        Dim setA As New CSet
        Dim setB As New CSet
        setA.Add("milk")
        setA.Add("eggs")
        setA.Add("bacon")
        setA.Add("cereal")

        setB.Add("bacon")
        setB.Add("eggs")
        setB.Add("bread")

        Dim setC As New CSet
        setC = setA.Union(setB)
        Console.WriteLine()
        Console.WriteLine("A: " & setA.ToString)
        Console.WriteLine("B: " & setB.ToString)
        Console.WriteLine("A union B: " & setC.ToString)

        setC = setA.Intersection(setB)
        Console.WriteLine("A intersection B: " & setC.ToString)

        setC = setA.Difference(setB)
        Console.WriteLine("A difference B: " & setC.ToString)

        setC = setB.Difference(setA)
        Console.WriteLine("B difference A: " & setC.ToString)
    End Sub

End Module
