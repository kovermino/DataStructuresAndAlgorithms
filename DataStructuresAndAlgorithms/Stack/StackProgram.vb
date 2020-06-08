Module StackProgram

    Public Sub TestInfixArithmetic()
        Dim numbers As New Stack()
        Dim operators As New Stack()
        Dim expression As String = "5 + 10 + 15 + 20"
        Calculate(numbers, operators, expression)
        Console.WriteLine("Calculate: " & numbers.Pop())
        Console.WriteLine("Calculate practice: " & CalculatePractice(expression))
        Console.WriteLine("Press enter to quit")
        Console.Read()
    End Sub

    Public Sub Calculate(ByVal numbers As Stack, ByVal operators As Stack, ByVal exp As String)
        Dim ch As String
        Dim token As String = ""
        For p As Integer = 0 To exp.Length - 1
            ch = exp.Chars(p)
            If (IsNumeric(ch)) Then
                token &= ch
            End If
            If (ch = " ") Or (p = exp.Length - 1) Then
                If IsNumeric(token) Then
                    numbers.Push(token)
                    token = ""
                End If
            ElseIf (ch = "+") Or (ch = "-") Or (ch = "*") Or (ch = "/") Then
                operators.Push(ch)
            End If
            If (numbers.Count = 2) Then
                Compute(numbers, operators)
            End If
        Next
    End Sub

    Public Function CalculatePractice(ByVal exp As String) As String
        Dim numbers As New Stack()
        Dim operators As New Stack()

        Dim ch As String
        Dim token As String = ""
        For p As Integer = 0 To exp.Length - 1
            ch = exp.Chars(p)
            If (IsNumeric(ch)) Then
                token &= ch
            End If
            If (ch = " ") Or (p = exp.Length - 1) Then
                If (IsNumeric(token)) Then
                    numbers.Push(token)
                    token = ""
                End If
            ElseIf (ch = "+") Or (ch = "-") Or (ch = "*") Or (ch = "/") Then
                operators.Push(ch)
            End If
            If (numbers.Count = 2) Then
                Compute(numbers, operators)
            End If
        Next
        Return numbers.Pop()
    End Function

    Public Sub Compute(ByVal numbers As Stack, ByVal operators As Stack)
        Dim oper As String = operators.Pop()
        Dim num1 As Integer = numbers.Pop()
        Dim num2 As Integer = numbers.Pop()

        Select Case oper
            Case "+"
                numbers.Push(num1 + num2)
            Case "-"
                numbers.Push(num1 - num2)
            Case "*"
                numbers.Push(num1 * num2)
            Case "/"
                numbers.Push(num1 / num2)
        End Select
    End Sub

    Public Sub MulBaseTest()
        Dim num As Integer
        Dim base As Integer
        Console.Write("Enter a decimal number:")
        num = Console.ReadLine()
        Console.Write("Enter a base: ")
        base = Console.ReadLine()
        Console.Write(num & " converts to ")
        MulBase(num, base)
        Console.WriteLine(" Base " & base)
        Console.Write("Press enter to quit")
        Console.Read()
    End Sub

    Public Sub MulBase(ByVal n As Integer, ByVal b As Integer)
        Dim Digits As New Stack()

        Do
            Digits.Push(n Mod b)
            n /= b
        Loop While (n <> 0)

        While (Digits.Count > 0)
            Console.Write(Digits.Pop())
        End While
    End Sub

End Module
