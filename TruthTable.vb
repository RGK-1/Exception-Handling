Module TruthTable
    Function myOR(ByVal userinput1 As Boolean, ByVal userinput2 As Boolean) As Boolean
        myOR = userinput1 Or userinput2

    End Function
    Function myAND(ByVal userinput1 As Boolean, ByVal userinput2 As Boolean) As Boolean
        myAND = userinput1 And userinput2

    End Function

    Function myNOT(ByVal userinput1 As Boolean) As Boolean
        myNOT = Not userinput1

    End Function

    Function myXOR(ByVal userinput1 As Boolean, ByVal userinput2 As Boolean) As Boolean
        myXOR = userinput1 Xor userinput2

    End Function

    Sub Main()

        AndTruthTable()
        OrTruthTable()
        NotTruthTable()
        XorTruthTable()
        NandTruthTable()
        NorTruthTable()


        Console.ReadLine()

    End Sub


    Sub AndTruthTable()
        Console.WriteLine("AND gate truth table")
        Console.WriteLine("{0}" + vbTab + "{1}" + vbTab + "{2}", "InputA", "inputB", "Output")
        For i As Integer = 0 To 1
            For j As Integer = 0 To 1
                Console.WriteLine("{0}" + vbTab + "{1}" + vbTab + "{2}", -1 * CInt(i = 1), -1 * CInt(j = 1), -1 * CInt(myAND(i = 1, j = 1)))
            Next j
        Next i
        Console.WriteLine()
    End Sub

    Sub OrTruthTable()
        Console.WriteLine("OR gate truth table")
        Console.WriteLine("{0}" + vbTab + "{1}" + vbTab + "{2}", "InputA", "inputB", "Output")
        For i As Integer = 0 To 1
            For j As Integer = 0 To 1
                Console.WriteLine("{0}" + vbTab + "{1}" + vbTab + "{2}", -1 * CInt(i = 1), -1 * CInt(j = 1), -1 * CInt(myOR(i = 1, j = 1)))
            Next j
        Next i
        Console.WriteLine()
    End Sub

    Sub NotTruthTable()
        Console.WriteLine("NOT gate truth table")
        Console.WriteLine("{0}" + vbTab + "{1}", "InputA", "Output")

        For j As Integer = 0 To 1
            Console.WriteLine("{0}" + vbTab + "{1}", -1 * CInt(j = 1), -1 * CInt(myNOT(j = 1)))
        Next j

        Console.WriteLine()
    End Sub

    Sub XorTruthTable()
        Console.WriteLine("XOR gate truth table")
        Console.WriteLine("{0}" + vbTab + "{1}" + vbTab + "{2}", "InputA", "inputB", "Output")
        For i As Integer = 0 To 1
            For j As Integer = 0 To 1
                Console.WriteLine("{0}" + vbTab + "{1}" + vbTab + "{2}", -1 * CInt(i = 1), -1 * CInt(j = 1), -1 * CInt(myXOR(i = 1, j = 1)))
            Next j
        Next i
        Console.WriteLine()
    End Sub

    Sub NandTruthTable()
        Console.WriteLine("NAND gate truth table")
        Console.WriteLine("{0}" + vbTab + "{1}" + vbTab + "{2}", "InputA", "inputB", "Output")
        For i As Integer = 0 To 1
            For j As Integer = 0 To 1
                Console.WriteLine("{0}" + vbTab + "{1}" + vbTab + "{2}", -1 * CInt(i = 1), -1 * CInt(j = 1), -1 * CInt(myNOT(myAND(i = 1, j = 1))))
            Next j
        Next i
        Console.WriteLine()

    End Sub

    Sub NorTruthTable()
        Console.WriteLine("NOR gate truth table")
        Console.WriteLine("{0}" + vbTab + "{1}" + vbTab + "{2}", "InputA", "inputB", "Output")
        For i As Integer = 0 To 1
            For j As Integer = 0 To 1
                Console.WriteLine("{0}" + vbTab + "{1}" + vbTab + "{2}", -1 * CInt(i = 1), -1 * CInt(j = 1), -1 * CInt(myNOT(myOR(i = 1, j = 1))))
            Next j
        Next i
        Console.WriteLine()
    End Sub
End Module