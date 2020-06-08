Public Class SkipNode

    Public key As Integer
    Public value As Object
    Public link() As SkipNode

    Public Sub New(ByVal level As Integer, ByVal key As Integer, ByVal value As Object)
        Me.key = key
        Me.value = value
        ReDim link(level)
    End Sub

End Class
