Module BinaryToDenary

    Sub Main()
        Dim DenaryNumber As Integer
        Dim Convertnum As Integer

        Console.WriteLine("Please enter your denary number")
        DenaryNumber = Console.ReadLine()
        While Not Convertnum = 0
            Convertnum = Convertnum + (DenaryNumber Mod 2)
        End While

        Console.WriteLine(Convertnum)
        Console.ReadLine()

    End Sub


End Module

