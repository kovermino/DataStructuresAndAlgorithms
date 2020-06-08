Public Class ListNode
    Public Element As Object
    Public Link As ListNode

    Public Sub New()
        Element = Nothing
        Link = Nothing
    End Sub

    Public Sub New(theElement As Object)
        Element = theElement
        Link = Nothing
    End Sub
End Class
