Imports System.Text
Module StringExample
    Sub StringTest()
        Dim str As New String("Hello world")
        Dim len As Integer = str.Length()
        Dim pos As Integer = str.IndexOf(" ")

        Dim firstWord As String = str.Substring(0, pos)
        Dim secondWord As String = str.Substring(pos + 1, len - (pos + 1))

        Console.WriteLine("First word: " & firstWord)
        Console.WriteLine("Second word: " & secondWord)
    End Sub

    Sub StringSplit()
        Dim str As New String("now is the time")
        Dim pos As Integer
        Dim word As String
        Dim words As New Collection

        pos = str.IndexOf(" ")
        While (pos > 0)
            word = str.Substring(0, pos)
            words.Add(word)
            str = str.Substring(pos + 1, str.Length() - (pos + 1))
            pos = str.IndexOf(" ")

            If (pos = -1) Then
                word = str.Substring(0, str.Length())
                words.Add(word)
            End If
        End While
        Console.Read()
    End Sub

    Sub StringSplitTest()
        Dim string1 As New String("now is the time for all good people")
        Dim words As Collection = SplitWords(string1)

        For Each word As Object In words
            Console.WriteLine(word)
        Next
        Console.Read()
    End Sub

    Function SplitWords(ByVal str As String) As Collection
        Dim space As String = " "
        Dim pos As Integer = str.IndexOf(space)
        Dim word As String
        Dim words As New Collection
        While (pos > 0)
            word = str.Substring(0, pos)
            words.Add(word)

            str = str.Substring(pos + 1, str.Length - (pos + 1))
            pos = str.IndexOf(space)
            If (pos = -1) Then
                word = str.Substring(0, str.Length)
                words.Add(word)
            End If
        End While
        Return words
    End Function

    Sub SplitFunctionTest()
        Dim data As String = "Mike, McMillan,3000 W. Scenic,North Little Rock,AR,72118"
        Dim sdata() As String = data.Split(",")

        For index As Integer = 0 To sdata.GetUpperBound(0)
            Console.WriteLine(sdata(index))
        Next
    End Sub

    Sub JoinFunctionTest()
        Dim data As String = "Mike, McMillan,3000 W. Scenic,North Little Rock,AR,72118"
        Dim sdata() As String = data.Split(",")

        Dim data2 As String = String.Join(",", sdata)
        Console.WriteLine(data2)
        Console.Read()
    End Sub

    Sub CompareToTest()
        Dim s1 As New String("foobar")
        Dim s2 As String = "foobar"

        Console.WriteLine(s1.CompareTo(s2)) ' Returns 0
        s2 = "foofoo"
        Console.WriteLine(s1.CompareTo(s2)) ' Returns -1
        s2 = "fooaar"
        Console.WriteLine(s1.CompareTo(s2)) ' Returns 1
    End Sub

    Sub CompareTest()
        Dim s1 As New String("foobar")
        Dim s2 As String = "foobar"

        Dim compVal As Integer = String.Compare(s1, s2)
        Select Case compVal
            Case 0
                Console.WriteLine(s1 & " " & s2 & " are equal")
            Case 1
                Console.WriteLine(s1 & " is less than " & s2)
            Case 2
                Console.WriteLine(s1 & " is greater than " & s2)
            Case Else
                Console.WriteLine("Can't compare.")
        End Select
    End Sub

    Sub EndsWithTest()
        Dim nouns() As String = {"cat", "dogs", "bird", "eggs", "bones"}
        Dim pluralNouns As New Collection

        For Each noun As String In nouns
            If (noun.EndsWith("s")) Then
                pluralNouns.Add(noun)
            End If
        Next

        For Each noun In pluralNouns
            Console.WriteLine(noun)
        Next
        Console.Read()
    End Sub

    Sub StartsWithTest()
        Dim words() As String = {"triangle", "diagonal", "trimeter", "bifocal", "triglycerides"}
        Dim triWords As New Collection

        For Each word As String In words
            If (word.StartsWith("tri")) Then
                triWords.Add(word)
            End If
        Next

        For Each triWord As String In triWords
            Console.WriteLine(triWord)
        Next

        Console.Read()
    End Sub

    Sub LikeOperatorsTest()
        Dim s1 As String = "foobar"
        Dim aMatch As String = IIf(s1 Like "foo?ar", "match", "not match")
        Console.WriteLine(aMatch)
        aMatch = IIf(s1 Like "f*", "match", "not match")
        Console.WriteLine(aMatch)

        Dim s2 As New String("H2")
        aMatch = IIf(s2 Like "[hH][0-9]", "match", "not match")
        Console.WriteLine(aMatch)
        Console.Read()
    End Sub

    Sub NumberFormatTest()
        Dim a As Integer = 1
        Dim b As Integer = 2
        Dim c As Integer = 13
        Dim d As Integer = 20
        Dim e As Integer = 92
        Dim f As Integer = 100

        ConvertToNumberFormat(a)
        ConvertToNumberFormat(b)
        ConvertToNumberFormat(c)
        ConvertToNumberFormat(d)
        ConvertToNumberFormat(e)
        ConvertToNumberFormat(f)

        Console.Read()
    End Sub

    Sub StringInsertTest()
        Dim s1 As New String("Hello, . welcome to my class.")
        Dim name As String = "Clayton"
        Dim pos As Integer = s1.IndexOf(",")
        s1 = s1.Insert(pos + 2, name)
        Console.WriteLine(s1)
        Console.Read()
    End Sub

    Sub StringRemoveTest()
        Dim s1 As New String("Hello, . welcome to my class.")
        Dim name As String = "Clayton"
        Dim pos As Integer = s1.IndexOf(",")
        s1 = s1.Insert(pos + 2, name)
        Console.WriteLine(s1)
        s1 = s1.Remove(pos + 2, name.Length)
        Console.WriteLine(s1)
        Console.Read()
    End Sub

    Sub StringReplaceTest()
        Dim words() As String = {"recieve", "decieve", "reciept"}

        For index As Integer = 0 To words.GetUpperBound(0)
            words(index) = words(index).Replace("cie", "cei")
            Console.WriteLine(words(index))
        Next
        Console.Read()
    End Sub

    Sub ConvertToNumberFormat(ByVal value As Integer)
        Console.WriteLine(Format(value, "000"))
    End Sub

    Sub SubStringTest()
        Dim str As String = "C2005212"
        Dim newInteger As Integer = CInt(str.Substring(5))
        Console.WriteLine(newInteger)
        Console.Read()
    End Sub

    Sub PadLeftTest()
        Dim s1 As String = "Hello"
        Console.WriteLine(s1.PadLeft(10))
        Console.WriteLine("world")
        Console.Read()
    End Sub

    Sub PadRightTest()
        Dim s1 As New String("Hello")
        Dim s2 As New String("world")
        Dim s3 As New String("GoodBye")
        Console.Write(s1.PadLeft(10))
        Console.WriteLine(s2.PadLeft(10))
        Console.Write(s3.PadLeft(10))
        Console.WriteLine(s2.PadLeft(10))
        Console.Read()
    End Sub

    Sub PadMethodsTest()
        Dim names(,) As String = {{"1504", "Mary", "Ella", "Steve", "Bob"}, {"1133", "Elizabeth", "Alex", "David", "Joe"}, {"2624", "Chris", "Gordon", "Craig", "Bill"}}
        Dim inner, outer As Integer
        Console.WriteLine()
        Console.WriteLine()

        For outer = 0 To names.GetUpperBound(0)
            For inner = 0 To names.GetUpperBound(1)
                Console.Write(names(outer, inner) & " ")
            Next
            Console.WriteLine()
        Next
        Console.WriteLine()
        Console.WriteLine()

        For outer = 0 To names.GetUpperBound(0)
            For inner = 0 To names.GetUpperBound(1)
                Console.Write(names(outer, inner).PadRight(10) & " ")
            Next
            Console.WriteLine()
        Next
        Console.Read()
    End Sub

    Sub ConcatTest()
        Dim s1 As New String("Hello")
        Dim s2 As New String("World")
        Dim s3 As New String("")
        s3 = String.Concat(s1, " ", s2)
        Console.WriteLine(s3)
        Console.Read()
    End Sub

    Sub GovernanceSeqTest()
        Dim seq1 As String = "C2001001"
        Dim seq2 As String = "C2001025"
        Dim seq3 As String = "C2306224"
        Dim seq4 As String = "C5011029"
        Dim seq5 As String = "C9012045"
        Dim seq6 As String = "C9912999"
        Dim seq7 As String = "C8"
        Console.WriteLine(GetNextHistorySeq(seq1))
        Console.WriteLine(GetNextHistorySeq(seq2))
        Console.WriteLine(GetNextHistorySeq(seq3))
        Console.WriteLine(GetNextHistorySeq(seq4))
        Console.WriteLine(GetNextHistorySeq(seq5))
        Console.WriteLine(GetNextHistorySeq(seq6))
        Console.WriteLine(GetNextHistorySeq(seq7))
        Console.Read()
    End Sub

    Public Function GetNextHistorySeq(ByVal historyNo As String) As String
        Dim seqHeader As String = Date.Now.ToString("yyMM")
        Dim newSeq As Integer = 1
        Dim resultSeq As String = String.Empty
        If (historyNo.Length >= 8) AndAlso (historyNo.Substring(1, 4) = seqHeader) Then ' C2001001 : 2020년 01월 001번째
            Dim preSeq As Integer = CInt(historyNo.Substring(5))
            newSeq = preSeq + 1
        End If
        resultSeq = seqHeader & Format(newSeq, "000")
        Return resultSeq
    End Function

    Sub TrimExample()
        Dim names() As String = {" David", " Raymond", "Mike ", "Beronica "}
        Console.WriteLine()
        ShowNames(names)
        Console.WriteLine()
        TrimVals(names)
        Console.WriteLine()
        ShowNames(names)
        Console.Read()
    End Sub

    Sub ShowNames(ByVal names() As String)
        For index As Integer = 0 To names.GetUpperBound(0)
            Console.Write(names(index))
        Next
    End Sub

    Sub TrimVals(ByVal names() As String)
        For index As Integer = 0 To names.GetUpperBound(0)
            names(index) = names(index).Trim(" "c)
            names(index) = names(index).TrimEnd(" "c)
        Next
    End Sub

    Sub TrimHTMLTest()
        Dim htmlComments() As String = {"<-- Start Page Number Function -->",
                                        "<-- Get user name and password -->",
                                        "<-- End Title page -->",
                                        "<-- End script -->"}
        Dim commentChars() As Char = {"<", "!", "-", ">"}
        For index As Integer = 0 To htmlComments.GetUpperBound(0)
            htmlComments(index) = htmlComments(index).Trim(commentChars)
            htmlComments(index) = htmlComments(index).TrimEnd(commentChars)
        Next

        For index As Integer = 0 To htmlComments.GetUpperBound(0)
            Console.WriteLine("Comment: " & htmlComments(index))
        Next
        Console.Read()
    End Sub

    Sub StringBuilderTest()
        Dim strBld As New StringBuilder("Stephan Jay Gould")
        Console.WriteLine("Length of strBld: " & strBld.Length)
        Console.WriteLine("Capacity of strBld: " & strBld.Capacity)
        Console.WriteLine("MaxCapacity of strBld: " & strBld.MaxCapacity)
        Console.Read()
    End Sub

    Sub StringBuilderAppendTest()
        Dim stBuff As New StringBuilder()
        Dim words() As String = {"now ", "is ", "the ", "time ", "for ",
                                 "all ", "good ", "men ", "to ", "come", "to ",
                                 "the ", "aid ", "of ", "their ", "party"}

        For index As Integer = 0 To words.GetUpperBound(0)
            stBuff.Append(words(index))
        Next

        Console.WriteLine(stBuff)
        Console.Read()
    End Sub

    Sub FormattedNubmerTest()
        Dim stBuff As New StringBuilder()
        Console.WriteLine()

        stBuff.AppendFormat("Your order is for {0000} widget.", 234)
        stBuff.AppendFormat(Constants.vbCrLf & "We have {0000} widgets left.", 12)
        Console.WriteLine(stBuff)
        Console.Read()
    End Sub

    Sub StringBuilderInsertTest()
        Dim stBuff As New StringBuilder()
        stBuff.Insert(0, "Hello")
        stBuff.Append("world")
        stBuff.Insert(5, ", ")
        Console.WriteLine(stBuff)

        Dim chars() As Char = {"t"c, "h"c, "e"c, "r"c, "e"}
        stBuff.Insert(5, " " & chars)
        Console.WriteLine(stBuff)

        stBuff.Insert(0, "repeat", 2)
        Console.WriteLine(stBuff)
        Console.Read()
    End Sub

    Sub StringBuilderRemoveTest()
        Dim stBuff As New StringBuilder("noise in +++++string")
        stBuff.Remove(9, 5)
        Console.WriteLine(stBuff)
        Console.Read()
    End Sub

    Sub StringBuilderToStringTest()
        Dim stBuff As New StringBuilder("HELLO WORLD")
        Dim st As String = stBuff.ToString()
        st = st.ToLower()
        st = st.Replace(st.Substring(0, 1), st.Substring(0, 1).ToUpper())
        stBuff.Replace(stBuff.ToString(), st)
        Console.WriteLine(stBuff)
        Console.Read()
    End Sub
End Module
