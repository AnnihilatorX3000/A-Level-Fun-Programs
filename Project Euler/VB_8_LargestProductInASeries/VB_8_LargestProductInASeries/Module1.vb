Option Strict On
Imports System.IO
Module Module1
    Const NUMBERS As String = "C:\Users\AnnihilatorX3000\Documents\Visual Studio 2015\Projects\Project Euler\VB_8_LargestProductInASeries\Number.txt"
    Dim arrToProduct(12) As Integer
    Dim intToArray As Integer = 0
    Dim dcmProduct As Decimal = 1
    Dim dcmProductTemp As Decimal = 1
    Dim strmReader As StreamReader = New StreamReader(NUMBERS)
    Dim strNumbers As String = "73167176531330624919225119674426574742355349194934" &
                               "96983520312774506326239578318016984801869478851843" &
                               "85861560789112949495459501737958331952853208805511" &
                               "12540698747158523863050715693290963295227443043557" &
                               "66896648950445244523161731856403098711121722383113" &
                               "62229893423380308135336276614282806444486645238749" &
                               "30358907296290491560440772390713810515859307960866" &
                               "70172427121883998797908792274921901699720888093776" &
                               "65727333001053367881220235421809751254540594752243" &
                               "52584907711670556013604839586446706324415722155397" &
                               "53697817977846174064955149290862569321978468622482" &
                               "83972241375657056057490261407972968652414535100474" &
                               "82166370484403199890008895243450658541227588666881" &
                               "16427171479924442928230863465674813919123162824586" &
                               "17866458359124566529476545682848912883142607690042" &
                               "24219022671055626321111109370544217506941658960408" &
                               "07198403850962455444362981230987879927244284909188" &
                               "84580156166097919133875499200524063689912560717606" &
                               "05886116467109405077541002256983155200055935729725" &
                               "71636269561882670428252483600823257530420752963450"

    '☺
    'PROBLEM #8
    'The four adjacent digits In the 1000-digit number that have the greatest product are 9 × 9 × 8 × 9 = 5832.
    '73167176531330624919225119674426574742355349194934
    '96983520312774506326239578318016984801869478851843
    '85861560789112949495459501737958331952853208805511
    '12540698747158523863050715693290963295227443043557
    '66896648950445244523161731856403098711121722383113
    '62229893423380308135336276614282806444486645238749
    '30358907296290491560440772390713810515859307960866
    '70172427121883998797908792274921901699720888093776
    '65727333001053367881220235421809751254540594752243
    '52584907711670556013604839586446706324415722155397
    '53697817977846174064955149290862569321978468622482
    '83972241375657056057490261407972968652414535100474
    '82166370484403199890008895243450658541227588666881
    '16427171479924442928230863465674813919123162824586
    '17866458359124566529476545682848912883142607690042
    '24219022671055626321111109370544217506941658960408
    '07198403850962455444362981230987879927244284909188
    '84580156166097919133875499200524063689912560717606
    '05886116467109405077541002256983155200055935729725
    '71636269561882670428252483600823257530420752963450
    'Find the thirteen adjacent digits In the 1000-digit number that have the greatest product. What Is the value Of this product?

    Sub Main()
        'INITIALISE
        For i = 0 To 12
            arrToProduct(i) = strmReader.Read()
            dcmProduct *= arrToProduct(i)
        Next

        Do
            'Shift left
            SHIFT()

            'PRODUCT AND COMPARE
            For i = 0 To 12
                dcmProductTemp *= arrToProduct(i)
            Next
            If dcmProductTemp > dcmProduct Then
                dcmProduct = dcmProductTemp
            End If
            dcmProductTemp = 1
        Loop

    End Sub
    Sub SHIFT()
        For i = 1 To 12
            arrToProduct(i - 1) = arrToProduct(i)
        Next

TRANSFER:
        intToArray = strmReader.Read
        If intToArray = -1 Then
            Console.WriteLine("End of file reached")

            GoTo ENDING
        ElseIf intToArray = 0 Then
            Console.WriteLine("0 detected. Skipping")
            GoTo TRANSFER
        End If

        arrToProduct(12) = intToArray
        Main()

ENDING:
        strmReader.Close()
        Console.WriteLine("NUMBERS FUCKED UP TOGETHER:")
        For i = 0 To 12
            Console.Write(arrToProduct(i))
            If i <> 12 Then
                Console.Write(" * ")
            End If
        Next
        Console.Write(" = " & dcmProduct)
        Console.ReadLine()


    End Sub
End Module
