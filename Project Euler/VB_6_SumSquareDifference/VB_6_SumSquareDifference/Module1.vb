Option Strict On
Module Module1
    'PROBLEM #6
    'The sum Of the squares Of the first ten natural numbers Is,
    '1^2 + 2^2 + ... + 10^2 = 385
    'The square Of the sum Of the first ten natural numbers Is,
    '(1 + 2 + ... + 10)^2 = 55^2 = 3025
    'Hence the difference between the sum Of the squares Of the first ten natural numbers And the square Of the sum Is 3025 − 385 = 2640.
    'Find the difference between the sum Of the squares Of the first one hundred natural numbers And the square Of the sum.
    Sub Main()
        Dim dcmSumOfSquares As Decimal = 0
        Dim dcmSquareOfSums As Decimal = 0

        For i = 1 To 100
            dcmSumOfSquares += CDec(i ^ 2)
            dcmSquareOfSums += i
        Next
        dcmSquareOfSums = CDec(dcmSquareOfSums ^ 2)
        Console.WriteLine("Sum of Squares: " & dcmSumOfSquares)
        Console.WriteLine("Square of Sum: " & dcmSquareOfSums)
        Console.WriteLine("Difference: " & 0 - (dcmSumOfSquares - dcmSquareOfSums))             '0 minus to make it positive value
        Console.ReadLine()
    End Sub

End Module
