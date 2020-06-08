Public Class RBNode

    Public element As String
    Public left As RBNode
    Public right As RBNode
    Public color As Integer

    Const RED As Integer = 0
    Const BLACK As Integer = 1

    Public Sub New(ByVal element As String, ByVal left As RBNode, ByVal right As RBNode)
        Me.element = element
        Me.left = right
        Me.right = right
        Me.color = BLACK
    End Sub

    Public Sub New(ByVal element As String)
        Me.element = element
    End Sub

End Class
