Module DictionaryExample

    Sub IPAddressesTest()
        Dim myIPs As New IPAddresses
        myIPs.Add("Mike", "192.155.12.1")
        myIPs.Add("David", "192.155.12.2")
        myIPs.Add("Bernica", "192.155.12.3")

        Console.WriteLine("There are " & myIPs.Count() & " IP addresses.")
        Console.WriteLine("David's ip: " & myIPs.Item("David"))
        myIPs.Clear()
        Console.WriteLine("There are " & myIPs.Count() & " IP addresses.")
        Console.Read()
    End Sub

    Sub IPAddressesTest2()
        Dim myIPs As New IPAddresses("c:\ips.txt")
        Dim ips(myIPs.Count - 1) As DictionaryEntry
        myIPs.CopyTo(ips, 0)

        For index As Integer = 0 To ips.GetUpperBound(0)
            Console.WriteLine(ips(index).Key)
            Console.WriteLine(ips(index).Value)
        Next
    End Sub

    Sub SortedListTest()
        Dim myIPs As New SortedList
        myIPs.Add("Mike", "192.155.12.1")
        myIPs.Add("David", "192.155.12.2")
        myIPs.Add("Bernica", "192.155.12.3")

        For Each key As Object In myIPs.Keys
            Console.WriteLine("Name: " & key & Constants.vbTab & "IP: " & myIPs.Item(key))
        Next
        Console.Read()
    End Sub

End Module
