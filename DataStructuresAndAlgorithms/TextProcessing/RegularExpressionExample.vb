Imports System.Text.RegularExpressions

Module RegularExpressionExample

    Sub FirstExample()
        Dim reg As New Regex("over")
        Dim str1 As String = "the quick brown fox jumped over the lazy dog"

        Dim matchSet As Match = reg.Match(str1)
        Dim matchPos As Integer
        If matchSet.Success Then
            matchPos = matchSet.Index()
            Console.WriteLine("found match at position: " & matchPos)
        End If
        Console.Read()
    End Sub

    Sub MatchesTest()
        Dim reg As New Regex("the")
        Dim str1 As String = "the quick brown fox jumped over the lazy dog"
        Dim matchSet As MatchCollection = reg.Matches(str1)
        If (matchSet.Count > 0) Then
            For Each aMatch As Match In matchSet
                Console.WriteLine("Found a match at: " & aMatch.Index)
            Next
        End If
        Console.Read()

        Dim s As String = "the quick brown fox jumped over the lazy dog"
        s = Regex.Replace(s, "brown", "black")
    End Sub

    Sub PlusQuantifierTest()
        Dim words() As String = {"bad", "boy", "baaad", "bear", "bend"}
        For Each word As String In words
            If (Regex.IsMatch(word, "ba+")) Then
                Console.WriteLine(word)
            End If
        Next
        Console.Read()
    End Sub

    Sub NQuantifierTest()
        Dim words() As String = {"bad", "boy", "baad", "baaad", "bear", "bend"}
        For Each word In words
            If (Regex.IsMatch(word, "ba{2}d")) Then
                Console.WriteLine(word)
            End If
        Next
        Console.Read()
    End Sub

    Sub GreedyBehaviorTest()
        Dim words() As String = {"Part", "of", "this", "<b>string<b>", "is", "bold"}
        Dim regexp As String = "<.+?>"
        Dim aMatch As MatchCollection
        For Each word As String In words
            aMatch = Regex.Matches(word, regexp)
            For i As Integer = 0 To aMatch.Count - 1
                Console.WriteLine(aMatch(i).Value)
            Next
            Console.WriteLine()
        Next
        Console.Read()
    End Sub

    Sub PeriodTest()
        Dim str1 As String = "the quick brown fox jumped over the lazy dog"
        Dim matchSet As MatchCollection = Regex.Matches(str1, "t.e")
        For Each aMatch As Match In matchSet
            Console.WriteLine("Matches at : " & aMatch.Index)
        Next
        Console.Read()
    End Sub

    Sub CharacterClassTest()
        Dim str1 As String = "THE quick BROWN fox JUMPED over THE lazy DOG"
        Dim matchSet As MatchCollection = Regex.Matches(str1, "[a-z]")
        For Each aMatch As Match In matchSet
            Console.WriteLine("Matches at : " & aMatch.Value)
        Next
        Console.Read()
    End Sub

    Sub CaretAssertionTest()
        Dim words() As String = {"heal", "heel", "noah", "techno"}
        Dim regexp As String = "^h"
        Dim aMatch As Match
        For Each word As String In words
            If (Regex.IsMatch(word, regexp)) Then
                aMatch = Regex.Match(word, regexp)
                Console.WriteLine("Matched: " & word & " at position: " & aMatch.Index)
            End If
        Next
        Console.Read()
    End Sub

    Sub AnonymousGroupingConstructsTest()
        Dim words As String = "08/14/57 46 02/25/29 45 06/05/85 18 03/12/88 16 09/09/90 13"
        Dim regexp1 As String = "(\s\d{2}\s)"
        Dim matchSet As MatchCollection = Regex.Matches(words, regexp1)
        For Each aMatch As Match In matchSet
            Console.WriteLine(aMatch.Groups(0).Captures(0))
        Next
        Console.Read()
    End Sub

    Sub NamedGroupingConstructsTest()
        Dim words As String = "08/14/57 46 02/25/29 45 06/05/85 18 03/12/88 16 09/09/90 13"
        Dim regexp1 As String = "(?<dates>(\d{2}/\d{2}/\d{2}))\s"
        Dim matchSet As MatchCollection = Regex.Matches(words, regexp1)
        For Each aMatch As Match In matchSet
            Console.WriteLine("Date:{0}", aMatch.Groups("dates"))
        Next
        Console.Read()
    End Sub

    Sub CapturesCollectionTest()
        Dim dates As String = "08/14/57 46 02/25/29 45 06/05/85 18 03/12/88 16 09/09/90 13"
        Dim regexp As String = "(?<dates>(\d{2}/\d{2}/\d{2}))\s(?<ages>(\d{2}))\s"
        Dim matchSet As MatchCollection = Regex.Matches(dates, regexp)
        For Each aMatch As Match In matchSet
            For Each aCapture As Capture In aMatch.Groups("dates").Captures
                Console.WriteLine("date capture: " & aCapture.ToString())
            Next

            For Each aCapture As Capture In aMatch.Groups("ages").Captures
                Console.WriteLine("age capture: " & aCapture.ToString())
            Next
        Next
        Console.Read()
    End Sub

End Module
