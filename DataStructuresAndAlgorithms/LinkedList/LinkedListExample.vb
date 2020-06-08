Imports System
Imports Microsoft.VisualBasic

Module LinkedListExample

    Sub LinkedListTest()
        Dim myList As New ItLinkedList
        Dim iter As New ListIter(myList)
        Dim choice As String
        Dim value As String

        Try
            iter.InsertAfter("David")
            iter.InsertAfter("Mike")
            iter.InsertAfter("Raymond")
            iter.InsertAfter("Berica")
            iter.InsertAfter("Jennifer")
            iter.InsertBefore("Donny")
            iter.InsertAfter("Mike")
            iter.InsertBefore("Terrill")
            iter.InsertBefore("Mayo")

            While (True)
                Console.WriteLine("(n) Move to next node")
                Console.WriteLine("(g) Get value in current" & "node")
                Console.WriteLine("(r) Reset iterator")
                Console.WriteLine("(s) Show complete list")
                Console.WriteLine("(a) Insert after")
                Console.WriteLine("(b) Insert before")
                Console.WriteLine("(c) Clear the screen")
                Console.WriteLine("(x) Exit")
                Console.WriteLine()
                Console.Write("Enter your choice: ")
                choice = Console.ReadLine()
                choice = choice.ToLower()
                Select Case choice
                    Case "n"
                        If (Not myList.IsEmpty()) And (Not iter.AtEnd) Then
                            iter.NextLink()
                        Else
                            Console.WriteLine("Can't move to next link")
                        End If
                    Case "g"
                        If (Not myList.IsEmpty()) Then
                            Console.WriteLine("Element: " & iter.GetCurrent.Element)
                        Else
                            Console.WriteLine("List is empty")
                        End If
                    Case "r"
                        iter.Reset()
                    Case "s"
                        If (Not myList.IsEmpty()) Then
                            myList.ShowList()
                        Else
                            Console.WriteLine("List is empty")
                        End If
                    Case "a"
                        Console.WriteLine()
                        Console.Write("Enter value to insert: ")
                        value = Console.ReadLine()
                        iter.InsertBefore(value)
                    Case "c"
                        Console.Clear()
                    Case "x"
                        End
                End Select
            End While
        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
    End Sub

End Module