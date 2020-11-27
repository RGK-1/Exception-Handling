Imports System.IO
Module Calculator
    Sub Main()
        Console.WriteLine("Hello Welcome")

        Dim MenuOptions() As String = {"Multiply", "Divide", "Add", "Subtract"}

        Do
            Dim Menuresponse As Integer = Menu(MenuOptions)
            Console.Clear()
            If Menuresponse = MenuOptions.Count + 1 Then 'the last or extra option in the menu is to exit the program
                Exit Sub
            End If
            Select Case Menuresponse
                Case 1
                    Multiply()
                Case 2
                    Subtract()
                Case 3
                    Divide()
                Case 4
                    Add()

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

    Function Multiply()
        Console.WriteLine("Please Enter the number of integers you'd like to multiply")
        Dim ninteger As Integer = Console.ReadLine()
        'Dim i As Integer
        Dim Value() As Integer
        For i = 1 To ninteger
            Console.Write("Please enter value ", i)
            Dim input As Integer = Console.ReadLine()



        Next

    End Function

    Function Divide()

    End Function

    Function Add()

    End Function

    Function Subtract()

    End Function


End Module
