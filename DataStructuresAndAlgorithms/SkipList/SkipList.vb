Public Class SkipList

    Private maxLevel As Integer
    Private level As Integer
    Private header As SkipNode
    Private probability As Single
    Private Const NIL As Integer = Int32.MaxValue
    Private Const PROB As Single = 0.5

    Public Sub New(ByVal maxNodes As Long)
        Me.New(PROB, CInt(Math.Ceiling(Math.Log(maxNodes) / Math.Log(1 / PROB)) - 1))
    End Sub

    Private Sub New(ByVal probable As Single, ByVal maxLevel As Integer)
        Me.probability = probable
        Me.maxLevel = maxLevel
        level = 0
        header = New SkipNode(maxLevel, 0, Nothing)
        Dim nilElement As SkipNode = New SkipNode(maxLevel, NIL, Nothing)
        For i As Integer = 0 To maxLevel - 1
            header.link(i) = nilElement
        Next
    End Sub

    Public Sub Insert(ByVal key As Integer, ByVal value As Object)
        Dim update(maxLevel) As SkipNode
        Dim cursor As SkipNode = header

        For i As Integer = level To 0 Step -1
            While (cursor.link(i).key < key)
                cursor = cursor.link(i)
            End While
            update(i) = cursor
        Next

        cursor = cursor.link(0)

        If (cursor.key = key) Then
            cursor.value = value
        Else
            Dim newLevel As Integer = getRandomLevel()
            If (newLevel > level) Then
                For i = level + 1 To newLevel - 1
                    update(i) = header
                Next
                level = newLevel
            End If
            cursor = New SkipNode(newLevel, key, value)
            For i As Integer = 0 To newLevel - 1
                cursor.link(i) = update(i).link(i)
                update(i).link(i) = cursor
            Next
        End If
    End Sub

    Private Function getRandomLevel() As Integer
        Dim ran As New Random
        Dim newLevel As Integer = 0
        While (newLevel < maxLevel And CInt(Int((1 * Rnd()) + 0)) < probability)
            newLevel += 1
        End While
        Return newLevel
    End Function

    Public Sub Delete(ByVal key As Integer)
        Dim update(maxLevel + 1) As SkipNode
        Dim cursor As SkipNode = header
        For i As Integer = level To 0 Step -1
            While (cursor.link(i).key < key)
                cursor = cursor.link(i)
            End While
            update(i) = cursor
        Next
        cursor = cursor.link(0)
        If (cursor.key = key) Then
            For i As Integer = 0 To level - 1
                If (update(i).link(i) Is cursor) Then
                    update(i).link(i) = cursor.link(i)
                End If
            Next
            While (level > 0 And header.link(level).key = NIL)
                level -= 1
            End While
        End If
    End Sub

    Public Function Search(ByVal key As Integer) As Object
        Dim cursor As SkipNode = header
        For i As Integer = level - 1 To 0 Step -1
            Dim nextElement As SkipNode = cursor.link(i)
            While (nextElement.key < key)
                cursor = nextElement
                nextElement = cursor.link(i)
            End While
        Next
        cursor = cursor.link(0)
        If (cursor.key = key) Then
            Return cursor.value
        Else
            Return "Object not found"
        End If
    End Function
End Class
