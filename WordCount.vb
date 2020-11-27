Imports System.IO

Module WordCount
    Sub main()
        Using sr As StreamReader = New StreamReader("EnglishSample.txt")
            Dim Line As String
            Dim TextArray As ArrayList = New ArrayList


            Line = sr.ReadLine()
            While Line <> Nothing
                TextArray.Add(Line)

                Line = sr.ReadLine()

            End While
            'Dim Word As String() = sr.split(New Char() {" "}c)
            Dim Words As String()
            Dim CurrentLine As String
            Dim count As Integer = TextArray.Count
            Console.WriteLine(count)

            For i = 0 To TextArray.Count - 1
                CurrentLine = TextArray(i)
                Words = CurrentLine.Split(" "c)



            Next
            Dim test As String
            'test = Words(1)


            Console.WriteLine(Line)

            Console.ReadLine()

        End Using
    End Sub



End Module
