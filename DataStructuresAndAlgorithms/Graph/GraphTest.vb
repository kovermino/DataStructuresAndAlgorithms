Module GraphTest

    Sub SimpleTopSortTest()
        Dim theGraph As New Graph
        theGraph.AddVertex("A")
        theGraph.AddVertex("B")
        theGraph.AddVertex("C")
        theGraph.AddVertex("D")
        theGraph.AddEdge(0, 1)
        theGraph.AddEdge(1, 2)
        theGraph.AddEdge(2, 3)
        theGraph.AddEdge(3, 4)
        theGraph.TopSort()
        Console.WriteLine()
        Console.WriteLine("Finished.")
        Console.Read()
    End Sub

    Sub AdvancedTopSortTest()
        Dim theGraph As New Graph
        theGraph.AddVertex("CS1")
        theGraph.AddVertex("CS2")
        theGraph.AddVertex("DS")
        theGraph.AddVertex("OS")
        theGraph.AddVertex("ALG")
        theGraph.AddVertex("AL")
        theGraph.AddEdge(0, 1)
        theGraph.AddEdge(1, 2)
        theGraph.AddEdge(1, 5)
        theGraph.AddEdge(2, 3)
        theGraph.AddEdge(2, 4)
        theGraph.TopSort()
        Console.WriteLine()
        Console.WriteLine("Finished.")
        Console.Read()
    End Sub

End Module
