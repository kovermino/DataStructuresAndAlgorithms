Imports System.IO
Public Class IPAddresses
    Inherits DictionaryBase

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal txtFile As String)
        MyBase.New()
        Dim line As String
        Dim words() As String
        Using infile As StreamReader = File.OpenText(txtFile)
            While (infile.Peek <> -1)
                line = infile.ReadLine()
                words = line.Split(","c)
                Me.InnerHashtable.Add(words(0), words(1))
            End While
        End Using
    End Sub

    Public Sub Add(ByVal name As String, ByVal ip As String)
        MyBase.InnerHashtable.Add(name, ip)
    End Sub

    Public Function Item(ByVal name As String) As String
        Return CStr(MyBase.InnerHashtable.Item(name))
    End Function

    Public Sub Remove(ByVal name As String)
        MyBase.InnerHashtable.Remove(name)
    End Sub

End Class
