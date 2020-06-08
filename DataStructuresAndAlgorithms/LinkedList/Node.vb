Public Class Node

    Public Element As Object
    Public Flink As Node
    Public Blink As Node

    Public Sub New()
        Element = ""
        Flink = Nothing
        Blink = Nothing
    End Sub

    Public Sub New(theElement As Object)
        Element = theElement
        Flink = Nothing
        Blink = Nothing
    End Sub
End Class
