Public Class Graph

    Private Const NUM_VERTICES As Integer = 20
    Private vertices() As Vertex
    Private adjMatrix(,) As Integer
    Private numVerts As Integer

    Public Sub New()
        ReDim vertices(NUM_VERTICES)
        ReDim adjMatrix(NUM_VERTICES, NUM_VERTICES)
        numVerts = 0

        For j As Integer = 0 To NUM_VERTICES - 1
            For k As Integer = 0 To NUM_VERTICES - 1
                adjMatrix(j, k) = 0
            Next
        Next
    End Sub

    Public Sub AddVertex(ByVal label As String)
        vertices(numVerts) = New Vertex(label)
        numVerts += 1
    End Sub

    Public Sub AddEdge(ByVal start As Integer, ByVal eend As Integer)
        adjMatrix(start, eend) = 1
    End Sub

    Public Sub ShowVertex(ByVal v As Integer)
        Console.Write(vertices(v).label)
    End Sub

    Public Function NoSuccessors() As Integer
        Dim isEdge As Boolean
        For row As Integer = 0 To numVerts - 1
            isEdge = False
            For col As Integer = 0 To numVerts - 1
                If adjMatrix(row, col) > 0 Then
                    isEdge = True
                    Exit For
                End If
            Next
            If Not isEdge Then
                Return row
            End If
        Next
        Return -1
    End Function

    Public Sub delVertex(ByVal vert As Integer)
        If (vert <> numVerts) Then
            For j As Integer = vert To numVerts - 1
                vertices(j) = vertices(j + 1)
            Next

            For row As Integer = vert To numVerts - 1
                moveRow(row, numVerts)
            Next

            For col As Integer = vert To numVerts - 1
                moveCol(col, numVerts - 1)
            Next
            numVerts -= 1
        End If
    End Sub

    Private Sub moveRow(ByVal row As Integer, ByVal length As Integer)
        For col As Integer = 0 To length - 1
            adjMatrix(row, col) = adjMatrix(row + 1, col)
        Next
    End Sub

    Private Sub moveCol(ByVal col As Integer, ByVal length As Integer)
        For row As Integer = 0 To length - 1
            adjMatrix(row, col) = adjMatrix(row, col + 1)
        Next
    End Sub

    Public Sub TopSort()
        Dim gStack As New Stack(Of String)
        While (numVerts > 0)
            Dim currVertex As Integer = NoSuccessors()
            If currVertex = -1 Then
                Console.WriteLine("Error: graph has cycles")
                Exit Sub
            End If
            gStack.Push(vertices(currVertex).label)
            delVertex(currVertex)
        End While
        Console.WriteLine("Topological sorting order: ")
        While (gStack.Count > 0)
            Console.Write(gStack.Pop() & " ")
        End While
    End Sub

End Class