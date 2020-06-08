Imports System.Text

Module BitOperations
    Public Sub BitOperationTest()
        Dim val1 As Integer = 1
        Dim val2 As Integer = 2
        Console.WriteLine("Decimal Values - val1: " & val1 & ", val2: " & val2)

        Dim str1 As String = Convert(val1).ToString()
        Dim str2 As String = Convert(val2).ToString()
        Console.WriteLine("Convert val1: " & str1)
        Console.WriteLine("Convert val2: " & str2)

        Dim andResult As String = Convert(val1 And val2).ToString()
        Console.WriteLine("And Result  : " & andResult)

        Dim orResult As String = Convert(val1 Or val2).ToString()
        Console.WriteLine("Or Result   : " & orResult)

        Dim xorResult As String = Convert(val1 Xor val2).ToString()
        Console.WriteLine("Xor Result  : " & xorResult)

        Console.Read()
    End Sub

    Public Function Convert(ByVal val As Integer) As StringBuilder
        Dim dispMask As Integer = 1 << 31
        ' 1을 31 비트만큼 왼쪽으로 이동시킨다 - 10000000 00000000 00000000 00000000
        ' Decimal로는 2^31을 곱한다 = 1*2^31 = 2,147,483,648

        Dim bitBuffer As New StringBuilder(35)

        For index As Integer = 1 To 32
            If (val And dispMask) = 0 Then
                bitBuffer.Append("0")
            Else
                bitBuffer.Append("1")
            End If

            val <<= 1

            If (index Mod 8 = 0) Then
                bitBuffer.Append(" ")
            End If
        Next
        Return bitBuffer
    End Function

    Public Sub BitShiftTest()
        Dim valueLeft As Integer = 4
        Dim shiftLeft As Integer = 2

        Console.WriteLine("Left shift - origin : " & Convert(valueLeft).ToString())
        Console.WriteLine("Left shift - after  : " & LeftShift(valueLeft, shiftLeft))

        Dim valueRight As Integer = 256
        Dim shiftRight As Integer = 8

        Console.WriteLine("Right shift - origin: " & Convert(valueRight).ToString())
        Console.WriteLine("Right shift - after : " & RightShift(valueRight, shiftRight))

        Console.Read()
    End Sub

    Public Function LeftShift(ByVal value As Integer, ByVal numShift As Integer) As String
        value <<= numShift
        Return Convert(value).ToString()
    End Function

    Public Function RightShift(ByVal value As Integer, ByVal numShift As Integer) As String
        value >>= numShift
        Return Convert(value).ToString()
    End Function

    Public Sub ShowBitExample()
        Dim byteSet As Byte() = {1, 2, 3, 4, 5}
        Dim bitSet As New BitArray(byteSet)

        For bits As Integer = 0 To bitSet.Count - 1
            Console.Write(bitSet.Get(bits) & " ")
            If (bits + 1) Mod 8 = 0 Then
                Console.WriteLine()
            End If
        Next
        Console.Read()
    End Sub

    Public Sub CustomShowBits()
        Dim binNumbers(7) As String

        Dim byteSet As Byte() = {1, 2, 3, 4, 5}
        Dim bitSet As New BitArray(byteSet)

        Dim bits As Integer = 0
        Dim binary As Integer = 7

        For i As Integer = 0 To bitSet.Count - 1
            If bitSet.Get(i) Then
                binNumbers(binary) = "1"
            Else
                binNumbers(binary) = "0"
            End If

            bits += 1
            binary -= 1

            If bits Mod 8 = 0 Then
                binary = 7
                bits = 0

                For index As Integer = 0 To 7
                    Console.Write(binNumbers(index))
                Next

                Console.WriteLine()
                Console.WriteLine()
            End If
        Next
        Console.Read()
    End Sub

    Public Sub PrimeBitArray()
        Dim number As Integer = Console.ReadLine()
        Dim bitSet As New BitArray(1024)
        Dim primes As String = BuildSieve(bitSet)

        If bitSet.Get(number) Then
            Console.WriteLine(number & " is a prime number")
        Else
            Console.WriteLine(number & " is not a prime number")
        End If
        Console.WriteLine(primes)
        Console.Read()
    End Sub

    Public Function BuildSieve(ByRef bits As BitArray) As String
        Dim i, j As Integer
        Dim primes As String = ""

        For i = 0 To bits.Count - 1
            bits.Set(i, 1)
        Next

        ' 1024의 제곱근까지 순차로 루프를 돌면서 배수들을 제거한다(체로 거른다)
        Dim lastBit As Integer = CInt(Math.Sqrt(bits.Count))
        For i = 2 To lastBit - 1
            If (bits.Get(i)) Then
                For j = 2 * i To bits.Count - 1 Step i
                    bits.Set(j, 0)
                Next
            End If
        Next

        ' 7개씩 끊어서 라인을 나누어 결과 문자열을 만든다.
        Dim counter As Integer = 0
        For i = 1 To bits.Count - 1
            If (bits.Get(i)) Then
                primes &= CStr(i)
                counter += 1

                If (counter Mod 7 = 0) Then
                    primes &= Constants.vbCrLf
                Else
                    primes &= Constants.vbTab
                End If
            End If
        Next

        Return primes
    End Function

End Module
