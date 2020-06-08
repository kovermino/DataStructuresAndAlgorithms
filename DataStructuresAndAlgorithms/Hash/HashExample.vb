Module HashExample

    Sub SimpleHashTest()
        Dim names(99) As String
        Dim someNames() As String = {"David", "Jennifer", "Donnie", "Mayo", "Raymond", "Bernica", "Mike", "Clayton", "Beata", "Michael"}
        Dim name As String
        Dim hashVal As Integer

        For index As Integer = 0 To 9
            name = someNames(index)
            hashVal = BetterHash(name, names)
            names(hashVal) = name
        Next
        ShowDistribution(names)
        Console.Read()
    End Sub

    Function SimpleHash(ByVal s As String, ByVal arr() As String) As Integer
        Dim tot As Integer = 0

        For index As Integer = 0 To s.Length - 1
            tot += Asc(s.Chars(index))
        Next

        Return tot Mod arr.GetUpperBound(0)
    End Function

    Sub ShowDistribution(ByVal arr() As String)
        For index As Integer = 0 To arr.GetUpperBound(0)
            If (arr(index) <> "") Then
                Console.WriteLine(index & " : " & arr(index))
            End If
        Next
    End Sub

    Function BetterHash(ByVal s As String, ByVal arr() As String) As Integer
        Dim tot As Long
        For index As Integer = 0 To s.Length - 1
            tot += 37 * tot + Asc(s.Chars(index))
        Next
        tot = tot Mod arr.GetUpperBound(0)
        If (tot < 0) Then
            tot += arr.GetUpperBound(0)
        End If
        Return CInt(tot)
    End Function

    Function InHash(ByVal key As String, ByVal arr() As String) As Boolean
        Dim hval As Integer = BetterHash(key, arr)
        If (arr(hval) = key) Then
            Return True
        End If
        Return False
    End Function

    Sub HashtableExample()
        Dim symbols As New Hashtable(25)
        symbols.Add("salary", 100000)
        symbols.Add("name", "David Durr")
        symbols.Add("age", 43)
        symbols.Add("dept", "Information Technology")
        symbols.Item("sex") = "Male"

        Console.WriteLine("The keys are: ")
        For Each key As Object In symbols.Keys()
            Console.WriteLine(key)
        Next
        Console.WriteLine()

        Console.WriteLine("The values are: ")
        For Each value As Object In symbols.Values
            Console.WriteLine(value)
        Next
        Console.Read()
    End Sub

    Sub HashtableItemExample()
        Dim symbols As New Hashtable(25)
        symbols.Add("salary", 100000)
        symbols.Add("name", "David Durr")
        symbols.Add("age", 43)
        symbols.Add("dept", "Information Technology")
        symbols.Item("sex") = "Male"

        Console.WriteLine("Hash table dump - ")
        Console.WriteLine()
        For Each key As Object In symbols.Keys()
            Console.WriteLine(CStr(key) & ": " & CStr(symbols.Item(key)))
        Next
        Console.Read()
    End Sub

End Module
