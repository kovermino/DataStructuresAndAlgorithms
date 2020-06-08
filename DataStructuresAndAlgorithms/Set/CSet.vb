Public Class CSet

    Private data As Hashtable

    Public Sub New()
        data = New Hashtable
    End Sub

    Public Sub Add(ByVal item As Object)
        If Not (data.ContainsValue(item)) Then
            data.Add(Hash(item), item)
        End If
    End Sub

    Public Function Hash(ByVal item As Object) As String
        Dim hashValue As Integer
        Dim s As String = CStr(item)
        For index As Integer = 0 To s.Length - 1
            hashValue += Asc(s.Chars(index))
        Next
        Return CStr(hashValue)
    End Function

    Public Sub Remove(ByVal item As Object)
        data.Remove(Hash(item))
    End Sub

    Public Function Size() As Integer
        Return data.Count
    End Function

    Public Function Union(ByVal aSet As CSet) As CSet
        Dim tempSet As New CSet
        Dim hashObject As Object
        For Each hashObject In data.Keys
            tempSet.Add(Me.data.Item(hashObject))
        Next
        For Each hashObject In aSet.data.Keys
            If (Not Me.data.ContainsKey(hashObject)) Then
                tempSet.Add(aSet.data.Item(hashObject))
            End If
        Next
        Return tempSet
    End Function

    Public Function Intersection(ByVal aSet As CSet) As CSet
        Dim tempSet As New CSet
        Dim hashObject As Object
        For Each hashObject In data.Keys
            If (aSet.data.ContainsKey(hashObject)) Then
                tempSet.Add(aSet.data.Item(hashObject))
            End If
        Next
        Return tempSet
    End Function

    Public Function IsSubsetOf(ByVal aSet As CSet) As Boolean
        If (Me.Size() > aSet.Size()) Then
            Return False
        Else
            For Each key As Object In Me.data.Keys
                If (Not (aSet.data.Contains(key))) Then
                    Return False
                End If
            Next
        End If
        Return True
    End Function

    Public Function Difference(ByVal aSet As CSet)
        Dim tempSet As New CSet
        For Each hashObject As Object In data.Keys
            If (Not (aSet.data.Contains(hashObject))) Then
                tempSet.Add(data.Item(hashObject))
            End If
        Next
        Return tempSet
    End Function

    Public Overrides Function ToString() As String
        Dim str As String = ""
        For Each key As Object In data.Keys
            str &= data.Item(key) & " "
        Next
        Return str
    End Function
End Class
