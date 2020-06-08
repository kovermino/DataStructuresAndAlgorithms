Imports System.IO

Module QueueProgram

    Public Structure Dancer
        Dim name As String
        Dim sex As String
    End Structure

    Public Sub QueueApplication()
        Dim males As New Queue()
        Dim females As New Queue()

        LoadDancers(males, females)
        StartDancing(males, females)

        If (males.Count > 0) Or (females.Count > 0) Then
            HeadofLine(males, females)
        End If
        NewDancers(males, females)

        If (males.Count > 0) Or (females.Count > 0) Then
            HeadofLine(males, females)
        End If
        NewDancers(males, females)
        Console.WriteLine("Press enter to quit")
        Console.Read()
    End Sub

    Public Sub LoadDancers(ByRef male As Queue, ByRef female As Queue)
        Dim d As Dancer
        Dim inFile As StreamReader = File.OpenText("C:\dancers.dat")
        Dim line As String
        While (inFile.Peek() <> -1)
            line = inFile.ReadLine()
            d.sex = line.Chars(0)
            d.name = line.Substring(2, line.Length - 2)
            If (d.sex = "M") Then
                male.Enqueue(d)
            Else
                female.Enqueue(d)
            End If
        End While
    End Sub
    Public Sub StartDancing(ByRef male As Queue, ByRef female As Queue)
        Dim m, w As Dancer
        Console.WriteLine("Dance partners are: ")
        Console.WriteLine()
        For count As Integer = 0 To 3
            m = male.Dequeue()
            w = female.Dequeue()
            Console.WriteLine(w.name & Constants.vbTab & m.name)
        Next
    End Sub

    Public Sub NewDancers(ByRef male As Queue, ByRef female As Queue)
        Dim m, w As Dancer
        If (male.Count > 0) And (female.Count > 0) Then
            m = male.Dequeue()
            w = female.Dequeue()
            Console.WriteLine("The new dancers are: " & m.name & " and " & w.name)
        ElseIf (male.Count > 0) And (female.Count = 0) Then
            Console.WriteLine("Waiting on a female dancer.")
        ElseIf (male.Count = 0) And (female.Count > 0) Then
            Console.WriteLine("Waiting on a male dancer.")
        End If
    End Sub

    Public Sub HeadofLine(ByRef male As Queue, ByRef female As Queue)
        Dim m, w As New Dancer
        If (male.Count > 0) Then
            m = male.Peek()
        End If

        If (female.Count > 0) Then
            w = female.Peek()
        End If

        If (m.name <> "" And w.name <> "") Then
            Console.WriteLine("Next in line is: " & m.name & Constants.vbTab & w.name)
        Else
            If (m.name <> "") Then
                Console.WriteLine("Next in line is: " & m.name)
            Else
                Console.WriteLine("Next in line is: " & w.name)
            End If
        End If
    End Sub

End Module
