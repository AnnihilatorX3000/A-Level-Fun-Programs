Option Strict On
Module Module1
    'Problem 1
    'If we list all the natural numbers below 10 that are multiples Of 3 Or 5, we Get 3, 5, 6 And 9. The sum Of these multiples Is 23.
    'Find the sum Of all the multiples Of 3 Or 5 below 1000.

    Sub Main()
        Dim Threes As Decimal = 0
        Dim Fives As Decimal = 0
        Dim ThreeFives As Decimal = 0

        For i = 1 To 333
            Threes += (3 * i)
        Next
        For i = 1 To 199
            Fives += (5 * i)
        Next
        For i = 1 To 66
            ThreeFives += (15 * i)
        Next

        Console.WriteLine(Threes + Fives - ThreeFives)
        Console.ReadLine()
    End Sub

End Module
