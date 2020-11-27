
Imports System.IO
    Imports System.Math
    Imports System.Runtime.CompilerServices

    Module DiceGame
        Class FreqArray
            Private freq(10000) As Integer

            Public Function GetFreq(ByVal i As Integer) As Integer
                Return freq(i)
            End Function

            Public Function MeanScore() As Double
                Dim sumfreq As Integer
                For i As Integer = 1 To freq.Count - 1
                    If freq(i) > 0 Then
                        sumfreq += (i * freq(i))
                    End If
                Next
                Return (sumfreq / Me.countscores)
            End Function

            Public Function countscores() As Integer
                Dim countscore As Integer
                For i As Integer = 1 To freq.Count - 1
                    If freq(i) > 0 Then
                        countscore += freq(i)
                    End If
                Next
                Return countscore
            End Function

            Public Function Sigma() As Double
                Dim i As Integer
                Dim variance As Double
                For i = 1 To freq.Count - 1
                    variance += (freq(i) * (Me.MeanScore - i) ^ 2) / Me.countscores
                Next
                Sigma = Sqrt(variance)
                Return Sigma
            End Function

            Public Sub Addfreq(ByVal score As Integer)
                freq(score) = freq(score) + 1
            End Sub


            Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
                ' by making Generator static, we preserve the same instance '
                ' (i.e., do not create new instances with the same seed over and over) '
                ' between calls '
                Static Generator As System.Random = New System.Random()
                Return Generator.Next(Min, Max)
            End Function


            Public Function ThrowDice(ByRef sides As Integer) As Integer
                ThrowDice = GetRandom(1, sides)
            End Function

            Public Sub PlayGame(ByRef N As Integer, ByRef Sides As Integer, ByRef players As Integer)
                'Create the raw data in DiceThrows file
                Dim scores As New List(Of Integer)
                Dim ttotal As Integer
                Dim thisthrow As Integer
                Using sw As StreamWriter = New StreamWriter("DiceThrows.txt")
                    For p As Integer = 0 To players - 1
                        ttotal = 0
                        'Console.Write("Player {0} scores: ", CStr(p))
                        For pn As Integer = 0 To N - 1
                            thisthrow = ThrowDice(Sides)
                            scores.Add(thisthrow)
                            ttotal += thisthrow

                        Next pn
                        Me.Addfreq(ttotal)
                        For Each score In scores
                            sw.Write((CStr(score)) & " ")
                        Next

                        scores.Clear()
                        sw.WriteLine()
                    Next p
                End Using
            End Sub

        End Class






        Sub readgamefile(ByRef N As Integer)
            'Read in the data from file
            Dim throwline As String = " "
            Dim MyGame As New List(Of String())
            Dim playerscore = New List(Of Integer)

            Using sr As StreamReader = New StreamReader("DiceThrows.txt")
                throwline = sr.ReadLine()
                Do While (throwline <> Nothing)
                    MyGame.Add(throwline.Split(" "))
                    throwline = sr.ReadLine()
                Loop
            End Using

            'recast the array of strings into an array of integers
            Dim MyGameArray(MyGame.Count - 1, N) As Integer
            For i As Integer = 0 To MyGame.Count - 1
                For j As Integer = 0 To N - 1
                    MyGameArray(i, j) = CInt(MyGame(i)(j))
                Next
            Next
        End Sub



        Sub Main()
            Dim throws As Integer = 10
            Dim dicesides As Integer = 6
            Dim players As Integer = 10
            Dim MyFreqArray As New FreqArray
            Dim mySigma As New Double
            Dim myMean As Double
            Console.WriteLine("Number of players {0}", players)
            Console.WriteLine("Number of dice sides {0}", dicesides)
            Console.WriteLine("Number of throws per player {0}", throws)
            MyFreqArray.PlayGame(throws, dicesides + 1, players)    'throws, dicesides, players
            mySigma = MyFreqArray.Sigma
            myMean = MyFreqArray.MeanScore
            Dim mycumulativetotal As Integer
            Using dw As StreamWriter = New StreamWriter("StandardScores.txt")
                For i = 1 To (throws * dicesides) - 0
                    If MyFreqArray.GetFreq(i) > 0 Then
                        mycumulativetotal += MyFreqArray.GetFreq(i)
                        Console.WriteLine("Score {0}, Freq. {1}, StandardScore {2}, Confidence {3}", i, MyFreqArray.GetFreq(i), Round((i - myMean) / mySigma, 2), 100 * Round(mycumulativetotal / MyFreqArray.countscores, 2))
                        dw.WriteLine("Score {0}, Freq. {1}, StandardScore {2}, Confidence {3}", i, MyFreqArray.GetFreq(i), Round((i - myMean) / mySigma, 2), 100 * Round(mycumulativetotal / MyFreqArray.countscores, 2))
                    End If
                Next i
            End Using

            Console.WriteLine()
            Console.WriteLine("Meanscore {0} +/- {1}", Round(myMean, 2), Round(mySigma, 2))

            Console.WriteLine()
            Console.WriteLine("Countcore {0}", Round(MyFreqArray.countscores, 2))

            Console.ReadKey()
        End Sub

    End Module

