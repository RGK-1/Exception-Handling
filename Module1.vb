Imports System.IO
Imports System.Math
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text

Imports System.Text.ASCIIEncoding


Module Module1


    Sub MySubroutine1()
        Dim Output As String = ("Printing all Logic Gates")
        TruthTable.Main()

        Console.WriteLine(Output)
        WriteToLog(Output)
        Console.ReadKey()
    End Sub
    Sub MySubroutine2()
        Dim Output As String = ("Clearing Text File")
        Console.WriteLine(Output)
        WriteToLog(Output)
        Dim path As String = "C:\Users\ryakel\source\repos\Exception Handling\bin\Debug\Log.txt"
        System.IO.File.WriteAllText(Path, "")
        Console.ReadKey()
    End Sub
    Sub ReadBackLog()
        Using sr As StreamReader = New StreamReader("Decrypted.txt")
            Dim Line As String

            Line = sr.ReadLine()
            While Line <> Nothing
                Console.WriteLine(Line)
                Line = sr.ReadLine()
            End While
            Console.ReadLine()

        End Using
    End Sub

    Sub WriteToLog(ByRef Input As String)
        Using sw As StreamWriter = New StreamWriter("Decrytped.txt", True)
            sw.WriteLine("at " & CStr(Minute(Now)) & " of hour " & CStr(Hour(Now) & " of the day " & CStr(Day(Now)) & " " & CStr(Month(Now)) & " " & CStr(Year(Now))))
            sw.WriteLine(Input)
        End Using
    End Sub

    Sub Main()
        Dim MenuOptions() As String = {"Print All Logic Gates", "Clear Log File", "Dice Game", "Read Back Log", "Calculator", "WordCount"}
        'Decryption.Main123()
        Dim Random2 As Integer
        Random2 = RandomiseKey()
        Console.WriteLine(Random2)





        Do
            Dim Menuresponse As Integer = Menu(MenuOptions)
            Console.Clear()
            If Menuresponse = MenuOptions.Count + 1 Then 'the last or extra option in the menu is to exit the program



                Exit Sub

            End If
            Select Case Menuresponse
                Case 1
                    MySubroutine1()
                Case 2
                    MySubroutine2()
                Case 3
                    DiceGame.Main()
                Case 4
                    ReadBackLog()
                Case 5
                    Calculator.Main()
                Case 6
                    WordCount.main()


            End Select
        Loop
    End Sub

    Function Menu(MenuOptions As String()) As Integer
        Console.Clear()
        Dim Output As String = ("---MENU---")
        Console.WriteLine(Output)
        WriteToLog(Output)
        Console.WriteLine()
        For i = 0 To MenuOptions.Length - 1 'print each of the standard menu items
            Output = (i + 1 & " : " & MenuOptions(i))
            Console.WriteLine(Output)
            WriteToLog(Output)
        Next

        Output = (MenuOptions.Length + 1 & " : Exit Program")
        WriteToLog(Output)
        Console.WriteLine(Output) 'add an extra menu item to exit the program
        Console.WriteLine()
        Return ChooseMenuOption(MenuOptions.Length + 1)
    End Function

    Function ChooseMenuOption(NumberOfOptions As Integer)
        Dim Response As Integer = -1
        Dim Output As String
        Do While Response = -1 'response of -1 means that we haven't suceeded in getting a proper menu choice
            Output = ("Choose an item from: 1 to " & NumberOfOptions)
            Console.WriteLine(Output)
            WriteToLog(Output)
            Try
                Dim Input As Integer = Console.ReadLine() 'get the users input and try to cast it to an integer
                WriteToLog(Input)
                If Input > 0 And Input <= NumberOfOptions Then 'if this suceeds then check it's in the right range
                    Response = Input
                Else
                    Err.Raise(1)
                End If
            Catch ex As Exception
                Output = ("Please only enter an integer between 1 & " & NumberOfOptions)
                Console.WriteLine(Output)
                WriteToLog(Output)
            Finally
                Console.WriteLine()
            End Try
        Loop
        Return Response
    End Function

    Function RandomiseKey()
        Dim Random1 As Integer
        Dim random As New Random
        Random1 = random.Next(10000000, 99999999)
        Return Random1


    End Function

    Sub Encryption(ByVal Random1 As Integer)
        Try

            Dim myDESProvider As DESCryptoServiceProvider = New DESCryptoServiceProvider()
            myDESProvider.Key = ASCIIEncoding.ASCII.GetBytes(Random1)
            myDESProvider.IV = ASCIIEncoding.ASCII.GetBytes(Random1)
            Dim myICryptoTransform As ICryptoTransform = myDESProvider.CreateEncryptor(myDESProvider.Key, myDESProvider.IV)
            Dim ProcessFileStream As FileStream = New FileStream("Decrypted.txt", FileMode.Open, FileAccess.Read)
            Dim ResultFileStream As FileStream = New FileStream("Encrypted.txt", FileMode.Create, FileAccess.Write)
            Dim myCryptoStream As CryptoStream = New CryptoStream(ResultFileStream, myICryptoTransform, CryptoStreamMode.Write)
            Dim bytearrayinput(ProcessFileStream.Length - 1) As Byte
            ProcessFileStream.Read(bytearrayinput, 0, bytearrayinput.Length)
            myCryptoStream.Write(bytearrayinput, 0, bytearrayinput.Length)
            myCryptoStream.Close()
            ProcessFileStream.Close()
            ResultFileStream.Close()

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        End Try
        My.Computer.FileSystem.DeleteFile("C:\Users\ryakel\source\repos\Exception Handling\bin\Debug\Decrypted.txt")
        Console.ReadLine()


    End Sub

    Sub Decryption()
        'Try
        '    Dim myDESProvider As DESCryptoServiceProvider = New DESCryptoServiceProvider()

        '    myDESProvider.Key = ASCIIEncoding.ASCII.GetBytes("12345678")
        '    myDESProvider.IV = ASCIIEncoding.ASCII.GetBytes("12345678")

        '    Dim DecryptedFile As FileStream = New FileStream("Encrypted.txt", FileMode.Open, FileAccess.Read)
        '    Dim myICryptoTransform As ICryptoTransform = myDESProvider.CreateDecryptor(myDESProvider.Key, myDESProvider.IV)
        '    Dim myCryptoStream As CryptoStream = New CryptoStream(DecryptedFile, myICryptoTransform, CryptoStreamMode.Read)

        '    Using myDecStreamReader As New StreamReader(myCryptoStream)
        '        Using myDecStreamWriter As New StreamWriter("Decrypted.txt")

        '            myDecStreamWriter.Write(myDecStreamReader.ReadToEnd())

        '            myCryptoStream.Close()
        '            myDecStreamReader.Close()
        '            myDecStreamWriter.Close()
        '        End Using

        '    End Using
        'Catch ex As Exception

        '    Console.WriteLine(ex.ToString())

        'End Try
        'My.Computer.FileSystem.DeleteFile("C:\Users\ryakel\source\repos\Exception Handling\bin\Debug\Encrypted.txt")
    End Sub

End Module

