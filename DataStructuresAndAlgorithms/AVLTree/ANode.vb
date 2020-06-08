Public Class ANode
    Implements IComparable

    Public element As Object
    Public left As ANode
    Public right As ANode
    Public height As Integer

    Public Sub New(ByVal data As Object, ByVal lt As ANode, ByVal rt As ANode)
        element = data
        left = lt
        right = rt
        height = 0
    End Sub

    Public Function CompareTo(obj As Object) As Integer Implements IComparable.CompareTo
        Return Me.element.compareto(obj.element)
    End Function

    Public ReadOnly Property getHeight() As Integer
        Get
            If Me Is Nothing Then
                Return -1
            Else
                Return Me.height
            End If
        End Get
    End Property
End Class
