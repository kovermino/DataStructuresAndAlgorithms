Public Class BSet

    Private data As BitArray

    Public Sub New()
        data = New BitArray(5)
    End Sub

    Public Sub Add(ByVal item As Integer)
        data(item) = True
    End Sub

    Public Function IsMember(ByVal item As Integer) As Boolean
        Return data(item)
    End Function

    Public Sub Remove(ByVal item As Integer)
        data(item) = False
    End Sub

    Public Function Union(ByVal aSet As BSet) As BSet
        Dim tempSet As New BSet
        For index As Integer = 0 To data.Count - 1
            tempSet.data(index) = Me.data(index) Or aSet.data(index)
        Next
        Return tempSet
    End Function

    Public Function Intersection(ByVal aSet As BSet) As BSet
        Dim tempSet As New BSet
        For index As Integer = 0 To data.Count - 1
            tempSet.data(index) = Me.data(index) And aSet.data(index)
        Next
        Return tempSet
    End Function

    Public Function Difference(ByVal aSet As BSet) As BSet
        Dim tempSet As New BSet
        For index As Integer = 0 To Me.data.Count - 1
            tempSet.data(index) = (Me.data(index) And Not aSet.data(index))
        Next
        Return tempSet
    End Function

    Public Function IsSubsetOf(ByVal aSet As BSet) As Boolean
        Dim tempSet As New BSet
        For index As Integer = 0 To data.Count - 1
            If (Me.data(index) And Not aSet.data(index)) Then
                Return False
            End If
        Next
        Return True
    End Function

    Public Overrides Function ToString() As String
        Dim str As String = ""
        For index As Integer = 0 To data.Count - 1
            If (data(index)) Then
                str &= index
            End If
        Next
        Return str
    End Function

End Class
