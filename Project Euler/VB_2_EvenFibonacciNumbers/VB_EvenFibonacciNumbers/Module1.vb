﻿Option Strict On
Module Module1

    Sub Main()
        'PROBLEM #2
        'Each New term in the Fibonacci sequence Is generated by adding the previous two terms. By starting with 1 And 2, the first 10 terms will be
        '1, 2, 3, 5, 8, 13, 21, 34, 55, 89, ...
        'By considering the terms In the Fibonacci sequence whose values Do Not exceed four million, find the sum of the even-valued terms.

        'For Fibonacci sequence
        Dim intFibonacci1 As Decimal = 0
        Dim intFibonacci2 As Decimal = 1
        Dim intFibonacciCurrent As Decimal = 0
        'For totaling evens
        Dim intEvens As Decimal = 0

        Do
            'Ignore on first loop
            If intFibonacciCurrent Mod 2 = 0 Then
                intEvens += intFibonacciCurrent
            End If
            'SHIFT FIBONACCI UP
            intFibonacciCurrent = intFibonacci1 + intFibonacci2
            intFibonacci1 = intFibonacci2
            intFibonacci2 = intFibonacciCurrent
        Loop While intFibonacciCurrent < 4000000

        Console.WriteLine(intEvens)
        Console.ReadLine()
    End Sub

End Module
