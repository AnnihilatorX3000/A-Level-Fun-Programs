Option Strict On
Module Module1
    'PROBLEM #7
    'By listing the first six prime numbers: 2, 3, 5, 7, 11, And 13, we can see that the 6th prime Is 13.
    'What Is the 10001st prime number?
    Sub Main()
        'Screw it, slow way it is
        Dim intTestPrime As Integer = 2
        Dim intFactors As Integer = 0
        Dim intPrimeNumber As Integer = 0
        Dim intToRoot As Integer = 2

        Console.WriteLine("Primes found: ")
        Do
            intToRoot = CInt(Math.Ceiling(Math.Sqrt(intTestPrime)))
            For i = 1 To intToRoot
                If intTestPrime Mod i = 0 Then
                    intFactors += 1
                End If
                If intFactors > 1 Then
                    Exit For
                End If
            Next
            If intFactors = 1 Or intTestPrime = 2 Then                'Making an exception for 2
                intPrimeNumber += 1
                Console.WriteLine("Prime no." & intPrimeNumber & " = " & intTestPrime)
            End If
            intFactors = 0
            intTestPrime += 1
        Loop Until intPrimeNumber = 10001

        Console.WriteLine(intTestPrime - 1)
        Console.ReadLine()
    End Sub

End Module
