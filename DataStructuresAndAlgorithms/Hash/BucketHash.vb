Public Class BucketHash

    Private Const SIZE As Integer = 101
    Private data() As ArrayList

    Public Sub New()
        ReDim data(SIZE)
        For index As Integer = 0 To SIZE - 1
            data(index) = New ArrayList(4)
        Next
    End Sub

    Private Function Hash(ByVal s As String) As Integer
        Dim tot As Long
        For index As Integer = 0 To s.Length - 1
            tot += 37 * tot + Asc(s.Chars(index))
        Next
        tot = tot Mod data.GetUpperBound(0)
        If (tot < 0) Then
            tot += data.GetUpperBound(0)
        End If
        Return CInt(tot)
    End Function

    Public Sub Insert(ByVal item As String)
        Dim hash_value As Integer = Hash(item)
        If Not (data(hash_value).Contains(item)) Then
            data(hash_value).Add(item)
        End If
    End Sub

    Public Sub Remove(ByVal item As String)
        Dim hash_value As Integer = Hash(item)
        If (data(hash_value).Contains(item)) Then
            data(hash_value).Remove(item)
        End If
    End Sub

End Class
