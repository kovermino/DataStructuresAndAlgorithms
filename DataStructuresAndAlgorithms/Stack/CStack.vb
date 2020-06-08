Public Class CStack

    Private p_index As Integer
    Private list As New ArrayList()

    Public Sub New()
        p_index = -1
    End Sub

    ReadOnly Property Count()
        Get
            Return list.Count
        End Get
    End Property

    Public Sub Push(ByVal value As Object)
        list.Add(value)
        p_index += 1
    End Sub

    Public Function Pop() As Object
        Dim obj As Object = list.Item(p_index)
        list.RemoveAt(p_index)
        p_index -= 1
        Return obj
    End Function

    Public Sub Clear()
        list.Clear()
        p_index = -1
    End Sub

    Public Function Peek() As Object
        Return list.Item(p_index)
    End Function

End Class
