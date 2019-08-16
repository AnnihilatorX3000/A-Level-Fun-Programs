Option Strict On
Module Module1
    Sub Main()
        Const intTimeLength As Integer = 48
        Const arrXLength As Integer = 10
        Const intShiftLength As Integer = 100

        Dim arrShit(arrXLength, arrXLength) As Char
        Dim intShift As Integer = 0
        Dim intTemp As Integer = 0
        Dim blnUp As Boolean = True
        Dim intClouds As Integer = 0
        Dim intCloudColour As Integer = 0
        Dim intTime As Integer = 0

        Dim intLCounter As Integer = 0
        Dim intRCounter As Integer = 0
        Dim intWCounter As Integer = -1
        Dim blnWHasAdded As Boolean = False
        Dim intCloudColourChange As Integer = 15
        Dim intLoops As Integer = -1
        Dim blnLoopsHasAdded As Boolean = False
        Dim intHeightAdd As Integer = 0
        Dim blnCheckWIs5 As Boolean = True
        Dim intDaysPassed As Integer = 0
        Dim intDaysPassedTemp As Integer = -1

        Dim blnCheckDIs7 As Boolean = True
        Dim intWeeksPassed As Integer = 0
        Dim intWeeksPassedTemp As Integer = 0
        Dim intDaysCurrent As Integer = 0
        Dim intDaysPast As Integer = 0

        Dim intMonthsPassed As Integer = 0
        Dim intMonthsPassedTemp As Integer = 0
        Dim intWeeksCurrent As Integer = 0
        Dim intWeeksPast As Integer = 0
        Dim blnAllowCheckMonths As Boolean = True

        Dim intYearsPassed As Integer = 0
        Dim intYearsPassedTemp As Integer = 0
        Dim intMonthsCurrent As Integer = 0
        Dim intMonthsPast As Integer = 0
        Dim blnAllowCheckYears As Boolean = True

        Dim blnAllowCheckFinal As Boolean = True

        Console.WindowHeight = (arrXLength + 5)
        Console.WindowWidth = (arrXLength + intShiftLength + 6)

        'Put shits in the shitsss
        For i = 0 To arrXLength         'y                                'MOVING THING
            For j = 0 To arrXLength     'x
                If i = 0 Then
                    If j = 0 Then
                        arrShit(i, j) = CChar("<")
                    ElseIf j = arrXLength Then
                        arrShit(i, j) = CChar(">")
                    Else
                        arrShit(i, j) = CChar("=")
                    End If
                ElseIf i = arrXLength Then
                    arrShit(i, j) = CChar("~")
                ElseIf j = 0 Or j = arrXLength Then
                    arrShit(i, j) = CChar("|")
                Else
                    arrShit(i, j) = CChar(" ")
                End If
            Next
        Next

        Randomize()
        Do                              'Moving entire shit left and right infinitely
            'OUTPUTTING THE SHIT
            intTemp = intShift

            Console.BackgroundColor = ConsoleColor.DarkRed
            Console.ForegroundColor = ConsoleColor.White
            If intShift = 0 Then
                Console.BackgroundColor = ConsoleColor.Red
                Console.Write("+1")
            Else
                Console.Write("/|")
            End If


            If intShift = 0 Or intShift = intShiftLength Then
                intTime += 1
            End If
            If intShift = 0 Then
                intLCounter += 1
                intLoops += 1
                If intLoops = 1 Then
                    blnLoopsHasAdded = False
                End If
            End If

            For i = 0 To (intShiftLength + arrXLength)               'TOP FIRST
                If intTemp > 0 Then
                    Console.ForegroundColor = ConsoleColor.White
                    Console.BackgroundColor = ConsoleColor.DarkRed
                    Console.Write("-")
                    intTemp -= 1
                Else
                    If i <= (arrXLength + intShift) Then
                        Randomize()
                        Console.BackgroundColor = ConsoleColor.DarkRed
                        Console.Write(arrShit(0, (i - intShift)))
                    Else
                        Console.ForegroundColor = ConsoleColor.White
                        Console.BackgroundColor = ConsoleColor.DarkRed
                        Console.Write("-")
                    End If
                End If
                Console.BackgroundColor = ConsoleColor.Black
            Next
            Console.ForegroundColor = ConsoleColor.White
            If (intShiftLength - intShift) = 0 Then
                Console.BackgroundColor = ConsoleColor.Red
                Console.Write("+1" & vbCrLf)
            Else
                Console.BackgroundColor = ConsoleColor.DarkRed
                Console.Write("|\" & vbCrLf)
            End If

            For i = 1 To arrXLength                                  'THEN REMAINING BOTTOMs
                If intShift = 0 Then
                    Console.BackgroundColor = ConsoleColor.Red
                Else
                    Console.BackgroundColor = ConsoleColor.DarkRed
                End If
                Console.Write("||")

                If intShift = 0 Or intShift = intShiftLength Then
                    intTime += 1
                End If
                If intShift = intShiftLength Then
                    intRCounter += 1
                End If

                For shift = 0 To (intShift - 1)
                    If intTime > 0 And intTime < 1 * (intTimeLength) Then
                        Console.BackgroundColor = ConsoleColor.Cyan
                        intCloudColour = 15
                    ElseIf intTime >= 1 * (intTimeLength) And intTime < 2 * (intTimeLength) Then
                        Console.BackgroundColor = ConsoleColor.DarkCyan
                        intCloudColour = 7
                    ElseIf intTime >= 2 * (intTimeLength) And intTime < 3 * (intTimeLength) Then
                        Console.BackgroundColor = ConsoleColor.DarkBlue
                        intCloudColour = 14
                    ElseIf intTime >= 3 * (intTimeLength) And intTime < 4 * (intTimeLength) Then
                        Console.BackgroundColor = ConsoleColor.Black
                        intCloudColour = 8
                    ElseIf intTime >= 4 * (intTimeLength) And intTime < 5 * (intTimeLength) Then
                        Console.BackgroundColor = ConsoleColor.DarkCyan
                        intCloudColour = 7
                    ElseIf intTime >= 5 * (intTimeLength) And intTime < 6 * (intTimeLength) Then
                        intTime = 0
                    End If

                    intClouds = CInt(Rnd() * 4)
                    If intClouds = 0 And i < 7 And i > 1 Then
                        Console.BackgroundColor = CType(intCloudColour, ConsoleColor)
                    End If
                    Console.Write(" ")
                Next
                Console.BackgroundColor = ConsoleColor.Black

                For j = 0 To arrXLength
                    Console.BackgroundColor = CType(Rnd() * 15, ConsoleColor)
                    If i = arrXLength Or j = 0 Or j = arrXLength Then
                        Console.ForegroundColor = ConsoleColor.Black

                        If intTime > 0 And intTime < 1 * (intTimeLength) Then
                            Console.BackgroundColor = ConsoleColor.Cyan
                        ElseIf intTime >= 1 * (intTimeLength) And intTime < 2 * (intTimeLength) Then
                            Console.BackgroundColor = ConsoleColor.DarkCyan
                        ElseIf intTime >= 2 * (intTimeLength) And intTime < 3 * (intTimeLength) Then
                            Console.BackgroundColor = ConsoleColor.DarkBlue
                        ElseIf intTime >= 3 * (intTimeLength) And intTime < 4 * (intTimeLength) Then
                            Console.BackgroundColor = ConsoleColor.Black
                        ElseIf intTime >= 4 * (intTimeLength) And intTime < 5 * (intTimeLength) Then
                            Console.BackgroundColor = ConsoleColor.DarkCyan
                        ElseIf intTime >= 5 * (intTimeLength) And intTime < 6 * (intTimeLength) Then
                            intTime = 0
                        End If

                    End If
                    Console.Write(arrShit(i, j))
                Next

                For j = 1 To (intShiftLength - intShift)
                    If intTime > 0 And intTime < 1 * (intTimeLength) Then
                        Console.BackgroundColor = ConsoleColor.Cyan
                        intCloudColour = 15
                        If intCloudColour <> intCloudColourChange Then
                            blnWHasAdded = False
                            intCloudColourChange = intCloudColour
                        End If
                        If blnWHasAdded = False Then
                            intWCounter += 1
                            intDaysPassedTemp += 1
                            blnWHasAdded = True
                        End If
                    ElseIf intTime >= 1 * (intTimeLength) And intTime < 2 * (intTimeLength) Then
                        Console.BackgroundColor = ConsoleColor.DarkCyan
                        intCloudColour = 7
                        If intCloudColour <> intCloudColourChange Then
                            blnWHasAdded = False
                            intCloudColourChange = intCloudColour
                        End If
                        If blnWHasAdded = False Then
                            intWCounter += 1
                            intDaysPassedTemp += 1
                            blnWHasAdded = True
                            If intWCounter = 1 Then
                                blnLoopsHasAdded = False
                            End If
                        End If

                    ElseIf intTime >= 2 * (intTimeLength) And intTime < 3 * (intTimeLength) Then
                        Console.BackgroundColor = ConsoleColor.DarkBlue
                        intCloudColour = 14
                        If intCloudColour <> intCloudColourChange Then
                            blnWHasAdded = False
                            intCloudColourChange = intCloudColour
                        End If
                        If blnWHasAdded = False Then
                            intWCounter += 1
                            intDaysPassedTemp += 1
                            blnWHasAdded = True
                        End If
                    ElseIf intTime >= 3 * (intTimeLength) And intTime < 4 * (intTimeLength) Then
                        Console.BackgroundColor = ConsoleColor.Black
                        intCloudColour = 8
                        If intCloudColour <> intCloudColourChange Then
                            blnWHasAdded = False
                            intCloudColourChange = intCloudColour
                        End If
                        If blnWHasAdded = False Then
                            intWCounter += 1
                            intDaysPassedTemp += 1
                            blnWHasAdded = True
                        End If
                    ElseIf intTime >= 4 * (intTimeLength) And intTime < 5 * (intTimeLength) Then
                        Console.BackgroundColor = ConsoleColor.DarkCyan
                        intCloudColour = 7
                        If intCloudColour <> intCloudColourChange Then
                            blnWHasAdded = False
                            intCloudColourChange = intCloudColour
                        End If
                        If blnWHasAdded = False Then
                            intWCounter += 1
                            intDaysPassedTemp += 1
                            blnWHasAdded = True
                        End If
                    ElseIf intTime >= 5 * (intTimeLength) And intTime < 6 * (intTimeLength) Then
                        intTime = 0
                        If intCloudColour <> intCloudColourChange Then
                            blnWHasAdded = False
                            intCloudColourChange = intCloudColour
                        End If
                        If blnWHasAdded = False Then
                            intWCounter += 1
                            intDaysPassedTemp += 1
                            blnWHasAdded = True
                        End If
                    End If

                    intClouds = CInt(Rnd() * 4)
                    If intClouds = 0 And i < 7 And i > 1 Then
                        Console.BackgroundColor = CType(intCloudColour, ConsoleColor)
                    End If
                    Console.Write(" ")
                Next
                Console.BackgroundColor = ConsoleColor.Black

                Console.ForegroundColor = ConsoleColor.White
                If (intShiftLength - intShift) = 0 Then
                    Console.BackgroundColor = ConsoleColor.Red
                Else
                    Console.BackgroundColor = ConsoleColor.DarkRed
                End If
                Console.Write("||")
                Console.WriteLine()
            Next

            Console.ForegroundColor = ConsoleColor.Green         'YO ASS IS GRASS
            Console.BackgroundColor = ConsoleColor.DarkGreen

            For j = 0 To (arrXLength + intShiftLength + 4)
                Console.Write("^")
            Next

            'CHECK TO ADD HEIGHT
            If blnCheckWIs5 = True Then                         'TRAP CHECKER: CHECK ONCE THEN ONCE FOUND NEVER CHECK AGAIN
                If intWCounter = 5 Then                         'W is 5 means 1 day passed
                    intHeightAdd += 1
                    blnCheckWIs5 = False
                End If
            End If

            Console.WriteLine()
            Console.ForegroundColor = ConsoleColor.White
            Console.BackgroundColor = ConsoleColor.Black
            Console.WriteLine("Left Boops: " & intLCounter)
            Console.WriteLine("Right Boops: " & intRCounter / 10)
            If intWCounter = 1 Or intLoops = 1 Or intWCounter = 5 Then
                If blnLoopsHasAdded = False Then
                    Console.WindowHeight += 1
                    blnLoopsHasAdded = True
                End If
            End If

            If intDaysPassedTemp = 5 Then
                intDaysPassed += 1
                intDaysPassedTemp = 0
            End If

            '//NEW SYSTEM===================================================
            intDaysCurrent = intDaysPassed              'WEEKS
            If intDaysCurrent <> intDaysPast Then
                intWeeksPassedTemp += 1
                intDaysPast = intDaysCurrent
            End If
            If intWeeksPassedTemp = 7 Then
                intWeeksPassed += 1
                intWeeksPassedTemp = 0
            End If

            intWeeksCurrent = intWeeksPassed            'MONTHS
            If intWeeksCurrent <> intWeeksPast Then
                intMonthsPassedTemp += 1
                intWeeksPast = intWeeksCurrent
            End If
            If intMonthsPassedTemp = 4 Then
                intMonthsPassed += 1
                intMonthsPassedTemp = 0
            End If

            intMonthsCurrent = intMonthsPassed            'YEARS
            If intMonthsCurrent <> intMonthsPast Then
                intYearsPassedTemp += 1
                intMonthsPast = intMonthsCurrent
            End If
            If intYearsPassedTemp = 12 Then
                intYearsPassed += 1
                intYearsPassedTemp = 0
            End If

            If blnCheckDIs7 = True Then                         'FOR STARTING WEEKS
                If intDaysPassed = 7 Then
                    intHeightAdd += 1
                    blnCheckDIs7 = False
                End If
            End If

            If blnAllowCheckMonths = True Then                         'FOR STARTING MONTHS
                If intMonthsPassed = 1 Then
                    intHeightAdd += 1
                    blnAllowCheckMonths = False
                End If
            End If

            If blnAllowCheckYears = True Then                        'FOR STARTING YEARS
                If intYearsPassed = 1 Then
                    intHeightAdd += 1
                    blnAllowCheckYears = False
                End If
            End If

            If blnAllowCheckFinal = True Then                            'FINAL MESSAGE
                If intYearsPassed = 10 Then
                    intHeightAdd += 1
                    blnAllowCheckYears = False
                End If
            End If

            If intHeightAdd > 0 Then
                Console.WindowHeight += 1
                intHeightAdd -= 1
            End If

            If intLoops > 0 Then
                Console.WriteLine("Loops Done: " & intLoops)
            End If
            If intWCounter > 0 Then
                Console.WriteLine("Time Period Changes: " & intWCounter)
            End If

            If intDaysPassed > 0 Then
                Console.WriteLine("Days Passed: " & intDaysPassed)
            End If
            If intWeeksPassed > 0 Then
                Console.WriteLine("Weeks Passed: " & intWeeksPassed)
            End If

            If intMonthsPassed > 0 Then
                Console.WriteLine("Months Passed: " & intMonthsPassed)
            End If

            If intYearsPassed > 0 Then
                Console.WriteLine("Years Passed: " & intYearsPassed)
            End If

            If blnAllowCheckFinal = False Then
                Console.WriteLine("Seriously, what are you doing with your life...")
            End If

            For j = 0 To (arrXLength + intShiftLength + 4)
                Console.Write("_")
            Next

            If intShift = intShiftLength Then
                blnUp = False
            ElseIf intShift = 0 Then
                blnUp = True
            End If

            If blnUp = True Then            'GOIN UP
                intShift += 1
            ElseIf blnUp = False Then       'GOIN DOWN
                intShift -= 1
            End If
            Threading.Thread.Sleep(80)
            Console.Clear()
        Loop
    End Sub

End Module
