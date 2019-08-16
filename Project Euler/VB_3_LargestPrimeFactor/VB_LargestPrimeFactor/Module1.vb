Module Module1

    Sub Main()
        'PROBLEM #3
        'The prime factors Of 13195 are 5, 7, 13 And 29.
        'What Is the largest prime factor of the number 600851475143 ?

        Dim intNumber As Decimal = 600851475143
        Dim intTrial As Decimal = Math.Round(intNumber ^ (1 / 2))

        While intTrial > 1
            If intNumber Mod intTrial = 0 Then
                Console.WriteLine("Testing " & intTrial & " if prime...")
                For i = 2 To Math.Round(intTrial ^ (1 / 2))
                    If intTrial Mod i = 0 Then
                        Console.WriteLine("Factor " & i & " found, therefore not prime.")
                        Exit For
                    End If
                    If i = Math.Round(intTrial ^ (1 / 2)) Then
                        Console.WriteLine("No factors found, therefore " & intTrial & " is the largest prime factor")
                        Exit While
                    End If
                Next
            End If
            intTrial -= 1
        End While
        Console.ReadLine()

    End Sub

End Module
