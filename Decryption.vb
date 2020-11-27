Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Imports System.IO
Imports System.Text.ASCIIEncoding

Module Decryption
    Sub Main123()
        Try
            Dim myDESProvider As DESCryptoServiceProvider = New DESCryptoServiceProvider()

            myDESProvider.Key = ASCIIEncoding.ASCII.GetBytes("12345678")
            myDESProvider.IV = ASCIIEncoding.ASCII.GetBytes("12345678")

            Dim DecryptedFile As FileStream = New FileStream("Encrypted.txt", FileMode.Open, FileAccess.Read)
            Dim myICryptoTransform As ICryptoTransform = myDESProvider.CreateDecryptor(myDESProvider.Key, myDESProvider.IV)
            Dim myCryptoStream As CryptoStream = New CryptoStream(DecryptedFile, myICryptoTransform, CryptoStreamMode.Read)

            Using myDecStreamReader As New StreamReader(myCryptoStream)
                Using myDecStreamWriter As New StreamWriter("Decrypted.txt")

                    myDecStreamWriter.Write(myDecStreamReader.ReadToEnd())

                    myCryptoStream.Close()
                    myDecStreamReader.Close()
                    myDecStreamWriter.Close()
                End Using

            End Using
        Catch ex As Exception

            Console.WriteLine(ex.ToString())

        End Try
        My.Computer.FileSystem.DeleteFile("C:\Users\ryakel\source\repos\Exception Handling\bin\Debug\Encrypted.txt")
    End Sub
End Module
