Option Strict On
Module Module1
    'PROBLEM #4
    'A palindromic number reads the same both ways. The largest palindrome made from the product Of two 2-digit numbers Is 9009 = 91 × 99.
    'Find the largest palindrome made from the product of two 3-digit numbers.

    Sub Main()
        'With two 3-digit numbers, largest result is 6 digits: 999 x 999 = 998001
        'Smallest is 100 x 100 = 10000   <- 5-digits will never be a palindrome 

        Dim dcmTestProduct As Decimal = 0
        Dim intIntegerComponent As Integer = 0
        Dim arrForReverse() As Char
        Dim strReverseTemp As String = ""
        Dim dcmReversed As Decimal = 0
        Dim intTemp As Decimal = 0
        Dim intLargest As Decimal = 0

        Console.WriteLine("Possible answers")
        For i = 999 To 100 Step -1S
            For j = 999 To 100 Step -1S
                dcmTestProduct = i * j    'Note: No need to check for 6-digits as it won't even make it there
                intIntegerComponent = CInt(Math.Floor(dcmTestProduct / 1000))      '3-Digits for integer component, other 3 for decimal

                arrForReverse = CStr(intIntegerComponent).ToCharArray        'Switcheroo for Palindrome Decimal Part
                For k = (arrForReverse.Length - 1) To 0 Step -1
                    strReverseTemp = strReverseTemp & arrForReverse(k)
                Next
                dcmReversed = (CDec(strReverseTemp)) / 1000

                If ((dcmTestProduct / 1000) - intIntegerComponent) - (dcmReversed) = 0 Then      'Integer component used to subtract to decimal component
                    intTemp = dcmTestProduct
                    Console.WriteLine(i & " x " & j & " = " & intTemp)
                    If intTemp > intLargest Then
                        intLargest = intTemp
                    End If
                End If
                strReverseTemp = ""         'FLUSH
            Next
        Next
        Console.WriteLine("Largest Palindrome Product = " & intLargest)
        Console.ReadLine()

    End Sub

End Module
