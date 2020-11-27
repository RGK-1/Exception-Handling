'Imports System.Security
'Imports System.Security.Cryptography
'Imports System.Text
'Imports System.IO
'Imports System.Text.ASCIIEncoding

'Module Encryption123

'    Sub Main123()
'        Try

'            Dim myDESProvider As DESCryptoServiceProvider = New DESCryptoServiceProvider()
'            myDESProvider.Key = ASCIIEncoding.ASCII.GetBytes(Random1)
'            myDESProvider.IV = ASCIIEncoding.ASCII.GetBytes("12345678")
'            Dim myICryptoTransform As ICryptoTransform = myDESProvider.CreateEncryptor(myDESProvider.Key, myDESProvider.IV)
'            Dim ProcessFileStream As FileStream = New FileStream("Decrypted.txt", FileMode.Open, FileAccess.Read)
'            Dim ResultFileStream As FileStream = New FileStream("Encrypted.txt", FileMode.Create, FileAccess.Write)
'            Dim myCryptoStream As CryptoStream = New CryptoStream(ResultFileStream, myICryptoTransform, CryptoStreamMode.Write)
'            Dim bytearrayinput(ProcessFileStream.Length - 1) As Byte
'            ProcessFileStream.Read(bytearrayinput, 0, bytearrayinput.Length)
'            myCryptoStream.Write(bytearrayinput, 0, bytearrayinput.Length)
'            myCryptoStream.Close()
'            ProcessFileStream.Close()
'            ResultFileStream.Close()

'        Catch ex As Exception
'            Console.WriteLine(ex.Message)
'        End Try
'        My.Computer.FileSystem.DeleteFile("C:\Users\ryakel\source\repos\Exception Handling\bin\Debug\Decrypted.txt")
'        Console.ReadLine()
'    End Sub



'End Module
