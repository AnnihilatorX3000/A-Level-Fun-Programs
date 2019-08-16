Option Strict On
Module Module1
    'PROBLEM #5
    '2520 Is the smallest number that can be divided by each of the numbers from 1 to 10 without any remainder.
    'What Is the smallest positive number that Is evenly divisible by all of the numbers from 1 to 20?
    Sub Main()
        Dim dcmTest As Decimal = 2520     'Just in case number is humungous
        Dim intCounter As Integer = 1
        Dim blnFound As Boolean = False

        Console.WriteLine("Searching for the faggot...")
        Do
            For i = 2 To 20
                If (dcmTest Mod i) = 0 Then
                    intCounter += 1
                End If
            Next
            If intCounter = 20 Then         '2 to 20 INCLUSIVE
                Console.WriteLine("AHA! GOT YOU NUMBER " & dcmTest)
                blnFound = True
            Else
                Console.WriteLine("Sorry bout that number " & dcmTest)
                intCounter = 1
                dcmTest += 2520
            End If
        Loop While blnFound = False

        Console.ReadLine()
    End Sub

End Module
